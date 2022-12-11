// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD. Abdul Hakim
// Date: Oct 26, 2014
// Time : 11:25 AM
// Description: Class for DayStartEndLog.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class DayStartEndLog
    {
        private int _nLogID;
        private int _nWarehouseID;
        private int _nType;
        private DateTime _dOperationDate;
        private int _nCreateUserID;
        private object _dUploadDate;
        private string _sMobileNo;


        // <summary>
        // Get set property for LogID
        // </summary>
        public int LogID
        {
            get { return _nLogID; }
            set { _nLogID = value; }
        }

        // <summary>
        // Get set property for WarehouseID
        // </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        // <summary>
        // Get set property for Type
        // </summary>
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }

        // <summary>
        // Get set property for OperationDate
        // </summary>
        public DateTime OperationDate
        {
            get { return _dOperationDate; }
            set { _dOperationDate = value; }
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
        // Get set property for UploadDate
        // </summary>
        public object UploadDate
        {
            get { return _dUploadDate; }
            set { _dUploadDate = value; }
        }
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value; }
        }
        

        private string _sWarehouseCode;
        private DateTime _dLastClosingDate;
        private int _nDays;
        public string WarehouseCode
        {
            get { return _sWarehouseCode; }
            set { _sWarehouseCode = value; }
        }
        public DateTime LastClosingDate
        {
            get { return _dLastClosingDate; }
            set { _dLastClosingDate = value; }
        }
        public int Days
        {
            get { return _nDays; }
            set { _nDays = value; }
        }

        public void Add()
        {
            int nMaxLogID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([LogID]) FROM t_DayStartEndLog";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxLogID = 1;
                }
                else
                {
                    nMaxLogID = Convert.ToInt32(maxID) + 1;
                }
                if (_nLogID == 0)
                {
                    _nLogID = nMaxLogID;
                }

                sSql = "INSERT INTO t_DayStartEndLog (LogID, WarehouseID, Type, OperationDate, CreateUserID, UploadDate) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LogID", _nLogID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("OperationDate", _dOperationDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UploadDate", _dUploadDate);

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
                sSql = "UPDATE t_DayStartEndLog SET WarehouseID = ?, Type = ?, OperationDate = ?, CreateUserID = ?, UploadDate = ? WHERE LogID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("OperationDate", _dOperationDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UploadDate", _dUploadDate);

                cmd.Parameters.AddWithValue("LogID", _nLogID);

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
                sSql = "DELETE FROM t_DayStartEndLog WHERE [LogID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LogID", _nLogID);
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
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_DayStartEndLog where LogID =?";
                cmd.Parameters.AddWithValue("LogID", _nLogID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nLogID = (int)reader["LogID"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _nType = (int)reader["Type"];
                    _dOperationDate = Convert.ToDateTime(reader["OperationDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dUploadDate = Convert.ToDateTime(reader["UploadDate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckLog()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "select * from t_DayStartEndLog Where LogID=? and WarehouseID=? and Type=?";
                cmd.Parameters.AddWithValue("LogID", _nLogID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                return true;
            else return false;
        }
    }
    public class DayStartEndLogs : CollectionBase
    {
        public DayStartEndLog this[int i]
        {
            get { return (DayStartEndLog)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DayStartEndLog oDayStartEndLog)
        {
            InnerList.Add(oDayStartEndLog);
        }
        public int GetIndex(int nLogID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].LogID == nLogID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DayStartEndLog";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DayStartEndLog oDayStartEndLog = new DayStartEndLog();
                    oDayStartEndLog.LogID = (int)reader["LogID"];
                    oDayStartEndLog.WarehouseID = (int)reader["WarehouseID"];
                    oDayStartEndLog.Type = (int)reader["Type"];
                    oDayStartEndLog.OperationDate = Convert.ToDateTime(reader["OperationDate"].ToString());
                    oDayStartEndLog.CreateUserID = (int)reader["CreateUserID"];
                    oDayStartEndLog.UploadDate = Convert.ToDateTime(reader["UploadDate"].ToString());
                    InnerList.Add(oDayStartEndLog);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetLog(string sDB)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select ShortCode, LastClosingDate,MobileNo,Type,Days " +
                          "  from  " +
                          "  ( " +
                          "  Select ShortCode, LastClosingDate,MobileNo, " +
                          "  CASE When CONVERT(VARCHAR(20), ComDate, 114) > CONVERT(VARCHAR(20), getdate(), 114)  then 1 else 2 end as Type,Days from  " +
                          "  ( " +
                          "  Select ShortCode, LastClosingDate, CAST(LastClosingDate+ '22:00:00' as DATETIME ) as ComDate, MobileNo,Days " +
                          "  from " +
                          "  ( " +
                          "  Select ShortCode, LastClosingDate, MobileNo, " +
                          "  convert(int,Convert(datetime,replace(convert(varchar, getdate(),6),'','-'),1)-LastClosingDate) as Days from  " +
                          "  (select WarehouseID, max(Convert(datetime,replace(convert(varchar, OperationDate,6),'','-'),1)) as LastClosingDate   " +
                          "  from " + sDB + ".dbo.t_DayStartEndLog Where Type=2 Group by WarehouseID)a,  " +
                          "  " + sDB + ".dbo.t_Warehouse b , " + sDB + ".dbo.t_Showroom c  " +
                          "  Where a.WarehouseID=b.WarehouseID and a.WarehouseID=c.WarehouseID  " +
                          "  and IsPOSActive=1  " +
                          "  )a Where Days=1 " +
                          "  )a " +
                          "  UNION ALL " +
                          "  Select ShortCode, LastClosingDate, MobileNo,3 as Type,Days " +
                          "  from " +
                          "  ( " +
                          "  Select ShortCode, LastClosingDate, MobileNo, " +
                          "  convert(int,Convert(datetime,replace(convert(varchar, getdate(),6),'','-'),1)-LastClosingDate) as Days from  " +
                          "  (select WarehouseID, max(Convert(datetime,replace(convert(varchar, OperationDate,6),'','-'),1)) as LastClosingDate   " +
                          "  from " + sDB + ".dbo.t_DayStartEndLog Where Type=2 Group by WarehouseID)a,  " +
                          "  " + sDB + ".dbo.t_Warehouse b , " + sDB + ".dbo.t_Showroom c  " +
                          "  Where a.WarehouseID=b.WarehouseID and a.WarehouseID=c.WarehouseID  " +
                          "  and IsPOSActive=1  " +
                          "  )a Where Days>1 " +
                          "  )Final " +
                          "  order by Type DESC, LastClosingDate, shortcode";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DayStartEndLog oDayStartEndLog = new DayStartEndLog();
                    oDayStartEndLog.WarehouseCode = (string)reader["ShortCode"];
                    oDayStartEndLog.LastClosingDate = Convert.ToDateTime(reader["LastClosingDate"].ToString());
                    oDayStartEndLog.MobileNo = (string)reader["MobileNo"];
                    oDayStartEndLog.Type = (int)reader["Type"];
                    oDayStartEndLog.Days = (int)reader["Days"];
                    InnerList.Add(oDayStartEndLog);
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


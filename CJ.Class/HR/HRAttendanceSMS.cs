// <summary>
// Company: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Mar 04, 2021
// Time : 12:57 PM
// Description: Class for HRAttendanceSMS.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.HR
{
    public class HRAttendanceSMS
    {
        private int _nId;
        private int _nEmployeeId;
        private DateTime _dTDate;
        private int _nSMSId;
        private DateTime _dCreateDate;
        private int _nCreateUserId;


        // <summary>
        // Get set property for Id
        // </summary>
        public int Id
        {
            get { return _nId; }
            set { _nId = value; }
        }

        // <summary>
        // Get set property for EmployeeId
        // </summary>
        public int EmployeeId
        {
            get { return _nEmployeeId; }
            set { _nEmployeeId = value; }
        }

        // <summary>
        // Get set property for TDate
        // </summary>
        public DateTime TDate
        {
            get { return _dTDate; }
            set { _dTDate = value; }
        }

        // <summary>
        // Get set property for SMSId
        // </summary>
        public int SMSId
        {
            get { return _nSMSId; }
            set { _nSMSId = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        // <summary>
        // Get set property for CreateUserId
        // </summary>
        public int CreateUserId
        {
            get { return _nCreateUserId; }
            set { _nCreateUserId = value; }
        }

        private int _nTYear;
        public int TYear
        {
            get { return _nTYear; }
            set { _nTYear = value; }
        }

        public void Add()
        {
            int nMaxId = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([Id]) FROM t_HRAttendanceSMS";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxId = 1;
                }
                else
                {
                    nMaxId = Convert.ToInt32(maxID) + 1;
                }
                _nId = nMaxId;
                sSql = "INSERT INTO t_HRAttendanceSMS (Id, EmployeeId, TDate, SMSId, CreateDate, CreateUserId) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Id", _nId);
                cmd.Parameters.AddWithValue("EmployeeId", _nEmployeeId);
                cmd.Parameters.AddWithValue("TDate", _dTDate);
                cmd.Parameters.AddWithValue("SMSId", _nSMSId);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserId", _nCreateUserId);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddBirthdaySMS()
        {
            int nMaxId = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                //sSql = "SELECT MAX([Id]) FROM t_HRAttendanceSMS";
                //cmd.CommandText = sSql;
                //object maxID = cmd.ExecuteScalar();
                //if (maxID == DBNull.Value)
                //{
                //    nMaxId = 1;
                //}
                //else
                //{
                //    nMaxId = Convert.ToInt32(maxID) + 1;
                //}
                //_nId = nMaxId;
                sSql = "INSERT INTO t_HRBirthdaySMSLog (EmployeeId, TYear, SMSId, CreateDate, CreateUserId) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EmployeeId", _nEmployeeId);
                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("SMSId", _nSMSId);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserId", _nCreateUserId);

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
                sSql = "UPDATE t_HRAttendanceSMS SET EmployeeId = ?, TDate = ?, SMSId = ?, CreateDate = ?, CreateUserId = ? WHERE Id = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EmployeeId", _nEmployeeId);
                cmd.Parameters.AddWithValue("TDate", _dTDate);
                cmd.Parameters.AddWithValue("SMSId", _nSMSId);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserId", _nCreateUserId);

                cmd.Parameters.AddWithValue("Id", _nId);

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
                sSql = "DELETE FROM t_HRAttendanceSMS WHERE [Id]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Id", _nId);
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
                cmd.CommandText = "SELECT * FROM t_HRAttendanceSMS where Id =?";
                cmd.Parameters.AddWithValue("Id", _nId);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nId = (int)reader["Id"];
                    _nEmployeeId = (int)reader["EmployeeId"];
                    _dTDate = Convert.ToDateTime(reader["TDate"].ToString());
                    _nSMSId = (int)reader["SMSId"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserId = (int)reader["CreateUserId"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class HRAttendanceSMSs : CollectionBase
    {
        public HRAttendanceSMS this[int i]
        {
            get { return (HRAttendanceSMS)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRAttendanceSMS oHRAttendanceSMS)
        {
            InnerList.Add(oHRAttendanceSMS);
        }
        public int GetIndex(int nId)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].Id == nId)
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
            string sSql = "SELECT * FROM t_HRAttendanceSMS";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRAttendanceSMS oHRAttendanceSMS = new HRAttendanceSMS();
                    oHRAttendanceSMS.Id = (int)reader["Id"];
                    oHRAttendanceSMS.EmployeeId = (int)reader["EmployeeId"];
                    oHRAttendanceSMS.TDate = Convert.ToDateTime(reader["TDate"].ToString());
                    oHRAttendanceSMS.SMSId = (int)reader["SMSId"];
                    oHRAttendanceSMS.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oHRAttendanceSMS.CreateUserId = (int)reader["CreateUserId"];
                    InnerList.Add(oHRAttendanceSMS);
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


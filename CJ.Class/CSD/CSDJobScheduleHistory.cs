// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Mar 07, 2017
// Time : 10:45 AM
// Description: Class for CSDJobScheduleHistory.
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
    public class CSDJobScheduleHistory
    {
        private int _nID;
        private int _nJobID;
        private int _nType;
        private DateTime _dVisitingDate;
        private object _dVisitingTimeFrom;
        private object _dVisitingTimeTo;
        private int _nCreateUserID;
        private DateTime _dCreateDate;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for JobID
        // </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
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
        // Get set property for VisitingDate
        // </summary>
        public DateTime VisitingDate
        {
            get { return _dVisitingDate; }
            set { _dVisitingDate = value; }
        }

        // <summary>
        // Get set property for VisitingTimeFrom
        // </summary>
        public object VisitingTimeFrom
        {
            get { return _dVisitingTimeFrom; }
            set { _dVisitingTimeFrom = value; }
        }

        // <summary>
        // Get set property for VisitingTimeTo
        // </summary>
        public object VisitingTimeTo
        {
            get { return _dVisitingTimeTo; }
            set { _dVisitingTimeTo = value; }
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
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CSDJobScheduleHistory";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = Convert.ToInt32(maxID) + 1;
                }
                _nID = nMaxID;
                sSql = "INSERT INTO t_CSDJobScheduleHistory (ID, JobID, Type, VisitingDate, VisitingTimeFrom, VisitingTimeTo, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("VisitingDate", _dVisitingDate);
                cmd.Parameters.AddWithValue("VisitingTimeFrom", _dVisitingTimeFrom);
                cmd.Parameters.AddWithValue("VisitingTimeTo", _dVisitingTimeTo);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

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
                sSql = "UPDATE t_CSDJobScheduleHistory SET JobID = ?, Type = ?, VisitingDate = ?, VisitingTimeFrom = ?, VisitingTimeTo = ?, CreateUserID = ?, CreateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("VisitingDate", _dVisitingDate);
                cmd.Parameters.AddWithValue("VisitingTimeFrom", _dVisitingTimeFrom);
                cmd.Parameters.AddWithValue("VisitingTimeTo", _dVisitingTimeTo);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "DELETE FROM t_CSDJobScheduleHistory WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
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
                cmd.CommandText = "SELECT * FROM t_CSDJobScheduleHistory where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nJobID = (int)reader["JobID"];
                    _nType = (int)reader["Type"];
                    _dVisitingDate = Convert.ToDateTime(reader["VisitingDate"].ToString());
                    _dVisitingTimeFrom = (object)reader["VisitingTimeFrom"];
                    _dVisitingTimeTo = (object)reader["VisitingTimeTo"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
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
    public class CSDJobScheduleHistorys : CollectionBase
    {
        public CSDJobScheduleHistory this[int i]
        {
            get { return (CSDJobScheduleHistory)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDJobScheduleHistory oCSDJobScheduleHistory)
        {
            InnerList.Add(oCSDJobScheduleHistory);
        }
        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
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
            string sSql = "SELECT * FROM t_CSDJobScheduleHistory";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJobScheduleHistory oCSDJobScheduleHistory = new CSDJobScheduleHistory();
                    oCSDJobScheduleHistory.ID = (int)reader["ID"];
                    oCSDJobScheduleHistory.JobID = (int)reader["JobID"];
                    oCSDJobScheduleHistory.Type = (int)reader["Type"];
                    oCSDJobScheduleHistory.VisitingDate = Convert.ToDateTime(reader["VisitingDate"].ToString());
                    oCSDJobScheduleHistory.VisitingTimeFrom = (object)reader["VisitingTimeFrom"];
                    oCSDJobScheduleHistory.VisitingTimeTo = (object)reader["VisitingTimeTo"];
                    oCSDJobScheduleHistory.CreateUserID = (int)reader["CreateUserID"];
                    oCSDJobScheduleHistory.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oCSDJobScheduleHistory);
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


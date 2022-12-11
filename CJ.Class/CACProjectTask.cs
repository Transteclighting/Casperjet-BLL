// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Apr 25, 2019
// Time : 05:54 PM
// Description: Class for CACProjectTask.
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
    public class CACProjectTask
    {
        private int _nTaskID;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private string _sTaskName;
        private int _nIsActive;
        private double _dWeight;
        private DateTime _dStartDate;
        private DateTime _dEndDate;
        private double _dCompleteWeight;

        // <summary>
        // Get set property for TaskID
        // </summary>
        public int TaskID
        {
            get { return _nTaskID; }
            set { _nTaskID = value; }
        }
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        public DateTime StartDate
        {
            get { return _dStartDate; }
            set { _dStartDate = value; }
        }
        public DateTime EndDate
        {
            get { return _dEndDate; }
            set { _dEndDate = value; }
        }
        // <summary>
        // Get set property for TaskName
        // </summary>
        public string TaskName
        {
            get { return _sTaskName; }
            set { _sTaskName = value.Trim(); }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
        public double Weight
        {
            get { return _dWeight; }
            set { _dWeight = value; }
        }
        public double CompleteWeight
        {
            get { return _dCompleteWeight; }
            set { _dCompleteWeight = value; }
        }
        public void Add()
        {
            int nMaxTaskID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TaskID]) FROM t_CACProjectTask";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxTaskID = 1;
                }
                else
                {
                    nMaxTaskID = Convert.ToInt32(maxID) + 1;
                }
                _nTaskID = nMaxTaskID;
                sSql = "INSERT INTO t_CACProjectTask (TaskID, TaskName, CreateUserID, CreateDate, IsActive) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TaskID", _nTaskID);
                cmd.Parameters.AddWithValue("TaskName", _sTaskName);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

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
                sSql = "UPDATE t_CACProjectTask SET TaskName = ?, IsActive = ? WHERE TaskID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TaskName", _sTaskName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.Parameters.AddWithValue("TaskID", _nTaskID);

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
                sSql = "DELETE FROM t_CACProjectTask WHERE [TaskID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TaskID", _nTaskID);
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
                cmd.CommandText = "SELECT * FROM t_CACProjectTask where TaskID =?";
                cmd.Parameters.AddWithValue("TaskID", _nTaskID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTaskID = (int)reader["TaskID"];
                    _sTaskName = (string)reader["TaskName"];
                    _nIsActive = (int)reader["IsActive"];
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
    public class CACProjectTasks : CollectionBase
    {
        public CACProjectTask this[int i]
        {
            get { return (CACProjectTask)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CACProjectTask oCACProjectTask)
        {
            InnerList.Add(oCACProjectTask);
        }
        public int GetIndex(int nTaskID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].TaskID == nTaskID)
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
            string sSql = "SELECT * FROM t_CACProjectTask";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACProjectTask oCACProjectTask = new CACProjectTask();
                    oCACProjectTask.TaskID = (int)reader["TaskID"];
                    oCACProjectTask.TaskName = (string)reader["TaskName"];
                    oCACProjectTask.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oCACProjectTask);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshWeight(int nProjectID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CACProjectTask a,t_CACProjectTaskWeight b where a.TaskID=b.TaskID and ProjectID="+ nProjectID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACProjectTask oCACProjectTask = new CACProjectTask();
                    oCACProjectTask.TaskID = (int)reader["TaskID"];
                    oCACProjectTask.TaskName = (string)reader["TaskName"];
                    oCACProjectTask.IsActive = (int)reader["IsActive"];
                    oCACProjectTask.Weight= Convert.ToDouble(reader["Weight"].ToString());
                    oCACProjectTask.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                    oCACProjectTask.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                    oCACProjectTask.CompleteWeight= Convert.ToDouble(reader["CompletePercent"].ToString());
                    InnerList.Add(oCACProjectTask);
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



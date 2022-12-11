// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: May 12, 2019
// Time : 11:59 AM
// Description: Class for CACProjectTaskComplete.
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
    public class CACProjectTaskComplete
    {
        private int _nID;
        private int _nProjectID;
        private int _nTaskID;
        private DateTime _dDate;
        private double _CompleteProgressWeight;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for ProjectID
        // </summary>
        public int ProjectID
        {
            get { return _nProjectID; }
            set { _nProjectID = value; }
        }

        // <summary>
        // Get set property for TaskID
        // </summary>
        public int TaskID
        {
            get { return _nTaskID; }
            set { _nTaskID = value; }
        }

        // <summary>
        // Get set property for Date
        // </summary>
        public DateTime Date
        {
            get { return _dDate; }
            set { _dDate = value; }
        }

        // <summary>
        // Get set property for CompleteProgressWeight
        // </summary>
        public double CompleteProgressWeight
        {
            get { return _CompleteProgressWeight; }
            set { _CompleteProgressWeight = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CACProjectTaskComplete";
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
                sSql = "INSERT INTO t_CACProjectTaskComplete (ID, ProjectID, TaskID, Date, CompleteProgressWeight) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("TaskID", _nTaskID);
                cmd.Parameters.AddWithValue("Date", _dDate);
                cmd.Parameters.AddWithValue("CompleteProgressWeight", _CompleteProgressWeight);

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
                sSql = "UPDATE t_CACProjectTaskComplete SET ProjectID = ?, TaskID = ?, Date = ?, CompleteProgressWeight = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("TaskID", _nTaskID);
                cmd.Parameters.AddWithValue("Date", _dDate);
                cmd.Parameters.AddWithValue("CompleteProgressWeight", _CompleteProgressWeight);

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
                sSql = "DELETE FROM t_CACProjectTaskComplete WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_CACProjectTaskComplete where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nProjectID = (int)reader["ProjectID"];
                    _nTaskID = (int)reader["TaskID"];
                    _dDate = Convert.ToDateTime(reader["Date"].ToString());
                    _CompleteProgressWeight = Convert.ToDouble(reader["CompleteProgressWeight"].ToString());
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
    public class CACProjectTaskCompletes : CollectionBase
    {
        public CACProjectTaskComplete this[int i]
        {
            get { return (CACProjectTaskComplete)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CACProjectTaskComplete oCACProjectTaskComplete)
        {
            InnerList.Add(oCACProjectTaskComplete);
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
            string sSql = "SELECT * FROM t_CACProjectTaskComplete";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACProjectTaskComplete oCACProjectTaskComplete = new CACProjectTaskComplete();
                    oCACProjectTaskComplete.ID = (int)reader["ID"];
                    oCACProjectTaskComplete.ProjectID = (int)reader["ProjectID"];
                    oCACProjectTaskComplete.TaskID = (int)reader["TaskID"];
                    oCACProjectTaskComplete.Date = Convert.ToDateTime(reader["Date"].ToString());
                    oCACProjectTaskComplete.CompleteProgressWeight = Convert.ToDouble(reader["CompleteProgressWeight"].ToString());
                    InnerList.Add(oCACProjectTaskComplete);
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


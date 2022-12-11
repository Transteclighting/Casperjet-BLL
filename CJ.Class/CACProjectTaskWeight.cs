// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Apr 25, 2019
// Time : 05:55 PM
// Description: Class for CACProjectTaskWeight.
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
    public class CACProjectTaskWeight
    {
        private int _nID;
        private int _nProjectID;
        private int _nTaskID;
        private double _Weight;
        private double _Percentage;
        private double _CompletePercent;
        private string _sTaskName;
        private DateTime _dStartDate;
        private DateTime _dEndDate;


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
        // Get set property for Weight
        // </summary>
        public double Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }
        public double CompletePercent
        {
            get { return _CompletePercent; }
            set { _CompletePercent = value; }
        }

        // <summary>
        // Get set property for Percentage
        // </summary>
        public double Percentage
        {
            get { return _Percentage; }
            set { _Percentage = value; }
        }
        public string TaskName
        {
            get { return _sTaskName; }
            set { _sTaskName = value.Trim(); }
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
        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CACProjectTaskWeight";
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
                sSql = "INSERT INTO t_CACProjectTaskWeight (ID, ProjectID, TaskID, Weight,CompletePercent,Startdate,Enddate) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("TaskID", _nTaskID);
                cmd.Parameters.AddWithValue("Weight", _Weight);
                cmd.Parameters.AddWithValue("CompletePercent", _CompletePercent);
                cmd.Parameters.AddWithValue("StartDate", _dStartDate);
                cmd.Parameters.AddWithValue("EndDate", _dEndDate);

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
                sSql = "UPDATE t_CACProjectTaskWeight SET ProjectID = ?, TaskID = ?, Weight = ?,CompletePercent = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("TaskID", _nTaskID);
                cmd.Parameters.AddWithValue("Weight", _Weight);
                cmd.Parameters.AddWithValue("CompletePercent", _CompletePercent);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateCompleteTaskWeight(int _nProjectID, int nID)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CACProjectTaskWeight SET CompletePercent = CompletePercent + ? WHERE ProjectID = ? And ID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;               
                cmd.Parameters.AddWithValue("CompletePercent", _CompletePercent);
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
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
                sSql = "DELETE FROM t_CACProjectTaskWeight WHERE [ID]=?";
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
        public void DeleteByTaskWeight(int _nProjectID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_CACProjectTaskWeight WHERE ProjectID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
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
                cmd.CommandText = "SELECT * FROM t_CACProjectTaskWeight where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nProjectID = (int)reader["ProjectID"];
                    _nTaskID = (int)reader["TaskID"];
                    _Weight = Convert.ToDouble(reader["Weight"].ToString());
                    //_Percentage = Convert.ToDouble(reader["Percentage"].ToString());
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
    public class CACProjectTaskWeights : CollectionBase
    {
        public CACProjectTaskWeight this[int i]
        {
            get { return (CACProjectTaskWeight)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CACProjectTaskWeight oCACProjectTaskWeight)
        {
            InnerList.Add(oCACProjectTaskWeight);
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
            string sSql = "Select * from t_CACProjectTaskWeight ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACProjectTaskWeight oCACProjectTaskWeight = new CACProjectTaskWeight();
                    oCACProjectTaskWeight.ID = (int)reader["ID"];
                    oCACProjectTaskWeight.ProjectID = (int)reader["ProjectID"];
                    oCACProjectTaskWeight.TaskID = (int)reader["TaskID"];
                    oCACProjectTaskWeight.Weight = Convert.ToDouble(reader["Weight"].ToString());
                    oCACProjectTaskWeight.CompletePercent = Convert.ToDouble(reader["CompletePercent"].ToString());
                    InnerList.Add(oCACProjectTaskWeight);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByTaskWeight(int nProjectID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.ID,ProjectID,a.TaskID,TaskName,Weight,CompletePercent,StartDate,EndDate from t_CACProjectTaskWeight a,t_CACProjectTask b where a.TaskID=b.TaskID and ProjectID=" + nProjectID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACProjectTaskWeight oCACProjectTaskWeight = new CACProjectTaskWeight();
                    oCACProjectTaskWeight.ID = (int)reader["ID"];
                    oCACProjectTaskWeight.ProjectID = (int)reader["ProjectID"];
                    oCACProjectTaskWeight.TaskID = (int)reader["TaskID"];
                    oCACProjectTaskWeight.TaskName = (string)reader["TaskName"];
                    oCACProjectTaskWeight.Weight = Convert.ToDouble(reader["Weight"].ToString());
                    oCACProjectTaskWeight.CompletePercent = Convert.ToDouble(reader["CompletePercent"].ToString());
                    oCACProjectTaskWeight.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                    oCACProjectTaskWeight.EndDate= Convert.ToDateTime(reader["EndDate"].ToString());
                    InnerList.Add(oCACProjectTaskWeight);
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



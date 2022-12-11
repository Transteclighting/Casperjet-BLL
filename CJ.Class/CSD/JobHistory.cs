// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Aug 07, 2014
// Time :  11:00 PM
// Description: Class for Job History
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.CSD
{
    public class JobHistory
    {

        private int _nJobHistoryID;
        private int _nJobID;
        private int _nStatusID;
        //private int _nSubStatusID;
        private string _sSubStatusName;
        private int _nCreateUserID;
        private string _sUserName;
        private DateTime _dCreateDate;
        private string _sRemarks;
        private int _nSubStatusID;
        private int _nServiceType;


        /// <summary>
        /// Get set property for ServiceType
        /// </summary>
        public int ServiceType
        {
            get { return _nServiceType; }
            set { _nServiceType = value; }
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
        /// Get set property for JobHistoryID
        /// </summary>
        public int JobHistoryID
        {
            get { return _nJobHistoryID; }
            set { _nJobHistoryID = value; }
        }
        /// <summary>
        /// Get set property for JobID
        /// </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }
        /// <summary>
        /// Get set property for StatusID
        /// </summary>
        public int StatusID
        {
            get { return _nStatusID; }
            set { _nStatusID = value; }
        }

        /// <summary>
        /// Get set property for SubStatusID
        /// </summary>
        public int SubStatusID
        {
            get { return _nSubStatusID; }
            set { _nSubStatusID = value; }
        }

        /// <summary>
        /// Get set property for SubStatusName
        /// </summary>
        public string SubStatusName
        {
            get { return _sSubStatusName; }
            set { _sSubStatusName = value; }
        }
        /// <summary>
        /// Get set property for CreateUserID
        /// </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }
        //public object SubStatusID
        //{
        //    get { return _nSubStatusID; }
        //    set { _nSubStatusID = value; }
        //}

        public void Add(object nSubStatusID)
        {
            int nMaxID = 0;
            int nMaxJobHistoryID = 0;


            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([JobHistoryID]) FROM t_CSDJobHistory";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxJobHistoryID = 1;
                }
                else
                {
                    nMaxJobHistoryID = Convert.ToInt32(maxID) + 1;
                }
                _nJobHistoryID = nMaxJobHistoryID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CSDJobHistory(JobHistoryID, JobID, StatusID, CreateUserID, CreateDate, Remarks, SubStatusID,ServiceType) Values (?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobHistoryID", _nJobHistoryID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("StatusID", _nStatusID);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("SubStatusID", nSubStatusID);
                cmd.Parameters.AddWithValue("ServiceType", _nServiceType);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
    public class JobHistorys : CollectionBase
    {
        public JobHistory this[int i]
        {
            get { return (JobHistory)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(JobHistory oJobHistory)
        {
            InnerList.Add(oJobHistory);
        }

        public int GetIndex(int nJobHistoryID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].JobHistoryID == nJobHistoryID)
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

            string sSql = "Select * from t_CSDJobHistory a INNER JOIN t_User b ON a.CreateUserID = b.UserID order by JobHistoryID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JobHistory oJobHistory = new JobHistory();
                    oJobHistory.JobHistoryID = (int)reader["JobHistoryID"];
                    oJobHistory.JobID = (int)reader["JobID"];
                    oJobHistory.StatusID = (int)reader["StatusID"];
                    oJobHistory.CreateUserID = (int)reader["CreateUserID"];
                    oJobHistory.UserName = (string)reader["UserName"];
                    oJobHistory.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                        oJobHistory.Remarks = (string)reader["Remarks"];
                    if (reader["ServiceType"] != DBNull.Value)
                    {
                        oJobHistory.ServiceType = (int)reader["ServiceType"];
                    }
                    InnerList.Add(oJobHistory);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByID(int nJobID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_CSDJobHistory a LEFT JOIN t_User b ON a.CreateUserID = b.UserID LEFT JOIN t_CSDJobStatus_Sub c ON a.SubStatusID = c.SubStatusID Where JobID= " + nJobID + " order by JobHistoryID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JobHistory oJobHistory = new JobHistory();
                    oJobHistory.JobHistoryID = (int)reader["JobHistoryID"];
                    oJobHistory.JobID = (int)reader["JobID"];
                    oJobHistory.StatusID = (int)reader["StatusID"];
                    if (reader["SubStatusID"] != DBNull.Value)
                    {
                        oJobHistory.SubStatusID = (int)reader["SubStatusID"];
                    }
                    if (reader["Name"] != DBNull.Value)
                    {
                        oJobHistory.SubStatusName = (string)reader["Name"];
                    }
                    oJobHistory.CreateUserID = (int)reader["CreateUserID"];
                    //oJobHistory.UserName = (string)reader["UserName"];
                    if (reader["UserName"] != DBNull.Value)
                    {
                        oJobHistory.UserName = (string)reader["UserName"];
                    }
                    oJobHistory.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oJobHistory.Remarks = (string)reader["Remarks"];
                    }
                    if (reader["ServiceType"] != DBNull.Value)
                    {
                        oJobHistory.ServiceType = (int)reader["ServiceType"];
                    }
                    InnerList.Add(oJobHistory);
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


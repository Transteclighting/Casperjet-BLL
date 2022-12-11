// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Aug 07, 2014
// Time :  11:20 PM
// Description: Class for Job Feedback Date History
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
    public class JobFeedbackDate
    {
        private int _nID;
        private int _nJobID;
        private int _nTechnicianID;
        private string _sTechnicianName;
        private int _nStatusID;
        private string _sSubStatusName;
        private DateTime _dFeedbackDate;
        private object _dVisitingTimeFrom;
        private object _dVisitingTimeTo;
        private int _nCreateUserID;
        private string _sUserName;
        private DateTime _dCreateDate;
        private string _sRemarks;

        /// <summary>
        /// Get set property for ID
        /// </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
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
        /// Get set property for TechnicianID
        /// </summary>
        public int TechnicianID
        {
            get { return _nTechnicianID; }
            set { _nTechnicianID = value; }
        }

        /// <summary>
        /// Get set property for TechnicianName
        /// </summary>
        public string TechnicianName
        {
            get { return _sTechnicianName; }
            set { _sTechnicianName = value; }
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
        /// Get set property for SubStatusName
        /// </summary>
        public string SubStatusName
        {
            get { return _sSubStatusName; }
            set { _sSubStatusName = value; }
        }
        /// <summary>
        /// Get set property for FeedbackDate
        /// </summary>
        public DateTime FeedbackDate
        {
            get { return _dFeedbackDate; }
            set { _dFeedbackDate = value; }
        }
        /// <summary>
        /// Get set property for VisitingTimeFrom
        /// </summary>
        public object VisitingTimeFrom
        {
            get { return _dVisitingTimeFrom; }
            set { _dVisitingTimeFrom = value; }
        }
        /// <summary>
        /// Get set property for VisitingTimeTo
        /// </summary>
        public object VisitingTimeTo
        {
            get { return _dVisitingTimeTo; }
            set { _dVisitingTimeTo = value; }
        }
        /// <summary>
        /// Get set property for CreateUserID
        /// </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        public string UserName
        {
            get { return _sUserName; }
            set { _sUserName = value; }
        }
        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        

        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            int nMaxFeedbackID = 0;


            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CSDFeedbackDateHistory";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxFeedbackID = 1;
                }
                else
                {
                    nMaxFeedbackID = Convert.ToInt32(maxID) + 1;
                }
                _nID = nMaxFeedbackID;
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "INSERT INTO t_CSDFeedbackDateHistory(ID,JobID,TechnicianID,StatusID, FeedbackDate,VisitingTimeFrom, VisitingTimeTo, CreateUserID, CreateDate, Remarks) Values (?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("TechnicianID", _nTechnicianID);
                cmd.Parameters.AddWithValue("StatusID", _nStatusID);
                cmd.Parameters.AddWithValue("FeedbackDate", _dFeedbackDate);
                cmd.Parameters.AddWithValue("VisitingTimeFrom", _dVisitingTimeFrom);
                cmd.Parameters.AddWithValue("VisitingTimeTo", _dVisitingTimeTo);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks); 
                

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckFeedbackDate(int nJobID, DateTime dToFeedbackDate)
        {
            DateTime dFromFeedbackDate = dToFeedbackDate.AddDays(1);
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDFeedbackDateHistory where JobID=" + nJobID + " "
                         +" AND FeedbackDate Between '" + dToFeedbackDate + "' AND '"+dFromFeedbackDate+"' "
                         +" AND FeedbackDate < '"+ dFromFeedbackDate +"' ";

            try
            {
                cmd.CommandText = sSql;
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
            if (nCount == 0)
                return false;
            else return true;
        }

    }
    public class JobFeedbackDates : CollectionBase
    {
        public JobFeedbackDate this[int i]
        {
            get { return (JobFeedbackDate)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(JobFeedbackDate oJobFeedbackDate)
        {
            InnerList.Add(oJobFeedbackDate);
        }

        public int GetIndex(int nJobFeedbackID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nJobFeedbackID)
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

            string sSql = "Select * from t_CSDFeedbackDateHistory order by ID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    JobFeedbackDate oJobFeedbackDate = new JobFeedbackDate();
                    oJobFeedbackDate.ID = (int)reader["ID"];
                    oJobFeedbackDate.JobID = (int)reader["JobID"];

                    InnerList.Add(oJobFeedbackDate);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByJobID(int nJobID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.ID,a.JobID,ISNULL(a.TechnicianID,0)TechnicianID,a.StatusID,ISNULL(Sub.Name,'')SubStatusName,ISNULL(t.Name,'')TechnicainName, "
                         + " a.FeedbackDate,a.VisitingTimeFrom,a.VisitingTimeTo,a.CreateUserID,u.UserName,"
                         + " a.CreateDate,a.Remarks from t_CSDFeedbackDateHistory a "
                         + " INNER JOIN t_CSDJob Job ON a.JobID = Job.JobId"
                         + " LEFT OUTER JOIN t_CSDJobStatus_Sub Sub ON Sub.SubStatusID = Job.SubStatus"
                         + " LEFT OUTER JOIN t_CSDTechnician t ON t.TechnicianID = a.TechnicianID"
                         + " INNER JOIN t_user u on u.userID = a.CreateUserID"
                         +" where a.JobID = '" + nJobID + "' order by a.ID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {                   
                    JobFeedbackDate oCSDFeedbackDateHistory = new JobFeedbackDate();
                    oCSDFeedbackDateHistory.ID = (int)reader["ID"];
                    oCSDFeedbackDateHistory.JobID = (int)reader["JobID"];
                    oCSDFeedbackDateHistory.TechnicianID = (int)reader["TechnicianID"];
                    oCSDFeedbackDateHistory.StatusID = (int)reader["StatusID"];
                    oCSDFeedbackDateHistory.SubStatusName = (string)reader["SubStatusName"];
                    oCSDFeedbackDateHistory.TechnicianName = (string)reader["TechnicainName"];
                    oCSDFeedbackDateHistory.FeedbackDate = Convert.ToDateTime(reader["FeedbackDate"].ToString());
                    
                    if (reader["VisitingTimeFrom"] != DBNull.Value)
                    {
                        oCSDFeedbackDateHistory.VisitingTimeFrom = Convert.ToDateTime(reader["VisitingTimeFrom"].ToString());
                    }
                    if (reader["VisitingTimeTo"] != DBNull.Value)
                    {
                        oCSDFeedbackDateHistory.VisitingTimeTo = Convert.ToDateTime(reader["VisitingTimeTo"].ToString());
                    }                    
                    oCSDFeedbackDateHistory.CreateUserID = (int)reader["CreateUserID"];
                    oCSDFeedbackDateHistory.UserName = (string)reader["UserName"];
                    oCSDFeedbackDateHistory.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oCSDFeedbackDateHistory.Remarks = (string)reader["Remarks"];
                    }                    
                    InnerList.Add(oCSDFeedbackDateHistory);
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



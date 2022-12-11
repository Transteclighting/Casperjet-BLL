using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

using CJ.Class;

namespace CJ.Class.IT
{
    public class ITSupportLog
    {
        private int _nJobID;
        private DateTime _dJobDate;
        private string _sCompany;
        private string _sJobFor;
        private string _sJobDescription;
        private DateTime _dAssignDate;
        private DateTime _dEndDate;
        private int _nPriority;
        private int _nStatus;
        private string _sUser;

        /// <summary>
        /// Get set property for JobID
        /// </summary>
        public int nJobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }


        /// <summary>
        /// Get set property for JobDate
        /// </summary>
        public DateTime dJobDate
        {
            get { return _dJobDate; }
            set { _dJobDate = value; }
        }

        /// <summary>
        /// Get set property for Company
        /// </summary>
        public string sCompany
        {
            get { return _sCompany; }
            set { _sCompany = value.Trim(); }
        }

        /// <summary>
        /// Get set property for JobFor
        /// </summary>
        public string sJobFor
        {
            get { return _sJobFor; }
            set { _sJobFor = value.Trim(); }
        }
        /// <summary>
        /// Get set property for JobDescription
        /// </summary>
        public string sJobDescription
        {
            get { return _sJobDescription; }
            set { _sJobDescription = value.Trim(); }
        }
        /// <summary>
        /// Get set property for AssignDate
        /// </summary>
        public DateTime dAssignDate
        {
            get { return _dAssignDate; }
            set { _dAssignDate = value; }
        }

        /// <summary>
        /// Get set property for AssignDate
        /// </summary>
        public DateTime dEndDate
        {
            get { return _dEndDate; }
            set { _dEndDate = value; }
        }
        /// <summary>
        /// Get set property for Priority
        /// </summary>
        public int nPriority
        {
            get { return _nPriority; }
            set { _nPriority = value; }
        }

        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int nStatus
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        /// <summary>
        /// Get set property for User
        /// </summary>
        public string sUser
        {
            get { return _sUser; }
            set { _sUser = value.Trim(); }
        }
        public void Add()
        {
            int nMaxJobID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([JobID]) FROM t_ITSupportLog";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxJobID = 1;
                }
                else
                {
                    nMaxJobID = Convert.ToInt32(maxID) + 1;
                }
                _nJobID = nMaxJobID;

                sSql = "INSERT INTO t_ITSupportLog(JobID,JobDate,Company,JobFor,JobDescription,AssignDate,EndDate,Priority,Status,[User])"
                    + " VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("JobDate", _dJobDate);
                cmd.Parameters.AddWithValue("Company", _sCompany);
                cmd.Parameters.AddWithValue("JobFor", _sJobFor);
                cmd.Parameters.AddWithValue("JobDescription", _sJobDescription);
                cmd.Parameters.AddWithValue("AssignDate", _dAssignDate);
                cmd.Parameters.AddWithValue("EndDate", _dEndDate);
                cmd.Parameters.AddWithValue("Priority", _nPriority);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("[User]", _sUser);

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

                sSql = "UPDATE t_ITSupportLog SET JobDate=?, Company=?, JobFor=?,JobDescription=?,AssignDate=?,EndDate=?,Priority=?,Status=?,[User]=?"
                    + " WHERE JobID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("JobDate", _dJobDate);
                cmd.Parameters.AddWithValue("Company", _sCompany);
                cmd.Parameters.AddWithValue("JobFor", _sJobFor);
                cmd.Parameters.AddWithValue("JobDescription", _sJobDescription);
                cmd.Parameters.AddWithValue("AssignDate", _dAssignDate);
                cmd.Parameters.AddWithValue("EndDate", _dEndDate);
                cmd.Parameters.AddWithValue("Priority", _nPriority);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("[User]", _sUser);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Delete(int _nJobID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_ITSupportLog WHERE [JobID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("JobID", _nJobID);
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
                cmd.CommandText = "SELECT * FROM t_ITSupportLog where JobID =?";
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nJobID = (int)reader["JobID"];
                    _dJobDate = (DateTime)reader["JobDate"];
                    _sCompany = (string)reader["Company"];
                    _sJobFor = (string)reader["JobFor"];
                    _sJobDescription = (string)reader["JobDescription"];
                    _dAssignDate = (DateTime)reader["AssignDate"];
                    _dEndDate = (DateTime)reader["EndDate"];
                    _nPriority = (int)reader["Priority"];
                    _nStatus = (int)reader["Status"];
                    _sUser = (string)reader["[User]"];
                    
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
    public class ITSupportLogs : CollectionBase
    {

        public ITSupportLog this[int i]
        {
            get { return (ITSupportLog)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ITSupportLog oITSupportLog)
        {
            InnerList.Add(oITSupportLog);
        }

        public int GetIndex(int nJobID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].nJobID == nJobID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh()
        {

            ITSupportLog oITSupportLog;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_ITSupportLog";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oITSupportLog = new ITSupportLog();

                    oITSupportLog.nJobID = (int)reader["JobID"];
                    oITSupportLog.dJobDate = (DateTime)reader["JobDate"];
                    oITSupportLog.sCompany = (string)reader["Company"];
                    oITSupportLog.sJobFor = (string)reader["JobFor"];
                    oITSupportLog.sJobDescription = (string)reader["JobDescription"];
                    oITSupportLog.dAssignDate = (DateTime)reader["AssignDate"];
                    oITSupportLog.dEndDate = (DateTime)reader["EndDate"];
                    oITSupportLog.nPriority = (int)reader["Priority"];
                    oITSupportLog.nStatus = (int)reader["Status"];
                    oITSupportLog.sUser = (string)reader["User"];
                    InnerList.Add(oITSupportLog);
                }
                reader.Close();

       
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshITSupportLog(DateTime dFromdate,DateTime dEndDate,int nStatus,string sUser)
        {

            ITSupportLog oITSupportLog;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_ITSupportLog";
            sSql=sSql + " where JobDate between  '" + dFromdate +"' AND  '"+dEndDate +"' ";
            sSql = sSql + " and Status= " + nStatus + " ";
            sSql = sSql + " and [User] like '%" + sUser + "%' ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oITSupportLog = new ITSupportLog();

                    oITSupportLog.nJobID = (int)reader["JobID"];
                    oITSupportLog.dJobDate = (DateTime)reader["JobDate"];
                    oITSupportLog.sCompany = (string)reader["Company"];
                    oITSupportLog.sJobFor = (string)reader["JobFor"];
                    oITSupportLog.sJobDescription = (string)reader["JobDescription"];
                    oITSupportLog.dAssignDate = (DateTime)reader["AssignDate"];
                    oITSupportLog.dEndDate = (DateTime)reader["EndDate"];
                    oITSupportLog.nPriority = (int)reader["Priority"];
                    oITSupportLog.nStatus = (int)reader["Status"];
                    oITSupportLog.sUser = (string)reader["User"];
                    InnerList.Add(oITSupportLog);
                }
                reader.Close();


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
       

    }
}

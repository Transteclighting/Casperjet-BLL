// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: July 13, 2011
// Time :  1:00 PM
// Description: Class for Supplier information.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace CJ.Class
{
    public class ReportLog
    {
        private string _ReportCode;
        private string _ReportName;
        private string _UserName;
        private DateTime _LogDate;


        /// <summary>
        /// Get set property for ReportCode
        /// </summary>
        public string ReportCode
        {
            get { return _ReportCode; }
            set { _ReportCode = value.Trim(); }
        }

        /// <summary>
        /// Get set property for ReportName
        /// </summary>
        public string ReportName
        {
            get { return _ReportName; }
            set { _ReportName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for UserName
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for LogDate
        /// </summary>
        public DateTime LogDate
        {
            get { return _LogDate; }
            set { _LogDate = value; }
        }

        public void Add()
        {           
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "INSERT INTO t_ReportLog (ReportCode, ReportName, UserName, LogDate) Values (?,?,?,?)";
            try
            {               
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ReportCode", _ReportCode);
                cmd.Parameters.AddWithValue("ReportName", "CJ: " + _ReportName);
                cmd.Parameters.AddWithValue("UserName", Utility.Username);
                cmd.Parameters.AddWithValue("LogDate", DateTime.Now);
               
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void AddForAndroid(string connStr, string sReportCode, string sReportName, string sUserName)
        {

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;            // <== lacking
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO t_ReportLog VALUES ('" + sReportCode + "', '" + sReportName + "', '" + sUserName + "', '" + DateTime.Now + "') ";
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        public void InsertTMLDB()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "INSERT INTO TMLSysDB.dbo.t_ReportLog (ReportCode, ReportName, UserName, LogDate) Values (?,?,?,?)";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ReportCode", _ReportCode);
                cmd.Parameters.AddWithValue("ReportName", _ReportName);
                cmd.Parameters.AddWithValue("UserName", _UserName);
                cmd.Parameters.AddWithValue("LogDate", DateTime.Now);

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

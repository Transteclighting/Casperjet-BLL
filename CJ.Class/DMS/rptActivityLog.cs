// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Mazharul Haque
// Date: January, 2012
// Time : 01:00 PM
// Description: Form for Activity Log 
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.DMS
{
    public class rptActivityLog

    {
        private string _sRegion;
        private string _sArea;
        private string _sTerritory;
        private string _sCustomerCode;
        private string _sCustomerName;
        private DateTime _dLogInTime;
        private object _LogOutTime;

        public String Region
        {
            get { return _sRegion; }
            set { _sRegion = value; }

        }
        public String Area
        {
            get { return _sArea; }
            set { _sArea = value; }

        }
        public String Territory
        {
            get { return _sTerritory; }
            set { _sTerritory = value; }

        }
        public String CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }

        }
        public String CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }

        }
        public DateTime  LogInTime
        {
            get { return _dLogInTime; }
            set { _dLogInTime = value; }

        }
        public object  LogOutTime
        {
            get { return _LogOutTime; }
            set { _LogOutTime = value; }

        }
    }

    public class rptActivityLogs : CollectionBase
    {
        public void GetActivityLog(DateTime dDFromDate, DateTime dDToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            sSql = " select regionname,areaname,territoryname,c.customercode,C.CustomerName,LogInTime,LogOutTime " +
                    " from t_DMSUserLog DU " +
                    " inner join v_customerdetails C " +
                    " on DU.DistributorID=C.CustomerID " +
                    " where LogInTime between ? and ? and LogInTime<= ?" +
                    " order by regionname,areaname,territoryname,c.customercode,C.CustomerName,logintime ";

            cmd.Parameters.AddWithValue("LogInTime", dDFromDate);
            cmd.Parameters.AddWithValue("LogInTime", dDToDate.AddDays(1));
            cmd.Parameters.AddWithValue("LogInTime", dDToDate.AddDays(1));


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {



                    rptActivityLog orptActivityLog = new rptActivityLog();


                    orptActivityLog.Region = (string)reader["regionname"];
                    orptActivityLog.Area = (string)reader["areaname"];
                    orptActivityLog.Territory = (string)reader["territoryname"];
                    orptActivityLog.CustomerCode = (string)reader["CustomerCode"];
                    orptActivityLog.CustomerName = (string)reader["CustomerName"];
                    orptActivityLog.LogInTime = (DateTime)reader["LogInTime"];
                    if (reader["LogOutTime"] != DBNull.Value)
                        orptActivityLog.LogOutTime = Convert.ToDateTime( reader["LogOutTime"]).ToShortTimeString();
                    else orptActivityLog.LogOutTime = null;

                    InnerList.Add(orptActivityLog);
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

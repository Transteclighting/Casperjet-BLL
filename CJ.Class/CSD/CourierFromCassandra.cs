
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: June 03, 2012
// Time :  11:46 AM
// Description: Class for CourierName from Cassandra.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Class
{
    public class CourierFromCassandra
    {
        private int _nCourierServiceID;
        private string _sCourierServiceName;


        /// <summary>
        /// Get set property for CourierServiceID
        /// </summary>
        public int CourierServiceID
        {
            get { return _nCourierServiceID; }
            set { _nCourierServiceID = value; }
        }

        /// <summary>
        /// Get set property for CourierServiceName
        /// </summary>
        public string CourierServiceName
        {
            get { return _sCourierServiceName; }
            set { _sCourierServiceName = value; }
        }

        public void RefreshByCourierID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT CourierServiceID, Name CourierServiceName FROM TELServiceDB.dbo.CourierService";
                //cmd.Parameters.AddWithValue("GeoLocationID", _nGeoLocationID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    
                    _nCourierServiceID = (int)reader["CourierServiceID"];
                    _sCourierServiceName = (string)reader["CourierServiceName"];

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
    public class CourierFromCassandras : CollectionBase
    {

        public CourierFromCassandra this[int i]
        {
            get { return (CourierFromCassandra)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(CourierFromCassandra oCourierFromCassandra)
        {
            InnerList.Add(oCourierFromCassandra);
        }
        public int GetIndex(int nCourierServiceID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].CourierServiceID == nCourierServiceID)
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

            string sSql = "SELECT CourierServiceID, Name CourierServiceName FROM TELServiceDB.dbo.CourierService";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CourierFromCassandra oCourierFromCassandra = new CourierFromCassandra();

                    oCourierFromCassandra.CourierServiceID = (int)reader["CourierServiceID"];
                    oCourierFromCassandra.CourierServiceName = (string)reader["CourierServiceName"];

                    InnerList.Add(oCourierFromCassandra);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetCourierName(int nType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " SELECT CourierServiceID, Name CourierServiceName FROM TELServiceDB.dbo.CourierService";
            cmd.Parameters.AddWithValue("CourierServiceName", nType);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CourierFromCassandra oCourierFromCassandra = new CourierFromCassandra();

                    oCourierFromCassandra.CourierServiceID = (int)reader["CourierServiceID"];
                    oCourierFromCassandra.CourierServiceName = (string)reader["CourierServiceName"];


                    InnerList.Add(oCourierFromCassandra);
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


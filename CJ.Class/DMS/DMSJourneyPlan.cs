// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Sep 13, 2011
// Time :  12:00 PM
// Description: Class for DMS Journey Plan.
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
    public class DMSJourneyPlan
    {
        private int _nDistributorID;
        private int _nDSRID;
        private int _nRouteID;
        private int _nDayNo;
        private DSR _oDSR;
        private Route _oRoute;

        public DSR DSR
        {
            get
            {
                if (_oDSR == null)
                {
                    _oDSR = new DSR();
                    _oDSR.DSRID = _nDSRID;
                    _oDSR.DistributorID = _nDistributorID;
                    _oDSR.Refresh();
                }
                return _oDSR;
            }
        }
        public Route Route
        {
            get
            {
                if (_oRoute == null)
                {
                    _oRoute = new Route();
                    _oRoute.RouteID = _nRouteID;
                    _oRoute.DistributorID = _nDistributorID;
                    _oRoute.Refresh();
                }
                return _oRoute;
            }
        }
        /// <summary>
        /// Get set property for DistributorID
        /// </summary>
        public int DistributorID
        {
            get { return _nDistributorID; }
            set { _nDistributorID = value; }
        }

        /// <summary>
        /// Get set property for DSRID
        /// </summary>
        public int DSRID
        {
            get { return _nDSRID; }
            set { _nDSRID = value; }
        }

        /// <summary>
        /// Get set property for RouteID
        /// </summary>
        public int RouteID
        {
            get { return _nRouteID; }
            set { _nRouteID = value; }
        }

        /// <summary>
        /// Get set property for DayNo
        /// </summary>
        public int DayNo
        {
            get { return _nDayNo; }
            set { _nDayNo = value; }
        }

        public void Add()
        {           
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_DMSJourneyPlan VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("DSRID", _nDSRID);
                cmd.Parameters.AddWithValue("RouteID", _nRouteID);
                cmd.Parameters.AddWithValue("DayNo", _nDayNo);               

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Edit(int nOutletID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "UPDATE t_DMSOutlet SET RouteID=? WHERE OutletID=? and DistributorID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RouteID", _nRouteID);                           

                cmd.Parameters.AddWithValue("OutletID", nOutletID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditOutlet()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "UPDATE t_DMSOutlet SET RouteID=? WHERE RouteID=? and DistributorID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("RouteID", null);

                cmd.Parameters.AddWithValue("RouteID", _nRouteID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);

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
                sSql = "DELETE FROM t_DMSJourneyPlan WHERE DSRID =? and DistributorID=? and RouteID=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DSRID", _nDSRID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("RouteID", _nRouteID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public string GetDate(int nRouteID)
        {            
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sDay = "";
            string sSql = "SELECT * FROM t_DMSJourneyPlan where DistributorID=? and DSRID=? and RouteID=? ";
            cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
            cmd.Parameters.AddWithValue("DSRID", _nDSRID);
            cmd.Parameters.AddWithValue("RouteID", nRouteID); 

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if ((int)reader["DayNo"] == 1)
                    {
                        if (sDay == "")
                            sDay = "Saturday";
                        else sDay = sDay +","+ "Saturday";                       
                    }
                    if ((int)reader["DayNo"] == 2)
                    {
                        if (sDay == "")
                            sDay = "Sunday";
                        else sDay = sDay + "," + "Sunday";
                    }                    
                    if ((int)reader["DayNo"] == 3)
                    {
                        if (sDay == "")
                            sDay = "Monday";
                        else sDay = sDay + "," + "Monday";
                    }                     
                    if ((int)reader["DayNo"] == 4)
                    {
                        if (sDay == "")
                            sDay = "Tuesday";
                        else sDay = sDay + "," + "Tuesday";
                    }                   
                    if ((int)reader["DayNo"] == 5)
                    {
                        if (sDay == "")
                            sDay = "Wednesday";
                        else sDay = sDay + "," + "Wednesday";
                    }                   
                    if ((int)reader["DayNo"] == 6)
                    {
                        if (sDay == "")
                            sDay = "Thursday";
                        else sDay = sDay + "," + "Thursday";
                    }                    
                    if ((int)reader["DayNo"] == 7)
                    {
                        if (sDay == "")
                            sDay = "Friday";
                        else sDay = sDay + "," + "Friday";
                    }    
               
                   
                }
                reader.Close();

                return sDay;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public string GetRouteName()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sRouteName = "";
            string sSql = "SELECT * FROM t_DMSJourneyPlan where DistributorID=? and DSRID=? ";
            cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
            cmd.Parameters.AddWithValue("DSRID", _nDSRID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oRoute = new Route();
                    _oRoute.RouteID = (int)reader["RouteID"];
                    _oRoute.DistributorID = _nDistributorID;
                    _oRoute.Refresh();

                    if (sRouteName == "")
                        sRouteName = _oRoute.RouteName;
                    else sRouteName = sRouteName + "," + _oRoute.RouteName;         
                }
                reader.Close();

                return sRouteName;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class DMSJourneyPlanList : CollectionBase
    {

        public DMSJourneyPlan this[int i]
        {
            get { return (DMSJourneyPlan)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DMSJourneyPlan oDMSJourneyPlan)
        {
            InnerList.Add(oDMSJourneyPlan);
        }

        public void Refresh(int nUserID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSJourneyPlan where DistributorID=?";
            cmd.Parameters.AddWithValue("DistributorID", nUserID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSJourneyPlan oDMSJourneyPlan = new DMSJourneyPlan();

                    oDMSJourneyPlan.DistributorID = (int)reader["DistributorID"];
                    oDMSJourneyPlan.DSRID = (int)reader["DSRID"];
                    oDMSJourneyPlan.RouteID = (int)reader["RouteID"];
                    oDMSJourneyPlan.DayNo = (int)reader["DayNo"];

                    InnerList.Add(oDMSJourneyPlan);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refreshby(int nUserID,int nDSRID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSJourneyPlan where DistributorID=? and DSRID=?";
            cmd.Parameters.AddWithValue("DistributorID", nUserID);
            cmd.Parameters.AddWithValue("DSRID", nDSRID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSJourneyPlan oDMSJourneyPlan = new DMSJourneyPlan();                 
                    oDMSJourneyPlan.RouteID = (int)reader["RouteID"];
                    oDMSJourneyPlan.DayNo = (int)reader["DayNo"];

                    InnerList.Add(oDMSJourneyPlan);
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

// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: July 17, 2011
// Time :  02:00 PM
// Description: Class for route  information for DMS. 
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
    public class Route
    {
        private int _nRouteID;       
        private int _nDistributorID;
        private int _nCustomerID;
        private string _sCustomerCode;
        private int _nRouteCode;
        private string _sRouteName;
        private int _nDSRID;

        private DSR _oDSR;


        /// <summary>
        /// Get set property for RouteID
        /// </summary>
        public int RouteID
        {
            get { return _nRouteID; }
            set { _nRouteID = value; }
        }
        public int DistributorID
        {
            get { return _nDistributorID; }
            set { _nDistributorID = value; }
        }

        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }

        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }

        public int DSRID
        {
            get { return _nDSRID; }
            set { _nDSRID = value; }
        }
        /// <summary>
        /// Get set property for RouteCode
        /// </summary>
        public int RouteCode
        {
            get { return _nRouteCode; }
            set { _nRouteCode = value; }
        }

        /// <summary>
        /// Get set property for RouteName
        /// </summary>
        public string RouteName
        {
            get { return _sRouteName; }
            set { _sRouteName = value.Trim(); }
        }
        public DSR DSR
        {
            get
            {
                if (_oDSR == null)
                {
                    _oDSR = new DSR();
                    _oDSR.DSRID = _nDSRID;
                    _oDSR.DSRID = _nDistributorID;
                    _oDSR.Refresh();
                }

                return _oDSR;
            }
        }


        public void Add()
        {
            int nMaxRouteID = 0;
            int nMaxRouteCode = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([RouteID]) FROM t_DMSRoute";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxRouteID = 1;
                }
                else
                {
                    nMaxRouteID = Convert.ToInt32(maxID) + 1;
                }
                _nRouteID = nMaxRouteID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([RouteCode]) FROM t_DMSRoute";
                cmd.CommandText = sSql;
                object maxCode = cmd.ExecuteScalar();
                if (maxCode == DBNull.Value)
                {
                    nMaxRouteCode= 1;
                }
                else
                {
                    nMaxRouteCode=(Convert.ToInt32(maxCode) + 1);
                }
                _nRouteCode = nMaxRouteCode;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();


                sSql = "INSERT INTO t_DMSRoute VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("RouteID", _nRouteID);
                cmd.Parameters.AddWithValue("RouteCode", _nRouteCode);
                cmd.Parameters.AddWithValue("RouteName", _sRouteName);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("DSRID", _nDSRID);
               
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

                sSql = "UPDATE t_DMSRoute SET RouteCode=?, RouteName=? WHERE RouteID=? and DistributorID=? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("RouteCode", _nRouteCode);
                cmd.Parameters.AddWithValue("RouteName", _sRouteName);
                
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
                sSql = "DELETE FROM t_DMSRoute WHERE RouteID=? and DistributorID=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
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
       
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSRoute where RouteID=? and  DistributorID=?";

            cmd.Parameters.AddWithValue("RouteID", _nRouteID);
            cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nRouteID = (int)reader["RouteID"];
                    _nRouteCode = (int)reader["RouteCode"];
                    _sRouteName = (string)reader["RouteName"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        
    }
    public class Routes : CollectionBase
    {

        public Route this[int i]
        {
            get { return (Route)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public int GetIndexByID(int nRouteID)
        {
            int i = 0;
            foreach (Route oRoute in this)
            {
                if (oRoute.RouteID == nRouteID)
                    return i;
                i++;
            }
            return -1;
        }


        public void Add(Route oRoute)
        {
            InnerList.Add(oRoute);
        }

        public void Refresh(int nDistributorID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSRoute where DistributorID=? ORDER BY RouteCode ";
            cmd.Parameters.AddWithValue("DistributorID", nDistributorID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Route oRoute = new Route();

                    oRoute.RouteID = (int)reader["RouteID"];
                    oRoute.RouteCode = (int)reader["RouteCode"];
                    oRoute.RouteName = (string)reader["RouteName"];                 

                    InnerList.Add(oRoute);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetRoute(int nDistributorID)
        {
            InnerList.Clear();
            Route oRoute;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSRoute where DistributorID=?";
            cmd.Parameters.AddWithValue("DistributorID", nDistributorID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oRoute = new Route();
                    oRoute.RouteID = (int)reader["RouteID"];                 
                    oRoute.RouteName = (string)reader["RouteName"];
                    InnerList.Add(oRoute);
                }
                reader.Close();

                oRoute = new Route();
                oRoute.RouteID = -1;
                oRoute.RouteName = "Select Route";
                InnerList.Add(oRoute);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetRouteForPlan(int nDistributorID)
        {
            InnerList.Clear();
            Route oRoute;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_dmsroute where routeid not in (select routeid from t_DMSOutlet where routeid is not null and DistributorID='" + nDistributorID + "' group by routeid  ) and DistributorID='"+nDistributorID+"'";          
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oRoute = new Route();
                    oRoute.RouteID = (int)reader["RouteID"];
                    oRoute.RouteName = (string)reader["RouteName"];
                    InnerList.Add(oRoute);
                }
                reader.Close();

                oRoute = new Route();
                oRoute.RouteID = -1;
                oRoute.RouteName = "Select Route";
                InnerList.Add(oRoute);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetRoutebyCustomer(int nCustomerID)
        {
            InnerList.Clear();
            Route oRoute;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select b.CustomerID, a.CustomerCode,RouteCode, RouteName from TELAddDB.dbo.t_Route a, t_Customer b where a.CustomerCode=b.CustomerCode and CustomerID= ? ";
            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oRoute = new Route();

                    oRoute.CustomerID = (int)reader["CustomerID"];
                    oRoute.CustomerCode = (string)reader["CustomerCode"];
                    oRoute.RouteCode = (int)reader["RouteCode"];                  
                    oRoute.RouteName = (string)reader["RouteName"];

                    InnerList.Add(oRoute);

                }
                reader.Close();


                oRoute = new Route();
                oRoute.RouteID = -1;
                oRoute.RouteName = "All";
                InnerList.Add(oRoute);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

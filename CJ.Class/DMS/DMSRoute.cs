// <summary>
// Compamy: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Aug 05, 2015
// Time : 03:36 PM
// Description: Class for DMSRoute.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

using CJ.Class;
using CJ.Class.DMS;

namespace CJ.Class.DMS
{
    public class DMSRoute
    {
        private int _nRouteID;
        private int _nRouteCode;
        private string _sRouteName;
        private int _nDistributorID;
        private int _nDSRID;
        private int _nRouteTypeID;
        private string _sRouteType;
        private int _nVisitFrequency;
        private string _sVisitDay;
        private int _nDayID;
        private string _sGeoType;
        private string _sDSRMobileNo;
        private string _sDesignation;
        private string _sDeliveryDay;
        private string _sOrderType;
        private int _nRACode;
        private string _sRAName;
        private string _sRAMobileNo;
        private int _nDriverCode;
        private string _sDriverName;
        private string _sDriverMobNo;
        private string _sVehicleNo;
        private int _nIsActive;
        private int _nCustomerID;
        private string _sDsrName;
        private string _sOutletName;
        private string _sCustomerCode;
        private string _sCustomerName;
        private Customer _oCustomer;
        public Customer Customer
        {
            get
            {
                if (_oCustomer == null)
                {
                    _oCustomer = new Customer();
                    _oCustomer.CustomerID = _nDistributorID;
                    _oCustomer.refresh();
                }

                return _oCustomer;
            }
        }
        private DMSDSR oDMSDSR;
        public DMSDSR DMSDSR
        {
            get
            {
                if (oDMSDSR == null)
                {
                    oDMSDSR = new DMSDSR();
                    oDMSDSR.DistributorID = _nDistributorID;
                    oDMSDSR.Refresh();
                }

                return oDMSDSR;
            }
        }

        // <summary>
        // Get set property for RouteID
        // </summary>
        public int RouteID
        {
            get { return _nRouteID; }
            set { _nRouteID = value; }
        }
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        // <summary>
        // Get set property for RouteCode
        // </summary>
        public int RouteCode
        {
            get { return _nRouteCode; }
            set { _nRouteCode = value; }
        }

        // <summary>
        // Get set property for RouteName
        // </summary>
        public string RouteName
        {
            get { return _sRouteName; }
            set { _sRouteName = value.Trim(); }
        }
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }

        // <summary>
        // Get set property for DistributorID
        // </summary>
        public int DistributorID
        {
            get { return _nDistributorID; }
            set { _nDistributorID = value; }
        }

        // <summary>
        // Get set property for DSRID
        // </summary>
        public int DSRID
        {
            get { return _nDSRID; }
            set { _nDSRID = value; }
        }

        // <summary>
        // Get set property for RouteTypeID
        // </summary>
        public int RouteTypeID
        {
            get { return _nRouteTypeID; }
            set { _nRouteTypeID = value; }
        }

        // <summary>
        // Get set property for RouteType
        // </summary>
        public string RouteType
        {
            get { return _sRouteType; }
            set { _sRouteType = value.Trim(); }
        }

        // <summary>
        // Get set property for VisitFrequency
        // </summary>
        public int VisitFrequency
        {
            get { return _nVisitFrequency; }
            set { _nVisitFrequency = value; }
        }

        // <summary>
        // Get set property for VisitDay
        // </summary>
        public string VisitDay
        {
            get { return _sVisitDay; }
            set { _sVisitDay = value.Trim(); }
        }

        // <summary>
        // Get set property for DayID
        // </summary>
        public int DayID
        {
            get { return _nDayID; }
            set { _nDayID = value; }
        }

        // <summary>
        // Get set property for GeoType
        // </summary>
        public string GeoType
        {
            get { return _sGeoType; }
            set { _sGeoType = value.Trim(); }
        }

        // <summary>
        // Get set property for DSRMobileNo
        // </summary>
        public string DSRMobileNo
        {
            get { return _sDSRMobileNo; }
            set { _sDSRMobileNo = value.Trim(); }
        }

        // <summary>
        // Get set property for Designation
        // </summary>
        public string Designation
        {
            get { return _sDesignation; }
            set { _sDesignation = value.Trim(); }
        }

        // <summary>
        // Get set property for DeliveryDay
        // </summary>
        public string DeliveryDay
        {
            get { return _sDeliveryDay; }
            set { _sDeliveryDay = value.Trim(); }
        }

        // <summary>
        // Get set property for OrderType
        // </summary>
        public string OrderType
        {
            get { return _sOrderType; }
            set { _sOrderType = value.Trim(); }
        }

        // <summary>
        // Get set property for RACode
        // </summary>
        public int RACode
        {
            get { return _nRACode; }
            set { _nRACode = value; }
        }

        // <summary>
        // Get set property for RAName
        // </summary>
        public string RAName
        {
            get { return _sRAName; }
            set { _sRAName = value.Trim(); }
        }

        // <summary>
        // Get set property for RAMobileNo
        // </summary>
        public string RAMobileNo
        {
            get { return _sRAMobileNo; }
            set { _sRAMobileNo = value.Trim(); }
        }

        // <summary>
        // Get set property for DriverCode
        // </summary>
        public int DriverCode
        {
            get { return _nDriverCode; }
            set { _nDriverCode = value; }
        }

        // <summary>
        // Get set property for DriverName
        // </summary>
        public string DriverName
        {
            get { return _sDriverName; }
            set { _sDriverName = value.Trim(); }
        }

        public string OutletName
        {
            get { return _sOutletName; }
            set { _sOutletName = value.Trim(); }
        }

        // <summary>
        // Get set property for DriverMobNo
        // </summary>
        public string DriverMobNo
        {
            get { return _sDriverMobNo; }
            set { _sDriverMobNo = value.Trim(); }
        }

        // <summary>
        // Get set property for VehicleNo
        // </summary>
        public string VehicleNo
        {
            get { return _sVehicleNo; }
            set { _sVehicleNo = value.Trim(); }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
        public string DsrName
        {
            get { return _sDsrName; }
            set { _sDsrName = value.Trim(); }
        }

        public void Add()
        {
            int nMaxRouteID = 0;
            int nMaxRouteCode = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([RouteID])as RouteID,MAX([RouteCode])as RouteCode FROM t_DMSRoute";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxRouteID = 1;
                    nMaxRouteCode = 1;

                }
                else
                {
                    nMaxRouteID = Convert.ToInt32(maxID) + 1;
                    nMaxRouteCode = Convert.ToInt32(maxID) + 1;
                }
                _nRouteID = nMaxRouteID;
                _nRouteCode = nMaxRouteCode;
                sSql = "INSERT INTO t_DMSRoute (RouteID, RouteCode, RouteName, DistributorID, DSRID, RouteTypeID, RouteType, VisitFrequency, VisitDay, DayID, GeoType, DSRMobileNo, Designation, DeliveryDay, OrderType, RACode, RAName, RAMobileNo, DriverCode, DriverName, DriverMobNo, VehicleNo, IsActive) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RouteID", _nRouteID);
                cmd.Parameters.AddWithValue("RouteCode", _nRouteCode);
                cmd.Parameters.AddWithValue("RouteName", _sRouteName);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("DSRID", _nDSRID);
                cmd.Parameters.AddWithValue("RouteTypeID", _nRouteTypeID);
                cmd.Parameters.AddWithValue("RouteType", _sRouteType);
                cmd.Parameters.AddWithValue("VisitFrequency", _nVisitFrequency);
                cmd.Parameters.AddWithValue("VisitDay", _sVisitDay);
                cmd.Parameters.AddWithValue("DayID", _nDayID);
                cmd.Parameters.AddWithValue("GeoType", _sGeoType);
                cmd.Parameters.AddWithValue("DSRMobileNo", _sDSRMobileNo);
                cmd.Parameters.AddWithValue("Designation", _sDesignation);
                cmd.Parameters.AddWithValue("DeliveryDay", _sDeliveryDay);
                cmd.Parameters.AddWithValue("OrderType", _sOrderType);
                cmd.Parameters.AddWithValue("RACode", _nRACode);
                cmd.Parameters.AddWithValue("RAName", _sRAName);
                cmd.Parameters.AddWithValue("RAMobileNo", _sRAMobileNo);
                cmd.Parameters.AddWithValue("DriverCode", _nDriverCode);
                cmd.Parameters.AddWithValue("DriverName", _sDriverName);
                cmd.Parameters.AddWithValue("DriverMobNo", _sDriverMobNo);
                cmd.Parameters.AddWithValue("VehicleNo", _sVehicleNo);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

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
                sSql = "UPDATE t_DMSRoute SET RouteCode = ?, RouteName = ?, DistributorID = ?, DSRID = ?, RouteTypeID = ?, RouteType = ?, VisitFrequency = ?, VisitDay = ?, DayID = ?, GeoType = ?, DSRMobileNo = ?, Designation = ?, DeliveryDay = ?, OrderType = ?, RACode = ?, RAName = ?, RAMobileNo = ?, DriverCode = ?, DriverName = ?, DriverMobNo = ?, VehicleNo = ?, IsActive = ? WHERE RouteID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RouteCode", _nRouteCode);
                cmd.Parameters.AddWithValue("RouteName", _sRouteName);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("DSRID", _nDSRID);
                cmd.Parameters.AddWithValue("RouteTypeID", _nRouteTypeID);
                cmd.Parameters.AddWithValue("RouteType", _sRouteType);
                cmd.Parameters.AddWithValue("VisitFrequency", _nVisitFrequency);
                cmd.Parameters.AddWithValue("VisitDay", _sVisitDay);
                cmd.Parameters.AddWithValue("DayID", _nDayID);
                cmd.Parameters.AddWithValue("GeoType", _sGeoType);
                cmd.Parameters.AddWithValue("DSRMobileNo", _sDSRMobileNo);
                cmd.Parameters.AddWithValue("Designation", _sDesignation);
                cmd.Parameters.AddWithValue("DeliveryDay", _sDeliveryDay);
                cmd.Parameters.AddWithValue("OrderType", _sOrderType);
                cmd.Parameters.AddWithValue("RACode", _nRACode);
                cmd.Parameters.AddWithValue("RAName", _sRAName);
                cmd.Parameters.AddWithValue("RAMobileNo", _sRAMobileNo);
                cmd.Parameters.AddWithValue("DriverCode", _nDriverCode);
                cmd.Parameters.AddWithValue("DriverName", _sDriverName);
                cmd.Parameters.AddWithValue("DriverMobNo", _sDriverMobNo);
                cmd.Parameters.AddWithValue("VehicleNo", _sVehicleNo);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);


                cmd.Parameters.AddWithValue("RouteID", _nRouteID);
                

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditDMSRouteByRouteIDAndDSRID(int nRouteID,int nDSRID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_DMSRoute SET DSRID = " + nDSRID + " WHERE RouteID = " + nRouteID + " ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;                
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
                sSql = "DELETE FROM t_DMSRoute WHERE [RouteID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("RouteID", _nRouteID);
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
                cmd.CommandText = "SELECT * FROM t_DMSRoute where RouteID =?";
                cmd.Parameters.AddWithValue("RouteID", _nRouteID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nRouteID = (int)reader["RouteID"];
                    _nRouteCode = (int)reader["RouteCode"];
                    _sRouteName = (string)reader["RouteName"];
                    _nDistributorID = (int)reader["DistributorID"];
                    _nDSRID = (int)reader["DSRID"];
                    _nRouteTypeID = (int)reader["RouteTypeID"];
                    _sRouteType = (string)reader["RouteType"];
                    _nVisitFrequency = (int)reader["VisitFrequency"];
                    _sVisitDay = (string)reader["VisitDay"];
                    _nDayID = (int)reader["DayID"];
                    _sGeoType = (string)reader["GeoType"];
                    _sDSRMobileNo = (string)reader["DSRMobileNo"];
                    _sDesignation = (string)reader["Designation"];
                    _sDeliveryDay = (string)reader["DeliveryDay"];
                    _sOrderType = (string)reader["OrderType"];
                    _nRACode = (int)reader["RACode"];
                    _sRAName = (string)reader["RAName"];
                    _sRAMobileNo = (string)reader["RAMobileNo"];
                    _nDriverCode = (int)reader["DriverCode"];
                    _sDriverName = (string)reader["DriverName"];
                    _sDriverMobNo = (string)reader["DriverMobNo"];
                    _sVehicleNo = (string)reader["VehicleNo"];
                    _nIsActive = (int)reader["IsActive"];
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
    public class DMSRoutes : CollectionBase
    {
        public DMSRoute this[int i]
        {
            get { return (DMSRoute)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DMSRoute oDMSRoute)
        {
            InnerList.Add(oDMSRoute);
        }
        public int GetIndex(int nRouteID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].RouteID == nRouteID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(string sCustomerName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            //string sSql = "SELECT * FROM t_DMSRoute Where Isactive = 1";
            //string sSql = "Select CustomerCode,RouteName,RouteType,VisitFrequency,Visitday,GeoType, " +
            //            "DSRMobileNo,Designation,DeliveryDay,OrderType,RACode,RAName,RAMobileNo," +
            //            "DriverCode,DriverName,DriverMobno,VehicleNo,DSRName,OutletName,a.IsActive " +
            //            "from t_dmsroute a, t_customer b, t_dmsdsr c, t_dmsoutlet d " +
            //            "where a.distributorid=b.customerid  and a.dsrid=c.dsrid " +
            //            "and a.routeid=d.routeid and a.isactive=1 ";
            string sSql = "Select RouteID,RouteCode,CustomerCode,CustomerName,DsrName,RouteName,RouteType,VisitFrequency,Visitday,GeoType, " +
                        "DSRMobileNo,Designation,DeliveryDay,OrderType,RACode,RAName,RAMobileNo," +
                        "DriverCode,DriverName,DriverMobno,VehicleNo,DSRName,a.IsActive " +
                        "from t_dmsroute a, t_customer b, t_dmsdsr c " +
                        "where a.distributorid=b.customerid  and a.dsrid=c.dsrid " +
                        " and a.isactive=1 ";
            string sClause = "";
            if (sCustomerName != "")
            {
                sClause = sClause + " AND CustomerName LIKE ?";
                cmd.Parameters.AddWithValue("CustomerName", "%" + sCustomerName + "%");
            }
            try
            {
                cmd.CommandText = sSql + sClause;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSRoute oDMSRoute = new DMSRoute();
                    oDMSRoute.RouteID = (int)reader["RouteID"];
                    oDMSRoute.RouteCode = (int)reader["RouteCode"];
                        if (reader["RouteName"] != DBNull.Value)
                            oDMSRoute.RouteName = (string)reader["RouteName"];
                            oDMSRoute.DsrName = (string)reader["DsrName"];
                            oDMSRoute.CustomerName = (string)reader["CustomerName"];
                    //oDMSRoute.DistributorID = (int)reader["DistributorID"];
                    //oDMSRoute.DSRID = (int)reader["DSRID"];
                    //oDMSRoute.RouteTypeID = (int)reader["RouteTypeID"];
                        if (reader["RouteType"] != DBNull.Value)
                            oDMSRoute.RouteType = (string)reader["RouteType"];
                        if (reader["VisitFrequency"] != DBNull.Value)
                            oDMSRoute.VisitFrequency = (int)reader["VisitFrequency"];
                        if (reader["VisitDay"] != DBNull.Value)
                            oDMSRoute.VisitDay = (string)reader["VisitDay"];
                        if (reader["GeoType"] != DBNull.Value)
                            oDMSRoute.GeoType = (string)reader["GeoType"];
                        if (reader["DSRMobileNo"] != DBNull.Value)
                        oDMSRoute.DSRMobileNo = (string)reader["DSRMobileNo"];
                        if (reader["Designation"] != DBNull.Value)
                            oDMSRoute.Designation = (string)reader["Designation"];
                        if (reader["DeliveryDay"] != DBNull.Value)
                            oDMSRoute.DeliveryDay = (string)reader["DeliveryDay"];
                        if (reader["OrderType"] != DBNull.Value)
                        oDMSRoute.OrderType = (string)reader["OrderType"];

                        oDMSRoute.DsrName = (string)reader["DsrName"];
                        //oDMSRoute.OutletName = (string)reader["OutletName"];
                        oDMSRoute.CustomerCode = (string)reader["CustomerCode"];
                    
                    //oDMSRoute.DayID = (int)reader["DayID"];

                        if (reader["RACode"] != DBNull.Value)
                        oDMSRoute.RACode =Convert.ToInt32(reader["RACode"]);
                        if (reader["RAName"] != DBNull.Value)
                            oDMSRoute.RAName = (string)reader["RAName"];
                        if (reader["RAMobileNo"] != DBNull.Value)
                            oDMSRoute.RAMobileNo = (string)reader["RAMobileNo"];
                        if (reader["DriverCode"] != DBNull.Value)
                        oDMSRoute.DriverCode = Convert.ToInt32(reader["DriverCode"]);
                        if (reader["DriverName"] != DBNull.Value)
                            oDMSRoute.DriverName = (string)reader["DriverName"];
                        if (reader["DriverMobNo"] != DBNull.Value)
                            oDMSRoute.DriverMobNo = (string)reader["DriverMobNo"];
                        if (reader["VehicleNo"] != DBNull.Value)
                            oDMSRoute.VehicleNo = (string)reader["VehicleNo"];
                            oDMSRoute.IsActive = Convert.ToInt32(reader["IsActive"]);
                    InnerList.Add(oDMSRoute);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshRouteWise(int nRouteID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            //string sSql = "SELECT * FROM t_DMSRoute where RouteId = ?";
            //cmd.Parameters.AddWithValue("RouteId", nRouteId);
            string sSql = "select routetype,visitfrequency,visitday,geotype,  " +
                          "designation,deliveryday,ordertype from t_dmsroute  where Isactive=1 and RouteID = ? ";
            cmd.Parameters.AddWithValue("RouteId", nRouteID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSRoute oDMSRoute = new DMSRoute();

                 if (reader["RouteType"] != DBNull.Value)
                          oDMSRoute.RouteType = (string)reader["RouteType"];
                 if (reader["VisitFrequency"] != DBNull.Value)
                    oDMSRoute.VisitFrequency = (int)reader["VisitFrequency"];
                 if (reader["VisitDay"] != DBNull.Value)
                    oDMSRoute.VisitDay = (string)reader["VisitDay"];
                 if (reader["GeoType"] != DBNull.Value)
                    //oDMSRoute.DayID = (int)reader["DayID"];
                    oDMSRoute.GeoType = (string)reader["GeoType"];
                 if (reader["Designation"] != DBNull.Value)
                    oDMSRoute.Designation = (string)reader["Designation"];
                 if (reader["DeliveryDay"] != DBNull.Value)
                    oDMSRoute.DeliveryDay = (string)reader["DeliveryDay"];
                 if (reader["OrderType"] != DBNull.Value)
                    oDMSRoute.OrderType = (string)reader["OrderType"];
                    
                    
                    InnerList.Add(oDMSRoute);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshBYRouteName(int nCustomerId)
        {
            DMSRoute oDMSRoute;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_dmsroute where Isactive =1 and distributorid= ? ";
            cmd.Parameters.AddWithValue("DistributorID", nCustomerId);
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oDMSRoute = new DMSRoute();
                    //DMSRoute oDMSRoute = new DMSRoute();
                    oDMSRoute.RouteID = (int)reader["RouteID"];
                    //if (reader["RouteName"] != DBNull.Value)
                        oDMSRoute.RouteName = (string)reader["RouteName"];
                    InnerList.Add(oDMSRoute);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void RefreshByCustomerID(int nCustomerID)
        {   
            DMSRoute oDMSRoute;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from t_DMSRoute WHERE IsActive = 1 ";
            if (nCustomerID != -1)
            {
                sSql += "AND DistributorID = '" + nCustomerID + "' ";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oDMSRoute = new DMSRoute();
                    oDMSRoute.RouteID = (int)reader["RouteID"];
                    oDMSRoute.RouteName = (string)reader["RouteName"];
                    oDMSRoute.RouteCode = (int)reader["RouteCode"];
                    oDMSRoute.DSRMobileNo = (string)reader["DSRMobileNo"];
                    oDMSRoute.Designation = (string)reader["Designation"];
                    oDMSRoute.IsActive = Convert.ToInt32(reader["IsActive"]);
                    InnerList.Add(oDMSRoute);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
       

        public void RefreshByDSRID(int nDSRID)
        {
            DMSRoute oDMSRoute;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select RouteID,RouteName,RouteCode,DSRMobileNo,Designation,IsActive from t_DMSRoute WHERE 1=1 ";
            if (nDSRID != -1)
            {
                sSql += "AND DSRID = '" + nDSRID + "' ";
            }           

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oDMSRoute = new DMSRoute();
                    oDMSRoute.RouteID = (int)reader["RouteID"];
                    oDMSRoute.RouteName = (string)reader["RouteName"];
                    oDMSRoute.RouteCode = (int)reader["RouteCode"];
                    oDMSRoute.DSRMobileNo = (string)reader["DSRMobileNo"];
                    oDMSRoute.Designation = (string)reader["Designation"];
                    oDMSRoute.IsActive = Convert.ToInt32(reader["IsActive"]);
                    InnerList.Add(oDMSRoute);
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


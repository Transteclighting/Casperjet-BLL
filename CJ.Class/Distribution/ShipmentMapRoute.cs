using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Distribution
{
    public class ShipmentMapRoute
    {
        private string _sCompany;
        private string _sTType;
        private int _nDestinationId;
        private int _nRouteId;
        private string _sCustomerCode;
        private string _sCustomerName;
        private int _nShipmentRouteID;

        public int ShipmentRouteID
        {
            get { return _nShipmentRouteID; }
            set { _nShipmentRouteID = value; }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }
        public string Comapany
        {
            get { return _sCompany; }
            set { _sCompany = value; }
        }

        public string TType
        {
            get { return _sTType; }
            set { _sTType = value; }
        }
        public int DestinationId
        {
            get { return _nDestinationId; }
            set { _nDestinationId = value; }
        }
        public int RouteId
        {
            get { return _nRouteId; }
            set { _nRouteId = value; }
        }



        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_ShipmentRoute(Company,TType,DestinationID, RouteID) VALUES(?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Company", _sCompany);
                cmd.Parameters.AddWithValue("TType", _sTType);
                cmd.Parameters.AddWithValue("DestinationID", _nDestinationId);
                cmd.Parameters.AddWithValue("DestinationID", _nRouteId);
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
                sSql = "Delete FROM t_ShipmentRoute WHERE [ShipmentRouteID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("DestinationID", _nDestinationId);
                cmd.Parameters.AddWithValue("ShipmentRouteID", _nShipmentRouteID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }

    public class ShipmentMapRoutes : CollectionBase
    {
        public ShipmentMapRoute this[int i]
        {
            get { return (ShipmentMapRoute)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ShipmentMapRoute _oShipmentRoute)
        {
            InnerList.Add(_oShipmentRoute);
        }

        public void NonMapRoute(string txtCompany, string txtTType, string txtCode, string txtName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from (  " +
                        "Select 'Invoice'as TType,a.CustomerID as DestinationID,'Customer'as Destination,'TEL'as Company, CustomerCode as Code, " +
                        "CustomerName as Name,DistrictName as District,ThanaName as Thana from v_CustomerDetails a, " +
                        "(select distinct CustomerID from t_SalesInvoice Where InvoiceDate >= '01-Jan-2013')b Where a.customerid=b.customerid and a.CustomerID Not IN( " +
                        "select CustomerID from t_ShipmentRoute a, t_Customer b Where a.DestinationID=b.CustomerID and TType='Invoice' and Company='TEL') " +
                        "UNION ALL " +
                        "Select 'Invoice'as TType,a.CustomerID as DestinationID,'Customer'as Destination, 'BLL'as Company,CustomerCode as Code, " +
                        "CustomerName as Name,DistrictName as District,ThanaName as Thana from BLLSysDB.dbo.v_CustomerDetails a, " +
                        "(select distinct CustomerID from BLLSysDB.dbo.t_SalesInvoice Where InvoiceDate >= '01-Jan-2013')b " +
                        "Where a.customerid=b.customerid and a.CustomerID Not IN( " +
                        "select CustomerID from t_ShipmentRoute a, BLLSysDB.dbo.t_Customer b Where a.DestinationID=b.CustomerID and TType='Invoice' and Company='BLL') " +
                        "UNION ALL " +
                        "Select 'Invoice'as TType,a.CustomerID as DestinationID,'Customer'as Destination, 'TML'as Company,CustomerCode as Code, " +
                        "CustomerName as Name,DistrictName as District,ThanaName as Thana from TMLSysDB.dbo.v_CustomerDetails a, " +
                        "(select distinct CustomerID from TMLSysDB.dbo.t_SalesInvoice Where InvoiceDate >= '01-Jan-2013')b Where a.customerid=b.customerid and a.CustomerID Not IN( " +
                        "select CustomerID from t_ShipmentRoute a, TMLSysDB.dbo.t_Customer b Where a.DestinationID=b.CustomerID and TType='Invoice' and Company='TML') " +
                        "UNION ALL " +
                        "Select 'Chalan'as TType,WarehouseID as DestinationID,'Warehouse'as Destination,'TEL'as Company, WarehouseCode as Code, " +
                        "WarehouseName as Name,'N/A' as District,'N/A' as Thana from t_Warehouse Where WarehouseID Not IN( " +
                        "select DestinationID from t_ShipmentRoute a, t_Warehouse b Where a.DestinationID=b.WarehouseID and TType='Chalan' and Company='TEL') " +
                        "UNION ALL " +
                        "Select 'Chalan'as TType,WarehouseID as DestinationID,'Warehouse'as Destination,'BLL'as Company, WarehouseCode as Code, " +
                        "WarehouseName as Name,'N/A' as District,'N/A' as Thana from BLLSysDB.dbo.t_Warehouse Where WarehouseID Not IN( " +
                        "select DestinationID from t_ShipmentRoute a, BLLSysDB.dbo.t_Warehouse b Where a.DestinationID=b.WarehouseID and TType='Chalan' and Company='BLL') " +
                        "UNION ALL " +
                        "Select 'Chalan'as TType,WarehouseID as DestinationID,'Warehouse'as Destination,'TML'as Company, WarehouseCode as Code, " +
                        "WarehouseName as Name,'N/A' as District,'N/A' as Thana from TMLSysDB.dbo.t_Warehouse Where WarehouseID Not IN( " +
                        "select DestinationID from t_ShipmentRoute a, TMLSysDB.dbo.t_Warehouse b Where a.DestinationID=b.WarehouseID " +
                        "and TType='Chalan' and Company='TML')) as final Where 1=1 ";

            if (txtCompany != "")
            {
                sSql = sSql + " AND Company = '" + txtCompany + "'";
            }

            if (txtTType != "")
            {
                sSql = sSql + " AND TType = '" + txtTType + "'";
            }

            if (txtCode != "")
            {
                sSql = sSql + " AND Code = '" + txtCode + "'";
            }

            if (txtName != "")
            {
                txtName = "%" + txtName + "%";
                sSql = sSql + " AND Name LIKE '" + txtName + "'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ShipmentMapRoute _oShipmentRoute = new ShipmentMapRoute();
                    _oShipmentRoute.Comapany = (string)reader["Company"];
                    _oShipmentRoute.TType = (string)reader["TType"];
                    _oShipmentRoute.DestinationId = (int)reader["DestinationID"];
                    _oShipmentRoute.CustomerCode = (string)reader["Code"];
                    _oShipmentRoute.CustomerName = (string)reader["Name"];

                    InnerList.Add(_oShipmentRoute);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RefreshMapRoute(string txtCompany, string txtTType, string txtCode, string txtName, string txtRouteId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select * from ( "+
                          " select ShipmentRouteID,'Customer'as Destination, TType, 'TEL'as Company, CustomerCode as Code,CustomerName as Name,RouteID from t_ShipmentRoute a, " +
                          " t_Customer b Where a.DestinationID=b.CustomerID and TType='Invoice' and Company='TEL'" +
                          " UNION ALL" +
                          " select ShipmentRouteID,'Customer'as Destination, TType, 'BLL'as Company, CustomerCode as Code,CustomerName as Name,RouteID from t_ShipmentRoute a, " +
                          " BLLSysDB.dbo.t_Customer b Where a.DestinationID=b.CustomerID and TType='Invoice' and Company='BLL'" +
                          " UNION ALL" +
                          " select ShipmentRouteID,'Customer'as Destination, TType, 'TML'as Company, CustomerCode as Code,CustomerName as Name,RouteID from t_ShipmentRoute a, " +
                          " TMLSysDB.dbo.t_Customer b Where a.DestinationID=b.CustomerID and TType='Invoice' and Company='TML'" +
                          " UNION ALL" +
                          " select ShipmentRouteID,'Warehouse'as Destination, TType, 'TEL'as Company, WarehouseCode as Code,WarehouseName as Name,RouteID from t_ShipmentRoute a, " +
                          " t_Warehouse b Where a.DestinationID=b.WarehouseID and TType='Chalan' and Company='TEL'" +
                          " UNION ALL" +
                          " select ShipmentRouteID,'Warehouse'as Destination, TType, 'BLL'as Company, WarehouseCode as Code,WarehouseName as Name,RouteID from t_ShipmentRoute a, " +
                          " BLLSysDB.dbo.t_Warehouse b Where a.DestinationID=b.WarehouseID and TType='Chalan' and Company='BLL'" +
                          " UNION ALL" +
                          " select ShipmentRouteID,'Warehouse'as Destination, TType, 'TML'as Company, WarehouseCode as Code,WarehouseName as Name,RouteID from t_ShipmentRoute a, " +
                          " TMLSysDB.dbo.t_Warehouse b Where a.DestinationID=b.WarehouseID" +
                          " and TType='Chalan' and Company='TML') as FinalMap where 1=1 ";

            if (txtCompany != "")
            {
                sSql = sSql + " AND Company = '" + txtCompany + "'";
            }

            if (txtTType != "")
            {
                sSql = sSql + " AND TType = '" + txtTType + "'";
            }

            if (txtCode != "")
            {
                sSql = sSql + " AND Code = '" + txtCode + "'";
            }

            if (txtName != "")
            {
                txtName = "%" + txtName + "%";
                sSql = sSql + " AND Name LIKE '" + txtName + "'";
                //sSql = sSql + " AND Name = '" + txtName + "'";
            }

            if (txtRouteId != "")
            {
                int nRouteID = 0;
                nRouteID = Convert.ToInt32(txtRouteId);
                sSql = sSql + " AND RouteID = " + nRouteID + "";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ShipmentMapRoute _oShipmentRoute = new ShipmentMapRoute();
                    _oShipmentRoute.ShipmentRouteID = (int)reader["ShipmentRouteID"];
                    _oShipmentRoute.Comapany = (string)reader["Company"];
                    _oShipmentRoute.TType = (string)reader["TType"];
                    _oShipmentRoute.RouteId = (int)reader["RouteId"];
                    _oShipmentRoute.CustomerCode = (string)reader["Code"];
                    _oShipmentRoute.CustomerName = (string)reader["Name"];

                    InnerList.Add(_oShipmentRoute);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


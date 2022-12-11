// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: Oct 28, 2013
// Time : 12.00 PM
// Description: Class for Vehicle Shipment.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class
{
    /// <summary>
    /// Shipment Type
    /// </summary>
    public enum ShipmentType
    {
        None=0,
        LogVehicle = 1,
        Parcel = 2,
        RentVehicle = 3,
        Self=4
    }

    public class LogDeliveryShipmentItem
    {
        private int _nShipmentID;
        private string _sCompany;
        private string _sTranType;
        private int _nTranID;
        private double _FreightCost;
        private double _LocalDeliveryCost;
        private int _nVendorID;
        private object _dtReceiveDate;
        private object _dtReceiveTime;
        private double _ParcelCost;
        private string _sRemarks;
        private string _sVendorName;
        private string _sCustomerName;
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        private string _sShipmentNo;
        public string ShipmentNo
        {
            get { return _sShipmentNo; }
            set { _sShipmentNo = value.Trim(); }
        }
        public string VendorName
        {
            get { return _sVendorName; }
            set { _sVendorName = value.Trim(); }
        }
        private string _sParcelVendorName;
        public string ParcelVendorName
        {
            get { return _sParcelVendorName; }
            set { _sParcelVendorName = value.Trim(); }
        }
        private int _nDeliveryMode;
        public int DeliveryMode
        {
            get { return _nDeliveryMode; }
            set { _nDeliveryMode = value; }
        }
        private int _nParcelType;
        public int ParcelType
        {
            get { return _nParcelType; }
            set { _nParcelType = value; }
        }

        private string _sVehicleCapacity;
        public string VehicleCapacity
        {
            get { return _sVehicleCapacity; }
            set { _sVehicleCapacity = value; }
        }

        private int _nParcelVendorID;
        public int ParcelVendorID
        {
            get { return _nParcelVendorID; }
            set { _nParcelVendorID = value; }
        }

        public double ParcelCost
        {
            get { return _ParcelCost; }
            set { _ParcelCost = value; }
        }

        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        public object ReceiveDate
        {
            get { return _dtReceiveDate; }
            set { _dtReceiveDate = value; }
        }
        public object ReceiveTime
        {
            get { return _dtReceiveTime; }
            set { _dtReceiveTime = value; }
        }


        public int VendorID
        {
            get { return _nVendorID; }
            set { _nVendorID = value; }
        }
        private int _nVehicleID;
        public int VehicleID
        {
            get { return _nVehicleID; }
            set { _nVehicleID = value; }
        }
        private string _sVehicleNo;
        public string VehicleNo
        {
            get { return _sVehicleNo; }
            set { _sVehicleNo = value.Trim(); }
        }

        private string _sTranNo;
        public string TranNo
        {
            get { return _sTranNo; }
            set { _sTranNo = value.Trim(); }
        }
        private DateTime _dTranDate;
        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
        }
        
        private double _StockPrice;
        public double StockPrice
        {
            get { return _StockPrice; }
            set { _StockPrice = value; }
        }


        // <summary>
        // Get set property for ShipmentID
        // </summary>
        public int ShipmentID
        {
            get { return _nShipmentID; }
            set { _nShipmentID = value; }
        }
        
        // <summary>
        // Get set property for Company
        // </summary>
        public string Company
        {
            get { return _sCompany; }
            set { _sCompany = value.Trim(); }
        }
        
        // <summary>
        // Get set property for TranType
        // </summary>
        public string TranType
        {
            get { return _sTranType; }
            set { _sTranType = value.Trim(); }
        }

        // <summary>
        // Get set property for TranID
        // </summary>
        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }

        // <summary>
        // Get set property for FreightCost
        // </summary>
        public double FreightCost
        {
            get { return _FreightCost; }
            set { _FreightCost = value; }
        }

        // <summary>
        // Get set property for LocalDeliveryCost
        // </summary>
        public double LocalDeliveryCost
        {
            get { return _LocalDeliveryCost; }
            set { _LocalDeliveryCost = value; }
        }

        public void Add(int nType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_LogDeliveryShipmentItem (ShipmentID, Company, TranType, TranID, TranNo, TranDate,StockPrice, VendorID, VehicleNo, VehicleID, FreightCost, LocalDeliveryCost, ParcelCost, ReceiveDate, ReceiveTime, Remarks, DeliveryMode,ParcelType,ParcelVendorID,VehicleCapacity) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);
                cmd.Parameters.AddWithValue("Company", _sCompany);
                cmd.Parameters.AddWithValue("TranType", _sTranType);
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", _dTranDate);
                cmd.Parameters.AddWithValue("StockPrice", _StockPrice);
                cmd.Parameters.AddWithValue("VendorID", _nVendorID);
                cmd.Parameters.AddWithValue("VehicleNo", _sVehicleNo);
                cmd.Parameters.AddWithValue("VehicleID", _nVehicleID);
                cmd.Parameters.AddWithValue("FreightCost", _FreightCost);
                cmd.Parameters.AddWithValue("LocalDeliveryCost", _LocalDeliveryCost);
                cmd.Parameters.AddWithValue("ParcelCost", _ParcelCost);
                if (nType == 1)
                {
                    cmd.Parameters.AddWithValue("ReceiveDate", null);
                    cmd.Parameters.AddWithValue("ReceiveTime", null);
                }
                else
                {
                    if (_dtReceiveDate != null)
                    {
                        cmd.Parameters.AddWithValue("ReceiveDate", _dtReceiveDate);
                        cmd.Parameters.AddWithValue("ReceiveTime", _dtReceiveTime);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("ReceiveDate", null);
                        cmd.Parameters.AddWithValue("ReceiveTime", null);
                    }
                }
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("DeliveryMode", _nDeliveryMode);
                cmd.Parameters.AddWithValue("ParcelType", _nParcelType);
                cmd.Parameters.AddWithValue("ParcelVendorID", _nParcelVendorID);
                cmd.Parameters.AddWithValue("VehicleCapacity", _sVehicleCapacity);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditReceiveDate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_LogDeliveryShipmentItem SET ReceiveDate = ?, ReceiveTime = ? WHERE ShipmentID = ? and TranID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ReceiveDate", _dtReceiveDate);
                cmd.Parameters.AddWithValue("ReceiveTime", _dtReceiveTime);
                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);
                cmd.Parameters.AddWithValue("TranID", _nTranID);

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
                sSql = "UPDATE t_LogDeliveryShipmentItem SET Company = ?, TranType = ?, TranID = ?, FreightCost = ?, LocalDeliveryCost = ? WHERE ShipmentID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Company", _sCompany);
                cmd.Parameters.AddWithValue("TranType", _sTranType);
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("FreightCost", _FreightCost);
                cmd.Parameters.AddWithValue("LocalDeliveryCost", _LocalDeliveryCost);

                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);

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
                sSql = "DELETE FROM t_LogDeliveryShipmentItem WHERE [ShipmentID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);
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
                cmd.CommandText = "SELECT * FROM t_LogDeliveryShipmentItem where ShipmentID =?";
                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nShipmentID = (int)reader["ShipmentID"];
                    _sCompany = (string)reader["Company"];
                    _sTranType = (string)reader["TranType"];
                    _nTranID = (int)reader["TranID"];
                    _FreightCost = Convert.ToDouble(reader["FreightCost"].ToString());
                    _LocalDeliveryCost = Convert.ToDouble(reader["LocalDeliveryCost"].ToString());
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

    public class ShipmentVehicle : CollectionBase
    {

        public LogDeliveryShipmentItem this[int i]
        {
            get { return (LogDeliveryShipmentItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(LogDeliveryShipmentItem oLogDeliveryShipmentItem)
        {
            InnerList.Add(oLogDeliveryShipmentItem);
        }
        private string _sCompany;
        private int _nTranID;
        private string _sTranNo;
        private DateTime _dTranDate;
        private DateTime _dDeliveryDate;
        private string _sTType;
        private string _sDestination;
        private string _sChannel;
        private string _sTranStatus;
        private object _nVehicleID;
        private string _sVehicleNo;
        private ShipmentType _nShipmentType;
        private double _nCostAmount;
        private double _nTranAmount;
        private DateTime _dEntryDate;
        private int _nRouteID;
        private int _nVendorID;
        private int _nShipmentID;
        private int _nFromWHID;
        private int _nToWHID;
        private int _nDutyTranID;
        private DateTime _dDutyTranDate;
        private string _sDutyTranNo;

        private string _sFromWHName;
        public string FromWHName
        {
            get { return _sFromWHName; }
            set { _sFromWHName = value.Trim(); }
        }
        private string _sToWHName;
        public string ToWHName
        {
            get { return _sToWHName; }
            set { _sToWHName = value.Trim(); }
        }

        private string _sVehicleName;
        public string VehicleName
        {
            get { return _sVehicleName; }
            set { _sVehicleName = value.Trim(); }
        }
        private DateTime _dCreateDate;
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        private int _nCreateUserID;

        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        private double _nFreightCost;
        public double FreightCost
        {
            get { return _nFreightCost; }
            set { _nFreightCost = value; }
        }
        private double _nLocalDeliveryCost;

        public double LocalDeliveryCost
        {
            get { return _nLocalDeliveryCost; }
            set { _nLocalDeliveryCost = value; }
        }
        private double _ParcelCost;
        public double ParcelCost
        {
            get { return _ParcelCost; }
            set { _ParcelCost = value; }
        }

        public int ShipmentID
        {
            get { return _nShipmentID; }
            set { _nShipmentID = value; }
        }
        private string _sShipmentNo;
        public string ShipmentNo
        {
            get { return _sShipmentNo; }
            set { _sShipmentNo = value.Trim(); }
        }
        private string _sVehicleCapacity;
        public string VehicleCapacity
        {
            get { return _sVehicleCapacity; }
            set { _sVehicleCapacity = value.Trim(); }
        }
        public string VehicleNo
        {
            get { return _sVehicleNo; }
            set { _sVehicleNo = value.Trim(); }
        }
        private string _sGatePassNo;
        public string GatePassNo
        {
            get { return _sGatePassNo; }
            set { _sGatePassNo = value.Trim(); }
        }
        public int VendorID
        {
            get { return _nVendorID; }
            set { _nVendorID = value; }
        }
        public int FromWHID
        {
            get { return _nFromWHID; }
            set { _nFromWHID = value; }
        }
        public int ToWHID
        {
            get { return _nToWHID; }
            set { _nToWHID = value; }
        }
        private int _nVendorType;
        public int VendorType
        {
            get { return _nVendorType; }
            set { _nVendorType = value; }
        }
        private string _sVendorName;
        public string VendorName
        {
            get { return _sVendorName; }
            set { _sVendorName = value; }
        }

        private string _sDeliveryPersonContactNo;
        public string DeliveryPersonContactNo
        {
            get { return _sDeliveryPersonContactNo; }
            set { _sDeliveryPersonContactNo = value.Trim(); }
        }
        private string _sDeliveryPerson;
        public string DeliveryPerson
        {
            get { return _sDeliveryPerson; }
            set { _sDeliveryPerson = value.Trim(); }
        }

        private int _nDeliveryMode;
        public int DeliveryMode
        {
            get { return _nDeliveryMode; }
            set { _nDeliveryMode = value; }
        }

        private int _nParcelType;
        public int ParcelType
        {
            get { return _nParcelType; }
            set { _nParcelType = value; }
        }
        public int DutyTranID
        {
            get { return _nDutyTranID; }
            set { _nDutyTranID = value; }
        }
        private DateTime _dtShipmentDate;
        public DateTime ShipmentDate
        {
            get { return _dtShipmentDate; }
            set { _dtShipmentDate = value; }
        }
        public DateTime DutyTranDate
        {
            get { return _dDutyTranDate; }
            set { _dDutyTranDate = value; }
        }
        private int _nCustomerID;
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        private string _sCustomerCode;
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }
        public string DutyTranNo
        {
            get { return _sDutyTranNo; }
            set { _sDutyTranNo = value.Trim(); }
        }
        private string _sCustomerName;
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        private string _sAreaName;
        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value.Trim(); }
        }
        private string _sTerritoryName;
        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value.Trim(); }
        }
        private string _sThanaName;
        public string ThanaName
        {
            get { return _sThanaName; }
            set { _sThanaName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for Company
        /// </summary>
        /// 



        public string Company
        {
            get { return _sCompany; }
            set { _sCompany = value.Trim(); }
        }

        /// <summary>
        /// Get set property for TranID
        /// </summary>
        public int TranID
        {
            get { return _nTranID; }
            set { _nTranID = value; }
        }

        /// <summary>
        /// Get set property for TranNo
        /// </summary>
        public string TranNo
        {
            get { return _sTranNo; }
            set { _sTranNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for TranDate
        /// </summary>
        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
        }

        /// <summary>
        /// Get set property for DeliveryDate
        /// </summary>
        public DateTime DeliveryDate
        {
            get { return _dDeliveryDate; }
            set { _dDeliveryDate = value; }
        }

        /// <summary>
        /// Get set property for TranTypeID
        /// </summary>
        public string TType
        {
            get { return _sTType; }
            set { _sTType = value; }
        }

        /// <summary>
        /// Get set property for Destination
        /// </summary>
        public string Destination
        {
            get { return _sDestination; }
            set { _sDestination = value; }
        }

        /// <summary>
        /// Get set property for Channel
        /// </summary>
        public string Channel
        {
            get { return _sChannel; }
            set { _sChannel = value; }
        }

        /// <summary>
        /// Get set property for TranStatus
        /// </summary>
        public string TranStatus
        {
            get { return _sTranStatus; }
            set { _sTranStatus = value; }
        }

        /// <summary>
        /// Get set property for VehicleID
        /// </summary>
        public object VehicleID
        {
            get { return _nVehicleID; }
            set { _nVehicleID = value; }
        }

        /// <summary>
        /// Get set property for Shipment Type
        /// </summary>
        public ShipmentType ShipmentType
        {
            get { return _nShipmentType; }
            set { _nShipmentType = value; }
        }

        /// <summary>
        /// Get set property for VehicleID
        /// </summary>
        public double CostAmount
        {
            get { return _nCostAmount; }
            set { _nCostAmount = value; }
        }

        /// <summary>
        /// Get set property for Tran Amount
        /// </summary>
        public double TranAmount
        {
            get { return _nTranAmount; }
            set { _nTranAmount = value; }
        }

        /// <summary>
        /// Get set property for EntryDate
        /// </summary>
        public DateTime EntryDate
        {
            get { return _dEntryDate; }
            set { _dEntryDate = value; }
        }

        /// <summary>
        /// Get set property for RouteID
        /// </summary>
        public int RouteID
        {
            get { return _nRouteID; }
            set { _nRouteID = value; }
        }
        private string _sDistrictName;
        public string DistrictName
        {
            get { return _sDistrictName; }
            set { _sDistrictName = value; }
        }

        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ShipmentVehicle(Company, TType,TranID,ShipmentType,VehicleID,CostAmount,EntryDate)" +
                        " VALUES(?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Company", _sCompany);
                cmd.Parameters.AddWithValue("TType", _sTType);
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("ShipmentType", _nShipmentType);
                cmd.Parameters.AddWithValue("VehicleID", _nVehicleID);
                cmd.Parameters.AddWithValue("CostAmount", _nCostAmount);
                cmd.Parameters.AddWithValue("EntryDate", _dEntryDate);


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

            try
            {
                cmd.CommandText = "Delete from  t_ShipmentVehicle Where Company=? AND TType=? AND TranID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Company", _sCompany);
                cmd.Parameters.AddWithValue("TType", _sTType);
                cmd.Parameters.AddWithValue("TranID", _nTranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public void AddLogShipment()
        {
            int nMaxShipmentID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ShipmentID]) FROM t_LogDeliveryShipment";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxShipmentID = 1;
                }
                else
                {
                    nMaxShipmentID = Convert.ToInt32(maxID) + 1;
                }
                _nShipmentID = nMaxShipmentID;

                _sShipmentNo = "S-" + DateTime.Now.Year.ToString() + "-" + nMaxShipmentID.ToString("00000");

                sSql = "INSERT INTO t_LogDeliveryShipment (ShipmentID, ShipmentNo, ShipmentDate, GatePassNo, FreightCost, LocalDeliveryCost, CreateDate, CreateUserID, UpdateDate, UpdateUserID, ParcelCost) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);
                cmd.Parameters.AddWithValue("ShipmentNo", _sShipmentNo);
                cmd.Parameters.AddWithValue("ShipmentDate", _dtShipmentDate);
                cmd.Parameters.AddWithValue("GatePassNo", _sGatePassNo);
                cmd.Parameters.AddWithValue("FreightCost", _nFreightCost);
                cmd.Parameters.AddWithValue("LocalDeliveryCost", _nLocalDeliveryCost);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("ParcelCost", _ParcelCost);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (LogDeliveryShipmentItem oItem in this)
                {
                    oItem.ShipmentID = _nShipmentID;
                    oItem.Add(1);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddDeilveryVehicle()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_DutyVehicle (Type, TranID, DutyTranID, ShipmentDate, VendorID, VehicleID, VehicleNo, CreateDate, CreateUserID, UpdateDate, UpdateUserID,DeliveryMode,ParcelType,DeliveryPerson,DeliveryPersonContactNo,GatePassNo,VehicleCapacity) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Type", _sTType);
                cmd.Parameters.AddWithValue("TranID", _nTranID);
                cmd.Parameters.AddWithValue("DutyTranID", _nDutyTranID);
                cmd.Parameters.AddWithValue("ShipmentDate", _dtShipmentDate);
                cmd.Parameters.AddWithValue("VendorID", _nVendorID);
                if (_nVehicleID != null)
                {
                    cmd.Parameters.AddWithValue("VehicleID", _nVehicleID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("VehicleID", null);
                }
                //if (_sVehicleNo != null)
                //{
                cmd.Parameters.AddWithValue("VehicleNo", _sVehicleNo);
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("VehicleNo", null);
                //}
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);

                cmd.Parameters.AddWithValue("DeliveryMode", _nDeliveryMode);
                cmd.Parameters.AddWithValue("ParcelType", _nParcelType);

                cmd.Parameters.AddWithValue("DeliveryPerson", _sDeliveryPerson);
                cmd.Parameters.AddWithValue("DeliveryPersonContactNo", _sDeliveryPersonContactNo);
                cmd.Parameters.AddWithValue("GatePassNo", _sGatePassNo);
                cmd.Parameters.AddWithValue("VehicleCapacity", _sVehicleCapacity);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditLogShipment(int nShipmentID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_LogDeliveryShipment SET ShipmentDate = ?, GatePassNo = ?, FreightCost = ?, LocalDeliveryCost = ?, UpdateDate = ?, UpdateUserID = ?, ParcelCost = ? WHERE ShipmentID = ?";
                
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ShipmentDate", _dtShipmentDate);
                cmd.Parameters.AddWithValue("GatePassNo", _sGatePassNo);
                cmd.Parameters.AddWithValue("FreightCost", _nFreightCost);
                cmd.Parameters.AddWithValue("LocalDeliveryCost", _nLocalDeliveryCost);
                //cmd.Parameters.AddWithValue("VendorID", _nVendorID);
                //cmd.Parameters.AddWithValue("VehicleID", _nVehicleID);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("ParcelCost", _ParcelCost);
                cmd.Parameters.AddWithValue("ShipmentID", nShipmentID);
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                LogDeliveryShipmentItem oLogDeliveryShipmentItem = new LogDeliveryShipmentItem();
                oLogDeliveryShipmentItem.ShipmentID = nShipmentID;
                oLogDeliveryShipmentItem.Delete();

                foreach (LogDeliveryShipmentItem oItem in this)
                {
                    oItem.ShipmentID = nShipmentID;
                    oItem.Add(2);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateDutyTranDate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_Dutytran SET DutyTranDate = ?,VehicleNumber = ? WHERE DutyTranID = ? and DutyTranNo = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranDate", _dtShipmentDate);
                cmd.Parameters.AddWithValue("VehicleNumber", _sVehicleNo);
                cmd.Parameters.AddWithValue("DutyTranID", _nDutyTranID);
                cmd.Parameters.AddWithValue("DutyTranNo", _sDutyTranNo);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateDutyTranTel()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_Dutytran SET VehicleNumber = ? WHERE DutyTranID = ? and DutyTranNo = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.AddWithValue("VehicleNumber", _sVehicleNo);
                cmd.Parameters.AddWithValue("DutyTranID", _nDutyTranID);
                cmd.Parameters.AddWithValue("DutyTranNo", _sDutyTranNo);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetVehicleNo(int nTranID, int nDutyTranID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select VehicleNo=Case when VenDorID=0 then VehicleName+'['+RegistrationNo+']'  " +
                        "else VehicleNo end From ( Select a.*,VehicleName,RegistrationNo From (Select * From t_DutyVehicle where TranID=" + nTranID + " and DutyTranID=" + nDutyTranID + ") a  " +
                        "left outer join (Select * From t_Vehicle) b on a.VehicleID=b.VehicleID) Main ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sVehicleNo = (string)reader["VehicleNo"];
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetShipmentDataOld(int nShipmentID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From  " +
                        "(  " +
                        "Select ShipmentID,Company,TranType,TranID,InvoiceNo as TranNo,  " +
                        "InvoiceDate as TranDate,StockPrice,FreightCost,LocalDeliveryCost  " +
                        "From   " +
                        "(Select ShipmentID,Company,TranType,TranID,FreightCost,LocalDeliveryCost   " +
                        "From TELSysDB.DBO.t_LogDeliveryShipmentItem where Company='BLL' and TranType='Invoice') a,  " +
                        "(Select a.InvoiceID,InvoiceNo,InvoiceDate,sum(Quantity*UnitPrice) as StockPrice   " +
                        "From BLLSysDB.DBO.t_SalesInvoice a,BLLSysDB.DBO.t_SalesInvoicedetail b  " +
                        "where a.InvoiceID=b.InvoiceID group by a.InvoiceID,InvoiceNo,InvoiceDate) b  " +
                        "where a.TranID=b.InvoiceID  " +
                        "Union All  " +
                        "Select ShipmentID,Company,TranType,TranID,InvoiceNo as TranNo,  " +
                        "InvoiceDate as TranDate,StockPrice,FreightCost,LocalDeliveryCost  " +
                        "From   " +
                        "(Select ShipmentID,Company,TranType,TranID,FreightCost,LocalDeliveryCost   " +
                        "From TELSysDB.DBO.t_LogDeliveryShipmentItem where Company='TEL' and TranType='Invoice') a,  " +
                        "(Select a.InvoiceID,InvoiceNo,InvoiceDate,sum(Quantity*UnitPrice) as StockPrice   " +
                        "From TELSysDB.DBO.t_SalesInvoice a,TELSysDB.DBO.t_SalesInvoicedetail b  " +
                        "where a.InvoiceID=b.InvoiceID group by a.InvoiceID,InvoiceNo,InvoiceDate) b  " +
                        "where a.TranID=b.InvoiceID  " +
                        "Union All  " +
                        "Select ShipmentID,Company,TranType,TranID,InvoiceNo as TranNo,  " +
                        "InvoiceDate as TranDate,StockPrice,FreightCost,LocalDeliveryCost  " +
                        "From   " +
                        "(Select ShipmentID,Company,TranType,TranID,FreightCost,LocalDeliveryCost   " +
                        "From TELSysDB.DBO.t_LogDeliveryShipmentItem where Company='TML' and TranType='Invoice') a,  " +
                        "(Select a.InvoiceID,InvoiceNo,InvoiceDate,sum(Quantity*UnitPrice) as StockPrice   " +
                        "From TMLSysDB.DBO.t_SalesInvoice a,TMLSysDB.DBO.t_SalesInvoicedetail b  " +
                        "where a.InvoiceID=b.InvoiceID group by a.InvoiceID,InvoiceNo,InvoiceDate) b  " +
                        "where a.TranID=b.InvoiceID  " +
                        "Union All  " +
                        "Select ShipmentID,Company,TranType,a.TranID,TranNo,  " +
                        "TranDate,StockPrice,FreightCost,LocalDeliveryCost  " +
                        "From   " +
                        "(Select * From TELSysDB.DBO.t_LogDeliveryShipmentItem   " +
                        "where Company='TEL' and TranType='Chalan') a,  " +
                        "(Select a.TranID,TranNo,TranDate,sum(Qty*StockPrice) as StockPrice   " +
                        "From TELSysDB.DBO.t_ProductStockTran a,TELSysDB.DBO.t_ProductStockTranItem b  " +
                        "where a.TranID=b.TranID group by a.TranID,TranNo,TranDate) b  " +
                        "where a.TranID=b.TranID   " +
                        "Union All  " +
                        "Select ShipmentID,Company,TranType,a.TranID,TranNo,  " +
                        "TranDate,StockPrice,FreightCost,LocalDeliveryCost  " +
                        "From   " +
                        "(Select * From TELSysDB.DBO.t_LogDeliveryShipmentItem   " +
                        "where Company='TML' and TranType='Chalan') a,  " +
                        "(Select a.TranID,TranNo,TranDate,sum(Qty*StockPrice) as StockPrice   " +
                        "From TMLSysDB.DBO.t_ProductStockTran a,TMLSysDB.DBO.t_ProductStockTranItem b  " +
                        "where a.TranID=b.TranID group by a.TranID,TranNo,TranDate) b  " +
                        "where a.TranID=b.TranID   " +
                        ") a where ShipmentID=" + nShipmentID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LogDeliveryShipmentItem _oItem = new LogDeliveryShipmentItem();
                    _oItem.ShipmentID = (int)reader["ShipmentID"];
                    _oItem.Company = (string)reader["Company"];
                    _oItem.TranType = (string)reader["TranType"];
                    _oItem.TranID = (int)reader["TranID"];

                    _oItem.TranNo = (string)reader["TranNo"];
                    _oItem.TranDate = (DateTime)reader["TranDate"];
                    _oItem.StockPrice = (double)reader["StockPrice"];
                    
                    _oItem.LocalDeliveryCost = (double)reader["LocalDeliveryCost"];
                    _oItem.FreightCost = (double)reader["FreightCost"];

                    InnerList.Add(_oItem);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetShipmentData(int nShipmentID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ShipmentID,Company,TranType,TranID,TranNo,TranDate,isnull(StockPrice,0) StockPrice,  " +
                        "isnull(a.VendorID,-1) VendorID,isnull(VendorName,'') VendorName,isnull(VehicleNo,'') VehicleNo,isnull(VehicleID,-1) VehicleID,isnull(FreightCost,0) FreightCost,isnull(LocalDeliveryCost,0) LocalDeliveryCost,   " +
                        "isnull(ParcelCost, 0) ParcelCost,ReceiveDate,ReceiveTime,   " +
                        "isnull(Remarks, '') Remarks,isnull(a.DeliveryMode, 1) DeliveryMode,  " +
                        "isnull(ParcelType, 0) ParcelType,isnull(ParcelVendorID, -1) ParcelVendorID,isnull(VehicleCapacity,'') VehicleCapacity  " +
                        "From t_LogDeliveryShipmentItem a, t_LogDeliveryShipmentVendor b  " +
                        "where a.VendorID = b.VendorID and ShipmentID = " + nShipmentID + "";
           
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LogDeliveryShipmentItem _oItem = new LogDeliveryShipmentItem();
                    _oItem.Company = (string)reader["Company"];
                    _oItem.VendorID = (int)reader["VendorID"];
                    _oItem.VendorName = (string)reader["VendorName"];
                    _oItem.VehicleNo = (string)reader["VehicleNo"];
                    _oItem.TranType = (string)reader["TranType"];
                    _oItem.TranID = (int)reader["TranID"];
                    _oItem.TranNo = (string)reader["TranNo"];
                    _oItem.TranDate = (DateTime)reader["TranDate"];
                    _oItem.StockPrice = (double)reader["StockPrice"];
                    _oItem.LocalDeliveryCost = (double)reader["LocalDeliveryCost"];
                    _oItem.FreightCost = (double)reader["FreightCost"];
                    _oItem.VehicleID = (int)reader["VehicleID"];
                    _oItem.ShipmentID = (int)reader["ShipmentID"];
                    if (reader["ReceiveDate"] != DBNull.Value)
                    {
                        _oItem.ReceiveDate = (DateTime)reader["ReceiveDate"];
                        _oItem.ReceiveTime = (DateTime)reader["ReceiveTime"];
                    }
                    _oItem.Remarks = (string)reader["Remarks"];
                    _oItem.ParcelCost = (double)reader["ParcelCost"];

                    _oItem.ParcelType = (int)reader["ParcelType"];
                    _oItem.ParcelVendorID = (int)reader["ParcelVendorID"];
                    _oItem.DeliveryMode = (int)reader["DeliveryMode"];
                    _oItem.VehicleCapacity = (string)reader["VehicleCapacity"];
                    InnerList.Add(_oItem);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetShipmentDataForDateEdit(DateTime dtFromDate, DateTime dtTodate, string sTranNo, string sVehicleNo, int nVendor, string sCustomer, string sTranType, string sCompany, string sChannelDescription, int nArea, int nDistrictID, int nTerritoryID, int nThana,int nDeliveryMode)
        {

            dtTodate = dtTodate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select x.*,isnull(y.VendorName,'N/A') ParcelVendorName From  " +
                        "(  " +
                        "Select a.*, ShipmentNo, ShipmentDate, CustomerCode, CustomerName, AreaID, AreaName, TerritoryID, TerritoryName,  " +
                        "DistrictID, DistrictName, ThanaID, ThanaName, ChannelDescription, VendorName, VendorType From  " +
                        "(  " +
                        "Select ShipmentID, Company, TranType, a.TranID, a.TranNo, b.TranDate, StockPrice, isnull(VendorID, -1) VendorID,  " +
                        "isnull(VehicleNo, '') VehicleNo, isnull(VehicleID, -1) VehicleID, isnull(FreightCost, 0) as FreightCost, isnull(LocalDeliveryCost, 0) as LocalDeliveryCost,  " +
                        "isnull(ParcelCost, 0) ParcelCost, ReceiveDate, ReceiveTime, isnull(a.Remarks, '') Remarks,  " +
                        "isnull(DeliveryMode, 1) DeliveryMode, isnull(ParcelType, 0) ParcelType,  " +
                        "isnull(ParcelVendorID, -1) ParcelVendorID, CustomerID  " +
                        "From t_LogDeliveryShipmentItem a, t_ProductStockTran b, t_Showroom c  " +
                        "where TranType = 'Challan' and a.TranID = b.TranID and b.ToWHID = c.WarehouseID  " +
                        "Union All  " +
                        "Select ShipmentID, Company, TranType, a.TranID, a.TranNo, b.InvoiceDate, StockPrice, isnull(VendorID, -1) VendorID,  " +
                        "isnull(VehicleNo, '') VehicleNo, isnull(VehicleID, -1) VehicleID, isnull(FreightCost, 0) as FreightCost, isnull(LocalDeliveryCost, 0) as LocalDeliveryCost, isnull(ParcelCost, 0) ParcelCost,  " +
                        "ReceiveDate, ReceiveTime, isnull(a.Remarks, '') Remarks,  " +
                        "isnull(a.DeliveryMode, 1) DeliveryMode, isnull(ParcelType, 0) ParcelType,  " +
                        "isnull(ParcelVendorID, -1) ParcelVendorID, CustomerID  " +
                        "From t_LogDeliveryShipmentItem a, t_SalesInvoice b  " +
                        "where TranType = 'Invoice' and a.TranID = b.InvoiceID  " +
                        ") A, v_CustomerDetails B, t_LogDeliveryShipmentVendor c, t_LogDeliveryShipment d  " +
                        "where a.CustomerID = b.CustomerID and a.VendorID = c.VendorID and a.ShipmentID = d.ShipmentID  " +
                        ") X  " +
                        "left Outer Join  " +
                        "(  " +
                        "Select * From t_LogDeliveryShipmentVendor  " +
                        ") Y  " +
                        "on x.ParcelVendorID = y.VendorID  " +
                        "where TranDate between '" + dtFromDate + "' and '" + dtTodate + "'  " +
                        "and TranDate< '" + dtTodate + "'";

            if (sTranNo != "")
            {
                sSql = sSql + " AND TranNo like '%" + sTranNo + "%'";
            }
            if (sVehicleNo != "")
            {
                sSql = sSql + " AND VehicleNo like '%" + sVehicleNo + "%'";
            }
            if (nVendor != -1)
            {
                sSql = sSql + " AND x.VendorID=" + nVendor + "";
            }
            if (sCustomer != "")
            {
                sSql = sSql + " AND CustomerName like '%" + sCustomer + "%'";
            }
            if (sTranType != "<All>")
            {
                sSql = sSql + " AND TranType like '%" + sTranType + "%'";
            }
            if (sCompany != "<All>")
            {
                sSql = sSql + " AND Company like '%" + sCompany + "%'";
            }

            if (sChannelDescription != "<All>")
            {
                sSql = sSql + " AND ChannelDescription like '%" + sChannelDescription + "%'";
            }
            if (nArea != -1)
            {
                sSql = sSql + " AND AreaID=" + nArea + "";
            }
            if (nDistrictID != -1)
            {
                sSql = sSql + " AND DistrictID=" + nDistrictID + "";
            }
            if (nTerritoryID != -1)
            {
                sSql = sSql + " AND TerritoryID=" + nTerritoryID + "";
            }
            if (nThana != -1)
            {
                sSql = sSql + " AND ThanaID=" + nThana + "";
            }
            if (nDeliveryMode != 0)
            {
                sSql = sSql + " AND x.DeliveryMode=" + nDeliveryMode + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LogDeliveryShipmentItem _oItem = new LogDeliveryShipmentItem();
                    _oItem.Company = (string)reader["Company"];
                    _oItem.ShipmentID = (int)reader["ShipmentID"];
                    _oItem.VendorID = (int)reader["VendorID"];
                    _oItem.VendorName = (string)reader["VendorName"];
                    _oItem.ShipmentNo = (string)reader["ShipmentNo"];
                    _oItem.CustomerName = (string)reader["CustomerName"];
                    _oItem.VehicleNo = (string)reader["VehicleNo"];
                    _oItem.TranType = (string)reader["TranType"];
                    _oItem.TranID = (int)reader["TranID"];
                    _oItem.TranNo = (string)reader["TranNo"];
                    _oItem.TranDate = (DateTime)reader["TranDate"];
                    _oItem.StockPrice = (double)reader["StockPrice"];
                    _oItem.LocalDeliveryCost = (double)reader["LocalDeliveryCost"];
                    _oItem.FreightCost = (double)reader["FreightCost"];
                    _oItem.VehicleID = (int)reader["VehicleID"];
                    _oItem.ShipmentID = (int)reader["ShipmentID"];
                    if (reader["ReceiveDate"] != DBNull.Value)
                    {
                        _oItem.ReceiveDate = (DateTime)reader["ReceiveDate"];
                        _oItem.ReceiveTime = (DateTime)reader["ReceiveTime"];
                    }
                    _oItem.Remarks = (string)reader["Remarks"];
                    _oItem.ParcelCost = (double)reader["ParcelCost"];

                    _oItem.ParcelType = (int)reader["ParcelType"];
                    _oItem.ParcelVendorID = (int)reader["ParcelVendorID"];
                    _oItem.DeliveryMode = (int)reader["DeliveryMode"];
                    _oItem.ParcelVendorName = (string)reader["ParcelVendorName"];

                    InnerList.Add(_oItem);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public bool IsVehicleAssign(int nTranID, string sType)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select * From t_DutyVehicle where TranID=" + nTranID + " and Type='" + sType + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
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
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string GetMaxGatePassNo(DateTime _dtDate)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sGatePassNo = "";
            string sSql = "Select isnull('GP-'+cast(max(right(GatepassNo,9))+1 as varchar),'GP-'+cast(cast(FORMAT(cast('" + _dtDate.Date + "' as date), 'yyMMdd') as varchar)+'000'+1  as varchar)) as GatePassNo From t_DutyVehicle where CreateDate = '" + _dtDate.Date + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sGatePassNo = (string)reader["GatePassNo"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return sGatePassNo;

        }


    }

    public class ShipmentVehicles : CollectionBase
    {
        public ShipmentVehicle this[int i]
        {
            get { return (ShipmentVehicle)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ShipmentVehicle oShipmentVehicle)
        {
            InnerList.Add(oShipmentVehicle);
        }

        public void Refersh(DateTime dFromDate, DateTime dToDate, string  sCompany, string sType, string sStatus, object dDeliveryDate,string sRouteID,string sTranNo, int nShipment, string sDistrict)
        {
            DateTime dDelDate;
            InnerList.Clear();
            //dtTodate = dtTodate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            #region NEW Query
            string sSql = "select AAA.*,BBB.ShipmentType,BBB.VehicleID,CCC.RouteID from  " +
            "( " +
            "select AA.Company, TType,TranID,TranNo,TranDate,DeliveryDate,TranStatus,DestinationID,Destination,Channel,  " +
            "SUM(Qty*UnitCost) as CostAmount,InvoiceAmount as TranAmount,DistrictName   " +
            "from ( " +
            "SELECT 'TEL' as Company,'Invoice' as TType,q1.InvoiceID as TranID,  " +
            "InvoiceNo as TranNo,InvoiceDate as TranDate, DeliveryDate,  " +
            "TranStatus= Case when InvoiceStatus =1 then 'Undelivered'   " +
            "when InvoiceStatus =2 then 'Delivered'   " +
            "when InvoiceStatus =5 then 'Pending'   " +
            "when InvoiceStatus =6 then 'Processing' else 'Nothing' end,  " +
            "q2.CustomerID as DestinationID,q2.CustomerName as Destination,ChannelDescription as Channel,q3.ProductID,q3.Quantity as Qty,InvoiceAmount,DistrictName  " +
            "FROM TELSysDB.dbo.t_SalesInvoice q1,TELSysDB.dbo.v_CustomerDetails q2, TELSysDB.dbo.t_SalesInvoiceDetail q3  " +
            "Where q1.customerid = q2.customerid   " +
            "AND InvoiceDate between ? AND ? and InvoiceDate < ?  " +
            "AND InvoiceStatus in (1,2,5,6)   " +
            "and WarehouseID in (Select WarehouseID from TELSysDB.dbo.t_Warehouse where WarehouseParentID IN (6,9))   " +
            "and q1.InvoiceID=q3.InvoiceID) AA  " +
            "inner join t_ShipmentCostParam BB  " +
            "on AA.Company=BB.Company and AA.ProductID=BB.ProductID  " +
            "Group by AA.Company, TType,TranID,TranNo,TranDate,DeliveryDate,TranStatus,DestinationID,Destination,Channel,InvoiceAmount,DistrictName  " +

            "Union All  " +
            "select AA.Company, TType,TranID,TranNo,TranDate,TranDate as DeliveryDate,TranStatus,DestinationID,Destination,Channel,  " +
            "SUM(Qty*UnitCost) as CostAmount,SUM(Qty*StockPrice) as TranAmount,'NA'as DistrictName   " +
            "from (select 'TEL' as Company,'Chalan' as TType,PST.TranID,TranNo,TranDate,'Delivered' as TranStatus,  " +
            "WH.WarehouseID as DestinationID,WH.ShortCode as Destination,ChannelDescription as Channel,PSTI.ProductID,PSTI.Qty,PSTI.StockPrice  " +
            "from TELSysDB.dbo.t_ProductStockTran PST  " +
            "inner join TELSysDB.dbo.t_Warehouse WH  " +
            "on PST.ToWHID=WH.WarehouseID  " +
            "inner join TELSysDB.dbo.t_Channel CH  " +
            "on PST.ToChannelID=CH.ChannelID  " +
            "inner join TELSysDB.dbo.t_ProductStockTranItem PSTI  " +
            "on PST.TranID=PSTI.TranID  " +
            "where TranDate  between ? and ?   " +
            "and TranDate < ? and TranTypeID=3   " +
            "and FromWHID in (Select WarehouseID from TELSysDB.dbo.t_Warehouse where WarehouseParentID IN (6,9))   " +
            "and WH.WarehouseParentID in (2,4,7) ) AA  " +
            "inner join t_ShipmentCostParam BB  " +
            "on AA.Company=BB.Company and AA.ProductID=BB.ProductID  " +
            "Group by AA.Company, TType,TranID,TranNo,TranDate,TranStatus,DestinationID,Destination,Channel  " +

            "Union All  " +
            "select AA.Company, TType,TranID,TranNo,TranDate,DeliveryDate,TranStatus,DestinationID,Destination,Channel,  " +
            "SUM(Qty*UnitCost) as CostAmount,InvoiceAmount as TranAmount,DistrictName   " +
            "from (SELECT 'TML' as Company,'Invoice' as TType,q1.InvoiceID as TranID,  " +
            "InvoiceNo as TranNo,InvoiceDate as TranDate,DeliveryDate,  " +
            "TranStatus= Case when InvoiceStatus =1 then 'Undelivered'   " +
            "when InvoiceStatus =2 then 'Delivered'   " +
            "when InvoiceStatus =5 then 'Pending'   " +
            "when InvoiceStatus =6 then 'Processing' else 'Nothing' end,  " +
            "q2.CustomerID as DestinationID,q2.CustomerName as Destination,ChannelDescription as Channel,q3.ProductID,q3.Quantity as Qty,InvoiceAmount,DistrictName  " +
            "FROM TMLSysDB.dbo.t_SalesInvoice q1,TMLSysDB.dbo.v_CustomerDetails q2, TMLSysDB.dbo.t_SalesInvoiceDetail q3  " +
            "Where q1.customerid = q2.customerid   " +
            "AND InvoiceDate between ? AND ? and InvoiceDate < ?  " +
            "AND InvoiceStatus in (1,2,5,6)   " +
            "and WarehouseID in (Select WarehouseID from TMLSysDB.dbo.t_Warehouse where WarehouseParentID IN (6,9))   " +
            "and q1.InvoiceID=q3.InvoiceID) AA  " +
            "inner join t_ShipmentCostParam BB  " +
            "on AA.Company=BB.Company and AA.ProductID=BB.ProductID  " +
            "Group by AA.Company, TType,TranID,TranNo,TranDate,DeliveryDate,TranStatus,DestinationID,Destination,Channel,InvoiceAmount,DistrictName  " +

            "Union All  " +

            "select AA.Company, TType,TranID,TranNo,TranDate,TranDate as DeliveryDate,TranStatus,DestinationID,Destination,Channel,  " +
            "SUM(Qty*UnitCost) as CostAmount,SUM(Qty*StockPrice) as TranAmount,'NA' as DistrictName   " +
            "from (select 'TML' as Company,'Chalan' as TType,PST.TranID,TranNo,TranDate,'Delivered' as TranStatus,  " +
            "WH.WarehouseID as DestinationID,WH.ShortCode as Destination,ChannelDescription as Channel,PSTI.ProductID,PSTI.Qty,PSTI.StockPrice  " +
            "from TMLSysDB.dbo.t_ProductStockTran PST  " +
            "inner join TMLSysDB.dbo.t_Warehouse WH  " +
            "on PST.ToWHID=WH.WarehouseID  " +
            "inner join TMLSysDB.dbo.t_Channel CH  " +
            "on PST.ToChannelID=CH.ChannelID  " +
            "inner join TMLSysDB.dbo.t_ProductStockTranItem PSTI  " +
            "on PST.TranID=PSTI.TranID  " +
            "where TranDate  between ? and ?   " +
            "and TranDate < ? and TranTypeID=3    " +
            "and FromWHID in (Select WarehouseID from TMLSysDB.dbo.t_Warehouse where WarehouseParentID IN (6,9))   " +
            "and WH.WarehouseParentID in (2,4,7) ) AA  " +
            "inner join t_ShipmentCostParam BB  " +
            "on AA.Company=BB.Company and AA.ProductID=BB.ProductID  " +
            "Group by AA.Company, TType,TranID,TranNo,TranDate,TranStatus,DestinationID,Destination,Channel  " +

            "Union All  " +

            "select AA.Company, TType,TranID,TranNo,TranDate,DeliveryDate,TranStatus,DestinationID,Destination,Channel,  " +
            "SUM(Qty*UnitCost) as CostAmount,InvoiceAmount as TranAmount,DistrictName  " +
            "from (SELECT 'BLL' as Company,'Invoice' as TType,q1.InvoiceID as TranID,  " +
            "InvoiceNo as TranNo,InvoiceDate as TranDate,DeliveryDate,  " +
            "TranStatus= Case when InvoiceStatus =1 then 'Undelivered'   " +
            "when InvoiceStatus =2 then 'Delivered'   " +
            "when InvoiceStatus =5 then 'Pending'   " +
            "when InvoiceStatus =6 then 'Processing' else 'Nothing' end,  " +
            "q2.CustomerID as DestinationID,q2.CustomerName as Destination,ChannelDescription as Channel,q3.ProductID,q3.Quantity as Qty,InvoiceAmount, DistrictName  " +
            "FROM BLLSysDB.dbo.t_SalesInvoice q1,BLLSysDB.dbo.v_CustomerDetails q2, BLLSysDB.dbo.t_SalesInvoiceDetail q3  " +
            "Where q1.customerid = q2.customerid   " +
            "AND InvoiceDate between ? AND ? and InvoiceDate < ?  " +
            "AND InvoiceStatus in (1,2,5,6)   " +
            "and WarehouseID in (Select WarehouseID from BLLSysDB.dbo.t_Warehouse where WarehouseParentID IN (6,9))   " +
            "and q1.InvoiceID=q3.InvoiceID) AA  " +
            "inner join t_ShipmentCostParam BB  " +
            "on AA.Company=BB.Company and AA.ProductID=BB.ProductID  " +
            "Group by AA.Company, TType,TranID,TranNo,TranDate,DeliveryDate,TranStatus,DestinationID,Destination,Channel,InvoiceAmount,DistrictName " +

            ") AAA  " +
            "left outer join TELSysDB.dbo.t_ShipmentVehicle BBB  " +
            "on AAA.Company=BBB.Company and AAA.TType=BBB.TType and AAA.TranID=BBB.TranID  " +
            "left outer join TELSysDB.dbo.t_ShipmentRoute CCC  " +
            "on AAA.Company=CCC.Company and AAA.TType=CCC.TType and AAA.DestinationID=CCC.DestinationID ";
                       
                #endregion


             #region Old Query
                        //string sSql = " select AAA.*,BBB.ShipmentType,BBB.VehicleID,CCC.RouteID from  " +
            //    " (select AA.Company, TType,TranID,TranNo,TranDate,DeliveryDate,TranStatus,DestinationID,Destination,Channel, SUM(Qty*UnitCost) as CostAmount,InvoiceAmount as TranAmount  " +
            //    " from (SELECT 'TEL' as Company,'Invoice' as TType,q1.InvoiceID as TranID, " +
            //    " InvoiceNo as TranNo,InvoiceDate as TranDate, DeliveryDate, " +
            //    " TranStatus= Case when InvoiceStatus =1 then 'Undelivered'  " +
            //    " when InvoiceStatus =2 then 'Delivered'  " +
            //    " when InvoiceStatus =5 then 'Pending'  " +
            //    " when InvoiceStatus =6 then 'Processing' else 'Nothing' end, " +
            //    " q2.CustomerID as DestinationID,q2.CustomerName as Destination,ChannelDescription as Channel,q3.ProductID,q3.Quantity as Qty,InvoiceAmount " +
            //    " FROM TELSysDB.dbo.t_SalesInvoice q1,TELSysDB.dbo.v_CustomerDetails q2, TELSysDB.dbo.t_SalesInvoiceDetail q3 " +
            //    " Where q1.customerid = q2.customerid  " +
            //    " AND InvoiceDate between ? AND ? and InvoiceDate < ? " +
            //    " AND InvoiceStatus in (1,2,5,6)  " +
            //    " and WarehouseID in (Select WarehouseID from TELSysDB.dbo.t_Warehouse where WarehouseParentID=6)  " +
            //    " and q1.InvoiceID=q3.InvoiceID) AA " +
            //    " inner join t_ShipmentCostParam BB " +
            //    " on AA.Company=BB.Company and AA.ProductID=BB.ProductID " +
            //    " Group by AA.Company, TType,TranID,TranNo,TranDate,DeliveryDate,TranStatus,DestinationID,Destination,Channel,InvoiceAmount " +
                
            //    " Union All " +
            //    " select AA.Company, TType,TranID,TranNo,TranDate,TranDate as DeliveryDate,TranStatus,DestinationID,Destination,Channel, SUM(Qty*UnitCost) as CostAmount,SUM(Qty*StockPrice) as TranAmount  " +
            //    " from (select 'TEL' as Company,'Chalan' as TType,PST.TranID,TranNo,TranDate,'Delivered' as TranStatus, " +
            //    " WH.WarehouseID as DestinationID,WH.ShortCode as Destination,ChannelDescription as Channel,PSTI.ProductID,PSTI.Qty,PSTI.StockPrice " +
            //    " from TELSysDB.dbo.t_ProductStockTran PST " +
            //    " inner join TELSysDB.dbo.t_Warehouse WH " +
            //    " on PST.ToWHID=WH.WarehouseID " +
            //    " inner join TELSysDB.dbo.t_Channel CH " +
            //    " on PST.ToChannelID=CH.ChannelID " +
            //    " inner join TELSysDB.dbo.t_ProductStockTranItem PSTI " +
            //    " on PST.TranID=PSTI.TranID " +
            //    " where TranDate  between ? and ?  " +
            //    " and TranDate < ? and TranTypeID=3  " +
            //    " and FromWHID in (Select WarehouseID from TELSysDB.dbo.t_Warehouse where WarehouseParentID=6)  " +
            //    " and WH.WarehouseParentID in (2,4,7) ) AA " +
            //    " inner join t_ShipmentCostParam BB " +
            //    " on AA.Company=BB.Company and AA.ProductID=BB.ProductID " +
            //    " Group by AA.Company, TType,TranID,TranNo,TranDate,TranStatus,DestinationID,Destination,Channel " +
                
            //    " Union All " +
            //    " select AA.Company, TType,TranID,TranNo,TranDate,DeliveryDate,TranStatus,DestinationID,Destination,Channel, SUM(Qty*UnitCost) as CostAmount,InvoiceAmount as TranAmount  " +
            //    " from (SELECT 'TML' as Company,'Invoice' as TType,q1.InvoiceID as TranID, " +
            //    " InvoiceNo as TranNo,InvoiceDate as TranDate,DeliveryDate, " +
            //    " TranStatus= Case when InvoiceStatus =1 then 'Undelivered'  " +
            //    " when InvoiceStatus =2 then 'Delivered'  " +
            //    " when InvoiceStatus =5 then 'Pending'  " +
            //    " when InvoiceStatus =6 then 'Processing' else 'Nothing' end, " +
            //    " q2.CustomerID as DestinationID,q2.CustomerName as Destination,ChannelDescription as Channel,q3.ProductID,q3.Quantity as Qty,InvoiceAmount " +
            //    " FROM TMLSysDB.dbo.t_SalesInvoice q1,TMLSysDB.dbo.v_CustomerDetails q2, TMLSysDB.dbo.t_SalesInvoiceDetail q3 " +
            //    " Where q1.customerid = q2.customerid  " +
            //    " AND InvoiceDate between ? AND ? and InvoiceDate < ? " +
            //    " AND InvoiceStatus in (1,2,5,6)  " +
            //    " and WarehouseID in (Select WarehouseID from TMLSysDB.dbo.t_Warehouse where WarehouseParentID=6)  " +
            //    " and q1.InvoiceID=q3.InvoiceID) AA " +
            //    " inner join t_ShipmentCostParam BB " +
            //    " on AA.Company=BB.Company and AA.ProductID=BB.ProductID " +
            //    " Group by AA.Company, TType,TranID,TranNo,TranDate,DeliveryDate,TranStatus,DestinationID,Destination,Channel,InvoiceAmount " +
                
            //    " Union All " +
            //    " select AA.Company, TType,TranID,TranNo,TranDate,TranDate as DeliveryDate,TranStatus,DestinationID,Destination,Channel, SUM(Qty*UnitCost) as CostAmount,SUM(Qty*StockPrice) as TranAmount  " +
            //    " from (select 'TML' as Company,'Chalan' as TType,PST.TranID,TranNo,TranDate,'Delivered' as TranStatus, " +
            //    " WH.WarehouseID as DestinationID,WH.ShortCode as Destination,ChannelDescription as Channel,PSTI.ProductID,PSTI.Qty,PSTI.StockPrice " +
            //    " from TMLSysDB.dbo.t_ProductStockTran PST " +
            //    " inner join TMLSysDB.dbo.t_Warehouse WH " +
            //    " on PST.ToWHID=WH.WarehouseID " +
            //    " inner join TMLSysDB.dbo.t_Channel CH " +
            //    " on PST.ToChannelID=CH.ChannelID " +
            //    " inner join TMLSysDB.dbo.t_ProductStockTranItem PSTI " +
            //    " on PST.TranID=PSTI.TranID " +
            //    " where TranDate  between ? and ?  " +
            //    " and TranDate < ? and TranTypeID=3  " +
            //    " and FromWHID in (Select WarehouseID from TMLSysDB.dbo.t_Warehouse where WarehouseParentID=6)  " +
            //    " and WH.WarehouseParentID in (2,4,7) ) AA " +
            //    " inner join t_ShipmentCostParam BB " +
            //    " on AA.Company=BB.Company and AA.ProductID=BB.ProductID " +
            //    " Group by AA.Company, TType,TranID,TranNo,TranDate,TranStatus,DestinationID,Destination,Channel " +
                
            //    " Union All " +
            //    " select AA.Company, TType,TranID,TranNo,TranDate,DeliveryDate,TranStatus,DestinationID,Destination,Channel, SUM(Qty*UnitCost) as CostAmount,InvoiceAmount as TranAmount " +
            //    " from (SELECT 'BLL' as Company,'Invoice' as TType,q1.InvoiceID as TranID, " +
            //    " InvoiceNo as TranNo,InvoiceDate as TranDate,DeliveryDate, " +
            //    " TranStatus= Case when InvoiceStatus =1 then 'Undelivered'  " +
            //    " when InvoiceStatus =2 then 'Delivered'  " +
            //    " when InvoiceStatus =5 then 'Pending'  " +
            //    " when InvoiceStatus =6 then 'Processing' else 'Nothing' end, " +
            //    " q2.CustomerID as DestinationID,q2.CustomerName as Destination,ChannelDescription as Channel,q3.ProductID,q3.Quantity as Qty,InvoiceAmount " +
            //    " FROM BLLSysDB.dbo.t_SalesInvoice q1,BLLSysDB.dbo.v_CustomerDetails q2, BLLSysDB.dbo.t_SalesInvoiceDetail q3 " +
            //    " Where q1.customerid = q2.customerid  " +
            //    " AND InvoiceDate between ? AND ? and InvoiceDate < ? " +
            //    " AND InvoiceStatus in (1,2,5,6)  " +
            //    " and WarehouseID in (Select WarehouseID from BLLSysDB.dbo.t_Warehouse where WarehouseParentID=6)  " +
            //    " and q1.InvoiceID=q3.InvoiceID) AA " +
            //    " inner join t_ShipmentCostParam BB " +
            //    " on AA.Company=BB.Company and AA.ProductID=BB.ProductID " +
            //    " Group by AA.Company, TType,TranID,TranNo,TranDate,DeliveryDate,TranStatus,DestinationID,Destination,Channel,InvoiceAmount) AAA " +
            //    " left outer join TELSysDB.dbo.t_ShipmentVehicle BBB " +
            //    " on AAA.Company=BBB.Company and AAA.TType=BBB.TType and AAA.TranID=BBB.TranID " +
            //    " left outer join TELSysDB.dbo.t_ShipmentRoute CCC " +
            //    " on AAA.Company=CCC.Company and AAA.TType=CCC.TType and AAA.DestinationID=CCC.DestinationID ";
            #endregion

            cmd.Parameters.AddWithValue("InvoiceDate", dFromDate.Date);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate.Date);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate.Date);

            cmd.Parameters.AddWithValue("InvoiceDate", dFromDate.Date);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate.Date);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate.Date);

            cmd.Parameters.AddWithValue("InvoiceDate", dFromDate.Date);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate.Date);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate.Date);

            cmd.Parameters.AddWithValue("InvoiceDate", dFromDate.Date);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate.Date);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate.Date);

            cmd.Parameters.AddWithValue("InvoiceDate", dFromDate.Date);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate.Date);
            cmd.Parameters.AddWithValue("InvoiceDate", dToDate.Date);


            string sClause = "";

            if (sCompany != "ALL")
            {
                sClause = " WHERE AAA.Company=?";
                cmd.Parameters.AddWithValue("Company", sCompany);
            }

            if (sType != "ALL")
            {
                if (sClause == "")
                    sClause = " WHERE AAA.TType=?";
                else
                    sClause = sClause + " AND AAA.TType=?";
                cmd.Parameters.AddWithValue("TType", sType);
            }

            if (sStatus != "ALL")
            {
                if (sClause == "")
                    sClause = " WHERE AAA.TranStatus=?";
                else
                    sClause = sClause + " AND AAA.TranStatus=?";
                cmd.Parameters.AddWithValue("TranStatus", sStatus);
            }

            if (dDeliveryDate != null)
            {
                dDelDate = (DateTime)dDeliveryDate;
                if (sClause == "")
                    sClause = " WHERE AAA.DeliveryDate>=? AND AAA.DeliveryDate<?";
                else
                    sClause = sClause + " AND AAA.DeliveryDate>=? AND AAA.DeliveryDate<?";
                cmd.Parameters.AddWithValue("DeliveryDate", dDelDate);
                cmd.Parameters.AddWithValue("DeliveryDate", dDelDate.AddDays(1.0));
            }

            if (sRouteID != "<All>")
            {
                if (sClause == "")
                    sClause = " WHERE CCC.RouteID=?";
                else
                    sClause = sClause + " AND CCC.RouteID=?";
                cmd.Parameters.AddWithValue("RouteID", sRouteID);
            }

            if (sTranNo.Trim() != "")
            {
                if (sClause == "")
                    sClause = " WHERE AAA.TranNo like '%" + sTranNo + "%'";
                else
                    sClause = sClause + " AND AAA.TranNo like '%" + sTranNo + "%'";
            }
            if (nShipment >0)
            {
                
                if (sClause == "")
                    sClause = " WHERE BBB.ShipmentType = ?";
                else
                    sClause = sClause + " AND BBB.ShipmentType = ? ";
                cmd.Parameters.AddWithValue("ShipmentType", nShipment);
            }
            else if (nShipment == 0)
            {

                if (sClause == "")
                    sClause = " WHERE BBB.ShipmentType is null";
                else
                    sClause = sClause + " AND BBB.ShipmentType is null";
            }
            if (sDistrict.Trim() != "<All>")
            {
                if (sClause == "")
                    sClause = " Where DistrictName ='" + sDistrict + "' ";
                else
                    sClause = sClause + " AND DistrictName ='" + sDistrict + "' ";
            }


            try
            {
                cmd.CommandText = sSql + sClause;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ShipmentVehicle _oShipmentVehicle = new ShipmentVehicle();
                    _oShipmentVehicle.Company = reader["Company"].ToString();
                    _oShipmentVehicle.TranID = int.Parse(reader["TranID"].ToString());
                    _oShipmentVehicle.TranNo = reader["TranNo"].ToString();
                    _oShipmentVehicle.TranDate = Convert.ToDateTime(reader["TranDate"]);
                    if (reader["DeliveryDate"] != DBNull.Value)
                        _oShipmentVehicle.DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"]);
                    _oShipmentVehicle.TType = reader["TType"].ToString();
                    _oShipmentVehicle.Destination = reader["Destination"].ToString();
                    _oShipmentVehicle.Channel = reader["Channel"].ToString();
                    _oShipmentVehicle.TranStatus = reader["TranStatus"].ToString();
                    if (reader["ShipmentType"] != DBNull.Value)
                        _oShipmentVehicle.ShipmentType = (ShipmentType)reader["ShipmentType"];
                    if (reader["VehicleID"] != DBNull.Value)
                        _oShipmentVehicle.VehicleID = int.Parse(reader["VehicleID"].ToString());
                    if (reader["CostAmount"] != DBNull.Value)
                        _oShipmentVehicle.CostAmount = Convert.ToDouble(reader["CostAmount"]);
                    if (reader["TranAmount"] != DBNull.Value)
                        _oShipmentVehicle.TranAmount = Convert.ToDouble(reader["TranAmount"]);
                    if (reader["RouteID"] != DBNull.Value)
                    {
                        _oShipmentVehicle.RouteID = int.Parse(reader["RouteID"].ToString());
                    }
                    else
                    {
                        _oShipmentVehicle.RouteID = 0;
                    }
                    _oShipmentVehicle.DistrictName = reader["DistrictName"].ToString();
                    InnerList.Add(_oShipmentVehicle);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetLogDeliveryShipmentDataOld(DateTime dFromDate, DateTime dToDate, string sTranNo, string sTranType, string sCustomerCode, int nArea, int nThana, int nTerritoryID, int nDistrictID, string sChannelDescription, string sCompany, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From " +
                    "( " +
                    //---TEL----
                    "Select 'TEL' as Company,'Chalan' as TranType,a.TranID,TranNo,TranDate, " +
                    "d.CustomerID,CustomerCode,CustomerName,AreaID,AreaName,TerritoryID,TerritoryName, " +
                    "DistrictID,DistrictName,d.ThanaID,ThanaName, " +
                    "ChannelDescription,SUM(Qty*StockPrice) as StockPrice " +
                    "From TELSysDB.DBO.t_ProductStockTran a,TELSysDB.DBO.t_ProductStockTranItem b,TELSysDB.DBO.t_Showroom c,TELSysDB.DBO.v_CustomerDetails d,TELSysDB.DBO.v_ProductDetails e " +
                    "where a.TranID=b.TranID and a.ToWHID=c.WarehouseID and c.CustomerID=d.CustomerID and b.ProductID=e.ProductID and  " +
                    "TranTypeID=3 and TranDate>='01-Dec-2017' " +
                    "and a.TranID in  " +
                    "( " +
                    "Select StockTranID From TELSysDB.DBO.t_StockRequisition where RequisitionType=0 " +
                    "and StockTranID is not null " +
                    ")  and a.TranID not in (Select TranID From t_LogDeliveryShipmentItem where Company='TEL' and TranType='Chalan') " +
                    "group by a.TranID,TranNo,TranDate,CustomerCode,CustomerName,d.CustomerID, " +
                    "AreaID,TerritoryID,DistrictID,d.ThanaID, " +
                    "AreaName,TerritoryName,DistrictName,ThanaName,ChannelDescription " +
                    "Union All " +
                    "Select  'TEL' as Company,'Invoice' as TranType,a.InvoiceID as TranID, " +
                    "InvoiceNo as TranNo,InvoiceDate as TranDate, " +
                    "a.CustomerID,CustomerCode,CustomerName,AreaID,AreaName,TerritoryID,TerritoryName, " +
                    "DistrictID,DistrictName,ThanaID,ThanaName, " +
                    "ChannelDescription,SUM(Quantity*UnitPrice) as StockPrice " +
                    "From TELSysDB.DBO.t_SalesInvoice a,TELSysDB.DBO.t_SalesInvoiceDetail b,TELSysDB.DBO.v_CustomerDetails c,TELSysDB.DBO.v_ProductDetails d " +
                    "where a.InvoiceID=b.InvoiceID and a.CustomerID=c.CustomerID and b.ProductID=d.ProductID and  " +
                    "InvoiceDate>'01-Dec-2017' " +
                    "and WarehouseID in (Select WarehouseID From TELSysDB.DBO.t_Warehouse  " +
                    "where WarehouseParentID in (2,4,6,9)) and  " +
                    "InvoiceTypeID not in (6,7,8,9,10,11,12) and InvoiceStatus=2 and a.InvoiceID not in (Select TranID From TELSysDB.DBO.t_LogDeliveryShipmentItem where Company='TEL' and TranType='Invoice')  " +
                    "group by a.InvoiceID,InvoiceNo,InvoiceDate,a.CustomerID,CustomerCode,CustomerName, " +
                    "AreaID,TerritoryID,DistrictID,ThanaID, " +
                    "AreaName,TerritoryName,DistrictName,ThanaName,ChannelDescription " +
                    //---END TEL---- "+
                    "Union All " +
                    //---TML----- "+
                    "Select 'TML' as Company,'Chalan' as TranType,a.TranID,TranNo,TranDate, " +
                    "d.CustomerID,CustomerCode,CustomerName,AreaID,AreaName,TerritoryID,TerritoryName, " +
                    "DistrictID,DistrictName,d.ThanaID,ThanaName, " +
                    "ChannelDescription,SUM(Qty*StockPrice) as StockPrice " +
                    "From TMLSysDB.DBO.t_ProductStockTran a,TMLSysDB.DBO.t_ProductStockTranItem b,TMLSysDB.DBO.t_Showroom c,TMLSysDB.DBO.v_CustomerDetails d,TMLSysDB.DBO.v_ProductDetails e " +
                    "where a.TranID=b.TranID and a.ToWHID=c.WarehouseID and c.CustomerID=d.CustomerID and b.ProductID=e.ProductID and  " +
                    "TranTypeID=3 and TranDate>='01-Dec-2017' " +
                    "and a.TranID in  " +
                    "( " +
                    "Select StockTranID From TMLSysDB.DBO.t_StockRequisition where RequisitionType=0 " +
                    "and StockTranID is not null " +
                    ") and a.TranID not in (Select TranID From t_LogDeliveryShipmentItem where Company='TML' and TranType='Chalan')  " +
                    "group by a.TranID,TranNo,TranDate,CustomerCode,CustomerName,d.CustomerID, " +
                    "AreaID,TerritoryID,DistrictID,d.ThanaID, " +
                    "AreaName,TerritoryName,DistrictName,ThanaName,ChannelDescription " +
                    "Union All " +
                    "Select  'TML' as Company,'Invoice' as TranType,a.InvoiceID as TranID, " +
                    "InvoiceNo as TranNo,InvoiceDate as TranDate, " +
                    "a.CustomerID,CustomerCode,CustomerName,AreaID,AreaName,TerritoryID,TerritoryName, " +
                    "DistrictID,DistrictName,ThanaID,ThanaName, " +
                    "ChannelDescription,SUM(Quantity*UnitPrice) as StockPrice " +
                    "From TMLSysDB.DBO.t_SalesInvoice a,TMLSysDB.DBO.t_SalesInvoiceDetail b,TMLSysDB.DBO.v_CustomerDetails c,TMLSysDB.DBO.v_ProductDetails d " +
                    "where a.InvoiceID=b.InvoiceID and a.CustomerID=c.CustomerID and b.ProductID=d.ProductID and  " +
                    "InvoiceDate>'01-Dec-2017' " +
                    "and WarehouseID in (Select WarehouseID From TMLSysDB.DBO.t_Warehouse  " +
                    "where WarehouseParentID in (2,4,6,9)) and  " +
                    "InvoiceTypeID not in (6,7,8,9,10,11,12) and InvoiceStatus=2 and a.InvoiceID not in (Select TranID From TELSysDB.DBO.t_LogDeliveryShipmentItem where Company='TML' and TranType='Invoice')  " +
                    "group by a.InvoiceID,InvoiceNo,InvoiceDate,a.CustomerID,CustomerCode,CustomerName, " +
                    "AreaID,TerritoryID,DistrictID,ThanaID, " +
                    "AreaName,TerritoryName,DistrictName,ThanaName,ChannelDescription " +
                    //---END TML----- "+
                    "Union All " +
                    //---BLL--- "+
                    "Select  'BLL' as Company,'Invoice' as TranType,a.InvoiceID as TranID, " +
                    "InvoiceNo as TranNo,InvoiceDate as TranDate, " +
                    "a.CustomerID,CustomerCode,CustomerName,AreaID,AreaName,TerritoryID,TerritoryName, " +
                    "DistrictID,DistrictName,ThanaID,ThanaName, " +
                    "ChannelDescription,SUM(Quantity*UnitPrice) as StockPrice " +
                    "From BLLSysDB.DBO.t_SalesInvoice a,BLLSysDB.DBO.t_SalesInvoiceDetail b,BLLSysDB.DBO.v_CustomerDetails c,BLLSysDB.DBO.v_ProductDetails d " +
                    "where a.InvoiceID=b.InvoiceID and a.CustomerID=c.CustomerID and b.ProductID=d.ProductID and  " +
                    "InvoiceDate>'01-Dec-2017' " +
                    "and WarehouseID in (Select WarehouseID From BLLSysDB.DBO.t_Warehouse  " +
                    "where WarehouseParentID in (2,4,6,9)) and  " +
                    "InvoiceTypeID not in (6,7,8,9,10,11,12) and InvoiceStatus=2 and a.InvoiceID not in (Select TranID From TELSysDB.DBO.t_LogDeliveryShipmentItem where Company='BLL' and TranType='Invoice')  " +
                    "group by a.InvoiceID,InvoiceNo,InvoiceDate,a.CustomerID,CustomerCode,CustomerName, " +
                    "AreaID,TerritoryID,DistrictID,ThanaID, " +
                    "AreaName,TerritoryName,DistrictName,ThanaName,ChannelDescription " +
                    //----END BLL--- "+
                    ") Main where 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate<'" + dToDate + "' ";
            }
            if (sTranNo != "")
            {
                sSql = sSql + " AND TranNo like '%" + sTranNo + "%'";
            }
            if (sTranType != "<All>")
            {
                sSql = sSql + " AND TranType like '%" + sTranType + "%'";
            }
            if (sCustomerCode != "<All>")
            {
                sSql = sSql + " AND CustomerCode like '%" + sCustomerCode + "%'";
            }
            if (nArea != -1)
            {
                sSql = sSql + " AND AreaID=" + nArea + "";
            }
            if (nTerritoryID != -1)
            {
                sSql = sSql + " AND TerritoryID=" + nTerritoryID + "";
            }
            if (nThana != -1)
            {
                sSql = sSql + " AND ThanaID=" + nThana + "";
            }
            if (nDistrictID != -1)
            {
                sSql = sSql + " AND DistrictID=" + nDistrictID + "";
            }

            if (sChannelDescription != "<All>")
            {
                sSql = sSql + " AND ChannelDescription like '%" + sChannelDescription + "%'";
            }
            if (sCompany != "<All>")
            {
                sSql = sSql + " AND Company like '%" + sCompany + "%'";
            }

            sSql = sSql + " Order by TranNo,TranDate";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ShipmentVehicle _oShipmentVehicle = new ShipmentVehicle();
                    _oShipmentVehicle.Company = reader["Company"].ToString();
                    _oShipmentVehicle.TType = reader["TranType"].ToString();
                    _oShipmentVehicle.TranID = int.Parse(reader["TranID"].ToString());
                    _oShipmentVehicle.TranNo = reader["TranNo"].ToString();
                    _oShipmentVehicle.TranDate = Convert.ToDateTime(reader["TranDate"]);
                    _oShipmentVehicle.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _oShipmentVehicle.CustomerCode = reader["CustomerCode"].ToString();
                    _oShipmentVehicle.CustomerName = reader["CustomerName"].ToString();
                    _oShipmentVehicle.AreaName = reader["AreaName"].ToString();
                    _oShipmentVehicle.TerritoryName = reader["TerritoryName"].ToString();
                    _oShipmentVehicle.DistrictName = reader["DistrictName"].ToString();
                    _oShipmentVehicle.ThanaName = reader["ThanaName"].ToString();
                    _oShipmentVehicle.Channel = reader["ChannelDescription"].ToString();
                    if (reader["StockPrice"] != DBNull.Value)
                        _oShipmentVehicle.TranAmount = Convert.ToDouble(reader["StockPrice"]);
                    else _oShipmentVehicle.TranAmount = 0;

                    InnerList.Add(_oShipmentVehicle);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetLogDeliveryShipmentData(DateTime dFromDate, DateTime dToDate, string sTranNo, string sVehicleNo, int nVendor, string sCustomer, string sTranType, string sCompany, string sChannelDescription, int nArea, int nDistrictID, int nTerritoryID, int nThana, bool IsCheck,int nDeliveryMode,string sgatepassNo)
        {

            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";


            if (Utility.CompanyInfo == "TEL")
            {

                //sSql = "Select x.*,isnull(StockPrice,0) StockPrice From  " +
                //    "(  " +
                //    "Select VehicleCapacity,TranType, Company, Type, VendorID,isnull(VehicleID,-1) VehicleID, VehicleNo, TranID, TranNo, TranDate,  " +
                //    "a.CustomerID, CustomerCode, CustomerName, AreaID, AreaName, TerritoryID, TerritoryName,  " +
                //    "DistrictID, DistrictName, ThanaID, ThanaName, ChannelDescription, isnull(a.DeliveryMode,1) DeliveryMode, isnull(ParcelType,0) ParcelType,  " +
                //    "VendorName, VendorType, a.DutyTranID,GatePassNo,ShipmentDate From  " +
                //    "(  " +
                //    "Select isnull(VehicleCapacity,'N/A') VehicleCapacity,ShipmentDate,a.GatePassNo,1 as TranType, 'TEL' as Company, Type, a.VendorID, VendorName,  " +
                //    "VendorType, VehicleID, a.VehicleNo, a.TranID, DutyTranID,  " +
                //    "ParcelType, a.DeliveryMode, TranNo, TranDate, CustomerID  " +
                //    "From t_DutyVehicle a, t_LogDeliveryShipmentVendor b, t_ProductStockTran c, t_Showroom d  " +
                //    "where a.VendorID = b.VendorID and Type = 'Challan' and a.TranID = c.TranID and c.ToWHID = d.WarehouseID  " +
                //    "and a.TranID not in (Select TranID From t_LOGDeliveryShipmentItem where Company = 'TEL'  " +
                //    "and TranType = 'Challan')  " +
                //    "Union ALL  " +
                //    "Select isnull(VehicleCapacity,'N/A') VehicleCapacity,ShipmentDate,a.GatePassNo,2 as TranType, 'TEL' as Company, Type, a.VendorID, VendorName,  " +
                //    "VendorType, VehicleID, a.VehicleNo, TranID, DutyTranID,  " +
                //    "ParcelType, a.DeliveryMode, InvoiceNo as TranNo, InvoiceDate as TranDate,CustomerID  " +
                //    "From t_DutyVehicle a, t_LogDeliveryShipmentVendor b, t_SalesInvoice c  " +
                //    "where a.VendorID = b.VendorID and Type = 'Invoice' and a.TranID = c.InvoiceID  " +
                //    "and a.TranID not in (Select TranID From t_LOGDeliveryShipmentItem where Company = 'TEL'  " +
                //    "and TranType = 'Invoice')  " +
                //    ") A,v_CustomerDetails B  " +
                //    "where a.CustomerID = b.CustomerID  " +
                //    ") X  " +
                //    "Left Outer Join  " +
                //    "(  " +
                //    "Select TranType, TranID, DutyTranID, sum(StockPrice)StockPrice From  " +
                //    "(  " +
                //    "Select 1 as TranType, TranID, ProductID, sum(Qty * StockPrice) as StockPrice  " +
                //    "From t_ProductStockTranItem group by TranID, ProductID  " +
                //    "Union All  " +
                //    "Select 2 as TranType, InvoiceID, ProductID, sum(Quantity * UnitPrice) as StockPrice  " +
                //    "From t_SalesInvoiceDetail group by InvoiceID, ProductID  " +
                //    ") A,  " +
                //    "(  " +
                //    "Select a.DutyTranID, ProductID, RefID  " +
                //    "From t_DutyTranDetail a, t_DutyTran b  " +
                //    "where a.DutyTranID = b.DutyTranID  " +
                //    ") B  " +
                //    "where a.TranID = b.RefID and a.ProductID = b.ProductID  " +
                //    "group by TranType,TranID,DutyTranID  " +
                //    ") Y  " +
                //    "on x.TranID = y.TranID and x.TranType = y.TranType and x.DutyTranID = y.DutyTranID where 1=1";

                sSql = "Select x.*,isnull(StockPrice,0) StockPrice From   " +
                    "(     " +
                    "Select  WarehouseParentCode,  VehicleCapacity,TranType, Company, Type, VendorID,isnull(VehicleID,-1) VehicleID, VehicleNo, TranID, TranNo, TranDate,     " +
                    "a.CustomerID, CustomerCode, case when a.CustomerID=1125 then CustomerName+'['+WarehouseCode+']' else CustomerName end as CustomerName,    " +
                    "AreaID, AreaName, TerritoryID, TerritoryName,     " +
                    "DistrictID, DistrictName, b.ThanaID, ThanaName, ChannelDescription, isnull(a.DeliveryMode,1) DeliveryMode, isnull(ParcelType,0) ParcelType,     " +
                    "VendorName, VendorType, a.DutyTranID,GatePassNo,ShipmentDate From     " +
                    "(     " +
                    "Select f.WarehouseParentCode,ToWHID,isnull(VehicleCapacity,'N/A') VehicleCapacity,ShipmentDate,a.GatePassNo,1 as TranType, 'TEL' as Company, Type, a.VendorID, VendorName,     " +
                    "VendorType, VehicleID, a.VehicleNo, a.TranID, DutyTranID,     " +
                    "ParcelType, a.DeliveryMode, TranNo, TranDate,isnull(CustomerID,1125) CustomerID    " +
                    "From t_DutyVehicle a    " +
                    "inner join t_LogDeliveryShipmentVendor b  on a.VendorID = b.VendorID   " +
                    "inner join t_ProductStockTran c on a.TranID = c.TranID     " +
                    "Left Outer join    " +
                    "t_Showroom d  on c.ToWHID = d.WarehouseID Left Outer join   t_Warehouse e on c.FromWHID = e.WarehouseID Left Outer join   t_WarehouseParent f on e.WarehouseParentID = f.WarehouseParentID   " +
                    "where  Type = 'Challan'   " +
                    "and a.TranID not in (Select TranID From t_LOGDeliveryShipmentItem where Company = 'TEL'     " +
                    "and TranType = 'Challan')     " +
                    "Union ALL     " +
                    "Select e.WarehouseParentCode,c.WarehouseID,isnull(VehicleCapacity,'N/A') VehicleCapacity,ShipmentDate,a.GatePassNo,2 as TranType, 'TEL' as Company, Type, a.VendorID, VendorName,     " +
                    "VendorType, VehicleID, a.VehicleNo, TranID, DutyTranID,     " +
                    "ParcelType, a.DeliveryMode, InvoiceNo as TranNo, InvoiceDate as TranDate,CustomerID     " +
                    "From t_DutyVehicle a, t_LogDeliveryShipmentVendor b, t_SalesInvoice c,t_Warehouse d,t_WarehouseParent e     " +
                    "where a.VendorID = b.VendorID and Type = 'Invoice' and a.TranID = c.InvoiceID     " +
                    "and c.WarehouseID=d.WarehouseID and d.WarehouseParentID=e.WarehouseParentID and  a.TranID not in (Select TranID From t_LOGDeliveryShipmentItem where Company = 'TEL'     " +
                    "and TranType = 'Invoice')     " +
                    ") A,v_CustomerDetails B, t_Warehouse W    " +
                    "where a.CustomerID = b.CustomerID and  a.ToWHID=W.WarehouseID      " +
                    ") X     " +
                    "Left Outer Join     " +
                    "(     " +
                    "Select TranType, TranID, DutyTranID, sum(StockPrice)StockPrice From     " +
                    "(     " +
                    "Select 1 as TranType, TranID, ProductID, sum(Qty * StockPrice) as StockPrice     " +
                    "From t_ProductStockTranItem group by TranID, ProductID     " +
                    "Union All     " +
                    "Select 2 as TranType, InvoiceID, ProductID, sum(Quantity * UnitPrice) as StockPrice     " +
                    "From t_SalesInvoiceDetail group by InvoiceID, ProductID     " +
                    ") A,     " +
                    "(     " +
                    "Select a.DutyTranID, ProductID, RefID     " +
                    "From t_DutyTranDetail a, t_DutyTran b     " +
                    "where a.DutyTranID = b.DutyTranID     " +
                    ") B     " +
                    "where a.TranID = b.RefID and a.ProductID = b.ProductID     " +
                    "group by TranType,TranID,DutyTranID     " +
                    ") Y     " +
                    "on x.TranID = y.TranID and x.TranType = y.TranType and x.DutyTranID = y.DutyTranID where 1=1";
            }
            else if (Utility.CompanyInfo == "BLL")
            {

                sSql = "Select x.*,isnull(StockPrice,0) StockPrice From  " +
                    "(  " +
                    "Select VehicleCapacity,TranType, Company, Type, VendorID, isnull(VehicleID,-1) VehicleID, VehicleNo, TranID, TranNo, TranDate,  " +
                    "a.CustomerID, CustomerCode, CustomerName, AreaID, AreaName, TerritoryID, TerritoryName,  " +
                    "DistrictID, DistrictName, ThanaID, ThanaName, ChannelDescription, isnull(a.DeliveryMode,1) DeliveryMode, isnull(ParcelType,0) ParcelType,  " +
                    "VendorName, VendorType, a.DutyTranID,GatePassNo,ShipmentDate From  " +
                    "(  " +
                    "Select isnull(VehicleCapacity,'N/A') VehicleCapacity,ShipmentDate,a.GatePassNo,2 as TranType, 'BLL' as Company, Type, a.VendorID, VendorName,  " +
                    "VendorType, VehicleID, a.VehicleNo, TranID, DutyTranID,  " +
                    "ParcelType, a.DeliveryMode, InvoiceNo as TranNo, InvoiceDate as TranDate,  " +
                    "CustomerID  " +
                    "From t_DutyVehicle a, t_LogDeliveryShipmentVendor b, t_SalesInvoice c  " +
                    "where a.VendorID = b.VendorID and Type = 'Invoice' and a.TranID = c.InvoiceID  " +
                    "and a.TranID not in (Select TranID From t_LOGDeliveryShipmentItem where Company = 'BLL'  " +
                    "and TranType = 'Invoice')  " +
                    ") A,v_CustomerDetails B  " +
                    "where a.CustomerID = b.CustomerID  " +
                    ") X  " +
                    "Left Outer Join  " +
                    "(  " +
                    "Select TranType, TranID, DutyTranID, sum(StockPrice)StockPrice From  " +
                    "(  " +
                    "Select 2 as TranType, InvoiceID as TranID, ProductID, sum(Quantity * UnitPrice) as StockPrice  " +
                    "From t_SalesInvoiceDetail group by InvoiceID, ProductID  " +
                    ") A,  " +
                    "(  " +
                    "Select a.DutyTranID, ProductID, RefID  " +
                    "From t_DutyTranDetail a, t_DutyTran b  " +
                    "where a.DutyTranID = b.DutyTranID  " +
                    ") B  " +
                    "where a.TranID = b.RefID and a.ProductID = b.ProductID  " +
                    "group by TranType,TranID,DutyTranID  " +
                    ") Y  " +
                    "on x.TranID = y.TranID and x.TranType = y.TranType and x.DutyTranID = y.DutyTranID  where 1=1";
            }

            if (IsCheck == false)
            {
                sSql = sSql + " and ShipmentDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate<'" + dToDate + "' ";
            }
            if (sTranNo != "")
            {
                sSql = sSql + " AND TranNo like '%" + sTranNo + "%'";
            }
            if (sVehicleNo != "")
            {
                sSql = sSql + " AND VehicleNo like '%" + sVehicleNo + "%'";
            }
            if (nVendor != -1)
            {
                sSql = sSql + " AND VendorID=" + nVendor + "";
            }
            if (sCustomer != "")
            {
                sSql = sSql + " AND CustomerName like '%" + sCustomer + "%'";
            }
            if (sTranType != "<All>")
            {
                sSql = sSql + " AND Type like '%" + sTranType + "%'";
            }
            if (sCompany != "<All>")
            {
                sSql = sSql + " AND Company like '%" + sCompany + "%'";
            }
            if (sgatepassNo != "")
            {
                sSql = sSql + " AND GatePassNo like '%" + sgatepassNo + "%'";
            }
            if (sChannelDescription != "<All>")
            {
                sSql = sSql + " AND ChannelDescription like '%" + sChannelDescription + "%'";
            }
            if (nArea != -1)
            {
                sSql = sSql + " AND AreaID=" + nArea + "";
            }
            if (nDistrictID != -1)
            {
                sSql = sSql + " AND DistrictID=" + nDistrictID + "";
            }
            if (nTerritoryID != -1)
            {
                sSql = sSql + " AND TerritoryID=" + nTerritoryID + "";
            }
            if (nThana != -1)
            {
                sSql = sSql + " AND ThanaID=" + nThana + "";
            }
            if (nDeliveryMode != 0)
            {
                sSql = sSql + " AND DeliveryMode=" + nDeliveryMode + "";
            }
            sSql = sSql + " Order by TranNo,TranDate";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ShipmentVehicle _oShipmentVehicle = new ShipmentVehicle();
                    _oShipmentVehicle.Company = reader["Company"].ToString();
                    try
                    {
                        _oShipmentVehicle.FromWHName = reader["WarehouseParentCode"].ToString();
                    }
                    catch
                    {
                        _oShipmentVehicle.FromWHName = "";
                    }
                    _oShipmentVehicle.VehicleCapacity = reader["VehicleCapacity"].ToString();
                    
                    _oShipmentVehicle.TType = reader["Type"].ToString();
                    _oShipmentVehicle.VendorID = int.Parse(reader["VendorID"].ToString());
                    _oShipmentVehicle.VehicleID = int.Parse(reader["VehicleID"].ToString());
                    _oShipmentVehicle.VehicleNo = reader["VehicleNo"].ToString();
                    _oShipmentVehicle.TranID = int.Parse(reader["TranID"].ToString());
                    _oShipmentVehicle.TranNo = reader["TranNo"].ToString();
                    _oShipmentVehicle.TranDate = Convert.ToDateTime(reader["TranDate"]);
                    _oShipmentVehicle.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _oShipmentVehicle.CustomerCode = reader["CustomerCode"].ToString();
                    _oShipmentVehicle.CustomerName = reader["CustomerName"].ToString();
                    _oShipmentVehicle.AreaName = reader["AreaName"].ToString();
                    _oShipmentVehicle.TerritoryName = reader["TerritoryName"].ToString();
                    _oShipmentVehicle.DistrictName = reader["DistrictName"].ToString();
                    _oShipmentVehicle.ThanaName = reader["ThanaName"].ToString();
                    _oShipmentVehicle.Channel = reader["ChannelDescription"].ToString();
                    if (reader["StockPrice"] != DBNull.Value)
                        _oShipmentVehicle.TranAmount = Convert.ToDouble(reader["StockPrice"]);
                    else _oShipmentVehicle.TranAmount = 0;
                    _oShipmentVehicle.VendorName = reader["VendorName"].ToString();
                    _oShipmentVehicle.VendorType = int.Parse(reader["VendorType"].ToString());
                    _oShipmentVehicle.DeliveryMode = int.Parse(reader["DeliveryMode"].ToString());
                    _oShipmentVehicle.ParcelType = int.Parse(reader["ParcelType"].ToString());

                    if (reader["GatePassNo"] != DBNull.Value)
                        _oShipmentVehicle.GatePassNo = (reader["GatePassNo"].ToString());
                    else _oShipmentVehicle.GatePassNo = "";

                    InnerList.Add(_oShipmentVehicle);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetDutyvehicleData(DateTime dFromDate, DateTime dToDate, string sTranNo, bool IsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            string sSql = "";
            if (Utility.CompanyInfo == "TEL")
            {
                sSql = "Select * From  " +
                    "(  " +
                    "Select a.*,isnull(b.DutyTranID,0) As IsSet From   " +
                    "(Select * From   " +
                    "(  " +
                    "Select 'Challan' as Type,TranID,TranNo,TranDate,  " +
                    "DutyTranID,DutyTranNo,DutyTranDate,FromWHID,c.WarehouseName As FromWHName,   " +
                    "ToWHID,d.WarehouseName as ToWHName From t_ProductStockTran a,t_DutyTran b,t_Warehouse c,t_Warehouse d   " +
                    "where a.TranID=b.RefID and a.FromWHID=b.WHID and a.FromWHID=c.WarehouseID and a.ToWHID=d.WarehouseID   " +
                    "and TranDate>='01-Jan-2018'   " +
                    "and TranTypeID=3   " +
                    "Union All   " +
                    "Select 'Invoice' as Type,InvoiceID as TranID,InvoiceNo as TranNo,InvoiceDate as TranDate,   " +
                    "DutyTranID,DutyTranNo,DutyTranDate,a.WarehouseID as FromWHID,   " +
                    "c.WarehouseName As FromWHName,   " +
                    "1 as ToWHID,'System Warehouse' as ToWHName    " +
                    "From t_SalesInvoice a,t_DutyTran b,t_Warehouse c   " +
                    "where a.InvoiceID=b.RefID and a.WarehouseID=b.WHID and a.WarehouseID=c.WarehouseID    " +
                    "and InvoiceDate>='01-Jan-2018'   " +
                    "and a.WarehouseID not in (Select WarehouseID from t_Showroom)   " +
                    "and InvoiceTypeID not in (6,7,8,9,10,11,12)  " +
                    ") x) a  " +
                    "Left Outer Join   " +
                    "(Select Type,TranID,DutyTranID From t_DutyVehicle) b  " +
                    "on a.Type=b.Type and a.TranID=b.TranID and a.DutyTranID=b.DutyTranID  " +
                    ") Main where IsSet=0";
            }
            else if (Utility.CompanyInfo == "BLL")
            {
                sSql = "Select * From  " +
                    "(  " +
                    "Select a.*,isnull(b.DutyTranID,0) As IsSet From   " +
                    "(  " +
                    "Select * From (Select 'Challan' as Type,TranID,TranNo,  " +
                    "TranDate,DutyTranID,DutyTranNo,DutyTranDate,FromWHID,c.WarehouseName As FromWHName,   " +
                    "ToWHID,d.WarehouseName as ToWHName From t_ProductStockTran a,t_DutyTran b,t_Warehouse c,t_Warehouse d   " +
                    "where a.TranID=b.RefID and a.FromWHID=b.WHID and a.FromWHID=c.WarehouseID and a.ToWHID=d.WarehouseID   " +
                    "and TranDate>='01-Jan-2018' and TranTypeID=3   " +
                    "Union All   " +
                    "Select 'Invoice' as Type,InvoiceID as TranID,InvoiceNo as TranNo,InvoiceDate as TranDate,   " +
                    "DutyTranID,DutyTranNo,DutyTranDate,a.WarehouseID as FromWHID,   " +
                    "c.WarehouseName As FromWHName,   " +
                    "1 as ToWHID,'System Warehouse' as ToWHName    " +
                    "From t_SalesInvoice a,t_DutyTran b,t_Warehouse c   " +
                    "where a.InvoiceID=b.RefID and a.WarehouseID=b.WHID and a.WarehouseID=c.WarehouseID    " +
                    "and InvoiceDate>='01-Jan-2018' and InvoiceTypeID not in (6,7,8,9,10,11,12)) x  " +
                    ") a   " +
                    "Left Outer Join   " +
                    "(Select Type,TranID,DutyTranID From t_DutyVehicle) b  " +
                    "on a.Type=b.Type and a.TranID=b.TranID and a.DutyTranID=b.DutyTranID  " +
                    ") Main where IsSet=0";
            }

            if (IsCheck == false)
            {
                sSql = sSql + " and TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate<'" + dToDate + "' ";
            }
            if (sTranNo != "")
            {
                sSql = sSql + " AND TranNo like '%" + sTranNo + "%'";
            }

            sSql = sSql + " Order by TranNo,TranDate";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ShipmentVehicle _oShipmentVehicle = new ShipmentVehicle();
                    _oShipmentVehicle.TType = reader["Type"].ToString();
                    _oShipmentVehicle.TranNo = reader["TranNo"].ToString();
                    _oShipmentVehicle.TranID = int.Parse(reader["TranID"].ToString());
                    _oShipmentVehicle.TranDate = Convert.ToDateTime(reader["TranDate"]);
                    _oShipmentVehicle.DutyTranID = int.Parse(reader["DutyTranID"].ToString());
                    _oShipmentVehicle.DutyTranNo = reader["DutyTranNo"].ToString();
                    _oShipmentVehicle.DutyTranDate = Convert.ToDateTime(reader["DutyTranDate"]);
                    _oShipmentVehicle.FromWHID = int.Parse(reader["FromWHID"].ToString());
                    _oShipmentVehicle.FromWHName = reader["FromWHName"].ToString();
                    _oShipmentVehicle.ToWHID = int.Parse(reader["ToWHID"].ToString());
                    _oShipmentVehicle.ToWHName = reader["ToWHName"].ToString();

                    InnerList.Add(_oShipmentVehicle);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetLogDeliveryShipmentList(DateTime dFromDate, DateTime dToDate, string sShipmentNo,string sGatePassNo, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select ShipmentID,ShipmentNo,ShipmentDate,GatePassNo,FreightCost,LocalDeliveryCost,CreateDate,CreateUserID,isnull(ParcelCost, 0) ParcelCost From t_LogDeliveryShipment where 1=1";

            }
            if (IsCheck == false)
            {
                sSql = sSql + " and ShipmentDate between '" + dFromDate + "' and '" + dToDate + "' and ShipmentDate<'" + dToDate + "' ";
            }
            if (sShipmentNo != "")
            {
                sSql = sSql + " AND ShipmentNo like '%" + sShipmentNo + "%'";
            }
            if (sGatePassNo != "")
            {
                sSql = sSql + " AND GatePassNo like '%" + sGatePassNo + "%'";
            }

            sSql = sSql + " Order by ShipmentID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ShipmentVehicle _oShipmentVehicle = new ShipmentVehicle();
                    _oShipmentVehicle.ShipmentID = int.Parse(reader["ShipmentID"].ToString());
                    _oShipmentVehicle.ShipmentNo = reader["ShipmentNo"].ToString();
                    _oShipmentVehicle.ShipmentDate = Convert.ToDateTime(reader["ShipmentDate"]);
                    _oShipmentVehicle.GatePassNo = reader["GatePassNo"].ToString();
                    _oShipmentVehicle.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    _oShipmentVehicle.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    _oShipmentVehicle.FreightCost = Convert.ToDouble(reader["FreightCost"]);
                    _oShipmentVehicle.LocalDeliveryCost = Convert.ToDouble(reader["LocalDeliveryCost"]);
                    _oShipmentVehicle.ParcelCost = Convert.ToDouble(reader["ParcelCost"]);

                    InnerList.Add(_oShipmentVehicle);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetGatePassDataNo(string sGatePassNo)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";
            {
                sSql = "Select * From  " +
                    "(  " +
                    "Select InvoiceNo as TranNo, a.CreateDate, GatePassNo,  " +
                    "VehicleNo, DeliveryPerson,DeliveryPersonContactNo, VendorName,isnull(VehicleCapacity,'N/A') VehicleCapacity  " +
                    "From t_DutyVehicle a, t_SalesInvoice b, t_LogDeliveryShipmentVendor c  " +
                    "where a.TranID = b.InvoiceID and Type = 'Invoice' and a.VendorID = c.VendorID  " +
                    "Union ALL  " +
                    "Select TranNo, a.CreateDate, GatePassNo,  " +
                    "VehicleNo, DeliveryPerson,DeliveryPersonContactNo, VendorName,isnull(VehicleCapacity,'N/A') VehicleCapacity  " +
                    "From t_DutyVehicle a, t_ProductStockTran b, t_LogDeliveryShipmentVendor c  " +
                    "where a.TranID = b.TranID and Type = 'Challan' and a.VendorID = c.VendorID  " +
                    ") X where GatePassNo = '" + sGatePassNo + "'";

            }

            sSql = sSql + " Order by TranNo";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ShipmentVehicle _oShipmentVehicle = new ShipmentVehicle();
                    
                    _oShipmentVehicle.TranNo = reader["TranNo"].ToString();
                    _oShipmentVehicle.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    _oShipmentVehicle.GatePassNo = reader["GatePassNo"].ToString();
                    _oShipmentVehicle.VehicleNo = reader["VehicleNo"].ToString();
                    _oShipmentVehicle.DeliveryPerson = reader["DeliveryPerson"].ToString();
                    _oShipmentVehicle.VendorName = reader["VendorName"].ToString();
                    _oShipmentVehicle.VehicleCapacity = reader["VehicleCapacity"].ToString();
                    _oShipmentVehicle.DeliveryPersonContactNo = reader["DeliveryPersonContactNo"].ToString();


                    InnerList.Add(_oShipmentVehicle);

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


    public class ShipmentRoute
    {
        private int _nRouteID;


        /// <summary>
        /// Get set property for RouteID
        /// </summary>
        public int RouteID
        {
            get { return _nRouteID; }
            set { _nRouteID = value; }
        }

    }

    public class ShipmentRoutes : CollectionBase
    {
        public ShipmentRoute this[int i]
        {
            get { return (ShipmentRoute)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ShipmentRoute oShipmentRoute)
        {
            InnerList.Add(oShipmentRoute);
        }

        public void Refersh()
        {

            InnerList.Clear();
            //dtTodate = dtTodate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT DISTINCT RouteID FROM t_ShipmentRoute";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ShipmentRoute _oShipmentRoute = new ShipmentRoute();
                    _oShipmentRoute.RouteID = (int)reader["RouteID"];
                    InnerList.Add(_oShipmentRoute);

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

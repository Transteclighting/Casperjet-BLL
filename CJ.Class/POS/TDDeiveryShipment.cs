// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Feb 20, 2018
// Time : 01:21 PM
// Description: Class for TDDeliveryShipmentItem.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class TDDeliveryShipmentItem
    {
        private int _nShipmentID;
        private string _sInvoiceNo;
        private int _nProductID;
        private int _nQty;
        private double _UnitPrice;
        private string _sDeliveryMode;
        private string _sVehicleNo;
        private string _sShipingAddress;
        private DateTime _dShipmentDate;
        private DateTime _dShipmentTime;
        private string _sInstallationRequired;
        private object _dInstallationDate;
        private object _dInstallationTime;
        private double _FreightCost;
        private string _sRemarks;
        private string _sProductName;
        private int _nWHID;
        private int _FloorNo;
        private double _DistanceKM;

        public int FloorNo
        {
            get { return _FloorNo; }
            set { _FloorNo = value; }
        }

        public double DistanceKM
        {
            get { return _DistanceKM; }
            set { _DistanceKM = value; }
        }

        private string _sShowroomCode;
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value.Trim(); }
        }
        private int _nInvoiceID;
        public int InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
        }

        private string _sConsumerName;
        public string ConsumerName
        {
            get { return _sConsumerName; }
            set { _sConsumerName = value.Trim(); }
        }
        private string _sEmail;
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value.Trim(); }
        }
        private DateTime _dInvoiceDate;
        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }
        private string _sAGName;
        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value.Trim(); }
        }
        private string _sASGName;
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value.Trim(); }
        }
        private string _sMAGName;
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value.Trim(); }
        }
        private string _sPGName;
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value.Trim(); }
        }
        private string _sProductSerialNo;
        public string ProductSerialNo
        {
            get { return _sProductSerialNo; }
            set { _sProductSerialNo = value.Trim(); }
        }


        public int WHID
        {
            get { return _nWHID; }
            set { _nWHID = value; }
        }

        private string _sContactNo;
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value.Trim(); }
        }
        private object _dtExpInstallationDate;
        public object ExpInstallationDate
        {
            get { return _dtExpInstallationDate; }
            set { _dtExpInstallationDate = value; }
        }
        private object _dtExpInstallationTime;
        public object ExpInstallationTime
        {
            get { return _dtExpInstallationTime; }
            set { _dtExpInstallationTime = value; }
        }
        //private DateTime _dtHDCompletionDate;
        //public DateTime HDCompletionDate
        //{
        //    get { return _dtHDCompletionDate; }
        //    set { _dtHDCompletionDate = value; }
        //}
        //private DateTime _dtHDCompletionTime;
        //public DateTime HDCompletionTime
        //{
        //    get { return _dtHDCompletionTime; }
        //    set { _dtHDCompletionTime = value; }
        //}
        private object _dtHDCompletionDate;
        public object HDCompletionDate
        {
            get { return _dtHDCompletionDate; }
            set { _dtHDCompletionDate = value; }
        }
        private object _dtHDCompletionTime;
        public object HDCompletionTime
        {
            get { return _dtHDCompletionTime; }
            set { _dtHDCompletionTime = value; }
        }
        private string _sIsSafelyDelivered;
        public string IsSafelyDelivered
        {
            get { return _sIsSafelyDelivered; }
            set { _sIsSafelyDelivered = value.Trim(); }
        }
        private string _sReason;
        public string Reason
        {
            get { return _sReason; }
            set { _sReason = value.Trim(); }
        }
        private string _sActionTaken;
        public string ActionTaken
        {
            get { return _sActionTaken; }
            set { _sActionTaken = value.Trim(); }
        }
        private string _sJobNo;
        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value.Trim(); }
        }
        private string _sIsProperlyInstalled;
        public string IsProperlyInstalled
        {
            get { return _sIsProperlyInstalled; }
            set { _sIsProperlyInstalled = value.Trim(); }
        }
        private string _sCSDReason;
        public string CSDReason
        {
            get { return _sCSDReason; }
            set { _sCSDReason = value.Trim(); }
        }
        private string _sCSDRemarks;
        public string CSDRemarks
        {
            get { return _sCSDRemarks; }
            set { _sCSDRemarks = value.Trim(); }
        }

        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }
        private string _sProductCode;
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
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
        // Get set property for InvoiceNo
        // </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }

        // <summary>
        // Get set property for ProductID
        // </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        // <summary>
        // Get set property for Qty
        // </summary>
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        // <summary>
        // Get set property for UnitPrice
        // </summary>
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        // <summary>
        // Get set property for DeliveryMode
        // </summary>
        public string DeliveryMode
        {
            get { return _sDeliveryMode; }
            set { _sDeliveryMode = value.Trim(); }
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
        // Get set property for ShipingAddress
        // </summary>
        public string ShipingAddress
        {
            get { return _sShipingAddress; }
            set { _sShipingAddress = value.Trim(); }
        }

        // <summary>
        // Get set property for ShipmentDate
        // </summary>
        public DateTime ShipmentDate
        {
            get { return _dShipmentDate; }
            set { _dShipmentDate = value; }
        }

        // <summary>
        // Get set property for ShipmentTime
        // </summary>
        public DateTime ShipmentTime
        {
            get { return _dShipmentTime; }
            set { _dShipmentTime = value; }
        }

        // <summary>
        // Get set property for InstallationRequired
        // </summary>
        public string InstallationRequired
        {
            get { return _sInstallationRequired; }
            set { _sInstallationRequired = value; }
        }

        // <summary>
        // Get set property for InstallationDate
        // </summary>
        public object InstallationDate
        {
            get { return _dInstallationDate; }
            set { _dInstallationDate = value; }
        }

        // <summary>
        // Get set property for InstallationTime
        // </summary>
        public object InstallationTime
        {
            get { return _dInstallationTime; }
            set { _dInstallationTime = value; }
        }

        // <summary>
        // Get set property for FreightCost
        // </summary>
        public double FreightCost
        {
            get { return _FreightCost; }
            set { _FreightCost = value; }
        }
        private double _LiftingCost;
        public double LiftingCost
        {
            get { return _LiftingCost; }
            set { _LiftingCost = value; }
        }


        private double _ApprovedFreightCost;
        public double ApprovedFreightCost
        {
            get { return _ApprovedFreightCost; }
            set { _ApprovedFreightCost = value; }
        }
        
        private double _ApprovedLiftingCost;
        public double ApprovedLiftingCost
        {
            get { return _ApprovedLiftingCost; }
            set { _ApprovedLiftingCost = value; }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        private DateTime _dUpdateDate;
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        public void Add(int nType)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_TDDeliveryShipmentItem (ShipmentID, ProductID, UnitPrice, Qty, ShipmentDate, ShipmentTime, ShipingAddress, ContactNo, InstallationRequired, ExpInstallationDate, ExpInstallationTime, DeliveryMode, VehicleNo, FreightCost, HDCompletionDate, HDCompletionTime, IsSafelyDelivered, Reason, ActionTaken, Remarks, JobNo, InstallationDate, InstallationTime, IsProperlyInstalled, CSDReason, CSDRemarks, WHID, LiftingCost,ApprovedLiftingCost, ApprovedFreightCost,DistanceKM,FloorNo) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("ShipmentDate", _dShipmentDate);
                cmd.Parameters.AddWithValue("ShipmentTime", _dShipmentTime);
                cmd.Parameters.AddWithValue("ShipingAddress", _sShipingAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("InstallationRequired", _sInstallationRequired);
                if (_sInstallationRequired == "Yes")
                {
                    cmd.Parameters.AddWithValue("ExpInstallationDate", _dtExpInstallationDate);
                    cmd.Parameters.AddWithValue("ExpInstallationTime", _dtExpInstallationTime);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ExpInstallationDate", null);
                    cmd.Parameters.AddWithValue("ExpInstallationTime", null);
                }
                cmd.Parameters.AddWithValue("DeliveryMode", _sDeliveryMode);
                if (_sVehicleNo != null)
                {
                    cmd.Parameters.AddWithValue("VehicleNo", _sVehicleNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("VehicleNo", null);
                }

                cmd.Parameters.AddWithValue("FreightCost", _FreightCost);

                if (nType == (int)Dictionary.TDDeliveryShipmentStatus.Processing_Delivery|| nType == (int)Dictionary.TDDeliveryShipmentStatus.Undelivered)
                {
                    cmd.Parameters.AddWithValue("HDCompletionDate", null);
                    cmd.Parameters.AddWithValue("HDCompletionTime", null);
                    cmd.Parameters.AddWithValue("IsSafelyDelivered", null);
                    cmd.Parameters.AddWithValue("Reason", null);
                    cmd.Parameters.AddWithValue("ActionTaken", null);
                    cmd.Parameters.AddWithValue("Remarks", null);
                    cmd.Parameters.AddWithValue("JobNo", null);
                    cmd.Parameters.AddWithValue("InstallationDate", null);
                    cmd.Parameters.AddWithValue("InstallationTime", null);
                    cmd.Parameters.AddWithValue("IsProperlyInstalled", null);
                    cmd.Parameters.AddWithValue("CSDReason", null);
                    cmd.Parameters.AddWithValue("CSDRemarks", null);

                }
                else if (nType == (int)Dictionary.TDDeliveryShipmentStatus.Delivered || nType == (int)Dictionary.TDDeliveryShipmentStatus.Bill_Approved)
                {

                    if (_dtHDCompletionDate == null)
                    {
                        cmd.Parameters.AddWithValue("HDCompletionDate", null);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("HDCompletionDate", _dtHDCompletionDate);
                    }
                    if (_dtHDCompletionTime == null)
                    {
                        cmd.Parameters.AddWithValue("HDCompletionTime", null);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("HDCompletionTime", _dtHDCompletionTime);
                    }
                    if (_sIsSafelyDelivered != null)
                    {
                        cmd.Parameters.AddWithValue("IsSafelyDelivered", _sIsSafelyDelivered);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("IsSafelyDelivered", null);
                    }
                    if (_sReason != null)
                    {
                        cmd.Parameters.AddWithValue("Reason", _sReason);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Reason", null);
                    }
                    if (_sActionTaken != null)
                    {
                        cmd.Parameters.AddWithValue("ActionTaken", _sActionTaken);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("ActionTaken", null);
                    }
                    if (_sRemarks != null)
                    {
                        cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Remarks", null);
                    }
                    if (_sJobNo != null)
                    {
                        cmd.Parameters.AddWithValue("JobNo", _sJobNo);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("JobNo", null);
                    }


                    if (_dInstallationDate == null)
                    {
                        cmd.Parameters.AddWithValue("InstallationDate", null);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("InstallationDate", _dInstallationDate);
                    }
                    if (_dInstallationTime == null)
                    {
                        cmd.Parameters.AddWithValue("InstallationTime", null);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("InstallationTime", _dInstallationTime);
                    }

                    if (_sIsProperlyInstalled != null)
                    {
                        cmd.Parameters.AddWithValue("IsProperlyInstalled", _sIsProperlyInstalled);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("IsProperlyInstalled", null);
                    }
                    if (_sCSDReason != null)
                    {
                        cmd.Parameters.AddWithValue("CSDReason", _sCSDReason);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("CSDReason", null);
                    }
                    if (_sCSDRemarks != null)
                    {
                        cmd.Parameters.AddWithValue("CSDRemarks", _sCSDRemarks);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("CSDRemarks", null);
                    }
                }
                cmd.Parameters.AddWithValue("WHID", _nWHID);
                cmd.Parameters.AddWithValue("LiftingCost", _LiftingCost);
                if (nType == (int)Dictionary.TDDeliveryShipmentStatus.Bill_Approved)
                {
                    cmd.Parameters.AddWithValue("ApprovedLiftingCost", _ApprovedLiftingCost);
                    cmd.Parameters.AddWithValue("ApprovedFreightCost", _ApprovedFreightCost);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ApprovedLiftingCost", null);
                    cmd.Parameters.AddWithValue("ApprovedFreightCost", null);
                }

                cmd.Parameters.AddWithValue("DistanceKM", _DistanceKM);
                cmd.Parameters.AddWithValue("FloorNo", _FloorNo);

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
                sSql = "UPDATE t_TDDeliveryShipmentItem SET InvoiceNo = ?, ProductID = ?, Qty = ?, UnitPrice = ?, DeliveryMode = ?, VehicleNo = ?, ShipingAddress = ?, ShipmentDate = ?, ShipmentTime = ?, InstallationRequired = ?, InstallationDate = ?, InstallationTime = ?, FreightCost = ?, Remarks = ? WHERE ShipmentID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("DeliveryMode", _sDeliveryMode);
                cmd.Parameters.AddWithValue("VehicleNo", _sVehicleNo);
                cmd.Parameters.AddWithValue("ShipingAddress", _sShipingAddress);
                cmd.Parameters.AddWithValue("ShipmentDate", _dShipmentDate);
                cmd.Parameters.AddWithValue("ShipmentTime", _dShipmentTime);
                cmd.Parameters.AddWithValue("InstallationRequired", _sInstallationRequired);
                cmd.Parameters.AddWithValue("InstallationDate", _dInstallationDate);
                cmd.Parameters.AddWithValue("InstallationTime", _dInstallationTime);
                cmd.Parameters.AddWithValue("FreightCost", _FreightCost);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete(int nShipmentID,int nWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_TDDeliveryShipmentItem WHERE [ShipmentID]=? and [WHID] = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ShipmentID", nShipmentID);
                cmd.Parameters.AddWithValue("WHID", nWHID);
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
                cmd.CommandText = "SELECT * FROM t_TDDeliveryShipmentItem where ShipmentID =?";
                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nShipmentID = (int)reader["ShipmentID"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _nProductID = (int)reader["ProductID"];
                    _nQty = (int)reader["Qty"];
                    _UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    _sDeliveryMode = (string)reader["DeliveryMode"];
                    _sVehicleNo = (string)reader["VehicleNo"];
                    _sShipingAddress = (string)reader["ShipingAddress"];
                    _dShipmentDate = Convert.ToDateTime(reader["ShipmentDate"].ToString());
                    _dShipmentTime = Convert.ToDateTime(reader["ShipmentTime"].ToString());
                    _sInstallationRequired = (string)reader["InstallationRequired"];
                    _dInstallationDate = Convert.ToDateTime(reader["InstallationDate"].ToString());
                    _dInstallationTime = Convert.ToDateTime(reader["InstallationTime"].ToString());
                    _FreightCost = Convert.ToDouble(reader["FreightCost"].ToString());
                    _sRemarks = (string)reader["Remarks"];
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

    public class TDDeliveryShipment : CollectionBase
    {
        public TDDeliveryShipmentItem this[int i]
        {
            get { return (TDDeliveryShipmentItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(TDDeliveryShipmentItem oTDDeliveryShipmentItem)
        {
            InnerList.Add(oTDDeliveryShipmentItem);
        }
        private int _nShipmentID;
        private int _nWHID;
        private string _sInvoiceNo;
        private string _sRemarks;
        private int _nStatus;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private DateTime _dUpdateDate;
        private int _nUpdateUserID;

        private string _sShowroomCode;
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value; }
        }
        private int _nThanaID;
        public int ThanaID
        {
            get { return _nThanaID; }
            set { _nThanaID = value; }
        }
        private string _sThanaName;
        public string ThanaName
        {
            get { return _sThanaName; }
            set { _sThanaName = value; }
        }
        private int _nDistrictID;
        public int DistrictID
        {
            get { return _nDistrictID; }
            set { _nDistrictID = value; }
        }
        private string _sDistrictName;
        public string DistrictName
        {
            get { return _sDistrictName; }
            set { _sDistrictName = value; }
        }
        private int _nTerritoryID;
        public int TerritoryID
        {
            get { return _nTerritoryID; }
            set { _nTerritoryID = value; }
        }
        private string _sTerritoryName;
        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value; }
        }
        private int _nAreaID;
        public int AreaID
        {
            get { return _nAreaID; }
            set { _nAreaID = value; }
        }
        private string _sAreaName;
        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value; }
        }
        private double _Discount;
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        private int _nSalesType;
        public int SalesType
        {
            get { return _nSalesType; }
            set { _nSalesType = value; }
        }
        private int _nIsHOShipment;
        public int IsHOShipment
        {
            get { return _nIsHOShipment; }
            set { _nIsHOShipment = value; }
        }



        private double _FreightCost;
        public double FreightCost
        {
            get { return _FreightCost; }
            set { _FreightCost = value; }
        }
        private double _LiftingCost;
        public double LiftingCost
        {
            get { return _LiftingCost; }
            set { _LiftingCost = value; }
        }


        private double _ApprovedFreightCost;
        public double ApprovedFreightCost
        {
            get { return _ApprovedFreightCost; }
            set { _ApprovedFreightCost = value; }
        }

        private double _ApprovedLiftingCost;
        public double ApprovedLiftingCost
        {
            get { return _ApprovedLiftingCost; }
            set { _ApprovedLiftingCost = value; }
        }


        private int _nInvoiceID;
        public int InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
        }
        private DateTime _dtInvoiceDate;
        public DateTime InvoiceDate
        {
            get { return _dtInvoiceDate; }
            set { _dtInvoiceDate = value; }
        }
        private double _InvoiceAmount;
        public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }
        private string _sConsumerCode;
        public string ConsumerCode
        {
            get { return _sConsumerCode; }
            set { _sConsumerCode = value.Trim(); }
        }
        private string _sConsumerName;
        public string ConsumerName
        {
            get { return _sConsumerName; }
            set { _sConsumerName = value.Trim(); }
        }
        private string _sAddress;
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value.Trim(); }
        }
        private string _sCellNo;
        public string CellNo
        {
            get { return _sCellNo; }
            set { _sCellNo = value.Trim(); }
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
        // Get set property for WHID
        // </summary>
        public int WHID
        {
            get { return _nWHID; }
            set { _nWHID = value; }
        }

        // <summary>
        // Get set property for InvoiceNo
        // </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        public void Add(int nID, int nType)
        {
            int nMaxShipmentID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ShipmentID]) FROM t_TDDeliveryShipment where WHID=" + _nWHID + "";
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
                if (nID == 0)
                {
                    _nShipmentID = nMaxShipmentID;
                }
                else
                {
                    _nShipmentID = nID;
                }


                sSql = "INSERT INTO t_TDDeliveryShipment (ShipmentID, WHID, InvoiceNo, Remarks, Status, CreateDate, CreateUserID, UpdateDate, UpdateUserID) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);
                cmd.Parameters.AddWithValue("WHID", _nWHID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                if (_sRemarks != null)
                {
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Remarks", null);
                }
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                if (nType == 1)
                {
                    cmd.Parameters.AddWithValue("UpdateDate", null);
                    cmd.Parameters.AddWithValue("UpdateUserID", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                    if (_nUpdateUserID != null)
                    {
                        cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("UpdateUserID", null);
                    }
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (TDDeliveryShipmentItem oItem in this)
                {
                    oItem.ShipmentID = _nShipmentID;
                    oItem.WHID = _nWHID;
                    oItem.Add(nType);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Edit(int nShipmentID,int nType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_TDDeliveryShipment SET Remarks = ?, Status = ?, UpdateDate = ?, UpdateUserID = ? WHERE ShipmentID = ? and WHID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);

                cmd.Parameters.AddWithValue("ShipmentID", nShipmentID);
                cmd.Parameters.AddWithValue("WHID", _nWHID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                int nCount = 0;
                foreach (TDDeliveryShipmentItem oItem in this)
                {
                    oItem.ShipmentID = nShipmentID;
                    oItem.WHID = _nWHID;
                    if (nCount == 0)
                    {
                        oItem.Delete(nShipmentID, _nWHID);
                    }
                    oItem.Add(nType);
                    nCount++;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditRT(int nShipmentID, int nType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_TDDeliveryShipment SET Remarks = ?, Status = ?, UpdateDate = ?, UpdateUserID = ? WHERE ShipmentID = ? and WHID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);

                cmd.Parameters.AddWithValue("ShipmentID", nShipmentID);
                cmd.Parameters.AddWithValue("WHID", _nWHID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                int nCount = 0;
                foreach (TDDeliveryShipmentItem oItem in this)
                {
                    oItem.ShipmentID = nShipmentID;
                    oItem.WHID = _nWHID;
                    if (nCount == 0)
                    {
                        oItem.Delete(nShipmentID, _nWHID);
                    }
                    oItem.Add(nType);
                    nCount++;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void BillApproved(int nShipmentID, int nType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_TDDeliveryShipment SET Remarks = ?, Status = ?, ApprovedDate = ?, ApprovedBy = ? WHERE ShipmentID = ? and WHID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("ApprovedBy", Utility.UserId);

                cmd.Parameters.AddWithValue("ShipmentID", nShipmentID);
                cmd.Parameters.AddWithValue("WHID", _nWHID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                int nCount = 0;
                foreach (TDDeliveryShipmentItem oItem in this)
                {
                    oItem.ShipmentID = nShipmentID;
                    oItem.WHID = _nWHID;
                    if (nCount == 0)
                    {
                        oItem.Delete(nShipmentID, _nWHID);
                    }
                    oItem.Add(nType);
                    nCount++;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Delete(int nShipmentID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_TDDeliveryShipment WHERE [ShipmentID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ShipmentID", nShipmentID);
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
                cmd.CommandText = "SELECT * FROM t_TDDeliveryShipment where ShipmentID =?";
                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nShipmentID = (int)reader["ShipmentID"];
                    _nWHID = (int)reader["WHID"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _sRemarks = (string)reader["Remarks"];
                    _nStatus = (int)reader["Status"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
       
        public void RefreshDetail()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select ShipmentID,ProductID,UnitPrice,Qty,ShipmentDate,  " +
                        "ShipmentTime,ShipingAddress,ContactNo,InstallationRequired,  " +
                        "isnull(ExpInstallationDate,ShipmentDate) ExpInstallationDate,isnull(ExpInstallationTime, ShipmentTime) ExpInstallationTime,  " +
                        "DeliveryMode,isnull(VehicleNo,'') VehicleNo,isnull(FreightCost,0) FreightCost,  " +
                        "isnull(HDCompletionDate,ShipmentDate) HDCompletionDate,isnull(HDCompletionTime,ShipmentTime) HDCompletionTime,  " +
                        "isnull(IsSafelyDelivered,'') IsSafelyDelivered,isnull(Reason,'') Reason,isnull(ActionTaken,'') ActionTaken,  " +
                        "isnull(Remarks,'') Remarks,isnull(JobNo,'') JobNo,  " +
                        "InstallationDate,InstallationTime,isnull(IsProperlyInstalled,'') IsProperlyInstalled,isnull(CSDReason,'') CSDReason,  " +
                        "isnull(CSDRemarks,'') CSDRemarks,WHID,isnull(LiftingCost,0) LiftingCost,isnull(ApprovedLiftingCost,0) ApprovedLiftingCost,isnull(ApprovedFreightCost,0) ApprovedFreightCost,isnull(FloorNo,0) FloorNo,isnull(DistanceKM,0) DistanceKM  "+ 
                        "From t_TDDeliveryShipmentItem where ShipmentID=? and WHID=?";

            cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);
            cmd.Parameters.AddWithValue("WHID", _nWHID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDDeliveryShipmentItem oTDDeliveryShipmentItem = new TDDeliveryShipmentItem();
                    oTDDeliveryShipmentItem.ShipmentID = (int)reader["ShipmentID"];
                    oTDDeliveryShipmentItem.ProductID = (int)reader["ProductID"];
                    oTDDeliveryShipmentItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    oTDDeliveryShipmentItem.Qty = (int)reader["Qty"];
                    oTDDeliveryShipmentItem.ShipmentDate = Convert.ToDateTime(reader["ShipmentDate"].ToString());
                    oTDDeliveryShipmentItem.ShipmentTime = Convert.ToDateTime(reader["ShipmentTime"].ToString());
                    oTDDeliveryShipmentItem.ShipingAddress = (string)reader["ShipingAddress"];
                    oTDDeliveryShipmentItem.ContactNo = (string)reader["ContactNo"];
                    oTDDeliveryShipmentItem.InstallationRequired = (string)reader["InstallationRequired"];

                    oTDDeliveryShipmentItem.ExpInstallationDate = Convert.ToDateTime(reader["ExpInstallationDate"].ToString());
                    oTDDeliveryShipmentItem.ExpInstallationTime = Convert.ToDateTime(reader["ExpInstallationTime"].ToString());


                    oTDDeliveryShipmentItem.DeliveryMode = (string)reader["DeliveryMode"];
                    oTDDeliveryShipmentItem.VehicleNo = (string)reader["VehicleNo"];
                    oTDDeliveryShipmentItem.FreightCost = Convert.ToDouble(reader["FreightCost"].ToString());


                    oTDDeliveryShipmentItem.HDCompletionDate = Convert.ToDateTime(reader["HDCompletionDate"].ToString());
                    oTDDeliveryShipmentItem.HDCompletionTime = Convert.ToDateTime(reader["HDCompletionTime"].ToString());

                    oTDDeliveryShipmentItem.IsSafelyDelivered = (string)reader["IsSafelyDelivered"];
                    oTDDeliveryShipmentItem.Reason = (string)reader["Reason"];
                    oTDDeliveryShipmentItem.ActionTaken = (string)reader["ActionTaken"];
                    oTDDeliveryShipmentItem.Remarks = (string)reader["Remarks"];
                    oTDDeliveryShipmentItem.JobNo = (string)reader["JobNo"];

                    if (reader["InstallationDate"] != DBNull.Value)
                    {
                        oTDDeliveryShipmentItem.InstallationDate = Convert.ToDateTime(reader["InstallationDate"].ToString());

                    }
                    if (reader["InstallationTime"] != DBNull.Value)
                    {
                        oTDDeliveryShipmentItem.InstallationTime = Convert.ToDateTime(reader["InstallationTime"].ToString());
                    }

                    oTDDeliveryShipmentItem.IsProperlyInstalled = (string)reader["IsProperlyInstalled"];
                    oTDDeliveryShipmentItem.CSDReason = (string)reader["CSDReason"];
                    oTDDeliveryShipmentItem.CSDRemarks = (string)reader["CSDRemarks"];

                    oTDDeliveryShipmentItem.WHID = (int)reader["WHID"];
                    oTDDeliveryShipmentItem.LiftingCost = Convert.ToDouble(reader["LiftingCost"].ToString());
                    oTDDeliveryShipmentItem.ApprovedLiftingCost = Convert.ToDouble(reader["ApprovedLiftingCost"].ToString());
                    oTDDeliveryShipmentItem.ApprovedFreightCost = Convert.ToDouble(reader["ApprovedFreightCost"].ToString());
                    oTDDeliveryShipmentItem.FloorNo = Convert.ToInt32(reader["FloorNo"].ToString());
                    oTDDeliveryShipmentItem.DistanceKM = Convert.ToDouble(reader["DistanceKM"].ToString());

                    InnerList.Add(oTDDeliveryShipmentItem);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void DeleteShipmentData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_TDDeliveryShipment Where ShipmentID=? and WHID= ?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DutyTranID", _nShipmentID);
                cmd.Parameters.AddWithValue("WHID", _nWHID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Delete from  t_TDDeliveryShipmentItem Where ShipmentID=? and WHID= ?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);
                cmd.Parameters.AddWithValue("WHID", _nWHID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public bool IsHODelivery(int nShipmentID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select ShipmentID From t_TDDeliveryShipmentItem where DeliveryMode='Company Vehicle' and ShipmentID=" + nShipmentID + "";

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
            if (nCount == 0) return true;
            else return false;

        }

        public bool IsHODeliveryRT(int nShipmentID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select ShipmentID From t_TDDeliveryShipmentItem where WHID=" + Utility.WarehouseID + " and  DeliveryMode='Company Vehicle' and ShipmentID=" + nShipmentID + "";

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
            if (nCount == 0) return true;
            else return false;

        }

    }

    public class TDDeliveryShipments : CollectionBase
    {
        public TDDeliveryShipment this[int i]
        {
            get { return (TDDeliveryShipment)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(TDDeliveryShipment oTDDeliveryShipment)
        {
            InnerList.Add(oTDDeliveryShipment);
        }
        public int GetIndex(int nShipmentID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ShipmentID == nShipmentID)
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
            string sSql = "SELECT * FROM t_TDDeliveryShipment";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDDeliveryShipment oTDDeliveryShipment = new TDDeliveryShipment();
                    oTDDeliveryShipment.ShipmentID = (int)reader["ShipmentID"];
                    oTDDeliveryShipment.WHID = (int)reader["WHID"];
                    oTDDeliveryShipment.InvoiceNo = (string)reader["InvoiceNo"];
                    oTDDeliveryShipment.Remarks = (string)reader["Remarks"];
                    oTDDeliveryShipment.Status = (int)reader["Status"];
                    oTDDeliveryShipment.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oTDDeliveryShipment.CreateUserID = (int)reader["CreateUserID"];
                    oTDDeliveryShipment.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oTDDeliveryShipment.UpdateUserID = (int)reader["UpdateUserID"];
                    InnerList.Add(oTDDeliveryShipment);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(string sInvoiceNo, int nType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (nType == 1)
            {
                sSql = "Select -1 ShipmentID, InvoiceNo,a.ProductID,ProductCode,  " +
                    "ProductName,UnitPrice,Quantity as Qty,InvoiceDate ShipmentDate,getdate() ShipmentTime,  " +
                    "isnull(b.DeliveryAddress,d.Address) as ShipingAddress,CellNo as ContactNo,InvoiceDate ExpInstallationDate,  " +
                    "getdate() ExpInstallationTime,InstallationRequired=Case when MAGID in (23,791,792,25,0) then 'Yes' else 'No' end,   " +
                    "'Self Delivery' DeliveryMode,'' VehicleNo,0 FreightCost,0 LiftingCost,InvoiceDate HDCompletionDate,  " +
                    "getdate() HDCompletionTime,'Yes' IsSafelyDelivered,'' Reason,'' ActionTaken,Remarks,  " +
                    "'' JobNo,InvoiceDate InstallationDate,getdate() InstallationTime,'Yes' IsProperlyInstalled,  " +
                    "'' CSDReason,'' CSDRemarks  " +
                    "From t_SalesInvoiceDetail a,t_SalesInvoice b,v_productDetails c,t_RetailConsumer d    " +
                    "where a.ProductID=c.ProductID and a.InvoiceID=b.invoiceID and b.SundryCustomerID=d.ConsumerID  " +
                    "and IsBarcodeItem=1 and InvoiceNo='" + sInvoiceNo + "'";

            }
            else if (nType == 2)
            {
                sSql = "Select a.ShipmentID,InvoiceNo,b.ProductID,ProductCode,ProductName,UnitPrice,Qty,  " +
                    "ShipmentDate,ShipmentTime,ShipingAddress,ContactNo,isnull(ExpInstallationDate,  " +
                    "ShipmentDate) ExpInstallationDate,isnull(ExpInstallationTime,getdate()) ExpInstallationTime,   " +
                    "InstallationRequired,DeliveryMode,isnull(VehicleNo,'') VehicleNo,isnull(FreightCost,0) FreightCost,isnull(LiftingCost,0) LiftingCost,  " +
                    "isnull(HDCompletionDate, ShipmentDate) HDCompletionDate,  " +
                    "isnull(HDCompletionTime,getdate()) HDCompletionTime,   " +
                    "isnull(IsSafelyDelivered,'Yes') IsSafelyDelivered,isnull(Reason,'') Reason,  " +
                    "isnull(ActionTaken,'') ActionTaken,isnull(b.Remarks,'') Remarks,isnull(JobNo,'') JobNo,  " +
                    "isnull(InstallationDate,ShipmentDate) InstallationDate,  " +
                    "isnull(InstallationTime,getdate()) InstallationTime,   " +
                    "isnull(IsProperlyInstalled,'Yes') IsProperlyInstalled,isnull(CSDReason,'') CSDReason,  " +
                    "isnull(CSDRemarks,'') CSDRemarks    " +
                    "From dbo.t_TDDeliveryShipment a,dbo.t_TDDeliveryShipmentItem b,t_Product c   " +
                    "where a.ShipmentID=b.ShipmentID and b.ProductID=c.ProductID and InvoiceNo='" + sInvoiceNo + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDDeliveryShipmentItem oItem = new TDDeliveryShipmentItem();
                    oItem.ShipmentID = (int)reader["ShipmentID"];
                    oItem.InvoiceNo = (string)reader["InvoiceNo"];
                    oItem.ProductID = (int)reader["ProductID"];
                    oItem.ProductCode = (string)reader["ProductCode"];
                    oItem.ProductName = (string)reader["ProductName"];
                    oItem.UnitPrice = (double)reader["UnitPrice"];
                    oItem.Qty = Convert.ToInt32(reader["Qty"].ToString());
                    oItem.ShipmentDate = (DateTime)reader["ShipmentDate"];
                    oItem.ShipmentTime = (DateTime)reader["ShipmentTime"];
                    oItem.ShipingAddress = (string)reader["ShipingAddress"];
                    oItem.ContactNo = (string)reader["ContactNo"];
                    oItem.InstallationRequired = (string)reader["InstallationRequired"];
                    oItem.ExpInstallationDate = (DateTime)reader["ExpInstallationDate"];
                    oItem.ExpInstallationTime = (DateTime)reader["ExpInstallationTime"];
                    oItem.DeliveryMode = (string)reader["DeliveryMode"];
                    oItem.VehicleNo = (string)reader["VehicleNo"];
                    oItem.FreightCost = Convert.ToDouble(reader["FreightCost"].ToString());
                    oItem.LiftingCost = Convert.ToDouble(reader["LiftingCost"].ToString());
                    
                    oItem.HDCompletionDate = (DateTime)reader["HDCompletionDate"];
                    oItem.HDCompletionTime = (DateTime)reader["HDCompletionTime"];
                    oItem.IsSafelyDelivered = (string)reader["IsSafelyDelivered"];
                    oItem.Reason = (string)reader["Reason"];
                    oItem.ActionTaken = (string)reader["ActionTaken"];
                    oItem.Remarks = (string)reader["Remarks"];
                    oItem.JobNo = (string)reader["JobNo"];
                    oItem.InstallationDate = (DateTime)reader["InstallationDate"];
                    oItem.InstallationTime = (DateTime)reader["InstallationTime"];
                    oItem.IsProperlyInstalled = (string)reader["IsProperlyInstalled"];
                    oItem.CSDReason = (string)reader["CSDReason"];
                    oItem.CSDRemarks = (string)reader["CSDRemarks"];
                    InnerList.Add(oItem);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForRT(string sInvoiceNo, int nType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (nType == 1)
            {
                sSql = "Select -1 ShipmentID, InvoiceNo,a.ProductID,ProductCode,  " +
                    "ProductName,UnitPrice,Quantity as Qty,InvoiceDate ShipmentDate,getdate() ShipmentTime,  " +
                    "isnull(b.DeliveryAddress,d.Address) as ShipingAddress,CellNo as ContactNo,InvoiceDate ExpInstallationDate,  " +
                    "getdate() ExpInstallationTime,InstallationRequired=Case when MAGID in (23,791,792,25,0) then 'Yes' else 'No' end,   " +
                    "'Self Delivery' DeliveryMode,'' VehicleNo,0 FreightCost,0 LiftingCost,InvoiceDate HDCompletionDate,  " +
                    "getdate() HDCompletionTime,'Yes' IsSafelyDelivered,'' Reason,'' ActionTaken,Remarks,  " +
                    "'' JobNo,InvoiceDate InstallationDate,getdate() InstallationTime,'Yes' IsProperlyInstalled,  " +
                    "'' CSDReason,'' CSDRemarks  " +
                    "From t_SalesInvoiceDetail a,t_SalesInvoice b,v_productDetails c,t_RetailConsumer d    " +
                    "where a.ProductID=c.ProductID and a.InvoiceID=b.invoiceID and b.SundryCustomerID=d.ConsumerID and b.WarehouseID=d.WarehouseID  " +
                    "and IsBarcodeItem=1 and InvoiceNo='" + sInvoiceNo + "'";

            }
            else if (nType == 2)
            {
                sSql = "Select a.ShipmentID,InvoiceNo,b.ProductID,ProductCode,ProductName,UnitPrice,Qty,  " +
                    "ShipmentDate,ShipmentTime,ShipingAddress,ContactNo,isnull(ExpInstallationDate,  " +
                    "ShipmentDate) ExpInstallationDate,isnull(ExpInstallationTime,getdate()) ExpInstallationTime,   " +
                    "InstallationRequired,DeliveryMode,isnull(VehicleNo,'') VehicleNo,isnull(FreightCost,0) FreightCost,isnull(LiftingCost,0) LiftingCost,  " +
                    "isnull(HDCompletionDate, ShipmentDate) HDCompletionDate,  " +
                    "isnull(HDCompletionTime,getdate()) HDCompletionTime,   " +
                    "isnull(IsSafelyDelivered,'Yes') IsSafelyDelivered,isnull(Reason,'') Reason,  " +
                    "isnull(ActionTaken,'') ActionTaken,isnull(b.Remarks,'') Remarks,isnull(JobNo,'') JobNo,  " +
                    "isnull(InstallationDate,ShipmentDate) InstallationDate,  " +
                    "isnull(InstallationTime,getdate()) InstallationTime,   " +
                    "isnull(IsProperlyInstalled,'Yes') IsProperlyInstalled,isnull(CSDReason,'') CSDReason,  " +
                    "isnull(CSDRemarks,'') CSDRemarks    " +
                    "From dbo.t_TDDeliveryShipment a,dbo.t_TDDeliveryShipmentItem b,t_Product c   " +
                    "where a.ShipmentID=b.ShipmentID and a.WHID=b.WHID and b.ProductID=c.ProductID and InvoiceNo='" + sInvoiceNo + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDDeliveryShipmentItem oItem = new TDDeliveryShipmentItem();
                    oItem.ShipmentID = (int)reader["ShipmentID"];
                    oItem.InvoiceNo = (string)reader["InvoiceNo"];
                    oItem.ProductID = (int)reader["ProductID"];
                    oItem.ProductCode = (string)reader["ProductCode"];
                    oItem.ProductName = (string)reader["ProductName"];
                    oItem.UnitPrice = (double)reader["UnitPrice"];
                    oItem.Qty = Convert.ToInt32(reader["Qty"].ToString());
                    oItem.ShipmentDate = (DateTime)reader["ShipmentDate"];
                    oItem.ShipmentTime = (DateTime)reader["ShipmentTime"];
                    oItem.ShipingAddress = (string)reader["ShipingAddress"];
                    oItem.ContactNo = (string)reader["ContactNo"];
                    oItem.InstallationRequired = (string)reader["InstallationRequired"];
                    oItem.ExpInstallationDate = (DateTime)reader["ExpInstallationDate"];
                    oItem.ExpInstallationTime = (DateTime)reader["ExpInstallationTime"];
                    oItem.DeliveryMode = (string)reader["DeliveryMode"];
                    oItem.VehicleNo = (string)reader["VehicleNo"];
                    oItem.FreightCost = Convert.ToDouble(reader["FreightCost"].ToString());
                    oItem.LiftingCost = Convert.ToDouble(reader["LiftingCost"].ToString());

                    oItem.HDCompletionDate = (DateTime)reader["HDCompletionDate"];
                    oItem.HDCompletionTime = (DateTime)reader["HDCompletionTime"];
                    oItem.IsSafelyDelivered = (string)reader["IsSafelyDelivered"];
                    oItem.Reason = (string)reader["Reason"];
                    oItem.ActionTaken = (string)reader["ActionTaken"];
                    oItem.Remarks = (string)reader["Remarks"];
                    oItem.JobNo = (string)reader["JobNo"];
                    oItem.InstallationDate = (DateTime)reader["InstallationDate"];
                    oItem.InstallationTime = (DateTime)reader["InstallationTime"];
                    oItem.IsProperlyInstalled = (string)reader["IsProperlyInstalled"];
                    oItem.CSDReason = (string)reader["CSDReason"];
                    oItem.CSDRemarks = (string)reader["CSDRemarks"];
                    InnerList.Add(oItem);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetDataForUnDeliverd(string sInvoiceNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
                sSql = "Select -1 ShipmentID, InvoiceNo,a.ProductID,ProductCode,  " +
                    "ProductName,UnitPrice,Quantity as Qty,InvoiceDate ShipmentDate,getdate() ShipmentTime,  " +
                    "isnull(b.DeliveryAddress,d.Address) as ShipingAddress,CellNo as ContactNo,InvoiceDate ExpInstallationDate,  " +
                    "getdate() ExpInstallationTime,InstallationRequired=Case when MAGID in (23,791,792,25,0) then 'Yes' else 'No' end,   " +
                    "'Self Delivery' DeliveryMode,'' VehicleNo,0 FreightCost,0 LiftingCost,InvoiceDate HDCompletionDate,  " +
                    "getdate() HDCompletionTime,'Yes' IsSafelyDelivered,'' Reason,'' ActionTaken,Remarks,  " +
                    "'' JobNo,InvoiceDate InstallationDate,getdate() InstallationTime,'Yes' IsProperlyInstalled,  " +
                    "'' CSDReason,'' CSDRemarks,0 FloorNo,0 DistanceKM  " +
                    "From t_SalesInvoiceDetail a,t_SalesInvoice b,v_productDetails c,t_RetailConsumer d    " +
                    "where a.ProductID=c.ProductID and a.InvoiceID=b.invoiceID and b.SundryCustomerID=d.ConsumerID  " +
                    "and IsBarcodeItem=1 and InvoiceNo='" + sInvoiceNo + "'";

            

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDDeliveryShipmentItem oItem = new TDDeliveryShipmentItem();
                    oItem.ShipmentID = (int)reader["ShipmentID"];
                    oItem.ProductID = (int)reader["ProductID"];
                    oItem.ProductCode = (string)reader["ProductCode"];
                    oItem.ProductName = (string)reader["ProductName"];
                    oItem.UnitPrice = (double)reader["UnitPrice"];
                    oItem.Qty = Convert.ToInt32(reader["Qty"].ToString());
                    oItem.ShipmentDate = (DateTime)reader["ShipmentDate"];
                    oItem.ShipmentTime = (DateTime)reader["ShipmentTime"];
                    oItem.ShipingAddress = (string)reader["ShipingAddress"];
                    oItem.ContactNo = (string)reader["ContactNo"];
                    oItem.InstallationRequired = (string)reader["InstallationRequired"];
                    oItem.ExpInstallationDate = (DateTime)reader["ExpInstallationDate"];
                    oItem.ExpInstallationTime = (DateTime)reader["ExpInstallationTime"];
                    oItem.DeliveryMode = (string)reader["DeliveryMode"];
                    oItem.VehicleNo = (string)reader["VehicleNo"];
                    oItem.FreightCost = Convert.ToDouble(reader["FreightCost"].ToString());
                    oItem.LiftingCost = Convert.ToDouble(reader["LiftingCost"].ToString());
                    oItem.HDCompletionDate = (DateTime)reader["HDCompletionDate"];
                    oItem.HDCompletionTime = (DateTime)reader["HDCompletionTime"];
                    oItem.IsSafelyDelivered = (string)reader["IsSafelyDelivered"];
                    oItem.Reason = (string)reader["Reason"];
                    oItem.ActionTaken = (string)reader["ActionTaken"];
                    oItem.Remarks = (string)reader["Remarks"];
                    oItem.JobNo = (string)reader["JobNo"];
                    oItem.InstallationDate = (DateTime)reader["InstallationDate"];
                    oItem.InstallationTime = (DateTime)reader["InstallationTime"];
                    oItem.IsProperlyInstalled = (string)reader["IsProperlyInstalled"];
                    oItem.CSDReason = (string)reader["CSDReason"];
                    oItem.CSDRemarks = (string)reader["CSDRemarks"];

                    oItem.FloorNo = Convert.ToInt32(reader["FloorNo"].ToString());
                    oItem.DistanceKM = Convert.ToDouble(reader["DistanceKM"].ToString());

                    InnerList.Add(oItem);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetDataForUnDeliverdRT(string sInvoiceNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select -1 ShipmentID, InvoiceNo,a.ProductID,ProductCode,  " +
                "ProductName,UnitPrice,Quantity as Qty,InvoiceDate ShipmentDate,getdate() ShipmentTime,  " +
                "isnull(b.DeliveryAddress,d.Address) as ShipingAddress,CellNo as ContactNo,InvoiceDate ExpInstallationDate,  " +
                "getdate() ExpInstallationTime,InstallationRequired=Case when MAGID in (23,791,792,25,0) then 'Yes' else 'No' end,   " +
                "'Self Delivery' DeliveryMode,'' VehicleNo,0 FreightCost,0 LiftingCost,InvoiceDate HDCompletionDate,  " +
                "getdate() HDCompletionTime,'Yes' IsSafelyDelivered,'' Reason,'' ActionTaken,Remarks,  " +
                "'' JobNo,InvoiceDate InstallationDate,getdate() InstallationTime,'Yes' IsProperlyInstalled,  " +
                "'' CSDReason,'' CSDRemarks,0 FloorNo,0 DistanceKM  " +
                "From t_SalesInvoiceDetail a,t_SalesInvoice b,v_productDetails c,t_RetailConsumer d    " +
                "where b.WarehouseID=d.WarehouseID and a.ProductID=c.ProductID and a.InvoiceID=b.invoiceID and b.SundryCustomerID=d.ConsumerID  " +
                "and IsBarcodeItem=1 and InvoiceNo='" + sInvoiceNo + "'";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDDeliveryShipmentItem oItem = new TDDeliveryShipmentItem();
                    oItem.ShipmentID = (int)reader["ShipmentID"];
                    oItem.ProductID = (int)reader["ProductID"];
                    oItem.ProductCode = (string)reader["ProductCode"];
                    oItem.ProductName = (string)reader["ProductName"];
                    oItem.UnitPrice = (double)reader["UnitPrice"];
                    oItem.Qty = Convert.ToInt32(reader["Qty"].ToString());
                    oItem.ShipmentDate = (DateTime)reader["ShipmentDate"];
                    oItem.ShipmentTime = (DateTime)reader["ShipmentTime"];
                    oItem.ShipingAddress = (string)reader["ShipingAddress"];
                    oItem.ContactNo = (string)reader["ContactNo"];
                    oItem.InstallationRequired = (string)reader["InstallationRequired"];
                    oItem.ExpInstallationDate = (DateTime)reader["ExpInstallationDate"];
                    oItem.ExpInstallationTime = (DateTime)reader["ExpInstallationTime"];
                    oItem.DeliveryMode = (string)reader["DeliveryMode"];
                    oItem.VehicleNo = (string)reader["VehicleNo"];
                    oItem.FreightCost = Convert.ToDouble(reader["FreightCost"].ToString());
                    oItem.LiftingCost = Convert.ToDouble(reader["LiftingCost"].ToString());
                    oItem.HDCompletionDate = (DateTime)reader["HDCompletionDate"];
                    oItem.HDCompletionTime = (DateTime)reader["HDCompletionTime"];
                    oItem.IsSafelyDelivered = (string)reader["IsSafelyDelivered"];
                    oItem.Reason = (string)reader["Reason"];
                    oItem.ActionTaken = (string)reader["ActionTaken"];
                    oItem.Remarks = (string)reader["Remarks"];
                    oItem.JobNo = (string)reader["JobNo"];
                    oItem.InstallationDate = (DateTime)reader["InstallationDate"];
                    oItem.InstallationTime = (DateTime)reader["InstallationTime"];
                    oItem.IsProperlyInstalled = (string)reader["IsProperlyInstalled"];
                    oItem.CSDReason = (string)reader["CSDReason"];
                    oItem.CSDRemarks = (string)reader["CSDRemarks"];

                    oItem.FloorNo = Convert.ToInt32(reader["FloorNo"].ToString());
                    oItem.DistanceKM = Convert.ToDouble(reader["DistanceKM"].ToString());

                    InnerList.Add(oItem);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetTDMonthlyShipmentBill(string sInvoiceNo, DateTime DtFromDate, DateTime DtToDate,string sSalesType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DtToDate = DtToDate.AddDays(1);
            string sSql = "";
            {
                sSql = "Select * from  " +
                    "(  " +
                    "Select Case When SalesType = 1 then 'Retail'  " +
                    "When SalesType = 2 then 'B2C'  " +
                    "When SalesType = 3 then 'B2B'  " +
                    "When SalesType = 4 then 'HPA'  " +
                    "When SalesType = 5 then 'Dealer'  " +
                    "When SalesType = 6 then 'eStore'   " +
                    "else 'Other' end as SalesTypeName,  " +
                    "InvoiceID, a.InvoiceNo,  " +
                    "InvoiceDate, ProductCode, ProductName,Qty, b.DeliveryMode,  " +
                    "isnull(FreightCost, 0) FreightCost, isnull(LiftingCost, 0) LiftingCost,  " +
                    "isnull(ApprovedFreightCost, 0) ApprovedFreightCost, isnull(ApprovedLiftingCost, 0) ApprovedLiftingCost, isnull(b.Remarks, '') Remarks  " +
                    "From t_TDDeliveryShipment a, t_TDDeliveryShipmentItem b,  " +
                    "t_SalesInvoice c, v_ProductDetails d, t_RetailConsumer e  " +
                    "where a.ShipmentID = b.ShipmentID and a.WHID = b.WHID  " +
                    "and a.InvoiceNo = c.InvoiceNo and b.ProductID = d.ProductID  " +
                    "and b.DeliveryMode not in ('Company Vehicle') and c.SundryCustomerID = e.ConsumerID  " +
                    "and isnull(FreightCost, 0) + isnull(LiftingCost, 0) > 0  " +
                    "and InvoiceDate between '" + DtFromDate + "' and '" + DtToDate + "'  " +
                    "and InvoiceDate < '" + DtToDate + "'  " +
                    ") A where 1 = 1";
            }

            if (sInvoiceNo != "")
            {
                sSql = sSql + " AND InvoiceNo like '%" + sInvoiceNo + "%'";
            }
            if (sSalesType != "")
            {
                sSql = sSql + " AND SalesTypeName in (" + sSalesType.ToString() + ")";
            }
            sSql = sSql + " order by InvoiceID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;              
                IDataReader reader = cmd.ExecuteReader();               
                while (reader.Read())
                {
                    TDDeliveryShipmentItem oItem = new TDDeliveryShipmentItem();
                    oItem.InvoiceID = (int)reader["InvoiceID"];
                    oItem.ProductCode = (string)reader["ProductCode"];
                    oItem.ProductName = (string)reader["ProductName"];                   
                    oItem.InvoiceDate = (DateTime)reader["InvoiceDate"];
                    oItem.DeliveryMode = (string)reader["DeliveryMode"];
                    oItem.InvoiceNo = (string)reader["InvoiceNo"];
                    oItem.Qty = Convert.ToInt32(reader["Qty"].ToString());
                    oItem.FreightCost = Convert.ToDouble(reader["FreightCost"].ToString());
                    oItem.LiftingCost = Convert.ToDouble(reader["LiftingCost"].ToString());
                    oItem.ApprovedFreightCost = Convert.ToDouble(reader["ApprovedFreightCost"].ToString());
                    oItem.ApprovedLiftingCost= Convert.ToDouble(reader["ApprovedLiftingCost"].ToString());                   
                    oItem.Remarks = (string)reader["Remarks"];                    
                    InnerList.Add(oItem);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetTDMonthlyShipmentBillHO(string sInvoiceNo, DateTime DtFromDate, DateTime DtToDate,int nWHID,string sSalesType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            DtToDate = DtToDate.AddDays(1);
            string sSql = "";
            {
                sSql = "Select * From (Select a.*,isnull(SalesType, 1) SalesType, Case When SalesType = 1 then 'Retail' " +
                    "When SalesType = 2 then 'B2C' " +
                    "When SalesType = 3 then 'B2B' " +
                    "When SalesType = 4 then 'HPA' " +
                    "When SalesType = 5 then 'Dealer' " +
                    "When SalesType = 6 then 'eStore' " +
                    "else 'Other' end as SalesTypeName " +
                    "From " +
                    "( " +
                    "Select InvoiceID, a.InvoiceNo, InvoiceDate, ProductCode, ShipmentDate, ProductName, c.DeliveryMode, Qty,  " +
                    "SundryCustomerID, a.WHID,isnull(FreightCost,0) FreightCost, isnull(LiftingCost,0) LiftingCost,  "+
                    "isnull(ApprovedFreightCost,0) ApprovedFreightCost, isnull(ApprovedLiftingCost,0) ApprovedLiftingCost, isnull(c.Remarks,'') Remarks " +
                    "from t_TDDeliveryShipment a, t_SalesInvoice b, t_TDDeliveryShipmentItem c, v_ProductDetails d " +
                    "where a.InvoiceNo = b.InvoiceNo and a.ShipmentID = c.ShipmentID and a.WHID = c.WHID and c.ProductID = d.ProductID " +
                    "and b.InvoiceDate between '"+ DtFromDate + "' and '"+ DtToDate + "' " +
                    "and b.InvoiceDate < '"+ DtToDate + "' " +
                    ") a " +
                    "Left outer join " +
                    "( " +
                    "Select * From t_RetailConsumer " +
                    ") b " +
                    "on a.SundryCustomerID = b.ConsumerID and a.WHID = b.WarehouseID " +
                    ") Main where isnull(FreightCost,0) + isnull(LiftingCost,0) > 0";
            }

            if (sInvoiceNo != "")
            {
                sSql = sSql + " AND InvoiceNo like '%" + sInvoiceNo + "%'";
            }
            if(nWHID != -1)
            {
                sSql = sSql + " AND WHID=" + nWHID + "";
            }

            //if (nSalesType != -1)
            //{
            //    sSql = sSql + " AND SalesType=" + nSalesType + "";
            //}

            if (sSalesType != "")
            {
                sSql = sSql + " AND SalesTypeName in (" + sSalesType.ToString() + ")";
            }
            sSql = sSql + " order by InvoiceDate,WHID,InvoiceID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDDeliveryShipmentItem oItem = new TDDeliveryShipmentItem();
                    oItem.InvoiceID = (int)reader["InvoiceID"];
                    oItem.ProductCode = (string)reader["ProductCode"];
                    oItem.ProductName = (string)reader["ProductName"];
                    oItem.InvoiceDate = (DateTime)reader["InvoiceDate"];
                    oItem.DeliveryMode = (string)reader["DeliveryMode"];
                    oItem.InvoiceNo = (string)reader["InvoiceNo"];
                    oItem.Qty = (int)reader["Qty"];
                    oItem.FreightCost = Convert.ToDouble(reader["FreightCost"].ToString());
                    oItem.LiftingCost = Convert.ToDouble(reader["LiftingCost"].ToString());
                    oItem.ApprovedFreightCost = Convert.ToDouble(reader["ApprovedFreightCost"].ToString());
                    oItem.ApprovedLiftingCost = Convert.ToDouble(reader["ApprovedLiftingCost"].ToString());
                    oItem.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oItem);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void RefreshForHo(int nShipmentID,int nWHID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select ShipmentID,a.ProductID,ProductCode,ProductName, " +
                "UnitPrice,Qty,ShipmentDate,ShipmentTime,ShipingAddress,ContactNo, " +
                "InstallationRequired,isnull(ExpInstallationDate, getdate()) ExpInstallationDate, " +
                "isnull(ExpInstallationTime, getdate()) ExpInstallationTime, " +
                "DeliveryMode,isnull(VehicleNo, '') VehicleNo,isnull(FreightCost, 0) FreightCost, " +
                "isnull(LiftingCost, 0) LiftingCost,isnull(HDCompletionDate, getdate()) HDCompletionDate, " +
                "isnull(HDCompletionTime, getdate()) HDCompletionTime, " +
                "isnull(IsSafelyDelivered, 'Yes') IsSafelyDelivered,isnull(Reason, '') Reason, " +
                "isnull(ActionTaken, '') ActionTaken,isnull(Remarks, '') Remarks, " +
                "isnull(JobNo, '') JobNo,isnull(InstallationDate, getdate()) InstallationDate, " +
                "isnull(InstallationTime, getdate()) InstallationTime,isnull(IsProperlyInstalled, 'Yes') IsProperlyInstalled, " +
                "isnull(CSDReason, '') CSDReason,isnull(CSDRemarks, '') CSDRemarks,WHID,isnull(FloorNo,0) FloorNo,isnull(DistanceKM,0) DistanceKM " +
                "From t_TDDeliveryShipmentItem a, t_Product b " +
                "where ShipmentID = " + nShipmentID + " and a.ProductID = b.ProductID and WHID = " + nWHID + "";

            

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDDeliveryShipmentItem oItem = new TDDeliveryShipmentItem();
                    oItem.ShipmentID = (int)reader["ShipmentID"];
                    oItem.ProductID = (int)reader["ProductID"];
                    oItem.ProductCode = (string)reader["ProductCode"];
                    oItem.ProductName = (string)reader["ProductName"];
                    oItem.UnitPrice = (double)reader["UnitPrice"];
                    oItem.Qty = Convert.ToInt32(reader["Qty"].ToString());
                    oItem.ShipmentDate = (DateTime)reader["ShipmentDate"];
                    oItem.ShipmentTime = (DateTime)reader["ShipmentTime"];
                    oItem.ShipingAddress = (string)reader["ShipingAddress"];
                    oItem.ContactNo = (string)reader["ContactNo"];
                    oItem.InstallationRequired = (string)reader["InstallationRequired"];
                    oItem.ExpInstallationDate = (DateTime)reader["ExpInstallationDate"];
                    oItem.ExpInstallationTime = (DateTime)reader["ExpInstallationTime"];
                    oItem.DeliveryMode = (string)reader["DeliveryMode"];
                    oItem.VehicleNo = (string)reader["VehicleNo"];
                    oItem.FreightCost = Convert.ToDouble(reader["FreightCost"].ToString());
                    oItem.LiftingCost = Convert.ToDouble(reader["LiftingCost"].ToString());
                    oItem.HDCompletionDate = (DateTime)reader["HDCompletionDate"];
                    oItem.HDCompletionTime = (DateTime)reader["HDCompletionTime"];
                    oItem.IsSafelyDelivered = (string)reader["IsSafelyDelivered"];
                    oItem.Reason = (string)reader["Reason"];
                    oItem.ActionTaken = (string)reader["ActionTaken"];
                    oItem.Remarks = (string)reader["Remarks"];
                    oItem.JobNo = (string)reader["JobNo"];
                    oItem.InstallationDate = (DateTime)reader["InstallationDate"];
                    oItem.InstallationTime = (DateTime)reader["InstallationTime"];
                    oItem.IsProperlyInstalled = (string)reader["IsProperlyInstalled"];
                    oItem.CSDReason = (string)reader["CSDReason"];
                    oItem.CSDRemarks = (string)reader["CSDRemarks"];
                    oItem.FloorNo = Convert.ToInt32(reader["FloorNo"].ToString());
                    oItem.DistanceKM = Convert.ToDouble(reader["DistanceKM"].ToString());


                    InnerList.Add(oItem);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetAllInvoice(DateTime dFromDate, DateTime dToDate, int nStatus, string sInvoiceNo, string sMobile, string sCustomerName, string sAddress, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From  " +
                    "(Select a.*,isnull(ShipmentID,0) ShipmentID,isnull(Status,0) as Status,isnull(b.Remarks,'') Remarks From   " +
                    "(Select InvoiceID,InvoiceNo,InvoiceDate,WarehouseID,  " +
                    "InvoiceAmount,ConsumerCode,ConsumerName,Address,CellNo From t_SalesInvoice a,t_RetailConsumer b  " +
                    "where a.SundryCustomerID=b.ConsumerID) a  " +
                    "Left Outer Join   " +
                    "(Select * From t_TDDeliveryShipment) b  " +
                    "on a.InvoiceNo=b.InvoiceNo  " +
                    ") Main where 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sInvoiceNo != "")
            {
                sSql = sSql + " AND InvoiceNo like '%" + sInvoiceNo + "%'";
            }

            if (sMobile != "")
            {
                sSql = sSql + " AND CellNo like '%" + sMobile + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND ConsumerName like '%" + sCustomerName + "%'";
            }

            if (sAddress != "")
            {
                sSql = sSql + " AND Address like '%" + sAddress + "%'";
            }

            sSql = sSql + " Order by InvoiceID desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDDeliveryShipment oTDDeliveryShipment = new TDDeliveryShipment();
                    oTDDeliveryShipment.ShipmentID = int.Parse(reader["ShipmentID"].ToString());
                    oTDDeliveryShipment.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    oTDDeliveryShipment.InvoiceNo = (reader["InvoiceNo"].ToString());
                    oTDDeliveryShipment.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oTDDeliveryShipment.WHID = int.Parse(reader["WarehouseID"].ToString());
                    oTDDeliveryShipment.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    oTDDeliveryShipment.ConsumerCode = (reader["ConsumerCode"].ToString());
                    oTDDeliveryShipment.ConsumerName = (reader["ConsumerName"].ToString());
                    oTDDeliveryShipment.Address = (reader["Address"].ToString());
                    oTDDeliveryShipment.CellNo = (reader["CellNo"].ToString());
                    oTDDeliveryShipment.Status = int.Parse(reader["Status"].ToString());
                    oTDDeliveryShipment.Remarks = (reader["Remarks"].ToString());
                    InnerList.Add(oTDDeliveryShipment);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetInstallationItem(DateTime dFromDate, DateTime dToDate, DateTime dExpInstFromDate, DateTime dExpInstToDate, bool IsCheckInv, bool IsCheckInst, string sInvoiceNo, string sCustomerName,int nWHID, string sMobile,int nMAG,int nPG)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            dExpInstToDate = dExpInstToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select ShipmentDate,ShipmentTime,InstallationRequired,isnull(UnitPrice,0) UnitPrice, "+
                    "isnull(VehicleNo,'') VehicleNo,isnull(FreightCost,'') FreightCost, "+
                    "c.ShipmentID,a.WarehouseID,ShowroomCode,a.InvoiceID,a.InvoiceNo,ConsumerName,ShipingAddress, " +
                    "isnull(ContactNo,'') ContactNo,isnull(g.Email,'') Email,InvoiceDate, " +
                    "b.ProductID,ProductCode,ProductName,AGName, " +
                    "ASGName,MAGID,MAGName,PGID,PGName,ProductSerialNo,ExpInstallationDate, " +
                    "ExpInstallationTime,e.DeliveryMode,HDCompletionDate,HDCompletionTime, " +
                    "IsSafelyDelivered,isnull(Reason,'') Reason,isnull(ActionTaken,'') ActionTaken, " +
                    "isnull(JobNo,'') JobNo,InstallationDate,InstallationTime, " +
                    "isnull(IsProperlyInstalled,'') IsProperlyInstalled,isnull(CSDReason,'') CSDReason, " +
                    "isnull(CSDRemarks,'') CSDRemarks,isnull(e.Remarks,'') Remarks   " +
                    "From  " +
                    "t_SalesInvoice a,t_SalesInvoiceProductSerial b,t_TDDeliveryShipment c, " +
                    "t_Showroom d,t_TDDeliveryShipmentItem e,v_ProductDetails f,t_RetailConsumer g " +
                    "where a.InvoiceID=b.InvoiceID and a.InvoiceNo=c.InvoiceNo  " +
                    "and a.WarehouseID=d.WarehouseID and c.shipmentid=e.shipmentid and c.WHID=e.WHID  " +
                    "and b.productid=e.productid and b.productid=f.productid  " +
                    "and InstallationRequired='Yes' and a.SundryCustomerID=g.ConsumerID  " +
                    "and a.WarehouseID=g.WarehouseID";

            }

            if (IsCheckInv == false)
            {
                sSql = sSql + " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate<'" + dToDate + "' ";
            }
            if (IsCheckInst == false)
            {
                sSql = sSql + " and ExpInstallationDate between '" + dExpInstFromDate + "' and '" + dExpInstToDate + "' and ExpInstallationDate<'" + dExpInstToDate + "' ";
            }
            if (sInvoiceNo != "")
            {
                sSql = sSql + " AND a.InvoiceNo like '%" + sInvoiceNo + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND ConsumerName like '%" + sCustomerName + "%'";
            }
            if (nWHID != -1)
            {
                sSql = sSql + " AND a.WarehouseID=" + nWHID + "";
            }
            if (sMobile != "")
            {
                sSql = sSql + " AND ContactNo like '%" + sMobile + "%'";
            }
            if (nMAG != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAG + "";
            }

            if (nPG != -1)
            {
                sSql = sSql + " AND PGID=" + nPG + "";
            }

            //sSql = sSql + " Order by InvoiceID desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    TDDeliveryShipmentItem oTDDeliveryShipmentItem = new TDDeliveryShipmentItem();
                    oTDDeliveryShipmentItem.ShipmentID = (int)reader["ShipmentID"];
                    oTDDeliveryShipmentItem.WHID = (int)reader["WarehouseID"];
                    oTDDeliveryShipmentItem.ShowroomCode = (string)reader["ShowroomCode"];
                    oTDDeliveryShipmentItem.InvoiceID = (int)reader["InvoiceID"];
                    oTDDeliveryShipmentItem.InvoiceNo = (string)reader["InvoiceNo"];
                    oTDDeliveryShipmentItem.ConsumerName = (string)reader["ConsumerName"];
                    oTDDeliveryShipmentItem.ShipingAddress = (string)reader["ShipingAddress"];
                    oTDDeliveryShipmentItem.ContactNo = (string)reader["ContactNo"];
                    oTDDeliveryShipmentItem.Email = (string)reader["Email"];
                    oTDDeliveryShipmentItem.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oTDDeliveryShipmentItem.ProductID = (int)reader["ProductID"];
                    oTDDeliveryShipmentItem.ProductCode = (string)reader["ProductCode"];
                    oTDDeliveryShipmentItem.ProductName = (string)reader["ProductName"];
                    oTDDeliveryShipmentItem.AGName = (string)reader["AGName"];
                    oTDDeliveryShipmentItem.ASGName = (string)reader["ASGName"];
                    oTDDeliveryShipmentItem.MAGName = (string)reader["MAGName"];
                    oTDDeliveryShipmentItem.PGName = (string)reader["PGName"];
                    oTDDeliveryShipmentItem.ProductSerialNo = (string)reader["ProductSerialNo"];
                    if (reader["ExpInstallationDate"] != DBNull.Value)
                    {
                        oTDDeliveryShipmentItem.ExpInstallationDate = Convert.ToDateTime(reader["ExpInstallationDate"].ToString());
                    }
                    if (reader["ExpInstallationTime"] != DBNull.Value)
                    {
                        oTDDeliveryShipmentItem.ExpInstallationTime = Convert.ToDateTime(reader["ExpInstallationTime"].ToString());
                    }
                    oTDDeliveryShipmentItem.DeliveryMode = (string)reader["DeliveryMode"];

                    if (reader["HDCompletionDate"] != DBNull.Value)
                    {
                        oTDDeliveryShipmentItem.HDCompletionDate = Convert.ToDateTime(reader["HDCompletionDate"].ToString());
                    }
                    if (reader["HDCompletionTime"] != DBNull.Value)
                    {
                        oTDDeliveryShipmentItem.HDCompletionTime = Convert.ToDateTime(reader["HDCompletionTime"].ToString());
                    }
                    oTDDeliveryShipmentItem.IsSafelyDelivered = (string)reader["IsSafelyDelivered"];
                    oTDDeliveryShipmentItem.Reason = (string)reader["Reason"];
                    oTDDeliveryShipmentItem.ActionTaken = (string)reader["ActionTaken"];
                    oTDDeliveryShipmentItem.JobNo = (string)reader["JobNo"];
                    if (reader["InstallationDate"] != DBNull.Value)
                    {
                        oTDDeliveryShipmentItem.InstallationDate = Convert.ToDateTime(reader["InstallationDate"].ToString());

                    }
                    if (reader["InstallationTime"] != DBNull.Value)
                    {
                        oTDDeliveryShipmentItem.InstallationTime = Convert.ToDateTime(reader["InstallationTime"].ToString());
                    }
                    oTDDeliveryShipmentItem.IsProperlyInstalled = (string)reader["IsProperlyInstalled"];
                    oTDDeliveryShipmentItem.CSDReason = (string)reader["CSDReason"];
                    oTDDeliveryShipmentItem.CSDRemarks = (string)reader["CSDRemarks"];
                    oTDDeliveryShipmentItem.Remarks = (string)reader["Remarks"];
                    oTDDeliveryShipmentItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    oTDDeliveryShipmentItem.ShipmentDate = Convert.ToDateTime(reader["ShipmentDate"].ToString());
                    oTDDeliveryShipmentItem.ShipmentTime = Convert.ToDateTime(reader["ShipmentTime"].ToString());
                    oTDDeliveryShipmentItem.VehicleNo = (string)reader["VehicleNo"];
                    oTDDeliveryShipmentItem.FreightCost = Convert.ToDouble(reader["FreightCost"].ToString());

                    InnerList.Add(oTDDeliveryShipmentItem);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetTDShipmentDataHo(DateTime dFromDate, DateTime dToDate, int nSalesType, int nThana, int nDistrict, int nTerritory, int nArea, int IsHOShipment,string sShowroom, int nStatus,string sInvoiceNo, string sCustomerName, string sMobileNo,bool IsCheck)
        {
            
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From  " +
                    "(  " +
                    "Select a.*,case when b.ShipmentID is null then 0 else 1 end As IsHOShipment,  " +
                    "isnull(FreightCost, 0) FreightCost, isnull(LiftingCost, 0) LiftingCost,  " +
                    "isnull(ApprovedLiftingCost, 0) ApprovedLiftingCost, isnull(ApprovedFreightCost, 0) ApprovedFreightCost  " +
                    "From  " +
                    "(  " +
                    "Select ShipmentID, b.WarehouseID, ShowroomCode, d.ThanaID, ThanaName,  " +
                    "DistrictID, DistrictName, TerritoryID, TerritoryName, Areaid, AreaName,  " +
                    "InvoiceID, a.InvoiceNo, InvoiceDate, InvoiceAmount, Discount, a.CreateDate, CreateUserID,  " +
                    "'[' + ConsumerCode + '] ' + ConsumerName as ConsumerName,  " +
                    "e.CellNo,[Address] as CustomerAddress, a.Status, SalesType, isnull(a.Remarks, '') Remarks  " +
                    "From t_TDDeliveryShipment a, t_SalesInvoice b, t_Showroom c, v_CustomerDetails d, t_RetailConsumer e  " +
                    "where a.InvoiceNo = b.InvoiceNo and a.WHID = c.WarehouseID and c.CustomerID = d.CustomerID  " +
                    "and b.SundryCustomerID = e.ConsumerID and b.WarehouseID = e.WarehouseID  " +
                    ") a  " +
                    "Left Outer Join  " +
                    "(  " +
                    "Select distinct ShipmentID, WHID  " +
                    "From t_TDDeliveryShipmentItem where DeliveryMode in ('Company Vehicle')  " +
                    ") b  " +
                    "on a.ShipmentID = b.ShipmentID and a.WarehouseID = b.WHID  " +
                    "left Outer join  " +
                    "(  " +
                    "Select ShipmentID, WHID, sum(FreightCost) FreightCost,  " +
                    "sum(LiftingCost) LiftingCost, sum(ApprovedLiftingCost) ApprovedLiftingCost,  " +
                    "sum(ApprovedFreightCost) ApprovedFreightCost  " +
                    "From  " +
                    "(  " +
                    "Select ShipmentID, WHID, isnull(FreightCost, 0) FreightCost, isnull(LiftingCost, 0) LiftingCost,  " +
                    "isnull(ApprovedLiftingCost, 0) ApprovedLiftingCost, isnull(ApprovedFreightCost, 0) ApprovedFreightCost  " +
                    "From t_TDDeliveryShipmentItem  " +
                    ") a group by ShipmentID, WHID  " +
                    ") c  " +
                    "on a.ShipmentID = c.ShipmentID and a.WarehouseID = c.WHID  " +
                    ") Main where 1 = 1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate<'" + dToDate + "' ";
            }
            if (nSalesType != -1)
            {
                sSql = sSql + " AND SalesType=" + nSalesType + "";
            }
            if (nThana != -1)
            {
                sSql = sSql + " AND ThanaID=" + nThana + "";
            }
            if (nDistrict != -1)
            {
                sSql = sSql + " AND DistrictID=" + nDistrict + "";
            }
            if (nTerritory != -1)
            {
                sSql = sSql + " AND TerritoryID=" + nTerritory + "";
            }
            if (nArea != -1)
            {
                sSql = sSql + " AND AreaID=" + nArea + "";
            }

            if (IsHOShipment != -1)
            {
                sSql = sSql + " AND IsHOShipment=" + IsHOShipment + "";
            }
            if (sShowroom != "<All>")
            {
                sSql = sSql + " AND ShowroomCode='" + sShowroom + "'";
            }
            
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sInvoiceNo != "")
            {
                sSql = sSql + " AND InvoiceNo like '%" + sInvoiceNo + "%'";
            }

            if (sMobileNo != "")
            {
                sSql = sSql + " AND CellNo like '%" + sMobileNo + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND ConsumerName like '%" + sCustomerName + "%'";
            }

            sSql = sSql + " Order by InvoiceID desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
              

                while (reader.Read())
                {


                    TDDeliveryShipment oTDDeliveryShipment = new TDDeliveryShipment();
                    oTDDeliveryShipment.ShipmentID = int.Parse(reader["ShipmentID"].ToString());
                    oTDDeliveryShipment.WHID = int.Parse(reader["WarehouseID"].ToString());
                    oTDDeliveryShipment.ShowroomCode = (reader["ShowroomCode"].ToString());
                    oTDDeliveryShipment.ThanaID = int.Parse(reader["ThanaID"].ToString());
                    oTDDeliveryShipment.ThanaName = (reader["ThanaName"].ToString());
                    oTDDeliveryShipment.DistrictID = int.Parse(reader["DistrictID"].ToString());
                    oTDDeliveryShipment.DistrictName = (reader["DistrictName"].ToString());
                    oTDDeliveryShipment.TerritoryID = int.Parse(reader["TerritoryID"].ToString());
                    oTDDeliveryShipment.TerritoryName = (reader["TerritoryName"].ToString());
                    oTDDeliveryShipment.AreaID = int.Parse(reader["AreaID"].ToString());
                    oTDDeliveryShipment.AreaName = (reader["AreaName"].ToString());
                    oTDDeliveryShipment.InvoiceNo = (reader["InvoiceNo"].ToString());
                    oTDDeliveryShipment.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oTDDeliveryShipment.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    oTDDeliveryShipment.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    oTDDeliveryShipment.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    oTDDeliveryShipment.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oTDDeliveryShipment.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oTDDeliveryShipment.ConsumerName = (reader["ConsumerName"].ToString());
                    oTDDeliveryShipment.Address = (reader["CustomerAddress"].ToString());
                    oTDDeliveryShipment.CellNo = (reader["CellNo"].ToString());
                    oTDDeliveryShipment.Status = int.Parse(reader["Status"].ToString());
                    oTDDeliveryShipment.SalesType = int.Parse(reader["SalesType"].ToString());
                    oTDDeliveryShipment.IsHOShipment = int.Parse(reader["IsHOShipment"].ToString());
                    oTDDeliveryShipment.Remarks = (reader["Remarks"].ToString());

                    oTDDeliveryShipment.FreightCost = Convert.ToDouble(reader["FreightCost"].ToString());
                    oTDDeliveryShipment.LiftingCost = Convert.ToDouble(reader["LiftingCost"].ToString());
                    oTDDeliveryShipment.ApprovedFreightCost = Convert.ToDouble(reader["ApprovedFreightCost"].ToString());
                    oTDDeliveryShipment.ApprovedLiftingCost = Convert.ToDouble(reader["ApprovedLiftingCost"].ToString());

                    InnerList.Add(oTDDeliveryShipment);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetTDShipmentDataPOS(DateTime dFromDate, DateTime dToDate, int nStatus, string sInvoiceNo, string sMobile, string sCustomerName, string sAddress, int IsHOShipment, int nSalesType, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From  " +
                    "(  " +
                    "Select a.*,case when b.ShipmentID is null then 0 else 1 end As IsHOShipment,  " +
                    "isnull(FreightCost, 0) FreightCost, isnull(LiftingCost, 0) LiftingCost,  " +
                    "isnull(ApprovedLiftingCost, 0) ApprovedLiftingCost, isnull(ApprovedFreightCost, 0) ApprovedFreightCost  " +
                    "From  " +
                    "(  " +
                    "Select ShipmentID, b.WarehouseID, ShowroomCode, d.ThanaID, ThanaName,  " +
                    "DistrictID, DistrictName, TerritoryID, TerritoryName, Areaid, AreaName,  " +
                    "InvoiceID, a.InvoiceNo, InvoiceDate, InvoiceAmount, Discount, a.CreateDate, CreateUserID,  " +
                    "'[' + ConsumerCode + '] ' + ConsumerName as ConsumerName,  " +
                    "e.CellNo,[Address] as CustomerAddress, a.Status, SalesType, isnull(a.Remarks, '') Remarks  " +
                    "From t_TDDeliveryShipment a, t_SalesInvoice b, t_Showroom c, v_CustomerDetails d, t_RetailConsumer e  " +
                    "where a.InvoiceNo = b.InvoiceNo and a.WHID = c.WarehouseID and c.CustomerID = d.CustomerID  " +
                    "and b.SundryCustomerID = e.ConsumerID  " +
                    ") a  " +
                    "Left Outer Join  " +
                    "(  " +
                    "Select distinct ShipmentID, WHID  " +
                    "From t_TDDeliveryShipmentItem where DeliveryMode in ('Company Vehicle')  " +
                    ") b  " +
                    "on a.ShipmentID = b.ShipmentID and a.WarehouseID = b.WHID  " +
                    "left Outer join  " +
                    "(  " +
                    "Select ShipmentID, WHID, sum(FreightCost) FreightCost,  " +
                    "sum(LiftingCost) LiftingCost, sum(ApprovedLiftingCost) ApprovedLiftingCost,  " +
                    "sum(ApprovedFreightCost) ApprovedFreightCost  " +
                    "From  " +
                    "(  " +
                    "Select ShipmentID, WHID, isnull(FreightCost, 0) FreightCost, isnull(LiftingCost, 0) LiftingCost,  " +
                    "isnull(ApprovedLiftingCost, 0) ApprovedLiftingCost, isnull(ApprovedFreightCost, 0) ApprovedFreightCost  " +
                    "From t_TDDeliveryShipmentItem  " +
                    ") a group by ShipmentID, WHID  " +
                    ") c  " +
                    "on a.ShipmentID = c.ShipmentID and a.WarehouseID = c.WHID  " +
                    ") Main where 1 = 1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate<'" + dToDate + "' ";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sInvoiceNo != "")
            {
                sSql = sSql + " AND InvoiceNo like '%" + sInvoiceNo + "%'";
            }

            if (sMobile != "")
            {
                sSql = sSql + " AND CellNo like '%" + sMobile + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND ConsumerName like '%" + sCustomerName + "%'";
            }

            if (sAddress != "")
            {
                sSql = sSql + " AND CustomerAddress like '%" + sAddress + "%'";
            }
            if (nSalesType != -1)
            {
                sSql = sSql + " AND SalesType=" + nSalesType + "";
            }
            if (IsHOShipment != -1)
            {
                sSql = sSql + " AND IsHOShipment=" + IsHOShipment + "";
            }
            
            sSql = sSql + " Order by InvoiceNo desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDDeliveryShipment oTDDeliveryShipment = new TDDeliveryShipment();
                    oTDDeliveryShipment.ShipmentID = int.Parse(reader["ShipmentID"].ToString());
                    oTDDeliveryShipment.WHID = int.Parse(reader["WarehouseID"].ToString());
                    oTDDeliveryShipment.ShowroomCode = (reader["ShowroomCode"].ToString());
                    oTDDeliveryShipment.ThanaID = int.Parse(reader["ThanaID"].ToString());
                    oTDDeliveryShipment.ThanaName = (reader["ThanaName"].ToString());
                    oTDDeliveryShipment.DistrictID = int.Parse(reader["DistrictID"].ToString());
                    oTDDeliveryShipment.DistrictName = (reader["DistrictName"].ToString());
                    oTDDeliveryShipment.TerritoryID = int.Parse(reader["TerritoryID"].ToString());
                    oTDDeliveryShipment.TerritoryName = (reader["TerritoryName"].ToString());
                    oTDDeliveryShipment.AreaID = int.Parse(reader["AreaID"].ToString());
                    oTDDeliveryShipment.AreaName = (reader["AreaName"].ToString());
                    oTDDeliveryShipment.InvoiceNo = (reader["InvoiceNo"].ToString());
                    oTDDeliveryShipment.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oTDDeliveryShipment.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    oTDDeliveryShipment.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    oTDDeliveryShipment.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    oTDDeliveryShipment.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oTDDeliveryShipment.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oTDDeliveryShipment.ConsumerName = (reader["ConsumerName"].ToString());
                    oTDDeliveryShipment.Address = (reader["CustomerAddress"].ToString());
                    oTDDeliveryShipment.CellNo = (reader["CellNo"].ToString());
                    oTDDeliveryShipment.Status = int.Parse(reader["Status"].ToString());
                    oTDDeliveryShipment.SalesType = int.Parse(reader["SalesType"].ToString());
                    oTDDeliveryShipment.IsHOShipment = int.Parse(reader["IsHOShipment"].ToString());
                    oTDDeliveryShipment.Remarks = (reader["Remarks"].ToString());

                    oTDDeliveryShipment.FreightCost = Convert.ToDouble(reader["FreightCost"].ToString());
                    oTDDeliveryShipment.LiftingCost = Convert.ToDouble(reader["LiftingCost"].ToString());
                    oTDDeliveryShipment.ApprovedFreightCost = Convert.ToDouble(reader["ApprovedFreightCost"].ToString());
                    oTDDeliveryShipment.ApprovedLiftingCost = Convert.ToDouble(reader["ApprovedLiftingCost"].ToString());

                    InnerList.Add(oTDDeliveryShipment);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetTDShipmentDataPOSRT(DateTime dFromDate, DateTime dToDate, int nStatus, string sInvoiceNo, string sMobile, string sCustomerName, string sAddress, int IsHOShipment, int nSalesType, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From  " +
                    "(  " +
                    "Select a.*,case when b.ShipmentID is null then 0 else 1 end As IsHOShipment,  " +
                    "isnull(FreightCost, 0) FreightCost, isnull(LiftingCost, 0) LiftingCost,  " +
                    "isnull(ApprovedLiftingCost, 0) ApprovedLiftingCost, isnull(ApprovedFreightCost, 0) ApprovedFreightCost  " +
                    "From  " +
                    "(  " +
                    "Select ShipmentID, b.WarehouseID, ShowroomCode, d.ThanaID, ThanaName,  " +
                    "DistrictID, DistrictName, TerritoryID, TerritoryName, Areaid, AreaName,  " +
                    "InvoiceID, a.InvoiceNo, InvoiceDate, InvoiceAmount, Discount, a.CreateDate, CreateUserID,  " +
                    "'[' + ConsumerCode + '] ' + ConsumerName as ConsumerName,  " +
                    "e.CellNo,[Address] as CustomerAddress, a.Status, SalesType, isnull(a.Remarks, '') Remarks  " +
                    "From t_TDDeliveryShipment a, t_SalesInvoice b, t_Showroom c, v_CustomerDetails d, t_RetailConsumer e  " +
                    "where a.WHID=" + Utility.WarehouseID + " and a.InvoiceNo = b.InvoiceNo and a.WHID = c.WarehouseID and c.CustomerID = d.CustomerID  " +
                    "and b.SundryCustomerID = e.ConsumerID and b.WarehouseID=e.WarehouseID " +
                    ") a  " +
                    "Left Outer Join  " +
                    "(  " +
                    "Select distinct ShipmentID, WHID  " +
                    "From t_TDDeliveryShipmentItem where WHID=" + Utility.WarehouseID + " and DeliveryMode in ('Company Vehicle')  " +
                    ") b  " +
                    "on a.ShipmentID = b.ShipmentID and a.WarehouseID = b.WHID  " +
                    "left Outer join  " +
                    "(  " +
                    "Select ShipmentID, WHID, sum(FreightCost) FreightCost,  " +
                    "sum(LiftingCost) LiftingCost, sum(ApprovedLiftingCost) ApprovedLiftingCost,  " +
                    "sum(ApprovedFreightCost) ApprovedFreightCost  " +
                    "From  " +
                    "(  " +
                    "Select ShipmentID, WHID, isnull(FreightCost, 0) FreightCost, isnull(LiftingCost, 0) LiftingCost,  " +
                    "isnull(ApprovedLiftingCost, 0) ApprovedLiftingCost, isnull(ApprovedFreightCost, 0) ApprovedFreightCost  " +
                    "From t_TDDeliveryShipmentItem  where WHID=" + Utility.WarehouseID + " " +
                    ") a group by ShipmentID, WHID  " +
                    ") c  " +
                    "on a.ShipmentID = c.ShipmentID and a.WarehouseID = c.WHID  " +
                    ") Main where 1 = 1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate<'" + dToDate + "' ";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sInvoiceNo != "")
            {
                sSql = sSql + " AND InvoiceNo like '%" + sInvoiceNo + "%'";
            }

            if (sMobile != "")
            {
                sSql = sSql + " AND CellNo like '%" + sMobile + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND ConsumerName like '%" + sCustomerName + "%'";
            }

            if (sAddress != "")
            {
                sSql = sSql + " AND CustomerAddress like '%" + sAddress + "%'";
            }
            if (nSalesType != -1)
            {
                sSql = sSql + " AND SalesType=" + nSalesType + "";
            }
            if (IsHOShipment != -1)
            {
                sSql = sSql + " AND IsHOShipment=" + IsHOShipment + "";
            }

            sSql = sSql + " Order by InvoiceNo desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TDDeliveryShipment oTDDeliveryShipment = new TDDeliveryShipment();
                    oTDDeliveryShipment.ShipmentID = int.Parse(reader["ShipmentID"].ToString());
                    oTDDeliveryShipment.WHID = int.Parse(reader["WarehouseID"].ToString());
                    oTDDeliveryShipment.ShowroomCode = (reader["ShowroomCode"].ToString());
                    oTDDeliveryShipment.ThanaID = int.Parse(reader["ThanaID"].ToString());
                    oTDDeliveryShipment.ThanaName = (reader["ThanaName"].ToString());
                    oTDDeliveryShipment.DistrictID = int.Parse(reader["DistrictID"].ToString());
                    oTDDeliveryShipment.DistrictName = (reader["DistrictName"].ToString());
                    oTDDeliveryShipment.TerritoryID = int.Parse(reader["TerritoryID"].ToString());
                    oTDDeliveryShipment.TerritoryName = (reader["TerritoryName"].ToString());
                    oTDDeliveryShipment.AreaID = int.Parse(reader["AreaID"].ToString());
                    oTDDeliveryShipment.AreaName = (reader["AreaName"].ToString());
                    oTDDeliveryShipment.InvoiceNo = (reader["InvoiceNo"].ToString());
                    oTDDeliveryShipment.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oTDDeliveryShipment.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    oTDDeliveryShipment.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    oTDDeliveryShipment.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    oTDDeliveryShipment.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oTDDeliveryShipment.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oTDDeliveryShipment.ConsumerName = (reader["ConsumerName"].ToString());
                    oTDDeliveryShipment.Address = (reader["CustomerAddress"].ToString());
                    oTDDeliveryShipment.CellNo = (reader["CellNo"].ToString());
                    oTDDeliveryShipment.Status = int.Parse(reader["Status"].ToString());
                    oTDDeliveryShipment.SalesType = int.Parse(reader["SalesType"].ToString());
                    oTDDeliveryShipment.IsHOShipment = int.Parse(reader["IsHOShipment"].ToString());
                    oTDDeliveryShipment.Remarks = (reader["Remarks"].ToString());

                    oTDDeliveryShipment.FreightCost = Convert.ToDouble(reader["FreightCost"].ToString());
                    oTDDeliveryShipment.LiftingCost = Convert.ToDouble(reader["LiftingCost"].ToString());
                    oTDDeliveryShipment.ApprovedFreightCost = Convert.ToDouble(reader["ApprovedFreightCost"].ToString());
                    oTDDeliveryShipment.ApprovedLiftingCost = Convert.ToDouble(reader["ApprovedLiftingCost"].ToString());

                    InnerList.Add(oTDDeliveryShipment);

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





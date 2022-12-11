// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Sep 07, 2015
// Time : 03:36 PM
// Description: Class for SCMShipment.
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
    public class SCMShipmentItem
    {
        private int _nShipmentID;
        private int _nProductID;
        private int _nShipmentQty;
        private string _sProductCode;
        private string _sProductName;
        private int _nGRDQty;
        private double _CostPrice;
        private int _nBOMID;
        private string _sBOMDescription;

        // <summary>
        // Get set property for _sBOMDescription
        // </summary>
        public string BOMDescription
        {
            get { return _sBOMDescription; }
            set { _sBOMDescription = value.Trim(); }
        }

        // <summary>
        // Get set property for BOMID
        // </summary>
        public int BOMID
        {
            get { return _nBOMID; }
            set { _nBOMID = value; }
        }

        private int _nInventoryCategory;
        public int InventoryCategory
        {
            get { return _nInventoryCategory; }
            set { _nInventoryCategory = value; }
        }
        // <summary>
        // Get set property for GRDQty
        // </summary>
        public int GRDQty
        {
            get { return _nGRDQty; }
            set { _nGRDQty = value; }
        }


        // <summary>
        // Get set property for ShipmentID
        // </summary>
        public int ShipmentID
        {
            get { return _nShipmentID; }
            set { _nShipmentID = value; }
        }
        private int _nIsBarcodeItem;
        public int IsBarcodeItem
        {
            get { return _nIsBarcodeItem; }
            set { _nIsBarcodeItem = value; }
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
        // Get set property for ShipmentQty
        // </summary>
        public int ShipmentQty
        {
            get { return _nShipmentQty; }
            set { _nShipmentQty = value; }
        }

        // <summary>
        // Get set property for ProductCode
        // </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }

        // <summary>
        // Get set property for ProductName
        // </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }

        public double CostPrice
        {
            get { return _CostPrice; }
            set { _CostPrice = value; }
        }

        public void Add()
        {
            int nMaxShipmentID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ShipmentID]) FROM t_SCMShipmentItem";
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
                sSql = "INSERT INTO t_SCMShipmentItem (ShipmentID, ProductID, ShipmentQty) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ShipmentQty", _nShipmentQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertShipmentItem(int nShipmentID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "INSERT INTO t_SCMShipmentItem (ShipmentID, ProductID, ShipmentQty) VALUES(?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ShipmentID", nShipmentID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ShipmentQty", _nShipmentQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertBEILShipmentItem(int nShipmentID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "INSERT INTO t_SCMShipmentBOMItem (ShipmentID, ProductID, BOMID, ShipmentQty) VALUES(?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ShipmentID", nShipmentID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BOMID", _nBOMID);
                cmd.Parameters.AddWithValue("ShipmentQty", _nShipmentQty);

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
                sSql = "UPDATE t_SCMShipmentItem SET ProductID = ?, ShipmentQty = ? WHERE ShipmentID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ShipmentQty", _nShipmentQty);

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
                sSql = "DELETE FROM t_SCMShipmentItem WHERE [ShipmentID]=?";
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
                cmd.CommandText = "SELECT * FROM t_SCMShipmentItem where ShipmentID =?";
                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nShipmentID = (int)reader["ShipmentID"];
                    _nProductID = (int)reader["ProductID"];
                    _nShipmentQty = (int)reader["ShipmentQty"];
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
    public class SCMShipment : CollectionBase
    {
        public SCMShipmentItem this[int i]
        {
            get { return (SCMShipmentItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SCMShipmentItem oSCMShipmentItem)
        {
            InnerList.Add(oSCMShipmentItem);
        }

        private int _nShipmentID;
        private string _sShipmentNo;
        private int _nOrderID;
        private DateTime _dForwarderEngagementDate;
        private string _sForwarderName;
        private DateTime _dShipmentDate;
        private string _sInvoiceNo;
        private DateTime _dInvoiceDate;
        private int _nCurrency;
        private double _InvoiceAmount;
        private DateTime _dShipmentDocRcvbyBankDate;
        private string _sBLNo;
        private DateTime _dBLDate;
        private string _sContainerNo;
        private double _NetWeightKG;
        private double _GrossWeightKG;
        private double _MeasurementCBM;
        private int _nNoOfCarton;
        private string _sRemarks;
        private DateTime _dDateOfShippingRetireFromBank;
        private double _CrfValue;
        private DateTime _dDutyandTaxSubmittoFADate;
        private DateTime _dDutyPaidDate;
        private double _AssessableValue;
        private double _CD;
        private double _RD;
        private double _SD;
        private double _VAT;
        private double _AIT;
        private double _ATV;
        private double _PSI;
        private double _GlobalTax;
        private double _ServiceCharge;
        private double _BG;
        private double _Additional;
        private DateTime _dSupportingDocSubmitToFAForVATApproval;
        private DateTime _dReleaseDate;
        private DateTime _dReadyForGRDDate;
        private double _OceanFreightinBDT;
        private double _Demurrage;
        private double _Receivable;
        private double _MiscNonReceivable;
        private double _AdvancedAmount;
        private int _nStatus;

        private string _sPINo;
        private DateTime _dPIReceiveDate;
        private string _sOrderNo;
        private DateTime _dOrderPlaceDate;
        private string _sLCNo;
        private DateTime _dLCDate;
        private int _nPSIID;
        private string _sPSINo;
        private DateTime _dPSIDate;
        private int _nExpectedHOArrivalWeek;
        private int _nExpectedHOArrivalYear;
        private int _nCompanyID;
        private string _sCompanyName;
        private string _sStatusName;
        private int _nSupplierID;
        private string _sSupplierName;
        private int _nPIID;
        private int _nIsEqual;
        private string _sPINO;
        private string _sDescription;

        // <summary>
        // Get set property for Description
        // </summary>
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }


        // <summary>
        // Get set property for PSIDate
        // </summary>
        public DateTime PSIDate
        {
            get { return _dPSIDate; }
            set { _dPSIDate = value; }
        }

        // <summary>
        // Get set property for PIReceiveDate
        // </summary>
        public DateTime PIReceiveDate
        {
            get { return _dPIReceiveDate; }
            set { _dPIReceiveDate = value; }
        }

        // <summary>
        // Get set property for IsEqual
        // </summary> 
        public int IsEqual
        {
            get { return _nIsEqual; }
            set { _nIsEqual = value; }
        }

        // <summary>
        // Get set property for PIID
        // </summary> 
        public int PIID
        {
            get { return _nPIID; }
            set { _nPIID = value; }
        }
        // <summary>
        // Get set property for PINO
        // </summary>
        public string PINO
        {
            get { return _sPINO; }
            set { _sPINO = value.Trim(); }
        }




        // <summary>
        // Get set property for SupplierID
        // </summary> 
        public int SupplierID
        {
            get { return _nSupplierID; }
            set { _nSupplierID = value; }
        }

        // <summary>
        // Get set property for SupplierName
        // </summary>
        public string SupplierName
        {
            get { return _sSupplierName; }
            set { _sSupplierName = value.Trim(); }
        }


        // <summary>
        // Get set property for PINo
        // </summary>
        public string PINo
        {
            get { return _sPINo; }
            set { _sPINo = value.Trim(); }
        }


        // <summary>
        // Get set property for OrderNo
        // </summary>
        public string OrderNo
        {
            get { return _sOrderNo; }
            set { _sOrderNo = value.Trim(); }
        }

        // <summary>
        // Get set property for OrderPlaceDate
        // </summary>
        public DateTime OrderPlaceDate
        {
            get { return _dOrderPlaceDate; }
            set { _dOrderPlaceDate = value; }
        }

        // <summary>
        // Get set property for LCNo
        // </summary>
        public string LCNo
        {
            get { return _sLCNo; }
            set { _sLCNo = value.Trim(); }
        }

        // <summary>
        // Get set property for LCDate
        // </summary>
        public DateTime LCDate
        {
            get { return _dLCDate; }
            set { _dLCDate = value; }
        }


        // <summary>
        // Get set property for _nPSIID
        // </summary>
        public int PSIID
        {
            get { return _nPSIID; }
            set { _nPSIID = value; }
        }

        // <summary>
        // Get set property for PSINo
        // </summary>
        public string PSINo
        {
            get { return _sPSINo; }
            set { _sPSINo = value.Trim(); }
        }

        // <summary>
        // Get set property for ExpectedHOArrivalWeek
        // </summary>
        public int ExpectedHOArrivalWeek
        {
            get { return _nExpectedHOArrivalWeek; }
            set { _nExpectedHOArrivalWeek = value; }
        }

        // <summary>
        // Get set property for ExpectedHOArrivalYear
        // </summary>
        public int ExpectedHOArrivalYear
        {
            get { return _nExpectedHOArrivalYear; }
            set { _nExpectedHOArrivalYear = value; }
        }

        // <summary>
        // Get set property for CompanyID
        // </summary>
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }
        // <summary>
        // Get set property for CompanyName
        // </summary>
        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value.Trim(); }
        }

        // <summary>
        // Get set property for StatusName
        // </summary>
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value.Trim(); }
        }

        private string _sText;
        public string Text
        {
            get { return _sText; }
            set { _sText = value.Trim(); }
        }
        private string _sMobileNo;
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value.Trim(); }
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
        // Get set property for ShipmentNo
        // </summary>
        public string ShipmentNo
        {
            get { return _sShipmentNo; }
            set { _sShipmentNo = value.Trim(); }
        }


        // <summary>
        // Get set property for OrderID
        // </summary>
        public int OrderID
        {
            get { return _nOrderID; }
            set { _nOrderID = value; }
        }

        // <summary>
        // Get set property for ForwarderEngagementDate
        // </summary>
        public DateTime ForwarderEngagementDate
        {
            get { return _dForwarderEngagementDate; }
            set { _dForwarderEngagementDate = value; }
        }

        // <summary>
        // Get set property for ForwarderName
        // </summary>
        public string ForwarderName
        {
            get { return _sForwarderName; }
            set { _sForwarderName = value.Trim(); }
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
        // Get set property for InvoiceNo
        // </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }

        // <summary>
        // Get set property for InvoiceDate
        // </summary>
        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }

        // <summary>
        // Get set property for Currency
        // </summary>
        public int Currency
        {
            get { return _nCurrency; }
            set { _nCurrency = value; }
        }

        // <summary>
        // Get set property for InvoiceAmount
        // </summary>
        public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }

        // <summary>
        // Get set property for ShipmentDocRcvbyBankDate
        // </summary>
        public DateTime ShipmentDocRcvbyBankDate
        {
            get { return _dShipmentDocRcvbyBankDate; }
            set { _dShipmentDocRcvbyBankDate = value; }
        }

        // <summary>
        // Get set property for BLNo
        // </summary>
        public string BLNo
        {
            get { return _sBLNo; }
            set { _sBLNo = value.Trim(); }
        }

        // <summary>
        // Get set property for BLDate
        // </summary>
        public DateTime BLDate
        {
            get { return _dBLDate; }
            set { _dBLDate = value; }
        }

        // <summary>
        // Get set property for ContainerNo
        // </summary>
        public string ContainerNo
        {
            get { return _sContainerNo; }
            set { _sContainerNo = value.Trim(); }
        }

        // <summary>
        // Get set property for NetWeightKG
        // </summary>
        public double NetWeightKG
        {
            get { return _NetWeightKG; }
            set { _NetWeightKG = value; }
        }

        // <summary>
        // Get set property for GrossWeightKG
        // </summary>
        public double GrossWeightKG
        {
            get { return _GrossWeightKG; }
            set { _GrossWeightKG = value; }
        }

        // <summary>
        // Get set property for MeasurementCBM
        // </summary>
        public double MeasurementCBM
        {
            get { return _MeasurementCBM; }
            set { _MeasurementCBM = value; }
        }

        // <summary>
        // Get set property for NoOfCarton
        // </summary>
        public int NoOfCarton
        {
            get { return _nNoOfCarton; }
            set { _nNoOfCarton = value; }
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
        // Get set property for DateOfShippingRetireFromBank
        // </summary>
        public DateTime DateOfShippingRetireFromBank
        {
            get { return _dDateOfShippingRetireFromBank; }
            set { _dDateOfShippingRetireFromBank = value; }
        }

        // <summary>
        // Get set property for CrfValue
        // </summary>
        public double CrfValue
        {
            get { return _CrfValue; }
            set { _CrfValue = value; }
        }

        // <summary>
        // Get set property for DutyandTaxSubmittoFADate
        // </summary>
        public DateTime DutyandTaxSubmittoFADate
        {
            get { return _dDutyandTaxSubmittoFADate; }
            set { _dDutyandTaxSubmittoFADate = value; }
        }

        // <summary>
        // Get set property for DutyPaidDate
        // </summary>
        public DateTime DutyPaidDate
        {
            get { return _dDutyPaidDate; }
            set { _dDutyPaidDate = value; }
        }

        // <summary>
        // Get set property for AssessableValue
        // </summary>
        public double AssessableValue
        {
            get { return _AssessableValue; }
            set { _AssessableValue = value; }
        }

        // <summary>
        // Get set property for CD
        // </summary>
        public double CD
        {
            get { return _CD; }
            set { _CD = value; }
        }

        // <summary>
        // Get set property for RD
        // </summary>
        public double RD
        {
            get { return _RD; }
            set { _RD = value; }
        }

        // <summary>
        // Get set property for SD
        // </summary>
        public double SD
        {
            get { return _SD; }
            set { _SD = value; }
        }

        // <summary>
        // Get set property for VAT
        // </summary>
        public double VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }

        // <summary>
        // Get set property for AIT
        // </summary>
        public double AIT
        {
            get { return _AIT; }
            set { _AIT = value; }
        }
        // <summary>
        // Get set property for ATV
        // </summary>
        public double ATV
        {
            get { return _ATV; }
            set { _ATV = value; }
        }

        // <summary>
        // Get set property for PSI
        // </summary>
        public double PSI
        {
            get { return _PSI; }
            set { _PSI = value; }
        }

        // <summary>
        // Get set property for GlobalTax
        // </summary>
        public double GlobalTax
        {
            get { return _GlobalTax; }
            set { _GlobalTax = value; }
        }

        // <summary>
        // Get set property for ServiceCharge
        // </summary>
        public double ServiceCharge
        {
            get { return _ServiceCharge; }
            set { _ServiceCharge = value; }
        }

        // <summary>
        // Get set property for BG
        // </summary>
        public double BG
        {
            get { return _BG; }
            set { _BG = value; }
        }

        // <summary>
        // Get set property for Additional
        // </summary>
        public double Additional
        {
            get { return _Additional; }
            set { _Additional = value; }
        }

        // <summary>
        // Get set property for SupportingDocSubmitToFAForVATApproval
        // </summary>
        public DateTime SupportingDocSubmitToFAForVATApproval
        {
            get { return _dSupportingDocSubmitToFAForVATApproval; }
            set { _dSupportingDocSubmitToFAForVATApproval = value; }
        }

        // <summary>
        // Get set property for ReleaseDate
        // </summary>
        public DateTime ReleaseDate
        {
            get { return _dReleaseDate; }
            set { _dReleaseDate = value; }
        }

        // <summary>
        // Get set property for ReadyForGRDDate
        // </summary>
        public DateTime ReadyForGRDDate
        {
            get { return _dReadyForGRDDate; }
            set { _dReadyForGRDDate = value; }
        }

        // <summary>
        // Get set property for OceanFreightinBDT
        // </summary>
        public double OceanFreightinBDT
        {
            get { return _OceanFreightinBDT; }
            set { _OceanFreightinBDT = value; }
        }

        // <summary>
        // Get set property for Demurrage
        // </summary>
        public double Demurrage
        {
            get { return _Demurrage; }
            set { _Demurrage = value; }
        }

        // <summary>
        // Get set property for Receivable
        // </summary>
        public double Receivable
        {
            get { return _Receivable; }
            set { _Receivable = value; }
        }

        // <summary>
        // Get set property for MiscNonReceivable
        // </summary>
        public double MiscNonReceivable
        {
            get { return _MiscNonReceivable; }
            set { _MiscNonReceivable = value; }
        }

        // <summary>
        // Get set property for AdvancedAmount
        // </summary>
        public double AdvancedAmount
        {
            get { return _AdvancedAmount; }
            set { _AdvancedAmount = value; }
        }
        private object _BEDate;
        public object BEDate
        {
            get { return _BEDate; }
            set { _BEDate = value; }
        }
        private string _sBENo;
        public string BENo
        {
            get { return _sBENo; }
            set { _sBENo = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        public void Add()
        {
            int nMaxShipmentID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ShipmentID]) FROM t_SCMShipment";
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
                sSql = "INSERT INTO t_SCMShipment (ShipmentID, ShipmentNo, OrderID, ForwarderEngagementDate, ForwarderName, ShipmentDate, InvoiceNo, InvoiceDate, Currency, InvoiceAmount, ShipmentDocRcvbyBankDate, BLNo, BLDate, ContainerNo, NetWeightKG, GrossWeightKG, MeasurementCBM, NoOfCarton, Remarks, DateOfShippingRetireFromBank, CrfValue, DutyandTaxSubmittoFADate, DutyPaidDate, AssessableValue, CD, RD, SD, VAT, AIT,ATV, PSI, GlobalTax, ServiceCharge, BG, Additional, SupportingDocSubmitToFAForVATApproval, ReleaseDate, ReadyForGRDDate, OceanFreightinBDT, Demurrage, Receivable, MiscNonReceivable, AdvancedAmount, Status) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);
                cmd.Parameters.AddWithValue("ShipmentNo", _sShipmentNo);
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("ForwarderEngagementDate", _dForwarderEngagementDate);
                cmd.Parameters.AddWithValue("ForwarderName", _sForwarderName);
                cmd.Parameters.AddWithValue("ShipmentDate", _dShipmentDate);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("Currency", _nCurrency);
                cmd.Parameters.AddWithValue("InvoiceAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("ShipmentDocRcvbyBankDate", _dShipmentDocRcvbyBankDate);
                cmd.Parameters.AddWithValue("BLNo", _sBLNo);
                cmd.Parameters.AddWithValue("BLDate", _dBLDate);
                cmd.Parameters.AddWithValue("ContainerNo", _sContainerNo);
                cmd.Parameters.AddWithValue("NetWeightKG", _NetWeightKG);
                cmd.Parameters.AddWithValue("GrossWeightKG", _GrossWeightKG);
                cmd.Parameters.AddWithValue("MeasurementCBM", _MeasurementCBM);
                cmd.Parameters.AddWithValue("NoOfCarton", _nNoOfCarton);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("DateOfShippingRetireFromBank", _dDateOfShippingRetireFromBank);
                cmd.Parameters.AddWithValue("CrfValue", _CrfValue);
                cmd.Parameters.AddWithValue("DutyandTaxSubmittoFADate", _dDutyandTaxSubmittoFADate);
                cmd.Parameters.AddWithValue("DutyPaidDate", _dDutyPaidDate);
                cmd.Parameters.AddWithValue("AssessableValue", _AssessableValue);
                cmd.Parameters.AddWithValue("CD", _CD);
                cmd.Parameters.AddWithValue("RD", _RD);
                cmd.Parameters.AddWithValue("SD", _SD);
                cmd.Parameters.AddWithValue("VAT", _VAT);
                cmd.Parameters.AddWithValue("AIT", _AIT);
                cmd.Parameters.AddWithValue("ATV", _ATV);
                cmd.Parameters.AddWithValue("PSI", _PSI);
                cmd.Parameters.AddWithValue("GlobalTax", _GlobalTax);
                cmd.Parameters.AddWithValue("ServiceCharge", _ServiceCharge);
                cmd.Parameters.AddWithValue("BG", _BG);
                cmd.Parameters.AddWithValue("Additional", _Additional);
                cmd.Parameters.AddWithValue("SupportingDocSubmitToFAForVATApproval", _dSupportingDocSubmitToFAForVATApproval);
                cmd.Parameters.AddWithValue("ReleaseDate", _dReleaseDate);
                cmd.Parameters.AddWithValue("ReadyForGRDDate", _dReadyForGRDDate);
                cmd.Parameters.AddWithValue("OceanFreightinBDT", _OceanFreightinBDT);
                cmd.Parameters.AddWithValue("Demurrage", _Demurrage);
                cmd.Parameters.AddWithValue("Receivable", _Receivable);
                cmd.Parameters.AddWithValue("MiscNonReceivable", _MiscNonReceivable);
                cmd.Parameters.AddWithValue("AdvancedAmount", _AdvancedAmount);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertShipment(int nCompanyID)
        {
            int nShipmentID = 0;
            int nMaxNextShipmentNo = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ShipmentID]) FROM t_SCMShipment";
                cmd.CommandText = sSql;
                object MaxShipmentID = cmd.ExecuteScalar();
                if (MaxShipmentID == DBNull.Value)
                {
                    nShipmentID = 1;
                }
                else
                {
                    nShipmentID = int.Parse(MaxShipmentID.ToString()) + 1;

                }
                _nShipmentID = nShipmentID;

                string sShortCode = "";
                DateTime dOperationDate;

                sShortCode = "S";
                dOperationDate = DateTime.Today.Date;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = " select NextShipmentNo from t_NextSCMPONo ";
                cmd.CommandText = sSql;

                object MaxShipmentNo = cmd.ExecuteScalar();
                if (MaxShipmentNo == DBNull.Value)
                {
                    nMaxNextShipmentNo = 1;
                }
                else
                {
                    nMaxNextShipmentNo = int.Parse(MaxShipmentNo.ToString());

                }

                _sShipmentNo = sShortCode + "-" + dOperationDate.Year.ToString() + "-" + nMaxNextShipmentNo.ToString("0000");

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SCMShipment (ShipmentID, ShipmentNo, PIID, ForwarderEngagementDate, ForwarderName, ShipmentDate, InvoiceNo, InvoiceDate, Currency, InvoiceAmount, ShipmentDocRcvbyBankDate, BLNo, BLDate, ContainerNo, NetWeightKG, GrossWeightKG, MeasurementCBM, NoOfCarton, Remarks, DateOfShippingRetireFromBank, CrfValue, DutyandTaxSubmittoFADate, DutyPaidDate, AssessableValue, CD, RD, SD, VAT, AIT, ATV, PSI, GlobalTax, ServiceCharge, BG, Additional, SupportingDocSubmitToFAForVATApproval, ReleaseDate, ReadyForGRDDate, OceanFreightinBDT, Demurrage, Receivable, MiscNonReceivable, AdvancedAmount, Status) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);
                cmd.Parameters.AddWithValue("ShipmentNo", _sShipmentNo);
                cmd.Parameters.AddWithValue("PIID", _nPIID);
                cmd.Parameters.AddWithValue("ForwarderEngagementDate", _dForwarderEngagementDate);
                cmd.Parameters.AddWithValue("ForwarderName", _sForwarderName);
                cmd.Parameters.AddWithValue("ShipmentDate", _dShipmentDate);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("Currency", _nCurrency);
                cmd.Parameters.AddWithValue("InvoiceAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("ShipmentDocRcvbyBankDate", _dShipmentDocRcvbyBankDate);
                cmd.Parameters.AddWithValue("BLNo", _sBLNo);
                cmd.Parameters.AddWithValue("BLDate", _dBLDate);
                cmd.Parameters.AddWithValue("ContainerNo", _sContainerNo);
                cmd.Parameters.AddWithValue("NetWeightKG", _NetWeightKG);
                cmd.Parameters.AddWithValue("GrossWeightKG", _GrossWeightKG);
                cmd.Parameters.AddWithValue("MeasurementCBM", _MeasurementCBM);
                cmd.Parameters.AddWithValue("NoOfCarton", _nNoOfCarton);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("DateOfShippingRetireFromBank", null);
                cmd.Parameters.AddWithValue("CrfValue", null);
                cmd.Parameters.AddWithValue("DutyandTaxSubmittoFADate", null);
                cmd.Parameters.AddWithValue("DutyPaidDate", null);
                cmd.Parameters.AddWithValue("AssessableValue", null);
                cmd.Parameters.AddWithValue("CD", null);
                cmd.Parameters.AddWithValue("RD", null);
                cmd.Parameters.AddWithValue("SD", null);
                cmd.Parameters.AddWithValue("VAT", null);
                cmd.Parameters.AddWithValue("AIT", null);
                cmd.Parameters.AddWithValue("ATV", null);
                cmd.Parameters.AddWithValue("PSI", null);
                cmd.Parameters.AddWithValue("GlobalTax", null);
                cmd.Parameters.AddWithValue("ServiceCharge", null);
                cmd.Parameters.AddWithValue("BG", null);
                cmd.Parameters.AddWithValue("Additional", null);
                cmd.Parameters.AddWithValue("SupportingDocSubmitToFAForVATApproval", null);
                cmd.Parameters.AddWithValue("ReleaseDate", null);
                cmd.Parameters.AddWithValue("ReadyForGRDDate", null);
                cmd.Parameters.AddWithValue("OceanFreightinBDT", null);
                cmd.Parameters.AddWithValue("Demurrage", null);
                cmd.Parameters.AddWithValue("Receivable", null);
                cmd.Parameters.AddWithValue("MiscNonReceivable", null);
                cmd.Parameters.AddWithValue("AdvancedAmount", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update t_NextSCMPONo Set NextShipmentNo = ?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("NextShipmentNo", nMaxNextShipmentNo + 1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                if (nCompanyID == 82942)
                {
                    foreach (SCMShipmentItem oItem in this)
                    {
                        oItem.InsertBEILShipmentItem(_nShipmentID);
                    }
                }
                else
                {
                    foreach (SCMShipmentItem oItem in this)
                    {
                        oItem.InsertShipmentItem(_nShipmentID);
                    }
                }

                cmd = DBController.Instance.GetCommand();

                SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
                oSCMProcessHistory.TableName = "t_SCMShipment";
                oSCMProcessHistory.DateID = Convert.ToInt32(_nShipmentID);
                oSCMProcessHistory.StatusID = Convert.ToInt32(_nStatus);
                oSCMProcessHistory.ExpectedGRDWeek = Convert.ToInt32(_nExpectedHOArrivalWeek);
                oSCMProcessHistory.ExpectedGRDYear = Convert.ToInt32(_nExpectedHOArrivalYear);
                oSCMProcessHistory.Remarks = _sRemarks;
                oSCMProcessHistory.TranType = (int)Dictionary.DataTransferType.Add;

                oSCMProcessHistory.Add();

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
                sSql = "UPDATE t_SCMShipment SET OrderID = ?, ForwarderEngagementDate = ?, ForwarderName = ?, ShipmentDate = ?, InvoiceNo = ?, InvoiceDate = ?, Currency = ?, InvoiceAmount = ?, ShipmentDocRcvbyBankDate = ?, BLNo = ?, BLDate = ?, ContainerNo = ?, NetWeightKG = ?, GrossWeightKG = ?, MeasurementCBM = ?, NoOfCarton = ?, Remarks = ?, DateOfShippingRetireFromBank = ?, CrfValue = ?, DutyandTaxSubmittoFADate = ?, DutyPaidDate = ?, AssessableValue = ?, CD = ?, RD = ?, SD = ?, VAT = ?, AIT = ?, ATV = ?, PSI = ?, GlobalTax = ?, ServiceCharge = ?, BG = ?, Additional = ?, SupportingDocSubmitToFAForVATApproval = ? ,ReleaseDate = ?, ReadyForGRDDate = ?, OceanFreightinBDT = ?, Demurrage = ?, Receivable = ?, MiscNonReceivable = ?, AdvancedAmount = ?, Status = ? WHERE ShipmentID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("ForwarderEngagementDate", _dForwarderEngagementDate);
                cmd.Parameters.AddWithValue("ForwarderName", _sForwarderName);
                cmd.Parameters.AddWithValue("ShipmentDate", _dShipmentDate);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("Currency", _nCurrency);
                cmd.Parameters.AddWithValue("InvoiceAmount", _InvoiceAmount);
                cmd.Parameters.AddWithValue("ShipmentDocRcvbyBankDate", _dShipmentDocRcvbyBankDate);
                cmd.Parameters.AddWithValue("BLNo", _sBLNo);
                cmd.Parameters.AddWithValue("BLDate", _dBLDate);
                cmd.Parameters.AddWithValue("ContainerNo", _sContainerNo);
                cmd.Parameters.AddWithValue("NetWeightKG", _NetWeightKG);
                cmd.Parameters.AddWithValue("GrossWeightKG", _GrossWeightKG);
                cmd.Parameters.AddWithValue("MeasurementCBM", _MeasurementCBM);
                cmd.Parameters.AddWithValue("NoOfCarton", _nNoOfCarton);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("DateOfShippingRetireFromBank", _dDateOfShippingRetireFromBank);
                cmd.Parameters.AddWithValue("CrfValue", _CrfValue);
                cmd.Parameters.AddWithValue("DutyandTaxSubmittoFADate", _dDutyandTaxSubmittoFADate);
                cmd.Parameters.AddWithValue("DutyPaidDate", _dDutyPaidDate);
                cmd.Parameters.AddWithValue("AssessableValue", _AssessableValue);
                cmd.Parameters.AddWithValue("CD", _CD);
                cmd.Parameters.AddWithValue("RD", _RD);
                cmd.Parameters.AddWithValue("SD", _SD);
                cmd.Parameters.AddWithValue("VAT", _VAT);
                cmd.Parameters.AddWithValue("AIT", _AIT);
                cmd.Parameters.AddWithValue("ATV", _ATV);
                cmd.Parameters.AddWithValue("PSI", _PSI);
                cmd.Parameters.AddWithValue("GlobalTax", _GlobalTax);
                cmd.Parameters.AddWithValue("ServiceCharge", _ServiceCharge);
                cmd.Parameters.AddWithValue("BG", _BG);
                cmd.Parameters.AddWithValue("Additional", _Additional);
                cmd.Parameters.AddWithValue("SupportingDocSubmitToFAForVATApproval", _dSupportingDocSubmitToFAForVATApproval);
                cmd.Parameters.AddWithValue("ReleaseDate", _dReleaseDate);
                cmd.Parameters.AddWithValue("ReadyForGRDDate", _dReadyForGRDDate);
                cmd.Parameters.AddWithValue("OceanFreightinBDT", _OceanFreightinBDT);
                cmd.Parameters.AddWithValue("Demurrage", _Demurrage);
                cmd.Parameters.AddWithValue("Receivable", _Receivable);
                cmd.Parameters.AddWithValue("MiscNonReceivable", _MiscNonReceivable);
                cmd.Parameters.AddWithValue("AdvancedAmount", _AdvancedAmount);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateCustomerClearance(int nShipmentID, int nExpectedHOArrivalWeek, int nExpectedHOArrivalYear, string sRemarks)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_SCMShipment SET DateOfShippingRetireFromBank = ?, CrfValue = ?, DutyandTaxSubmittoFADate = ?, DutyPaidDate = ?, AssessableValue = ?, CD = ?, RD = ?, SD = ?, VAT = ?, AIT = ?, ATV = ?, PSI = ?, GlobalTax = ?, ServiceCharge = ?, BG = ?, Additional = ?, Status = ?, BENo = ?, BEDate = ? WHERE ShipmentID = ?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DateOfShippingRetireFromBank", _dDateOfShippingRetireFromBank);
                cmd.Parameters.AddWithValue("CrfValue", _CrfValue);
                cmd.Parameters.AddWithValue("DutyandTaxSubmittoFADate", _dDutyandTaxSubmittoFADate);
                cmd.Parameters.AddWithValue("DutyPaidDate", _dDutyPaidDate);
                cmd.Parameters.AddWithValue("AssessableValue", _AssessableValue);
                cmd.Parameters.AddWithValue("CD", _CD);
                cmd.Parameters.AddWithValue("RD", _RD);
                cmd.Parameters.AddWithValue("SD", _SD);
                cmd.Parameters.AddWithValue("VAT", _VAT);
                cmd.Parameters.AddWithValue("AIT", _AIT);
                cmd.Parameters.AddWithValue("ATV", _ATV);
                cmd.Parameters.AddWithValue("PSI", _PSI);
                cmd.Parameters.AddWithValue("GlobalTax", _GlobalTax);
                cmd.Parameters.AddWithValue("ServiceCharge", _ServiceCharge);
                cmd.Parameters.AddWithValue("BG", _BG);
                cmd.Parameters.AddWithValue("Additional", _Additional);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("BENo", _sBENo);
                cmd.Parameters.AddWithValue("BEDate", _BEDate);

                cmd.Parameters.AddWithValue("ShipmentID", nShipmentID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();


                SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
                oSCMProcessHistory.TableName = "t_SCMShipment";
                oSCMProcessHistory.DateID = Convert.ToInt32(nShipmentID);
                oSCMProcessHistory.StatusID = Convert.ToInt32(_nStatus);
                oSCMProcessHistory.ExpectedGRDWeek = Convert.ToInt32(nExpectedHOArrivalWeek);
                oSCMProcessHistory.ExpectedGRDYear = Convert.ToInt32(nExpectedHOArrivalYear);
                oSCMProcessHistory.Remarks = sRemarks;
                oSCMProcessHistory.TranType = (int)Dictionary.DataTransferType.Edit;

                oSCMProcessHistory.Add();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateRelease(int nShipmentID, int nExpectedHOArrivalWeek, int nExpectedHOArrivalYear, string sRemarks)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_SCMShipment SET ReleaseDate = ?, SupportingDocSubmitToFAForVATApproval = ?, Status = ? WHERE ShipmentID = ?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ReleaseDate", _dReleaseDate);
                cmd.Parameters.AddWithValue("SupportingDocSubmitToFAForVATApproval", _dSupportingDocSubmitToFAForVATApproval);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("ShipmentID", nShipmentID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();


                SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
                oSCMProcessHistory.TableName = "t_SCMShipment";
                oSCMProcessHistory.DateID = Convert.ToInt32(nShipmentID);
                oSCMProcessHistory.StatusID = Convert.ToInt32(_nStatus);
                oSCMProcessHistory.ExpectedGRDWeek = Convert.ToInt32(nExpectedHOArrivalWeek);
                oSCMProcessHistory.ExpectedGRDYear = Convert.ToInt32(nExpectedHOArrivalYear);
                oSCMProcessHistory.Remarks = sRemarks;
                oSCMProcessHistory.TranType = (int)Dictionary.DataTransferType.Edit;

                oSCMProcessHistory.Add();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateReadyForGRD(int nShipmentID, int nExpectedHOArrivalWeek, int nExpectedHOArrivalYear, string sRemarks)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_SCMShipment SET ReadyForGRDDate = ? , Status = ? WHERE ShipmentID = ?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ReadyForGRDDate", _dReadyForGRDDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("ShipmentID", nShipmentID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();


                SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
                oSCMProcessHistory.TableName = "t_SCMShipment";
                oSCMProcessHistory.DateID = Convert.ToInt32(nShipmentID);
                oSCMProcessHistory.StatusID = Convert.ToInt32(_nStatus);
                oSCMProcessHistory.ExpectedGRDWeek = Convert.ToInt32(nExpectedHOArrivalWeek);
                oSCMProcessHistory.ExpectedGRDYear = Convert.ToInt32(nExpectedHOArrivalYear);
                oSCMProcessHistory.Remarks = sRemarks;
                oSCMProcessHistory.TranType = (int)Dictionary.DataTransferType.Edit;

                oSCMProcessHistory.Add();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateBilling(int nShipmentID, int nExpectedHOArrivalWeek, int nExpectedHOArrivalYear, string sRemarks)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE t_SCMShipment SET OceanFreightinBDT = ?, Demurrage = ?, Receivable = ?, MiscNonReceivable = ?, AdvancedAmount = ?, Status = ? WHERE ShipmentID = ?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OceanFreightinBDT", _OceanFreightinBDT);
                cmd.Parameters.AddWithValue("Demurrage", _Demurrage);
                cmd.Parameters.AddWithValue("Receivable", _Receivable);
                cmd.Parameters.AddWithValue("MiscNonReceivable", _MiscNonReceivable);
                cmd.Parameters.AddWithValue("AdvancedAmount", _AdvancedAmount);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("ShipmentID", nShipmentID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();


                SCMProcessHistory oSCMProcessHistory = new SCMProcessHistory();
                oSCMProcessHistory.TableName = "t_SCMShipment";
                oSCMProcessHistory.DateID = Convert.ToInt32(nShipmentID);
                oSCMProcessHistory.StatusID = Convert.ToInt32(_nStatus);
                oSCMProcessHistory.ExpectedGRDWeek = Convert.ToInt32(nExpectedHOArrivalWeek);
                oSCMProcessHistory.ExpectedGRDYear = Convert.ToInt32(nExpectedHOArrivalYear);
                oSCMProcessHistory.Remarks = sRemarks;
                oSCMProcessHistory.TranType = (int)Dictionary.DataTransferType.Edit;

                oSCMProcessHistory.Add();


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
                sSql = "DELETE FROM t_SCMShipment WHERE [ShipmentID]=?";
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
                cmd.CommandText = "SELECT * FROM t_SCMShipment where ShipmentID =?";
                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nShipmentID = (int)reader["ShipmentID"];
                    _sShipmentNo = (string)reader["ShipmentNo"];
                    _nOrderID = (int)reader["OrderID"];
                    _dForwarderEngagementDate = Convert.ToDateTime(reader["ForwarderEngagementDate"].ToString());
                    _sForwarderName = (string)reader["ForwarderName"];
                    _dShipmentDate = Convert.ToDateTime(reader["ShipmentDate"].ToString());
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _nCurrency = (int)reader["Currency"];
                    _InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _dShipmentDocRcvbyBankDate = Convert.ToDateTime(reader["ShipmentDocRcvbyBankDate"].ToString());
                    _sBLNo = (string)reader["BLNo"];
                    _dBLDate = Convert.ToDateTime(reader["BLDate"].ToString());
                    _sContainerNo = (string)reader["ContainerNo"];
                    _NetWeightKG = Convert.ToDouble(reader["NetWeightKG"].ToString());
                    _GrossWeightKG = Convert.ToDouble(reader["GrossWeightKG"].ToString());
                    _MeasurementCBM = Convert.ToDouble(reader["MeasurementCBM"].ToString());
                    _nNoOfCarton = (int)reader["NoOfCarton"];
                    _sRemarks = (string)reader["Remarks"];
                    _dDateOfShippingRetireFromBank = Convert.ToDateTime(reader["DateOfShippingRetireFromBank"].ToString());
                    _CrfValue = Convert.ToDouble(reader["CrfValue"].ToString());
                    _dDutyandTaxSubmittoFADate = Convert.ToDateTime(reader["DutyandTaxSubmittoFADate"].ToString());
                    _dDutyPaidDate = Convert.ToDateTime(reader["DutyPaidDate"].ToString());
                    _AssessableValue = Convert.ToDouble(reader["AssessableValue"].ToString());
                    _CD = Convert.ToDouble(reader["CD"].ToString());
                    _RD = Convert.ToDouble(reader["RD"].ToString());
                    _SD = Convert.ToDouble(reader["SD"].ToString());
                    _VAT = Convert.ToDouble(reader["VAT"].ToString());
                    _AIT = Convert.ToDouble(reader["AIT"].ToString());
                    _ATV = Convert.ToDouble(reader["ATV"].ToString());
                    _PSI = Convert.ToDouble(reader["PSI"].ToString());
                    _GlobalTax = Convert.ToDouble(reader["GlobalTax"].ToString());
                    _ServiceCharge = Convert.ToDouble(reader["ServiceCharge"].ToString());
                    _BG = Convert.ToDouble(reader["BG"].ToString());
                    _Additional = Convert.ToDouble(reader["Additional"].ToString());
                    _dSupportingDocSubmitToFAForVATApproval = Convert.ToDateTime(reader["SupportingDocSubmitToFAForVATApproval"].ToString());
                    _dReleaseDate = Convert.ToDateTime(reader["ReleaseDate"].ToString());
                    _dReadyForGRDDate = Convert.ToDateTime(reader["ReadyForGRDDate"].ToString());
                    _OceanFreightinBDT = Convert.ToDouble(reader["OceanFreightinBDT"].ToString());
                    _Demurrage = Convert.ToDouble(reader["Demurrage"].ToString());
                    _Receivable = Convert.ToDouble(reader["Receivable"].ToString());
                    _MiscNonReceivable = Convert.ToDouble(reader["MiscNonReceivable"].ToString());
                    _AdvancedAmount = Convert.ToDouble(reader["AdvancedAmount"].ToString());
                    _nStatus = (int)reader["Status"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshIsPIQtyEqual(int nPIID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select PIID,IsEqual From  " +
                                " (Select PIID,PIQty,ShipmentQty,(PIQty-ShipmentQty) IsEqual From    " +
                                " (Select x.PIID,PIQty,isnull (ShipmentQty,0) ShipmentQty From    " +
                                " (Select PIID,sum (PIQty) PIQty From t_SCMPIItem    " +
                                " group by PIID) x    " +
                                " Left Outer Join     " +
                                " (Select PIID,sum (ShipmentQty) ShipmentQty From t_SCMShipment a,t_SCMShipmentItem b     " +
                                " where a.ShipmentID=b.ShipmentID group by PIID) y    " +
                                " on x.PIID=y.PIID) x ) xx where PIID = ? ";

                cmd.Parameters.AddWithValue("PIID", nPIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPIID = (int)reader["PIID"];
                    _nIsEqual = (int)reader["IsEqual"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshBEILIsPIQtyEqual(int nPIID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select PIID,IsEqual From  " +
                                " (Select PIID,PIQty,ShipmentQty,(PIQty-ShipmentQty) IsEqual From    " +
                                " (Select x.PIID,PIQty,isnull (ShipmentQty,0) ShipmentQty From    " +
                                " (Select PIID,sum (PIQty) PIQty From t_SCMPIBOMItem    " +
                                " group by PIID) x    " +
                                " Left Outer Join     " +
                                " (Select PIID,sum (ShipmentQty) ShipmentQty From t_SCMShipment a,t_SCMShipmentBOMItem b     " +
                                " where a.ShipmentID=b.ShipmentID group by PIID) y    " +
                                " on x.PIID=y.PIID) x ) xx where PIID = ? ";

                cmd.Parameters.AddWithValue("PIID", nPIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPIID = (int)reader["PIID"];
                    _nIsEqual = (int)reader["IsEqual"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshShipmentForGRD(int nShipmentID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select c.SupplierID,ShipmentID,ShipmentNo,ShipmentDate,InvoiceNo,InvoiceDate,PINo,PIReceiveDate, " +
                                  " isnull(LCNo,'NonLC') as LCNo,isnull(LCDate,PIReceiveDate) as LCDate,OrderNo,OrderPlaceDate,PSINo,CreateDate,CompanyName,SupplierName " +
                                  " From t_SCMShipment a,t_SCMPI b,t_SCMOrder c,t_SCMPSI d,t_Company e,t_Supplier f " +
                                  " where a.PIID=b.PIID and b.OrderID=c.OrderID and c.PSIID=d.PSIID and d.Company=e.CompanyID  " +
                                  " and c.SupplierID=f.SupplierID and ShipmentID = ?";

                cmd.Parameters.AddWithValue("ShipmentID", nShipmentID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nSupplierID = (int)reader["SupplierID"];
                    _nShipmentID = (int)reader["ShipmentID"];
                    _sShipmentNo = (string)reader["ShipmentNo"];
                    _dShipmentDate = Convert.ToDateTime(reader["ShipmentDate"].ToString());
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _sPINo = (string)reader["PINo"];
                    _dPIReceiveDate = Convert.ToDateTime(reader["PIReceiveDate"].ToString());
                    _sLCNo = (string)reader["LCNo"];
                    _dLCDate = Convert.ToDateTime(reader["LCDate"].ToString());
                    _sOrderNo = (string)reader["OrderNo"];
                    _dOrderPlaceDate = Convert.ToDateTime(reader["OrderPlaceDate"].ToString());
                    _sPSINo = (string)reader["PSINo"];
                    _dPSIDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _sCompanyName = (string)reader["CompanyName"];
                    _sSupplierName = (string)reader["SupplierName"];

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshChallanForGRD(int nShipmentID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select ID,ChallanNo,ChallanDate,ChallanNo,ChallanDate, "+
                                  "'N/A' as PINo,ChallanDate as PIReceiveDate,  "+
                                  "'NonLC' as LCNo,ChallanDate as LCDate, "+
                                  "'N/A' as OrderNo,ChallanDate as OrderPlaceDate, "+
                                  "'N/A' as PSINo,ChallanDate, "+
                                  "'Bangladesh Electrical Industries Limited' as CompanyName, "+
                                  "'Bangladesh Electrical Industries Limited' as SupplierName  "+
                                  "From t_ProductionLotDelivery a " +
                                  "where ID = ? ";

                cmd.Parameters.AddWithValue("ID", nShipmentID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nShipmentID = (int)reader["ID"];
                    _sShipmentNo = (string)reader["ChallanNo"];
                    _dShipmentDate = Convert.ToDateTime(reader["ChallanDate"].ToString());
                    _sInvoiceNo = (string)reader["ChallanNo"];
                    _dInvoiceDate = Convert.ToDateTime(reader["ChallanDate"].ToString());
                    _sPINo = (string)reader["PINo"];
                    _dPIReceiveDate = Convert.ToDateTime(reader["PIReceiveDate"].ToString());
                    _sLCNo = (string)reader["LCNo"];
                    _dLCDate = Convert.ToDateTime(reader["LCDate"].ToString());
                    _sOrderNo = (string)reader["OrderNo"];
                    _dOrderPlaceDate = Convert.ToDateTime(reader["OrderPlaceDate"].ToString());
                    _sPSINo = (string)reader["PSINo"];
                    _dPSIDate = Convert.ToDateTime(reader["ChallanDate"].ToString());
                    _sCompanyName = (string)reader["CompanyName"];
                    _sSupplierName = (string)reader["SupplierName"];

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshShipmentItemForGRD()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select InventoryCategory,IsBarcodeItem,ShipmentID,ProductID,ProductCode,ProductName,isnull(CP,0) as CP,ShipmentQty,GRDQty From  " +
                               " (Select InventoryCategory,IsBarcodeItem,x.ShipmentID,x.ProductID,ProductCode,ProductName,CP,ShipmentQty,isnull(GRDQty,0) GRDQty From   " +
                               " (Select InventoryCategory,isnull(IsBarcodeItem,0) IsBarcodeItem,ShipmentID,a.ProductID,ProductCode,ProductName,CostPrice as CP,ShipmentQty   " +
                               " From t_SCMShipmentItem a,v_ProductDetails b  " +
                               " where a.ProductID=b.ProductID) x  " +
                               " Left outer Join   " +
                               " (Select ShipmentID,ProductID,Sum(Qty) as GRDQty From t_SCMGRD a,t_ProductStockTranItem b " +
                               " where a.TranID=b.TranID  group by ShipmentID,ProductID) y  " +
                               " on x.ShipmentID=y.ShipmentID and x.ProductID=y.ProductID) xx where ShipmentQty<>GRDQty and ShipmentID = ?";

                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMShipmentItem oItem = new SCMShipmentItem();
                    oItem.IsBarcodeItem = int.Parse(reader["IsBarcodeItem"].ToString());
                    oItem.ShipmentID = int.Parse(reader["ShipmentID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.CostPrice = Convert.ToDouble(reader["CP"].ToString());
                    oItem.ShipmentQty = int.Parse(reader["ShipmentQty"].ToString());
                    oItem.GRDQty = int.Parse(reader["GRDQty"].ToString());
                    oItem.InventoryCategory = int.Parse(reader["InventoryCategory"].ToString());


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
        public void RefreshChallanItemForGRD()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select IsBarcodeItem,ChallanID,ProductID,ProductCode,ProductName,isnull(CP,0) as CP,ChallanQty,GRDQty From  " +
                                " (Select IsBarcodeItem,x.ChallanID,x.ProductID,ProductCode,ProductName,CP,ChallanQty,isnull(GRDQty,0) GRDQty From     " +
                                " (Select * From (Select  isnull(IsBarcodeItem,0) IsBarcodeItem,a.ID as ChallanID,a.ProductID,ProductCode,ProductName,CostPrice as CP,ChallanQty    " +
                                " From t_ProductionLotDeliveryItem a,v_ProductDetails b,t_ProductionLotDelivery c  "+
                                " where a.ProductID=b.ProductID and a.ID=c.ID and CustomerID=759) x) x   "+
                                " Left outer Join     "+
                                " (Select ChallanID,ProductID,Sum(Qty) as GRDQty   "+
                                " From t_SCMGRD a,t_ProductStockTranItem b   "+
                                " where a.TranID=b.TranID  and ChallanID is not null   "+
                                " group by ChallanID,ProductID) y    "+
                                " on x.ChallanID=y.ChallanID and x.ProductID=y.ProductID) xx where ChallanQty<>GRDQty   " +
                                " and ChallanID = ?";

                cmd.Parameters.AddWithValue("ChallanID", _nShipmentID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMShipmentItem oItem = new SCMShipmentItem();
                    oItem.IsBarcodeItem = int.Parse(reader["IsBarcodeItem"].ToString());
                    oItem.ShipmentID = int.Parse(reader["ChallanID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.CostPrice = Convert.ToDouble(reader["CP"].ToString());
                    oItem.ShipmentQty = int.Parse(reader["ChallanQty"].ToString());
                    oItem.GRDQty = int.Parse(reader["GRDQty"].ToString());
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
        public void RefreshBEILShipmentItemForGRD()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select * From  "+
                                " (Select x.ShipmentID,x.ProductID,ProductCode,ProductName,  "+
                                " x.BOMID,BOMDescription,ShipmentQty,isnull(GRDQty,0) GRDQty From     " +
                                " (Select * From (Select ShipmentID,a.ProductID,ProductCode,ProductName,  "+
                                " a.BOMID,BOMDescription,ShipmentQty     "+
                                " From t_SCMShipmentBOMItem a,t_ProductBOM b,t_Product c  "+
                                " where a.ProductID=c.ProductID and a.BOMID=b.BOMID) a) x   "+
                                " Left outer Join     "+
                                " (Select ShipmentID,ProductID,BOMID,sum(Quantity) GRDQty   "+
                                " from t_SCMBOMStockTran a,t_SCMBOMStockTranItem b   "+
                                " where a.TranID=b.TranID group by ShipmentID,ProductID,BOMID) y   "+
                                " on x.ShipmentID=y.ShipmentID and x.ProductID=y.ProductID and x.BOMID=y.BOMID) x  " +
                                " where ShipmentQty<>GRDQty and ShipmentID = ? ";


                cmd.Parameters.AddWithValue("ShipmentID", _nShipmentID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMShipmentItem oItem = new SCMShipmentItem();
                    oItem.ShipmentID = int.Parse(reader["ShipmentID"].ToString());
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.BOMID = int.Parse(reader["BOMID"].ToString());
                    oItem.BOMDescription = (reader["BOMDescription"].ToString());
                    oItem.ShipmentQty = int.Parse(reader["ShipmentQty"].ToString());
                    oItem.GRDQty = int.Parse(reader["GRDQty"].ToString());
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

        public void GetItems(int nShipmentID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select a.ProductID,ProductCode,ProductName,ShipmentQty  " +
                                  "From t_SCMShipmentItem a,t_Product b " +
                                  "where a.ProductID=b.ProductID and ShipmentID=" + nShipmentID + "";

                cmd.Parameters.AddWithValue("ShipmentID", nShipmentID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMShipmentItem oItem = new SCMShipmentItem();
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.ShipmentQty = int.Parse(reader["ShipmentQty"].ToString());
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
    }
    public class SCMShipments : CollectionBase
    {
        public SCMShipment this[int i]
        {
            get { return (SCMShipment)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SCMShipment oSCMShipment)
        {
            InnerList.Add(oSCMShipment);
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
            string sSql = "SELECT * FROM t_SCMShipment";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMShipment oSCMShipment = new SCMShipment();
                    oSCMShipment.ShipmentID = (int)reader["ShipmentID"];
                    oSCMShipment.ShipmentNo = (string)reader["ShipmentNo"];
                    oSCMShipment.OrderID = (int)reader["OrderID"];
                    oSCMShipment.ForwarderEngagementDate = Convert.ToDateTime(reader["ForwarderEngagementDate"].ToString());
                    oSCMShipment.ForwarderName = (string)reader["ForwarderName"];
                    oSCMShipment.ShipmentDate = Convert.ToDateTime(reader["ShipmentDate"].ToString());
                    oSCMShipment.InvoiceNo = (string)reader["InvoiceNo"];
                    oSCMShipment.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oSCMShipment.Currency = (int)reader["Currency"];
                    oSCMShipment.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    oSCMShipment.ShipmentDocRcvbyBankDate = Convert.ToDateTime(reader["ShipmentDocRcvbyBankDate"].ToString());
                    oSCMShipment.BLNo = (string)reader["BLNo"];
                    oSCMShipment.BLDate = Convert.ToDateTime(reader["BLDate"].ToString());
                    oSCMShipment.ContainerNo = (string)reader["ContainerNo"];
                    oSCMShipment.NetWeightKG = Convert.ToDouble(reader["NetWeightKG"].ToString());
                    oSCMShipment.GrossWeightKG = Convert.ToDouble(reader["GrossWeightKG"].ToString());
                    oSCMShipment.MeasurementCBM = Convert.ToDouble(reader["MeasurementCBM"].ToString());
                    oSCMShipment.NoOfCarton = (int)reader["NoOfCarton"];
                    oSCMShipment.Remarks = (string)reader["Remarks"];
                    oSCMShipment.DateOfShippingRetireFromBank = Convert.ToDateTime(reader["DateOfShippingRetireFromBank"].ToString());
                    oSCMShipment.CrfValue = Convert.ToDouble(reader["CrfValue"].ToString());
                    oSCMShipment.DutyandTaxSubmittoFADate = Convert.ToDateTime(reader["DutyandTaxSubmittoFADate"].ToString());
                    oSCMShipment.DutyPaidDate = Convert.ToDateTime(reader["DutyPaidDate"].ToString());
                    oSCMShipment.AssessableValue = Convert.ToDouble(reader["AssessableValue"].ToString());
                    oSCMShipment.CD = Convert.ToDouble(reader["CD"].ToString());
                    oSCMShipment.RD = Convert.ToDouble(reader["RD"].ToString());
                    oSCMShipment.SD = Convert.ToDouble(reader["SD"].ToString());
                    oSCMShipment.VAT = Convert.ToDouble(reader["VAT"].ToString());
                    oSCMShipment.AIT = Convert.ToDouble(reader["AIT"].ToString());
                    oSCMShipment.ATV = Convert.ToDouble(reader["ATV"].ToString());
                    oSCMShipment.PSI = Convert.ToDouble(reader["PSI"].ToString());
                    oSCMShipment.GlobalTax = Convert.ToDouble(reader["GlobalTax"].ToString());
                    oSCMShipment.ServiceCharge = Convert.ToDouble(reader["ServiceCharge"].ToString());
                    oSCMShipment.BG = Convert.ToDouble(reader["BG"].ToString());
                    oSCMShipment.Additional = Convert.ToDouble(reader["Additional"].ToString());
                    oSCMShipment.SupportingDocSubmitToFAForVATApproval = Convert.ToDateTime(reader["SupportingDocSubmitToFAForVATApproval"].ToString());
                    oSCMShipment.ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"].ToString());
                    oSCMShipment.ReadyForGRDDate = Convert.ToDateTime(reader["ReadyForGRDDate"].ToString());
                    oSCMShipment.OceanFreightinBDT = Convert.ToDouble(reader["OceanFreightinBDT"].ToString());
                    oSCMShipment.Demurrage = Convert.ToDouble(reader["Demurrage"].ToString());
                    oSCMShipment.Receivable = Convert.ToDouble(reader["Receivable"].ToString());
                    oSCMShipment.MiscNonReceivable = Convert.ToDouble(reader["MiscNonReceivable"].ToString());
                    oSCMShipment.AdvancedAmount = Convert.ToDouble(reader["AdvancedAmount"].ToString());
                    oSCMShipment.Status = (int)reader["Status"];
                    InnerList.Add(oSCMShipment);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshShipment(DateTime dFromDate, DateTime dToDate, string sShipmentNo, string sInvoiceNo, string sLCNO, string sOrderNo, string sPSINO, int nSupplier, int nCompany, int nStatus, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select ShipmentID,ShipmentNo,ShipmentDate,a.PIID,PINo,PIReceiveDate,InvoiceNo,InvoiceDate,isnull(LCNO,'NONLC') as LCNO,isnull(LCDate,getdate()) as LCDate, " +
                       " c.OrderID,OrderNo,OrderPlaceDate,c.PSIID,PSINO,f.CreateDate as PSIDate,c.SupplierID,SupplierName,CompanyID,CompanyCode,CompanyName, " +
                       " ExpectedHOArrivalWeek,ExpectedHOArrivalYear, a.Status,StatusName=CASE When a.Status=1 then 'PSI'  " +
                       " When a.Status=2 then 'OrderPlace'  " +
                       " When a.Status=3 then 'PIReceive' When a.Status=4 then 'LCProcessing'    " +
                       " When a.Status=5 then 'LCOpening' When a.Status=6 then 'Shipment'    " +
                       " When a.Status=7 then 'CustomerClearance' When a.Status=8 then 'Release'    " +
                       " When a.Status=9 then 'ReadyForGRD' When a.Status=10 then 'Billing'    " +
                       " else 'Others' end " +
                       " From t_SCMShipment a,t_SCMPI b,t_SCMOrder c,t_Company d,t_Supplier e,t_SCMPSI f " +
                       " where a.PIID=b.PIID and b.OrderID=c.OrderID and f.PSIID=c.PSIID " +
                       " and f.Company=d.CompanyID and c.SupplierID=e.SupplierID ";
            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND ShipmentDate between '" + dFromDate + "' and '" + dToDate + "' and ShipmentDate<'" + dToDate + "' ";
            }

            if (sShipmentNo != "")
            {
                sSql = sSql + " AND ShipmentNo like '%" + sShipmentNo + "%'";
            }
            if (sInvoiceNo != "")
            {
                sSql = sSql + " AND InvoiceNo like '%" + sInvoiceNo + "%'";
            }
            if (sLCNO != "")
            {
                sSql = sSql + " AND LCNo like '%" + sLCNO + "%'";
            }

            if (sOrderNo != "")
            {
                sSql = sSql + " AND OrderNo like '%" + sOrderNo + "%'";
            }

            if (sPSINO != "")
            {
                sSql = sSql + " AND PSINO like '%" + sPSINO + "%'";
            }

            if (nSupplier != -1)
            {
                sSql = sSql + " AND c.SupplierID =" + nSupplier + "";
            }

            if (nCompany != -1)
            {
                sSql = sSql + " AND CompanyID=" + nCompany + "";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND  a.Status=" + nStatus + "";
            }
            sSql = sSql + " Order by ShipmentID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMShipment oSCMShipment = new SCMShipment();

                    oSCMShipment.ShipmentID = int.Parse(reader["ShipmentID"].ToString());
                    oSCMShipment.ShipmentNo = (reader["ShipmentNo"].ToString());
                    oSCMShipment.ShipmentDate = Convert.ToDateTime(reader["ShipmentDate"].ToString());
                    oSCMShipment.PIID = int.Parse(reader["PIID"].ToString());
                    oSCMShipment.PINo = (reader["PINo"].ToString());
                    oSCMShipment.PIReceiveDate = Convert.ToDateTime(reader["PIReceiveDate"].ToString());
                    oSCMShipment.InvoiceNo = (reader["InvoiceNo"].ToString());
                    oSCMShipment.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    if (reader["LCNo"] != DBNull.Value)
                        oSCMShipment.LCNo = (reader["LCNo"].ToString());
                    else oSCMShipment.LCNo = "'NonLC'";
                    oSCMShipment.LCDate = Convert.ToDateTime(reader["LCDate"].ToString());
                    oSCMShipment.OrderID = int.Parse(reader["OrderID"].ToString());
                    oSCMShipment.OrderNo = (reader["OrderNo"].ToString());
                    oSCMShipment.OrderPlaceDate = Convert.ToDateTime(reader["OrderPlaceDate"].ToString());
                    oSCMShipment.PSIID = int.Parse(reader["PSIID"].ToString());
                    oSCMShipment.PSINo = (reader["PSINo"].ToString());
                    oSCMShipment.PSIDate = Convert.ToDateTime(reader["PSIDate"].ToString());
                    oSCMShipment.SupplierID = int.Parse(reader["SupplierID"].ToString());
                    oSCMShipment.SupplierName = (reader["SupplierName"].ToString());
                    oSCMShipment.CompanyID = int.Parse(reader["CompanyID"].ToString());
                    oSCMShipment.CompanyName = (reader["CompanyCode"].ToString());
                    oSCMShipment.ExpectedHOArrivalWeek = int.Parse(reader["ExpectedHOArrivalWeek"].ToString());
                    oSCMShipment.ExpectedHOArrivalYear = int.Parse(reader["ExpectedHOArrivalYear"].ToString());
                    oSCMShipment.Status = int.Parse(reader["Status"].ToString());
                    oSCMShipment.StatusName = (reader["StatusName"].ToString());

                    InnerList.Add(oSCMShipment);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetShipment()
        {
            InnerList.Clear();
            SCMShipment oSCMShipment;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select ShipmentID,ShipmentNo,ShipmentDate,'Shipment' as Description  "+
                        "From t_SCMShipment where Status in (9,10)   "+
                        " and ShipmentID in (  "+
                        " Select ShipmentID From (   "+
                        " Select ShipmentID,(ShipmentQty-GRDQty) RestQty From    "+
                        " (Select a.ShipmentID,ShipmentQty,isnull(GRDQty,0) GRDQty From    "+
                        " (Select ShipmentID,sum(ShipmentQty) ShipmentQty From t_SCMShipmentItem    "+
                        " group by ShipmentID) a   "+
                        " left outer join    "+
                        " (Select ShipmentID,sum(Qty) GRDQty from t_SCMGRD a,t_ProductStockTranItem b   "+
                        " where a.TranID=b.TranID group by ShipmentID) b   "+
                        " on a.ShipmentID=b.ShipmentID) xx) Main where RestQty>0)  "+
                        " Union All  "+
                        " Select ID,ChallanNo,ChallanDate,'Challan' as Description From t_ProductionLotDelivery where ID in (  "+
                        " Select ChallanID From (   "+
                        " Select ChallanID,(ChallanQty-GRDQty) RestQty From    "+
                        " (Select ID as ChallanID,ChallanQty,isnull(GRDQty,0) GRDQty From    "+
                        " (Select ID,sum(ChallanQty) ChallanQty From t_ProductionLotDeliveryItem    "+
                        " group by ID) a   "+
                        " left outer join    "+
                        " (Select ChallanID,sum(Qty) GRDQty from t_SCMGRD a,t_ProductStockTranItem b   "+
                        " where a.TranID=b.TranID and ChallanID is not null group by ChallanID ) b   " +
                        " on a.ID=b.ChallanID) xx) Main where RestQty>0) and CustomerID=759 order by ShipmentNo Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oSCMShipment = new SCMShipment();
                    oSCMShipment.ShipmentID = int.Parse(reader["ShipmentID"].ToString());
                    oSCMShipment.ShipmentNo = (string)reader["ShipmentNo"].ToString();
                    oSCMShipment.ShipmentDate = Convert.ToDateTime(reader["ShipmentDate"].ToString());
                    oSCMShipment.Description = (string)reader["Description"].ToString();

                    InnerList.Add(oSCMShipment);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetBEILShipment()
        {
            InnerList.Clear();
            SCMShipment oSCMShipment;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From t_SCMShipment where Status in (9,10) " +
                        " and ShipmentID in ( " +
                        " Select ShipmentID From ( " +
                        " Select ShipmentID,(ShipmentQty-GRDQty) RestQty From  " +
                        " (Select a.ShipmentID,ShipmentQty,isnull(GRDQty,0) GRDQty From  " +
                        " (Select ShipmentID,sum(ShipmentQty) ShipmentQty From t_SCMShipmentBOMItem  " +
                        " group by ShipmentID) a " +
                        " left outer join  " +
                        " (Select ShipmentID,sum(Quantity) GRDQty from t_SCMBOMStockTran a,t_SCMBOMStockTranItem b  " +
                        " where a.TranID=b.TranID group by ShipmentID) b  " +
                        " on a.ShipmentID=b.ShipmentID) xx) Main where RestQty>0)";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oSCMShipment = new SCMShipment();
                    oSCMShipment.ShipmentID = int.Parse(reader["ShipmentID"].ToString());
                    oSCMShipment.ShipmentNo = (string)reader["ShipmentNo"].ToString();

                    InnerList.Add(oSCMShipment);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GETText(int nShipmentID,string sCompanyCode)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            if (sCompanyCode == "TEL")
            {
                sSql = "Select 'Delivery Pre-Alert:' as Description " +
                            "Union All " +
                            "Select 'ShipmentNo:'+' '+ShipmentNo++'||Date:'+CONVERT(VARCHAR(11),ShipmentDate,106)+ ', '+'InvoiceNo:'+' '+ " +
                            "InvoiceNo+'||Date:'+CONVERT(VARCHAR(11),InvoiceDate,106)  " +
                            "+', '+ 'LCNo:'+' '+isnull(LCNo,'NonLC')+'||Date:'+isnull(CONVERT(VARCHAR(11),LCDate,106),'') as Description  " +
                            "From t_SCMShipment a,t_SCMPI b where a.PIID=b.PIID and ShipmentID= " + nShipmentID + " " +
                            "Union All  " +
                            "Select 'Product Details:' " +
                            "Union All " +
                            "Select BrandDesc +'-'+ MAGName+'-'+CAST(sum(ShipmentQty) AS varchar(100))+'Pcs'   " +
                            "as Description   " +
                            "from t_SCMShipmentItem a,v_ProductDetails b   " +
                            "where a.ProductID=b.ProductID and ShipmentID= " + nShipmentID + "  " +
                            "group by MAGName,BrandDesc  " +
                            "Union All " +
                            "Select 'Total:'+' '+CAST(sum(ShipmentQty) AS varchar(100))+'Pcs'    " +
                            "as Description  " +
                            "from t_SCMShipmentItem a,v_ProductDetails b  " +
                            "where a.ProductID=b.ProductID and ShipmentID= " + nShipmentID + "";

            }
            
            else
            {
                sSql = "Select 'Delivery Pre-Alert:' as Description  " +
                            "Union All   " +
                            "Select 'ShipmentNo:'+' '+ShipmentNo++'||Date:'+CONVERT(VARCHAR(11),ShipmentDate,106)+ ', '+'InvoiceNo:'+' '+   " +
                            "InvoiceNo+'||Date:'+CONVERT(VARCHAR(11),InvoiceDate,106)    " +
                            "+', '+ 'LCNo:'+' '+isnull(LCNo,'NonLC')+'||Date:'+isnull(CONVERT(VARCHAR(11),LCDate,106),'') as Description    " +
                            "From t_SCMShipment a,t_SCMPI b where a.PIID=b.PIID and ShipmentID=  " + nShipmentID + "   " +
                            "Union All    " +
                            "Select 'Product Details:'   " +
                            "Union All   " +
                            "Select BrandDesc +'-'+ MAGName+'-'+CAST(sum(ShipmentQty) AS varchar(100))+'Pcs BOM Item'     " +
                            "as Description    " +
                            "From t_SCMShipmentBOMItem a,t_ProductBom b,v_ProductDetails c  " +
                            "where a.BOMID=b.BOMID and a.ProductID=c.ProductID and ShipmentID=  " + nShipmentID + "  " +
                            "group by MAGName,BrandDesc   " +
                            "Union All   " +
                            "Select 'Total:'+' '+CAST(sum(ShipmentQty) AS varchar(100))+'Pcs'      " +
                            "as Description   " +
                            "From t_SCMShipmentBOMItem a,t_ProductBom b,v_ProductDetails c  " +
                            "where a.BOMID=b.BOMID and a.ProductID=c.ProductID and ShipmentID=  " + nShipmentID + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMShipment oSCMShipment = new SCMShipment();
                    oSCMShipment.Text = (string)reader["Description"];
                    
                    InnerList.Add(oSCMShipment);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GETGRDText(int nTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "Select 'GRD Alert:' as Description  " +
                    "Union All   " +
                    "Select 'GRD#:'+' '+TranNo+' Date:'+CONVERT(VARCHAR(11),TranDate,106)+ '||'+'Shipment#:'+' '+ShipmentNo+' Date:'+CONVERT(VARCHAR(11),ShipmentDate,106)+ '||'+'Invoice#:'+' '+   " +
                    "InvoiceNo +' Date:'+CONVERT(VARCHAR(11),InvoiceDate,106)    " +
                    "+ '||'+ 'LC#:'+' '+isnull(b.LCNo,'NonLC')+' Date:'+isnull(CONVERT(VARCHAR(11),b.LCDate,106),'') as Description    " +
                    "From t_SCMShipment a,t_SCMPI b,t_SCMGRD c,t_ProductStockTran d  " +
                    "where a.PIID=b.PIID and a.ShipmentID=c.ShipmentID and c.TranID=d.TranID  " +
                    "and d.TranID=" + nTranID + "  " +
                    "Union All  " +
                    "Select 'Product Details:'   " +
                    "Union All    " +
                    "Select BrandDesc +'('+ MAGName+'): Total Shipment-'+CAST(sum(ShipmentQty) AS varchar(100))+   " +
                    "+ ',This GRD-'+CAST(sum(d.Qty) AS varchar(100))+',Total GRD-'+CAST(sum(e.TotalGRD) AS varchar(100))+' (Pcs)'   " +
                    "as Description     " +
                    "from t_SCMShipmentItem a,v_ProductDetails b,(Select distinct TranID,ShipmentID   " +
                    "From t_SCMGRD where isnull(ChallanID,0)=0) c,t_ProductStockTranItem d,  " +
                    "(  " +
                    "Select a.ShipmentID,a.ProductID,sum(Qty) TotalGRD From   " +
                    "t_SCMShipmentItem a,(Select distinct TranID,ShipmentID   " +
                    "From t_SCMGRD where isnull(ChallanID,0)=0) c,  " +
                    "t_ProductStockTranItem d  " +
                    "where a.ShipmentID=c.ShipmentID and c.TranID=d.TranID and a.ProductID=d.ProductID  " +
                    "group by a.ShipmentID,a.ProductID  " +
                    ") e  " +
                    "where a.ProductID=b.ProductID and   " +
                    "a.ShipmentID=c.ShipmentID and c.TranID=d.TranID  " +
                    "and a.ProductID=e.ProductID and a.ShipmentID=e.ShipmentID  " +
                    "and a.ProductID=d.ProductID and d.TranID=" + nTranID + "  " +
                    "group by MAGName,BrandDesc";

            

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMShipment oSCMShipment = new SCMShipment();
                    oSCMShipment.Text = (string)reader["Description"];

                    InnerList.Add(oSCMShipment);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GETSMSMobileNo(int nSMSgroupID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_SMSGroupPerson a,t_MobilePhone b,t_SMSGroup c  " +
                          "where a.MobileID=b.MobileID and a.SMSGroupID=c.SMSgroupID  " +
                          "and a.SMSGroupID=" + nSMSgroupID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMShipment oSCMShipment = new SCMShipment();
                    oSCMShipment.MobileNo = (string)reader["MobileNo"];

                    InnerList.Add(oSCMShipment);
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
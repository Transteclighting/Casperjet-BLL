using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class WarrantyClaimDistribution
    {
        private int _nID;
        private int _nJobID;
        private int _nSupplierID;
        private double _ServiceCharge;
        private double _SparePartsCharge;
        private double _TransportationCharge;
        private double _OtherCharge;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for JobID
        // </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
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
        // Get set property for ServiceCharge
        // </summary>
        public double ServiceCharge
        {
            get { return _ServiceCharge; }
            set { _ServiceCharge = value; }
        }

        // <summary>
        // Get set property for SparePartsCharge
        // </summary>
        public double SparePartsCharge
        {
            get { return _SparePartsCharge; }
            set { _SparePartsCharge = value; }
        }

        // <summary>
        // Get set property for TransportationCharge
        // </summary>
        public double TransportationCharge
        {
            get { return _TransportationCharge; }
            set { _TransportationCharge = value; }
        }

        // <summary>
        // Get set property for OtherCharge
        // </summary>
        public double OtherCharge
        {
            get { return _OtherCharge; }
            set { _OtherCharge = value; }
        }

        //public void Add(WarrantyParamDetails oWarrantyParamDetails)
        //{
        //    InnerList.Add(oWarrantyParamDetails);
        //}

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_WarrantyClaimDistribution";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = Convert.ToInt32(maxID) + 1;
                }
                _nID = nMaxID;
                sSql = "INSERT INTO t_WarrantyClaimDistribution (ID, JobID, SupplierID, ServiceCharge, SparePartsCharge, TransportationCharge, OtherCharge) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                cmd.Parameters.AddWithValue("ServiceCharge", _ServiceCharge);
                cmd.Parameters.AddWithValue("SparePartsCharge", _SparePartsCharge);
                cmd.Parameters.AddWithValue("TransportationCharge", _TransportationCharge);
                cmd.Parameters.AddWithValue("OtherCharge", _OtherCharge);

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
                sSql = "UPDATE t_WarrantyClaimDistribution SET JobID = ?, SupplierID = ?, ServiceCharge = ?, SparePartsCharge = ?, TransportationCharge = ?, OtherCharge = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                cmd.Parameters.AddWithValue("ServiceCharge", _ServiceCharge);
                cmd.Parameters.AddWithValue("SparePartsCharge", _SparePartsCharge);
                cmd.Parameters.AddWithValue("TransportationCharge", _TransportationCharge);
                cmd.Parameters.AddWithValue("OtherCharge", _OtherCharge);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "DELETE FROM t_WarrantyClaimDistribution WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
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
                cmd.CommandText = "SELECT * FROM t_WarrantyClaimDistribution where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nJobID = (int)reader["JobID"];
                    _nSupplierID = (int)reader["SupplierID"];
                    _ServiceCharge = Convert.ToDouble(reader["ServiceCharge"].ToString());
                    _SparePartsCharge = Convert.ToDouble(reader["SparePartsCharge"].ToString());
                    _TransportationCharge = Convert.ToDouble(reader["TransportationCharge"].ToString());
                    _OtherCharge = Convert.ToDouble(reader["OtherCharge"].ToString());
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
    public class WarrantyClaimDistributions : CollectionBase
    {
        public WarrantyClaimDistribution this[int i]
        {
            get { return (WarrantyClaimDistribution)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(WarrantyClaimDistribution oWarrantyClaimDistribution)
        {
            InnerList.Add(oWarrantyClaimDistribution);
        }
        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
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
            string sSql = "SELECT * FROM t_WarrantyClaimDistribution";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    WarrantyClaimDistribution oWarrantyClaimDistribution = new WarrantyClaimDistribution();
                    oWarrantyClaimDistribution.ID = (int)reader["ID"];
                    oWarrantyClaimDistribution.JobID = (int)reader["JobID"];
                    oWarrantyClaimDistribution.SupplierID = (int)reader["SupplierID"];
                    oWarrantyClaimDistribution.ServiceCharge = Convert.ToDouble(reader["ServiceCharge"].ToString());
                    oWarrantyClaimDistribution.SparePartsCharge = Convert.ToDouble(reader["SparePartsCharge"].ToString());
                    oWarrantyClaimDistribution.TransportationCharge = Convert.ToDouble(reader["TransportationCharge"].ToString());
                    oWarrantyClaimDistribution.OtherCharge = Convert.ToDouble(reader["OtherCharge"].ToString());
                    InnerList.Add(oWarrantyClaimDistribution);
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

    public class CSDJobsForWarranty
    {
        private int _nJobID;
        private string _sProductSerialNo;
        private string _sOriginalProductSerialNo;
        private string _sInvoiceNo;
        private DateTime _dInvoiceDate;
        private int _nSalesChannelID;
        private int _nSalesPointID;
        private string _sJobNo;
        private int _nServiceType;
        private int _nJobType;
        private int _nWorkshopID;
        private string _sReferenceJobNo;
        private string _sGSPNJobNo;
        private int _nPriority;
        private DateTime _dLastFeedBackDate;
        private DateTime _dVisitingTimeFrom;
        private DateTime _dVisitingTimeTo;
        private object _dDeliveryDate;
        private string _sRemarks;
        private int _nProductID;
        private int _nFullOrAccessories;
        private int _nAccessoryID;
        private int _nPrimaryFaultID;
        private int _nOwnOrCustomerSet;
        private int _nRefChannelID;
        private int _nRefSalesPointID;
        private string _sCustomerName;
        private string _sTelePhone;
        private string _sMobileNo;
        private string _sCustomerAddress;
        private int _nThanaID;
        private string _sEmail;
        private string _sNationalID;
        private int _nStatus;
        private int _nSubStatus;
        private string _sStatusReason;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nAssignTo;
        private int _nAssignLeadMinute;
        private int _nOwnOrOtherTechnician;
        private int _nReceivingTransportationMode;
        private int _nReceivingCourierID;
        private string _sReceivingInstrumentNo;
        private double _ReceivingCost;
        private int _nDeliveryTransportationMode;
        private int _nDeliveryCourierID;
        private string _sDeliveryInstrumentNo;
        private double _DeliveryCost;
        private int _nProductLocation;
        private int _nProductMovementStatus;
        private int _nSparePartsUsed;
        private int _nIsStoreClearance;
        private int _nActualFaultID;
        private int _nInterSerJobType;
        private int _nIsDelivered;
        private int _nIsReplacement;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private int _nIsHappyCall;
        private int _nHaveBackupSet;
        private int _nProductPhysicalLocation;
        private DateTime _dVisitingDate;
        private double _EstSpAmount;
        private double _EstScAmount;
        private double _TPMatCharge;
        private double _TPGasCharge;
        private double _TPOtherCharge;
        private int _nCustomerArchiveFlag;
        private int _nIsRemoteServiceProvided;
        private double _RemoteServiceProvidedAmount;
        private DateTime _dRemoteServiceProvidedDate;
        private int _nFlag;
        private double _SparePartsCharge;
        private double _ServiceCharge;
        private double _TransportationCharge;
        private double _OtherCharge;
        private int _nIsWarrantyDistribution;


        public int IsWarrantyDistribution
        {
            get { return _nIsWarrantyDistribution; }
            set { _nIsWarrantyDistribution = value; }
        }

        public double SparePartsCharge
        {
            get { return _SparePartsCharge; }
            set { _SparePartsCharge = value; }
        }

        public double ServiceCharge
        {
            get { return _ServiceCharge; }
            set { _ServiceCharge = value; }
        }

        public double TransportationCharge
        {
            get { return _TransportationCharge; }
            set { _TransportationCharge = value; }
        }

        public double OtherCharge
        {
            get { return _OtherCharge; }
            set { _OtherCharge = value; }
        }
        // <summary>
        // Get set property for JobID
        // </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }

        // <summary>
        // Get set property for ProductSerialNo
        // </summary>
        public string ProductSerialNo
        {
            get { return _sProductSerialNo; }
            set { _sProductSerialNo = value.Trim(); }
        }

        // <summary>
        // Get set property for OriginalProductSerialNo
        // </summary>
        public string OriginalProductSerialNo
        {
            get { return _sOriginalProductSerialNo; }
            set { _sOriginalProductSerialNo = value.Trim(); }
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
        // Get set property for SalesChannelID
        // </summary>
        public int SalesChannelID
        {
            get { return _nSalesChannelID; }
            set { _nSalesChannelID = value; }
        }

        // <summary>
        // Get set property for SalesPointID
        // </summary>
        public int SalesPointID
        {
            get { return _nSalesPointID; }
            set { _nSalesPointID = value; }
        }

        // <summary>
        // Get set property for JobNo
        // </summary>
        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value.Trim(); }
        }

        // <summary>
        // Get set property for ServiceType
        // </summary>
        public int ServiceType
        {
            get { return _nServiceType; }
            set { _nServiceType = value; }
        }

        // <summary>
        // Get set property for JobType
        // </summary>
        public int JobType
        {
            get { return _nJobType; }
            set { _nJobType = value; }
        }

        // <summary>
        // Get set property for WorkshopID
        // </summary>
        public int WorkshopID
        {
            get { return _nWorkshopID; }
            set { _nWorkshopID = value; }
        }

        // <summary>
        // Get set property for ReferenceJobNo
        // </summary>
        public string ReferenceJobNo
        {
            get { return _sReferenceJobNo; }
            set { _sReferenceJobNo = value.Trim(); }
        }

        // <summary>
        // Get set property for GSPNJobNo
        // </summary>
        public string GSPNJobNo
        {
            get { return _sGSPNJobNo; }
            set { _sGSPNJobNo = value.Trim(); }
        }

        // <summary>
        // Get set property for Priority
        // </summary>
        public int Priority
        {
            get { return _nPriority; }
            set { _nPriority = value; }
        }

        // <summary>
        // Get set property for LastFeedBackDate
        // </summary>
        public DateTime LastFeedBackDate
        {
            get { return _dLastFeedBackDate; }
            set { _dLastFeedBackDate = value; }
        }

        // <summary>
        // Get set property for VisitingTimeFrom
        // </summary>
        public DateTime VisitingTimeFrom
        {
            get { return _dVisitingTimeFrom; }
            set { _dVisitingTimeFrom = value; }
        }

        // <summary>
        // Get set property for VisitingTimeTo
        // </summary>
        public DateTime VisitingTimeTo
        {
            get { return _dVisitingTimeTo; }
            set { _dVisitingTimeTo = value; }
        }

        // <summary>
        // Get set property for DeliveryDate
        // </summary>
        public object DeliveryDate
        {
            get { return _dDeliveryDate; }
            set { _dDeliveryDate = value; }
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
        // Get set property for ProductID
        // </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        // <summary>
        // Get set property for FullOrAccessories
        // </summary>
        public int FullOrAccessories
        {
            get { return _nFullOrAccessories; }
            set { _nFullOrAccessories = value; }
        }

        // <summary>
        // Get set property for AccessoryID
        // </summary>
        public int AccessoryID
        {
            get { return _nAccessoryID; }
            set { _nAccessoryID = value; }
        }

        // <summary>
        // Get set property for PrimaryFaultID
        // </summary>
        public int PrimaryFaultID
        {
            get { return _nPrimaryFaultID; }
            set { _nPrimaryFaultID = value; }
        }

        // <summary>
        // Get set property for OwnOrCustomerSet
        // </summary>
        public int OwnOrCustomerSet
        {
            get { return _nOwnOrCustomerSet; }
            set { _nOwnOrCustomerSet = value; }
        }

        // <summary>
        // Get set property for RefChannelID
        // </summary>
        public int RefChannelID
        {
            get { return _nRefChannelID; }
            set { _nRefChannelID = value; }
        }

        // <summary>
        // Get set property for RefSalesPointID
        // </summary>
        public int RefSalesPointID
        {
            get { return _nRefSalesPointID; }
            set { _nRefSalesPointID = value; }
        }

        // <summary>
        // Get set property for CustomerName
        // </summary>
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }

        // <summary>
        // Get set property for TelePhone
        // </summary>
        public string TelePhone
        {
            get { return _sTelePhone; }
            set { _sTelePhone = value.Trim(); }
        }

        // <summary>
        // Get set property for MobileNo
        // </summary>
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value.Trim(); }
        }

        // <summary>
        // Get set property for CustomerAddress
        // </summary>
        public string CustomerAddress
        {
            get { return _sCustomerAddress; }
            set { _sCustomerAddress = value.Trim(); }
        }

        // <summary>
        // Get set property for ThanaID
        // </summary>
        public int ThanaID
        {
            get { return _nThanaID; }
            set { _nThanaID = value; }
        }

        // <summary>
        // Get set property for Email
        // </summary>
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value.Trim(); }
        }

        // <summary>
        // Get set property for NationalID
        // </summary>
        public string NationalID
        {
            get { return _sNationalID; }
            set { _sNationalID = value.Trim(); }
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
        // Get set property for SubStatus
        // </summary>
        public int SubStatus
        {
            get { return _nSubStatus; }
            set { _nSubStatus = value; }
        }

        // <summary>
        // Get set property for StatusReason
        // </summary>
        public string StatusReason
        {
            get { return _sStatusReason; }
            set { _sStatusReason = value.Trim(); }
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
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        // <summary>
        // Get set property for AssignTo
        // </summary>
        public int AssignTo
        {
            get { return _nAssignTo; }
            set { _nAssignTo = value; }
        }

        // <summary>
        // Get set property for AssignLeadMinute
        // </summary>
        public int AssignLeadMinute
        {
            get { return _nAssignLeadMinute; }
            set { _nAssignLeadMinute = value; }
        }

        // <summary>
        // Get set property for OwnOrOtherTechnician
        // </summary>
        public int OwnOrOtherTechnician
        {
            get { return _nOwnOrOtherTechnician; }
            set { _nOwnOrOtherTechnician = value; }
        }

        // <summary>
        // Get set property for ReceivingTransportationMode
        // </summary>
        public int ReceivingTransportationMode
        {
            get { return _nReceivingTransportationMode; }
            set { _nReceivingTransportationMode = value; }
        }

        // <summary>
        // Get set property for ReceivingCourierID
        // </summary>
        public int ReceivingCourierID
        {
            get { return _nReceivingCourierID; }
            set { _nReceivingCourierID = value; }
        }

        // <summary>
        // Get set property for ReceivingInstrumentNo
        // </summary>
        public string ReceivingInstrumentNo
        {
            get { return _sReceivingInstrumentNo; }
            set { _sReceivingInstrumentNo = value.Trim(); }
        }

        // <summary>
        // Get set property for ReceivingCost
        // </summary>
        public double ReceivingCost
        {
            get { return _ReceivingCost; }
            set { _ReceivingCost = value; }
        }

        // <summary>
        // Get set property for DeliveryTransportationMode
        // </summary>
        public int DeliveryTransportationMode
        {
            get { return _nDeliveryTransportationMode; }
            set { _nDeliveryTransportationMode = value; }
        }

        // <summary>
        // Get set property for DeliveryCourierID
        // </summary>
        public int DeliveryCourierID
        {
            get { return _nDeliveryCourierID; }
            set { _nDeliveryCourierID = value; }
        }

        // <summary>
        // Get set property for DeliveryInstrumentNo
        // </summary>
        public string DeliveryInstrumentNo
        {
            get { return _sDeliveryInstrumentNo; }
            set { _sDeliveryInstrumentNo = value.Trim(); }
        }

        // <summary>
        // Get set property for DeliveryCost
        // </summary>
        public double DeliveryCost
        {
            get { return _DeliveryCost; }
            set { _DeliveryCost = value; }
        }

        // <summary>
        // Get set property for ProductLocation
        // </summary>
        public int ProductLocation
        {
            get { return _nProductLocation; }
            set { _nProductLocation = value; }
        }

        // <summary>
        // Get set property for ProductMovementStatus
        // </summary>
        public int ProductMovementStatus
        {
            get { return _nProductMovementStatus; }
            set { _nProductMovementStatus = value; }
        }

        // <summary>
        // Get set property for SparePartsUsed
        // </summary>
        public int SparePartsUsed
        {
            get { return _nSparePartsUsed; }
            set { _nSparePartsUsed = value; }
        }

        // <summary>
        // Get set property for IsStoreClearance
        // </summary>
        public int IsStoreClearance
        {
            get { return _nIsStoreClearance; }
            set { _nIsStoreClearance = value; }
        }

        // <summary>
        // Get set property for ActualFaultID
        // </summary>
        public int ActualFaultID
        {
            get { return _nActualFaultID; }
            set { _nActualFaultID = value; }
        }

        // <summary>
        // Get set property for InterSerJobType
        // </summary>
        public int InterSerJobType
        {
            get { return _nInterSerJobType; }
            set { _nInterSerJobType = value; }
        }

        // <summary>
        // Get set property for IsDelivered
        // </summary>
        public int IsDelivered
        {
            get { return _nIsDelivered; }
            set { _nIsDelivered = value; }
        }

        // <summary>
        // Get set property for IsReplacement
        // </summary>
        public int IsReplacement
        {
            get { return _nIsReplacement; }
            set { _nIsReplacement = value; }
        }

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
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
        // Get set property for IsHappyCall
        // </summary>
        public int IsHappyCall
        {
            get { return _nIsHappyCall; }
            set { _nIsHappyCall = value; }
        }

        // <summary>
        // Get set property for HaveBackupSet
        // </summary>
        public int HaveBackupSet
        {
            get { return _nHaveBackupSet; }
            set { _nHaveBackupSet = value; }
        }

        // <summary>
        // Get set property for ProductPhysicalLocation
        // </summary>
        public int ProductPhysicalLocation
        {
            get { return _nProductPhysicalLocation; }
            set { _nProductPhysicalLocation = value; }
        }

        // <summary>
        // Get set property for VisitingDate
        // </summary>
        public DateTime VisitingDate
        {
            get { return _dVisitingDate; }
            set { _dVisitingDate = value; }
        }

        // <summary>
        // Get set property for EstSpAmount
        // </summary>
        public double EstSpAmount
        {
            get { return _EstSpAmount; }
            set { _EstSpAmount = value; }
        }

        // <summary>
        // Get set property for EstScAmount
        // </summary>
        public double EstScAmount
        {
            get { return _EstScAmount; }
            set { _EstScAmount = value; }
        }

        // <summary>
        // Get set property for TPMatCharge
        // </summary>
        public double TPMatCharge
        {
            get { return _TPMatCharge; }
            set { _TPMatCharge = value; }
        }

        // <summary>
        // Get set property for TPGasCharge
        // </summary>
        public double TPGasCharge
        {
            get { return _TPGasCharge; }
            set { _TPGasCharge = value; }
        }

        // <summary>
        // Get set property for TPOtherCharge
        // </summary>
        public double TPOtherCharge
        {
            get { return _TPOtherCharge; }
            set { _TPOtherCharge = value; }
        }

        // <summary>
        // Get set property for CustomerArchiveFlag
        // </summary>
        public int CustomerArchiveFlag
        {
            get { return _nCustomerArchiveFlag; }
            set { _nCustomerArchiveFlag = value; }
        }

        // <summary>
        // Get set property for IsRemoteServiceProvided
        // </summary>
        public int IsRemoteServiceProvided
        {
            get { return _nIsRemoteServiceProvided; }
            set { _nIsRemoteServiceProvided = value; }
        }

        // <summary>
        // Get set property for RemoteServiceProvidedAmount
        // </summary>
        public double RemoteServiceProvidedAmount
        {
            get { return _RemoteServiceProvidedAmount; }
            set { _RemoteServiceProvidedAmount = value; }
        }

        // <summary>
        // Get set property for RemoteServiceProvidedDate
        // </summary>
        public DateTime RemoteServiceProvidedDate
        {
            get { return _dRemoteServiceProvidedDate; }
            set { _dRemoteServiceProvidedDate = value; }
        }

        // <summary>
        // Get set property for Flag
        // </summary>
        public int Flag
        {
            get { return _nFlag; }
            set { _nFlag = value; }
        }

        public void Add()
        {
            int nMaxJobID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([JobID]) FROM t_CSDJob";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxJobID = 1;
                }
                else
                {
                    nMaxJobID = Convert.ToInt32(maxID) + 1;
                }
                _nJobID = nMaxJobID;
                sSql = "INSERT INTO t_CSDJob (JobID, ProductSerialNo, OriginalProductSerialNo, InvoiceNo, InvoiceDate, SalesChannelID, SalesPointID, JobNo, ServiceType, JobType, WorkshopID, ReferenceJobNo, GSPNJobNo, Priority, LastFeedBackDate, VisitingTimeFrom, VisitingTimeTo, DeliveryDate, Remarks, ProductID, FullOrAccessories, AccessoryID, PrimaryFaultID, OwnOrCustomerSet, RefChannelID, RefSalesPointID, CustomerName, TelePhone, MobileNo, CustomerAddress, ThanaID, Email, NationalID, Status, SubStatus, StatusReason, CreateUserID, CreateDate, AssignTo, AssignLeadMinute, OwnOrOtherTechnician, ReceivingTransportationMode, ReceivingCourierID, ReceivingInstrumentNo, ReceivingCost, DeliveryTransportationMode, DeliveryCourierID, DeliveryInstrumentNo, DeliveryCost, ProductLocation, ProductMovementStatus, SparePartsUsed, IsStoreClearance, ActualFaultID, InterSerJobType, IsDelivered, IsReplacement, UpdateUserID, UpdateDate, IsHappyCall, HaveBackupSet, ProductPhysicalLocation, VisitingDate, EstSpAmount, EstScAmount, TPMatCharge, TPGasCharge, TPOtherCharge, CustomerArchiveFlag, IsRemoteServiceProvided, RemoteServiceProvidedAmount, RemoteServiceProvidedDate, Flag) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);
                cmd.Parameters.AddWithValue("OriginalProductSerialNo", _sOriginalProductSerialNo);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("SalesChannelID", _nSalesChannelID);
                cmd.Parameters.AddWithValue("SalesPointID", _nSalesPointID);
                cmd.Parameters.AddWithValue("JobNo", _sJobNo);
                cmd.Parameters.AddWithValue("ServiceType", _nServiceType);
                cmd.Parameters.AddWithValue("JobType", _nJobType);
                cmd.Parameters.AddWithValue("WorkshopID", _nWorkshopID);
                cmd.Parameters.AddWithValue("ReferenceJobNo", _sReferenceJobNo);
                cmd.Parameters.AddWithValue("GSPNJobNo", _sGSPNJobNo);
                cmd.Parameters.AddWithValue("Priority", _nPriority);
                cmd.Parameters.AddWithValue("LastFeedBackDate", _dLastFeedBackDate);
                cmd.Parameters.AddWithValue("VisitingTimeFrom", _dVisitingTimeFrom);
                cmd.Parameters.AddWithValue("VisitingTimeTo", _dVisitingTimeTo);
                cmd.Parameters.AddWithValue("DeliveryDate", _dDeliveryDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("FullOrAccessories", _nFullOrAccessories);
                cmd.Parameters.AddWithValue("AccessoryID", _nAccessoryID);
                cmd.Parameters.AddWithValue("PrimaryFaultID", _nPrimaryFaultID);
                cmd.Parameters.AddWithValue("OwnOrCustomerSet", _nOwnOrCustomerSet);
                cmd.Parameters.AddWithValue("RefChannelID", _nRefChannelID);
                cmd.Parameters.AddWithValue("RefSalesPointID", _nRefSalesPointID);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("TelePhone", _sTelePhone);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("CustomerAddress", _sCustomerAddress);
                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("NationalID", _sNationalID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("SubStatus", _nSubStatus);
                cmd.Parameters.AddWithValue("StatusReason", _sStatusReason);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("AssignTo", _nAssignTo);
                cmd.Parameters.AddWithValue("AssignLeadMinute", _nAssignLeadMinute);
                cmd.Parameters.AddWithValue("OwnOrOtherTechnician", _nOwnOrOtherTechnician);
                cmd.Parameters.AddWithValue("ReceivingTransportationMode", _nReceivingTransportationMode);
                cmd.Parameters.AddWithValue("ReceivingCourierID", _nReceivingCourierID);
                cmd.Parameters.AddWithValue("ReceivingInstrumentNo", _sReceivingInstrumentNo);
                cmd.Parameters.AddWithValue("ReceivingCost", _ReceivingCost);
                cmd.Parameters.AddWithValue("DeliveryTransportationMode", _nDeliveryTransportationMode);
                cmd.Parameters.AddWithValue("DeliveryCourierID", _nDeliveryCourierID);
                cmd.Parameters.AddWithValue("DeliveryInstrumentNo", _sDeliveryInstrumentNo);
                cmd.Parameters.AddWithValue("DeliveryCost", _DeliveryCost);
                cmd.Parameters.AddWithValue("ProductLocation", _nProductLocation);
                cmd.Parameters.AddWithValue("ProductMovementStatus", _nProductMovementStatus);
                cmd.Parameters.AddWithValue("SparePartsUsed", _nSparePartsUsed);
                cmd.Parameters.AddWithValue("IsStoreClearance", _nIsStoreClearance);
                cmd.Parameters.AddWithValue("ActualFaultID", _nActualFaultID);
                cmd.Parameters.AddWithValue("InterSerJobType", _nInterSerJobType);
                cmd.Parameters.AddWithValue("IsDelivered", _nIsDelivered);
                cmd.Parameters.AddWithValue("IsReplacement", _nIsReplacement);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("IsHappyCall", _nIsHappyCall);
                cmd.Parameters.AddWithValue("HaveBackupSet", _nHaveBackupSet);
                cmd.Parameters.AddWithValue("ProductPhysicalLocation", _nProductPhysicalLocation);
                cmd.Parameters.AddWithValue("VisitingDate", _dVisitingDate);
                cmd.Parameters.AddWithValue("EstSpAmount", _EstSpAmount);
                cmd.Parameters.AddWithValue("EstScAmount", _EstScAmount);
                cmd.Parameters.AddWithValue("TPMatCharge", _TPMatCharge);
                cmd.Parameters.AddWithValue("TPGasCharge", _TPGasCharge);
                cmd.Parameters.AddWithValue("TPOtherCharge", _TPOtherCharge);
                cmd.Parameters.AddWithValue("CustomerArchiveFlag", _nCustomerArchiveFlag);
                cmd.Parameters.AddWithValue("IsRemoteServiceProvided", _nIsRemoteServiceProvided);
                cmd.Parameters.AddWithValue("RemoteServiceProvidedAmount", _RemoteServiceProvidedAmount);
                cmd.Parameters.AddWithValue("RemoteServiceProvidedDate", _dRemoteServiceProvidedDate);
                cmd.Parameters.AddWithValue("Flag", _nFlag);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void UpdateCSDJobBill()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CSDJobBill SET IsWarrantyDistribution = ? WHERE JobID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsWarrantyDistribution", _nIsWarrantyDistribution);
                cmd.Parameters.AddWithValue("JobID", _nJobID);

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
                sSql = "UPDATE t_CSDJob SET ProductSerialNo = ?, OriginalProductSerialNo = ?, InvoiceNo = ?, InvoiceDate = ?, SalesChannelID = ?, SalesPointID = ?, JobNo = ?, ServiceType = ?, JobType = ?, WorkshopID = ?, ReferenceJobNo = ?, GSPNJobNo = ?, Priority = ?, LastFeedBackDate = ?, VisitingTimeFrom = ?, VisitingTimeTo = ?, DeliveryDate = ?, Remarks = ?, ProductID = ?, FullOrAccessories = ?, AccessoryID = ?, PrimaryFaultID = ?, OwnOrCustomerSet = ?, RefChannelID = ?, RefSalesPointID = ?, CustomerName = ?, TelePhone = ?, MobileNo = ?, CustomerAddress = ?, ThanaID = ?, Email = ?, NationalID = ?, Status = ?, SubStatus = ?, StatusReason = ?, CreateUserID = ?, CreateDate = ?, AssignTo = ?, AssignLeadMinute = ?, OwnOrOtherTechnician = ?, ReceivingTransportationMode = ?, ReceivingCourierID = ?, ReceivingInstrumentNo = ?, ReceivingCost = ?, DeliveryTransportationMode = ?, DeliveryCourierID = ?, DeliveryInstrumentNo = ?, DeliveryCost = ?, ProductLocation = ?, ProductMovementStatus = ?, SparePartsUsed = ?, IsStoreClearance = ?, ActualFaultID = ?, InterSerJobType = ?, IsDelivered = ?, IsReplacement = ?, UpdateUserID = ?, UpdateDate = ?, IsHappyCall = ?, HaveBackupSet = ?, ProductPhysicalLocation = ?, VisitingDate = ?, EstSpAmount = ?, EstScAmount = ?, TPMatCharge = ?, TPGasCharge = ?, TPOtherCharge = ?, CustomerArchiveFlag = ?, IsRemoteServiceProvided = ?, RemoteServiceProvidedAmount = ?, RemoteServiceProvidedDate = ?, Flag = ? WHERE JobID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);
                cmd.Parameters.AddWithValue("OriginalProductSerialNo", _sOriginalProductSerialNo);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("SalesChannelID", _nSalesChannelID);
                cmd.Parameters.AddWithValue("SalesPointID", _nSalesPointID);
                cmd.Parameters.AddWithValue("JobNo", _sJobNo);
                cmd.Parameters.AddWithValue("ServiceType", _nServiceType);
                cmd.Parameters.AddWithValue("JobType", _nJobType);
                cmd.Parameters.AddWithValue("WorkshopID", _nWorkshopID);
                cmd.Parameters.AddWithValue("ReferenceJobNo", _sReferenceJobNo);
                cmd.Parameters.AddWithValue("GSPNJobNo", _sGSPNJobNo);
                cmd.Parameters.AddWithValue("Priority", _nPriority);
                cmd.Parameters.AddWithValue("LastFeedBackDate", _dLastFeedBackDate);
                cmd.Parameters.AddWithValue("VisitingTimeFrom", _dVisitingTimeFrom);
                cmd.Parameters.AddWithValue("VisitingTimeTo", _dVisitingTimeTo);
                cmd.Parameters.AddWithValue("DeliveryDate", _dDeliveryDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("FullOrAccessories", _nFullOrAccessories);
                cmd.Parameters.AddWithValue("AccessoryID", _nAccessoryID);
                cmd.Parameters.AddWithValue("PrimaryFaultID", _nPrimaryFaultID);
                cmd.Parameters.AddWithValue("OwnOrCustomerSet", _nOwnOrCustomerSet);
                cmd.Parameters.AddWithValue("RefChannelID", _nRefChannelID);
                cmd.Parameters.AddWithValue("RefSalesPointID", _nRefSalesPointID);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("TelePhone", _sTelePhone);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("CustomerAddress", _sCustomerAddress);
                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("NationalID", _sNationalID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("SubStatus", _nSubStatus);
                cmd.Parameters.AddWithValue("StatusReason", _sStatusReason);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("AssignTo", _nAssignTo);
                cmd.Parameters.AddWithValue("AssignLeadMinute", _nAssignLeadMinute);
                cmd.Parameters.AddWithValue("OwnOrOtherTechnician", _nOwnOrOtherTechnician);
                cmd.Parameters.AddWithValue("ReceivingTransportationMode", _nReceivingTransportationMode);
                cmd.Parameters.AddWithValue("ReceivingCourierID", _nReceivingCourierID);
                cmd.Parameters.AddWithValue("ReceivingInstrumentNo", _sReceivingInstrumentNo);
                cmd.Parameters.AddWithValue("ReceivingCost", _ReceivingCost);
                cmd.Parameters.AddWithValue("DeliveryTransportationMode", _nDeliveryTransportationMode);
                cmd.Parameters.AddWithValue("DeliveryCourierID", _nDeliveryCourierID);
                cmd.Parameters.AddWithValue("DeliveryInstrumentNo", _sDeliveryInstrumentNo);
                cmd.Parameters.AddWithValue("DeliveryCost", _DeliveryCost);
                cmd.Parameters.AddWithValue("ProductLocation", _nProductLocation);
                cmd.Parameters.AddWithValue("ProductMovementStatus", _nProductMovementStatus);
                cmd.Parameters.AddWithValue("SparePartsUsed", _nSparePartsUsed);
                cmd.Parameters.AddWithValue("IsStoreClearance", _nIsStoreClearance);
                cmd.Parameters.AddWithValue("ActualFaultID", _nActualFaultID);
                cmd.Parameters.AddWithValue("InterSerJobType", _nInterSerJobType);
                cmd.Parameters.AddWithValue("IsDelivered", _nIsDelivered);
                cmd.Parameters.AddWithValue("IsReplacement", _nIsReplacement);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("IsHappyCall", _nIsHappyCall);
                cmd.Parameters.AddWithValue("HaveBackupSet", _nHaveBackupSet);
                cmd.Parameters.AddWithValue("ProductPhysicalLocation", _nProductPhysicalLocation);
                cmd.Parameters.AddWithValue("VisitingDate", _dVisitingDate);
                cmd.Parameters.AddWithValue("EstSpAmount", _EstSpAmount);
                cmd.Parameters.AddWithValue("EstScAmount", _EstScAmount);
                cmd.Parameters.AddWithValue("TPMatCharge", _TPMatCharge);
                cmd.Parameters.AddWithValue("TPGasCharge", _TPGasCharge);
                cmd.Parameters.AddWithValue("TPOtherCharge", _TPOtherCharge);
                cmd.Parameters.AddWithValue("CustomerArchiveFlag", _nCustomerArchiveFlag);
                cmd.Parameters.AddWithValue("IsRemoteServiceProvided", _nIsRemoteServiceProvided);
                cmd.Parameters.AddWithValue("RemoteServiceProvidedAmount", _RemoteServiceProvidedAmount);
                cmd.Parameters.AddWithValue("RemoteServiceProvidedDate", _dRemoteServiceProvidedDate);
                cmd.Parameters.AddWithValue("Flag", _nFlag);

                cmd.Parameters.AddWithValue("JobID", _nJobID);

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
                sSql = "DELETE FROM t_CSDJob WHERE [JobID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("JobID", _nJobID);
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
                cmd.CommandText = "SELECT * FROM t_CSDJob where JobID =?";
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nJobID = (int)reader["JobID"];
                    _sProductSerialNo = (string)reader["ProductSerialNo"];
                    _sOriginalProductSerialNo = (string)reader["OriginalProductSerialNo"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _nSalesChannelID = (int)reader["SalesChannelID"];
                    _nSalesPointID = (int)reader["SalesPointID"];
                    _sJobNo = (string)reader["JobNo"];
                    _nServiceType = (int)reader["ServiceType"];
                    _nJobType = (int)reader["JobType"];
                    _nWorkshopID = (int)reader["WorkshopID"];
                    _sReferenceJobNo = (string)reader["ReferenceJobNo"];
                    _sGSPNJobNo = (string)reader["GSPNJobNo"];
                    _nPriority = (int)reader["Priority"];
                    _dLastFeedBackDate = Convert.ToDateTime(reader["LastFeedBackDate"].ToString());
                    _dVisitingTimeFrom = Convert.ToDateTime(reader["VisitingTimeFrom"].ToString());
                    _dVisitingTimeTo = Convert.ToDateTime(reader["VisitingTimeTo"].ToString());
                    _dDeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    _sRemarks = (string)reader["Remarks"];
                    _nProductID = (int)reader["ProductID"];
                    _nFullOrAccessories = (int)reader["FullOrAccessories"];
                    _nAccessoryID = (int)reader["AccessoryID"];
                    _nPrimaryFaultID = (int)reader["PrimaryFaultID"];
                    _nOwnOrCustomerSet = (int)reader["OwnOrCustomerSet"];
                    _nRefChannelID = (int)reader["RefChannelID"];
                    _nRefSalesPointID = (int)reader["RefSalesPointID"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _sTelePhone = (string)reader["TelePhone"];
                    _sMobileNo = (string)reader["MobileNo"];
                    _sCustomerAddress = (string)reader["CustomerAddress"];
                    _nThanaID = (int)reader["ThanaID"];
                    _sEmail = (string)reader["Email"];
                    _sNationalID = (string)reader["NationalID"];
                    _nStatus = (int)reader["Status"];
                    _nSubStatus = (int)reader["SubStatus"];
                    _sStatusReason = (string)reader["StatusReason"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nAssignTo = (int)reader["AssignTo"];
                    _nAssignLeadMinute = (int)reader["AssignLeadMinute"];
                    _nOwnOrOtherTechnician = (int)reader["OwnOrOtherTechnician"];
                    _nReceivingTransportationMode = (int)reader["ReceivingTransportationMode"];
                    _nReceivingCourierID = (int)reader["ReceivingCourierID"];
                    _sReceivingInstrumentNo = (string)reader["ReceivingInstrumentNo"];
                    _ReceivingCost = Convert.ToDouble(reader["ReceivingCost"].ToString());
                    _nDeliveryTransportationMode = (int)reader["DeliveryTransportationMode"];
                    _nDeliveryCourierID = (int)reader["DeliveryCourierID"];
                    _sDeliveryInstrumentNo = (string)reader["DeliveryInstrumentNo"];
                    _DeliveryCost = Convert.ToDouble(reader["DeliveryCost"].ToString());
                    _nProductLocation = (int)reader["ProductLocation"];
                    _nProductMovementStatus = (int)reader["ProductMovementStatus"];
                    _nSparePartsUsed = (int)reader["SparePartsUsed"];
                    _nIsStoreClearance = (int)reader["IsStoreClearance"];
                    _nActualFaultID = (int)reader["ActualFaultID"];
                    _nInterSerJobType = (int)reader["InterSerJobType"];
                    _nIsDelivered = (int)reader["IsDelivered"];
                    _nIsReplacement = (int)reader["IsReplacement"];
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nIsHappyCall = (int)reader["IsHappyCall"];
                    _nHaveBackupSet = (int)reader["HaveBackupSet"];
                    _nProductPhysicalLocation = (int)reader["ProductPhysicalLocation"];
                    _dVisitingDate = Convert.ToDateTime(reader["VisitingDate"].ToString());
                    _EstSpAmount = Convert.ToDouble(reader["EstSpAmount"].ToString());
                    _EstScAmount = Convert.ToDouble(reader["EstScAmount"].ToString());
                    _TPMatCharge = Convert.ToDouble(reader["TPMatCharge"].ToString());
                    _TPGasCharge = Convert.ToDouble(reader["TPGasCharge"].ToString());
                    _TPOtherCharge = Convert.ToDouble(reader["TPOtherCharge"].ToString());
                    _nCustomerArchiveFlag = (int)reader["CustomerArchiveFlag"];
                    _nIsRemoteServiceProvided = (int)reader["IsRemoteServiceProvided"];
                    _RemoteServiceProvidedAmount = Convert.ToDouble(reader["RemoteServiceProvidedAmount"].ToString());
                    _dRemoteServiceProvidedDate = Convert.ToDateTime(reader["RemoteServiceProvidedDate"].ToString());
                    _nFlag = (int)reader["Flag"];
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
    public class CSDJobsForWarrantys : CollectionBase
    {
        public CSDJobsForWarranty this[int i]
        {
            get { return (CSDJobsForWarranty)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDJobsForWarranty oCSDJob)
        {
            InnerList.Add(oCSDJob);
        }
        public int GetIndex(int nJobID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].JobID == nJobID)
                {
                    return i;
                }

            }
            return -1;
        }
        public void GetDataFromCSDJob(string nJobNo, int nJobType, int nServiceType, int nIsWarrantyDist)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select a.JobID, JobNo, ServiceType, JobType, DeliveryDate, CustomerName, CustomerAddress, Status, CreateDate, ActualMatCharge as SparePartsCharge, ActualSerCharge as ServiceCharge, InTranportationCharge + OutTranportationCharge as TransportationCharge, OtherCharge, IsWarrantyDistribution from t_CSDJob a, t_CSDJobBill b where a.JobID = b.JobID and ServiceType != 3 and JobType != 2 and IsDelivered = 1 and ReceivedAmount > 0 and CreateDate >= '2020-01-01'";

            if (nJobNo != string.Empty)
            {
                sSql += " AND JobNo LIKE '%" + nJobNo + "%' ";
            }

            if (nJobType != 0)
            {
                sSql = sSql + " AND JobType=" + nJobType + "";
            }

            if (nServiceType != 0)
            {
                sSql = sSql + " AND ServiceType=" + nServiceType + "";
            }

            if (nIsWarrantyDist != -1)
            {
                sSql = sSql + " AND IsWarrantyDistribution=" + nIsWarrantyDist + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJobsForWarranty oCSDJob = new CSDJobsForWarranty();
                    oCSDJob.JobID = (int)reader["JobID"];
                    oCSDJob.JobNo = (string)reader["JobNo"];
                    oCSDJob.ServiceType = (int)reader["ServiceType"];
                    oCSDJob.JobType = (int)reader["JobType"];

                    if (reader["DeliveryDate"] != DBNull.Value)
                    {
                        oCSDJob.DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    }
                    else
                    {
                        oCSDJob.DeliveryDate = "";
                    }

                    //oCSDJob.DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    oCSDJob.CustomerName = (string)reader["CustomerName"];
                    oCSDJob.CustomerAddress = (string)reader["CustomerAddress"];
                    oCSDJob.Status = (int)reader["Status"];
                    oCSDJob.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDJob.SparePartsCharge = Convert.ToDouble(reader["ServiceCharge"].ToString());
                    oCSDJob.ServiceCharge = Convert.ToDouble(reader["SparePartsCharge"].ToString());
                    oCSDJob.TransportationCharge = Convert.ToDouble(reader["TransportationCharge"].ToString());
                    oCSDJob.OtherCharge = Convert.ToDouble(reader["OtherCharge"].ToString());

                    if (reader["IsWarrantyDistribution"] != DBNull.Value)
                    {
                        oCSDJob.IsWarrantyDistribution = (int)reader["IsWarrantyDistribution"];
                    }
                    else
                    {
                        oCSDJob.IsWarrantyDistribution = 0 ;
                    }

                    InnerList.Add(oCSDJob);
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
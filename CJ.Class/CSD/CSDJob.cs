// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Aug 04, 2014
// Time :  02:00 PM
// Description: Class for CSD Job.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;



namespace CJ.Class.CSD
{
    public class CSDJobBillSendItem
    {
        private int _nBillID;
        private int _nJobID;
        private double _Amount;
        private string _sJobNo;
        private string _sGSPNJobNo;
        private string _sActualFault;
        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value.Trim(); }
        }
        public string GSPNJobNo
        {
            get { return _sGSPNJobNo; }
            set { _sGSPNJobNo = value.Trim(); }
        }
        public string ActualFault
        {
            get { return _sActualFault; }
            set { _sActualFault = value.Trim(); }
        }

        private DateTime _dJobDate;
        public DateTime JobDate
        {
            get { return _dJobDate; }
            set { _dJobDate = value; }
        }

        private string _sProductName;
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }
        private string _sCustomerName;
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        private string _sMobileNo;
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value.Trim(); }
        }
        private string _sTechnicianName;
        public string TechnicianName
        {
            get { return _sTechnicianName; }
            set { _sTechnicianName = value.Trim(); }
        }
        private double _BillAmount;
        public double BillAmount
        {
            get { return _BillAmount; }
            set { _BillAmount = value; }
        }


        // <summary>
        // Get set property for BillID
        // </summary>
        public int BillID
        {
            get { return _nBillID; }
            set { _nBillID = value; }
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
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        public void Add()
        {
            int nMaxBillID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([BillID]) FROM t_CSDJobBillSendItem";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBillID = 1;
                }
                else
                {
                    nMaxBillID = Convert.ToInt32(maxID) + 1;
                }
                _nBillID = nMaxBillID;
                sSql = "INSERT INTO t_CSDJobBillSendItem (BillID, JobID, Amount) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BillID", _nBillID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("Amount", _Amount);

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
                sSql = "UPDATE t_CSDJobBillSendItem SET JobID = ?, Amount = ? WHERE BillID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("Amount", _Amount);

                cmd.Parameters.AddWithValue("BillID", _nBillID);

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
                sSql = "DELETE FROM t_CSDJobBillSendItem WHERE [BillID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BillID", _nBillID);
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
                cmd.CommandText = "SELECT * FROM t_CSDJobBillSendItem where BillID =?";
                cmd.Parameters.AddWithValue("BillID", _nBillID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nBillID = (int)reader["BillID"];
                    _nJobID = (int)reader["JobID"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
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

    public class CSDJob : CollectionBase
    {
        public CSDJobBillSendItem this[int i]
        {
            get { return (CSDJobBillSendItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDJobBillSendItem oCSDJobBillSendItem)
        {
            InnerList.Add(oCSDJobBillSendItem);
        }

        private int _nJobID;
        private string _sProductSerialNo;
        private string _sOriginalProductSerialNo;
        private string _sInvoiceNo;
        private object _dInvoiceDate;
        private int _nSalesChannelID;
        private int _nSalesPointID;
        private string _sJobNo;
        private int _nServiceType;
        private int _nJobType;
        private int _nWorkshopID;
        private string _sWorkshopName;
        private string _sReferenceJobNo;
        private string _sGSPNJobNo;
        private int _nPriority;
        private DateTime _dLastFeedBackDate;
        private object _dVisitingTimeFrom;
        private object _dVisitingTimeTo;
        private object _dDeliveryDate;
        private string _sRemarks;
        private int _nProductID;
        private int _nFullOrAccessories;
        private int _nAccessoryID;
        private int _nPrimaryFaultID;
        private int _nNextJobNo;
        private string _sProductCode;
        private string _sProductName;
        private string _sProductModel;
        private string _sProductTypeName;
        private string _sCustomerCode;
        private int _nASGID;
        private int _nBrandID;
        private string _sASGName;
        private string _sBrandName;
        private string _sJobTypeDes;
        private string _sStatusName;
        private string _sServiceTypeDes;
        private int _nActualFaultID;
        private string _sFaultDescription;
        private string _sActualFault;
        private int _nOwnOrCustomerSet;
        private int _nRefChannelID;
        private int _nRefSalesPointID;
        private string _sCustomerName;
        private string _sTelePhone;
        private string _sMobileNo;
        private string _sCustomerAddress;
        private int _nThanaID;
        private string _sThanaName;
        private string _sDistrictName;
        private string _sEmail;
        private string _sNationalID;
        private int _nStatus;
        private int _nSubStatus;
        private string _sSubStatusName;
        private string _sStatusReason;
        private int _nCreateUserID;
        private string _sCreateUserName;
        private DateTime _dCreateDate;
        private int _nAssignTo;
        private int _nThirdPartyID;
        private string _sThirdPartyName;
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
        private int _nInterSerJobType;
        private int _nIsDelivered;
        private int _nIsReplacement;

        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        private string _sType;
        private string _sJobStatus;
        private int _nTotalJob;

        private int _nIsHappyCall;
        private int _nHaveBackupset;
        private int _nProductPhysicalLocation;
        private string _sTechnicianCode;
        private string _sTechnicianName;
        private object _dVisitingDate;

        private string _sSendUserName;

        public double _TPMatCharge;
        public double _TPGasCharge;
        public double _TPOtherCharge;

        private int _nJobCreateLocation;
        public double _RemoteServiceProvidedAmount;


        public int JobCreateLocation
        {
            get { return _nJobCreateLocation; }
            set { _nJobCreateLocation = value; }
        }

        public string SendUserName
        {
            get { return _sSendUserName; }
            set { _sSendUserName = value; }
        }
        public string Type
        {
            get { return _sType; }
            set { _sType = value; }
        }
        public string JobStatus
        {
            get { return _sJobStatus; }
            set { _sJobStatus = value; }
        }

        public int TotalJob
        {
            get { return _nTotalJob; }
            set { _nTotalJob = value; }
        }
        public string ActualFault
        {
            get { return _sActualFault; }
            set { _sActualFault = value; }
        }
        private string _sReceiveUserName;
        public string ReceiveUserName
        {
            get { return _sReceiveUserName; }
            set { _sReceiveUserName = value; }
        }
        private object _dSendDate;
        public object SendDate
        {
            get { return _dSendDate; }
            set { _dSendDate = value; }
        }
        private object _dReceiveDate;
        public object ReceiveDate
        {
            get { return _dReceiveDate; }
            set { _dReceiveDate = value; }
        }


        private double _nEstSpAmount;
        public double EstSpAmount
        {
            get { return _nEstSpAmount; }
            set { _nEstSpAmount = value; }
        }

        private double _nEstScAmount;
        public double EstScAmount
        {
            get { return _nEstScAmount; }
            set { _nEstScAmount = value; }
        }

        public Employee oEmployee = new Employee();
        public InterServiceR oThirdParty = new InterServiceR();
        public Technician oTechnician = new Technician();
        private double _BillAmount;
        public double BillAmount
        {
            get { return _BillAmount; }
            set { _BillAmount = value; }
        }
        private int _nBillID;
        public int BillID
        {
            get { return _nBillID; }
            set { _nBillID = value; }
        }
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        private string _sBillNo;
        public string BillNo
        {
            get { return _sBillNo; }
            set { _sBillNo = value; }
        }
        private int _nBillStatus;
        public int BillStatus
        {
            get { return _nBillStatus; }
            set { _nBillStatus = value; }
        }


        /// <summary>
        /// Get set property for WorkshopName
        /// </summary>
        public string WorkshopName
        {
            get { return _sWorkshopName; }
            set { _sWorkshopName = value; }
        }
        /// <summary>
        /// Get set property for JobID
        /// </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }

        private string _sDeliveryAddress;
        public string DeliveryAddress
        {
            get { return _sDeliveryAddress; }
            set { _sDeliveryAddress = value.Trim(); }
        }
        /// <summary>
        /// Get set property for ProductSerialNo
        /// </summary>
        public string ProductSerialNo
        {
            get { return _sProductSerialNo; }
            set { _sProductSerialNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for OriginalProductSerialNo
        /// </summary>
        public string OriginalProductSerialNo
        {
            get { return _sOriginalProductSerialNo; }
            set { _sOriginalProductSerialNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for CreateUserName
        /// </summary>
        public string CreateUserName
        {
            get { return _sCreateUserName; }
            set { _sCreateUserName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for ProductModel
        /// </summary>
        public string ProductModel
        {
            get { return _sProductModel; }
            set { _sProductModel = value.Trim(); }
        }


        /// <summary>
        /// Get set property for InvocieNo
        /// </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for InvoiceDate
        /// </summary>
        public object InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }
        /// <summary>
        /// Get set property for SalesChannelID
        /// </summary>
        public int SalesChannelID
        {
            get { return _nSalesChannelID; }
            set { _nSalesChannelID = value; }
        }
        /// <summary>
        /// Get set property for SalesPointID
        /// </summary>
        public int SalesPointID
        {
            get { return _nSalesPointID; }
            set { _nSalesPointID = value; }
        }
        /// <summary>
        /// Get set property for JobNo
        /// </summary>
        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for ServiceType
        /// </summary>
        public int ServiceType
        {
            get { return _nServiceType; }
            set { _nServiceType = value; }
        }
        /// <summary>
        /// Get set property for JobType
        /// </summary>
        public int JobType
        {
            get { return _nJobType; }
            set { _nJobType = value; }
        }
        /// <summary>
        /// Get set property for WorkshopID
        /// </summary>
        public int WorkshopID
        {
            get { return _nWorkshopID; }
            set { _nWorkshopID = value; }
        }
        /// <summary>
        /// Get set property for ReferenceJobNo
        /// </summary>
        public string ReferenceJobNo
        {
            get { return _sReferenceJobNo; }
            set { _sReferenceJobNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for GSPNJobNo
        /// </summary>
        public string GSPNJobNo
        {
            get { return _sGSPNJobNo; }
            set { _sGSPNJobNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for Priority
        /// </summary>
        public int Priority
        {
            get { return _nPriority; }
            set { _nPriority = value; }
        }
        /// <summary>
        /// Get set property for LastFeedBackDate
        /// </summary>
        public DateTime LastFeedBackDate
        {
            get { return _dLastFeedBackDate; }
            set { _dLastFeedBackDate = value; }
        }
        /// <summary>
        /// Get set property for VisitingTimeFrom
        /// </summary>
        public object VisitingTimeFrom
        {
            get { return _dVisitingTimeFrom; }
            set { _dVisitingTimeFrom = value; }
        }
        /// <summary>
        /// Get set property for VisitingTimeTo
        /// </summary>
        public object VisitingTimeTo
        {
            get { return _dVisitingTimeTo; }
            set { _dVisitingTimeTo = value; }
        }
        /// <summary>
        /// Get set property for DeliveryDate
        /// </summary>
        public object DeliveryDate
        {
            get { return _dDeliveryDate; }
            set { _dDeliveryDate = value; }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }
        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        /// <summary>
        /// Get set property for FullOrAccessories
        /// </summary>
        public int FullOrAccessories
        {
            get { return _nFullOrAccessories; }
            set { _nFullOrAccessories = value; }
        }
        /// <summary>
        /// Get set property for AccessoryID
        /// </summary>
        public int AccessoryID
        {
            get { return _nAccessoryID; }
            set { _nAccessoryID = value; }
        }
        /// <summary>
        /// Get set property for PrimaryFaultID
        /// </summary>
        public int PrimaryFaultID
        {
            get { return _nPrimaryFaultID; }
            set { _nPrimaryFaultID = value; }
        }
        /// <summary>
        /// Get set property for FaultDescription
        /// </summary>
        public string FaultDescription
        {
            get { return _sFaultDescription; }
            set { _sFaultDescription = value; }
        }
        /// <summary>
        /// Get set property for OwnOrCustomerSet
        /// </summary>
        public int OwnOrCustomerSet
        {
            get { return _nOwnOrCustomerSet; }
            set { _nOwnOrCustomerSet = value; }
        }
        /// <summary>
        /// Get set property for RefChannelID
        /// </summary>
        public int RefChannelID
        {
            get { return _nRefChannelID; }
            set { _nRefChannelID = value; }
        }
        /// <summary>
        /// Get set property for RefSalesPointID
        /// </summary>
        public int RefSalesPointID
        {
            get { return _nRefSalesPointID; }
            set { _nRefSalesPointID = value; }
        }
        /// <summary>
        /// Get set property for CustomerName
        /// </summary>
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for TelePhone
        /// </summary>
        public string TelePhone
        {
            get { return _sTelePhone; }
            set { _sTelePhone = value.Trim(); }
        }
        /// <summary>
        /// Get set property for MobileNo
        /// </summary>
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for CustomerAddress
        /// </summary>
        public string CustomerAddress
        {
            get { return _sCustomerAddress; }
            set { _sCustomerAddress = value.Trim(); }
        }
        /// <summary>
        /// Get set property for ThanaID
        /// </summary>
        public int ThanaID
        {
            get { return _nThanaID; }
            set { _nThanaID = value; }
        }
        /// <summary>
        /// Get set property for ThanaID
        /// </summary>
        public string ThanaName
        {
            get { return _sThanaName; }
            set { _sThanaName = value; }
        }
        /// <summary>
        /// Get set property for ThanaID
        /// </summary>
        public string DistrictName
        {
            get { return _sDistrictName; }
            set { _sDistrictName = value; }
        }
        /// <summary>
        /// Get set property for Email
        /// </summary>
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value.Trim(); }
        }
        /// <summary>
        /// Get set property for NationalID
        /// </summary>
        public string NationalID
        {
            get { return _sNationalID; }
            set { _sNationalID = value.Trim(); }
        }
        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        /// <summary>
        /// Get set property for SubStatus
        /// </summary>
        public int SubStatus
        {
            get { return _nSubStatus; }
            set { _nSubStatus = value; }
        }

        /// <summary>
        /// Get set property for SubStatusName
        /// </summary>
        public string SubStatusName
        {
            get { return _sSubStatusName; }
            set { _sSubStatusName = value; }
        }
        /// <summary>
        /// Get set property for StatusReason
        /// </summary>
        public string StatusReason
        {
            get { return _sStatusReason; }
            set { _sStatusReason = value.Trim(); }
        }
        /// <summary>
        /// Get set property for CreateUserID
        /// </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        /// <summary>
        /// Get set property for AssignTo
        /// </summary>
        public int AssignTo
        {
            get { return _nAssignTo; }
            set { _nAssignTo = value; }
        }
        /// <summary>
        /// Get set property for ThirdPartyID;
        /// </summary>
        public int ThirdPartyID
        {
            get { return _nThirdPartyID; }
            set { _nThirdPartyID = value; }
        }

        /// <summary>
        /// Get set property for ThirdPartyName
        /// </summary>
        public string ThirdPartyName
        {
            get { return _sThirdPartyName; }
            set { _sThirdPartyName = value; }
        }

        /// <summary>
        /// Get set property for AssignLeadMinute
        /// </summary>
        public int AssignLeadMinute
        {
            get { return _nAssignLeadMinute; }
            set { _nAssignLeadMinute = value; }
        }
        /// <summary>
        /// Get set property for OwnOrOtherTechnician
        /// </summary>
        public int OwnOrOtherTechnician
        {
            get { return _nOwnOrOtherTechnician; }
            set { _nOwnOrOtherTechnician = value; }
        }
        /// <summary>
        /// Get set property for ReceivingTransportationMode
        /// </summary>
        public int ReceivingTransportationMode
        {
            get { return _nReceivingTransportationMode; }
            set { _nReceivingTransportationMode = value; }
        }
        /// <summary>
        /// Get set property for ReceivingCourierID
        /// </summary>
        public int ReceivingCourierID
        {
            get { return _nReceivingCourierID; }
            set { _nReceivingCourierID = value; }
        }
        /// <summary>
        /// Get set property for ReceivingInstrumentNo
        /// </summary>
        public string ReceivingInstrumentNo
        {
            get { return _sReceivingInstrumentNo; }
            set { _sReceivingInstrumentNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for ReceivingCost
        /// </summary>
        public double ReceivingCost
        {
            get { return _ReceivingCost; }
            set { _ReceivingCost = value; }
        }
        /// <summary>
        /// Get set property for DeliveryTransportationMode
        /// </summary>
        public int DeliveryTransportationMode
        {
            get { return _nDeliveryTransportationMode; }
            set { _nDeliveryTransportationMode = value; }
        }
        /// <summary>
        /// Get set property for DeliveryCourierID
        /// </summary>
        public int DeliveryCourierID
        {
            get { return _nDeliveryCourierID; }
            set { _nDeliveryCourierID = value; }
        }
        /// <summary>
        /// Get set property for DeliveryInstrumentNo
        /// </summary>
        public string DeliveryInstrumentNo
        {
            get { return _sDeliveryInstrumentNo; }
            set { _sDeliveryInstrumentNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for DeliveryCost
        /// </summary>
        public double DeliveryCost
        {
            get { return _DeliveryCost; }
            set { _DeliveryCost = value; }
        }
        /// <summary>
        /// Get set property for ProductLocation
        /// </summary>
        public int ProductLocation
        {
            get { return _nProductLocation; }
            set { _nProductLocation = value; }
        }
        /// <summary>
        /// Get set property for ProductMovementStatus
        /// </summary>
        public int ProductMovementStatus
        {
            get { return _nProductMovementStatus; }
            set { _nProductMovementStatus = value; }
        }
        /// <summary>
        /// Get set property for SparePartsUsed
        /// </summary>
        public int SparePartsUsed
        {
            get { return _nSparePartsUsed; }
            set { _nSparePartsUsed = value; }
        }

        /// <summary>
        /// Get set property for IsStoreClearance
        /// </summary>
        public int IsStoreClearance
        {
            get { return _nIsStoreClearance; }
            set { _nIsStoreClearance = value; }
        }


        /// <summary>
        /// Get set property for ActualFaultID
        /// </summary>
        public int ActualFaultID
        {
            get { return _nActualFaultID; }
            set { _nActualFaultID = value; }
        }
        /// <summary>
        /// Get set property for InterSerJobType
        /// </summary>
        public int InterSerJobType
        {
            get { return _nInterSerJobType; }
            set { _nInterSerJobType = value; }
        }
        /// <summary>
        /// Get set property for IsDelivered
        /// </summary>
        public int IsDelivered
        {
            get { return _nIsDelivered; }
            set { _nIsDelivered = value; }
        }
        /// <summary>
        /// Get set property for IsReplacement
        /// </summary>
        public int IsReplacement
        {
            get { return _nIsReplacement; }
            set { _nIsReplacement = value; }
        }
        /// <summary>
        /// Get set property for UpdateUserID
        /// </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }
        /// <summary>
        /// Get set property for UpdateDate
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }


        public int NextJobNo
        {
            get { return _nNextJobNo; }
            set { _nNextJobNo = value; }
        }

        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }

        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }

        public string ProductTypeName
        {
            get { return _sProductTypeName; }
            set { _sProductTypeName = value; }
        }


        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }

        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }

        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }

        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }

        public string ServiceTypeDes
        {
            get { return _sServiceTypeDes; }
            set { _sServiceTypeDes = value; }
        }

        public string JobTypeDes
        {
            get { return _sJobTypeDes; }
            set { _sJobTypeDes = value; }
        }

        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value; }
        }


        /// <summary>
        /// Get set property for IsHappyCall
        /// </summary>
        public int IsHappyCall
        {
            get { return _nIsHappyCall; }
            set { _nIsHappyCall = value; }
        }


        /// <summary>
        /// Get set property for HaveBackupset
        /// </summary>
        public int HaveBackupset
        {
            get { return _nHaveBackupset; }
            set { _nHaveBackupset = value; }
        }

        /// <summary>
        /// Get set property for ProductPhysicalLocation
        /// </summary>
        public int ProductPhysicalLocation
        {
            get { return _nProductPhysicalLocation; }
            set { _nProductPhysicalLocation = value; }
        }

        /// <summary>
        /// Get set property for TechnicianCode
        /// </summary>
        public string TechnicianCode
        {
            get { return _sTechnicianCode; }
            set { _sTechnicianCode = value; }
        }

        /// <summary>
        /// Get set property for TechnicianName
        /// </summary>
        public string TechnicianName
        {
            get { return _sTechnicianName; }
            set { _sTechnicianName = value; }
        }

        /// <summary>
        /// Get set property for VisitingDate
        /// </summary>
        public object VisitingDate
        {
            get { return _dVisitingDate; }
            set { _dVisitingDate = value; }
        }

        public double TPMatCharge
        {
            get { return _TPMatCharge; }
            set { _TPMatCharge = value; }
        }

        public double TPGasCharge
        {
            get { return _TPGasCharge; }
            set { _TPGasCharge = value; }
        }
        public double TPOtherCharge
        {
            get { return _TPOtherCharge; }
            set { _TPOtherCharge = value; }
        }

        public double RemoteServiceProvidedAmount
        {
            get { return _RemoteServiceProvidedAmount; }
            set { _RemoteServiceProvidedAmount = value; }
        }

        public int Add(int nUIControl)
        {
            int nMaxID = 0;
            int nMaxJobID = 0;
            string sShortCode = "";

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

                if (nUIControl == (int)Dictionary.ServiceType.Walkin)
                {
                    sShortCode = "W";
                }
                else if (nUIControl == (int)Dictionary.ServiceType.HomeCall)
                {
                    sShortCode = "H";
                }
                else if (nUIControl == (int)Dictionary.ServiceType.Installation)
                {
                    sShortCode = "I";
                }
                //else if (nUIControl == (int)Dictionary.ServiceType.InterService)
                //{
                //    sShortCode = "T";
                //}

                DateTime _dToday = DateTime.Today;

                _sJobNo = sShortCode + _dToday.ToString("yy") + _nNextJobNo.ToString("00000");


                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_CSDJob( "
                                  + " JobID,ProductSerialNo,OriginalProductSerialNo,InvoiceNo,InvoiceDate,SalesChannelID,SalesPointID,JobNo,ServiceType,JobType,"
                                  + " WorkshopID,ReferenceJobNo,GSPNJobNo,Priority,LastFeedBackDate,VisitingTimeFrom, VisitingTimeTo, DeliveryDate,Remarks,ProductID,FullOrAccessories,"
                                  + " AccessoryID,PrimaryFaultID,OwnOrCustomerSet,RefChannelID,RefSalesPointID,CustomerName,TelePhone,"
                                  + " MobileNo,CustomerAddress,ThanaID,Email,NationalID,Status,StatusReason,CreateUserID,CreateDate,AssignTo,AssignLeadMinute,"
                                  + " OwnOrOtherTechnician,ReceivingTransportationMode,ReceivingCourierID,ReceivingInstrumentNo,ReceivingCost,"
                                  + " DeliveryTransportationMode,DeliveryCourierID,DeliveryInstrumentNo,DeliveryCost,ProductLocation,ProductMovementStatus,SparePartsUsed,IsStoreClearance,"
                                  + " ActualFaultID,InterSerJobType,IsDelivered,IsReplacement,IsHappyCall,HaveBackupset,ProductPhysicalLocation,VisitingDate,JobCreateLocation) "
                                  + " Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

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
                if (_nAccessoryID != -1)
                    cmd.Parameters.AddWithValue("AccessoryID", _nAccessoryID);
                else cmd.Parameters.AddWithValue("AccessoryID", null);
                cmd.Parameters.AddWithValue("PrimaryFaultID", _nPrimaryFaultID);
                cmd.Parameters.AddWithValue("OwnOrCustomerSet", _nOwnOrCustomerSet);
                cmd.Parameters.AddWithValue("RefChannelID", _nRefChannelID);
                if (_nRefSalesPointID != -1)
                    cmd.Parameters.AddWithValue("RefSalesPointID", _nRefSalesPointID);
                else cmd.Parameters.AddWithValue("RefSalesPointID", null);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("TelePhone", _sTelePhone);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("CustomerAddress", _sCustomerAddress);
                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("NationalID", _sNationalID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("StatusReason", _sStatusReason);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                if (_nAssignTo != -1)
                    cmd.Parameters.AddWithValue("AssignTo", _nAssignTo);
                else cmd.Parameters.AddWithValue("AssignTo", null);
                if (_nAssignLeadMinute != -1)
                    cmd.Parameters.AddWithValue("AssignLeadMinute", _nAssignLeadMinute);
                else cmd.Parameters.AddWithValue("AssignLeadMinute", null);
                if (_nOwnOrOtherTechnician != -1)
                    cmd.Parameters.AddWithValue("OwnOrOtherTechnician", _nOwnOrOtherTechnician);
                else cmd.Parameters.AddWithValue("OwnOrOtherTechnician", null);
                cmd.Parameters.AddWithValue("ReceivingTransportationMode", _nReceivingTransportationMode);
                if (_nReceivingCourierID != -1)
                    cmd.Parameters.AddWithValue("ReceivingCourierID", _nReceivingCourierID);
                else cmd.Parameters.AddWithValue("ReceivingCourierID", null);
                cmd.Parameters.AddWithValue("ReceivingInstrumentNo", _sReceivingInstrumentNo);
                cmd.Parameters.AddWithValue("ReceivingCost", _ReceivingCost);
                if (_nDeliveryTransportationMode != -1)
                    cmd.Parameters.AddWithValue("DeliveryTransportationMode", _nDeliveryTransportationMode);
                else cmd.Parameters.AddWithValue("DeliveryTransportationMode", null);
                if (_nDeliveryCourierID != -1)
                    cmd.Parameters.AddWithValue("DeliveryCourierID", _nDeliveryCourierID);
                else cmd.Parameters.AddWithValue("DeliveryCourierID", null);
                cmd.Parameters.AddWithValue("DeliveryInstrumentNo", _sDeliveryInstrumentNo);
                cmd.Parameters.AddWithValue("DeliveryCost", _DeliveryCost);
                cmd.Parameters.AddWithValue("ProductLocation", _nProductLocation);
                cmd.Parameters.AddWithValue("ProductMovementStatus", (int)Dictionary.ProductMovementStatus.None);
                cmd.Parameters.AddWithValue("SparePartsUsed", _nSparePartsUsed);
                cmd.Parameters.AddWithValue("IsStoreClearance", _nIsStoreClearance);
                if (_nActualFaultID != -1)
                    cmd.Parameters.AddWithValue("ActualFaultID", _nActualFaultID);
                else cmd.Parameters.AddWithValue("ActualFaultID", null);
                if (_nInterSerJobType != -1)
                    cmd.Parameters.AddWithValue("InterSerJobType", _nInterSerJobType);
                else cmd.Parameters.AddWithValue("InterSerJobType", null);
                cmd.Parameters.AddWithValue("IsDelivered", _nIsDelivered);
                cmd.Parameters.AddWithValue("IsReplacement", _nIsReplacement);
                cmd.Parameters.AddWithValue("IsHappyCall", _nIsHappyCall);
                cmd.Parameters.AddWithValue("HaveBackupset", _nHaveBackupset);
                cmd.Parameters.AddWithValue("ProductPhysicalLocation", _nProductPhysicalLocation);
                cmd.Parameters.AddWithValue("VisitingDate", _dVisitingDate);
                cmd.Parameters.AddWithValue("JobCreateLocation", _nJobCreateLocation);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_CSDNextJobNo set JobNumber = JobNumber + 1  where YearID=" + Convert.ToInt32(_dToday.Year) + " and ServiceType=" + nUIControl + "";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nMaxJobID;
        }

        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDJob set ProductSerialNo=?,OriginalProductSerialNo = ?, InvoiceNo=?,InvoiceDate=?,SalesChannelID=?,SalesPointID=?,JobType=?,"
                      + " ReferenceJobNo=?, GSPNJobNo=?, Priority=?,LastFeedBackDate=?,Remarks=?,ProductID=?,FullOrAccessories=?,"
                      + " AccessoryID=?,PrimaryFaultID=?,OwnOrCustomerSet=?,RefChannelID=?,RefSalesPointID=?,CustomerName=?,TelePhone=?,"
                      + " MobileNo=?,CustomerAddress=?,ThanaID=?, Email=?,NationalID=?,UpdateUserID=?,UpdateDate=?,"
                      + " ReceivingTransportationMode=?,ReceivingCourierID=?,ReceivingInstrumentNo=?,ReceivingCost=?, ServiceType=?, "
                      + " VisitingDate=?,VisitingTimeFrom=?,VisitingTimeTo=?,ProductPhysicalLocation =?,ProductLocation =? where JobID=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductSerialNo", _sProductSerialNo);
                cmd.Parameters.AddWithValue("OriginalProductSerialNo", _sOriginalProductSerialNo);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("SalesChannelID", _nSalesChannelID);
                cmd.Parameters.AddWithValue("SalesPointID", _nSalesPointID);
                cmd.Parameters.AddWithValue("JobType", _nJobType);
                cmd.Parameters.AddWithValue("ReferenceJobNo", _sReferenceJobNo);
                cmd.Parameters.AddWithValue("GSPNJobNo", _sGSPNJobNo);
                cmd.Parameters.AddWithValue("Priority", _nPriority);
                cmd.Parameters.AddWithValue("LastFeedBackDate", _dLastFeedBackDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("FullOrAccessories", _nFullOrAccessories);
                if (_nAccessoryID != -1)
                    cmd.Parameters.AddWithValue("AccessoryID", _nAccessoryID);
                else cmd.Parameters.AddWithValue("AccessoryID", null);
                cmd.Parameters.AddWithValue("PrimaryFaultID", _nPrimaryFaultID);
                cmd.Parameters.AddWithValue("OwnOrCustomerSet", _nOwnOrCustomerSet);
                cmd.Parameters.AddWithValue("RefChannelID", _nRefChannelID);
                if (_nRefSalesPointID != -1)
                    cmd.Parameters.AddWithValue("RefSalesPointID", _nRefSalesPointID);
                else cmd.Parameters.AddWithValue("RefSalesPointID", null);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("TelePhone", _sTelePhone);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("CustomerAddress", _sCustomerAddress);
                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("NationalID", _sNationalID);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("ReceivingTransportationMode", _nReceivingTransportationMode);
                if (_nReceivingCourierID != -1)
                    cmd.Parameters.AddWithValue("ReceivingCourierID", _nReceivingCourierID);
                else cmd.Parameters.AddWithValue("ReceivingCourierID", null);
                cmd.Parameters.AddWithValue("ReceivingInstrumentNo", _sReceivingInstrumentNo);
                cmd.Parameters.AddWithValue("ReceivingCost", _ReceivingCost);
                cmd.Parameters.AddWithValue("ServiceType", _nServiceType);

                cmd.Parameters.AddWithValue("VisitingDate", _dVisitingDate);
                cmd.Parameters.AddWithValue("VisitingTimeFrom", _dVisitingTimeFrom);
                cmd.Parameters.AddWithValue("VisitingTimeTo", _dVisitingTimeTo);
                cmd.Parameters.AddWithValue("ProductPhysicalLocation", _nProductPhysicalLocation);
                cmd.Parameters.AddWithValue("ProductLocation", _nProductLocation);
                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void UpdateJobAfterDelivery()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDJob set DeliveryTransportationMode=?,DeliveryCourierID=?,DeliveryCost=?,Status=?,DeliveryInstrumentNo=?,"
                       + " IsDelivered=?,DeliveryDate=?,UpdateUserID=?,UpdateDate=?,ProductLocation=?,"
                       + " ProductMovementStatus=? where JobID=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DeliveryTransportationMode", _nDeliveryTransportationMode);
                cmd.Parameters.AddWithValue("DeliveryCourierID", _nDeliveryCourierID);
                cmd.Parameters.AddWithValue("DeliveryCost", _DeliveryCost);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("DeliveryInstrumentNo", _sDeliveryInstrumentNo);
                cmd.Parameters.AddWithValue("IsDelivered", _nIsDelivered);
                cmd.Parameters.AddWithValue("DeliveryDate", _dDeliveryDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("ProductLocation", _nProductLocation);
                //cmd.Parameters.AddWithValue("ProductPhysicalLocation", _nProductPhysicalLocation);
                cmd.Parameters.AddWithValue("ProductMovementStatus", _nProductMovementStatus);

                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateTechnician()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDJob set AssignTo=? where JobID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("AssignTo", _nAssignTo);
                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateHaveBackupSetToYes()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDJob set HaveBackupSet= " + (int)Dictionary.HaveBackupset.Yes + " where JobID=?";
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

        public void UpdateHaveBackupSetToNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDJob set HaveBackupSet= " + (int)Dictionary.HaveBackupset.No + " where JobID=?";
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

        public bool HaveBackupProduct()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            bool bHaveBackupSet = false;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDJob where JobID =? AND HaveBackUpSet = " + (int)Dictionary.HaveBackupset.Yes + " ";
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    bHaveBackupSet = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return bHaveBackupSet;
        }

        public bool GetNextJobNo(int nYearID, int nServiceType)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDNextJobNo where YearID=? and ServiceType=?";
            cmd.Parameters.AddWithValue("YearID", nYearID);
            cmd.Parameters.AddWithValue("ServiceType", nServiceType);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nNextJobNo = int.Parse(reader["JobNumber"].ToString());

                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return false;
            else return true;
        }

        public void InsertNextJobNo(int nUIControl, int nYearID)
        {
            int nMaxID = 0;
            int nMaxJobID = 0;
            string sShortCode = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                cmd.CommandText = "INSERT INTO t_CSDNextJobNo(YearID, ServiceType, JobNumber) Values (?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("YearID", nYearID);
                cmd.Parameters.AddWithValue("ServiceType", nUIControl);
                cmd.Parameters.AddWithValue("JobNumber", 1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetJobIDByProductSerial(string sProductSerial)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                string sSql = "Select isnull(Max(JobID),0) JobID FROM t_CSDJob where ServiceType=" + (int)Dictionary.ServiceType.Installation + " and ProductSerialNo='" + sProductSerial + "' ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nJobID = (int)reader["JobID"];
                    nCount++;
                }
                reader.Close();
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
                string sSql = "SELECT JobID,IsNull(ProductSerialNo,'') as ProductSerialNo,IsNull(InvoiceNo,'') InvoiceNo,InvoiceDate,SalesChannelID,SalesPointID,JobNo,ServiceType,JobType,"
                      + " WorkshopID,ReferenceJobNo,Priority,LastFeedBackDate,VisitingTimeFrom,VisitingTimeTo,DeliveryDate,ISNULL(Remarks,'')Remarks,a.ProductID,FullOrAccessories,"
                      + " IsNull(AccessoryID,0)AccessoryID,PrimaryFaultID,OwnOrCustomerSet,RefChannelID,IsNull(RefSalesPointID,0)RefSalesPointID,CustomerName,ISNULL(TelePhone,'')TelePhone,"
                      + " MobileNo,CustomerAddress,Email,NationalID,Status,StatusReason,a.CreateUserID,a.CreateDate,IsNull(AssignTo,0)AssignTo,ISNULL(AssignLeadMinute,0)AssignLeadMinute, "
                      + " IsNull(OwnOrOtherTechnician,0)OwnOrOtherTechnician,ReceivingTransportationMode,IsNull(ReceivingCourierID,0)ReceivingCourierID,ReceivingInstrumentNo,"
                      + " ReceivingCost,IsNull(DeliveryTransportationMode,0)DeliveryTransportationMode,IsNull(DeliveryCourierID,0)DeliveryCourierID,DeliveryInstrumentNo,"
                      + " DeliveryCost,ProductLocation,SparePartsUsed,IsNull(ActualFaultID,0)ActualFaultID,IsNull(InterSerJobType,0)InterSerJobType,IsDelivered,IsReplacement, "
                      + " ISNULL(ProductMovementStatus,0)ProductMovementStatus,ISNULL(SparePartsUsed,0)SparePartsUsed,"
                      + " ISNULL(UpdateUserID,0)UpdateUserID,UpdateDate,ISNULL(IsHappyCall,0)IsHappyCall,ISNULL(HaveBackupSet,0)HaveBackupSet,ISNULL(ProductPhysicalLocation,0)ProductPhysicalLocation from t_CSDJob a "
                      + " WHERE JobID = ?";

                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nJobID = (int)reader["JobID"];
                    _sProductSerialNo = (string)reader["ProductSerialNo"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    if (reader["InvoiceDate"] != DBNull.Value)
                    {
                        _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    }
                    _nSalesChannelID = (int)reader["SalesChannelID"];
                    _nSalesPointID = (int)reader["SalesPointID"];
                    _sJobNo = (string)reader["JobNo"];
                    _nServiceType = (int)reader["ServiceType"];
                    _nJobType = (int)reader["JobType"];
                    _nWorkshopID = (int)reader["WorkshopID"];
                    _sReferenceJobNo = (string)reader["ReferenceJobNo"];
                    _nPriority = (int)reader["Priority"];
                    if (reader["LastFeedBackDate"] != DBNull.Value)
                    {
                        _dLastFeedBackDate = Convert.ToDateTime(reader["LastFeedBackDate"].ToString());
                    }
                    if (reader["VisitingTimeFrom"] != DBNull.Value)
                    {
                        _dVisitingTimeFrom = Convert.ToDateTime(reader["VisitingTimeFrom"].ToString());
                    }
                    if (reader["VisitingTimeTo"] != DBNull.Value)
                    {
                        _dVisitingTimeTo = Convert.ToDateTime(reader["VisitingTimeTo"].ToString());
                    }

                    if (reader["DeliveryDate"] != DBNull.Value)
                    {
                        _dDeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    }
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
                    _sEmail = (string)reader["Email"];
                    _sNationalID = (string)reader["NationalID"];
                    _nStatus = (int)reader["Status"];
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
                    _nActualFaultID = (int)reader["ActualFaultID"];
                    _nInterSerJobType = (int)reader["InterSerJobType"];
                    _nIsDelivered = (int)reader["IsDelivered"];
                    _nIsReplacement = (int)reader["IsReplacement"];
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    }
                    _nIsHappyCall = (int)reader["IsHappyCall"];
                    //_nHaveBackupSet = (int)reader["HaveBackupSet"];
                    _nProductPhysicalLocation = (int)reader["ProductPhysicalLocation"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool GetJobByJobNo(string sJobNo)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " SELECT JobID,IsNull(ProductSerialNo,'') as ProductSerialNo,ISNULL(OriginalProductSerialNo,'')OriginalProductSerialNo,IsNull(InvoiceNo,'') " +
                          " InvoiceNo,InvoiceDate,SalesChannelID,SalesPointID,JobNo,ServiceType,JobType, " +
                          " WorkshopID,ReferenceJobNo,Priority,LastFeedBackDate,VisitingTimeFrom,VisitingTimeTo,DeliveryDate,ISNULL(a.Remarks,'')Remarks,a.ProductID,ProductCode,ProductName,ISNULL(ProductModel,'')ProductModel,BrandDesc,FullOrAccessories, " +
                          " IsNull(AccessoryID,0)AccessoryID,PrimaryFaultID,OwnOrCustomerSet,RefChannelID,IsNull(RefSalesPointID,0)RefSalesPointID,CustomerName,ISNULL(TelePhone,'')TelePhone, " +
                          " a.MobileNo,CustomerAddress,ISNULL(a.ThanaID,0)ThanaID,a.Email,NationalID,Status,ISNULL(a.SubStatus,0)SubStatus,ISNULL(ss.Name,'')SubStatusName,StatusReason,a.CreateUserID,a.CreateDate, " +
                          " IsNull(AssignTo,0)AssignTo,ISNULL(t.Name,'')TechnicianName,ISNULL(ThirdPartyID,0)ThirdPartyID,ISNULL(ISV.Name,'')ThirdPartyName,ISNULL(AssignLeadMinute,0)AssignLeadMinute,  " +
                          " IsNull(OwnOrOtherTechnician,0)OwnOrOtherTechnician,ReceivingTransportationMode,IsNull(ReceivingCourierID,0)ReceivingCourierID,ReceivingInstrumentNo, " +
                          " ReceivingCost,IsNull(DeliveryTransportationMode,0)DeliveryTransportationMode,IsNull(DeliveryCourierID,0)DeliveryCourierID,DeliveryInstrumentNo, " +
                          " DeliveryCost,ProductLocation,SparePartsUsed,IsNull(ActualFaultID,0)ActualFaultID,IsNull(InterSerJobType,0)InterSerJobType,IsDelivered,IsReplacement,  " +
                          " ISNULL(ProductMovementStatus,0)ProductMovementStatus,ISNULL(SparePartsUsed,0)SparePartsUsed, " +
                          " ISNULL(a.UpdateUserID,0)UpdateUserID,a.UpdateDate,ISNULL(IsHappyCall,0)IsHappyCall,ISNULL(HaveBackupSet,0)HaveBackupSet,ISNULL(ProductPhysicalLocation,0)ProductPhysicalLocation,VisitingDate,ISNULL(GSPNJobNo,'') GSPNJobNo from (Select * from t_CSDJob Where JobNo = '" + sJobNo + "') a " +
                          " INNER JOIN v_Productdetails b ON a.ProductID=b.ProductID " +
                          " LEFT OUTER JOIN t_CSDTechnician t on a.AssignTo = t.TechnicianID " +
                          " LEFT OUTER JOIN t_CSDJobStatus_Sub ss on a.SubStatus = ss.SubStatusID " +
                          " LEFT OUTER JOIN t_CSDInterService ISV ON t.ThirdPartyID = ISV.InterserviceID  ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nJobID = (int)reader["JobID"];
                    _sProductSerialNo = (string)reader["ProductSerialNo"];
                    _sOriginalProductSerialNo = (string)reader["OriginalProductSerialNo"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    if (reader["InvoiceDate"] != DBNull.Value)
                    {
                        _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    }
                    _nSalesChannelID = (int)reader["SalesChannelID"];
                    _nSalesPointID = (int)reader["SalesPointID"];
                    _sJobNo = (string)reader["JobNo"];
                    _nServiceType = (int)reader["ServiceType"];
                    _nJobType = (int)reader["JobType"];
                    _nWorkshopID = (int)reader["WorkshopID"];
                    if (reader["ReferenceJobNo"] != DBNull.Value)
                        _sReferenceJobNo = (string)reader["ReferenceJobNo"];
                    _nPriority = (int)reader["Priority"];
                    _dLastFeedBackDate = Convert.ToDateTime(reader["LastFeedBackDate"].ToString());
                    if (reader["VisitingTimeFrom"] != DBNull.Value)
                    {
                        _dVisitingTimeFrom = Convert.ToDateTime(reader["VisitingTimeFrom"].ToString());
                    }
                    if (reader["VisitingTimeTo"] != DBNull.Value)
                    {
                        _dVisitingTimeTo = Convert.ToDateTime(reader["VisitingTimeTo"].ToString());
                    }

                    if (reader["DeliveryDate"] != DBNull.Value)
                    {
                        _dDeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    }
                    _sRemarks = (string)reader["Remarks"];
                    _nProductID = (int)reader["ProductID"];
                    _sProductModel = (string)reader["ProductModel"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sBrandName = (string)reader["BrandDesc"];
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
                    _sSubStatusName = (string)reader["SubStatusName"];
                    _sStatusReason = (string)reader["StatusReason"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    if (reader["CreateDate"] != DBNull.Value)
                    {
                        _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    }
                    _nAssignTo = (int)reader["AssignTo"];
                    if (reader["TechnicianName"] != DBNull.Value)
                    {
                        _sTechnicianName = (string)reader["TechnicianName"];
                    }
                    _nThirdPartyID = (int)reader["ThirdPartyID"];
                    _sThirdPartyName = (string)reader["ThirdPartyName"]; ;
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
                    _nActualFaultID = (int)reader["ActualFaultID"];
                    _nInterSerJobType = (int)reader["InterSerJobType"];
                    _nIsDelivered = (int)reader["IsDelivered"];
                    _nIsReplacement = (int)reader["IsReplacement"];
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    }
                    _nIsHappyCall = (int)reader["IsHappyCall"];
                    _nHaveBackupset = (int)reader["HaveBackupSet"];
                    _nProductPhysicalLocation = (int)reader["ProductPhysicalLocation"];
                    if (reader["VisitingDate"] != DBNull.Value)
                    {
                        _dVisitingDate = (object)reader["VisitingDate"];
                    }
                    _sGSPNJobNo = (string)reader["GSPNJobNo"];
                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return false;
            else return true;
        }

        public bool GetCassandraJobByJobNo(string sJobNo)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select JobID, SerialNo as ProductSerialNo, '' as InvoiceNo, '' as  InvoiceDate, 4 as SalesChannelID, 0 as SalesPointID, " +
                        "JobNo, JobType, RefferenceJobNo as ReferenceJobNo, 0 as ProductID, b.Code as ProductCode, b.Name as ProductName, CustomerName, TelePhone=CASE  " +
                        "When PhoneHome = '' then PhoneOffice else PhoneHome+', '+PhoneOffice end, Mobile as MobileNo, FirstAddress as CustomerAddress, " +
                        "Email, '' as NationalID,ISNULL(Remarks,'') AS Remarks from TELServiceDB.dbo.Job a, TELServiceDB.dbo.Product b Where a.ProductID=b.ProductID and JobNo='" + sJobNo + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nJobID = int.Parse(reader["JobID"].ToString());
                    _sProductSerialNo = (string)reader["ProductSerialNo"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    //_dInvoiceDate = (object)reader["InvoiceDate"];
                    _dInvoiceDate = null;
                    _nSalesChannelID = (int)reader["SalesChannelID"];
                    _nSalesPointID = (int)reader["SalesPointID"];
                    _sJobNo = (string)reader["JobNo"];
                    _nJobType = Convert.ToInt32(reader["JobType"].ToString());
                    _sReferenceJobNo = (string)reader["ReferenceJobNo"];
                    _nProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _sTelePhone = (string)reader["TelePhone"];
                    _sMobileNo = (string)reader["MobileNo"];
                    _sCustomerAddress = (string)reader["CustomerAddress"];
                    _sEmail = (string)reader["Email"];
                    _sNationalID = (string)reader["NationalID"];
                    _sRemarks = (string)reader["Remarks"];

                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return false;
            else return true;
        }

        public int GetAssignLeadTime(int nServiceType)
        {
            int nLeadTime = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_CSDJobAssignleadtime Where ServiceType=" + nServiceType + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["LeadMinute"] != DBNull.Value)
                    {
                        nLeadTime = (int)reader["LeadMinute"];
                    }
                    else
                    {
                        nLeadTime = -1;
                    }

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nLeadTime;
        }

        public int GetTechTypeByJob(int nJobID)
        {
            int nTechType = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select b.Type from t_CSDJob a,t_CSDTechnician b  Where a.AssignTo =  b.TechnicianID and JobID = " + nJobID + " ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Type"] != DBNull.Value)
                    {
                        nTechType = (int)reader["Type"];
                    }
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nTechType;
        }

        public void UpdateProductMovement()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDJob set ProductMovementStatus = ?,ProductLocation=? where JobID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductMovementStatus", _nProductMovementStatus);
                cmd.Parameters.AddWithValue("ProductLocation", _nProductLocation);
                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateProductPhysicalLocation()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDJob set ProductPhysicalLocation=? where JobID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductPhysicalLocation", _nProductPhysicalLocation);
                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateProductLocation()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDJob set ProductLocation = 3 Where JobId in( " +
                        "Select a.Jobid from t_CSDJob a, t_CSDTechnician b " +
                        "Where a.AssignTo = b.TechnicianId and ProductMovementStatus = 2 and " +
                        "ProductLocation = 1 and ProductPhysicalLocation = 1 and IsDelivered = 0 " +
                        "and b.Type = 1 and OwnOrOtherTechnician = 1 " +
                        ") ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue("ProductLocation", _nProductLocation);
                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateEstimatedCharge()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDJob set EstSpAmount = ?,EstScAmount=? where JobID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EstSpAmount", _nEstSpAmount);
                cmd.Parameters.AddWithValue("EstScAmount", _nEstScAmount);
                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AssignToTechnician()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDJob set AssignTo = ?, OwnOrOtherTechnician=?, Status=? where JobID = ? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AssignTo", _nAssignTo);
                cmd.Parameters.AddWithValue("OwnOrOtherTechnician", _nOwnOrOtherTechnician);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool IsEstimatedJob()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_CSDJobHistory Where JobID = " + _nJobID + " and StatusID = 7 ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
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
                return false;
            else return true;
        }

        public void UpdateTpCharge()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDJob set TPMatCharge = ?, TPGasCharge = ?,TPOtherCharge=? where JobID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TPMatCharge", _TPMatCharge);
                cmd.Parameters.AddWithValue("TPGasCharge", _TPGasCharge);
                cmd.Parameters.AddWithValue("TPOtherCharge", _TPOtherCharge);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public void UpdateJobStatus(int nJobID, int nStatus, int nSubStatus)
        public void UpdateJobStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
           
            string sSql = "";

            try
            {
                if (_nStatus == (int)Dictionary.JobStatus.ServiceProvided || _nStatus == (int)Dictionary.JobStatus.Delivered)
                {
                    sSql = "Update t_CSDJob set Status = ?, SubStatus = ?,IsDelivered=?,DeliveryDate=?,UpdateUSerID=?,UpdateDate=? where JobID = ? ";

                }
                else
                {
                    sSql = "Update t_CSDJob set Status = ?, SubStatus = ?,UpdateUSerID=?,UpdateDate=? where JobID = ? ";
                }
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("SubStatus", _nSubStatus);
                if (_nStatus == (int)Dictionary.JobStatus.ServiceProvided || _nStatus == (int)Dictionary.JobStatus.Delivered)
                {
                    cmd.Parameters.AddWithValue("IsDelivered", _nIsDelivered);
                    cmd.Parameters.AddWithValue("DeliveryDate", _dDeliveryDate);
                }
                cmd.Parameters.AddWithValue("UpdateUSerID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateDeliveryStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDJob set IsDelivered = ?,DeliveryDate=?  where JobID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsDelivered", _nIsDelivered);
                cmd.Parameters.AddWithValue("DeliveryDate", _dDeliveryDate);
                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void UpdateDeliveryLocation()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDJob set DeliveryLocation=?  where JobID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DeliveryLocation", Utility.JobLocation);
                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateLastFeedbackdate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDJob set LastFeedbackDate = ? where JobID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LastFeedbackDate", _dLastFeedBackDate);
                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public void UpdateStatusForcely()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";

        //    try
        //    {
        //        sSql = "Update t_CSDJob set StatusReason = ? where JobID = ? ";
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Parameters.AddWithValue("StatusReason", _sStatusReason);
        //        cmd.Parameters.AddWithValue("JobID", _nJobID);
        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        public void UpdateStatusReason()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDJob set StatusReason = ? where JobID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("StatusReason", _sStatusReason);

                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateVisitingTime()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDJob set VisitingTimeFrom = ?,VisitingTimeTo=?,VisitingDate=? where JobID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VisitingTimeFrom", _dVisitingTimeFrom);
                cmd.Parameters.AddWithValue("VisitingTimeTo", _dVisitingTimeTo);
                cmd.Parameters.AddWithValue("VisitingDate", _dVisitingDate);
                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool GetInvoice(String sInvoiceNo)
        {
            int nCount = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "Select ProductSerialNo,InvoiceNo,InvoiceDate,SalesPointID,ProductID, " +
            //            "ProductCode,ProductName,CustomerName,TelePhone,MobileNo,CustomerAddress,Email, NationalID " +
            //            "From " +
            //            "( " +
            //            "select IsNull(ProductSerialNo,'') as ProductSerialNo, InvoiceNo, InvoiceDate, a.CustomerID as SalesPointID, " +
            //            " b.ProductID, ProductCode, ProductName, IsNull(ConsumerName,'') as CustomerName,  " +
            //            "IsNull(PhoneNo,'') as TelePhone, IsNull(CellNo,'') as MobileNo, IsNull(Address,'') as CustomerAddress,  " +
            //            "IsNull(Email,'') as Email, IsNull(NationalID,'') as NationalID from (Select * from t_SalesInvoice Where SundryCustomerID Is Not Null ) a " +
            //            "INNER JOIN t_SalesInvoiceDetail b " +
            //            "ON a.InvoiceID=b.InvoiceID " +
            //            "INNER JOIN " +
            //            "t_Product prod " +
            //            "ON b.ProductID=prod.ProductID " +
            //            "Left Outer JOIN " +
            //            "dbo.t_RetailConsumer c ON a.SundryCustomerID=c.ConsumerID and a.WarehouseID=c.WarehouseID " +
            //            "Left Outer JOIN  " +
            //            "t_SalesInvoiceProductSerial d " +
            //            "ON b.ProductID=d.ProductID and b.InvoiceID=d.InvoiceID " +
            //            ") as a Where InvoiceNo = '" + sInvoiceNo + "'";

            string sSql = @"Select ProductSerialNo,InvoiceNo,InvoiceDate,SalesPointID,ProductID, 
                            ProductCode,ProductName,CustomerName,TelePhone,MobileNo,CustomerAddress,Email, NationalID 
                            From 
                            ( 
                            --TD----
                            select IsNull(ProductSerialNo,'') as ProductSerialNo, InvoiceNo, InvoiceDate, a.CustomerID as SalesPointID, 
                             b.ProductID, ProductCode, ProductName, IsNull(ConsumerName,'') as CustomerName,  
                            IsNull(PhoneNo,'') as TelePhone, IsNull(CellNo,'') as MobileNo, IsNull(Address,'') as CustomerAddress,  
                            IsNull(c.Email,'') as Email, IsNull(NationalID,'') as NationalID from (Select * 
                            from t_SalesInvoice Where SundryCustomerID Is Not Null ) a 
                            INNER JOIN t_SalesInvoiceDetail b 
                            ON a.InvoiceID=b.InvoiceID 
                            INNER JOIN 
                            t_Product prod 
                            ON b.ProductID=prod.ProductID 
                            INNER JOIN t_Showroom s ON a.WarehouseID = s.WarehouseID 
                            Left Outer JOIN 
                            dbo.t_RetailConsumer c ON a.SundryCustomerID=c.ConsumerID and  a.WarehouseID = c.WarehouseID 
                            Left Outer JOIN  
                            t_SalesInvoiceProductSerial d 
                            ON b.ProductID=d.ProductID and b.InvoiceID=d.InvoiceID 
                            UNION ALL

                            -- EPS----
                            Select IsNull(ProductSerialNo,'') as ProductSerialNo, InvoiceNo, InvoiceDate, b.CustomerID as SalesPointID, 
                            d.ProductID, ProductCode, ProductName, IsNull(EmployeeName,'') as CustomerName,  
                            '' as TelePhone, IsNull(PhoneNo,'') as MobileNo, IsNull(EmployeeAddress,'') as CustomerAddress,  
                            IsNull(c.Email,'') as Email, '' as NationalID 
                            from t_EPSSales a 
                            INNER JOIN t_SalesInvoice b
                            ON a.OrderID = b.OrderID
                            INNER JOIN
                            t_EPSCustomer c
                            ON a.EPSCustomerID = c.EPSCustomerID
                            INNER JOIN
                            t_SalesInvoiceDetail d
                            ON b.InvoiceID = d.InvoiceID
                            INNER JOIN
                            t_Product e 
                            ON d.ProductID = e.ProductID
                            Left Outer JOIN
                            t_SalesInvoiceProductSerial f 
                            ON d.ProductID = f.ProductID and d.InvoiceID = f.InvoiceID

                            UNION ALL

                            --Others----
                            select IsNull(ProductSerialNo,'') as ProductSerialNo, InvoiceNo, InvoiceDate, a.CustomerID as SalesPointID, 
                             prod.ProductID, ProductCode, ProductName, IsNull(CustomerName,'') as CustomerName,  
                            IsNull(CustomerTelephone,'') as TelePhone, IsNull(CellPhoneNumber,'') as MobileNo, IsNull(CustomerAddress,'') as CustomerAddress,  
                            '' as Email, '' as NationalID from (Select * 
                            from t_SalesInvoice Where WarehouseID <> 71 and WarehouseID NOT IN (Select WarehouseID from t_Showroom)) a 
                            INNER JOIN t_SalesInvoiceDetail b 
                            ON a.InvoiceID=b.InvoiceID 
                            INNER JOIN 
                            t_Product prod 
                            ON b.ProductID = prod.ProductID 
                            INNER JOIN
                            t_Customer cust ON Cust.CustomerID = a.CustomerID
                            Left Outer JOIN  
                            t_SalesInvoiceProductSerial d 
                            ON b.ProductID = d.ProductID and b.InvoiceID = d.InvoiceID

                            ) as a Where 1=1 and Invoiceno='" + sInvoiceNo + "' ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _sProductSerialNo = (string)reader["ProductSerialNo"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _nSalesPointID = (int)reader["SalesPointID"];
                    _nProductID = (int)reader["ProductID"];
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _sTelePhone = (string)reader["TelePhone"];
                    _sMobileNo = (string)reader["MobileNo"];
                    _sCustomerAddress = (string)reader["CustomerAddress"];
                    _sEmail = (string)reader["Email"];
                    _sNationalID = (string)reader["NationalID"];

                    nCount++;
                }
                reader.Close();

                if (nCount != 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool GetCassiopeiaInvoice(String sInvoiceNo)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ProductSerialNo,InvoiceNo,InvoiceDate,SalesPointCode, " +
                        "ProductCode,ProductName,CustomerName,TelePhone,MobileNo,CustomerAddress,Email, NationalID " +
                        "from  " +
                        "(Select InvoiceID, ShowroomID, TranDate as InvoiceDate, TranNo as InvoiceNo, CustomerID from Cassiopeia_HO.dbo.Invoice) as a " +
                        "INNER JOIN " +
                        "(Select InvoiceID,ShowroomID,ProductID, IsNull(BarCodeOrMSlNo,'') as ProductSerialNo from Cassiopeia_HO.dbo.InvoiceItem ) as b " +
                        "ON a.InvoiceID=b.InvoiceID and a.ShowroomID=b.ShowroomID  " +
                        "INNER JOIN  " +
                        "(Select ProductID, Code as ProductCode, Name as ProductName from Cassiopeia_HO.dbo.Product) as c " +
                        "ON b.ProductID=c.ProductID  " +
                        "INNER JOIN  " +
                        "(Select CustomerID,ShowroomID,IsNull(Name,'') as CustomerName, IsNull(Address,'') as CustomerAddress,  " +
                        "IsNull(MobileNo,'')as MobileNo,IsNull(TelNo,'') as TelePhone,IsNull(Email,'') as Email,IsNull(NationalID,'') as NationalID from Cassiopeia_HO.dbo.Customer) as d " +
                        "ON a.ShowroomID=d.ShowroomID and a.CustomerID=d.CustomerID " +
                        "INNER JOIN (Select ShowroomID,CustomerID as SalesPointCode from Cassiopeia_HO.dbo.Showroom) as e " +
                        "ON a.ShowroomID=e.ShowroomID Where InvoiceNo = '" + sInvoiceNo + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _sProductSerialNo = (string)reader["ProductSerialNo"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _sCustomerCode = Convert.ToString(reader["SalesPointCode"]);
                    _sProductCode = (string)reader["ProductCode"];
                    _sProductName = (string)reader["ProductName"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _sTelePhone = (string)reader["TelePhone"];
                    _sMobileNo = (string)reader["MobileNo"];
                    _sCustomerAddress = (string)reader["CustomerAddress"];
                    _sEmail = (string)reader["Email"];
                    _sNationalID = (string)reader["NationalID"];

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            if (nCount != 0)
                return true;
            else return false;
        }
        public void UpdateIsHappyCall()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "UPDATE t_CSDJob set IsHappyCall = ? WHERE JobID = ? ";                           
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("IsHappyCall", _nIsHappyCall);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateSparePartUse(int nJobID, bool _bFlag)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                if (_bFlag)
                {
                    sSql = "Update t_CSDJob set SparePartsUsed = " + (int)Dictionary.YesOrNoStatus.YES + " where JobID = ? ";
                }
                else
                {
                    sSql = "Update t_CSDJob set SparePartsUsed = " + (int)Dictionary.YesOrNoStatus.NO + " where JobID = ? ";
                }
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobID", nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetRefChannel(int nJobID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select RefChannelID, ServiceType from t_CSDJob Where JobID = " + nJobID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nRefChannelID = (int)reader["RefChannelID"];
                    _nServiceType = (int)reader["ServiceType"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetSubStatus(int nJobID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select Status, SubStatus, StatusReason from t_CSDJob Where JobID = " + nJobID + " ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Status"] != DBNull.Value)
                        _nStatus = (int)reader["Status"];
                    else _nStatus = 0;

                    if (reader["SubStatus"] != DBNull.Value)
                        _nSubStatus = (int)reader["SubStatus"];
                    else _nSubStatus = 0;

                    if (reader["StatusReason"] != DBNull.Value)
                        _sStatusReason = (string)reader["StatusReason"];
                    else _sStatusReason = "";

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void AddJobBill()
        {
            int nMaxBillID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([BillID]) FROM t_CSDJobBillSend";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBillID = 1;
                }
                else
                {
                    nMaxBillID = Convert.ToInt32(maxID) + 1;
                }
                _nBillID = nMaxBillID;


                string sBillNo = "";
                DateTime dToday = DateTime.Today;
                sBillNo = "Bill" + "-" + dToday.ToString("yy") + _nBillID.ToString("000");
                _sBillNo = sBillNo;

                sSql = "INSERT INTO t_CSDJobBillSend (BillID,BillNo,BillAmount,SendUserID,SendDate,ReceiveUserID,ReceiveDate,Status,JobLocationId) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BillID", _nBillID);
                cmd.Parameters.AddWithValue("BillNo", _sBillNo);
                cmd.Parameters.AddWithValue("BillAmount", 0);
                cmd.Parameters.AddWithValue("SendUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("SendDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("ReceiveUserID", null);
                cmd.Parameters.AddWithValue("ReceiveDate", null);
                cmd.Parameters.AddWithValue("Status", _nBillStatus);
                cmd.Parameters.AddWithValue("JobLocationId", Utility.JobLocation);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddJobBillDetail()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                cmd.CommandText = "INSERT INTO t_CSDJobBillSendItem(BillID, JobID, Amount) Values (?,?,?)";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BillID", _nBillID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("Amount", _BillAmount);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetBillAmount()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                string sSql = "Select sum(Amount) TotalBill From t_CSDJobBillSendItem where BillID = ?";

                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("BillID", _nBillID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _BillAmount = (double)reader["TotalBill"];

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateJobBillAmount()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDJobBillSend set BillAmount = ? where BillID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BillAmount", _BillAmount);
                cmd.Parameters.AddWithValue("BillID", _nBillID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateJobBillStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_CSDJobBillSend set ReceiveUserID = ?, ReceiveDate = ?, Status = ? where BillID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ReceiveUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("ReceiveDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("Status", _nBillStatus);
                cmd.Parameters.AddWithValue("BillID", _nBillID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void ConvertHomeCallJob()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = " Update t_CSDJob set Status = ?,ServiceType=?, ProductMovementStatus=?,ProductLocation=?, " +
                        " ProductPhysicalLocation=?, UpdateUserID=?,UpdateDate=? where JobID = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ServiceType", _nServiceType);
                cmd.Parameters.AddWithValue("ProductMovementStatus", _nProductMovementStatus);
                cmd.Parameters.AddWithValue("ProductLocation", _nProductLocation);
                cmd.Parameters.AddWithValue("ProductPhysicalLocation", _nProductPhysicalLocation);

                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshBillForReport(int nBillID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {

                cmd.CommandText = @"Select * From  (  
                                Select BillID,BillNo,BillAmount,  
                                SendUserID,a.UserName as SendUserName,  
                                SendDate,ReceiveUserID,c.UserName as ReceiveUserName,ReceiveDate,Status  
                                From   
                                (Select * From t_CSDJobBillSend a,t_User b  where a.SendUserID=b.UserID) a  
                                Left Outer Join   
                                (Select * From t_User) c   
                                on a.ReceiveUserID=c.UserID  ) 
                                Main where BillID = ?";


                cmd.Parameters.AddWithValue("BillID", nBillID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nBillID = int.Parse(reader["BillID"].ToString());
                    _sBillNo = (string)reader["BillNo"];
                    _BillAmount = Convert.ToDouble(reader["BillAmount"].ToString());
                    _sSendUserName = (string)reader["SendUserName"];
                    _dSendDate = Convert.ToDateTime(reader["SendDate"].ToString());

                    if (reader["ReceiveUserName"] != DBNull.Value)
                    {
                        _sReceiveUserName = (string)reader["ReceiveUserName"];
                    }
                    else _sReceiveUserName = "";

                    if (reader["ReceiveDate"] != DBNull.Value)
                    {
                        _dReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());
                    }
                    else _dReceiveDate = "";
                    _nBillStatus = int.Parse(reader["Status"].ToString());

                }
                GetBillItemforReport(nBillID);

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetBillItemforReport(int nBillID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = @"Select BillID,a.JobID,JobNo,a.CreateDate,'['+ProductCode+']'+' '+ProductName as ProductName, 
                                 CustomerName,a.MobileNo,c.Name as TechnicianName,sum(Amount) BillAmount  
                                 From t_CSDJob a,v_ProductDetails b, t_CSDTechnician c,t_CSDJobBillSendItem d  
                                 where a.ProductID=b.ProductID and a.AssignTo = c.TechnicianID and a.JobID=d.JobID
                                 and BillID=?
                                 group by BillID,a.JobID,JobNo,a.CreateDate,ProductCode,ProductName,ASGName, 
                                 CustomerName,a.MobileNo,c.Name";

                cmd.Parameters.AddWithValue("BillID", nBillID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJobBillSendItem oItem = new CSDJobBillSendItem();

                    oItem.BillID = int.Parse(reader["BillID"].ToString());
                    oItem.JobID = int.Parse(reader["JobID"].ToString());
                    oItem.JobNo = (reader["JobNo"].ToString());
                    oItem.JobDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.CustomerName = (reader["CustomerName"].ToString());
                    oItem.MobileNo = (reader["MobileNo"].ToString());
                    oItem.TechnicianName = (reader["TechnicianName"].ToString());
                    oItem.BillAmount = Convert.ToDouble(reader["BillAmount"].ToString());
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
    public class CSDJobs : CollectionBase
    {
        public CSDJob this[int i]
        {
            get { return (CSDJob)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDJob oCSDJob)
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
        public void RefreshForSparePartsAssign(string sJobNo, string sCustomerName, string sContactNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT JobID,IsNull(ProductSerialNo,'') as ProductSerialNo,ISNULL(OriginalProductSerialNo,'')OriginalProductSerialNo,IsNull(InvoiceNo,'') InvoiceNo,InvoiceDate,SalesChannelID,SalesPointID,JobNo,ServiceType,JobType,"
                          + " WorkshopID,ReferenceJobNo,Priority,LastFeedBackDate,DeliveryDate,Remarks,a.ProductID,FullOrAccessories,"
                          + " IsNull(AccessoryID,0)AccessoryID,PrimaryFaultID,OwnOrCustomerSet,RefChannelID,IsNull(RefSalesPointID,0)RefSalesPointID,CustomerName,TelePhone,"
                          + " MobileNo,CustomerAddress,ISNULL(ThanaID,0)ThanaID,Email,NationalID,Status,ISNULL(SubStatus,0)SubStatus,StatusReason,a.CreateUserID,a.CreateDate,IsNull(AssignTo,0)AssignTo,"
                          + " IsNull(OwnOrOtherTechnician,0)OwnOrOtherTechnician,ReceivingTransportationMode,IsNull(ReceivingCourierID,0)ReceivingCourierID,ReceivingInstrumentNo,"
                          + " ReceivingCost,IsNull(DeliveryTransportationMode,0)DeliveryTransportationMode,IsNull(DeliveryCourierID,0)DeliveryCourierID,DeliveryInstrumentNo,"
                          + " DeliveryCost,ProductLocation,SparePartsUsed,IsNull(ActualFaultID,0)ActualFaultID,IsNull(InterSerJobType,0)InterSerJobType,IsDelivered,IsReplacement,ISNULL(FaultDescription,'') FaultDescription from t_CSDJob a "
                          + " LEFT JOIN t_CSDProductFault b ON a.PrimaryFaultID = b.FaultID "
                          + "  WHERE 1=1 ";

            if (sJobNo != string.Empty)
            {
                sSql += "AND JobNo LIKE '%" + sJobNo + "%' ";
            }
            if (sCustomerName != string.Empty)
            {
                sSql += "AND CustomerName LIKE '%" + sCustomerName + "%' ";
            }
            if (sContactNo != string.Empty)
            {
                sSql += "AND MobileNo LIKE '%" + sContactNo + "%' ";
            }

            sSql = sSql + " order by JobID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CSDJob oCSDJob = new CSDJob();

                    oCSDJob.JobID = (int)reader["JobID"];
                    oCSDJob.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oCSDJob.OriginalProductSerialNo = (string)reader["OriginalProductSerialNo"];
                    oCSDJob.InvoiceNo = (string)reader["InvoiceNo"];
                    oCSDJob.InvoiceDate = (object)reader["InvoiceDate"];
                    oCSDJob.SalesChannelID = (int)reader["SalesChannelID"];
                    oCSDJob.SalesPointID = (int)reader["SalesPointID"];
                    oCSDJob.JobNo = (string)reader["JobNo"];
                    oCSDJob.ServiceType = (int)reader["ServiceType"];
                    oCSDJob.JobType = (int)reader["JobType"];
                    oCSDJob.WorkshopID = (int)reader["WorkshopID"];
                    if (reader["ReferenceJobNo"] != DBNull.Value)
                    oCSDJob.ReferenceJobNo = (string)reader["ReferenceJobNo"];
                    oCSDJob.Priority = (int)reader["Priority"];
                    oCSDJob.LastFeedBackDate = Convert.ToDateTime(reader["LastFeedBackDate"].ToString());
                    oCSDJob.DeliveryDate = (object)reader["DeliveryDate"];
                    if (reader["Remarks"] != DBNull.Value)
                    oCSDJob.Remarks = (string)reader["Remarks"];
                    oCSDJob.ProductID = (int)reader["ProductID"];
                    oCSDJob.FullOrAccessories = (int)reader["FullOrAccessories"];
                    oCSDJob.AccessoryID = (int)reader["AccessoryID"];
                    oCSDJob.PrimaryFaultID = (int)reader["PrimaryFaultID"];
                    oCSDJob.OwnOrCustomerSet = (int)reader["OwnOrCustomerSet"];
                    oCSDJob.RefChannelID = (int)reader["RefChannelID"];
                    oCSDJob.RefSalesPointID = (int)reader["RefSalesPointID"];
                    oCSDJob.CustomerName = (string)reader["CustomerName"];
                    oCSDJob.TelePhone = (string)reader["TelePhone"];
                    oCSDJob.MobileNo = (string)reader["MobileNo"];
                    oCSDJob.CustomerAddress = (string)reader["CustomerAddress"];
                    oCSDJob.ThanaID = (int)reader["ThanaID"];
                    oCSDJob.Email = (string)reader["Email"];
                    oCSDJob.NationalID = (string)reader["NationalID"];
                    oCSDJob.Status = (int)reader["Status"];
                    oCSDJob.SubStatus = (int)reader["SubStatus"];
                    oCSDJob.StatusReason = (string)reader["StatusReason"];
                    oCSDJob.CreateUserID = (int)reader["CreateUserID"];
                    oCSDJob.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDJob.AssignTo = (int)reader["AssignTo"];
                    oCSDJob.OwnOrOtherTechnician = (int)reader["OwnOrOtherTechnician"];
                    oCSDJob.ReceivingTransportationMode = (int)reader["ReceivingTransportationMode"];
                    oCSDJob.ReceivingCourierID = (int)reader["ReceivingCourierID"];
                    if (reader["ReceivingInstrumentNo"]!= DBNull.Value)
                    oCSDJob.ReceivingInstrumentNo = (string)reader["ReceivingInstrumentNo"];
                    oCSDJob.ReceivingCost = Convert.ToDouble(reader["ReceivingCost"].ToString());
                    oCSDJob.DeliveryTransportationMode = (int)reader["DeliveryTransportationMode"];
                    oCSDJob.DeliveryCourierID = (int)reader["DeliveryCourierID"];
                    if (reader["DeliveryInstrumentNo"] != DBNull.Value)
                    oCSDJob.DeliveryInstrumentNo = (string)reader["DeliveryInstrumentNo"];
                    oCSDJob.DeliveryCost = Convert.ToDouble(reader["DeliveryCost"].ToString());
                    oCSDJob.ProductLocation = (int)reader["ProductLocation"];
                    oCSDJob.SparePartsUsed = (int)reader["SparePartsUsed"];
                    oCSDJob.ActualFaultID = (int)reader["ActualFaultID"];
                    oCSDJob.InterSerJobType = (int)reader["InterSerJobType"];
                    oCSDJob.IsDelivered = (int)reader["IsDelivered"];
                    oCSDJob.IsReplacement = (int)reader["IsReplacement"];
                    oCSDJob.FaultDescription = (string)reader["FaultDescription"];

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
        public void GetJobForForcelyStatusUpdate(string sJobNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @"SELECT JobID,IsNull(ProductSerialNo,'') as ProductSerialNo,IsNull(OriginalProductSerialNo,'') as OriginalProductSerialNo,
                          IsNull(InvoiceNo,'')InvoiceNo,InvoiceDate,SalesChannelID,SalesPointID,JobNo,ServiceType,JobType,
                          WorkshopID,IsNull(ReferenceJobNo,'') as ReferenceJobNo,IsNull(GSPNJobNo,'') as GSPNJobNo, Priority,LastFeedBackDate,DeliveryDate,a.Remarks,a.ProductID,FullOrAccessories,
                          IsNull(AccessoryID,0)AccessoryID,PrimaryFaultID,OwnOrCustomerSet,RefChannelID,IsNull(RefSalesPointID,0)RefSalesPointID,CustomerName,TelePhone,
                          a.MobileNo,CustomerAddress,a.Email,NationalID,Status,ISNULL(SubStatus,0)SubStatus,StatusReason,a.CreateUserID,a.CreateDate,IsNull(AssignTo,0)AssignTo,
                          IsNull(OwnOrOtherTechnician,0)OwnOrOtherTechnician,ReceivingTransportationMode,IsNull(ReceivingCourierID,0)ReceivingCourierID,ReceivingInstrumentNo,ReceivingCost,
                          IsNull(DeliveryTransportationMode,0)DeliveryTransportationMode,IsNull(DeliveryCourierID,0)DeliveryCourierID,DeliveryInstrumentNo,DeliveryCost,ProductLocation,SparePartsUsed,
                          IsNull(ActualFaultID,0)ActualFaultID,IsNull(InterSerJobType,0)InterSerJobType,IsDelivered,IsReplacement,HaveBackupSet, IsNull(a.ThanaID,0) as ThanaID,
                          VisitingDate,VisitingTimeFrom,VisitingTimeTo,ProductPhysicalLocation,ProductMovementStatus,ProductName from t_CSDJob a,
                          (Select ProductID, ProductCode, ProductName from t_Product) b
                          where a.ProductID = b.ProductID ";
            if (sJobNo != string.Empty)
            {
                sSql += " AND a.JobNo LIKE '%" + sJobNo + "%' ";
            }
            sSql += " ORDER BY JobID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJob oCSDJob = new CSDJob();

                    oCSDJob.JobID = (int)reader["JobID"];
                    oCSDJob.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oCSDJob.OriginalProductSerialNo = (string)reader["OriginalProductSerialNo"];
                    oCSDJob.InvoiceNo = (string)reader["InvoiceNo"];
                    oCSDJob.InvoiceDate = (object)reader["InvoiceDate"];
                    oCSDJob.SalesChannelID = (int)reader["SalesChannelID"];
                    oCSDJob.SalesPointID = (int)reader["SalesPointID"];
                    oCSDJob.JobNo = (string)reader["JobNo"];
                    oCSDJob.ServiceType = (int)reader["ServiceType"];
                    oCSDJob.JobType = (int)reader["JobType"];
                    oCSDJob.WorkshopID = (int)reader["WorkshopID"];
                    oCSDJob.ReferenceJobNo = (string)reader["ReferenceJobNo"];
                    oCSDJob.Priority = (int)reader["Priority"];
                    oCSDJob.LastFeedBackDate = Convert.ToDateTime(reader["LastFeedBackDate"].ToString());
                    oCSDJob.DeliveryDate = (object)reader["DeliveryDate"];
                    oCSDJob.Remarks = (string)reader["Remarks"];
                    oCSDJob.ProductID = (int)reader["ProductID"];
                    oCSDJob.FullOrAccessories = (int)reader["FullOrAccessories"];
                    oCSDJob.AccessoryID = (int)reader["AccessoryID"];
                    oCSDJob.PrimaryFaultID = (int)reader["PrimaryFaultID"];
                    //oCSDJob.FaultDescription = (string)reader["FaultDescription"];
                    oCSDJob.ProductName = (string)reader["ProductName"];
                    oCSDJob.OwnOrCustomerSet = (int)reader["OwnOrCustomerSet"];
                    oCSDJob.RefChannelID = (int)reader["RefChannelID"];
                    oCSDJob.RefSalesPointID = (int)reader["RefSalesPointID"];
                    oCSDJob.CustomerName = (string)reader["CustomerName"];
                    oCSDJob.TelePhone = (string)reader["TelePhone"];
                    oCSDJob.MobileNo = (string)reader["MobileNo"];
                    oCSDJob.CustomerAddress = (string)reader["CustomerAddress"];
                    oCSDJob.Email = (string)reader["Email"];
                    oCSDJob.NationalID = (string)reader["NationalID"];
                    oCSDJob.Status = (int)reader["Status"];
                    oCSDJob.SubStatus = (int)reader["SubStatus"];
                    oCSDJob.StatusReason = (string)reader["StatusReason"];
                    oCSDJob.CreateUserID = (int)reader["CreateUserID"];
                    oCSDJob.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDJob.AssignTo = (int)reader["AssignTo"];
                    oCSDJob.ReceivingTransportationMode = (int)reader["ReceivingTransportationMode"];
                    oCSDJob.ReceivingCourierID = (int)reader["ReceivingCourierID"];
                    if (reader["ReceivingInstrumentNo"] != DBNull.Value)
                    oCSDJob.ReceivingInstrumentNo = (string)reader["ReceivingInstrumentNo"];
                    oCSDJob.ReceivingCost = Convert.ToDouble(reader["ReceivingCost"].ToString());
                    oCSDJob.DeliveryTransportationMode = (int)reader["DeliveryTransportationMode"];
                    oCSDJob.DeliveryCourierID = (int)reader["DeliveryCourierID"];
                    if (reader["DeliveryInstrumentNo"] != DBNull.Value)
                    oCSDJob.DeliveryInstrumentNo = (string)reader["DeliveryInstrumentNo"];
                    oCSDJob.DeliveryCost = Convert.ToDouble(reader["DeliveryCost"].ToString());
                    oCSDJob.ProductLocation = (int)reader["ProductLocation"];
                    oCSDJob.SparePartsUsed = (int)reader["SparePartsUsed"];
                    oCSDJob.ActualFaultID = (int)reader["ActualFaultID"];
                    oCSDJob.InterSerJobType = (int)reader["InterSerJobType"];
                    oCSDJob.IsDelivered = (int)reader["IsDelivered"];
                    oCSDJob.IsReplacement = (int)reader["IsReplacement"];
                    oCSDJob.HaveBackupset = (int)reader["HaveBackupSet"];
                    oCSDJob.ThanaID = (int)reader["ThanaID"];
                    if (reader["GSPNJobNo"] != DBNull.Value)
                    oCSDJob.GSPNJobNo = (string)reader["GSPNJobNo"];
                    oCSDJob.ProductPhysicalLocation = (int)reader["ProductPhysicalLocation"];
                    oCSDJob.ProductMovementStatus = (int)reader["ProductMovementStatus"];
                    if (reader["VisitingDate"] != null)
                    {
                        oCSDJob.VisitingDate = (object)reader["VisitingDate"];
                    }
                    if (reader["VisitingTimeFrom"] != null)
                    {
                        oCSDJob.VisitingTimeFrom = (object)reader["VisitingTimeFrom"];
                    }
                    if (reader["VisitingTimeTo"] != null)
                    {
                        oCSDJob.VisitingTimeTo = (object)reader["VisitingTimeTo"];
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
        public void GetJobForCancel(string sJobNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @"SELECT JobID,IsNull(ProductSerialNo,'') as ProductSerialNo,IsNull(OriginalProductSerialNo,'') as OriginalProductSerialNo,
                          IsNull(InvoiceNo,'')InvoiceNo,InvoiceDate,SalesChannelID,SalesPointID,JobNo,ServiceType,JobType,
                          WorkshopID,IsNull(ReferenceJobNo,'') as ReferenceJobNo,IsNull(GSPNJobNo,'') as GSPNJobNo, Priority,LastFeedBackDate,DeliveryDate,a.Remarks,a.ProductID,FullOrAccessories,
                          IsNull(AccessoryID,0)AccessoryID,PrimaryFaultID,OwnOrCustomerSet,RefChannelID,IsNull(RefSalesPointID,0)RefSalesPointID,CustomerName,TelePhone,
                          a.MobileNo,CustomerAddress,a.Email,NationalID,Status,ISNULL(SubStatus,0)SubStatus,StatusReason,a.CreateUserID,a.CreateDate,IsNull(AssignTo,0)AssignTo,
                          IsNull(OwnOrOtherTechnician,0)OwnOrOtherTechnician,ReceivingTransportationMode,IsNull(ReceivingCourierID,0)ReceivingCourierID,ReceivingInstrumentNo,ReceivingCost,
                          IsNull(DeliveryTransportationMode,0)DeliveryTransportationMode,IsNull(DeliveryCourierID,0)DeliveryCourierID,DeliveryInstrumentNo,DeliveryCost,ProductLocation,SparePartsUsed,
                          IsNull(ActualFaultID,0)ActualFaultID,IsNull(InterSerJobType,0)InterSerJobType,IsDelivered,IsReplacement,HaveBackupSet, IsNull(a.ThanaID,0) as ThanaID,
                          VisitingDate,VisitingTimeFrom,VisitingTimeTo,ProductPhysicalLocation,ProductName,IsNull(RemoteServiceProvidedAmount,0) RemoteServiceProvidedAmount from t_CSDJob a,
                          (Select ProductID, ProductCode, ProductName from t_Product) b
                          where a.ProductID = b.ProductID AND a.Status NOT IN (13,17,20,27) AND SparePartsUsed = 0 ";
            if (sJobNo != string.Empty)
            {
                sSql += " AND a.JobNo LIKE '%" + sJobNo + "%' ";
            }

            //sSql +=" ORDER BY JobID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJob oCSDJob = new CSDJob();

                    oCSDJob.JobID = (int)reader["JobID"];
                    oCSDJob.ProductName = (string)reader["ProductName"];
                    oCSDJob.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oCSDJob.OriginalProductSerialNo = (string)reader["OriginalProductSerialNo"];
                    oCSDJob.InvoiceNo = (string)reader["InvoiceNo"];
                    oCSDJob.InvoiceDate = (object)reader["InvoiceDate"];
                    oCSDJob.SalesChannelID = (int)reader["SalesChannelID"];
                    oCSDJob.SalesPointID = (int)reader["SalesPointID"];
                    oCSDJob.JobNo = (string)reader["JobNo"];
                    oCSDJob.ServiceType = (int)reader["ServiceType"];
                    oCSDJob.JobType = (int)reader["JobType"];
                    oCSDJob.WorkshopID = (int)reader["WorkshopID"];
                    oCSDJob.ReferenceJobNo = (string)reader["ReferenceJobNo"];
                    oCSDJob.Priority = (int)reader["Priority"];
                    oCSDJob.LastFeedBackDate = Convert.ToDateTime(reader["LastFeedBackDate"].ToString());
                    oCSDJob.DeliveryDate = (object)reader["DeliveryDate"];
                    oCSDJob.Remarks = (string)reader["Remarks"];
                    oCSDJob.ProductID = (int)reader["ProductID"];
                    oCSDJob.FullOrAccessories = (int)reader["FullOrAccessories"];
                    oCSDJob.AccessoryID = (int)reader["AccessoryID"];
                    oCSDJob.PrimaryFaultID = (int)reader["PrimaryFaultID"];
                    //oCSDJob.FaultDescription = (string)reader["FaultDescription"];
                    oCSDJob.OwnOrCustomerSet = (int)reader["OwnOrCustomerSet"];
                    oCSDJob.RefChannelID = (int)reader["RefChannelID"];
                    oCSDJob.RefSalesPointID = (int)reader["RefSalesPointID"];
                    oCSDJob.CustomerName = (string)reader["CustomerName"];
                    oCSDJob.TelePhone = (string)reader["TelePhone"];
                    oCSDJob.MobileNo = (string)reader["MobileNo"];
                    oCSDJob.CustomerAddress = (string)reader["CustomerAddress"];
                    oCSDJob.Email = (string)reader["Email"];
                    oCSDJob.NationalID = (string)reader["NationalID"];
                    oCSDJob.Status = (int)reader["Status"];
                    oCSDJob.SubStatus = (int)reader["SubStatus"];
                    oCSDJob.StatusReason = (string)reader["StatusReason"];
                    oCSDJob.CreateUserID = (int)reader["CreateUserID"];
                    oCSDJob.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDJob.AssignTo = (int)reader["AssignTo"];
                    oCSDJob.ReceivingTransportationMode = (int)reader["ReceivingTransportationMode"];
                    oCSDJob.ReceivingCourierID = (int)reader["ReceivingCourierID"];
                    oCSDJob.ReceivingInstrumentNo = (string)reader["ReceivingInstrumentNo"];
                    oCSDJob.ReceivingCost = Convert.ToDouble(reader["ReceivingCost"].ToString());
                    oCSDJob.DeliveryTransportationMode = (int)reader["DeliveryTransportationMode"];
                    oCSDJob.DeliveryCourierID = (int)reader["DeliveryCourierID"];
                    oCSDJob.DeliveryInstrumentNo = (string)reader["DeliveryInstrumentNo"];
                    oCSDJob.DeliveryCost = Convert.ToDouble(reader["DeliveryCost"].ToString());
                    oCSDJob.ProductLocation = (int)reader["ProductLocation"];
                    oCSDJob.SparePartsUsed = (int)reader["SparePartsUsed"];
                    oCSDJob.ActualFaultID = (int)reader["ActualFaultID"];
                    oCSDJob.InterSerJobType = (int)reader["InterSerJobType"];
                    oCSDJob.IsDelivered = (int)reader["IsDelivered"];
                    oCSDJob.IsReplacement = (int)reader["IsReplacement"];
                    oCSDJob.HaveBackupset = (int)reader["HaveBackupSet"];
                    oCSDJob.ThanaID = (int)reader["ThanaID"];
                    oCSDJob.GSPNJobNo = (string)reader["GSPNJobNo"];
                    oCSDJob.ProductPhysicalLocation = (int)reader["ProductPhysicalLocation"];
                    if (reader["VisitingDate"] != null)
                    {
                        oCSDJob.VisitingDate = (object)reader["VisitingDate"];
                    }
                    if (reader["VisitingTimeFrom"] != null)
                    {
                        oCSDJob.VisitingTimeFrom = (object)reader["VisitingTimeFrom"];
                    }
                    if (reader["VisitingTimeTo"] != null)
                    {
                        oCSDJob.VisitingTimeTo = (object)reader["VisitingTimeTo"];
                    }
                    
                    oCSDJob.RemoteServiceProvidedAmount = Convert.ToDouble(reader["RemoteServiceProvidedAmount"].ToString());

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

        public void Refresh(bool isDateRangeChecked, DateTime dtCreateFromDate, DateTime dtCreateToDate, bool isLFDateRangeChecked, DateTime dtLFFromDate, DateTime dtLFToDate, string sJobNo, string sInvoiceNo, string sCustomerName, string sContactNo, int nJobType, int nServiceType, int nStatus, int nSubStatus, string sProductSerail, int nProductID, int nTechType, int nOwnTechID, int nThirdPartyID, string sBrandID)//
        {
            dtCreateToDate = dtCreateToDate.Date.AddDays(1);
            dtLFToDate = dtLFToDate.Date.AddDays(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "SELECT ProductTypeName,ISNULL(ProductModel,'') AS ProductModel,BrandID,BrandDesc,StatusName,FaultDescription,JobID,IsNull(ProductSerialNo,'') as ProductSerialNo,IsNull(OriginalProductSerialNo,'') as OriginalProductSerialNo, IsNull(InvoiceNo,'')InvoiceNo,InvoiceDate,SalesChannelID,SalesPointID,JobNo,ServiceType,JobType,"
            //              + " WorkshopID,IsNull(ReferenceJobNo,'') as ReferenceJobNo,IsNull(GSPNJobNo,'') as GSPNJobNo, Priority,LastFeedBackDate,DeliveryDate,a.Remarks,a.ProductID,FullOrAccessories,"
            //              + " IsNull(AccessoryID,0)AccessoryID,PrimaryFaultID,OwnOrCustomerSet,RefChannelID,IsNull(RefSalesPointID,0)RefSalesPointID,CustomerName,TelePhone,"
            //              + " a.MobileNo,CustomerAddress,a.Email,NationalID,Status,ISNULL(SubStatus,0)SubStatus,ISNULL(JSB.Name,'') SubStatusName,StatusReason,a.CreateUserID,a.CreateDate,IsNull(AssignTo,0)AssignTo,"
            //              + " IsNull(OwnOrOtherTechnician,0)OwnOrOtherTechnician,ReceivingTransportationMode,IsNull(ReceivingCourierID,0)ReceivingCourierID,ISNULL(ReceivingInstrumentNo,'') ReceivingInstrumentNo,ReceivingCost,"
            //              + " IsNull(DeliveryTransportationMode,0)DeliveryTransportationMode,IsNull(DeliveryCourierID,0)DeliveryCourierID,ISNULL(DeliveryInstrumentNo,'')DeliveryInstrumentNo,DeliveryCost,ProductLocation,SparePartsUsed,"
            //              + " IsNull(ActualFaultID,0)ActualFaultID,IsNull(InterSerJobType,0)InterSerJobType,IsDelivered,IsReplacement,ProductCode, ProductName,HaveBackupSet, IsNull(a.ThanaID,0) as ThanaID,"
            //              + " VisitingDate,VisitingTimeFrom,VisitingTimeTo,ProductPhysicalLocation,h.UserName,ISNULL(t.Name,'')TechnicianName,ISNULL(t.Type,0)TechnicianType,ISNULL(tp.Name,'') ThirdPartyName,ISNULL(tp.Code,'') ThirdPartyCode from t_CSDJob a"
            //              + " LEFT JOIN t_CSDTechnician t ON t.TechnicianID = a.AssignTo"
            //              + " LEFT JOIN t_CSDInterService tp ON tp.InterServiceID = t.ThirdPartyID"
            //              + " LEFT JOIN dbo.t_CSDJobStatus_Sub JSB ON JSB.SubStatusID = a.SubStatus, (Select ProductID, ProductCode, ProductName,BrandID,BrandDesc,ProductModel from v_ProductDetails)b, "
            //              + " (SELECT FaultID,FaultDescription FROM t_CSDProductFault) c, (SELECT StatusID,StatusName FROM t_CSDJobStatus) d, "
            //              + "(SELECT * from t_CSDServiceChargeProduct) e , (SELECT ServiceChargeID,ProductTypeID from t_CSDServiceCharge) f, (SELECT ProductTypeID,ProductTypeName FROM t_CSDProductType) g, "
            //              + "(SELECT * FROM t_User) h "
            //              + " Where f.ProductTypeID=g.ProductTypeID AND e.ServiceChargeID = f.ServiceChargeID AND a.ProductID = e.ProductID AND a.ProductID=b.ProductID AND a.PrimaryFaultID = c.FaultID AND a.Status = d.StatusID AND h.UserID =a.CreateUserID ";

            string sSql = @"SELECT ProductTypeName,ISNULL(ProductModel,'') AS ProductModel,BrandID,BrandDesc,StatusName,FaultDescription,Actualfault,JobID,IsNull(ProductSerialNo,'') as ProductSerialNo,IsNull(OriginalProductSerialNo,'') as OriginalProductSerialNo, IsNull(InvoiceNo,'')InvoiceNo,InvoiceDate,SalesChannelID,SalesPointID,JobNo,ServiceType,JobType,
                            WorkshopID,IsNull(ReferenceJobNo,'') as ReferenceJobNo,IsNull(GSPNJobNo,'') as GSPNJobNo, Priority,LastFeedBackDate,DeliveryDate,a.Remarks,a.ProductID,FullOrAccessories,
                            IsNull(AccessoryID,0)AccessoryID,PrimaryFaultID,OwnOrCustomerSet,RefChannelID,IsNull(RefSalesPointID,0)RefSalesPointID,CustomerName,TelePhone,
                            a.MobileNo,CustomerAddress,a.Email,NationalID,Status,ISNULL(SubStatus,0)SubStatus,ISNULL(JSB.Name,'') SubStatusName,StatusReason,a.CreateUserID,a.CreateDate,IsNull(AssignTo,0)AssignTo,
                            IsNull(OwnOrOtherTechnician,0)OwnOrOtherTechnician,ReceivingTransportationMode,IsNull(ReceivingCourierID,0)ReceivingCourierID,ISNULL(ReceivingInstrumentNo,'') ReceivingInstrumentNo,ReceivingCost,
                            IsNull(DeliveryTransportationMode,0)DeliveryTransportationMode,IsNull(DeliveryCourierID,0)DeliveryCourierID,ISNULL(DeliveryInstrumentNo,'')DeliveryInstrumentNo,DeliveryCost,ProductLocation,SparePartsUsed,
                            IsNull(ActualFaultID,0)ActualFaultID,IsNull(InterSerJobType,0)InterSerJobType,IsDelivered,IsReplacement,ProductCode, ProductName,HaveBackupSet, IsNull(a.ThanaID,0) as ThanaID,
                            VisitingDate,VisitingTimeFrom,VisitingTimeTo,ProductPhysicalLocation,h.UserName,ISNULL(t.Name,'')TechnicianName,ISNULL(t.Type,0)TechnicianType,ISNULL(tp.Name,'') ThirdPartyName,ISNULL(tp.Code,'') ThirdPartyCode,isnull(JL.Description,'') DeliveryAddress, JobCreateLocation from t_CSDJob a
                            Left Outer Join t_JobLocation JL on JL.JobLocationID=a.DeliveryLocation
                            LEFT JOIN t_CSDTechnician t ON t.TechnicianID = a.AssignTo
                            LEFT JOIN t_CSDInterService tp ON tp.InterServiceID = t.ThirdPartyID
                            LEFT JOIN dbo.t_CSDJobStatus_Sub JSB ON JSB.SubStatusID = a.SubStatus, (Select ProductID, ProductCode, ProductName,BrandID,BrandDesc,ProductModel from v_ProductDetails)b, 
                            (SELECT a.FaultID,a.FaultDescription,b.FaultDescription Actualfault FROM t_CSDProductFault a,t_CSDProductFault b
                            where a.ParentID=b.FaultID) c, (SELECT StatusID,StatusName FROM t_CSDJobStatus) d, 
                            (SELECT * from t_CSDServiceChargeProduct) e , (SELECT ServiceChargeID,ProductTypeID from t_CSDServiceCharge) f, (SELECT ProductTypeID,ProductTypeName FROM t_CSDProductType) g, 
                            (SELECT * FROM t_User) h 
                            Where f.ProductTypeID=g.ProductTypeID AND e.ServiceChargeID = f.ServiceChargeID AND a.ProductID = e.ProductID AND a.ProductID=b.ProductID AND a.PrimaryFaultID = c.FaultID AND a.Status = d.StatusID AND h.UserID =a.CreateUserID ";

            if (nJobType != -1)
            {
                sSql += "AND JobType = " + nJobType + " ";
            }
            if (nServiceType != -1)
            {
                sSql += "AND ServiceType = " + nServiceType + " ";
            }
            if (nStatus != -1)
            {
                sSql += "AND Status = " + nStatus + " ";
            }
            if (nSubStatus != -1)
            {
                sSql += "AND SubStatus = " + nSubStatus + " ";
            }
            if (!isDateRangeChecked)
            {
                sSql += " AND a.CreateDate BETWEEN'" + dtCreateFromDate + "'AND '" + dtCreateToDate + "' AND a.CreateDate < '" + dtCreateToDate + "'";
            }
            if (!isLFDateRangeChecked)
            {
                sSql += " AND LastFeedbackDate BETWEEN'" + dtLFFromDate + "'AND '" + dtLFToDate + "' AND LastFeedbackDate < '" + dtLFToDate + "'";
            }
            if (sJobNo != string.Empty)
            {
                sSql += " AND JobNo LIKE '%" + sJobNo + "%' ";
            }
            if (sInvoiceNo != string.Empty)
            {
                sSql += " AND InvoiceNo LIKE '%" + sInvoiceNo + "%' ";
            }
            if (sCustomerName != string.Empty)
            {
                sSql += " AND CustomerName LIKE '%" + sCustomerName + "%' ";
            }
            if (sContactNo != string.Empty)
            {
                sSql += " AND a.MobileNo LIKE '%" + sContactNo + "%' ";
            }
            if (sProductSerail != string.Empty)
            {
                sSql += " AND a.ProductSerialNo LIKE '%" + sProductSerail + "%' ";
            }
            if (nProductID != 0)
            {
                sSql += " AND a.ProductID = " + nProductID + " ";
            }
            if (nTechType != 0)
            {
                sSql += " AND t.Type = " + nTechType + " ";
            }
            if (nOwnTechID != 0)
            {
                sSql += " AND t.TechnicianID = " + nOwnTechID + " ";
            }
            if (nThirdPartyID != 0)
            {
                sSql += " AND t.ThirdPartyID = " + nThirdPartyID + " ";
            }
            if (sBrandID != "")
            {
                sSql = sSql + " AND BrandID IN (" + sBrandID + ") ";
            }
            sSql = sSql + " ORDER BY JobID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJob oCSDJob = new CSDJob();
                    oCSDJob.DeliveryAddress = (string)reader["DeliveryAddress"];
                    oCSDJob.JobID = (int)reader["JobID"];
                    oCSDJob.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oCSDJob.OriginalProductSerialNo = (string)reader["OriginalProductSerialNo"];
                    oCSDJob.InvoiceNo = (string)reader["InvoiceNo"];
                    if (reader["InvoiceDate"] != DBNull.Value)
                    oCSDJob.InvoiceDate = (object)reader["InvoiceDate"];
                    oCSDJob.SalesChannelID = (int)reader["SalesChannelID"];
                    oCSDJob.SalesPointID = (int)reader["SalesPointID"];
                    oCSDJob.JobNo = (string)reader["JobNo"];
                    oCSDJob.ServiceType = (int)reader["ServiceType"];
                    oCSDJob.JobType = (int)reader["JobType"];
                    oCSDJob.WorkshopID = (int)reader["WorkshopID"];
                    oCSDJob.ReferenceJobNo = (string)reader["ReferenceJobNo"];
                    oCSDJob.Priority = (int)reader["Priority"];
                    oCSDJob.LastFeedBackDate = Convert.ToDateTime(reader["LastFeedBackDate"].ToString());
                    oCSDJob.DeliveryDate = (object)reader["DeliveryDate"];
                    oCSDJob.Remarks = (string)reader["Remarks"];
                    oCSDJob.ProductID = (int)reader["ProductID"];
                    oCSDJob.FullOrAccessories = (int)reader["FullOrAccessories"];
                    oCSDJob.AccessoryID = (int)reader["AccessoryID"];
                    oCSDJob.PrimaryFaultID = (int)reader["PrimaryFaultID"];
                    oCSDJob.FaultDescription = (string)reader["FaultDescription"];
                    oCSDJob.OwnOrCustomerSet = (int)reader["OwnOrCustomerSet"];
                    oCSDJob.RefChannelID = (int)reader["RefChannelID"];
                    oCSDJob.RefSalesPointID = (int)reader["RefSalesPointID"];
                    oCSDJob.CustomerName = (string)reader["CustomerName"];
                    oCSDJob.TelePhone = (string)reader["TelePhone"];
                    oCSDJob.MobileNo = (string)reader["MobileNo"];
                    oCSDJob.CustomerAddress = (string)reader["CustomerAddress"];
                    oCSDJob.Email = (string)reader["Email"];
                    oCSDJob.NationalID = (string)reader["NationalID"];
                    oCSDJob.Status = (int)reader["Status"];
                    oCSDJob.SubStatus = (int)reader["SubStatus"];
                    oCSDJob.SubStatusName = (string)reader["SubStatusName"];
                    oCSDJob.StatusName = (string)reader["StatusName"];
                    oCSDJob.StatusReason = (string)reader["StatusReason"];
                    oCSDJob.CreateUserID = (int)reader["CreateUserID"];
                    oCSDJob.CreateUserName = (string)reader["UserName"];
                    oCSDJob.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDJob.AssignTo = (int)reader["AssignTo"];
                    oCSDJob.OwnOrOtherTechnician = (int)reader["OwnOrOtherTechnician"];
                    oCSDJob.ReceivingTransportationMode = (int)reader["ReceivingTransportationMode"];
                    oCSDJob.ReceivingCourierID = (int)reader["ReceivingCourierID"];
                    oCSDJob.ReceivingInstrumentNo = (string)reader["ReceivingInstrumentNo"];
                    oCSDJob.ReceivingCost = Convert.ToDouble(reader["ReceivingCost"].ToString());
                    oCSDJob.DeliveryTransportationMode = (int)reader["DeliveryTransportationMode"];
                    oCSDJob.DeliveryCourierID = (int)reader["DeliveryCourierID"];
                    oCSDJob.DeliveryInstrumentNo = (string)reader["DeliveryInstrumentNo"];
                    oCSDJob.DeliveryCost = Convert.ToDouble(reader["DeliveryCost"].ToString());
                    oCSDJob.ProductLocation = (int)reader["ProductLocation"];
                    oCSDJob.SparePartsUsed = (int)reader["SparePartsUsed"];
                    oCSDJob.ActualFaultID = (int)reader["ActualFaultID"];
                    oCSDJob.InterSerJobType = (int)reader["InterSerJobType"];
                    oCSDJob.IsDelivered = (int)reader["IsDelivered"];
                    oCSDJob.IsReplacement = (int)reader["IsReplacement"];
                    oCSDJob.ProductCode = (string)reader["ProductCode"];
                    oCSDJob.ProductName = (string)reader["ProductName"];
                    oCSDJob.BrandID = (int)reader["BrandID"];
                    oCSDJob.BrandName = (string)reader["BrandDesc"];
                    oCSDJob.ProductModel = (string)reader["ProductModel"];
                    oCSDJob.ProductTypeName = (string)reader["ProductTypeName"];
                    oCSDJob.HaveBackupset = (int)reader["HaveBackupSet"];
                    oCSDJob.ThanaID = (int)reader["ThanaID"];
                    oCSDJob.GSPNJobNo = (string)reader["GSPNJobNo"];
                    oCSDJob.ProductPhysicalLocation = (int)reader["ProductPhysicalLocation"];
                    if (reader["VisitingDate"] != null)
                    {
                        oCSDJob.VisitingDate = (object)reader["VisitingDate"];
                    }
                    if (reader["VisitingTimeFrom"] != null)
                    {
                        oCSDJob.VisitingTimeFrom = (object)reader["VisitingTimeFrom"];
                    }
                    if (reader["VisitingTimeTo"] != null)
                    {
                        oCSDJob.VisitingTimeTo = (object)reader["VisitingTimeTo"];
                    }
                    oCSDJob.oTechnician.Name = (string)reader["TechnicianName"];
                    oCSDJob.oTechnician.TechnicianTypeID = (int)reader["TechnicianType"];
                    oCSDJob.oThirdParty.Name = (string)reader["ThirdPartyName"];
                    oCSDJob.oThirdParty.Code = (string)reader["ThirdPartyCode"];
                    oCSDJob.ActualFault= (string)reader["Actualfault"];
                    if (reader["JobCreateLocation"] != DBNull.Value)
                        oCSDJob.JobCreateLocation = (int)reader["JobCreateLocation"];
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
        public bool GetJobs(String sProductSerial, String sMobileNo, String sCustomerName, String sInvoiceNo, String sTelephone, String sJobNo, String sAddress,String sGSPNJob)
        {
            int nCount = 0;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @"select JobID,Status,ProductSerialNo, InvoiceNo,InvoiceDate, SalesChannelID,SalesPointID,GSPNJobNo,JobNo,
                          JobType,ReferenceJobNo,a.ProductID, ProductCode,ProductName,CustomerName, TelePhone,MobileNo,
                          CustomerAddress,Email,NationalID,CreateDate from t_CSDJob a, t_Product b 
                          Where a.ProductID=b.ProductID ";

            if (sProductSerial != "")
            {
                sSql = sSql + " AND ProductSerialNo = '" + sProductSerial + "'";
            }
            if (sMobileNo != "")
            {
                sSql = sSql + " AND MobileNo Like '%" + sMobileNo + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND CustomerName Like '%" + sCustomerName + "%'";
            }
            if (sInvoiceNo != "")
            {
                sSql = sSql + " AND InvoiceNo = '" + sInvoiceNo + "'";
            }
            if (sTelephone != "")
            {
                sSql = sSql + " AND TelePhone Like '%" + sTelephone + "%'";
            }
            if (sJobNo != "")
            {
                sSql = sSql + " AND JobNo = '" + sJobNo + "'";
            }
            if (sAddress != "")
            {
                sSql = sSql + " AND CustomerAddress Like '%" + sAddress + "%'";
            }
            if (sGSPNJob != "")
            {
                sSql = sSql + " AND GSPNJobNo = '" + sGSPNJob + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CSDJob oCSDJob = new CSDJob();

                    oCSDJob.JobID = int.Parse(reader["JobID"].ToString());
                    oCSDJob.Status = int.Parse(reader["Status"].ToString());
                    oCSDJob.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oCSDJob.InvoiceNo = (string)reader["InvoiceNo"];
                    oCSDJob.InvoiceDate = (object)reader["InvoiceDate"];
                    oCSDJob.SalesChannelID = (int)reader["SalesChannelID"];
                    oCSDJob.SalesPointID = (int)reader["SalesPointID"];
                    if (reader["GSPNJobNo"] != DBNull.Value)
                    oCSDJob.GSPNJobNo = (string)reader["GSPNJobNo"];
                    oCSDJob.JobNo = (string)reader["JobNo"];
                    oCSDJob.JobType = (int)reader["JobType"];
                    oCSDJob.ReferenceJobNo = (string)reader["ReferenceJobNo"];
                    oCSDJob.ProductID = (int)reader["ProductID"];
                    oCSDJob.ProductCode = (string)reader["ProductCode"];
                    oCSDJob.ProductName = (string)reader["ProductName"];
                    oCSDJob.CustomerName = (string)reader["CustomerName"];
                    oCSDJob.TelePhone = (string)reader["TelePhone"];
                    oCSDJob.MobileNo = (string)reader["MobileNo"];
                    oCSDJob.CustomerAddress = (string)reader["CustomerAddress"];
                    oCSDJob.Email = (string)reader["Email"];
                    oCSDJob.NationalID = (string)reader["NationalID"];
                    oCSDJob.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oCSDJob);

                    nCount++;
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            if (nCount != 0)
                return true;
            else return false;

        }
        public void GetJobsInTechHand(int nTechnicianID, int nWorkshopID)
        {
            int nCount = 0;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDJob Job LEFT JOIN t_CSDJobStatus_Sub SS ON Job.SubStatus = SS.SubStatusID "
                         + "WHERE WorkshopID = " + nWorkshopID + " AND AssignTo = " + nTechnicianID + " AND Status >=4 AND Status <= 17 ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJob oCSDJob = new CSDJob();
                    oCSDJob.JobNo = (string)reader["JobNo"];
                    oCSDJob.CustomerName = (string)reader["CustomerName"];
                    oCSDJob.CustomerAddress = (string)reader["CustomerAddress"];
                    oCSDJob.StatusName = Enum.GetName(typeof(Dictionary.JobStatus), oCSDJob.Status);
                    oCSDJob.StatusReason = (string)reader["StatusReason"];
                    if (reader["Name"] != DBNull.Value)
                        oCSDJob.SubStatusName = (string)reader["Name"];
                    InnerList.Add(oCSDJob);

                    nCount++;
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshByTechnicianID(int nTechnicianID)
        {
            int nCount = 0;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "SELECT a.*,b.GeoLocationName AS ThanaName,c.GeoLocationName AS DistrictName FROM t_CSDJob a "
            //             +"INNER JOIN t_GeoLocation b ON a.ThanaID = b.GeoLocationID "
            //             +"INNER JOIN t_GeoLocation c ON c.GeoLocationID = b.ParentID "
            //             +"WHERE AssignTo = " + nTechnicianID + " AND Status NOT IN (" + (int)Dictionary.JobStatus.Cancel + ", "
            //             +" " + (int)Dictionary.JobStatus.ServiceProvided + "," + (int)Dictionary.JobStatus.Repaired + ","+(int)Dictionary.JobStatus.Delivered+") "
            //             + " AND a.SubStatus NOT in (1,2,3,4) "
            //             +"AND ServiceType in (" + (int)Dictionary.ServiceType.HomeCall + "," + (int)Dictionary.ServiceType.Installation + ") "
            //             +"ORDER BY VisitingDate ASC";

            string sSql = "SELECT * FROM( "
                        +"SELECT a.*,b.GeoLocationName AS ThanaName,c.GeoLocationName AS DistrictName  "
                        +"FROM t_CSDJob a INNER JOIN t_GeoLocation b ON a.ThanaID = b.GeoLocationID "
                        +"INNER JOIN t_GeoLocation c ON c.GeoLocationID = b.ParentID  "
                        + "WHERE AssignTo = '" + nTechnicianID + "' AND a.Status NOT IN (20,17,13,27,11)  "
                        +"AND ServiceType in (2,3) )a "
                        +"UNION ALL "
                        +"SELECT * FROM( "
                        +"SELECT a.*,b.GeoLocationName AS ThanaName,c.GeoLocationName AS DistrictName  "
                        +"FROM t_CSDJob a INNER JOIN t_GeoLocation b ON a.ThanaID = b.GeoLocationID "
                        +"INNER JOIN t_GeoLocation c ON c.GeoLocationID = b.ParentID  "
                        + "WHERE AssignTo = '" + nTechnicianID + "' AND a.Status  IN (11) and a.SubStatus in (5,6) "
                        + "AND ServiceType in (2,3))b ORDER BY VisitingDate DESC";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CSDJob oCSDJob = new CSDJob();

                    oCSDJob.VisitingDate = Convert.ToDateTime(reader["VisitingDate"].ToString());
                    if (reader["VisitingTimeFrom"] != DBNull.Value)
                    {
                        oCSDJob.VisitingTimeFrom = Convert.ToDateTime(reader["VisitingTimeFrom"].ToString());
                    }
                    if (reader["VisitingTimeTo"] != DBNull.Value)
                    {
                        oCSDJob.VisitingTimeTo = Convert.ToDateTime(reader["VisitingTimeTo"].ToString());
                    }
                    oCSDJob.JobNo = (string)reader["JobNo"];
                    oCSDJob.JobType = (int)reader["JobType"];
                    oCSDJob.ServiceType = (int)reader["ServiceType"];
                    oCSDJob.CustomerAddress = (string)reader["CustomerAddress"];
                    oCSDJob.ThanaName = (string)reader["ThanaName"];
                    oCSDJob.DistrictName = (string)reader["DistrictName"];
                    InnerList.Add(oCSDJob);

                    nCount++;
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetCassandraJobs(String sProductSerial, String sMobileNo, String sCustomerName, String sInvoiceNo, String sTelephone, String sJobNo, String sAddress)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select JobID,JobStatus, ProductSerialNo,InvoiceNo,InvoiceDate,SalesChannelID,SalesPointID,'' as GSPNJobNo,JobNo,JobType,ReferenceJobNo,ProductID, " +
                           " ProductCode,ProductName,CustomerName,TelePhone,MobileNo,CustomerAddress,Email, NationalID, JobCreationDate " +
                           " from( " +
                           " select JobID,a.JobStatus,SerialNo as ProductSerialNo, '' as InvoiceNo, '' as  InvoiceDate, 0 as SalesChannelID, 0 as SalesPointID, " +
                           " JobNo, JobType, RefferenceJobNo as ReferenceJobNo, 0 as ProductID, b.Code as ProductCode, b.Name as ProductName, CustomerName, TelePhone=CASE  " +
                           " When PhoneHome = '' then PhoneOffice else PhoneHome+', '+PhoneOffice end, Mobile as MobileNo, FirstAddress as CustomerAddress, " +
                           " Email, '' as NationalID,JobCreationDate " +
                           " from TELServiceDB.dbo.Job a, TELServiceDB.dbo.Product b Where a.ProductID=b.ProductID )a Where 1=1 ";

            if (sProductSerial != "")
            {
                sSql = sSql + " AND ProductSerialNo = '" + sProductSerial + "'";
            }
            if (sMobileNo != "")
            {
                sSql = sSql + " AND MobileNo Like '%" + sMobileNo + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND CustomerName Like '%" + sCustomerName + "%'";
            }
            if (sTelephone != "")
            {
                sSql = sSql + " AND TelePhone Like '%" + sTelephone + "%'";
            }
            if (sJobNo != "")
            {
                sSql = sSql + " AND JobNo = '" + sJobNo + "'";
            }
            if (sAddress != "")
            {
                sSql = sSql + " AND CustomerAddress Like '%" + sAddress + "%'";
            }
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CSDJob oCSDJob = new CSDJob();

                    oCSDJob.JobID = int.Parse(reader["JobID"].ToString());
                    oCSDJob.Status = int.Parse(reader["JobStatus"].ToString());
                    oCSDJob.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oCSDJob.InvoiceNo = (string)reader["InvoiceNo"];
                    oCSDJob.InvoiceDate = null;
                    oCSDJob.SalesChannelID = (int)reader["SalesChannelID"];
                    oCSDJob.SalesPointID = (int)reader["SalesPointID"];
                    oCSDJob.GSPNJobNo = (string)reader["GSPNJobNo"];
                    oCSDJob.JobNo = (string)reader["JobNo"];
                    oCSDJob.JobType = Convert.ToInt32(reader["JobType"].ToString());
                    oCSDJob.ReferenceJobNo = (string)reader["ReferenceJobNo"];
                    oCSDJob.ProductID = (int)reader["ProductID"];
                    oCSDJob.ProductCode = (string)reader["ProductCode"];
                    oCSDJob.ProductName = (string)reader["ProductName"];
                    oCSDJob.CustomerName = (string)reader["CustomerName"];
                    oCSDJob.TelePhone = (string)reader["TelePhone"];
                    oCSDJob.MobileNo = (string)reader["MobileNo"];
                    oCSDJob.CustomerAddress = (string)reader["CustomerAddress"];
                    oCSDJob.Email = (string)reader["Email"];
                    oCSDJob.NationalID = (string)reader["NationalID"];
                    oCSDJob.CreateDate = Convert.ToDateTime(reader["JobCreationDate"].ToString());

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
        public bool GetInvoice(String sInvoiceNo, String sProductSerial, String sMobileNo, String sTelephone, String sCustomerName)
        {
            int nCount = 0;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "Select ProductSerialNo,InvoiceNo,InvoiceDate,SalesPointID,ProductID, " +
            //            "ProductCode,ProductName,CustomerName,TelePhone,MobileNo,CustomerAddress,Email, NationalID " +
            //            "From " +
            //            "( " +
            //            "select IsNull(ProductSerialNo,'') as ProductSerialNo, InvoiceNo, InvoiceDate, a.CustomerID as SalesPointID, " +
            //            " b.ProductID, ProductCode, ProductName, IsNull(ConsumerName,'') as CustomerName,  " +
            //            "IsNull(PhoneNo,'') as TelePhone, IsNull(CellNo,'') as MobileNo, IsNull(Address,'') as CustomerAddress,  " +
            //            "IsNull(Email,'') as Email, IsNull(NationalID,'') as NationalID from (Select * from t_SalesInvoice Where SundryCustomerID Is Not Null ) a " +
            //            "INNER JOIN t_SalesInvoiceDetail b " +
            //            "ON a.InvoiceID=b.InvoiceID " +
            //            "INNER JOIN " +
            //            "t_Product prod " +
            //            "ON b.ProductID=prod.ProductID " +
            //            "Left Outer JOIN " +
            //            "dbo.t_RetailConsumer c ON a.SundryCustomerID=c.ConsumerID and a.WarehouseID=c.WarehouseID " +
            //            "Left Outer JOIN  " +
            //            "t_SalesInvoiceProductSerial d " +
            //            "ON b.ProductID=d.ProductID and b.InvoiceID=d.InvoiceID " +
            //            ") as a Where 1=1 ";

            string sSql = @"Select ProductSerialNo,InvoiceNo,InvoiceDate,SalesPointID,ProductID, 
                            ProductCode,ProductName,CustomerName,TelePhone,MobileNo,CustomerAddress,Email, NationalID 
                            From 
                            ( 
                            --TD----
                            select IsNull(ProductSerialNo,'') as ProductSerialNo, InvoiceNo, InvoiceDate, a.CustomerID as SalesPointID, 
                             b.ProductID, ProductCode, ProductName, IsNull(ConsumerName,'') as CustomerName,  
                            IsNull(PhoneNo,'') as TelePhone, IsNull(CellNo,'') as MobileNo, IsNull(Address,'') as CustomerAddress,  
                            IsNull(c.Email,'') as Email, IsNull(NationalID,'') as NationalID from (Select * 
                            from t_SalesInvoice Where SundryCustomerID Is Not Null ) a 
                            INNER JOIN t_SalesInvoiceDetail b 
                            ON a.InvoiceID=b.InvoiceID 
                            INNER JOIN 
                            t_Product prod 
                            ON b.ProductID=prod.ProductID 
                            INNER JOIN t_Showroom s ON a.WarehouseID = s.WarehouseID 
                            Left Outer JOIN 
                            dbo.t_RetailConsumer c ON a.SundryCustomerID=c.ConsumerID and  a.WarehouseID = c.WarehouseID 
                            Left Outer JOIN  
                            t_SalesInvoiceProductSerial d 
                            ON b.ProductID=d.ProductID and b.InvoiceID=d.InvoiceID 
                            UNION ALL

                            -- EPS----
                            Select IsNull(ProductSerialNo,'') as ProductSerialNo, InvoiceNo, InvoiceDate, b.CustomerID as SalesPointID, 
                            d.ProductID, ProductCode, ProductName, IsNull(EmployeeName,'') as CustomerName,  
                            '' as TelePhone, IsNull(PhoneNo,'') as MobileNo, IsNull(EmployeeAddress,'') as CustomerAddress,  
                            IsNull(c.Email,'') as Email, '' as NationalID 
                            from t_EPSSales a 
                            INNER JOIN t_SalesInvoice b
                            ON a.OrderID = b.OrderID
                            INNER JOIN
                            t_EPSCustomer c
                            ON a.EPSCustomerID = c.EPSCustomerID
                            INNER JOIN
                            t_SalesInvoiceDetail d
                            ON b.InvoiceID = d.InvoiceID
                            INNER JOIN
                            t_Product e 
                            ON d.ProductID = e.ProductID
                            Left Outer JOIN
                            t_SalesInvoiceProductSerial f 
                            ON d.ProductID = f.ProductID and d.InvoiceID = f.InvoiceID

                            UNION ALL

                            --Others----
                            select IsNull(ProductSerialNo,'') as ProductSerialNo, InvoiceNo, InvoiceDate, a.CustomerID as SalesPointID, 
                             prod.ProductID, ProductCode, ProductName, IsNull(CustomerName,'') as CustomerName,  
                            IsNull(CustomerTelephone,'') as TelePhone, IsNull(CellPhoneNumber,'') as MobileNo, IsNull(CustomerAddress,'') as CustomerAddress,  
                            '' as Email, '' as NationalID from (Select * 
                            from t_SalesInvoice Where WarehouseID <> 71 and WarehouseID NOT IN (Select WarehouseID from t_Showroom)) a 
                            INNER JOIN t_SalesInvoiceDetail b 
                            ON a.InvoiceID=b.InvoiceID 
                            INNER JOIN 
                            t_Product prod 
                            ON b.ProductID = prod.ProductID 
                            INNER JOIN
                            t_Customer cust ON Cust.CustomerID = a.CustomerID
                            Left Outer JOIN  
                            t_SalesInvoiceProductSerial d 
                            ON b.ProductID = d.ProductID and b.InvoiceID = d.InvoiceID

                            ) as a Where 1=1 ";

            if (sInvoiceNo != "")
            {
                sSql = sSql + " AND InvoiceNo = '" + sInvoiceNo + "'";
            }
            if (sProductSerial != "")
            {
                sSql = sSql + " AND ProductSerialNo Like '%" + sProductSerial + "%'";
            }
            if (sMobileNo != "")
            {
                sSql = sSql + " AND MobileNo Like '%" + sMobileNo + "%'";
            }
            if (sTelephone != "")
            {
                sSql = sSql + " AND TelePhone Like '%" + sTelephone + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND CustomerName Like '%" + sCustomerName + "%'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CSDJob oCSDJob = new CSDJob();

                    oCSDJob.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oCSDJob.InvoiceNo = (string)reader["InvoiceNo"];
                    oCSDJob.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oCSDJob.SalesPointID = (int)reader["SalesPointID"];
                    oCSDJob.ProductID = (int)reader["ProductID"];
                    oCSDJob.ProductCode = (string)reader["ProductCode"];
                    oCSDJob.ProductName = (string)reader["ProductName"];
                    oCSDJob.CustomerName = (string)reader["CustomerName"];
                    oCSDJob.TelePhone = (string)reader["TelePhone"];
                    oCSDJob.MobileNo = (string)reader["MobileNo"];
                    oCSDJob.CustomerAddress = (string)reader["CustomerAddress"];
                    oCSDJob.Email = (string)reader["Email"];
                    oCSDJob.NationalID = (string)reader["NationalID"];

                    InnerList.Add(oCSDJob);
                    nCount++;
                }
                reader.Close();
                InnerList.TrimToSize();
                if (nCount != 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetCassiopeiaInvoice(String sInvoiceNo, String sProductSerial, String sMobileNo, String sTelephone, String sCustomerName)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ProductSerialNo,InvoiceNo,InvoiceDate,SalesPointCode, " +
                        "ProductCode,ProductName,CustomerName,TelePhone,MobileNo,CustomerAddress,Email, NationalID " +
                        "from  " +
                        "(Select InvoiceID, ShowroomID, TranDate as InvoiceDate, TranNo as InvoiceNo, CustomerID from Cassiopeia_HO.dbo.Invoice) as a " +
                        "INNER JOIN " +
                        "(Select InvoiceID,ShowroomID,ProductID, IsNull(BarCodeOrMSlNo,'') as ProductSerialNo from Cassiopeia_HO.dbo.InvoiceItem ) as b " +
                        "ON a.InvoiceID=b.InvoiceID and a.ShowroomID=b.ShowroomID  " +
                        "INNER JOIN  " +
                        "(Select ProductID, Code as ProductCode, Name as ProductName from Cassiopeia_HO.dbo.Product) as c " +
                        "ON b.ProductID=c.ProductID  " +
                        "INNER JOIN  " +
                        "(Select CustomerID,ShowroomID,IsNull(Name,'') as CustomerName, IsNull(Address,'') as CustomerAddress,  " +
                        "IsNull(MobileNo,'')as MobileNo,IsNull(TelNo,'') as TelePhone,IsNull(Email,'') as Email,IsNull(NationalID,'') as NationalID from Cassiopeia_HO.dbo.Customer) as d " +
                        "ON a.ShowroomID=d.ShowroomID and a.CustomerID=d.CustomerID " +
                        "INNER JOIN (Select ShowroomID,CustomerID as SalesPointCode from Cassiopeia_HO.dbo.Showroom) as e " +
                        "ON a.ShowroomID=e.ShowroomID Where 1=1 ";

            if (sInvoiceNo != "")
            {
                sSql = sSql + " AND InvoiceNo = '" + sInvoiceNo + "'";
            }
            if (sProductSerial != "")
            {
                sSql = sSql + " AND ProductSerialNo Like '%" + sProductSerial + "%'";
            }
            if (sMobileNo != "")
            {
                sSql = sSql + " AND MobileNo Like '%" + sMobileNo + "%'";
            }
            if (sTelephone != "")
            {
                sSql = sSql + " AND TelePhone Like '%" + sTelephone + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND CustomerName Like '%" + sCustomerName + "%'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CSDJob oCSDJob = new CSDJob();

                    oCSDJob.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oCSDJob.InvoiceNo = (string)reader["InvoiceNo"];
                    oCSDJob.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oCSDJob.CustomerCode = Convert.ToString(reader["SalesPointCode"]);
                    oCSDJob.ProductCode = (string)reader["ProductCode"];
                    oCSDJob.ProductName = (string)reader["ProductName"];
                    oCSDJob.CustomerName = (string)reader["CustomerName"];
                    oCSDJob.TelePhone = (string)reader["TelePhone"];
                    oCSDJob.MobileNo = (string)reader["MobileNo"];
                    oCSDJob.CustomerAddress = (string)reader["CustomerAddress"];
                    oCSDJob.Email = (string)reader["Email"];
                    oCSDJob.NationalID = (string)reader["NationalID"];

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
        public void GetUnSendJob(DateTime dtFromDate, DateTime dtToDate, bool IsCheck, string sJobNo, int nASGID, int nChallanFrom)//
        {
            dtToDate = dtToDate.Date.AddDays(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select JobID, JobNo, ProductName,ProductLocation,ProductMovementStatus,ProductPhysicalLocation, ASGName from  " +
                        "(Select JobID,ProductLocation,ProductMovementStatus,ProductPhysicalLocation,JobNo, ProductID, CreateDate from t_CSDJob Where ServiceType= " + (int)Dictionary.ServiceType.Walkin + " AND ProductPhysicalLocation = " + (int)Dictionary.ProductPhysicalLocation.CentralService + " ";
            if (nChallanFrom == (int)Dictionary.ChallanCreateFrom.FrontDesk)
            {
                sSql = sSql + " AND ProductMovementStatus = " + (int)Dictionary.ProductMovementStatus.None + " AND ProductLocation = " + (int)Dictionary.ProductLocation.At_FrontDesk + "  ";
            }
            else
            {
                sSql = sSql + " AND ProductMovementStatus = " + (int)Dictionary.ProductMovementStatus.Receive_at_Workshop + " " +
                                " AND ProductLocation = "+(int)Dictionary.ProductLocation.At_Workshop+" "+
                                " AND Status IN (" + (int)Dictionary.JobStatus.Return + "," + (int)Dictionary.JobStatus.ReadyForDelivery + ") ";
            }
            sSql = sSql + " ) a,  " +
                        "(Select ProductID, ProductName, ASGName, ASGID from v_ProductDetails) b  " +
                        "Where a.ProductID=b.ProductID  ";

            if (IsCheck == false)
            {
                sSql = sSql + " and CreateDate BETWEEN'" + dtFromDate + "'AND '" + dtToDate + "' AND CreateDate < '" + dtToDate + "'";
            }
            if (sJobNo != "")
            {
                sSql = sSql + " and JobNo like '%" + sJobNo + "%' ";
            }
            if (nASGID > 0)
            {
                sSql = sSql + " and ASGID = " + nASGID + " ";
            }

            sSql = sSql + " order by JobID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CSDJob oCSDJob = new CSDJob();

                    oCSDJob.JobID = (int)reader["JobID"];
                    oCSDJob.JobNo = (string)reader["JobNo"];
                    oCSDJob.ProductName = (string)reader["ProductName"];
                    oCSDJob.ASGName = (string)reader["ASGName"];
                    oCSDJob.ProductLocation = (int)reader["ProductLocation"];
                    oCSDJob.ProductMovementStatus = (int)reader["ProductMovementStatus"];
                    oCSDJob.ProductPhysicalLocation = (int)reader["ProductPhysicalLocation"];
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
        public void  GetJobsForDelivery(DateTime dtFromDate, DateTime dtToDate, String sMobileNo, String sJobNo, int nASGID, int nWorkshop, String sCustomerName, String sProduct, int nServiceType, int nJobType, bool IsCheck, bool isLFDateChecked, DateTime dtLFDateFrom, DateTime dtLFDateTo, int nThirdPartyID, int nTechnicianID, int nWorkshopTypeID)//
        {
            dtToDate = dtToDate.Date.AddDays(1);
            dtLFDateTo = dtLFDateTo.Date.AddDays(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            //sSql = "  SELECT JobID,IsNull(ProductSerialNo,'') as ProductSerialNo,IsNull(InvoiceNo,'')InvoiceNo,InvoiceDate, " +
            //       "  SalesChannelID,SalesPointID,JobNo,ServiceType, ServiceTypeDes=CASE When ServiceType = 1 then 'Walkin' When ServiceType = 2 then 'Home Call' " +
            //       "  When ServiceType = 3 then 'Inter Service' When ServiceType = 4 then 'Installation' else 'Others' end, " +
            //       "  JobType, JobTypeDes=CASE When JobType = 1 then 'Full Warranty' " +
            //       "  When JobType = 2 then 'Paid' When JobType = 3 then 'Service Warranty' " +
            //       "  When JobType = 4 then 'Component Warranty' else 'Others' end, " +
            //       "  WorkshopID,Priority,a.Remarks,a.ProductID,PrimaryFaultID,RefChannelID, " +
            //       "  CustomerName,TelePhone, a.MobileNo,CustomerAddress,a.Email,NationalID,Status,StatusName,StatusReason, " +
            //       "  a.CreateUserID,a.CreateDate,IsNull(AssignTo,0)AssignTo, " +
            //       "  ProductCode, ProductName,ASGID, ASGName,a.LastFeedBackDate from t_CSDJob a " +
            //       "  LEFT JOIN t_CSDTechnician t ON t.TechnicianID = a.AssignTo" + 
            //       "  LEFT JOIN t_CSDInterService TP ON TP.InterServiceID = t.ThirdPartyID, " +
            //       " (Select ProductID, ProductCode, ProductName,ASGID, ASGName from v_ProductDetails)b, t_CSDJobStatus c  " +
            //       "  Where a.ProductID=b.ProductID and a.Status=c.StatusID and Status IN (17,26) and IsDelivered = 0";
            //            string subquery = string.Empty;
            //            if (nWorkshopTypeID != -1)
            //            {
            //            subquery = @" INNER JOIN t_CSDServiceChargeProduct M ON a.ProductID = M.ProductID
            //                                        INNER JOIN t_CSDServiceCharge N ON M.ServiceChargeID = N.ServiceChargeID 
            //                                        INNER JOIN t_CSDProductType O ON N.ProductTypeID = O.ProductTypeID 
            //                                        INNER JOIN t_CSDWorkshopType P ON  O.WorkShopTypeID =P.WorkShopTypeID ";
            //                sSql += " AND P.WorkShopTypeID = " + nWorkshopTypeID + " ";
            //            }
            sSql = @"SELECT * FROM (SELECT JobID,IsNull(ProductSerialNo,'') as ProductSerialNo,IsNull(InvoiceNo,'')InvoiceNo,InvoiceDate, 
                    SalesChannelID,SalesPointID,JobNo,ServiceType, ServiceTypeDes=CASE When ServiceType = 1 then 'Walkin' When ServiceType = 2 then 'Home Call' 
                    When ServiceType = 3 then 'Inter Service' When ServiceType = 4 then 'Installation' else 'Others' end, 
                    JobType, JobTypeDes=CASE When JobType = 1 then 'Full Warranty' 
                    When JobType = 2 then 'Paid' When JobType = 3 then 'Service Warranty' 
                    When JobType = 4 then 'Component Warranty' else 'Others' end, 
                    WorkshopID,O.WorkShopTypeID,Priority,a.Remarks,a.ProductID,PrimaryFaultID,RefChannelID, 
                    CustomerName,TelePhone, a.MobileNo,CustomerAddress,a.Email,NationalID,Status,StatusName,StatusReason, 
                    a.CreateUserID,a.CreateDate,IsNull(AssignTo,0)AssignTo, P.Name WorkshopName,
                    ProductCode, ProductName,ASGID, ASGName,a.LastFeedBackDate,TP.InterServiceID,
                    ISNULL(OwnOrOtherTechnician,-1) OwnOrOtherTechnician from t_CSDJob a 
                    INNER JOIN t_CSDServiceChargeProduct M ON a.ProductID = M.ProductID
                    INNER JOIN t_CSDServiceCharge N ON M.ServiceChargeID = N.ServiceChargeID 
                    INNER JOIN t_CSDProductType O ON N.ProductTypeID = O.ProductTypeID 
                    INNER JOIN t_CSDWorkshopType P ON  O.WorkShopTypeID =P.WorkShopTypeID
                    LEFT JOIN t_CSDTechnician t ON t.TechnicianID = a.AssignTo
                    LEFT JOIN t_CSDInterService TP ON TP.InterServiceID = t.ThirdPartyID, 
                    (Select ProductID, ProductCode, ProductName,ASGID, ASGName from v_ProductDetails)b, t_CSDJobStatus c  
                    Where a.ProductID=b.ProductID and a.Status=c.StatusID and Status IN (14,17,26) and ProductPhysicalLocation=1 and
                    ProductLocation=1 and ProductMovementStatus=4 and IsDelivered = 0 
                    UNION ALL
                    SELECT JobID,IsNull(ProductSerialNo,'') as ProductSerialNo,IsNull(InvoiceNo,'')InvoiceNo,InvoiceDate, 
                    SalesChannelID,SalesPointID,JobNo,ServiceType, ServiceTypeDes=CASE When ServiceType = 1 then 'Walkin' When ServiceType = 2 then 'Home Call' 
                    When ServiceType = 3 then 'Inter Service' When ServiceType = 4 then 'Installation' else 'Others' end, 
                    JobType, JobTypeDes=CASE When JobType = 1 then 'Full Warranty' 
                    When JobType = 2 then 'Paid' When JobType = 3 then 'Service Warranty' 
                    When JobType = 4 then 'Component Warranty' else 'Others' end, 
                    WorkshopID,O.WorkShopTypeID,Priority,a.Remarks,a.ProductID,PrimaryFaultID,RefChannelID, 
                    CustomerName,TelePhone, a.MobileNo,CustomerAddress,a.Email,NationalID,Status,StatusName,StatusReason, 
                    a.CreateUserID,a.CreateDate,IsNull(AssignTo,0)AssignTo, P.Name WorkshopName,
                    ProductCode, ProductName,ASGID, ASGName,a.LastFeedBackDate,TP.InterServiceID,
                    ISNULL(OwnOrOtherTechnician,-1) OwnOrOtherTechnician from t_CSDJob a 
                    INNER JOIN t_CSDServiceChargeProduct M ON a.ProductID = M.ProductID
                    INNER JOIN t_CSDServiceCharge N ON M.ServiceChargeID = N.ServiceChargeID 
                    INNER JOIN t_CSDProductType O ON N.ProductTypeID = O.ProductTypeID 
                    INNER JOIN t_CSDWorkshopType P ON  O.WorkShopTypeID =P.WorkShopTypeID
                    LEFT JOIN t_CSDTechnician t ON t.TechnicianID = a.AssignTo
                    LEFT JOIN t_CSDInterService TP ON TP.InterServiceID = t.ThirdPartyID, 
                    (Select ProductID, ProductCode, ProductName,ASGID, ASGName from v_ProductDetails)b, t_CSDJobStatus c  
                    Where a.ProductID=b.ProductID and a.Status=c.StatusID and Status IN (14,17,26) and ProductPhysicalLocation = 2 
                    and IsDelivered = 0) Main Where 1=1 ";


            if (nServiceType > 0)
            {
                sSql = sSql + "  and ServiceType =" + nServiceType + " ";
            }

            if (nJobType > 0)
            {
                sSql = sSql + "  and JobType =" + nJobType + " ";
            }
            if (IsCheck == false)
            {
                sSql = sSql + " and CreateDate BETWEEN '" + dtFromDate + "'AND '" + dtToDate + "' AND CreateDate < '" + dtToDate + "' ";
            }
            if (!isLFDateChecked)
            {
                sSql += " AND LastFeedBackDate BETWEEN '" + dtLFDateFrom + "'AND '" + dtLFDateTo + "' AND LastFeedBackDate < '" + dtLFDateTo + "' ";
            }
            if (sJobNo != "")
            {
                sSql = sSql + "  and JobNo = '" + sJobNo + "' ";
            }
            if (sProduct != "")
            {
                sSql = sSql + "  and ProductName like '%" + sProduct + "%' ";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + "  and CustomerName like '%" + sCustomerName + "%' ";
            }
            if (sMobileNo != "")
            {
                sSql = sSql + "  and MobileNo like '%" + sMobileNo + "%' ";
            }
            if (nASGID > 0)
            {
                sSql = sSql + "  and ASGID =" + nASGID + " ";
            }
            if (nThirdPartyID != -1)
            {
                sSql += " AND InterServiceID = " + nThirdPartyID + " ";
            }
            if (nTechnicianID != 0)
            {
                sSql += " AND AssignTo = " + nTechnicianID + " ";
            }
            if (nWorkshopTypeID != -1)
            {
                sSql += " AND WorkShopTypeID = " + nWorkshopTypeID + " ";
            }
            sSql = sSql + " order by JobID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJob oCSDJob = new CSDJob();
                    oCSDJob.JobID = (int)reader["JobID"];
                    oCSDJob.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oCSDJob.InvoiceNo = (string)reader["InvoiceNo"];
                    oCSDJob.InvoiceDate = (object)reader["InvoiceDate"];
                    oCSDJob.SalesChannelID = (int)reader["SalesChannelID"];
                    oCSDJob.SalesPointID = (int)reader["SalesPointID"];
                    oCSDJob.JobNo = (string)reader["JobNo"];
                    oCSDJob.ServiceType = (int)reader["ServiceType"];
                    oCSDJob.JobType = (int)reader["JobType"];
                    oCSDJob.JobTypeDes = (string)reader["JobTypeDes"];
                    oCSDJob.WorkshopID = (int)reader["WorkshopID"];
                    oCSDJob.WorkshopName = (string)reader["WorkshopName"];
                    //oCSDJob.ReferenceJobNo = (string)reader["ReferenceJobNo"];
                    oCSDJob.Priority = (int)reader["Priority"];
                    oCSDJob.LastFeedBackDate = Convert.ToDateTime(reader["LastFeedBackDate"].ToString());
                    //oCSDJob.DeliveryDate = (object)reader["DeliveryDate"];
                    oCSDJob.Remarks = (string)reader["Remarks"];
                    oCSDJob.ProductID = (int)reader["ProductID"];
                    //oCSDJob.FullOrAccessories = (int)reader["FullOrAccessories"];
                    //oCSDJob.AccessoryID = (int)reader["AccessoryID"];
                    oCSDJob.PrimaryFaultID = (int)reader["PrimaryFaultID"];
                    //oCSDJob.OwnOrCustomerSet = (int)reader["OwnOrCustomerSet"];
                    //oCSDJob.RefChannelID = (int)reader["RefChannelID"];
                    //oCSDJob.RefSalesPointID = (int)reader["RefSalesPointID"];
                    oCSDJob.CustomerName = (string)reader["CustomerName"];
                    oCSDJob.TelePhone = (string)reader["TelePhone"];
                    oCSDJob.MobileNo = (string)reader["MobileNo"];
                    oCSDJob.CustomerAddress = (string)reader["CustomerAddress"];
                    oCSDJob.Email = (string)reader["Email"];
                    oCSDJob.NationalID = (string)reader["NationalID"];
                    oCSDJob.Status = (int)reader["Status"];
                    oCSDJob.StatusName = (string)reader["StatusName"];
                    //oCSDJob.StatusReason = (string)reader["StatusReason"];
                    oCSDJob.CreateUserID = (int)reader["CreateUserID"];
                    oCSDJob.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDJob.AssignTo = (int)reader["AssignTo"];
                    oCSDJob.OwnOrOtherTechnician = (int)reader["OwnOrOtherTechnician"];
                    //oCSDJob.ReceivingTransportationMode = (int)reader["ReceivingTransportationMode"];
                    //oCSDJob.ReceivingCourierID = (int)reader["ReceivingCourierID"];
                    //oCSDJob.ReceivingInstrumentNo = (string)reader["ReceivingInstrumentNo"];
                    //oCSDJob.ReceivingCost = Convert.ToDouble(reader["ReceivingCost"].ToString());
                    //oCSDJob.DeliveryTransportationMode = (int)reader["DeliveryTransportationMode"];
                    //oCSDJob.DeliveryCourierID = (int)reader["DeliveryCourierID"];
                    //oCSDJob.DeliveryInstrumentNo = (string)reader["DeliveryInstrumentNo"];
                    //oCSDJob.DeliveryCost = Convert.ToDouble(reader["DeliveryCost"].ToString());
                    //oCSDJob.ProductLocation = (int)reader["ProductLocation"];
                    //oCSDJob.SparePartsUsed = (int)reader["SparePartsUsed"];
                    //oCSDJob.ActualFaultID = (int)reader["ActualFaultID"];
                    //oCSDJob.InterSerJobType = (int)reader["InterSerJobType"];
                    oCSDJob.ASGID = (int)reader["ASGID"];
                    oCSDJob.ASGName = (string)reader["ASGName"];
                    oCSDJob.ProductCode = (string)reader["ProductCode"];
                    oCSDJob.ProductName = (string)reader["ProductName"];
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
        public void GetJobforAssign(DateTime dtFromDate, DateTime dtToDate, String sMobileNo, String sJobNo, int nASGID, int nWorkshop, String sCustomerName, String sProduct, int nServiceType, int nJobType, bool IsCheck, int nType, bool isLFDateChecked, DateTime dtLFDateFrom, DateTime dtLFDateTo, int nTechnicianType, int nThirdPartyID, int nTechnicianID, int nStatus, int nWorkshopTypeID)//
        {
            dtToDate = dtToDate.Date.AddDays(1);
            dtLFDateTo = dtLFDateTo.Date.AddDays(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = string.Empty;
            string subquery = string.Empty;


//            sSql = @"SELECT JobID,IsNull(ProductSerialNo,'') as ProductSerialNo,IsNull(InvoiceNo,'')InvoiceNo,InvoiceDate,
//                    SalesChannelID,SalesPointID,JobNo,ServiceType, ServiceTypeDes=CASE When ServiceType = 1 then 'Walkin' When ServiceType = 2 then 'Home Call' 
//                    When ServiceType = 3 then 'Inter Service' When ServiceType = 4 then 'Installation' else 'Others' end, 
//                    JobType, JobTypeDes=CASE When JobType = 1 then 'Full Warranty' 
//                    When JobType = 2 then 'Paid' When JobType = 3 then 'Service Warranty' 
//                    When JobType = 4 then 'Component Warranty' else 'Others' end, 
//                    WorkshopID,Priority,a.Remarks,a.ProductID,PrimaryFaultID,RefChannelID, 
//                    CustomerName,TelePhone, a.MobileNo,CustomerAddress,a.Email,NationalID,Status,StatusName,StatusReason, 
//                    a.CreateUserID,a.CreateDate,IsNull(AssignTo,0)AssignTo,P.Name WorkshopName, 
//                    ProductCode, ProductName,ASGID, ASGName,a.LastFeedBackDate,VisitingTimeFrom,VisitingTimeTo,
//                    VisitingDate,OwnOrOtherTechnician,EstSpAmount,EstScAmount from t_CSDJob a 
//                    INNER JOIN t_CSDServiceChargeProduct M ON a.ProductID = M.ProductID
//                    INNER JOIN t_CSDServiceCharge N ON M.ServiceChargeID = N.ServiceChargeID 
//                    INNER JOIN t_CSDProductType O ON N.ProductTypeID = O.ProductTypeID 
//                    INNER JOIN t_CSDWorkshopType P ON  O.WorkShopTypeID =P.WorkShopTypeID 
//                    LEFT JOIN t_CSDTechnician t ON t.TechnicianID = a.AssignTo
//                    LEFT JOIN t_CSDInterService TP ON TP.InterServiceID = t.ThirdPartyID,
//                    (Select ProductID, ProductCode, ProductName,ASGID, ASGName from v_ProductDetails)b, t_CSDJobStatus c
//                    Where a.ProductID=b.ProductID and a.Status=c.StatusID  and 1=1 ";

            sSql = @"Select * From (SELECT JobID,IsNull(ProductSerialNo,'') as ProductSerialNo,IsNull(InvoiceNo,'')InvoiceNo,InvoiceDate,
                            SalesChannelID,SalesPointID,JobNo,ServiceType, ServiceTypeDes=CASE When ServiceType = 1 then 'Walkin' When ServiceType = 2 then 'Home Call' 
                            When ServiceType = 3 then 'Inter Service' When ServiceType = 4 then 'Installation' else 'Others' end, 
                            JobType, JobTypeDes=CASE When JobType = 1 then 'Full Warranty' 
                            When JobType = 2 then 'Paid' When JobType = 3 then 'Service Warranty' 
                            When JobType = 4 then 'Component Warranty' else 'Others' end,IsDelivered,
                            WorkshopID,Priority,a.Remarks,a.ProductID,PrimaryFaultID,RefChannelID,TP.InterServiceID,
                            CustomerName,TelePhone, a.MobileNo,CustomerAddress,a.Email,NationalID,Status,StatusName,StatusReason, 
                            a.CreateUserID,a.CreateDate,IsNull(AssignTo,0)AssignTo,P.Name WorkshopName,P.WorkShopTypeID, 
                            ProductCode,ProductName,ASGID, ASGName,a.LastFeedBackDate,VisitingTimeFrom,VisitingTimeTo,
                            VisitingDate,OwnOrOtherTechnician,EstSpAmount,EstScAmount from t_CSDJob a 
                            INNER JOIN t_CSDServiceChargeProduct M ON a.ProductID = M.ProductID
                            INNER JOIN t_CSDServiceCharge N ON M.ServiceChargeID = N.ServiceChargeID 
                            INNER JOIN t_CSDProductType O ON N.ProductTypeID = O.ProductTypeID 
                            INNER JOIN t_CSDWorkshopType P ON  O.WorkShopTypeID =P.WorkShopTypeID 
                            LEFT JOIN t_CSDTechnician t ON t.TechnicianID = a.AssignTo
                            LEFT JOIN t_CSDInterService TP ON TP.InterServiceID = t.ThirdPartyID,
                            (Select ProductID, ProductCode, ProductName,ASGID, ASGName from v_ProductDetails)b, t_CSDJobStatus c
                            Where a.ProductID=b.ProductID and a.Status=c.StatusID   AND ProductPhysicalLocation = 2 
                            and IsDelivered =0 AND Status NOT IN (17,20,27)
                            UNION ALL
                            SELECT JobID,IsNull(ProductSerialNo,'') as ProductSerialNo,IsNull(InvoiceNo,'')InvoiceNo,InvoiceDate,
                            SalesChannelID,SalesPointID,JobNo,ServiceType, ServiceTypeDes=CASE When ServiceType = 1 then 'Walkin' When ServiceType = 2 then 'Home Call' 
                            When ServiceType = 3 then 'Inter Service' When ServiceType = 4 then 'Installation' else 'Others' end, 
                            JobType, JobTypeDes=CASE When JobType = 1 then 'Full Warranty' 
                            When JobType = 2 then 'Paid' When JobType = 3 then 'Service Warranty' 
                            When JobType = 4 then 'Component Warranty' else 'Others' end,IsDelivered,
                            WorkshopID,Priority,a.Remarks,a.ProductID,PrimaryFaultID,RefChannelID,TP.InterServiceID,
                            CustomerName,TelePhone, a.MobileNo,CustomerAddress,a.Email,NationalID,Status,StatusName,StatusReason, 
                            a.CreateUserID,a.CreateDate,IsNull(AssignTo,0)AssignTo,P.Name WorkshopName,P.WorkShopTypeID,
                            ProductCode, ProductName,ASGID, ASGName,a.LastFeedBackDate,VisitingTimeFrom,VisitingTimeTo,
                            VisitingDate,OwnOrOtherTechnician,EstSpAmount,EstScAmount from t_CSDJob a 
                            INNER JOIN t_CSDServiceChargeProduct M ON a.ProductID = M.ProductID
                            INNER JOIN t_CSDServiceCharge N ON M.ServiceChargeID = N.ServiceChargeID 
                            INNER JOIN t_CSDProductType O ON N.ProductTypeID = O.ProductTypeID 
                            INNER JOIN t_CSDWorkshopType P ON  O.WorkShopTypeID =P.WorkShopTypeID 
                            LEFT JOIN t_CSDTechnician t ON t.TechnicianID = a.AssignTo
                            LEFT JOIN t_CSDInterService TP ON TP.InterServiceID = t.ThirdPartyID,
                            (Select ProductID, ProductCode, ProductName,ASGID, ASGName from v_ProductDetails)b, t_CSDJobStatus c
                            Where a.ProductID=b.ProductID and a.Status=c.StatusID AND ProductPhysicalLocation = 1 AND ProductLocation = 3
                            AND ProductMovementStatus = 2 AND Status NOT IN (17,20,27)) Main WHERE 1=1 ";

            if (nTechnicianType != 0)
            {
                //sSql = sSql + " and t.Type = " + nTechnicianType + " ";
                sSql = sSql + " and OwnOrOtherTechnician = " + nTechnicianType + " ";                
            }
            if (nStatus != -1)
            {
                sSql = sSql + " and Status = " + nStatus + " ";
            }
            if (nType == 2)
            {
                sSql = sSql + " and Status NOT IN (0,1,2,14,15,17,18,20,26,27) and IsDelivered = 0 ";
            }
            else if (nType == 4)
            {
                sSql = sSql + " and Status IN (17,26) and IsDelivered = 0 ";
            }

            //sSql = sSql + " and ServiceType IN (" + (int)Dictionary.ServiceType.Walkin + "," + (int)Dictionary.ServiceType.HomeCall + "," + (int)Dictionary.ServiceType.Installation + ") ";
            if (nServiceType > 0)
            {
                sSql = sSql + "  and ServiceType =" + nServiceType + " ";
            }
            //else
            //{
            //    sSql = sSql + "  and ServiceType IN (2,4)  ";
            //}
            if (nJobType > 0)
            {
                sSql = sSql + "  and JobType =" + nJobType + " ";
            }
            if (IsCheck == false)
            {
                sSql = sSql + " and CreateDate BETWEEN '" + dtFromDate + "'AND '" + dtToDate + "' AND CreateDate < '" + dtToDate + "' ";
            }
            if (!isLFDateChecked)
            {
                sSql += " AND LastFeedBackDate BETWEEN '" + dtLFDateFrom + "'AND '" + dtLFDateTo + "' AND LastFeedBackDate < '" + dtLFDateTo + "' ";
            }
            if (sJobNo != "")
            {
                sSql = sSql + "  and JobNo = '" + sJobNo + "' ";
            }
            if (sProduct != "")
            {
                sSql = sSql + "  and ProductName like '%" + sProduct + "%' ";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + "  and CustomerName like '%" + sCustomerName + "%' ";
            }
            if (sMobileNo != "")
            {
                sSql = sSql + "  and MobileNo like '%" + sMobileNo + "%' ";
            }
            if (nASGID > 0)
            {
                sSql = sSql + "  and ASGID =" + nASGID + " ";
            }
            if (nThirdPartyID != -1)
            {
                sSql += " AND TP.InterServiceID = " + nThirdPartyID + " ";
            }
            if (nTechnicianID != 0)
            {
                sSql += " AND AssignTo = " + nTechnicianID + " ";
            }
            if (nWorkshopTypeID != -1)
            {
                sSql += " AND P.WorkShopTypeID = " + nWorkshopTypeID + " ";
            }
            sSql = sSql + " order by JobID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CSDJob oCSDJob = new CSDJob();

                    oCSDJob.JobID = (int)reader["JobID"];
                    oCSDJob.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oCSDJob.InvoiceNo = (string)reader["InvoiceNo"];
                    oCSDJob.InvoiceDate = (object)reader["InvoiceDate"];
                    oCSDJob.SalesChannelID = (int)reader["SalesChannelID"];
                    oCSDJob.SalesPointID = (int)reader["SalesPointID"];
                    oCSDJob.JobNo = (string)reader["JobNo"];
                    oCSDJob.ServiceType = (int)reader["ServiceType"];
                    oCSDJob.JobType = (int)reader["JobType"];
                    oCSDJob.JobTypeDes = (string)reader["JobTypeDes"];
                    oCSDJob.WorkshopID = (int)reader["WorkshopID"];
                    oCSDJob.WorkshopName = (string)reader["WorkshopName"];
                    //oCSDJob.ReferenceJobNo = (string)reader["ReferenceJobNo"];
                    oCSDJob.Priority = (int)reader["Priority"];
                    oCSDJob.LastFeedBackDate = Convert.ToDateTime(reader["LastFeedBackDate"].ToString());
                    //oCSDJob.DeliveryDate = (object)reader["DeliveryDate"];
                    oCSDJob.Remarks = (string)reader["Remarks"];
                    oCSDJob.ProductID = (int)reader["ProductID"];
                    //oCSDJob.FullOrAccessories = (int)reader["FullOrAccessories"];
                    //oCSDJob.AccessoryID = (int)reader["AccessoryID"];
                    oCSDJob.PrimaryFaultID = (int)reader["PrimaryFaultID"];
                    //oCSDJob.OwnOrCustomerSet = (int)reader["OwnOrCustomerSet"];
                    //oCSDJob.RefChannelID = (int)reader["RefChannelID"];
                    //oCSDJob.RefSalesPointID = (int)reader["RefSalesPointID"];
                    oCSDJob.CustomerName = (string)reader["CustomerName"];
                    oCSDJob.TelePhone = (string)reader["TelePhone"];
                    oCSDJob.MobileNo = (string)reader["MobileNo"];
                    oCSDJob.CustomerAddress = (string)reader["CustomerAddress"];
                    oCSDJob.Email = (string)reader["Email"];
                    oCSDJob.NationalID = (string)reader["NationalID"];
                    oCSDJob.Status = (int)reader["Status"];
                    oCSDJob.StatusName = (string)reader["StatusName"];
                    //oCSDJob.StatusReason = (string)reader["StatusReason"];
                    oCSDJob.CreateUserID = (int)reader["CreateUserID"];
                    oCSDJob.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDJob.AssignTo = (int)reader["AssignTo"];
                    if (reader["OwnOrOtherTechnician"] != DBNull.Value)
                    oCSDJob.OwnOrOtherTechnician = (int)reader["OwnOrOtherTechnician"];
                    //oCSDJob.ReceivingTransportationMode = (int)reader["ReceivingTransportationMode"];
                    //oCSDJob.ReceivingCourierID = (int)reader["ReceivingCourierID"];
                    //oCSDJob.ReceivingInstrumentNo = (string)reader["ReceivingInstrumentNo"];
                    //oCSDJob.ReceivingCost = Convert.ToDouble(reader["ReceivingCost"].ToString());
                    //oCSDJob.DeliveryTransportationMode = (int)reader["DeliveryTransportationMode"];
                    //oCSDJob.DeliveryCourierID = (int)reader["DeliveryCourierID"];
                    //oCSDJob.DeliveryInstrumentNo = (string)reader["DeliveryInstrumentNo"];
                    //oCSDJob.DeliveryCost = Convert.ToDouble(reader["DeliveryCost"].ToString());
                    //oCSDJob.ProductLocation = (int)reader["ProductLocation"];
                    //oCSDJob.SparePartsUsed = (int)reader["SparePartsUsed"];
                    //oCSDJob.ActualFaultID = (int)reader["ActualFaultID"];
                    //oCSDJob.InterSerJobType = (int)reader["InterSerJobType"];
                    oCSDJob.ASGID = (int)reader["ASGID"];
                    oCSDJob.ASGName = (string)reader["ASGName"];
                    oCSDJob.ProductCode = (string)reader["ProductCode"];
                    oCSDJob.ProductName = (string)reader["ProductName"];
                    if (reader["VisitingDate"] != DBNull.Value)
                    oCSDJob.VisitingDate = (object)(reader["VisitingDate"]);
                    if (reader["VisitingTimeFrom"] != DBNull.Value)
                    oCSDJob.VisitingTimeFrom = (object)(reader["VisitingTimeFrom"]);
                    if (reader["VisitingTimeTo"] != DBNull.Value)
                        oCSDJob.VisitingTimeTo = (object)(reader["VisitingTimeTo"]);
                    if (reader["EstSpAmount"] != DBNull.Value)
                        oCSDJob.EstSpAmount = Convert.ToDouble(reader["EstSpAmount"].ToString());
                    if (reader["EstScAmount"] != DBNull.Value)
                        oCSDJob.EstScAmount = Convert.ToDouble(reader["EstScAmount"].ToString());
                    
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
        public void GetTransferRequiredJob(bool IsCheck, DateTime dtFromDate, DateTime dtToDate, bool isLFDateChecked, DateTime dtLFDateFrom, DateTime dtLFDateTo, string sJobNo, string sMobileNo, int nTechnicianID, int nWorkshopTypeID)//
        {
            dtToDate = dtToDate.Date.AddDays(1);
            dtLFDateTo = dtLFDateTo.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //sSql = "  SELECT JobID,IsNull(ProductSerialNo,'') as ProductSerialNo,IsNull(InvoiceNo,'')InvoiceNo,InvoiceDate, " +
            //       "  SalesChannelID,SalesPointID,JobNo,ServiceType, ServiceTypeDes=CASE When ServiceType = 1 then 'Walkin' When ServiceType = 2 then 'Home Call' " +
            //       "  When ServiceType = 3 then 'Inter Service' When ServiceType = 4 then 'Installation' else 'Others' end, " +
            //       "  JobType, JobTypeDes=CASE When JobType = 1 then 'Full Warranty' " +
            //       "  When JobType = 2 then 'Paid' When JobType = 3 then 'Service Warranty' " +
            //       "  When JobType = 4 then 'Component Warranty' else 'Others' end, " +
            //       "  WorkshopID,Priority,a.Remarks,a.ProductID,PrimaryFaultID,RefChannelID, " +
            //       "  CustomerName,TelePhone, a.MobileNo,CustomerAddress,a.Email,NationalID,Status,StatusName,StatusReason, " +
            //       "  a.CreateUserID,a.CreateDate,IsNull(AssignTo,0)AssignTo, a.ThanaID, " +
            //       "  ProductCode, ProductName,ASGID, ASGName,a.LastFeedBackDate from t_CSDJob a " +
            //       "  " + subquery + " " +
            //       "  LEFT JOIN t_CSDTechnician t ON t.TechnicianID = a.AssignTo" +
            //       "  LEFT JOIN t_CSDInterService TP ON TP.InterServiceID = t.ThirdPartyID, " +
            //       " (Select ProductID, ProductCode, ProductName,ASGID, ASGName from v_ProductDetails)b, t_CSDJobStatus c  " +
            //      "  Where a.ProductID=b.ProductID and a.Status=c.StatusID AND a.Status = " + (int)Dictionary.JobStatus.TransportRequired + " ";

            string sSql = @"SELECT JobID,IsNull(ProductSerialNo,'') as ProductSerialNo,ISNULL(OriginalProductSerialNo,'')OriginalProductSerialNo,
                  IsNull(InvoiceNo,'')InvoiceNo,InvoiceDate,SalesChannelID,SalesPointID,JobNo,ServiceType, ServiceTypeDes=CASE When ServiceType = 1 then 'Walkin' When ServiceType = 2 then 'Home Call' 
                  When ServiceType = 3 then 'Inter Service' When ServiceType = 4 then 'Installation' else 'Others' end, 
                  JobType, JobTypeDes=CASE When JobType = 1 then 'Full Warranty' 
                  When JobType = 2 then 'Paid' When JobType = 3 then 'Service Warranty' 
                  When JobType = 4 then 'Component Warranty' else 'Others' end, WorkshopID,ISNULL(ReferenceJobNo,'') ReferenceJobNo,
                  ISNULL(GSPNJobNo,'')GSPNJobNo,Priority,a.LastFeedBackDate,VisitingTimeFrom,VisitingTimeTo,DeliveryDate,
                  a.Remarks,a.ProductID,PrimaryFaultID,OwnOrCustomerSet,RefChannelID,RefSalesPointID,
                  CustomerName,TelePhone, a.MobileNo,CustomerAddress,a.ThanaID,a.Email,NationalID,Status,StatusName,SubStatus,StatusReason, 
                  a.CreateUserID,a.CreateDate,IsNull(AssignTo,0)AssignTo,AccessoryID,
                  AssignLeadMinute,OwnOrOtherTechnician,ReceivingTransportationMode,ReceivingCourierID,
                  ReceivingInstrumentNo,ReceivingCost,DeliveryTransportationMode,DeliveryCourierID,DeliveryInstrumentNo,
                  DeliveryCost,ProductLocation,ProductMovementStatus,SparePartsUsed,IsStoreClearance,ActualFaultID,
                  InterSerJobType,IsDelivered,IsReplacement,a.UpdateUserID,a.UpdateDate,IsHappyCall,HaveBackupSet,ProductPhysicalLocation,
                  VisitingDate,FullOrAccessories,pdt.ProductCode, pdt.ProductName,ASGID,ASGName,P.Name AS WorkshopName from t_CSDJob a 
                  INNER JOIN t_CSDServiceChargeProduct M ON a.ProductID = M.ProductID
                  INNER JOIN t_CSDServiceCharge N ON M.ServiceChargeID = N.ServiceChargeID 
                  INNER JOIN t_CSDProductType O ON N.ProductTypeID = O.ProductTypeID 
                  INNER JOIN t_CSDWorkshopType P ON  O.WorkShopTypeID =P.WorkShopTypeID
                  INNER JOIN t_Product pdt ON a.ProductID = pdt.ProductID
                  LEFT JOIN t_CSDTechnician t ON t.TechnicianID = a.AssignTo
                  LEFT JOIN t_CSDInterService TP ON TP.InterServiceID = t.ThirdPartyID, 
                  (Select ProductID, ProductCode, ProductName,ASGID, ASGName from v_ProductDetails)b, t_CSDJobStatus c  
                  Where a.ProductID=b.ProductID and a.Status=c.StatusID AND a.Status =18 ";

            if (sJobNo != string.Empty)
            {
                sSql = sSql + "  and a.JobNo = '" + sJobNo + "' ";
            }

            if (sMobileNo != string.Empty)
            {
                sSql = sSql + "  and a.MobileNo like '%" + sMobileNo + "%' ";
            }

            if (nTechnicianID != 0)
            {
                sSql += " AND a.AssignTo = " + nTechnicianID + " ";
            }

            if (IsCheck == false)
            {
                sSql = sSql + " and a.CreateDate BETWEEN '" + dtFromDate + "'AND '" + dtToDate + "' AND a.CreateDate < '" + dtToDate + "' ";
            }
            if (!isLFDateChecked)
            {
                sSql += " AND a.LastFeedBackDate BETWEEN '" + dtLFDateFrom + "'AND '" + dtLFDateTo + "' AND a.LastFeedBackDate < '" + dtLFDateTo + "' ";
            }
            if (nWorkshopTypeID != -1)
            {
                sSql += " AND P.WorkShopTypeID = " + nWorkshopTypeID + " ";
            }
            sSql = sSql + " order by JobID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJob oCSDJob = new CSDJob();
                    oCSDJob.JobID = (int)reader["JobID"];
                    oCSDJob.ProductCode = (string)reader["ProductCode"];
                    oCSDJob.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oCSDJob.OriginalProductSerialNo = (string)reader["OriginalProductSerialNo"];
                    oCSDJob.InvoiceNo = (string)reader["InvoiceNo"];
                    if (reader["InvoiceDate"] != DBNull.Value)
                        oCSDJob.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oCSDJob.SalesChannelID = (int)reader["SalesChannelID"];
                    oCSDJob.SalesPointID = (int)reader["SalesPointID"];
                    oCSDJob.JobNo = (string)reader["JobNo"];
                    oCSDJob.ServiceType = (int)reader["ServiceType"];
                    oCSDJob.ServiceTypeDes = (string)reader["ServiceTypeDes"];
                    oCSDJob.JobType = (int)reader["JobType"];
                    oCSDJob.JobTypeDes = (string)reader["JobTypeDes"];
                    oCSDJob.WorkshopID = (int)reader["WorkshopID"];
                    oCSDJob.ReferenceJobNo = (string)reader["ReferenceJobNo"];
                    oCSDJob.GSPNJobNo = (string)reader["GSPNJobNo"];
                    oCSDJob.Priority = (int)reader["Priority"];
                    oCSDJob.LastFeedBackDate = Convert.ToDateTime(reader["LastFeedBackDate"].ToString());
                    if (reader["VisitingTimeFrom"] != DBNull.Value)
                        oCSDJob.VisitingTimeFrom = Convert.ToDateTime(reader["VisitingTimeFrom"].ToString());
                    if (reader["VisitingTimeTo"] != DBNull.Value)
                        oCSDJob.VisitingTimeTo = Convert.ToDateTime(reader["VisitingTimeTo"].ToString());
                    if (reader["DeliveryDate"] != DBNull.Value)
                        oCSDJob.DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    oCSDJob.Remarks = (string)reader["Remarks"];
                    oCSDJob.ProductID = (int)reader["ProductID"];
                    oCSDJob.ProductName = (string)reader["ProductName"];
                    oCSDJob.ASGName = (string)reader["ASGName"];
                    oCSDJob.FullOrAccessories = (int)reader["FullOrAccessories"];
                    if (reader["AccessoryID"] != DBNull.Value)
                        oCSDJob.AccessoryID = (int)reader["AccessoryID"];
                    oCSDJob.PrimaryFaultID = (int)reader["PrimaryFaultID"];
                    oCSDJob.OwnOrCustomerSet = (int)reader["OwnOrCustomerSet"];
                    oCSDJob.RefChannelID = (int)reader["RefChannelID"];
                    if (reader["RefSalesPointID"] != DBNull.Value)
                        oCSDJob.RefSalesPointID = (int)reader["RefSalesPointID"];
                    oCSDJob.CustomerName = (string)reader["CustomerName"];
                    oCSDJob.TelePhone = (string)reader["TelePhone"];
                    oCSDJob.MobileNo = (string)reader["MobileNo"];
                    oCSDJob.CustomerAddress = (string)reader["CustomerAddress"];
                    oCSDJob.ThanaID = (int)reader["ThanaID"];
                    oCSDJob.Email = (string)reader["Email"];
                    oCSDJob.NationalID = (string)reader["NationalID"];
                    oCSDJob.Status = (int)reader["Status"];
                    oCSDJob.StatusName = (string)reader["StatusName"];
                    if (reader["SubStatus"] != DBNull.Value)
                        oCSDJob.SubStatus = (int)reader["SubStatus"];
                    oCSDJob.StatusReason = (string)reader["StatusReason"];
                    oCSDJob.CreateUserID = (int)reader["CreateUserID"];
                    oCSDJob.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDJob.AssignTo = (int)reader["AssignTo"];
                    oCSDJob.AssignLeadMinute = (int)reader["AssignLeadMinute"];
                    oCSDJob.OwnOrOtherTechnician = (int)reader["OwnOrOtherTechnician"];
                    oCSDJob.ReceivingTransportationMode = (int)reader["ReceivingTransportationMode"];
                    if (reader["ReceivingCourierID"] != DBNull.Value)
                        oCSDJob.ReceivingCourierID = (int)reader["ReceivingCourierID"];
                    oCSDJob.ReceivingInstrumentNo = (string)reader["ReceivingInstrumentNo"];
                    oCSDJob.ReceivingCost = Convert.ToDouble(reader["ReceivingCost"].ToString());
                    if (reader["DeliveryTransportationMode"] != DBNull.Value)
                        oCSDJob.DeliveryTransportationMode = (int)reader["DeliveryTransportationMode"];
                    if (reader["DeliveryCourierID"] != DBNull.Value)
                        oCSDJob.DeliveryCourierID = (int)reader["DeliveryCourierID"];
                    oCSDJob.DeliveryInstrumentNo = (string)reader["DeliveryInstrumentNo"];
                    oCSDJob.DeliveryCost = Convert.ToDouble(reader["DeliveryCost"].ToString());
                    oCSDJob.ProductLocation = (int)reader["ProductLocation"];
                    oCSDJob.ProductMovementStatus = (int)reader["ProductMovementStatus"];
                    oCSDJob.SparePartsUsed = (int)reader["SparePartsUsed"];
                    oCSDJob.IsStoreClearance = (int)reader["IsStoreClearance"];
                    if (reader["ActualFaultID"] != DBNull.Value)
                        oCSDJob.ActualFaultID = (int)reader["ActualFaultID"];
                    if (reader["InterSerJobType"] != DBNull.Value)
                        oCSDJob.InterSerJobType = (int)reader["InterSerJobType"];
                    oCSDJob.IsDelivered = (int)reader["IsDelivered"];
                    oCSDJob.IsReplacement = (int)reader["IsReplacement"];
                    if (reader["UpdateUserID"] != DBNull.Value)
                        oCSDJob.UpdateUserID = (int)reader["UpdateUserID"];
                    if (reader["UpdateDate"] != DBNull.Value)
                        oCSDJob.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oCSDJob.IsHappyCall = (int)reader["IsHappyCall"];
                    oCSDJob.HaveBackupset = (int)reader["HaveBackupSet"];
                    oCSDJob.ProductPhysicalLocation = (int)reader["ProductPhysicalLocation"];
                    if (reader["VisitingDate"] != DBNull.Value)
                        oCSDJob.VisitingDate = Convert.ToDateTime(reader["VisitingDate"].ToString());
                    oCSDJob.WorkshopName = (string)reader["WorkshopName"];
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
        public void GetEDDList(int nJobType, int nServiceType, int nJobStatus, String sJobNo, bool isLFDateChecked, DateTime dtLFDateFrom, DateTime dtLFDateTo, int nThirdPartyID)
        {
            dtLFDateTo = dtLFDateTo.Date.AddDays(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            sSql = @"SELECT JobID,IsNull(ProductSerialNo,'') as ProductSerialNo,IsNull(InvoiceNo,'')InvoiceNo,InvoiceDate, 
                    SalesChannelID,SalesPointID,JobNo,ServiceType, ServiceTypeDes=CASE When ServiceType = 1 then 'Walkin' When ServiceType = 2 then 'Home Call' 
                    When ServiceType = 3 then 'Inter Service' When ServiceType = 4 then 'Installation' else 'Others' end, 
                    JobType, JobTypeDes=CASE When JobType = 1 then 'Full Warranty'
                    When JobType = 2 then 'Paid' When JobType = 3 then 'Service Warranty' 
                    When JobType = 4 then 'Component Warranty' else 'Others' end, 
                    WorkshopID,Priority,a.Remarks,a.ProductID,PrimaryFaultID,RefChannelID, 
                    CustomerName,a.TelePhone, a.MobileNo,CustomerAddress,a.Email,a.NationalID,
                    Status,StatusName,ISNULL(StatusReason,'') StatusReason,
                    a.CreateUserID,a.CreateDate,IsNull(AssignTo,0)AssignTo, 
                    ProductCode, ProductName,ASGID, ASGName,a.LastFeedBackDate,ISNULL(t.Name,'') TechnicianName,ISNULL(t.MobileNo,'') TechnicianMobile, 
                    ISNULL(TP.Name,'') ThirdPartyName, ISNULL(TP.Mobile,'') ThirdPartyMobile, ISNULL(TP.ContactPerson,'') TPContactPerson,
                    ISNULL(E.EmployeeName,'') SupervisorName,ISNULL(TS.MobileNo,'') TechSupMobile,a.VisitingDate,
                    a.VisitingTimeFrom,a.VisitingTimeTo,ISNULL(OwnOrOtherTechnician,-1) OwnOrOtherTechnician from t_CSDJob a 
                    LEFT JOIN t_CSDTechnician t ON t.TechnicianID = a.AssignTo
                    LEFT JOIN t_CSDInterService TP ON TP.InterServiceID = t.ThirdPartyID 
                    LEFT JOIN t_CSDTechnicalSupervisor TS ON t.SupervisorID = TS.SupervisorID
                    LEFT JOIN t_EMployee E ON E.EmployeeID = TS.EmployeeID, 
                    (Select ProductID, ProductCode, ProductName,ASGID, ASGName from v_ProductDetails)b, t_CSDJobStatus c  
                    Where a.ProductID=b.ProductID and a.Status=c.StatusID and Status NOT IN (0,1,2,14,15,17,18,20,26,27)
                    and IsDelivered = 0 AND ServiceType NOT IN (1)                  
                    ";

            if (nJobType != 0)
            {
                sSql += " AND a.JobType = " + nJobType + " ";
            }
            if (nServiceType != 0)
            {
                sSql += " AND a.ServiceType = " + nServiceType + " ";
            }
            if (nJobStatus != -1)
            {
                sSql += " AND a.Status = " + nJobStatus + " ";
            }

            if (!isLFDateChecked)
            {
                sSql += " AND a.LastFeedBackDate BETWEEN '" + dtLFDateFrom + "'AND '" + dtLFDateTo + "' AND a.LastFeedBackDate < '" + dtLFDateTo + "' ";
            }

            if (sJobNo != string.Empty)
            {
                sSql += "  AND a.JobNo like '%" + sJobNo + "%' ";
            }
            if (nThirdPartyID != -1)
            {
                sSql += " AND TP.InterServiceID = " + nThirdPartyID + " ";
            }
            sSql += " order by JobID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CSDJob oCSDJob = new CSDJob();

                    oCSDJob.JobID = (int)reader["JobID"];
                    oCSDJob.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oCSDJob.InvoiceNo = (string)reader["InvoiceNo"];
                    oCSDJob.InvoiceDate = (object)reader["InvoiceDate"];
                    oCSDJob.SalesChannelID = (int)reader["SalesChannelID"];
                    oCSDJob.SalesPointID = (int)reader["SalesPointID"];
                    oCSDJob.JobNo = (string)reader["JobNo"];
                    oCSDJob.ServiceType = (int)reader["ServiceType"];
                    oCSDJob.JobType = (int)reader["JobType"];
                    oCSDJob.JobTypeDes = (string)reader["JobTypeDes"];
                    oCSDJob.WorkshopID = (int)reader["WorkshopID"];
                    oCSDJob.Priority = (int)reader["Priority"];
                    oCSDJob.LastFeedBackDate = Convert.ToDateTime(reader["LastFeedBackDate"].ToString());
                    oCSDJob.Remarks = (string)reader["Remarks"];
                    oCSDJob.ProductID = (int)reader["ProductID"];
                    oCSDJob.PrimaryFaultID = (int)reader["PrimaryFaultID"];
                    oCSDJob.CustomerName = (string)reader["CustomerName"];
                    oCSDJob.TelePhone = (string)reader["TelePhone"];
                    oCSDJob.MobileNo = (string)reader["MobileNo"];
                    oCSDJob.CustomerAddress = (string)reader["CustomerAddress"];
                    oCSDJob.Email = (string)reader["Email"];
                    oCSDJob.NationalID = (string)reader["NationalID"];
                    oCSDJob.Status = (int)reader["Status"];
                    oCSDJob.StatusName = (string)reader["StatusName"];
                    oCSDJob.CreateUserID = (int)reader["CreateUserID"];
                    oCSDJob.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDJob.AssignTo = (int)reader["AssignTo"];
                    oCSDJob.ASGID = (int)reader["ASGID"];
                    oCSDJob.ASGName = (string)reader["ASGName"];
                    oCSDJob.OwnOrOtherTechnician = (int)reader["OwnOrOtherTechnician"];
                    if (reader["VisitingDate"] != DBNull.Value)
                    {
                        oCSDJob.VisitingDate = (object)reader["VisitingDate"];
                    }
                    if (reader["VisitingTimeFrom"] != DBNull.Value)
                    {
                        oCSDJob.VisitingTimeFrom = (object)reader["VisitingTimeFrom"];
                    }
                    if (reader["VisitingTimeTo"] != DBNull.Value)
                    {
                        oCSDJob.VisitingTimeTo = (object)reader["VisitingTimeTo"];
                    }

                    oCSDJob.ProductCode = (string)reader["ProductCode"];
                    oCSDJob.ProductName = (string)reader["ProductName"];

                    oCSDJob.oEmployee.EmployeeName = (string)reader["SupervisorName"];
                    oCSDJob.oEmployee.Mobile = (string)reader["TechSupMobile"];

                    oCSDJob.oThirdParty.Name = (string)reader["ThirdPartyName"];
                    oCSDJob.oThirdParty.Mobile = (string)reader["ThirdPartyMobile"];
                    oCSDJob.oThirdParty.ContactPerson = (string)reader["TPContactPerson"];

                    oCSDJob.oTechnician.Name = (string)reader["TechnicianName"];
                    oCSDJob.oTechnician.MobileNo = (string)reader["TechnicianMobile"];

                    oCSDJob.StatusReason = (string)reader["StatusReason"];



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
        public void GetAssignJob(DateTime dtFromDate, DateTime dtToDate, String sJobNo, int nASGID, int nWorkshop, String sCustomerName, String sProduct, int nJobType, int nServiceType, bool IsCheck, bool IsReassignTech)//
        {
            dtToDate = dtToDate.Date.AddDays(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            string sSubQuery = string.Empty;
            if (sJobNo != "")
            {
                sSubQuery = " AND JobNo = '" + sJobNo + "' ";
            }

            string sSubQueryForServiceType = " ";
            if (nServiceType != 0)
            {
                sSubQueryForServiceType = " AND a.ServiceType = " + nServiceType + " ";
            }
            string sSubQueryForWorkshop = " ";
            if (nWorkshop != 0)
            {
                sSubQueryForWorkshop = " AND P.WorkShopTypeID = " + nWorkshop + " ";
            }
            if (!IsReassignTech)
            {
                sSql = " SELECT JobID,IsNull(ProductSerialNo,'') as ProductSerialNo,IsNull(InvoiceNo,'')InvoiceNo,InvoiceDate, " +
                      "  SalesChannelID,SalesPointID,JobNo,ServiceType, ServiceTypeDes=CASE When ServiceType = 1 then 'Walkin' When ServiceType = 2 then 'Home Call' " +
                      "  When ServiceType = 3 then 'Inter Service' When ServiceType = 4 then 'Installation' else 'Others' end, " +
                      "  JobType, JobTypeDes=CASE When JobType = 1 then 'Full Warranty' " +
                      "  When JobType = 2 then 'Paid' When JobType = 3 then 'Service Warranty' " +
                      "  When JobType = 4 then 'Component Warranty' else 'Others' end, " +
                      "  WorkshopID,Priority,Remarks,a.ProductID,PrimaryFaultID,RefChannelID, " +
                      "  CustomerName,TelePhone, a.MobileNo,CustomerAddress,Email,NationalID,Status,StatusReason, " +
                      "  a.CreateUserID,a.CreateDate,IsNull(AssignTo,0)AssignTo,IsNull(t.Code,'')TechnicianCode,IsNull(t.Name,'')TechnicianName, " +
                      "  ProductCode, ProductName,ASGID, ASGName,ThanaID from t_CSDJob a " +
                      "  LEFT JOIN t_CSDtechnician t ON a.AssignTo = t.TechnicianID " +
                      "  INNER JOIN t_CSDServiceChargeProduct M ON a.ProductID = M.ProductID " +
                      "  INNER JOIN t_CSDServiceCharge N ON M.ServiceChargeID = N.ServiceChargeID " +
                      "  INNER JOIN t_CSDProductType O ON N.ProductTypeID = O.ProductTypeID " +
                      "  INNER JOIN t_CSDWorkshopType P ON  O.WorkShopTypeID =P.WorkShopTypeID, " +
                      "  (Select ProductID, ProductCode, ProductName,ASGID, ASGName from v_ProductDetails)b  " +
                      "  Where a.ProductID=b.ProductID and Status IN (" + (int)Dictionary.JobStatus.WalkinJobCreated + ") " +
                      "  AND ProductLocation = " + (int)Dictionary.ProductLocation.At_Workshop + " AND ProductPhysicalLocation = " + (int)Dictionary.ProductPhysicalLocation.CentralService + " AND IsNull(AssignTo,0) = 0 " + sSubQuery + " " +
                      "  " + sSubQueryForServiceType + " " +
                      "  " + sSubQueryForWorkshop + " " +
                      "  UNION ALL " +
                      "  SELECT JobID,IsNull(ProductSerialNo,'') as ProductSerialNo,IsNull(InvoiceNo,'')InvoiceNo,InvoiceDate, " +
                      "  SalesChannelID,SalesPointID,JobNo,ServiceType, ServiceTypeDes=CASE When ServiceType = 1 then 'Walkin' When ServiceType = 2 then 'Home Call' " +
                      "  When ServiceType = 3 then 'Inter Service' When ServiceType = 4 then 'Installation' else 'Others' end, " +
                      "  JobType, JobTypeDes=CASE When JobType = 1 then 'Full Warranty' " +
                      "  When JobType = 2 then 'Paid' When JobType = 3 then 'Service Warranty' " +
                      "  When JobType = 4 then 'Component Warranty' else 'Others' end, " +
                      "  WorkshopID,Priority,Remarks,a.ProductID,PrimaryFaultID,RefChannelID, " +
                      "  CustomerName,TelePhone, a.MobileNo,CustomerAddress,Email,NationalID,Status,StatusReason, " +
                      "  a.CreateUserID,a.CreateDate,IsNull(AssignTo,0)AssignTo,IsNull(t.Code,'')TechnicianCode,IsNull(t.Name,'')TechnicianName, " +
                      "  ProductCode, ProductName,ASGID, ASGName,ThanaID from t_CSDJob a " +
                      "  INNER JOIN t_CSDServiceChargeProduct M ON a.ProductID = M.ProductID " +
                      "  INNER JOIN t_CSDServiceCharge N ON M.ServiceChargeID = N.ServiceChargeID " +
                      "  INNER JOIN t_CSDProductType O ON N.ProductTypeID = O.ProductTypeID " +
                      "  INNER JOIN t_CSDWorkshopType P ON  O.WorkShopTypeID =P.WorkShopTypeID " +
                      "  LEFT JOIN t_CSDtechnician t ON a.AssignTo = t.TechnicianID, " +
                      " (Select ProductID, ProductCode, ProductName,ASGID, ASGName from v_ProductDetails)b  " +
                      "  Where a.ProductID=b.ProductID and Status IN (" + (int)Dictionary.JobStatus.WalkinJobCreated + "," + (int)Dictionary.JobStatus.HomecallJobCreated + "," + (int)Dictionary.JobStatus.InstallationJobCreated + ") AND ProductPhysicalLocation = " + (int)Dictionary.ProductPhysicalLocation.OuterService + " AND IsNull(AssignTo,0) = 0 " + sSubQuery + " " +
                      "  " + sSubQueryForServiceType + " " +
                      "  " + sSubQueryForWorkshop + " ";

            }
            else
            {
                sSql = "SELECT JobID,IsNull(ProductSerialNo,'') as ProductSerialNo,IsNull(InvoiceNo,'')InvoiceNo,InvoiceDate, " +
                      "  SalesChannelID,SalesPointID,JobNo,ServiceType, ServiceTypeDes=CASE When ServiceType = 1 then 'Walkin' When ServiceType = 2 then 'Home Call' " +
                      "  When ServiceType = 3 then 'Inter Service' When ServiceType = 4 then 'Installation' else 'Others' end, " +
                      "  JobType, JobTypeDes=CASE When JobType = 1 then 'Full Warranty' " +
                      "  When JobType = 2 then 'Paid' When JobType = 3 then 'Service Warranty' " +
                      "  When JobType = 4 then 'Component Warranty' else 'Others' end, " +
                      "  WorkshopID,Priority,Remarks,a.ProductID,PrimaryFaultID,RefChannelID, " +
                      "  CustomerName,TelePhone, a.MobileNo,CustomerAddress,Email,NationalID,Status,StatusReason, " +
                      "  a.CreateUserID,a.CreateDate,IsNull(AssignTo,0)AssignTo,IsNull(t.Code,'')TechnicianCode, IsNull(t.Name,'')TechnicianName, " +
                      "  ProductCode, ProductName,ASGID, ASGName,ThanaID from t_CSDJob a " +
                      "  INNER JOIN t_CSDServiceChargeProduct M ON a.ProductID = M.ProductID " +
                      "  INNER JOIN t_CSDServiceCharge N ON M.ServiceChargeID = N.ServiceChargeID " +
                      "  INNER JOIN t_CSDProductType O ON N.ProductTypeID = O.ProductTypeID " +
                      "  INNER JOIN t_CSDWorkshopType P ON  O.WorkShopTypeID =P.WorkShopTypeID " +
                      "  LEFT JOIN t_CSDtechnician t ON a.AssignTo = t.TechnicianID, (Select ProductID, ProductCode, ProductName,ASGID, ASGName from v_ProductDetails)b  " +
                      "  Where a.ProductID=b.ProductID and Status IN (" + (int)Dictionary.JobStatus.ReadyForTest + "," + (int)Dictionary.JobStatus.AssignedToTechnician + "," +
                      "  " + (int)Dictionary.JobStatus.Estimated + "," + (int)Dictionary.JobStatus.EstimateApproved + "," + (int)Dictionary.JobStatus.Critical + "," + (int)Dictionary.JobStatus.WorkInProgress + "," + (int)Dictionary.JobStatus.TransportRequired + "," + (int)Dictionary.JobStatus.Pending + "," + (int)Dictionary.JobStatus.Untouched + "," + (int)Dictionary.JobStatus.ConvertedFromHomeCall + ") AND JobNo = '" + sJobNo + "'" +
                      "  " + sSubQueryForServiceType + " " +
                      "  " + sSubQueryForWorkshop + " ";
            }

            if (nJobType > 0)
            {
                sSql = sSql + "  and JobType =" + nJobType + " ";
            }
            if (IsCheck == false)
            {
                sSql = sSql + " and a.CreateDate BETWEEN '" + dtFromDate + "'AND '" + dtToDate + "' AND a.CreateDate < '" + dtToDate + "' ";
            }

            if (sProduct != "")
            {
                sSql = sSql + "  and ProductName like '%" + sProduct + "%' ";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + "  and CustomerName like '%" + sCustomerName + "%' ";
            }
            if (nASGID > 0)
            {
                sSql = sSql + "  and ASGID =" + nASGID + " ";
            }


            sSql = sSql + " order by JobID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJob oCSDJob = new CSDJob();

                    oCSDJob.JobID = (int)reader["JobID"];
                    oCSDJob.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oCSDJob.InvoiceNo = (string)reader["InvoiceNo"];
                    oCSDJob.InvoiceDate = (object)reader["InvoiceDate"];
                    oCSDJob.SalesChannelID = (int)reader["SalesChannelID"];
                    oCSDJob.SalesPointID = (int)reader["SalesPointID"];
                    oCSDJob.JobNo = (string)reader["JobNo"];
                    oCSDJob.ServiceType = (int)reader["ServiceType"];
                    oCSDJob.JobType = (int)reader["JobType"];
                    oCSDJob.WorkshopID = (int)reader["WorkshopID"];
                    //oCSDJob.ReferenceJobNo = (string)reader["ReferenceJobNo"];
                    oCSDJob.Priority = (int)reader["Priority"];
                    //oCSDJob.LastFeedBackDate = Convert.ToDateTime(reader["LastFeedBackDate"].ToString());
                    //oCSDJob.DeliveryDate = (object)reader["DeliveryDate"];
                    oCSDJob.Remarks = (string)reader["Remarks"];
                    oCSDJob.ProductID = (int)reader["ProductID"];
                    //oCSDJob.FullOrAccessories = (int)reader["FullOrAccessories"];
                    //oCSDJob.AccessoryID = (int)reader["AccessoryID"];
                    oCSDJob.PrimaryFaultID = (int)reader["PrimaryFaultID"];
                    //oCSDJob.OwnOrCustomerSet = (int)reader["OwnOrCustomerSet"];
                    //oCSDJob.RefChannelID = (int)reader["RefChannelID"];
                    //oCSDJob.RefSalesPointID = (int)reader["RefSalesPointID"];
                    oCSDJob.CustomerName = (string)reader["CustomerName"];
                    oCSDJob.TelePhone = (string)reader["TelePhone"];
                    oCSDJob.MobileNo = (string)reader["MobileNo"];
                    oCSDJob.CustomerAddress = (string)reader["CustomerAddress"];
                    oCSDJob.Email = (string)reader["Email"];
                    oCSDJob.NationalID = (string)reader["NationalID"];
                    oCSDJob.Status = (int)reader["Status"];
                    //oCSDJob.StatusReason = (string)reader["StatusReason"];
                    oCSDJob.CreateUserID = (int)reader["CreateUserID"];
                    oCSDJob.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDJob.ThanaID = (int)reader["ThanaID"];
                    //oCSDJob.OwnOrOtherTechnician = (int)reader["OwnOrOtherTechnician"];
                    //oCSDJob.ReceivingTransportationMode = (int)reader["ReceivingTransportationMode"];
                    //oCSDJob.ReceivingCourierID = (int)reader["ReceivingCourierID"];
                    //oCSDJob.ReceivingInstrumentNo = (string)reader["ReceivingInstrumentNo"];
                    //oCSDJob.ReceivingCost = Convert.ToDouble(reader["ReceivingCost"].ToString());
                    //oCSDJob.DeliveryTransportationMode = (int)reader["DeliveryTransportationMode"];
                    //oCSDJob.DeliveryCourierID = (int)reader["DeliveryCourierID"];
                    //oCSDJob.DeliveryInstrumentNo = (string)reader["DeliveryInstrumentNo"];
                    //oCSDJob.DeliveryCost = Convert.ToDouble(reader["DeliveryCost"].ToString());
                    //oCSDJob.ProductLocation = (int)reader["ProductLocation"];
                    //oCSDJob.SparePartsUsed = (int)reader["SparePartsUsed"];
                    //oCSDJob.ActualFaultID = (int)reader["ActualFaultID"];
                    //oCSDJob.InterSerJobType = (int)reader["InterSerJobType"];
                    oCSDJob.ASGID = (int)reader["ASGID"];
                    oCSDJob.ASGName = (string)reader["ASGName"];

                    oCSDJob.ProductCode = (string)reader["ProductCode"];
                    oCSDJob.ProductName = (string)reader["ProductName"];

                    oCSDJob.TechnicianCode = (string)reader["TechnicianCode"];
                    oCSDJob.TechnicianName = (string)reader["TechnicianName"];
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

        public void GetBillJobList(DateTime dtFromDate, DateTime dtToDate,bool IsChecked, String sJobNo,string sCustomerName,string sMobileNo, string sProductCode)
        {
            dtToDate = dtToDate.Date.AddDays(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            sSql = "Select a.JobID,JobNo,JobType,a.CreateDate,'['+ProductCode+']'+' '+ProductName as ProductName,ASGName,  " +
                    "CustomerName,a.MobileNo,c.Name as TechnicianName,ReceivedAmount as Amount   " +
                    "From t_CSDJob a,v_ProductDetails b, t_CSDTechnician c,t_CSDJobBill d   " +
                    "where a.ProductID=b.ProductID and a.JobID=d.JobID and a.AssignTo = c.TechnicianID   " +
                    "and ServiceType in (" + (int)Dictionary.ServiceType.HomeCall + "," + (int) Dictionary.ServiceType.Installation + ") and   " +
                    " Status=" + (int) Dictionary.JobStatus.ServiceProvided + "  " +
                    "and c.Type = " + (int) Dictionary.CSDTechnicianType.Own + " and a.JobID not in (Select JobID from t_CSDJobBillSendItem)";

            if (!IsChecked)
            {
                sSql = sSql + " AND a.CreateDate BETWEEN '" + dtFromDate + "'AND '" + dtToDate + "' AND a.CreateDate < '" + dtToDate + "' ";
            }

            if (sJobNo != string.Empty)
            {
                sSql = sSql + "  AND a.JobNo like '%" + sJobNo + "%' ";
            }
            if (sCustomerName != string.Empty)
            {
                sSql = sSql + "  AND CustomerName like '%" + sCustomerName + "%' ";
            }
            if (sMobileNo != string.Empty)
            {
                sSql = sSql + "  AND a.MobileNo like '%" + sMobileNo + "%' ";
            }
            if (sProductCode != string.Empty)
            {
                sSql = sSql + "  AND ProductCode like '%" + sProductCode + "%' ";
            }
            sSql = sSql + " order by a.JobID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CSDJob oCSDJob = new CSDJob();
                    oCSDJob.JobID = (int)reader["JobID"];
                    oCSDJob.JobNo = (string)reader["JobNo"];
                    oCSDJob.JobType = (int)reader["JobType"];
                    oCSDJob.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDJob.ProductName = (string)reader["ProductName"];
                    oCSDJob.ASGName = (string)reader["ASGName"];
                    oCSDJob.CustomerName = (string)reader["CustomerName"];
                    oCSDJob.MobileNo = (string)reader["MobileNo"];
                    oCSDJob.TechnicianName = (string)reader["TechnicianName"];
                    oCSDJob.BillAmount = Convert.ToDouble(reader["Amount"].ToString());

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
        public void GetBillList(DateTime dtFromDate, DateTime dtToDate, bool IsChecked, String sBillNo, int nStatus,string sJobNo)
        {
            dtToDate = dtToDate.Date.AddDays(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            if (sJobNo != "")
            {
                sSql = "Select* From " +
                       "( " +
                       "Select a.*, UserName as ReceiveUserName From " +
                       "( " +
                       "Select JobNo, c.BillID, BillNo, BillAmount, SendUserID, d.UserName as SendUserName, " +
                       "SendDate, ReceiveUserID, c.Status, ReceiveDate " +
                       "From t_CSDJobBillSendItem a, t_CSDJob b, t_CSDJobBillSend c, t_user d " +
                       "where a.JobID = b.Jobid and a.BillID = c.BillID and c.SendUserID = d.userid " +
                       ") a " +
                       "left outer join " +
                       "( " +
                       "Select * From t_user " +
                       ") b " +
                       "on a.ReceiveUserID = b.userID " +
                       ") Main where JobNo = '"+ sJobNo + "'";
            }
            else
            {
                sSql = "Select * From  " +
                 "(  " +
                 "Select BillID,BillNo,BillAmount,  " +
                 "SendUserID,a.UserName as SendUserName,  " +
                 "SendDate,ReceiveUserID,c.UserName as ReceiveUserName,ReceiveDate,Status  " +
                 "From   " +
                 "(Select * From t_CSDJobBillSend a,t_User b  " +
                 "where a.SendUserID=b.UserID) a  " +
                 "Left Outer Join   " +
                 "(Select * From t_User) c   " +
                 "on a.ReceiveUserID=c.UserID  " +
                 ") Main where 1=1";
            }
            if (!IsChecked)
            {
                sSql = sSql + " AND SendDate BETWEEN '" + dtFromDate + "'AND '" + dtToDate + "' AND SendDate < '" + dtToDate + "' ";
            }
            if (nStatus != -1)
            {
                sSql = sSql + "  AND Status=" + nStatus + "";
            }
            if (sBillNo != string.Empty)
            {
                sSql = sSql + "  AND BillNo like '%" + sBillNo + "%' ";
            }
            sSql = sSql + " order by BillID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CSDJob oCSDJob = new CSDJob();
                    oCSDJob.BillID = (int)reader["BillID"];
                    oCSDJob.BillNo = (string)reader["BillNo"];
                    oCSDJob.BillAmount = Convert.ToDouble(reader["BillAmount"].ToString());
                    oCSDJob.SendUserName = (string)reader["SendUserName"];
                    oCSDJob.SendDate = Convert.ToDateTime(reader["SendDate"].ToString());
                    if (reader["ReceiveUserName"] != DBNull.Value)
                    {
                        oCSDJob.ReceiveUserName = (string)reader["ReceiveUserName"];
                    }
                    else
                    {
                        oCSDJob.ReceiveUserName = "";
                    }
                    if (reader["ReceiveDate"] != DBNull.Value)
                    {
                        oCSDJob.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());
                    }
                    else
                    {
                        oCSDJob.ReceiveDate = "";
                    }
                    oCSDJob.BillStatus = (int)reader["Status"];


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

        public void GetCSDJobSummeryDateWise(DateTime dtFromDate, DateTime dtToDate, bool IsOtherBrand, bool IsSamsung)
        {
            dtToDate = dtToDate.Date.AddDays(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand(); 

            string sSql = " Select * from DWDB.dbo.t_CSDJobSummeryDateWise where 1=1";
            
              sSql = sSql + " and CreateDate BETWEEN'" + dtFromDate + "'AND '" + dtToDate + "' AND CreateDate < '" + dtToDate + "'";
            if (IsOtherBrand)
            {
                sSql += " AND BrandType Not In('Samsung')";
            }
            if (IsSamsung)
            {
                sSql += " AND BrandType In('Samsung')";
            }

            sSql = sSql + " order by CreateDate ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CSDJob oCSDJob = new CSDJob();
                    oCSDJob.Type = (string)reader["Type"];
                    oCSDJob.JobStatus = (string)reader["JobStatus"];
                    oCSDJob.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDJob.TotalJob = (int)reader["TotalJob"];
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



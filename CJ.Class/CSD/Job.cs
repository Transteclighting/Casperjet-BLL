// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Mar 11, 2013
// Time :  4:26 PM
// Description: Class for CSD Job.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.CSD
{
    public class Job
    {
        private int _nJobID;
        private string _sSerialNo;
        private string _sJobNo;
        private int _nServiceType;
        private int _nJobType;
        private int _nWorkshopID;
        private string _sRefferenceJobNo;
        private int _nPriority;
        private string _ReceivingCounter;
        private DateTime _DeliveryDate;
        private string _Remarks;
        private int _ProductID;
        private int _FullOrAccessories;
        private int _AccessoryID;
        private int _FaultDescriptionID;
        private int _ChannelType;
        private int _OwnOrCustomerSet;
        private int _ChannelID;
        private string _sCustomerName;
        private string _PhoneOffice;
        private string _PhoneHome;
        private string _sMobile;
        private string _sFirstAddress;
        private string _SecondAddress;
        private string _ThirdAddress;
        private string _EMail;
        private int _nJobStatus;
        private DateTime _dJobCreationDate;
        private int _nTechnicianID;
        private int _nCategoryID;
        private int _WorkType;
        private int _WorkCondition;
        private int _ByCurrier;
        private int _ProductTypeID;
        private int _BillStatus;
        private int _ProductLocation;
        private int _SparePartsUsed;
        private int _SendOrReceive;
        private int _SendToCallCenter;
        private int _PendingID;
        private DateTime _TestCompleteDate;
        private int _nThirdPartyID;
        private int _nInterServiceID;
        private int _CarryingCostIn;
        private int _CarryingCostOut;
        private int _ReceiveCourierID;
        private int _SendCourierID;
        private string _WarrantyCardNo;
        private DateTime _RepairedDate;
        private string _FaultFromTech;
        private int _InterSerJobType;
        private int _nIsDelivered;
        private int _nIsReplacement;
        private int _CustomerType;
        private string _CustomerID;
        private string _NationalID;
        private string _CourierCostIn;
        private string _CourierCostOut;
        private DateTime _ConvertionDate;
        private bool _bFlag;

        private string _sProductCode;
        private string _sProductName;


        /// <summary>
        /// Get set property for JobID
        /// </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }
        /// <summary>
        /// Get set property for SerialNo
        /// </summary>
        public string SerialNo
        {
            get { return _sSerialNo; }
            set { _sSerialNo = value.Trim(); }
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
        /// Get set property for RefferenceJobNo
        /// </summary>
        public string RefferenceJobNo
        {
            get { return _sRefferenceJobNo; }
            set { _sRefferenceJobNo = value.Trim(); }
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
        /// Get set property for ReceivingCounter
        /// </summary>
        public string ReceivingCounter
        {
            get { return _ReceivingCounter; }
            set { _ReceivingCounter = value.Trim(); }
        }
        /// <summary>
        /// Get set property for DeliveryDate
        /// </summary>
        public DateTime DeliveryDate
        {
            get { return _DeliveryDate; }
            set { _DeliveryDate = value; }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value.Trim(); }
        }
        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
        /// <summary>
        /// Get set property for FullOrAccessories
        /// </summary>
        public int FullOrAccessories
        {
            get { return _FullOrAccessories; }
            set { _FullOrAccessories = value; }
        }
        /// <summary>
        /// Get set property for AccessoryID
        /// </summary>
        public int AccessoryID
        {
            get { return _AccessoryID; }
            set { _AccessoryID = value; }
        }
        /// <summary>
        /// Get set property for FaultDescriptionID
        /// </summary>
        public int FaultDescriptionID
        {
            get { return _FaultDescriptionID; }
            set { _FaultDescriptionID = value; }
        }
        /// <summary>
        /// Get set property for ChannelType
        /// </summary>
        public int ChannelType
        {
            get { return _ChannelType; }
            set { _ChannelType = value; }
        }
        /// <summary>
        /// Get set property for OwnOrCustomerSet
        /// </summary>
        public int OwnOrCustomerSet
        {
            get { return _OwnOrCustomerSet; }
            set { _OwnOrCustomerSet = value; }
        }
        /// <summary>
        /// Get set property for ChannelID
        /// </summary>
        public int ChannelID
        {
            get { return _ChannelID; }
            set { _ChannelID = value; }
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
        /// Get set property for PhoneOffice
        /// </summary>
        public string PhoneOffice
        {
            get { return _PhoneOffice; }
            set { _PhoneOffice = value.Trim(); }
        }
        /// <summary>
        /// Get set property for PhoneHome
        /// </summary>
        public string PhoneHome
        {
            get { return _PhoneHome; }
            set { _PhoneHome = value.Trim(); }
        }
        /// <summary>
        /// Get set property for Mobile
        /// </summary>
        public string Mobile
        {
            get { return _sMobile; }
            set { _sMobile = value.Trim(); }
        }
        /// <summary>
        /// Get set property for FirstAddress
        /// </summary>
        public string FirstAddress
        {
            get { return _sFirstAddress; }
            set { _sFirstAddress = value.Trim(); }
        }
        /// <summary>
        /// Get set property for SecondAddress
        /// </summary>
        public string SecondAddress
        {
            get { return _SecondAddress; }
            set { _SecondAddress = value.Trim(); }
        }
        /// <summary>
        /// Get set property for ThirdAddress
        /// </summary>
        public string ThirdAddress
        {
            get { return _ThirdAddress; }
            set { _ThirdAddress = value.Trim(); }
        }
        /// <summary>
        /// Get set property for EMail
        /// </summary>
        public string EMail
        {
            get { return _EMail; }
            set { _EMail = value.Trim(); }
        }
        /// <summary>
        /// Get set property for JobStatus
        /// </summary>
        public int JobStatus
        {
            get { return _nJobStatus; }
            set { _nJobStatus = value; }
        }
        /// <summary>
        /// Get set property for JobCreationDate
        /// </summary>
        public DateTime JobCreationDate
        {
            get { return _dJobCreationDate; }
            set { _dJobCreationDate = value; }
        }
        /// <summary>
        /// Get set property for TechnicianID
        /// </summary>
        public int TechnicianID
        {
            get { return _nTechnicianID; }
            set { _nTechnicianID = value; }
        }
        /// <summary>
        /// Get set property for CategoryID
        /// </summary>
        public int CategoryID
        {
            get { return _nCategoryID; }
            set { _nCategoryID = value; }
        }
        /// <summary>
        /// Get set property for WorkType
        /// </summary>
        public int WorkType
        {
            get { return _WorkType; }
            set { _WorkType = value; }
        }
        /// <summary>
        /// Get set property for WorkCondition
        /// </summary>
        public int WorkCondition
        {
            get { return _WorkCondition; }
            set { _WorkCondition = value; }
        }
        /// <summary>
        /// Get set property for ByCurrier
        /// </summary>
        public int ByCurrier
        {
            get { return _ByCurrier; }
            set { _ByCurrier = value; }
        }
        /// <summary>
        /// Get set property for ProductTypeID
        /// </summary>
        public int ProductTypeID
        {
            get { return _ProductTypeID; }
            set { _ProductTypeID = value; }
        }
        /// <summary>
        /// Get set property for BillStatus
        /// </summary>
        public int BillStatus
        {
            get { return _BillStatus; }
            set { _BillStatus = value; }
        }
        /// <summary>
        /// Get set property for ProductLocation
        /// </summary>
        public int ProductLocation
        {
            get { return _ProductLocation; }
            set { _ProductLocation = value; }
        }
        /// <summary>
        /// Get set property for SparePartsUsed
        /// </summary>
        public int SparePartsUsed
        {
            get { return _SparePartsUsed; }
            set { _SparePartsUsed = value; }
        }
        /// <summary>
        /// Get set property for SendOrReceive
        /// </summary>
        public int SendOrReceive
        {
            get { return _SendOrReceive; }
            set { _SendOrReceive = value; }
        }
        /// <summary>
        /// Get set property for SendToCallCenter
        /// </summary>
        public int SendToCallCenter
        {
            get { return _SendToCallCenter; }
            set { _SendToCallCenter = value; }
        }
        /// <summary>
        /// Get set property for PendingID
        /// </summary>
        public int PendingID
        {
            get { return _PendingID; }
            set { _PendingID = value; }
        }
        /// <summary>
        /// Get set property for TestCompleteDate
        /// </summary>
        public DateTime TestCompleteDate
        {
            get { return _TestCompleteDate; }
            set { _TestCompleteDate = value; }
        }
        /// <summary>
        /// Get set property for ThirdPartyID
        /// </summary>
        public int ThirdPartyID
        {
            get { return _nThirdPartyID; }
            set { _nThirdPartyID = value; }
        }
        /// <summary>
        /// Get set property for InterServiceID
        /// </summary>
        public int InterServiceID
        {
            get { return _nInterServiceID; }
            set { _nInterServiceID = value; }
        }
        /// <summary>
        /// Get set property for CarryingCostIn
        /// </summary>
        public int CarryingCostIn
        {
            get { return _CarryingCostIn; }
            set { _CarryingCostIn = value; }
        }
        /// <summary>
        /// Get set property for CarryingCostOut
        /// </summary>
        public int CarryingCostOut
        {
            get { return _CarryingCostOut; }
            set { _CarryingCostOut = value; }
        }
        /// <summary>
        /// Get set property for ReceiveCourierID
        /// </summary>
        public int ReceiveCourierID
        {
            get { return _ReceiveCourierID; }
            set { _ReceiveCourierID = value; }
        }
        /// <summary>
        /// Get set property for SendCourierID
        /// </summary>
        public int SendCourierID
        {
            get { return _SendCourierID; }
            set { _SendCourierID = value; }
        }
        /// <summary>
        /// Get set property for WarrantyCardNo
        /// </summary>
        public string WarrantyCardNo
        {
            get { return _WarrantyCardNo; }
            set { _WarrantyCardNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for RepairedDate
        /// </summary>
        public DateTime RepairedDate
        {
            get { return _RepairedDate; }
            set { _RepairedDate = value; }
        }
        /// <summary>
        /// Get set property for FaultFromTech
        /// </summary>
        public string FaultFromTech
        {
            get { return _FaultFromTech; }
            set { _FaultFromTech = value.Trim(); }
        }
        /// <summary>
        /// Get set property for InterSerJobType
        /// </summary>
        public int InterSerJobType
        {
            get { return _InterSerJobType; }
            set { _InterSerJobType = value; }
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
        /// Get set property for CustomerType
        /// </summary>
        public int CustomerType
        {
            get { return _CustomerType; }
            set { _CustomerType = value; }
        }
        /// <summary>
        /// Get set property for CustomerID
        /// </summary>
        public string CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value.Trim(); }
        }
        /// <summary>
        /// Get set property for NationalID
        /// </summary>
        public string NationalID
        {
            get { return _NationalID; }
            set { _NationalID = value.Trim(); }
        }
        /// <summary>
        /// Get set property for CourierCostIn
        /// </summary>
        public string CourierCostIn
        {
            get { return _CourierCostIn; }
            set { _CourierCostIn = value.Trim(); }
        }
        /// <summary>
        /// Get set property for CourierCostOut
        /// </summary>
        public string CourierCostOut
        {
            get { return _CourierCostOut; }
            set { _CourierCostOut = value.Trim(); }
        }
        /// <summary>
        /// Get set property for ConvertionDate
        /// </summary>
        public DateTime ConvertionDate
        {
            get { return _ConvertionDate; }
            set { _ConvertionDate = value; }
        }
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }



        /// <summary>
        /// Get set property for ProductCode
        /// </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        /// <summary>
        /// Get set property for ProductName
        /// </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }

        public void RefreshByJob()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * from TELServiceDB.dbo.Job where JobNo=?";

                cmd.Parameters.AddWithValue("JobNo", _sJobNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nJobID = (int)reader["JobID"];
                    _sJobNo = (string)reader["JobNo"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _sFirstAddress = (string)reader["FirstAddress"];
                    _sMobile = (string)reader["Mobile"];
                    _dJobCreationDate = Convert.ToDateTime(reader["JobCreationDate"].ToString());

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                _bFlag = true;
            else _bFlag = false;
        }

    }
    public class Jobs : CollectionBase
    {
        public Job this[int i]
        {
            get { return (Job)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Job oJob)
        {
            InnerList.Add(oJob);
        }

        public void RefreshJob(String txtJobNo, String txtCustomerName, String txtContactNo, String txtProductName, String txtProductCode)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select JobID,JobNo,CustomerName,Mobile,P.name ProductName, FirstAddress,P.Code ProductCode from TELServiceDB.dbo.Job J  " +
                          "INNER JOIN TELServiceDB.dbo.Product P " +
                          "ON J.ProductID=P.ProductID ";


            if (txtJobNo != "")
            {
                txtJobNo = "%" + txtJobNo + "%";
                sSql = sSql + " AND JobNo LIKE '" + txtJobNo + "'";
            }
            if (txtCustomerName != "")
            {
                txtCustomerName = "%" + txtCustomerName + "%";
                sSql = sSql + " AND CustomerName LIKE '" + txtCustomerName + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND Mobile LIKE '" + txtContactNo + "'";
            }
            if (txtProductName != "")
            {
                txtProductName = "%" + txtProductName + "%";
                sSql = sSql + " AND P.name LIKE '" + txtProductName + "'";
            }
            if (txtProductCode != "")
            {
                txtProductCode = "%" + txtProductCode + "%";
                sSql = sSql + " AND P.Code LIKE '" + txtProductCode + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Job oJob = new Job();

                    oJob.JobID = (int)reader["JobID"];
                    oJob.JobNo = (string)reader["JobNo"];
                    oJob.CustomerName = (string)reader["CustomerName"];
                    oJob.Mobile = (string)reader["Mobile"];
                    oJob.ProductName = (string)reader["ProductName"];
                    oJob.ProductCode = (string)reader["ProductCode"];
                    oJob.FirstAddress = (string)reader["FirstAddress"];


                    InnerList.Add(oJob);
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



// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Jul 15, 2012
// Time :  12:41 PM
// Description: Class for Vehicle Schedule Data.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class.CSD;

namespace CJ.Class
{
    public class VehicleSchedule
    {


        private int _nVRID;
        private Object _nJobID;
        private Object _sCustomerName;
        private Object _sAddress;
        private Object _sLocation;
        private Object _sContactNo;
        private int _nJobType;
        private Object _nProductID;
        private int _nReqType;
        private Object _sRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private Object _dExpectedDate;
        private Object _dExpectedTimeFrom;
        private Object _dExpectedTimeTo;
        private Object _dScheduleDate;
        private Object _dScheduleTimeFrom;
        private Object _dScheduleTimeTo;
        private int _nStatus;
        private int _nIsNoJob;
        private int _nContactForDateTime;

        private Object _dFirstScheduleDate;
        private Object _dFirstScheduleTimeFrom;
        private Object _dFirstScheduleTimeTo;
        private int _nByVehicle;
        private int _nSuspendReasonID;
        private Object _sDeliveryMan;

        private Object _sJobNo;
        private Object _sProductCode;
        private Object _sStatusName;
        private string _sCreatedBy;


        private Object _sScheduleRemarks;
        private Object _sReScheduleRemarks;
        private Object _sDoneRemarks;
        private Object _sPendingRemarks;
        private Object _sCancelRemarks;
        private Object _sSuspendReason;
        private Object _sVehicleName;
        private Object _sProductName;
        private Object _sJobTypeName;
        private Object _sReqName;
        private Object _dSD1;
        private Object _dSDTF1;
        private Object _dSDTT1;

        private int _nJobLocationId;


        private User _oUser;
        private ReplaceJobFromCassandra _oReplaceJobFromCassandra;
        private int _nType;

        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }

        public int JobLocationId
        {
            get { return _nJobLocationId; }
            set { _nJobLocationId = value; }
        }

        /// <summary>
        /// Get set property for VRID
        /// </summary>
        public int VRID
        {
            get { return _nVRID; }
            set { _nVRID = value; }
        }
        /// <summary>
        /// Get set property for JobID
        /// </summary>
        public Object JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }
        /// <summary>
        /// Get set property for CustomerName
        /// </summary>
        public Object CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        /// <summary>
        /// Get set property for Contact Address
        /// </summary>
        public Object Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }
        /// <summary>
        /// Get set property for Location
        /// </summary>
        public Object Location
        {
            get { return _sLocation; }
            set { _sLocation = value; }
        }
        /// <summary>
        /// Get set property for ContactNo
        /// </summary>
        public Object ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value; }
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
        /// Get set property for ProductID
        /// </summary>
        public Object ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        /// <summary>
        /// Get set property for ReqType
        /// </summary>
        public int ReqType
        {
            get { return _nReqType; }
            set { _nReqType = value; }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public Object Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
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
        /// Get set property for ExpectedDate
        /// </summary>
        public Object ExpectedDate
        {
            get { return _dExpectedDate; }
            set { _dExpectedDate = value; }
        }
        /// <summary>
        /// Get set property for ExpectedTimeFrom
        /// </summary>
        public Object ExpectedTimeFrom
        {
            get { return _dExpectedTimeFrom; }
            set { _dExpectedTimeFrom = value; }
        }
        /// <summary>
        /// Get set property for ExpectedTimeTo
        /// </summary>
        public Object ExpectedTimeTo
        {
            get { return _dExpectedTimeTo; }
            set { _dExpectedTimeTo = value; }
        }
        /// <summary>
        /// Get set property for ScheduleDate
        /// </summary>
        public Object ScheduleDate
        {
            get { return _dScheduleDate; }
            set { _dScheduleDate = value; }
        }
        /// <summary>
        /// Get set property for ScheduleTimeFrom
        /// </summary>
        public Object ScheduleTimeFrom
        {
            get { return _dScheduleTimeFrom; }
            set { _dScheduleTimeFrom = value; }
        }
        /// <summary>
        /// Get set property for ScheduleTimeTo
        /// </summary>
        public Object ScheduleTimeTo
        {
            get { return _dScheduleTimeTo; }
            set { _dScheduleTimeTo = value; }
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
        /// Get set property for IsNoJob
        /// </summary>
        public int IsNoJob
        {
            get { return _nIsNoJob; }
            set { _nIsNoJob = value; }
        }
        /// <summary>
        /// Get set property for ContactForDateTime
        /// </summary>
        public int ContactForDateTime
        {
            get { return _nContactForDateTime; }
            set { _nContactForDateTime = value; }
        }

     
        /// <summary>
        /// Get set property for FirstScheduleDate
        /// </summary>
        public Object FirstScheduleDate
        {
            get { return _dFirstScheduleDate; }
            set { _dFirstScheduleDate = value; }
        }
        /// <summary>
        /// Get set property for FirstScheduleTimeFrom
        /// </summary>
        public Object FirstScheduleTimeFrom
        {
            get { return _dFirstScheduleTimeFrom; }
            set { _dFirstScheduleTimeFrom = value; }
        }
        /// <summary>
        /// Get set property for FirstScheduleTimeTo
        /// </summary>
        public Object FirstScheduleTimeTo
        {
            get { return _dFirstScheduleTimeTo; }
            set { _dFirstScheduleTimeTo = value; }
        }
        /// <summary>
        /// Get set property for ByVehicle
        /// </summary>
        public int ByVehicle
        {
            get { return _nByVehicle; }
            set { _nByVehicle = value; }
        }
        /// <summary>
        /// Get set property for SuspendReasonID
        /// </summary>
        public int SuspendReasonID
        {
            get { return _nSuspendReasonID; }
            set { _nSuspendReasonID = value; }
        }
        /// <summary>
        /// Get set property for DeliveryMan
        /// </summary>
        public Object DeliveryMan
        {
            get { return _sDeliveryMan; }
            set { _sDeliveryMan = value; }
        }


        /// <summary>
        /// Get set property for JobNo
        /// </summary>
        public Object JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value; }
        }
        /// <summary>
        /// Get set property for ProductCode
        /// </summary>
        public Object ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        /// <summary>
        /// Get set property for StatusName
        /// </summary>
        public Object StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value; }
        }
        /// <summary>
        /// Get set property for CreatedBy
        /// </summary>
        public string CreatedBy
        {
            get { return _sCreatedBy; }
            set { _sCreatedBy = value; }
        }


        /// <summary>
        /// Get set property for ScheduleRemarks
        /// </summary>
        public Object ScheduleRemarks
        {
            get { return _sScheduleRemarks; }
            set { _sScheduleRemarks = value; }
        }
        /// <summary>
        /// Get set property for ReScheduleRemarks
        /// </summary>
        public Object ReScheduleRemarks
        {
            get { return _sReScheduleRemarks; }
            set { _sReScheduleRemarks = value; }
        }
        /// <summary>
        /// Get set property for DoneRemarks
        /// </summary>
        public Object DoneRemarks
        {
            get { return _sDoneRemarks; }
            set { _sDoneRemarks = value; }
        }
        /// <summary>
        /// Get set property for PendingRemarks
        /// </summary>
        public Object PendingRemarks
        {
            get { return _sPendingRemarks; }
            set { _sPendingRemarks = value; }
        }
        /// <summary>
        /// Get set property for CancelRemarks
        /// </summary>
        public Object CancelRemarks
        {
            get { return _sCancelRemarks; }
            set { _sCancelRemarks = value; }
        }
        /// <summary>
        /// Get set property for SuspendReason
        /// </summary>
        public Object SuspendReason
        {
            get { return _sSuspendReason; }
            set { _sSuspendReason = value; }
        }
        /// <summary>
        /// Get set property for VehicleName
        /// </summary>
        public Object VehicleName
        {
            get { return _sVehicleName; }
            set { _sVehicleName = value; }
        }
        /// <summary>
        /// Get set property for ProductName
        /// </summary>
        public Object ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        /// <summary>
        /// Get set property for JobTypeName
        /// </summary>
        public Object JobTypeName
        {
            get { return _sJobTypeName; }
            set { _sJobTypeName = value; }
        }
        /// <summary>
        /// Get set property for ReqName
        /// </summary>
        public Object ReqName
        {
            get { return _sReqName; }
            set { _sReqName = value; }
        }
        /// <summary>
        /// Get set property for SD1
        /// </summary>
        public Object SD1
        {
            get { return _dSD1; }
            set { _dSD1 = value; }
        }
        /// <summary>
        /// Get set property for SDTF1
        /// </summary>
        public Object SDTF1
        {
            get { return _dSDTF1; }
            set { _dSDTF1 = value; }
        }
        /// <summary>
        /// Get set property for SDTT1
        /// </summary>
        public Object SDTT1
        {
            get { return _dSDTT1; }
            set { _dSDTT1 = value; }
        }


        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                }
                return _oUser;
            }
        }
        public ReplaceJobFromCassandra ReplaceJobFromCassandra
        {
            get
            {
                if (_oReplaceJobFromCassandra == null)
                {
                    _oReplaceJobFromCassandra = new ReplaceJobFromCassandra();
                    //_oReplaceJobFromCassandra.JobID = _nJobID;
                    //_oReplaceJobFromCassandra.RefreshByJobNo();

                }
                return _oReplaceJobFromCassandra;
            }
        }

        public void Add()
        {
            int nMaxVRID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([VRID]) FROM t_CSDVehicleRequisition";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxVRID = 1;
                }
                else
                {
                    nMaxVRID = Convert.ToInt32(maxID) + 1;
                }
                _nVRID = nMaxVRID;


                sSql = "INSERT INTO t_CSDVehicleRequisition(VRID,Type,JobID,CustomerName,"
                    + " Address,Location,ContactNo,JobType,ProductID,ReqType,"
                    + " Remarks,CreateUserID,CreateDate,ExpectedDate,ExpectedTimeFrom,ExpectedTimeTo,Status,IsNoJob,"
                    + " ContactForDateTime, JobLocationId"
                    + " ) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VRID", _nVRID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Location", _sLocation);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("JobType", _nJobType);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ReqType", _nReqType);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("ExpectedDate", _dExpectedDate);
                cmd.Parameters.AddWithValue("ExpectedTimeFrom", _dExpectedTimeFrom);
                cmd.Parameters.AddWithValue("ExpectedTimeTo", _dExpectedTimeTo);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.VehicleRequisitionStatus.Requisition);
                cmd.Parameters.AddWithValue("IsNoJob", _nIsNoJob);
                cmd.Parameters.AddWithValue("ContactForDateTime", _nContactForDateTime);
                cmd.Parameters.AddWithValue("JobLocationId", _nJobLocationId);
                //cmd.Parameters.AddWithValue("ByVehicle", -9);
                //cmd.Parameters.AddWithValue("SuspendReasonID", -9);

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

            try
            {

                cmd.CommandText = "UPDATE t_CSDVehicleRequisition SET JobID=?,CustomerName=?,"
                    + " Address=?,Location=?,ContactNo=?,JobType=?,"
                    + " ProductID=?, ReqType=?,Remarks=?,ExpectedDate=?,ExpectedTimeFrom=?,"
                    + " ExpectedTimeTo=?, IsNoJob=?, ContactForDateTime=? WHERE VRID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Location", _sLocation);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("JobType", _nJobType);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ReqType", _nReqType);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("ExpectedDate", _dExpectedDate);
                cmd.Parameters.AddWithValue("ExpectedTimeFrom", _dExpectedTimeFrom);
                cmd.Parameters.AddWithValue("ExpectedTimeTo", _dExpectedTimeTo);
                cmd.Parameters.AddWithValue("IsNoJob", _nIsNoJob);
                cmd.Parameters.AddWithValue("ContactForDateTime", _nContactForDateTime);


                cmd.Parameters.AddWithValue("VRID", _nVRID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateSchedulePreparation()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDVehicleRequisition SET ScheduleDate=?,ScheduleTimeFrom=?,ScheduleTimeTo=?,Status=?,"
                + "FirstScheduleDate=?,FirstScheduleTimeFrom=?,FirstScheduleTimeTo=? WHERE VRID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ScheduleDate",_dScheduleDate);
                cmd.Parameters.AddWithValue("ScheduleTimeFrom",_dScheduleTimeFrom);
                cmd.Parameters.AddWithValue("ScheduleTimeTo",_dScheduleTimeTo);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.VehicleRequisitionStatus.Schedule);
                cmd.Parameters.AddWithValue("FirstScheduleDate", _dFirstScheduleDate);
                cmd.Parameters.AddWithValue("FirstScheduleTimeFrom", _dFirstScheduleTimeFrom);
                cmd.Parameters.AddWithValue("FirstScheduleTimeTo",_dFirstScheduleTimeTo);

                cmd.Parameters.AddWithValue("VRID", _nVRID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateReSchedulePreparation()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDVehicleRequisition SET ScheduleDate=?,ScheduleTimeFrom=?,ScheduleTimeTo=?,Status=? WHERE VRID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ScheduleDate", _dScheduleDate);
                cmd.Parameters.AddWithValue("ScheduleTimeFrom", _dScheduleTimeFrom);
                cmd.Parameters.AddWithValue("ScheduleTimeTo", _dScheduleTimeTo);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.VehicleRequisitionStatus.ReSchedule);

                cmd.Parameters.AddWithValue("VRID", _nVRID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateScheduleDone()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDVehicleRequisition SET ScheduleDate=?,ScheduleTimeFrom=?,ScheduleTimeTo=?,Status=?,ByVehicle=?,DeliveryMan=? WHERE VRID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ScheduleDate", _dScheduleDate);
                cmd.Parameters.AddWithValue("ScheduleTimeFrom", _dScheduleTimeFrom);
                cmd.Parameters.AddWithValue("ScheduleTimeTo", _dScheduleTimeTo);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.VehicleRequisitionStatus.Done);
                cmd.Parameters.AddWithValue("ByVehicle", _nByVehicle);
                cmd.Parameters.AddWithValue("DeliveryMan", _sDeliveryMan);

                cmd.Parameters.AddWithValue("VRID", _nVRID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateScheduleCancel()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDVehicleRequisition SET Status=? WHERE VRID=?";
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Status", (int)Dictionary.VehicleRequisitionStatus.Cancel);

                cmd.Parameters.AddWithValue("VRID", _nVRID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateScheduleSuspend()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDVehicleRequisition SET Status=?,SuspendReasonID=?,ScheduleDate=?,ScheduleTimeFrom=?,ScheduleTimeTo=? WHERE VRID=?";
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Status", (int)Dictionary.VehicleRequisitionStatus.Suspend);
                cmd.Parameters.AddWithValue("SuspendReasonID", _nSuspendReasonID);
                cmd.Parameters.AddWithValue("ScheduleDate", _dScheduleDate);
                cmd.Parameters.AddWithValue("ScheduleTimeFrom", _dScheduleTimeFrom);
                cmd.Parameters.AddWithValue("ScheduleTimeTo", _dScheduleTimeTo);

                cmd.Parameters.AddWithValue("VRID", _nVRID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    
        public void RefreshUser()
        {
            User.UserId = _nCreateUserID;
            User.RefreshByUserID();
        }
    }

    public class VehicleSchedules : CollectionBase
    {
        public VehicleSchedule this[int i]
        {
            get { return (VehicleSchedule)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(VehicleSchedule oVehicleSchedule)
        {
            InnerList.Add(oVehicleSchedule);
        }

        public void Refresh(DateTime dtFromDate, DateTime dtToDate, DateTime dtFromDate1, DateTime dtToDate1, DateTime dtFromDate2, DateTime dtToDate2, int nStatus, int nReqType, String txtID, String txtJobNo, String txtContactNo, String txtCustomerName, String txtLocation) 
        {
            dtToDate = dtToDate.Date.AddDays(1);
            dtToDate1 = dtToDate1.Date.AddDays(1);
            dtToDate2 = dtToDate2.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select VRID, JobNo,CustomerName,Address,Location,ContactNo,ProductCode,ProductName,JobType, " +
                          "JobTypeName,ReqType,ReqName,Remarks,CreateUser,CD,ExpectedDate, ED,EDTF,EDTT,ScheduleDate,IsNull(SD,GetDate())SD, SD SD1, " +
                          "IsNull(SDTF,GetDate())SDTF, SDTF SDTF1, IsNull(SDTT,GetDate())SDTT, SDTT SDTT1, " +
                          "Status,StatusName,IsNoJob,ContactForDateTime, " +
                          "ScheduleRemarks, ReScheduleRemarks, DoneRemarks, PendingRemarks, CancelRemarks, " +
                          "SuspendReasonID,SuspendReason, ByVehicle,VehicleName,DeliveryMan " +
                          "from " +
                          "( " +
                          "Select VR.VRID VRID,IsNull(JobNo,'--')JobNo, IsNull(J.CustomerName,VR.CustomerName)CustomerName, " +
                          "IsNull(FirstAddress,Address)Address,Location,IsNull(Mobile,ContactNo)ContactNo, " +
                          "IsNull(P.Code,PD.ProductCode)ProductCode,IsNull(P.Name,PD.ProductName)ProductName, " +
                          "IsNull(J.JobType,VR.JobType)JobType, JobTypeName=Case  " +
                          "When IsNull(J.JobType,VR.JobType)=1 Then 'FullWarranty' " +
                          "When IsNull(J.JobType,VR.JobType)=2 Then 'Paid' " +
                          "When IsNull(J.JobType,VR.JobType)=3 Then 'ServiceWarranty' " +
                          "else 'Others' end,ReqType, ReqName=CASE When ReQType=1 Then 'Pick-Up' When ReQType=2 Then 'Drop' else 'Others' End, " +
                          "VR.Remarks,CreateUserID,U.UserName CreateUser,VR.CreateDate CD, ExpectedDate, " +
                          "RTRIM(RIGHT(CONVERT(varchar, ExpectedDate, 105),11)) ED, " +
                          "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeFrom, 100),7))EDTF, " +
                          "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeTo, 100),7))EDTT, " +
                          "VR.Status Status, " +
                          "StatusName=CASE When VR.Status=0 then 'Requisition' " +
                          "When VR.Status=1 then 'Schedule' " +
                          "When VR.Status=2 then 'ReSchedule' " +
                          "When VR.Status=3 then 'Done' " +
                          "When VR.Status=4 then 'Suspend' " +
                          "When VR.Status=5 then 'Cancel' " +
                          "else 'Others' end, IsNoJob,ContactForDateTime,ScheduleDate, " +
                          "RTRIM(RIGHT(CONVERT(varchar, ScheduleDate, 105),11)) SD, " +
                          "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeFrom, 100),7))SDTF, " +
                          "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeTo, 100),7))SDTT, " +
                          "IsNull(VRHSCH.Remarks,'')ScheduleRemarks, IsNull(VRHRSCH.Remarks,'')ReScheduleRemarks, " +
                          "IsNull(VRHDone.Remarks,'')DoneRemarks,IsNull(VRHPen.Remarks,'')PendingRemarks, " +
                          "IsNull(VRHCan.Remarks,'')CancelRemarks, IsNull(SuspendReasonID,0)SuspendReasonID, " +
                          "IsNull(ByVehicle,0)ByVehicle,DeliveryMan, " +
                          "SuspendReason=CASE When SuspendReasonID = 0 Then 'ScheduleNotMatched' " +
                          "When SuspendReasonID = 1 Then 'CustomerWillInfoLater' " +
                          "else 'Others' end, " +
                          "VehicleName=CASE When ByVehicle = 0 Then 'CSD-Covered Van' " +
                          "When ByVehicle = 1 Then 'CSD-Micro Bus' " +
                          "When ByVehicle = 2 Then 'Log-Vehicle' " +
                          "When ByVehicle = 3 Then 'TD-Vehicle' " +
                          "When ByVehicle = 4 Then 'Admin-Vehicle' " +
                          "When ByVehicle = 5 Then 'Rental-Vehicle' " +
                          "When ByVehicle = 6  Then 'Others' " +
                          "else 'Nothings' end " +
                          "From t_CSDVehicleRequisition VR " +
                          "Left Outer Join TELServiceDB.dbo.Job J " +
                          "ON J.JobID=VR.JobID " +
                          "Left Outer Join TELServiceDB.dbo.Product P " +
                          "ON P.ProductID=J.ProductID " +
                          "INNER JOIN t_User U " +
                          "ON U.UserID=VR.CreateUserID " +
                          "Left OUter JOIN v_ProductDetails PD " +
                          "ON PD.ProductID=VR.ProductID " +
                          "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=1) VRHSCH " +
                          "ON VR.VRID=VRHSCH.VRID " +
                          "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=2) VRHRSCH " +
                          "ON VR.VRID=VRHRSCH.VRID " +
                          "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=3) VRHDone " +
                          "ON VR.VRID=VRHDone.VRID " +
                          "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=4) VRHPen " +
                          "ON VR.VRID=VRHPen.VRID " +
                          "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=5) VRHCan " +
                          "ON VR.VRID=VRHCan.VRID " +
                          ")A " +
                          "Where CD BETWEEN'" + dtFromDate + "'AND '" + dtToDate + "' AND CD < '" + dtToDate + "'" +
                          "AND ScheduleDate BETWEEN'" + dtFromDate1 + "'AND '" + dtToDate1 + "' AND ScheduleDate < '" + dtToDate1 + "'" +
                          "AND ExpectedDate BETWEEN'" + dtFromDate2 + "'AND '" + dtToDate2 + "' AND ExpectedDate < '" + dtToDate2 + "'";


             if (nStatus > -1)
             {
                 sSql = sSql + "AND Status ='" + nStatus + "'";
             }
             if (nReqType > -0)
             {
                 sSql = sSql + "AND ReqType ='" + nReqType + "'";
             }
             if (txtID != "")
             {
                 sSql = sSql + " AND VRID = '" + txtID + "'";
             }
             if (txtJobNo != "")
             {
                 txtJobNo = "%" + txtJobNo + "%";
                 sSql = sSql + " AND JobNo LIKE '" + txtJobNo + "'";
             }
             if (txtContactNo != "")
             {
                 txtContactNo = "%" + txtContactNo + "%";
                 sSql = sSql + " AND ContactNo LIKE '" + txtContactNo + "'";
             }
             if (txtCustomerName != "")
             {
                 txtCustomerName = "%" + txtCustomerName + "%";
                 sSql = sSql + " AND CustomerName LIKE '" + txtCustomerName + "'";
             }
             if (txtLocation != "")
             {
                 txtLocation = "%" + txtLocation + "%";
                 sSql = sSql + " AND Location LIKE '" + txtLocation + "'";
             }
             sSql = sSql + " order by VRID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VehicleSchedule oVehicleSchedule = new VehicleSchedule();

                    oVehicleSchedule.VRID = (int)reader["VRID"];
                    oVehicleSchedule.JobNo = (Object)reader["JobNo"].ToString();
                    oVehicleSchedule.ProductCode = (Object)reader["ProductCode"].ToString();
                    oVehicleSchedule.CustomerName = (Object)reader["CustomerName"].ToString();
                    oVehicleSchedule.ContactNo = (Object)reader["ContactNo"].ToString();
                    oVehicleSchedule.Address = (Object)reader["Address"].ToString();
                    oVehicleSchedule.IsNoJob = int.Parse(reader["IsNoJob"].ToString());
                    oVehicleSchedule.ContactForDateTime = int.Parse(reader["ContactForDateTime"].ToString());
                    oVehicleSchedule.JobType = int.Parse(reader["JobType"].ToString());
                    oVehicleSchedule.Location = (Object)reader["Location"].ToString();
                    oVehicleSchedule.ReqType = int.Parse(reader["ReqType"].ToString());
                    oVehicleSchedule.Remarks = (Object)reader["Remarks"].ToString();
                    oVehicleSchedule.Status = int.Parse(reader["Status"].ToString());
                    oVehicleSchedule.StatusName = (object)reader["StatusName"].ToString();
                    oVehicleSchedule.CreatedBy = (string)reader["CreateUser"];
                    oVehicleSchedule.CreateDate = Convert.ToDateTime(reader["CD"].ToString());
                    oVehicleSchedule.ExpectedDate = (Object)reader["ED"].ToString();
                    oVehicleSchedule.ExpectedTimeFrom = (Object)reader["EDTF"].ToString();
                    oVehicleSchedule.ExpectedTimeTo = (Object)reader["EDTT"].ToString();
                    oVehicleSchedule.ScheduleDate = (Object)reader["SD"].ToString();
                    oVehicleSchedule.ScheduleTimeFrom = (Object)reader["SDTF"].ToString();
                    oVehicleSchedule.ScheduleTimeTo = (Object)reader["SDTT"].ToString();
                    oVehicleSchedule.ScheduleRemarks = (Object)reader["ScheduleRemarks"].ToString();
                    oVehicleSchedule.ReScheduleRemarks = (Object)reader["ReScheduleRemarks"].ToString();
                    oVehicleSchedule.DoneRemarks = (Object)reader["DoneRemarks"].ToString();
                    oVehicleSchedule.PendingRemarks = (Object)reader["PendingRemarks"].ToString();
                    oVehicleSchedule.CancelRemarks = (Object)reader["CancelRemarks"].ToString();
                    oVehicleSchedule.SuspendReasonID = int.Parse(reader["SuspendReasonID"].ToString());
                    //oVehicleSchedule.ByVehicle = int.Parse(reader["ByVehicle"].ToString());
                    oVehicleSchedule.ByVehicle = (int)reader["ByVehicle"];
                    oVehicleSchedule.DeliveryMan = (Object)reader["DeliveryMan"].ToString();
                    oVehicleSchedule.SuspendReason = (Object)reader["SuspendReason"].ToString();
                    oVehicleSchedule.VehicleName = (Object)reader["VehicleName"].ToString();
                    oVehicleSchedule.ProductName = (Object)reader["ProductName"].ToString();
                    oVehicleSchedule.JobTypeName = (Object)reader["JobTypeName"].ToString();
                    oVehicleSchedule.ReqName = (Object)reader["ReqName"].ToString();
                    oVehicleSchedule.SD1 = (Object)reader["SD1"].ToString();
                    oVehicleSchedule.SDTF1 = (Object)reader["SDTF1"].ToString();
                    oVehicleSchedule.SDTT1 = (Object)reader["SDTT1"].ToString();

                    oVehicleSchedule.RefreshUser();
                    InnerList.Add(oVehicleSchedule);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshOnlyCD(DateTime dtFromDate, DateTime dtToDate, int nStatus, int nReqType, String txtID, String txtJobNo, String txtContactNo, String txtCustomerName, String txtLocation)
        {
            dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select VRID, JobNo,CustomerName,Address,Location,ContactNo,ProductCode,ProductName,JobType, " +
                           "JobTypeName,ReqType,ReqName,Remarks,CreateUser,CD,ExpectedDate, ED,EDTF,EDTT,ScheduleDate,IsNull(SD,GetDate())SD, SD SD1, " +
                           "IsNull(SDTF,GetDate())SDTF, SDTF SDTF1, IsNull(SDTT,GetDate())SDTT, SDTT SDTT1, " +
                           "Status,StatusName,IsNoJob,ContactForDateTime, " +
                           "ScheduleRemarks, ReScheduleRemarks, DoneRemarks, PendingRemarks, CancelRemarks, " +
                           "SuspendReasonID,SuspendReason, ByVehicle,VehicleName,DeliveryMan " +
                           "from " +
                           "( " +
                           "Select VR.VRID VRID,IsNull(JobNo,'--')JobNo, IsNull(J.CustomerName,VR.CustomerName)CustomerName, " +
                           "IsNull(FirstAddress,Address)Address,Location,IsNull(Mobile,ContactNo)ContactNo, " +
                           "IsNull(P.Code,PD.ProductCode)ProductCode,IsNull(P.Name,PD.ProductName)ProductName, " +
                           "IsNull(J.JobType,VR.JobType)JobType, JobTypeName=Case  " +
                           "When IsNull(J.JobType,VR.JobType)=1 Then 'FullWarranty' " +
                           "When IsNull(J.JobType,VR.JobType)=2 Then 'Paid' " +
                           "When IsNull(J.JobType,VR.JobType)=3 Then 'ServiceWarranty' " +
                           "else 'Others' end,ReqType, ReqName=CASE When ReQType=1 Then 'Pick-Up' When ReQType=2 Then 'Drop' else 'Others' End, " +
                           "VR.Remarks,CreateUserID,U.UserName CreateUser,VR.CreateDate CD, ExpectedDate, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedDate, 105),11)) ED, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeFrom, 100),7))EDTF, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeTo, 100),7))EDTT, " +
                           "VR.Status Status, " +
                           "StatusName=CASE When VR.Status=0 then 'Requisition' " +
                           "When VR.Status=1 then 'Schedule' " +
                           "When VR.Status=2 then 'ReSchedule' " +
                           "When VR.Status=3 then 'Done' " +
                           "When VR.Status=4 then 'Suspend' " +
                           "When VR.Status=5 then 'Cancel' " +
                           "else 'Others' end, IsNoJob,ContactForDateTime,ScheduleDate, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleDate, 105),11)) SD, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeFrom, 100),7))SDTF, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeTo, 100),7))SDTT, " +
                           "IsNull(VRHSCH.Remarks,'')ScheduleRemarks, IsNull(VRHRSCH.Remarks,'')ReScheduleRemarks, " +
                           "IsNull(VRHDone.Remarks,'')DoneRemarks,IsNull(VRHPen.Remarks,'')PendingRemarks, " +
                           "IsNull(VRHCan.Remarks,'')CancelRemarks, IsNull(SuspendReasonID,0)SuspendReasonID, " +
                           "IsNull(ByVehicle,0)ByVehicle,DeliveryMan, " +
                           "SuspendReason=CASE When SuspendReasonID = 0 Then 'ScheduleNotMatched' " +
                           "When SuspendReasonID = 1 Then 'CustomerWillInfoLater' " +
                           "else 'Others' end, " +
                           "VehicleName=CASE When ByVehicle = 0 Then 'CSD-Covered Van' " +
                           "When ByVehicle = 1 Then 'CSD-Micro Bus' " +
                           "When ByVehicle = 2 Then 'Log-Vehicle' " +
                           "When ByVehicle = 3 Then 'TD-Vehicle' " +
                           "When ByVehicle = 4 Then 'Admin-Vehicle' " +
                           "When ByVehicle = 5 Then 'Rental-Vehicle' " +
                           "When ByVehicle = 6  Then 'Others' " +
                           "else 'Nothings' end " +
                           "From t_CSDVehicleRequisition VR " +
                           "Left Outer Join TELServiceDB.dbo.Job J " +
                           "ON J.JobID=VR.JobID " +
                           "Left Outer Join TELServiceDB.dbo.Product P " +
                           "ON P.ProductID=J.ProductID " +
                           "INNER JOIN t_User U " +
                           "ON U.UserID=VR.CreateUserID " +
                           "Left OUter JOIN v_ProductDetails PD " +
                           "ON PD.ProductID=VR.ProductID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=1) VRHSCH " +
                           "ON VR.VRID=VRHSCH.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=2) VRHRSCH " +
                           "ON VR.VRID=VRHRSCH.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=3) VRHDone " +
                           "ON VR.VRID=VRHDone.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=4) VRHPen " +
                           "ON VR.VRID=VRHPen.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=5) VRHCan " +
                           "ON VR.VRID=VRHCan.VRID " +
                           ")A " +
                           "Where CD BETWEEN'" + dtFromDate + "'AND '" + dtToDate + "' AND CD < '" + dtToDate + "'";


            if (nStatus > -1)
            {
                sSql = sSql + "AND Status ='" + nStatus + "'";
            }
            if (nReqType > -0)
            {
                sSql = sSql + "AND ReqType ='" + nReqType + "'";
            }
            if (txtID != "")
            {
                sSql = sSql + " AND VRID = '" + txtID + "'";
            }
            if (txtJobNo != "")
            {
                txtJobNo = "%" + txtJobNo + "%";
                sSql = sSql + " AND JobNo LIKE '" + txtJobNo + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND ContactNo LIKE '" + txtContactNo + "'";
            }
            if (txtCustomerName != "")
            {
                txtCustomerName = "%" + txtCustomerName + "%";
                sSql = sSql + " AND CustomerName LIKE '" + txtCustomerName + "'";
            }
            if (txtLocation != "")
            {
                txtLocation = "%" + txtLocation + "%";
                sSql = sSql + " AND Location LIKE '" + txtLocation + "'";
            }
            sSql = sSql + " order by VRID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VehicleSchedule oVehicleSchedule = new VehicleSchedule();

                    oVehicleSchedule.VRID = (int)reader["VRID"];
                    oVehicleSchedule.JobNo = (Object)reader["JobNo"].ToString();
                    oVehicleSchedule.ProductCode = (Object)reader["ProductCode"].ToString();
                    oVehicleSchedule.CustomerName = (Object)reader["CustomerName"].ToString();
                    oVehicleSchedule.ContactNo = (Object)reader["ContactNo"].ToString();
                    oVehicleSchedule.Address = (Object)reader["Address"].ToString();
                    oVehicleSchedule.IsNoJob = int.Parse(reader["IsNoJob"].ToString());
                    oVehicleSchedule.ContactForDateTime = int.Parse(reader["ContactForDateTime"].ToString());
                    oVehicleSchedule.JobType = int.Parse(reader["JobType"].ToString());
                    oVehicleSchedule.Location = (Object)reader["Location"].ToString();
                    oVehicleSchedule.ReqType = int.Parse(reader["ReqType"].ToString());
                    oVehicleSchedule.Remarks = (Object)reader["Remarks"].ToString();
                    oVehicleSchedule.Status = int.Parse(reader["Status"].ToString());
                    oVehicleSchedule.StatusName = (object)reader["StatusName"].ToString();
                    oVehicleSchedule.CreatedBy = (string)reader["CreateUser"];
                    oVehicleSchedule.CreateDate = Convert.ToDateTime(reader["CD"].ToString());
                    oVehicleSchedule.ExpectedDate = (Object)reader["ED"].ToString();
                    oVehicleSchedule.ExpectedTimeFrom = (Object)reader["EDTF"].ToString();
                    oVehicleSchedule.ExpectedTimeTo = (Object)reader["EDTT"].ToString();
                    oVehicleSchedule.ScheduleDate = (Object)reader["SD"].ToString();
                    oVehicleSchedule.ScheduleTimeFrom = (Object)reader["SDTF"].ToString();
                    oVehicleSchedule.ScheduleTimeTo = (Object)reader["SDTT"].ToString();
                    oVehicleSchedule.ScheduleRemarks = (Object)reader["ScheduleRemarks"].ToString();
                    oVehicleSchedule.ReScheduleRemarks = (Object)reader["ReScheduleRemarks"].ToString();
                    oVehicleSchedule.DoneRemarks = (Object)reader["DoneRemarks"].ToString();
                    oVehicleSchedule.PendingRemarks = (Object)reader["PendingRemarks"].ToString();
                    oVehicleSchedule.CancelRemarks = (Object)reader["CancelRemarks"].ToString();
                    oVehicleSchedule.SuspendReasonID = int.Parse(reader["SuspendReasonID"].ToString());
                    //oVehicleSchedule.ByVehicle = int.Parse(reader["ByVehicle"].ToString());
                    oVehicleSchedule.ByVehicle = (int)reader["ByVehicle"];
                    oVehicleSchedule.DeliveryMan = (Object)reader["DeliveryMan"].ToString();
                    oVehicleSchedule.SuspendReason = (Object)reader["SuspendReason"].ToString();
                    oVehicleSchedule.VehicleName = (Object)reader["VehicleName"].ToString();
                    oVehicleSchedule.ProductName = (Object)reader["ProductName"].ToString();
                    oVehicleSchedule.JobTypeName = (Object)reader["JobTypeName"].ToString();
                    oVehicleSchedule.ReqName = (Object)reader["ReqName"].ToString();
                    oVehicleSchedule.SD1 = (Object)reader["SD1"].ToString();
                    oVehicleSchedule.SDTF1 = (Object)reader["SDTF1"].ToString();
                    oVehicleSchedule.SDTT1 = (Object)reader["SDTT1"].ToString();

                    oVehicleSchedule.RefreshUser();
                    InnerList.Add(oVehicleSchedule);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshOnlySD(DateTime dtFromDate1, DateTime dtToDate1, int nStatus, int nReqType, String txtID, String txtJobNo, String txtContactNo, String txtCustomerName, String txtLocation)
        {
            dtToDate1 = dtToDate1.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select VRID, JobNo,CustomerName,Address,Location,ContactNo,ProductCode,ProductName,JobType, " +
                           "JobTypeName,ReqType,ReqName,Remarks,CreateUser,CD,ExpectedDate, ED,EDTF,EDTT,ScheduleDate,IsNull(SD,GetDate())SD, SD SD1, " +
                           "IsNull(SDTF,GetDate())SDTF, SDTF SDTF1, IsNull(SDTT,GetDate())SDTT, SDTT SDTT1, " +
                           "Status,StatusName,IsNoJob,ContactForDateTime, " +
                           "ScheduleRemarks, ReScheduleRemarks, DoneRemarks, PendingRemarks, CancelRemarks, " +
                           "SuspendReasonID,SuspendReason, ByVehicle,VehicleName,DeliveryMan " +
                           "from " +
                           "( " +
                           "Select VR.VRID VRID,IsNull(JobNo,'--')JobNo, IsNull(J.CustomerName,VR.CustomerName)CustomerName, " +
                           "IsNull(FirstAddress,Address)Address,Location,IsNull(Mobile,ContactNo)ContactNo, " +
                           "IsNull(P.Code,PD.ProductCode)ProductCode,IsNull(P.Name,PD.ProductName)ProductName, " +
                           "IsNull(J.JobType,VR.JobType)JobType, JobTypeName=Case  " +
                           "When IsNull(J.JobType,VR.JobType)=1 Then 'FullWarranty' " +
                           "When IsNull(J.JobType,VR.JobType)=2 Then 'Paid' " +
                           "When IsNull(J.JobType,VR.JobType)=3 Then 'ServiceWarranty' " +
                           "else 'Others' end,ReqType, ReqName=CASE When ReQType=1 Then 'Pick-Up' When ReQType=2 Then 'Drop' else 'Others' End, " +
                           "VR.Remarks,CreateUserID,U.UserName CreateUser,VR.CreateDate CD, ExpectedDate, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedDate, 105),11)) ED, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeFrom, 100),7))EDTF, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeTo, 100),7))EDTT, " +
                           "VR.Status Status, " +
                           "StatusName=CASE When VR.Status=0 then 'Requisition' " +
                           "When VR.Status=1 then 'Schedule' " +
                           "When VR.Status=2 then 'ReSchedule' " +
                           "When VR.Status=3 then 'Done' " +
                           "When VR.Status=4 then 'Suspend' " +
                           "When VR.Status=5 then 'Cancel' " +
                           "else 'Others' end, IsNoJob,ContactForDateTime,ScheduleDate, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleDate, 105),11)) SD, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeFrom, 100),7))SDTF, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeTo, 100),7))SDTT, " +
                           "IsNull(VRHSCH.Remarks,'')ScheduleRemarks, IsNull(VRHRSCH.Remarks,'')ReScheduleRemarks, " +
                           "IsNull(VRHDone.Remarks,'')DoneRemarks,IsNull(VRHPen.Remarks,'')PendingRemarks, " +
                           "IsNull(VRHCan.Remarks,'')CancelRemarks, IsNull(SuspendReasonID,0)SuspendReasonID, " +
                           "IsNull(ByVehicle,0)ByVehicle,DeliveryMan, " +
                           "SuspendReason=CASE When SuspendReasonID = 0 Then 'ScheduleNotMatched' " +
                           "When SuspendReasonID = 1 Then 'CustomerWillInfoLater' " +
                           "else 'Others' end, " +
                           "VehicleName=CASE When ByVehicle = 0 Then 'CSD-Covered Van' " +
                           "When ByVehicle = 1 Then 'CSD-Micro Bus' " +
                           "When ByVehicle = 2 Then 'Log-Vehicle' " +
                           "When ByVehicle = 3 Then 'TD-Vehicle' " +
                           "When ByVehicle = 4 Then 'Admin-Vehicle' " +
                           "When ByVehicle = 5 Then 'Rental-Vehicle' " +
                           "When ByVehicle = 6  Then 'Others' " +
                           "else 'Nothings' end " +
                           "From t_CSDVehicleRequisition VR " +
                           "Left Outer Join TELServiceDB.dbo.Job J " +
                           "ON J.JobID=VR.JobID " +
                           "Left Outer Join TELServiceDB.dbo.Product P " +
                           "ON P.ProductID=J.ProductID " +
                           "INNER JOIN t_User U " +
                           "ON U.UserID=VR.CreateUserID " +
                           "Left OUter JOIN v_ProductDetails PD " +
                           "ON PD.ProductID=VR.ProductID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=1) VRHSCH " +
                           "ON VR.VRID=VRHSCH.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=2) VRHRSCH " +
                           "ON VR.VRID=VRHRSCH.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=3) VRHDone " +
                           "ON VR.VRID=VRHDone.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=4) VRHPen " +
                           "ON VR.VRID=VRHPen.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=5) VRHCan " +
                           "ON VR.VRID=VRHCan.VRID " +
                           ")A " +
                           "Where ScheduleDate BETWEEN'" + dtFromDate1 + "'AND '" + dtToDate1 + "' AND ScheduleDate < '" + dtToDate1 + "'";

            if (nStatus > -1)
            {
                sSql = sSql + "AND Status ='" + nStatus + "'";
            }
            if (nReqType > -0)
            {
                sSql = sSql + "AND ReqType ='" + nReqType + "'";
            }
            if (txtID != "")
            {
                sSql = sSql + " AND VRID = '" + txtID + "'";
            }
            if (txtJobNo != "")
            {
                txtJobNo = "%" + txtJobNo + "%";
                sSql = sSql + " AND JobNo LIKE '" + txtJobNo + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND ContactNo LIKE '" + txtContactNo + "'";
            }
            if (txtCustomerName != "")
            {
                txtCustomerName = "%" + txtCustomerName + "%";
                sSql = sSql + " AND CustomerName LIKE '" + txtCustomerName + "'";
            }
            if (txtLocation != "")
            {
                txtLocation = "%" + txtLocation + "%";
                sSql = sSql + " AND Location LIKE '" + txtLocation + "'";
            }
            sSql = sSql + " order by VRID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VehicleSchedule oVehicleSchedule = new VehicleSchedule();

                    oVehicleSchedule.VRID = (int)reader["VRID"];
                    oVehicleSchedule.JobNo = (Object)reader["JobNo"].ToString();
                    oVehicleSchedule.ProductCode = (Object)reader["ProductCode"].ToString();
                    oVehicleSchedule.CustomerName = (Object)reader["CustomerName"].ToString();
                    oVehicleSchedule.ContactNo = (Object)reader["ContactNo"].ToString();
                    oVehicleSchedule.Address = (Object)reader["Address"].ToString();
                    oVehicleSchedule.IsNoJob = int.Parse(reader["IsNoJob"].ToString());
                    oVehicleSchedule.ContactForDateTime = int.Parse(reader["ContactForDateTime"].ToString());
                    oVehicleSchedule.JobType = int.Parse(reader["JobType"].ToString());
                    oVehicleSchedule.Location = (Object)reader["Location"].ToString();
                    oVehicleSchedule.ReqType = int.Parse(reader["ReqType"].ToString());
                    oVehicleSchedule.Remarks = (Object)reader["Remarks"].ToString();
                    oVehicleSchedule.Status = int.Parse(reader["Status"].ToString());
                    oVehicleSchedule.StatusName = (object)reader["StatusName"].ToString();
                    oVehicleSchedule.CreatedBy = (string)reader["CreateUser"];
                    oVehicleSchedule.CreateDate = Convert.ToDateTime(reader["CD"].ToString());
                    oVehicleSchedule.ExpectedDate = (Object)reader["ED"].ToString();
                    oVehicleSchedule.ExpectedTimeFrom = (Object)reader["EDTF"].ToString();
                    oVehicleSchedule.ExpectedTimeTo = (Object)reader["EDTT"].ToString();
                    oVehicleSchedule.ScheduleDate = (Object)reader["SD"].ToString();
                    oVehicleSchedule.ScheduleTimeFrom = (Object)reader["SDTF"].ToString();
                    oVehicleSchedule.ScheduleTimeTo = (Object)reader["SDTT"].ToString();
                    oVehicleSchedule.ScheduleRemarks = (Object)reader["ScheduleRemarks"].ToString();
                    oVehicleSchedule.ReScheduleRemarks = (Object)reader["ReScheduleRemarks"].ToString();
                    oVehicleSchedule.DoneRemarks = (Object)reader["DoneRemarks"].ToString();
                    oVehicleSchedule.PendingRemarks = (Object)reader["PendingRemarks"].ToString();
                    oVehicleSchedule.CancelRemarks = (Object)reader["CancelRemarks"].ToString();
                    oVehicleSchedule.SuspendReasonID = int.Parse(reader["SuspendReasonID"].ToString());
                    //oVehicleSchedule.ByVehicle = int.Parse(reader["ByVehicle"].ToString());
                    oVehicleSchedule.ByVehicle = (int)reader["ByVehicle"];
                    oVehicleSchedule.DeliveryMan = (Object)reader["DeliveryMan"].ToString();
                    oVehicleSchedule.SuspendReason = (Object)reader["SuspendReason"].ToString();
                    oVehicleSchedule.VehicleName = (Object)reader["VehicleName"].ToString();
                    oVehicleSchedule.ProductName = (Object)reader["ProductName"].ToString();
                    oVehicleSchedule.JobTypeName = (Object)reader["JobTypeName"].ToString();
                    oVehicleSchedule.ReqName = (Object)reader["ReqName"].ToString();
                    oVehicleSchedule.SD1 = (Object)reader["SD1"].ToString();
                    oVehicleSchedule.SDTF1 = (Object)reader["SDTF1"].ToString();
                    oVehicleSchedule.SDTT1 = (Object)reader["SDTT1"].ToString();

                    oVehicleSchedule.RefreshUser();
                    InnerList.Add(oVehicleSchedule);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshOnlyED(DateTime dtFromDate2, DateTime dtToDate2, int nStatus, int nReqType, String txtID, String txtJobNo, String txtContactNo, String txtCustomerName, String txtLocation)
        {
            dtToDate2 = dtToDate2.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select VRID, JobNo,CustomerName,Address,Location,ContactNo,ProductCode,ProductName,JobType, " +
                           "JobTypeName,ReqType,ReqName,Remarks,CreateUser,CD,ExpectedDate, ED,EDTF,EDTT,ScheduleDate,IsNull(SD,GetDate())SD, SD SD1, " +
                           "IsNull(SDTF,GetDate())SDTF, SDTF SDTF1, IsNull(SDTT,GetDate())SDTT, SDTT SDTT1, " +
                           "Status,StatusName,IsNoJob,ContactForDateTime, " +
                           "ScheduleRemarks, ReScheduleRemarks, DoneRemarks, PendingRemarks, CancelRemarks, " +
                           "SuspendReasonID,SuspendReason, ByVehicle,VehicleName,DeliveryMan " +
                           "from " +
                           "( " +
                           "Select VR.VRID VRID,IsNull(JobNo,'--')JobNo, IsNull(J.CustomerName,VR.CustomerName)CustomerName, " +
                           "IsNull(FirstAddress,Address)Address,Location,IsNull(Mobile,ContactNo)ContactNo, " +
                           "IsNull(P.Code,PD.ProductCode)ProductCode,IsNull(P.Name,PD.ProductName)ProductName, " +
                           "IsNull(J.JobType,VR.JobType)JobType, JobTypeName=Case  " +
                           "When IsNull(J.JobType,VR.JobType)=1 Then 'FullWarranty' " +
                           "When IsNull(J.JobType,VR.JobType)=2 Then 'Paid' " +
                           "When IsNull(J.JobType,VR.JobType)=3 Then 'ServiceWarranty' " +
                           "else 'Others' end,ReqType, ReqName=CASE When ReQType=1 Then 'Pick-Up' When ReQType=2 Then 'Drop' else 'Others' End, " +
                           "VR.Remarks,CreateUserID,U.UserName CreateUser,VR.CreateDate CD, ExpectedDate, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedDate, 105),11)) ED, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeFrom, 100),7))EDTF, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeTo, 100),7))EDTT, " +
                           "VR.Status Status, " +
                           "StatusName=CASE When VR.Status=0 then 'Requisition' " +
                           "When VR.Status=1 then 'Schedule' " +
                           "When VR.Status=2 then 'ReSchedule' " +
                           "When VR.Status=3 then 'Done' " +
                           "When VR.Status=4 then 'Suspend' " +
                           "When VR.Status=5 then 'Cancel' " +
                           "else 'Others' end, IsNoJob,ContactForDateTime,ScheduleDate, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleDate, 105),11)) SD, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeFrom, 100),7))SDTF, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeTo, 100),7))SDTT, " +
                           "IsNull(VRHSCH.Remarks,'')ScheduleRemarks, IsNull(VRHRSCH.Remarks,'')ReScheduleRemarks, " +
                           "IsNull(VRHDone.Remarks,'')DoneRemarks,IsNull(VRHPen.Remarks,'')PendingRemarks, " +
                           "IsNull(VRHCan.Remarks,'')CancelRemarks, IsNull(SuspendReasonID,0)SuspendReasonID, " +
                           "IsNull(ByVehicle,0)ByVehicle,DeliveryMan, " +
                           "SuspendReason=CASE When SuspendReasonID = 0 Then 'ScheduleNotMatched' " +
                           "When SuspendReasonID = 1 Then 'CustomerWillInfoLater' " +
                           "else 'Others' end, " +
                           "VehicleName=CASE When ByVehicle = 0 Then 'CSD-Covered Van' " +
                           "When ByVehicle = 1 Then 'CSD-Micro Bus' " +
                           "When ByVehicle = 2 Then 'Log-Vehicle' " +
                           "When ByVehicle = 3 Then 'TD-Vehicle' " +
                           "When ByVehicle = 4 Then 'Admin-Vehicle' " +
                           "When ByVehicle = 5 Then 'Rental-Vehicle' " +
                           "When ByVehicle = 6  Then 'Others' " +
                           "else 'Nothings' end " +
                           "From t_CSDVehicleRequisition VR " +
                           "Left Outer Join TELServiceDB.dbo.Job J " +
                           "ON J.JobID=VR.JobID " +
                           "Left Outer Join TELServiceDB.dbo.Product P " +
                           "ON P.ProductID=J.ProductID " +
                           "INNER JOIN t_User U " +
                           "ON U.UserID=VR.CreateUserID " +
                           "Left OUter JOIN v_ProductDetails PD " +
                           "ON PD.ProductID=VR.ProductID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=1) VRHSCH " +
                           "ON VR.VRID=VRHSCH.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=2) VRHRSCH " +
                           "ON VR.VRID=VRHRSCH.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=3) VRHDone " +
                           "ON VR.VRID=VRHDone.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=4) VRHPen " +
                           "ON VR.VRID=VRHPen.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=5) VRHCan " +
                           "ON VR.VRID=VRHCan.VRID " +
                           ")A " +
                           "Where ExpectedDate BETWEEN'" + dtFromDate2 + "'AND '" + dtToDate2 + "' AND ExpectedDate < '" + dtToDate2 + "'";


            if (nStatus > -1)
            {
                sSql = sSql + "AND Status ='" + nStatus + "'";
            }
            if (nReqType > -0)
            {
                sSql = sSql + "AND ReqType ='" + nReqType + "'";
            }
            if (txtID != "")
            {
                sSql = sSql + " AND VRID = '" + txtID + "'";
            }
            if (txtJobNo != "")
            {
                txtJobNo = "%" + txtJobNo + "%";
                sSql = sSql + " AND JobNo LIKE '" + txtJobNo + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND ContactNo LIKE '" + txtContactNo + "'";
            }
            if (txtCustomerName != "")
            {
                txtCustomerName = "%" + txtCustomerName + "%";
                sSql = sSql + " AND CustomerName LIKE '" + txtCustomerName + "'";
            }
            if (txtLocation != "")
            {
                txtLocation = "%" + txtLocation + "%";
                sSql = sSql + " AND Location LIKE '" + txtLocation + "'";
            }
            sSql = sSql + " order by VRID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VehicleSchedule oVehicleSchedule = new VehicleSchedule();

                    oVehicleSchedule.VRID = (int)reader["VRID"];
                    oVehicleSchedule.JobNo = (Object)reader["JobNo"].ToString();
                    oVehicleSchedule.ProductCode = (Object)reader["ProductCode"].ToString();
                    oVehicleSchedule.CustomerName = (Object)reader["CustomerName"].ToString();
                    oVehicleSchedule.ContactNo = (Object)reader["ContactNo"].ToString();
                    oVehicleSchedule.Address = (Object)reader["Address"].ToString();
                    oVehicleSchedule.IsNoJob = int.Parse(reader["IsNoJob"].ToString());
                    oVehicleSchedule.ContactForDateTime = int.Parse(reader["ContactForDateTime"].ToString());
                    oVehicleSchedule.JobType = int.Parse(reader["JobType"].ToString());
                    oVehicleSchedule.Location = (Object)reader["Location"].ToString();
                    oVehicleSchedule.ReqType = int.Parse(reader["ReqType"].ToString());
                    oVehicleSchedule.Remarks = (Object)reader["Remarks"].ToString();
                    oVehicleSchedule.Status = int.Parse(reader["Status"].ToString());
                    oVehicleSchedule.StatusName = (object)reader["StatusName"].ToString();
                    oVehicleSchedule.CreatedBy = (string)reader["CreateUser"];
                    oVehicleSchedule.CreateDate = Convert.ToDateTime(reader["CD"].ToString());
                    oVehicleSchedule.ExpectedDate = (Object)reader["ED"].ToString();
                    oVehicleSchedule.ExpectedTimeFrom = (Object)reader["EDTF"].ToString();
                    oVehicleSchedule.ExpectedTimeTo = (Object)reader["EDTT"].ToString();
                    oVehicleSchedule.ScheduleDate = (Object)reader["SD"].ToString();
                    oVehicleSchedule.ScheduleTimeFrom = (Object)reader["SDTF"].ToString();
                    oVehicleSchedule.ScheduleTimeTo = (Object)reader["SDTT"].ToString();
                    oVehicleSchedule.ScheduleRemarks = (Object)reader["ScheduleRemarks"].ToString();
                    oVehicleSchedule.ReScheduleRemarks = (Object)reader["ReScheduleRemarks"].ToString();
                    oVehicleSchedule.DoneRemarks = (Object)reader["DoneRemarks"].ToString();
                    oVehicleSchedule.PendingRemarks = (Object)reader["PendingRemarks"].ToString();
                    oVehicleSchedule.CancelRemarks = (Object)reader["CancelRemarks"].ToString();
                    oVehicleSchedule.SuspendReasonID = int.Parse(reader["SuspendReasonID"].ToString());
                    //oVehicleSchedule.ByVehicle = int.Parse(reader["ByVehicle"].ToString());
                    oVehicleSchedule.ByVehicle = (int)reader["ByVehicle"];
                    oVehicleSchedule.DeliveryMan = (Object)reader["DeliveryMan"].ToString();
                    oVehicleSchedule.SuspendReason = (Object)reader["SuspendReason"].ToString();
                    oVehicleSchedule.VehicleName = (Object)reader["VehicleName"].ToString();
                    oVehicleSchedule.ProductName = (Object)reader["ProductName"].ToString();
                    oVehicleSchedule.JobTypeName = (Object)reader["JobTypeName"].ToString();
                    oVehicleSchedule.ReqName = (Object)reader["ReqName"].ToString();
                    oVehicleSchedule.SD1 = (Object)reader["SD1"].ToString();
                    oVehicleSchedule.SDTF1 = (Object)reader["SDTF1"].ToString();
                    oVehicleSchedule.SDTT1 = (Object)reader["SDTT1"].ToString();

                    oVehicleSchedule.RefreshUser();
                    InnerList.Add(oVehicleSchedule);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshCDNSD(DateTime dtFromDate, DateTime dtToDate, DateTime dtFromDate1, DateTime dtToDate1, int nStatus, int nReqType, String txtID, String txtJobNo, String txtContactNo, String txtCustomerName, String txtLocation)
        {
            dtToDate = dtToDate.Date.AddDays(1);
            dtToDate1 = dtToDate1.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select VRID, JobNo,CustomerName,Address,Location,ContactNo,ProductCode,ProductName,JobType, " +
                           "JobTypeName,ReqType,ReqName,Remarks,CreateUser,CD,ExpectedDate, ED,EDTF,EDTT,ScheduleDate,IsNull(SD,GetDate())SD, SD SD1, " +
                           "IsNull(SDTF,GetDate())SDTF, SDTF SDTF1, IsNull(SDTT,GetDate())SDTT, SDTT SDTT1, " +
                           "Status,StatusName,IsNoJob,ContactForDateTime, " +
                           "ScheduleRemarks, ReScheduleRemarks, DoneRemarks, PendingRemarks, CancelRemarks, " +
                           "SuspendReasonID,SuspendReason, ByVehicle,VehicleName,DeliveryMan " +
                           "from " +
                           "( " +
                           "Select VR.VRID VRID,IsNull(JobNo,'--')JobNo, IsNull(J.CustomerName,VR.CustomerName)CustomerName, " +
                           "IsNull(FirstAddress,Address)Address,Location,IsNull(Mobile,ContactNo)ContactNo, " +
                           "IsNull(P.Code,PD.ProductCode)ProductCode,IsNull(P.Name,PD.ProductName)ProductName, " +
                           "IsNull(J.JobType,VR.JobType)JobType, JobTypeName=Case  " +
                           "When IsNull(J.JobType,VR.JobType)=1 Then 'FullWarranty' " +
                           "When IsNull(J.JobType,VR.JobType)=2 Then 'Paid' " +
                           "When IsNull(J.JobType,VR.JobType)=3 Then 'ServiceWarranty' " +
                           "else 'Others' end,ReqType, ReqName=CASE When ReQType=1 Then 'Pick-Up' When ReQType=2 Then 'Drop' else 'Others' End, " +
                           "VR.Remarks,CreateUserID,U.UserName CreateUser,VR.CreateDate CD, ExpectedDate, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedDate, 105),11)) ED, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeFrom, 100),7))EDTF, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeTo, 100),7))EDTT, " +
                           "VR.Status Status, " +
                           "StatusName=CASE When VR.Status=0 then 'Requisition' " +
                           "When VR.Status=1 then 'Schedule' " +
                           "When VR.Status=2 then 'ReSchedule' " +
                           "When VR.Status=3 then 'Done' " +
                           "When VR.Status=4 then 'Suspend' " +
                           "When VR.Status=5 then 'Cancel' " +
                           "else 'Others' end, IsNoJob,ContactForDateTime,ScheduleDate, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleDate, 105),11)) SD, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeFrom, 100),7))SDTF, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeTo, 100),7))SDTT, " +
                           "IsNull(VRHSCH.Remarks,'')ScheduleRemarks, IsNull(VRHRSCH.Remarks,'')ReScheduleRemarks, " +
                           "IsNull(VRHDone.Remarks,'')DoneRemarks,IsNull(VRHPen.Remarks,'')PendingRemarks, " +
                           "IsNull(VRHCan.Remarks,'')CancelRemarks, IsNull(SuspendReasonID,0)SuspendReasonID, " +
                           "IsNull(ByVehicle,0)ByVehicle,DeliveryMan, " +
                           "SuspendReason=CASE When SuspendReasonID = 0 Then 'ScheduleNotMatched' " +
                           "When SuspendReasonID = 1 Then 'CustomerWillInfoLater' " +
                           "else 'Others' end, " +
                           "VehicleName=CASE When ByVehicle = 0 Then 'CSD-Covered Van' " +
                           "When ByVehicle = 1 Then 'CSD-Micro Bus' " +
                           "When ByVehicle = 2 Then 'Log-Vehicle' " +
                           "When ByVehicle = 3 Then 'TD-Vehicle' " +
                           "When ByVehicle = 4 Then 'Admin-Vehicle' " +
                           "When ByVehicle = 5 Then 'Rental-Vehicle' " +
                           "When ByVehicle = 6  Then 'Others' " +
                           "else 'Nothings' end " +
                           "From t_CSDVehicleRequisition VR " +
                           "Left Outer Join TELServiceDB.dbo.Job J " +
                           "ON J.JobID=VR.JobID " +
                           "Left Outer Join TELServiceDB.dbo.Product P " +
                           "ON P.ProductID=J.ProductID " +
                           "INNER JOIN t_User U " +
                           "ON U.UserID=VR.CreateUserID " +
                           "Left OUter JOIN v_ProductDetails PD " +
                           "ON PD.ProductID=VR.ProductID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=1) VRHSCH " +
                           "ON VR.VRID=VRHSCH.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=2) VRHRSCH " +
                           "ON VR.VRID=VRHRSCH.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=3) VRHDone " +
                           "ON VR.VRID=VRHDone.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=4) VRHPen " +
                           "ON VR.VRID=VRHPen.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=5) VRHCan " +
                           "ON VR.VRID=VRHCan.VRID " +
                           ")A " +
                           "Where CD BETWEEN'" + dtFromDate + "'AND '" + dtToDate + "' AND CD < '" + dtToDate + "'" +
                           "AND ScheduleDate BETWEEN'" + dtFromDate1 + "'AND '" + dtToDate1 + "' AND ScheduleDate < '" + dtToDate1 + "'";


            if (nStatus > -1)
            {
                sSql = sSql + "AND Status ='" + nStatus + "'";
            }
            if (nReqType > -0)
            {
                sSql = sSql + "AND ReqType ='" + nReqType + "'";
            }
            if (txtID != "")
            {
                sSql = sSql + " AND VRID = '" + txtID + "'";
            }
            if (txtJobNo != "")
            {
                txtJobNo = "%" + txtJobNo + "%";
                sSql = sSql + " AND JobNo LIKE '" + txtJobNo + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND ContactNo LIKE '" + txtContactNo + "'";
            }
            if (txtCustomerName != "")
            {
                txtCustomerName = "%" + txtCustomerName + "%";
                sSql = sSql + " AND CustomerName LIKE '" + txtCustomerName + "'";
            }
            if (txtLocation != "")
            {
                txtLocation = "%" + txtLocation + "%";
                sSql = sSql + " AND Location LIKE '" + txtLocation + "'";
            }
            sSql = sSql + " order by VRID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VehicleSchedule oVehicleSchedule = new VehicleSchedule();

                    oVehicleSchedule.VRID = (int)reader["VRID"];
                    oVehicleSchedule.JobNo = (Object)reader["JobNo"].ToString();
                    oVehicleSchedule.ProductCode = (Object)reader["ProductCode"].ToString();
                    oVehicleSchedule.CustomerName = (Object)reader["CustomerName"].ToString();
                    oVehicleSchedule.ContactNo = (Object)reader["ContactNo"].ToString();
                    oVehicleSchedule.Address = (Object)reader["Address"].ToString();
                    oVehicleSchedule.IsNoJob = int.Parse(reader["IsNoJob"].ToString());
                    oVehicleSchedule.ContactForDateTime = int.Parse(reader["ContactForDateTime"].ToString());
                    oVehicleSchedule.JobType = int.Parse(reader["JobType"].ToString());
                    oVehicleSchedule.Location = (Object)reader["Location"].ToString();
                    oVehicleSchedule.ReqType = int.Parse(reader["ReqType"].ToString());
                    oVehicleSchedule.Remarks = (Object)reader["Remarks"].ToString();
                    oVehicleSchedule.Status = int.Parse(reader["Status"].ToString());
                    oVehicleSchedule.StatusName = (object)reader["StatusName"].ToString();
                    oVehicleSchedule.CreatedBy = (string)reader["CreateUser"];
                    oVehicleSchedule.CreateDate = Convert.ToDateTime(reader["CD"].ToString());
                    oVehicleSchedule.ExpectedDate = (Object)reader["ED"].ToString();
                    oVehicleSchedule.ExpectedTimeFrom = (Object)reader["EDTF"].ToString();
                    oVehicleSchedule.ExpectedTimeTo = (Object)reader["EDTT"].ToString();
                    oVehicleSchedule.ScheduleDate = (Object)reader["SD"].ToString();
                    oVehicleSchedule.ScheduleTimeFrom = (Object)reader["SDTF"].ToString();
                    oVehicleSchedule.ScheduleTimeTo = (Object)reader["SDTT"].ToString();
                    oVehicleSchedule.ScheduleRemarks = (Object)reader["ScheduleRemarks"].ToString();
                    oVehicleSchedule.ReScheduleRemarks = (Object)reader["ReScheduleRemarks"].ToString();
                    oVehicleSchedule.DoneRemarks = (Object)reader["DoneRemarks"].ToString();
                    oVehicleSchedule.PendingRemarks = (Object)reader["PendingRemarks"].ToString();
                    oVehicleSchedule.CancelRemarks = (Object)reader["CancelRemarks"].ToString();
                    oVehicleSchedule.SuspendReasonID = int.Parse(reader["SuspendReasonID"].ToString());
                    //oVehicleSchedule.ByVehicle = int.Parse(reader["ByVehicle"].ToString());
                    oVehicleSchedule.ByVehicle = (int)reader["ByVehicle"];
                    oVehicleSchedule.DeliveryMan = (Object)reader["DeliveryMan"].ToString();
                    oVehicleSchedule.SuspendReason = (Object)reader["SuspendReason"].ToString();
                    oVehicleSchedule.VehicleName = (Object)reader["VehicleName"].ToString();
                    oVehicleSchedule.ProductName = (Object)reader["ProductName"].ToString();
                    oVehicleSchedule.JobTypeName = (Object)reader["JobTypeName"].ToString();
                    oVehicleSchedule.ReqName = (Object)reader["ReqName"].ToString();
                    oVehicleSchedule.SD1 = (Object)reader["SD1"].ToString();
                    oVehicleSchedule.SDTF1 = (Object)reader["SDTF1"].ToString();
                    oVehicleSchedule.SDTT1 = (Object)reader["SDTT1"].ToString();

                    oVehicleSchedule.RefreshUser();
                    InnerList.Add(oVehicleSchedule);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshCDNED(DateTime dtFromDate, DateTime dtToDate, DateTime dtFromDate2, DateTime dtToDate2, int nStatus, int nReqType, String txtID, String txtJobNo, String txtContactNo, String txtCustomerName, String txtLocation)
        {
            dtToDate = dtToDate.Date.AddDays(1);
            dtToDate2 = dtToDate2.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select VRID, JobNo,CustomerName,Address,Location,ContactNo,ProductCode,ProductName,JobType, " +
                           "JobTypeName,ReqType,ReqName,Remarks,CreateUser,CD,ExpectedDate, ED,EDTF,EDTT,ScheduleDate,IsNull(SD,GetDate())SD, SD SD1, " +
                           "IsNull(SDTF,GetDate())SDTF, SDTF SDTF1, IsNull(SDTT,GetDate())SDTT, SDTT SDTT1, " +
                           "Status,StatusName,IsNoJob,ContactForDateTime, " +
                           "ScheduleRemarks, ReScheduleRemarks, DoneRemarks, PendingRemarks, CancelRemarks, " +
                           "SuspendReasonID,SuspendReason, ByVehicle,VehicleName,DeliveryMan " +
                           "from " +
                           "( " +
                           "Select VR.VRID VRID,IsNull(JobNo,'--')JobNo, IsNull(J.CustomerName,VR.CustomerName)CustomerName, " +
                           "IsNull(FirstAddress,Address)Address,Location,IsNull(Mobile,ContactNo)ContactNo, " +
                           "IsNull(P.Code,PD.ProductCode)ProductCode,IsNull(P.Name,PD.ProductName)ProductName, " +
                           "IsNull(J.JobType,VR.JobType)JobType, JobTypeName=Case  " +
                           "When IsNull(J.JobType,VR.JobType)=1 Then 'FullWarranty' " +
                           "When IsNull(J.JobType,VR.JobType)=2 Then 'Paid' " +
                           "When IsNull(J.JobType,VR.JobType)=3 Then 'ServiceWarranty' " +
                           "else 'Others' end,ReqType, ReqName=CASE When ReQType=1 Then 'Pick-Up' When ReQType=2 Then 'Drop' else 'Others' End, " +
                           "VR.Remarks,CreateUserID,U.UserName CreateUser,VR.CreateDate CD, ExpectedDate, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedDate, 105),11)) ED, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeFrom, 100),7))EDTF, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeTo, 100),7))EDTT, " +
                           "VR.Status Status, " +
                           "StatusName=CASE When VR.Status=0 then 'Requisition' " +
                           "When VR.Status=1 then 'Schedule' " +
                           "When VR.Status=2 then 'ReSchedule' " +
                           "When VR.Status=3 then 'Done' " +
                           "When VR.Status=4 then 'Suspend' " +
                           "When VR.Status=5 then 'Cancel' " +
                           "else 'Others' end, IsNoJob,ContactForDateTime,ScheduleDate, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleDate, 105),11)) SD, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeFrom, 100),7))SDTF, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeTo, 100),7))SDTT, " +
                           "IsNull(VRHSCH.Remarks,'')ScheduleRemarks, IsNull(VRHRSCH.Remarks,'')ReScheduleRemarks, " +
                           "IsNull(VRHDone.Remarks,'')DoneRemarks,IsNull(VRHPen.Remarks,'')PendingRemarks, " +
                           "IsNull(VRHCan.Remarks,'')CancelRemarks, IsNull(SuspendReasonID,0)SuspendReasonID, " +
                           "IsNull(ByVehicle,0)ByVehicle,DeliveryMan, " +
                           "SuspendReason=CASE When SuspendReasonID = 0 Then 'ScheduleNotMatched' " +
                           "When SuspendReasonID = 1 Then 'CustomerWillInfoLater' " +
                           "else 'Others' end, " +
                           "VehicleName=CASE When ByVehicle = 0 Then 'CSD-Covered Van' " +
                           "When ByVehicle = 1 Then 'CSD-Micro Bus' " +
                           "When ByVehicle = 2 Then 'Log-Vehicle' " +
                           "When ByVehicle = 3 Then 'TD-Vehicle' " +
                           "When ByVehicle = 4 Then 'Admin-Vehicle' " +
                           "When ByVehicle = 5 Then 'Rental-Vehicle' " +
                           "When ByVehicle = 6  Then 'Others' " +
                           "else 'Nothings' end " +
                           "From t_CSDVehicleRequisition VR " +
                           "Left Outer Join TELServiceDB.dbo.Job J " +
                           "ON J.JobID=VR.JobID " +
                           "Left Outer Join TELServiceDB.dbo.Product P " +
                           "ON P.ProductID=J.ProductID " +
                           "INNER JOIN t_User U " +
                           "ON U.UserID=VR.CreateUserID " +
                           "Left OUter JOIN v_ProductDetails PD " +
                           "ON PD.ProductID=VR.ProductID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=1) VRHSCH " +
                           "ON VR.VRID=VRHSCH.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=2) VRHRSCH " +
                           "ON VR.VRID=VRHRSCH.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=3) VRHDone " +
                           "ON VR.VRID=VRHDone.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=4) VRHPen " +
                           "ON VR.VRID=VRHPen.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=5) VRHCan " +
                           "ON VR.VRID=VRHCan.VRID " +
                           ")A " +
                           "Where CD BETWEEN'" + dtFromDate + "'AND '" + dtToDate + "' AND CD < '" + dtToDate + "'" +
                           "AND ExpectedDate BETWEEN'" + dtFromDate2 + "'AND '" + dtToDate2 + "' AND ExpectedDate < '" + dtToDate2 + "'";


            if (nStatus > -1)
            {
                sSql = sSql + "AND Status ='" + nStatus + "'";
            }
            if (nReqType > -0)
            {
                sSql = sSql + "AND ReqType ='" + nReqType + "'";
            }
            if (txtID != "")
            {
                sSql = sSql + " AND VRID = '" + txtID + "'";
            }
            if (txtJobNo != "")
            {
                txtJobNo = "%" + txtJobNo + "%";
                sSql = sSql + " AND JobNo LIKE '" + txtJobNo + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND ContactNo LIKE '" + txtContactNo + "'";
            }
            if (txtCustomerName != "")
            {
                txtCustomerName = "%" + txtCustomerName + "%";
                sSql = sSql + " AND CustomerName LIKE '" + txtCustomerName + "'";
            }
            if (txtLocation != "")
            {
                txtLocation = "%" + txtLocation + "%";
                sSql = sSql + " AND Location LIKE '" + txtLocation + "'";
            }
            sSql = sSql + " order by VRID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VehicleSchedule oVehicleSchedule = new VehicleSchedule();

                    oVehicleSchedule.VRID = (int)reader["VRID"];
                    oVehicleSchedule.JobNo = (Object)reader["JobNo"].ToString();
                    oVehicleSchedule.ProductCode = (Object)reader["ProductCode"].ToString();
                    oVehicleSchedule.CustomerName = (Object)reader["CustomerName"].ToString();
                    oVehicleSchedule.ContactNo = (Object)reader["ContactNo"].ToString();
                    oVehicleSchedule.Address = (Object)reader["Address"].ToString();
                    oVehicleSchedule.IsNoJob = int.Parse(reader["IsNoJob"].ToString());
                    oVehicleSchedule.ContactForDateTime = int.Parse(reader["ContactForDateTime"].ToString());
                    oVehicleSchedule.JobType = int.Parse(reader["JobType"].ToString());
                    oVehicleSchedule.Location = (Object)reader["Location"].ToString();
                    oVehicleSchedule.ReqType = int.Parse(reader["ReqType"].ToString());
                    oVehicleSchedule.Remarks = (Object)reader["Remarks"].ToString();
                    oVehicleSchedule.Status = int.Parse(reader["Status"].ToString());
                    oVehicleSchedule.StatusName = (object)reader["StatusName"].ToString();
                    oVehicleSchedule.CreatedBy = (string)reader["CreateUser"];
                    oVehicleSchedule.CreateDate = Convert.ToDateTime(reader["CD"].ToString());
                    oVehicleSchedule.ExpectedDate = (Object)reader["ED"].ToString();
                    oVehicleSchedule.ExpectedTimeFrom = (Object)reader["EDTF"].ToString();
                    oVehicleSchedule.ExpectedTimeTo = (Object)reader["EDTT"].ToString();
                    oVehicleSchedule.ScheduleDate = (Object)reader["SD"].ToString();
                    oVehicleSchedule.ScheduleTimeFrom = (Object)reader["SDTF"].ToString();
                    oVehicleSchedule.ScheduleTimeTo = (Object)reader["SDTT"].ToString();
                    oVehicleSchedule.ScheduleRemarks = (Object)reader["ScheduleRemarks"].ToString();
                    oVehicleSchedule.ReScheduleRemarks = (Object)reader["ReScheduleRemarks"].ToString();
                    oVehicleSchedule.DoneRemarks = (Object)reader["DoneRemarks"].ToString();
                    oVehicleSchedule.PendingRemarks = (Object)reader["PendingRemarks"].ToString();
                    oVehicleSchedule.CancelRemarks = (Object)reader["CancelRemarks"].ToString();
                    oVehicleSchedule.SuspendReasonID = int.Parse(reader["SuspendReasonID"].ToString());
                    //oVehicleSchedule.ByVehicle = int.Parse(reader["ByVehicle"].ToString());
                    oVehicleSchedule.ByVehicle = (int)reader["ByVehicle"];
                    oVehicleSchedule.DeliveryMan = (Object)reader["DeliveryMan"].ToString();
                    oVehicleSchedule.SuspendReason = (Object)reader["SuspendReason"].ToString();
                    oVehicleSchedule.VehicleName = (Object)reader["VehicleName"].ToString();
                    oVehicleSchedule.ProductName = (Object)reader["ProductName"].ToString();
                    oVehicleSchedule.JobTypeName = (Object)reader["JobTypeName"].ToString();
                    oVehicleSchedule.ReqName = (Object)reader["ReqName"].ToString();
                    oVehicleSchedule.SD1 = (Object)reader["SD1"].ToString();
                    oVehicleSchedule.SDTF1 = (Object)reader["SDTF1"].ToString();
                    oVehicleSchedule.SDTT1 = (Object)reader["SDTT1"].ToString();

                    oVehicleSchedule.RefreshUser();
                    InnerList.Add(oVehicleSchedule);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshSDNED(DateTime dtFromDate1, DateTime dtToDate1, DateTime dtFromDate2, DateTime dtToDate2, int nStatus, int nReqType, String txtID, String txtJobNo, String txtContactNo, String txtCustomerName, String txtLocation)
        {
            dtToDate1 = dtToDate1.Date.AddDays(1);
            dtToDate2 = dtToDate2.Date.AddDays(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select VRID, JobNo,CustomerName,Address,Location,ContactNo,ProductCode,ProductName,JobType, " +
                           "JobTypeName,ReqType,ReqName,Remarks,CreateUser,CD,ExpectedDate, ED,EDTF,EDTT,ScheduleDate,IsNull(SD,GetDate())SD, SD SD1, " +
                           "IsNull(SDTF,GetDate())SDTF, SDTF SDTF1, IsNull(SDTT,GetDate())SDTT, SDTT SDTT1, " +
                           "Status,StatusName,IsNoJob,ContactForDateTime, " +
                           "ScheduleRemarks, ReScheduleRemarks, DoneRemarks, PendingRemarks, CancelRemarks, " +
                           "SuspendReasonID,SuspendReason, ByVehicle,VehicleName,DeliveryMan " +
                           "from " +
                           "( " +
                           "Select VR.VRID VRID,IsNull(JobNo,'--')JobNo, IsNull(J.CustomerName,VR.CustomerName)CustomerName, " +
                           "IsNull(FirstAddress,Address)Address,Location,IsNull(Mobile,ContactNo)ContactNo, " +
                           "IsNull(P.Code,PD.ProductCode)ProductCode,IsNull(P.Name,PD.ProductName)ProductName, " +
                           "IsNull(J.JobType,VR.JobType)JobType, JobTypeName=Case  " +
                           "When IsNull(J.JobType,VR.JobType)=1 Then 'FullWarranty' " +
                           "When IsNull(J.JobType,VR.JobType)=2 Then 'Paid' " +
                           "When IsNull(J.JobType,VR.JobType)=3 Then 'ServiceWarranty' " +
                           "else 'Others' end,ReqType, ReqName=CASE When ReQType=1 Then 'Pick-Up' When ReQType=2 Then 'Drop' else 'Others' End, " +
                           "VR.Remarks,CreateUserID,U.UserName CreateUser,VR.CreateDate CD, ExpectedDate, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedDate, 105),11)) ED, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeFrom, 100),7))EDTF, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeTo, 100),7))EDTT, " +
                           "VR.Status Status, " +
                           "StatusName=CASE When VR.Status=0 then 'Requisition' " +
                           "When VR.Status=1 then 'Schedule' " +
                           "When VR.Status=2 then 'ReSchedule' " +
                           "When VR.Status=3 then 'Done' " +
                           "When VR.Status=4 then 'Suspend' " +
                           "When VR.Status=5 then 'Cancel' " +
                           "else 'Others' end, IsNoJob,ContactForDateTime,ScheduleDate, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleDate, 105),11)) SD, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeFrom, 100),7))SDTF, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeTo, 100),7))SDTT, " +
                           "IsNull(VRHSCH.Remarks,'')ScheduleRemarks, IsNull(VRHRSCH.Remarks,'')ReScheduleRemarks, " +
                           "IsNull(VRHDone.Remarks,'')DoneRemarks,IsNull(VRHPen.Remarks,'')PendingRemarks, " +
                           "IsNull(VRHCan.Remarks,'')CancelRemarks, IsNull(SuspendReasonID,0)SuspendReasonID, " +
                           "IsNull(ByVehicle,0)ByVehicle,DeliveryMan, " +
                           "SuspendReason=CASE When SuspendReasonID = 0 Then 'ScheduleNotMatched' " +
                           "When SuspendReasonID = 1 Then 'CustomerWillInfoLater' " +
                           "else 'Others' end, " +
                           "VehicleName=CASE When ByVehicle = 0 Then 'CSD-Covered Van' " +
                           "When ByVehicle = 1 Then 'CSD-Micro Bus' " +
                           "When ByVehicle = 2 Then 'Log-Vehicle' " +
                           "When ByVehicle = 3 Then 'TD-Vehicle' " +
                           "When ByVehicle = 4 Then 'Admin-Vehicle' " +
                           "When ByVehicle = 5 Then 'Rental-Vehicle' " +
                           "When ByVehicle = 6  Then 'Others' " +
                           "else 'Nothings' end " +
                           "From t_CSDVehicleRequisition VR " +
                           "Left Outer Join TELServiceDB.dbo.Job J " +
                           "ON J.JobID=VR.JobID " +
                           "Left Outer Join TELServiceDB.dbo.Product P " +
                           "ON P.ProductID=J.ProductID " +
                           "INNER JOIN t_User U " +
                           "ON U.UserID=VR.CreateUserID " +
                           "Left OUter JOIN v_ProductDetails PD " +
                           "ON PD.ProductID=VR.ProductID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=1) VRHSCH " +
                           "ON VR.VRID=VRHSCH.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=2) VRHRSCH " +
                           "ON VR.VRID=VRHRSCH.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=3) VRHDone " +
                           "ON VR.VRID=VRHDone.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=4) VRHPen " +
                           "ON VR.VRID=VRHPen.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=5) VRHCan " +
                           "ON VR.VRID=VRHCan.VRID " +
                           ")A " +
                           "Where ScheduleDate BETWEEN'" + dtFromDate1 + "'AND '" + dtToDate1 + "' AND ScheduleDate < '" + dtToDate1 + "'" +
                           "AND ExpectedDate BETWEEN'" + dtFromDate2 + "'AND '" + dtToDate2 + "' AND ExpectedDate < '" + dtToDate2 + "'";

            if (nStatus > -1)
            {
                sSql = sSql + "AND Status ='" + nStatus + "'";
            }
            if (nReqType > -0)
            {
                sSql = sSql + "AND ReqType ='" + nReqType + "'";
            }
            if (txtID != "")
            {
                sSql = sSql + " AND VRID = '" + txtID + "'";
            }
            if (txtJobNo != "")
            {
                txtJobNo = "%" + txtJobNo + "%";
                sSql = sSql + " AND JobNo LIKE '" + txtJobNo + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND ContactNo LIKE '" + txtContactNo + "'";
            }
            if (txtCustomerName != "")
            {
                txtCustomerName = "%" + txtCustomerName + "%";
                sSql = sSql + " AND CustomerName LIKE '" + txtCustomerName + "'";
            }
            if (txtLocation != "")
            {
                txtLocation = "%" + txtLocation + "%";
                sSql = sSql + " AND Location LIKE '" + txtLocation + "'";
            }
            sSql = sSql + " order by VRID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VehicleSchedule oVehicleSchedule = new VehicleSchedule();

                    oVehicleSchedule.VRID = (int)reader["VRID"];
                    oVehicleSchedule.JobNo = (Object)reader["JobNo"].ToString();
                    oVehicleSchedule.ProductCode = (Object)reader["ProductCode"].ToString();
                    oVehicleSchedule.CustomerName = (Object)reader["CustomerName"].ToString();
                    oVehicleSchedule.ContactNo = (Object)reader["ContactNo"].ToString();
                    oVehicleSchedule.Address = (Object)reader["Address"].ToString();
                    oVehicleSchedule.IsNoJob = int.Parse(reader["IsNoJob"].ToString());
                    oVehicleSchedule.ContactForDateTime = int.Parse(reader["ContactForDateTime"].ToString());
                    oVehicleSchedule.JobType = int.Parse(reader["JobType"].ToString());
                    oVehicleSchedule.Location = (Object)reader["Location"].ToString();
                    oVehicleSchedule.ReqType = int.Parse(reader["ReqType"].ToString());
                    oVehicleSchedule.Remarks = (Object)reader["Remarks"].ToString();
                    oVehicleSchedule.Status = int.Parse(reader["Status"].ToString());
                    oVehicleSchedule.StatusName = (object)reader["StatusName"].ToString();
                    oVehicleSchedule.CreatedBy = (string)reader["CreateUser"];
                    oVehicleSchedule.CreateDate = Convert.ToDateTime(reader["CD"].ToString());
                    oVehicleSchedule.ExpectedDate = (Object)reader["ED"].ToString();
                    oVehicleSchedule.ExpectedTimeFrom = (Object)reader["EDTF"].ToString();
                    oVehicleSchedule.ExpectedTimeTo = (Object)reader["EDTT"].ToString();
                    oVehicleSchedule.ScheduleDate = (Object)reader["SD"].ToString();
                    oVehicleSchedule.ScheduleTimeFrom = (Object)reader["SDTF"].ToString();
                    oVehicleSchedule.ScheduleTimeTo = (Object)reader["SDTT"].ToString();
                    oVehicleSchedule.ScheduleRemarks = (Object)reader["ScheduleRemarks"].ToString();
                    oVehicleSchedule.ReScheduleRemarks = (Object)reader["ReScheduleRemarks"].ToString();
                    oVehicleSchedule.DoneRemarks = (Object)reader["DoneRemarks"].ToString();
                    oVehicleSchedule.PendingRemarks = (Object)reader["PendingRemarks"].ToString();
                    oVehicleSchedule.CancelRemarks = (Object)reader["CancelRemarks"].ToString();
                    oVehicleSchedule.SuspendReasonID = int.Parse(reader["SuspendReasonID"].ToString());
                    //oVehicleSchedule.ByVehicle = int.Parse(reader["ByVehicle"].ToString());
                    oVehicleSchedule.ByVehicle = (int)reader["ByVehicle"];
                    oVehicleSchedule.DeliveryMan = (Object)reader["DeliveryMan"].ToString();
                    oVehicleSchedule.SuspendReason = (Object)reader["SuspendReason"].ToString();
                    oVehicleSchedule.VehicleName = (Object)reader["VehicleName"].ToString();
                    oVehicleSchedule.ProductName = (Object)reader["ProductName"].ToString();
                    oVehicleSchedule.JobTypeName = (Object)reader["JobTypeName"].ToString();
                    oVehicleSchedule.ReqName = (Object)reader["ReqName"].ToString();
                    oVehicleSchedule.SD1 = (Object)reader["SD1"].ToString();
                    oVehicleSchedule.SDTF1 = (Object)reader["SDTF1"].ToString();
                    oVehicleSchedule.SDTT1 = (Object)reader["SDTT1"].ToString();

                    oVehicleSchedule.RefreshUser();
                    InnerList.Add(oVehicleSchedule);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshAll(int nStatus, int nReqType, String txtID, String txtJobNo, String txtContactNo, String txtCustomerName, String txtLocation)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select VRID, JobNo,CustomerName,Address,Location,ContactNo,ProductCode,ProductName,JobType, " +
                           "JobTypeName,ReqType,ReqName,Remarks,CreateUser,CD,ExpectedDate, ED,EDTF,EDTT,ScheduleDate,IsNull(SD,GetDate())SD, SD SD1, " +
                           "IsNull(SDTF,GetDate())SDTF, SDTF SDTF1, IsNull(SDTT,GetDate())SDTT, SDTT SDTT1, " +
                           "Status,StatusName,IsNoJob,ContactForDateTime, " +
                           "ScheduleRemarks, ReScheduleRemarks, DoneRemarks, PendingRemarks, CancelRemarks, " +
                           "SuspendReasonID,SuspendReason, ByVehicle,VehicleName,DeliveryMan " +
                           "from " +
                           "( " +
                           "Select VR.VRID VRID,IsNull(JobNo,'--')JobNo, IsNull(J.CustomerName,VR.CustomerName)CustomerName, " +
                           "IsNull(FirstAddress,Address)Address,Location,IsNull(Mobile,ContactNo)ContactNo, " +
                           "IsNull(P.Code,PD.ProductCode)ProductCode,IsNull(P.Name,PD.ProductName)ProductName, " +
                           "IsNull(J.JobType,VR.JobType)JobType, JobTypeName=Case  " +
                           "When IsNull(J.JobType,VR.JobType)=1 Then 'FullWarranty' " +
                           "When IsNull(J.JobType,VR.JobType)=2 Then 'Paid' " +
                           "When IsNull(J.JobType,VR.JobType)=3 Then 'ServiceWarranty' " +
                           "else 'Others' end,ReqType, ReqName=CASE When ReQType=1 Then 'Pick-Up' When ReQType=2 Then 'Drop' else 'Others' End, " +
                           "VR.Remarks,CreateUserID,U.UserName CreateUser,VR.CreateDate CD, ExpectedDate, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedDate, 105),11)) ED, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeFrom, 100),7))EDTF, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeTo, 100),7))EDTT, " +
                           "VR.Status Status, " +
                           "StatusName=CASE When VR.Status=0 then 'Requisition' " +
                           "When VR.Status=1 then 'Schedule' " +
                           "When VR.Status=2 then 'ReSchedule' " +
                           "When VR.Status=3 then 'Done' " +
                           "When VR.Status=4 then 'Suspend' " +
                           "When VR.Status=5 then 'Cancel' " +
                           "else 'Others' end, IsNoJob,ContactForDateTime,ScheduleDate, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleDate, 105),11)) SD, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeFrom, 100),7))SDTF, " +
                           "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeTo, 100),7))SDTT, " +
                           "IsNull(VRHSCH.Remarks,'')ScheduleRemarks, IsNull(VRHRSCH.Remarks,'')ReScheduleRemarks, " +
                           "IsNull(VRHDone.Remarks,'')DoneRemarks,IsNull(VRHPen.Remarks,'')PendingRemarks, " +
                           "IsNull(VRHCan.Remarks,'')CancelRemarks, IsNull(SuspendReasonID,0)SuspendReasonID, " +
                           "IsNull(ByVehicle,0)ByVehicle,DeliveryMan, " +
                           "SuspendReason=CASE When SuspendReasonID = 0 Then 'ScheduleNotMatched' " +
                           "When SuspendReasonID = 1 Then 'CustomerWillInfoLater' " +
                           "else 'Others' end, " +
                           "VehicleName=CASE When ByVehicle = 0 Then 'CSD-Covered Van' " +
                           "When ByVehicle = 1 Then 'CSD-Micro Bus' " +
                           "When ByVehicle = 2 Then 'Log-Vehicle' " +
                           "When ByVehicle = 3 Then 'TD-Vehicle' " +
                           "When ByVehicle = 4 Then 'Admin-Vehicle' " +
                           "When ByVehicle = 5 Then 'Rental-Vehicle' " +
                           "When ByVehicle = 6  Then 'Others' " +
                           "else 'Nothings' end " +
                           "From t_CSDVehicleRequisition VR " +
                           "Left Outer Join TELServiceDB.dbo.Job J " +
                           "ON J.JobID=VR.JobID " +
                           "Left Outer Join TELServiceDB.dbo.Product P " +
                           "ON P.ProductID=J.ProductID " +
                           "INNER JOIN t_User U " +
                           "ON U.UserID=VR.CreateUserID " +
                           "Left OUter JOIN v_ProductDetails PD " +
                           "ON PD.ProductID=VR.ProductID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=1) VRHSCH " +
                           "ON VR.VRID=VRHSCH.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=2) VRHRSCH " +
                           "ON VR.VRID=VRHRSCH.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=3) VRHDone " +
                           "ON VR.VRID=VRHDone.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=4) VRHPen " +
                           "ON VR.VRID=VRHPen.VRID " +
                           "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=5) VRHCan " +
                           "ON VR.VRID=VRHCan.VRID " +
                           ")A " +
                           "Where VRID <>0 ";

            if (nStatus > -1)
            {
                sSql = sSql + "AND Status ='" + nStatus + "'";
            }
            if (nReqType > -0)
            {
                sSql = sSql + "AND ReqType ='" + nReqType + "'";
            }
            if (txtID != "")
            {
                sSql = sSql + " AND VRID = '" + txtID + "'";
            }
            if (txtJobNo != "")
            {
                txtJobNo = "%" + txtJobNo + "%";
                sSql = sSql + " AND JobNo LIKE '" + txtJobNo + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND ContactNo LIKE '" + txtContactNo + "'";
            }
            if (txtCustomerName != "")
            {
                txtCustomerName = "%" + txtCustomerName + "%";
                sSql = sSql + " AND CustomerName LIKE '" + txtCustomerName + "'";
            }
            if (txtLocation != "")
            {
                txtLocation = "%" + txtLocation + "%";
                sSql = sSql + " AND Location LIKE '" + txtLocation + "'";
            }
            sSql = sSql + " order by VRID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VehicleSchedule oVehicleSchedule = new VehicleSchedule();

                    oVehicleSchedule.VRID = (int)reader["VRID"];
                    oVehicleSchedule.JobNo = (Object)reader["JobNo"].ToString();
                    oVehicleSchedule.ProductCode = (Object)reader["ProductCode"].ToString();
                    oVehicleSchedule.CustomerName = (Object)reader["CustomerName"].ToString();
                    oVehicleSchedule.ContactNo = (Object)reader["ContactNo"].ToString();
                    oVehicleSchedule.Address = (Object)reader["Address"].ToString();
                    oVehicleSchedule.IsNoJob = int.Parse(reader["IsNoJob"].ToString());
                    oVehicleSchedule.ContactForDateTime = int.Parse(reader["ContactForDateTime"].ToString());
                    oVehicleSchedule.JobType = int.Parse(reader["JobType"].ToString());
                    oVehicleSchedule.Location = (Object)reader["Location"].ToString();
                    oVehicleSchedule.ReqType = int.Parse(reader["ReqType"].ToString());
                    oVehicleSchedule.Remarks = (Object)reader["Remarks"].ToString();
                    oVehicleSchedule.Status = int.Parse(reader["Status"].ToString());
                    oVehicleSchedule.StatusName = (object)reader["StatusName"].ToString();
                    oVehicleSchedule.CreatedBy = (string)reader["CreateUser"];
                    oVehicleSchedule.CreateDate = Convert.ToDateTime(reader["CD"].ToString());
                    oVehicleSchedule.ExpectedDate = (Object)reader["ED"].ToString();
                    oVehicleSchedule.ExpectedTimeFrom = (Object)reader["EDTF"].ToString();
                    oVehicleSchedule.ExpectedTimeTo = (Object)reader["EDTT"].ToString();
                    oVehicleSchedule.ScheduleDate = (Object)reader["SD"].ToString();
                    oVehicleSchedule.ScheduleTimeFrom = (Object)reader["SDTF"].ToString();
                    oVehicleSchedule.ScheduleTimeTo = (Object)reader["SDTT"].ToString();
                    oVehicleSchedule.ScheduleRemarks = (Object)reader["ScheduleRemarks"].ToString();
                    oVehicleSchedule.ReScheduleRemarks = (Object)reader["ReScheduleRemarks"].ToString();
                    oVehicleSchedule.DoneRemarks = (Object)reader["DoneRemarks"].ToString();
                    oVehicleSchedule.PendingRemarks = (Object)reader["PendingRemarks"].ToString();
                    oVehicleSchedule.CancelRemarks = (Object)reader["CancelRemarks"].ToString();
                    oVehicleSchedule.SuspendReasonID = int.Parse(reader["SuspendReasonID"].ToString());
                    //oVehicleSchedule.ByVehicle = int.Parse(reader["ByVehicle"].ToString());
                    oVehicleSchedule.ByVehicle = (int)reader["ByVehicle"];
                    oVehicleSchedule.DeliveryMan = (Object)reader["DeliveryMan"].ToString();
                    oVehicleSchedule.SuspendReason = (Object)reader["SuspendReason"].ToString();
                    oVehicleSchedule.VehicleName = (Object)reader["VehicleName"].ToString();
                    oVehicleSchedule.ProductName = (Object)reader["ProductName"].ToString();
                    oVehicleSchedule.JobTypeName = (Object)reader["JobTypeName"].ToString();
                    oVehicleSchedule.ReqName = (Object)reader["ReqName"].ToString();
                    oVehicleSchedule.SD1 = (Object)reader["SD1"].ToString();
                    oVehicleSchedule.SDTF1 = (Object)reader["SDTF1"].ToString();
                    oVehicleSchedule.SDTT1 = (Object)reader["SDTT1"].ToString();

                    oVehicleSchedule.RefreshUser();
                    InnerList.Add(oVehicleSchedule);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshScheduleReport(DateTime dtFromDate, DateTime dtToDate,int jobLocationId)
        {
            dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select * From  " +
                            "(  " +
                            "Select ScheduleDate,VR.VRID VRID,IsNull(JobNo,'--')JobNo, IsNull(J.CustomerName,VR.CustomerName)CustomerName,    " +
                            "IsNull(FirstAddress,Address)Address,Location,IsNull(Mobile,ContactNo)ContactNo,    " +
                            "IsNull(P.Code,PD.ProductCode)ProductCode,IsNull(P.Name,PD.ProductName)ProductName, JobTypeName=Case     " +
                            "When IsNull(J.JobType,VR.JobType)=1 Then 'W'    " +
                            "When IsNull(J.JobType,VR.JobType)=2 Then 'P'    " +
                            "When IsNull(J.JobType,VR.JobType)=3 Then 'S'    " +
                            "else 'Others' end,   " +
                            "ReqName=CASE When ReQType=1 Then 'Pick-Up' When ReQType=2 Then 'Drop' else 'Others' End,    " +
                            "VR.Remarks,VR.JobLocationId   " +
                            "From t_CSDVehicleRequisition VR    " +
                            "Left Outer Join TELServiceDB.dbo.Job J    " +
                            "ON J.JobID=VR.JobID    " +
                            "Left Outer Join TELServiceDB.dbo.Product P   " +
                            "ON P.ProductID=J.ProductID     " +
                            "Left OUter JOIN v_ProductDetails PD    " +
                            "ON PD.ProductID=VR.ProductID    " +
                            "Where Status IN (1,2) and Type=1  " +
                            "Union All  " +
                            "Select ScheduleDate,VR.VRID VRID,IsNull(JobNo,'--')JobNo, IsNull(J.CustomerName,VR.CustomerName)CustomerName,    " +
                            "IsNull(CustomerAddress,Address)Address,Location,IsNull(MobileNo,ContactNo)ContactNo,    " +
                            "IsNull(P.ProductCode,PD.ProductCode)ProductCode,IsNull(P.ProductName,PD.ProductName)ProductName, JobTypeName=Case     " +
                            "When IsNull(J.JobType,VR.JobType)=1 Then 'W'    " +
                            "When IsNull(J.JobType,VR.JobType)=2 Then 'P'    " +
                            "When IsNull(J.JobType,VR.JobType)=3 Then 'S'    " +
                            "else 'Others' end,   " +
                            "ReqName=CASE When ReQType=1 Then 'Pick-Up' When ReQType=2 Then 'Drop' else 'Others' End,    " +
                            "VR.Remarks,VR.JobLocationId " +
                            "From t_CSDVehicleRequisition VR    " +
                            "Left Outer Join TELSYSDB.dbo.t_CSDJob J    " +
                            "ON J.JobID=VR.JobID    " +
                            "Left Outer Join TELSYSDB.dbo.v_ProductDetails P   " +
                            "ON P.ProductID=J.ProductID     " +
                            "Left OUter JOIN v_ProductDetails PD    " +
                            "ON PD.ProductID=VR.ProductID    " +
                            "Where VR.Status IN (1,2) and Type=2  " +
                            ") Main where ScheduleDate BETWEEN '" + dtFromDate + "' AND '" + dtToDate + "' AND ScheduleDate < '" + dtToDate + "'";
            if (jobLocationId > 0)
            {
                sSql += " AND JobLocationId  =" + jobLocationId;
            }
            

            sSql = sSql + " order by Location ";

            

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VehicleSchedule oVehicleSchedule = new VehicleSchedule();

                    oVehicleSchedule.VRID = (int)reader["VRID"];
                    oVehicleSchedule.JobNo = (Object)reader["JobNo"].ToString();
                    oVehicleSchedule.ProductCode = (Object)reader["ProductCode"].ToString();
                    oVehicleSchedule.CustomerName = (Object)reader["CustomerName"].ToString();
                    oVehicleSchedule.ContactNo = (Object)reader["ContactNo"].ToString();
                    oVehicleSchedule.Address = (Object)reader["Address"].ToString();
                    oVehicleSchedule.Location = (Object)reader["Location"].ToString();
                    oVehicleSchedule.Remarks = (Object)reader["Remarks"].ToString();
                    oVehicleSchedule.ProductName = (Object)reader["ProductName"].ToString();
                    oVehicleSchedule.JobTypeName = (Object)reader["JobTypeName"].ToString();
                    oVehicleSchedule.ReqName = (Object)reader["ReqName"].ToString();


                    oVehicleSchedule.RefreshUser();
                    InnerList.Add(oVehicleSchedule);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void RefreshAllData(DateTime dtFromCreateDate, DateTime dtToCreateDate, bool IsCheckCreateDate, DateTime dtFromExpectedDate, DateTime dtToExpectedDate, bool IsCheckExpectedDate, DateTime dtFromScheduleDate, DateTime dtToScheduleDate, bool IsCheckScheduleDate, int nStatus, int nReqType, String txtID, String txtJobNo, String txtContactNo, String txtCustomerName, String txtLocation,int jobLocationId)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dtToCreateDate = dtToCreateDate.AddDays(1);
            dtToExpectedDate = dtToExpectedDate.AddDays(1);
            dtToScheduleDate = dtToScheduleDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From  " +
                    "(  " +
                    "Select VRID, JobNo,CustomerName,Address,Location,ContactNo,ProductCode,ProductName,JobType,   " +
                    "JobTypeName,ReqType,ReqName,Remarks,CreateUser,CD,ExpectedDate, ED,EDTF,EDTT,ScheduleDate,IsNull(SD,GetDate())SD, SD SD1,   " +
                    "IsNull(SDTF,GetDate())SDTF, SDTF SDTF1, IsNull(SDTT,GetDate())SDTT, SDTT SDTT1,   " +
                    "Status,StatusName,IsNoJob,ContactForDateTime,   " +
                    "ScheduleRemarks, ReScheduleRemarks, DoneRemarks, PendingRemarks, CancelRemarks,   " +
                    "SuspendReasonID,SuspendReason, ByVehicle,VehicleName,DeliveryMan,Type, JobLocationId   " +
                    "from   " +
                    "(   " +
                    "Select VR.VRID VRID,IsNull(JobNo,'--')JobNo, IsNull(J.CustomerName,VR.CustomerName)CustomerName,   " +
                    "IsNull(FirstAddress,Address)Address,Location,IsNull(Mobile,ContactNo)ContactNo,   " +
                    "IsNull(P.Code,PD.ProductCode)ProductCode,IsNull(P.Name,PD.ProductName)ProductName,   " +
                    "IsNull(J.JobType,VR.JobType)JobType, JobTypeName=Case    " +
                    "When IsNull(J.JobType,VR.JobType)=1 Then 'FullWarranty'   " +
                    "When IsNull(J.JobType,VR.JobType)=2 Then 'Paid'   " +
                    "When IsNull(J.JobType,VR.JobType)=3 Then 'ServiceWarranty'   " +
                    "else 'Others' end,ReqType, ReqName=CASE When ReQType=1 Then 'Pick-Up' When ReQType=2 Then 'Drop' else 'Others' End,   " +
                    "VR.Remarks,CreateUserID,U.UserName CreateUser,VR.CreateDate CD, ExpectedDate,   " +
                    "RTRIM(RIGHT(CONVERT(varchar, ExpectedDate, 105),11)) ED,   " +
                    "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeFrom, 100),7))EDTF,   " +
                    "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeTo, 100),7))EDTT,   " +
                    "VR.Status Status,   " +
                    "StatusName=CASE When VR.Status=0 then 'Requisition'   " +
                    "When VR.Status=1 then 'Schedule'   " +
                    "When VR.Status=2 then 'ReSchedule'   " +
                    "When VR.Status=3 then 'Done'   " +
                    "When VR.Status=4 then 'Suspend'   " +
                    "When VR.Status=5 then 'Cancel'   " +
                    "else 'Others' end, IsNoJob,ContactForDateTime,ScheduleDate,   " +
                    "RTRIM(RIGHT(CONVERT(varchar, ScheduleDate, 105),11)) SD,   " +
                    "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeFrom, 100),7))SDTF,   " +
                    "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeTo, 100),7))SDTT,   " +
                    "IsNull(VRHSCH.Remarks,'')ScheduleRemarks, IsNull(VRHRSCH.Remarks,'')ReScheduleRemarks,   " +
                    "IsNull(VRHDone.Remarks,'')DoneRemarks,IsNull(VRHPen.Remarks,'')PendingRemarks,   " +
                    "IsNull(VRHCan.Remarks,'')CancelRemarks, IsNull(SuspendReasonID,0)SuspendReasonID,   " +
                    "IsNull(ByVehicle,0)ByVehicle,DeliveryMan,   " +
                    "SuspendReason=CASE When SuspendReasonID = 0 Then 'ScheduleNotMatched'   " +
                    "When SuspendReasonID = 1 Then 'CustomerWillInfoLater'   " +
                    "else 'Others' end,   " +
                    "VehicleName=CASE When ByVehicle = 0 Then 'CSD-Covered Van'   " +
                    "When ByVehicle = 1 Then 'CSD-Micro Bus'   " +
                    "When ByVehicle = 2 Then 'Log-Vehicle'   " +
                    "When ByVehicle = 3 Then 'TD-Vehicle'   " +
                    "When ByVehicle = 4 Then 'Admin-Vehicle'   " +
                    "When ByVehicle = 5 Then 'Rental-Vehicle'   " +
                    "When ByVehicle = 6  Then 'Others'   " +
                    "else 'Nothings' end,Type, JobLocationId   " +
                    "From t_CSDVehicleRequisition VR   " +
                    "Left Outer Join TELServiceDB.dbo.Job J   " +
                    "ON J.JobID=VR.JobID   " +
                    "Left Outer Join TELServiceDB.dbo.Product P   " +
                    "ON P.ProductID=J.ProductID   " +
                    "INNER JOIN t_User U   " +
                    "ON U.UserID=VR.CreateUserID   " +
                    "Left OUter JOIN v_ProductDetails PD   " +
                    "ON PD.ProductID=VR.ProductID   " +
                    "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=1) VRHSCH   " +
                    "ON VR.VRID=VRHSCH.VRID   " +
                    "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=2) VRHRSCH   " +
                    "ON VR.VRID=VRHRSCH.VRID   " +
                    "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=3) VRHDone   " +
                    "ON VR.VRID=VRHDone.VRID   " +
                    "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=4) VRHPen   " +
                    "ON VR.VRID=VRHPen.VRID   " +
                    "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=5) VRHCan   " +
                    "ON VR.VRID=VRHCan.VRID   " +
                    ")A  Where Type in (1,3)  " +
                    "Union All  " +
                    "Select VRID, JobNo,CustomerName,Address,Location,ContactNo,ProductCode,ProductName,JobType,   " +
                    "JobTypeName,ReqType,ReqName,Remarks,CreateUser,CD,ExpectedDate, ED,EDTF,EDTT,ScheduleDate,IsNull(SD,GetDate())SD, SD SD1,   " +
                    "IsNull(SDTF,GetDate())SDTF, SDTF SDTF1, IsNull(SDTT,GetDate())SDTT, SDTT SDTT1,   " +
                    "Status,StatusName,IsNoJob,ContactForDateTime,   " +
                    "ScheduleRemarks, ReScheduleRemarks, DoneRemarks, PendingRemarks, CancelRemarks,   " +
                    "SuspendReasonID,SuspendReason, ByVehicle,VehicleName,DeliveryMan,Type, JobLocationId   " +
                    "from   " +
                    "(   " +
                    "Select VR.VRID VRID,IsNull(JobNo,'--')JobNo, IsNull(J.CustomerName,VR.CustomerName)CustomerName,   " +
                    "IsNull(CustomerAddress,Address)Address,Location,IsNull(MobileNo,ContactNo)ContactNo,   " +
                    "IsNull(P.ProductCode,PD.ProductCode)ProductCode,IsNull(P.ProductName,PD.ProductName)ProductName,   " +
                    "IsNull(J.JobType,VR.JobType)JobType, JobTypeName=Case    " +
                    "When IsNull(J.JobType,VR.JobType)=1 Then 'FullWarranty'   " +
                    "When IsNull(J.JobType,VR.JobType)=2 Then 'Paid'   " +
                    "When IsNull(J.JobType,VR.JobType)=3 Then 'ServiceWarranty'   " +
                    "else 'Others' end,ReqType, ReqName=CASE When ReQType=1 Then 'Pick-Up' When ReQType=2 Then 'Drop' else 'Others' End,   " +
                    "VR.Remarks,VR.CreateUserID,U.UserName CreateUser,VR.CreateDate CD, ExpectedDate,   " +
                    "RTRIM(RIGHT(CONVERT(varchar, ExpectedDate, 105),11)) ED,   " +
                    "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeFrom, 100),7))EDTF,   " +
                    "RTRIM(RIGHT(CONVERT(varchar, ExpectedTimeTo, 100),7))EDTT,   " +
                    "VR.Status Status,   " +
                    "StatusName=CASE When VR.Status=0 then 'Requisition'   " +
                    "When VR.Status=1 then 'Schedule'   " +
                    "When VR.Status=2 then 'ReSchedule'   " +
                    "When VR.Status=3 then 'Done'   " +
                    "When VR.Status=4 then 'Suspend'   " +
                    "When VR.Status=5 then 'Cancel'   " +
                    "else 'Others' end, IsNoJob,ContactForDateTime,ScheduleDate,   " +
                    "RTRIM(RIGHT(CONVERT(varchar, ScheduleDate, 105),11)) SD,   " +
                    "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeFrom, 100),7))SDTF,   " +
                    "RTRIM(RIGHT(CONVERT(varchar, ScheduleTimeTo, 100),7))SDTT,   " +
                    "IsNull(VRHSCH.Remarks,'')ScheduleRemarks, IsNull(VRHRSCH.Remarks,'')ReScheduleRemarks,   " +
                    "IsNull(VRHDone.Remarks,'')DoneRemarks,IsNull(VRHPen.Remarks,'')PendingRemarks,   " +
                    "IsNull(VRHCan.Remarks,'')CancelRemarks, IsNull(SuspendReasonID,0)SuspendReasonID,   " +
                    "IsNull(ByVehicle,0)ByVehicle,DeliveryMan,   " +
                    "SuspendReason=CASE When SuspendReasonID = 0 Then 'ScheduleNotMatched'   " +
                    "When SuspendReasonID = 1 Then 'CustomerWillInfoLater'   " +
                    "else 'Others' end,   " +
                    "VehicleName=CASE When ByVehicle = 0 Then 'CSD-Covered Van'   " +
                    "When ByVehicle = 1 Then 'CSD-Micro Bus'   " +
                    "When ByVehicle = 2 Then 'Log-Vehicle'   " +
                    "When ByVehicle = 3 Then 'TD-Vehicle'   " +
                    "When ByVehicle = 4 Then 'Admin-Vehicle'   " +
                    "When ByVehicle = 5 Then 'Rental-Vehicle'   " +
                    "When ByVehicle = 6  Then 'Others'   " +
                    "else 'Nothings' end,Type, JobLocationId   " +
                    "From t_CSDVehicleRequisition VR   " +
                    "Left Outer Join TELSysDB.dbo.t_CSDJob J   " +
                    "ON J.JobID=VR.JobID   " +
                    "Left Outer Join TELSysDB.dbo.v_ProductDetails P   " +
                    "ON P.ProductID=J.ProductID   " +
                    "INNER JOIN t_User U   " +
                    "ON U.UserID=VR.CreateUserID   " +
                    "Left OUter JOIN v_ProductDetails PD   " +
                    "ON PD.ProductID=VR.ProductID   " +
                    "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=1) VRHSCH   " +
                    "ON VR.VRID=VRHSCH.VRID   " +
                    "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=2) VRHRSCH   " +
                    "ON VR.VRID=VRHRSCH.VRID   " +
                    "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=3) VRHDone   " +
                    "ON VR.VRID=VRHDone.VRID   " +
                    "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=4) VRHPen   " +
                    "ON VR.VRID=VRHPen.VRID   " +
                    "Left Outer JOIN (Select VRID,Status,Remarks from t_CSDVehicleRequisitionHistory Where Status=5) VRHCan   " +
                    "ON VR.VRID=VRHCan.VRID   " +
                    ")A  Where Type in (2)  " +
                    ") A WHERE 1=1";

            }

            if (IsCheckCreateDate == false)
            {
                sSql = sSql + " and CD between '" + dtFromCreateDate + "' and '" + dtToCreateDate + "' and CD<'" + dtToCreateDate + "' ";
            }
            if (IsCheckScheduleDate == false)
            {
                sSql = sSql + " and ScheduleDate between '" + dtFromScheduleDate + "' and '" + dtToScheduleDate + "' and ScheduleDate<'" + dtToScheduleDate + "' ";
            }
            if (IsCheckExpectedDate == false)
            {
                sSql = sSql + " and ExpectedDate between '" + dtFromExpectedDate + "' and '" + dtToExpectedDate + "' and ExpectedDate<'" + dtToExpectedDate + "' ";
            }
            if (nStatus > -1)
            {
                sSql = sSql + "AND Status ='" + nStatus + "'";
            }
            if (nReqType > -0)
            {
                sSql = sSql + "AND ReqType ='" + nReqType + "'";
            }
            if (txtID != "")
            {
                sSql = sSql + " AND VRID = '" + txtID + "'";
            }
            if (txtJobNo != "")
            {
                txtJobNo = "%" + txtJobNo + "%";
                sSql = sSql + " AND JobNo LIKE '" + txtJobNo + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND ContactNo LIKE '" + txtContactNo + "'";
            }
            if (txtCustomerName != "")
            {
                txtCustomerName = "%" + txtCustomerName + "%";
                sSql = sSql + " AND CustomerName LIKE '" + txtCustomerName + "'";
            }
            if (txtLocation != "")
            {
                txtLocation = "%" + txtLocation + "%";
                sSql = sSql + " AND Location LIKE '" + txtLocation + "'";
            }

            if (jobLocationId > 0)
            {
                sSql += " and JobLocationId = " + jobLocationId;
            }

            sSql = sSql + " order by VRID ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VehicleSchedule oVehicleSchedule = new VehicleSchedule();

                    oVehicleSchedule.VRID = (int)reader["VRID"];
                    oVehicleSchedule.JobNo = (Object)reader["JobNo"].ToString();
                    oVehicleSchedule.ProductCode = (Object)reader["ProductCode"].ToString();
                    oVehicleSchedule.CustomerName = (Object)reader["CustomerName"].ToString();
                    oVehicleSchedule.ContactNo = (Object)reader["ContactNo"].ToString();
                    oVehicleSchedule.Address = (Object)reader["Address"].ToString();
                    oVehicleSchedule.IsNoJob = int.Parse(reader["IsNoJob"].ToString());
                    oVehicleSchedule.ContactForDateTime = int.Parse(reader["ContactForDateTime"].ToString());
                    oVehicleSchedule.JobType = int.Parse(reader["JobType"].ToString());
                    oVehicleSchedule.Location = (Object)reader["Location"].ToString();
                    oVehicleSchedule.ReqType = int.Parse(reader["ReqType"].ToString());
                    oVehicleSchedule.Remarks = (Object)reader["Remarks"].ToString();
                    oVehicleSchedule.Status = int.Parse(reader["Status"].ToString());
                    oVehicleSchedule.StatusName = (object)reader["StatusName"].ToString();
                    oVehicleSchedule.CreatedBy = (string)reader["CreateUser"];
                    oVehicleSchedule.CreateDate = Convert.ToDateTime(reader["CD"].ToString());
                    oVehicleSchedule.ExpectedDate = (Object)reader["ED"].ToString();
                    oVehicleSchedule.ExpectedTimeFrom = (Object)reader["EDTF"].ToString();
                    oVehicleSchedule.ExpectedTimeTo = (Object)reader["EDTT"].ToString();
                    oVehicleSchedule.ScheduleDate = (Object)reader["SD"].ToString();
                    oVehicleSchedule.ScheduleTimeFrom = (Object)reader["SDTF"].ToString();
                    oVehicleSchedule.ScheduleTimeTo = (Object)reader["SDTT"].ToString();
                    oVehicleSchedule.ScheduleRemarks = (Object)reader["ScheduleRemarks"].ToString();
                    oVehicleSchedule.ReScheduleRemarks = (Object)reader["ReScheduleRemarks"].ToString();
                    oVehicleSchedule.DoneRemarks = (Object)reader["DoneRemarks"].ToString();
                    oVehicleSchedule.PendingRemarks = (Object)reader["PendingRemarks"].ToString();
                    oVehicleSchedule.CancelRemarks = (Object)reader["CancelRemarks"].ToString();
                    oVehicleSchedule.SuspendReasonID = int.Parse(reader["SuspendReasonID"].ToString());
                    //oVehicleSchedule.ByVehicle = int.Parse(reader["ByVehicle"].ToString());
                    oVehicleSchedule.ByVehicle = (int)reader["ByVehicle"];
                    oVehicleSchedule.DeliveryMan = (Object)reader["DeliveryMan"].ToString();
                    oVehicleSchedule.SuspendReason = (Object)reader["SuspendReason"].ToString();
                    oVehicleSchedule.VehicleName = (Object)reader["VehicleName"].ToString();
                    oVehicleSchedule.ProductName = (Object)reader["ProductName"].ToString();
                    oVehicleSchedule.JobTypeName = (Object)reader["JobTypeName"].ToString();
                    oVehicleSchedule.ReqName = (Object)reader["ReqName"].ToString();
                    oVehicleSchedule.SD1 = (Object)reader["SD1"].ToString();
                    oVehicleSchedule.SDTF1 = (Object)reader["SDTF1"].ToString();
                    oVehicleSchedule.SDTT1 = (Object)reader["SDTT1"].ToString();

                    oVehicleSchedule.RefreshUser();
                    InnerList.Add(oVehicleSchedule);
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

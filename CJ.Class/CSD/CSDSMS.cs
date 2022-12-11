// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Jul 05, 2012
// Time :  09:34 PM
// Description: Class for CSD Auto SMS
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
    public class CSDSMS
    {
        private int _nSMSID;
        private string _sSMSCode;
        private int _nJobID;
        private string _sSMSText;
        private string _sMobileNo;
        private int _nStatus;
        private Object _dCreateDate;
        private int _nSMSType;
        private Object _nEditUserID;
        private Object _nCancelUserID;
        private Object _sCancelReason;
        private Object _dCancelDate;
        private Object _nSendUserID;
        private Object _dSendDate;
        private Object _nReSentUserID;
        private Object _dReSentDate;
        private Object _nReGenReqUserID;
        private Object _dReGenReqDate;
        private Object _sReGenReqReason;

        private string _sJobNo;
        private string _sSMSTypeName;
        private string _sStatusName;
        private int _sCharCount;
        private int _nSMSlenth;

        private Object _sSentBy;
        private Object _sReSentBy;
        private Object _sEditedBy;
        private Object _sReGenReqBy;
        private Object _sCancelledBy;
        private int _nSvrStatus;
        private Object _sServerStatus;

        private User _oUser;

        //TELSysDB.dbo.t_SMSMessage
        private int _nSMSMessageID;
        private DateTime _dRequestDate;
        private string _sSMSTextT;
        private int _nSMSTypeT;
        private string _sSingleMobileNo;
        private Object _dSendDateT;
        private int _nStatusT;
        private string _sSubmittedBy;
        private Object _sUserGroupName;
        private int _nSuccessCount;
        private int _nfailCount;


        //TELServiceDB.dbo.CallCentJobList
        private int _nCallCentJobListID;
        private int _nJobIDC;
        private Object _sInstruction;
        private Object _dFollowUpDate;
        private int _nUserIDC;
        private int _nCallType;
        private int _nResponseType;
        private int _nIsAttend;
        private string _sCallRemarks;
        private Object _dCallCreationDate;
        private int _nIsBanForever;

        //TELServiceDB.dbo.Communication
        private int _nID;
        private int _nJobIDCom;
        private string _sRemarks;
        private Object _dNextCommDate;
        private int _nEnteredBy;
        private DateTime _dEntryDate;
        private int _nResponseTypeCom;
        private int _nCallTypeCom;
        private int _nCallCenterJobListID;
        private int _sCCJLID;

        //ISV Paid Job History
        private int _nPaidJobHistoryID;
        private int _nPaidJobID;
        private int _nStatusPJH;
        private int _nUserIDPJH;
        private DateTime _dStatusDatePJH;
        private Object _sRemarksPJH;

        private int _nCommunicationStatus;
        private string _sCommuRemarks;

        /// <summary>
        /// Get set property for SMSID
        /// </summary>
        public int SMSID
        {
            get { return _nSMSID; }
            set { _nSMSID = value; }
        }
        /// <summary>
        /// Get set property for SMSCode
        /// </summary>
        public string SMSCode
        {
            get { return _sSMSCode; }
            set { _sSMSCode = value; }
        }
        /// <summary>
        /// Get set property for JobID
        /// </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }
        /// <summary>
        /// Get set property for SMSText
        /// </summary>
        public string SMSText
        {
            get { return _sSMSText; }
            set { _sSMSText = value; }
        }
        /// <summary>
        /// Get set property for MobileNo
        /// </summary>
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value; }
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
        /// Get set property for CreateDate
        /// </summary>
        public Object CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        /// <summary>
        /// Get set property for SMSType
        /// </summary>
        public int SMSType
        {
            get { return _nSMSType; }
            set { _nSMSType = value; }
        }
        /// <summary>
        /// Get set property for EditUserID
        /// </summary>
        public Object EditUserID
        {
            get { return _nEditUserID; }
            set { _nEditUserID = value; }
        }
        /// <summary>
        /// Get set property for CancelUserID
        /// </summary>
        public Object CancelUserID
        {
            get { return _nCancelUserID; }
            set { _nCancelUserID = value; }
        }
        /// <summary>
        /// Get set property for CancelReason
        /// </summary>
        public Object CancelReason
        {
            get { return _sCancelReason; }
            set { _sCancelReason = value; }
        }
        /// <summary>
        /// Get set property for CancelDate
        /// </summary>
        public Object CancelDate
        {
            get { return _dCancelDate; }
            set { _dCancelDate = value; }
        }
        /// <summary>
        /// Get set property for SendUserID
        /// </summary>
        public Object SendUserID
        {
            get { return _nSendUserID; }
            set { _nSendUserID = value; }
        }
        /// <summary>
        /// Get set property for SendDate
        /// </summary>
        public Object SendDate
        {
            get { return _dSendDate; }
            set { _dSendDate = value; }
        }
        /// <summary>
        /// Get set property for ReSentUserID
        /// </summary>
        public Object ReSentUserID
        {
            get { return _nReSentUserID; }
            set { _nReSentUserID = value; }
        }
        /// <summary>
        /// Get set property for ReSentDate
        /// </summary>
        public Object ReSentDate
        {
            get { return _dReSentDate; }
            set { _dReSentDate = value; }
        }
        /// <summary>
        /// Get set property for ReGenReqUserID
        /// </summary>
        public Object ReGenReqUserID
        {
            get { return _nReGenReqUserID; }
            set { _nReGenReqUserID = value; }
        }
        /// <summary>
        /// Get set property for ReGenReqDate
        /// </summary>
        public Object ReGenReqDate
        {
            get { return _dReGenReqDate; }
            set { _dReGenReqDate = value; }
        }
        /// <summary>
        /// Get set property for ReGenReqReason
        /// </summary>
        public Object ReGenReqReason
        {
            get { return _sReGenReqReason; }
            set { _sReGenReqReason = value; }
        }

        /// <summary>
        /// Get set property for JobNo
        /// </summary>
        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value; }
        }
        /// <summary>
        /// Get set property for SMSTypeName
        /// </summary>
        public string SMSTypeName
        {
            get { return _sSMSTypeName; }
            set { _sSMSTypeName = value; }
        }
        /// <summary>
        /// Get set property for StatusName
        /// </summary>
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value; }
        }
        /// <summary>
        /// Get set property for CharCount
        /// </summary>
        public int CharCount
        {
            get { return _sCharCount; }
            set { _sCharCount = value; }
        }
        /// <summary>
        /// Get set property for SMSlenth
        /// </summary>
        public int SMSlenth
        {
            get { return _nSMSlenth; }
            set { _nSMSlenth = value; }
        }
        /// <summary>
        /// Get set property for SentBy
        /// </summary>
        public Object SentBy
        {
            get { return _sSentBy; }
            set { _sSentBy = value; }
        }
        /// <summary>
        /// Get set property for ReSentBy
        /// </summary>
        public Object ReSentBy
        {
            get { return _sReSentBy; }
            set { _sReSentBy = value; }
        }
        /// <summary>
        /// Get set property for EditedBy
        /// </summary>
        public Object EditedBy
        {
            get { return _sEditedBy; }
            set { _sEditedBy = value; }
        }
        /// <summary>
        /// Get set property for ReGenReqBy
        /// </summary>
        public Object ReGenReqBy
        {
            get { return _sReGenReqBy; }
            set { _sReGenReqBy = value; }
        }
        /// <summary>
        /// Get set property for CancelledBy
        /// </summary>
        public Object CancelledBy
        {
            get { return _sCancelledBy; }
            set { _sCancelledBy = value; }
        }
        /// <summary>
        /// Get set property for SvrStatus
        /// </summary>
        public int SvrStatus
        {
            get { return _nSvrStatus; }
            set { _nSvrStatus = value; }
        }
        /// <summary>
        /// Get set property for ServerStatus
        /// </summary>
        public Object ServerStatus
        {
            get { return _sServerStatus; }
            set { _sServerStatus = value; }
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

        /// <summary>
        /// Get set property for SMSMessageID
        /// </summary>
        public int SMSMessageID
        {
            get { return _nSMSMessageID; }
            set { _nSMSMessageID = value; }
        }
        /// <summary>
        /// Get set property for RequestDate
        /// </summary>
        public DateTime RequestDate
        {
            get { return _dRequestDate; }
            set { _dRequestDate = value; }
        }
        /// <summary>
        /// Get set property for SMSTextT
        /// </summary>
        public string SMSTextT
        {
            get { return _sSMSTextT; }
            set { _sSMSTextT = value; }
        }
        /// <summary>
        /// Get set property for SMSTypeT
        /// </summary>
        public int SMSTypeT
        {
            get { return _nSMSTypeT; }
            set { _nSMSTypeT = value; }
        }
        /// <summary>
        /// Get set property for SingleMobileNo
        /// </summary>
        public string SingleMobileNo
        {
            get { return _sSingleMobileNo; }
            set { _sSingleMobileNo = value; }
        }
        /// <summary>
        /// Get set property for SendDateT
        /// </summary>
        public Object SendDateT
        {
            get { return _dSendDateT; }
            set { _dSendDateT = value; }
        }
        /// <summary>
        /// Get set property for StatusT
        /// </summary>
        public int StatusT
        {
            get { return _nStatusT; }
            set { _nStatusT = value; }
        }
        /// <summary>
        /// Get set property for SubmittedBy
        /// </summary>
        public string SubmittedBy
        {
            get { return _sSubmittedBy; }
            set { _sSubmittedBy = value; }
        }
        /// <summary>
        /// Get set property for UserGroupName
        /// </summary>
        public Object UserGroupName
        {
            get { return _sUserGroupName; }
            set { _sUserGroupName = value; }
        }
        /// <summary>
        /// Get set property for SuccessCount
        /// </summary>
        public int SuccessCount
        {
            get { return _nSuccessCount; }
            set { _nSuccessCount = value; }
        }
        /// <summary>
        /// Get set property for failCount
        /// </summary>
        public int failCount
        {
            get { return _nfailCount; }
            set { _nfailCount = value; }
        }


        /// <summary>
        /// Get set property for CallCentJobListID
        /// </summary>
        public int CallCentJobListID
        {
            get { return _nCallCentJobListID; }
            set { _nCallCentJobListID = value; }
        }
        /// <summary>
        /// Get set property for JobIDC
        /// </summary>
        public int JobIDC
        {
            get { return _nJobIDC; }
            set { _nJobIDC = value; }
        }
        /// <summary>
        /// Get set property for Instruction
        /// </summary>
        public Object Instruction
        {
            get { return _sInstruction; }
            set { _sInstruction = value; }
        }
        /// <summary>
        /// Get set property for FollowUpDate
        /// </summary>
        public Object FollowUpDate
        {
            get { return _dFollowUpDate; }
            set { _dFollowUpDate = value; }
        }
        /// <summary>
        /// Get set property for UserIDC
        /// </summary>
        public int UserIDC
        {
            get { return _nUserIDC; }
            set { _nUserIDC = value; }
        }
        /// <summary>
        /// Get set property for CallType
        /// </summary>
        public int CallType
        {
            get { return _nCallType; }
            set { _nCallType = value; }
        }
        /// <summary>
        /// Get set property for ResponseType
        /// </summary>
        public int ResponseType
        {
            get { return _nResponseType; }
            set { _nResponseType = value; }
        }
        /// <summary>
        /// Get set property for IsAttend
        /// </summary>
        public int IsAttend
        {
            get { return _nIsAttend; }
            set { _nIsAttend = value; }
        }
        /// <summary>
        /// Get set property for CallRemarks
        /// </summary>
        public string CallRemarks
        {
            get { return _sCallRemarks; }
            set { _sCallRemarks = value; }
        }
        /// <summary>
        /// Get set property for CallCreationDate
        /// </summary>
        public Object CallCreationDate
        {
            get { return _dCallCreationDate; }
            set { _dCallCreationDate = value; }
        }
        /// <summary>
        /// Get set property for IsBanForever
        /// </summary>
        public int IsBanForever
        {
            get { return _nIsBanForever; }
            set { _nIsBanForever = value; }
        }


        /// <summary>
        /// Get set property for ID
        /// </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
        /// <summary>
        /// Get set property for JobIDCom
        /// </summary>
        public int JobIDCom
        {
            get { return _nJobIDCom; }
            set { _nJobIDCom = value; }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }
        /// <summary>
        /// Get set property for NextCommDate
        /// </summary>
        public Object NextCommDate
        {
            get { return _dNextCommDate; }
            set { _dNextCommDate = value; }
        }
        /// <summary>
        /// Get set property for EnteredBy
        /// </summary>
        public int EnteredBy
        {
            get { return _nEnteredBy; }
            set { _nEnteredBy = value; }
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
        /// Get set property for ResponseTypeCom
        /// </summary>
        public int ResponseTypeCom
        {
            get { return _nResponseTypeCom; }
            set { _nResponseTypeCom = value; }
        }
        /// <summary>
        /// Get set property for CallTypeCom
        /// </summary>
        public int CallTypeCom
        {
            get { return _nCallTypeCom; }
            set { _nCallTypeCom = value; }
        }
        /// <summary>
        /// Get set property for CallCenterJobListID
        /// </summary>
        public int CallCenterJobListID
        {
            get { return _nCallCenterJobListID; }
            set { _nCallCenterJobListID = value; }
        }
        /// <summary>
        /// Get set property for CCJLID
        /// </summary>
        public int CCJLID
        {
            get { return _sCCJLID; }
            set { _sCCJLID = value; }
        }

        /// <summary>
        /// Get set property for PaidJobHistoryID
        /// </summary>
        public int PaidJobHistoryID
        {
            get { return _nPaidJobHistoryID; }
            set { _nPaidJobHistoryID = value; }
        }
        /// <summary>
        /// Get set property for PaidJobID
        /// </summary>
        public int PaidJobID
        {
            get { return _nPaidJobID; }
            set { _nPaidJobID = value; }
        }
        /// <summary>
        /// Get set property for StatusPJH
        /// </summary>
        public int StatusPJH
        {
            get { return _nStatusPJH; }
            set { _nStatusPJH = value; }
        }
        /// <summary>
        /// Get set property for UserIDPJH
        /// </summary>
        public int UserIDPJH
        {
            get { return _nUserIDPJH; }
            set { _nUserIDPJH = value; }
        }
        /// <summary>
        /// Get set property for StatusDatePJH
        /// </summary>
        public DateTime StatusDatePJH
        {
            get { return _dStatusDatePJH; }
            set { _dStatusDatePJH = value; }
        }
        /// <summary>
        /// Get set property for RemarksPJH
        /// </summary>
        public Object RemarksPJH
        {
            get { return _sRemarksPJH; }
            set { _sRemarksPJH = value; }
        }


        /// <summary>
        /// Get set property for CommunicationStatus
        /// </summary>
        public int CommunicationStatus
        {
            get { return _nCommunicationStatus; }
            set { _nCommunicationStatus = value; }
        }
        /// <summary>
        /// Get set property for CommuRemarks
        /// </summary>
        public string CommuRemarks
        {
            get { return _sCommuRemarks; }
            set { _sCommuRemarks = value; }
        }
        SMSMaker _oSMSMaker;

        public void Add()
        {          
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            _oSMSMaker = new SMSMaker();
            try
            {
                sSql = "INSERT INTO t_CSDSMS Select Final.SMSCode SMSCode, Final.JobID JobID,SMS, Mobile,0 Status,getdate(),Type, " +
                        "Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null " +
                        "From " +
                        "( " +
                    //Installation Schedule for First Time...//Schedule Date-time
                        "Select SMSCode, JobID,JobNo,Type,Mobile,SMS,len(SMS)CharCount,JCD " +
                        "From " +
                        "( " +
                        "Select SMSCode,JobID,JobNo, 0 AS Type, Mobile,JCD,  " +
                        "('Dear Sir, '+IsNull(ASGName,'Product')+ ' Installation ' +'(Job#'+JobNo+')'+ ' scheduled on ' " +
                        "+Rem+' For Cont." + _oSMSMaker.GetHelpline(0) + " [" + _oSMSMaker.GetServiceTime(0) + "]. B/Rgds, CSD-TEL.')SMS from " +
                        "( " +
                        "Select J.JobID JobID,JobNo, ASGName,SerialNo, JobStatus, JobCreationDate JCD, JobType, ServiceType, JobStat.Remarks Rem, " +
                        "(JobNo+'4'+'442')SMSCode, Mobile " +
                        "from TELServiceDB.dbo.Job J  " +
                        "INNER JOIN  " +
                        "( " +
                        "Select JHM.ID,JHM.JobID,Status, Remarks " +
                        "From " +
                        "(Select Max(ID)ID,JobID from TELServiceDB.dbo.JobHistory JH Where Status='Pending' Group by JobID) JH " +
                        "INNER JOIN (Select * from TELServiceDB.dbo.JobHistory) JHM  " +
                        "ON JH.ID=JHM.ID " +
                        ") JobStat " +
                        "ON JobStat.JobID=J.JobID " +
                        "INNER JOIN TELServiceDB.dbo.Product P " +
                        "ON P.ProductID=J.productID " +
                        "Left outer JOIN (Select ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) PD " +
                        "ON PD.ProductCode=P.Code " +
                        "Where IsDelivered=0 AND ServiceType=4 AND PendingID=442 " +
                        ")A " +
                        ")A UNION ALL " +
                    //---------------------------------------------------------------------------------------------------------------------
                    //Installation Schedule for Second Time...//Re-Schedule Date-time
                        "Select SMSCode, JobID,JobNo,Type,Mobile,SMS,len(SMS)CharCount,JCD " +
                        "From " +
                        "( " +
                        "Select SMSCode,JobID,JobNo, 1 AS Type, Mobile,JCD,  " +
                        "('Dear Sir, '+IsNull(ASGName,'Product')+ ' Installation ' +'(Job#'+JobNo+')'+ ' re-scheduled on ' " +
                        "+Rem+' For Cont." + _oSMSMaker.GetHelpline(1) + " [" + _oSMSMaker.GetServiceTime(1) + "]. B/Rgds, CSD-TEL.')SMS from " +
                        "( " +
                        "Select J.JobID JobID,JobNo, ASGName,SerialNo, JobStatus, JobCreationDate JCD, JobType, ServiceType, JobStat.Remarks Rem, " +
                        "(JobNo+'4'+'434')SMSCode, Mobile " +
                        "from TELServiceDB.dbo.Job J  " +
                        "INNER JOIN  " +
                        "( " +
                        "Select JHM.ID,JHM.JobID,Status, Remarks " +
                        "From " +
                        "(Select Max(ID)ID,JobID from TELServiceDB.dbo.JobHistory JH Where Status='Pending' Group by JobID) JH " +
                        "INNER JOIN (Select * from TELServiceDB.dbo.JobHistory) JHM  " +
                        "ON JH.ID=JHM.ID " +
                        ") JobStat " +
                        "ON JobStat.JobID=J.JobID " +
                        "INNER JOIN TELServiceDB.dbo.Product P " +
                        "ON P.ProductID=J.productID " +
                        "Left outer JOIN (Select ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) PD " +
                        "ON PD.ProductCode=P.Code " +
                        "Where IsDelivered=0 AND ServiceType=4 AND PendingID=434 " +
                        ")B " +
                        ")B UNION ALL " +
                    //---------------------------------------------------------------------------------------------------------------------
                    //Home Call Schedule for first Time//Schedule Date-time
                        "Select SMSCode, JobID,JobNo,Type,Mobile,SMS,len(SMS)CharCount,JCD  " +
                        "From  " +
                        "(  " +
                        "Select SMSCode,JobID,JobNo,2 Type,Mobile,JCD,   " +
                        "('Dear Sir, HomeCall Service ' +'('+'Job#'+JobNo+')'+ ' for '+IsNull(ASGName,'Product')+ ' scheduled on '  " +
                        "+Rem+' For Cont." + _oSMSMaker.GetHelpline(2) + " [" + _oSMSMaker.GetServiceTime(2) + "]. B/Rgds, CSD-TEL.')SMS from  " +
                        "(  " +
                        "Select J.JobID,JobNo, SerialNo, JobStatus, ASGName,JobCreationDate JCD, JobType, ServiceType, JobStat.Remarks Rem,  " +
                        "(JobNo+'2'+'442')SMSCode,Mobile  " +
                        "from TELServiceDB.dbo.Job J  " +
                        "INNER JOIN   " +
                        "(  " +
                        "Select JHM.ID,JHM.JobID,Status, Remarks  " +
                        "From  " +
                        "(Select Max(ID)ID,JobID from TELServiceDB.dbo.JobHistory JH Where Status='Pending' Group by JobID) JH  " +
                        "INNER JOIN (Select * from TELServiceDB.dbo.JobHistory) JHM   " +
                        "ON JH.ID=JHM.ID  " +
                        ") JobStat  " +
                        "ON JobStat.JobID=J.JobID  " +
                        "INNER JOIN TELServiceDB.dbo.Product P  " +
                        "ON P.ProductID=J.productID  " +
                        "Left outer JOIN (Select ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) PD  " +
                        "ON PD.ProductCode=P.Code  " +
                        "Where IsDelivered=0 AND ServiceType=2 AND PendingID=442  " +
                        ")C  " +
                        ")C " +
                        ")Final " +
                        "Where JCD>='15-Jul-2012' AND SMSCode NOT IN (Select SMSCode From t_CSDSMS Where Status <>4)";

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
        public void Add3()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            _oSMSMaker = new SMSMaker();
            try
            {
                sSql = "INSERT INTO t_CSDSMS Select Final.SMSCode SMSCode, Final.JobID JobID,SMS, Mobile,0 Status,getdate(),Type, " +
                        "Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null " +
                        "From " +
                        "( " +
                    
                    //---------------------------------------------------------------------------------------------------------------------
                    //Home Call Schedule for Second Time...//Re-Schedule Date-time
                        "Select SMSCode, JobID,JobNo,Type,Mobile,SMS,len(SMS)CharCount,JCD  " +
                        "From  " +
                        "(  " +
                        "Select SMSCode,JobID,JobNo,3 Type,Mobile,JCD,   " +
                        "('Dear Sir, HomeCall Service ' +'('+'Job#'+JobNo+')'+ ' for '+IsNull(ASGName,'Product')+ ' re-scheduled on '  " +
                        "+Rem+' For Cont." + _oSMSMaker.GetHelpline(3) + " [" + _oSMSMaker.GetServiceTime(3) + "]. B/Rgds, CSD-TEL.')SMS from  " +
                        "(  " +
                        "Select J.JobID,JobNo, SerialNo, JobStatus, ASGName,JobCreationDate JCD, JobType, ServiceType, JobStat.Remarks Rem,  " +
                        "(JobNo+'2'+'434')SMSCode,Mobile  " +
                        "from TELServiceDB.dbo.Job J  " +
                        "INNER JOIN   " +
                        "(  " +
                        "Select JHM.ID,JHM.JobID,Status, Remarks  " +
                        "From  " +
                        "(Select Max(ID)ID,JobID from TELServiceDB.dbo.JobHistory JH Where Status='Pending' Group by JobID) JH  " +
                        "INNER JOIN (Select * from TELServiceDB.dbo.JobHistory) JHM   " +
                        "ON JH.ID=JHM.ID  " +
                        ") JobStat  " +
                        "ON JobStat.JobID=J.JobID  " +
                        "INNER JOIN TELServiceDB.dbo.Product P  " +
                        "ON P.ProductID=J.productID  " +
                        "Left outer JOIN (Select ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) PD  " +
                        "ON PD.ProductCode=P.Code  " +
                        "Where IsDelivered=0 AND ServiceType=2 AND PendingID=434  " +
                        ")D  " +
                        ")D UNION ALL " +

                        //---------------------------------------------------------------------------------------------------------------------
                    //Walk-In Estimated Job
                        "Select SMSCode, JobID,JobNo,type,Mobile,SMS,len(SMS)CharCount,JCD " +
                        "From  " +
                        "(  " +
                        "Select SMSCode, JobID,JobNo,4 type,Mobile,JCD,   " +
                        "('Dear Sir, Your '+IsNull(ASGName,'Product')+ ' ('+'Job#'+JobNo+')'+' repairing estimate is Tk.'  " +
                        "+ parsename(convert(varchar,convert(money,Total), 1),2) +'(Mat='+ " +
                        "+ parsename(convert(varchar,convert(money,SPAmt), 1),2)+'+'+'S/Charge='  " +
                        "+ parsename(convert(varchar,convert(money,SCV), 1),2)+') Pls confirm ASAP " + _oSMSMaker.GetHelpline(4) + " [" + _oSMSMaker.GetServiceTime(4) + "] " +
                        "B/Rgds,CSD-TEL')SMS  " +
                        "from  " +
                        "(  " +
                        "Select J.JobID,JobNo, J.ProductID,ASGName,SerialNo, JobStatus, JobCreationDate JCD, JobType, ServiceType, JobStat.Remarks Rem,  " +
                        "(JobNo+'7'+'EST')SMSCode,Mobile,IsNull(SPAmt,0)SPAmt, CSC.SCV, (IsNull(SPAmt,0)+CSC.SCV) Total  " +
                        "from TELServiceDB.dbo.Job J  " +
                        "INNER JOIN   " +
                        "(  " +
                        "Select JHM.ID,JHM.JobID,Status, Remarks  " +
                        "From  " +
                        "(Select Max(ID)ID,JobID from TELServiceDB.dbo.JobHistory JH Where Status='Estimated' Group by JobID) JH  " +
                        "INNER JOIN (Select * from TELServiceDB.dbo.JobHistory) JHM   " +
                        "ON JH.ID=JHM.ID  " +
                        ") JobStat  " +
                        "ON JobStat.JobID=J.JobID  " +
                        "Left OUTER JOIN  " +
                        "(   " +
                        "Select JobID, Sum(SPAmt)SPAmt From  " +
                        "(  " +
                        "Select JobID, UP.SparePartID,Quantity,    " +
                        "(SP.SalePrice* Quantity)SPAmt  " +
                        "from (Select * from TELServiceDB.dbo.UnavailableParts Where PurposeType=2) UP  " +
                        "INNER JOIN TELServiceDB.dbo.SpareParts SP  " +
                        "ON SP.ID= UP.SparePartID  " +
                        ")A  " +
                        "Group BY JobID  " +
                        ")SPUse  " +
                        "ON SPUse.JobID=J.JobID  " +
                        "Inner JOIN TELServiceDB.dbo.Product P  " +
                        "ON P.ProductID=J.ProductID  " +
                        "INNER JOIN   " +
                        "(Select CategoryID, PaidAmt sCV from TELServiceDB.dbo.CategorySerCharge Where ChargeType=1) CSC  " +
                        "ON CSC.CategoryID=P.CategoryID  " +
                        "Left outer JOIN (Select ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) PD  " +
                        "ON PD.ProductCode=P.Code  " +
                        "Where IsDelivered=0 AND JobStatus=7  " +
                        ")E  " +
                        ")E  " +
                        ")Final " +
                        "Where JCD>='15-Jul-2012' AND SMSCode NOT IN (Select SMSCode From t_CSDSMS Where Status <>4)";

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

        public void Add2()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            _oSMSMaker = new SMSMaker();
            try
            {
                sSql = "INSERT INTO t_CSDSMS Select Final.SMSCode SMSCode, Final.JobID JobID,SMS, Mobile,0 Status,getdate(),Type, " +
                        "Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null " +
                        "From " +
                        "( " +
                    //Product Receive by TEL Vehicle
                            "Select SMSCode, JobID,JobNo,Type,Mobile,SMS,len(SMS)CharCount,JCD " +
                            "From " +
                            "( " +
                            "Select SMSCode, JobID,JobNo,5 Type,Mobile,JCD,  " +
                            "('Dear Sir, Received '+IsNull(ASGName,'Product')+' (Job#'+JobNo+')'+' Expected Delivery Date is '+EDD +'. For Cont." + _oSMSMaker.GetHelpline(5) + " [" + _oSMSMaker.GetServiceTime(5) + "]. " +
                            " B/Rgds, CSD-TEL.')SMS from " +
                            "( " +
                            "Select J.JobID,JobNo, CarryingCostIn, SerialNo, JobStatus, Convert(Varchar,JobCreationDate,106)JCD, " +
                            "Convert(Varchar,DeliveryDate,106)EDD, JobType, ServiceType, J.ProductID,ASGName, " +
                            "(JobNo+'1'+'VEH')SMSCode,Mobile " +
                            "from TELServiceDB.dbo.Job J " +
                            "INNER JOIN TELServiceDB.dbo.Product P " +
                            "ON P.ProductID=J.productID " +
                            "Left outer JOIN (Select ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) PD " +
                            "ON PD.ProductCode=P.Code " +
                            "Where IsDelivered=0 AND ServiceType=1 AND CarryingCostIn>0 " +
                            ")F " +
                            ")F UNION ALL " +
                            //---------------------------------------------------------------------------------------------------------------------
                            //Product Receive by Courier

                            "Select SMSCode, JobID,JobNo,Type,Mobile,SMS,len(SMS)CharCount,JCD " +
                            "From " +
                            "( " +
                            "Select SMSCode, JobID,JobNo,6 Type,Mobile,JCD,  " +
                            "('Dear Sir, Received '+IsNull(ASGName,'Product')+' (Job#'+JobNo+')'+' Expected Delivery Date is '+EDD +'. For Cont." + _oSMSMaker.GetHelpline(6) + " [" + _oSMSMaker.GetServiceTime(6) + "]. " +
                            " B/Rgds, CSD-TEL.')SMS from " +
                            "( " +
                            "Select J.JobID,JobNo, CarryingCostIn, SerialNo, JobStatus, Convert(Varchar,JobCreationDate,106)JCD, " +
                            "Convert(Varchar,DeliveryDate,106)EDD, JobType, ServiceType, J.ProductID,ASGName, " +
                            "(JobNo+'1'+'VEH')SMSCode,Mobile " +
                            "from TELServiceDB.dbo.Job J " +
                            "INNER JOIN TELServiceDB.dbo.Product P " +
                            "ON P.ProductID=J.productID " +
                            "Left outer JOIN (Select ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) PD " +
                            "ON PD.ProductCode=P.Code " +
                            "Where IsDelivered=0 AND ServiceType=1 AND ByCurrier=1 " +
                            ")G  " +
                            ")G UNION ALL " +
                            //---------------------------------------------------------------------------------------------------------------------
                            //Product Delivery Information (Walk-In, Warranty)

                            "Select SMSCode, JobID,JobNo,Type,Mobile,SMS,len(SMS)CharCount,JCD " +
                            "From " +
                            "( " +
                            "Select SMSCode, JobID,JobNo,7 Type,Mobile,JCD,  " +
                            "('Dear Sir, Your '+IsNull(ASGName,'Product')+'('+'Job#'+JobNo+')'+' is ready for delivery. Pls collect ASAP. For Cont." + _oSMSMaker.GetHelpline(7) + " [" + _oSMSMaker.GetServiceTime(7) + "]. " +
                            "B/Rgds, CSD-TEL.')SMS from " +
                            "( " +
                            "Select J.JobID,JobNo, CarryingCostIn, SerialNo, JobStatus, Convert(Varchar,JobCreationDate,106)JCD, " +
                            "Convert(Varchar,DeliveryDate,106)EDD, JobType, ServiceType, J.ProductID,ASGName, " +
                            "(JobNo+'1'+'RDW')SMSCode,Mobile  " +
                            "from TELServiceDB.dbo.Job J " +
                            "INNER JOIN TELServiceDB.dbo.Product P " +
                            "ON P.ProductID=J.productID " +
                            "Left outer JOIN (Select ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) PD " +
                            "ON PD.ProductCode=P.Code " +
                            "Where IsDelivered=0 AND ServiceType=1  " +
                            "AND JobType=1 AND JobStatus=13 AND ProductLocation=0 " +
                            ")H  " +
                            ")H UNION ALL " +

                            //---------------------------------------------------------------------------------------------------------------------
                            //Product Delivery Information (Walk-In, Paid)

                            "Select SMSCode, JobID,JobNo,Type,Mobile,SMS,len(SMS)CharCount,JCD " +
                            "From " +
                            "( " +
                            "Select SMSCode, JobID,JobNo,8 Type,Mobile,JCD,  " +
                            "('Dear Sir, Your '+IsNull(ASGName,'Product')+'('+'Job#'+JobNo+')'+' is ready for delivery. Bill amount is Tk.' "+
                            "+parsename(convert(varchar,convert(money,Total), 1),2) " +
                            "+'. Pls collect ASAP. For Cont." + _oSMSMaker.GetHelpline(8) + " [" + _oSMSMaker.GetServiceTime(8) + "]. B/Rgds, CSD-TEL.')SMS from " +
                            "( " +
                            "Select J.JobID,JobNo, SerialNo,JobCreationDate JCD, " +
                            "JobType, ServiceType, J.ProductID,ASGName, " +
                            "(JobNo+'1'+'PAD')SMSCode,Mobile,IsNull(SpareAmt,0)SPAmt, CSC.PaidAmt SC, (IsNull(SpareAmt,0)+CSC.PaidAmt) Total  " +
                            "from TELServiceDB.dbo.Job J " +
                            "INNER JOIN TELServiceDB.dbo.Product P " +
                            "ON P.ProductID=J.productID " +
                            "Left outer JOIN (Select ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) PD " +
                            "ON PD.ProductCode=P.Code " +
                            "INNER JOIN  " +
                            "(Select CategoryID, PaidAmt from TELServiceDB.dbo.CategorySerCharge Where ChargeType=1) CSC " +
                            "ON CSC.CategoryID=P.CategoryID " +
                            "left OUter JOIN " +
                            "( " +
                            "Select JobID, Sum(SaleAmt)SpareAmt " +
                            "From " +
                            "( " +
                            "Select SparePartID,JobID,IssueQty,ReturnQty,SalePrice,  " +
                            "(IssueQty-ReturnQty)UseQty,(SalePrice*(IssueQty-ReturnQty))SaleAmt  " +
                            "from TELServiceDB.dbo.IssueParts IP " +
                            "INNER JOIN TELServiceDB.dbo.SpareParts SP " +
                            "ON SP.ID=IP.SparePartID " +
                            "Where (IssueQty-ReturnQty)>0 " +
                            ")A Group by JobID " +
                            ")H " +
                            "ON H.JobID=J.JobID " +
                            "Where IsDelivered=0 AND ServiceType=1  " +
                            "AND JobType=2 AND JobStatus=13 AND ProductLocation=0 " +
                            ")I  " +
                            ")I " +
                            ")Final " +
                            "Where JCD>='15-Jul-2012' AND SMSCode NOT IN (Select SMSCode From t_CSDSMS Where Status <>4)";

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
        public void Add4()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            _oSMSMaker = new SMSMaker();
            try
            {
                sSql = "INSERT INTO t_CSDSMS Select Final.SMSCode SMSCode, Final.JobID JobID,SMS, Mobile,0 Status,getdate(),Type, " +
                        "Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null " +
                        "From " +
                        "( " +
                
                    //---------------------------------------------------------------------------------------------------------------------
                    //Product Delivery Information (Walk-In, ServiceWarranty)

                            "Select SMSCode, JobID,JobNo,Type,Mobile,SMS,len(SMS)CharCount,JCD " +
                            "From " +
                            "( " +
                            "Select SMSCode, JobID,JobNo,9 Type,Mobile,JCD,  " +
                            "('Dear Sir, Your '+IsNull(ASGName,'Product')+'('+'Job#'+JobNo+')'+' is ready for delivery. Bill amount is Tk.' " +
                            "+parsename(convert(varchar,convert(money,SPAmt), 1),2) " +
                            "+'. Pls collect ASAP. For Cont." + _oSMSMaker.GetHelpline(9) + " [" + _oSMSMaker.GetServiceTime(9) + "]. B/Rgds, CSD-TEL.')SMS from " +
                            "( " +
                            "Select J.JobID,JobNo, SerialNo,JobCreationDate JCD, " +
                            "JobType, ServiceType, J.ProductID,ASGName, " +
                            "(JobNo+'1'+'PAD')SMSCode,Mobile,IsNull(SpareAmt,0)SPAmt  " +
                            "from TELServiceDB.dbo.Job J " +
                            "INNER JOIN TELServiceDB.dbo.Product P " +
                            "ON P.ProductID=J.productID " +
                            "Left outer JOIN (Select ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) PD " +
                            "ON PD.ProductCode=P.Code " +
                            "left OUter JOIN " +
                            "( " +
                            "Select JobID, Sum(SaleAmt)SpareAmt " +
                            "From " +
                            "( " +
                            "Select SparePartID,JobID,IssueQty,ReturnQty,SalePrice,  " +
                            "(IssueQty-ReturnQty)UseQty,(SalePrice*(IssueQty-ReturnQty))SaleAmt  " +
                            "from TELServiceDB.dbo.IssueParts IP " +
                            "INNER JOIN TELServiceDB.dbo.SpareParts SP " +
                            "ON SP.ID=IP.SparePartID " +
                            "Where (IssueQty-ReturnQty)>0 " +
                            ")A Group by JobID " +
                            ")H " +
                            "ON H.JobID=J.JobID " +
                            "Where IsDelivered=0 AND ServiceType=1  " +
                            "AND JobType=3 AND JobStatus=13 AND ProductLocation=0 " +
                            ")J  " +
                            ")J UNION ALL " +
                    //---------------------------------------------------------------------------------------------------------------------
                    //Product Delivery Information (Return)

                            "Select SMSCode, JobID,JobNo,Type,Mobile,SMS,len(SMS)CharCount,JCD " +
                            "From " +
                            "( " +
                            "Select SMSCode, JobID,JobNo,10 Type,Mobile,JCD,  " +
                            "('Dear Sir, Your '+IsNull(ASGName,'Product')+'('+'Job#'+JobNo+')'+ " +
                            "' is ready for RETURN which is not in a repairable condition/Estimate not agreed. " +
                            "For Cont." + _oSMSMaker.GetHelpline(10) + " [" + _oSMSMaker.GetServiceTime(10) + "]. B/Rgds, CSD-TEL.')SMS from " +
                            "( " +
                            "Select J.JobID,JobNo, SerialNo, JobCreationDate JCD, " +
                            "JobType, ServiceType, J.ProductID,ASGName, " +
                            "(JobNo+'1'+'RET')SMSCode,Mobile " +
                            "from TELServiceDB.dbo.Job J " +
                            "INNER JOIN TELServiceDB.dbo.Product P " +
                            "ON P.ProductID=J.productID " +
                            "Left outer JOIN (Select ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) PD " +
                            "ON PD.ProductCode=P.Code " +
                            "Where IsDelivered=0 AND ServiceType=1  " +
                            "AND JobStatus=14 AND ProductLocation=0 " +
                            ")K  " +
                            ")K UNION ALL " +
                    //---------------------------------------------------------------------------------------------------------------------
                    //Long Pending_ Ready for Delivery(Repaired/Return) >7 days
                            "Select SMSCode, JobID,JobNo,Type,Mobile,SMS,len(SMS)CharCount,JCD  " +
                            "From   " +
                            "(   " +
                            "Select SMSCode, JobID,JobNo,11 Type,Mobile,JCD,  " +
                            "('Dear Sir, Your '+IsNull(ASGName,'Product')+'('+'Job#'+JobNo+')'+' is ready for delivery. Bill amount is Tk.'  " +
                            "+ parsename(convert(varchar,convert(money,Total), 1),2) + " +
                            "'. Please collect ASAP. For Cont." + _oSMSMaker.GetHelpline(11) + " [" + _oSMSMaker.GetServiceTime(11) + "]. B/Rdgs, CSD-TEL.')SMS from   " +
                            "(   " +
                            "Select J.JobID,JobNo, SerialNo, JobCreationDate JCD,   " +
                            "JobType, ServiceType, J.ProductID,ASGName,   " +
                            "(JobNo+'1'+'LPS')SMSCode,Mobile,Convert(Varchar,TranDate,106)TranDate ,  (IsNull(SPAmt,0)+CSC.SCV) Total  " +
                            "from TELServiceDB.dbo.Job J   " +
                            "INNER JOIN TELServiceDB.dbo.Product P   " +
                            "ON P.ProductID=J.productID   " +
                            "Left outer JOIN (Select ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) PD   " +
                            "ON PD.ProductCode=P.Code  " +
                            "Left OUter JOIN  " +
                            "(select Max(JobID)JobID,A.TranDate  from (Select * from TELServiceDB.dbo.JobHistory  " +
                            "where Status='Send To Home Care')A Group by TranDate)STHC  " +
                            "ON STHC.JobID=J.JobID " +
                            "Left OUTER JOIN  " +
                            "(   " +
                            "Select JobID, Sum(SPAmt)SPAmt From  " +
                            "(  " +
                            "Select JobID, UP.SparePartID,Quantity, " +
                            "(SP.SalePrice* Quantity)SPAmt  " +
                            "from (Select * from TELServiceDB.dbo.UnavailableParts Where PurposeType=2) UP  " +
                            "INNER JOIN TELServiceDB.dbo.SpareParts SP  " +
                            "ON SP.ID= UP.SparePartID  " +
                            ")A  " +
                            "Group BY JobID  " +
                            ")SPUse  " +
                            "ON SPUse.JobID=J.JobID  " +
                            "INNER JOIN   " +
                            "(Select CategoryID, PaidAmt sCV from TELServiceDB.dbo.CategorySerCharge Where ChargeType=1) CSC  " +
                            "ON CSC.CategoryID=P.CategoryID  " +
                            "Where IsDelivered=0 AND ServiceType=1 and TranDate > '25-Jul-2013' " +
                            "AND JobStatus IN (13,14) AND ProductLocation=0 AND (GetDate()-TranDate)>7 " +
                            ")L  " +
                            ")L " +
                            ")Final " +
                            "Where JCD>='15-Jul-2012' AND SMSCode NOT IN (Select SMSCode From t_CSDSMS Where Status <>4)";

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
        public void Add1()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            _oSMSMaker = new SMSMaker();
            try
            {
                sSql = "INSERT INTO t_CSDSMS Select Final.SMSCode SMSCode, Final.JobID JobID,SMS, Mobile,0 Status,getdate(),Type, " +
                           "Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null " +
                           "From " +
                           "( " +
                            //---------------------------------------------------------------------------------------------------------------------
                            //Long Pending_ Ready for Delivery(Repaired/Return)>14 days
                            "Select SMSCode, JobID,JobNo,Type,Mobile,SMS,len(SMS)CharCount,JCD  " +
                            "From   " +
                            "(   " +
                            "Select SMSCode, JobID,JobNo,14 Type,Mobile,JCD,  " +
                            "('Dear Sir, Pls collect yr '+IsNull(ASGName,'Product')+'('+'Job#'+JobNo+')'+' within this otherwise " +
                            "we will not be liable for product. For Cont." + _oSMSMaker.GetHelpline(14) + " [" + _oSMSMaker.GetServiceTime(14) + "]. B/Rgds, CSD-TEL.')SMS from   " +
                            "(   " +
                            "Select J.JobID,JobNo, SerialNo, JobCreationDate JCD,   " +
                            "JobType, ServiceType, J.ProductID,ASGName,   " +
                            "(JobNo+'1'+'LPF')SMSCode,Mobile,Convert(Varchar,TranDate,106)TranDate  " +
                            "from TELServiceDB.dbo.Job J   " +
                            "INNER JOIN TELServiceDB.dbo.Product P   " +
                            "ON P.ProductID=J.productID   " +
                            "Left outer JOIN (Select ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) PD   " +
                            "ON PD.ProductCode=P.Code  " +
                            "Left OUter JOIN  " +
                            "(select Max(JobID)JobID,A.TranDate  from (Select * from TELServiceDB.dbo.JobHistory  " +
                            "where Status='Send To Home Care')A Group by TranDate)STHC  " +
                            "ON STHC.JobID=J.JobID " +
                            "Where IsDelivered=0 AND ServiceType=1 and TranDate > '01-Jul-2013' " +
                            "AND JobStatus IN (13,14) AND ProductLocation=0 AND (GetDate()-TranDate)>14 " +
                            ")LL  " +
                            ")LL UNION ALL " +
                            //-------------------------------------------------------------------------------------------------------------------
                            //Long Pending_ Ready for Delivery(Repaired/Return)>21 days
                            "Select SMSCode, JobID,JobNo,Type,Mobile,SMS,len(SMS)CharCount,JCD  " +
                            "From   " +
                            "(   " +
                            "Select SMSCode, JobID,JobNo,15 Type,Mobile,JCD,  " +
                            "('Dear Sir, Pls collect yr '+IsNull(ASGName,'Product')+'('+'Job#'+JobNo+')'+' within next 2/3 days " +
                            "otherwise we dispose the same without notice. For Cont." + _oSMSMaker.GetHelpline(15) + " [" + _oSMSMaker.GetServiceTime(15) + "]. B/Rgds, CSD-TEL.')SMS from   " +
                            "(   " +
                            "Select J.JobID,JobNo, SerialNo, JobCreationDate JCD,   " +
                            "JobType, ServiceType, J.ProductID,ASGName,   " +
                            "(JobNo+'1'+'LPT')SMSCode,Mobile,Convert(Varchar,TranDate,106)TranDate  " +
                            "from TELServiceDB.dbo.Job J   " +
                            "INNER JOIN TELServiceDB.dbo.Product P   " +
                            "ON P.ProductID=J.productID   " +
                            "Left outer JOIN (Select ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) PD   " +
                            "ON PD.ProductCode=P.Code  " +
                            "Left OUter JOIN  " +
                            "(select Max(JobID)JobID,A.TranDate  from (Select * from TELServiceDB.dbo.JobHistory  " +
                            "where Status='Send To Home Care')A Group by TranDate)STHC  " +
                            "ON STHC.JobID=J.JobID " +
                            "Where IsDelivered=0 AND ServiceType=1 and TranDate > '01-Jul-2013' " +
                            "AND JobStatus IN (13,14) AND ProductLocation=0 AND (GetDate()-TranDate)>21 " +
                            ")LLL  " +
                            ")LLL UNION ALL " +

                            //---------------------------------------------------------------------------------------------------------------------
                    //ProActive EDD Extention
                            "Select SMSCode, JobID,JobNo,Type,Mobile,SMS,len(SMS)CharCount,JCD " +
                            "From  " +
                            "(  " +

                            "Select SMSCode, JobID,JobNo,12 Type,Mobile,JCD, " +
                            "('Dear Sir, Due to critical,Delivery Date for '+'Job#'+JobNo+  " +
                            "' is extended upto '+NextCommDate+'. Sorry for inconvenient. " +
                            "For Cont." + _oSMSMaker.GetHelpline(12) + " [" + _oSMSMaker.GetServiceTime(12) + "]. B/Rgds, CSD-TEL.')SMS from  " +
                            "(  " +
                            "Select J.JobID,JobNo, SerialNo, JobCreationDate JCD,  " +
                            "JobType, ServiceType,  " +
                            "(JobNo+Right(ID,4))SMSCode,Mobile,Convert(Varchar,NextCommDate,106)NextCommDate  " +
                            "from TELServiceDB.dbo.Job J  " +
                            "INNER JOIN " +
                            "(select Max(ID)ID,JobID,NextCommDate from TELServiceDB.dbo.communication Where NextCommDate IS NOT Null AND NextCommDate <> '01-Jan-1900' " +
                            "Group By JobID,NextCommDate)ProActive " +
                            "ON ProActive.JobID=J.JobID " +
                            "Where IsDelivered=0 AND ServiceType=1 " +
                            ")M " +
                            ")M UNION ALL " +
                    //---------------------------------------------------------------------------------------------------------------------
                    //Replace Expected FeedBack Date
                            "Select SMSCode, JobID,JobNo,Type,Mobile,SMS,len(SMS)CharCount,JCD  " +
                            "From    " +
                            "(    " +
                            "Select SMSCode, JobID,JobNo,16 Type,Mobile,JCD,   " +
                            "('Dear Sir, Yr '+IsNull(ASGName,'Product')+'('+'Job#'+JobNo+')'+' is under replace process. Exp. Feedback dt. is ' " +
                            "+ Convert(varchar,EDD,5) + ' Inform u the DD later. Cont." + _oSMSMaker.GetHelpline(16) + " [" + _oSMSMaker.GetServiceTime(16) + "]. B/Rgds, CSD-TEL.')SMS from    " +
                            "(   " +
                            "Select ReplaceID,R.CreateDate as JCD,R.JobID,ASGName,Mobile,JobNo,(J.JobNo+'1'+'REF')SMSCode,  " +
                            "Status,IssueDate,EDD from dbo.t_CSDReplace R " +
                            "INNER JOIN TELServiceDB.dbo.Job J  " +
                            "ON R.JobID=J.JobID " +
                            "INNER JOIN TELServiceDB.dbo.Product P    " +
                            "ON P.ProductID=J.productID    " +
                            "Left outer JOIN (Select ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) PD    " +
                            "ON PD.ProductCode=P.Code   " +
                            "Where R.CreateDate >'31-Jul-2013' " +
                            ")N  " +
                            ")N " +
                            
                            ")Final " +
                            "Where JCD>='15-Jul-2012' AND SMSCode NOT IN (Select SMSCode From t_CSDSMS Where Status <>4)";

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
        public void Add5()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            _oSMSMaker = new SMSMaker();
            try
            {
                sSql = "INSERT INTO t_CSDSMS Select Final.SMSCode SMSCode, Final.JobID JobID,SMS, Mobile,0 Status,getdate(),Type, " +
                           "Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null " +
                           "From " +
                           "( " +
                    
                    //---------------------------------------------------------------------------------------------------------------------
                    //Replaced product delivery date info
                            "Select SMSCode, JobID,JobNo,Type,Mobile,SMS,len(SMS)CharCount,JCD  " +
                            "From    " +
                            "(    " +
                            "Select SMSCode, JobID,JobNo,17 Type,Mobile,JCD,   " +
                            "('Dear Sir, Your replaced '+IsNull(ASGName,'Product')+'('+' Job#'+JobNo+')'+' is ready for delivery. " +
                            "For Cont." + _oSMSMaker.GetHelpline(17) + " [" + _oSMSMaker.GetServiceTime(17) + "]. B/Rgds, CSD-TEL.')SMS from    " +
                            "(   " +
                            "Select ReplaceID,R.CreateDate as JCD,R.JobID,ASGName,Mobile,JobNo,(J.JobNo+'1'+'RDD')SMSCode,  " +
                            "Status,IssueDate,EDD from dbo.t_CSDReplace R " +
                            "INNER JOIN TELServiceDB.dbo.Job J  " +
                            "ON R.JobID=J.JobID " +
                            "INNER JOIN TELServiceDB.dbo.Product P    " +
                            "ON P.ProductID=J.productID    " +
                            "Left outer JOIN (Select ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) PD    " +
                            "ON PD.ProductCode=P.Code   " +
                            "Where R.CreateDate >'12-Jul-2013' and IssueDate Is Not Null " +
                            ")O  " +
                            ")O UNION ALL " +
                    //---------------------------------------------------------------------------------------------------------------------
                    //Vehicle Schedule/Reschedule
                            "Select SMSCode, JobID,JobNo,Type,Mobile,SMS,len(SMS)CharCount,JCD   " +
                            "From    " +
                            "(    " +
                            "Select SMSCode, JobID,JobNo,18 Type,Mobile,JCD,   " +
                            "('Dear Sir, Your '+IsNull(ASGName,'Product')+' ('+' Job/Schedule#'+JobNo+')'+ ReqType+' re/schedule on '+Convert(varchar,ScheduleDate,5)+ " +
                            "' (Inform you the time later)For Cont." + _oSMSMaker.GetHelpline(18) + " [" + _oSMSMaker.GetServiceTime(18) + "]. B/Rgds, CSD-TEL.')SMS from    " +
                            "(  " +
                            "Select VRID,R.JobID,JobNo,ReqType=CASE When ReqType=1 then 'Pick-up' else 'Drop' end , " +
                            "R.CreateDate as JCD, ScheduleDate,ASGName,Mobile,(JobNo+'0'+'VSF')SMSCode from dbo.t_CSDVehicleRequisition R " +
                            "INNER JOIN TELServiceDB.dbo.Job J ON R.JobID=J.JobID " +
                            "INNER JOIN TELServiceDB.dbo.Product P ON P.ProductID=J.productID    " +
                            "Left outer JOIN (Select ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) PD    " +
                            "ON PD.ProductCode=P.Code Where Status IN (1,2) and IsNoJob=0 " +
                            "UNION ALL " +
                            "Select VRID,R.JobID,Convert(Varchar,VRID) as JobNo,ReqType=CASE When ReqType=1 then 'Pick-up' else 'Drop' end , " +
                            "R.CreateDate as JCD, ScheduleDate,ASGName,ContactNo,(Convert(Varchar,VRID)+'1'+'VSF')SMSCode from dbo.t_CSDVehicleRequisition R " +
                            "INNER JOIN (Select ProductID,ProductCode, ASGName from TELSysDB.dbo.v_ProductDetails) PD    " +
                            "ON PD.ProductID=R.ProductID Where Status IN (1,2) and IsNoJob=1 " +
                            ")P Where ScheduleDate > '30-Jul-2013' " +
                            ")P UNION ALL  " +

                            //---------------------------------------------------------------------------------------------------------------------
                    //Inter Service Paid Job Schedule Confirmation
                            "Select SMSCode, JobID,JobNo,Type,Mobile,SMS,len(SMS)CharCount,JCD " +
                            "From " +
                            "( " +
                            "Select CreateDate JCD,ISPJ.PaidJobID JobID,ISPJ.PaidJobID JobNo, 13 Type,ContactNo Mobile, " +
                            "SMSCode=RIGHT('PJ0000000' + CONVERT(VARCHAR,ISPJ.PaidJobID), 12), " +
                            "('Dear Sir, Our Technician will reach at your end On ' " +
                            "+ Convert(Varchar,ScheduleDate,6)+'/'+ ISPJH.Remarks +' " +
                            "'+'('+'Job# '+('PJ'+ Convert(varchar,ISPJ.PaidJobID))+')'+ " +
                            "' For Cont." + _oSMSMaker.GetHelpline(13) + " [" + _oSMSMaker.GetServiceTime(13) + "]. B/Rgds, CSD-TEL.')SMS " +
                            "from t_CSDInterServicepaidJob ISPJ " +
                            "INNER JOIN (Select * from t_CSDInterServicepaidJobHistory Where Status=1)ISPJH " +
                            "ON ISPJ.PaidJobID=ISPJH.PaidJobID " +
                            "Where CreateDate>='13-Nov-2012' AND ISPJ.Status=1 " +
                            ")A " +
                            ")Final " +
                            "Where JCD>='15-Jul-2012' AND SMSCode NOT IN (Select SMSCode From t_CSDSMS Where Status <>4)";

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
        public void AddToServer()
        {
            int nMaxSMSMessageID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SMSMessageID]) FROM t_SMSMessage";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSMSMessageID = 1;
                }
                else
                {
                    nMaxSMSMessageID = Convert.ToInt32(maxID) + 1;
                }
                _nSMSMessageID = nMaxSMSMessageID;

                sSql = "INSERT INTO t_SMSMessage(SMSMessageID,RequestDate,SMSText,"
                    + " SMSType,SingleMobileNo,SendDate,Status,SubmittedBy,"
                    + " UserGroupName,SuccessCount,failCount"
                    + " ) VALUES(?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SMSMessageID", _nSMSMessageID);
                cmd.Parameters.AddWithValue("RequestDate", DateTime.Now);
                cmd.Parameters.AddWithValue("SMSText", _sSMSTextT);
                cmd.Parameters.AddWithValue("SMSType", 1);
                cmd.Parameters.AddWithValue("SingleMobileNo", _sSingleMobileNo);
                cmd.Parameters.AddWithValue("SendDate", DateTime.Now);
                cmd.Parameters.AddWithValue("Status", 1);
                cmd.Parameters.AddWithValue("SubmittedBy", _sSubmittedBy);
                cmd.Parameters.AddWithValue("UserGroupName", "CSD");
                cmd.Parameters.AddWithValue("SuccessCount", 0);
                cmd.Parameters.AddWithValue("failCount", 0);

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

                cmd.CommandText = "UPDATE t_CSDSMS SET SMSText=?,MobileNo=?,EditUserID=? Where SMSID=?";

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("SMSText", _sSMSText);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("EditUserID", Utility.UserId);

                cmd.Parameters.AddWithValue("SMSID", _nSMSID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Sent()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDSMS SET SendUserID=?,SendDate=?, Status=? Where SMSID=?";

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("SendUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("SendDate", DateTime.Now);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.CSDSMSStatus.Sent);

                cmd.Parameters.AddWithValue("SMSID", _nSMSID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void ReSent()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDSMS SET ReSentUserID=?,ReSentDate=?,Status=? Where SMSID=?";

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("ReSentUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("ReSentDate", DateTime.Now);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.CSDSMSStatus.ReSent);

                cmd.Parameters.AddWithValue("SMSID", _nSMSID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void ReGenerate()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDSMS SET ReGenReqUserID=?,ReGenReqDate=?,ReGenReqReason=?,Status=? Where SMSID=?";

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("ReGenReqUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("ReGenReqDate", DateTime.Now);
                cmd.Parameters.AddWithValue("ReGenReqReason", _sReGenReqReason);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.CSDSMSStatus.ReGenerate);

                cmd.Parameters.AddWithValue("SMSID", _nSMSID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void ReqForReGenerate()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDSMS SET ReSentUserID=?,ReSentDate=?,Status=? Where SMSID=?";

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("ReSentUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("ReSentDate", DateTime.Now);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.CSDSMSStatus.ReSent);

                cmd.Parameters.AddWithValue("SMSID", _nSMSID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Cancel()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDSMS SET CancelUserID=?,CancelReason=?,CancelDate=?, Status=? Where SMSID=?";

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("CancelUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CancelReason", _sCancelReason);
                cmd.Parameters.AddWithValue("CancelDate", DateTime.Now);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.CSDSMSStatus.Cancel);

                cmd.Parameters.AddWithValue("SMSID", _nSMSID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddCallCentJobList()
        {
            int nMaxCallCentJobListID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([CallCentJobListID]) FROM TELServiceDB.dbo.CallCentJobList";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxCallCentJobListID = 1;
                }
                else
                {
                    nMaxCallCentJobListID = Convert.ToInt32(maxID) + 1;
                }
                _nCallCentJobListID = nMaxCallCentJobListID;

                sSql = "INSERT INTO TELServiceDB.dbo.CallCentJobList(CallCentJobListID, JobID, Instruction, FollowUpDate, UserID, " //,
                      +  "CallType, ResponseType, IsAttend, CallRemarks, CallCreationDate, IsBanForever"
                      + " ) VALUES(?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CallCentJobListID", _nCallCentJobListID);
                cmd.Parameters.AddWithValue("JobID", _nJobIDC);
                cmd.Parameters.AddWithValue("Instruction", "Sent SMS about the Job status");
                cmd.Parameters.AddWithValue("FollowUpDate", "");
                cmd.Parameters.AddWithValue("UserID", -9);
                cmd.Parameters.AddWithValue("CallType", 1);
                cmd.Parameters.AddWithValue("ResponseType", 0);
                cmd.Parameters.AddWithValue("IsAttend", 1);
                cmd.Parameters.AddWithValue("CallRemarks", _sCallRemarks);
                cmd.Parameters.AddWithValue("CallCreationDate", DateTime.Now);
                cmd.Parameters.AddWithValue("IsBanForever", 0);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddCommunication()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ID]) FROM TELServiceDB.dbo.Communication";
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

                sSql = "SELECT MAX([CallCentJobListID]) FROM TELServiceDB.dbo.CallCentJobList";
                cmd.CommandText = sSql;

                _nCallCenterJobListID = CallCentJobListID;

                sSql = "INSERT INTO TELServiceDB.dbo.Communication(ID,JobID,Remarks,NextCommDate, EnteredBy,"
                      +" EntryDate, ResponseType, CallType, CallCenterJobListID"
                      + " ) VALUES(?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("JobID", _nJobIDCom);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("NextCommDate", "");
                cmd.Parameters.AddWithValue("EnteredBy", -9);
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Now);
                cmd.Parameters.AddWithValue("ResponseType", 0);
                cmd.Parameters.AddWithValue("CallType", 1);
                cmd.Parameters.AddWithValue("CallCenterJobListID", _nCallCenterJobListID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddISVPaidJobHistory()
        {

            int nMaxPaidJobHistoryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([PaidJobHistoryID]) FROM t_CSDInterServicePaidJobHistory";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPaidJobHistoryID = 1;
                }
                else
                {
                    nMaxPaidJobHistoryID = Convert.ToInt32(maxID) + 1;
                }
                _nPaidJobHistoryID = nMaxPaidJobHistoryID;

                sSql = "INSERT INTO t_CSDInterServicePaidJobHistory(PaidJobHistoryID, PaidJobID, "+ 
                      "Status, UserID, StatusDate, Remarks) VALUES(?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PaidJobHistoryID", _nPaidJobHistoryID);
                cmd.Parameters.AddWithValue("PaidJobID", _nPaidJobID);
                cmd.Parameters.AddWithValue("Status", -9);
                cmd.Parameters.AddWithValue("UserID",Utility.UserId);
                cmd.Parameters.AddWithValue("StatusDate", DateTime.Now);
                cmd.Parameters.AddWithValue("Remarks", _sRemarksPJH);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        
        }
        public void UpdateISVPaidJobComStatus()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDInterServicePaidJob SET CommunicationStatus=?,CommuRemarks=? Where PaidJobID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CommunicationStatus", (int)Dictionary.YesOrNoStatus.YES);
                cmd.Parameters.AddWithValue("CommuRemarks",_sCommuRemarks);

                cmd.Parameters.AddWithValue("PaidJobID", _nPaidJobID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Start
        /// For Customer Satisfaction Module
        /// Shavagata Saha
        /// Date-10-May-2016
        /// </summary>
        public void GetCallCentJoblistID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = " Select max(CallCentJoblistID) CallCentJoblistID  "+
                                  " from TELServiceDB.dbo.CallCentJobList where JobID = ?";

                cmd.Parameters.AddWithValue("JobID", _nJobIDC);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCallCentJobListID = (int)reader["CallCentJoblistID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateCallCenterJobList()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = " UPDATE TELServiceDB.dbo.CallCentJobList SET UserID = ?, FollowUpDate = ? ,CallType = ?, ResponseType = ?, IsAttend = ?, CallRemarks = ? Where CallCentJobListID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("UserID", -9);
                cmd.Parameters.AddWithValue("FollowUpDate", null);
                cmd.Parameters.AddWithValue("CallType", _nCallType);
                cmd.Parameters.AddWithValue("ResponseType", _nResponseType);
                cmd.Parameters.AddWithValue("IsAttend", _nIsAttend);
                cmd.Parameters.AddWithValue("CallRemarks", _sRemarks);

                cmd.Parameters.AddWithValue("CallCentJobListID", _nCallCentJobListID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddCommunicationForCJ()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ID]) FROM TELServiceDB.dbo.Communication";
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

                //sSql = "SELECT MAX([CallCentJobListID]) FROM TELServiceDB.dbo.CallCentJobList";
                //cmd.CommandText = sSql;

                //_nCallCenterJobListID = CallCentJobListID;

                sSql = "INSERT INTO TELServiceDB.dbo.Communication(ID,JobID,Remarks,NextCommDate, EnteredBy,"
                      + " EntryDate, ResponseType, CallType, CallCenterJobListID"
                      + " ) VALUES(?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("JobID", _nJobIDC);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("NextCommDate", "");
                cmd.Parameters.AddWithValue("EnteredBy", -9);
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Now);
                cmd.Parameters.AddWithValue("ResponseType", _nResponseType);
                cmd.Parameters.AddWithValue("CallType", _nCallType);
                cmd.Parameters.AddWithValue("CallCenterJobListID", _nCallCentJobListID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// END
        /// </summary>

    }

    public class CSDSMSS : CollectionBase
    {
        public CSDSMS this[int i]
        {
            get { return (CSDSMS)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(CSDSMS oCSDSMS)
        {
            InnerList.Add(oCSDSMS);
        }
        public void Refresh(DateTime dtFromDate, DateTime dtToDate, String txtSMSID,String txtSMSCode, String txtMobileNo, String txtJobNo, int nStatus, int nSMSType, int nSMSLenth, int nSvrStatus)
        {
            dtToDate = dtToDate.Date.AddDays(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select SMSID, SMSCode,JobID,IsNull(PJI,JobNo)JobNo,SMSText,CharCount,SMSLenth,MobileNo,Status,StatusName, CreateDate,SMSType,SMSTypeName, " +
                            "SentBy,SendDate,ReSentBy ,ReSentDate,EditedBy,ReGenReqBy, ReGenReqDate,ReGenReqReason,CancelledBy, CancelDate,CancelReason,SvrStatus,ServerStatus "+
                            "From ( "+
                            "Select SMSID, SMSCode,S.JobID JobID,JobNo,Convert(Varchar,ISVPJ.PaidJobID) PJI, SMSText, Len(SMSText)CharCount,  " +
                            "SMSLenth=CASE When Len(SMSText)<=160 then 1   "+
                            "When Len(SMSText)>160 then 0 End,  "+
                            "MobileNo, S.Status,StatusName=CASE   "+
                            "When S.Status=0 THEN 'UnSend'   "+
                            "When S.Status=1 THEN 'Sent'   "+
                            "When S.Status=2 THEN 'ReSent'   "+
                            "When S.Status=3 THEN 'Cancel'   "+
                            "When S.Status=4 THEN 'ReGenerate' else 'Others'  " +
                            "End,S.CreateDate, SMSType, SMSTypeName=CASE   "+
                            "When SMSType=0 THEN 'Installation_ScheduleDateTime'   "+
                            "When SMSType=1 THEN 'Installation_ReScheduleDateTime'   "+
                            "When SMSType=2 THEN 'HomeCall_ScheduleDateTime'   "+
                            "When SMSType=3 THEN 'HomeCall_ReScheduleDateTime'   "+
                            "When SMSType=4 THEN 'WalkIn_Estimated'   "+
                            "When SMSType=5 THEN 'WalkIn_ReceiveByTELVehicle'   "+
                            "When SMSType=6 THEN 'WalkIn_ReceiveByCourier'   "+
                            "When SMSType=7 THEN 'WalkIn_ReadyForDelivery_Warranty'   "+
                            "When SMSType=8 THEN 'WalkIn_ReadyForDelivery_Paid'   "+
                            "When SMSType=9 THEN 'WalkIn_ReadyForDelivery_ServiceWarranty'   "+
                            "When SMSType=10 THEN 'WalkIn_ReadyForReturn_Paid' " +
                            "When SMSType=11 THEN 'LongPending_ReadyForDelivery_7Days' " +
                            "When SMSType=12 THEN 'ExpectedDeliveryDateExtention' " +
                            "When SMSType=13 THEN 'InterServicePaidJob_ScheduleDateTime' " +
                            "When SMSType=14 THEN 'LongPending_ReadyForDelivery_14Days' " +
                            "When SMSType=15 THEN 'LongPending_ReadyForDelivery_21Days' " +
                            "When SMSType=16 THEN 'Replace_Expected_Feedback_Date' " +
                            "When SMSType=17 THEN 'Replaced_Product_Delivery_Info' " +
                            "When SMSType=18 THEN 'Vehicle_Schedule_ReSchedule' " +
                            "else 'Others' End,  "+
                            "U.UserName SentBy,SendDate, "+
                            "U1.UserName ReSentBy ,ReSentDate, "+
                            "U2.UserName EditedBy, U3.UserName ReGenReqBy, ReGenReqDate, "+
                            "ReGenReqReason, "+
                            "U4.UserName CancelledBy, CancelDate, "+
                            "CancelReason,IsNull(M.Status,0) SvrStatus,IsNull(ServerStatus, 'N/A')ServerStatus " +
                            "From t_CSDSMS S "+  
                            "INNER JOIN TELServiceDB.dbo.Job J   "+
                            "ON J.JobID=S.JobID "+
                            "Left OUter JOIN t_user U "+
                            "ON U.UserID=s.SendUserID "+
                            "Left OUter JOIN t_user U1 "+
                            "ON U1.UserID=s.ReSentUserID "+
                            "Left OUter JOIN t_user U2 "+
                            "ON U2.UserID=s.EditUserID "+
                            "Left OUter JOIN t_user U3 "+
                            "ON U3.UserID=s.ReGenReqUserID "+
                            "Left OUter JOIN t_user U4 "+
                            "ON U4.UserID=s.CancelUserID "+
                            "Left Outer JOIN t_CSDInterServicePaidJob ISVPJ "+
                            "ON ISVPJ.PaidJobID=S.JobID "+
                            "Left outer join "+
                            "( "+
                            "Select A.SMSMessageID, M.Status,ServerStatus=CASE When Status=1 Then 'Submitted'  "+
                            "When Status=2 Then 'Sent' "+
                            "When Status=3 Then 'Failed' "+
                            "When Status=4 Then 'Cancelled' "+
                            "else 'Others' End, Convert(int,A.SubmittedBy)SubmittedBy,UserGroupName from "+
                            "( "+
                            "Select Max(SMSMessageID)SMSMessageID, SubmittedBy from (Select * From t_SMSMessage M Where UserGroupName='CSD')A "+
                            "Group By SubmittedBy "+
                            ")A "+
                            "INNER JOIN t_SMSMessage M "+
                            "ON A.SMSMessageID=M.SMSMessageID)M "+
                            "ON M.SubmittedBy=S.SMSID)A "+
                            "WHERE CreateDate BETWEEN " +
                            "'" + dtFromDate.Date + "'AND '" + dtToDate.Date + "' AND CreateDate < '" + dtToDate.Date + "'";

            if (txtSMSID != "")
            {
                txtSMSID = "%" + txtSMSID + "%";
                sSql = sSql + " AND SMSID LIKE '" + txtSMSID + "'";
            }
            if (txtSMSCode != "")
            {
                txtSMSCode = "%" + txtSMSCode + "%";
                sSql = sSql + " AND SMSCode LIKE '" + txtSMSCode + "'";
            }
            if (txtMobileNo != "")
            {
                txtMobileNo = "%" + txtMobileNo + "%";
                sSql = sSql + " AND MobileNo LIKE '" + txtMobileNo + "'";
            }
            if (txtJobNo != "")
            {
                txtJobNo = "%" + txtJobNo + "%";
                sSql = sSql + " AND JobNo LIKE '" + txtJobNo + "'";
            }

            if (nStatus >= 0)
            {
                sSql = sSql + " and Status=?";
                cmd.Parameters.AddWithValue("Status", nStatus);
            }
            if (nSMSType >= 0)
            {
                sSql = sSql + " and SMSType=?";
                cmd.Parameters.AddWithValue("SMSType", nSMSType);
            }

            if (nSMSLenth >= 0)
            {
                sSql = sSql + " and SMSLenth=?";
                cmd.Parameters.AddWithValue("SMSLenth", nSMSLenth);
            }
            if (nSvrStatus >= 0)
            {
                sSql = sSql + " and SvrStatus=?";
                cmd.Parameters.AddWithValue("SvrStatus", nSvrStatus);
            }

            sSql = sSql + " Order By CreateDate ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CSDSMS oCSDSMS = new CSDSMS();
                    oCSDSMS.SMSID=(int)reader["SMSID"];
                    oCSDSMS.SMSCode = (string)reader["SMSCode"];
                    oCSDSMS.JobID = (int)reader["JobID"];
                    oCSDSMS.JobNo = (string)reader["JobNo"];
                    oCSDSMS.MobileNo = (string)reader["MobileNo"];
                    oCSDSMS.Status = (int)reader["Status"];
                    oCSDSMS.StatusName = (string)reader["StatusName"];
                    oCSDSMS.SMSText = (string)reader["SMSText"];
                    oCSDSMS.CharCount = (int)reader["CharCount"];
                    oCSDSMS.SMSType = (int)reader["SMSType"];
                    oCSDSMS.SMSTypeName = (string)reader["SMSTypeName"];
                    oCSDSMS.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDSMS.SMSlenth = (int)reader["SMSLenth"];
                    oCSDSMS.SentBy = (Object)reader["SentBy"].ToString();
                    oCSDSMS.ReSentBy = (Object)reader["ReSentBy"].ToString();
                    oCSDSMS.ReGenReqBy = (Object)reader["ReGenReqBy"].ToString();
                    oCSDSMS.CancelledBy = (Object)reader["CancelledBy"].ToString();
                    oCSDSMS.EditedBy = (Object)reader["EditedBy"].ToString();
                    oCSDSMS.SendDate = (Object)reader["SendDate"].ToString();
                    oCSDSMS.ReSentDate = (Object)reader["ReSentDate"].ToString();
                    oCSDSMS.ReGenReqDate = (Object)reader["ReGenReqDate"].ToString();
                    oCSDSMS.CancelDate = (Object)reader["CancelDate"].ToString();
                    oCSDSMS.CancelReason = (Object)reader["CancelReason"].ToString();
                    oCSDSMS.ReGenReqReason = (Object)reader["ReGenReqReason"].ToString();
                    oCSDSMS.CancelReason = (Object)reader["CancelReason"].ToString();
                    oCSDSMS.SvrStatus = int.Parse(reader["SvrStatus"].ToString());
                    oCSDSMS.ServerStatus = (Object)reader["ServerStatus"].ToString();


                    InnerList.Add(oCSDSMS);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshAll(String txtSMSID, String txtSMSCode, String txtMobileNo, String txtJobNo, int nStatus, int nSMSType, int nSMSLenth, int nSvrStatus)
        {
            //dtToDate = dtToDate.Date.AddDays(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select SMSID, SMSCode,JobID,IsNull(PJI,JobNo)JobNo,SMSText,CharCount,SMSLenth,MobileNo,Status,StatusName, CreateDate,SMSType,SMSTypeName, " +
                "SentBy,SendDate,ReSentBy ,ReSentDate,EditedBy,ReGenReqBy, ReGenReqDate,ReGenReqReason,CancelledBy, CancelDate,CancelReason,SvrStatus,ServerStatus " +
                "From ( " +
                "Select SMSID, SMSCode,S.JobID JobID,JobNo,Convert(Varchar,ISVPJ.PaidJobID) PJI, SMSText, Len(SMSText)CharCount,  " +
                "SMSLenth=CASE When Len(SMSText)<=160 then 1   " +
                "When Len(SMSText)>160 then 0 End,  " +
                "MobileNo, S.Status,StatusName=CASE   " +
                "When S.Status=0 THEN 'UnSend'   " +
                "When S.Status=1 THEN 'Sent'   " +
                "When S.Status=2 THEN 'ReSent'   " +
                "When S.Status=3 THEN 'Cancel'   " +
                "When S.Status=4 THEN 'ReGenerate' else 'Others'  " +
                "End,S.CreateDate, SMSType, SMSTypeName=CASE   " +
                "When SMSType=0 THEN 'Installation_ScheduleDateTime'   " +
                "When SMSType=1 THEN 'Installation_ReScheduleDateTime'   " +
                "When SMSType=2 THEN 'HomeCall_ScheduleDateTime'   " +
                "When SMSType=3 THEN 'HomeCall_ReScheduleDateTime'   " +
                "When SMSType=4 THEN 'WalkIn_Estimated'   " +
                "When SMSType=5 THEN 'WalkIn_ReceiveByTELVehicle'   " +
                "When SMSType=6 THEN 'WalkIn_ReceiveByCourier'   " +
                "When SMSType=7 THEN 'WalkIn_ReadyForDelivery_Warranty'   " +
                "When SMSType=8 THEN 'WalkIn_ReadyForDelivery_Paid'   " +
                "When SMSType=9 THEN 'WalkIn_ReadyForDelivery_ServiceWarranty'   " +
                "When SMSType=10 THEN 'WalkIn_ReadyForReturn_Paid' " +
                "When SMSType=11 THEN 'LongPending_ReadyForDelivery_7Days' " +
                "When SMSType=12 THEN 'ExpectedDeliveryDateExtention' " +
                "When SMSType=13 THEN 'InterServicePaidJob_ScheduleDateTime' " +
                "When SMSType=14 THEN 'LongPending_ReadyForDelivery_14Days' " +
                "When SMSType=15 THEN 'LongPending_ReadyForDelivery_21Days' " +
                "When SMSType=16 THEN 'Replace_Expected_Feedback_Date' " +
                "When SMSType=17 THEN 'Replaced_Product_Delivery_Info' " +
                "When SMSType=18 THEN 'Vehicle_Schedule_ReSchedule' " +
                "else 'Others' End,  " +
                "U.UserName SentBy,SendDate, " +
                "U1.UserName ReSentBy ,ReSentDate, " +
                "U2.UserName EditedBy, U3.UserName ReGenReqBy, ReGenReqDate, " +
                "ReGenReqReason, " +
                "U4.UserName CancelledBy, CancelDate, " +
                "CancelReason,IsNull(M.Status,0) SvrStatus,IsNull(ServerStatus, 'N/A')ServerStatus " +
                "From t_CSDSMS S " +
                "INNER JOIN TELServiceDB.dbo.Job J   " +
                "ON J.JobID=S.JobID " +
                "Left OUter JOIN t_user U " +
                "ON U.UserID=s.SendUserID " +
                "Left OUter JOIN t_user U1 " +
                "ON U1.UserID=s.ReSentUserID " +
                "Left OUter JOIN t_user U2 " +
                "ON U2.UserID=s.EditUserID " +
                "Left OUter JOIN t_user U3 " +
                "ON U3.UserID=s.ReGenReqUserID " +
                "Left OUter JOIN t_user U4 " +
                "ON U4.UserID=s.CancelUserID " +
                "Left Outer JOIN t_CSDInterServicePaidJob ISVPJ " +
                "ON ISVPJ.PaidJobID=S.JobID " +
                "Left outer join " +
                "( " +
                "Select A.SMSMessageID, M.Status,ServerStatus=CASE When Status=1 Then 'Submitted'  " +
                "When Status=2 Then 'Sent' " +
                "When Status=3 Then 'Failed' " +
                "When Status=4 Then 'Cancelled' " +
                "else 'Others' End, Convert(int,A.SubmittedBy)SubmittedBy,UserGroupName from " +
                "( " +
                "Select Max(SMSMessageID)SMSMessageID, SubmittedBy from (Select * From t_SMSMessage M Where UserGroupName='CSD')A " +
                "Group By SubmittedBy " +
                ")A " +
                "INNER JOIN t_SMSMessage M " +
                "ON A.SMSMessageID=M.SMSMessageID)M " +
                "ON M.SubmittedBy=S.SMSID)A " +
                 "WHERE SMSCode IS NOT NULL ";


            if (txtSMSID != "")
            {
                txtSMSID = "%" + txtSMSID + "%";
                sSql = sSql + " AND SMSID LIKE '" + txtSMSID + "'";
            }
            if (txtSMSCode != "")
            {
                txtSMSCode = "%" + txtSMSCode + "%";
                sSql = sSql + " AND SMSCode LIKE '" + txtSMSCode + "'";
            }
            if (txtMobileNo != "")
            {
                txtMobileNo = "%" + txtMobileNo + "%";
                sSql = sSql + " AND MobileNo LIKE '" + txtMobileNo + "'";
            }
            if (txtJobNo != "")
            {
                txtJobNo = "%" + txtJobNo + "%";
                sSql = sSql + " AND JobNo LIKE '" + txtJobNo + "'";
            }

            if (nStatus >= 0)
            {
                sSql = sSql + " and Status=?";
                cmd.Parameters.AddWithValue("Status", nStatus);
            }
            if (nSMSType >= 0)
            {
                sSql = sSql + " and SMSType=?";
                cmd.Parameters.AddWithValue("SMSType", nSMSType);
            }

            if (nSMSLenth >= 0)
            {
                sSql = sSql + " and SMSLenth=?";
                cmd.Parameters.AddWithValue("SMSLenth", nSMSLenth);
            }
            if (nSvrStatus >= 0)
            {
                sSql = sSql + " and SvrStatus=?";
                cmd.Parameters.AddWithValue("SvrStatus", nSvrStatus);
            }

            sSql = sSql + " Order By CreateDate ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CSDSMS oCSDSMS = new CSDSMS();
                    oCSDSMS.SMSID = (int)reader["SMSID"];
                    oCSDSMS.SMSCode = (string)reader["SMSCode"];
                    oCSDSMS.JobID = (int)reader["JobID"];
                    oCSDSMS.JobNo = (string)reader["JobNo"];
                    oCSDSMS.MobileNo = (string)reader["MobileNo"];
                    oCSDSMS.Status = (int)reader["Status"];
                    oCSDSMS.StatusName = (string)reader["StatusName"];
                    oCSDSMS.SMSText = (string)reader["SMSText"];
                    oCSDSMS.CharCount = (int)reader["CharCount"];
                    oCSDSMS.SMSType = (int)reader["SMSType"];
                    oCSDSMS.SMSTypeName = (string)reader["SMSTypeName"];
                    oCSDSMS.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDSMS.SMSlenth = (int)reader["SMSLenth"];
                    oCSDSMS.SentBy = (Object)reader["SentBy"].ToString();
                    oCSDSMS.ReSentBy = (Object)reader["ReSentBy"].ToString();
                    oCSDSMS.ReGenReqBy = (Object)reader["ReGenReqBy"].ToString();
                    oCSDSMS.CancelledBy = (Object)reader["CancelledBy"].ToString();
                    oCSDSMS.EditedBy = (Object)reader["EditedBy"].ToString();
                    oCSDSMS.SendDate = (Object)reader["SendDate"].ToString();
                    oCSDSMS.ReSentDate = (Object)reader["ReSentDate"].ToString();
                    oCSDSMS.ReGenReqDate = (Object)reader["ReGenReqDate"].ToString();
                    oCSDSMS.CancelDate = (Object)reader["CancelDate"].ToString();
                    oCSDSMS.CancelReason = (Object)reader["CancelReason"].ToString();
                    oCSDSMS.ReGenReqReason = (Object)reader["ReGenReqReason"].ToString();
                    oCSDSMS.CancelReason = (Object)reader["CancelReason"].ToString();
                    oCSDSMS.SvrStatus = int.Parse(reader["SvrStatus"].ToString());
                    oCSDSMS.ServerStatus = (Object)reader["ServerStatus"].ToString();

                    InnerList.Add(oCSDSMS);
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




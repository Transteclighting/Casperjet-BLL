
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Mar 28, 2012
// Time :  12:21 PM
// Description: Class for Replace Data.
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
    public class Replace
    {
        private int _nReplaceID;
        private int _nJobID;
        private Object _dCreateDate;
        private int _nCreateUserID;
        private int _nIssueProductID;
        private Object _dIssueDate;
        private Object _dApproxDeliveryDate;
        private Object _dDeliveryDate;
        private int _nIsDelivered;
        private int _nFromWH;
        private int _nModeofDelivery;
        private Object _sDeliveredby;
        private int _nHappyCallStatus;
        private int _nStatus;
        private Object _sInvoiceCashMemo;
        private Object _dDateOfPurchase;
        private Object _dFullWarrantyPeriod;
        private Object _sReiseRemarks;
        private Object _sIssueProductBarcode;
        private Object _sRemarksAcutalFault;
        private Object _sSource;
        private Object _sSourceName;
        private Object _sUserName;
        private int _nPapersLocation;
        private Object _dPapersSendDate;
        private Object _dPapersReceiveDate;
        private Object _sReplacedProductCode;
        private Object _sReplacedProductName;
        private int _nCourierID;
        private Object _sConsignmentNo;
        private Object _dEDD;

        private Object _sHappyCallStat;
        private Object _sPapersLocationDetails;
        private Object _sModeofDeliveryName;
        private Object _sDeliveredFromWHName;
        private Object _dEDD1;

        private Object _sCancelRemarks;
        private Object _sDeliveryRemarks;
        private Object _sHappyCallRemarks;
        private Object _sInformedRemarks;
        private Object _sIssueRemarks;


        private User _oUser;
        private ReplaceJobFromCassandra _oReplaceJobFromCassandra;
        private CourierFromCassandra _oCourierFromCassandra;
        private Product _oProduct;

        private int _nType;
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }

        private string _sFaultDescription;

        #region
        private int _nSupReasonID;
        private string _sSupComments;
        private DateTime _dSupDate;

        private int _nTmReasonID;
        private string _sTmComments;
        private DateTime _dTmDate;

        private int _nCusReasonID;
        private int _nHOSReasonID;
        private string _sCusComments;
        private string _sHOSComments;
        private DateTime _dCusDate;

        private int _nHsReasonID;
        private string _sHsComments;
        private DateTime _dHsDate;
        #endregion

        #region

        public int SupReasonID
        {
            get { return _nSupReasonID; }
            set { _nSupReasonID = value; }
        }
        public string SupComments
        {
            get { return _sSupComments; }
            set { _sSupComments = value; }
        }
        public DateTime SupDate
        {
            get { return _dSupDate; }
            set { _dSupDate = value; }
        }

        public int TmReasonID
        {
            get { return _nTmReasonID; }
            set { _nTmReasonID = value; }
        }
        public string TmComments
        {
            get { return _sTmComments; }
            set { _sTmComments = value; }
        }
        public DateTime TmDate
        {
            get { return _dTmDate; }
            set { _dTmDate = value; }
        }

        public int CusReasonID
        {
            get { return _nCusReasonID; }
            set { _nCusReasonID = value; }
        }
        public string CusComments
        {
            get { return _sCusComments; }
            set { _sCusComments = value; }
        }
        public string HOSComments
        {
            get { return _sHOSComments; }
            set { _sHOSComments = value; }
        }
        public DateTime CusDate
        {
            get { return _dCusDate; }
            set { _dCusDate = value; }
        }

        public int HsReasonID
        {
            get { return _nHsReasonID; }
            set { _nHsReasonID = value; }
        }
        public int HOSReasonID
        {
            get { return _nHOSReasonID; }
            set { _nHOSReasonID = value; }
        }
        public string HsComments
        {
            get { return _sHsComments; }
            set { _sHsComments = value; }
        }
        public DateTime HsDate
        {
            get { return _dHsDate; }
            set { _dHsDate = value; }
        }
        #endregion

        /// <summary>
        /// Get set property for ReplaceID
        /// </summary>
        public int ReplaceID
        {
            get { return _nReplaceID; }
            set { _nReplaceID = value; }
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
        /// Get set property for CreateDate
        /// </summary>
        public Object CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
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
        /// Get set property for IssueProductID
        /// </summary>
        public int IssueProductID
        {
            get { return _nIssueProductID; }
            set { _nIssueProductID = value; }
        }
        /// <summary>
        /// Get set property for IssueDate
        /// </summary>
        public Object IssueDate
        {
            get { return _dIssueDate; }
            set { _dIssueDate = value; }
        }
        /// <summary>
        /// Get set property for ApproxDeliveryDate
        /// </summary>
        public Object ApproxDeliveryDate
        {
            get { return _dApproxDeliveryDate; }
            set { _dApproxDeliveryDate = value; }
        }
        /// <summary>
        /// Get set property for DeliveryDate
        /// </summary>
        public Object DeliveryDate
        {
            get { return _dDeliveryDate; }
            set { _dDeliveryDate = value; }
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
        /// Get set property for FromWH
        /// </summary>
        public int FromWH
        {
            get { return _nFromWH; }
            set { _nFromWH = value; }
        }
        /// <summary>
        /// Get set property for ModeofDelivery
        /// </summary>
        public int ModeofDelivery
        {
            get { return _nModeofDelivery; }
            set { _nModeofDelivery = value; }
        }
        /// <summary>
        /// Get set property for Deliveredby
        /// </summary>
        public Object Deliveredby
        {
            get { return _sDeliveredby; }
            set { _sDeliveredby = value; }
        }
        /// <summary>
        /// Get set property for HappyCallStatus
        /// </summary>
        public int HappyCallStatus
        {
            get { return _nHappyCallStatus; }
            set { _nHappyCallStatus = value; }
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
        /// Get set property for InvoiceCashMemo
        /// </summary>
        public Object InvoiceCashMemo
        {
            get { return _sInvoiceCashMemo; }
            set { _sInvoiceCashMemo = value; }
        }
        /// <summary>
        /// Get set property for DateOfPurchase
        /// </summary>
        public Object DateOfPurchase
        {
            get { return _dDateOfPurchase; }
            set { _dDateOfPurchase = value; }
        }
        /// <summary>
        /// Get set property for FullWarrantyPeriod
        /// </summary>
        public Object FullWarrantyPeriod
        {
            get { return _dFullWarrantyPeriod; }
            set { _dFullWarrantyPeriod = value; }
        }
        /// <summary>
        /// Get set property for ReiseRemarks
        /// </summary>
        public Object ReiseRemarks
        {
            get { return _sReiseRemarks; }
            set { _sReiseRemarks = value; }
        }
        /// <summary>
        /// Get set property for IssueProductBarcode
        /// </summary>
        public Object IssueProductBarcode
        {
            get { return _sIssueProductBarcode; }
            set { _sIssueProductBarcode = value; }
        }
        /// <summary>
        /// Get set property for RemarksAcutalFault
        /// </summary>
        public Object RemarksAcutalFault
        {
            get { return _sRemarksAcutalFault; }
            set { _sRemarksAcutalFault = value; }
        }
        /// <summary>
        /// Get set property for Source
        /// </summary>
        public Object Source
        {
            get { return _sSource; }
            set { _sSource = value; }
        }
        /// <summary>
        /// Get set property for SourceName
        /// </summary>
        public Object SourceName
        {
            get { return _sSourceName; }
            set { _sSourceName = value; }
        }
        /// <summary>
        /// Get set property for UserName
        /// </summary>
        public Object UserName
        {
            get { return _sUserName; }
            set { _sUserName = value; }
        }
      

        /// <summary>
        /// Get set property for PapersLocation
        /// </summary>
        public int PapersLocation
        {
            get { return _nPapersLocation; }
            set { _nPapersLocation = value; }
        }
        /// <summary>
        /// Get set property for PapersSendDate
        /// </summary>
        public Object PapersSendDate
        {
            get { return _dPapersSendDate; }
            set { _dPapersSendDate = value; }
        }
        /// <summary>
        /// Get set property for PapersReceiveDate
        /// </summary>
        public Object PapersReceiveDate
        {
            get { return _dPapersReceiveDate; }
            set { _dPapersReceiveDate = value; }
        }
        /// <summary>
        /// Get set property for ReplacedProductCode
        /// </summary>
        public Object ReplacedProductCode
        {
            get { return _sReplacedProductCode; }
            set { _sReplacedProductCode = value; }
        }
        /// <summary>
        /// Get set property for ReplacedProductName
        /// </summary>
        public Object ReplacedProductName
        {
            get { return _sReplacedProductName; }
            set { _sReplacedProductName = value; }
        }
        /// <summary>
        /// Get set property for CourierID
        /// </summary>
        public int CourierID
        {
            get { return _nCourierID; }
            set { _nCourierID = value; }
        }
        /// <summary>
        /// Get set property for ConsignmentNo
        /// </summary>
        public Object ConsignmentNo
        {
            get { return _sConsignmentNo; }
            set { _sConsignmentNo = value; }
        }
        /// <summary>
        /// Get set property for EDD
        /// </summary>
        public Object EDD
        {
            get { return _dEDD; }
            set { _dEDD = value; }
        }
        /// <summary>
        /// Get set property for HappyCallStat
        /// </summary>
        public Object HappyCallStat
        {
            get { return _sHappyCallStat; }
            set { _sHappyCallStat = value; }
        }
        /// <summary>
        /// Get set property for PapersLocationDetails
        /// </summary>
        public Object PapersLocationDetails
        {
            get { return _sPapersLocationDetails; }
            set { _sPapersLocationDetails = value; }
        }
        /// <summary>
        /// Get set property for ModeofDeliveryName
        /// </summary>
        public Object ModeofDeliveryName
        {
            get { return _sModeofDeliveryName; }
            set { _sModeofDeliveryName = value; }
        }
        /// <summary>
        /// Get set property for DeliveredFromWHName
        /// </summary>
        public Object DeliveredFromWHName
        {
            get { return _sDeliveredFromWHName; }
            set { _sDeliveredFromWHName = value; }
        }
        /// <summary>
        /// Get set property for EDD1
        /// </summary>
        public Object EDD1
        {
            get { return _dEDD1; }
            set { _dEDD1 = value; }
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
        /// Get set property for DeliveryRemarks
        /// </summary>
        public Object DeliveryRemarks
        {
            get { return _sDeliveryRemarks; }
            set { _sDeliveryRemarks = value; }
        }
        /// <summary>
        /// Get set property for HappyCallRemarks
        /// </summary>
        public Object HappyCallRemarks
        {
            get { return _sHappyCallRemarks; }
            set { _sHappyCallRemarks = value; }
        }
        /// <summary>
        /// Get set property for InformedRemarks
        /// </summary>
        public Object InformedRemarks
        {
            get { return _sInformedRemarks; }
            set { _sInformedRemarks = value; }
        }
        /// <summary>
        /// Get set property for IssueRemarks
        /// </summary>
        public Object IssueRemarks
        {
            get { return _sIssueRemarks; }
            set { _sIssueRemarks = value; }
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
        public CourierFromCassandra CourierFromCassandra
        {
            get
            {
                if (_oCourierFromCassandra == null)
                {
                    _oCourierFromCassandra = new CourierFromCassandra();

                }
                return _oCourierFromCassandra;
            }
        }
        public Product Product
        {
            get
            {
                if (_oProduct == null)
                {
                    _oProduct = new Product();
                    _oProduct.ProductID = _nIssueProductID;
                    _oProduct.RefreshByID();
                   
                }
                return _oProduct;
            }
        }

        /// <summary>
        /// Get set property for FaultDescription
        /// </summary>
        public string FaultDescription
        {
            get { return _sFaultDescription; }
            set { _sFaultDescription = value; }
        }
           
        public void AddReplace()
            {
                int nMaxReplaceID = 0;
                OleDbCommand cmd = DBController.Instance.GetCommand();
                string sSql = "";

                try
                {
                    sSql = "SELECT MAX([ReplaceID]) FROM t_CSDReplace";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nMaxReplaceID = 1;
                    }
                    else
                    {
                        nMaxReplaceID = Convert.ToInt32(maxID) + 1;
                    }
                    _nReplaceID = nMaxReplaceID;


                    sSql = "INSERT INTO t_CSDReplace(ReplaceID,Type,JobID,CreateDate,CreateUserID,Status,InvoiceCashMemo,DateOfPurchase, "+
                           "FullWarrantyPeriod,ReiseRemarks,PapersLocation,EDD) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";

                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);
                    cmd.Parameters.AddWithValue("Type", _nType);
                    cmd.Parameters.AddWithValue("JobID", _nJobID);
                    cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                    cmd.Parameters.AddWithValue("Status", _nStatus);
                    cmd.Parameters.AddWithValue("InvoiceCashMemo", _sInvoiceCashMemo);
                    cmd.Parameters.AddWithValue("DateOfPurchase", _dDateOfPurchase);
                    cmd.Parameters.AddWithValue("FullWarrantyPeriod", _dFullWarrantyPeriod);
                    cmd.Parameters.AddWithValue("ReiseRemarks", _sReiseRemarks);
                    cmd.Parameters.AddWithValue("PapersLocation", (int)Dictionary.ReplacePapersLocation.Workshop);
                    cmd.Parameters.AddWithValue("EDD", _dEDD);
                    


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }

        public void UpdateDelNStatCassandra()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE TELServiceDB.dbo.Job SET DeliveryDate=?,IsDelivered=? WHERE JobNo=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DeliveryDate", DateTime.Now);
                cmd.Parameters.AddWithValue("IsDelivered", 1);

                cmd.Parameters.AddWithValue("JobNo", ReplaceJobFromCassandra.JobNo);

                //cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditReplace()
            {

                OleDbCommand cmd = DBController.Instance.GetCommand();

                try
                {

                    cmd.CommandText = "UPDATE t_CSDReplace SET InvoiceCashMemo=?,DateOfPurchase=?,FullWarrantyPeriod=?,ReiseRemarks=?,EDD=? WHERE ReplaceID=?";

                    cmd.CommandType = CommandType.Text;


                    //cmd.Parameters.AddWithValue("JobID", _nJobID);
                    cmd.Parameters.AddWithValue("InvoiceCashMemo", _sInvoiceCashMemo);
                    cmd.Parameters.AddWithValue("DateOfPurchase", _dDateOfPurchase);
                    cmd.Parameters.AddWithValue("FullWarrantyPeriod", _dFullWarrantyPeriod);
                    cmd.Parameters.AddWithValue("ReiseRemarks", _sReiseRemarks);
                    cmd.Parameters.AddWithValue("EDD", _dEDD);

                    cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }

        public void ApproveReplace()
            {

                OleDbCommand cmd = DBController.Instance.GetCommand();
                string sSql = "";
                try
                {

                    cmd.CommandText = "UPDATE t_CSDReplace SET Status=? WHERE ReplaceID=?";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("Status", (int)Dictionary.ReplaceStatusCriteria.Approve);

                    cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }

        public void DepositReplace()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDReplace SET Status=?, PapersLocation=? WHERE ReplaceID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", (int)Dictionary.ReplaceStatusCriteria.DepositToLog);
                cmd.Parameters.AddWithValue("PapersLocation", (int)Dictionary.ReplacePapersLocation.Logistics);

                cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void IssueReplace()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDReplace SET IssueProductID=?,IssueDate=?,Status=?, IssueProductBarcode=? WHERE ReplaceID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IssueProductID", _nIssueProductID);
                cmd.Parameters.AddWithValue("IssueDate", _dIssueDate);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.ReplaceStatusCriteria.IssueFromLog);
                cmd.Parameters.AddWithValue("IssueProductBarcode", _sIssueProductBarcode);

                cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void SendToCSDReplace()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDReplace SET Status=?,PapersLocation=?,PapersSendDate=? WHERE ReplaceID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", (int)Dictionary.ReplaceStatusCriteria.SentToCSD);
                cmd.Parameters.AddWithValue("PapersLocation", (int)Dictionary.ReplacePapersLocation.SendToCSD);
                cmd.Parameters.AddWithValue("PapersSendDate",DateTime.Now);

                cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ReceiveAtCSDReplace()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDReplace SET Status=?,PapersLocation=?,PapersReceiveDate=? WHERE ReplaceID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", (int)Dictionary.ReplaceStatusCriteria.ReceiveAtCSD);
                cmd.Parameters.AddWithValue("PapersLocation", (int)Dictionary.ReplacePapersLocation.ReceiveAtCSD);
                cmd.Parameters.AddWithValue("PapersReceiveDate", DateTime.Now);

                cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InformToCustomerReplace()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDReplace SET ApproxDeliveryDate=?,Status=? WHERE ReplaceID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ApproxDeliveryDate", _dApproxDeliveryDate);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.ReplaceStatusCriteria.InformToCustomer);

                cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeliveryReplace()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDReplace SET DeliveryDate=?,FromWH=?,ModeofDelivery=?,Deliveredby=?,Status=?,ConsignmentNo=?,CourierID=? WHERE ReplaceID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DeliveryDate", _dDeliveryDate);
                cmd.Parameters.AddWithValue("FromWH", _nFromWH);
                cmd.Parameters.AddWithValue("ModeofDelivery", _nModeofDelivery);
                cmd.Parameters.AddWithValue("Deliveredby", _sDeliveredby);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ConsignmentNo", _sConsignmentNo);
                cmd.Parameters.AddWithValue("CourierID", _nCourierID);
                

                cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void PaperAcknowledgeReplace()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDReplace SET Status=? WHERE ReplaceID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", (int)Dictionary.ReplaceStatusCriteria.PaperAcknowledge);

                cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void HappyCallReplace()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDReplace SET HappyCallStatus=?,Status=? WHERE ReplaceID=?";
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("HappyCallStatus", _nHappyCallStatus);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.ReplaceStatusCriteria.HappyCall);

                cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void CancelReplace()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDReplace SET Status=? WHERE ReplaceID=?";
                cmd.CommandType = CommandType.Text;

                
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.ReplaceStatusCriteria.Cancel);

                cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteReplace()
            {
                OleDbCommand cmd = DBController.Instance.GetCommand();

                try
                {
                    Complain oItem = new Complain();

                    cmd.CommandText = "DELETE FROM t_CSDReplace WHERE [ReplaceID]=?";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {

                    throw (ex);
                }
            }

        public void ReplacePapersSend()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDReplace SET PapersLocation=?, PapersSendDate=? WHERE ReplaceID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PapersLocation", (int)Dictionary.ReplacePapersLocation.SendToCSD);
                cmd.Parameters.AddWithValue("PapersSendDate", DateTime.Now);

                cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ReplacePapersReceive()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDReplace SET PapersLocation=?, PapersReceiveDate=? WHERE ReplaceID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PapersLocation", (int)Dictionary.ReplacePapersLocation.ReceiveAtCSD);
                cmd.Parameters.AddWithValue("PapersReceiveDate", DateTime.Now);

                cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateComments()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_CSDReplace SET SupReasonID=?,SupComments=?,SupDate=?,TmReasonID=?,TmComments=?,TmDate=?,CsmReasonID=?, " +
                                  "CsmComments=?,CsmDate=?, HoSReasonID=?, HoSComments=?, HoSDate=?,IssueProductID=?,HSReasonID=?,HSComments=?  WHERE ReplaceID=?";

                cmd.CommandType = CommandType.Text;


                //cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("SupReasonID", _nSupReasonID);
                cmd.Parameters.AddWithValue("SupComments", _sSupComments);
                cmd.Parameters.AddWithValue("SupDate", _dSupDate);
                cmd.Parameters.AddWithValue("TmReason", _nTmReasonID);
                cmd.Parameters.AddWithValue("TmComments", _sTmComments);
                cmd.Parameters.AddWithValue("TmDate", _dTmDate);
                cmd.Parameters.AddWithValue("CsmReasonID", _nCusReasonID);
                cmd.Parameters.AddWithValue("CsmComments", _sCusComments);
                cmd.Parameters.AddWithValue("CsmDate", _dCusDate);
                cmd.Parameters.AddWithValue("HoSReasonID", _nHsReasonID);
                cmd.Parameters.AddWithValue("HoSComments", _sHsComments);
                cmd.Parameters.AddWithValue("HoSDate", _dHsDate);
                cmd.Parameters.AddWithValue("HSReasonID", _nHOSReasonID);
                cmd.Parameters.AddWithValue("HSComments", _sHOSComments);

                if (_nIssueProductID != 0)
                {
                    cmd.Parameters.AddWithValue("IssueProductID", _nIssueProductID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IssueProductID", null);
                }

                cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private int _nSalesQty;
        public int SalesQty
        {
            get { return _nSalesQty; }
            set { _nSalesQty = value; }
        }
        private int _nSvrQty;
        public int SvrQty
        {
            get { return _nSvrQty; }
            set { _nSvrQty = value; }
        }
        private int _nRepQty;
        public int RepQty
        {
            get { return _nRepQty; }
            set { _nRepQty = value; }
        }

        public bool RefreshByProductCode(string sProductCode)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {

                cmd.CommandText = "select ProductCode, Sum(SalesQty)SalesQty, Sum(SvcQty)SvcQty, Sum(RepQty)RepQty from   " +
                "(  " +
                "Select ProductCode,Sum(SalesQty+FreeQty) as SalesQty, 0 as SvcQty,0 AS RepQty from  " +
                "DWDB.dbo.t_SalesDataCustomerProduct a, t_Product b " +
                "Where a.ProductID = b.ProductID and ProductCode = '" + sProductCode + "' and CompanyName = 'TEL' " +
                "Group by ProductCode " +

                "UNION ALL  " +

                "SELECT PD.ProductCode as ProductCode, 0 as SalesQty, 0 as SvcQty, SUM (PSTI.Qty) AS RepQty  " +
                "FROM t_ProductStockTran AS PST  " +
                "INNER JOIN t_ProductStockTranItem AS PSTI  " +
                "ON PST.TranID=PSTI.TranID  " +
                "INNER JOIN (SELECT ProductID,ProductCode FROM  t_Product) AS PD  " +
                "ON PSTI.ProductID=PD.ProductID  " +
                "WHERE PST.TrantypeID = 21 and PD.ProductCode='" + sProductCode + "'  " +
                "GROUP BY PD.ProductCode  " +

                "UNION ALL  " +

                "Select ProductCode, 0 as SalesQty, Sum(JobQty) SvcQty, 0 AS RepQty from  " +
                "( " +
                "Select ProductCode, Count(JobID) as JobQty from dbo.t_CSDJob a, t_Product b  " +
                "Where JobType = 1 and ServiceType <> 3 and Status Not IN (15,20) " +
                "and a.ProductID = b.ProductID and ProductCode =  '" + sProductCode + "' " +
                "Group by ProductCode " +
                "UNION ALL " +
                "Select P.Code AS ProductCode, COUNT(J.JobID) JobQty " +
                "FROM TELServiceDB.dbo.Job AS J  " +
                "INNER JOIN TELServiceDB.dbo.Product AS P  " +
                "ON P.ProductID=J.ProductID  " +
                "WHERE J.JobType=1 AND J.ServiceType Not in (4)AND J.JobStatus NOT IN (13,17)  " +
                "and P.Code='" + sProductCode + "'  " +
                "GROUP BY P.Code  " +
                ")x group by ProductCode " +
                ") final Group by ProductCode";


                //cmd.CommandText = "select ProductCode, Sum(SalesQty)SalesQty, Sum(SvcQty)SvcQty, Sum(RepQty)RepQty from  " +
                //    "( " +
                //    "select ProductCode,Sum(SalesQty) as SalesQty, 0 as SvcQty,0 AS RepQty " +
                //    "from " +
                //    "( " +
                //    "select ProductCode,SalesQty " +
                //    "from ( " +
                //    "SELECT ProductID, ISNULL(SUM(CrSalesQty) - ABS(SUM(DrSalesQty)), 0) AS SalesQty " +
                //    "FROM ( " +
                //    "SELECT cd.ProductID, SUM(cd.Quantity) AS CrSalesQty, 0 AS DrSalesQty " +
                //    "FROM t_SalesInvoice AS im INNER JOIN " +
                //    "t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                //    "WHERE (im.InvoiceTypeID IN (1, 2, 4, 5)) AND (im.InvoiceStatus NOT IN (3)) " +
                //    "GROUP BY cd.ProductID " +
                //    "UNION ALL " +
                //    "SELECT cd.ProductID, 0 AS CrSalesQty, SUM(cd.Quantity) AS DrSalesQty " +
                //    "FROM t_SalesInvoice AS im INNER JOIN " +
                //    "t_SalesInvoiceDetail AS cd ON im.InvoiceID = cd.InvoiceID " +
                //    "WHERE (im.InvoiceTypeID IN (6, 7, 9, 10, 12)) AND (im.InvoiceStatus NOT IN (3)) " +
                //    "GROUP BY cd.ProductID " +
                //    ") AS p2 " +
                //    "GROUP BY ProductID " +
                //    ") AA " +
                //    "inner join (Select ProductID, ProductCode from v_ProductDetails Where ProductCode='" + sProductCode + "') Prod " +
                //    "on Prod.ProductID=AA.ProductID " +
                //    ") BB " +
                //    "group by ProductCode " +

                //    "UNION ALL " +

                //    "SELECT PD.ProductCode as ProductCode, 0 as SalesQty, 0 as SvcQty, SUM (PSTI.Qty) AS RepQty " +
                //    "FROM t_ProductStockTran AS PST " +
                //    "INNER JOIN t_ProductStockTranItem AS PSTI " +
                //    "ON PST.TranID=PSTI.TranID " +
                //    "INNER JOIN (SELECT ProductID,ProductCode FROM  v_ProductDetails ) AS PD " +
                //    "ON PSTI.ProductID=PD.ProductID " +
                //    "WHERE PST.TrantypeID = 21 and PD.ProductCode='" + sProductCode + "' " +
                //    "GROUP BY PD.ProductCode " +

                //    "UNION ALL " +

                //    "Select P.Code AS ProductCode, 0 as SalesQty, COUNT(J.JobID) SvcQty, 0 AS RepQty " +
                //    "FROM TELServiceDB.dbo.Job AS J " +
                //    "INNER JOIN TELServiceDB.dbo.Product AS P " +
                //    "ON P.ProductID=J.ProductID " +
                //    "WHERE J.JobType=1 AND J.ServiceType Not in (4)AND J.JobStatus NOT IN (15,20) " +
                //    "and P.Code='" + sProductCode + "' " +
                //    "GROUP BY P.Code " +
                //    ") final Group by ProductCode";

                cmd.CommandType = CommandType.Text;
                DBController.Instance.BeginNewTransaction();
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nSalesQty = int.Parse(reader["SalesQty"].ToString());
                    _nSvrQty = int.Parse(reader["SvcQty"].ToString());
                    _nRepQty = int.Parse(reader["RepQty"].ToString());

                    nCount++;
                }
                DBController.Instance.CommitTransaction();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) return true;
            else return false;
        }

        }

        public class Replaces : CollectionBase
        {
        public Replace this[int i]
            {
                get { return (Replace)InnerList[i]; }
                set { InnerList[i] = value; }
            }

        public void Add(Replace oReplace)
            {
                InnerList.Add(oReplace);
            }

            //public void RefreshUser()
            //{
            //    User.UserId = _nCreateUserID;
            //    User.RefreshByUserID();
            //}

            public void Refresh(DateTime dtFromDate, DateTime dtToDate, String txtReplaceID, String txtJobNo, int nStatus, int nPapersLocation, String txtCustomerName, String txtAddress, String txtContactNo, int nCheckedAll)//
            {
                dtToDate = dtToDate.Date.AddDays(1);
                InnerList.Clear();
                OleDbCommand cmd = DBController.Instance.GetCommand();

                string sSql = @"Select * From 
                            (
                            Select * From 
                            (
                            SELECT R.ReplaceID ReplaceID,Type,J.JobID,JobNo,J.CustomerName,J.CustomerAddress as FirstAddress,J.MobileNo as Mobile,
                            ProductSerialNo as SerialNo,R.Status,P.ProductCode ProductCode, P.ProductName ProductName, 
                            FaultDescription as Description, R.CreateuserID,R.CreateDate, 
                            ISNULL(cast(DateOfPurchase as varchar(20)), getdate())DateOfPurchase, 
                            ISNULL(cast(FullWarrantyPeriod as varchar(20)), getdate())FullWarrantyPeriod, 
                            IsNull(InvoiceCashMemo,'')InvoiceCashMemo, 
                            IsNull(ReiseRemarks,'')ReiseRemarks,H.Remarks, 
                            Source=Case 
                            WHEN J.RefChannelID=3 THEN 'EnA_Distribution' 
                            WHEN J.RefChannelID=4 Then 'TD_Retail' 
                            WHEN J.RefChannelID=5 THEN 'TD_Corporate' 
                            WHEN J.RefChannelID=13 THEN 'B2B'
                            WHEN J.RefChannelID=98 THEN 'ThirtPartyService'
                            else 'Others' End, 
                            IsNull(C.CustomerName,'Not Applicable') SourceName, 
                            PapersLocationDetail=CASE 
                            WHEN PapersLocation=0 THEN 'Workshop' 
                            WHEN PapersLocation=1 THEN 'Logistics' 
                            WHEN PapersLocation=2 THEN 'Send to CSD' 
                            WHEN PapersLocation=3 THEN 'Receive at CSD' END, 
                            ISNULL(CONVERT(VARCHAR(26),PapersSendDate,109),getdate())PapersSendDate, 
                            ISNULL(CONVERT(VARCHAR(26),PapersReceiveDate,109),getdate())PapersReceiveDate, 
                            PD.ProductCode IssueProductCode,PD.ProductName IssueProductName, R.IssueProductBarcode,J.CreateDate JobCreationDate, 
                            ISNULL(cast(IssueDate as varchar(11)), getdate())IssueDate , 
                            ISNULL(cast(ApproxDeliveryDate as varchar(20)), getdate())ApproxDeliveryDate, 
                            ISNULL(cast(R.DeliveryDate as varchar(11)), getdate())DeliveryDate, 
                            FromWHName=CASE 
                            WHEN FromWH=0 THEN 'CWH' 
                            WHEN FromWH=1 THEN 'Branch' 
                            ELSE '' END, 
                            ModeofDeliveryDet=CASE 
                            WHEN ModeofDelivery=0 THEN 'Walk-In' 
                            WHEN ModeofDelivery=1 THEN 'Home Delivery' 
                            WHEN ModeofDelivery=2 THEN 'By Courier' 
                            WHEN ModeofDelivery=3 THEN 'By CHW Vehicle' 
                            ELSE '' End,IsNull(CourierID,0)CourierID, 
                            IsNull(CS.Name,'')CourierServiceName, IsNUll(ConsignmentNO,'')ConsignmentNO,IsNUll(Deliveredby,'')Deliveredby, 
                            HappyCallStatus=CASE 
                            When HappyCallStatus=0 Then 'Satisfy' 
                            When HappyCallStatus=1 Then 'Moderate' 
                            When HappyCallStatus=2 Then 'Dissatisfy' 
                            else '' End,IsNull(R.EDD,getdate())EDD_Edit,R.EDD EDD_RPT, 
                            CanRem.Remarks CanRem,DelRem.Remarks DelRem,HppRem.Remarks HppRem,InfoRem.Remarks InfoRem,IssRem.Remarks IssRem, 
                            ISNULL(SupReasonId,0) SupReasonId, IsNull(SupComments,'')SupComments, 
                            ISNULL(TMReasonID,0)TMReasonID, IsNull(TMComments,'')TMComments, 
                            ISNULL(CSMReasonID,0)CSMReasonID, IsNull(CSMComments,'')CSMComments, 
                            ISNULL(HosReasonID,0)HosReasonID,IsNull(HoSComments,'')HoSComments,
                            ISNULL(HSReasonID,0)HSReasonID,IsNull(HSComments,'')HSComments
                            FROM t_CSDReplace R 
                            INNER JOIN TELSYSDB.dbo.t_CSDJob J  
                            ON R.JobID=J.JobID 
                            INNER JOIN TELSYSDB.dbo.v_ProductDetails P 
                            ON J.ProductID=P.ProductID  
                            INNER JOIN TELSYSDB.dbo.t_CSDProductFault BD 
                            ON BD.FaultID=J.PrimaryFaultID 
                            LEFT OUTER JOIN 
                            (Select HID.JobID,JHA.Remarks FROM 
                            (Select Max(JH.JobHistoryID) AS ID, JH.JobID 
                            FROM TELSYSDB.dbo.t_CSDJobHistory JH 
                            WHERE JH.StatusID=15 
                            GROUP BY JobId)HID 
                            INNER JOIN 
                            TELSYSDB.dbo.t_CSDJobHistory JHA 
                            ON JHA.JobHistoryID=HID.ID)H 
                            ON J.JobID=H.JobID 
                            LEFT OUTER JOIN TELSYSDB.dbo.v_CustomerDetails C 
                            ON J.RefSalesPointID=C.CustomerID 
                            LEFT OUTER JOIN v_ProductDetails PD 
                            ON R.IssueProductID=PD.ProductID 
                            LEFT OUTER JOIN TELSYSDB.dbo.t_CSDCourierService CS 
                            ON CS.CourierServiceID=R.CourierID 
                            Left OUter JOIN (Select RH.ReplaceID, Remarks From t_CSDReplaceHistory RH Where Status=10)CanRem 
                            ON R.ReplaceID=CanRem.ReplaceID 
                            Left OUter JOIN (Select RH.ReplaceID, Remarks From t_CSDReplaceHistory RH Where Status=7)DelRem 
                            ON R.ReplaceID=DelRem.ReplaceID 
                            Left OUter JOIN (Select RH.ReplaceID, Remarks From t_CSDReplaceHistory RH Where Status=9)HppRem 
                            ON R.ReplaceID=HppRem.ReplaceID 
                            Left OUter JOIN (Select RH.ReplaceID, Remarks From t_CSDReplaceHistory RH Where Status=6)InfoRem 
                            ON R.ReplaceID=InfoRem.ReplaceID 
                            Left OUter JOIN (Select RH.ReplaceID, Remarks From t_CSDReplaceHistory RH Where Status=3)IssRem 
                            ON R.ReplaceID=IssRem.ReplaceID 
                            ) as CJ WHERE Type=1

                            Union All
                            Select * From 
                            (
                            SELECT R.ReplaceID ReplaceID,R.Type,J.JobID,JobNo,CustomerName,FirstAddress,J.Mobile,
                            SerialNo,Status,P.Code ProductCode, P.Name ProductName, 
                            Description, CreateuserID,R.CreateDate, 
                            ISNULL(cast(DateOfPurchase as varchar(20)), getdate())DateOfPurchase, 
                            ISNULL(cast(FullWarrantyPeriod as varchar(20)), getdate())FullWarrantyPeriod, 
                            IsNull(InvoiceCashMemo,'')InvoiceCashMemo, 
                            IsNull(ReiseRemarks,'')ReiseRemarks,H.Remarks, 
                            Source=Case 
                            WHEN J.ChannelType=1 THEN 'Walk-In Customer' 
                            WHEN J.ChannelType=3 Then 'TD' 
                            WHEN J.ChannelType=2 THEN 'Dealer(E&A)' 
                            WHEN J.ChannelType=5 THEN 'IPB' End, 
                            IsNull(C.Name,'Not Applicable') SourceName, PapersLocationDetail=CASE 
                            WHEN PapersLocation=0 THEN 'Workshop' 
                            WHEN PapersLocation=1 THEN 'Logistics' 
                            WHEN PapersLocation=2 THEN 'Send to CSD' 
                            WHEN PapersLocation=3 THEN 'Receive at CSD' END, 
                            ISNULL(CONVERT(VARCHAR(26),PapersSendDate,109),getdate())PapersSendDate, 
                            ISNULL(CONVERT(VARCHAR(26),PapersReceiveDate,109),getdate())PapersReceiveDate, 
                            PD.ProductCode IssueProductCode,PD.ProductName IssueProductName, R.IssueProductBarcode,JobCreationDate, 
                            ISNULL(cast(IssueDate as varchar(11)), getdate())IssueDate , 
                            ISNULL(cast(ApproxDeliveryDate as varchar(20)), getdate())ApproxDeliveryDate, 
                            ISNULL(cast(R.DeliveryDate as varchar(11)), getdate())DeliveryDate, 
                            FromWHName=CASE 
                            WHEN FromWH=0 THEN 'CWH' 
                            WHEN FromWH=1 THEN 'Branch' 
                            ELSE '' END, 
                            ModeofDeliveryDet=CASE 
                            WHEN ModeofDelivery=0 THEN 'Walk-In' 
                            WHEN ModeofDelivery=1 THEN 'Home Delivery' 
                            WHEN ModeofDelivery=2 THEN 'By Courier' 
                            WHEN ModeofDelivery=3 THEN 'By CHW Vehicle' 
                            ELSE '' End,IsNull(CourierID,0)CourierID, 
                            IsNull(CS.Name,'')CourierServiceName, IsNUll(ConsignmentNO,'')ConsignmentNO,IsNUll(Deliveredby,'')Deliveredby, 
                            HappyCallStatus=CASE 
                            When HappyCallStatus=0 Then 'Satisfy' 
                            When HappyCallStatus=1 Then 'Moderate' 
                            When HappyCallStatus=2 Then 'Dissatisfy' 
                            else '' End,IsNull(R.EDD,getdate())EDD_Edit,R.EDD EDD_RPT, 
                            CanRem.Remarks CanRem,DelRem.Remarks DelRem,HppRem.Remarks HppRem,InfoRem.Remarks InfoRem,IssRem.Remarks IssRem, 
                            ISNULL(SupReasonId,0) SupReasonId, IsNull(SupComments,'')SupComments, 
                            ISNULL(TMReasonID,0)TMReasonID, IsNull(TMComments,'')TMComments, 
                            ISNULL(CSMReasonID,0)CSMReasonID, IsNull(CSMComments,'')CSMComments, 
                            ISNULL(HosReasonID,0)HosReasonID,IsNull(HoSComments,'')HoSComments,
                            ISNULL(HSReasonID,0)HSReasonID,IsNull(HSComments,'')HSComments
                            FROM t_CSDReplace R INNER JOIN TELServiceDB.dbo.Job J  
                            ON R.JobID=J.JobID INNER JOIN TELServiceDB.dbo.Product P ON J.ProductID=P.ProductID  
                            INNER JOIN TELServiceDB.dbo.BasicDescription BD 
                            ON BD.DescriptionID=J.FaultDescriptionID 
                            LEFT OUTER JOIN (Select HID.JobID,JHA.Remarks FROM (Select Max(JH.ID) AS ID, JH.JobID 
                            FROM TELServiceDB.dbo.JobHistory JH WHERE JH.Status='Replacement' GROUP BY JobId)HID 
                            INNER JOIN TELServiceDB.dbo.JobHistory JHA ON JHA.ID=HID.ID)H ON J.JobID=H.JobID 
                            LEFT OUTER JOIN TELServiceDB.dbo.Channel C ON J.ChannelID=C.ID 
                            LEFT OUTER JOIN v_ProductDetails PD ON R.IssueProductID=PD.ProductID 
                            LEFT OUTER JOIN TELServiceDB.dbo.CourierService CS 
                            ON CS.CourierServiceID=R.CourierID 
                            Left OUter JOIN (Select RH.ReplaceID, Remarks From t_CSDReplaceHistory RH Where Status=10)CanRem 
                            ON R.ReplaceID=CanRem.ReplaceID 
                            Left OUter JOIN (Select RH.ReplaceID, Remarks From t_CSDReplaceHistory RH Where Status=7)DelRem 
                            ON R.ReplaceID=DelRem.ReplaceID 
                            Left OUter JOIN (Select RH.ReplaceID, Remarks From t_CSDReplaceHistory RH Where Status=9)HppRem 
                            ON R.ReplaceID=HppRem.ReplaceID 
                            Left OUter JOIN (Select RH.ReplaceID, Remarks From t_CSDReplaceHistory RH Where Status=6)InfoRem 
                            ON R.ReplaceID=InfoRem.ReplaceID 
                            Left OUter JOIN (Select RH.ReplaceID, Remarks From t_CSDReplaceHistory RH Where Status=3)IssRem 
                            ON R.ReplaceID=IssRem.ReplaceID
                            ) as Old WHERE Type=0
                            ) Main where 1=1";

                if (nCheckedAll != -1)
                {
                    sSql = sSql + " and CreateDate BETWEEN '" + dtFromDate.Date + "'AND '" + dtToDate.Date + "' AND CreateDate < '" + dtToDate.Date + "'";
                }

                if (txtReplaceID != "")
                {
                    sSql = sSql + " AND ReplaceID ='" + txtReplaceID + "'";
                }
                if (txtJobNo != "")
                {
                    txtJobNo = "%" + txtJobNo + "%";
                    sSql = sSql + " AND JobNo LIKE '" + txtJobNo + "'";
                }
                if (nStatus > -1)
                {
                    sSql = sSql + " AND Status ='" + nStatus + "'";
                }
                if (nPapersLocation != -1)
                {
                    sSql = sSql + " AND PapersLocation ='" + nPapersLocation + "'";
                }
                if (txtCustomerName != "")
                {
                    txtCustomerName = "%" + txtCustomerName + "%";
                    sSql = sSql + " AND CustomerName LIKE '" + txtCustomerName + "'";
                }
                if (txtAddress != "")
                {
                    txtAddress = "%" + txtAddress + "%";
                    sSql = sSql + " AND FirstAddress LIKE '" + txtAddress + "'";
                }
                if (txtContactNo != "")
                {
                    txtContactNo = "%" + txtContactNo + "%";
                    sSql = sSql + " AND Mobile LIKE '" + txtContactNo + "'";
                }
                sSql = sSql + " order by CreateDate ";

                try
                {
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Replace oReplace = new Replace();

                        oReplace.ReplaceID = (int)reader["ReplaceID"];
                        oReplace.ReplaceJobFromCassandra.JobNo = (string)reader["JobNo"];
                        oReplace.ReplaceJobFromCassandra.CustomerName = (string)reader["CustomerName"];
                        oReplace.ReplaceJobFromCassandra.FirstAddress = (string)reader["FirstAddress"];
                        oReplace.ReplaceJobFromCassandra.Mobile = (string)reader["Mobile"];
                        oReplace.ReplaceJobFromCassandra.SerialNo = (string)reader["SerialNo"];
                        oReplace.Status = int.Parse(reader["Status"].ToString());
                        oReplace.ReplaceJobFromCassandra.ProductCode = (string)reader["ProductCode"];
                        oReplace.ReplaceJobFromCassandra.ProductName = (string)reader["ProductName"];
                        oReplace.FaultDescription = (string)reader["Description"];
                        oReplace.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                        oReplace.DateOfPurchase = (Object)reader["DateOfPurchase"];
                        oReplace.InvoiceCashMemo = (Object)reader["InvoiceCashMemo"];
                        oReplace.FullWarrantyPeriod = (Object)reader["FullWarrantyPeriod"];
                        oReplace.RemarksAcutalFault = (Object)reader["Remarks"];
                        oReplace.Source = (Object)reader["Source"];
                        oReplace.SourceName = (Object)reader["SourceName"];
                        oReplace.Product.ProductCode = reader["IssueProductCode"].ToString();
                        oReplace.Product.ProductName = reader["IssueProductName"].ToString();
                        oReplace.IssueProductBarcode = (Object)reader["IssueProductBarcode"];
                        oReplace.ReiseRemarks = (Object)reader["ReiseRemarks"].ToString();
                        oReplace.ReplaceJobFromCassandra.JobCreationDate = Convert.ToDateTime(reader["JobCreationDate"].ToString());
                        oReplace.CourierFromCassandra.CourierServiceName = (string)reader["CourierServiceName"].ToString();
                        oReplace.CourierFromCassandra.CourierServiceID = int.Parse(reader["CourierID"].ToString());
                        oReplace.ConsignmentNo = (Object)reader["ConsignmentNO"].ToString();
                        oReplace.Deliveredby = (Object)reader["Deliveredby"].ToString();
                        oReplace.HappyCallStat = (Object)reader["HappyCallStatus"].ToString();
                        oReplace.ModeofDeliveryName = (Object)reader["ModeofDeliveryDet"].ToString();
                        oReplace.IssueDate = (Object)reader["IssueDate"].ToString();
                        oReplace.ApproxDeliveryDate = (Object)reader["ApproxDeliveryDate"];
                        oReplace.DeliveryDate = (Object)reader["DeliveryDate"].ToString();
                        oReplace.DeliveredFromWHName = (Object)reader["FromWHName"];
                        oReplace.EDD = (Object)reader["EDD_Edit"].ToString();
                        oReplace.EDD1 = (Object)reader["EDD_RPT"].ToString();
                        oReplace.CancelRemarks = (Object)reader["CanRem"].ToString();
                        oReplace.DeliveryRemarks = (Object)reader["DelRem"].ToString();
                        oReplace.HappyCallRemarks = (Object)reader["HppRem"].ToString();
                        oReplace.InformedRemarks = (Object)reader["InfoRem"].ToString();
                        oReplace.IssueRemarks = (Object)reader["IssRem"].ToString();
                        oReplace.SupComments = (string)reader["SupComments"].ToString();
                        oReplace.TmComments = (string)reader["TMComments"].ToString();
                        oReplace.CusComments = (string)reader["CSMComments"].ToString();
                        oReplace.HsComments = (string)reader["HoSComments"].ToString();
                        oReplace.HOSComments = (string)reader["HSComments"].ToString();
                        InnerList.Add(oReplace);
                    }
                    reader.Close();
                    InnerList.TrimToSize();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            public void RefreshAll(String txtReplaceID, String txtJobNo, int nStatus, int nPapersLocation, String txtCustomerName, String txtAddress, String txtContactNo)//
            {
                InnerList.Clear();
                OleDbCommand cmd = DBController.Instance.GetCommand();

                string sSql = "SELECT R.ReplaceID ReplaceID,J.JobID,JobNo,CustomerName,FirstAddress,J.Mobile,SerialNo,Status,P.Code ProductCode, P.Name ProductName, " +
                                    "Description, CreateuserID,R.CreateDate, " +
                                    "ISNULL(cast(DateOfPurchase as varchar(20)), getdate())DateOfPurchase, " +
                                    "ISNULL(cast(FullWarrantyPeriod as varchar(20)), getdate())FullWarrantyPeriod, " +
                                    "IsNull(InvoiceCashMemo,'')InvoiceCashMemo, " +
                                    "IsNull(ReiseRemarks,'')ReiseRemarks,H.Remarks, " +
                                    "Source=Case " +
                                    "WHEN J.ChannelType=1 THEN 'Walk-In Customer' " +
                                    "WHEN J.ChannelType=3 Then 'TD' " +
                                    "WHEN J.ChannelType=2 THEN 'Dealer(E&A)' " +
                                    "WHEN J.ChannelType=5 THEN 'IPB' End, " +
                                    "IsNull(C.Name,'Not Applicable') SourceName, PapersLocationDetail=CASE " +
                                    "WHEN PapersLocation=0 THEN 'Workshop' " +
                                    "WHEN PapersLocation=1 THEN 'Logistics' " +
                                    "WHEN PapersLocation=2 THEN 'Send to CSD' " +
                                    "WHEN PapersLocation=3 THEN 'Receive at CSD' END, " +
                                    "ISNULL(CONVERT(VARCHAR(26),PapersSendDate,109),getdate())PapersSendDate, " +
                                    "ISNULL(CONVERT(VARCHAR(26),PapersReceiveDate,109),getdate())PapersReceiveDate, " +
                                    "PD.ProductCode IssueProductCode,PD.ProductName IssueProductName, R.IssueProductBarcode,JobCreationDate, " +
                                    "ISNULL(cast(IssueDate as varchar(11)), getdate())IssueDate , " +
                                    "ISNULL(cast(ApproxDeliveryDate as varchar(20)), getdate())ApproxDeliveryDate, " +
                                    "ISNULL(cast(R.DeliveryDate as varchar(11)), getdate())DeliveryDate, " +
                                    "FromWHName=CASE " +
                                    "WHEN FromWH=0 THEN 'CWH' " +
                                    "WHEN FromWH=1 THEN 'Branch' " +
                                    "ELSE '' END, " +
                                    "ModeofDeliveryDet=CASE " +
                                    "WHEN ModeofDelivery=0 THEN 'Walk-In' " +
                                    "WHEN ModeofDelivery=1 THEN 'Home Delivery' " +
                                    "WHEN ModeofDelivery=2 THEN 'By Courier' " +
                                    "WHEN ModeofDelivery=3 THEN 'By CHW Vehicle' " +
                                    "ELSE '' End,IsNull(CourierID,0)CourierID, " +
                                    "IsNull(CS.Name,'')CourierServiceName, IsNUll(ConsignmentNO,'')ConsignmentNO,IsNUll(Deliveredby,'')Deliveredby, " +
                                    "HappyCallStatus=CASE " +
                                    "When HappyCallStatus=0 Then 'Satisfy' " +
                                    "When HappyCallStatus=1 Then 'Moderate' " +
                                    "When HappyCallStatus=2 Then 'Dissatisfy' " +
                                    "else '' End,IsNull(R.EDD,getdate())EDD_Edit,R.EDD EDD_RPT, " +
                                    "CanRem.Remarks CanRem,DelRem.Remarks DelRem,HppRem.Remarks HppRem,InfoRem.Remarks InfoRem,IssRem.Remarks IssRem " +
                                    "FROM t_CSDReplace R INNER JOIN TELServiceDB.dbo.Job J  " +
                                    "ON R.JobID=J.JobID INNER JOIN TELServiceDB.dbo.Product P ON J.ProductID=P.ProductID  " +
                                    "INNER JOIN TELServiceDB.dbo.BasicDescription BD " +
                                    "ON BD.DescriptionID=J.FaultDescriptionID " +
                                    "LEFT OUTER JOIN (Select HID.JobID,JHA.Remarks FROM (Select Max(JH.ID) AS ID, JH.JobID " +
                                    "FROM TELServiceDB.dbo.JobHistory JH WHERE JH.Status='Replacement' GROUP BY JobId)HID " +
                                    "INNER JOIN TELServiceDB.dbo.JobHistory JHA ON JHA.ID=HID.ID)H ON J.JobID=H.JobID " +
                                    "LEFT OUTER JOIN TELServiceDB.dbo.Channel C ON J.ChannelID=C.ID " +
                                    "LEFT OUTER JOIN v_ProductDetails PD ON R.IssueProductID=PD.ProductID " +
                                    "LEFT OUTER JOIN TELServiceDB.dbo.CourierService CS " +
                                    "ON CS.CourierServiceID=R.CourierID " +
                                    "Left OUter JOIN (Select RH.ReplaceID, Remarks From t_CSDReplaceHistory RH Where Status=10)CanRem " +
                                    "ON R.ReplaceID=CanRem.ReplaceID " +
                                    "Left OUter JOIN (Select RH.ReplaceID, Remarks From t_CSDReplaceHistory RH Where Status=7)DelRem " +
                                    "ON R.ReplaceID=DelRem.ReplaceID " +
                                    "Left OUter JOIN (Select RH.ReplaceID, Remarks From t_CSDReplaceHistory RH Where Status=9)HppRem " +
                                    "ON R.ReplaceID=HppRem.ReplaceID " +
                                    "Left OUter JOIN (Select RH.ReplaceID, Remarks From t_CSDReplaceHistory RH Where Status=6)InfoRem " +
                                    "ON R.ReplaceID=InfoRem.ReplaceID " +
                                    "Left OUter JOIN (Select RH.ReplaceID, Remarks From t_CSDReplaceHistory RH Where Status=3)IssRem " +
                                    "ON R.ReplaceID=IssRem.ReplaceID " +
                                    "WHERE R.ReplaceID <>0 ";

                if (txtReplaceID != "")
                {
                    sSql = sSql + " AND R.ReplaceID ='" + txtReplaceID + "'";
                }
                if (txtJobNo != "")
                {
                    txtJobNo = "%" + txtJobNo + "%";
                    sSql = sSql + " AND JobNo LIKE '" + txtJobNo + "'";
                }
                if (nStatus > -1)
                {
                    sSql = sSql + " AND Status ='" + nStatus + "'";
                }
                if (nPapersLocation > -1)
                {
                    sSql = sSql + " AND PapersLocation ='" + nPapersLocation + "'";
                }
                if (txtCustomerName != "")
                {
                    txtCustomerName = "%" + txtCustomerName + "%";
                    sSql = sSql + " AND CustomerName LIKE '" + txtCustomerName + "'";
                }
                if (txtAddress != "")
                {
                    txtAddress = "%" + txtAddress + "%";
                    sSql = sSql + " AND FirstAddress LIKE '" + txtAddress + "'";
                }
                if (txtContactNo != "")
                {
                    txtContactNo = "%" + txtContactNo + "%";
                    sSql = sSql + " AND Mobile LIKE '" + txtContactNo + "'";
                }
                sSql = sSql + " order by R.CreateDate ";

                try
                {
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Replace oReplace = new Replace();

                        oReplace.ReplaceID = (int)reader["ReplaceID"];
                        oReplace.ReplaceJobFromCassandra.JobNo = (string)reader["JobNo"];
                        oReplace.ReplaceJobFromCassandra.CustomerName = (string)reader["CustomerName"];
                        oReplace.ReplaceJobFromCassandra.FirstAddress = (string)reader["FirstAddress"];
                        oReplace.ReplaceJobFromCassandra.Mobile = (string)reader["Mobile"];
                        oReplace.ReplaceJobFromCassandra.SerialNo = (string)reader["SerialNo"];
                        oReplace.Status = int.Parse(reader["Status"].ToString());
                        oReplace.ReplaceJobFromCassandra.ProductCode = (string)reader["ProductCode"];
                        oReplace.ReplaceJobFromCassandra.ProductName = (string)reader["ProductName"];
                        oReplace.FaultDescription = (string)reader["Description"];
                        oReplace.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                        oReplace.DateOfPurchase = (Object)reader["DateOfPurchase"];
                        oReplace.InvoiceCashMemo = (Object)reader["InvoiceCashMemo"];
                        oReplace.FullWarrantyPeriod = (Object)reader["FullWarrantyPeriod"];
                        oReplace.RemarksAcutalFault = (Object)reader["Remarks"];
                        oReplace.Source = (Object)reader["Source"];
                        oReplace.SourceName = (Object)reader["SourceName"];
                        oReplace.Product.ProductCode = reader["IssueProductCode"].ToString();
                        oReplace.Product.ProductName = reader["IssueProductName"].ToString();
                        oReplace.IssueProductBarcode = (Object)reader["IssueProductBarcode"];
                        oReplace.ReiseRemarks = (Object)reader["ReiseRemarks"].ToString();
                        oReplace.ReplaceJobFromCassandra.JobCreationDate = Convert.ToDateTime(reader["JobCreationDate"].ToString());
                        oReplace.CourierFromCassandra.CourierServiceName = (string)reader["CourierServiceName"].ToString();
                        oReplace.CourierFromCassandra.CourierServiceID = int.Parse(reader["CourierID"].ToString());
                        oReplace.ConsignmentNo = (Object)reader["ConsignmentNO"].ToString();
                        oReplace.Deliveredby = (Object)reader["Deliveredby"].ToString();
                        oReplace.HappyCallStat = (Object)reader["HappyCallStatus"].ToString();
                        oReplace.ModeofDeliveryName = (Object)reader["ModeofDeliveryDet"].ToString();
                        oReplace.IssueDate = (Object)reader["IssueDate"].ToString();
                        oReplace.ApproxDeliveryDate = (Object)reader["ApproxDeliveryDate"].ToString();
                        oReplace.DeliveryDate = (Object)reader["DeliveryDate"].ToString();
                        oReplace.DeliveredFromWHName = (Object)reader["FromWHName"];
                        oReplace.EDD = (Object)reader["EDD_Edit"].ToString();
                        oReplace.EDD1 = (Object)reader["EDD_RPT"].ToString();
                        oReplace.CancelRemarks = (Object)reader["CanRem"].ToString();
                        oReplace.DeliveryRemarks = (Object)reader["DelRem"].ToString();
                        oReplace.HappyCallRemarks = (Object)reader["HppRem"].ToString();
                        oReplace.InformedRemarks = (Object)reader["InfoRem"].ToString();
                        oReplace.IssueRemarks = (Object)reader["IssRem"].ToString();

                        InnerList.Add(oReplace);
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
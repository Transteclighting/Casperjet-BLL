// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Jul 28, 2012
// Time :  9:21 AM
// Description: Class for Inter Service Spare Parts Requisition Item Data.
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
    public class SparePartsTransactionDetail
    {
        private int _nISVRequisitionItemID;
        private int _nISVRequisitionID;
        private int _nSparePartID;
        private long _nClaimQty;
        private int _nJobID;
        private int _nSubStatus;
        private int _nLoanProductID;
        private Object _dEDD;
        private int _nSourceID;
        private int _nIssuedUserID;
        private Object _dIssueDate;
        

        private Object _sSubStatusName;
        private string _sLoanCode;

        private SpareParts _oSpareParts;

        private ReplaceJobFromCassandra _oReplaceJobFromCassandra;
        private SerarchProduct _oSerarchProduct;
        private SparePartStockCassandra _oSparePartStockCassandra;
        private SPTranCassandra _oSPTranCassandra;

        /// <summary>
        /// Get set property for ISVRequisitionItemID
        /// </summary>
        public int ISVRequisitionItemID
        {
            get { return _nISVRequisitionItemID; }
            set { _nISVRequisitionItemID = value; }
        }
        /// <summary>
        /// Get set property for ISVRequisitionID
        /// </summary>
        public int ISVRequisitionID
        {
            get { return _nISVRequisitionID; }
            set { _nISVRequisitionID = value; }
        }
        /// <summary>
        /// Get set property for SparePartID
        /// </summary>
        public int SparePartID
        {
            get { return _nSparePartID; }
            set { _nSparePartID = value; }
        }
        /// <summary>
        /// Get set property for ClaimQty
        /// </summary>
        public long ClaimQty
        {
            get { return _nClaimQty; }
            set { _nClaimQty = value; }
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
        /// Get set property for SubStatus
        /// </summary>
        public int SubStatus
        {
            get { return _nSubStatus; }
            set { _nSubStatus = value; }
        }
        /// <summary>
        /// Get set property for LoanProductID
        /// </summary>
        public int LoanProductID
        {
            get { return _nLoanProductID; }
            set { _nLoanProductID = value; }
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
        /// Get set property for SourceID
        /// </summary>
        public int SourceID
        {
            get { return _nSourceID; }
            set { _nSourceID = value; }
        }
        /// <summary>
        /// Get set property for IssuedUserID
        /// </summary>
        public int IssuedUserID
        {
            get { return _nIssuedUserID; }
            set { _nIssuedUserID = value; }
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
        /// Get set property for SubStatusName
        /// </summary>
        public Object SubStatusName
        {
            get { return _sSubStatusName; }
            set { _sSubStatusName = value; }
        }
        /// <summary>
        /// Get set property for LoanCode
        /// </summary>
        public string LoanCode
        {
            get { return _sLoanCode; }
            set { _sLoanCode = value; }
        }

        public SpareParts SpareParts
        {
            get
            {
                if (_oSpareParts == null)
                {
                    _oSpareParts = new SpareParts();
                    _oSpareParts.ID = _nSparePartID;
                    _oSpareParts.RefreshSpareParts();
                }
                return _oSpareParts;
            }
        }

        public ReplaceJobFromCassandra ReplaceJobFromCassandra
        {
            get
            {
                if (_oReplaceJobFromCassandra == null)
                {
                    _oReplaceJobFromCassandra = new ReplaceJobFromCassandra();
                    _oReplaceJobFromCassandra.JobID = _nJobID;
                    _oReplaceJobFromCassandra.RefreshByJobID();

                }
                return _oReplaceJobFromCassandra;
            }
        }
        public SerarchProduct SerarchProduct
        {
            get
            {
                if (_oSerarchProduct == null)
                {
                    _oSerarchProduct = new SerarchProduct();

                }
                return _oSerarchProduct;
            }
        }
        public SparePartStockCassandra SparePartStockCassandra
        {
            get
            {
                if (_oSparePartStockCassandra == null)
                {
                    _oSparePartStockCassandra = new SparePartStockCassandra();

                }
                return _oSparePartStockCassandra;
            }
        }
        public SPTranCassandra SPTranCassandra
        {
            get
            {
                if (_oSPTranCassandra == null)
                {
                    _oSPTranCassandra = new SPTranCassandra();

                }
                return _oSPTranCassandra;
            }
        }

        public void RefreshSpareParts()
        {
            SpareParts.ID =_nSparePartID;
            SpareParts.RefreshSpareParts();
        }
        public void RefreshSpareStock()
        {
            SparePartStockCassandra.SparePartID = _nSparePartID;
            SparePartStockCassandra.RefreshSpareID();
        }
        public void RefreshJob()
        {
            ReplaceJobFromCassandra.JobID = _nJobID;
            ReplaceJobFromCassandra.RefreshByJobID();
        }
        public void AddRequisitionItem(int nISVRequisitionID)
        {
            int nMaxISVRequisitionItemID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ISVRequisitionItemID]) FROM t_CSDISVRequisitionItem";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxISVRequisitionItemID = 1;
                }
                else
                {
                    nMaxISVRequisitionItemID = Convert.ToInt32(maxID) + 1;
                }
                _nISVRequisitionItemID = nMaxISVRequisitionItemID;


                sSql = "INSERT INTO t_CSDISVRequisitionItem(ISVRequisitionItemID,ISVRequisitionID,SparePartID,"
                    + " ClaimQty,JobID,SubStatus "
                    + " ) VALUES(?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ISVRequisitionItemID", _nISVRequisitionItemID);
                cmd.Parameters.AddWithValue("ISVRequisitionID", nISVRequisitionID);
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.Parameters.AddWithValue("ClaimQty", _nClaimQty);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("SubStatus", -9);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddRequisitionItemEditMode()
        {
            int nMaxISVRequisitionItemID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ISVRequisitionItemID]) FROM t_CSDISVRequisitionItem";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxISVRequisitionItemID = 1;
                }
                else
                {
                    nMaxISVRequisitionItemID = Convert.ToInt32(maxID) + 1;
                }
                _nISVRequisitionItemID = nMaxISVRequisitionItemID;


                sSql = "INSERT INTO t_CSDISVRequisitionItem(ISVRequisitionItemID,ISVRequisitionID,SparePartID,"
                    + " ClaimQty,JobID,SubStatus "
                    + " ) VALUES(?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ISVRequisitionItemID", _nISVRequisitionItemID);
                cmd.Parameters.AddWithValue("ISVRequisitionID", _nISVRequisitionID);
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.Parameters.AddWithValue("ClaimQty", _nClaimQty);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("SubStatus", -9);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateRequisitionItem()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_CSDISVRequisitionItem SET SubStatus=?,LoanProductID=?,EDD=?, IssuedUserID=?,IssueDate=? WHERE ISVRequisitionItemID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SubStatus", _nSubStatus);
                cmd.Parameters.AddWithValue("LoanProductID", _nLoanProductID);
                cmd.Parameters.AddWithValue("EDD", _dEDD);
                cmd.Parameters.AddWithValue("IssuedUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("IssueDate", DateTime.Now);

                cmd.Parameters.AddWithValue("ISVRequisitionItemID", _nISVRequisitionItemID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateRequisitionItemEditMode()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_CSDISVRequisitionItem SET SparePartID=?,ClaimQty=?,JobID=?  WHERE SubStatus Not IN (0,1) AND ISVRequisitionItemID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.Parameters.AddWithValue("ClaimQty", _nClaimQty);
                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.Parameters.AddWithValue("ISVRequisitionItemID", _nISVRequisitionItemID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public bool CheckRequisitionItem()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDISVRequisitionItem where ISVRequisitionItemID=? ";
            cmd.Parameters.AddWithValue("ISVRequisitionItemID", _nISVRequisitionItemID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nISVRequisitionItemID = (int)reader["ISVRequisitionItemID"];

                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return true;
            else return false;
        }
        public void CheckRequisitionItemByISVRequisitionID()
        {
           
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDISVRequisitionItem where ISVRequisitionID=? ";
            cmd.Parameters.AddWithValue("ISVRequisitionID", _nISVRequisitionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nSubStatus = (int)reader["SubStatus"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
       
        
        //public void DeleteRequisitionItem(int nISVRequisitionID)
        public void DeleteRequisitionItem()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "Delete FROM t_CSDISVRequisitionItem WHERE SubStatus =-9 AND ISVRequisitionID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ISVRequisitionID", _nISVRequisitionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    
    }
    public class SparePartsTransaction : CollectionBase
    {
        public SparePartsTransactionDetail this[int i]
        {
            get { return (SparePartsTransactionDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SparePartsTransactionDetail oSparePartsTransactionDetail)
        {
            InnerList.Add(oSparePartsTransactionDetail);
        }

        private int _nISVRequisitionID;
        private int _nInterServiceID;
        private Object _sSerialNo;
        private Object _sReportNo;
        private DateTime _dPrepareDate;
        private DateTime _dReceiveDate;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nStatus;
        private Object _sRemarks;
        private Object _sCancelReason;

        private int _nStatusCode;
        private string _sStatusName;
        

        private User _oUser;
        private InterService _oInterService;
        private SpareParts _oSpareParts;

        private ReplaceJobFromCassandra _oReplaceJobFromCassandra;
        private SerarchProduct _oSerarchProduct;
        private SparePartsTransactionDetail _oSparePartsTransactionDetail;
        private SparePartsSend _oSparePartsSend;

        /// <summary>
        /// Get set property for ISVRequisitionID
        /// </summary>
        public int ISVRequisitionID
        {
            get { return _nISVRequisitionID; }
            set { _nISVRequisitionID = value; }
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
        /// Get set property for SerialNo
        /// </summary>
        public Object SerialNo
        {
            get { return _sSerialNo; }
            set { _sSerialNo = value; }
        }
        /// <summary>
        /// Get set property for ReportNo
        /// </summary>
        public Object ReportNo
        {
            get { return _sReportNo; }
            set { _sReportNo = value; }
        }
        /// <summary>
        /// Get set property for PrepareDate
        /// </summary>
        public DateTime PrepareDate
        {
            get { return _dPrepareDate; }
            set { _dPrepareDate = value; }
        }
        /// <summary>
        /// Get set property for ReceiveDate
        /// </summary>
        public DateTime ReceiveDate
        {
            get { return _dReceiveDate; }
            set { _dReceiveDate = value; }
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
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
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
        /// Get set property for CancelReason
        /// </summary>
        public Object CancelReason
        {
            get { return _sCancelReason; }
            set { _sCancelReason = value; }
        }


        /// <summary>
        /// Get set property for StatusCode
        /// </summary>
        public int StatusCode
        {
            get { return _nStatusCode; }
            set { _nStatusCode = value; }
        }
        /// <summary>
        /// Get set property for StatusName
        /// </summary>
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value; }
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
        public InterService InterService
        {
            get
            {
                if (_oInterService == null)
                {
                    _oInterService = new InterService();
                    _oInterService.InterServiceID = _nInterServiceID;
                    _oInterService.RefreshByID();
                }
                return _oInterService;
            }
        }
        public SpareParts SpareParts
        {
            get
            {
                if (_oSpareParts == null)
                {
                    _oSpareParts = new SpareParts();
                   // _oSpareParts.ID = _nSparePartID;
                    _oSpareParts.RefreshBySPID();
                }
                return _oSpareParts;
            }
        }

        public ReplaceJobFromCassandra ReplaceJobFromCassandra
        {
            get
            {
                if (_oReplaceJobFromCassandra == null)
                {
                    _oReplaceJobFromCassandra = new ReplaceJobFromCassandra();

                }
                return _oReplaceJobFromCassandra;
            }
        }
        public SerarchProduct SerarchProduct
        {
            get
            {
                if (_oSerarchProduct == null)
                {
                    _oSerarchProduct = new SerarchProduct();

                }
                return _oSerarchProduct;
            }
        }
        public SparePartsTransactionDetail SparePartsTransactionDetail
        {
            get
            {
                if (_oSparePartsTransactionDetail == null)
                {
                    _oSparePartsTransactionDetail = new SparePartsTransactionDetail();

                }
                return _oSparePartsTransactionDetail;
            }
        }
        public SparePartsSend SparePartsSend
        {
            get
            {
                if (_oSparePartsSend == null)
                {
                    _oSparePartsSend = new SparePartsSend();

                }
                return _oSparePartsSend;
            }
        }

        public void AddRequisition()
        {
            int nMaxISVRequisitionID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ISVRequisitionID]) FROM t_CSDISVRequisition";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxISVRequisitionID = 1;
                }
                else
                {
                    nMaxISVRequisitionID = Convert.ToInt32(maxID) + 1;
                }
                _nISVRequisitionID = nMaxISVRequisitionID;


                sSql = "INSERT INTO t_CSDISVRequisition(ISVRequisitionID,InterServiceID,SerialNo,ReportNo,PrepareDate, "
                    + " ReceiveDate,CreateUserID,CreateDate,Status,Remarks"
                    + " ) VALUES(?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ISVRequisitionID", _nISVRequisitionID);
                cmd.Parameters.AddWithValue("InterServiceID", _nInterServiceID);
                cmd.Parameters.AddWithValue("SerialNo", _sSerialNo);
                cmd.Parameters.AddWithValue("ReportNo", _sReportNo);
                cmd.Parameters.AddWithValue("PrepareDate", _dPrepareDate);
                cmd.Parameters.AddWithValue("ReceiveDate", _dReceiveDate);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (SparePartsTransactionDetail oItem in this)
                {
                    oItem.AddRequisitionItem(_nISVRequisitionID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditRequisition()
        {
            int nCount = 1;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_CSDISVRequisition SET InterServiceID=?,SerialNo=?,ReportNo=?,PrepareDate=?,ReceiveDate=?,Remarks=?  WHERE ISVRequisitionID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InterServiceID", _nInterServiceID);
                cmd.Parameters.AddWithValue("SerialNo", _sSerialNo);
                cmd.Parameters.AddWithValue("ReportNo", _sReportNo);
                cmd.Parameters.AddWithValue("PrepareDate", _dPrepareDate);
                cmd.Parameters.AddWithValue("ReceiveDate", _dReceiveDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("ISVRequisitionID", _nISVRequisitionID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //foreach (SparePartsTransactionDetail oItem in this)
                //{
                //    //if (nCount == 1)
                //    //{
                //    //    oItem.DeleteRequisitionItem(_nISVRequisitionID);
                //    //    nCount++;
                //    //}
                //    //oItem.AddRequisitionItem(_nISVRequisitionID);
                //    oItem.UpdateRequisitionItem(_nISVRequisitionID);
                //}

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void CancelStatus()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_CSDISVRequisition SET Status=?,CancelReason=?  WHERE ISVRequisitionID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", (int)Dictionary.ISVRequisitionStatus.Cancel);
                cmd.Parameters.AddWithValue("CancelReason", _sCancelReason);

                cmd.Parameters.AddWithValue("ISVRequisitionID", _nISVRequisitionID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatus()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_CSDISVRequisition SET Status=?  WHERE ISVRequisitionID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("ISVRequisitionID", _nISVRequisitionID);
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
        public void RefreshItem()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT ISVRequisitionItemID, SparePartID, ClaimQty,JobID,IsNull(EDD,GetDate())EDD,  "+
                            "SubStatus, SubStatusName=CASE When SubStatus=0 then 'FromStock'  " +
                            "When SubStatus=1 then 'FromLoanSet' " +
                            "When SubStatus=2 then 'LocalPurchase' " +
                            "When SubStatus=3 then 'ForeignOrder' " +
                            "When SubStatus=4 then 'LoanRequisition' " +
                            "When SubStatus=5 then 'Suspend' " +
                            "When SubStatus=6 then 'Rejected' " +
                            "else 'FromStock' end " +
                            "FROM t_CSDISVRequisitionItem Where ISVRequisitionID=? ";

            cmd.Parameters.AddWithValue("ISVRequisitionID", _nISVRequisitionID);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SparePartsTransactionDetail oSparePartsTransactionDetail = new SparePartsTransactionDetail();


                    oSparePartsTransactionDetail.ISVRequisitionItemID = (int)reader["ISVRequisitionItemID"];
                    oSparePartsTransactionDetail.SparePartID = (int)reader["SparePartID"];
                    oSparePartsTransactionDetail.ClaimQty = (int)reader["ClaimQty"];
                    oSparePartsTransactionDetail.JobID = (int)reader["JobID"];
                    oSparePartsTransactionDetail.EDD = (Object)reader["EDD"].ToString();
                    oSparePartsTransactionDetail.SubStatusName = (string)reader["SubStatusName"];
                    oSparePartsTransactionDetail.SubStatus = int.Parse(reader["SubStatus"].ToString());

                    InnerList.Add(oSparePartsTransactionDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByRequisitionID()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT ISVRequisitionItemID,ISVRequisitionID, ISVRI.SparePartID,ISVRI.ClaimQty, " +
                            "ISVRI.JobID, J.JobNo, ISVRI.SparePartID, SP.Code SpareCode, SP.Name SpareName, SP.CostPrice, " +
                            "SP.SalePrice, P.Name ProductName,IsNull(EDD,Convert(datetime,replace(convert(varchar,GetDate(),6),' ','-'),1)) EDD, SPS.SoundQty, " +
                            "SubStatusName=CASE When SubStatus=0 then 'FromStock'  " +
                            "When SubStatus=1 then 'FromLoanSet' " +
                            "When SubStatus=2 then 'LocalPurchase' " +
                            "When SubStatus=3 then 'ForeignOrder' " +
                            "When SubStatus=4 then 'LoanRequisition' " +
                            "When SubStatus=5 then 'Suspend' " +
                            "When SubStatus=6 then 'Rejected' " +
                            "else 'FromStock' end " +
                            "FROM t_CSDISVRequisitionItem ISVRI INNER JOIN TELServiceDB.dbo.Job J " +
                            "ON J.JobID=ISVRI.JobID " +
                            "INNER JOIN TELServiceDB.dbo.SpareParts SP " +
                            "ON SP.ID=ISVRI.SparePartID " +
                            "INNER JOIN TELServiceDB.dbo.Product P " +
                            "ON P.ProductID=J.ProductID " +
                            "Left Outer JOIN TELServiceDB.dbo.SparePartStock SPS " +
                            "ON SPS.SparePartID=SP.ID " +
                            "Where SubStatus NOT IN (0,1) AND ISVRequisitionID=? ";

            cmd.Parameters.AddWithValue("ISVRequisitionID", _nISVRequisitionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SparePartsTransactionDetail oSparePartsTransactionDetail = new SparePartsTransactionDetail();
                    //SparePartsTransaction oSparePartsTransaction = new SparePartsTransaction();

                    oSparePartsTransactionDetail.ISVRequisitionItemID = (int)reader["ISVRequisitionItemID"];
                    //oSparePartsTransactionDetail.ISVRequisitionID = (int)reader["ISVRequisitionID"];
                    oSparePartsTransactionDetail.SparePartID = (int)reader["SparePartID"];
                    oSparePartsTransactionDetail.SpareParts.Code = (string)reader["SpareCode"];
                    oSparePartsTransactionDetail.SpareParts.Name = (string)reader["SpareName"];
                    oSparePartsTransactionDetail.SpareParts.SalePrice = Convert.ToDouble(reader["SalePrice"].ToString());
                    oSparePartsTransactionDetail.SpareParts.CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    oSparePartsTransactionDetail.ClaimQty = Convert.ToInt64(reader["ClaimQty"]);
                    oSparePartsTransactionDetail.ReplaceJobFromCassandra.JobID = (int)reader["JobID"];
                    oSparePartsTransactionDetail.ReplaceJobFromCassandra.JobNo = (string)reader["JobNo"];
                    oSparePartsTransactionDetail.SerarchProduct.ProductName = (string)reader["ProductName"];
                    oSparePartsTransactionDetail.EDD = (Object)reader["EDD"].ToString();
                    oSparePartsTransactionDetail.SparePartStockCassandra.SoundQty = Convert.ToInt64(reader["SoundQty"]);
                    oSparePartsTransactionDetail.SubStatusName = (Object)reader["SubStatusName"].ToString();

                    InnerList.Add(oSparePartsTransactionDetail);
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
    public class SparePartsTransactions : CollectionBase
    {
        public SparePartsTransaction this[int i]
        {
            get { return (SparePartsTransaction)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SparePartsTransaction oSparePartsTransaction)
        {
            InnerList.Add(oSparePartsTransaction);
        }
        public void Refresh(DateTime dtFromDate, DateTime dtToDate,String txtRequisitionID, int nInterServiceID, int nStatus, String txtSerialNo,String txtReportNo, String txtContactNo, String txtReceiveBy)
        {
            dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select ISVR.ISVRequisitionID, InterServiceID,SerialNo,ReportNo, CancelReason, PrepareDate,  " +
                            "ReceiveDate, CreateDate, Status, Remarks,u.username,ISV.Code ISVCode,  " +
                            "ISV.Name ISVName,ISV.Mobile ISVContactNo, StatusName,StatusCode " +
                            "from t_CSDISVRequisition ISVR  " +
                            "INNER JOIN t_user u  " +
                            "ON u.UserID=ISVR.CreateUserID  " +
                            "INNER JOIN TELServiceDB.dbo.InterService ISV  " +
                            "ON ISV.ID=ISVR.InterServiceID " +
                            "INNER JOIN " +
                            "( " +
                            "Select ISVRequisitionID, StatusName=CASE " +
                            "When (Total-Rejected)=(FromStock+FromLoanSet) And ((FromStock+FromLoanSet)>0) Then 'Full_Issue' " +
                            "When Total=Rejected OR Status=4 Then 'Cancel' " +
                            "When Total=Receive Then 'Receive' " +
                            "When Total=Suspend Then 'Suspend' " +
                            "When (Total-Rejected)=(LocalPurchase+ForeignOrder+LoanRequisition+Suspend)AND((FromStock+FromLoanSet)=0) Then 'Pending' " +
                            "When (Total-Rejected)>(FromStock+FromLoanSet) And ((FromStock+FromLoanSet)>0) Then 'Partial_Issue' " +
                            "else 'Receive' end, " +
                            "StatusCode=CASE " +
                            "When (Total-Rejected)=(FromStock+FromLoanSet) And ((FromStock+FromLoanSet)>0) Then 2 " +
                            "When Total=Rejected OR Status=4 Then 4 " +
                            "When Total=Receive Then 0 " +
                            "When Total=Suspend Then 3 " +
                            "When (Total-Rejected)=(LocalPurchase+ForeignOrder+LoanRequisition+Suspend)AND((FromStock+FromLoanSet)=0) Then 5 " +
                            "When (Total-Rejected)>(FromStock+FromLoanSet) And ((FromStock+FromLoanSet)>0) Then 1 " +
                            "else -9 end " +
                            "From " +
                            "( " +
                            "Select ISVRequisitionID, Status, FromStock, FromLoanSet, LocalPurchase, ForeignOrder, LoanRequisition, Suspend, " +
                            "Rejected, Receive,(FromStock + FromLoanSet + LocalPurchase + ForeignOrder + LoanRequisition + Suspend + Rejected + Receive)Total " +
                            "from ( " +
                            "Select ISVRequisitionID, Status, " +
                            "Sum(case SubStatusName when 'FromStock' then 1  else 0 end) as FromStock, " +
                            "Sum(case SubStatusName when 'FromLoanSet' then 1  else 0 end) as FromLoanSet, " +
                            "Sum(case SubStatusName when 'LocalPurchase' then 1  else 0 end) as LocalPurchase, " +
                            "Sum(case SubStatusName when 'ForeignOrder' then 1  else 0 end) as ForeignOrder, " +
                            "Sum(case SubStatusName when 'LoanRequisition' then 1  else 0 end) as LoanRequisition, " +
                            "Sum(case SubStatusName when 'Suspend' then 1  else 0 end) as Suspend, " +
                            "Sum(case SubStatusName when 'Rejected' then 1  else 0 end) as Rejected, " +
                            "Sum(case SubStatusName when 'Receive' then 1  else 0 end) as Receive " +
                            "From " +
                            "(  " +
                            "Select RI.ISVRequisitionID, Status, SubStatusName=Case " +
                            "When SubStatus=0 Then 'FromStock' " +
                            "When SubStatus=1 Then 'FromLoanSet' " +
                            "When SubStatus=2 Then 'LocalPurchase' " +
                            "When SubStatus=3 Then 'ForeignOrder' " +
                            "When SubStatus=4 Then 'LoanRequisition' " +
                            "When SubStatus=5 Then 'Suspend' " +
                            "When SubStatus=6 Then 'Rejected' " +
                            "When SubStatus=-9 Then 'Receive' " +
                            "End " +
                            "From t_CSDISVRequisitionItem RI " +
                            "INNER JOIN t_CSDISVRequisition R "+
                            "ON R.ISVRequisitionID=RI.ISVRequisitionID "+
                            ")A " +
                            "Group by ISVRequisitionID, Status " +
                            ")A " +
                            ")A " +
                            ")Final " +
                            "ON Final.ISVRequisitionID=ISVR.ISVRequisitionID "+
                            "Where " +
                            "CreateDate BETWEEN'" + dtFromDate + "'AND '" + dtToDate + "' AND CreateDate < '" + dtToDate + "'";

            if (txtRequisitionID != "")
            {
                sSql = sSql + " AND ISVR.ISVRequisitionID ='" + txtRequisitionID + "'";
            }
            if (nInterServiceID != 0)
                sSql = sSql + " and InterServiceID ='" + nInterServiceID + "'";

            if (nStatus > -1)
            {
                sSql = sSql + "AND StatusCode ='" + nStatus + "'";
            }
            if (txtSerialNo != "")
            {
                //txtSerialNo = "%" + txtSerialNo + "%";
                sSql = sSql + " AND SerialNo LIKE '" + txtSerialNo + "'";
            }
            if (txtReportNo != "")
            {
                //txtReportNo = "%" + txtReportNo + "%";
                sSql = sSql + " AND ReportNo = '" + txtReportNo + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND ISV.Mobile LIKE '" + txtContactNo + "'";
            }
            if (txtReceiveBy != "")
            {
                txtReceiveBy = "%" + txtReceiveBy + "%";
                sSql = sSql + " AND u.username LIKE '" + txtReceiveBy + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SparePartsTransaction oSparePartsTransaction = new SparePartsTransaction();

                    oSparePartsTransaction.ISVRequisitionID = (int)reader["ISVRequisitionID"];
                    oSparePartsTransaction.InterServiceID = (int)reader["InterServiceID"];
                    oSparePartsTransaction.SerialNo = (Object)reader["SerialNo"].ToString();
                    oSparePartsTransaction.ReportNo = (Object)reader["ReportNo"].ToString();
                    oSparePartsTransaction.PrepareDate = Convert.ToDateTime(reader["PrepareDate"].ToString());
                    oSparePartsTransaction.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());
                    oSparePartsTransaction.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSparePartsTransaction.Status = (int)reader["Status"];
                    oSparePartsTransaction.Remarks = (Object)reader["Remarks"].ToString();
                    oSparePartsTransaction.User.Username = (string)reader["username"];
                    oSparePartsTransaction.InterService.Code = (string)reader["ISVCode"];
                    oSparePartsTransaction.InterService.Name = (string)reader["ISVName"];
                    oSparePartsTransaction.InterService.Mobile = (string)reader["ISVContactNo"];

                    oSparePartsTransaction.StatusCode = int.Parse(reader["StatusCode"].ToString());
                    oSparePartsTransaction.StatusName = (string)reader["StatusName"];
                    oSparePartsTransaction.CancelReason = (Object)reader["CancelReason"].ToString();



                    oSparePartsTransaction.RefreshItem();

                    oSparePartsTransaction.RefreshUser();
                    InnerList.Add(oSparePartsTransaction);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshAll(String txtRequisitionID, int nInterServiceID, int nStatus, String txtSerialNo, String txtReportNo, String txtContactNo, String txtReceiveBy)
        {
            //dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select ISVR.ISVRequisitionID, InterServiceID,SerialNo,ReportNo, CancelReason, PrepareDate,  " +
                            "ReceiveDate, CreateDate, Status, Remarks,u.username,ISV.Code ISVCode,  " +
                            "ISV.Name ISVName,ISV.Mobile ISVContactNo, StatusName,StatusCode " +
                            "from t_CSDISVRequisition ISVR  " +
                            "INNER JOIN t_user u  " +
                            "ON u.UserID=ISVR.CreateUserID  " +
                            "INNER JOIN TELServiceDB.dbo.InterService ISV  " +
                            "ON ISV.ID=ISVR.InterServiceID " +
                            "INNER JOIN " +
                            "( " +
                            "Select ISVRequisitionID, StatusName=CASE " +
                            "When (Total-Rejected)=(FromStock+FromLoanSet) And ((FromStock+FromLoanSet)>0) Then 'Full_Issue' " +
                            "When Total=Rejected OR Status=4 Then 'Cancel' " +
                            "When Total=Receive Then 'Receive' " +
                            "When Total=Suspend Then 'Suspend' " +
                            "When (Total-Rejected)=(LocalPurchase+ForeignOrder+LoanRequisition+Suspend)AND((FromStock+FromLoanSet)=0) Then 'Pending' " +
                            "When (Total-Rejected)>(FromStock+FromLoanSet) And ((FromStock+FromLoanSet)>0) Then 'Partial_Issue' " +
                            "else 'Receive' end, " +
                            "StatusCode=CASE " +
                            "When (Total-Rejected)=(FromStock+FromLoanSet) And ((FromStock+FromLoanSet)>0) Then 2 " +
                            "When Total=Rejected OR Status=4 Then 4 " +
                            "When Total=Receive Then 0 " +
                            "When Total=Suspend Then 3 " +
                            "When (Total-Rejected)=(LocalPurchase+ForeignOrder+LoanRequisition+Suspend)AND((FromStock+FromLoanSet)=0) Then 5 " +
                            "When (Total-Rejected)>(FromStock+FromLoanSet) And ((FromStock+FromLoanSet)>0) Then 1 " +
                            "else -9 end " +
                            "From " +
                            "( " +
                            "Select ISVRequisitionID, Status, FromStock, FromLoanSet, LocalPurchase, ForeignOrder, LoanRequisition, Suspend, " +
                            "Rejected, Receive,(FromStock + FromLoanSet + LocalPurchase + ForeignOrder + LoanRequisition + Suspend + Rejected + Receive)Total " +
                            "from ( " +
                            "Select ISVRequisitionID, Status, " +
                            "Sum(case SubStatusName when 'FromStock' then 1  else 0 end) as FromStock, " +
                            "Sum(case SubStatusName when 'FromLoanSet' then 1  else 0 end) as FromLoanSet, " +
                            "Sum(case SubStatusName when 'LocalPurchase' then 1  else 0 end) as LocalPurchase, " +
                            "Sum(case SubStatusName when 'ForeignOrder' then 1  else 0 end) as ForeignOrder, " +
                            "Sum(case SubStatusName when 'LoanRequisition' then 1  else 0 end) as LoanRequisition, " +
                            "Sum(case SubStatusName when 'Suspend' then 1  else 0 end) as Suspend, " +
                            "Sum(case SubStatusName when 'Rejected' then 1  else 0 end) as Rejected, " +
                            "Sum(case SubStatusName when 'Receive' then 1  else 0 end) as Receive " +
                            "From " +
                            "(  " +
                            "Select RI.ISVRequisitionID, Status, SubStatusName=Case " +
                            "When SubStatus=0 Then 'FromStock' " +
                            "When SubStatus=1 Then 'FromLoanSet' " +
                            "When SubStatus=2 Then 'LocalPurchase' " +
                            "When SubStatus=3 Then 'ForeignOrder' " +
                            "When SubStatus=4 Then 'LoanRequisition' " +
                            "When SubStatus=5 Then 'Suspend' " +
                            "When SubStatus=6 Then 'Rejected' " +
                            "When SubStatus=-9 Then 'Receive' " +
                            "End " +
                            "From t_CSDISVRequisitionItem RI " +
                            "INNER JOIN t_CSDISVRequisition R " +
                            "ON R.ISVRequisitionID=RI.ISVRequisitionID " +
                            ")A " +
                            "Group by ISVRequisitionID, Status " +
                            ")A " +
                            ")A " +
                            ")Final " +
                            "ON Final.ISVRequisitionID=ISVR.ISVRequisitionID " +
                            "Where ISVR.ISVRequisitionID <>0 ";

            if (txtRequisitionID != "")
            {
                sSql = sSql + " AND ISVR.ISVRequisitionID ='" + txtRequisitionID + "'";
            }
            if (nInterServiceID != 0)
                sSql = sSql + " and InterServiceID ='" + nInterServiceID + "'";

            if (nStatus > -1)
            {
                sSql = sSql + "AND StatusCode ='" + nStatus + "'";
            }
            if (txtSerialNo != "")
            {
                //txtSerialNo = "%" + txtSerialNo + "%";
                sSql = sSql + " AND SerialNo LIKE '" + txtSerialNo + "'";
            }
            if (txtReportNo != "")
            {
                //txtReportNo = "%" + txtReportNo + "%";
                sSql = sSql + " AND ReportNo = '" + txtReportNo + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND ISV.Mobile LIKE '" + txtContactNo + "'";
            }
            if (txtReceiveBy != "")
            {
                txtReceiveBy = "%" + txtReceiveBy + "%";
                sSql = sSql + " AND u.username LIKE '" + txtReceiveBy + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SparePartsTransaction oSparePartsTransaction = new SparePartsTransaction();

                    oSparePartsTransaction.ISVRequisitionID = (int)reader["ISVRequisitionID"];
                    oSparePartsTransaction.InterServiceID = (int)reader["InterServiceID"];
                    oSparePartsTransaction.SerialNo = (Object)reader["SerialNo"].ToString();
                    oSparePartsTransaction.ReportNo = (Object)reader["ReportNo"].ToString();
                    oSparePartsTransaction.PrepareDate = Convert.ToDateTime(reader["PrepareDate"].ToString());
                    oSparePartsTransaction.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());
                    oSparePartsTransaction.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSparePartsTransaction.Status = (int)reader["Status"];
                    oSparePartsTransaction.Remarks = (Object)reader["Remarks"].ToString();
                    oSparePartsTransaction.User.Username = (string)reader["username"];
                    oSparePartsTransaction.InterService.Code = (string)reader["ISVCode"];
                    oSparePartsTransaction.InterService.Name = (string)reader["ISVName"];
                    oSparePartsTransaction.InterService.Mobile = (string)reader["ISVContactNo"];

                    oSparePartsTransaction.StatusCode = int.Parse(reader["StatusCode"].ToString());
                    oSparePartsTransaction.StatusName = (string)reader["StatusName"];
                    oSparePartsTransaction.CancelReason = (Object)reader["CancelReason"].ToString();



                    oSparePartsTransaction.RefreshItem();

                    oSparePartsTransaction.RefreshUser();
                    InnerList.Add(oSparePartsTransaction);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByRequisitionIDView(int _nISVRequisitionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT ISVRequisitionItemID,ISVRequisitionID, ISVRI.SparePartID,ISVRI.ClaimQty, " +
                            "ISVRI.JobID, J.JobNo, ISVRI.SparePartID, SP.Code SpareCode, SP.Name SpareName, " +
                            "SP.SalePrice, P.Name ProductName,GetDate() EDD, IsNull(SPS.SoundQty,0)SoundQty, SubStatus, "+
                            "IsNull(DS.JobCardNo,'N/A') LoanCode  " +
                            "FROM t_CSDISVRequisitionItem ISVRI INNER JOIN TELServiceDB.dbo.Job J " +
                            "ON J.JobID=ISVRI.JobID " +
                            "INNER JOIN TELServiceDB.dbo.SpareParts SP " +
                            "ON SP.ID=ISVRI.SparePartID " +
                            "LEFT OUTER JOIN TELServiceDB.dbo.DamageStock DS "+
                            "ON DS.ID=ISVRI.LoanProductID "+
                            "INNER JOIN TELServiceDB.dbo.Product P " +
                            "ON P.ProductID=J.ProductID " +
                            "Left Outer JOIN TELServiceDB.dbo.SparePartStock SPS " +
                            "ON SPS.SparePartID=SP.ID " +
                            "Where SubStatus IN (0,1) AND ISVRequisitionID=? ";

            cmd.Parameters.AddWithValue("ISVRequisitionID", _nISVRequisitionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    SparePartsTransactionDetail oSparePartsTransactionDetail = new SparePartsTransactionDetail();

                    oSparePartsTransactionDetail.SpareParts.Code = (string)reader["SpareCode"];
                    oSparePartsTransactionDetail.SpareParts.Name = (string)reader["SpareName"];
                    oSparePartsTransactionDetail.ClaimQty = (int)reader["ClaimQty"];
                    oSparePartsTransactionDetail.ReplaceJobFromCassandra.JobNo = (string)reader["JobNo"];
                    oSparePartsTransactionDetail.SerarchProduct.ProductName = (string)reader["ProductName"];
                    oSparePartsTransactionDetail.SubStatus = int.Parse(reader["SubStatus"].ToString());
                    oSparePartsTransactionDetail.LoanCode = (string)reader["LoanCode"];

                    InnerList.Add(oSparePartsTransactionDetail);
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
    public class SPTranItemCassandra
    {
        private int _nSPTranItemID;
        private int _nSPTranID;
        private int _nSparePartID;
        private int _nSoundQty;
        private int _nDamageQty;
        private int _nCostPrice;
        private int _nSalePrice;
        private int _nTranSide;
        private int _nCostPriceReceive;
        private int _nCostPriceAverage;

        private SpareParts _oSpareParts;
        private SPTranCassandra _oSPTranCassandra;


        /// <summary>
        /// Get set property for SPTranItemID
        /// </summary>
        public int SPTranItemID
        {
            get { return _nSPTranItemID; }
            set { _nSPTranItemID = value; }
        }
        /// <summary>
        /// Get set property for SPTranID
        /// </summary>
        public int SPTranID
        {
            get { return _nSPTranID; }
            set { _nSPTranID = value; }
        }

        /// <summary>
        /// Get set property for SparePartID
        /// </summary>
        public int SparePartID
        {
            get { return _nSparePartID; }
            set { _nSparePartID = value; }
        }
        /// <summary>
        /// Get set property for SoundQty
        /// </summary>
        public int SoundQty
        {
            get { return _nSoundQty; }
            set { _nSoundQty = value; }
        }
        /// <summary>
        /// Get set property for DamageQty
        /// </summary>
        public int DamageQty
        {
            get { return _nDamageQty; }
            set { _nDamageQty = value; }
        }
        /// <summary>
        /// Get set property for CostPrice
        /// </summary>
        public int CostPrice
        {
            get { return _nCostPrice; }
            set { _nCostPrice = value; }
        }
        /// <summary>
        /// Get set property for SalePrice
        /// </summary>
        public int SalePrice
        {
            get { return _nSalePrice; }
            set { _nSalePrice = value; }
        }
        /// <summary>
        /// Get set property for TranSide
        /// </summary>
        public int TranSide
        {
            get { return _nTranSide; }
            set { _nTranSide = value; }
        }
        /// <summary>
        /// Get set property for CostPriceReceive
        /// </summary>
        public int CostPriceReceive
        {
            get { return _nCostPriceReceive; }
            set { _nCostPriceReceive = value; }
        }
        /// <summary>
        /// Get set property for CostPriceAverage
        /// </summary>
        public int CostPriceAverage
        {
            get { return _nCostPriceAverage; }
            set { _nCostPriceAverage = value; }
        }

        public SpareParts SpareParts
        {
            get
            {
                if (_oSpareParts == null)
                {
                    _oSpareParts = new SpareParts();
                }
                return _oSpareParts;
            }
        }
        public SPTranCassandra SPTranCassandra
        {
            get
            {
                if (_oSPTranCassandra == null)
                {
                    _oSPTranCassandra = new SPTranCassandra();
                }
                return _oSPTranCassandra;
            }
        }
        //public void AddSPTranItem(int nSPTranID)
        public void AddSPTranItem()
        {
            int nMaxSPTranItemID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SPTranItemID]) FROM TELServiceDB.dbo.SPTranItem";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSPTranItemID = 1;
                }
                else
                {
                    nMaxSPTranItemID = Convert.ToInt32(maxID) + 1;
                }
                _nSPTranItemID = nMaxSPTranItemID;

                //sSql = "SELECT FROM TELServiceDB.dbo.SPTran Where JobID=?";
                //cmd.CommandText = sSql;

                //_nSPTranID = SPTranID;


                sSql = "INSERT INTO TELServiceDB.dbo.SPTranItem(SPTranItemID,SPTranID,SparePartID,SoundQty,DamageQty,CostPrice, " +
                        "SalePrice,TranSide,CostPriceReceive,CostPriceAverage) VALUES(?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SPTranItemID", _nSPTranItemID);
                cmd.Parameters.AddWithValue("SPTranID", _nSPTranID);
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.Parameters.AddWithValue("SoundQty", _nSoundQty);
                cmd.Parameters.AddWithValue("DamageQty", 0);
                cmd.Parameters.AddWithValue("CostPrice", _nCostPrice);
                cmd.Parameters.AddWithValue("SalePrice", _nSalePrice);
                cmd.Parameters.AddWithValue("TranSide", 2);
                cmd.Parameters.AddWithValue("CostPriceReceive", 0);
                cmd.Parameters.AddWithValue("CostPriceAverage", 0);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool CheckSPTranItem()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM TELServiceDB.dbo.SPTranItem where SPTranID=? and SparePartID=? ";
            cmd.Parameters.AddWithValue("SPTranID", _nSPTranID);
            cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nSPTranID = (int)reader["SPTranID"];

                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return true;
            else return false;
        }
    }
    public class SPTranCassandra : CollectionBase
    {
        public SPTranItemCassandra this[int i]
        {
            get { return (SPTranItemCassandra)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SPTranItemCassandra oSPTranItemCassandra)
        {
            InnerList.Add(oSPTranItemCassandra);
        }

        private int _nSPTranID;
        private string _sTranNo;
        private DateTime _dTranDate;
        private int _nTranType;
        private int _nTranSide;
        private string _sInvoiceNo;
        private string _sCashMemoNo;
        private string _sRefRequisitionNo;
        private Object _nSupplierID;
        private int _nJobID;
        private Object _nTechnicianID;
        private int _nInterServiceID;
        private Object _nSisterConcernID;
        private string _sCustomerName;
        private string _sCustomerAddress;
        private int _sDiscountAmt;
        private string _sRemarks;
        private int _nEnteredBy;
        private DateTime _dEntryDate;
        private string _sMarketLocation;
        private int _nBrandID;
        private int _nProductID;
        private int _nWorkshopID;
        private Object _dInvoiceDate;
        private string _sVoucherNo;
        private Object _dReceiptDate;


        /// <summary>
        /// Get set property for SPTranID
        /// </summary>
        public int SPTranID
        {
            get { return _nSPTranID; }
            set { _nSPTranID = value; }
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
        /// Get set property for TranType
        /// </summary>
        public int TranType
        {
            get { return _nTranType; }
            set { _nTranType = value; }
        }
        /// <summary>
        /// Get set property for TranSide
        /// </summary>
        public int TranSide
        {
            get { return _nTranSide; }
            set { _nTranSide = value; }
        }
        /// <summary>
        /// Get set property for InvoiceNo
        /// </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for CashMemoNo
        /// </summary>
        public string CashMemoNo
        {
            get { return _sCashMemoNo; }
            set { _sCashMemoNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for RefRequisitionNo
        /// </summary>
        public string RefRequisitionNo
        {
            get { return _sRefRequisitionNo; }
            set { _sRefRequisitionNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for SupplierID
        /// </summary>
        public Object SupplierID
        {
            get { return _nSupplierID; }
            set { _nSupplierID = value; }
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
        /// Get set property for TechnicianID
        /// </summary>
        public Object TechnicianID
        {
            get { return _nTechnicianID; }
            set { _nTechnicianID = value; }
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
        /// Get set property for SisterConcernID
        /// </summary>
        public Object SisterConcernID
        {
            get { return _nSisterConcernID; }
            set { _nSisterConcernID = value; }
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
        /// Get set property for CustomerAddress
        /// </summary>
        public string CustomerAddress
        {
            get { return _sCustomerAddress; }
            set { _sCustomerAddress = value.Trim(); }
        }
        /// <summary>
        /// Get set property for DiscountAmt
        /// </summary>
        public int DiscountAmt
        {
            get { return _sDiscountAmt; }
            set { _sDiscountAmt = value; }
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
        /// Get set property for MarketLocation
        /// </summary>
        public string MarketLocation
        {
            get { return _sMarketLocation; }
            set { _sMarketLocation = value.Trim(); }
        }
        /// <summary>
        /// Get set property for BrandID
        /// </summary>
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
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
        /// Get set property for WorkshopID
        /// </summary>
        public int WorkshopID
        {
            get { return _nWorkshopID; }
            set { _nWorkshopID = value; }
        }
        /// <summary>
        /// Get set property for InvoiceDate
        /// </summary>
        public Object InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }
        /// <summary>
        /// Get set property for VoucherNo
        /// </summary>
        public string VoucherNo
        {
            get { return _sVoucherNo; }
            set { _sVoucherNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for ReceiptDate
        /// </summary>
        public Object ReceiptDate
        {
            get { return _dReceiptDate; }
            set { _dReceiptDate = value; }
        }


        public void AddSPTranIssueParts()
        {
            int nMaxSPTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SPTranID]) FROM TELServiceDB.dbo.SPTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSPTranID = 1;
                }
                else
                {
                    nMaxSPTranID = Convert.ToInt32(maxID) + 1;
                }
                _nSPTranID = nMaxSPTranID;
                _sTranNo = nMaxSPTranID.ToString();


                sSql = "INSERT INTO TELServiceDB.dbo.SPTran(SPTranID,TranNo,TranDate,TranType,TranSide,InvoiceNo, " +
                        "CashMemoNo,RefRequisitionNo,SupplierID,JobID,TechnicianID,InterServiceID,SisterConcernID,CustomerName, " +
                        "CustomerAddress,DiscountAmt,Remarks,EnteredBy,EntryDate,MarketLocation,BrandID,ProductID,WorkshopID, " +
                        "InvoiceDate,VoucherNo,ReceiptDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                //oSPTranCassandra.InterServiceID = _oISVRequisition.InterServiceID;
                 //Convert.ToInt32(oItemRow.Cells[14].Value.ToString().Trim())

                cmd.Parameters.AddWithValue("SPTranID", _nSPTranID);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("TranType", 1);
                cmd.Parameters.AddWithValue("TranSide", 2);
                cmd.Parameters.AddWithValue("InvoiceNo", "");
                cmd.Parameters.AddWithValue("CashMemoNo", "");
                cmd.Parameters.AddWithValue("RefRequisitionNo", "");
                cmd.Parameters.AddWithValue("SupplierID", null);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("TechnicianID", null);
                cmd.Parameters.AddWithValue("InterServiceID", _nInterServiceID);
                cmd.Parameters.AddWithValue("SisterConcernID", null);
                cmd.Parameters.AddWithValue("CustomerName", "");
                cmd.Parameters.AddWithValue("CustomerAddress", "");
                cmd.Parameters.AddWithValue("DiscountAmt", 0);
                cmd.Parameters.AddWithValue("Remarks", "");
                cmd.Parameters.AddWithValue("EnteredBy", -9);
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("MarketLocation", "");
                cmd.Parameters.AddWithValue("BrandID", 0);
                cmd.Parameters.AddWithValue("ProductID", 0);
                cmd.Parameters.AddWithValue("WorkshopID", 0);
                cmd.Parameters.AddWithValue("InvoiceDate", null);
                cmd.Parameters.AddWithValue("VoucherNo", "");
                cmd.Parameters.AddWithValue("ReceiptDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //foreach (SPTranItemCassandra oItem in this)
                //{
                //    oItem.AddSPTranItem(_nSPTranID);
                //}
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByJobID()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM TELServiceDB.dbo.SPTran where JobID=?";
            cmd.Parameters.AddWithValue("JobID", _nJobID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nSPTranID = (int)reader["SPTranID"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckSPTranJobID()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM TELServiceDB.dbo.SPTran where JobID=? ";
            cmd.Parameters.AddWithValue("JobID", _nJobID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nSPTranID = (int)reader["SPTranID"];

                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return true;
            else return false;
        }
        public void RefreshSPTranByJobID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM TELServiceDB.dbo.SPTran where JobID=? ";
            cmd.Parameters.AddWithValue("JobID", _nJobID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nSPTranID = (int)reader["SPTranID"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
       

    }
    public class SPTranCassandras : CollectionBase
    {
        public SPTranCassandra this[int i]
        {
            get { return (SPTranCassandra)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SPTranCassandra oSPTranCassandra)
        {
            InnerList.Add(oSPTranCassandra);
        }

        //////

    }
    public class SparePartsIssueFromLoanSet
    {
        private int _nID;
        private int _nDamageProductID;
        private int _nSparePartsID;
        private int _nJobID;
        private int _nQuantity;
        private string _sSerialNo;

        private LoanProductCassandra _oLoanProductCassandra;


        /// <summary>
        /// Get set property for ID
        /// </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
        /// <summary>
        /// Get set property for DamageProductID
        /// </summary>
        public int DamageProductID
        {
            get { return _nDamageProductID; }
            set { _nDamageProductID = value; }
        }
        /// <summary>
        /// Get set property for SparePartsID
        /// </summary>
        public int SparePartsID
        {
            get { return _nSparePartsID; }
            set { _nSparePartsID = value; }
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
        /// Get set property for Quantity
        /// </summary>
        public int Quantity
        {
            get { return _nQuantity; }
            set { _nQuantity = value; }
        }
        /// <summary>
        /// Get set property for SerialNo
        /// </summary>
        public string SerialNo
        {
            get { return _sSerialNo; }
            set { _sSerialNo = value; }
        }


        public LoanProductCassandra LoanProductCassandra
        {
            get
            {
                if (_oLoanProductCassandra == null)
                {
                    _oLoanProductCassandra = new LoanProductCassandra();
                    //_oLoanProductCassandra.SerialNo = _sSerialNo;
                    //_oLoanProductCassandra.RefreshSpareParts();
                }
                return _oLoanProductCassandra;
            }
        }
        //public void RefreshSpareParts()
        //{
        //    SpareParts.ID = _nSparePartID;
        //    SpareParts.RefreshSpareParts();
        //}

        public void AddSpareFromLoanSet()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ID]) FROM TELServiceDB.dbo.SPFromDamageProduct";
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


                sSql = "INSERT INTO TELServiceDB.dbo.SPFromDamageProduct(ID,DamageProductID,SparePartsID,JobID,Quantity,SerialNo "
                    + " ) VALUES(?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("DamageProductID",_nDamageProductID);
                cmd.Parameters.AddWithValue("SparePartsID", _nSparePartsID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                cmd.Parameters.AddWithValue("SerialNo", _sSerialNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateSpareFromLoanSet()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "UPDATE TELServiceDB.dbo.SPFromDamageProduct SET Quantity=Quantity+?  WHERE SparePartsID=? AND JobID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Quantity", _nQuantity);

                cmd.Parameters.AddWithValue("SparePartsID", _nSparePartsID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckTran()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM TELServiceDB.dbo.SPFromDamageProduct where SparePartsID=? AND JobID=? ";
            cmd.Parameters.AddWithValue("SparePartsID", _nSparePartsID);
            cmd.Parameters.AddWithValue("JobID", _nJobID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sSerialNo = (string)reader["SerialNo"];

                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return true;
            else return false;
        }

    }
    public class SparePartsSend
    {

        private int _nISVRequisitionSendID;
        private int _nISVRequisitionID;
        private int _nModeOfSend;
        private int _nCourierID;
        private DateTime _dBookingDate;
        private string _sConsignmentNo;
        private Object _sReceiveBy;
        private Object _sRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;

        private SparePartsTransaction _oSparePartsTransaction;
        public SparePartsTransaction SparePartsTransaction
        {
            get
            {
                if (_oSparePartsTransaction == null)
                {
                    _oSparePartsTransaction = new SparePartsTransaction();

                }
                return _oSparePartsTransaction;
            }
        }
        private CourierFromCassandra _oCourierFromCassandra;
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

        /// <summary>
        /// Get set property for ISVRequisitionSendID
        /// </summary>
        public int ISVRequisitionSendID
        {
            get { return _nISVRequisitionSendID; }
            set { _nISVRequisitionSendID = value; }
        }
        /// <summary>
        /// Get set property for ISVRequisitionID
        /// </summary>
        public int ISVRequisitionID
        {
            get { return _nISVRequisitionID; }
            set { _nISVRequisitionID = value; }
        }
        /// <summary>
        /// Get set property for ModeOfSend
        /// </summary>
        public int ModeOfSend
        {
            get { return _nModeOfSend; }
            set { _nModeOfSend = value; }
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
        /// Get set property for BookingDate
        /// </summary>
        public DateTime BookingDate
        {
            get { return _dBookingDate; }
            set { _dBookingDate = value; }
        }
        /// <summary>
        /// Get set property for ConsignmentNo
        /// </summary>
        public string ConsignmentNo
        {
            get { return _sConsignmentNo; }
            set { _sConsignmentNo = value; }
        }
        /// <summary>
        /// Get set property for ReceiveBy
        /// </summary>
        public Object ReceiveBy
        {
            get { return _sReceiveBy; }
            set { _sReceiveBy = value; }
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

        

        public void AddRequisitionItemSend()
        {
            int nMaxISVRequisitionSendID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ISVRequisitionSendID]) FROM t_CSDISVRequisitionSend";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxISVRequisitionSendID = 1;
                }
                else
                {
                    nMaxISVRequisitionSendID = Convert.ToInt32(maxID) + 1;
                }
                _nISVRequisitionSendID = nMaxISVRequisitionSendID;


                sSql = "INSERT INTO t_CSDISVRequisitionSend(ISVRequisitionSendID,ISVRequisitionID,ModeOfSend,"
                    + " CourierID,BookingDate,ConsignmentNo,ReceiveBy,Remarks,CreateUserID, CreateDate"
                    + " ) VALUES(?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ISVRequisitionSendID", _nISVRequisitionSendID);
                cmd.Parameters.AddWithValue("ISVRequisitionID", _nISVRequisitionID);
                cmd.Parameters.AddWithValue("ModeOfSend", _nModeOfSend);
                cmd.Parameters.AddWithValue("CourierID", _nCourierID);
                cmd.Parameters.AddWithValue("BookingDate", _dBookingDate);
                cmd.Parameters.AddWithValue("ConsignmentNo", _sConsignmentNo);
                cmd.Parameters.AddWithValue("ReceiveBy", _sReceiveBy);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("Remarks", DateTime.Now);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
    public class SparePartsSends : CollectionBase
    {
        public SparePartsSend this[int i]
        {
            get { return (SparePartsSend)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SparePartsSend oSparePartsSend)
        {
            InnerList.Add(oSparePartsSend);
        }


        public void Refresh(int nISVRequisitionID)
        {
            //dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select ISVRequisitionSendID, ISVRequisitionID, BookingDate, ModeOfSend, " +
                            "IsNull(CS.Name,'N/A')CourierName,  " +
                            "IsNull(ConsignmentNo,'N/A')ConsignmentNo, IsNull(ReceiveBy,'N/A')ReceiveBy, Remarks " +
                            "from t_CSDISVRequisitionSend ISVRS " +
                            "Left Outer JOIN TELServiceDB.dbo.CourierService CS " +
                            "ON ISVRS.CourierID=CS.CourierServiceID " +
                            "Where ISVRequisitionID=? ";
                            //"Order by ISVRequisitionSendID ";

            cmd.Parameters.AddWithValue("ISVRequisitionID", nISVRequisitionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    SparePartsSend oSparePartsSend = new SparePartsSend();

                    oSparePartsSend.ISVRequisitionSendID = (int)reader["ISVRequisitionSendID"];
                    oSparePartsSend.ISVRequisitionID = (int)reader["ISVRequisitionID"];
                    oSparePartsSend.ModeOfSend = (int)reader["ModeOfSend"];
                    oSparePartsSend.BookingDate = Convert.ToDateTime(reader["BookingDate"].ToString());
                    oSparePartsSend.CourierFromCassandra.CourierServiceName = (string)reader["CourierName"];
                    oSparePartsSend.ConsignmentNo = (string)reader["ConsignmentNo"];
                    oSparePartsSend.ReceiveBy = (Object)reader["ReceiveBy"].ToString();
                    oSparePartsSend.Remarks = (Object)reader["Remarks"].ToString();


                    InnerList.Add(oSparePartsSend);
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
    public class ISVSpareCommunication
    { 
        private int _nID;
        private int _nISVRequisitionItemID;
        private DateTime _dEDD;
        private int _nIsIssue;
        private int _nIsCommunication;
        private int _nCommunicatedBy;
        private DateTime _dCommunicationDate;
        private Object _sRemarks;

        private SparePartsTransactionDetail _oSparePartsTransactionDetail;
        public SparePartsTransactionDetail SparePartsTransactionDetail
        {
            get
            {
                if (_oSparePartsTransactionDetail == null)
                {
                    _oSparePartsTransactionDetail = new SparePartsTransactionDetail();
                }
                return _oSparePartsTransactionDetail;
            }
        }

        private SpareParts _oSpareParts;
        public SpareParts SpareParts
        {
            get
            {
                if (_oSpareParts == null)
                {
                    _oSpareParts = new SpareParts();
                }
                return _oSpareParts;
            }
        }

        private SerarchProduct _oSerarchProduct;
        public SerarchProduct SerarchProduct
        {
            get
            {
                if (_oSerarchProduct == null)
                {
                    _oSerarchProduct = new SerarchProduct();
                }
                return _oSerarchProduct;
            }
        }

        private SparePartsTransaction _oSparePartsTransaction;
        public SparePartsTransaction SparePartsTransaction
        {
            get
            {
                if (_oSparePartsTransaction == null)
                {
                    _oSparePartsTransaction = new SparePartsTransaction();
                }
                return _oSparePartsTransaction;
            }
        }

        private InterService _oInterService;
        public InterService InterService
        {
            get
            {
                if (_oInterService == null)
                {
                    _oInterService = new InterService();
                }
                return _oInterService;
            }
        }

        private ReplaceJobFromCassandra _oReplaceJobFromCassandra;
        public ReplaceJobFromCassandra ReplaceJobFromCassandra
        {
            get
            {
                if (_oReplaceJobFromCassandra == null)
                {
                    _oReplaceJobFromCassandra = new ReplaceJobFromCassandra();
                }
                return _oReplaceJobFromCassandra;
            }
        }

        private User _oUser;
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
        /// Get set property for ID
        /// </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
        /// <summary>
        /// Get set property for ISVRequisitionItemID
        /// </summary>
        public int ISVRequisitionItemID
        {
            get { return _nISVRequisitionItemID; }
            set { _nISVRequisitionItemID = value; }
        }
        /// <summary>
        /// Get set property for EDD
        /// </summary>
        public DateTime EDD
        {
            get { return _dEDD; }
            set { _dEDD = value; }
        }
        /// <summary>
        /// Get set property for IsIssue
        /// </summary>
        public int IsIssue
        {
            get { return _nIsIssue; }
            set { _nIsIssue = value; }
        }
        /// <summary>
        /// Get set property for IsCommunication
        /// </summary>
        public int IsCommunication
        {
            get { return _nIsCommunication; }
            set { _nIsCommunication = value; }
        }
        /// <summary>
        /// Get set property for CommunicatedBy
        /// </summary>
        public int CommunicatedBy
        {
            get { return _nCommunicatedBy; }
            set { _nCommunicatedBy = value; }
        }
        /// <summary>
        /// Get set property for CommunicationDate
        /// </summary>
        public DateTime CommunicationDate
        {
            get { return _dCommunicationDate; }
            set { _dCommunicationDate = value; }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public Object Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }

        public void AddCommunicationableData()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CSDISVRequisitionCommunication";
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


                sSql = "INSERT INTO t_CSDISVRequisitionCommunication(ID,ISVRequisitionItemID,EDD,IsIssue,IsCommunication) VALUES(?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ISVRequisitionItemID", _nISVRequisitionItemID);
                cmd.Parameters.AddWithValue("EDD", _dEDD);
                cmd.Parameters.AddWithValue("IsIssue", (int)Dictionary.InquiryCommunicationStatus.False);
                cmd.Parameters.AddWithValue("IsCommunication", (int)Dictionary.InquiryCommunicationStatus.False);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateIssue()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_CSDISVRequisitionCommunication SET IsIssue=?  WHERE ISVRequisitionItemID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsIssue", _nIsIssue);

                cmd.Parameters.AddWithValue("ISVRequisitionItemID", _nISVRequisitionItemID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateCommunication()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_CSDISVRequisitionCommunication SET Remarks=?, IsCommunication=?, CommunicatedBy=?, CommunicationDate=? WHERE ID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsCommunication", (int)Dictionary.InquiryCommunicationStatus.True);
                cmd.Parameters.AddWithValue("CommunicatedBy", Utility.UserId);
                cmd.Parameters.AddWithValue("CommunicationDate", DateTime.Now);

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckRequisitionItemISVRIIDNDate()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDISVRequisitionCommunication where ISVRequisitionItemID=? AND EDD=? ";
            cmd.Parameters.AddWithValue("ISVRequisitionItemID", _nISVRequisitionItemID);
            cmd.Parameters.AddWithValue("EDD", _dEDD);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nISVRequisitionItemID = (int)reader["ISVRequisitionItemID"];

                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return true;
            else return false;
        }
        public bool CheckRequisitionItemID()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDISVRequisitionCommunication where ISVRequisitionItemID=?";
            cmd.Parameters.AddWithValue("ISVRequisitionItemID", _nISVRequisitionItemID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nISVRequisitionItemID = (int)reader["ISVRequisitionItemID"];

                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return true;
            else return false;
        }
    }
    public class ISVSpareCommunications : CollectionBase
    {
        public ISVSpareCommunication this[int i]
        {
            get { return (ISVSpareCommunication)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ISVSpareCommunication oISVSpareCommunication)
        {
            InnerList.Add(oISVSpareCommunication);
        }

        public void RefreshByISVReqID(int nISVRequisitionID)
        {
            //dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql =   "Select ISVReqID,CommunicationDate,UserName " +
                            "From " +
                            "( " +
                            "Select ISVRC.CommunicatedBy,u.UserFullName UserName, " +
                            "CONVERT(VARCHAR(16), CommunicationDate, 121)CommunicationDate, " +
                            "ISVRI.ISVRequisitionID ISVReqID " +
                            "from t_CSDISVRequisitionCommunication ISVRC " +
                            "INNER JOIN t_CSDISVRequisitionItem ISVRI " +
                            "ON ISVRI.ISVRequisitionItemID=ISVRC.ISVRequisitionItemID " +
                            "INNER JOIN t_user U " +
                            "ON u.UserID=ISVRC.CommunicatedBy " +
                            "Where ISVRC.CommunicatedBy Is Not Null " +
                            "Group by ISVRC.CommunicatedBy,u.UserFullName, " +
                            "CONVERT(VARCHAR(16), CommunicationDate, 121), " +
                            "ISVRI.ISVRequisitionID " +
                            ")A Where ISVReqID=? ";

            cmd.Parameters.AddWithValue("ISVReqID", nISVRequisitionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {



                    ISVSpareCommunication oISVSpareCommunication = new ISVSpareCommunication();


                    oISVSpareCommunication.ISVRequisitionItemID = (int)reader["ISVReqID"];
                    oISVSpareCommunication.EDD = Convert.ToDateTime(reader["CommunicationDate"].ToString());
                    oISVSpareCommunication.User.UserFullName = (string)reader["UserName"];

                    InnerList.Add(oISVSpareCommunication);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshProActiveData()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select Final.ID, Final.EDD PAEDD,ISVRC.EDD, ISVRC.ISVRequisitionItemID, ISVRI.ISVRequisitionID, " +
                            "ISVRI.ClaimQty, SubStatusName=Case " +
                            "When SubStatus=0 Then 'FromStock' " +
                            "When SubStatus=1 Then 'FromLoanSet' " +
                            "When SubStatus=2 Then 'LocalPurchase' " +
                            "When SubStatus=3 Then 'ForeignOrder' " +
                            "When SubStatus=4 Then 'LoanRequisition' " +
                            "When SubStatus=5 Then 'Suspend' " +
                            "When SubStatus=6 Then 'Rejected' " +
                            "When SubStatus=-9 Then 'Receive' " +
                            "End, J.JobNo, SP.Code SpareCode, SP.Name SpareName " +
                            "From " +
                            "( " +
                //Before 1 Day
                            "Select A.ID, (ISVRC.EDD-1)EDD from " +
                            "( " +
                            "Select Max(ID)ID,ISVRequisitionItemID from " +
                            "(Select * from t_CSDISVRequisitionCommunication Where IsIssue =0)A " +
                            "group by ISVRequisitionItemID " +
                            ")A " +
                            "INNER JOIN t_CSDISVRequisitionCommunication ISVRC " +
                            "ON ISVRC.ID=A.ID " +
                            "Where EDD Not IN (Select Holiday From t_HRHoliday) " +
                            "UNION ALL " +
                //If Holiday = 1 Day 
                            "Select ID,(EDD-1)EDD " +
                            "From ( " +
                            "Select A.ID, (ISVRC.EDD-1)EDD from " +
                            "( " +
                            "Select Max(ID)ID,ISVRequisitionItemID from " +
                            "(Select * from t_CSDISVRequisitionCommunication Where IsIssue =0)A " +
                            "group by ISVRequisitionItemID " +
                            ")A " +
                            "INNER JOIN t_CSDISVRequisitionCommunication ISVRC " +
                            "ON ISVRC.ID=A.ID " +
                            "Where EDD IN (Select Holiday From t_HRHoliday) " +
                            ")A Where EDD Not IN (Select Holiday From t_HRHoliday) " +

                            "UNION ALL " +
                //If Holiday = 2 Days Continously
                            "Select ID,(EDD-1)EDD " +
                            "From( " +
                            "Select ID,(EDD-1)EDD " +
                            "From ( " +
                            "Select A.ID, (ISVRC.EDD-1)EDD from " +
                            "( " +
                            "Select Max(ID)ID,ISVRequisitionItemID from " +
                            "(Select * from t_CSDISVRequisitionCommunication Where IsIssue =0)A " +
                            "group by ISVRequisitionItemID " +
                            ")A " +
                            "INNER JOIN t_CSDISVRequisitionCommunication ISVRC " +
                            "ON ISVRC.ID=A.ID " +
                            "Where EDD IN (Select Holiday From t_HRHoliday) " +
                            ")A Where EDD IN (Select Holiday From t_HRHoliday) " +
                            ")A Where EDD NOT IN (Select Holiday From t_HRHoliday) " +
                            "UNION ALL " +
                //If Holiday = 3 Days Continously
                            "Select ID,(EDD-1)EDD " +
                            "From ( " +
                            "Select ID,(EDD-1)EDD " +
                            "From( " +
                            "Select ID,(EDD-1)EDD " +
                            "From ( " +
                            "Select A.ID, (ISVRC.EDD-1)EDD from " +
                            "( " +
                            "Select Max(ID)ID,ISVRequisitionItemID from " +
                            "(Select * from t_CSDISVRequisitionCommunication Where IsIssue =0)A " +
                            "group by ISVRequisitionItemID " +
                            ")A " +
                            "INNER JOIN t_CSDISVRequisitionCommunication ISVRC " +
                            "ON ISVRC.ID=A.ID " +
                            "Where EDD IN (Select Holiday From t_HRHoliday) " +
                            ")A Where EDD IN (Select Holiday From t_HRHoliday) " +
                            ")A Where EDD IN (Select Holiday From t_HRHoliday) " +
                            ")A Where EDD NOT IN (Select Holiday From t_HRHoliday) " +

                            "UNION ALL " +
                //If Holiday = 4 Days Continously

                            "Select ID,(EDD-1)EDD " +
                            "From ( " +
                            "Select ID,(EDD-1)EDD " +
                            "From ( " +
                            "Select ID,(EDD-1)EDD " +
                            "From( " +
                            "Select ID,(EDD-1)EDD " +
                            "From ( " +
                            "Select A.ID, (ISVRC.EDD-1)EDD from " +
                            "( " +
                            "Select Max(ID)ID,ISVRequisitionItemID from " +
                            "(Select * from t_CSDISVRequisitionCommunication Where IsIssue =0)A " +
                            "group by ISVRequisitionItemID " +
                            ")A " +
                            "INNER JOIN t_CSDISVRequisitionCommunication ISVRC " +
                            "ON ISVRC.ID=A.ID " +
                            "Where EDD IN (Select Holiday From t_HRHoliday) " +
                            ")A Where EDD IN (Select Holiday From t_HRHoliday) " +
                            ")A Where EDD IN (Select Holiday From t_HRHoliday) " +
                            ")A Where EDD IN (Select Holiday From t_HRHoliday) " +
                            ")A Where EDD NOT IN (Select Holiday From t_HRHoliday) " +
                            "UNION ALL " +

                            //If Holiday = 5 Days Continously
                            "Select ID,(EDD-1)EDD " +
                            "From ( " +
                            "Select ID,(EDD-1)EDD " +
                            "From ( " +
                            "Select ID,(EDD-1)EDD " +
                            "From ( " +
                            "Select ID,(EDD-1)EDD " +
                            "From( " +
                            "Select ID,(EDD-1)EDD " +
                            "From ( " +
                            "Select A.ID, (ISVRC.EDD-1)EDD from " +
                            "( " +
                            "Select Max(ID)ID,ISVRequisitionItemID from " +
                            "(Select * from t_CSDISVRequisitionCommunication Where IsIssue =0)A " +
                            "group by ISVRequisitionItemID " +
                            ")A " +
                            "INNER JOIN t_CSDISVRequisitionCommunication ISVRC " +
                            "ON ISVRC.ID=A.ID " +
                            "Where EDD IN (Select Holiday From t_HRHoliday) " +
                            ")A Where EDD IN (Select Holiday From t_HRHoliday) " +
                            ")A Where EDD IN (Select Holiday From t_HRHoliday) " +
                            ")A Where EDD IN (Select Holiday From t_HRHoliday) " +
                            ")A Where EDD IN (Select Holiday From t_HRHoliday) " +
                            ")A Where EDD NOT IN (Select Holiday From t_HRHoliday) " +
                            ")Final " +
                            "INNER JOIN t_CSDISVRequisitionCommunication ISVRC " +
                            "ON Final.ID=ISVRC.ID " +
                            "INNER JOIN t_CSDISVRequisitionItem ISVRI " +
                            "ON ISVRI.ISVRequisitionItemID=ISVRC.ISVRequisitionItemID " +
                            "INNER JOIN TELServiceDB.dbo.Spareparts SP " +
                            "ON SP.ID=ISVRI.SparepartID " +
                            "INNER JOIN TELServiceDB.dbo.Job J " +
                            "ON J.JobID=ISVRI.JobID " +
                            "Where CONVERT(DateTime, CONVERT(Char, GETDATE(),103),103)-Final.EDD=0 " +
                            "Order by Final.ID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ISVSpareCommunication oISVSpareCommunication = new ISVSpareCommunication();

                    oISVSpareCommunication.ID = (int)reader["ID"];
                    oISVSpareCommunication.EDD = Convert.ToDateTime(reader["EDD"].ToString());
                    oISVSpareCommunication.ISVRequisitionItemID = (int)reader["ISVRequisitionItemID"];
                    oISVSpareCommunication.SparePartsTransactionDetail.ISVRequisitionID = (int)reader["ISVRequisitionID"];
                    oISVSpareCommunication.SparePartsTransactionDetail.ClaimQty = (int)reader["ClaimQty"];
                    oISVSpareCommunication.SparePartsTransactionDetail.SubStatusName = (string)reader["SubStatusName"];
                    oISVSpareCommunication.SpareParts.Code = (string)reader["SpareCode"];
                    oISVSpareCommunication.SpareParts.Name = (string)reader["SpareName"];
                    oISVSpareCommunication.ReplaceJobFromCassandra.JobNo = (string)reader["JobNo"];

                    InnerList.Add(oISVSpareCommunication);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(String txtRequisitionIDs, String txtSerialNos, String txtJobNos, String txtReportNos, int nInterServiceID)
        {
            
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select ISVRC.ID, ISVRC.ISVRequisitionItemID,ISVRI.ISVRequisitionID, "+
                            "IsNull(ISVRC.Remarks,'')Remarks, "+
                            "ISVRC.EDD, ClaimQty, SubStatus=CASE " +
                            "When SubStatus=0 then 'FromStock' " +
                            "When SubStatus=1 then 'FromLoanSet' " +
                            "When SubStatus=2 then 'LocalPurchase' " +
                            "When SubStatus=3 then 'ForeignOrder' " +
                            "When SubStatus=4 then 'LoanRequisition' " +
                            "When SubStatus=5 then 'Suspend' " +
                            "When SubStatus=6 then 'Rejected' " +
                            "end, SP.Code SpareCode, SP.Name SpareName, J.JobNo,P.Name ProductName, " +
                            "ISVR.SerialNo, ISVR.ReportNo,ISV.ID ISVID, ISV.Code ISVCode, ISV.Name ISVName " +
                            "from t_CSDISVRequisitionCommunication ISVRC " +
                            "INNER JOIN t_CSDISVRequisitionItem ISVRI " +
                            "ON ISVRI.ISVRequisitionItemID=ISVRC.ISVRequisitionItemID " +
                            "INNER JOIN TELServiceDB.dbo.SpareParts SP " +
                            "ON SP.ID=ISVRI.SparePartID " +
                            "INNER JOIN TELServiceDB.dbo.Job J " +
                            "ON J.JobID=ISVRI.JobID " +
                            "INNER JOIN TELServiceDB.dbo.Product P " +
                            "ON P.ProductID=J.ProductID " +
                            "INNER JOIN t_CSDISVRequisition ISVR " +
                            "ON ISVR.ISVRequisitionID=ISVRI.ISVRequisitionID " +
                            "INNER JOIN TELServiceDB.dbo.InterService ISV " +
                            "ON ISV.ID=ISVR.InterServiceID " +
                            "Where ISVRC.IsIssue =0 AND IsCommunication =0 ";

            if (txtRequisitionIDs != "")
            {
                sSql = sSql + " AND ISVRI.ISVRequisitionID ='" + txtRequisitionIDs + "'";
            }
            if (txtSerialNos != "")
            {
                sSql = sSql + " AND ISVR.SerialNo ='" + txtSerialNos + "'";
            }
            if (txtJobNos != "")
            {
                sSql = sSql + " AND J.JobNo ='" + txtJobNos + "'";
            }
            if (txtReportNos != "")
            {
                sSql = sSql + " AND ISVR.ReportNo ='" + txtReportNos + "'";
            }
            if (nInterServiceID != 0)
            {
                sSql = sSql + " AND ISV.ID ='" + nInterServiceID + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ISVSpareCommunication oISVSpareCommunication = new ISVSpareCommunication();

                    oISVSpareCommunication.ID = (int)reader["ID"];
                    oISVSpareCommunication.ISVRequisitionItemID = (int)reader["ISVRequisitionItemID"];
                    oISVSpareCommunication.EDD = Convert.ToDateTime(reader["EDD"].ToString());
                    oISVSpareCommunication.SparePartsTransactionDetail.ClaimQty = (int)reader["ClaimQty"];
                    oISVSpareCommunication.SparePartsTransactionDetail.SubStatusName = (string)reader["SubStatus"];
                    oISVSpareCommunication.SpareParts.Code = (string)reader["SpareCode"];
                    oISVSpareCommunication.SpareParts.Name = (string)reader["SpareName"];
                    oISVSpareCommunication.SerarchProduct.ProductName = (string)reader["ProductName"];
                    oISVSpareCommunication.SparePartsTransaction.SerialNo = (Object)reader["SerialNo"].ToString();
                    oISVSpareCommunication.SparePartsTransaction.ReportNo = (Object)reader["ReportNo"].ToString();
                    oISVSpareCommunication.InterService.InterServiceID = (int)reader["ISVID"];
                    oISVSpareCommunication.InterService.Code = (string)reader["ISVCode"];
                    oISVSpareCommunication.InterService.Name = (string)reader["ISVName"];
                    oISVSpareCommunication.ReplaceJobFromCassandra.JobNo = (string)reader["JobNo"];
                    oISVSpareCommunication.SparePartsTransactionDetail.ISVRequisitionID = (int)reader["ISVRequisitionID"];
                    oISVSpareCommunication.Remarks = (Object)reader["Remarks"].ToString();


                    InnerList.Add(oISVSpareCommunication);
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

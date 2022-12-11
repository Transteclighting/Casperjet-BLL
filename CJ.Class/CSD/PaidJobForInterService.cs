// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Jun 12, 2012
// Time :  04:00 PM
// Description: Class for Inter Service Paid Job.
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
    public class PaidJobForInterService
    {
        private int _nPaidJobID;
        private int _nSourceID;
        private string _sCustomerName;
        private string _sAddress;
        private Object _sLocation;
        private Object _sContactNo;
        private int _nProductID;
        private int _nFaultID;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private Object _dExpectedServiceDate;
        private int _nStatus;
        private Object _sReceiveRemarks;
        private int _nAssignInterServiceID;
        private Object _dScheduleDate;
        private Object _sConvertedJobNo;
        private int _nCommunicationStatus;
        private int _nCommuUserID;
        private Object _dCommuDate;
        private Object _sCommuRemarks;
        private Object _dEDDIfPending;
        private Object _dDeliveryDate;
        private string _sProductNames;

        private Object _sAssignTo;
        private string _sUserName;
        private Object _dExpectedDateOnly;
        private Object _dScheduleDateOnly;
        private Object _dExpectedTime;
        private Object _dScheduleTime;
        private string _sFaultName;
        private string _sStatusName;
        private Object _sScheduleRemarks;
        private Object _sWIPRemarks;
        private Object _sSPRemarks;
        private Object _sPenRemarks;
        private Object _sCanRemarks;
        private Object _sConvRemarks;
        private Object _sISCode;
        private Object _dEDDIfPendingg;
        private Object _dDeliveryDatee;


        private User _oUser;
        private InterService _oInterService;
        private Product _oProduct;
        private ChannelFromCassandra _oChannelFromCassandra;
        private ProductFaultFromCassandra _oProductFaultFromCassandra;

        /// <summary>
        /// Get set property for PaidJobID
        /// </summary>
        public int PaidJobID
        {
            get { return _nPaidJobID; }
            set { _nPaidJobID = value; }
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
        /// Get set property for CustomerName
        /// </summary>
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for Address
        /// </summary>
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value.Trim(); }
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
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        /// <summary>
        /// Get set property for FaultID
        /// </summary>
        public int FaultID
        {
            get { return _nFaultID; }
            set { _nFaultID = value; }
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
        /// Get set property for CreateUserID
        /// </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        /// <summary>
        /// Get set property for ExpectedServiceDate
        /// </summary>
        public Object ExpectedServiceDate
        {
            get { return _dExpectedServiceDate; }
            set { _dExpectedServiceDate = value; }
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
        /// Get set property for ReceiveRemarks
        /// </summary>
        public Object ReceiveRemarks
        {
            get { return _sReceiveRemarks; }
            set { _sReceiveRemarks = value; }
        }
        /// <summary>
        /// Get set property for AssignInterServiceID
        /// </summary>
        public int AssignInterServiceID
        {
            get { return _nAssignInterServiceID; }
            set { _nAssignInterServiceID = value; }
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
        /// Get set property for ConvertedJobNo
        /// </summary>
        public Object ConvertedJobNo
        {
            get { return _sConvertedJobNo; }
            set { _sConvertedJobNo = value; }
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
        /// Get set property for CommuUserID
        /// </summary>
        public int CommuUserID
        {
            get { return _nCommuUserID; }
            set { _nCommuUserID = value; }
        }
        /// <summary>
        /// Get set property for CommuDate
        /// </summary>
        public Object CommuDate
        {
            get { return _dCommuDate; }
            set { _dCommuDate = value; }
        }
        /// <summary>
        /// Get set property for CommuRemarks
        /// </summary>
        public Object CommuRemarks
        {
            get { return _sCommuRemarks; }
            set { _sCommuRemarks = value; }
        }
        /// <summary>
        /// Get set property for EDDIfPending
        /// </summary>
        public Object EDDIfPending
        {
            get { return _dEDDIfPending; }
            set { _dEDDIfPending = value; }
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
        /// Get set property for ProductName
        /// </summary>
        public string ProductNames
        {
            get { return _sProductNames; }
            set { _sProductNames = value; }
        }

        /// <summary>
        /// Get set property for AssignTo
        /// </summary>
        public Object AssignTo
        {
            get { return _sAssignTo; }
            set { _sAssignTo = value; }
        }
        /// <summary>
        /// Get set property for UserName
        /// </summary>
        public string UserName
        {
            get { return _sUserName; }
            set { _sUserName = value; }
        }
        /// <summary>
        /// Get set property for ExpectedDateOnly
        /// </summary>
        public Object ExpectedDateOnly
        {
            get { return _dExpectedDateOnly; }
            set { _dExpectedDateOnly = value; }
        }
        /// <summary>
        /// Get set property for ScheduleDateOnly
        /// </summary>
        public Object ScheduleDateOnly
        {
            get { return _dScheduleDateOnly; }
            set { _dScheduleDateOnly = value; }
        }
        /// <summary>
        /// Get set property for ExpectedTime
        /// </summary>
        public Object ExpectedTime
        {
            get { return _dExpectedTime; }
            set { _dExpectedTime = value; }
        }
        /// <summary>
        /// Get set property for ScheduleTime
        /// </summary>
        public Object ScheduleTime
        {
            get { return _dScheduleTime; }
            set { _dScheduleTime = value; }
        }
        /// <summary>
        /// Get set property for FaultName
        /// </summary>
        public string FaultName
        {
            get { return _sFaultName; }
            set { _sFaultName = value; }
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
        /// Get set property for EDDIfPendingg
        /// </summary>
        public Object EDDIfPendingg
        {
            get { return _dEDDIfPendingg; }
            set { _dEDDIfPendingg = value; }
        }
        /// <summary>
        /// Get set property for DeliveryDatee
        /// </summary>
        public Object DeliveryDatee
        {
            get { return _dDeliveryDatee; }
            set { _dDeliveryDatee = value; }
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
        /// Get set property for WIPRemarks
        /// </summary>
        public Object WIPRemarks
        {
            get { return _sWIPRemarks; }
            set { _sWIPRemarks = value; }
        }
        /// <summary>
        /// Get set property for SPRemarks
        /// </summary>
        public Object SPRemarks
        {
            get { return _sSPRemarks; }
            set { _sSPRemarks = value; }
        }
        /// <summary>
        /// Get set property for PenRemarks
        /// </summary>
        public Object PenRemarks
        {
            get { return _sPenRemarks; }
            set { _sPenRemarks = value; }
        }
        /// <summary>
        /// Get set property for CanRemarks
        /// </summary>
        public Object CanRemarks
        {
            get { return _sCanRemarks; }
            set { _sCanRemarks = value; }
        }
        /// <summary>
        /// Get set property for ConvRemarks
        /// </summary>
        public Object ConvRemarks
        {
            get { return _sConvRemarks; }
            set { _sConvRemarks = value; }
        }

        /// <summary>
        /// Get set property for ISCode
        /// </summary>
        public Object ISCode
        {
            get { return _sISCode; }
            set { _sISCode = value; }
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
                    _oInterService.InterServiceID = _nAssignInterServiceID;
                    _oInterService.RefreshByID();
                }
                return _oInterService;
            }
        }
        public Product Product
        {
            get
            {
                if (_oProduct == null)
                {
                    _oProduct = new Product();
                    _oProduct.ProductID = _nProductID;
                    _oProduct.RefreshByID();
                }
                return _oProduct;
            }
        }
        public ChannelFromCassandra ChannelFromCassandra
        {
            get
            {
                if (_oChannelFromCassandra == null)
                {
                    _oChannelFromCassandra = new ChannelFromCassandra();
                    _oChannelFromCassandra.ChannelID = _nSourceID;
                    _oChannelFromCassandra.RefreshByID();
                }
                return _oChannelFromCassandra;
            }
        }
        public ProductFaultFromCassandra ProductFaultFromCassandra
        {
            get
            {
                if (_oProductFaultFromCassandra == null)
                {
                    _oProductFaultFromCassandra = new ProductFaultFromCassandra();
                    _oProductFaultFromCassandra.DescriptionID = _nFaultID;
                    _oProductFaultFromCassandra.RefreshByFaultID();
                }
                return _oProductFaultFromCassandra;
            }
        }

        public void Add()
        {
            int nMaxPaidJobID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([PaidJobID]) FROM t_CSDInterServicePaidJob";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPaidJobID = 1;
                }
                else
                {
                    nMaxPaidJobID = Convert.ToInt32(maxID) + 1;
                }
                _nPaidJobID = nMaxPaidJobID;


                sSql = "INSERT INTO t_CSDInterServicePaidJob(PaidJobID,SourceID,CustomerName,Address,Location,ContactNo,ProductID,"
                    + " FaultID,CreateUserID,CreateDate,ExpectedServiceDate,Status,ReceiveRemarks,CommunicationStatus,AssignInterServiceID "
                    + " ) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PaidJobID", _nPaidJobID);
                cmd.Parameters.AddWithValue("SourceID", _nSourceID);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Location", _sLocation);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("FaultID", _nFaultID);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("ExpectedServiceDate", _dExpectedServiceDate);
                cmd.Parameters.AddWithValue("Status", (short)Dictionary.ISPaidJobStatus.Receive);
                cmd.Parameters.AddWithValue("ReceiveRemarks", _sReceiveRemarks);
                cmd.Parameters.AddWithValue("CommunicationStatus", (short)Dictionary.InquiryCommunicationStatus.False);
                cmd.Parameters.AddWithValue("AssignInterServiceID", 0);

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

                cmd.CommandText = "UPDATE t_CSDInterServicePaidJob SET SourceID=?,CustomerName=?,Address=?,Location=?,ContactNo=?,ProductID=?,"
                    + " FaultID=?,ExpectedServiceDate=?,ReceiveRemarks=? Where PaidJobID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SourceID", _nSourceID);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Location", _sLocation);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("FaultID", _nFaultID);
                cmd.Parameters.AddWithValue("ExpectedServiceDate", _dExpectedServiceDate);
                cmd.Parameters.AddWithValue("ReceiveRemarks", _sReceiveRemarks);

                cmd.Parameters.AddWithValue("PaidJobID", _nPaidJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Assign()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDInterServicePaidJob SET AssignInterServiceID=?,ScheduleDate=?,Status=? WHERE PaidJobID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AssignInterServiceID", _nAssignInterServiceID);
                cmd.Parameters.AddWithValue("ScheduleDate", _dScheduleDate);
                cmd.Parameters.AddWithValue("Status", (short)Dictionary.ISPaidJobStatus.Assign);

                cmd.Parameters.AddWithValue("PaidJobID", _nPaidJobID);

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

                cmd.CommandText = "UPDATE t_CSDInterServicePaidJob SET Status=? WHERE PaidJobID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", (short)Dictionary.ISPaidJobStatus.Cancel);

                cmd.Parameters.AddWithValue("PaidJobID", _nPaidJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ServiceProvided()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDInterServicePaidJob SET Status=?, DeliveryDate=? WHERE PaidJobID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", (short)Dictionary.ISPaidJobStatus.ServiceProvided);
                cmd.Parameters.AddWithValue("DeliveryDate", _dDeliveryDate);

                cmd.Parameters.AddWithValue("PaidJobID", _nPaidJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Pending()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDInterServicePaidJob SET Status=?, EDDIfPending=? WHERE PaidJobID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", (short)Dictionary.ISPaidJobStatus.Pending);
                cmd.Parameters.AddWithValue("EDDIfPending", _dEDDIfPending);

                cmd.Parameters.AddWithValue("PaidJobID", _nPaidJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void ConvertJob()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDInterServicePaidJob SET ConvertedJobNO=?,Status=? WHERE PaidJobID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConvertedJobNO", _sConvertedJobNo);
                cmd.Parameters.AddWithValue("Status", (short)Dictionary.ISPaidJobStatus.ConvertToCSDJob);

                cmd.Parameters.AddWithValue("PaidJobID", _nPaidJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void WorkInProgress()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDInterServicePaidJob SET Status=? WHERE PaidJobID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", (short)Dictionary.ISPaidJobStatus.WorkInProgress);

                cmd.Parameters.AddWithValue("PaidJobID", _nPaidJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Communication()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDInterServicePaidJob SET CommunicationStatus=?,CommuUserID=?,CommuDate=?,CommuRemarks=? WHERE PaidJobID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CommunicationStatus",(short)Dictionary.InquiryCommunicationStatus.True);
                cmd.Parameters.AddWithValue("CommuUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CommuDate", DateTime.Now);
                cmd.Parameters.AddWithValue("CommuRemarks", _sCommuRemarks);

                cmd.Parameters.AddWithValue("PaidJobID", _nPaidJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
    public class PaidJobForInterServices : CollectionBase
    {
        public PaidJobForInterService this[int i]
        {
            get { return (PaidJobForInterService)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(PaidJobForInterService oPaidJobForInterService)
        {
            InnerList.Add(oPaidJobForInterService);
        }
        public void Refresh(DateTime dtFromDate, DateTime dtToDate, String txtPaidJobNo, String txtName, String txtContactNo, 
            String txtLocation, int nStatus, int nAssignInterServiceID, String txtProductCode, String txtProductName, int nIsCommu)//
        {
            dtToDate = dtToDate.Date.AddDays(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select PJ.PaidJobID, SourceID, CustomerName, PJ.Address, Location, ContactNo, PD.ProductCode ProductCode,  " +
                        "PD.ProductName ProductName,FaultID, CreateDate, U.UserName, ExpectedServiceDate, IsNull(EDDIfPending,getdate())EDDIfPending, " +
                        "EDDIfPending EDDIfPendingg, DeliveryDate DeliveryDatee, " +
                        "IsNull(DeliveryDate,getdate())DeliveryDate, RTRIM(RIGHT(CONVERT(varchar, ExpectedServiceDate, 105),11))ExpectedDateOnly, " +
                        "RTRIM(RIGHT(CONVERT(varchar, ExpectedServiceDate, 100),7))ExpectedTime, "+
                        "PJ.Status, StatusName=CASE "+
                        "When PJ.Status=0 Then 'Receive' "+
                        "When PJ.Status=1 Then 'Assign' "+
                        "When PJ.Status=2 Then 'WorkInProgress' "+
                        "When PJ.Status=3 Then 'ServiceProvided' "+
                        "When PJ.Status=4 Then 'ConvertToCSDJob' "+
                        "When PJ.Status=5 Then 'Pending' "+
                        "When PJ.Status=6 Then 'Cancel' "+
                        "END, "+
                        "IsNull(AssignInterServiceID,-1) AssignInterServiceID,  "+
                        "IsNull(ISV.Code,'--')Code, "+
                        "IsNull(ISV.Name,'Not Assign') AssignTo, IsNull(ScheduleDate,getdate())ScheduleDate, " +
                        "RTRIM(RIGHT(CONVERT(varchar, ScheduleDate, 105),11))ScheduleDateOnly, "+
                        "RTRIM(RIGHT(CONVERT(varchar, ScheduleDate, 100),7))ScheduleTime, "+
                        "ConvertedJobNo, BD.DescriptionID FaultID, BD.Description FaultName,CommunicationStatus, " +
                        "CommunStatus=CASE When CommunicationStatus=0 THEN 'False' else 'True' END, CommuUserID, CommuDate, " +
                        "IsNull(ReceiveRemarks,'')ReceiveRemarks, IsNull(PJH.Remarks,'')ScheduleRemarks,IsNull(CommuRemarks,'')CommuRemarks, "+
			            "IsNull(PJHWIP.Remarks,'')WIPRemarks, IsNull(PJHSP.Remarks,'')SPRemarks, "+
			            "IsNull(PJHConv.Remarks,'')ConvRemarks, IsNull(PJHPen.Remarks,'')PenRemarks,IsNull(PJHCan.Remarks,'')CanRemarks, "+
                        "IsNull(CHA.Code,' ')ChaCode, IsNull(Cha.Name,' ')ChaName from t_CSDInterServicePaidJob PJ  " +
                        "Left Outer JOIN TELServiceDB.dbo.InterService ISV  "+
                        "ON ISV.ID=PJ.AssignInterServiceID "+
                        "INNER JOIN v_ProductDetails PD "+
                        "ON PD.ProductID=PJ.ProductID "+
                        "INNER JOIN t_user U "+
                        "ON U.UserID=PJ.CreateUserID "+
                        "INNER JOIN TELServiceDB.dbo.BasicDescription BD "+
                        "ON BD.DescriptionID=PJ.FaultID "+
                        "Left Outer JOIN (Select PaidJobID,Status,Remarks from t_CSDInterServicePaidJobHistory Where Status=1) PJH "+
                        "ON PJ.PaidJobID=PJH.PaidJobID "+
                        "Left Outer JOIN "+
			            "(Select PaidJobID,Status,Remarks from t_CSDInterServicePaidJobHistory Where Status=2) PJHWIP "+
                        "ON PJ.PaidJobID=PJHWIP.PaidJobID "+
			            "Left Outer JOIN "+
			            "(Select PaidJobID,Status,Remarks from t_CSDInterServicePaidJobHistory Where Status=3) PJHSP "+
                        "ON PJ.PaidJobID=PJHSP.PaidJobID "+
			            "Left Outer JOIN "+
			            "(Select PaidJobID,Status,Remarks from t_CSDInterServicePaidJobHistory Where Status=4) PJHConv "+
                        "ON PJ.PaidJobID=PJHConv.PaidJobID "+
			            "Left Outer JOIN "+
			            "(Select PaidJobID,Status,Remarks from t_CSDInterServicePaidJobHistory Where Status=5) PJHPen "+
                        "ON PJ.PaidJobID=PJHPen.PaidJobID "+
			            "Left Outer JOIN "+
			            "(Select PaidJobID,Status,Remarks from t_CSDInterServicePaidJobHistory Where Status=6) PJHCan "+
                        "ON PJ.PaidJobID=PJHCan.PaidJobID "+
                        "Left Outer JOIN "+
                        "(Select ID,Code,Types,Name,Mobile,Address1 from  " +
                        "(  " +
                        "Select ID ,Code, " +
                        "Types=CASE  " +
                        "When Type=3 then 'TD'  " +
                        "When Type=2 then 'Dealer'  " +
                        "When Type=5 then 'IPB'  " +
                        "End, Name, Mobile, Address1,Type " +
                        "from TELServiceDB.dbo.Channel " +
                        "UNION All  " +
                        "Select '-1', 'CUST','N/A','Customer Himself','N/A','N/A' ,'0'  " +
                        ")f )CHA "+
                        "ON CHA.ID=PJ.SourceID "+

                        "Where CreateDate BETWEEN'" + dtFromDate + "'AND '" + dtToDate + "' AND CreateDate < '" + dtToDate + "'";


            if (txtPaidJobNo != "")
            {
                //txtComplainNo = "%" + txtComplainNo + "%";
                sSql = sSql + " AND PJ.PaidJobID ='" + txtPaidJobNo + "'";
            }
            if (nAssignInterServiceID != 0)
                sSql = sSql + " and AssignInterServiceID ='" + nAssignInterServiceID + "'";

            if (nStatus > -1)
            {
                sSql = sSql + "AND PJ.Status ='" + nStatus + "'";
            }
            if (txtLocation != "")
            {
                txtLocation = "%" + txtLocation + "%";
                sSql = sSql + " AND Location LIKE '" + txtLocation + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND ContactNo LIKE '" + txtContactNo + "'";
            }
            if (txtName != "")
            {
                txtName = "%" + txtName + "%";
                sSql = sSql + " AND CustomerName LIKE '" + txtName + "'";
            }
            if (txtProductCode != "")
            {
                txtProductCode = "%" + txtProductCode + "%";
                sSql = sSql + " AND PD.ProductCode LIKE '" + txtProductCode + "'";
            }
            if (txtProductName != "")
            {
                txtProductName = "%" + txtProductName + "%";
                sSql = sSql + " AND PD.ProductName LIKE '" + txtProductName + "'";
            }
            if (nIsCommu >= 0)
            {
                sSql = sSql + " and CommunicationStatus=?";
                cmd.Parameters.AddWithValue("CommunicationStatus", nIsCommu);
            }
            sSql = sSql + " order by PJ.PaidJobID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PaidJobForInterService oPaidJobForInterService = new PaidJobForInterService();

                    oPaidJobForInterService.PaidJobID = (int)reader["PaidJobID"];
                    //oPaidJobForInterService.SourceID = (int)reader["SourceID"];
                    oPaidJobForInterService.ChannelFromCassandra.ChannelID = (int)reader["SourceID"];
                    oPaidJobForInterService.CustomerName = (string)reader["CustomerName"];
                    oPaidJobForInterService.Address = (string)reader["Address"];
                    oPaidJobForInterService.Location = (string)reader["Location"];
                    oPaidJobForInterService.ContactNo = (string)reader["ContactNo"];
                    oPaidJobForInterService.Product.ProductCode = (string)reader["ProductCode"];
                    oPaidJobForInterService.Product.ProductName = (string)reader["ProductName"];
                    oPaidJobForInterService.ProductFaultFromCassandra.DescriptionID = (int)reader["FaultID"];
                    oPaidJobForInterService.ProductFaultFromCassandra.Description = (string)reader["FaultName"];
                    oPaidJobForInterService.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPaidJobForInterService.UserName = (string)reader["UserName"];
                    //oPaidJobForInterService.ExpectedServiceDate = Convert.ToDateTime(reader["ExpectedServiceDate"].ToString());
                    oPaidJobForInterService.Status = (int)reader["Status"];
                    oPaidJobForInterService.StatusName = (string)reader["StatusName"];
                    oPaidJobForInterService.CommunicationStatus = (int)reader["CommunicationStatus"];
                    oPaidJobForInterService.ReceiveRemarks = (Object)reader["ReceiveRemarks"];
                    oPaidJobForInterService.CommuRemarks = (Object)reader["CommuRemarks"];
                    oPaidJobForInterService.ScheduleRemarks = (Object)reader["ScheduleRemarks"];
                    oPaidJobForInterService.WIPRemarks = (Object)reader["WIPRemarks"];
                    oPaidJobForInterService.ConvRemarks = (Object)reader["ConvRemarks"];
                    oPaidJobForInterService.CanRemarks = (Object)reader["CanRemarks"];
                    oPaidJobForInterService.SPRemarks = (Object)reader["SPRemarks"];
                    oPaidJobForInterService.PenRemarks = (Object)reader["PenRemarks"];
                    oPaidJobForInterService.AssignInterServiceID = int.Parse(reader["AssignInterServiceID"].ToString());
                    oPaidJobForInterService.ISCode = (Object)reader["Code"];
                    oPaidJobForInterService.AssignTo = (Object)reader["AssignTo"];
                    oPaidJobForInterService.ChannelFromCassandra.Code = (string)reader["ChaCode"];
                    oPaidJobForInterService.ChannelFromCassandra.Name = (string)reader["ChaName"];
                    oPaidJobForInterService.ScheduleDate = (Object)reader["ScheduleDate"].ToString();
                    oPaidJobForInterService.ScheduleDateOnly = (Object)reader["ScheduleDateOnly"].ToString();
                    oPaidJobForInterService.ScheduleTime = (Object)reader["ScheduleTime"].ToString();
                    oPaidJobForInterService.ExpectedServiceDate = (Object)reader["ExpectedServiceDate"].ToString();
                    oPaidJobForInterService.ExpectedDateOnly = (Object)reader["ExpectedDateOnly"].ToString();
                    oPaidJobForInterService.ExpectedTime = (Object)reader["ExpectedTime"].ToString();
                    oPaidJobForInterService.ConvertedJobNo = (Object)reader["ConvertedJobNo"].ToString();
                    oPaidJobForInterService.EDDIfPending = (Object)reader["EDDIfPending"].ToString();
                    oPaidJobForInterService.DeliveryDate = (Object)reader["DeliveryDate"].ToString();

                    oPaidJobForInterService.EDDIfPendingg = (Object)reader["EDDIfPendingg"].ToString();
                    oPaidJobForInterService.DeliveryDatee = (Object)reader["DeliveryDatee"].ToString();

                    //oPaidJobForInterService.RefreshUser();
                    InnerList.Add(oPaidJobForInterService);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshAll(String txtPaidJobNo, String txtName, String txtContactNo,
            String txtLocation, int nStatus, int nAssignInterServiceID, String txtProductCode, String txtProductName, int nIsCommu)//
        {
            //dtToDate = dtToDate.Date.AddDays(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select PJ.PaidJobID, SourceID, CustomerName, PJ.Address, Location, ContactNo, PD.ProductCode ProductCode,  " +
                       "PD.ProductName ProductName,FaultID, CreateDate, U.UserName, ExpectedServiceDate, IsNull(EDDIfPending,getdate())EDDIfPending, " +
                        "EDDIfPending EDDIfPendingg, DeliveryDate DeliveryDatee, " +
                        "IsNull(DeliveryDate,getdate())DeliveryDate, RTRIM(RIGHT(CONVERT(varchar, ExpectedServiceDate, 105),11))ExpectedDateOnly, " +
                        "RTRIM(RIGHT(CONVERT(varchar, ExpectedServiceDate, 100),7))ExpectedTime, " +
                        "PJ.Status, StatusName=CASE " +
                        "When PJ.Status=0 Then 'Receive' " +
                        "When PJ.Status=1 Then 'Assign' " +
                        "When PJ.Status=2 Then 'WorkInProgress' " +
                        "When PJ.Status=3 Then 'ServiceProvided' " +
                        "When PJ.Status=4 Then 'ConvertToCSDJob' " +
                        "When PJ.Status=5 Then 'Pending' " +
                        "When PJ.Status=6 Then 'Cancel' " +
                        "END, " +
                        "IsNull(AssignInterServiceID,-1) AssignInterServiceID,  " +
                        "IsNull(ISV.Code,'--')Code, " +
                        "IsNull(ISV.Name,'Not Assign') AssignTo, IsNull(ScheduleDate,getdate())ScheduleDate, " +
                        "RTRIM(RIGHT(CONVERT(varchar, ScheduleDate, 105),11))ScheduleDateOnly, " +
                        "RTRIM(RIGHT(CONVERT(varchar, ScheduleDate, 100),7))ScheduleTime, " +
                        "ConvertedJobNo, BD.DescriptionID FaultID, BD.Description FaultName,CommunicationStatus, " +
                        "CommunStatus=CASE When CommunicationStatus=0 THEN 'False' else 'True' END, CommuUserID, CommuDate, " +
                        "IsNull(ReceiveRemarks,'')ReceiveRemarks, IsNull(PJH.Remarks,'')ScheduleRemarks,IsNull(CommuRemarks,'')CommuRemarks, " +
                        "IsNull(PJHWIP.Remarks,'')WIPRemarks, IsNull(PJHSP.Remarks,'')SPRemarks, " +
                        "IsNull(PJHConv.Remarks,'')ConvRemarks, IsNull(PJHPen.Remarks,'')PenRemarks,IsNull(PJHCan.Remarks,'')CanRemarks, " +
                        "IsNull(CHA.Code,' ')ChaCode, IsNull(Cha.Name,' ')ChaName from t_CSDInterServicePaidJob PJ  " +
                        "Left Outer JOIN TELServiceDB.dbo.InterService ISV  " +
                        "ON ISV.ID=PJ.AssignInterServiceID " +
                        "INNER JOIN v_ProductDetails PD " +
                        "ON PD.ProductID=PJ.ProductID " +
                        "INNER JOIN t_user U " +
                        "ON U.UserID=PJ.CreateUserID " +
                        "INNER JOIN TELServiceDB.dbo.BasicDescription BD " +
                        "ON BD.DescriptionID=PJ.FaultID " +
                        "Left Outer JOIN (Select PaidJobID,Status,Remarks from t_CSDInterServicePaidJobHistory Where Status=1) PJH " +
                        "ON PJ.PaidJobID=PJH.PaidJobID " +
                        "Left Outer JOIN " +
                        "(Select PaidJobID,Status,Remarks from t_CSDInterServicePaidJobHistory Where Status=2) PJHWIP " +
                        "ON PJ.PaidJobID=PJHWIP.PaidJobID " +
                        "Left Outer JOIN " +
                        "(Select PaidJobID,Status,Remarks from t_CSDInterServicePaidJobHistory Where Status=3) PJHSP " +
                        "ON PJ.PaidJobID=PJHSP.PaidJobID " +
                        "Left Outer JOIN " +
                        "(Select PaidJobID,Status,Remarks from t_CSDInterServicePaidJobHistory Where Status=4) PJHConv " +
                        "ON PJ.PaidJobID=PJHConv.PaidJobID " +
                        "Left Outer JOIN " +
                        "(Select PaidJobID,Status,Remarks from t_CSDInterServicePaidJobHistory Where Status=5) PJHPen " +
                        "ON PJ.PaidJobID=PJHPen.PaidJobID " +
                        "Left Outer JOIN " +
                        "(Select PaidJobID,Status,Remarks from t_CSDInterServicePaidJobHistory Where Status=6) PJHCan " +
                        "ON PJ.PaidJobID=PJHCan.PaidJobID " +
                        "Left Outer JOIN " +
                        "(Select ID,Code,Types,Name,Mobile,Address1 from  " +
                        "(  " +
                        "Select ID ,Code, " +
                        "Types=CASE  " +
                        "When Type=3 then 'TD'  " +
                        "When Type=2 then 'Dealer'  " +
                        "When Type=5 then 'IPB'  " +
                        "End, Name, Mobile, Address1,Type " +
                        "from TELServiceDB.dbo.Channel " +
                        "UNION All  " +
                        "Select '-1', 'CUST','N/A','Customer Himself','N/A','N/A' ,'0'  " +
                        ")f )CHA " +
                        "ON CHA.ID=PJ.SourceID " +
                        "Where PJ.PaidJobID <>-1";


            if (txtPaidJobNo != "")
            {
                //txtComplainNo = "%" + txtComplainNo + "%";
                sSql = sSql + " AND PJ.PaidJobID ='" + txtPaidJobNo + "'";
            }
            if (nAssignInterServiceID != 0)
                sSql = sSql + " and AssignInterServiceID ='" + nAssignInterServiceID + "'";

            if (nStatus > -1)
            {
                sSql = sSql + "AND PJ.Status ='" + nStatus + "'";
            }
            if (txtLocation != "")
            {
                txtLocation = "%" + txtLocation + "%";
                sSql = sSql + " AND Location LIKE '" + txtLocation + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND ContactNo LIKE '" + txtContactNo + "'";
            }
            if (txtName != "")
            {
                txtName = "%" + txtName + "%";
                sSql = sSql + " AND CustomerName LIKE '" + txtName + "'";
            }
            if (txtProductCode != "")
            {
                txtProductCode = "%" + txtProductCode + "%";
                sSql = sSql + " AND PD.ProductCode LIKE '" + txtProductCode + "'";
            }
            if (txtProductName != "")
            {
                txtProductName = "%" + txtProductName + "%";
                sSql = sSql + " AND PD.ProductName LIKE '" + txtProductName + "'";
            }
            if (nIsCommu >= 0)
            {
                sSql = sSql + " and CommunicationStatus=?";
                cmd.Parameters.AddWithValue("CommunicationStatus", nIsCommu);
            }
            sSql = sSql + " order by PJ.PaidJobID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PaidJobForInterService oPaidJobForInterService = new PaidJobForInterService();

                    oPaidJobForInterService.PaidJobID = (int)reader["PaidJobID"];
                    //oPaidJobForInterService.SourceID = (int)reader["SourceID"];
                    oPaidJobForInterService.ChannelFromCassandra.ChannelID = (int)reader["SourceID"];
                    oPaidJobForInterService.CustomerName = (string)reader["CustomerName"];
                    oPaidJobForInterService.Address = (string)reader["Address"];
                    oPaidJobForInterService.Location = (string)reader["Location"];
                    oPaidJobForInterService.ContactNo = (string)reader["ContactNo"];
                    oPaidJobForInterService.Product.ProductCode = (string)reader["ProductCode"];
                    oPaidJobForInterService.Product.ProductName = (string)reader["ProductName"];
                    oPaidJobForInterService.ProductFaultFromCassandra.DescriptionID = (int)reader["FaultID"];
                    oPaidJobForInterService.ProductFaultFromCassandra.Description = (string)reader["FaultName"];
                    oPaidJobForInterService.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPaidJobForInterService.UserName = (string)reader["UserName"];
                    //oPaidJobForInterService.ExpectedServiceDate = Convert.ToDateTime(reader["ExpectedServiceDate"].ToString());
                    oPaidJobForInterService.Status = (int)reader["Status"];
                    oPaidJobForInterService.StatusName = (string)reader["StatusName"];
                    oPaidJobForInterService.CommunicationStatus = (int)reader["CommunicationStatus"];
                    oPaidJobForInterService.ReceiveRemarks = (Object)reader["ReceiveRemarks"];
                    oPaidJobForInterService.CommuRemarks = (Object)reader["CommuRemarks"];
                    oPaidJobForInterService.ScheduleRemarks = (Object)reader["ScheduleRemarks"];
                    oPaidJobForInterService.WIPRemarks = (Object)reader["WIPRemarks"];
                    oPaidJobForInterService.ConvRemarks = (Object)reader["ConvRemarks"];
                    oPaidJobForInterService.CanRemarks = (Object)reader["CanRemarks"];
                    oPaidJobForInterService.SPRemarks = (Object)reader["SPRemarks"];
                    oPaidJobForInterService.PenRemarks = (Object)reader["PenRemarks"];
                    oPaidJobForInterService.AssignInterServiceID = int.Parse(reader["AssignInterServiceID"].ToString());
                    oPaidJobForInterService.ISCode = (Object)reader["Code"];
                    oPaidJobForInterService.AssignTo = (Object)reader["AssignTo"];
                    oPaidJobForInterService.ChannelFromCassandra.Code = (string)reader["ChaCode"];
                    oPaidJobForInterService.ChannelFromCassandra.Name = (string)reader["ChaName"];
                    oPaidJobForInterService.ScheduleDate = (Object)reader["ScheduleDate"].ToString();
                    oPaidJobForInterService.ScheduleDateOnly = (Object)reader["ScheduleDateOnly"].ToString();
                    oPaidJobForInterService.ScheduleTime = (Object)reader["ScheduleTime"].ToString();
                    oPaidJobForInterService.ExpectedServiceDate = (Object)reader["ExpectedServiceDate"].ToString();
                    oPaidJobForInterService.ExpectedDateOnly = (Object)reader["ExpectedDateOnly"].ToString();
                    oPaidJobForInterService.ExpectedTime = (Object)reader["ExpectedTime"].ToString();
                    oPaidJobForInterService.ConvertedJobNo = (Object)reader["ConvertedJobNo"].ToString();
                    oPaidJobForInterService.EDDIfPending = (Object)reader["EDDIfPending"].ToString();
                    oPaidJobForInterService.DeliveryDate = (Object)reader["DeliveryDate"].ToString();

                    oPaidJobForInterService.EDDIfPendingg = (Object)reader["EDDIfPendingg"].ToString();
                    oPaidJobForInterService.DeliveryDatee = (Object)reader["DeliveryDatee"].ToString();

                    //oPaidJobForInterService.RefreshUser();
                    InnerList.Add(oPaidJobForInterService);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshScheduleReport(DateTime dtFromDate, DateTime dtToDate)
        {
            dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select PJ.PaidJobID, CustomerName, PJ.Address, Location, ContactNo, PD.ProductCode ProductCode,   " +
                            "PD.ProductName ProductName,BD.Description Fault, CreateDate,     " +
                            "PJ.Status, StatusName=CASE  " +
                            "When PJ.Status=0 Then 'Receive' " +
                            "When PJ.Status=1 Then 'AGN'  " +
                            "When PJ.Status=2 Then 'WIP'  " +
                            "When PJ.Status=3 Then 'ServiceProvided'  " +
                            "When PJ.Status=4 Then 'ConvertToCSDJob'  " +
                            "When PJ.Status=5 Then 'PDG'  " +
                            "When PJ.Status=6 Then 'Cancel' " +
                            "END,   " +
                            "IsNull(ISV.Name,'Not Assign') AssignTo,  " +
                            "RTRIM(RIGHT(CONVERT(varchar, ScheduleDate, 105),11))ScheduleDateOnly,  " +
                            "RTRIM(RIGHT(CONVERT(varchar, ScheduleDate, 100),7))ScheduleTime,  " +
                            "BD.Description FaultName,  " +
                            "IsNull(ReceiveRemarks,'')ReceiveRemarks, IsNull(PJH.Remarks,'')ScheduleRemarks from t_CSDInterServicePaidJob PJ   " +
                            "Left Outer JOIN TELServiceDB.dbo.InterService ISV   " +
                            "ON ISV.ID=PJ.AssignInterServiceID  " +
                            "INNER JOIN v_ProductDetails PD  " +
                            "ON PD.ProductID=PJ.ProductID  " +
                            "INNER JOIN TELServiceDB.dbo.BasicDescription BD  " +
                            "ON BD.DescriptionID=PJ.FaultID  " +
                            "Left Outer JOIN " +
                            "(Select PaidJobID,Status,Remarks from t_CSDInterServicePaidJobHistory Where Status=1) PJH " +
                            "ON PJ.PaidJobID=PJH.PaidJobID " +
                            "Where ScheduleDate BETWEEN '" + dtFromDate + "' AND '" + dtToDate + "' AND ScheduleDate < '" + dtToDate + "' AND PJ.Status IN (1,2,5) ";

            sSql = sSql + " order by PJ.PaidJobID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PaidJobForInterService oPaidJobForInterService = new PaidJobForInterService();

                    oPaidJobForInterService.PaidJobID = (int)reader["PaidJobID"];
                    oPaidJobForInterService.CustomerName = (string)reader["CustomerName"];
                    oPaidJobForInterService.Address = (string)reader["Address"];
                    oPaidJobForInterService.Location = (string)reader["Location"];
                    oPaidJobForInterService.ContactNo = (string)reader["ContactNo"];
                    oPaidJobForInterService.ProductNames = (string)reader["ProductName"];
                    oPaidJobForInterService.ProductFaultFromCassandra.Description = (string)reader["FaultName"];
                    //oPaidJobForInterService.UserName = (string)reader["UserName"];
                    //oPaidJobForInterService.ScheduleDate=Convert.ToDateTime(reader["ScheduleDate"].ToString());
                    oPaidJobForInterService.AssignTo = (Object)reader["AssignTo"];
                    oPaidJobForInterService.ScheduleDateOnly = (Object)reader["ScheduleDateOnly"].ToString();
                    //oPaidJobForInterService.ScheduleTime = (Object)reader["ScheduleTime"].ToString();
                    oPaidJobForInterService.StatusName = (string)reader["StatusName"];
                    //oPaidJobForInterService.ReceiveRemarks = (Object)reader["ReceiveRemarks"];
                    oPaidJobForInterService.ScheduleRemarks = (Object)reader["ScheduleRemarks"];
                    oPaidJobForInterService.FaultName = (string)reader["FaultName"];

                    //oPaidJobForInterService.RefreshUser();
                    InnerList.Add(oPaidJobForInterService);
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


// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Feb 17, 2013
// Time : 06:47 PM
// Description: class for Exchange Offer Data.
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
    public class ExchangeOffer
    {
        private int _nExchangeOfferID;
        private DateTime _dContactDate;
        private string _sCodeNo;
        private int _nContactMode;
        private int _nJobLocationID;
        private string _sCustomerName;
        private string _sAddress;
        private string _sContactNo;
        private int _nAssignedVenderID;
        private DateTime _dAssignDate;
        private DateTime _dExpectedVisitDate;
        private string _sInvoiceNo;
        private int _nMoneyReceiptID;
        private int _nHappyStatus;
        private string _sRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nIsExchange;
        private int _nNotExchangeReason;
        private int _nIsSaleExecuted;
        private int _nStatus;
        private string _sStatusName;


        /// <summary>
        /// Get set property for ExchangeOfferID
        /// </summary>
        public int ExchangeOfferID
        {
            get { return _nExchangeOfferID; }
            set { _nExchangeOfferID = value; }
        }
        /// <summary>
        /// Get set property for ContactDate
        /// </summary>
        public DateTime ContactDate
        {
            get { return _dContactDate; }
            set { _dContactDate = value; }
        }
        /// <summary>
        /// Get set property for CodeNo
        /// </summary>
        public string CodeNo
        {
            get { return _sCodeNo; }
            set { _sCodeNo = value; }
        }
        /// <summary>
        /// Get set property for ContactMode
        /// </summary>
        public int ContactMode
        {
            get { return _nContactMode; }
            set { _nContactMode = value; }
        }
        /// <summary>
        /// Get set property for JobLocationID
        /// </summary>
        public int JobLocationID
        {
            get { return _nJobLocationID; }
            set { _nJobLocationID = value; }
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
        /// Get set property for ContactNo
        /// </summary>
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for AssignedVenderID
        /// </summary>
        public int AssignedVenderID
        {
            get { return _nAssignedVenderID; }
            set { _nAssignedVenderID = value; }
        }
        /// <summary>
        /// Get set property for AssignDate
        /// </summary>
        public DateTime AssignDate
        {
            get { return _dAssignDate; }
            set { _dAssignDate = value; }
        }
        /// <summary>
        /// Get set property for ExpectedVisitDate
        /// </summary>
        public DateTime ExpectedVisitDate
        {
            get { return _dExpectedVisitDate; }
            set { _dExpectedVisitDate = value; }
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
        /// Get set property for MoneyReceiptID
        /// </summary>
        public int MoneyReceiptID
        {
            get { return _nMoneyReceiptID; }
            set { _nMoneyReceiptID = value; }
        }
        /// <summary>
        /// Get set property for HappyStatus
        /// </summary>
        public int HappyStatus
        {
            get { return _nHappyStatus; }
            set { _nHappyStatus = value; }
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
        /// Get set property for IsExchange
        /// </summary>
        public int IsExchange
        {
            get { return _nIsExchange; }
            set { _nIsExchange = value; }
        }
        /// <summary>
        /// Get set property for NotExchangeReason
        /// </summary>
        public int NotExchangeReason
        {
            get { return _nNotExchangeReason; }
            set { _nNotExchangeReason = value; }
        }
        /// <summary>
        /// Get set property for IsSaleExecuted
        /// </summary>
        public int IsSaleExecuted
        {
            get { return _nIsSaleExecuted; }
            set { _nIsSaleExecuted = value; }
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
        /// Get set property for StatusName
        /// </summary>
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value; }
        }

        public void Add()
        {
            int nMaxExchangeOfferID = 0;
            int nCount = 0;
            DateTime Todate = DateTime.Today.Date;
            DateTime Fromdate = Todate.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT MAX([ExchangeOfferID]) FROM t_ExchangeOffer";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxExchangeOfferID = 1;
                }
                else
                {
                    nMaxExchangeOfferID = Convert.ToInt32(maxID) + 1;
                }
                _nExchangeOfferID = nMaxExchangeOfferID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "Select A.ECode From ( Select  Max(ExchangeOfferID)as EOID,Right(CodeNo,3)ECode " +
                        "from t_ExchangeOffer Group by CodeNo) A INNER JOIN (Select Max(ExchangeOfferID)as EOID from " +
                        "t_ExchangeOffer Where JobLocationID=? AND CreateDate Between ? AND ? AND CreateDate <?)B ON A.EOID=B.EOID ";

                cmd.Parameters.AddWithValue("JobLocationID", _nJobLocationID);
                cmd.Parameters.AddWithValue("CreateDate", Todate);
                cmd.Parameters.AddWithValue("CreateDate", Fromdate);
                cmd.Parameters.AddWithValue("CreateDate", Fromdate);

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                object ID = cmd.ExecuteScalar();

                nCount = Convert.ToInt32(ID) + 1;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "Select Right(JobLocationCode,4) as LocationCode " +
                        "from t_JobLocation Where JobLocationID=?";
                cmd.Parameters.AddWithValue("JobLocationID", _nJobLocationID);

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                object LocationCode = cmd.ExecuteScalar();


                _sCodeNo = "E" + LocationCode + Convert.ToInt32(DateTime.Today.Date.ToString("yy") + DateTime.Today.Month.ToString("00") + DateTime.Today.Day.ToString("00") + nCount.ToString("000"));


                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_ExchangeOffer (ExchangeOfferID,ContactDate,CodeNo, ContactMode,JobLocationID,CustomerName," +
                        "Address,ContactNo,Remarks,CreateUserID,CreateDate,IsExchange,NotExchangeReason,IsSaleExecuted,Status) " +
                        "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ExchangeOfferID", _nExchangeOfferID);
                cmd.Parameters.AddWithValue("ContactDate", _dContactDate);
                cmd.Parameters.AddWithValue("CodeNo", _sCodeNo);
                cmd.Parameters.AddWithValue("ContactMode", _nContactMode);
                cmd.Parameters.AddWithValue("JobLocationID", _nJobLocationID);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("IsExchange", (int)Dictionary.ExOIsExchange.NA);
                cmd.Parameters.AddWithValue("NotExchangeReason", (int)Dictionary.ExONotExchangeReason.NA);
                cmd.Parameters.AddWithValue("IsSaleExecuted", (int)Dictionary.ExOIsSaleExecuted.NA);

                cmd.Parameters.AddWithValue("Status", (int)Dictionary.ExchangeOfferStatus.Create);

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

                cmd.CommandText = "UPDATE t_ExchangeOffer SET ContactDate=?, ContactMode=?,JobLocationID=?,CustomerName=?,Address=?,ContactNo=?, " +
                                    "Remarks=? Where ExchangeOfferID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ContactDate", _dContactDate);
                cmd.Parameters.AddWithValue("ContactMode", _nContactMode);
                cmd.Parameters.AddWithValue("JobLocationID", _nJobLocationID);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);


                cmd.Parameters.AddWithValue("ExchangeOfferID", _nExchangeOfferID);

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

            try
            {

                cmd.CommandText = "UPDATE t_ExchangeOffer SET AssignedVenderID=?,AssignDate=?,ExpectedVisitDate=?,Status=? Where ExchangeOfferID=?";

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("AssignedVenderID", _nAssignedVenderID);
                cmd.Parameters.AddWithValue("AssignDate", _dAssignDate);
                cmd.Parameters.AddWithValue("ExpectedVisitDate", _dExpectedVisitDate);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.ExchangeOfferStatus.Assign);

                cmd.Parameters.AddWithValue("ExchangeOfferID", _nExchangeOfferID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Exchange()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_ExchangeOffer SET MoneyReceiptID=?, IsExchange=?, IsSaleExecuted=?,Status=? Where ExchangeOfferID=?";

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("MoneyReceiptID", _nMoneyReceiptID);
                cmd.Parameters.AddWithValue("IsExchange", _nIsExchange);
                cmd.Parameters.AddWithValue("IsSaleExecuted", (int)Dictionary.ExOIsSaleExecuted.No);
                //cmd.Parameters.AddWithValue("Status", (int)Dictionary.ExchangeOfferStatus.Exchanged);

                cmd.Parameters.AddWithValue("ExchangeOfferID", _nExchangeOfferID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void NotExchange()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_ExchangeOffer SET IsExchange=?, NotExchangeReason=?, Status=? Where ExchangeOfferID=?";

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("IsExchange", _nIsExchange);
                cmd.Parameters.AddWithValue("NotExchangeReason", _nNotExchangeReason);
                //cmd.Parameters.AddWithValue("Status", (int)Dictionary.ExchangeOfferStatus.NotExchange);

                cmd.Parameters.AddWithValue("ExchangeOfferID", _nExchangeOfferID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void SaleExecuted()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_ExchangeOffer SET InvoiceNo=?, IsSaleExecuted=?, Status=? Where ExchangeOfferID=?";

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("IsSaleExecuted", (int)Dictionary.ExOIsSaleExecuted.Yes);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.ExchangeOfferStatus.SalesExecuted);

                cmd.Parameters.AddWithValue("ExchangeOfferID", _nExchangeOfferID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void HappyCall()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_ExchangeOffer SET HappyStatus=?, Status=? Where ExchangeOfferID=?";

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("HappyStatus", _nHappyStatus);
                //cmd.Parameters.AddWithValue("Status", (int)Dictionary.ExchangeOfferStatus.HappyCall);

                cmd.Parameters.AddWithValue("ExchangeOfferID", _nExchangeOfferID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void StatusChange()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_ExchangeOffer SET Status=? Where ExchangeOfferID=?";

                cmd.CommandType = CommandType.Text;



                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("ExchangeOfferID", _nExchangeOfferID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT ExchangeOfferID,CodeNo,CustomerName,Address,ContactNo, StatusName=CASE When Status = 0 then 'Create' When Status = 1 then 'Assign' " +
                            "When Status = 2 then 'Suspend' When Status = 3 then 'Exchanged' When Status = 4 then 'NotExchange' " +
                            "When Status = 5 then 'SalesExecuted' When Status = 6 then 'Cancel' else 'HappyCall' end, Status FROM t_ExchangeOffer where CodeNo =?";
                cmd.Parameters.AddWithValue("CodeNo", _sCodeNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nExchangeOfferID = (int)reader["ExchangeOfferID"];
                    _sCodeNo = (string)reader["CodeNo"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _sAddress = (string)reader["Address"];
                    _sContactNo = (string)reader["ContactNo"];
                    _sStatusName = (string)reader["StatusName"];
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
        public void GetAssignVenderByEXOID(int nExchangeOfferID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT AssignedVenderID FROM t_ExchangeOffer where ExchangeOfferID = ?";

                cmd.Parameters.AddWithValue("ExchangeOfferID", nExchangeOfferID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nAssignedVenderID = (int)reader["AssignedVenderID"];

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
    public class ExchangeOffers : CollectionBase
    {
        public ExchangeOffer this[int i]
        {
            get { return (ExchangeOffer)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ExchangeOffer oExchangeOffer)
        {
            InnerList.Add(oExchangeOffer);
        }
        public int GetIndex(int nJobLocationID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].JobLocationID == nJobLocationID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh(DateTime dtFromDate, DateTime dtToDate, int nJobLocationID, string CodeNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dtToDate = dtToDate.AddDays(1);
            string sSql = "Select ExchangeOfferID,ContactDate,CodeNo,ContactMode,JobLocationID,CustomerName,Address,ContactNo, " +
                            "IsNull(AssignedVenderID,0) as AssignedVenderID, CreateUserID, CreateDate,IsExchange, StatusName=CASE When Status = 0 then 'Create' When Status = 1 then 'Assign' " +
                            "When Status = 2 then 'Suspend' When Status = 3 then 'Exchanged' When Status = 4 then 'NotExchange' " +
                            "When Status = 5 then 'SalesExecuted' When Status = 6 then 'Cancel' else 'HappyCall' end, Status from t_ExchangeOffer " +
                            "Where CreateDate Between ? and ? and CreateDate < ? and JobLocationID=? ";

            cmd.Parameters.AddWithValue("CreateDate", dtFromDate);
            cmd.Parameters.AddWithValue("CreateDate", dtToDate);
            cmd.Parameters.AddWithValue("CreateDate", dtToDate);
            cmd.Parameters.AddWithValue("JobLocationID", nJobLocationID);

            if (CodeNo != "")
            {
                CodeNo = "%" + CodeNo + "%";
                sSql = sSql + " and CodeNo LIKE'" + CodeNo + "'";
            }


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOffer oEO = new ExchangeOffer();

                    oEO.ExchangeOfferID = (int)reader["ExchangeOfferID"];
                    oEO.ContactDate = Convert.ToDateTime(reader["ContactDate"].ToString());
                    oEO.CodeNo = (string)reader["CodeNo"];
                    oEO.ContactMode = (int)reader["ContactMode"];
                    oEO.JobLocationID = (int)reader["JobLocationID"];
                    oEO.CustomerName = (string)reader["CustomerName"];
                    oEO.Address = (string)reader["Address"];
                    oEO.ContactNo = (string)reader["ContactNo"];
                    oEO.AssignedVenderID = (int)reader["AssignedVenderID"];
                    //oEO.AssignDate = Convert.ToDateTime(reader["AssignDate"].ToString());
                    //oEO.ExpectedVisitDate = Convert.ToDateTime(reader["ExpectedVisitDate"].ToString());
                    //oEO.InvoiceNo = (string)reader["InvoiceNo"];
                    //oEO.MoneyReceiptID = (int)reader["MoneyReceiptNo"];
                    //oEO.HappyStatus = (int)reader["HappyStatus"];
                    //oEO.Remarks = (string)reader["Remarks"];
                    oEO.CreateUserID = (int)reader["CreateUserID"];
                    oEO.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oEO.IsExchange = (int)reader["IsExchange"];
                    oEO.StatusName = (string)reader["StatusName"];
                    oEO.Status = (int)reader["Status"];

                    InnerList.Add(oEO);
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
    public class ExchangeOfferDetail
    {
        private int _nExchangeOfferID;
        private int _nType;
        private int _nDetailID;
        private int _nQuantity;
        private string _sProductSize;
        private string _sBrandName;
        private int _nHaveRemortCtrl;
        private int _nProductCondition;


        /// <summary>
        /// Get set property for ExchangeOfferID
        /// </summary>
        public int ExchangeOfferID
        {
            get { return _nExchangeOfferID; }
            set { _nExchangeOfferID = value; }
        }
        /// <summary>
        /// Get set property for Type
        /// </summary>
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }
        /// <summary>
        /// Get set property for DetailID
        /// </summary>
        public int DetailID
        {
            get { return _nDetailID; }
            set { _nDetailID = value; }
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
        /// Get set property for ProductSize
        /// </summary>
        public string ProductSize
        {
            get { return _sProductSize; }
            set { _sProductSize = value.Trim(); }
        }
        /// <summary>
        /// Get set property for BrandName
        /// </summary>
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for HaveRemortCtrl
        /// </summary>
        public int HaveRemortCtrl
        {
            get { return _nHaveRemortCtrl; }
            set { _nHaveRemortCtrl = value; }
        }
        /// <summary>
        /// Get set property for ProductCondition
        /// </summary>
        public int ProductCondition
        {
            get { return _nProductCondition; }
            set { _nProductCondition = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_ExchangeOfferDetail(ExchangeOfferID,Type,DetailID,Quantity, " +
                        "ProductSize,BrandName,HaveRemortCtrl,ProductCondition) VALUES(?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ExchangeOfferID", _nExchangeOfferID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("DetailID", _nDetailID);
                cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                cmd.Parameters.AddWithValue("ProductSize", _sProductSize);
                cmd.Parameters.AddWithValue("BrandName", _sBrandName);
                cmd.Parameters.AddWithValue("HaveRemortCtrl", _nHaveRemortCtrl);
                cmd.Parameters.AddWithValue("ProductCondition", _nProductCondition);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckExODetail()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_ExchangeOfferDetail where ExchangeOfferID=? AND DetailID=? AND Type=?";
            cmd.Parameters.AddWithValue("ExchangeOfferID", _nExchangeOfferID);
            cmd.Parameters.AddWithValue("DetailID", _nDetailID);
            cmd.Parameters.AddWithValue("Type", _nType);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nQuantity = (int)reader["Quantity"];
                    _sBrandName = (string)reader["BrandName"];
                    _sProductSize = (string)reader["ProductSize"];
                    _nHaveRemortCtrl = (int)reader["HaveRemortCtrl"];
                    _nProductCondition = (int)reader["ProductCondition"];
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
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_ExchangeOfferDetail WHERE [ExchangeOfferID]=? AND [Type]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ExchangeOfferID", _nExchangeOfferID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
    public class ExchangeOfferDetails : CollectionBase
    {
        public ExchangeOfferDetail this[int i]
        {
            get { return (ExchangeOfferDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ExchangeOfferDetail oExchangeOffer)
        {
            InnerList.Add(oExchangeOffer);
        }

        public void Refresh(int nExchangeOfferID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_ExchangeOfferDetail Where ExchangeOfferID=?";

            cmd.Parameters.AddWithValue("ExchangeOfferID", nExchangeOfferID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferDetail oEOD = new ExchangeOfferDetail();

                    oEOD.ExchangeOfferID = (int)reader["ExchangeOfferID"];
                    oEOD.Type = (int)reader["Type"];
                    oEOD.DetailID = (int)reader["DetailID"];
                    oEOD.Quantity = (int)reader["Quantity"];
                    oEOD.ProductSize = (string)reader["ProductSize"];
                    oEOD.BrandName = (string)reader["BrandName"];
                    oEOD.HaveRemortCtrl = (int)reader["HaveRemortCtrl"];
                    oEOD.ProductCondition = (int)reader["ProductCondition"];

                    InnerList.Add(oEOD);
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
    public class ExchangeOfferHist
    {
        private int _nExchOfferHistID;
        private int _nExchangeOfferID;
        private int _nStatus;
        private string _sRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;

        /// <summary>
        /// Get set property for ExchOfferHistID
        /// </summary>
        public int ExchOfferHistID
        {
            get { return _nExchOfferHistID; }
            set { _nExchOfferHistID = value; }
        }
        /// <summary>
        /// Get set property for ExchangeOfferID
        /// </summary>
        public int ExchangeOfferID
        {
            get { return _nExchangeOfferID; }
            set { _nExchangeOfferID = value; }
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
        public string Remarks
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

        public void Add()
        {
            int nMaxExchOfferHistID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "SELECT MAX([ExchOfferHistID]) FROM t_ExchangeOfferHist";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxExchOfferHistID = 1;
                }
                else
                {
                    nMaxExchOfferHistID = Convert.ToInt32(maxID) + 1;
                }
                _nExchOfferHistID = nMaxExchOfferHistID;

                sSql = "INSERT INTO t_ExchangeOfferHist (ExchOfferHistID,ExchangeOfferID,Status,Remarks,CreateUserID,CreateDate) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ExchOfferHistID", _nExchOfferHistID);
                cmd.Parameters.AddWithValue("ExchangeOfferID", _nExchangeOfferID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);

                cmd.ExecuteNonQuery();

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateRemarks()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_ExchangeOfferHist SET Remarks=? Where ExchangeOfferID=? AND Status=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("ExchangeOfferID", _nExchangeOfferID);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
    public class ExchangeOfferHists : CollectionBase
    {
        public ExchangeOfferHist this[int i]
        {
            get { return (ExchangeOfferHist)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ExchangeOfferHist oExchangeOffer)
        {
            InnerList.Add(oExchangeOffer);
        }

        public void Refresh(int nExchangeOfferID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_ExchangeOfferHist Where ExchangeOfferID=?";

            cmd.Parameters.AddWithValue("ExchangeOfferID", nExchangeOfferID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ExchangeOfferHist oEOH = new ExchangeOfferHist();

                    oEOH.ExchOfferHistID = (int)reader["ExchOfferHistID"];
                    oEOH.ExchangeOfferID = (int)reader["ExchangeOfferID"];
                    oEOH.Status = (int)reader["Status"];
                    oEOH.Remarks = (string)reader["Remarks"];

                    InnerList.Add(oEOH);
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
    public class ExchangeOfferVender
    {
        private int _nVenderID;
        private string _sCode;
        private string _sName;
        private string _sAddress;
        private string _sContactNo;
        private string _sContactPerson;
        private string _sRemarks;
        private int _nIsActive;
        private int _nCreateUserID;
        private DateTime _dCreateDate;

        private double _SecurityDeposit;
        private double _PaymentReceive;
        private double _MoneyReceiptAmt;
        private double _Balance;
        private string _sActiveStatus;
        private int _nParentCustomerID;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private string _sParentCustomerName;
        private int _nWarehouseID;
        public int _nParentVenderID;
        private string _sParentVenderName;
        private double _MotherAcctBalance;
        private double _ChildAcctBalance;



        public double MotherAcctBalance
        {
            get { return _MotherAcctBalance; }
            set { _MotherAcctBalance = value; }
        }


        public double ChildAcctBalance
        {
            get { return _ChildAcctBalance; }
            set { _ChildAcctBalance = value; }
        }
        // <summary>
        // Get set property for ParentVenderID
        // </summary>
        public int ParentVenderID
        {
            get { return _nParentVenderID; }
            set { _nParentVenderID = value; }
        }

        /// <summary>
        /// Get set property for ParentVenderName
        /// </summary>
        public string ParentVenderName
        {
            get { return _sParentVenderName; }
            set { _sParentVenderName = value.Trim(); }
        }


        /// <summary>
        /// Get set property for WarehouseID
        /// </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        /// <summary>
        /// Get set property for ParentCustomerName
        /// </summary>
        public string ParentCustomerName
        {
            get { return _sParentCustomerName; }
            set { _sParentCustomerName = value.Trim(); }
        }


        /// <summary>
        /// Get set property for ParentCustomerID
        /// </summary>
        public int ParentCustomerID
        {
            get { return _nParentCustomerID; }
            set { _nParentCustomerID = value; }
        }

        /// <summary>
        /// Get set property for VenderID
        /// </summary>
        public int VenderID
        {
            get { return _nVenderID; }
            set { _nVenderID = value; }
        }
        /// <summary>
        /// Get set property for Code
        /// </summary>
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value.Trim(); }
        }
        /// <summary>
        /// Get set property for Name
        /// </summary>
        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
        }
        /// <summary>
        /// Get set property for Address
        /// </summary>
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }
        /// <summary>
        /// Get set property for ContactNo
        /// </summary>
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value; }
        }
        /// <summary>
        /// Get set property for ContactPerson
        /// </summary>
        public string ContactPerson
        {
            get { return _sContactPerson; }
            set { _sContactPerson = value; }
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
        /// Get set property for IsActive
        /// </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
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
        /// Get set property for CreateUserID
        /// </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }
        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        public double SecurityDeposit
        {
            get { return _SecurityDeposit; }
            set { _SecurityDeposit = value; }
        }
        public double PaymentReceive
        {
            get { return _PaymentReceive; }
            set { _PaymentReceive = value; }
        }
        public double MoneyReceiptAmt
        {
            get { return _MoneyReceiptAmt; }
            set { _MoneyReceiptAmt = value; }
        }
        public double Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
        public string ActiveStatus
        {
            get { return _sActiveStatus; }
            set { _sActiveStatus = value; }
        }

        public void Add()
        {
            int nMaxVenderID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([VenderID]) FROM t_ExchangeOfferVender";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxVenderID = 1;
                }
                else
                {
                    nMaxVenderID = Convert.ToInt32(maxID) + 1;
                }
                _nVenderID = nMaxVenderID;

                sSql = "INSERT INTO t_ExchangeOfferVender(VenderID,Code,Name,Address,ContactNo,ContactPerson,Remarks,IsActive,CreateUserID,CreateDate) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VenderID", _nVenderID);
                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);

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

                cmd.CommandText = "UPDATE t_ExchangeOfferVender SET Name=?, Address=?, ContactNo=?, ContactPerson=?, Remarks=?, IsActive=? " +
                                    "Where VenderID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.Parameters.AddWithValue("VenderID", _nVenderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckVenderCode()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_ExchangeOfferVender where Code=?";
            cmd.Parameters.AddWithValue("Code", _sCode);

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
            if (nCount == 0)
                return true;
            else return false;
        }
        public void Insert()
        {
            int nMaxVenderID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([VenderID]) FROM t_ExchangeOfferVender";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxVenderID = 1;
                }
                else
                {
                    nMaxVenderID = Convert.ToInt32(maxID) + 1;
                }
                _nVenderID = nMaxVenderID;

                string sCode = "";
                DateTime dToday = DateTime.Today;
                sCode = "20" + _nVenderID.ToString("0000");
                _sCode = sCode;

                sSql = "INSERT INTO t_ExchangeOfferVender(VenderID,Code,Name,ParentVenderID,ParentCustomerID,Balance,IsActive,Remarks,CreateUserID,CreateDate,UpdateUserID,UpdateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VenderID", _nVenderID);
                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("ParentVenderID", _nParentVenderID);
                cmd.Parameters.AddWithValue("ParentCustomerID", _nParentCustomerID);
                cmd.Parameters.AddWithValue("Balance", _Balance);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);                
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Update()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_ExchangeOfferVender SET Name=?, Remarks=?, IsActive=?, UpdateDate=?, UpdateUserID=?, " +
                                    "ParentVenderID = ?, ParentCustomerID = ? Where VenderID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Name", _sName);
                if (_sRemarks != null)
                {
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Remarks", null);
                }
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("ParentVenderID", _nParentVenderID);
                cmd.Parameters.AddWithValue("ParentCustomerID", _nParentCustomerID);

                cmd.Parameters.AddWithValue("VenderID", _nVenderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetParentVenderID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT ParentVenderID FROM t_ExchangeOfferVender where VenderID = ?";

                cmd.Parameters.AddWithValue("VenderID", _nVenderID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nParentVenderID = (int)reader["ParentVenderID"];

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateChildBalanceByType(int _nType)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                if (_nType == (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Parent_To_Child)
                {
                    cmd.CommandText = "UPDATE t_ExchangeOfferVender SET Balance = Balance + ? Where VenderID=?";
                }
                else if (_nType == (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Child_To_Parent)
                {
                    cmd.CommandText = "UPDATE t_ExchangeOfferVender SET Balance = Balance - ? Where VenderID=?";
                }
                else if (_nType == (int)Dictionary.ExchangeOfferDepositType.Money_Receipt)
                {
                    cmd.CommandText = "UPDATE t_ExchangeOfferVender SET Balance = Balance - ? Where VenderID=?";
                }

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Balance", _Balance);
                cmd.Parameters.AddWithValue("VenderID", _nVenderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetWHID(int nJobID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            
            try
            {
                cmd.CommandText = " Select WarehouseID From t_ExchangeOfferJob a, t_ExchangeOfferVender b,t_Showroom c  " +
                                  " where a.AssignedVenderID=b.VenderID and b.ParentCustomerID=c.CustomerID and JobID= " + nJobID + " ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nWarehouseID = Convert.ToInt32(reader["WarehouseID"].ToString());
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
    public class ExchangeOfferVenders : CollectionBase
    {
        public ExchangeOfferVender this[int i]
        {
            get { return (ExchangeOfferVender)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ExchangeOfferVender oExchangeOfferVender)
        {
            InnerList.Add(oExchangeOfferVender);
        }
        public int GetIndex(int nVenderID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].VenderID == nVenderID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh(String txtVenderNo, String txtVenderName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT EOV.VenderID,Code,Name,Address,contactNo,ContactPerson,Remarks, IsActive, ActiveStatus = CASE " +
                            "When IsActive = 1 then 'True' else 'False' end, CreateUserID,CreateDate,IsNull(SecurityDeposit,0) as SecurityDeposit, " +
                            "IsNull(PaymentReceive,0) as PaymentReceive, IsNull(MoneyReceiptAmt,0) as MoneyReceiptAmt,IsNull(Balance,0) as " +
                            "Balance FROM t_ExchangeOfferVender EOV Left OUter JOIN t_ExchangeOfferVenderAccount EOVA ON EOV.VenderID=EOVA.VenderID Where EOV.VenderID <>0";

            if (txtVenderNo != "")
            {
                txtVenderNo = "%" + txtVenderNo + "%";
                sSql = sSql + " AND Code LIKE '" + txtVenderNo + "'";
            }
            if (txtVenderName != "")
            {
                txtVenderName = "%" + txtVenderName + "%";
                sSql = sSql + " AND Name LIKE '" + txtVenderName + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferVender oExchangeOfferVender = new ExchangeOfferVender();

                    oExchangeOfferVender.VenderID = (int)reader["VenderID"];
                    oExchangeOfferVender.Code = (string)reader["Code"];
                    oExchangeOfferVender.Name = (string)reader["Name"];
                    oExchangeOfferVender.Address = (string)reader["Address"];
                    oExchangeOfferVender.ContactNo = (string)reader["ContactNo"];
                    oExchangeOfferVender.ContactPerson = (string)reader["ContactPerson"];
                    oExchangeOfferVender.Remarks = (string)reader["Remarks"];
                    oExchangeOfferVender.IsActive = (int)reader["IsActive"];
                    oExchangeOfferVender.ActiveStatus = (string)reader["ActiveStatus"];
                    oExchangeOfferVender.SecurityDeposit = Convert.ToDouble(reader["SecurityDeposit"].ToString());
                    oExchangeOfferVender.PaymentReceive = Convert.ToDouble(reader["PaymentReceive"].ToString());
                    oExchangeOfferVender.MoneyReceiptAmt = Convert.ToDouble(reader["MoneyReceiptAmt"].ToString());
                    oExchangeOfferVender.Balance = Convert.ToDouble(reader["Balance"].ToString());

                    InnerList.Add(oExchangeOfferVender);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetVenders(string sVenderCode, string sVenderName, string sContactNo, string sParentCustomerName, string sParentVenderName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select VenderID,Code,Name,a.ParentVenderID,ParentVenderName,  "+
                        " a.ParentCustomerID,CustomerName,Balance,a.IsActive,a.Remarks,a.CreateDate,a.CreateUserID  " +
                        " From t_ExchangeOfferVender a,t_ExchangeOfferVenderParent b,t_Customer c  " +
                        " where a.ParentVenderID=b.ParentVenderID and a.ParentCustomerID=c.CustomerID";

            if (sVenderCode != "")
            {
                sVenderCode = "%" + sVenderCode + "%";
                sSql = sSql + " AND Code LIKE '" + sVenderCode + "'";
            }
            if (sVenderName != "")
            {
                sVenderName = "%" + sVenderName + "%";
                sSql = sSql + " AND Name LIKE '" + sVenderName + "'";
            }
            if (sContactNo != "")
            {
                sContactNo = "%" + sContactNo + "%";
                sSql = sSql + " AND ContactNo LIKE '" + sContactNo + "'";
            }
            if (sParentCustomerName != "")
            {
                sParentCustomerName = "%" + sParentCustomerName + "%";
                sSql = sSql + " AND CustomerName LIKE '" + sParentCustomerName + "'";
            }
            if (sParentVenderName != "")
            {
                sParentVenderName = "%" + sParentVenderName + "%";
                sSql = sSql + " AND ParentVenderName LIKE '" + sParentVenderName + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferVender oExchangeOfferVender = new ExchangeOfferVender();

                    oExchangeOfferVender.VenderID = (int)reader["VenderID"];
                    oExchangeOfferVender.Code = (string)reader["Code"];
                    oExchangeOfferVender.Name = (string)reader["Name"];
                    oExchangeOfferVender.ParentVenderID = (int)reader["ParentVenderID"];
                    oExchangeOfferVender.ParentVenderName = (string)reader["ParentVenderName"];
                    oExchangeOfferVender.ParentCustomerID = (int)reader["ParentCustomerID"];
                    oExchangeOfferVender.ParentCustomerName = (string)reader["CustomerName"];
                    oExchangeOfferVender.Balance = (double)reader["Balance"];
                    oExchangeOfferVender.IsActive = (int)reader["IsActive"];

                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oExchangeOfferVender.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oExchangeOfferVender.Remarks = "";
                    }                    
                    oExchangeOfferVender.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oExchangeOfferVender.CreateUserID = (int)reader["CreateUserID"];


                    InnerList.Add(oExchangeOfferVender);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshforCombo()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * FROM t_ExchangeOfferVender a,t_Showroom b "+
                          "Where a.ParentCustomerID=b.CustomerID and a.IsActive=1";

          

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferVender oExchangeOfferVender = new ExchangeOfferVender();

                    oExchangeOfferVender.VenderID = (int)reader["VenderID"];
                    oExchangeOfferVender.Code = (string)reader["Code"];
                    oExchangeOfferVender.Name = (string)reader["Name"];
                    oExchangeOfferVender.ParentCustomerID = (int)reader["ParentCustomerID"];
                    oExchangeOfferVender.WarehouseID = (int)reader["WarehouseID"];
                    oExchangeOfferVender.ParentVenderID = (int)reader["ParentVenderID"];
                    oExchangeOfferVender.Balance = (double)reader["Balance"];

                    InnerList.Add(oExchangeOfferVender);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshforComboByID(int nParentVenderID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.ParentVenderID,ParentVenderName,VenderID,Code,Name,WarehouseID,  "+
                        " ParentCustomerID,Balance as ChildAcctBalance,MotherAcctBalance FROM t_ExchangeOfferVender a,t_Showroom b,t_ExchangeOfferVenderParent c  " +
                        " Where a.ParentCustomerID=b.CustomerID and a.ParentVenderID=c.ParentVenderID  " +
                        " and a.IsActive=1 and c.ParentVenderID=" + nParentVenderID + "";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferVender oExchangeOfferVender = new ExchangeOfferVender();

                    oExchangeOfferVender.ParentVenderID = (int)reader["ParentVenderID"];
                    oExchangeOfferVender.ParentVenderName = (string)reader["ParentVenderName"];
                    oExchangeOfferVender.VenderID = (int)reader["VenderID"];
                    oExchangeOfferVender.Code = (string)reader["Code"];
                    oExchangeOfferVender.Name = (string)reader["Name"];                    
                    oExchangeOfferVender.WarehouseID = (int)reader["WarehouseID"];
                    oExchangeOfferVender.ParentCustomerID = (int)reader["ParentCustomerID"];
                    oExchangeOfferVender.MotherAcctBalance = (double)reader["MotherAcctBalance"];
                    oExchangeOfferVender.ChildAcctBalance = (double)reader["ChildAcctBalance"];

                    InnerList.Add(oExchangeOfferVender);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshforComboPOS()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * FROM t_ExchangeOfferVender a,t_Showroom b " +
                          "Where a.ParentCustomerID=b.CustomerID and a.IsActive=1";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferVender oExchangeOfferVender = new ExchangeOfferVender();

                    oExchangeOfferVender.VenderID = (int)reader["VenderID"];
                    oExchangeOfferVender.Code = (string)reader["Code"];
                    oExchangeOfferVender.Name = (string)reader["Name"];
                    oExchangeOfferVender.ParentCustomerID = (int)reader["ParentCustomerID"];
                    oExchangeOfferVender.WarehouseID = (int)reader["WarehouseID"];
                    oExchangeOfferVender.Balance = (double)reader["Balance"];

                    InnerList.Add(oExchangeOfferVender);
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
    public class ExchangeOfferVenderDeposit
    {
        private int _nVenderTranID;
        private int _nVenderID;
        private double _Amount;
        private int _nDepositType;
        private string _sInstrumentNo;
        private int _nInstrumentType;
        private int _nBankID;
        private string _sBranchName;
        private string _sRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;


        /// <summary>
        /// Get set property for VenderTranID
        /// </summary>
        public int VenderTranID
        {
            get { return _nVenderTranID; }
            set { _nVenderTranID = value; }
        }
        /// <summary>
        /// Get set property for VenderID
        /// </summary>
        public int VenderID
        {
            get { return _nVenderID; }
            set { _nVenderID = value; }
        }
        /// <summary>
        /// Get set property for _Amount
        /// </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        /// <summary>
        /// Get set property for DepositType
        /// </summary>
        public int DepositType
        {
            get { return _nDepositType; }
            set { _nDepositType = value; }
        }
        /// <summary>
        /// Get set property for InstrumentNo
        /// </summary>
        public string InstrumentNo
        {
            get { return _sInstrumentNo; }
            set { _sInstrumentNo = value; }
        }
        /// <summary>
        /// Get set property for InstrumentType
        /// </summary>
        public int InstrumentType
        {
            get { return _nInstrumentType; }
            set { _nInstrumentType = value; }
        }
        /// <summary>
        /// Get set property for BankID
        /// </summary>
        public int BankID
        {
            get { return _nBankID; }
            set { _nBankID = value; }
        }
        /// <summary>
        /// Get set property for BranchName
        /// </summary>
        public string BranchName
        {
            get { return _sBranchName; }
            set { _sBranchName = value; }
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

        public void Add()
        {
            int nMaxVenderTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([VenderTranID]) FROM t_ExchangeOfferVenderDeposit";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxVenderTranID = 1;
                }
                else
                {
                    nMaxVenderTranID = Convert.ToInt32(maxID) + 1;
                }
                _nVenderTranID = nMaxVenderTranID;

                sSql = "INSERT INTO t_ExchangeOfferVenderDeposit(VenderTranID,VenderID,Amount,DepositType,InstrumentNo, InstrumentType, " +
                        "BankID, BranchName,Remarks,CreateUserID,CreateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VenderTranID", _nVenderTranID);
                cmd.Parameters.AddWithValue("VenderID", _nVenderID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("DepositType", _nDepositType);
                if (_nInstrumentType == (int)Dictionary.InstrumentType.CASH)
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _sInstrumentNo);
                }
                cmd.Parameters.AddWithValue("InstrumentType", _nInstrumentType);
                if (_nInstrumentType == (int)Dictionary.InstrumentType.CASH)
                {
                    cmd.Parameters.AddWithValue("BankID", null);
                    cmd.Parameters.AddWithValue("BranchName", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("BankID", _nBankID);
                    cmd.Parameters.AddWithValue("BranchName", _sBranchName);
                }
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
    public class ExchangeOfferVenderAccount
    {
        private int _nVenderID;
        private double _SecurityDeposit;
        private double _PaymentReceive;
        private double _MoneyReceiptAmt;
        private double _Balance;


        /// <summary>
        /// Get set property for VenderID
        /// </summary>
        public int VenderID
        {
            get { return _nVenderID; }
            set { _nVenderID = value; }
        }
        /// <summary>
        /// Get set property for SecurityDeposit
        /// </summary>
        public double SecurityDeposit
        {
            get { return _SecurityDeposit; }
            set { _SecurityDeposit = value; }
        }
        /// <summary>
        /// Get set property for PaymentReceive
        /// </summary>
        public double PaymentReceive
        {
            get { return _PaymentReceive; }
            set { _PaymentReceive = value; }
        }
        /// <summary>
        /// Get set property for MoneyReceipt
        /// </summary>
        public double MoneyReceiptAmt
        {
            get { return _MoneyReceiptAmt; }
            set { _MoneyReceiptAmt = value; }
        }
        /// <summary>
        /// Get set property for Balance
        /// </summary>
        public double Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }


        public void Add()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_ExchangeOfferVenderAccount(VenderID,SecurityDeposit,PaymentReceive,MoneyReceiptAmt,Balance) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VenderID", _nVenderID);
                cmd.Parameters.AddWithValue("SecurityDeposit", _SecurityDeposit);
                cmd.Parameters.AddWithValue("PaymentReceive", _PaymentReceive);
                cmd.Parameters.AddWithValue("MoneyReceiptAmt", _MoneyReceiptAmt);
                cmd.Parameters.AddWithValue("Balance", _Balance);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Update(bool IsTrue)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                if (IsTrue == true)
                {
                    cmd.CommandText = "UPDATE t_ExchangeOfferVenderAccount SET SecurityDeposit = SecurityDeposit + ?, PaymentReceive = PaymentReceive + ?, " +
                                        "MoneyReceiptAmt = MoneyReceiptAmt + ?, Balance = Balance + ? Where VenderID=?";
                }
                else
                {
                    cmd.CommandText = "UPDATE t_ExchangeOfferVenderAccount SET SecurityDeposit = SecurityDeposit + ?, PaymentReceive = PaymentReceive + ?, " +
                                        "MoneyReceiptAmt = MoneyReceiptAmt + ?, Balance = Balance - ? Where VenderID=?";
                }

                cmd.CommandType = CommandType.Text;
               
                cmd.Parameters.AddWithValue("SecurityDeposit", _SecurityDeposit);
                cmd.Parameters.AddWithValue("PaymentReceive", _PaymentReceive);
                cmd.Parameters.AddWithValue("MoneyReceiptAmt", _MoneyReceiptAmt);
                cmd.Parameters.AddWithValue("Balance", _Balance);

                cmd.Parameters.AddWithValue("VenderID", _nVenderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckVenderAccount()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_ExchangeOfferVenderAccount where VenderID=?";
            cmd.Parameters.AddWithValue("VenderID", _nVenderID);

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
            if (nCount == 0)
                return true;
            else return false;
        }

        public void AddAccount()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_ExchangeOfferVenderAccount(VenderID,Balance) VALUES(?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VenderID", _nVenderID);
                cmd.Parameters.AddWithValue("Balance", _Balance);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateAccount(bool IsTrue)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                if (IsTrue == true)
                {
                    cmd.CommandText = "UPDATE t_ExchangeOfferVenderAccount SET Balance = Balance + ? Where VenderID=?";
                }
                else
                {
                    cmd.CommandText = "UPDATE t_ExchangeOfferVenderAccount SET Balance = Balance - ? Where VenderID=?";
                }

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Balance", _Balance);
                cmd.Parameters.AddWithValue("VenderID", _nVenderID);

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
                cmd.CommandText = "SELECT * FROM t_ExchangeOfferVenderAccount where VenderID = ?";
                cmd.Parameters.AddWithValue("VenderID", _nVenderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _Balance = Convert.ToDouble(reader["Balance"].ToString());
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
    public class ExchangeOfferVenderMR
    {
        private int _nMoneyReceiptID;
        private int _nMoneyReceiptNo;
        private int _nCustomerID;
        private double _Amount;
        private int _nStatus;
        private int _nCreateUserID;
        private DateTime _dCreateDate;

        private string _sCancelReason;
        private int _nCancelUserID;
        private DateTime _dCancelDate;
        private string _sCustomerName;
        private string _sMRStatus;
        private string _sAmt;

        /// <summary>
        /// Get set property for MoneyReceiptID
        /// </summary>
        public int MoneyReceiptID
        {
            get { return _nMoneyReceiptID; }
            set { _nMoneyReceiptID = value; }
        }
        /// <summary>
        /// Get set property for MoneyReceiptNo
        /// </summary>
        public int MoneyReceiptNo
        {
            get { return _nMoneyReceiptNo; }
            set { _nMoneyReceiptNo = value; }
        }
        /// <summary>
        /// Get set property for CustomerID
        /// </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        /// <summary>
        /// Get set property for Amount
        /// </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
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
        /// Get set property for CancelReason
        /// </summary>
        public string CancelReason
        {
            get { return _sCancelReason; }
            set { _sCancelReason = value; }
        }
        /// <summary>
        /// Get set property for CancelUserID
        /// </summary>
        public int CancelUserID
        {
            get { return _nCancelUserID; }
            set { _nCancelUserID = value; }
        }
        /// <summary>
        /// Get set property for CancelDate
        /// </summary>
        public DateTime CancelDate
        {
            get { return _dCancelDate; }
            set { _dCancelDate = value; }
        }
        /// <summary>
        /// Get set property for CustomerName
        /// </summary>
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        /// <summary>
        /// Get set property for MRStatus
        /// </summary>
        public string MRStatus
        {
            get { return _sMRStatus; }
            set { _sMRStatus = value; }
        }
        /// <summary>
        /// Get set property for Amt
        /// </summary>
        public string Amt
        {
            get { return _sAmt; }
            set { _sAmt = value; }
        }


        public void Add()
        {
            int nMaxMRID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([MoneyReceiptID]) FROM t_ExchangeOfferMR";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxMRID = 1;
                }
                else
                {
                    nMaxMRID = Convert.ToInt32(maxID) + 1;
                }
                _nMoneyReceiptID = nMaxMRID;

                sSql = "INSERT INTO t_ExchangeOfferMR(MoneyReceiptID,MoneyReceiptNo,CustomerID,Amount,Status,CreateUserID,CreateDate) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("MoneyReceiptID", _nMoneyReceiptID);
                cmd.Parameters.AddWithValue("MoneyReceiptNo", _nMoneyReceiptNo);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("Amount", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void MRStatusUpdate()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_ExchangeOfferMR SET Status=? Where MoneyReceiptID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("MoneyReceiptID", _nMoneyReceiptID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void MRAmountUpdate()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_ExchangeOfferMR SET Amount=? Where MoneyReceiptID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Amount", _Amount);

                cmd.Parameters.AddWithValue("MoneyReceiptID", _nMoneyReceiptID);

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

            try
            {

                cmd.CommandText = "UPDATE t_ExchangeOfferMR SET CancelReason=?, Status=?, CancelUserID=?, CancelDate=? Where MoneyReceiptNo=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CancelReason", _sCancelReason);
                cmd.Parameters.AddWithValue("Status", (int)Dictionary.ExOMRStatus.Cancel);
                cmd.Parameters.AddWithValue("CancelUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CancelDate", DateTime.Now);

                cmd.Parameters.AddWithValue("MoneyReceiptNo", _nMoneyReceiptNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckMR()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_ExchangeOfferMR where Status = 0 and MoneyReceiptNo=?";
            cmd.Parameters.AddWithValue("MoneyReceiptNo", _nMoneyReceiptNo);

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
            if (nCount == 0)
                return true;
            else return false;
        }
    }
    public class ExchangeOfferVenderMRs : CollectionBase
    {
        public ExchangeOfferVenderMR this[int i]
        {
            get { return (ExchangeOfferVenderMR)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ExchangeOfferVenderMR oExchangeOfferVenderMR)
        {
            InnerList.Add(oExchangeOfferVenderMR);
        }
        //public int GetIndex(int nVenderID)
        //{
        //    int i;
        //    for (i = 0; i < this.Count; i++)
        //    {
        //        if (this[i].VenderID == nVenderID)
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}

        public void Refresh(String txtMRNo, int nCustomerID, int nStatus)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select MoneyReceiptID,MoneyReceiptNo,CustomerName,IsNull(Amount,'') as Amount,Status, EOMR.CustomerID, MRStatus= CASE " +
                            "When Status=0 then 'Create' When Status=1 then 'Exchange' When Status=2 then 'Redeem' When Status=3 then 'Cancel' end "+
                            "from t_ExchangeOfferMR EOMR INNER JOIN t_Customer C ON C.CustomerID=EOMR.CustomerID Where MoneyReceiptID <>0";

            if (txtMRNo != "")
            {
                txtMRNo = "%" + txtMRNo + "%";
                sSql = sSql + " AND MoneyReceiptNo LIKE '" + txtMRNo + "'";
            }
            if (nCustomerID > 0)
            {
                sSql = sSql + "AND EOMR.CustomerID ='" + nCustomerID + "'";
            }
            if (nStatus > 0)
            {
                sSql = sSql + "AND Status ='" + nStatus + "'";
            }


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferVenderMR oExchangeOfferVenderMR = new ExchangeOfferVenderMR();


                    oExchangeOfferVenderMR.MoneyReceiptID = (int)reader["MoneyReceiptID"];
                    oExchangeOfferVenderMR.MoneyReceiptNo = int.Parse(reader["MoneyReceiptNo"].ToString());
                    oExchangeOfferVenderMR.CustomerName = (string)reader["CustomerName"];
                    oExchangeOfferVenderMR.Amt = (string)reader["Amount"];
                    oExchangeOfferVenderMR.MRStatus = (string)reader["MRStatus"];

                    InnerList.Add(oExchangeOfferVenderMR);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetMoneyReceiptNo()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * FROM t_ExchangeOfferMR Where Status = 0";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferVenderMR oExchangeOfferVenderMR = new ExchangeOfferVenderMR();

                    oExchangeOfferVenderMR.MoneyReceiptID = (int)reader["MoneyReceiptID"];
                    oExchangeOfferVenderMR.MoneyReceiptNo = int.Parse(reader["MoneyReceiptNo"].ToString());

                    InnerList.Add(oExchangeOfferVenderMR);
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

    public class ExchangeOfferVenderParent
    {
        private int _nParentVenderID;
        private string _sParentVenderCode;
        private string _sParentVenderName;
        private string _sAddress;
        private string _sContactNo;
        private string _sContactPerson;
        private string _sEmail;
        private double _MotherAcctBalance;
        private double _ChildAcctBalance;
        private int _nIsActive;
        private string _sRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private int _nVenderID;
        private string _sCode;
        private string _sName;
        private int _nWarehouseID;
        private int _nParentCustomerID;


        // <summary>
        // Get set property for Code
        // </summary>
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value.Trim(); }
        }
        // <summary>
        // Get set property for Name
        // </summary>
        public string Name
        {
            get { return _sName; }
            set { _sName = value.Trim(); }
        }


        // <summary>
        // Get set property for ParentCustomerID
        // </summary>
        public int ParentCustomerID
        {
            get { return _nParentCustomerID; }
            set { _nParentCustomerID = value; }
        }
        // <summary>
        // Get set property for WarehousID
        // </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        // <summary>
        // Get set property for VenderID
        // </summary>
        public int VenderID
        {
            get { return _nVenderID; }
            set { _nVenderID = value; }
        }

        // <summary>
        // Get set property for ParentVenderID
        // </summary>
        public int ParentVenderID
        {
            get { return _nParentVenderID; }
            set { _nParentVenderID = value; }
        }

        // <summary>
        // Get set property for ParentVenderCode
        // </summary>
        public string ParentVenderCode
        {
            get { return _sParentVenderCode; }
            set { _sParentVenderCode = value.Trim(); }
        }

        // <summary>
        // Get set property for ParentVenderName
        // </summary>
        public string ParentVenderName
        {
            get { return _sParentVenderName; }
            set { _sParentVenderName = value.Trim(); }
        }

        // <summary>
        // Get set property for Address
        // </summary>
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value.Trim(); }
        }

        // <summary>
        // Get set property for ContactNo
        // </summary>
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value.Trim(); }
        }

        // <summary>
        // Get set property for ContactPerson
        // </summary>
        public string ContactPerson
        {
            get { return _sContactPerson; }
            set { _sContactPerson = value.Trim(); }
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
        // Get set property for MotherAcctBalance
        // </summary>
        public double MotherAcctBalance
        {
            get { return _MotherAcctBalance; }
            set { _MotherAcctBalance = value; }
        }

        // <summary>
        // Get set property for ChildAcctBalance
        // </summary>
        public double ChildAcctBalance
        {
            get { return _ChildAcctBalance; }
            set { _ChildAcctBalance = value; }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
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

        public void Add()
        {
            int nMaxParentVenderID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ParentVenderID]) FROM t_ExchangeOfferVenderParent";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxParentVenderID = 1;
                }
                else
                {
                    nMaxParentVenderID = Convert.ToInt32(maxID) + 1;
                }
                _nParentVenderID = nMaxParentVenderID;



                string sCode = "";
                sCode = "10" + _nParentVenderID.ToString("0000");
                _sParentVenderCode = sCode;


                sSql = "INSERT INTO t_ExchangeOfferVenderParent (ParentVenderID, ParentVenderCode, ParentVenderName, Address, ContactNo, ContactPerson, Email, MotherAcctBalance, ChildAcctBalance, IsActive, Remarks, CreateUserID, CreateDate, UpdateUserID, UpdateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ParentVenderID", _nParentVenderID);
                cmd.Parameters.AddWithValue("ParentVenderCode", _sParentVenderCode);
                cmd.Parameters.AddWithValue("ParentVenderName", _sParentVenderName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("MotherAcctBalance", _MotherAcctBalance);
                cmd.Parameters.AddWithValue("ChildAcctBalance", _ChildAcctBalance);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);

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
                sSql = "UPDATE t_ExchangeOfferVenderParent SET ParentVenderName = ?, Address = ?, ContactNo = ?, ContactPerson = ?, Email = ?, IsActive = ?, Remarks = ?, UpdateUserID = ?, UpdateDate = ? WHERE ParentVenderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("ParentVenderName", _sParentVenderName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("ParentVenderID", _nParentVenderID);

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
                sSql = "DELETE FROM t_ExchangeOfferVenderParent WHERE [ParentVenderID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ParentVenderID", _nParentVenderID);
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
                cmd.CommandText = "SELECT * FROM t_ExchangeOfferVenderParent where ParentVenderID =?";
                cmd.Parameters.AddWithValue("ParentVenderID", _nParentVenderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nParentVenderID = (int)reader["ParentVenderID"];
                    _sParentVenderCode = (string)reader["ParentVenderCode"];
                    _sParentVenderName = (string)reader["ParentVenderName"];
                    _sAddress = (string)reader["Address"];
                    _sContactNo = (string)reader["ContactNo"];
                    _sContactPerson = (string)reader["ContactPerson"];
                    _sEmail = (string)reader["Email"];
                    _MotherAcctBalance = Convert.ToDouble(reader["MotherAcctBalance"].ToString());
                    _ChildAcctBalance = Convert.ToDouble(reader["ChildAcctBalance"].ToString());
                    _nIsActive = (int)reader["IsActive"];
                    _sRemarks = (string)reader["Remarks"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateParentBalance(bool IsTrue)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                if (IsTrue == true)
                {
                    cmd.CommandText = "UPDATE t_ExchangeOfferVenderParent SET MotherAcctBalance = MotherAcctBalance + ? Where ParentVenderID=?";
                }
                else
                {
                    cmd.CommandText = "UPDATE t_ExchangeOfferVenderParent SET MotherAcctBalance = MotherAcctBalance + ? Where ParentVenderID=?";
                }

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MotherAcctBalance", _MotherAcctBalance);
                cmd.Parameters.AddWithValue("ParentVenderID", _nParentVenderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateBalanceByType(int _nType)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                if (_nType == (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Parent_To_Child)
                {
                    cmd.CommandText = "UPDATE t_ExchangeOfferVenderParent SET MotherAcctBalance = MotherAcctBalance - ?, ChildAcctBalance = ChildAcctBalance + ? Where ParentVenderID=?";
                }
                else if (_nType == (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Child_To_Parent)
                {
                    cmd.CommandText = "UPDATE t_ExchangeOfferVenderParent SET MotherAcctBalance = MotherAcctBalance + ?, ChildAcctBalance = ChildAcctBalance - ?  Where ParentVenderID=?";
                }

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("MotherAcctBalance", _MotherAcctBalance);
                cmd.Parameters.AddWithValue("ChildAcctBalance", _ChildAcctBalance);
                cmd.Parameters.AddWithValue("ParentVenderID", _nParentVenderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateChildBalanceByType(int _nType)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                if (_nType == (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Parent_To_Child)
                {
                    cmd.CommandText = "UPDATE t_ExchangeOfferVenderParent SET ChildAcctBalance = ChildAcctBalance + ? Where ParentVenderID=?";
                }
                else if (_nType == (int)Dictionary.ExchangeOfferDepositType.Fund_Transfer_Child_To_Parent)
                {
                    cmd.CommandText = "UPDATE t_ExchangeOfferVenderParent SET ChildAcctBalance = ChildAcctBalance - ?  Where ParentVenderID=?";
                }
                else if (_nType == (int)Dictionary.ExchangeOfferDepositType.Money_Receipt)
                {
                    cmd.CommandText = "UPDATE t_ExchangeOfferVenderParent SET ChildAcctBalance = ChildAcctBalance - ?  Where ParentVenderID=?";
                }

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ChildAcctBalance", _ChildAcctBalance);
                cmd.Parameters.AddWithValue("ParentVenderID", _nParentVenderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class ExchangeOfferVenderParents : CollectionBase
    {
        public ExchangeOfferVenderParent this[int i]
        {
            get { return (ExchangeOfferVenderParent)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ExchangeOfferVenderParent oExchangeOfferVenderParent)
        {
            InnerList.Add(oExchangeOfferVenderParent);
        }
        public int GetIndex(int nParentVenderID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ParentVenderID == nParentVenderID)
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
            string sSql = "SELECT * FROM t_ExchangeOfferVenderParent";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferVenderParent oExchangeOfferVenderParent = new ExchangeOfferVenderParent();
                    oExchangeOfferVenderParent.ParentVenderID = (int)reader["ParentVenderID"];
                    oExchangeOfferVenderParent.ParentVenderCode = (string)reader["ParentVenderCode"];
                    oExchangeOfferVenderParent.ParentVenderName = (string)reader["ParentVenderName"];
                    oExchangeOfferVenderParent.Address = (string)reader["Address"];
                    oExchangeOfferVenderParent.ContactNo = (string)reader["ContactNo"];
                    oExchangeOfferVenderParent.ContactPerson = (string)reader["ContactPerson"];
                    oExchangeOfferVenderParent.Email = (string)reader["Email"];
                    oExchangeOfferVenderParent.MotherAcctBalance = Convert.ToDouble(reader["MotherAcctBalance"].ToString());
                    oExchangeOfferVenderParent.ChildAcctBalance = Convert.ToDouble(reader["ChildAcctBalance"].ToString());
                    oExchangeOfferVenderParent.IsActive = (int)reader["IsActive"];
                    oExchangeOfferVenderParent.Remarks = (string)reader["Remarks"];
                    oExchangeOfferVenderParent.CreateUserID = (int)reader["CreateUserID"];
                    oExchangeOfferVenderParent.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oExchangeOfferVenderParent.UpdateUserID = (int)reader["UpdateUserID"];
                    oExchangeOfferVenderParent.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    InnerList.Add(oExchangeOfferVenderParent);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(string sVenderCode, string sVenderName, string sContactNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From t_ExchangeOfferVenderParent where 1=1";

            if (sVenderCode != "")
            {
                sVenderCode = "%" + sVenderCode + "%";
                sSql = sSql + " AND ParentVenderCode LIKE '" + sVenderCode + "'";
            }
            if (sVenderName != "")
            {
                sVenderName = "%" + sVenderName + "%";
                sSql = sSql + " AND ParentVenderName LIKE '" + sVenderName + "'";
            }
            if (sContactNo != "")
            {
                sContactNo = "%" + sContactNo + "%";
                sSql = sSql + " AND ContactNo LIKE '" + sContactNo + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferVenderParent oExchangeOfferVenderParent = new ExchangeOfferVenderParent();
                    oExchangeOfferVenderParent.ParentVenderID = (int)reader["ParentVenderID"];
                    oExchangeOfferVenderParent.ParentVenderCode = (string)reader["ParentVenderCode"];
                    oExchangeOfferVenderParent.ParentVenderName = (string)reader["ParentVenderName"];
                    oExchangeOfferVenderParent.Address = (string)reader["Address"];
                    oExchangeOfferVenderParent.ContactNo = (string)reader["ContactNo"];
                    oExchangeOfferVenderParent.ContactPerson = (string)reader["ContactPerson"];
                    oExchangeOfferVenderParent.Email = (string)reader["Email"];
                    oExchangeOfferVenderParent.MotherAcctBalance = Convert.ToDouble(reader["MotherAcctBalance"].ToString());
                    oExchangeOfferVenderParent.ChildAcctBalance = Convert.ToDouble(reader["ChildAcctBalance"].ToString());
                    oExchangeOfferVenderParent.IsActive = (int)reader["IsActive"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oExchangeOfferVenderParent.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oExchangeOfferVenderParent.Remarks = "";
                    }
                    oExchangeOfferVenderParent.CreateUserID = (int)reader["CreateUserID"];
                    oExchangeOfferVenderParent.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oExchangeOfferVenderParent);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshforCombo()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * FROM t_ExchangeOfferVenderParent where IsActive=1";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferVenderParent oExchangeOfferVenderParent = new ExchangeOfferVenderParent();

                    oExchangeOfferVenderParent.ParentVenderID = (int)reader["ParentVenderID"];
                    oExchangeOfferVenderParent.ParentVenderCode = (string)reader["ParentVenderCode"];
                    oExchangeOfferVenderParent.ParentVenderName = (string)reader["ParentVenderName"];
                    oExchangeOfferVenderParent.MotherAcctBalance = (double)reader["MotherAcctBalance"];
                    oExchangeOfferVenderParent.ChildAcctBalance = (double)reader["ChildAcctBalance"];
                    oExchangeOfferVenderParent.IsActive = (int)reader["IsActive"];


                    InnerList.Add(oExchangeOfferVenderParent);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshforComboByID(int nVenderID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.ParentVenderID,ParentVenderCode,ParentVenderName,VenderID,Code,Name,WarehouseID,  " +
                        " ParentCustomerID,Balance as ChildAcctBalance,MotherAcctBalance FROM t_ExchangeOfferVender a,t_Showroom b,t_ExchangeOfferVenderParent c  " +
                        " Where a.ParentCustomerID=b.CustomerID and a.ParentVenderID=c.ParentVenderID  " +
                        " and a.IsActive=1 and VenderID=" + nVenderID + "";



            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferVenderParent oExchangeOfferVenderParent = new ExchangeOfferVenderParent();

                    oExchangeOfferVenderParent.ParentVenderID = (int)reader["ParentVenderID"];
                    oExchangeOfferVenderParent.ParentVenderName = (string)reader["ParentVenderName"];
                    oExchangeOfferVenderParent.ParentVenderCode = (string)reader["ParentVenderCode"];
                    oExchangeOfferVenderParent.VenderID = (int)reader["VenderID"];
                    oExchangeOfferVenderParent.Code = (string)reader["Code"];
                    oExchangeOfferVenderParent.Name = (string)reader["Name"];
                    oExchangeOfferVenderParent.WarehouseID = (int)reader["WarehouseID"];
                    oExchangeOfferVenderParent.ParentCustomerID = (int)reader["ParentCustomerID"];
                    oExchangeOfferVenderParent.MotherAcctBalance = (double)reader["MotherAcctBalance"];
                    oExchangeOfferVenderParent.ChildAcctBalance = (double)reader["ChildAcctBalance"];

                    InnerList.Add(oExchangeOfferVenderParent);
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






    


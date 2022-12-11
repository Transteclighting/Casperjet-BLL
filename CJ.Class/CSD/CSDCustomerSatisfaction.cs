// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Mar 20, 2016
// Time : 12:23 PM
// Description: Class for CSDCustomerSatisfactionDetail.
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
    public class CSDCustomerSatisfactionDetail
    {
        private int _nID;
        private int _nQuestionID;
        private int _nMark;
        private string _sQuestions;
        private int _nType;
        private int _nMAGID;
        private int _nInvoiceID;
        private int _nProductID;
        private int _nJobID;

        private string _sProductSerial;


        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }
        public string ProductSerial
        {
            get { return _sProductSerial; }
            set { _sProductSerial = value.Trim(); }
        }
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }

        // <summary>
        // Get set property for Questions
        // </summary>
        public string Questions
        {
            get { return _sQuestions; }
            set { _sQuestions = value.Trim(); }
        }

        // <summary>
        // Get set property for Type
        // </summary>
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for QuestionID
        // </summary>
        public int QuestionID
        {
            get { return _nQuestionID; }
            set { _nQuestionID = value; }
        }

        // <summary>
        // Get set property for Mark
        // </summary>
        public int Mark
        {
            get { return _nMark; }
            set { _nMark = value; }
        }

        private int _nMarkID;
        public int MarkID
        {
            get { return _nMarkID; }
            set { _nMarkID = value; }
        }

        private string _sDescription;

        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }


        // <summary>
        // Get set property for InvoiceID
        // </summary>
        public int InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
        }

        // <summary>
        // Get set property for ProductID
        // </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "INSERT INTO t_CSDCustomerSatisfactionDetail (ID, QuestionID, Mark) VALUES(?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("QuestionID", _nQuestionID);
                cmd.Parameters.AddWithValue("Mark", _nMark);

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
                sSql = "UPDATE t_CSDCustomerSatisfactionDetail SET QuestionID = ?, Mark = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("QuestionID", _nQuestionID);
                cmd.Parameters.AddWithValue("Mark", _nMark);

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
                sSql = "DELETE FROM t_CSDCustomerSatisfactionDetail WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_CSDCustomerSatisfactionDetail where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nQuestionID = (int)reader["QuestionID"];
                    _nMark = (int)reader["Mark"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddInvoiceWise()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "INSERT INTO t_CSDCustomerSatisfactionInvoiceDetail (ID, InvoiceID, ProductID, ProductSerial, QuestionID, Marks, JobID, MarkID) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("ProductSerial", _sProductSerial);
                cmd.Parameters.AddWithValue("QuestionID", _nQuestionID);
                cmd.Parameters.AddWithValue("Marks", _nMark);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("MarkID", _nMarkID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteInvoiceWise()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_CSDCustomerSatisfactionInvoiceDetail WHERE [ID]=?";
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
    }
    public class CSDCustomerSatisfaction : CollectionBase
    {
        public CSDCustomerSatisfactionDetail this[int i]
        {
            get { return (CSDCustomerSatisfactionDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDCustomerSatisfactionDetail oCSDCustomerSatisfactionDetail)
        {
            InnerList.Add(oCSDCustomerSatisfactionDetail);
        }
        private int _nID;
        private int _nJobID;
        private int _nInvoiceID;
        private int _nIsBanforever;
        private int _nProductID;
        private int _nWarehouseID;
        private int _nStatus;
        private string _sRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpDateUserID;
        private DateTime _dUpdateDate;

        private string _sJobNo;
        private string _sInvoiceNo;
        private string _sShowroomCode;
        private string _sConsumerCode;
        private string _sConsumerName;
        private double _dInvoiceAmount;
        private double _dDiscount;
        private string _sAGName;
        private string _sASGName;
        private string _sMAGName;
        private string _sPGName;
        private string _sBrandDesc;
        private string _sProductSerialNo;
        private int _nMAGID;
        private int _nBrandID;
        private int _nQty;
        private int _nFreeQty;
        private string _sCallStatus;
        private object _nHappyCallStatus;
        private string _sIsExchangeOffer;

        public int IsBanforever
        {
            get { return _nIsBanforever; }
            set { _nIsBanforever = value; }
        }
        public object HappyCallStatus
        {
            get { return _nHappyCallStatus; }
            set { _nHappyCallStatus = value; }
        }
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }

        public int InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
        }
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
        public int FreeQty
        {
            get { return _nFreeQty; }
            set { _nFreeQty = value; }
        }
        private double _DisorChrAmt;
        public double DisorChrAmt
        {
            get { return _DisorChrAmt; }
            set { _DisorChrAmt = value; }
        }

        public double InvoiceAmount
        {
            get { return _dInvoiceAmount; }
            set { _dInvoiceAmount = value; }
        }
        public double Discount
        {
            get { return _dDiscount; }
            set { _dDiscount = value; }
        }
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }
        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value.Trim(); }
        }
        private string _sInstallationRequired;
        public string InstallationRequired
        {
            get { return _sInstallationRequired; }
            set { _sInstallationRequired = value.Trim(); }
        }
        public string IsExchangeOffer
        {
            get { return _sIsExchangeOffer; }
            set { _sIsExchangeOffer = value.Trim(); }
        }
        public string ConsumerCode
        {
            get { return _sConsumerCode; }
            set { _sConsumerCode = value.Trim(); }
        }
        public string ConsumerName
        {
            get { return _sConsumerName; }
            set { _sConsumerName = value.Trim(); }
        }
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value.Trim(); }
        }

        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value.Trim(); }
        }
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value.Trim(); }
        }
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value.Trim(); }
        }
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value.Trim(); }
        }
        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value.Trim(); }
        }
        public string ProductSerialNo
        {
            get { return _sProductSerialNo; }
            set { _sProductSerialNo = value.Trim(); }
        }
        private DateTime _dJobCreationDate;
        private DateTime _dInvoiceDate;
        // <summary>
        // Get set property for JobCreationDate
        // </summary>
        public DateTime JobCreationDate
        {
            get { return _dJobCreationDate; }
            set { _dJobCreationDate = value; }
        }
        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }
        private int _nJobType;
        // <summary>
        // Get set property for JobType
        // </summary>
        public int JobType
        {
            get { return _nJobType; }
            set { _nJobType = value; }
        }

        private string _sJobTypeName;
        // <summary>
        // Get set property for _sJobTypeName
        // </summary>
        public string JobTypeName
        {
            get { return _sJobTypeName; }
            set { _sJobTypeName = value.Trim(); }
        }

        private int _nServiceType;
        // <summary>
        // Get set property for ServiceType
        // </summary>
        public int ServiceType
        {
            get { return _nServiceType; }
            set { _nServiceType = value; }
        }

        private string _sServiceTypeName;
        // <summary>
        // Get set property for Remarks
        // </summary>
        public string ServiceTypeName
        {
            get { return _sServiceTypeName; }
            set { _sServiceTypeName = value.Trim(); }
        }

        private DateTime _dDeliveryDate;
        // <summary>
        // Get set property for DeliveryDate
        // </summary>
        public DateTime DeliveryDate
        {
            get { return _dDeliveryDate; }
            set { _dDeliveryDate = value; }
        }

        private DateTime _dCDate;
        // <summary>
        // Get set property for CDate
        // </summary>
        public DateTime CDate
        {
            get { return _dCDate; }
            set { _dCDate = value; }
        }

        private string _sCustomerName;
        // <summary>
        // Get set property for _sCustomerName
        // </summary>
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }

        private string _sPhoneOffice;
        // <summary>
        // Get set property for _sPhoneOffice
        // </summary>
        public string PhoneOffice
        {
            get { return _sPhoneOffice; }
            set { _sPhoneOffice = value.Trim(); }
        }

        private string _sPhoneHome;
        // <summary>
        // Get set property for _sPhoneHome
        // </summary>
        public string PhoneHome
        {
            get { return _sPhoneHome; }
            set { _sPhoneHome = value.Trim(); }
        }

        private string _sMobile;
        // <summary>
        // Get set property for Mobile
        // </summary>
        public string Mobile
        {
            get { return _sMobile; }
            set { _sMobile = value.Trim(); }
        }


        private string _sEmail;
        // <summary>
        // Get set property for Email
        // </summary>
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value.Trim(); }
        }


        private string _sAddress;
        // <summary>
        // Get set property for Address
        // </summary>
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value.Trim(); }
        }

        //private int _nProductID;
        // <summary>
        // Get set property for ProductID
        // </summary>
        //public int ProductID
        //{
        //    get { return _nProductID; }
        //    set { _nProductID = value; }
        //}

        private string _sProductCode;
        // <summary>
        // Get set property for ProductCode
        // </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }

        private string _sProductName;
        // <summary>
        // Get set property for ProductName
        // </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }

        //private string _sAGName;
        // <summary>
        // Get set property for AGName
        // </summary>
        //public string AGName
        //{
        //    get { return _sAGName; }
        //    set { _sAGName = value.Trim(); }
        //}

        //private string _sASGName;
        //// <summary>
        //// Get set property for ASGName
        //// </summary>
        //public string ASGName
        //{
        //    get { return _sASGName; }
        //    set { _sASGName = value.Trim(); }
        //}

        //private string _sMAGName;
        //// <summary>
        //// Get set property for MAGName
        //// </summary>
        //public string MAGName
        //{
        //    get { return _sMAGName; }
        //    set { _sMAGName = value.Trim(); }
        //}

        //private string _sPGName;
        //// <summary>
        //// Get set property for PGName
        //// </summary>
        //public string PGName
        //{
        //    get { return _sPGName; }
        //    set { _sPGName = value.Trim(); }
        //}

        private string _sSerialNo;
        // <summary>
        // Get set property for SerialNo
        // </summary>
        public string SerialNo
        {
            get { return _sSerialNo; }
            set { _sSerialNo = value.Trim(); }
        }

        private int _nIsHappyCall;
        // <summary>
        // Get set property for IsHappyCall
        // </summary>
        public int IsHappyCall
        {
            get { return _nIsHappyCall; }
            set { _nIsHappyCall = value; }
        }

        private int _nSalesType;

        public int SalesType
        {
            get { return _nSalesType; }
            set { _nSalesType = value; }
        }
        private int _nIsJob;
        public int IsJob
        {
            get { return _nIsJob; }
            set { _nIsJob = value; }
        }



        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        private string _sDiscountTypeName;
        public string DiscountTypeName
        {
            get { return _sDiscountTypeName; }
            set { _sDiscountTypeName = value; }
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
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }
        public string CallStatus
        {
            get { return _sCallStatus; }
            set { _sCallStatus = value.Trim(); }
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
        // Get set property for UpDateUserID
        // </summary>
        public int UpDateUserID
        {
            get { return _nUpDateUserID; }
            set { _nUpDateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        private int _nIsNewJob;
        public int IsNewJob
        {
            get { return _nIsNewJob; }
            set { _nIsNewJob = value; }
        }



        public void Add(int nServiceType)
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CSDCustomerSatisfaction";
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
                sSql = "INSERT INTO t_CSDCustomerSatisfaction (ID, JobID, Status, Remarks, CreateUserID, CreateDate, UpDateUserID, UpdateDate,IsNewJob) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpDateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("IsNewJob", _nIsNewJob);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (_nStatus == (int)Dictionary.CSDHappyCallStatus.NoResponse)
                {

                }
                //else if (_nStatus == (int)Dictionary.CSDHappyCallStatus.BanForever)
                //{

                //}
                else
                {
                    if (nServiceType == (int)Dictionary.ServiceType.HomeCall || nServiceType == (int)Dictionary.ServiceType.Installation || nServiceType == (int)Dictionary.ServiceType.Walkin)
                    {

                        foreach (CSDCustomerSatisfactionDetail oItem in this)
                        {
                            oItem.ID = _nID;
                            oItem.Add();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddOldData()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CSDCustomerSatisfaction";
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
                sSql = "INSERT INTO t_CSDCustomerSatisfaction (ID, JobID, Status, Remarks, CreateUserID, CreateDate, UpDateUserID, UpdateDate,IsNewJob) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpDateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("IsNewJob", 1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Edit(int nJobID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CSDCustomerSatisfaction SET Status = ?, Remarks = ?, UpDateUserID = ?, UpdateDate = ? WHERE JobID = "+nJobID+"";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpDateUserID", _nUpDateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

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
                sSql = "DELETE FROM t_CSDCustomerSatisfaction WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_CSDCustomerSatisfaction where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nJobID = (int)reader["JobID"];
                    _nStatus = (int)reader["Status"];
                    _sRemarks = (string)reader["Remarks"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpDateUserID = (int)reader["UpDateUserID"];
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
        public int RefreshResponse(int nJobID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDCustomerSatisfaction where JobID ="+nJobID+" and Status=4";
                //cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nJobID = (int)reader["JobID"];
                    _nStatus = (int)reader["Status"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nCount;
        }
        public int RefreshForIsHappyCall(int nJobID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDCustomerSatisfaction where JobID =" + nJobID + " and Status In(1,2,3)";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nJobID = (int)reader["JobID"];
                    _nStatus = (int)reader["Status"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nCount;
        }
        public void GetQuestions(int nServiceType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select * From t_CSDCustomerSatisfactionQuestioner where Type = ? and IsActive=" + (int)Dictionary.IsActive.Active + "";

                cmd.Parameters.AddWithValue("Type", nServiceType);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDCustomerSatisfactionDetail oItem = new CSDCustomerSatisfactionDetail();

                    oItem.ID = int.Parse(reader["ID"].ToString());
                    oItem.Type = int.Parse(reader["Type"].ToString());
                    oItem.Questions = (reader["Questions"].ToString());
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

        public void AddbyInvoice()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CSDCustomerSatisfactionInvoice";
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
                sSql = "INSERT INTO t_CSDCustomerSatisfactionInvoice (ID, Status, Remarks, CreateUserID, CreateDate, UpdateUserID, UpdateDate, InvoiceID, IsBanforever) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpDateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);
                cmd.Parameters.AddWithValue("IsBanforever", _nIsBanforever);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetQuestionsByMAG(int nMAGID,int nSalesType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                //cmd.CommandText = "Select a.QuestionID,MAGID,Question  " +
                //                "FROM dbo.t_CSDCustomerSatisfactionQuestionMappingMAG a,dbo.t_CSDCustomerSatisfactionQuestionerNew b  " +
                //                "where a.QuestionID=b.QuestionID and IsActive=1 and MAGID= ?";

                cmd.CommandText = "Select a.QuestionID,MAGID,Question  " +
                                "FROM dbo.t_CSDCustomerSatisfactionQuestionMappingMAG a,dbo.t_CSDCustomerSatisfactionQuestionerNew b,t_CSDCustomerSatisfactionQuestionMappingSalesType c   " +
                                "where a.QuestionID=b.QuestionID and a.QuestionID=c.QuestionID and IsActive=1 and MAGID= " + nMAGID + " and SalesType=" + nSalesType + "";

                cmd.Parameters.AddWithValue("MAGID", nMAGID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDCustomerSatisfactionDetail oItem = new CSDCustomerSatisfactionDetail();

                    oItem.ID = int.Parse(reader["QuestionID"].ToString());
                    oItem.MAGID = int.Parse(reader["MAGID"].ToString());
                    oItem.Questions = (reader["Question"].ToString());
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
        public void GetMarklistbyQuestionsID(int nQuestionsID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select* From t_CSDCustomerSatisfactionMark where QuestionID = ?";

                cmd.Parameters.AddWithValue("QuestionID", nQuestionsID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDCustomerSatisfactionDetail oItem = new CSDCustomerSatisfactionDetail();

                    oItem.ID = int.Parse(reader["ID"].ToString());
                    oItem.QuestionID = int.Parse(reader["QuestionID"].ToString());
                    oItem.Description = (reader["Description"].ToString());
                    oItem.Mark = int.Parse(reader["Mark"].ToString());

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

        public void GetMarklist()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select* From t_CSDCustomerSatisfactionMark";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDCustomerSatisfactionDetail oItem = new CSDCustomerSatisfactionDetail();

                    oItem.ID = int.Parse(reader["ID"].ToString());
                    oItem.QuestionID = int.Parse(reader["QuestionID"].ToString());
                    oItem.Description = (reader["Description"].ToString());
                    oItem.Mark = int.Parse(reader["Mark"].ToString());

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
    public class CSDCustomerSatisfactions : CollectionBase
    {
        public CSDCustomerSatisfaction this[int i]
        {
            get { return (CSDCustomerSatisfaction)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDCustomerSatisfaction oCSDCustomerSatisfaction)
        {
            InnerList.Add(oCSDCustomerSatisfaction);
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
            string sSql = "SELECT * FROM t_CSDCustomerSatisfaction";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDCustomerSatisfaction oCSDCustomerSatisfaction = new CSDCustomerSatisfaction();
                    oCSDCustomerSatisfaction.ID = (int)reader["ID"];
                    oCSDCustomerSatisfaction.JobID = (int)reader["JobID"];
                    oCSDCustomerSatisfaction.Status = (int)reader["Status"];
                    oCSDCustomerSatisfaction.Remarks = (string)reader["Remarks"];
                    oCSDCustomerSatisfaction.CreateUserID = (int)reader["CreateUserID"];
                    oCSDCustomerSatisfaction.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDCustomerSatisfaction.UpDateUserID = (int)reader["UpDateUserID"];
                    oCSDCustomerSatisfaction.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    InnerList.Add(oCSDCustomerSatisfaction);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate, string sJobNo, string sMobileNo, string sCustomer, string sProductName, string sSerialNo, int nIsHappyCall, int nJobType, int nServiceType, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From (Select Main.*,IsHappyCall=Case when ID=0 then 0 else 1 end From  " +
                    " (Select x.*,isnull(ID,0) ID,isnull(Status,0) Status,isnull(Remarks,'') Remarks,  " +
                    " isnull(CreateUserID,0) CreateUserID,isnull(CreateDate,'') CreateDate From  " +
                    " (Select JobID,JobNo,JobCreationDate,JobType,JobTypeName=Case When JobType=1 then 'Full_Warranty'  " +
                    " When JobType=2 then 'Paid'   " +
                    " When JobType=3 then 'Service_Warranty' else 'Other' end,  " +
                    " ServiceType,ServiceTypeName=Case When ServiceType=1 then 'WalkIn'  " +
                    " When ServiceType=2 then 'Home_Call'   " +
                    " When ServiceType=3 then 'Inter_Service'   " +
                    " When ServiceType=4 then 'Installation' else 'Other' end,  " +
                    " DeliveryDate,CDate=Case when ServiceType=4 then DeliveryDate+1   " +
                    " else DeliveryDate+3 end,  " +
                    " CustomerName,isnull(PhoneOffice,'') as PhoneOffice,  " +
                    " isnull(PhoneHome,'') PhoneHome,isnull(Mobile,'') Mobile,isnull(FirstAddress,'') as Address,  " +
                    " c.ProductID,ProductCode,ProductName,AGName,ASGName,MAGName,PGName,SerialNo  " +
                    " From TELServiceDB.DBO.Job a,TELServiceDB.DBO.Product b,v_ProductDetails c  " +
                    " where a.ProductID=b.ProductID and b.Code=c.ProductCode and JobStatus=13 and IsDelivered=1  " +
                    " and Year(JobCreationDate)>=2016  " +
                    " Union All  " +
                    " Select JobID,JobNo,JobCreationDate,JobType,JobTypeName=Case When JobType=1 then 'FullWarranty'  " +
                    " When JobType=2 then 'Paid'   " +
                    " When JobType=3 then 'ServiceWarranty' else 'ComponentWarranty' end,  " +
                    " ServiceType,ServiceTypeName=Case When ServiceType=1 then 'WalkIn'  " +
                    " When ServiceType=2 then 'Home_Call'   " +
                    " When ServiceType=3 then 'Inter_Service'   " +
                    " When ServiceType=4 then 'Installation' else 'Other' end,  " +
                    " DeliveryDate,CDate=Case when ServiceType=4 then DeliveryDate+1   " +
                    " else DeliveryDate+3 end,  " +
                    " CustomerName,isnull(PhoneOffice,'') as PhoneOffice,  " +
                    " isnull(PhoneHome,'') PhoneHome,isnull(Mobile,'') Mobile,isnull(FirstAddress,'') as Address,  " +
                    " c.ProductID,ProductCode,ProductName,AGName,ASGName,MAGName,PGName,SerialNo  " +
                    " From TELServiceDB.DBO.Job a,TELServiceDB.DBO.Product b,v_ProductDetails c  " +
                    " where a.ProductID=b.ProductID and b.Code=c.ProductCode and JobStatus=17  " +
                    " and Year(JobCreationDate)>=2016) x   " +
                    " Left Outer Join   " +
                    " (Select * From t_CSDCustomerSatisfaction where Status<>" + (int)Dictionary.CSDHappyCallStatus.NoResponse + ") y  " +
                    " on x.JobID=y.JobID) Main) Final where 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND CDate between '" + dFromDate + "' and '" + dToDate + "' and CDate<'" + dToDate + "' ";
            }
            if (sJobNo != "")
            {
                sSql = sSql + " AND JobNo like '%" + sJobNo + "%'";
            }
            if (sMobileNo != "")
            {
                sSql = sSql + " AND Mobile like '%" + sMobileNo + "%'";
            }
            if (sCustomer != "")
            {
                sSql = sSql + " AND CustomerName like '%" + sCustomer + "%'";
            }
            if (sProductName != "")
            {
                sSql = sSql + " AND ProductName like '%" + sProductName + "%'";
            }
            if (sSerialNo != "")
            {
                sSql = sSql + " AND SerialNo like '%" + sSerialNo + "%'";
            }

            if (nIsHappyCall != -1)
            {
                sSql = sSql + " AND IsHappyCall=" + nIsHappyCall + "";
            }

            if (nJobType != -1)
            {
                sSql = sSql + " AND JobType=" + nJobType + "";
            }
            if (nServiceType != -1)
            {
                sSql = sSql + " AND ServiceType=" + nServiceType + "";
            }
            sSql = sSql + " Order by JobID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDCustomerSatisfaction oCSDCustomerSatisfaction = new CSDCustomerSatisfaction();

                    oCSDCustomerSatisfaction.JobID = int.Parse(reader["JobID"].ToString());
                    oCSDCustomerSatisfaction.JobNo = (reader["JobNo"].ToString());
                    oCSDCustomerSatisfaction.JobCreationDate = Convert.ToDateTime(reader["JobCreationDate"].ToString());
                    oCSDCustomerSatisfaction.JobType = int.Parse(reader["JobType"].ToString());
                    oCSDCustomerSatisfaction.JobTypeName = (reader["JobTypeName"].ToString());
                    oCSDCustomerSatisfaction.ServiceType = int.Parse(reader["ServiceType"].ToString());
                    oCSDCustomerSatisfaction.ServiceTypeName = (reader["ServiceTypeName"].ToString());
                    oCSDCustomerSatisfaction.DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    oCSDCustomerSatisfaction.CDate = Convert.ToDateTime(reader["CDate"].ToString());
                    oCSDCustomerSatisfaction.CustomerName = (reader["CustomerName"].ToString());
                    oCSDCustomerSatisfaction.PhoneOffice = (reader["PhoneOffice"].ToString());
                    oCSDCustomerSatisfaction.PhoneHome = (reader["PhoneHome"].ToString());
                    oCSDCustomerSatisfaction.Mobile = (reader["Mobile"].ToString());
                    oCSDCustomerSatisfaction.Address = (reader["Address"].ToString());
                    oCSDCustomerSatisfaction.ProductID = int.Parse(reader["ProductID"].ToString());

                    oCSDCustomerSatisfaction.ProductCode = (reader["ProductCode"].ToString());
                    oCSDCustomerSatisfaction.ProductName = (reader["ProductName"].ToString());
                    oCSDCustomerSatisfaction.AGName = (reader["AGName"].ToString());
                    oCSDCustomerSatisfaction.ASGName = (reader["ASGName"].ToString());
                    oCSDCustomerSatisfaction.MAGName = (reader["MAGName"].ToString());
                    oCSDCustomerSatisfaction.PGName = (reader["PGName"].ToString());
                    oCSDCustomerSatisfaction.SerialNo = (reader["SerialNo"].ToString());

                    oCSDCustomerSatisfaction.ID = int.Parse(reader["ID"].ToString());
                    oCSDCustomerSatisfaction.Status = int.Parse(reader["Status"].ToString());
                    oCSDCustomerSatisfaction.Remarks = (reader["Remarks"].ToString());
                    oCSDCustomerSatisfaction.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oCSDCustomerSatisfaction.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDCustomerSatisfaction.IsHappyCall = int.Parse(reader["IsHappyCall"].ToString());

                    InnerList.Add(oCSDCustomerSatisfaction);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetData(DateTime dFromDate, DateTime dToDate, string sJobNo, string sMobileNo, string sCustomer, string sProductName, string sSerialNo, int nIsHappyCall, int nJobType, int nServiceType, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "SELECT * FROM (" +
                    " Select JobID,JobNo,CreateDate JobCreationDate,JobType,JobTypeName=Case When JobType=1 then 'FullWarranty'    " +
                    " When JobType=2 then 'Paid'     " +
                    " When JobType=3 then 'ServiceWarranty' else 'ComponentWarranty' end,    " +
                    " ServiceType,ServiceTypeName=Case When ServiceType=1 then 'WalkIn'    " +
                    " When ServiceType=2 then 'HomeCall'     " +
                    " When ServiceType=3 then 'Installation' else 'Other' end,    " +
                    " DeliveryDate,CDate=Case when ServiceType=3 then DeliveryDate+1     " +
                    " else DeliveryDate+3 end, " +
                    " CustomerName,isnull(Telephone,'') as PhoneNo,    " +
                    " isnull(MobileNo,'') Mobile,isnull(CustomerAddress,'') as Address,    " +
                    " a.ProductID,ProductCode,ProductName,AGName,ASGName,MAGName,PGName,ProductSerialNo,IsHappyCall From t_CSDJob a,v_ProductDetails b  " +
                    " where a.ProductID=b.ProductID and Status IN (17,27)) Main Where 1=1 ";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND CDate between '" + dFromDate + "' and '" + dToDate + "' and CDate<'" + dToDate + "' ";
            }
            if (sJobNo != "")
            {
                sSql = sSql + " AND JobNo like '%" + sJobNo + "%'";
            }
            if (sMobileNo != "")
            {
                sSql = sSql + " AND Mobile like '%" + sMobileNo + "%'";
            }
            if (sCustomer != "")
            {
                sSql = sSql + " AND CustomerName like '%" + sCustomer + "%'";
            }
            if (sProductName != "")
            {
                sSql = sSql + " AND ProductName like '%" + sProductName + "%'";
            }
            if (sSerialNo != "")
            {
                sSql = sSql + " AND ProductSerialNo like '%" + sSerialNo + "%'";
            }

            if (nIsHappyCall != -1)
            {
                sSql = sSql + " AND IsHappyCall=" + nIsHappyCall + "";
            }

            if (nJobType != -1)
            {
                sSql = sSql + " AND JobType=" + nJobType + "";
            }
            if (nServiceType != -1)
            {
                sSql = sSql + " AND ServiceType=" + nServiceType + "";
            }
            sSql = sSql + " Order by JobID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDCustomerSatisfaction oCSDCustomerSatisfaction = new CSDCustomerSatisfaction();

                    oCSDCustomerSatisfaction.JobID = int.Parse(reader["JobID"].ToString());
                    oCSDCustomerSatisfaction.JobNo = (reader["JobNo"].ToString());
                    oCSDCustomerSatisfaction.JobCreationDate = Convert.ToDateTime(reader["JobCreationDate"].ToString());
                    oCSDCustomerSatisfaction.JobType = int.Parse(reader["JobType"].ToString());
                    oCSDCustomerSatisfaction.JobTypeName = (reader["JobTypeName"].ToString());
                    oCSDCustomerSatisfaction.ServiceType = int.Parse(reader["ServiceType"].ToString());
                    oCSDCustomerSatisfaction.ServiceTypeName = (reader["ServiceTypeName"].ToString());
                    if (reader["DeliveryDate"] != DBNull.Value)
                    {
                        oCSDCustomerSatisfaction.DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    }
                    if (reader["CDate"] != DBNull.Value)
                    {
                        oCSDCustomerSatisfaction.CDate = Convert.ToDateTime(reader["CDate"].ToString());
                    }
                    oCSDCustomerSatisfaction.CustomerName = (reader["CustomerName"].ToString());
                    //oCSDCustomerSatisfaction.PhoneOffice = (reader["PhoneOffice"].ToString());
                    oCSDCustomerSatisfaction.PhoneHome = (reader["PhoneNo"].ToString());
                    oCSDCustomerSatisfaction.Mobile = (reader["Mobile"].ToString());
                    oCSDCustomerSatisfaction.Address = (reader["Address"].ToString());
                    oCSDCustomerSatisfaction.ProductID = int.Parse(reader["ProductID"].ToString());

                    oCSDCustomerSatisfaction.ProductCode = (reader["ProductCode"].ToString());
                    oCSDCustomerSatisfaction.ProductName = (reader["ProductName"].ToString());
                    oCSDCustomerSatisfaction.AGName = (reader["AGName"].ToString());
                    oCSDCustomerSatisfaction.ASGName = (reader["ASGName"].ToString());
                    oCSDCustomerSatisfaction.MAGName = (reader["MAGName"].ToString());
                    oCSDCustomerSatisfaction.PGName = (reader["PGName"].ToString());
                    oCSDCustomerSatisfaction.SerialNo = (reader["ProductSerialNo"].ToString());

                    //oCSDCustomerSatisfaction.ID = int.Parse(reader["ID"].ToString());
                    //oCSDCustomerSatisfaction.Status = int.Parse(reader["Status"].ToString());
                    //oCSDCustomerSatisfaction.Remarks = (reader["Remarks"].ToString());
                    //oCSDCustomerSatisfaction.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    //oCSDCustomerSatisfaction.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDCustomerSatisfaction.IsHappyCall = Convert.ToInt32(reader["IsHappyCall"].ToString());

                    InnerList.Add(oCSDCustomerSatisfaction);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetDataHappyCallStatus(DateTime dFromDate, DateTime dToDate, string sJobNo, string sMobileNo, string sCustomer, string sProductName, string sSerialNo, int nIsHappyCall, int nJobType, int nServiceType, bool IsCheck, int nStatus, string sBrandID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                //sSql = "SELECT * FROM (" +
                //    " Select JobID,JobNo,CreateDate JobCreationDate,JobType,JobTypeName=Case When JobType=1 then 'FullWarranty'    " +
                //    " When JobType=2 then 'Paid'     " +
                //    " When JobType=3 then 'ServiceWarranty' else 'ComponentWarranty' end,    " +
                //    " ServiceType,ServiceTypeName=Case When ServiceType=1 then 'WalkIn'    " +
                //    " When ServiceType=2 then 'HomeCall'     " +
                //    " When ServiceType=3 then 'Installation' else 'Other' end,    " +
                //    " DeliveryDate,CDate=Case when ServiceType=3 then DeliveryDate+1     " +
                //    " else DeliveryDate+3 end, " +
                //    " CustomerName,isnull(Telephone,'') as PhoneNo,    " +
                //    " isnull(MobileNo,'') Mobile,isnull(CustomerAddress,'') as Address,    " +
                //    " a.ProductID,ProductCode,ProductName,AGName,ASGName,MAGName,PGName,ProductSerialNo,IsHappyCall From t_CSDJob a,v_ProductDetails b  " +
                //    " where a.ProductID=b.ProductID and Status IN (17,27)) Main Where 1=1 ";

                sSql = @" Select A.*,isnull(B.Status,0) as Status From(
                        (SELECT * FROM ( 
                         Select a.JobID,JobNo,a.CreateDate JobCreationDate,JobType,JobTypeName=Case When JobType=1 then 'FullWarranty'     
                         When JobType=2 then 'Paid'      
                         When JobType=3 then 'ServiceWarranty' else 'ComponentWarranty' end,     
                         ServiceType,ServiceTypeName=Case When ServiceType=1 then 'WalkIn'     
                         When ServiceType=2 then 'HomeCall'      
                         When ServiceType=3 then 'Installation' else 'Other' end,     
                         DeliveryDate,CDate=Case when ServiceType=3 then DeliveryDate+1      
                         else DeliveryDate+3 end,b.BrandDesc,BrandID,
                         CustomerName,isnull(Telephone,'') as PhoneNo,     
                         isnull(MobileNo,'') Mobile,isnull(CustomerAddress,'') as Address,     
                         a.ProductID,ProductCode,ProductName,AGName,ASGName,MAGName,PGName,ProductSerialNo,IsHappyCall From t_CSDJob a,v_ProductDetails b  
                         where a.ProductID=b.ProductID and a.Status IN (17,27)) Main)as A
                         left Outer join
                         (SELECT * FROM t_CSDCustomerSatisfaction where IsNewJob=1) as B on A.JobID=B.JobID)Where 1=1 ";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND CDate between '" + dFromDate + "' and '" + dToDate + "' and CDate<'" + dToDate + "' ";
            }
            if (sJobNo != "")
            {
                sSql = sSql + " AND JobNo like '%" + sJobNo + "%'";
            }
            if (sMobileNo != "")
            {
                sSql = sSql + " AND Mobile like '%" + sMobileNo + "%'";
            }
            if (sCustomer != "")
            {
                sSql = sSql + " AND CustomerName like '%" + sCustomer + "%'";
            }
            if (sProductName != "")
            {
                sSql = sSql + " AND ProductName like '%" + sProductName + "%'";
            }
            if (sSerialNo != "")
            {
                sSql = sSql + " AND ProductSerialNo like '%" + sSerialNo + "%'";
            }

            if (nIsHappyCall != -1)
            {
                sSql = sSql + " AND IsHappyCall=" + nIsHappyCall + "";
            }

            if (nJobType != -1)
            {
                sSql = sSql + " AND JobType=" + nJobType + "";
            }
            if (nServiceType != -1)
            {
                sSql = sSql + " AND ServiceType=" + nServiceType + "";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status =" + nStatus + "";
            }
            //if (nBrandID != -1)
            //{
            //    sSql = sSql + " AND BrandID=" + nBrandID + "";
            //}
            if (sBrandID != "")
            {
                sSql = sSql + " AND BrandID IN (" + sBrandID + ") ";
            }
            sSql = sSql + " Order by JobID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDCustomerSatisfaction oCSDCustomerSatisfaction = new CSDCustomerSatisfaction();

                    oCSDCustomerSatisfaction.JobID = int.Parse(reader["JobID"].ToString());
                    oCSDCustomerSatisfaction.JobNo = (reader["JobNo"].ToString());
                    oCSDCustomerSatisfaction.JobCreationDate = Convert.ToDateTime(reader["JobCreationDate"].ToString());
                    oCSDCustomerSatisfaction.JobType = int.Parse(reader["JobType"].ToString());
                    oCSDCustomerSatisfaction.JobTypeName = (reader["JobTypeName"].ToString());
                    oCSDCustomerSatisfaction.ServiceType = int.Parse(reader["ServiceType"].ToString());
                    oCSDCustomerSatisfaction.ServiceTypeName = (reader["ServiceTypeName"].ToString());
                    if (reader["DeliveryDate"] != DBNull.Value)
                    {
                        oCSDCustomerSatisfaction.DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    }
                    if (reader["CDate"] != DBNull.Value)
                    {
                        oCSDCustomerSatisfaction.CDate = Convert.ToDateTime(reader["CDate"].ToString());
                    }
                    oCSDCustomerSatisfaction.CustomerName = (reader["CustomerName"].ToString());
                    //oCSDCustomerSatisfaction.PhoneOffice = (reader["PhoneOffice"].ToString());
                    oCSDCustomerSatisfaction.PhoneHome = (reader["PhoneNo"].ToString());
                    oCSDCustomerSatisfaction.Mobile = (reader["Mobile"].ToString());
                    oCSDCustomerSatisfaction.Address = (reader["Address"].ToString());
                    oCSDCustomerSatisfaction.ProductID = int.Parse(reader["ProductID"].ToString());

                    oCSDCustomerSatisfaction.ProductCode = (reader["ProductCode"].ToString());
                    oCSDCustomerSatisfaction.ProductName = (reader["ProductName"].ToString());
                    oCSDCustomerSatisfaction.AGName = (reader["AGName"].ToString());
                    oCSDCustomerSatisfaction.ASGName = (reader["ASGName"].ToString());
                    oCSDCustomerSatisfaction.MAGName = (reader["MAGName"].ToString());
                    oCSDCustomerSatisfaction.PGName = (reader["PGName"].ToString());
                    oCSDCustomerSatisfaction.SerialNo = (reader["ProductSerialNo"].ToString());
                    oCSDCustomerSatisfaction.BrandID = int.Parse(reader["BrandID"].ToString());
                    oCSDCustomerSatisfaction.BrandDesc = (reader["BrandDesc"].ToString());

                    //oCSDCustomerSatisfaction.ID = int.Parse(reader["ID"].ToString());
                    //oCSDCustomerSatisfaction.Status = int.Parse(reader["Status"].ToString());
                    //oCSDCustomerSatisfaction.Remarks = (reader["Remarks"].ToString());
                    //oCSDCustomerSatisfaction.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    //oCSDCustomerSatisfaction.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDCustomerSatisfaction.IsHappyCall = Convert.ToInt32(reader["IsHappyCall"].ToString());
                    oCSDCustomerSatisfaction.Status = Convert.ToInt32(reader["Status"].ToString());

                    InnerList.Add(oCSDCustomerSatisfaction);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetDataByCustomerQuery(DateTime dFromDate, DateTime dToDate, string sInvoiceNo, string sConsumerName, string sMobileNo, int nIsHappyCall, int nWarehouseID, bool IsCheck, int nSalesType, string sCallStatus, int nIsBanforever)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {

                //sSql = "Select a.*,isnull(IsExchangeOffer,'No') as IsExchangeOffer from(Select * From  " +
                //    "(Select a.*,isnull(JobID,-1) JobID,isnull(JobNo,'') JobNo,IsHappyCall=Case when c.InvoiceID is null then 0 else 1 end,  " +
                //    "IsJob=Case when JobID is null then 0 else 1 end,isnull(InstallationRequired,'No') as InstallationRequired,Case when Status=1 then 'Satisfy' when Status=2 then 'Moderate' when Status=3 then 'Dissatisfy'when Status=4 then 'NoResponse' when Status=5 then 'BanForever' when Status=6 then 'CallBack' when Status=7 then 'NumBusy' else 'N/A' end as CallStatus  " +
                //    "From   " +
                //    "(Select a.WarehouseID,'['+ShowroomCode+']'+' '+ShowroomName as ShowroomCode,     " +
                //    "InvoiceID,InvoiceNo,SalesType,     " +
                //    "InvoiceDate,ConsumerCode,ConsumerName,b.Address as ConsumerAddress,     " +
                //    "CellNo as MobileNo,b.Email,InvoiceAmount,Discount      " +
                //    "from t_salesinvoice a, t_RetailConsumer b,t_Showroom c      " +
                //    "Where a.SundryCustomerID=b.ConsumerID      " +
                //    "and a.WarehouseID=b.WarehouseID and a.WarehouseID=c.WarehouseID      " +
                //    "and InvoiceDate >='01-Feb-2018' and      " +
                //    "InvoiceTypeID not in (6,7,8,9,10,11,12)) a  " +
                //    "left Outer join   " +
                //    "(Select InvoiceID,max(JobID) JobID,max(JobNo) JobNo From t_CSDJob a,t_SalesInvoiceProductSerial b  " +
                //    "where a.ProductSerialNo=b.ProductSerialNo and ServiceType=3 group by InvoiceID) b  " +
                //    "on a.InvoiceID=b.InvoiceID  " +
                //    "Left Outer Join     " +
                //    "(Select InvoiceID,Status From t_CSDCustomerSatisfactionInvoiceDetail a,t_CSDCustomerSatisfactionInvoice b where a.ID=b.ID group by InvoiceID,Status) c    " +
                //    "on a.InvoiceID=c.InvoiceID   " +
                //    "left Outer Join   " +
                //    "(Select distinct InvoiceNo,InstallationRequired From t_TDDeliveryShipmentItem a,t_TDDeliveryShipment b    " +
                //    "where a.ShipmentID=b.ShipmentID and a.WHID=b.WHID and InstallationRequired='Yes')  d    " +
                //    "on a.InvoiceNo=d.InvoiceNo    " +
                //    ") Main ) a Left Outer Join(Select InvoiceID,'Yes' IsExchangeOffer from t_SalesInvoicePaymentMode where PaymentModeID=11)b on a.InvoiceID=b.InvoiceID where 1=1 ";
                sSql = "Select * From  " +
                    "(  " +
                    "Select a.*,isnull(IsBanforever,0) IsBanforever, isnull(JobID, -1) JobID, isnull(JobNo, '') JobNo,  " +
                    "IsJob = Case when JobID is null then 0 else 1 end,  " +
                    "IsHappyCall = Case when c.InvoiceID is null then 0 else 1 end,  " +
                    "isnull(IsExchangeOffer, 'No') IsExchangeOffer, isnull(InstallationRequired, 'No') as InstallationRequired,  " +
                    "Case when c.Status = 1 then 'Satisfy'  " +
                    "when c.Status = 2 then 'Moderate'  " +
                    "when c.Status = 3 then 'Dissatisfy'  " +
                    "when c.Status = 4 then 'NoResponse'  " +
                    "when c.Status = 5 then 'CallBack'  " +
                    "when c.Status = 6 then 'NumBusy'  " +
                    "when c.Status = 7 then 'Switched_Off'   " +
                    "else 'N/A' end as CallStatus,isnull(c.Status,-1) Status  " +
                    "From  " +
                    "(  " +
                    "Select a.WarehouseID, ShowroomCode, InvoiceID,  " +
                    "InvoiceNo, SalesType, InvoiceDate, ConsumerCode,  " +
                    "ConsumerName, b.Address ConsumerAddress,b.CellNo as MobileNo,  " +
                    "b.Email, InvoiceAmount, Discount  " +
                    "from t_salesinvoice a, t_RetailConsumer b, t_Showroom c  " +
                    "Where a.SundryCustomerID = b.ConsumerID  " +
                    "and a.WarehouseID = b.WarehouseID and a.WarehouseID = c.WarehouseID  " +
                    "and InvoiceDate >= '01-Feb-2018' and  " +
                    "InvoiceTypeID not in (6, 7, 8, 9, 10, 11, 12)  " +
                    ") a  " +
                    "left Outer join  " +
                    "(  " +
                    "Select InvoiceID, max(JobID)JobID, max(JobNo) JobNo  " +
                    "From t_CSDJob a, t_SalesInvoiceProductSerial b  " +
                    "where a.ProductSerialNo = b.ProductSerialNo  " +
                    "and ServiceType = 3 group by InvoiceID  " +
                    ") b on a.InvoiceID = b.InvoiceID  " +
                    "Left outer Join  " +
                    "(  " +
                    "Select a.ID, InvoiceID, Remarks, Status,isnull(IsBanforever,0) IsBanforever From t_CSDCustomerSatisfactionInvoice a, (  " +
                    "Select max(ID) ID From t_CSDCustomerSatisfactionInvoice  " +
                    "where invoiceID is not null group by invoiceID) B  " +
                    "WHERE a.ID = b.ID  " +
                    ") c on a.InvoiceID = c.InvoiceID  " +
                    "Left Outer Join  " +
                    "(  " +
                    "Select InvoiceID, 'Yes' IsExchangeOffer  " +
                    "from t_SalesInvoicePaymentMode where PaymentModeID = 11  " +
                    ") d on a.InvoiceID = d.InvoiceID  " +
                    "Left Outer Join  " +
                    "(  " +
                    "Select distinct InvoiceNo, InstallationRequired  " +
                    "From t_TDDeliveryShipmentItem a, t_TDDeliveryShipment b  " +
                    "where a.ShipmentID = b.ShipmentID and a.WHID = b.WHID and  " +
                    "InstallationRequired = 'Yes'  " +
                    ") e on a.InvoiceNo = e.InvoiceNo  " +
                    ") Main where 1 = 1";
            }
            if (IsCheck == false)
            {
                sSql = sSql + "  AND InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate<'" + dToDate + "' ";
            }
            if (sInvoiceNo != "")
            {
                sSql = sSql + " AND InvoiceNo like '%" + sInvoiceNo + "%'";
            }
            if (sConsumerName != "")
            {
                sSql = sSql + " AND ConsumerName like '%" + sConsumerName + "%'";
            }
            if (sMobileNo != "")
            {
                sSql = sSql + " AND MobileNo like '%" + sMobileNo + "%'";
            }
            if (nIsHappyCall != -1)
            {
                sSql = sSql + " AND IsHappyCall =" + nIsHappyCall + "";
            }
            if (nWarehouseID != -1)
            {
                sSql = sSql + " AND WarehouseID =" + nWarehouseID + "";
            }
            if (nSalesType != -1)
            {
                sSql = sSql + " AND SalesType =" + nSalesType + "";
            }
            if (sCallStatus != "<All>")
            {
                sSql = sSql + " AND CallStatus = '" + sCallStatus + "'  ";
            }
            if (nIsBanforever != -1)
            {
                sSql = sSql + " AND IsBanforever =" + nIsBanforever + "";
            }

            sSql = sSql + "order by InvoiceID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDCustomerSatisfaction oCSDCustomerSatisfaction = new CSDCustomerSatisfaction();
                    oCSDCustomerSatisfaction.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oCSDCustomerSatisfaction.ShowroomCode = (reader["ShowroomCode"].ToString());
                    oCSDCustomerSatisfaction.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    oCSDCustomerSatisfaction.InvoiceNo = (reader["InvoiceNo"].ToString());
                    oCSDCustomerSatisfaction.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oCSDCustomerSatisfaction.ConsumerCode = (reader["ConsumerCode"].ToString());
                    oCSDCustomerSatisfaction.ConsumerName = (reader["ConsumerName"].ToString());
                    oCSDCustomerSatisfaction.Address = (reader["ConsumerAddress"].ToString());
                    oCSDCustomerSatisfaction.Mobile = (reader["MobileNo"].ToString());
                    oCSDCustomerSatisfaction.Email = (reader["Email"].ToString());
                    oCSDCustomerSatisfaction.InvoiceAmount = double.Parse(reader["InvoiceAmount"].ToString());
                    oCSDCustomerSatisfaction.Discount = double.Parse(reader["Discount"].ToString());
                    oCSDCustomerSatisfaction.IsHappyCall = int.Parse(reader["IsHappyCall"].ToString());
                    oCSDCustomerSatisfaction.IsJob = int.Parse(reader["IsJob"].ToString());
                    oCSDCustomerSatisfaction.JobNo = (reader["JobNo"].ToString());
                    oCSDCustomerSatisfaction.InstallationRequired = (reader["InstallationRequired"].ToString());
                    oCSDCustomerSatisfaction.IsExchangeOffer = (reader["IsExchangeOffer"].ToString());
                    oCSDCustomerSatisfaction.CallStatus = (reader["CallStatus"].ToString());
                    oCSDCustomerSatisfaction.SalesType = int.Parse(reader["SalesType"].ToString());
                    oCSDCustomerSatisfaction.IsBanforever = int.Parse(reader["IsBanforever"].ToString());
                    oCSDCustomerSatisfaction.Status = int.Parse(reader["Status"].ToString());
                    InnerList.Add(oCSDCustomerSatisfaction);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetDataByCustomerQueryInvoiceWise(int nInvoiceID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            //dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select a.InvoiceID,a.ProductID,ProductCode,ProductName,AGName, Quantity as Qty,FreeQty, " +
                        "ASGName,MAGID,MAGName,PGName,BrandDesc,ProductSerialNo " +
                        "From t_SalesInvoiceDetail a,v_ProductDetails b,t_SalesInvoiceProductSerial c " +
                        "where a.ProductID=b.ProductID and a.InvoiceID=c.InvoiceID and a.InvoiceID=" + nInvoiceID + " and a.ProductID=c.ProductID";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDCustomerSatisfaction oCSDCustomerSatisfaction = new CSDCustomerSatisfaction();


                    oCSDCustomerSatisfaction.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    oCSDCustomerSatisfaction.ProductID = int.Parse(reader["ProductID"].ToString());
                    oCSDCustomerSatisfaction.ProductCode = (reader["productCode"].ToString());
                    oCSDCustomerSatisfaction.ProductName = (reader["ProductName"].ToString());
                    oCSDCustomerSatisfaction.AGName = (reader["AGName"].ToString());
                    oCSDCustomerSatisfaction.ASGName = (reader["ASGName"].ToString());
                    oCSDCustomerSatisfaction.MAGID = int.Parse(reader["MAGID"].ToString());
                    oCSDCustomerSatisfaction.Qty = int.Parse(reader["Qty"].ToString());
                    oCSDCustomerSatisfaction.FreeQty = int.Parse(reader["FreeQty"].ToString());
                    oCSDCustomerSatisfaction.MAGName = (reader["MAGName"].ToString());
                    oCSDCustomerSatisfaction.PGName = (reader["PGName"].ToString());
                    oCSDCustomerSatisfaction.BrandDesc = (reader["BrandDesc"].ToString());
                    oCSDCustomerSatisfaction.ProductSerialNo = (reader["ProductSerialNo"].ToString());

                    InnerList.Add(oCSDCustomerSatisfaction);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetFreeQty(int nInvoiceID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            {
                sSql = "Select ProductCode,ProductName,FreeQty From t_SalesInvoiceDetail a,t_Product b where a.ProductID = b.ProductID and FreeQty> 0 and InvoiceID = " + nInvoiceID + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDCustomerSatisfaction oCSDCustomerSatisfaction = new CSDCustomerSatisfaction();
                    oCSDCustomerSatisfaction.ProductCode = (reader["ProductCode"].ToString());
                    oCSDCustomerSatisfaction.ProductName = (reader["ProductName"].ToString());
                    oCSDCustomerSatisfaction.FreeQty = int.Parse(reader["FreeQty"].ToString());
                    InnerList.Add(oCSDCustomerSatisfaction);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetDatabyNewID(int nID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select JobID,Status,Remarks,CreateUserID,CreateDate " +
                        "From dbo.t_CSDCustomerSatisfactionInvoice a,dbo.t_CSDCustomerSatisfactionInvoiceDetail b " +
                        "where a.ID=b.ID and a.ID=" + nID + " and JobID<>-1 group by JobID,Status,Remarks,CreateUserID,CreateDate";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDCustomerSatisfaction oCSDCustomerSatisfaction = new CSDCustomerSatisfaction();
                    oCSDCustomerSatisfaction.JobID = (int)reader["JobID"];
                    oCSDCustomerSatisfaction.Status = (int)reader["Status"];
                    oCSDCustomerSatisfaction.Remarks = (string)reader["Remarks"];
                    oCSDCustomerSatisfaction.CreateUserID = (int)reader["CreateUserID"];
                    oCSDCustomerSatisfaction.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oCSDCustomerSatisfaction);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetItembyJobID(int nJobID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select c.ID as QuestionID,Marks From t_CSDCustomerSatisfactionInvoiceDetail a,t_CSDCustomerSatisfactionQuestionMapping b,t_CSDCustomerSatisfactionQuestioner c  " +
                        "where a.QuestionID=b.QuestionID and b.OldQuestionID=c.ID and JobID=" + nJobID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDCustomerSatisfactionDetail oItem = new CSDCustomerSatisfactionDetail();
                    oItem.QuestionID = (int)reader["QuestionID"];
                    oItem.Mark = (int)reader["Marks"];
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

        public void GetDiscountByInvID(int nInvoiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select isnull(DiscountTypeName,'') DiscountTypeName,isnull(Amount,0) Amount From " +
                        "( " +
                        "Select InvoiceID, DiscountTypeName, sum(Amount) Amount " +
                        "From t_SalesInvoiceDiscount a, t_SalesInvoiceDiscountType b " +
                        "where a.DiscountTypeID = b.DiscountTypeID and Type = 0 " +
                        "and a.DiscountTypeID <> 6 group by InvoiceID, DiscountTypeName " +
                        "Union All " +
                        "Select InvoiceID, DiscountTypeName, sum(Amount) Amount " +
                        "from t_SalesInvoiceDiscountChargeMap a, " +
                        "( " +
                        "Select 6 as DiscountTypeID, BankDiscountID, " +
                        "Name + ' ' + cast(DiscountPercent as varchar) + '% Discount' as DiscountTypeName " +
                        "From t_PromoDiscountBank a, t_Bank b " +
                        "where a.BankID = b.BankID " +
                        ") b,t_SalesInvoice c " +
                        "where a.DiscountTypeID = 6 and a.DiscountTypeID = b.DiscountTypeID and a.InvoiceNo = c.InvoiceNo " +
                        "and a.DataID = b.BankDiscountID group by InvoiceID,DiscountTypeName " +
                        ") a where  InvoiceID = " + nInvoiceID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDCustomerSatisfaction oItem = new CSDCustomerSatisfaction();
                    oItem.DiscountTypeName = (string)reader["DiscountTypeName"];
                    oItem.DisorChrAmt = (double)reader["Amount"];
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

        public void GetChargeByInvID(int nInvoiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select isnull(DiscountTypeName,'') DiscountTypeName,isnull(Amount,0) Amount From " +
                        "(  " +
                        "Select InvoiceID, DiscountTypeName, sum(Amount)Amount  " +
                        "From t_SalesInvoiceDiscount a, t_SalesInvoiceDiscountType b  " +
                        "where a.DiscountTypeID = b.DiscountTypeID and Type = 1  " +
                        "and a.DiscountTypeID <> 8 group by a.DiscountTypeID, InvoiceID, DiscountTypeName  " +
                        "Union All  " +
                        "Select InvoiceID, Name + ' Extended EMI Charge' as DiscountTypeName, ExtendedEMICharge  " +
                        "From t_SalesInvoicePaymentModeNew a, t_Bank b  " +
                        "where ExtendedEMICharge > 0 and a.BankID = b.BankID  " +
                        ") A where InvoiceID = " + nInvoiceID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDCustomerSatisfaction oItem = new CSDCustomerSatisfaction();
                    oItem.DiscountTypeName = (string)reader["DiscountTypeName"];
                    oItem.DisorChrAmt = (double)reader["Amount"];
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
}


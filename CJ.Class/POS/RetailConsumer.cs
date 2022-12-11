// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: April 11, 2012
// Time :  04:00 PM
// Description: Class for Retail Consumer.
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;


namespace CJ.Class.POS
{
    public class RetailConsumer
    {
        private int _ConsumerID;
        private string _ConsumerCode;
        private string _ConsumerName;
        private int _ConsumerType;
        private int _WarehouseID;
        private int _CustomerID;
        private int _nParentCustomerID;
        private string _Address;
        private string _CellNo;
        private string _PhoneNo;
        private string _Email;
        private string _NationalID;
        private object _DateofBirth;
        private string _VatRegNo;
        private string _ShortName;
        private string _FatherName;
        private string _MotherName;
        private string _SpouseName;
        private string _PermanentAddress;
        private string _Nationality;
        private string _PassportNo;
        private int _IsCLP;
        private int _CurrentCLP;
        private int _IsRegister;
        private int _IsAuthorized;
        private int _nIsVerifiedEmail;
        
        private bool _bFlag;
        private string _sEmployeeCode;


        private string _sCustomerCode;
        private string _sCustomerName;
        private string _sProductCode;
        private string _sProductName;
        private int _nAGID;
        private string _sAGName;
        private int _nASGID;
        private string _sASGName;
        private int _nMAGID;
        private string _sMAGName;
        private int _nPGID;
        private string _sPGName;
        private string _sInvoiceNo;
        private DateTime _dInvoiceDate;
        private double _Amount;
        private int _nSalesQty;
        private string _sDeliveryAddress;
        private int _nRetailConsumerID;
        public int RetailConsumerID
        {
            get { return _nRetailConsumerID; }
            set { _nRetailConsumerID = value; }
        }
        private string _sRetailConsumerCode;
        public string RetailConsumerCode
        {
            get { return _sRetailConsumerCode; }
            set { _sRetailConsumerCode = value.Trim(); }
        }
        private string _sRetailConsumerName;
        public string RetailConsumerName
        {
            get { return _sRetailConsumerName; }
            set { _sRetailConsumerName = value.Trim(); }
        }
        public int IsVerifiedEmail
        {
            get { return _nIsVerifiedEmail; }
            set { _nIsVerifiedEmail = value; }
        }
        public string DeliveryAddress
        {
            get { return _sDeliveryAddress; }
            set { _sDeliveryAddress = value.Trim(); }
        }

        /// <summary>
        /// Get set property for CustomerCode
        /// </summary>
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
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
        /// Get set property for ProductCode
        /// </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }
        /// <summary>
        /// Get set property for ProductName
        /// </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for AGID
        /// </summary>
        public int AGID
        {
            get { return _nAGID; }
            set { _nAGID = value; }
        }
        /// <summary>
        /// Get set property for AGName
        /// </summary>
        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for ASGID
        /// </summary>
        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }
        /// <summary>
        /// Get set property for ASGName
        /// </summary>
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for MAGID
        /// </summary>
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }
        /// <summary>
        /// Get set property for MAGName
        /// </summary>
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for PGID
        /// </summary>
        public int PGID
        {
            get { return _nPGID; }
            set { _nPGID = value; }
        }
        /// <summary>
        /// Get set property for AGName
        /// </summary>
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value.Trim(); }
        }

        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }

        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }

        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        public int SalesQty
        {
            get { return _nSalesQty; }
            set { _nSalesQty = value; }
        }


        DataTran _oDataTran;
        SystemInfo _oSystemInfo;

        /// <summary>
        /// Get set property for ConsumerID
        /// </summary>
        public int ConsumerID
        {
            get { return _ConsumerID; }
            set { _ConsumerID = value; }
        }
        private long _nInvoiceID;
        public long InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
        }

        /// <summary>
        /// Get set property for ConsumerCode
        /// </summary>
        public string ConsumerCode
        {
            get { return _ConsumerCode; }
            set { _ConsumerCode = value.Trim(); }
        }

        /// <summary>
        /// Get set property for ConsumerName
        /// </summary>
        public string ConsumerName
        {
            get { return _ConsumerName; }
            set { _ConsumerName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for ConsumerType
        /// </summary>
        public int ConsumerType
        {
            get { return _ConsumerType; }
            set { _ConsumerType = value; }
        }

        private string _sSecondaryConsumer;
        public string SecondaryConsumer
        {
            get { return _sSecondaryConsumer; }
            set { _sSecondaryConsumer = value.Trim(); }
        }
        private string _sSecondaryMobileNo;
        public string SecondaryMobileNo
        {
            get { return _sSecondaryMobileNo; }
            set { _sSecondaryMobileNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for WarehouseID
        /// </summary>
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        private int _nMotherConsumerID;
        public int MotherConsumerID
        {
            get { return _nMotherConsumerID; }
            set { _nMotherConsumerID = value; }
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
        /// Get set property for WarehouseID
        /// </summary>
        public int WarehouseID
        {
            get { return _WarehouseID; }
            set { _WarehouseID = value; }
        }

        /// <summary>
        /// Get set property for Address
        /// </summary>
        public string Address
        {
            get { return _Address; }
            set { _Address = value.Trim(); }
        }

        /// <summary>
        /// Get set property for CellNo
        /// </summary>
        public string CellNo
        {
            get { return _CellNo; }
            set { _CellNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for PhoneNo
        /// </summary>
        public string PhoneNo
        {
            get { return _PhoneNo; }
            set { _PhoneNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for Email
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set { _Email = value.Trim(); }
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
        /// Get set property for DateofBirth
        /// </summary>
        public object DateofBirth
        {
            get { return _DateofBirth; }
            set { _DateofBirth = value; }
        }

        /// <summary>
        /// Get set property for VatRegNo
        /// </summary>
        public string VatRegNo
        {
            get { return _VatRegNo; }
            set { _VatRegNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for ShortName
        /// </summary>
        public string ShortName
        {
            get { return _ShortName; }
            set { _ShortName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for FatherName
        /// </summary>
        public string FatherName
        {
            get { return _FatherName; }
            set { _FatherName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for MotherName
        /// </summary>
        public string MotherName
        {
            get { return _MotherName; }
            set { _MotherName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for SpouseName
        /// </summary>
        public string SpouseName
        {
            get { return _SpouseName; }
            set { _SpouseName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for PermanentAddress
        /// </summary>
        public string PermanentAddress
        {
            get { return _PermanentAddress; }
            set { _PermanentAddress = value.Trim(); }
        }

        /// <summary>
        /// Get set property for Nationality
        /// </summary>
        public string Nationality
        {
            get { return _Nationality; }
            set { _Nationality = value.Trim(); }
        }

        /// <summary>
        /// Get set property for PassportNo
        /// </summary>
        public string PassportNo
        {
            get { return _PassportNo; }
            set { _PassportNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for IsCLP
        /// </summary>
        public int IsCLP
        {
            get { return _IsCLP; }
            set { _IsCLP = value; }
        }

        /// <summary>
        /// Get set property for CurrentCLP
        /// </summary>
        public int CurrentCLP
        {
            get { return _CurrentCLP; }
            set { _CurrentCLP = value; }
        }

        /// <summary>
        /// Get set property for IsRegister
        /// </summary>
        public int IsRegister
        {
            get { return _IsRegister; }
            set { _IsRegister = value; }
        }

        /// <summary>
        /// Get set property for IsAuthorized
        /// </summary>
        public int IsAuthorized
        {
            get { return _IsAuthorized; }
            set { _IsAuthorized = value; }
        }
        private Warehouse _oWarehouse;
        public Warehouse Warehouse
        {
            get
            {
                if (_oWarehouse == null)
                {
                    _oWarehouse = new Warehouse();

                }
                return _oWarehouse;
            }
        }
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value; }
        }
        private int _nSalesType;
        public int SalesType
        {
            get { return _nSalesType; }
            set { _nSalesType = value; }
        }
        private string _sSalesTypeName;
        public string SalesTypeName
        {
            get { return _sSalesTypeName; }
            set { _sSalesTypeName = value; }
        }

        public void Add()
        {
            int nMaxCustomerID = 0;
            int nMaxCustomerCode = 0;

            // Adding Sundry Customer Information 

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Select Max([ConsumerID]) From t_RetailConsumer";
                cmd.CommandText = sSql;
                object _oMaxCustomerID = cmd.ExecuteScalar();

                if (_oMaxCustomerID == DBNull.Value)
                {
                    nMaxCustomerID = 1;

                }
                else
                {
                    nMaxCustomerID = Convert.ToInt32(_oMaxCustomerID) + 1;

                }

                _ConsumerID = nMaxCustomerID;

                _oSystemInfo=new SystemInfo();
                _oSystemInfo.Refresh();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([NextCustomerCode]) FROM t_NextDocumentNo where WarehouseID='" + _oSystemInfo.WarehouseID + "'";
                cmd.CommandText = sSql;
                object MaxCustomerCode = cmd.ExecuteScalar();
                if (MaxCustomerCode == DBNull.Value)
                {
                    nMaxCustomerCode = 100001;
                }
                else
                {
                    nMaxCustomerCode = int.Parse(MaxCustomerCode.ToString());

                }
                _ConsumerCode = _oSystemInfo.Shortcode + "-" + nMaxCustomerCode.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = "insert into t_RetailConsumer (ConsumerID,ConsumerCode,ConsumerName,ConsumerType,CustomerID, " +
                "ParentCustomerID, Address,CellNo,PhoneNo,Email,EmployeeCode,NationalID,DateofBirth,VatRegNo,ShortName,FatherName,MotherName, " +
                "SpouseName,PermanentAddress,Nationality,PassportNo,IsCLP,CurrentCLP,IsRegister,IsAuthorized,SalesType,IsVerifiedEmail,SecondaryConsumer,SecondaryMobileNo)  " +
                "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
                cmd.Parameters.AddWithValue("ConsumerCode", _ConsumerCode);
                cmd.Parameters.AddWithValue("ConsumerName", _ConsumerName);
                cmd.Parameters.AddWithValue("ConsumerType", _ConsumerType);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("ParentCustomerID", _nParentCustomerID);
                cmd.Parameters.AddWithValue("Address", _Address);
                cmd.Parameters.AddWithValue("CellNo", _CellNo);
                cmd.Parameters.AddWithValue("PhoneNo", _PhoneNo);
                cmd.Parameters.AddWithValue("Email", _Email);
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("NationalID", _NationalID);
                if (_DateofBirth != null)
                    cmd.Parameters.AddWithValue("DateofBirth", Convert.ToDateTime(_DateofBirth));
                else cmd.Parameters.AddWithValue("DateofBirth", null);
                cmd.Parameters.AddWithValue("VatRegNo", _VatRegNo);
                cmd.Parameters.AddWithValue("ShortName", null);
                cmd.Parameters.AddWithValue("FatherName", null);
                cmd.Parameters.AddWithValue("MotherName", null);
                cmd.Parameters.AddWithValue("SpouseName", null);
                cmd.Parameters.AddWithValue("PermanentAddress", null);
                cmd.Parameters.AddWithValue("Nationality ", null);
                cmd.Parameters.AddWithValue("PassportNo", null);
                cmd.Parameters.AddWithValue("IsCLP ", 0);
                cmd.Parameters.AddWithValue("CurrentCLP", null);
                cmd.Parameters.AddWithValue("IsRegister ", 0);
                cmd.Parameters.AddWithValue("IsAuthorized", 0);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("IsVerifiedEmail", _nIsVerifiedEmail);

                cmd.Parameters.AddWithValue("SecondaryConsumer", _sSecondaryConsumer);
                cmd.Parameters.AddWithValue("SecondaryMobileNo", _sSecondaryMobileNo);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
                nMaxCustomerCode = nMaxCustomerCode + 1;
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_NextDocumentNo set NextCustomerCode='" + nMaxCustomerCode + "'  where WarehouseID='" + _oSystemInfo.WarehouseID + "'";
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                _oDataTran = new DataTran();
                _oDataTran.TableName = "t_RetailConsumer";
                _oDataTran.DataID = _ConsumerID;
                _oDataTran.WarehouseID = _oSystemInfo.WarehouseID;
                _oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                _oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                _oDataTran.BatchNo = 0;
                _oDataTran.CreateDate = Convert.ToDateTime(_oSystemInfo.OperationDate);
                _oDataTran.AddForTDPOS();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void AddRT()
        { 
            int nMaxCustomerID = 0;
            int nNextConsumerCode = 0;

            // Adding Sundry Customer Information 

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Select Max([ConsumerID]) From t_RetailConsumer where WarehouseID=" + Utility.WarehouseID + "";
                cmd.CommandText = sSql;
                object _oMaxCustomerID = cmd.ExecuteScalar();

                if (_oMaxCustomerID == DBNull.Value)
                {
                    nMaxCustomerID = 1;

                }
                else
                {
                    nMaxCustomerID = Convert.ToInt32(_oMaxCustomerID) + 1;

                }

                _ConsumerID = nMaxCustomerID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([NextConsumerCode]) FROM t_Showroom where WarehouseID='" + Utility.WarehouseID + "'";
                cmd.CommandText = sSql;
                object NextConsumerCode = cmd.ExecuteScalar();
                if (NextConsumerCode == DBNull.Value)
                {
                    nNextConsumerCode = 100001;
                }
                else
                {
                    nNextConsumerCode = int.Parse(NextConsumerCode.ToString());

                }
                _ConsumerCode = Utility.Shortcode + "-" + nNextConsumerCode.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = "insert into t_RetailConsumer (ConsumerID,ConsumerCode,ConsumerName,ConsumerType,CustomerID, " +
                "ParentCustomerID, Address,CellNo,PhoneNo,Email,EmployeeCode,NationalID,DateofBirth,VatRegNo,ShortName,FatherName,MotherName, " +
                "SpouseName,PermanentAddress,Nationality,PassportNo,IsCLP,CurrentCLP,IsRegister,IsAuthorized,SalesType,IsVerifiedEmail,SecondaryConsumer,SecondaryMobileNo,WarehouseID)  " +
                "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
                cmd.Parameters.AddWithValue("ConsumerCode", _ConsumerCode);
                cmd.Parameters.AddWithValue("ConsumerName", _ConsumerName);
                cmd.Parameters.AddWithValue("ConsumerType", _ConsumerType);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("ParentCustomerID", _nParentCustomerID);
                cmd.Parameters.AddWithValue("Address", _Address);
                cmd.Parameters.AddWithValue("CellNo", _CellNo);
                cmd.Parameters.AddWithValue("PhoneNo", _PhoneNo);
                cmd.Parameters.AddWithValue("Email", _Email);
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("NationalID", _NationalID);
                if (_DateofBirth != null)
                    cmd.Parameters.AddWithValue("DateofBirth", Convert.ToDateTime(_DateofBirth));
                else cmd.Parameters.AddWithValue("DateofBirth", null);
                cmd.Parameters.AddWithValue("VatRegNo", _VatRegNo);
                cmd.Parameters.AddWithValue("ShortName", null);
                cmd.Parameters.AddWithValue("FatherName", null);
                cmd.Parameters.AddWithValue("MotherName", null);
                cmd.Parameters.AddWithValue("SpouseName", null);
                cmd.Parameters.AddWithValue("PermanentAddress", null);
                cmd.Parameters.AddWithValue("Nationality ", null);
                cmd.Parameters.AddWithValue("PassportNo", null);
                cmd.Parameters.AddWithValue("IsCLP ", 0);
                cmd.Parameters.AddWithValue("CurrentCLP", null);
                cmd.Parameters.AddWithValue("IsRegister ", 0);
                cmd.Parameters.AddWithValue("IsAuthorized", 0);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("IsVerifiedEmail", _nIsVerifiedEmail);

                cmd.Parameters.AddWithValue("SecondaryConsumer", _sSecondaryConsumer);
                cmd.Parameters.AddWithValue("SecondaryMobileNo", _sSecondaryMobileNo);
                cmd.Parameters.AddWithValue("WarehouseID", Utility.WarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                nNextConsumerCode = nNextConsumerCode + 1;
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_Showroom set NextConsumerCode='" + nNextConsumerCode + "'  where WarehouseID='" + _WarehouseID + "'";
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        } 
        public void AddNewRetailConsumer()
        {
            int nMaxCustomerID = 0;
            int nMaxCustomerCode = 0;

            // Adding Sundry Customer Information 

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Select Max([ConsumerID]) From t_RetailConsumer";
                cmd.CommandText = sSql;
                object _oMaxCustomerID = cmd.ExecuteScalar();

                if (_oMaxCustomerID == DBNull.Value)
                {
                    nMaxCustomerID = 1;

                }
                else
                {
                    nMaxCustomerID = Convert.ToInt32(_oMaxCustomerID) + 1;

                }

                _ConsumerID = nMaxCustomerID;

                _oSystemInfo = new SystemInfo();
                _oSystemInfo.Refresh();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([NextCustomerCode]) FROM t_NextDocumentNo where WarehouseID='" + _oSystemInfo.WarehouseID + "'";
                cmd.CommandText = sSql;
                object MaxCustomerCode = cmd.ExecuteScalar();
                if (MaxCustomerCode == DBNull.Value)
                {
                    nMaxCustomerCode = 100001;
                }
                else
                {
                    nMaxCustomerCode = int.Parse(MaxCustomerCode.ToString());

                }
                _ConsumerCode = _oSystemInfo.Shortcode + "-" + nMaxCustomerCode.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = "insert into t_RetailConsumer (ConsumerID,ConsumerCode,ConsumerName,ConsumerType,CustomerID, " +
                "ParentCustomerID, Address,CellNo,PhoneNo,Email,EmployeeCode,NationalID,DateofBirth,VatRegNo,ShortName,FatherName,MotherName, " +
                "SpouseName,PermanentAddress,Nationality,PassportNo,IsCLP,CurrentCLP,IsRegister,IsAuthorized,SalesType, DeliveryAddress)  " +
                "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
                cmd.Parameters.AddWithValue("ConsumerCode", _ConsumerCode);
                cmd.Parameters.AddWithValue("ConsumerName", _ConsumerName);
                cmd.Parameters.AddWithValue("ConsumerType", _ConsumerType);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("ParentCustomerID", _nParentCustomerID);
                cmd.Parameters.AddWithValue("Address", _Address);
                cmd.Parameters.AddWithValue("CellNo", _CellNo);
                cmd.Parameters.AddWithValue("PhoneNo", _PhoneNo);
                cmd.Parameters.AddWithValue("Email", _Email);
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("NationalID", _NationalID);
                if (_DateofBirth != null)
                    cmd.Parameters.AddWithValue("DateofBirth", Convert.ToDateTime(_DateofBirth));
                else cmd.Parameters.AddWithValue("DateofBirth", null);
                cmd.Parameters.AddWithValue("VatRegNo", _VatRegNo);
                if (_ShortName != null)
                    cmd.Parameters.AddWithValue("ShortName", _ShortName);
                else cmd.Parameters.AddWithValue("ShortName", null);

                if(_FatherName!=null)
                cmd.Parameters.AddWithValue("FatherName", _FatherName);
                else cmd.Parameters.AddWithValue("FatherName", null);
                if (_MotherName != null)
                    cmd.Parameters.AddWithValue("MotherName", _MotherName);
                else cmd.Parameters.AddWithValue("MotherName", _MotherName);
                if (_SpouseName != null)
                    cmd.Parameters.AddWithValue("SpouseName", _SpouseName);
                else cmd.Parameters.AddWithValue("SpouseName", null);
                if (_PermanentAddress != null)
                    cmd.Parameters.AddWithValue("PermanentAddress", _PermanentAddress);
                else cmd.Parameters.AddWithValue("PermanentAddress", null);
                if (_Nationality != null)
                    cmd.Parameters.AddWithValue("Nationality ", _Nationality);
                else cmd.Parameters.AddWithValue("Nationality ", null);
                if (_PassportNo != null)
                    cmd.Parameters.AddWithValue("PassportNo", _PassportNo);
                else cmd.Parameters.AddWithValue("PassportNo", null);
                cmd.Parameters.AddWithValue("IsCLP ", 0);
                cmd.Parameters.AddWithValue("CurrentCLP", _CurrentCLP);
                cmd.Parameters.AddWithValue("IsRegister ", 0);
                cmd.Parameters.AddWithValue("IsAuthorized", 0);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                nMaxCustomerCode = nMaxCustomerCode + 1;
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_NextDocumentNo set NextCustomerCode='" + nMaxCustomerCode + "'  where WarehouseID='" + _oSystemInfo.WarehouseID + "'";
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                _oDataTran = new DataTran();
                _oDataTran.TableName = "t_RetailConsumer";
                _oDataTran.DataID = _ConsumerID;
                _oDataTran.WarehouseID = _oSystemInfo.WarehouseID;
                _oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                _oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                _oDataTran.BatchNo = 0;
                _oDataTran.CreateDate = Convert.ToDateTime(_oSystemInfo.OperationDate);
                _oDataTran.AddForTDPOS();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public string GetMaxConsumerCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nMaxCustomerCode = 0;
            try
            {

                string sSql = "SELECT NextConsumerCode FROM t_Showroom where WarehouseID='" + Utility.WarehouseID + "'";
                cmd.CommandText = sSql;
                object MaxCustomerCode = cmd.ExecuteScalar();
                if (MaxCustomerCode == DBNull.Value)
                {
                    nMaxCustomerCode = 100001;
                }
                else
                {
                    nMaxCustomerCode = int.Parse(MaxCustomerCode.ToString());

                }
                _ConsumerCode = Utility.Shortcode + "-" + nMaxCustomerCode.ToString();
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _ConsumerCode;

        }
        public int AddNewRetailConsumerRT()
        {
            int nMaxCustomerID = 0;
            int nMaxCustomerCode = 0;


            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Select Max([ConsumerID]) From t_RetailConsumer where WarehouseID=" + Utility.WarehouseID + "";
                cmd.CommandText = sSql;
                object _oMaxCustomerID = cmd.ExecuteScalar();

                if (_oMaxCustomerID == DBNull.Value)
                {
                    nMaxCustomerID = 1;

                }
                else
                {
                    nMaxCustomerID = Convert.ToInt32(_oMaxCustomerID) + 1;

                }

                _ConsumerID = nMaxCustomerID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT NextConsumerCode FROM t_Showroom where WarehouseID='" + _WarehouseID + "'";
                cmd.CommandText = sSql;
                object MaxCustomerCode = cmd.ExecuteScalar();
                if (MaxCustomerCode == DBNull.Value)
                {
                    nMaxCustomerCode = 100001;
                }
                else
                {
                    nMaxCustomerCode = int.Parse(MaxCustomerCode.ToString());

                }
                _ConsumerCode = Utility.Shortcode + "-" + nMaxCustomerCode.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = "insert into t_RetailConsumer (ConsumerID,ConsumerCode,ConsumerName,ConsumerType,CustomerID, " +
                "ParentCustomerID, Address,CellNo,PhoneNo,Email,EmployeeCode,NationalID,DateofBirth,VatRegNo,ShortName,FatherName,MotherName, " +
                "SpouseName,PermanentAddress,Nationality,PassportNo,IsCLP,CurrentCLP,IsRegister,IsAuthorized,SalesType, DeliveryAddress,WarehouseID,IsVerifiedEmail,SecondaryConsumer,SecondaryMobileNo,MotherConsumerID)  " +
                "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
                cmd.Parameters.AddWithValue("ConsumerCode", _ConsumerCode);
                cmd.Parameters.AddWithValue("ConsumerName", _ConsumerName);
                cmd.Parameters.AddWithValue("ConsumerType", _ConsumerType);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("ParentCustomerID", _nParentCustomerID);
                cmd.Parameters.AddWithValue("Address", _Address);
                cmd.Parameters.AddWithValue("CellNo", _CellNo);
                cmd.Parameters.AddWithValue("PhoneNo", _PhoneNo);
                cmd.Parameters.AddWithValue("Email", _Email);
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("NationalID", _NationalID);
                if (_DateofBirth != null)
                    cmd.Parameters.AddWithValue("DateofBirth", Convert.ToDateTime(_DateofBirth));
                else cmd.Parameters.AddWithValue("DateofBirth", null);
                cmd.Parameters.AddWithValue("VatRegNo", _VatRegNo);
                if (_ShortName != null)
                    cmd.Parameters.AddWithValue("ShortName", _ShortName);
                else cmd.Parameters.AddWithValue("ShortName", null);

                if (_FatherName != null)
                    cmd.Parameters.AddWithValue("FatherName", _FatherName);
                else cmd.Parameters.AddWithValue("FatherName", null);
                if (_MotherName != null)
                    cmd.Parameters.AddWithValue("MotherName", _MotherName);
                else cmd.Parameters.AddWithValue("MotherName", _MotherName);
                if (_SpouseName != null)
                    cmd.Parameters.AddWithValue("SpouseName", _SpouseName);
                else cmd.Parameters.AddWithValue("SpouseName", null);
                if (_PermanentAddress != null)
                    cmd.Parameters.AddWithValue("PermanentAddress", _PermanentAddress);
                else cmd.Parameters.AddWithValue("PermanentAddress", null);
                if (_Nationality != null)
                    cmd.Parameters.AddWithValue("Nationality ", _Nationality);
                else cmd.Parameters.AddWithValue("Nationality ", null);
                if (_PassportNo != null)
                    cmd.Parameters.AddWithValue("PassportNo", _PassportNo);
                else cmd.Parameters.AddWithValue("PassportNo", null);
                cmd.Parameters.AddWithValue("IsCLP ", 0);
                cmd.Parameters.AddWithValue("CurrentCLP", _CurrentCLP);
                cmd.Parameters.AddWithValue("IsRegister ", 0);
                cmd.Parameters.AddWithValue("IsAuthorized", 0);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("WarehouseID", _WarehouseID);

                if (_nIsVerifiedEmail != null)
                    cmd.Parameters.AddWithValue("IsVerifiedEmail", _nIsVerifiedEmail);
                else cmd.Parameters.AddWithValue("IsVerifiedEmail", 0);

                if (_sSecondaryConsumer != null)
                    cmd.Parameters.AddWithValue("SecondaryConsumer", _sSecondaryConsumer);
                else cmd.Parameters.AddWithValue("SecondaryConsumer", null);

                if (_sSecondaryMobileNo != null)
                    cmd.Parameters.AddWithValue("SecondaryMobileNo", _sSecondaryMobileNo);
                else cmd.Parameters.AddWithValue("SecondaryMobileNo", null);
                cmd.Parameters.AddWithValue("MotherConsumerID", _nMotherConsumerID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                nMaxCustomerCode = nMaxCustomerCode + 1;
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_Showroom set NextCustomerCode='" + nMaxCustomerCode + "'  where WarehouseID='" + _WarehouseID + "'";
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _ConsumerID;
        }
        public void AddNewRetailConsumerRTNew()
        {
            int nMaxCustomerID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select Max([ConsumerID]) From t_RetailConsumer where WarehouseID=" + Utility.WarehouseID + "";
            cmd.CommandText = sSql;
            object _oMaxCustomerID = cmd.ExecuteScalar();

            if (_oMaxCustomerID == DBNull.Value)
            {
                nMaxCustomerID = 1;

            }
            else
            {
                nMaxCustomerID = Convert.ToInt32(_oMaxCustomerID) + 1;

            }

            _ConsumerID = nMaxCustomerID;

            cmd.Dispose();
            cmd = DBController.Instance.GetCommand();
            
            try
            {
               
                sSql = "insert into t_RetailConsumer (ConsumerID,ConsumerCode,ConsumerName,ConsumerType,CustomerID, " +
                "ParentCustomerID, Address,CellNo,PhoneNo,Email,EmployeeCode,NationalID,DateofBirth,VatRegNo,ShortName,FatherName,MotherName, " +
                "SpouseName,PermanentAddress,Nationality,PassportNo,IsCLP,CurrentCLP,IsRegister,IsAuthorized,SalesType, DeliveryAddress,WarehouseID,IsVerifiedEmail,SecondaryConsumer,SecondaryMobileNo,MotherConsumerID)  " +
                "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
                cmd.Parameters.AddWithValue("ConsumerCode", _ConsumerCode);
                cmd.Parameters.AddWithValue("ConsumerName", _ConsumerName);
                cmd.Parameters.AddWithValue("ConsumerType", _ConsumerType);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("ParentCustomerID", _nParentCustomerID);
                cmd.Parameters.AddWithValue("Address", _Address);
                cmd.Parameters.AddWithValue("CellNo", _CellNo);
                cmd.Parameters.AddWithValue("PhoneNo", _PhoneNo);
                cmd.Parameters.AddWithValue("Email", _Email);
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("NationalID", _NationalID);
                if (_DateofBirth != null)
                    cmd.Parameters.AddWithValue("DateofBirth", Convert.ToDateTime(_DateofBirth));
                else cmd.Parameters.AddWithValue("DateofBirth", null);
                cmd.Parameters.AddWithValue("VatRegNo", _VatRegNo);
                if (_ShortName != null)
                    cmd.Parameters.AddWithValue("ShortName", _ShortName);
                else cmd.Parameters.AddWithValue("ShortName", null);

                if (_FatherName != null)
                    cmd.Parameters.AddWithValue("FatherName", _FatherName);
                else cmd.Parameters.AddWithValue("FatherName", null);
                if (_MotherName != null)
                    cmd.Parameters.AddWithValue("MotherName", _MotherName);
                else cmd.Parameters.AddWithValue("MotherName", _MotherName);
                if (_SpouseName != null)
                    cmd.Parameters.AddWithValue("SpouseName", _SpouseName);
                else cmd.Parameters.AddWithValue("SpouseName", null);
                if (_PermanentAddress != null)
                    cmd.Parameters.AddWithValue("PermanentAddress", _PermanentAddress);
                else cmd.Parameters.AddWithValue("PermanentAddress", null);
                if (_Nationality != null)
                    cmd.Parameters.AddWithValue("Nationality ", _Nationality);
                else cmd.Parameters.AddWithValue("Nationality ", null);
                if (_PassportNo != null)
                    cmd.Parameters.AddWithValue("PassportNo", _PassportNo);
                else cmd.Parameters.AddWithValue("PassportNo", null);
                cmd.Parameters.AddWithValue("IsCLP ", 0);
                cmd.Parameters.AddWithValue("CurrentCLP", _CurrentCLP);
                cmd.Parameters.AddWithValue("IsRegister ", 0);
                cmd.Parameters.AddWithValue("IsAuthorized", 0);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("WarehouseID", _WarehouseID);

                if (_nIsVerifiedEmail != null)
                    cmd.Parameters.AddWithValue("IsVerifiedEmail", _nIsVerifiedEmail);
                else cmd.Parameters.AddWithValue("IsVerifiedEmail", 0);

                if (_sSecondaryConsumer != null)
                    cmd.Parameters.AddWithValue("SecondaryConsumer", _sSecondaryConsumer);
                else cmd.Parameters.AddWithValue("SecondaryConsumer", null);

                if (_sSecondaryMobileNo != null)
                    cmd.Parameters.AddWithValue("SecondaryMobileNo", _sSecondaryMobileNo);
                else cmd.Parameters.AddWithValue("SecondaryMobileNo", null);
                cmd.Parameters.AddWithValue("MotherConsumerID", _nMotherConsumerID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "update t_Showroom set NextConsumerCode=NextConsumerCode+1  where WarehouseID='" + _WarehouseID + "'";
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void AddSalesInvoiceConsumer()
        {
            int nMaxCustomerID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            sSql = "Select Max([InvoiceConsumerID]) From t_SalesInvoiceConsumer";
            cmd.CommandText = sSql;
            object _oMaxCustomerID = cmd.ExecuteScalar();

            if (_oMaxCustomerID == DBNull.Value)
            {
                nMaxCustomerID = 1;

            }
            else
            {
                nMaxCustomerID = Convert.ToInt32(_oMaxCustomerID) + 1;

            }

            _ConsumerID = nMaxCustomerID;

            cmd.Dispose();
            cmd = DBController.Instance.GetCommand();

            try
            {

                sSql = @"Insert into t_SalesInvoiceConsumer (InvoiceConsumerID,InvoiceID,ConsumerCode,ConsumerName,ConsumerType,CustomerID,	
                        ParentCustomerID,Address,CellNo,PhoneNo,Email,EmployeeCode,NationalID,DateofBirth,
                        VatRegNo,SalesType,DeliveryAddress,IsVerifiedEmail,SecondaryConsumer,SecondaryMobileNo) 
                        VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceConsumerID", _ConsumerID);
                cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);
                cmd.Parameters.AddWithValue("ConsumerCode", _ConsumerCode);
                cmd.Parameters.AddWithValue("ConsumerName", _ConsumerName);
                cmd.Parameters.AddWithValue("ConsumerType", _ConsumerType);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("ParentCustomerID", _nParentCustomerID);
                cmd.Parameters.AddWithValue("Address", _Address);
                cmd.Parameters.AddWithValue("CellNo", _CellNo);
                cmd.Parameters.AddWithValue("PhoneNo", _PhoneNo);
                cmd.Parameters.AddWithValue("Email", _Email);
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("NationalID", _NationalID);
                if (_DateofBirth != null)
                    cmd.Parameters.AddWithValue("DateofBirth", Convert.ToDateTime(_DateofBirth));
                else cmd.Parameters.AddWithValue("DateofBirth", null);
                cmd.Parameters.AddWithValue("VatRegNo", _VatRegNo);

                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("IsVerifiedEmail", _nIsVerifiedEmail);
                if (_sSecondaryConsumer != null)
                    cmd.Parameters.AddWithValue("SecondaryConsumer", _sSecondaryConsumer);
                else cmd.Parameters.AddWithValue("SecondaryConsumer", null);

                if (_sSecondaryMobileNo != null)
                    cmd.Parameters.AddWithValue("SecondaryMobileNo", _sSecondaryMobileNo);
                else cmd.Parameters.AddWithValue("SecondaryMobileNo", null);



                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        
        public int AddRetailConsumerRT(string sConsumerName, int nConsumerType, int nCustomerID, int nParentCustomerID, string sAddress, string sCellNo, string sPhoneNo, string sEmail, int nIsCLP, int nSalesType, int nMotherConsumerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nConsumerID = 0;
            try
            {
                sSql = "Select Max([ConsumerID]) From t_RetailConsumer where WarehouseID=" + Utility.WarehouseID + "";
                cmd.CommandText = sSql;
                object _oMaxCustomerID = cmd.ExecuteScalar();

                if (_oMaxCustomerID == DBNull.Value)
                {
                    nConsumerID = 1;

                }
                else
                {
                    nConsumerID = Convert.ToInt32(_oMaxCustomerID) + 1;

                }

                _ConsumerID = nConsumerID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = @"INSERT INTO [dbo].[t_RetailConsumer]
                    ([ConsumerID] ,[ConsumerCode],[ConsumerName],[ConsumerType],
                    [CustomerID],[ParentCustomerID],[Address],[CellNo],[PhoneNo],
                    [Email],[IsCLP],[SalesType],[WarehouseID],[MotherConsumerID])     
                    VALUES (" + _ConsumerID + @",
                    (SELECT '" + Utility.Shortcode + @"' + '-'+cast(NextConsumerCode as varchar) FROM t_Showroom where WarehouseID=" + Utility.WarehouseID + @"),'" + sConsumerName + @"',
                    " + nConsumerType + @"," + nCustomerID + @"," + nParentCustomerID + @",'" + sAddress + @"','" + sCellNo + @"','" + sPhoneNo + @"','" + sEmail + @"'," + nIsCLP + @",
                    " + nSalesType + @"," + Utility.WarehouseID + @"," + nMotherConsumerID + @")";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                
                sSql = "";
                cmd = DBController.Instance.GetCommand();
                sSql = "update t_Showroom set NextConsumerCode=NextConsumerCode+1 where WarehouseID=" + Utility.WarehouseID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nConsumerID;
        }

        public int AddConsumerDetailRT()
        {
            int nConsumerID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                               
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                sSql = "Insert into t_ConsumerDetail (ConsumerCode,ConsumerName,Address,MobileNo,PhoneNo,Email) VALUES(?,?,?,?,?,?);SELECT CAST(scope_identity() AS int) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerCode", _ConsumerCode);
                cmd.Parameters.AddWithValue("ConsumerName", _ConsumerName);
                cmd.Parameters.AddWithValue("Address", _Address);
                cmd.Parameters.AddWithValue("MobileNo", _CellNo);
                cmd.Parameters.AddWithValue("PhoneNo", _PhoneNo);
                cmd.Parameters.AddWithValue("Email", _Email);

                 cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT @@IDENTITY";

                nConsumerID = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.Dispose();
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nConsumerID;
        }

        public void AddforLead()
        {
            int nMaxCustomerCode = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Select Max([ConsumerID]) From t_RetailConsumer where WarehouseID=68";
                cmd.CommandText = sSql;
                object MaxCustomerCode = cmd.ExecuteScalar();
                if (MaxCustomerCode == DBNull.Value)
                {
                    nMaxCustomerCode = 1;
                }
                else
                {
                    nMaxCustomerCode = int.Parse(MaxCustomerCode.ToString());

                }
                string sKeyWord = "HO";
                _ConsumerCode = sKeyWord + DateTime.Now.Year.ToString() + "-" + nMaxCustomerCode.ToString("0000");
                
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "insert into t_RetailConsumer (ConsumerID,ConsumerCode,ConsumerName,ConsumerType,CustomerID, " +
                "ParentCustomerID, Address,CellNo,PhoneNo,Email,EmployeeCode,NationalID,DateofBirth,VatRegNo,ShortName,FatherName,MotherName, " +
                "SpouseName,PermanentAddress,Nationality,PassportNo,IsCLP,CurrentCLP,IsRegister,IsAuthorized,SalesType,WarehouseID)  " +
                "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
                cmd.Parameters.AddWithValue("ConsumerCode", _ConsumerCode);
                cmd.Parameters.AddWithValue("ConsumerName", _ConsumerName);
                cmd.Parameters.AddWithValue("ConsumerType", _ConsumerType);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("ParentCustomerID", _nParentCustomerID);
                cmd.Parameters.AddWithValue("Address", _Address);
                cmd.Parameters.AddWithValue("CellNo", _CellNo);
                cmd.Parameters.AddWithValue("PhoneNo", _PhoneNo);
                cmd.Parameters.AddWithValue("Email", _Email);
                cmd.Parameters.AddWithValue("EmployeeCode", null);
                cmd.Parameters.AddWithValue("NationalID", null);
                cmd.Parameters.AddWithValue("DateofBirth", null);
                cmd.Parameters.AddWithValue("VatRegNo", null);
                cmd.Parameters.AddWithValue("ShortName", null);
                cmd.Parameters.AddWithValue("FatherName", null);
                cmd.Parameters.AddWithValue("MotherName", null);
                cmd.Parameters.AddWithValue("SpouseName", null);
                cmd.Parameters.AddWithValue("PermanentAddress", null);
                cmd.Parameters.AddWithValue("Nationality ", null);
                cmd.Parameters.AddWithValue("PassportNo", null);
                cmd.Parameters.AddWithValue("IsCLP ", 0);
                cmd.Parameters.AddWithValue("CurrentCLP", null);
                cmd.Parameters.AddWithValue("IsRegister ", 0);
                cmd.Parameters.AddWithValue("IsAuthorized", 0);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("WarehouseID", _WarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void AddForHOEnd() //Should be deleted after implementing V9
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "insert into t_RetailConsumer (ConsumerID,ConsumerCode,ConsumerName,ConsumerType,CustomerID, " +
                        " ParentCustomerID, Address,CellNo,PhoneNo,Email,EmployeeCode,NationalID,DateofBirth,VatRegNo,ShortName,FatherName,MotherName," +
                        "SpouseName,PermanentAddress,Nationality,PassportNo,IsCLP,CurrentCLP,IsRegister,IsAuthorized " +
                        ")  VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
                cmd.Parameters.AddWithValue("ConsumerCode", _ConsumerCode);
                cmd.Parameters.AddWithValue("ConsumerName", _ConsumerName);
                cmd.Parameters.AddWithValue("ConsumerType", _ConsumerType);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("ParentCustomerID", _nParentCustomerID);
                cmd.Parameters.AddWithValue("Address", _Address);
                cmd.Parameters.AddWithValue("CellNo", _CellNo);
                cmd.Parameters.AddWithValue("PhoneNo", _PhoneNo);
                cmd.Parameters.AddWithValue("Email", _Email);
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("NationalID", _NationalID);
                if (_DateofBirth != null)
                    cmd.Parameters.AddWithValue("DateofBirth", Convert.ToDateTime(_DateofBirth));
                else cmd.Parameters.AddWithValue("DateofBirth", null);
                cmd.Parameters.AddWithValue("VatRegNo", _VatRegNo);
                cmd.Parameters.AddWithValue("ShortName", null);
                cmd.Parameters.AddWithValue("FatherName", null);
                cmd.Parameters.AddWithValue("MotherName", null);
                cmd.Parameters.AddWithValue("SpouseName", null);
                cmd.Parameters.AddWithValue("PermanentAddress", null);
                cmd.Parameters.AddWithValue("Nationality ", null);
                cmd.Parameters.AddWithValue("PassportNo", null);
                cmd.Parameters.AddWithValue("IsCLP ", 0);
                cmd.Parameters.AddWithValue("CurrentCLP", null);
                cmd.Parameters.AddWithValue("IsRegister ", 0);
                cmd.Parameters.AddWithValue("IsAuthorized", 0);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddHOEnd()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "insert into t_RetailConsumer (ConsumerID,ConsumerCode,ConsumerName,ConsumerType,CustomerID, " +
                        " ParentCustomerID, Address,CellNo,PhoneNo,Email,EmployeeCode,NationalID,DateofBirth,VatRegNo,ShortName,FatherName,MotherName," +
                        "SpouseName,PermanentAddress,Nationality,PassportNo,IsCLP,CurrentCLP,IsRegister,IsAuthorized, SalesType, WarehouseID,IsVerifiedEmail,SecondaryConsumer,SecondaryMobileNo " +
                        ")  VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
                cmd.Parameters.AddWithValue("ConsumerCode", _ConsumerCode);
                cmd.Parameters.AddWithValue("ConsumerName", _ConsumerName);
                cmd.Parameters.AddWithValue("ConsumerType", _ConsumerType);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("ParentCustomerID", _nParentCustomerID);
                cmd.Parameters.AddWithValue("Address", _Address);
                cmd.Parameters.AddWithValue("CellNo", _CellNo);
                cmd.Parameters.AddWithValue("PhoneNo", _PhoneNo);
                cmd.Parameters.AddWithValue("Email", _Email);
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("NationalID", _NationalID);
                if (_DateofBirth != null)
                    cmd.Parameters.AddWithValue("DateofBirth", Convert.ToDateTime(_DateofBirth));
                else cmd.Parameters.AddWithValue("DateofBirth", null);
                cmd.Parameters.AddWithValue("VatRegNo", _VatRegNo);
                cmd.Parameters.AddWithValue("ShortName", null);
                cmd.Parameters.AddWithValue("FatherName", null);
                cmd.Parameters.AddWithValue("MotherName", null);
                cmd.Parameters.AddWithValue("SpouseName", null);
                cmd.Parameters.AddWithValue("PermanentAddress", null);
                cmd.Parameters.AddWithValue("Nationality ", null);
                cmd.Parameters.AddWithValue("PassportNo", null);
                cmd.Parameters.AddWithValue("IsCLP ", 0);
                cmd.Parameters.AddWithValue("CurrentCLP", null);
                cmd.Parameters.AddWithValue("IsRegister ", 0);
                cmd.Parameters.AddWithValue("IsAuthorized", 0);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("WarehouseID", _WarehouseID);
                cmd.Parameters.AddWithValue("IsVerifiedEmail", _nIsVerifiedEmail);
                cmd.Parameters.AddWithValue("SecondaryConsumer", _sSecondaryConsumer);
                cmd.Parameters.AddWithValue("SecondaryMobileNo", _sSecondaryMobileNo);

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
            int nCount = 0;
            try
            {
                cmd.CommandText = "Update t_RetailConsumer Set ParentCustomerID=?, ConsumerName=?,Address=?,CellNo=?,PhoneNo=?,Email=?,EmployeeCode=?,NationalID=?,DateofBirth=?, "
                    + " VatRegNo=?,ShortName=?,FatherName=?,MotherName=?,SpouseName=?,PermanentAddress=?,Nationality=?,PassportNo=?,IsCLP=?,IsRegister=? "
                    + " Where ConsumerID=? and CustomerID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ParentCustomerID", _nParentCustomerID);
                cmd.Parameters.AddWithValue("ConsumerName", _ConsumerName);            
                cmd.Parameters.AddWithValue("Address", _Address);
                cmd.Parameters.AddWithValue("CellNo", _CellNo);
                cmd.Parameters.AddWithValue("PhoneNo", _PhoneNo);
                cmd.Parameters.AddWithValue("Email", _Email);
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("NationalID", _NationalID);
                if (_DateofBirth != null)
                    cmd.Parameters.AddWithValue("DateofBirth", Convert.ToDateTime(_DateofBirth));
                else cmd.Parameters.AddWithValue("DateofBirth", null);
                cmd.Parameters.AddWithValue("VatRegNo", _VatRegNo);
                cmd.Parameters.AddWithValue("ShortName", _ShortName);
                cmd.Parameters.AddWithValue("FatherName", _FatherName);
                cmd.Parameters.AddWithValue("MotherName", _MotherName);
                cmd.Parameters.AddWithValue("SpouseName", _SpouseName);
                cmd.Parameters.AddWithValue("PermanentAddress", _PermanentAddress);
                cmd.Parameters.AddWithValue("Nationality ", _Nationality);
                cmd.Parameters.AddWithValue("PassportNo", _PassportNo);
                cmd.Parameters.AddWithValue("IsCLP ", _IsCLP);
                cmd.Parameters.AddWithValue("IsRegister ", _IsRegister);

                cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);

                nCount = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                _bFlag = false;
            else _bFlag = true;
            
        }
        public void UpdateHOEnd()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Update t_RetailConsumer Set CustomerID=?, ParentCustomerID=?, ConsumerName=?,Address=?,CellNo=?,PhoneNo=?,Email=?,EmployeeCode=?,NationalID=?,DateofBirth=?, "
                    + " VatRegNo=?,ShortName=?,FatherName=?,MotherName=?,SpouseName=?,PermanentAddress=?,Nationality=?,PassportNo=?,IsCLP=?,IsRegister=?, SalesType=?, IsVerifiedEmail = ?,SecondaryConsumer = ?,SecondaryMobileNo = ? "
                    + " Where ConsumerID=? and WarehouseID=? ";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("ParentCustomerID", _nParentCustomerID);
                cmd.Parameters.AddWithValue("ConsumerName", _ConsumerName);
                cmd.Parameters.AddWithValue("Address", _Address);
                cmd.Parameters.AddWithValue("CellNo", _CellNo);
                cmd.Parameters.AddWithValue("PhoneNo", _PhoneNo);
                cmd.Parameters.AddWithValue("Email", _Email);
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("NationalID", _NationalID);
                if (_DateofBirth != null)
                    cmd.Parameters.AddWithValue("DateofBirth", Convert.ToDateTime(_DateofBirth));
                else cmd.Parameters.AddWithValue("DateofBirth", null);
                cmd.Parameters.AddWithValue("VatRegNo", _VatRegNo);
                cmd.Parameters.AddWithValue("ShortName", _ShortName);
                cmd.Parameters.AddWithValue("FatherName", _FatherName);
                cmd.Parameters.AddWithValue("MotherName", _MotherName);
                cmd.Parameters.AddWithValue("SpouseName", _SpouseName);
                cmd.Parameters.AddWithValue("PermanentAddress", _PermanentAddress);
                cmd.Parameters.AddWithValue("Nationality ", _Nationality);
                cmd.Parameters.AddWithValue("PassportNo", _PassportNo);
                cmd.Parameters.AddWithValue("IsCLP ", _IsCLP);
                cmd.Parameters.AddWithValue("IsRegister ", _IsRegister);
                cmd.Parameters.AddWithValue("SalesType ", _nSalesType);
                cmd.Parameters.AddWithValue("IsVerifiedEmail ", _nIsVerifiedEmail);
                cmd.Parameters.AddWithValue("SecondaryConsumer", _sSecondaryConsumer);
                cmd.Parameters.AddWithValue("SecondaryMobileNo", _sSecondaryMobileNo);

                cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
                cmd.Parameters.AddWithValue("WarehouseID", _WarehouseID);

                nCount = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                _bFlag = false;
            else _bFlag = true;

        }
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = " SELECT a.*,CASE When SalesType=1 then 'Retail' When SalesType=2 then 'B2C' When SalesType=3 then 'B2B' " +
                          " When SalesType=4 then 'HPA' When SalesType=5 then 'Dealer' " +
                          " else 'Other' end as SalesTypeName FROM t_RetailConsumer a where ConsumerID=? and WarehouseID=? ";

            cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
            cmd.Parameters.AddWithValue("WarehouseID", _WarehouseID);

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nParentCustomerID = int.Parse(reader["ParentCustomerID"].ToString());
                    _ConsumerCode = reader["ConsumerCode"].ToString();
                    _ConsumerName = (string)reader["ConsumerName"];
                    _ConsumerType = int.Parse(reader["ConsumerType"].ToString());
                    _Address = reader["Address"].ToString();
                    _Email = reader["Email"].ToString();
                    if (reader["EmployeeCode"] != DBNull.Value)
                        _sEmployeeCode = reader["EmployeeCode"].ToString();
                    else _sEmployeeCode = "";
                    _NationalID = reader["NationalID"].ToString();
                    _CellNo = reader["CellNo"].ToString();
                    _PhoneNo = reader["PhoneNo"].ToString();
                    if (reader["DateofBirth"] != DBNull.Value)
                        _DateofBirth = Convert.ToDateTime(reader["DateofBirth"]);
                    _VatRegNo = reader["VatRegNo"].ToString();

                    _ShortName = reader["ShortName"].ToString();
                    _FatherName = reader["FatherName"].ToString();
                    _MotherName = reader["MotherName"].ToString();
                    _SpouseName = reader["SpouseName"].ToString();
                    _PermanentAddress = reader["PermanentAddress"].ToString();
                    _Nationality = reader["Nationality"].ToString();
                    _PassportNo = reader["PassportNo"].ToString();

                    if (reader["IsCLP"] != DBNull.Value)
                        _IsCLP = Convert.ToInt32(reader["IsCLP"]);
                    else _IsCLP = 0;
                    if (reader["CurrentCLP"] != DBNull.Value)
                        _CurrentCLP = Convert.ToInt32(reader["CurrentCLP"]);
                    else _CurrentCLP = 0;
                    if (reader["IsRegister"] != DBNull.Value)
                        _IsRegister = Convert.ToInt32(reader["IsRegister"]);
                    else _IsRegister = 0;
                    if (reader["IsAuthorized"] != DBNull.Value)
                        _IsAuthorized = Convert.ToInt32(reader["IsAuthorized"]);
                    else _IsAuthorized = 0;
                    if (reader["SalesType"] != DBNull.Value)
                       _nSalesType = Convert.ToInt32(reader["SalesType"]);
                   else _nSalesType = (int)Dictionary.SalesType.Retail;
                    _sSalesTypeName = Enum.GetName(typeof (Dictionary.SalesType), _nSalesType);


                    if (reader["SecondaryConsumer"] != DBNull.Value)
                        _sSecondaryConsumer = reader["SecondaryConsumer"].ToString();
                    else _sSecondaryConsumer = "";

                    if (reader["SecondaryMobileNo"] != DBNull.Value)
                        _sSecondaryMobileNo = reader["SecondaryMobileNo"].ToString();
                    else _sSecondaryMobileNo = "";


                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForPOS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = " SELECT a.*,CASE When SalesType=1 then 'Retail' When SalesType=2 then 'B2C' When SalesType=3 then 'B2B' " +
                          " When SalesType=4 then 'HPA' When SalesType=5 then 'Dealer' When SalesType=6 then 'e-Store' " +
                          " else 'Other' end as SalesTypeName FROM t_RetailConsumer a where ConsumerID=? and CustomerID=? ";

            cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
            cmd.Parameters.AddWithValue("CustomerID", _CustomerID);

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nParentCustomerID = int.Parse(reader["ParentCustomerID"].ToString());
                    _ConsumerCode = reader["ConsumerCode"].ToString();
                    _ConsumerName = (string)reader["ConsumerName"];
                    _ConsumerType = int.Parse(reader["ConsumerType"].ToString());
                    _Address = reader["Address"].ToString();
                    if (reader["Email"] != DBNull.Value)
                        _Email = reader["Email"].ToString();
                    else _Email = "";
                    if (reader["EmployeeCode"] != DBNull.Value)
                        _sEmployeeCode = reader["EmployeeCode"].ToString();
                    else _sEmployeeCode = "";
                    _NationalID = reader["NationalID"].ToString();
                    _CellNo = reader["CellNo"].ToString();
                    _PhoneNo = reader["PhoneNo"].ToString();
                    if (reader["DateofBirth"] != DBNull.Value)
                        _DateofBirth = Convert.ToDateTime(reader["DateofBirth"]);
                    _VatRegNo = reader["VatRegNo"].ToString();

                    _ShortName = reader["ShortName"].ToString();
                    _FatherName = reader["FatherName"].ToString();
                    _MotherName = reader["MotherName"].ToString();
                    _SpouseName = reader["SpouseName"].ToString();
                    _PermanentAddress = reader["PermanentAddress"].ToString();
                    _Nationality = reader["Nationality"].ToString();
                    _PassportNo = reader["PassportNo"].ToString();

                    if (reader["IsCLP"] != DBNull.Value)
                        _IsCLP = Convert.ToInt32(reader["IsCLP"]);
                    else _IsCLP = 0;
                    if (reader["CurrentCLP"] != DBNull.Value)
                        _CurrentCLP = Convert.ToInt32(reader["CurrentCLP"]);
                    else _CurrentCLP = 0;
                    if (reader["IsRegister"] != DBNull.Value)
                        _IsRegister = Convert.ToInt32(reader["IsRegister"]);
                    else _IsRegister = 0;
                    if (reader["IsAuthorized"] != DBNull.Value)
                        _IsAuthorized = Convert.ToInt32(reader["IsAuthorized"]);
                    else _IsAuthorized = 0;
                    if (reader["SalesType"] != DBNull.Value)
                        _nSalesType = Convert.ToInt32(reader["SalesType"]);
                    else _nSalesType = (int)Dictionary.SalesType.Retail;
                    _sSalesTypeName = (string)reader["SalesTypeName"];

                    if (reader["SecondaryConsumer"] != DBNull.Value)
                        _sSecondaryConsumer = reader["SecondaryConsumer"].ToString();
                    else _sSecondaryConsumer = "";

                    if (reader["SecondaryMobileNo"] != DBNull.Value)
                        _sSecondaryMobileNo = reader["SecondaryMobileNo"].ToString();
                    else _sSecondaryMobileNo = "";

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForPOSRT(long nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = @"Select a.*,b.Description as SalesTypeName  From
                        (
                        Select a.WarehouseID,ConsumerID,InvoiceID,ConsumerCode,ConsumerName,
                        ConsumerType,b.CustomerID,ParentCustomerID,Address,CellNo,PhoneNo,
                        Email,EmployeeCode,NationalID,DateofBirth,VatRegNo,ShortName,
                        FatherName,MotherName,SpouseName,PermanentAddress,Nationality,
                        PassportNo,IsCLP,CurrentCLP,IsRegister,IsAuthorized,SalesType,
                        a.DeliveryAddress,IsVerifiedEmail,SecondaryConsumer,SecondaryMobileNo From t_SalesInvoice a
                        join t_RetailConsumer b on a.SundryCustomerID=b.ConsumerID and a.WarehouseID=b.WarehouseID
                        where isnull(a.IsRTInvoice,0)=0 and a.WarehouseID=129
                        Union All
                        Select WarehouseID,b.InvoiceConsumerID as ConsumerID,b.InvoiceID,ConsumerCode,ConsumerName,
                        ConsumerType,b.CustomerID,ParentCustomerID,Address,CellNo,PhoneNo,
                        Email,EmployeeCode,NationalID,DateofBirth,VatRegNo,ShortName,
                        FatherName,MotherName,SpouseName,PermanentAddress,Nationality,
                        PassportNo,IsCLP,CurrentCLP,IsRegister,IsAuthorized,SalesType,
                        a.DeliveryAddress,IsVerifiedEmail,SecondaryConsumer,SecondaryMobileNo From t_SalesInvoice a
                        join t_SalesInvoiceConsumer b on a.InvoiceConsumerID=b.InvoiceConsumerID and a.InvoiceID=b.InvoiceID
                        where isnull(a.IsRTInvoice,0)=1 
                        ) a,t_SalesTypeGroup b where a.SalesType=b.SalesTypeID 
                        and InvoiceID=" + nInvoiceID + "";


            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nParentCustomerID = int.Parse(reader["ParentCustomerID"].ToString());
                    _ConsumerCode = reader["ConsumerCode"].ToString();
                    _ConsumerName = (string)reader["ConsumerName"];
                    _ConsumerType = int.Parse(reader["ConsumerType"].ToString());
                    _Address = reader["Address"].ToString();
                    if (reader["Email"] != DBNull.Value)
                        _Email = reader["Email"].ToString();
                    else _Email = "";
                    if (reader["EmployeeCode"] != DBNull.Value)
                        _sEmployeeCode = reader["EmployeeCode"].ToString();
                    else _sEmployeeCode = "";
                    _NationalID = reader["NationalID"].ToString();
                    _CellNo = reader["CellNo"].ToString();
                    _PhoneNo = reader["PhoneNo"].ToString();
                    if (reader["DateofBirth"] != DBNull.Value)
                        _DateofBirth = Convert.ToDateTime(reader["DateofBirth"]);
                    _VatRegNo = reader["VatRegNo"].ToString();

                    _ShortName = reader["ShortName"].ToString();
                    _FatherName = reader["FatherName"].ToString();
                    _MotherName = reader["MotherName"].ToString();
                    _SpouseName = reader["SpouseName"].ToString();
                    _PermanentAddress = reader["PermanentAddress"].ToString();
                    _Nationality = reader["Nationality"].ToString();
                    _PassportNo = reader["PassportNo"].ToString();

                    if (reader["IsCLP"] != DBNull.Value)
                        _IsCLP = Convert.ToInt32(reader["IsCLP"]);
                    else _IsCLP = 0;
                    if (reader["CurrentCLP"] != DBNull.Value)
                        _CurrentCLP = Convert.ToInt32(reader["CurrentCLP"]);
                    else _CurrentCLP = 0;
                    if (reader["IsRegister"] != DBNull.Value)
                        _IsRegister = Convert.ToInt32(reader["IsRegister"]);
                    else _IsRegister = 0;
                    if (reader["IsAuthorized"] != DBNull.Value)
                        _IsAuthorized = Convert.ToInt32(reader["IsAuthorized"]);
                    else _IsAuthorized = 0;
                    if (reader["SalesType"] != DBNull.Value)
                        _nSalesType = Convert.ToInt32(reader["SalesType"]);
                    else _nSalesType = (int)Dictionary.SalesType.Retail;
                    _sSalesTypeName = (string)reader["SalesTypeName"];

                    if (reader["SecondaryConsumer"] != DBNull.Value)
                        _sSecondaryConsumer = reader["SecondaryConsumer"].ToString();
                    else _sSecondaryConsumer = "";

                    if (reader["SecondaryMobileNo"] != DBNull.Value)
                        _sSecondaryMobileNo = reader["SecondaryMobileNo"].ToString();
                    else _sSecondaryMobileNo = "";

                    nCount++;
                }

                reader.Close();
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
            string sSql = "SELECT * FROM t_RetailConsumer where  ConsumerCode = '" + _ConsumerCode + "'";

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nParentCustomerID = int.Parse(reader["ParentCustomerID"].ToString());
                    _ConsumerID = int.Parse(reader["ConsumerID"].ToString());
                    _ConsumerCode = reader["ConsumerCode"].ToString();
                    _ConsumerName = (string)reader["ConsumerName"];
                    _ConsumerType = int.Parse(reader["ConsumerType"].ToString());
                    _CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _Address = reader["Address"].ToString();
                    _Email = reader["Email"].ToString();
                    if (reader["EmployeeCode"] != DBNull.Value)
                        _sEmployeeCode = reader["EmployeeCode"].ToString();
                    else _sEmployeeCode = "";
                    _NationalID = reader["NationalID"].ToString();
                    _CellNo = reader["CellNo"].ToString();
                    _PhoneNo = reader["PhoneNo"].ToString();
                    if (reader["DateofBirth"] != DBNull.Value)
                        _DateofBirth = Convert.ToDateTime(reader["DateofBirth"]);
                    _VatRegNo = reader["VatRegNo"].ToString();

                    _ShortName = reader["ShortName"].ToString();
                    _FatherName = reader["FatherName"].ToString();
                    _MotherName = reader["MotherName"].ToString();
                    _SpouseName = reader["SpouseName"].ToString();
                    _PermanentAddress = reader["PermanentAddress"].ToString();
                    _Nationality = reader["Nationality"].ToString();
                    _PassportNo = reader["PassportNo"].ToString();

                    if (reader["IsCLP"] != DBNull.Value)
                        _IsCLP = Convert.ToInt32(reader["IsCLP"]);
                    else _IsCLP = 0;
                    if (reader["CurrentCLP"] != DBNull.Value)
                        _CurrentCLP = Convert.ToInt32(reader["CurrentCLP"]);
                    else _CurrentCLP = 0;
                    if (reader["IsRegister"] != DBNull.Value)
                        _IsRegister = Convert.ToInt32(reader["IsRegister"]);
                    else _IsRegister = 0;
                    if (reader["IsAuthorized"] != DBNull.Value)
                        _IsAuthorized = Convert.ToInt32(reader["IsAuthorized"]);
                    else _IsRegister = 0;


                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshConsumerByType(int nSalesType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT a.*,CustomerCode,CustomerName FROM t_RetailConsumer a,t_Customer b where a.CustomerID=b.CustomerID and  ConsumerCode = '" + _ConsumerCode + "' and SalesType=" + nSalesType + "";

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sCustomerCode = reader["CustomerCode"].ToString();
                    _sCustomerName = reader["CustomerName"].ToString();

                    _nParentCustomerID = int.Parse(reader["ParentCustomerID"].ToString());
                    _ConsumerID = int.Parse(reader["ConsumerID"].ToString());
                    _ConsumerCode = reader["ConsumerCode"].ToString();
                    _ConsumerName = (string)reader["ConsumerName"];
                    _ConsumerType = int.Parse(reader["ConsumerType"].ToString());
                    _CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _Address = reader["Address"].ToString();
                    _Email = reader["Email"].ToString();
                    if (reader["EmployeeCode"] != DBNull.Value)
                        _sEmployeeCode = reader["EmployeeCode"].ToString();
                    else _sEmployeeCode = "";
                    _NationalID = reader["NationalID"].ToString();
                    _CellNo = reader["CellNo"].ToString();
                    _PhoneNo = reader["PhoneNo"].ToString();
                    if (reader["DateofBirth"] != DBNull.Value)
                        _DateofBirth = Convert.ToDateTime(reader["DateofBirth"]);
                    if (reader["VatRegNo"] != DBNull.Value)
                        _VatRegNo = reader["VatRegNo"].ToString();
                    _ShortName = reader["ShortName"].ToString();
                    _FatherName = reader["FatherName"].ToString();
                    _MotherName = reader["MotherName"].ToString();
                    _SpouseName = reader["SpouseName"].ToString();
                    _PermanentAddress = reader["PermanentAddress"].ToString();
                    _Nationality = reader["Nationality"].ToString();
                    _PassportNo = reader["PassportNo"].ToString();

                    if (reader["IsCLP"] != DBNull.Value)
                        _IsCLP = Convert.ToInt32(reader["IsCLP"]);
                    else _IsCLP = 0;
                    if (reader["CurrentCLP"] != DBNull.Value)
                        _CurrentCLP = Convert.ToInt32(reader["CurrentCLP"]);
                    else _CurrentCLP = 0;
                    if (reader["IsRegister"] != DBNull.Value)
                        _IsRegister = Convert.ToInt32(reader["IsRegister"]);
                    else _IsRegister = 0;
                    if (reader["IsAuthorized"] != DBNull.Value)
                        _IsAuthorized = Convert.ToInt32(reader["IsAuthorized"]);
                    else _IsRegister = 0;

                    if (reader["DeliveryAddress"] != DBNull.Value)
                        _sDeliveryAddress = reader["DeliveryAddress"].ToString();
                    else _sDeliveryAddress = reader["Address"].ToString();


                    if (reader["IsVerifiedEmail"] != DBNull.Value)
                        _nIsVerifiedEmail = Convert.ToInt32(reader["IsVerifiedEmail"]);
                    else _nIsVerifiedEmail = 0;


                    if (reader["SecondaryConsumer"] != DBNull.Value)
                        _sSecondaryConsumer = reader["SecondaryConsumer"].ToString();
                    else _sSecondaryConsumer = "";

                    if (reader["SecondaryMobileNo"] != DBNull.Value)
                        _sSecondaryMobileNo = reader["SecondaryMobileNo"].ToString();
                    else _sSecondaryMobileNo = "";


                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshConsumerByTypeRT(int nSalesType,string sConsumerCode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.ConsumerID,a.ConsumerCode,a.ConsumerName, " +
                        "isnull(a.MobileNo,'') MobileNo,isnull(a.PhoneNo,'') PhoneNo, " +
                        "isnull(a.Address,'') Address,isnull(a.Email,'')  Email, " +
                        "isnull(b.ConsumerID,0) as RetailConsumerID, " +
                        "isnull(b.ConsumerCode,'') as RetailConsumerCode,isnull(b.ConsumerName,'') RetailConsumerName, " +
                        "isnull(CustomerCode,'') CustomerCode,isnull(CustomerName,'') CustomerName,isnull(b.CustomerID,0) CustomerID From t_ConsumerDetail a " +
                        "left outer join  " +
                        "(Select a.*,isnull(b.CustomerCode,'') CustomerCode,isnull(b.CustomerName,'') CustomerName "+ 
                        "From t_RetailConsumer a,t_Customer b where a.CustomerID=b.CustomerID and WarehouseID=" + Utility.WarehouseID + " and SalesType=" + nSalesType + ") b  " +
                        "on a.ConsumerID=b.MotherConsumerID where  " +
                        "a.ConsumerCode='" + sConsumerCode + "'";

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _ConsumerID = int.Parse(reader["ConsumerID"].ToString());
                    _ConsumerCode = reader["ConsumerCode"].ToString();
                    _ConsumerName = reader["ConsumerName"].ToString();
                    _CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _sCustomerCode = reader["CustomerCode"].ToString();
                    _sCustomerName = reader["CustomerName"].ToString();
                    _CellNo = reader["MobileNo"].ToString();
                    _PhoneNo = reader["PhoneNo"].ToString();
                    _Address = reader["Address"].ToString();
                    _Email = reader["Email"].ToString();
                    _sRetailConsumerCode = reader["RetailConsumerCode"].ToString();
                    _sRetailConsumerName = (string)reader["RetailConsumerName"];
                    _nRetailConsumerID = int.Parse(reader["RetailConsumerID"].ToString());

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public bool RefreshConsumerByCellNoRT(string sMobileNo, int nSalesType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select a.ConsumerID,a.ConsumerCode,a.ConsumerName, " +
                        "isnull(a.MobileNo,'') MobileNo,isnull(a.PhoneNo,'') PhoneNo, " +
                        "isnull(a.Address,'') Address,isnull(a.Email,'')  Email, " +
                        "isnull(b.ConsumerID,0) as RetailConsumerID, " +
                        "isnull(b.ConsumerCode,'') as RetailConsumerCode,isnull(b.ConsumerName,'') RetailConsumerName, " +
                        "isnull(CustomerCode,'') CustomerCode,isnull(CustomerName,'') CustomerName,isnull(b.CustomerID,0) CustomerID From t_ConsumerDetail a " +
                        "left outer join  " +
                        "(Select a.*,isnull(b.CustomerCode,'') CustomerCode,isnull(b.CustomerName,'') CustomerName " +
                        "From t_RetailConsumer a,t_Customer b where a.CustomerID=b.CustomerID and WarehouseID=" + Utility.WarehouseID + " and SalesType=" + nSalesType + ") b  " +
                        "on a.ConsumerID=b.MotherConsumerID where  " +
                        "a.MobileNo='" + sMobileNo + "'";

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _ConsumerID = int.Parse(reader["ConsumerID"].ToString());
                    _ConsumerCode = reader["ConsumerCode"].ToString();
                    _ConsumerName = reader["ConsumerName"].ToString();
                    _CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _sCustomerCode = reader["CustomerCode"].ToString();
                    _sCustomerName = reader["CustomerName"].ToString();
                    _CellNo = reader["MobileNo"].ToString();
                    _PhoneNo = reader["PhoneNo"].ToString();
                    _Address = reader["Address"].ToString();
                    _Email = reader["Email"].ToString();
                    _sRetailConsumerCode = reader["RetailConsumerCode"].ToString();
                    _sRetailConsumerName = (string)reader["RetailConsumerName"];
                    _nRetailConsumerID = int.Parse(reader["RetailConsumerID"].ToString());

                    nCount++;

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        public bool CheckCLPConsumer()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_RetailConsumer where ConsumerID=? and IsCLP=? and CustomerID=?";
            cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
            cmd.Parameters.AddWithValue("IsCLP", (int)Dictionary.YesOrNoStatus.YES);
            cmd.Parameters.AddWithValue("CustomerID", _CustomerID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["CurrentCLP"] != DBNull.Value)
                        _CurrentCLP = Convert.ToInt32(reader["CurrentCLP"]);
                    else _CurrentCLP = 0;

                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0) return true;
            else return false;

        }

        public bool CheckConsumer()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_RetailConsumer where ConsumerID=? and CustomerID=?";
            cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
            cmd.Parameters.AddWithValue("CustomerID", _CustomerID);

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
            if (nCount != 0) 
                return true;
            else return false;

        }
        public bool CheckConsumerHOEnd()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_RetailConsumer where ConsumerID=? and WarehouseID=?";
            cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
            cmd.Parameters.AddWithValue("WarehouseID", _WarehouseID);

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
            if (nCount != 0)
                return true;
            else return false;

        }
        public bool CheckConsumer(int nCustomerID, int nSalesType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_RetailConsumer where CustomerID=? and SalesType=?";
            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
            cmd.Parameters.AddWithValue("SalesType", nSalesType);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ConsumerID = (int)reader["ConsumerID"];
                    _ConsumerCode = (string)reader["ConsumerCode"];
                    _CustomerID = (int)reader["CustomerID"];
                    if (reader["SalesType"] != DBNull.Value)
                    {
                        _nSalesType = (int)reader["SalesType"];
                    }
                    else
                    {
                        _nSalesType = 1;
                    }
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
        public bool CheckConsumerRT(int nCustomerID, int nSalesType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_RetailConsumer where CustomerID=? and SalesType=? and WarehouseID=" + Utility.WarehouseID + "";
            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
            cmd.Parameters.AddWithValue("SalesType", nSalesType);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ConsumerID = (int)reader["ConsumerID"];
                    _ConsumerCode = (string)reader["ConsumerCode"];
                    _CustomerID = (int)reader["CustomerID"];
                    if (reader["SalesType"] != DBNull.Value)
                    {
                        _nSalesType = (int)reader["SalesType"];
                    }
                    else
                    {
                        _nSalesType = 1;
                    }
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
        public bool GetConsumer(int nConsumerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_RetailConsumer where ConsumerID=?";
            cmd.Parameters.AddWithValue("ConsumerID", nConsumerID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ConsumerID = (int)reader["ConsumerID"];
                    _CustomerID = (int)reader["CustomerID"];
                    if (reader["SalesType"] != DBNull.Value)
                    {
                        _nSalesType = (int)reader["SalesType"];
                    }
                    else
                    {
                        _nSalesType = 1;
                    }
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
        public bool GetConsumerByMobileNoType(string sMobileNo,int nSalesType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_RetailConsumer where CellNo = ? and SalesType = ?";
            cmd.Parameters.AddWithValue("CellNo", sMobileNo);
            cmd.Parameters.AddWithValue("SalesType", nSalesType);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ConsumerCode = reader["ConsumerCode"].ToString();
                    _ConsumerName = reader["ConsumerName"].ToString();
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
        public bool GetConsumerByMobileNo(string sMobileNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_RetailConsumer where CellNo=?";
            cmd.Parameters.AddWithValue("CellNo", sMobileNo);

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
            if (nCount != 0)
                return true;
            else return false;

        }
        public int GetConsumerDetailByMobileNo(string sMobileNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nMotherConsumerID = 0;
            string sSql = "SELECT * FROM t_ConsumerDetail where MobileNo=?";
            cmd.Parameters.AddWithValue("MobileNo", sMobileNo);

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nMotherConsumerID = int.Parse(reader["ConsumerID"].ToString());
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nMotherConsumerID;

        }
        public bool GetConsumerByMobileNoSalesType(string sMobileNo, int nSalesType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_RetailConsumer where CellNo=? and SalesType=?";
            cmd.Parameters.AddWithValue("CellNo", sMobileNo);
            cmd.Parameters.AddWithValue("SalesType", nSalesType);

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
            if (nCount != 0)
                return true;
            else return false;

        }
        public bool GetConsumerByMobileNoSalesTypeRT(string sMobileNo, int nSalesType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = @"Select a.*,isnull(b.ConsumerID,0) ExistingLocalConsumerID 
                        From t_ConsumerDetail a left outer join (Select * From t_RetailConsumer where WarehouseID = " + Utility.WarehouseID + @" and SalesType=" + nSalesType + @") b on a.ConsumerID = b.MotherConsumerID
                        where a.MobileNo = '" + sMobileNo + "'";

            cmd.Parameters.AddWithValue("CellNo", sMobileNo);
            cmd.Parameters.AddWithValue("SalesType", nSalesType);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ConsumerID = (int)reader["ConsumerID"];
                    _ConsumerCode = (string)reader["ConsumerCode"];
                    _ConsumerName = (string)reader["ConsumerName"];
                    _nRetailConsumerID = (int)reader["ExistingLocalConsumerID"];
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
        public bool GetConsumerByCode(string sConsumerCode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_RetailConsumer where ConsumerCode=?";
            cmd.Parameters.AddWithValue("ConsumerCode", sConsumerCode);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ConsumerID = (int)reader["ConsumerID"];
                    _CustomerID = (int)reader["CustomerID"];
                    _ConsumerCode = (string)reader["ConsumerCode"];
                    if (reader["SalesType"] != DBNull.Value)
                    {
                        _nSalesType = (int)reader["SalesType"];
                    }
                    else
                    {
                        _nSalesType = 1;
                    }
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
        public bool GetConsumerByCustomerID(int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_RetailConsumer where CustomerID=?";
            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ConsumerID = (int)reader["ConsumerID"];
                    _CustomerID = (int)reader["CustomerID"];
                    _ConsumerCode = (string)reader["ConsumerCode"];
                    if (reader["SalesType"] != DBNull.Value)
                    {
                        _nSalesType = (int)reader["SalesType"];
                    }
                    else
                    {
                        _nSalesType = 1;
                    }
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
        public bool GetConsumerByCustomerIDRT(int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_RetailConsumer where CustomerID=? and WarehouseID=" + Utility.WarehouseID + "";
            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _ConsumerID = (int)reader["ConsumerID"];
                    _CustomerID = (int)reader["CustomerID"];
                    _ConsumerCode = (string)reader["ConsumerCode"];
                    if (reader["SalesType"] != DBNull.Value)
                    {
                        _nSalesType = (int)reader["SalesType"];
                    }
                    else
                    {
                        _nSalesType = 1;
                    }
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
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_RetailConsumer Set ConsumerName=?,Address=?, Email=?, NationalID=?, CellNo=?, PhoneNo=?, DateofBirth=?, "
                    + " VatRegNo=?, ShortName=?, FatherName=?, MotherName=?, SpouseName=?, PermanentAddress=?, Nationality=?, PassportNo=?, IsCLP = ?, IsRegister = ? "
                    + " Where ConsumerID=? ";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerName", _ConsumerName);
                cmd.Parameters.AddWithValue("Address", _Address);
                cmd.Parameters.AddWithValue("Email", _Email);
                if (_NationalID != null)
                {
                    cmd.Parameters.AddWithValue("NationalID", _NationalID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("NationalID", null);
                }
                cmd.Parameters.AddWithValue("CellNo", _CellNo);

                if (_PhoneNo != null)
                {
                    cmd.Parameters.AddWithValue("PhoneNo", _PhoneNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("PhoneNo", null);
                }

                if (_DateofBirth != null)
                {
                    cmd.Parameters.AddWithValue("DateofBirth", Convert.ToDateTime(_DateofBirth));
                }
                else
                {
                    cmd.Parameters.AddWithValue("DateofBirth", null);
                }

                if (_VatRegNo != null)
                {
                    cmd.Parameters.AddWithValue("VatRegNo", _VatRegNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("VatRegNo", null);
                }

                if (_ShortName != null)
                {
                    cmd.Parameters.AddWithValue("ShortName", _ShortName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ShortName", null);
                }

                if (_FatherName != null)
                {
                    cmd.Parameters.AddWithValue("FatherName", _FatherName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("FatherName", null);
                }
                if (_MotherName != null)
                {
                    cmd.Parameters.AddWithValue("MotherName", _MotherName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("MotherName", null);
                }

                if (_SpouseName != null)
                {
                    cmd.Parameters.AddWithValue("SpouseName", _SpouseName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("SpouseName", null);
                }

                if (_PermanentAddress != null)
                {
                    cmd.Parameters.AddWithValue("PermanentAddress", _PermanentAddress);
                }
                else
                {
                    cmd.Parameters.AddWithValue("PermanentAddress", null);
                }

                if (_Nationality != null)
                {
                    cmd.Parameters.AddWithValue("Nationality ", _Nationality);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Nationality ", null);
                }
                if (_PassportNo != null)
                {
                    cmd.Parameters.AddWithValue("PassportNo", _PassportNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("PassportNo", null);
                }
                if (_IsCLP != null)
                {
                    cmd.Parameters.AddWithValue("IsCLP ", _IsCLP);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IsCLP ", -1);
                }
                if (_IsRegister != null)
                {
                    cmd.Parameters.AddWithValue("IsRegister ", _IsRegister);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IsRegister ", -1);
                }


                cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Update t_RetailConsumer Set ConsumerName=?,Address=?, Email=?, NationalID=?, CellNo=?, PhoneNo=?, DateofBirth=?, "
                    + " VatRegNo=?, ShortName=?, FatherName=?, MotherName=?, SpouseName=?, PermanentAddress=?, Nationality=?, PassportNo=?, IsCLP = ?, IsRegister = ? "
                    + " Where ConsumerID=? and WarehouseID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerName", _ConsumerName);
                cmd.Parameters.AddWithValue("Address", _Address);
                cmd.Parameters.AddWithValue("Email", _Email);
                if (_NationalID != null)
                {
                    cmd.Parameters.AddWithValue("NationalID", _NationalID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("NationalID", null);
                }
                cmd.Parameters.AddWithValue("CellNo", _CellNo);

                if (_PhoneNo != null)
                {
                    cmd.Parameters.AddWithValue("PhoneNo", _PhoneNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("PhoneNo", null);
                }

                if (_DateofBirth != null)
                {
                    cmd.Parameters.AddWithValue("DateofBirth", Convert.ToDateTime(_DateofBirth));
                }
                else
                {
                    cmd.Parameters.AddWithValue("DateofBirth", null);
                }

                if (_VatRegNo != null)
                {
                    cmd.Parameters.AddWithValue("VatRegNo", _VatRegNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("VatRegNo", null);
                }

                if (_ShortName != null)
                {
                    cmd.Parameters.AddWithValue("ShortName", _ShortName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ShortName", null);
                }

                if (_FatherName != null)
                {
                    cmd.Parameters.AddWithValue("FatherName", _FatherName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("FatherName", null);
                }
                if (_MotherName != null)
                {
                    cmd.Parameters.AddWithValue("MotherName", _MotherName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("MotherName", null);
                }

                if (_SpouseName != null)
                {
                    cmd.Parameters.AddWithValue("SpouseName", _SpouseName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("SpouseName", null);
                }

                if (_PermanentAddress != null)
                {
                    cmd.Parameters.AddWithValue("PermanentAddress", _PermanentAddress);
                }
                else
                {
                    cmd.Parameters.AddWithValue("PermanentAddress", null);
                }

                if (_Nationality != null)
                {
                    cmd.Parameters.AddWithValue("Nationality ", _Nationality);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Nationality ", null);
                }
                if (_PassportNo != null)
                {
                    cmd.Parameters.AddWithValue("PassportNo", _PassportNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("PassportNo", null);
                }
                if (_IsCLP != null)
                {
                    cmd.Parameters.AddWithValue("IsCLP ", _IsCLP);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IsCLP ", -1);
                }
                if (_IsRegister != null)
                {
                    cmd.Parameters.AddWithValue("IsRegister ", _IsRegister);
                }
                else
                {
                    cmd.Parameters.AddWithValue("IsRegister ", -1);
                }


                cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
                cmd.Parameters.AddWithValue("WarehouseID", _WarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateEmail(int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Update t_RetailConsumer Set Email=?, IsVerifiedEmail =?,SecondaryConsumer = ?, SecondaryMobileNo = ? Where ConsumerID=? and CustomerID=?";

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Email", _Email);
                cmd.Parameters.AddWithValue("IsVerifiedEmail", _nIsVerifiedEmail);
                cmd.Parameters.AddWithValue("SecondaryConsumer", _sSecondaryConsumer);
                cmd.Parameters.AddWithValue("SecondaryMobileNo", _sSecondaryMobileNo);

                cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);

                nCount = cmd.ExecuteNonQuery();
                cmd.Dispose();

                _oDataTran = new DataTran();
                _oDataTran.TableName = "t_RetailConsumer";
                _oDataTran.DataID = _ConsumerID;
                _oDataTran.WarehouseID = nWarehouseID;
                _oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                _oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                _oDataTran.BatchNo = 0;
                _oDataTran.CreateDate = DateTime.Now;
                _oDataTran.AddForTDPOS();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void UpdateEmailRT(int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Update t_RetailConsumer Set Email=?, IsVerifiedEmail =?,SecondaryConsumer = ?, SecondaryMobileNo = ? Where ConsumerID=? and CustomerID=? and WarehouseID=?";

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Email", _Email);
                cmd.Parameters.AddWithValue("IsVerifiedEmail", _nIsVerifiedEmail);
                cmd.Parameters.AddWithValue("SecondaryConsumer", _sSecondaryConsumer);
                cmd.Parameters.AddWithValue("SecondaryMobileNo", _sSecondaryMobileNo);

                cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);
                cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

                nCount = cmd.ExecuteNonQuery();
                cmd.Dispose();
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }




        //public void RefreshForPOS()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    int nCount = 0;
        //    string sSql = "  ";

        //    cmd.Parameters.AddWithValue("ConsumerID", _ConsumerID);
        //    cmd.Parameters.AddWithValue("CustomerID", _CustomerID);

        //    try
        //    {
        //        cmd.CommandText = sSql;

        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            _nParentCustomerID = int.Parse(reader["ParentCustomerID"].ToString());
        //            _ConsumerCode = reader["ConsumerCode"].ToString();
        //            _ConsumerName = (string)reader["ConsumerName"];
        //            _ConsumerType = int.Parse(reader["ConsumerType"].ToString());
        //            _Address = reader["Address"].ToString();
        //            _Email = reader["Email"].ToString();
        //            if (reader["EmployeeCode"] != DBNull.Value)
        //                _sEmployeeCode = reader["EmployeeCode"].ToString();
        //            else _sEmployeeCode = "";
        //            _NationalID = reader["NationalID"].ToString();
        //            _CellNo = reader["CellNo"].ToString();
        //            _PhoneNo = reader["PhoneNo"].ToString();
        //            if (reader["DateofBirth"] != DBNull.Value)
        //                _DateofBirth = Convert.ToDateTime(reader["DateofBirth"]);
        //            _VatRegNo = reader["VatRegNo"].ToString();

        //            _ShortName = reader["ShortName"].ToString();
        //            _FatherName = reader["FatherName"].ToString();
        //            _MotherName = reader["MotherName"].ToString();
        //            _SpouseName = reader["SpouseName"].ToString();
        //            _PermanentAddress = reader["PermanentAddress"].ToString();
        //            _Nationality = reader["Nationality"].ToString();
        //            _PassportNo = reader["PassportNo"].ToString();

        //            if (reader["IsCLP"] != DBNull.Value)
        //                _IsCLP = Convert.ToInt32(reader["IsCLP"]);
        //            else _IsCLP = 0;
        //            if (reader["CurrentCLP"] != DBNull.Value)
        //                _CurrentCLP = Convert.ToInt32(reader["CurrentCLP"]);
        //            else _CurrentCLP = 0;
        //            if (reader["IsRegister"] != DBNull.Value)
        //                _IsRegister = Convert.ToInt32(reader["IsRegister"]);
        //            else _IsRegister = 0;
        //            if (reader["IsAuthorized"] != DBNull.Value)
        //                _IsAuthorized = Convert.ToInt32(reader["IsAuthorized"]);
        //            else _IsAuthorized = 0;
        //            if (reader["SalesType"] != DBNull.Value)
        //                _nSalesType = Convert.ToInt32(reader["SalesType"]);
        //            else _nSalesType = (int)Dictionary.SalesType.Retail;
        //            _sSalesTypeName = (string)reader["SalesTypeName"];

        //            nCount++;
        //        }

        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
    }
    public class RetailConsumers : CollectionBase
    {
        public RetailConsumer this[int i]
        {
            get { return (RetailConsumer)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(RetailConsumer oRetailConsumer)
        {
            InnerList.Add(oRetailConsumer);
        }
        public void Refresh(string sCustomerCode, string sCustomerName, string sCellNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "SELECT a.*,CustomerCode,CustomerName FROM t_RetailConsumer A,t_Customer B where a.CustomerID=b.CustomerID";

            if (sCustomerCode.Trim() != "")
            {
                sSql = sSql + " and ConsumerCode= '" + sCustomerCode + "'";
            }
            if (sCustomerName.Trim() != "")
            {

                sSql = sSql + " and ConsumerName like '%" + sCustomerName + "%'";
            }
            if (sCellNo.Trim() != "")
            {
                sSql = sSql + " and CellNo like '%" + sCellNo + "%'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RetailConsumer oRetailConsumer = new RetailConsumer();
                    oRetailConsumer.ConsumerID = int.Parse(reader["ConsumerID"].ToString());
                    oRetailConsumer.ConsumerCode = reader["ConsumerCode"].ToString();
                    oRetailConsumer.ConsumerName = (string)reader["ConsumerName"];
                    oRetailConsumer.CellNo = (string)reader["CellNo"];
                    oRetailConsumer.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oRetailConsumer.SalesType = int.Parse(reader["SalesType"].ToString());
                    oRetailConsumer.CustomerCode = (string)reader["CustomerCode"];
                    oRetailConsumer.CustomerName = (string)reader["CellNo"];

                    if (reader["IsVerifiedEmail"] != DBNull.Value)
                        oRetailConsumer.IsVerifiedEmail = Convert.ToInt32(reader["IsVerifiedEmail"]);
                    else oRetailConsumer.IsVerifiedEmail = 0;

                    if (reader["VatRegNo"] != DBNull.Value)
                        oRetailConsumer.VatRegNo = reader["VatRegNo"].ToString();
                    else oRetailConsumer.VatRegNo = "";

                    InnerList.Add(oRetailConsumer);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshRT(string sCustomerCode, string sCustomerName, string sMobileNo,string sPhoneNo,string sAddress,string sEmail,int _nSalesType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "Select top 50 a.ConsumerID,a.ConsumerCode,a.ConsumerName, " +
                "isnull(a.MobileNo,'') MobileNo,isnull(a.PhoneNo,'') PhoneNo, " +
                "isnull(a.Address,'') Address,isnull(a.Email,'')  Email, " +
                "isnull(b.ConsumerID,0) as RetailConsumerID, " +
                "isnull(b.ConsumerCode,'') as RetailConsumerCode,isnull(b.ConsumerName,'') RetailConsumerName " +
                "From t_ConsumerDetail a " +
                "left outer join  " +
                "(Select * From t_RetailConsumer where WarehouseID=" + Utility.WarehouseID + " and SalesType=" + _nSalesType + ") b  " +
                "on a.ConsumerID=b.MotherConsumerID where 1=1  ";

            if (sCustomerCode != "")
            {
                sSql = sSql + " and a.ConsumerCode like '%" + sCustomerCode + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " and a.ConsumerName like '%" + sCustomerName + "%'";
            }
            if (sMobileNo != "")
            {
                sSql = sSql + " and a.MobileNo like '%" + sMobileNo + "%' ";
            }
            if (sPhoneNo != "")
            {
                sSql = sSql + " and a.PhoneNo like '%" + sPhoneNo + "%'";
            }

            if (sAddress != "")
            {
                sSql = sSql + " and a.Address like '%" + sAddress + "%'";
            }
            if (sEmail != "")
            {
                sSql = sSql + " and a.Email like '%" + sEmail + "%' ";
            }
            sSql = sSql + " order by a.ConsumerID ";

            
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RetailConsumer oRetailConsumer = new RetailConsumer();
                    oRetailConsumer.ConsumerID = int.Parse(reader["ConsumerID"].ToString());
                    oRetailConsumer.ConsumerCode = reader["ConsumerCode"].ToString();
                    oRetailConsumer.ConsumerName = (string)reader["ConsumerName"];
                    oRetailConsumer.CellNo = (string)reader["MobileNo"];
                    oRetailConsumer.PhoneNo = (string)reader["PhoneNo"];
                    oRetailConsumer.Address = (string)reader["Address"];
                    oRetailConsumer.Email = (string)reader["Email"];

                    oRetailConsumer.RetailConsumerID = int.Parse(reader["RetailConsumerID"].ToString());
                    oRetailConsumer.RetailConsumerCode = reader["RetailConsumerCode"].ToString();
                    oRetailConsumer.RetailConsumerName = (string)reader["RetailConsumerName"];
                    InnerList.Add(oRetailConsumer);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshConsumerByType(string sCustomerCode, string sCustomerName, string sCellNo, int nSalesType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "SELECT a.*,CustomerCode,CustomerName FROM t_RetailConsumer A,t_Customer B where a.CustomerID=b.CustomerID and a.SalesType=" + nSalesType + "";

            if (sCustomerCode.Trim() != "")
            {
                sSql = sSql + " and ConsumerCode= '" + sCustomerCode + "'";
            }
            if (sCustomerName.Trim() != "")
            {

                sSql = sSql + " and ConsumerName like '%" + sCustomerName + "%'";
            }
            if (sCellNo.Trim() != "")
            {
                sSql = sSql + " and CellNo like '%" + sCellNo + "%'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RetailConsumer oRetailConsumer = new RetailConsumer();
                    oRetailConsumer.ConsumerID = int.Parse(reader["ConsumerID"].ToString());
                    oRetailConsumer.ConsumerCode = reader["ConsumerCode"].ToString();
                    oRetailConsumer.ConsumerName = (string)reader["ConsumerName"];
                    oRetailConsumer.CellNo = (string)reader["CellNo"];
                    oRetailConsumer.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oRetailConsumer.SalesType = int.Parse(reader["SalesType"].ToString());
                    oRetailConsumer.CustomerCode = (string)reader["CustomerCode"];
                    oRetailConsumer.CustomerName = (string)reader["CustomerName"];

                    if (reader["IsVerifiedEmail"] != DBNull.Value)
                        oRetailConsumer.IsVerifiedEmail = Convert.ToInt32(reader["IsVerifiedEmail"]);
                    else oRetailConsumer.IsVerifiedEmail = 0;

                    if (reader["VatRegNo"] != DBNull.Value)
                        oRetailConsumer.VatRegNo = reader["VatRegNo"].ToString();
                    else oRetailConsumer.VatRegNo = "";

                    InnerList.Add(oRetailConsumer);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshConsumerByTypeHO(string sCustomerCode, string sCustomerName, string sCellNo, int nSalesType,int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "SELECT a.*,CustomerCode,CustomerName FROM t_RetailConsumer A,t_Customer B where a.CustomerID=b.CustomerID and a.SalesType=" + nSalesType + " and a.WarehouseID=" + nWarehouseID + "";

            if (sCustomerCode.Trim() != "")
            {
                sSql = sSql + " and ConsumerCode= '" + sCustomerCode + "'";
            }
            if (sCustomerName.Trim() != "")
            {

                sSql = sSql + " and ConsumerName like '%" + sCustomerName + "%'";
            }
            if (sCellNo.Trim() != "")
            {
                sSql = sSql + " and CellNo like '%" + sCellNo + "%'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RetailConsumer oRetailConsumer = new RetailConsumer();
                    oRetailConsumer.ConsumerID = int.Parse(reader["ConsumerID"].ToString());
                    oRetailConsumer.ConsumerCode = reader["ConsumerCode"].ToString();
                    oRetailConsumer.ConsumerName = (string)reader["ConsumerName"];
                    oRetailConsumer.CellNo = (string)reader["CellNo"];
                    oRetailConsumer.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oRetailConsumer.SalesType = int.Parse(reader["SalesType"].ToString());
                    oRetailConsumer.CustomerCode = (string)reader["CustomerCode"];
                    oRetailConsumer.CustomerName = (string)reader["CustomerName"];

                    if (reader["IsVerifiedEmail"] != DBNull.Value)
                        oRetailConsumer.IsVerifiedEmail = Convert.ToInt32(reader["IsVerifiedEmail"]);
                    else oRetailConsumer.IsVerifiedEmail = 0;

                    if (reader["VatRegNo"] != DBNull.Value)
                        oRetailConsumer.VatRegNo = reader["VatRegNo"].ToString();
                    else oRetailConsumer.VatRegNo = "";

                    InnerList.Add(oRetailConsumer);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetRetailConsumer()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "select a.* from t_RetailConsumer a,t_DataTransfer b where a.consumerid=b.dataid and b.tablename='t_RetailConsumer' and Isdownload in (1,2) ";
           
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RetailConsumer oRetailConsumer = new RetailConsumer();
                    oRetailConsumer.ConsumerID = int.Parse(reader["ConsumerID"].ToString());
                    oRetailConsumer.ConsumerCode = reader["ConsumerCode"].ToString();
                    oRetailConsumer.ConsumerName = (string)reader["ConsumerName"];
                    oRetailConsumer.ConsumerType = int.Parse(reader["ConsumerType"].ToString());
                    oRetailConsumer.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oRetailConsumer.Address = reader["Address"].ToString();
                    oRetailConsumer.Email = reader["Email"].ToString();
                    if (reader["EmployeeCode"] != DBNull.Value)
                        oRetailConsumer.EmployeeCode = reader["EmployeeCode"].ToString();
                    else oRetailConsumer.EmployeeCode = "";
                    oRetailConsumer.NationalID = reader["NationalID"].ToString();
                    oRetailConsumer.CellNo = reader["CellNo"].ToString();
                    oRetailConsumer.PhoneNo = reader["PhoneNo"].ToString();
                    if (reader["DateofBirth"] != DBNull.Value)
                        oRetailConsumer.DateofBirth = Convert.ToDateTime(reader["DateofBirth"]);
                    oRetailConsumer.VatRegNo = reader["VatRegNo"].ToString();

                    oRetailConsumer.ShortName = reader["ShortName"].ToString();
                    oRetailConsumer.FatherName = reader["FatherName"].ToString();
                    oRetailConsumer.MotherName = reader["MotherName"].ToString();
                    oRetailConsumer.SpouseName = reader["SpouseName"].ToString();
                    oRetailConsumer.PermanentAddress = reader["PermanentAddress"].ToString();
                    oRetailConsumer.Nationality = reader["Nationality"].ToString();
                    oRetailConsumer.PassportNo = reader["PassportNo"].ToString();

                    if (reader["IsCLP"] != DBNull.Value)
                        oRetailConsumer.IsCLP = Convert.ToInt32(reader["IsCLP"]);
                    else oRetailConsumer.IsCLP = 0;
                    if (reader["CurrentCLP"] != DBNull.Value)
                        oRetailConsumer.CurrentCLP = Convert.ToInt32(reader["CurrentCLP"]);
                    else oRetailConsumer.CurrentCLP = 0;
                    if (reader["IsRegister"] != DBNull.Value)
                        oRetailConsumer.IsRegister = Convert.ToInt32(reader["IsRegister"]);
                    else oRetailConsumer.IsRegister = 0;
                    if (reader["IsAuthorized"] != DBNull.Value)
                        oRetailConsumer.IsAuthorized = Convert.ToInt32(reader["IsAuthorized"]);
                    else oRetailConsumer.IsRegister = 0;


                    InnerList.Add(oRetailConsumer);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForRegistration(int nIsRegister, int nCustomerID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "SELECT * FROM t_RetailConsumer Where IsRegister='" + nIsRegister + "' and  CustomerID='" + nCustomerID + "'";
           
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    RetailConsumer oRetailConsumer = new RetailConsumer();
                    oRetailConsumer.ConsumerID = int.Parse(reader["ConsumerID"].ToString());
                    oRetailConsumer.ConsumerCode = reader["ConsumerCode"].ToString();
                    oRetailConsumer.ConsumerName = (string)reader["ConsumerName"];
                    oRetailConsumer.ConsumerType = int.Parse(reader["ConsumerType"].ToString());
                    oRetailConsumer.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oRetailConsumer.Address = reader["Address"].ToString();
                    oRetailConsumer.Email = reader["Email"].ToString();
                    if (reader["EmployeeCode"] != DBNull.Value)
                        oRetailConsumer.EmployeeCode = reader["EmployeeCode"].ToString();
                    else oRetailConsumer.EmployeeCode = "";
                    oRetailConsumer.NationalID = reader["NationalID"].ToString();
                    oRetailConsumer.CellNo = reader["CellNo"].ToString();
                    oRetailConsumer.PhoneNo = reader["PhoneNo"].ToString();
                    if (reader["DateofBirth"] != DBNull.Value)
                        oRetailConsumer.DateofBirth = Convert.ToDateTime(reader["DateofBirth"]);
                    oRetailConsumer.VatRegNo = reader["VatRegNo"].ToString();

                    oRetailConsumer.ShortName = reader["ShortName"].ToString();
                    oRetailConsumer.FatherName = reader["FatherName"].ToString();
                    oRetailConsumer.MotherName = reader["MotherName"].ToString();
                    oRetailConsumer.SpouseName = reader["SpouseName"].ToString();
                    oRetailConsumer.PermanentAddress = reader["PermanentAddress"].ToString();
                    oRetailConsumer.Nationality = reader["Nationality"].ToString();
                    oRetailConsumer.PassportNo = reader["PassportNo"].ToString();

                    if (reader["IsCLP"] != DBNull.Value)
                        oRetailConsumer.IsCLP = Convert.ToInt32(reader["IsCLP"]);
                    else oRetailConsumer.IsCLP = 0;
                    if (reader["CurrentCLP"] != DBNull.Value)
                        oRetailConsumer.CurrentCLP = Convert.ToInt32(reader["CurrentCLP"]);
                    else oRetailConsumer.CurrentCLP = 0;
                    if (reader["IsRegister"] != DBNull.Value)
                        oRetailConsumer.IsRegister = Convert.ToInt32(reader["IsRegister"]);
                    else oRetailConsumer.IsRegister = 0;
                    if (reader["IsAuthorized"] != DBNull.Value)
                        oRetailConsumer.IsAuthorized = Convert.ToInt32(reader["IsAuthorized"]);
                    else oRetailConsumer.IsRegister = 0;

                    InnerList.Add(oRetailConsumer);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshConsumer(string sConsumerCode, string sConsumerName, string sCellNo, int nSalesType)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            {
                sSql = @"Select CustomerCode,CustomerName,ConsumerID,ConsumerCode,ConsumerName, 
                        isnull(Address,'') Address,isnull(CellNo,'') CellNo,isnull(PhoneNo,'') PhoneNo, 
                        isnull(Email,'') Email,SalesType, 
                        isnull(NationalID,'') NationalID,isnull(VatRegNo,'') VatRegNo,  
                        isnull(ShortName,'') ShortName,isnull(FatherName,'') FatherName, 
                        isnull(MotherName,'') MotherName,isnull(SpouseName,'') SpouseName, 
                        isnull(PermanentAddress,'') PermanentAddress,isnull(Nationality,'') Nationality, 
                        isnull(PassportNo,'') PassportNo, SalesType,
                        SalesTypeName=Case when SalesType=1 then 'Retail'  
                        when SalesType=2 then 'B2C'  
                        when SalesType=3 then 'B2B'  
                        when SalesType=4 then 'HPA'  
                        when SalesType=5 then 'Dealer' else 'Other' end
                        From t_RetailConsumer a,t_Customer b where a.CustomerID=b.CustomerID ";
            }

            if (sConsumerCode != "")
            {
                sSql = sSql + " AND ConsumerCode like '%" + sConsumerCode + "%'";
            }
            if (sConsumerName != "")
            {
                sSql = sSql + " AND ConsumerName like '%" + sConsumerName + "%'";
            }
            if (sCellNo != "")
            {
                sSql = sSql + " AND CellNo like '%" + sCellNo + "%'";
            }
            if (nSalesType != -1)
            {
                sSql = sSql + " AND SalesType=" + nSalesType + "";
            }
            sSql = sSql + " order by ConsumerID desc ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailConsumer oRetailConsumer = new RetailConsumer();

                    oRetailConsumer.CustomerCode = (reader["CustomerCode"].ToString());
                    oRetailConsumer.CustomerName = (reader["CustomerName"].ToString());
                    oRetailConsumer.ConsumerID = int.Parse(reader["ConsumerID"].ToString());
                    oRetailConsumer.ConsumerCode = (reader["ConsumerCode"].ToString());
                    oRetailConsumer.ConsumerName = (reader["ConsumerName"].ToString());
                    oRetailConsumer.Address = (reader["Address"].ToString());
                    oRetailConsumer.CellNo = (reader["CellNo"].ToString());
                    oRetailConsumer.PhoneNo = (reader["PhoneNo"].ToString());
                    oRetailConsumer.Email = (reader["Email"].ToString());
                    oRetailConsumer.NationalID = (reader["NationalID"].ToString());
                    oRetailConsumer.VatRegNo = (reader["VatRegNo"].ToString());
                    oRetailConsumer.ShortName = reader["ShortName"].ToString();
                    oRetailConsumer.FatherName = reader["FatherName"].ToString();
                    oRetailConsumer.MotherName = reader["MotherName"].ToString();
                    oRetailConsumer.SpouseName = reader["SpouseName"].ToString();
                    oRetailConsumer.PermanentAddress = reader["PermanentAddress"].ToString();
                    oRetailConsumer.Nationality = reader["Nationality"].ToString();
                    oRetailConsumer.PassportNo = reader["PassportNo"].ToString();
                    oRetailConsumer.SalesType = int.Parse(reader["SalesType"].ToString());
                    oRetailConsumer.SalesTypeName = (reader["SalesTypeName"].ToString());


                    //oRetailConsumer.InvoiceNo = (reader["InvoiceNo"].ToString());
                    //oRetailConsumer.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    //oRetailConsumer.ProductCode = (reader["ProductCode"].ToString());
                    //oRetailConsumer.ProductName = (reader["ProductName"].ToString());
                    //oRetailConsumer.AGID = int.Parse(reader["AGID"].ToString());
                    //oRetailConsumer.AGName = (reader["AGName"].ToString());
                    //oRetailConsumer.ASGID = int.Parse(reader["ASGID"].ToString());
                    //oRetailConsumer.ASGName = (reader["ASGName"].ToString());
                    //oRetailConsumer.MAGID = int.Parse(reader["MAGID"].ToString());
                    //oRetailConsumer.MAGName = (reader["MAGName"].ToString());
                    //oRetailConsumer.PGID = int.Parse(reader["PGID"].ToString());
                    //oRetailConsumer.PGName = (reader["PGName"].ToString());
                    //oRetailConsumer.SalesQty = int.Parse(reader["SalesQty"].ToString());
                    //oRetailConsumer.Amount = Convert.ToDouble(reader["Amount"].ToString());

                    InnerList.Add(oRetailConsumer);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshConsumerRT(string sConsumerCode, string sConsumerName, string sCellNo, int nMAGID, int nSalesType,int nWHID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            {
                sSql = " Select CustomerCode,CustomerName,ConsumerID,ConsumerCode,ConsumerName, " +
                       " isnull(Address,'') Address,isnull(CellNo,'') CellNo,isnull(PhoneNo,'') PhoneNo, " +
                       " isnull(Email,'') Email,SalesType, " +
                       " isnull(NationalID,'') NationalID,isnull(VatRegNo,'') VatRegNo,  " +
                       " isnull(ShortName,'') ShortName,isnull(FatherName,'') FatherName, " +
                       " isnull(MotherName,'') MotherName,isnull(SpouseName,'') SpouseName, " +
                       " isnull(PermanentAddress,'') PermanentAddress,isnull(Nationality,'') Nationality, " +
                       " isnull(PassportNo,'') PassportNo, " +
                       " SalesTypeName=Case when SalesType=1 then 'Retail'  " +
                       " when SalesType=2 then 'B2C'  " +
                       " when SalesType=3 then 'B2B'  " +
                       " when SalesType=4 then 'HPA'  " +
                       " when SalesType=5 then 'Dealer' when SalesType=6 then 'eStore' else 'Other' end, " +
                       " InvoiceNo,InvoiceDate,ProductCode,ProductName,AGID,AGName, " +
                       " ASGID,ASGName,MAGID,MAGName,PGID,PGName,(Quantity+FreeQty) as SalesQty, " +
                       " (UnitPrice*Quantity) as Amount " +
                       " From t_SalesinvoiceDetail a,t_SalesInvoice b,t_RetailConsumer c,v_ProductDetails d,t_Customer e " +
                       " where a.InvoiceID=b.InvoiceID and b.SundryCustomerID=c.ConsumerID and b.WarehouseID=c.WarehouseID and a.ProductID=d.ProductID and  " +
                       " b.CustomerID=e.CustomerID and InvoiceTypeID not in (6,7,8,9,10,11,12) and b.WarehouseID=" + nWHID + "";

            }

            if (sConsumerCode != "")
            {
                sSql = sSql + " AND ConsumerCode like '%" + sConsumerCode + "%'";
            }
            if (sConsumerName != "")
            {
                sSql = sSql + " AND ConsumerName like '%" + sConsumerName + "%'";
            }
            if (sCellNo != "")
            {
                sSql = sSql + " AND CellNo like '%" + sCellNo + "%'";
            }
            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAGID + "";
            }
            if (nSalesType != -1)
            {
                sSql = sSql + " AND SalesType=" + nSalesType + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RetailConsumer oRetailConsumer = new RetailConsumer();

                    oRetailConsumer.CustomerCode = (reader["CustomerCode"].ToString());
                    oRetailConsumer.CustomerName = (reader["CustomerName"].ToString());
                    oRetailConsumer.ConsumerID = int.Parse(reader["ConsumerID"].ToString());
                    oRetailConsumer.ConsumerCode = (reader["ConsumerCode"].ToString());
                    oRetailConsumer.ConsumerName = (reader["ConsumerName"].ToString());
                    oRetailConsumer.Address = (reader["Address"].ToString());
                    oRetailConsumer.CellNo = (reader["CellNo"].ToString());
                    oRetailConsumer.PhoneNo = (reader["PhoneNo"].ToString());
                    oRetailConsumer.Email = (reader["Email"].ToString());
                    oRetailConsumer.NationalID = (reader["NationalID"].ToString());
                    oRetailConsumer.VatRegNo = (reader["VatRegNo"].ToString());
                    oRetailConsumer.ShortName = reader["ShortName"].ToString();
                    oRetailConsumer.FatherName = reader["FatherName"].ToString();
                    oRetailConsumer.MotherName = reader["MotherName"].ToString();
                    oRetailConsumer.SpouseName = reader["SpouseName"].ToString();
                    oRetailConsumer.PermanentAddress = reader["PermanentAddress"].ToString();
                    oRetailConsumer.Nationality = reader["Nationality"].ToString();
                    oRetailConsumer.PassportNo = reader["PassportNo"].ToString();

                    oRetailConsumer.SalesType = int.Parse(reader["SalesType"].ToString());
                    oRetailConsumer.SalesTypeName = (reader["SalesTypeName"].ToString());
                    oRetailConsumer.InvoiceNo = (reader["InvoiceNo"].ToString());
                    oRetailConsumer.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oRetailConsumer.ProductCode = (reader["ProductCode"].ToString());
                    oRetailConsumer.ProductName = (reader["ProductName"].ToString());
                    oRetailConsumer.AGID = int.Parse(reader["AGID"].ToString());
                    oRetailConsumer.AGName = (reader["AGName"].ToString());
                    oRetailConsumer.ASGID = int.Parse(reader["ASGID"].ToString());
                    oRetailConsumer.ASGName = (reader["ASGName"].ToString());
                    oRetailConsumer.MAGID = int.Parse(reader["MAGID"].ToString());
                    oRetailConsumer.MAGName = (reader["MAGName"].ToString());
                    oRetailConsumer.PGID = int.Parse(reader["PGID"].ToString());
                    oRetailConsumer.PGName = (reader["PGName"].ToString());
                    oRetailConsumer.SalesQty = int.Parse(reader["SalesQty"].ToString());
                    oRetailConsumer.Amount = Convert.ToDouble(reader["Amount"].ToString());

                    InnerList.Add(oRetailConsumer);

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

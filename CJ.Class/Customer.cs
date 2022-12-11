// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak K. C.
// Date: April 25, 2011
// Time :  12:00 PM
// Description: Class for Customer.
// Modify Person And Date:Uttam Kar 18 May,2014
// </summary>


using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;

namespace CJ.Class
{

    public class Customer
    {
        /// <summary>
        /// For Customer Varification
        /// Shuvo
        /// Date-28-02-2016
        /// </summary>
        private int _nVarificationID;
        private int _nNatureofBusiness;
        private int _nType;
        private int _nCompanyType;
        private int _nNoOfEmployee;
        private double _ExpectedSales;
        private int _nCompanyCategory;
        private int _nVerifiedThrough;
        private string _sRemarks;
        private DateTime _dtVerifiedDate;
        private string _sVerifiedBy;

        private int _nDataID;
        private string _sName;

        public int DataID
        {
            get { return _nDataID; }
            set { _nDataID = value; }
        }

        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
        }

        public int VarificationID
        {
            get { return _nVarificationID; }
            set { _nVarificationID = value; }
        }
        public int NatureofBusiness
        {
            get { return _nNatureofBusiness; }
            set { _nNatureofBusiness = value; }
        }
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }
        public int CompanyType
        {
            get { return _nCompanyType; }
            set { _nCompanyType = value; }
        }
        public int NoOfEmployee
        {
            get { return _nNoOfEmployee; }
            set { _nNoOfEmployee = value; }
        }
        public double ExpectedSales
        {
            get { return _ExpectedSales; }
            set { _ExpectedSales = value; }
        }
        public int CompanyCategory
        {
            get { return _nCompanyCategory; }
            set { _nCompanyCategory = value; }
        }
        public int VerifiedThrough
        {
            get { return _nVerifiedThrough; }
            set { _nVerifiedThrough = value; }
        }
        public DateTime VerifiedDate
        {
            get { return _dtVerifiedDate; }
            set { _dtVerifiedDate = value; }
        }
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }

        public string VerifiedBy
        {
            get { return _sVerifiedBy; }
            set { _sVerifiedBy = value; }
        }

        /// <summary>
        /// For Customer Varification
        /// Shuvo
        /// Date-28-02-2016
        /// </summary>

        private int _nWarehouseID;
        private int _nCustomerID;
        private string _sCustomerCode;
        private string _sCustomerName;
        private string _sCustomerAddress;
        private string _sCustomerTelephone;
        private string _sCustomerFax;
        private string _sCellPhoneNo;
        private string _sContactPerson;
        private string _sContactDesignation;
        private int _nIsActive;
        private int _nCustTypeID;
        private string _sCustomerTypeName;
        private int _nMarketGroupID;
        private int _nGeoLocationID;
        private string _sEmailAddress;
        private DateTime _dEnrollmentDate;
        private int _nUploadStatus;
        private DateTime _dUploadDate;
        private DateTime _dDownloadDate;
        private int _nRowStatus;
        private int _nTerminal;
        private DateTime _dEntryDate;
        private int _nEntryUserID;
        private DateTime _dUpdateDate;

        private DateTime _dApprovedDate;
        private int _nApprovedUserID;

        public DateTime ApprovedDate
        {
            get { return _dApprovedDate; }
            set { _dApprovedDate = value; }

        }
        public int ApprovedUserID
        {
            get { return _nApprovedUserID; }
            set { _nApprovedUserID = value; }
        }


        private int _nUpdateUserID;
        //Uttam
        private int _nAreaID;
        private string _sAreaName;
        //Uttam
        private int _nTerritoryID;
        private string _sTerritoryName;
        //Uttam
        private int _nDistrictID;
        private string _sTerritory;
        private string _sChannelDescription;
        private int _nChannelID;
        private int _nCreditlimitID;
        private int _nMaxCreditLimit;
        private double _nMinCreditLimit;
        private int _nParentCustomerID;
        private string _sParentCustomerCode;
        private string _sParentCustomerName;
        private DateTime _dEffectiveDate;
        private DateTime _dExpiryDate;
        private int _nUserID;
        private bool _bFlag;
        private string _sShortCode;
        private string _sDistrictName;
        private int _nThanaID;
        private int _nIsCustomerAccount;
        public int IsCustomerAccount
        {
            get { return _nIsCustomerAccount; }
            set { _nIsCustomerAccount = value; }
        }
        private string _sThanaName;
        private int _nPriceOptionID;
        private string _sCustomerShortName;
        private int _nStatus;
        private int _nIsVerified;
        public int IsVerified
        {
            get { return _nIsVerified; }
            set { _nIsVerified = value; }
        }
        private string _sCompany;
        public string Company
        {
            get { return _sCompany; }
            set { _sCompany = value; }
        }
        private string _sSystem;
        public string System
        {
            get { return _sSystem; }
            set { _sSystem = value; }
        }
        private string _sTranType;
        public string TranType
        {
            get { return _sTranType; }
            set { _sTranType = value; }
        }
        private string _sSalesType;
        public string SalesType
        {
            get { return _sSalesType; }
            set { _sSalesType = value; }
        }
        private string _sTranNo;
        public string TranNo
        {
            get { return _sTranNo; }
            set { _sTranNo = value; }
        }
        private DateTime _dtTranDate;
        public DateTime TranDate
        {
            get { return _dtTranDate; }
            set { _dtTranDate = value; }
        }
        private string _sProductCode;
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        private string _sTaxNumber;
        public string TaxNumber
        {
            get { return _sTaxNumber; }
            set { _sTaxNumber = value; }
        }
        private string _sProductName;
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        private int _nQty;
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
        private double _Amount;
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }


        private string _sShowroomCode;
        private string _sAlternativeCellNo;
        public string AlternativeCellNo
        {
            get { return _sAlternativeCellNo; }
            set { _sAlternativeCellNo = value; }
        }
        private string _sMobileNo;
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value; }
        }

        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
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

        public int ThanaID
        {
            get { return _nThanaID; }
            set { _nThanaID = value; }
        }

        public string ThanaName
        {
            get { return _sThanaName; }
            set { _sThanaName = value; }
        }

        public string ParentCustomerCode
        {
            get { return _sParentCustomerCode; }
            set { _sParentCustomerCode = value; }
        }

        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value; }
        }
        public string ParentCustomerName
        {
            get { return _sParentCustomerName; }
            set { _sParentCustomerName = value; }
        }

        public string CustomerTypeName
        {
            get { return _sCustomerTypeName; }
            set { _sCustomerTypeName = value; }
        }

        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }
        private int _nIsVerifiedEmail;
        public int IsVerifiedEmail
        {
            get { return _nIsVerifiedEmail; }
            set { _nIsVerifiedEmail = value; }
        }
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value; }
        }
        public string CustomerShortName
        {
            get { return _sCustomerShortName; }
            set { _sCustomerShortName = value; }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        public string CustomerAddress
        {
            get { return _sCustomerAddress; }
            set { _sCustomerAddress = value; }
        }
        public string CustomerTelephone
        {
            get { return _sCustomerTelephone; }
            set { _sCustomerTelephone = value; }

        }
        public string CustomerFax
        {
            get { return _sCustomerFax; }
            set { _sCustomerFax = value; }


        }
        public string CellPhoneNo
        {
            get { return _sCellPhoneNo; }
            set { _sCellPhoneNo = value; }


        }
        public String ContactPerson
        {

            get { return _sContactPerson; }
            set { _sContactPerson = value; }

        }
        public string ContactDesignation
        {
            get { return _sContactDesignation; }
            set { _sContactDesignation = value; }

        }
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }

        }
        public int CustTypeID
        {
            get { return _nCustTypeID; }
            set { _nCustTypeID = value; }

        }
        public int MarketGroupID
        {
            get { return _nMarketGroupID; }
            set { _nMarketGroupID = value; }


        }
        public int GeoLocationID
        {
            get { return _nGeoLocationID; }
            set { _nGeoLocationID = value; }

        }
        public string EmailAddress
        {
            get { return _sEmailAddress; }
            set { _sEmailAddress = value; }
        }
        public DateTime EnrollmentDate
        {
            get { return _dEnrollmentDate; }
            set { _dEnrollmentDate = value; }

        }
        public int UploadStatus
        {
            get { return _nUploadStatus; }
            set { _nUploadStatus = value; }

        }
        public DateTime UploadDate
        {
            get { return _dUploadDate; }
            set { _dUploadDate = value; }

        }
        public DateTime DownloadDate
        {
            get { return _dDownloadDate; }
            set { _dDownloadDate = value; }
        }
        public int RowStatus
        {
            get { return _nRowStatus; }
            set { _nRowStatus = value; }

        }
        public int Terminal
        {
            get { return _nTerminal; }
            set { _nTerminal = value; }
        }
        public DateTime EntryDate
        {
            get { return _dEntryDate; }
            set { _dEntryDate = value; }
        }
        public int EntryUserID
        {
            get { return _nEntryUserID; }
            set { _nEntryUserID = value; }

        }
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }


        }
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }

        }
        //Uttam
        public int AreaID
        {
            get { return _nAreaID; }
            set { _nAreaID = value; }

        }
        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value; }

        }
        //Uttam
        public int TerritoryID
        {
            get { return _nTerritoryID; }
            set { _nTerritoryID = value; }

        }
        public string DistrictName
        {
            get { return _sDistrictName; }
            set { _sDistrictName = value; }
        }
        //Uttam
        public int DistrictID
        {
            get { return _nDistrictID; }
            set { _nDistrictID = value; }
        }
        public string Territory
        {
            get { return _sTerritory; }
            set { _sTerritory = value; }

        }
        public string ChannelDescription
        {
            get { return _sChannelDescription; }
            set { _sChannelDescription = value; }

        }
        public int ChannelID
        {
            get { return _nChannelID; }
            set { _nChannelID = value; }
        }
        public int CreditlimitID
        {

            get { return _nCreditlimitID; }
            set { _nCreditlimitID = value; }
        }
        public int MaxCreditLimit
        {
            get { return _nMaxCreditLimit; }
            set { _nMaxCreditLimit = value; }

        }
        public double MinCreditLimit
        {
            get { return _nMinCreditLimit; }
            set { _nMinCreditLimit = value; }

        }
        public DateTime EffectiveDate
        {
            get { return _dEffectiveDate; }
            set { _dEffectiveDate = value; }
        }
        public DateTime ExpiryDate
        {
            get { return _dExpiryDate; }
            set { _dExpiryDate = value; }
        }
        public int UserID
        {
            get { return _nUserID; }
            set { _nUserID = value; }
        }
        public int ParentCustomerID
        {
            get { return _nParentCustomerID; }
            set { _nParentCustomerID = value; }

        }
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }
        public string ShortCode
        {
            get { return _sShortCode; }
            set { _sShortCode = value; }
        }
        public int PriceOptionID
        {
            get { return _nPriceOptionID; }
            set { _nPriceOptionID = value; }
        }
        public void InsertCustomer()
        {
            int nCustomerID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Select Max([CustomerID]) From t_Customer";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nCustomerID = 1;
                }
                else
                {
                    nCustomerID = Convert.ToInt32(maxID) + 1;
                }
                _nCustomerID = nCustomerID;
                cmd.Dispose();


                cmd = DBController.Instance.GetCommand();

                sSql = "Insert Into t_Customer (CustomerID,ParentCustomerID,CustomerCode,CustomerShortName,TaxNumber,CustomerName,CustomerAddress,CustomerTelephone,CustomerFax,CellPhoneNumber,ContactPerson,ContactDesignation, " +
                       "IsActive,CustTypeID,MarketGroupID,GeoLocationID,EmailAddress,EnrollmentDate,UploadStatus,UploadDate,DownloadDate,RowStatus,Terminal, " +
                       "EntryDate,EntryUserID,UpdateDate,UpdateUserID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";


                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                if (_nParentCustomerID != 0)
                {
                    cmd.Parameters.AddWithValue("ParentCustomerID", _nParentCustomerID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ParentCustomerID", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("CustomerCode", _sCustomerCode);
                cmd.Parameters.AddWithValue("CustomerShortName", _sCustomerShortName);
                cmd.Parameters.AddWithValue("TaxNumber", _sTaxNumber);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("CustomerAddress", _sCustomerAddress);
                cmd.Parameters.AddWithValue("CustomerTelephone", _sCustomerTelephone);
                cmd.Parameters.AddWithValue("CustomerFax ", _sCustomerFax);
                cmd.Parameters.AddWithValue("CellPhoneNumber", _sCellPhoneNo);
                cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                cmd.Parameters.AddWithValue("ContactDesignation", _sContactDesignation);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                if (_nCustTypeID != -1)
                {
                    cmd.Parameters.AddWithValue("CustTypeID", _nCustTypeID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CustTypeID", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("MarketGroupID", _nMarketGroupID);
                cmd.Parameters.AddWithValue("GeoLocationID", _nGeoLocationID);
                cmd.Parameters.AddWithValue("EmailAddress", _sEmailAddress);
                if (_dEnrollmentDate != null)
                {
                    cmd.Parameters.AddWithValue("EnrollmentDate", _dEnrollmentDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("EnrollmentDate", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("UploadStatus", DBNull.Value);
                cmd.Parameters.AddWithValue("UploadDate", DBNull.Value);
                cmd.Parameters.AddWithValue("DownloadDate", DBNull.Value);
                cmd.Parameters.AddWithValue("RowStatus", DBNull.Value);
                cmd.Parameters.AddWithValue("Terminal", DBNull.Value);
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Now);
                cmd.Parameters.AddWithValue("EntryUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DBNull.Value);
                cmd.Parameters.AddWithValue("UpdateUserID", DBNull.Value);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void AddTempCustomer()
        {
            int nMaxCustomerID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([CustomerID]) FROM t_CustomerTemp";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxCustomerID = 1;
                }
                else
                {
                    nMaxCustomerID = Convert.ToInt32(maxID) + 1;
                }
                _nCustomerID = nMaxCustomerID;


                //string sCustomerCode = "";
                //DateTime dOperationDate;

                SystemInfo oSystemInfo = new SystemInfo();
                oSystemInfo.Refresh();
                //sCustomerCode = oSystemInfo.Shortcode;
                //dOperationDate = Convert.ToDateTime(oSystemInfo.OperationDate);

                //_sCustomerCode = sCustomerCode + "-" + dOperationDate.Year.ToString() + "-" + nMaxCustomerID.ToString("0000");


                sSql = "INSERT INTO t_CustomerTemp (CustomerID, WarehouseID, ParentCustomerID, CustomerShortName, NewCustomerCode, CustomerName, CustomerAddress, CustomerTelephone, CustomerFax, CellPhoneNumber, ContactPerson, ContactDesignation, IsActive, CustTypeID, MarketGroupID, GeoLocationID, EmailAddress, EnrollmentDate, Terminal, CreateDate, CreateUserID, UpdateDate, UpdateUserID, ApprovedDate, ApprovedUserID, Status,TaxNumber) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("WarehouseID", oSystemInfo.WarehouseID);
                cmd.Parameters.AddWithValue("ParentCustomerID", oSystemInfo.CustomerID);
                cmd.Parameters.AddWithValue("CustomerShortName", _sCustomerShortName);
                cmd.Parameters.AddWithValue("NewCustomerCode", null);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("CustomerAddress", _sCustomerAddress);
                if (_sCustomerTelephone != null || _sCustomerTelephone != "")
                {
                    cmd.Parameters.AddWithValue("CustomerTelephone", _sCustomerTelephone);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CustomerTelephone", null);
                }
                if (_sCustomerFax != null || _sCustomerFax != "")
                {
                    cmd.Parameters.AddWithValue("CustomerFax", _sCustomerFax);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CustomerFax", null);
                }

                cmd.Parameters.AddWithValue("CellPhoneNumber", _sCellPhoneNo);
                cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                cmd.Parameters.AddWithValue("ContactDesignation", _sContactDesignation);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CustTypeID", _nCustTypeID);
                cmd.Parameters.AddWithValue("MarketGroupID", _nMarketGroupID);
                cmd.Parameters.AddWithValue("GeoLocationID", _nGeoLocationID);
                cmd.Parameters.AddWithValue("EmailAddress", _sEmailAddress);
                cmd.Parameters.AddWithValue("EnrollmentDate", _dEnrollmentDate);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);

                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("ApprovedUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("TaxNumber", _sTaxNumber);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_CustomerTemp";
                oDataTran.DataID = Convert.ToInt32(_nCustomerID);
                oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;
                if (oDataTran.CheckData() == false)
                {
                    oDataTran.AddForTDPOS();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddTempCustomerRT()
        {

            TELLib _oTELLib = new TELLib();
            
            int nMaxCustomerID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([CustomerID]) FROM t_CustomerTemp where WarehouseID=" + Utility.WarehouseID + "";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxCustomerID = 1;
                }
                else
                {
                    nMaxCustomerID = Convert.ToInt32(maxID) + 1;
                }
                _nCustomerID = nMaxCustomerID;
                                
                sSql = "INSERT INTO t_CustomerTemp (CustomerID, WarehouseID, ParentCustomerID, CustomerShortName, NewCustomerCode, CustomerName, CustomerAddress, CustomerTelephone, CustomerFax, CellPhoneNumber, ContactPerson, ContactDesignation, IsActive, CustTypeID, MarketGroupID, GeoLocationID, EmailAddress, EnrollmentDate, Terminal, CreateDate, CreateUserID, UpdateDate, UpdateUserID, ApprovedDate, ApprovedUserID, Status,TaxNumber) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("WarehouseID", Utility.WarehouseID);
                cmd.Parameters.AddWithValue("ParentCustomerID", Utility.CustomerID);
                cmd.Parameters.AddWithValue("CustomerShortName", _sCustomerShortName);
                cmd.Parameters.AddWithValue("NewCustomerCode", null);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("CustomerAddress", _sCustomerAddress);
                if (_sCustomerTelephone != null || _sCustomerTelephone != "")
                {
                    cmd.Parameters.AddWithValue("CustomerTelephone", _sCustomerTelephone);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CustomerTelephone", null);
                }
                if (_sCustomerFax != null || _sCustomerFax != "")
                {
                    cmd.Parameters.AddWithValue("CustomerFax", _sCustomerFax);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CustomerFax", null);
                }

                cmd.Parameters.AddWithValue("CellPhoneNumber", _sCellPhoneNo);
                cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                cmd.Parameters.AddWithValue("ContactDesignation", _sContactDesignation);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CustTypeID", _nCustTypeID);
                cmd.Parameters.AddWithValue("MarketGroupID", _nMarketGroupID);
                cmd.Parameters.AddWithValue("GeoLocationID", _nGeoLocationID);
                cmd.Parameters.AddWithValue("EmailAddress", _sEmailAddress);
                cmd.Parameters.AddWithValue("EnrollmentDate", _dEnrollmentDate);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("CreateDate", _oTELLib.ServerDateTime());
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);

                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("ApprovedUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("TaxNumber", _sTaxNumber);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddTempCustomerForWeb()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_CustomerTemp (CustomerID, WarehouseID, ParentCustomerID, CustomerShortName, NewCustomerCode, CustomerName, CustomerAddress, CustomerTelephone, CustomerFax, CellPhoneNumber, ContactPerson, ContactDesignation, IsActive, CustTypeID, MarketGroupID, GeoLocationID, EmailAddress, EnrollmentDate, Terminal, CreateDate, CreateUserID, UpdateDate, UpdateUserID, ApprovedDate, ApprovedUserID, Status,TaxNumber) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ParentCustomerID", _nParentCustomerID);
                cmd.Parameters.AddWithValue("CustomerShortName", _sCustomerShortName);
                cmd.Parameters.AddWithValue("NewCustomerCode", null);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("CustomerAddress", _sCustomerAddress);
                if (_sCustomerTelephone != null)
                {
                    cmd.Parameters.AddWithValue("CustomerTelephone", _sCustomerTelephone);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CustomerTelephone", null);
                }
                if (_sCustomerFax != null)
                {
                    cmd.Parameters.AddWithValue("CustomerFax", _sCustomerFax);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CustomerFax", null);
                }

                cmd.Parameters.AddWithValue("CellPhoneNumber", _sCellPhoneNo);
                cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                cmd.Parameters.AddWithValue("ContactDesignation", _sContactDesignation);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CustTypeID", _nCustTypeID);
                cmd.Parameters.AddWithValue("MarketGroupID", _nMarketGroupID);
                cmd.Parameters.AddWithValue("GeoLocationID", _nGeoLocationID);
                cmd.Parameters.AddWithValue("EmailAddress", _sEmailAddress);
                cmd.Parameters.AddWithValue("EnrollmentDate", _dEnrollmentDate);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("CreateDate", _dEntryDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nEntryUserID);

                if (_dUpdateDate != null)
                {
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateDate", DBNull.Value);
                }
                if (_nUpdateUserID != null)
                {
                    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateUserID", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("ApprovedDate", null);
                cmd.Parameters.AddWithValue("ApprovedUserID", null);

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("TaxNumber", _sTaxNumber);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditTempCustomer()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CustomerTemp SET ParentCustomerID = ?, CustomerShortName = ?, NewCustomerCode = ?, CustomerName = ?, CustomerAddress = ?, CustomerTelephone = ?, CustomerFax = ?, CellPhoneNumber = ?, ContactPerson = ?, ContactDesignation = ?, IsActive = ?, CustTypeID = ?, MarketGroupID = ?, GeoLocationID = ?, EmailAddress = ?, EnrollmentDate = ?, Terminal = ?, UpdateDate = ?, UpdateUserID = ?, Status = ?, TaxNumber = ? WHERE CustomerID = ? and WarehouseID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("ParentCustomerID", _nParentCustomerID);
                cmd.Parameters.AddWithValue("CustomerShortName", _sCustomerShortName);
                cmd.Parameters.AddWithValue("NewCustomerCode", null);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("CustomerAddress", _sCustomerAddress);
                cmd.Parameters.AddWithValue("CustomerTelephone", _sCustomerTelephone);
                cmd.Parameters.AddWithValue("CustomerFax", _sCustomerFax);
                cmd.Parameters.AddWithValue("CellPhoneNumber", _sCellPhoneNo);
                cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                cmd.Parameters.AddWithValue("ContactDesignation", _sContactDesignation);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CustTypeID", _nCustTypeID);
                cmd.Parameters.AddWithValue("MarketGroupID", _nMarketGroupID);
                cmd.Parameters.AddWithValue("GeoLocationID", _nGeoLocationID);
                cmd.Parameters.AddWithValue("EmailAddress", _sEmailAddress);
                cmd.Parameters.AddWithValue("EnrollmentDate", _dEnrollmentDate);
                cmd.Parameters.AddWithValue("Terminal", _nTerminal);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("TaxNumber", _sTaxNumber);

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateTempCustomerStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CustomerTemp SET NewCustomerCode = ?, Status = ?, ApprovedUserID = ?, ApprovedDate = ? WHERE CustomerID = ? and WarehouseID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;




                cmd.Parameters.AddWithValue("NewCustomerCode", _sCustomerCode);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ApprovedUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("ApprovedDate", DateTime.Now.Date);

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateTempCustomerStatusWEB()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CustomerTemp SET NewCustomerCode = ?, Status = ?, ApprovedUserID = ?, ApprovedDate = ? WHERE CustomerID = ? and WarehouseID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;




                cmd.Parameters.AddWithValue("NewCustomerCode", _sCustomerCode);


                cmd.Parameters.AddWithValue("Status", _nStatus);

                if (_nApprovedUserID != null)
                {
                    cmd.Parameters.AddWithValue("ApprovedUserID", _nApprovedUserID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ApprovedUserID", -1);
                }
                if (_dApprovedDate != null)
                {
                    cmd.Parameters.AddWithValue("ApprovedDate", _dApprovedDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ApprovedDate", DateTime.Now.Date);
                }

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteTempCustomer()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_CustomerTemp WHERE [CustomerID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        public void DeleteTempCustomerRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_CustomerTemp WHERE [CustomerID]=? and [WarehouseID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("CustomerID", _nWarehouseID);
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
                sSql = "DELETE FROM t_Customer WHERE [CustomerID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
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
                sSql = "Update  t_Customer set ParentCustomerID=?,CustomerCode=?,CustomerShortName = ?,TaxNumber = ?,CustomerName=?,CustomerAddress=?, " +
                       "CustomerTelephone=?,CustomerFax=?,CellPhoneNumber=?,ContactPerson=?,ContactDesignation=?,IsActive=?,CustTypeID=?, " +
                       "MarketGroupID=?,GeoLocationID=?,EmailAddress=?,EnrollmentDate=?,UploadStatus=?,UploadDate=?,DownloadDate=?,RowStatus=?, " +
                       "Terminal=?,UpdateDate=?,UpdateUserID=? where CustomerID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                if (_nParentCustomerID != 0)
                {
                    cmd.Parameters.AddWithValue("ParentCustomerID", _nParentCustomerID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ParentCustomerID", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("CustomerCode", _sCustomerCode);
                cmd.Parameters.AddWithValue("CustomerShortName", _sCustomerShortName);
                cmd.Parameters.AddWithValue("TaxNumber", _sTaxNumber);
                cmd.Parameters.AddWithValue("CustomerName", _sCustomerName);
                cmd.Parameters.AddWithValue("CustomerAddress", _sCustomerAddress);
                cmd.Parameters.AddWithValue("CustomerTelephone", _sCustomerTelephone);
                cmd.Parameters.AddWithValue("CustomerFax ", _sCustomerFax);
                cmd.Parameters.AddWithValue("CellPhoneNumber", _sCellPhoneNo);
                cmd.Parameters.AddWithValue("ContactPerson", _sContactPerson);
                cmd.Parameters.AddWithValue("ContactDesignation", _sContactDesignation);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CustTypeID", _nCustTypeID);
                cmd.Parameters.AddWithValue("MarketGroupID", _nMarketGroupID);
                cmd.Parameters.AddWithValue("GeoLocationID", _nGeoLocationID);
                cmd.Parameters.AddWithValue("EmailAddress", _sEmailAddress);
                if (_dEnrollmentDate != null)
                {
                    cmd.Parameters.AddWithValue("EnrollmentDate", _dEnrollmentDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("EnrollmentDate", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("UploadStatus", DBNull.Value);
                cmd.Parameters.AddWithValue("UploadDate", DBNull.Value);
                cmd.Parameters.AddWithValue("DownloadDate", DBNull.Value);
                cmd.Parameters.AddWithValue("RowStatus", DBNull.Value);
                cmd.Parameters.AddWithValue("Terminal", DBNull.Value);

                //cmd.Parameters.AddWithValue("EntryDate", DBNull.Value);
                //cmd.Parameters.AddWithValue("EntryUserID", DBNull.Value);

                //if (_dUpdateDate == null)
                //{
                //    cmd.Parameters.AddWithValue("UpdateDate", DBNull.Value);
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                //}
                //if (_nUpdateUserID == null)
                //{
                //    cmd.Parameters.AddWithValue("UpdateUserID", DBNull.Value);
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                //}
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void InsertCustomerVerificationInfo()
        {
            int nID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Select Max([ID]) From t_CustomerVerificationInfo";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nID = 1;
                }
                else
                {
                    nID = Convert.ToInt32(maxID) + 1;
                }
                _nVarificationID = nID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = " Insert Into t_CustomerVerificationInfo (ID,CustomerID,NatureofBusiness,Type,CompanyType,NoOfEmployee,ExpectedSales,CompanyCategory, " +
                       " VerifiedThrough,VerifiedBy,Remarks,VerifiedDate,CreateUserID,CreateDate,UpdateUserID,UpdateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";


                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nVarificationID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("NatureofBusiness", _nNatureofBusiness);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("CompanyType", _nCompanyType);
                cmd.Parameters.AddWithValue("NoOfEmployee", _nNoOfEmployee);
                cmd.Parameters.AddWithValue("ExpectedSales", _ExpectedSales);
                cmd.Parameters.AddWithValue("CompanyCategory ", _nCompanyCategory);
                cmd.Parameters.AddWithValue("VerifiedThrough", _nVerifiedThrough);
                cmd.Parameters.AddWithValue("VerifiedBy", _sVerifiedBy);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("VerifiedDate", _dtVerifiedDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nEntryUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dEntryDate);
                cmd.Parameters.AddWithValue("UpdateUserID", DBNull.Value);
                cmd.Parameters.AddWithValue("UpdateDate", DBNull.Value);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        /*********Uttam**************/
        public bool IsExitAccount(int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "";
            sSql = "Select CustomerID FROM t_CustomerAccount where CustomerID='" + nCustomerID + "'";
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
            if (nCount != 0) return true;
            else return false;
        }
        /******Uttam************/
        public void CreateAccount(int nCustomerID)
        {
            //int nCustomerID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Insert into t_CustomerAccount(CustomerID,CurrentBalance)values(?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
                cmd.Parameters.AddWithValue("CurrentBalance", 0);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void refresh()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM v_CustomerDetails where CustomerID =?";
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nCustomerID = (int)reader["CustomerID"];
                    _sCustomerCode = (string)reader["CustomerCode"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _sCellPhoneNo = (string)reader["CellPhoneNo"];
                    _sCustomerAddress = (string)reader["CustomerAddress"];
                    _sCustomerTelephone = (string)reader["CustomerTelephone"];
                    if (reader["ParentCustomerID"] != DBNull.Value)
                        _nParentCustomerID = (int)reader["ParentCustomerID"];
                    else _nParentCustomerID = 0;
                    _nCustTypeID = (int)reader["CustomerTypeID"];
                    _nChannelID = (int)reader["ChannelID"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetParentCustomer(int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = " Select CustomerID,CustomerCode,CustomerName From t_Customer where CustomerID in ( " +
                                  " Select ParentCustomerID From t_Customer where CustomerID = ?)";
                cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nParentCustomerID = (int)reader["CustomerID"];
                    _sParentCustomerCode = (string)reader["CustomerCode"];
                    _sParentCustomerName = (string)reader["CustomerName"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetCustomerTypeByID(int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * From t_Customer where CustomerID=?";
                cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nCustTypeID = (int)reader["CustTypeID"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForSalesOrder(string sCustomerCode, string sCustomerName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM v_CustomerDetails where CustomerID ='" + _nCustomerID + "'";
            if (sCustomerCode != "" && sCustomerCode != null)
            {
                sSql = sSql + "and CustomerCode = '" + sCustomerCode + "'";
            }
            if (sCustomerName != "" && sCustomerName != null)
            {
                sCustomerName = "%" + sCustomerName + "%";
                sSql = sSql + "and CustomerName like '" + sCustomerName + "'";
            }
            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sCustomerCode = (string)reader["CustomerCode"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _sCustomerAddress = (string)reader["CustomerAddress"];
                    if (reader["ParentCustomerID"] != DBNull.Value)
                        _nParentCustomerID = (int)reader["ParentCustomerID"];
                    else _nParentCustomerID = 0;

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddCreditLimit()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "INSERT INTO t_CustomerCreditlimit VALUES(?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CreditlimitID", _nCreditlimitID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("MinCreditlimit", _nMinCreditLimit);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("Expirydate", _dExpiryDate);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("MaxCreditLimit", _nMaxCreditLimit);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetCustomerID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM v_CustomerDetails where CustomerCode =?";
                cmd.Parameters.AddWithValue("CustomerCode", _sCustomerCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nCustomerID = int.Parse(reader["CustomerID"].ToString());
                    _sCustomerName = (string)(reader["CustomerName"]);
                    _sCustomerAddress = (string)(reader["CustomerAddress"]);
                    //  _sTerritory = (string)(reader["Territory"]);


                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0) _bFlag = false;
            else _bFlag = true;
        }
        public void GetWebStoreCustomer(string sWebStoreCustomer)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd.CommandText = "Select CustomerID,CustomerName, ChannelID, PriceOptionID,b.CustTypeID from t_Customer a, t_CustomerType b, " +
                            "t_CustomerTypeWisePriceSetting c where a.CustTypeID=b.CustTypeID and c.CustTypeID=a.CustTypeID and CustomerCode=?";
            cmd.Parameters.AddWithValue("CustomerCode", sWebStoreCustomer);

            try
            {
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _sCustomerName = (string)reader["CustomerName"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _nChannelID = (int)reader["ChannelID"];
                    _nPriceOptionID = (int)reader["PriceOptionID"];
                    _nCustTypeID = (int)reader["CustTypeID"];

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetCustomerCreditLimit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select * from t_CustomerCreditLimit where ? between EffectiveDate  and ExpiryDate and customerid = ? ";
                cmd.Parameters.AddWithValue("date", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nMinCreditLimit = Convert.ToDouble(reader["MinCreditlimit"].ToString());

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
            string sSql = "Select a.*,isnull(IsCustomerAccount,0) IsCustomerAccount From  " +
                        "(  " +
                        "Select * From v_CustomerDetails  " +
                        ") a  " +
                        "Left Outer Join  " +
                        "(  " +
                        "Select CustomerID,1 as IsCustomerAccount From t_CustomerAccount  " +
                        ") b on a.CustomerID = b.CustomerID  " +
                        "where CustomerCode = ?";

            cmd.Parameters.AddWithValue("CustomerCode", _sCustomerCode);

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCustomerID = int.Parse(reader["CustomerID"].ToString());
                    _nIsActive = int.Parse(reader["IsActive"].ToString());
                    _sCustomerCode = (string)reader["CustomerCode"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _sCustomerAddress = (string)reader["CustomerAddress"];
                    if (reader["CustomerTelephone"] != DBNull.Value)
                        _sCustomerTelephone = (string)reader["CustomerTelephone"];
                    if (reader["CellPhoneNo"] != DBNull.Value)
                        _sCellPhoneNo = (string)reader["CellPhoneNo"];
                    _nChannelID = int.Parse(reader["ChannelID"].ToString());
                    _nCustTypeID = int.Parse(reader["CustomerTypeID"].ToString());
                    if (reader["ThanaID"] != DBNull.Value)
                        _nThanaID = int.Parse(reader["ThanaID"].ToString());
                    //_sThanaName=
                    else _nThanaID = -1;
                    if (reader["ContractPerson"] != DBNull.Value)
                    {
                        _sContactPerson = (string)reader["ContractPerson"];
                    }

                    _nIsCustomerAccount = int.Parse(reader["IsCustomerAccount"].ToString());

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByID(int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM v_CustomerDetails where  CustomerID = " + nCustomerID + "";


            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCustomerID = int.Parse(reader["CustomerID"].ToString());
                    _sCustomerCode = (string)reader["CustomerCode"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _sCustomerAddress = (string)reader["CustomerAddress"];
                    _nChannelID = int.Parse(reader["ChannelID"].ToString());
                    _nCustTypeID = int.Parse(reader["CustomerTypeID"].ToString());

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByCodeForCustType()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_Customer where  CustomerCode = ?";
            cmd.Parameters.AddWithValue("CustomerCode", _sCustomerCode);

            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCustTypeID = int.Parse(reader["CustTypeID"].ToString());

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckCustPermission(int nUserID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "select a.* from v_CustomerDetails a,t_UserPermissionData b "
                          + "  where b.DataID=a.CustomerID and b.UserID= '" + nUserID + "' and DataType='Customer' and a.CustomerID='" + _nCustomerID + "'";

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
            if (nCount != 0) return true;
            else return false;
        }
        public bool CheckCustomerType()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select * From t_Customer where CustTypeID = ? and CustomerID = ?";
            cmd.Parameters.AddWithValue("CustTypeID", _nCustTypeID);
            cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
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
            if (nCount != 0) return true;
            else return false;
        }

        public bool CheckDMSCustomer()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select * From t_DMSOutlet where CustomerID = ?";

            cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
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
            if (nCount != 0) return true;
            else return false;
        }



        public void GetCustomerForDCS(int nUserID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select a.* from v_CustomerDetails a,t_UserPermissionData b "
                           + "  where b.DataID=a.CustomerID and b.UserID= '" + nUserID + "' and DataType='Customer' and CustomerTypeID='" + (int)Dictionary.CustomerType.OwnShowroom + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    _nCustomerID = (int)reader["CustomerID"];
                    _sCustomerCode = reader["CustomerCode"].ToString();
                    _sCustomerName = reader["CustomerName"].ToString();

                }

                reader.Close();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetCustomerForFootFall(int nUserID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select CustomerID, CustomerName,Left(CustomerName,3) as TDCode from v_CustomerDetails a, " +
                            "t_UserPermissionData b, t_Warehouse W where b.DataID=a.CustomerID and w.shortCode=Left(CustomerName,3) " +
                            "and b.UserID= ? and DataType='Customer' and CustomerTypeID=? AND CustomerID<>7";

            cmd.Parameters.AddWithValue("b.UserID", nUserID);
            cmd.Parameters.AddWithValue("CustomerTypeID", (int)Dictionary.CustomerType.OwnShowroom);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    _nCustomerID = (int)reader["CustomerID"];
                    _sCustomerName = reader["CustomerName"].ToString();
                    _sCustomerCode = reader["TDCode"].ToString();

                }

                reader.Close();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetCustomerAddressByID(int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "select CustomerID,CustomerAddress, ChannelID from v_customerdetails Where CustomerID=?";
                cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nCustomerID = int.Parse(reader["CustomerID"].ToString());
                    _sCustomerAddress = (string)(reader["CustomerAddress"]);
                    _nChannelID = int.Parse(reader["ChannelID"].ToString());

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetCustomerDetailByID(int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * From v_CustomerDetails where CustomerID = ?";

                cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nCustomerID = int.Parse(reader["CustomerID"].ToString());
                    _sCustomerCode = (string)reader["CustomerCode"];
                    _sCustomerName = (string)reader["CustomerName"];
                    if (reader["ParentCustomerID"] != DBNull.Value)
                    {
                        _nParentCustomerID = int.Parse(reader["ParentCustomerID"].ToString());
                    }
                    else
                    {
                        _nParentCustomerID = -1;
                    }

                    if (reader["ParentCustomerCode"] != DBNull.Value)
                    {
                        _sParentCustomerCode = (string)reader["ParentCustomerCode"];
                    }
                    else
                    {
                        _sParentCustomerCode = "";
                    }
                    if (reader["ParentCustomerName"] != DBNull.Value)
                    {
                        _sParentCustomerName = (string)reader["ParentCustomerName"];
                    }
                    else
                    {
                        _sParentCustomerName = "";
                    }

                    _sCustomerAddress = (string)reader["CustomerAddress"];

                    if (reader["CustomerTelephone"] != DBNull.Value)
                    {
                        _sCustomerTelephone = (string)reader["CustomerTelephone"];
                    }
                    else
                    {
                        _sCustomerTelephone = "";
                    }

                    if (reader["CustomerFax"] != DBNull.Value)
                    {
                        _sCustomerFax = (string)reader["CustomerFax"];
                    }
                    else
                    {
                        _sCustomerFax = "";
                    }
                    _sContactPerson = (string)reader["ContractPerson"];
                    _sContactDesignation = (string)reader["ContactDesignation"];
                    if (reader["CellPhoneNo"] != DBNull.Value)
                    {
                        _sCellPhoneNo = (string)reader["CellPhoneNo"];
                    }
                    else
                    {
                        _sCellPhoneNo = "";
                    }

                    _nChannelID = int.Parse(reader["ChannelID"].ToString());
                    _sChannelDescription = (string)reader["ChannelDescription"];
                    _nCustTypeID = int.Parse(reader["CustomerTypeID"].ToString());
                    _sCustomerTypeName = (string)reader["CustomerTypeName"];
                    _nAreaID = int.Parse(reader["AreaID"].ToString());
                    _sAreaName = (string)reader["AreaName"];
                    _nTerritoryID = int.Parse(reader["TerritoryID"].ToString());
                    _sTerritoryName = (string)reader["TerritoryName"];
                    _nDistrictID = int.Parse(reader["DistrictID"].ToString());
                    _sDistrictName = (string)reader["DistrictName"];
                    _nThanaID = int.Parse(reader["ThanaID"].ToString());
                    _sThanaName = (string)reader["ThanaName"];

                    try
                    {
                        _dEntryDate = Convert.ToDateTime(reader["EntryDate"].ToString());
                    }
                    catch
                    {
                        _dEntryDate = DateTime.Now;
                    }

                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        /// <summary>
        /// Get Max B2B Customer Code
        /// Shuvo
        /// Date:1 7-Jul-2016
        /// </summary>

        public void GetMaxCustomerCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                if (Utility.CompanyInfo == "TEL")
                {
                    cmd.CommandText = "Select '4500'+CONVERT(varchar(10), CustomerCode) as CustomerCode From  " +
                                      "(Select max(CustomerID)+1 as CustomerCode From t_Customer ) x";
                }
                else if (Utility.CompanyInfo == "TML")
                {
                    cmd.CommandText = " Select CONVERT(varchar(10), CustomerCode) as CustomerCode  " +
                                      " From (Select max(CustomerCode)+1 as CustomerCode     " +
                                      " From t_Customer where CusttypeID=202 and   " +
                                      " Customercode like '4500%') x";
                }

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sCustomerCode = (string)reader["CustomerCode"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateConsumerDetail()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update  t_ConsumerDetail set ConsumerCode=?, ConsumerName=?, Address = ?, PhoneNo=?, Email=?, AlternativeCellNo=?, LastUpdateDate=?, UpdateUserID=?, IsVerified = ? where ConsumerID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConsumerCode", _sCustomerCode);
                cmd.Parameters.AddWithValue("ConsumerName", _sCustomerName);
                cmd.Parameters.AddWithValue("Address", _sCustomerAddress);
                cmd.Parameters.AddWithValue("PhoneNo", _sCustomerTelephone);
                cmd.Parameters.AddWithValue("Email", _sEmailAddress);
                cmd.Parameters.AddWithValue("AlternativeCellNo ", _sAlternativeCellNo);
                cmd.Parameters.AddWithValue("LastUpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("IsVerified", _nIsVerified);

                cmd.Parameters.AddWithValue("ConsumerID", _nCustomerID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }


        //public void InsertCustomerBalanceData(int oCustomerID, int nWarehouseID)
        //{
        //    DBController.Instance.BeginNewTransaction();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";


        //    try
        //    {
        //        cmd.Dispose();
        //        cmd = DBController.Instance.GetCommand();

        //        sSql = "insert into t_DataTransfer values ('t_CustomerAccount'," + oCustomerID + "," + nWarehouseID + ",1,1,0,GETDATE(),NULL,NULL)";
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();

        //        DBController.Instance.CommitTransaction();
        //    }
        //    catch (Exception ex)
        //    {
        //        DBController.Instance.RollbackTransaction();
        //        throw (ex);
        //    }
        //}

        public bool CheckDistributionCustomer(int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "Select a.CustomerID,isnull(c.WarehouseID,-1) WarehouseID From t_Customer a  " +
                        "Inner Join v_SBU b on a.CustTypeID = b.CustTypeID  " +
                        "Left Outer Join t_Showroom c on a.ParentCustomerID = c.CustomerID  " +
                        "where SBUID = 5 and a.CustomerID = ?";

            cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
            try
            {
                cmd.CommandText = sSql;

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nWarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) return true;
            else return false;
        }
        public void CustomerBalanceDataCreation(int nCustomerID, int nWarehouseID, string sTableName, int nDataID)
        {
            #region Insert Customer Account Data
            DataTran _oDataTran = new DataTran();
            if (CheckDistributionCustomer(nCustomerID))
            {
                if (sTableName == "t_CustomerAccount")
                {
                    foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SuperOutlet)))
                    {
                        if (GetEnum == nWarehouseID)
                        {
                            DataTran oDataTran = new DataTran();
                            oDataTran.TableName = sTableName;
                            oDataTran.DataID = Convert.ToInt32(nDataID);
                            oDataTran.WarehouseID = _nWarehouseID;
                            oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                            oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                            oDataTran.BatchNo = 0;
                            if (oDataTran.CheckDataByWHID() == false)
                            {
                                oDataTran.AddForTDPOS();
                            }

                        }
                        else
                        {


                            DataTran oDataTran = new DataTran();
                            oDataTran.TableName = sTableName;
                            oDataTran.DataID = Convert.ToInt32(nDataID);
                            oDataTran.WarehouseID = GetEnum;
                            oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                            oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                            oDataTran.BatchNo = 0;
                            if (oDataTran.CheckDataByWHID() == false)
                            {
                                oDataTran.AddForTDPOS();
                            }
                        }

                    }
                }
                else
                {
                    foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SuperOutlet)))
                    {
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = sTableName;
                        oDataTran.DataID = Convert.ToInt32(nDataID);
                        oDataTran.WarehouseID = GetEnum;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckData() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                    }
                }
            }
            #endregion
        }
    }

    public class Customers : CollectionBase
    {
        public Customer this[int i]
        {
            get { return (Customer)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Customer oCustomer)
        {
            InnerList.Add(oCustomer);
        }

        public int GetIndex(int nCustomerID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].CustomerID == nCustomerID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void CustomerCreditLimit(string sCustomerCode)
        {
            int ncreditlimitID;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            try
            {
                string sSql2 = "select Max(creditlimitID)+1  as MaxLimitID from t_CustomerCreditlimit";
                cmd.CommandText = sSql2;
                ncreditlimitID = Convert.ToInt16(cmd.ExecuteScalar().ToString());
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                string sSql = "select * from t_Customer where CustomerCode='" + sCustomerCode + "'"; ;
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Customer oCustomer = new Customer();
                    oCustomer.CustomerID = Convert.ToInt16(reader["CustomerID"].ToString());
                    oCustomer.CustomerAddress = reader["CustomerAddress"].ToString();
                    oCustomer.CustomerName = reader["CustomerName"].ToString();


                    InnerList.Add(oCustomer);
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

        public Customers GetChannelName()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select ChannelID, ChannelDescription from t_Channel";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer oCustomer = new Customer();
                    oCustomer.ChannelID = int.Parse(reader["ChannelID"].ToString());
                    oCustomer.ChannelDescription = (string)reader["ChannelDescription"];
                    InnerList.Add(oCustomer);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return this;
        }

        /// <summary>
        /// GetCustomerVerifiedData
        /// Shuvo
        /// Date-29-Feb-2016
        /// </summary>
        public Customers GetCustomerVerifiedData(int nPerentID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select DataID,Name From dbo.t_CustomerVerifiedData where PerentID=" + nPerentID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer oCustomer = new Customer();
                    oCustomer.DataID = int.Parse(reader["DataID"].ToString());
                    oCustomer.Name = (string)reader["Name"];
                    InnerList.Add(oCustomer);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return this;
        }


        public void refresh(string sCustomerCode, string sCustomerName)//This function is use for customer control both HO and Outlet. Thanks for not edit - Hakim
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            if (sCustomerCode != "")
            {
                sSql = " Select CustomerID,CustomerCode,CustomerName,isnull(IsActive,0) IsActive,isnull(CustomerAddress,'') CustomerAddress,  " +
                    "isnull(CustomerTelephone,'') CustomerTelephone,isnull(CustomerFax,'') CustomerFax,isnull(CellPhoneNo,'') CellPhoneNo, " +
                    "isnull(ContractPerson,'') ContractPerson,isnull(ContactDesignation,'') ContactDesignation, " +
                    "isnull(ChannelDescription,'') ChannelDescription,isnull(ChannelID,-1) ChannelID,isnull(AreaID,-1) AreaID, " +
                    "isnull(AreaName,'') AreaName,isnull(territoryName,'') territoryName,isnull(CustomerTypeID,-1) CustomerTypeID,isnull(CustomerTypeName,'') CustomerTypeName, " +
                    "isnull(TerritoryID,-1) TerritoryID,isnull(DistrictID,-1) DistrictID,isnull(ThanaID,-1) ThanaID " +
                    "From v_CustomerDetails where CustomerCode= '" + sCustomerCode + "'";
            }
            else if (sCustomerName != "")
            {
                sSql = " Select CustomerID,CustomerCode,CustomerName,isnull(IsActive,0) IsActive,isnull(CustomerAddress,'') CustomerAddress,  " +
                    "isnull(CustomerTelephone,'') CustomerTelephone,isnull(CustomerFax,'') CustomerFax,isnull(CellPhoneNo,'') CellPhoneNo, " +
                    "isnull(ContractPerson,'') ContractPerson,isnull(ContactDesignation,'') ContactDesignation, " +
                    "isnull(ChannelDescription,'') ChannelDescription,isnull(ChannelID,-1) ChannelID,isnull(AreaID,-1) AreaID, " +
                    "isnull(AreaName,'') AreaName,isnull(territoryName,'') territoryName,isnull(CustomerTypeID,-1) CustomerTypeID,isnull(CustomerTypeName,'') CustomerTypeName,  " +
                    "isnull(TerritoryID,-1) TerritoryID,isnull(DistrictID,-1) DistrictID,isnull(ThanaID,-1) ThanaID " +
                    "From v_CustomerDetails where CustomerName like '%" + sCustomerName + "%'";
            }
            else
            {
                sSql = " Select CustomerID,CustomerCode,CustomerName,isnull(IsActive,0) IsActive,isnull(CustomerAddress,'') CustomerAddress,  " +
                    "isnull(CustomerTelephone,'') CustomerTelephone,isnull(CustomerFax,'') CustomerFax,isnull(CellPhoneNo,'') CellPhoneNo, " +
                    "isnull(ContractPerson,'') ContractPerson,isnull(ContactDesignation,'') ContactDesignation, " +
                    "isnull(ChannelDescription,'') ChannelDescription,isnull(ChannelID,-1) ChannelID,isnull(AreaID,-1) AreaID, " +
                    "isnull(AreaName,'') AreaName,isnull(territoryName,'') territoryName,isnull(CustomerTypeID,-1) CustomerTypeID,isnull(CustomerTypeName,'') CustomerTypeName,  " +
                    "isnull(TerritoryID,-1) TerritoryID,isnull(DistrictID,-1) DistrictID,isnull(ThanaID,-1) ThanaID " +
                    "From v_CustomerDetails ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Customer oCustomer = new Customer();
                    oCustomer.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oCustomer.CustomerCode = reader["CustomerCode"].ToString();
                    oCustomer.IsActive = int.Parse(reader["IsActive"].ToString());
                    oCustomer.CustomerName = reader["CustomerName"].ToString();
                    oCustomer.CustomerAddress = reader["CustomerAddress"].ToString();
                    oCustomer.CustomerTelephone = reader["CustomerTelephone"].ToString();
                    oCustomer.CustomerFax = reader["CustomerFax"].ToString();
                    oCustomer.CellPhoneNo = reader["CellPhoneNo"].ToString();
                    oCustomer.ContactPerson = reader["ContractPerson"].ToString();
                    oCustomer.ContactDesignation = reader["ContactDesignation"].ToString();
                    oCustomer.ChannelDescription = reader["ChannelDescription"].ToString();
                    oCustomer.ChannelID = int.Parse(reader["ChannelID"].ToString());
                    oCustomer.AreaID = int.Parse(reader["AreaID"].ToString());
                    oCustomer.AreaName = reader["AreaName"].ToString();
                    oCustomer.Territory = reader["territoryName"].ToString();
                    oCustomer.CustTypeID = int.Parse(reader["CustomerTypeID"].ToString());
                    oCustomer.CustomerTypeName = reader["CustomerTypeName"].ToString();
                    oCustomer.MarketGroupID = int.Parse(reader["TerritoryID"].ToString());
                    oCustomer.DistrictID = int.Parse(reader["DistrictID"].ToString());
                    oCustomer.GeoLocationID = int.Parse(reader["ThanaID"].ToString());
                    oCustomer.ThanaID = int.Parse(reader["ThanaID"].ToString());

                    InnerList.Add(oCustomer);
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


        public void GetCustomerByCustType(string sCustomerCode, string sCustomerName, string sCusttype)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "Select a.*,isnull(IsCustomerAccount,0) IsCustomerAccount From  " +
                "(  " +
                "Select CustomerID,CustomerCode,CustomerName,isnull(IsActive,0) IsActive,isnull(CustomerAddress,'') CustomerAddress,    " +
                "isnull(CustomerTelephone,'') CustomerTelephone,isnull(CustomerFax,'') CustomerFax,isnull(CellPhoneNo,'') CellPhoneNo,   " +
                "isnull(ContractPerson,'') ContractPerson,isnull(ContactDesignation,'') ContactDesignation,   " +
                "isnull(ChannelDescription,'') ChannelDescription,isnull(ChannelID,-1) ChannelID,isnull(AreaID,-1) AreaID,   " +
                "isnull(AreaName,'') AreaName,isnull(territoryName,'') territoryName,isnull(CustomerTypeID,-1) CustomerTypeID,isnull(CustomerTypeName,'') CustomerTypeName,   " +
                "isnull(TerritoryID,-1) TerritoryID,isnull(DistrictID,-1) DistrictID,isnull(ThanaID,-1) ThanaID   " +
                "From v_CustomerDetails   " +
                ") a  " +
                "Left Outer Join   " +
                "(  " +
                "Select CustomerID,1 as IsCustomerAccount From t_CustomerAccount   " +
                ") b on a.CustomerID=b.CustomerID  " +
                "where 1=1";


            if (sCustomerCode != "")
            {
                sSql = sSql + " AND CustomerCode like '%" + sCustomerCode + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND CustomerName like '%" + sCustomerName + "%'";
            }
            if (sCusttype != "-1")
            {
                sSql = sSql + " AND CustomerTypeID in (" + sCusttype + ")";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Customer oCustomer = new Customer();
                    oCustomer.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oCustomer.CustomerCode = reader["CustomerCode"].ToString();
                    oCustomer.IsActive = int.Parse(reader["IsActive"].ToString());
                    oCustomer.CustomerName = reader["CustomerName"].ToString();
                    oCustomer.CustomerAddress = reader["CustomerAddress"].ToString();
                    oCustomer.CustomerTelephone = reader["CustomerTelephone"].ToString();
                    oCustomer.CustomerFax = reader["CustomerFax"].ToString();
                    oCustomer.CellPhoneNo = reader["CellPhoneNo"].ToString();
                    oCustomer.ContactPerson = reader["ContractPerson"].ToString();
                    oCustomer.ContactDesignation = reader["ContactDesignation"].ToString();
                    oCustomer.ChannelDescription = reader["ChannelDescription"].ToString();
                    oCustomer.ChannelID = int.Parse(reader["ChannelID"].ToString());
                    oCustomer.AreaID = int.Parse(reader["AreaID"].ToString());
                    oCustomer.AreaName = reader["AreaName"].ToString();
                    oCustomer.Territory = reader["territoryName"].ToString();
                    oCustomer.CustTypeID = int.Parse(reader["CustomerTypeID"].ToString());
                    oCustomer.CustomerTypeName = reader["CustomerTypeName"].ToString();
                    oCustomer.MarketGroupID = int.Parse(reader["TerritoryID"].ToString());
                    oCustomer.DistrictID = int.Parse(reader["DistrictID"].ToString());
                    oCustomer.GeoLocationID = int.Parse(reader["ThanaID"].ToString());
                    oCustomer.ThanaID = int.Parse(reader["ThanaID"].ToString());
                    oCustomer.IsCustomerAccount = int.Parse(reader["IsCustomerAccount"].ToString());

                    InnerList.Add(oCustomer);
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
        public void Refresh(string sCustomerCode, string sCustomerName, int nChannelID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            {
                sSql = "Select * From v_CustomerDetails where 1=1 ";
            }
            if (sCustomerCode != "")
            {
                sSql = sSql + " AND CustomerCode like '%" + sCustomerCode + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND CustomerName like '%" + sCustomerName + "%'";
            }
            if (nChannelID != -1)
            {
                sSql = sSql + " AND ChannelID=" + nChannelID + "";
            }
            sSql = sSql + " Order by CustomerID DESC";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Customer oCustomer = new Customer();
                    oCustomer.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oCustomer.CustomerCode = reader["CustomerCode"].ToString();
                    if (reader["CustomerShortName"] != DBNull.Value)
                        oCustomer.CustomerShortName = (string)reader["CustomerShortName"];
                    else oCustomer.CustomerShortName = "";
                    if (reader["TaxNumber"] != DBNull.Value)
                        oCustomer.TaxNumber = (string)reader["TaxNumber"];
                    else oCustomer.TaxNumber = "";
                    oCustomer.CustomerName = reader["CustomerName"].ToString();
                    oCustomer.CustomerAddress = reader["CustomerAddress"].ToString();
                    oCustomer.CustomerTelephone = reader["CustomerTelephone"].ToString();
                    oCustomer.CustomerFax = reader["CustomerFax"].ToString();
                    oCustomer.CellPhoneNo = reader["CellPhoneNo"].ToString();
                    oCustomer.ContactPerson = reader["ContractPerson"].ToString();
                    oCustomer.ContactDesignation = reader["ContactDesignation"].ToString();
                    oCustomer.ChannelDescription = reader["ChannelDescription"].ToString();
                    oCustomer.ChannelID = int.Parse(reader["ChannelID"].ToString());
                    oCustomer.AreaID = int.Parse(reader["AreaID"].ToString());
                    oCustomer.AreaName = reader["AreaName"].ToString();
                    //oCustomer.EmailAddress = reader["EmailAddress"].ToString();
                    oCustomer.Territory = reader["territoryName"].ToString();
                    oCustomer.CustTypeID = int.Parse(reader["CustomerTypeID"].ToString());
                    oCustomer.MarketGroupID = int.Parse(reader["TerritoryID"].ToString());
                    oCustomer.DistrictID = int.Parse(reader["DistrictID"].ToString());
                    oCustomer.GeoLocationID = int.Parse(reader["ThanaID"].ToString());
                    oCustomer.IsActive = (int)reader["IsActive"];

                    if (reader["ParentCustomerID"] != DBNull.Value)
                        oCustomer.ParentCustomerID = (int)reader["ParentCustomerID"];
                    else oCustomer.ParentCustomerID = -1;

                    InnerList.Add(oCustomer);
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

        public void GetCustomers(int nUserID, bool bIsShowroom)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select a.* from v_CustomerDetails a,t_UserPermissionData b "
                           + "  where b.DataID=a.CustomerID and b.UserID= '" + nUserID + "' and DataType='Customer'";
            if (bIsShowroom) sSql = sSql + " and CustomerTypeID='" + (int)Dictionary.CustomerType.OwnShowroom + "'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Customer oCustomer = new Customer();

                    oCustomer.CustomerID = (int)reader["CustomerID"];
                    oCustomer.CustomerCode = reader["CustomerCode"].ToString();
                    oCustomer.CustomerName = reader["CustomerName"].ToString();
                    InnerList.Add(oCustomer);
                }

                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetCustomersBLL(int nUserID)
        {
            Customer oCustomer;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select a.* from v_CustomerDetails a,t_UserPermissionData b "
                           + "  where b.DataID=a.CustomerID and b.UserID= '" + nUserID + "' and Isactive=1 ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                //oCustomer = new Customer();
                //oCustomer.CustomerID = -1;
                //oCustomer.CustomerName = "<Select Distributor>";
                //InnerList.Add(oCustomer);


                oCustomer = new Customer();
                oCustomer.CustomerID = -1;
                oCustomer.CustomerName = "ALL";
                InnerList.Add(oCustomer);

                while (reader.Read())
                {
                    oCustomer = new Customer();

                    oCustomer.CustomerID = (int)reader["CustomerID"];
                    oCustomer.CustomerCode = reader["CustomerCode"].ToString();
                    oCustomer.CustomerName = reader["CustomerName"].ToString();
                    InnerList.Add(oCustomer);
                }
                reader.Close();

                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public Customers GetCustomerInfoForSMSindenting(int nCustomerId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select * from t_Customer where CustomerID= ?";
                cmd.Parameters.AddWithValue("CustomerID", nCustomerId);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer oCustomer = new Customer();
                    oCustomer.CustomerID = (int)reader["CustomerID"];
                    oCustomer.CustomerCode = reader["CustomerCode"].ToString();
                    oCustomer.CustomerName = reader["CustomerName"].ToString();
                    oCustomer.CustomerAddress = reader["CustomerAddress"].ToString();
                    InnerList.Add(oCustomer);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return this;
        }

        public Customers GetParentCustomerNameForTMLSMDPstock()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select DISTINCT ParentCustomerName from dbo.v_CustomerDetails where ParentCustomerName !=?";
                cmd.Parameters.AddWithValue("ParentCustomerName", "");


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Customer oCustomer = new Customer();
                    oCustomer.CustomerName = reader["ParentCustomerName"].ToString();
                    InnerList.Add(oCustomer);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return this;
        }

        public Customers GetCustomerNameForTMLSMDPstock(string sParentCustomerName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "select * from dbo.v_CustomerDetails  where ParentCustomerName =? and CustomerName !=?";
                cmd.Parameters.AddWithValue("ParentCustomerName", sParentCustomerName);
                cmd.Parameters.AddWithValue("CustomerName", "");

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer oCustomer = new Customer();
                    oCustomer.CustomerName = (string)reader["CustomerName"];
                    oCustomer.CustomerCode = (string)reader["CustomerCode"];
                    InnerList.Add(oCustomer);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return this;
        }

        public void RefreshByPermission(int nUserID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select a.* from v_CustomerDetails a,t_UserPermissionData b "
                           + "  where b.DataID=a.CustomerID and b.UserID= '" + nUserID + "' and DataType='Customer'";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Customer oCustomer = new Customer();
                    oCustomer.CustomerID = (int)reader["CustomerID"];
                    oCustomer.CustomerCode = reader["CustomerCode"].ToString();
                    oCustomer.CustomerName = reader["CustomerName"].ToString();

                    InnerList.Add(oCustomer);
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

        public void RefreshPermissionForFootFall(int nUserID)
        {
            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (Utility.CompanyInfo == "TEL")
            {

                sSql = "select CustomerID, CustomerName,Left(CustomerName,3) as TDCode from v_CustomerDetails a, " +
                   "t_UserPermissionData b, t_Warehouse W where b.DataID=a.CustomerID and w.shortCode=Left(CustomerName,3) " +
                   "and b.UserID= ? and DataType='Customer' and CustomerTypeID=? AND CustomerID<>7";
            }

            if (Utility.CompanyInfo == "BLL")
            {

                sSql = " select CustomerID, CustomerName from v_CustomerDetails a," +
                 " t_UserPermissionData b where b.DataID=a.CustomerID " +
                  " and b.UserID= ? and DataType='Customer' and a.ChannelID= ? ";
            }


            cmd.Parameters.AddWithValue("b.UserID", nUserID);

            if (Utility.CompanyInfo == "TEL")
            {
                cmd.Parameters.AddWithValue("CustomerTypeID", (int)Dictionary.CustomerType.OwnShowroom);
            }
            if (Utility.CompanyInfo == "BLL")
            {
                cmd.Parameters.AddWithValue("ChannelID", (int)Dictionary.CustomerType.Lighting);
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Customer oCustomer = new Customer();
                    oCustomer.CustomerID = (int)reader["CustomerID"];
                    oCustomer.CustomerName = reader["CustomerName"].ToString();

                    InnerList.Add(oCustomer);
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
        public void GetTDOutlet()
        {
            Customer oCustomer;
            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (Utility.CompanyInfo == "TEL")
            {

                sSql = "Select CustomerID,CustomerCode,CustomerName, left(CustomerName,3)as ShortCode " +
                               "from t_Customer Where CustTypeID in (5,221) and CustomerID Not IN (2170,789,2171,22,1993,3204,2489,2080) AND ISActive=1 Order by CustomerName ASC";
            }

            if (Utility.CompanyInfo == "BLL")
            {

                sSql = "Select CustomerID,CustomerCode,CustomerName, left(CustomerName,3)as ShortCode " +
                                "from v_Customerdetails Where ChannelID=2 AND CustomerID Not IN (2170,789,2171) AND ISActive=1 Order by CustomerName ASC";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    oCustomer = new Customer();
                    oCustomer.CustomerID = (int)reader["CustomerID"];
                    oCustomer.CustomerCode = (string)reader["CustomerCode"];
                    oCustomer.CustomerName = (string)reader["CustomerName"];
                    oCustomer.ShortCode = (string)reader["ShortCode"];

                    InnerList.Add(oCustomer);
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
        public void GetTDOutletByProductID(int nProdID)
        {
            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            sSql = "select distinct a.CustomerID,left(CustomerName,3)Outlet from t_TDProductPortfolio a, t_customer b " +
                    "Where a.CustomerID=b.CustomerID and ProductID=" + nProdID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Customer oCustomer = new Customer();
                    oCustomer.CustomerID = (int)reader["CustomerID"];
                    oCustomer.CustomerCode = (string)reader["Outlet"];

                    InnerList.Add(oCustomer);
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
        public void GetTDOutletAll()
        {
            Customer oCustomer;
            string sSql = "";
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            sSql = "Select CustomerID,CustomerCode,CustomerName, left(CustomerName,3)as ShortCode " +
                "from t_Customer Where CustTypeID=5 AND CustomerID Not IN (2170,789,2171) AND ISActive=1 Order by CustomerName ASC";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    oCustomer = new Customer();
                    oCustomer.CustomerID = (int)reader["CustomerID"];
                    oCustomer.CustomerCode = (string)reader["CustomerCode"];
                    oCustomer.CustomerName = (string)reader["CustomerName"];
                    oCustomer.ShortCode = (string)reader["ShortCode"];

                    InnerList.Add(oCustomer);
                }

                reader.Close();

                oCustomer = new Customer();
                oCustomer.CustomerID = -1;
                oCustomer.CustomerName = "ALL";
                InnerList.Add(oCustomer);

                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetDistrict(int nCustomerID)
        {
            Customer oCustomer;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select DistrictID,DistrictName from v_CustomerDetails where CustomerID= '" + nCustomerID + "' ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    oCustomer = new Customer();
                    oCustomer.DistrictID = (int)reader["DistrictID"];
                    oCustomer.DistrictName = reader["DistrictName"].ToString();

                    InnerList.Add(oCustomer);
                }

                reader.Close();
                oCustomer = new Customer();
                oCustomer.DistrictID = -1;
                oCustomer.DistrictName = "ALL";
                InnerList.Add(oCustomer);
                InnerList.TrimToSize();


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetCustomersTerritoryWise(int nUserID, int nTerritoryID)
        {
            Customer oCustomer;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select a.* from v_CustomerDetails a,t_UserPermissionData b "
                           + "  where b.DataID=a.CustomerID and b.UserID= '" + nUserID + "' and TerritoryID='" + nTerritoryID + "' and Isactive=1 ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                //oCustomer = new Customer();
                //oCustomer.CustomerID = -1;
                //oCustomer.CustomerName = "<Select Distributor>";
                //InnerList.Add(oCustomer);


                oCustomer = new Customer();
                oCustomer.CustomerID = -1;
                oCustomer.CustomerName = "ALL";
                InnerList.Add(oCustomer);

                while (reader.Read())
                {
                    oCustomer = new Customer();

                    oCustomer.CustomerID = (int)reader["CustomerID"];
                    oCustomer.CustomerCode = reader["CustomerCode"].ToString();
                    oCustomer.CustomerName = reader["CustomerName"].ToString();
                    InnerList.Add(oCustomer);
                }
                reader.Close();

                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// BEIL Customer List
        /// Shavagata Saha (Shuvo)
        /// Date: 19-Jan-2016
        /// </summary>
        public void GetBEILCustomer()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select CustomerID,CustomerCode,CustomerName,CustomerAddress From dbo.t_Customer where CustomerID in (787,759,4337,4338)";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer oCustomer = new Customer();

                    oCustomer.CustomerID = (int)reader["CustomerID"];
                    oCustomer.CustomerCode = (string)reader["CustomerCode"];
                    oCustomer.CustomerName = (string)reader["CustomerName"];
                    oCustomer.CustomerAddress = (string)(reader["CustomerAddress"]);
                    InnerList.Add(oCustomer);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Get B2B Customer For Varification
        /// Shavagata Saha (Shuvo)
        /// Date: 28-Feb-2016
        /// </summary>
        /// 

        public void GetB2BCustomerForVarification(string sCustomerCode, string sCustomerName, int nStatus, int nCustType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            {
                sSql = " Select * From (Select a.*,Status=Case when ID=0 then 0 else 1 end From  " +
                       " (Select a.*,  " +
                       " isnull(ID,0) ID,isnull(NatureofBusiness,0) NatureofBusiness,  " +
                       " isnull(Type,0) Type,isnull(CompanyType,0) CompanyType,isnull(NoOfEmployee,0) NoOfEmployee,  " +
                       " isnull(ExpectedSales,0) ExpectedSales,isnull(CompanyCategory,0) CompanyCategory,  " +
                       " isnull(VerifiedThrough,0) VerifiedThrough,isnull(Remarks,'') Remarks,  " +
                       " isnull(VerifiedDate,getdate())  VerifiedDate " +
                       " From   " +
                       " (Select * From v_CustomerDetails where CustomerTypeID=" + nCustType + ") a  " +
                       " Left Outer Join  " +
                       " (Select * From dbo.t_CustomerVerificationInfo) b  " +
                       " on a.CustomerID=b.CustomerID) a) Final where 1=1 ";
            }

            if (sCustomerCode != "")
            {
                sSql = sSql + " AND CustomerCode like '%" + sCustomerCode + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND CustomerName like '%" + sCustomerName + "%'";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            sSql = sSql + " Order by CustomerID DESC";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Customer oCustomer = new Customer();

                    oCustomer.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oCustomer.CustomerCode = reader["CustomerCode"].ToString();
                    if (reader["CustomerShortName"] != DBNull.Value)
                        oCustomer.CustomerShortName = (string)reader["CustomerShortName"];
                    else oCustomer.CustomerShortName = "";
                    oCustomer.CustomerName = reader["CustomerName"].ToString();
                    oCustomer.CustomerAddress = reader["CustomerAddress"].ToString();
                    if (reader["CustomerTelephone"] != DBNull.Value)
                        oCustomer.CustomerTelephone = reader["CustomerTelephone"].ToString();
                    else oCustomer.CustomerTelephone = "";
                    if (reader["CustomerFax"] != DBNull.Value)
                        oCustomer.CustomerFax = reader["CustomerFax"].ToString();
                    else oCustomer.CustomerFax = "";
                    if (reader["CellPhoneNo"] != DBNull.Value)
                        oCustomer.CellPhoneNo = reader["CellPhoneNo"].ToString();
                    else oCustomer.CellPhoneNo = "";
                    if (reader["ContractPerson"] != DBNull.Value)
                        oCustomer.ContactPerson = reader["ContractPerson"].ToString();
                    else oCustomer.ContactPerson = "";
                    if (reader["ContactDesignation"] != DBNull.Value)
                        oCustomer.ContactDesignation = reader["ContactDesignation"].ToString();
                    else oCustomer.ContactDesignation = "";
                    oCustomer.ChannelDescription = reader["ChannelDescription"].ToString();
                    oCustomer.ChannelID = int.Parse(reader["ChannelID"].ToString());
                    oCustomer.AreaID = int.Parse(reader["AreaID"].ToString());
                    oCustomer.AreaName = reader["AreaName"].ToString();
                    oCustomer.Territory = reader["territoryName"].ToString();
                    oCustomer.CustTypeID = int.Parse(reader["CustomerTypeID"].ToString());
                    oCustomer.MarketGroupID = int.Parse(reader["TerritoryID"].ToString());
                    oCustomer.DistrictID = int.Parse(reader["DistrictID"].ToString());
                    oCustomer.GeoLocationID = int.Parse(reader["ThanaID"].ToString());
                    if (reader["ParentCustomerName"] != DBNull.Value)
                        oCustomer.ParentCustomerName = reader["ParentCustomerName"].ToString();
                    else oCustomer.ParentCustomerName = "";



                    oCustomer.VarificationID = int.Parse(reader["ID"].ToString());
                    oCustomer.NatureofBusiness = int.Parse(reader["NatureofBusiness"].ToString());
                    oCustomer.Type = int.Parse(reader["Type"].ToString());
                    oCustomer.CompanyType = int.Parse(reader["CompanyType"].ToString());
                    oCustomer.NoOfEmployee = int.Parse(reader["NoOfEmployee"].ToString());
                    oCustomer.ExpectedSales = Convert.ToDouble(reader["ExpectedSales"].ToString());
                    oCustomer.CompanyCategory = int.Parse(reader["CompanyCategory"].ToString());
                    oCustomer.VerifiedThrough = int.Parse(reader["VerifiedThrough"].ToString());
                    oCustomer.Remarks = reader["Remarks"].ToString();
                    oCustomer.VerifiedDate = Convert.ToDateTime(reader["VerifiedDate"].ToString());
                    oCustomer.Status = int.Parse(reader["Status"].ToString());
                    InnerList.Add(oCustomer);
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
        
        /// <summary>
        /// Get Temp Customer
        /// Shavagata Saha (Shuvo)
        /// Date: 16-Jul-2016
        /// </summary>
        /// 
        public void RefreshTempCustomer(DateTime dFromDate, DateTime dToDate, string sCustomerCode, string sCustomerName, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From t_CustomerTemp where 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";
            }

            if (sCustomerCode != "")
            {
                sSql = sSql + " AND NewCustomerCode like '%" + sCustomerCode + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND CustomerName like '%" + sCustomerName + "%'";
            }
            sSql = sSql + " Order by CustomerID Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer oCustomer = new Customer();
                    oCustomer.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oCustomer.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oCustomer.ParentCustomerID = int.Parse(reader["ParentCustomerID"].ToString());
                    if (reader["NewCustomerCode"] != DBNull.Value)
                        oCustomer.CustomerCode = reader["NewCustomerCode"].ToString();
                    else oCustomer.CustomerCode = "";

                    if (reader["CustomerShortName"] != DBNull.Value)
                        oCustomer.CustomerShortName = (string)reader["CustomerShortName"];
                    else oCustomer.CustomerShortName = "";
                    oCustomer.CustomerName = reader["CustomerName"].ToString();
                    oCustomer.CustomerAddress = reader["CustomerAddress"].ToString();
                    if (reader["CustomerTelephone"] != DBNull.Value)
                        oCustomer.CustomerTelephone = reader["CustomerTelephone"].ToString();
                    else oCustomer.CustomerTelephone = "";
                    if (reader["CustomerFax"] != DBNull.Value)
                        oCustomer.CustomerFax = reader["CustomerFax"].ToString();
                    else oCustomer.CustomerFax = "";
                    oCustomer.CellPhoneNo = reader["CellPhoneNumber"].ToString();
                    if (reader["ContactPerson"] != DBNull.Value)
                        oCustomer.ContactPerson = reader["ContactPerson"].ToString();
                    else oCustomer.ContactPerson = "";
                    if (reader["ContactDesignation"] != DBNull.Value)
                        oCustomer.ContactDesignation = reader["ContactDesignation"].ToString();
                    else oCustomer.ContactDesignation = "";
                    oCustomer.IsActive = int.Parse(reader["IsActive"].ToString());
                    oCustomer.CustTypeID = int.Parse(reader["CustTypeID"].ToString());
                    oCustomer.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    oCustomer.GeoLocationID = int.Parse(reader["GeoLocationID"].ToString());
                    if (reader["EmailAddress"] != DBNull.Value)
                        oCustomer.EmailAddress = reader["EmailAddress"].ToString();
                    else oCustomer.EmailAddress = "";
                    oCustomer.EnrollmentDate = Convert.ToDateTime(reader["EnrollmentDate"].ToString());
                    oCustomer.Terminal = int.Parse(reader["Terminal"].ToString());
                    oCustomer.EntryDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCustomer.EntryUserID = int.Parse(reader["CreateUserID"].ToString());
                    oCustomer.Status = int.Parse(reader["Status"].ToString());
                    if (reader["TaxNumber"] != DBNull.Value)
                        oCustomer.TaxNumber = reader["TaxNumber"].ToString();
                    else oCustomer.TaxNumber = "";

                    InnerList.Add(oCustomer);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshTempCustomerRT(DateTime dFromDate, DateTime dToDate, string sCustomerCode, string sCustomerName, bool IsCheck,int nWHID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From t_CustomerTemp where WarehouseID=" + nWHID + "";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";
            }

            if (sCustomerCode != "")
            {
                sSql = sSql + " AND NewCustomerCode like '%" + sCustomerCode + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND CustomerName like '%" + sCustomerName + "%'";
            }
            sSql = sSql + " Order by CustomerID Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer oCustomer = new Customer();
                    oCustomer.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oCustomer.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oCustomer.ParentCustomerID = int.Parse(reader["ParentCustomerID"].ToString());
                    if (reader["NewCustomerCode"] != DBNull.Value)
                        oCustomer.CustomerCode = reader["NewCustomerCode"].ToString();
                    else oCustomer.CustomerCode = "";

                    if (reader["CustomerShortName"] != DBNull.Value)
                        oCustomer.CustomerShortName = (string)reader["CustomerShortName"];
                    else oCustomer.CustomerShortName = "";
                    oCustomer.CustomerName = reader["CustomerName"].ToString();
                    oCustomer.CustomerAddress = reader["CustomerAddress"].ToString();
                    if (reader["CustomerTelephone"] != DBNull.Value)
                        oCustomer.CustomerTelephone = reader["CustomerTelephone"].ToString();
                    else oCustomer.CustomerTelephone = "";
                    if (reader["CustomerFax"] != DBNull.Value)
                        oCustomer.CustomerFax = reader["CustomerFax"].ToString();
                    else oCustomer.CustomerFax = "";
                    oCustomer.CellPhoneNo = reader["CellPhoneNumber"].ToString();
                    if (reader["ContactPerson"] != DBNull.Value)
                        oCustomer.ContactPerson = reader["ContactPerson"].ToString();
                    else oCustomer.ContactPerson = "";
                    if (reader["ContactDesignation"] != DBNull.Value)
                        oCustomer.ContactDesignation = reader["ContactDesignation"].ToString();
                    else oCustomer.ContactDesignation = "";
                    oCustomer.IsActive = int.Parse(reader["IsActive"].ToString());
                    oCustomer.CustTypeID = int.Parse(reader["CustTypeID"].ToString());
                    oCustomer.MarketGroupID = int.Parse(reader["MarketGroupID"].ToString());
                    oCustomer.GeoLocationID = int.Parse(reader["GeoLocationID"].ToString());
                    if (reader["EmailAddress"] != DBNull.Value)
                        oCustomer.EmailAddress = reader["EmailAddress"].ToString();
                    else oCustomer.EmailAddress = "";
                    oCustomer.EnrollmentDate = Convert.ToDateTime(reader["EnrollmentDate"].ToString());
                    oCustomer.Terminal = int.Parse(reader["Terminal"].ToString());
                    oCustomer.EntryDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCustomer.EntryUserID = int.Parse(reader["CreateUserID"].ToString());
                    oCustomer.Status = int.Parse(reader["Status"].ToString());
                    if (reader["TaxNumber"] != DBNull.Value)
                        oCustomer.TaxNumber = reader["TaxNumber"].ToString();
                    else oCustomer.TaxNumber = "";

                    InnerList.Add(oCustomer);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        /// <summary>
        /// Get Temp Customer
        /// Shavagata Saha (Shuvo)
        /// Date: 16-Jul-2016
        /// </summary>
        /// 
        public void RefreshTempCustomerForHO(DateTime dFromDate, DateTime dToDate, string sCustomerCode, string sCustomerName,int nWarehouseID,int nStatus, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From  "+
                    "(SELECT WarehouseID,qq6.ShowroomCode,qq1.CustomerID, qq1.CustomerName,isnull(qq7.NewCustomerCode,'') as CustomerCode,qq1.CreateDate,qq1.CreateUserID, qq1.ParentCustomerID, qq5.CustomerCode AS ParentCustomerCode,   " +
                    "qq5.CustomerName AS ParentCustomerName, qq1.CustomerAddress, qq1.CustomerTelephone, qq1.CustomerFax, qq1.CellPhoneNumber AS CellPhoneNo,  "+
                    "qq1.CustomerShortName,qq1.CellPhoneNumber,qq1.ContactPerson,qq1.CustTypeID,qq1.MarketGroupID,qq1.GeoLocationID,  "+
                    "qq1.EmailAddress,qq1.EnrollmentDate,qq1.Terminal,qq1.Status,   "+
                    "qq1.ContactPerson AS ContractPerson, qq1.ContactDesignation, qq1.IsActive, qq1.SBUID, qq1.SBUCode, qq1.SBUName, qq1.ChannelID, qq1.ChannelCode,   "+
                    "qq1.ChannelDescription, qq1.CustTypeID AS CustomerTypeID, qq1.CustTypeCode AS CustomerTypeCode, qq1.CustTypeDescription AS CustomerTypeName,   "+
                    "qq2.Areaid, qq2.AreaCode, qq2.AreaName, qq2.TerritoryID, qq2.TerritoryCode, qq2.TerritoryName, qq3.DistrictID, qq3.DistrictCode, qq3.DistrictName, qq3.ThanaID,   "+
                    "qq3.ThanaCode, qq3.ThanaName, qq3.ThanaCategory  "+
                    "FROM      "+
                    "(SELECT c.CustomerID, c.ParentCustomerID,c.CustomerShortName, c.CustomerName,  "+
                    "c.CreateDate,c.CreateUserID, c.CustomerAddress, isnull(c.CustomerTelephone,'') CustomerTelephone,   "+
                    "isnull(c.CustomerFax,'') CustomerFax, c.CellPhoneNumber,   "+
                    "c.ContactPerson, c.ContactDesignation, c.IsActive, c.GeoLocationID,   "+
                    "isnull(c.EmailAddress,'') EmailAddress,c.EnrollmentDate,c.Terminal,  "+
                    "c.Status,c.MarketGroupID, t.CustTypeID, t.CustTypeCode, t.CustTypeDescription, ch.ChannelID,   "+
                    "ch.ChannelCode, ch.ChannelDescription, sb.SBUID, sb.SBUCode, sb.SBUName  "+
                    "FROM  dbo.t_CustomertEMP AS c INNER JOIN  "+
                    "dbo.t_CustomerType AS t ON c.CustTypeID = t.CustTypeID INNER JOIN  "+
                    "dbo.t_Channel AS ch ON t.ChannelID = ch.ChannelID INNER JOIN  "+
                    "dbo.t_SBU AS sb ON ch.SBUID = sb.SBUID) AS qq1   "+
                    "INNER JOIN  "+
                    "(SELECT q1.MarketGroupID AS Areaid, q1.MarketGroupCode AS AreaCode,   "+
                    "q1.MarketGroupDesc AS AreaName, q2.MarketGroupID AS TerritoryID,   "+
                    " q2.MarketGroupCode AS TerritoryCode, q2.MarketGroupDesc AS TerritoryName  "+
                    "FROM      "+
                    "(SELECT MarketGroupID, MarketGroupCode, MarketGroupDesc, ParentID  "+
                    " FROM dbo.t_MarketGroup) AS q1 INNER JOIN  "+
                    "(SELECT MarketGroupID, MarketGroupCode, MarketGroupDesc, ParentID  "+
                    " FROM dbo.t_MarketGroup AS t_MarketGroup_1) AS q2 ON q1.MarketGroupID = q2.ParentID) AS qq2 ON   "+
                    "qq1.MarketGroupID = qq2.TerritoryID   "+
                    "LEFT OUTER JOIN  "+
                    "(SELECT q3.GeoLocationID AS DistrictID, q3.GeoLocationCode AS DistrictCode, q3.GeoLocationName AS DistrictName, q4.GeoLocationID AS ThanaID,   "+
                    "q4.GeoLocationCode AS ThanaCode, q4.GeoLocationName AS ThanaName, q4.GeoLocationCategory AS ThanaCategory  "+
                    "FROM (SELECT GeoLocationID, GeoLocationCode, GeoLocationName, ParentID  "+
                    "FROM  dbo.t_GeoLocation) AS q3 INNER JOIN  "+
                    "(SELECT GeoLocationID, GeoLocationCode, GeoLocationName, GeoLocationCategory, ParentID  "+
                    "FROM dbo.t_GeoLocation AS t_GeoLocation_1) AS q4 ON q3.GeoLocationID = q4.ParentID) AS qq3 ON   "+
                    "qq1.GeoLocationID = qq3.ThanaID  "+
                    "LEFT OUTER JOIN  "+
                    " (SELECT CustomerID, CustomerCode, CustomerName  "+
                    "FROM  dbo.t_Customer ) AS qq5 ON qq1.ParentCustomerID = qq5.CustomerID  "+
                    "LEFT OUTER JOIN  "+
                    " (SELECT CustomerID, WarehouseID,ShowroomCode  "+
                    "FROM  dbo.t_Showroom ) AS qq6 ON qq1.ParentCustomerID = qq6.CustomerID  " +
                    " left outer join  "+
                    " (Select * From (Select a.CustomerID,NewCustomerCode,a.ParentCustomerID From t_CustomerTemp a,t_Customer b   " +
                    " where a.NewCustomerCode=b.CustomerCode) x) AS qq7 ON qq1.CustomerID = qq7.CustomerID  and qq1.ParentCustomerID=qq7.ParentCustomerID   " +
                    ") Main where 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";
            }

            if (sCustomerCode != "")
            {
                sSql = sSql + " AND CustomerCode like '%" + sCustomerCode + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND CustomerName like '%" + sCustomerName + "%'";
            }
            if (nWarehouseID != -1)
            {
                sSql = sSql + " AND WarehouseID=" + nWarehouseID + "";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            sSql = sSql + " Order by CustomerID Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Customer oCustomer = new Customer();

                    oCustomer.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oCustomer.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    oCustomer.ShowroomCode = reader["ShowroomCode"].ToString();
                    oCustomer.CustomerCode = reader["CustomerCode"].ToString();
                    oCustomer.ParentCustomerCode = reader["ParentCustomerCode"].ToString();
                    if (reader["CustomerShortName"] != DBNull.Value)
                        oCustomer.CustomerShortName = (string)reader["CustomerShortName"];
                    else oCustomer.CustomerShortName = "";
                    oCustomer.CustomerName = reader["CustomerName"].ToString();
                    oCustomer.CustomerAddress = reader["CustomerAddress"].ToString();
                    oCustomer.CustomerTelephone = reader["CustomerTelephone"].ToString();
                    oCustomer.CustomerFax = reader["CustomerFax"].ToString();
                    oCustomer.CellPhoneNo = reader["CellPhoneNo"].ToString();
                    oCustomer.ContactPerson = reader["ContractPerson"].ToString();
                    oCustomer.ContactDesignation = reader["ContactDesignation"].ToString();
                    oCustomer.ChannelDescription = reader["ChannelDescription"].ToString();
                    oCustomer.ChannelID = int.Parse(reader["ChannelID"].ToString());
                    oCustomer.AreaID = int.Parse(reader["AreaID"].ToString());
                    oCustomer.AreaName = reader["AreaName"].ToString();
                    oCustomer.EmailAddress = reader["EmailAddress"].ToString();
                    oCustomer.Territory = reader["territoryName"].ToString();
                    oCustomer.CustTypeID = int.Parse(reader["CustomerTypeID"].ToString());
                    oCustomer.MarketGroupID = int.Parse(reader["TerritoryID"].ToString());
                    oCustomer.DistrictID = int.Parse(reader["DistrictID"].ToString());
                    oCustomer.GeoLocationID = int.Parse(reader["ThanaID"].ToString());
                    oCustomer.Status = int.Parse(reader["Status"].ToString());
                    oCustomer.EntryUserID = int.Parse(reader["CreateUserID"].ToString());
                    oCustomer.EntryDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCustomer.Terminal = int.Parse(reader["Terminal"].ToString());

                    InnerList.Add(oCustomer);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetConsumerDetails(string sMobileNo)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            {
                sSql = "Select * From t_ConsumerDetail where MobileNo='" + sMobileNo + "' or AlternativeCellNo='" + sMobileNo + "'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer oCustomer = new Customer();
                    oCustomer.CustomerID = int.Parse(reader["ConsumerID"].ToString());
                    oCustomer.CustomerCode = reader["ConsumerCode"].ToString();
                    oCustomer.CustomerName = reader["ConsumerName"].ToString();
                    oCustomer.CustomerAddress = reader["Address"].ToString();
                    oCustomer.MobileNo = reader["MobileNo"].ToString();

                    if (reader["PhoneNo"] != DBNull.Value)
                        oCustomer.CustomerTelephone = reader["PhoneNo"].ToString();
                    else oCustomer.CustomerTelephone = "";
                    
                    if (reader["Email"] != DBNull.Value)
                        oCustomer.EmailAddress = reader["Email"].ToString();
                    else oCustomer.EmailAddress = "";

                    if (reader["AlternativeCellNo"] != DBNull.Value)
                        oCustomer.AlternativeCellNo = reader["AlternativeCellNo"].ToString();
                    else oCustomer.AlternativeCellNo = "";

                    if (reader["IsVerified"] != DBNull.Value)
                        oCustomer.IsVerified = int.Parse(reader["IsVerified"].ToString());
                    else oCustomer.IsVerified = 0;

                    InnerList.Add(oCustomer);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetConsumerHistory(int nConsumerID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.ConsumerID,isnull(a.ConsumerCode,b.ConsumerCode) as ConsumerCode, " +
                        "isnull(a.ConsumerName, b.ConsumerName) as ConsumerName,isnull(a.Address, b.Address) as Address,isnull(IsVerifiedEmail,0) IsVerifiedEmail, " +
                        "isnull(a.MobileNo, b.MobileNo) as MobileNo,isnull(a.PhoneNo, b.PhoneNo) as PhoneNo, " +
                        "isnull(a.Email, b.Email) as Email,Company,System,TranType,WHCode,SalesType, " +
                        "TranNo,TranDate,ProductCode,ProductName,Qty,Amount From TELSYSDB.DBO.t_ConsumerDetailTran a, TELSYSDB.DBO.t_ConsumerDetail b " +
                        "where a.ConsumerID = b.ConsumerID and a.ConsumerID = " + nConsumerID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer oCustomer = new Customer();
                    oCustomer.CustomerID = (int)reader["ConsumerID"];
                    oCustomer.Company = reader["Company"].ToString();
                    oCustomer.System = reader["System"].ToString();
                    oCustomer.TranType = reader["TranType"].ToString();
                    oCustomer.ShowroomCode = reader["WHCode"].ToString();
                    oCustomer.SalesType = reader["SalesType"].ToString();
                    oCustomer.TranNo = reader["TranNo"].ToString();
                    oCustomer.TranDate = (DateTime)reader["TranDate"];
                    oCustomer.ProductCode = reader["ProductCode"].ToString();
                    oCustomer.ProductName = reader["ProductName"].ToString();
                    oCustomer.Qty = (int)reader["Qty"];
                    oCustomer.Amount = (double)reader["Amount"];
                    oCustomer.CustomerCode = reader["ConsumerCode"].ToString();
                    oCustomer.CustomerName = reader["ConsumerName"].ToString();
                    oCustomer.CustomerAddress = reader["Address"].ToString();
                    oCustomer.MobileNo = reader["MobileNo"].ToString();
                    if (reader["PhoneNo"] != DBNull.Value)
                        oCustomer.CustomerTelephone = reader["PhoneNo"].ToString();
                    else oCustomer.CustomerTelephone = "";
                    if (reader["Email"] != DBNull.Value)
                        oCustomer.EmailAddress = reader["Email"].ToString();
                    else oCustomer.EmailAddress = "";
                    oCustomer.IsVerifiedEmail = (int)reader["IsVerifiedEmail"];


                    InnerList.Add(oCustomer);

                }

                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }

}


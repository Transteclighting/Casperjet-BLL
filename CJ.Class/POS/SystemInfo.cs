// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas.
// Date: March 13, 2012
// Time :  12:00 PM
// Description: Class for System info in Retail DB.
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
    public class SystemInfo
    {
        private string _sShowroomCode;
        private string _sCustomerCode;
        private string _sCustomerName;
        private int _nWarehouseID;
        private int _nCustTypeID;
        private string _sWarehouseCode;
        private string _sWarehouseName;
        private string _sWarehouseAddress;
        private string _sLocationName;
        private int _nLocationID;
        private string _sShortcode;
        private int _nCustomerID;
        private int _nChannelID;
        private string _sWarehousePhoneNo;
        private string _sWarehouseCellNo;
        private string _sWarehouseEmail;
        private string _sHCPhoneNo;
        private string _sHCMobileNo; 
        private string _sHCEmail;
        private object _dLastOperationDate;
        private object _dOperationDate;
        private object _dNextOperationDate;
        private object _dLastMonthEndDate;
        private object _dLastYearEndDate;
        private int _nCreatedBy;
        private DateTime _dtCJVersionLaunchedDate;
        private string _sCJVersionNo;
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value; }
        }

        public string CJVersionNo
        {
            get { return _sCJVersionNo; }
            set { _sCJVersionNo = value; }
        }

        public DateTime CJVersionLaunchedDate
        {
            get { return _dtCJVersionLaunchedDate; }
            set { _dtCJVersionLaunchedDate = value; }
        }
        private DateTime _dCreateDate;
        private int _nIsActive;
        private string _sCentralRegisteredPersonAddress;
        private string _sVATRegistrationNo;
        private string _sPOSVersionNo;
        private object _dSystemDisableDate;
        private string _sAddress;
        private object _dHOStockUpdateDate;
        private int _nPositionID;
        private int _IsActiveSalesOrder;
        private int _IsThermalPrintEnable;

        public int IsThermalPrintEnable
        {
            get { return _IsThermalPrintEnable; }
            set { _IsThermalPrintEnable = value; }
        }
        public int LocationID
        {
            get { return _nLocationID; }
            set { _nLocationID = value; }
        }
        public string LocationName
        {
            get { return _sLocationName; }
            set { _sLocationName = value; }
        }

        public int IsActiveSalesOrder
        {
            get { return _IsActiveSalesOrder; }
            set { _IsActiveSalesOrder = value; }
        }

        private int _nIsNewVat;
        private object _dtNewVatActivationDate;
        public int IsNewVat
        {
            get { return _nIsNewVat; }
            set { _nIsNewVat = value; }
        }
        public object NewVatActivationDate
        {
            get { return _dtNewVatActivationDate; }
            set { _dtNewVatActivationDate = value; }
        }

        public int CustTypeID
        {
            get { return _nCustTypeID; }
            set { _nCustTypeID = value; }
        }

        public string CentralRegisteredPersonAddress
        {
            get { return _sCentralRegisteredPersonAddress; }
            set { _sCentralRegisteredPersonAddress = value; }
        }

        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        public int PositionID
        {
            get { return _nPositionID; }
            set { _nPositionID = value; }
        }
            
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }
        public string WarehouseCode
        {
            get { return _sWarehouseCode; }
            set { _sWarehouseCode = value; }
        }
        public string WarehouseName
        {
            get { return _sWarehouseName; }
            set { _sWarehouseName = value; }
        }
        public string WarehouseAddress
        {
            get { return _sWarehouseAddress; }
            set { _sWarehouseAddress = value; }
        }
        public string Shortcode
        {
            get { return _sShortcode; }
            set { _sShortcode = value; }
        }
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        public int ChannelID
        {
            get { return _nChannelID; }
            set { _nChannelID = value; }
        }
        
        public string WarehousePhoneNo
        {
            get { return _sWarehousePhoneNo; }
            set { _sWarehousePhoneNo = value; }
        }
        public string WarehouseCellNo
        {
            get { return _sWarehouseCellNo; }
            set { _sWarehouseCellNo = value; }
        }
        public string WarehouseEmail
        {
            get { return _sWarehouseEmail; }
            set { _sWarehouseEmail = value; }

        }
        public string HCPhoneNo
        {
            get { return _sHCPhoneNo; }
            set { _sHCPhoneNo = value; }
        }       
        public string HCMobileNo
        {
            get { return _sHCMobileNo; }
            set { _sHCMobileNo = value.Trim(); }
        }
        public string HCEmail
        {
            get { return _sHCEmail; }
            set { _sHCEmail = value; }
        }       
        public object LastOperationDate
        {
            get { return _dLastOperationDate; }
            set { _dLastOperationDate = value; }
        }
        public object OperationDate
        {
            get { return _dOperationDate; }
            set { _dOperationDate = value; }
        }
        public object NextOperationDate
        {
            get { return _dNextOperationDate; }
            set { _dNextOperationDate = value; }
        }
        public object LastMonthEndDate
        {
            get { return _dLastMonthEndDate; }
            set { _dLastMonthEndDate = value; }
        }       
        public object LastYearEndDate
        {
            get { return _dLastYearEndDate; }
            set { _dLastYearEndDate = value; }
        }
        public int CreatedBy
        {
            get { return _nCreatedBy; }
            set { _nCreatedBy = value; }
        }        
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
        public string VATRegistrationNo
        {
            get { return _sVATRegistrationNo; }
            set { _sVATRegistrationNo = value; }
        }
        public string POSVersionNo
        {
            get { return _sPOSVersionNo; }
            set { _sPOSVersionNo = value; }
        }
        public object SystemDisableDate
        {
            get { return _dSystemDisableDate; }
            set { _dSystemDisableDate = value; }
        }
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }
        public object HOStockUpdateDate
        {
            get { return _dHOStockUpdateDate; }
            set { _dHOStockUpdateDate = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "insert into t_TDOutlets  VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("WarehouseCode", _sWarehouseCode);
                cmd.Parameters.AddWithValue("WarehouseName", _sWarehouseName);
                cmd.Parameters.AddWithValue("WarehouseAddress", _sWarehouseAddress);
                cmd.Parameters.AddWithValue("Shortcode", _sShortcode);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ChannelID", _nChannelID);
                cmd.Parameters.AddWithValue("PhoneNo", _sWarehousePhoneNo);
                cmd.Parameters.AddWithValue("MobileNo", _sWarehouseCellNo);
                cmd.Parameters.AddWithValue("Email", _sWarehouseEmail);
                cmd.Parameters.AddWithValue("HCMobileNo", _sHCMobileNo);
                cmd.Parameters.AddWithValue("HCPhoneNo", _sHCPhoneNo);
                cmd.Parameters.AddWithValue("HCEmail", _sHCEmail);
                if(_dLastOperationDate!=null)
                    cmd.Parameters.AddWithValue("LastOperationDate", Convert.ToDateTime(_dLastOperationDate));
                else cmd.Parameters.AddWithValue("LastOperationDate", null);
                if (_dOperationDate != null)
                    cmd.Parameters.AddWithValue("OperationDate", Convert.ToDateTime(_dOperationDate));
                else cmd.Parameters.AddWithValue("OperationDate", null);
                if (_dNextOperationDate != null)
                    cmd.Parameters.AddWithValue("NextOperationDate", Convert.ToDateTime(_dNextOperationDate));
                else cmd.Parameters.AddWithValue("NextOperationDate", null);
                if (_dLastMonthEndDate != null)
                    cmd.Parameters.AddWithValue("LastMonthEndDate", Convert.ToDateTime(_dLastMonthEndDate));
                else cmd.Parameters.AddWithValue("LastMonthEndDate", null);
                if (_dLastYearEndDate != null)
                    cmd.Parameters.AddWithValue("LastYearEndDate", Convert.ToDateTime(_dLastYearEndDate));
                else cmd.Parameters.AddWithValue("LastYearEndDate", null);

                cmd.Parameters.AddWithValue("CreatedBy", _nCreatedBy);
                cmd.Parameters.AddWithValue("CreateDate ", _dCreateDate);
                cmd.Parameters.AddWithValue("IsActive ", _nIsActive);
                cmd.Parameters.AddWithValue("VATRegistrationNo ", _sVATRegistrationNo);
            
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
            string sSql = "";

            try
            {
                sSql = "Update t_TDOutlets Set WarehouseCode=?, WarehouseName=?, WarehouseAddress=?,CustomerID=?,PhoneNo=?,MobileNo=?,Email=?,HCMobileNo=?,HCPhoneNo=?,HCEmail=?,"
                      + " IsActive=?,VATRegistrationNo=? Where WarehouseID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WarehouseCode", _sWarehouseCode);
                cmd.Parameters.AddWithValue("WarehouseName", _sWarehouseName);
                cmd.Parameters.AddWithValue("WarehouseAddress", _sWarehouseAddress);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);     
                cmd.Parameters.AddWithValue("PhoneNo", _sWarehousePhoneNo);
                cmd.Parameters.AddWithValue("MobileNo", _sWarehouseCellNo);
                cmd.Parameters.AddWithValue("Email", _sWarehouseEmail);
                cmd.Parameters.AddWithValue("HCMobileNo", _sHCMobileNo);
                cmd.Parameters.AddWithValue("HCPhoneNo", _sHCPhoneNo);
                cmd.Parameters.AddWithValue("HCEmail", _sHCEmail);             
                cmd.Parameters.AddWithValue("IsActive ", _nIsActive);
                cmd.Parameters.AddWithValue("VATRegistrationNo ", _sVATRegistrationNo);

                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                
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
            try
            {
                cmd.CommandText = "SELECT a.*,CustomerCode,CustomerName,CustTypeID FROM t_ThisSystem a,t_Customer b where a.CustomerID=b.CustomerID";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sCustomerCode = (string)reader["CustomerCode"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _nCustTypeID = (int)reader["CustTypeID"];
                    _sWarehouseCode = (string)reader["WarehouseCode"];
                    _sWarehouseName = (string)reader["WarehouseName"];
                    _sWarehouseAddress = (string)reader["WarehouseAddress"];
                    _sShortcode = reader["Shortcode"].ToString();
                    _nCustomerID = (int)reader["CustomerID"];
                    _nChannelID = (int)reader["ChannelID"];
                    _sWarehousePhoneNo = reader["PhoneNo"].ToString();
                    _sWarehouseCellNo = reader["MobileNo"].ToString();
                    _sWarehouseEmail = reader["Email"].ToString();
                    _sHCMobileNo = reader["HCMobileNo"].ToString();
                    _sHCPhoneNo = reader["HCPhoneNo"].ToString();
                    _sHCEmail = reader["HCEmail"].ToString();
                    if (reader["LastOperationDate"] != DBNull.Value)
                        _dLastOperationDate = (object)reader["LastOperationDate"];
                    else _dLastOperationDate = null;
                    if (reader["OperationDate"] != DBNull.Value)
                        _dOperationDate = (object)reader["OperationDate"];
                    else _dOperationDate = null;
                    if (reader["NextOperationDate"] != DBNull.Value)
                        _dNextOperationDate = (object)reader["NextOperationDate"];
                    else _dNextOperationDate = null;
                    if (reader["LastMonthEndDate"] != DBNull.Value)
                        _dLastMonthEndDate = (object)reader["LastMonthEndDate"];
                    else _dLastMonthEndDate = null;
                    if (reader["LastYearEndDate"] != DBNull.Value)
                        _dLastYearEndDate = (object)reader["LastYearEndDate"];
                    else _dLastYearEndDate = null;
                    _sVATRegistrationNo = reader["VATRegistrationNo"].ToString();
                    _sPOSVersionNo = reader["POSVersionNo"].ToString();
                    if (reader["SystemDisableDate"] != DBNull.Value)
                    {
                        _dSystemDisableDate = (object)reader["SystemDisableDate"];
                    }
                    else
                    {
                        _dSystemDisableDate = null;
                    }
                    if (reader["HOStockUpdateDate"] != DBNull.Value)
                        _dHOStockUpdateDate = (object)reader["HOStockUpdateDate"];
                    else _dHOStockUpdateDate = null;


                    if (reader["IsActiveSalesOrder"] != DBNull.Value)
                        _IsActiveSalesOrder = (int)reader["IsActiveSalesOrder"];
                    else _IsActiveSalesOrder = 0;


                    if (reader["CentralRegisteredPersonAddress"] != DBNull.Value)
                        _sCentralRegisteredPersonAddress = (string)reader["CentralRegisteredPersonAddress"];
                    else _sCentralRegisteredPersonAddress = "";

                    if (reader["VATRegistrationNo"] != DBNull.Value)
                        _sVATRegistrationNo = (string)reader["VATRegistrationNo"];
                    else _sVATRegistrationNo = "";



                    if (reader["IsThermalPrintEnable"] != DBNull.Value)
                        _IsThermalPrintEnable = (int)reader["IsThermalPrintEnable"];
                    else _IsThermalPrintEnable = 0;

                    

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                 throw (ex);
            }
        }
        public void RefreshPOSRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " SELECT a.*,c.Shortcode,CustomerCode,CustomerName,CustTypeID, c.WarehouseCode as WarehouseCode, a.ShowroomName as WarehouseName, a.ShowroomAddress as WarehouseAddress, d.* FROM t_Showroom a,t_Customer b, t_Warehouse c, (Select top 1.* from t_ThisSystem)d where a.CustomerID=b.CustomerID " +
                                  " and a.WarehouseID = c.WarehouseID and a.WarehouseID = (select WarehouseID from t_UserMapForPOS where UserId = " + Utility.UserId + ")";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nLocationID = (int)reader["LocationID"];
                    _sShowroomCode = (string)reader["ShowroomCode"];
                    _sCustomerCode = (string)reader["CustomerCode"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _nCustTypeID = (int)reader["CustTypeID"];
                    _sWarehouseCode = (string)reader["WarehouseCode"];
                    _sWarehouseName = (string)reader["WarehouseName"];
                    _sWarehouseAddress = (string)reader["WarehouseAddress"];
                    _sShortcode = reader["Shortcode"].ToString();
                    _nCustomerID = (int)reader["CustomerID"];
                    _nChannelID = (int)reader["ChannelID"];
                    _sWarehousePhoneNo = reader["PhoneNo"].ToString();
                    _sWarehouseCellNo = reader["MobileNo"].ToString();
                    _sWarehouseEmail = reader["Email"].ToString();
                    _sHCMobileNo = reader["HCMobileNo"].ToString();
                    _sHCPhoneNo = reader["HCPhoneNo"].ToString();
                    _sHCEmail = reader["HCEmail"].ToString();
                    _sVATRegistrationNo = reader["VATRegistrationNo"].ToString();
                    if (reader["CentralRegisteredPersonAddress"] != DBNull.Value)
                        _sCentralRegisteredPersonAddress = (string)reader["CentralRegisteredPersonAddress"];
                    else _sCentralRegisteredPersonAddress = "";

                    if (reader["VATRegistrationNo"] != DBNull.Value)
                        _sVATRegistrationNo = (string)reader["VATRegistrationNo"];
                    else _sVATRegistrationNo = "";



                    if (reader["IsThermalPrintEnable"] != DBNull.Value)
                        _IsThermalPrintEnable = (int)reader["IsThermalPrintEnable"];
                    else _IsThermalPrintEnable = 0;

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool CheckEligibilityforPOSOperation(string _userName)
        {
            bool _bFlag = false;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_POSSetup a,t_UserMapForPOS b, t_User c where a.WarehouseID=b.WarehouseID and " +
                                  " b.UserId = c.UserID and c.UserName = '" + _userName + "'";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _bFlag = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _bFlag;
        }
        public void RefreshForPOSNew(DateTime dtDeliveryDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT a.*,CustomerCode,CustomerName,CustTypeID FROM t_ThisSystem a,t_Customer b where a.CustomerID=b.CustomerID";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sCustomerCode = (string)reader["CustomerCode"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _nCustTypeID = (int)reader["CustTypeID"];
                    _sWarehouseCode = (string)reader["WarehouseCode"];
                    _sWarehouseName = (string)reader["WarehouseName"];
                    _sWarehouseAddress = (string)reader["WarehouseAddress"];
                    _sShortcode = reader["Shortcode"].ToString();
                    _nCustomerID = (int)reader["CustomerID"];
                    _nChannelID = (int)reader["ChannelID"];
                    _sWarehousePhoneNo = reader["PhoneNo"].ToString();
                    _sWarehouseCellNo = reader["MobileNo"].ToString();
                    _sWarehouseEmail = reader["Email"].ToString();
                    _sHCMobileNo = reader["HCMobileNo"].ToString();
                    _sHCPhoneNo = reader["HCPhoneNo"].ToString();
                    _sHCEmail = reader["HCEmail"].ToString();
                    if (reader["LastOperationDate"] != DBNull.Value)
                        _dLastOperationDate = (object)reader["LastOperationDate"];
                    else _dLastOperationDate = null;
                    if (reader["OperationDate"] != DBNull.Value)
                        _dOperationDate = (object)reader["OperationDate"];
                    else _dOperationDate = null;
                    if (reader["NextOperationDate"] != DBNull.Value)
                        _dNextOperationDate = (object)reader["NextOperationDate"];
                    else _dNextOperationDate = null;
                    if (reader["LastMonthEndDate"] != DBNull.Value)
                        _dLastMonthEndDate = (object)reader["LastMonthEndDate"];
                    else _dLastMonthEndDate = null;
                    if (reader["LastYearEndDate"] != DBNull.Value)
                        _dLastYearEndDate = (object)reader["LastYearEndDate"];
                    else _dLastYearEndDate = null;
                    _sVATRegistrationNo = reader["VATRegistrationNo"].ToString();
                    _sPOSVersionNo = reader["POSVersionNo"].ToString();
                    if (reader["SystemDisableDate"] != DBNull.Value)
                    {
                        _dSystemDisableDate = (object)reader["SystemDisableDate"];
                    }
                    else
                    {
                        _dSystemDisableDate = null;
                    }
                    if (reader["HOStockUpdateDate"] != DBNull.Value)
                        _dHOStockUpdateDate = (object)reader["HOStockUpdateDate"];
                    else _dHOStockUpdateDate = null;


                    if (reader["IsActiveSalesOrder"] != DBNull.Value)
                        _IsActiveSalesOrder = (int)reader["IsActiveSalesOrder"];
                    else _IsActiveSalesOrder = 0;




                    if (dtDeliveryDate.Date >= Convert.ToDateTime("01-Jan-2021").Date)
                    {
                        if (reader["CentralRegisteredPersonAddress"] != DBNull.Value)
                            _sCentralRegisteredPersonAddress = (string)reader["CentralRegisteredPersonAddress"];
                        else _sCentralRegisteredPersonAddress = "";
                    }
                    else
                    {
                        _sCentralRegisteredPersonAddress = "Sadar Road, Mohakhali, Dhaka-1206";
                    }

                    if (reader["VATRegistrationNo"] != DBNull.Value)
                        _sVATRegistrationNo = (string)reader["VATRegistrationNo"];
                    else _sVATRegistrationNo = "";

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForPOSNewRT(DateTime dtDeliveryDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT a.*,CustomerCode,CustomerName,CustTypeID FROM t_Showroom a,t_Customer b where a.CustomerID=b.CustomerID";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sCustomerCode = (string)reader["CustomerCode"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _nCustTypeID = (int)reader["CustTypeID"];
                    //_sWarehouseCode = (string)reader["WarehouseCode"];
                    //_sWarehouseName = (string)reader["WarehouseName"];
                    //_sWarehouseAddress = (string)reader["WarehouseAddress"];
                    //_sShortcode = reader["Shortcode"].ToString();
                    _sWarehouseCode = Utility.WarehouseCode;
                    _sWarehouseName = Utility.WarehouseName;
                    _sWarehouseAddress = Utility.WarehouseAddress;
                    _sShortcode = Utility.Shortcode;
                    //_nCustomerID = (int)reader["CustomerID"];
                   
                    _sCentralRegisteredPersonAddress = Utility.CentralRegisteredPersonAddress;
                    _sVATRegistrationNo = Utility.VATRegistrationNo;
                  

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForFactory()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select * From t_ThisSystem";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nLocationID = (int)reader["LocationID"];
                    _sLocationName = (string)reader["LocationName"];
                    _sWarehouseAddress = (string)reader["Address"];
                    _sShortcode = reader["Shortcode"].ToString();
                    _sVATRegistrationNo = (string)reader["VATRegistrationNo"];
                    _sPOSVersionNo = reader["VersionNo"].ToString();

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshHO()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select * from t_ThisSystem ";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _nIsNewVat = (int)reader["IsNewVat"];
                    _dtNewVatActivationDate = (DateTime)reader["NewVatActivationDate"];
                    _sAddress = (string)reader["Address"];
                    _sWarehousePhoneNo = reader["PhoneNo"].ToString();
                    _sWarehouseCellNo = reader["MobileNo"].ToString();
                    _sWarehouseEmail = reader["Email"].ToString();
                    _sHCMobileNo = reader["HCMobileNo"].ToString();
                    _sHCPhoneNo = reader["HCPhoneNo"].ToString();
                    _sHCEmail = reader["HCEmail"].ToString();
                    _sVATRegistrationNo = reader["VATRegistrationNo"].ToString();

                    if (reader["CentralRegisteredPersonAddress"] != DBNull.Value)
                        _sCentralRegisteredPersonAddress = (string)reader["CentralRegisteredPersonAddress"];
                    else _sCentralRegisteredPersonAddress = "";

                    _sCJVersionNo = (string)reader["CJVersionNo"];
                    _dtCJVersionLaunchedDate = (DateTime)reader["CJVersionLaunchedDate"];



                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshHONew(DateTime dtDeliveryDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select * from t_ThisSystem ";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _nIsNewVat = (int)reader["IsNewVat"];
                    _dtNewVatActivationDate = (DateTime)reader["NewVatActivationDate"];
                    _sAddress = (string)reader["Address"];
                    _sWarehousePhoneNo = reader["PhoneNo"].ToString();
                    _sWarehouseCellNo = reader["MobileNo"].ToString();
                    _sWarehouseEmail = reader["Email"].ToString();
                    _sHCMobileNo = reader["HCMobileNo"].ToString();
                    _sHCPhoneNo = reader["HCPhoneNo"].ToString();
                    _sHCEmail = reader["HCEmail"].ToString();
                    _sVATRegistrationNo = reader["VATRegistrationNo"].ToString();

                    if (dtDeliveryDate.Date >= Convert.ToDateTime("01-Jan-2021").Date)
                    {
                        if (reader["CentralRegisteredPersonAddress"] != DBNull.Value)
                            _sCentralRegisteredPersonAddress = (string)reader["CentralRegisteredPersonAddress"];
                        else _sCentralRegisteredPersonAddress = "";
                    }
                    else
                    {
                        _sCentralRegisteredPersonAddress = "Sadar Road, Mohakhali, Dhaka-1206";
                    }

                    _sCJVersionNo = (string)reader["CJVersionNo"];
                    _dtCJVersionLaunchedDate = (DateTime)reader["CJVersionLaunchedDate"];



                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshHOWithWH(int nWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select WarehouseName,Address, PhoneNo, MobileNo, Email, HCMobileNo, HCPhoneNo, HCEmail,VATRegistrationNo,IsNewVat,NewVatActivationDate from t_ThisSystem a, t_Warehouse b where WarehouseID = " + nWHID + "";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _nIsNewVat = (int)reader["IsNewVat"];
                    _dtNewVatActivationDate = (DateTime)reader["NewVatActivationDate"];
                    _sAddress = (string)reader["Address"];
                    _sWarehousePhoneNo = reader["PhoneNo"].ToString();
                    _sWarehouseCellNo = reader["MobileNo"].ToString();
                    _sWarehouseEmail = reader["Email"].ToString();
                    _sHCMobileNo = reader["HCMobileNo"].ToString();
                    _sHCPhoneNo = reader["HCPhoneNo"].ToString();
                    _sHCEmail = reader["HCEmail"].ToString();
                    _sVATRegistrationNo = reader["VATRegistrationNo"].ToString();
                    _sWarehouseAddress=(string)reader["Address"];
                    _sWarehouseName = (string)reader["WarehouseName"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshPOSISGM()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select WarehouseAddress Address, PhoneNo, MobileNo, Email, HCMobileNo, HCPhoneNo, HCEmail, VATRegistrationNo from t_ThisSystem ";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _sAddress = (string)reader["Address"];
                    _sWarehousePhoneNo = reader["PhoneNo"].ToString();
                    _sWarehouseCellNo = reader["MobileNo"].ToString();
                    _sWarehouseEmail = reader["Email"].ToString();
                    _sHCMobileNo = reader["HCMobileNo"].ToString();
                    _sHCPhoneNo = reader["HCPhoneNo"].ToString();
                    _sHCEmail = reader["HCEmail"].ToString();
                    _sVATRegistrationNo = reader["VATRegistrationNo"].ToString();

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_TDOutlets Where WarehouseID=?";
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _sWarehouseCode = (string)reader["WarehouseCode"];
                    _sWarehouseName = (string)reader["WarehouseName"];
                    _sWarehouseAddress = (string)reader["WarehouseAddress"];
                    _sShortcode = reader["Shortcode"].ToString();
                    _nCustomerID = (int)reader["CustomerID"];
                    _nChannelID = (int)reader["ChannelID"];
                    _sWarehousePhoneNo = reader["PhoneNo"].ToString();
                    _sWarehouseCellNo = reader["MobileNo"].ToString();
                    _sWarehouseEmail = reader["Email"].ToString();
                    _sHCMobileNo = reader["HCMobileNo"].ToString();
                    _sHCPhoneNo = reader["HCPhoneNo"].ToString();
                    _sHCEmail = reader["HCEmail"].ToString();
                    if (reader["LastOperationDate"] != DBNull.Value)
                        _dLastOperationDate = (object)reader["LastOperationDate"];
                    else _dLastOperationDate = null;
                    if (reader["OperationDate"] != DBNull.Value)
                        _dOperationDate = (object)reader["OperationDate"];
                    else _dOperationDate = null;
                    if (reader["NextOperationDate"] != DBNull.Value)
                        _dNextOperationDate = (object)reader["NextOperationDate"];
                    else _dNextOperationDate = null;
                    if (reader["LastMonthEndDate"] != DBNull.Value)
                        _dLastMonthEndDate = (object)reader["LastMonthEndDate"];
                    else _dLastMonthEndDate = null;
                    if (reader["LastYearEndDate"] != DBNull.Value)
                        _dLastYearEndDate = (object)reader["LastYearEndDate"];
                    else _dLastYearEndDate = null;

                    _nCreatedBy = (int)reader["CreatedBy"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nIsActive = (int)reader["IsActive"];
                    _sVATRegistrationNo = reader["VATRegistrationNo"].ToString();

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public void DayStart()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_ThisSystem Set OperationDate=? ";               

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OperationDate", Convert.ToDateTime(_dOperationDate));
             
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }            
        }
        
        public void DayEnd()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_ThisSystem Set  LastOperationDate=?,OperationDate=?,NextOperationDate=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LastOperationDate", Convert.ToDateTime(_dLastOperationDate));
                cmd.Parameters.AddWithValue("OperationDate", null);
                cmd.Parameters.AddWithValue("NextOperationDate", Convert.ToDateTime(_dNextOperationDate));

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateSystemDisableDate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_ThisSystem Set SystemDisableDate=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SystemDisableDate", _dSystemDisableDate);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetDisplayPositionID(int nWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select * From (Select ShowroomCode,max(PositionID) PositionID From  " +
                                  "(Select WarehouseID,ShowroomCode From t_Showroom where WarehouseID=" + nWHID + ") x  " +
                                  "left Outer Join   "+
                                  "(Select WHID,right(PositionCode,3) as PositionID   "+
                                  "From t_OutletDisplayPosition where WHID=" + nWHID + ") y  " +
                                  "on x.WarehouseID=y.WHID group by ShowroomCode) x";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sShortcode = (string)reader["ShowroomCode"];
                    if (reader["PositionID"] != DBNull.Value)
                        _nPositionID = Convert.ToInt16(reader["PositionID"].ToString());
                    else _nPositionID = 0;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int IsNewVatActive()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nIsActive = 0;
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_NewVatActivation";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nIsActive = (int)reader["IsNewVat"];
                    nCount++;

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nIsActive;
        }

        public void NewVatActive()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_ThisSystem";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["IsNewVat"] != DBNull.Value)
                        _nIsNewVat = Convert.ToInt32(reader["IsNewVat"].ToString());
                    else _nIsNewVat = 0;

                    if (reader["NewVatActivationDate"] != DBNull.Value)
                        _dtNewVatActivationDate = Convert.ToDateTime(reader["NewVatActivationDate"].ToString());
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
    public class SystemInfoList : CollectionBase
    {
        public SystemInfo this[int i]
        {
            get { return (SystemInfo)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SystemInfo oSystemInfo)
        {
            InnerList.Add(oSystemInfo);
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_TDOutlets ";
           
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SystemInfo oSystemInfo = new SystemInfo();

                    oSystemInfo.WarehouseID = (int)reader["WarehouseID"];
                    oSystemInfo.WarehouseName = (string)reader["WarehouseName"];
                    oSystemInfo.WarehouseAddress = (string)reader["WarehouseAddress"];
                    oSystemInfo.Shortcode = reader["Shortcode"].ToString();
                    oSystemInfo.CustomerID = (int)reader["CustomerID"];
                    oSystemInfo.ChannelID = (int)reader["ChannelID"];
                    oSystemInfo.WarehousePhoneNo = reader["PhoneNo"].ToString();
                    oSystemInfo.WarehouseCellNo = reader["MobileNo"].ToString();
                    oSystemInfo.WarehouseEmail = reader["Email"].ToString();
                    oSystemInfo.HCMobileNo = reader["HCMobileNo"].ToString();
                    oSystemInfo.HCPhoneNo = reader["HCPhoneNo"].ToString();
                    oSystemInfo.HCEmail = reader["HCEmail"].ToString();
                    if (reader["LastOperationDate"] != DBNull.Value)
                        oSystemInfo.LastOperationDate = (object)reader["LastOperationDate"];
                    else oSystemInfo.LastOperationDate = null;
                    if (reader["OperationDate"] != DBNull.Value)
                        oSystemInfo.OperationDate = (object)reader["OperationDate"];
                    else oSystemInfo.OperationDate = null;
                    if (reader["NextOperationDate"] != DBNull.Value)
                        oSystemInfo.NextOperationDate = (object)reader["NextOperationDate"];
                    else oSystemInfo.NextOperationDate = null;
                    if (reader["LastMonthEndDate"] != DBNull.Value)
                        oSystemInfo.LastMonthEndDate = (object)reader["LastMonthEndDate"];
                    else oSystemInfo.LastMonthEndDate = null;
                    if (reader["LastYearEndDate"] != DBNull.Value)
                        oSystemInfo.LastYearEndDate = (object)reader["LastYearEndDate"];
                    else oSystemInfo.LastYearEndDate = null;

                    oSystemInfo.CreatedBy = (int)reader["CreatedBy"];
                    oSystemInfo.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSystemInfo.IsActive = (int)reader["IsActive"];
                    oSystemInfo.VATRegistrationNo = reader["VATRegistrationNo"].ToString();

                    if (reader["HOStockUpdateDate"] != DBNull.Value)
                        oSystemInfo.HOStockUpdateDate = (object)reader["HOStockUpdateDate"];
                    else oSystemInfo.HOStockUpdateDate = null;

                    InnerList.Add(oSystemInfo);
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
        
    }
}

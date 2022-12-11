// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: April 17, 2014
// Time :  12:00 PM
// Description: Class for Showroom.
// Modify Person And Date: Md. Abdul Hakim (06-May-2014)
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

    public class Showroom
    {


        
        private int _nIsDepot;
        private int _nIsTDOutlet;
        private int _nMappedWarehouseID;
        private int _nNextConsumerCode;
        private int _nNextAdvancePaymentNo;
        private int _nNextDCSNo;
        private int _nNextUnsoldDefectiveNo;
        private int _nNextInvoiceNo;
        private int _nNextMoneyReceiptNo;
        private int _nNextVatChallanNo;
        private int _nNextWarrantyCardNo;
        private int _nNextRequisitionNo;
        private int _nNextISGMNo;
        private int _nNextReturnNo;
        private int _nNextSendToCSDNo;
        private int _nNextIVChallanNo;
        private int _nNextOfficeItemTranNo;
        private int _nNextIVChallanNoISGM;
        private int _nIsRTImplemented;


        public int IsDepot { get { return _nIsDepot; } set { _nIsDepot = value; } }
        public int IsTDOutlet { get { return _nIsTDOutlet; } set { _nIsTDOutlet = value; } }
        public int MappedWarehouseID { get { return _nMappedWarehouseID; } set { _nMappedWarehouseID = value; } }
        public int NextConsumerCode { get { return _nNextConsumerCode; } set { _nNextConsumerCode = value; } }
        public int NextAdvancePaymentNo { get { return _nNextAdvancePaymentNo; } set { _nNextAdvancePaymentNo = value; } }
        public int NextDCSNo { get { return _nNextDCSNo; } set { _nNextDCSNo = value; } }
        public int NextUnsoldDefectiveNo { get { return _nNextUnsoldDefectiveNo; } set { _nNextUnsoldDefectiveNo = value; } }
        public int NextInvoiceNo { get { return _nNextInvoiceNo; } set { _nNextInvoiceNo = value; } }
        public int NextMoneyReceiptNo { get { return _nNextMoneyReceiptNo; } set { _nNextMoneyReceiptNo = value; } }
        public int NextVatChallanNo { get { return _nNextVatChallanNo; } set { _nNextVatChallanNo = value; } }
        public int NextWarrantyCardNo { get { return _nNextWarrantyCardNo; } set { _nNextWarrantyCardNo = value; } }
        public int NextRequisitionNo { get { return _nNextRequisitionNo; } set { _nNextRequisitionNo = value; } }
        public int NextISGMNo { get { return _nNextISGMNo; } set { _nNextISGMNo = value; } }
        public int NextReturnNo { get { return _nNextReturnNo; } set { _nNextReturnNo = value; } }
        public int NextSendToCSDNo { get { return _nNextSendToCSDNo; } set { _nNextSendToCSDNo = value; } }
        public int NextIVChallanNo { get { return _nNextIVChallanNo; } set { _nNextIVChallanNo = value; } }
        public int NextOfficeItemTranNo { get { return _nNextOfficeItemTranNo; } set { _nNextOfficeItemTranNo = value; } }
        public int NextIVChallanNoISGM { get { return _nNextIVChallanNoISGM; } set { _nNextIVChallanNoISGM = value; } }
        public int IsRTImplemented { get { return _nIsRTImplemented; } set { _nIsRTImplemented = value; } }

        private int _nID;
        private int _nType;
        private double _Space;
        private double _RatePerSquareFeet;
        private double _Vat;
        private double _AdvanceAmount;
        private DateTime _dAgreementStartDate;
        private DateTime _dAgreementUpcomingRenewalDate;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private DateTime _dUpdateDate;
        private int _nUpdateUserID;
        private string _sOutletName;
        public string OutletName
        {
            get { return _sOutletName; }
            set { _sOutletName = value; }
        }

        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
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
        // Get set property for Space
        // </summary>
        public double Space
        {
            get { return _Space; }
            set { _Space = value; }
        }

        // <summary>
        // Get set property for RatePerSquareFeet
        // </summary>
        public double RatePerSquareFeet
        {
            get { return _RatePerSquareFeet; }
            set { _RatePerSquareFeet = value; }
        }

        // <summary>
        // Get set property for Vat
        // </summary>
        public double Vat
        {
            get { return _Vat; }
            set { _Vat = value; }
        }

        // <summary>
        // Get set property for AdvanceAmount
        // </summary>
        public double AdvanceAmount
        {
            get { return _AdvanceAmount; }
            set { _AdvanceAmount = value; }
        }

        // <summary>
        // Get set property for AgreementStartDate
        // </summary>
        public DateTime AgreementStartDate
        {
            get { return _dAgreementStartDate; }
            set { _dAgreementStartDate = value; }
        }

        // <summary>
        // Get set property for AgreementUpcomingRenewalDate
        // </summary>
        public DateTime AgreementUpcomingRenewalDate
        {
            get { return _dAgreementUpcomingRenewalDate; }
            set { _dAgreementUpcomingRenewalDate = value; }
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
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        } 



        private int _nShowroomID;
        private int _nPositionNo;
        private string _sShowroomCode;
        private string _sShowroomName;
        private int _nShowroomType;
        private string _sShowroomAddress;
        private string _sTelephone;
        private string _sEmail;
        private int _nWarehouseID;
        private int _nManagerID;
        private bool _bIsActive;
        private int _nDistanceType;
        private int _nCustomerID;
        private int _nChannelID;
        private string _sMobileNo;
        private int _nIsPOSActive;
        private string _sWarehouseName;
        private string _sCustomerName;
        private string _sDistrict;
        private string _sThana;
        private string _sLocationName;
        private int _nLocationID;
        private int _nReceivableDataCategory;
        private int _nReceivableDataType;
        private int _nThanaID;

        public int ShowroomID
        {
            get { return _nShowroomID; }
            set { _nShowroomID = value; }

        }
        public int PositionNo
        {
            get { return _nPositionNo; }
            set { _nPositionNo = value; }

        }
        public int LocationID
        {
            get { return _nLocationID; }
            set { _nLocationID = value; }

        }
        public int ThanaID
        {
            get { return _nThanaID; }
            set { _nThanaID = value; }

        }
        public int ReceivableDataCategory
        {
            get { return _nReceivableDataCategory; }
            set { _nReceivableDataCategory = value; }

        }
        public int ReceivableDataType
        {
            get { return _nReceivableDataType; }
            set { _nReceivableDataType = value; }

        }
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value; }

        }
        public string ShowroomName
        {
            get { return _sShowroomName; }
            set { _sShowroomName = value; }
        }
        public string WarehouseName
        {
            get { return _sWarehouseName; }
            set { _sWarehouseName = value; }
        }
        private string _sCustomerCode;
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
        public string District
        {
            get { return _sDistrict; }
            set { _sDistrict = value; }

        }
        public string Thana
        {
            get { return _sThana; }
            set { _sThana = value; }

        }
        public string LocationName
        {
            get { return _sLocationName; }
            set { _sLocationName = value; }

        }
        public int ShowroomType
        {
            get { return _nShowroomType; }
            set { _nShowroomType = value; }

        }
        public string ShowroomAddress
        {
            get { return _sShowroomAddress; }
            set { _sShowroomAddress = value; }
        }
        public string Telephone
        {
            get { return _sTelephone; }
            set { _sTelephone = value; }
        }
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value; }
        }
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }
        private int _WarehouseParentID;
        public int WarehouseParentID
        {
            get { return _WarehouseParentID; }
            set { _WarehouseParentID = value; }
        }
        public int ManagerID
        {
            get { return _nManagerID; }
            set { _nManagerID = value; }
        }
        public bool IsActive
        {
            get { return _bIsActive; }
            set { _bIsActive = value; }
        }
        public int DistanceType
        {
            get { return _nDistanceType; }
            set { _nDistanceType = value; }
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
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value; }
        }
        public int IsPOSActive
        {
            get { return _nIsPOSActive; }
            set { _nIsPOSActive = value; }
        }
        
        public void Add()//Hakim
        {
            int nMaxShowroomID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                if (_nShowroomID == 0)
                {
                    sSql = "SELECT MAX([ShowroomID]) FROM t_Showroom";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        nMaxShowroomID = 1;
                    }
                    else
                    {
                        nMaxShowroomID = Convert.ToInt32(maxID) + 1;
                    }
                    _nShowroomID = nMaxShowroomID;
                }

                sSql = "INSERT INTO t_Showroom(ShowroomID,PositionNo,ShowroomCode,ShowroomName,ShowroomType, "+
                       "ShowroomAddress,Telephone,Email,LocationID,WarehouseID,ManagerID,IsActive,DistanceType,CustomerID, " +
                       "ChannelID,MobileNo,IsPOSActive,ReceivableDataCategory,ReceivableDataType,ThanaID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ShowroomID", _nShowroomID);
                cmd.Parameters.AddWithValue("PositionNo", _nShowroomID);
                cmd.Parameters.AddWithValue("ShowroomCode", _sShowroomCode);
                cmd.Parameters.AddWithValue("ShowroomName", _sShowroomName);
                cmd.Parameters.AddWithValue("ShowroomType", _nShowroomType);
                cmd.Parameters.AddWithValue("ShowroomAddress", _sShowroomAddress);
                cmd.Parameters.AddWithValue("Telephone", _sTelephone);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ManagerID", _nManagerID);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);

                cmd.Parameters.AddWithValue("DistanceType", _nDistanceType);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ChannelID", _nChannelID);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("IsPOSActive", _nIsPOSActive);
                cmd.Parameters.AddWithValue("ReceivableDataCategory", _nReceivableDataCategory);
                cmd.Parameters.AddWithValue("ReceivableDataType", _nReceivableDataType);
                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Edit()//Hakim
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "UPDATE t_Showroom SET ShowroomCode=?,ShowroomName=?,ShowroomType=?, " +
                       "ShowroomAddress=?,Telephone=?,Email=?,LocationID=?,WarehouseID=?,ManagerID=?,IsActive=?,DistanceType=?,CustomerID=?, " +
                       "ChannelID=?,MobileNo=?,IsPOSActive=?,ThanaID=? WHERE ShowroomID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue("PositionNo", _nPositionNo);
                cmd.Parameters.AddWithValue("ShowroomCode", _sShowroomCode);
                cmd.Parameters.AddWithValue("ShowroomName", _sShowroomName);
                cmd.Parameters.AddWithValue("ShowroomType", _nShowroomType);
                cmd.Parameters.AddWithValue("ShowroomAddress", _sShowroomAddress);
                cmd.Parameters.AddWithValue("Telephone", _sTelephone);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ManagerID", _nManagerID);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);
                cmd.Parameters.AddWithValue("DistanceType", _nDistanceType);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ChannelID", _nChannelID);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("IsPOSActive", _nIsPOSActive);
                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);

                cmd.Parameters.AddWithValue("ShowroomID", _nShowroomID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdatePOSActive()//Hakim
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "UPDATE t_Showroom SET IsPOSActive=? WHERE WarehouseID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsPOSActive", _nIsPOSActive);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

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
                sSql = "DELETE FROM t_Showroom WHERE [ShowroomID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ShowroomID", _nShowroomID);
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
                cmd.CommandText = "SELECT * FROM t_Showroom where ShowroomID=? ";
                cmd.Parameters.AddWithValue("ShowroomID", _nShowroomID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nShowroomID = (int)reader["ShowroomID"];
                    _nPositionNo = (int)reader["PositionNo"];
                    _sShowroomCode = (string)reader["ShowroomCode"];
                    _sShowroomName = (string)reader["ShowroomName"];
                    _nShowroomType = (int)reader["ShowroomType"];

                    if (reader["ShowroomAddress"] != DBNull.Value)
                        _sShowroomAddress = (string)reader["ShowroomAddress"];
                    else _sShowroomAddress = "";

                    if (reader["Telephone"] != DBNull.Value)
                        _sTelephone = (string)reader["Telephone"];
                    else _sTelephone = "";

                    if (reader["Email"] != DBNull.Value)
                        _sEmail = (string)reader["Email"];
                    else _sEmail = "";

                    _nWarehouseID = (int)reader["WarehouseID"];

                    if (reader["ManagerID"] != DBNull.Value)
                        _nManagerID = (int)reader["ManagerID"];
                    else _nManagerID = 0;
                    _bIsActive = Convert.ToBoolean(reader["IsActive"]);
                    _nDistanceType = (int)reader["DistanceType"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _nChannelID=(int)reader["ChannelID"];
                    _sMobileNo = (string)reader["MobileNo"];
                    _nIsPOSActive = (int)reader["IsPOSActive"];
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool RefreshForRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_Showroom where WarehouseID=? ";
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nShowroomID = (int)reader["ShowroomID"];
                    _nPositionNo = (int)reader["PositionNo"];
                    _sShowroomCode = (string)reader["ShowroomCode"];
                    _sShowroomName = (string)reader["ShowroomName"];
                    _nShowroomType = (int)reader["ShowroomType"];

                    if (reader["ShowroomAddress"] != DBNull.Value)
                        _sShowroomAddress = (string)reader["ShowroomAddress"];
                    else _sShowroomAddress = "";

                    if (reader["Telephone"] != DBNull.Value)
                        _sTelephone = (string)reader["Telephone"];
                    else _sTelephone = "";

                    if (reader["Email"] != DBNull.Value)
                        _sEmail = (string)reader["Email"];
                    else _sEmail = "";

                    _nWarehouseID = (int)reader["WarehouseID"];

                    if (reader["ManagerID"] != DBNull.Value)
                        _nManagerID = (int)reader["ManagerID"];
                    else _nManagerID = 0;
                    _bIsActive = Convert.ToBoolean(reader["IsActive"]);
                    _nDistanceType = (int)reader["DistanceType"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _nChannelID = (int)reader["ChannelID"];
                    _sMobileNo = (string)reader["MobileNo"];
                    _nIsPOSActive = (int)reader["IsPOSActive"];



                    if (reader["ThanaID"] != DBNull.Value)
                        _nThanaID = (int)reader["ThanaID"];
                    else _nThanaID = 0;

                    if (reader["IsDepot"] != DBNull.Value)
                        _nIsDepot = (int)reader["IsDepot"];
                    else _nIsDepot = 0;

                    if (reader["IsTDOutlet"] != DBNull.Value)
                        _nIsTDOutlet = (int)reader["IsTDOutlet"];
                    else _nIsTDOutlet = 0;


                    if (reader["MappedWarehouseID"] != DBNull.Value)
                        _nMappedWarehouseID = Convert.ToInt32(reader["MappedWarehouseID"]);
                    else _nMappedWarehouseID = 0;

                    if (reader["NextConsumerCode"] != DBNull.Value)
                        _nNextConsumerCode = Convert.ToInt32(reader["NextConsumerCode"]);
                    else _nNextConsumerCode = 0;

                    if (reader["NextAdvancePaymentNo"] != DBNull.Value)
                        _nNextAdvancePaymentNo = Convert.ToInt32(reader["NextAdvancePaymentNo"]);
                    else _nNextAdvancePaymentNo = 0;


                    if (reader["NextDCSNo"] != DBNull.Value)
                        _nNextDCSNo = Convert.ToInt32(reader["NextDCSNo"]);
                    else _nNextDCSNo = 0;



                    if (reader["NextUnsoldDefectiveNo"] != DBNull.Value)
                        _nNextUnsoldDefectiveNo = Convert.ToInt32(reader["NextUnsoldDefectiveNo"]);
                    else _nNextUnsoldDefectiveNo = 0;


                    if (reader["NextInvoiceNo"] != DBNull.Value)
                        _nNextInvoiceNo = Convert.ToInt32(reader["NextInvoiceNo"]);
                    else _nNextInvoiceNo = 0;


                    if (reader["NextMoneyReceiptNo"] != DBNull.Value)
                        _nNextMoneyReceiptNo = Convert.ToInt32(reader["NextMoneyReceiptNo"]);
                    else _nNextMoneyReceiptNo = 0;


                    if (reader["NextVatChallanNo"] != DBNull.Value)
                        _nNextVatChallanNo = Convert.ToInt32(reader["NextVatChallanNo"]);
                    else _nNextVatChallanNo  = 0;


                    if (reader["NextWarrantyCardNo"] != DBNull.Value)
                        _nNextWarrantyCardNo = Convert.ToInt32(reader["NextWarrantyCardNo"]);
                    else _nNextWarrantyCardNo = 0;




                    if (reader["NextISGMNo"] != DBNull.Value)
                        _nNextISGMNo = Convert.ToInt32(reader["NextISGMNo"]);
                    else _nNextISGMNo = 0;


                    if (reader["NextReturnNo"] != DBNull.Value)
                        _nNextReturnNo = Convert.ToInt32(reader["NextReturnNo"]);
                    else _nNextReturnNo = 0;

                    if (reader["NextSendToCSDNo"] != DBNull.Value)
                        _nNextSendToCSDNo = Convert.ToInt32(reader["NextSendToCSDNo"]);
                    else _nNextSendToCSDNo = 0;

                    if (reader["NextIVChallanNo"] != DBNull.Value)
                        _nNextIVChallanNo = Convert.ToInt32(reader["NextIVChallanNo"]);
                    else _nNextIVChallanNo = 0;

                    if (reader["NextOfficeItemTranNo"] != DBNull.Value)
                        _nNextOfficeItemTranNo = Convert.ToInt32(reader["NextOfficeItemTranNo"]);
                    else _nNextOfficeItemTranNo = 0;

                    if (reader["NextIVChallanNoISGM"] != DBNull.Value)
                        _nNextIVChallanNoISGM = Convert.ToInt32(reader["NextIVChallanNoISGM"]);
                    else _nNextIVChallanNoISGM = 0;

                    if (reader["IsRTImplemented"] != DBNull.Value)
                        _nIsRTImplemented = Convert.ToInt32(reader["IsRTImplemented"]);
                    else _nIsRTImplemented = 0;

                    if (_nIsRTImplemented != 0)
                    {
                        nCount++;
                    }
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

        public int GetNextAPNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nNextAPNo = 0;
            try
            {
                sSql = "select NextAdvancePaymentNo from t_Showroom a, [dbo].[t_UserMapForPOS] b Where a.WarehouseID = b.WarehouseId and b.UserId =" + Utility.UserId;

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nNextAPNo = int.Parse(reader["NextAdvancePaymentNo"].ToString());
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nNextAPNo;

        }


        public int GetNextTranNo(string sFieldName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nNextTranNo = 0;
            try
            {
                sSql = "select " + sFieldName + " from t_Showroom  where WarehouseID =" + Utility.WarehouseID;

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nNextTranNo = int.Parse(reader["" + sFieldName + ""].ToString());
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nNextTranNo;

        }

        public void GetOutletExpensesForEdit(int nWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * From t_OutletExpenses where Type=1 and WHID=" + nWHID + "";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sOutletName = (string)reader["Name"];
                    _Space = (double)reader["Space"];
                    _RatePerSquareFeet = (double)reader["RatePerSquareFeet"];
                    _Vat = (double)reader["Vat"];
                    _AdvanceAmount = (double)reader["AdvanceAmount"];
                    _dAgreementStartDate = (DateTime)reader["AgreementStartDate"];
                    _dAgreementUpcomingRenewalDate = (DateTime)reader["AgreementUpcomingRenewalDate"];
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetWHIDByCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_Showroom where ShowroomCode = ?";
                cmd.Parameters.AddWithValue("ShiowroomCode", _sShowroomCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nShowroomID = (int)reader["ShowroomID"];
                    _nPositionNo = (int)reader["PositionNo"];
                    _sShowroomCode = (string)reader["ShowroomCode"];
                    _sShowroomName = (string)reader["ShowroomName"];
                    _nShowroomType = (int)reader["ShowroomType"];

                    if (reader["ShowroomAddress"] != DBNull.Value)
                        _sShowroomAddress = (string)reader["ShowroomAddress"];
                    else _sShowroomAddress = "";

                    if (reader["Telephone"] != DBNull.Value)
                        _sTelephone = (string)reader["Telephone"];
                    else _sTelephone = "";

                    if (reader["Email"] != DBNull.Value)
                        _sEmail = (string)reader["Email"];
                    else _sEmail = "";

                    _nWarehouseID = (int)reader["WarehouseID"];

                    _bIsActive = Convert.ToBoolean(reader["IsActive"]);
                    _nDistanceType = (int)reader["DistanceType"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _nChannelID = (int)reader["ChannelID"];
                    _sMobileNo = (string)reader["MobileNo"];
                    _nIsPOSActive = (int)reader["IsPOSActive"];
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetShowroomByCustID(int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_Showroom where CustomerID =?";
                cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nShowroomID = (int)reader["ShowroomID"];
                    _nPositionNo = (int)reader["PositionNo"];
                    _sShowroomCode = (string)reader["ShowroomCode"];
                    _sShowroomName = (string)reader["ShowroomName"];
                    _nShowroomType = (int)reader["ShowroomType"];

                    if (reader["ShowroomAddress"] != DBNull.Value)
                        _sShowroomAddress = (string)reader["ShowroomAddress"];
                    else _sShowroomAddress = "";

                    if (reader["Telephone"] != DBNull.Value)
                        _sTelephone = (string)reader["Telephone"];
                    else _sTelephone = "";

                    if (reader["Email"] != DBNull.Value)
                        _sEmail = (string)reader["Email"];
                    else _sEmail = "";

                    _nWarehouseID = (int)reader["WarehouseID"];

                    if (reader["ManagerID"] != DBNull.Value)
                        _nManagerID = (int)reader["ManagerID"];
                    else _nManagerID = 0;
                    _bIsActive = Convert.ToBoolean(reader["IsActive"]);
                    _nCustomerID = (int)reader["CustomerID"];
                    _nChannelID = (int)reader["ChannelID"];
                    _sMobileNo = (string)reader["MobileNo"];
                    _nIsPOSActive = (int)reader["IsPOSActive"];
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetShowroomByCode(string sShowroomCode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_Showroom where ShowroomCode =?";
                cmd.Parameters.AddWithValue("ShowroomCode", sShowroomCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nShowroomID = (int)reader["ShowroomID"];
                    _nPositionNo = (int)reader["PositionNo"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _sShowroomCode = (string)reader["ShowroomCode"];
                    _sShowroomName = (string)reader["ShowroomName"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _nIsPOSActive = (int)reader["IsPOSActive"];
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetShowroomID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_Showroom where WarehouseID =?";
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nShowroomID = (int)reader["ShowroomID"];
                    _sShowroomCode = (string)reader["ShowroomCode"];
                    _sShowroomName = (string)reader["ShowroomName"];
                    _nChannelID = (int)reader["ChannelID"];
                    _nCustomerID = (int)reader["CustomerID"];
                    
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetShowroomByCustomerID(int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = " Select * From t_Showroom where CustomerID = ?";

                cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nCustomerID = (int)reader["CustomerID"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public int GetWarehouseIDByCustomer(int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nWarehouseID = 0;
            int nCount = 0;

            cmd.CommandText = "Select WarehouseID From dbo.t_Customer a,t_Showroom b where a.ParentCustomerID=b.CustomerID and a.CustomerID=" + nCustomerID + "";

            try
            {
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nWarehouseID = (int)reader["WarehouseID"];
                    nCount++;
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            return nWarehouseID;


        }


        public int GetExpensesData(int nWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select Count(ID) Count From t_OutletExpenses where WHID=" + nWHID + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount = (int)reader["Count"];

                }
                reader.Close();
                return nCount;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int GetMappedWH(int nWHID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nMappedWarehouseID = 0;
            try
            {
                cmd.CommandText = "Select MappedWarehouseID From t_Showroom where WarehouseID=" + nWHID + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nMappedWarehouseID = Convert.ToInt32(reader["MappedWarehouseID"]);

                }
                reader.Close();
                return nMappedWarehouseID;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddOutletExpenses()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_OutletExpenses";
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
                sSql = "INSERT INTO t_OutletExpenses (ID, WHID,Name, Type, Space, RatePerSquareFeet, Vat, AdvanceAmount, AgreementStartDate, AgreementUpcomingRenewalDate, CreateDate, CreateUserID, UpdateDate, UpdateUserID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("WHID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Name", _sOutletName);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("Space", _Space);
                cmd.Parameters.AddWithValue("RatePerSquareFeet", _RatePerSquareFeet);
                cmd.Parameters.AddWithValue("Vat", _Vat);
                cmd.Parameters.AddWithValue("AdvanceAmount", _AdvanceAmount);
                cmd.Parameters.AddWithValue("AgreementStartDate", _dAgreementStartDate);
                cmd.Parameters.AddWithValue("AgreementUpcomingRenewalDate", _dAgreementUpcomingRenewalDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditOutletExpenses()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OutletExpenses SET WHID = ?, Type = ?, Space = ?, RatePerSquareFeet = ?, Vat = ?, AdvanceAmount = ?, AgreementStartDate = ?, AgreementUpcomingRenewalDate = ?, CreateDate = ?, CreateUserID = ?, UpdateDate = ?, UpdateUserID = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WHID", _nWarehouseID);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("Space", _Space);
                cmd.Parameters.AddWithValue("RatePerSquareFeet", _RatePerSquareFeet);
                cmd.Parameters.AddWithValue("Vat", _Vat);
                cmd.Parameters.AddWithValue("AdvanceAmount", _AdvanceAmount);
                cmd.Parameters.AddWithValue("AgreementStartDate", _dAgreementStartDate);
                cmd.Parameters.AddWithValue("AgreementUpcomingRenewalDate", _dAgreementUpcomingRenewalDate);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DeleteOutletExpence()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_OutletExpenses WHERE [WHID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WHID", _nWarehouseID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }


    public class Showrooms : CollectionBaseCustom
    {

        public Showroom this[int i]
        {
            get { return (Showroom)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Showroom oShowroom)
        {
            InnerList.Add(oShowroom);
        }

        public int GetIndex(int nShowroomID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ShowroomID == nShowroomID)
                {
                    return i;
                }
            }
            return -1;
        }
        public int GetIndexWHID(int nWarehouseID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].WarehouseID == nWarehouseID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh()
        {
            Showroom oShowroom;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Showroom Where IsActive=? and IsPOSActive=? order by ShowroomCode ";
            cmd.Parameters.AddWithValue("IsActive", (int)Dictionary.YesOrNoStatus.YES);
            cmd.Parameters.AddWithValue("IsPOSActive", (int)Dictionary.YesOrNoStatus.YES);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    oShowroom = new Showroom();
                    oShowroom.ShowroomID = (int)reader["ShowroomID"];
                    oShowroom.CustomerID = (int)reader["CustomerID"];
                    oShowroom.ShowroomCode = (string)reader["ShowroomCode"];
                    oShowroom.ShowroomName = (string)reader["ShowroomName"];
                    oShowroom.ShowroomAddress = (string)reader["ShowroomAddress"];
                    oShowroom.WarehouseID = (int)reader["WarehouseID"];
                    oShowroom.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    oShowroom.LocationID = (int)reader["LocationID"];
                    InnerList.Add(oShowroom);
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
        public void GetShowroom(int nWarehouseID)
        {
            Showroom oShowroom;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Showroom Where IsActive=? and IsPOSActive=? and WarehouseID = ? ";
            cmd.Parameters.AddWithValue("IsActive", (int)Dictionary.YesOrNoStatus.YES);
            cmd.Parameters.AddWithValue("IsPOSActive", (int)Dictionary.YesOrNoStatus.YES);
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    oShowroom = new Showroom();
                    oShowroom.ShowroomID = (int)reader["ShowroomID"];
                    oShowroom.ShowroomCode = (string)reader["ShowroomCode"];
                    oShowroom.ShowroomName = (string)reader["ShowroomName"];
                    oShowroom.ShowroomAddress = (string)reader["ShowroomAddress"];
                    oShowroom.WarehouseID = (int)reader["WarehouseID"];
                    oShowroom.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    InnerList.Add(oShowroom);
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
        public void GetShowroomByJobLocation()
        {
            Showroom oShowroom;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select JobLocationID,isnull(showroomCode,Joblocationname) as ShowroomName from t_JobLocation a left outer join t_showroom b on(a.JobLocationID = b.LocationID) ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    oShowroom = new Showroom();
                    oShowroom.LocationID = (int)reader["JobLocationID"];
                    oShowroom.ShowroomName = (string)reader["ShowroomName"];
                    InnerList.Add(oShowroom);
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
        public void GetAllShowroom()//Hakim
        {
            Showroom oShowroom;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Showroom where IsActive=1 order by ShowroomCode";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    oShowroom = new Showroom();

                    oShowroom.ShowroomID = (int)reader["ShowroomID"];
                    oShowroom.PositionNo = (int)reader["PositionNo"];
                    oShowroom.ShowroomCode = (string)reader["ShowroomCode"];
                    oShowroom.ShowroomName = (string)reader["ShowroomName"];
                    oShowroom.ShowroomType = (int)reader["ShowroomType"];

                    if (reader["ShowroomAddress"] != DBNull.Value)
                        oShowroom.ShowroomAddress = (string)reader["ShowroomAddress"];
                    else oShowroom.ShowroomAddress = "";

                    if (reader["Telephone"] != DBNull.Value)
                        oShowroom.Telephone = (string)reader["Telephone"];
                    else oShowroom.Telephone = "";

                    if (reader["Email"] != DBNull.Value)
                        oShowroom.Email = (string)reader["Email"];
                    else oShowroom.Email = "";

                    oShowroom.WarehouseID = (int)reader["WarehouseID"];

                    if (reader["ManagerID"] != DBNull.Value)
                        oShowroom.ManagerID = (int)reader["ManagerID"];
                    else oShowroom.ManagerID = 0;
                    oShowroom.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    oShowroom.DistanceType = (int)reader["DistanceType"];
                    oShowroom.CustomerID = (int)reader["CustomerID"];
                    oShowroom.ChannelID = (int)reader["ChannelID"];
                    oShowroom.MobileNo = (string)reader["MobileNo"];
                    oShowroom.IsPOSActive = (int)reader["IsPOSActive"];


                    InnerList.Add(oShowroom);
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

        public void GetWarehouseForVat()
        {
            Showroom oShowroom;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.WarehouseID,ShowroomCode,ShowroomName,WarehouseParentID From t_Showroom a,t_Warehouse b  " +
                        "where a.WarehouseID = b.WarehouseID  " +
                        "Union All  " +
                        "Select WarehouseID, isnull(ShortCode,'') ShowroomCode,WarehouseName ShowroomName, WarehouseParentID From t_Warehouse where WarehouseParentID = 6  " +
                        "Union All Select -1,'CW' ShowroomCode,'Central Warehouse' ShowroomName,-1 WarehouseParentID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    oShowroom = new Showroom();

                    oShowroom.WarehouseParentID = (int)reader["WarehouseParentID"];
                    oShowroom.WarehouseID = (int)reader["WarehouseID"];
                    oShowroom.ShowroomCode = (string)reader["ShowroomCode"];
                    oShowroom.ShowroomName = (string)reader["ShowroomName"];
                    
                    

                    InnerList.Add(oShowroom);
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

        public void GetShowroomByName(string sCode, string sCustomerName)
        {
            Showroom oShowroom;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "SELECT * FROM t_Showroom a,t_Warehouse b,t_Customer c where a.WarehouseID=b.WarehouseID and a.CustomerID=c.CustomerID and a.IsActive=1 and 1=1";
            string sSql = @"SELECT a.*,CustomerName,WarehouseName,e.GeoLocationName as District,d.GeoLocationName as Thana,JobLocationName
                            FROM t_Showroom a,t_Warehouse b,t_Customer c, t_GeoLocation d,t_GeoLocation e,t_JobLocation f
                            where a.WarehouseID=b.WarehouseID and a.CustomerID=c.CustomerID and a.ThanaID=d.GeoLocationID
                            and a.LocationID=f.JobLocationID and d.ParentID=e.GeoLocationID and a.IsActive=1 and 1=1 ";

            if (sCode != "")
            {
                sSql = sSql + " AND ShowroomCode = '" + sCode + "'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND CustomerName like '%" + sCustomerName + "%'";
            }
            //if (nIsActive != -1)
            //{
            //    sSql = sSql + " AND IsPOSActive=" + nIsActive + "";
            //}
            sSql = sSql + " Order by ShowroomCode";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    oShowroom = new Showroom();

                    oShowroom.ShowroomID = (int)reader["ShowroomID"];
                    oShowroom.PositionNo = (int)reader["PositionNo"];
                    oShowroom.ShowroomCode = (string)reader["ShowroomCode"];
                    oShowroom.ShowroomName = (string)reader["ShowroomName"];
                    oShowroom.ShowroomType = (int)reader["ShowroomType"];

                    if (reader["ShowroomAddress"] != DBNull.Value)
                        oShowroom.ShowroomAddress = (string)reader["ShowroomAddress"];
                    else oShowroom.ShowroomAddress = "";

                    if (reader["Telephone"] != DBNull.Value)
                        oShowroom.Telephone = (string)reader["Telephone"];
                    else oShowroom.Telephone = "";

                    if (reader["Email"] != DBNull.Value)
                        oShowroom.Email = (string)reader["Email"];
                    else oShowroom.Email = "";

                    oShowroom.WarehouseID = (int)reader["WarehouseID"];

                    if (reader["ManagerID"] != DBNull.Value)
                        oShowroom.ManagerID = (int)reader["ManagerID"];
                    else oShowroom.ManagerID = 0;
                    oShowroom.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    oShowroom.DistanceType = (int)reader["DistanceType"];
                    oShowroom.CustomerID = (int)reader["CustomerID"];
                    oShowroom.ChannelID = (int)reader["ChannelID"];
                    oShowroom.MobileNo = (string)reader["MobileNo"];
                    oShowroom.IsPOSActive = (int)reader["IsPOSActive"];
                    oShowroom.WarehouseName= (string)reader["WarehouseName"];
                    oShowroom.CustomerName= (string)reader["CustomerName"];
                    oShowroom.District = (string)reader["District"];
                    oShowroom.Thana = (string)reader["Thana"];
                    oShowroom.LocationID = (int)reader["LocationID"];
                    oShowroom.ThanaID= (int)reader["ThanaID"];
                    oShowroom.LocationName = (string)reader["JobLocationName"];


                    InnerList.Add(oShowroom);
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

        public void RefreshForTarget(string sTableName, int nVersionNo) 
        {
            Showroom oShowroom;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select WarehouseID From " + sTableName + " a,t_Showroom b " +
                          " where a.CustomerID=b.CustomerID and IsPOSActive=1 and  " +
                          " VersionNo=" + nVersionNo + " group by WarehouseID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    oShowroom = new Showroom();
                    oShowroom.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(oShowroom);
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

        public void GetShowroomForISGM(int nWarehouseID)
        {
            Showroom oShowroom;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Showroom Where IsActive=? and IsPOSActive=? and WarehouseID <> ?";
            cmd.Parameters.AddWithValue("IsActive", (int)Dictionary.YesOrNoStatus.YES);
            cmd.Parameters.AddWithValue("IsPOSActive", (int)Dictionary.YesOrNoStatus.YES);
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    oShowroom = new Showroom();
                    oShowroom.ShowroomID = (int)reader["ShowroomID"];
                    oShowroom.ShowroomCode = (string)reader["ShowroomCode"];
                    oShowroom.ShowroomName = (string)reader["ShowroomName"];
                    oShowroom.ShowroomAddress = (string)reader["ShowroomAddress"];
                    oShowroom.WarehouseID = (int)reader["WarehouseID"];
                    oShowroom.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    InnerList.Add(oShowroom);
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
        public void GetOutletExpense(int nWarehouseID)
        {
            Showroom oShowroom;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            {
                sSql = "Select * From  " +
                           "( " +
                           "Select ShowroomCode,WHID,sum(Space) Space, " +
                           "sum(RatePerSquareFeet) RatePerSquareFeet, " +
                           "sum(Vat) Vat, " +
                           "sum(AdvanceAmount) AdvanceAmount " +
                           "From t_OutletExpenses a,t_Showroom b " +
                           "where a.WHID=b.WarehouseID  " +
                           "group by ShowroomCode,WHID " +
                           ") Main where 1=1";
            }
            if (nWarehouseID != -1)
            {
                sSql = sSql + " and WHID=" + nWarehouseID + "";
            }
            

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    oShowroom = new Showroom();
                    oShowroom.ShowroomCode = (string)reader["ShowroomCode"];
                    oShowroom.WarehouseID = (int)reader["WHID"];
                    oShowroom.Space = Convert.ToDouble(reader["Space"]);
                    oShowroom.RatePerSquareFeet = Convert.ToDouble(reader["RatePerSquareFeet"]);
                    oShowroom.Vat = Convert.ToDouble(reader["Vat"]);
                    oShowroom.AdvanceAmount = Convert.ToDouble(reader["AdvanceAmount"]);
                    InnerList.Add(oShowroom);
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
        public void GetOutletExpenseForEdit(int nWHID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select * From t_OutletExpenses where Type=2 and WHID=" + nWHID + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Showroom oItem = new Showroom();

                    oItem.OutletName = (reader["Name"].ToString());
                    oItem.Space = Convert.ToDouble(reader["Space"].ToString());
                    oItem.RatePerSquareFeet = Convert.ToDouble(reader["RatePerSquareFeet"].ToString());
                    oItem.Vat = Convert.ToDouble(reader["Vat"].ToString());
                    oItem.AdvanceAmount = Convert.ToDouble(reader["AdvanceAmount"].ToString());
                    oItem.AgreementStartDate = Convert.ToDateTime(reader["AgreementStartDate"].ToString());
                    oItem.AgreementUpcomingRenewalDate = Convert.ToDateTime(reader["AgreementUpcomingRenewalDate"].ToString());

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

        public void RefreshHO()
        {
            Showroom oShowroom;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT a.*,CustomerCode,CustomerName FROM t_Showroom a,t_Customer b Where a.CustomerID=b.CustomerID and a.IsActive=? and a.IsPOSActive=? order by ShowroomCode ";
            cmd.Parameters.AddWithValue("IsActive", (int)Dictionary.YesOrNoStatus.YES);
            cmd.Parameters.AddWithValue("IsPOSActive", (int)Dictionary.YesOrNoStatus.YES);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    oShowroom = new Showroom();
                    oShowroom.ShowroomID = (int)reader["ShowroomID"];
                    oShowroom.CustomerID = (int)reader["CustomerID"];
                    oShowroom.ShowroomCode = (string)reader["ShowroomCode"];
                    oShowroom.ShowroomName = (string)reader["ShowroomName"];
                    oShowroom.ShowroomAddress = (string)reader["ShowroomAddress"];
                    oShowroom.WarehouseID = (int)reader["WarehouseID"];
                    oShowroom.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    oShowroom.LocationID = (int)reader["LocationID"];
                    oShowroom.CustomerCode = (string)reader["CustomerCode"];
                    oShowroom.CustomerName = (string)reader["CustomerName"];
                    InnerList.Add(oShowroom);
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

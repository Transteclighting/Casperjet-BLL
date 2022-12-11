// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: May 22, 2011
// Time :  02:00 PM
// Description: Class for Sales Order.
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;


namespace CJ.Class.Report
{
    public class rptSalesInvoiceDetail 
    {
        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
        private double _Quantity;
        private  string _sLUOM;
        private string _sSUOM;
        private double _UOMConversionFactor;
        private int _nFreeQty;       
        private long _LSRatio;
        private int _nProductTypeID;
        private double _UnitPrice;
        private  double _AdjustedDPAmount;
        private double _AdjustedTPAmount;
        private  double _AdjustedPWAmount;
        private double _TradePrice;
        private double _VATAmount;
        private int _nIsFreeProduct;
        private string _sCopy;
        private string _sBarcode;
        private string _sFreeProductBarcode;
        private double _PromotionalDiscount;

        private string _sItemCode;
        private string _sItemName;
        private double _ItemQty;

        private double _GrossAmount;
        private double _NetAmount;

        private double _TotalQty;

        public double TotalQty
        {
            get { return _TotalQty; }
            set { _TotalQty = value; }
        }

        public double GrossAmount
        {
            get { return _GrossAmount; }
            set { _GrossAmount = value; }
        }
        public double NetAmount
        {
            get { return _NetAmount; }
            set { _NetAmount = value; }
        }

        private string _sProductDesc;
        public string ProductDesc
        {
            get { return _sProductDesc; }
            set { _sProductDesc = value; }
        }
        private string _sProductModel;
        public string ProductModel
        {
            get { return _sProductModel; }
            set { _sProductModel = value; }
        }

        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        public double Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public string LUOM
        {
            get { return _sLUOM; }
            set { _sLUOM = value; }
        }
        public string SUOM
        {
            get { return _sSUOM; }
            set { _sSUOM = value; }
        }
        public double UOMConversionFactor
        {
            get { return _UOMConversionFactor; }
            set { _UOMConversionFactor = value; }
        }
        public int FreeQty
        {
            get { return _nFreeQty; }
            set { _nFreeQty = value; }
        }
        public long LSRatio
        {
            get { return _LSRatio; }
            set { _LSRatio = value; }
        }
        public int ProductTypeID
        {
            get { return _nProductTypeID; }
            set { _nProductTypeID = value; }
        }
        public double AdjustedTPAmount
        {
            get { return _AdjustedTPAmount; }
            set { _AdjustedTPAmount = value; }
        }
        public double AdjustedDPAmount
        {
            get { return _AdjustedDPAmount; }
            set { _AdjustedDPAmount = value; }
        }
        public double AdjustedPWAmount
        {
            get { return _AdjustedPWAmount; }
            set { _AdjustedPWAmount = value; }
        }
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
        public double TradePrice
        {
            get { return _TradePrice; }
            set { _TradePrice = value; }
        }
        public double VATAmount
        {
            get { return _VATAmount; }
            set { _VATAmount = value; }
        }
        public string Copy
        {
            get { return _sCopy; }
            set { _sCopy = value; }
        }
        public string Barcode
        {
            get { return _sBarcode; }
            set { _sBarcode = value; }
        }
        public string ItemCode
        {
            get { return _sItemCode; }
            set { _sItemCode = value; }
        }
        public string ItemName
        {
            get { return _sItemName; }
            set { _sItemName = value; }
        }
        public double ItemQty
        {
            get { return _ItemQty; }
            set { _ItemQty = value; }
        }
        public int IsFreeProduct
        {
            get { return _nIsFreeProduct; }
            set { _nIsFreeProduct = value; }
        }
        public string FreeProductBarcode
        {
            get { return _sFreeProductBarcode; }
            set { _sFreeProductBarcode = value; }
        }
        public double PromotionalDiscount
        {
            get { return _PromotionalDiscount; }
            set { _PromotionalDiscount = value; }
        }

        private string _sInboxItemName;
        public string InboxItemName
        {
            get { return _sInboxItemName; }
            set { _sInboxItemName = value; }
        }
        private string _sIMEI;
        public string IMEI
        {
            get { return _sIMEI; }
            set { _sIMEI = value; }
        }
      
    }
    public class rptSalesInvoice : CollectionBase
    {
        private long _InvoiceID;
        private int _nInvoiceTypeID;
        private string _sCustomerName;
        private string _sTaxNo;
        private string _sCustomerAddress;
        private string _sDeliveryAddress;
        private string _sWarehouseName;
        private string _sWarehouseAddress;
        private string _sWarehouseCode;
        private string _sInvoiceNo;
        private DateTime _dInvoiceDate;
        private string _sOrderNo;
        private string _sOrderConfirmedBy;

        private double _Receivable;
        private double _Age30;
        private double _Age60;
        private double _Above60Day;
        public string WarehouseAddress
        {
            get { return _sWarehouseAddress; }
            set { _sWarehouseAddress = value; }
        }
        public string ShowRoomName
        {
            get { return _ShowRoomName; }
            set { _ShowRoomName = value; }
        }
        public string ShowRoomCode
        {
            get { return _ShowRoomCode; }
            set { _ShowRoomCode = value; }
        }
        private string _ActualInvoiceNo;
        private DateTime _InvoiceDate;
        private int _CustomerID;
        private string _DeliveryAddress;
        private long _SalesPersonID;
        private string _SalesPersonName;
        private short _InvoiceStatus;
        private string _Remarks;
        private long _UpdateUserID;
        private string _UpdateUserName;
        private DateTime _CreateDate;
        private DateTime _UpdateDate;
        private long _CreateUserID;
        private double _InvoiceAmount;
        private string _InvoiceAmountInWord;
        private double _Discount;
        private long _OrderID;
        private short _InvoiceTypeID;
        private string _InvoiceTypeName;
        private short _PriceOptionID;
        private long _VATChallanNo;
        private string _CustomerCode;                       
        private long _DeliveredBy;
        private DateTime _DeliveryDate;
        private long _ChannelID;
        private long _LastChannelID;
        private string _CustomerTelephone;
        private string _CustomerFax;
        private string _CellPhoneNo;
        private string _EMailAddress;
        private string _ContactPerson;
        private string _ContactDesignation;
        private long _IsActive;
        private long _WarehouseID;
        private string _NationalID;
        private long _LastWarehouseID;
        private long _SBUID;
        private string _SBUCode;
        private string _SBUName;
        private long _TerritoryID;
        private string _TerritoryCode;
        private string _TerritoryName;
        private long _AreaID;
        private string _AreaCode;
        private string _AreaName;
        private long _DistrictID;
        private string _DistrictCode;
        private string _DistrictName;
        private long _ThanaID;
        private string _ThanaCode;
        private string _ThanaName;
        private string _ChannelCode;
        private string _ChannelName;
        private long _CustTypeID;
        private string _CustTypeCode;
        private string _CustTypeName;
        private long _ShowRoomID;
        private string _ShowRoomCode;
        private string _ShowRoomName;
        private string _DeliveredByName;
        private string _InvoiceByName;
        private long _InvoiceBy;                      
        private DateTime _OrderDate;
        private string _RefInvoiceID;
        private long _OrderReceivedByID;
        private string _sRefInvoiceNo;
        private DateTime _RefInvoiceDate;
        private string _OrderReceivedByName;
        private string _OrderConfirmeddByName;
        private long _OrderConfirmedByID;                    
        private string _InvoicePrintByString;
        private int _InvoicePrintCounter;
        private string _InvoicePrintWorkStation;                     
        private string _InvoiceHeader;
        private double _DueAmount;
        private string _InvoiceStatusName;
        private string _SundryCustomerName;
        private string _SCAddress;
        private string _SCPhoneNo;
        private string _SCCellNo;
        private string _SCEmail;
        private int _nWebInvoiceNo;
        private string _RefDetails;
        private long _ParentCustomerID;
        private string _ParentCustomerCode;
        private string _ParentCustomerName;
        private double _OtherCharge;
        private string _SundryCustomerCode;
        private long _SundryCustomerID;
        private short _RowStatus;
        private short _UploadStatus;
        private DateTime _UploadDate;
        private DateTime _DownloadDate;
        private short _InvoiceProcessFlow;
        private short _Terminal;
        private int _SalesPromotionID;
        private double _CustomerBalance;
        private string _sWarehouseShortcode;

        private string _sEPSCustomerCode;
        private string _sEmployeeCode;
        private string _sEmployeeName;
        private string _sDesignation;
        private string _sEmployeeAddress;
        private string _sPhoneNo;
        private string _sEPSDeliveryWHName;
        private int _nNoOfInstallment;

        private int _nPackQty;
        private double _QtyAmount;
        private string _sProductCode;
        private string _sProductName;
        private string _sUOM;
        private double _UnitPrice;
        private double _Quantity;
        private object _dRefDate;
        private string _sProRecUser;

        private string _sCustomerTypeName;
        public string NationalID
        {
            get { return _NationalID; }
            set { _NationalID = value; }
        }
        public string ProRecUser
        {
            get { return _sProRecUser; }
            set { _sProRecUser = value; }
        }
        public string CustomerTypeName
        {
            get { return _sCustomerTypeName; }
            set { _sCustomerTypeName=value; }
        }

        public object RefDate
        {
            get { return _dRefDate; }
            set { _dRefDate = value; }
        }

        public string RefInvoiceNo
        {
            get { return _sRefInvoiceNo; }
            set { _sRefInvoiceNo = value; }
        }

        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }

        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }

        public string UOM
        {
            get { return _sUOM; }
            set { _sUOM = value; }
        }

        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }

        public double Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        public int PackQty
        {
            get { return _nPackQty; }
            set { _nPackQty = value; }
        }

        public double QtyAmount
        {
            get { return _QtyAmount; }
            set { _QtyAmount = value; }
        }


        private bool _bFlag;
        public string TaxNo
        {
            get { return _sTaxNo; }
            set { _sTaxNo = value; }
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
        public long WarehouseID
        {
            get { return _WarehouseID; }
            set { _WarehouseID = value; }
        }
        public string WarehouseName
        {
            get { return _sWarehouseName; }
            set { _sWarehouseName = value; }
        }
        public string WarehouseCode
        {
            get { return _sWarehouseCode; }
            set { _sWarehouseCode = value; }
        }
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }

        public double Receivable
        {
            get { return _Receivable; }
            set { _Receivable = value; }
        }

        public double Age30
        {
            get { return _Age30; }
            set { _Age30 = value; }
        }

        public double Age60
        {
            get { return _Age60; }
            set { _Age60 = value; }
        }

        public double Above60Day
        {
            get { return _Above60Day; }
            set { _Above60Day = value; }
        }
        public string DeliveryAddress
        {
            get { return _sDeliveryAddress; }
            set { _sDeliveryAddress = value; }
        }
        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }
        public DateTime DeliveryDate
        {
            get { return _DeliveryDate; }
            set { _DeliveryDate = value; }
        }
        public string OrderNo
        {
            get { return _sOrderNo; }
            set { _sOrderNo = value; }
        }
        public string OrderConfirmedBy
        {
            get { return _sOrderConfirmedBy; }
            set { _sOrderConfirmedBy = value; }
        }
        public long InvoiceID
        {
            get { return _InvoiceID; }
            set { _InvoiceID = value; }
        }
        public int InvoiceTypeID
        {
            get { return _nInvoiceTypeID; }
            set { _nInvoiceTypeID = value; }
        }
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        public string CustomerCode
        {
            get { return _CustomerCode; }
            set { _CustomerCode = value; }
        }
        public string CustomerTelephone
        {
            get { return _CustomerTelephone; }
            set { _CustomerTelephone = value; }
        }
        public string CustTypeName
        {
            get { return _CustTypeName; }
            set { _CustTypeName = value; }
        }
        public string AreaName
        {
            get { return _AreaName; }
            set { _AreaName = value; }
        }
        public string TerritoryName
        {
            get { return _TerritoryName; }
            set { _TerritoryName = value; }
        }
        public string ThanaName
        {
            get { return _ThanaName; }
            set { _ThanaName = value; }
        }
        public string DistrictName
        {
            get { return _DistrictName; }
            set { _DistrictName = value; }
        }
        public string InvoiceHeader
        {
            get { return _InvoiceHeader; }
            set { _InvoiceHeader = value; }
        }
        public string ChannelName
        {
            get { return _ChannelName; }
            set { _ChannelName = value; }
        }
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        public string OrderConfirmeddByName
        {
            get { return _OrderConfirmeddByName; }
            set { _OrderConfirmeddByName = value; }
        }
        public string DeliveredByName
        {
            get { return _DeliveredByName; }
            set { _DeliveredByName = value; }
        }
        public long VATChallanNo
        {
            get { return _VATChallanNo; }
            set { _VATChallanNo = value; }
        }
        public DateTime OrderDate
        {
            get { return _OrderDate; }
            set { _OrderDate = value; }
        }
        public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        public double DueAmount
        {
            get { return _DueAmount; }
            set { _DueAmount = value; }
        }
        public long SundryCustomerID
        {
            get { return _SundryCustomerID; }
            set { _SundryCustomerID = value; }
        }
        public string SundryCustomerName
        {
            get { return _SundryCustomerName; }
            set { _SundryCustomerName = value; }
        }
        public string SCAddress
        {
            get { return _SCAddress; }
            set { _SCAddress = value; }
        }
        public string SCCellNo
        {
            get { return _SCCellNo; }
            set { _SCCellNo = value; }
        }
        public string SCPhoneNo
        {
            get { return _SCPhoneNo; }
            set { _SCPhoneNo = value; }
        }
        public string SCEmail
        {
            get { return _SCEmail; }
            set { _SCEmail = value; }
        }
        public int WebInvoiceNo
        {
            get { return _nWebInvoiceNo; }
            set { _nWebInvoiceNo = value; }
        }
        public double CustomerBalance
        {
            get { return _CustomerBalance; }
            set { _CustomerBalance = value; }
        }
        public string WarehouseShortcode
        {
            get { return _sWarehouseShortcode; }
            set { _sWarehouseShortcode = value; }
        }
        public string EPSCustomerCode
        {
            get { return _sEPSCustomerCode; }
            set { _sEPSCustomerCode = value; }
        }
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value; }
        }
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value; }
        }
        public string Designation
        {
            get { return _sDesignation; }
            set { _sDesignation = value; }
        }
        public string EmployeeAddress
        {
            get { return _sEmployeeAddress; }
            set { _sEmployeeAddress = value; }
        }
        public string PhoneNo
        {
            get { return _sPhoneNo; }
            set { _sPhoneNo = value; }
        }
        public string EPSDeliveryWHName
        {
            get { return _sEPSDeliveryWHName; }
            set { _sEPSDeliveryWHName = value; }
        }
        public int NoOfInstallment
        {
            get { return _nNoOfInstallment; }
            set { _nNoOfInstallment = value; }
        }
        public long SalesPersonID
        {
            get { return _SalesPersonID; }
            set { _SalesPersonID = value; }
        }
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }
        public string RefDetails
        {
            get { return _RefDetails; }
            set { _RefDetails = value; }
        }

        private double _PromotionalDiscount;
        public double PromotionalDiscount
        {
            get { return _PromotionalDiscount; }
            set { _PromotionalDiscount = value; }
        
        }
        public short InvoiceStatus
        {
            get { return _InvoiceStatus; }
            set { _InvoiceStatus = value; }
        }
        public string RefInvoiceID
        {
            get { return _RefInvoiceID; }
            set { _RefInvoiceID = value; }
        }


        public rptSalesInvoiceDetail this[int i]
        {
            get { return (rptSalesInvoiceDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(rptSalesInvoiceDetail orptSalesInvoiceDetail)
        {
            InnerList.Add(orptSalesInvoiceDetail);
        }
        /// <summary>
        /// Shuvo 
        /// Date-27-Dec-2016
        /// </summary>
        public void RefreshForLead()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select SundryCustomerID, isnull(Balance,0) as Balance,isnull(RefDetails,'') RefDetails,  "+
                                  " InvoiceTypeID,InvoiceBy,f.UserName,a.WarehouseID,OrderNo,OrderDate,InvoiceNo,InvoiceDate,a.ConsumerName as CustomerName, " +
                                  " ConsumerCode as CustomerCode,Address as CustomerAddress, " +
                                  " CellNo as CustomerTelephone, CustomerTypeName, AreaName,  " +
                                  " TerritoryName, ThanaName, DistrictName,  " +
                                  " b.Discount, InvoiceAmount,WarehouseCode, WarehouseName, b.Remarks " +
                                  " From t_RetailConsumer a,t_SalesInvoice b,v_CustomerDetails c, " +
                                  " t_Warehouse d,t_SalesInvoiceEcommerce e,t_User f " +
                                  " where  a.WarehouseID=b.WarehouseID and a.CustomerID=b.CustomerID  " +
                                  " and a.CustomerID=c.CustomerID and b.InvoiceNo=e.RefInvoiceNo " +
                                  " and a.WarehouseID=d.WarehouseID and b.InvoiceBy=f.UserID and SalesType=" + (int)Dictionary.SalesType.eStore + "  " +
                                  " and InvoiceID = ?";


                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    _sOrderNo = reader["OrderNo"].ToString();
                    _OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    _sInvoiceNo = reader["InvoiceNo"].ToString();
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _sCustomerName = reader["CustomerName"].ToString();
                    _CustomerCode = reader["CustomerCode"].ToString();
                    _sCustomerAddress = reader["CustomerAddress"].ToString();
                    _CustomerTelephone = reader["CustomerTelephone"].ToString();
                    _CustTypeName = reader["CustomerTypeName"].ToString();
                    _AreaName = reader["AreaName"].ToString();
                    _TerritoryName = reader["TerritoryName"].ToString();
                    _ThanaName = reader["ThanaName"].ToString();
                    _DistrictName = reader["DistrictName"].ToString();
                    _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    _InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _sWarehouseName = reader["WarehouseName"].ToString();
                    _sWarehouseCode = reader["WarehouseCode"].ToString();
                    _Remarks = reader["Remarks"].ToString();

                    _sEPSCustomerCode = "";
                    _sEmployeeCode = "";
                    _sEmployeeName = "";
                    _sDesignation = "";
                    _sEmployeeAddress ="";
                    _sPhoneNo = "";
                    _sEPSDeliveryWHName = "";
                    _nNoOfInstallment = 0;

                    _SundryCustomerID = Convert.ToInt64(reader["SundryCustomerID"].ToString());
                    _SundryCustomerName = reader["CustomerName"].ToString();
                    _SCAddress = reader["CustomerAddress"].ToString();
                    _SCCellNo = reader["CustomerTelephone"].ToString();
                    _SCPhoneNo = reader["CustomerTelephone"].ToString();

                    _WarehouseID = Convert.ToInt32(reader["WarehouseID"].ToString());

                    if (reader["InvoiceDate"] != DBNull.Value)
                        _DeliveryDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    else _DeliveryDate = DateTime.Today;


                    _sOrderConfirmedBy = "";
                    _nInvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());


                    _OrderConfirmeddByName = "";
                    _DeliveredByName = "";

                    _RefDetails = reader["RefDetails"].ToString();
                    _CustomerBalance = Convert.ToDouble(reader["Balance"].ToString());
                    _DueAmount = 0;
                    _VATChallanNo = 0;
                    _OrderConfirmeddByName = reader["UserName"].ToString();
                    _DeliveredByName = reader["UserName"].ToString();
                    _ChannelName = "ECommerce";


                    RefreshItem();

                }
                reader.Close();



            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = " select qq1.*,qq2.UserName  as DeliveredByName,qq3.EmployeeName as SalesPersonName,CustomerAddress, CustomerTelePhone,CustomerFax " +
                               " ,CellPhoneNo, ContractPerson, CustomerTypeID as CustTypeID, CustomerTypeCode as CustTypeCode, CustomerTypeName as CustTypeName, AreaID, AreaCode, AreaName, TerritoryID,TerritoryCode, TerritoryName,OrderNo, OrderDate, SBUID, SBUCode, SBUName, InvoiceTypeName,DistrictID, DistrictCode, DistrictName, ThanaID, ThanaCode, ThanaName,isnull(TaxNumber,'') TaxNumber " +
                               " , OrderReceivedByID, OrderConfirmedByID,  OrderReceivedByName, OrderConfirmedByName " +
                               " , qq7.UserName as UpdateUserName,qq8.SundryCustomerName, qq8.Address as SCAddress, qq8.PhoneNo as SCPhoneNo , qq8.CellNo as SCCellNo, qq8.Email as SCEmail " +
                               " , C.EPSCustomerCode, C.EmployeeCode,C.EmployeeName, C.Designation, C.EmployeeAddress, C.PhoneNo as EPSCustPhoneNo,WH.WarehouseName as EPSDeliveryWHName,E.NoOfInstallment,isnull(WH.WarehouseAddress,'') WarehouseAddress" +
                               " FROM  " +
                               " ( " +
                               " SELECT q1.*,q2.CustomerName,q2.CustomerCode,q3.WarehouseCode, q3.WarehouseName, q3.ChannelID,q5.ChannelCode, q5.ChannelDescription as ChannelName, q4.UserName as InvoiceByName,q6.CurrentBalance  FROM t_SalesInvoice q1,t_customer q2, t_warehouse q3, t_User q4, t_Channel q5,t_CustomerAccount q6 " +
                               " WHERE q1.customerid = q2.customerid and q1.customerid = q6.customerid and q1.warehouseid = q3.warehouseid AND InvoiceID = ? AND q4.UserID = q1.InvoiceBy and q3.ChannelID = q5.ChannelID " +
                               " ) " +
                               " as qq1 Left outer Join " +
                               " ( " +
                               " select UserID, UserName from t_User " +
                               " ) " +
                               " as qq2 " +
                               " on qq1.DeliveredBy = qq2.UserID " +
                               " left outer join " +
                               " ( " +
                               " select AssignmentCode,JobTypeID,EmployeeName, q1.EmployeeID from t_EmployeeJobType q1, t_Employee q2  " +
                               " where q1.EmployeeID = q2.EmployeeID and  IsActive = ? and JobTypeID = ? " +
                               " ) " +
                               " as qq3 " +
                               " on qq1.SalesPersonID = qq3.EmployeeID " +
                               " left outer join " +
                               " ( " +
                               " select CustomerID, CustomerAddress, CustomerTelePhone,CustomerFax, CellPhoneNo, ContractPerson, CustomerTypeID, CustomerTypeCode, CustomerTypeName, AreaID, AreaCode, AreaName,TerritoryID, TerritoryCode, TerritoryName, SBUID, SBUCode, SBUName,DistrictID, DistrictCode, DistrictName, ThanaID, ThanaCode, ThanaName,isnull(TaxNumber,'') TaxNumber from v_customerDetails " +
                               " ) " +
                               " as qq4  " +
                               " on qq1.customerid = qq4.customerid " +
                               " Left outer join " +
                               " ( " +
                               " select q1.OrderID, q1.OrderNo, q1. OrderDate, q1.CreateUserID as OrderReceivedByID, q1.ConfirmUserID as OrderConfirmedByID,  q2.UserName as  OrderReceivedByName, q3.UserName as OrderConfirmedByName from " +
                               " ( " +
                               " select OrderID, OrderNo, OrderDate,CreateUserID, ConfirmUserID from t_salesOrder " +
                               " ) " +
                               " as q1 " +
                               " left outer join " +
                               " ( " +
                               " select UserID, UserName from t_User " +
                               " ) " +
                               " as q2 " +
                               " on q1.CreateUserID = q2.UserID " +
                               " left outer join " +
                               " ( " +
                               " select UserID, UserName from t_User " +
                               " ) " +
                               " as q3 " +
                               " on q1.ConfirmUserID = q3.UserID " +
                               " )  " +
                               " as qq5 " +
                               " on qq1.orderid = qq5.Orderid " +
                               " LEFT OUTER JOIN " +
                               " ( " +
                               " select InvoiceTypeID, InvoiceTypeName from t_invoicetype " +
                               " ) " +
                               " as qq6 " +
                               " on qq1.InvoiceTypeID = qq6.InvoiceTypeID " +
                               " LEFT OUTER JOIN " +
                               " ( " +
                               " select UserID, UserName from t_User " +
                               " ) " +
                               " as qq7 " +
                               " on qq1.UpdateUserID = qq7.UserID " +
                               " LEFT OUTER JOIN " +
                               " ( " +
                               " SELECT SundryCustomerID, SundryCustomerName, Address, PhoneNo, CellNo, Email FROM t_SundryCustomer" +
                               " ) " +
                               " as qq8 " +
                               " on qq1.SundryCustomerID = qq8.SundryCustomerID" +
                               " Left outer JOIN t_EPSSales E" +
                               " ON qq1.OrderID=E.OrderID" +
                               " Left Outer JOIN t_EPSCustomer C" +
                               " ON C.EPSCustomerID=E.EPSCustomerID" +
                               " Left OUter JOIN (Select WarehouseID, WarehouseName,isnull(b.Description,'')  as WarehouseAddress from  t_WareHouse a,t_JobLocation b where a.LocationID=b.JobLocationID) WH" +
                               " ON WH.WarehouseID=qq1.WarehouseID";

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("IsActive", Dictionary.ActiveOrInActiveStatus.ACTIVE);
                cmd.Parameters.AddWithValue("JobTypeID", Dictionary.JobType.SALES_PERSONS);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    if (reader["SundryCustomerID"] != DBNull.Value)
                    {
                        _SundryCustomerID = Convert.ToInt64(reader["SundryCustomerID"].ToString());
                        _SundryCustomerName = reader["SundryCustomerName"].ToString();
                        _SCAddress = reader["SCAddress"].ToString();
                        _SCCellNo = reader["SCCellNo"].ToString();
                        _SCPhoneNo = reader["SCPhoneNo"].ToString();
                    }
                    else _SundryCustomerID = -1;

                    _CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _sCustomerName = reader["CustomerName"].ToString();
                    _CustomerCode = reader["CustomerCode"].ToString();
                    _sCustomerAddress = reader["CustomerAddress"].ToString();
                    _sDeliveryAddress = reader["DeliveryAddress"].ToString();
                    _sTaxNo = reader["TaxNumber"].ToString();
                    _CustomerTelephone = reader["CustomerTelephone"].ToString();
                    _CustTypeName = reader["CustTypeName"].ToString();
                    _AreaName = reader["AreaName"].ToString();
                    _TerritoryName = reader["TerritoryName"].ToString();
                    _ThanaName = reader["ThanaName"].ToString();
                    _DistrictName = reader["DistrictName"].ToString();
                    _ChannelName = reader["ChannelName"].ToString();

                    _sWarehouseName = reader["WarehouseName"].ToString();
                    _sWarehouseAddress = reader["WarehouseAddress"].ToString();
                    _sWarehouseCode = reader["WarehouseCode"].ToString();

                    _sInvoiceNo = reader["InvoiceNo"].ToString();
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());

                    if (reader["DeliveryDate"] != DBNull.Value)
                        _DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    else _DeliveryDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());

                    _sEPSCustomerCode = reader["EPSCustomerCode"].ToString();
                    _sEmployeeCode = reader["EmployeeCode"].ToString();
                    _sEmployeeName = reader["EmployeeName"].ToString();
                    _sDesignation = reader["Designation"].ToString();
                    _sEmployeeAddress = reader["EmployeeAddress"].ToString();
                    _sPhoneNo = reader["EPSCustPhoneNo"].ToString();
                    _sEPSDeliveryWHName = reader["EPSDeliveryWHName"].ToString();
                    if (reader["NoOfInstallment"] != DBNull.Value)
                        _nNoOfInstallment = Convert.ToInt32(reader["NoOfInstallment"].ToString());
                    else _nNoOfInstallment = 0;

                    _WarehouseID = Convert.ToInt32(reader["WarehouseID"].ToString());

                    if (reader["DeliveryDate"] != DBNull.Value)
                        _DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    else _DeliveryDate = DateTime.Today;

                    _sOrderNo = reader["OrderNo"].ToString();
                    _sOrderConfirmedBy = reader["OrderConfirmedByName"].ToString();
                    _nInvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
                    if (reader["OrderDate"] != DBNull.Value)
                        _OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    _InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _OrderConfirmeddByName = reader["OrderConfirmedByName"].ToString();
                    _DeliveredByName = reader["DeliveredByName"].ToString();
                    _Remarks = reader["Remarks"].ToString();
                    _RefDetails = reader["RefDetails"].ToString();
                    _CustomerBalance = Convert.ToDouble(reader["CurrentBalance"].ToString());
                    if (reader["DueAmount"] != DBNull.Value)
                        _DueAmount = Convert.ToDouble(reader["DueAmount"].ToString());
                    else _DueAmount = 0;

                    try
                    {
                        _VATChallanNo = Convert.ToInt64(reader["VATChallanNo"].ToString());
                    }
                    catch
                    {
                        _VATChallanNo = 0;
                    }

                    RefreshItem();

                }
                reader.Close();



            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        // Aging Added by Hrashid 30 Dec 2021
        public void RefreshAgingForBLL(int CustomerID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @" select CustomerID, Isnull(Receivables, 0) as Receivable, Isnull(Due30Days, 0) as Age30, Isnull(Due60day, 0) as Age60, Isnull((Receivables-(Due30Days+Due60day)),0) as Above60Day
            from
            (
            --- Aging Part Start-----------
            select CustomerID, Receivables,Due30Days,
            Due60day= case when Receivables>0 then (Receivables-Due30Days) when Receivables<0 then 0 else 0 end
            from
            (
            select CustomerID, MTDSales,CM_Coll30, (MTDSales- CM_Coll30) as Age30,
            Receivables,
            Due30Days=case when Receivables < 0 then 0
            when (MTDSales- CM_Coll30) < 0 then 0
            when (MTDSales- CM_Coll30) >0 then (MTDSales- CM_Coll30) else 0 end
            from
            (
            select CustomerID,isnull(sum(MTDAge30),0 ) as MTDSales, Isnull(sum(CM_Coll30),0) as CM_Coll30, sum(Receivables) as Receivables
            from 
            (-------------AG30Sales Start------------------
            select CustomerID,isnull(sum(crAmount) - abs(sum(drAmount)),0) as MTDAge30, 0 as CM_Coll30,0 as Receivables
            from 
            (
            select CustomerID, sum(invoiceamount) as crAmount, 0 as drAmount
            from t_salesInvoice 
            where invoicedate between   dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and  DATEADD(dd,DATEDIFF(dd,0,GETDATE()),-1)
            and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)  
            group by CustomerID 
            union all 
            select CustomerID,0 as crAmount,sum(invoiceamount) as drAmount
            from t_salesInvoice  
            where invoicedate between  dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and DATEADD(dd,DATEDIFF(dd,0,GETDATE()),-1)
            and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) 
            group by CustomerID 
            )as asg30
            group by CustomerID
            -------------AG30Sayes End-------------------------
            union all
            -------------AG30 Coll Start---------------------
            select customerid, 0 as MTDAge30, sum(CreditAmount-DebitAmount) as CM_Coll30, 0 as Receivables
            from 
            ( 
            select customerid, sum(amount)as CreditAmount, 0 as DebitAmount from t_customerTran ct, t_customerTrantype ctt
            where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(4,5,6,27,19,21) and ct.TranDate between   
            dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106))  and DATEADD(dd,DATEDIFF(dd,0,GETDATE()),-1)
            group by customerid
            union all
            select customerid, 0 as CreditAmount, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt
            where ct.trantypeid = ctt.trantypeid and ctt.TranTypeID in(17,16,18,28,20) and ct.TranDate between 
            dateadd(day, -30, CONVERT(VARCHAR(25), dateadd(month, -0, getdate()), 106)) and DATEADD(dd,DATEDIFF(dd,0,GETDATE()),-1)
            group by customerid 
            ) as Coll 
            group by customerid

            union all
            -------------------------------Receivables-------------
            select CustomerID, 0 as MTDAge30, 0 as CM_Coll30,  (CurrentBalance * -1) as Receivables
            from v_Customerdetails 
            ) as total group by CustomerID
            ) as final 
            ) as ttaging 
            ) as finalage where CustomerID=" + CustomerID + @" ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _CustomerID = int.Parse(reader["CustomerID"].ToString());

                    if (reader["Receivable"] != DBNull.Value)
                        _Receivable = Convert.ToDouble(reader["Receivable"].ToString());
                    else _Receivable = 0;

                    if (reader["Age30"] != DBNull.Value)
                        _Age30 = Convert.ToDouble(reader["Age30"].ToString());
                    else _Age30 = 0;

                    if (reader["Age60"] != DBNull.Value)
                        _Age60 = Convert.ToDouble(reader["Age60"].ToString());
                    else _Age60 = 0;

                    if (reader["Above60Day"] != DBNull.Value)
                        _Above60Day = Convert.ToDouble(reader["Above60Day"].ToString());
                    else _Above60Day = 0;

                }
                reader.Close();
               // InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void RefreshforProductReturn(long InvoiceID)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = " Select RProduct.InvoiceID,RProduct.CustomerID,ProductCode, ProductName,UOM,UnitPrice,Quantity,PackQty,Discount,InvoiceAmount, QtyAmount,InvoiceNo,InvoiceDate,RProduct.Remarks,RefInvoiceNo,RefDate, CustomerCode,CustomerName,CustomerAddress,ThanaName,DistrictName,CustomerTelephone,CustomerTypeName,AreaName,TerritoryName, ProRecUser " +
                            " from " +
                            " ( " +
                            " Select a.InvoiceID, RefInvoiceID, ProductCode, ProductName, SmallUnitOfMeasure as UOM, b.UnitPrice, b.Quantity, Discount, InvoiceAmount, " +
                            " UOMConversionFactor, round(isnull((Quantity / cast(Nullif((UOMConversionFactor), 0) as float)), 0), 0) as PackQty, round((UnitPrice * Quantity), 0) as QtyAmount, " +
                            " Convert(datetime, replace(convert(varchar, InvoiceDate, 6), '', '-'), 1) as InvoiceDate, InvoiceNo, CustomerID, InvoiceBy ,Remarks" +
                            " from t_SalesInvoice a, t_SalesInvoiceDetail b, v_ProductDetails c " +
                            " where a.InvoiceID = b.InvoiceID and b.ProductID = c.ProductID and a.InvoiceID = '" + InvoiceID + "'  " +
                            " ) as RProduct " +
                            " left outer join " +
                            " ( " +
                            " Select InvoiceID, InvoiceNo as RefInvoiceNo , Convert(datetime, replace(convert(varchar, InvoiceDate, 6), '', '-'), 1) as RefDate, Remarks, RefInvoiceID from t_SalesInvoice) as RefInv " +
                            " on RProduct.RefInvoiceID = RefInv.InvoiceID " +
                            " inner join " +
                            " ( " +
                            " select CustomerID, CustomerCode, CustomerName, CustomerAddress, ThanaName, DistrictName, CustomerTelephone, CustomerTypeName, AreaName, TerritoryName " +
                            " from v_CustomerDetails) as Cust on RProduct.CustomerID = Cust.CustomerID " +
                            " inner join (Select UserID, UserName as ProRecUser from t_user ) as Emp on RProduct.InvoiceBy=Emp.UserID ";

            try
            {

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    rptSalesInvoice _orptSalesInvoice = new rptSalesInvoice();

                    _orptSalesInvoice.InvoiceID = long.Parse(reader["InvoiceID"].ToString());
                    _orptSalesInvoice.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _orptSalesInvoice.ProductCode= reader["ProductCode"].ToString();
                    _orptSalesInvoice.ProductName = reader["ProductName"].ToString(); 
                    _orptSalesInvoice.UOM = reader["UOM"].ToString();
                    _orptSalesInvoice.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    _orptSalesInvoice.Quantity = Convert.ToDouble(reader["Quantity"].ToString());
                    _orptSalesInvoice.PackQty = int.Parse(reader["PackQty"].ToString());
                    _orptSalesInvoice.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    _orptSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _orptSalesInvoice.QtyAmount = Convert.ToDouble(reader["QtyAmount"].ToString());
                    _orptSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();

                    if (reader["InvoiceDate"] != DBNull.Value)
                    {
                        _orptSalesInvoice.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    }
                   
                    _orptSalesInvoice.Remarks = reader["Remarks"].ToString();
                    _orptSalesInvoice.RefInvoiceNo = reader["RefInvoiceNo"].ToString();

                    if (reader["RefDate"] != DBNull.Value)
                    {
                        _orptSalesInvoice.RefDate = Convert.ToDateTime(reader["RefDate"].ToString());
                    }
                    else
                    {
                        _orptSalesInvoice.RefDate ="";
                    }
            

                    _orptSalesInvoice.CustomerCode = reader["CustomerCode"].ToString();
                    _orptSalesInvoice.CustomerName = reader["CustomerName"].ToString();
                    _orptSalesInvoice.CustomerAddress = reader["CustomerAddress"].ToString();
                    _orptSalesInvoice.ThanaName = reader["ThanaName"].ToString();
                    _orptSalesInvoice.DistrictName = reader["DistrictName"].ToString();
                    _orptSalesInvoice.CustomerTelephone = reader["CustomerTelephone"].ToString();
                    _orptSalesInvoice.CustomerTypeName = reader["CustomerTypeName"].ToString();
                    _orptSalesInvoice.AreaName = reader["AreaName"].ToString();
                    _orptSalesInvoice.TerritoryName = reader["TerritoryName"].ToString();
                    _orptSalesInvoice.ProRecUser = reader["ProRecUser"].ToString();

                    InnerList.Add(_orptSalesInvoice);

                }
                reader.Close();
                InnerList.TrimToSize();



            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshForEcommerce()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select qq1.*,qq2.UserName  as DeliveredByName,qq3.EmployeeName as SalesPersonName,CustomerAddress, CustomerTelePhone,CustomerFax, " +
                                    "CellPhoneNo, ContractPerson, CustomerTypeID as CustTypeID, CustomerTypeCode as CustTypeCode, CustomerTypeName as CustTypeName, " +
                                    "AreaID, AreaCode, AreaName, TerritoryID,TerritoryCode, TerritoryName,OrderNo, OrderDate, SBUID, SBUCode, SBUName, InvoiceTypeName, " +
                                    "DistrictID, DistrictCode, DistrictName, ThanaID, ThanaCode, ThanaName, OrderReceivedByID, OrderConfirmedByID,  OrderReceivedByName, " +
                                    "OrderConfirmedByName , qq7.UserName as UpdateUserName,qq8.SundryCustomerName, qq8.Address as SCAddress, IsNull(qq8.PhoneNo,'') as SCPhoneNo , " +
                                    "qq8.CellNo as SCCellNo, qq8.Email as SCEmail, WH.WarehouseName, WebInvoiceNo " +
                                    "FROM " +
                                    "( " +
                                    "SELECT q1.*,q2.CustomerName,q2.CustomerCode,q3.WarehouseCode, q3.WarehouseName, q3.ChannelID,q5.ChannelCode, " +
                                    "q5.ChannelDescription as ChannelName, q4.UserName as InvoiceByName,q6.CurrentBalance  FROM t_SalesInvoice q1,t_customer q2, " +
                                    "t_warehouse q3, t_User q4, t_Channel q5,t_CustomerAccount q6 WHERE q1.customerid = q2.customerid and q1.customerid = q6.customerid " +
                                    "and q1.warehouseid = q3.warehouseid AND q4.UserID = q1.InvoiceBy and q3.ChannelID = q5.ChannelID and InvoiceID = ?) as qq1 " +
                                    "Left outer Join (select UserID, UserName from t_User) as qq2 " +
                                    "on qq1.DeliveredBy = qq2.UserID " +
                                    "left outer join (select AssignmentCode,JobTypeID,EmployeeName, q1.EmployeeID from t_EmployeeJobType q1, t_Employee q2  " +
                                    "where q1.EmployeeID = q2.EmployeeID and  IsActive = ?) as qq3 " +
                                    "on qq1.SalesPersonID = qq3.EmployeeID " +
                                    "left outer join " +
                                    "( " +
                                    "select CustomerID, CustomerAddress, CustomerTelePhone,CustomerFax, CellPhoneNo, ContractPerson, CustomerTypeID, CustomerTypeCode, " +
                                    "CustomerTypeName, AreaID, AreaCode, AreaName,TerritoryID, TerritoryCode, TerritoryName, SBUID, SBUCode, SBUName,DistrictID, " +
                                    "DistrictCode, DistrictName, ThanaID, ThanaCode, ThanaName from v_customerDetails) as qq4  " +
                                    "on qq1.customerid = qq4.customerid " +
                                    "Left outer join " +
                                    "( " +
                                    "select q1.OrderID, q1.OrderNo, q1. OrderDate, q1.CreateUserID as OrderReceivedByID, q1.ConfirmUserID as OrderConfirmedByID,  " +
                                    "q2.UserName as  OrderReceivedByName, q3.UserName as OrderConfirmedByName from " +
                                    "(select OrderID, OrderNo, WarehouseID, OrderDate,CreateUserID, ConfirmUserID from t_salesOrder) as q1 " +
                                    "left outer join " +
                                    "(select UserID, UserName from t_User) as q2 " +
                                    "on q1.CreateUserID = q2.UserID " +
                                    "left outer join " +
                                    "(select UserID, UserName from t_User) as q3 " +
                                    "on q1.ConfirmUserID = q3.UserID) as qq5 " +
                                    "on qq1.orderid = qq5.Orderid " +
                                    "LEFT OUTER JOIN " +
                                    "(select InvoiceTypeID, InvoiceTypeName from t_invoicetype) as qq6 " +
                                    "on qq1.InvoiceTypeID = qq6.InvoiceTypeID " +
                                    "LEFT OUTER JOIN " +
                                    "(select UserID, UserName from t_User) as qq7 " +
                                    "on qq1.UpdateUserID = qq7.UserID " +
                                    "LEFT OUTER JOIN " +
                                    "(SELECT SundryCustomerID, SundryCustomerName, Address, PhoneNo, CellNo, Email FROM t_SundryCustomer)  as qq8 " +
                                    "on qq1.SundryCustomerID = qq8.SundryCustomerID " +
                                    "Left OUter JOIN (Select WarehouseID, WarehouseName from  t_WareHouse) WH " +
                                    "ON WH.WarehouseID=qq1.warehouseID " +
                                    "Left OUter JOIN (Select OrderID, WebInvoiceNo from  t_ecommerceorder) EC " +
                                    "ON EC.OrderID=qq1.OrderID ";

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.Parameters.AddWithValue("IsActive", Dictionary.ActiveOrInActiveStatus.ACTIVE);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    _CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _sCustomerName = reader["CustomerName"].ToString();
                    _CustomerCode = reader["CustomerCode"].ToString();
                    _sCustomerAddress = reader["CustomerAddress"].ToString();
                    _CustomerTelephone = reader["CustomerTelephone"].ToString();
                    _CustTypeName = reader["CustTypeName"].ToString();
                    _AreaName = reader["AreaName"].ToString();
                    _TerritoryName = reader["TerritoryName"].ToString();
                    _ThanaName = reader["ThanaName"].ToString();
                    _DistrictName = reader["DistrictName"].ToString();
                    _ChannelName = reader["ChannelName"].ToString();

                    _sWarehouseName = reader["WarehouseName"].ToString();
                    _sWarehouseCode = reader["WarehouseCode"].ToString();
                    _sInvoiceNo = reader["InvoiceNo"].ToString();
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());

                    
                    _SundryCustomerName = reader["SundryCustomerName"].ToString();
                    _SCAddress = reader["SCAddress"].ToString();
                    _SCPhoneNo = reader["SCPhoneNo"].ToString();
                    _SCCellNo = reader["SCCellNo"].ToString();
                    _SCEmail = reader["SCEmail"].ToString();

                    if (reader["WebInvoiceNo"] != DBNull.Value)
                    {
                        _nWebInvoiceNo = Convert.ToInt32(reader["WebInvoiceNo"].ToString());
                    }

                    _WarehouseID = Convert.ToInt32(reader["WarehouseID"].ToString());

                    if (reader["DeliveryDate"] != DBNull.Value)
                        _DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    else _DeliveryDate = DateTime.Today;

                    if (reader["OrderNo"] != DBNull.Value)
                    {
                        _sOrderNo = reader["OrderNo"].ToString();
                    }
                    if (reader["OrderConfirmedByName"] != DBNull.Value)
                    {
                        _sOrderConfirmedBy = reader["OrderConfirmedByName"].ToString();
                    }
                    _nInvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
                    if (reader["OrderDate"] != DBNull.Value)
                    {
                        _OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    }
                    _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    _InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    if (reader["OrderConfirmedByName"] != DBNull.Value)
                    {
                        _OrderConfirmeddByName = reader["OrderConfirmedByName"].ToString();
                    }
                    _DeliveredByName = reader["DeliveredByName"].ToString();
                    _Remarks = reader["Remarks"].ToString();
                    _RefDetails = reader["RefDetails"].ToString();
                    _CustomerBalance = Convert.ToDouble(reader["CurrentBalance"].ToString());
                    if (reader["DueAmount"] != DBNull.Value)
                        _DueAmount = Convert.ToDouble(reader["DueAmount"].ToString());
                    else _DueAmount = 0;

                    try
                    {
                        _VATChallanNo = Convert.ToInt64(reader["VATChallanNo"].ToString());
                    }
                    catch
                    {
                        _VATChallanNo = 0;
                    }

                    RefreshItem();

                }
                reader.Close();



            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshPOSDealer()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " select qq1.*,qq2.UserName  as DeliveredByName,CustomerName, CustomerAddress, CustomerTelePhone,CustomerFax ,CellPhoneNo, " +
                "ContractPerson, CustomerTypeID as CustTypeID, CustomerTypeCode as CustTypeCode, CustomerTypeName as CustTypeName, AreaID, " +
                "AreaCode, AreaName, TerritoryID,TerritoryCode, TerritoryName,SBUID, SBUCode, SBUName, InvoiceTypeName, DistrictID, " +
                "DistrictCode, DistrictName, ThanaID, ThanaCode, ThanaName, qq7.UserName as UpdateUserName " +
                "FROM  " +
                "( " +
                "SELECT q1.*,q2.CustomerName,q2.CustomerCode,q3.WarehouseCode, q3.WarehouseName, q3.ChannelID,q5.ChannelCode, " +
                "q5.ChannelDescription as ChannelName,q4.UserName as InvoiceByName,q6.CurrentBalance  FROM t_SalesInvoice q1, " +
                "t_customer q2, t_warehouse q3, t_User q4, t_Channel q5,t_CustomerAccount q6 " +
                "WHERE q1.customerid = q2.customerid and q1.customerid = q6.customerid and q1.warehouseid = q3.warehouseid AND " +
                "InvoiceID = ? AND q4.UserID = q1.InvoiceBy and q3.ChannelID = q5.ChannelID)as qq1 " +
                "Left outer Join " +
                "(select UserID, UserName from t_User) as qq2 on qq1.DeliveredBy = qq2.UserID " +
                "left outer join " +
                "(select CustomerID, CustomerAddress, CustomerTelePhone,CustomerFax, CellPhoneNo, ContractPerson, CustomerTypeID, " +
                "CustomerTypeCode, CustomerTypeName, AreaID, AreaCode, AreaName,TerritoryID, TerritoryCode, TerritoryName, " +
                "SBUID, SBUCode, SBUName,DistrictID, DistrictCode, DistrictName, ThanaID, ThanaCode, ThanaName from v_customerDetails)as qq4  " +
                "on qq1.customerid = qq4.customerid " +
                "left outer join " +
                "(select UserID, UserName from t_User) as q2 on qq1.InvoiceBy = q2.UserID " +
                "LEFT OUTER JOIN " +
                "(select InvoiceTypeID, InvoiceTypeName from t_invoicetype) as qq6 " +
                "on qq1.InvoiceTypeID = qq6.InvoiceTypeID " +
                "LEFT OUTER JOIN " +
                "(select UserID, UserName from t_User) as qq7 " +
                "on qq1.UpdateUserID = qq7.UserID ";


                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    _CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _sCustomerName = reader["CustomerName"].ToString();
                    _CustomerCode = reader["CustomerCode"].ToString();
                    _sCustomerAddress = reader["CustomerAddress"].ToString();
                    _CustomerTelephone = reader["CustomerTelephone"].ToString();
                    _CustTypeName = reader["CustTypeName"].ToString();
                    _AreaName = reader["AreaName"].ToString();
                    _TerritoryName = reader["TerritoryName"].ToString();
                    _ThanaName = reader["ThanaName"].ToString();
                    _DistrictName = reader["DistrictName"].ToString();
                    _ChannelName = reader["ChannelName"].ToString();

                    _sWarehouseName = reader["WarehouseName"].ToString();
                    _sWarehouseCode = reader["WarehouseCode"].ToString();
                    _sInvoiceNo = reader["InvoiceNo"].ToString();
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());


                    _WarehouseID = Convert.ToInt32(reader["WarehouseID"].ToString());

                    if (reader["DeliveryDate"] != DBNull.Value)
                        _DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    else _DeliveryDate = DateTime.Today;

                    _nInvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
                    _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    _InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _DeliveredByName = reader["DeliveredByName"].ToString();
                    _Remarks = reader["Remarks"].ToString();
                    _RefDetails = reader["RefDetails"].ToString();
                    _CustomerBalance = Convert.ToDouble(reader["CurrentBalance"].ToString());
                    if (reader["DueAmount"] != DBNull.Value)
                        _DueAmount = Convert.ToDouble(reader["DueAmount"].ToString());
                    else _DueAmount = 0;

                    try
                    {
                        _VATChallanNo = Convert.ToInt64(reader["VATChallanNo"].ToString());
                    }
                    catch
                    {
                        _VATChallanNo = 0;
                    }

                    RefreshItem();

                }
                reader.Close();



            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        //public void RefreshItem()
        //{

        //    string[] sCopy = new string[] { "Customer Copy", "Warehouse Copy", "Gate Pass Copy" };
        //    rptSalesInvoiceDetail oItem;
        //    InnerList.Clear();
        //    DBController.Instance.BeginNewTransaction();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();

        //    try
        //    {
        //        cmd.CommandText = " SELECT q1.InvoiceID, q1.ProductID, (q1.Quantity + isnull(q1.FreeQty,0)) as Quantity,  " +
        //                        " q1.UnitPrice, q1.CostPrice, q1.TradePrice, q1.VATAmount, q1.ProductDiscount, q1.SalesPersonBonus,   " +
        //                        " q1.CustomerProfitMargin, q1.CustomerSellingExpense, q1.TradePromotion, q1.Advertisement, q1.RetailCommission,   " +
        //                        " q1.ProductWarrenty, q1.PrimaryFreightCost, q1.OtherProvission, q1.AdjustedDPAmount, q1.AdjustedPWAmount, q1.AdjustedTPAmount,   " +
        //                        " q1.PromotionalDiscount, q1.IsFreeProduct, q1.FreeQty, q2.ProductCode,q2.ProductName,q2.SmallUnitOfMeasure as SUOM, "+
        //                        " q2.LargeUnitOfMeasure as LUOM,q2.UOMConversionFactor, q2.ProductType, q2.LSRatio, q2.MSRatio from t_SalesInvoiceDetail q1, "+
        //                        " t_Product q2 WHERE q1.Productid = q2.Productid AND InvoiceID = ? ";


        //        cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);                
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            oItem = new rptSalesInvoiceDetail();

        //            oItem.ProductCode = reader["ProductCode"].ToString();
        //            oItem.ProductName = reader["ProductName"].ToString();
        //            try
        //            {
        //                oItem.Quantity = Convert.ToDouble(reader["Quantity"].ToString());
        //            }
        //            catch
        //            {
        //                oItem.Quantity = 0;
        //            }
        //            oItem.SUOM = reader["SUOM"].ToString();
        //            oItem.LUOM = reader["LUOM"].ToString();
        //            try
        //            {
        //                oItem.LSRatio = Convert.ToInt64(reader["LSRatio"].ToString());
        //            }
        //            catch
        //            {
        //                oItem.LSRatio = 0;
        //            }
        //            try
        //            {
        //                oItem.UOMConversionFactor = Convert.ToDouble(reader["UOMConversionFactor"].ToString());
        //            }
        //            catch
        //            {
        //                oItem.UOMConversionFactor = 0;
        //            }
        //            try
        //            {
        //                oItem.FreeQty = int.Parse(reader["FreeQty"].ToString());
        //            }
        //            catch
        //            {
        //                oItem.FreeQty = 0;
        //            }
        //            try
        //            {
        //                oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
        //            }
        //            catch
        //            {
        //                oItem.UnitPrice = 0;
        //            }
        //            try
        //            {
        //                oItem.AdjustedTPAmount = Convert.ToDouble(reader["AdjustedTPAmount"].ToString());
        //            }
        //            catch
        //            {
        //                oItem.AdjustedTPAmount = 0;
        //            }
        //            try
        //            {
        //                oItem.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"].ToString());
        //            }
        //            catch
        //            {
        //                oItem.AdjustedPWAmount = 0;
        //            }
        //            try
        //            {
        //                oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"].ToString());
        //            }
        //            catch
        //            {
        //                oItem.AdjustedDPAmount = 0;
        //            }
        //            try
        //            {
        //                oItem.VATAmount = Convert.ToDouble(reader["VATAmount"].ToString());
        //            }
        //            catch
        //            {
        //                oItem.VATAmount = 0;
        //            }
        //            try
        //            {
        //                oItem.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
        //            }
        //            catch
        //            {
        //                oItem.TradePrice = 0;
        //            }
        //            try
        //            {
        //                oItem.PromotionalDiscount = Convert.ToDouble(reader["PromotionalDiscount"].ToString());
        //            }
        //            catch
        //            {
        //                oItem.PromotionalDiscount = 0;
        //            }
        //            oItem.ProductTypeID = int.Parse(reader["ProductType"].ToString());

        //            for (int i = 0; i < 3;i++ )
        //            {
        //                oItem.Copy = sCopy[i];

        //            }
        //            oItem.ProductID = int.Parse(reader["ProductID"].ToString());

        //            if (Utility.CompanyInfo == "TML")
        //            {
        //                //for E-store
        //                if (_WarehouseID == Utility.WebStore)
        //                {
        //                    oItem.InboxItemName = InboxItem(oItem.ProductID);
        //                    oItem.IMEI = GetIMEI(oItem.ProductID, int.Parse(reader["InvoiceID"].ToString()));
        //                }
        //            }

        //            InnerList.Add(oItem);
        //        }

        //        reader.Close();                             

        //        InnerList.TrimToSize();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }

        //}

        public void RefreshItem()
        {

            string[] sCopy = new string[] { "Customer Copy", "Warehouse Copy", "Gate Pass Copy" };
            rptSalesInvoiceDetail oItem;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " SELECT q1.InvoiceID, q1.ProductID, (q1.Quantity + isnull(q1.FreeQty,0)) as Quantity,  " +
                                " q1.UnitPrice, q1.CostPrice, q1.TradePrice, q1.VATAmount, q1.ProductDiscount, q1.SalesPersonBonus,   " +
                                " q1.CustomerProfitMargin, q1.CustomerSellingExpense, q1.TradePromotion, q1.Advertisement, q1.RetailCommission,   " +
                                " q1.ProductWarrenty, q1.PrimaryFreightCost, q1.OtherProvission, q1.AdjustedDPAmount, q1.AdjustedPWAmount, q1.AdjustedTPAmount,   " +
                                " q1.PromotionalDiscount, q1.IsFreeProduct, q1.FreeQty, q2.ProductCode,q2.ProductName,q2.SmallUnitOfMeasure as SUOM, " +
                                " q2.LargeUnitOfMeasure as LUOM,q2.UOMConversionFactor, q2.ProductType, q2.LSRatio, q2.MSRatio from t_SalesInvoiceDetail q1, " +
                                " t_Product q2 WHERE q1.Productid = q2.Productid AND InvoiceID = ? ";


                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oItem = new rptSalesInvoiceDetail();

                    oItem.ProductCode = reader["ProductCode"].ToString();
                    oItem.ProductName = reader["ProductName"].ToString();
                    try
                    {
                        oItem.Quantity = Convert.ToDouble(reader["Quantity"].ToString());
                    }
                    catch
                    {
                        oItem.Quantity = 0;
                    }
                    oItem.SUOM = reader["SUOM"].ToString();
                    oItem.LUOM = reader["LUOM"].ToString();
                    try
                    {
                        oItem.LSRatio = Convert.ToInt64(reader["LSRatio"].ToString());
                    }
                    catch
                    {
                        oItem.LSRatio = 0;
                    }
                    try
                    {
                        oItem.UOMConversionFactor = Convert.ToDouble(reader["UOMConversionFactor"].ToString());
                    }
                    catch
                    {
                        oItem.UOMConversionFactor = 0;
                    }
                    try
                    {
                        oItem.FreeQty = int.Parse(reader["FreeQty"].ToString());
                    }
                    catch
                    {
                        oItem.FreeQty = 0;
                    }
                    try
                    {
                        oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    }
                    catch
                    {
                        oItem.UnitPrice = 0;
                    }
                    try
                    {
                        oItem.AdjustedTPAmount = Convert.ToDouble(reader["AdjustedTPAmount"].ToString());
                    }
                    catch
                    {
                        oItem.AdjustedTPAmount = 0;
                    }
                    try
                    {
                        oItem.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"].ToString());
                    }
                    catch
                    {
                        oItem.AdjustedPWAmount = 0;
                    }
                    try
                    {
                        oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"].ToString());
                    }
                    catch
                    {
                        oItem.AdjustedDPAmount = 0;
                    }
                    try
                    {
                        oItem.VATAmount = Convert.ToDouble(reader["VATAmount"].ToString());
                    }
                    catch
                    {
                        oItem.VATAmount = 0;
                    }
                    try
                    {
                        oItem.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    }
                    catch
                    {
                        oItem.TradePrice = 0;
                    }
                    try
                    {
                        oItem.PromotionalDiscount = Convert.ToDouble(reader["PromotionalDiscount"].ToString());
                    }
                    catch
                    {
                        oItem.PromotionalDiscount = 0;
                    }
                    oItem.ProductTypeID = int.Parse(reader["ProductType"].ToString());

                    for (int i = 0; i < 3; i++)
                    {
                        oItem.Copy = sCopy[i];

                    }
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());

                    if (Utility.CompanyInfo == "TML")
                    {
                        //for E-store
                        if (_WarehouseID == Utility.WebStore)
                        {
                            oItem.InboxItemName = InboxItem(oItem.ProductID);
                            oItem.IMEI = GetIMEI(oItem.ProductID, int.Parse(reader["InvoiceID"].ToString()));
                        }
                    }

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



        public void RefreshInvoiceItemByID(bool IsFree)
        {
            string sSQL = "";
            rptSalesInvoiceDetail oItem;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                sSQL = " SELECT * from t_SalesInvoiceDetail a, " +
                                " v_ProductDetails b WHERE a.Productid = b.Productid AND InvoiceID = ? ";

                if (IsFree)
                {
                    sSQL = sSQL + " and IsFreeProduct=" + (int)Dictionary.YesOrNoStatus.YES + " ";
                }
                else
                {
                    sSQL = sSQL + " and Quantity > 0 ";
                }

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oItem = new rptSalesInvoiceDetail();

                    oItem.ProductCode = reader["ProductCode"].ToString();
                    oItem.ProductName = reader["ProductName"].ToString();
                    try
                    {
                        oItem.Quantity = Convert.ToDouble(reader["Quantity"].ToString());
                    }
                    catch
                    {
                        oItem.Quantity = 0;
                    }
                    // New Code by Humayun 
                    try
                    {
                        oItem.FreeQty = Convert.ToInt16(reader["FreeQty"].ToString());
                    }
                    catch
                    {
                        oItem.FreeQty = 0;
                    }

                    oItem.TotalQty = oItem.Quantity + oItem.FreeQty;



                    oItem.SUOM = reader["SmallUnitOfMeasure"].ToString();
                    oItem.LUOM = reader["LargeUnitOfMeasure"].ToString();
                    try
                    {
                        oItem.LSRatio = Convert.ToInt64(reader["LSRatio"].ToString());
                    }
                    catch
                    {
                        oItem.LSRatio = 0;
                    }
                    try
                    {
                        oItem.UOMConversionFactor = Convert.ToDouble(reader["UOMConversionFactor"].ToString());
                    }
                    catch
                    {
                        oItem.UOMConversionFactor = 0;
                    }
                    try
                    {
                        oItem.IsFreeProduct = int.Parse(reader["IsFreeProduct"].ToString());
                    }
                    catch
                    {
                        oItem.IsFreeProduct = 0;
                    }
                    try
                    {
                        oItem.FreeQty = int.Parse(reader["FreeQty"].ToString());
                    }
                    catch
                    {
                        oItem.FreeQty = 0;
                    }
                    try
                    {
                        oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    }
                    catch
                    {
                        oItem.UnitPrice = 0;
                    }
                    try
                    {
                        oItem.AdjustedTPAmount = Convert.ToDouble(reader["AdjustedTPAmount"].ToString());
                    }
                    catch
                    {
                        oItem.AdjustedTPAmount = 0;
                    }
                    try
                    {
                        oItem.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"].ToString());
                    }
                    catch
                    {
                        oItem.AdjustedPWAmount = 0;
                    }
                    try
                    {
                        oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"].ToString());
                    }
                    catch
                    {
                        oItem.AdjustedDPAmount = 0;
                    }
                    try
                    {
                        oItem.VATAmount = Convert.ToDouble(reader["VATAmount"].ToString());
                    }
                    catch
                    {
                        oItem.VATAmount = 0;
                    }
                    try
                    {
                        oItem.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                    }
                    catch
                    {
                        oItem.TradePrice = 0;
                    }
                    try
                    {
                        oItem.PromotionalDiscount = Convert.ToDouble(reader["PromotionalDiscount"].ToString());
                    }
                    catch
                    {
                        oItem.PromotionalDiscount = 0;
                    }

                    oItem.GrossAmount = oItem.Quantity * oItem.UnitPrice;

                    oItem.NetAmount = oItem.GrossAmount - ((oItem.AdjustedDPAmount * oItem.Quantity) + (oItem.AdjustedTPAmount*oItem.Quantity) + (oItem.AdjustedPWAmount*oItem.Quantity));

                    oItem.ProductTypeID = int.Parse(reader["ProductType"].ToString());

                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());

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
        public string InboxItem(int nProductID)
        {           
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select * from t_InboxItem where ProductID=?";

                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                string sInboxItem = "";
                while (reader.Read())
                {
                    if (sInboxItem != "")
                    {
                        sInboxItem = sInboxItem + ", ";
                    }
                    sInboxItem = sInboxItem + reader["InboxItemName"].ToString();
                   
                }

                reader.Close();
                return sInboxItem;

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public string GetIMEI(int nProductID, int nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select ProductSerialNo from t_SalesInvoiceProductSerial Where ProductID=? AND InvoiceID=? ";

                cmd.Parameters.AddWithValue("ProductID", nProductID);
                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                string sInboxItem = "";
                while (reader.Read())
                {
                    if (sInboxItem != "")
                    {
                        sInboxItem = sInboxItem + ", ";
                    }
                    sInboxItem = sInboxItem + reader["ProductSerialNo"].ToString();

                }

                reader.Close();
                return sInboxItem;

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshByInvoiceID()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " select isnull(RefInvoiceID,-1) RefInvoiceID,isnull(b.NationalID,'') NationalID,InvoiceID, InvoiceNo,a.WarehouseID,InvoiceStatus,InvoiceDate, ConsumerName,isnull(a.DeliveryAddress,'') DeliveryAddress,isnull(b.Address,'') CustomerAddress,isnull(VatRegNo,'') TaxNo " +
                                  " from t_SalesInvoice a, t_RetailConsumer b where a.SundryCustomerID=b.ConsumerID and InvoiceID=?";


                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    _InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                   _sInvoiceNo = reader["InvoiceNo"].ToString();
                   _InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                   _sCustomerName = reader["ConsumerName"].ToString();
                   _sCustomerAddress = reader["CustomerAddress"].ToString();
                    _sDeliveryAddress = reader["DeliveryAddress"].ToString();
                    _sTaxNo = reader["TaxNo"].ToString();
                    _InvoiceStatus = Convert.ToInt16(reader["InvoiceStatus"]);
                   _WarehouseID = Convert.ToInt64(reader["WarehouseID"]);
                    _NationalID = reader["NationalID"].ToString();
                    _RefInvoiceID = (reader["RefInvoiceID"].ToString());
                    RefreshItemForRetailInvoice(_WarehouseID, _InvoiceStatus);

                }
                reader.Close();



            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshByInvoiceIDHOReport()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select isnull(RefInvoiceID,-1) RefInvoiceID,isnull(b.NationalID,'') NationalID,InvoiceID,  " +
                                "InvoiceNo,a.WarehouseID,InvoiceStatus,InvoiceDate, isnull(ConsumerName,CustomerName) as ConsumerName,  " +
                                "isnull(a.DeliveryAddress,CustomerAddress) DeliveryAddress,  " +
                                "isnull(b.Address,CustomerAddress) CustomerAddress,isnull(VatRegNo,TaxNo) TaxNo From   " +
                                "(  " +
                                "Select SundryCustomerID,isnull(RefInvoiceID,-1) RefInvoiceID,InvoiceID,   " +
                                "InvoiceNo,a.WarehouseID,InvoiceStatus,InvoiceDate, CustomerName,isnull(a.DeliveryAddress,'') DeliveryAddress,  " +
                                "CustomerAddress,isnull(b.TaxNumber,'') TaxNo From t_SalesInvoice a,t_Customer b  " +
                                "where a.CustomerID=b.CustomerID   " +
                                ") a  " +
                                "left outer join   " +
                                "(  " +
                                "Select * From t_RetailConsumer  " +
                                ") b  " +
                                "on a.SundryCustomerID=b.ConsumerID and a.WarehouseID=b.WarehouseID  " +
                                "where InvoiceID=?";


                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    _InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    _sInvoiceNo = reader["InvoiceNo"].ToString();
                    _InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _sCustomerName = reader["ConsumerName"].ToString();
                    _sCustomerAddress = reader["CustomerAddress"].ToString();
                    _sDeliveryAddress = reader["DeliveryAddress"].ToString();
                    _sTaxNo = reader["TaxNo"].ToString();
                    _InvoiceStatus = Convert.ToInt16(reader["InvoiceStatus"]);
                    _WarehouseID = Convert.ToInt64(reader["WarehouseID"]);
                    _NationalID = reader["NationalID"].ToString();
                    _RefInvoiceID = (reader["RefInvoiceID"].ToString());
                    RefreshItemForRetailInvoice(_WarehouseID, _InvoiceStatus);

                }
                reader.Close();



            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshByInvoiceIDHONew()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select isnull(a.SalesPersonID,-1) SalesPersonID,a.CustomerID,SundryCustomerID,InvoiceID, InvoiceNo,a.WarehouseID,InvoiceStatus, " +
                                "InvoiceDate, ConsumerName,Address,ShowroomName,ShowroomCode " +
                                "from t_SalesInvoice a, t_RetailConsumer b,t_Showroom c where a.SundryCustomerID=b.ConsumerID and a.WarehouseID=b.WarehouseID  " +
                                "and a.WarehouseID=c.WarehouseID and InvoiceID=?";


                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    _InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    _sInvoiceNo = reader["InvoiceNo"].ToString();
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _sCustomerName = reader["ConsumerName"].ToString();
                    _sCustomerAddress = reader["Address"].ToString();
                    _InvoiceStatus = Convert.ToInt16(reader["InvoiceStatus"]);
                    _WarehouseID = Convert.ToInt64(reader["WarehouseID"]);
                    _SundryCustomerID = Convert.ToInt32(reader["SundryCustomerID"]);
                    _CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    _SalesPersonID = Convert.ToInt32(reader["SalesPersonID"]);
                    _ShowRoomCode = reader["ShowroomCode"].ToString();
                    _ShowRoomName = reader["ShowroomName"].ToString();
                    //RefreshItemForRetailInvoice(_WarehouseID, _InvoiceStatus);

                }
                reader.Close();



            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshByInvoiceIDHO()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " select InvoiceID, InvoiceNo,a.WarehouseID,InvoiceStatus,InvoiceDate, ConsumerName,Address " +
                "from t_SalesInvoice a, t_RetailConsumer b where a.SundryCustomerID=b.ConsumerID and a.WarehouseID=b.WarehouseID and InvoiceID=?";


                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    _InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    _sInvoiceNo = reader["InvoiceNo"].ToString();
                    _InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _sCustomerName = reader["ConsumerName"].ToString();
                    _sCustomerAddress = reader["Address"].ToString();
                    _InvoiceStatus = Convert.ToInt16(reader["InvoiceStatus"]);
                    _WarehouseID = Convert.ToInt64(reader["WarehouseID"]);

                    RefreshItemForRetailInvoice(_WarehouseID, _InvoiceStatus);

                }
                reader.Close();



            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetInvoiceStatusByID(long nInvoiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " select * from t_SalesInvoice where InvoiceID=?";


                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    _InvoiceStatus = Convert.ToInt16(reader["InvoiceStatus"]);
                    
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public bool IsPartial()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            
            cmd.CommandText = " SELECT  count(DISTINCT  q2.producttype) from t_SalesInvoiceDetail q1, t_Product q2 WHERE q1.Productid = q2.Productid AND InvoiceID = ?";
            cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);                
            cmd.CommandType = CommandType.Text;
            object IsPartial = cmd.ExecuteScalar();

            try
            {
                if (int.Parse(IsPartial.ToString()) > 1)
                {
                    return true;

                }
                else return false;
            }
            catch
            {
                return false;
            }
          
        }
        public void RetailRefresh()
        {
         
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select a.*,isnull(ThanaDetail,'') ThanaDetail From  " +
                                "(  " +
                                "Select a.*, WarehouseCode, WarehouseName, CustomerCode, CustomerName, b.Shortcode, isnull(a.CustThanaID, ThanaID) as Thana  " +
                                "from t_SalesInvoice a, t_warehouse b, t_Customer c  " +
                                "Where a.warehouseid = b.warehouseid and a.CustomerID = c.CustomerID  " +
                                ") a  " +
                                "Left Outer Join  " +
                                "(  " +
                                "Select a.GeoLocationID as ThanaID,  " +
                                "'Thana: ' + a.GeoLocationName + ', District: ' + b.GeoLocationName as ThanaDetail  " +
                                "From t_GeoLocation a, t_GeoLocation b  " +
                                "where a.GeoLocationType = 2 and a.ParentID = b.GeoLocationID  " +
                                ") b  " +
                                "on a.Thana = b.ThanaID where InvoiceID = ?";

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);
            
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["SundryCustomerID"] != DBNull.Value)
                    {
                        _SundryCustomerID = Convert.ToInt64(reader["SundryCustomerID"].ToString());                      
                    }
                    else _SundryCustomerID = -1;
                    _CustomerID = (int)reader["CustomerID"];
                    _WarehouseID = (int)reader["WarehouseID"];
                    _sWarehouseName = reader["WarehouseName"].ToString();
                    _sWarehouseCode = reader["WarehouseCode"].ToString();
                    _InvoiceStatus = Convert.ToInt16(reader["InvoiceStatus"]);


                    if (reader["ThanaDetail"] != DBNull.Value)
                    {
                        _ThanaName = (string)reader["ThanaDetail"];
                    }
                    else
                    {
                        _ThanaName = "";
                    }

                    if (reader["RefInvoiceID"] != DBNull.Value)
                    {
                        _RefInvoiceID = (string)reader["RefInvoiceID"];
                    }
                    else
                    {
                        _RefInvoiceID = "";
                    }

                    if (reader["DeliveryAddress"] != DBNull.Value)
                    {
                        _sDeliveryAddress = (string)reader["DeliveryAddress"];
                    }
                    else
                    {
                        _sDeliveryAddress = "";
                    }

                    if (reader["Shortcode"] != DBNull.Value)
                    {
                        _sWarehouseShortcode = (reader["Shortcode"].ToString());

                    }
                    else _sWarehouseShortcode = "";
                    _sInvoiceNo = reader["InvoiceNo"].ToString();
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());                          
                    _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    _InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    _CustomerCode = (string)reader["CustomerCode"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _Remarks = reader["Remarks"].ToString();
                    if (reader["SalesPersonID"] != DBNull.Value)
                    {
                        _SalesPersonID = Convert.ToInt64(reader["SalesPersonID"]);
                    }
                    else
                    {
                        _SalesPersonID = -1;
                    }
                    
                    _bFlag = RefreshItemForRetailInvoice(_WarehouseID, _InvoiceStatus);

                }
                reader.Close();



            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public bool RefreshItemForRetailInvoice(long nWarehouseid, short nInvoiceStatus)
        {
            int nCount = 0;
            rptSalesInvoiceDetail oItem;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " SELECT q1.InvoiceID, q1.ProductID, (q1.Quantity) as Quantity, (q1.FreeQty) as FreeQty, " +
                                " q1.UnitPrice, q1.CostPrice, q1.TradePrice, q1.VATAmount, q1.ProductDiscount, q1.SalesPersonBonus,   " +
                                " q1.CustomerProfitMargin, q1.CustomerSellingExpense, q1.TradePromotion, q1.Advertisement, q1.RetailCommission,   " +
                                " q1.ProductWarrenty, q1.PrimaryFreightCost, q1.OtherProvission, q1.AdjustedDPAmount, q1.AdjustedPWAmount, q1.AdjustedTPAmount,q1.IsFreeProduct,   " +
                                " q1.PromotionalDiscount,q2.ProductCode,q2.ProductName,isnull(ProductDesc,ProductName) as ProductDesc,isnull(ProductModel,ProductName) as ProductModel,q2.SmallUnitOfMeasure as SUOM, q2.LargeUnitOfMeasure as LUOM, " +
                                " q2.UOMConversionFactor, q2.LSRatio, q2.MSRatio from t_SalesInvoiceDetail q1, v_Productdetails q2 WHERE q1.Productid = q2.Productid AND InvoiceID = ? ";


                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oItem = new rptSalesInvoiceDetail();

                    oItem.ProductCode = reader["ProductCode"].ToString();
                    oItem.ProductName = reader["ProductName"].ToString();
                    oItem.ProductDesc = reader["ProductDesc"].ToString();
                    oItem.ProductModel = reader["ProductModel"].ToString();
                    if (nInvoiceStatus == (short)Dictionary.InvoiceStatus.REVERSE)
                    {
                        try
                        {
                            oItem.Quantity = Convert.ToDouble(reader["Quantity"].ToString()) * -1;
                        }
                        catch
                        {
                            oItem.Quantity = 0 * -1;
                        }

                        oItem.SUOM = reader["SUOM"].ToString();
                        oItem.LUOM = reader["LUOM"].ToString();
                        try
                        {
                            oItem.LSRatio = Convert.ToInt64(reader["LSRatio"].ToString()) * -1;
                        }
                        catch
                        {
                            oItem.LSRatio = 0 * -1;
                        }
                        try
                        {
                            oItem.UOMConversionFactor = Convert.ToDouble(reader["UOMConversionFactor"].ToString()) * -1; 
                        }
                        catch
                        {
                            oItem.UOMConversionFactor = 0 * -1;
                        }
                        try
                        {
                            oItem.FreeQty = int.Parse(reader["FreeQty"].ToString()) * -1;
                        }
                        catch
                        {
                            oItem.FreeQty = 0 * -1;
                        }
                        try
                        {
                            oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                        }
                        catch
                        {
                            oItem.UnitPrice = 0;
                        }
                        try
                        {
                            oItem.AdjustedTPAmount = Convert.ToDouble(reader["AdjustedTPAmount"].ToString()) * -1;
                        }
                        catch
                        {
                            oItem.AdjustedTPAmount = 0 * -1;
                        }
                        try
                        {
                            oItem.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"].ToString()) * -1;
                        }
                        catch
                        {
                            oItem.AdjustedPWAmount = 0 * -1;
                        }
                        try
                        {
                            oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"].ToString()) * -1;
                        }
                        catch
                        {
                            oItem.AdjustedDPAmount = 0 * -1;
                        }
                        try
                        {
                            oItem.VATAmount = Convert.ToDouble(reader["VATAmount"].ToString()) * -1;
                        }
                        catch
                        {
                            oItem.VATAmount = 0 * -1;
                        }
                        try
                        {
                            oItem.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                        }
                        catch
                        {
                            oItem.TradePrice = 0;
                        }
                        try
                        {
                            oItem.IsFreeProduct = Convert.ToInt32(reader["IsFreeProduct"].ToString()) * -1;
                        }
                        catch
                        {
                            oItem.IsFreeProduct = 0 * -1;
                        }
                    }
                    else
                    {
                        try
                        {
                            oItem.Quantity = Convert.ToDouble(reader["Quantity"].ToString());
                        }
                        catch
                        {
                            oItem.Quantity = 0;
                        }

                        oItem.SUOM = reader["SUOM"].ToString();
                        oItem.LUOM = reader["LUOM"].ToString();
                        try
                        {
                            oItem.LSRatio = Convert.ToInt64(reader["LSRatio"].ToString());
                        }
                        catch
                        {
                            oItem.LSRatio = 0;
                        }
                        try
                        {
                            oItem.UOMConversionFactor = Convert.ToDouble(reader["UOMConversionFactor"].ToString());
                        }
                        catch
                        {
                            oItem.UOMConversionFactor = 0;
                        }
                        try
                        {
                            oItem.FreeQty = int.Parse(reader["FreeQty"].ToString());
                        }
                        catch
                        {
                            oItem.FreeQty = 0;
                        }
                        try
                        {
                            oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                        }
                        catch
                        {
                            oItem.UnitPrice = 0;
                        }
                        try
                        {
                            oItem.AdjustedTPAmount = Convert.ToDouble(reader["AdjustedTPAmount"].ToString());
                        }
                        catch
                        {
                            oItem.AdjustedTPAmount = 0;
                        }
                        try
                        {
                            oItem.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"].ToString());
                        }
                        catch
                        {
                            oItem.AdjustedPWAmount = 0;
                        }
                        try
                        {
                            oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"].ToString());
                        }
                        catch
                        {
                            oItem.AdjustedDPAmount = 0;
                        }
                        try
                        {
                            oItem.VATAmount = Convert.ToDouble(reader["VATAmount"].ToString());
                        }
                        catch
                        {
                            oItem.VATAmount = 0;
                        }
                        try
                        {
                            oItem.TradePrice = Convert.ToDouble(reader["TradePrice"].ToString());
                        }
                        catch
                        {
                            oItem.TradePrice = 0;
                        }
                        try
                        {
                            oItem.IsFreeProduct = Convert.ToInt32(reader["IsFreeProduct"].ToString());
                        }
                        catch
                        {
                            oItem.IsFreeProduct = 0;
                        }
                    }
                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());

                    if (int.Parse(reader["IsFreeProduct"].ToString()) == (int)Dictionary.YesOrNoStatus.YES)
                    {
                        nCount++;
                    }
                    
                    InnerList.Add(oItem);
                }

                reader.Close();

                InnerList.TrimToSize();
                if (nCount == 0)
                    return false;
                else return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetInvoiceCustomer()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " select qq1.* "
                                  +"  from "
                                  +" ( "
                                  +" select CustomerID,CustomerCode,CustomerName,CustomerAddress from t_Customer "
                                  +" ) as qq1 "
                                  +" inner join  "
                                  +" ( "
                                  +" select InvoiceID,CustomerID from t_SalesInvoice where invoiceid=? "
                                  +" ) as qq2 "
                                  +" on qq1.CustomerID=qq2.CustomerID ";

                cmd.Parameters.AddWithValue("InvoiceID", _InvoiceID);              
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    _CustomerID = int.Parse(reader["CustomerID"].ToString());
                    _sCustomerName = reader["CustomerName"].ToString();
                    _CustomerCode = reader["CustomerCode"].ToString();
                    _sCustomerAddress = reader["CustomerAddress"].ToString();
                    
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetPromotionDiscountByInvoiceID(long InvoID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select InvoiceID,Sum(PromotionalDiscount) as PromotionalDiscount from t_SalesInvoiceDetail "+
                                    "Where InvoiceID=? group by InvoiceID";


                cmd.Parameters.AddWithValue("InvoiceID", InvoID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    _PromotionalDiscount = Convert.ToDouble(reader["PromotionalDiscount"].ToString());

                }
                reader.Close();



            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
    public class rptSalesInvoices : CollectionBase
    {
        public rptSalesInvoice this[int i]
        {
            get { return (rptSalesInvoice)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(rptSalesInvoice orptSalesInvoice)
        {
            InnerList.Add(orptSalesInvoice);
        }
        public void Refresh(string sInvoiceID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " select qq1.*,qq2.UserName  as DeliveredByName,qq3.EmployeeName as SalesPersonName,CustomerAddress, CustomerTelePhone,CustomerFax " +
                               " ,CellPhoneNo, ContractPerson, CustomerTypeID as CustTypeID, CustomerTypeCode as CustTypeCode, CustomerTypeName as CustTypeName, AreaID, AreaCode, AreaName, TerritoryID,TerritoryCode, TerritoryName,OrderNo, OrderDate, SBUID, SBUCode, SBUName, InvoiceTypeName,DistrictID, DistrictCode, DistrictName, ThanaID, ThanaCode, ThanaName " +
                               " , OrderReceivedByID, OrderConfirmedByID,  OrderReceivedByName, OrderConfirmedByName " +
                               " , qq7.UserName as UpdateUserName,qq8.SundryCustomerName, qq8.Address as SCAddress, qq8.PhoneNo as SCPhoneNo , qq8.CellNo as SCCellNo, qq8.Email as SCEmail " +
                               " FROM  " +
                               " ( " +
                               " SELECT q1.*,q2.CustomerName,q2.CustomerCode,q3.WarehouseCode, q3.WarehouseName, q3.ChannelID,q5.ChannelCode, q5.ChannelDescription as ChannelName, q4.UserName as InvoiceByName,q6.CurrentBalance  FROM t_SalesInvoice q1,t_customer q2, t_warehouse q3, t_User q4, t_Channel q5,t_CustomerAccount q6 " +
                               " WHERE q1.customerid = q2.customerid and q1.customerid = q6.customerid and q1.warehouseid = q3.warehouseid AND InvoiceID in (" + sInvoiceID + ") AND q4.UserID = q1.InvoiceBy and q3.ChannelID = q5.ChannelID " +
                               " ) " +
                               " as qq1 Left outer Join " +
                               " ( " +
                               " select UserID, UserName from t_User " +
                               " ) " +
                               " as qq2 " +
                               " on qq1.DeliveredBy = qq2.UserID " +
                               " left outer join " +
                               " ( " +
                               " select AssignmentCode,JobTypeID,EmployeeName, q1.EmployeeID from t_EmployeeJobType q1, t_Employee q2  " +
                               " where q1.EmployeeID = q2.EmployeeID and  IsActive = ? and JobTypeID = ? " +
                               " ) " +
                               " as qq3 " +
                               " on qq1.SalesPersonID = qq3.EmployeeID " +
                               " left outer join " +
                               " ( " +
                               " select CustomerID, CustomerAddress, CustomerTelePhone,CustomerFax, CellPhoneNo, ContractPerson, CustomerTypeID, CustomerTypeCode, CustomerTypeName, AreaID, AreaCode, AreaName,TerritoryID, TerritoryCode, TerritoryName, SBUID, SBUCode, SBUName,DistrictID, DistrictCode, DistrictName, ThanaID, ThanaCode, ThanaName from v_customerDetails " +
                               " ) " +
                               " as qq4  " +
                               " on qq1.customerid = qq4.customerid " +
                               " Left outer join " +
                               " ( " +
                               " select q1.OrderID, q1.OrderNo, q1. OrderDate, q1.CreateUserID as OrderReceivedByID, q1.ConfirmUserID as OrderConfirmedByID,  q2.UserName as  OrderReceivedByName, q3.UserName as OrderConfirmedByName from " +
                               " ( " +
                               " select OrderID, OrderNo, OrderDate,CreateUserID, ConfirmUserID from t_salesOrder " +
                               " ) " +
                               " as q1 " +
                               " left outer join " +
                               " ( " +
                               " select UserID, UserName from t_User " +
                               " ) " +
                               " as q2 " +
                               " on q1.CreateUserID = q2.UserID " +
                               " left outer join " +
                               " ( " +
                               " select UserID, UserName from t_User " +
                               " ) " +
                               " as q3 " +
                               " on q1.ConfirmUserID = q3.UserID " +
                               " )  " +
                               " as qq5 " +
                               " on qq1.orderid = qq5.Orderid " +
                               " LEFT OUTER JOIN " +
                               " ( " +
                               " select InvoiceTypeID, InvoiceTypeName from t_invoicetype " +
                               " ) " +
                               " as qq6 " +
                               " on qq1.InvoiceTypeID = qq6.InvoiceTypeID " +
                               " LEFT OUTER JOIN " +
                               " ( " +
                               " select UserID, UserName from t_User " +
                               " ) " +
                               " as qq7 " +
                               " on qq1.UpdateUserID = qq7.UserID " +
                               " LEFT OUTER JOIN " +
                               " ( " +
                               " SELECT SundryCustomerID, SundryCustomerName, Address, PhoneNo, CellNo, Email FROM t_SundryCustomer" +
                               " ) " +
                               " as qq8 " +
                               " on qq1.SundryCustomerID = qq8.SundryCustomerID";
                
        
                cmd.Parameters.AddWithValue("IsActive", Dictionary.ActiveOrInActiveStatus.ACTIVE);
                cmd.Parameters.AddWithValue("JobTypeID", Dictionary.JobType.SALES_PERSONS);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    rptSalesInvoice orptSalesInvoice = new rptSalesInvoice();

                    if (reader["SundryCustomerID"] != DBNull.Value)
                    {
                        orptSalesInvoice.SundryCustomerID = Convert.ToInt64(reader["SundryCustomerID"].ToString());
                        orptSalesInvoice.SundryCustomerName = reader["SundryCustomerName"].ToString();
                        orptSalesInvoice.SCAddress = reader["SCAddress"].ToString();
                        orptSalesInvoice.SCCellNo = reader["SCCellNo"].ToString();
                        orptSalesInvoice.SCPhoneNo = reader["SCPhoneNo"].ToString();
                    }
                    else orptSalesInvoice.SundryCustomerID = -1;

                    orptSalesInvoice.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    orptSalesInvoice.CustomerName = reader["CustomerName"].ToString();
                    orptSalesInvoice.CustomerCode = reader["CustomerCode"].ToString();
                    orptSalesInvoice.CustomerAddress = reader["CustomerAddress"].ToString();
                    orptSalesInvoice.CustomerTelephone = reader["CustomerTelephone"].ToString();
                    orptSalesInvoice.CustTypeName = reader["CustTypeName"].ToString();
                    orptSalesInvoice.AreaName = reader["AreaName"].ToString();
                    orptSalesInvoice.TerritoryName = reader["TerritoryName"].ToString();
                    orptSalesInvoice.ThanaName = reader["ThanaName"].ToString();
                    orptSalesInvoice.DistrictName = reader["DistrictName"].ToString();
                    orptSalesInvoice.ChannelName = reader["ChannelName"].ToString();

                    orptSalesInvoice.WarehouseName = reader["WarehouseName"].ToString();
                    orptSalesInvoice.WarehouseCode = reader["WarehouseCode"].ToString();
                    orptSalesInvoice.InvoiceID = int.Parse(reader["InvoiceID"].ToString());
                    orptSalesInvoice.InvoiceNo = reader["InvoiceNo"].ToString();
                    orptSalesInvoice.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());

                    if (reader["DeliveryDate"] != DBNull.Value)
                        orptSalesInvoice.DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"].ToString());
                    else orptSalesInvoice.DeliveryDate = DateTime.Today;

                    orptSalesInvoice.OrderNo = reader["OrderNo"].ToString();
                    orptSalesInvoice.OrderConfirmedBy = reader["OrderConfirmedByName"].ToString();
                    orptSalesInvoice.InvoiceTypeID = int.Parse(reader["InvoiceTypeID"].ToString());
                    if (reader["OrderDate"] != DBNull.Value)
                        orptSalesInvoice.OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    orptSalesInvoice.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    orptSalesInvoice.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());
                    orptSalesInvoice.OrderConfirmeddByName = reader["OrderConfirmedByName"].ToString();
                    orptSalesInvoice.DeliveredByName = reader["DeliveredByName"].ToString();
                    orptSalesInvoice.Remarks = reader["Remarks"].ToString();
                    orptSalesInvoice.CustomerBalance = Convert.ToDouble(reader["CurrentBalance"].ToString());
                    if (reader["DueAmount"] != DBNull.Value)
                        orptSalesInvoice.DueAmount = Convert.ToDouble(reader["DueAmount"].ToString());
                    else orptSalesInvoice.DueAmount = 0;

                    try
                    {
                        orptSalesInvoice.VATChallanNo = Convert.ToInt64(reader["VATChallanNo"].ToString());
                    }
                    catch
                    {
                        orptSalesInvoice.VATChallanNo = 0;
                    }

                    orptSalesInvoice.RefreshItem();
                    InnerList.Add(orptSalesInvoice);
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

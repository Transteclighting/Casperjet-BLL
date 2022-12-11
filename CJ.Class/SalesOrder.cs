// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: May 03, 2011
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
using CJ.Class.Web.UI.Class;


namespace CJ.Class
{
    public class SalesOrderItem
    {
        private int _nOrderID;
        private double _UnitPrice;
        private int _nProductID;
        private int _nQuantity;
        private int _nConfirmQuantity;
        private double _AdjustedDPAmount;
        private double _AdjustedPWAmount;
        private double _AdjustedTPAmount;
        private double _PromotionalDiscount;
        private int _nIsFreeProduct;
        private int _nFreeQty;
        private Product _oProduct;
        public Product Product
        {
            get
            {
                if (_oProduct == null)
                {
                    _oProduct = new Product();
                  
                }
                return _oProduct;
            }
        }
        private int _nDBStock;
        private int _nStockNorm;

        private int _nReason;
        /// <summary>
        /// Get set property for Quantity
        /// </summary>
        public int Reason
        {
            get { return _nReason; }
            set { _nReason = value; }
        }

        /// <summary>
        /// Get set property for OrderID
        /// </summary>
        public int OrderID
        {
            get { return _nOrderID; }
            set { _nOrderID = value; }
        }
        /// <summary>
        /// Get set property for UnitPrice
        /// </summary>
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
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
        /// Get set property for Quantity
        /// </summary>
        public int Quantity
        {
            get { return _nQuantity; }
            set { _nQuantity = value; }
        }
        /// <summary>
        /// Get set property for ConfirmQuantity
        /// </summary>
        public int ConfirmQuantity
        {
            get { return _nConfirmQuantity; }
            set { _nConfirmQuantity = value; }
        }
        /// <summary>
        /// Get set property for AdjustedDPAmount
        /// </summary>
        public double AdjustedDPAmount
        {
            get { return _AdjustedDPAmount; }
            set { _AdjustedDPAmount = value; }
        }
        /// <summary>
        /// Get set property for AdjustedPWAmount
        /// </summary>
        public double AdjustedPWAmount
        {
            get { return _AdjustedPWAmount; }
            set { _AdjustedPWAmount = value; }
        }
        /// <summary>
        /// Get set property for AdjustedTPAmount
        /// </summary>
        public double AdjustedTPAmount
        {
            get { return _AdjustedTPAmount; }
            set { _AdjustedTPAmount = value; }
        }
        /// <summary>
        /// Get set property for PromotionalDiscount
        /// </summary>
        public double PromotionalDiscount
        {
            get { return _PromotionalDiscount; }
            set { _PromotionalDiscount = value; }
        }
        /// <summary>
        /// Get set property for IsFreeProduct
        /// </summary>
        public int IsFreeProduct
        {
            get { return _nIsFreeProduct; }
            set { _nIsFreeProduct = value; }
        }
        /// <summary>
        /// Get set property for FreeQty
        /// </summary>
        public int FreeQty
        {
            get { return _nFreeQty; }
            set { _nFreeQty = value; }
        }
        /// <summary>
        /// Get set property for Quantity
        /// </summary>
        public int DBStock
        {
            get { return _nDBStock; }
            set { _nDBStock = value; }
        }
        /// <summary>
        /// Get set property for Quantity
        /// </summary>
        public int StockNorm
        {
            get { return _nStockNorm; }
            set { _nStockNorm = value; }
        }

        private int _MStatus;
        public int MStatus
        {
            get { return _MStatus; }
            set { _MStatus = value; }
        }
        private int _LWSec;
        public int LWSec
        {
            get { return _LWSec; }
            set { _LWSec = value; }
        }
        private int _LWReq;
        public int LWReq
        {
            get { return _LWReq; }
            set { _LWReq = value; }
        }
        private int _MTDSec;
        public int MTDSec
        {
            get { return _MTDSec; }
            set { _MTDSec = value; }
        }
        private int _MTDReq;
        public int MTDReq
        {
            get { return _MTDReq; }
            set { _MTDReq = value; }
        }

        private double _TradePrice;
        public double TradePrice
        {
            get { return _TradePrice; }
            set { _TradePrice = value; }
        }

        private int _nAndroidOrderID;
        private int _nOrderQty;
        private int _nRevOrderQty;
        private int _nNOrderQty;
        private string _sProductCode;
        private string _sProductName;
        private double _GrossAmount;
        private double _NetAmount;

        /// <summary>
        /// Get set property for AndroidOrderID
        /// </summary>
        public int AndroidOrderID
        {
            get { return _nAndroidOrderID; }
            set { _nAndroidOrderID = value; }
        }
        /// <summary>
        /// Get set property for OrderQty
        /// </summary>
        public int OrderQty
        {
            get { return _nOrderQty; }
            set { _nOrderQty = value; }
        }
        /// <summary>
        /// Get set property for RevOrderQty
        /// </summary>
        public int RevOrderQty
        {
            get { return _nRevOrderQty; }
            set { _nRevOrderQty = value; }
        }
        /// <summary>
        /// Get set property for NOrderQty
        /// </summary>
        public int NOrderQty
        {
            get { return _nNOrderQty; }
            set { _nNOrderQty = value; }
        }
        /// <summary>
        /// Get set property for ProductCode
        /// </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        /// <summary>
        /// Get set property for ProductName
        /// </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
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

        public void Insert(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_SalesOrderDetail (OrderID,UnitPrice, ProductID, Quantity, ConfirmQuantity, AdjustedDPAmount, AdjustedPWAmount,AdjustedTPAmount,PromotionalDiscount,IsFreeProduct,FreeQty,Reason) VALUES (?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                cmd.Parameters.AddWithValue("ConfirmQuantity", _nConfirmQuantity);
                cmd.Parameters.AddWithValue("AdjustedDPAmount", _AdjustedDPAmount);
                cmd.Parameters.AddWithValue("AdjustedPWAmount", _AdjustedPWAmount);
                cmd.Parameters.AddWithValue("AdjustedTPAmount", _AdjustedTPAmount);
                cmd.Parameters.AddWithValue("PromotionalDiscount", _PromotionalDiscount);
                cmd.Parameters.AddWithValue("IsFreeProduct", _nIsFreeProduct);
                cmd.Parameters.AddWithValue("FreeQty", _nFreeQty);
                if (_nReason != -1)
                    cmd.Parameters.AddWithValue("Reason", _nReason);
                else cmd.Parameters.AddWithValue("Reason", null); 


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Add(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_SalesOrderDetail (OrderID,UnitPrice, ProductID, Quantity, ConfirmQuantity, AdjustedDPAmount, AdjustedPWAmount,AdjustedTPAmount,PromotionalDiscount,IsFreeProduct,FreeQty) VALUES (?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                cmd.Parameters.AddWithValue("ConfirmQuantity", _nConfirmQuantity);
                cmd.Parameters.AddWithValue("AdjustedDPAmount", _AdjustedDPAmount);
                cmd.Parameters.AddWithValue("AdjustedPWAmount", _AdjustedPWAmount);
                cmd.Parameters.AddWithValue("AdjustedTPAmount", _AdjustedTPAmount);
                cmd.Parameters.AddWithValue("PromotionalDiscount", _PromotionalDiscount);
                cmd.Parameters.AddWithValue("IsFreeProduct", _nIsFreeProduct);
                cmd.Parameters.AddWithValue("FreeQty", _nFreeQty);
                //if (_nReason != -1)
                //    cmd.Parameters.AddWithValue("Reason", _nReason);
                //else cmd.Parameters.AddWithValue("Reason", null);


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Update(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (_nIsFreeProduct == 0)
            {
                try
                {
                    cmd.CommandText = "Update t_SalesOrderDetail set ConfirmQuantity =?,PromotionalDiscount=? "
                                      + " Where OrderID=? and ProductID=? ";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("ConfirmQuantity", _nConfirmQuantity);
                    cmd.Parameters.AddWithValue("PromotionalDiscount", _PromotionalDiscount);
                
                    cmd.Parameters.AddWithValue("OrderID", nOrderID);
                    cmd.Parameters.AddWithValue("ProductID", _nProductID);


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            else
            {
                try
                {
                    cmd.CommandText = "INSERT INTO t_SalesOrderDetail (OrderID,UnitPrice, ProductID, Quantity, ConfirmQuantity, AdjustedDPAmount, AdjustedPWAmount,AdjustedTPAmount,PromotionalDiscount,IsFreeProduct,FreeQty) VALUES (?,?,?,?,?,?,?,?,?,?,?)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("OrderID", nOrderID);
                    cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);
                    cmd.Parameters.AddWithValue("ProductID", _nProductID);
                    cmd.Parameters.AddWithValue("Quantity", _nQuantity);
                    cmd.Parameters.AddWithValue("ConfirmQuantity", _nConfirmQuantity);
                    cmd.Parameters.AddWithValue("AdjustedDPAmount", _AdjustedDPAmount);
                    cmd.Parameters.AddWithValue("AdjustedPWAmount", _AdjustedPWAmount);
                    cmd.Parameters.AddWithValue("AdjustedTPAmount", _AdjustedTPAmount);
                    cmd.Parameters.AddWithValue("PromotionalDiscount", _PromotionalDiscount);
                    cmd.Parameters.AddWithValue("IsFreeProduct", _nIsFreeProduct);
                    cmd.Parameters.AddWithValue("FreeQty", _nFreeQty);


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }

            }
        }
        public void Delete(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_SalesOrderDetail Where OrderID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
    /// <summary>
    /// collection class for sales order item.
    /// 
    /// </summary>
    public class SalesOrder : CollectionBase
    {


        private int _nOrderID;
        private int _nOrderNo;
        private object _dOrderDate;
        private int _nCustomerID;
        private string _sDeliveryAddress;
        private int _nSalesPersonID;
        private object _dConfirmDate;
        private int _nOrderStatus;
        private string _sRemarks;
        private int _nCreateUserID;
        private int _nWarehouseID;
        private int _nConfirmUserID;
        private double _Discount;
        private double _DDAmount;
        private object _dDDDate;
        private string _sDDDetails;
        private int _nOrderTypeID;
        private int _nSalesPromotionID;
        private int _nUpdateUserID;
        private object _dUpdateDate;
        private string _sCustomerCode;
        private string _sCustomerName;
        private bool _bFlag;
        private bool _bIsUpdate;
        private int _nIsHODelivery;      
        public Customer _oCustomer;
        private CustomerDetail _oCustomerDetail;
        private User _oCreateUser;
        private User _oConfirmUser;
        private Warehouse _oWarehouse;
        private Employee _oEmployee;
        private SalesPromotion _oSalesPromotion;

        public CustomerDetail CustomerDetail
        {
            get
            {
                if (_oCustomerDetail == null)
                {
                    _oCustomerDetail = new CustomerDetail();
                    _oCustomerDetail.CustomerID = _nCustomerID;
                    _oCustomerDetail.RefreshForSalesOrder();
                }

                return _oCustomerDetail;
            }
        }    
        public Customer Customer
        {
            get
            {
                if (_oCustomer == null)
                {
                    _oCustomer = new Customer();                   
                    _oCustomer.CustomerID = _nCustomerID;                   
                    _oCustomer.RefreshForSalesOrder(_sCustomerCode, _sCustomerName);                   
                }              

                return _oCustomer;
            }
        }
        public User CreateUser
        {
            get
            {
                if (_oCreateUser == null)
                {
                    _oCreateUser = new User();                    
                    _oCreateUser.UserId = _nCreateUserID;
                    _oCreateUser.RefreshByUserID();
                }
                return _oCreateUser;
            }
        }
        public User ConfirmUser
        {
            get
            {
                if (_oConfirmUser == null)
                {
                    _oConfirmUser = new User();                   
                    _oConfirmUser.UserId = _nConfirmUserID;
                    _oConfirmUser.RefreshByUserID();
                }
                return _oConfirmUser;
            }
        }
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
        public Employee Employee
        {
            get
            {
                if (_oEmployee == null)
                {
                    _oEmployee = new Employee();                   
                    _oEmployee.EmployeeID = _nSalesPersonID;
                    _oEmployee.Refresh();
                }
                return _oEmployee;
            }
        }
        public SalesPromotion SalesPromotion
        {
            get
            {
                if (_oSalesPromotion == null)
                {
                    _oSalesPromotion = new SalesPromotion();
                }
                return _oSalesPromotion;
            }
        }

        private double _VATLowerLimit;
        private double _VATUpperLimit;
        public double VATLowerLimit
        {
            get { return _VATLowerLimit; }
            set { _VATLowerLimit = value; }
        }

        public double VATUpperLimit
        {
            get { return _VATUpperLimit; }
            set { _VATUpperLimit = value; }
        }
        private double _nCalculativeTradePrice;

        public double CalculativeTradePrice
        {
            get { return _nCalculativeTradePrice; }
            set { _nCalculativeTradePrice = value; }
        }

        private string _sStatusName;
        public string StatusName
        {
            get { return _sStatusName;}
            set { _sStatusName = value;}
        }

        /// <summary>
        /// Get set property for OrderID
        /// </summary>
        public int OrderID
        {
            get { return _nOrderID; }
            set { _nOrderID = value; }
        }
        /// <summary>
        /// Get set property for OrderNo
        /// </summary>
        public int OrderNo
        {
            get { return _nOrderNo; }
            set { _nOrderNo = value; }
        }
        /// <summary>
        /// Get set property for OrderDate
        /// </summary>
        public object OrderDate
        {
            get { return _dOrderDate; }
            set { _dOrderDate = value; }
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
        /// Get set property for DeliveryAddress
        /// </summary>
        public string DeliveryAddress
        {
            get { return _sDeliveryAddress; }
            set { _sDeliveryAddress = value.Trim(); }
        }
        /// <summary>
        /// Get set property for SalesPersonID
        /// </summary>
        public int SalesPersonID
        {
            get { return _nSalesPersonID; }
            set { _nSalesPersonID = value; }
        }
        /// <summary>
        /// Get set property for ConfirmDate
        /// </summary>
        public object ConfirmDate
        {
            get { return _dConfirmDate; }
            set { _dConfirmDate = value; }
        }
        /// <summary>
        /// Get set property for OrderStatus
        /// </summary>
        public int OrderStatus
        {
            get { return _nOrderStatus; }
            set { _nOrderStatus = value; }
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
        /// Get set property for WarehouseID
        /// </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }
        /// <summary>
        /// Get set property for ConfirmUserID
        /// </summary>
        public int ConfirmUserID
        {
            get { return _nConfirmUserID; }
            set { _nConfirmUserID = value; }
        }
        /// <summary>
        /// Get set property for Discount
        /// </summary>
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        /// <summary>
        /// Get set property for DDAmount
        /// </summary>
        public double DDAmount
        {
            get { return _DDAmount; }
            set { _DDAmount = value; }
        }
        /// <summary>
        /// Get set property for DDDate
        /// </summary>
        public object DDDate
        {
            get { return _dDDDate; }
            set { _dDDDate = value; }
        }
        /// <summary>
        /// Get set property for DDDetails
        /// </summary>
        public string DDDetails
        {
            get { return _sDDDetails; }
            set { _sDDDetails = value.Trim(); }
        }
        /// <summary>
        /// Get set property for OrderTypeID
        /// </summary>
        public int OrderTypeID
        {
            get { return _nOrderTypeID; }
            set { _nOrderTypeID = value; }
        }
        /// <summary>
        /// Get set property for SalesPromotionID
        /// </summary>
        /// 
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
        
        public int SalesPromotionID
        {
            get { return _nSalesPromotionID; }
            set { _nSalesPromotionID = value; }
        }
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }
        public object UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }
     
        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }
        public bool IsUpdate
        {
            get { return _bIsUpdate; }
            set { _bIsUpdate = value; }
        }
        public int IsHODelivery
        {
            get { return _nIsHODelivery; }
            set { _nIsHODelivery = value; }
        }
        private string _sInvoiceNo;
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }

        private int _nChannelID;
        public int ChannelID
        {
            get { return _nChannelID; }
            set { _nChannelID = value; }
        }
        private int _nWebInvoiceNo;
        public int WebInvoiceNo
        {
            get { return _nWebInvoiceNo; }
            set { _nWebInvoiceNo = value; }
        }

        private int _nSundryCustomerID;
        private string _sSundryCustomerName;
        private string _sAddress;
        private string _sPhoneNo;
        private string _sCellNo;
        private string _sEmail;

        public int SundryCustomerID
        {
            get { return _nSundryCustomerID; }
            set { _nSundryCustomerID = value; }
        }
        public string SundryCustomerName
        {
            get { return _sSundryCustomerName; }
            set { _sSundryCustomerName = value; }
        }
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }
        public string PhoneNo
        {
            get { return _sPhoneNo; }
            set { _sPhoneNo = value; }
        }
        public string CellNo
        {
            get { return _sCellNo; }
            set { _sCellNo = value; }
        }
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value; }
        }


        private int _nAndroidOrderID;
        private string _sAndroidOrderStatus;
        private string _sAndroidRemarks;
        private int _nIsComplete;
        private int _nTotalOrderQty;
        private double _TotalOrderValue;
        private int _nActualOrderID;

        public int AndroidOrderID
        {
            get { return _nAndroidOrderID; }
            set { _nAndroidOrderID = value; }
        }
        public string AndroidOrderStatus
        {
            get { return _sAndroidOrderStatus; }
            set { _sAndroidOrderStatus = value; }
        }
        public string AndroidRemarks
        {
            get { return _sAndroidRemarks; }
            set { _sAndroidRemarks = value; }
        }
        public int IsComplete
        {
            get { return _nIsComplete; }
            set { _nIsComplete = value; }
        }
        public int TotalOrderQty
        {
            get { return _nTotalOrderQty;}
            set { _nTotalOrderQty = value;}
        }
        public double TotalOrderValue
        {
            get { return _TotalOrderValue; }
            set { _TotalOrderValue = value; }
        }
        public int ActualOrderID
        {
            get { return _nActualOrderID; }
            set { _nActualOrderID = value; }
        }


        public SalesOrderItem this[int i]
        {
            get { return (SalesOrderItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SalesOrderItem oSalesOrderItem)
        {
            InnerList.Add(oSalesOrderItem);
        }

        public void Insert(bool IsWebModule)
        {
            int nMaxOrderID = 0;
            int nMaxOrderNo = 0;
            DateTime todate = DateTime.Today.Date;
            DateTime fromdate = todate.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([OrderID]) FROM t_SalesOrder";
                cmd.CommandText = sSql;
                object maxOrderID = cmd.ExecuteScalar();
                if (maxOrderID == DBNull.Value)
                {
                    nMaxOrderID = 1;
                }
                else
                {
                    nMaxOrderID = int.Parse(maxOrderID.ToString()) + 1;

                }
                _nOrderID = nMaxOrderID;
                
                /// Make order no             

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "select max( convert(int, (right(orderno,3)),1)) as MaxTranNo from t_salesorder " +
                       "where orderdate between ? and ? and orderdate < ? and len(orderno)=9";
                cmd.Parameters.AddWithValue("orderdate", todate);
                cmd.Parameters.AddWithValue("orderdate", fromdate);
                cmd.Parameters.AddWithValue("orderdate", fromdate);

                cmd.CommandText = sSql;
                object MaxTranNo = cmd.ExecuteScalar();
                if (MaxTranNo == DBNull.Value)
                {
                    nMaxOrderNo = 1;
                }
                else
                {
                    nMaxOrderNo = int.Parse(MaxTranNo.ToString()) + 1;

                }

                if (nMaxOrderNo == 1000)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    sSql = "select max( convert(int, (right(orderno,4)),1)) as MaxTranNo from t_salesorder " +
                      "where orderdate between ? and ? and orderdate < ? and len(orderno)=10";
                    cmd.Parameters.AddWithValue("orderdate", todate);
                    cmd.Parameters.AddWithValue("orderdate", fromdate);
                    cmd.Parameters.AddWithValue("orderdate", fromdate);

                    cmd.CommandText = sSql;
                    object MaxTran = cmd.ExecuteScalar();
                    if (MaxTranNo == DBNull.Value)
                    {
                        nMaxOrderNo = 1;
                    }
                    else
                    {
                        nMaxOrderNo = int.Parse(MaxTran.ToString()) + 1;

                    }
                    _nOrderNo = Convert.ToInt32(DateTime.Today.Date.ToString("yy") + DateTime.Today.Month.ToString("00") + DateTime.Today.Day.ToString("00") + nMaxOrderNo.ToString("0000"));
                }
                else
                {
                    _nOrderNo = Convert.ToInt32(DateTime.Today.Date.ToString("yy") + DateTime.Today.Month.ToString("00") + DateTime.Today.Day.ToString("00") + nMaxOrderNo.ToString("000"));
                }
                ///

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SalesOrder VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("OrderNo", _nOrderNo);
                cmd.Parameters.AddWithValue("OrderDate", _dOrderDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                if (_nSalesPersonID != -1)
                    cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                else cmd.Parameters.AddWithValue("SalesPersonID", null);               
                cmd.Parameters.AddWithValue("ConfirmDate", null);
                cmd.Parameters.AddWithValue("OrderStatus", 1);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ConfirmUserID", null);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("DDAmount", _DDAmount);
                cmd.Parameters.AddWithValue("DDDate", _dDDDate);
                cmd.Parameters.AddWithValue("DDDetails", _sDDDetails);
                cmd.Parameters.AddWithValue("OrderTypeID", _nOrderTypeID);
                if (_nSalesPromotionID != -1)
                    cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);
                else cmd.Parameters.AddWithValue("SalesPromotionID", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (Utility.CompanyInfo == "BLL")
                {
                    foreach (SalesOrderItem oItem in this)
                    {
                        oItem.Insert(_nOrderID);
                    }
                }
                else
                {

                    foreach (SalesOrderItem oItem in this)
                    {
                        oItem.Add(_nOrderID);
                    }
                }
                if (IsWebModule)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    cmd.CommandText = "INSERT INTO t_RetailOrderCheck VALUES(?,?,?)";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                    cmd.Parameters.AddWithValue("DeliveryPoint", _nIsHODelivery);
                    cmd.Parameters.AddWithValue("IsCheck", 0);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
              
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddOrder(DateTime dOrderDate)
        {
            int nMaxOrderID = 0;
            int nMaxOrderNo = 0;
            DateTime fromdate = dOrderDate;
            DateTime todate = fromdate.AddDays(1);

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([OrderID]) FROM t_SalesOrder";
                cmd.CommandText = sSql;
                object maxOrderID = cmd.ExecuteScalar();
                if (maxOrderID == DBNull.Value)
                {
                    nMaxOrderID = 1;
                }
                else
                {
                    nMaxOrderID = int.Parse(maxOrderID.ToString()) + 1;

                }
                _nOrderID = nMaxOrderID;

                /// Make order no             

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "select max( convert(int, (right(orderno,3)),1)) as MaxTranNo from t_salesorder " +
                       "where orderdate between ? and ? and orderdate < ? and len(orderno)=9";
                cmd.Parameters.AddWithValue("orderdate", fromdate);
                cmd.Parameters.AddWithValue("orderdate", todate);
                cmd.Parameters.AddWithValue("orderdate", todate);

                cmd.CommandText = sSql;
                object MaxTranNo = cmd.ExecuteScalar();
                if (MaxTranNo == DBNull.Value)
                {
                    nMaxOrderNo = 1;
                }
                else
                {
                    nMaxOrderNo = int.Parse(MaxTranNo.ToString()) + 1;

                }
                if (nMaxOrderNo == 1000)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    sSql = "select max( convert(int, (right(orderno,4)),1)) as MaxTranNo from t_salesorder " +
                      "where orderdate between ? and ? and orderdate < ? and len(orderno)=10";
                    cmd.Parameters.AddWithValue("orderdate", fromdate);
                    cmd.Parameters.AddWithValue("orderdate", todate);
                    cmd.Parameters.AddWithValue("orderdate", todate);

                    cmd.CommandText = sSql;
                    object MaxTran = cmd.ExecuteScalar();
                    if (MaxTran == DBNull.Value)
                    {
                        nMaxOrderNo = 1;
                    }
                    else
                    {
                        nMaxOrderNo = int.Parse(MaxTran.ToString()) + 1;

                    }
                    _nOrderNo = Convert.ToInt32(fromdate.Date.ToString("yy") + fromdate.Month.ToString("00") + fromdate.Day.ToString("00") + nMaxOrderNo.ToString("0000"));
                }
                else
                {
                    _nOrderNo = Convert.ToInt32(fromdate.Date.ToString("yy") + fromdate.Month.ToString("00") + fromdate.Day.ToString("00") + nMaxOrderNo.ToString("000"));
                }
                ///

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();            

                cmd.CommandText = "INSERT INTO t_SalesOrder VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("OrderNo", _nOrderNo);
                cmd.Parameters.AddWithValue("OrderDate", _dOrderDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                if (_nSalesPersonID != -1)
                    cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                else cmd.Parameters.AddWithValue("SalesPersonID", null);
                cmd.Parameters.AddWithValue("ConfirmDate", null);
                cmd.Parameters.AddWithValue("OrderStatus", _nOrderStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ConfirmUserID", null);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("DDAmount", _DDAmount);
                cmd.Parameters.AddWithValue("DDDate", _dDDDate);
                cmd.Parameters.AddWithValue("DDDetails", _sDDDetails);
                cmd.Parameters.AddWithValue("OrderTypeID", _nOrderTypeID);
                if (_nSalesPromotionID != -1)
                    cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);
                else cmd.Parameters.AddWithValue("SalesPromotionID", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (SalesOrderItem oItem in this)
                {
                    oItem.Insert(_nOrderID);
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Update()
        {
            int nCount = 1;
            OleDbCommand cmd = DBController.Instance.GetCommand();          

            try
            {
                cmd.CommandText = "update  t_SalesOrder set OrderDate=?,CustomerID=?,DeliveryAddress=?,SalesPersonID=?,Remarks=?,WarehouseID=?,Discount=?,DDAmount=?, " +
                    "DDDate=?,DDDetails=?,OrderTypeID=?,SalesPromotionID=?,UpdateUserID=?,UpdateDate=? where OrderID=?";

                cmd.CommandType = CommandType.Text;                
               
                cmd.Parameters.AddWithValue("OrderDate", _dOrderDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);               
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);                
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);               
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("DDAmount", _DDAmount);
                cmd.Parameters.AddWithValue("DDDate", _dDDDate);
                cmd.Parameters.AddWithValue("DDDetails", _sDDDetails);
                cmd.Parameters.AddWithValue("OrderTypeID", _nOrderTypeID);
                if (_nSalesPromotionID != -1)
                    cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);
                else cmd.Parameters.AddWithValue("SalesPromotionID", null);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
              
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (SalesOrderItem oItem in this)
                {
                    if (nCount == 1)
                    {
                        oItem.Delete(_nOrderID);
                        nCount++;
                    }
                    oItem.Insert(_nOrderID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AndroidUpdate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "update t_AndroidOrder set IsComplete=?, ActualOrderID=? where OrderID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsComplete", (int)Dictionary.AndroidOrderStatus.Complete);
                cmd.Parameters.AddWithValue("ActualOrderID", _nActualOrderID);

                cmd.Parameters.AddWithValue("OrderID", _nAndroidOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete(bool IsWebModule)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {              
               
                SalesOrderItem oItem = new SalesOrderItem();
                oItem.Delete(_nOrderID);          
              
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "Delete from  t_SalesOrder Where OrderID=? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (IsWebModule)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    cmd.CommandText = "Delete from t_RetailOrderCheck Where OrderID=? ";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("OrderID", _nOrderID);


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
        public void DeleteOrder(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from  t_SalesOrder Where OrderID=? ";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshSalesOrderItem()
        {
            InnerList.Clear();
            int IsFreeProduct = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesOrderDetail where OrderID= '" + _nOrderID + "' and IsNull(Quantity,0)+IsNull(ConfirmQuantity,0)>0 ";
               
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesOrderItem oItem = new SalesOrderItem();

                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());

                    if (reader["Quantity"] != DBNull.Value)
                    {
                        oItem.Quantity = int.Parse(reader["Quantity"].ToString());
                    }
                    else oItem.Quantity = 0;

                                        
                    if (reader["ConfirmQuantity"] != DBNull.Value)
                    {
                        oItem.ConfirmQuantity = int.Parse(reader["ConfirmQuantity"].ToString());
                    }
                    else oItem.ConfirmQuantity = 0;

                   
                    if (reader["AdjustedDPAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"].ToString());
                    }
                    else oItem.AdjustedDPAmount = 0;

                   
                    if (reader["AdjustedPWAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"].ToString());
                    }
                    else oItem.AdjustedPWAmount = 0;

                    if (reader["AdjustedTPAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedTPAmount = Convert.ToDouble(reader["AdjustedTPAmount"].ToString());
                    }
                    else oItem.AdjustedTPAmount = 0;
                  
                    if (reader["PromotionalDiscount"] != DBNull.Value)
                    {
                        oItem.PromotionalDiscount = Convert.ToDouble(reader["PromotionalDiscount"].ToString());
                    }
                    else oItem.PromotionalDiscount = 0;

                 
                    if (reader["IsFreeProduct"] != DBNull.Value)
                    {
                        oItem.IsFreeProduct = Convert.ToInt16(reader["IsFreeProduct"].ToString());
                    }
                    else oItem.IsFreeProduct = 0;
                   
                    if (reader["FreeQty"] != DBNull.Value)
                    {
                        oItem.FreeQty = int.Parse(reader["FreeQty"].ToString());
                    }
                    else oItem.FreeQty = 0;

                    oItem.Product.ProductID = oItem.ProductID;
                    oItem.Product.RefreshByProductID();
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
        public void RefreshOrderfromCustomerItem(int nAndroidOrderID)
        {
            InnerList.Clear();
            int IsFreeProduct = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select OrderID, ProductID, ProductCode, ProductName, OrderQty, RevOrderQty, NOrderQty,UnitPrice from ( " +
                                "Select AOD.OrderID, AOD.ProductID, ProductCode, ProductName, OrderQty, RevOrderQty,NOrderQty,NSP,RSP, SpecialPrice,CostPrice, " +
                                "TradePrice,MRP,  UnitPrice=CASE When PriceOptionID=1 then pd.NSP When PriceOptionID=2 then pd.RSP " +
                                "When PriceOptionID=3 then pd.SpecialPrice When PriceOptionID=4 then pd.CostPrice When PriceOptionID=5 then pd.TradePrice " +
                                "When PriceOptionID=6 then pd.MRP else 0 end from t_AndroidOrderDetail AOD INNER JOIN (select ProductID, ProductCode, " +
                                "ProductName, IsNull(NSP,0)NSP, IsNull(RSP,0)RSP, IsNull(SpecialPrice,0)SpecialPrice, IsNull(CostPrice,0)CostPrice, " +
                                "IsNull(TradePrice,0)TradePrice, IsNull(MRP,0)MRP from v_ProductDetails) as pd on pd.productid=aod.productid " +
                                "INNER JOIN t_AndroidOrder AO ON AO.OrderID=AOD.OrderID INNER JOIN t_customer c ON c.CustomerID=AO.CustomerID " +
                                "INNER JOIN t_CustomerTypeWisePriceSetting x On x.CustTypeID=c.CustTypeID)x Where OrderID=? ";
                cmd.Parameters.AddWithValue("OrderID", nAndroidOrderID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesOrderItem oItem = new SalesOrderItem();

                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (string)reader["ProductCode"];
                    oItem.ProductName = (string)reader["ProductName"];
                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    oItem.OrderQty = int.Parse(reader["OrderQty"].ToString());
                    oItem.RevOrderQty = int.Parse(reader["RevOrderQty"].ToString());
                    oItem.NOrderQty = int.Parse(reader["NOrderQty"].ToString());

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
        public void RefreshOrderfromCustomerItemBLL(int nAndroidOrderID)
        {
            InnerList.Clear();
            int IsFreeProduct = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = " Select OrderID, ProductID, ProductCode, ProductName, OrderQty, RevOrderQty, NOrderQty,UnitPrice from ( " +
               " Select AOD.OrderID, AOD.ProductID, ProductCode, ProductName, OrderQty, RevOrderQty,NOrderQty,NSP,RSP, SpecialPrice,CostPrice, " +
               " TradePrice, UnitPrice=CASE When PriceOptionID=1 then pd.NSP When PriceOptionID=2 then pd.RSP " +
               " When PriceOptionID=3 then pd.SpecialPrice When PriceOptionID=4 then pd.CostPrice When PriceOptionID=5 then pd.TradePrice " +
               " else 0 end from t_AndroidOrderDetail AOD INNER JOIN (select ProductID, ProductCode, " +
               " ProductName, IsNull(NSP,0)NSP, IsNull(RSP,0)RSP, IsNull(SpecialPrice,0)SpecialPrice, IsNull(CostPrice,0)CostPrice,  " +
               " IsNull(TradePrice,0)TradePrice from v_ProductDetails) as pd on pd.productid=aod.productid  " +
               " INNER JOIN t_AndroidOrder AO ON AO.OrderID=AOD.OrderID INNER JOIN t_customer c ON c.CustomerID=AO.CustomerID  " +
               " INNER JOIN t_CustomerTypeWisePriceSetting x On x.CustTypeID=c.CustTypeID)x Where OrderID= ?  ";



                cmd.Parameters.AddWithValue("OrderID", nAndroidOrderID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesOrderItem oItem = new SalesOrderItem();

                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (string)reader["ProductCode"];
                    oItem.ProductName = (string)reader["ProductName"];
                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    oItem.OrderQty = int.Parse(reader["OrderQty"].ToString());
                    oItem.RevOrderQty = int.Parse(reader["RevOrderQty"].ToString());
                    oItem.NOrderQty = int.Parse(reader["NOrderQty"].ToString());

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
        public void RefreshItem()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesOrderDetail where OrderID= '" + _nOrderID + "'";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesOrderItem oItem = new SalesOrderItem();

                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());

                    if (reader["Quantity"] != DBNull.Value)
                    {
                        oItem.Quantity = int.Parse(reader["Quantity"].ToString());
                    }
                    else oItem.Quantity = 0;


                    if (reader["ConfirmQuantity"] != DBNull.Value)
                    {
                        oItem.ConfirmQuantity = int.Parse(reader["ConfirmQuantity"].ToString());
                    }
                    else oItem.ConfirmQuantity = 0;


                    if (reader["AdjustedDPAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"].ToString());
                    }
                    else oItem.AdjustedDPAmount = 0;


                    if (reader["AdjustedPWAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"].ToString());
                    }
                    else oItem.AdjustedPWAmount = 0;

                    if (reader["AdjustedTPAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedTPAmount = Convert.ToDouble(reader["AdjustedTPAmount"].ToString());
                    }
                    else oItem.AdjustedTPAmount = 0;

                    if (reader["PromotionalDiscount"] != DBNull.Value)
                    {
                        oItem.PromotionalDiscount = Convert.ToDouble(reader["PromotionalDiscount"].ToString());
                    }
                    else oItem.PromotionalDiscount = 0;


                    if  (reader["IsFreeProduct"] != DBNull.Value)
                    {
                        oItem.IsFreeProduct = Convert.ToInt16(reader["IsFreeProduct"].ToString());
                    }
                    else oItem.IsFreeProduct = 0;

                    if (reader["FreeQty"] != DBNull.Value)
                    {
                        oItem.FreeQty = int.Parse(reader["FreeQty"].ToString());
                    }
                    else oItem.FreeQty = 0;

                    oItem.Product.ProductID = oItem.ProductID;
                    oItem.Product.RefreshByProductID();
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
        public void RefreshOrderItem(int nOrderStatus)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesOrderDetail where Quantity + ConfirmQuantity > 0 and OrderID= '" + _nOrderID + "'";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesOrderItem oItem = new SalesOrderItem();

                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());

                    if (reader["Quantity"] != DBNull.Value)
                    {
                        oItem.Quantity = int.Parse(reader["Quantity"].ToString());
                    }
                    else oItem.Quantity = 0;


                    if (reader["ConfirmQuantity"] != DBNull.Value)
                    {
                        oItem.ConfirmQuantity = int.Parse(reader["ConfirmQuantity"].ToString());
                    }
                    else oItem.ConfirmQuantity = 0;


                    if (reader["AdjustedDPAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"].ToString());
                    }
                    else oItem.AdjustedDPAmount = 0;


                    if (reader["AdjustedPWAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"].ToString());
                    }
                    else oItem.AdjustedPWAmount = 0;

                    if (reader["AdjustedTPAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedTPAmount = Convert.ToDouble(reader["AdjustedTPAmount"].ToString());
                    }
                    else oItem.AdjustedTPAmount = 0;

                    if (reader["PromotionalDiscount"] != DBNull.Value)
                    {
                        oItem.PromotionalDiscount = Convert.ToDouble(reader["PromotionalDiscount"].ToString());
                    }
                    else oItem.PromotionalDiscount = 0;


                    if (reader["IsFreeProduct"] != DBNull.Value)
                    {
                        oItem.IsFreeProduct = Convert.ToInt16(reader["IsFreeProduct"].ToString());
                    }
                    else oItem.IsFreeProduct = 0;

                    if (reader["FreeQty"] != DBNull.Value)
                    {
                        oItem.FreeQty = int.Parse(reader["FreeQty"].ToString());
                    }
                    else oItem.FreeQty = 0;

                    if (nOrderStatus == (int)Dictionary.OrderStatus.Confirmed || nOrderStatus == (int)Dictionary.OrderStatus.Invoiced)
                    {
                        oItem.GrossAmount = oItem.ConfirmQuantity * oItem.UnitPrice;
                    }
                    else
                    {
                        oItem.GrossAmount = oItem.Quantity * oItem.UnitPrice;
                    }
                    oItem.NetAmount = oItem.GrossAmount - (oItem.AdjustedDPAmount + oItem.AdjustedTPAmount + oItem.AdjustedPWAmount);

                    oItem.Product.ProductID = oItem.ProductID;
                    oItem.Product.RefreshByProductID();
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
        public void RefreshFreeQty()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select * from t_SalesOrderDetail Where IsFreeProduct=1 and OrderID= '" + _nOrderID + "'";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesOrderItem oItem = new SalesOrderItem();

                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());


                    if (reader["IsFreeProduct"] != DBNull.Value)
                    {
                        oItem.IsFreeProduct = Convert.ToInt16(reader["IsFreeProduct"].ToString());
                    }
                    else oItem.IsFreeProduct = 0;

                    if (reader["FreeQty"] != DBNull.Value)
                    {
                        oItem.FreeQty = int.Parse(reader["FreeQty"].ToString());
                    }
                    else oItem.FreeQty = 0;

                    oItem.Product.ProductID = oItem.ProductID;
                    oItem.Product.RefreshByProductID();
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
        public void CheckOrderNo(int sOrderNo)
        {
            int _nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesOrder where OrderNo =?";
                cmd.Parameters.AddWithValue("OrderNo", sOrderNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (_nCount ==1)
                _bFlag = true;
            else _bFlag = false;
        }
        public void Refresh(string sOrderNo,string sCustomerCode, string sCustomerName)
        {
            _sCustomerCode = sCustomerCode;
            _sCustomerName = sCustomerName;

            OleDbCommand cmd = DBController.Instance.GetCommand();
           
            string sSql = "SELECT * FROM t_SalesOrder where OrderID = '"+_nOrderID+"'";
            if (sOrderNo!= "")
            {
                sOrderNo = "%" + sOrderNo + "%";
                sSql = sSql + "and OrderNo like '" + sOrderNo + "'";
            }           
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {                 
                    _nOrderNo = int.Parse(reader["OrderNo"].ToString());
                    _dOrderDate = (object)reader["OrderDate"];
                    _nCustomerID = int.Parse(reader["CustomerID"].ToString());
                    _sDeliveryAddress = reader["DeliveryAddress"].ToString();

                    if (reader["SalesPersonID"] != DBNull.Value)
                    {
                        _nSalesPersonID = int.Parse(reader["SalesPersonID"].ToString());
                    }
                    else _nSalesPersonID = -1;

                    _dConfirmDate = (object)(reader["ConfirmDate"].ToString());
                    _nOrderStatus = int.Parse(reader["OrderStatus"].ToString());
                    _sRemarks = reader["Remarks"].ToString();

                    if (reader["CreateUserID"] != DBNull.Value)
                    {
                        _nCreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    }
                    else _nCreateUserID = -1;

                    if (reader["WarehouseID"] != DBNull.Value)
                    {
                        _nWarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    }
                    else _nWarehouseID = -1;

                    if (reader["ConfirmUserID"] != DBNull.Value)
                    {
                        _nConfirmUserID = int.Parse(reader["ConfirmUserID"].ToString());
                    }
                    else _nConfirmUserID = -1;

                    if (reader["Discount"] != DBNull.Value)
                    {
                        _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    }
                    else _Discount = 0;


                    if (reader["DDAmount"] != DBNull.Value)
                    {
                        _DDAmount = Convert.ToDouble(reader["DDAmount"].ToString());
                    }
                    else _DDAmount = 0;

                    _dDDDate = (object)reader["DDDate"];
                    _sDDDetails = (string)reader["DDDetails"].ToString();


                    if (reader["OrderTypeID"] != DBNull.Value)
                    {
                        _nOrderTypeID = int.Parse(reader["OrderTypeID"].ToString());
                    }
                    else _nOrderTypeID = 1;

                    if (reader["SalesPromotionID"] != DBNull.Value)
                    {
                        _nSalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                    }
                    else _nSalesPromotionID = -1;

                    RefreshSalesOrderItem();
                   
                }
                reader.Close();             

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
                cmd.CommandText = "update  t_SalesOrder set ConfirmDate=?,OrderStatus=?,ConfirmUserID=? where OrderID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConfirmDate", _dConfirmDate);
                cmd.Parameters.AddWithValue("OrderStatus", _nOrderStatus);
                cmd.Parameters.AddWithValue("ConfirmUserID", _nConfirmUserID);              

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (SalesOrderItem oItem in this)
                {                   
                    oItem.Update(_nOrderID);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void ConfirmStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "update t_SalesOrder set ConfirmDate=?,OrderStatus=?,ConfirmUserID=? where OrderID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ConfirmDate", _dConfirmDate);
                cmd.Parameters.AddWithValue("OrderStatus", _nOrderStatus);
                cmd.Parameters.AddWithValue("ConfirmUserID", _nConfirmUserID);

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);

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
                cmd.CommandText = "update  t_SalesOrder set OrderStatus=? where OrderID=?";

                cmd.CommandType = CommandType.Text;
               
                cmd.Parameters.AddWithValue("OrderStatus", _nOrderStatus);
               
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateOrderID(long nOrderID,long nInvoiceID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "update t_SalesInvoice set OrderID=? where InvoiceID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", nOrderID);

                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT *  FROM t_SalesOrder where  OrderID=" + nOrderID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                   _nOrderID = int.Parse(reader["OrderID"].ToString());
                    _nOrderNo = int.Parse(reader["OrderNo"].ToString());
                    _dOrderDate = (object)reader["OrderDate"];
                    _nCustomerID = int.Parse(reader["CustomerID"].ToString());
                    _sDeliveryAddress = reader["DeliveryAddress"].ToString();

                    if (reader["SalesPersonID"] != DBNull.Value)
                    {
                        _nSalesPersonID = int.Parse(reader["SalesPersonID"].ToString());
                    }
                    else _nSalesPersonID = -1;
                    if (reader["ConfirmDate"] != DBNull.Value)
                        _dConfirmDate = (object)(reader["ConfirmDate"].ToString());
                    else _dConfirmDate = null;
                    _nOrderStatus = int.Parse(reader["OrderStatus"].ToString());
                    _sRemarks = reader["Remarks"].ToString();

                    if (reader["CreateUserID"] != DBNull.Value)
                    {
                        _nCreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    }
                    else _nCreateUserID = -1;

                    if (reader["WarehouseID"] != DBNull.Value)
                    {
                        _nWarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    }
                    else _nWarehouseID = -1;

                    if (reader["ConfirmUserID"] != DBNull.Value)
                    {
                        _nConfirmUserID = int.Parse(reader["ConfirmUserID"].ToString());
                    }
                    else _nConfirmUserID = -1;

                    if (reader["Discount"] != DBNull.Value)
                    {
                        _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    }
                    else _Discount = 0;

                    if (reader["DDAmount"] != DBNull.Value)
                    {
                        _DDAmount = Convert.ToDouble(reader["DDAmount"].ToString());
                    }
                    else _DDAmount = 0;
                    if (reader["DDDate"] != null)
                    {
                        _dDDDate = (object)reader["DDDate"];
                    }
                    else
                    {
                        _dDDDate = null;
                    }
                    _sDDDetails = (string)reader["DDDetails"].ToString();


                    if (reader["OrderTypeID"] != DBNull.Value)
                    {
                        _nOrderTypeID = int.Parse(reader["OrderTypeID"].ToString());
                    }
                    else _nOrderTypeID = 1;

                    if (reader["SalesPromotionID"] != DBNull.Value)
                    {
                        _nSalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                        if (_nSalesPromotionID == 0)
                            _nSalesPromotionID = -1;

                    }
                    else _nSalesPromotionID = -1;

                    CustomerDetail.RefreshForSalesOrder();
                    Warehouse.WarehouseID = _nWarehouseID;
                    Warehouse.Refresh();
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
        /// Buffer Stock Table added by Shuvo 06-Dec-2015
        /// </summary>
        //public void RefreshSalesOrderItemForBLL(int nCustomerID,int nOrderID)
        //{
        //    InnerList.Clear();
        //    int IsFreeProduct = 0;
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    try
        //    {
        //        cmd.CommandText = "Select * From  "+
        //                       " (Select OrderID,xxx.CustomerID,xxx.ProductID,UnitPrice,Quantity,ConfirmQuantity,  "+
        //                       " AdjustedDPAmount,AdjustedPWAmount,AdjustedTPAmount,PromotionalDiscount,IsFreeProduct,FreeQty,isnull (CRStock,0) DBSTK,isnull(StockNorm,0) StockNorm From   " +
        //                       " (SELECT a.OrderID,CustomerID,ProductID,UnitPrice,Quantity,ConfirmQuantity,  "+
        //                       " AdjustedDPAmount,AdjustedPWAmount,AdjustedTPAmount,PromotionalDiscount,IsFreeProduct,FreeQty  "+
        //                       " FROM t_SalesOrderDetail a,t_SalesOrder b  "+
        //                       " where a.OrderID=b.OrderID and IsNull(Quantity,0)+IsNull(ConfirmQuantity,0)>0) xxx   "+
        //                       " Left Outer Join  "+
        //                       " (Select * From (Select CustomerID=Case when xx.CustomerID is NULL then yy.CustomerID else xx.CustomerID end,   "+
        //                       " ProductID=Case when xx.ProductID is NULL then yy.ProductID else xx.ProductID end,  "+
        //                       " isnull(StockNorm,0) StockNorm,isnull(CRStock,0) CRStock From  "+
        //                       " (Select * From (Select b.CustomerID,a.ProductID,BufferStock as StockNorm  "+
        //                       " From t_BufferStock a,t_Customer b,t_Product c  "+
        //                       " where a.CustomerID=b.CustomerID and a.ProductID=c.ProductID) b) xx  "+
        //                       " full Outer Join   "+
        //                       " (Select * From (Select b.CustomerID,a.ProductID,CurrentStock as CRStock  "+
        //                       " From t_DMSProductStock a,t_Customer b,t_Product c  "+
        //                       " where a.DistributorID=b.CustomerID and a.ProductID=c.ProductID) a) yy  " +
        //                       " on xx.CustomerID=yy.CustomerID and xx.ProductID=yy.ProductID) xx) yyy  " +
        //                       " on xxx.CustomerID=yyy.CustomerID and xxx.ProductID=yyy.ProductID ) Final where  CustomerID=" + nCustomerID + " and OrderID=" + nOrderID + " ";

        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            SalesOrderItem oItem = new SalesOrderItem();

        //            oItem.ProductID = int.Parse(reader["ProductID"].ToString());
        //            oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());

        //            if (reader["Quantity"] != DBNull.Value)
        //            {
        //                oItem.Quantity = int.Parse(reader["Quantity"].ToString());
        //            }
        //            else oItem.Quantity = 0;


        //            if (reader["ConfirmQuantity"] != DBNull.Value)
        //            {
        //                oItem.ConfirmQuantity = int.Parse(reader["ConfirmQuantity"].ToString());
        //            }
        //            else oItem.ConfirmQuantity = 0;


        //            if (reader["AdjustedDPAmount"] != DBNull.Value)
        //            {
        //                oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"].ToString());
        //            }
        //            else oItem.AdjustedDPAmount = 0;


        //            if (reader["AdjustedPWAmount"] != DBNull.Value)
        //            {
        //                oItem.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"].ToString());
        //            }
        //            else oItem.AdjustedPWAmount = 0;

        //            if (reader["AdjustedTPAmount"] != DBNull.Value)
        //            {
        //                oItem.AdjustedTPAmount = Convert.ToDouble(reader["AdjustedTPAmount"].ToString());
        //            }
        //            else oItem.AdjustedTPAmount = 0;

        //            if (reader["PromotionalDiscount"] != DBNull.Value)
        //            {
        //                oItem.PromotionalDiscount = Convert.ToDouble(reader["PromotionalDiscount"].ToString());
        //            }
        //            else oItem.PromotionalDiscount = 0;


        //            if (reader["IsFreeProduct"] != DBNull.Value)
        //            {
        //                oItem.IsFreeProduct = Convert.ToInt16(reader["IsFreeProduct"].ToString());
        //            }
        //            else oItem.IsFreeProduct = 0;

        //            if (reader["FreeQty"] != DBNull.Value)
        //            {
        //                oItem.FreeQty = int.Parse(reader["FreeQty"].ToString());
        //            }
        //            else oItem.FreeQty = 0;

        //            if (reader["DBSTK"] != DBNull.Value)
        //            {
        //                oItem.DBStock = int.Parse(reader["DBSTK"].ToString());
        //            }
        //            else oItem.DBStock = 0;

        //            if (reader["StockNorm"] != DBNull.Value)
        //            {
        //                oItem.StockNorm = int.Parse(reader["StockNorm"].ToString());
        //            }
        //            else oItem.StockNorm = 0;

        //            oItem.Product.ProductID = oItem.ProductID;
        //            oItem.Product.RefreshByProductID();
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
        public void RefreshSalesOrderItemForBLL(int nCustomerID, int nOrderID)
        {
            InnerList.Clear();
            int IsFreeProduct = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                //cmd.CommandText = "select MasterQuery.*, isnull(MStatus, 0) as MStatus,isnull(LWSec, 0) as LWSec,isnull(LWReq, 0) as LWReq,  " +
                //                "isnull(MTDSec, 0)As MTDSec, isnull(MTDReq,0)as MTDReq  " +
                //                "from  " +
                //                "(  " +
                //                "Select * From  " +
                //                "(Select OrderID, xxx.CustomerID, xxx.ProductID, UnitPrice, Quantity, ConfirmQuantity,  " +
                //                "AdjustedDPAmount, AdjustedPWAmount, AdjustedTPAmount, PromotionalDiscount, IsFreeProduct, FreeQty, isnull(CRStock, 0) DBSTK, isnull(StockNorm, 0) StockNorm From  " +
                //                "(SELECT a.OrderID, CustomerID, ProductID, UnitPrice, Quantity, ConfirmQuantity,  " +
                //                "AdjustedDPAmount, AdjustedPWAmount, AdjustedTPAmount, PromotionalDiscount, IsFreeProduct, FreeQty  " +
                //                "FROM t_SalesOrderDetail a, t_SalesOrder b  " +
                //                "where a.OrderID = b.OrderID and IsNull(Quantity, 0) + IsNull(ConfirmQuantity, 0) > 0) xxx  " +
                //                "Left Outer Join  " +
                //                "(Select * From  " +
                //                "(  " +
                //                "Select CustomerID = Case when xx.CustomerID is NULL then yy.CustomerID else xx.CustomerID end,  " +
                //                "ProductID = Case when xx.ProductID is NULL then yy.ProductID else xx.ProductID end,  " +
                //                "isnull(StockNorm, 0) StockNorm, isnull(CRStock, 0) CRStock From  " +
                //                "(Select * From(Select b.CustomerID, a.ProductID, BufferStock as StockNorm  " +
                //                "From t_BufferStock a, t_Customer b, t_Product c  " +
                //                "where a.CustomerID = b.CustomerID and a.ProductID = c.ProductID) b) xx  " +
                //                "full Outer Join  " +
                //                "(Select * From(Select b.CustomerID, a.ProductID, CurrentStock as CRStock  " +
                //                "From t_DMSProductStock a, t_Customer b, t_Product c  " +
                //                "where a.DistributorID = b.CustomerID and a.ProductID = c.ProductID) a) yy  " +
                //                "on xx.CustomerID = yy.CustomerID and xx.ProductID = yy.ProductID) xx) yyy  " +
                //                "on xxx.CustomerID = yyy.CustomerID and xxx.ProductID = yyy.ProductID  " +
                //                ") Final where  CustomerID = " + nCustomerID + "   and OrderID = " + nOrderID + "  " +
                //                ")As MasterQuery  " +
                //                "left outer join  " +
                //                "(  " +
                //                //---------------------New Query for Order----------------  "+
                //                "select SalesQty.ProductID, isnull(MovingTypeID, 0) as MStatus,  " +
                //                "isnull(LWPri, 0) as LWPri, isnull(LWSec, 0) as LWSec, isnull((LWSec - LWPri), 0) as LWReq,  " +
                //                "isnull(MTDPri, 0) as MTDPri, isnull(MTDSec, 0)As MTDSec, isnull((MTDSec - MTDPri), 0) as MTDReq  " +
                //                "from  " +
                //                "(  " +
                //                "select ProductID, sum(LWPri) as LWPri, sum(MTDPri)As MTDPri, sum(LWSec) as LWSec, sum(MTDSec) as MTDSec  " +
                //                "from  " +
                //                "(  " +
                //                //------------Last week & MTD Sec------  "+
                //                "select ProductID, 0 as LWPri, 0 as MTDPri, sum(Qty) as LWSec, 0 as MTDSec  " +
                //                "from t_DMSproductTran a, t_DMSproductTranItem b  " +
                //                "where DistributorID = " + nCustomerID + " and TranTypeID = 2 and a.TranID = b.TranID  " +
                //                "and TranDate >= (select Fromdate from dbo.t_CalendarWeek where WeekNo = ( select (WeekNo - 1) as Week from dbo.t_CalendarWeek where fromdate <= getdate() and Todate >= getdate())  and Cyear = year(getdate()))  " +
                //                "and TranDate <= (select Todate from dbo.t_CalendarWeek where WeekNo = ( select (WeekNo - 1) as Week from dbo.t_CalendarWeek where fromdate <= getdate() and Todate >= getdate())  " +
                //                "and Cyear = year(getdate()) )    " +
                //                "and DistributorID = " + nCustomerID + "  " +
                //                "group by ProductID  " +
                //                "union all  " +
                //                "select ProductID,0 as LWPri, 0 as MTDPri, 0 as LWSec,sum(Qty) as MTDSec  " +
                //                "from t_DMSproductTran a, t_DMSproductTranItem b  " +
                //                "where DistributorID = " + nCustomerID + " and TranTypeID = 2 and a.TranID = b.TranID  " +
                //                "and TranDate between DATEADD(mm, DATEDIFF(mm,0, GETDATE()),0) and DATEADD(mm,+1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0)) and TranDate< DATEADD(mm, +1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0))  " +
                //                "and DistributorID = " + nCustomerID + "  " +
                //                "group by ProductID  " +
                //                //------------Last week &MTD Sec End------  "+
                //                "union all  " +
                //                //---------- - Last weeek and MTD Primary-----  "+
                //                "select ProductID, isnull(sum(QtySA) - sum(QtyRA), 0) as LWPri, 0 as MTDPri, 0 as LWSec, 0 as MTDSec  " +
                //                "from  " +
                //                "(  " +
                //                "select ProductID, sum(Quantity) as QtySA, 0 as QtyRA  " +
                //                "from t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c  " +
                //                "where b.InvoiceID = c.InvoiceID and  InvoicetypeID in (1, 2, 4, 5) and invoiceStatus not in (3)  " +
                //                "and Invoicedate>= (select Fromdate from dbo.t_CalendarWeek where WeekNo = (select(WeekNo - 1) as Week from dbo.t_CalendarWeek where fromdate <= getdate() and Todate >= getdate())  and Cyear = year(getdate()) )    " +
                //                "and Invoicedate <= (select Todate from dbo.t_CalendarWeek where WeekNo = (select(WeekNo - 1) as Week from dbo.t_CalendarWeek where fromdate <= getdate() and Todate >= getdate())  and Cyear = year(getdate()) )     " +
                //                "and CustomerID = " + nCustomerID + "  " +
                //                "group by  ProductID  " +
                //                "union all  " +
                //                "select ProductID, 0 as QtySA,  sum(Quantity) as QtyRA  " +
                //                "from t_salesinvoiceDetail b, t_salesinvoice c  " +
                //                "where b.InvoiceID = c.InvoiceID and InvoicetypeID in (6,7,9,10,12) and invoiceStatus not in (3)  " +
                //                "and Invoicedate>= (select Fromdate from dbo.t_CalendarWeek where WeekNo = (select(WeekNo - 1) as Week from dbo.t_CalendarWeek where fromdate <= getdate() and Todate >= getdate())  and Cyear = year(getdate()) )    " +
                //                "and Invoicedate <= (select Todate from dbo.t_CalendarWeek where WeekNo = (select(WeekNo - 1) as Week from dbo.t_CalendarWeek where fromdate <= getdate() and Todate >= getdate())  and Cyear = year(getdate()) )     " +
                //                "and CustomerID = " + nCustomerID + "  " +
                //                "group by  ProductID  " +
                //                ") as b  " +
                //                "group by ProductID  " +
                //                "union all  " +
                //                "select ProductID, 0 as LWPri, isnull(sum(QtySA) - sum(QtyRA), 0) as MTDPri, 0 as LWSec, 0 as MTDSec  " +
                //                "from  " +
                //                "(  " +
                //                "select ProductID, sum(Quantity) as QtySA, 0 as QtyRA  " +
                //                "from t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c  " +
                //                "where b.InvoiceID = c.InvoiceID and  InvoicetypeID in (1, 2, 4, 5) and invoiceStatus not in (3)  " +
                //                "and Invoicedate between DATEADD(mm, DATEDIFF(mm,0, GETDATE()),0) and DATEADD(mm,+1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0)) and Invoicedate< DATEADD(mm, +1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0))  " +
                //                "and CustomerID = " + nCustomerID + "  " +
                //                "group by  ProductID  " +
                //                "union all  " +
                //                "select ProductID, 0 as QtySA,  sum(Quantity) as QtyRA  " +
                //                "from t_salesinvoiceDetail b, t_salesinvoice c  " +
                //                "where b.InvoiceID = c.InvoiceID and InvoicetypeID in (6,7,9,10,12) and invoiceStatus not in (3)  " +
                //                "and Invoicedate  between DATEADD(mm, DATEDIFF(mm,0, GETDATE()),0) and DATEADD(mm,+1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0)) and Invoicedate< DATEADD(mm, +1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0))  " +
                //                "and CustomerID = " + nCustomerID + "  " +
                //                "group by  ProductID  " +
                //                ") as b  " +
                //                "group by ProductID  " +
                //                //---------- - Last weeek and MTD Primary-----
                //                ")As PriSec group by ProductID  " +
                //                ")As SalesQty  " +
                //                "left outer join  " +
                //                "(select ProductID, MovingTypeID from t_productMovingStatus) as MStatus on SalesQty.ProductID = MStatus.ProductID  " +
                //                ")As Child on MasterQuery.ProductID = Child.ProductID";


                cmd.CommandText = "select MasterQuery.*, isnull(MStatus, 0) as MStatus,isnull(LWSec, 0) as LWSec,isnull(LWReq, 0) as LWReq,  " +
                                "isnull(MTDSec, 0)As MTDSec, isnull(MTDReq,0)as MTDReq  " +
                                "from  " +
                                "(  " +
                                "Select * From  " +
                                "(Select OrderID, xxx.CustomerID, xxx.ProductID, UnitPrice, Quantity, ConfirmQuantity,  " +
                                "AdjustedDPAmount, AdjustedPWAmount, AdjustedTPAmount, PromotionalDiscount, IsFreeProduct, FreeQty, isnull(CRStock, 0) DBSTK, isnull(StockNorm, 0) StockNorm From  " +
                                "(SELECT a.OrderID, CustomerID, ProductID, UnitPrice, Quantity, ConfirmQuantity,  " +
                                "AdjustedDPAmount, AdjustedPWAmount, AdjustedTPAmount, PromotionalDiscount, IsFreeProduct, FreeQty  " +
                                "FROM t_SalesOrderDetail a, t_SalesOrder b  " +
                                "where a.OrderID = b.OrderID and IsNull(Quantity, 0) + IsNull(ConfirmQuantity, 0) > 0) xxx  " +
                                "Left Outer Join  " +
                                "(Select * From  " +
                                "(  " +
                                "Select CustomerID = Case when xx.CustomerID is NULL then yy.CustomerID else xx.CustomerID end,  " +
                                "ProductID = Case when xx.ProductID is NULL then yy.ProductID else xx.ProductID end,  " +
                                "isnull(StockNorm, 0) StockNorm, isnull(CRStock, 0) CRStock From  " +
                                "(Select * From(Select b.CustomerID, a.ProductID, BufferStock as StockNorm  " +
                                "From t_BufferStock a, t_Customer b, t_Product c  " +
                                "where a.CustomerID = b.CustomerID and a.ProductID = c.ProductID) b) xx  " +
                                "full Outer Join  " +
                                "(Select * From(Select b.CustomerID, a.ProductID, CurrentStock as CRStock  " +
                                "From t_DMSProductStock a, t_Customer b, t_Product c  " +
                                "where a.DistributorID = b.CustomerID and a.ProductID = c.ProductID) a) yy  " +
                                "on xx.CustomerID = yy.CustomerID and xx.ProductID = yy.ProductID) xx) yyy  " +
                                "on xxx.CustomerID = yyy.CustomerID and xxx.ProductID = yyy.ProductID  " +
                                ") Final where  CustomerID = " + nCustomerID + "   and OrderID = " + nOrderID + "  " +
                                ")As MasterQuery  " +
                                "left outer join  " +
                                "(  " +
                                //---------------------New Query for Order----------------  "+
                                "select SalesQty.ProductID, isnull(MovingTypeID, 0) as MStatus,  " +
                                "isnull(LWPri, 0) as LWPri, isnull(LWSec, 0) as LWSec, isnull((LWSec - LWPri), 0) as LWReq,  " +
                                "isnull(MTDPri, 0) as MTDPri, isnull(MTDSec, 0)As MTDSec, isnull((MTDSec - MTDPri), 0) as MTDReq  " +
                                "from  " +
                                "(  " +
                                "select ProductID, sum(LWPri) as LWPri, sum(MTDPri)As MTDPri, sum(LWSec) as LWSec, sum(MTDSec) as MTDSec  " +
                                "from  " +
                                "(  " +
                                //------------Last week & MTD Sec------  "+
                                "select ProductID, 0 as LWPri, 0 as MTDPri, sum(Qty) as LWSec, 0 as MTDSec  " +
                                "from t_DMSproductTran a, t_DMSproductTranItem b  " +
                                "where DistributorID = " + nCustomerID + " and TranTypeID = 2 and a.TranID = b.TranID  " +
                                "and TranDate >= DATEADD(dd,DATEDIFF(dd,0,GETDATE()),-7) " +
                                "and TranDate < DATEADD(dd,DATEDIFF(dd,0,GETDATE()),0) " +
                                "and DistributorID = " + nCustomerID + "  " +
                                "group by ProductID  " +
                                "union all  " +
                                "select ProductID,0 as LWPri, 0 as MTDPri, 0 as LWSec,sum(Qty) as MTDSec  " +
                                "from t_DMSproductTran a, t_DMSproductTranItem b  " +
                                "where DistributorID = " + nCustomerID + " and TranTypeID = 2 and a.TranID = b.TranID  " +
                                "and TranDate between DATEADD(mm, DATEDIFF(mm,0, GETDATE()),0) and DATEADD(mm,+1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0)) and TranDate< DATEADD(mm, +1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0))  " +
                                "and DistributorID = " + nCustomerID + "  " +
                                "group by ProductID  " +
                                //------------Last week &MTD Sec End------  "+
                                "union all  " +
                                //---------- - Last weeek and MTD Primary-----  "+
                                "select ProductID, isnull(sum(QtySA) - sum(QtyRA), 0) as LWPri, 0 as MTDPri, 0 as LWSec, 0 as MTDSec  " +
                                "from  " +
                                "(  " +
                                "select ProductID, sum(Quantity) as QtySA, 0 as QtyRA  " +
                                "from t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c  " +
                                "where b.InvoiceID = c.InvoiceID and  InvoicetypeID in (1, 2, 4, 5) and invoiceStatus not in (3)  " +
                                "and Invoicedate> = DATEADD(dd,DATEDIFF(dd,0,GETDATE()),-7)   " +
                                "and Invoicedate < DATEADD(dd,DATEDIFF(dd,0,GETDATE()),0)   " +
                                "and CustomerID = " + nCustomerID + "  " +
                                "group by  ProductID  " +
                                "union all  " +
                                "select ProductID, 0 as QtySA,  sum(Quantity) as QtyRA  " +
                                "from t_salesinvoiceDetail b, t_salesinvoice c  " +
                                "where b.InvoiceID = c.InvoiceID and InvoicetypeID in (6,7,9,10,12) and invoiceStatus not in (3)  " +
                                "and Invoicedate>= DATEADD(dd,DATEDIFF(dd,0,GETDATE()),-7)   " +
                                "and Invoicedate < DATEADD(dd,DATEDIFF(dd,0,GETDATE()),0)      " +
                                "and CustomerID = " + nCustomerID + "  " +
                                "group by  ProductID  " +
                                ") as b  " +
                                "group by ProductID  " +
                                "union all  " +
                                "select ProductID, 0 as LWPri, isnull(sum(QtySA) - sum(QtyRA), 0) as MTDPri, 0 as LWSec, 0 as MTDSec  " +
                                "from  " +
                                "(  " +
                                "select ProductID, sum(Quantity) as QtySA, 0 as QtyRA  " +
                                "from t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c  " +
                                "where b.InvoiceID = c.InvoiceID and  InvoicetypeID in (1, 2, 4, 5) and invoiceStatus not in (3)  " +
                                "and Invoicedate between DATEADD(mm, DATEDIFF(mm,0, GETDATE()),0) and DATEADD(mm,+1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0)) and Invoicedate< DATEADD(mm, +1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0))  " +
                                "and CustomerID = " + nCustomerID + "  " +
                                "group by  ProductID  " +
                                "union all  " +
                                "select ProductID, 0 as QtySA,  sum(Quantity) as QtyRA  " +
                                "from t_salesinvoiceDetail b, t_salesinvoice c  " +
                                "where b.InvoiceID = c.InvoiceID and InvoicetypeID in (6,7,9,10,12) and invoiceStatus not in (3)  " +
                                "and Invoicedate  between DATEADD(mm, DATEDIFF(mm,0, GETDATE()),0) and DATEADD(mm,+1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0)) and Invoicedate< DATEADD(mm, +1, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0))  " +
                                "and CustomerID = " + nCustomerID + "  " +
                                "group by  ProductID  " +
                                ") as b  " +
                                "group by ProductID  " +
                                //---------- - Last weeek and MTD Primary-----
                                ")As PriSec group by ProductID  " +
                                ")As SalesQty  " +
                                "left outer join  " +
                                "(select ProductID, MovingTypeID from t_productMovingStatus) as MStatus on SalesQty.ProductID = MStatus.ProductID  " +
                                ")As Child on MasterQuery.ProductID = Child.ProductID";





                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesOrderItem oItem = new SalesOrderItem();

                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());

                    if (reader["Quantity"] != DBNull.Value)
                    {
                        oItem.Quantity = int.Parse(reader["Quantity"].ToString());
                    }
                    else oItem.Quantity = 0;


                    if (reader["ConfirmQuantity"] != DBNull.Value)
                    {
                        oItem.ConfirmQuantity = int.Parse(reader["ConfirmQuantity"].ToString());
                    }
                    else oItem.ConfirmQuantity = 0;


                    if (reader["AdjustedDPAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"].ToString());
                    }
                    else oItem.AdjustedDPAmount = 0;


                    if (reader["AdjustedPWAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"].ToString());
                    }
                    else oItem.AdjustedPWAmount = 0;

                    if (reader["AdjustedTPAmount"] != DBNull.Value)
                    {
                        oItem.AdjustedTPAmount = Convert.ToDouble(reader["AdjustedTPAmount"].ToString());
                    }
                    else oItem.AdjustedTPAmount = 0;

                    if (reader["PromotionalDiscount"] != DBNull.Value)
                    {
                        oItem.PromotionalDiscount = Convert.ToDouble(reader["PromotionalDiscount"].ToString());
                    }
                    else oItem.PromotionalDiscount = 0;


                    if (reader["IsFreeProduct"] != DBNull.Value)
                    {
                        oItem.IsFreeProduct = Convert.ToInt16(reader["IsFreeProduct"].ToString());
                    }
                    else oItem.IsFreeProduct = 0;

                    if (reader["FreeQty"] != DBNull.Value)
                    {
                        oItem.FreeQty = int.Parse(reader["FreeQty"].ToString());
                    }
                    else oItem.FreeQty = 0;

                    if (reader["DBSTK"] != DBNull.Value)
                    {
                        oItem.DBStock = int.Parse(reader["DBSTK"].ToString());
                    }
                    else oItem.DBStock = 0;

                    if (reader["StockNorm"] != DBNull.Value)
                    {
                        oItem.StockNorm = int.Parse(reader["StockNorm"].ToString());
                    }
                    else oItem.StockNorm = 0;

                    if (reader["MStatus"] != DBNull.Value)
                    {
                        oItem.MStatus = int.Parse(reader["MStatus"].ToString());
                    }
                    else oItem.MStatus = 0;

                    if (reader["LWSec"] != DBNull.Value)
                    {
                        oItem.LWSec = int.Parse(reader["LWSec"].ToString());
                    }
                    else oItem.LWSec = 0;

                    if (reader["LWReq"] != DBNull.Value)
                    {
                        oItem.LWReq = int.Parse(reader["LWReq"].ToString());
                    }
                    else oItem.LWReq = 0;

                    if (reader["MTDSec"] != DBNull.Value)
                    {
                        oItem.MTDSec = int.Parse(reader["MTDSec"].ToString());
                    }
                    else oItem.MTDSec = 0;

                    if (reader["MTDReq"] != DBNull.Value)
                    {
                        oItem.MTDReq = int.Parse(reader["MTDReq"].ToString());
                    }
                    else oItem.MTDReq = 0;

                    oItem.Product.ProductID = oItem.ProductID;

                    oItem.Product.RefreshByProductID();
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


    /// <summary>
    /// 
    /// Collection class for SalesOrder Class.
    /// 
    /// </summary>

    public class SalesOrders : CollectionBase 
    {
        public SalesOrder this[int i]
        {
            get { return (SalesOrder)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SalesOrder oSalesOrder)
        {
            InnerList.Add(oSalesOrder);
        }

        public void Refresh( DateTime dFromDate,DateTime dToDate,string OrderNo,int OrderSatus,int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate=dToDate.AddDays(1);
            //string sSql = "SELECT * FROM t_SalesOrder where OrderDate between '" + dFromDate + "' and '" + dToDate + "' and OrderDate < '" + dToDate + "'";

            //string sSql = "SELECT *  FROM t_SalesOrder "
            //  + " where  OrderDate between '" + dFromDate + "' and '" + dToDate + "' and OrderDate < '" + dToDate + "' and "
            //  + " customerid in "
            //  + " ( "
            //  + " select a.customerid from t_customer a ,t_UserPermissionData b "
            //  + " where b.DataID=a.CustomerID and b.UserID= '" + nUserID + "' and DataType='Customer' "
            //  + " ) ";

            string sSql = "SELECT SO.*,IsNull(SI.InvoiceNo,'')as InvoiceNo FROM t_SalesOrder SO Left OUter JOIN (Select OrderID,InvoiceNo from t_SalesInvoice) SI " +
                            "ON SO.OrderID=SI.OrderID where  OrderDate between ? and ? and OrderDate < ? and "+
                           " customerid in ( select a.customerid from t_customer a ,t_UserPermissionData b "+
                           " where b.DataID=a.CustomerID and SO.WarehouseID= ? and DataType='Customer' "+
                           " ) ";

            cmd.Parameters.AddWithValue("OrderDate", dFromDate);
            cmd.Parameters.AddWithValue("OrderDate", dToDate);
            cmd.Parameters.AddWithValue("OrderDate", dToDate);
            cmd.Parameters.AddWithValue("WarehouseID", nWarehouseID);

            if (OrderNo != "")
            {
                OrderNo = "%" + OrderNo + "%";
                sSql = sSql + "and OrderNo like '" + OrderNo + "'";
            }
            if (OrderSatus>0)
            {
                sSql = sSql + "and OrderStatus='" + OrderSatus + "'";
            }
            try
            {
                cmd.CommandText = sSql;               
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesOrder oSalesOrder = new SalesOrder();

                    oSalesOrder.OrderID = int.Parse(reader["OrderID"].ToString());
                    oSalesOrder.InvoiceNo = (string)reader["InvoiceNo"];
                    oSalesOrder.OrderNo = int.Parse( reader["OrderNo"].ToString());
                    oSalesOrder.OrderDate = (object)reader["OrderDate"];
                    oSalesOrder.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oSalesOrder.DeliveryAddress = reader["DeliveryAddress"].ToString();

                    if (reader["SalesPersonID"] != DBNull.Value)
                    {
                        oSalesOrder.SalesPersonID = int.Parse(reader["SalesPersonID"].ToString());
                    }
                    else oSalesOrder.SalesPersonID = -1;

                    oSalesOrder.ConfirmDate = (object)(reader["ConfirmDate"].ToString());
                    oSalesOrder.OrderStatus = int.Parse( reader["OrderStatus"].ToString());
                    oSalesOrder.Remarks = reader["Remarks"].ToString();

                    if (reader["CreateUserID"] != DBNull.Value)
                    {
                         oSalesOrder.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    }
                    else  oSalesOrder.CreateUserID= -1;
                    
                    if (reader["WarehouseID"] != DBNull.Value)
                    {
                       oSalesOrder.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    }
                    else oSalesOrder.WarehouseID = -1;
                   
                    if (reader["ConfirmUserID"] != DBNull.Value)
                    {
                        oSalesOrder.ConfirmUserID = int.Parse(reader["ConfirmUserID"].ToString());
                    }
                    else oSalesOrder.ConfirmUserID = -1;
                   
                    if (reader["Discount"] != DBNull.Value)
                    {
                        oSalesOrder.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    }
                    else oSalesOrder.Discount = 0;

                   
                    if (reader["DDAmount"] != DBNull.Value)
                    {
                        oSalesOrder.DDAmount = Convert.ToDouble( reader["DDAmount"].ToString());
                    }
                    else oSalesOrder.DDAmount = 0;

                    oSalesOrder.DDDate = (object)reader["DDDate"];
                    oSalesOrder.DDDetails = (string)reader["DDDetails"].ToString();

                  
                    if (reader["OrderTypeID"] != DBNull.Value)
                    {
                        oSalesOrder.OrderTypeID = int.Parse( reader["OrderTypeID"].ToString());
                    }
                    else oSalesOrder.OrderTypeID = 1;
                   
                    if (reader["SalesPromotionID"] != DBNull.Value)
                    {
                        oSalesOrder.SalesPromotionID = int.Parse( reader["SalesPromotionID"].ToString());
                        if (oSalesOrder.SalesPromotionID == 0)
                            oSalesOrder.SalesPromotionID = -1;

                    }
                    else oSalesOrder.SalesPromotionID = -1;                 
                    
                    oSalesOrder.RefreshSalesOrderItem();                 

                    InnerList.Add(oSalesOrder);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            
        }
        public void RefreshEcommerce(DateTime dFromDate, DateTime dToDate, string OrderNo, string sCustomerName, int OrderSatus)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "SELECT SO.*,IsNull(SI.InvoiceNo,'')as InvoiceNo, sc.*, cd.ChannelID, eo.WebInvoiceNo, OrderStatusName=CASE When OrderStatus=1 then 'Received' " +
                            "When OrderStatus=2 then 'Confirmed' When OrderStatus=3 then 'Pending' When OrderStatus=4 then 'Canceled' " +
                            "When OrderStatus=5 then 'Invoiced' When OrderStatus=6 then 'Reject_Due_To_Less_Credit' " +
                            "When OrderStatus=7 then 'Cancle_Due_To_Less_Stock' else 'Others' end FROM t_SalesOrder SO Left Outer JOIN " +
                            "(Select OrderID,InvoiceNo from t_SalesInvoice) SI ON SO.OrderID=SI.OrderID  INNER JOIN t_EcommerceOrder eo " +
                            "INNER JOIN t_SundryCustomer sc ON sc.SundryCustomerID=eo.SundryCustID ON eo.OrderID=So.OrderID " +
                            "INNER JOIN (select ChannelID, customerID from v_customerdetails )cd ON CD.CustomerID=SO.CustomerID "+
                            "where OrderDate between ? and ? and OrderDate < ? ";

            cmd.Parameters.AddWithValue("OrderDate", dFromDate);
            cmd.Parameters.AddWithValue("OrderDate", dToDate);
            cmd.Parameters.AddWithValue("OrderDate", dToDate);

            if (OrderNo != "")
            {
                OrderNo = "%" + OrderNo + "%";
                sSql = sSql + "and OrderNo like '" + OrderNo + "'";
            }
            if (sCustomerName != "")
            {
                sCustomerName = "%" + sCustomerName + "%";
                sSql = sSql + "and SundryCustomerName like '" + sCustomerName + "'";
            }
            if (OrderSatus > 0)
            {
                sSql = sSql + "and OrderStatus='" + OrderSatus + "'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesOrder oSalesOrder = new SalesOrder();

                    oSalesOrder.OrderID = int.Parse(reader["OrderID"].ToString());
                    oSalesOrder.InvoiceNo = (string)reader["InvoiceNo"];
                    oSalesOrder.OrderNo = int.Parse(reader["OrderNo"].ToString());
                    oSalesOrder.OrderDate = (object)reader["OrderDate"];
                    oSalesOrder.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oSalesOrder.DeliveryAddress = reader["DeliveryAddress"].ToString();

                    if (reader["SalesPersonID"] != DBNull.Value)
                    {
                        oSalesOrder.SalesPersonID = int.Parse(reader["SalesPersonID"].ToString());
                    }
                    else oSalesOrder.SalesPersonID = -1;

                    oSalesOrder.ConfirmDate = (object)(reader["ConfirmDate"].ToString());
                    oSalesOrder.OrderStatus = int.Parse(reader["OrderStatus"].ToString());
                    oSalesOrder.Remarks = reader["Remarks"].ToString();

                    if (reader["CreateUserID"] != DBNull.Value)
                    {
                        oSalesOrder.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    }
                    else oSalesOrder.CreateUserID = -1;

                    if (reader["WarehouseID"] != DBNull.Value)
                    {
                        oSalesOrder.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    }
                    else oSalesOrder.WarehouseID = -1;

                    if (reader["ConfirmUserID"] != DBNull.Value)
                    {
                        oSalesOrder.ConfirmUserID = int.Parse(reader["ConfirmUserID"].ToString());
                    }
                    else oSalesOrder.ConfirmUserID = -1;

                    if (reader["Discount"] != DBNull.Value)
                    {
                        oSalesOrder.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    }
                    else oSalesOrder.Discount = 0;


                    if (reader["DDAmount"] != DBNull.Value)
                    {
                        oSalesOrder.DDAmount = Convert.ToDouble(reader["DDAmount"].ToString());
                    }
                    else oSalesOrder.DDAmount = 0;

                    oSalesOrder.DDDate = (object)reader["DDDate"];
                    oSalesOrder.DDDetails = (string)reader["DDDetails"].ToString();


                    if (reader["OrderTypeID"] != DBNull.Value)
                    {
                        oSalesOrder.OrderTypeID = int.Parse(reader["OrderTypeID"].ToString());
                    }
                    else oSalesOrder.OrderTypeID = 1;

                    if (reader["SalesPromotionID"] != DBNull.Value)
                    {
                        oSalesOrder.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                        if (oSalesOrder.SalesPromotionID == 0)
                            oSalesOrder.SalesPromotionID = -1;

                    }
                    else oSalesOrder.SalesPromotionID = -1;
                    oSalesOrder.ChannelID = (int)reader["ChannelID"];
                    oSalesOrder.WebInvoiceNo = (int)reader["WebInvoiceNo"];
                    oSalesOrder.StatusName = (string)reader["OrderStatusName"];
                    oSalesOrder.SundryCustomerID=(int)reader["SundryCustomerID"];
                    oSalesOrder.SundryCustomerName=(string)reader["SundryCustomerName"];
                    oSalesOrder.Address=(string)reader["Address"];
                    oSalesOrder.PhoneNo=(string)reader["PhoneNo"];
                    oSalesOrder.CellNo=(string)reader["CellNo"];
                    oSalesOrder.Email=(string)reader["Email"];

                    oSalesOrder.RefreshSalesOrderItem();

                    InnerList.Add(oSalesOrder);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetAllData(DateTime dFromDate, DateTime dToDate, string OrderNo, int OrderSatus, string sCustomerCode, string sCustomerName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            //string sSql = "SELECT * FROM t_SalesOrder where OrderDate between '" + dFromDate + "' and '" + dToDate + "' and OrderDate < '" + dToDate + "'";

            string sSql = "SELECT *  FROM t_SalesOrder "
                          + " where  OrderDate between '" + dFromDate + "' and '" + dToDate + "' and OrderDate < '" + dToDate + "'";                       

            if (OrderNo != "")
            {
                OrderNo = "%" + OrderNo + "%";
                sSql = sSql + "and OrderNo like '" + OrderNo + "'";
            }
            if (OrderSatus > 0)
            {
                sSql = sSql + "and OrderStatus='" + OrderSatus + "'";
            }
            sSql = sSql + " order by OrderID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesOrder oSalesOrder = new SalesOrder();

                    oSalesOrder.OrderID = int.Parse(reader["OrderID"].ToString());
                    oSalesOrder.OrderNo = int.Parse(reader["OrderNo"].ToString());
                    oSalesOrder.OrderDate = (object)reader["OrderDate"];
                    oSalesOrder.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oSalesOrder.DeliveryAddress = reader["DeliveryAddress"].ToString();

                    if (reader["SalesPersonID"] != DBNull.Value)
                    {
                        oSalesOrder.SalesPersonID = int.Parse(reader["SalesPersonID"].ToString());
                    }
                    else oSalesOrder.SalesPersonID = -1;

                    oSalesOrder.ConfirmDate = (object)(reader["ConfirmDate"].ToString());
                    oSalesOrder.OrderStatus = int.Parse(reader["OrderStatus"].ToString());
                    oSalesOrder.Remarks = reader["Remarks"].ToString();

                    if (reader["CreateUserID"] != DBNull.Value)
                    {
                        oSalesOrder.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    }
                    else oSalesOrder.CreateUserID = -1;

                    if (reader["WarehouseID"] != DBNull.Value)
                    {
                        oSalesOrder.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    }
                    else oSalesOrder.WarehouseID = -1;

                    if (reader["ConfirmUserID"] != DBNull.Value)
                    {
                        oSalesOrder.ConfirmUserID = int.Parse(reader["ConfirmUserID"].ToString());
                    }
                    else oSalesOrder.ConfirmUserID = -1;

                    if (reader["Discount"] != DBNull.Value)
                    {
                        oSalesOrder.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    }
                    else oSalesOrder.Discount = 0;

                    if (reader["DDAmount"] != DBNull.Value)
                    {
                        oSalesOrder.DDAmount = Convert.ToDouble(reader["DDAmount"].ToString());
                    }
                    else oSalesOrder.DDAmount = 0;

                    oSalesOrder.DDDate = (object)reader["DDDate"];
                    oSalesOrder.DDDetails = (string)reader["DDDetails"].ToString();


                    if (reader["OrderTypeID"] != DBNull.Value)
                    {
                        oSalesOrder.OrderTypeID = int.Parse(reader["OrderTypeID"].ToString());
                    }
                    else oSalesOrder.OrderTypeID = 1;

                    if (reader["SalesPromotionID"] != DBNull.Value)
                    {
                        oSalesOrder.SalesPromotionID = int.Parse(reader["SalesPromotionID"].ToString());
                        if (oSalesOrder.SalesPromotionID == 0)
                            oSalesOrder.SalesPromotionID = -1;

                    }
                    else oSalesOrder.SalesPromotionID = -1;
                    oSalesOrder.CustomerCode = sCustomerCode;
                    oSalesOrder.CustomerName = sCustomerName;

                    //oSalesOrder.RefreshItem();

                    InnerList.Add(oSalesOrder);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public void RefreshOrderFromCustomer(DateTime dFromDate, DateTime dToDate, string nID,string sCustomerCode, string sCustomerName, int OrderSatus)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "Select AO.OrderID as AndroidOrderID, AO.OrderStatus,IsNull(SO.OrderNo,'')as OrderNo, AO.CustomerID, CustomerCode, CustomerName, " +
                            "(CustomerName+'['+CustomerCode+']')as Customer,AO.OrderDate,IsComplete, OrderStatusName=CASE " +
                            "When IsNull(SO.OrderStatus,0)=1 then 'Received' When SO.OrderStatus=2 then 'Confirmed' When SO.OrderStatus=3 then 'Pending' " +
                            "When SO.OrderStatus=4 then 'Canceled' When SO.OrderStatus=5 then 'Invoiced' When SO.OrderStatus=6 then 'Reject_Due_To_Less_Credit' " +
                            "When SO.OrderStatus=7 then 'Cancle_Due_To_Less_Stock' When IsNull(SO.OrderStatus,0)=0 then  'Submit' end, PriceOptionID,RevOrderQty, " +
                            "Value=CASE When PriceOptionID=1 then Price.TtlNSP When PriceOptionID=2 then Price.TtlRSP When PriceOptionID=3 then Price.TtlSP " +
                            "When PriceOptionID=4 then Price.TtlCP When PriceOptionID=5 then Price.TtlTP When PriceOptionID=6 then Price.TtlMRP else 0 end " +
                            "from dbo.t_AndroidOrder AO INNER JOIN (Select OrderID, sum(RevOrderQty)RevOrderQty from t_AndroidOrderDetail group by orderid)AOD " +
                            "ON AOD.OrderID=AO.OrderID INNER JOIN v_CustomerDetails CD ON CD.CustomerID=AO.CustomerID " +
                            "INNER JOIN t_CustomerTypeWisePriceSetting x On x.CustTypeID=CD.CustomerTypeID " +
                            "Left outer join t_salesOrder SO on SO.orderid=AO.actualorderid " +
                            "INNER JOIN (Select OrderID, Sum(RevOrderQty)RevQty, Sum(TtlNSP)TtlNSP, Sum(TtlRSP)TtlRSP, Sum(TtlSP)TtlSP, Sum(TtlCP)TtlCP, " +
                            "Sum(TtlTP)TtlTP,Sum(TtlMRP)TtlMRP from (Select OrderID, AOD.ProductID, RevOrderQty,(RevOrderQty*NSP) as TtlNSP, " +
                            "(RevOrderQty*RSP) as TtlRSP, (RevOrderQty*SpecialPrice) as TtlSP,(RevOrderQty*CostPrice) as TtlCP, " +
                            "(RevOrderQty*TradePrice) as TtlTP,(RevOrderQty*MRP) as TtlMRP  from t_AndroidOrderDetail AOD " +
                            "INNER JOIN (select ProductID, IsNull(NSP,0)NSP, IsNull(RSP,0)RSP, IsNull(SpecialPrice,0)SpecialPrice, " +
                            "IsNull(CostPrice,0)CostPrice, IsNull(TradePrice,0)TradePrice, IsNull(MRP,0)MRP from v_ProductDetails) as pd " +
                            "on pd.productid=aod.productid )a group by orderid)Price ON AO.OrderID=Price.OrderID " +
                            "Where AO.OrderDate between ? and ? and AO.OrderDate < ? ";

            cmd.Parameters.AddWithValue("AO.OrderDate", dFromDate);
            cmd.Parameters.AddWithValue("AO.OrderDate", dToDate);
            cmd.Parameters.AddWithValue("AO.OrderDate", dToDate);

            if (nID != "")
            {
                sSql = sSql + " and AO.OrderID = '" + nID + "'";
            }
            if (sCustomerCode != "")
            {
                sCustomerCode = "%" + sCustomerCode + "%";
                sSql = sSql + " and CustomerCode like '" + sCustomerCode + "'";
            }
            if (sCustomerName != "")
            {
                sCustomerName = "%" + sCustomerName + "%";
                sSql = sSql + " and CustomerName like '" + sCustomerName + "'";
            }
            if (OrderSatus > 0)
            {
                sSql = sSql + " and SO.OrderStatus='" + OrderSatus + "'";
            }
            sSql = sSql + " Order by AO.orderDate asc ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesOrder oSalesOrder = new SalesOrder();

                    oSalesOrder.AndroidOrderID = int.Parse(reader["AndroidOrderID"].ToString());
                    oSalesOrder.OrderNo = int.Parse(reader["OrderNo"].ToString());             
                    oSalesOrder.OrderDate = (object)reader["OrderDate"];
                    oSalesOrder.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oSalesOrder.CustomerName = (string)reader["CustomerName"] + "[" + (string)reader["CustomerCode"]+"]";
                    oSalesOrder.StatusName = (string)reader["OrderStatusName"];
                    oSalesOrder.AndroidOrderStatus = (string)reader["OrderStatus"];
                    if (reader["RevOrderQty"] != DBNull.Value)
                    {
                        oSalesOrder.TotalOrderQty = (int)reader["RevOrderQty"];
                    }
                    else
                    {
                        oSalesOrder.TotalOrderQty = 0;
                    }
                    if (reader["Value"] != DBNull.Value)
                    {
                        oSalesOrder.TotalOrderValue = Convert.ToDouble(reader["Value"].ToString());
                    }
                    else
                    {
                        oSalesOrder.TotalOrderValue = 0;
                    }


                    oSalesOrder.RefreshOrderfromCustomerItem(oSalesOrder.AndroidOrderID);

                    InnerList.Add(oSalesOrder);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshOrderFromCustomerBLL(DateTime dFromDate, DateTime dToDate, string nID, string sCustomerCode, string sCustomerName, int OrderSatus)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "select AO.OrderID as AndroidOrderID, AO.OrderStatus,IsNull(SO.OrderNo,'')as OrderNo, AO.CustomerID, CustomerCode, CustomerName,  " +
                   " (CustomerName+'['+CustomerCode+']')as Customer,AO.OrderDate,IsComplete, OrderStatusName=CASE  " +
                   " When IsNull(SO.OrderStatus,0)=1 then 'Received' When SO.OrderStatus=2 then 'Confirmed' When SO.OrderStatus=3 then 'Pending'  " +
                   " When SO.OrderStatus=4 then 'Canceled' When SO.OrderStatus=5 then 'Invoiced' When SO.OrderStatus=6 then 'Reject_Due_To_Less_Credit'  " +
                   " When SO.OrderStatus=7 then 'Cancle_Due_To_Less_Stock' When IsNull(SO.OrderStatus,0)=0 then  'Submit' end, PriceOptionID,RevOrderQty,  " +
                   " Value=CASE When PriceOptionID=1 then Price.TtlNSP When PriceOptionID=2 then Price.TtlRSP When PriceOptionID=3 then Price.TtlSP  " +
                   " When PriceOptionID=4 then Price.TtlCP When PriceOptionID=5 then Price.TtlTP else 0 end  " +
                   " from t_AndroidOrder AO INNER JOIN (Select OrderID, sum(RevOrderQty)RevOrderQty from t_AndroidOrderDetail group by orderid)AOD  " +
                   " ON AOD.OrderID=AO.OrderID INNER JOIN v_CustomerDetails CD ON CD.CustomerID=AO.CustomerID  " +
                   " INNER JOIN t_CustomerTypeWisePriceSetting x On x.CustTypeID=CD.CustomerTypeID  " +
                   " Left outer join t_salesOrder SO on SO.orderid=AO.actualorderid  " +
                   " INNER JOIN (Select OrderID, Sum(RevOrderQty)RevQty, Sum(TtlNSP)TtlNSP, Sum(TtlRSP)TtlRSP, Sum(TtlSP)TtlSP, Sum(TtlCP)TtlCP,  " +
                   " Sum(TtlTP)TtlTP from (Select OrderID, AOD.ProductID, RevOrderQty,(RevOrderQty*NSP) as TtlNSP,  " +
                   " (RevOrderQty*RSP) as TtlRSP, (RevOrderQty*SpecialPrice) as TtlSP,(RevOrderQty*CostPrice) as TtlCP,  " +
                   " (RevOrderQty*TradePrice) as TtlTP from t_AndroidOrderDetail AOD  " +
                   " INNER JOIN (select ProductID, IsNull(NSP,0)NSP,IsNull(RSP,0)RSP,IsNull(SpecialPrice,0)SpecialPrice,  " +
                   " IsNull(CostPrice,0)CostPrice, IsNull(TradePrice,0)TradePrice  from v_ProductDetails) as pd  " +
                   " on pd.productid=aod.productid )a group by orderid)Price ON AO.OrderID=Price.OrderID  " +
                   " Where AO.OrderDate between ? and ? and AO.OrderDate < ?  ";



            cmd.Parameters.AddWithValue("AO.OrderDate", dFromDate);
            cmd.Parameters.AddWithValue("AO.OrderDate", dToDate);
            cmd.Parameters.AddWithValue("AO.OrderDate", dToDate);

            if (nID != "")
            {
                sSql = sSql + " and AO.OrderID = '" + nID + "'";
            }
            if (sCustomerCode != "")
            {
                sCustomerCode = "%" + sCustomerCode + "%";
                sSql = sSql + " and CustomerCode like '" + sCustomerCode + "'";
            }
            if (sCustomerName != "")
            {
                sCustomerName = "%" + sCustomerName + "%";
                sSql = sSql + " and CustomerName like '" + sCustomerName + "'";
            }
            if (OrderSatus > 0)
            {
                sSql = sSql + " and SO.OrderStatus='" + OrderSatus + "'";
            }
            sSql = sSql + " Order by AO.orderDate asc ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesOrder oSalesOrder = new SalesOrder();

                    oSalesOrder.AndroidOrderID = int.Parse(reader["AndroidOrderID"].ToString());
                    oSalesOrder.OrderNo = int.Parse(reader["OrderNo"].ToString());
                    oSalesOrder.OrderDate = (object)reader["OrderDate"];
                    oSalesOrder.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oSalesOrder.CustomerName = (string)reader["CustomerName"] + "[" + (string)reader["CustomerCode"] + "]";
                    oSalesOrder.StatusName = (string)reader["OrderStatusName"];
                    oSalesOrder.AndroidOrderStatus = (string)reader["OrderStatus"];
                    if (reader["RevOrderQty"] != DBNull.Value)
                    {
                        oSalesOrder.TotalOrderQty = (int)reader["RevOrderQty"];
                    }
                    else
                    {
                        oSalesOrder.TotalOrderQty = 0;
                    }
                    if (reader["Value"] != DBNull.Value)
                    {
                        oSalesOrder.TotalOrderValue = Convert.ToDouble(reader["Value"].ToString());
                    }
                    else
                    {
                        oSalesOrder.TotalOrderValue = 0;
                    }


                    oSalesOrder.RefreshOrderfromCustomerItemBLL(oSalesOrder.AndroidOrderID);

                    InnerList.Add(oSalesOrder);
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

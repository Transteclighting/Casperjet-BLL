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

namespace CJ.Class.DMS
{
    public class DMSOrderItem
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

       

        public void Insert(int nOrderID)
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


                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
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
    public class DMSOrder:CollectionBase
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
        private string _sCustomerCode;
        private string _sCustomerName;
        private bool _bFlag;
        private bool _bIsUpdate;       
        public Customer _oCustomer;
        private DMSUser _oCreateUser;
        private DMSUser _oConfirmUser;
        private Warehouse _oWarehouse;
        private Employee _oEmployee;
        private SalesPromotion _oSalesPromotion;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
       
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
        public DMSUser CreateUser
        {
            get
            {
                if (_oCreateUser == null)
                {
                    _oCreateUser = new DMSUser();                    
                    _oCreateUser.DistributorID = _nCreateUserID;
                   // _oCreateUser.RefreshByUserID();
                }
                return _oCreateUser;
            }
        }
        public DMSUser ConfirmUser
        {
            get
            {
                if (_oConfirmUser == null)
                {
                    _oConfirmUser = new DMSUser();                   
                    _oConfirmUser.DistributorID = _nConfirmUserID;
                   // _oConfirmUser.RefreshByUserID();
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

        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
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

        public DMSOrderItem this[int i]
        {
            get { return (DMSOrderItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(DMSOrderItem oDMSOrderItem)
        {
            InnerList.Add(oDMSOrderItem);
        }

        public void Insert()
        {
            int nMaxOrderID = 0;
            int nMaxTranNo = 0;
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

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "select max( convert(int, (right(orderno,3)),1)) as MaxTranNo from t_salesorder "+
                       "where orderdate between ? and ? and orderdate < ?";
                cmd.Parameters.AddWithValue("orderdate", todate);
                cmd.Parameters.AddWithValue("orderdate", fromdate);
                cmd.Parameters.AddWithValue("orderdate", fromdate);

                cmd.CommandText = sSql;
                object MaxTranNo = cmd.ExecuteScalar();
                if (MaxTranNo == DBNull.Value)
                {
                    nMaxTranNo = 1;
                }
                else
                {
                    nMaxTranNo = int.Parse(MaxTranNo.ToString()) + 1;

                }
                _nOrderNo = Convert.ToInt32(DateTime.Today.Date.ToString("yy") + DateTime.Today.Month.ToString("00") + DateTime.Today.Day.ToString("00") + nMaxTranNo.ToString("000"));

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SalesOrder VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("OrderNo", _nOrderNo);
                cmd.Parameters.AddWithValue("OrderDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _sDeliveryAddress);     
                cmd.Parameters.AddWithValue("SalesPersonID", 0);               
                cmd.Parameters.AddWithValue("ConfirmDate", null);
                cmd.Parameters.AddWithValue("OrderStatus", 1);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.DMSMakeOrderID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ConfirmUserID", null);
                cmd.Parameters.AddWithValue("Discount", 0);
                cmd.Parameters.AddWithValue("DDAmount", null);
                cmd.Parameters.AddWithValue("DDDate", null);
                cmd.Parameters.AddWithValue("DDDetails", null);
                cmd.Parameters.AddWithValue("OrderTypeID", _nOrderTypeID); 
                if(_nSalesPromotionID!=-1)
                    cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);
                else cmd.Parameters.AddWithValue("SalesPromotionID", 0);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null); 

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (DMSOrderItem oItem in this)
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
                cmd.CommandText = "update  t_SalesOrder set Remarks=? where OrderID=?";

                cmd.CommandType = CommandType.Text;
             
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);           

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (DMSOrderItem oItem in this)
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
        public void Delete()
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
                
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
        public void RefreshSalesOrderItem()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesOrderDetail where OrderID=? ";
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSOrderItem oItem = new DMSOrderItem();

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
                while (reader.Read())
                {
                    _nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (_nCount != 0)
                _bFlag = false;
            else _bFlag = true;
        }
        public void Refresh(string sOrderNo,string sCustomerCode, string sCustomerName)
        {
            _sCustomerCode = sCustomerCode;
            _sCustomerName = sCustomerName;

            OleDbCommand cmd = DBController.Instance.GetCommand();
           
            string sSql = "SELECT * FROM t_SalesOrder where OrderID = '"+_nOrderID+"'";
            if (sOrderNo!= "")
            {
                sSql = sSql + "and OrderNo ='" + sOrderNo + "'";
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
    }
    /// <summary>
    /// 
    /// Collection class for SalesOrder Class.
    /// 
    /// </summary>

    public class DMSOrders : CollectionBase 
    {
        public DMSOrder this[int i]
        {
            get { return (DMSOrder)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(DMSOrder oDMSOrder)
        {
            InnerList.Add(oDMSOrder);
        }

        public void Refresh( DateTime dFromDate,DateTime dToDate,string OrderNo,int nOrderSatus,int nUserID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate=dToDate.AddDays(1);
            //string sSql = "SELECT * FROM t_SalesOrder where OrderDate between '" + dFromDate + "' and '" + dToDate + "' and OrderDate < '" + dToDate + "'";

            string sSql = "SELECT * FROM t_SalesOrder where OrderDate "
                          + " between '" + dFromDate + "' and '" + dToDate + "' and OrderDate < '" + dToDate + "' and CustomerID = '" + nUserID + "'";

            if (OrderNo != "")
            {
                OrderNo = "%" + OrderNo + "%";
                sSql = sSql + "and OrderNo like '" + OrderNo + "'";
            }
            if (nOrderSatus>0)
            {
                sSql = sSql + "and OrderStatus='" + nOrderSatus + "'";
            }
            try
            {
                cmd.CommandText = sSql;                
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSOrder oDMSOrder = new DMSOrder();

                    oDMSOrder.OrderID = int.Parse(reader["OrderID"].ToString());
                    oDMSOrder.OrderNo = int.Parse( reader["OrderNo"].ToString());
                    oDMSOrder.OrderDate = (object)reader["OrderDate"];
                    oDMSOrder.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    oDMSOrder.DeliveryAddress = reader["DeliveryAddress"].ToString();

                    if (reader["SalesPersonID"] != DBNull.Value)
                    {
                        oDMSOrder.SalesPersonID = int.Parse(reader["SalesPersonID"].ToString());
                    }
                    else oDMSOrder.SalesPersonID = -1;

                    oDMSOrder.ConfirmDate = (object)(reader["ConfirmDate"].ToString());
                    oDMSOrder.OrderStatus = int.Parse( reader["OrderStatus"].ToString());
                    oDMSOrder.Remarks = reader["Remarks"].ToString();

                    if (reader["CreateUserID"] != DBNull.Value)
                    {
                         oDMSOrder.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    }
                    else  oDMSOrder.CreateUserID= -1;
                    
                    if (reader["WarehouseID"] != DBNull.Value)
                    {
                       oDMSOrder.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    }
                    else oDMSOrder.WarehouseID = -1;
                   
                    if (reader["ConfirmUserID"] != DBNull.Value)
                    {
                        oDMSOrder.ConfirmUserID = int.Parse(reader["ConfirmUserID"].ToString());
                    }
                    else oDMSOrder.ConfirmUserID = -1;
                   
                    if (reader["Discount"] != DBNull.Value)
                    {
                        oDMSOrder.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    }
                    else oDMSOrder.Discount = 0;

                   
                    if (reader["DDAmount"] != DBNull.Value)
                    {
                        oDMSOrder.DDAmount = Convert.ToDouble( reader["DDAmount"].ToString());
                    }
                    else oDMSOrder.DDAmount = 0;

                    oDMSOrder.DDDate = (object)reader["DDDate"];
                    oDMSOrder.DDDetails = (string)reader["DDDetails"].ToString();

                  
                    if (reader["OrderTypeID"] != DBNull.Value)
                    {
                        oDMSOrder.OrderTypeID = int.Parse( reader["OrderTypeID"].ToString());
                    }
                    else oDMSOrder.OrderTypeID = 1;
                   
                    if (reader["SalesPromotionID"] != DBNull.Value)
                    {
                        oDMSOrder.SalesPromotionID = int.Parse( reader["SalesPromotionID"].ToString());
                        if (oDMSOrder.SalesPromotionID == 0)
                            oDMSOrder.SalesPromotionID = -1;

                    }
                    else oDMSOrder.SalesPromotionID = -1;                 
                    
                    oDMSOrder.RefreshSalesOrderItem();
                 

                    InnerList.Add(oDMSOrder);
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


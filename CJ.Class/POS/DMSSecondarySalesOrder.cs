// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Apr 17, 2018
// Time : 04:58 PM
// Description: Class for DMSSecondarySalesOrder.
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
    public class DMSSecondarySalesOrderDetail
    {
        private int _nID;
        private int _nOrderID;
        private int _nProductID;
        private int _nOrderQty;
        private int _nConfirmedQty;

        private string _sOrderNo;
        public string OrderNo
        {
            get { return _sOrderNo; }
            set { _sOrderNo = value; }
        }
        private string _sWarehouseName;
        public string WarehouseName
        {
            get { return _sWarehouseName; }
            set { _sWarehouseName = value; }
        }
        private DateTime _dEDD;
        public DateTime EDD
        {
            get { return _dEDD; }
            set { _dEDD = value; }
        }
        private DateTime _dCreateDate;
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        private string _sProductCode;
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        private string _sProductName;
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        private string _sCustomerCode;
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }
        private string _sCustomerName;
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        private string _sCustomerAddress;
        public string CustomerAddress
        {
            get { return _sCustomerAddress; }
            set { _sCustomerAddress = value.Trim(); }
        }
        private int _CurrentStock;
        public int CurrentStock
        {
            get { return _CurrentStock; }
            set { _CurrentStock = value; }
        }
        private int _MAGID;
        public int MAGID
        {
            get { return _MAGID; }
            set { _MAGID = value; }
        }
        private int _BrandID;
        public int BrandID
        {
            get { return _BrandID; }
            set { _BrandID = value; }
        }
        private int _IsBarcodeItem;
        public int IsBarcodeItem
        {
            get { return _IsBarcodeItem; }
            set { _IsBarcodeItem = value; }
        }
        private double _RSP;
        public double RSP
        {
            get { return _RSP; }
            set { _RSP = value; }
        }

        private int _nWarehouseID;
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
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
        // Get set property for OrderID
        // </summary>
        public int OrderID
        {
            get { return _nOrderID; }
            set { _nOrderID = value; }
        }

        // <summary>
        // Get set property for ProductID
        // </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        // <summary>
        // Get set property for Qty
        // </summary>
        public int OrderQty
        {
            get { return _nOrderQty; }
            set { _nOrderQty = value; }
        }
        private double _UnitPrice;
        public double UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
        // <summary>
        // Get set property for ConfirmedQty
        // </summary>
        public int ConfirmedQty
        {
            get { return _nConfirmedQty; }
            set { _nConfirmedQty = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                
                sSql = "INSERT INTO t_DMSSecondarySalesOrderDetail (OrderID, WarehouseID, ProductID, OrderQty, ConfirmedQty,UnitPrice) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("OrderQty", _nOrderQty);
                cmd.Parameters.AddWithValue("ConfirmedQty", _nConfirmedQty);
                cmd.Parameters.AddWithValue("UnitPrice", _UnitPrice);

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
                sSql = "UPDATE t_DMSSecondarySalesOrderDetail SET OrderID = ?, ProductID = ?, Qty = ?, ConfirmedQty = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("Qty", _nOrderQty);
                cmd.Parameters.AddWithValue("ConfirmedQty", _nConfirmedQty);

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
                sSql = "DELETE FROM t_DMSSecondarySalesOrderDetail WHERE [OrderID]=? and [WarehouseID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
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
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_DMSSecondarySalesOrderDetail where OrderID =?";
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    //_nID = (int)reader["ID"];
                    _nOrderID = (int)reader["OrderID"];
                    _nProductID = (int)reader["ProductID"];
                    _nOrderQty = (int)reader["OrderQty"];
                    _UnitPrice = (double)reader["UnitPrice"];
                    _nConfirmedQty = (int)reader["ConfirmedQty"];
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
    public class DMSSecondarySalesOrder : CollectionBase
    {
        public DMSSecondarySalesOrderDetail this[int i]
        {
            get { return (DMSSecondarySalesOrderDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DMSSecondarySalesOrderDetail oDMSSecondarySalesOrderDetail)
        {
            InnerList.Add(oDMSSecondarySalesOrderDetail);
        }
        private int _nOrderID;
        private string _sOrderNo;
        private int _nCustomerID;
        private int _nParentCustomerId;
        private DateTime _dEDD;
        private double _Amount;
        private int _nStatus;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private object _dUpdateDate;
        private string _sRemarks;

        private string _sCustomerCode;
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }
        private string _sCustomerName;
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        private string _sParentCustomer;
        public string ParentCustomer
        {
            get { return _sParentCustomer; }
            set { _sParentCustomer = value.Trim(); }
        }
        private string _sCustomerTypeName;
        public string CustomerTypeName
        {
            get { return _sCustomerTypeName; }
            set { _sCustomerTypeName = value.Trim(); }
        }
        private string _sChannelName;
        public string ChannelName
        {
            get { return _sChannelName; }
            set { _sChannelName = value.Trim(); }
        }


        // <summary>
        // Get set property for OrderID
        // </summary>
        public int OrderID
        {
            get { return _nOrderID; }
            set { _nOrderID = value; }
        }

        // <summary>
        // Get set property for OrderNo
        // </summary>
        public string OrderNo
        {
            get { return _sOrderNo; }
            set { _sOrderNo = value.Trim(); }
        }

        // <summary>
        // Get set property for CustomerID
        // </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }

        // <summary>
        // Get set property for ParentCustomerId
        // </summary>
        public int ParentCustomerId
        {
            get { return _nParentCustomerId; }
            set { _nParentCustomerId = value; }
        }

        // <summary>
        // Get set property for EDD
        // </summary>
        public DateTime EDD
        {
            get { return _dEDD; }
            set { _dEDD = value; }
        }
        private string _sShortcode;
        public string Shortcode
        {
            get { return _sShortcode; }
            set { _sShortcode = value; }
        }
        private string _sOrderType;
        public string OrderType
        {
            get { return _sOrderType; }
            set { _sOrderType = value; }
        }
        private int _nSalesType;
        public int SalesType
        {
            get { return _nSalesType; }
            set { _nSalesType = value; }
        }
        private int _nWarehouseID;
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }
        // <summary>
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
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
        public object UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }
        private string _sRefInvoiceNo;
        public string RefInvoiceNo
        {
            get { return _sRefInvoiceNo; }
            set { _sRefInvoiceNo = value.Trim(); }
        }
        private object _dRefInvoiceDate;
        public object RefInvoiceDate
        {
            get { return _dRefInvoiceDate; }
            set { _dRefInvoiceDate = value; }
        }
        private int _AuthorizedBy;
        public int AuthorizedBy
        {
            get { return _AuthorizedBy; }
            set { _AuthorizedBy = value; }
        }


        private object _dAuthorizeDate;
        public object AuthorizeDate
        {
            get { return _dAuthorizeDate; }
            set { _dAuthorizeDate = value; }
        }

        private string _sAuthorizeRemarks;
        public string AuthorizeRemarks
        {
            get { return _sAuthorizeRemarks; }
            set { _sAuthorizeRemarks = value.Trim(); }
        }
        public void InsertForWEB()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_DMSSecondarySalesOrder (OrderID,OrderNo,WarehouseID,SalesType,CustomerID,ParentCustomerID,EDD,OrderAmount,Status,CreateUserID,CreateDate,RefInvoiceNo,RefInvoiceDate,UpdateUserID,UpdateDate,Remarks,AuthorizedBy,AuthorizeDate,AuthorizeRemarks,OrderType) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("OrderNo", _sOrderNo);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ParentCustomerId", _nParentCustomerId);
                cmd.Parameters.AddWithValue("EDD", _dEDD);
                cmd.Parameters.AddWithValue("OrderAmount", _Amount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                if (_sRefInvoiceNo != null)
                {
                    cmd.Parameters.AddWithValue("RefInvoiceNo", _sRefInvoiceNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("RefInvoiceNo", null);
                }

                if (_dRefInvoiceDate != null)
                {
                    cmd.Parameters.AddWithValue("RefInvoiceDate", _dRefInvoiceDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("RefInvoiceDate", null);
                }
                if (_nUpdateUserID != -1)
                {
                    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateUserID", null);
                }
                if (_dUpdateDate != null)
                {
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateDate", null);
                }
                if (_sRemarks != null)
                {
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Remarks", null);
                }
                if (_AuthorizedBy != -1)
                {
                    cmd.Parameters.AddWithValue("AuthorizedBy", _AuthorizedBy);
                }
                else
                {
                    cmd.Parameters.AddWithValue("AuthorizedBy", null);
                }
                if (_dAuthorizeDate != null)
                {
                    cmd.Parameters.AddWithValue("AuthorizeDate", _dAuthorizeDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("AuthorizeDate", null);
                }
                if (_sAuthorizeRemarks != null)
                {
                    cmd.Parameters.AddWithValue("AuthorizeRemarks", _sAuthorizeRemarks);
                }
                else
                {
                    cmd.Parameters.AddWithValue("AuthorizeRemarks", null);
                }
                if (_sOrderType != null)
                {
                    cmd.Parameters.AddWithValue("OrderType", _sOrderType);
                }
                else
                {
                    cmd.Parameters.AddWithValue("OrderType", null);
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                DMSSecondarySalesOrderDetail oItem = new DMSSecondarySalesOrderDetail();
                oItem.WarehouseID = _nWarehouseID;
                oItem.OrderID = _nOrderID;
                oItem.Delete();

                foreach (DMSSecondarySalesOrderDetail oItems in this)
                {
                    oItems.OrderID = _nOrderID;
                    oItems.Add();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Add()
        {
            int nMaxOrderID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OrderID]) FROM t_DMSSecondarySalesOrder where WarehouseID = " + _nWarehouseID + "";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxOrderID = 1;
                }
                else
                {
                    nMaxOrderID = Convert.ToInt32(maxID) + 1;
                }
                _nOrderID = nMaxOrderID;
                _sShortcode = "Order-" + _sShortcode + "-" + DateTime.Now.ToString("yy") + _nOrderID.ToString("0000");

                sSql = "INSERT INTO t_DMSSecondarySalesOrder (OrderID,OrderNo,WarehouseID,SalesType,CustomerID,ParentCustomerID,EDD,OrderAmount,Status,CreateUserID,CreateDate,RefInvoiceNo,RefInvoiceDate,UpdateUserID,UpdateDate,Remarks) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("OrderNo", _sShortcode);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ParentCustomerId", _nParentCustomerId);
                cmd.Parameters.AddWithValue("EDD", _dEDD);
                cmd.Parameters.AddWithValue("OrderAmount", _Amount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("RefInvoiceNo", _sRefInvoiceNo);
                cmd.Parameters.AddWithValue("RefInvoiceDate", _dRefInvoiceDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();


                DMSSecondarySalesOrderDetail oItem = new DMSSecondarySalesOrderDetail();
                oItem.WarehouseID = _nWarehouseID;
                oItem.OrderID = _nOrderID;
                oItem.Delete();

                foreach (DMSSecondarySalesOrderDetail oItems in this)
                {
                    oItems.OrderID = _nOrderID;
                    oItems.Add();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddNew()
        {
            int nMaxOrderID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OrderID]) FROM t_DMSSecondarySalesOrder where WarehouseID = " + _nWarehouseID + "";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxOrderID = 1;
                }
                else
                {
                    nMaxOrderID = Convert.ToInt32(maxID) + 1;
                }
                _nOrderID = nMaxOrderID;
                _sShortcode = "Order-" + _sShortcode + "-" + DateTime.Now.ToString("yy") + _nOrderID.ToString("0000");

                sSql = "INSERT INTO t_DMSSecondarySalesOrder (OrderID,OrderNo,WarehouseID,SalesType,CustomerID,ParentCustomerID,EDD,OrderAmount,Status,CreateUserID,CreateDate,RefInvoiceNo,RefInvoiceDate,UpdateUserID,UpdateDate,Remarks,OrderType) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("OrderNo", _sShortcode);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ParentCustomerId", _nParentCustomerId);
                cmd.Parameters.AddWithValue("EDD", _dEDD);
                cmd.Parameters.AddWithValue("OrderAmount", _Amount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("RefInvoiceNo", _sRefInvoiceNo);
                cmd.Parameters.AddWithValue("RefInvoiceDate", _dRefInvoiceDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("OrderType", _sOrderType);
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                DMSSecondarySalesOrderDetail oItem = new DMSSecondarySalesOrderDetail();
                oItem.WarehouseID = _nWarehouseID;
                oItem.OrderID = _nOrderID;
                oItem.Delete();

                foreach (DMSSecondarySalesOrderDetail oItems in this)
                {
                    oItems.OrderID = _nOrderID;
                    oItems.Add();
                }
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
                sSql = "UPDATE t_DMSSecondarySalesOrder SET CustomerID = ?, ParentCustomerId = ?, EDD = ?, Amount = ?, Status = ?, UpdateUserID = ?, UpdateDate = ?, Remarks = ? WHERE OrderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ParentCustomerId", _nParentCustomerId);
                cmd.Parameters.AddWithValue("EDD", _dEDD);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                DMSSecondarySalesOrderDetail oItem = new DMSSecondarySalesOrderDetail();
                oItem.WarehouseID = _nWarehouseID;
                oItem.OrderID = _nOrderID;
                oItem.Delete();

                foreach (DMSSecondarySalesOrderDetail oItems in this)
                {
                    oItems.OrderID = _nOrderID;
                    oItems.Add();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditNew(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_DMSSecondarySalesOrder SET CustomerID = ?, ParentCustomerId = ?, EDD = ?, OrderAmount = ?, Status = ?, UpdateUserID = ?, UpdateDate = ?, Remarks = ?,SalesType=?, OrderType=?,WarehouseID=? WHERE OrderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ParentCustomerId", _nParentCustomerId);
                cmd.Parameters.AddWithValue("EDD", _dEDD);
                cmd.Parameters.AddWithValue("OrderAmount", _Amount);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("OrderType", _sOrderType);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("OrderID", nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                DMSSecondarySalesOrderDetail oItem = new DMSSecondarySalesOrderDetail();
                oItem.WarehouseID = _nWarehouseID;
                oItem.OrderID = nOrderID;
                oItem.Delete();

                foreach (DMSSecondarySalesOrderDetail oItems in this)
                {
                    oItems.OrderID = nOrderID;
                    oItems.Add();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Approve()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_DMSSecondarySalesOrder SET Status = ?,AuthorizeRemarks= ?,AuthorizedBy= " + Utility.UserId + ",AuthorizeDate = '" + DateTime.Now + "' WHERE OrderNo = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

               
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("AuthorizeRemarks", _sRemarks);
                cmd.Parameters.AddWithValue("OrderNo", _sOrderNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateConfirmQty(int nStatus,int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (nStatus == (int)Dictionary.DMSSecondarySalesOrderStatus.Approved_By_HO)
                {
                    sSql = "update t_DMSSecondarySalesOrderDetail set ConfirmedQty=OrderQty where OrderID=? and WarehouseID=" + nWarehouseID + "";
                }
                else
                {
                    sSql = "update t_DMSSecondarySalesOrderDetail set ConfirmedQty=0 where OrderID=? and WarehouseID=" + nWarehouseID + "";
                }
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("OrderID", _nOrderID);


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
                sSql = "DELETE FROM t_DMSSecondarySalesOrder WHERE [OrderID]=? and [WarehouseID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
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
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_DMSSecondarySalesOrder where OrderID = ? and WarehouseID = ? ";
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOrderID = (int)reader["OrderID"];
                    _sOrderNo = (string)reader["OrderNo"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _nParentCustomerId = (int)reader["ParentCustomerId"];
                    _dEDD = Convert.ToDateTime(reader["EDD"].ToString());
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _nStatus = (int)reader["Status"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _sRemarks = (string)reader["Remarks"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetConfirmedQty(string sOrderNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"Select a.OrderID,b.ProductID,ProductCode,ProductName,ConfirmedQty,OrderQty,
                        isnull(CurrentStock,0) CurrentStock,MAGID,BrandID,RSP,IsBarcodeItem  
                        From t_DMSSecondarySalesOrder a
                        join t_DMSSecondarySalesOrderDetail b on a.OrderID = b.OrderID and a.WarehouseID = b.WarehouseID
                        join v_ProductDetails c on b.ProductID = c.ProductID
                        left outer join t_ProductStock d on b.ProductID = d.ProductID and a.WarehouseID = d.WarehouseID
                        where ConfirmedQty> 0 and OrderNo = '" + sOrderNo + "'";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSSecondarySalesOrderDetail oDMSSecondarySalesOrder = new DMSSecondarySalesOrderDetail();
                    oDMSSecondarySalesOrder.OrderID = (int)reader["OrderID"];
                    oDMSSecondarySalesOrder.ProductID = (int)reader["ProductID"];
                    oDMSSecondarySalesOrder.ProductCode = (string)reader["ProductCode"];
                    oDMSSecondarySalesOrder.ProductName = (string)reader["ProductName"];
                    oDMSSecondarySalesOrder.ConfirmedQty = (int)reader["ConfirmedQty"];
                    oDMSSecondarySalesOrder.OrderQty = (int)reader["OrderQty"];
                    oDMSSecondarySalesOrder.CurrentStock = Convert.ToInt32(reader["CurrentStock"].ToString());
                    oDMSSecondarySalesOrder.MAGID = Convert.ToInt32(reader["MAGID"].ToString());
                    oDMSSecondarySalesOrder.BrandID = Convert.ToInt32(reader["BrandID"].ToString());
                    oDMSSecondarySalesOrder.IsBarcodeItem = Convert.ToInt32(reader["IsBarcodeItem"].ToString());
                    oDMSSecondarySalesOrder.RSP = Convert.ToDouble(reader["RSP"].ToString());

                    InnerList.Add(oDMSSecondarySalesOrder);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetOrderItem(int nOrderID,int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select OrderID,WarehouseID,ProductID,UnitPrice,OrderQty,isnull(ConfirmedQty,0) ConfirmedQty From t_DMSSecondarySalesOrderDetail where OrderID=" + nOrderID + " and WarehouseID=" + nWarehouseID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSSecondarySalesOrderDetail oDMSSecondarySalesOrder = new DMSSecondarySalesOrderDetail();
                    oDMSSecondarySalesOrder.OrderID = (int)reader["OrderID"];
                    oDMSSecondarySalesOrder.WarehouseID = (int)reader["WarehouseID"];
                    oDMSSecondarySalesOrder.ProductID = (int)reader["ProductID"];
                    oDMSSecondarySalesOrder.UnitPrice = Convert.ToDouble(reader["UnitPrice"].ToString());
                    oDMSSecondarySalesOrder.OrderQty = Convert.ToInt32(reader["OrderQty"].ToString());
                    oDMSSecondarySalesOrder.ConfirmedQty = Convert.ToInt32(reader["ConfirmedQty"].ToString());

                    InnerList.Add(oDMSSecondarySalesOrder);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateInvoiceData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_DMSSecondarySalesOrder SET RefInvoiceNo = ?,RefInvoiceDate =?, Status = ? WHERE OrderNo = ? and WarehouseID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RefInvoiceNo", _sRefInvoiceNo);
                cmd.Parameters.AddWithValue("RefInvoiceDate", _dRefInvoiceDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);


                cmd.Parameters.AddWithValue("OrderNo", _sOrderNo);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
    public class DMSSecondarySalesOrders : CollectionBase
    {
        public DMSSecondarySalesOrder this[int i]
        {
            get { return (DMSSecondarySalesOrder)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DMSSecondarySalesOrder oDMSSecondarySalesOrder)
        {
            InnerList.Add(oDMSSecondarySalesOrder);
        }
        public int GetIndex(int nOrderID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].OrderID == nOrderID)
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
            string sSql = "SELECT * FROM t_DMSSecondarySalesOrder";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSSecondarySalesOrder oDMSSecondarySalesOrder = new DMSSecondarySalesOrder();
                    oDMSSecondarySalesOrder.OrderID = (int)reader["OrderID"];
                    oDMSSecondarySalesOrder.OrderNo = (string)reader["OrderNo"];
                    oDMSSecondarySalesOrder.CustomerID = (int)reader["CustomerID"];
                    oDMSSecondarySalesOrder.ParentCustomerId = (int)reader["ParentCustomerId"];
                    oDMSSecondarySalesOrder.EDD = Convert.ToDateTime(reader["EDD"].ToString());
                    oDMSSecondarySalesOrder.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oDMSSecondarySalesOrder.Status = (int)reader["Status"];
                    oDMSSecondarySalesOrder.CreateUserID = (int)reader["CreateUserID"];
                    oDMSSecondarySalesOrder.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oDMSSecondarySalesOrder.UpdateUserID = (int)reader["UpdateUserID"];
                    oDMSSecondarySalesOrder.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oDMSSecondarySalesOrder.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oDMSSecondarySalesOrder);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetOrderData(DateTime dFromDate, DateTime dToDate, string sOrderNo, string sCustomerCode, string sCustomerName, int nChannel, int nStatus, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select isnull(RefInvoiceNo,'') RefInvoiceNo,RefInvoiceDate,a.SalesType,OrderID,OrderNo,OrderAmount,a.CustomerID,b.CustomerCode,b.CustomerName,CustomerTypeName, " +
                       "b.ChannelID,b.ChannelDescription as ChannelName,a.ParentCustomerID, " +
                       "'['+c.CustomerCode+']'+' '+c.CustomerName as ParentCustomer, " +
                       "OrderAmount as Amount,a.Status,a.CreateDate,CreateUserID,EDD,isnull(a.Remarks,'') Remarks, WarehouseID ,isnull(OrderType,'') OrderType " +
                       "From dbo.t_DMSSecondarySalesOrder a,v_CustomerDetails b,t_Customer c " +
                       "where a.CustomerID=b.CustomerID and a.ParentCustomerID=c.CustomerID";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND a.CreateDate between '" + dFromDate + "' and '" + dToDate + "' and a.CreateDate<'" + dToDate + "' ";
            }

            if (sOrderNo != "")
            {
                sSql = sSql + " AND OrderNo like '%" + sOrderNo + "%'";
            }
            if (sCustomerCode != "")
            {
                sSql = sSql + " AND b.CustomerCode like '%" + sCustomerCode + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND b.CustomerName like '%" + sCustomerName + "%'";
            }
            if (nChannel != -1)
            {
                sSql = sSql + " AND a.SalesType=" + nChannel + "";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND a.Status=" + nStatus + "";
            }
           
            sSql = sSql + " Order by OrderID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSSecondarySalesOrder oDMSSecondarySalesOrder = new DMSSecondarySalesOrder();
                    oDMSSecondarySalesOrder.OrderID = (int)reader["OrderID"];
                    oDMSSecondarySalesOrder.OrderNo = (string)reader["OrderNo"];
                    oDMSSecondarySalesOrder.Amount = (double)reader["OrderAmount"];
                    oDMSSecondarySalesOrder.SalesType = (int)reader["SalesType"];
                    oDMSSecondarySalesOrder.CustomerCode = (string)reader["CustomerCode"];
                    oDMSSecondarySalesOrder.CustomerName = (string)reader["CustomerName"];
                    oDMSSecondarySalesOrder.ParentCustomer = (string)reader["ParentCustomer"];
                    oDMSSecondarySalesOrder.CustomerTypeName = (string)reader["CustomerTypeName"];
                    oDMSSecondarySalesOrder.ChannelName = (string)reader["ChannelName"];
                    oDMSSecondarySalesOrder.CustomerID = (int)reader["CustomerID"];
                    oDMSSecondarySalesOrder.ParentCustomerId = (int)reader["ParentCustomerID"];
                    oDMSSecondarySalesOrder.EDD = Convert.ToDateTime(reader["EDD"].ToString());
                    oDMSSecondarySalesOrder.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oDMSSecondarySalesOrder.Status = Convert.ToInt32(reader["Status"].ToString());
                    oDMSSecondarySalesOrder.CreateUserID = Convert.ToInt32(reader["CreateUserID"].ToString());
                    oDMSSecondarySalesOrder.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oDMSSecondarySalesOrder.Remarks = (string)reader["Remarks"];
                    oDMSSecondarySalesOrder.RefInvoiceNo = (string)reader["RefInvoiceNo"];
                    oDMSSecondarySalesOrder.WarehouseID = (int)reader["WarehouseID"];
                    if (reader["RefInvoiceDate"] != DBNull.Value)
                        oDMSSecondarySalesOrder.RefInvoiceDate = Convert.ToDateTime(reader["RefInvoiceDate"].ToString());
                    else oDMSSecondarySalesOrder.RefInvoiceDate = null;

                    oDMSSecondarySalesOrder.OrderType = (string)reader["OrderType"];

                    InnerList.Add(oDMSSecondarySalesOrder);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetOrderDataRT(DateTime dFromDate, DateTime dToDate, string sOrderNo, string sCustomerCode, string sCustomerName, int nChannel, int nStatus, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select isnull(RefInvoiceNo,'') RefInvoiceNo,RefInvoiceDate,a.SalesType,OrderID,OrderNo,OrderAmount,a.CustomerID,b.CustomerCode,b.CustomerName,CustomerTypeName, " +
                       "b.ChannelID,b.ChannelDescription as ChannelName,a.ParentCustomerID, " +
                       "'['+c.CustomerCode+']'+' '+c.CustomerName as ParentCustomer, " +
                       "OrderAmount as Amount,a.Status,a.CreateDate,CreateUserID,EDD,isnull(a.Remarks,'') Remarks, WarehouseID ,isnull(OrderType,'') OrderType " +
                       "From dbo.t_DMSSecondarySalesOrder a,v_CustomerDetails b,t_Customer c " +
                       "where a.CustomerID=b.CustomerID and a.ParentCustomerID=c.CustomerID and a.WarehouseID=" + Utility.WarehouseID + "";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND a.CreateDate between '" + dFromDate + "' and '" + dToDate + "' and a.CreateDate<'" + dToDate + "' ";
            }

            if (sOrderNo != "")
            {
                sSql = sSql + " AND OrderNo like '%" + sOrderNo + "%'";
            }
            if (sCustomerCode != "")
            {
                sSql = sSql + " AND b.CustomerCode like '%" + sCustomerCode + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND b.CustomerName like '%" + sCustomerName + "%'";
            }
            if (nChannel != -1)
            {
                sSql = sSql + " AND a.SalesType=" + nChannel + "";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND a.Status=" + nStatus + "";
            }

            sSql = sSql + " Order by OrderID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSSecondarySalesOrder oDMSSecondarySalesOrder = new DMSSecondarySalesOrder();
                    oDMSSecondarySalesOrder.OrderID = (int)reader["OrderID"];
                    oDMSSecondarySalesOrder.OrderNo = (string)reader["OrderNo"];
                    oDMSSecondarySalesOrder.Amount = (double)reader["OrderAmount"];
                    oDMSSecondarySalesOrder.SalesType = (int)reader["SalesType"];
                    oDMSSecondarySalesOrder.CustomerCode = (string)reader["CustomerCode"];
                    oDMSSecondarySalesOrder.CustomerName = (string)reader["CustomerName"];
                    oDMSSecondarySalesOrder.ParentCustomer = (string)reader["ParentCustomer"];
                    oDMSSecondarySalesOrder.CustomerTypeName = (string)reader["CustomerTypeName"];
                    oDMSSecondarySalesOrder.ChannelName = (string)reader["ChannelName"];
                    oDMSSecondarySalesOrder.CustomerID = (int)reader["CustomerID"];
                    oDMSSecondarySalesOrder.ParentCustomerId = (int)reader["ParentCustomerID"];
                    oDMSSecondarySalesOrder.EDD = Convert.ToDateTime(reader["EDD"].ToString());
                    oDMSSecondarySalesOrder.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oDMSSecondarySalesOrder.Status = Convert.ToInt32(reader["Status"].ToString());
                    oDMSSecondarySalesOrder.CreateUserID = Convert.ToInt32(reader["CreateUserID"].ToString());
                    oDMSSecondarySalesOrder.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oDMSSecondarySalesOrder.Remarks = (string)reader["Remarks"];
                    oDMSSecondarySalesOrder.RefInvoiceNo = (string)reader["RefInvoiceNo"];
                    oDMSSecondarySalesOrder.WarehouseID = (int)reader["WarehouseID"];
                    if (reader["RefInvoiceDate"] != DBNull.Value)
                        oDMSSecondarySalesOrder.RefInvoiceDate = Convert.ToDateTime(reader["RefInvoiceDate"].ToString());
                    else oDMSSecondarySalesOrder.RefInvoiceDate = null;

                    oDMSSecondarySalesOrder.OrderType = (string)reader["OrderType"];

                    InnerList.Add(oDMSSecondarySalesOrder);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetOrderData1(DateTime dFromDate, DateTime dToDate, string sOrderNo, string sCustomerCode, string sCustomerName, int nChannel, int nStatus, bool IsCheck, int nShowroom, int nSalesType)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select isnull(RefInvoiceNo,'') RefInvoiceNo,RefInvoiceDate,a.SalesType,OrderID,OrderNo,OrderAmount,a.CustomerID,b.CustomerCode,b.CustomerName,CustomerTypeName, " +
                       "b.ChannelID,b.ChannelDescription as ChannelName,a.ParentCustomerID, " +
                       "'['+c.CustomerCode+']'+' '+c.CustomerName as ParentCustomer, " +
                       "OrderAmount as Amount,a.Status,a.CreateDate,CreateUserID,EDD,isnull(a.Remarks,'') Remarks, WarehouseID  " +
                       "From dbo.t_DMSSecondarySalesOrder a,v_CustomerDetails b,t_Customer c " +
                       "where a.CustomerID=b.CustomerID and a.ParentCustomerID=c.CustomerID and a.SalesType='"+ nSalesType + "'";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND a.CreateDate between '" + dFromDate + "' and '" + dToDate + "' and a.CreateDate<'" + dToDate + "' ";
            }

            if (sOrderNo != "")
            {
                sSql = sSql + " AND OrderNo like '%" + sOrderNo + "%'";
            }
            if (sCustomerCode != "")
            {
                sSql = sSql + " AND b.CustomerCode like '%" + sCustomerCode + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND b.CustomerName like '%" + sCustomerName + "%'";
            }
            if (nChannel != -1)
            {
                sSql = sSql + " AND a.SalesType=" + nChannel + "";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND a.Status=" + nStatus + "";
            }
            if (nShowroom != -1)
            {
                sSql = sSql + " AND a.WarehouseID=" + nShowroom + "";
            }
            sSql = sSql + " Order by OrderID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSSecondarySalesOrder oDMSSecondarySalesOrder = new DMSSecondarySalesOrder();
                    oDMSSecondarySalesOrder.OrderID = (int)reader["OrderID"];
                    oDMSSecondarySalesOrder.OrderNo = (string)reader["OrderNo"];
                    oDMSSecondarySalesOrder.Amount = (double)reader["OrderAmount"];
                    oDMSSecondarySalesOrder.SalesType = (int)reader["SalesType"];
                    oDMSSecondarySalesOrder.CustomerCode = (string)reader["CustomerCode"];
                    oDMSSecondarySalesOrder.CustomerName = (string)reader["CustomerName"];
                    oDMSSecondarySalesOrder.ParentCustomer = (string)reader["ParentCustomer"];
                    oDMSSecondarySalesOrder.CustomerTypeName = (string)reader["CustomerTypeName"];
                    oDMSSecondarySalesOrder.ChannelName = (string)reader["ChannelName"];
                    oDMSSecondarySalesOrder.CustomerID = (int)reader["CustomerID"];
                    oDMSSecondarySalesOrder.ParentCustomerId = (int)reader["ParentCustomerID"];
                    oDMSSecondarySalesOrder.EDD = Convert.ToDateTime(reader["EDD"].ToString());
                    oDMSSecondarySalesOrder.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oDMSSecondarySalesOrder.Status = Convert.ToInt32(reader["Status"].ToString());
                    oDMSSecondarySalesOrder.CreateUserID = Convert.ToInt32(reader["CreateUserID"].ToString());
                    oDMSSecondarySalesOrder.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oDMSSecondarySalesOrder.Remarks = (string)reader["Remarks"];
                    oDMSSecondarySalesOrder.RefInvoiceNo = (string)reader["RefInvoiceNo"];
                    oDMSSecondarySalesOrder.WarehouseID = (int)reader["WarehouseID"];
                    if (reader["RefInvoiceDate"] != DBNull.Value)
                        oDMSSecondarySalesOrder.RefInvoiceDate = Convert.ToDateTime(reader["RefInvoiceDate"].ToString());
                    else oDMSSecondarySalesOrder.RefInvoiceDate = null;

                    InnerList.Add(oDMSSecondarySalesOrder);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetConfirmOrderList(string sOrderNo, string sCustomerName,int _nSalesType)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            {
                sSql = "Select a.SalesType,OrderID,OrderNo,a.CustomerID,b.CustomerCode,b.CustomerName,CustomerTypeName,  " +
                    "b.ChannelID,b.ChannelDescription as ChannelName,a.ParentCustomerID,  " +
                    "OrderAmount as Amount,a.Status,a.CreateDate,CreateUserID,EDD,isnull(a.Remarks,'') Remarks    " +
                    "From dbo.t_DMSSecondarySalesOrder a,v_CustomerDetails b   " +
                    "where a.CustomerID=b.CustomerID and Status=" + (int)Dictionary.DMSSecondarySalesOrderStatus.Approved_By_HO + " and a.SalesType=" + _nSalesType + "";

            }
            if (sOrderNo != "")
            {
                sSql = sSql + " AND a.OrderNo like '%" + sOrderNo + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND b.CustomerName like '%" + sCustomerName + "%'";
            }
            sSql = sSql + " Order by a.OrderID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSSecondarySalesOrder oDMSSecondarySalesOrder = new DMSSecondarySalesOrder();
                    oDMSSecondarySalesOrder.OrderID = (int)reader["OrderID"];
                    oDMSSecondarySalesOrder.OrderNo = (string)reader["OrderNo"];
                    oDMSSecondarySalesOrder.SalesType = (int)reader["SalesType"];
                    oDMSSecondarySalesOrder.CustomerCode = (string)reader["CustomerCode"];
                    oDMSSecondarySalesOrder.CustomerName = (string)reader["CustomerName"];
                    oDMSSecondarySalesOrder.ChannelName = (string)reader["ChannelName"];
                    oDMSSecondarySalesOrder.CustomerID = (int)reader["CustomerID"];
                    oDMSSecondarySalesOrder.ParentCustomerId = (int)reader["ParentCustomerID"];
                    oDMSSecondarySalesOrder.EDD = Convert.ToDateTime(reader["EDD"].ToString());
                    oDMSSecondarySalesOrder.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oDMSSecondarySalesOrder.Status = Convert.ToInt32(reader["Status"].ToString());
                    oDMSSecondarySalesOrder.CreateUserID = Convert.ToInt32(reader["CreateUserID"].ToString());
                    oDMSSecondarySalesOrder.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oDMSSecondarySalesOrder.Remarks = (string)reader["Remarks"];


                    InnerList.Add(oDMSSecondarySalesOrder);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetConfirmOrderListRT(string sOrderNo, string sCustomerName, int _nSalesType, int _nWarehouseID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            {
                sSql = "Select a.SalesType,OrderID,OrderNo,a.CustomerID,b.CustomerCode,b.CustomerName,CustomerTypeName,  " +
                    "b.ChannelID,b.ChannelDescription as ChannelName,a.ParentCustomerID,  " +
                    "OrderAmount as Amount,a.Status,a.CreateDate,CreateUserID,EDD,isnull(a.Remarks,'') Remarks    " +
                    "From dbo.t_DMSSecondarySalesOrder a,v_CustomerDetails b   " +
                    "where a.CustomerID=b.CustomerID and Status=" + (int)Dictionary.DMSSecondarySalesOrderStatus.Approved_By_HO + " and a.SalesType=" + _nSalesType + " and a.WarehouseID=" + _nWarehouseID + "";

            }
            if (sOrderNo != "")
            {
                sSql = sSql + " AND a.OrderNo like '%" + sOrderNo + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND b.CustomerName like '%" + sCustomerName + "%'";
            }
            sSql = sSql + " Order by a.OrderID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSSecondarySalesOrder oDMSSecondarySalesOrder = new DMSSecondarySalesOrder();
                    oDMSSecondarySalesOrder.OrderID = (int)reader["OrderID"];
                    oDMSSecondarySalesOrder.OrderNo = (string)reader["OrderNo"];
                    oDMSSecondarySalesOrder.SalesType = (int)reader["SalesType"];
                    oDMSSecondarySalesOrder.CustomerCode = (string)reader["CustomerCode"];
                    oDMSSecondarySalesOrder.CustomerName = (string)reader["CustomerName"];
                    oDMSSecondarySalesOrder.ChannelName = (string)reader["ChannelName"];
                    oDMSSecondarySalesOrder.CustomerID = (int)reader["CustomerID"];
                    oDMSSecondarySalesOrder.ParentCustomerId = (int)reader["ParentCustomerID"];
                    oDMSSecondarySalesOrder.EDD = Convert.ToDateTime(reader["EDD"].ToString());
                    oDMSSecondarySalesOrder.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oDMSSecondarySalesOrder.Status = Convert.ToInt32(reader["Status"].ToString());
                    oDMSSecondarySalesOrder.CreateUserID = Convert.ToInt32(reader["CreateUserID"].ToString());
                    oDMSSecondarySalesOrder.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oDMSSecondarySalesOrder.Remarks = (string)reader["Remarks"];


                    InnerList.Add(oDMSSecondarySalesOrder);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetConfirmOrderListRT(string sOrderNo, string sCustomerName, int _nSalesType)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            {
                sSql = "Select a.SalesType,OrderID,OrderNo,a.CustomerID,b.CustomerCode,b.CustomerName,CustomerTypeName,  " +
                    "b.ChannelID,b.ChannelDescription as ChannelName,a.ParentCustomerID,  " +
                    "OrderAmount as Amount,a.Status,a.CreateDate,CreateUserID,EDD,isnull(a.Remarks,'') Remarks    " +
                    "From dbo.t_DMSSecondarySalesOrder a,v_CustomerDetails b   " +
                    "where a.CustomerID=b.CustomerID and a.WarehouseId=" + Utility.WarehouseID + " and Status=" + (int)Dictionary.DMSSecondarySalesOrderStatus.Approved_By_HO + " and a.SalesType=" + _nSalesType + "";

            }
            if (sOrderNo != "")
            {
                sSql = sSql + " AND a.OrderNo like '%" + sOrderNo + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND b.CustomerName like '%" + sCustomerName + "%'";
            }
            sSql = sSql + " Order by a.OrderID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSSecondarySalesOrder oDMSSecondarySalesOrder = new DMSSecondarySalesOrder();
                    oDMSSecondarySalesOrder.OrderID = (int)reader["OrderID"];
                    oDMSSecondarySalesOrder.OrderNo = (string)reader["OrderNo"];
                    oDMSSecondarySalesOrder.SalesType = (int)reader["SalesType"];
                    oDMSSecondarySalesOrder.CustomerCode = (string)reader["CustomerCode"];
                    oDMSSecondarySalesOrder.CustomerName = (string)reader["CustomerName"];
                    oDMSSecondarySalesOrder.ChannelName = (string)reader["ChannelName"];
                    oDMSSecondarySalesOrder.CustomerID = (int)reader["CustomerID"];
                    oDMSSecondarySalesOrder.ParentCustomerId = (int)reader["ParentCustomerID"];
                    oDMSSecondarySalesOrder.EDD = Convert.ToDateTime(reader["EDD"].ToString());
                    oDMSSecondarySalesOrder.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oDMSSecondarySalesOrder.Status = Convert.ToInt32(reader["Status"].ToString());
                    oDMSSecondarySalesOrder.CreateUserID = Convert.ToInt32(reader["CreateUserID"].ToString());
                    oDMSSecondarySalesOrder.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oDMSSecondarySalesOrder.Remarks = (string)reader["Remarks"];


                    InnerList.Add(oDMSSecondarySalesOrder);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void PrintDMSSalesOrder(int nOrderID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"Select a.OrderID,OrderNo,CreateDate,EDD,OrderQty,OrderAmount,UnitPrice,CustomerCode,
                            CustomerName,CustomerAddress,WarehouseName,ProductCode,ProductName
                            from t_DMSSecondarySalesOrder a, t_DMSSecondarySalesOrderDetail b,t_Customer c,t_Warehouse d,t_Product e
                            Where a.OrderID=b.OrderID and a.CustomerID=c.CustomerID and a.WarehouseID=d.WarehouseID
                            and b.ProductID=e.ProductID and a.OrderID="+nOrderID+"";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSSecondarySalesOrderDetail oDMSSecondarySalesOrderDetail = new DMSSecondarySalesOrderDetail();
                    oDMSSecondarySalesOrderDetail.OrderID = (int)reader["OrderID"];
                    oDMSSecondarySalesOrderDetail.OrderNo = (string)reader["OrderNo"];
                    oDMSSecondarySalesOrderDetail.OrderQty = (int)reader["OrderQty"];
                    oDMSSecondarySalesOrderDetail.UnitPrice = (double)reader["UnitPrice"];
                    oDMSSecondarySalesOrderDetail.CustomerName= (string)reader["CustomerName"];
                    oDMSSecondarySalesOrderDetail.CustomerAddress = (string)reader["CustomerAddress"];
                    oDMSSecondarySalesOrderDetail.ProductCode = (string)reader["ProductCode"];
                    oDMSSecondarySalesOrderDetail.ProductName = (string)reader["ProductName"];
                    oDMSSecondarySalesOrderDetail.WarehouseName= (string)reader["WarehouseName"];                  
                    InnerList.Add(oDMSSecondarySalesOrderDetail);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void PrintDMSSalesOrderRT(int nOrderID, int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"Select a.OrderID,OrderNo,CreateDate,EDD,OrderQty,OrderAmount,UnitPrice,CustomerCode,
                            CustomerName,CustomerAddress,WarehouseName,ProductCode,ProductName
                            from t_DMSSecondarySalesOrder a, t_DMSSecondarySalesOrderDetail b,t_Customer c,t_Warehouse d,t_Product e
                            Where a.OrderID=b.OrderID and a.CustomerID=c.CustomerID and a.WarehouseID=d.WarehouseID
                            and b.ProductID=e.ProductID and a.OrderID=" + nOrderID + " and a.WarehouseID="+nWarehouseID+"";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DMSSecondarySalesOrderDetail oDMSSecondarySalesOrderDetail = new DMSSecondarySalesOrderDetail();
                    oDMSSecondarySalesOrderDetail.OrderID = (int)reader["OrderID"];
                    oDMSSecondarySalesOrderDetail.OrderNo = (string)reader["OrderNo"];
                    oDMSSecondarySalesOrderDetail.OrderQty = (int)reader["OrderQty"];
                    oDMSSecondarySalesOrderDetail.UnitPrice = (double)reader["UnitPrice"];
                    oDMSSecondarySalesOrderDetail.CustomerName = (string)reader["CustomerName"];
                    oDMSSecondarySalesOrderDetail.CustomerAddress = (string)reader["CustomerAddress"];
                    oDMSSecondarySalesOrderDetail.ProductCode = (string)reader["ProductCode"];
                    oDMSSecondarySalesOrderDetail.ProductName = (string)reader["ProductName"];
                    oDMSSecondarySalesOrderDetail.WarehouseName = (string)reader["WarehouseName"];
                    InnerList.Add(oDMSSecondarySalesOrderDetail);
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


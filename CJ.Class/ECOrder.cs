// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Aug 28, 2012
// Time :  11:00 AM
// Description: Class for ecommerce sales tracking.
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
    public class ECOrderDetail
    {
        private int _OrderID;
        private int _ProductID;
        private string _ProductCode;
        private string _ProductName;
        private int _Qty;


        /// <summary>
        /// Get set property for OrderID
        /// </summary>
        public int OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }

        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }

        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public string ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = value; }
        }

        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }

        /// <summary>
        /// Get set property for Qty
        /// </summary>
        public int Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }

        public void Insert(int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_ECOderDetail VALUES (?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OrderID", nOrderID);            
                cmd.Parameters.AddWithValue("ProductID", _ProductID);
                cmd.Parameters.AddWithValue("Qty", _Qty);
               
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
                cmd.CommandText = "Delete from  t_ECOderDetail Where OrderID=? ";
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
    public class ECOrder : CollectionBase
    {
        public ECOrderDetail this[int i]
        {
            get { return (ECOrderDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ECOrderDetail oECOrderDetail)
        {
            InnerList.Add(oECOrderDetail);
        }

        private int _OrderID;
        private string _OrderNo;
        private DateTime _OrderDate;
        private int _OrderStatus;
        private string _CustomerName;
        private string _CustomerAddress;
        private string _CustomerMailID;
        private string _CustomerMobileNo;
        private double _Amount;
        private int _PaymentMode;
        private string _PaymentDes;
        private int _DeliveryMode;
        private int _DeliveryWHID;
        private string _DeliveryAddress;
        private DateTime _DesiredDeliveryDate;
        private DateTime _DesiredPaymentDate;
        private object _DesiredStockAvailableDate;

        private int _Status;
        private int _UserID;
        private DateTime _Date;
        private string _Remarks;

        private Warehouse _oWarehouse;
        public Warehouse Warehouse
        {
            get
            {
                if (_oWarehouse == null)
                {
                    _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseID = _DeliveryWHID;
                    _oWarehouse.Reresh();
                }
                return _oWarehouse;
            }
        }
        private User _oUser;
        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                    _oUser.UserId = _UserID;
                    _oUser.RefreshByUserID();
                }
                return _oUser;
            }
        }
        
        /// <summary>
        /// Get set property for OrderID
        /// </summary>
        public int OrderID
        {
            get { return _OrderID; }
            set { _OrderID = value; }
        }

        /// <summary>
        /// Get set property for OrderNo
        /// </summary>
        public string OrderNo
        {
            get { return _OrderNo; }
            set { _OrderNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for OrderDate
        /// </summary>
        public DateTime OrderDate
        {
            get { return _OrderDate; }
            set { _OrderDate = value; }
        }

        /// <summary>
        /// Get set property for OrderStatus
        /// </summary>
        public int OrderStatus
        {
            get { return _OrderStatus; }
            set { _OrderStatus = value; }
        }

        /// <summary>
        /// Get set property for CustomerName
        /// </summary>
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for CustomerAddress
        /// </summary>
        public string CustomerAddress
        {
            get { return _CustomerAddress; }
            set { _CustomerAddress = value.Trim(); }
        }

        /// <summary>
        /// Get set property for CustomerMailID
        /// </summary>
        public string CustomerMailID
        {
            get { return _CustomerMailID; }
            set { _CustomerMailID = value.Trim(); }
        }

        /// <summary>
        /// Get set property for CustomerMobileNo
        /// </summary>
        public string CustomerMobileNo
        {
            get { return _CustomerMobileNo; }
            set { _CustomerMobileNo = value.Trim(); }
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
        /// Get set property for PaymentMode
        /// </summary>
        public int PaymentMode
        {
            get { return _PaymentMode; }
            set { _PaymentMode = value; }
        }

        /// <summary>
        /// Get set property for PaymentDes
        /// </summary>
        public string PaymentDes
        {
            get { return _PaymentDes; }
            set { _PaymentDes = value.Trim(); }
        }

        /// <summary>
        /// Get set property for DeliveryMode
        /// </summary>
        public int DeliveryMode
        {
            get { return _DeliveryMode; }
            set { _DeliveryMode = value; }
        }

        /// <summary>
        /// Get set property for DeliveryWHID
        /// </summary>
        public int DeliveryWHID
        {
            get { return _DeliveryWHID; }
            set { _DeliveryWHID = value; }
        }

        /// <summary>
        /// Get set property for DeliveryAddress
        /// </summary>
        public string DeliveryAddress
        {
            get { return _DeliveryAddress; }
            set { _DeliveryAddress = value.Trim(); }
        }

        /// <summary>
        /// Get set property for DesiredDeliveryDate
        /// </summary>
        public DateTime DesiredDeliveryDate
        {
            get { return _DesiredDeliveryDate; }
            set { _DesiredDeliveryDate = value; }
        }

        /// <summary>
        /// Get set property for DesiredPaymentDate
        /// </summary>
        public DateTime DesiredPaymentDate
        {
            get { return _DesiredPaymentDate; }
            set { _DesiredPaymentDate = value; }
        }

        /// <summary>
        /// Get set property for DesiredStockAvailableDate
        /// </summary>
        public object DesiredStockAvailableDate
        {
            get { return _DesiredStockAvailableDate; }
            set { _DesiredStockAvailableDate = value; }
        }

        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        /// <summary>
        /// Get set property for UserID
        /// </summary>
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        /// <summary>
        /// Get set property for Date
        /// </summary>
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value.Trim(); }
        }

        public void Insert()
        {
            int nMaxOrderID = 0;       

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([OrderID]) FROM t_ECOrder";
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
                _OrderID = nMaxOrderID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ECOrder VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _OrderID);
                cmd.Parameters.AddWithValue("OrderNo", _OrderNo);
                cmd.Parameters.AddWithValue("OrderDate", _OrderDate);
                cmd.Parameters.AddWithValue("OrderStatus", _OrderStatus);
                cmd.Parameters.AddWithValue("CustomerName", _CustomerName);
                cmd.Parameters.AddWithValue("CustomerAddress", _CustomerAddress);
                cmd.Parameters.AddWithValue("CustomerMailID", _CustomerMailID);
                cmd.Parameters.AddWithValue("CustomerMobileNo", _CustomerMobileNo);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("PaymentMode", _PaymentMode);
                cmd.Parameters.AddWithValue("PaymentDes", _PaymentDes);
                cmd.Parameters.AddWithValue("DeliveryMode", _DeliveryMode);
                cmd.Parameters.AddWithValue("DeliveryWHID", _DeliveryWHID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _DeliveryAddress);
                cmd.Parameters.AddWithValue("DesiredDeliveryDate", _DesiredDeliveryDate);
                cmd.Parameters.AddWithValue("DesiredPaymentDate", _DesiredPaymentDate);
                cmd.Parameters.AddWithValue("DesiredStockAvailableDate", null);
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ECOrderDetail oItem in this)
                {
                    oItem.Insert(_OrderID);
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ECOrderHist VALUES(?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _OrderID);
                cmd.Parameters.AddWithValue("Status", _OrderStatus);
                cmd.Parameters.AddWithValue("UserID", _UserID);
                cmd.Parameters.AddWithValue("HistDate", _Date);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);

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
            int nCount = 1;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "update  t_ECOrder set OrderDate=?,CustomerName=?,CustomerAddress=?,CustomerMailID=?,CustomerMobileNo=?,Amount=?,PaymentMode=?," +
                    "PaymentDes=?,DeliveryMode=?,DeliveryWHID=?,DeliveryAddress=?,DesiredDeliveryDate=?,DesiredPaymentDate=?,DesiredStockAvailableDate=? where OrderID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderDate", _OrderDate);        
                cmd.Parameters.AddWithValue("CustomerName", _CustomerName);
                cmd.Parameters.AddWithValue("CustomerAddress", _CustomerAddress);
                cmd.Parameters.AddWithValue("CustomerMailID", _CustomerMailID);
                cmd.Parameters.AddWithValue("CustomerMobileNo", _CustomerMobileNo);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("PaymentMode", _PaymentMode);
                cmd.Parameters.AddWithValue("PaymentDes", _PaymentDes);
                cmd.Parameters.AddWithValue("DeliveryMode", _DeliveryMode);
                cmd.Parameters.AddWithValue("DeliveryWHID", _DeliveryWHID);
                cmd.Parameters.AddWithValue("DeliveryAddress", _DeliveryAddress);
                cmd.Parameters.AddWithValue("DesiredDeliveryDate", _DesiredDeliveryDate);
                cmd.Parameters.AddWithValue("DesiredPaymentDate", _DesiredPaymentDate);
                cmd.Parameters.AddWithValue("DesiredStockAvailableDate", _DesiredStockAvailableDate);

                cmd.Parameters.AddWithValue("OrderID", _OrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (ECOrderDetail oItem in this)
                {
                    if (nCount == 1)
                    {
                        oItem.Delete(_OrderID);
                        nCount++;
                    }
                    oItem.Insert(_OrderID);
                }               

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
                cmd.CommandText = "update  t_ECOrder set OrderStatus=? where OrderID=?";

                cmd.CommandType = CommandType.Text;

               
                cmd.Parameters.AddWithValue("OrderStatus", _OrderStatus);              

                cmd.Parameters.AddWithValue("OrderID", _OrderID);

                cmd.ExecuteNonQuery();
               
              
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ECOrderHist VALUES(?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _OrderID);
                cmd.Parameters.AddWithValue("Status", _OrderStatus);
                cmd.Parameters.AddWithValue("UserID", _UserID);
                cmd.Parameters.AddWithValue("HistDate", _Date);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStockAvailableDate()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "update  t_ECOrder set OrderStatus=?,DesiredStockAvailableDate=? where OrderID=?";

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("OrderStatus", _OrderStatus);
                cmd.Parameters.AddWithValue("DesiredStockAvailableDate", _DesiredStockAvailableDate);

                cmd.Parameters.AddWithValue("OrderID", _OrderID);

                cmd.ExecuteNonQuery();


                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_ECOrderHist VALUES(?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _OrderID);
                cmd.Parameters.AddWithValue("Status", _OrderStatus);
                cmd.Parameters.AddWithValue("UserID", _UserID);
                cmd.Parameters.AddWithValue("HistDate", _Date);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete( int nOrderID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_ECOderDetail WHERE OrderID=? ";
               

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OrderID", nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
               
                cmd = DBController.Instance.GetCommand();

                sSql = "DELETE FROM t_ECOrderHist WHERE OrderID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OrderID", nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                sSql = "DELETE FROM t_ECOrder WHERE OrderID=? ";
                cmd.CommandText = sSql;
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

        public void RefreshItem()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT a.*,ProductCode,ProductName FROM t_ECOderDetail a, t_Product b where a.ProductID=b.ProductID and OrderID = '" + _OrderID + "'";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ECOrderDetail oItem = new ECOrderDetail();

                    oItem.ProductID = int.Parse(reader["ProductID"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());  
                    oItem.Qty = int.Parse(reader["Qty"].ToString());                  
                  
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
        public void Refresh()
        {          
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT *  FROM t_ECOrder  Where OrderID=?";
            cmd.Parameters.AddWithValue("OrderID", _OrderID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {             

                   _OrderID = int.Parse(reader["OrderID"].ToString());
                   _OrderNo = reader["OrderNo"].ToString();
                   _OrderDate = (DateTime)reader["OrderDate"];
                   _OrderStatus = int.Parse(reader["OrderStatus"].ToString());
                   _CustomerName = reader["CustomerName"].ToString();
                   _CustomerAddress = reader["CustomerAddress"].ToString();
                   _CustomerMailID = reader["CustomerMailID"].ToString();
                   _CustomerMobileNo = reader["CustomerMobileNo"].ToString();
                   _Amount = Convert.ToDouble(reader["Amount"].ToString());
                   _PaymentMode = int.Parse(reader["PaymentMode"].ToString());
                   _PaymentDes = reader["PaymentDes"].ToString();
                   _DeliveryMode = int.Parse(reader["DeliveryMode"].ToString());
                   _DeliveryWHID = int.Parse(reader["DeliveryWHID"].ToString());
                   _DeliveryAddress = reader["DeliveryAddress"].ToString();
                   _DesiredDeliveryDate = (DateTime)reader["DesiredDeliveryDate"];
                   _DesiredPaymentDate = (DateTime)reader["DesiredPaymentDate"];
                   _DesiredStockAvailableDate = (object)reader["DesiredStockAvailableDate"];
                  
                }
                reader.Close();
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshHistoryByStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT *  FROM t_ECOrderHist  Where OrderID=? and Status=?";
            cmd.Parameters.AddWithValue("OrderID", _OrderID);
            cmd.Parameters.AddWithValue("Status", _OrderStatus);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _Remarks = reader["Remarks"].ToString();               

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public bool CheckOrder()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT *  FROM t_ECOrder  Where OrderNo=?";
            cmd.Parameters.AddWithValue("OrderID", _OrderNo);
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
    public class ECOrders : CollectionBase
    {
        public ECOrder this[int i]
        {
            get { return (ECOrder)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ECOrder oECOrder)
        {
            InnerList.Add(oECOrder);
        }

        public void Refresh(DateTime dFromDate, DateTime dToDate, string sOrderNo, int nOrderSatus, int nWarehouseID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            //string sSql = "SELECT *  FROM t_ECOrder "
            //  + " where  OrderDate between '" + dFromDate + "' and '" + dToDate + "' and OrderDate < '" + dToDate + "' and "
            //  + " DeliveryWHID in "
            //  + " ( "
            //  + " select a.WarehouseID from t_warehouse a ,t_UserPermissionData b "
            //  + " where b.DataID=a.WarehouseID and b.UserID= '" + nUserID + "' and DataType='Warehouse' "
            //  + " ) ";

            string sSql = "SELECT *  FROM t_ECOrder where  OrderDate between ? and ? and OrderDate < ? and DeliveryWHID =? ";

            cmd.Parameters.AddWithValue("OrderDate", dFromDate);
            cmd.Parameters.AddWithValue("OrderDate", dToDate);
            cmd.Parameters.AddWithValue("OrderDate", dToDate);
            cmd.Parameters.AddWithValue("DeliveryWHID", nWarehouseID);

            if (sOrderNo != "")
            {
                sOrderNo = "%" + sOrderNo + "%";
                sSql = sSql + "and OrderNo like '" + sOrderNo + "'";
            }
            if (nOrderSatus > 0)
            {
                sSql = sSql + "and OrderStatus='" + nOrderSatus + "'";
            }

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetDataDetail(cmd);
        }
        public void RefreshDesktop(DateTime dFromDate, DateTime dToDate, string sOrderNo, int nOrderSatus, string sCustomerName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "SELECT *  FROM t_ECOrder where  OrderDate between ? and ? and OrderDate < ? ";

            cmd.Parameters.AddWithValue("OrderDate", dFromDate);
            cmd.Parameters.AddWithValue("OrderDate", dToDate);
            cmd.Parameters.AddWithValue("OrderDate", dToDate);

            if (sOrderNo != "")
            {
                sSql = sSql + "and OrderNo ='" + sOrderNo + "'";
            }
            if (nOrderSatus > 0)
            {
                sSql = sSql + "and OrderStatus='" + nOrderSatus + "'";
            }
            if (sCustomerName != "")
            {
                sCustomerName = "%" + sCustomerName + "%";
                sSql = sSql + "and CustomerName like '" + sCustomerName + "'";
            }

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetDataDetail(cmd);
        }
        private void GetDataDetail(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ECOrder oECOrder = new ECOrder();

                    oECOrder.OrderID = int.Parse(reader["OrderID"].ToString());
                    oECOrder.OrderNo = reader["OrderNo"].ToString();
                    oECOrder.OrderDate = (DateTime)reader["OrderDate"];
                    oECOrder.OrderStatus = int.Parse(reader["OrderStatus"].ToString());
                    oECOrder.CustomerName = reader["CustomerName"].ToString();
                    oECOrder.CustomerAddress = reader["CustomerAddress"].ToString();
                    oECOrder.CustomerMailID = reader["CustomerMailID"].ToString();
                    oECOrder.CustomerMobileNo = reader["CustomerMobileNo"].ToString();
                    oECOrder.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oECOrder.PaymentMode = int.Parse(reader["PaymentMode"].ToString());
                    oECOrder.PaymentDes = reader["PaymentDes"].ToString();
                    oECOrder.DeliveryMode = int.Parse(reader["DeliveryMode"].ToString());
                    oECOrder.DeliveryWHID = int.Parse(reader["DeliveryWHID"].ToString());
                    oECOrder.DeliveryAddress = reader["DeliveryAddress"].ToString();
                    oECOrder.DesiredDeliveryDate = (DateTime)reader["DesiredDeliveryDate"];
                    oECOrder.DesiredPaymentDate = (DateTime)reader["DesiredPaymentDate"];
                    oECOrder.DesiredStockAvailableDate = (object)reader["DesiredStockAvailableDate"];

                    InnerList.Add(oECOrder);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshHistory(int nOrderID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT *  FROM t_ECOrderHist Where OrderID='" + nOrderID + "' ";                         

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ECOrder oECOrder = new ECOrder();

                    oECOrder.Status = int.Parse(reader["Status"].ToString());
                    oECOrder.UserID = int.Parse(reader["UserID"].ToString());
                    oECOrder.Date = (DateTime)reader["HistDate"];
                    oECOrder.Remarks = reader["Remarks"].ToString();       

                    InnerList.Add(oECOrder);
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

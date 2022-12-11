
// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Nov 12, 2018
// Time : 04:15 PM
// Description: Class for SalesOrderFactory.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.BEIL
{
    public class SalesOrderFactoryDetail
    {
        private int _nID;
        private int _nOrderID;
        private int _nProductID;
        private double _CostPrice;
        private double _RSP;
        private int _nOrderQty;
        private int _nDeliveryQty;


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
        // Get set property for CostPrice
        // </summary>
        public double CostPrice
        {
            get { return _CostPrice; }
            set { _CostPrice = value; }
        }

        // <summary>
        // Get set property for RSP
        // </summary>
        public double RSP
        {
            get { return _RSP; }
            set { _RSP = value; }
        }

        // <summary>
        // Get set property for OrderQty
        // </summary>
        public int OrderQty
        {
            get { return _nOrderQty; }
            set { _nOrderQty = value; }
        }

        // <summary>
        // Get set property for DeliveryQty
        // </summary>
        public int DeliveryQty
        {
            get { return _nDeliveryQty; }
            set { _nDeliveryQty = value; }
        }

        public void Add(int _nOrderID)
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_SalesOrderFactoryDetail";
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
                sSql = "INSERT INTO t_SalesOrderFactoryDetail (ID, OrderID, ProductID, CostPrice, RSP, OrderQty, DeliveryQty) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("CostPrice", _CostPrice);
                cmd.Parameters.AddWithValue("RSP", _RSP);
                cmd.Parameters.AddWithValue("OrderQty", _nOrderQty);
                cmd.Parameters.AddWithValue("DeliveryQty", _nDeliveryQty);

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
                sSql = "UPDATE t_SalesOrderFactoryDetail SET OrderID = ?, ProductID = ?, CostPrice = ?, RSP = ?, OrderQty = ?, DeliveryQty = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("CostPrice", _CostPrice);
                cmd.Parameters.AddWithValue("RSP", _RSP);
                cmd.Parameters.AddWithValue("OrderQty", _nOrderQty);
                cmd.Parameters.AddWithValue("DeliveryQty", _nDeliveryQty);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateByDeliveryWise(int nOrderID , int nID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesOrderFactoryDetail SET DeliveryQty = DeliveryQty + ? WHERE OrderID = ? And ID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DeliveryQty", _nDeliveryQty);
                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.Parameters.AddWithValue("ID", nID);
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
                sSql = "DELETE FROM t_SalesOrderFactoryDetail WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_SalesOrderFactoryDetail where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nOrderID = (int)reader["OrderID"];
                    _nProductID = (int)reader["ProductID"];
                    _CostPrice = Convert.ToDouble(reader["CostPrice"].ToString());
                    _RSP = Convert.ToDouble(reader["RSP"].ToString());
                    _nOrderQty = (int)reader["OrderQty"];
                    _nDeliveryQty = (int)reader["DeliveryQty"];
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
    public class SalesOrderFactory:CollectionBase
    {
        public SalesOrderFactoryDetail this[int i]
        {
            get { return (SalesOrderFactoryDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SalesOrderFactoryDetail oSalesOrderFactoryDetail)
        {
            InnerList.Add(oSalesOrderFactoryDetail);
        }
        private int _nOrderID;
        private string _sOrderNumber;
        private DateTime _dOrderDate;
        private int _nCustomerID;
        private double _OrderValue;
        private int _nStatus;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private string _sRemarks;
        private string _sCustomerName;



        // <summary>
        // Get set property for OrderID
        // </summary>
        public int OrderID
        {
            get { return _nOrderID; }
            set { _nOrderID = value; }
        }

        // <summary>
        // Get set property for OrderNumber
        // </summary>
        public string OrderNumber
        {
            get { return _sOrderNumber; }
            set { _sOrderNumber = value.Trim(); }
        }

        // <summary>
        // Get set property for OrderDate
        // </summary>
        public DateTime OrderDate
        {
            get { return _dOrderDate; }
            set { _dOrderDate = value; }
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
        // Get set property for OrderValue
        // </summary>
        public double OrderValue
        {
            get { return _OrderValue; }
            set { _OrderValue = value; }
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
        public DateTime UpdateDate
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
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }

        public void Add()
        {
            int nMaxOrderID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            //string sSql = "";
            try
            {
                string sSql = "";
                if (_nOrderID == 0)
                {
                    sSql = "SELECT MAX([OrderID]) FROM t_SalesOrderFactory";
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
                }

               _sOrderNumber = "OrderNo#-" + DateTime.Now.Year.ToString() + "-" + nMaxOrderID.ToString("001");
                sSql = "INSERT INTO t_SalesOrderFactory (OrderID, OrderNumber, OrderDate, CustomerID, OrderValue, Status, CreateUserID, CreateDate,Remarks) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("OrderNumber", _sOrderNumber);
                cmd.Parameters.AddWithValue("OrderDate", _dOrderDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("OrderValue", _OrderValue);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                //cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                //cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                foreach (SalesOrderFactoryDetail oSalesOrderFactoryDetail in this)
                {
                    oSalesOrderFactoryDetail.Add(_nOrderID);
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
                sSql = "UPDATE t_SalesOrderFactory SET OrderNumber = ?, OrderDate = ?, CustomerID = ?, OrderValue = ?, Status = ?, CreateUserID = ?, CreateDate = ?, UpdateUserID = ?, UpdateDate = ?, Remarks = ? WHERE OrderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderNumber", _sOrderNumber);
                cmd.Parameters.AddWithValue("OrderDate", _dOrderDate);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("OrderValue", _OrderValue);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("OrderID", _nOrderID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditByStatus(int nOrderID, int _nStatus)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesOrderFactory SET  Status = ?, UpdateUserID = ?, UpdateDate = ? WHERE OrderID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //SalesOrderFactoryDetail oUpdate = new SalesOrderFactoryDetail();
                //oUpdate.OrderID= nOrderID;
                //oUpdate.UpdateByDeliveryWise(nOrderID);
                
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
                sSql = "DELETE FROM t_SalesOrderFactory WHERE [OrderID]=?";
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
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesOrderFactory where OrderID =?";
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOrderID = (int)reader["OrderID"];
                    _sOrderNumber = (string)reader["OrderNumber"];
                    _dOrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    _nCustomerID = (int)reader["CustomerID"];
                    _OrderValue = Convert.ToDouble(reader["OrderValue"].ToString());
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
    }
    public class SalesOrderFactorys : CollectionBase
    {
        public SalesOrderFactory this[int i]
        {
            get { return (SalesOrderFactory)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SalesOrderFactory oSalesOrderFactory)
        {
            InnerList.Add(oSalesOrderFactory);
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
            string sSql = "SELECT * FROM t_SalesOrderFactory";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesOrderFactory oSalesOrderFactory = new SalesOrderFactory();
                    oSalesOrderFactory.OrderID = (int)reader["OrderID"];
                    oSalesOrderFactory.OrderNumber = (string)reader["OrderNumber"];
                    oSalesOrderFactory.OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    oSalesOrderFactory.CustomerID = (int)reader["CustomerID"];
                    oSalesOrderFactory.OrderValue = Convert.ToDouble(reader["OrderValue"].ToString());
                    oSalesOrderFactory.Status = (int)reader["Status"];
                    oSalesOrderFactory.CreateUserID = (int)reader["CreateUserID"];
                    oSalesOrderFactory.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSalesOrderFactory.UpdateUserID = (int)reader["UpdateUserID"];
                    oSalesOrderFactory.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oSalesOrderFactory.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oSalesOrderFactory);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshBySalesOrderFactory(DateTime dFromDate, DateTime dToDate, string sCustomer,int nStatus, bool IsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "Select OrderID,CustomerName,OrderNumber,OrderDate,a.CustomerID,OrderValue,Status,Remarks from t_SalesOrderFactory a, t_Customer b where a.CustomerID=b.CustomerID";

            if (IsCheck == false)
            {
                sSql = sSql + "  AND OrderDate between '" + dFromDate + "' and '" + dToDate + "' and OrderDate<'" + dToDate + "' ";
            }
            if (sCustomer != "")
            {
                sSql = sSql + " AND CustomerName like '%" + sCustomer + "%'";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND Status =" + nStatus + "";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesOrderFactory oSalesOrderFactory = new SalesOrderFactory();
                    oSalesOrderFactory.OrderID = (int)reader["OrderID"];
                    oSalesOrderFactory.OrderNumber = (string)reader["OrderNumber"];
                    oSalesOrderFactory.OrderDate = Convert.ToDateTime(reader["OrderDate"].ToString());
                    oSalesOrderFactory.CustomerID = (int)reader["CustomerID"];
                    oSalesOrderFactory.OrderValue = Convert.ToDouble(reader["OrderValue"].ToString());
                    oSalesOrderFactory.Status = (int)reader["Status"];
                    if (reader["Remarks"] != DBNull.Value)
                        oSalesOrderFactory.Remarks = (string)reader["Remarks"];
                    oSalesOrderFactory.CustomerName= (string)reader["CustomerName"];
                    InnerList.Add(oSalesOrderFactory);
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











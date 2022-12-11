// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Nov 15, 2018
// Time : 11:19 AM
// Description: Class for SalesOrderFactoryDelivery.
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
    public class SalesOrderFactoryDelivery
    {
        private int _nID;
        private int _nOrderID;
        private int _nProductID;
        private int _nDeliveryQty;
        private int _nOrderQty;
        private DateTime _dDeliverydate;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private string _sRemarks;
        private string _sProductCode;
        private string _sProductname;


        // <summary>
        // Get set property for OrderID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
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
        // Get set property for DeliveryQty
        // </summary>
        public int DeliveryQty
        {
            get { return _nDeliveryQty; }
            set { _nDeliveryQty = value; }
        }

        public int OrderQty
        {
            get { return _nOrderQty; }
            set { _nOrderQty = value; }
        }
        // <summary>
        // Get set property for Deliverydate
        // </summary>
        public DateTime Deliverydate
        {
            get { return _dDeliverydate; }
            set { _dDeliverydate = value; }
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
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }
        public string Productname
        {
            get { return _sProductname; }
            set { _sProductname = value.Trim(); }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_SalesOrderFactoryDelivery";
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
                sSql = "INSERT INTO t_SalesOrderFactoryDelivery (ID,OrderID, ProductID, DeliveryQty, Deliverydate, CreateUserID, CreateDate, Remarks) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("OrderID", _nOrderID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("DeliveryQty", _nDeliveryQty);
                cmd.Parameters.AddWithValue("Deliverydate", _dDeliverydate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

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
                sSql = "UPDATE t_SalesOrderFactoryDelivery SET OrderID = ?,ProductID = ?, DeliveryQty = ?, Deliverydate = ?, CreateUserID = ?, CreateDate = ?, Remarks = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OrderID)", _nOrderID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("DeliveryQty", _nDeliveryQty);
                cmd.Parameters.AddWithValue("Deliverydate", _dDeliverydate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

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
                sSql = "DELETE FROM t_SalesOrderFactoryDelivery WHERE [OrderID]=?";
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
                cmd.CommandText = "SELECT * FROM t_SalesOrderFactoryDelivery where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nOrderID = (int)reader["OrderID"];
                    _nProductID = (int)reader["ProductID"];
                    _nDeliveryQty = (int)reader["DeliveryQty"];
                    _dDeliverydate = Convert.ToDateTime(reader["Deliverydate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
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
    public class SalesOrderFactoryDeliverys : CollectionBase
    {
        public SalesOrderFactoryDelivery this[int i]
        {
            get { return (SalesOrderFactoryDelivery)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SalesOrderFactoryDelivery oSalesOrderFactoryDelivery)
        {
            InnerList.Add(oSalesOrderFactoryDelivery);
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
            string sSql = "SELECT * FROM t_SalesOrderFactoryDelivery";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesOrderFactoryDelivery oSalesOrderFactoryDelivery = new SalesOrderFactoryDelivery();
                    oSalesOrderFactoryDelivery.ID = (int)reader["ID"];
                    oSalesOrderFactoryDelivery.OrderID = (int)reader["OrderID"];
                    oSalesOrderFactoryDelivery.ProductID = (int)reader["ProductID"];
                    oSalesOrderFactoryDelivery.DeliveryQty = (int)reader["DeliveryQty"];
                    oSalesOrderFactoryDelivery.Deliverydate = Convert.ToDateTime(reader["Deliverydate"].ToString());
                    oSalesOrderFactoryDelivery.CreateUserID = (int)reader["CreateUserID"];
                    oSalesOrderFactoryDelivery.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSalesOrderFactoryDelivery.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oSalesOrderFactoryDelivery);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
       
        public void RefreshBySalesOrderDetails(int nOrderID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.ID,OrderID,a.ProductID,ProductCode,ProductName,OrderQty,DeliveryQty from t_SalesOrderFactoryDetail a,v_ProductDetails b where a.ProductID=b.ProductID and OrderID=" + nOrderID + " order by OrderID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesOrderFactoryDelivery oSalesOrderFactoryDelivery = new SalesOrderFactoryDelivery();

                    oSalesOrderFactoryDelivery.ID = (int)reader["ID"];
                    oSalesOrderFactoryDelivery.OrderID = (int)reader["OrderID"];
                    oSalesOrderFactoryDelivery.ProductID = (int)reader["ProductID"];
                    oSalesOrderFactoryDelivery.ProductCode = (string)reader["ProductCode"];
                    oSalesOrderFactoryDelivery.Productname = (string)reader["Productname"];
                    oSalesOrderFactoryDelivery.OrderQty = (int)reader["OrderQty"];
                    oSalesOrderFactoryDelivery.DeliveryQty = (int)reader["DeliveryQty"];
                    InnerList.Add(oSalesOrderFactoryDelivery);
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


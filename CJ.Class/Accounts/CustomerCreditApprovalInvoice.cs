// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD. Abdul Hakim
// Date: Nov 03, 2015
// Time : 04:17 PM
// Description: Class for CustomerCreditApprovalInvoice.
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
    public class CustomerCreditApprovalInvoice
    {
        private int _nCreditApprovalAdjustID;
        private int _nCreditApprovalID;
        private int _nWarehouseID;
        private int _nCustomerID;
        private string _sInvoiceNo;
        private DateTime _dInvoiceDate;
        private double _Amount;


        // <summary>
        // Get set property for CreditApprovalAdjustID
        // </summary>
        public int CreditApprovalAdjustID
        {
            get { return _nCreditApprovalAdjustID; }
            set { _nCreditApprovalAdjustID = value; }
        }

        // <summary>
        // Get set property for CreditApprovalID
        // </summary>
        public int CreditApprovalID
        {
            get { return _nCreditApprovalID; }
            set { _nCreditApprovalID = value; }
        }

        // <summary>
        // Get set property for WarehouseID
        // </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
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
        // Get set property for InvoiceNo
        // </summary>
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }

        // <summary>
        // Get set property for InvoiceDate
        // </summary>
        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }

        // <summary>
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        public void Add()
        {
            int nMaxCreditApprovalAdjustID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([CreditApprovalAdjustID]) FROM t_CustomerCreditApprovalInvoice";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxCreditApprovalAdjustID = 1;
                }
                else
                {
                    nMaxCreditApprovalAdjustID = Convert.ToInt32(maxID) + 1;
                }
                _nCreditApprovalAdjustID = nMaxCreditApprovalAdjustID;
                sSql = "INSERT INTO t_CustomerCreditApprovalInvoice (CreditApprovalAdjustID, CreditApprovalID, WarehouseID, CustomerID, InvoiceNo, InvoiceDate, Amount) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CreditApprovalAdjustID", _nCreditApprovalAdjustID);
                cmd.Parameters.AddWithValue("CreditApprovalID", _nCreditApprovalID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("Amount", _Amount);

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
                sSql = "UPDATE t_CustomerCreditApprovalInvoice SET CreditApprovalID = ?, WarehouseID = ?, CustomerID = ?, InvoiceNo = ?, InvoiceDate = ?, Amount = ? WHERE CreditApprovalAdjustID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CreditApprovalID", _nCreditApprovalID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("Amount", _Amount);

                cmd.Parameters.AddWithValue("CreditApprovalAdjustID", _nCreditApprovalAdjustID);

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
                sSql = "DELETE FROM t_CustomerCreditApprovalInvoice WHERE [CreditApprovalAdjustID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CreditApprovalAdjustID", _nCreditApprovalAdjustID);
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
                cmd.CommandText = "SELECT * FROM t_CustomerCreditApprovalInvoice where CreditApprovalAdjustID =?";
                cmd.Parameters.AddWithValue("CreditApprovalAdjustID", _nCreditApprovalAdjustID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCreditApprovalAdjustID = (int)reader["CreditApprovalAdjustID"];
                    _nCreditApprovalID = (int)reader["CreditApprovalID"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _sInvoiceNo = (string)reader["InvoiceNo"];
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
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
    public class CustomerCreditApprovalInvoices : CollectionBase
    {
        public CustomerCreditApprovalInvoice this[int i]
        {
            get { return (CustomerCreditApprovalInvoice)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CustomerCreditApprovalInvoice oCustomerCreditApprovalInvoice)
        {
            InnerList.Add(oCustomerCreditApprovalInvoice);
        }
        public int GetIndex(int nCreditApprovalAdjustID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].CreditApprovalAdjustID == nCreditApprovalAdjustID)
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
            string sSql = "SELECT * FROM t_CustomerCreditApprovalInvoice";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerCreditApprovalInvoice oCustomerCreditApprovalInvoice = new CustomerCreditApprovalInvoice();

                    oCustomerCreditApprovalInvoice.CreditApprovalAdjustID = (int)reader["CreditApprovalAdjustID"];
                    oCustomerCreditApprovalInvoice.CreditApprovalID = (int)reader["CreditApprovalID"];
                    oCustomerCreditApprovalInvoice.WarehouseID = (int)reader["WarehouseID"];
                    oCustomerCreditApprovalInvoice.CustomerID = (int)reader["CustomerID"];
                    oCustomerCreditApprovalInvoice.InvoiceNo = (string)reader["InvoiceNo"];
                    oCustomerCreditApprovalInvoice.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oCustomerCreditApprovalInvoice.Amount = Convert.ToDouble(reader["Amount"].ToString());

                    InnerList.Add(oCustomerCreditApprovalInvoice);
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


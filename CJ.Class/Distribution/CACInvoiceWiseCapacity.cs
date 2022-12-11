// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Jan 14, 2020
// Time : 01:58 PM
// Description: Class for CACInvoiceWiseCapacity.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Distribution
{
    public class CACInvoiceWiseCapacity
    {
        private int _nCapacityID;
        private int _nInvoiceID;
        private DateTime _dInvoiceDate;
        private int _nCreateUser;
        private DateTime _dCreateDate;
        private double _IndoorCapacity;
        private double _OutdoorCapacity;
        private string _sRemarks;
        private string _sInvoiceNo;
        private string _sCustomerName;
        private double _sInvoiceAmount;


        // <summary>
        // Get set property for CapacityID
        // </summary>
        public int CapacityID
        {
            get { return _nCapacityID; }
            set { _nCapacityID = value; }
        }

        // <summary>
        // Get set property for InvoiceID
        // </summary>
        public int InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
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
        // Get set property for CreateUser
        // </summary>
        public int CreateUser
        {
            get { return _nCreateUser; }
            set { _nCreateUser = value; }
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
        // Get set property for IndoorCapacity
        // </summary>
        public double IndoorCapacity
        {
            get { return _IndoorCapacity; }
            set { _IndoorCapacity = value; }
        }

        // <summary>
        // Get set property for OutdoorCapacity
        // </summary>
        public double OutdoorCapacity
        {
            get { return _OutdoorCapacity; }
            set { _OutdoorCapacity = value; }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        public double InvoiceAmount
        {
            get { return _sInvoiceAmount; }
            set { _sInvoiceAmount = value; }
        }

        public void Add()
        {
            int nMaxCapacityID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([CapacityID]) FROM t_CACInvoiceWiseCapacity";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxCapacityID = 1;
                }
                else
                {
                    nMaxCapacityID = Convert.ToInt32(maxID) + 1;
                }
                _nCapacityID = nMaxCapacityID;
                sSql = "INSERT INTO t_CACInvoiceWiseCapacity (CapacityID, InvoiceID, InvoiceDate, CreateUser, CreateDate, IndoorCapacity, OutdoorCapacity, Remarks) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CapacityID", _nCapacityID);
                cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("CreateUser", _nCreateUser);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("IndoorCapacity", _IndoorCapacity);
                cmd.Parameters.AddWithValue("OutdoorCapacity", _OutdoorCapacity);
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
                sSql = "UPDATE t_CACInvoiceWiseCapacity SET InvoiceID = ?, InvoiceDate = ?, CreateUser = ?, CreateDate = ?, IndoorCapacity = ?, OutdoorCapacity = ?, Remarks = ? WHERE CapacityID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);
                cmd.Parameters.AddWithValue("InvoiceDate", _dInvoiceDate);
                cmd.Parameters.AddWithValue("CreateUser", _nCreateUser);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("IndoorCapacity", _IndoorCapacity);
                cmd.Parameters.AddWithValue("OutdoorCapacity", _OutdoorCapacity);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("CapacityID", _nCapacityID);

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
                sSql = "DELETE FROM t_CACInvoiceWiseCapacity WHERE [CapacityID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CapacityID", _nCapacityID);
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
                cmd.CommandText = "SELECT * FROM t_CACInvoiceWiseCapacity where CapacityID =?";
                cmd.Parameters.AddWithValue("CapacityID", _nCapacityID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCapacityID = (int)reader["CapacityID"];
                    _nInvoiceID = (int)reader["InvoiceID"];
                    _dInvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    _nCreateUser = (int)reader["CreateUser"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _IndoorCapacity = Convert.ToDouble(reader["IndoorCapacity"].ToString());
                    _OutdoorCapacity = Convert.ToDouble(reader["OutdoorCapacity"].ToString());
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
    public class CACInvoiceWiseCapacitys : CollectionBase
    {
        public CACInvoiceWiseCapacity this[int i]
        {
            get { return (CACInvoiceWiseCapacity)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CACInvoiceWiseCapacity oCACInvoiceWiseCapacity)
        {
            InnerList.Add(oCACInvoiceWiseCapacity);
        }
        public int GetIndex(int nCapacityID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].CapacityID == nCapacityID)
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
            string sSql = "SELECT * FROM t_CACInvoiceWiseCapacity";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACInvoiceWiseCapacity oCACInvoiceWiseCapacity = new CACInvoiceWiseCapacity();
                    oCACInvoiceWiseCapacity.CapacityID = (int)reader["CapacityID"];
                    oCACInvoiceWiseCapacity.InvoiceID = (int)reader["InvoiceID"];
                    oCACInvoiceWiseCapacity.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oCACInvoiceWiseCapacity.CreateUser = (int)reader["CreateUser"];
                    oCACInvoiceWiseCapacity.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCACInvoiceWiseCapacity.IndoorCapacity = Convert.ToDouble(reader["IndoorCapacity"].ToString());
                    oCACInvoiceWiseCapacity.OutdoorCapacity = Convert.ToDouble(reader["OutdoorCapacity"].ToString());
                    oCACInvoiceWiseCapacity.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oCACInvoiceWiseCapacity);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByInvoiceCapacity(string sName, string sInvoiceNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from t_CACInvoiceWiseCapacity a, t_SalesInvoice b,t_Customer c where a.InvoiceID=b.InvoiceID and b.CustomerID=c.CustomerID and InvoiceNo like'%" + sInvoiceNo+ "%' and CustomerName like'%" + sName + "%'";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACInvoiceWiseCapacity oCACInvoiceWiseCapacity = new CACInvoiceWiseCapacity();
                    oCACInvoiceWiseCapacity.CapacityID = (int)reader["CapacityID"];
                    oCACInvoiceWiseCapacity.InvoiceID = (int)reader["InvoiceID"];
                    oCACInvoiceWiseCapacity.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());
                    oCACInvoiceWiseCapacity.CreateUser = (int)reader["CreateUser"];
                    oCACInvoiceWiseCapacity.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCACInvoiceWiseCapacity.IndoorCapacity = Convert.ToDouble(reader["IndoorCapacity"].ToString());
                    oCACInvoiceWiseCapacity.OutdoorCapacity = Convert.ToDouble(reader["OutdoorCapacity"].ToString());
                    oCACInvoiceWiseCapacity.Remarks = (string)reader["Remarks"];
                    oCACInvoiceWiseCapacity.InvoiceNo= (string)reader["InvoiceNo"];
                    oCACInvoiceWiseCapacity.CustomerName = (string)reader["CustomerName"];
                    oCACInvoiceWiseCapacity.InvoiceAmount = (double)reader["InvoiceAmount"];
                    InnerList.Add(oCACInvoiceWiseCapacity);
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



// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: May 27, 2019
// Time : 11:21 AM
// Description: Class for CACProjectOtherPayment.
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
    public class CACProjectOtherPayment
    {
        private int _nID;
        private int _nProjectID;
        private int _nSupplierID;
        private string _sSupplierName;
        private int _nInstrumentType;
        private DateTime _dCreateDate;
        private double _PaymentAmount;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for ProjectID
        // </summary>
        public int ProjectID
        {
            get { return _nProjectID; }
            set { _nProjectID = value; }
        }
        public int SupplierID
        {
            get { return _nSupplierID; }
            set { _nSupplierID = value; }
        }

        // <summary>
        // Get set property for SupplierName
        // </summary>
        public string SupplierName
        {
            get { return _sSupplierName; }
            set { _sSupplierName = value.Trim(); }
        }

        // <summary>
        // Get set property for InstrumentType
        // </summary>
        public int InstrumentType
        {
            get { return _nInstrumentType; }
            set { _nInstrumentType = value; }
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
        // Get set property for PaymentAmount
        // </summary>
        public double PaymentAmount
        {
            get { return _PaymentAmount; }
            set { _PaymentAmount = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CACProjectOtherPayment";
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
                sSql = "INSERT INTO t_CACProjectOtherPayment (ID, ProjectID, SupplierID, InstrumentType, CreateDate, PaymentAmount) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                cmd.Parameters.AddWithValue("InstrumentType", _nInstrumentType);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("PaymentAmount", _PaymentAmount);

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
                sSql = "UPDATE t_CACProjectOtherPayment SET ProjectID = ?, SupplierID = ?, InstrumentType = ?, CreateDate = ?, PaymentAmount = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("SupplierID", _nSupplierID);
                cmd.Parameters.AddWithValue("InstrumentType", _nInstrumentType);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("PaymentAmount", _PaymentAmount);

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
                sSql = "DELETE FROM t_CACProjectOtherPayment WHERE [ID]=?";
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
        public void DeleteByOtherPayment(int _nProjectID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_CACProjectOtherPayment WHERE ProjectID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
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
                cmd.CommandText = "SELECT * FROM t_CACProjectOtherPayment where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nProjectID = (int)reader["ProjectID"];
                    _sSupplierName = (string)reader["SupplierName"];
                    _nInstrumentType = (int)reader["InstrumentType"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _PaymentAmount = Convert.ToDouble(reader["PaymentAmount"].ToString());
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
    public class CACProjectOtherPayments : CollectionBase
    {
        public CACProjectOtherPayment this[int i]
        {
            get { return (CACProjectOtherPayment)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CACProjectOtherPayment oCACProjectOtherPayment)
        {
            InnerList.Add(oCACProjectOtherPayment);
        }
        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
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
            string sSql = "SELECT * FROM t_CACProjectOtherPayment";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACProjectOtherPayment oCACProjectOtherPayment = new CACProjectOtherPayment();
                    oCACProjectOtherPayment.ID = (int)reader["ID"];
                    oCACProjectOtherPayment.ProjectID = (int)reader["ProjectID"];
                    oCACProjectOtherPayment.SupplierName = (string)reader["SupplierName"];
                    oCACProjectOtherPayment.InstrumentType = (int)reader["InstrumentType"];
                    oCACProjectOtherPayment.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCACProjectOtherPayment.PaymentAmount = Convert.ToDouble(reader["PaymentAmount"].ToString());
                    InnerList.Add(oCACProjectOtherPayment);
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


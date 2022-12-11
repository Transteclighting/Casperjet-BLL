// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Jul 19, 2017
// Time : 01:10 PM
// Description: Class for CustomerBankGuaranty.
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
    public class CustomerBankGuaranty
    {
        private int _nBGID;
        private int _nCustomerID;
        private int _nBankID;
        private DateTime _dEffectiveDate;
        private DateTime _dExpiryDate;
        private double _BGAmount;
        private int _nIsActive;
        private string _sRemarks;
        private DateTime _dCreateDate;
        private int _nCreateuserID;
        private DateTime _dUpdateDate;
        private int _nUpdateUserID;

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

        private string _sBankName;
        public string BankName
        {
            get { return _sBankName; }
            set { _sBankName = value.Trim(); }
        }

        // <summary>
        // Get set property for BGID
        // </summary>
        public int BGID
        {
            get { return _nBGID; }
            set { _nBGID = value; }
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
        // Get set property for BankID
        // </summary>
        public int BankID
        {
            get { return _nBankID; }
            set { _nBankID = value; }
        }

        // <summary>
        // Get set property for EffectiveDate
        // </summary>
        public DateTime EffectiveDate
        {
            get { return _dEffectiveDate; }
            set { _dEffectiveDate = value; }
        }

        // <summary>
        // Get set property for ExpiryDate
        // </summary>
        public DateTime ExpiryDate
        {
            get { return _dExpiryDate; }
            set { _dExpiryDate = value; }
        }

        // <summary>
        // Get set property for BGAmount
        // </summary>
        public double BGAmount
        {
            get { return _BGAmount; }
            set { _BGAmount = value; }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
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
        // Get set property for CreateuserID
        // </summary>
        public int CreateuserID
        {
            get { return _nCreateuserID; }
            set { _nCreateuserID = value; }
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
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        public void Add()
        {
            int nMaxBGID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([BGID]) FROM t_CustomerBankGuaranty";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBGID = 1;
                }
                else
                {
                    nMaxBGID = Convert.ToInt32(maxID) + 1;
                }
                _nBGID = nMaxBGID;
                sSql = "INSERT INTO t_CustomerBankGuaranty (BGID, CustomerID, BankID, EffectiveDate, ExpiryDate, BGAmount, IsActive, Remarks, CreateDate, CreateuserID, UpdateDate, UpdateUserID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BGID", _nBGID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("ExpiryDate", _dExpiryDate);
                cmd.Parameters.AddWithValue("BGAmount", _BGAmount);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateuserID", _nCreateuserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);

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
                sSql = "UPDATE t_CustomerBankGuaranty SET CustomerID = ?, BankID = ?, EffectiveDate = ?, ExpiryDate = ?, BGAmount = ?, IsActive = ?, Remarks = ?, CreateDate = ?, CreateuserID = ?, UpdateDate = ?, UpdateUserID = ? WHERE BGID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("EffectiveDate", _dEffectiveDate);
                cmd.Parameters.AddWithValue("ExpiryDate", _dExpiryDate);
                cmd.Parameters.AddWithValue("BGAmount", _BGAmount);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateuserID", _nCreateuserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);

                cmd.Parameters.AddWithValue("BGID", _nBGID);

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
                sSql = "DELETE FROM t_CustomerBankGuaranty WHERE [BGID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BGID", _nBGID);
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
                cmd.CommandText = "SELECT * FROM t_CustomerBankGuaranty where BGID =?";
                cmd.Parameters.AddWithValue("BGID", _nBGID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nBGID = (int)reader["BGID"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _nBankID = (int)reader["BankID"];
                    _dEffectiveDate = Convert.ToDateTime(reader["EffectiveDate"].ToString());
                    _dExpiryDate = Convert.ToDateTime(reader["ExpiryDate"].ToString());
                    _BGAmount = Convert.ToDouble(reader["BGAmount"].ToString());
                    _nIsActive = (int)reader["IsActive"];
                    _sRemarks = (string)reader["Remarks"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateuserID = (int)reader["CreateuserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CustomerBankGuaranty SET IsActive = ?, Remarks = ?, UpdateDate = ?, UpdateUserID = ? WHERE BGID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);

                cmd.Parameters.AddWithValue("BGID", _nBGID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class CustomerBankGuarantys : CollectionBase
    {
        public CustomerBankGuaranty this[int i]
        {
            get { return (CustomerBankGuaranty)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CustomerBankGuaranty oCustomerBankGuaranty)
        {
            InnerList.Add(oCustomerBankGuaranty);
        }
        public int GetIndex(int nBGID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].BGID == nBGID)
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
            string sSql = "SELECT * FROM t_CustomerBankGuaranty";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerBankGuaranty oCustomerBankGuaranty = new CustomerBankGuaranty();
                    oCustomerBankGuaranty.BGID = (int)reader["BGID"];
                    oCustomerBankGuaranty.CustomerID = (int)reader["CustomerID"];
                    oCustomerBankGuaranty.BankID = (int)reader["BankID"];
                    oCustomerBankGuaranty.EffectiveDate = Convert.ToDateTime(reader["EffectiveDate"].ToString());
                    oCustomerBankGuaranty.ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"].ToString());
                    oCustomerBankGuaranty.BGAmount = Convert.ToDouble(reader["BGAmount"].ToString());
                    oCustomerBankGuaranty.IsActive = (int)reader["IsActive"];
                    oCustomerBankGuaranty.Remarks = (string)reader["Remarks"];
                    oCustomerBankGuaranty.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCustomerBankGuaranty.CreateuserID = (int)reader["CreateuserID"];
                    oCustomerBankGuaranty.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oCustomerBankGuaranty.UpdateUserID = (int)reader["UpdateUserID"];
                    InnerList.Add(oCustomerBankGuaranty);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshData(string sCustomerCode, int nBankID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            {
                sSql = "Select BGID,a.CustomerID,CustomerCode,CustomerName,a.BankID,Name as BankName, " +
                       "EffectiveDate,ExpiryDate,BGAmount,a.IsActive, " +
                       "isnull(a.Remarks,'') Remarks,CreateDate,CreateuserID  " +
                       "From dbo.t_CustomerBankGuaranty a,t_Customer b,t_Bank c " +
                       "where a.CustomerID=b.CustomerID and a.BankID=c.BankID";

            }
            if (sCustomerCode != "")
            {
                sSql = sSql + " AND CustomerCode like '%" + sCustomerCode + "%'";
            }
            if (nBankID != -1)
            {
                sSql = sSql + " AND a.BankID=" + nBankID + "";
            }
            sSql = sSql + " Order by a.CustomerID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerBankGuaranty oCustomerBankGuaranty = new CustomerBankGuaranty();
                    oCustomerBankGuaranty.BGID = (int)reader["BGID"];
                    oCustomerBankGuaranty.CustomerID = (int)reader["CustomerID"];
                    oCustomerBankGuaranty.CustomerCode = (string)reader["CustomerCode"];
                    oCustomerBankGuaranty.CustomerName = (string)reader["CustomerName"];
                    oCustomerBankGuaranty.BankID = (int)reader["BankID"];
                    oCustomerBankGuaranty.BankName = (string)reader["BankName"];
                    oCustomerBankGuaranty.EffectiveDate = Convert.ToDateTime(reader["EffectiveDate"].ToString());
                    oCustomerBankGuaranty.ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"].ToString());
                    oCustomerBankGuaranty.BGAmount = Convert.ToDouble(reader["BGAmount"].ToString());
                    oCustomerBankGuaranty.IsActive = (int)reader["IsActive"];
                    oCustomerBankGuaranty.Remarks = (string)reader["Remarks"];
                    oCustomerBankGuaranty.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCustomerBankGuaranty.CreateuserID = (int)reader["CreateuserID"];

                    InnerList.Add(oCustomerBankGuaranty);
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


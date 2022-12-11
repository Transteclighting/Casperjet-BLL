// <summary>
// Company: Bangladesh Lamps Limited
// Author: MD. Humayun Rashid
// Date: Jul 12, 2018
// Time : 04:25 PM
// Description: Class for CustomerBankGuarantee.
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
    public class CustomerBankGuarantee
    {
        private int _nTRanID;
        private int _nCustomerID;
        private double _BGAmount;
        private DateTime _dOpeningDate;
        private DateTime _dExpiryDate;
        private int _nIsActive;
        private string nCustomerCode;
        private string sCustomerName;
        private string sRegionName;
        private string sAreaName;
        private string sTerritoryName;



        // <summary>
        // Get set property for TRanID
        // </summary>
        public int TRanID
        {
            get { return _nTRanID; }
            set { _nTRanID = value; }
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
        // Get set property for BGAmount
        // </summary>
        public double BGAmount
        {
            get { return _BGAmount; }
            set { _BGAmount = value; }
        }

        // <summary>
        // Get set property for OpeningDate
        // </summary>
        public DateTime OpeningDate
        {
            get { return _dOpeningDate; }
            set { _dOpeningDate = value; }
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
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        public string CustomerCode
        {
            get { return nCustomerCode; }
            set { nCustomerCode = value; }
        }
        public string CustomerName
        {
            get { return sCustomerName; }
            set { sCustomerName = value; }
        }
        public string RegionName
        {
            get { return sRegionName; }
            set { sRegionName = value; }
        }
        public string AreaName
        {
            get { return sAreaName; }
            set { sAreaName = value; }
        }
        public string TerritoryName
        {
            get { return sTerritoryName; }
            set { sTerritoryName = value; }
        }
        public void Add()
        {
            int nMaxTRanID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TRanID]) FROM t_CustomerBankGuarantee";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxTRanID = 1;
                }
                else
                {
                    nMaxTRanID = Convert.ToInt32(maxID) + 1;
                }
                _nTRanID = nMaxTRanID;
                sSql = "INSERT INTO t_CustomerBankGuarantee (TRanID, CustomerID, BGAmount, OpeningDate, ExpiryDate, IsActive) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TRanID", _nTRanID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("BGAmount", _BGAmount);
                cmd.Parameters.AddWithValue("OpeningDate", _dOpeningDate);
                cmd.Parameters.AddWithValue("ExpiryDate", _dExpiryDate);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

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
                sSql = "UPDATE t_CustomerBankGuarantee SET CustomerID = ?, BGAmount = ?, OpeningDate = ?, ExpiryDate = ?, IsActive = ? WHERE TRanID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("BGAmount", _BGAmount);
                cmd.Parameters.AddWithValue("OpeningDate", _dOpeningDate);
                cmd.Parameters.AddWithValue("ExpiryDate", _dExpiryDate);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.Parameters.AddWithValue("TRanID", _nTRanID);

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
                sSql = "DELETE FROM t_CustomerBankGuarantee WHERE [TRanID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TRanID", _nTRanID);
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
                cmd.CommandText = "SELECT * FROM t_CustomerBankGuarantee where TRanID =?";
                cmd.Parameters.AddWithValue("TRanID", _nTRanID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTRanID = (int)reader["TRanID"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _BGAmount = Convert.ToDouble(reader["BGAmount"].ToString());
                    _dOpeningDate = Convert.ToDateTime(reader["OpeningDate"].ToString());
                    _dExpiryDate = Convert.ToDateTime(reader["ExpiryDate"].ToString());
                    _nIsActive = (int)reader["IsActive"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateStatus(int _nTRanID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CustomerBankGuarantee SET IsActive = ?,  OpeningDate = ?, ExpiryDate = ?, BGAmount=? WHERE TranID = ? and CustomerID= ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("OpeningDate", _dOpeningDate);
                cmd.Parameters.AddWithValue("ExpiryDate", _dExpiryDate);
                cmd.Parameters.AddWithValue("BGAmount", _BGAmount);
                cmd.Parameters.AddWithValue("TranID", _nTRanID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class CustomerBankGuarantees : CollectionBase
    {
        public CustomerBankGuarantee this[int i]
        {
            get { return (CustomerBankGuarantee)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CustomerBankGuarantee oCustomerBankGuarantee)
        {
            InnerList.Add(oCustomerBankGuarantee);
        }
        public int GetIndex(int nTRanID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].TRanID == nTRanID)
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
            string sSql = "SELECT * FROM t_CustomerBankGuarantee";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerBankGuarantee oCustomerBankGuarantee = new CustomerBankGuarantee();
                    oCustomerBankGuarantee.TRanID = (int)reader["TRanID"];
                    oCustomerBankGuarantee.CustomerID = (int)reader["CustomerID"];
                    oCustomerBankGuarantee.BGAmount = Convert.ToDouble(reader["BGAmount"].ToString());
                    oCustomerBankGuarantee.OpeningDate = Convert.ToDateTime(reader["OpeningDate"].ToString());
                    oCustomerBankGuarantee.ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"].ToString());
                    oCustomerBankGuarantee.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oCustomerBankGuarantee);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshData(string sCustomerCode)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            {

                sSql = " Select TranID,a.CustomerID,RegionName, AreaName, TerritoryName,CustomerCode, CustomerName, OpeningDate, ExpiryDate, a.IsActive, BGAmount " +
                      " from[t_CustomerBankGuarantee] a, v_CustomerDetails b " +
                      " where a.CustomerID = b.CustomerID ";

            }
            if (sCustomerCode != "")
            {
                sSql = sSql + " AND CustomerCode like '%" + sCustomerCode + "%'";
            }
            sSql = sSql + " Order by  RegionName, AreaName, TerritoryName,CustomerCode";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerBankGuarantee oCustomerBankGuarantee = new CustomerBankGuarantee();
                    oCustomerBankGuarantee.TRanID = (int)reader["TranID"];
                    oCustomerBankGuarantee.CustomerID = (int)reader["CustomerID"];
                    oCustomerBankGuarantee.RegionName = (string)reader["RegionName"];
                    oCustomerBankGuarantee.AreaName = (string)reader["AreaName"];
                    oCustomerBankGuarantee.TerritoryName = (string)reader["TerritoryName"];
                    oCustomerBankGuarantee.CustomerCode = (string)reader["CustomerCode"];
                    oCustomerBankGuarantee.CustomerName = (string)reader["CustomerName"];
                    oCustomerBankGuarantee.OpeningDate = Convert.ToDateTime(reader["OpeningDate"].ToString());
                    oCustomerBankGuarantee.ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"].ToString());
                    oCustomerBankGuarantee.IsActive = (int)reader["IsActive"];
                    oCustomerBankGuarantee.BGAmount = Convert.ToDouble(reader["BGAmount"].ToString());

                    InnerList.Add(oCustomerBankGuarantee);
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


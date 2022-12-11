// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: July, 2011
// Time :  11:30 AM
// Description: Class for Customer Type.
// Modify Person And Date:Uttam Kar 13-May-2014
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using System.Data;
using System.Data.OleDb;

namespace CJ.Class
{

    public  class CustomerType
    {
        private int _CustTypeID;
        private string _CustTypeCode;
        private string _CustTypeDescription;
        private int _ChannelID;
        private int _IsActive;
        private int _Pos;
        private int _ReportingChannelID;
        private Channel _oChannel;

        /// <summary>
        /// Get set property for CustTypeID
        /// </summary>
        public int CustTypeID
        {
            get { return _CustTypeID; }
            set { _CustTypeID = value; }
        }

        /// <summary>
        /// Get set property for CustTypeCode
        /// </summary>
        public string CustTypeCode
        {
            get { return _CustTypeCode; }
            set { _CustTypeCode = value.Trim(); }
        }

        /// <summary>
        /// Get set property for CustTypeDescription
        /// </summary>
        public string CustTypeDescription
        {
            get { return _CustTypeDescription; }
            set { _CustTypeDescription = value.Trim(); }
        }

        /// <summary>
        /// Get set property for ChannelID
        /// </summary>
        public int ChannelID
        {
            get { return _ChannelID; }
            set { _ChannelID = value; }
        }

        /// <summary>
        /// Get set property for IsActive
        /// </summary>
        public int IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        /// <summary>
        /// Get set property for Pos
        /// </summary>
        public int Pos
        {
            get { return _Pos; }
            set { _Pos = value; }
        }

        /// <summary>
        /// Get set property for ReportingChannelID
        /// </summary>
        public int ReportingChannelID
        {
            get { return _ReportingChannelID; }
            set { _ReportingChannelID = value; }
        }
        private string _sChannelDescription;
        public string ChannelDescription
        {
            get { return _sChannelDescription; }
            set { _sChannelDescription = value; }
        }
        /*******Uttam Kar**********/
        public Channel ChnnelDesc
        {
            get
            {
                if (_oChannel == null)
                {
                    _oChannel = new Channel();
                    _oChannel.ChannelID = _ChannelID;
                    _oChannel.Refresh();
                }
                return _oChannel;
            }
        }

        /*******Uttam Kar**********/
        public void Add()
        {
            int nMaxCustTypeID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([CustTypeID]) FROM t_CustomerType";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxCustTypeID = 1;
                }
                else
                {
                    nMaxCustTypeID = Convert.ToInt32(maxID) + 1;
                }
                _CustTypeID = nMaxCustTypeID;

                sSql = "INSERT INTO t_CustomerType(CustTypeID,CustTypeCode,CustTypeDescription,ChannelID,IsActive,Pos,ReportingChannelID) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CustTypeID", _CustTypeID);
                cmd.Parameters.AddWithValue("CustTypeCode", _CustTypeCode);
                cmd.Parameters.AddWithValue("CustTypeDescription", _CustTypeDescription);
                cmd.Parameters.AddWithValue("ChannelID", _ChannelID);
                cmd.Parameters.AddWithValue("IsActive", _IsActive);

                cmd.Parameters.AddWithValue("Pos", _Pos);

                if (_ReportingChannelID != null)
                {
                    cmd.Parameters.AddWithValue("ReportingChannelID", _ReportingChannelID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ReportingChannelID", null);
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /******Uttam Kar***********/
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "UPDATE t_CustomerType SET CustTypeCode=?, CustTypeDescription=?, ChannelID=?,IsActive=?,Pos=?,ReportingChannelID=?"
                    + " WHERE CustTypeID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CustTypeCode", _CustTypeCode);
                cmd.Parameters.AddWithValue("CustTypeDescription", _CustTypeDescription);
                cmd.Parameters.AddWithValue("ChannelID", _ChannelID);
                cmd.Parameters.AddWithValue("IsActive", _IsActive);
                cmd.Parameters.AddWithValue("Pos", _Pos);
                if (_ReportingChannelID != null)
                {
                    cmd.Parameters.AddWithValue("ReportingChannelID", _ReportingChannelID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("ReportingChannelID", null);
                }
                cmd.Parameters.AddWithValue("CustTypeID", _CustTypeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /******Uttam Kar***********/
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_CustomerType WHERE [CustTypeID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CustTypeID", _CustTypeID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        /******Uttam Kar***********/
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CustomerType where CustTypeID =?";
                cmd.Parameters.AddWithValue("CustTypeID", _CustTypeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _CustTypeID = (int)reader["CustTypeID"];
                    _CustTypeCode = (string)reader["CustTypeCode"];
                    _CustTypeDescription = (string)reader["CustTypeDescription"];
                    _ChannelID = (int)reader["ChannelID"];
                    _IsActive = (int)reader["IsActive"];
                    _Pos = (int)reader["Pos"];
                    _ReportingChannelID = (int)reader["ReportingChannelID"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshCustTypeDescription( string _sCustTypeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
           
            try
            {
                cmd.CommandText = "Select string_AGG( CustTypeDescription+' ['+ChannelDescription+']',',') as CustTypeDescription from t_CustomerType a,t_Channel b where a.ChannelID = b.ChannelID  and CustTypeID in(" + _sCustTypeID + ")";
             
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _CustTypeDescription = (string)reader["CustTypeDescription"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }

    public class CustomerTypies : CollectionBase
    {
        public CustomerType this[int i]
        {
            get { return (CustomerType)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CustomerType oCustomerType)
        {
            InnerList.Add(oCustomerType);
        }
        /******Uttam Kar***********/
        public int GetIndex(int nCustTypeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].CustTypeID == nCustTypeID)
                {
                    return i;
                }
            }
            return -1;
        }
        /******Uttam Kar***********/
        public void Refresh()
        {
            CustomerType oCustomerType;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM t_CustomerType ";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oCustomerType = new CustomerType();
                    oCustomerType.CustTypeID = int.Parse(reader["CustTypeID"].ToString());
                    oCustomerType.CustTypeCode = reader["CustTypeCode"].ToString();
                    oCustomerType.CustTypeDescription = reader["CustTypeDescription"].ToString();
                    oCustomerType.ChannelID = int.Parse(reader["ChannelID"].ToString());
                    oCustomerType.IsActive = int.Parse(reader["IsActive"].ToString());
                    oCustomerType.Pos = int.Parse(reader["Pos"].ToString());

                    if (reader["ReportingChannelID"] != DBNull.Value)
                    {
                        oCustomerType.ReportingChannelID = int.Parse(reader["ReportingChannelID"].ToString());
                    }
                    else
                    {
                        oCustomerType.ReportingChannelID = 0;
                    }

                    InnerList.Add(oCustomerType);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void GetCustTypeChannelWise(int nChannelID)
        {
            CustomerType oCustomerType;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM t_CustomerType where ChannelID=" + nChannelID + "";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oCustomerType = new CustomerType();
                    oCustomerType.CustTypeID = int.Parse(reader["CustTypeID"].ToString());
                    oCustomerType.CustTypeCode = reader["CustTypeCode"].ToString();
                    oCustomerType.CustTypeDescription = reader["CustTypeDescription"].ToString();
                    oCustomerType.ChannelID = int.Parse(reader["ChannelID"].ToString());
                    oCustomerType.IsActive = int.Parse(reader["IsActive"].ToString());
                    oCustomerType.Pos = int.Parse(reader["Pos"].ToString());

                    if (reader["ReportingChannelID"] != DBNull.Value)
                    {
                        oCustomerType.ReportingChannelID = int.Parse(reader["ReportingChannelID"].ToString());
                    }
                    else
                    {
                        oCustomerType.ReportingChannelID = 0;
                    }

                    InnerList.Add(oCustomerType);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetCustomerType()
        {
            CustomerType oCustomerType;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_CustomerType";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    oCustomerType = new CustomerType();
                    oCustomerType.CustTypeID = int.Parse(reader["CustTypeID"].ToString());
                    oCustomerType.CustTypeDescription = reader["CustTypeDescription"].ToString();
                    InnerList.Add(oCustomerType);
                }

                reader.Close();

                oCustomerType = new CustomerType();
                oCustomerType.CustTypeID = -1;
                oCustomerType.CustTypeDescription = "ALL";
                InnerList.Add(oCustomerType);
                InnerList.TrimToSize();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetCustTypeChannel()
        {
            CustomerType oCustomerType;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select CustTypeID, CustTypeCode, CustTypeDescription, " +
                          " ChannelDescription from t_CustomerType a, t_Channel b Where a.ChannelID=b.ChannelID  " +
                          " order by ChannelDescription, CustTypeDescription ";

            try
            {
               cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oCustomerType = new CustomerType();

                    oCustomerType.CustTypeID = int.Parse(reader["CustTypeID"].ToString());
                    oCustomerType.CustTypeCode = reader["CustTypeCode"].ToString();
                    oCustomerType.CustTypeDescription = reader["CustTypeDescription"].ToString();
                    oCustomerType.ChannelDescription = reader["ChannelDescription"].ToString();

                    InnerList.Add(oCustomerType);
                }
                reader.Close();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public string GetCustTypeSalesTypeWise(int nSalesType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From t_CustomerType where SalesType=" + nSalesType + " and IsActive=1";
            string sCustomerType = "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (sCustomerType == "")
                    {
                        sCustomerType = Convert.ToString(reader["CustTypeID"].ToString());
                    }
                    else
                    {
                        sCustomerType = sCustomerType + ',' + int.Parse(reader["CustTypeID"].ToString());
                    }
                }
                reader.Close();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            return sCustomerType;
        }

    }
}

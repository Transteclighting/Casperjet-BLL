// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Oct 06, 2012
// Time :  60:00 PM
// Description: Class for ERP Customer Mapping.
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
    public class CustomerMapping
    {


        private string _sCustomerERPCode;
        private string _sCustomerCode;
        
       
        /// <summary>
        /// Get set property for CustomerERPCode
        /// </summary>
        public string CustomerERPCode
        {
            get { return _sCustomerERPCode; }
            set { _sCustomerERPCode = value; }
        }
        /// <summary>
        /// Get set property for CustomerCode
        /// </summary>
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }
        private string _sCustomerName;
        /// <summary>
        /// Get set property for CustomerName
        /// </summary>
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
   
        public void Add()
        {
            
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_MapERPCustomer(CustomerERPCode,CustomerCode) VALUES(?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CustomerERPCode", _sCustomerERPCode);
                cmd.Parameters.AddWithValue("CustomerCode", _sCustomerCode);

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
                ProductMapping _oProductMapping;

                cmd.CommandText = "UPDATE t_MapERPCustomer SET CustomerERPCode=?,CustomerCode=? Where CustomerERPCode=? "; 

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("CustomerERPCode", _sCustomerERPCode);
                cmd.Parameters.AddWithValue("CustomerCode", _sCustomerCode);

                cmd.Parameters.AddWithValue("CustomerCode", _sCustomerCode);

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
                sSql = "DELETE FROM t_MapERPCustomer WHERE [CustomerERPCode]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CustomerERPCode", _sCustomerERPCode);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        public bool CheckCustomerERPCode()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_MapERPCustomer where CustomerERPCode=? ";
            cmd.Parameters.AddWithValue("CustomerERPCode", _sCustomerERPCode);

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
        public bool CheckCustomerCode()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_MapERPCustomer where CustomerCode=? ";
            cmd.Parameters.AddWithValue("CustomerCode", _sCustomerCode);

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
    public class CustomerMappings : CollectionBase
    {
        public CustomerMapping this[int i]
        {
            get { return (CustomerMapping)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(CustomerMapping oCustomerMapping)
        {
            InnerList.Add(oCustomerMapping);
        }
        public void Refresh(string txtERPCode, String txtCustomerCode, String txtCustomerName)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select M.*,CD.CustomerName from t_MapERPCustomer M "+
                            "INNER JOIN v_CustomerDetails CD "+
                            "ON CD.CustomerCode= M.CustomerCode "+
                            "Where CustomerERPCode <>'xyz'";

            if (txtERPCode != "")
            {
                txtERPCode = "%" + txtERPCode + "%";
                sSql = sSql + " AND CustomerERPCode LIKE '" + txtERPCode + "'";
            }
            if (txtCustomerCode != "")
            {
                txtCustomerCode = "%" + txtCustomerCode + "%";
                sSql = sSql + " AND CD.CustomerCode LIKE '" + txtCustomerCode + "'";
            }
            if (txtCustomerName != "")
            {
                txtCustomerName = "%" + txtCustomerName + "%";
                sSql = sSql + " AND CD.CustomerName LIKE '" + txtCustomerName + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CustomerMapping oCustomerMapping = new CustomerMapping();

                    oCustomerMapping.CustomerERPCode = (string)reader["CustomerERPCode"];
                    oCustomerMapping.CustomerCode = (string)reader["CustomerCode"];
                    oCustomerMapping.CustomerName = (string)reader["CustomerName"];

                    InnerList.Add(oCustomerMapping);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshNonMapping(DateTime dtFromDate, String txtCustomerCodeU, String txtCustomerNameU)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select CD.CustomerCode, CustomerName, CD.EntryDate, M.CustomerCode From v_CustomerDetails CD " +
                            "Left Outer JOIN t_MapERPCustomer M " +
                            "ON CD.CustomerCode= M.CustomerCode " +
                            "Where M.CustomerCode Is Null AND CD.EntryDate >= '" + dtFromDate + "'";


            if (txtCustomerCodeU != "")
            {
                txtCustomerCodeU = "%" + txtCustomerCodeU + "%";
                sSql = sSql + " AND CD.CustomerCode LIKE '" + txtCustomerCodeU + "'";
            }
            if (txtCustomerNameU != "")
            {
                txtCustomerNameU = "%" + txtCustomerNameU + "%";
                sSql = sSql + " AND CustomerName LIKE '" + txtCustomerNameU + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerMapping oCustomerMapping = new CustomerMapping();

                    oCustomerMapping.CustomerCode = (string)reader["CustomerCode"];
                    oCustomerMapping.CustomerName = (string)reader["CustomerName"];

                    InnerList.Add(oCustomerMapping);
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






// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Jun 11, 2013
// Time :  10:00 AM
// Description: Class for Sundry Customer.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class.CSD;

namespace CJ.Class
{
    public class SundryCustomer
    {

        private int _nSundryCustomerID;
        private string _sSundryCustomerName;
        private string _sAddress;
        private string _sPhoneNo;
        private string _sCellNo;
        private string _sEmail;
        private int _nSundryCustomerType;
        private int _nCustomerID;
             

        /// <summary>
        /// Get set property for SundryCustomerID
        /// </summary>
        public int SundryCustomerID
        {
            get { return _nSundryCustomerID; }
            set { _nSundryCustomerID = value; }
        }
        /// <summary>
        /// Get set property for SundryCustomerName
        /// </summary>
        public string SundryCustomerName
        {
            get { return _sSundryCustomerName; }
            set { _sSundryCustomerName = value; }
        }
        /// <summary>
        /// Get set property for Address
        /// </summary>
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }
        /// <summary>
        /// Get set property for PhoneNo
        /// </summary>
        public string PhoneNo
        {
            get { return _sPhoneNo; }
            set { _sPhoneNo = value; }
        }
        /// <summary>
        /// Get set property for CellNo
        /// </summary>
        public string CellNo
        {
            get { return _sCellNo; }
            set { _sCellNo = value; }
        }
        /// <summary>
        /// Get set property for Email
        /// </summary>
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value; }
        }
        /// <summary>
        /// Get set property for SundryCustomerType
        /// </summary>
        public int SundryCustomerType
        {
            get { return _nSundryCustomerType; }
            set { _nSundryCustomerType = value; }
        }
        /// <summary>
        /// Get set property for CustomerID
        /// </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
       
 
        public void Add()
        {
            int nMaxSundryCustID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SundryCustomerID]) FROM t_SundryCustomer";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSundryCustID = 1;
                }
                else
                {
                    nMaxSundryCustID = Convert.ToInt32(maxID) + 1;
                }
                _nSundryCustomerID = nMaxSundryCustID;


                sSql = "INSERT INTO t_SundryCustomer(SundryCustomerID,SundryCustomerName, Address, PhoneNo,CellNo,"
                    + " Email,SundryCustomerType,CustomerID) VALUES(?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SundryCustomerID", _nSundryCustomerID);
                cmd.Parameters.AddWithValue("SundryCustomerName", _sSundryCustomerName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("PhoneNo", _sPhoneNo);
                cmd.Parameters.AddWithValue("CellNo", _sCellNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("SundryCustomerType", _nSundryCustomerType);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);

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

            try
            {

                cmd.CommandText = "UPDATE t_SundryCustomer SET SundryCustomerName=?, Address=?, PhoneNo=?,CellNo=?,"
                    + " Email=?,SundryCustomerType=?,CustomerID=?  where SundryCustomerID=? ";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SundryCustomerName", _sSundryCustomerName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("PhoneNo", _sPhoneNo);
                cmd.Parameters.AddWithValue("CellNo", _sCellNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("SundryCustomerType", _nSundryCustomerType);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);

                cmd.Parameters.AddWithValue("SundryCustomerID", _nSundryCustomerID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
       
        public void Delete(int nOrderID, int nSundryCustID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                Complain oItem = new Complain();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "DELETE FROM t_EcommerceOrder WHERE [OrderID]=? AND [SundryCustID]=?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OrderID", nOrderID);
                cmd.Parameters.AddWithValue("SundryCustID", nSundryCustID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd.CommandText = "DELETE FROM t_SundryCustomer WHERE [SundryCustomerID]=?";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SundryCustomerID", nSundryCustID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }

    public class SundryCustomers : CollectionBase
    {
        public SundryCustomer this[int i]
        {
            get { return (SundryCustomer)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SundryCustomer oSundryCustomer)
        {
            InnerList.Add(oSundryCustomer);
        }
      
    }

}
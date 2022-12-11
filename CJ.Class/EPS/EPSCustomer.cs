// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Dec 04, 2012
// Time :  06:20 PM
// Description: Class for EPS Customer.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class.Web.UI.Class;

namespace CJ.Class
{
    public class EPSCustomer
    {
        private int _nEPSCustomerID;
        private string _sEPSCustomerCode;
        private int _nCustomerID;
        private string _sEmployeeCode;
        private string _sEmployeeName;
        private string _sEmployeeAddress;
        private string _sDesignation;
        private string _sPhoneNo;
        private string _sEmail;
        private int _nEmployeeStatus;

        /// <summary>
        /// Get set property for EPSCustomerID
        /// </summary>
        public int EPSCustomerID
        {
            get { return _nEPSCustomerID; }
            set { _nEPSCustomerID = value; }
        }
        /// <summary>
        /// Get set property for EPSCustomerCode
        /// </summary>
        public string EPSCustomerCode
        {
            get { return _sEPSCustomerCode; }
            set { _sEPSCustomerCode = value.Trim(); }
        }
        /// <summary>
        /// Get set property for CustomerID
        /// </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        /// <summary>
        /// Get set property for EmployeeCode
        /// </summary>
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }
        /// <summary>
        /// Get set property for EmployeeName
        /// </summary>
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for EmployeeAddress
        /// </summary>
        public string EmployeeAddress
        {
            get { return _sEmployeeAddress; }
            set { _sEmployeeAddress = value.Trim(); }
        }
        /// <summary>
        /// Get set property for PhoneNo
        /// </summary>
        public string PhoneNo
        {
            get { return _sPhoneNo; }
            set { _sPhoneNo = value.Trim(); }
        }
        /// <summary>
        /// Get set property for Email
        /// </summary>
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value.Trim(); }
        }
        /// <summary>
        /// Get set property for Designation
        /// </summary>
        public string Designation
        {
            get { return _sDesignation; }
            set { _sDesignation = value.Trim(); }
        }
        /// <summary>
        /// Get set property for EmployeeStatus
        /// </summary>
        public int EmployeeStatus
        {
            get { return _nEmployeeStatus; }
            set { _nEmployeeStatus = value; }
        }

        public Customer _oCustomer;
        public Customer Customer
        {
            get
            {
                if (_oCustomer == null)
                {
                    _oCustomer = new Customer();
                    _oCustomer.CustomerID = _nCustomerID;
                    _oCustomer.refresh();
                }

                return _oCustomer;
            }
        }

        public void InsertCustomer(bool IsNew)
        {
            int nMaxEPSCustomerID = 0;
            int nNextCode = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([EPSCustomerID]) FROM t_EPSCustomer";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxEPSCustomerID = 1;
                }
                else
                {
                    nMaxEPSCustomerID = int.Parse(maxID.ToString()) + 1;

                }
                _nEPSCustomerID = nMaxEPSCustomerID;

                if (IsNew)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    sSql = "SELECT [NEXT_ID] FROM T_Next_ID where OID= 5 ";
                    cmd.CommandText = sSql;
                    object NextCode = cmd.ExecuteScalar();
                    if (NextCode == DBNull.Value)
                    {
                        nNextCode = 1;
                    }
                    else
                    {
                        nNextCode = int.Parse(NextCode.ToString());

                    }
                    _sEPSCustomerCode = nNextCode.ToString();
                }
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_EPSCustomer VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EPSCustomerID", _nEPSCustomerID);
                cmd.Parameters.AddWithValue("EPSCustomerCode", _sEPSCustomerCode);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("EmployeeName", _sEmployeeName);
                cmd.Parameters.AddWithValue("EmployeeAddress", _sEmployeeAddress);
                cmd.Parameters.AddWithValue("PhoneNo", _sPhoneNo);
                cmd.Parameters.AddWithValue("Designation", _sDesignation);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("EmployeeStatus", (int)Dictionary.EPSEmployeeStatus.Regular);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (IsNew)
                {
                    nNextCode = nNextCode + 1;
                    cmd = DBController.Instance.GetCommand();
                    cmd.CommandText = "Update T_Next_ID set NEXT_ID = '" + nNextCode + "'  where OID = 5 ";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateCustomer()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.CommandText = "UPDATE t_EPSCustomer SET CustomerID=?,EmployeeCode=?,EmployeeName=?,EmployeeAddress=?,Designation=?,PhoneNo=?,Email=?,EmployeeStatus=? WHERE EPSCustomerID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("EmployeeName", _sEmployeeName);
                cmd.Parameters.AddWithValue("EmployeeAddress", _sEmployeeAddress);
                cmd.Parameters.AddWithValue("Designation", _sDesignation);
                cmd.Parameters.AddWithValue("PhoneNo", _sPhoneNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("EmployeeStatus", _nEmployeeStatus);

                cmd.Parameters.AddWithValue("EPSCustomerID", _nEPSCustomerID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool RefreshEmployee()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_epscustomer where EmployeeCode =? and customerid=?";
            cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
            cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sEmployeeCode = (reader["EmployeeCode"].ToString());
                    _sEmployeeName = (reader["EmployeeName"].ToString());
                    _sDesignation = (reader["Designation"].ToString());
                    _sEmployeeAddress = (reader["EmployeeAddress"].ToString());
                    _sEmail = (reader["Email"].ToString());
                    _sPhoneNo = (reader["PhoneNo"].ToString());
                    _sEPSCustomerCode = (reader["EPSCustomerCode"].ToString());

                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) return true;
            else return false;

        }

        public bool RefreshByEPSCustomer()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_EPSCustomer where EPSCustomerID =? ";
            cmd.Parameters.AddWithValue("EmployeeCode", _nEPSCustomerID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sEmployeeCode = (reader["EmployeeCode"].ToString());
                    _sEmployeeName = (reader["EmployeeName"].ToString());
                    _sDesignation = (reader["Designation"].ToString());
                    _nCustomerID = (int)(reader["CustomerID"]);
                    _sEPSCustomerCode = (reader["EPSCustomerCode"].ToString());
                    _sEmployeeAddress = (reader["EmployeeAddress"].ToString());
                    _sEmail = (reader["Email"].ToString());
                    _sPhoneNo = (reader["PhoneNo"].ToString());
                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) return true;
            else return false;
        }
        public bool RefreshByEPSCustomerCode()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select * from t_EPSCustomer where EPSCustomerCode =? ";
            cmd.Parameters.AddWithValue("EPSCustomerCode", _sEPSCustomerCode);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _nEPSCustomerID = (int)(reader["EPSCustomerID"]);
                    _sEmployeeCode = (reader["EmployeeCode"].ToString());
                    _sEmployeeName = (reader["EmployeeName"].ToString());
                    _sDesignation = (reader["Designation"].ToString());
                    _nCustomerID = (int)(reader["CustomerID"]);
                    _sEmployeeAddress = (reader["EmployeeAddress"].ToString());
                    _sEmail = (reader["Email"].ToString());
                    _sPhoneNo = (reader["PhoneNo"].ToString());

                    _sEPSCustomerCode = (reader["EPSCustomerCode"].ToString());
                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) return true;
            else return false;

        }
        public void DeleteEPSCustomer()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from t_epscustomer where EPSCustomerID =? ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EPSCustomerID", _nEPSCustomerID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetCassiopeiaCustomer(int nCustomerID, int nShowroomID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select Name,IsNull(Address,'')Address,IsNull(MobileNo,'')MobileNo,IsNull(Email,'')Email from Cassiopeia_HO.dbo.Customer Where CustomerID=? and ShowroomID=?";
            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
            cmd.Parameters.AddWithValue("ShowroomID", nShowroomID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sEmployeeName = reader["Name"].ToString();
                    _sEmployeeAddress = reader["Address"].ToString();
                    _sPhoneNo = reader["MobileNo"].ToString();
                    _sEmail = reader["Email"].ToString();
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class EPSCustomers : CollectionBase
    {
        public EPSCustomer this[int i]
        {
            get { return (EPSCustomer)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(EPSCustomer oEPSCustomer)
        {
            InnerList.Add(oEPSCustomer);
        }
        public void RefreshForControl(int nCustomerID, String txtCustCode, String txtCustName)
        {
            //dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select EPSCustomerID,EPSCustomerCode,E.CustomerID,EmployeeCode,EmployeeName, "+
                        "EmployeeAddress,PhoneNo,Designation,Email,CustomerCode,CustomerName from t_EPSCustomer E "+
                        "INNER JOIN t_Customer C "+
                        "ON C.CustomerID=E.CustomerID Where EPSCustomerID <>0 ";
            string sClause = "";

            if (nCustomerID != 0)
                sSql = sSql + " and E.CustomerID ='" + nCustomerID + "'";

            if (txtCustCode != "")
            {
                //txtCode = "%" + txtCode + "%";
                sSql = sSql + " AND EPSCustomerCode ='" + txtCustCode + "'";
            }
            if (txtCustName != "")
            {
                txtCustName = "%" + txtCustName + "%";
                sSql = sSql + " AND EmployeeName LIKE '" + txtCustName + "'";
            }

            sSql = sSql + " order by EPSCustomerID ";

            cmd.CommandText = sSql + sClause;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);
        }
        public void Refresh(int nCustomerID, String txtEPSCustomerCode, String txtEmployeeName)
        {
            
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select EPSCustomerID,EPSCustomerCode,E.CustomerID,EmployeeCode,EmployeeName, " +
                        "EmployeeAddress,PhoneNo,Designation,Email,CustomerCode,CustomerName, EmployeeStatus from t_EPSCustomer E " +
                        "INNER JOIN t_Customer C " +
                        "ON C.CustomerID=E.CustomerID Where EPSCustomerID <>0 ";
            string sClause = "";

            if (nCustomerID != 0)
                sSql = sSql + " and E.CustomerID ='" + nCustomerID + "'";

            if (txtEPSCustomerCode != "")
            {
                //txtCode = "%" + txtCode + "%";
                sSql = sSql + " AND EPSCustomerCode ='" + txtEPSCustomerCode + "'";
            }
            if (txtEmployeeName != "")
            {
                txtEmployeeName = "%" + txtEmployeeName + "%";
                sSql = sSql + " AND EmployeeName LIKE '" + txtEmployeeName + "'";
            }

            sSql = sSql + " order by EPSCustomerID ";

            cmd.CommandText = sSql + sClause;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);
        }

        private void GetData(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    EPSCustomer oEPSCustomer = new EPSCustomer();

                    oEPSCustomer.EPSCustomerID = (int)reader["EPSCustomerID"];
                    oEPSCustomer.EPSCustomerCode = (string)reader["EPSCustomerCode"];
                    oEPSCustomer.CustomerID = (int)reader["CustomerID"];
                    oEPSCustomer.EmployeeCode = (string)reader["EmployeeCode"];
                    oEPSCustomer.EmployeeName = (string)reader["EmployeeName"];
                    oEPSCustomer.EmployeeAddress = (string)reader["EmployeeAddress"];
                    oEPSCustomer.Designation = (string)reader["Designation"];
                    oEPSCustomer.PhoneNo = (string)reader["PhoneNo"];
                    oEPSCustomer.Email=(string)reader["Email"];
                    oEPSCustomer.Customer.CustomerCode = (string)reader["CustomerCode"];
                    oEPSCustomer.Customer.CustomerName = (string)reader["CustomerName"];
                    oEPSCustomer.EmployeeStatus = (int)reader["EmployeeStatus"];

                    InnerList.Add(oEPSCustomer);
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

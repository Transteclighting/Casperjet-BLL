// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Dec 07, 2011
// Time :  10:00 AM
// Description: Class for Fixed Asset History.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Admin
{
    public class FixedAssetHistory
    {
        private int _nFAHistoryID;
        private int _nFAID;
        private DateTime _dTranDate;
        private int _nTranTypeID;
        private double _DepreciateValue;
        private int _nCompanyID;
        private int _nDepartmentID;
        private int _nEmployeeID;
        private int _nLocationID;
        private int _nUserID;
        private string _sRemarks;


        /// <summary>
        /// Get set property for FAHistoryID
        /// </summary>
        public int FAHistoryID
        {
            get { return _nFAHistoryID; }
            set { _nFAHistoryID = value; }
        }

        /// <summary>
        /// Get set property for FAID
        /// </summary>
        public int FAID
        {
            get { return _nFAID; }
            set { _nFAID = value; }
        }

        /// <summary>
        /// Get set property for TranDate
        /// </summary>
        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
        }

        /// <summary>
        /// Get set property for TranTypeID
        /// </summary>
        public int TranTypeID
        {
            get { return _nTranTypeID; }
            set { _nTranTypeID = value; }
        }

        /// <summary>
        /// Get set property for DepreciateValue
        /// </summary>
        public double DepreciateValue
        {
            get { return _DepreciateValue; }
            set { _DepreciateValue = value; }
        }

        /// <summary>
        /// Get set property for CompanyID
        /// </summary>
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }

        /// <summary>
        /// Get set property for DepartmentID
        /// </summary>
        public int DepartmentID
        {
            get { return _nDepartmentID; }
            set { _nDepartmentID = value; }
        }

        /// <summary>
        /// Get set property for EmployeeID
        /// </summary>
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }

        /// <summary>
        /// Get set property for LocationID
        /// </summary>
        public int LocationID
        {
            get { return _nLocationID; }
            set { _nLocationID = value; }
        }

        /// <summary>
        /// Get set property for UserID
        /// </summary>
        public int UserID
        {
            get { return _nUserID; }
            set { _nUserID = value; }
        }

        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        public void Add()
        {
            int nMaxFAHistoryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([FAHistoryID]) FROM t_FixedAssetHistory";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxFAHistoryID = 1;
                }
                else
                {
                    nMaxFAHistoryID = Convert.ToInt32(maxID) + 1;
                }
                _nFAHistoryID = nMaxFAHistoryID;

                sSql = "INSERT INTO t_FixedAssetHistory VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("FAHistoryID", _nFAHistoryID);
                cmd.Parameters.AddWithValue("FAID", _nFAID);
                cmd.Parameters.AddWithValue("TranDate", _dTranDate);
                cmd.Parameters.AddWithValue("TranTypeID", _nTranTypeID);
                cmd.Parameters.AddWithValue("DepreciateValue", _DepreciateValue);             
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);

                if (_nDepartmentID != -1)
                    cmd.Parameters.AddWithValue("DepartmentID", _nDepartmentID);
                else cmd.Parameters.AddWithValue("DepartmentID", null);

                if (_nEmployeeID != -1)
                    cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                else cmd.Parameters.AddWithValue("EmployeeID", null);

                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

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
                sSql = "DELETE FROM t_FixedAssetHistory WHERE [FAID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FAID", _nFAID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}

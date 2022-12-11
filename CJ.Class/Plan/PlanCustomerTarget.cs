// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Feb 07, 2016
// Time : 12:08 PM
// Description: Class for PlanCustomerTarget.
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
    public class PlanCustomerTarget
    {
        private int _nVersionNo;
        private int _nTYear;
        private int _nTMonth;
        private int _nWeekNo;
        private int _nCustomerID;
        private int _nOldCustomer;
        private int _nNewCustomer;


        // <summary>
        // Get set property for VersionNo
        // </summary>
        public int VersionNo
        {
            get { return _nVersionNo; }
            set { _nVersionNo = value; }
        }

        // <summary>
        // Get set property for TYear
        // </summary>
        public int TYear
        {
            get { return _nTYear; }
            set { _nTYear = value; }
        }

        // <summary>
        // Get set property for TMonth
        // </summary>
        public int TMonth
        {
            get { return _nTMonth; }
            set { _nTMonth = value; }
        }

        // <summary>
        // Get set property for WeekNo
        // </summary>
        public int WeekNo
        {
            get { return _nWeekNo; }
            set { _nWeekNo = value; }
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
        // Get set property for OldCustomer
        // </summary>
        public int OldCustomer
        {
            get { return _nOldCustomer; }
            set { _nOldCustomer = value; }
        }

        // <summary>
        // Get set property for NewCustomer
        // </summary>
        public int NewCustomer
        {
            get { return _nNewCustomer; }
            set { _nNewCustomer = value; }
        }

        public void Add()
        {
            int nMaxVersionNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_PlanCustomerTarget (VersionNo, TYear, TMonth, WeekNo, CustomerID, OldCustomer, NewCustomer) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("WeekNo", _nWeekNo);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("OldCustomer", _nOldCustomer);
                cmd.Parameters.AddWithValue("NewCustomer", _nNewCustomer);

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
                sSql = "UPDATE t_PlanCustomerTarget SET TYear = ?, TMonth = ?, WeekNo = ?, CustomerID = ?, OldCustomer = ?, NewCustomer = ? WHERE VersionNo = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("WeekNo", _nWeekNo);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("OldCustomer", _nOldCustomer);
                cmd.Parameters.AddWithValue("NewCustomer", _nNewCustomer);

                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);

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
                sSql = "DELETE FROM t_PlanCustomerTarget WHERE [VersionNo]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
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
                cmd.CommandText = "SELECT * FROM t_PlanCustomerTarget where VersionNo =?";
                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nVersionNo = (int)reader["VersionNo"];
                    _nTYear = (int)reader["TYear"];
                    _nTMonth = (int)reader["TMonth"];
                    _nWeekNo = (int)reader["WeekNo"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _nOldCustomer = (int)reader["OldCustomer"];
                    _nNewCustomer = (int)reader["NewCustomer"];
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
    public class PlanCustomerTargets : CollectionBase
    {
        public PlanCustomerTarget this[int i]
        {
            get { return (PlanCustomerTarget)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PlanCustomerTarget oPlanCustomerTarget)
        {
            InnerList.Add(oPlanCustomerTarget);
        }
        public int GetIndex(int nVersionNo)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].VersionNo == nVersionNo)
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
            string sSql = "SELECT * FROM t_PlanCustomerTarget";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PlanCustomerTarget oPlanCustomerTarget = new PlanCustomerTarget();
                    oPlanCustomerTarget.VersionNo = (int)reader["VersionNo"];
                    oPlanCustomerTarget.TYear = (int)reader["TYear"];
                    oPlanCustomerTarget.TMonth = (int)reader["TMonth"];
                    oPlanCustomerTarget.WeekNo = (int)reader["WeekNo"];
                    oPlanCustomerTarget.CustomerID = (int)reader["CustomerID"];
                    oPlanCustomerTarget.OldCustomer = (int)reader["OldCustomer"];
                    oPlanCustomerTarget.NewCustomer = (int)reader["NewCustomer"];
                    InnerList.Add(oPlanCustomerTarget);
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


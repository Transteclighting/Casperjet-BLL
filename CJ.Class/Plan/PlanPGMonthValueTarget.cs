
// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD. Abdul Hakim
// Date: May 04, 2015
// Time : 12:59 PM
// Description: Class for PlanPGMonthValueTarget.
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
    public class PlanPGMonthValueTarget
    {
        private int _nVersionNo;
        private int _nTYear;
        private int _nTMonth;
        private int _nCustomerID;
        private int _nPGID;
        private double _TargetAmount;


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
        // Get set property for CustomerID
        // </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }

        // <summary>
        // Get set property for PGID
        // </summary>
        public int PGID
        {
            get { return _nPGID; }
            set { _nPGID = value; }
        }

        // <summary>
        // Get set property for TargetAmount
        // </summary>
        public double TargetAmount
        {
            get { return _TargetAmount; }
            set { _TargetAmount = value; }
        }

        public void Add()
        {
            int nMaxVersionNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_PlanPGMonthTargetValue (VersionNo, TYear, TMonth, CustomerID, PGID, TargetAmount) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("PGID", _nPGID);
                cmd.Parameters.AddWithValue("TargetAmount", _TargetAmount);

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
                sSql = "UPDATE t_PlanPGMonthTargetValue SET TYear = ?, TMonth = ?, CustomerID = ?, PGID = ?, TargetAmount = ? WHERE VersionNo = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("PGID", _nPGID);
                cmd.Parameters.AddWithValue("TargetAmount", _TargetAmount);

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
                sSql = "DELETE FROM t_PlanPGMonthTargetValue WHERE [VersionNo]=?";
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
                cmd.CommandText = "SELECT * FROM t_PlanPGMonthTargetValue where VersionNo =?";
                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nVersionNo = (int)reader["VersionNo"];
                    _nTYear = (int)reader["TYear"];
                    _nTMonth = (int)reader["TMonth"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _nPGID = (int)reader["PGID"];
                    _TargetAmount = Convert.ToDouble(reader["TargetAmount"].ToString());
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
    public class PlanPGMonthValueTargets : CollectionBase
    {
        public PlanPGMonthValueTarget this[int i]
        {
            get { return (PlanPGMonthValueTarget)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PlanPGMonthValueTarget oPlanPGMonthValueTarget)
        {
            InnerList.Add(oPlanPGMonthValueTarget);
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
            string sSql = "SELECT * FROM t_PlanPGMonthTargetValue";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PlanPGMonthValueTarget oPlanPGMonthValueTarget = new PlanPGMonthValueTarget();
                    oPlanPGMonthValueTarget.VersionNo = (int)reader["VersionNo"];
                    oPlanPGMonthValueTarget.TYear = (int)reader["TYear"];
                    oPlanPGMonthValueTarget.TMonth = (int)reader["TMonth"];
                    oPlanPGMonthValueTarget.CustomerID = (int)reader["CustomerID"];
                    oPlanPGMonthValueTarget.PGID = (int)reader["PGID"];
                    oPlanPGMonthValueTarget.TargetAmount = Convert.ToDouble(reader["TargetAmount"].ToString());
                    InnerList.Add(oPlanPGMonthValueTarget);
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



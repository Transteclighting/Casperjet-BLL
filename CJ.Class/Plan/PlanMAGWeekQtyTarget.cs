
// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD. Abdul Hakim
// Date: May 04, 2015
// Time : 01:04 PM
// Description: Class for PlanMAGWeekQtyTarget.
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
    public class PlanMAGWeekQtyTarget
    {
        private int _nVersionNo;
        private int _nTYear;
        private int _nTMonth;
        private int _nWeekNo;
        private int _nCustomerID;
        private int _nMAGID;
        private int _nBrandID;
        private int _nTargetQty;
        private double _TargetValue;
        private string _sChannel;

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
        // Get set property for MAGID
        // </summary>
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }

        // <summary>
        // Get set property for BrandID
        // </summary>
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }


        // <summary>
        // Get set property for TargetQty
        // </summary>
        public int TargetQty
        {
            get { return _nTargetQty; }
            set { _nTargetQty = value; }
        }

        // <summary>
        // Get set property for TargetValue
        // </summary>
        public double TargetValue
        {
            get { return _TargetValue; }
            set { _TargetValue = value; }
        }
        public string Channel
        {
            get { return _sChannel; }
            set { _sChannel = value.Trim(); }
        }

        public void Add()
        {
            int nMaxVersionNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "INSERT INTO t_PlanMAGWeekTargetQty (VersionNo, TYear, TMonth, WeekNo, CustomerID, MAGID, BrandID, TargetQty, TargetValue, Channel) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("WeekNo", _nWeekNo);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("TargetQty", _nTargetQty);
                cmd.Parameters.AddWithValue("TargetValue", _TargetValue);
                cmd.Parameters.AddWithValue("Channel", _sChannel);

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
                sSql = "UPDATE t_PlanMAGWeekTargetQty SET TYear = ?, TMonth = ?, WeekNo = ?, CustomerID = ?, MAGID = ?, BrandID = ?, TargetQty = ? WHERE VersionNo = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("WeekNo", _nWeekNo);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("TargetQty", _nTargetQty);

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
                sSql = "DELETE FROM t_PlanMAGWeekTargetQty WHERE [VersionNo]=?";
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
                cmd.CommandText = "SELECT * FROM t_PlanMAGWeekTargetQty where VersionNo =?";
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
                    _nMAGID = (int)reader["MAGID"];
                    _nBrandID = (int)reader["BrandID"];
                    _nTargetQty = (int)reader["TargetQty"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetTargetForPOS(int nSalesPersonID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                if (nSalesPersonID != -1)
                    cmd.CommandText = "Select isnull(Sum(TargetAmount),0) TargetAmount,isnull(Sum(TargetQty),0) TargetQty  " +
                                    "From t_PlanExecutiveLeadTarget where TargetType = 5 and SalesPersonID = " + nSalesPersonID + "  " +
                                    "and TYear = YEAR(GETDATE()) and TMonth = Month(GETDATE())  " +
                                    "group by SalesPersonID";

                else cmd.CommandText = "Select isnull(Sum(TargetAmount),0) TargetAmount,isnull(Sum(TargetQty),0) TargetQty  " +
                                    "From t_PlanExecutiveLeadTarget where TargetType = 5  " +
                                    "and TYear = YEAR(GETDATE()) and TMonth = Month(GETDATE())";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTargetQty = Convert.ToInt32(reader["TargetQty"]);
                    _TargetValue = Convert.ToDouble(reader["TargetAmount"]);
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
    public class PlanMAGWeekQtyTargets : CollectionBase
    {
        public PlanMAGWeekQtyTarget this[int i]
        {
            get { return (PlanMAGWeekQtyTarget)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PlanMAGWeekQtyTarget oPlanMAGWeekQtyTarget)
        {
            InnerList.Add(oPlanMAGWeekQtyTarget);
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
            string sSql = "SELECT * FROM t_PlanMAGWeekTargetQty";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PlanMAGWeekQtyTarget oPlanMAGWeekQtyTarget = new PlanMAGWeekQtyTarget();
                    oPlanMAGWeekQtyTarget.VersionNo = (int)reader["VersionNo"];
                    oPlanMAGWeekQtyTarget.TYear = (int)reader["TYear"];
                    oPlanMAGWeekQtyTarget.TMonth = (int)reader["TMonth"];
                    oPlanMAGWeekQtyTarget.WeekNo = (int)reader["WeekNo"];
                    oPlanMAGWeekQtyTarget.CustomerID = (int)reader["CustomerID"];
                    oPlanMAGWeekQtyTarget.MAGID = (int)reader["MAGID"];
                    oPlanMAGWeekQtyTarget.BrandID = (int)reader["BrandID"];
                    oPlanMAGWeekQtyTarget.TargetQty = (int)reader["TargetQty"];
                    oPlanMAGWeekQtyTarget.TargetValue = Convert.ToDouble(reader["TargetValue"]);
                    InnerList.Add(oPlanMAGWeekQtyTarget);
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



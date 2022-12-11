// <summary>
// Company: Transcom Electronics Limited
// Author: Khandakar Ali Ifran
// Date: Oct 12, 2020
// Time : 10:41 AM
// Description: Class for PlanExecutiveActivityTarget.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Plan
{
    public class PlanExecutiveActivityTarget
    {
        private int _nVersionNo;
        private int _nTYear;
        private int _nTMonth;
        private int _nWeekNo;
        private int _nCustomerID;
        private int _nSalesPersonID;
        private int _nDayPlanPurposeID;
        private int _nTarget;
        private int _nChannel;


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
        // Get set property for SalesPersonID
        // </summary>
        public int SalesPersonID
        {
            get { return _nSalesPersonID; }
            set { _nSalesPersonID = value; }
        }

        // <summary>
        // Get set property for DayPlanPurposeID
        // </summary>
        public int DayPlanPurposeID
        {
            get { return _nDayPlanPurposeID; }
            set { _nDayPlanPurposeID = value; }
        }

        // <summary>
        // Get set property for Target
        // </summary>
        public int Target
        {
            get { return _nTarget; }
            set { _nTarget = value; }
        }

        // <summary>
        // Get set property for Channel
        // </summary>
        public int Channel
        {
            get { return _nChannel; }
            set { _nChannel = value; }
        }

        public void Add()
        {
            int nMaxVersionNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([VersionNo]) FROM t_PlanExecutiveActivityTarget";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxVersionNo = 1;
                }
                else
                {
                    nMaxVersionNo = Convert.ToInt32(maxID) + 1;
                }
                _nVersionNo = nMaxVersionNo;
                sSql = "INSERT INTO t_PlanExecutiveActivityTarget (VersionNo, TYear, TMonth, WeekNo, CustomerID, SalesPersonID, DayPlanPurposeID, Target, Channel) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("WeekNo", _nWeekNo);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("DayPlanPurposeID", _nDayPlanPurposeID);
                cmd.Parameters.AddWithValue("Target", _nTarget);
                cmd.Parameters.AddWithValue("Channel", _nChannel);

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
                sSql = "UPDATE t_PlanExecutiveActivityTarget SET TYear = ?, TMonth = ?, WeekNo = ?, CustomerID = ?, SalesPersonID = ?, DayPlanPurposeID = ?, Target = ?, Channel = ? WHERE VersionNo = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("WeekNo", _nWeekNo);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("DayPlanPurposeID", _nDayPlanPurposeID);
                cmd.Parameters.AddWithValue("Target", _nTarget);
                cmd.Parameters.AddWithValue("Channel", _nChannel);

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
                sSql = "DELETE FROM t_PlanExecutiveActivityTarget WHERE [VersionNo]=?";
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
                cmd.CommandText = "SELECT * FROM t_PlanExecutiveActivityTarget where VersionNo =?";
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
                    _nSalesPersonID = (int)reader["SalesPersonID"];
                    _nDayPlanPurposeID = (int)reader["DayPlanPurposeID"];
                    _nTarget = (int)reader["Target"];
                    _nChannel = (int)reader["Channel"];
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
    public class PlanExecutiveActivityTargets : CollectionBase
    {
        public PlanExecutiveActivityTarget this[int i]
        {
            get { return (PlanExecutiveActivityTarget)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PlanExecutiveActivityTarget oPlanExecutiveActivityTarget)
        {
            InnerList.Add(oPlanExecutiveActivityTarget);
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
            string sSql = "SELECT * FROM t_PlanExecutiveActivityTarget";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PlanExecutiveActivityTarget oPlanExecutiveActivityTarget = new PlanExecutiveActivityTarget();
                    oPlanExecutiveActivityTarget.VersionNo = (int)reader["VersionNo"];
                    oPlanExecutiveActivityTarget.TYear = (int)reader["TYear"];
                    oPlanExecutiveActivityTarget.TMonth = (int)reader["TMonth"];
                    oPlanExecutiveActivityTarget.WeekNo = (int)reader["WeekNo"];
                    oPlanExecutiveActivityTarget.CustomerID = (int)reader["CustomerID"];
                    oPlanExecutiveActivityTarget.SalesPersonID = (int)reader["SalesPersonID"];
                    oPlanExecutiveActivityTarget.DayPlanPurposeID = (int)reader["DayPlanPurposeID"];
                    oPlanExecutiveActivityTarget.Target = (int)reader["Target"];
                    oPlanExecutiveActivityTarget.Channel = (int)reader["Channel"];
                    InnerList.Add(oPlanExecutiveActivityTarget);
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


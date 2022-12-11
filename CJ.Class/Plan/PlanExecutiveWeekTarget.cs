// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD. Abdul Hakim
// Date: Apr 20, 2015
// Time : 05:54 PM
// Description: Class for PlanExecutiveWeekTarget.
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
    public class PlanExecutiveWeekTarget
    {
        private int _nVersionNo;
        private int _nTYear;
        private int _nTMonth;
        private int _nWeekNo;
        private int _nCustomerID;
        private int _nSalesPersonID;
        private string _sCategory;
        private double _TargetAmount;
        private string _sChannel;

        private int _nS1Qty;
        public int S1Qty
        {
            get { return _nS1Qty; }
            set { _nS1Qty = value; }
        }
        private int _nS2Qty;
        public int S2Qty
        {
            get { return _nS2Qty; }
            set { _nS2Qty = value; }
        }
        private int _nS3Qty;
        public int S3Qty
        {
            get { return _nS3Qty; }
            set { _nS3Qty = value; }
        }
        private double _nS1Value;
        public double S1Value
        {
            get { return _nS1Value; }
            set { _nS1Value = value; }
        }
        private double _nS2Value;
        public double S2Value
        {
            get { return _nS2Value; }
            set { _nS2Value = value; }
        }
        private double _nS3Value;
        public double S3Value
        {
            get { return _nS3Value; }
            set { _nS3Value = value; }
        }


        private int _nTargetQty;
        public int TargetQty
        {
            get { return _nTargetQty; }
            set { _nTargetQty = value; }
        }


        private int _nMAGID;
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }
        private int _nBrandID;
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        private int _nChannelID;
        public int ChannelID
        {
            get { return _nChannelID; }
            set { _nChannelID = value; }
        }
        private int _nTargetType;
        public int TargetType
        {
            get { return _nTargetType; }
            set { _nTargetType = value; }
        }


        // <summary>
        // Get set property for Category
        // </summary>
        public string Channel
        {
            get { return _sChannel; }
            set { _sChannel = value.Trim(); }
        }

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
        // Get set property for Category
        // </summary>
        public string Category
        {
            get { return _sCategory; }
            set { _sCategory = value.Trim(); }
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
                sSql = "INSERT INTO t_PlanExecutiveWeekTarget (VersionNo, TYear, TMonth, WeekNo, CustomerID, SalesPersonID, Category, TargetAmount) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("WeekNo", _nWeekNo);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("Category", _sCategory);
                cmd.Parameters.AddWithValue("TargetAmount", _TargetAmount);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void AddLeadTarget()
        {
            int nMaxVersionNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_PlanExecutiveLeadTarget (VersionNo,TYear,TMonth,WeekNo,CustomerID,SalesPersonID, " +
                       "MAGID,BrandID,TargetQty,TargetAmount,Channel,TargetType) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("WeekNo", _nWeekNo);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);


                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("TargetQty", _nTargetQty);
                cmd.Parameters.AddWithValue("TargetAmount", _TargetAmount);
                cmd.Parameters.AddWithValue("Channel", _nChannelID);
                cmd.Parameters.AddWithValue("TargetType", _nTargetType);
                

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddOpportunityTarget()
        {
            int nMaxVersionNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_PlanOpportunityTarget (VersionNo,TYear,TMonth,CustomerID,MAGID,BrandID,Slab1Qty,Slab1Value,Slab2Qty,Slab2Value,Slab3Qty,Slab3Value) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VersionNo", _nVersionNo);
                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("Slab1Qty", _nS1Qty);
                cmd.Parameters.AddWithValue("Slab1Value", _nS1Value);
                cmd.Parameters.AddWithValue("Slab1Qty", _nS2Qty);
                cmd.Parameters.AddWithValue("Slab1Value", _nS2Value);
                cmd.Parameters.AddWithValue("Slab1Qty", _nS3Qty);
                cmd.Parameters.AddWithValue("Slab1Value", _nS3Value);
                

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
                sSql = "UPDATE t_PlanExecutiveWeekTarget SET TYear = ?, TMonth = ?, WeekNo = ?, CustomerID = ?, SalesPersonID = ?, Category = ?, TargetAmount = ? WHERE VersionNo = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("WeekNo", _nWeekNo);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("SalesPersonID", _nSalesPersonID);
                cmd.Parameters.AddWithValue("Category", _sCategory);
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
                sSql = "DELETE FROM t_PlanExecutiveWeekTarget WHERE [VersionNo]=?";
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

        public void DeleteLeadTarget()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_PlanExecutiveLeadTarget WHERE [VersionNo]=?";
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

        public void DeleteOT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_PlanOpportunityTarget WHERE [VersionNo]=?";
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
                cmd.CommandText = "SELECT * FROM t_PlanExecutiveWeekTarget where VersionNo =?";
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
                    _sCategory = (string)reader["Category"];
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
        public bool CheckCustomer(int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_Customer where CustomerID =?";
                cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
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
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class PlanExecutiveWeekTargets : CollectionBase
    {
        public PlanExecutiveWeekTarget this[int i]
        {
            get { return (PlanExecutiveWeekTarget)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PlanExecutiveWeekTarget oPlanExecutiveWeekTarget)
        {
            InnerList.Add(oPlanExecutiveWeekTarget);
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
            string sSql = "SELECT * FROM t_PlanExecutiveWeekTarget";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PlanExecutiveWeekTarget oPlanExecutiveWeekTarget = new PlanExecutiveWeekTarget();

                    oPlanExecutiveWeekTarget.VersionNo = (int)reader["VersionNo"];
                    oPlanExecutiveWeekTarget.TYear = (int)reader["TYear"];
                    oPlanExecutiveWeekTarget.TMonth = (int)reader["TMonth"];
                    oPlanExecutiveWeekTarget.WeekNo = (int)reader["WeekNo"];
                    oPlanExecutiveWeekTarget.CustomerID = (int)reader["CustomerID"];
                    oPlanExecutiveWeekTarget.SalesPersonID = (int)reader["SalesPersonID"];
                    oPlanExecutiveWeekTarget.Category = (string)reader["Category"];
                    oPlanExecutiveWeekTarget.TargetAmount = Convert.ToDouble(reader["TargetAmount"].ToString());
                    InnerList.Add(oPlanExecutiveWeekTarget);
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



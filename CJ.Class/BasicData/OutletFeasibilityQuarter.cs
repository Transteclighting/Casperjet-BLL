// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Oct 13, 2019
// Time : 02:18 PM
// Description: Class for OutletFeasibilityQuarter.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.BasicData
{
    public class OutletFeasibilityQuarter
    {
        private int _nID;
        private int _nOutletFeasibilityID;
        private string _sQuarter;
        private DateTime _dFromDate;
        private DateTime _dToDate;
        private double _fQuarterPercent;


        public double QuarterPercent
        {
            get { return _fQuarterPercent; }
            set { _fQuarterPercent = value; }
        }

        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for OutletFeasibilityID
        // </summary>
        public int OutletFeasibilityID
        {
            get { return _nOutletFeasibilityID; }
            set { _nOutletFeasibilityID = value; }
        }

        // <summary>
        // Get set property for Quarter
        // </summary>
        public string Quarter
        {
            get { return _sQuarter; }
            set { _sQuarter = value.Trim(); }
        }

        // <summary>
        // Get set property for FromDate
        // </summary>
        public DateTime FromDate
        {
            get { return _dFromDate; }
            set { _dFromDate = value; }
        }

        // <summary>
        // Get set property for ToDate
        // </summary>
        public DateTime ToDate
        {
            get { return _dToDate; }
            set { _dToDate = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_OutletFeasibilityQuarter";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = Convert.ToInt32(maxID) + 1;
                }
                _nID = nMaxID;
                sSql = "INSERT INTO t_OutletFeasibilityQuarter (ID, OutletFeasibilityID, Quarter, FromDate, ToDate, QuarterPercent) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("OutletFeasibilityID", _nOutletFeasibilityID);
                cmd.Parameters.AddWithValue("Quarter", _sQuarter);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("QuarterPercent", _fQuarterPercent);

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
                sSql = "UPDATE t_OutletFeasibilityQuarter SET OutletFeasibilityID = ?, Quarter = ?, FromDate = ?, ToDate = ?, QuarterPercent=? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OutletFeasibilityID", _nOutletFeasibilityID);
                cmd.Parameters.AddWithValue("Quarter", _sQuarter);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("QuarterPercent", _fQuarterPercent);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete(int _nOutletFeasibilityID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_OutletFeasibilityQuarter WHERE OutletFeasibilityID="+_nOutletFeasibilityID+"";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("OutletFeasibilityID", _nOutletFeasibilityID);
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
                cmd.CommandText = "SELECT * FROM t_OutletFeasibilityQuarter where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nOutletFeasibilityID = (int)reader["OutletFeasibilityID"];
                    _sQuarter = (string)reader["Quarter"];
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    _fQuarterPercent = Convert.ToDouble(reader["QuarterPercent"].ToString());
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
    public class OutletFeasibilityQuarters : CollectionBase
    {
        public OutletFeasibilityQuarter this[int i]
        {
            get { return (OutletFeasibilityQuarter)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OutletFeasibilityQuarter oOutletFeasibilityQuarter)
        {
            InnerList.Add(oOutletFeasibilityQuarter);
        }
        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(int nOutletFeasibilityID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_OutletFeasibilityQuarter where OutletFeasibilityID='"+ nOutletFeasibilityID + "'";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletFeasibilityQuarter oOutletFeasibilityQuarter = new OutletFeasibilityQuarter();
                    oOutletFeasibilityQuarter.ID = (int)reader["ID"];
                    oOutletFeasibilityQuarter.OutletFeasibilityID = (int)reader["OutletFeasibilityID"];
                    oOutletFeasibilityQuarter.Quarter = (string)reader["Quarter"];
                    oOutletFeasibilityQuarter.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oOutletFeasibilityQuarter.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oOutletFeasibilityQuarter.QuarterPercent = Convert.ToDouble(reader["QuarterPercent"].ToString());
                    InnerList.Add(oOutletFeasibilityQuarter);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByQuarter(DateTime dtDate) 
        {
            DateTime.Compare(dtDate.AddDays(10),DateTime.Now);
            if (dtDate.Day >= 10)
            {
                dtDate = new DateTime(dtDate.Year, dtDate.Month, 1).AddMonths(1);   
            }
            else
            {
                dtDate = new DateTime(dtDate.Year, dtDate.Month, 1);
            }
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = string.Format(@"Select FromDate,ToDate,Case when QuarterNo=1 then '1Q1'
                            when QuarterNo=2 then '1Q2' when QuarterNo = 3 then '1Q3'
                            when QuarterNo = 4 then '1Q4'
                            when QuarterNo= 5 then '2Q1'
                            when QuarterNo= 6 then '2Q2' when QuarterNo = 7 then '2Q3'
                            when QuarterNo = 8 then '2Q4'
                            when QuarterNo= 9 then '3Q1'
                            when QuarterNo= 10 then '3Q2' when QuarterNo = 11 then '3Q3'
                            when QuarterNo =12 then '3Q4'
                            End as QuarterNo 
                            from (SELECT DATEADD(mm, (quarter - 1) * 3, Year_date) FromDate, 
                            DATEADD(dd, -1, DATEADD(mm, quarter * 3, year_date)) ToDate, 
                            Quarter QuarterNo FROM(SELECT '{0}' Year_date) S 
                            CROSS JOIN 
                            ( SELECT 1 Quarter 
                            UNION ALL 
                            SELECT 2 
                            UNION ALL 
                            SELECT 3 
                            UNION ALL 
                            SELECT 4 
                            UNION ALL 
                            SELECT 5 
                            UNION ALL 
                            SELECT 6 
                            UNION ALL 
                            SELECT 7
                            UNION ALL 
                            SELECT 8 
                            UNION ALL 
                            SELECT 9 
                            UNION ALL 
                            SELECT 10
                            UNION ALL 
                            SELECT 11 
                            UNION ALL 
                            SELECT 12  
                            ) Q )P" ,dtDate);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletFeasibilityQuarter oOutletFeasibilityQuarter = new OutletFeasibilityQuarter();
                    oOutletFeasibilityQuarter.Quarter = (string)reader["QuarterNo"];
                    oOutletFeasibilityQuarter.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oOutletFeasibilityQuarter.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    //oOutletFeasibilityQuarter.QuarterPercent = Convert.ToDouble(reader["QuarterPercent"].ToString());
                    InnerList.Add(oOutletFeasibilityQuarter);
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


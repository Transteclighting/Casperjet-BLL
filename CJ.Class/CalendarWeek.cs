// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Sep 22, 2015
// Time : 06:19 PM
// Description: Class for CalendarWeek.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.Class
{
    public class CalendarWeek
    {
        private int _nID;
        private int _nCYear;
        private int _nCMonth;
        private int _nWeekNo;
        private DateTime _dFromDate;
        private DateTime _dToDate;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for CYear
        // </summary>
        public int CYear
        {
            get { return _nCYear; }
            set { _nCYear = value; }
        }

        // <summary>
        // Get set property for CMonth
        // </summary>
        public int CMonth
        {
            get { return _nCMonth; }
            set { _nCMonth = value; }
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
                sSql = "SELECT MAX([ID]) FROM t_CalendarWeek";
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
                sSql = "INSERT INTO t_CalendarWeek (ID, CYear, CMonth, WeekNo, FromDate, ToDate) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("CYear", _nCYear);
                cmd.Parameters.AddWithValue("CMonth", _nCMonth);
                cmd.Parameters.AddWithValue("WeekNo", _nWeekNo);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);

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
                sSql = "UPDATE t_CalendarWeek SET CYear = ?, CMonth = ?, WeekNo = ?, FromDate = ?, ToDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CYear", _nCYear);
                cmd.Parameters.AddWithValue("CMonth", _nCMonth);
                cmd.Parameters.AddWithValue("WeekNo", _nWeekNo);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "DELETE FROM t_CalendarWeek WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
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
                cmd.CommandText = "SELECT * FROM t_CalendarWeek where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nCYear = (int)reader["CYear"];
                    _nCMonth = (int)reader["CMonth"];
                    _nWeekNo = (int)reader["WeekNo"];
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int GetReamainingDateBLL()
        {
            string sSQL = "";
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            TELLib _oTELLib = new TELLib();
            DateTime _dToday = DateTime.Now.Date;
            DateTime _FirstDayofMonth = _oTELLib.FirstDayofMonth(_dToday);
            DateTime _FirstDayofNextMonth = _FirstDayofMonth.AddMonths(1);
            int _nDay = 0;


            sSQL = " select count(TDate)as DayRemain from BLLSysDB.dbo.t_CalendarSales " +
                   " where TDate between  '" + _dToday + "' and '" + _FirstDayofNextMonth + "' and TDate < '" + _FirstDayofNextMonth + "' and IssalesDay=1 ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["DayRemain"] != DBNull.Value)
                        _nDay = Convert.ToInt32(reader["DayRemain"]);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return _nDay;
        }
    }
    public class CalendarWeeks : CollectionBase
    {
        public CalendarWeek this[int i]
        {
            get { return (CalendarWeek)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CalendarWeek oCalendarWeek)
        {
            InnerList.Add(oCalendarWeek);
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
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nPrYear = DateTime.Now.Year - 1;
            int nNxtYear = DateTime.Now.Year + 1;
            string sSql = "SELECT * FROM t_CalendarWeek where CYear in (" + DateTime.Now.Year + "," + nPrYear + "," + nNxtYear + ") order by CYear,CMonth ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CalendarWeek oCalendarWeek = new CalendarWeek();
                    oCalendarWeek.ID = (int)reader["ID"];
                    oCalendarWeek.CYear = (int)reader["CYear"];
                    oCalendarWeek.CMonth = (int)reader["CMonth"];
                    oCalendarWeek.WeekNo = (int)reader["WeekNo"];
                    oCalendarWeek.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oCalendarWeek.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    InnerList.Add(oCalendarWeek);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(int nMonth, int nYear)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nPrYear = DateTime.Now.Year - 1;
            int nNxtYear = DateTime.Now.Year + 1;
            string sSql = "SELECT * FROM t_CalendarWeek where CYear=" + nYear + " and CMonth=" + nMonth + " order by CYear,CMonth ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CalendarWeek oCalendarWeek = new CalendarWeek();
                    oCalendarWeek.ID = (int)reader["ID"];
                    oCalendarWeek.CYear = (int)reader["CYear"];
                    oCalendarWeek.CMonth = (int)reader["CMonth"];
                    oCalendarWeek.WeekNo = (int)reader["WeekNo"];
                    oCalendarWeek.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oCalendarWeek.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    InnerList.Add(oCalendarWeek);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetWeeks(int nMonth, int nYear)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select WeekNo From t_CalendarWeek where CMonth=" + nMonth + " and CYear=" + nYear + " group by WeekNo";
  
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CalendarWeek oCalendarWeek = new CalendarWeek();
                    oCalendarWeek.WeekNo = (int)reader["WeekNo"];
                    InnerList.Add(oCalendarWeek);
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


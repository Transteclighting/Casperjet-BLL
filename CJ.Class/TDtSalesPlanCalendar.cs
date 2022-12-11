// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Sep 19, 2013
// Time :  10:56 AM
// Description: Class for TD Sales Plan Calender.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class
{
    public class TDtSalesPlanCalendar
    {
        private int _nYearID;
        private int _nMonthNo;
        public string _sWeekName;
        private DateTime _dFromDate;
        private DateTime _dToDate;


        public int YearID
        {
            get { return _nYearID; }
            set { _nYearID = value; }
        }
        public int MonthNo
        {
            get { return _nMonthNo; }
            set { _nMonthNo = value; }
        }
        public string WeekName
        {
            get { return _sWeekName; }
            set { _sWeekName = value; }
        }
        public DateTime FromDate
        {
            get { return _dFromDate; }
            set { _dFromDate = value; }
        }
        public DateTime ToDate
        {
            get { return _dToDate; }
            set { _dToDate = value; }
        }

    }
    public class TDtSalesPlanCalendars : CollectionBase
    {

        public TDtSalesPlanCalendar this[int i]
        {
            get { return (TDtSalesPlanCalendar)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public int GetIndexByID(string sWeekName)
        {
            int i = 0;
            foreach (TDtSalesPlanCalendar oTDtSalesPlanCalendar in this)
            {
                if (oTDtSalesPlanCalendar.WeekName == sWeekName)
                    return i;
                i++;
            }
            return -1;
        }

        public void Add(TDtSalesPlanCalendar oTDtSalesPlanCalendar)
        {
            InnerList.Add(oTDtSalesPlanCalendar);
        }

        public void Refresh(DateTime dtPlanMonth)
        {

            int nYearID = dtPlanMonth.Year;
            int nMonthNo = dtPlanMonth.Month;

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select YearID, MonthNo,WeekName,FromDate,ToDate from dbo.t_TDSalesPlanCalendar Where YearID=? and MonthNo=?";

            cmd.Parameters.AddWithValue("YearID", nYearID);
            cmd.Parameters.AddWithValue("MonthNo", nMonthNo);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    TDtSalesPlanCalendar oTDtSalesPlanCalendar = new TDtSalesPlanCalendar();

                    oTDtSalesPlanCalendar.YearID = int.Parse(reader["YearID"].ToString());
                    oTDtSalesPlanCalendar.MonthNo = int.Parse(reader["MonthNo"].ToString());
                    oTDtSalesPlanCalendar.WeekName = (string)reader["WeekName"];
                    oTDtSalesPlanCalendar.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oTDtSalesPlanCalendar.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());

                    InnerList.Add(oTDtSalesPlanCalendar);
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

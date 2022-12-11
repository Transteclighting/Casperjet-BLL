// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: June 05, 2011
// Time :  4:55 PM
// Description: Class for Holiday.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;
using CJ.Class.HR;

namespace CJ.Class
{
    public class Holiday
    {
        private DateTime _Holiday;
        private int _CompanyID;
        private string _Reason;


        /// <summary>
        /// Get set property for Holiday
        /// </summary>
        public DateTime HolidayDate
        {
            get { return _Holiday; }
            set { _Holiday = value; }
        }

        /// <summary>
        /// Get set property for CompanyID
        /// </summary>
        public int CompanyID
        {
            get { return _CompanyID; }
            set { _CompanyID = value; }
        }

        /// <summary>
        /// Get set property for Reason
        /// </summary>
        public string Reason
        {
            get { return _Reason; }
            set { _Reason = value.Trim(); }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_HRHoliday(CompanyID,Holiday,Reason)"
                    + " VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CompanyID", _CompanyID);
                cmd.Parameters.AddWithValue("Holiday", _Holiday);
                cmd.Parameters.AddWithValue("Reason", _Reason);

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
                sSql = "DELETE FROM t_HRHoliday WHERE CompanyID=? AND Holiday=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CompanyID", _CompanyID);
                cmd.Parameters.AddWithValue("Holiday", _Holiday);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool IsHoliday()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_HRHoliday where CompanyID =? AND Holiday=?";
                cmd.Parameters.AddWithValue("CompanyID", _CompanyID);
                cmd.Parameters.AddWithValue("Holiday", _Holiday);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) nCount++;
                reader.Close();
                return nCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }


    public class Holidays : CollectionBase
    {
        public Holiday this[int i]
        {
            get { return (Holiday)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Holiday oHoliday)
        {
            InnerList.Add(oHoliday);
        }

        public int GetIndex(int nCompanyID, DateTime dHolidayDate)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].CompanyID == nCompanyID && this[i].HolidayDate == dHolidayDate)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_HRHoliday";
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);
        }

        public void Refresh(int nCompanyID, int nMonth, int nYear)
        {
            DateTime dFromDate = new DateTime(nYear, nMonth, 1);
            DateTime dToDate = dFromDate.AddMonths(1).AddDays(-1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_HRHoliday WHERE CompanyID=? AND Holiday BETWEEN ? and ?";
            cmd.Parameters.AddWithValue("CompanyID", nCompanyID);
            cmd.Parameters.AddWithValue("FromDate", dFromDate);
            cmd.Parameters.AddWithValue("ToDate", dToDate);

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            GetData(cmd);
        }

        public DSAttendance GetHolydayData(DSAttendance oDSHolyday, int nCompanyID, DateTime dFromDate, DateTime dToDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            string sSql = " SELECT * FROM t_HRHoliday WHERE Holiday " +
                          " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and Holiday < '" + dToDate + "'";
            if (nCompanyID != 0)
            {
                sSql += " AND CompanyID=" + nCompanyID + " ";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSAttendance.HolydayRow oHolydayRow = oDSHolyday.Holyday.NewHolydayRow();

                    oHolydayRow.CompanyID = (int)reader["CompanyID"];
                    oHolydayRow.FromDate = (DateTime)reader["Holiday"];

                    oDSHolyday.Holyday.AddHolydayRow(oHolydayRow);
                    oDSHolyday.AcceptChanges();
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDSHolyday;
        }

        private void GetData(OleDbCommand cmd)
        {
            InnerList.Clear();
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Holiday oHoliday = new Holiday();
                    oHoliday.HolidayDate = (DateTime)reader["Holiday"];
                    oHoliday.CompanyID = (int)reader["CompanyID"];
                    oHoliday.Reason = (string)reader["Reason"];

                    InnerList.Add(oHoliday);

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






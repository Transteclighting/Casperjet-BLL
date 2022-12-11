// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Feb 04, 2012
// Time :  11:30 AM
// Description: Class for DMS Product Target.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.DMS
{
    public class DMSProductTarget
    {
        private int _nDistributorID;
        private int _nOutletID;
        private int _nProductID;
        private DateTime _dTargetDate;
        private int _nWeekNo;
        private int _nDayNo;
        private int _nQty;
        private DateTime _dEntryDate;


        /// <summary>
        /// Get set property for DistributorID
        /// </summary>
        public int DistributorID
        {
            get { return _nDistributorID; }
            set { _nDistributorID = value; }
        }

        /// <summary>
        /// Get set property for OutletID
        /// </summary>
        public int OutletID
        {
            get { return _nOutletID; }
            set { _nOutletID = value; }
        }

        /// <summary>
        /// Get set property for ProductID
        /// </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        /// <summary>
        /// Get set property for TargetDate
        /// </summary>
        public DateTime TargetDate
        {
            get { return _dTargetDate; }
            set { _dTargetDate = value; }
        }

        /// <summary>
        /// Get set property for WeekNo
        /// </summary>
        public int WeekNo
        {
            get { return _nWeekNo; }
            set { _nWeekNo = value; }
        }

        /// <summary>
        /// Get set property for DayNo
        /// </summary>
        public int DayNo
        {
            get { return _nDayNo; }
            set { _nDayNo = value; }
        }

        /// <summary>
        /// Get set property for Qty
        /// </summary>
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        /// <summary>
        /// Get set property for EntryDate
        /// </summary>
        public DateTime EntryDate
        {
            get { return _dEntryDate; }
            set { _dEntryDate = value; }
        }

        public void Add()
        {           
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_DMSProductTarget VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("TargetDate", _dTargetDate);
                cmd.Parameters.AddWithValue("WeekNo", _nWeekNo);
                cmd.Parameters.AddWithValue("DayNo", _nDayNo);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("EntryDate", _dEntryDate);            

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
                sSql = "DELETE FROM t_DMSProductTarget WHERE DistributorID =? and OutletID=? and ProductID =? and TargetDate=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("OutletID", _nOutletID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("TargetDate", _dTargetDate);
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

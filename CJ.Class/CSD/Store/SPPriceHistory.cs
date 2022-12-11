// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Sep 20, 2012
// Time :  40:00 PM
// Description: Class for Spare Parts Price History.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Class
{
    public class SPPriceHistory
    {

        private int _nSPPriceHistoryID;
        private int _nSparePartID;
        private double _sCostPrice;
        private double _sSalePrice;
        private int _nCreateUserID;
        private DateTime _dCreateDate;


        /// <summary>
        /// Get set property for SPPriceHistoryID
        /// </summary>
        public int SPPriceHistoryID
        {
            get { return _nSPPriceHistoryID; }
            set { _nSPPriceHistoryID = value; }
        }
        /// <summary>
        /// Get set property for SparePartID
        /// </summary>
        public int SparePartID
        {
            get { return _nSparePartID; }
            set { _nSparePartID = value; }
        }
        /// <summary>
        /// Get set property for CostPrice
        /// </summary>
        public double CostPrice
        {
            get { return _sCostPrice; }
            set { _sCostPrice = value; }
        }
        /// <summary>
        /// Get set property for SalePrice
        /// </summary>
        public double SalePrice
        {
            get { return _sSalePrice; }
            set { _sSalePrice = value; }
        }
        /// <summary>
        /// Get set property for CreateUserID
        /// </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
            //set { _sGeoLocationName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }

        }

        public void Add()
        {
            int nMaxSPPriceHistoryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SPPriceHistoryID]) FROM t_CSDSPPriceHistory";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSPPriceHistoryID = 1;
                }
                else
                {
                    nMaxSPPriceHistoryID = Convert.ToInt32(maxID) + 1;
                }
                _nSPPriceHistoryID = nMaxSPPriceHistoryID;


                sSql = "INSERT INTO t_CSDSPPriceHistory(SPPriceHistoryID,SparePartID,CostPrice,SalePrice,CreateUserID,CreateDate) VALUES(?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SPPriceHistoryID", _nSPPriceHistoryID);
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.Parameters.AddWithValue("CostPrice", _sCostPrice);
                cmd.Parameters.AddWithValue("SalePrice", _sSalePrice);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckPriceHistory()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDSPPriceHistory where SparePartID=? and CostPrice=? and SalePrice=? ";
            cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
            cmd.Parameters.AddWithValue("CostPrice", _sCostPrice);
            cmd.Parameters.AddWithValue("SalePrice", _sSalePrice);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //_dStatusDate = Convert.ToDateTime(reader["StatusDate"].ToString());
                    //_nStatus = int.Parse(reader["Status"].ToString());
                    //_sRemarks = (string)reader["Remarks"];
                    //_nUserID = (int)reader["UserID"];
                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return true;
            else return false;
        }
    }
    public class SPPriceHistorys : CollectionBase
    {

        public SPPriceHistory this[int i]
        {
            get { return (SPPriceHistory)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SPPriceHistory oSPPriceHistory)
        {
            InnerList.Add(oSPPriceHistory);
        }
    }
}


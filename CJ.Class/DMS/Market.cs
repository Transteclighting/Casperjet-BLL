// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: July 19, 2011
// Time :  10:00 AM
// Description: Class for DMS Market Information.
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
   public class Market
    {
        private int _nMarketID;
        private int _nMarketCode;
        private string _sMarketName;
        private int _nThanaID;
        private int _nDistributorID;
        private int _nMarketTypeID;


        /// <summary>
        /// Get set property for MarketID
        /// </summary>
        public int MarketID
        {
            get { return _nMarketID; }
            set { _nMarketID = value; }
        }

        /// <summary>
        /// Get set property for MarketName
        /// </summary>
        public string MarketName
        {
            get { return _sMarketName; }
            set { _sMarketName = value.Trim(); }
        }
       public int MarketCode
       {
           get { return _nMarketCode; }
           set { _nMarketCode = value; }
       }

        /// <summary>
        /// Get set property for ThanaID
        /// </summary>
        public int ThanaID
        {
            get { return _nThanaID; }
            set { _nThanaID = value; }
        }

        /// <summary>
        /// Get set property for DistributorID
        /// </summary>
        public int DistributorID
        {
            get { return _nDistributorID; }
            set { _nDistributorID = value; }
        }
       public int MarketTypeID
       {
           get { return _nMarketTypeID; }
           set { _nMarketTypeID = value; }
       }

        public void Add()
        {
            int nMaxMarketID = 0;
            int nMaxMarketCode = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([MarketID]) FROM t_DMSMarket";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxMarketID = 1;
                }
                else
                {
                    nMaxMarketID = Convert.ToInt32(maxID) + 1;
                }
                _nMarketID = nMaxMarketID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([MarketCode]) FROM t_DMSMarket";
                cmd.CommandText = sSql;
                object maxCode = cmd.ExecuteScalar();
                if (maxCode == DBNull.Value)
                {
                    nMaxMarketCode= 300001;
                }
                else
                {
                    nMaxMarketCode=(Convert.ToInt32(maxCode) + 1);
                }
                _nMarketCode = nMaxMarketCode;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_DMSMarket VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("MarketID", _nMarketID);
                cmd.Parameters.AddWithValue("MarketCode", _nMarketCode);
                cmd.Parameters.AddWithValue("MarketName", _sMarketName);
                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("MarketTypeID", _nMarketTypeID);

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

                sSql = "UPDATE t_DMSMarket SET MarketCode=?,MarketName=?, ThanaID=?, MarketTypeID=? WHERE MarketID=? and DistributorID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("MarketCode", _nMarketCode);
                cmd.Parameters.AddWithValue("MarketName", _sMarketName);
                cmd.Parameters.AddWithValue("ThanaID", _nThanaID);
                cmd.Parameters.AddWithValue("MarketType", _nMarketTypeID);

                cmd.Parameters.AddWithValue("MarketTypeID", _nMarketID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);

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
                sSql = "DELETE FROM t_DMSMarket WHERE MarketID =? and DistributorID=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("MarketID", _nMarketID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

    }
    public class Markets : CollectionBase
    {

        public Market this[int i]
        {
            get { return (Market)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public int GetIndexByID(int nMarketID)
        {
            int i = 0;
            foreach (Market oMarket in this)
            {
                if (oMarket.MarketID == nMarketID)
                    return i;
                i++;
            }
            return -1;
        }


        public void Add(Market oMarket)
        {
            InnerList.Add(oMarket);
        }

        public void Refresh(int nDistributorID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " SELECT * FROM t_DMSMarket where DistributorID=? ";
            cmd.Parameters.AddWithValue("DistributorID", nDistributorID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Market oMarket = new Market();

                    oMarket.MarketID = (int)reader["MarketID"];
                    oMarket.MarketCode = (int)reader["MarketCode"];
                    oMarket.MarketName = (string)reader["MarketName"];
                    oMarket.ThanaID = (int)reader["ThanaID"];
                    if (reader["MarketTypeID"] != DBNull.Value)
                        oMarket.MarketTypeID = Convert.ToInt32(reader["MarketTypeID"]);
                    else oMarket.MarketTypeID = -1;

                    InnerList.Add(oMarket);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshClusterMkt(int nDistributorID)
        {
            Market oMarket;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " SELECT * FROM t_DMSMarket where DistributorID=? and MarketTypeID=2";
            cmd.Parameters.AddWithValue("DistributorID", nDistributorID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oMarket = new Market();

                    oMarket.MarketID =Convert.ToInt32(reader["MarketID"]);
                    oMarket.MarketCode = (int)reader["MarketCode"];
                    oMarket.MarketName = (string)reader["MarketName"];                                        
                    InnerList.Add(oMarket);
                }

                reader.Close();
                oMarket = new Market();
                oMarket.MarketID = -1;
                oMarket.MarketName = "ALL";
                InnerList.Add(oMarket);
                InnerList.TrimToSize();
               

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetMarket(int nDistributorID)
        {
            InnerList.Clear();
            Market oMarket;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSMarket where DistributorID=?";
            cmd.Parameters.AddWithValue("DistributorID", nDistributorID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oMarket = new Market();
                    oMarket.MarketID = (int)reader["MarketID"];                   
                    oMarket.MarketName = (string)reader["MarketName"];                  

                    InnerList.Add(oMarket);
                }
                reader.Close();

                oMarket = new Market();
                oMarket.MarketID = -1;
                oMarket.MarketName = "Select Market";

                InnerList.Add(oMarket);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetMall()
        {
            InnerList.Clear();
            Market oMarket;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSMarket WHERE MarketType = ?";
            cmd.Parameters.AddWithValue("MarketType", (int)Dictionary.DMSMarketType.Mall);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oMarket = new Market();
                    oMarket.MarketID = (int)reader["MarketID"];                 
                    oMarket.MarketName = (string)reader["MarketName"];
                    InnerList.Add(oMarket);
                }
                reader.Close();

                oMarket = new Market();
                oMarket.MarketID = -1;
                oMarket.MarketName = "Select Mall";

                InnerList.Add(oMarket);

                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

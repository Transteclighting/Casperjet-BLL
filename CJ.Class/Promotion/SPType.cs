// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Oct 23, 2014
// Time :  03:22 PM
// Description: Class for Sales promotion Type.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Promotion
{
    public class SPType
    {
        private int _nSalesPromotionID;
        private int _nSalesPromotionTypeID;

        /// <summary>
        /// Get set property for SalesPromotionID
        /// </summary>
        public int SalesPromotionID
        {
            get { return _nSalesPromotionID; }
            set { _nSalesPromotionID = value; }
        }

        /// <summary>
        /// Get set property for SalesPromotionTypeID
        /// </summary>
        public int SalesPromotionTypeID
        {
            get { return _nSalesPromotionTypeID; }
            set { _nSalesPromotionTypeID = value; }
        }
        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_SalesPromoType VALUES(?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("SalesPromotionTypeID", _nSalesPromotionTypeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertConsumerPromotionType()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_PromoCPType VALUES(?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ConsumerPromoID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("ConsumerPromoTypeID", _nSalesPromotionTypeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertTPType()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_PromoTPType VALUES(?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TradePromoID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("TradePromoTypeID", _nSalesPromotionTypeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertTPTypeSecondary()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_PromoTPTypeSecondary VALUES(?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TradePromoID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("TradePromoTypeID", _nSalesPromotionTypeID);

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
                sSql = "DELETE FROM t_SalesPromoType WHERE SalesPromotionID=? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
    public class SPTypes : CollectionBase
    {
        public SPType this[int i]
        {
            get { return (SPType)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SPType oSPType)
        {
            InnerList.Add(oSPType);
        }
        public void Refresh(int nSalesPromotionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesPromoType where  SalesPromotionID=?";
            cmd.Parameters.AddWithValue("SalesPromotionID", nSalesPromotionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPType oSPType = new SPType();

                    oSPType.SalesPromotionTypeID = int.Parse(reader["SalesPromotionTypeID"].ToString());
                    InnerList.Add(oSPType);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(int nPromoID, string sTablename)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sTablename == "t_PromoCP")
            {
                sSql = " select * from t_PromoCPType where  ConsumerPromoID=" + nPromoID + "";
            }
            if (sTablename == "t_PromoTP")
            {
                sSql = " select * from t_PromoTPType where  TradePromoID=" + nPromoID + "";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPType oSPType = new SPType();
                    if (sTablename == "t_PromoCP")
                    {
                        oSPType.SalesPromotionID = int.Parse(reader["ConsumerPromoID"].ToString());
                        oSPType.SalesPromotionTypeID = int.Parse(reader["ConsumerPromoTypeID"].ToString());
                    }
                    if (sTablename == "t_PromoTP")
                    {
                        oSPType.SalesPromotionID = int.Parse(reader["TradePromoID"].ToString());
                        oSPType.SalesPromotionTypeID = int.Parse(reader["TradePromoTypeID"].ToString());
                    }

                    InnerList.Add(oSPType);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetPromoType(string sPromoID, string sTablename)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sTablename == "t_PromoCP")
            {
                sSql = " select * from t_PromoCPType where  ConsumerPromoID in (" + sPromoID + ")";
            }
            if (sTablename == "t_PromoTP")
            {
                sSql = " select * from t_PromoTPType where  TradePromoID in (" + sPromoID + ")";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPType oSPType = new SPType();
                    if (sTablename == "t_PromoCP")
                    {
                        oSPType.SalesPromotionID = int.Parse(reader["ConsumerPromoID"].ToString());
                        oSPType.SalesPromotionTypeID = int.Parse(reader["ConsumerPromoTypeID"].ToString());
                    }
                    if (sTablename == "t_PromoTP")
                    {
                        oSPType.SalesPromotionID = int.Parse(reader["TradePromoID"].ToString());
                        oSPType.SalesPromotionTypeID = int.Parse(reader["TradePromoTypeID"].ToString());
                    }

                    InnerList.Add(oSPType);
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


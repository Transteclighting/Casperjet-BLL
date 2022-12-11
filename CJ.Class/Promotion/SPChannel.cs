// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Dec 28, 2011
// Time :  03:00 PM
// Description: Class for Promotion.
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
    public class SPChannel
    {
        private int _nSalesPromotionID;
        private int _nChannelID;
        private string _sCustType;
        public string CustType
        {
            get { return _sCustType; }
            set { _sCustType = value; }
        }
        /// <summary>
        /// Get set property for SalesPromotionID
        /// </summary>
        public int SalesPromotionID
        {
            get { return _nSalesPromotionID; }
            set { _nSalesPromotionID = value; }
        }

        /// <summary>
        /// Get set property for ChannelID
        /// </summary>
        public int ChannelID
        {
            get { return _nChannelID; }
            set { _nChannelID = value; }
        }

        private string _sChannelName;

        public string ChannelName
        {
            get { return _sChannelName; }
            set { _sChannelName = value.Trim(); }
        }
        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_SalesPromoChannel VALUES(?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("ChannelID", _nChannelID);
              
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertConsumerPromoChannel()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_PromoCPSalesType (ConsumerPromoID,SalesType,CustType) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ConsumerPromoID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("SalesType", _nChannelID);
                if (_sCustType == "-1")
                    cmd.Parameters.AddWithValue("CustType", null);
                else cmd.Parameters.AddWithValue("CustType", _sCustType);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertScratchCardOfferChannel()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_ScratchCardOfferSalesType (ScratchCardOfferID,SalesType,CustType) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ScratchCardOfferID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("SalesType", _nChannelID);
                if (_sCustType == "-1")
                    cmd.Parameters.AddWithValue("CustType", null);
                else cmd.Parameters.AddWithValue("CustType", _sCustType);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertTPChannel()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_PromoTPSalesType (TradePromoID,SalesType,CustType) VALUES (?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TradePromoID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("SalesType", _nChannelID);
                if (_sCustType == "-1")
                    cmd.Parameters.AddWithValue("CustType", null);
                else cmd.Parameters.AddWithValue("CustType", _sCustType);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void InsertTPChannelSecondary()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_PromoTPSalesTypeSecondary (TradePromoID,SalesType,CustType) VALUES (?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TradePromoID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("SalesType", _nChannelID);
                if (_sCustType == "-1")
                    cmd.Parameters.AddWithValue("CustType", null);
                else cmd.Parameters.AddWithValue("CustType", _sCustType);

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
                sSql = "DELETE FROM t_SalesPromoChannel WHERE SalesPromotionID=? ";
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
    public class SPChannels : CollectionBase
    {
        public SPChannel this[int i]
        {
            get { return (SPChannel)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SPChannel oSPChannel)
        {
            InnerList.Add(oSPChannel);
        }
        public void Refresh(int nSalesPromotionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesPromoChannel where  SalesPromotionID=?";
            cmd.Parameters.AddWithValue("SalesPromotionID", nSalesPromotionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPChannel oSPChannel=new SPChannel();
                    oSPChannel.ChannelID = int.Parse(reader["ChannelID"].ToString());
                    InnerList.Add(oSPChannel);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetPromoChannel(int nConsumerPromotionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From dbo.t_PromoCPSalesType where ConsumerPromoID=" + nConsumerPromotionID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPChannel oSPChannel = new SPChannel();
                    oSPChannel.ChannelID = (int)reader["SalesType"];
                    if (reader["CustType"] != DBNull.Value)
                    {
                        //oSPChannel.CustType = (string)reader["CustType"];
                        oSPChannel.CustType = (string)reader["CustType"];
                    }
                    else
                    {
                        oSPChannel.CustType = "";
                    }
                    InnerList.Add(oSPChannel);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetPromoChannelTP(int nConsumerPromotionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From dbo.t_PromoTPSalesType where TradePromoID=" + nConsumerPromotionID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPChannel oSPChannel = new SPChannel();
                    oSPChannel.ChannelID = (int)reader["SalesType"];
                    if (reader["CustType"] != DBNull.Value)
                    {
                        //oSPChannel.CustType = (string)reader["CustType"];
                        oSPChannel.CustType = (string)reader["CustType"];
                    }
                    else
                    {
                        oSPChannel.CustType = "";
                    }
                    InnerList.Add(oSPChannel);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetPromoChannelTPSecondary(int nConsumerPromotionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From dbo.t_PromoTPSalesTypeSecondary where TradePromoID=" + nConsumerPromotionID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPChannel oSPChannel = new SPChannel();
                    oSPChannel.ChannelID = (int)reader["SalesType"];
                    if (reader["CustType"] != DBNull.Value)
                    {
                        //oSPChannel.CustType = (string)reader["CustType"];
                        oSPChannel.CustType = (string)reader["CustType"];
                    }
                    else
                    {
                        oSPChannel.CustType = "";
                    }
                    InnerList.Add(oSPChannel);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetTPChannel(int nConsumerPromotionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From dbo.t_PromoTPSalesType where TradePromoID=" + nConsumerPromotionID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPChannel oSPChannel = new SPChannel();
                    oSPChannel.ChannelID = (int)reader["SalesType"];
                    InnerList.Add(oSPChannel);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh(int nPromoID,string sTablename)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sTablename == "t_PromoCP")
            {
                sSql = " select * from t_PromoCPSalesType where  ConsumerPromoID=" + nPromoID + "";
            }
            if (sTablename == "t_PromoTP")
            {
                sSql = " select * from t_PromoTPSalesType where  TradePromoID=" + nPromoID + "";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPChannel oSPChannel = new SPChannel();
                    if (sTablename == "t_PromoCP")
                    {
                        oSPChannel.SalesPromotionID = int.Parse(reader["ConsumerPromoID"].ToString());
                    }
                    if (sTablename == "t_PromoTP")
                    {
                        oSPChannel.SalesPromotionID = int.Parse(reader["TradePromoID"].ToString());
                    }
                    oSPChannel.ChannelID = int.Parse(reader["SalesType"].ToString());
                    
                    if (reader["CustType"] != DBNull.Value)
                    {
                        oSPChannel.CustType = reader["CustType"].ToString();
                    }
                    else oSPChannel.CustType = "-1";

                    InnerList.Add(oSPChannel);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetPromoSalesType(string sPromoID, string sTablename)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sTablename == "t_PromoCP")
            {
                sSql = " select * from t_PromoCPSalesType where  ConsumerPromoID in (" + sPromoID + ")";
            }
            if (sTablename == "t_PromoTP")
            {
                sSql = " select * from t_PromoTPSalesType where  TradePromoID in (" + sPromoID + ")";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPChannel oSPChannel = new SPChannel();
                    if (sTablename == "t_PromoCP")
                    {
                        oSPChannel.SalesPromotionID = int.Parse(reader["ConsumerPromoID"].ToString());
                    }
                    if (sTablename == "t_PromoTP")
                    {
                        oSPChannel.SalesPromotionID = int.Parse(reader["TradePromoID"].ToString());
                    }
                    oSPChannel.ChannelID = int.Parse(reader["SalesType"].ToString());

                    if (reader["CustType"] != DBNull.Value)
                    {
                        oSPChannel.CustType = reader["CustType"].ToString();
                    }
                    else oSPChannel.CustType = "-1";

                    InnerList.Add(oSPChannel);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetScratchCardOfferSalesType(string sPromoID, string sTablename)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (sTablename == "t_ScratchCardOffer")
            {
                sSql = " select * from t_ScratchCardOfferSalesType where  ScratchCardOfferID in (" + sPromoID + ")";
            }
           
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPChannel oSPChannel = new SPChannel();
                    if (sTablename == "t_ScratchCardOffer")
                    {
                        oSPChannel.SalesPromotionID = int.Parse(reader["ScratchCardOfferID"].ToString());
                    }
                  
                    oSPChannel.ChannelID = int.Parse(reader["SalesType"].ToString());

                    if (reader["CustType"] != DBNull.Value)
                    {
                        oSPChannel.CustType = reader["CustType"].ToString();
                    }
                    else oSPChannel.CustType = "-1";

                    InnerList.Add(oSPChannel);
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

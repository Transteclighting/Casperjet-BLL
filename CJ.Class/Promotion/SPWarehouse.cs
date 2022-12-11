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
    public class SPWarehouse
    {
        private int _nSalesPromotionID;
        private int _nWarehouseID;


        /// <summary>
        /// Get set property for SalesPromotionID
        /// </summary>
        public int SalesPromotionID
        {
            get { return _nSalesPromotionID; }
            set { _nSalesPromotionID = value; }
        }

        /// <summary>
        /// Get set property for WarehouseID
        /// </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }
        private string _sWarehouseName;

        public string WarehouseName
        {
            get { return _sWarehouseName; }
            set { _sWarehouseName = value.Trim(); }
        }
        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_SalesPromoWarehouse VALUES(?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SalesPromotionID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertConsumerPromoWarehouse()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_PromoCPWarehouse VALUES(?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ConsumerPromoID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertScratchCardOfferWarehouse()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_ScratchCardOfferWarehouse VALUES(?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ScratchCardOfferID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertTPWarehouse()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_PromoTPWarehouse VALUES(?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TradePromoID", _nSalesPromotionID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);

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
                sSql = "DELETE FROM t_SalesPromoWarehouse WHERE SalesPromotionID=? ";
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
    public class SPWarehouses : CollectionBase
    {
        public SPWarehouse this[int i]
        {
            get { return (SPWarehouse)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SPWarehouse oSPWarehouse)
        {
            InnerList.Add(oSPWarehouse);
        }
        public void Refresh(int nSalesPromotionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesPromoWarehouse where  SalesPromotionID=?";
            cmd.Parameters.AddWithValue("SalesPromotionID", nSalesPromotionID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPWarehouse oSPWarehouse = new SPWarehouse();
                    oSPWarehouse.WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    InnerList.Add(oSPWarehouse);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetPromoWarehouse(int nSalesPromotionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From t_PromoCPWarehouse a,t_Showroom b where a.WarehouseID=b.WarehouseID and ConsumerPromoID=" + nSalesPromotionID + " and IsPosActive=1";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPWarehouse oSPWarehouse = new SPWarehouse();
                    oSPWarehouse.WarehouseName = (string)reader["ShowroomCode"];
                    oSPWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(oSPWarehouse);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetPromoCPandSimpleWarehouse(string sWarehouse)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From t_Showroom where WarehouseID in (" + sWarehouse + ") and IsPosActive=1";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPWarehouse oSPWarehouse = new SPWarehouse();
                    oSPWarehouse.WarehouseName = (string)reader["ShowroomCode"];
                    oSPWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(oSPWarehouse);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetTPWarehouse(int nSalesPromotionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From t_PromoTPWarehouse a,t_Showroom b where a.WarehouseID=b.WarehouseID and TradePromoID=" + nSalesPromotionID + " and IsPosActive=1";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPWarehouse oSPWarehouse = new SPWarehouse();
                    oSPWarehouse.WarehouseName = (string)reader["ShowroomCode"];
                    oSPWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(oSPWarehouse);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetExchangeWarehouse(int nOfferId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select ShowroomCode,WarehouseID From t_PromoExchangeOfferDetails a,t_Showroom b where a.DataId=b.WarehouseID and OfferId=" + nOfferId + "  and DataType=2 and IsPosActive=1";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPWarehouse oSPWarehouse = new SPWarehouse();
                    oSPWarehouse.WarehouseName = (string)reader["ShowroomCode"];
                    oSPWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(oSPWarehouse);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetScratchCardOfferWarehouse(int nSalesPromotionID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From t_ScratchCardOfferWarehouse a,t_Showroom b where a.WarehouseID=b.WarehouseID and ScratchCardOfferID=" + nSalesPromotionID + " and IsPosActive=1";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPWarehouse oSPWarehouse = new SPWarehouse();
                    oSPWarehouse.WarehouseName = (string)reader["ShowroomCode"];
                    oSPWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(oSPWarehouse);
                }

                reader.Close();
                InnerList.TrimToSize();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GetWarehouse()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select WarehouseID From t_Showroom Where IsPosActive=1";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SPWarehouse oSPWarehouse = new SPWarehouse();
                    oSPWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    InnerList.Add(oSPWarehouse);
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

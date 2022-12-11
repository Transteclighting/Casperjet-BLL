// <summary>
// Company: Transcom Electronics Limited
// Author: Zahid Hasan
// Date: May 29, 2021
// Time : 01:19 PM
// Description: Class for ExchangeOfferDetails.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Promotion
{
    public class ExchangeOfferDetails
    {
        private int _nOfferDetailsId;
        private int _nOfferId;
        private int _nDataType;
        private int _nDataId;


        // <summary>
        // Get set property for OfferDetailsId
        // </summary>
        public int OfferDetailsId
        {
            get { return _nOfferDetailsId; }
            set { _nOfferDetailsId = value; }
        }

        // <summary>
        // Get set property for OfferId
        // </summary>
        public int OfferId
        {
            get { return _nOfferId; }
            set { _nOfferId = value; }
        }

        // <summary>
        // Get set property for DataType
        // </summary>
        public int DataType
        {
            get { return _nDataType; }
            set { _nDataType = value; }
        }

        // <summary>
        // Get set property for DataId
        // </summary>
        public int DataId
        {
            get { return _nDataId; }
            set { _nDataId = value; }
        }

        public void Add()
        {
            int nMaxOfferDetailsId = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OfferDetailsId]) FROM t_PromoExchangeOfferDetails";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxOfferDetailsId = 1;
                }
                else
                {
                    nMaxOfferDetailsId = Convert.ToInt32(maxID) + 1;
                }
                _nOfferDetailsId = nMaxOfferDetailsId;
                sSql = "INSERT INTO t_PromoExchangeOfferDetails (OfferDetailsId, OfferId, DataType, DataId) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OfferDetailsId", _nOfferDetailsId);
                cmd.Parameters.AddWithValue("OfferId", _nOfferId);
                cmd.Parameters.AddWithValue("DataType", _nDataType);
                cmd.Parameters.AddWithValue("DataId", _nDataId);

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
                sSql = "UPDATE t_PromoExchangeOfferDetails SET OfferId = ?, DataType = ?, DataId = ? WHERE OfferDetailsId = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OfferId", _nOfferId);
                cmd.Parameters.AddWithValue("DataType", _nDataType);
                cmd.Parameters.AddWithValue("DataId", _nDataId);

                cmd.Parameters.AddWithValue("OfferDetailsId", _nOfferDetailsId);

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
                sSql = "DELETE FROM t_PromoExchangeOfferDetails WHERE [OfferDetailsId]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OfferDetailsId", _nOfferDetailsId);
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
                cmd.CommandText = "SELECT * FROM t_PromoExchangeOfferDetails where OfferDetailsId =?";
                cmd.Parameters.AddWithValue("OfferDetailsId", _nOfferDetailsId);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOfferDetailsId = (int)reader["OfferDetailsId"];
                    _nOfferId = (int)reader["OfferId"];
                    _nDataType = (int)reader["DataType"];
                    _nDataId = (int)reader["DataId"];
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
    public class ExchangeOfferDetailss : CollectionBase
    {
        public ExchangeOfferDetails this[int i]
        {
            get { return (ExchangeOfferDetails)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ExchangeOfferDetails oExchangeOfferDetails)
        {
            InnerList.Add(oExchangeOfferDetails);
        }
        public int GetIndex(int nOfferDetailsId)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].OfferDetailsId == nOfferDetailsId)
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
            string sSql = "SELECT * FROM t_PromoExchangeOfferDetails";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferDetails oExchangeOfferDetails = new ExchangeOfferDetails();
                    oExchangeOfferDetails.OfferDetailsId = (int)reader["OfferDetailsId"];
                    oExchangeOfferDetails.OfferId = (int)reader["OfferId"];
                    oExchangeOfferDetails.DataType = (int)reader["DataType"];
                    oExchangeOfferDetails.DataId = (int)reader["DataId"];
                    InnerList.Add(oExchangeOfferDetails);
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


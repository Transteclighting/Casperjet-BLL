// <summary>
// Company: Transcom Electronics Limited
// Author: Zahid Hasan
// Date: Jun 10, 2021
// Time : 12:55 PM
// Description: Class for PromoWarrantyDetail.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class PromoWarrantyDetailx
    {
        private int _nWarrantyDetailId;
        private int _nWarrantyId;
        private int _nProductId;


        // <summary>
        // Get set property for WarrantyDetailId
        // </summary>
        public int WarrantyDetailId
        {
            get { return _nWarrantyDetailId; }
            set { _nWarrantyDetailId = value; }
        }

        // <summary>
        // Get set property for WarrantyId
        // </summary>
        public int WarrantyId
        {
            get { return _nWarrantyId; }
            set { _nWarrantyId = value; }
        }

        // <summary>
        // Get set property for ProductId
        // </summary>
        public int ProductId
        {
            get { return _nProductId; }
            set { _nProductId = value; }
        }

        public void Add()
        {
            int nMaxWarrantyDetailId = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([WarrantyDetailId]) FROM t_PromoWarrantyDetail";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxWarrantyDetailId = 1;
                }
                else
                {
                    nMaxWarrantyDetailId = Convert.ToInt32(maxID) + 1;
                }
                _nWarrantyDetailId = nMaxWarrantyDetailId;
                sSql = "INSERT INTO t_PromoWarrantyDetail (WarrantyDetailId, WarrantyId, ProductId) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WarrantyDetailId", _nWarrantyDetailId);
                cmd.Parameters.AddWithValue("WarrantyId", _nWarrantyId);
                cmd.Parameters.AddWithValue("ProductId", _nProductId);

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
                sSql = "UPDATE t_PromoWarrantyDetail SET WarrantyId = ?, ProductId = ? WHERE WarrantyDetailId = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WarrantyId", _nWarrantyId);
                cmd.Parameters.AddWithValue("ProductId", _nProductId);

                cmd.Parameters.AddWithValue("WarrantyDetailId", _nWarrantyDetailId);

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
                sSql = "DELETE FROM t_PromoWarrantyDetail WHERE [WarrantyDetailId]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("WarrantyDetailId", _nWarrantyDetailId);
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
                cmd.CommandText = "SELECT * FROM t_PromoWarrantyDetail where WarrantyDetailId =?";
                cmd.Parameters.AddWithValue("WarrantyDetailId", _nWarrantyDetailId);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nWarrantyDetailId = (int)reader["WarrantyDetailId"];
                    _nWarrantyId = (int)reader["WarrantyId"];
                    _nProductId = (int)reader["ProductId"];
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
    public class PromoWarrantyDetails : CollectionBase
    {
        public PromoWarrantyDetail this[int i]
        {
            get { return (PromoWarrantyDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PromoWarrantyDetail oPromoWarrantyDetail)
        {
            InnerList.Add(oPromoWarrantyDetail);
        }
        public int GetIndex(int nWarrantyDetailId)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].WarrantyDetailId == nWarrantyDetailId)
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
            string sSql = "SELECT * FROM t_PromoWarrantyDetail";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoWarrantyDetail oPromoWarrantyDetail = new PromoWarrantyDetail();
                    oPromoWarrantyDetail.WarrantyDetailId = (int)reader["WarrantyDetailId"];
                    oPromoWarrantyDetail.WarrantyId = (int)reader["WarrantyId"];
                    oPromoWarrantyDetail.ProductId = (int)reader["ProductId"];
                    InnerList.Add(oPromoWarrantyDetail);
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


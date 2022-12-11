// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD. Abdul Hakim
// Date: Oct 23, 2014
// Time : 11:56 AM
// Description: Class for SalesPromotionType.
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
    public class SalesPromotionType
    {
        private int _nSalesPromotionTypeID;
        private string _sSalesPromotionTypeName;
        private int _nIsActive;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        int nCount = 0;

        // <summary>
        // Get set property for SalesPromotionTypeID
        // </summary>
        public int SalesPromotionTypeID
        {
            get { return _nSalesPromotionTypeID; }
            set { _nSalesPromotionTypeID = value; }
        }

        // <summary>
        // Get set property for SalesPromotionTypeName
        // </summary>
        public string SalesPromotionTypeName
        {
            get { return _sSalesPromotionTypeName; }
            set { _sSalesPromotionTypeName = value.Trim(); }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        public void Add()
        {
            int nMaxSalesPromotionTypeID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([SalesPromotionTypeID]) FROM t_SalesPromotionType";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSalesPromotionTypeID = 1;
                }
                else
                {
                    nMaxSalesPromotionTypeID = Convert.ToInt32(maxID) + 1;
                }

                if (_nSalesPromotionTypeID == 0)
                {
                    _nSalesPromotionTypeID = nMaxSalesPromotionTypeID;
                }

                sSql = "INSERT INTO t_SalesPromotionType (SalesPromotionTypeID, SalesPromotionTypeName, IsActive, CreateUserID, CreateDate) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SalesPromotionTypeID", _nSalesPromotionTypeID);
                cmd.Parameters.AddWithValue("SalesPromotionTypeName", _sSalesPromotionTypeName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

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
                sSql = "UPDATE t_SalesPromotionType SET SalesPromotionTypeName = ?, IsActive = ?, UpdateUserID = ?, UpdateDate = ? WHERE SalesPromotionTypeID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SalesPromotionTypeName", _sSalesPromotionTypeName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("SalesPromotionTypeID", _nSalesPromotionTypeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateForPOS()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_SalesPromotionType Set SalesPromotionTypeName=?,IsActive=?,CreateUserID=?,CreateDate=? Where SalesPromotionTypeID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SalesPromotionTypeName", _sSalesPromotionTypeName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("SalesPromotionTypeID", _nSalesPromotionTypeID);

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
                sSql = "DELETE FROM t_SalesPromotionType WHERE [SalesPromotionTypeID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SalesPromotionTypeID", _nSalesPromotionTypeID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckSalesPromotionType()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            nCount = 0;
            try
            {
                sSql = "Select * from t_SalesPromotionType Where SalesPromotionTypeID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SalesPromotionTypeID", _nSalesPromotionTypeID);
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                return true;
            else return false;
        }
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesPromotionType where SalesPromotionTypeID =?";
                cmd.Parameters.AddWithValue("SalesPromotionTypeID", _nSalesPromotionTypeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nSalesPromotionTypeID = (int)reader["SalesPromotionTypeID"];
                    _sSalesPromotionTypeName = (string)reader["SalesPromotionTypeName"];
                    _nIsActive = (int)reader["IsActive"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
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
    public class SalesPromotionTypes : CollectionBase
    {
        public SalesPromotionType this[int i]
        {
            get { return (SalesPromotionType)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SalesPromotionType oSalesPromotionType)
        {
            InnerList.Add(oSalesPromotionType);
        }
        public int GetIndex(int nSalesPromotionTypeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].SalesPromotionTypeID == nSalesPromotionTypeID)
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
            string sSql = "SELECT * FROM t_SalesPromotionType order by SalesPromotionTypeID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesPromotionType oSalesPromotionType = new SalesPromotionType();
                    oSalesPromotionType.SalesPromotionTypeID = (int)reader["SalesPromotionTypeID"];
                    oSalesPromotionType.SalesPromotionTypeName = (string)reader["SalesPromotionTypeName"];
                    oSalesPromotionType.IsActive = (int)reader["IsActive"];

                    InnerList.Add(oSalesPromotionType);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(int nIsActive)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_SalesPromotionType where IsActive=" + nIsActive + " order by SalesPromotionTypeID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesPromotionType oSalesPromotionType = new SalesPromotionType();
                    oSalesPromotionType.SalesPromotionTypeID = (int)reader["SalesPromotionTypeID"];
                    oSalesPromotionType.SalesPromotionTypeName = (string)reader["SalesPromotionTypeName"];
                    oSalesPromotionType.IsActive = (int)reader["IsActive"];

                    InnerList.Add(oSalesPromotionType);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetPromoTypePromoIDWise(int nConsumerPromoID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From dbo.t_PromoCPType a,t_SalesPromotionType b " +
                          "where a.ConsumerPromoTypeID=b.SalesPromotionTypeID and ConsumerPromoID=" + nConsumerPromoID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesPromotionType oSalesPromotionType = new SalesPromotionType();
                    oSalesPromotionType.SalesPromotionTypeName = (string)reader["SalesPromotionTypeName"];
                    InnerList.Add(oSalesPromotionType);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetTPTypePromoIDWise(int nConsumerPromoID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From dbo.t_PromoTPType a,t_SalesPromotionType b " +
                          "where a.TradePromoTypeID=b.SalesPromotionTypeID and TradePromoID=" + nConsumerPromoID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesPromotionType oSalesPromotionType = new SalesPromotionType();
                    oSalesPromotionType.SalesPromotionTypeName = (string)reader["SalesPromotionTypeName"];
                    InnerList.Add(oSalesPromotionType);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetTPTypePromoIDWiseSecondary(int nConsumerPromoID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From dbo.t_PromoTPTypeSecondary a,t_SalesPromotionType b " +
                          "where a.TradePromoTypeID=b.SalesPromotionTypeID and TradePromoID=" + nConsumerPromoID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesPromotionType oSalesPromotionType = new SalesPromotionType();
                    oSalesPromotionType.SalesPromotionTypeName = (string)reader["SalesPromotionTypeName"];
                    InnerList.Add(oSalesPromotionType);
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



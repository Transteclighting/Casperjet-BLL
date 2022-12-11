using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Promotion
{
    public class PromoDiscountContributor
    {
        private int _nDiscountContributorID;
        private string _sDiscountContributorName;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private string _sCreateUserName;

        // <summary>
        // Get set property for DiscountContributorID
        // </summary>
        public int DiscountContributorID
        {
            get { return _nDiscountContributorID; }
            set { _nDiscountContributorID = value; }
        }

        // <summary>
        // Get set property for DiscountContributorName
        // </summary>
        public string DiscountContributorName
        {
            get { return _sDiscountContributorName; }
            set { _sDiscountContributorName = value.Trim(); }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        public string CreateUserName
        {
            get { return _sCreateUserName; }
            set { _sCreateUserName = value.Trim(); }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        public void Add()
        {
            int nMaxDiscountSharingTypeID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([DiscountContributorID]) FROM t_PromoDiscountContributor";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxDiscountSharingTypeID = 1;
                }
                else
                {
                    nMaxDiscountSharingTypeID = Convert.ToInt32(maxID) + 1;
                }
                _nDiscountContributorID = nMaxDiscountSharingTypeID;
                sSql = "INSERT INTO t_PromoDiscountContributor (DiscountContributorID, DiscountContributorName, CreateUserID, CreateDate) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DiscountContributorID", _nDiscountContributorID);
                cmd.Parameters.AddWithValue("DiscountContributorName", _sDiscountContributorName);
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
                sSql = "UPDATE t_PromoDiscountContributor SET DiscountContributorName = ?, CreateUserID = ?, CreateDate = ? WHERE DiscountContributorID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DiscountContributorName", _sDiscountContributorName);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("DiscountContributorID", _nDiscountContributorID);

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
                sSql = "DELETE FROM t_PromoDiscountContributor WHERE [DiscountContributorID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DiscountContributorID", _nDiscountContributorID);
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
                cmd.CommandText = "SELECT * FROM t_PromoDiscountContributor where DiscountContributorID =?";
                cmd.Parameters.AddWithValue("DiscountContributorID", _nDiscountContributorID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nDiscountContributorID = (int)reader["DiscountContributorID"];
                    _sDiscountContributorName = (string)reader["DiscountContributorName"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
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
    public class PromoDiscountContributors : CollectionBase
    {
        public PromoDiscountContributor this[int i]
        {
            get { return (PromoDiscountContributor)InnerList[i]; }
            set { InnerList[i] = value; }
        } 
        public void Add(PromoDiscountContributor oConsumerPromotionDiscountSharingType)
        {
            InnerList.Add(oConsumerPromotionDiscountSharingType);
        }
        public int GetIndex(int nDiscountSharingTypeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].DiscountContributorID == nDiscountSharingTypeID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(string DiscountContributorName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select c.*, u.UserName From t_PromoDiscountContributor c, t_user u  where u.UserID = c.CreateUserID";

            if (!string.IsNullOrEmpty(DiscountContributorName))
            {
                sSql = sSql + " and c.DiscountContributorName like '%" + DiscountContributorName + "%'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   PromoDiscountContributor oConsumerPromotionDiscountSharingType = new PromoDiscountContributor();
                    oConsumerPromotionDiscountSharingType.DiscountContributorID = (int)reader["DiscountContributorID"];
                    oConsumerPromotionDiscountSharingType.DiscountContributorName = (string)reader["DiscountContributorName"];
                    //oConsumerPromotionDiscountSharingType.CreateUserID = (int)reader["CreateUserID"];
                    oConsumerPromotionDiscountSharingType.CreateUserName = (string)reader["UserName"];
                    oConsumerPromotionDiscountSharingType.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oConsumerPromotionDiscountSharingType);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * From t_PromoDiscountContributor order by DiscountContributorName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   PromoDiscountContributor oConsumerPromotionDiscountSharingType = new PromoDiscountContributor();
                    oConsumerPromotionDiscountSharingType.DiscountContributorID = (int)reader["DiscountContributorID"];
                    oConsumerPromotionDiscountSharingType.DiscountContributorName = (string)reader["DiscountContributorName"];
                    InnerList.Add(oConsumerPromotionDiscountSharingType);
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




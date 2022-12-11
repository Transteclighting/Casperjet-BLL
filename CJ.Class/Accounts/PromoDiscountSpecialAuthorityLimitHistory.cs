// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Mar 02, 2019
// Time : 01:23 PM
// Description: Class for PromoDiscountSpecialAuthorityLimitHistory.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Accounts
{
    public class PromoDiscountSpecialAuthorityLimitHistory
    {
        private int _nID;
        private int _nAuthorityID;
        private int _nLimitID;
        private double _Limit;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private string _sRemarks;
        private string _sUserName;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for AuthorityID
        // </summary>
        public int AuthorityID
        {
            get { return _nAuthorityID; }
            set { _nAuthorityID = value; }
        }

        public int LimitID
        {
            get { return _nLimitID; }
            set { _nLimitID = value; }
        }

        // <summary>
        // Get set property for Limit
        // </summary>
        public double Limit
        {
            get { return _Limit; }
            set { _Limit = value; }
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
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }
        public string UserName
        {
            get { return _sUserName; }
            set { _sUserName = value.Trim(); }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_PromoDiscountSpecialAuthorityLimitHistory";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = Convert.ToInt32(maxID) + 1;
                }
                _nID = nMaxID;
                sSql = "INSERT INTO t_PromoDiscountSpecialAuthorityLimitHistory (ID, AuthorityID, LimitID, Limit, CreateUserID, CreateDate, Remarks) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("AuthorityID", _nAuthorityID);
                cmd.Parameters.AddWithValue("LimitID", _nLimitID);
                cmd.Parameters.AddWithValue("Limit", _Limit);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

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
                sSql = "UPDATE t_PromoDiscountSpecialAuthorityLimitHistory SET AuthorityID = ?, LimitID=?, Limit = ?, CreateUserID = ?, CreateDate = ?, Remarks = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AuthorityID", _nAuthorityID);
                cmd.Parameters.AddWithValue("LimitID", _nLimitID);
                cmd.Parameters.AddWithValue("Limit", _Limit);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "DELETE FROM t_PromoDiscountSpecialAuthorityLimitHistory WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
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
                cmd.CommandText = "SELECT * FROM t_PromoDiscountSpecialAuthorityLimitHistory where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nAuthorityID = (int)reader["AuthorityID"];
                    _Limit = Convert.ToDouble(reader["Limit"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _sRemarks = (string)reader["Remarks"];
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
    public class PromoDiscountSpecialAuthorityLimitHistorys : CollectionBase
    {
        public PromoDiscountSpecialAuthorityLimitHistory this[int i]
        {
            get { return (PromoDiscountSpecialAuthorityLimitHistory)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PromoDiscountSpecialAuthorityLimitHistory oPromoDiscountSpecialAuthorityLimitHistory)
        {
            InnerList.Add(oPromoDiscountSpecialAuthorityLimitHistory);
        }
        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
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
            string sSql = "SELECT * FROM t_PromoDiscountSpecialAuthorityLimitHistory";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoDiscountSpecialAuthorityLimitHistory oPromoDiscountSpecialAuthorityLimitHistory = new PromoDiscountSpecialAuthorityLimitHistory();
                    oPromoDiscountSpecialAuthorityLimitHistory.ID = (int)reader["ID"];
                    oPromoDiscountSpecialAuthorityLimitHistory.AuthorityID = (int)reader["AuthorityID"];
                    oPromoDiscountSpecialAuthorityLimitHistory.Limit = Convert.ToDouble(reader["Limit"].ToString());
                    oPromoDiscountSpecialAuthorityLimitHistory.CreateUserID = (int)reader["CreateUserID"];
                    oPromoDiscountSpecialAuthorityLimitHistory.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPromoDiscountSpecialAuthorityLimitHistory.Remarks = (string)reader["Remarks"];
                    InnerList.Add(oPromoDiscountSpecialAuthorityLimitHistory);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshBySpecialDiscountLimitHistory(DateTime dtDate,int nAuthorityID)
        {
            int nYear = dtDate.Year;
            int nMonth= dtDate.Month;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.AuthorityID,Limit,a.CreateUserID,a.CreateDate,a.Remarks,UserName from t_PromoDiscountSpecialAuthorityLimitHistory a,t_PromoDiscountSpecialAuthority b,t_User c where a.AuthorityID=b.AuthorityID and a.CreateUserID=c.UserID and Year(a.CreateDate)="+nYear+" and Month(a.CreateDate)="+nMonth+ " and a.AuthorityID="+nAuthorityID+"";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoDiscountSpecialAuthorityLimitHistory oPromoDiscountSpecialAuthorityLimitHistory = new PromoDiscountSpecialAuthorityLimitHistory();
                    //oPromoDiscountSpecialAuthorityLimitHistory.ID = (int)reader["ID"];
                    oPromoDiscountSpecialAuthorityLimitHistory.AuthorityID = (int)reader["AuthorityID"];
                    oPromoDiscountSpecialAuthorityLimitHistory.Limit = Convert.ToDouble(reader["Limit"].ToString());
                    oPromoDiscountSpecialAuthorityLimitHistory.CreateUserID = (int)reader["CreateUserID"];
                    oPromoDiscountSpecialAuthorityLimitHistory.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPromoDiscountSpecialAuthorityLimitHistory.Remarks = (string)reader["Remarks"];
                    oPromoDiscountSpecialAuthorityLimitHistory.UserName= (string)reader["UserName"];
                    InnerList.Add(oPromoDiscountSpecialAuthorityLimitHistory);
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



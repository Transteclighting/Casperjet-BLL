// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Mar 02, 2019
// Time : 01:20 PM
// Description: Class for PromoDiscountSpecialAuthorityLimit.
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
    public class PromoDiscountSpecialAuthorityLimit
    {
        private int _nID;
        private int _nAuthorityID;
        private double _Limit;
        private double _Discount;
        private double _AvailableLimit;
        private int _nTMonth;
        private int _nTYear;

        private string _sEmployeeName;
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }
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

        // <summary>
        // Get set property for Limit
        // </summary>
        public double Limit
        {
            get { return _Limit; }
            set { _Limit = value; }
        }

        // <summary>
        // Get set property for Discount
        // </summary>
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        public double AvailableLimit
        {
            get { return _AvailableLimit; }
            set { _AvailableLimit = value; }
        }

        // <summary>
        // Get set property for TMonth
        // </summary>
        public int TMonth
        {
            get { return _nTMonth; }
            set { _nTMonth = value; }
        }

        // <summary>
        // Get set property for TYear
        // </summary>
        public int TYear
        {
            get { return _nTYear; }
            set { _nTYear = value; }
        }

        public void Add(DateTime dtDate)
        {
            int nYear = dtDate.Year;
            int nMonth = dtDate.Month;
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_PromoDiscountSpecialAuthorityLimit";
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
                sSql = "INSERT INTO t_PromoDiscountSpecialAuthorityLimit (ID, AuthorityID, Limit, Discount, TMonth, TYear) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("AuthorityID", _nAuthorityID);
                cmd.Parameters.AddWithValue("Limit", _Limit);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("TMonth", nMonth);
                cmd.Parameters.AddWithValue("TYear", nYear);

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
                sSql = "UPDATE t_PromoDiscountSpecialAuthorityLimit SET AuthorityID = ?, Limit = ?, Discount = ?, TMonth = ?, TYear = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AuthorityID", _nAuthorityID);
                cmd.Parameters.AddWithValue("Limit", _Limit);
                cmd.Parameters.AddWithValue("Discount", _Discount);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("TYear", _nTYear);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateLimit(int nAuthorityID,DateTime dtDate)
        {
            int nYear = dtDate.Year;
            int nMonth = dtDate.Month;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PromoDiscountSpecialAuthorityLimit SET Limit = Limit + ? WHERE AuthorityID = ? and TYear="+nYear+" and TMonth="+nMonth+"";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Limit", _Limit);
                cmd.Parameters.AddWithValue("AuthorityID", nAuthorityID);

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
                sSql = "DELETE FROM t_PromoDiscountSpecialAuthorityLimit WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_PromoDiscountSpecialAuthorityLimit where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nAuthorityID = (int)reader["AuthorityID"];
                    _Limit = Convert.ToDouble(reader["Limit"].ToString());
                    _Discount = Convert.ToDouble(reader["Discount"].ToString());
                    _nTMonth = (int)reader["TMonth"];
                    _nTYear = (int)reader["TYear"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
       
        public bool CheckLimit(int nAuthorityID,DateTime dtDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            //int nMonth = DateTime.Now.Month;
            //int nYear = DateTime.Now.Year;
            int nYear = dtDate.Year;
            int nMonth = dtDate.Month;

            try
            {
                cmd.CommandText = "SELECT * FROM t_PromoDiscountSpecialAuthorityLimit where TMonth = "+ nMonth + " and TYear = "+ nYear + " and AuthorityID = "+ nAuthorityID + " ";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public class PromoDiscountSpecialAuthorityLimits : CollectionBase
    {
        public PromoDiscountSpecialAuthorityLimit this[int i]
        {
            get { return (PromoDiscountSpecialAuthorityLimit)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PromoDiscountSpecialAuthorityLimit oPromoDiscountSpecialAuthorityLimit)
        {
            InnerList.Add(oPromoDiscountSpecialAuthorityLimit);
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
            string sSql = "SELECT * FROM t_PromoDiscountSpecialAuthorityLimit";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoDiscountSpecialAuthorityLimit oPromoDiscountSpecialAuthorityLimit = new PromoDiscountSpecialAuthorityLimit();
                    oPromoDiscountSpecialAuthorityLimit.ID = (int)reader["ID"];
                    oPromoDiscountSpecialAuthorityLimit.AuthorityID = (int)reader["AuthorityID"];
                    oPromoDiscountSpecialAuthorityLimit.Limit = Convert.ToDouble(reader["Limit"].ToString());
                    oPromoDiscountSpecialAuthorityLimit.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    oPromoDiscountSpecialAuthorityLimit.TMonth = (int)reader["TMonth"];
                    oPromoDiscountSpecialAuthorityLimit.TYear = (int)reader["TYear"];
                    InnerList.Add(oPromoDiscountSpecialAuthorityLimit);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshBySpecialDiscountLimit(DateTime dtDate)
        {
            //DateTime dtDate = DateTime.Now;
            int nYear = dtDate.Year;
            int nMonth = dtDate.Month;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            //string sSql = @"Select ID,a.AuthorityID,EmployeeName,Limit from t_PromoDiscountSpecialAuthority a
            //                Left Outer Join t_PromoDiscountSpecialAuthorityLimit b on a.AuthorityID = b.AuthorityID
            //                where TYear = year(getdate()) and TMonth = DATEPART(MONTH, DATEADD(MONTH, 0, getdate()))
            //                order by a.AuthorityID";
            string sSql = "Select a.AuthorityID,EmployeeName,isnull(Limit,0)Limit,isnull(Discount,0)Discount from t_PromoDiscountSpecialAuthority a " +
                           "Left Outer Join (Select * from t_PromoDiscountSpecialAuthorityLimit where TYear="+ nYear + " and TMonth= " + nMonth + ") b " +
                           "on a.AuthorityID=b.AuthorityID order by Sort";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PromoDiscountSpecialAuthorityLimit oPromoDiscountSpecialAuthorityLimit = new PromoDiscountSpecialAuthorityLimit();
                    //oPromoDiscountSpecialAuthorityLimit.ID = (int)reader["ID"];
                    oPromoDiscountSpecialAuthorityLimit.AuthorityID = (int)reader["AuthorityID"];
                    oPromoDiscountSpecialAuthorityLimit.EmployeeName = (string)reader["EmployeeName"];
                    oPromoDiscountSpecialAuthorityLimit.Limit = Convert.ToDouble(reader["Limit"].ToString());
                    oPromoDiscountSpecialAuthorityLimit.Discount = Convert.ToDouble(reader["Discount"].ToString());
                    oPromoDiscountSpecialAuthorityLimit.AvailableLimit= Convert.ToDouble(reader["Limit"].ToString())- Convert.ToDouble(reader["Discount"].ToString());
                    InnerList.Add(oPromoDiscountSpecialAuthorityLimit);
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



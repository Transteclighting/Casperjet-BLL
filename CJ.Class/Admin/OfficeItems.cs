// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Jul 05, 2015
// Time : 12:04 PM
// Description: Class for OfficeItem.
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
    public class OfficeItem
    {
        private int _nID;
        private string _sCode;
        private string _sArticlesName;
        private int _nCategory;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private DateTime _dUpdateDate;
        private int _nUpdateUserID;
        private string _sCategoryName;
        private bool _bFlag;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for Code
        // </summary>
        public string Code
        {
            get { return _sCode; }
            set { _sCode = value.Trim(); }
        }

        // <summary>
        // Get set property for ArticlesName
        // </summary>
        public string ArticlesName
        {
            get { return _sArticlesName; }
            set { _sArticlesName = value.Trim(); }
        }

        // <summary>
        // Get set property for Category
        // </summary>
        public int Category
        {
            get { return _nCategory; }
            set { _nCategory = value; }
        }


        // <summary>
        // Get set property for CategoryName
        // </summary>
        public string CategoryName
        {
            get { return _sCategoryName; }
            set { _sCategoryName = value; }
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
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_OfficeItems";
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
                sSql = "INSERT INTO t_OfficeItems (ID, Code, ArticlesName, Category, CreateDate, CreateUserID) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("ArticlesName", _sArticlesName);
                cmd.Parameters.AddWithValue("Category", _nCategory);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);

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
                sSql = "UPDATE t_OfficeItems SET Code = ?, ArticlesName = ?, Category = ?, UpdateDate = ?, UpdateUserID = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.Parameters.AddWithValue("ArticlesName", _sArticlesName);
                cmd.Parameters.AddWithValue("Category", _nCategory);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);

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
                sSql = "DELETE FROM t_OfficeItems WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_OfficeItems where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sCode = (string)reader["Code"];
                    _sArticlesName = (string)reader["ArticlesName"];
                    _nCategory = (int)reader["Category"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByCode()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_OfficeItems where Code =?";
                cmd.Parameters.AddWithValue("Code", _sCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sCode = (string)reader["Code"];
                    _sArticlesName = (string)reader["ArticlesName"];
                    _nCategory = (int)reader["Category"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) _bFlag = true;
            else Flag = false;
        }
    }
    public class OfficeItems : CollectionBase
    {
        public OfficeItem this[int i]
        {
            get { return (OfficeItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OfficeItem oOfficeItem)
        {
            InnerList.Add(oOfficeItem);
        }
        public void GetData(int nCategory, string sCode, string sName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "select ID,Code,ArticlesName, Category, "+
                          "CategoryName=case when Category=1 then 'Stationary' when Category=2 then 'Toiletry'  "+
                          "when Category=3 then 'Other' else 'Others' end from t_OfficeItems where 1 = 1 ";

            if (nCategory > 0)
            {
                sSql = sSql + " and Category = " + nCategory + "";
            }

            if (sCode != "")
            {
                sSql = sSql + " and Code = " + sCode + "";
            }

            if (sName != "")
            {

                sSql = sSql + " and ArticlesName like '%" + sName + "%'";
            }

            sSql = sSql + " Order by ID";

            try
            {
                cmd.CommandText = sSql;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OfficeItem oItem = new OfficeItem();

                    oItem.ID = int.Parse(reader["ID"].ToString());
                    oItem.Code = reader["Code"].ToString();
                    oItem.ArticlesName = reader["ArticlesName"].ToString();
                    oItem.Category = int.Parse(reader["Category"].ToString());
                    oItem.CategoryName = reader["CategoryName"].ToString();

                    InnerList.Add(oItem);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void RefreshBySearch(int nCategory, string sCode, string sName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select ID,Code,ArticlesName, Category, "+
                          "CategoryName=case when Category=1 then 'Stationary' when Category=2 then 'Toiletry'  " +
                          "when Category=3 then 'Other' else 'Others' end from t_OfficeItems ";

            string sClause = "";

            if (nCategory >0)
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where Category =? ";
                    cmd.Parameters.AddWithValue("Category", nCategory);
                }
                else
                {
                    sClause = sClause + " AND Category = ? ";
                    cmd.Parameters.AddWithValue("Category", nCategory);
                }
            }
            if (sCode != "")
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where Code = ? ";
                    cmd.Parameters.AddWithValue("Code", sCode);
                }
                else
                {
                    sClause = sClause + " AND Code =? ";
                    cmd.Parameters.AddWithValue("Code", sCode);
                }
            }

            if (sName != "")
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "Where ArticlesName Like ? ";
                    cmd.Parameters.AddWithValue("ArticlesName", "%" + sName + "%");
                }
                else
                {
                    sClause = sClause + " AND ArticlesName Like ? ";
                    cmd.Parameters.AddWithValue("ArticlesName", "%" + sName + "%");
                }
            }

            try
            {
                cmd.CommandText = sSql + sClause;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OfficeItem oOfficeItem = new OfficeItem();
                    oOfficeItem.ID = (int)reader["ID"];
                    oOfficeItem.Code = (string)reader["Code"];
                    oOfficeItem.ArticlesName = (string)reader["ArticlesName"];
                    oOfficeItem.Category = (int)reader["Category"];

                    if (reader["CategoryName"] != DBNull.Value)
                        oOfficeItem.CategoryName = (string)reader["CategoryName"];
                    else oOfficeItem.CategoryName = "";
                    InnerList.Add(oOfficeItem);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
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
            string sSql = "SELECT * FROM t_OfficeItems";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OfficeItem oOfficeItem = new OfficeItem();
                    oOfficeItem.ID = (int)reader["ID"];
                    oOfficeItem.Code = (string)reader["Code"];
                    oOfficeItem.ArticlesName = (string)reader["ArticlesName"];
                    oOfficeItem.Category = (int)reader["Category"];
                    oOfficeItem.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oOfficeItem.CreateUserID = (int)reader["CreateUserID"];
                    InnerList.Add(oOfficeItem);
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


using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class ProductFeature
    {
        private int _nId;
        private int _nProductId;
        private string _sUrl;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private string _sProductCode;
        private string _sProductName;
        private string _sUserFullName;

        private string duplicateVale;


        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }

        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }

        public string UserFullName
        {
            get { return _sUserFullName; }
            set { _sUserFullName = value.Trim(); }
        }
        // <summary>
        // Get set property for Id
        // </summary>
        public int Id
        {
            get { return _nId; }
            set { _nId = value; }
        }

        // <summary>
        // Get set property for ProductId
        // </summary>
        public int ProductId
        {
            get { return _nProductId; }
            set { _nProductId = value; }
        }

        // <summary>
        // Get set property for Url
        // </summary>
        public string Url
        {
            get { return _sUrl; }
            set { _sUrl = value.Trim(); }
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
            int nMaxId = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([Id]) FROM t_ProductFeature";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxId = 1;
                }
                else
                {
                    nMaxId = Convert.ToInt32(maxID) + 1;
                }
                _nId = nMaxId;
                sSql = "INSERT INTO t_ProductFeature (Id, ProductId, Url, CreateUserID, CreateDate) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Id", _nId);
                cmd.Parameters.AddWithValue("ProductId", _nProductId);
                cmd.Parameters.AddWithValue("Url", _sUrl);
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
                sSql = "UPDATE t_ProductFeature SET ProductId = ?, Url = ?, UpdateUserID = ?, UpdateDate = ? WHERE Id = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductId", _nProductId);
                cmd.Parameters.AddWithValue("Url", _sUrl);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("Id", _nId);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public string CheckDuplicateData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            duplicateVale = "No";
            try
            {
                cmd.CommandText = "SELECT * FROM t_ProductFeature where ProductId =? and URL = ?";
                cmd.Parameters.AddWithValue("ProductId", _nProductId);
                cmd.Parameters.AddWithValue("Url", _sUrl);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    duplicateVale = "Yes";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return duplicateVale;
        }


        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_ProductFeature WHERE [Id]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Id", _nId);
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
                cmd.CommandText = "SELECT * FROM t_ProductFeature where Id =?";
                cmd.Parameters.AddWithValue("Id", _nId);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nId = (int)reader["Id"];
                    _nProductId = (int)reader["ProductId"];
                    _sUrl = (string)reader["Url"];
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
    public class ProductFeatures : CollectionBase
    {
        public ProductFeature this[int i]
        {
            get { return (ProductFeature)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ProductFeature oProductFeature)
        {
            InnerList.Add(oProductFeature);
        }
        public int GetIndex(int nId)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].Id == nId)
                {
                    return i;
                }
            }
            return -1;
        }
        public void GetProductFeature(string nProductCode)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT a.Id, a.ProductId, a.URL, b.ProductCode, b.ProductName, c.UserFullName, a.CreateDate FROM t_ProductFeature a inner join t_Product b on a.ProductId = b.ProductId left outer join t_User c on a.CreateUserID = c.UserID where 1=1";

            if (!string.IsNullOrEmpty(nProductCode))
            {
                sSql = sSql + " AND b.ProductCode like '%" + nProductCode + "%'";
            }


            sSql = sSql + " order by a.ProductId desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductFeature oProductFeature = new ProductFeature();
                    oProductFeature.Id = (int)reader["Id"];
                    oProductFeature.ProductId = (int)reader["ProductId"];
                    oProductFeature.Url = (string)reader["URL"];
                    oProductFeature.ProductCode = (string)reader["ProductCode"];
                    oProductFeature.ProductName = (string)reader["ProductName"];
                    if (reader["UserFullName"] != DBNull.Value)
                    oProductFeature.UserFullName = (string)reader["UserFullName"];

                    if (reader["CreateDate"] != DBNull.Value)
                        oProductFeature.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oProductFeature);
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



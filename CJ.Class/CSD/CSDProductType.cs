// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Dec 03, 2016
// Time : 10:06 AM
// Description: Class for CSDProductType.
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
    public class CSDProductType
    {
        private int _nProductTypeID;
        private string _sProductTypeName;
        private int _nPrefix;
        private int _nWorkshopTypeID;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        public string _sWorkshopTypeName;




        

        // <summary>
        // Get set property for ProductTypeID
        // </summary>
        public int ProductTypeID
        {
            get { return _nProductTypeID; }
            set { _nProductTypeID = value; }
        }

        // <summary>
        // Get set property for ProductTypeName
        // </summary>
        public string ProductTypeName
        {
            get { return _sProductTypeName; }
            set { _sProductTypeName = value.Trim(); }
        }

        // <summary>
        // Get set property for Prefix
        // </summary>
        public int Prefix
        {
            get { return _nPrefix; }
            set { _nPrefix = value; }
        }

        // <summary>
        // Get set property for WorkshopTypeID
        // </summary>
        public int WorkshopTypeID
        {
            get { return _nWorkshopTypeID; }
            set { _nWorkshopTypeID = value; }
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
        // <summary>
        // Get set property for WorkshopTypeName
        // </summary>
        public string WorkshopTypeName
        {
            get { return _sWorkshopTypeName; }
            set { _sWorkshopTypeName = value; }
        }
        public void Add()
        {
            int nMaxProductTypeID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ProductTypeID]) FROM t_CSDProductType";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxProductTypeID = 1;
                }
                else
                {
                    nMaxProductTypeID = Convert.ToInt32(maxID) + 1;
                }
                _nProductTypeID = nMaxProductTypeID;
                sSql = "INSERT INTO t_CSDProductType (ProductTypeID, ProductTypeName, Prefix, WorkshopTypeID, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductTypeID", _nProductTypeID);
                cmd.Parameters.AddWithValue("ProductTypeName", _sProductTypeName);
                cmd.Parameters.AddWithValue("Prefix", _nPrefix);
                cmd.Parameters.AddWithValue("WorkshopTypeID", _nWorkshopTypeID);
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
                sSql = "UPDATE t_CSDProductType SET ProductTypeName = ?, Prefix = ?, WorkshopTypeID = ?, UpdateUserID = ?, UpdateDate = ? WHERE ProductTypeID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductTypeName", _sProductTypeName);
                cmd.Parameters.AddWithValue("Prefix", _nPrefix);
                cmd.Parameters.AddWithValue("WorkshopTypeID", _nWorkshopTypeID);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("ProductTypeID", _nProductTypeID);

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
                sSql = "DELETE FROM t_CSDProductType WHERE [ProductTypeID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductTypeID", _nProductTypeID);
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
                cmd.CommandText = "SELECT * FROM t_CSDProductType where ProductTypeID =?";
                cmd.Parameters.AddWithValue("ProductTypeID", _nProductTypeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProductTypeID = (int)reader["ProductTypeID"];
                    _sProductTypeName = (string)reader["ProductTypeName"];
                    _nPrefix = (int)reader["Prefix"];
                    _nWorkshopTypeID = (int)reader["WorkshopTypeID"];
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
    public class CSDProductTypes : CollectionBase
    {
        public CSDProductType this[int i]
        {
            get { return (CSDProductType)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDProductType oCSDProductType)
        {
            InnerList.Add(oCSDProductType);
        }
        public int GetIndex(int nProductTypeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ProductTypeID == nProductTypeID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void RefreshForCombo()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CSDProductType";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDProductType oCSDProductType = new CSDProductType();
                    oCSDProductType.ProductTypeID = (int)reader["ProductTypeID"];
                    oCSDProductType.ProductTypeName = (string)reader["ProductTypeName"];
                    InnerList.Add(oCSDProductType);
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
            string sSql = "SELECT * FROM t_CSDProductType ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDProductType oCSDProductType = new CSDProductType();
                    oCSDProductType.ProductTypeID = (int)reader["ProductTypeID"];
                    oCSDProductType.ProductTypeName = (string)reader["ProductTypeName"];
                    oCSDProductType.Prefix = (int)reader["Prefix"];
                    oCSDProductType.WorkshopTypeID = (int)reader["WorkshopTypeID"];
                    oCSDProductType.CreateUserID = (int)reader["CreateUserID"];
                    oCSDProductType.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        oCSDProductType.UpdateUserID = (int)reader["UpdateUserID"];
                    }
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        oCSDProductType.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    }
                    InnerList.Add(oCSDProductType);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Getdata()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CSDProductType a INNER JOIN t_CSDWorkshopType b on a.WorkshopTypeID = b.WorkshopTypeID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDProductType oCSDProductType = new CSDProductType();
                    oCSDProductType.ProductTypeID = (int)reader["ProductTypeID"];
                    oCSDProductType.ProductTypeName = (string)reader["ProductTypeName"];
                    oCSDProductType.Prefix = (int)reader["Prefix"];
                    oCSDProductType.WorkshopTypeID = (int)reader["WorkshopTypeID"];
                    oCSDProductType.WorkshopTypeName = (string)reader["Name"];                    
                    oCSDProductType.CreateUserID = (int)reader["CreateUserID"];
                    oCSDProductType.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        oCSDProductType.UpdateUserID = (int)reader["UpdateUserID"];
                    }
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        oCSDProductType.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    }                    
                    InnerList.Add(oCSDProductType);
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


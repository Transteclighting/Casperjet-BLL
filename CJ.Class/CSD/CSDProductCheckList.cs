
// <summary>
// Company: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Dec 01, 2016
// Time : 01:55 PM
// Description: Class for CSDProductCheckList.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.CSD
{
    public class CSDProductCheckList
    {
        private int _nProductCheckListID;
        private int _nProductTypeID;
        private string _sDescription;
        private string _sCreatedBy;
        private DateTime _dtCreateDate;
        private string _sProductTypeName;

        


        // <summary>
        // Get set property for CreateDate
        // </summary>
        public string ProductTypeName
        {
            get { return _sProductTypeName; }
            set { _sProductTypeName = value; }
        }


        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dtCreateDate; }
            set { _dtCreateDate = value; }
        }

        // <summary>
        // Get set property for CreatedBy
        // </summary>
        public string CreatedBy
        {
            get { return _sCreatedBy; }
            set { _sCreatedBy = value.Trim(); }
        }

        // <summary>
        // Get set property for ProductCheckListID
        // </summary>
        public int ProductCheckListID
        {
            get { return _nProductCheckListID; }
            set { _nProductCheckListID = value; }
        }

        // <summary>
        // Get set property for ProductTypeID
        // </summary>
        public int ProductTypeID
        {
            get { return _nProductTypeID; }
            set { _nProductTypeID = value; }
        }

        // <summary>
        // Get set property for Description
        // </summary>
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }

        public void Add()
        {
            int nMaxProductCheckListID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ProductCheckListID]) FROM t_CSDProductCheckList";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxProductCheckListID = 1;
                }
                else
                {
                    nMaxProductCheckListID = Convert.ToInt32(maxID) + 1;
                }
                _nProductCheckListID = nMaxProductCheckListID;
                sSql = "INSERT INTO t_CSDProductCheckList (ProductCheckListID, ProductTypeID, Description) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductCheckListID", _nProductCheckListID);
                cmd.Parameters.AddWithValue("ProductTypeID", _nProductTypeID);
                cmd.Parameters.AddWithValue("Description", _sDescription);

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
                sSql = "UPDATE t_CSDProductCheckList SET ProductTypeID = ?, Description = ? WHERE ProductCheckListID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductTypeID", _nProductTypeID);
                cmd.Parameters.AddWithValue("Description", _sDescription);

                cmd.Parameters.AddWithValue("ProductCheckListID", _nProductCheckListID);

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
                sSql = "DELETE FROM t_CSDProductCheckList WHERE [ProductCheckListID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductCheckListID", _nProductCheckListID);
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
                cmd.CommandText = "SELECT * FROM t_CSDProductCheckList where ProductCheckListID =?";
                cmd.Parameters.AddWithValue("ProductCheckListID", _nProductCheckListID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProductCheckListID = (int)reader["ProductCheckListID"];
                    _nProductTypeID = (int)reader["ProductTypeID"];
                    _sDescription = (string)reader["Description"];
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
    public class CSDProductCheckLists : CollectionBase
    {
        public CSDProductCheckList this[int i]
        {
            get { return (CSDProductCheckList)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDProductCheckList oCSDProductCheckList)
        {
            InnerList.Add(oCSDProductCheckList);
        }
        public int GetIndex(int nProductCheckListID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ProductCheckListID == nProductCheckListID)
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

            string sSql = "SELECT * FROM t_CSDProductCheckList";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDProductCheckList oCSDProductCheckList = new CSDProductCheckList();

                    oCSDProductCheckList.ProductCheckListID = (int)reader["ProductCheckListID"];
                    oCSDProductCheckList.ProductTypeID = (int)reader["ProductTypeID"];
                    oCSDProductCheckList.Description = (string)reader["Description"];

                    InnerList.Add(oCSDProductCheckList);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void GedData(int nProductType, string sChecklistName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDProductCheckList a "+
            "INNER JOIN t_CSDProductType b on a.ProductTypeID= b.ProductTypeID "+
            "INNER JOIN dbo.t_User c on b.CreateUserID = c.UserID "+
            "WHERE 1=1 ";
            if (nProductType != -1)
            {
                sSql += " AND a.ProductTypeID = " + nProductType + " ";
            }
            if (sChecklistName != String.Empty)
            {
                sSql += " AND a.Description LIKE '%"+ sChecklistName + "%' ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDProductCheckList oCSDProductCheckList = new CSDProductCheckList();
                    oCSDProductCheckList.ProductCheckListID = (int)reader["ProductCheckListID"];
                    oCSDProductCheckList.ProductTypeID = (int)reader["ProductTypeID"];
                    oCSDProductCheckList.ProductTypeName = (string)reader["ProductTypeName"];
                    oCSDProductCheckList.Description = (string)reader["Description"];
                    oCSDProductCheckList.CreatedBy = (string)reader["UserFullName"];
                    oCSDProductCheckList.CreateDate = (DateTime)reader["CreateDate"];
                    InnerList.Add(oCSDProductCheckList);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetProductCheckList(int nProductTypeID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDProductCheckList Where ProductTypeID = " + nProductTypeID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDProductCheckList oCSDProductCheckList = new CSDProductCheckList();

                    oCSDProductCheckList.ProductCheckListID = (int)reader["ProductCheckListID"];
                    oCSDProductCheckList.ProductTypeID = (int)reader["ProductTypeID"];
                    oCSDProductCheckList.Description = (string)reader["Description"];

                    InnerList.Add(oCSDProductCheckList);
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



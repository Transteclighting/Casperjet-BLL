// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Dec 07, 2011
// Time :  10:00 AM
// Description: Class for Fixed Asset Type.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Admin
{
    public class FixedAssetType
    {
        private int _nFATypeID;
        private string _sFATypeCode;
        private string _sFATypeName;
        private string _sFATypeGroup;


        /// <summary>
        /// Get set property for FATypeID
        /// </summary>
        public int FATypeID
        {
            get { return _nFATypeID; }
            set { _nFATypeID = value; }
        }

        /// <summary>
        /// Get set property for FATypeCode
        /// </summary>
        public string FATypeCode
        {
            get { return _sFATypeCode; }
            set { _sFATypeCode = value.Trim(); }
        }

        /// <summary>
        /// Get set property for FATypeName
        /// </summary>
        public string FATypeName
        {
            get { return _sFATypeName; }
            set { _sFATypeName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for FATypeGroup
        /// </summary>
        public string FATypeGroup
        {
            get { return _sFATypeGroup; }
            set { _sFATypeGroup = value.Trim(); }
        }

        public void Add()
        {
            int nMaxFATypeID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([FATypeID]) FROM t_FixedAssetType";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxFATypeID = 1;
                }
                else
                {
                    nMaxFATypeID = Convert.ToInt32(maxID) + 1;
                }
                _nFATypeID = nMaxFATypeID;

                sSql = "INSERT INTO t_FixedAssetType VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("FATypeID", _nFATypeID);
                cmd.Parameters.AddWithValue("FATypeCode", _sFATypeCode);
                cmd.Parameters.AddWithValue("FATypeName", _sFATypeName);
                cmd.Parameters.AddWithValue("FATypeGroup", _sFATypeGroup);
                

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

                sSql = "UPDATE t_FixedAssetType SET FATypeCode=?, FATypeName=?, FATypeGroup=?"
                    + " WHERE FATypeID=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FATypeCode", _sFATypeCode);
                cmd.Parameters.AddWithValue("FATypeName", _sFATypeName);
                cmd.Parameters.AddWithValue("FATypeGroup", _sFATypeGroup);

                cmd.Parameters.AddWithValue("FATypeID", _nFATypeID);

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
                sSql = "DELETE FROM t_FixedAssetType WHERE [FATypeID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FATypeID", _nFATypeID);
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

            string sSql = "SELECT * FROM t_FixedAssetType Where FATypeID=? ";
            cmd.Parameters.AddWithValue("FATypeID", _nFATypeID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {  
                    _sFATypeCode = reader["FATypeCode"].ToString();
                    _sFATypeName = reader["FATypeName"].ToString();
                    _sFATypeGroup = reader["FATypeGroup"].ToString();
                  
                }
                reader.Close();
              

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckCode()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_FixedAssetType Where FATypeCode=? ";
            cmd.Parameters.AddWithValue("FATypeCode", _sFATypeCode);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nCount++;
                }
                reader.Close();


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) return false;
            else return true;
        }

    }
    public class FixedAssetTypes : CollectionBase
    {
        public FixedAssetType this[int i]
        {
            get { return (FixedAssetType)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(FixedAssetType oFixedAssetType)
        {
            InnerList.Add(oFixedAssetType);
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_FixedAssetType ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FixedAssetType oFixedAssetType = new FixedAssetType();

                    oFixedAssetType.FATypeID = (int)reader["FATypeID"];
                    oFixedAssetType.FATypeCode = reader["FATypeCode"].ToString();
                    oFixedAssetType.FATypeName = reader["FATypeName"].ToString();
                    oFixedAssetType.FATypeGroup = reader["FATypeGroup"].ToString();

                    InnerList.Add(oFixedAssetType);
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

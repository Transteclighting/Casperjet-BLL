// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Nov 27, 2019
// Time : 02:36 PM
// Description: Class for AreaType.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.BasicData
{
    public class OtletAreaType
    {
        private int _nID;
        private string _sAreaType;
        private int _nCreateUser;
        private DateTime _dCreateDate;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for AreaType
        // </summary>
        public string AreaType
        {
            get { return _sAreaType; }
            set { _sAreaType = value.Trim(); }
        }

        // <summary>
        // Get set property for CreateUser
        // </summary>
        public int CreateUser
        {
            get { return _nCreateUser; }
            set { _nCreateUser = value; }
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
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_AreaType";
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
                sSql = "INSERT INTO t_AreaType (ID, AreaType, CreateUser, CreateDate) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("AreaType", _sAreaType);
                cmd.Parameters.AddWithValue("CreateUser", _nCreateUser);
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
                sSql = "UPDATE t_AreaType SET AreaType = ?, CreateUser = ?, CreateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AreaType", _sAreaType);
                cmd.Parameters.AddWithValue("CreateUser", _nCreateUser);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

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
                sSql = "DELETE FROM t_AreaType WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_AreaType where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sAreaType = (string)reader["AreaType"];
                    _nCreateUser = (int)reader["CreateUser"];
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
    public class OtletAreaTypes : CollectionBase
    {
        public OtletAreaType this[int i]
        {
            get { return (OtletAreaType)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OtletAreaType oOtletAreaType)
        {
            InnerList.Add(oOtletAreaType);
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
            string sSql = "SELECT * FROM t_AreaType";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OtletAreaType oOtletAreaType = new OtletAreaType();
                    oOtletAreaType.ID = (int)reader["ID"];
                    oOtletAreaType.AreaType = (string)reader["AreaType"];
                    oOtletAreaType.CreateUser = (int)reader["CreateUser"];
                    oOtletAreaType.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oOtletAreaType);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByOthers()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_AreaType where ID In(1,2,4)";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OtletAreaType oOtletAreaType = new OtletAreaType();
                    oOtletAreaType.ID = (int)reader["ID"];
                    oOtletAreaType.AreaType = (string)reader["AreaType"];
                    oOtletAreaType.CreateUser = (int)reader["CreateUser"];
                    oOtletAreaType.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oOtletAreaType);
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



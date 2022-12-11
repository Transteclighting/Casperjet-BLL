// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Dec 29, 2016
// Time : 11:57 AM
// Description: Class for CSDProductFault.
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
    public class CSDProductFault
    {
        private int _nFaultID;
        private string _sFaultDescription;
        private int _nParentID;
        private int _nFaultLevel;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;


        // <summary>
        // Get set property for FaultID
        // </summary>
        public int FaultID
        {
            get { return _nFaultID; }
            set { _nFaultID = value; }
        }

        // <summary>
        // Get set property for FaultDescription
        // </summary>
        public string FaultDescription
        {
            get { return _sFaultDescription; }
            set { _sFaultDescription = value.Trim(); }
        }

        // <summary>
        // Get set property for ParentID
        // </summary>
        public int ParentID
        {
            get { return _nParentID; }
            set { _nParentID = value; }
        }

        // <summary>
        // Get set property for FaultLevel
        // </summary>
        public int FaultLevel
        {
            get { return _nFaultLevel; }
            set { _nFaultLevel = value; }
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
            int nMaxFaultID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([FaultID]) FROM t_CSDProductFault";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxFaultID = 1;
                }
                else
                {
                    nMaxFaultID = Convert.ToInt32(maxID) + 1;
                }
                _nFaultID = nMaxFaultID;
                sSql = "INSERT INTO t_CSDProductFault (FaultID, FaultDescription, ParentID, FaultLevel, CreateUserID, CreateDate, UpdateUserID, UpdateDate) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("FaultID", _nFaultID);
                cmd.Parameters.AddWithValue("FaultDescription", _sFaultDescription);
                cmd.Parameters.AddWithValue("ParentID", _nParentID);
                cmd.Parameters.AddWithValue("FaultLevel", _nFaultLevel);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

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
                sSql = "UPDATE t_CSDProductFault SET FaultDescription = ?, ParentID = ?, FaultLevel = ?, CreateUserID = ?, CreateDate = ?, UpdateUserID = ?, UpdateDate = ? WHERE FaultID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("FaultDescription", _sFaultDescription);
                cmd.Parameters.AddWithValue("ParentID", _nParentID);
                cmd.Parameters.AddWithValue("FaultLevel", _nFaultLevel);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("FaultID", _nFaultID);

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
                sSql = "DELETE FROM t_CSDProductFault WHERE [FaultID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("FaultID", _nFaultID);
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
                cmd.CommandText = "SELECT * FROM t_CSDProductFault where FaultID =?";
                cmd.Parameters.AddWithValue("FaultID", _nFaultID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nFaultID = (int)reader["FaultID"];
                    _sFaultDescription = (string)reader["FaultDescription"];
                    if (reader["ParentID"] != DBNull.Value)
                    _nParentID = (int)reader["ParentID"];
                    _nFaultLevel = (int)reader["FaultLevel"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    if (reader["UpdateUserID"] != DBNull.Value)
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    if (reader["UpdateDate"] != DBNull.Value)
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
    public class CSDProductFaults : CollectionBase
    {
        public CSDProductFault this[int i]
        {
            get { return (CSDProductFault)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDProductFault oCSDProductFault)
        {
            InnerList.Add(oCSDProductFault);
        }
        public int GetIndex(int nFaultID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].FaultID == nFaultID)
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
            string sSql = "SELECT * FROM t_CSDProductFault";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDProductFault oCSDProductFault = new CSDProductFault();
                    oCSDProductFault.FaultID = (int)reader["FaultID"];
                    oCSDProductFault.FaultDescription = (string)reader["FaultDescription"];
                    oCSDProductFault.ParentID = (int)reader["ParentID"];
                    oCSDProductFault.FaultLevel = (int)reader["FaultLevel"];
                    oCSDProductFault.CreateUserID = (int)reader["CreateUserID"];
                    oCSDProductFault.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDProductFault.UpdateUserID = (int)reader["UpdateUserID"];
                    oCSDProductFault.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    InnerList.Add(oCSDProductFault);
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


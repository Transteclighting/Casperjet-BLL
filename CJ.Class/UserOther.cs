// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Oct 07, 2019
// Time : 10:01 AM
// Description: Class for UserOther.
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
    public class UserOther
    {
        private int _nUserID;
        private string _sUserFullName;
        private string _sUserName;
        private string _sPassword;
        private string _sSalt;
        private int _nAppID;
        private int _nInstrumentId;
        private bool _bIsActive;
        private int _nCreateUserID;
        private DateTime _dCreateDate;


        // <summary>
        // Get set property for UserID
        // </summary>
        public int UserID
        {
            get { return _nUserID; }
            set { _nUserID = value; }
        }

        // <summary>
        // Get set property for UserFullName
        // </summary>
        public string UserFullName
        {
            get { return _sUserFullName; }
            set { _sUserFullName = value.Trim(); }
        }

        // <summary>
        // Get set property for UserName
        // </summary>
        public string UserName
        {
            get { return _sUserName; }
            set { _sUserName = value.Trim(); }
        }

        // <summary>
        // Get set property for Password
        // </summary>
        public string Password
        {
            get { return _sPassword; }
            set { _sPassword = value.Trim(); }
        }

        // <summary>
        // Get set property for Salt
        // </summary>
        public string Salt
        {
            get { return _sSalt; }
            set { _sSalt = value.Trim(); }
        }

        // <summary>
        // Get set property for AppID
        // </summary>
        public int AppID
        {
            get { return _nAppID; }
            set { _nAppID = value; }
        }

        // <summary>
        // Get set property for InstrumentId
        // </summary>
        public int InstrumentId
        {
            get { return _nInstrumentId; }
            set { _nInstrumentId = value; }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public bool IsActive
        {
            get { return _bIsActive; }
            set { _bIsActive = value; }
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

        public void Add()
        {
            int nMaxUserID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([UserID]) FROM t_UserOther";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxUserID = 1;
                }
                else
                {
                    nMaxUserID = Convert.ToInt32(maxID) + 1;
                }
                _nUserID = nMaxUserID;
                sSql = "INSERT INTO t_UserOther (UserID, UserFullName, UserName, Password, Salt, AppID, InstrumentId, IsActive, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("UserFullName", _sUserFullName);
                cmd.Parameters.AddWithValue("UserName", _sUserName);
                cmd.Parameters.AddWithValue("Password", _sPassword);
                cmd.Parameters.AddWithValue("Salt", _sSalt);
                cmd.Parameters.AddWithValue("AppID", _nAppID);
                cmd.Parameters.AddWithValue("InstrumentId", _nInstrumentId);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);
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
                sSql = "UPDATE t_UserOther SET UserFullName = ?, UserName = ?, Password = ?, Salt = ?, AppID = ?, InstrumentId = ?, IsActive = ?, CreateUserID = ?, CreateDate = ? WHERE UserID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("UserFullName", _sUserFullName);
                cmd.Parameters.AddWithValue("UserName", _sUserName);
                cmd.Parameters.AddWithValue("Password", _sPassword);
                cmd.Parameters.AddWithValue("Salt", _sSalt);
                cmd.Parameters.AddWithValue("AppID", _nAppID);
                cmd.Parameters.AddWithValue("InstrumentId", _nInstrumentId);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("UserID", _nUserID);

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
                sSql = "DELETE FROM t_UserOther WHERE [UserID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("UserID", _nUserID);
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
                cmd.CommandText = "SELECT * FROM t_UserOther where UserID =?";
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nUserID = (int)reader["UserID"];
                    _sUserFullName = (string)reader["UserFullName"];
                    _sUserName = (string)reader["UserName"];
                    _sPassword = (string)reader["Password"];
                    _sSalt = (string)reader["Salt"];
                    _nAppID = (int)reader["AppID"];
                    _nInstrumentId = (int)reader["InstrumentId"];
                    _bIsActive = Convert.ToBoolean(reader["IsActive"]);
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
    public class UserOthers : CollectionBase
    {
        public UserOther this[int i]
        {
            get { return (UserOther)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(UserOther oUserOther)
        {
            InnerList.Add(oUserOther);
        }
        public int GetIndex(int nUserID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].UserID == nUserID)
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
            string sSql = "SELECT * FROM t_UserOther";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UserOther oUserOther = new UserOther();
                    oUserOther.UserID = (int)reader["UserID"];
                    oUserOther.UserFullName = (string)reader["UserFullName"];
                    oUserOther.UserName = (string)reader["UserName"];
                    oUserOther.Password = (string)reader["Password"];
                    oUserOther.Salt = (string)reader["Salt"];
                    oUserOther.AppID = (int)reader["AppID"];
                    oUserOther.InstrumentId = (int)reader["InstrumentId"];
                    oUserOther.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    oUserOther.CreateUserID = (int)reader["CreateUserID"];
                    oUserOther.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oUserOther);
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


// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Dec 07, 2016
// Time : 11:07 AM
// Description: Class for DMSUser.
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
    public class DealerUser
    {
        private int _nUserID;
        private int _nCustomerID;
        private string _sUserName;
        private string _sUserFullName;
        private string _sPassword;
        private string _sSalt;
        private int _nIsActive;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private string _sCreatedBy;
        private string _sCustomerCode;



        // <summary>
        // Get set property for CustomerCode
        // </summary>
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }

        // <summary>
        // Get set property for CreatedBy
        // </summary>
        public string CreatedBy
        {
            get { return _sCreatedBy; }
            set { _sCreatedBy = value; }
        }

        // <summary>
        // Get set property for UserID
        // </summary>
        public int UserID
        {
            get { return _nUserID; }
            set { _nUserID = value; }
        }

        // <summary>
        // Get set property for CustomerID
        // </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
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
        // Get set property for UserFullName
        // </summary>
        public string UserFullName
        {
            get { return _sUserFullName; }
            set { _sUserFullName = value.Trim(); }
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
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
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
                sSql = "SELECT MAX([UserID]) FROM t_DMSUser";
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
                sSql = "INSERT INTO t_DMSUser (UserID, CustomerID, UserName, UserFullName, Password, Salt, IsActive, CreateUserID, CreateDate,Role) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("UserName", _sUserName);
                cmd.Parameters.AddWithValue("UserFullName", _sUserFullName);
                cmd.Parameters.AddWithValue("Password", _sPassword);
                cmd.Parameters.AddWithValue("Salt", _sSalt);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Role", "Outlet");

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
                sSql = "UPDATE t_DMSUser SET CustomerID = ?, UserName = ?, UserFullName = ?, Password = ?, Salt = ?, IsActive = ? WHERE UserID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("UserName", _sUserName);
                cmd.Parameters.AddWithValue("UserFullName", _sUserFullName);
                cmd.Parameters.AddWithValue("Password", _sPassword);
                cmd.Parameters.AddWithValue("Salt", _sSalt);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
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
                sSql = "DELETE FROM t_DMSUser WHERE [UserID]=?";
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
                cmd.CommandText = "SELECT * FROM t_DMSUser where UserID =?";
                cmd.Parameters.AddWithValue("UserID", _nUserID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nUserID = (int)reader["UserID"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _sUserName = (string)reader["UserName"];
                    _sUserFullName = (string)reader["UserFullName"];
                    _sPassword = (string)reader["Password"];
                    _sSalt = (string)reader["Salt"];
                    _nIsActive = (int)reader["IsActive"];
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
    public class DealerUsers : CollectionBase
    {
        public DealerUser this[int i]
        {
            get { return (DealerUser)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DealerUser oDealerUser)
        {
            InnerList.Add(oDealerUser);
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


        public void GetData()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            //string sSql = "SELECT * FROM t_DMSUser a INNER JOIN t_User b on a.CreateUserID = b.UserID INNER JOIN t_Customer c ON c.CustomerId = a.UserID";
            string sSql = "SELECT a.*,b.UserFullName AS CreatedBy,c.* FROM t_DMSUser a "+
                          "INNER JOIN t_User b on a.CreateUserID = b.UserID "+
                          "INNER JOIN t_Customer c ON c.CustomerId = a.CustomerID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DealerUser oDealerUser = new DealerUser();
                    oDealerUser.UserID = (int)reader["UserID"];
                    oDealerUser.CustomerID = (int)reader["CustomerID"];
                    oDealerUser.CustomerCode = (string)reader["CustomerCode"];
                    oDealerUser.UserName = (string)reader["UserName"];
                    oDealerUser.UserFullName = (string)reader["UserFullName"];
                    oDealerUser.Password = (string)reader["Password"];
                    oDealerUser.Salt = (string)reader["Salt"];
                    oDealerUser.IsActive = (int)reader["IsActive"];
                    oDealerUser.CreateUserID = (int)reader["CreateUserID"];
                    oDealerUser.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oDealerUser.CreatedBy = (string)reader["CreatedBy"];
                    
                    
                    InnerList.Add(oDealerUser);
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
            string sSql = "SELECT * FROM t_DMSUser";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DealerUser oDealerUser = new DealerUser();
                    oDealerUser.UserID = (int)reader["UserID"];
                    oDealerUser.CustomerID = (int)reader["CustomerID"];
                    oDealerUser.UserName = (string)reader["UserName"];
                    oDealerUser.UserFullName = (string)reader["UserFullName"];
                    oDealerUser.Password = (string)reader["Password"];
                    oDealerUser.Salt = (string)reader["Salt"];
                    oDealerUser.IsActive = (int)reader["IsActive"];
                    oDealerUser.CreateUserID = (int)reader["CreateUserID"];
                    oDealerUser.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oDealerUser);
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


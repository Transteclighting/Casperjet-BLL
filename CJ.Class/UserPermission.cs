// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abudl Hakim
// Date: Apr 19, 2014
// Time :  02:58 PM
// Description: Class for User Permission.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.POS;

namespace CJ.Class
{
    public class UserPermission
    {
        private int _nUser;
        private string _sUserPermissions;
        private string _sDescription;
        private string _sMenuType;
        private string _sCompany;
        int nCount = 0;
        public int User
        {
            get { return _nUser; }
            set { _nUser = value; }
        }
        public string UserPermissions
        {
            get { return _sUserPermissions; }
            set { _sUserPermissions = value; }
        }
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value; }
        }
        public string Company
        {
            get { return _sCompany; }
            set { _sCompany = value; }
        }
        public string MenuType
        {
            get { return _sMenuType; }
            set { _sMenuType = value; }
        }
        public bool CheckPermission(string sPermisstionKey)
        {
            
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_UserPermission where PermissionKey=? and UserID=" + Utility.UserId + "";
            cmd.Parameters.AddWithValue("PermissionKey", sPermisstionKey);
            nCount = 0;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sUserPermissions = reader["PermissionKey"].ToString();
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                return true;
            else return false;
        }

        public bool CheckPermissionalData(string sDataType, int nDataID, int nUserID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from dbo.t_UserPermissionData Where DataType='" + sDataType + "' and DataID=" + nDataID + " and UserID=" + nUserID + " ";
            
            nCount = 0;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                return true;
            else return false;
        }

        public bool CheckPermission(string sPermisstionKey,int nUserID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_UserPermission where PermissionKey=? and UserID=?";
            cmd.Parameters.AddWithValue("PermissionKey", sPermisstionKey);
            cmd.Parameters.AddWithValue("UserID", nUserID);
            nCount = 0;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sUserPermissions = reader["PermissionKey"].ToString();
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                return true;
            else return false;
        }
    }
    public class UserPermissions : CollectionBase
    {

        public UserPermission this[int i]
        {
            get { return (UserPermission)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(UserPermission oUserPermission)
        {
            InnerList.Add(oUserPermission);
        }

        public UserPermissions Refresh(UserPermissions oUserPermissions, int nUserId)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_UserPermission where UserID=?";
            cmd.Parameters.AddWithValue("UserID", nUserId);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UserPermission oUserPermission = new UserPermission();
                    oUserPermission.UserPermissions = reader["PermissionKey"].ToString();
                    InnerList.Add(oUserPermission);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return oUserPermissions;
        }
        public UserPermissions RefreshAndroidPermission(UserPermissions oUserPermissions, string sUserName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "Select a.* from t_UserPermission a, t_User b where a.UserID=b.UserID and UserName='" + sUserName + "' and PermissionKey IN " +
            //    "('M41.1.1','M41.1.2','M41.1.3','M41.1.4','M41.1.5','M41.1.6','M41.1.7','M41.2.1','M41.3.1','M41.3.2','M41.3.3') ";

            string sSql = "select a.PermissionKey, Description, MenuType, Company from t_A_Menu a, t_UserPermission b, t_user c " +
                           " where a.PermissionKey=b.PermissionKey and b.UserID=c.UserID and a.IsActive=1 and " +
                           " c.UserName='" + sUserName + "' order by sortOrder ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UserPermission oUserPermission = new UserPermission();
                    oUserPermission.UserPermissions = reader["PermissionKey"].ToString();
                    oUserPermission.Description = reader["Description"].ToString();
                    oUserPermission.MenuType = reader["MenuType"].ToString();
                    oUserPermission.Company = reader["Company"].ToString();
                    InnerList.Add(oUserPermission);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return oUserPermissions;
        }
        public UserPermissions RefreshAndroidNonPermission(UserPermissions oUserPermissions)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "Select a.* from t_UserPermission a, t_User b where a.UserID=b.UserID and UserName='" + sUserName + "' and PermissionKey IN " +
            //    "('M41.1.1','M41.1.2','M41.1.3','M41.1.4','M41.1.5','M41.1.6','M41.1.7','M41.2.1','M41.3.1','M41.3.2','M41.3.3') ";

            string sSql = "select PermissionKey, Description, MenuType, Company from t_A_Menu where IsActive=1  order by sortOrder ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UserPermission oUserPermission = new UserPermission();
                    oUserPermission.UserPermissions = reader["PermissionKey"].ToString();
                    oUserPermission.Description = reader["Description"].ToString();
                    oUserPermission.MenuType = reader["MenuType"].ToString();
                    oUserPermission.Company = reader["Company"].ToString();
                    InnerList.Add(oUserPermission);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return oUserPermissions;
        }
    }
}

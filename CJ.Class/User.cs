// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: March 21, 2011
// Time :  10:00 AM
// Description: Class for User Information.
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
    public class User
    {
        private int _nUserId;
        private int _nEmployeeID;
        private string _sUserFullName;
        private string _sUsername;
        private string _sUserPassword;
        private string _sSalt;             
        private string _sUserSBUs;
        private string _sPermission;
        private int _nAndroidAppID;
        private string _sEmployeeCode;
        private string _sEmployeeName;
        private Employee _oEmployee;
        private int _nSync;

        public Employee Employee
        {
            get
            {
                if (_oEmployee == null)
                {
                    _oEmployee = new Employee();
                    _oEmployee.EmployeeID = _nEmployeeID;
                    _oEmployee.Refresh();
                }

                return _oEmployee;
            }
        }

        public int UserId
        {
            get { return _nUserId; }
            set { _nUserId = value; }
        }
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }   
        public string UserFullName
        {
            get { return _sUserFullName; }
            set { _sUserFullName = value; }
        }
        public string Username
        {
            get { return _sUsername; }
            set { _sUsername = value; }
        }
        public string UserPassword
        {
            get { return _sUserPassword; }
            set { _sUserPassword = value; }
        }
        public string Salt
        {
            get { return _sSalt; }
            set { _sSalt = value; }
        }
        public string UserSBUs
        {
            get { return _sUserSBUs; }
            set { _sUserSBUs = value; }
        }
        public string Permission
        {
            get { return _sPermission; }
            set { _sPermission = value; }
        }
        private string _sStatus;
        public string Status
        {
            get { return _sStatus; }
            set { _sStatus = value; }
        }
        private string _sAuthenticateMode;
        public string AuthenticateMode
        {
            get { return _sAuthenticateMode; }
            set { _sAuthenticateMode = value; }
        }
        public int AndroidAppID
        {
            get { return _nAndroidAppID; }
            set { _nAndroidAppID = value; }
        }
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value; }
        }
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value; }
        }
        public int Sync
        {
            get { return _nSync; }
            set { _nSync = value; }
        }

        public void Add()
        {
            int nMaxUserID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([UserID]) FROM t_User";
                cmd.CommandText = sSql;
                object maxUserID = cmd.ExecuteScalar();
                if (maxUserID == DBNull.Value)
                {
                    nMaxUserID = 1;
                }
                else
                {
                    nMaxUserID = Convert.ToInt32(maxUserID) + 1;

                }
                _nUserId = nMaxUserID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_User VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("UserID", _nUserId);
                cmd.Parameters.AddWithValue("UserFullName", _sUserFullName);
                cmd.Parameters.AddWithValue("UserName", _sUsername);
                cmd.Parameters.AddWithValue("Password", _sUserPassword);
                cmd.Parameters.AddWithValue("Salt",_sSalt);
                cmd.Parameters.AddWithValue("UserSBUs", _sUserSBUs);

                if (_nEmployeeID != -1)
                    cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                else cmd.Parameters.AddWithValue("EmployeeID", null);
                //cmd.Parameters.AddWithValue("EntryUserDate", DateTime.Today);
                //cmd.Parameters.AddWithValue("EntryUserID", Utility.UserId);
                //cmd.Parameters.AddWithValue("EditUserDate", null);
                //cmd.Parameters.AddWithValue("EditUserID", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddPermission(string sPermission)
        {          

            OleDbCommand cmd = DBController.Instance.GetCommand();            

            try
            {              

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "INSERT INTO t_UserPermission VALUES(?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("UserID", _nUserId);
                cmd.Parameters.AddWithValue("PermissionKey", sPermission);
                //cmd.Parameters.AddWithValue("EntryUserID", Utility.UserId);
                //cmd.Parameters.AddWithValue("EntryUserDate", DateTime.Today);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddForTransfer()
        {        

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_User (UserID,UserFullName,UserName,Password,Salt,UserSBUs,EmployeeID) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("UserID", _nUserId);
                cmd.Parameters.AddWithValue("UserFullName", _sUserFullName);
                cmd.Parameters.AddWithValue("UserName", _sUsername);
                cmd.Parameters.AddWithValue("Password", _sUserPassword);
                cmd.Parameters.AddWithValue("Salt", _sSalt);
                cmd.Parameters.AddWithValue("UserSBUs", _sUserSBUs);

                if (_nEmployeeID != -1)
                    cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                else cmd.Parameters.AddWithValue("EmployeeID", null);
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }      
        public void AddDataPermission(int nUserID, int nDataID, string sDataType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {             
                cmd.CommandText = "INSERT INTO t_UserPermissionData VALUES(?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("UserID", nUserID);
                cmd.Parameters.AddWithValue("DataID", nDataID);
                cmd.Parameters.AddWithValue("DataType", sDataType);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Update(bool bFlag)
        { 
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (bFlag == true)
            {
                try
                {
                    cmd.CommandText = "Update t_User set UserName=?,UserFullName=?, Password=?,Salt = ?, UserSBUs = ?,EmployeeID=? where UserID=?";
                    cmd.Parameters.AddWithValue("UserName", _sUsername);
                    cmd.Parameters.AddWithValue("UserFullName", _sUserFullName);
                    cmd.Parameters.AddWithValue("Password", _sUserPassword);
                    cmd.Parameters.AddWithValue("Salt", _sSalt);
                    cmd.Parameters.AddWithValue("UserSBUs", _sUserSBUs);

                    if (_nEmployeeID != -1)
                        cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                    else cmd.Parameters.AddWithValue("EmployeeID",null);
                    //cmd.Parameters.AddWithValue("EditUserDate", DateTime.Today);
                    //cmd.Parameters.AddWithValue("EditUserID", Utility.UserId);

                    cmd.Parameters.AddWithValue("UserID", _nUserId);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            else
            {
                try
                {
                    cmd.CommandText = "Update t_User set UserName=?,UserFullName=?, UserSBUs = ?,EmployeeID=?  where UserID=?";
                    cmd.Parameters.AddWithValue("UserName", _sUsername);
                    cmd.Parameters.AddWithValue("UserFullName", _sUserFullName);                
                    cmd.Parameters.AddWithValue("UserSBUs", _sUserSBUs);

                    if (_nEmployeeID != -1)
                        cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);
                    else cmd.Parameters.AddWithValue("EmployeeID", null);
                    //cmd.Parameters.AddWithValue("EditUserDate", DateTime.Today);
                    //cmd.Parameters.AddWithValue("EditUserID", Utility.UserId);

                    cmd.Parameters.AddWithValue("UserID", _nUserId);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }
        public void changepassword()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();           
                try
                {
                    cmd.CommandText = "Update t_User set Password=?, Salt = ? where UserID=?";                    
                    cmd.Parameters.AddWithValue("Password", _sUserPassword);
                    cmd.Parameters.AddWithValue("Salt", _sSalt);                  
                    cmd.Parameters.AddWithValue("UserID", _nUserId);
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

            try
            {             
                cmd.CommandText = "Delete from t_User where UserID=?";
                cmd.Parameters.AddWithValue("UserID", _nUserId);
                cmd.ExecuteNonQuery();           
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeletePermission()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from t_UserPermission where UserID=?";
                //cmd.CommandText = "Delete from t_UserRole where UserID=?";
                cmd.Parameters.AddWithValue("UserID", _nUserId);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void DeleteDataPermission(int nUserId)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from t_UserPermissionData where UserID=?";
                cmd.Parameters.AddWithValue("UserID", nUserId);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }      
        public bool authenticate(string sUsername)
        {          
            int Count = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (Utility.CompanyInfo == "TEL")
            {
                sSql = "Select a.* from t_User a, t_Employee b where UserName=? and " +
                " a.EmployeeID = b.EmployeeID and b.EMPStatus in (" + (int)Dictionary.HREmployeeStatus.Contractual + "," + (int)Dictionary.HREmployeeStatus.Confirmed + ")";
                cmd.Parameters.AddWithValue("UserName", sUsername);
            }
            else
            {
                sSql = "Select * from t_User where UserName=?";
                cmd.Parameters.AddWithValue("UserName", sUsername);
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {                  
                    _nUserId = int.Parse(reader["UserID"].ToString());
                    _sUserFullName = reader["UserFullName"].ToString();
                    _sUsername = reader["UserName"].ToString();
                    _sUserPassword = reader["Password"].ToString();
                    _sSalt = reader["Salt"].ToString();

                    _sUserSBUs = reader["UserSBUs"].ToString();
                    if (reader["EmployeeID"] != DBNull.Value)
                        _nEmployeeID = int.Parse(reader["EmployeeID"].ToString());
                    else _nEmployeeID = -1;
                    
                    Count++;
                }
                reader.Close();
                if (Count != 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
           
        }
        public bool authenticateFactory(string sUsername)
        {
            int Count = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_User where UserName=?";
            cmd.Parameters.AddWithValue("UserName", sUsername);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nUserId = int.Parse(reader["UserID"].ToString());
                    _sUserFullName = reader["UserFullName"].ToString();
                    _sUsername = reader["UserName"].ToString();
                    _sUserPassword = reader["Password"].ToString();
                    _sSalt = reader["Salt"].ToString();

                    _sUserSBUs = reader["UserSBUs"].ToString();
                    if (reader["EmployeeID"] != DBNull.Value)
                        _nEmployeeID = int.Parse(reader["EmployeeID"].ToString());
                    else _nEmployeeID = -1;

                    Count++;
                }
                reader.Close();
                if (Count != 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public bool authenticatePOS(string sUsername)
        {
            int Count = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.*,b.EmployeeCode,b.EmployeeName from t_User a, t_Employee b where UserName=? and " +
            " a.EmployeeID = b.EmployeeID and b.Status in (" + (int)Dictionary.HREmployeeStatus.Contractual + "," + (int)Dictionary.HREmployeeStatus.Confirmed + ")";
            cmd.Parameters.AddWithValue("UserName", sUsername);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nUserId = int.Parse(reader["UserID"].ToString());
                    _sUserFullName = reader["UserFullName"].ToString();
                    _sUsername = reader["UserName"].ToString();
                    _sUserPassword = reader["Password"].ToString();
                    _sSalt = reader["Salt"].ToString();

                    _sUserSBUs = reader["UserSBUs"].ToString();
                    if (reader["EmployeeID"] != DBNull.Value)
                        _nEmployeeID = int.Parse(reader["EmployeeID"].ToString());
                    else _nEmployeeID = -1;
                    if (reader["EmployeeCode"] != DBNull.Value)
                        _sEmployeeCode = (reader["EmployeeCode"].ToString());
                    else _sEmployeeCode = "";

                    if (reader["EmployeeName"] != DBNull.Value)
                        _sEmployeeName = (reader["EmployeeName"].ToString());
                    else _sEmployeeName = "";

                    Count++;
                }
                reader.Close();
                if (Count != 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public bool authenticatePOSRT(string sUsername)
        {
            int Count = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.*,b.EmployeeCode,b.EmployeeName from t_User a, t_Employee b where UserName=? and " +
            " a.EmployeeID = b.EmployeeID and b.EmpStatus in (" + (int)Dictionary.HREmployeeStatus.Contractual + "," + (int)Dictionary.HREmployeeStatus.Confirmed + ")";
            cmd.Parameters.AddWithValue("UserName", sUsername);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nUserId = int.Parse(reader["UserID"].ToString());
                    _sUserFullName = reader["UserFullName"].ToString();
                    _sUsername = reader["UserName"].ToString();
                    _sUserPassword = reader["Password"].ToString();
                    _sSalt = reader["Salt"].ToString();

                    _sUserSBUs = reader["UserSBUs"].ToString();
                    if (reader["EmployeeID"] != DBNull.Value)
                        _nEmployeeID = int.Parse(reader["EmployeeID"].ToString());
                    else _nEmployeeID = -1;
                    if (reader["EmployeeCode"] != DBNull.Value)
                        _sEmployeeCode = (reader["EmployeeCode"].ToString());
                    else _sEmployeeCode = "";

                    if (reader["EmployeeName"] != DBNull.Value)
                        _sEmployeeName = (reader["EmployeeName"].ToString());
                    else _sEmployeeName = "";

                    Count++;
                }
                reader.Close();
                if (Count != 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public bool UserAuthentication(string sUsername, string sDatabase)
        {
            int Count = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from " + sDatabase + ".dbo.t_User where UserName=?";
            cmd.Parameters.AddWithValue("UserName", sUsername);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nUserId = int.Parse(reader["UserID"].ToString());
                    _sUserFullName = reader["UserFullName"].ToString();
                    _sUsername = reader["UserName"].ToString();
                    _sUserPassword = reader["Password"].ToString();
                    _sSalt = reader["Salt"].ToString();

                    _sUserSBUs = reader["UserSBUs"].ToString();
                    if (reader["EmployeeID"] != DBNull.Value)
                        _nEmployeeID = int.Parse(reader["EmployeeID"].ToString());
                    else _nEmployeeID = -1;

                    Count++;
                }
                reader.Close();
                if (Count != 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public bool CheckRegistrationCJApps(string sIMEI)
        {
            int Count = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from dbo.t_A_UserRegistration where IMEINo='" + sIMEI + "' ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["AndroidAppID"] != DBNull.Value)
                        _nAndroidAppID = (int)reader["AndroidAppID"];
                    else _nAndroidAppID = 1;
                    _sStatus = (string)reader["Status"];
                    if (reader["AuthenticateMode"] != DBNull.Value)
                        _sAuthenticateMode = (string)reader["AuthenticateMode"];
                    else _sAuthenticateMode = "Null";
                    Count++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (Count != 0) 
                return true; 
            else 
                return false;
        }
        public bool CheckRegistrationCJApps(string sIMEI, string sUserName)
        {
            int Count = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from dbo.t_A_UserRegistration where IMEINo='" + sIMEI + "' and UserName='" + sUserName + "' ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["AndroidAppID"] != DBNull.Value)
                        _nAndroidAppID = (int)reader["AndroidAppID"];
                    else _nAndroidAppID = 1;
                    _sStatus = (string)reader["Status"];
                    if (reader["AuthenticateMode"] != DBNull.Value)
                        _sAuthenticateMode = (string)reader["AuthenticateMode"];
                    else _sAuthenticateMode = "Null";
                    Count++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (Count != 0)
                return true;
            else
                return false;
        }
        public bool CheckSIMSerial(string sSIMSerial)
        {
            int Count = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from dbo.t_A_UserRegistration where SIMSerialNo='" + sSIMSerial + "' ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["AndroidAppID"] != DBNull.Value)
                        _nAndroidAppID = (int)reader["AndroidAppID"];
                    else _nAndroidAppID = 1;
                    Count++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (Count != 0)
                return true;
            else
                return false;
        }
        public bool CheckSIMSerialCJApps(string sSIMSerial, string sUserName)
        {
            int Count = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from dbo.t_A_UserRegistration where SIMSerialNo='" + sSIMSerial + "' and UserName='" + sUserName + "' ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["AndroidAppID"] != DBNull.Value)
                        _nAndroidAppID = (int)reader["AndroidAppID"];
                    else _nAndroidAppID = 1;
                    Count++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (Count != 0)
                return true;
            else
                return false;
        }
        public int GetAndroidAppID(string sIMEI)
        {
            int nAndroidAppID = 1;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from dbo.t_A_UserRegistration where IMEINo='" + sIMEI + "' ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["AndroidAppID"] != DBNull.Value)
                        nAndroidAppID = (int)reader["AndroidAppID"];
                    else nAndroidAppID = 1;
                   
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nAndroidAppID;
        }
        public bool authenticatefordms(string sUsername)
        {
            int Count = 0;
            string DMSAdminPermissionKey = "M31.3";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.* from t_User a,t_UserPermission b where a.UserID=b.UserID and a.UserName=? and b.PermissionKey=?";
            cmd.Parameters.AddWithValue("UserName", sUsername);
            cmd.Parameters.AddWithValue("PermissionKey", DMSAdminPermissionKey);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nUserId = int.Parse(reader["UserID"].ToString());
                    _sUserFullName = reader["UserFullName"].ToString();
                    _sUsername = reader["UserName"].ToString();
                    _sUserPassword = reader["Password"].ToString();
                    _sSalt = reader["Salt"].ToString();

                    _sUserSBUs = reader["UserSBUs"].ToString();
                    if (reader["EmployeeID"] != DBNull.Value)
                        _nEmployeeID = int.Parse(reader["EmployeeID"].ToString());
                    else _nEmployeeID = -1;

                    Count++;
                }
                reader.Close();
                if (Count != 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshByUserID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM t_User where UserID =?";
                cmd.Parameters.AddWithValue("UserID", _nUserId);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sUsername = (string)reader["UserName"];
                    if (reader["EmployeeID"] != DBNull.Value)
                        _nEmployeeID = int.Parse(reader["EmployeeID"].ToString());
                    else _nEmployeeID = -99;

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void SyncUser(int _nUserID)
        {
            //int nCustomerID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_Userrole set Sync=1 where UserID=? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("UserID", _nUserId);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Web Service Functions

        /// <summary>
        /// Web Service Functions
        /// </summary>
        /// 
        public DSUser PosAuthenticate(DSUser oDSUser)
        {
           string sUserName = oDSUser.User[0].UserName.ToLower();
           string sUsePassword = oDSUser.User[0].Password.ToLower();
           oDSUser = new DSUser();

           if (authenticate(sUserName) != false)
           {                 
               PDSAHash mph = new PDSAHash(PDSAHash.PDSAHashType.MD5);
               string sHashValue = mph.CreateHash(sUsePassword, _sSalt);

               if (_sUserPassword.CompareTo(sHashValue) != 0)
               {
                   DSUser.UserRow oUserRow = oDSUser.User.NewUserRow();

                   oUserRow.IsTrue = "0";

                   oDSUser.User.AddUserRow(oUserRow);
                   oDSUser.AcceptChanges();
               }
               else
               {
                   DSUser.UserRow oUserRow = oDSUser.User.NewUserRow();

                   oUserRow.UserName = _sUsername;
                   oUserRow.UserID = _nUserId;
                   oUserRow.EmployeeID = _nEmployeeID;
                   oUserRow.IsTrue = "1";

                   oDSUser.User.AddUserRow(oUserRow);
                   oDSUser.AcceptChanges();
               }
              
           }
           else
           {
               DSUser.UserRow oUserRow = oDSUser.User.NewUserRow();
                             
               oUserRow.IsTrue = "0";

               oDSUser.User.AddUserRow(oUserRow);
               oDSUser.AcceptChanges();
           }

           return oDSUser;

       }
        #endregion

   }


    public class Users : CollectionBase
    {
        
        public User this[int i]
        {
            get { return (User)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(User oUser)
        {
            InnerList.Add(oUser);
        }
        public bool UserNameCheck(string sUsername)
        {
             int Count = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_User where UserName=?";
            cmd.Parameters.AddWithValue("UserName", sUsername);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {  
                    Count++;
                }
                reader.Close();
                if (Count != 0) return true;

                return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }           
        
        }
        public Users GetData(string sUsername, string sUserFullName, int nEmployeeID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = " SELECT a.*, EmployeeCode, EmployeeName FROM t_User a " +
                   " Left Outer Join t_Employee b ON a.EmployeeID = b.EmployeeID where 1=1 ";

            if (sUsername != "")
            {
                sSql = sSql + " and UserName like '%" + sUsername + "%'";
            }
            if (sUserFullName != "")
            {
                sSql = sSql + " and UserFullName like '%" + sUserFullName + "%'";
            }
            if (nEmployeeID != 0)
            {
                sSql = sSql + " and a.EmployeeID = " + nEmployeeID + "";
            }

            sSql = sSql + " Order by UserName ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User oUser = new User();
                    oUser.UserId = int.Parse(reader["UserID"].ToString());
                    oUser.UserFullName = reader["UserFullName"].ToString();
                    oUser.Username = reader["UserName"].ToString();
                    oUser.UserPassword = reader["Password"].ToString();
                    oUser.UserSBUs = reader["UserSBUs"].ToString();

                    if (reader["EmployeeID"] != DBNull.Value)
                        oUser.EmployeeID = int.Parse(reader["EmployeeID"].ToString());
                    else oUser.EmployeeID = -1;

                    if (reader["EmployeeCode"] != DBNull.Value)
                        oUser.EmployeeCode = reader["EmployeeCode"].ToString();
                    else oUser.EmployeeCode = "";

                    if (reader["EmployeeName"] != DBNull.Value)
                        oUser.EmployeeName = reader["EmployeeName"].ToString();
                    else oUser.EmployeeName = "";

                    InnerList.Add(oUser);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return this;
        }
        public bool checkPermission(string sKey,int nUserId)
        {
            int i = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_UserPermission where PermissionKey=? and UserID=?";
            cmd.Parameters.AddWithValue("PermissionKey", sKey);
            cmd.Parameters.AddWithValue("UserID", nUserId);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {  
                    i = i + 1;
                }
                reader.Close();
            }             
            catch (Exception ex)
            {
                throw (ex);
            } 
  
            if (i > 0)
                return true;
            else
                return false;

        }
        public DSPermission UserPermission(int nUserId)
        {
            int i = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            DSPermission oDSPermission = new DSPermission();

            string sSql = "Select * from t_UserPermission where UserID=? ";
            cmd.Parameters.AddWithValue("UserID", nUserId);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSPermission.PermissionRow oRow = oDSPermission.Permission.NewPermissionRow();

                    oRow.PermissionKey = (string)reader["PermissionKey"];

                    oDSPermission.Permission.AddPermissionRow(oRow);
                    oDSPermission.AcceptChanges();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return oDSPermission;

        }
        public bool checkPermissionFromDS(string sKey)
        {
            int i = 0;
            DataRow[] foundRows;

            try
            {
                foundRows = Utility.UserPermission.Permission.Select("PermissionKey='" + sKey + "'");

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            if (foundRows.Length > 0)
                return true;
            else
                return false;

        }
        public string checkOtherPermission(string sKey)
        {
            int i = 0;
            DataRow[] foundRows;

            try
            {
                foundRows = Utility.UserPermission.Permission.Select("PermissionKey='" + sKey + "'");

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            if (foundRows.Length > 0)
                return sKey;
            else
                return null;

        }
        public string checkOtherPermission(string sKey, int nUserId)
        {           
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_UserPermission where PermissionKey=? and UserID=?";
            cmd.Parameters.AddWithValue("PermissionKey", sKey);
            cmd.Parameters.AddWithValue("UserID", nUserId);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return (reader["PermissionKey"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return null;           

        }
        public bool checkdataPermission(int nDataID, string sDataName, int nUserID)
        {
            int i = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_UserPermissionData where DataID=? and DataType=? and UserID=?";
            cmd.Parameters.AddWithValue("DataID", nDataID);
            cmd.Parameters.AddWithValue("DataType", sDataName);
            cmd.Parameters.AddWithValue("UserID", nUserID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    i = i + 1;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            if (i > 0)
                return true;
            else
                return false;

        }
        public DSPermissionData GetDataPermission(int nUserID)
        {
            DSPermissionData oDSPermissionData = new DSPermissionData();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_UserPermissionData where UserID=?";
            cmd.Parameters.AddWithValue("UserID", nUserID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSPermissionData.PermissionDataRow oRow = oDSPermissionData.PermissionData.NewPermissionDataRow();

                    oRow.UserID = (int)reader["UserID"];
                    oRow.DataID = (int)reader["DataID"];
                    oRow.DataType = (string)reader["DataType"];

                    oDSPermissionData.PermissionData.AddPermissionDataRow(oRow);
                    oDSPermissionData.AcceptChanges();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return oDSPermissionData;
        }

        public bool checkdataPermissionDS(DSPermissionData oDSPermissionData, int nDataID, string sDataType, int nUserID)
        {

            DataRow[] foundRows;

            try
            {
                foundRows = oDSPermissionData.PermissionData.Select(" DataID="+ nDataID + " and DataType='"+ sDataType + "' and UserID= " + nUserID + " ");

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            if (foundRows.Length > 0)
                return true;
            else
                return false;

        }
        public void AllPermission(int nUserId)
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
                    User oUser = new User();
                    oUser.Permission=reader["PermissionKey"].ToString();
                    InnerList.Add(oUser);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }            

        }
        public string GetDataID(int nUserID, string sDataType )
        {
            string sPermission = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_UserPermissionData where UserID=? and DataType=? ";
            cmd.Parameters.AddWithValue("UserID", nUserID);
            cmd.Parameters.AddWithValue("DataType", sDataType);
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (sPermission == "")
                    {
                        sPermission = reader["DataID"].ToString();
                    }
                    else
                    {
                        sPermission = sPermission + "," + reader["DataID"].ToString();
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return sPermission;

        }
        public void Refresh()
        {
            
            User oUser;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_User order by UserName";
                
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while  (reader.Read())
                {
                    oUser = new User();
                    oUser.UserId = (int)reader["UserID"];
                    oUser.Username = (string)reader["UserName"];
                    InnerList.Add(oUser);
                }

                reader.Close();
                //cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #region Web Service Functions

        public DSPermission POSGetAllPermission(DSPermission oDSPermission,int nUserID)
        {
            AllPermission(nUserID);

            oDSPermission = new DSPermission();
            foreach (User oUser in this)
            {
                DSPermission.PermissionRow oPermissionRow = oDSPermission.Permission.NewPermissionRow();
                oPermissionRow.PermissionKey = oUser.Permission;            
                oDSPermission.Permission.AddPermissionRow(oPermissionRow);
                oDSPermission.AcceptChanges();
            }
            return oDSPermission;
        }

        #endregion


    }
}

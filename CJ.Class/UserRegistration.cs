// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Apr 04, 2016
// Time : 03:18 PM
// Description: Class for UserRegistration.
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
    public class UserRegistration
    {
        private int _nID;
        private string _sMobileNo;
        private string _sUserFullName;
        private string _sUserName;
        private string _sIMEINo;
        private string _sSIMSerialNo;
        private DateTime _dRequestDate;
        private string _sStatus;
        private string _sAuthenticateMode;
        private string _sActivatedBy;
        private DateTime _dActivatedDate;
        private int _nBLLMarketGroup;
        private string _sVersionNo;
        private int _nAndroidAppID;
        private int _nEmployeeID;
        private string _sEmployeeName;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for MobileNo
        // </summary>
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value.Trim(); }
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
        // Get set property for IMEINo
        // </summary>
        public string IMEINo
        {
            get { return _sIMEINo; }
            set { _sIMEINo = value.Trim(); }
        }

        // <summary>
        // Get set property for SIMSerialNo
        // </summary>
        public string SIMSerialNo
        {
            get { return _sSIMSerialNo; }
            set { _sSIMSerialNo = value.Trim(); }
        }

        // <summary>
        // Get set property for RequestDate
        // </summary>
        public DateTime RequestDate
        {
            get { return _dRequestDate; }
            set { _dRequestDate = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public string Status
        {
            get { return _sStatus; }
            set { _sStatus = value.Trim(); }
        }

        // <summary>
        // Get set property for AuthenticateMode
        // </summary>
        public string AuthenticateMode
        {
            get { return _sAuthenticateMode; }
            set { _sAuthenticateMode = value.Trim(); }
        }

        // <summary>
        // Get set property for ActivatedBy
        // </summary>
        public string ActivatedBy
        {
            get { return _sActivatedBy; }
            set { _sActivatedBy = value.Trim(); }
        }

        // <summary>
        // Get set property for ActivatedDate
        // </summary>
        public DateTime ActivatedDate
        {
            get { return _dActivatedDate; }
            set { _dActivatedDate = value; }
        }

        // <summary>
        // Get set property for BLLMarketGroup
        // </summary>
        public int BLLMarketGroup
        {
            get { return _nBLLMarketGroup; }
            set { _nBLLMarketGroup = value; }
        }

        // <summary>
        // Get set property for VersionNo
        // </summary>
        public string VersionNo
        {
            get { return _sVersionNo; }
            set { _sVersionNo = value.Trim(); }
        }

        // <summary>
        // Get set property for AndroidAppID
        // </summary>
        public int AndroidAppID
        {
            get { return _nAndroidAppID; }
            set { _nAndroidAppID = value; }
        }

        // <summary>
        // Get set property for EmployeeID
        // </summary>
        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }


        // <summary>
        // Get set property for EmployeeName
        // </summary>
        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_A_UserRegistration";
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
                sSql = "INSERT INTO t_A_UserRegistration (ID, MobileNo, UserFullName, UserName, IMEINo, SIMSerialNo, RequestDate, Status, AuthenticateMode, ActivatedBy, ActivatedDate, BLLMarketGroup, VersionNo, AndroidAppID, EmployeeID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("UserFullName", _sUserFullName);
                cmd.Parameters.AddWithValue("UserName", _sUserName);
                cmd.Parameters.AddWithValue("IMEINo", _sIMEINo);
                cmd.Parameters.AddWithValue("SIMSerialNo", _sSIMSerialNo);
                cmd.Parameters.AddWithValue("RequestDate", _dRequestDate);
                cmd.Parameters.AddWithValue("Status", _sStatus);
                cmd.Parameters.AddWithValue("AuthenticateMode", _sAuthenticateMode);
                cmd.Parameters.AddWithValue("ActivatedBy", _sActivatedBy);
                cmd.Parameters.AddWithValue("ActivatedDate", _dActivatedDate);
                cmd.Parameters.AddWithValue("BLLMarketGroup", _nBLLMarketGroup);
                cmd.Parameters.AddWithValue("VersionNo", _sVersionNo);
                cmd.Parameters.AddWithValue("AndroidAppID", _nAndroidAppID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);

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
                sSql = "UPDATE t_A_UserRegistration SET  Status = ?, AuthenticateMode = ?, ActivatedBy = ?, ActivatedDate = ?, AndroidAppID = ?, EmployeeID = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("Status", _sStatus);
                cmd.Parameters.AddWithValue("AuthenticateMode", _sAuthenticateMode);
                cmd.Parameters.AddWithValue("ActivatedBy", _sActivatedBy);
                cmd.Parameters.AddWithValue("ActivatedDate", _dActivatedDate);
                cmd.Parameters.AddWithValue("AndroidAppID", _nAndroidAppID);
                cmd.Parameters.AddWithValue("EmployeeID", _nEmployeeID);

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
                sSql = "DELETE FROM t_A_UserRegistration WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_A_UserRegistration where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sMobileNo = (string)reader["MobileNo"];
                    _sUserFullName = (string)reader["UserFullName"];
                    _sUserName = (string)reader["UserName"];
                    _sIMEINo = (string)reader["IMEINo"];
                    _sSIMSerialNo = (string)reader["SIMSerialNo"];
                    _dRequestDate = Convert.ToDateTime(reader["RequestDate"].ToString());
                    _sStatus = (string)reader["Status"];
                    _sAuthenticateMode = (string)reader["AuthenticateMode"];
                    _sActivatedBy = (string)reader["ActivatedBy"];
                    _dActivatedDate = Convert.ToDateTime(reader["ActivatedDate"].ToString());
                    _nBLLMarketGroup = (int)reader["BLLMarketGroup"];
                    _sVersionNo = (string)reader["VersionNo"];
                    _nAndroidAppID = (int)reader["AndroidAppID"];
                    _nEmployeeID = (int)reader["EmployeeID"];
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
    public class UserRegistrations : CollectionBase
    {
        public UserRegistration this[int i]
        {
            get { return (UserRegistration)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(UserRegistration oUserRegistration)
        {
            InnerList.Add(oUserRegistration);
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
            string sSql = "SELECT * FROM t_A_UserRegistration";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UserRegistration oUserRegistration = new UserRegistration();
                    oUserRegistration.ID = (int)reader["ID"];
                    oUserRegistration.MobileNo = (string)reader["MobileNo"];
                    oUserRegistration.UserFullName = (string)reader["UserFullName"];
                    oUserRegistration.UserName = (string)reader["UserName"];
                    oUserRegistration.IMEINo = (string)reader["IMEINo"];
                    oUserRegistration.SIMSerialNo = (string)reader["SIMSerialNo"];
                    oUserRegistration.RequestDate = Convert.ToDateTime(reader["RequestDate"].ToString());
                    oUserRegistration.Status = (string)reader["Status"];
                    oUserRegistration.AuthenticateMode = (string)reader["AuthenticateMode"];
                    oUserRegistration.ActivatedBy = (string)reader["ActivatedBy"];
                    oUserRegistration.ActivatedDate = Convert.ToDateTime(reader["ActivatedDate"].ToString());
                    oUserRegistration.BLLMarketGroup = (int)reader["BLLMarketGroup"];
                    oUserRegistration.VersionNo = (string)reader["VersionNo"];
                    oUserRegistration.AndroidAppID = (int)reader["AndroidAppID"];
                    oUserRegistration.EmployeeID = (int)reader["EmployeeID"];
                    InnerList.Add(oUserRegistration);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshData(DateTime dFromDate, DateTime dToDate, string sUserName, string sMobileNo, int nPermitedApp, string sStatus, bool IsCheck, int nEmployeeID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From (Select a.*,PermittedApp=Case when AndroidAppID=1 then 'CJ_Apps' "+
                       " when AndroidAppID=2 then 'CJ_Digital' "+
                       " when AndroidAppID=3 then 'CJ_Lighting' "+
                       " when AndroidAppID=-9 then 'All' else 'NotPermitted' end ,isnull(EmployeeName,'') EmployeeName From  "+
                       " (Select ID,MobileNo,isnull(UserFullName,'') UserFullName,isnull(UserName,'') UserName, "+
                       " isnull(IMEINo,'') IMEINo,isnull(SIMSerialNo,'') SIMSerialNo,isnull(RequestDate,'') RequestDate, "+
                       " isnull(Status,'InActive') Status,isnull(AuthenticateMode,'') AuthenticateMode, "+
                       " isnull(ActivatedBy,'')ActivatedBy,isnull(ActivatedDate,'') ActivatedDate,isnull(VersionNo,'') VersionNo, "+
                       " isnull(AndroidAppID,0) AndroidAppID,isnull(EmployeeID,0) EmployeeID from t_A_UserRegistration) a "+
                       " Left Outer Join  "+
                       " (Select * From t_Employee) b " +
                       " on a.EmployeeID=b.EmployeeID) Main where 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " AND RequestDate between '" + dFromDate + "' and '" + dToDate + "' and RequestDate<'" + dToDate + "' ";
            }

            if (sUserName != "")
            {
                sSql = sSql + " AND UserName like '%" + sUserName + "%'";
            }
            if (sMobileNo != "")
            {
                sSql = sSql + " AND MobileNo like '%" + sMobileNo + "%'";
            }
            if (nPermitedApp != -1)
            {
                sSql = sSql + " AND AndroidAppID=" + nPermitedApp + "";
            }
            if (sStatus != "--All--")
            {
                sSql = sSql + " AND Status='" + sStatus + "'";
            }
            if (nEmployeeID != 0)
            {
                sSql = sSql + " AND EmployeeID =" + nEmployeeID + "";
            }
            sSql = sSql + " Order by ID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UserRegistration oUserRegistration = new UserRegistration();
                    oUserRegistration.ID = (int)reader["ID"];
                    oUserRegistration.MobileNo = (string)reader["MobileNo"];
                    oUserRegistration.UserFullName = (string)reader["UserFullName"];
                    oUserRegistration.UserName = (string)reader["UserName"];
                    oUserRegistration.IMEINo = (string)reader["IMEINo"];
                    oUserRegistration.SIMSerialNo = (string)reader["SIMSerialNo"];
                    oUserRegistration.RequestDate = Convert.ToDateTime(reader["RequestDate"].ToString());
                    oUserRegistration.Status = (string)reader["Status"];
                    oUserRegistration.AuthenticateMode = (string)reader["AuthenticateMode"];
                    oUserRegistration.ActivatedBy = (string)reader["ActivatedBy"];
                    oUserRegistration.ActivatedDate = Convert.ToDateTime(reader["ActivatedDate"].ToString());
                    oUserRegistration.VersionNo = (string)reader["VersionNo"];
                    oUserRegistration.AndroidAppID = (int)reader["AndroidAppID"];
                    oUserRegistration.EmployeeID = (int)reader["EmployeeID"];
                    oUserRegistration.EmployeeName = (string)reader["EmployeeName"];
                    InnerList.Add(oUserRegistration);
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


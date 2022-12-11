// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Mar 08, 2017
// Time : 04:49 PM
// Description: Class for CSDSMSHistory.
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
    public class CSDSMSHistory
    {
        private int _nID;
        private int _nSMSModelID;
        private int _nJobID;
        private string _sJobNo;
        private string _sSMSText;
        private string _sMobileNo;
        private int _nStatus;
        private int _nIsAutoCreate;
        private int _nCreateUserID;
        private string _sCreateUserName;
        private object _dCreateDate;
        private int _nUpdateUserID;
        private string _sUpdateUserName;
        private object _dUpdateDate;

        private string _sServiceType;
        private string _sSmsModelStatus;
        private string _sSendTo;
        private int _nServerType;

        private int _nCancelUserID;
        private string _sCancelUserName;
        private object _oCancelDate;
        private string _sCancelReason;

        private object _oSendUserID;
        private object _oSendDate;
        private object _oOriginalSMS;


        // <summary>
        // Get set property for UpdateUserName
        // </summary>
        public string UpdateUserName
        {
            get { return _sUpdateUserName; }
            set { _sUpdateUserName = value; }
        }

        // <summary>
        // Get set property for CancelUserName
        // </summary>
        public string CancelUserName
        {
            get { return _sCancelUserName; }
            set { _sCancelUserName = value; }
        }
        
        // <summary>
        // Get set property for ServiceType
        // </summary>
        public string ServiceType
        {
            get { return _sServiceType; }
            set { _sServiceType = value; }
        }

        // <summary>
        // Get set property for SmsModelStatus
        // </summary>
        public string SmsModelStatus
        {
            get { return _sSmsModelStatus; }
            set { _sSmsModelStatus = value; }
        }
        // <summary>
        // Get set property for SendTo
        // </summary>
        public string SendTo
        {
            get { return _sSendTo; }
            set { _sSendTo = value; }
        }


        // <summary>
        // Get set property for CreateUserName
        // </summary>
        public string CreateUserName
        {
            get { return _sCreateUserName; }
            set { _sCreateUserName = value; }
        }

        // <summary>
        // Get set property for JobNo
        // </summary>
        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value; }
        }

        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for SMSModelID
        // </summary>
        public int SMSModelID
        {
            get { return _nSMSModelID; }
            set { _nSMSModelID = value; }
        }

        // <summary>
        // Get set property for JobID
        // </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }

        // <summary>
        // Get set property for SMSText
        // </summary>
        public string SMSText
        {
            get { return _sSMSText; }
            set { _sSMSText = value.Trim(); }
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
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        // <summary>
        // Get set property for IsAutoCreate
        // </summary>
        public int IsAutoCreate
        {
            get { return _nIsAutoCreate; }
            set { _nIsAutoCreate = value; }
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
        public object CreateDate
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
        public object UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        public int ServerType
        {
            get { return _nServerType; }
            set { _nServerType = value; }
        }



        // <summary>
        // Get set property for SendUserID
        // </summary>
        public object SendUserID
        {
            get { return _oSendUserID; }
            set { _oSendUserID = value; }
        }

        // <summary>
        // Get set property for SendDate
        // </summary>
        public object SendDate
        {
            get { return _oSendDate; }
            set { _oSendDate = value; }
        }

        // <summary>
        // Get set property for OriginalSMS
        // </summary>
        public object OriginalSMS
        {
            get { return _oOriginalSMS; }
            set { _oOriginalSMS = value; }
        }

        // <summary>
        // Get set property for CancelUserID
        // </summary>
        public int CancelUserID
        {
            get { return _nCancelUserID; }
            set { _nCancelUserID = value; }
        }

        // <summary>
        // Get set property for CancelDate
        // </summary>
        public object CancelDate
        {
            get { return _oCancelDate; }
            set { _oCancelDate = value; }
        }
        // <summary>
        // Get set property for CancelReason
        // </summary>
        public string CancelReason
        {
            get { return _sCancelReason; }
            set { _sCancelReason = value; }
        }
        

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CSDSMSHistory";
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
                sSql = "INSERT INTO t_CSDSMSHistory (ID, SMSModelID, JobID, SMSText, MobileNo, Status, IsAutoCreate, CreateUserID, CreateDate, OriginalSMS) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("SMSModelID", _nSMSModelID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("SMSText", _sSMSText);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("IsAutoCreate", _nIsAutoCreate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("OriginalSMS", _sSMSText);
                
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
                sSql = "UPDATE t_CSDSMSHistory SET SMSModelID = ?,  SMSText = ?, MobileNo = ?, UpdateUserID = ?, UpdateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SMSModelID", _nSMSModelID);
                //cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("SMSText", _sSMSText);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                //cmd.Parameters.AddWithValue("Status", _nStatus);
                //cmd.Parameters.AddWithValue("IsAutoCreate", _nIsAutoCreate);
                //cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                //cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void SMSCancel()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CSDSMSHistory SET Status = ?,CancelUserID=?,CancelDate=?,CancelReason=? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CancelUserID", _nCancelUserID);
                cmd.Parameters.AddWithValue("CancelDate", _oCancelDate);
                cmd.Parameters.AddWithValue("CancelReason", _sCancelReason);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void SendStatusUpdate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CSDSMSHistory SET SendUserID = ?,SendDate=? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SendUserID", _oSendUserID);
                cmd.Parameters.AddWithValue("SendDate", _oSendDate);
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
                sSql = "DELETE FROM t_CSDSMSHistory WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_CSDSMSHistory where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nSMSModelID = (int)reader["SMSModelID"];
                    _nJobID = (int)reader["JobID"];
                    _sSMSText = (string)reader["SMSText"];
                    _sMobileNo = (string)reader["MobileNo"];
                    _nStatus = (int)reader["Status"];
                    _nIsAutoCreate = (int)reader["IsAutoCreate"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = (object)(reader["CreateDate"]);
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = (object)(reader["UpdateDate"]);
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void StatusUpdate(int nStatus)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CSDSMSHistory SET Status = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", nStatus);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class CSDSMSHistorys : CollectionBase
    {
        public CSDSMSHistory this[int i]
        {
            get { return (CSDSMSHistory)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDSMSHistory oCSDSMSHistory)
        {
            InnerList.Add(oCSDSMSHistory);
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
            string sSql = "SELECT * FROM t_CSDSMSHistory";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDSMSHistory oCSDSMSHistory = new CSDSMSHistory();
                    oCSDSMSHistory.ID = (int)reader["ID"];
                    oCSDSMSHistory.SMSModelID = (int)reader["SMSModelID"];
                    oCSDSMSHistory.JobID = (int)reader["JobID"];
                    oCSDSMSHistory.SMSText = (string)reader["SMSText"];
                    oCSDSMSHistory.MobileNo = (string)reader["MobileNo"];
                    oCSDSMSHistory.Status = (int)reader["Status"];
                    oCSDSMSHistory.IsAutoCreate = (int)reader["IsAutoCreate"];
                    oCSDSMSHistory.CreateUserID = (int)reader["CreateUserID"];
                    oCSDSMSHistory.CreateDate = (object)(reader["CreateDate"]);
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        oCSDSMSHistory.UpdateUserID = (int)reader["UpdateUserID"];
                    }
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        oCSDSMSHistory.UpdateDate = (object)(reader["UpdateDate"]);
                    }                
                    InnerList.Add(oCSDSMSHistory);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByJobID(int nJobID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT a.ID,a.SMSModelID,a.JobID,a.SMSText,a.MobileNo,a.Status,a.IsAutoCreate, "
                          +"a.CreateUserID , a.CreateDate, a.UpdateUserID,a.UpdateDate,ISNULL(SendDate,CreateDate) SendDate,u.UserName "
                          +"FROM t_CSDSMSHistory a INNER JOIN t_User u ON a.CreateUserID = u.UserID "
                          +"Where JobID = " + nJobID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDSMSHistory oCSDSMSHistory = new CSDSMSHistory();
                    oCSDSMSHistory.ID = (int)reader["ID"];
                    oCSDSMSHistory.SMSModelID = (int)reader["SMSModelID"];
                    oCSDSMSHistory.JobID = (int)reader["JobID"];
                    oCSDSMSHistory.SMSText = (string)reader["SMSText"];
                    oCSDSMSHistory.MobileNo = (string)reader["MobileNo"];
                    oCSDSMSHistory.Status = (int)reader["Status"];
                    oCSDSMSHistory.IsAutoCreate = (int)reader["IsAutoCreate"];
                    oCSDSMSHistory.CreateUserID = (int)reader["CreateUserID"];
                    oCSDSMSHistory.CreateDate = (object)(reader["CreateDate"]);
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        oCSDSMSHistory.UpdateUserID = (int)reader["UpdateUserID"];
                    }
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        oCSDSMSHistory.UpdateDate = (object)(reader["UpdateDate"]);
                    }
                    if (reader["SendDate"] != DBNull.Value)
                    {
                        oCSDSMSHistory.SendDate = (object)reader["SendDate"];
                    }
                    oCSDSMSHistory.CreateUserName = (string)reader["UserName"];
                    InnerList.Add(oCSDSMSHistory);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Getdata(string sJobNo, string sMobileNo, int nStatus,int nSMSSlength)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT a.*,J.JobNo,U.UserName,M.ServiceType,M.Status AS SmsModelStatus, "
                          + "ISNULL(uu.UserName,'') AS UpdateUserName,ISNULL(cu.UserName,'') AS CancelUserName, "
                          + "M.SendTo,a.UpdateDate,a.CancelDate," 
                          + "M.ServerType  FROM t_CSDSMSHistory a "
                          + "INNER JOIN t_CSDJob J ON a.JobID = J.JobID "
                          + "INNER JOIN t_User U ON a.CreateUserID = U.UserID "
                          + "LEFT JOIN t_User uu ON uu.UserID = a.UpdateUserID "
                          + "LEFT JOIN t_User cu ON cu.UserID = a.CancelUserID "
                          + "INNER JOIN t_CSDSMSModel M ON M.ID = a.SMSModelID Where 1=1 ";
            
            if (sJobNo != string.Empty)
            {
                sSql += "AND J.JobNo = '" + sJobNo + "' ";
            }
            if (sMobileNo != string.Empty)
            {
                sSql += "AND a.MobileNo = '" + sMobileNo + "' ";
            }
            if (nStatus != -1)
            {
                sSql += " AND a.Status = " + nStatus + " ";
            }
            if (nSMSSlength == 1)
            {
                sSql += " AND LEN(SMSText) <= 160 ";
            }
            else if (nSMSSlength == 2)
            {
                sSql += " AND LEN(SMSText) > 160 ";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDSMSHistory oCSDSMSHistory = new CSDSMSHistory();
                    oCSDSMSHistory.ID = (int)reader["ID"];
                    
                    oCSDSMSHistory.SMSModelID = (int)reader["SMSModelID"];
                    oCSDSMSHistory.JobID = (int)reader["JobID"];
                    oCSDSMSHistory.JobNo = (string)reader["JobNo"];
                    oCSDSMSHistory.SMSText = (string)reader["SMSText"];
                    oCSDSMSHistory.MobileNo = (string)reader["MobileNo"];
                    oCSDSMSHistory.Status = (int)reader["Status"];
                    oCSDSMSHistory.IsAutoCreate = (int)reader["IsAutoCreate"];
                    oCSDSMSHistory.CreateUserID = (int)reader["CreateUserID"];
                    oCSDSMSHistory.CreateUserName = (string)reader["UserName"];
                    oCSDSMSHistory.CreateDate = (object)(reader["CreateDate"]);
                    oCSDSMSHistory.ServerType = Convert.ToInt32(reader["ServerType"]);
                    oCSDSMSHistory.ServiceType = (string)reader["ServiceType"];
                    oCSDSMSHistory.SmsModelStatus = (string)reader["SmsModelStatus"];
                    oCSDSMSHistory.SendTo = (string)reader["SendTo"];
                    if (reader["OriginalSMS"]!= DBNull.Value)
                    oCSDSMSHistory.OriginalSMS = (object)reader["OriginalSMS"];
                    if (reader["UpdateDate"] != DBNull.Value) {
                        oCSDSMSHistory.UpdateDate = (object)reader["UpdateDate"];
                    }
                    if (reader["CancelDate"] != DBNull.Value) {
                        oCSDSMSHistory.CancelDate = (object)reader["CancelDate"];
                    }
                    oCSDSMSHistory.UpdateUserName = (string)reader["UpdateUserName"];
                    oCSDSMSHistory.CancelUserName = (string)reader["CancelUserName"];
                    if (reader["CancelReason"] != DBNull.Value)
                    {
                        oCSDSMSHistory.CancelReason = (string)reader["CancelReason"];
                    }
                    InnerList.Add(oCSDSMSHistory);
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


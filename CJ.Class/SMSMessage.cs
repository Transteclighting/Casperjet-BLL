
// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD. Abdul Hakim
// Date: Mar 24, 2015
// Time : 03:29 PM
// Description: Class for SMSMessage.
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
    public class SMSMessage
    {
        private int _nSMSMessageID;
        private DateTime _dRequestDate;
        private string _sSMSText;
        private int _nSMSType;
        private string _sSingleMobileNo;
        private DateTime _dSendDate;
        private int _nStatus;
        private string _sSubmittedBy;
        private string _sUserGroupName;
        private int _nSuccessCount;
        private int _nFailCount;
        private object _nEmployeeId;


        // <summary>
        // Get set property for SMSMessageID
        // </summary>
        public int SMSMessageID
        {
            get { return _nSMSMessageID; }
            set { _nSMSMessageID = value; }
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
        // Get set property for SMSText
        // </summary>
        public string SMSText
        {
            get { return _sSMSText; }
            set { _sSMSText = value.Trim(); }
        }

        // <summary>
        // Get set property for SMSType
        // </summary>
        public int SMSType
        {
            get { return _nSMSType; }
            set { _nSMSType = value; }
        }

        // <summary>
        // Get set property for SingleMobileNo
        // </summary>
        public string SingleMobileNo
        {
            get { return _sSingleMobileNo; }
            set { _sSingleMobileNo = value.Trim(); }
        }

        // <summary>
        // Get set property for SendDate
        // </summary>
        public DateTime SendDate
        {
            get { return _dSendDate; }
            set { _dSendDate = value; }
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
        // Get set property for SubmittedBy
        // </summary>
        public string SubmittedBy
        {
            get { return _sSubmittedBy; }
            set { _sSubmittedBy = value.Trim(); }
        }

        // <summary>
        // Get set property for UserGroupName
        // </summary>
        public string UserGroupName
        {
            get { return _sUserGroupName; }
            set { _sUserGroupName = value.Trim(); }
        }

        // <summary>
        // Get set property for SuccessCount
        // </summary>
        public int SuccessCount
        {
            get { return _nSuccessCount; }
            set { _nSuccessCount = value; }
        }

        // <summary>
        // Get set property for FailCount
        // </summary>
        public int FailCount
        {
            get { return _nFailCount; }
            set { _nFailCount = value; }
        }

        public object EmployeeId
        {
            get { return _nEmployeeId; }
            set { _nEmployeeId = value; }
        }

        public void Add()
        {
            int nMaxSMSMessageID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([SMSMessageID]) FROM t_SMSMessage";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSMSMessageID = 1;
                }
                else
                {
                    nMaxSMSMessageID = Convert.ToInt32(maxID) + 1;
                }
                _nSMSMessageID = nMaxSMSMessageID;
                sSql = "INSERT INTO t_SMSMessage (SMSMessageID, RequestDate, SMSText, SMSType, SingleMobileNo, SendDate, Status, SubmittedBy, UserGroupName, SuccessCount, FailCount, EmployeeId) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SMSMessageID", _nSMSMessageID);
                cmd.Parameters.AddWithValue("RequestDate", _dRequestDate);
                cmd.Parameters.AddWithValue("SMSText", _sSMSText);
                cmd.Parameters.AddWithValue("SMSType", _nSMSType);
                cmd.Parameters.AddWithValue("SingleMobileNo", _sSingleMobileNo);
                cmd.Parameters.AddWithValue("SendDate", _dSendDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("SubmittedBy", _sSubmittedBy);
                cmd.Parameters.AddWithValue("UserGroupName", _sUserGroupName);
                cmd.Parameters.AddWithValue("SuccessCount", _nSuccessCount);
                cmd.Parameters.AddWithValue("FailCount", _nFailCount);
                cmd.Parameters.AddWithValue("EmployeeId", _nEmployeeId);
                

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
                sSql = "UPDATE t_SMSMessage SET RequestDate = ?, SMSText = ?, SMSType = ?, SingleMobileNo = ?, SendDate = ?, Status = ?, SubmittedBy = ?, UserGroupName = ?, SuccessCount = ?, FailCount = ? WHERE SMSMessageID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RequestDate", _dRequestDate);
                cmd.Parameters.AddWithValue("SMSText", _sSMSText);
                cmd.Parameters.AddWithValue("SMSType", _nSMSType);
                cmd.Parameters.AddWithValue("SingleMobileNo", _sSingleMobileNo);
                cmd.Parameters.AddWithValue("SendDate", _dSendDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("SubmittedBy", _sSubmittedBy);
                cmd.Parameters.AddWithValue("UserGroupName", _sUserGroupName);
                cmd.Parameters.AddWithValue("SuccessCount", _nSuccessCount);
                cmd.Parameters.AddWithValue("FailCount", _nFailCount);

                cmd.Parameters.AddWithValue("SMSMessageID", _nSMSMessageID);

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
                sSql = "DELETE FROM t_SMSMessage WHERE [SMSMessageID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SMSMessageID", _nSMSMessageID);
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
                cmd.CommandText = "SELECT * FROM t_SMSMessage where SMSMessageID =?";
                cmd.Parameters.AddWithValue("SMSMessageID", _nSMSMessageID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nSMSMessageID = (int)reader["SMSMessageID"];
                    _dRequestDate = Convert.ToDateTime(reader["RequestDate"].ToString());
                    _sSMSText = (string)reader["SMSText"];
                    _nSMSType = (int)reader["SMSType"];
                    _sSingleMobileNo = (string)reader["SingleMobileNo"];
                    _dSendDate = Convert.ToDateTime(reader["SendDate"].ToString());
                    _nStatus = (int)reader["Status"];
                    _sSubmittedBy = (string)reader["SubmittedBy"];
                    _sUserGroupName = (string)reader["UserGroupName"];
                    _nSuccessCount = (int)reader["SuccessCount"];
                    _nFailCount = (int)reader["FailCount"];
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
    public class SMSMessages : CollectionBase
    {
        public SMSMessage this[int i]
        {
            get { return (SMSMessage)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SMSMessage oSMSMessage)
        {
            InnerList.Add(oSMSMessage);
        }
        public int GetIndex(int nSMSMessageID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].SMSMessageID == nSMSMessageID)
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
            string sSql = "SELECT * FROM t_SMSMessage";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SMSMessage oSMSMessage = new SMSMessage();
                    oSMSMessage.SMSMessageID = (int)reader["SMSMessageID"];
                    oSMSMessage.RequestDate = Convert.ToDateTime(reader["RequestDate"].ToString());
                    oSMSMessage.SMSText = (string)reader["SMSText"];
                    oSMSMessage.SMSType = (int)reader["SMSType"];
                    oSMSMessage.SingleMobileNo = (string)reader["SingleMobileNo"];
                    oSMSMessage.SendDate = Convert.ToDateTime(reader["SendDate"].ToString());
                    oSMSMessage.Status = (int)reader["Status"];
                    oSMSMessage.SubmittedBy = (string)reader["SubmittedBy"];
                    oSMSMessage.UserGroupName = (string)reader["UserGroupName"];
                    oSMSMessage.SuccessCount = (int)reader["SuccessCount"];
                    oSMSMessage.FailCount = (int)reader["FailCount"];
                    InnerList.Add(oSMSMessage);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetMobileNoByGroup(int nGroupID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select MobileNo, SMSGroupName from dbo.t_SMSGroupPerson a,dbo.t_MobilePhone b, dbo.t_SMSGroup c " +
                          "Where a.MobileID=b.MobileID and a.SMSGroupID=c.SMSGroupID and a.SMSGroupID=" + nGroupID + "";
            
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SMSMessage oSMSMessage = new SMSMessage();

                    oSMSMessage.SingleMobileNo = (string)reader["MobileNo"];
                    oSMSMessage.UserGroupName = (string)reader["SMSGroupName"];
                    InnerList.Add(oSMSMessage);
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



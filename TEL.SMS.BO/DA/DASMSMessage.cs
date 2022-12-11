using System;
using System.Collections.Generic;
using System.Text;
using TEL.SMS.BO.BE;
using System.Data.OleDb;
using System.Diagnostics;

namespace TEL.SMS.BO.DA
{    
    public enum  DateMessage
    {
        DateMessage
    }
    public class DASMSMessage
    {
           
        public void Insert(DSSMSMessage oDSSMSMessage)
        {
            OleDbCommand cmd=new OleDbCommand();

            foreach (DSSMSMessage.SMSMessageRow oSMSMessageRow in oDSSMSMessage.SMSMessage)
            {
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_SMSMessage(SMSMessageID, RequestDate, SMSText,"
                    + " SMSType, SingleMobileNo, SendDate, Status, SubmittedBy, UserGroupName)"
                    + " VALUES(?,?,?,?,?,?,?,?,?)";
                oSMSMessageRow.SMSMessageID = getNewID();
                cmd.Parameters.AddWithValue("SMSMessageID", oSMSMessageRow.SMSMessageID);
                cmd.Parameters.AddWithValue("RequestDate", oSMSMessageRow.RequestDate);
                cmd.Parameters.AddWithValue("SMSText", oSMSMessageRow.SMSText);
                cmd.Parameters.AddWithValue("SMSType", oSMSMessageRow.SMSType);
                if (oSMSMessageRow.IsSingleMobileNoNull())
                {
                    cmd.Parameters.AddWithValue("SingleMobileNo", System.DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("SingleMobileNo", (object)oSMSMessageRow.SingleMobileNo);
                }

                if (oSMSMessageRow.IsSendDateNull())
                {
                    cmd.Parameters.AddWithValue("SendDate", System.DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("SendDate", (object)oSMSMessageRow.SendDate.Date);
                }
                cmd.Parameters.AddWithValue("Status", oSMSMessageRow.Status);
                
                cmd.Parameters.AddWithValue("SubmittedBy", oSMSMessageRow.SubmittedBy);

                cmd.Parameters.AddWithValue("UserGroupName", oSMSMessageRow.UserGroupName);
                cmd.ExecuteNonQuery();
                
                foreach (DSSMSMessage.SMSMessageGroupRow oSMSMessageGroupRow in oDSSMSMessage.SMSMessageGroup)
                {
                    cmd.Dispose();
                    cmd = DBController.Instance.GetCommand();

                    cmd.CommandText = "INSERT INTO t_SMSMessageGroup(SMSMessageID,SMSGroupID) VALUES(?,?)";

                    oSMSMessageGroupRow.SMSMessageID = oSMSMessageRow.SMSMessageID;
                    cmd.Parameters.AddWithValue("SMSMessageID", oSMSMessageGroupRow.SMSMessageID);
                    cmd.Parameters.AddWithValue("SMSGroupID", oSMSMessageGroupRow.SMSGroupID);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        private long getNewID()
        {
            long nNextID;
            Utility oUtil = new Utility();
            nNextID = oUtil.GenerateID("t_SMSMessage", "SMSMessageID");
            return nNextID;
        }

        public void Update(DSSMSMessage oDSSMSMessage)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            foreach (DSSMSMessage.SMSMessageRow oSMSMessageRow in oDSSMSMessage.SMSMessage)
            {
                cmd.CommandText = "UPDATE t_SMSMessage SET RequestDate=?, SMSText=?,"
                    + " SMSType=?, SingleMobileNo=?, SendDate=?, Status=?,SubmittedBy=?, UserGroupName=?"
                    + " WHERE SMSMessageID=?";
                cmd.Parameters.AddWithValue("RequestDate", oSMSMessageRow.RequestDate);
                cmd.Parameters.AddWithValue("SMSText", oSMSMessageRow.SMSText);
                cmd.Parameters.AddWithValue("SMSType", oSMSMessageRow.SMSType);
                if (oSMSMessageRow.IsSingleMobileNoNull())
                {
                    cmd.Parameters.AddWithValue("SingleMobileNo", System.DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("SingleMobileNo", (object)oSMSMessageRow.SingleMobileNo);
                }

                if (oSMSMessageRow.IsSendDateNull())
                {
                    cmd.Parameters.AddWithValue("SendDate", System.DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("SendDate", (object)oSMSMessageRow.SendDate.Date);
                }
                cmd.Parameters.AddWithValue("Status", oSMSMessageRow.Status);
                
                cmd.Parameters.AddWithValue("SubmittedBy", oSMSMessageRow.SubmittedBy);

                cmd.Parameters.AddWithValue("UserGroupName", oSMSMessageRow.UserGroupName);

                cmd.Parameters.AddWithValue("SMSMessageID", oSMSMessageRow.SMSMessageID);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStatus(long nSMSMessageID, SMSMessageStatus nStatus)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd.CommandText = "UPDATE t_SMSMessage SET Status=?"
                + " WHERE SMSMessageID=?";
            cmd.Parameters.AddWithValue("Status", nStatus);
            cmd.Parameters.AddWithValue("SMSMessageID", nSMSMessageID);
            cmd.ExecuteNonQuery();
        }

        public void Delete(DSSMSMessage oDSSMSMessage)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            foreach (DSSMSMessage.SMSMessageRow oSMSMessageRow in oDSSMSMessage.SMSMessage)
            {
                cmd.CommandText = "DELETE FROM t_SMSMessage WHERE SMSMessageID=?";
                cmd.Parameters.AddWithValue("SMSMessageID", oSMSMessageRow.SMSMessageID);
                cmd.ExecuteNonQuery();
            }
        }

        public void GetSMSMessage(DSSMSMessage oDSSMSMessage)
        {
            long nSMSMessageID = oDSSMSMessage.SMSMessage[0].SMSMessageID;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();


            adapter.SelectCommand = cmd;
            try
            {
                oDSSMSMessage.Clear();
                cmd.CommandText = "SELECT * FROM t_SMSMessage WHERE SMSMesageID=?";
                cmd.Parameters.AddWithValue("SMSMessageID", nSMSMessageID);
                adapter.Fill(oDSSMSMessage, "SMSMessage");

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                adapter.SelectCommand = cmd;
                cmd.CommandText = "SELECT * FROM t_SMSMessageGroup WHERE SMSMessageID=?";
                cmd.Parameters.AddWithValue("SMSMessageID", nSMSMessageID);
                adapter.Fill(oDSSMSMessage, "SMSMessageGroup");

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void GetSMSMessagesAll(DSSMSMessage oDSSMSMessage,DateTime dfromDt,DateTime dtoDt,DateMessage nDateType)
        {
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            if (nDateType == DateMessage.DateMessage)
            {
                sSQL = "SELECT * FROM t_SMSMessage"
                + " WHERE RequestDate>=? AND RequestDate<=?";
            }
            else 
            {
                sSQL = "SELECT * FROM t_SMSMessage";
                
            }

            cmd.CommandText = sSQL;
            cmd.Parameters.AddWithValue("RequestDate",dfromDt);
            cmd.Parameters.AddWithValue("RequestDate",dtoDt);
            adapter.SelectCommand = cmd;
            try
            {
                oDSSMSMessage.Clear();
                adapter.Fill(oDSSMSMessage, "SMSMessage");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void GetSMSMessages(DSSMSMessage oDSSMSMessage, string sUserGroupName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.CommandText = "SELECT * FROM t_SMSMessage WHERE UserGroupName=?";
            adapter.SelectCommand = cmd;
            try
            {
                cmd.Parameters.AddWithValue("UserGroupName", sUserGroupName);
                oDSSMSMessage.Clear();
                adapter.Fill(oDSSMSMessage, "SMSMessage");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void GetSMSMessages(DSSMSMessage oDSSMSMessage, SMSMessageStatus nStatus, DateTime dfromDt, DateTime dtoDt, DateMessage nDateType)
        {
            string sSQL1 = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            if (nDateType == DateMessage.DateMessage)
            {
                sSQL1 = "SELECT * FROM t_SMSMessage"
                + " WHERE RequestDate>=? AND RequestDate<? AND Status=?";
            }
            else
            {
                sSQL1 = "SELECT * FROM t_SMSMessage";

            }


            cmd.CommandText = sSQL1;
            cmd.Parameters.AddWithValue("RequestDate", dfromDt);
            cmd.Parameters.AddWithValue("RequestDate", dtoDt.AddDays(1));
            adapter.SelectCommand = cmd;
            try
            {
                cmd.Parameters.AddWithValue("Status", (int)nStatus);
                oDSSMSMessage.Clear();
                adapter.Fill(oDSSMSMessage, "SMSMessage");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void GetSMSMessages(DSSMSMessage oDSSMSMessage, SMSMessageStatus nStatus,string sUserGroupName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.CommandText = "SELECT * FROM t_SMSMessage WHERE Status=? AND UserGroupName=?";
            adapter.SelectCommand = cmd;
            try
            {
                cmd.Parameters.AddWithValue("Status", (int)nStatus);
                cmd.Parameters.AddWithValue("UserGroupName", sUserGroupName);
                oDSSMSMessage.Clear();
                adapter.Fill(oDSSMSMessage, "SMSMessage");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

    }
}

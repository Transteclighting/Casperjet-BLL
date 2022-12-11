using System;
using System.Collections.Generic;
using System.Text;
using TEL.SMS.BO.BE;
using System.Data.OleDb;
using System.Diagnostics;

namespace TEL.SMS.BO.DA
{
    public enum DateMessageIn
    {
        DateMessageIn
    }
    public class DASMSMessageIn
    {        

        public void GetSMSMessageIn(DSSMSMessageIn  oDSSMSMessageIn)
        {
            long nSMSMessageID = oDSSMSMessageIn.SMSInMessage[0].SMSMessageID;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();


            adapter.SelectCommand = cmd;
            try
            {
                oDSSMSMessageIn.Clear();
                cmd.CommandText = "SELECT * FROM t_SMSInMessage WHERE SMSMessageID=?";
                cmd.Parameters.AddWithValue("SMSMessageID", nSMSMessageID);
                adapter.Fill(oDSSMSMessageIn, "SMSInMessage");

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                adapter.SelectCommand = cmd;
                cmd.CommandText = "SELECT * FROM t_SMSMessageGroup WHERE SMSMessageID=?";
                cmd.Parameters.AddWithValue("SMSMessageID", nSMSMessageID);
                adapter.Fill(oDSSMSMessageIn, "SMSMessageGroup");

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void GetSMSMessagesAllIn(DSSMSMessageIn oDSSMSMessageIn, DateTime dfromDt, DateTime dtoDt, DateMessageIn nDateType)
        {
            string sSQL2 = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            if (nDateType == DateMessageIn.DateMessageIn)
            {
                sSQL2 = "SELECT * FROM t_SMSInMessage"
                + " WHERE ReceiveDate>=? AND ReceiveDate<?";
            }
            else
            {
                sSQL2 = "SELECT * FROM t_SMSInMessage";

            }

            cmd.CommandText = sSQL2;
            cmd.Parameters.AddWithValue("ReceiveDate", dfromDt);
            cmd.Parameters.AddWithValue("ReceiveDate", dtoDt.AddDays(1));
            adapter.SelectCommand = cmd;
            try
            {
                oDSSMSMessageIn.Clear();
                adapter.Fill(oDSSMSMessageIn, "SMSInMessage");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void GetSMSMessagesIn(DSSMSMessageIn  oDSSMSMessageIn, string sUserGroupName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.CommandText = "SELECT * FROM t_SMSMessage WHERE UserGroupName=?";
            adapter.SelectCommand = cmd;
            try
            {
                cmd.Parameters.AddWithValue("UserGroupName", sUserGroupName);
                oDSSMSMessageIn.Clear();
                adapter.Fill(oDSSMSMessageIn, "SMSMessage");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void GetSMSMessagesIn(DSSMSMessageIn oDSSMSMessageIn, SMSMessageStatus nStatus)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.CommandText = "SELECT * FROM t_SMSInMessage WHERE Status=?";
            adapter.SelectCommand = cmd;
            try
            {
                cmd.Parameters.AddWithValue("Status", (int)nStatus);
                oDSSMSMessageIn.Clear();
                adapter.Fill(oDSSMSMessageIn, "SMSInMessage");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void GetSMSMessagesIn(DSSMSMessageIn oDSSMSMessage, SMSMessageStatus nStatus, string sUserGroupName)
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

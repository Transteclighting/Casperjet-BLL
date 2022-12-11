using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Diagnostics;
using System.Configuration;
using System.Security.Principal; 
using TEL.SMS.BO.DA;

namespace TEL.SMS.BO
{

    /// <summary>
    /// Enum for SMS Message Type.
    /// </summary>
    public enum SMSMessageType
    {
        Group,
        Individual,

    }

    /// <summary>
    /// Enum for SMS Message Status.
    /// </summary>
    public enum SMSMessageStatus
    {
        Submitted,
        Approved,
        Sent,
        Failed,
        Cancelled,
    }

    /// <summary>
    /// Enum for SMS Message Status.
    /// </summary>
    public enum WarrantyRegMode
    {
        SMS,
        Final,
    }

    /// <summary>
    /// Summary description for Utility.
    /// </summary>
    public class Utility
    {
        public Utility()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public long GenerateID(string sTableName, string sFieldName)
        {
            sFieldName = "[" + sFieldName + "]";
            sTableName = "[" + sTableName + "]";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            cmd.CommandText = "SELECT MAX(" + sFieldName + ") FROM " + sTableName;
            object oMaxID = cmd.ExecuteScalar();
            long nNextID;
            if (oMaxID.Equals(DBNull.Value))
            {
                nNextID = 1;
            }
            else
            {
                nNextID = Convert.ToInt64(oMaxID) + 1;
            }
            Debug.WriteLine("New ID is " + nNextID);
            return nNextID;
        }

        public long GenerateID(string sTableName, string sFieldName, string sSQLClause)
        {
            sFieldName = "[" + sFieldName + "]";
            sTableName = "[" + sTableName + "]";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            cmd.CommandText = "SELECT MAX(" + sFieldName + ") FROM " + sTableName + sSQLClause;
            object oMaxID = cmd.ExecuteScalar();
            long nNextID;
            if (oMaxID.Equals(DBNull.Value))
            {
                nNextID = 1;
            }
            else
            {
                nNextID = Convert.ToInt64(oMaxID) + 1;
            }
            Debug.WriteLine("New ID is " + nNextID);
            return nNextID;
        }

        public static string GetUserName()
        {
            return WindowsIdentity.GetCurrent().Name;
        }
        public static string GetUserGroupName()
        {
            return ConfigurationManager.AppSettings["UserGroup"];
        }
    }
}

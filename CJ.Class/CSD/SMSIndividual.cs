
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Collections;
    using System.Data;
    using System.Data.OleDb;
    using CJ.Class;

    namespace CJ.Class.CSD
    {
    public class SMSMessageInividualHistory
    {
    private int _nID; 
    private string _sMessage; 
    private string _sMobileNo; 
    private int _nSendBy; 
    private DateTime _dSendDate; 

     
    // <summary>
    // Get set property for ID
    // </summary>
    public int ID
     { 
           get { return  _nID; }
           set { _nID = value; }
     } 

    // <summary>
    // Get set property for Message
    // </summary>
    public string Message
     { 
           get { return  _sMessage; }
           set { _sMessage = value.Trim(); }
     } 

    // <summary>
    // Get set property for MobileNo
    // </summary>
    public string MobileNo
     { 
           get { return  _sMobileNo; }
           set { _sMobileNo = value.Trim(); }
     } 

    // <summary>
    // Get set property for SendBy
    // </summary>
    public int SendBy
     { 
           get { return  _nSendBy; }
           set { _nSendBy = value; }
     } 

    // <summary>
    // Get set property for SendDate
    // </summary>
    public DateTime SendDate
     { 
           get { return  _dSendDate; }
           set { _dSendDate = value; }
     } 

    public void Add()
     {
         int nMaxID = 0;
         OleDbCommand cmd = DBController.Instance.GetCommand();
         string sSql = "";
         try
         {
             sSql = "SELECT MAX([ID]) FROM t_SMSMessageInividualHistory";
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
             sSql = "INSERT INTO t_SMSMessageInividualHistory (ID, Message, MobileNo, SendBy, SendDate) VALUES(?,?,?,?,?)";
             cmd.CommandText = sSql;
             cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("ID",  _nID);
             cmd.Parameters.AddWithValue("Message",  _sMessage);
             cmd.Parameters.AddWithValue("MobileNo",  _sMobileNo);
             cmd.Parameters.AddWithValue("SendBy",  _nSendBy);
             cmd.Parameters.AddWithValue("SendDate",  _dSendDate);
     
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
             sSql = "UPDATE t_SMSMessageInividualHistory SET Message = ?, MobileNo = ?, SendBy = ?, SendDate = ? WHERE ID = ?";
             cmd.CommandText = sSql;
             cmd.CommandType = CommandType.Text;
     
             cmd.Parameters.AddWithValue("Message",  _sMessage);
             cmd.Parameters.AddWithValue("MobileNo",  _sMobileNo);
             cmd.Parameters.AddWithValue("SendBy",  _nSendBy);
             cmd.Parameters.AddWithValue("SendDate",  _dSendDate);
            
             cmd.Parameters.AddWithValue("ID",  _nID);
     
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
             sSql = "DELETE FROM t_SMSMessageInividualHistory WHERE [ID]=?";
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
             cmd.CommandText = "SELECT * FROM t_SMSMessageInividualHistory where ID =?";
             cmd.Parameters.AddWithValue("ID", _nID);
             cmd.CommandType = CommandType.Text;
             IDataReader reader = cmd.ExecuteReader();
             if (reader.Read())
             {
                 _nID = (int)reader["ID"];
                 _sMessage = (string)reader["Message"];
                 _sMobileNo = (string)reader["MobileNo"];
                 _nSendBy = (int)reader["SendBy"];
                 _dSendDate = Convert.ToDateTime(reader["SendDate"].ToString());
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
    public class SMSMessageInividualHistorys : CollectionBase
    {
    public SMSMessageInividualHistory this[int i]
    {
        get { return (SMSMessageInividualHistory)InnerList[i]; }
        set { InnerList[i] = value; }
    }
    public void Add(SMSMessageInividualHistory oSMSMessageInividualHistory)
    {
        InnerList.Add(oSMSMessageInividualHistory);
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
        string sSql = "SELECT * FROM t_SMSMessageInividualHistory";
        try
        {
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SMSMessageInividualHistory oSMSMessageInividualHistory = new SMSMessageInividualHistory();
                oSMSMessageInividualHistory.ID = (int)reader["ID"];
                 oSMSMessageInividualHistory.Message = (string)reader["Message"];
                 oSMSMessageInividualHistory.MobileNo = (string)reader["MobileNo"];
                 oSMSMessageInividualHistory.SendBy = (int)reader["SendBy"];
                 oSMSMessageInividualHistory.SendDate = Convert.ToDateTime(reader["SendDate"].ToString());
                 InnerList.Add(oSMSMessageInividualHistory);
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



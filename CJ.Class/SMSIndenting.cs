// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: March 28, 2011
// Time :  10:00 AM
// Description: Class for SMS Indenting
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class
{
    public class SMSIndenting
    {
        private int _nSMSmessageID;
        private int _nMessageType;
        private int _nStatus;
        private string _sSMSText;
        private string _sMobileNo;
        private DateTime _dReceiveDate;

        public int SMSmessageID
        {
            get { return _nSMSmessageID; }
            set { _nSMSmessageID = value; }
            
        }
        public int MessageType
        {
            get { return _nMessageType; }
            set { _nMessageType = value; }
        }
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        public string SMSText
        {
            get { return _sSMSText; }
            set { _sSMSText = value; }
        }
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value; }
        }
        public DateTime ReceiveDate
        {
            get { return _dReceiveDate; }
            set { _dReceiveDate = value; }
        }
        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "INSERT INTO t_SMSIndent VALUES(?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SMSMessageID", _nSMSmessageID);
                cmd.Parameters.AddWithValue("ReceiveDate", _dReceiveDate);
                cmd.Parameters.AddWithValue("SMSText",_sSMSText );
                cmd.Parameters.AddWithValue("MessageType", _nMessageType);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Update(int nSMSmessageID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            
            try
            {
                cmd.CommandText = " update t_SMSIndent set  status= ? where SMSMessageID= ?";
                cmd.Parameters.AddWithValue("status", 1);
                cmd.Parameters.AddWithValue("SMSMessageID", nSMSmessageID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
    public class SMSIndentings : CollectionBase
    {

        public SMSIndenting this[int i]
        {
            get { return (SMSIndenting)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SMSIndenting oSMSIndenting)
        {
            InnerList.Add(oSMSIndenting);
        }
        public SMSIndentings Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();        

            try
            {
                cmd.CommandText = "SELECT * FROM TELSysDB.dbo.t_SMSInMessage WHERE (SMSText LIKE 'LSO%') AND (SMSMessageID >(SELECT MAX(SMSmessageID) AS Expr1 FROM t_SMSIndent))";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SMSIndenting oSMSIndenting = new SMSIndenting();
                    oSMSIndenting.SMSmessageID = int.Parse(reader["SMSmessageID"].ToString());
                    oSMSIndenting.ReceiveDate = Convert.ToDateTime( reader["ReceiveDate"].ToString());
                    oSMSIndenting.SMSText = reader["SMSText"].ToString();
                    oSMSIndenting.MessageType = int.Parse(reader["MessageType"].ToString());
                    oSMSIndenting.MobileNo = reader["MobileNo"].ToString();
                    oSMSIndenting.Status = int.Parse(reader["Status"].ToString());
                    InnerList.Add(oSMSIndenting);
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
        public SMSIndentings GetSMSinfo(int nSMSmessageID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql="";
            if (nSMSmessageID == 0) sSql = "SELECT * FROM t_SMSIndent where Status='0'";
            else 
            {
                sSql = "select * from t_SMSIndent where SMSmessageID =?";
                cmd.Parameters.AddWithValue("SMSmessageID", nSMSmessageID);
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SMSIndenting oSMSIndenting = new SMSIndenting();
                    oSMSIndenting.SMSmessageID = int.Parse(reader["SMSmessageID"].ToString());
                    oSMSIndenting.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());
                    oSMSIndenting.SMSText = reader["SMSText"].ToString();
                    oSMSIndenting.MessageType = int.Parse(reader["MessageType"].ToString());
                    oSMSIndenting.MobileNo = reader["MobileNo"].ToString();
                    oSMSIndenting.Status = int.Parse(reader["Status"].ToString());
                    InnerList.Add(oSMSIndenting);
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
        public SMSIndentings GetDataForReport(DateTime dFromdate, DateTime dTofrom, int nStatus, string sMobileNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";

            sSql = "select * from t_SMSIndent where ReceiveDate between '" + dFromdate + "' and '" + dTofrom + "' and ReceiveDate < '" + dTofrom + "' ";

            if (sMobileNo != "")
            {
                sMobileNo = "%" + sMobileNo + "%";
                sSql = sSql + " and  MobileNo like '" + sMobileNo + "' ";
            }
            if (nStatus> -1)
            {
                sSql = sSql + " and status= '" + nStatus + "' ";
            }  
      
           
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SMSIndenting oSMSIndenting = new SMSIndenting();
                    oSMSIndenting.SMSmessageID = int.Parse(reader["SMSmessageID"].ToString());
                    oSMSIndenting.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());
                    oSMSIndenting.SMSText = reader["SMSText"].ToString();
                    oSMSIndenting.MessageType = int.Parse(reader["MessageType"].ToString());
                    oSMSIndenting.MobileNo = reader["MobileNo"].ToString();
                    oSMSIndenting.Status = int.Parse(reader["Status"].ToString());
                    InnerList.Add(oSMSIndenting);
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
    }
}

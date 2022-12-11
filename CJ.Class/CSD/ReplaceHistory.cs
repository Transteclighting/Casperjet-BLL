
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Apr 23, 2012
// Time :  2:31 PM
// Description: Class for Replace History Data.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class.CSD;

namespace CJ.Class.CSD
{
    public class ReplaceHistory
    {

        private int _nReplaceHistoryID;
        private int _nReplaceID;
        private int _nUserID;
        private string _sUserName;
        private int _nStatus;
        private string _sStatusName;
        private Object _dStatusDate;
        private Object _sRemarks;
       
        private User _oUser;
        private Replace _oReplace;
        private CourierFromCassandra _oCourierFromCassandra;


        /// <summary>
        /// Get set property for ReplaceHistoryID
        /// </summary>
        public int ReplaceHistoryID
        {
            get { return _nReplaceHistoryID; }
            set { _nReplaceHistoryID = value; }
        }
        /// <summary>
        /// Get set property for ReplaceID
        /// </summary>
        public int ReplaceID
        {
            get { return _nReplaceID; }
            set { _nReplaceID = value; }
        }
        /// <summary>
        /// Get set property for UserID
        /// </summary>
        public int UserID
        {
            get { return _nUserID; }
            set { _nUserID = value; }
        }
        /// <summary>
        /// Get set property for UserName
        /// </summary>
        public string UserName
        {
            get { return _sUserName; }
            set { _sUserName = value; }
        }
        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        /// <summary>
        /// Get set property for StatusName
        /// </summary>
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value; }
        }
        /// <summary>
        /// Get set property for StatusDate
        /// </summary>
        public Object StatusDate
        {
            get { return _dStatusDate; }
            set { _dStatusDate = value; }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public Object Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }

        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                    _oUser.UserId = _nUserID;
                    _oUser.RefreshByUserID();
                }
                return _oUser;
            }
        }
        public Replace Replace
        {
            get
            {
                if (_oReplace == null)
                {
                    _oReplace = new Replace();
                }
                return _oReplace;
            }
        }
        public void AddReplaceHistory()
        {
            int nMaxReplaceHistoryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ReplaceHistoryID]) FROM t_CSDReplaceHistory";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxReplaceHistoryID = 1;
                }
                else
                {
                    nMaxReplaceHistoryID = Convert.ToInt32(maxID) + 1;
                }
                _nReplaceHistoryID = nMaxReplaceHistoryID;


                sSql = "INSERT INTO t_CSDReplaceHistory(ReplaceHistoryID,ReplaceID,UserID,Status,StatusDate,Remarks) VALUES(?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ReplaceHistoryID", _nReplaceHistoryID);
                cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);
                cmd.Parameters.AddWithValue("UserID", Utility.UserId);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("StatusDate", DateTime.Now);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateReplaceHistoryRemarks()
        {           
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {

                cmd.CommandText = "Update t_CSDReplaceHistory SET Remarks=? Where ReplaceID=? and Status=?";
                cmd.CommandType = CommandType.Text;
            
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);
                cmd.Parameters.AddWithValue("Status", _nStatus);

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

            string sSql = "SELECT * FROM t_CSDReplaceHistory where ReplaceID=?";
            cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _dStatusDate = Convert.ToDateTime(reader["StatusDate"].ToString());
                    _nStatus = int.Parse(reader["Status"].ToString());
                    _sRemarks = (string)reader["Remarks"];
                    _nUserID = (int)reader["UserID"];
                }
                reader.Close();             

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckReplace()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDReplaceHistory where ReplaceID=? and Status=?";
            cmd.Parameters.AddWithValue("ReplaceID", _nReplaceID);
            cmd.Parameters.AddWithValue("Status", _nStatus);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _dStatusDate = Convert.ToDateTime(reader["StatusDate"].ToString());
                    _nStatus = int.Parse(reader["Status"].ToString());
                    _sRemarks = (string)reader["Remarks"];
                    _nUserID = (int)reader["UserID"];
                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return false;
            else return true;
        }
    }
    public class ReplaceHistorys : CollectionBase
    {
        public ReplaceHistory this[int i]
        {
            get { return (ReplaceHistory)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ReplaceHistory oReplaceHistory)
        {
            InnerList.Add(oReplaceHistory);
        }
        //public void Refresh()//String txtReplaceID
        //{

        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();

        //    string sSql = "SELECT * FROM t_CSDReplaceHistory Order by StatusDate";

        //    //if (txtReplaceID != "")
        //    //{
        //    //    //txtReplaceID = "%" + txtReplaceID + "%";
        //    //    sSql = sSql + " AND ReplaceID ='" + txtReplaceID + "'";
        //    //}

        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            ReplaceHistory oReplaceHistory = new ReplaceHistory();
        //            oReplaceHistory.ReplaceID = (int)reader["ReplaceID"];
        //            oReplaceHistory.StatusDate = Convert.ToDateTime(reader["StatusDate"].ToString());
        //            oReplaceHistory.Status = int.Parse(reader["Status"].ToString());
        //            oReplaceHistory.Remarks = (Object)reader["Remarks"].ToString();
        //            oReplaceHistory.UserID = (int)reader["UserID"];

        //            InnerList.Add(oReplaceHistory);
        //        }
        //        reader.Close();
        //        InnerList.TrimToSize();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        public void RefreshByID(int nReplaceID)//String txtReplaceID
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql ="SELECT ReplaceHistoryID,ReplaceID,RH.UserID,Status,StatusDate,Remarks,U.UserFullName, " +
                        "StatusName=CASE "+
                        "When Status=0 Then 'Raise' "+
                        "When Status=1 Then 'Approve' "+
                        "When Status=2 Then 'DepositToLog' "+
                        "When Status=3 Then 'IssueFromLog' "+
                        "When Status=4 Then 'SentToCSD' "+
                        "When Status=5 Then 'ReceiveAtCSD' "+
                        "When Status=6 Then 'InformToCustomer' "+
                        "When Status=7 Then 'Delivered' "+
                        "When Status=8 Then 'PaperAcknowledge' "+
                        "When Status=9 Then 'HappyCall' "+
                        "When Status=10 Then 'Cancel' "+ 
                        "End "+
                        "FROM t_CSDReplaceHistory RH INNER JOIN t_user U ON U.UserID=RH.UserID "+
                        "where ReplaceID=? ";

           
             cmd.Parameters.AddWithValue("ReplaceID", nReplaceID);
             //sSql = sSql + " order by ReplaceHistoryID ";
            

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReplaceHistory oReplaceHistory = new ReplaceHistory();
                    oReplaceHistory.ReplaceID = (int)reader["ReplaceID"];
                    oReplaceHistory.StatusDate = Convert.ToDateTime(reader["StatusDate"].ToString());
                    oReplaceHistory.Status = int.Parse(reader["Status"].ToString());
                    oReplaceHistory.Remarks = (Object)reader["Remarks"].ToString();
                    oReplaceHistory.UserID = (int)reader["UserID"];
                    oReplaceHistory.UserName = (string)reader["UserFullName"];
                    oReplaceHistory.StatusName = (string)reader["StatusName"];


                    InnerList.Add(oReplaceHistory);
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

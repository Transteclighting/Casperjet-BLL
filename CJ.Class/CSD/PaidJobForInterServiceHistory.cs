// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Apr 23, 2012
// Time :  2:31 PM
// Description: Class for Paid Job For Inter Service History Data.
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
    public class PaidJobForInterServiceHistory
    {

        private int _nPaidJobHistoryID;
        private int _nPaidJobID;
        private int _nUserID;
        private string _sUserName;
        private int _nStatus;
        private string _sStatusName;
        private DateTime _dStatusDate;
        private Object _sRemarks;

        private User _oUser;
        private PaidJobForInterService _oPaidJobForInterService;

        /// <summary>
        /// Get set property for PaidJobHistoryID
        /// </summary>
        public int PaidJobHistoryID
        {
            get { return _nPaidJobHistoryID; }
            set { _nPaidJobHistoryID = value; }
        }
        /// <summary>
        /// Get set property for PaidJobID
        /// </summary>
        public int PaidJobID
        {
            get { return _nPaidJobID; }
            set { _nPaidJobID = value; }
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
        public DateTime StatusDate
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
        public PaidJobForInterService PaidJobForInterService
        {
            get
            {
                if (_oPaidJobForInterService == null)
                {
                    _oPaidJobForInterService = new PaidJobForInterService();
                }
                return _oPaidJobForInterService;
            }
        }
        public void AddPaidJobHistory()
        {
            int nMaxPaidJobHistoryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([PaidJobHistoryID]) FROM t_CSDInterServicePaidJobHistory";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPaidJobHistoryID = 1;
                }
                else
                {
                    nMaxPaidJobHistoryID = Convert.ToInt32(maxID) + 1;
                }
                _nPaidJobHistoryID = nMaxPaidJobHistoryID;


                sSql = "INSERT INTO t_CSDInterServicePaidJobHistory(PaidJobHistoryID,PaidJobID,UserID,Status,StatusDate,Remarks) VALUES(?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PaidJobHistoryID", _nPaidJobHistoryID);
                cmd.Parameters.AddWithValue("PaidJobID", _nPaidJobID);
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
        public void UpdateHistoryRemarks()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {

                cmd.CommandText = "Update t_CSDInterServicePaidJobHistory SET Remarks=? Where PaidJobID=? and Status=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("PaidJobID", _nPaidJobID);
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

            string sSql = "SELECT * FROM t_CSDInterServicePaidJobHistory where PaidJobID=?";
            cmd.Parameters.AddWithValue("PaidJobID", _nPaidJobID);
            
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
        public bool CheckJobHistory()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDInterServicePaidJobHistory where PaidJobID=? and Status=?";
            cmd.Parameters.AddWithValue("PaidJobID", _nPaidJobID);
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
    public class PaidJobForInterServiceHistorys : CollectionBase
    {
        public PaidJobForInterServiceHistory this[int i]
        {
            get { return (PaidJobForInterServiceHistory)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(PaidJobForInterServiceHistory oPaidJobForInterServiceHistory)
        {
            InnerList.Add(oPaidJobForInterServiceHistory);
        }
        public void Refresh()//String txtPaidJobID
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDInterServicePaidJobHistory";

            //if (txtPaidJobID != "")
            //{
            //    //txtPaidJobID = "%" + txtPaidJobID + "%";
            //    sSql = sSql + " AND PaidJobID ='" + txtPaidJobID + "'";
            //}

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PaidJobForInterServiceHistory oPaidJobForInterServiceHistory = new PaidJobForInterServiceHistory();
                    oPaidJobForInterServiceHistory.PaidJobID = (int)reader["PaidJobID"];
                    oPaidJobForInterServiceHistory.StatusDate = Convert.ToDateTime(reader["StatusDate"].ToString());
                    oPaidJobForInterServiceHistory.Status = int.Parse(reader["Status"].ToString());
                    oPaidJobForInterServiceHistory.Remarks = (string)reader["Remarks"];
                    oPaidJobForInterServiceHistory.UserID = (int)reader["UserID"];

                    InnerList.Add(oPaidJobForInterServiceHistory);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByID(int nPaidJobID)//String txtPaidJobID
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql="SELECT RH.*,U.UserFullName, "+
                        "StatusName=CASE "+
                        "When Status=0 Then 'Receive' "+
                        "When Status=1 Then 'Assign' "+
                        "When Status=2 Then 'WorkInProgress' "+
                        "When Status=3 Then 'ServiceProvided' "+
                        "When Status=4 Then 'ConvertToCSDJob' "+
                        "When Status=5 Then 'Pending' "+
                        "When Status=6 Then 'Cancel' "+
                        "When Status=-9 Then 'Communication' " + 
                        "End "+
                        "FROM t_CSDInterServicePaidJobHistory RH INNER JOIN t_user U ON U.UserID=RH.UserID " +
                        "where PaidJobID=?";


            cmd.Parameters.AddWithValue("PaidJobID", nPaidJobID);

            //if (txtPaidJobID != "")
            //{
            //    //txtPaidJobID = "%" + txtPaidJobID + "%";
            //    sSql = sSql + " AND PaidJobID ='" + txtPaidJobID + "'";
            //}

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PaidJobForInterServiceHistory oPaidJobForInterServiceHistory = new PaidJobForInterServiceHistory();
                    oPaidJobForInterServiceHistory.PaidJobID = (int)reader["PaidJobID"];
                    oPaidJobForInterServiceHistory.StatusDate = Convert.ToDateTime(reader["StatusDate"].ToString());
                    oPaidJobForInterServiceHistory.Status = int.Parse(reader["Status"].ToString());
                    oPaidJobForInterServiceHistory.Remarks = (Object)reader["Remarks"].ToString();
                    oPaidJobForInterServiceHistory.UserID = (int)reader["UserID"];
                    oPaidJobForInterServiceHistory.UserName = (string)reader["UserFullName"];
                    oPaidJobForInterServiceHistory.StatusName = (string)reader["StatusName"];


                    InnerList.Add(oPaidJobForInterServiceHistory);
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


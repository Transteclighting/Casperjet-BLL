// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Jan 19, 2017
// Time : 03:06 PM
// Description: Class for CSDBackupProductTran.
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
    public class CSDBackupProductTran
    {
        private int _nBackupProductTranID;
        private int _nBackupProductID;
        private int _nJobID;
        private int _nTranType;
        private int _nCreateUserID;
        private DateTime _dCreateDate;


        // <summary>
        // Get set property for BackupProductTranID
        // </summary>
        public int BackupProductTranID
        {
            get { return _nBackupProductTranID; }
            set { _nBackupProductTranID = value; }
        }

        // <summary>
        // Get set property for BackupProductID
        // </summary>
        public int BackupProductID
        {
            get { return _nBackupProductID; }
            set { _nBackupProductID = value; }
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
        // Get set property for TranType
        // </summary>
        public int TranType
        {
            get { return _nTranType; }
            set { _nTranType = value; }
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
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        public void Add()
        {
            int nMaxBackupProductTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([BackupProductTranID]) FROM t_CSDBackupProductTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBackupProductTranID = 1;
                }
                else
                {
                    nMaxBackupProductTranID = Convert.ToInt32(maxID) + 1;
                }
                _nBackupProductTranID = nMaxBackupProductTranID;
                sSql = "INSERT INTO t_CSDBackupProductTran (BackupProductTranID, BackupProductID, JobID, TranType, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BackupProductTranID", _nBackupProductTranID);
                cmd.Parameters.AddWithValue("BackupProductID", _nBackupProductID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("TranType", _nTranType);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

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
                sSql = "UPDATE t_CSDBackupProductTran SET BackupProductID = ?, JobID = ?, TranType = ?, CreateUserID = ?, CreateDate = ? WHERE BackupProductTranID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BackupProductID", _nBackupProductID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("TranType", _nTranType);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("BackupProductTranID", _nBackupProductTranID);

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
                sSql = "DELETE FROM t_CSDBackupProductTran WHERE [BackupProductTranID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BackupProductTranID", _nBackupProductTranID);
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
                cmd.CommandText = "SELECT * FROM t_CSDBackupProductTran where BackupProductTranID =?";
                cmd.Parameters.AddWithValue("BackupProductTranID", _nBackupProductTranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nBackupProductTranID = (int)reader["BackupProductTranID"];
                    _nBackupProductID = (int)reader["BackupProductID"];
                    _nJobID = (int)reader["JobID"];
                    _nTranType = (int)reader["TranType"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
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
    public class CSDBackupProductTrans : CollectionBase
    {
        public CSDBackupProductTran this[int i]
        {
            get { return (CSDBackupProductTran)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDBackupProductTran oCSDBackupProductTran)
        {
            InnerList.Add(oCSDBackupProductTran);
        }
        public int GetIndex(int nBackupProductTranID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].BackupProductTranID == nBackupProductTranID)
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
            string sSql = "SELECT * FROM t_CSDBackupProductTran";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDBackupProductTran oCSDBackupProductTran = new CSDBackupProductTran();
                    oCSDBackupProductTran.BackupProductTranID = (int)reader["BackupProductTranID"];
                    oCSDBackupProductTran.BackupProductID = (int)reader["BackupProductID"];
                    oCSDBackupProductTran.JobID = (int)reader["JobID"];
                    oCSDBackupProductTran.TranType = (int)reader["TranType"];
                    oCSDBackupProductTran.CreateUserID = (int)reader["CreateUserID"];
                    oCSDBackupProductTran.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oCSDBackupProductTran);
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


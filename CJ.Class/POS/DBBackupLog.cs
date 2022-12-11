// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD. Abdul Hakim
// Date: Feb 17, 2015
// Time : 04:39 PM
// Description: Class for DBBackupLog.
// Modify Person And Date:
// </summary>

using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.POS
{
    public class DBBackupLog
    {
        private int _nBackupID;
        private int _nWarehouseID;
        private DateTime _dOperationDate;
        private DateTime _dBakcupDate;
        private string _sFileName;
        private object _dUploadDate;


        // <summary>
        // Get set property for BackupID
        // </summary>
        public int BackupID
        {
            get { return _nBackupID; }
            set { _nBackupID = value; }
        }

        // <summary>
        // Get set property for WarehouseID
        // </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        // <summary>
        // Get set property for BakcupDate
        // </summary>
        public DateTime OperationDate
        {
            get { return _dOperationDate; }
            set { _dOperationDate = value; }
        }

        // <summary>
        // Get set property for BakcupDate
        // </summary>
        public DateTime BakcupDate
        {
            get { return _dBakcupDate; }
            set { _dBakcupDate = value; }
        }

        // <summary>
        // Get set property for FileName
        // </summary>
        public string FileName
        {
            get { return _sFileName; }
            set { _sFileName = value.Trim(); }
        }

        // <summary>
        // Get set property for UploadDate
        // </summary>
        public object UploadDate
        {
            get { return _dUploadDate; }
            set { _dUploadDate = value; }
        }

        public void Add()
        {
            int nMaxBackupID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([BackupID]) FROM t_DBBackupLog";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBackupID = 1;
                }
                else
                {
                    nMaxBackupID = Convert.ToInt32(maxID) + 1;
                }
                if (_nBackupID == 0)
                {
                    _nBackupID = nMaxBackupID;
                }
                
                sSql = "INSERT INTO t_DBBackupLog (BackupID, WarehouseID, OperationDate, BakcupDate, FileName, UploadDate) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BackupID", _nBackupID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("OperationDate", _dOperationDate);
                cmd.Parameters.AddWithValue("BakcupDate", _dBakcupDate);
                cmd.Parameters.AddWithValue("FileName", _sFileName);
                cmd.Parameters.AddWithValue("UploadDate", _dUploadDate);

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
                sSql = "UPDATE t_DBBackupLog SET WarehouseID = ?, OperationDate = ?, BakcupDate = ?, FileName = ?, UploadDate = ? WHERE BackupID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("OperationDate", _dOperationDate);
                cmd.Parameters.AddWithValue("BakcupDate", _dBakcupDate);
                cmd.Parameters.AddWithValue("FileName", _sFileName);
                cmd.Parameters.AddWithValue("UploadDate", _dUploadDate);

                cmd.Parameters.AddWithValue("BackupID", _nBackupID);

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
                sSql = "DELETE FROM t_DBBackupLog WHERE [BackupID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BackupID", _nBackupID);
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
                cmd.CommandText = "SELECT * FROM t_DBBackupLog where BackupID =?";
                cmd.Parameters.AddWithValue("BackupID", _nBackupID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nBackupID = (int)reader["BackupID"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _dOperationDate = Convert.ToDateTime(reader["OperationDate"].ToString());
                    _dBakcupDate = Convert.ToDateTime(reader["BakcupDate"].ToString());
                    _sFileName = (string)reader["FileName"];
                    _dUploadDate = Convert.ToDateTime(reader["UploadDate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckLog()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "select * from t_DBBackupLog Where BackupID=? and WarehouseID=? ";
                cmd.Parameters.AddWithValue("BackupID", _nBackupID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                return true;
            else return false;
        }
    }
    public class DBBackupLogs : CollectionBase
    {
        public DBBackupLog this[int i]
        {
            get { return (DBBackupLog)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(DBBackupLog oDBBackupLog)
        {
            InnerList.Add(oDBBackupLog);
        }
        public int GetIndex(int nBackupID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].BackupID == nBackupID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(DateTime dOperationDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_DBBackupLog Where OperationDate <'" + dOperationDate + "'";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DBBackupLog oDBBackupLog = new DBBackupLog();

                    oDBBackupLog.BackupID = (int)reader["BackupID"];
                    oDBBackupLog.WarehouseID = (int)reader["WarehouseID"];
                    oDBBackupLog.OperationDate = Convert.ToDateTime(reader["OperationDate"].ToString());
                    oDBBackupLog.BakcupDate = Convert.ToDateTime(reader["BakcupDate"].ToString());
                    oDBBackupLog.FileName = (string)reader["FileName"];

                    InnerList.Add(oDBBackupLog);
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



// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Dec 31, 2016
// Time : 01:32 PM
// Description: Class for CSDJobStatus.
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
    public class CSDJobStatus
    {
        private int _nStatusID;
        private string _sStatusName;
        private string _sType;


        // <summary>
        // Get set property for StatusID
        // </summary>
        public int StatusID
        {
            get { return _nStatusID; }
            set { _nStatusID = value; }
        }

        // <summary>
        // Get set property for StatusName
        // </summary>
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value.Trim(); }
        }

        // <summary>
        // Get set property for Type
        // </summary>
        public string Type
        {
            get { return _sType; }
            set { _sType = value.Trim(); }
        }

        public void Add()
        {
            int nMaxStatusID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([StatusID]) FROM t_CSDJobStatus";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxStatusID = 1;
                }
                else
                {
                    nMaxStatusID = Convert.ToInt32(maxID) + 1;
                }
                _nStatusID = nMaxStatusID;
                sSql = "INSERT INTO t_CSDJobStatus (StatusID, StatusName, Type) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("StatusID", _nStatusID);
                cmd.Parameters.AddWithValue("StatusName", _sStatusName);
                cmd.Parameters.AddWithValue("Type", _sType);

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
                sSql = "UPDATE t_CSDJobStatus SET StatusName = ?, Type = ? WHERE StatusID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("StatusName", _sStatusName);
                cmd.Parameters.AddWithValue("Type", _sType);

                cmd.Parameters.AddWithValue("StatusID", _nStatusID);

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
                sSql = "DELETE FROM t_CSDJobStatus WHERE [StatusID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("StatusID", _nStatusID);
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
                cmd.CommandText = "SELECT * FROM t_CSDJobStatus where StatusID =?";
                cmd.Parameters.AddWithValue("StatusID", _nStatusID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nStatusID = (int)reader["StatusID"];
                    _sStatusName = (string)reader["StatusName"];
                    _sType = (string)reader["Type"];
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
    public class CSDJobStatuss : CollectionBase
    {
        public CSDJobStatus this[int i]
        {
            get { return (CSDJobStatus)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDJobStatus oCSDJobStatus)
        {
            InnerList.Add(oCSDJobStatus);
        }
        public int GetIndex(int nStatusID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].StatusID == nStatusID)
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
            string sSql = "SELECT * FROM t_CSDJobStatus";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJobStatus oCSDJobStatus = new CSDJobStatus();
                    oCSDJobStatus.StatusID = (int)reader["StatusID"];
                    oCSDJobStatus.StatusName = (string)reader["StatusName"];
                    oCSDJobStatus.Type = (string)reader["Type"];
                    InnerList.Add(oCSDJobStatus);
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


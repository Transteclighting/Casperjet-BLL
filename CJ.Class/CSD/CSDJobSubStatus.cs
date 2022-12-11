// <summary>
// Company: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Feb 11, 2017
// Time : 01:13 PM
// Description: Class for CSDJobStatus_Sub.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.CSD
{
    public class CSDJobSubStatus
    {
        private int _nSubStatusID;
        private int _nStatusID;
        private string _sName;
        private int _nIsActive;
        private int _nCreateUserID;
        private DateTime _dCreateDate;


        // <summary>
        // Get set property for SubStatusID
        // </summary>
        public int SubStatusID
        {
            get { return _nSubStatusID; }
            set { _nSubStatusID = value; }
        }

        // <summary>
        // Get set property for StatusID
        // </summary>
        public int StatusID
        {
            get { return _nStatusID; }
            set { _nStatusID = value; }
        }

        // <summary>
        // Get set property for Name
        // </summary>
        public string Name
        {
            get { return _sName; }
            set { _sName = value.Trim(); }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
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
            int nMaxSubStatusID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([SubStatusID]) FROM t_CSDJobStatus_Sub";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSubStatusID = 1;
                }
                else
                {
                    nMaxSubStatusID = Convert.ToInt32(maxID) + 1;
                }
                _nSubStatusID = nMaxSubStatusID;
                sSql = "INSERT INTO t_CSDJobStatus_Sub (SubStatusID, StatusID, Name, IsActive, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SubStatusID", _nSubStatusID);
                cmd.Parameters.AddWithValue("StatusID", _nStatusID);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
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
                sSql = "UPDATE t_CSDJobStatus_Sub SET StatusID = ?, Name = ?, IsActive = ?, CreateUserID = ?, CreateDate = ? WHERE SubStatusID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("StatusID", _nStatusID);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("SubStatusID", _nSubStatusID);

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
                sSql = "DELETE FROM t_CSDJobStatus_Sub WHERE [SubStatusID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SubStatusID", _nSubStatusID);
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
                cmd.CommandText = "SELECT * FROM t_CSDJobStatus_Sub where SubStatusID =?";
                cmd.Parameters.AddWithValue("SubStatusID", _nSubStatusID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nSubStatusID = (int)reader["SubStatusID"];
                    _nStatusID = (int)reader["StatusID"];
                    _sName = (string)reader["Name"];
                    _nIsActive = (int)reader["IsActive"];
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
    public class CSDJobSubStatuss : CollectionBase
    {
        public CSDJobSubStatus this[int i]
        {
            get { return (CSDJobSubStatus)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDJobSubStatus oCSDJobSubStatus)
        {
            InnerList.Add(oCSDJobSubStatus);
        }
        public int GetIndex(int nSubStatusID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].SubStatusID == nSubStatusID)
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
            string sSql = "SELECT * FROM t_CSDJobStatus_Sub";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJobSubStatus oCSDJobStatus_Sub = new CSDJobSubStatus();
                    oCSDJobStatus_Sub.SubStatusID = (int)reader["SubStatusID"];
                    oCSDJobStatus_Sub.StatusID = (int)reader["StatusID"];
                    oCSDJobStatus_Sub.Name = (string)reader["Name"];
                    oCSDJobStatus_Sub.IsActive = (int)reader["IsActive"];
                    oCSDJobStatus_Sub.CreateUserID = (int)reader["CreateUserID"];
                    oCSDJobStatus_Sub.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oCSDJobStatus_Sub);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByStatusID(int nStatusID, int nServiceType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            if (nServiceType != (int)Dictionary.ServiceType.Walkin)
            {
                sSql = "SELECT * FROM t_CSDJobStatus_Sub where StatusID = " + nStatusID + " ";
            }
            else
            {
                sSql = "SELECT * FROM t_CSDJobStatus_Sub where StatusID = " + nStatusID + " and SubStatusID Not IN (6)";//6=Reschedule
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJobSubStatus oCSDJobStatus_Sub = new CSDJobSubStatus();

                    oCSDJobStatus_Sub.SubStatusID = (int)reader["SubStatusID"];
                    oCSDJobStatus_Sub.StatusID = (int)reader["StatusID"];
                    oCSDJobStatus_Sub.Name = (string)reader["Name"];
                    oCSDJobStatus_Sub.IsActive = (int)reader["IsActive"];
                    oCSDJobStatus_Sub.CreateUserID = (int)reader["CreateUserID"];
                    oCSDJobStatus_Sub.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oCSDJobStatus_Sub);
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



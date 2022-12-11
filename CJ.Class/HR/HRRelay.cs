// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Sep 24, 2016
// Time : 12:35 PM
// Description: Class for HRRelay.
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
    public class HRRelay
    {
        private int _nRelayID;
        private string _sRelayName;
        private string _sRemarks;
        private DateTime _dStartTime;
        private DateTime _dEndTime;
        private int _nIsActive;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _dUpdateUserID;
        private DateTime _dUpdateDate;
        private string _sCreatedBy;


        // <summary>
        // Get set property for RelayID
        // </summary>
        public int RelayID
        {
            get { return _nRelayID; }
            set { _nRelayID = value; }
        }

        // <summary>
        // Get set property for Relay Name
        // </summary>
        public string RelayName
        {
            get { return _sRelayName; }
            set { _sRelayName = value.Trim(); }
        }
        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        // <summary>
        // Get set property for StartTime
        // </summary>
        public DateTime StartTime
        {
            get { return _dStartTime; }
            set { _dStartTime = value; }
        }

        // <summary>
        // Get set property for EndTime
        // </summary>
        public DateTime EndTime
        {
            get { return _dEndTime; }
            set { _dEndTime = value; }
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

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _dUpdateUserID; }
            set { _dUpdateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }       

        // <summary>
        // Get set property for CreatedBy
        // </summary>
        public string CreatedBy
        {
            get { return _sCreatedBy; }
            set { _sCreatedBy = value; }
        }

        public void Add()
        {
            int nMaxRelayID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([RelayID]) FROM t_HRRelay";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxRelayID = 1;
                }
                else
                {
                    nMaxRelayID = Convert.ToInt32(maxID) + 1;
                }
                _nRelayID = nMaxRelayID;
                sSql = "INSERT INTO t_HRRelay (RelayID, Remarks, StartTime, EndTime, IsActive, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("RelayID", _nRelayID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("StartTime", _dStartTime);
                cmd.Parameters.AddWithValue("EndTime", _dEndTime);
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
                sSql = "UPDATE t_HRRelay SET Remarks = ?, StartTime = ?, EndTime = ?, IsActive = ?, UpdateUserID = ?, UpdateDate = ? WHERE RelayID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("StartTime", _dStartTime);
                cmd.Parameters.AddWithValue("EndTime", _dEndTime);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", _dUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("RelayID", _nRelayID);
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
                sSql = "DELETE FROM t_HRRelay WHERE [RelayID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("RelayID", _nRelayID);
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
                cmd.CommandText = "SELECT * FROM t_HRRelay where RelayID =?";
                cmd.Parameters.AddWithValue("RelayID", _nRelayID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nRelayID = (int)reader["RelayID"];
                    _sRemarks = (string)reader["Remarks"];
                    _dStartTime = Convert.ToDateTime(reader["StartTime"].ToString());
                    _dEndTime = Convert.ToDateTime(reader["EndTime"].ToString());
                    _nIsActive = (int)reader["IsActive"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _dUpdateUserID = (int)(reader["UpdateUserID"]);
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
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
    public class HRRelays : CollectionBase
    {
        public HRRelay this[int i]
        {
            get { return (HRRelay)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRRelay oHRRelay)
        {
            InnerList.Add(oHRRelay);
        }
        public int GetIndex(int nRelayID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].RelayID == nRelayID)
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
            string sSql = "SELECT * FROM t_HRRelay a INNER JOIN t_User b on a.CreateUserID = b.UserID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRRelay oHRRelay = new HRRelay();
                    oHRRelay.RelayID = (int)reader["RelayID"];
                    oHRRelay.Remarks = (string)reader["Remarks"];
                    oHRRelay.StartTime = Convert.ToDateTime(reader["StartTime"].ToString());
                    oHRRelay.EndTime = Convert.ToDateTime(reader["EndTime"].ToString());
                    string _sStartTime = oHRRelay.StartTime.ToShortTimeString();
                    string _sEndTime = oHRRelay.EndTime.ToShortTimeString();
                    oHRRelay.RelayName = "Relay:[" + _sStartTime +"-"+ _sEndTime + "]";
                    oHRRelay.IsActive = (int)reader["IsActive"];
                    oHRRelay.CreatedBy = (string)reader["UserFullName"];
                    oHRRelay.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oHRRelay);
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


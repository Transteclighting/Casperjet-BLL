// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Sep 26, 2016
// Time : 09:57 AM
// Description: Class for HRShiftMapping.
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
    public class HRShiftMapping
    {
        private int _nID;
        private DateTime _dDate;
        private int _nRelayID;
        private string _sRelayName;
        private int _nShiftID;
        private string _sShiftName;
        private int _nCreateUserID;
        private string _sCreateUserName;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for Date
        // </summary>
        public DateTime Date
        {
            get { return _dDate; }
            set { _dDate = value; }
        }

        // <summary>
        // Get set property for RelayID
        // </summary>
        public int RelayID
        {
            get { return _nRelayID; }
            set { _nRelayID = value; }
        }

        // <summary>
        // Get set property for RelayName
        // </summary>
        public string RelayName
        {
            get { return _sRelayName; }
            set { _sRelayName = value; }
        }

        // <summary>
        // Get set property for ShiftID
        // </summary>
        public int ShiftID
        {
            get { return _nShiftID; }
            set { _nShiftID = value; }
        }

        // <summary>
        // Get set property for ShiftName
        // </summary>
        public string ShiftName
        {
            get { return _sShiftName; }
            set { _sShiftName = value; }
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
        // Get set property for CreateUserName
        // </summary>
        public string CreateUserName
        {
            get { return _sCreateUserName; }
            set { _sCreateUserName = value; }
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
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_HRShiftMapping";
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
                sSql = "INSERT INTO t_HRShiftMapping (ID, Date, RelayID, ShiftID, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("Date", _dDate);
                cmd.Parameters.AddWithValue("RelayID", _nRelayID);
                cmd.Parameters.AddWithValue("ShiftID", _nShiftID);
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
                sSql = "UPDATE t_HRShiftMapping SET Date = ?, RelayID = ?, ShiftID = ?, CreateUserID = ?, CreateDate = ?, UpdateUserID = ?, UpdateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Date", _dDate);
                cmd.Parameters.AddWithValue("RelayID", _nRelayID);
                cmd.Parameters.AddWithValue("ShiftID", _nShiftID);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "DELETE FROM t_HRShiftMapping WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_HRShiftMapping where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _dDate = Convert.ToDateTime(reader["Date"].ToString());
                    _nRelayID = (int)reader["RelayID"];
                    _nShiftID = (int)reader["ShiftID"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
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
    public class HRShiftMappings : CollectionBase
    {
        public HRShiftMapping this[int i]
        {
            get { return (HRShiftMapping)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRShiftMapping oHRShiftMapping)
        {
            InnerList.Add(oHRShiftMapping);
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
        public void Refresh(int nShiftID,int TMonth,int TYear)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM dbo.t_HRShiftMapping a "
                         +" INNER JOIN dbo.t_HRRelay b on a.RelayID = b.RelayID "
                         +" INNER JOIN dbo.t_HRShift c on a.ShiftID = c.ShiftID " 
                         +" INNER JOIN t_User d on a.CreateUserID = d.UserID "
                         +" WHERE MONTH(Date) = " + TMonth + " AND YEAR(Date)= " + TYear + " ";
            if (nShiftID != -1)
            {
                sSql += " AND a.ShiftID = " + nShiftID + " ";
            }
            sSql += " ORDER BY Date DESC";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRShiftMapping oHRShiftMapping = new HRShiftMapping();
                    oHRShiftMapping.ID = (int)reader["ID"];
                    oHRShiftMapping.Date = Convert.ToDateTime(reader["Date"].ToString());
                    string _sStartTime = Convert.ToDateTime(reader["StartTime"].ToString()).ToShortTimeString();
                    string _sEndTime = Convert.ToDateTime(reader["EndTime"].ToString()).ToShortTimeString();
                    oHRShiftMapping.RelayName = "Relay:[" + _sStartTime + "-" + _sEndTime + "]"; ;
                    oHRShiftMapping.ShiftName = (string)reader["ShiftName"];
                    oHRShiftMapping.CreateUserName = (string)reader["UserFullName"];
                    InnerList.Add(oHRShiftMapping);
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


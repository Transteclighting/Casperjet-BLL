// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Nov 17, 2016
// Time : 12:35 PM
// Description: Class for HRDivision.
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
    public class HRDivision
    {
        private int _nDivisionID;
        private string _sDivisionName;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private DateTime _dUpdateDate;
        private int _nUpdateUserID;
        private int _nStatus;


        // <summary>
        // Get set property for DivisionID
        // </summary>
        public int DivisionID
        {
            get { return _nDivisionID; }
            set { _nDivisionID = value; }
        }

        // <summary>
        // Get set property for DivisionName
        // </summary>
        public string DivisionName
        {
            get { return _sDivisionName; }
            set { _sDivisionName = value.Trim(); }
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
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
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
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        public void Add()
        {
            int nMaxDivisionID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([DivisionID]) FROM t_HRDivision";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxDivisionID = 1;
                }
                else
                {
                    nMaxDivisionID = Convert.ToInt32(maxID) + 1;
                }
                _nDivisionID = nMaxDivisionID;
                sSql = "INSERT INTO t_HRDivision (DivisionID, DivisionName, CreateDate, CreateUserID, UpdateDate, UpdateUserID, Status) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DivisionID", _nDivisionID);
                cmd.Parameters.AddWithValue("DivisionName", _sDivisionName);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);

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
                sSql = "UPDATE t_HRDivision SET DivisionName = ?, CreateDate = ?, CreateUserID = ?, UpdateDate = ?, UpdateUserID = ?, Status = ? WHERE DivisionID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DivisionName", _sDivisionName);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("DivisionID", _nDivisionID);

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
                sSql = "DELETE FROM t_HRDivision WHERE [DivisionID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DivisionID", _nDivisionID);
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
                cmd.CommandText = "SELECT * FROM t_HRDivision where DivisionID =?";
                cmd.Parameters.AddWithValue("DivisionID", _nDivisionID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nDivisionID = (int)reader["DivisionID"];
                    _sDivisionName = (string)reader["DivisionName"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _nStatus = (int)reader["Status"];
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
    public class HRDivisions : CollectionBase
    {
        public HRDivision this[int i]
        {
            get { return (HRDivision)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRDivision oHRDivision)
        {
            InnerList.Add(oHRDivision);
        }
        public int GetIndex(int nDivisionID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].DivisionID == nDivisionID)
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
            string sSql = "SELECT * FROM t_HRDivision";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRDivision oHRDivision = new HRDivision();
                    oHRDivision.DivisionID = (int)reader["DivisionID"];
                    oHRDivision.DivisionName = (string)reader["DivisionName"];
                    oHRDivision.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oHRDivision.CreateUserID = (int)reader["CreateUserID"];
                    oHRDivision.Status = (int)reader["Status"];
                    InnerList.Add(oHRDivision);
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


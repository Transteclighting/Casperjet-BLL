// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Nov 18, 2019
// Time : 03:45 PM
// Description: Class for OutletFeasibilityType.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.BasicData
{
    public class OutletFeasibilityType
    {
        private int _nOutletFeasibilityTypeID;
        private string _sOutletFeasibilityTypeName;
        private int _nCreateUser;
        private DateTime _dCreateDate;
        private int _nIsActive;


        // <summary>
        // Get set property for OutletFeasibilityTypeID
        // </summary>
        public int OutletFeasibilityTypeID
        {
            get { return _nOutletFeasibilityTypeID; }
            set { _nOutletFeasibilityTypeID = value; }
        }

        // <summary>
        // Get set property for OutletFeasibilityTypeName
        // </summary>
        public string OutletFeasibilityTypeName
        {
            get { return _sOutletFeasibilityTypeName; }
            set { _sOutletFeasibilityTypeName = value.Trim(); }
        }

        // <summary>
        // Get set property for CreateUser
        // </summary>
        public int CreateUser
        {
            get { return _nCreateUser; }
            set { _nCreateUser = value; }
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
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        public void Add()
        {
            int nMaxOutletFeasibilityTypeID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OutletFeasibilityTypeID]) FROM t_OutletFeasibilityType";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxOutletFeasibilityTypeID = 1;
                }
                else
                {
                    nMaxOutletFeasibilityTypeID = Convert.ToInt32(maxID) + 1;
                }
                _nOutletFeasibilityTypeID = nMaxOutletFeasibilityTypeID;
                sSql = "INSERT INTO t_OutletFeasibilityType (OutletFeasibilityTypeID, OutletFeasibilityTypeName, CreateUser, CreateDate, IsActive) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OutletFeasibilityTypeID", _nOutletFeasibilityTypeID);
                cmd.Parameters.AddWithValue("OutletFeasibilityTypeName", _sOutletFeasibilityTypeName);
                cmd.Parameters.AddWithValue("CreateUser", _nCreateUser);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

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
                sSql = "UPDATE t_OutletFeasibilityType SET OutletFeasibilityTypeName = ?, CreateUser = ?, CreateDate = ?, IsActive = ? WHERE OutletFeasibilityTypeID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OutletFeasibilityTypeName", _sOutletFeasibilityTypeName);
                cmd.Parameters.AddWithValue("CreateUser", _nCreateUser);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.Parameters.AddWithValue("OutletFeasibilityTypeID", _nOutletFeasibilityTypeID);

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
                sSql = "DELETE FROM t_OutletFeasibilityType WHERE [OutletFeasibilityTypeID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OutletFeasibilityTypeID", _nOutletFeasibilityTypeID);
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
                cmd.CommandText = "SELECT * FROM t_OutletFeasibilityType where OutletFeasibilityTypeID =?";
                cmd.Parameters.AddWithValue("OutletFeasibilityTypeID", _nOutletFeasibilityTypeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nOutletFeasibilityTypeID = (int)reader["OutletFeasibilityTypeID"];
                    _sOutletFeasibilityTypeName = (string)reader["OutletFeasibilityTypeName"];
                    _nCreateUser = (int)reader["CreateUser"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nIsActive = (int)reader["IsActive"];
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
    public class OutletFeasibilityTypeDetails : CollectionBase
    {
        public OutletFeasibilityType this[int i]
        {
            get { return (OutletFeasibilityType)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OutletFeasibilityType oOutletFeasibilityType)
        {
            InnerList.Add(oOutletFeasibilityType);
        }
        public int GetIndex(int nOutletFeasibilityTypeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].OutletFeasibilityTypeID == nOutletFeasibilityTypeID)
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
            string sSql = "SELECT * FROM t_OutletFeasibilityType";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletFeasibilityType oOutletFeasibilityType = new OutletFeasibilityType();
                    oOutletFeasibilityType.OutletFeasibilityTypeID = (int)reader["OutletFeasibilityTypeID"];
                    oOutletFeasibilityType.OutletFeasibilityTypeName = (string)reader["OutletFeasibilityTypeName"];
                    oOutletFeasibilityType.CreateUser = (int)reader["CreateUser"];
                    oOutletFeasibilityType.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oOutletFeasibilityType.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oOutletFeasibilityType);
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



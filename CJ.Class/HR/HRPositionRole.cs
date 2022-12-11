
// <summary>
// Company: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Nov 05, 2016
// Time : 02:08 PM
// Description: Class for HRPositionRole.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.HR
{
    public class HRPositionRole
    {
        private int _nID;
        private string _sName;
        private int _nType;
        private int _nIsActive;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        private string duplicateVale;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
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
        // Get set property for Type
        // </summary>
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
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
                sSql = "SELECT MAX([ID]) FROM t_HRPositionRole";
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
                sSql = "INSERT INTO t_HRPositionRole (ID, Name, Type, IsActive, CreateUserID, CreateDate, UpdateUserID, UpdateDate) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);

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
                sSql = "UPDATE t_HRPositionRole SET Name = ?, Type = ?, IsActive = ?, CreateUserID = ?, CreateDate = ?, UpdateUserID = ?, UpdateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
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
                sSql = "DELETE FROM t_HRPositionRole WHERE [ID]=?";
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

        public string CheckDuplicateData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            duplicateVale = "No";
            try
            {
                cmd.CommandText = "SELECT * FROM t_HRPositionRole where Name =? and Type =?";
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    duplicateVale = "Yes";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return duplicateVale;
        }



        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_HRPositionRole where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sName = (string)reader["Name"];
                    _nType = (int)reader["Type"];
                    _nIsActive = (int)reader["IsActive"];
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
    public class HRPositionRoles : CollectionBase
    {
        public HRPositionRole this[int i]
        {
            get { return (HRPositionRole)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRPositionRole oHRPositionRole)
        {
            InnerList.Add(oHRPositionRole);
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
        public void Refresh(int nType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_HRPositionRole Where Type = " + nType + " ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPositionRole oHRPositionRole = new HRPositionRole();
                    oHRPositionRole.ID = (int)reader["ID"];
                    oHRPositionRole.Name = (string)reader["Name"];
                    oHRPositionRole.Type = (int)reader["Type"];
                    oHRPositionRole.IsActive = (int)reader["IsActive"];
                    oHRPositionRole.CreateUserID = (int)reader["CreateUserID"];
                    oHRPositionRole.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oHRPositionRole);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetListData(string roleName, int nType)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_HRPositionRole where Type = " + nType + "";

            if (!string.IsNullOrEmpty(roleName))
            {
                sSql = sSql + " and Name like '%" + roleName + "%' ";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPositionRole oHRPositionRole = new HRPositionRole();
                    oHRPositionRole.ID = (int)reader["ID"];
                    oHRPositionRole.Name = (string)reader["Name"];
                    oHRPositionRole.Type = (int)reader["Type"];
                    oHRPositionRole.IsActive = (int)reader["IsActive"];
                    oHRPositionRole.CreateUserID = (int)reader["CreateUserID"];
                    oHRPositionRole.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oHRPositionRole);
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




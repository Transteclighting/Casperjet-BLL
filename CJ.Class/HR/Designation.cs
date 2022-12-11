// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak K. C.
// Date: April 25, 2011
// Time :  12:00 PM
// Description: Class for Designation.
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

    public class Designation
    {

        private int _nDesignationID;
        private string _sDesignationCode;
        private string _sDesignationName;
        private bool _bIsActive;

        public int DesignationID
        {
            get { return _nDesignationID; }
            set { _nDesignationID = value; }

        }

        public string DesignationCode
        {
            get { return _sDesignationCode; }
            set { _sDesignationCode = value; }

        }

        public string DesignationName
        {
            get { return _sDesignationName; }
            set { _sDesignationName = value; }
        }

        public bool IsActive
        {
            get { return _bIsActive; }
            set { _bIsActive = value; }

        }
        public void Add()
        {
            int nMaxDesignationID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([DesignationID]) FROM t_Designation";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxDesignationID = 1;
                }
                else
                {
                    nMaxDesignationID = Convert.ToInt32(maxID) + 1;
                }
                _nDesignationID = nMaxDesignationID;

                sSql = "INSERT INTO t_Designation VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DesignationID", _nDesignationID);
                cmd.Parameters.AddWithValue("DesignationCode", _sDesignationCode);
                cmd.Parameters.AddWithValue("DesignationName", _sDesignationName);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);

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

                sSql = "UPDATE t_Designation SET DesignationCode=?, DesignationName=?, IsActive=?"
                    + " WHERE DesignationID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DesignationCode", _sDesignationCode);
                cmd.Parameters.AddWithValue("DesignationName", _sDesignationName);
                cmd.Parameters.AddWithValue("IsActive", _bIsActive);
                cmd.Parameters.AddWithValue("DesignationID", _nDesignationID);

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
                sSql = "DELETE FROM t_Designation WHERE [DesignationID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DesignationID", _nDesignationID);
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
                cmd.CommandText = "SELECT * FROM t_Designation where DesignationID =?";
                cmd.Parameters.AddWithValue("DesignationID", _nDesignationID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nDesignationID = (int)reader["DesignationID"];
                    _sDesignationCode = (string)reader["DesignationCode"];
                    _sDesignationName = (string)reader["DesignationName"];
                    _bIsActive = Convert.ToBoolean(reader["IsActive"]);
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


    public class Designations : CollectionBase
    {

        public Designation this[int i]
        {
            get { return (Designation)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Designation oDesignation)
        {
            InnerList.Add(oDesignation);
        }

        public int GetIndex(int nDesignationID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].DesignationID == nDesignationID)
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

            string sSql = "SELECT * FROM t_Designation ORDER BY DesignationName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Designation oDesignation = new Designation();

                    oDesignation.DesignationID = (int)reader["DesignationID"];
                    oDesignation.DesignationCode = (string)reader["DesignationCode"];
                    oDesignation.DesignationName = (string)reader["DesignationName"];
                    oDesignation.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    InnerList.Add(oDesignation);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetData(string sDesignationCode, string sDesignationName, int nIsActive)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_Designation where 1=1";

            if (sDesignationCode != "")
            {
                sSql = sSql + " AND DesignationCode LIKE '%" + sDesignationCode + "%' ";
            }
            if (sDesignationName != "")
            {
                sSql = sSql + " AND DesignationName LIKE '%" + sDesignationName + "%' ";
            }

            if (nIsActive != -1)
            {
                sSql = sSql + " AND IsActive=" + nIsActive + "";
            }
            sSql = sSql + " ORDER BY DesignationName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Designation oDesignation = new Designation();

                    oDesignation.DesignationID = (int)reader["DesignationID"];
                    oDesignation.DesignationCode = (string)reader["DesignationCode"];
                    oDesignation.DesignationName = (string)reader["DesignationName"];
                    oDesignation.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    InnerList.Add(oDesignation);
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

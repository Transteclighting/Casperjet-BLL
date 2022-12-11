using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.HR
{
    public class MapERPHRAccpacCJAllowanceID
    {
        private int _nCompanyID;
        private int _nAccpacAllowanceID;
        private string _sDescription;
        private int _nCJAllowanceID;


        // <summary>
        // Get set property for CompanyID
        // </summary>
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }

        // <summary>
        // Get set property for AccpacAllowanceID
        // </summary>
        public int AccpacAllowanceID
        {
            get { return _nAccpacAllowanceID; }
            set { _nAccpacAllowanceID = value; }
        }

        // <summary>
        // Get set property for Description
        // </summary>
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }

        // <summary>
        // Get set property for CJAllowanceID
        // </summary>
        public int CJAllowanceID
        {
            get { return _nCJAllowanceID; }
            set { _nCJAllowanceID = value; }
        }

        public void Add()
        {
            int nMaxCompanyID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([CompanyID]) FROM t_MapERPHRAccpacCJAllowanceID";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxCompanyID = 1;
                }
                else
                {
                    nMaxCompanyID = Convert.ToInt32(maxID) + 1;
                }
                _nCompanyID = nMaxCompanyID;
                sSql = "INSERT INTO t_MapERPHRAccpacCJAllowanceID (CompanyID, AccpacAllowanceID, Description, CJAllowanceID) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("AccpacAllowanceID", _nAccpacAllowanceID);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("CJAllowanceID", _nCJAllowanceID);

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
                sSql = "UPDATE t_MapERPHRAccpacCJAllowanceID SET AccpacAllowanceID = ?, Description = ?, CJAllowanceID = ? WHERE CompanyID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AccpacAllowanceID", _nAccpacAllowanceID);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("CJAllowanceID", _nCJAllowanceID);

                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);

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
                sSql = "DELETE FROM t_MapERPHRAccpacCJAllowanceID WHERE [CompanyID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
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
                cmd.CommandText = "SELECT * FROM t_MapERPHRAccpacCJAllowanceID where CompanyID =?";
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCompanyID = (int)reader["CompanyID"];
                    _nAccpacAllowanceID = (int)reader["AccpacAllowanceID"];
                    _sDescription = (string)reader["Description"];
                    _nCJAllowanceID = (int)reader["CJAllowanceID"];
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
    public class MapERPHRAccpacCJAllowanceIDs : CollectionBase
    {
        public MapERPHRAccpacCJAllowanceID this[int i]
        {
            get { return (MapERPHRAccpacCJAllowanceID)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(MapERPHRAccpacCJAllowanceID oMapERPHRAccpacCJAllowanceID)
        {
            InnerList.Add(oMapERPHRAccpacCJAllowanceID);
        }
        public int GetIndex(int nCompanyID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].CompanyID == nCompanyID)
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
            string sSql = "SELECT * FROM t_MapERPHRAccpacCJAllowanceID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MapERPHRAccpacCJAllowanceID oMapERPHRAccpacCJAllowanceID = new MapERPHRAccpacCJAllowanceID();
                    oMapERPHRAccpacCJAllowanceID.CompanyID = (int)reader["CompanyID"];
                    oMapERPHRAccpacCJAllowanceID.AccpacAllowanceID = (int)reader["AccpacAllowanceID"];
                    oMapERPHRAccpacCJAllowanceID.Description = (string)reader["Description"];
                    oMapERPHRAccpacCJAllowanceID.CJAllowanceID = (int)reader["CJAllowanceID"];
                    InnerList.Add(oMapERPHRAccpacCJAllowanceID);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByBEILDistSet()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from t_MapERPHRAccpacCJAllowanceID where CompanyID = "+(int)Dictionary.CompanyID.BEIL+" Order By AccpacAllowanceID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MapERPHRAccpacCJAllowanceID oMapERPHRAccpacCJAllowanceID = new MapERPHRAccpacCJAllowanceID();
                    oMapERPHRAccpacCJAllowanceID.CompanyID = (int)reader["CompanyID"];
                    oMapERPHRAccpacCJAllowanceID.AccpacAllowanceID = (int)reader["AccpacAllowanceID"];
                    oMapERPHRAccpacCJAllowanceID.Description = (string)reader["Description"];
                    oMapERPHRAccpacCJAllowanceID.CJAllowanceID = (int)reader["CJAllowanceID"];
                    InnerList.Add(oMapERPHRAccpacCJAllowanceID);
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


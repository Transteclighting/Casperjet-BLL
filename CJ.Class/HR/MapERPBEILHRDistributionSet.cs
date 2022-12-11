using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.HR
{
    public class MapERPBEILHRDistributionSet
    {
        private int _nID;
        private int _nCompanyID;
        private string _sDepartment;
        private string _sDistributionSet;
        private string _sDistributionDescription;
        private string _sDistributionCode;
        private string _sExpenseType;
        private string _sDistributionType;
        private int _nAllowanceID;
        private string _sCompanyName;
        private string _sAllowanceType;
        private int _nAccpacAllowanceID;

        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for CompanyID
        // </summary>
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }

        public int AccpacAllowanceID
        {
            get { return _nAccpacAllowanceID; }
            set { _nAccpacAllowanceID = value; }
        }
        // <summary>
        // Get set property for Department
        // </summary>
        public string Department
        {
            get { return _sDepartment; }
            set { _sDepartment = value.Trim(); }
        }

        // <summary>
        // Get set property for DistributionSet
        // </summary>
        public string DistributionSet
        {
            get { return _sDistributionSet; }
            set { _sDistributionSet = value.Trim(); }
        }

        // <summary>
        // Get set property for DistributionDescription
        // </summary>
        public string DistributionDescription
        {
            get { return _sDistributionDescription; }
            set { _sDistributionDescription = value.Trim(); }
        }

        // <summary>
        // Get set property for DistributionCode
        // </summary>
        public string DistributionCode
        {
            get { return _sDistributionCode; }
            set { _sDistributionCode = value.Trim(); }
        }

        // <summary>
        // Get set property for ExpenseType
        // </summary>
        public string ExpenseType
        {
            get { return _sExpenseType; }
            set { _sExpenseType = value.Trim(); }
        }

        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value.Trim(); }
        }
        public string AllowanceType
        {
            get { return _sAllowanceType; }
            set { _sAllowanceType = value.Trim(); }
        }
        // <summary>
        // Get set property for DistributionType
        // </summary>
        public string DistributionType
        {
            get { return _sDistributionType; }
            set { _sDistributionType = value.Trim(); }
        }

        // <summary>
        // Get set property for AllowanceID
        // </summary>
        public int AllowanceID
        {
            get { return _nAllowanceID; }
            set { _nAllowanceID = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_MapERPBEILHRDistributionSet";
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
                sSql = "INSERT INTO t_MapERPBEILHRDistributionSet (ID, CompanyID, Department, DistributionSet, DistributionDescription, DistributionCode, ExpenseType, DistributionType, AllowanceID) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("Department", _sDepartment);
                cmd.Parameters.AddWithValue("DistributionSet", _sDistributionSet);
                cmd.Parameters.AddWithValue("DistributionDescription", _sDistributionDescription);
                cmd.Parameters.AddWithValue("DistributionCode", _sDistributionCode);
                cmd.Parameters.AddWithValue("ExpenseType", _sExpenseType);
                cmd.Parameters.AddWithValue("DistributionType", _sDistributionType);
                cmd.Parameters.AddWithValue("AllowanceID", _nAllowanceID);

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
                sSql = "UPDATE t_MapERPBEILHRDistributionSet SET CompanyID = ?, Department = ?, DistributionSet = ?, DistributionDescription = ?, DistributionCode = ?, ExpenseType = ?, DistributionType = ?, AllowanceID = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("Department", _sDepartment);
                cmd.Parameters.AddWithValue("DistributionSet", _sDistributionSet);
                cmd.Parameters.AddWithValue("DistributionDescription", _sDistributionDescription);
                cmd.Parameters.AddWithValue("DistributionCode", _sDistributionCode);
                cmd.Parameters.AddWithValue("ExpenseType", _sExpenseType);
                cmd.Parameters.AddWithValue("DistributionType", _sDistributionType);
                cmd.Parameters.AddWithValue("AllowanceID", _nAllowanceID);

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
                sSql = "DELETE FROM t_MapERPBEILHRDistributionSet WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_MapERPBEILHRDistributionSet where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nCompanyID = (int)reader["CompanyID"];
                    _sDepartment = (string)reader["Department"];
                    _sDistributionSet = (string)reader["DistributionSet"];
                    _sDistributionDescription = (string)reader["DistributionDescription"];
                    _sDistributionCode = (string)reader["DistributionCode"];
                    _sExpenseType = (string)reader["ExpenseType"];
                    _sDistributionType = (string)reader["DistributionType"];
                    _nAllowanceID = (int)reader["AllowanceID"];
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
    public class MapERPBEILHRDistributionSets : CollectionBase
    {
        public MapERPBEILHRDistributionSet this[int i]
        {
            get { return (MapERPBEILHRDistributionSet)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(MapERPBEILHRDistributionSet oMapERPBEILHRDistributionSet)
        {
            InnerList.Add(oMapERPBEILHRDistributionSet);
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
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_MapERPBEILHRDistributionSet";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MapERPBEILHRDistributionSet oMapERPBEILHRDistributionSet = new MapERPBEILHRDistributionSet();
                    oMapERPBEILHRDistributionSet.ID = (int)reader["ID"];
                    oMapERPBEILHRDistributionSet.CompanyID = (int)reader["CompanyID"];
                    oMapERPBEILHRDistributionSet.Department = (string)reader["Department"];
                    oMapERPBEILHRDistributionSet.DistributionSet = (string)reader["DistributionSet"];
                    oMapERPBEILHRDistributionSet.DistributionDescription = (string)reader["DistributionDescription"];
                    oMapERPBEILHRDistributionSet.DistributionCode = (string)reader["DistributionCode"];
                    oMapERPBEILHRDistributionSet.ExpenseType = (string)reader["ExpenseType"];
                    oMapERPBEILHRDistributionSet.DistributionType = (string)reader["DistributionType"];
                    oMapERPBEILHRDistributionSet.AllowanceID = (int)reader["AllowanceID"];
                    InnerList.Add(oMapERPBEILHRDistributionSet);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByBEILDistributionSet(int nAccpacAllowanceID,string sDistCode, string sDistSet)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT ID,a.CompanyID,CompanyName,Department,DistributionSet,DistributionDescription, " +
                           "DistributionCode,ExpenseType,DistributionType,AllowanceID,AccpacAllowanceID,c.Description as AllowanceType FROM t_MapERPBEILHRDistributionSet a, " +
                           "t_Company b, t_MapERPHRAccpacCJAllowanceID c where a.CompanyID = b.CompanyID And a.AllowanceID = c.AccpacAllowanceID " +
                           "And c.CompanyID = 82942 ";
            if (nAccpacAllowanceID != 0)
            {
                sSql += " AND AccpacAllowanceID=" + nAccpacAllowanceID + " ";
            }
            if (sDistCode != "")
            {
                sSql = sSql + " and DistributionCode like '%" + sDistCode + "%'";
            }
            if (sDistSet != "")
            {
                sSql = sSql + " and DistributionSet like '%" + sDistSet + "%'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MapERPBEILHRDistributionSet oMapERPBEILHRDistributionSet = new MapERPBEILHRDistributionSet();
                    oMapERPBEILHRDistributionSet.ID = (int)reader["ID"];
                    oMapERPBEILHRDistributionSet.CompanyID = (int)reader["CompanyID"];
                    oMapERPBEILHRDistributionSet.CompanyName = (string)reader["CompanyName"];
                    oMapERPBEILHRDistributionSet.AllowanceID = (int)reader["AllowanceID"];
                    oMapERPBEILHRDistributionSet.AccpacAllowanceID = (int)reader["AccpacAllowanceID"];
                    oMapERPBEILHRDistributionSet.AllowanceType = (string)reader["AllowanceType"];
                    oMapERPBEILHRDistributionSet.Department = (string)reader["Department"];
                    oMapERPBEILHRDistributionSet.DistributionSet = (string)reader["DistributionSet"];
                    oMapERPBEILHRDistributionSet.DistributionDescription = (string)reader["DistributionDescription"];
                    oMapERPBEILHRDistributionSet.DistributionCode = (string)reader["DistributionCode"];
                    oMapERPBEILHRDistributionSet.ExpenseType = (string)reader["ExpenseType"];
                    oMapERPBEILHRDistributionSet.DistributionType = (string)reader["DistributionType"];
                   
                    InnerList.Add(oMapERPBEILHRDistributionSet);
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


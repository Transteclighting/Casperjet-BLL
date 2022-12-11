using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.HR
{
    public class  MapERPBEILHREmployeeDistributionSet
    {
        private string _sEmployeeCode;
        private string _sEmployeeName;
        private string _sEmplDeptCode;
        private string _sDistributionSet;
        private string _sDistributionSetDescription;
        private string duplicateVale;


        // <summary>
        // Get set property for EmployeeCode
        // </summary>
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }

        // <summary>
        // Get set property for EmplDeptCode
        // </summary>
        public string EmplDeptCode
        {
            get { return _sEmplDeptCode; }
            set { _sEmplDeptCode = value.Trim(); }
        }

        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
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
        // Get set property for DistributionSetDescription
        // </summary>
        public string DistributionSetDescription
        {
            get { return _sDistributionSetDescription; }
            set { _sDistributionSetDescription = value.Trim(); }
        }

        public void BEILEmpAdd()
        {
            int nMaxEmployeeCode = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([EmployeeCode]) FROM t_MapERPBEILHREmployeeDistributionSet";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxEmployeeCode = 1;
                }
                else
                {
                    nMaxEmployeeCode = Convert.ToInt32(maxID) + 1;
                }
               // _sEmployeeCode = nMaxEmployeeCode;
                sSql = "INSERT INTO t_MapERPBEILHREmployeeDistributionSet (EmployeeCode, EmplDeptCode, DistributionSet, DistributionSetDescription) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("EmplDeptCode", _sEmplDeptCode);
                cmd.Parameters.AddWithValue("DistributionSet", _sDistributionSet);
                cmd.Parameters.AddWithValue("DistributionSetDescription", _sDistributionSetDescription);

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
                sSql = "UPDATE t_MapERPBEILHREmployeeDistributionSet SET EmplDeptCode = ?, DistributionSet = ?, DistributionSetDescription = ? WHERE EmployeeCode = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EmplDeptCode", _sEmplDeptCode);
                cmd.Parameters.AddWithValue("DistributionSet", _sDistributionSet);
                cmd.Parameters.AddWithValue("DistributionSetDescription", _sDistributionSetDescription);

                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);

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
                sSql = "DELETE FROM t_MapERPBEILHREmployeeDistributionSet WHERE [EmployeeCode]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
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
                cmd.CommandText = "SELECT * FROM t_MapERPBEILHREmployeeDistributionSet where EmployeeCode =?";
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
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
                cmd.CommandText = "SELECT * FROM t_MapERPBEILHREmployeeDistributionSet where EmployeeCode =?";
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sEmployeeCode = (string)reader["EmployeeCode"];
                    _sEmplDeptCode = (string)reader["EmplDeptCode"];
                    _sDistributionSet = (string)reader["DistributionSet"];
                    _sDistributionSetDescription = (string)reader["DistributionSetDescription"];
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
    public class MapERPBEILHREmployeeDistributionSets : CollectionBase
    {
        public MapERPBEILHREmployeeDistributionSet this[int i]
        {
            get { return (MapERPBEILHREmployeeDistributionSet)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(MapERPBEILHREmployeeDistributionSet oMapERPBEILHREmployeeDistributionSet)
        {
            InnerList.Add(oMapERPBEILHREmployeeDistributionSet);
        }
        public int GetIndex(string nEmployeeCode)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].EmployeeCode == nEmployeeCode)
                {
                    return i;
                }
            }
            return -1;
        }
        public void RefreshByBEILEmployeeDistSet(string sEmployeeCode, string sDistributionSet)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT m.EmployeeCode, e.EmployeeName, m.EmplDeptCode, m.DistributionSet, m.DistributionSetDescription FROM t_MapERPBEILHREmployeeDistributionSet m, t_Employee e where m.employeecode = e.employeecode";

            if (sEmployeeCode != null)
            {
                sSql = sSql + " AND m.EmployeeCode=" + sEmployeeCode + "";

            }

            if (sDistributionSet != "")
            {
                sSql = sSql + " and DistributionSet like '%" + sDistributionSet + "%'";

            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MapERPBEILHREmployeeDistributionSet oMapERPBEILHREmployeeDistributionSet = new MapERPBEILHREmployeeDistributionSet();
                    oMapERPBEILHREmployeeDistributionSet.EmployeeCode = (string)reader["EmployeeCode"];
                    oMapERPBEILHREmployeeDistributionSet.EmployeeName = (string)reader["EmployeeName"];
                    oMapERPBEILHREmployeeDistributionSet.EmplDeptCode = (string)reader["EmplDeptCode"];
                    oMapERPBEILHREmployeeDistributionSet.DistributionSet = (string)reader["DistributionSet"];
                    oMapERPBEILHREmployeeDistributionSet.DistributionSetDescription = (string)reader["DistributionSetDescription"];
                    InnerList.Add(oMapERPBEILHREmployeeDistributionSet);
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




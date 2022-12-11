using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.HR
{
    public class MapERPHREmployeeDistributionSet
    {
        private int _nCompanyID;
        private string _sEmployeeCode;
        private string _sDistributionSet; 
        private string _sEmployeeName;
        private string _sCompanyName;
        private int _nEmployeeID;
        private string duplicateVale;


        // <summary>
        // Get set property for CompanyID
        // </summary>
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }

        public int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }

        // <summary>
        // Get set property for EmployeeCode
        // </summary>
        public string EmployeeCode
        {
            get { return _sEmployeeCode; }
            set { _sEmployeeCode = value.Trim(); }
        }

        public string EmployeeName
        {
            get { return _sEmployeeName; }
            set { _sEmployeeName = value.Trim(); }
        }

        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value.Trim(); }
        }

        // <summary>
        // Get set property for DistributionSet
        // </summary>
        public string DistributionSet
        {
            get { return _sDistributionSet; }
            set { _sDistributionSet = value.Trim(); }
        }

        public void AddByDistributionSet()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([CompanyID]) FROM t_MapERPHREmployeeDistributionSet";
                cmd.CommandText = sSql;

                sSql = "INSERT INTO t_MapERPHREmployeeDistributionSet (CompanyID, EmployeeCode, DistributionSet) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("EmployeeCode", _sEmployeeCode);
                cmd.Parameters.AddWithValue("DistributionSet", _sDistributionSet);

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
                sSql = "UPDATE t_MapERPHREmployeeDistributionSet SET DistributionSet = ? WHERE CompanyID = ? and EmployeeCode = ?";
                //WHERE CompanyID = ? and DistributionSet = ?
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DistributionSet", _sDistributionSet);
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
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
                sSql = "DELETE FROM t_MapERPHREmployeeDistributionSet WHERE [CompanyID]=?";
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

        public string CheckDuplicateData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            duplicateVale = "No";
            try
            {
                cmd.CommandText = "SELECT * FROM t_MapERPHREmployeeDistributionSet where EmployeeCode =?";
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
                cmd.CommandText = "SELECT * FROM t_MapERPHREmployeeDistributionSet where CompanyID =?";
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCompanyID = (int)reader["CompanyID"];
                    _sEmployeeCode = (string)reader["EmployeeCode"];
                    _sDistributionSet = (string)reader["DistributionSet"];
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
    public class MapERPHREmployeeDistributionSets : CollectionBase
    {
        public MapERPHREmployeeDistributionSet this[int i]
        {
            get { return (MapERPHREmployeeDistributionSet)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(MapERPHREmployeeDistributionSet oMapERPHREmployeeDistributionSet)
        {
            InnerList.Add(oMapERPHREmployeeDistributionSet);
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
        public void RefreshByBllEmployeeDistSet(int nEmployeeID,string sDistributionSet)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            {
                 sSql = "SELECT m.CompanyID,EmployeeID, c.CompanyName, m.EmployeeCode, e.EmployeeName, m.DistributionSet FROM t_MapERPHREmployeeDistributionSet m, t_Employee e, t_company c where m.employeecode = e.employeecode and m.companyid = c.companyid and 1=1";
            }

            if (nEmployeeID != -1)
            {
                sSql += " AND EmployeeID = " + nEmployeeID + " ";
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
                    MapERPHREmployeeDistributionSet oMapERPHREmployeeDistributionSet = new MapERPHREmployeeDistributionSet();
                    oMapERPHREmployeeDistributionSet.CompanyID = (int)reader["CompanyID"];
                    oMapERPHREmployeeDistributionSet.EmployeeID = (int)reader["EmployeeID"];
                    oMapERPHREmployeeDistributionSet.EmployeeCode = (string)reader["EmployeeCode"];
                    oMapERPHREmployeeDistributionSet.EmployeeName = (string)reader["EmployeeName"];
                    oMapERPHREmployeeDistributionSet.DistributionSet = (string)reader["DistributionSet"];
                    oMapERPHREmployeeDistributionSet.CompanyName = (string)reader["CompanyName"];

                    InnerList.Add(oMapERPHREmployeeDistributionSet);
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



using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class BlldistributionSet
    {
        private int _nCompanyID;
        private string _sDistributionSet;
        private string _sDepartmentCode;
        private string _sASG;
        private string _sCompanyName;


        // <summary>
        // Get set property for CompanyID
        // </summary>
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }
        }

        // <summary>
        // Get set property for DistributionSet
        // </summary>
        public string DistributionSet
        {
            get { return _sDistributionSet; }
            set { _sDistributionSet = value.Trim(); }
        }

        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value.Trim(); }
        }
        // <summary>
        // Get set property for DepartmentCode
        // </summary>
        public string DepartmentCode
        {
            get { return _sDepartmentCode; }
            set { _sDepartmentCode = value.Trim(); }
        }

        // <summary>
        // Get set property for ASG
        // </summary>
        public string ASG
        {
            get { return _sASG; }
            set { _sASG = value.Trim(); }
        }

        public void Add()
        {
            int nMaxCompanyID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([CompanyID]) FROM t_BlldistributionSet";
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
                sSql = "INSERT INTO t_MapERPHRDistributionSet (CompanyID, DistributionSet, DepartmentCode, ASG) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("DistributionSet", _sDistributionSet);
                cmd.Parameters.AddWithValue("DepartmentCode", _sDepartmentCode);
                cmd.Parameters.AddWithValue("ASG", _sASG);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddByDistributionSet()
        {
            //int nMaxCompanyID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT * FROM t_BlldistributionSet";
                cmd.CommandText = sSql;
                //object maxID = cmd.ExecuteScalar();
                //if (maxID == DBNull.Value)
                //{
                //    nMaxCompanyID = 1;
                //}
                //else
                //{
                //    nMaxCompanyID = Convert.ToInt32(maxID) + 1;
                //}
                //_nCompanyID = nMaxCompanyID;
                sSql = "INSERT INTO t_MapERPHRDistributionSet (CompanyID, DistributionSet, DepartmentCode, ASG) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("DistributionSet", _sDistributionSet);
                cmd.Parameters.AddWithValue("DepartmentCode", _sDepartmentCode);
                cmd.Parameters.AddWithValue("ASG", _sASG);

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
                sSql = "UPDATE t_MapERPHRDistributionSet SET DepartmentCode = ?, ASG = ? WHERE CompanyID = ? And DistributionSet = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue("DistributionSet", _sDistributionSet);
                cmd.Parameters.AddWithValue("DepartmentCode", _sDepartmentCode);
                cmd.Parameters.AddWithValue("ASG", _sASG);

                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.Parameters.AddWithValue("DistributionSet", _sDistributionSet);

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
                sSql = "DELETE FROM t_MapERPHRDistributionSet WHERE [CompanyID]=?";
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
                cmd.CommandText = "SELECT * FROM t_MapERPHRDistributionSet where CompanyID =?";
                cmd.Parameters.AddWithValue("CompanyID", _nCompanyID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCompanyID = (int)reader["CompanyID"];
                    _sDistributionSet = (string)reader["DistributionSet"];
                    _sDepartmentCode = (string)reader["DepartmentCode"];
                    _sASG = (string)reader["ASG"];
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
    public class BlldistributionSets : CollectionBase
    {
        public BlldistributionSet this[int i]
        {
            get { return (BlldistributionSet)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(BlldistributionSet oBlldistributionSet)
        {
            InnerList.Add(oBlldistributionSet);
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
            string sSql = "SELECT * FROM t_BlldistributionSet";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BlldistributionSet oBlldistributionSet = new BlldistributionSet();
                    oBlldistributionSet.CompanyID = (int)reader["CompanyID"];
                    oBlldistributionSet.DistributionSet = (string)reader["DistributionSet"];
                    oBlldistributionSet.DepartmentCode = (string)reader["DepartmentCode"];
                    oBlldistributionSet.ASG = (string)reader["ASG"];
                    InnerList.Add(oBlldistributionSet);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByBllDistributionSet(string sDepartmentCode, string sDistSet)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT a.CompanyID,CompanyName,DistributionSet,DepartmentCode,ASG FROM t_MapERPHRDistributionSet a, t_Company b where a.CompanyID = b.CompanyID";

            if (sDepartmentCode != "")
            {
                sSql = sSql + " and DepartmentCode like '%" + sDepartmentCode + "%'";
            }
            if (sDistSet != "")
            {
                sSql = sSql + " and DistributionSet like '%" + sDistSet + "%'";
            }
            //sSql = sSql + " order by DistributionSet";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BlldistributionSet oBlldistributionSet = new BlldistributionSet();
                    oBlldistributionSet.CompanyID = (int)reader["CompanyID"];
                    oBlldistributionSet.CompanyName = (string)reader["CompanyName"];
                    oBlldistributionSet.DistributionSet = (string)reader["DistributionSet"];
                    oBlldistributionSet.DepartmentCode = (string)reader["DepartmentCode"];
                    oBlldistributionSet.ASG = (string)reader["ASG"];
                    InnerList.Add(oBlldistributionSet);
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



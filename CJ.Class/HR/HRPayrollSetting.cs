
// <summary>
// Company: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Jul 17, 2016
// Time : 05:28 PM
// Description: Class for HRPayrollSettings.
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
    public class HRPayrollSetting
    {
        private int _nID;
        private int _nPayrollID;
        private int _nSettingsID;
        private int _nSettingsTimes;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for PayrollID
        // </summary>
        public int PayrollID
        {
            get { return _nPayrollID; }
            set { _nPayrollID = value; }
        }

        // <summary>
        // Get set property for SettingsID
        // </summary>
        public int SettingsID
        {
            get { return _nSettingsID; }
            set { _nSettingsID = value; }
        }

        // <summary>
        // Get set property for SettingsTimes
        // </summary>
        public int SettingsTimes
        {
            get { return _nSettingsTimes; }
            set { _nSettingsTimes = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_HRPayrollSettings";
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
                sSql = "INSERT INTO t_HRPayrollSettings (ID, PayrollID, SettingsID, SettingsTimes) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("PayrollID", _nPayrollID);
                cmd.Parameters.AddWithValue("SettingsID", _nSettingsID);
                cmd.Parameters.AddWithValue("SettingsTimes", _nSettingsTimes);

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
                sSql = "UPDATE t_HRPayrollSettings SET PayrollID = ?, SettingsID = ?, SettingsTimes = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PayrollID", _nPayrollID);
                cmd.Parameters.AddWithValue("SettingsID", _nSettingsID);
                cmd.Parameters.AddWithValue("SettingsTimes", _nSettingsTimes);

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
                sSql = "DELETE FROM t_HRPayrollSettings WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_HRPayrollSettings where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nPayrollID = (int)reader["PayrollID"];
                    _nSettingsID = (int)reader["SettingsID"];
                    _nSettingsTimes = (int)reader["SettingsTimes"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool CheckSalaryType(int nPayrollID, int nSettingsID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * from dbo.t_HRPayrollSettings Where PayrollID=" + nPayrollID + " and SettingsID=" + nSettingsID + "";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                return true;
            else return false;

        }
    }
    public class HRPayrollSettings : CollectionBase
    {
        public HRPayrollSetting this[int i]
        {
            get { return (HRPayrollSetting)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(HRPayrollSetting oHRPayrollSetting)
        {
            InnerList.Add(oHRPayrollSetting);
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
        public void Refresh(int nPayrollID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_HRPayrollSettings Where PayrollID = " + nPayrollID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HRPayrollSetting oHRPayrollSetting = new HRPayrollSetting();

                    oHRPayrollSetting.ID = (int)reader["ID"];
                    oHRPayrollSetting.PayrollID = (int)reader["PayrollID"];
                    oHRPayrollSetting.SettingsID = (int)reader["SettingsID"];
                    oHRPayrollSetting.SettingsTimes = (int)reader["SettingsTimes"];
                    
                    InnerList.Add(oHRPayrollSetting);
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



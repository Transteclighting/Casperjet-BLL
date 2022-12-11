// <summary>
// Company: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Jun 23, 2016
// Time : 04:27 PM
// Description: Class for CSDSMSHelpline.
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
    public class CSDSMSHelpline
    {
        private int _nID;
        private int _nTypeOfJobSMS;
        private string _sName;
        private string _sHelpline;
        private string _sServiceTime;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for TypeOfJobSMS
        // </summary>
        public int TypeOfJobSMS
        {
            get { return _nTypeOfJobSMS; }
            set { _nTypeOfJobSMS = value; }
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
        // Get set property for Helpline
        // </summary>
        public string Helpline
        {
            get { return _sHelpline; }
            set { _sHelpline = value.Trim(); }
        }

        // <summary>
        // Get set property for ServiceTime
        // </summary>
        public string ServiceTime
        {
            get { return _sServiceTime; }
            set { _sServiceTime = value.Trim(); }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CSDSMSHelpline";
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
                sSql = "INSERT INTO t_CSDSMSHelpline (ID, TypeOfJobSMS, Name, Helpline, ServiceTime) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("TypeOfJobSMS", _nTypeOfJobSMS);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Helpline", _sHelpline);
                cmd.Parameters.AddWithValue("ServiceTime", _sServiceTime);

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
                sSql = "UPDATE t_CSDSMSHelpline SET TypeOfJobSMS = ?, Name = ?, Helpline = ?, ServiceTime = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TypeOfJobSMS", _nTypeOfJobSMS);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("Helpline", _sHelpline);
                cmd.Parameters.AddWithValue("ServiceTime", _sServiceTime);

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
                sSql = "DELETE FROM t_CSDSMSHelpline WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_CSDSMSHelpline where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nTypeOfJobSMS = (int)reader["TypeOfJobSMS"];
                    _sName = (string)reader["Name"];
                    _sHelpline = (string)reader["Helpline"];
                    _sServiceTime = (string)reader["ServiceTime"];
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
    public class CSDSMSHelplines : CollectionBase
    {
        public CSDSMSHelpline this[int i]
        {
            get { return (CSDSMSHelpline)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDSMSHelpline oCSDSMSHelpline)
        {
            InnerList.Add(oCSDSMSHelpline);
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
            string sSql = "SELECT * FROM t_CSDSMSHelpline ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDSMSHelpline oCSDSMSHelpline = new CSDSMSHelpline();
                    oCSDSMSHelpline.ID = (int)reader["ID"];
                    oCSDSMSHelpline.TypeOfJobSMS = (int)reader["TypeOfJobSMS"];
                    oCSDSMSHelpline.Name = (string)reader["Name"];
                    oCSDSMSHelpline.Helpline = (string)reader["Helpline"];
                    oCSDSMSHelpline.ServiceTime = (string)reader["ServiceTime"];
                    InnerList.Add(oCSDSMSHelpline);
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



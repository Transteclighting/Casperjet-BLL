// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Apr 25, 2019
// Time : 05:54 PM
// Description: Class for CACProjectSecurity.
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
    public class CACProjectSecurity
    {
        private int _nID;
        private int _nProjectID;
        private int _nSecurityID;
        private int _nInstrumentType;
        private DateTime _dExpDate;
        private double _Amount;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for ProjectID
        // </summary>
        public int ProjectID
        {
            get { return _nProjectID; }
            set { _nProjectID = value; }
        }
        public int InstrumentType
        {
            get { return _nInstrumentType; }
            set { _nInstrumentType = value; }
        }

        // <summary>
        // Get set property for SecurityID
        // </summary>
        public int SecurityID
        {
            get { return _nSecurityID; }
            set { _nSecurityID = value; }
        }

        // <summary>
        // Get set property for ExpDate
        // </summary>
        public DateTime ExpDate
        {
            get { return _dExpDate; }
            set { _dExpDate = value; }
        }

        // <summary>
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CACProjectSecurity";
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
                sSql = "INSERT INTO t_CACProjectSecurity (ID, ProjectID, SecurityID, InstrumentType, ExpDate, Amount) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("SecurityID", _nSecurityID);
                cmd.Parameters.AddWithValue("InstrumentType", _nInstrumentType);
                cmd.Parameters.AddWithValue("ExpDate", _dExpDate);
                cmd.Parameters.AddWithValue("Amount", _Amount);

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
                sSql = "UPDATE t_CACProjectSecurity SET ProjectID = ?, SecurityID = ?, InstrumentType = ?, ExpDate = ?, Amount = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("SecurityID", _nSecurityID);
                cmd.Parameters.AddWithValue("InstrumentType", _nInstrumentType);
                cmd.Parameters.AddWithValue("ExpDate", _dExpDate);
                cmd.Parameters.AddWithValue("Amount", _Amount);

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
                sSql = "DELETE FROM t_CACProjectSecurity WHERE [ID]=?";
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
        public void DeleteBySecurity(int _nProjectID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_CACProjectSecurity WHERE ProjectID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
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
                cmd.CommandText = "SELECT * FROM t_CACProjectSecurity where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nProjectID = (int)reader["ProjectID"];
                    _nSecurityID = (int)reader["SecurityID"];
                    _dExpDate = Convert.ToDateTime(reader["ExpDate"].ToString());
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
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
    public class CACProjectSecuritys : CollectionBase
    {
        public CACProjectSecurity this[int i]
        {
            get { return (CACProjectSecurity)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CACProjectSecurity oCACProjectSecurity)
        {
            InnerList.Add(oCACProjectSecurity);
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
        public void Refresh(int nProjectID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CACProjectSecurity where ProjectID="+ nProjectID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACProjectSecurity oCACProjectSecurity = new CACProjectSecurity();
                    oCACProjectSecurity.ID = (int)reader["ID"];
                    oCACProjectSecurity.ProjectID = (int)reader["ProjectID"];
                    oCACProjectSecurity.SecurityID = (int)reader["SecurityID"];
                    oCACProjectSecurity.InstrumentType = (int)reader["InstrumentType"];
                    oCACProjectSecurity.ExpDate = Convert.ToDateTime(reader["ExpDate"].ToString());
                    oCACProjectSecurity.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    InnerList.Add(oCACProjectSecurity);
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



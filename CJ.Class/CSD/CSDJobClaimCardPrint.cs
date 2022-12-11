// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Jan 01, 2017
// Time : 01:54 PM
// Description: Class for CSDJobClaimCardPrint.
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
    public class CSDJobClaimCardPrint
    {
        private int _nID;
        private int _nJobID;
        private int _nPrintUserID;
        private DateTime _dPrintDate;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for JobID
        // </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }

        // <summary>
        // Get set property for PrintUserID
        // </summary>
        public int PrintUserID
        {
            get { return _nPrintUserID; }
            set { _nPrintUserID = value; }
        }

        // <summary>
        // Get set property for PrintDate
        // </summary>
        public DateTime PrintDate
        {
            get { return _dPrintDate; }
            set { _dPrintDate = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CSDJobClaimCardPrint";
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
                sSql = "INSERT INTO t_CSDJobClaimCardPrint (ID, JobID, PrintUserID, PrintDate) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("PrintUserID", _nPrintUserID);
                cmd.Parameters.AddWithValue("PrintDate", _dPrintDate);

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
                sSql = "UPDATE t_CSDJobClaimCardPrint SET JobID = ?, PrintUserID = ?, PrintDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("PrintUserID", _nPrintUserID);
                cmd.Parameters.AddWithValue("PrintDate", _dPrintDate);

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
                sSql = "DELETE FROM t_CSDJobClaimCardPrint WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_CSDJobClaimCardPrint where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nJobID = (int)reader["JobID"];
                    _nPrintUserID = (int)reader["PrintUserID"];
                    _dPrintDate = Convert.ToDateTime(reader["PrintDate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool IsClaimCardReprint(int nJobID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            bool isReprint = false;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDJobClaimCardPrint where JobID = " + nJobID + " ";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isReprint= true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return isReprint;
        }
    }
    public class CSDJobClaimCardPrints : CollectionBase
    {
        public CSDJobClaimCardPrint this[int i]
        {
            get { return (CSDJobClaimCardPrint)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDJobClaimCardPrint oCSDJobClaimCardPrint)
        {
            InnerList.Add(oCSDJobClaimCardPrint);
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
            string sSql = "SELECT * FROM t_CSDJobClaimCardPrint";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJobClaimCardPrint oCSDJobClaimCardPrint = new CSDJobClaimCardPrint();
                    oCSDJobClaimCardPrint.ID = (int)reader["ID"];
                    oCSDJobClaimCardPrint.JobID = (int)reader["JobID"];
                    oCSDJobClaimCardPrint.PrintUserID = (int)reader["PrintUserID"];
                    oCSDJobClaimCardPrint.PrintDate = Convert.ToDateTime(reader["PrintDate"].ToString());
                    InnerList.Add(oCSDJobClaimCardPrint);
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


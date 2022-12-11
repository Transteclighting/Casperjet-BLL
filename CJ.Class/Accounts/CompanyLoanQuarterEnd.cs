// <summary>
// Company: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Apr 09, 2019
// Time : 04:47 PM
// Description: Class for CompanyLoanQuarterEnd.
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
    public class CompanyLoanQuarterEnd
    {
        private int _nID;
        private DateTime _dQuarterEndDate;
        private int _nNoOfLoanEffect;
        private int _nCreateUserID;
        private DateTime _dCreateDate;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for QuarterEndDate
        // </summary>
        public DateTime QuarterEndDate
        {
            get { return _dQuarterEndDate; }
            set { _dQuarterEndDate = value; }
        }

        // <summary>
        // Get set property for NoOfLoanEffect
        // </summary>
        public int NoOfLoanEffect
        {
            get { return _nNoOfLoanEffect; }
            set { _nNoOfLoanEffect = value; }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CompanyLoanQuarterEnd";
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
                sSql = "INSERT INTO t_CompanyLoanQuarterEnd (ID, QuarterEndDate, NoOfLoanEffect, CreateUserID, CreateDate) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("QuarterEndDate", _dQuarterEndDate);
                cmd.Parameters.AddWithValue("NoOfLoanEffect", _nNoOfLoanEffect);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

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
                sSql = "UPDATE t_CompanyLoanQuarterEnd SET QuarterEndDate = ?, NoOfLoanEffect = ?, CreateUserID = ?, CreateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("QuarterEndDate", _dQuarterEndDate);
                cmd.Parameters.AddWithValue("NoOfLoanEffect", _nNoOfLoanEffect);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

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
                sSql = "DELETE FROM t_CompanyLoanQuarterEnd WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_CompanyLoanQuarterEnd where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _dQuarterEndDate = Convert.ToDateTime(reader["QuarterEndDate"].ToString());
                    _nNoOfLoanEffect = (int)reader["NoOfLoanEffect"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
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
    public class CompanyLoanQuarterEnds : CollectionBase
    {
        public CompanyLoanQuarterEnd this[int i]
        {
            get { return (CompanyLoanQuarterEnd)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CompanyLoanQuarterEnd oCompanyLoanQuarterEnd)
        {
            InnerList.Add(oCompanyLoanQuarterEnd);
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
            string sSql = "SELECT * FROM t_CompanyLoanQuarterEnd";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyLoanQuarterEnd oCompanyLoanQuarterEnd = new CompanyLoanQuarterEnd();
                    oCompanyLoanQuarterEnd.ID = (int)reader["ID"];
                    oCompanyLoanQuarterEnd.QuarterEndDate = Convert.ToDateTime(reader["QuarterEndDate"].ToString());
                    oCompanyLoanQuarterEnd.NoOfLoanEffect = (int)reader["NoOfLoanEffect"];
                    oCompanyLoanQuarterEnd.CreateUserID = (int)reader["CreateUserID"];
                    oCompanyLoanQuarterEnd.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oCompanyLoanQuarterEnd);
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



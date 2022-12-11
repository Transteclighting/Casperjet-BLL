// <summary>
// Company: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Mar 07, 2019
// Time : 05:36 PM
// Description: Class for CompanyLoanInterest.
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
    public class CompanyLoanInterest
    {
        private int _nID;
        private int _nLoanID;
        private DateTime _dFromDate;
        private DateTime _dToDate;
        private int _nDays;
        private double _InterestOnPrincipal;
        private double _Interest;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for LoanID
        // </summary>
        public int LoanID
        {
            get { return _nLoanID; }
            set { _nLoanID = value; }
        }

        // <summary>
        // Get set property for FromDate
        // </summary>
        public DateTime FromDate
        {
            get { return _dFromDate; }
            set { _dFromDate = value; }
        }

        // <summary>
        // Get set property for ToDate
        // </summary>
        public DateTime ToDate
        {
            get { return _dToDate; }
            set { _dToDate = value; }
        }

        // <summary>
        // Get set property for Days
        // </summary>
        public int Days
        {
            get { return _nDays; }
            set { _nDays = value; }
        }

        // <summary>
        // Get set property for InterestOnPrincipal
        // </summary>
        public double InterestOnPrincipal
        {
            get { return _InterestOnPrincipal; }
            set { _InterestOnPrincipal = value; }
        }

        // <summary>
        // Get set property for Interest
        // </summary>
        public double Interest
        {
            get { return _Interest; }
            set { _Interest = value; }
        }
        private double _InterestRate;
        public double InterestRate
        {
            get { return _InterestRate; }
            set { _InterestRate = value; }
        }

        private int _nCreateUserID;
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        private DateTime _dCreateDate;
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
                sSql = "SELECT MAX([ID]) FROM t_CompanyLoanInterest";
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
                sSql = "INSERT INTO t_CompanyLoanInterest (ID, LoanID, FromDate, ToDate, Days, InterestOnPrincipal, Interest, InterestRate, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("LoanID", _nLoanID);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("Days", _nDays);
                cmd.Parameters.AddWithValue("InterestOnPrincipal", _InterestOnPrincipal);
                cmd.Parameters.AddWithValue("Interest", _Interest);
                cmd.Parameters.AddWithValue("InterestRate", _InterestRate);
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
                sSql = "UPDATE t_CompanyLoanInterest SET LoanID = ?, FromDate = ?, ToDate = ?, Days = ?, InterestOnPrincipal = ?, Interest = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LoanID", _nLoanID);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("ToDate", _dToDate);
                cmd.Parameters.AddWithValue("Days", _nDays);
                cmd.Parameters.AddWithValue("InterestOnPrincipal", _InterestOnPrincipal);
                cmd.Parameters.AddWithValue("Interest", _Interest);

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
                sSql = "DELETE FROM t_CompanyLoanInterest WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_CompanyLoanInterest where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nLoanID = (int)reader["LoanID"];
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    _nDays = (int)reader["Days"];
                    _InterestOnPrincipal = Convert.ToDouble(reader["InterestOnPrincipal"].ToString());
                    _Interest = Convert.ToDouble(reader["Interest"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool GetLastDataByLoanID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select top 1* from t_CompanyLoanInterest Where LoanID = ? Order by ID DESC";
                cmd.Parameters.AddWithValue("LoanID", _nLoanID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nLoanID = (int)reader["LoanID"];
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    _nDays = (int)reader["Days"];
                    _InterestOnPrincipal = Convert.ToDouble(reader["InterestOnPrincipal"].ToString());
                    _Interest = Convert.ToDouble(reader["Interest"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            if (nCount != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetTopOneData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT top 1* FROM t_CompanyLoanInterest where LoanID =? order by ID DESC";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nLoanID = (int)reader["LoanID"];
                    _dFromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    _dToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    _nDays = (int)reader["Days"];
                    _InterestOnPrincipal = Convert.ToDouble(reader["InterestOnPrincipal"].ToString());
                    _Interest = Convert.ToDouble(reader["Interest"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            if (nCount != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class CompanyLoanInterests : CollectionBase
    {
        public CompanyLoanInterest this[int i]
        {
            get { return (CompanyLoanInterest)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CompanyLoanInterest oCompanyLoanInterest)
        {
            InnerList.Add(oCompanyLoanInterest);
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
        public void Refresh(int nLoanID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CompanyLoanInterest where LoanID = "+ nLoanID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyLoanInterest oCompanyLoanInterest = new CompanyLoanInterest();
                    oCompanyLoanInterest.ID = (int)reader["ID"];
                    oCompanyLoanInterest.LoanID = (int)reader["LoanID"];
                    oCompanyLoanInterest.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oCompanyLoanInterest.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oCompanyLoanInterest.Days = (int)reader["Days"];
                    oCompanyLoanInterest.InterestOnPrincipal = Convert.ToDouble(reader["InterestOnPrincipal"].ToString());
                    oCompanyLoanInterest.Interest = Convert.ToDouble(reader["Interest"].ToString());
                    InnerList.Add(oCompanyLoanInterest);
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



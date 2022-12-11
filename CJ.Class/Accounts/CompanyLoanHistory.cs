// <summary>
// Company: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Mar 07, 2019
// Time : 05:27 PM
// Description: Class for CompanyLoanHistory.
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
    public class CompanyLoanHistory
    {
        private int _nID;
        private int _nLoanID;
        private DateTime _dTranDate;
        private int _nTranType;
        private string _sTranTypeName;
        private int _nTranSide;
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
        // Get set property for LoanID
        // </summary>
        public int LoanID
        {
            get { return _nLoanID; }
            set { _nLoanID = value; }
        }

        // <summary>
        // Get set property for TranDate
        // </summary>
        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
        }

        // <summary>
        // Get set property for TranType
        // </summary>
        public int TranType
        {
            get { return _nTranType; }
            set { _nTranType = value; }
        }

        public string TranTypeName
        {
            get { return _sTranTypeName; }
            set { _sTranTypeName = value; }
        }

        // <summary>
        // Get set property for TranSide
        // </summary>
        public int TranSide
        {
            get { return _nTranSide; }
            set { _nTranSide = value; }
        }

        // <summary>
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        private int _nCreateUserID;
        private DateTime _dCreateDate;
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
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
                sSql = "SELECT MAX([ID]) FROM t_CompanyLoanHistory";
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
                sSql = "INSERT INTO t_CompanyLoanHistory (ID, LoanID, TranDate, TranType, TranSide, Amount,CreateUserID,CreateDate) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("LoanID", _nLoanID);
                cmd.Parameters.AddWithValue("TranDate", _dTranDate);
                cmd.Parameters.AddWithValue("TranType", _nTranType);
                cmd.Parameters.AddWithValue("TranSide", _nTranSide);
                cmd.Parameters.AddWithValue("Amount", _Amount);
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
                sSql = "UPDATE t_CompanyLoanHistory SET LoanID = ?, TranDate = ?, TranType = ?, TranSide = ?, Amount = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LoanID", _nLoanID);
                cmd.Parameters.AddWithValue("TranDate", _dTranDate);
                cmd.Parameters.AddWithValue("TranType", _nTranType);
                cmd.Parameters.AddWithValue("TranSide", _nTranSide);
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
                sSql = "DELETE FROM t_CompanyLoanHistory WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_CompanyLoanHistory where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nLoanID = (int)reader["LoanID"];
                    _dTranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    _nTranType = (int)reader["TranType"];
                    _nTranSide = (int)reader["TranSide"];
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
    public class CompanyLoanHistorys : CollectionBase
    {
        public CompanyLoanHistory this[int i]
        {
            get { return (CompanyLoanHistory)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CompanyLoanHistory oCompanyLoanHistory)
        {
            InnerList.Add(oCompanyLoanHistory);
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
            string sSql = "SELECT * FROM t_CompanyLoanHistory where LoanID = "+ nLoanID + " ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyLoanHistory oCompanyLoanHistory = new CompanyLoanHistory();
                    oCompanyLoanHistory.ID = (int)reader["ID"];
                    oCompanyLoanHistory.LoanID = (int)reader["LoanID"];
                    oCompanyLoanHistory.TranDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oCompanyLoanHistory.TranType = (int)reader["TranType"];
                    oCompanyLoanHistory.TranTypeName = Enum.GetName(typeof(Dictionary.CompanyLoanTranType), oCompanyLoanHistory.TranType);
                    oCompanyLoanHistory.TranSide = (int)reader["TranSide"];
                    oCompanyLoanHistory.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    InnerList.Add(oCompanyLoanHistory);
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



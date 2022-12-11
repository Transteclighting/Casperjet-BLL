// <summary>
// Company: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Aug 01, 2016
// Time : 11:58 AM
// Description: Class for HRLoanType.
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
    public class LoanType
    {
        private int _nLoanTypeID;
        private string _sLoanTypeName;
        private int _nIsActive;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;


        // <summary>
        // Get set property for LoanTypeID
        // </summary>
        public int LoanTypeID
        {
            get { return _nLoanTypeID; }
            set { _nLoanTypeID = value; }
        }

        // <summary>
        // Get set property for LoanTypeName
        // </summary>
        public string LoanTypeName
        {
            get { return _sLoanTypeName; }
            set { _sLoanTypeName = value.Trim(); }
        }

        // <summary>
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
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

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        private string _sUserName;
        public string UserName
        {
            get { return _sUserName; }
            set { _sUserName = value; }
        }

        public void Add()
        {
            int nMaxLoanTypeID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([LoanTypeID]) FROM t_HRLoanType";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxLoanTypeID = 1;
                }
                else
                {
                    nMaxLoanTypeID = Convert.ToInt32(maxID) + 1;
                }
                _nLoanTypeID = nMaxLoanTypeID;
                sSql = "INSERT INTO t_HRLoanType (LoanTypeID, LoanTypeName, IsActive, CreateUserID, CreateDate) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LoanTypeID", _nLoanTypeID);
                cmd.Parameters.AddWithValue("LoanTypeName", _sLoanTypeName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
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
                sSql = "UPDATE t_HRLoanType SET LoanTypeName = ?, IsActive = ?, UpdateUserID = ?, UpdateDate = ? WHERE LoanTypeID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LoanTypeName", _sLoanTypeName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("LoanTypeID", _nLoanTypeID);

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
                sSql = "DELETE FROM t_HRLoanType WHERE [LoanTypeID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LoanTypeID", _nLoanTypeID);
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
                cmd.CommandText = "SELECT * FROM t_HRLoanType where LoanTypeID =?";
                cmd.Parameters.AddWithValue("LoanTypeID", _nLoanTypeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nLoanTypeID = (int)reader["LoanTypeID"];
                    _sLoanTypeName = (string)reader["LoanTypeName"];
                    _nIsActive = (int)reader["IsActive"];
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
    public class LoanTypes : CollectionBase
    {
        public LoanType this[int i]
        {
            get { return (LoanType)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(LoanType oLoanType)
        {
            InnerList.Add(oLoanType);
        }
        public int GetIndex(int nLoanTypeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].LoanTypeID == nLoanTypeID)
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
            string sSql = "SELECT a.*, UserFullName as UserName FROM t_HRLoanType a, t_User b Where a.CreateUserID=b.UserID Order by LoanTypeID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LoanType oLoanType = new LoanType();

                    oLoanType.LoanTypeID = (int)reader["LoanTypeID"];
                    oLoanType.LoanTypeName = (string)reader["LoanTypeName"];
                    oLoanType.IsActive = (int)reader["IsActive"];
                    oLoanType.CreateUserID = (int)reader["CreateUserID"];
                    oLoanType.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oLoanType.UserName = (string)reader["UserName"];

                    InnerList.Add(oLoanType);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshActiveData()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_HRLoanType Where IsActive=" + (int)Dictionary.YesOrNoStatus.YES + " Order by LoanTypeID ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LoanType oLoanType = new LoanType();

                    oLoanType.LoanTypeID = (int)reader["LoanTypeID"];
                    oLoanType.LoanTypeName = (string)reader["LoanTypeName"];

                    InnerList.Add(oLoanType);
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


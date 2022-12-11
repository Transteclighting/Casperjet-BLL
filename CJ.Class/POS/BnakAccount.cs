// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Aug 28, 2014
// Time :  05:45 PM
// Description: Class for Bank Account
// Modify Person And Date:
// </summary>


using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.POS
{
    public class Bnak_Account
    {

        private int _nBankAccountID;
        private string _sBankAccountNo;
        private int _nBankID;
        private string _sBankBranchName;
        private string _sBankName;
        private int _nIsActive;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        public int BankAccountID
        {
            get { return _nBankAccountID; }
            set { _nBankAccountID = value; }
        }
        public string BankAccountNo
        {
            get { return _sBankAccountNo; }
            set { _sBankAccountNo = value; }
        }
        public int BankID
        {
            get { return _nBankID; }
            set { _nBankID = value; }
        }
        public string BankBranchName
        {
            get { return _sBankBranchName; }
            set { _sBankBranchName = value; }
        }
        public string BankName
        {
            get { return _sBankName; }
            set { _sBankName = value; }
        }
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
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
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nMaxBankAccountID = 0;

            try
            {
                sSql = "SELECT MAX([BankAccountID]) FROM t_BankAccount";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBankAccountID = 1;
                }
                else
                {
                    nMaxBankAccountID = Convert.ToInt32(maxID) + 1;
                }
                if (_nBankAccountID == 0)
                {
                    _nBankAccountID = nMaxBankAccountID;
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "insert into t_BankAccount (BankAccountID,BankAccountNo,BankID,BankBranchName,IsActive,CreateUserID,CreateDate)  VALUES(?,?,?,?,?,?,?) ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BankAccountID", _nBankAccountID);
                cmd.Parameters.AddWithValue("BankAccountNo", _sBankAccountNo);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("BankBranchName", _sBankBranchName);
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
        public void Update()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "Update t_BankAccount Set BankAccountNo=?,BankID=?,BankBranchName=?,IsActive=?,UpdateUserID=?,UpdateDate=? Where BankAccountID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BankAccountNo", _sBankAccountNo);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("BankBranchName", _sBankBranchName);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("BankAccountID", _nBankAccountID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class Bnak_Accounts : CollectionBase
    {
        public Bnak_Account this[int i]
        {
            get { return (Bnak_Account)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Bnak_Account oBnak_Account)
        {
            InnerList.Add(oBnak_Account);
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_BankAccount ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    Bnak_Account oBnak_Account = new Bnak_Account();

                    oBnak_Account.BankAccountID = (int)reader["BankAccountID"];
                    oBnak_Account.BankAccountNo = (string)reader["BankAccountNo"];
                    oBnak_Account.BankID = (int)reader["BankID"];
                    oBnak_Account.BankBranchName = (string)reader["BankBranchName"];
                    oBnak_Account.IsActive = (int)reader["IsActive"];

                    InnerList.Add(oBnak_Account);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetActiveBankAccount()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT BankAccountID, BankAccountNo, b.Name as BankName FROM t_BankAccount a, t_Bank b Where a.BankID=b.BankID and IsActive = 1 order by a.BankID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Bnak_Account oBnak_Account = new Bnak_Account();

                    oBnak_Account.BankAccountID = (int)reader["BankAccountID"];
                    //oBnak_Account.BankAccountNo = (string)reader["BankAccountNo"];
                    oBnak_Account.BankName = reader["BankName"] + "[" + reader["BankAccountNo"] + "]";

                    InnerList.Add(oBnak_Account);
                }

                reader.Close();
                InnerList.TrimToSize();

                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}


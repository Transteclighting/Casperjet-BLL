// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Apr 09, 2019
// Time : 01:53 PM
// Description: Class for PettyCashExpenseHead.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.POS
{
    public class PettyCashExpenseHead
    {
        private int _nExpenseHeadID;
        private string _sDescription;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private DateTime _dUpdateDate;
        private int _nUpdateUserID;
        private int _nIsActive;
        private string _sUserName;


        // <summary>
        // Get set property for ExpenseHeadID
        // </summary>
        public int ExpenseHeadID
        {
            get { return _nExpenseHeadID; }
            set { _nExpenseHeadID = value; }
        }

        // <summary>
        // Get set property for Description
        // </summary>
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }

        public string UserName
        {
            get { return _sUserName; }
            set { _sUserName = value.Trim(); }
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
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
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
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        public void Add()
        {
            int nMaxExpenseHeadID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ExpenseHeadID]) FROM t_PettyCashExpenseHead";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxExpenseHeadID = 1;
                }
                else
                {
                    nMaxExpenseHeadID = Convert.ToInt32(maxID) + 1;
                }
                _nExpenseHeadID = nMaxExpenseHeadID;
                sSql = "INSERT INTO t_PettyCashExpenseHead (ExpenseHeadID, Description, CreateDate, CreateUserID,IsActive) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ExpenseHeadID", _nExpenseHeadID);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                //cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                //cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

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
                sSql = "UPDATE t_PettyCashExpenseHead SET Description = ?, CreateDate = ?, CreateUserID = ?, UpdateDate = ?, UpdateUserID = ?, IsActive = ? WHERE ExpenseHeadID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.Parameters.AddWithValue("ExpenseHeadID", _nExpenseHeadID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditExpenseHead()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PettyCashExpenseHead SET Description = ?, UpdateDate = ?, UpdateUserID = ?, IsActive = ? WHERE ExpenseHeadID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.Parameters.AddWithValue("ExpenseHeadID", _nExpenseHeadID);

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
                sSql = "DELETE FROM t_PettyCashExpenseHead WHERE [ExpenseHeadID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ExpenseHeadID", _nExpenseHeadID);
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
                cmd.CommandText = "SELECT * FROM t_PettyCashExpenseHead where ExpenseHeadID =?";
                cmd.Parameters.AddWithValue("ExpenseHeadID", _nExpenseHeadID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nExpenseHeadID = (int)reader["ExpenseHeadID"];
                    _sDescription = (string)reader["Description"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _nIsActive = (int)reader["IsActive"];
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
    public class PettyCashExpenseHeads : CollectionBase
    {
        public PettyCashExpenseHead this[int i]
        {
            get { return (PettyCashExpenseHead)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PettyCashExpenseHead oPettyCashExpenseHead)
        {
            InnerList.Add(oPettyCashExpenseHead);
        }
        public int GetIndex(int nExpenseHeadID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ExpenseHeadID == nExpenseHeadID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(string sDescription, int nIsActive)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            {
                sSql = "Select ExpenseHeadID,Description,CreateDate,UserName,IsActive from t_PettyCashExpenseHead a,t_User b where a.CreateUserID=b.UserID";
            }

            if (sDescription != "")
            {
                sSql = sSql + " AND Description like '%" + sDescription + "%'";
            }
            if (nIsActive != -1)
            {
                sSql = sSql + " AND IsActive=" + nIsActive + "";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PettyCashExpenseHead oPettyCashExpenseHead = new PettyCashExpenseHead();
                    oPettyCashExpenseHead.ExpenseHeadID = (int)reader["ExpenseHeadID"];
                    oPettyCashExpenseHead.Description = (string)reader["Description"];
                    oPettyCashExpenseHead.UserName = (string)reader["UserName"];
                    oPettyCashExpenseHead.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    //oPettyCashExpenseHead.CreateUserID = (int)reader["CreateUserID"];
                    //oPettyCashExpenseHead.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    //oPettyCashExpenseHead.UpdateUserID = (int)reader["UpdateUserID"];
                    oPettyCashExpenseHead.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oPettyCashExpenseHead);
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



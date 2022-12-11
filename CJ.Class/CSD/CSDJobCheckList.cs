// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Jan 04, 2017
// Time : 10:27 AM
// Description: Class for CSDJobCheckList.
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
    public class CSDJobCheckList
    {
        private int _nID;
        private int _nJobID;
        private int _nProductCheckListID;
        private string _sProductName;
        private string _sDescription;
        private int _nCreateStage;
        private int _nCreateUserID;
        private DateTime _dCreateDate;


        // <summary>
        // Get set property for ProductName
        // </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }

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
        // Get set property for ProductCheckListID
        // </summary>
        public int ProductCheckListID
        {
            get { return _nProductCheckListID; }
            set { _nProductCheckListID = value; }
        }

        // <summary>
        // Get set property for Description
        // </summary>
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }

        // <summary>
        // Get set property for CreateStage
        // </summary>
        public int CreateStage
        {
            get { return _nCreateStage; }
            set { _nCreateStage = value; }
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
                sSql = "SELECT MAX([ID]) FROM t_CSDJobCheckList";
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
                sSql = "INSERT INTO t_CSDJobCheckList (ID, JobID, ProductCheckListID, Description, CreateStage, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("ProductCheckListID", _nProductCheckListID);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("CreateStage", _nCreateStage);
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
                sSql = "UPDATE t_CSDJobCheckList SET JobID = ?, ProductCheckListID = ?, Description = ?, CreateStage = ?, CreateUserID = ?, CreateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("ProductCheckListID", _nProductCheckListID);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("CreateStage", _nCreateStage);
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
                sSql = "DELETE FROM t_CSDJobCheckList WHERE [JobID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("JobID", _nJobID);
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
                cmd.CommandText = "SELECT * FROM t_CSDJobCheckList where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nJobID = (int)reader["JobID"];
                    _nProductCheckListID = (int)reader["ProductCheckListID"];
                    _sDescription = (string)reader["Description"];
                    _nCreateStage = (int)reader["CreateStage"];
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
    public class CSDJobCheckLists : CollectionBase
    {
        public CSDJobCheckList this[int i]
        {
            get { return (CSDJobCheckList)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDJobCheckList oCSDJobCheckList)
        {
            InnerList.Add(oCSDJobCheckList);
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
        public void Refresh(int nJobID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CSDJobCheckList WHERE JobID = " + nJobID + " ";
            //cmd.Parameters.AddWithValue("JobID", _nJobID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJobCheckList oCSDJobCheckList = new CSDJobCheckList();
                    oCSDJobCheckList.ID = (int)reader["ID"];
                    oCSDJobCheckList.JobID = (int)reader["JobID"];
                    oCSDJobCheckList.ProductCheckListID = (int)reader["ProductCheckListID"];
                    oCSDJobCheckList.Description = (string)reader["Description"];
                    oCSDJobCheckList.CreateStage = (int)reader["CreateStage"];
                    oCSDJobCheckList.CreateUserID = (int)reader["CreateUserID"];
                    oCSDJobCheckList.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oCSDJobCheckList);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetProductChecList(int nJobID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "select b.Description AS ProductName, a.Description  from dbo.t_CSDJobCheckList a, "
                          +" t_CSDProductCheckList b WHERE a.ProductCheckListID = b.ProductCheckListID "
                          +" AND JobID = " + nJobID + " ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJobCheckList oCSDJobCheckList = new CSDJobCheckList();                    
                    oCSDJobCheckList.Description = (string)reader["Description"];
                    oCSDJobCheckList.ProductName = (string)reader["ProductName"];
                    InnerList.Add(oCSDJobCheckList);
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




// <summary>
// Company: Transcom Electronics Limited
// Author: Md. Abdul Arif Sarker
// Date: May 09, 2019
// Time : 02:20 PM
// Description: Class for CACProjectCollection.
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
    public class CACProjectCollection
    {
        private int _nCollectionID;
        private int _nCustomerID;
        private int _nProjectID;
        private string _sTranNo;
        private double _Amount;
        private int _nCreateUserID;
        private DateTime _dCreateDate;


        // <summary>
        // Get set property for CollectionID
        // </summary>
        public int CollectionID
        {
            get { return _nCollectionID; }
            set { _nCollectionID = value; }
        }

        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }


        // <summary>
        // Get set property for ProjectID
        // </summary>
        public int ProjectID
        {
            get { return _nProjectID; }
            set { _nProjectID = value; }
        }

        // <summary>
        // Get set property for TranNo
        // </summary>
        public string TranNo
        {
            get { return _sTranNo; }
            set { _sTranNo = value.Trim(); }
        }

        // <summary>
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
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
            int nMaxCollectionID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([CollectionID]) FROM t_CACProjectCollection";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxCollectionID = 1;
                }
                else
                {
                    nMaxCollectionID = Convert.ToInt32(maxID) + 1;
                }
                _nCollectionID = nMaxCollectionID;
                sSql = "INSERT INTO t_CACProjectCollection (CollectionID, ProjectID, TranNo, Amount, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CollectionID", _nCollectionID);
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
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
                sSql = "UPDATE t_CACProjectCollection SET ProjectID = ?, TranNo = ?, Amount = ?, CreateUserID = ?, CreateDate = ? WHERE CollectionID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("CollectionID", _nCollectionID);

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
                sSql = "DELETE FROM t_CACProjectCollection WHERE [CollectionID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CollectionID", _nCollectionID);
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
                cmd.CommandText = "SELECT * FROM t_CACProjectCollection where CollectionID =?";
                cmd.Parameters.AddWithValue("CollectionID", _nCollectionID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCollectionID = (int)reader["CollectionID"];
                    _nProjectID = (int)reader["ProjectID"];
                    _sTranNo = (string)reader["TranNo"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
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

        public void GetAmount()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT TranNo, Amount,CustomerID FROM t_CustomerTran where TranNo =? and CustomerID =?";
                cmd.Parameters.AddWithValue("TranNo", _sTranNo);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sTranNo = (string)reader["TranNo"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _nCustomerID= (int)reader["CustomerID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetCACCProjectollectionAmount(string sTranNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT TranNo, Amount,CustomerID FROM t_CustomerTran where TranNo ='"+ sTranNo + "' ";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sTranNo = (string)reader["TranNo"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _nCustomerID = (int)reader["CustomerID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


    }
    public class CACProjectCollections : CollectionBase
    {
        public CACProjectCollection this[int i]
        {
            get { return (CACProjectCollection)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CACProjectCollection oCACProjectCollection)
        {
            InnerList.Add(oCACProjectCollection);
        }
        public int GetIndex(int nCollectionID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].CollectionID == nCollectionID)
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
            string sSql = "SELECT * FROM t_CACProjectCollection";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACProjectCollection oCACProjectCollection = new CACProjectCollection();
                    oCACProjectCollection.CollectionID = (int)reader["CollectionID"];
                    oCACProjectCollection.ProjectID = (int)reader["ProjectID"];
                    oCACProjectCollection.TranNo = (string)reader["TranNo"];
                    oCACProjectCollection.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oCACProjectCollection.CreateUserID = (int)reader["CreateUserID"];
                    oCACProjectCollection.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oCACProjectCollection);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByCollectionAmount(int nProjectID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from t_CACProjectCollection where ProjectID="+nProjectID+"";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACProjectCollection oCACProjectCollection = new CACProjectCollection();
                    oCACProjectCollection.CollectionID = (int)reader["CollectionID"];
                    oCACProjectCollection.ProjectID = (int)reader["ProjectID"];
                    oCACProjectCollection.TranNo = (string)reader["TranNo"];
                    oCACProjectCollection.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oCACProjectCollection.CreateUserID = (int)reader["CreateUserID"];
                    oCACProjectCollection.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oCACProjectCollection);
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


// <summary>
// Company: Transcom Electronics Limited
// Author: Md. Abdul Arif Sarker
// Date: May 09, 2019
// Time : 11:12 AM
// Description: Class for CACProjectCollectionSchedule.
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
    public class CACProjectCollectionSchedule
    {
        private int _nCollectionScheduleID;
        private int _nProjectID;
        private DateTime _dPaymentDate;
        private string _sDescription;
        private double _nCompletePercentage;
        private double _nAmount;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private double _nCollection;
        private int _nIsFullCollect;


        // <summary>
        // Get set property for CollectionScheduleID
        // </summary>
        public int CollectionScheduleID
        {
            get { return _nCollectionScheduleID; }
            set { _nCollectionScheduleID = value; }
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
        // Get set property for PaymentDate
        // </summary>
        public DateTime PaymentDate
        {
            get { return _dPaymentDate; }
            set { _dPaymentDate = value; }
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
        // Get set property for CompletePercentage
        // </summary>
        public double CompletePercentage
        {
            get { return _nCompletePercentage; }
            set { _nCompletePercentage = value; }
        }

        // <summary>
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _nAmount; }
            set { _nAmount = value; }
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
        // Get set property for Collection
        // </summary>
        public double Collection
        {
            get { return _nCollection; }
            set { _nCollection = value; }
        }

        // <summary>
        // Get set property for IsFullCollect
        // </summary>
        public int IsFullCollect
        {
            get { return _nIsFullCollect; }
            set { _nIsFullCollect = value; }
        }

        public void Add()
        {
            int nMaxCollectionScheduleID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([CollectionScheduleID]) FROM t_CACProjectCollectionSchedule";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxCollectionScheduleID = 1;
                }
                else
                {
                    nMaxCollectionScheduleID = Convert.ToInt32(maxID) + 1;
                }
                _nCollectionScheduleID = nMaxCollectionScheduleID;
                sSql = "INSERT INTO t_CACProjectCollectionSchedule (CollectionScheduleID, ProjectID, PaymentDate, Description, CompletePercentage, Amount, CreateUserID, CreateDate, Collection, IsFullCollect) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CollectionScheduleID", _nCollectionScheduleID);
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("PaymentDate", _dPaymentDate);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("CompletePercentage", _nCompletePercentage);
                cmd.Parameters.AddWithValue("Amount", _nAmount);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Collection", _nCollection);
                cmd.Parameters.AddWithValue("IsFullCollect", _nIsFullCollect);

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
                sSql = "UPDATE t_CACProjectCollectionSchedule SET ProjectID = ?, PaymentDate = ?, Description = ?, CompletePercentage = ?, Amount = ?, CreateUserID = ?, CreateDate = ?, Collection = ?, IsFullCollect = ? WHERE CollectionScheduleID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("PaymentDate", _dPaymentDate);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("CompletePercentage", _nCompletePercentage);
                cmd.Parameters.AddWithValue("Amount", _nAmount);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Collection", _nCollection);
                cmd.Parameters.AddWithValue("IsFullCollect", _nIsFullCollect);

                cmd.Parameters.AddWithValue("CollectionScheduleID", _nCollectionScheduleID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void UpdateFromCollection()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CACProjectCollectionSchedule SET Collection = ?, IsFullCollect = ? WHERE ProjectID = ? and CollectionScheduleID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Collection", _nCollection);
                cmd.Parameters.AddWithValue("IsFullCollect", _nIsFullCollect);
                cmd.Parameters.AddWithValue("ProjectID", _nProjectID);
                cmd.Parameters.AddWithValue("CollectionScheduleID", _nCollectionScheduleID);

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
                sSql = "DELETE FROM t_CACProjectCollectionSchedule WHERE [CollectionScheduleID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CollectionScheduleID", _nCollectionScheduleID);
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
                cmd.CommandText = "SELECT * FROM t_CACProjectCollectionSchedule where CollectionScheduleID =?";
                cmd.Parameters.AddWithValue("CollectionScheduleID", _nCollectionScheduleID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCollectionScheduleID = (int)reader["CollectionScheduleID"];
                    _nProjectID = (int)reader["ProjectID"];
                    _dPaymentDate = Convert.ToDateTime(reader["PaymentDate"].ToString());
                    _sDescription = (string)reader["Description"];
                    _nCompletePercentage = (double)reader["CompletePercentage"];
                    _nAmount = (double)reader["Amount"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCollection = (double)reader["Collection"];
                    _nIsFullCollect = (int)reader["IsFullCollect"];
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
    public class CACProjectCollectionSchedules : CollectionBase
    {
        public CACProjectCollectionSchedule this[int i]
        {
            get { return (CACProjectCollectionSchedule)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CACProjectCollectionSchedule oCACProjectCollectionSchedule)
        {
            InnerList.Add(oCACProjectCollectionSchedule);
        }
        public int GetIndex(int nCollectionScheduleID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].CollectionScheduleID == nCollectionScheduleID)
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
            string sSql = "SELECT * FROM t_CACProjectCollectionSchedule";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACProjectCollectionSchedule oCACProjectCollectionSchedule = new CACProjectCollectionSchedule();
                    oCACProjectCollectionSchedule.CollectionScheduleID = (int)reader["CollectionScheduleID"];
                    oCACProjectCollectionSchedule.ProjectID = (int)reader["ProjectID"];
                    oCACProjectCollectionSchedule.PaymentDate = Convert.ToDateTime(reader["PaymentDate"].ToString());
                    oCACProjectCollectionSchedule.Description = (string)reader["Description"];
                    oCACProjectCollectionSchedule.CompletePercentage = (double)reader["CompletePercentage"];
                    oCACProjectCollectionSchedule.Amount = (double)reader["Amount"];
                    oCACProjectCollectionSchedule.CreateUserID = (int)reader["CreateUserID"];
                    oCACProjectCollectionSchedule.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCACProjectCollectionSchedule.Collection = (double)reader["Collection"];
                    oCACProjectCollectionSchedule.IsFullCollect = (int)reader["IsFullCollect"];
                    InnerList.Add(oCACProjectCollectionSchedule);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetDataBasedOnCollection(int projectID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT CollectionScheduleID, ProjectID, PaymentDate, Amount, Collection, IsFullCollect FROM t_CACProjectCollectionSchedule where ProjectID = " + projectID+ " and  IsFullCollect = 0 order by PaymentDate ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CACProjectCollectionSchedule oCACProjectCollectionSchedule = new CACProjectCollectionSchedule();
                    oCACProjectCollectionSchedule.CollectionScheduleID = (int)reader["CollectionScheduleID"];
                    oCACProjectCollectionSchedule.ProjectID = (int)reader["ProjectID"];
                    oCACProjectCollectionSchedule.Amount = (double)reader["Amount"];
                    oCACProjectCollectionSchedule.PaymentDate = Convert.ToDateTime(reader["PaymentDate"]);
                    oCACProjectCollectionSchedule.Collection = (double)reader["Collection"];
                    oCACProjectCollectionSchedule.IsFullCollect = (int)reader["IsFullCollect"];
                    InnerList.Add(oCACProjectCollectionSchedule);
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


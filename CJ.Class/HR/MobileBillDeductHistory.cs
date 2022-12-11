// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Sep 05, 2016
// Time : 12:45 PM
// Description: Class for MobileBillDeductHistory.
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
    public class MobileBillDeductHistory
    {
        private int _nID;
        private int _nAprovalUserID;
        private DateTime _dCreateDate;
        private int _nBillID;
        private double _DeductAmount;
        private double _nApproveAmount;


        public double ApproveAmount
        {
            get { return _nApproveAmount; }
            set { _nApproveAmount = value; }
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
        // Get set property for AprovalUserID
        // </summary>
        public int AprovalUserID
        {
            get { return _nAprovalUserID; }
            set { _nAprovalUserID = value; }
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
        // Get set property for BillID
        // </summary>
        public int BillID
        {
            get { return _nBillID; }
            set { _nBillID = value; }
        }

        // <summary>
        // Get set property for DeductAmount
        // </summary>
        public double DeductAmount
        {
            get { return _DeductAmount; }
            set { _DeductAmount = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_MobileBillDeductHistory";
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
                sSql = "INSERT INTO t_MobileBillDeductHistory (ID, AprovalUserID, CreateDate, BillID, DeductAmount) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("AprovalUserID", _nAprovalUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("BillID", _nBillID);
                cmd.Parameters.AddWithValue("DeductAmount", _DeductAmount);

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
                sSql = "UPDATE t_MobileBillDeductHistory SET AprovalUserID = ?, CreateDate = ?, BillID = ?, DeductAmount = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AprovalUserID", _nAprovalUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("BillID", _nBillID);
                cmd.Parameters.AddWithValue("DeductAmount", _DeductAmount);

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
                sSql = "DELETE FROM t_MobileBillDeductHistory WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_MobileBillDeductHistory where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nAprovalUserID = (int)reader["AprovalUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nBillID = (int)reader["BillID"];
                    _DeductAmount = Convert.ToDouble(reader["DeductAmount"].ToString());
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
    public class MobileBillDeductHistorys : CollectionBase
    {
        public MobileBillDeductHistory this[int i]
        {
            get { return (MobileBillDeductHistory)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(MobileBillDeductHistory oMobileBillDeductHistory)
        {
            InnerList.Add(oMobileBillDeductHistory);
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
            string sSql = "SELECT * FROM t_MobileBillDeductHistory";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MobileBillDeductHistory oMobileBillDeductHistory = new MobileBillDeductHistory();
                    oMobileBillDeductHistory.ID = (int)reader["ID"];
                    oMobileBillDeductHistory.AprovalUserID = (int)reader["AprovalUserID"];
                    oMobileBillDeductHistory.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oMobileBillDeductHistory.BillID = (int)reader["BillID"];
                    oMobileBillDeductHistory.DeductAmount = Convert.ToDouble(reader["DeductAmount"].ToString());
                    InnerList.Add(oMobileBillDeductHistory);
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


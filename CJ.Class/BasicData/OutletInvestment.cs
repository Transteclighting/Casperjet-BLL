// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Oct 18, 2020
// Time : 04:19 PM
// Description: Class for OutletInvestment.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.BasicData
{
    public class OutletInvestment
    {
        private int _nInvestmentID;
        private string _sDescription;
        private double _Amount;
        private string _sRemarks;
        private int _nCreateBy;
        private DateTime _dCreateDate;


        // <summary>
        // Get set property for InvestmentID
        // </summary>
        public int InvestmentID
        {
            get { return _nInvestmentID; }
            set { _nInvestmentID = value; }
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
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        // <summary>
        // Get set property for CreateBy
        // </summary>
        public int CreateBy
        {
            get { return _nCreateBy; }
            set { _nCreateBy = value; }
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
            int nMaxInvestmentID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([InvestmentID]) FROM t_OutletInvestment";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxInvestmentID = 1;
                }
                else
                {
                    nMaxInvestmentID = Convert.ToInt32(maxID) + 1;
                }
                _nInvestmentID = nMaxInvestmentID;
                sSql = "INSERT INTO t_OutletInvestment (InvestmentID, Description, Amount, Remarks, CreateBy, CreateDate) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvestmentID", _nInvestmentID);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateBy", _nCreateBy);
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
                sSql = "UPDATE t_OutletInvestment SET Description = ?, Amount = ?, Remarks = ? WHERE InvestmentID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("InvestmentID", _nInvestmentID);

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
                sSql = "DELETE FROM t_OutletInvestment WHERE [InvestmentID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InvestmentID", _nInvestmentID);
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
                cmd.CommandText = "SELECT * FROM t_OutletInvestment where InvestmentID =?";
                cmd.Parameters.AddWithValue("InvestmentID", _nInvestmentID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nInvestmentID = (int)reader["InvestmentID"];
                    _sDescription = (string)reader["Description"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _sRemarks = (string)reader["Remarks"];
                    _nCreateBy = (int)reader["CreateBy"];
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
    public class OutletInvestments : CollectionBase
    {
        public OutletInvestment this[int i]
        {
            get { return (OutletInvestment)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OutletInvestment oOutletInvestment)
        {
            InnerList.Add(oOutletInvestment);
        }
        public int GetIndex(int nInvestmentID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].InvestmentID == nInvestmentID)
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
            string sSql = "SELECT * FROM t_OutletInvestment";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletInvestment oOutletInvestment = new OutletInvestment();
                    oOutletInvestment.InvestmentID = (int)reader["InvestmentID"];
                    oOutletInvestment.Description = (string)reader["Description"];
                    oOutletInvestment.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oOutletInvestment.Remarks = (string)reader["Remarks"];
                    oOutletInvestment.CreateBy = (int)reader["CreateBy"];
                    oOutletInvestment.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oOutletInvestment);
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



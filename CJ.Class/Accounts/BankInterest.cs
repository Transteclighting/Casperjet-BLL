// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD. Humayun Rashid
// Date: Jul 26, 2015
// Time : 03:59 PM
// Description: Class for BankIst.
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
    public class BankIst
    {
        private int _nID;
        private int _nBankID;
        private int _nEMINo;
        private double _InsRate;
        private string _sBankName;
        private int _nIsActive;
        private DateTime _dtEffectiveFrom;
        private object _dtEffectiveTo;

        public DateTime EffectiveFrom
        {
            get { return _dtEffectiveFrom; }
            set { _dtEffectiveFrom = value; }
        }
        public object EffectiveTo
        {
            get { return _dtEffectiveTo; }
            set { _dtEffectiveTo = value; }
        }

        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        // <summary>
        // Get set property for BankID
        // </summary>
        public int BankID
        {
            get { return _nBankID; }
            set { _nBankID = value; }
        }


        // <summary>
        // Get set property for BankName
        // </summary>
        public string BankName
        {
            get { return _sBankName; }
            set { _sBankName = value; }
        }

        // <summary>
        // Get set property for EMINo
        // </summary>
        public int EMINo
        {
            get { return _nEMINo; }
            set { _nEMINo = value; }
        }
        
        // <summary>
        // Get set property for InsRate
        // </summary>
        public double InsRate
        {
            get { return _InsRate; }
            set { _InsRate = value; }
        }

        public void Add()
        {
            int nMaxBankID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                //if (_nBankID == 0)
                //{
                //    sSql = "SELECT MAX([BankID]) FROM t_BankInterest";
                //    cmd.CommandText = sSql;
                //    object maxID = cmd.ExecuteScalar();
                //    if (maxID == DBNull.Value)
                //    {
                //        nMaxBankID = 1;
                //    }
                //    else
                //    {
                //        nMaxBankID = Convert.ToInt32(maxID) + 1;
                //    }
                //    _nBankID = nMaxBankID;
                //}
                sSql = "INSERT INTO t_BankInterest (BankID, EMINo, InsRate, EffectiveFrom, EffectiveTo, IsActive) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("EMINo", _nEMINo);
                cmd.Parameters.AddWithValue("InsRate", _InsRate);
                cmd.Parameters.AddWithValue("EffectiveFrom", _dtEffectiveFrom);

                if (_dtEffectiveTo != null)
                {
                    cmd.Parameters.AddWithValue("EffectiveTo", _dtEffectiveTo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("EffectiveTo", null);
                }
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
                sSql = "UPDATE t_BankInterest SET EffectiveTo = ?, IsActive = ? WHERE ID =  ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EffectiveTo", _dtEffectiveTo);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "UPDATE t_BankInterest SET EffectiveFrom = ? , InsRate = ? WHERE ID =  ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("EffectiveFrom", _dtEffectiveFrom);
                cmd.Parameters.AddWithValue("InsRate", _InsRate);

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
                sSql = "DELETE FROM t_BankInterest WHERE [BankID]=? and [EMINo]= ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("EMINo", _nEMINo);
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
                cmd.CommandText = "SELECT * FROM t_BankInterest where BankID =?";
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nBankID = (int)reader["BankID"];
                    _nEMINo = (int)reader["EMINo"];
                    _InsRate = Convert.ToDouble(reader["InsRate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_BankInterest where BankID =? and EMINo = ? and IsActive=1";
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("EMINo", _nEMINo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nBankID = (int)reader["BankID"];
                    _nEMINo = (int)reader["EMINo"];
                    _InsRate = Convert.ToDouble(reader["InsRate"].ToString());
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
    public class BankIsts : CollectionBase
    {
        public BankIst this[int i]
        {
            get { return (BankIst)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(BankIst oBankIst)
        {
            InnerList.Add(oBankIst);
        }
        public int GetIndex(int nBankID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].BankID == nBankID)
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
            string sSql = "SELECT * FROM t_BankInterest";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BankIst oBankIst = new BankIst();
                    oBankIst.BankID = (int)reader["BankID"];
                    oBankIst.EMINo = (int)reader["EMINo"];
                    oBankIst.InsRate = Convert.ToDouble(reader["InsRate"].ToString());
                    InnerList.Add(oBankIst);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refreshs(int nBankID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " SELECT a.ID,a.BankID,Name,EMINo,InsRate,EffectiveFrom,EffectiveTo,IsActive  " +
                          " FROM t_BankInterest a,t_Bank b where a.BankID=b.BankID and IsActive=1";

            if (nBankID != -1)
            {

                sSql = sSql + " and a.BankID = " + nBankID + " ";
            }
            sSql = sSql + " order by Name, EMINo ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BankIst oBankIst = new BankIst();
                    oBankIst.ID = (int)reader["ID"];
                    oBankIst.BankID = (int)reader["BankID"];
                    oBankIst.BankName = (string)reader["Name"];
                    oBankIst.EMINo = (int)reader["EMINo"];
                    oBankIst.InsRate = Convert.ToDouble(reader["InsRate"].ToString());
                    oBankIst.EffectiveFrom = (DateTime)reader["EffectiveFrom"];
                    if (reader["EffectiveTo"] != DBNull.Value)
                    {
                        oBankIst.EffectiveTo = (object)reader["EffectiveTo"];
                    }
                    else
                    {
                        oBankIst.EffectiveTo = "";
                    }
                    oBankIst.IsActive = (int)reader["IsActive"];
                    InnerList.Add(oBankIst);
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


// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Nov 30, 2016
// Time : 03:08 PM
// Description: Class for CSDServiceChargeCustomer.
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
    public class CSDServiceChargeCustomer
    {
        private int _nID;
        private int _nServiceChargeID;
        private int _nChargeType;
        private int _nProductID;
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
        // Get set property for ServiceChargeID
        // </summary>
        public int ServiceChargeID
        {
            get { return _nServiceChargeID; }
            set { _nServiceChargeID = value; }
        }

        // <summary>
        // Get set property for ChargeType
        // </summary>
        public int ChargeType
        {
            get { return _nChargeType; }
            set { _nChargeType = value; }
        }

        // <summary>
        // Get set property for ProductID
        // </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        
        // <summary>
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CSDServiceChargeCustomer";
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
                sSql = "INSERT INTO t_CSDServiceChargeCustomer (ID, ServiceChargeID, ChargeType, Amount) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ServiceChargeID", _nServiceChargeID);
                cmd.Parameters.AddWithValue("ChargeType", _nChargeType);
                cmd.Parameters.AddWithValue("Amount", _Amount);

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
                sSql = "UPDATE t_CSDServiceChargeCustomer SET  Amount = ? WHERE ServiceChargeID = ? AND ChargeType = ? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("ServiceChargeID", _nServiceChargeID);
                cmd.Parameters.AddWithValue("ChargeType", _nChargeType);
                
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
                sSql = "DELETE FROM t_CSDServiceChargeCustomer WHERE [ID]=?";
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
        public bool IsServiceChargeSaved(int nServiceChargeID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDServiceChargeCustomer where ServiceChargeID = '" + nServiceChargeID + "' ";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return false;
        }


        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDServiceChargeCustomer where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nServiceChargeID = (int)reader["ServiceChargeID"];
                    _nChargeType = (int)reader["ChargeType"];
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
        public void GetCharge()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select a.ServiceChargeId,Amount from dbo.t_CSDServiceChargeCustomer a, dbo.t_CSDServiceChargeProduct b"
                               + " where ChargeType =" + _nChargeType + " and a.ServiceChargeId= b.ServiceChargeId and ProductID =" + _nProductID + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nServiceChargeID=(int)reader["ServiceChargeId"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class CSDServiceChargeCustomers : CollectionBase
    {
        public CSDServiceChargeCustomer this[int i]
        {
            get { return (CSDServiceChargeCustomer)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDServiceChargeCustomer oCSDServiceChargeCustomer)
        {
            InnerList.Add(oCSDServiceChargeCustomer);
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
        public void Refresh(int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CSDServiceChargeCustomer";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDServiceChargeCustomer oCSDServiceChargeCustomer = new CSDServiceChargeCustomer();
                    oCSDServiceChargeCustomer.ID = (int)reader["ID"];
                    oCSDServiceChargeCustomer.ServiceChargeID = (int)reader["ServiceChargeID"];
                    oCSDServiceChargeCustomer.ChargeType = (int)reader["ChargeType"];
                    oCSDServiceChargeCustomer.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    InnerList.Add(oCSDServiceChargeCustomer);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshBySCID(int nSCID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CSDServiceChargeCustomer WHERE ServiceChargeID = '" + nSCID + "'";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDServiceChargeCustomer oCSDServiceChargeCustomer = new CSDServiceChargeCustomer();
                    oCSDServiceChargeCustomer.ID = (int)reader["ID"];
                    oCSDServiceChargeCustomer.ServiceChargeID = (int)reader["ServiceChargeID"];
                    oCSDServiceChargeCustomer.ChargeType = (int)reader["ChargeType"];
                    oCSDServiceChargeCustomer.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    InnerList.Add(oCSDServiceChargeCustomer);
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


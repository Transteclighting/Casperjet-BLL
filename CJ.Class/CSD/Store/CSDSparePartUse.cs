// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Mar 16, 2017
// Time : 04:32 PM
// Description: Class for CSDSparePartUse.
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
    public class CSDSparePartUse
    {
        private int _nJobID;
        private int _nSparePartID;
        private int _nQty;
        private double _UnitCostPrice;
        private double _UnitSalePrice;
        private int _nIsValidWarranty;


        // <summary>
        // Get set property for JobID
        // </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }

        // <summary>
        // Get set property for SparePartID
        // </summary>
        public int SparePartID
        {
            get { return _nSparePartID; }
            set { _nSparePartID = value; }
        }

        // <summary>
        // Get set property for Qty
        // </summary>
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        // <summary>
        // Get set property for UnitCostPrice
        // </summary>
        public double UnitCostPrice
        {
            get { return _UnitCostPrice; }
            set { _UnitCostPrice = value; }
        }

        // <summary>
        // Get set property for UnitSalePrice
        // </summary>
        public double UnitSalePrice
        {
            get { return _UnitSalePrice; }
            set { _UnitSalePrice = value; }
        }

        // <summary>
        // Get set property for IsValidWarranty
        // </summary>
        public int IsValidWarranty
        {
            get { return _nIsValidWarranty; }
            set { _nIsValidWarranty = value; }
        }

        public void Add()
        {
            int nMaxJobID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([JobID]) FROM t_CSDSparePartUse";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxJobID = 1;
                }
                else
                {
                    nMaxJobID = Convert.ToInt32(maxID) + 1;
                }
                _nJobID = nMaxJobID;
                sSql = "INSERT INTO t_CSDSparePartUse (JobID, SparePartID, Qty, UnitCostPrice, UnitSalePrice, IsValidWarranty) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("UnitCostPrice", _UnitCostPrice);
                cmd.Parameters.AddWithValue("UnitSalePrice", _UnitSalePrice);
                cmd.Parameters.AddWithValue("IsValidWarranty", _nIsValidWarranty);

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
                sSql = "UPDATE t_CSDSparePartUse SET SparePartID = ?, Qty = ?, UnitCostPrice = ?, UnitSalePrice = ?, IsValidWarranty = ? WHERE JobID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("UnitCostPrice", _UnitCostPrice);
                cmd.Parameters.AddWithValue("UnitSalePrice", _UnitSalePrice);
                cmd.Parameters.AddWithValue("IsValidWarranty", _nIsValidWarranty);

                cmd.Parameters.AddWithValue("JobID", _nJobID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateSPWarrantyValid()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CSDSparePartUse SET IsValidWarranty = ? WHERE SparePartID=? AND JobID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsValidWarranty", _nIsValidWarranty);
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);

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
                sSql = "DELETE FROM t_CSDSparePartUse WHERE [JobID]=?";
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
                cmd.CommandText = "SELECT * FROM t_CSDSparePartUse where JobID =?";
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nJobID = (int)reader["JobID"];
                    _nSparePartID = (int)reader["SparePartID"];
                    _nQty = (int)reader["Qty"];
                    _UnitCostPrice = Convert.ToDouble(reader["UnitCostPrice"].ToString());
                    _UnitSalePrice = Convert.ToDouble(reader["UnitSalePrice"].ToString());
                    _nIsValidWarranty = (int)reader["IsValidWarranty"];
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
    public class CSDSparePartUses : CollectionBase
    {
        public CSDSparePartUse this[int i]
        {
            get { return (CSDSparePartUse)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDSparePartUse oCSDSparePartUse)
        {
            InnerList.Add(oCSDSparePartUse);
        }
        public int GetIndex(int nJobID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].JobID == nJobID)
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
            string sSql = "SELECT * FROM t_CSDSparePartUse";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDSparePartUse oCSDSparePartUse = new CSDSparePartUse();
                    oCSDSparePartUse.JobID = (int)reader["JobID"];
                    oCSDSparePartUse.SparePartID = (int)reader["SparePartID"];
                    oCSDSparePartUse.Qty = (int)reader["Qty"];
                    oCSDSparePartUse.UnitCostPrice = Convert.ToDouble(reader["UnitCostPrice"].ToString());
                    oCSDSparePartUse.UnitSalePrice = Convert.ToDouble(reader["UnitSalePrice"].ToString());
                    oCSDSparePartUse.IsValidWarranty = (int)reader["IsValidWarranty"];
                    InnerList.Add(oCSDSparePartUse);
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


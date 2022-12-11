// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Feb 28, 2017
// Time : 05:41 PM
// Description: Class for CSDSparePartStock.
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
    public class CSDSparePartStock
    {
        private int _nSPStockID;
        private int _nSparePartID;
        private string _sSparePartCode;
        private int _nStoreID;
        private int _nCurrentStockQty;


        // <summary>
        // Get set property for SPStockID
        // </summary>
        public int SPStockID
        {
            get { return _nSPStockID; }
            set { _nSPStockID = value; }
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
        // Get set property for SparePartCode
        // </summary>
        public string SparePartCode
        {
            get { return _sSparePartCode; }
            set { _sSparePartCode = value; }
        }

        // <summary>
        // Get set property for StoreID
        // </summary>
        public int StoreID
        {
            get { return _nStoreID; }
            set { _nStoreID = value; }
        }

        // <summary>
        // Get set property for CurrentStockQty
        // </summary>
        public int CurrentStockQty
        {
            get { return _nCurrentStockQty; }
            set { _nCurrentStockQty = value; }
        }

        public void Add()
        {
            int nMaxSPStockID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([SPStockID]) FROM t_CSDSparePartStock";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSPStockID = 1;
                }
                else
                {
                    nMaxSPStockID = Convert.ToInt32(maxID) + 1;
                }
                _nSPStockID = nMaxSPStockID;
                sSql = "INSERT INTO t_CSDSparePartStock (SPStockID, SparePartID, StoreID, CurrentStockQty) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SPStockID", _nSPStockID);
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.Parameters.AddWithValue("StoreID", _nStoreID);
                cmd.Parameters.AddWithValue("CurrentStockQty", _nCurrentStockQty);

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
                sSql = "UPDATE t_CSDSparePartStock SET SparePartID = ?, StoreID = ?, CurrentStockQty = ? WHERE SPStockID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.Parameters.AddWithValue("StoreID", _nStoreID);
                cmd.Parameters.AddWithValue("CurrentStockQty", _nCurrentStockQty);

                cmd.Parameters.AddWithValue("SPStockID", _nSPStockID);

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
                sSql = "DELETE FROM t_CSDSparePartStock WHERE [SPStockID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SPStockID", _nSPStockID);
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
                cmd.CommandText = "SELECT * FROM t_CSDSparePartStock where SPStockID =?";
                cmd.Parameters.AddWithValue("SPStockID", _nSPStockID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nSPStockID = (int)reader["SPStockID"];
                    _nSparePartID = (int)reader["SparePartID"];
                    _nStoreID = (int)reader["StoreID"];
                    _nCurrentStockQty = (int)reader["CurrentStockQty"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckBySpID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDSparePartStock where SparePartID =? AND StoreID =?";
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.Parameters.AddWithValue("StoreID", _nStoreID);
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
        public void UpdateStock(int nStockIn)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                if (nStockIn == (int)Dictionary.YesOrNoStatus.NO)
                {
                    sSql = "UPDATE t_CSDSparePartStock SET CurrentStockQty = CurrentStockQty-? WHERE SparePartID=? AND StoreID=? ";
                }
                else
                {
                    sSql = "UPDATE t_CSDSparePartStock SET CurrentStockQty = CurrentStockQty+? WHERE SparePartID=? AND StoreID=? ";

                }
               
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CurrentStockQty", _nCurrentStockQty);
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.Parameters.AddWithValue("StoreID", _nStoreID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public void CheckStock()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSql = "";

        //    try
        //    {

        //        sSql = "SELECT * FROM t_CSDSparePartStock a INNER JOIN t_CSDSpareParts b ON a.SparePartID = b.SparePartID "
        //              +"WHERE StoreID=? ";
        //        if (_sSparePartCode != string.Empty)
        //        {
        //            sSql += "AND Code = '%" + _sSparePartCode + "%' ";
        //        }
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Parameters.AddWithValue("StoreID", _nStoreID);

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

    }
    public class CSDSparePartStocks : CollectionBase
    {
        public CSDSparePartStock this[int i]
        {
            get { return (CSDSparePartStock)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDSparePartStock oCSDSparePartStock)
        {
            InnerList.Add(oCSDSparePartStock);
        }
        public int GetIndex(int nSPStockID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].SPStockID == nSPStockID)
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
            string sSql = "SELECT * FROM t_CSDSparePartStock";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDSparePartStock oCSDSparePartStock = new CSDSparePartStock();
                    oCSDSparePartStock.SPStockID = (int)reader["SPStockID"];
                    oCSDSparePartStock.SparePartID = (int)reader["SparePartID"];
                    oCSDSparePartStock.StoreID = (int)reader["StoreID"];
                    oCSDSparePartStock.CurrentStockQty = (int)reader["CurrentStockQty"];
                    InnerList.Add(oCSDSparePartStock);
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


// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Jun 25, 2016
// Time : 01:36 PM
// Description: Class for SCMBOMStock.
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
    public class SCMBOMStock
    {
        private int _nProductID;
        private int _nBOMID;
        private int _nLocationID;
        private int _nCurrentStock;
        private bool _bFlag;
        private int _nGRDQty;


        // <summary>
        // Get set property for GRDQty
        // </summary>
        public int GRDQty
        {
            get { return _nGRDQty; }
            set { _nGRDQty = value; }
        }


        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
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
        // Get set property for BOMID
        // </summary>
        public int BOMID
        {
            get { return _nBOMID; }
            set { _nBOMID = value; }
        }

        // <summary>
        // Get set property for LocationID
        // </summary>
        public int LocationID
        {
            get { return _nLocationID; }
            set { _nLocationID = value; }
        }

        // <summary>
        // Get set property for CurrentStock
        // </summary>
        public int CurrentStock
        {
            get { return _nCurrentStock; }
            set { _nCurrentStock = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_SCMBOMStock (ProductID, BOMID, LocationID, CurrentStock) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BOMID", _nBOMID);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("CurrentStock", 0);

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
                sSql = "UPDATE t_SCMBOMStock SET BOMID = ?, LocationID = ?, CurrentStock = ? WHERE ProductID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BOMID", _nBOMID);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("CurrentStock", _nCurrentStock);

                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateCurrentStock_GRD(bool IsAdd)
        {
            string sSql = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            if (IsAdd)
                sSql = "UPDATE t_SCMBOMStock SET CurrentStock = CurrentStock + ? where ProductID = ? and BOMID = ? and LocationID = ? ";
            else sSql = "UPDATE t_SCMBOMStock SET CurrentStock = CurrentStock - ? where ProductID = ? and BOMID = ? and LocationID = ? ";

            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("CurrentStock", _nGRDQty);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BOMID", _nBOMID);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                
                
                cmd.CommandType = CommandType.Text;

                if (cmd.ExecuteNonQuery() != 0)
                    _bFlag = true;
                else _bFlag = false;

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
                sSql = "DELETE FROM t_SCMBOMStock WHERE [ProductID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
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
                cmd.CommandText = "SELECT * FROM t_SCMBOMStock where ProductID =?";
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nProductID = (int)reader["ProductID"];
                    _nBOMID = (int)reader["BOMID"];
                    _nLocationID = (int)reader["LocationID"];
                    _nCurrentStock = (int)reader["CurrentStock"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckBOMStock()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sSql = "SELECT * FROM t_SCMBOMStock where LocationID = ? AND ProductID = ? AND BOMID=?";
            cmd.Parameters.AddWithValue("LocationID", _nLocationID);
            cmd.Parameters.AddWithValue("ProductID", _nProductID);
            cmd.Parameters.AddWithValue("BOMID", _nBOMID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nCurrentStock = int.Parse(reader["CurrentStock"].ToString());
                    nCount++;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0) return true;
            else return false;


        }

    }
    public class SCMBOMStocks : CollectionBase
    {
        public SCMBOMStock this[int i]
        {
            get { return (SCMBOMStock)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SCMBOMStock oSCMBOMStock)
        {
            InnerList.Add(oSCMBOMStock);
        }
        public int GetIndex(int nProductID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ProductID == nProductID)
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
            string sSql = "SELECT * FROM t_SCMBOMStock";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMBOMStock oSCMBOMStock = new SCMBOMStock();
                    oSCMBOMStock.ProductID = (int)reader["ProductID"];
                    oSCMBOMStock.BOMID = (int)reader["BOMID"];
                    oSCMBOMStock.LocationID = (int)reader["LocationID"];
                    oSCMBOMStock.CurrentStock = (int)reader["CurrentStock"];
                    InnerList.Add(oSCMBOMStock);
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


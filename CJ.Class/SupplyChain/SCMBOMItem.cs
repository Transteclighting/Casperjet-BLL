// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Jun 20, 2016
// Time : 01:07 PM
// Description: Class for SCMPIBOMItem.
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
    public class SCMPIBOMItem
    {
        private int _nPIID;
        private int _nProductID;
        private int _nBOMID;
        private int _nPIQty;
        private int _nLCQty;


        // <summary>
        // Get set property for PIID
        // </summary>
        public int PIID
        {
            get { return _nPIID; }
            set { _nPIID = value; }
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
        // Get set property for PIQty
        // </summary>
        public int PIQty
        {
            get { return _nPIQty; }
            set { _nPIQty = value; }
        }

        // <summary>
        // Get set property for LCQty
        // </summary>
        public int LCQty
        {
            get { return _nLCQty; }
            set { _nLCQty = value; }
        }

        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "INSERT INTO t_SCMPIBOMItem (PIID, ProductID, BOMID, PIQty, LCQty) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("PIID", _nPIID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BOMID", _nBOMID);
                cmd.Parameters.AddWithValue("PIQty", _nPIQty);
                if (_nLCQty != null)
                {
                    cmd.Parameters.AddWithValue("LCQty", _nLCQty);
                }
                else
                {
                    cmd.Parameters.AddWithValue("LCQty", null);
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Add()
        {
            int nMaxPIID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([PIID]) FROM t_SCMPIBOMItem";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxPIID = 1;
                }
                else
                {
                    nMaxPIID = Convert.ToInt32(maxID) + 1;
                }
                _nPIID = nMaxPIID;
                sSql = "INSERT INTO t_SCMPIBOMItem (PIID, ProductID, BOMID, PIQty, LCQty) VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("PIID", _nPIID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BOMID", _nBOMID);
                cmd.Parameters.AddWithValue("PIQty", _nPIQty);
                cmd.Parameters.AddWithValue("LCQty", _nLCQty);

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
                sSql = "UPDATE t_SCMPIBOMItem SET ProductID = ?, BOMID = ?, PIQty = ?, LCQty = ? WHERE PIID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ProductID", _nProductID);
                cmd.Parameters.AddWithValue("BOMID", _nBOMID);
                cmd.Parameters.AddWithValue("PIQty", _nPIQty);
                cmd.Parameters.AddWithValue("LCQty", _nLCQty);

                cmd.Parameters.AddWithValue("PIID", _nPIID);

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
                sSql = "DELETE FROM t_SCMPIBOMItem WHERE [PIID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("PIID", _nPIID);
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
                cmd.CommandText = "SELECT * FROM t_SCMPIBOMItem where PIID =?";
                cmd.Parameters.AddWithValue("PIID", _nPIID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nPIID = (int)reader["PIID"];
                    _nProductID = (int)reader["ProductID"];
                    _nBOMID = (int)reader["BOMID"];
                    _nPIQty = (int)reader["PIQty"];
                    _nLCQty = (int)reader["LCQty"];
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
    public class SCMPIBOMItems : CollectionBase
    {
        public SCMPIBOMItem this[int i]
        {
            get { return (SCMPIBOMItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SCMPIBOMItem oSCMPIBOMItem)
        {
            InnerList.Add(oSCMPIBOMItem);
        }
        public int GetIndex(int nPIID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].PIID == nPIID)
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
            string sSql = "SELECT * FROM t_SCMPIBOMItem";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMPIBOMItem oSCMPIBOMItem = new SCMPIBOMItem();
                    oSCMPIBOMItem.PIID = (int)reader["PIID"];
                    oSCMPIBOMItem.ProductID = (int)reader["ProductID"];
                    oSCMPIBOMItem.BOMID = (int)reader["BOMID"];
                    oSCMPIBOMItem.PIQty = (int)reader["PIQty"];
                    oSCMPIBOMItem.LCQty = (int)reader["LCQty"];
                    InnerList.Add(oSCMPIBOMItem);
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




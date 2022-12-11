// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Oct 01, 2015
// Time : 01:08 PM
// Description: Class for SCMBOM.
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
    public class SCMBOM
    {
        private int _nBOMID;
        private string _sBOMDescription;
        private int _nMAGID;
        private int _nProductID;
        private int _nBOMQty;

        // <summary>
        // Get set property for BOMQty
        // </summary>
        public int BOMQty
        {
            get { return _nBOMQty; }
            set { _nBOMQty = value; }
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
        // Get set property for BOMDescription
        // </summary>
        public string BOMDescription
        {
            get { return _sBOMDescription; }
            set { _sBOMDescription = value.Trim(); }
        }

        // <summary>
        // Get set property for MAGID
        // </summary>
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }

        public void Add()
        {
            int nMaxBOMID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([BOMID]) FROM t_ProductBOM";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxBOMID = 1;
                }
                else
                {
                    nMaxBOMID = Convert.ToInt32(maxID) + 1;
                }
                _nBOMID = nMaxBOMID;
                sSql = "INSERT INTO t_ProductBOM (BOMID, BOMDescription, MAGID) VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BOMID", _nBOMID);
                cmd.Parameters.AddWithValue("BOMDescription", _sBOMDescription);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);

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
                sSql = "UPDATE t_ProductBOM SET BOMDescription = ?, MAGID = ? WHERE BOMID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BOMDescription", _sBOMDescription);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);

                cmd.Parameters.AddWithValue("BOMID", _nBOMID);

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
                sSql = "DELETE FROM t_ProductBOM WHERE [BOMID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BOMID", _nBOMID);
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
                cmd.CommandText = "SELECT * FROM t_ProductBOM where BOMID =?";
                cmd.Parameters.AddWithValue("BOMID", _nBOMID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nBOMID = (int)reader["BOMID"];
                    _sBOMDescription = (string)reader["BOMDescription"];
                    _nMAGID = (int)reader["MAGID"];
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
    public class SCMBOMs : CollectionBase
    {
        public SCMBOM this[int i]
        {
            get { return (SCMBOM)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SCMBOM oSCMBOM)
        {
            InnerList.Add(oSCMBOM);
        }
        public int GetIndex(int nBOMID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].BOMID == nBOMID)
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
            string sSql = "SELECT * FROM t_ProductBOM";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMBOM oSCMBOM = new SCMBOM();
                    oSCMBOM.BOMID = (int)reader["BOMID"];
                    oSCMBOM.BOMDescription = (string)reader["BOMDescription"];
                    oSCMBOM.MAGID = (int)reader["MAGID"];
                    InnerList.Add(oSCMBOM);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetBOMList(int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " Select BOMID,BOMDescription From dbo.t_PRoductBOM a,v_PRoductDetails b " +
                           " where a.MAGID=b.MAGID and ProductID = " + nProductID + " ";

            //cmd.Parameters.AddWithValue("ProductID", nProductID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SCMBOM oSCMBOM = new SCMBOM();
                    oSCMBOM.BOMID = (int)reader["BOMID"];
                    oSCMBOM.BOMDescription = (string)reader["BOMDescription"];
                    InnerList.Add(oSCMBOM);
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


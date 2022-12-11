using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;


namespace CJ.Class.POS
{
    public class MapBranchTran
    {
        private string _sTableName;
        private int _nHODataID;
        private int _nBranchDataID;
        private int _nWHID;

        public string TableName
        {
            get { return _sTableName;}
            set { _sTableName = value.Trim();}
        }
        public int HODataID
        {
            get { return _nHODataID; }
            set { _nHODataID = value; }
        }
        public int BranchDataID
        {
            get { return _nBranchDataID; }
            set { _nBranchDataID = value; }
        }
        public int WHID
        {
            get { return _nWHID; }
            set { _nWHID = value; }
        }

        public void Add()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_MapBranchTran VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TableName",_sTableName);
                cmd.Parameters.AddWithValue("HODataID", _nHODataID);
                cmd.Parameters.AddWithValue("BranchDataID", _nBranchDataID);
                cmd.Parameters.AddWithValue("WHID", _nWHID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetHODataID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "SELECT * FROM t_MapBranchTran where TableName =? and BranchDataID=? and WHID=?";
                cmd.Parameters.AddWithValue("TableName",_sTableName);
                cmd.Parameters.AddWithValue("BranchDataID", _nBranchDataID);
                cmd.Parameters.AddWithValue("WHID", _nWHID);

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    _nHODataID = (int)reader["HODataID"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
    }
    public class MapHOTran
    {
        private string _sTableName;
        private int _nHODataID;
        private int _nBranchDataID;

        public string TableName
        {
            get { return _sTableName; }
            set { _sTableName = value.Trim(); }
        }
        public int HODataID
        {
            get { return _nHODataID; }
            set { _nHODataID = value; }
        }
        public int BranchDataID
        {
            get { return _nBranchDataID; }
            set { _nBranchDataID = value; }
        }

        public void Add()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {

                sSql = "INSERT INTO t_MapHOTran VALUES(?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TableName", _sTableName);
                cmd.Parameters.AddWithValue("HODataID", _nHODataID);
                cmd.Parameters.AddWithValue("BranchDataID", _nBranchDataID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}

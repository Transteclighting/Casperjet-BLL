// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Aug 04, 2012
// Time :  11:07 AM
// Description: Class for Issue Parts Stock From Cassandra.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Class
{
    public class IssuePartsCassandra
    { 
        private int _nID;
        private int _nSparePartID;
        private int _nJobID;
        private int _nIssueQty;
        private int _nReturnQty;
        private int _nIsWarrantyValid;
        
        private bool _bFlag;

        /// <summary>
        /// Get set property for ID
        /// </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
        /// <summary>
        /// Get set property for SparePartID
        /// </summary>
        public int SparePartID
        {
            get { return _nSparePartID; }
            set { _nSparePartID = value; }
        }
        /// <summary>
        /// Get set property for JobID
        /// </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }
        /// <summary>
        /// Get set property for IssueQty
        /// </summary>
        public int IssueQty
        {
            get { return _nIssueQty; }
            set { _nIssueQty = value; }
        }
        /// <summary>
        /// Get set property for ReturnQty
        /// </summary>
        public int ReturnQty
        {
            get { return _nReturnQty; }
            set { _nReturnQty = value; }
        }
        /// <summary>
        /// Get set property for IsWarrantyValid
        /// </summary>
        public int IsWarrantyValid
        {
            get { return _nIsWarrantyValid; }
            set { _nIsWarrantyValid = value; }
        }

        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }

        public void AddIssueParts()
        {
            int nMaxID = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([ID]) FROM TELServiceDB.dbo.IssueParts";
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


                sSql = "INSERT INTO TELServiceDB.dbo.IssueParts(ID,SparePartID,JobID,IssueQty,ReturnQty,IsWarrantyValid) VALUES(?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("IssueQty", _nIssueQty);
                cmd.Parameters.AddWithValue("ReturnQty", 0);
                cmd.Parameters.AddWithValue("IsWarrantyValid", 0);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateIssueParts()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE TELServiceDB.dbo.IssueParts SET IssueQty=IssueQty+? WHERE SparePartID=? AND JobID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IssueQty", _nIssueQty);

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
        public bool CheckIssuePartsAgainstJob()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from TELServiceDB.dbo.IssueParts where SparePartID=? AND JobID=? ";
            cmd.Parameters.AddWithValue("SparePartID", _nSparePartID);
            cmd.Parameters.AddWithValue("JobID", _nJobID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nSparePartID = (int)reader["SparePartID"];
                    _nJobID = (int)reader["JobID"];
                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount == 0)
                return true;
            else return false;
        }
    }
    public class IssuePartsCassandras : CollectionBase
    {
        public IssuePartsCassandra this[int i]
        {
            get { return (IssuePartsCassandra)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(IssuePartsCassandra oIssuePartsCassandra)
        {
            InnerList.Add(oIssuePartsCassandra);
        }
        
    }

}





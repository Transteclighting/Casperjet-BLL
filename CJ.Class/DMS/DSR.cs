// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Mazharul Haque
// Date: July 26, 2011
// Time :  16:00 PM
// Description: Class for DMS DSR Information.
// Modify Person And Date: Shyam Sundar Biswas
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.DMS
{
    public class DSR
    {
        private int _nDSRID;
        private int _nDistributorID;
        private int _nDSRCode;
        private string _sDSRName;
        private string _sDSRMobile;

     
        public int DSRID
        {
            get { return _nDSRID; }
            set { _nDSRID = value; }
        }
        public int DSRCode
        {
            get { return _nDSRCode; }
            set { _nDSRCode = value; }
        }
        public int DistributorID
        {
            get { return _nDistributorID; }
            set { _nDistributorID = value; }
        }
      
        public string DSRName
        {
            get { return _sDSRName; }
            set { _sDSRName = value; }
        }

      
        public string DSRMobile
        {
            get { return _sDSRMobile; }
            set { _sDSRMobile = value.Trim(); }
        }

        public void Add()
        {
            int nMaxDSRID = 0;
            int nMaxDSRCode = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([DSRID]) FROM t_DMSDSR";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxDSRID = 1;
                }
                else
                {
                    nMaxDSRID = Convert.ToInt32(maxID) + 1;
                }
                _nDSRID = nMaxDSRID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "SELECT MAX([DSRCode]) FROM t_DMSDSR";
                cmd.CommandText = sSql;
                object maxCode = cmd.ExecuteScalar();
                if (maxCode == DBNull.Value)
                {
                    nMaxDSRCode = 100001;
                }
                else
                {
                    nMaxDSRCode = Convert.ToInt32(maxCode) + 1;
                }
                _nDSRCode = nMaxDSRCode;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_DMSDSR VALUES(?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DSRID", _nDSRID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
                cmd.Parameters.AddWithValue("DSRCode", _nDSRCode);
                cmd.Parameters.AddWithValue("DSRName", _sDSRName);
                cmd.Parameters.AddWithValue("DSRMobile", _sDSRMobile);
               

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

                sSql = "UPDATE t_DMSDSR SET DSRName=?, DSRMobile=?  WHERE DSRID=? and DistributorID=? ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.AddWithValue("DSRName", _sDSRName);
                cmd.Parameters.AddWithValue("DSRMobile", _sDSRMobile);

                cmd.Parameters.AddWithValue("DSRID", _nDSRID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);

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
                sSql = "DELETE FROM t_DMSDSR WHERE DSRID=? and DistributorID=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("DSRID", _nDSRID);
                cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);


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

            string sSql = "SELECT * FROM t_DMSDSR where DSRID=? and  DistributorID=?";

            cmd.Parameters.AddWithValue("DSRID", _nDSRID);
            cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _nDSRID = (int)reader["DSRID"];
                    _nDSRCode = (int)reader["DSRCode"];
                    _sDSRName = (string)reader["DSRName"];
                    _sDSRMobile = (string)reader["DSRMobile"];                   
                }
                reader.Close();               

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

       

        public void RefreshBy()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSDSR where DSRID=? ";

            cmd.Parameters.AddWithValue("DSRID", _nDSRID);
         
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _nDSRID = (int)reader["DSRID"];
                    _nDSRCode = (int)reader["DSRCode"];
                    _sDSRName = (string)reader["DSRName"];
                    _sDSRMobile = (string)reader["DSRMobile"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
     
    }
    public class DSRs : CollectionBase
    {

        public DSR this[int i]
        {
            get { return (DSR)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public int GetIndexByID(int nDSRID)
        {
            int i = 0;
            foreach (DSR oDSR in this)
            {
                if (oDSR.DSRID == nDSRID)
                    return i;
                i++;
            }
            return -1;
        }


        public void Add(Route oDSR)
        {
            InnerList.Add(oDSR);
        }

        public void Refresh(int nDistributorID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSDSR where DistributorID=? ORDER BY DSRCode DESC";
            cmd.Parameters.AddWithValue("DistributorID", nDistributorID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSR oDSR = new DSR();

                    oDSR.DSRID = (int)reader["DSRID"];
                    oDSR.DistributorID = (int)reader["DistributorID"];
                    oDSR.DSRCode = (int)reader["DSRCode"];
                    oDSR.DSRName = (string)reader["DSRName"];
                    oDSR.DSRMobile = (string)reader["DSRMobile"];


                    InnerList.Add(oDSR);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetDSR(int nDistributorID)
        {
            InnerList.Clear();
            DSR oDSR;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSDSR where DistributorID=?";
            cmd.Parameters.AddWithValue("DistributorID", nDistributorID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oDSR = new DSR();

                    oDSR.DSRID = (int)reader["DSRID"];                  
                    oDSR.DSRName = (string)reader["DSRName"];                   

                    InnerList.Add(oDSR);
                }
                reader.Close();

                oDSR = new DSR();
                oDSR.DSRID = -1;
                oDSR.DSRName = "Select DSR";
                InnerList.Add(oDSR);


                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetDSRForPlan(int nDistributorID)
        {
            InnerList.Clear();
            DSR oDSR;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select * from t_dmsdsr where DistributorID='" + nDistributorID + "'";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oDSR = new DSR();

                    oDSR.DSRID = (int)reader["DSRID"];
                    oDSR.DSRName = (string)reader["DSRName"];

                    InnerList.Add(oDSR);
                }
                reader.Close();

                oDSR = new DSR();
                oDSR.DSRID = -1;
                oDSR.DSRName = "Select DSR";
                InnerList.Add(oDSR);


                InnerList.TrimToSize();
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


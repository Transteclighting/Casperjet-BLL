// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: July 24, 2011
// Time :  11:00 AM
// Description: Class for DMS Transaction type.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;


namespace CJ.Class.DMS
{
    public class TranType
    {
        private int _nTranTypeID;
        private string _sTranTypeName;
        private int _nTranSide;
        private int _nIsSystem;


        /// <summary>
        /// Get set property for TranTypeID
        /// </summary>
        public int TranTypeID
        {
            get { return _nTranTypeID; }
            set { _nTranTypeID = value; }
        }

        /// <summary>
        /// Get set property for TranTypeName
        /// </summary>
        public string TranTypeName
        {
            get { return _sTranTypeName; }
            set { _sTranTypeName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for TranSide
        /// </summary>
        public int TranSide
        {
            get { return _nTranSide; }
            set { _nTranSide = value; }
        }

        /// <summary>
        /// Get set property for IsSystem
        /// </summary>
        public int IsSystem
        {
            get { return _nIsSystem; }
            set { _nIsSystem = value; }
        }
        public void Refresh()
        {          
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSProductTranType where TranTypeID =?";
            cmd.Parameters.AddWithValue("TranTypeID", _nTranTypeID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {              

                 _nTranTypeID = (int)reader["TranTypeID"];
                 _sTranTypeName = (string)reader["TranTypeName"];
                 _nTranSide = (int)reader["TranSide"];     
                
                }
                reader.Close();              

            }
            catch (Exception ex)
            {
                throw (ex);
            }
         
        }

    }
    public class TranTypes : CollectionBase
    {

        public TranType this[int i]
        {
            get { return (TranType)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public int GetIndexByID(int nTranTypeID)
        {
            int i = 0;
            foreach (TranType oTranType in this)
            {
                if (oTranType.TranTypeID == nTranTypeID)
                    return i;
                i++;
            }
            return -1;
        }

        public void Add(TranType oTranType)
        {
            InnerList.Add(oTranType);
        }

        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSProductTranType where TranSide != 0";          
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    TranType oTranType = new TranType();

                    oTranType.TranTypeID = (int)reader["TranTypeID"];
                    oTranType.TranTypeName = (string)reader["TranTypeName"];
                    oTranType.TranSide = (int)reader["TranSide"];

                    InnerList.Add(oTranType);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForSales()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSProductTranType where TranSide != 0 and TranTypeID in(2,5)";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    TranType oTranType = new TranType();

                    oTranType.TranTypeID = (int)reader["TranTypeID"];
                    oTranType.TranTypeName = (string)reader["TranTypeName"];
                    oTranType.TranSide = (int)reader["TranSide"];

                    InnerList.Add(oTranType);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForAdjust()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSProductTranType where TranSide != 0 and TranTypeID in(3,4,8)";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    TranType oTranType = new TranType();

                    oTranType.TranTypeID = (int)reader["TranTypeID"];
                    oTranType.TranTypeName = (string)reader["TranTypeName"];
                    oTranType.TranSide = (int)reader["TranSide"];

                    InnerList.Add(oTranType);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForAdjustRep()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_DMSProductTranType where TranSide != 0 and TranTypeID in(8)";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    TranType oTranType = new TranType();

                    oTranType.TranTypeID = (int)reader["TranTypeID"];
                    oTranType.TranTypeName = (string)reader["TranTypeName"];
                    oTranType.TranSide = (int)reader["TranSide"];

                    InnerList.Add(oTranType);
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

// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Mar 11, 2012
// Time :  4:55 PM
// Description: Class for ComplainType Data.
// Modify Person And Date:A
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.CSD
{
    public class ComplainType
    {
        private int _nComplainID;
        private int _nComplainTypeID;


        /// <summary>
        /// Get set property for ComplainID
        /// </summary>
        public int ComplainID
        {
            get { return _nComplainID; }
            set { _nComplainID = value; }
        }
        /// <summary>
        /// Get set property for ComplainTypeID
        /// </summary>
        public int ComplainTypeID
        {
            get { return _nComplainTypeID; }
            set { _nComplainTypeID = value; }
        }


        public void AddComplainType()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_CSDComplainType(ComplainID,ComplainTypeID) VALUES(?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ComplainID", _nComplainID);
                cmd.Parameters.AddWithValue("_nComplainTypeID", _nComplainTypeID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void UpdateComplainType()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDComplainType SET ComplainTypeID=? WHERE ComplainID=?";
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("ComplainTypeID", _nComplainTypeID);


                cmd.Parameters.AddWithValue("ComplainID", _nComplainID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void DeleteComplainType()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_CSDComplainType WHERE [ComplainID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ComplainID", _nComplainID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
    public class ComplainTypes : CollectionBase
    {
        public ComplainType this[int i]
        {
            get { return (ComplainType)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ComplainType oComplain)
        {
            InnerList.Add(oComplain);
        }

        public void Refresh(int _nComplainID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDComplainType Where ComplainID=?";

            cmd.Parameters.AddWithValue("ComplainID", _nComplainID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ComplainType oComplainType = new ComplainType();
                    oComplainType.ComplainTypeID = (int)reader["ComplainTypeID"];

                    InnerList.Add(oComplainType);
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
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Mar 08, 2012
// Time :  4:55 PM
// Description: Class for ComplainCategory Data.
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
    public class ComplainCategory
    {
        private int _nComplainID;
        private int _nComplainSubCatID;


        /// <summary>
        /// Get set property for ComplainID
        /// </summary>
        public int ComplainID
        {
            get { return _nComplainID; }
            set { _nComplainID = value; }
        }
        /// <summary>
        /// Get set property for ComplainSubCatID
        /// </summary>
        public int ComplainSubCatID
        {
            get { return _nComplainSubCatID; }
            set { _nComplainSubCatID = value; }
        }



        public void AddtComplainCategory()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_CSDComplainCategory(ComplainID,ComplainSubCatID) VALUES(?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ComplainID", _nComplainID);
                cmd.Parameters.AddWithValue("ComplainSubCatID", _nComplainSubCatID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void UpdateComplainCategory()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDComplainCategory SET ComplainSubCatID=? WHERE ComplainID=?";
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("ComplainSubCatID", _nComplainSubCatID);


                cmd.Parameters.AddWithValue("ComplainID", _nComplainID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
       

        public void DeleteComplainCategory()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_CSDComplainCategory WHERE [ComplainID]=?";

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
    public class ComplainCategories : CollectionBase
    {
        public ComplainCategory this[int i]
        {
            get { return (ComplainCategory)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ComplainCategory oComplain)
        {
            InnerList.Add(oComplain);
        }

        public void Refresh(int _nComplainID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDComplainCategory Where ComplainID=?";

            cmd.Parameters.AddWithValue("ComplainID", _nComplainID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ComplainCategory oComplainCategory = new  ComplainCategory();
                    oComplainCategory.ComplainSubCatID = (int)reader["ComplainSubCatID"];

                    InnerList.Add(oComplainCategory);
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
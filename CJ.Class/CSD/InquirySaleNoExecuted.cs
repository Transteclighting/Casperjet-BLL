

// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Mar 22, 2012
// Time :  4:55 PM
// Description: Class for Inquiry Sale No Executed Data.
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
    public class InquirySaleNoExecuted
    {
        private int _nInquiryID;
        private int _nTypeID;
        private int _nTypeDetailID;


        /// <summary>
        /// Get set property for InquiryID
        /// </summary>
        public int InquiryID
        {
            get { return _nInquiryID; }
            set { _nInquiryID = value; }
        }
        /// <summary>
        /// Get set property for TypeID
        /// </summary>
        public int TypeID
        {
            get { return _nTypeID; }
            set { _nTypeID = value; }
        }
        /// <summary>
        /// Get set property for TypeDetailID
        /// </summary>
        public int TypeDetailID
        {
            get { return _nTypeDetailID; }
            set { _nTypeDetailID = value; }
        }



        public void AddInquirySaleNoExecuted()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_CSDInquiryType(InquiryID,TypeID,TypeDetailID) VALUES(?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InquiryID", _nInquiryID);
                cmd.Parameters.AddWithValue("TypeID", _nTypeID);
                cmd.Parameters.AddWithValue("TypeDetailID", _nTypeDetailID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void UpdateInquirySaleNoExecuted()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDInquiryType SET TypeID=?,TypeDetailID=?  WHERE InquiryID=?";
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("TypeID", _nTypeID);
                cmd.Parameters.AddWithValue("TypeDetailID", _nTypeDetailID);

                cmd.Parameters.AddWithValue("InquiryID", _nInquiryID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void DeleteInquirySaleNoExecuted()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "DELETE FROM t_CSDInquiryType WHERE [InquiryID]=? AND [TypeID]=?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("InquiryID", _nInquiryID);
                cmd.Parameters.AddWithValue("TypeID", _nTypeID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
    public class InquirySaleNoExecuteds : CollectionBase
    {
        public InquirySaleNoExecuted this[int i]
        {
            get { return (InquirySaleNoExecuted)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(InquirySaleNoExecuted oInquiry)
        {
            InnerList.Add(oInquiry);
        }

        public void Refresh(int _nInquiryID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDInquiryType Where InquiryID=?";

            cmd.Parameters.AddWithValue("InquiryID", _nInquiryID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InquirySaleNoExecuted oInquirySaleNoExecuted = new InquirySaleNoExecuted();
                    oInquirySaleNoExecuted.TypeID = (int)reader["TypeID"];
                    oInquirySaleNoExecuted.TypeDetailID = (int)reader["TypeDetailID"];

                    InnerList.Add(oInquirySaleNoExecuted);
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
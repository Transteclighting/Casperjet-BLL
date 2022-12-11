
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Apr 17, 2012
// Time :  04:36 PM
// Description: Class for Replace Job From Cassandra.
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

namespace CJ.Class
{
    public class SpareLoan
    {
        private int _nSpareLoanID;
        private int _nRaiseAgainstJobID;
        private int _nStatus;
        private int _nCreateUserID;
        private Object _dCreateDate;
        private string _sRecmdWH;
        private string _sRemarks;

        private User _oUser;
        //private string _sJobNo;
        private ReplaceJobFromCassandra _oReplaceJobFromCassandra;


        /// <summary>
        /// Get set property for SpareLoanID
        /// </summary>
        public int SpareLoanID
        {
            get { return _nSpareLoanID; }
            set { _nSpareLoanID = value; }
        }

        /// <summary>
        /// Get set property for RaiseAgainstJobID
        /// </summary>
        public int RaiseAgainstJobID
        {
            get { return _nRaiseAgainstJobID; }
            set { _nRaiseAgainstJobID = value; }
        }

        /// <summary>
        /// Get set property for Status
        /// </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        /// <summary>
        /// Get set property for CreateUserID
        /// </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        /// <summary>
        /// Get set property for CreateDate
        /// </summary>
        public Object CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        /// <summary>
        /// Get set property for Contact RecmdWH
        /// </summary>
        public string RecmdWH
        {
            get { return _sRecmdWH; }
            set { _sRecmdWH = value; }
        }

        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }

        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                }
                return _oUser;
            }
        }

        ///// <summary>
        ///// Get set property for JobNo
        ///// </summary>
        //public string JobNo
        //{
        //    get { return _sJobNo; }
        //    set { _sJobNo = value; }
        //}

        public ReplaceJobFromCassandra ReplaceJobFromCassandra
        {
            get
            {
                if (_oReplaceJobFromCassandra == null)
                {
                    _oReplaceJobFromCassandra = new ReplaceJobFromCassandra();
                }
                return _oReplaceJobFromCassandra;
            }
        }

        public void Add()
        {
            int nMaxSpareLoanID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([SpareLoanID]) FROM t_CSDSpareLoan";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSpareLoanID = 1;
                }
                else
                {
                    nMaxSpareLoanID = Convert.ToInt32(maxID) + 1;
                }
                _nSpareLoanID = nMaxSpareLoanID;


                sSql = "INSERT INTO t_CSDSpareLoan(SpareLoanID,RaiseAgainstJobID,Status,CreateUserID,"
                    + " CreateDate,RecmdWH,Remarks) VALUES(?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SpareLoanID", _nSpareLoanID);
                cmd.Parameters.AddWithValue("RaiseAgainstJobID", _nRaiseAgainstJobID);
                cmd.Parameters.AddWithValue("Status", (short)Dictionary.SpareLoanStatus.Raise);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("RecmdWH", _sRecmdWH);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

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

            try
            {

                cmd.CommandText = "UPDATE t_CSDSpareLoan SET RaiseAgainstJobID=?,RecmdWH=?,Remarks=? WHERE SpareLoanID=?";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("RaiseAgainstJobID", _nRaiseAgainstJobID);
                cmd.Parameters.AddWithValue("RecmdWH", _sRecmdWH);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);


                cmd.Parameters.AddWithValue("SpareLoanID", _nSpareLoanID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateStatus()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                cmd.CommandText = "UPDATE t_CSDSpareLoan SET Status=? WHERE SpareLoanID=?";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("SpareLoanID", _nSpareLoanID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class SpareLoans : CollectionBase
    {
        public SpareLoan this[int i]
        {
            get { return (SpareLoan)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SpareLoan oSpareLoan)
        {
            InnerList.Add(oSpareLoan);
        }


        public void Refresh()//String txtJobNo, String txtCustomerName, String txtContactNo
        {
            //dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "Select * from TELServiceDB.dbo.Job where JobStatus=15 AND IsDelivered=0";

            string sSql = "SELECT SpareLoanID, JobNo,CustomerName,CreateDate,Status,SL.Remarks FROM t_CSDSpareloan SL INNER JOIN TELServiceDB.dbo.Job ON RaiseAgainstJobID=JobID ";

            //Status, CreateDate, Remarks
            //string sSql = "SELECT SL.SpareLoanID, J.JobNo,SL.Status, SL.CreateDate, SL.Remarks"
            // + "FROM t_CSDSpareloan SL INNER JOIN TELServiceDB.dbo.Job J ON SL.RaiseAgainstJobID=J.JobID ";

            //    if (txtJobNo != "")
            //    {
            //        txtJobNo = "%" + txtJobNo + "%";
            //        sSql = sSql + " AND J.JobNo LIKE '" + txtJobNo + "'";
            //    }
            //    if (txtCustomerName != "")
            //    {
            //        txtCustomerName = "%" + txtCustomerName + "%";
            //        sSql = sSql + " AND J.CustomerName LIKE '" + txtCustomerName + "'";
            //    }
            //    if (txtContactNo != "")
            //    {
            //        txtContactNo = "%" + txtContactNo + "%";
            //        sSql = sSql + " AND J.Mobile LIKE '" + txtContactNo + "'";
            //    }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SpareLoan oSpareLoan = new SpareLoan();
                    oSpareLoan.SpareLoanID = (int)reader["SpareLoanID"];
                    oSpareLoan.ReplaceJobFromCassandra.JobNo = (string)reader["JobNo"];
                    oSpareLoan.ReplaceJobFromCassandra.CustomerName = (string)reader["CustomerName"];
                    oSpareLoan.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSpareLoan.Status = (int)reader["Status"];
                    oSpareLoan.Remarks = (string)reader["Remarks"];

                    InnerList.Add(oSpareLoan);
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


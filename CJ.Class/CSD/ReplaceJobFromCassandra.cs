
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Mar 28, 2012
// Time :  04:02 PM
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
    public class ReplaceJobFromCassandra
    {
        private int _nJobID;
        private Object _sSerialNo;
        private string _sJobNo;
        private string _sCustomerName;
        private string _sFirstAddress;
        private string _sMobile;
        private Object _dJobCreationDate;
        private Object _dDeliveryDate;
        private int _nIsDelivered;
        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
        private bool _bFlag;

        /// <summary>
        /// Get set property for JobID
        /// </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }

        /// <summary>
        /// Get set property for SerialNo
        /// </summary>
        public Object SerialNo
        {
            get { return _sSerialNo; }
            set { _sSerialNo = value; }
        }

        /// <summary>
        /// Get set property for JobNo
        /// </summary>
        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value; }
        }

        /// <summary>
        /// Get set property for CustomerName
        /// </summary>
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }

        /// <summary>
        /// Get set property for Contact FirstAddress
        /// </summary>
        public string FirstAddress
        {
            get { return _sFirstAddress; }
            set { _sFirstAddress = value; }
        }

        /// <summary>
        /// Get set property for Mobile
        /// </summary>
        public string Mobile
        {
            get { return _sMobile; }
            set { _sMobile = value; }
        }

        /// <summary>
        /// Get set property for JobCreationDate
        /// </summary>
        public Object JobCreationDate
        {
            get { return _dJobCreationDate; }
            set { _dJobCreationDate = value; }
        }

        public bool Flag
        {
            get { return _bFlag; }
            set { _bFlag = value; }
        }


        /// <summary>
        /// Get set property for DeliveryDate (Cassandra)
        /// </summary>
        public Object DeliveryDate
        {
            get { return _dDeliveryDate; }
            set { _dDeliveryDate = value; }
        }

        /// <summary>
        /// Get set property for IsDelivered (Cassandra)
        /// </summary>
        public int IsDelivered
        {
            get { return _nIsDelivered; }
            set { _nIsDelivered = value; }
        }

        /// <summary>
        /// Get set property for ProductID (Cassandra)
        /// </summary>
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        /// <summary>
        /// Get set property for ProductCode (Cassandra)
        /// </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }

        /// <summary>
        /// Get set property for ProductName (Cassandra)
        /// </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }

        public void RefreshByJobNo()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                //cmd.CommandText = "Select * from TELServiceDB.dbo.Job where JobStatus=15 AND IsDelivered=0 AND JobNo=?";
                cmd.CommandText = "Select J.*,R.JobID from TELServiceDB.dbo.Job J Left Outer JOIN t_CSDReplace R ON J.JobID=R.JobID where J.JobStatus=15 AND J.IsDelivered=0 AND R.JobID  IS NULL AND J.JobNo=?";

                cmd.Parameters.AddWithValue("J.JobNo", _sJobNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nJobID = (int)reader["JobID"];
                    _sJobNo = (string)reader["JobNo"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _sFirstAddress = (string)reader["FirstAddress"];
                    _sMobile = (string)reader["Mobile"];
                    _dJobCreationDate = Convert.ToDateTime(reader["JobCreationDate"].ToString());


                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                _bFlag = true;
            else _bFlag=false;
        }
        public void RefreshByJobNoAll()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select * from TELServiceDB.dbo.Job where JobNo=?";

                cmd.Parameters.AddWithValue("JobNo", _sJobNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nJobID = (int)reader["JobID"];
                    _sJobNo = (string)reader["JobNo"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _sFirstAddress = (string)reader["FirstAddress"];
                    _sMobile = (string)reader["Mobile"];
                    _dJobCreationDate = Convert.ToDateTime(reader["JobCreationDate"].ToString());

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                _bFlag = true;
            else _bFlag = false;
        }
        public void RefreshByJobNoISV()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText =   "Select JobID,JobNo,P.name ProductName from TELServiceDB.dbo.Job J  " +
                                    "INNER JOIN TELServiceDB.dbo.Product P " +
                                    "ON J.ProductID=P.ProductID Where ServiceType IN (3,2) AND JobNo=?";

                cmd.Parameters.AddWithValue("JobNo", _sJobNo);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nJobID = (int)reader["JobID"];
                    _sJobNo = (string)reader["JobNo"];
                    _sProductName = (string)reader["ProductName"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                _bFlag = true;
            else _bFlag = false;
        }
        public void RefreshByJobID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            
            try
            {
                cmd.CommandText = "Select JobID,JobNo,P.name ProductName from TELServiceDB.dbo.Job J  " +
                                    "INNER JOIN TELServiceDB.dbo.Product P " +
                                    "ON J.ProductID=P.ProductID Where JobID=?";

                cmd.Parameters.AddWithValue("JobID",_nJobID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nJobID = (int)reader["JobID"];
                    _sJobNo = (string)reader["JobNo"];
                    _sProductName = (string)reader["ProductName"];
                    
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

    }

    public class ReplaceJobFromCassandras : CollectionBase
        {
        public ReplaceJobFromCassandra this[int i]
            {
                get { return (ReplaceJobFromCassandra)InnerList[i]; }
                set { InnerList[i] = value; }
            }

        public void Add(ReplaceJobFromCassandra oReplaceJobFromCassandra)
            {
                InnerList.Add(oReplaceJobFromCassandra);
            }
  
        //public void Refresh(int nJobID)
        //    {
        //        //dtToDate = dtToDate.Date.AddDays(1);
        //        InnerList.Clear();
        //        OleDbCommand cmd = DBController.Instance.GetCommand();

        //        string sSql = "Select * from TELServiceDB.dbo.Job where JobStatus=15 AND IsDelivered=0 AND JobID=?";


        //        //if (txtJobNo != "")
        //        //{
        //        //    txtJobNo = "%" + txtJobNo + "%";
        //        //    sSql = sSql + " AND JobID LIKE '" + txtJobNo + "'";
        //        //}
        //        //if (nStatus > -1)
        //        //{
        //        //    sSql = sSql + "AND Status ='" + nStatus + "'";
        //        //}

        //        try
        //        {
        //            cmd.CommandText = sSql;
        //            cmd.CommandType = CommandType.Text;
        //            IDataReader reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                ReplaceJobFromCassandra oReplaceJobFromCassandra = new ReplaceJobFromCassandra();
        //                oReplaceJobFromCassandra.JobID = (int)reader["JobID"];
        //                oReplaceJobFromCassandra.JobNo=(string)reader["JobNo"];
        //                oReplaceJobFromCassandra.CustomerName = (string)reader["CustomerName"];
        //                oReplaceJobFromCassandra.FirstAddress = (string)reader["FirstAddress"];
        //                oReplaceJobFromCassandra.Mobile = (string)reader["Mobile"];
        //                oReplaceJobFromCassandra.JobCreationDate = Convert.ToDateTime(reader["JobCreationDate"].ToString());

        //               InnerList.Add(oReplaceJobFromCassandra);
        //            }
        //            reader.Close();
        //            InnerList.TrimToSize();

        //        }
        //        catch (Exception ex)
        //        {
        //            throw (ex);
        //        }
        //    }

        public void RefreshReplaceJob(String txtJobNo, String txtCustomerName, String txtContactNo)
        {
            //dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select J.*,R.JobID from TELServiceDB.dbo.Job J " +
                          "Left Outer JOIN t_CSDReplace R ON J.JobID=R.JobID where J.JobStatus=15 AND J.IsDelivered=0 AND R.JobID  IS NULL";


            if (txtJobNo != "")
            {
                txtJobNo = "%" + txtJobNo + "%";
                sSql = sSql + " AND J.JobNo LIKE '" + txtJobNo + "'";
            }
            if (txtCustomerName != "")
            {
                txtCustomerName = "%" + txtCustomerName + "%";
                sSql = sSql + " AND J.CustomerName LIKE '" + txtCustomerName + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND J.Mobile LIKE '" + txtContactNo + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReplaceJobFromCassandra oReplaceJobFromCassandra = new ReplaceJobFromCassandra();
                    oReplaceJobFromCassandra.JobID = (int)reader["JobID"];
                    oReplaceJobFromCassandra.JobNo = (string)reader["JobNo"];
                    oReplaceJobFromCassandra.CustomerName = (string)reader["CustomerName"];
                    oReplaceJobFromCassandra.Mobile = (string)reader["Mobile"];
                    oReplaceJobFromCassandra.FirstAddress = (string)reader["FirstAddress"];
                    oReplaceJobFromCassandra.JobCreationDate = (Object)reader["JobCreationDate"].ToString();

                    InnerList.Add(oReplaceJobFromCassandra);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshAllJob(String txtJobNo, String txtCustomerName, String txtContactNo)
        {
            //dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "Select * from TELServiceDB.dbo.Job ";


            if (txtJobNo != "")
            {
                txtJobNo = "%" + txtJobNo + "%";
                sSql = sSql + " AND J.JobNo LIKE '" + txtJobNo + "'";
            }
            if (txtCustomerName != "")
            {
                txtCustomerName = "%" + txtCustomerName + "%";
                sSql = sSql + " AND J.CustomerName LIKE '" + txtCustomerName + "'";
            }
            if (txtContactNo != "")
            {
                txtContactNo = "%" + txtContactNo + "%";
                sSql = sSql + " AND J.Mobile LIKE '" + txtContactNo + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReplaceJobFromCassandra oReplaceJobFromCassandra = new ReplaceJobFromCassandra();
                    oReplaceJobFromCassandra.JobID = (int)reader["JobID"];
                    oReplaceJobFromCassandra.JobNo = (string)reader["JobNo"];
                    oReplaceJobFromCassandra.CustomerName = (string)reader["CustomerName"];
                    oReplaceJobFromCassandra.Mobile = (string)reader["Mobile"];
                    oReplaceJobFromCassandra.FirstAddress = (string)reader["FirstAddress"];
                    oReplaceJobFromCassandra.JobCreationDate = (Object)reader["JobCreationDate"].ToString();

                    InnerList.Add(oReplaceJobFromCassandra);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //public void RefreshISVJob(String txtJobNo, String txtCustomerName, String txtContactNo, String txtProductName, String txtProductCode)
        //{
        //    InnerList.Clear();
        //    OleDbCommand cmd = DBController.Instance.GetCommand();


        //    string sSql = "Select JobID,JobNo,CustomerName,Mobile,P.name ProductName, FirstAddress,P.Code ProductCode from TELServiceDB.dbo.Job J  " +
        //                  "INNER JOIN TELServiceDB.dbo.Product P " +
        //                  "ON J.ProductID=P.ProductID Where ServiceType IN (3,2) ";


        //    if (txtJobNo != "")
        //    {
        //        txtJobNo = "%" + txtJobNo + "%";
        //        sSql = sSql + " AND JobNo LIKE '" + txtJobNo + "'";
        //    }
        //    if (txtCustomerName != "")
        //    {
        //        txtCustomerName = "%" + txtCustomerName + "%";
        //        sSql = sSql + " AND CustomerName LIKE '" + txtCustomerName + "'";
        //    }
        //    if (txtContactNo != "")
        //    {
        //        txtContactNo = "%" + txtContactNo + "%";
        //        sSql = sSql + " AND Mobile LIKE '" + txtContactNo + "'";
        //    }
        //    if (txtProductName != "")
        //    {
        //        txtProductName = "%" + txtProductName + "%";
        //        sSql = sSql + " AND P.name LIKE '" + txtProductName + "'";
        //    }
        //    if (txtProductCode != "")
        //    {
        //        txtProductCode = "%" + txtProductCode + "%";
        //        sSql = sSql + " AND P.Code LIKE '" + txtProductCode + "'";
        //    }

        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            ReplaceJobFromCassandra oReplaceJobFromCassandra = new ReplaceJobFromCassandra();
        //            oReplaceJobFromCassandra.JobID = (int)reader["JobID"];
        //            oReplaceJobFromCassandra.JobNo = (string)reader["JobNo"];
        //            oReplaceJobFromCassandra.CustomerName = (string)reader["CustomerName"];
        //            oReplaceJobFromCassandra.Mobile = (string)reader["Mobile"];
        //            oReplaceJobFromCassandra.ProductName = (string)reader["ProductName"];
        //            oReplaceJobFromCassandra.ProductCode = (string)reader["ProductCode"];
        //            oReplaceJobFromCassandra.FirstAddress = (string)reader["FirstAddress"];
                    

        //            InnerList.Add(oReplaceJobFromCassandra);
        //        }
        //        reader.Close();
        //        InnerList.TrimToSize();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}

        }

    }
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: Jan 22, 2012
// Time :  4:55 PM
// Description: Class for Attendance Data.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;



namespace CJ.Class.CSD
{
    public class ServiceJob
    {
        private int _nJobID;
        private string _sJobNo;
        private string _sCustomerName;
        private string _sFirstAddress;
        private string _sMobile;
        private string _sRemarks;
        private Object _dJobCreationDate;
        private string _sProductCode;
        private string _sProductName;
        private string _sISCode;
        private string _sISName;
        private string _sISAddress;

        /// <summary>
        /// Get set property for JobID
        /// </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
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
        /// Get set property for FirstAddress
        /// </summary>
        public string FirstAddress
        {
            get { return _sFirstAddress; }
            set { _sFirstAddress = value; }
        }
        /// <summary>
        /// Get set property for Contact Number
        /// </summary>
        public string Mobile
        {
            get { return _sMobile; }
            set { _sMobile = value; }
        }
        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }
        /// <summary>
        /// Get set property for JobCreationDate
        /// </summary>
        public Object JobCreationDate
        {
            get { return _dJobCreationDate; }
            set { _dJobCreationDate = value; }
        }
        /// <summary>
        /// Get set property for ProductCode
        /// </summary>
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        /// <summary>
        /// Get set property for ProductName
        /// </summary>
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        /// <summary>
        /// Get set property for ISCode
        /// </summary>
        public string ISCode
        {
            get { return _sISCode; }
            set { _sISCode = value; }
        }
        /// <summary>
        /// Get set property for ISName
        /// </summary>
        public string ISName
        {
            get { return _sISName; }
            set { _sISName = value; }
        }
        /// <summary>
        /// Get set property for ISAddress
        /// </summary>
        public string ISAddress
        {
            get { return _sISAddress; }
            set { _sISAddress = value; }
        }

        public void UpdateStatus(DateTime dDate)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "UPDATE TELServiceDB.dbo.Job SET DeliveryDate=?,Isdelivered=1, JobStatus=13 WHERE ServiceType=3 and IsDelivered=0 and JobID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DeliveryDate", dDate);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }


    public class ServiceJobs : CollectionBase
    {
        public ServiceJob this[int i]
        {
            get { return (ServiceJob)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(ServiceJob oServiceJob)
        {
            InnerList.Add(oServiceJob);
        }

        //public int GetIndex(int nServiceJobID)
        //{
        //    int i;
        //    for (i = 0; i < this.Count; i++)
        //    {
        //        if (this[i].ServiceJobID == nServiceJobID)
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}

        public void Refresh(DateTime dtFromDate, DateTime dtToDate, String txtJobNo)
        {
            dtToDate = dtToDate.Date.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            //string sSql = "SELECT * FROM TELServiceDB.dbo.Job WHERE ServiceType=3 and IsDelivered=0 AND JobCreationDate BETWEEN '" + dtFromDate + "'AND '" + dtToDate + "' AND JobCreationDate < '" + dtToDate + "'";

            string sSql =   "SELECT J.JobID, J.SerialNo, J.JobNo, J.CustomerName, J.FirstAddress, J.Remarks, J.Mobile, JobCreationDate, " +
                            "P.Code ProductCode, P.Name ProductName,ISV.Code ISCode, ISV.Name ISName, ISV.Address " +
                            "FROM TELServiceDB.dbo.Job J " +
                            "INNER JOIN TELServiceDB.dbo.Product P " +
                            "ON P.ProductID=J.ProductID " +
                            "INNER JOIN TELServiceDB.dbo.InterService ISV " +
                            "ON ISV.ID=J.InterServiceID " +
                            "WHERE J.ServiceType=3 and J.IsDelivered=0 AND JobStatus <> 20 AND J.JobCreationDate " +
                            "BETWEEN '" + dtFromDate + "'AND '" + dtToDate + "' AND JobCreationDate < '" + dtToDate + "'";


            if (txtJobNo != "")
            {
                txtJobNo = "%" + txtJobNo + "%";
                sSql = sSql + " AND J.JobNo LIKE '" + txtJobNo + "'";

            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ServiceJob oServiceJob = new ServiceJob();

                    oServiceJob.JobID = (int)reader["JobID"];
                    oServiceJob.JobNo = (string)reader["JobNo"];
                    oServiceJob.CustomerName = (string)reader["CustomerName"];
                    oServiceJob.FirstAddress = (string)reader["FirstAddress"];
                    oServiceJob.Mobile = (string)reader["Mobile"];
                    oServiceJob.Remarks = (string)reader["Remarks"];
                    oServiceJob.JobCreationDate = Convert.ToDateTime(reader["JobCreationDate"].ToString());
                    oServiceJob.ProductCode = (string)reader["ProductCode"];
                    oServiceJob.ProductName = (string)reader["ProductName"];
                    oServiceJob.ISCode = (string)reader["ISCode"];
                    oServiceJob.ISName = (string)reader["ISName"];
                    oServiceJob.ISAddress = (string)reader["Address"];
                    InnerList.Add(oServiceJob);
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

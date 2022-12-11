using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class IPDCFileTracking
    {
        private int _nTrackingID;
        private int _nInvoiceID;
        private string _sReferenceNo;
        private string _sDescription;
        private int _nCreateUserID;
        private object _dCreateDate;

        private int _nStatus;
        private string _sRemarks;
        private string _sInvoiceNo;
        private string _sCustomerName;
        private string _sCustomerContact;
        private double _InvoiceAmount;
        private DateTime _dInvoiceDate;
        private string _sStatusName;
        private string _sMobileNo;




        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value.Trim(); }
        }


        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value.Trim(); }
        }


        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value.Trim(); }
        }

        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }

        public string CustomerContact
        {
            get { return _sCustomerContact; }
            set { _sCustomerContact = value.Trim(); }
        }

        public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }

        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }


        public object CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        // <summary>
        // Get set property for TrackingID
        // </summary>
        public int TrackingID
        {
            get { return _nTrackingID; }
            set { _nTrackingID = value; }
        }

        // <summary>
        // Get set property for InvoiceID
        // </summary>
        public int InvoiceID
        {
            get { return _nInvoiceID; }
            set { _nInvoiceID = value; }
        }

        // <summary>
        // Get set property for ReferenceNo
        // </summary>
        public string ReferenceNo
        {
            get { return _sReferenceNo; }
            set { _sReferenceNo = value.Trim(); }
        }

        // <summary>
        // Get set property for Description
        // </summary>
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value.Trim(); }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        //public DateTime CreateDate
        //{
        //    get { return _dCreateDate; }
        //    set { _dCreateDate = value; }
        //}

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        public void Add()
        {
            int nMaxTrackingID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([TrackingID]) FROM t_IPDCFileTracking";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxTrackingID = 1;
                }
                else
                {
                    nMaxTrackingID = Convert.ToInt32(maxID) + 1;
                }
                _nTrackingID = nMaxTrackingID;
                sSql = "INSERT INTO t_IPDCFileTracking (TrackingID, InvoiceID, ReferenceNo, Description, CreateUserID, CreateDate, Status, Remarks) VALUES(?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TrackingID", _nTrackingID);
                cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);
                cmd.Parameters.AddWithValue("ReferenceNo", _sReferenceNo);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                IPDCFileTrackingStatusHistory oIPDCFileTrackingStatusHistory = new IPDCFileTrackingStatusHistory();

                oIPDCFileTrackingStatusHistory.AddFileTrackingData(_nTrackingID, _nStatus, _sRemarks, _nCreateUserID, _dCreateDate);


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
                sSql = "UPDATE t_IPDCFileTracking SET InvoiceID = ?, ReferenceNo = ?, Description = ?, CreateUserID = ?, CreateDate = ?, Status = ?, Remarks = ? WHERE TrackingID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoiceID", _nInvoiceID);
                cmd.Parameters.AddWithValue("ReferenceNo", _sReferenceNo);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("TrackingID", _nTrackingID);

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
                sSql = "UPDATE t_IPDCFileTracking SET Status = ? WHERE TrackingID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("TrackingID", _nTrackingID);

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
                sSql = "DELETE FROM t_IPDCFileTracking WHERE [TrackingID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("TrackingID", _nTrackingID);
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
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_IPDCFileTracking where TrackingID =?";
                cmd.Parameters.AddWithValue("TrackingID", _nTrackingID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nTrackingID = (int)reader["TrackingID"];
                    _nInvoiceID = (int)reader["InvoiceID"];
                    _sReferenceNo = (string)reader["ReferenceNo"];
                    _sDescription = (string)reader["Description"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nStatus = (int)reader["Status"];
                    _sRemarks = (string)reader["Remarks"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class IPDCFileTrackings : CollectionBase
    {
        public IPDCFileTracking this[int i]
        {
            get { return (IPDCFileTracking)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(IPDCFileTracking oIPDCFileTracking)
        {
            InnerList.Add(oIPDCFileTracking);
        }
        public int GetIndex(int nTrackingID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].TrackingID == nTrackingID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate, string sInvoiceNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select distinct a.InvoiceID, a.InvoiceNo, a.InvoiceDate, a.InvoiceAmount, a.Remarks, c.ConsumerName as CustomerName, c.Address as CustomerAddress, c.CellNo as MobileNo from t_SalesInvoice a inner join t_SalesInvoicePaymentModeNew b on a.invoiceid = b.invoiceid " +
             " inner join t_RetailConsumer c on a.SundryCustomerID = c.ConsumerID and a.WarehouseID = c.WarehouseID where b.PaymentModeID = 16 and a.InvoiceID not in (select distinct InvoiceID from t_IPDCFileTracking)";

            //string sSql = " select distinct a.InvoiceID, a.InvoiceNo, a.InvoiceDate, a.InvoiceAmount, a.Remarks, c.CustomerName, c.CustomerAddress from t_SalesInvoice a inner join t_SalesInvoicePaymentModeNew b on a.invoiceid = b.invoiceid " +
            //                "inner join t_Customer c on a.CustomerID = c.CustomerID where b.PaymentModeID = 16 and a.InvoiceID not in (select distinct InvoiceID from t_IPDCFileTracking)";


            sSql = sSql + " AND a.InvoiceDate between '" + dFromDate + "' and '" + dToDate + "' ";


            if(!string.IsNullOrEmpty(sInvoiceNo))
            {

                sSql = sSql + " AND a.InvoiceNo like '%" + sInvoiceNo + "%'";
            }


            sSql = sSql + " order by a.InvoiceID desc";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    IPDCFileTracking oIPDCFileTracking = new IPDCFileTracking();
                    oIPDCFileTracking.InvoiceID = (int)reader["InvoiceID"];
                    oIPDCFileTracking.InvoiceNo = (string)reader["InvoiceNo"];
                    oIPDCFileTracking.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());

                    if (reader["InvoiceAmount"] != DBNull.Value)
                        oIPDCFileTracking.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());

                    oIPDCFileTracking.Remarks = (string)reader["Remarks"];


                    oIPDCFileTracking.CustomerName = (string)reader["CustomerName"];
                    oIPDCFileTracking.CustomerContact = (string)reader["CustomerAddress"];
                    oIPDCFileTracking.MobileNo = (string)reader["MobileNo"];


                    InnerList.Add(oIPDCFileTracking);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetIPDCFileTrackingData(DateTime dFromDate, DateTime dToDate, bool IsCheck, string sInvoiceNo, int nStatus)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "select a.TrackingID, a.InvoiceID, b.InvoiceNo, b.InvoiceDate, b.InvoiceAmount, c.CustomerName, c.CustomerAddress, a.ReferenceNo, a.Description, a.CreateDate, a.Status, d.StatusName, a.Remarks " +
                "from t_IPDCFileTracking a inner join t_SalesInvoice b on a.InvoiceID = b.InvoiceID inner join t_Customer c on b.CustomerID = c.CustomerID inner join t_IPDCFileTrackingStatus d on a.status = d.StatusID where 1=1";

            if (IsCheck == false)
            {
                sSql = sSql + " AND a.CreateDate between '" + dFromDate + "' and '" + dToDate + "' ";
            }

            if (!string.IsNullOrEmpty(sInvoiceNo))
            {
                sSql = sSql + " AND b.InvoiceNo like '%" + sInvoiceNo + "%'";
            }


            if (nStatus != 0)
            {
                sSql = sSql + " AND a.Status=" + nStatus + "";
            }


            sSql = sSql + " order by a.InvoiceID desc";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    IPDCFileTracking oIPDCFileTracking = new IPDCFileTracking();
                    oIPDCFileTracking.TrackingID = (int)reader["TrackingID"];
                    oIPDCFileTracking.InvoiceID = (int)reader["InvoiceID"];
                    oIPDCFileTracking.InvoiceNo = (string)reader["InvoiceNo"];
                    oIPDCFileTracking.InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"].ToString());

                    if (reader["InvoiceAmount"] != DBNull.Value)
                        oIPDCFileTracking.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"].ToString());

                    oIPDCFileTracking.CustomerName = (string)reader["CustomerName"];
                    oIPDCFileTracking.CustomerContact = (string)reader["CustomerAddress"];

                    oIPDCFileTracking.ReferenceNo = (string)reader["ReferenceNo"];

                    oIPDCFileTracking.Description = (string)reader["Description"];

                    if (reader["CreateDate"] != DBNull.Value)
                        oIPDCFileTracking.CreateDate = (object)reader["CreateDate"];
                    else oIPDCFileTracking.CreateDate = null;


                    oIPDCFileTracking.Status = int.Parse(reader["Status"].ToString());
                    oIPDCFileTracking.StatusName = (string)reader["StatusName"];

                    oIPDCFileTracking.Remarks = (string)reader["Remarks"];


                    //oIPDCFileTracking.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oIPDCFileTracking);
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


    public class IPDCFileTrackingStatusHistory
    {
        private int _nID;
        private int _nTrackingID;
        private int _nStatus;
        private string _sRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private string _sStatusName;
        private string _sUserName;



        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value.Trim(); }
        }


        public string UserName
        {
            get { return _sUserName; }
            set { _sUserName = value.Trim(); }
        }

        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for TrackingID
        // </summary>
        public int TrackingID
        {
            get { return _nTrackingID; }
            set { _nTrackingID = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        

        public void AddFileTrackingData(int nTrackingID, int nStatus, string sRemarks, int nCreateUserID, Object dCreateDate )
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_IPDCFileTrackingStatusHistory";
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
                sSql = "INSERT INTO t_IPDCFileTrackingStatusHistory (ID, TrackingID, Status, Remarks, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("TrackingID", nTrackingID);
                cmd.Parameters.AddWithValue("Status", nStatus);
                cmd.Parameters.AddWithValue("Remarks", sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", dCreateDate);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_IPDCFileTrackingStatusHistory";
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
                sSql = "INSERT INTO t_IPDCFileTrackingStatusHistory (ID, TrackingID, Status, Remarks, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("TrackingID", _nTrackingID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

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
                sSql = "UPDATE t_IPDCFileTrackingStatusHistory SET TrackingID = ?, Status = ?, Remarks = ?, CreateUserID = ?, CreateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TrackingID", _nTrackingID);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "DELETE FROM t_IPDCFileTrackingStatusHistory WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
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
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_IPDCFileTrackingStatusHistory where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nTrackingID = (int)reader["TrackingID"];
                    _nStatus = (int)reader["Status"];
                    _sRemarks = (string)reader["Remarks"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class IPDCFileTrackingStatusHistorys : CollectionBase
    {
        public IPDCFileTrackingStatusHistory this[int i]
        {
            get { return (IPDCFileTrackingStatusHistory)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(IPDCFileTrackingStatusHistory oIPDCFileTrackingStatusHistory)
        {
            InnerList.Add(oIPDCFileTrackingStatusHistory);
        }
        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(int nTrackingID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT a.ID, a.TrackingID, a.Status, b.StatusName, a.Remarks, a.CreateUserID, a.CreateDate, c.UserFullName as UserName FROM t_IPDCFileTrackingStatusHistory a inner join t_IPDCFileTrackingStatus b on a.status = b.StatusID inner join t_User c on a.CreateUserID = c.UserID where a.TrackingID = " + nTrackingID + "";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    IPDCFileTrackingStatusHistory oIPDCFileTrackingStatusHistory = new IPDCFileTrackingStatusHistory();
                    oIPDCFileTrackingStatusHistory.ID = (int)reader["ID"];
                    oIPDCFileTrackingStatusHistory.TrackingID = (int)reader["TrackingID"];
                    oIPDCFileTrackingStatusHistory.Status = (int)reader["Status"];
                    oIPDCFileTrackingStatusHistory.StatusName = (string)reader["StatusName"];
                    oIPDCFileTrackingStatusHistory.Remarks = (string)reader["Remarks"];

                    oIPDCFileTrackingStatusHistory.CreateUserID = (int)reader["CreateUserID"];

                    oIPDCFileTrackingStatusHistory.UserName = (string)reader["UserName"];

                    oIPDCFileTrackingStatusHistory.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());


                    InnerList.Add(oIPDCFileTrackingStatusHistory);
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




    public class IPDCFileTrackingStatus
        {
            private int _nID;
            private int _nStatusID;
            private string _sStatusName;


            // <summary>
            // Get set property for ID
            // </summary>
            public int ID
            {
                get { return _nID; }
                set { _nID = value; }
            }

            // <summary>
            // Get set property for StatusID
            // </summary>
            public int StatusID
            {
                get { return _nStatusID; }
                set { _nStatusID = value; }
            }

            // <summary>
            // Get set property for StatusName
            // </summary>
            public string StatusName
            {
                get { return _sStatusName; }
                set { _sStatusName = value.Trim(); }
            }

            public void Add()
            {
                int nMaxID = 0;
                OleDbCommand cmd = DBController.Instance.GetCommand();
                string sSql = "";
                try
                {
                    sSql = "SELECT MAX([ID]) FROM t_IPDCFileTrackingStatus";
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
                    sSql = "INSERT INTO t_IPDCFileTrackingStatus (ID, StatusID, StatusName) VALUES(?,?,?)";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("ID", _nID);
                    cmd.Parameters.AddWithValue("StatusID", _nStatusID);
                    cmd.Parameters.AddWithValue("StatusName", _sStatusName);

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
                    sSql = "UPDATE t_IPDCFileTrackingStatus SET StatusID = ?, StatusName = ? WHERE ID = ?";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("StatusID", _nStatusID);
                    cmd.Parameters.AddWithValue("StatusName", _sStatusName);

                    cmd.Parameters.AddWithValue("ID", _nID);

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
                    sSql = "DELETE FROM t_IPDCFileTrackingStatus WHERE [ID]=?";
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("ID", _nID);
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
                int nCount = 0;
                try
                {
                    cmd.CommandText = "SELECT * FROM t_IPDCFileTrackingStatus where ID =?";
                    cmd.Parameters.AddWithValue("ID", _nID);
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        _nID = (int)reader["ID"];
                        _nStatusID = (int)reader["StatusID"];
                        _sStatusName = (string)reader["StatusName"];
                        nCount++;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }
        public class IPDCFileTrackingStatuss : CollectionBase
        {
            public IPDCFileTrackingStatus this[int i]
            {
                get { return (IPDCFileTrackingStatus)InnerList[i]; }
                set { InnerList[i] = value; }
            }
            public void Add(IPDCFileTrackingStatus oIPDCFileTrackingStatus)
            {
                InnerList.Add(oIPDCFileTrackingStatus);
            }
            public int GetIndex(int nID)
            {
                int i;
                for (i = 0; i < this.Count; i++)
                {
                    if (this[i].ID == nID)
                    {
                        return i;
                    }
                }
                return -1;
            }

            public void GetStatus()
            {
                InnerList.Clear();
                OleDbCommand cmd = DBController.Instance.GetCommand();
                string sSql = "SELECT * FROM t_IPDCFileTrackingStatus where statusID != 1";
                try
                {
                    cmd.CommandText = sSql;
                    cmd.CommandType = CommandType.Text;
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        IPDCFileTrackingStatus oIPDCFileTrackingStatus = new IPDCFileTrackingStatus();
                        oIPDCFileTrackingStatus.ID = (int)reader["ID"];
                        oIPDCFileTrackingStatus.StatusID = (int)reader["StatusID"];
                        oIPDCFileTrackingStatus.StatusName = (string)reader["StatusName"];
                        InnerList.Add(oIPDCFileTrackingStatus);
                    }
                    reader.Close();
                    InnerList.TrimToSize();
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }

        public void GetAllStatus()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_IPDCFileTrackingStatus";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    IPDCFileTrackingStatus oIPDCFileTrackingStatus = new IPDCFileTrackingStatus();
                    oIPDCFileTrackingStatus.ID = (int)reader["ID"];
                    oIPDCFileTrackingStatus.StatusID = (int)reader["StatusID"];
                    oIPDCFileTrackingStatus.StatusName = (string)reader["StatusName"];
                    InnerList.Add(oIPDCFileTrackingStatus);
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


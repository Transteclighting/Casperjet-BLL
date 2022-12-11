// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Oct 01, 2014
// Time :  04:36 PM
// Description: Class for ProactiveCall.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.CSD
{
    public class ProactiveCall
    {
        private int _nID;
        private int _nJobID;
        private DateTime _dNextFollowUpDate;
        private object _dProposeFollowupDate;
        private DateTime _dLastFeedbackDate;
        private string _sRemarks;
        private string _sLastCommunication;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private object _nUpdateUserID;
        private object _dUpdateDate;
        private int _nIsBanForever;

        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for JobID
        // </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }

        // <summary>
        // Get set property for NextFollowUpDate
        // </summary>
        public DateTime NextFollowUpDate
        {
            get { return _dNextFollowUpDate; }
            set { _dNextFollowUpDate = value; }
        }
        
        // <summary>
        // Get set property for LastFeedbackDate
        // </summary>
        public DateTime LastFeedbackDate
        {
            get { return _dLastFeedbackDate; }
            set { _dLastFeedbackDate = value; }
        }

        // <summary>
        // Get set property for ProposeFollowupDate
        // </summary>
        public object ProposeFollowupDate
        {
            get { return _dProposeFollowupDate; }
            set { _dProposeFollowupDate = value; }
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
        // Get set property for LastCommunication
        // </summary>
        public string LastCommunication
        {
            get { return _sLastCommunication; }
            set { _sLastCommunication = value.Trim(); }
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

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public object UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public object UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        // <summary>
        // Get set property for IsBanForever
        // </summary>
        public int IsBanForever
        {
            get { return _nIsBanForever; }
            set { _nIsBanForever = value; }
        }

        private string _sJobNo;
        public string JobNo
        {
            get { return _sJobNo; }
            set { _sJobNo = value; }
        }
        private string _sUserFullName;
        public string UserFullName
        {
            get { return _sUserFullName; }
            set { _sUserFullName = value; }
        }
        private string _sProductSerialNo;
        public string ProductSerialNo
        {
            get { return _sProductSerialNo; }
            set { _sProductSerialNo = value; }
        }
        private string _sCustomerName;
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        private string _sMobileNo;
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value; }
        }
        private string _sCustomerAddress;
        public string CustomerAddress
        {
            get { return _sCustomerAddress; }
            set { _sCustomerAddress = value; }
        }
        private int _nStatus;
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        private string _sProductCode;
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        private string _sProductName;
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        private DateTime _dJobCreateDate;
        public DateTime JobCreateDate
        {
            get { return _dJobCreateDate; }
            set { _dJobCreateDate = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CSDProductiveCallList";
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
                sSql = "INSERT INTO t_CSDProductiveCallList (ID, JobID, NextFollowUpDate, ProposeFollowupDate, Remarks, LastCommunication, CreateUserID, CreateDate, IsBanForever) VALUES(?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("NextFollowUpDate", _dNextFollowUpDate);
                cmd.Parameters.AddWithValue("ProposeFollowupDate", _dProposeFollowupDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("LastCommunication", _sLastCommunication);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("IsBanForever", _nIsBanForever);

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
                sSql = "UPDATE t_CSDProductiveCallList SET JobID = ?, NextFollowUpDate = ?, ProposeFollowupDate = ?, Remarks = ?, LastCommunication = ?, CreateUserID = ?, CreateDate = ?, UpdateUserID = ?, UpdateDate = ?, IsBanForever = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("NextFollowUpDate", _dNextFollowUpDate);
                cmd.Parameters.AddWithValue("ProposeFollowupDate", _dProposeFollowupDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("LastCommunication", _sLastCommunication);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("IsBanForever", _nIsBanForever);

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
                sSql = "DELETE FROM t_CSDProductiveCallList WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_CSDProductiveCallList where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nJobID = (int)reader["JobID"];
                    if (reader["NextFollowUpDate"] != DBNull.Value)
                    {
                        _dNextFollowUpDate = Convert.ToDateTime(reader["NextFollowUpDate"].ToString());
                    }                    
                    _dProposeFollowupDate = Convert.ToDateTime(reader["ProposeFollowupDate"].ToString());
                    _sRemarks = (string)reader["Remarks"];
                    _sLastCommunication = (string)reader["LastCommunication"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        _nUpdateUserID = (int)reader["UpdateUserID"];
                    }
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    }                
                    
                    _nIsBanForever = (int)reader["IsBanForever"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
           
        }
        public void RefreshByJobID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CSDProductiveCallList where JobID =?";
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nJobID = (int)reader["JobID"];
                    if (reader["NextFollowUpDate"] != DBNull.Value)
                    {
                        _dNextFollowUpDate = Convert.ToDateTime(reader["NextFollowUpDate"].ToString());
                    }
                    if (reader["ProposeFollowupDate"] != DBNull.Value)
                    {
                        _dProposeFollowupDate = Convert.ToDateTime(reader["ProposeFollowupDate"].ToString());

                    }
                    _sRemarks = (string)reader["Remarks"];
                    _sLastCommunication = (string)reader["LastCommunication"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    if (reader["UpdateUserID"] != DBNull.Value)
                    {
                        _nUpdateUserID = (int)reader["UpdateUserID"];
                    }
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    }
                    if (reader["IsBanForever"] != DBNull.Value)
                    {
                        _nIsBanForever = (int)reader["IsBanForever"];
                    }                    
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateLastCommunication()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CSDProductiveCallList SET LastCommunication = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LastCommunication", _sLastCommunication);
                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateNextFollowupDate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CSDProductiveCallList SET NextFollowUpDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("NextFollowUpDate", _dNextFollowUpDate);
                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateBanForever()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CSDProductiveCallList SET IsBanForever = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsBanForever", _nIsBanForever);
                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class ProactiveCalls : CollectionBase
    {
        public ProactiveCall this[int i]
        {
            get { return (ProactiveCall)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ProactiveCall oProactiveCall)
        {
            InnerList.Add(oProactiveCall);
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
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_CSDProductiveCallList";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProactiveCall oCSDProductiveCallList = new ProactiveCall();
                    oCSDProductiveCallList.ID = (int)reader["ID"];
                    oCSDProductiveCallList.JobID = (int)reader["JobID"];
                    oCSDProductiveCallList.NextFollowUpDate = Convert.ToDateTime(reader["NextFollowUpDate"].ToString());
                    oCSDProductiveCallList.ProposeFollowupDate = Convert.ToDateTime(reader["ProposeFollowupDate"].ToString());
                    oCSDProductiveCallList.Remarks = (string)reader["Remarks"];
                    oCSDProductiveCallList.LastCommunication = (string)reader["LastCommunication"];
                    oCSDProductiveCallList.CreateUserID = (int)reader["CreateUserID"];
                    oCSDProductiveCallList.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDProductiveCallList.UpdateUserID = (int)reader["UpdateUserID"];
                    oCSDProductiveCallList.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oCSDProductiveCallList.IsBanForever = (int)reader["IsBanForever"];
                    InnerList.Add(oCSDProductiveCallList);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByDate(int nJobType, int nServiceType, int nJobStatus,DateTime dtFromDate, DateTime dtToDate, int nJobID, string sMobileNo, string sBarcodeSerialNo, int nCheckAll,int  nIsLFChecked, DateTime dtLFFromDate, DateTime dtLFToDate)
        {
            dtToDate = dtToDate.AddDays(1);
            dtLFToDate = dtLFToDate.AddDays(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT ID, a.JobID, JobNo,b.CreateDate as JobCreateDate, NextFollowUpDate, ProposeFollowupDate, a.Remarks, "+
                          " LastCommunication, UserFullName, a.CreateDate, ProductSerialNo, CustomerName, MobileNo, CustomerAddress,  "+
                          " Status, ProductCode, ProductName,b.LastFeedbackDate FROM t_CSDProductiveCallList a, t_CSDJob b, t_Product c, t_User d  " +
                          " Where a.JobID = b.JobID and b.ProductID = c.ProductID and d.UserID=a.CreateUserID and IsBanForever = " + (int)Dictionary.YesOrNoStatus.NO + " ";

            if (nJobType != 0)
            {
                sSql += " AND b.JobType = " + nJobType + " ";
            }
            if (nServiceType != 0)
            {
                sSql += " AND b.ServiceType = " + nServiceType + " ";
            }
            if (nJobStatus != -1)
            {
                sSql += " AND b.Status = " + nJobStatus + " ";
            }
            if (nIsLFChecked == (int)Dictionary.YesOrNoStatus.NO)
            {
                sSql += " and a.LastFeedbackDate between '" + dtLFFromDate + "' and '" + dtLFToDate + "' and a.LastFeedbackDate < '" + dtLFToDate + "' ";
            }
            if (nCheckAll == 0)
            {
                sSql = sSql + " and NextFollowUpDate between '" + dtFromDate + "' and '" + dtToDate + "' and NextFollowUpDate < '" + dtToDate + "' ";
            }
            if (nJobID > 0)
            {
                sSql = sSql + " and a.JobID = '" + nJobID + "' ";
            }
            if (sMobileNo != "")
            {
                sSql = sSql + " and MobileNo = '" + sMobileNo + "' ";
            }
            if (sBarcodeSerialNo != "")
            {
                sSql = sSql + " and ProductSerialNo = '" + sBarcodeSerialNo + "' ";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProactiveCall oCSDProductiveCallList = new ProactiveCall();
                    oCSDProductiveCallList.ID = (int)reader["ID"];
                    oCSDProductiveCallList.JobID = (int)reader["JobID"];
                    oCSDProductiveCallList.JobNo = (string)reader["JobNo"];
                    oCSDProductiveCallList.JobCreateDate = Convert.ToDateTime(reader["JobCreateDate"].ToString());
                    oCSDProductiveCallList.NextFollowUpDate = Convert.ToDateTime(reader["NextFollowUpDate"].ToString());
                    if (reader["ProposeFollowupDate"] != DBNull.Value)
                        oCSDProductiveCallList.ProposeFollowupDate = Convert.ToDateTime(reader["ProposeFollowupDate"].ToString());
                    else oCSDProductiveCallList.ProposeFollowupDate = null;
                    if (reader["LastFeedbackDate"] != DBNull.Value)
                    {
                        oCSDProductiveCallList.LastFeedbackDate = Convert.ToDateTime(reader["LastFeedbackDate"].ToString());
                    }
                    oCSDProductiveCallList.Remarks = (string)reader["Remarks"];
                    oCSDProductiveCallList.LastCommunication = (string)reader["LastCommunication"];
                    oCSDProductiveCallList.UserFullName = (string)reader["UserFullName"];
                    oCSDProductiveCallList.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCSDProductiveCallList.ProductSerialNo = (string)reader["ProductSerialNo"];
                    oCSDProductiveCallList.CustomerName = (string)reader["CustomerName"];
                    oCSDProductiveCallList.MobileNo = (string)reader["MobileNo"];
                    oCSDProductiveCallList.CustomerAddress = (string)reader["CustomerAddress"];
                    oCSDProductiveCallList.Status = (int)reader["Status"];
                    oCSDProductiveCallList.ProductCode = (string)reader["ProductCode"];
                    oCSDProductiveCallList.ProductName = (string)reader["ProductName"];
                   
                    InnerList.Add(oCSDProductiveCallList);
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



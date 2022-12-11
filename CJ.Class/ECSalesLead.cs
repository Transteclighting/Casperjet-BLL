
// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD. Abdul Hakim
// Date: Mar 23, 2015
// Time : 10:38 AM
// Description: Class for SalesLead.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class ECSalesLead
    {
        private int _nSalesLeadID;
        private string _sName;
        private string _sContactNo;
        private string _sDistrict;
        private string _sThana;
        private string _sAddress;
        private string _sEmail;
        private string _sProductModel;
        private string _sBrand;
        private DateTime _dCreateDate;
        private int _nStatus;
        private string _sRemarks;
        private string _sAssignOutlet;
        private int _nAssignSMSID;
        private int _nCreateUserID;
        private int _nIsWebRequest;
        private int _nWebDataID;


        // <summary>
        // Get set property for SalesLeadID
        // </summary>
        public int SalesLeadID
        {
            get { return _nSalesLeadID; }
            set { _nSalesLeadID = value; }
        }

        // <summary>
        // Get set property for Name
        // </summary>
        public string Name
        {
            get { return _sName; }
            set { _sName = value.Trim(); }
        }

        // <summary>
        // Get set property for ContactNo
        // </summary>
        public string ContactNo
        {
            get { return _sContactNo; }
            set { _sContactNo = value.Trim(); }
        }

        // <summary>
        // Get set property for District
        // </summary>
        public string District
        {
            get { return _sDistrict; }
            set { _sDistrict = value.Trim(); }
        }

        // <summary>
        // Get set property for Thana
        // </summary>
        public string Thana
        {
            get { return _sThana; }
            set { _sThana = value.Trim(); }
        }

        // <summary>
        // Get set property for Address
        // </summary>
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value.Trim(); }
        }

        // <summary>
        // Get set property for Email
        // </summary>
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value.Trim(); }
        }

        // <summary>
        // Get set property for ProductModel
        // </summary>
        public string ProductModel
        {
            get { return _sProductModel; }
            set { _sProductModel = value.Trim(); }
        }

        // <summary>
        // Get set property for Brand
        // </summary>
        public string Brand
        {
            get { return _sBrand; }
            set { _sBrand = value.Trim(); }
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
        // Get set property for AssignOutlet
        // </summary>
        public string AssignOutlet
        {
            get { return _sAssignOutlet; }
            set { _sAssignOutlet = value.Trim(); }
        }

        // <summary>
        // Get set property for AssignSMSID
        // </summary>
        public int AssignSMSID
        {
            get { return _nAssignSMSID; }
            set { _nAssignSMSID = value; }
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
        // Get set property for IsWebRequest
        // </summary>
        public int IsWebRequest
        {
            get { return _nIsWebRequest; }
            set { _nIsWebRequest = value; }
        }

        // <summary>
        // Get set property for WebDataID
        // </summary>
        public int WebDataID
        {
            get { return _nWebDataID; }
            set { _nWebDataID = value; }
        }

        private int _nUpdateUserID;
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }
        private DateTime _dUpdateDate;
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }
        private string _sStatusRemarks;
        public string StatusRemarks
        {
            get { return _sStatusRemarks; }
            set { _sStatusRemarks = value; }
        }
        private string _sInvoiceNo;
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { _sInvoiceNo = value; }
        }

        private int _nIsHappyCall;
        public int IsHappyCall
        {
            get { return _nIsHappyCall; }
            set { _nIsHappyCall = value; }
        }
        private int _nHappyCallStatus;
        public int HappyCallStatus
        {
            get { return _nHappyCallStatus; }
            set { _nHappyCallStatus = value; }
        }
        private string _sHappyCallComment;
        public string HappyCallComment
        {
            get { return _sHappyCallComment; }
            set { _sHappyCallComment = value; }
        }

        public void Add()
        {
            int nMaxSalesLeadID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([SalesLeadID]) FROM t_SalesLead";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSalesLeadID = 1;
                }
                else
                {
                    nMaxSalesLeadID = Convert.ToInt32(maxID) + 1;
                }
                _nSalesLeadID = nMaxSalesLeadID;
                sSql = "INSERT INTO t_SalesLead (SalesLeadID, Name, ContactNo, District, Thana, Address, Email, ProductModel, Brand, CreateDate, Status, Remarks, AssignOutlet, AssignSMSID, CreateUserID, IsWebRequest, WebDataID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("SalesLeadID", _nSalesLeadID);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("District", _sDistrict);
                cmd.Parameters.AddWithValue("Thana", _sThana);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("ProductModel", _sProductModel);
                cmd.Parameters.AddWithValue("Brand", _sBrand);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                if (_sAssignOutlet != "")
                    cmd.Parameters.AddWithValue("AssignOutlet", _sAssignOutlet);
                else cmd.Parameters.AddWithValue("AssignOutlet", null);
                if (_nAssignSMSID != 0)
                    cmd.Parameters.AddWithValue("AssignSMSID", _nAssignSMSID);
                else cmd.Parameters.AddWithValue("AssignSMSID", null);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("IsWebRequest", _nIsWebRequest);
                if (_nWebDataID != 0)
                    cmd.Parameters.AddWithValue("WebDataID", _nWebDataID);
                else cmd.Parameters.AddWithValue("WebDataID", null);

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
                sSql = "UPDATE t_SalesLead SET Name = ?, ContactNo = ?, Address = ?, Email = ?, ProductModel = ?, Remarks = ?, IsWebRequest = ?, WebDataID = ?, UpdateUserID=?, UpdateDate=?,District=?,Thana=?,Brand=? WHERE SalesLeadID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("ContactNo", _sContactNo);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("ProductModel", _sProductModel);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("IsWebRequest", _nIsWebRequest);
                if (_nWebDataID != 0)
                    cmd.Parameters.AddWithValue("WebDataID", _nWebDataID);
                else cmd.Parameters.AddWithValue("WebDataID", null);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("District", _sDistrict);
                cmd.Parameters.AddWithValue("Thana", _sThana);
                cmd.Parameters.AddWithValue("Brand", _sBrand);

                cmd.Parameters.AddWithValue("SalesLeadID", _nSalesLeadID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void StatusUpdate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesLead SET Status = ?, StatusRemarks = ?, InvoiceNo = ? WHERE SalesLeadID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("StatusRemarks", _sStatusRemarks);
                cmd.Parameters.AddWithValue("InvoiceNo", _sInvoiceNo);

                cmd.Parameters.AddWithValue("SalesLeadID", _nSalesLeadID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateAssignSMSID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesLead SET AssignSMSID = ? WHERE SalesLeadID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AssignSMSID", _nAssignSMSID);

                cmd.Parameters.AddWithValue("SalesLeadID", _nSalesLeadID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Assign()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesLead SET Status = ?, AssignOutlet = ?, StatusRemarks=? WHERE SalesLeadID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("AssignOutlet", _sAssignOutlet);
                cmd.Parameters.AddWithValue("StatusRemarks", _sStatusRemarks);

                cmd.Parameters.AddWithValue("SalesLeadID", _nSalesLeadID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void HappyCall()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_SalesLead SET IsHappyCall = ?, HappyCallStatus = ?, HappyCallComment=? WHERE SalesLeadID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsHappyCall", _nIsHappyCall);
                cmd.Parameters.AddWithValue("HappyCallStatus", _nHappyCallStatus);
                cmd.Parameters.AddWithValue("HappyCallComment", _sHappyCallComment);

                cmd.Parameters.AddWithValue("SalesLeadID", _nSalesLeadID);

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
                sSql = "DELETE FROM t_SalesLead WHERE [SalesLeadID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("SalesLeadID", _nSalesLeadID);
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
                cmd.CommandText = "SELECT * FROM t_SalesLead where SalesLeadID =?";
                cmd.Parameters.AddWithValue("SalesLeadID", _nSalesLeadID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nSalesLeadID = (int)reader["SalesLeadID"];
                    _sName = (string)reader["Name"];
                    _sContactNo = (string)reader["ContactNo"];
                    _sDistrict = (string)reader["District"];
                    _sThana = (string)reader["Thana"];
                    _sAddress = (string)reader["Address"];
                    _sEmail = (string)reader["Email"];
                    _sProductModel = (string)reader["ProductModel"];
                    _sBrand = (string)reader["Brand"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nStatus = (int)reader["Status"];
                    _sRemarks = (string)reader["Remarks"];
                    _sAssignOutlet = (string)reader["AssignOutlet"];
                    _nAssignSMSID = (int)reader["AssignSMSID"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _nIsWebRequest = (int)reader["IsWebRequest"];
                    _nWebDataID = (int)reader["WebDataID"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckWebID()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesLead where WebDataID =?";
                cmd.Parameters.AddWithValue("SalesLeadID", _nWebDataID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
                return true;
            else return false;
        }
    }
    public class ECSalesLeads : CollectionBase
    {
        public ECSalesLead this[int i]
        {
            get { return (ECSalesLead)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ECSalesLead oECSalesLead)
        {
            InnerList.Add(oECSalesLead);
        }
        public int GetIndex(int nECSalesLeadID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].SalesLeadID == nECSalesLeadID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate, string sSalesLeadID, string sName, string sContact, int nStatus, bool IsCheck)
        {
            InnerList.Clear();
            dToDate = dToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "SELECT * FROM t_SalesLead where 1=1 ";

            if (IsCheck == false)
            {
                sSql = sSql + " and CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate < '" + dToDate + "' ";
            }
            if (sSalesLeadID != "")
            {
                sSql = sSql + " and SalesLeadID = " + sSalesLeadID + "";
            }
            if (sName != "")
            {
                sSql = sSql + " and Name like '%" + sName + "%'";
            }
            if (sContact != "")
            {
                sSql = sSql + " and ContactNo like '%" + sContact + "%'";
            }
            if (nStatus >= 0)
            {
                sSql = sSql + " and Status = " + nStatus + "";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ECSalesLead oSalesLead = new ECSalesLead();

                    oSalesLead.SalesLeadID = (int)reader["SalesLeadID"];
                    oSalesLead.Name = (string)reader["Name"];
                    oSalesLead.ContactNo = (string)reader["ContactNo"];
                    oSalesLead.District = (string)reader["District"];
                    oSalesLead.Thana = (string)reader["Thana"];
                    oSalesLead.Address = (string)reader["Address"];
                    oSalesLead.Email = (string)reader["Email"];
                    oSalesLead.ProductModel = (string)reader["ProductModel"];
                    oSalesLead.Brand = (string)reader["Brand"];
                    oSalesLead.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSalesLead.Status = (int)reader["Status"];
                    if (reader["Remarks"] != DBNull.Value)
                        oSalesLead.Remarks = (string)reader["Remarks"];
                    else oSalesLead.Remarks = "";
                    if (reader["AssignOutlet"] != DBNull.Value)
                        oSalesLead.AssignOutlet = (string)reader["AssignOutlet"];
                    else oSalesLead.AssignOutlet = "";
                    if (reader["AssignSMSID"] != DBNull.Value)
                        oSalesLead.AssignSMSID = (int)reader["AssignSMSID"];
                    else oSalesLead.AssignSMSID = 0;
                    if (reader["CreateUserID"] != DBNull.Value)
                        oSalesLead.CreateUserID = (int)reader["CreateUserID"];
                    else oSalesLead.CreateUserID = 0;
                    oSalesLead.IsWebRequest = (int)reader["IsWebRequest"];
                    if (reader["WebDataID"] != DBNull.Value)
                        oSalesLead.WebDataID = (int)reader["WebDataID"];
                    else oSalesLead.WebDataID = 0;
                    if (reader["IsHappyCall"] != DBNull.Value)
                        oSalesLead.IsHappyCall = (int)reader["IsHappyCall"];
                    else oSalesLead.IsHappyCall = 0;

                    InnerList.Add(oSalesLead);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_SalesLead";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ECSalesLead oSalesLead = new ECSalesLead();

                    oSalesLead.SalesLeadID = (int)reader["SalesLeadID"];
                    oSalesLead.Name = (string)reader["Name"];
                    oSalesLead.ContactNo = (string)reader["ContactNo"];
                    oSalesLead.District = (string)reader["District"];
                    oSalesLead.Thana = (string)reader["Thana"];
                    oSalesLead.Address = (string)reader["Address"];
                    oSalesLead.Email = (string)reader["Email"];
                    oSalesLead.ProductModel = (string)reader["ProductModel"];
                    oSalesLead.Brand = (string)reader["Brand"];
                    oSalesLead.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oSalesLead.Status = (int)reader["Status"];
                    oSalesLead.Remarks = (string)reader["Remarks"];
                    oSalesLead.AssignOutlet = (string)reader["AssignOutlet"];
                    oSalesLead.AssignSMSID = (int)reader["AssignSMSID"];
                    oSalesLead.CreateUserID = (int)reader["CreateUserID"];
                    oSalesLead.IsWebRequest = (int)reader["IsWebRequest"];
                    oSalesLead.WebDataID = (int)reader["WebDataID"];
                    InnerList.Add(oSalesLead);
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



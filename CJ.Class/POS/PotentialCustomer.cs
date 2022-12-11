// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Jan 05, 2016
// Time : 11:48 AM
// Description: Class for PotentialCustomer.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Class
{
    public class PotentialCustomer
    {
        SystemInfo oSystemInfo;
        private int _nID;
        private int _nOutlet;
        private string _sCompanyName;
        private string _sName;
        private DateTime _dVisitDate;
        private string _sDesignation;
        private string _sMobileNo;
        private string _sTelephoneNo;
        private string _sAddress;
        private string _sEmail;
        private string _sRemarks;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private object _dUpdateDate;
        private int _nUpdateUserID;
        private int _nStatus;
        private string _sMAGName;
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value.Trim(); }
        }
        private DateTime _dtNextFollowupDate;
        public DateTime NextFollowupDate
        {
            get { return _dtNextFollowupDate; }
            set { _dtNextFollowupDate = value; }
        }

        private int _nOutboundCallID;
        public int OutboundCallID
        {
            get { return _nOutboundCallID; }
            set { _nOutboundCallID = value; }
        }
        private int _nHistoryID;
        public int HistoryID
        {
            get { return _nHistoryID; }
            set { _nHistoryID = value; }
        }
        private string _sShowroomCode;
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value.Trim(); }
        }

        private string _sTranNo;
        public string TranNo
        {
            get { return _sTranNo; }
            set { _sTranNo = value.Trim(); }
        }
        private string _sProductCode;
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value.Trim(); }
        }
        private string _sProductName;
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value.Trim(); }
        }

        private int _Qty;
        public int Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        private double _Value;
        public double Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        private int _nSource;
        public int Source
        {
            get { return _nSource; }
            set { _nSource = value; }
        }
        private int _nIsCall;
        public int IsCall
        {
            get { return _nIsCall; }
            set { _nIsCall = value; }
        }

        private int _nMAGID;
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
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
        // Get set property for Outlet
        // </summary>
        public int Outlet
        {
            get { return _nOutlet; }
            set { _nOutlet = value; }
        }

        // <summary>
        // Get set property for CompanyName
        // </summary>
        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value.Trim(); }
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
        // Get set property for VisitDate
        // </summary>
        public DateTime VisitDate
        {
            get { return _dVisitDate; }
            set { _dVisitDate = value; }
        }

        // <summary>
        // Get set property for Designation
        // </summary>
        public string Designation
        {
            get { return _sDesignation; }
            set { _sDesignation = value.Trim(); }
        }

        // <summary>
        // Get set property for MobileNo
        // </summary>
        public string MobileNo
        {
            get { return _sMobileNo; }
            set { _sMobileNo = value.Trim(); }
        }

        // <summary>
        // Get set property for TelephoneNo
        // </summary>
        public string TelephoneNo
        {
            get { return _sTelephoneNo; }
            set { _sTelephoneNo = value.Trim(); }
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
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }
        private string _sLeadNo;
        public string LeadNo
        {
            get { return _sLeadNo; }
            set { _sLeadNo = value.Trim(); }
        }
        private int _nLeadStatus;
        public int LeadStatus
        {
            get { return _nLeadStatus; }
            set { _nLeadStatus = value; }
        }
        private object _dtLeadDate;
        public object LeadDate
        {
            get { return _dtLeadDate; }
            set { _dtLeadDate = value; }
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
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
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
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_PotentialCustomerList";
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
                sSql = "INSERT INTO t_PotentialCustomerList (ID, Outlet, CompanyName, Name, VisitDate, Designation, MobileNo, TelephoneNo, Address, Email, Remarks, CreateDate, CreateUserID, UpdateDate, UpdateUserID, Status) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("Outlet", _nOutlet);

                if (_sCompanyName != "")
                {
                    cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CompanyName", null);
                }
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("VisitDate", _dVisitDate);

                if (_sDesignation != "")
                {
                    cmd.Parameters.AddWithValue("Designation", _sDesignation);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Designation", null);
                }
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                if (_sTelephoneNo != "")
                {
                    cmd.Parameters.AddWithValue("TelephoneNo", _sTelephoneNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("TelephoneNo", null);
                }

                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                oSystemInfo = new SystemInfo();
                oSystemInfo.Refresh();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_PotentialCustomerList";
                oDataTran.DataID = Convert.ToInt32(_nID);
                oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;
                if (oDataTran.CheckData() == false)
                {
                    oDataTran.AddForTDPOS();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddforRT()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_PotentialCustomerList where Outlet=" + Utility.WarehouseID + "";
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
                sSql = "INSERT INTO t_PotentialCustomerList (ID, Outlet, CompanyName, Name, VisitDate, Designation, MobileNo, TelephoneNo, Address, Email, Remarks, CreateDate, CreateUserID, UpdateDate, UpdateUserID, Status) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("Outlet", _nOutlet);

                if (_sCompanyName != "")
                {
                    cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CompanyName", null);
                }
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("VisitDate", _dVisitDate);

                if (_sDesignation != "")
                {
                    cmd.Parameters.AddWithValue("Designation", _sDesignation);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Designation", null);
                }
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                if (_sTelephoneNo != "")
                {
                    cmd.Parameters.AddWithValue("TelephoneNo", _sTelephoneNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("TelephoneNo", null);
                }

                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void InsertForWeb()
        {
            //int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                //sSql = "SELECT MAX([ID]) FROM t_PotentialCustomerList where Outlet = " + _nOutlet + "";
                //cmd.CommandText = sSql;
                //object maxID = cmd.ExecuteScalar();
                //if (maxID == DBNull.Value)
                //{
                //    nMaxID = 1;
                //}
                //else
                //{
                //    nMaxID = Convert.ToInt32(maxID) + 1;
                //}
                //_nID = nMaxID;

                sSql = "INSERT INTO t_PotentialCustomerList (ID, Outlet, CompanyName, Name, VisitDate, Designation, MobileNo, TelephoneNo, Address, Email, Remarks, CreateDate, CreateUserID, UpdateDate, UpdateUserID, Status,LeadNo,LeadDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("Outlet", _nOutlet);
                cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("VisitDate", _dVisitDate);
                cmd.Parameters.AddWithValue("Designation", _sDesignation);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("TelephoneNo", _sTelephoneNo);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                if (_dUpdateDate != null)
                {
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                }

                else
                {
                    cmd.Parameters.AddWithValue("UpdateDate", null);
                    cmd.Parameters.AddWithValue("UpdateUserID", null);
                }
                
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);
                if (_dtLeadDate != null)
                {
                    cmd.Parameters.AddWithValue("LeadDate", _dtLeadDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("LeadDate", null);
                }
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
                sSql = "UPDATE t_PotentialCustomerList SET  CompanyName = ?, Name = ?, VisitDate = ?, Designation = ?, MobileNo = ?, TelephoneNo = ?, Address = ?, Email = ?, Remarks = ?,  UpdateDate = ?, UpdateUserID = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("VisitDate", _dVisitDate);
                cmd.Parameters.AddWithValue("Designation", _sDesignation);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("TelephoneNo", _sTelephoneNo);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                oSystemInfo = new SystemInfo();
                oSystemInfo.Refresh();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_PotentialCustomerList";
                oDataTran.DataID = Convert.ToInt32(_nID);
                oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;

                if (oDataTran.CheckData() == false)
                {
                    oDataTran.AddForTDPOS();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditforRT()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PotentialCustomerList SET  CompanyName = ?, Name = ?, VisitDate = ?, Designation = ?, MobileNo = ?, TelephoneNo = ?, Address = ?, Email = ?, Remarks = ?,  UpdateDate = ?, UpdateUserID = ? WHERE ID = ? and Outlet=" + Utility.WarehouseID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("VisitDate", _dVisitDate);
                cmd.Parameters.AddWithValue("Designation", _sDesignation);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("TelephoneNo", _sTelephoneNo);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Update()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PotentialCustomerList SET  CompanyName = ?, Name = ?, VisitDate = ?, Designation = ?, " +
                       "MobileNo = ?, TelephoneNo = ?, Address = ?, Email = ?, Remarks = ?,  UpdateDate = ?, UpdateUserID = ?,LeadNo = ?, LeadDate = ? WHERE ID = ? and Outlet = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("VisitDate", _dVisitDate);
                cmd.Parameters.AddWithValue("Designation", _sDesignation);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("TelephoneNo", _sTelephoneNo);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                if (_dUpdateDate != null)
                {
                    cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                    cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("UpdateDate", null);
                    cmd.Parameters.AddWithValue("UpdateUserID", null);
                }
               

                cmd.Parameters.AddWithValue("LeadNo", _sLeadNo);
                if (_dtLeadDate != null)
                    cmd.Parameters.AddWithValue("LeadDate", _dtLeadDate);
                else cmd.Parameters.AddWithValue("LeadDate", null);


                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("Outlet", _nOutlet);

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
                sSql = "DELETE FROM t_PotentialCustomerList WHERE [ID]=?";
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
                cmd.CommandText = "SELECT * FROM t_PotentialCustomerList where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nOutlet = (int)reader["Outlet"];
                    _sCompanyName = (string)reader["CompanyName"];
                    _sName = (string)reader["Name"];
                    _dVisitDate = Convert.ToDateTime(reader["VisitDate"].ToString());
                    _sDesignation = (string)reader["Designation"];
                    _sMobileNo = (string)reader["MobileNo"];
                    _sTelephoneNo = (string)reader["TelephoneNo"];
                    _sAddress = (string)reader["Address"];
                    _sEmail = (string)reader["Email"];
                    _sRemarks = (string)reader["Remarks"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _nStatus = (int)reader["Status"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddOutboundCall()
        {
            int nMaxOutboundCallID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([OutboundCallID]) FROM t_OutboundCall";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxOutboundCallID = 1;
                }
                else
                {
                    nMaxOutboundCallID = Convert.ToInt32(maxID) + 1;
                }
                _nOutboundCallID = nMaxOutboundCallID;
                sSql = "INSERT INTO t_OutboundCall (OutboundCallID, CustomerName, Address, MobileNo, Email, NextFollowUpDate, Status, Remarks, CreateDate, CreateUserID, UpdateDate, UpdateUserID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OutboundCallID", _nOutboundCallID);
                cmd.Parameters.AddWithValue("CustomerName", _sName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("NextFollowUpDate", _dtNextFollowupDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateOutboundStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OutboundCall SET  Status = ?,  UpdateDate = ?, UpdateUserID = ? WHERE OutboundCallID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("OutboundCallID", _nOutboundCallID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateOutboundCall()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_OutboundCall SET CustomerName = ?,Address = ?, Email = ?, NextFollowupDate = ?, Remarks =?, Status = ?,  UpdateDate = ?, UpdateUserID = ? WHERE OutboundCallID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("CustomerName", _sName);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("NextFollowUpdate", _dtNextFollowupDate);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("OutboundCallID", _nOutboundCallID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddFromHO()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_PotentialCustomerList";
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
                sSql = "INSERT INTO t_PotentialCustomerList (ID, Outlet, CompanyName, Name, VisitDate, Designation, MobileNo, TelephoneNo, Address, Email, Remarks, CreateDate, CreateUserID, UpdateDate, UpdateUserID, Status, CustType, MAGID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("Outlet", _nOutlet);

                if (_sCompanyName != "")
                {
                    cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("CompanyName", null);
                }
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("VisitDate", _dVisitDate);

                if (_sDesignation != "")
                {
                    cmd.Parameters.AddWithValue("Designation", _sDesignation);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Designation", null);
                }
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                if (_sTelephoneNo != "")
                {
                    cmd.Parameters.AddWithValue("TelephoneNo", _sTelephoneNo);
                }
                else
                {
                    cmd.Parameters.AddWithValue("TelephoneNo", null);
                }

                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("CustType", _nSource);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditFromHO()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_PotentialCustomerList SET  CompanyName = ?, Name = ?, VisitDate = ?, Designation = ?, MobileNo = ?, TelephoneNo = ?, Address = ?, Email = ?, Remarks = ?,  UpdateDate = ?, UpdateUserID = ?, CustType = ?, MAGID = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CompanyName", _sCompanyName);
                cmd.Parameters.AddWithValue("Name", _sName);
                cmd.Parameters.AddWithValue("VisitDate", _dVisitDate);
                cmd.Parameters.AddWithValue("Designation", _sDesignation);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("TelephoneNo", _sTelephoneNo);
                cmd.Parameters.AddWithValue("Address", _sAddress);
                cmd.Parameters.AddWithValue("Email", _sEmail);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("CustType", _nSource);
                cmd.Parameters.AddWithValue("MAGID", _nMAGID);
                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddOutboundCallHistory()
        {
            int nMaxHistoryID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([HistoryID]) FROM t_OutboundCallHistory";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxHistoryID = 1;
                }
                else
                {
                    nMaxHistoryID = Convert.ToInt32(maxID) + 1;
                }
                _nHistoryID = nMaxHistoryID;
                sSql = "INSERT INTO t_OutboundCallHistory (HistoryID, OutboundCallID, MobileNo, CreateDate, Remarks, Status) VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("HistoryID", _nHistoryID);
                cmd.Parameters.AddWithValue("OutboundCallID", _nOutboundCallID);
                cmd.Parameters.AddWithValue("MobileNo", _sMobileNo);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class PotentialCustomers : CollectionBase
    {
        public PotentialCustomer this[int i]
        {
            get { return (PotentialCustomer)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(PotentialCustomer oPotentialCustomer)
        {
            InnerList.Add(oPotentialCustomer);
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

        public void GetTransactionalHistory(string sMobileNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select isnull(ShowroomCode,'') ShowroomCode,isnull(CustomerName,'') CustomerName, " +
                                "isnull(Address,'') Address,isnull(MobileNo,'') MobileNo, " +
                                "isnull(TelephoneNo,'') TelephoneNo,isnull(Email,'') Email, " +
                                "isnull(TranNo,'') TranNo,TranDate,isnull(ProductName,'') ProductName, " +
                                "isnull(ProductCode,'') ProductCode,isnull(Qty,0) Qty,isnull(Value,0) Value, " +
                                "Source From  " +
                                "( " +
                                "Select ShowroomCode,Name as CustomerName,Address,MobileNo, " +
                                "TelephoneNo,Email,'' as TranNo,VisitDate as TranDate,'' ProductName,'' ProductCode, " +
                                "0 Qty,0 Value, " +
                                "isnull(CustType,1) Source From  " +
                                "(Select * From TELSYSDB.DBO.t_PotentialCustomerList) x " +
                                "Left Outer Join  " +
                                "(Select * From  " +
                                "(Select WarehouseID,ShowroomCode From t_Showroom " +
                                "Union All " +
                                "Select -1,'HO') a) y " +
                                "on x.Outlet=y.WarehouseID " +
                                "Union All " +
                                "Select WHCode as ShowroomCode,CustomerName,Address,MobileNo, " +
                                "PhoneNo,Email,TranNo,TranDate,ProductName,ProductCode,isnull(Qty,0) Qty,isnull(Value,0) Value, " +
                                "Source=Case when Trantype='Sales' then 6 " +
                                "else 7 end " +
                                "From DWDB.dbo.t_RetailCustomerTran  " +
                                ") x where 1=1 and MobileNo='" + sMobileNo + "'";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PotentialCustomer oItem = new PotentialCustomer();

                    oItem.ShowroomCode = (reader["ShowroomCode"].ToString());
                    oItem.Name = (reader["CustomerName"].ToString());
                    oItem.Address = (reader["Address"].ToString());
                    oItem.MobileNo = (reader["MobileNo"].ToString());
                    oItem.TelephoneNo = (reader["TelephoneNo"].ToString());
                    oItem.Email = (reader["Email"].ToString());
                    oItem.TranNo = (reader["TranNo"].ToString());
                    oItem.CreateDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    oItem.ProductName = (reader["ProductName"].ToString());
                    oItem.ProductCode = (reader["ProductCode"].ToString());
                    oItem.Qty = Convert.ToInt32(reader["Qty"].ToString());
                    oItem.Value = Convert.ToDouble(reader["Value"].ToString());
                    oItem.Source = Convert.ToInt32(reader["Source"].ToString());

                    InnerList.Add(oItem);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetCallHistory(string sMobileNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select * From dbo.t_OutboundCallHistory where MobileNo='" + sMobileNo + "'";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PotentialCustomer oItem = new PotentialCustomer();

                    oItem.HistoryID = Convert.ToInt32(reader["HistoryID"].ToString());
                    oItem.OutboundCallID = Convert.ToInt32(reader["OutboundCallID"].ToString());
                    oItem.MobileNo = (reader["MobileNo"].ToString());
                    oItem.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oItem.Remarks = (reader["Remarks"].ToString());
                    oItem.Status = Convert.ToInt32(reader["Status"].ToString());

                    InnerList.Add(oItem);
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
            string sSql = "SELECT * FROM t_PotentialCustomerList";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PotentialCustomer oPotentialCustomer = new PotentialCustomer();
                    oPotentialCustomer.ID = (int)reader["ID"];
                    oPotentialCustomer.Outlet = (int)reader["Outlet"];
                    oPotentialCustomer.CompanyName = (string)reader["CompanyName"];
                    oPotentialCustomer.Name = (string)reader["Name"];
                    oPotentialCustomer.VisitDate = Convert.ToDateTime(reader["VisitDate"].ToString());
                    oPotentialCustomer.Designation = (string)reader["Designation"];
                    oPotentialCustomer.MobileNo = (string)reader["MobileNo"];
                    oPotentialCustomer.TelephoneNo = (string)reader["TelephoneNo"];
                    oPotentialCustomer.Address = (string)reader["Address"];
                    oPotentialCustomer.Email = (string)reader["Email"];
                    oPotentialCustomer.Remarks = (string)reader["Remarks"];
                    oPotentialCustomer.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPotentialCustomer.CreateUserID = (int)reader["CreateUserID"];
                    oPotentialCustomer.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oPotentialCustomer.UpdateUserID = (int)reader["UpdateUserID"];
                    oPotentialCustomer.Status = (int)reader["Status"];
                    InnerList.Add(oPotentialCustomer);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate, int nStatus, string sCompany, string sName, string sContact, string sTelephoneNo, bool IsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";
            {
                sSql = "SELECT a.*,isnull(b.Status,-1)  as LeadStatus FROM t_PotentialCustomerList a " +
                       "left outer join " +
                       "t_SalesLeadManagement b on a.LeadNo = b.LeadNo " +
                       "where 1 = 1";

            }
            if (IsCheck == false)
            {
                sSql = sSql + " and VisitDate between '" + dFromDate + "' and '" + dToDate + "' and VisitDate<'" + dToDate + "' ";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND a.Status=" + nStatus + "";
            }
            if (sCompany != "")
            {
                sSql = sSql + " AND CompanyName like '%" + sCompany + "%'";
            }
            if (sName != "")
            {
                sSql = sSql + " AND Name like '%" + sName + "%'";
            }
            if (sContact != "")
            {
                sSql = sSql + " AND MobileNo like '%" + sContact + "%'";
            }
            if (sTelephoneNo != "")
            {
                sSql = sSql + " AND TelephoneNo like '%" + sTelephoneNo + "%'";
            }

            sSql = sSql + " Order by ID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PotentialCustomer oPotentialCustomer = new PotentialCustomer();
                    oPotentialCustomer.ID = (int)reader["ID"];
                    oPotentialCustomer.Outlet = (int)reader["Outlet"];

                    if (reader["CompanyName"] != DBNull.Value)
                    {
                        oPotentialCustomer.CompanyName = (string)reader["CompanyName"];
                    }
                    else
                    {
                        oPotentialCustomer.CompanyName = "";
                    }
                    oPotentialCustomer.Name = (string)reader["Name"];
                    oPotentialCustomer.VisitDate = Convert.ToDateTime(reader["VisitDate"].ToString());

                    if (reader["Designation"] != DBNull.Value)
                    {
                        oPotentialCustomer.Designation = (string)reader["Designation"];
                    }
                    else
                    {
                        oPotentialCustomer.Designation = "";
                    }

                    oPotentialCustomer.MobileNo = (string)reader["MobileNo"];
                    if (reader["TelephoneNo"] != DBNull.Value)
                    {
                        oPotentialCustomer.TelephoneNo = (string)reader["TelephoneNo"];
                    }
                    else
                    {
                        oPotentialCustomer.TelephoneNo = "";
                    }

                    oPotentialCustomer.Address = (string)reader["Address"];
                    oPotentialCustomer.Email = (string)reader["Email"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oPotentialCustomer.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oPotentialCustomer.Remarks = "";
                    }
                    oPotentialCustomer.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPotentialCustomer.CreateUserID = (int)reader["CreateUserID"];
                    oPotentialCustomer.Status = (int)reader["Status"];

                    if (reader["LeadNo"] != DBNull.Value)
                    {
                        oPotentialCustomer.LeadNo = (string)reader["LeadNo"];
                    }
                    else
                    {
                        oPotentialCustomer.LeadNo = "";
                    }
                    if (reader["LeadDate"] != DBNull.Value)
                    {
                        oPotentialCustomer.LeadDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    }


                    oPotentialCustomer.LeadStatus = (int)reader["LeadStatus"];
                    InnerList.Add(oPotentialCustomer);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshRT(DateTime dFromDate, DateTime dToDate, int nStatus, string sCompany, string sName, string sContact, string sTelephoneNo, bool IsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";
            {
                sSql = "SELECT a.*,isnull(b.Status,-1)  as LeadStatus FROM t_PotentialCustomerList a " +
                       "left outer join " +
                       "t_SalesLeadManagement b on a.LeadNo = b.LeadNo " +
                       "where a.Outlet=" + Utility.WarehouseID + "";

            }
            if (IsCheck == false)
            {
                sSql = sSql + " and VisitDate between '" + dFromDate + "' and '" + dToDate + "' and VisitDate<'" + dToDate + "' ";
            }
            if (nStatus != -1)
            {
                sSql = sSql + " AND a.Status=" + nStatus + "";
            }
            if (sCompany != "")
            {
                sSql = sSql + " AND CompanyName like '%" + sCompany + "%'";
            }
            if (sName != "")
            {
                sSql = sSql + " AND Name like '%" + sName + "%'";
            }
            if (sContact != "")
            {
                sSql = sSql + " AND MobileNo like '%" + sContact + "%'";
            }
            if (sTelephoneNo != "")
            {
                sSql = sSql + " AND TelephoneNo like '%" + sTelephoneNo + "%'";
            }

            sSql = sSql + " Order by ID";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PotentialCustomer oPotentialCustomer = new PotentialCustomer();
                    oPotentialCustomer.ID = (int)reader["ID"];
                    oPotentialCustomer.Outlet = (int)reader["Outlet"];

                    if (reader["CompanyName"] != DBNull.Value)
                    {
                        oPotentialCustomer.CompanyName = (string)reader["CompanyName"];
                    }
                    else
                    {
                        oPotentialCustomer.CompanyName = "";
                    }
                    oPotentialCustomer.Name = (string)reader["Name"];
                    oPotentialCustomer.VisitDate = Convert.ToDateTime(reader["VisitDate"].ToString());

                    if (reader["Designation"] != DBNull.Value)
                    {
                        oPotentialCustomer.Designation = (string)reader["Designation"];
                    }
                    else
                    {
                        oPotentialCustomer.Designation = "";
                    }

                    oPotentialCustomer.MobileNo = (string)reader["MobileNo"];
                    if (reader["TelephoneNo"] != DBNull.Value)
                    {
                        oPotentialCustomer.TelephoneNo = (string)reader["TelephoneNo"];
                    }
                    else
                    {
                        oPotentialCustomer.TelephoneNo = "";
                    }

                    oPotentialCustomer.Address = (string)reader["Address"];
                    oPotentialCustomer.Email = (string)reader["Email"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oPotentialCustomer.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oPotentialCustomer.Remarks = "";
                    }
                    oPotentialCustomer.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPotentialCustomer.CreateUserID = (int)reader["CreateUserID"];
                    oPotentialCustomer.Status = (int)reader["Status"];

                    if (reader["LeadNo"] != DBNull.Value)
                    {
                        oPotentialCustomer.LeadNo = (string)reader["LeadNo"];
                    }
                    else
                    {
                        oPotentialCustomer.LeadNo = "";
                    }
                    if (reader["LeadDate"] != DBNull.Value)
                    {
                        oPotentialCustomer.LeadDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    }


                    oPotentialCustomer.LeadStatus = (int)reader["LeadStatus"];
                    InnerList.Add(oPotentialCustomer);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetCustomerList(DateTime dFromDate, DateTime dToDate, int nSource, int nIsCall, string sEmail, string sCustomerName, string sMobile, string sTelephoneNo,string sAddress, bool IsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";
            {
                sSql = "Select * From  " +
                    "(  " +
                    "Select ShowroomCode,a.CustomerName,a.Address, " +
                    "MobileNo=Case when a.MobileNo='' then TelephoneNo else a.MobileNo end, " +
                    "TelephoneNo,a.Email,TranNo,TranDate,Qty,Value,Source,IsCall=Case when OutboundCallID is null then 0  " +
                    "else 1 end From   " +
                    "(  " +
                    "Select isnull(ShowroomCode,'') ShowroomCode,isnull(CustomerName,'') CustomerName,  " +
                    "isnull(Address,'') Address,isnull(MobileNo,'') MobileNo,  " +
                    "isnull(TelephoneNo,'') TelephoneNo,isnull(Email,'') Email,  " +
                    "isnull(TranNo,'') TranNo,TranDate,isnull(Qty,0) Qty,isnull(Value,0) Value,  " +
                    "Source From   " +
                    "(  " +
                    "Select ShowroomCode,Name as CustomerName,Address,MobileNo,  " +
                    "TelephoneNo,Email,'' as TranNo,VisitDate as TranDate,  " +
                    "0 Qty,0 Value,  " +
                    "isnull(CustType,1) Source From   " +
                    "(Select * From TELSYSDB.DBO.t_PotentialCustomerList) x  " +
                    "Left Outer Join   " +
                    "(Select * From   " +
                    "(Select WarehouseID,ShowroomCode From t_Showroom  " +
                    "Union All  " +
                    "Select -1,'HO') a) y  " +
                    "on x.Outlet=y.WarehouseID  " +
                    "Union All  " +
                    "Select WHCode as ShowroomCode,CustomerName,Address,MobileNo,  " +
                    "PhoneNo,Email,TranNo,TranDate,sum(isnull(Qty,0)) Qty,sum(isnull(Value,0)) Value,  " +
                    "Source=Case when Trantype='Sales' then 6  " +
                    "else 7 end  " +
                    "From DWDB.dbo.t_RetailCustomerTran  group by WHCode,CustomerName,Address,MobileNo,PhoneNo,Email,TranNo,TranDate,Trantype  " +
                    ") x ) a  " +
                    "Left Outer Join   " +
                    "(Select * From dbo.t_OutboundCall) b  " +
                    "on a.MobileNo=b.MobileNo  " +
                    ") Main where 1=1";

            }
            if (IsCheck == false)
            {
                sSql = sSql + " and TranDate between '" + dFromDate + "' and '" + dToDate + "' and TranDate<'" + dToDate + "' ";
            }

            if (nSource != -1)
            {
                sSql = sSql + " AND Source=" + nSource + "";
            }
            if (nIsCall != -1)
            {
                sSql = sSql + " AND IsCall=" + nIsCall + "";
            }
            if (sEmail != "")
            {
                sSql = sSql + " AND Email like '%" + sEmail + "%'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " AND CustomerName like '%" + sCustomerName + "%'";
            }
            if (sMobile != "")
            {
                sSql = sSql + " AND MobileNo like '%" + sMobile + "%'";
            }
            if (sTelephoneNo != "")
            {
                sSql = sSql + " AND TelephoneNo like '%" + sTelephoneNo + "%'";
            }
            if (sAddress != "")
            {
                sSql = sSql + " AND Address like '%" + sAddress + "%'";
            }

            sSql = sSql + " Order by TranDate Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PotentialCustomer oPotentialCustomer = new PotentialCustomer();

                    oPotentialCustomer.ShowroomCode = (string)reader["ShowroomCode"];
                    oPotentialCustomer.Name = (string)reader["CustomerName"];
                    oPotentialCustomer.Address = (string)reader["Address"];
                    oPotentialCustomer.MobileNo = (string)reader["MobileNo"];
                    oPotentialCustomer.TelephoneNo = (string)reader["TelephoneNo"];
                    oPotentialCustomer.Email = (string)reader["Email"];
                    oPotentialCustomer.TranNo = (string)reader["TranNo"];
                    oPotentialCustomer.CreateDate = Convert.ToDateTime(reader["TranDate"].ToString());
                    //oPotentialCustomer.ProductCode = (string)reader["ProductCode"];
                    //oPotentialCustomer.ProductName = (string)reader["ProductName"];
                    oPotentialCustomer.Qty = Convert.ToInt32(reader["Qty"].ToString());
                    oPotentialCustomer.Value = Convert.ToDouble(reader["Value"].ToString());
                    oPotentialCustomer.Source = (int)reader["Source"];
                    oPotentialCustomer.IsCall = (int)reader["IsCall"];

                    InnerList.Add(oPotentialCustomer);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetFollowUpdata(DateTime dFromDate, DateTime dToDate, int nStatus, string sEmail, string sCustomerName, string sMobile, string sAddress, bool IsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            string sSql = "";
            {
                sSql = "Select OutboundCallID,CustomerName,Address,MobileNo,Email, " +
                       "CreateUserID,CreateDate,NextFollowupDate,Status,isnull(Remarks,'') Remarks from t_OutboundCall where 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and NextFollowupDate between '" + dFromDate + "' and '" + dToDate + "' and NextFollowupDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }

            if (sEmail != "")
            {
                sSql = sSql + " AND Email like '%" + sEmail + "%'";
            }

            if (sCustomerName != "")
            {
                sSql = sSql + " AND CustomerName like '%" + sCustomerName + "%'";
            }

            if (sMobile != "")
            {
                sSql = sSql + " AND MobileNo like '%" + sMobile + "%'";
            }

            if (sAddress != "")
            {
                sSql = sSql + " AND Address like '%" + sAddress + "%'";
            }
            sSql = sSql + " Order by CreateDate Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PotentialCustomer oPotentialCustomer = new PotentialCustomer();

                    oPotentialCustomer.OutboundCallID = (int)reader["OutboundCallID"];
                    oPotentialCustomer.Name = (string)reader["CustomerName"];
                    oPotentialCustomer.Address = (string)reader["Address"];
                    oPotentialCustomer.MobileNo = (string)reader["MobileNo"];
                    oPotentialCustomer.Email = (string)reader["Email"];
                    oPotentialCustomer.CreateUserID = (int)reader["CreateUserID"];
                    oPotentialCustomer.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPotentialCustomer.NextFollowupDate = Convert.ToDateTime(reader["NextFollowupDate"].ToString());
                    oPotentialCustomer.Status = Convert.ToInt32(reader["Status"].ToString());
                    oPotentialCustomer.Remarks = (string)reader["Remarks"];

                    InnerList.Add(oPotentialCustomer);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetHOPotentialCustomer(DateTime dFromDate, DateTime dToDate, string sCustomerName, string sMobile, int nMAGID, int nSource, bool IsCheck)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);
            string sSql = "";
            {
                sSql = "Select ID,Name,VisitDate,isnull(CompanyName,'') CompanyName,isnull(Designation,'') Designation, " +
                    "isnull(MobileNo,'') MobileNo,isnull(TelephoneNo,'') TelephoneNo,isnull(Address,'') Address,  " +
                    "isnull(Email,'') Email,isnull(Remarks,'') Remarks,CreateDate,CreateUserID,Status,MAGID, " +
                    "PdtGroupName as MAGName,CustType as Source From t_PotentialCustomerList a,t_ProductGroup b " +
                    "where a.MAGID=b.PdtGroupID and Outlet=-1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and VisitDate between '" + dFromDate + "' and '" + dToDate + "' and VisitDate<'" + dToDate + "' ";
            }

            if (nMAGID != -1)
            {
                sSql = sSql + " AND MAGID=" + nMAGID + "";
            }
            if (nSource != -1)
            {
                sSql = sSql + " AND CustType=" + nSource + "";
            }

            if (sCustomerName != "")
            {
                sSql = sSql + " AND Name like '%" + sCustomerName + "%'";
            }

            if (sMobile != "")
            {
                sSql = sSql + " AND MobileNo like '%" + sMobile + "%'";
            }

            sSql = sSql + " Order by VisitDate Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PotentialCustomer oPotentialCustomer = new PotentialCustomer();

                    oPotentialCustomer.ID = (int)reader["ID"];
                    oPotentialCustomer.Name = (string)reader["Name"];
                    oPotentialCustomer.Address = (string)reader["Address"];
                    oPotentialCustomer.MobileNo = (string)reader["MobileNo"];
                    oPotentialCustomer.Email = (string)reader["Email"];
                    oPotentialCustomer.CreateUserID = (int)reader["CreateUserID"];
                    oPotentialCustomer.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oPotentialCustomer.VisitDate = Convert.ToDateTime(reader["VisitDate"].ToString());
                    oPotentialCustomer.Source = Convert.ToInt32(reader["Source"].ToString());
                    oPotentialCustomer.MAGID = Convert.ToInt32(reader["MAGID"].ToString());
                    oPotentialCustomer.Status = Convert.ToInt32(reader["Status"].ToString());
                    oPotentialCustomer.MAGName = (string)reader["MAGName"];
                    oPotentialCustomer.CompanyName = (string)reader["CompanyName"];
                    oPotentialCustomer.Designation = (string)reader["Designation"];
                    oPotentialCustomer.TelephoneNo = (string)reader["TelephoneNo"];
                    oPotentialCustomer.Remarks = (string)reader["Remarks"];

                    InnerList.Add(oPotentialCustomer);
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


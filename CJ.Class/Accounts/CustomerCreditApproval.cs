// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD. Abdul Hakim
// Date: Nov 03, 2015
// Time : 04:13 PM
// Description: Class for CustomerCreditApproval.
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
    public class CustomerCreditApproval
    {
        private int _nID;
        private int _nCreditApprovalID;
        private int _nWarehouseID;
        private int _nCustomerID;
        private string _sApprovalNo;
        private string _sProductOrService;
        private int _nCreditPeriod;
        private double _CreditAmount;
        private double _InvoicedAmount;
        private double _CollectedAmount;
        private string _sRemarks;
        private string _sAttachment;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        private double _TotalCreditAmount;
        private double _TotalOverDueAmount;
        private double _MaxOverDueDays;
        private string _sCompany;

        public string Company
        {
            get { return _sCompany; }
            set { _sCompany = value.Trim(); }
        }


        public double TotalCreditAmount
        {
            get { return _TotalCreditAmount; }
            set { _TotalCreditAmount = value; }
        }
        public double TotalOverDueAmount
        {
            get { return _TotalOverDueAmount; }
            set { _TotalOverDueAmount = value; }
        }
        public double MaxOverDueDays
        {
            get { return _MaxOverDueDays; }
            set { _MaxOverDueDays = value; }
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
        // Get set property for CreditApprovalID
        // </summary>
        public int CreditApprovalID
        {
            get { return _nCreditApprovalID; }
            set { _nCreditApprovalID = value; }
        }

        // <summary>
        // Get set property for WarehouseID
        // </summary>
        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }

        // <summary>
        // Get set property for CustomerID
        // </summary>
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }

        // <summary>
        // Get set property for ApprovalNo
        // </summary>
        public string ApprovalNo
        {
            get { return _sApprovalNo; }
            set { _sApprovalNo = value.Trim(); }
        }

        // <summary>
        // Get set property for ProductOrService
        // </summary>
        public string ProductOrService
        {
            get { return _sProductOrService; }
            set { _sProductOrService = value.Trim(); }
        }

        // <summary>
        // Get set property for CreditPeriod
        // </summary>
        public int CreditPeriod
        {
            get { return _nCreditPeriod; }
            set { _nCreditPeriod = value; }
        }

        // <summary>
        // Get set property for CreditAmount
        // </summary>
        public double CreditAmount
        {
            get { return _CreditAmount; }
            set { _CreditAmount = value; }
        }

        // <summary>
        // Get set property for InvoicedAmount
        // </summary>
        public double InvoicedAmount
        {
            get { return _InvoicedAmount; }
            set { _InvoicedAmount = value; }
        }

        // <summary>
        // Get set property for CollectedAmount
        // </summary>
        public double CollectedAmount
        {
            get { return _CollectedAmount; }
            set { _CollectedAmount = value; }
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
        // Get set property for Attachment
        // </summary>
        public string Attachment
        {
            get { return _sAttachment; }
            set { _sAttachment = value.Trim(); }
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
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        private string _sWarehouseCode;
        public string WarehouseCode
        {
            get { return _sWarehouseCode; }
            set { _sWarehouseCode = value; }
        }
        private string _sCustomerCode;
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }
        private string _sCustomerName;
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }

        private int _nConsumerID;
        public int ConsumerID
        {
            get { return _nConsumerID; }
            set { _nConsumerID = value; }
        }


        private int _nSalesType;
        public int SalesType
        {
            get { return _nSalesType; }
            set { _nSalesType = value; }
        }


        private string _sConsumerCode;
        public string ConsumerCode
        {
            get { return _sConsumerCode; }
            set { _sConsumerCode = value; }
        }
        private int _nStatus;
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }
        private int _nStatusUpdateUserID;
        public int StatusUpdateUserID
        {
            get { return _nStatusUpdateUserID; }
            set { _nStatusUpdateUserID = value; }
        }
        private DateTime _dStatusUpdateDate;
        public DateTime StatusUpdateDate
        {
            get { return _dStatusUpdateDate; }
            set { _dStatusUpdateDate = value; }
        }
        private string _sCustomerAddress;
        public string CustomerAddress
        {
            get { return _sCustomerAddress; }
            set { _sCustomerAddress = value; }
        }
        private string _sCustomerContactNo;
        public string CustomerContactNo
        {
            get { return _sCustomerContactNo; }
            set { _sCustomerContactNo = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            int nMaxCreditApprovalID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CustomerCreditApproval";
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


                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([CreditApprovalID]) FROM t_CustomerCreditApproval Where WarehouseID = " + _nWarehouseID + "";
                cmd.CommandText = sSql;
                object maxAppvID = cmd.ExecuteScalar();
                if (maxAppvID == DBNull.Value)
                {
                    nMaxCreditApprovalID = 1;
                }
                else
                {
                    nMaxCreditApprovalID = Convert.ToInt32(maxAppvID) + 1;
                }
                _nCreditApprovalID = nMaxCreditApprovalID;

                string sApprovalCode = "";
                DateTime dToday = DateTime.Today;
                sApprovalCode = "CA-" + _sWarehouseCode + "-" + dToday.ToString("yy") + _nCreditApprovalID.ToString("000");
                _sApprovalNo = sApprovalCode;

                sSql = "INSERT INTO t_CustomerCreditApproval (ID, CreditApprovalID, WarehouseID, CustomerID, ApprovalNo, " +
                "ProductOrService, CreditPeriod, CreditAmount, InvoicedAmount, CollectedAmount, Remarks, Attachment,  " +
                "CreateUserID, CreateDate, Status) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("CreditApprovalID", _nCreditApprovalID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ApprovalNo", _sApprovalNo);
                cmd.Parameters.AddWithValue("ProductOrService", _sProductOrService);
                cmd.Parameters.AddWithValue("CreditPeriod", _nCreditPeriod);
                cmd.Parameters.AddWithValue("CreditAmount", _CreditAmount);
                cmd.Parameters.AddWithValue("InvoicedAmount", _InvoicedAmount);
                cmd.Parameters.AddWithValue("CollectedAmount", _CollectedAmount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Attachment", _sAttachment);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddNew()
        {
            int nMaxID = 0;
            int nMaxCreditApprovalID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_CustomerCreditApproval";
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


                cmd = DBController.Instance.GetCommand();
                sSql = "SELECT MAX([CreditApprovalID]) FROM t_CustomerCreditApproval Where WarehouseID = " + _nWarehouseID + "";
                cmd.CommandText = sSql;
                object maxAppvID = cmd.ExecuteScalar();
                if (maxAppvID == DBNull.Value)
                {
                    nMaxCreditApprovalID = 1;
                }
                else
                {
                    nMaxCreditApprovalID = Convert.ToInt32(maxAppvID) + 1;
                }
                _nCreditApprovalID = nMaxCreditApprovalID;

                string sApprovalCode = "";
                DateTime dToday = DateTime.Today;
                sApprovalCode = "CA-" + _sWarehouseCode + "-" + dToday.ToString("yy") + _nCreditApprovalID.ToString("000");
                _sApprovalNo = sApprovalCode;

                sSql = "INSERT INTO t_CustomerCreditApproval (ID, CreditApprovalID, WarehouseID, CustomerID, ApprovalNo, " +
                "ProductOrService, CreditPeriod, CreditAmount, InvoicedAmount, CollectedAmount, Remarks, Attachment,  " +
                "CreateUserID, CreateDate, Status, ConsumerID,SalesType ) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("CreditApprovalID", _nCreditApprovalID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ApprovalNo", _sApprovalNo);
                cmd.Parameters.AddWithValue("ProductOrService", _sProductOrService);
                cmd.Parameters.AddWithValue("CreditPeriod", _nCreditPeriod);
                cmd.Parameters.AddWithValue("CreditAmount", _CreditAmount);
                cmd.Parameters.AddWithValue("InvoicedAmount", _InvoicedAmount);
                cmd.Parameters.AddWithValue("CollectedAmount", _CollectedAmount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Attachment", _sAttachment);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);

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
                sSql = "UPDATE t_CustomerCreditApproval SET CustomerID = ?, ProductOrService = ?, CreditPeriod = ?, " +
                "CreditAmount = ?, Remarks = ?, Attachment = ?, UpdateUserID = ?, UpdateDate = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ProductOrService", _sProductOrService);
                cmd.Parameters.AddWithValue("CreditPeriod", _nCreditPeriod);
                cmd.Parameters.AddWithValue("CreditAmount", _CreditAmount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Attachment", _sAttachment);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditNew()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CustomerCreditApproval SET CustomerID = ?, ProductOrService = ?, CreditPeriod = ?, " +
                "CreditAmount = ?, Remarks = ?, Attachment = ?, UpdateUserID = ?, UpdateDate = ?, ConsumerID = ?, SalesType = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("ProductOrService", _sProductOrService);
                cmd.Parameters.AddWithValue("CreditPeriod", _nCreditPeriod);
                cmd.Parameters.AddWithValue("CreditAmount", _CreditAmount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Attachment", _sAttachment);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("ConsumerID", _nConsumerID);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
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
                sSql = "DELETE FROM t_CustomerCreditApproval WHERE [ID]=?";
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
        public void StatusUpdate()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_CustomerCreditApproval SET Status=?, StatusUpdateUserID=?, StatusUpdateDate=? WHERE [ID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("StatusUpdateUserID", _nStatusUpdateUserID);
                cmd.Parameters.AddWithValue("StatusUpdateDate", _dStatusUpdateDate);

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateInvoicedAmount(bool IsTrue)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (IsTrue == true)
                {
                    sSql = "Update t_CustomerCreditApproval SET InvoicedAmount = InvoicedAmount + ? WHERE [ApprovalNo]=?";
                }
                else
                {
                    sSql = "Update t_CustomerCreditApproval SET InvoicedAmount = InvoicedAmount - ? WHERE [ApprovalNo]=?";
                }
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InvoicedAmount", _InvoicedAmount);
                cmd.Parameters.AddWithValue("ApprovalNo", _sApprovalNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateCollectedAmount()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_CustomerCreditApproval SET CollectedAmount = CollectedAmount + ? WHERE [ApprovalNo]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CollectedAmount", _CollectedAmount);
                cmd.Parameters.AddWithValue("ApprovalNo", _sApprovalNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateCollectedAmount(int nCreditApprovalID, int nWarehouseID, int nCustomerID, double _Amount)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_CustomerCreditApproval SET CollectedAmount = CollectedAmount + " + _Amount + " WHERE CreditApprovalID=" + nCreditApprovalID + " and WarehouseID = " + nWarehouseID + " and CustomerID = " + nCustomerID + "";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

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
                cmd.CommandText = "SELECT * FROM t_CustomerCreditApproval where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nCreditApprovalID = (int)reader["CreditApprovalID"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _sApprovalNo = (string)reader["ApprovalNo"];
                    _sProductOrService = (string)reader["ProductOrService"];
                    _nCreditPeriod = (int)reader["CreditPeriod"];
                    _CreditAmount = Convert.ToDouble(reader["CreditAmount"].ToString());
                    _InvoicedAmount = Convert.ToDouble(reader["InvoicedAmount"].ToString());
                    _CollectedAmount = Convert.ToDouble(reader["CollectedAmount"].ToString());
                    _sRemarks = (string)reader["Remarks"];
                    _sAttachment = (string)reader["Attachment"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByApprovalNo(string sApprovalNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CustomerCreditApproval where ApprovalNo ='" + sApprovalNo + "'";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nCreditApprovalID = (int)reader["CreditApprovalID"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _sApprovalNo = (string)reader["ApprovalNo"];
                    _sProductOrService = (string)reader["ProductOrService"];
                    _nCreditPeriod = (int)reader["CreditPeriod"];
                    _CreditAmount = Convert.ToDouble(reader["CreditAmount"].ToString());
                    _InvoicedAmount = Convert.ToDouble(reader["InvoicedAmount"].ToString());
                    _CollectedAmount = Convert.ToDouble(reader["CollectedAmount"].ToString());


                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshByApprovalNoByCustID(string sApprovalNo,int nCustID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CustomerCreditApproval where ApprovalNo ='" + sApprovalNo + "' and CustomerID=" + nCustID + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nCreditApprovalID = (int)reader["CreditApprovalID"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _sApprovalNo = (string)reader["ApprovalNo"];
                    _sProductOrService = (string)reader["ProductOrService"];
                    _nCreditPeriod = (int)reader["CreditPeriod"];
                    _CreditAmount = Convert.ToDouble(reader["CreditAmount"].ToString());
                    _InvoicedAmount = Convert.ToDouble(reader["InvoicedAmount"].ToString());
                    _CollectedAmount = Convert.ToDouble(reader["CollectedAmount"].ToString());


                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByApprovalNoByConsumerID(string sApprovalNo, int nCustID,int nConsumerID,int nSalesType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CustomerCreditApproval where ConsumerID=" + nConsumerID + " and SalesType=" + nSalesType + " and  ApprovalNo ='" + sApprovalNo + "' and CustomerID=" + nCustID + "";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nCreditApprovalID = (int)reader["CreditApprovalID"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _sApprovalNo = (string)reader["ApprovalNo"];
                    _sProductOrService = (string)reader["ProductOrService"];
                    _nCreditPeriod = (int)reader["CreditPeriod"];
                    _CreditAmount = Convert.ToDouble(reader["CreditAmount"].ToString());
                    _InvoicedAmount = Convert.ToDouble(reader["InvoicedAmount"].ToString());
                    _CollectedAmount = Convert.ToDouble(reader["CollectedAmount"].ToString());


                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetCustomerCreditBalance(string sCAN, int nCustomerID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            double _Balance = 0;
            int nNextAPNo = 0;
            try
            {
                sSql = "select CustomerID, SUM(CreditAmount-InvoicedAmount) as Balance from dbo.t_CustomerCreditApproval " +
                        "Where ApprovalNo = '" + sCAN + "' and CustomerID =" + nCustomerID + " Group by CustomerID ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCustomerID = (int)reader["CustomerID"];
                    _Balance = Convert.ToDouble(reader["Balance"].ToString());
                }
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return _Balance;

        }

        public void GetTotalCreditAmount(int nID, int nWarehouseID, string sDB, int nMatch, string sCompany)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                if (nMatch == 1)
                {
                    cmd.CommandText = "Select '" + sCompany + "' as Company, sum(CreditAmount-CollectedAmount) TotalCreditAmount  " +
                                    "From " + sDB + ".DBO.t_CustomerCreditApproval a   " +
                                    "where WarehouseID=" + nWarehouseID + " and CreditAmount-CollectedAmount>0  " +
                                    "and ID<>" + nID + "";
                }
                else if (nMatch == 2)
                {
                    cmd.CommandText = "Select '" + sCompany + "' as Company, sum(CreditAmount-CollectedAmount) TotalCreditAmount  " +
                    "From " + sDB + ".DBO.t_CustomerCreditApproval a   " +
                    "where WarehouseID=" + nWarehouseID + " and CreditAmount-CollectedAmount>0";
                }

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _sCompany = reader["CreditAmount"].ToString();
                    _TotalCreditAmount = Convert.ToDouble(reader["TotalCreditAmount"].ToString());
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
    public class CustomerCreditApprovals : CollectionBase
    {
        public CustomerCreditApproval this[int i]
        {
            get { return (CustomerCreditApproval)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CustomerCreditApproval oCustomerCreditApproval)
        {
            InnerList.Add(oCustomerCreditApproval);
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
        public void Refresh(DateTime dtFromDate, DateTime dtToDate, string sOutlet, string sCAN, int nCustomerID, bool IsCheck)
        {
            dtToDate = dtToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"Select * From (SELECT a.*,ShowroomCode, CustomerCode, CustomerName,
                        isnull(ConsumerCode ,'') ConsumerCode
                        FROM t_CustomerCreditApproval a
                        join 
                        t_Showroom b on a.WarehouseID=b.WarehouseID 
                        join  t_Customer c on a.CustomerID=c.CustomerID
                        left outer join t_RetailConsumer d on a.WarehouseID=d.WarehouseID and a.ConsumerID=d.ConsumerID) a where 1=1 ";
            if (IsCheck != true)
            {
                sSql = sSql + " and CreateDate between '" + dtFromDate + "' and '" + dtToDate + "' and CreateDate < '" + dtToDate + "'";
            }
            if (sOutlet != "")
            {
                sSql = sSql + " and ShowroomCode='" + sOutlet + "'";
            }
            if (sCAN != "")
            {
                sSql = sSql + " and ApprovalNo='" + sCAN + "'";
            }
            if (nCustomerID > 0)
            {
                sSql = sSql + " and ApprovalNo='" + sCAN + "'";
            }
            sSql = sSql + " Order by ID ASC ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerCreditApproval oCustomerCreditApproval = new CustomerCreditApproval();

                    oCustomerCreditApproval.ID = (int)reader["ID"];
                    oCustomerCreditApproval.CreditApprovalID = (int)reader["CreditApprovalID"];
                    oCustomerCreditApproval.WarehouseID = (int)reader["WarehouseID"];
                    oCustomerCreditApproval.WarehouseCode = (string)reader["ShowroomCode"];
                    oCustomerCreditApproval.CustomerID = (int)reader["CustomerID"];
                    oCustomerCreditApproval.CustomerCode = (string)reader["CustomerCode"];
                    oCustomerCreditApproval.CustomerName = (string)reader["CustomerName"];
                    oCustomerCreditApproval.ApprovalNo = (string)reader["ApprovalNo"];
                    oCustomerCreditApproval.ProductOrService = (string)reader["ProductOrService"];
                    oCustomerCreditApproval.CreditPeriod = (int)reader["CreditPeriod"];
                    oCustomerCreditApproval.CreditAmount = Convert.ToDouble(reader["CreditAmount"].ToString());
                    oCustomerCreditApproval.InvoicedAmount = Convert.ToDouble(reader["InvoicedAmount"].ToString());
                    oCustomerCreditApproval.CollectedAmount = Convert.ToDouble(reader["CollectedAmount"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oCustomerCreditApproval.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oCustomerCreditApproval.Remarks = "";
                    }
                    if (reader["Attachment"] != DBNull.Value)
                    {
                        oCustomerCreditApproval.Attachment = (string)reader["Attachment"];
                    }
                    else
                    {
                        oCustomerCreditApproval.Attachment = "";
                    }
                    oCustomerCreditApproval.CreateUserID = (int)reader["CreateUserID"];
                    oCustomerCreditApproval.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCustomerCreditApproval.Status = (int)reader["Status"];


                    oCustomerCreditApproval.ConsumerCode = Convert.ToString(reader["ConsumerCode"].ToString());
                    if (reader["SalesType"] != DBNull.Value)
                    {
                        oCustomerCreditApproval.SalesType = (int)reader["SalesType"];
                    }
                    else
                    {
                        oCustomerCreditApproval.SalesType = 0;
                    }

                    InnerList.Add(oCustomerCreditApproval);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForPOSx(DateTime dtFromDate, DateTime dtToDate, string sCAN, string sCustomerName, bool IsCheck)
        {
            dtToDate = dtToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT a.*,ShowroomCode, CustomerCode, CustomerName FROM t_CustomerCreditApproval a, " +
            "t_Showroom b, t_Customer c Where a.WarehouseID=b.WarehouseID and a.CustomerID=c.CustomerID ";
            if (IsCheck != true)
            {
                sSql = sSql + " and CreateDate between '" + dtFromDate + "' and '" + dtToDate + "' and CreateDate < '" + dtToDate + "'";
            }
            if (sCAN != "")
            {
                sSql = sSql + " and ApprovalNo='" + sCAN + "'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " and CustomerName like '%" + sCustomerName + "%'";
            }
            sSql = sSql + " Order by ID ASC ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerCreditApproval oCustomerCreditApproval = new CustomerCreditApproval();

                    oCustomerCreditApproval.ID = (int)reader["ID"];
                    oCustomerCreditApproval.CreditApprovalID = (int)reader["CreditApprovalID"];
                    oCustomerCreditApproval.WarehouseID = (int)reader["WarehouseID"];
                    oCustomerCreditApproval.WarehouseCode = (string)reader["ShowroomCode"];
                    oCustomerCreditApproval.CustomerID = (int)reader["CustomerID"];
                    oCustomerCreditApproval.CustomerCode = (string)reader["CustomerCode"];
                    oCustomerCreditApproval.CustomerName = (string)reader["CustomerName"];
                    oCustomerCreditApproval.ApprovalNo = (string)reader["ApprovalNo"];
                    oCustomerCreditApproval.ProductOrService = (string)reader["ProductOrService"];
                    oCustomerCreditApproval.CreditPeriod = (int)reader["CreditPeriod"];
                    oCustomerCreditApproval.CreditAmount = Convert.ToDouble(reader["CreditAmount"].ToString());
                    oCustomerCreditApproval.InvoicedAmount = Convert.ToDouble(reader["InvoicedAmount"].ToString());
                    oCustomerCreditApproval.CollectedAmount = Convert.ToDouble(reader["CollectedAmount"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oCustomerCreditApproval.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oCustomerCreditApproval.Remarks = "";
                    }
                    oCustomerCreditApproval.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oCustomerCreditApproval);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshForPOS(DateTime dtFromDate, DateTime dtToDate, string sCAN, string sCustomerName, bool IsCheck)
        {
            dtToDate = dtToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @"Select * From 
                        (
                        SELECT a.*,ShowroomCode, 
                        isnull(d.ConsumerCode,c.CustomerCode) CustomerCode,
                        isnull(d.ConsumerName,c.CustomerName) CustomerName,
                        isnull(d.Address,c.CustomerAddress) CustomerAddress,
                        isnull(isnull(d.CellNo,c.CellPhoneNumber),'') CustomerMobileNo
                        FROM t_CustomerCreditApproval a 
                        join t_Showroom b on a.WarehouseID=b.WarehouseID 
                        join t_Customer c on a.CustomerID=c.CustomerID
                        left outer join t_RetailConsumer d 
                        on a.ConsumerID=d.ConsumerID ) x where 1=1";

            if (IsCheck != true)
            {
                sSql = sSql + " and CreateDate between '" + dtFromDate + "' and '" + dtToDate + "' and CreateDate < '" + dtToDate + "'";
            }
            if (sCAN != "")
            {
                sSql = sSql + " and ApprovalNo='" + sCAN + "'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " and CustomerName like '%" + sCustomerName + "%'";
            }
            sSql = sSql + " Order by ID ASC ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerCreditApproval oCustomerCreditApproval = new CustomerCreditApproval();

                    oCustomerCreditApproval.ID = (int)reader["ID"];
                    oCustomerCreditApproval.CreditApprovalID = (int)reader["CreditApprovalID"];
                    oCustomerCreditApproval.WarehouseID = (int)reader["WarehouseID"];
                    oCustomerCreditApproval.WarehouseCode = (string)reader["ShowroomCode"];
                    oCustomerCreditApproval.CustomerID = (int)reader["CustomerID"];
                    oCustomerCreditApproval.CustomerCode = (string)reader["CustomerCode"];
                    oCustomerCreditApproval.CustomerName = (string)reader["CustomerName"];
                    oCustomerCreditApproval.ApprovalNo = (string)reader["ApprovalNo"];
                    oCustomerCreditApproval.ProductOrService = (string)reader["ProductOrService"];
                    oCustomerCreditApproval.CreditPeriod = (int)reader["CreditPeriod"];
                    oCustomerCreditApproval.CreditAmount = Convert.ToDouble(reader["CreditAmount"].ToString());
                    oCustomerCreditApproval.InvoicedAmount = Convert.ToDouble(reader["InvoicedAmount"].ToString());
                    oCustomerCreditApproval.CollectedAmount = Convert.ToDouble(reader["CollectedAmount"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oCustomerCreditApproval.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oCustomerCreditApproval.Remarks = "";
                    }
                    oCustomerCreditApproval.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oCustomerCreditApproval);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForPOSRT(DateTime dtFromDate, DateTime dtToDate, string sCAN, string sCustomerName, bool IsCheck)
        {
            dtToDate = dtToDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT a.*,ShowroomCode, CustomerCode, CustomerName FROM t_CustomerCreditApproval a, " +
            "t_Showroom b, t_Customer c Where a.WarehouseID=b.WarehouseID and a.CustomerID=c.CustomerID and a.WarehouseID=" + Utility.WarehouseID + "";
            if (IsCheck != true)
            {
                sSql = sSql + " and CreateDate between '" + dtFromDate + "' and '" + dtToDate + "' and CreateDate < '" + dtToDate + "'";
            }
            if (sCAN != "")
            {
                sSql = sSql + " and ApprovalNo='" + sCAN + "'";
            }
            if (sCustomerName != "")
            {
                sSql = sSql + " and CustomerName like '%" + sCustomerName + "%'";
            }
            sSql = sSql + " Order by ID ASC ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerCreditApproval oCustomerCreditApproval = new CustomerCreditApproval();

                    oCustomerCreditApproval.ID = (int)reader["ID"];
                    oCustomerCreditApproval.CreditApprovalID = (int)reader["CreditApprovalID"];
                    oCustomerCreditApproval.WarehouseID = (int)reader["WarehouseID"];
                    oCustomerCreditApproval.WarehouseCode = (string)reader["ShowroomCode"];
                    oCustomerCreditApproval.CustomerID = (int)reader["CustomerID"];
                    oCustomerCreditApproval.CustomerCode = (string)reader["CustomerCode"];
                    oCustomerCreditApproval.CustomerName = (string)reader["CustomerName"];
                    oCustomerCreditApproval.ApprovalNo = (string)reader["ApprovalNo"];
                    oCustomerCreditApproval.ProductOrService = (string)reader["ProductOrService"];
                    oCustomerCreditApproval.CreditPeriod = (int)reader["CreditPeriod"];
                    oCustomerCreditApproval.CreditAmount = Convert.ToDouble(reader["CreditAmount"].ToString());
                    oCustomerCreditApproval.InvoicedAmount = Convert.ToDouble(reader["InvoicedAmount"].ToString());
                    oCustomerCreditApproval.CollectedAmount = Convert.ToDouble(reader["CollectedAmount"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oCustomerCreditApproval.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oCustomerCreditApproval.Remarks = "";
                    }
                    oCustomerCreditApproval.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oCustomerCreditApproval);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(int nID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT a.*,ShowroomCode, CustomerCode, CustomerName, CustomerAddress, CASE When CellPhoneNumber !='' " +
            "then CellPhoneNumber else CustomerTelephone end as ContactNo FROM t_CustomerCreditApproval a, " +
            "t_Showroom b, t_Customer c Where a.WarehouseID=b.WarehouseID and a.CustomerID=c.CustomerID and ID=" + nID + " ";
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerCreditApproval oCustomerCreditApproval = new CustomerCreditApproval();

                    oCustomerCreditApproval.ID = (int)reader["ID"];
                    oCustomerCreditApproval.CreditApprovalID = (int)reader["CreditApprovalID"];
                    oCustomerCreditApproval.WarehouseID = (int)reader["WarehouseID"];
                    oCustomerCreditApproval.WarehouseCode = (string)reader["ShowroomCode"];
                    oCustomerCreditApproval.CustomerID = (int)reader["CustomerID"];
                    oCustomerCreditApproval.CustomerCode = (string)reader["CustomerCode"];
                    oCustomerCreditApproval.CustomerName = (string)reader["CustomerName"];
                    oCustomerCreditApproval.ApprovalNo = (string)reader["ApprovalNo"];
                    oCustomerCreditApproval.ProductOrService = (string)reader["ProductOrService"];
                    oCustomerCreditApproval.CustomerAddress = (string)reader["CustomerAddress"];
                    oCustomerCreditApproval.CustomerContactNo = (string)reader["ContactNo"];
                    oCustomerCreditApproval.CreditPeriod = (int)reader["CreditPeriod"];
                    oCustomerCreditApproval.CreditAmount = Convert.ToDouble(reader["CreditAmount"].ToString());
                    oCustomerCreditApproval.InvoicedAmount = Convert.ToDouble(reader["InvoicedAmount"].ToString());
                    oCustomerCreditApproval.CollectedAmount = Convert.ToDouble(reader["CollectedAmount"].ToString());
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oCustomerCreditApproval.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oCustomerCreditApproval.Remarks = "";
                    }
                    oCustomerCreditApproval.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    InnerList.Add(oCustomerCreditApproval);
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


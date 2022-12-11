// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD. Abdul Hakim
// Date: Nov 09, 2015
// Time : 10:56 AM
// Description: Class for CustomerCreditApprovalCollection.
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
    public class CustomerCreditApprovalCollection
    {
        private int _nCreditApprovalCollectionID;
        private int _nCreditApprovalID;
        private int _nWarehouseID;
        private int _nCustomerID;
        private double _Amount;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nInstrumentType;
        private object _dInstrumentDate;
        private string _sInstrumentNo;
        private int _nBankID;
        private string _sBranchName;
        private int _nInstrumentStatus;
        private string _sRemarks;
        private string _sShowroomCode;
        private string _sCustomerCode;
        private string _sCustomerName;
        private string _sCustomerAddress;
        private string _sCellNo;
        private string _sApprovalNo;

        // <summary>
        // Get set property for CellNo
        // </summary>
        public string CellNo
        {
            get { return _sCellNo; }
            set { _sCellNo = value.Trim(); }
        }

        // <summary>
        // Get set property for CustomerAddress
        // </summary>
        public string CustomerAddress
        {
            get { return _sCustomerAddress; }
            set { _sCustomerAddress = value.Trim(); }
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
        // Get set property for ShowroomCode
        // </summary>
        public string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value.Trim(); }
        }

        // <summary>
        // Get set property for CustomerCode
        // </summary>
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }

        // <summary>
        // Get set property for CustomerName
        // </summary>
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }


        // <summary>
        // Get set property for CreditApprovalCollectionID
        // </summary>
        public int CreditApprovalCollectionID
        {
            get { return _nCreditApprovalCollectionID; }
            set { _nCreditApprovalCollectionID = value; }
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
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
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
        // Get set property for InstrumentType
        // </summary>
        public int InstrumentType
        {
            get { return _nInstrumentType; }
            set { _nInstrumentType = value; }
        }

        // <summary>
        // Get set property for InstrumentDate
        // </summary>
        public object InstrumentDate
        {
            get { return _dInstrumentDate; }
            set { _dInstrumentDate = value; }
        }

        // <summary>
        // Get set property for InstrumentNo
        // </summary>
        public string InstrumentNo
        {
            get { return _sInstrumentNo; }
            set { _sInstrumentNo = value.Trim(); }
        }

        // <summary>
        // Get set property for BankID
        // </summary>
        public int BankID
        {
            get { return _nBankID; }
            set { _nBankID = value; }
        }

        // <summary>
        // Get set property for BranchName
        // </summary>
        public string BranchName
        {
            get { return _sBranchName; }
            set { _sBranchName = value.Trim(); }
        }

        // <summary>
        // Get set property for InstrumentStatus
        // </summary>
        public int InstrumentStatus
        {
            get { return _nInstrumentStatus; }
            set { _nInstrumentStatus = value; }
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
            int nMaxCreditApprovalCollectionID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([CreditApprovalCollectionID]) FROM t_CustomerCreditApprovalCollection";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxCreditApprovalCollectionID = 1;
                }
                else
                {
                    nMaxCreditApprovalCollectionID = Convert.ToInt32(maxID) + 1;
                }
                _nCreditApprovalCollectionID = nMaxCreditApprovalCollectionID;
                sSql = "INSERT INTO t_CustomerCreditApprovalCollection (CreditApprovalCollectionID, CreditApprovalID, WarehouseID, CustomerID, Amount, CreateUserID, CreateDate, InstrumentType, InstrumentDate, InstrumentNo, BankID, BranchName, InstrumentStatus, Remarks) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CreditApprovalCollectionID", _nCreditApprovalCollectionID);
                cmd.Parameters.AddWithValue("CreditApprovalID", _nCreditApprovalID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("InstrumentType", _nInstrumentType);
                cmd.Parameters.AddWithValue("InstrumentDate", _dInstrumentDate);
                cmd.Parameters.AddWithValue("InstrumentNo", _sInstrumentNo);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("BranchName", _sBranchName);
                cmd.Parameters.AddWithValue("InstrumentStatus", _nInstrumentStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_CustomerCreditApprovalCollection";
                oDataTran.DataID = _nCreditApprovalCollectionID;
                oDataTran.WarehouseID = _nWarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;

                oDataTran.AddForTDPOS();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddRT()
        {
            int nMaxCreditApprovalCollectionID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([CreditApprovalCollectionID]) FROM t_CustomerCreditApprovalCollection where WarehouseID=" + Utility.WarehouseID + "";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxCreditApprovalCollectionID = 1;
                }
                else
                {
                    nMaxCreditApprovalCollectionID = Convert.ToInt32(maxID) + 1;
                }
                _nCreditApprovalCollectionID = nMaxCreditApprovalCollectionID;
                sSql = "INSERT INTO t_CustomerCreditApprovalCollection (CreditApprovalCollectionID, CreditApprovalID, WarehouseID, CustomerID, Amount, CreateUserID, CreateDate, InstrumentType, InstrumentDate, InstrumentNo, BankID, BranchName, InstrumentStatus, Remarks) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CreditApprovalCollectionID", _nCreditApprovalCollectionID);
                cmd.Parameters.AddWithValue("CreditApprovalID", _nCreditApprovalID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("InstrumentType", _nInstrumentType);
                cmd.Parameters.AddWithValue("InstrumentDate", _dInstrumentDate);
                cmd.Parameters.AddWithValue("InstrumentNo", _sInstrumentNo);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("BranchName", _sBranchName);
                cmd.Parameters.AddWithValue("InstrumentStatus", _nInstrumentStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void AddForPOS()
        {
           
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                
                sSql = "INSERT INTO t_CustomerCreditApprovalCollection (CreditApprovalCollectionID, CreditApprovalID, WarehouseID, CustomerID, Amount, CreateUserID, CreateDate, InstrumentType, InstrumentDate, InstrumentNo, BankID, BranchName, InstrumentStatus, Remarks) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CreditApprovalCollectionID", _nCreditApprovalCollectionID);
                cmd.Parameters.AddWithValue("CreditApprovalID", _nCreditApprovalID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("InstrumentType", _nInstrumentType);
                cmd.Parameters.AddWithValue("InstrumentDate", _dInstrumentDate);
                cmd.Parameters.AddWithValue("InstrumentNo", _sInstrumentNo);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("BranchName", _sBranchName);
                cmd.Parameters.AddWithValue("InstrumentStatus", _nInstrumentStatus);
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
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CustomerCreditApprovalCollection SET CreditApprovalID = ?, WarehouseID = ?, CustomerID = ?, Amount = ?, CreateUserID = ?, CreateDate = ?, InstrumentType = ?, InstrumentDate = ?, InstrumentNo = ?, BankID = ?, BranchName = ?, InstrumentStatus = ?, Remarks = ? WHERE CreditApprovalCollectionID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("CreditApprovalID", _nCreditApprovalID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("InstrumentType", _nInstrumentType);
                cmd.Parameters.AddWithValue("InstrumentDate", _dInstrumentDate);
                cmd.Parameters.AddWithValue("InstrumentNo", _sInstrumentNo);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("BranchName", _sBranchName);
                cmd.Parameters.AddWithValue("InstrumentStatus", _nInstrumentStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);

                cmd.Parameters.AddWithValue("CreditApprovalCollectionID", _nCreditApprovalCollectionID);

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
                sSql = "DELETE FROM t_CustomerCreditApprovalCollection WHERE [CreditApprovalCollectionID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CreditApprovalCollectionID", _nCreditApprovalCollectionID);
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
                cmd.CommandText = "SELECT * FROM t_CustomerCreditApprovalCollection where CreditApprovalCollectionID =?";
                cmd.Parameters.AddWithValue("CreditApprovalCollectionID", _nCreditApprovalCollectionID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCreditApprovalCollectionID = (int)reader["CreditApprovalCollectionID"];
                    _nCreditApprovalID = (int)reader["CreditApprovalID"];
                    _nWarehouseID = (int)reader["WarehouseID"];
                    _nCustomerID = (int)reader["CustomerID"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nInstrumentType = (int)reader["InstrumentType"];
                    _dInstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                    _sInstrumentNo = (string)reader["InstrumentNo"];
                    _nBankID = (int)reader["BankID"];
                    _sBranchName = (string)reader["BranchName"];
                    _nInstrumentStatus = (int)reader["InstrumentStatus"];
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
        public bool CheckCollection()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_CustomerCreditApprovalCollection where CreditApprovalCollectionID =? and CreditApprovalID = ? and WarehouseID=? and CustomerID=?";
                
                cmd.Parameters.AddWithValue("CreditApprovalCollectionID", _nCreditApprovalCollectionID);
                cmd.Parameters.AddWithValue("CreditApprovalID", _nCreditApprovalID);
                cmd.Parameters.AddWithValue("WarehouseID", _nWarehouseID);
                cmd.Parameters.AddWithValue("CustomerID", _nCustomerID);

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
            if (nCount == 0)
                return true;
            else return false;
        }
        public void RefreshCollectionCollectionID(int nCollectionID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select CreditApprovalCollectionID,a.CreditApprovalID,ApprovalNo,a.CreateDate, "+
                                  " ShowroomCode,CustomerCode,CustomerName,CustomerAddress,CellPhoneNumber,Amount  "+
                                  " From t_CustomerCreditApprovalCollection a,t_Showroom b,t_Customer c,t_CustomerCreditApproval d " +
                                  " where a.WarehouseID=b.WarehouseID and c.CustomerID=a.CustomerID and a.CreditApprovalID=d.CreditApprovalID and a.CreditApprovalCollectionID = ?";


                cmd.Parameters.AddWithValue("CreditApprovalCollectionID", nCollectionID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCreditApprovalCollectionID = (int)reader["CreditApprovalCollectionID"];
                    _nCreditApprovalID = (int)reader["CreditApprovalID"];
                    _sApprovalNo = (string)reader["ApprovalNo"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _sShowroomCode = (string)reader["ShowroomCode"];
                    _sCustomerCode = (string)reader["CustomerCode"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _sCustomerAddress = (string)reader["CustomerAddress"];
                    _sCellNo = (string)reader["CellPhoneNumber"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
               
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void RefreshCollectionCollectionIDRT(int nCollectionID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "Select CreditApprovalCollectionID,a.CreditApprovalID,ApprovalNo,a.CreateDate, " +
                                  " ShowroomCode,CustomerCode,CustomerName,CustomerAddress,CellPhoneNumber,Amount  " +
                                  " From t_CustomerCreditApprovalCollection a,t_Showroom b,t_Customer c,t_CustomerCreditApproval d " +
                                  " where a.WarehouseID=" + Utility.WarehouseID + " and a.WarehouseID=b.WarehouseID and c.CustomerID=a.CustomerID "+
                                  " and a.WarehouseID=d.WarehouseID and a.CreditApprovalID=d.CreditApprovalID and a.CreditApprovalCollectionID = ?";


                cmd.Parameters.AddWithValue("CreditApprovalCollectionID", nCollectionID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nCreditApprovalCollectionID = (int)reader["CreditApprovalCollectionID"];
                    _nCreditApprovalID = (int)reader["CreditApprovalID"];
                    _sApprovalNo = (string)reader["ApprovalNo"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _sShowroomCode = (string)reader["ShowroomCode"];
                    _sCustomerCode = (string)reader["CustomerCode"];
                    _sCustomerName = (string)reader["CustomerName"];
                    _sCustomerAddress = (string)reader["CustomerAddress"];
                    _sCellNo = (string)reader["CellPhoneNumber"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());

                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public double GetCollectionAmount(DateTime _Date)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            DateTime dToDate = _Date.AddDays(1);
            string sSQL = "";
            double _Amt = 0;
            try
            {
                sSQL = "Select sum(Amount) Amount From  " +
                    "(  " +
                    "Select Sum(Amount) as Amount From t_CustomerCreditApprovalCollection    " +
                    "Where CreateDate Between '" + _Date + "'  and '" + dToDate + "'  " +
                    "and CreateDate <'" + dToDate + "' " +
                    "Union All  " +
                    "Select sum(Amount) Amount  " +
                    "From t_CustomerTran where TranTypeID=5   " +
                    "and TranDate Between '" + _Date + "'  and '" + dToDate + "'  " +
                    "and TranDate <'" + dToDate + "'  and Terminal<>" + (int)Dictionary.Terminal.Head_Office + " " +
                    ") Main ";

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _Amt = Convert.ToDouble(reader["Amount"].ToString());
                }
                reader.Close();
            }
            catch 
            {
                _Amt = 0;
            }

            return _Amt;
        }

        public double GetCollectionAmountRT(DateTime _Date)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            DateTime dToDate = _Date.AddDays(1);
            string sSQL = "";
            double _Amt = 0;
            try
            {
                sSQL = "Select sum(Amount) Amount From  " +
                    "(  " +
                    "Select Sum(Amount) as Amount From t_CustomerCreditApprovalCollection    " +
                    "Where WarehouseID=" + Utility.WarehouseID + " and CreateDate Between '" + _Date + "'  and '" + dToDate + "'  " +
                    "and CreateDate <'" + dToDate + "' " +
                    "Union All  " +
                    "Select sum(Amount) Amount  " +
                    "From t_CustomerTran where EntryLocationID=" + Utility.LocationID + " and TranTypeID=5   " +
                    "and TranDate Between '" + _Date + "'  and '" + dToDate + "'  " +
                    "and TranDate <'" + dToDate + "'  and Terminal<>" + (int)Dictionary.Terminal.Head_Office + " " +
                    ") Main ";

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _Amt = Convert.ToDouble(reader["Amount"].ToString());
                }
                reader.Close();
            }
            catch
            {
                _Amt = 0;
            }

            return _Amt;
        }
    }
    public class CustomerCreditApprovalCollections : CollectionBase
    {
        public CustomerCreditApprovalCollection this[int i]
        {
            get { return (CustomerCreditApprovalCollection)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CustomerCreditApprovalCollection oCustomerCreditApprovalCollection)
        {
            InnerList.Add(oCustomerCreditApprovalCollection);
        }
        public int GetIndex(int nCreditApprovalCollectionID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].CreditApprovalCollectionID == nCreditApprovalCollectionID)
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
            string sSql = "SELECT * FROM t_CustomerCreditApprovalCollection";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerCreditApprovalCollection oCustomerCreditApprovalCollection = new CustomerCreditApprovalCollection();
                    
                    oCustomerCreditApprovalCollection.CreditApprovalCollectionID = (int)reader["CreditApprovalCollectionID"];
                    oCustomerCreditApprovalCollection.CreditApprovalID = (int)reader["CreditApprovalID"];
                    oCustomerCreditApprovalCollection.WarehouseID = (int)reader["WarehouseID"];
                    oCustomerCreditApprovalCollection.CustomerID = (int)reader["CustomerID"];
                    oCustomerCreditApprovalCollection.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oCustomerCreditApprovalCollection.CreateUserID = (int)reader["CreateUserID"];
                    oCustomerCreditApprovalCollection.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oCustomerCreditApprovalCollection.InstrumentType = (int)reader["InstrumentType"];
                    oCustomerCreditApprovalCollection.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                    oCustomerCreditApprovalCollection.InstrumentNo = (string)reader["InstrumentNo"];
                    oCustomerCreditApprovalCollection.BankID = (int)reader["BankID"];
                    oCustomerCreditApprovalCollection.BranchName = (string)reader["BranchName"];
                    oCustomerCreditApprovalCollection.InstrumentStatus = (int)reader["InstrumentStatus"];
                    oCustomerCreditApprovalCollection.Remarks = (string)reader["Remarks"];

                    InnerList.Add(oCustomerCreditApprovalCollection);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshCollectionAmount(string nApprovalNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select CreditApprovalCollectionID,b.CreateDate,b.Amount  "+
                          " From t_CustomerCreditApproval a,t_CustomerCreditApprovalCollection b  " +
                          " where a.CreditApprovalID=b.CreditApprovalID and a.WarehouseID=b.WarehouseID and ApprovalNo= ? ";

            cmd.Parameters.AddWithValue("ApprovalNo", nApprovalNo);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CustomerCreditApprovalCollection _oCustomerCreditApprovalCollection = new CustomerCreditApprovalCollection();
                    _oCustomerCreditApprovalCollection.CreditApprovalCollectionID = (int)reader["CreditApprovalCollectionID"];
                    _oCustomerCreditApprovalCollection.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    if (reader["Amount"] != DBNull.Value)
                        _oCustomerCreditApprovalCollection.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    else _oCustomerCreditApprovalCollection.Amount = 0;

                    InnerList.Add(_oCustomerCreditApprovalCollection);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshCollectionAmountForMoneyReceiptxx(int nCreditApprovalID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select CreditApprovalCollectionID,CreditApprovalID,CreateDate, "+
                          " ShowroomCode,CustomerCode,CustomerName,Amount  "+
                          " From t_CustomerCreditApprovalCollection a,t_Showroom b,t_Customer c " +
                          " where a.WarehouseID=b.WarehouseID and c.CustomerID=a.CustomerID  and CreditApprovalID = ?";

            cmd.Parameters.AddWithValue("CreditApprovalID", nCreditApprovalID);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CustomerCreditApprovalCollection _oCustomerCreditApprovalCollection = new CustomerCreditApprovalCollection();
                    _oCustomerCreditApprovalCollection.CreditApprovalCollectionID = (int)reader["CreditApprovalCollectionID"];
                    _oCustomerCreditApprovalCollection.CreditApprovalID = (int)reader["CreditApprovalID"];
                    _oCustomerCreditApprovalCollection.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _oCustomerCreditApprovalCollection.ShowroomCode = (string)reader["ShowroomCode"];
                    _oCustomerCreditApprovalCollection.CustomerCode = (string)reader["CustomerCode"];
                    _oCustomerCreditApprovalCollection.CustomerName = (string)reader["CustomerName"]; 
                    if (reader["Amount"] != DBNull.Value)
                        _oCustomerCreditApprovalCollection.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    else _oCustomerCreditApprovalCollection.Amount = 0;

                    InnerList.Add(_oCustomerCreditApprovalCollection);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshCollectionAmountForMoneyReceipt(int nCreditApprovalID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = @"Select CreditApprovalCollectionID,a.CreditApprovalID,a.CreateDate,
                        ShowroomCode,isnull(e.ConsumerCode,CustomerCode) CustomerCode,ApprovalNo,
                        isnull(e.ConsumerName,CustomerName) CustomerName,
                        isnull(e.Address,d.CustomerAddress) CustomerAddress,
                        isnull(isnull(e.CellNo,d.CellPhoneNumber),'') CustomerMobileNo,
                        Amount 
                        From t_CustomerCreditApprovalCollection a
                        join t_CustomerCreditApproval b on a.CreditApprovalID=b.CreditApprovalID and a.CustomerID=b.CustomerID and a.WarehouseID=b.WarehouseID
                        join t_Showroom c on a.WarehouseID=c.WarehouseID 
                        join t_Customer d on a.CustomerID=d.CustomerID  
                        left outer join t_RetailConsumer e 
                        on b.ConsumerID=e.ConsumerID
                        where a.CreditApprovalID = " + nCreditApprovalID + "";
            
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerCreditApprovalCollection _oCustomerCreditApprovalCollection = new CustomerCreditApprovalCollection();
                    _oCustomerCreditApprovalCollection.CreditApprovalCollectionID = (int)reader["CreditApprovalCollectionID"];
                    _oCustomerCreditApprovalCollection.CreditApprovalID = (int)reader["CreditApprovalID"];
                    _oCustomerCreditApprovalCollection.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _oCustomerCreditApprovalCollection.ShowroomCode = (string)reader["ShowroomCode"];
                    _oCustomerCreditApprovalCollection.CustomerCode = (string)reader["CustomerCode"];
                    _oCustomerCreditApprovalCollection.CustomerName = (string)reader["CustomerName"];
                    if (reader["Amount"] != DBNull.Value)
                        _oCustomerCreditApprovalCollection.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    else _oCustomerCreditApprovalCollection.Amount = 0;


                    _oCustomerCreditApprovalCollection.ApprovalNo = (string)reader["ApprovalNo"];
                    _oCustomerCreditApprovalCollection.CustomerAddress = (string)reader["CustomerAddress"];
                    _oCustomerCreditApprovalCollection.CellNo = (string)reader["CustomerMobileNo"];

                    InnerList.Add(_oCustomerCreditApprovalCollection);

                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RefreshCollectionAmountForMoneyReceiptRT(int nCreditApprovalID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select CreditApprovalCollectionID,CreditApprovalID,CreateDate, " +
                          " ShowroomCode,CustomerCode,CustomerName,Amount  " +
                          " From t_CustomerCreditApprovalCollection a,t_Showroom b,t_Customer c " +
                          " where a.WarehouseID=b.WarehouseID and c.CustomerID=a.CustomerID and a.WarehouseID=" + Utility.WarehouseID + " and CreditApprovalID = ?";

            cmd.Parameters.AddWithValue("CreditApprovalID", nCreditApprovalID);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    CustomerCreditApprovalCollection _oCustomerCreditApprovalCollection = new CustomerCreditApprovalCollection();
                    _oCustomerCreditApprovalCollection.CreditApprovalCollectionID = (int)reader["CreditApprovalCollectionID"];
                    _oCustomerCreditApprovalCollection.CreditApprovalID = (int)reader["CreditApprovalID"];
                    _oCustomerCreditApprovalCollection.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _oCustomerCreditApprovalCollection.ShowroomCode = (string)reader["ShowroomCode"];
                    _oCustomerCreditApprovalCollection.CustomerCode = (string)reader["CustomerCode"];
                    _oCustomerCreditApprovalCollection.CustomerName = (string)reader["CustomerName"];
                    if (reader["Amount"] != DBNull.Value)
                        _oCustomerCreditApprovalCollection.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    else _oCustomerCreditApprovalCollection.Amount = 0;
                    InnerList.Add(_oCustomerCreditApprovalCollection);

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


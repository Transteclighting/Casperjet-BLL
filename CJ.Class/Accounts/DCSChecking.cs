// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Oct 22, 2012
// Time :  09:55 AM
// Description: Class for DCS Checking.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Class
{
    public class DCSChecking
    {
        private string _sID;
        private double _sInvoiceAmt;
        private double _sBankDepositAmt;
        private int _nStatus;
        private string _sRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;

        /// <summary>
        /// Get set property for ID
        /// </summary>
        public string ID
        {
            get { return _sID; }
            set { _sID = value; }
        }
        /// <summary>
        /// Get set property for InvoiceAmt
        /// </summary>
        public double InvoiceAmt
        {
            get { return _sInvoiceAmt; }
            set { _sInvoiceAmt = value; }
        }
        /// <summary>
        /// Get set property for BankDepositAmt
        /// </summary>
        public double BankDepositAmt
        {
            get { return _sBankDepositAmt; }
            set { _sBankDepositAmt = value; }
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
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
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
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }
        /// <summary>
        /// Get set property for UpdateUserID
        /// </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }
        /// <summary>
        /// Get set property for UpdateDate
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        private string _sOutlet;
        public string Outlet
        {
            get { return _sOutlet; }
            set { _sOutlet = value; }
        }
        //private double _sCassiopeiaSale;
        //public double CassiopeiaSale
        //{
        //    get { return _sCassiopeiaSale; }
        //    set { _sCassiopeiaSale = value; }
        //}
        private int _nDepositType;
        public int DepositType
        {
            get { return _nDepositType; }
            set { _nDepositType = value; }
        }
        private User _oUser; 
        public User User
        {
            get
            {
                if (_oUser == null)
                {
                    _oUser = new User();
                    User.UserId =_nCreateUserID;
                    User.RefreshByUserID();
                }
                return _oUser;
            }
        }
        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_OutletDepositChecking(ID, InvoiceAmt, BankDepositAmt, Status, Remarks, CreateUserID,CreateDate) VALUES(?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _sID);
                if (_nStatus != 1)
                {
                    cmd.Parameters.AddWithValue("InvoiceAmt", null);
                    cmd.Parameters.AddWithValue("BankDepositAmt", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InvoiceAmt", _sInvoiceAmt);
                    cmd.Parameters.AddWithValue("BankDepositAmt", _sBankDepositAmt);
                }
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);

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

                cmd.CommandText = "UPDATE t_OutletDepositChecking SET InvoiceAmt=?, BankDepositAmt=?, Status=?, Remarks=?, UpdateUserID=?,UpdateDate=? Where ID=? ";

                cmd.CommandType = CommandType.Text;

                if (_nStatus != 1)
                {
                    cmd.Parameters.AddWithValue("InvoiceAmt", null);
                    cmd.Parameters.AddWithValue("BankDepositAmt", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InvoiceAmt", _sInvoiceAmt);
                    cmd.Parameters.AddWithValue("BankDepositAmt", _sBankDepositAmt);
                }
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now);

                cmd.Parameters.AddWithValue("ID", _sID);

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

                cmd.CommandText = "Delete From t_OutletDepositChecking Where ID=? ";

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _sID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool CheckByStatus_ID()
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_OutletDepositChecking where ID=?";
            cmd.Parameters.AddWithValue("ID", _sID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
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
        
    }
    public class DCSCheckings : CollectionBase
    {

        public DCSChecking this[int i]
        {
            get { return (DCSChecking)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(DCSChecking oDCSChecking)
        {
            InnerList.Add(oDCSChecking);
        }

        public void Refresh(DateTime dtFromDate, String txtOutlet, int nStatus, int nType)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select F.ID,Outlet,DepositTypeID,TranDate,IsNull(InvoiceAmt,InvoiceReceived)InvoiceReceived, " +
                        "IsNull(BankDepositAmt,BankDeposit)BankDeposit,IsNull(ODC.Status,0)Status,IsNull(ODC.Remarks, '')Remarks from( " +
                        "Select (Code+Convert(Varchar,DepositTypeID)+Convert(Varchar,Year(TranDate)) " +
                        "+Convert(Varchar,Month(TranDate))+Convert(Varchar,Day(TranDate)))ID, " +
                        "Code Outlet,CustomerID,DepositTypeID,TranDate,  " +
                        "Sum(case Cat when 'InvoiceReceived' then Amt  else 0 end) as InvoiceReceived, " +
                        "Sum(case Cat when 'BankDeposit' then Amt  else 0 end) as BankDeposit " +
                        "from " +
                        "( " +
                        "select Cust.Code,A.TranDate TranDate, A.CustomerID,DepositTypeID, sum(Amount)Amt, 'BankDeposit'Cat " +
                        "from t_OutletDeposit A inner join t_OutletDepositDetail B on A.OutletDepositID=B.OutletDepositID " +
                        "INNER JOIN (SELECT LEFT(CustomerName, 3) as Code, CustomerID FROM t_Customer Where CustTypeID=5)Cust " +
                        "ON Cust.CustomerID=A.CustomerID group by Cust.Code,A.TranDate, A.CustomerID,DepositTypeID " +
                        "UNION ALL select Cust.Code, A.TranDate TranDate, A.CustomerID,InstrumentTypeID, sum(Amount)Amt, 'InvoiceReceived' Cat " +
                        "from t_OutletDeposit A inner join t_OutletDepositInvoice B on A.OutletDepositID=B.OutletDepositID " +
                        "INNER JOIN (SELECT LEFT(CustomerName, 3) as Code, CustomerID FROM t_Customer Where CustTypeID=5)Cust " +
                        "ON Cust.CustomerID=A.CustomerID group by Cust.Code,A.TranDate, A.CustomerID,InstrumentTypeID " +
                        ")a " +
                        "Group by Code,CustomerID,DepositTypeID,TranDate " +
                        ")F " +
                        "Left OUTER JOIN t_OutletDepositChecking ODC " +
                        "ON ODC.ID=F.ID " +
                        "Where TranDate ='" + dtFromDate + "'";

            if (txtOutlet != "")
            {
                txtOutlet = "%" + txtOutlet + "%";
                sSql = sSql + " AND Outlet LIKE '" + txtOutlet + "'";
            }
            if (nStatus >= 0)
            {
                sSql = sSql + " and Status=?";
                cmd.Parameters.AddWithValue("Status", nStatus);
            }
            if (nType >= 0)
            {
                sSql = sSql + " and DepositTypeID=?";
                cmd.Parameters.AddWithValue("DepositTypeID", nType);
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DCSChecking oDCSChecking = new DCSChecking();

                    oDCSChecking.ID = (string)reader["ID"];
                    oDCSChecking.InvoiceAmt = Convert.ToDouble(reader["InvoiceReceived"].ToString());
                    oDCSChecking.BankDepositAmt = Convert.ToDouble(reader["BankDeposit"].ToString());
                    oDCSChecking.Status = int.Parse(reader["Status"].ToString());
                    oDCSChecking.Remarks = (string)reader["Remarks"];
                    oDCSChecking.Outlet = (string)reader["Outlet"];
                    //oDCSChecking.CassiopeiaSale = Convert.ToDouble(reader["CassiopeiaSale"].ToString());
                    oDCSChecking.DepositType = (int)reader["DepositTypeID"];

                    InnerList.Add(oDCSChecking);
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





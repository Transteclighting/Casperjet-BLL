// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Oct 04.2012
// Time :  11:00 AM
// Description: Class for DCS
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;


namespace CJ.Class.DCS
{
    public class OutletDepositDetail
    {
        private int _OutletDepositID;
        private int _DepositBankBranch;
        private int _DepositTypeId;
        private string _DepositBankBranchName;
        private string _DepositType;
        private double _Amount;


        /// <summary>
        /// Get set property for OutletDepositID
        /// </summary>
        public int OutletDepositID
        {
            get { return _OutletDepositID; }
            set { _OutletDepositID = value; }
        }

        /// <summary>
        /// Get set property for DepositBankBranch
        /// </summary>
        /// 
        public int DepositTypeID
        {
            get { return _DepositTypeId; }
            set { _DepositTypeId = value; }
        }
        public int DepositBankBranch
        {
            get { return _DepositBankBranch; }
            set { _DepositBankBranch = value; }
        }
        public string DepositBankBranchName
        {
            get { return _DepositBankBranchName; }
            set { _DepositBankBranchName = value; }
        }
        public string DepositType
        {
            get { return _DepositType; }
            set { _DepositType = value; }
        }
        /// <summary>
        /// Get set property for Amount
        /// </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_OutletDepositDetail VALUES (?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OutletDepositID", _OutletDepositID);
                cmd.Parameters.AddWithValue("DepositBankBranch", _DepositBankBranch);
                cmd.Parameters.AddWithValue("DepositTypeID", _DepositTypeId);
                cmd.Parameters.AddWithValue("Amount", _Amount);           
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class OutletDeposit : CollectionBase
    {
        public OutletDepositDetail this[int i]
        {
            get { return (OutletDepositDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(OutletDepositDetail oOutletDepositDetail)
        {
            InnerList.Add(oOutletDepositDetail);
        }

        private int _OutletDepositID;
        private string _OutletDepositNo;
        private int _CustomerID;
        private DateTime _TranDate;
        private string _Remarks;
        private int _UserID;
        public OutletDepositInvoices oOutletDepositInvoices;

        public OutletDepositInvoices OutletDepositInvoices
        {
            get
            {
                if (oOutletDepositInvoices == null)
                {
                    oOutletDepositInvoices = new OutletDepositInvoices();
                 
                }

                return oOutletDepositInvoices;
            }
        }

        /// <summary>
        /// Get set property for OutletDepositID
        /// </summary>
        public int OutletDepositID
        {
            get { return _OutletDepositID; }
            set { _OutletDepositID = value; }
        }

        /// <summary>
        /// Get set property for OutletDepositNo
        /// </summary>
        public string OutletDepositNo
        {
            get { return _OutletDepositNo; }
            set { _OutletDepositNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for CustomerID
        /// </summary>
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }

        /// <summary>
        /// Get set property for TranDate
        /// </summary>
        public DateTime TranDate
        {
            get { return _TranDate; }
            set { _TranDate = value; }
        }

        /// <summary>
        /// Get set property for Remarks
        /// </summary>
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value.Trim(); }
        }

        /// <summary>
        /// Get set property for UserID
        /// </summary>
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        public void Insert()
        {
            int nMaxID = 0;
            int nMaxDipositNo = 0;
            string sCode = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "SELECT MAX([OutletDepositID]) FROM t_OutletDeposit";
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
                _OutletDepositID = nMaxID;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "select convert(nvarchar(3),CustomerName)  from v_customerdetails where customertypeid='" + (int)Dictionary.CustomerType.OwnShowroom + "'"
                       + " and CustomerID='" + _CustomerID + "'";
                cmd.CommandText = sSql;
                object maxCode = cmd.ExecuteScalar();
                if (maxCode == DBNull.Value)
                {
                    sCode = "HO";
                }
                else
                {
                    sCode = Convert.ToString(maxCode);
                }

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = " select NEXT_ID from T_Next_ID Where OID=7 ";
                cmd.CommandText = sSql;
                object maxDipositNo = cmd.ExecuteScalar();
                if (maxDipositNo == DBNull.Value)
                {
                    nMaxDipositNo = 1;
                }
                else
                {
                    nMaxDipositNo = Convert.ToInt32(maxDipositNo);
                }
                _OutletDepositNo = sCode + "-" + nMaxDipositNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_OutletDeposit VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OutletDepositID", _OutletDepositID);
                cmd.Parameters.AddWithValue("OutletDepositNo", _OutletDepositNo);
                cmd.Parameters.AddWithValue("CustomerID", _CustomerID);    
                cmd.Parameters.AddWithValue("TranDate", _TranDate);
                cmd.Parameters.AddWithValue("Remarks", _Remarks);          
                cmd.Parameters.AddWithValue("UserID", _UserID);
                cmd.Parameters.AddWithValue("EntryDate", DateTime.Now);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "Update T_Next_ID Set NEXT_ID = ? Where OID=7 ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("NEXT_ID", nMaxDipositNo + 1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                foreach (OutletDepositDetail oItem in this)
                {
                    oItem.OutletDepositID = _OutletDepositID;
                    oItem.Insert();
                }

                foreach (OutletDepositInvoice oItem in oOutletDepositInvoices)
                {
                    oItem.OutletDepositID = _OutletDepositID;
                    oItem.Insert();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }            
        }
        public void RefreshDetail()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();        

            string sSql = "SELECT * FROM t_OutletDepositDetail where OutletDepositID =?";
            cmd.Parameters.AddWithValue("OutletDepositID", _OutletDepositID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletDepositDetail oOutletDepositDetail = new OutletDepositDetail();

                    oOutletDepositDetail.OutletDepositID = (int)reader["OutletDepositID"];
                    oOutletDepositDetail.DepositBankBranch = (int)reader["DepositBankBranch"];
                    oOutletDepositDetail.DepositTypeID = (int)reader["DepositTypeID"];
                    oOutletDepositDetail.Amount = (double)reader["Amount"];

                    InnerList.Add(oOutletDepositDetail);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public DSDCS RefreshDetailForReport(DSDCS oDSDCS)
        {
         
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_OutletDepositDetail where OutletDepositID =?";
            cmd.Parameters.AddWithValue("OutletDepositID", _OutletDepositID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSDCS.DepositDetailRow oDepositDetailRow = oDSDCS.DepositDetail.NewDepositDetailRow();


                    oDepositDetailRow.Amout = (double)reader["Amount"];

                    Branch oBranch = new Branch();
                    oBranch.BranchID = (int)reader["DepositBankBranch"];
                    oBranch.Refresh();
                    Bank oBank = new Bank();
                    oBank.BankID = oBranch.BankID;
                    oBank.Refresh();
                    oDepositDetailRow.BankBranch = oBank.Name + "/" + oBranch.Name;
                    oDepositDetailRow.DepositType = Enum.GetName(typeof(Dictionary.InstrumentType), (int)reader["DepositTypeID"]);

                    oDSDCS.DepositDetail.AddDepositDetailRow(oDepositDetailRow);
                    oDSDCS.AcceptChanges();
                   
                }
                reader.Close();
              

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return oDSDCS;
        }
    }
    public class OutletDeposits : CollectionBase
    {

        public OutletDeposit this[int i]
        {
            get { return (OutletDeposit)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(OutletDeposit oOutletDeposit)
        {
            InnerList.Add(oOutletDeposit);
        }

        public void Refresh(DateTime dtFromDate, DateTime dtToDate, int nCustomerID,string sDepositNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dtToDate = dtToDate.AddDays(1);

            string sSql = "SELECT * FROM t_OutletDeposit where TranDate Between '" + dtFromDate + "' and '" + dtToDate + "' and TranDate < '" + dtToDate + "'"
                           + " and CustomerID=?";
            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
            if (sDepositNo != "")
            {
                sSql = sSql + " and OutletDepositNo='" + sDepositNo + "'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletDeposit oOutletDeposit = new OutletDeposit();

                    oOutletDeposit.OutletDepositID = (int)reader["OutletDepositID"];
                    oOutletDeposit.OutletDepositNo = (string)reader["OutletDepositNo"];
                    oOutletDeposit.Remarks = (string)reader["Remarks"];
                    oOutletDeposit.TranDate = (DateTime)reader["TranDate"];
                    oOutletDeposit.RefreshDetail();
                    oOutletDeposit.oOutletDepositInvoices = new OutletDepositInvoices();
                    oOutletDeposit.oOutletDepositInvoices.Refresh(oOutletDeposit.OutletDepositID);

                    InnerList.Add(oOutletDeposit);
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

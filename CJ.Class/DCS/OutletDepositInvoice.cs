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
    public class OutletDepositInvoice
    {
        private int _OutletDepositID;
        private string _InvoiceNo;
        private int _InstrumentTypeID;
        private string _InstrumentNo;
        private DateTime _InstrumentDate;
        private int _InstrumentBankBranch;
        private string _InstrumentBankBranchName;
        private double _Amount;
        private string _InstrumentType;

        /// <summary>
        /// Get set property for OutletDepositID
        /// </summary>
        public int OutletDepositID
        {
            get { return _OutletDepositID; }
            set { _OutletDepositID = value; }
        }

        /// <summary>
        /// Get set property for InvoiceNo
        /// </summary>
        public string InvoiceNo
        {
            get { return _InvoiceNo; }
            set { _InvoiceNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for InstrumentTypeID
        /// </summary>
        public int InstrumentTypeID
        {
            get { return _InstrumentTypeID; }
            set { _InstrumentTypeID = value; }
        }

        /// <summary>
        /// Get set property for InstrumentNo
        /// </summary>
        public string InstrumentNo
        {
            get { return _InstrumentNo; }
            set { _InstrumentNo = value.Trim(); }
        }

        /// <summary>
        /// Get set property for InstrumentDate
        /// </summary>
        public DateTime InstrumentDate
        {
            get { return _InstrumentDate; }
            set { _InstrumentDate = value; }
        }

        /// <summary>
        /// Get set property for InstrumentBankBranch
        /// </summary>
        public int InstrumentBankBranch
        {
            get { return _InstrumentBankBranch; }
            set { _InstrumentBankBranch = value; }
        }
        public string InstrumentBankBranchName
        {
            get { return _InstrumentBankBranchName; }
            set { _InstrumentBankBranchName = value; }
        }

        /// <summary>
        /// Get set property for Amount
        /// </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        public string InstrumentType
        {
            get { return _InstrumentType; }
            set { _InstrumentType = value; }
        }

        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_OutletDepositInvoice VALUES (?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OutletDepositID", _OutletDepositID);
                cmd.Parameters.AddWithValue("InvoiceNo", _InvoiceNo);
                cmd.Parameters.AddWithValue("InstrumentTypeID", _InstrumentTypeID);
                if (_InstrumentTypeID != (int)Dictionary.InstrumentType.CASH)
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                    cmd.Parameters.AddWithValue("InstrumentBankBranch", _InstrumentBankBranch);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", null);
                    cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                    cmd.Parameters.AddWithValue("InstrumentBankBranch", null);
                }
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
    public class OutletDepositInvoices : CollectionBase
    {

        public OutletDepositInvoice this[int i]
        {
            get { return (OutletDepositInvoice)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(OutletDepositInvoice oOutletDepositInvoice)
        {
            InnerList.Add(oOutletDepositInvoice);
        }
        public void Refresh(int nOutletDepositID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_OutletDepositInvoice where OutletDepositID =?";
            cmd.Parameters.AddWithValue("OutletDepositID", nOutletDepositID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletDepositInvoice oOutletDepositInvoice = new  OutletDepositInvoice();

                    oOutletDepositInvoice.OutletDepositID = (int)reader["OutletDepositID"];
                    oOutletDepositInvoice.InvoiceNo = (string)reader["InvoiceNo"];
                    oOutletDepositInvoice.InstrumentTypeID = (int)reader["InstrumentTypeID"];
                    if ((int)reader["InstrumentTypeID"] != (int)Dictionary.InstrumentType.CASH)
                    {
                        oOutletDepositInvoice.InstrumentNo = (string)reader["InstrumentNo"];
                        oOutletDepositInvoice.InstrumentBankBranch = (int)reader["InstrumentBankBranch"];
                    }
                    else
                    {
                        oOutletDepositInvoice.InstrumentNo = "";
                        oOutletDepositInvoice.InstrumentBankBranch = 0;
                    }

                    oOutletDepositInvoice.InstrumentDate = (DateTime)reader["InstrumentDate"];                     
                    oOutletDepositInvoice.Amount = (double)reader["Amount"];


                    InnerList.Add(oOutletDepositInvoice);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DSDCS RefreshForReport(DSDCS oDSDCS, int nOutletDepositID)
        {
          
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_OutletDepositInvoice where OutletDepositID =?";
            cmd.Parameters.AddWithValue("OutletDepositID", nOutletDepositID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSDCS.InstrumnetDetailRow oInstrumnetDetailRow = oDSDCS.InstrumnetDetail.NewInstrumnetDetailRow();

                    oInstrumnetDetailRow.InvoiceNo = (string)reader["InvoiceNo"];                 
                    oInstrumnetDetailRow.InstrumentType = Enum.GetName(typeof(Dictionary.InstrumentType), (int)reader["InstrumentTypeID"]);

                    if ((int)reader["InstrumentTypeID"] != (int)Dictionary.InstrumentType.CASH)
                    {
                        oInstrumnetDetailRow.InstrumentNo = (string)reader["InstrumentNo"];

                        Branch oBranch = new Branch();
                        oBranch.BranchID = (int)reader["InstrumentBankBranch"];
                        oBranch.Refresh();
                        Bank oBank = new Bank();
                        oBank.BankID = oBranch.BankID;
                        oBank.Refresh();
                        oInstrumnetDetailRow.BankBranch = oBank.Name + "/" + oBranch.Name;
                    }
                    else
                    {
                        oInstrumnetDetailRow.InstrumentNo = "";
                        oInstrumnetDetailRow.BankBranch = "";
                    }
                    oInstrumnetDetailRow.InstrumentDate = (DateTime)reader["InstrumentDate"];
                    oInstrumnetDetailRow.Amount = (double)reader["Amount"];

                    oDSDCS.InstrumnetDetail.AddInstrumnetDetailRow(oInstrumnetDetailRow);
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
}

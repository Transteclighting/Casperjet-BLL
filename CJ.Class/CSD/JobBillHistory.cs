// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Feb 05, 2017
// Time : 11:04 AM
// Description: Class for CSDJobBillHistory.
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
    public class CSDJobBillHistory
    {
        private int _nBillID;
        private double _ReceiveableAmount;
        private double _SCDiscount;
        private double _SPDiscount;
        private double _NetPayable;
        private double _ReceiveAmount;
        private DateTime _dReceiveDate;
        private int _nInstrumentType;
        private DateTime _dInstrumentDate;
        private int _nBankID;
        private string _sInstrumentNo;
        private string _sBillRemarks;
        private string _sMoneyReceiptNo;
        private int _nReceiveType;


        // <summary>
        // Get set property for BillID
        // </summary>
        public int BillID
        {
            get { return _nBillID; }
            set { _nBillID = value; }
        }

        // <summary>
        // Get set property for ReceiveableAmount
        // </summary>
        public double ReceiveableAmount
        {
            get { return _ReceiveableAmount; }
            set { _ReceiveableAmount = value; }
        }

        // <summary>
        // Get set property for SCDiscount
        // </summary>
        public double SCDiscount
        {
            get { return _SCDiscount; }
            set { _SCDiscount = value; }
        }

        // <summary>
        // Get set property for SPDiscount
        // </summary>
        public double SPDiscount
        {
            get { return _SPDiscount; }
            set { _SPDiscount = value; }
        }

        // <summary>
        // Get set property for NetPayable
        // </summary>
        public double NetPayable
        {
            get { return _NetPayable; }
            set { _NetPayable = value; }
        }

        // <summary>
        // Get set property for ReceiveAmount
        // </summary>
        public double ReceiveAmount
        {
            get { return _ReceiveAmount; }
            set { _ReceiveAmount = value; }
        }

        // <summary>
        // Get set property for ReceiveDate
        // </summary>
        public DateTime ReceiveDate
        {
            get { return _dReceiveDate; }
            set { _dReceiveDate = value; }
        }

        // <summary>
        // Get set property for InstrumentType
        // </summary>
        public int InstrumentType
        {
            get { return _nInstrumentType; }
            set { _nInstrumentType = value; }
        }
        public int ReceiveType
        {
            get { return _nReceiveType; }
            set { _nReceiveType = value; }
        }

        // <summary>
        // Get set property for InstrumentDate
        // </summary>
        public DateTime InstrumentDate
        {
            get { return _dInstrumentDate; }
            set { _dInstrumentDate = value; }
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
        // Get set property for InstrumentNo
        // </summary>
        public string InstrumentNo
        {
            get { return _sInstrumentNo; }
            set { _sInstrumentNo = value.Trim(); }
        }

        // <summary>
        // Get set property for BillRemarks
        // </summary>
        public string BillRemarks
        {
            get { return _sBillRemarks; }
            set { _sBillRemarks = value.Trim(); }
        }

        // <summary>
        // Get set property for MoneyReceiptNo
        // </summary>
        public string MoneyReceiptNo
        {
            get { return _sMoneyReceiptNo; }
            set { _sMoneyReceiptNo = value.Trim(); }
        }

        private int _nIsPending;
        public int IsPending
        {
            get { return _nIsPending; }
            set { _nIsPending = value; }
        }
        public void Add()
        {
            //int nMaxBillID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                //sSql = "SELECT MAX([BillID]) FROM t_CSDJobBillHistory";
                //cmd.CommandText = sSql;
                //object maxID = cmd.ExecuteScalar();
                //if (maxID == DBNull.Value)
                //{
                //    nMaxBillID = 1;
                //}
                //else
                //{
                //    nMaxBillID = Convert.ToInt32(maxID) + 1;
                //}
                //_nBillID = nMaxBillID;

                sSql = "INSERT INTO t_CSDJobBillHistory (BillID, ReceiveableAmount, SCDiscount, SPDiscount, NetPayable, "+
                " ReceiveAmount, ReceiveDate, InstrumentType, InstrumentDate, BankID, InstrumentNo, BillRemarks, MoneyReceiptNo, "+ 
                " IsPending,ReceiveType) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("BillID", _nBillID);
                cmd.Parameters.AddWithValue("ReceiveableAmount", _ReceiveableAmount);
                cmd.Parameters.AddWithValue("SCDiscount", _SCDiscount);
                cmd.Parameters.AddWithValue("SPDiscount", _SPDiscount);
                cmd.Parameters.AddWithValue("NetPayable", _NetPayable);
                cmd.Parameters.AddWithValue("ReceiveAmount", _ReceiveAmount);
                cmd.Parameters.AddWithValue("ReceiveDate", _dReceiveDate);
                cmd.Parameters.AddWithValue("InstrumentType", _nInstrumentType);
                cmd.Parameters.AddWithValue("InstrumentDate", _dInstrumentDate);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("InstrumentNo", _sInstrumentNo);
                cmd.Parameters.AddWithValue("BillRemarks", _sBillRemarks);
                cmd.Parameters.AddWithValue("MoneyReceiptNo", _sMoneyReceiptNo);
                cmd.Parameters.AddWithValue("IsPending", _nIsPending);
                cmd.Parameters.AddWithValue("ReceiveType", _nReceiveType);

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
                sSql = "UPDATE t_CSDJobBillHistory SET ReceiveableAmount = ?, SCDiscount = ?, SPDiscount = ?, NetPayable = ?, ReceiveAmount = ?, ReceiveDate = ?, InstrumentType = ?, InstrumentDate = ?, BankID = ?, InstrumentNo = ?, BillRemarks = ?, MoneyReceiptNo = ? WHERE BillID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ReceiveableAmount", _ReceiveableAmount);
                cmd.Parameters.AddWithValue("SCDiscount", _SCDiscount);
                cmd.Parameters.AddWithValue("SPDiscount", _SPDiscount);
                cmd.Parameters.AddWithValue("NetPayable", _NetPayable);
                cmd.Parameters.AddWithValue("ReceiveAmount", _ReceiveAmount);
                cmd.Parameters.AddWithValue("ReceiveDate", _dReceiveDate);
                cmd.Parameters.AddWithValue("InstrumentType", _nInstrumentType);
                cmd.Parameters.AddWithValue("InstrumentDate", _dInstrumentDate);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("InstrumentNo", _sInstrumentNo);
                cmd.Parameters.AddWithValue("BillRemarks", _sBillRemarks);
                cmd.Parameters.AddWithValue("MoneyReceiptNo", _sMoneyReceiptNo);

                cmd.Parameters.AddWithValue("BillID", _nBillID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateHistoryStatus(int nBillID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "Update t_CSDJobBillHistory set IsPending=" + (int)Dictionary.YesOrNoStatus.NO + ", ReceiveDate=getdate() where BillID In ( " +
                    "Select BillID From t_CSDJobBill where JobID in ( " +
                    "Select JobID From t_CSDJobBillSendItem where BillID=" + nBillID + ")) " +
                    "and IsPending=" + (int)Dictionary.YesOrNoStatus.YES + "";

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
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_CSDJobBillHistory WHERE [BillID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("BillID", _nBillID);
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
                cmd.CommandText = "SELECT * FROM t_CSDJobBillHistory where BillID =?";
                cmd.Parameters.AddWithValue("BillID", _nBillID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nBillID = (int)reader["BillID"];
                    _ReceiveableAmount = Convert.ToDouble(reader["ReceiveableAmount"].ToString());
                    _SCDiscount = Convert.ToDouble(reader["SCDiscount"].ToString());
                    _SPDiscount = Convert.ToDouble(reader["SPDiscount"].ToString());
                    _NetPayable = Convert.ToDouble(reader["NetPayable"].ToString());
                    _ReceiveAmount = Convert.ToDouble(reader["ReceiveAmount"].ToString());
                    _dReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());
                    _nInstrumentType = (int)reader["InstrumentType"];
                    _dInstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                    _nBankID = (int)reader["BankID"];
                    _sInstrumentNo = (string)reader["InstrumentNo"];
                    _sBillRemarks = (string)reader["BillRemarks"];
                    _sMoneyReceiptNo = (string)reader["MoneyReceiptNo"];
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
    public class CSDJobBillHistorys : CollectionBase
    {
        public CSDJobBillHistory this[int i]
        {
            get { return (CSDJobBillHistory)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDJobBillHistory oCSDJobBillHistory)
        {
            InnerList.Add(oCSDJobBillHistory);
        }
        public int GetIndex(int nBillID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].BillID == nBillID)
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
            string sSql = "SELECT * FROM t_CSDJobBillHistory";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDJobBillHistory oCSDJobBillHistory = new CSDJobBillHistory();
                    oCSDJobBillHistory.BillID = (int)reader["BillID"];
                    oCSDJobBillHistory.ReceiveableAmount = Convert.ToDouble(reader["ReceiveableAmount"].ToString());
                    oCSDJobBillHistory.SCDiscount = Convert.ToDouble(reader["SCDiscount"].ToString());
                    oCSDJobBillHistory.SPDiscount = Convert.ToDouble(reader["SPDiscount"].ToString());
                    oCSDJobBillHistory.NetPayable = Convert.ToDouble(reader["NetPayable"].ToString());
                    oCSDJobBillHistory.ReceiveAmount = Convert.ToDouble(reader["ReceiveAmount"].ToString());
                    oCSDJobBillHistory.ReceiveDate = Convert.ToDateTime(reader["ReceiveDate"].ToString());
                    oCSDJobBillHistory.InstrumentType = (int)reader["InstrumentType"];
                    oCSDJobBillHistory.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                    if (reader["BankID"] != DBNull.Value)
                    {
                        oCSDJobBillHistory.BankID = Convert.ToInt32(reader["BankID"]);
                    }                    
                    oCSDJobBillHistory.InstrumentNo = (string)reader["InstrumentNo"];
                    if (reader["BillRemarks"] != DBNull.Value)
                    {
                        oCSDJobBillHistory.BillRemarks = (string)reader["BillRemarks"];
                    }
                    if (reader["MoneyReceiptNo"] != DBNull.Value)
                    {
                        oCSDJobBillHistory.MoneyReceiptNo = (string)reader["MoneyReceiptNo"];
                    }
                    InnerList.Add(oCSDJobBillHistory);
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


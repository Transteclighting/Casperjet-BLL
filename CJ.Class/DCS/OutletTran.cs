// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arifur Rahman Khan
// Date: 20-Feb-2013
// Time :  03:23 PM
// Description: Class for DCS (OutletTran)
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;


namespace CJ.Class.DCS
{
    public class OutletTranDetail
    {
        private int _OutletTranID;
        private int _TranTypeID;
        private int _TranSerial;
        private string _InstrumentType;
        private string _InstrumentNo;
        private DateTime _InstrumentDate;
        private int _BankID;
        private string _BankBranchName;
        private string _BankAccountNo;
        private string _InvoiceNo;
        private double _Amount;


        /// <summary>
        /// Get set property for OutletTranID
        /// </summary>
        public int OutletTranID
        {
            get { return _OutletTranID; }
            set { _OutletTranID = value; }
        }

        /// <summary>
        /// Get set property for DepositBankBranch
        /// </summary>
        /// 
        public int TranTypeID
        {
            get { return _TranTypeID; }
            set { _TranTypeID = value; }
        }
        
        /// <summary>
        /// Get set property for TranSerial
        /// </summary>
        public int TranSerial
        {
            get { return _TranSerial; }
            set { _TranSerial = value; }
        }

        public string InstrumentType
        {
            get { return _InstrumentType; }
            set { _InstrumentType = value; }
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

        public int BankID
        {
            get { return _BankID; }
            set { _BankID = value; }
        }
        public string BankBranchName
        {
            get { return _BankBranchName; }
            set { _BankBranchName = value; }
        }

        public string BankAccountNo
        {
            get { return _BankAccountNo; }
            set { _BankAccountNo = value; }
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
        /// Get set property for Amount
        /// </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        
        public void Insert()
        {
            string sSql = "";
            int nMaxSerialNo = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                sSql = "SELECT MAX([TranSerial]) FROM t_OutletTranDetail WHERE OutletTranID=? AND TranTypeID=?";
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("OutletTranID", _OutletTranID);
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxSerialNo = 1;
                }
                else
                {
                    nMaxSerialNo = Convert.ToInt32(maxID) + 1;
                }
                _TranSerial = nMaxSerialNo;

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO t_OutletTranDetail(OutletTranID,TranTypeID,"
                    + " TranSerial,InstrumentType,Amount,InstrumentNo,InstrumentDate,InvoiceNo,"
                    + " BankAccountNo, BankBranchName) VALUES (?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("OutletTranID", _OutletTranID);                
                cmd.Parameters.AddWithValue("TranTypeID", _TranTypeID);
                cmd.Parameters.AddWithValue("TranSerial", _TranSerial);
                cmd.Parameters.AddWithValue("InstrumentType", _InstrumentType);
                cmd.Parameters.AddWithValue("Amount", _Amount);

                cmd.Parameters.AddWithValue("InstrumentNo", _InstrumentNo);
                cmd.Parameters.AddWithValue("InstrumentDate", _InstrumentDate);
                cmd.Parameters.AddWithValue("InvoiceNo", _InvoiceNo);
                cmd.Parameters.AddWithValue("BankAccountNo", _BankAccountNo);
                cmd.Parameters.AddWithValue("BankBranchName", _BankBranchName);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class OutletTran : CollectionBase
    {
        public OutletTranDetail this[int i]
        {
            get { return (OutletTranDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(OutletTranDetail oOutletTranDetail)
        {
            InnerList.Add(oOutletTranDetail);
        }

        private int _OutletTranID;
        private string _OutletTranNo;
        private int _CustomerID;
        private DateTime _TranDate;
        private string _Remarks;
        private int _UserID;

        /// <summary>
        /// Get set property for OutletTranID
        /// </summary>
        public int OutletTranID
        {
            get { return _OutletTranID; }
            set { _OutletTranID = value; }
        }

        /// <summary>
        /// Get set property for OutletTranNo
        /// </summary>
        public string OutletTranNo
        {
            get { return _OutletTranNo; }
            set { _OutletTranNo = value.Trim(); }
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
                sSql = "SELECT MAX([OutletTranID]) FROM t_OutletTran";
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
                _OutletTranID = nMaxID;

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
                _OutletTranNo = sCode + "-" + nMaxDipositNo.ToString();

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                sSql = "INSERT INTO t_OutletTran VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("OutletTranID", _OutletTranID);
                cmd.Parameters.AddWithValue("OutletTranNo", _OutletTranNo);
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

                foreach (OutletTranDetail oItem in this)
                {
                    oItem.OutletTranID = _OutletTranID;
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

            string sSql = "SELECT * FROM t_OutletTranDetail where OutletTranID =?";
            cmd.Parameters.AddWithValue("OutletTranID", _OutletTranID);
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletTranDetail oOutletTranDetail = new OutletTranDetail();

                    oOutletTranDetail.OutletTranID = (int)reader["OutletTranID"];
                    oOutletTranDetail.TranTypeID = (int)reader["TranTypeID"];
                    oOutletTranDetail.TranSerial = (int)reader["TranSerial"];
                    oOutletTranDetail.InstrumentType = (string)reader["InstrumentType"];
                    oOutletTranDetail.Amount = (double)reader["Amount"];

                    if (reader["InstrumentNo"] != DBNull.Value)
                        oOutletTranDetail.InstrumentNo = (string)reader["InstrumentNo"];
                    if (reader["InstrumentDate"] != DBNull.Value)
                        oOutletTranDetail.InstrumentDate = (DateTime)reader["InstrumentDate"];
                    if (reader["InvoiceNo"] != DBNull.Value)
                        oOutletTranDetail.InvoiceNo = (string)reader["InvoiceNo"];
                    if (reader["BankAccountNo"] != DBNull.Value)
                        oOutletTranDetail.BankAccountNo = (string)reader["BankAccountNo"];
                    if (reader["BankBranchName"] != DBNull.Value)
                    oOutletTranDetail.BankBranchName = (string)reader["BankBranchName"];
                    
                    InnerList.Add(oOutletTranDetail);
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

            string sSql = "SELECT * FROM t_OutletTranDetail where OutletTranID =?";
            cmd.Parameters.AddWithValue("OutletTranID", _OutletTranID);
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
                    oDepositDetailRow.DepositType = Enum.GetName(typeof(Dictionary.InstrumentType), (int)reader["TranTypeID"]);

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
    public class OutletTrans : CollectionBase
    {

        public OutletTran this[int i]
        {
            get { return (OutletTran)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(OutletTran oOutletTran)
        {
            InnerList.Add(oOutletTran);
        }

        public void Refresh(DateTime dtFromDate, DateTime dtToDate, int nCustomerID, string sDepositNo)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            dtToDate = dtToDate.AddDays(1);

            string sSql = "SELECT * FROM t_OutletTran where TranDate Between '" + dtFromDate + "' and '" + dtToDate + "' and TranDate < '" + dtToDate + "'"
                           + " and CustomerID=?";
            cmd.Parameters.AddWithValue("CustomerID", nCustomerID);
            if (sDepositNo != "")
            {
                sSql = sSql + " and OutletTranNo='" + sDepositNo + "'";
            }
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletTran oOutletTran = new OutletTran();

                    oOutletTran.OutletTranID = (int)reader["OutletTranID"];
                    oOutletTran.OutletTranNo = (string)reader["OutletTranNo"];
                    oOutletTran.Remarks = (string)reader["Remarks"];
                    oOutletTran.TranDate = (DateTime)reader["TranDate"];
                    oOutletTran.CustomerID = (int)reader["CustomerID"]; 
                    oOutletTran.RefreshDetail();
                    //oOutletTran.oOutletTranInvoices = new OutletTranInvoices();
                    //oOutletTran.oOutletTranInvoices.Refresh(oOutletTran.OutletTranID);

                    InnerList.Add(oOutletTran);
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



    public class OutletTranType
    {
        private int _nTranTypeID;
        private string _sTranTypeName;
        private int _nTranSide;


        /// <summary>
        /// Get set property for OutletTranID
        /// </summary>
        public int TranTypeID
        {
            get { return _nTranTypeID; }
            set { _nTranTypeID = value; }
        }

        /// <summary>
        /// Get set property for TranTypeName
        /// </summary>
        /// 
        public string TranTypeName
        {
            get { return _sTranTypeName; }
            set { _sTranTypeName = value; }
        }

        /// <summary>
        /// Get set property for TranSide
        /// </summary>
        /// 
        public int TranSide
        {
            get { return _nTranSide; }
            set { _nTranSide = value; }
        }



        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_OutletTranType VALUES (?,?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("TranTypeID", _nTranTypeID);
                cmd.Parameters.AddWithValue("TranTypeName", _sTranTypeName);
                cmd.Parameters.AddWithValue("TranSide", _nTranSide);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class OutletTranTypes : CollectionBase
    {
        public OutletTranType this[int i]
        {
            get { return (OutletTranType)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public OutletTranType GetOutletTranType(int nOutletTranTypeID)
        {
            foreach (OutletTranType oItem in this)
            {
                if (oItem.TranTypeID == nOutletTranTypeID)
                    return oItem;
            }
            return null;
        }

        public void Add(OutletTranType oOutletTranType)
        {
            InnerList.Add(oOutletTranType);
        }

        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_OutletTranType";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OutletTranType oOutletTranType = new OutletTranType();

                    oOutletTranType.TranTypeID = (int)reader["TranTypeID"];
                    oOutletTranType.TranTypeName = (string)reader["TranTypeName"]; 
                    oOutletTranType.TranSide = (int)reader["TranSide"];

                    InnerList.Add(oOutletTranType);
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


    public class InstrumentType
    {
        private int _nInstrumentTypeID;
        private string _sInstrumentTypeName;
        //private int _nTranSide;


        /// <summary>
        /// Get set property for OutletTranID
        /// </summary>
        public int InstrumentTypeID
        {
            get { return _nInstrumentTypeID; }
            set { _nInstrumentTypeID = value; }
        }

        /// <summary>
        /// Get set property for InstrumentTypeName
        /// </summary>
        /// 
        public string InstrumentTypeName
        {
            get { return _sInstrumentTypeName; }
            set { _sInstrumentTypeName = value; }
        }

        ///// <summary>
        ///// Get set property for TranSide
        ///// </summary>
        ///// 
        //public int TranSide
        //{
        //    get { return _nTranSide; }
        //    set { _nTranSide = value; }
        //}



        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "INSERT INTO t_InstrumentType VALUES (?,?)";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("InstrumentTypeID", _nInstrumentTypeID);
                cmd.Parameters.AddWithValue("InstrumentTypeName", _sInstrumentTypeName);
                //cmd.Parameters.AddWithValue("TranSide", _nTranSide);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class InstrumentTypes : CollectionBase
    {
        public OutletTranDetail this[int i]
        {
            get { return (OutletTranDetail)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(OutletTranDetail oOutletTranDetail)
        {
            InnerList.Add(oOutletTranDetail);
        }

        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_InstrumentType";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InstrumentType oInstrumentType = new InstrumentType();

                    oInstrumentType.InstrumentTypeID = (int)reader["InstrumentTypeID"];
                    oInstrumentType.InstrumentTypeName = (string)reader["InstrumentTypeName"];
                    //oInstrumentType.TranSide = (int)reader["TranSide"];

                    InnerList.Add(oInstrumentType);
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

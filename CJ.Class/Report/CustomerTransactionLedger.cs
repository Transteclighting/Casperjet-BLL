// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak k. Chakraborty
// Date: July 13, 2011
// Time" :  04:09 PM
// Description: Customer Transaction ledger [800]
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Report
{
    [Serializable]
    public class CustomerTransactionLedger
    {
        private long _lTranID;
        private string _sTranNo;
        private long _lCustomerID;
        private string _sCustomerCode;
        private string _sCustomerName;
        private string _sCustomerAddress;
        private string _sCustomerTelephone;
        private string _sCellphoneNo;
        private string _sContractperson;
        private DateTime _dTranDate;
        private double _Amount;
        private string _sInstrumentNo;
        private DateTime _dInstrumentDate;
        private int _sInstrumentType;
        private int _nInstrumentStatus;

        private long _lBranchID;
        private string _sBranchName;
        private long _lEntryUserID;
        private DateTime _dEntryDate;
        private long _lUpdateUserID;
        private DateTime _dUpdatedate;
        private string _sRemarks;
        private double _Unadjustedamount;

        private int _nUploadStatus;
        private DateTime _dUploadDate;
        private DateTime _dDownloadDate;
        private int _nRowStatus;
        private int _nTerminal;
        private long _lTranTypeID;
        //private long _lCustomerID2;
        private string _sTranTypeCode;
        private string _sTranTypeName;
        private int _sTranSide;
        private double _Debit;
        private double _Credit;
        private string _sInstType;
        private string _sDebitAmount;
        private string _sCreditAmount;
        private double _OpeningOS;
        private double _Outstanding;
        private double _OpeningOutstanding;
        private double _temp;
        //private double _MnCrLimit;
        //private double _MxCrLimit;
              

       
        public long TranID
        {
            get { return _lTranID; }
            set { _lTranID = value; }
        }
        public string TranNo
        {
            get { return _sTranNo; }
            set { _sTranNo = value; }
        }

        public long CustomerID
        {
            get { return _lCustomerID; }
            set { _lCustomerID = value; }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }

        }
        public string CustomerAddress
        {
            get { return _sCustomerAddress; }
            set { _sCustomerAddress = value; }

        }
        public string CustomerTelephone
        {
            get { return _sCustomerTelephone; }
            set { _sCustomerTelephone = value; }

        }
        public string CellphoneNo
        {
            get { return _sCellphoneNo; }
            set { _sCellphoneNo = value; }

        }
        public string Contractperson
        {
            get { return _sContractperson; }
            set { _sContractperson = value; }

        }
        public DateTime TranDate
        {
            get { return _dTranDate; }
            set { _dTranDate = value; }
        }               
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        public string InstrumentNo
        {
            get { return _sInstrumentNo; }
            set { _sInstrumentNo = value; }
        }
        public DateTime InstrumentDate
        {
            get { return _dInstrumentDate; }
            set { _dInstrumentDate = value; }
        }
        public int InstrumentType
        {
            get { return _sInstrumentType; }
            set { _sInstrumentType = value; }
        }
        public int InstrumentStatus
        {
            get { return _nInstrumentStatus; }
            set { _nInstrumentStatus = value; }
        }
        public long BranchID
        {
            get { return _lBranchID; }
            set { _lBranchID = value; }
        }
        public string BranchName
        {
            get { return _sBranchName; }
            set { _sBranchName = value; }
        }
        public long EntryUserID
        {
            get { return _lEntryUserID; }
            set { _lEntryUserID = value; }
        }
        public DateTime EntryDate
        {
            get { return _dEntryDate; }
            set { _dEntryDate = value; }
        }
        public long UpdateUserID
        {
            get { return _lUpdateUserID; }
            set { _lUpdateUserID = value; }
        }
        public DateTime Updatedate
        {
            get { return _dUpdatedate; }
            set { _dUpdatedate = value; }
        }
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value; }
        }
        public double Unadjustedamount
        {
            get { return _Unadjustedamount; }
            set { _Unadjustedamount = value; }
        }
        public int UploadStatus
        {
            get { return _nUploadStatus; }
            set { _nUploadStatus = value; }
        }
        public DateTime UploadDate
        {
            get { return _dUploadDate; }
            set { _dUploadDate = value; }
        }

        public DateTime DownloadDate
        {
            get { return _dDownloadDate; }
            set { _dDownloadDate = value; }
        }
        public int RowStatus
        {
            get { return _nRowStatus; }
            set { _nRowStatus = value; }
        }
        public int Terminal
        {         
            get { return _nTerminal; }
            set { _nTerminal = value; }
                    
        }
        
        public long TranTypeID
        {
            get { return _lTranTypeID; }
            set { _lTranTypeID = value; }
        }
        //public long CustomerID2
        //{
        //    get { return _lCustomerID2 ; }
        //    set { _lCustomerID2 = value; }
        //}

        public string TranTypeCode
        {
            get { return _sTranTypeCode; }
            set { _sTranTypeCode = value; }
        
        }
        public string TranTypeName
        {
            get { return _sTranTypeName; }
            set { _sTranTypeName = value; }
        }

        public int TranSide
        {
            get { return _sTranSide; }
            set { _sTranSide = value; }
        }
        public double Debit
        {
            get { return _Debit; }
            set { _Debit = value; }
        }
        public double Credit
        {
            get { return _Credit; }
            set { _Credit = value; }
        }
        public string InstType
        {
            get { return _sInstType; }
            set { _sInstType = value; }
        }
        public string DebitAmount
        {
            get { return _sDebitAmount; }
            set { _sDebitAmount = value; }
        }
        public string CreditAmount
        {
            get { return _sCreditAmount ; }
            set { _sCreditAmount = value; }
        }
        public double OpeningOS
        {
            get { return _OpeningOS; }
            set { _OpeningOS = value; }
        }
        public double Outstanding
        {
            get { return _Outstanding; }
            set { _Outstanding = value; }
        }

        public double OpeningOutstanding
        {
            get { return _OpeningOutstanding; }
            set { _OpeningOutstanding = value; }
        }
        public double Temp
        {
            get { return _temp; }
            set { _temp = value; }
        }

        private string _sAccountStatus;
        public string AccountStatus
        {
            get { return _sAccountStatus; }
            set { _sAccountStatus = value; }
        }

        //public double MnCrLimit
        //{
        //    get { return _MnCrLimit; }
        //    set { _MnCrLimit = value; }
        //}

        //public double MxCrLimit
        //{
        //    get { return _MxCrLimit; }
        //    set { _MxCrLimit = value; }
        //}

   

       
    }

    public class CustomerTransactionLedgerDetails : CollectionBaseCustom
    {
        public void Add(CustomerTransactionLedger oCustomerTransactionLedger)
        {
            this.List.Add(oCustomerTransactionLedger);
        }    
        public CustomerTransactionLedger this[Int32 Index]
        {
            get
            {
                return (CustomerTransactionLedger)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(CustomerTransactionLedger))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public double CustomerTransection(DateTime dYFromDate, DateTime dYToDate, int nCustomerID,bool IsMainReport)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nCount = 0;
            double _OS = 0;
            double _TotalDebit = 0;
            double _TotalCredit = 0;

            double _ClosingOS = 0;
            // Query for the report [800 Old ]
            //StringBuilder sQueryStringMaster;
            //sQueryStringMaster = new StringBuilder();
            //sQueryStringMaster.Append(" select  details.CustomerID,details.CustomerCode,details.CustomerName, details.CustomerAddress, details.CustomerTelephone, details.CellphoneNo,details.Contractperson, Final.TranID,Final.TranNo, Final.TranDate,Final.TranTypeName, Final.InstrumentNo,Final.InstrumentType, Final.Debit,Final.Credit,Final.Remarks,Final.OpeningOS,IsNull(a.AccountStatus,'')as AccountStatus  from ");
            //sQueryStringMaster.Append(" (");
            //sQueryStringMaster.Append(" Select a.*, isnull(OpeningOS,0) as OpeningOS");
            //sQueryStringMaster.Append(" from");
            //sQueryStringMaster.Append(" (");
            //sQueryStringMaster.Append(" select q6.*,TranTypeCode,TranTypeName,TranSide,(case q7.TranSide When 1 then q6.Amount End) as Credit,(case q7.TranSide When 2 then q6.Amount End) as Debit ");
            //sQueryStringMaster.Append(" from ");
            //sQueryStringMaster.Append(" (");
            //sQueryStringMaster.Append(" select * from t_CustomerTran Where TranDate Between ? and ? and TranDate< ?  and CustomerID= ? ");
            //sQueryStringMaster.Append(" ) as q6 ");
            //sQueryStringMaster.Append("  Left Outer Join ");
            //sQueryStringMaster.Append(" (");
            //sQueryStringMaster.Append("select TranTypeID,TranTypeCode,TranTypeName,TranSide from t_CustomerTranType");
            //sQueryStringMaster.Append(" ) as q7 on q7.TranTypeID=q6.TranTypeID");
            //sQueryStringMaster.Append(" ) as a");
            //sQueryStringMaster.Append(" Left outer Join");
            //sQueryStringMaster.Append(" (");
            //sQueryStringMaster.Append(" Select q1.CustomerID,(((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0))*-1) as OpeningOS");
            //sQueryStringMaster.Append(" from");
            //sQueryStringMaster.Append(" ( ");
            //sQueryStringMaster.Append(" select customerid, CurrentBalance from t_customerAccount ");
            //sQueryStringMaster.Append(" ) ");
            //sQueryStringMaster.Append(" as q1  ");
            //sQueryStringMaster.Append(" left outer join");
            //sQueryStringMaster.Append(" (  ");
            //sQueryStringMaster.Append(" select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt ");
            //sQueryStringMaster.Append(" where ct.trantypeid = ctt.trantypeid and transide = 1 and ct.TranDate between ? and ?");
            //sQueryStringMaster.Append(" group by customerid  ");
            //sQueryStringMaster.Append(" )");
            //sQueryStringMaster.Append(" as q2");
            //sQueryStringMaster.Append(" on q1.customerid = q2.customerid ");
            //sQueryStringMaster.Append(" left outer join");
            //sQueryStringMaster.Append(" ( ");
            //sQueryStringMaster.Append(" select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt");
            //sQueryStringMaster.Append(" where ct.trantypeid = ctt.trantypeid and transide = 2  and ct.TranDate between ? and ? ");
            //sQueryStringMaster.Append(" group by customerid ");
            //sQueryStringMaster.Append(" ) as q3 ");
            //sQueryStringMaster.Append(" on q1.customerid = q3.customerid ");
            //sQueryStringMaster.Append(" ) as b on a.customerid = b.customerid");
            //sQueryStringMaster.Append(" ) as Final");
            //sQueryStringMaster.Append(" inner join");
            //sQueryStringMaster.Append(" (");
            //sQueryStringMaster.Append(" select * from v_customerdetails ) as details on Final.customerid = details.customerid ");
            //sQueryStringMaster.Append(" left outer join");
            //sQueryStringMaster.Append(" TELAddDB.dbo.t_AccountStatus a on a.customercode = details.customercode");
            //sQueryStringMaster.Append(" order by TranDate ");

            if (IsMainReport)
            {
                sSql = "select  details.CustomerID,details.CustomerCode,details.CustomerName, details.CustomerAddress, details.CustomerTelephone, details.CellphoneNo,details.Contractperson, Final.TranID,Final.TranNo, Final.TranDate,Final.TranTypeName, Final.InstrumentNo,Final.InstrumentType, Final.Debit,Final.Credit,Final.Remarks,Final.OpeningOS,IsNull(a.AccountStatus,'')as AccountStatus  from  " +
                    "(  " +
                    "Select a.*, isnull(OpeningOS, 0) as OpeningOS  " +
                    "from  " +
                    "(  " +
                    "select q6.*, TranTypeCode, TranTypeName, TranSide, (case q7.TranSide When 1 then q6.Amount End) as Credit, (case q7.TranSide When 2 then q6.Amount End) as Debit  " +
                    "from  " +
                    "(  " +
                    "select * from t_CustomerTran Where TranDate Between '" + dYFromDate.Date + "' and '" + dYToDate.AddDays(1) + "' and TranDate < '" + dYToDate.AddDays(1) + "' and CustomerID = " + nCustomerID + "  " +
                    ") as q6  " +
                    "Left Outer Join  " +
                    "(  " +
                    "Select TranTypeID, TranTypeCode, TranTypeName, TranSide from t_CustomerTranType  " +
                    ") as q7 on q7.TranTypeID = q6.TranTypeID  " +
                    ") as a  " +
                    "Left outer Join  " +
                    "(  " +
                    "Select q1.CustomerID, (((q1.CurrentBalance - isnull(q2.CreditAmount, 0)) + isnull(q3.DebitAmount, 0)) * -1) as OpeningOS  " +
                    "from  " +
                    "(  " +
                    "select customerid, CurrentBalance from t_customerAccount  " +
                    ")  " +
                    "as q1  " +
                    "left outer join  " +
                    "(  " +
                    "select customerid, sum(amount) as CreditAmount from t_customerTran ct, t_customerTrantype ctt  " +
                    "where ct.trantypeid = ctt.trantypeid and transide = 1 and ct.TranDate between '" + dYFromDate.Date + "' and '" + DateTime.Today.Date.AddDays(1) + "'  " +
                    "group by customerid  " +
                    ")  " +
                    "as q2  " +
                    "on q1.customerid = q2.customerid  " +
                    "left outer join  " +
                    "(  " +
                    "select customerid, sum(amount) as DebitAmount from t_customerTran ct, t_customerTrantype ctt  " +
                    "where ct.trantypeid = ctt.trantypeid and transide = 2  and ct.TranDate between '" + dYFromDate.Date + "' and '" + DateTime.Today.Date.AddDays(1) + "'  " +
                    "group by customerid  " +
                    ") as q3  " +
                    "on q1.customerid = q3.customerid  " +
                    ") as b on a.customerid = b.customerid  " +
                    ") as Final  " +
                    "inner join  " +
                    "(  " +
                    "select * from v_customerdetails ) as details on Final.customerid = details.customerid  " +
                    "left outer join  " +
                    "TELAddDB.dbo.t_AccountStatus a on a.customercode = details.customercode  " +
                    "order by TranDate";
            }

            else
            {
                sSql = "select  details.CustomerID,details.CustomerCode,details.CustomerName, details.CustomerAddress, details.CustomerTelephone,  " +
                    "details.CellphoneNo,details.Contractperson, Final.TranID,Final.TranNo, Final.TranDate,Final.TranTypeName, Final.InstrumentNo,Final.InstrumentType,   " +
                    "Final.Debit,Final.Credit,Final.Remarks,Final.OpeningOS,IsNull(a.AccountStatus,'')as AccountStatus  from   " +
                    "(  " +
                    "Select a.*, isnull(OpeningOS,0) as OpeningOS  " +
                    "from  " +
                    "(  " +
                    "select q6.*,TranTypeCode,TranTypeName,TranSide,(case q7.TranSide When 1 then q6.Amount End) as Credit,(case q7.TranSide When 2 then q6.Amount End) as Debit   " +
                    "from   " +
                    "(  " +
                    //----Main Tran--  "+
                    "Select TranID,a.TranNo,a.CustomerID,TranDate,TranTypeID,isnull(a.Amount,0)-isnull(b.CAAmount,0) as Amount,InstrumentNo,InstrumentDate,InstrumentType,  " +
                    "InstrumentStatus,BranchID,BranchName,EntryUserID,EntryDate,UpdateUserID,UpdateDate,Remarks,UnAdjustedAmount,  " +
                    "UploadStatus,UploadDate,DownloadDate,RowStatus,Terminal From   " +
                    "(  " +
                    "select * from   " +
                    "(  " +
                    "Select TranID,TranNo,CustomerID,TranDate,TranTypeID,Amount,InstrumentNo,InstrumentDate,InstrumentType, "+
                    "InstrumentStatus,BranchID,BranchName,EntryUserID,EntryDate,UpdateUserID,UpdateDate,Remarks, "+
                    "UnAdjustedAmount,UploadStatus,UploadDate, DownloadDate,RowStatus,Terminal from t_CustomerTran   " +
                    "Union All  " +
                    "Select b.CreditApprovalCollectionID as TranID,ApprovalNo+'_'+CAST(a.WarehouseID as varchar)+'_'+CAST(b.CreditApprovalCollectionID as varchar) TranNo,  " +
                    "a.CustomerID,b.CreateDate as TranDate,42 as TranTypeID,b.Amount,InstrumentNo,InstrumentDate,InstrumentType,InstrumentStatus,-1 as BranchID,b.BranchName,  " +
                    "b.CreateUserID AS EntryUserID,b.CreateDate as EntryDate,-1 as UpdateUserID,NULL UpdateDate,b.Remarks,0 as UnAdjustedAmount,NULL UploadStatus,NULL UploadDate,  " +
                    "NULL as DownloadDate,NULL RowStatus,2 as Terminal  " +
                    "From t_CustomerCreditApproval a,t_CustomerCreditApprovalCollection b  " +
                    "where a.WarehouseID=b.WarehouseID and a.CreditApprovalID=b.CreditApprovalID   " +
                    ")  main Where TranDate Between '" + dYFromDate.Date + "' and '" + dYToDate.AddDays(1) + "' and TranDate < '" + dYToDate.AddDays(1) + "' and CustomerID = " + nCustomerID + "  " +
                    ") a  " +
                    "Left Outer join   " +
                    "(  " +
                    "Select TranNo,CustomerID,CAAmount From   " +
                    "(  " +
                    "Select InvoiceNo,TranNo,a.CustomerID,Amount as CTAmount   " +
                    "From t_CustomerTran a,t_SalesInvoice b,t_Showroom c  " +
                    "where a.InstrumentNo=b.InvoiceNo and b.WarehouseID=c.WarehouseID  " +
                    "and TranNo like 'CT-%' and InvoiceID in (Select InvoiceID from t_SalesInvoicePaymentMode where PaymentModeID=6)  " +
                    ") a  " +
                    "left outer join   " +
                    "(  " +
                    "Select InvoiceNo,sum(b.Amount) CAAmount From t_SalesInvoice a,t_SalesInvoicePaymentMode b  " +
                    "where a.InvoiceID=b.InvoiceID and PaymentModeID=6 group by InvoiceNo  " +
                    ") b on a.InvoiceNo=b.InvoiceNo  " +
                    ") b on a.CustomerID=b.CustomerID and a.TranNo=b.TranNo  " +
                    //-- -End Main Tran-----  "+
                    ") as q6   " +
                    "Left Outer Join   " +
                    "(  " +
                    "select TranTypeID,TranTypeCode,TranTypeName,TranSide from t_CustomerTranType  " +
                    ") as q7 on q7.TranTypeID=q6.TranTypeID  " +
                    ") as a  " +
                    "Left outer Join  " +
                    "(  " +
                    //-- -OpeningOS---  "+
                    "Select q1.CustomerID,(((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0))*-1) as OpeningOS  " +
                    "from  " +
                    "(   " +
                    //-- -Current Balance----  "+
                    "Select CustomerID,sum(CurrentBalance) CurrentBalance From   " +
                    "(  " +
                    "Select CustomerID,sum(CollectionAmount)-sum(InvoiceAmount) CurrentBalance From   " +
                    "(  " +
                    "Select CustomerID,Amount as CollectionAmount,0 as InvoiceAmount   " +
                    "From t_CustomerCreditApprovalCollection  " +
                    "Union All  " +
                    "Select b.CustomerID,0 as CollectionAmount,case when invoiceTypeID In (6,7,8,9,10,11,12,16) then Amount*-1 else Amount end as InvoiceAmount  " +
                    "From t_SalesInvoicePaymentMode a,t_SalesInvoice b,t_CustomerCreditApproval c   " +
                    "where a.InvoiceID=b.InvoiceID and PaymentModeID=6  and a.InstrumentNo=c.ApprovalNo  " +
                    ") x   " +
                    "group by CustomerID  " +
                    "Union All  " +
                    "Select * From t_CustomerAccount  " +
                    ") bal group by CustomerID  " +
                    //-- -END Current Balance----  "+
                    ")   " +
                    "as q1    " +
                    "left outer join  " +
                    "(    " +
                    "Select  CustomerID,sum(Amount) as CreditAmount From   " +
                    "(  " +
                    "Select CustomerID,TranDate,Amount from t_customerTran ct, t_customerTrantype ctt   " +
                    "where ct.trantypeid = ctt.trantypeid and transide = 1  " +
                    "Union All  " +
                    "Select b.CustomerID,InvoiceDate,  " +
                    "case when InvoiceTypeID in (6,7,8,9,10,11,12,16) then a.Amount else a.Amount*-1 end as Amount   " +
                    "From t_SalesInvoicePaymentMode a,t_SalesInvoice b,t_CustomerCreditApproval c   " +
                    "where a.InvoiceID=b.InvoiceID and PaymentModeID=6  and a.InstrumentNo=c.ApprovalNo  " +
                    "Union All   " +
                    "Select a.CustomerID,a.CreateDate,a.Amount From t_CustomerCreditApprovalCollection a,t_CustomerCreditApproval b  " +
                    "where a.CreditApprovalID=b.CreditApprovalID and a.WarehouseID=b.WarehouseID   " +
                    ") Cr where TranDate between '" + dYFromDate.Date + "' and '" + DateTime.Today.Date.AddDays(1) + "'   " +
                    "group by customerid    " +
                    ")  " +
                    "as q2  " +
                    "on q1.customerid = q2.customerid   " +
                    "left outer join  " +
                    "(   " +
                    "select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt  " +
                    "where ct.trantypeid = ctt.trantypeid and transide = 2  and ct.TranDate between '" + dYFromDate.Date + "' and '" + DateTime.Today.Date.AddDays(1) + "'   " +
                    "group by customerid   " +
                    ") as q3   " +
                    "on q1.customerid = q3.customerid   " +
                    //----End OpeningOS---  "+
                    ") as b on a.customerid = b.customerid  " +
                    ") as Final  " +
                    "inner join  " +
                    "(  " +
                    "select * from v_customerdetails ) as details on Final.customerid = details.customerid   " +
                    "left outer join  " +
                    "TELAddDB.dbo.t_AccountStatus a on a.customercode = details.customercode  " +
                    "order by TranDate";
            }

              //OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            //oCmd.CommandTimeout = 0;
            //oCmd.CommandText = sQueryStringMaster.ToString();
            //oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            //oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));
            //oCmd.Parameters.AddWithValue("TranDate", dYToDate.AddDays(1));
            //oCmd.Parameters.AddWithValue("CustomerID", (long)nCustomerID);

            //oCmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.Date);
            //oCmd.Parameters.AddWithValue("ct.TranDate", DateTime.Today.Date.AddDays(1));

            //oCmd.Parameters.AddWithValue("ct.TranDate", dYFromDate.Date);
            //oCmd.Parameters.AddWithValue("ct.TranDate", DateTime.Today.Date.AddDays(1));



            //GetDataCustomerTransection(oCmd);

            cmd.CommandTimeout = 0;
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CustomerTransactionLedger oItem = new CustomerTransactionLedger();

                if (reader["CustomerId"] != DBNull.Value)
                    oItem.CustomerID = Convert.ToInt32(reader["CustomerId"]);
                else oItem.CustomerID = 0;

                if (reader["CustomerCode"] != DBNull.Value)
                    oItem.CustomerCode = (string)reader["CustomerCode"];
                else oItem.CustomerCode = "";

                if (reader["CustomerName"] != DBNull.Value)
                    oItem.CustomerName = (string)reader["CustomerName"];
                else oItem.CustomerName = "";

                if (reader["CustomerAddress"] != DBNull.Value)
                    oItem.CustomerAddress = (string)reader["CustomerAddress"];
                else oItem.CustomerAddress = "";

                if (reader["CustomerTelephone"] != DBNull.Value)
                    oItem.CustomerTelephone = (string)reader["CustomerTelephone"];
                else oItem.CustomerTelephone = "";

                if (reader["CellphoneNo"] != DBNull.Value)
                    oItem.CellphoneNo = (string)reader["CellphoneNo"];
                else oItem.CellphoneNo = "";

                if (reader["Contractperson"] != DBNull.Value)
                    oItem.Contractperson = (string)reader["Contractperson"];
                else oItem.Contractperson = "";

                if (reader["TranID"] != DBNull.Value)
                    oItem.TranID = Convert.ToInt32(reader["TranID"]);
                else oItem.TranID = -1;

                if (reader["TranNo"] != DBNull.Value)
                    oItem.TranNo = (string)reader["TranNo"];
                else oItem.TranNo = "";

                if (reader["Trandate"] != DBNull.Value)
                    oItem.TranDate = (DateTime)reader["Trandate"];
                else oItem.TranDate = Convert.ToDateTime("01-Jan-1980");

                if (reader["TranTypeName"] != DBNull.Value)
                    oItem.TranTypeName = (string)reader["TranTypeName"];
                else oItem.TranTypeName = "";

                if (reader["InstrumentNo"] != DBNull.Value)
                    oItem.InstrumentNo = (string)reader["InstrumentNo"];
                else oItem.InstrumentNo = "";

                if (reader["InstrumentType"] != DBNull.Value)
                {
                    oItem.InstrumentType = int.Parse(reader["InstrumentType"].ToString());
                    if (oItem.InstrumentType == 0)
                    {
                        oItem.InstType = "DD";

                    }
                    if (oItem.InstrumentType == 1)
                    {
                        oItem.InstType = "Payorder";

                    }
                    if (oItem.InstrumentType == 2)
                    {
                        oItem.InstType = "Cash";

                    }
                    if (oItem.InstrumentType == 3)
                    {
                        oItem.InstType = "Cheque";

                    }
                    if (oItem.InstrumentType == 4)
                    {
                        oItem.InstType = "TT";

                    }
                }
                else oItem.InstrumentType = -1;

                if (reader["Remarks"] != DBNull.Value)
                    oItem.Remarks = (string)reader["Remarks"];
                else oItem.Remarks = "";

                if (reader["AccountStatus"] != DBNull.Value)
                    oItem.AccountStatus = (string)reader["AccountStatus"];
                else oItem.AccountStatus = "";

                if (nCount == 0)
                {
                    if (reader["OpeningOS"] != DBNull.Value)
                    {
                        _OS = Convert.ToDouble(reader["OpeningOS"]);
                        oItem.OpeningOS = Convert.ToDouble(reader["OpeningOS"]);
                        oItem.Outstanding = Convert.ToDouble(reader["OpeningOS"]);
                        ++nCount;
                    }
                    else
                    {
                        _OS = 0;
                        oItem.OpeningOS = 0;
                        oItem.Outstanding = 0;
                    }
                }
                if (reader["Debit"] != DBNull.Value)
                {
                    oItem.Debit = Convert.ToDouble(reader["Debit"]);
                    _TotalDebit = _TotalDebit + oItem.Debit;
                }
                else oItem.Debit = 0;

                if (reader["Credit"] != DBNull.Value)
                {
                    oItem.Credit = Convert.ToDouble(reader["Credit"]);
                    _TotalCredit = _TotalCredit + oItem.Credit;

                }
                else oItem.Credit = 0;




                InnerList.Add(oItem);
            }
            return _ClosingOS = _OS + _TotalDebit - _TotalCredit;

        }

        private void GetDataCustomerTransection(OleDbCommand cmd)
        {

            int nCount = 0;
            //CustomerTransactionLedger oTemp = new CustomerTransactionLedger();
            //oTemp.Temp = 0;
            //oTemp.Outstanding = 0;

            try
            {
              
                IDataReader reader = cmd.ExecuteReader();              
                         
                
                while (reader.Read())
                {
                    CustomerTransactionLedger oItem = new CustomerTransactionLedger();

                    if (reader["CustomerId"] != DBNull.Value)
                        oItem.CustomerID = Convert.ToInt32(reader["CustomerId"]);
                    else oItem.CustomerID = 0;

                    if (reader["CustomerCode"] != DBNull.Value)
                        oItem.CustomerCode = (string)reader["CustomerCode"];
                    else oItem.CustomerCode = "";

                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = (string)reader["CustomerName"];
                    else oItem.CustomerName = "";

                    if (reader["CustomerAddress"] != DBNull.Value)
                        oItem.CustomerAddress = (string)reader["CustomerAddress"];
                    else oItem.CustomerAddress = "";

                    if (reader["CustomerTelephone"] != DBNull.Value)
                        oItem.CustomerTelephone = (string)reader["CustomerTelephone"];
                    else oItem.CustomerTelephone = "";

                    if (reader["CellphoneNo"] != DBNull.Value)
                        oItem.CellphoneNo = (string)reader["CellphoneNo"];
                    else oItem.CellphoneNo = "";

                    if (reader["Contractperson"] != DBNull.Value)
                        oItem.Contractperson = (string)reader["Contractperson"];
                    else oItem.Contractperson = "";                    

                    if (reader["TranID"] != DBNull.Value)
                        oItem.TranID = Convert.ToInt32(reader["TranID"]);
                    else oItem.TranID = -1;

                    if (reader["TranNo"] != DBNull.Value)
                        oItem.TranNo = (string)reader["TranNo"];
                    else oItem.TranNo = "";

                    if (reader["Trandate"] != DBNull.Value)
                        oItem.TranDate = (DateTime)reader["Trandate"];
                    else oItem.TranDate = Convert.ToDateTime("01-Jan-1980");

                    if (reader["TranTypeName"] != DBNull.Value)
                        oItem.TranTypeName = (string)reader["TranTypeName"];
                    else oItem.TranTypeName = "";

                    if (reader["InstrumentNo"] != DBNull.Value)
                        oItem.InstrumentNo = (string)reader["InstrumentNo"];
                    else oItem.InstrumentNo = "";

                    //if (reader["MnCrLimit"] != DBNull.Value)
                    //    oItem.MnCrLimit =(Convert.ToDouble(reader["MnCrLimit"])/1000);
                    //else oItem.MnCrLimit = 0;

                    //if (reader["MxCrLimit"] != DBNull.Value)
                    //    oItem.MxCrLimit =Convert.ToDouble(reader["MxCrLimit"]);
                    //else oItem.MxCrLimit = 0;
                    

                    if (reader["InstrumentType"] != DBNull.Value)
                    {
                        oItem.InstrumentType = int.Parse(reader["InstrumentType"].ToString());
                        if (oItem.InstrumentType == 0)
                        {
                            oItem.InstType = "DD";

                        }
                        if (oItem.InstrumentType == 1)
                        {
                            oItem.InstType = "Payorder";

                        }
                        if (oItem.InstrumentType == 2)
                        {
                            oItem.InstType = "Cash";

                        }
                        if (oItem.InstrumentType == 3)
                        {
                            oItem.InstType = "Cheque";

                        }
                        if (oItem.InstrumentType == 4)
                        {
                            oItem.InstType = "TT";

                        }
                    }
                    else oItem.InstrumentType = -1;

                    if (reader["Remarks"] != DBNull.Value)
                        oItem.Remarks = (string)reader["Remarks"];
                    else oItem.Remarks = "";

                    if (reader["AccountStatus"] != DBNull.Value)
                        oItem.AccountStatus = (string)reader["AccountStatus"];
                    else oItem.AccountStatus = "";

                    if (nCount == 0)
                    {
                        if (reader["OpeningOS"] != DBNull.Value)
                        {

                            oItem.OpeningOS = Convert.ToDouble(reader["OpeningOS"]);
                            oItem.Outstanding = Convert.ToDouble(reader["OpeningOS"]);
                            ++nCount;


                        }
                        else
                        {
                            oItem.OpeningOS = 0;
                            oItem.Outstanding = 0;
                        }
                    }


                    if (reader["Debit"] != DBNull.Value)
                    {
                        oItem.Debit = Convert.ToDouble(reader["Debit"]);


                    }

                    else oItem.Debit = 0;

                    if (reader["Credit"] != DBNull.Value)
                    {
                        oItem.Credit = Convert.ToDouble(reader["Credit"]);

                    }
                    else oItem.Credit = 0;                     
                    
                                                                                       
                   
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
        public void FromDataSetForCustomerTransactionLedget(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    CustomerTransactionLedger oCustomerTransactionLedger = new CustomerTransactionLedger();

                    
                    oCustomerTransactionLedger.CustomerID = Convert.ToInt32(oRow["CustomerID"]);
                    oCustomerTransactionLedger.CustomerCode = (string)oRow["CustomerCode"];
                    oCustomerTransactionLedger.CustomerName = (string)oRow["CustomerName"];

                    oCustomerTransactionLedger.CustomerAddress = (string)oRow["CustomerAddress"];
                    oCustomerTransactionLedger.CustomerTelephone = (string)oRow["CustomerTelephone"];
                    oCustomerTransactionLedger.CellphoneNo = (string)oRow["CellphoneNo"];
                    oCustomerTransactionLedger.Contractperson = (string)oRow["Contractperson"];
                    //oCustomerTransactionLedger.MxCrLimit = (double)oRow["MxCrLimit"];
                    //oCustomerTransactionLedger.MnCrLimit = (double)oRow["MnCrLimit"];

                    oCustomerTransactionLedger.TranID = Convert.ToInt32(oRow["TranID"]);
                    oCustomerTransactionLedger.TranNo = (string)oRow["TranNo"];
                    oCustomerTransactionLedger.TranDate = (DateTime)oRow["TranDate"];
                    oCustomerTransactionLedger.TranTypeName = (string)oRow["TraTypeName"];
                    oCustomerTransactionLedger.InstrumentNo = (string)oRow["InstrumentNo"];
                    oCustomerTransactionLedger.InstrumentType = Convert.ToInt16(oRow["InstrumentType"]);
                    oCustomerTransactionLedger.Debit = (double)oRow["Debit"];
                    oCustomerTransactionLedger.Credit = (double)oRow["Credit"];
                    oCustomerTransactionLedger.Remarks = (string)oRow["Remarks"];
                    oCustomerTransactionLedger.OpeningOS = (double)oRow["OpeningOS"];
                    oCustomerTransactionLedger.AccountStatus = (string)oRow["AccountStatus"];
                    
                    InnerList.Add(oCustomerTransactionLedger);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetCustomerTransection()
        {
            double _Outstanding = 0;
            int _nCount = 0;
            foreach(CustomerTransactionLedger oCustomerTransactionLedger in this)
            {
                if (_nCount == 0)
                {
                    _Outstanding = (oCustomerTransactionLedger.OpeningOS + oCustomerTransactionLedger.Debit) - oCustomerTransactionLedger.Credit;
                    oCustomerTransactionLedger.Outstanding = _Outstanding;
                    _nCount++;
                }
                else
                {
                    _Outstanding = (_Outstanding + oCustomerTransactionLedger.Debit) - oCustomerTransactionLedger.Credit;
                    oCustomerTransactionLedger.Outstanding = _Outstanding;
                }

                ////if (oCustomerTransactionLedger.Debit >= 0)
                //if (oCustomerTransactionLedger.Debit != 0)
                //{
                //    _Outstanding = _Outstanding + oCustomerTransactionLedger.Debit;
                //    oCustomerTransactionLedger.Outstanding = _Outstanding;

                //}
                ////if (oCustomerTransactionLedger.Credit >= 0)
                //if (oCustomerTransactionLedger.Credit != 0)
                //{
                //    _Outstanding = _Outstanding - oCustomerTransactionLedger.Credit;
                //    oCustomerTransactionLedger.Outstanding = _Outstanding;
                //}
            }
        }



    }

    
}

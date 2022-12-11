// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak k. Chakraborty
// Date: Oct 11, 2011
// Time" :  10:00 AM
// Descriptio: Customer Balance Customer wise [811]
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
    public class CustomerBalanceStatementCustomerWise
    {

        private long _SBUID;
        private string _sSBUCode;
        private string _sSBUName;

        private int _nChannelID;
        private string _sChannelCode;
        private string _sChannelName;

        private int _nCustomerTypeID;
        private string _sCustomerTypeCode;
        private string _sCustomerTypeName;

        private int _nAreaID;
        private string _sAreaCode;
        private string _sAreaName;
        
        private int _nTerritoryID;
        private string _sTerritoryCode;
        private string _sTerritoryName;

        private int _nCustomerID;
        private string _sCustomerCode;
        private string _sCustomerName;

        private int _nParentCustomerID;
        private string _sParentCustomerCode;
        private string _sParentCustomerName;
        private long _sProductCodeInNumber;

        private double _Sales;
        private double _Payment;
        private double _Adjustment;
        private double _OpeningOS;
        private double _ClosingOS;
        private double _CreditLimit;


        public long SBUID
        {
            get { return _SBUID; }
            set { _SBUID = value; }
        }
        public string SBUCode
        {
            get { return  _sSBUCode; }
            set { _sSBUCode = value; }
        }

        public string SBUName
        {
            get { return _sSBUName; }
            set { _sSBUName = value; }
        }
        public int ChannelID
        {
            get { return _nChannelID; }
            set { _nChannelID = value; }
        }

        public string ChannelCode
        {
            get { return _sChannelCode; }
            set { _sChannelCode = value; }

        }
        public string ChannelName
        {
            get { return _sChannelName; }
            set { _sChannelName = value; }
        }


        public int CustomerTypeID
        {
            get { return _nCustomerTypeID; }
            set { _nCustomerTypeID = value; }
        }

        public string CustomerTypeCode
        {
            get { return _sCustomerTypeCode; }
            set { _sCustomerTypeCode = value; }

        }
        public string CustomerTypeName
        {
            get { return _sCustomerTypeName; }
            set { _sCustomerTypeName = value; }
        }
        public int AreaID
        {
            get { return _nAreaID; }
            set { _nAreaID = value; }
        }
        public string AreaCode
        {
            get { return _sAreaCode; }
            set { _sAreaCode = value; }
        }
        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value; }
        }
        public int TerritoryID
        {
            get { return _nTerritoryID; }
            set { _nTerritoryID = value; }
        }
        public string TerritoryCode
        {
            get { return _sTerritoryCode; }
            set { _sTerritoryCode = value; }
        }        
        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value; }
        }
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        public int ParentCustomerID
        {
            get { return _nParentCustomerID; }
            set { _nParentCustomerID = value; }
        }
        public string ParentCustomerCode
        {
            get { return _sParentCustomerCode; }
            set { _sParentCustomerCode = value; }
        }
        public string ParentCustomerName    
        {
            get { return _sParentCustomerName; }
            set { _sParentCustomerName = value; }
        }
        public long ProductCodeInNumber
        {
            get { return _sProductCodeInNumber; }
            set { _sProductCodeInNumber = value; }
        }
        public double Sales
        {
            get { return _Sales; }
            set { _Sales = value; }        
        }
        public double Payment
        {
            get { return _Payment; }
            set { _Payment = value; }
        }
        public double Adjustment
        {
            get { return _Adjustment; }
            set { _Adjustment = value; }
        }
        public double OpeningOS
        {
            get { return _OpeningOS; }
            set { _OpeningOS = value; }
        }
        public double ClosingOS
        {
            get { return _ClosingOS; }
            set { _ClosingOS = value; }
        }
        public double CreditLimit
        {
            get { return _CreditLimit; }
            set { _CreditLimit = value; }
        }
        
    }

    public class CustomerBalanceStatementCustomerWiseDetails : CollectionBaseCustom
    {
        public void Add( CustomerBalanceStatementCustomerWise oCustomerBalanceStatementCustomerWise )
        {
            this.List.Add(oCustomerBalanceStatementCustomerWise);
        }
        public CustomerBalanceStatementCustomerWise this[Int32 Index]
        {
            get
            {
                return (CustomerBalanceStatementCustomerWise)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(CustomerBalanceStatementCustomerWise))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void BalanceStatementCustomerWise(DateTime dYFromDate, DateTime dYToDate)
        {
            dYToDate = dYToDate.AddDays(1);
            DateTime dYCurrentDate = DateTime.Today.AddDays(1);
                                   
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            // Query for 811 Customer Balance Statement

            sQueryStringMaster.Append("SELECT   ");
            sQueryStringMaster.Append("SBUID,SBUCode,SBUName,  ");
            sQueryStringMaster.Append("ChannelID,ChannelCode,ChannelName,   ");
            sQueryStringMaster.Append("CustomerTypeID,CustomerTypeCode,CustomerTypeName,  ");
            sQueryStringMaster.Append("AreaID,AreaCode,AreaName,   ");
            sQueryStringMaster.Append("TerritoryID,TerritoryCode,TerritoryName,   ");
            sQueryStringMaster.Append("isnull(ParentCustomerID, CustomerID) as ParentCustomerID,   ");
            sQueryStringMaster.Append("isnull(ParentCustomerCode, CustomerCode) as ParentCustomerCode,   ");
            sQueryStringMaster.Append("isnull(ParentCustomerName, CustomerName) as ParentCustomerName,   ");
            sQueryStringMaster.Append("CustomerID,CustomerCode,CustomerName,  ");
            sQueryStringMaster.Append("ISNULL(SUM(Sales),0) AS Sales,  ");
            sQueryStringMaster.Append("ISNULL(SUM(Payment),0) AS Payment, isnull(sum(Adjustment),0)as Adjustment, ");
            sQueryStringMaster.Append(" ((-1)*SUM(isnull(LastMonthOS ,0))) AS OpeningOS, ((-1)*SUM(isnull(CurrentBalance ,0))) AS ClosingOS, Sum(isnull(CreditLimit,0)) as CreditLimit  ");
            sQueryStringMaster.Append("FROM   ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("Select qq1.*, isnull(qq2.Sales,0)as Sales, ");
            sQueryStringMaster.Append("isnull(qq6.Payment,0)as Payment,isnull(qq7.Adjustment,0)as Adjustment, ");
            sQueryStringMaster.Append("isnull(qq10.LastMonthOS,0)as LastMonthOS, isnull(qq11.CurrentOS,0)as CurrentBalance  ");
            sQueryStringMaster.Append("From   ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("Select   ");
            sQueryStringMaster.Append("p1.SBUID, p1.SBUCode, p1.SBUName  ");
            sQueryStringMaster.Append(",p1.ChannelID AS ChannelId,p1.ChannelCode AS ChannelCode,p1.Channeldescription AS ChannelName  ");
            sQueryStringMaster.Append(",p1.areaid AS AreaID,p1.AreaCode AS AreaCode, p1.AreaName AS AreaName   ");
            sQueryStringMaster.Append(",p1.territoryid AS TerritoryID,p1.TerritoryCode AS TerritoryCode,p1.TerritoryName AS TerritoryName   ");
            sQueryStringMaster.Append(",p1.Customerid AS CustomerId,p1.CustomerCode AS CustomerCode,p1.customername AS CustomerName  ");
            sQueryStringMaster.Append(",p1.ParentCustomerid AS ParentCustomerId,p1.ParentCustomerCode AS ParentCustomerCode,p1.Parentcustomername AS ParentCustomerName  ");
            sQueryStringMaster.Append(",p1.CustomerTypeID, p1.CustomerTypeCode, p1.CustomerTypeName  ");
            sQueryStringMaster.Append(",isnull(p2.CreditAmount,0) as CreditLimit  ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select * from v_customerdetails  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p1  ");
            sQueryStringMaster.Append("LEFT OUTER JOIN  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select Customerid,MinCreditLimit as CreditAmount from t_CustomerCreditLimit   ");
            sQueryStringMaster.Append("where ? between effectivedate and expirydate   ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as p2  ");
            sQueryStringMaster.Append("on p1.Customerid = p2.Customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as Sales    ");
            sQueryStringMaster.Append("From   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount   ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_customer cd   ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid   ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?) and InvoiceDate Between ? and ? and Invoicedate < ?  ");
            sQueryStringMaster.Append("Group By im.Customerid   ");
            sQueryStringMaster.Append("union all   ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, t_customer cd   ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid   ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?) and InvoiceDate Between ? and ? and Invoicedate < ?   ");
            sQueryStringMaster.Append("Group By im.Customerid   ");
            sQueryStringMaster.Append(")as qq1   ");
            sQueryStringMaster.Append("Group By Customerid   ");
            sQueryStringMaster.Append(")as qq2 on qq1.customerid = qq2.customerid  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as Payment from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?) and ct.TranDate between ? and ? and TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?)  and ct.TranDate between ? and ? and TranDate < ? ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")as qq6 on qq1.customerid = qq6.customerid  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as Adjustment from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q4  ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?)  and ct.TranDate between ? and ? and TranDate < ? ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q5  ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid  ");
            sQueryStringMaster.Append(")as qq7 on qq1.customerid = qq7.customerid  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select q1.customerid,  ((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0)) as LastMonthOS from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ? and ct.TranDate between ? and ? and TranDate < ?  ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q2  ");
            sQueryStringMaster.Append("on q1.customerid = q2.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ?  and ct.TranDate between ? and ? and TranDate < ? ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q3  ");
            sQueryStringMaster.Append("on q1.customerid = q3.customerid  ");
            sQueryStringMaster.Append(")as qq10 on qq1.customerid = qq10.customerid  ");
            sQueryStringMaster.Append("Left Outer Join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select q1.customerid,  ((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0)) as CurrentOS from  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q1  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ? and ct.TranDate between ? and ? and TranDate < ? ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")   ");
            sQueryStringMaster.Append("as q2  ");
            sQueryStringMaster.Append("on q1.customerid = q2.customerid  ");
            sQueryStringMaster.Append("left outer join  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ?  and ct.TranDate between ? and ? and TranDate < ? ");
            sQueryStringMaster.Append("group by customerid  ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q3  ");
            sQueryStringMaster.Append("on q1.customerid = q3.customerid  ");
            sQueryStringMaster.Append(")as qq11 on qq1.customerid = qq11.customerid  ");
            sQueryStringMaster.Append(")as finalQuery  ");
            sQueryStringMaster.Append("GROUP BY SBUID,SBUCode,SBUName,ChannelID,ChannelCode,ChannelName,AreaID,AreaCode,AreaName,   ");
            sQueryStringMaster.Append("TerritoryID,TerritoryCode,TerritoryName,CustomerID,CustomerCode,CustomerName,CustomerTypeID,CustomerTypeCode,CustomerTypeName,    ");
            sQueryStringMaster.Append("isnull(ParentCustomerID, CustomerID),isnull(ParentCustomerCode, CustomerCode),isnull(ParentCustomerName, CustomerName)   ");

            
            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            oCmd.Parameters.AddWithValue("Date", dYToDate);

            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);
            oCmd.Parameters.AddWithValue("im.Invoicedate", dYFromDate);
            oCmd.Parameters.AddWithValue("im.Invoicedate", dYToDate);
            oCmd.Parameters.AddWithValue("im.Invoicedate", dYToDate);

            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);
            oCmd.Parameters.AddWithValue("im.Invoicedate", dYFromDate);
            oCmd.Parameters.AddWithValue("im.Invoicedate", dYToDate );
            oCmd.Parameters.AddWithValue("im.Invoicedate", dYToDate);


            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            oCmd.Parameters.AddWithValue("TranDate", dYFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate);


            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            oCmd.Parameters.AddWithValue("TranDate", dYFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate );
            oCmd.Parameters.AddWithValue("TranDate", dYToDate);


            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            // Added for TML
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CO_OP_EXPENSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.PRICE_PROTECTION);
            //**********************************************************
            oCmd.Parameters.AddWithValue("TranDate", dYFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate);

            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            oCmd.Parameters.AddWithValue("TranDate", dYFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate);


            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.CREDIT);
            oCmd.Parameters.AddWithValue("TranDate", dYFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dYCurrentDate);
            oCmd.Parameters.AddWithValue("TranDate", dYCurrentDate);

            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.DEBIT);
            oCmd.Parameters.AddWithValue("TranDate", dYFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dYCurrentDate);
            oCmd.Parameters.AddWithValue("TranDate", dYCurrentDate);

            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.CREDIT);
            oCmd.Parameters.AddWithValue("TranDate", dYFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dYCurrentDate);
            oCmd.Parameters.AddWithValue("TranDate", dYCurrentDate);

            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.DEBIT);
            oCmd.Parameters.AddWithValue("TranDate", dYFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dYCurrentDate);
            oCmd.Parameters.AddWithValue("TranDate", dYCurrentDate);
            
            GetDataBalanceStatementCustomerWise(oCmd);

        }

        public void BalanceStatementCustomerWiseNew(DateTime dYFromDate, DateTime dYToDate)
        {
            dYToDate = dYToDate.AddDays(1);
            DateTime dYCurrentDate = DateTime.Today.AddDays(1);

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            // Query for 811 Customer Balance Statement
            sQueryStringMaster.Append("Select * From   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("Select SBUID,ChannelID,SBUCode,Customer.CustomerID,CustomerTypeID,ParentCustomerID,SBUName,   ");
            sQueryStringMaster.Append("ChannelCode,ChannelDescription as ChannelName,   ");
            sQueryStringMaster.Append("CustomerTypeCode,CustomerTypeName,   ");
            sQueryStringMaster.Append("AreaID,AreaCode,AreaName,   ");
            sQueryStringMaster.Append("TerritoryID,TerritoryCode,TerritoryName,   ");
            sQueryStringMaster.Append("isnull(ParentCustomerCode, CustomerCode) as ParentCustomerCode,   ");
            sQueryStringMaster.Append("isnull(ParentCustomerName, CustomerName) as ParentCustomerName,CustomerCode,CustomerName,   ");
            sQueryStringMaster.Append("isnull(CurrentBalance,0) CurrentBalance,isnull(OpeningOS,0) as OpeningOS,   ");
            sQueryStringMaster.Append("isnull(Sales,0) Sales,isnull(Payment,0) Payment,   ");
            sQueryStringMaster.Append("isnull(Adjustment,0) Adjustment,isnull(ClosingOS,0) ClosingOS,isnull(CreditLimit,0) CreditLimit,   ");
            sQueryStringMaster.Append("isnull(CreditLimit,0)-isnull(ClosingOS,0) DiffClosingOSVSCreditLimit,isnull(OpeningOS,0)-isnull(ClosingOS,0) AS  OSChangeAmt   ");
            sQueryStringMaster.Append("From   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("Select * From   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("Select a.*,MaxCreditLimit as CreditLimit From v_CustomerDetails a   ");
            sQueryStringMaster.Append("left outer join t_CustomerCreditLimit b   ");
            sQueryStringMaster.Append("on a.CustomerID=b.CustomerID and ? between effectivedate and expirydate   ");
            sQueryStringMaster.Append(") a   ");
            sQueryStringMaster.Append(") Customer   ");
            sQueryStringMaster.Append("Left Outer Join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("Select CustomerID,(-1)*sum(OpeningOS) OpeningOS,sum(Sales) Sales,sum(Payment) Payment,sum(Adjustment) Adjustment,   ");
            sQueryStringMaster.Append("(-1)*sum(ClosingOS) ClosingOS From   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("select CustomerID,0 as OpeningOS,sum(sales) as Sales,sum(Payment) as Payment,isnull(sum(Adjustment),0) as Adjustment,   ");
            sQueryStringMaster.Append("isnull(sum(sales),0)-(isnull(sum(Payment),0)+isnull(sum(Adjustment),0)) as ClosingOS   ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("Select CustomerID,TranGroupID,Case when TranGroupID=1 then sum(DebitAmount)-Sum(CreditAmount) end as Sales,   ");
            sQueryStringMaster.Append("Case when TranGroupID=2 then Sum(CreditAmount)-sum(DebitAmount) end as Payment,   ");
            sQueryStringMaster.Append("Case when TranGroupID=3 then Sum(CreditAmount)-sum(DebitAmount) end as Adjustment From    ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("Select CustomerID,TranGroupID, case when TranSide=1 then sum(Amount) else 0 end as CreditAmount,   ");
            sQueryStringMaster.Append("case when TranSide=2 then sum(Amount) else 0 end as DebitAmount From t_CustomerTran a,t_CustomerTranType b   ");
            sQueryStringMaster.Append("where a.TranTypeID=b.TranTypeID  and TranDate between ? and ?   ");
            sQueryStringMaster.Append("and TranDate<?   ");
            sQueryStringMaster.Append("group by CustomerID,TranGroupID,TranSide   ");
            sQueryStringMaster.Append(") Sales group by  CustomerID,TranGroupID   ");
            sQueryStringMaster.Append(") x   ");
            sQueryStringMaster.Append("group by CustomerID   ");
            sQueryStringMaster.Append("Union All   ");
            sQueryStringMaster.Append("Select x.customerid,isnull(currentbalance,0)-isnull(creditamount,0) +isnull(debitamount,0) OpeningOS,   ");
            sQueryStringMaster.Append("0 as Sales,0 as Payment,0 as Adjustment,0 as ClosingOS   ");
            sQueryStringMaster.Append("from   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("Select * From t_customeraccount   ");
            sQueryStringMaster.Append(") x   ");
            sQueryStringMaster.Append("left outer Join   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("Select a.customerid,isnull(sum(creditamount),0) creditamount,isnull(sum(debitamount),0) debitamount From   ");
            sQueryStringMaster.Append("(   ");
            sQueryStringMaster.Append("Select CustomerID,case when TranSide=1 then sum(Amount) else 0 end as CreditAmount,   ");
            sQueryStringMaster.Append("case when TranSide=2 then sum(Amount) else 0 end as DebitAmount From t_CustomerTran a,t_CustomerTranType b   ");
            sQueryStringMaster.Append("where a.TranTypeID=b.TranTypeID and TranDate between ? and ?   ");
            sQueryStringMaster.Append("and TranDate<?   ");
            sQueryStringMaster.Append("group by CustomerID,TranSide   ");
            sQueryStringMaster.Append(") a group by a.customerid    ");
            sQueryStringMaster.Append(") y   ");
            sQueryStringMaster.Append("on  x.customerid=y.customerid   ");
            sQueryStringMaster.Append(") Main group by CustomerID   ");
            sQueryStringMaster.Append(") Cal   ");
            sQueryStringMaster.Append("on Customer.CustomerID=Cal.CustomerID   ");
            sQueryStringMaster.Append(") Main   ");

            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            oCmd.Parameters.AddWithValue("Date", dYToDate);
            oCmd.Parameters.AddWithValue("TranDate", dYFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate);
            oCmd.Parameters.AddWithValue("TranDate", dYFromDate);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate);

            
            GetDataBalanceStatementCustomerWise(oCmd);

        }

        public void GetDataBalanceStatementCustomerWise(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerBalanceStatementCustomerWise oItem = new CustomerBalanceStatementCustomerWise();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = (long)reader["SBUID"];
                    else oItem.SBUID = -1;
                    
                    if (reader["SBUCode"] != DBNull.Value)
                        oItem.SBUCode = (string)reader["SBUCode"];
                    else oItem.SBUCode = "";
                    
                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)reader["SBUName"];
                    else oItem.SBUName = "";

                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelID = (int)reader["ChannelID"];
                    else oItem.ChannelID = -1;

                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)reader["ChannelCode"];
                    else oItem.ChannelCode = "";

                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)reader["ChannelName"];
                    else oItem.ChannelName = "";

                    if (reader["AreaID"] != DBNull.Value)
                        oItem.AreaID = (int)reader["AreaID"];
                    else oItem.AreaID = -1;

                    if (reader["AreaCode"] != DBNull.Value)
                        oItem.AreaCode = (string)reader["AreaCode"];
                    else oItem.AreaCode = "";

                    if (reader["AreaName"] != DBNull.Value)
                        oItem.AreaName = (string)reader["AreaName"];
                    else oItem.AreaName = "";

                    if (reader["TerritoryID"] != DBNull.Value)
                        oItem.TerritoryID = (int)reader["TerritoryID"];
                    else oItem.TerritoryID = -1;

                    if (reader["TerritoryCode"] != DBNull.Value)
                        oItem.TerritoryCode = (string)reader["TerritoryCode"];
                    else oItem.TerritoryCode = "";

                    if (reader["TerritoryName"] != DBNull.Value)
                        oItem.TerritoryName = (string)reader["TerritoryName"];
                    else oItem.TerritoryName = "";
                                                           
                    if (reader["CustomerTypeID"] != DBNull.Value)
                        oItem.CustomerTypeID = (int)reader["CustomerTypeID"];
                    else oItem.CustomerTypeID = -1;

                    if (reader["CustomerTypeCode"] != DBNull.Value)
                        oItem.CustomerTypeCode = (string)reader["CustomerTypeCode"];
                    else oItem.CustomerTypeCode = "";

                    if (reader["CustomerTypeName"] != DBNull.Value)
                        oItem.CustomerTypeName = (string)reader["CustomerTypeName"];
                    else oItem.CustomerTypeName = ""; 
                                      
                    
                    if (reader["CustomerID"] != DBNull.Value)
                        oItem.CustomerID = (int)reader["CustomerID"];
                    else oItem.CustomerID = -1;

                    if (reader["CustomerCode"] != DBNull.Value)
                        oItem.CustomerCode = (string)reader["CustomerCode"];
                    else oItem.CustomerCode = "";

                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = (string)reader["CustomerName"];
                    else oItem.CustomerName = "";

                    if (reader["ParentCustomerID"] != DBNull.Value)
                        oItem.ParentCustomerID = (int)reader["ParentCustomerID"];
                    else oItem.ParentCustomerID = -1;

                    if (reader["ParentCustomerCode"] != DBNull.Value)
                        oItem.ParentCustomerCode = (string)reader["ParentCustomerCode"];
                    else oItem.ParentCustomerCode = "";

                    if (reader["ParentCustomerName"] != DBNull.Value)
                        oItem.ParentCustomerName = (string)reader["ParentCustomerName"];
                    else oItem.ParentCustomerName = "";

                    if (reader["Sales"] != DBNull.Value)
                        oItem.Sales =  (double) reader["Sales"];
                    else oItem.Sales = 0;

                    if (reader["Payment"] != DBNull.Value)
                        oItem.Payment =  (double) reader["Payment"];
                    else oItem.Payment = 0;

                    if (reader["Adjustment"] != DBNull.Value)
                        oItem.Adjustment =  (double) reader["Adjustment"];
                    else oItem.Adjustment = 0;

                    if (reader["OpeningOS"] != DBNull.Value)
                        oItem.OpeningOS =  (double) reader["OpeningOS"];
                    else oItem.OpeningOS = 0; 

                    if (reader["ClosingOS"] != DBNull.Value)
                        oItem.ClosingOS = (double)reader["ClosingOS"];
                    else oItem.ClosingOS = 0;

                    if (reader["CreditLimit"] != DBNull.Value)
                        oItem.CreditLimit = (double)reader["CreditLimit"];
                    else oItem.CreditLimit = 0;
                    
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
        public void FromDataSetBalanceStatementCustomerWise(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    CustomerBalanceStatementCustomerWise oCustomerBalanceStatementCustomerWise = new CustomerBalanceStatementCustomerWise();

                    oCustomerBalanceStatementCustomerWise.SBUID = Convert.ToInt32(oRow["SBUID"]);
                    oCustomerBalanceStatementCustomerWise.SBUCode = (string)oRow["SBUCode"];
                    oCustomerBalanceStatementCustomerWise.SBUName = (string)oRow["SBUName"];

                    oCustomerBalanceStatementCustomerWise.ChannelID = Convert.ToInt32(oRow["ChannelID"]);
                    oCustomerBalanceStatementCustomerWise.ChannelCode = (string)oRow["ChannelCode"];
                    oCustomerBalanceStatementCustomerWise.ChannelName = (string)oRow["ChannelName"];

                    oCustomerBalanceStatementCustomerWise.CustomerTypeID = Convert.ToInt32(oRow["CustomerTypeID"]);
                    oCustomerBalanceStatementCustomerWise.CustomerTypeCode = (string)oRow["CustomerTypeCode"];
                    oCustomerBalanceStatementCustomerWise.CustomerTypeName = (string)oRow["CustomerTypeName"];

                    oCustomerBalanceStatementCustomerWise.AreaID = Convert.ToInt32(oRow["AreaID"]);
                    oCustomerBalanceStatementCustomerWise.AreaCode = (string)oRow["AreaCode"];
                    oCustomerBalanceStatementCustomerWise.AreaName = (string)oRow["AreaName"];

                    oCustomerBalanceStatementCustomerWise.TerritoryID = Convert.ToInt32(oRow["TerritoryID"]);
                    oCustomerBalanceStatementCustomerWise.TerritoryCode = (string)oRow["TerritoryCode"];
                    oCustomerBalanceStatementCustomerWise.TerritoryName = (string)oRow["TerritoryName"];

                    oCustomerBalanceStatementCustomerWise.CustomerID = Convert.ToInt32(oRow["CustomerID"]);
                    oCustomerBalanceStatementCustomerWise.CustomerCode = (string)oRow["CustomerCode"];
                    oCustomerBalanceStatementCustomerWise.CustomerName = (string)oRow["CustomerName"];

                    oCustomerBalanceStatementCustomerWise.ParentCustomerID = Convert.ToInt32(oRow["ParentCustomerID"]);
                    oCustomerBalanceStatementCustomerWise.ParentCustomerCode = (string)oRow["ParentCustomerCode"];
                    oCustomerBalanceStatementCustomerWise.ParentCustomerName = (string)oRow["ParentCustomerName"];
                    

                    oCustomerBalanceStatementCustomerWise.Sales = Convert.ToInt32(oRow["Sales"]);
                    oCustomerBalanceStatementCustomerWise.Payment = Convert.ToInt32(oRow["Payment"]);
                    oCustomerBalanceStatementCustomerWise.Adjustment = Convert.ToInt32(oRow["Adjustment"]);
                    oCustomerBalanceStatementCustomerWise.OpeningOS = Convert.ToInt32(oRow["OpeningOS"]);
                    oCustomerBalanceStatementCustomerWise.ClosingOS = Convert.ToInt32(oRow["ClosingOS"]);
                    oCustomerBalanceStatementCustomerWise.CreditLimit = Convert.ToInt32(oRow["CreditLimit"]);


                    InnerList.Add(oCustomerBalanceStatementCustomerWise);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    
    }
}

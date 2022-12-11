// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak kumar Chakraborty
// Date: Feb 20; 2012
// Time :  10:00 AM
// Description: Weekly Sales & Collection report Customer Wise [410]
// Modify Person And Date:
// </summary> 

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;

namespace CJ.Class.Report
{
    public class RptSalesAndCollReportCustomerWise
    {
        public int _nSBUID;
        public string _sSBUCode;
        public string _sSBUName;

        public int _nChannelID;
        public string _sChannelCode;
        public string _sChannelName;

        public int _nAreaID;
        public string _sAreaCode;
        public string _sAreaName;

        public int _nTerritoryID;
        public string _sTerritoryCode;
        public string _sTerritoryName;

        public int _nCustomertypeID;
        public string _sCustomerTypeCode;
        public string _sCustomerTypeName;

        public int _nCustomerID;
        public string _sCustomerCode;
        public string _sCustomerName;


        public int _nIsactive;
        public double _Week1Sales;
        public double _Week2Sales;
        public double _Week3Sales;
        public double _Week4Sales;
        public double _Week1Coll;
        public double _Week2Coll;
        public double _Week3Coll;
        public double _Week4Coll;
        public double _LastMonthOS;
        public double _CurrentBalance;
        public double _CreditLimit;



        public int SBUID
        {
            get { return _nSBUID; }
            set { _nSBUID = value; }
        }
        public string SBUCode
        {
            get { return _sSBUCode; }
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

        public int CustomerTypeID
        {
            get { return _nCustomertypeID; }
            set { _nCustomertypeID = value; }
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
        public int IsActive
        {
            get { return _nIsactive; }
            set { _nIsactive = value; }
        }
        public double Week1Sales
        {
            get { return _Week1Sales; }
            set { _Week1Sales = value; }
        }
        public double Week2Sales
        {
            get { return _Week2Sales; }
            set { _Week2Sales = value; }
        }
        public double Week3Sales
        {
            get { return _Week3Sales; }
            set { _Week3Sales = value; }
        }
        public double Week4Sales
        {
            get { return _Week4Sales; }
            set { _Week4Sales = value; }
        }
        public double Week1Coll
        {
            get { return _Week1Coll; }
            set { _Week1Coll = value; }
        }
        public double Week2Coll
        {
            get { return _Week2Coll; }
            set { _Week2Coll = value; }
        }
        public double Week3Coll
        {
            get { return _Week3Coll; }
            set { _Week3Coll = value; }
        }
        public double Week4Coll
        {
            get { return _Week4Coll; }
            set { _Week4Coll = value; }
        }
        public double LastMonthOS
        {
            get { return _LastMonthOS; }
            set { _LastMonthOS = value; }
        }
        public double CurrentBalance
        {
            get { return _CurrentBalance; }
            set { _CurrentBalance = value; }
        }
        public double CreditLimit
        {
            get { return _CreditLimit; }
            set { _CreditLimit = value; }
        }
    }


    public class RptSalesAndCollReportCustomerWiseDetails : CollectionBaseCustom
    {
        public void Add(RptSalesAndCollReportCustomerWise oRptSalesAndCollReportCustomerWise)
        {
            this.List.Add(oRptSalesAndCollReportCustomerWise);
        }
        public RptSalesAndCollReportCustomerWise this[Int32 Index]
        {
            get
            {
                return (RptSalesAndCollReportCustomerWise)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(RptSalesAndCollReportCustomerWise))))
                {
                    throw new Exception(" Type can't be converted");
                }
                this.List[Index] = value;
            }
        }


        public void SalesAndCollReportCustomerWise(DateTime dStartDate1, DateTime dEndDate1, DateTime dStartDate2, DateTime dEndDate2, DateTime dStartDate3, DateTime dEndDate3, DateTime dStartDate4, DateTime dEndDate4, DateTime dStartDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            sQueryStringMaster.Append("SELECT  ");
            sQueryStringMaster.Append("SBUID,SBUCode,SBUName, ");
            sQueryStringMaster.Append("ChannelID,ChannelCode,ChannelName,  ");
            sQueryStringMaster.Append("AreaID,AreaCode,AreaName,  ");
            sQueryStringMaster.Append("TerritoryID,TerritoryCode,TerritoryName,  ");
            sQueryStringMaster.Append("CustomerID,CustomerCode,CustomerName,  ");
            sQueryStringMaster.Append("CustomerTypeID,CustomerTypeCode,CustomerTypeName, IsActive, ");
            sQueryStringMaster.Append("ISNULL(SUM(week1_Sales),0) AS Week1Sales, ISNULL(SUM(week2_Sales),0) AS Week2Sales, ISNULL(SUM(week3_sales),0) AS Week3Sales, ISNULL(SUM(week4_sales),0) AS Week4Sales,  ");
            sQueryStringMaster.Append("ISNULL(SUM(week1_coll),0) AS Week1Coll, ISNULL(SUM(week2_coll),0) AS Week2Coll, ISNULL(SUM(week3_coll),0) AS Week3Coll, ISNULL(SUM(week4_coll),0) AS Week4Coll,   ");
            sQueryStringMaster.Append("SUM(isnull(LastMonthOS ,0)) AS LastMonthOS, SUM(isnull(CurrentBalance ,0)) AS CurrentBalance, Sum(isnull(CreditLimit,0)) as CreditLimit ");
            sQueryStringMaster.Append("FROM  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select qq1.*, isnull(qq2.week1_Sales,0)as week1_Sales,isnull(qq3.week2_Sales,0)as week2_Sales,isnull(qq4.week3_Sales,0)as week3_Sales,isnull(qq5.week4_Sales,0)as week4_Sales, ");
            sQueryStringMaster.Append("isnull(qq6.week1_Coll,0)as week1_Coll,isnull(qq7.week2_Coll,0)as week2_Coll,isnull(qq8.week3_Coll,0)as week3_Coll,isnull(qq9.week4_Coll,0)as week4_Coll, ");
            sQueryStringMaster.Append("isnull(qq10.LastMonthOS,0)as LastMonthOS, isnull(qq11.CurrentOS,0)as CurrentBalance ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("Select  ");
            sQueryStringMaster.Append("p1.SBUID, p1.SBUCode, p1.SBUName ");
            sQueryStringMaster.Append(",p1.ChannelID AS ChannelId,p1.ChannelCode AS ChannelCode,p1.Channeldescription AS ChannelName ");
            sQueryStringMaster.Append(",p1.areaid AS AreaID,p1.AreaCode AS AreaCode, p1.AreaName AS AreaName  ");
            sQueryStringMaster.Append(",p1.territoryid AS TerritoryID,p1.TerritoryCode AS TerritoryCode,p1.TerritoryName AS TerritoryName  ");
            sQueryStringMaster.Append(",p1.Customerid AS CustomerId,p1.CustomerCode AS CustomerCode,p1.customername AS CustomerName  ");
            sQueryStringMaster.Append(",p1.CustomerTypeID, p1.CustomerTypeCode, p1.CustomerTypeName,p1.IsActive ");
            sQueryStringMaster.Append(",isnull(p2.CreditAmount,0) as CreditLimit ");
            sQueryStringMaster.Append("From ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select * from v_customerdetails ");
            //sQueryStringMaster.Append(" where isactive = ? ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as p1 ");
            sQueryStringMaster.Append("LEFT OUTER JOIN ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid,MinCreditLimit as CreditAmount from t_CustomerCreditLimit  ");
            sQueryStringMaster.Append("where ? between effectivedate and expirydate  ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as p2 ");
            sQueryStringMaster.Append("on p1.Customerid = p2.Customerid ");
            sQueryStringMaster.Append(")as qq1 ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as Week1_Sales   ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?)and InvoiceDate Between ? and ? and Invoicedate < ? ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?) and InvoiceDate Between ? and ? and Invoicedate < ? ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(")as qq2 on qq1.customerid = qq2.customerid ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as Week2_Sales   ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?) and InvoiceDate Between ? and ? and Invoicedate < ? ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?) and InvoiceDate Between ? and ? and Invoicedate < ? ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(")as qq3 on qq1.customerid = qq3.customerid ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as Week3_Sales   ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?) and InvoiceDate Between ? and ? and Invoicedate < ? ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?) and InvoiceDate Between ? and ? and Invoicedate < ? ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(")as qq4 on qq1.customerid = qq4.customerid ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select Customerid, isnull(sum(CrSalesAmount)- abs(sum(drSalesAmount)),0) as Week4_Sales   ");
            sQueryStringMaster.Append("From  ");
            sQueryStringMaster.Append("(  ");
            sQueryStringMaster.Append("select im.CustomerID, sum(invoiceamount)as CrSalesAmount, 0 as drSalesAmount  ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?) and invoicestatus not in (?) and InvoiceDate between ? and ? and InvoiceDate < ?   ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append("union all  ");
            sQueryStringMaster.Append("select im.CustomerID, 0 as CrSalesAmount,sum(invoiceamount)as drSalesAmount ");
            sQueryStringMaster.Append("from t_SalesInvoice im, v_CustomerDetails cd  ");
            sQueryStringMaster.Append("where im.customerid = cd.customerid  ");
            sQueryStringMaster.Append("and im.invoicetypeid in (?,?,?,?,?,?) and invoicestatus not in (?) and InvoiceDate between ? and ? and InvoiceDate < ?  ");
            sQueryStringMaster.Append("Group By im.Customerid  ");
            sQueryStringMaster.Append(")as qq1  ");
            sQueryStringMaster.Append("Group By Customerid  ");
            sQueryStringMaster.Append(")as qq5 on qq1.customerid = qq5.customerid ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as week1_Coll from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as q1 ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt  ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and TranDate < ? ");
            sQueryStringMaster.Append("group by customerid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q4 ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt  ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?)  and ct.TranDate between ? and ? and TranDate < ? ");
            sQueryStringMaster.Append("group by customerid ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as q5 ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid ");
            sQueryStringMaster.Append(")as qq6 on qq1.customerid = qq6.customerid ");
            sQueryStringMaster.Append("Left outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as week2_Coll from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as q1 ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt  ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and TranDate < ? ");
            sQueryStringMaster.Append("group by customerid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q4 ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt  ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?)  and ct.TranDate between ? and ? and TranDate < ? ");
            sQueryStringMaster.Append("group by customerid ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as q5 ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid ");
            sQueryStringMaster.Append(")as qq7 on qq1.customerid = qq7.customerid ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as week3_Coll from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as q1 ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt  ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and TranDate < ? ");
            sQueryStringMaster.Append("group by customerid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q4 ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt  ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?)  and ct.TranDate between ? and ? and TranDate < ? ");
            sQueryStringMaster.Append("group by customerid ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as q5 ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid ");
            sQueryStringMaster.Append(")as qq8 on qq1.customerid = qq8.customerid ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ( isnull(q4.CreditAmount,0) - isnull(q5.DebitAmount,0)) as week4_Coll from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as q1 ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt  ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?,?,?,?,?,?) and ct.TranDate between ? and ? and TranDate < ? ");
            sQueryStringMaster.Append("group by customerid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q4 ");
            sQueryStringMaster.Append("on q1.customerid = q4.customerid ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt  ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and ct.TranTypeID in(?,?,?,?,?,?,?,?)  and ct.TranDate between ? and ? and TranDate < ? ");
            sQueryStringMaster.Append("group by customerid ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as q5 ");
            sQueryStringMaster.Append("on q1.customerid = q5.customerid ");
            sQueryStringMaster.Append(")as qq9 on qq1.customerid = qq9.customerid ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0)) as LastMonthOS from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as q1 ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt  ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ? and ct.TranDate between ? and ? and TranDate < ? ");
            sQueryStringMaster.Append("group by customerid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q2 ");
            sQueryStringMaster.Append("on q1.customerid = q2.customerid ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt  ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ?  and ct.TranDate between ? and ? and TranDate < ? ");
            sQueryStringMaster.Append("group by customerid ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as q3 ");
            sQueryStringMaster.Append("on q1.customerid = q3.customerid ");
            sQueryStringMaster.Append(")as qq10 on qq1.customerid = qq10.customerid ");
            sQueryStringMaster.Append("Left Outer Join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select q1.customerid,  ((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0)) as CurrentOS from ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, CurrentBalance from t_customerAccount ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as q1 ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt  ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ? and ct.TranDate between ? and ? and TranDate < ? ");
            sQueryStringMaster.Append("group by customerid ");
            sQueryStringMaster.Append(")  ");
            sQueryStringMaster.Append("as q2 ");
            sQueryStringMaster.Append("on q1.customerid = q2.customerid ");
            sQueryStringMaster.Append("left outer join ");
            sQueryStringMaster.Append("( ");
            sQueryStringMaster.Append("select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt  ");
            sQueryStringMaster.Append("where ct.trantypeid = ctt.trantypeid and transide = ?  and ct.TranDate between ? and ? and TranDate < ? ");
            sQueryStringMaster.Append("group by customerid ");
            sQueryStringMaster.Append(") ");
            sQueryStringMaster.Append("as q3 ");
            sQueryStringMaster.Append("on q1.customerid = q3.customerid ");
            sQueryStringMaster.Append(")as qq11 on qq1.customerid = qq11.customerid ");
            sQueryStringMaster.Append(")as finalQuery ");
            sQueryStringMaster.Append("GROUP BY SBUID,SBUCode,SBUName,ChannelID,ChannelCode,ChannelName,AreaID,AreaCode,AreaName,  ");
            sQueryStringMaster.Append("TerritoryID,TerritoryCode,TerritoryName,CustomerID,CustomerCode,CustomerName,CustomerTypeID,CustomerTypeCode,CustomerTypeName,IsActive  "); 
            

            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            oCmd.Parameters.AddWithValue("Date", dEndDate3);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);
            oCmd.Parameters.AddWithValue("InvoiceDate", dStartDate1);
            oCmd.Parameters.AddWithValue("InvoiceDate", dEndDate1.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceDate", dEndDate1.AddDays(1));


            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);
            oCmd.Parameters.AddWithValue("InvoiceDate", dStartDate1);
            oCmd.Parameters.AddWithValue("InvoiceDate", dEndDate1.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceDate", dEndDate1.AddDays(1));



            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);
            oCmd.Parameters.AddWithValue("InvoiceDate", dStartDate2);
            oCmd.Parameters.AddWithValue("InvoiceDate", dEndDate2.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceDate", dEndDate2.AddDays(1));



            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);
            oCmd.Parameters.AddWithValue("InvoiceDate", dStartDate2);
            oCmd.Parameters.AddWithValue("InvoiceDate", dEndDate2.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceDate", dEndDate2.AddDays(1));


            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);
            oCmd.Parameters.AddWithValue("InvoiceDate", dStartDate3);
            oCmd.Parameters.AddWithValue("InvoiceDate", dEndDate3.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceDate", dEndDate3.AddDays(1));

            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);
            oCmd.Parameters.AddWithValue("InvoiceDate", dStartDate3);
            oCmd.Parameters.AddWithValue("InvoiceDate", dEndDate3.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceDate", dEndDate3.AddDays(1));


            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);
            oCmd.Parameters.AddWithValue("InvoiceDate", dStartDate4);
            oCmd.Parameters.AddWithValue("InvoiceDate", dEndDate4.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceDate", dEndDate4.AddDays(1));


            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CASH_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.EPS_REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.REVERSE);
            oCmd.Parameters.AddWithValue("InvoiceTypeID", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            oCmd.Parameters.AddWithValue("InvoiceStatus", Dictionary.InvoiceStatus.CANCEL);
            oCmd.Parameters.AddWithValue("InvoiceDate", dStartDate4);
            oCmd.Parameters.AddWithValue("InvoiceDate", dEndDate4.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceDate", dEndDate4.AddDays(1));

            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate1);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate1.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dEndDate1.AddDays(1));

            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate1);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate1.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dEndDate1.AddDays(1));


            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate2);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate2.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dEndDate2.AddDays(1));

            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate2);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate2.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dEndDate2.AddDays(1)); 


            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate3);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate3.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dEndDate3.AddDays(1));

            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate3);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate3.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dEndDate3.AddDays(1));


            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate4);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate4.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dEndDate4.AddDays(1));


            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate4);
            oCmd.Parameters.AddWithValue("TranDate", dEndDate4.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dEndDate4.AddDays(1));

            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.CREDIT);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate1);
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.AddDays(1));

            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.DEBIT);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate1);
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.AddDays(1));

            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.CREDIT);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.AddDays(1));

            oCmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionSide.DEBIT);
            oCmd.Parameters.AddWithValue("TranDate", dStartDate.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.AddDays(1));


            GetDataSalesAndCollReport(oCmd);

        }
        public void GetDataSalesAndCollReport(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptSalesAndCollReportCustomerWise oItem = new RptSalesAndCollReportCustomerWise();

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID =Convert.ToInt16( reader["SBUID"]);
                    else oItem.SBUID = -1;

                    if (reader["SBUCode"] != DBNull.Value)
                        oItem.SBUCode = (string)reader["SBUCode"];
                    else oItem.SBUCode = "";

                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)reader["SBUName"];
                    else oItem.SBUName = "";

                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelID = Convert.ToInt16( reader["ChannelID"]);
                    else oItem.ChannelID = -1;

                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)reader["ChannelCode"];
                    else oItem.ChannelCode = "";

                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)reader["ChannelName"];
                    else oItem.ChannelName = "";


                    if (reader["AreaID"] != DBNull.Value)
                        oItem.AreaID = Convert.ToInt16( reader["AreaID"]);
                    else oItem.AreaID = -1;

                    if (reader["AreaCode"] != DBNull.Value)
                        oItem.AreaCode = (string)reader["AreaCode"];
                    else oItem.AreaCode = "";

                    if (reader["AreaName"] != DBNull.Value)
                        oItem.AreaName = (string)reader["AreaName"];
                    else oItem.AreaName = "";

                    if (reader["TerritoryID"] != DBNull.Value)
                        oItem.TerritoryID = Convert.ToInt16(reader["TerritoryID"]);
                    else oItem.TerritoryID = -1;

                    if (reader["TerritoryCode"] != DBNull.Value)
                        oItem.TerritoryCode = (string)reader["TerritoryCode"];
                    else oItem.TerritoryCode = "";

                    if (reader["TerritoryName"] != DBNull.Value)
                        oItem.TerritoryName = (string)reader["TerritoryName"];
                    else oItem.TerritoryName = "";
                    
                    if (reader["CustomerTypeID"] != DBNull.Value)
                        oItem.CustomerTypeID =Convert.ToInt16 (reader["CustomerTypeID"]);
                    else oItem.CustomerTypeID = -1;

                    if (reader["CustomerTypeCode"] != DBNull.Value)
                        oItem.CustomerTypeCode = (string)reader["CustomerTypeCode"];
                    else oItem.CustomerTypeCode = "";

                    if (reader["CustomerTypeName"] != DBNull.Value)
                        oItem.CustomerTypeName = (string)reader["CustomerTypeName"];
                    else oItem.CustomerTypeName = "";

                    if (reader["CustomerID"] != DBNull.Value)
                        oItem.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    else oItem.CustomerID = -1;

                    if (reader["CustomerCode"] != DBNull.Value)
                        oItem.CustomerCode = (string)reader["CustomerCode"];
                    else oItem.CustomerCode = "";

                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = (string)reader["CustomerName"];
                    else oItem.CustomerName = "";

                    if (reader["IsActive"] != DBNull.Value)
                        oItem.IsActive =Convert.ToInt32 (reader["IsActive"]);
                    else oItem.IsActive = 0;

                    if (reader["Week1Sales"] != DBNull.Value)
                        oItem.Week1Sales = Convert.ToDouble(reader["Week1Sales"]);
                    else oItem.Week1Sales = 0;

                    if (reader["Week2Sales"] != DBNull.Value)
                        oItem.Week2Sales = Convert.ToDouble(reader["Week2Sales"]);
                    else oItem.Week2Sales = 0;

                    if (reader["Week3Sales"] != DBNull.Value)
                        oItem.Week3Sales = Convert.ToDouble(reader["Week3Sales"]);
                    else oItem.Week3Sales = 0;

                    if (reader["Week4Sales"] != DBNull.Value)
                        oItem.Week4Sales = Convert.ToDouble(reader["Week4Sales"]);
                    else oItem.Week4Sales = 0;

                    if (reader["Week1Coll"] != DBNull.Value)
                        oItem.Week1Coll = Convert.ToDouble(reader["Week1Coll"]);
                    else oItem.Week1Coll = 0;

                    if (reader["Week2Coll"] != DBNull.Value)
                        oItem.Week2Coll = Convert.ToDouble(reader["Week2Coll"]);
                    else oItem.Week2Coll = 0;

                    if (reader["Week3Coll"] != DBNull.Value)
                        oItem.Week3Coll = Convert.ToDouble(reader["Week3Coll"]);
                    else oItem.Week3Coll = 0;

                    if (reader["Week4Coll"] != DBNull.Value)
                        oItem.Week4Coll = Convert.ToDouble(reader["Week4Coll"]);
                    else oItem.Week4Coll = 0;

                    if (reader["LastMonthOS"] != DBNull.Value)
                        oItem.LastMonthOS = Convert.ToDouble(reader["LastMonthOS"]);
                    else oItem.LastMonthOS = 0;

                    if (reader["CurrentBalance"] != DBNull.Value)
                        oItem.CurrentBalance = Convert.ToDouble(reader["CurrentBalance"]);
                    else oItem.CurrentBalance = 0;

                    if (reader["CreditLimit"] != DBNull.Value)
                        oItem.CreditLimit = Convert.ToDouble(reader["CreditLimit"]);
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


        public void FromDataSetSalesAndCollReport(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    RptSalesAndCollReportCustomerWise oRptSalesAndCollReportCustomerWise = new RptSalesAndCollReportCustomerWise();

                    
                    oRptSalesAndCollReportCustomerWise.SBUID=Convert.ToInt32(oRow["SBUID"]);
                    oRptSalesAndCollReportCustomerWise.SBUCode=(string)oRow["SBUCode"];
                    oRptSalesAndCollReportCustomerWise.SBUName=(string)oRow["SBUName"];

                    oRptSalesAndCollReportCustomerWise.ChannelID=Convert.ToInt32(oRow["ChannelID"]);
                    oRptSalesAndCollReportCustomerWise.ChannelName = (string)oRow["ChannelName"];
                    oRptSalesAndCollReportCustomerWise.ChannelCode = (string)oRow["ChannelCode"];

                    oRptSalesAndCollReportCustomerWise.AreaID = Convert.ToInt32(oRow["AreaID"]);
                    oRptSalesAndCollReportCustomerWise.AreaCode =(string)oRow["AreaCode"];
                    oRptSalesAndCollReportCustomerWise.AreaName = (string)oRow["AreaName"];

                    oRptSalesAndCollReportCustomerWise.TerritoryName = (string)oRow["TerritoryName"];
                    oRptSalesAndCollReportCustomerWise.TerritoryCode = (string)oRow["TerritoryCode"];
                    oRptSalesAndCollReportCustomerWise.TerritoryID = Convert.ToInt16(oRow["TerritoryID"]);

                    oRptSalesAndCollReportCustomerWise.CustomerTypeID = Convert.ToInt16(oRow["CustomerTypeID"]);
                    oRptSalesAndCollReportCustomerWise.CustomerTypeName = (string)oRow["CustomertypeName"];
                    oRptSalesAndCollReportCustomerWise.CustomerTypeCode = (string)oRow["CustomerTypeCode"];

                    oRptSalesAndCollReportCustomerWise.CustomerID = Convert.ToInt16(oRow["CustomerID"]);
                    oRptSalesAndCollReportCustomerWise.CustomerCode = (string)oRow["CustomerCode"];
                    oRptSalesAndCollReportCustomerWise.CustomerName = (string)oRow["CustomerName"];
                    
                    oRptSalesAndCollReportCustomerWise.Week1Sales=Convert.ToDouble(oRow["Week1Sales"]);
                    oRptSalesAndCollReportCustomerWise.Week2Sales=Convert.ToDouble(oRow["Week2Sales"]);
                    oRptSalesAndCollReportCustomerWise.Week3Sales=Convert.ToDouble(oRow["Week3Sales"]);
                    oRptSalesAndCollReportCustomerWise.Week4Sales=Convert.ToDouble(oRow["Week4Sales"]);
                    oRptSalesAndCollReportCustomerWise.Week1Coll =Convert.ToDouble(oRow["Week1Coll"]);
                    oRptSalesAndCollReportCustomerWise.Week2Coll=Convert.ToDouble(oRow["Week2Coll"]);
                    oRptSalesAndCollReportCustomerWise.Week3Coll=Convert.ToDouble(oRow["Week3Coll"]);
                    oRptSalesAndCollReportCustomerWise.Week4Coll=Convert.ToDouble(oRow["Week4Coll"]);
                    oRptSalesAndCollReportCustomerWise.LastMonthOS=Convert.ToDouble(oRow["LastMonthOS"]);
                    oRptSalesAndCollReportCustomerWise.CurrentBalance = Convert.ToDouble(oRow["CurrentBalance"]);
                    oRptSalesAndCollReportCustomerWise.CreditLimit = Convert.ToDouble(oRow["CreditLimit"]);                    
                    InnerList.Add(oRptSalesAndCollReportCustomerWise);

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
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Mithun Sarkar
// Date: Mar 13, 2012
// Time :  4:00 PM
// Description: Outstanding Statement with Collection and Adjustment Channel Wise
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Report
{
    [Serializable]
    public class rptMonthlyCollection
    {
        public int _nChannelId;
        public string _sChannelCode;
        public string _sChannelName;
        public int _nCustomerTypeId;
        public string _sCustomerTypeCode;
        public string _sCustomerTypeName;
        public int _nAreaId;
        public string _sAreaCode;
        public string _sAreaName;
        public int _nTerritoryId;
        public string _sTerritoryCode;
        public string _sTerritoryName;
        public int _nCustomerId;
        public string _sCustomerCode;
        public string _sCustomerName;
        public double _CreditReceive;
        public double _CashSales;
        public double _SellingExp;
        public double _TradePromotion;
        public double _OtherAdjustment;
        public double _OpeningBalance;
        public double _ClosingBalance;


        public int ChannelId
        {
            get { return _nChannelId; }
            set { _nChannelId = value; }
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
        public int CustomerTypeId
        {
            get { return _nCustomerTypeId; }
            set { _nCustomerTypeId = value; }
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
        public int AreaId
        {
            get { return _nAreaId; }
            set { _nAreaId = value; }
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
        public int TerritoryId
        {
            get { return _nTerritoryId; }
            set { _nTerritoryId = value; }
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
        public int CustomerId
        {
            get { return _nCustomerId; }
            set { _nCustomerId = value; }
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
        public double CreditReceive
        {
            get { return _CreditReceive; }
            set { _CreditReceive = value; }
        }
        public double CashSales
        {
            get { return _CashSales; }
            set { _CashSales = value; }
        }
        public double SellingExp
        {
            get { return _SellingExp; }
            set { _SellingExp = value; }
        }
        public double TradePromotion
        {
            get { return _TradePromotion; }
            set { _TradePromotion = value; }
        }
        public double OtherAdjustment
        {
            get { return _OtherAdjustment; }
            set { _OtherAdjustment = value; }
        }
        public double OpeningBalance
        {
            get { return _OpeningBalance; }
            set { _OpeningBalance = value; }
        }
        public double ClosingBalance
        {
            get { return _ClosingBalance; }
            set { _ClosingBalance = value; }
        }
    }

    public class rptMonthlyCollections : CollectionBaseCustom
    {
        public void Add(rptMonthlyCollection oMonthlyCollection)
        {
            this.List.Add(oMonthlyCollection);
        }
        public rptMonthlyCollection this[Int32 Index]
        {
            get
            {
                return (rptMonthlyCollection)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(rptMonthlyCollection))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void MonthlyCollectionChannelWise(DateTime dbFromDate, DateTime dbToDate)
        {
            dbToDate = dbToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            sQueryStringMaster.Append("  select   ");
            sQueryStringMaster.Append("  SBUID, SBUCode, SBUName  ");
            sQueryStringMaster.Append("  ,ChannelID, ChannelCode, ChannelName   ");
            sQueryStringMaster.Append("  ,sum(isnull(CreditLimit,0)) as CreditLimit, sum(isnull(CurrentBalance,0)) as [Current Balance]  ");
            sQueryStringMaster.Append("  ,sum(CreditCollection) as CreditReceive,sum(CashCollection) as CashSales,sum(OpeningBalance) as OpeningBalance,sum(ClosingBalance) as ClosingBalance  ");
            sQueryStringMaster.Append("  ,SUM(SEProfit) as SellingExp,SUM(TradePromotion) as TradePromotion,SUM(OtherAdjustment) as OtherAdjustment  ");
            sQueryStringMaster.Append("  ,sum(CreditCollection + CashCollection + SEProfit + TradePromotion + OtherAdjustment) as TotalCollection  ");
            sQueryStringMaster.Append("  from   ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  Select   ");
            sQueryStringMaster.Append("  p1.SBUID, p1.SBUCode, p1.SBUName  ");
            sQueryStringMaster.Append("  ,p1.ChannelID AS ChannelId,p1.ChannelCode AS ChannelCode,p1.Channeldescription AS ChannelName  ");
            sQueryStringMaster.Append("  ,p1.areaid AS AreaID,p1.AreaCode AS AreaCode, p1.AreaName AS AreaName   ");
            sQueryStringMaster.Append("  ,p1.territoryid AS TerritoryID,p1.TerritoryCode AS TerritoryCode,p1.TerritoryName AS TerritoryName   ");
            sQueryStringMaster.Append("  ,p1.Customerid AS CustomerId,p1.CustomerCode AS CustomerCode,p1.customername AS CustomerName   ");
            sQueryStringMaster.Append("  ,-(p1.CurrentBalance) as CurrentBalance  ");
            sQueryStringMaster.Append("  ,isnull(p4.CreditAmount,0)as CreditLimit  ");
            sQueryStringMaster.Append("  ,isnull(-(p6.IntBalance),0) as OpeningBalance  ");
            sQueryStringMaster.Append("  ,isnull(-(p7.IntBalance),0) as ClosingBalance  ");
            sQueryStringMaster.Append("  ,isnull(P8.CreditCollection,0) as CreditCollection  ");
            sQueryStringMaster.Append("  ,isnull(P9.CashCollection,0) as CashCollection  ");
            sQueryStringMaster.Append("  ,isnull(P10.SEProfit,0) as SEProfit  ");
            sQueryStringMaster.Append("  ,isnull(P11.Tradepromotion,0) as Tradepromotion  ");
            sQueryStringMaster.Append("  ,isnull(P12.OtherAdjustment,0) as OtherAdjustment  ");
            sQueryStringMaster.Append("  From   ");
            sQueryStringMaster.Append("  (   ");
            sQueryStringMaster.Append("  select * from v_customerdetails   ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as p1   ");
            sQueryStringMaster.Append("  Left Outer Join   ");
            sQueryStringMaster.Append("  (   ");
            sQueryStringMaster.Append("  select Customerid,MinCreditLimit as CreditAmount from t_CustomerCreditLimit   ");
            sQueryStringMaster.Append("  where ? between effectivedate and expirydate   ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as p4   ");
            sQueryStringMaster.Append("  on p1.CustomerID = p4.CustomerID   ");
            sQueryStringMaster.Append("    ");
            sQueryStringMaster.Append("  Left Outer Join ");
            sQueryStringMaster.Append("  (   ");
            sQueryStringMaster.Append("  select q1.customerid,  ((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0)) as IntBalance from  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as q1  ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("  where ct.trantypeid = ctt.trantypeid and transide = ? and ct.TranDate between ? and ?   and TranDate < ?     ");
            sQueryStringMaster.Append("  group by customerid  ");
            sQueryStringMaster.Append("  )   ");
            sQueryStringMaster.Append("  as q2  ");
            sQueryStringMaster.Append("  on q1.customerid = q2.customerid  ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("  where ct.trantypeid = ctt.trantypeid and transide = ?  and ct.TranDate between ? and ?  and TranDate < ?      ");
            sQueryStringMaster.Append("  group by customerid  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as q3  ");
            sQueryStringMaster.Append("  on q1.customerid = q3.customerid  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as p6   ");
            sQueryStringMaster.Append("  on p1.CustomerID = p6.CustomerID   ");
            sQueryStringMaster.Append("  Left Outer Join  ");
            sQueryStringMaster.Append("  (   ");
            sQueryStringMaster.Append("  select q1.customerid,  ((q1.CurrentBalance - isnull(q2.CreditAmount,0) ) + isnull(q3.DebitAmount,0)) as IntBalance from  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as q1  ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("  where ct.trantypeid = ctt.trantypeid and transide = ? and ct.TranDate between ? and ?  and TranDate < ?   ");
            sQueryStringMaster.Append("  group by customerid  ");
            sQueryStringMaster.Append("  )   ");
            sQueryStringMaster.Append("  as q2  ");
            sQueryStringMaster.Append("  on q1.customerid = q2.customerid  ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("  where ct.trantypeid = ctt.trantypeid and transide = ? and ct.TranDate between ? and ?  and TranDate < ?   ");
            sQueryStringMaster.Append("  group by customerid  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as q3  ");
            sQueryStringMaster.Append("  on q1.customerid = q3.customerid  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as p7   ");
            sQueryStringMaster.Append("  on p1.CustomerID = p7.CustomerID   ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select q1.customerid,   ( isnull(q2.CreditAmount,0) - isnull(q3.DebitAmount,0)) as CreditCollection from  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as q1  ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("  where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (?,?,?) and ct.TranDate between ? and ?   and TranDate < ?  ");
            sQueryStringMaster.Append("  group by customerid  ");
            sQueryStringMaster.Append("  )   ");
            sQueryStringMaster.Append("  as q2  ");
            sQueryStringMaster.Append("  on q1.customerid = q2.customerid  ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("  where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (?,?,?) and ct.TranDate between ? and ?  and TranDate < ?  ");
            sQueryStringMaster.Append("  group by customerid  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as q3  ");
            sQueryStringMaster.Append("  on q1.customerid = q3.customerid  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as p8  ");
            sQueryStringMaster.Append("  on P8.CustomerID = P1.CustomerID  ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select q1.customerid,   ( isnull(q2.CreditAmount,0) - isnull(q3.DebitAmount,0)) as CashCollection from  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as q1  ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("  where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (?) and ct.TranDate between ? and ?   and TranDate < ?  ");
            sQueryStringMaster.Append("  group by customerid  ");
            sQueryStringMaster.Append("  )   ");
            sQueryStringMaster.Append("  as q2  ");
            sQueryStringMaster.Append("  on q1.customerid = q2.customerid  ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("  where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (?) and ct.TranDate between ? and ?    and TranDate < ?  ");
            sQueryStringMaster.Append("  group by customerid  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as q3  ");
            sQueryStringMaster.Append("  on q1.customerid = q3.customerid  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as p9  ");
            sQueryStringMaster.Append("  on p9.CustomerID = P1.CustomerID  ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select q1.customerid,   ( isnull(q2.CreditAmount,0) - isnull(q3.DebitAmount,0)) as SEProfit from  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as q1  ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("  where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (?) and ct.TranDate between ? and ?   and TranDate < ? ");
            sQueryStringMaster.Append("  group by customerid  ");
            sQueryStringMaster.Append("  )   ");
            sQueryStringMaster.Append("  as q2  ");
            sQueryStringMaster.Append("  on q1.customerid = q2.customerid  ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("  where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (?) and ct.TranDate between ? and ?   and TranDate< ?  ");
            sQueryStringMaster.Append("  group by customerid  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as q3  ");
            sQueryStringMaster.Append("  on q1.customerid = q3.customerid  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as p10  ");
            sQueryStringMaster.Append("  on p10.CustomerID = P1.CustomerID  ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select q1.customerid,   ( isnull(q2.CreditAmount,0) - isnull(q3.DebitAmount,0)) as TradePromotion from  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as q1  ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("  where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (?) and ct.TranDate between ? and ?  and TranDate < ?   ");
            sQueryStringMaster.Append("  group by customerid  ");
            sQueryStringMaster.Append("  )   ");
            sQueryStringMaster.Append("  as q2  ");
            sQueryStringMaster.Append("  on q1.customerid = q2.customerid  ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("  where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (?) and ct.TranDate between ? and ?  and TranDate< ?   ");
            sQueryStringMaster.Append("  group by customerid  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as q3  ");
            sQueryStringMaster.Append("  on q1.customerid = q3.customerid  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as p11  ");
            sQueryStringMaster.Append("  on p11.CustomerID = P1.CustomerID  ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select q1.customerid,   ( isnull(q2.CreditAmount,0) - isnull(q3.DebitAmount,0)) as OtherAdjustment from  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, CurrentBalance from t_customerAccount  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as q1  ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, sum(amount)as CreditAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("  where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (?,?,?,?,?,?,?) and ct.TranDate between ? and ?  and TranDate < ?  ");
            sQueryStringMaster.Append("  group by customerid  ");
            sQueryStringMaster.Append("  )   ");
            sQueryStringMaster.Append("  as q2  ");
            sQueryStringMaster.Append("  on q1.customerid = q2.customerid  ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select customerid, sum(amount)as DebitAmount from t_customerTran ct, t_customerTrantype ctt   ");
            sQueryStringMaster.Append("  where ct.trantypeid = ctt.trantypeid and ct.trantypeid in (?,?) and ct.TranDate between ? and ?  and TranDate < ?   ");
            sQueryStringMaster.Append("  group by customerid  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as q3  ");
            sQueryStringMaster.Append("  on q1.customerid = q3.customerid  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as p12  ");
            sQueryStringMaster.Append("  on p12.CustomerID = P1.CustomerID  ");
            sQueryStringMaster.Append("  )  ");
            sQueryStringMaster.Append("  as qqq  ");
            sQueryStringMaster.Append("  group by  ");
            sQueryStringMaster.Append("  SBUID, SBUCode, SBUName   ");
            sQueryStringMaster.Append("  ,ChannelID, ChannelCode, ChannelName  ");
            sQueryStringMaster.Append("  order by sbuid  ");

            cmd.CommandTimeout = 60;
            cmd.CommandText = sQueryStringMaster.ToString();


            cmd.Parameters.AddWithValue("TranDate", dbToDate);

            cmd.Parameters.AddWithValue("TranSide", (short)Dictionary.TransectionSide.CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dbFromDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);

            cmd.Parameters.AddWithValue("TranSide", (short)Dictionary.TransectionSide.DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dbFromDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);

            cmd.Parameters.AddWithValue("TranSide", (short)Dictionary.TransectionSide.CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);

            cmd.Parameters.AddWithValue("TranSide", (short)Dictionary.TransectionSide.DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);

            cmd.Parameters.AddWithValue("TransectionType", (short)Dictionary.TransectionType.CREDIT_RECEIVE);
            cmd.Parameters.AddWithValue("TransectionType", (short)Dictionary.TransectionType.EPS_INSTALLMENT);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_CR);
            cmd.Parameters.AddWithValue("TranDate", dbFromDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);

            cmd.Parameters.AddWithValue("TransectionType", (short)Dictionary.TransectionType.CREDIT_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TransectionType", (short)Dictionary.TransectionType.EPS_INSTALLMENT_REVERSE);
            cmd.Parameters.AddWithValue("TranTypeID", (short)Dictionary.TransectionType.CANCELED_DR);
            cmd.Parameters.AddWithValue("TranDate", dbFromDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);

            cmd.Parameters.AddWithValue("TransectionType", (short)Dictionary.TransectionType.CASH_RECEIVE);
            cmd.Parameters.AddWithValue("TranDate", dbFromDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);

            cmd.Parameters.AddWithValue("TransectionType", (short)Dictionary.TransectionType.CASH_RECEIVE_REVERSE);
            cmd.Parameters.AddWithValue("TranDate", dbFromDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);

            cmd.Parameters.AddWithValue("TransectionType", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM);
            cmd.Parameters.AddWithValue("TranDate", dbFromDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);

            cmd.Parameters.AddWithValue("TransectionType", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_SE_CPM_REVERSE);
            cmd.Parameters.AddWithValue("TranDate", dbFromDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);

            cmd.Parameters.AddWithValue("TransectionType", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION);
            cmd.Parameters.AddWithValue("TranDate", dbFromDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);

            cmd.Parameters.AddWithValue("TransectionType", (short)Dictionary.TransectionType.ADJUSTMENT_FOR_TRADE_PROMOTION_REVERSE);
            cmd.Parameters.AddWithValue("TranDate", dbFromDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);

            cmd.Parameters.AddWithValue("TransectionType", (short)Dictionary.TransectionType.ADJUSTMENT);
            cmd.Parameters.AddWithValue("TransectionType", (short)Dictionary.TransectionType.ADVANCE_RECEIVED_FROM_CUSTOMER_IF_ANY);
            cmd.Parameters.AddWithValue("TransectionType", (short)Dictionary.TransectionType.DEBIT_NOTE_INTER_COMPANY_ADJUSTMENT);
            cmd.Parameters.AddWithValue("TransectionType", (short)Dictionary.TransectionType.INCOME_TAX_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TransectionType", (short)Dictionary.TransectionType.SPECIAL_DISCOUNT_IF_ANY);
            cmd.Parameters.AddWithValue("TransectionType", (short)Dictionary.TransectionType.VAT_DEDUCTED_AT_SOURCE);
            cmd.Parameters.AddWithValue("TransectionType", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_CREDIT);
            cmd.Parameters.AddWithValue("TranDate", dbFromDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);

            cmd.Parameters.AddWithValue("TransectionType", (short)Dictionary.TransectionType.ADJUSTMENT_REVERSE);
            cmd.Parameters.AddWithValue("TransectionType", (short)Dictionary.TransectionType.INITIAL_ADJUSTMENT_DEBIT);
            cmd.Parameters.AddWithValue("TranDate", dbFromDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);
            cmd.Parameters.AddWithValue("TranDate", dbToDate);


            GetDataMonthlyCollectionChannelWise(cmd);

        }

        private void GetDataMonthlyCollectionChannelWise(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptMonthlyCollection oItem = new rptMonthlyCollection();


                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelId = Convert.ToInt32(reader["ChannelID"]);
                    else oItem.ChannelId = -1;

                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)reader["ChannelCode"];
                    else oItem.ChannelCode = "";

                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)reader["ChannelName"];
                    else oItem.ChannelName = "";

                    oItem.CustomerTypeId = -1;
                    oItem.CustomerTypeCode = "";
                    oItem.CustomerTypeName = "";

                    oItem.AreaId = -1;
                    oItem.AreaCode = "";
                    oItem.AreaName = "";

                    oItem.TerritoryId = -1;
                    oItem.TerritoryCode = "";
                    oItem.TerritoryName = "";

                    oItem.CustomerId = -1;
                    oItem.CustomerCode = "";
                    oItem.CustomerName = "";

                    if (reader["CreditReceive"] != DBNull.Value)
                        oItem.CreditReceive = Convert.ToDouble(reader["CreditReceive"]);
                    else oItem.CreditReceive = 0;

                    if (reader["CashSales"] != DBNull.Value)
                        oItem.CashSales = Convert.ToDouble(reader["CashSales"]);
                    else oItem.CashSales = 0;

                    if (reader["SellingExp"] != DBNull.Value)
                        oItem.SellingExp = Convert.ToDouble(reader["SellingExp"]);
                    else oItem.SellingExp = 0;

                    if (reader["TradePromotion"] != DBNull.Value)
                        oItem.TradePromotion = Convert.ToDouble(reader["TradePromotion"]);
                    else oItem.TradePromotion = 0;

                    if (reader["OtherAdjustment"] != DBNull.Value)
                        oItem.OtherAdjustment = Convert.ToDouble(reader["OtherAdjustment"]);
                    else oItem.OtherAdjustment = 0;

                    if (reader["OpeningBalance"] != DBNull.Value)
                        oItem.OpeningBalance = Convert.ToDouble(reader["OpeningBalance"]);
                    else oItem.OpeningBalance = 0;

                    if (reader["ClosingBalance"] != DBNull.Value)
                        oItem.ClosingBalance = Convert.ToDouble(reader["ClosingBalance"]);
                    else oItem.ClosingBalance = 0;

                  
                    Add(oItem);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void FromDataSetForMonthlyCollectionChannelWise(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptMonthlyCollection oMonthlyCollection = new rptMonthlyCollection();

                    oMonthlyCollection.ChannelId = Convert.ToInt32(oRow["ChannelId"].ToString());
                    oMonthlyCollection.ChannelCode = (string)oRow["ChannelCode"];
                    oMonthlyCollection.ChannelName = (string)oRow["ChannelName"];

                    oMonthlyCollection.CustomerTypeId = -1;
                    oMonthlyCollection.CustomerTypeCode = "";
                    oMonthlyCollection.CustomerTypeName = "";

                    oMonthlyCollection.AreaId = -1;
                    oMonthlyCollection.AreaCode = "";
                    oMonthlyCollection.AreaName = "";

                    oMonthlyCollection.TerritoryId = -1;
                    oMonthlyCollection.TerritoryCode = "";
                    oMonthlyCollection.TerritoryName = "";

                    oMonthlyCollection.CustomerId = -1;
                    oMonthlyCollection.CustomerCode = "";
                    oMonthlyCollection.CustomerName = "";

                    oMonthlyCollection.CreditReceive = (double)oRow["CreditReceive"];
                    oMonthlyCollection.CashSales = (double)oRow["CashSales"];
                    oMonthlyCollection.SellingExp = (double)oRow["SellingExp"];
                    oMonthlyCollection.TradePromotion = (double)oRow["TradePromotion"];
                    oMonthlyCollection.OtherAdjustment = (double)oRow["OtherAdjustment"];
                    oMonthlyCollection.OpeningBalance = (double)oRow["OpeningBalance"];
                    oMonthlyCollection.ClosingBalance = (double)oRow["ClosingBalance"];

                    
                    InnerList.Add(oMonthlyCollection);
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

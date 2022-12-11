// <summary>
// Compamy: Transcom Electronics Limited
// Author: Mithun Sarkar
// Date: Feb 23, 2012
// Time" :  2:30 PM
// Description: Net Sales & Gross Margin Customer Wise
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
    public class rptNetSalesMarginCustomer
    {
        public int _nAreaID;
        public string _sAreaCode;
        public string _sAreaName;
        public int _nTerritoryID;
        public string _sTerritoryCode;
        public string _sTerritoryName;
        public double _Discount;
        public double _OtherCharge;
        public double _InvoiceAmount;
        public double _VATAmount;
        public double _CustomerProfitMargin;
        public double _CustomerSellingExpense;
        public double _TradePromotion;
        public double _Advertisement;
        public double _PrimaryFrieghtCost;
        public double _ProductWarrenty;
        public DateTime _FromDate;
        public DateTime _ToDate;
        public int _nSBUID;
        public string _sSBUName;
        public string _sSBUCode;
        public int _nChannelID;
        public string _sChannelCode;
        public string _sChannelName;
        public double _GrossSale;
        public int _nCustomerID;
        public string _sCustomerCode;
        public string _sCustomerName;
        public double _SalesProvission;
        public double _COGS;
        public double _AdjustedDPAmount;
        public double _AdjustedPWAmount;
        public double _TPQty;
        public double _TPValue;
        public double _RepQty;
        public double _RepValue;
        public double _AdjustedTPAmount;


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
        public double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        public double OtherCharge
        {
            get { return _OtherCharge; }
            set { _OtherCharge = value; }
        }
        public double InvoiceAmount
        {
            get { return _InvoiceAmount; }
            set { _InvoiceAmount = value; }
        }
        public double VATAmount
        {
            get { return _VATAmount; }
            set { _VATAmount = value; }
        }
        public double CustomerProfitMargin
        {
            get { return _CustomerProfitMargin; }
            set { _CustomerProfitMargin = value; }
        }
        public double CustomerSellingExpense
        {
            get { return _CustomerSellingExpense; }
            set { _CustomerSellingExpense = value; }
        }
        public double TradePromotion
        {
            get { return _TradePromotion; }
            set { _TradePromotion = value; }
        }
        public double Advertisement
        {
            get { return _Advertisement; }
            set { _Advertisement = value; }
        }
        public double PrimaryFrieghtCost
        {
            get { return _PrimaryFrieghtCost; }
            set { _PrimaryFrieghtCost = value; }
        }
        public double ProductWarrenty
        {
            get { return _ProductWarrenty; }
            set { _ProductWarrenty = value; }
        }
        public DateTime FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }
        public DateTime ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }
        public int SBUID
        {
            get { return _nSBUID; }
            set { _nSBUID = value; }
        }
        public string SBUName
        {
            get { return _sSBUName; }
            set { _sSBUName = value; }
        }
        public string SBUCode
        {
            get { return _sSBUCode; }
            set { _sSBUCode = value; }
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
        public double GrossSale
        {
            get { return _GrossSale; }
            set { _GrossSale = value; }
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
        public double SalesProvission
        {
            get { return _SalesProvission; }
            set { _SalesProvission = value; }
        }
        public double COGS
        {
            get { return _COGS; }
            set { _COGS = value; }
        }
        public double AdjustedDPAmount
        {
            get { return _AdjustedDPAmount; }
            set { _AdjustedDPAmount = value; }
        }
        public double AdjustedPWAmount
        {
            get { return _AdjustedPWAmount; }
            set { _AdjustedPWAmount = value; }
        }
        public double TPQty
        {
            get { return _TPQty; }
            set { _TPQty = value; }
        }
        public double TPValue
        {
            get { return _TPValue; }
            set { _TPValue = value; }
        }
        public double RepQty
        {
            get { return _RepQty; }
            set { _RepQty = value; }
        }
        public double RepValue
        {
            get { return _RepValue; }
            set { _RepValue = value; }
        }
        public double AdjustedTPAmount
        {
            get { return _AdjustedTPAmount; }
            set { _AdjustedTPAmount = value; }
        }
    }

    public class rptNetSalesMarginCustomers : CollectionBaseCustom
    {

        public void Add(rptNetSalesMarginCustomer oNetSalesMarginCustomer)
        {
            this.List.Add(oNetSalesMarginCustomer);
        }
        public rptNetSalesMarginCustomer this[Int32 Index]
        {
            get
            {
                return (rptNetSalesMarginCustomer)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(rptNetSalesMarginCustomer))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }
        public void NetSalesMarginCustomerWise(DateTime dbFromDate, DateTime dbToDate)
        {
            dbToDate = dbToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            sQueryStringMaster.Append("    Select * from (  ");
            sQueryStringMaster.Append("    Select   A.SBUID,A.SBUCode,A.SBUName   ");
            sQueryStringMaster.Append("    ,A.ChannelID,A.ChannelCode,A.ChannelDescription as ChannelName   ");
            sQueryStringMaster.Append("    ,A.AreaID,A.AreaCode,A.AreaName   ");
            sQueryStringMaster.Append("    ,A.TerritoryID,A.TerritoryCode,A.TerritoryName  ");
            sQueryStringMaster.Append("    ,A.CustomerID,A.CustomerCode,A.CustomerName  ");
            sQueryStringMaster.Append("    ,isnull(sum(B.InvoiceAmount),0) as InvoiceAmount,isnull(sum(B.Discount),0) as Discount, isnull(sum(B.OtherCharge),0) as OtherCharge, isnull(sum(COGS),0) as COGS   ");
            sQueryStringMaster.Append("    ,isnull(Sum(GrossSale),0) as GrossSale, isnull(SUM(Vatamount),0) as Vatamount ");
            sQueryStringMaster.Append("    ,isnull(Sum(AdjustedDPAmount),0) as AdjustedDPAmount,isnull(Sum(AdjustedPWAmount),0) as AdjustedPWAmount,isnull(Sum(AdjustedTPAmount),0) as AdjustedTPAmount ");
            sQueryStringMaster.Append("    ,isnull(sum(TotalTP),0) as TotalTP,isnull(sum(TotalTPValue),0) as TotalTPValue,isnull(sum(TPQty),0) as TPQty, isnull(sum(TPValue),0) as TPValue  ");
            sQueryStringMaster.Append("    ,isnull(sum(RepQty),0) as RepQty, isnull(sum(RepValue),0) as RepValue ");
            sQueryStringMaster.Append("    from   ");
            sQueryStringMaster.Append("    (   ");
            sQueryStringMaster.Append("    select Q1.CustomerID,Q1.InvoiceAmount,Q1.Discount,Q1.OtherCharge, q2.AdjustedDPAmount,q2.AdjustedPWAmount,Q2.AdjustedTPAmount,Q2.GrossSale,Q2.VatAmount,Q2.COGS,Q2.TotalTP,Q2.TotalTPValue, Q2.TPQty, Q2.TPValue, Q2.RepQty, Q2.RepValue from   ");
            sQueryStringMaster.Append("    (   ");
            sQueryStringMaster.Append("    select  Customerid, isnull(sum(CRInvoiceAmount)- abs(sum(DRInvoiceAmount)),0) as InvoiceAmount     ");
            sQueryStringMaster.Append("    ,isnull(SUM(CRDiscount)-abs(SUM(DRDiscount)),0) as Discount   ");
            sQueryStringMaster.Append("    ,isnull(SUM(CROtherCharge)-abs(SUM(DROtherCharge)),0) as OtherCharge   ");
            sQueryStringMaster.Append("    from    ");
            sQueryStringMaster.Append("    (   ");
            sQueryStringMaster.Append("    Select  IM.CustomerID,SUM(IM.InvoiceAmount) as CRInvoiceAmount,0 as DRInvoiceAmount   ");
            sQueryStringMaster.Append("    ,SUM(IM.Discount) as CRDiscount,0 as DRDiscount   ");
            sQueryStringMaster.Append("    ,SUM(IM.OtherCharge) as CROtherCharge,0 as DROtherCharge   ");
            sQueryStringMaster.Append("    from t_SalesInvoice IM    ");
            sQueryStringMaster.Append("    where IM.InvoiceDate Between ? and ? and IM.InvoiceDate < ?  ");
            sQueryStringMaster.Append("    and IM.InvoiceTypeID in (?,?,?,?) and IM.InvoiceStatus  not in (?)  ");
            sQueryStringMaster.Append("    Group BY IM.CustomerID   ");
            sQueryStringMaster.Append("    Union All   ");
            sQueryStringMaster.Append("    Select IM.CustomerID,0 as CRInvoiceAmount,SUM(IM.InvoiceAmount) as DRInvoiceAmount    ");
            sQueryStringMaster.Append("    ,0 as CRDiscount,SUM(IM.Discount) as DRDiscount   ");
            sQueryStringMaster.Append("    ,0 as CROtherCharge,SUM(IM.OtherCharge) as DROtherCharge   ");
            sQueryStringMaster.Append("    from t_SalesInvoice IM    ");
            sQueryStringMaster.Append("    where IM.InvoiceDate Between ? and ? and IM.InvoiceDate < ?    ");
            sQueryStringMaster.Append("    and IM.InvoiceTypeID in (?,?,?,?,?) and IM.InvoiceStatus  not in (?)  ");
            sQueryStringMaster.Append("    Group BY  IM.CustomerID   ");
            sQueryStringMaster.Append("    ) as qq1   ");
            sQueryStringMaster.Append("    Group By CustomerID   ");
            sQueryStringMaster.Append("    )  as Q1   ");
            sQueryStringMaster.Append("    Left Outer Join   ");
            sQueryStringMaster.Append("    (   ");
            sQueryStringMaster.Append("    Select CustomerID ");
            sQueryStringMaster.Append("    ,isnull(sum(QuantityCr)-abs(sum(QuantityDr)),0) as SalesQty, isnull(sum(AmountCr)-abs(sum(AmountDr)),0) as GrossSale    ");
            sQueryStringMaster.Append("    ,isnull(sum(VATCr)-abs(sum(VATDr)),0) as VatAmount, isnull(sum(COGSCr)-abs(sum(COGSDr)),0) as COGS  ");
            sQueryStringMaster.Append("    ,isnull(sum(SCCr)-abs(sum(SCDr)),0) as AdjustedDPAmount, isnull(sum(PWCr)-abs(sum(PWDr)),0) as AdjustedPWAmount  ");
            sQueryStringMaster.Append("    ,isnull(sum(TPCr)-abs(sum(TPDr)),0) as TotalTP,isnull(sum(TPValueCr)-abs(sum(TPValueDr)),0) as TotalTPValue ");
            sQueryStringMaster.Append("    ,isnull(sum(ActCrTPQty)-abs(sum(ActDrTPQty)),0) as TPQty, isnull(sum(ActCrTPValue)-abs(sum(ActDrTPValue)),0) as TPValue  ");
            sQueryStringMaster.Append("    ,isnull(sum(ActCrRepQty)-abs(sum(ActDrRepQty)),0) as RepQty, isnull(sum(ActCrRepValue)-abs(sum(ActDrRepValue)),0) as RepValue ");
            sQueryStringMaster.Append("    , isnull(sum(AdjustedTPCr)-abs(sum(AdjustedTPDr)),0) as AdjustedTPAmount ");
            sQueryStringMaster.Append("    from ");
            sQueryStringMaster.Append("    ( ");
            sQueryStringMaster.Append("    Select invoiceid,a.Productid,CustomerID ");
            sQueryStringMaster.Append("    ,QuantityCr, AmountCr, TPCr,TPValueCr, (ActCrTPQty* isnull(b.TPQty,0)) as ActCrTPQty,(ActCrTPValue* isnull(b.TPQty,0)) as ActCrTPValue ");
            sQueryStringMaster.Append("    ,(ActCrTPQty* isnull(b.RepQty,0)) as ActCrRepQty,(ActCrTPValue* isnull(b.RepQty,0)) as ActCrRepValue ");
            sQueryStringMaster.Append("    ,VATCr,COGSCr,SCCr,PWCr,AdjustedTPCr ");
            sQueryStringMaster.Append("    ,QuantityDr,AmountDr,TPDr,TPValueDr,ActDrTPQty, ActDrTPValue, 0 as ActDrRepQty, 0 as ActDrRepValue,VATDr,COGSDr,SCDr,PWDr,AdjustedTPDr   ");
            sQueryStringMaster.Append("    from ");
            sQueryStringMaster.Append("    ( ");
            sQueryStringMaster.Append("    select im.invoiceid,SID.Productid,IM.CustomerID  ");
            sQueryStringMaster.Append("    ,quantity as QuantityCr , isnull((unitPrice*Quantity),0) as AmountCr ");
            sQueryStringMaster.Append("    ,isnull(freeqty,0) as TPCr,isnull((freeqty*costPrice),0) as TPValueCr   ");
            sQueryStringMaster.Append("    ,ActCrTPQty = case when freeqty = 0 then 0 else (quantity + freeqty)/LSRatio end ");
            sQueryStringMaster.Append("    ,ActCrTPValue = case when freeqty = 0 then 0 else (CostPrice*(quantity + freeqty))/LSRatio end ");
            sQueryStringMaster.Append("    ,((quantity+isnull(freeQty,0))*SID.TradePrice*VATAmount) as VATCr , (CostPrice*(quantity+isnull(freeQty,0))) as COGSCr,(AdjustedDPAmount*Quantity) as SCCr,(AdjustedPWAmount*Quantity) as PWCr,(AdjustedTPAmount*Quantity) as AdjustedTPCr ");
            sQueryStringMaster.Append("    , 0 as QuantityDr,0 as AmountDr,0 as TPDr,0 as TPValueDr,0 as ActDrTPQty,0 as ActDrTPValue   ");
            sQueryStringMaster.Append("    , 0 as VATDr, 0 as COGSDr, 0 as SCDr, 0 as PWDr,0 as AdjustedTPDr    ");
            sQueryStringMaster.Append("    from t_salesinvoice IM, t_salesInvoiceDetail SID, t_product c ");
            sQueryStringMaster.Append("    where im.Invoiceid = Sid.Invoiceid and sid.productid = c.productid ");
            sQueryStringMaster.Append("    and im.Invoicedate between ? and ? and IM.InvoiceDate < ?  ");
            sQueryStringMaster.Append("    and im.invoicetypeid in(?,?,?,?)  and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("    ) as a ");
            sQueryStringMaster.Append("    left outer join ");
            sQueryStringMaster.Append("    ( ");
            sQueryStringMaster.Append("    Select * from temp_tpcalculation  ");
            sQueryStringMaster.Append("    )as b on a.productid = b.productid ");
            sQueryStringMaster.Append("    union all ");
            sQueryStringMaster.Append("    Select invoiceid,a.Productid,CustomerID ");
            sQueryStringMaster.Append("    ,QuantityCr,AmountCr,TPCr,TPValueCr,ActCrTPQty, ActCrTPValue, 0 as ActCrRepQty, 0 as ActCrRepValue ");
            sQueryStringMaster.Append("    ,VATCr,COGSCr,SCCr,PWCr,AdjustedTPCr   ");
            sQueryStringMaster.Append("    ,QuantityDr, AmountDr, TPDr,TPValueDr, (ActDrTPQty* isnull(b.TPQty,0)) as ActDrTPQty,(ActDrTPValue* isnull(b.TPQty,0)) as ActDrTPValue ");
            sQueryStringMaster.Append("    ,(ActDrTPQty* isnull(b.RepQty,0)) as ActDrRepQty,(ActDrTPValue* isnull(b.RepQty,0)) as ActDrRepValue,VATDr,COGSDr,SCDr,PWDr,AdjustedTPDr   ");
            sQueryStringMaster.Append("    from ");
            sQueryStringMaster.Append("    ( ");
            sQueryStringMaster.Append("    select im.invoiceid,SID.Productid,IM.CustomerID  ");
            sQueryStringMaster.Append("    , 0 as QuantityCr,0 as AmountCr,0 as TPCr,0 as TPValueCr,0 as ActCrTPQty,0 as ActCrTPValue  ");
            sQueryStringMaster.Append("    , 0 as VATCr, 0 as COGSCr, 0 as SCCr, 0 as PWCr,0 as AdjustedTPCr    ");
            sQueryStringMaster.Append("    ,quantity as QuantityDr , isnull((unitPrice*Quantity),0) as AmountDr ");
            sQueryStringMaster.Append("    ,isnull(freeqty,0) as TPDr,isnull((freeqty*costPrice),0) as TPValueDr   ");
            sQueryStringMaster.Append("    ,ActDrTPQty = case when freeqty = 0 then 0 else (quantity + freeqty)/LSRatio end ");
            sQueryStringMaster.Append("    ,ActDrTPValue = case when freeqty = 0 then 0 else (CostPrice*(quantity + freeqty))/LSRatio end ");
            sQueryStringMaster.Append("    ,((quantity+isnull(freeQty,0))*SID.TradePrice*VATAmount) as VATDr , (CostPrice*(quantity+isnull(freeQty,0))) as COGSDr,(AdjustedDPAmount*Quantity) as SCDr,(AdjustedPWAmount*Quantity) as PWDr,(AdjustedTPAmount*Quantity) as AdjustedTPDr ");
            sQueryStringMaster.Append("    from t_salesinvoice IM, t_salesInvoiceDetail SID, t_product c ");
            sQueryStringMaster.Append("    where im.Invoiceid = Sid.Invoiceid and sid.productid = c.productid ");
            sQueryStringMaster.Append("    and im.Invoicedate between ? and ? and IM.InvoiceDate < ?  ");
            sQueryStringMaster.Append("    and im.invoicetypeid in(?,?,?,?,?)  and invoicestatus not in (?)  ");
            sQueryStringMaster.Append("    ) as a ");
            sQueryStringMaster.Append("    left outer join ");
            sQueryStringMaster.Append("    ( ");
            sQueryStringMaster.Append("    Select * from temp_tpcalculation ");
            sQueryStringMaster.Append("    )as b on a.productid = b.productid ");
            sQueryStringMaster.Append("    ) as sales ");
            sQueryStringMaster.Append("    Group By CustomerID ");
            sQueryStringMaster.Append("    ) as Q2 on Q1.CustomerID=Q2.CustomerID   ");
            sQueryStringMaster.Append("    ) as B   ");
            sQueryStringMaster.Append("    Inner Join   ");
            sQueryStringMaster.Append("    (select * from v_CustomerDetails) as A   ");
            sQueryStringMaster.Append("    on A.CustomerID=B.CustomerID   ");
            sQueryStringMaster.Append("    Group BY A.SBUID,A.SBUCode,A.SBUName   ");
            sQueryStringMaster.Append("    ,A.ChannelID,A.ChannelCode,A.ChannelDescription       ");
            sQueryStringMaster.Append("    ,A.AreaID,A.AreaCode,A.AreaName    ");
            sQueryStringMaster.Append("    ,A.TerritoryID,A.TerritoryCode,A.TerritoryName  ");
            sQueryStringMaster.Append("    ,A.CustomerID,A.CustomerCode,A.CustomerName  ");
            sQueryStringMaster.Append(" )as finalquary  ");


            cmd.CommandTimeout = 0;
            cmd.CommandText = sQueryStringMaster.ToString();

            cmd.Parameters.AddWithValue("FromDate", dbFromDate);
            cmd.Parameters.AddWithValue("ToDate", dbToDate);
            cmd.Parameters.AddWithValue("ToDate", dbToDate);
            cmd.Parameters.AddWithValue("InvoiceType", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceType", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceType", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceType", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("FromDate", dbFromDate);
            cmd.Parameters.AddWithValue("ToDate", dbToDate);
            cmd.Parameters.AddWithValue("ToDate", dbToDate);
            cmd.Parameters.AddWithValue("InvoiceType", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceType", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceType", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceType", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceType", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("FromDate", dbFromDate);
            cmd.Parameters.AddWithValue("ToDate", dbToDate);
            cmd.Parameters.AddWithValue("ToDate", dbToDate);
            cmd.Parameters.AddWithValue("InvoiceType", (short)Dictionary.InvoiceType.CASH);
            cmd.Parameters.AddWithValue("InvoiceType", (short)Dictionary.InvoiceType.CREDIT);
            cmd.Parameters.AddWithValue("InvoiceType", (short)Dictionary.InvoiceType.EPS);
            cmd.Parameters.AddWithValue("InvoiceType", (short)Dictionary.InvoiceType.EASY_BUY);
            cmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);

            cmd.Parameters.AddWithValue("FromDate", dbFromDate);
            cmd.Parameters.AddWithValue("ToDate", dbToDate);
            cmd.Parameters.AddWithValue("ToDate", dbToDate);
            cmd.Parameters.AddWithValue("InvoiceType", (short)Dictionary.InvoiceType.CREDIT_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceType", (short)Dictionary.InvoiceType.CASH_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceType", (short)Dictionary.InvoiceType.EPS_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceType", (short)Dictionary.InvoiceType.EASY_BUY_REVERSE);
            cmd.Parameters.AddWithValue("InvoiceType", (short)Dictionary.InvoiceType.PRODUCT_RETURN);
            cmd.Parameters.AddWithValue("InvoiceStatus", (short)Dictionary.InvoiceStatus.CANCEL);

            GetDataSalesMarginCustomerWise(cmd);
        }

        private void GetDataSalesMarginCustomerWise(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptNetSalesMarginCustomer oItem = new rptNetSalesMarginCustomer();

                    if (reader["AreaID"] != DBNull.Value)
                        oItem.AreaID = Convert.ToInt32(reader["AreaID"]);
                    else oItem.AreaID = -1;

                    if (reader["AreaCode"] != DBNull.Value)
                        oItem.AreaCode = (string)reader["AreaCode"];
                    else oItem.AreaCode = "";

                    if (reader["AreaName"] != DBNull.Value)
                        oItem.AreaName = (string)reader["AreaName"];
                    else oItem.AreaName = "";

                    if (reader["TerritoryID"] != DBNull.Value)
                        oItem.TerritoryID = Convert.ToInt32(reader["TerritoryID"]);
                    else oItem.TerritoryID = -1;

                    if (reader["TerritoryCode"] != DBNull.Value)
                        oItem.TerritoryCode = (string)reader["TerritoryCode"];
                    else oItem.TerritoryCode = "";

                    if (reader["TerritoryName"] != DBNull.Value)
                        oItem.TerritoryName = (string)reader["TerritoryName"];
                    else oItem.TerritoryName = "";

                    if (reader["Discount"] != DBNull.Value)
                        oItem.Discount = Convert.ToDouble(reader["Discount"]);
                    else oItem.Discount = 0;

                    if (reader["OtherCharge"] != DBNull.Value)
                        oItem.OtherCharge = Convert.ToDouble(reader["OtherCharge"]);
                    else oItem.OtherCharge = 0;

                    if (reader["InvoiceAmount"] != DBNull.Value)
                        oItem.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"]);
                    else oItem.InvoiceAmount = 0;

                    if (reader["Vatamount"] != DBNull.Value)
                        oItem.VATAmount = Convert.ToDouble(reader["Vatamount"]);
                    else oItem.VATAmount = 0;

                    oItem.CustomerProfitMargin = 0;
                    oItem.CustomerSellingExpense = 0;
                    oItem.TradePromotion = 0;
                    oItem.Advertisement = 0;
                    oItem.PrimaryFrieghtCost = 0;
                    oItem.ProductWarrenty = 0;

                    oItem.FromDate = DateTime.Today.Date;
                    oItem.ToDate = DateTime.Today.Date;

                    if (reader["SBUID"] != DBNull.Value)
                        oItem.SBUID = Convert.ToInt32(reader["SBUID"]);
                    else oItem.SBUID = -1;

                    if (reader["SBUName"] != DBNull.Value)
                        oItem.SBUName = (string)reader["SBUName"];
                    else oItem.SBUName = "";

                    if (reader["SBUCode"] != DBNull.Value)
                        oItem.SBUCode = (string)reader["SBUCode"];
                    else oItem.SBUCode = "";

                    if (reader["ChannelID"] != DBNull.Value)
                        oItem.ChannelID = Convert.ToInt32(reader["ChannelID"]);
                    else oItem.ChannelID = -1;

                    if (reader["ChannelCode"] != DBNull.Value)
                        oItem.ChannelCode = (string)reader["ChannelCode"];
                    else oItem.ChannelCode = "";

                    if (reader["ChannelName"] != DBNull.Value)
                        oItem.ChannelName = (string)reader["ChannelName"];
                    else oItem.ChannelName = "";

                    if (reader["GrossSale"] != DBNull.Value)
                        oItem.GrossSale = Convert.ToDouble(reader["GrossSale"]);
                    else oItem.GrossSale = 0;

                    if (reader["CustomerID"] != DBNull.Value)
                        oItem.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    else oItem.CustomerID = -1;

                    if (reader["CustomerCode"] != DBNull.Value)
                        oItem.CustomerCode = (string)reader["CustomerCode"];
                    else oItem.CustomerCode = "";

                    if (reader["CustomerName"] != DBNull.Value)
                        oItem.CustomerName = (string)reader["CustomerName"];
                    else oItem.CustomerName = "";

                    oItem.SalesProvission = 0;

                    if (reader["COGS"] != DBNull.Value)
                        oItem.COGS = Convert.ToDouble(reader["COGS"]);
                    else oItem.COGS = 0;

                    if (reader["AdjustedDPAmount"] != DBNull.Value)
                        oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"]);
                    else oItem.AdjustedDPAmount = 0;

                    if (reader["AdjustedPWAmount"] != DBNull.Value)
                        oItem.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"]);
                    else oItem.AdjustedPWAmount = 0;

                    if (reader["TPQty"] != DBNull.Value)
                        oItem.TPQty = Convert.ToDouble(reader["TPQty"]);
                    else oItem.TPQty = 0;

                    if (reader["TPValue"] != DBNull.Value)
                        oItem.TPValue = Convert.ToDouble(reader["TPValue"]);
                    else oItem.TPValue = 0;

                    if (reader["RepQty"] != DBNull.Value)
                        oItem.RepQty = Convert.ToDouble(reader["RepQty"]);
                    else oItem.RepQty = 0;

                    if (reader["RepValue"] != DBNull.Value)
                        oItem.RepValue = Convert.ToDouble(reader["RepValue"]);
                    else oItem.RepValue = 0;

                    if (reader["AdjustedTPAmount"] != DBNull.Value)
                        oItem.AdjustedTPAmount = Convert.ToDouble(reader["AdjustedTPAmount"]);
                    else oItem.AdjustedTPAmount = 0;

                    Add(oItem);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void FromDataSetForSalesMarginCustomer(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptNetSalesMarginCustomer oNetSalesMarginCustomer = new rptNetSalesMarginCustomer();

                    oNetSalesMarginCustomer.AreaID = Convert.ToInt32(oRow["AreaID"].ToString());
                    oNetSalesMarginCustomer.AreaCode = (string)oRow["AreaCode"];
                    oNetSalesMarginCustomer.AreaName = (string)oRow["AreaName"];

                    oNetSalesMarginCustomer.TerritoryID = Convert.ToInt32(oRow["TerritoryID"].ToString());
                    oNetSalesMarginCustomer.TerritoryCode = (string)oRow["TerritoryCode"];
                    oNetSalesMarginCustomer.TerritoryName = (string)oRow["TerritoryName"];

                    oNetSalesMarginCustomer.Discount = (double)oRow["Discount"];
                    oNetSalesMarginCustomer.OtherCharge = (double)oRow["OtherCharge"];
                    oNetSalesMarginCustomer.InvoiceAmount = (double)oRow["InvoiceAmount"];
                    oNetSalesMarginCustomer.VATAmount = (double)oRow["Vatamount"];

                    oNetSalesMarginCustomer.CustomerProfitMargin = 0;
                    oNetSalesMarginCustomer.TradePromotion = 0;
                    oNetSalesMarginCustomer.Advertisement = 0;
                    oNetSalesMarginCustomer.PrimaryFrieghtCost = 0;
                    oNetSalesMarginCustomer.ProductWarrenty = 0;

                    oNetSalesMarginCustomer.FromDate = DateTime.Today.Date;
                    oNetSalesMarginCustomer.ToDate = DateTime.Today.Date;

                    oNetSalesMarginCustomer.SBUID = Convert.ToInt32(oRow["SBUID"].ToString());
                    oNetSalesMarginCustomer.SBUName = (string)oRow["SBUName"];
                    oNetSalesMarginCustomer.SBUCode = (string)oRow["SBUCode"];
                    oNetSalesMarginCustomer.ChannelID = Convert.ToInt32(oRow["ChannelID"].ToString());
                    oNetSalesMarginCustomer.ChannelCode = (string)oRow["ChannelCode"];
                    oNetSalesMarginCustomer.ChannelName = (string)oRow["ChannelName"];
                    oNetSalesMarginCustomer.GrossSale = (double)oRow["GrossSale"];

                    oNetSalesMarginCustomer.CustomerID = Convert.ToInt32(oRow["CustomerID"].ToString());
                    oNetSalesMarginCustomer.CustomerCode = (string)oRow["CustomerCode"];
                    oNetSalesMarginCustomer.CustomerName = (string)oRow["CustomerName"];

                    oNetSalesMarginCustomer.SalesProvission = 0;

                    oNetSalesMarginCustomer.COGS = (double)oRow["COGS"];
                    oNetSalesMarginCustomer.AdjustedDPAmount = (double)oRow["AdjustedDPAmount"];
                    oNetSalesMarginCustomer.AdjustedPWAmount = (double)oRow["AdjustedPWAmount"];
                    oNetSalesMarginCustomer.TPQty = (double)oRow["TPQty"];
                    oNetSalesMarginCustomer.TPValue = (double)oRow["TPValue"];
                    oNetSalesMarginCustomer.RepQty = (double)oRow["RepQty"];
                    oNetSalesMarginCustomer.RepValue = (double)oRow["RepValue"];
                    oNetSalesMarginCustomer.AdjustedTPAmount = (double)oRow["AdjustedTPAmount"];

                    InnerList.Add(oNetSalesMarginCustomer);
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

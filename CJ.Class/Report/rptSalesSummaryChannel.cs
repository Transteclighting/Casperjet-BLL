// <summary>
// Compamy: Transcom Electronics Limited
// Author: Mithun Sarkar
// Date: Feb 22, 2012
// Time" :  10:30 PM
// Description: Sales Summary Channel wise.
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
    public class rptSalesSummaryChannel
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
    }

    public class rptSalesSummaryChannels : CollectionBaseCustom
    {

        public void Add(rptSalesSummaryChannel oSalesSummaryChannel)
        {
            this.List.Add(oSalesSummaryChannel);
        }
        public rptSalesSummaryChannel this[Int32 Index]
        {
            get
            {
                return (rptSalesSummaryChannel)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(rptSalesSummaryChannel))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void SalesSummaryChannelWise( DateTime dbFromDate, DateTime dbToDate)
        {
            dbToDate = dbToDate.AddDays(1);
            OleDbCommand cmd = DBController.Instance.GetCommand();

            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            sQueryStringMaster.Append("      	Select * from ( 	    ");
            sQueryStringMaster.Append("      	select   A.SBUID,A.SBUCode,A.SBUName  	    ");
            sQueryStringMaster.Append("      	,A.ChannelID,A.ChannelCode,A.ChannelDescription as ChannelName  	    ");
            sQueryStringMaster.Append("      	,isnull(sum(B.InvoiceAmount),0) as InvoiceAmount,isnull(sum(B.Discount),0) as Discount, isnull(sum(B.OtherCharge),0) as OtherCharge, isnull(sum(COGS),0) as COGS  	    ");
            sQueryStringMaster.Append("      	,isnull(Sum(GrossSale),0) as GrossSale, isnull(SUM(Vatamount),0) as Vatamount,isnull(SUM(SalesProvision),0) as SalesProvission  	    ");
            sQueryStringMaster.Append("      	,isnull(Sum(TP),0) as TradePromotion, isnull(SUM(CSE),0) as CustomerSellingExpense,isnull(SUM(SC),0) as CustomerProfitMargin  	    ");
            sQueryStringMaster.Append("      	,isnull(Sum(ANP),0) as Advertisement, isnull(SUM(PW),0) as ProductWarrenty,isnull(SUM(PF),0) as PrimaryFrieghtCost  	    ");
            sQueryStringMaster.Append("      	,isnull(Sum(AdjustedDPAmount),0) as AdjustedDPAmount,isnull(Sum(AdjustedPWAmount),0) as AdjustedPWAmount	    ");
            sQueryStringMaster.Append("      	from  	    ");
            sQueryStringMaster.Append("      		    ");
            sQueryStringMaster.Append("      	(select * from v_CustomerDetails) as A  	    ");
            sQueryStringMaster.Append("      	Left Outer Join  	    ");
            sQueryStringMaster.Append("      	(  	    ");
            sQueryStringMaster.Append("      	select Q1.CustomerID,Q1.InvoiceAmount,Q1.Discount,Q1.OtherCharge, q2.AdjustedDPAmount,q2.AdjustedPWAmount,Q2.GrossSale,Q2.VatAmount,Q2.SalesProvision,Q2.COGS,Q2.TP,Q2.CSE, Q2.SC, Q2.ANP, Q2.PW, Q2.PF from  	    ");
            sQueryStringMaster.Append("      	(  	    ");
            sQueryStringMaster.Append("      	select  Customerid, isnull(sum(CRInvoiceAmount)- abs(sum(DRInvoiceAmount)),0) as InvoiceAmount    	    ");
            sQueryStringMaster.Append("      	,isnull(SUM(CRDiscount)-abs(SUM(DRDiscount)),0) as Discount  	    ");
            sQueryStringMaster.Append("      	,isnull(SUM(CROtherCharge)-abs(SUM(DROtherCharge)),0) as OtherCharge  	    ");
            sQueryStringMaster.Append("      	from   	    ");
            sQueryStringMaster.Append("      	(  	    ");
            sQueryStringMaster.Append("      	Select  IM.CustomerID,SUM(IM.InvoiceAmount) as CRInvoiceAmount,0 as DRInvoiceAmount  	    ");
            sQueryStringMaster.Append("      	,SUM(IM.Discount) as CRDiscount,0 as DRDiscount  	    ");
            sQueryStringMaster.Append("      	,SUM(IM.OtherCharge) as CROtherCharge,0 as DROtherCharge  	    ");
            sQueryStringMaster.Append("      		    ");
            sQueryStringMaster.Append("      	from t_SalesInvoice IM   	    ");
            sQueryStringMaster.Append("      	where IM.InvoiceDate Between ? and ? and IM.InvoiceDate < ?  	    ");
            sQueryStringMaster.Append("      	and IM.InvoiceTypeID in (?,?,?,?) and IM.InvoiceStatus  not in (?) 	    ");
            sQueryStringMaster.Append("      	Group BY IM.CustomerID  	    ");
            sQueryStringMaster.Append("      	Union All  	    ");
            sQueryStringMaster.Append("      	Select IM.CustomerID,0 as CRInvoiceAmount,SUM(IM.InvoiceAmount) as DRInvoiceAmount   	    ");
            sQueryStringMaster.Append("      	,0 as CRDiscount,SUM(IM.Discount) as DRDiscount  	    ");
            sQueryStringMaster.Append("      	,0 as CROtherCharge,SUM(IM.OtherCharge) as DROtherCharge  	    ");
            sQueryStringMaster.Append("      	from t_SalesInvoice IM   	    ");
            sQueryStringMaster.Append("      	where IM.InvoiceDate Between ? and ? and IM.InvoiceDate < ?     	    ");
            sQueryStringMaster.Append("      	and IM.InvoiceTypeID in (?,?,?,?,?) and IM.InvoiceStatus  not in (?) 	    ");
            sQueryStringMaster.Append("      	Group BY  IM.CustomerID  	    ");
            sQueryStringMaster.Append("      	) as qq1  	    ");
            sQueryStringMaster.Append("      	Group By CustomerID  	    ");
            sQueryStringMaster.Append("      	)  as Q1  	    ");
            sQueryStringMaster.Append("      	Left Outer Join  	    ");
            sQueryStringMaster.Append("      	(  	    ");
            sQueryStringMaster.Append("      	select  Customerid, isnull(sum(CRGrossSale)- abs(sum(DRGrossSale)),0) as GrossSale    	    ");
            sQueryStringMaster.Append("      	,isnull(SUM(CRVatAmount)-abs(SUM(DRVatAmount)),0) as VatAmount  	    ");
            sQueryStringMaster.Append("      	,isnull(SUM(CRCOGS)-abs(SUM(DRCOGS)),0) as COGS  	    ");
            sQueryStringMaster.Append("      	,isnull(SUM(CRTP)-abs(SUM(DRTP)),0) as TP  	    ");
            sQueryStringMaster.Append("      	,isnull(SUM(CRCSE)-abs(SUM(DRCSE)),0) as CSE  	    ");
            sQueryStringMaster.Append("      	,isnull(SUM(CRSC)-abs(SUM(DRSC)),0) as SC  	    ");
            sQueryStringMaster.Append("      	,isnull(SUM(CRANP)-abs(SUM(DRANP)),0) as ANP  	    ");
            sQueryStringMaster.Append("      	,isnull(SUM(CRPW)-abs(SUM(DRPW)),0) as PW  	    ");
            sQueryStringMaster.Append("      	,isnull(SUM(CRPF)-abs(SUM(DRPF)),0) as PF  	    ");
            sQueryStringMaster.Append("      	,isnull(SUM(CRSalesProvision)-abs(SUM(DRSalesProvision)),0) as SalesProvision  	    ");
            sQueryStringMaster.Append("      	,isnull(SUM(CRAdjustedDPAmount)-abs(SUM(DRAdjustedDPAmount)),0) as AdjustedDPAmount 	    ");
            sQueryStringMaster.Append("      	,isnull(SUM(CRAdjustedPWAmount)-abs(SUM(DRAdjustedPWAmount)),0) as AdjustedPWAmount  	    ");
            sQueryStringMaster.Append("      	from   	    ");
            sQueryStringMaster.Append("      	(  	    ");
            sQueryStringMaster.Append("      	Select  IM.CustomerID  	    ");
            sQueryStringMaster.Append("      	,sum(isnull((ISD.Quantity*ISD.UnitPrice),0))as CRGrossSale,0 as DRGrossSale  	    ");
            sQueryStringMaster.Append("      	,sum(isnull((ISD.Quantity*ISD.Tradeprice*ISD.VatAmount),0)) as  CRVatAmount,0 as DRVatamount  	    ");
            sQueryStringMaster.Append("      	,sum(isnull((ISD.Quantity*ISD.CostPrice),0)) as  CRCOGS,0 as DRCOGS  	    ");
            sQueryStringMaster.Append("      	,sum(isnull((ISD.Quantity*ISD.TradePromotion),0)) as CRTP,0 as DRTP  	    ");
            sQueryStringMaster.Append("      	,sum(isnull((ISD.Quantity*ISD.CustomerSellingExpense),0)) as CRCSE,0 as DRCSE  	    ");
            sQueryStringMaster.Append("      	,sum(isnull((ISD.Quantity*ISD.CustomerProfitMargin),0)) as CRSC,0 as DRSC  	    ");
            sQueryStringMaster.Append("      	,sum(isnull((ISD.Quantity*ISD.Advertisement),0)) as CRANP,0 as DRANP  	    ");
            sQueryStringMaster.Append("      	,sum(isnull((ISD.Quantity*ISD.ProductWarrenty),0)) as CRPW,0 as DRPW  	    ");
            sQueryStringMaster.Append("      	,sum(isnull((ISD.Quantity*ISD.PrimaryFreightCost),0)) as CRPF,0 as DRPF  	    ");
            sQueryStringMaster.Append("      	,sum(isnull((ISD.CustomerProfitMargin+ISD.CustomerSellingExpense+ISD.TradePromotion),0)) as CRSalesProvision,0 as DRSalesProvision  	    ");
            sQueryStringMaster.Append("      	,SUM(Quantity*AdjustedDPAmount) as CRAdjustedDPAmount,0 as DRAdjustedDPAmount	    ");
            sQueryStringMaster.Append("      	,SUM(Quantity*AdjustedPWAmount) as CRAdjustedPWAmount,0 as DRAdjustedPWAmount 	    ");
            sQueryStringMaster.Append("      	from t_SalesInvoice IM, t_SalesInvoiceDetail ISD  	    ");
            sQueryStringMaster.Append("      	where IM.InvoiceDate Between ? and ? and IM.InvoiceDate < ?   	    ");
            sQueryStringMaster.Append("      	and IM.InvoiceTypeID in (?,?,?,?) and IM.InvoiceStatus  not in (?) and IM.InvoiceID=ISD.InvoiceID  	    ");
            sQueryStringMaster.Append("      	Group BY IM.CustomerID  	    ");
            sQueryStringMaster.Append("      	Union ALL  	    ");
            sQueryStringMaster.Append("      	Select  IM.CustomerID  	    ");
            sQueryStringMaster.Append("      	,0 as CRGrossSale,sum(isnull((ISD.Quantity*ISD.UnitPrice),0)) as DRGrossSale  	    ");
            sQueryStringMaster.Append("      	,0 as CRVatAmount,sum(isnull((ISD.Quantity*ISD.Tradeprice*ISD.VatAmount),0)) as DRVatamount  	    ");
            sQueryStringMaster.Append("      	,0 as CRCOGS,sum(isnull((ISD.Quantity*ISD.CostPrice),0)) as DRCOGS  	    ");
            sQueryStringMaster.Append("      	,0 as CRTP,sum(isnull((ISD.Quantity*ISD.TradePromotion),0)) as DRTP  	    ");
            sQueryStringMaster.Append("      	,0 as CRCSE,sum(isnull((ISD.Quantity*ISD.CustomerSellingExpense),0)) as DRCSE  	    ");
            sQueryStringMaster.Append("      	,0 as CRSC,sum(isnull((ISD.Quantity*ISD.CustomerProfitMargin),0)) as DRSC  	    ");
            sQueryStringMaster.Append("      	,0 as CRANP,sum(isnull((ISD.Quantity*ISD.Advertisement),0)) as DRANP  	    ");
            sQueryStringMaster.Append("      	,0 as CRPW,sum(isnull((ISD.Quantity*ISD.ProductWarrenty),0)) as DRPW  	    ");
            sQueryStringMaster.Append("      	,0 as CRPF,sum(isnull((ISD.Quantity*ISD.PrimaryFreightCost),0)) as DRPF  	    ");
            sQueryStringMaster.Append("      	,0 as CRSalesProvision,sum(isnull((ISD.CustomerProfitMargin+ISD.CustomerSellingExpense+ISD.TradePromotion),0)) as DRSalesProvision  	    ");
            sQueryStringMaster.Append("      	,0 as CRAdjustedDPAmount,SUM(Quantity*AdjustedDPAmount) as DRAdjustedDPAmount	    ");
            sQueryStringMaster.Append("      	,0 as CRAdjustedPWAmount ,SUM(Quantity*AdjustedPWAmount) as DRAdjustedPWAmount	    ");
            sQueryStringMaster.Append("      	from t_SalesInvoice IM, t_SalesInvoiceDetail ISD  	    ");
            sQueryStringMaster.Append("      	where IM.InvoiceDate Between ? and ? and IM.InvoiceDate < ?   	    ");
            sQueryStringMaster.Append("      	and IM.InvoiceTypeID in (?,?,?,?,?) and IM.InvoiceStatus  not in (?) and IM.InvoiceID=ISD.InvoiceID  	    ");
            sQueryStringMaster.Append("      	Group BY IM.CustomerID  	    ");
            sQueryStringMaster.Append("      	) as qq2  	    ");
            sQueryStringMaster.Append("      	Group By CustomerID  	    ");
            sQueryStringMaster.Append("      	)  	    ");
            sQueryStringMaster.Append("      	as Q2  	    ");
            sQueryStringMaster.Append("      	on Q1.CustomerID=Q2.CustomerID  	    ");
            sQueryStringMaster.Append("      	) as B  	    ");
            sQueryStringMaster.Append("      	on A.CustomerID=B.CustomerID  	    ");
            sQueryStringMaster.Append("      	Group BY A.SBUID,A.SBUCode,A.SBUName  	    ");
            sQueryStringMaster.Append("      	,A.ChannelID,A.ChannelCode,A.ChannelDescription  	    ");

            //if (oDSDataString.DataString.Count > 0)
            //{
                sQueryStringMaster.Append("       )as finalquary  ");
            //+ oDSDataString.DataString[0].StringValue);
            //}
            //else
            //{
            //    sQueryStringMaster.Append("  ) as FinalQuery ");
            //}

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


            GetDataChannelWise(cmd);
        }

        public void GetDataChannelWise(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptSalesSummaryChannel oItem = new rptSalesSummaryChannel();

                    oItem.AreaID = 0;
                    oItem.AreaCode = "";
                    oItem.AreaName = "";

                    oItem.TerritoryID = 0;
                    oItem.TerritoryCode = "";
                    oItem.TerritoryName = "";

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

                    if (reader["CustomerProfitMargin"] != DBNull.Value)
                        oItem.CustomerProfitMargin = Convert.ToDouble(reader["CustomerProfitMargin"]);
                    else oItem.CustomerProfitMargin = 0;

                    if (reader["CustomerSellingExpense"] != DBNull.Value)
                        oItem.CustomerSellingExpense = Convert.ToDouble(reader["CustomerSellingExpense"]);
                    else oItem.CustomerSellingExpense = 0;

                    if (reader["TradePromotion"] != DBNull.Value)
                        oItem.TradePromotion = Convert.ToDouble(reader["TradePromotion"]);
                    else oItem.TradePromotion = 0;

                    if (reader["Advertisement"] != DBNull.Value)
                        oItem.Advertisement = Convert.ToDouble(reader["Advertisement"]);
                    else oItem.Advertisement = 0;

                    if (reader["PrimaryFrieghtCost"] != DBNull.Value)
                        oItem.PrimaryFrieghtCost = Convert.ToDouble(reader["PrimaryFrieghtCost"]);
                    else oItem.PrimaryFrieghtCost = 0;

                    if (reader["ProductWarrenty"] != DBNull.Value)
                        oItem.ProductWarrenty = Convert.ToDouble(reader["ProductWarrenty"]);
                    else oItem.ProductWarrenty = 0;

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

                    oItem.CustomerID = 0;
                    oItem.CustomerCode = "";
                    oItem.CustomerName = "";

                    if (reader["SalesProvission"] != DBNull.Value)
                        oItem.SalesProvission = Convert.ToDouble(reader["SalesProvission"]);
                    else oItem.SalesProvission = 0;


                    if (reader["COGS"] != DBNull.Value)
                        oItem.COGS = Convert.ToDouble(reader["COGS"]);
                    else oItem.COGS = 0;


                    if (reader["AdjustedDPAmount"] != DBNull.Value)
                        oItem.AdjustedDPAmount = Convert.ToDouble(reader["AdjustedDPAmount"]);
                    else oItem.AdjustedDPAmount = 0;

                    if (reader["AdjustedPWAmount"] != DBNull.Value)
                        oItem.AdjustedPWAmount = Convert.ToDouble(reader["AdjustedPWAmount"]);
                    else oItem.AdjustedPWAmount = 0;

                    Add(oItem);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void FromDataSetForSalesSummaryChannel(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptSalesSummaryChannel oSalesSummaryChannel = new rptSalesSummaryChannel();

                    oSalesSummaryChannel.AreaID = 0;
                    oSalesSummaryChannel.AreaCode = "";
                    oSalesSummaryChannel.AreaName = "";
                    oSalesSummaryChannel.TerritoryID = 0;
                    oSalesSummaryChannel.TerritoryCode = "";
                    oSalesSummaryChannel.TerritoryName = "";

                    oSalesSummaryChannel.Discount = (double)oRow["Discount"];
                    oSalesSummaryChannel.OtherCharge = (double)oRow["OtherCharge"];
                    oSalesSummaryChannel.InvoiceAmount = (double)oRow["InvoiceAmount"];
                    oSalesSummaryChannel.VATAmount = (double)oRow["Vatamount"];
                    oSalesSummaryChannel.CustomerProfitMargin = (double)oRow["CustomerProfitMargin"];
                    oSalesSummaryChannel.TradePromotion = (double)oRow["CustomerSellingExpense"];
                    oSalesSummaryChannel.Advertisement = (double)oRow["Advertisement"];
                    oSalesSummaryChannel.PrimaryFrieghtCost = (double)oRow["PrimaryFrieghtCost"];
                    oSalesSummaryChannel.ProductWarrenty = (double)oRow["ProductWarrenty"];
                    oSalesSummaryChannel.FromDate = DateTime.Today.Date;
                    oSalesSummaryChannel.ToDate = DateTime.Today.Date;

                    oSalesSummaryChannel.SBUID = Convert.ToInt32(oRow["SBUID"].ToString());
                    oSalesSummaryChannel.SBUName = (string)oRow["SBUName"];
                    oSalesSummaryChannel.SBUCode = (string)oRow["SBUCode"];
                    oSalesSummaryChannel.ChannelID = Convert.ToInt32(oRow["ChannelID"].ToString());
                    oSalesSummaryChannel.ChannelCode = (string)oRow["ChannelCode"];
                    oSalesSummaryChannel.ChannelName = (string)oRow["ChannelName"];
                    oSalesSummaryChannel.GrossSale = (double)oRow["GrossSale"];

                    oSalesSummaryChannel.CustomerID = 0;
                    oSalesSummaryChannel.CustomerCode = "";
                    oSalesSummaryChannel.CustomerName = "";
                    oSalesSummaryChannel.SalesProvission = (double)oRow["SalesProvission"];
                    oSalesSummaryChannel.COGS = (double)oRow["COGS"];
                    oSalesSummaryChannel.AdjustedDPAmount = (double)oRow["AdjustedDPAmount"];
                    oSalesSummaryChannel.AdjustedPWAmount = (double)oRow["AdjustedPWAmount"];

         
                    InnerList.Add(oSalesSummaryChannel);
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

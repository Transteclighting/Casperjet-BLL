// <summary>
// Compamy: Transcom Electronics Limited
// Author: MD. Humayun Rashid
// Date: May 21, 2015
// Time : 03:59 PM
// Description: Class for BankIst.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.DMS
{
   public class SecondarySalesDayWise
    {
        
        private string _sAreaName;
        private string _sTerritoryName;
        private int _nCustomerID;
        private string _sCustomerCode;
        private string _sCustomerName;
        
        private int _nAreaID;
        private int _nTerritoryID;
        private double _nSalesTO;
        private double _nTGTTO;
        private DateTime _dTranDate;
        private double _nPriSalesTO;
        private double _nSecSalesTO;
        private double _nSTKVal;
        private double _nBalance;
        private double _nPercent;

        public string AreaName
        {
            get { return _sAreaName; }
            set { _sAreaName = value.Trim(); }
        }
        public string TerritoryName
        {
            get { return _sTerritoryName; }
            set { _sTerritoryName = value.Trim(); }
        }
        public int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }                            
        public int AreaID
        {
            get { return _nAreaID; }
            set { _nAreaID = value; }
        }
        public int TerritoryID
        {
            get { return _nTerritoryID; }
            set { _nTerritoryID = value; }
        }
        public double TGTTO
           {
               get { return _nTGTTO; }
               set { _nTGTTO = value; }
           }
        public double SalesTO
           {
               get { return _nSalesTO; }
               set { _nSalesTO = value; }
           }
        public DateTime TranDate
           {
               get { return _dTranDate; }
               set { _dTranDate = value; }
           }
        public double PriSalesTO
           {
               get { return _nPriSalesTO; }
               set { _nPriSalesTO = value; }
           }
        public double SecSalesTO
       {
           get { return _nSecSalesTO; }
           set { _nSecSalesTO = value; }
       }
        public double STKVal
           {
               get { return _nSTKVal; }
               set { _nSTKVal = value; }
           }
        public double Balance
           {
               get { return _nBalance; }
               set { _nBalance = value; }
           }
        public double Percent
           {
               get { return _nPercent; }
               set { _nPercent = value; }
           }
    }

    public class SecondarySalesDayWises : CollectionBaseCustom
    {
        public void Add(SecondarySalesDayWise oSecondarySalesDayWise)
        {
            this.List.Add(oSecondarySalesDayWise);
        }

        public SecondarySalesDayWise this[Int32 Index]
        {
            get
            {
                return (SecondarySalesDayWise)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(SecondarySalesDayWise))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        // DayWiseSecondaryTO Details Method
        public void DayWiseSecondaryTO(int nUserID, DateTime dDFromDate, DateTime dDToDate, int nAreaID, int nTerritoryID, int nCustomerID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nCustID = 0;

            sSql= @"
                    Set dateformat dmy
                    select Customercode,Customername,Areaid,Areaname,Territoryid,Territoryname,GFinal.CustomerID,  TranDate,balance, STKVal,TGTTO, PriSalesTO,SecSalesTO as SalesTO " +
                    " from " +
                    " ( " +
                    " select isnull(Sec.DistributorID,Pri.CustomerID)as CustomerID, isnull(Sec.TranDate,Pri.invoicedate)as TranDate,  " +
                    " isnull(TGTTO,0)as TGTTO, isnull(SalesTO,0)as SecSalesTO, isnull(PriSalesTO,0) as PriSalesTO " +
                    " from " +
                    " ( " +
                    " select isnull(Q1.MarketGroupID,Q2.DistributorID)as DistributorID, " +
                    " isnull(Q1.PeriodDate,Q2.TranDate)as TranDate,isnull(TGTTO,0)as TGTTO, isnull(SalesTO,0)as SalesTO " +
                    " from " +
                    " ( " +
                    " SELECT  MarketGroupID,PeriodDate, round(sum(TurnOver),0) AS TGTTO " +     
                    " FROM  BLLSysDB.dbo.t_PlanBudgetTarget   " +
                    " where PeriodDate between '" + dDFromDate + "' and '" + dDToDate + "' and PeriodDate <'" + dDToDate + "' " +
                    " and MarketGroupID in (select DistributorID from t_DMSUser) " +
                    " GROUP BY MarketGroupID,PeriodDate " +
                    " )As Q1 " +
                    " full outer join " +
                    " ( " +
                    " select DistributorID,TranDate, sum(NetAmount)as SalesTO " + 
                    " from t_DMSProductTran  " +
                    " where TranDate between '" + dDFromDate + "' and '" + dDToDate + "'  and TranDate <'" + dDToDate + "' " +
                    " and tranTypeID=2  " +
                    " group by DistributorID, TranDate " +
                    " ) Q2 on Q1.MarketGroupID=Q2.DistributorID and Q1.PeriodDate=Q2.TranDate " +
                    " )As Sec " +

                    " full outer join " +

                    " ( " +
                    " select CustomerID,CustomerCode,invoicedate, sum (PriSalesTO)as PriSalesTO  " +   
                    " from " +
                    " (  " +
                    " select CustomerID,CustomerCode,cast(convert(nvarchar(12),InvoiceDate,106)as Datetime) as InvoiceDate,isnull(sum(crAmount) - abs(sum(drAmount)),0) as PriSalesTO     " +   
                    " from      " +
                    " (     " +
                    " select a.CustomerID,CustomerCode,invoicedate,sum(invoiceamount) as crAmount, 0 as drAmount " +
                    " from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v    " +
                    " where invoicedate between '" + dDFromDate + "' and '" + dDToDate + "' and invoicedate <'" + dDToDate + "' " +
                    " and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) " + 
                    " and a.CustomerID in (select DistributorID from t_DMSUser) " +
                    " group by  a.CustomerID,CustomerCode,invoicedate  " +
                    " union all      " +
                    " select a.CustomerID,CustomerCode,month(invoicedate)as MonthNO, 0 as crAmount,sum(invoiceamount) as drAmount " +
                    " from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v        " +
                    " where invoicedate between '" + dDFromDate + "' and '" + dDToDate + "' and invoicedate <'" + dDToDate + "' " +
                    " and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) " +
                    " and a.CustomerID in (select DistributorID from t_DMSUser) " +
                    " group by  a.CustomerID,CustomerCode,invoicedate " + 
                    " )as p2    " +
                    " group by CustomerID,CustomerCode,invoicedate " +
                    " ) as TELBLL " +
                    " group by  CustomerID,CustomerCode,invoicedate " +

                    " )as Pri on Sec.DistributorID=Pri.CustomerID and Sec.TranDate=Pri.invoicedate " +
                    " )As GFinal " +

                    " inner join " +
                    " ( " +
                    " select Customercode,Customerid,Customername,Areaid,Areaname,Territoryid,Territoryname,balance " +
                    " from v_customerdetails where channelid=2  " +
                    " ) as Cust on GFinal.CustomerID=Cust.Customerid " +
                    " inner join " +
                    " ( " +
                    " select DistributorID, sum(STKVal)as STKVal " +
                    " from " +
                    " ( " +
                    " select a.ProductID,DistributorID,NSP,CurrentStock,((NSP*CurrentStock)*0.95)as STKVal " +
                    " from t_DMSProductStock a, v_ProductDetails b " +
                    " where a.ProductID=b.ProductID and DistributorID in (select DistributorID from t_DMSUser) " +
                    " )As Stk " +
                    " group by DistributorID " +
                    " )as STK on GFinal.CustomerID=STK.DistributorID where ";


            if (nCustomerID > -1)
            {
                sSql = sSql + " GFinal.customerid= '" + nCustomerID + "'";

            }
            else
            {
                sSql = sSql + " GFinal.customerid IN (select CustomerID from v_CustomerDetails a,t_UserPermissionData b "
                           + "  where b.DataID=a.CustomerID and b.UserID= '" + nUserID + "' and Isactive=1 )";
                cmd.Parameters.AddWithValue("UserID", nUserID);

            }
            if (nAreaID != -1)
            {
                sSql = sSql + " and areaid = " + nAreaID + "";

            }
            if (nTerritoryID != -1)
            {
                sSql = sSql + " and territoryid = " + nTerritoryID + "";

            }
            
           
            sSql = sSql + " order by AreaId,AreaName,TerritoryID,TerritoryName,GFinal.CustomerID,CustomerName,TranDate ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    //rptSales orptSales = new rptSales();
                    SecondarySalesDayWise oSecondarySalesDayWise = new SecondarySalesDayWise();
                    


                    //if (Convert.ToInt32(reader["netsalesQty"].ToString()) != 0)
                    {                       
                       
                        
                        oSecondarySalesDayWise.AreaID = (int)reader["AreaID"];
                        oSecondarySalesDayWise.AreaName = (string)reader["areaname"].ToString();
                        oSecondarySalesDayWise.TerritoryID = (int)reader["TerritoryID"];
                        oSecondarySalesDayWise.TerritoryName =(string) reader["territoryname"].ToString();
                        oSecondarySalesDayWise.CustomerID = Convert.ToInt16(reader["CustomerID"]);
                        //oSecondarySalesDayWise.CustomerCode =(string) reader["CustomerCode"].ToString();
                        oSecondarySalesDayWise.CustomerName =(string) reader["CustomerName"].ToString();
                        oSecondarySalesDayWise.TranDate = Convert.ToDateTime(reader["TranDate"]);
                        oSecondarySalesDayWise.SalesTO=Convert.ToDouble(reader["SalesTO"]);
                        oSecondarySalesDayWise.TGTTO = Convert.ToDouble(reader["TGTTO"]);
                        oSecondarySalesDayWise.PriSalesTO = Convert.ToDouble(reader["PriSalesTO"]);
                    

                        if (oSecondarySalesDayWise.CustomerID != nCustID)
                        {
                            oSecondarySalesDayWise.STKVal = Convert.ToDouble(reader["STKVal"]);
                            oSecondarySalesDayWise.Balance = Convert.ToDouble(reader["Balance"]);
                            nCustID = oSecondarySalesDayWise.CustomerID;
                        }

                        else
                        {
                            oSecondarySalesDayWise.STKVal = 0;
                            oSecondarySalesDayWise.Balance = 0;
                        }

                        InnerList.Add(oSecondarySalesDayWise);
                    }
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // DayWiseSecondaryTO Summary Method
        public void DayWiseSecondaryTOSummary(int nUserID, DateTime dDFromDate, DateTime dDToDate, int nAreaID, int nTerritoryID, int nCustomerID, int nPercent)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nCustID = 0;

            sSql= @" 
                    Set dateformat dmy
                    select Customercode,Customername,Areaid,Areaname,Territoryid,Territoryname,GFinal.CustomerID,  balance, STKVal,TGTTO, " + 
                    " PriSalesTO,PriAch,SecSalesTO,SecAch " +
                    " from " +
                    " ( " +
                    " select Customercode,Customername,Areaid,Areaname,Territoryid,Territoryname,GFinal.CustomerID,  balance, STKVal,TGTTO, " + 
                    " PriSalesTO,  " +
                    " case when TGTTO > 0 then (PriSalesTO/TGTTO)*100  else 0 end as PriAch, " +
                    " SecSalesTO, " +
                    " case when TGTTO > 0 then (SecSalesTO/TGTTO)*100  else 0 end as SecAch " +
                    " from " +
                    " ( " +
                    " select isnull(Sec.DistributorID,Pri.CustomerID)as CustomerID,   " +
                    " isnull(TGTTO,0)as TGTTO, isnull(SalesTO,0)as SecSalesTO, isnull(PriSalesTO,0) as PriSalesTO " +
                    " from " +
                    " ( " +
                    " select isnull(Q1.MarketGroupID,Q2.DistributorID)as DistributorID, isnull(TGTTO,0)as TGTTO, isnull(SalesTO,0)as SalesTO " +
                    " from " +
                    " ( " +
                    " SELECT  MarketGroupID, round(sum(TurnOver),0) AS TGTTO  " +    
                    " FROM  BLLSysDB.dbo.t_PlanBudgetTarget   " +
                    " where PeriodDate between '" + dDFromDate + "' and '" + dDToDate + "' and PeriodDate <'" + dDToDate + "' " +
                    " and MarketGroupID in (select DistributorID from t_DMSUser) " +
                    " GROUP BY MarketGroupID " +
                    " )As Q1 " +
                    " full outer join " +
                    " ( " +
                    " select DistributorID, sum(NetAmount)as SalesTO " + 
                    " from t_DMSProductTran  " +
                    " where TranDate between '" + dDFromDate + "' and '" + dDToDate + "'  and TranDate <'" + dDToDate + "' " +
                    " and tranTypeID=2  " +
                    " group by DistributorID " +
                    " ) Q2 on Q1.MarketGroupID=Q2.DistributorID " + 
                    " )As Sec " +

                    " full outer join " +

                    " ( " +
                    " select CustomerID,CustomerCode, sum (PriSalesTO)as PriSalesTO  " +   
                    " from " +
                    " (  " +
                    " select CustomerID,CustomerCode,cast(convert(nvarchar(12),InvoiceDate,106)as Datetime) as InvoiceDate,isnull(sum(crAmount) - abs(sum(drAmount)),0) as PriSalesTO      " +  
                    " from      " +
                    " (     " +
                    " select a.CustomerID,CustomerCode,invoicedate,sum(invoiceamount) as crAmount, 0 as drAmount " +
                    " from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v    " +
                    " where invoicedate between '" + dDFromDate + "' and '" + dDToDate + "' and invoicedate <'" + dDToDate + "' " +
                    " and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) " + 
                    " and a.CustomerID in (select DistributorID from t_DMSUser) " +
                    " group by  a.CustomerID,CustomerCode,invoicedate  " +
                    " union all      " +
                    " select a.CustomerID,CustomerCode,month(invoicedate)as MonthNO, 0 as crAmount,sum(invoiceamount) as drAmount " +
                    " from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v        " +
                    " where invoicedate between '" + dDFromDate + "' and '" + dDToDate + "' and invoicedate <'" + dDToDate + "' " +
                    " and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) " +
                    " and a.CustomerID in (select DistributorID from t_DMSUser) " +
                    " group by  a.CustomerID,CustomerCode,invoicedate " + 
                    " )as p2    " +
                    " group by CustomerID,CustomerCode,invoicedate " +
                    " ) as TELBLL " +
                    " group by  CustomerID,CustomerCode " +

                    " )as Pri on Sec.DistributorID=Pri.CustomerID  " +
                    " )As GFinal " +

                    " inner join " +
                    " ( " +
                    " select Customercode,Customerid,Customername,Areaid,Areaname,Territoryid,Territoryname,balance " +
                    " from v_customerdetails where channelid=2  " +
                    " ) as Cust on GFinal.CustomerID=Cust.Customerid " +
                    " inner join " +
                    " ( " +
                    " select DistributorID, sum(STKVal)as STKVal " +
                    " from " +
                    " ( " +
                    " select a.ProductID,DistributorID,NSP,CurrentStock,((NSP*CurrentStock)*0.95)as STKVal " +
                    " from t_DMSProductStock a, v_ProductDetails b " +
                    " where a.ProductID=b.ProductID and DistributorID in (select DistributorID from t_DMSUser) " +
                    " )As Stk " +
                    " group by DistributorID " +
                    " )as STK on GFinal.CustomerID=STK.DistributorID " +
                    " )As GFinal where ";


            if (nCustomerID > -1)
            {
                sSql = sSql + " GFinal.customerid= '" + nCustomerID + "'";

            }
            else
            {
                sSql = sSql + " GFinal.customerid IN (select CustomerID from v_CustomerDetails a,t_UserPermissionData b "
                           + "  where b.DataID=a.CustomerID and b.UserID= '" + nUserID + "' and Isactive=1 )";
                cmd.Parameters.AddWithValue("UserID", nUserID);

            }
            if (nAreaID != -1)
            {
                sSql = sSql + " and areaid = " + nAreaID + "";

            }
            if (nTerritoryID != -1)
            {
                sSql = sSql + " and territoryid = " + nTerritoryID + "";

            }

            if (nPercent != 0)
            {
                sSql = sSql + " and SecAch <= " + nPercent + "";
            }

            sSql = sSql + " order by AreaId,AreaName,TerritoryID,TerritoryName,GFinal.CustomerID,CustomerName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    //rptSales orptSales = new rptSales();
                    SecondarySalesDayWise oSecondarySalesDayWise = new SecondarySalesDayWise();



                    //if (Convert.ToInt32(reader["netsalesQty"].ToString()) != 0)
                    {


                        oSecondarySalesDayWise.AreaID = (int)reader["AreaID"];
                        oSecondarySalesDayWise.AreaName = (string)reader["areaname"].ToString();
                        oSecondarySalesDayWise.TerritoryID = (int)reader["TerritoryID"];
                        oSecondarySalesDayWise.TerritoryName = (string)reader["territoryname"].ToString();
                        oSecondarySalesDayWise.CustomerID = Convert.ToInt16(reader["CustomerID"]);
                        //oSecondarySalesDayWise.CustomerCode =(string) reader["CustomerCode"].ToString();
                        oSecondarySalesDayWise.CustomerName = (string)reader["CustomerName"].ToString();
                        //oSecondarySalesDayWise.TranDate = Convert.ToDateTime(reader["TranDate"]);
                        //oSecondarySalesDayWise.SalesTO = Convert.ToDouble(reader["SalesTO"]);
                        oSecondarySalesDayWise.SecSalesTO = Convert.ToDouble(reader["SecSalesTO"]);
                        oSecondarySalesDayWise.TGTTO = Convert.ToDouble(reader["TGTTO"]);
                        oSecondarySalesDayWise.PriSalesTO = Convert.ToDouble(reader["PriSalesTO"]);


                        if (oSecondarySalesDayWise.CustomerID != nCustID)
                        {
                            oSecondarySalesDayWise.STKVal = Convert.ToDouble(reader["STKVal"]);
                            oSecondarySalesDayWise.Balance = Convert.ToDouble(reader["Balance"]);
                            nCustID = oSecondarySalesDayWise.CustomerID;
                        }

                        else
                        {
                            oSecondarySalesDayWise.STKVal = 0;
                            oSecondarySalesDayWise.Balance = 0;
                        }

                        InnerList.Add(oSecondarySalesDayWise);
                    }
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // RouteWiseSalesTO Details Method

        public void RouteWiseSalesTO(int nUserID, DateTime dDFromDate, DateTime dDToDate, int nAreaID, int nTerritoryID, int nCustomerID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nCustID = 0;

            sSql = @"
                    Set dateformat dmy
                    select Customercode,Customername,Areaid,Areaname,Territoryid,Territoryname,GFinal.CustomerID,  TranDate,balance, STKVal,TGTTO, PriSalesTO,SecSalesTO as SalesTO " +
                    " from " +
                    " ( " +
                    " select isnull(Sec.DistributorID,Pri.CustomerID)as CustomerID, isnull(Sec.TranDate,Pri.invoicedate)as TranDate,  " +
                    " isnull(TGTTO,0)as TGTTO, isnull(SalesTO,0)as SecSalesTO, isnull(PriSalesTO,0) as PriSalesTO " +
                    " from " +
                    " ( " +
                    " select isnull(Q1.MarketGroupID,Q2.DistributorID)as DistributorID, " +
                    " isnull(Q1.PeriodDate,Q2.TranDate)as TranDate,isnull(TGTTO,0)as TGTTO, isnull(SalesTO,0)as SalesTO " +
                    " from " +
                    " ( " +
                    " SELECT  MarketGroupID,PeriodDate, round(sum(TurnOver),0) AS TGTTO " +
                    " FROM  BLLSysDB.dbo.t_PlanBudgetTarget   " +
                    " where PeriodDate between '" + dDFromDate + "' and '" + dDToDate + "' and PeriodDate <'" + dDToDate + "' " +
                    " and MarketGroupID in (select DistributorID from t_DMSUser) " +
                    " GROUP BY MarketGroupID,PeriodDate " +
                    " )As Q1 " +
                    " full outer join " +
                    " ( " +
                    " select DistributorID,TranDate, sum(NetAmount)as SalesTO " +
                    " from t_DMSProductTran  " +
                    " where TranDate between '" + dDFromDate + "' and '" + dDToDate + "'  and TranDate <'" + dDToDate + "' " +
                    " and tranTypeID=2  " +
                    " group by DistributorID, TranDate " +
                    " ) Q2 on Q1.MarketGroupID=Q2.DistributorID and Q1.PeriodDate=Q2.TranDate " +
                    " )As Sec " +

                    " full outer join " +

                    " ( " +
                    " select CustomerID,CustomerCode,invoicedate, sum (PriSalesTO)as PriSalesTO  " +
                    " from " +
                    " (  " +
                    " select CustomerID,CustomerCode,cast(convert(nvarchar(12),InvoiceDate,106)as Datetime) as InvoiceDate,isnull(sum(crAmount) - abs(sum(drAmount)),0) as PriSalesTO     " +
                    " from      " +
                    " (     " +
                    " select a.CustomerID,CustomerCode,invoicedate,sum(invoiceamount) as crAmount, 0 as drAmount " +
                    " from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v    " +
                    " where invoicedate between '" + dDFromDate + "' and '" + dDToDate + "' and invoicedate <'" + dDToDate + "' " +
                    " and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) " +
                    " and a.CustomerID in (select DistributorID from t_DMSUser) " +
                    " group by  a.CustomerID,CustomerCode,invoicedate  " +
                    " union all      " +
                    " select a.CustomerID,CustomerCode,month(invoicedate)as MonthNO, 0 as crAmount,sum(invoiceamount) as drAmount " +
                    " from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v        " +
                    " where invoicedate between '" + dDFromDate + "' and '" + dDToDate + "' and invoicedate <'" + dDToDate + "' " +
                    " and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) " +
                    " and a.CustomerID in (select DistributorID from t_DMSUser) " +
                    " group by  a.CustomerID,CustomerCode,invoicedate " +
                    " )as p2    " +
                    " group by CustomerID,CustomerCode,invoicedate " +
                    " ) as TELBLL " +
                    " group by  CustomerID,CustomerCode,invoicedate " +

                    " )as Pri on Sec.DistributorID=Pri.CustomerID and Sec.TranDate=Pri.invoicedate " +
                    " )As GFinal " +

                    " inner join " +
                    " ( " +
                    " select Customercode,Customerid,Customername,Areaid,Areaname,Territoryid,Territoryname,balance " +
                    " from v_customerdetails where channelid=2  " +
                    " ) as Cust on GFinal.CustomerID=Cust.Customerid " +
                    " inner join " +
                    " ( " +
                    " select DistributorID, sum(STKVal)as STKVal " +
                    " from " +
                    " ( " +
                    " select a.ProductID,DistributorID,NSP,CurrentStock,((NSP*CurrentStock)*0.95)as STKVal " +
                    " from t_DMSProductStock a, v_ProductDetails b " +
                    " where a.ProductID=b.ProductID and DistributorID in (select DistributorID from t_DMSUser) " +
                    " )As Stk " +
                    " group by DistributorID " +
                    " )as STK on GFinal.CustomerID=STK.DistributorID where ";


            if (nCustomerID > -1)
            {
                sSql = sSql + " GFinal.customerid= '" + nCustomerID + "'";

            }
            else
            {
                sSql = sSql + " GFinal.customerid IN (select CustomerID from v_CustomerDetails a,t_UserPermissionData b "
                           + "  where b.DataID=a.CustomerID and b.UserID= '" + nUserID + "' and Isactive=1 )";
                cmd.Parameters.AddWithValue("UserID", nUserID);

            }
            if (nAreaID != -1)
            {
                sSql = sSql + " and areaid = " + nAreaID + "";

            }
            if (nTerritoryID != -1)
            {
                sSql = sSql + " and territoryid = " + nTerritoryID + "";

            }


            sSql = sSql + " order by AreaId,AreaName,TerritoryID,TerritoryName,GFinal.CustomerID,CustomerName,TranDate ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    //rptSales orptSales = new rptSales();
                    SecondarySalesDayWise oSecondarySalesDayWise = new SecondarySalesDayWise();



                    //if (Convert.ToInt32(reader["netsalesQty"].ToString()) != 0)
                    {


                        oSecondarySalesDayWise.AreaID = (int)reader["AreaID"];
                        oSecondarySalesDayWise.AreaName = (string)reader["areaname"].ToString();
                        oSecondarySalesDayWise.TerritoryID = (int)reader["TerritoryID"];
                        oSecondarySalesDayWise.TerritoryName = (string)reader["territoryname"].ToString();
                        oSecondarySalesDayWise.CustomerID = Convert.ToInt16(reader["CustomerID"]);
                        //oSecondarySalesDayWise.CustomerCode =(string) reader["CustomerCode"].ToString();
                        oSecondarySalesDayWise.CustomerName = (string)reader["CustomerName"].ToString();
                        oSecondarySalesDayWise.TranDate = Convert.ToDateTime(reader["TranDate"]);
                        oSecondarySalesDayWise.SalesTO = Convert.ToDouble(reader["SalesTO"]);
                        oSecondarySalesDayWise.TGTTO = Convert.ToDouble(reader["TGTTO"]);
                        oSecondarySalesDayWise.PriSalesTO = Convert.ToDouble(reader["PriSalesTO"]);


                        if (oSecondarySalesDayWise.CustomerID != nCustID)
                        {
                            oSecondarySalesDayWise.STKVal = Convert.ToDouble(reader["STKVal"]);
                            oSecondarySalesDayWise.Balance = Convert.ToDouble(reader["Balance"]);
                            nCustID = oSecondarySalesDayWise.CustomerID;
                        }

                        else
                        {
                            oSecondarySalesDayWise.STKVal = 0;
                            oSecondarySalesDayWise.Balance = 0;
                        }

                        InnerList.Add(oSecondarySalesDayWise);
                    }
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // RouteWiseSalesTO Summary Method

        public void RouteWiseSalesTOSummary(int nUserID, DateTime dDFromDate, DateTime dDToDate, int nAreaID, int nTerritoryID, int nCustomerID, int nPercent)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            int nCustID = 0;

            sSql = @" 
                    Set dateformat dmy
                    select Customercode,Customername,Areaid,Areaname,Territoryid,Territoryname,GFinal.CustomerID,  balance, STKVal,TGTTO, " +
                    " PriSalesTO,PriAch,SecSalesTO,SecAch " +
                    " from " +
                    " ( " +
                    " select Customercode,Customername,Areaid,Areaname,Territoryid,Territoryname,GFinal.CustomerID,  balance, STKVal,TGTTO, " +
                    " PriSalesTO,  " +
                    " case when TGTTO > 0 then (PriSalesTO/TGTTO)*100  else 0 end as PriAch, " +
                    " SecSalesTO, " +
                    " case when TGTTO > 0 then (SecSalesTO/TGTTO)*100  else 0 end as SecAch " +
                    " from " +
                    " ( " +
                    " select isnull(Sec.DistributorID,Pri.CustomerID)as CustomerID,   " +
                    " isnull(TGTTO,0)as TGTTO, isnull(SalesTO,0)as SecSalesTO, isnull(PriSalesTO,0) as PriSalesTO " +
                    " from " +
                    " ( " +
                    " select isnull(Q1.MarketGroupID,Q2.DistributorID)as DistributorID, isnull(TGTTO,0)as TGTTO, isnull(SalesTO,0)as SalesTO " +
                    " from " +
                    " ( " +
                    " SELECT  MarketGroupID, round(sum(TurnOver),0) AS TGTTO  " +
                    " FROM  BLLSysDB.dbo.t_PlanBudgetTarget   " +
                    " where PeriodDate between '" + dDFromDate + "' and '" + dDToDate + "' and PeriodDate <'" + dDToDate + "' " +
                    " and MarketGroupID in (select DistributorID from t_DMSUser) " +
                    " GROUP BY MarketGroupID " +
                    " )As Q1 " +
                    " full outer join " +
                    " ( " +
                    " select DistributorID, sum(NetAmount)as SalesTO " +
                    " from t_DMSProductTran  " +
                    " where TranDate between '" + dDFromDate + "' and '" + dDToDate + "'  and TranDate <'" + dDToDate + "' " +
                    " and tranTypeID=2  " +
                    " group by DistributorID " +
                    " ) Q2 on Q1.MarketGroupID=Q2.DistributorID " +
                    " )As Sec " +

                    " full outer join " +

                    " ( " +
                    " select CustomerID,CustomerCode, sum (PriSalesTO)as PriSalesTO  " +
                    " from " +
                    " (  " +
                    " select CustomerID,CustomerCode,cast(convert(nvarchar(12),InvoiceDate,106)as Datetime) as InvoiceDate,isnull(sum(crAmount) - abs(sum(drAmount)),0) as PriSalesTO      " +
                    " from      " +
                    " (     " +
                    " select a.CustomerID,CustomerCode,invoicedate,sum(invoiceamount) as crAmount, 0 as drAmount " +
                    " from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v    " +
                    " where invoicedate between '" + dDFromDate + "' and '" + dDToDate + "' and invoicedate <'" + dDToDate + "' " +
                    " and invoicetypeid in (1,2,4,5) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) " +
                    " and a.CustomerID in (select DistributorID from t_DMSUser) " +
                    " group by  a.CustomerID,CustomerCode,invoicedate  " +
                    " union all      " +
                    " select a.CustomerID,CustomerCode,month(invoicedate)as MonthNO, 0 as crAmount,sum(invoiceamount) as drAmount " +
                    " from bllsysdb.dbo.t_salesInvoice a, bllsysdb.dbo.v_customerdetails v        " +
                    " where invoicedate between '" + dDFromDate + "' and '" + dDToDate + "' and invoicedate <'" + dDToDate + "' " +
                    " and invoicetypeid in (6,7,8,9,10,12) and invoicestatus not in (3) and a.customerid = v.customerid and channelid in (2) " +
                    " and a.CustomerID in (select DistributorID from t_DMSUser) " +
                    " group by  a.CustomerID,CustomerCode,invoicedate " +
                    " )as p2    " +
                    " group by CustomerID,CustomerCode,invoicedate " +
                    " ) as TELBLL " +
                    " group by  CustomerID,CustomerCode " +

                    " )as Pri on Sec.DistributorID=Pri.CustomerID  " +
                    " )As GFinal " +

                    " inner join " +
                    " ( " +
                    " select Customercode,Customerid,Customername,Areaid,Areaname,Territoryid,Territoryname,balance " +
                    " from v_customerdetails where channelid=2  " +
                    " ) as Cust on GFinal.CustomerID=Cust.Customerid " +
                    " inner join " +
                    " ( " +
                    " select DistributorID, sum(STKVal)as STKVal " +
                    " from " +
                    " ( " +
                    " select a.ProductID,DistributorID,NSP,CurrentStock,((NSP*CurrentStock)*0.95)as STKVal " +
                    " from t_DMSProductStock a, v_ProductDetails b " +
                    " where a.ProductID=b.ProductID and DistributorID in (select DistributorID from t_DMSUser) " +
                    " )As Stk " +
                    " group by DistributorID " +
                    " )as STK on GFinal.CustomerID=STK.DistributorID " +
                    " )As GFinal where ";


            if (nCustomerID > -1)
            {
                sSql = sSql + " GFinal.customerid= '" + nCustomerID + "'";

            }
            else
            {
                sSql = sSql + " GFinal.customerid IN (select CustomerID from v_CustomerDetails a,t_UserPermissionData b "
                           + "  where b.DataID=a.CustomerID and b.UserID= '" + nUserID + "' and Isactive=1 )";
                cmd.Parameters.AddWithValue("UserID", nUserID);

            }
            if (nAreaID != -1)
            {
                sSql = sSql + " and areaid = " + nAreaID + "";

            }
            if (nTerritoryID != -1)
            {
                sSql = sSql + " and territoryid = " + nTerritoryID + "";

            }

            if (nPercent != 0)
            {
                sSql = sSql + " and SecAch <= " + nPercent + "";
            }

            sSql = sSql + " order by AreaId,AreaName,TerritoryID,TerritoryName,GFinal.CustomerID,CustomerName";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    //rptSales orptSales = new rptSales();
                    SecondarySalesDayWise oSecondarySalesDayWise = new SecondarySalesDayWise();



                    //if (Convert.ToInt32(reader["netsalesQty"].ToString()) != 0)
                    {


                        oSecondarySalesDayWise.AreaID = (int)reader["AreaID"];
                        oSecondarySalesDayWise.AreaName = (string)reader["areaname"].ToString();
                        oSecondarySalesDayWise.TerritoryID = (int)reader["TerritoryID"];
                        oSecondarySalesDayWise.TerritoryName = (string)reader["territoryname"].ToString();
                        oSecondarySalesDayWise.CustomerID = Convert.ToInt16(reader["CustomerID"]);
                        //oSecondarySalesDayWise.CustomerCode =(string) reader["CustomerCode"].ToString();
                        oSecondarySalesDayWise.CustomerName = (string)reader["CustomerName"].ToString();
                        //oSecondarySalesDayWise.TranDate = Convert.ToDateTime(reader["TranDate"]);
                        //oSecondarySalesDayWise.SalesTO = Convert.ToDouble(reader["SalesTO"]);
                        oSecondarySalesDayWise.SecSalesTO = Convert.ToDouble(reader["SecSalesTO"]);
                        oSecondarySalesDayWise.TGTTO = Convert.ToDouble(reader["TGTTO"]);
                        oSecondarySalesDayWise.PriSalesTO = Convert.ToDouble(reader["PriSalesTO"]);


                        if (oSecondarySalesDayWise.CustomerID != nCustID)
                        {
                            oSecondarySalesDayWise.STKVal = Convert.ToDouble(reader["STKVal"]);
                            oSecondarySalesDayWise.Balance = Convert.ToDouble(reader["Balance"]);
                            nCustID = oSecondarySalesDayWise.CustomerID;
                        }

                        else
                        {
                            oSecondarySalesDayWise.STKVal = 0;
                            oSecondarySalesDayWise.Balance = 0;
                        }

                        InnerList.Add(oSecondarySalesDayWise);
                    }
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

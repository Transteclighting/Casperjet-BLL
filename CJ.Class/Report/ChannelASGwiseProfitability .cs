// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak k. Chakraborty
// Date: Aug 07, 2011
// Time" : 10:30 AM
// Description: Channel ASG wise Profitability [740]
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
    public class ChannelASGwiseProfitability
    {
        private long _SBUID;
        private string _sSBUName;
        private long _ChannelID;
        private string _sChannelName;
        private long _PGID;
        private string _sPGName;
        private long _MAGID;
        private string _sMAGName;
        private long _ASGID;
        private string _sASGName;
        private long _BrandID;
        private string _sBrandName;
        private long _SalesQty;
        private double _GrossAmount;
        private double _VAT;
        private double _COGS;
        private double _Comission;
        private double _RepAmt;
        private double _TPAmt;
        private long _TargetQty;
        private double _TargetAmt;
        private long _StockQty;
        private double _StockAmt;

        public long SBUID
        {
            get { return _SBUID; }
            set { _SBUID = value; }
        }
        
        public string SBUName
        {
            get { return _sSBUName; }
            set { _sSBUName = value; }
        }
        public long ChannelID
        {
            get { return _ChannelID; }
            set { _ChannelID = value; }
        }        
        public string ChannelName
        {
            get { return _sChannelName; }
            set { _sChannelName = value; }
        }
        public long PGID
        {
            get { return _PGID; }
            set { _PGID = value; }
        }
        
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value; }
        }
        public long MAGID
        {
            get { return _MAGID; }
            set { _MAGID = value; }
        }
        
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value; }
        }
        public long ASGID
        {
            get { return _ASGID; }
            set { _ASGID = value; }
        }        
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }
        public long BrandID
        {
            get { return _BrandID; }
            set { _BrandID = value; }
        }
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }
        public long SalesQty
        {
            get { return _SalesQty; }
            set { _SalesQty = value; }
        }
        public double GrossAmount
        {
            get { return _GrossAmount; }
            set { _GrossAmount = value; }
        }
        public double VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }
        public double COGS
        {
            get { return _COGS; }
            set { _COGS = value; }
        }
        public double Comission
        {
            get { return _Comission; }
            set { _Comission = value; }
        }
        public double RepAmt
        {
            get { return _RepAmt; }
            set { _RepAmt = value; }
        }        
        public double TPAmt
        {
            get { return _TPAmt; }
            set { _TPAmt = value; }
        }         
        public long TargetQty
        {
            get { return _TargetQty; }
            set { _TargetQty = value; }
        }
        public double TargetAmt
        {
            get { return _TargetAmt; }
            set { _TargetAmt = value; }
        }
        public long StockQty
        {
            get { return _StockQty; }
            set { _StockQty = value; }
        }
        public double StockAmt
        {
            get { return _StockAmt; }
            set { _StockAmt = value; }
        } 
              
           
    }

      public class ChannelASGwiseProfitabilityDetails: CollectionBaseCustom
       {

           public void Add(ChannelASGwiseProfitability oChannelASGwiseProfitability)
           {
               this.List.Add(oChannelASGwiseProfitability);
           }
           public ChannelASGwiseProfitability this[Int32 Index]
           {
               get
               {
                   return (ChannelASGwiseProfitability)this.List[Index];
               }
               set
               {
                   if (!(value.GetType().Equals(typeof(ChannelASGwiseProfitability))))
                   {
                       throw new Exception("Type can't be converted");
                   }
                   this.List[Index] = value;
               }
           }

         public void ASGWiseProfitability(DateTime dYFromDate, DateTime dYToDate)
           
         {
           InnerList.Clear();
           OleDbCommand cmd = DBController.Instance.GetCommand();
           StringBuilder sQueryStringMaster;
           sQueryStringMaster = new StringBuilder();
          
           
          sQueryStringMaster.Append(" Select SBUID,SBUName,SA.ChannelID,ChannelName, PGID,PGName,MAGID,MAGName,ASGID,ASGName,BrandID,BrandDesc as BrandName ");
          sQueryStringMaster.Append(" ,sum(SalesQty) as SalesQty,sum(GrossAmount) as GrossAmount,sum(sa.VAT) as VAT,sum(COGS) as COGS,sum(Comission) as Comission ");
          sQueryStringMaster.Append(" ,sum(RepAmt) as RepAmt,sum(TPAmt) as TPAmt,sum(TargetQty) as TargetQty,sum(TargetAmt) as TargetAmt,sum(StockQty) as StockQty,sum(StockQty*costPrice) as StockAmt ");
          sQueryStringMaster.Append(" from ");
          sQueryStringMaster.Append(" ( ");
          sQueryStringMaster.Append(" Select isnull(a.channelid,b.channelid) as ChannelID,isnull(a.productid,b.productid) as ProductID ");
          sQueryStringMaster.Append(" ,isnull(SalesQty,0) as SalesQty, isnull(GrossAmount,0) as GrossAmount ");
          sQueryStringMaster.Append("  ,isnull(VAT,0) as VAT, isnull(COGS,0) as COGS, isnull(Comission,0) as Comission, isnull(RepAmt,0) as RepAmt, isnull(TPAmt,0) as TPAmt ");
          sQueryStringMaster.Append("  ,isnull(TargetQty,0) as TargetQty, isnull(TargetAmt,0) as TargetAmt,isnull(StockQty,0)as StockQty ");
          sQueryStringMaster.Append("  from ");
          sQueryStringMaster.Append("  ( ");
          sQueryStringMaster.Append("  select ");  
          sQueryStringMaster.Append("  ChannelID,Details.ProductID ");   
          sQueryStringMaster.Append("  ,sum(isnull(SalesQty,0)) as SalesQty, sum(isnull(GrossAmount,0)) as GrossAmount ");
          sQueryStringMaster.Append("  ,sum(isnull(Details.VAT,0)) as VAT, sum(isnull(COGS,0)) as COGS, sum(isnull(SC,0)) as Comission, sum(isnull(PW,0)) as RepAmt, sum(isnull(TP,0)) as TPAmt ");
          sQueryStringMaster.Append("  ,sum(isnull(TargetQty,0)) as TargetQty, sum(isnull(TargetAmt,0)) as TargetAmt ");
          sQueryStringMaster.Append("  from ");
          sQueryStringMaster.Append("  ( ");
          sQueryStringMaster.Append("  Select ");
          sQueryStringMaster.Append("  isnull(sales.Productid,Target.Productid) as ProductID,isnull(sales.CustomerID,Target.CustomerID) as CustomerID ");
          sQueryStringMaster.Append("  ,isnull(SalesQty,0) as SalesQty, isnull(GrossAmount,0) as GrossAmount ");
          sQueryStringMaster.Append("  ,isnull(VAT,0) as VAT, isnull(COGS,0) as COGS, isnull(SC,0) as SC, isnull(PW,0) as PW, isnull(TP,0) as TP ");
          sQueryStringMaster.Append("  ,isnull(TargetQty,0) as TargetQty, isnull(TargetAmt,0) as TargetAmt ");
          sQueryStringMaster.Append("  from ");
          sQueryStringMaster.Append("  (   ");
          sQueryStringMaster.Append("  select Productid,CustomerID  ");
          sQueryStringMaster.Append("  ,isnull(sum(QuantityCr)-abs(sum(QuantityDr)),0) as SalesQty, isnull(sum(AmountCr)-abs(sum(AmountDr)),0) as GrossAmount ");   
          sQueryStringMaster.Append("  ,isnull(sum(VATCr)-abs(sum(VATDr)),0) as VAT, isnull(sum(COGSCr)-abs(sum(COGSDr)),0) as COGS  ");
          sQueryStringMaster.Append("  , isnull(sum(SCCr)-abs(sum(SCDr)),0) as SC, isnull(sum(PWCr)-abs(sum(PWDr)),0) as PW, isnull(sum(TPCr)-abs(sum(TPDr)),0) as TP ");  
          sQueryStringMaster.Append("  from ");
          sQueryStringMaster.Append("  (   ");
          sQueryStringMaster.Append("  select SID.Productid,IM.CustomerID  ");
          sQueryStringMaster.Append("  ,sum(quantity) as QuantityCr , sum(unitPrice*Quantity) as AmountCr ");
          sQueryStringMaster.Append("  ,sum(quantity*SID.TradePrice*VATAmount) as VATCr , sum(CostPrice*Quantity) as COGSCr,sum(AdjustedDPAmount*Quantity) as SCCr,sum(AdjustedPWAmount*Quantity) as PWCr,sum(AdjustedTPAmount*Quantity) as TPCr ");  
          sQueryStringMaster.Append("  , 0 as QuantityDr, 0 as AmountDr, 0 as VATDr, 0 as COGSDr, 0 as SCDr, 0 as PWDr, 0 as TPDr ");     
          sQueryStringMaster.Append("  from t_salesinvoice IM, t_salesInvoiceDetail SID ");
          sQueryStringMaster.Append("  where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between ? and ? and im.Invoicedate< ? ");
          sQueryStringMaster.Append("  and im.invoicetypeid in(1,2,4,5)  and invoicestatus not in (3) ");  
          sQueryStringMaster.Append("  group by SID.Productid,IM.CustomerID ");
          sQueryStringMaster.Append("  union all ");  
          sQueryStringMaster.Append("  select SID.Productid,IM.CustomerID ");
          sQueryStringMaster.Append("  ,0 as QuantityCr , 0 as AmountCr, 0 as VATCr , 0 as COGSCr, 0 as SCCr, 0 as PWCr, 0 as TPCr ");
          sQueryStringMaster.Append("  , sum(quantity) as QuantityDr, sum(unitPrice*Quantity) as AmountDr  ");
          sQueryStringMaster.Append("  ,sum(quantity*SID.TradePrice*VATAmount) as VATDr , sum(CostPrice*Quantity) as COGSDr,sum(AdjustedDPAmount*Quantity) as SCDr,sum(AdjustedPWAmount*Quantity) as PWDr,sum(AdjustedTPAmount*Quantity) as TPDr ");
          sQueryStringMaster.Append("  from t_salesinvoice IM, t_salesInvoiceDetail SID ");
          sQueryStringMaster.Append("  where im.Invoiceid = Sid.Invoiceid and im.Invoicedate between ? and ? and im.Invoicedate< ? ");
          sQueryStringMaster.Append("  and im.invoicetypeid in(6,7,9,10,12)  and invoicestatus not in (3) ");  
          sQueryStringMaster.Append("  group by SID.Productid,IM.CustomerID ");
          sQueryStringMaster.Append("  ) ");   
          sQueryStringMaster.Append("  as qq group by Productid,CustomerID  ");
          sQueryStringMaster.Append("  ) as Sales ");
          sQueryStringMaster.Append("  full outer join ");
          sQueryStringMaster.Append("  (  ");  
          sQueryStringMaster.Append("  select MarketGroupID as Customerid,ProductGroupID as Productid,sum(Qty)as TargetQty, sum(Turnover)as TargetAmt ");  
          sQueryStringMaster.Append("  from t_planbudgettarget ");  
          sQueryStringMaster.Append("  where plantype in (2) and productgrouptype in (1) and periodtype in (3) and MarketScopeType in (4) ");
          sQueryStringMaster.Append("  and perioddate between ? and ? and perioddate < ? ");  
          sQueryStringMaster.Append("  group by  MarketGroupID,ProductGroupID ");   
          sQueryStringMaster.Append("  )as target on sales.Productid = Target.Productid and sales.CustomerID = Target.CustomerID ");
          sQueryStringMaster.Append("  )as Details ");
          sQueryStringMaster.Append("  inner join  ");
          sQueryStringMaster.Append("  ( ");
          sQueryStringMaster.Append("  select * from v_customerDetails ");
          sQueryStringMaster.Append("  ) as cd on cd.customerid = Details.customerid  ");
          sQueryStringMaster.Append("  group by ChannelID,Details.ProductID ");
          sQueryStringMaster.Append("  ) as A ");
          sQueryStringMaster.Append("  full outer join ");
          sQueryStringMaster.Append("  ( ");
          sQueryStringMaster.Append("  Select ChannelID,ProductID,sum(Currentstock) as StockQty ");
          sQueryStringMaster.Append("  from t_productstock where warehouseid<>1 ");
          sQueryStringMaster.Append("  group by ChannelID,ProductID ");
          sQueryStringMaster.Append("  ) as B on a.channelid = b.channelid and a.productid = b.productid ");
          sQueryStringMaster.Append("  ) as SA ");
          sQueryStringMaster.Append("  inner join ");
          sQueryStringMaster.Append("  ( ");
          sQueryStringMaster.Append("  select SBUID,SBUName,ChannelID,ChannelDescription as ChannelName from v_customerDetails group by SBUID,SBUName,ChannelID,ChannelDescription ");
          sQueryStringMaster.Append("  ) as cust on SA.ChannelID = cust.ChannelID  ");
          sQueryStringMaster.Append("  inner join ");
          sQueryStringMaster.Append("  (  ");
          sQueryStringMaster.Append("  select * from v_productDetails ");
          sQueryStringMaster.Append("  ) as prod on SA.Productid = prod.Productid  ");
          sQueryStringMaster.Append("  Group By ");
          sQueryStringMaster.Append("  SBUID,SBUName, SA.ChannelID, ChannelName, PGID, PGName, MAGID, MAGName, ASGID, ASGName, BrandID, BrandDesc ");
          
           OleDbCommand oCmd = DBController.Instance.GetCommand();
           //Command time out

           oCmd.CommandTimeout = 0;
           oCmd.CommandText = sQueryStringMaster.ToString();
           oCmd.Parameters.AddWithValue("im.Invoicedate", dYFromDate );
           oCmd.Parameters.AddWithValue("im.Invoicedate", dYToDate);
           oCmd.Parameters.AddWithValue("im.Invoicedate", dYToDate);
           
     
           oCmd.Parameters.AddWithValue("im.Invoicedate", dYFromDate);
           oCmd.Parameters.AddWithValue("im.Invoicedate", dYToDate);
           oCmd.Parameters.AddWithValue("im.Invoicedate", dYToDate); 

           oCmd.Parameters.AddWithValue(" perioddate ", dYFromDate);
           oCmd.Parameters.AddWithValue(" perioddate ", dYToDate.AddDays(-1));
           oCmd.Parameters.AddWithValue(" perioddate ", dYToDate.AddDays(-1));

           GetDataASGWiseProfitability(oCmd); 
           
           }

           public void GetDataASGWiseProfitability(OleDbCommand cmd)
           {   
               try
               {
                   IDataReader reader = cmd.ExecuteReader();
                   while (reader.Read())
                   {
                       ChannelASGwiseProfitability oItem = new ChannelASGwiseProfitability();

                       if (reader["SBUID"] != DBNull.Value)
                           oItem.SBUID = (long)reader["SBUID"];
                       else oItem.SBUID = -1;

                       if (reader["SBUName"] != DBNull.Value)
                           oItem.SBUName = (string)reader["SBUName"];
                       else oItem.SBUName = "";

                       if (reader["ChannelID"] != DBNull.Value)
                           oItem.ChannelID = (int)reader["ChannelID"];
                       else oItem.ChannelID = -1;
                       
                       if (reader["ChannelName"] != DBNull.Value)
                           oItem.ChannelName = (string)reader["ChannelName"];
                       else oItem.ChannelName = "";

                       if (reader["PGID"] != DBNull.Value)
                           oItem.PGID = (int)reader["PGID"];
                       else oItem.PGID = -1; 

                       if (reader["PGName"] != DBNull.Value)
                           oItem.PGName = (string)reader["PGName"];
                       else oItem.PGName = "";

                       if (reader["MAGID"] != DBNull.Value)
                           oItem.MAGID = (int)reader["MAGID"];
                       else oItem.MAGID = -1;

                       if (reader["MAGName"] != DBNull.Value)
                           oItem.MAGName = (string)reader["MAGName"];
                       else oItem.MAGName = "";
                       
                       if (reader["ASGID"] != DBNull.Value)
                           oItem.ASGID = (int)reader["ASGID"];
                       else oItem.ASGID = -1;

                       if (reader["ASGName"] != DBNull.Value)
                           oItem.ASGName = (string)reader["ASGName"];
                       else oItem.ASGName = "";

                       if (reader["BrandID"] != DBNull.Value)
                           oItem.BrandID = (int)reader["BrandID"];
                       else oItem.BrandID = -1;

                       if (reader["BrandName"] != DBNull.Value)
                           oItem.BrandName = (string)reader["BrandName"];
                       else oItem.BrandName = "";

                       if (reader["SalesQty"] != DBNull.Value)
                           oItem.SalesQty = Convert.ToInt64(reader["SalesQty"]);
                       else oItem.SalesQty = -1;

                       if (reader["GrossAmount"] != DBNull.Value)
                           oItem.GrossAmount = (double)reader["GrossAmount"];
                       else oItem.GrossAmount = -1;

                       if (reader["VAT"] != DBNull.Value)
                           oItem.VAT = (double)reader["VAT"];
                       else oItem.VAT = -1;

                       if (reader["COGS"] != DBNull.Value)
                           oItem.COGS = (double)reader["COGS"];
                       else oItem.COGS = -1; 

                       if (reader["Comission"] != DBNull.Value)
                           oItem.Comission = (double)reader["Comission"];
                       else oItem.Comission = -1;

                       if (reader["RepAmt"] != DBNull.Value)
                           oItem.RepAmt = (double)reader["RepAmt"];
                       else oItem.RepAmt = -1;

                       if (reader["TPAmt"] != DBNull.Value)
                           oItem.TPAmt = (double)reader["TPAmt"]; 
                       else oItem.TPAmt = -1;

                       if (reader["TargetQty"] != DBNull.Value)
                           oItem.TargetQty = Convert.ToInt64(reader["TargetQty"]);
                       else oItem.TargetQty = -1;

                       if (reader["TargetAmt"] != DBNull.Value)
                           oItem.TargetAmt = (double)reader["TargetAmt"];
                       else oItem.TargetAmt = -1;

                       if (reader["StockQty"] != DBNull.Value)
                           oItem.StockQty =Convert.ToInt32(reader["StockQty"]);
                       else oItem.StockQty = -1;

                       if (reader["StockAmt"] != DBNull.Value)
                           oItem.StockAmt =(double) reader["StockAmt"];
                       else oItem.StockAmt = -1;
                                                                    
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

           public void FromDataSetASGWiseProfitability(DataSet oDS)
           {
               InnerList.Clear();
               try
               {
                   foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                   {
                       ChannelASGwiseProfitability oChannelASGwiseProfitability = new ChannelASGwiseProfitability();

                       oChannelASGwiseProfitability.SBUID = Convert.ToInt32(oRow["SBUID"]);
                       oChannelASGwiseProfitability.SBUName = (string)oRow["SBUName"];
                       oChannelASGwiseProfitability.ChannelID = Convert.ToInt32(oRow ["ChannelID"]);
                       oChannelASGwiseProfitability.ChannelName = (string)oRow["ChannelName"];
                       oChannelASGwiseProfitability.PGID=Convert.ToInt32 (oRow["PGID"]);
                       oChannelASGwiseProfitability.PGName = (string)oRow["PGName"];
                       oChannelASGwiseProfitability.MAGID = Convert.ToInt32(oRow["MAGID"]);
                       oChannelASGwiseProfitability.MAGName = (string)oRow["MAGName"];
                       oChannelASGwiseProfitability.ASGID = Convert.ToInt32(oRow["ASGID"]);
                       oChannelASGwiseProfitability.ASGName=(string) oRow["ASGName"];
                       oChannelASGwiseProfitability.BrandID = Convert.ToInt32(oRow["BrandID"]);
                       oChannelASGwiseProfitability.BrandName = (string)oRow["BrandName"];
                       oChannelASGwiseProfitability.SalesQty = Convert.ToInt32(oRow["SalesQty"]);
                       oChannelASGwiseProfitability.GrossAmount = Convert.ToDouble(oRow["GrossAmount"]);
                       oChannelASGwiseProfitability.VAT = Convert.ToDouble(oRow["VAT"]);
                       oChannelASGwiseProfitability.COGS = Convert.ToDouble(oRow["COGS"]);
                       oChannelASGwiseProfitability.Comission = Convert.ToDouble(oRow["Comission"]);
                       oChannelASGwiseProfitability.RepAmt = Convert.ToDouble(oRow["RepAmt"]);
                       oChannelASGwiseProfitability.TPAmt = Convert.ToDouble(oRow["TPAmt"]);
                       oChannelASGwiseProfitability.TargetQty = Convert.ToInt64(oRow["TargetQty"]);
                       oChannelASGwiseProfitability.TargetAmt = Convert.ToDouble(oRow["TargetAmt"]);
                       oChannelASGwiseProfitability.StockQty = Convert.ToInt64(oRow["StockQty"]);
                       oChannelASGwiseProfitability.StockAmt = Convert.ToDouble(oRow["StockAmt"]);
                         
                       InnerList.Add(oChannelASGwiseProfitability);
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

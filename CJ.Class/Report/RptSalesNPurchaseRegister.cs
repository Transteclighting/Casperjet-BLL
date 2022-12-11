// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak k. Chakraborty
// Date: Jul 17, 2012
// Time" :  03:10 PM
// Descriptio: Sales & Purchase Register 
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Report
{
    public class RptSalesNPurchaseRegister
    {

        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
        private int _nSupplyerID;
        private string _sCustomerName;
        private string _sSupplyerName;
        private string _sAddress;
        private double _nOpenningStock;
        private double _nNSP;
        private double _nRSP;
        private double _nUnitCostPrice;
        private double _nTradePrice;
        private double _nVAT;
        private double _nTotalRecQty;
        private string _sTranNo;
        private DateTime _dInvoiceDate;
        private int _nTrantypeID;
        private double _nQty;
        private int _nTranside;
        private int _nDutyTranTYpeID;


        private double _nClStock;

        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }

        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }

        public int SupplierID
        {
            get { return _nSupplyerID; }
            set { _nSupplyerID = value; }
        }

        public string SupplierName
        {
            get { return _sSupplyerName; }
            set { _sSupplyerName = value; }
        }

        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }

        public double OpenningStock
        {
            get { return _nOpenningStock; }
            set { _nOpenningStock = value; }
        }
        public double NSP
        {
            get { return _nNSP; }
            set { _nNSP = value; }
        }
        public double RSP
        {
            get { return _nRSP; }
            set { _nRSP = value; }
        }

        public double UnitCostPrice
        {
            get { return _nUnitCostPrice; }
            set { _nUnitCostPrice = value; }
        }

        public double TradePrice
        {
            get { return _nTradePrice; }
            set { _nTradePrice = value; }
        }

        public double VAT
        {
            get { return _nVAT; }
            set { _nVAT = value; }
        }

        public double TotalRecQty
        {
            get { return _nTotalRecQty; }
            set { _nTotalRecQty = value; }
        }

        public string TranNo
        {
            get { return _sTranNo; }
            set { _sTranNo = value; }
        }
        public DateTime InvoiceDate
        {
            get { return _dInvoiceDate; }
            set { _dInvoiceDate = value; }
        }

        public int TrantypeID
        {
            get { return _nTrantypeID; }
            set { _nTrantypeID = value; }
        }

        public double Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        public int Transide
        {
            get { return _nTranside; }
            set { _nTranside = value; }
        }

        public double ClStock
        {
            get { return _nClStock; }
            set { _nClStock = value; }
        }

        public int DutyTranTYpeID
        {
            get { return _nDutyTranTYpeID; }
            set { _nDutyTranTYpeID = value; }
        }



    }

    public class RptSalesNPurcRegDetails : CollectionBaseCustom
    {
        public void Add(RptSalesNPurchaseRegister oRptSalesNPurchaseRegister)
        {
            this.List.Add(oRptSalesNPurchaseRegister);
        }
        public RptSalesNPurchaseRegister this[Int32 Index]
        {
            get
            {
                return (RptSalesNPurchaseRegister)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(RptSalesNPurchaseRegister))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void SalesAndPurchaseRegister(DateTime dYFromDate, DateTime dYToDate, string nProductCode)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            //Query for the report Sales & Purchase Register (for NBR)

            sQueryStringMaster.Append(" Select Final.InvoiceDate, Final.productid, Final.ProductCode,Final.ProductName,OStock.OpenningStock, Final.SupplierID, Final.SupplierName, Final.Address,Final.qty, Final.NSP,Final.RSP, ");
            sQueryStringMaster.Append(" Unitcostprice, Final.TradePrice, Final.VAT,  Final.TranNo, Final.Trantypeid,Final.DutyTranTypeID ");
            sQueryStringMaster.Append(" from ");
            sQueryStringMaster.Append(" (  ");
            sQueryStringMaster.Append(" select x.ProductID, ((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as OpenningStock  ");
            sQueryStringMaster.Append(" from    ");
            sQueryStringMaster.Append(" (    ");
            sQueryStringMaster.Append(" select Productid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock  ");
            sQueryStringMaster.Append(" where channelid <> 1 and warehouseid <> 1  ");
            sQueryStringMaster.Append(" group by ProductID  ");
            sQueryStringMaster.Append("  ) as x   ");
            sQueryStringMaster.Append(" left outer join   ");
            sQueryStringMaster.Append(" (     ");
            sQueryStringMaster.Append(" select sd.productid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
            sQueryStringMaster.Append(" where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ?   ");
            sQueryStringMaster.Append(" group by sd.productid   ");
            sQueryStringMaster.Append("  ) as y  ");
            sQueryStringMaster.Append(" on x.productid = y.productid  ");
            sQueryStringMaster.Append(" left outer join   ");
            sQueryStringMaster.Append(" (  ");
            sQueryStringMaster.Append(" select sd.productid,  sum(qty)as qty, sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd   ");
            sQueryStringMaster.Append(" where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ? ");
            sQueryStringMaster.Append(" group by sd.productid  ");
            sQueryStringMaster.Append("  )   ");
            sQueryStringMaster.Append(" as z   ");
            sQueryStringMaster.Append(" on x.productid = z.productid  ");
            sQueryStringMaster.Append(" ) as OStock ");
            sQueryStringMaster.Append(" left outer join ");
            sQueryStringMaster.Append(" (  ");
            sQueryStringMaster.Append(" Select PdTran.InvoiceDate as InvoiceDate, PdTran.productid, PdTran.ProductCode,PdTran.ProductName, PdTran.SupplierID, PdTran.SupplierName, PdTran.Address,PdTran.qty, PdTran.NSP,PdTran.RSP, ");
            sQueryStringMaster.Append(" Unitcostprice, PdTran.TradePrice, PdTran.VAT,  PdTran.TranNo, PdTran.Trantypeid,PdTran.DutyTranTypeID ");

            sQueryStringMaster.Append("  from  ");
            sQueryStringMaster.Append(" ( ");

            sQueryStringMaster.Append(" Select ProTran.InvoiceDate as InvoiceDate, ProTran.productid, ProTran.ProductCode,ProTran.ProductName, Supplyer.SupplierID, Supplyer.SupplierName, Supplyer.Address,ProTran.qty, ProTran.NSP,ProTran.RSP, ");
            sQueryStringMaster.Append(" Unitcostprice,'' TradePrice, '' as VAT,  ProTran.TranNo, ProTran.Trantypeid,ProTran.DutyTranTypeID ");

            sQueryStringMaster.Append(" from  ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" Select TranDate as InvoiceDate,a.productid,ProductCode,ProductName,  ");
            sQueryStringMaster.Append(" qty, NSP,RSP,costprice as Unitcostprice,TradePrice, TranNo, Trantypeid,DutyTranTypeID  ");
            sQueryStringMaster.Append(" from  ");
            sQueryStringMaster.Append(" (  ");

            sQueryStringMaster.Append(" select productid, TranDate,TranNo,sm.Trantypeid, 0 as DutyTranTypeID ,sum(qty)as qty   ");
            sQueryStringMaster.Append(" from t_productStockTran sm, t_productStockTranItem sd,t_productstocktrantype sc    ");
            sQueryStringMaster.Append(" where sd.tranid  = sm.tranid  and sm.trantypeid = sc.trantypeid and trandate between ? and ? and trandate < ? and sm.trantypeid in (1)   ");
            sQueryStringMaster.Append(" group by productid, TranDate,TranNo,sm.Trantypeid  ");
            sQueryStringMaster.Append(" union all  ");
            sQueryStringMaster.Append(" select productid, TranDate,TranNo, sm.Trantypeid, 21 as DutyTranTypeID, sum(qty)as qty   ");
            sQueryStringMaster.Append(" from t_productStockTran sm, t_productStockTranItem sd,t_productstocktrantype sc      ");
            sQueryStringMaster.Append(" where sd.tranid  = sm.tranid and sm.trantypeid = sc.trantypeid and trandate between ? and ? and trandate < ? and sm.trantypeid not in (1) and transactionside = 1    ");
            sQueryStringMaster.Append(" group by productid, TranDate,TranNo,sm.Trantypeid ");
            sQueryStringMaster.Append(" union all  ");
            sQueryStringMaster.Append(" select productid, TranDate,'All Adjustment Out' as TranNo, 2 as Trantypeid, 22 as  DutyTranTypeID,  sum(qty)as qty  ");
            sQueryStringMaster.Append(" from t_productStockTran sm, t_productStockTranItem sd,t_productstocktrantype sc     ");
            sQueryStringMaster.Append(" where sd.tranid  = sm.tranid  and sm.trantypeid = sc.trantypeid and trandate between ? and ? and trandate < ? and sm.trantypeid not in (3,5) and transactionside = 2  ");
            sQueryStringMaster.Append(" group by productid, TranDate  ");
            sQueryStringMaster.Append(" ) as a  ");
            sQueryStringMaster.Append(" inner join  ");
            sQueryStringMaster.Append(" (  ");
            sQueryStringMaster.Append(" Select * from v_productdetails  ");
            sQueryStringMaster.Append(" ) as b on a.productid = b.productid  ");
            sQueryStringMaster.Append(" ) as ProTran ");
            sQueryStringMaster.Append(" left outer join ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" select a.ProductID,c.ProductCode, c.ProductName, b.SupplierID, b.SupplierName, b.Address  from t_SupplierProduct a, t_Supplier b, t_product c  ");
            sQueryStringMaster.Append(" where a.SupplierID=b.SupplierID and a.ProductID=c.ProductID  ");
            sQueryStringMaster.Append(" ) Supplyer on  ProTran.ProductID=Supplyer.ProductID ");
            sQueryStringMaster.Append(" Union all  ");
            sQueryStringMaster.Append(" select a.DutyTranDate as InvoiceDate, b.ProductID, d.ProductCode, d.ProductName, '' as SupplyerID, a.DocumentNo as SupplyerName, '' as Address, ");
            sQueryStringMaster.Append(" b.Qty,d.NSP,d.RSP,d.Costprice as UnitCost, b.DutyPrice as TradePrice, b.DutyRate as VAT, a.DutyTranNo as TranNo, '' as TranTypeID,  ");
            sQueryStringMaster.Append(" a.DutyTranTypeID ");
            sQueryStringMaster.Append(" from t_DutyTran a,  t_DutyTranDetail b, t_DutyTranType c, v_ProductDetails d ");
            sQueryStringMaster.Append(" where a.DutyTranID=b.DutyTranID  and a.DutyTranTypeID=c.DutyTranTypeID  ");
            sQueryStringMaster.Append(" and b.ProductID=d.ProductID and DutyTranDate between ? and ? and DutyTranDate< ? ");
            sQueryStringMaster.Append(" )as PdTran ");

            sQueryStringMaster.Append(" ) as Final on OStock.ProductID=Final.ProductID  ");
            sQueryStringMaster.Append(" where ProductCode= ?  ");
            sQueryStringMaster.Append(" order by Final.InvoiceDate, Final.ProductID, Final.ProductCode, Final.ProductName, Final.DutyTranTypeID ");



            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            // input for Sales & Purchase  Reg.

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date.AddDays(1));

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));


            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));


            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("ProductCode", (string)nProductCode);

            getDataSalesNPurchaseRegister(oCmd);

        }


        public void SalesAndPurchaseCentral(DateTime dYFromDate, DateTime dYToDate, string nProductCode)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            //Query for the report Sales & Purchase Register ( Central Openinng Stock)

                                
              sQueryStringMaster.Append("  Select Final.InvoiceDate, Final.productid, OStock.ProductCode,Final.ProductName, OStock.OpenningStock, isnull( Final.SupplierID, 0)as SupplierID, Final.SupplierName, Final.Address,Final.qty, Final.NSP,Final.RSP, ");
              sQueryStringMaster.Append("  Unitcostprice, Final.TradePrice, Final.VAT,  Final.TranNo, Final.Trantypeid,Final.DutyTranTypeID ");
              sQueryStringMaster.Append("  from ");
              sQueryStringMaster.Append("  (  ");                       
              sQueryStringMaster.Append("  Select CentralOS.productid, ProductCode,ProductName,WHCategory, sum(ClosingStock )as OpenningStock ");
              sQueryStringMaster.Append("  from  ");
              sQueryStringMaster.Append("  ( ");
              sQueryStringMaster.Append("   Select WarehouseCode,WarehouseName,PGName,MAGName,ASGName,BrandDesc as BrandName, ");
              sQueryStringMaster.Append("  Category = case when supplytype = 2 then 'Imported' else 'Local' end, ");
              sQueryStringMaster.Append("  Stock.productid,ProductCode,ProductName,IntQty as ClosingStock, (IntQty *CostPrice) as ClosingStockValue, ");
              sQueryStringMaster.Append("  WHCategory = case when warehouseparentid not in (7,4,2) then 'CenteralWH' end ");
              sQueryStringMaster.Append("  from  ");
              sQueryStringMaster.Append("  ( ");
              sQueryStringMaster.Append("  select x.productid,x.Warehouseid, x.currentstock ,  ");
              sQueryStringMaster.Append("  isnull(y.qty,0) as stockin, isnull(z.qty,0) as stockout, ");
              sQueryStringMaster.Append("  ((x.currentstock + isnull(z.qty,0) ) - isnull(y.qty,0)) as intQty ");
              sQueryStringMaster.Append("  from  ");
              sQueryStringMaster.Append("  ( ");
              sQueryStringMaster.Append("  select Productid,Warehouseid, sum(CurrentStock) as CurrentStock, sum(CurrentStockValue) as  CurrentStockValue from t_productstock  ");
              sQueryStringMaster.Append("  where channelid <> 1 and warehouseid <> 1  ");
              sQueryStringMaster.Append("  group by ProductID,Warehouseid ");
              sQueryStringMaster.Append("  ) as x  ");
              sQueryStringMaster.Append("  left outer join ");
              sQueryStringMaster.Append("  ( ");
              sQueryStringMaster.Append("  select sd.productid,towhid as Warehouseid, sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
              sQueryStringMaster.Append("  where sd.tranid  = sm.tranid and towhid <> 1 and tochannelid <> 1 and trandate between ? and ? ");
              sQueryStringMaster.Append("  group by sd.productid,towhid ");
              sQueryStringMaster.Append("  ) as y ");
              sQueryStringMaster.Append("  on x.productid = y.productid and x.Warehouseid = y.Warehouseid ");
              sQueryStringMaster.Append("  left outer join  ");
              sQueryStringMaster.Append("  ( ");
              sQueryStringMaster.Append("  select sd.productid,Fromwhid as Warehouseid,  sum(qty)as qty,sum(StockPrice) as StockValue from t_productStockTran sm, t_productStockTranItem sd  ");
              sQueryStringMaster.Append("   where sd.tranid  = sm.tranid and Fromwhid <> 1 and FromChannelid <> 1 and trandate between ? and ? ");
              sQueryStringMaster.Append("  group by sd.productid,Fromwhid ");
              sQueryStringMaster.Append("  )  ");
              sQueryStringMaster.Append("  as z ");
              sQueryStringMaster.Append("  on x.productid = Z.productid and x.Warehouseid = z.Warehouseid ");
              sQueryStringMaster.Append("  )as Stock ");
              sQueryStringMaster.Append(" inner join ");
              sQueryStringMaster.Append("  ( ");
              sQueryStringMaster.Append("  select * from v_productdetails ");
              sQueryStringMaster.Append("  ) as details on stock.productid = details.productid ");
              sQueryStringMaster.Append("  inner join ");
              sQueryStringMaster.Append("  ( ");
              sQueryStringMaster.Append("  select * from t_warehouse where warehouseid not in (83) ");
              sQueryStringMaster.Append("  ) as wh on stock.warehouseid = wh.warehouseid ");
              sQueryStringMaster.Append("  where warehouseparentid not in (7,4,2) ");
              sQueryStringMaster.Append("  ) as CentralOS ");
             sQueryStringMaster.Append("   group by CentralOS.productid, ProductCode,ProductName,WHCategory ");
                   
             sQueryStringMaster.Append("    ) as OStock ");
             sQueryStringMaster.Append("   left outer join  ");
             sQueryStringMaster.Append("  (   ");
             sQueryStringMaster.Append("   Select PdTran.InvoiceDate as InvoiceDate, PdTran.productid, PdTran.ProductCode,PdTran.ProductName, PdTran.SupplierID, PdTran.SupplierName, PdTran.Address,PdTran.qty, PdTran.NSP,PdTran.RSP, ");
             sQueryStringMaster.Append("  Unitcostprice, PdTran.TradePrice, PdTran.VAT,  PdTran.TranNo, PdTran.Trantypeid,PdTran.DutyTranTypeID ");                      
             sQueryStringMaster.Append("   from  ");
             sQueryStringMaster.Append("   ( ");                      
             sQueryStringMaster.Append("   Select ProTran.InvoiceDate as InvoiceDate, ProTran.productid, ProTran.ProductCode,ProTran.ProductName, Supplyer.SupplierID, Supplyer.SupplierName, Supplyer.Address,ProTran.qty, ProTran.NSP,ProTran.RSP, ");
             sQueryStringMaster.Append("   Unitcostprice,'' TradePrice, '' as VAT,  ProTran.TranNo, ProTran.Trantypeid,ProTran.DutyTranTypeID ");

             sQueryStringMaster.Append("   from  ");
             sQueryStringMaster.Append("   ( ");
             sQueryStringMaster.Append("   Select TranDate as InvoiceDate,a.productid,ProductCode,ProductName,  ");
             sQueryStringMaster.Append("   qty, NSP,RSP,costprice as Unitcostprice,TradePrice, TranNo, Trantypeid,DutyTranTypeID  ");
             sQueryStringMaster.Append("   from  ");
             sQueryStringMaster.Append("   (  ");
            // Product tran 
            sQueryStringMaster.Append("   select productid, TranDate,TranNo,sm.Trantypeid, 0 as DutyTranTypeID ,sum(qty)as qty   ");
            sQueryStringMaster.Append("   from t_productStockTran sm, t_productStockTranItem sd,t_productstocktrantype sc    ");
            sQueryStringMaster.Append("   where sd.tranid  = sm.tranid  and sm.trantypeid = sc.trantypeid and trandate between ? and ? and trandate < ?  and sm.trantypeid in (1)    ");
            sQueryStringMaster.Append("   group by productid, TranDate,TranNo,sm.Trantypeid  ");
            sQueryStringMaster.Append("   union all  ");
            sQueryStringMaster.Append("   select productid, TranDate,TranNo, sm.Trantypeid, 21 as DutyTranTypeID, sum(qty)as qty   ");
            sQueryStringMaster.Append("   from t_productStockTran sm, t_productStockTranItem sd,t_productstocktrantype sc     ");
            sQueryStringMaster.Append("   where sd.tranid  = sm.tranid and sm.trantypeid = sc.trantypeid and trandate between ? and ? and trandate < ? and sm.trantypeid not in (1) and transactionside = 1    ");
            sQueryStringMaster.Append("   group by productid, TranDate,TranNo,sm.Trantypeid  ");
            sQueryStringMaster.Append("   union all   ");
            sQueryStringMaster.Append("   select productid, TranDate,'All Adjustment Out' as TranNo, 2 as Trantypeid,22 as  DutyTranTypeID,  sum(qty)as qty   ");
            sQueryStringMaster.Append("   from t_productStockTran sm, t_productStockTranItem sd,t_productstocktrantype sc     ");
            sQueryStringMaster.Append("   where sd.tranid  = sm.tranid  and sm.trantypeid = sc.trantypeid and trandate between ? and ? and trandate < ? and sm.trantypeid not in (3,5) and transactionside = 2   ");
            sQueryStringMaster.Append("   group by productid, TranDate ");
            //
             sQueryStringMaster.Append("  ) as a  ");
             sQueryStringMaster.Append("   inner join  ");
             sQueryStringMaster.Append("   (  ");
             sQueryStringMaster.Append("   Select * from v_productdetails  ");
             sQueryStringMaster.Append("   ) as b on a.productid = b.productid  ");
             sQueryStringMaster.Append("   ) as ProTran ");                    	    
             sQueryStringMaster.Append("  left outer join ");
             sQueryStringMaster.Append("   ( ");
             sQueryStringMaster.Append("  select a.ProductID,c.ProductCode, c.ProductName, b.SupplierID, b.SupplierName, b.Address  from t_SupplierProduct a, t_Supplier b, t_product c  ");
             sQueryStringMaster.Append("   where a.SupplierID=b.SupplierID and a.ProductID=c.ProductID  ");
             sQueryStringMaster.Append("  ) Supplyer on  ProTran.ProductID=Supplyer.ProductID ");
             sQueryStringMaster.Append("  Union all  ");
             sQueryStringMaster.Append("  select a.DutyTranDate as InvoiceDate, b.ProductID, d.ProductCode, d.ProductName, '' as SupplyerID, a.DocumentNo as SupplyerName, '' as Address, ");
             sQueryStringMaster.Append("  b.Qty,d.NSP,d.RSP,d.Costprice as UnitCost, b.DutyPrice as TradePrice, b.DutyRate as VAT, a.DutyTranNo as TranNo, '' as TranTypeID,  ");
             sQueryStringMaster.Append("  a.DutyTranTypeID ");
             sQueryStringMaster.Append("  from t_DutyTran a,  t_DutyTranDetail b, t_DutyTranType c, v_ProductDetails d ");
             sQueryStringMaster.Append("   where a.DutyTranID=b.DutyTranID  and a.DutyTranTypeID=c.DutyTranTypeID  ");
             sQueryStringMaster.Append("   and b.ProductID=d.ProductID and DutyTranDate between ? and ? and DutyTranDate< ? ");
             sQueryStringMaster.Append("  )as PdTran ");
             sQueryStringMaster.Append("   ) as Final on OStock.ProductID=Final.ProductID  ");
             sQueryStringMaster.Append("    where OStock.ProductCode= ? ");
             sQueryStringMaster.Append("  order by Final.InvoiceDate, Final.ProductID, OStock.ProductCode, Final.ProductName, Final.DutyTranTypeID ");

                       

            OleDbCommand oCmd = DBController.Instance.GetCommand();
            //Command time out
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            // input for Sales & Purchase  Reg.

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", DateTime.Today.Date.AddDays(1));

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));


            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date.AddDays(1));
            oCmd.Parameters.AddWithValue("ProductCode", (string)nProductCode);

            getDataSalesNPurchaseRegister(oCmd);

        }

        private void getDataSalesNPurchaseRegister(OleDbCommand cmd)
        {
            int nCount = 0;
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptSalesNPurchaseRegister oItem = new RptSalesNPurchaseRegister();

                    if (reader["ProductID"] != DBNull.Value)
                        oItem.ProductID = (int)reader["ProductID"];
                    else oItem.ProductID = -1;

                    if (reader["ProductCode"] != DBNull.Value)
                        oItem.ProductCode = (string)reader["ProductCode"];
                    else oItem.ProductCode = "";

                    if (reader["ProductName"] != DBNull.Value)
                        oItem.ProductName = (string)reader["ProductName"];
                    else oItem.ProductName = "";

                    if (reader["SupplierID"] != DBNull.Value)
                        oItem.SupplierID = (int)reader["SupplierID"];
                    else oItem.SupplierID = 0;

                    if (reader["SupplierName"] != DBNull.Value)
                        oItem.SupplierName = (string)reader["SupplierName"];
                    else oItem.SupplierName = "";

                    if (reader["Address"] != DBNull.Value)
                        oItem.Address = (string)reader["Address"];
                    else oItem.Address = "";

                    if (nCount == 0)
                    {
                        if (reader["OpenningStock"] != DBNull.Value)
                        {
                            oItem.OpenningStock = Convert.ToDouble(reader["OpenningStock"]);
                            oItem.ClStock = Convert.ToDouble(reader["OpenningStock"]);
                            ++nCount;
                        }
                        else
                        {
                            oItem.OpenningStock = 0;
                            oItem.ClStock = 0;
                        }
                    }


                    if (reader["NSP"] != DBNull.Value)
                        oItem.NSP = Convert.ToDouble(reader["NSP"]);
                    else oItem.NSP = 0;

                    if (reader["RSP"] != DBNull.Value)
                        oItem.RSP = Convert.ToDouble(reader["RSP"]);
                    else oItem.RSP = 0;

                    if (reader["UnitCostPrice"] != DBNull.Value)
                        oItem.UnitCostPrice = Convert.ToDouble(reader["UnitCostPrice"]);
                    else oItem.UnitCostPrice = 0;

                    if (reader["TradePrice"] != DBNull.Value)
                        oItem.TradePrice = Convert.ToDouble(reader["TradePrice"]);
                    else oItem.TradePrice = 0;

                    if (reader["VAT"] != DBNull.Value)
                        oItem.VAT = Convert.ToDouble(reader["VAT"]);
                    else oItem.VAT = 0;

                    if (reader["TranNo"] != DBNull.Value)
                        oItem.TranNo = (string)reader["TranNo"];
                    else oItem.TranNo = "";

                    if (reader["InvoiceDate"] != DBNull.Value)
                        oItem.InvoiceDate = (DateTime)reader["InvoiceDate"];
                    else oItem.InvoiceDate = Convert.ToDateTime(" Null");

                    if (reader["TrantypeID"] != DBNull.Value)
                        oItem.TrantypeID = int.Parse(reader["TrantypeID"].ToString());
                    else oItem.TrantypeID = -1;

                    if (reader["DutyTranTYpeID"] != DBNull.Value)
                        oItem.DutyTranTYpeID = int.Parse(reader["DutyTranTYpeID"].ToString());
                    else oItem.DutyTranTYpeID = -1;

                    if (reader["Qty"] != DBNull.Value)
                        oItem.Qty = Convert.ToDouble(reader["Qty"]);
                    else oItem.Qty = -1;


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


        public void FromDataSetSalesNPurRegister(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    RptSalesNPurchaseRegister oRptSalesNPurchaseRegister = new RptSalesNPurchaseRegister();

                    oRptSalesNPurchaseRegister.ProductID = Convert.ToInt32(oRow["ProductID"]);
                    oRptSalesNPurchaseRegister.ProductCode = (string)oRow["ProductCode"];
                    oRptSalesNPurchaseRegister.ProductName = (string)oRow["ProductName"];
                    oRptSalesNPurchaseRegister.SupplierID = Convert.ToInt32(oRow["SupplierID"]);
                    oRptSalesNPurchaseRegister.SupplierName = (string)oRow["SupplierName"];
                    oRptSalesNPurchaseRegister.Address = (string)oRow["Address"];
                    oRptSalesNPurchaseRegister.OpenningStock = (double)oRow["OpenningStock"];
                    oRptSalesNPurchaseRegister.NSP = (double)oRow["NSP"];
                    oRptSalesNPurchaseRegister.RSP = (double)oRow["RSP"];
                    oRptSalesNPurchaseRegister.UnitCostPrice = (double)oRow["UnitCostPrice"];
                    oRptSalesNPurchaseRegister.TranNo = (string)oRow["TranNo"];
                    oRptSalesNPurchaseRegister.InvoiceDate = (DateTime)oRow["InvoiceDate"];
                    oRptSalesNPurchaseRegister.TrantypeID = Convert.ToInt32(oRow["TrantypeID"]);
                    oRptSalesNPurchaseRegister.Qty = (double)oRow["Qty"];
                    //oRptSalesNPurchaseRegister.Transide = Convert.ToInt32(oRow["Transide"]);

                    InnerList.Add(oRptSalesNPurchaseRegister);
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetSalesAndPurRegister()
        {
            double _ClosingStock = 0;
            double _TotalRecQty = 0;
            double _UnitCost = 0;
            double _RSP = 0;
            double _NSP = 0;

            int _nCount = 0;
            int _nStCount = 0;

            foreach (RptSalesNPurchaseRegister oRptSalesNPurchaseRegister in this)
            {
                if (_nCount == 0)
                {
                    _ClosingStock = oRptSalesNPurchaseRegister.ClStock;


                    //_UnitCost = oRptSalesNPurchaseRegister.UnitCostPrice;
                    //_RSP = oRptSalesNPurchaseRegister.RSP;
                    //_NSP = oRptSalesNPurchaseRegister.NSP;

                    _nCount++;


                }
                //oRptSalesNPurchaseRegister.UnitCostPrice = _UnitCost;
                //oRptSalesNPurchaseRegister.NSP = _NSP;
                //oRptSalesNPurchaseRegister.RSP = _RSP;

                _TotalRecQty = oRptSalesNPurchaseRegister.ClStock;

                if (oRptSalesNPurchaseRegister.DutyTranTYpeID == 0)
                {

                    _ClosingStock = _ClosingStock + oRptSalesNPurchaseRegister.Qty;
                    oRptSalesNPurchaseRegister.ClStock = _ClosingStock;
                    oRptSalesNPurchaseRegister.TotalRecQty = oRptSalesNPurchaseRegister.ClStock;

                }

                if (oRptSalesNPurchaseRegister.DutyTranTYpeID == 1)
                {
                    _ClosingStock = _ClosingStock - oRptSalesNPurchaseRegister.Qty;
                    oRptSalesNPurchaseRegister.ClStock = _ClosingStock;
                    _TotalRecQty = oRptSalesNPurchaseRegister.ClStock + oRptSalesNPurchaseRegister.Qty;
                    oRptSalesNPurchaseRegister.TotalRecQty = _TotalRecQty;


                }

                if (oRptSalesNPurchaseRegister.DutyTranTYpeID == 2)
                {
                    _ClosingStock = _ClosingStock - oRptSalesNPurchaseRegister.Qty;
                    oRptSalesNPurchaseRegister.ClStock = _ClosingStock;
                    _TotalRecQty = oRptSalesNPurchaseRegister.ClStock + oRptSalesNPurchaseRegister.Qty;
                    oRptSalesNPurchaseRegister.TotalRecQty = _TotalRecQty;

                }

                if (oRptSalesNPurchaseRegister.DutyTranTYpeID == 21)
                {
                    _ClosingStock = _ClosingStock + oRptSalesNPurchaseRegister.Qty;
                    oRptSalesNPurchaseRegister.ClStock = _ClosingStock;
                    oRptSalesNPurchaseRegister.TotalRecQty = oRptSalesNPurchaseRegister.ClStock;
                }

                if (oRptSalesNPurchaseRegister.DutyTranTYpeID == 22)
                {
                    _ClosingStock = _ClosingStock - oRptSalesNPurchaseRegister.Qty;
                    oRptSalesNPurchaseRegister.ClStock = _ClosingStock;
                    _TotalRecQty = oRptSalesNPurchaseRegister.ClStock + oRptSalesNPurchaseRegister.Qty;
                    oRptSalesNPurchaseRegister.TotalRecQty = _TotalRecQty;
                }

                else oRptSalesNPurchaseRegister.ClStock = _ClosingStock;
                //oRptSalesNPurchaseRegister.TotalRecQty = _TotalRecQty;

            }

        }
    }
}
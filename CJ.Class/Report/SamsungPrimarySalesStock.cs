using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;


namespace CJ.Class.Report
{
    public class SamsungPrimarySalesStock
    {
        private int _nProductID;
        private string _sProductCode;
        private string _sPName;
        private string _sProductModel;
        private string _sAGName;
        private string _sASGName;
        private int _nImportQty;
        private int _nPipeline;
        private int _nNDStock;
        private int _nSalesQty;
        private int _nSecondaryStock;
        private int _nSecSalesQty;
        private int _nTertiaryStock;
        private int _nTertiarySalesQty;

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

        public string PName
        {
            get { return _sPName; }
            set { _sPName = value; }
        }

        public string ProductModel
        {
            get { return _sProductModel; }
            set { _sProductModel = value; }
        }

        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value; }
        }

        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }

        public int ImportQty
        {
            get { return _nImportQty; }
            set { _nImportQty = value; }
        }

        public int Pipeline
        {
            get { return _nPipeline; }
            set { _nPipeline = value; }
        }

        public int NDStock
        {
            get { return _nNDStock; }
            set { _nNDStock = value; }
        }

        public int SalesQty
        {
            get { return _nSalesQty; }
            set { _nSalesQty = value; }
        }

        public int SecondaryStock
        {
            get { return _nSecondaryStock; }
            set { _nSecondaryStock = value; }
        }

        public int SecSalesQty
        {
            get { return _nSecSalesQty; }
            set { _nSecSalesQty = value; }
        }

        public int TertiaryStock
        {
            get { return _nTertiaryStock; }
            set { _nTertiaryStock = value; }
        }

        public int TertiarySalesQty
        {
            get { return _nTertiarySalesQty; }
            set { _nTertiarySalesQty = value; }
        }
    }

    public class SamsungPrimarySalesStocks : CollectionBaseCustom
    {

        public void Add(SamsungPrimarySalesStock oSamsungPrimarySalesStock)
        {
            this.List.Add(oSamsungPrimarySalesStock);
        }
        public SamsungPrimarySalesStock this[int i]
        {
            get { return (SamsungPrimarySalesStock)InnerList[i]; }
            set { InnerList[i] = value; }
        }
       
        public void GetPrimarySalesStock(int nAGID, int nASGID, string sProductCode, string sProductName, DateTime dStartDate, DateTime dEndDate)
        {
            dEndDate = dEndDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select * from " +
                          " (select ProductID,ProductCode,substring(ProductName,16,110) as PName,ProductModel,agname,asgname " +
                          " from tmlsysdb.dbo.v_ProductDetails " +
                          " where itemcategory=1) A " +
                          " join " +
                          " (select ProductID,sum(ReceivedQty) as ImportQty,sum(Pipeline) as Pipeline,sum(NDStock) NDStock,sum(salesqty) as salesqty,sum(secondaryStock) secondaryStock,sum(secsalesqty) as secsalesqty,sum(TertiartyStock) as TertiaryStock,sum(TertiartySalesqty) as TertiarySalesQty " +
                          " from " +
                          " (select ProductID, isnull(sum(p2.CR) - abs(sum(p2.DR)),0) as SalesQty,0 secsalesqty,0 NDStock,0 secondaryStock,0 as ReceivedQty,0 as Pipeline,0 as TertiartyStock,0 as TertiartySalesqty " +
                          " from " +
                          " (select cast(convert(varchar,invoicedate,106) as datetime) as InvDate,ProductID,CustomerID, " +
                          " sum(Quantity) as CR, 0 as DR,sum(isnull(FreeQty,0)) as FreeCR, 0 as FreeDR,avg(unitprice)as unitprice " +
                          " from tmlsysdb.dbo.t_salesInvoice im,  tmlsysdb.dbo.t_salesInvoiceDetail cd " +
                          " where  im.InvoiceID = cd.InvoiceID and im.invoicetypeid in (1,2,3,4,5,15) and invoicestatus not in (3) " +
                          " group by  cast(convert(varchar,invoicedate,106) as datetime),ProductID,CustomerID " +
                          " union all " +
                          " select cast(convert(varchar,invoicedate,106) as datetime) as InvDate,ProductID,CustomerID, " +
                          " 0 as CR, sum(Quantity)  as DR,0 as FreeCR, sum(isnull(FreeQty,0)) as FreeDR,avg(unitprice)as unitprice " +
                          " from tmlsysdb.dbo.t_salesInvoice im, tmlsysdb.dbo.t_salesInvoiceDetail cd " +
                          " where  im.InvoiceID = cd.InvoiceID and im.invoicetypeid in (6,7,8,9,10,12,16) and invoicestatus not in (3) " +
                          " group by  cast(convert(varchar,invoicedate,106) as datetime),ProductID,CustomerID) as p2 " +
                          " where InvDate between '" + dStartDate + "' and '" + dEndDate + "' and InvDate <'" + dEndDate + "' group by ProductID " +
                          " union all " +
                          " select d.productid,0 salesqty,sum(qty) as secsalesqty,0 NDStock,0 secondaryStock ,0 as ReceivedQty,0 as Pipeline,0 as TertiartyStock,0 as TertiartySalesqty " +
                          " from dbo.t_DMSLiteSalesTran a,dbo.t_DMSLiteProductMapping b, v_productdetails d " +
                          " where  a.productcode=b.dlproductcode and b.cproductcode=d.productcode and " +
                          " invoicedate between '" + dStartDate + "' and '" + dEndDate + "' and invoicedate <'" + dEndDate + "' group by ProductID " +
                          " union all " +
                          " select productid,0 salesqty,0 as secsalesqty,sum(currentStock) as NDStock ,0 secondaryStock ,0 as ReceivedQty,0 as Pipeline,0 as TertiartyStock,0 as TertiartySalesqty " +
                          " from t_ProductStock where WAREHOUSEID  not in (1,76,90) group by productid " +
                          " union all " +
                          " select productid,0 salesqty,0 as secsalesqty,0 as NDStock, sum(Total_Stock) secondaryStock,0 as ReceivedQty,0 as Pipeline ,0 as TertiartyStock,0 as TertiartySalesqty " +
                          " from dbo.t_DMSLiteRDSStock a,dbo.t_DMSLiteProductMapping b,t_product c " +
                          " where a.productcode=b.dlproductcode and b.cproductcode=c.productcode " +
                          " group by productid " +
                          " union all " +
                          " select productid,0 salesqty,0 as secsalesqty,0 as NDStock, 0 secondaryStock,sum(sc.ReceivedQty) ReceivedQty,sum(sc.TransitQty) as Pipeline,0 as TertiartyStock,0 as TertiartySalesqty " +
                          " from " +
                          " (Select A.POID,pono,A.LCNo, A.LCDate, A.ProductID,LCOpenQty,0 as ReceivedQty, (LCOpenQty-isnull(ReceivedQty,0)) as TransitQty " +
                          " from " +
                          " (Select A.POID,PONO,LCNo, LCDate, ProductID,sum(ApprovedQty) as LCOpenQty " +
                          " from t_PurchaseRequisition a, t_PurchaseRequisitionDetail B " +
                          " where A.POID=B.POID and status in (2) " +
                          " Group By A.POID,PONO,LCNo, LCDate, ProductID) as a " +
                          " left outer join " +
                          " (Select c.POID, ProductID, sum(Qty)as ReceivedQty " +
                          " from t_commercialinvoice C,t_commercialinvoicedetail D " +
                          " where C.CIID=D.CIID and c.poid=d.poid and status in (3,4) " +
                          " group by c.POID, ProductID) as c on a.POID = c.POID and a.ProductID = c.ProductID " +
                          " union all " +
                          " select '' POID,0 as pono,'' LCNo, getdate() as LCDate, productid,0 LCOpenQty,sum(qty) as ReceivedQty, 0 as TransitQty from dbo.t_ProductStockTran a ,dbo.t_ProductStockTranItem b " +
                          " where a.tranid=b.tranid and trandate between '" + dStartDate + "' and '" + dEndDate + "' and trandate <'" + dEndDate + "' and tranno like 'GRD%' " +
                          " group by productid)as sc group by productid) x group by ProductID) B " +
                          " on A.ProductId=B.ProductID order by agname,asgname ";

            cmd.CommandTimeout = 0;


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SamsungPrimarySalesStock oSamsungPrimarySalesStock = new SamsungPrimarySalesStock();


                    oSamsungPrimarySalesStock.ProductCode = (string)reader["ProductCode"];
                    oSamsungPrimarySalesStock.PName = (string)reader["PName"];


                    oSamsungPrimarySalesStock.ProductModel = (string)reader["ProductModel"];
                    oSamsungPrimarySalesStock.AGName = (string)reader["AGName"];
                    oSamsungPrimarySalesStock.ASGName = (string)reader["ASGName"];
                    oSamsungPrimarySalesStock.ImportQty = int.Parse(reader["ImportQty"].ToString());
                    oSamsungPrimarySalesStock.Pipeline = int.Parse(reader["PipeLine"].ToString());
                    oSamsungPrimarySalesStock.NDStock = int.Parse(reader["NDStock"].ToString());
                    oSamsungPrimarySalesStock.SalesQty = int.Parse(reader["SalesQty"].ToString());
                    oSamsungPrimarySalesStock.SecondaryStock = int.Parse(reader["SecondaryStock"].ToString());
                    oSamsungPrimarySalesStock.SecSalesQty = int.Parse(reader["SecSalesQty"].ToString());
                    oSamsungPrimarySalesStock.TertiaryStock = int.Parse(reader["TertiaryStock"].ToString());
                    oSamsungPrimarySalesStock.TertiarySalesQty = int.Parse(reader["TertiarySalesQty"].ToString());


                    InnerList.Add(oSamsungPrimarySalesStock);
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.POS;

namespace CJ.Class.Report
{
    public class SamsungSecondarySalesStock
    {
        private int _nProductID;
        private string _sProductCode;
        private string _sPName;
        private string _sProductModel;
        private string _sAGName;
        private string _sASGName;
        private int _nCustomerID;
        private string _sCustomerCode;
        private string _sCustomerName;
        private string _sCustomerTypeName;
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

        public string CustomerTypeName
        {
            get { return _sCustomerTypeName; }
            set { _sCustomerTypeName = value; }
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

    public class SamsungSecondarySalesStocks : CollectionBaseCustom
    {

        public void Add(SamsungSecondarySalesStock oSamsungSecondarySalesStock)
        {
            this.List.Add(oSamsungSecondarySalesStock);
        }
        public SamsungSecondarySalesStock this[int i]
        {
            get { return (SamsungSecondarySalesStock)InnerList[i]; }
            set { InnerList[i] = value; }
        }
       
        public void GetSecondarySalesStock(int nCustomerID, int nMAGID, int nASGID, string sProductCode, string sProductName, DateTime dStartDate, DateTime dEndDate)
        {
            dEndDate = dEndDate.AddDays(1);
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select * from " +
                        " (select ProductID,ProductCode,substring(ProductName,16,110) as PName,ProductModel,agname, ASGName,CustomerID,pd.CustomerCode, CustomerName,CustomerTypeName  " +
                        " from tmlsysdb.dbo.v_ProductDetails , tmlsysdb.dbo.v_CustomerDetails pd left outer join TMLAddDB.dbo.t_tsomapping tm " +
                        " on (pd.customercode=tm.customercode)  where itemcategory=1) A " +
                        " join " +
                        " (select ProductID,customerid,sum(salesqty) as salesqty,sum(secondaryStock) secondaryStock,sum(secsalesqty) as secsalesqty,sum(TertiartyStock) as TertiaryStock,sum(TertiartySalesqty) as TertiarySalesQty " +
                        " from " +
                        " (select ProductID,customerid, isnull(sum(p2.CR) - abs(sum(p2.DR)),0) as SalesQty,0 secsalesqty,0 secondaryStock,0 as TertiartyStock,0 as TertiartySalesqty " +
                        " from " +
                        " (select cast(convert(varchar,invoicedate,106) as datetime) as InvDate,ProductID,CustomerID, " +
                        " sum(Quantity) as CR, 0 as DR,sum(isnull(FreeQty,0)) as FreeCR, 0 as FreeDR,avg(unitprice)as unitprice " +
                        " from tmlsysdb.dbo.t_salesInvoice im,  tmlsysdb.dbo.t_salesInvoiceDetail cd " +
                        " where  im.InvoiceID = cd.InvoiceID and " +
                        " im.invoicetypeid in (1,2,3,4,5,15) and invoicestatus not in (3) " +
                        " group by  cast(convert(varchar,invoicedate,106) as datetime),ProductID,CustomerID  " +
                        " union all  " +
                        " select cast(convert(varchar,invoicedate,106) as datetime) as InvDate,ProductID,CustomerID,  " +
                        " 0 as CR, sum(Quantity)  as DR,0 as FreeCR, sum(isnull(FreeQty,0)) as FreeDR,avg(unitprice)as unitprice  " +
                        " from tmlsysdb.dbo.t_salesInvoice im, tmlsysdb.dbo.t_salesInvoiceDetail cd where  im.InvoiceID = cd.InvoiceID and  " +
                        " im.invoicetypeid in (6,7,8,9,10,12,16) and invoicestatus not in (3) " +
                        " group by  cast(convert(varchar,invoicedate,106) as datetime),ProductID,CustomerID) as p2 " +
                        " where InvDate between '" + dStartDate + "' and '" + dEndDate + "' and InvDate <'" + dEndDate + "' " +
                        " group by ProductID,customerid " +
                        " union all " +
                        " select d.productid,e.customerid,0 salesqty,sum(qty) as secsalesqty,0 secondaryStock ,0 as TertiartyStock,0 as TertiartySalesqty " +
                        " from dbo.t_DMSLiteSalesTran a,dbo.t_DMSLiteProductMapping b,dbo.t_DMSLiteCustomerMapping c, v_productdetails d,t_customer e " +
                        " where a.smdpcode=c.dlcustomercode and a.productcode=b.dlproductcode and b.cproductcode=d.productcode and " +
                        " c.ccustomercode=e.customercode and " +
                        " invoicedate between '" + dStartDate + "' and '" + dEndDate + "' and invoicedate <'" + dEndDate + "' group by d.productid,e.customerid " +
                        " union all " +
                        " select productid,customerid,0 salesqty,0 as secsalesqty, sum(Total_Stock) secondaryStock ,0 as TertiartyStock,0 as TertiartySalesqty " +
                        " from dbo.t_DMSLiteRDSStock a,dbo.t_DMSLiteProductMapping b,t_product c,dbo.t_DMSLiteCustomerMapping d,t_customer e " +
                        " where a.productcode=b.dlproductcode and " +
                        " b.cproductcode=c.productcode and a.channel_code=d.dlcustomercode and d.ccustomercode=e.customercode group by productid,customerid) x " +
                        " group by ProductID,customerid " +
                        " union all  " +
                        " select productid,customerid,0 salesqty,0 as secsalesqty, 0 secondaryStock ,0 as TertiartyStock,count(imei) as TertiartySalesqty " +
                        " from tmladddb.dbo.t_MCSTertiarySales a,tmlsysdb.dbo.t_imeisource2 b,dbo.t_DMSLiteCustomerMapping c, t_customer e " +
                        " where a.imei=b.imeino and a.retailid=c.dlcustomercode and c.ccustomercode=e.customercode and saledate between '" + dStartDate + "' and '" + dEndDate + "' and saledate <'" + dEndDate + "' " +
                        " group by productid,customerid) B " +
                        " on A.ProductId=B.ProductID and a.customerid=b.customerid " +
                        " order by CustomerTypeName,CustomerName,AGName, ASGName ";
            
            cmd.CommandTimeout = 0;


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SamsungSecondarySalesStock oSamsungSecondarySalesStock = new SamsungSecondarySalesStock();


                    oSamsungSecondarySalesStock.ProductCode = (string)reader["ProductCode"];
                    oSamsungSecondarySalesStock.PName = (string)reader["PName"];
                    oSamsungSecondarySalesStock.ProductModel = (string)reader["ProductModel"];
                    oSamsungSecondarySalesStock.AGName = (string)reader["AGName"];
                    oSamsungSecondarySalesStock.ASGName = (string)reader["ASGName"];

                    oSamsungSecondarySalesStock.CustomerCode = (string)reader["CustomerCode"];
                    oSamsungSecondarySalesStock.CustomerName = (string)reader["CustomerName"];
                    oSamsungSecondarySalesStock.CustomerTypeName = (string)reader["CustomerTypeName"];

                    oSamsungSecondarySalesStock.SalesQty = int.Parse(reader["SalesQty"].ToString());
                    oSamsungSecondarySalesStock.SecondaryStock = int.Parse(reader["SecondaryStock"].ToString());
                    oSamsungSecondarySalesStock.SecSalesQty = int.Parse(reader["SecSalesQty"].ToString());
                    oSamsungSecondarySalesStock.TertiaryStock = int.Parse(reader["TertiaryStock"].ToString());
                    oSamsungSecondarySalesStock.TertiarySalesQty = int.Parse(reader["TertiarySalesQty"].ToString());


                    InnerList.Add(oSamsungSecondarySalesStock);
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

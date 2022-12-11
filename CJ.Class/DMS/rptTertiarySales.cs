// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Mazharul Haque
// Date: March, 2012
// Time : 01:00 PM
// Description: Reprot Class for Tertiary Sales Report 
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
    public class rptTertiarySales
    {
        private int _nDistributorID;
        private string _sCustomerCode;
        private string _sCustomerName;
        private string _sRegionName;
        private string _sAreaName;
        private string _sTerritoryName;
        private int _nDSRID;
        private int _nDSRCode;
        private string _sDSRName;
        private int _nOutletID;
        private int _nOutletCode;
        private string _sOutletName;
        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
        private DateTime dTrandate;
        private int _nStockQty;
        private int _nSalesQty;


        public int DistributorID
        {
            get { return _nDistributorID; }
            set { _nDistributorID = value; }
        }
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
        }
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }
        public string RegionName
        {
            get { return _sRegionName; }
            set { _sRegionName = value.Trim(); }
        }
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

        public int DSRID
        {
            get { return _nDSRID; }
            set { _nDSRID = value; }
        }

        public int DSRCode
        {
            get { return _nDSRCode; }
            set { _nDSRCode = value; }
        }

        public string DSRName
        {
            get { return _sDSRName; }
            set { _sDSRName = value; }
        }
        public int OutletID
        {
            get { return _nOutletID; }
            set { _nOutletID = value; }
        }
        public int OutletCode
        {
            get { return _nOutletCode; }
            set { _nOutletCode = value; }
        }
        public string OutletName
        {
            get { return _sOutletName; }
            set { _sOutletName = value.Trim(); }
        }

        public DateTime Trandate
        {
            get { return dTrandate; }
            set { dTrandate = value; }
        }
        public int StockQty
        {
            get { return _nStockQty; }
            set { _nStockQty = value; }
        }
        public int SalesQty
        {
            get { return _nSalesQty; }
            set { _nSalesQty = value; }
        }
    }

    public class TertiarySales : CollectionBaseCustom
    
    {
        public void Add(rptTertiarySales orptTertiarySales)
        {
            this.List.Add(orptTertiarySales);
        }
        public rptTertiarySales this[Int32 Index]
        {
            get
            {
                return (rptTertiarySales)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(rptTertiarySales))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void TertiarySalesStockBy(DateTime dTrandate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = @" select trandate,ssd.distributorid,customercode,customername,regionname,areaname,territoryname,ssd.dsrid,dsrcode,dsrname,ssd.outletid,
                        outletcode,outletname,ssd.productid,productcode,productname,stock,sales
                        from
                        (
                        select trandate,distributorid,dsrid,ss.outletid,outletcode,outletname,productid,stock,sales
                        from
                        (
                        select isnull(stock.trandate,sales.trandate) as Trandate,isnull (stock.dsrid,sales.dsrid)as dsrid, isnull (stock.outletid,sales.outletid) as outletid,
                        isnull (stock.productid,sales.productid)as productid, isnull (stock,0) as Stock, isnull (sales,0) as sales
                        from
                        (select trandate ,dsrid,outletid,productid, sum (qty) as stock  from t_dmsmproducttran1 a 
                        inner join t_dmsmprotrandetail1 b
                        on a.tranid=b.tranid
                        where trantypeid=0 
                        group by trandate ,dsrid,outletid,productid
                        ) as stock
                        full outer join
                        (select trandate,dsrid,outletid,productid, sum (qty) as sales  from t_dmsmproducttran1 a 
                        inner join t_dmsmprotrandetail1 b
                        on a.tranid=b.tranid
                        where trantypeid=1 
                        group by trandate,dsrid,outletid,productid
                        ) as sales
                        on stock.trandate=sales.trandate and stock.dsrid=sales and stock.productid=sales.productid and stock.outletid=sales.outletid
                        ) as ss
                        left outer join
                        t_dmsoutlet c
                        on c.outletid=ss.outletid
                        ) as ssd
                        left outer join t_product d
                        on d.productid=ssd.productid
                        left outer join t_dmsdsr f
                        on f.dsrid=ssd.dsrid
                        left outer join v_customerdetails g
                        on g.customerid=ssd.distributorid
                        where trandate= ? and dsrname not like 'BS%'
                        group by trandate,ssd.distributorid,customercode,customername,regionname,areaname,territoryname,ssd.dsrid,dsrcode,dsrname,
                        ssd.outletid,outletcode,outletname,ssd.productid,productcode,productname,stock,sales ";

            //


            cmd.Parameters.AddWithValue("trandate", dTrandate);        
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rptTertiarySales orptTertiarySales = new rptTertiarySales();




                        orptTertiarySales.DistributorID = (int)reader["DistributorID"];
                        orptTertiarySales.CustomerCode = reader["CustomerCode"].ToString();
                        orptTertiarySales.CustomerName = reader["CustomerName"].ToString();
                        orptTertiarySales.RegionName = reader["regionname"].ToString();
                        orptTertiarySales.AreaName = reader["areaname"].ToString();
                        orptTertiarySales.TerritoryName = reader["territoryname"].ToString();
                        orptTertiarySales.OutletID = (int)reader["OutletID"];
                        orptTertiarySales.OutletCode = (int)reader["OutletCode"];
                        orptTertiarySales.OutletName = reader["OutletName"].ToString();
                        orptTertiarySales.DSRID = (int)reader["DSRID"];
                        orptTertiarySales.DSRCode = (int)reader["DSRCode"];
                        orptTertiarySales.DSRName = reader["DSRName"].ToString();
                        orptTertiarySales.ProductID = (int)reader["ProductID"];
                        orptTertiarySales.ProductCode = reader["productcode"].ToString();
                        orptTertiarySales.ProductName = reader["productname"].ToString();
                        orptTertiarySales.SalesQty = (int)(reader["Sales"]);
                        orptTertiarySales.StockQty = (int)(reader["stock"]);

                        InnerList.Add(orptTertiarySales);
                    }
               

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }

        public void FromDataSetForTertiarySalesStock(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {

                    rptTertiarySales orptTertiarySales = new rptTertiarySales();



                        orptTertiarySales.DistributorID = (int)oRow["DistributorID"];
                        orptTertiarySales.CustomerCode = (string)oRow["CustomerCode"].ToString();
                        orptTertiarySales.CustomerName = (string)oRow["CustomerName"].ToString();
                        orptTertiarySales.RegionName = (string)oRow["regionname"].ToString();
                        orptTertiarySales.AreaName = (string)oRow["areaname"].ToString();
                        orptTertiarySales.TerritoryName = (string)oRow["territoryname"].ToString();
                        orptTertiarySales.OutletID = (int)oRow["OutletID"];
                        orptTertiarySales.OutletCode = (int)oRow["OutletCode"];
                        orptTertiarySales.OutletName = (string)oRow["OutletName"].ToString();
                        orptTertiarySales.DSRID = (int)oRow["DSRID"];
                        orptTertiarySales.DSRCode = (int)oRow["DSRCode"];
                        orptTertiarySales.DSRName = (string)oRow["DSRName"].ToString();
                        orptTertiarySales.ProductID = (int)oRow["ProductID"];
                        orptTertiarySales.ProductCode = (string)oRow["productcode"].ToString();
                        orptTertiarySales.ProductName = (string)oRow["productname"].ToString();
                        orptTertiarySales.SalesQty = (int)(oRow["SalesQty"]);
                        orptTertiarySales.StockQty = (int)(oRow["StockQty"]);

                        InnerList.Add(orptTertiarySales);
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

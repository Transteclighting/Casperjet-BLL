  // <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Mazharul Haque
// Date: February, 2011
// Time : 01:00 PM
// Description: Form for frmRptSalesSummary 
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
    public class rptSalesAchivement
    {
        private string _sRegionName;
        private string _sAreaName;
        private string _sTerritoryName;
        private int _nCustomerID;
        private string _sCustomerCode;
        private string _sCustomerName;
        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
        private double _dTarget;
        private double _dPrSales;
        private double _dSecSales;
        private double _dAchivement;
        private double _dMTDTarget;
        private double _dMTDAchv;

        private int _nAreaID;
        private int _nTerritoryID;
        private int _nBrandID;
        private string _sBrandName;
        private int _nASGID;
        private string _sASG;


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

        public double Target
        {
            get { return _dTarget; }
            set { _dTarget = value; }
        }

        public double PrSales
        {
            get { return _dPrSales; }
            set { _dPrSales = value; }
        }

        public double SecSales
        {
            get { return _dSecSales; }
            set { _dSecSales = value; }
        }
        public double Achivement
        {
            get { return _dAchivement; }
            set { _dAchivement = value; }
        }
        public double MTDTarget
        {
            get { return _dMTDTarget; }
            set { _dMTDTarget = value; }

        }
        public double MTDAchv
        {
            get { return _dMTDAchv; }
            set { _dMTDAchv = value; }

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
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
        }
        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }
        public string ASG
        {
            get { return _sASG; }
            set { _sASG = value; }
        }
    }

    public class rptSalesAchivements : CollectionBaseCustom
    {
        public void Add(rptSalesAchivement orptSalesAchivement)
        {
            this.List.Add(orptSalesAchivement);
        }

        public rptSalesAchivement this[Int32 Index]
        {
            get
            {
                return (rptSalesAchivement)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(rptSalesAchivement))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void SalesAchivementBy(DateTime dDFromDate, DateTime dDToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = " select regionname,areaname,territoryname,customercode,customername,step1.customerid,step1.productid,productcode,substring(productname,16,20) as productname , "+
            " Target,PrAchv, SecAchv " +
                " from " +
                " ( " +
                " select isnull (pssales.CustomerID,tgt.marketgroupid) as CustomerID,isnull (pssales.productid,tgt.productgroupid) as ProductID," +
                " isnull (targetqty,0)as target, PrAchv,SecAchv" +
                " from " +
                " (" +
                " select isnull(prsales.customerid,secsales.distributorid) as CustomerID,isnull(prsales.productid,secsales.productid) as ProductID," +
                " isnull (PrQty,0) as PrAchv,isnull (secqty,0) AS SecAchv " +
                " from " +
                " (" +
                " select customerid,productid,isnull(sum(crqty)- abs(sum(drqty)),0) as PrQty" +
                " from " +
                " (" +
                " select customerid,Productid, sum(quantity) as crqty, 0 as drqty " +
                " from t_salesinvoice a, t_salesinvoicedetail b " +
                " where a.invoiceid = b.invoiceid " +
                " and invoicedate between ? and ? " +
                " and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)" +
                " group by customerid,productid " +
                " union all " +
                " select customerid,Productid, 0 as crqty, sum (quantity) as drqty " +
                " from t_salesinvoice a, t_salesinvoicedetail b " +
                " where a.invoiceid = b.invoiceid " +
                " and invoicedate between ? and ? " +
                " and invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3) " +
                " group by customerid,productid " +
                " )as PrimaryQty " +
                " group by customerid,productid " +
                " ) as prsales " +
                " full outer Join " +
                " ( " +
                " select distributorid,secondaryqty.productid,isnull(sum(drSalesQty)-sum (crSalesQty),0) as secqty " +
                " from " +
                " ( " +
                " select distributorid,b.productid, sum (qty) as drSalesQty, 0 as crSalesQty  from t_dmsproducttran a, t_dmsproducttranitem b " +
                 @"where a.tranid=b.tranid and trantypeid=2 and trandate between ? and ? 
                group by distributorid,b.productid
                union all
                select distributorid,b.productid, 0 as drSalesQty, sum (qty) as crSalesQty from t_dmsproducttran a, t_dmsproducttranitem b
                where a.tranid=b.tranid and trantypeid=5 and trandate between ? and ?
                group by distributorid,b.productid
                ) as secondaryqty
                group by distributorid,secondaryqty.productid
                ) as secsales

                on  prsales.productid = secsales.productid and prsales.customerid = secsales.distributorid

                ) as PSSales

                full outer join

                (

                select marketgroupid,productgroupid, sum (qty) as targetqty from t_planbudgettarget where perioddate=?
                group by marketgroupid,productgroupid

                ) as tgt

                on tgt.productgroupid= PSSales.productid and tgt.marketgroupid= PSSales.customerid 

                ) as step1

                left outer join t_product prd
                on prd.productid=step1.productid

                left outer join v_customerdetails cd
                on cd.customerid=step1.customerid " ;


            cmd.Parameters.AddWithValue("invoicedate", dDFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dDToDate);

            cmd.Parameters.AddWithValue("invoicedate", dDFromDate);
            cmd.Parameters.AddWithValue("invoicedate", dDToDate);

            cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            cmd.Parameters.AddWithValue("TranDate", dDToDate);

            cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            cmd.Parameters.AddWithValue("TranDate", dDToDate);

            cmd.Parameters.AddWithValue("perioddate", dDFromDate);
           


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptSalesAchivement orptSalesAchivement = new rptSalesAchivement();
                    
                    if (Convert.ToDouble(reader["Target"].ToString()) > 0)

                    {

                        orptSalesAchivement.RegionName = reader["regionname"].ToString();
                        orptSalesAchivement.AreaName = reader["areaname"].ToString();
                        orptSalesAchivement.TerritoryName = reader["territoryname"].ToString();
                        orptSalesAchivement.CustomerID = (int)(reader["Customerid"]);
                        orptSalesAchivement.CustomerCode = reader["CustomerCode"].ToString();
                        orptSalesAchivement.CustomerName = reader["CustomerName"].ToString();
                        orptSalesAchivement.ProductID = (int)(reader["ProductID"]);
                        orptSalesAchivement.ProductCode = reader["ProductCode"].ToString();
                        orptSalesAchivement.ProductName = reader["ProductName"].ToString();
                        if (reader["Target"] != DBNull.Value)
                            orptSalesAchivement.Target = Convert.ToDouble(reader["Target"].ToString());
                        else orptSalesAchivement.Target = 0;
                        if (reader["PrAchv"] != DBNull.Value)
                            orptSalesAchivement.PrSales = Convert.ToDouble(reader["PrAchv"].ToString());
                        else orptSalesAchivement.PrSales = 0;
                        if (reader["SecAchv"] != DBNull.Value)
                            orptSalesAchivement.SecSales = Convert.ToDouble(reader["SecAchv"].ToString());
                        else orptSalesAchivement.SecSales = 0;

                        orptSalesAchivement.Achivement = ((orptSalesAchivement.SecSales) / (orptSalesAchivement.Target)) * 100;
                        orptSalesAchivement.MTDTarget = ((orptSalesAchivement.Target) / 26) * (DateTime.Now.Date.Day);
                        orptSalesAchivement.MTDAchv = ((orptSalesAchivement.SecSales) / (orptSalesAchivement.MTDTarget)) * 100;




                        InnerList.Add(orptSalesAchivement);
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
        public void SalesAchivementByBLL(DateTime dDFromDate, DateTime dDToDate, int nAreaID, int nTerritoryID, int nCustomerID, int nASGID, int nBrandID, int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = " select areaid,areaname,territoryid,territoryname,customercode,customername,step1.customerid,step1.productid,pd.productcode,substring(pd.productname,16,20) as productname , pd.BrandID, pd.BrandDesc, pd.ASGID, pd.ASGName, " +
            " Target,PrAchv, SecAchv " +
                " from " +
                " ( " +
                " select isnull (pssales.CustomerID,tgt.marketgroupid) as CustomerID,isnull (pssales.productid,tgt.productgroupid) as ProductID," +
                " isnull (targetqty,0)as target, PrAchv,SecAchv" +
                " from " +
                " (" +
                " select isnull(prsales.customerid,secsales.distributorid) as CustomerID,isnull(prsales.productid,secsales.productid) as ProductID," +
                " isnull (PrQty,0) as PrAchv,isnull (secqty,0) AS SecAchv " +
                " from " +
                " (" +
                " select customerid,productid,isnull(sum(crqty)- abs(sum(drqty)),0) as PrQty" +
                " from " +
                " (" +
                " select customerid,Productid, sum(quantity) as crqty, 0 as drqty " +
                " from t_salesinvoice a, t_salesinvoicedetail b " +
                " where a.invoiceid = b.invoiceid " +
                " and invoicedate between '" + dDFromDate + "' and '" + dDToDate + "' " +
                " and invoicetypeid in (1,2,4,5) and invoicestatus not in (3)" +
                " group by customerid,productid " +
                " union all " +
                " select customerid,Productid, 0 as crqty, sum (quantity) as drqty " +
                " from t_salesinvoice a, t_salesinvoicedetail b " +
                " where a.invoiceid = b.invoiceid " +
                " and invoicedate between '" + dDFromDate + "'  and '" + dDToDate + "' " +
                " and invoicetypeid in (6,7,9,10,12) and invoicestatus not in (3) " +
                " group by customerid,productid " +
                " )as PrimaryQty " +
                " group by customerid,productid " +
                " ) as prsales " +
                " full outer Join " +
                " ( " +
                " select distributorid,secondaryqty.productid,isnull(sum(drSalesQty)-sum (crSalesQty),0) as secqty " +
                " from " +
                " ( " +
                " select distributorid,b.productid, sum (qty) as drSalesQty, 0 as crSalesQty  from t_dmsproducttran a, t_dmsproducttranitem b " +
                "where a.tranid=b.tranid and trantypeid=2 and trandate between '" + dDFromDate + "'  and '" + dDToDate + "' " +
                "group by distributorid,b.productid " +
                "union all " +
                "select distributorid,b.productid, 0 as drSalesQty, sum (qty) as crSalesQty from t_dmsproducttran a, t_dmsproducttranitem b " +
                "where a.tranid=b.tranid and trantypeid=5 and trandate between '" + dDFromDate + "'  and '" + dDToDate + "' " +
                "group by distributorid,b.productid " +
                ") as secondaryqty " +
                "group by distributorid,secondaryqty.productid " +
                ") as secsales " +

                "on  prsales.productid = secsales.productid and prsales.customerid = secsales.distributorid " +

                ") as PSSales " +

                "full outer join " +

                "( " +

                "select marketgroupid,productgroupid, sum (qty) as targetqty from t_planbudgettarget where perioddate='" + dDFromDate + "'  " +
                "group by marketgroupid,productgroupid " +

                ") as tgt " +

                "on tgt.productgroupid= PSSales.productid and tgt.marketgroupid= PSSales.customerid  " +

                ") as step1 " +

                "inner join v_ProductDetails pd " +
                "on pd.productid=step1.productid " +
                "left outer join t_product prd " +
                "on prd.productid=step1.productid " +

                "left outer join v_customerdetails cd " +
                "on cd.customerid=step1.customerid ";


            if (nAreaID != -1)
            {
                sSql = sSql + " where areaid = " + nAreaID + "";

            }
            if (nTerritoryID != -1)
            {
                sSql = sSql + " and territoryid = " + nTerritoryID + "";

            }
            if (nCustomerID != -1)
            {
                sSql = sSql + " and customerid = '" + nCustomerID + "'";

            }
            if (nASGID != -1)
            {
                sSql = sSql + " and asgid = '" + nASGID + "'";

            }
            if (nBrandID != -1)
            {
                sSql = sSql + " and brandid = '" + nBrandID + "'";

            }


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptSalesAchivement orptSalesAchivement = new rptSalesAchivement();

                    if (Convert.ToDouble(reader["Target"].ToString()) > 0)
                    {

                        orptSalesAchivement.AreaID = (int)(reader["areaid"]);
                        orptSalesAchivement.AreaName = reader["areaname"].ToString();
                        orptSalesAchivement.TerritoryID = (int)(reader["territoryid"]);
                        orptSalesAchivement.TerritoryName = reader["territoryname"].ToString();
                        orptSalesAchivement.CustomerID = (int)(reader["Customerid"]);
                        orptSalesAchivement.CustomerCode = reader["CustomerCode"].ToString();
                        orptSalesAchivement.CustomerName = reader["CustomerName"].ToString();
                        orptSalesAchivement.ProductID = (int)(reader["ProductID"]);
                        orptSalesAchivement.ProductCode = reader["ProductCode"].ToString();
                        orptSalesAchivement.ProductName = reader["ProductName"].ToString();
                        orptSalesAchivement.BrandID = (int)(reader["brandid"]);
                        orptSalesAchivement.BrandName = reader["BrandDesc"].ToString();
                        orptSalesAchivement.ASGID = (int)(reader["ASGID"]);
                        orptSalesAchivement.ASG = reader["ASGName"].ToString();

                        if (reader["Target"] != DBNull.Value)
                            orptSalesAchivement.Target = Convert.ToDouble(reader["Target"].ToString());
                        else orptSalesAchivement.Target = 0;
                        if (reader["PrAchv"] != DBNull.Value)
                            orptSalesAchivement.PrSales = Convert.ToDouble(reader["PrAchv"].ToString());
                        else orptSalesAchivement.PrSales = 0;
                        if (reader["SecAchv"] != DBNull.Value)
                            orptSalesAchivement.SecSales = Convert.ToDouble(reader["SecAchv"].ToString());
                        else orptSalesAchivement.SecSales = 0;

                        orptSalesAchivement.Achivement = ((orptSalesAchivement.SecSales) / (orptSalesAchivement.Target)) * 100;
                        orptSalesAchivement.MTDTarget = ((orptSalesAchivement.Target) / 26) * (DateTime.Now.Date.Day);
                        orptSalesAchivement.MTDAchv = ((orptSalesAchivement.SecSales) / (orptSalesAchivement.MTDTarget)) * 100;




                        InnerList.Add(orptSalesAchivement);
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
        public void FromDataSetForSalesAchivement(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptSalesAchivement _orptSalesAchivement = new rptSalesAchivement();

                    _orptSalesAchivement.RegionName = (string)oRow["RegionName"];
                    _orptSalesAchivement.AreaName = (string)oRow["AreaName"];
                    _orptSalesAchivement.TerritoryName = (string)oRow["territoryname"];
                    _orptSalesAchivement.CustomerID = int.Parse(oRow["customerid"].ToString());
                    _orptSalesAchivement.CustomerCode = (string)oRow["CustomerCode"];
                    _orptSalesAchivement.CustomerName = (string)oRow["CustomerName"];
                    _orptSalesAchivement.ProductID =  int.Parse(oRow["ProductID"].ToString());
                    _orptSalesAchivement.ProductCode = (string)oRow["ProductCode"];
                    _orptSalesAchivement.ProductName = (string)oRow["ProductName"];
                    
                    _orptSalesAchivement.Target =  double.Parse(oRow["target"].ToString());
                    _orptSalesAchivement.PrSales = double.Parse(oRow["PrSales"].ToString());
                    _orptSalesAchivement.SecSales = double.Parse(oRow["SecSales"].ToString());
                    _orptSalesAchivement.Achivement = ((_orptSalesAchivement.SecSales) / (_orptSalesAchivement.Target)) * 100;
                    _orptSalesAchivement.MTDTarget = ((_orptSalesAchivement.Target) / 26)*(DateTime.Now.Date.Day);
                    _orptSalesAchivement.MTDAchv = ((_orptSalesAchivement.SecSales) / (_orptSalesAchivement.MTDTarget)) * 100;
                    InnerList.Add(_orptSalesAchivement);



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

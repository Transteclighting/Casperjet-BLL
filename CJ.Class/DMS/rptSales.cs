// <summary>
// Compamy: Transcom Electronics Limited
// Author: Mithun Sarkar
// Date: Augast, 2011
// Time : 01:00 PM
// Description: Form for Sales Report 
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
    public class rptSales
    {
        private int _nProductID;
        private int _nDistributorID;       
        private string _sProductCode;
        private string _sProductName;
        private int _nOutletID;      
        private int _nOutletCode;
        private string _sOutletName;     
        private string _sCustomerName;
        private string _sCustomerCode;
        private string _sRegionName;
        private string _sAreaName;
        private string _sTerritoryName;
        private int _nDSRID;
        private int _nRouteID;
        private string _sDSRName;
        private string _sRouteName;
        private int _nQty;
        private double _TotalQty;
        private int _nASGID;
        private string _sASGName;
        private int _nBrandID;
        private string _sBrandDesc;
        private double _nSalesAmount;
        private int _nAreaID;
        private int _nTerritoryID;

        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        public int DistributorID
        {
            get { return _nDistributorID; }
            set { _nDistributorID = value; }
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
        public string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value.Trim(); }
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
        public string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value.Trim(); }
        }

        public int DSRID
        {
            get { return _nDSRID; }
            set { _nDSRID = value; }
        }

        public int RouteID
        {
            get { return _nRouteID; }
            set { _nRouteID = value; }
        }

        public string DSRName
        {
            get { return _sDSRName; }
            set { _sDSRName = value.Trim(); }
        }

        public string RouteName
        {
            get { return _sRouteName; }
            set { _sRouteName = value.Trim(); }
        }
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
        public double TotalQty
        {
            get { return _TotalQty; }
            set { _TotalQty = value; }
        }

        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }

        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value.Trim(); }
        }

        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }

        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value.Trim(); }
        }

        public double SalesAmount
        {
            get { return _nSalesAmount; }
            set { _nSalesAmount = value; }
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
    }
    public class SalesReport : CollectionBaseCustom
    {

        public void Add(rptSales orptSales)
        {
            this.List.Add(orptSales);
        }
        public rptSales this[Int32 Index]
        {
            get
            {
                return (rptSales)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(rptSales))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }


        public void SaleSummary(DateTime dDFromDate, DateTime dDToDate, int nOutletID, int ndistributorid, int nItemCategory)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            // For Specific smdp
            if (ndistributorid !=-1)
            {
                // For Specific smdp and Specific Outlet

                if (nOutletID != -1)
                {
                    sSql = "Select sales.OutletID,OutletCode,OutletName,sales.ProductID,ProductCode,ProductName,ASGID,ASGName, BrandID,BrandDesc, sales.netsales, (NSP*sales.netsales)as SalesAmount,distributorid ,CustomerName " +
                           " from " +
                           " ( " +
                           " select productid,outletid,isnull(sum(drSalesQty)-sum (crSalesQty),0) as netsales " +
                           " from " +
                           " ( " +
                           " SELECT sd.productid,sm.outletid,sum (qty) as drSalesQty, 0 as crSalesQty " +
                           " FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st " +
                           " WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(2)  " +
                           " and trandate between ? and ?  " +
                           " Group By sd.productid,sm.outletid  " +
                           " union all " +
                           " SELECT sd.productid,sm.outletid,0 as drSalesQty, sum (qty) as crSalesQty " +
                           " FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st  " +
                           " WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(5)   " +
                           " and trandate between ? and ?   " +
                           " Group By sd.productid,sm.outletid " +
                           " ) as asales " +
                           " Group By asales.productid,asales.outletid " +
                           " ) as sales " +
                           " inner join " +
                           " ( " +
                           " select OutletID,OutletCode,OutletName,distributorid,CustomerName from t_DMSOutlet inner join  t_Customer on   t_DMSOutlet.distributorid=t_Customer.CustomerID   where t_DMSOutlet.distributorid= ? and t_DMSOutlet.OutletID=? " +
                           " ) as details on sales.outletid = details.outletid " +
                           " inner join " +
                           " ( " +
                           " select * from v_productdetails where itemcategory= ?" +
                           " ) as pd on sales.productid = pd.productid ";

                    cmd.Parameters.AddWithValue("TranDate", dDFromDate);
                    cmd.Parameters.AddWithValue("TranDate", dDToDate);
                    
                    cmd.Parameters.AddWithValue("TranDate", dDFromDate);
                    cmd.Parameters.AddWithValue("TranDate", dDToDate);
                   
                    cmd.Parameters.AddWithValue("distributorid", ndistributorid);
                    cmd.Parameters.AddWithValue("outletid", nOutletID);
                    cmd.Parameters.AddWithValue("itemcategory", nItemCategory);

                }

              // For Specific smdp and All Outlet


                else
                {
                    sSql = "Select sales.OutletID,OutletCode,OutletName,sales.ProductID,ProductCode,ProductName,ASGID,ASGName, BrandID,BrandDesc, sales.netsales,(NSP*sales.netsales)as SalesAmount,distributorid ,CustomerName " + 
                           " from "+ 
                           " ( "+ 
                           " select productid,outletid,isnull(sum(drSalesQty)-sum (crSalesQty),0) as netsales "+ 
                           " from "+ 
                           " ( "+ 
                           " SELECT sd.productid,sm.outletid,sum (qty) as drSalesQty, 0 as crSalesQty "+ 
                           " FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st "+ 
                           " WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(2)  "+ 
                           " and trandate between ? and ?   "+ 
                           " Group By sd.productid,sm.outletid  "+ 
                           " union all "+ 
                           " SELECT sd.productid,sm.outletid,0 as drSalesQty, sum (qty) as crSalesQty "+ 
                           " FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st  "+ 
                           " WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(5)   "+ 
                           " and trandate between ? and ?   "+ 
                           " Group By sd.productid,sm.outletid "+ 
                           " ) as asales "+ 
                           " Group By asales.productid,asales.outletid "+ 
                           " ) as sales "+ 
                           " inner join "+ 
                           " ( "+ 
                           " select OutletID,OutletCode,OutletName,distributorid,CustomerName from t_DMSOutlet inner join  t_Customer on   t_DMSOutlet.distributorid=t_Customer.CustomerID   where t_DMSOutlet.distributorid= ?"+ 
                           " ) as details on sales.outletid = details.outletid "+ 
                           " inner join "+ 
                           " ( "+
                           " select * from v_productdetails where itemcategory=?" + 
                           " ) as pd on sales.productid = pd.productid ";

                    cmd.Parameters.AddWithValue("TranDate", dDFromDate);
                    cmd.Parameters.AddWithValue("TranDate", dDToDate);
                  
                    cmd.Parameters.AddWithValue("TranDate", dDFromDate);
                    cmd.Parameters.AddWithValue("TranDate", dDToDate);
                 
                    cmd.Parameters.AddWithValue("distributorid", ndistributorid);
                    cmd.Parameters.AddWithValue("itemcategory", nItemCategory);
                }
            }

            // For All smdp and All Outlet
            else
            {
               
               /*     sSql =  "Select sales.OutletID,OutletCode,OutletName,sales.ProductID,ProductCode,ProductName,sales.netsales,distributorid ,CustomerName "+  
                                      " from  "+ 
                                      " (  "+ 
                                      " select  productid,outletid,isnull(sum(drSalesQty)-sum (crSalesQty),0) as netsales  "+ 
                                      " from "+ 
									  " ( "+ 
                                      " SELECT sd.productid,sm.outletid,sum (qty) as drSalesQty, 0 as crSalesQty  "+  
                                      " FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st "+ 
                                      " WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(2)  "+  
                                      " and trandate between ? and ?  "+ 
                                      " Group By sd.productid,sm.outletid  "+ 
                                      " union all "+ 
                                      " SELECT sd.productid,sm.outletid,0 as drSalesQty, sum (qty) as crSalesQty  "+  
                                      " FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st  "+ 
                                      " WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(5)  "+ 
                                      " and trandate between ? and ?  "+ 
                                      " Group By sd.productid,sm.outletid "+ 
  									  " ) as asales  "+ 
                                      "  group by asales.productid, asales.outletid "+ 
                                      " ) as sales  "+ 
                                      " inner join  "+ 
                                      " (  "+ 
                                      "  select OutletID,OutletCode,OutletName,distributorid,CustomerName from t_DMSOutlet inner join  t_Customer on   t_DMSOutlet.distributorid=t_Customer.CustomerID "+    
                                      " ) as details on sales.outletid = details.outletid  "+ 
                                      " inner join  "+ 
                                      " (  "+ 
                                      " select * from t_product  "+ 
                                      " ) as pd on sales.productid = pd.productid  ";
                */

                sSql = " Select sales.OutletID,OutletCode,OutletName,sales.ProductID,ProductCode,ProductName,ASGID,ASGName, BrandID,BrandDesc, sales.netsales,(NSP*sales.netsales)as SalesAmount, distributorid ,CustomerName,regionname,areaname,territoryname " +

                                        " from    "+
                                        " (  "+  
                                        " select  productid,outletid,isnull(sum(drSalesQty)-sum (crSalesQty),0) as netsales    "+
                                        " from   "+
									    " ("+   
                                        " SELECT sd.productid,sm.outletid,sum (qty) as drSalesQty, 0 as crSalesQty     "+
                                        " FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st   "+
                                        " WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(2)     "+
                                        " and trandate between ? and ?  "+
                                        " Group By sd.productid,sm.outletid    "+
                                        " union all   "+
                                        " SELECT sd.productid,sm.outletid,0 as drSalesQty, sum (qty) as crSalesQty     "+
                                        " FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st    "+
                                        " WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(5)    "+
                                        " and trandate between ? and ?   "+
                                        " Group By sd.productid,sm.outletid   "+
  									    " ) as asales    "+
                                        " group by asales.productid, asales.outletid "+  
                                        " ) as sales    "+
                                        " inner join    "+
                                        " (    "+
                                        " select OutletID,OutletCode,OutletName,distributorid,CustomerName,regionname,areaname,territoryname"+
                                        " from t_DMSOutlet "+
                                        " inner join  v_Customerdetails on   t_DMSOutlet.distributorid=v_Customerdetails.CustomerID      "+
                                        " ) as details on sales.outletid = details.outletid    "+
                                        " inner join    "+
                                        " (    "+
                                        " select * from v_productdetails where itemcategory=?   " +
                                        " ) as pd on sales.productid = pd.productid ";

                    cmd.Parameters.AddWithValue("TranDate", dDFromDate);
                    cmd.Parameters.AddWithValue("TranDate", dDToDate);
                    cmd.Parameters.AddWithValue("TranDate", dDFromDate);
                    cmd.Parameters.AddWithValue("TranDate", dDToDate);
                    cmd.Parameters.AddWithValue("itemcategory", nItemCategory);
                
              
            }
          
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rptSales orptSales = new rptSales();

                    if (Convert.ToInt32(reader["netsales"].ToString()) != 0)
                    {
                        orptSales.OutletID = (int)reader["OutletID"];
                        orptSales.DistributorID = (int)reader["DistributorID"];
                        orptSales.CustomerName = (string)reader["CustomerName"];
                        if (ndistributorid == -1)
                        {
                            orptSales.RegionName = (string)reader["regionname"];
                            orptSales.AreaName = (string)reader["areaname"];
                            orptSales.TerritoryName = (string)reader["territoryname"];
                        }
                        orptSales.OutletCode = (int)reader["OutletCode"];
                        orptSales.OutletName = (string)reader["OutletName"];
                        orptSales.ProductCode = (string)reader["productcode"];
                        orptSales.ProductName = (string)reader["productname"];
                        orptSales.Qty = (int)(reader["netsales"]);
                        if (orptSales.OutletName == "MAKKA TELECOM")
                        {
                        }
                        orptSales.TotalQty = orptSales.TotalQty + orptSales.Qty;
                        orptSales.ASGID = (int)reader["ASGID"];
                        orptSales.ASGName = (string)reader["ASGName"];
                        orptSales.BrandID = (int)reader["BrandID"];
                        orptSales.BrandDesc = (string)reader["BrandDesc"];
                        orptSales.SalesAmount = (double)reader["SalesAmount"];
                        InnerList.Add(orptSales);
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

        // For all smdp net sales
        public void SummaryReport(DateTime dDFromDate, DateTime dDToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
           
            sSql = " select  CustomerCode,CustomerName,Sales.netsales "+
                     " from "+                     
                     " ( "+
                     " Select distributorid,isnull(sum(drSalesQty)-sum (crSalesQty),0) as netsales "+
                     " from   "+
                     " (   "+
                     " SELECT sm.distributorid,sum (qty) as drSalesQty, 0 as crSalesQty "+
                     " FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st "+  
                     " WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(2) "+   
                     " and trandate between ? and ? "+  
                     " Group By sm.distributorid   "+
                     " union all "+
					 " SELECT sm.distributorid,0 as drSalesQty, sum (qty) as crSalesQty "+
                     " FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st "+  
                     " WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(5) "+   
                     " and trandate between ? and ?  "+ 
                     " Group By sm.distributorid   "+
                     " ) as asales  "+
                     " group by asales.distributorid  "+
                     " ) as Sales "+
                     " inner join  "+ 
                     " (   "+
                     " select CustomerName,CustomerID,CustomerCode from t_Customer  "+
                     " ) as details on sales.distributorid = details.CustomerID "; 

            cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            cmd.Parameters.AddWithValue("TranDate", dDToDate);
            cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            cmd.Parameters.AddWithValue("TranDate", dDToDate); 

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptSales orptSales = new rptSales();                 
   
                    orptSales.CustomerCode = (string)reader["CustomerCode"];
                    orptSales.CustomerName = (string)reader["CustomerName"];
                    orptSales.Qty = Convert.ToInt32(reader["netsales"].ToString());                       
                    InnerList.Add(orptSales);
                    
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // For all SMDP Sku wise net sales
        public void SaleSummarySMDP(DateTime dDFromDate, DateTime dDToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "Select sales.distributorid,ProductCode,ProductName,CustomerCode,CustomerName,sales.netsales "+  
                   " from  "+ 
                   " (    "+ 
                   " select asales.distributorid,asales.productid,isnull(sum(Drqty)-sum(Crqty),0) as netsales "+ 
                   " from "+ 
                   " ( "+ 
                   " SELECT sd.productid,sm.distributorid,sum(sd.qty) as Drqty,0 as Crqty "+ 
                   " FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st   "+    
                   " WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(2) "+      
                   " and trandate between ? and ? "+ 
                   " Group By sd.productid, sm.distributorid     "+ 
                   " union all "+ 
                   " SELECT sd.productid,sm.distributorid,0 as Drqty, sum(sd.qty) as Crqty "+ 
                   " FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st    "+   
                   " WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(5)  "+     
                   " and trandate between ? and ? "+ 
                   " Group By sd.productid, sm.distributorid  "+ 
                   " ) as asales "+ 
                   " group by asales.distributorid,asales.productid "+ 
                   " ) as sales   "+ 
                   " inner join   "+ 
                   " (   "+ 
                   " select CustomerName,CustomerID,CustomerCode from t_Customer  "+  
                   " ) as details on sales.distributorid = details.CustomerID  "+ 
                   " inner join   "+ 
                   " (   "+
                   " select * from t_product where itemcategory=1    " + 
                   " ) as pd on sales.productid = pd.productid  ";

            cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            cmd.Parameters.AddWithValue("TranDate", dDToDate);
            cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            cmd.Parameters.AddWithValue("TranDate", dDToDate);      

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rptSales orptSales = new rptSales();

                    if (Convert.ToInt32(reader["netsales"].ToString()) != 0)
                    {
                        orptSales.DistributorID = (int)reader["DistributorID"];
                        orptSales.CustomerName = (string)reader["CustomerName"];                  
                        orptSales.ProductCode = (string)reader["productcode"];
                        orptSales.ProductName = (string)reader["productname"];
                        orptSales.Qty = int.Parse(reader["netsales"].ToString());                        
                        InnerList.Add(orptSales);
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
        public void SaleSummarySKU(DateTime dDFromDate, DateTime dDToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = @"Select ProductCode,ProductName,sales.netsales 
                    from  
                    (    
                    select productid,isnull(sum(Drqty)-sum(Crqty),0) as netsales 
                    from 
                    ( 
                    SELECT sd.productid,sum(sd.qty) as Drqty,0 as Crqty 
                    FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st   
                    WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(2) 
                    and trandate between ? and ? 
                    Group By sd.productid    
                    union all 
                    SELECT sd.productid,0 as Drqty, sum(sd.qty) as Crqty 
                    FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st    
                    WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(5)  
                    and trandate between ? and ? 
                    Group By sd.productid 
                    ) as asales 
                    group by asales.productid 
                    ) as sales   
                    inner join   
		            (
                    select * from t_product where itemcategory=1   
                    ) as pd on sales.productid = pd.productid";

            cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            cmd.Parameters.AddWithValue("TranDate", dDToDate);
            cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            cmd.Parameters.AddWithValue("TranDate", dDToDate);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rptSales orptSales = new rptSales();

                    if (Convert.ToInt32(reader["netsales"].ToString()) != 0)
                    {
                       
                        orptSales.ProductCode = (string)reader["productcode"];
                        orptSales.ProductName = (string)reader["productname"];
                        orptSales.Qty = int.Parse(reader["netsales"].ToString());
                        orptSales.DistributorID = 0;
                        InnerList.Add(orptSales);
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

        // For selection wise net sales
        public void SaleSummaryBy(DateTime dDFromDate, DateTime dDToDate, int nItemCategory)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = @"    Select sales.ProductID,ProductCode,ProductName,sales.netsales,distributorid ,customercode,CustomerName,regionname,areaname,territoryname,sales.OutletID,OutletCode,outletname  
                             from  
                             (  
                             select productid,outletid,isnull(sum(drSalesQty)-sum (crSalesQty),0) as netsales  
                             from  
                             (  
                             SELECT sd.productid,sm.outletid,sum (qty) as drSalesQty, 0 as crSalesQty  
                             FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st  
                             WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(2)   
                             and trandate between ? and ?
                             Group By sd.productid,sm.outletid   
                             union all  
                             SELECT sd.productid,sm.outletid,0 as drSalesQty, sum (qty) as crSalesQty  
                             FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st   
                             WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(5)    
                             and trandate between ? and ?  
                             Group By sd.productid,sm.outletid  
                             ) as asales  
                             Group By asales.productid,asales.outletid  
                             ) as sales  
                             inner join  
                             (  
                             select regionname,areaname,territoryname,OutletID,OutletCode,OutletName,distributorid,customercode,CustomerName from t_DMSOutlet 
                              inner join  v_customerdetails on  
							 t_DMSOutlet.distributorid=v_customerdetails.CustomerID  
							
                             ) as details on sales.outletid = details.outletid  
                             inner join  
                             (  
                             select * from t_product where itemcategory=?
                             ) as pd on sales.productid = pd.productid ";

            cmd.Parameters.AddWithValue("TranDate", dDFromDate);         
            cmd.Parameters.AddWithValue("TranDate", dDToDate);
            cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            cmd.Parameters.AddWithValue("TranDate", dDToDate);
            cmd.Parameters.AddWithValue("itemcategory", nItemCategory);
           
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rptSales orptSales = new rptSales();

                    if (Convert.ToInt32(reader["netsales"].ToString()) != 0)
                    {
                        orptSales.OutletID = (int)reader["OutletID"];
                        orptSales.OutletCode = (int)reader["OutletCode"] ;
                        orptSales.OutletName = reader["OutletName"].ToString();
                        orptSales.RegionName = reader["regionname"].ToString();
                        orptSales.AreaName = reader["areaname"].ToString();
                        orptSales.TerritoryName = reader["territoryname"].ToString();
                        orptSales.CustomerCode = reader["CustomerCode"].ToString();
                        orptSales.CustomerName = reader["CustomerName"].ToString();
                        orptSales.DistributorID = int.Parse(reader["DistributorID"].ToString());
                        orptSales.ProductCode = reader["productcode"].ToString();
                        orptSales.ProductName = reader["productname"].ToString();
                        orptSales.Qty = (int)(reader["netsales"]);
                        orptSales.TotalQty = 0;

                        orptSales.ProductID = (int)reader["ProductID"];

                        orptSales.DSRID = 0;
                        orptSales.DSRName = "";
                        orptSales.RouteID = 0;
                        orptSales.RouteName = "";

                        InnerList.Add(orptSales);
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
        public void SaleSummaryBLL(int nUserID,DateTime dDFromDate, DateTime dDToDate, int nAreaID, int nTerritoryID, int nCustomerID, int nASGID, int nBrandID, int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            //sSql = @"   Select sales.ProductID,pd.ProductCode,pd.ProductName,bd.brandid,bd.branddesc,bd.asgid,bd.asgname,sales.netsalesQty,(NSP*sales.netsalesQty)as SalesAmount,distributorid ,customerid,customercode,CustomerName,areaid,areaname,territoryid,territoryname,sales.OutletID,OutletCode,outletname  " +
            //          " from " + 
            //            "     ( " +
            //                " select productid,outletid,isnull(sum(drSalesQty)-sum (crSalesQty),0) as netsalesQty " +  
            //                " from " + 
            //                " (  " + 
            //                " SELECT sd.productid,sm.outletid,sum (qty) as drSalesQty, 0 as crSalesQty  " +
            //                " FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st " + 
            //                " WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(2) " +  
            //                " and trandate between '" + dDFromDate + "' and '" + dDToDate + "' " +
            //                " Group By sd.productid,sm.outletid   " +
            //                " union all " + 
            //                " SELECT sd.productid,sm.outletid,0 as drSalesQty, sum (qty) as crSalesQty " + 
            //                " FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st  " + 
            //                " WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(5) " +
            //                " and trandate between '" + dDFromDate + "' and '" + dDToDate + "' " +
            //                " Group By sd.productid,sm.outletid " + 
            //                " ) as asales  " +
            //                " Group By asales.productid,asales.outletid  " + 
            //                " ) as sales  " +
            //                " inner join " + 
            //                " ( " + 
            //                " select areaid,areaname,territoryid,territoryname,OutletID,OutletCode,OutletName,distributorid,customerid,customercode,CustomerName from t_DMSOutlet " +
            //                "  inner join  v_customerdetails on  " +
            //                " t_DMSOutlet.distributorid=v_customerdetails.CustomerID " + 
							
            //                " ) as details on sales.outletid = details.outletid  " + 
            //                " inner join  " + 
            //                "( " + 
            //                "select * from t_product " +
            //                ") as pd on sales.productid = pd.productid " +
            //                "inner join " +
            //                "( " +
            //                "select * from v_productdetails " +
                             
                             
            //                 ")as bd on bd.productid= pd.productid ";

            sSql = @"   select AreaName,AreaID,TerritoryID,TerritoryName,CustomerCode,CustomerName, Final.ProductID,ProductCode,ProductName,ASGID,ASGName,BrandID,
                        BrandDesc,NSP,SalesQty, (NSP*SalesQty)as SalesAmount " +
                        " from " +
                        " ( " +
                        " select isnull(Q1.DistributorID,Q2.CustomerID)as DistributorID, isnull(Q1.ProductID,Q2.ProductID)as ProductID, " +
                        " isnull(SalesQty,0)as SalesQty, isnull (TPQty,0)as TPQty " +
                        " from " +
                        " ( " +
                        " select a.DistributorID,ProductID, sum(Qty)as SalesQty " +
                        " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b " +
                        " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + dDFromDate + "' and '" + dDToDate + "' and Trandate < '" + dDToDate + "' " +
                        " group by a.DistributorID,ProductID " +
                        " )as Q1 " +
                        " full outer join " +
                        " ( " +
                        " select CustomerID,ProductID, sum(Qty)as TPQty " +
                        " from BLLSysDB.dbo.t_DMSTPTranItem a " +
                        " where ProductID not in (2647,2676) " +
                        " and Trandate between '" + dDFromDate + "' and '" + dDToDate + "' and Trandate < '" + dDToDate + "' " +
                        " group by CustomerID,ProductID " +
                        " )as Q2 on Q1.DistributorID=Q2.CustomerID and Q1.ProductID=Q2.ProductID " +
                        " )as Final " +
                        " inner join " +
                        " ( " +
                        " select CustomerId,CustomerCode,CustomerName,AreaName,AreaID,TerritoryID,TerritoryName from v_CustomerDetails " +
                        " )as Cust on Final.DistributorID=cust.CustomerId " +
                        " inner join " +
                        " ( " +
                        " select ProductID,ProductCode,ProductName,ASGName,ASGID,BrandID,BrandDesc,NSP from v_ProductDetails " +
                        " )as Prod on Final.ProductID=Prod.ProductID " ;


            if (nCustomerID > -1)
            {
                sSql = sSql + " where CustomerId= '" + nCustomerID + "'";

            }
            else
            {
                sSql = sSql + " where customerid IN (select CustomerID from v_CustomerDetails a,t_UserPermissionData b "
                           + "  where b.DataID=a.CustomerID and b.UserID= '" + nUserID + "' and Isactive=1 )";
                cmd.Parameters.AddWithValue("UserID", nUserID);

            }
            if (nAreaID != -1)
            {
                sSql = sSql + " and AreaId = " + nAreaID + "";

            }
            if (nTerritoryID != -1)
            {
                sSql = sSql + " and TerritoryId = " + nTerritoryID + "";

            }
         
            if (nASGID != -1)
            {
                sSql = sSql + " and ASGID = '" + nASGID + "'";

            }
            if (nBrandID != -1)
            {
                sSql = sSql + " and BrandID = '" + nBrandID + "'";

            }
            if (nProductID != -1)
            {
                sSql = sSql + " and Final.ProductID = '" + nProductID + "'";

            }

            sSql = sSql + " order by ProductCode ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rptSales orptSales = new rptSales();

                    if (Convert.ToInt32(reader["SalesQty"].ToString()) != 0)
                    {
                        orptSales.ProductID = (int)reader["ProductID"];
                        orptSales.ProductCode = reader["productcode"].ToString();
                        orptSales.ProductName = reader["productname"].ToString();
                        orptSales.BrandID = (int)reader["BrandID"];
                        orptSales.BrandDesc = reader["BrandDesc"].ToString();
                        orptSales.ASGID = (int)reader["ASGID"];
                        orptSales.ASGName = reader["ASGName"].ToString();
                        orptSales.Qty = (int)(reader["SalesQty"]);
                        orptSales.SalesAmount = (double)reader["SalesAmount"];
                        //orptSales.DistributorID = int.Parse(reader["DistributorID"].ToString());
                        //orptSales.DSRID = (int)reader["customerid"];
                        orptSales.CustomerCode = reader["CustomerCode"].ToString();
                        orptSales.CustomerName = reader["CustomerName"].ToString();
                        orptSales.AreaID = (int)reader["AreaID"];
                        orptSales.AreaName = reader["areaname"].ToString();
                        orptSales.TerritoryID = (int)reader["TerritoryID"];
                        orptSales.TerritoryName = reader["territoryname"].ToString();
                        //orptSales.OutletID = (int)reader["OutletID"];
                        //orptSales.OutletCode =Convert.ToInt32(reader["OutletCode"]);
                        //orptSales.OutletName =Convert.ToString(reader["OutletName"].ToString());


                        InnerList.Add(orptSales);
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
        /* public void SaleSummaryBy(DateTime dDFromDate, DateTime dDToDate, int DSRID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = @"    Select sales.ProductID,ProductCode,ProductName,sales.netsales,distributorid ,customercode,CustomerName,
                         regionname,areaname,territoryname,sales.OutletID,OutletCode,outletname,dsrid,dsrname,routeid,routename
                         from  
                         (  
                         select productid,outletid,isnull(sum(drSalesQty)-sum (crSalesQty),0) as netsales  
                         from  
                         (  
                         SELECT sd.productid,sm.outletid,sum (qty) as drSalesQty, 0 as crSalesQty  
                         FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st  
                         WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(2)   
                         and trandate between ? and ?
                         Group By sd.productid,sm.outletid   
                         union all  
                         SELECT sd.productid,sm.outletid,0 as drSalesQty, sum (qty) as crSalesQty  
                         FROM t_DMSproductTran sm, t_DMSproductTranItem sd, t_DMSProductTranType st   
                         WHERE sd.tranid  = sm.tranid and sm.trantypeid=st.trantypeid and st.trantypeid in(5)    
                         and trandate between ? and ?
                         Group By sd.productid,sm.outletid  
                         ) as asales  
                         Group By asales.productid,asales.outletid  
                         ) as sales  
                         inner join  
                         (  

                         select regionname,areaname,territoryname,marketid,routeid,routename,dsrid,dsrname,OutletID,OutletCode,OutletName,
                         distributorid,customercode,CustomerName
                         from
                         (
                        select a.distributorid,outletid,outletcode,outletname,a.routeid,routename,b.dsrid,dsrcode,dsrname,marketid
                        from t_DMSOutlet a, t_dmsjourneyplan b, t_dmsdsr c, t_dmsroute d
                        where a.routeid=b.routeid and a.distributorid=b.distributorid and c.distributorid=b.distributorid and c.dsrid=b.dsrid
                        and d.routeid= a.routeid and d.distributorid=b.distributorid
                        group by a.distributorid,outletid,outletcode,outletname,a.routeid,routename,b.dsrid,dsrcode,dsrname,marketid
                        ) as jp
                         inner join  v_customerdetails on  
                        jp.distributorid=v_customerdetails.CustomerID  
                        WHERE dsrid=? 							
                         ) as details on sales.outletid = details.outletid  
                         inner join  
                         (  
                         select * from t_product  
                         ) as pd on sales.productid = pd.productid ";

            cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            cmd.Parameters.AddWithValue("TranDate", dDToDate);
            cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            cmd.Parameters.AddWithValue("TranDate", dDToDate);
            cmd.Parameters.AddWithValue("DSRID", DSRID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    rptSales orptSales = new rptSales();

                    if (Convert.ToInt32(reader["netsales"].ToString()) != 0)
                    {
                        orptSales.RegionName = reader["regionname"].ToString();
                        orptSales.AreaName = reader["areaname"].ToString();
                        orptSales.TerritoryName = reader["territoryname"].ToString();
                        orptSales.DistributorID = int.Parse(reader["DistributorID"].ToString());
                        orptSales.CustomerCode = reader["CustomerCode"].ToString();
                        orptSales.CustomerName = reader["CustomerName"].ToString();
                        orptSales.OutletID = (int)reader["OutletID"];
                        orptSales.OutletCode = (int)reader["OutletCode"];
                        orptSales.OutletName = reader["OutletName"].ToString();
                        orptSales.DSRID = (int) reader ["DSRID"];
                        orptSales.DSRName = reader ["DSRName"].ToString();
                        orptSales.RouteID = (int) reader ["RouteID"];
                        orptSales.RouteName = reader ["RouteName"].ToString();
                        orptSales.ProductID = (int) reader ["ProductID"];
                        orptSales.ProductCode = reader["productcode"].ToString();
                        orptSales.ProductName = reader["productname"].ToString();
                        orptSales.Qty = (int)(reader["netsales"]);
                        orptSales.TotalQty = 0;
                        
                        InnerList.Add(orptSales);
                    }
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        } */
        public void FromDataSetForSalesReport(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {

                    rptSales orptSales = new rptSales();

                    if (Convert.ToInt32(oRow["Qty"].ToString()) != 0)
                    {
                        orptSales.OutletID = (int)oRow["OutletID"];
                        orptSales.OutletCode = (int)oRow["OutletCode"];
                        orptSales.OutletName = (string)oRow["OutletName"];                    
                        orptSales.RegionName = (string)oRow["RegionName"];
                        orptSales.AreaName = (string)oRow["AreaName"];
                        orptSales.TerritoryName = (string)oRow["territoryname"];
                        orptSales.DistributorID = (int)oRow["DistributorID"];
                        orptSales.CustomerCode = (string)oRow["CustomerCode"];
                        orptSales.CustomerName = (string)oRow["CustomerName"];
                        orptSales.ProductCode = (string)oRow["ProductCode"];
                        orptSales.ProductName = (string)oRow["ProductName"];
                        //orptSales.DSRID = (int) oRow ["DSRID"];
                        //orptSales.RouteID = (int) oRow ["RouteID"];
                        //orptSales.DSRName = (string) oRow ["DSRName"];
                        //orptSales.RouteName = (string)oRow["RouteName"];
                        orptSales.Qty = int.Parse(oRow["Qty"].ToString());
                        orptSales.TotalQty = orptSales.TotalQty + orptSales.Qty;
                        InnerList.Add(orptSales);
                    }
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

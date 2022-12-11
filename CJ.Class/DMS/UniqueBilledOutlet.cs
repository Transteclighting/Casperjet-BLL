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
    public class UniqueBilledOutlet
    {

          
        private string _sRegionName;
        private string _sAreaName;
        private string _sTerritoryName;
        private int _nDistributorID;
        private string _sCustomerCode;
        private string _sCustomerName;
        private string _sProductModel;
        private int _nBilledOutlet;
        private int _nUniqueBilled;



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
        public int DistributorID
        {
            get { return _nDistributorID; }
            set { _nDistributorID = value; }
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

        public string ProductModel
        {
            get { return _sProductModel; }
            set { _sProductModel = value; }
        }

        public int BilledOutlet
        {
            get { return _nBilledOutlet; }
            set { _nBilledOutlet = value; }
        }

        public int UniqueBilled
        {
            get { return _nUniqueBilled; }
            set { _nUniqueBilled = value; }
        }

    }

    public class uniqueBilledOutlets : CollectionBaseCustom
    {
        public void Add(UniqueBilledOutlet oUniqueBilledOutlet)
        {
            this.List.Add(oUniqueBilledOutlet);
        }

        public UniqueBilledOutlet this[Int32 Index]
        {
            get
            {
                return (UniqueBilledOutlet)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(UniqueBilledOutlet))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }
        public void UniqueBilledOutletBy(DateTime dDFromDate, DateTime dDToDate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";


            // Query for product wise unique billed outlet
            //if (ndistributorid != -1)
            //{
            //    if (sProductModel != "all")
            //    {
            //sSql = " select distributorid,regionname,areaname,territoryname,customercode,customername,productmodel,BilledOutlet,OutletBilledUnique " +
            //                " from " +
            //                " (" +
            //                " select distributorid,productmodel,BilledOutlet,OutletBilledUnique " +
            //                " from " +
            //                " ( " +
            //                " select distributorid,productmodel,count (outletid)as BilledOutlet,count(distinct(outletid)) as OutletBilledUnique " +
            //                " from " +
            //                " ( " +
            //                " select sales.distributorid,sales.productid,sales.outletid,isnull(sum(drSalesQty)-sum (crSalesQty),0) as netsales " +
            //                " from " +
            //                " ( " +
            //                " select a.distributorid,a.outletid,b.productid, sum (qty) as drSalesQty, 0 as crSalesQty  from t_dmsproducttran a, t_dmsproducttranitem b " +
            //                " where a.tranid=b.tranid and trantypeid=2 and trandate between ? and ? " +
            //                " group by a.distributorid,b.productid,a.outletid " +
            //                " union all " +
            //                " select a.distributorid,a.outletid,b.productid, 0 as drSalesQty, sum (qty) as crSalesQty from t_dmsproducttran a, t_dmsproducttranitem b " +
            //                " where a.tranid=b.tranid and trantypeid=5 and trandate between ? and ? " +
            //                " group by a.distributorid,a.outletid,b.productid " +
            //                " ) as sales " +
            //                " group by sales.distributorid,sales.productid,sales.outletid " +
            //                " ) as Billed " +
            //                " left outer join " +
            //                " v_productdetails pd on pd.productid= Billed.productid " +
            //                " Group by distributorid,productmodel " +
            //                " ) as uniqeoutlet " +
            //                " group by distributorid,productmodel,BilledOutlet,OutletBilledUnique " +
            //                " ) as Modelwise" +
            //                " left outer join " +
            //                " v_customerdetails cd on cd.customerid= Modelwise.distributorid ";

            // Query for productmodel wise unique billed outlet
            sSql = @" select distributorid,regionname,areaname,territoryname,customercode,customername,productmodel,BilledOutlet,OutletBilledUnique  
                                 from  
                                 ( 
                                 select distributorid,productmodel,BilledOutlet,OutletBilledUnique  
                                 from  
                                 (  
                                 select distributorid,productmodel,count (outletid)as BilledOutlet,count(distinct(outletid)) as OutletBilledUnique  
                                 from  
                                 (
                                select distributorid,productmodel,outletid
                                from 
                                (
                                 select sales.distributorid,sales.productid,sales.outletid,isnull(sum(drSalesQty)-sum (crSalesQty),0) as netsales  
                                 from  
                                 (  
                                 select a.distributorid,a.outletid,b.productid, sum (qty) as drSalesQty, 0 as crSalesQty  from t_dmsproducttran a, t_dmsproducttranitem b  
                                 where a.tranid=b.tranid and trantypeid=2 and trandate between ? and ? 
                                 group by a.distributorid,b.productid,a.outletid  
                                 union all  
                                 select a.distributorid,a.outletid,b.productid, 0 as drSalesQty, sum (qty) as crSalesQty from t_dmsproducttran a, t_dmsproducttranitem b  
                                 where a.tranid=b.tranid and trantypeid=5 and trandate between ? and ?
                                 group by a.distributorid,a.outletid,b.productid  
                                 ) as sales  
                                
                                 group by sales.distributorid,sales.productid,sales.outletid  
                                 ) as Billed  
                                 left outer join  
                                 v_productdetails pd on pd.productid= Billed.productid  
                                 Group by distributorid,productmodel,outletid
                                ) as modelwiseoutlet
                                 Group by distributorid,productmodel  
                                 ) as uniqeoutlet  
                                 group by distributorid,productmodel,BilledOutlet,OutletBilledUnique  
                                 ) as Modelwise 
                                 left outer join  
                                 v_customerdetails cd on cd.customerid= Modelwise.distributorid ";


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
                            UniqueBilledOutlet oUniqueBilledOutlet = new UniqueBilledOutlet();
                            


                                oUniqueBilledOutlet.RegionName = reader["regionname"].ToString();
                                oUniqueBilledOutlet.AreaName = reader["areaname"].ToString();
                                oUniqueBilledOutlet.TerritoryName = reader["territoryname"].ToString();
                                oUniqueBilledOutlet.DistributorID = (int) (reader ["DistributorID"]);
                                oUniqueBilledOutlet.CustomerCode = reader["CustomerCode"].ToString();
                                oUniqueBilledOutlet.CustomerName = reader["CustomerName"].ToString();
                                oUniqueBilledOutlet.ProductModel = reader["productModel"].ToString();
                                oUniqueBilledOutlet.BilledOutlet = (int)(reader["BilledOutlet"]);
                                oUniqueBilledOutlet.UniqueBilled = (int)(reader["OutletBilledUnique"]);
 

                                InnerList.Add(oUniqueBilledOutlet);
                            }

                        reader.Close();
                        InnerList.TrimToSize();

                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                    //cmd.Parameters.AddWithValue("distributorid", ndistributorid);
                    //cmd.Parameters.AddWithValue("productmodel", sProductModel);
            //    }


            //    // For Selected SMDP and All Model

            //    else
            //    {

            //        sSql = " select distributorid,regionname,areaname,territoryname,customercode,customername,productmodel,OutletBilledUnique " +
            //               " from " +
            //               " (" +
            //               " select distributorid,productmodel,OutletBilledUnique " +
            //               " from " +
            //               " ( " +
            //               " select distributorid,productmodel,count(distinct(outletid)) as OutletBilledUnique " +
            //               " from " +
            //               " ( " +
            //               " select sales.distributorid,sales.productid,sales.outletid,isnull(sum(drSalesQty)-sum (crSalesQty),0) as netsales " +
            //               " from " +
            //               " ( " +
            //               " select a.distributorid,a.outletid,b.productid, sum (qty) as drSalesQty, 0 as crSalesQty  from t_dmsproducttran a, t_dmsproducttranitem b " +
            //               " where a.tranid=b.tranid and trantypeid=2 and trandate between ? and ? " +
            //               " group by a.distributorid,b.productid,a.outletid " +
            //               " union all " +
            //               " select a.distributorid,a.outletid,b.productid, 0 as drSalesQty, sum (qty) as crSalesQty from t_dmsproducttran a, t_dmsproducttranitem b " +
            //               " where a.tranid=b.tranid and trantypeid=5 and trandate between ? and ? " +
            //               " group by a.distributorid,a.outletid,b.productid " +
            //               " ) as sales " +
            //               " group by sales.distributorid,sales.productid,sales.outletid " +
            //               " ) as Billed " +
            //               " left outer join " +
            //               " tmlsysdb.dbo.v_productdetails pd on pd.productid= Billed.productid " +
            //               " Group by distributorid,productmodel " +
            //               " ) as uniqeoutlet " +
            //               " group by distributorid,productmodel,OutletBilledUnique " +
            //               " ) as Modelwise" +
            //               " left outer join " +
            //               " tmlsysdb.dbo.v_customerdetails cd on cd.customerid= Modelwise.distributorid " +
            //               " where distributorid = ? " +
            //               " group by distributorid,regionname,areaname,territoryname,customercode,customername,productmodel,OutletBilledUnique ";

            //        cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            //        cmd.Parameters.AddWithValue("TranDate", dDToDate);
            //        cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            //        cmd.Parameters.AddWithValue("TranDate", dDToDate);
            //        cmd.Parameters.AddWithValue("distributorid", ndistributorid);
            //    }
            //}

            //else
            //{
            //    if (sProductModel !="All")
            //    {

            //    // for ALL SMDP and selected Model

            //    sSql = " select distributorid,regionname,areaname,territoryname,customercode,customername,productmodel,OutletBilledUnique " +
            //           " from " +
            //           " (" +
            //           " select distributorid,productmodel,OutletBilledUnique " +
            //           " from " +
            //           " ( " +
            //           " select distributorid,productmodel,count(distinct(outletid)) as OutletBilledUnique " +
            //           " from " +
            //           " ( " +
            //           " select sales.distributorid,sales.productid,sales.outletid,isnull(sum(drSalesQty)-sum (crSalesQty),0) as netsales " +
            //           " from " +
            //           " ( " +
            //           " select a.distributorid,a.outletid,b.productid, sum (qty) as drSalesQty, 0 as crSalesQty  from t_dmsproducttran a, t_dmsproducttranitem b " +
            //           " where a.tranid=b.tranid and trantypeid=2 and trandate between ? and ? " +
            //           " group by a.distributorid,b.productid,a.outletid " +
            //           " union all " +
            //           " select a.distributorid,a.outletid,b.productid, 0 as drSalesQty, sum (qty) as crSalesQty from t_dmsproducttran a, t_dmsproducttranitem b " +
            //           " where a.tranid=b.tranid and trantypeid=5 and trandate between ? and ? " +
            //           " group by a.distributorid,a.outletid,b.productid " +
            //           " ) as sales " +
            //           " group by sales.distributorid,sales.productid,sales.outletid " +
            //           " ) as Billed " +
            //           " left outer join " +
            //           " tmlsysdb.dbo.v_productdetails pd on pd.productid= Billed.productid " +
            //           " Group by distributorid,productmodel " +
            //           " ) as uniqeoutlet " +
            //           " group by distributorid,productmodel,OutletBilledUnique " +
            //           " ) as Modelwise" +
            //           " left outer join " +
            //           " tmlsysdb.dbo.v_customerdetails cd on cd.customerid= Modelwise.distributorid " +
            //           " where productmodel= ? " +
            //           " group by distributorid,regionname,areaname,territoryname,customercode,customername,productmodel,OutletBilledUnique ";

            //    cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            //    cmd.Parameters.AddWithValue("TranDate", dDToDate);
            //    cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            //    cmd.Parameters.AddWithValue("TranDate", dDToDate);
            //    cmd.Parameters.AddWithValue("productmodel", sProductModel);

            //    }
            //    else 
            //    {

            // // for ALL SMDP and ALL Model

            //    sSql = " select distributorid,regionname,areaname,territoryname,customercode,customername,productmodel,OutletBilledUnique " +
            //           " from " +
            //           " (" +
            //           " select distributorid,productmodel,OutletBilledUnique " +
            //           " from " +
            //           " ( " +
            //           " select distributorid,productmodel,count(distinct(outletid)) as OutletBilledUnique " +
            //           " from " +
            //           " ( " +
            //           " select sales.distributorid,sales.productid,sales.outletid,isnull(sum(drSalesQty)-sum (crSalesQty),0) as netsales " +
            //           " from " +
            //           " ( " +
            //           " select a.distributorid,a.outletid,b.productid, sum (qty) as drSalesQty, 0 as crSalesQty  from t_dmsproducttran a, t_dmsproducttranitem b " +
            //           " where a.tranid=b.tranid and trantypeid=2 and trandate between ? and ? " +
            //           " group by a.distributorid,b.productid,a.outletid " +
            //           " union all " +
            //           " select a.distributorid,a.outletid,b.productid, 0 as drSalesQty, sum (qty) as crSalesQty from t_dmsproducttran a, t_dmsproducttranitem b " +
            //           " where a.tranid=b.tranid and trantypeid=5 and trandate between ? and ? " +
            //           " group by a.distributorid,a.outletid,b.productid " +
            //           " ) as sales " +
            //           " group by sales.distributorid,sales.productid,sales.outletid " +
            //           " ) as Billed " +
            //           " left outer join " +
            //           " tmlsysdb.dbo.v_productdetails pd on pd.productid= Billed.productid " +
            //           " Group by distributorid,productmodel " +
            //           " ) as uniqeoutlet " +
            //           " group by distributorid,productmodel,OutletBilledUnique " +
            //           " ) as Modelwise" +
            //           " left outer join " +
            //           " tmlsysdb.dbo.v_customerdetails cd on cd.customerid= Modelwise.distributorid " +
            //           " group by distributorid,regionname,areaname,territoryname,customercode,customername,productmodel,OutletBilledUnique ";

            //    cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            //    cmd.Parameters.AddWithValue("TranDate", dDToDate);
            //    cmd.Parameters.AddWithValue("TranDate", dDFromDate);
            //    cmd.Parameters.AddWithValue("TranDate", dDToDate);

            //    }

            //}

        }

        public void FromDataSetForUniqueBilledOutlet(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    UniqueBilledOutlet _oUniqueBilledOutlet = new UniqueBilledOutlet();

                    _oUniqueBilledOutlet.RegionName = (string) oRow["RegionName"];
                    _oUniqueBilledOutlet.AreaName = (string)oRow["AreaName"];
                    _oUniqueBilledOutlet.TerritoryName = (string)oRow["territoryname"];
                    _oUniqueBilledOutlet.CustomerCode = (string) oRow["CustomerCode"];
                    _oUniqueBilledOutlet.CustomerName = (string)oRow["CustomerName"];
                    _oUniqueBilledOutlet.ProductModel = (string) oRow["ProductModel"];
                    _oUniqueBilledOutlet.DistributorID = int.Parse(oRow["Distributorid"].ToString());
                    _oUniqueBilledOutlet.BilledOutlet = int.Parse(oRow["BilledOutlet"].ToString());
                    _oUniqueBilledOutlet.UniqueBilled = int.Parse(oRow["UniqueBilled"].ToString());
                    InnerList.Add (_oUniqueBilledOutlet);

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

// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak k. Chakraborty
// Date: May 06, 2013
// Time" :  03:00 PM
// Descriptio: Product Sales Qty for Transcom Digital ]
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
   public class RptSalesSKUwiseforTD
    {

       private int _nAreaID;        
       private string _sAreaName;
       private int _nTerritoryID;        
       private string _sTerritoryName;
       private int _nCustomerID;
       private string _sOutletcode;

       private long _BrandID;
       private string _sBrand; 
       private long _PGID;      
       private string _sPGName;
       private long _MAGID;       
       private string _sMAGName;
       private long _ASGID;       
       private string _sASGName;
       private long _AGID;      
       private string _sAGName;
       private string _sProductCode;
       private string _sProductName;
       private double _nSoldQty;


       public int AreaID
       {
           get { return _nAreaID; }
           set { _nAreaID = value; }
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
      
       public string TerritoryName
       {
           get { return _sTerritoryName; }
           set { _sTerritoryName = value; }
       }
       public int CustomerID
       {
           get { return _nCustomerID; }
           set { _nCustomerID = value; }
       }

       public string OutletCode
       {
           get { return _sOutletcode; }
           set { _sOutletcode = value; }
       }

       public long BrandID
       {
           get { return _BrandID; }
           set { _BrandID = value; }
       }

       public string Brand
       {
           get { return _sBrand; }
           set { _sBrand = value; }
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

       public long AGID
       {
           get { return _AGID; }
           set { _AGID = value; }
       }
       
       public string AGName
       {
           get { return _sAGName; }
           set { _sAGName = value; }
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

       public double SoldQty
       {
           get { return _nSoldQty; }
           set { _nSoldQty = value; }
       }

    }

    public class RptSalesSKUwiseforTDdetails : CollectionBaseCustom
    {
        public void Add(RptSalesSKUwiseforTD oRptSalesSKUwiseforTD)
        {
            this.List.Add(oRptSalesSKUwiseforTD);
        }

        public RptSalesSKUwiseforTD this[Int32 Index]
        {
            get
            {
                return (RptSalesSKUwiseforTD)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(RptSalesSKUwiseforTD))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void ProductSalesQtyforTD(DateTime dYFromDate, DateTime dYToDate)
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            // Query for report 68.............              

            sQueryStringMaster.Append(" select AreaID,AreaName,TerritoryID,TerritoryName,CustomerID,OutletCode,BrandID,Brand,PGID,PGName,MAGID,MAGName,ASGID,ASGName,AGID,AGName,ProductCode,ProductName,SoldQty ");
            sQueryStringMaster.Append("    from ");
            sQueryStringMaster.Append("    ( ");
            sQueryStringMaster.Append("    select AreaID,AreaName,TerritoryID,TerritoryName,cust.CustomerID CustomerID,sr.code OutletCode,prd.code PCode,sum(quantity) SoldQty ");
            sQueryStringMaster.Append("    from cassiopeia_ho.dbo.invoice inv,cassiopeia_ho.dbo.invoiceitem invitem, ");
            sQueryStringMaster.Append("    cassiopeia_ho.dbo.product prd,cassiopeia_ho.dbo.showroom sr,telsysdb.dbo.v_customerdetails cust ");
            sQueryStringMaster.Append("    where inv.invoiceid=invitem.invoiceid and inv.showroomid=invitem.showroomid and invitem.productid=prd.productid  ");
            sQueryStringMaster.Append("    and inv.showroomid=sr.showroomid and cust.customercode=cast(sr.customerid as varchar(50)) and cust.channelid=4 ");
            sQueryStringMaster.Append("    and isfree=0 and isreverse=0 and inv.showroomid not in(1,55) ");
            sQueryStringMaster.Append("    and inv.trandate between ? and ? and inv.trandate< ? ");
            sQueryStringMaster.Append("    group by AreaID,AreaName,TerritoryID,TerritoryName,cust.CustomerID,sr.code,prd.code ");
            sQueryStringMaster.Append("    ) sl ");
            sQueryStringMaster.Append("    inner join ");
            sQueryStringMaster.Append("    (select ProductCode,ProductName,BrandID,branddesc Brand,PGID,PGName,MAGID,MAGName,ASGID,ASGName,AGID,AGName  ");
            sQueryStringMaster.Append("   from telsysdb.dbo.v_productdetails ");
            sQueryStringMaster.Append("    ) v on sl.PCode=v.ProductCode ");
            sQueryStringMaster.Append("    order by AreaID,AreaName,TerritoryID,TerritoryName,CustomerID,OutletCode,BrandID,Brand,PGID,PGName,MAGID,MAGName,ASGID,ASGName,AGID,AGName,ProductCode,ProductName ");
            
            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();
            
            oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate);
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate.AddDays(1));
            oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate.AddDays(1));            

            GetDataProductSalesQtyforTD(oCmd);
        }

        public void GetDataProductSalesQtyforTD(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptSalesSKUwiseforTD oItem = new RptSalesSKUwiseforTD();

                    
                    if (reader["AreaID"] != DBNull.Value)
                        oItem.AreaID = (int)reader["AreaID"];
                    else oItem.AreaID = -1;                  

                    if (reader["AreaName"] != DBNull.Value)
                        oItem.AreaName = (string)reader["AreaName"];
                    else oItem.AreaName = "";

                    if (reader["TerritoryID"] != DBNull.Value)
                        oItem.TerritoryID = (int)reader["TerritoryID"];
                    else oItem.TerritoryID = -1;
                    
                    if (reader["TerritoryName"] != DBNull.Value)
                        oItem.TerritoryName = (string)reader["TerritoryName"];
                    else oItem.TerritoryName = "";                   

                    if (reader["CustomerID"] != DBNull.Value)
                        oItem.CustomerID = (int)reader["CustomerID"];
                    else oItem.CustomerID = -1;

                    if (reader["OutletCode"] != DBNull.Value)
                        oItem.OutletCode = (string)reader["OutletCode"];
                    else oItem.OutletCode = "";

                    if (reader["BrandID"] != DBNull.Value)
                        oItem.BrandID = (int)reader["BrandID"];
                    else oItem.BrandID = -1;

                    if (reader["Brand"] != DBNull.Value)
                        oItem.Brand = (string)reader["Brand"];
                    else oItem.Brand = "";

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

                    if (reader["AGID"] != DBNull.Value)
                        oItem.AGID = (int)reader["AGID"];
                    else oItem.AGID = -1;
                    
                    if (reader["AGName"] != DBNull.Value)
                        oItem.AGName = (string)reader["AGName"];
                    else oItem.AGName = "";                    

                    if (reader["ProductCode"] != DBNull.Value)
                        oItem.ProductCode = (string)reader["ProductCode"];
                    else oItem.ProductCode = "";

                    if (reader["ProductName"] != DBNull.Value)
                        oItem.ProductName = (string)reader["ProductName"];
                    else oItem.ProductName = "";

                    if (reader["SoldQty"] != DBNull.Value)
                        oItem.SoldQty = Convert.ToInt64(reader["SoldQty"]);
                    else oItem.SoldQty = -1;           
                                     

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

        public void FromDataSetProductSalesQtyforTD(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    RptSalesSKUwiseforTD oRptSalesSKUwiseforTD = new RptSalesSKUwiseforTD();

                    oRptSalesSKUwiseforTD.AreaID = Convert.ToInt32(oRow["AreaID"]);
                    oRptSalesSKUwiseforTD.AreaName = (string)oRow["AreaName"];
                    oRptSalesSKUwiseforTD.TerritoryID = Convert.ToInt32(oRow["TerritoryID"]);
                    oRptSalesSKUwiseforTD.TerritoryName = (string)oRow["TerritoryName"];
                    oRptSalesSKUwiseforTD.CustomerID = Convert.ToInt32(oRow["CustomerID"]);
                    oRptSalesSKUwiseforTD.OutletCode = (string)oRow["OutletCode"];
                    oRptSalesSKUwiseforTD.BrandID = Convert.ToInt32(oRow["BrandID"]);
                    oRptSalesSKUwiseforTD.Brand = (string)oRow["Brand"];                    
                    oRptSalesSKUwiseforTD.PGID = Convert.ToInt32(oRow["PGID"]);
                    oRptSalesSKUwiseforTD.PGName = (string)oRow["PGName"];
                    oRptSalesSKUwiseforTD.MAGID = Convert.ToInt32(oRow["MAGID"]);
                    oRptSalesSKUwiseforTD.MAGName = (string)oRow["MAGName"];
                    oRptSalesSKUwiseforTD.ASGID = Convert.ToInt32(oRow["ASGID"]);
                    oRptSalesSKUwiseforTD.ASGName = (string)oRow["ASGName"];
                    oRptSalesSKUwiseforTD.AGID = Convert.ToInt32(oRow["AGID"]);
                    oRptSalesSKUwiseforTD.AGName = (string)oRow["AGName"];                   
                    oRptSalesSKUwiseforTD.ProductCode = (string)oRow["ProductCode"];
                    oRptSalesSKUwiseforTD.ProductName = (string)oRow["ProductName"];
                    oRptSalesSKUwiseforTD.SoldQty = Convert.ToInt32(oRow["SoldQty"]);
                    InnerList.Add(oRptSalesSKUwiseforTD);
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

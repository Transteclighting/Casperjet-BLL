// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak k. Chakraborty
// Date: May 15, 2013
// Time" :  12:30 PM
// Descriptio: Stock Qty for Transcom Digital ]
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
   public class RptStockSKUwiseforTD
    {

        private int _nAreaID;
        private string _sAreaName;
        private int _nTerritoryID;
        private string _sTerritoryName;       
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
        private double _nStockQty;

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

       public double CurrentStock
        {
            get { return _nStockQty; }
            set { _nStockQty = value; }
        }
    }


    public class RptStockSKUwiseforTDdetails : CollectionBaseCustom
    {
        public void Add(RptStockSKUwiseforTD oRptStockSKUwiseforTD)
        {
            this.List.Add(oRptStockSKUwiseforTD);
        }
        public RptStockSKUwiseforTD this[Int32 Index]
        {
            get
            {
                return (RptStockSKUwiseforTD)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(RptStockSKUwiseforTD))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void ProductStockQtyforTD()
        {

            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            // Query for report 608.............            

                
                sQueryStringMaster.Append("   select AreaID,AreaName,TerritoryID,TerritoryName,OutletCode,BrandID,Brand, ");
                sQueryStringMaster.Append("    PGID,PGName,MAGID,MAGName,ASGID,ASGName,AGID,AGName,ProductCode,ProductName,CurrentStock ");
                sQueryStringMaster.Append("    from ");
                sQueryStringMaster.Append("    ( ");
                sQueryStringMaster.Append("    select AreaID,AreaName,TerritoryID,TerritoryName,tw.warehouseid WarehouseID,sr.code OutletCode,prd.code PCode,sum(soundstock) CurrentStock ");
                sQueryStringMaster.Append("    from cassiopeia_ho.dbo.srstock stk,cassiopeia_ho.dbo.product prd, ");
                sQueryStringMaster.Append("    cassiopeia_ho.dbo.showroom sr,telsysdb.dbo.t_MapTDWareHouse tw,telsysdb.dbo.v_customerdetails vcust ");
                sQueryStringMaster.Append("    where stk.productid=prd.productid and stk.showroomid not in(1,55) and soundstock>0 ");
                sQueryStringMaster.Append("    and cast(sr.warehouseid as varchar(50))=tw.warehousecode and stk.showroomid=sr.showroomid ");
                sQueryStringMaster.Append("    and vcust.customerid=tw.customerid and vcust.channelid=4 ");
                sQueryStringMaster.Append("    group by AreaID,AreaName,TerritoryID,TerritoryName,tw.warehouseid,sr.code,prd.code ");
                sQueryStringMaster.Append("    ) stock ");
                sQueryStringMaster.Append("    inner join ");
                sQueryStringMaster.Append("    (select ProductCode,ProductName,BrandID,branddesc Brand,PGID,PGName,MAGID,MAGName,ASGID,ASGName,AGID,AGName  ");
                sQueryStringMaster.Append("   from telsysdb.dbo.v_productdetails) v ");
                sQueryStringMaster.Append("    on ");
                sQueryStringMaster.Append("    stock.PCode=v.ProductCode ");
            

            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            
            GetDataProductStockQtyforTD(oCmd);
        }

        public void GetDataProductStockQtyforTD(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptStockSKUwiseforTD oItem = new RptStockSKUwiseforTD();


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

                    if (reader["CurrentStock"] != DBNull.Value)
                        oItem.CurrentStock = Convert.ToInt64(reader["CurrentStock"]);
                    else oItem.CurrentStock = -1;


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

        public void FromDataSetProductStockQtyforTD(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    RptStockSKUwiseforTD oRptStockSKUwiseforTD = new RptStockSKUwiseforTD();

                    oRptStockSKUwiseforTD.AreaID = Convert.ToInt32(oRow["AreaID"]);
                    oRptStockSKUwiseforTD.AreaName = (string)oRow["AreaName"];
                    oRptStockSKUwiseforTD.TerritoryID = Convert.ToInt32(oRow["TerritoryID"]);
                    oRptStockSKUwiseforTD.TerritoryName = (string)oRow["TerritoryName"];                    
                    oRptStockSKUwiseforTD.OutletCode = (string)oRow["OutletCode"];
                    oRptStockSKUwiseforTD.BrandID = Convert.ToInt32(oRow["BrandID"]);
                    oRptStockSKUwiseforTD.Brand = (string)oRow["Brand"];
                    oRptStockSKUwiseforTD.PGID = Convert.ToInt32(oRow["PGID"]);
                    oRptStockSKUwiseforTD.PGName = (string)oRow["PGName"];
                    oRptStockSKUwiseforTD.MAGID = Convert.ToInt32(oRow["MAGID"]);
                    oRptStockSKUwiseforTD.MAGName = (string)oRow["MAGName"];
                    oRptStockSKUwiseforTD.ASGID = Convert.ToInt32(oRow["ASGID"]);
                    oRptStockSKUwiseforTD.ASGName = (string)oRow["ASGName"];
                    oRptStockSKUwiseforTD.AGID = Convert.ToInt32(oRow["AGID"]);
                    oRptStockSKUwiseforTD.AGName = (string)oRow["AGName"];
                    oRptStockSKUwiseforTD.ProductCode = (string)oRow["ProductCode"];
                    oRptStockSKUwiseforTD.ProductName = (string)oRow["ProductName"];
                    oRptStockSKUwiseforTD.CurrentStock = Convert.ToInt32(oRow["CurrentStock"]);
                    InnerList.Add(oRptStockSKUwiseforTD);
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

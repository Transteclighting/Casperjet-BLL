// <summary>
// Compamy: Transcom Electronics Limited
// Author: Mithun Sarkar
// Date: Feb 16, 2012
// Time :  3:00 PM
// Description: Class for Stock Casper Cassiopeia
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;

namespace CJ.Class
{
    public class StockCasperCassiopeia
    {

        private string _sWarehouseName;
        private string _sWarehouseCode;
        private string _sASGName;
        private string _sMAGName;
        private string _sBrandName;
        private string _sProductCode;
        private string _sProductName;
        private double _CasperStock;
        private double _CassiopeiaStock;
        private double _StockDifference;

        public string WarehouseName
        {
            get { return _sWarehouseName; }
            set { _sWarehouseName = value; }
        }
        public string WarehouseCode
        {
            get { return _sWarehouseCode; }
            set { _sWarehouseCode = value; }
        }
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }

        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value; }
        }

        public string BrandName
        {
            get { return _sBrandName; }
            set { _sBrandName = value; }
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
        public double CasperStock
        {
            get { return _CasperStock; }
            set { _CasperStock = value; }
        }
        public double CassiopeiaStock
        {
            get { return _CassiopeiaStock; }
            set { _CassiopeiaStock = value; }
        }
        public double StockDifference
        {
            get { return _StockDifference; }
            set { _StockDifference = value; }
        }
    }

    public class StockCasperCassiopeias : CollectionBase
    {
        public StockCasperCassiopeia this[int i]
        {
            get { return (StockCasperCassiopeia)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(StockCasperCassiopeia oStockCasperCassiopeia)
        {
            InnerList.Add(oStockCasperCassiopeia);
        }
        public void GETData(string oShowroom, string oMAG, string oASG, string oBrand)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = @" Select PGName,MAGName,ASGName,AGName,BrandDesc as BrandName,CostPrice,WarehouseID,Stock.WarehouseCode,WarehouseName,ProductID,Stock.ProductCode,ProductName, CasperStock,CassiopeiaStock, (CasperStock-CassiopeiaStock) as Difference
                            from
                            (
                            Select isnull(a.code,b.Productcode) as ProductCode, isnull(a.warehouseid,b.warehousecode) as WarehouseCode, isnull(CurrentStock,0)as CasperStock, isnull(SoundStock,0) as CassiopeiaStock
                            from
                            (
                            Select b.Code,WarehouseID, sum(SoundStock) as SoundStock
                            from cassiopeia_ho.dbo.srstock a, cassiopeia_ho.dbo.product b,cassiopeia_ho.dbo.showroom c
                            where a.productid = b.productid and a.showroomid = c.showroomid and warehouseid <>99
                            group by b.Code,WarehouseID
                            ) as a
                            full outer join
                            (
                            Select Productcode,WarehouseCode,CurrentStock
                            from telsysdb.dbo.t_productstock a, telsysdb.dbo.t_warehouse b,telsysdb.dbo.t_product c
                            where a.channelid = 4 and a.warehouseid not in (70,95,71) and a.warehouseid = b.warehouseid and a.productid = c.productid
                            ) as b on a.code = b.Productcode and a.warehouseid = b.warehousecode
                            ) as stock
                            inner join
                            (
                            select * from v_productdetails
                            ) as p on stock.productcode = p.productcode 
                            inner join
                            (
                            select * from t_warehouse
                            ) as w on stock.warehousecode = w.warehousecode
                            where (CasperStock-CassiopeiaStock) <>0 ";


            if (oShowroom !="ALL")
            {
                sSql = sSql + "AND WarehouseName='" + oShowroom + "'";
            }

            if (oMAG != "ALL")
            {
                sSql = sSql + "AND MAGName='" + oMAG + "'";
            }
            if (oASG != "ALL")
            {
                sSql = sSql + "AND ASGName='" + oASG + "'";
            }
            if (oBrand != "ALL")
            {
                sSql = sSql + "AND BrandDesc='" + oBrand + "'";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StockCasperCassiopeia oStockCasperCassiopeia =new StockCasperCassiopeia();

                    oStockCasperCassiopeia.WarehouseCode = (string)reader["WarehouseCode"].ToString();
                    oStockCasperCassiopeia.WarehouseName = (string)reader["WarehouseName"].ToString();
                    oStockCasperCassiopeia.ProductCode = (string)reader["ProductCode"].ToString();
                    oStockCasperCassiopeia.ProductName = (string)reader["ProductName"].ToString();
                    oStockCasperCassiopeia.ASGName = (string)reader["ASGName"].ToString();
                    oStockCasperCassiopeia.MAGName = (string)reader["MAGName"].ToString(); ;
                    oStockCasperCassiopeia.BrandName = (string)reader["BrandName"].ToString();

                    if (reader["CasperStock"] != DBNull.Value)
                        oStockCasperCassiopeia.CasperStock = Convert.ToDouble(reader["CasperStock"].ToString());
                    else oStockCasperCassiopeia.CasperStock = 0;

                    if (reader["CassiopeiaStock"] != DBNull.Value)
                        oStockCasperCassiopeia.CassiopeiaStock = Convert.ToDouble(reader["CassiopeiaStock"].ToString());
                    else oStockCasperCassiopeia.CassiopeiaStock = 0;

                    if (reader["Difference"] != DBNull.Value)
                        oStockCasperCassiopeia.StockDifference = Convert.ToDouble(reader["Difference"].ToString());
                    else oStockCasperCassiopeia.StockDifference = 0;

                    InnerList.Add(oStockCasperCassiopeia);
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

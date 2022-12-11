// <summary>
// Compamy: Transcom Electronics Limited
// Author: Mithun Sarkar
// Date: Febuary 08, 2012
// Time :  2:10 PM
// Description: Class for Current Stock Position
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Light
{
    [Serializable]
    public class rptCurrentStock
    {
        public string _sWarehouseName;
        public string _sWarehouseCode;
        public string _sASGName;
        public string _sBrandName;
        public string _sProductCode;
        public string _sProductName;
        public double _CurrentStock;
        public double _BookingQty;
        public double _SellableQty;

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
        public double CurrentStock
        {
            get { return _CurrentStock; }
            set { _CurrentStock = value; }
        }
        public double BookingQty
        {
            get { return _BookingQty; }
            set { _BookingQty = value; }
        }
        public double SellableQty
        {
            get { return _SellableQty; }
            set { _SellableQty = value; }
        }

    }

    public class rptCurrentStocks : CollectionBaseCustom
    {
        public void Add(rptCurrentStock oCurrentStock)
        {
            this.List.Add(oCurrentStock);
        
        }     
        public rptCurrentStock this[Int32 Index]
        {
            get
            {
                return (rptCurrentStock)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(rptCurrentStock))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }
        public void TELCurrentStock( string sCompany)
        {
            if (sCompany == "Transcom Electronics Limited")
            {
                OleDbCommand cmd = DBController.Instance.GetCommand();

                StringBuilder sQueryStringMaster;
                sQueryStringMaster = new StringBuilder();

                sQueryStringMaster.Append(" SELECT a.ProductCode, a.ProductName, a.ASGName, a.BrandDesc as BrandName, d.WarehouseCode, d.WarehouseName, sum(b.CurrentStock) AS CurrentStock, sum(b.BookingStock) as BookingStock, sum(b.CurrentStock-b.BookingStock) AS 'SellableQty' ");
                sQueryStringMaster.Append(" FROM TELSysDB.dbo.V_Productdetails a, TELSysDB.dbo.t_ProductStock b, TELSysDB.dbo.t_WarehouseParent c, TELSysDB.dbo.t_Warehouse d ");
                sQueryStringMaster.Append(" WHERE a.ProductID = b.ProductID AND c.WarehouseParentID = d.WarehouseParentID AND b.WarehouseID = d.WarehouseID and a.PGID ='8' and d.WarehouseCode not in (0) ");
                sQueryStringMaster.Append(" group by a.ProductCode, a.ProductName, a.ASGName,a.BrandDesc, d.WarehouseCode, d.WarehouseName  ");

                cmd.CommandTimeout = 0;
                cmd.CommandText = sQueryStringMaster.ToString();

                GetDataTELCurrentStock(cmd);
            }

            if (sCompany == "Bangladesh Lamps Limited")
            {
                OleDbCommand cmd = DBController.Instance.GetCommand();

                StringBuilder sQueryStringMaster;
                sQueryStringMaster = new StringBuilder();

                sQueryStringMaster.Append(" SELECT a.ProductCode, a.ProductName, a.ASGName, a.BrandDesc as BrandName, d.WarehouseCode, d.WarehouseName, sum(b.CurrentStock) AS CurrentStock, sum(b.BookingStock) as BookingStock, sum(b.CurrentStock-b.BookingStock) AS 'SellableQty' ");
                sQueryStringMaster.Append(" FROM BLLSysDB.dbo.V_Productdetails a, BLLSysDB.dbo.t_ProductStock b, BLLSysDB.dbo.t_WarehouseParent c, BLLSysDB.dbo.t_Warehouse d ");
                sQueryStringMaster.Append(" WHERE a.ProductID = b.ProductID AND c.WarehouseParentID = d.WarehouseParentID AND b.WarehouseID = d.WarehouseID and a.PGID ='8' and d.WarehouseCode not in (0) ");
                sQueryStringMaster.Append(" group by a.ProductCode, a.ProductName, a.ASGName,a.BrandDesc, d.WarehouseCode, d.WarehouseName  ");

                cmd.CommandTimeout = 0;
                cmd.CommandText = sQueryStringMaster.ToString();

                GetDataTELCurrentStock(cmd);
            }
        }

        private void GetDataTELCurrentStock(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptCurrentStock oItem = new rptCurrentStock();

                    if (reader["WarehouseName"] != DBNull.Value)
                        oItem.WarehouseName = (string)reader["WarehouseName"];
                    else oItem.WarehouseName = "";

                    if (reader["WarehouseCode"] != DBNull.Value)
                        oItem.WarehouseCode = (string)reader["WarehouseCode"];
                    else oItem.WarehouseCode = "";

                    if (reader["ASGName"] != DBNull.Value)
                        oItem.ASGName = (string)reader["ASGName"];
                    else oItem.ASGName = "";

                    if (reader["BrandName"] != DBNull.Value)
                        oItem.BrandName = (string)reader["BrandName"];
                    else oItem.BrandName = "";

                    if (reader["ProductCode"] != DBNull.Value)
                        oItem.ProductCode = (string)reader["ProductCode"];
                    else oItem.ProductCode = "";

                    if (reader["ProductName"] != DBNull.Value)
                        oItem.ProductName = (string)reader["ProductName"];
                    else oItem.ProductName = "";

                    if (reader["CurrentStock"] != DBNull.Value)
                        oItem.CurrentStock = Convert.ToDouble(reader["CurrentStock"]);
                    else oItem.CurrentStock = 0;

                    if (reader["BookingStock"] != DBNull.Value)
                        oItem.BookingQty = Convert.ToDouble(reader["BookingStock"]);
                    else oItem.BookingQty = 0;

                    if (reader["SellableQty"] != DBNull.Value)
                        oItem.SellableQty = Convert.ToDouble(reader["SellableQty"]);
                    else oItem.SellableQty = 0;

                    Add(oItem);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void FromDataSetForTELStock(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    rptCurrentStock oCurrentStock = new rptCurrentStock();

                    oCurrentStock.WarehouseName = (string)oRow["WarehouseName"];
                    oCurrentStock.WarehouseCode = (string)oRow["WarehouseCode"];
                    oCurrentStock.ASGName = (string)oRow["ASGName"];
                    oCurrentStock.BrandName = (string)oRow["BrandName"];
                    oCurrentStock.ProductCode = (string)oRow["ProductCode"];
                    oCurrentStock.ProductName = (string)oRow["ProductName"];

                    oCurrentStock.CurrentStock = (double)oRow["CurrentStock"];
                    oCurrentStock.BookingQty = (double)oRow["BookingQty"];
                    oCurrentStock.SellableQty = (double)oRow["SellableQty"];

                    InnerList.Add(oCurrentStock);
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

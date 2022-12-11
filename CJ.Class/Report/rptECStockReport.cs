// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Aug 28, 2012
// Time :  11:00 AM
// Description: Class for ecommerce programmer stock report. 
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;
using CJ.Class.Web.UI.Class;

namespace CJ.Class.Report
{
    public class rptECStockReport
    {
        private string _PCode;
        private string _PName;
        private string _ProductName;
        private string _PCategory;
        private string _PSubCategory;
        private string _PBrand;
        private string _Brand;
        private string _ASGName;
        private double _RetailPrice;
        private double _RSP;
        private double _DiscountedPrice;
        private double _WebStock;
        private double _TDStock;
        private double _HOStock;

        /// <summary>
        /// Get set property for PCode
        /// </summary>
        public string PCode
        {
            get { return _PCode; }
            set { _PCode = value.Trim(); }
        }

        /// <summary>
        /// Get set property for PName
        /// </summary>
        public string PName
        {
            get { return _PName; }
            set { _PName = value.Trim(); }
        }
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for PCategory
        /// </summary>
        public string PCategory
        {
            get { return _PCategory; }
            set { _PCategory = value.Trim(); }
        }
        public string ASGName
        {
            get { return _ASGName; }
            set { _ASGName = value.Trim(); }
        }
        /// <summary>
        /// Get set property for PSubCategory
        /// </summary>
        public string PSubCategory
        {
            get { return _PSubCategory; }
            set { _PSubCategory = value.Trim(); }
        }

        /// <summary>
        /// Get set property for PBrand
        /// </summary>
        public string PBrand
        {
            get { return _PBrand; }
            set { _PBrand = value.Trim(); }
        }
        public string Brand
        {
            get { return _Brand; }
            set { _Brand = value.Trim(); }
        }

        /// <summary>
        /// Get set property for RetailPrice
        /// </summary>
        public double RetailPrice
        {
            get { return _RetailPrice; }
            set { _RetailPrice = value; }
        }
        public double RSP
        {
            get { return _RSP; }
            set { _RSP = value; }
        }
        /// <summary>
        /// Get set property for DiscountedPrice
        /// </summary>
        public double DiscountedPrice
        {
            get { return _DiscountedPrice; }
            set { _DiscountedPrice = value; }
        }

        /// <summary>
        /// Get set property for WebStock
        /// </summary>
        public double WebStock
        {
            get { return _WebStock; }
            set { _WebStock = value; }
        }
        public double TDStock
        {
            get { return _TDStock; }
            set { _TDStock = value; }
        }
        public double HOStock
        {
            get { return _HOStock; }
            set { _HOStock = value; }
        }

    }
    public class rptECStockReports : CollectionBase
    {
        public rptECStockReport this[int i]
        {
            get { return (rptECStockReport)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(rptECStockReport orptECStockReport)
        {
            InnerList.Add(orptECStockReport);
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = "select * from "
                          + " (select Prod.*,PD.ProductName,PD.BrandDesc,PD.ASGName,PD.RSP,TDOutlet.TDStock,HO.HOStock  "
                          +"  from t_ECProduct Prod "
                          +"  inner join v_ProductDetails PD "
                          +"  on Prod.PCode=PD.ProductCode "
                          +"  left outer join "
                          +"  (select B.Code as PCode,sum(SoundStock) as TDStock "
                          +"  from Cassiopeia_HO.dbo.SRStock A "
                          +"  inner join Cassiopeia_HO.dbo.Product B "
                          +"  on A.ProductID=B.ProductID "
                          +"  where not A.showroomID=1  "
                          +"  group by B.Code) TDOutlet "
                          +"  on Prod.PCode=TDOutlet.PCode "
                          +"  left outer join "
                          +"  (select B.ProductCode,CurrentStock as HOStock "
                          +"  from t_ProductStock A "
                          +"  inner join t_Product B " 
                          +"  on A.ProductID=B.ProductID "
                          +"  where WarehouseID=70) HO "
                          + "  on Prod.PCode=HO.ProductCode) AA order by PCategory,PSubCategory,PBrand ";
           
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptECStockReport orptECStockReport = new rptECStockReport();

                    orptECStockReport.PCode = (string)reader["PCode"];
                    orptECStockReport.PName = (string)reader["PName"];
                    orptECStockReport.ProductName = (string)reader["ProductName"];
                    orptECStockReport.ASGName = (string)reader["ASGName"];
                    orptECStockReport.PCategory = reader["PCategory"].ToString();
                    orptECStockReport.PSubCategory = reader["PSubCategory"].ToString();
                    orptECStockReport.PBrand = reader["PBrand"].ToString();
                    orptECStockReport.Brand = reader["BrandDesc"].ToString();
                    orptECStockReport.RetailPrice = (double)reader["RetailPrice"];
                    orptECStockReport.RSP = (double)reader["RSP"];
                    orptECStockReport.DiscountedPrice = (double)reader["DiscountedPrice"];
                    orptECStockReport.WebStock = (double)reader["WebStock"];
                    orptECStockReport.HOStock = Convert.ToDouble(reader["HOStock"]);
                    orptECStockReport.TDStock =Convert.ToDouble(reader["TDStock"]);

                    InnerList.Add(orptECStockReport);
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

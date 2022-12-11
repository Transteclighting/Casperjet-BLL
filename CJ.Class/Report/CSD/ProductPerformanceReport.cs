// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Sep 09, 2012
// Time" : 10:30 AM
// Description: Product Performance Report [900]
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
    [Serializable]
    public class ProductPerformanceReport
    {

        private string _sProductCode;
        private string _sProductName;
        private long _SaleQty;
        private long _ServiceQty;
        private long _ReplaceQty;
        private int _nASGID;
        private string _sASGName;
        private int _nMAGID;
        private string _sMAGName;
        private int _nBrandID;
        private string _sBrandName;

        //ASGID, ASGName, MAGID, MAGName, BrandID,BrandDesc, IsActive

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
        public long SaleQty
        {
            get { return _SaleQty; }
            set { _SaleQty = value; }
        }
        public long ServiceQty
        {
            get { return _ServiceQty; }
            set { _ServiceQty = value; }
        }
        public long ReplaceQty
        {
            get { return _ReplaceQty; }
            set { _ReplaceQty = value; }
        }
        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value; }
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
           
    }

    public class ProductPerformanceReportDetails: CollectionBaseCustom
       {

           public void Add(ProductPerformanceReport oProductPerformanceReport)
           {
               this.List.Add(oProductPerformanceReport);
           }
           public ProductPerformanceReport this[Int32 Index]
           {
               get
               {
                   return (ProductPerformanceReport)this.List[Index];
               }
               set
               {
                   if (!(value.GetType().Equals(typeof(ProductPerformanceReport))))
                   {
                       throw new Exception("Type can't be converted");
                   }
                   this.List[Index] = value;
               }
           }

         public void ProductWisePerformanceReport(DateTime dYFromDate, DateTime dYToDate)           
         {
           InnerList.Clear();
           OleDbCommand cmd = DBController.Instance.GetCommand();
           StringBuilder sQueryStringMaster;
           sQueryStringMaster = new StringBuilder();

           sQueryStringMaster.Append(" Select ProductCode,ProductName, ASGID, ASGName, MAGID, MAGName, BrandID,BrandDesc, IsActive, ");
            sQueryStringMaster.Append(" sum(case DataType when 'Sale' then Qty else 0 end) as SaleQty, ");
            sQueryStringMaster.Append(" sum(case DataType when 'Service' then Qty else 0 end) as ServiceQty, ");
            sQueryStringMaster.Append(" sum(case DataType when 'Replace' then Qty else 0 end) as ReplaceQty ");
            sQueryStringMaster.Append(" From ");
            sQueryStringMaster.Append(" (  ");
            //--Sale
            sQueryStringMaster.Append(" Select PD.ProductCode, PD.ProductName,PD.ASGID, PD.ASGName, PD.MAGID, PD.MAGName, PD.BrandID,PD.BrandDesc, PD.IsActive, ((S_Qty-R_Qty)+(S_FQty-R_FQty))Qty, ");
            sQueryStringMaster.Append(" 'Sale' AS DataType ");
            sQueryStringMaster.Append(" From ( ");
            sQueryStringMaster.Append(" Select Sale.ProductID ProductID, IsNull(S_Qty,0)S_Qty, IsNull(R_Qty,0)R_Qty,  ");
            sQueryStringMaster.Append(" IsNull(S_FQty,0)S_FQty,IsNull(R_FQty,0)R_FQty from  ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append(" Select ProductID, Sum(Quantity)S_Qty, Sum(FreeQty)S_FQty From ");
            sQueryStringMaster.Append(" (Select InvoiceID, ProductID, Quantity, FreeQty  ");
            sQueryStringMaster.Append(" from t_SalesInvoiceDetail) A ");
            sQueryStringMaster.Append(" INNER JOIN  ");
            sQueryStringMaster.Append(" (Select * from t_SalesInvoice Where InvoiceDate BETWEEN ? AND ? AND InvoiceDate < ? AND InvoiceStatus NOT IN (3,4,7))B ");
            sQueryStringMaster.Append(" ON B.InvoiceID=A.InvoiceID ");
            sQueryStringMaster.Append(" Group by ProductID)Sale ");

            sQueryStringMaster.Append(" Left Outer Join ");

            sQueryStringMaster.Append(" (Select ProductID, Sum(Quantity)R_Qty, Sum(FreeQty)R_FQty From ");
            sQueryStringMaster.Append(" (Select InvoiceID, ProductID, Quantity, FreeQty  ");
            sQueryStringMaster.Append(" from t_SalesInvoiceDetail) A ");
            sQueryStringMaster.Append(" INNER JOIN  ");
            sQueryStringMaster.Append(" (Select * from t_SalesInvoice Where InvoiceDate BETWEEN ? AND ? AND InvoiceDate < ? AND InvoiceStatus IN (4,7))B ");
            sQueryStringMaster.Append(" ON B.InvoiceID=A.InvoiceID ");
            sQueryStringMaster.Append(" Group by ProductID)Reverse ");
            sQueryStringMaster.Append(" ON Sale.ProductID=Reverse.ProductID ");
            sQueryStringMaster.Append(" )A ");
            sQueryStringMaster.Append(" INNER JOIN (SELECT * FROM  v_ProductDetails WHERE PGCode IN ('PG01', 'PG04', 'PG05')  ");
            sQueryStringMaster.Append(" AND MAGID NOT IN (20,33,41,334) AND BrandID IN (1,2,4,19)) AS PD ");
            sQueryStringMaster.Append(" ON A.ProductID=PD.ProductID ");
            sQueryStringMaster.Append(" Where ((S_Qty-R_Qty)+(S_FQty-R_FQty))<>0 ");

            sQueryStringMaster.Append(" UNION ALL ");
            //Replace

            sQueryStringMaster.Append(" SELECT PD.ProductCode, PD.ProductName,PD.ASGID, PD.ASGName, PD.MAGID, PD.MAGName, PD.BrandID,PD.BrandDesc, PD.IsActive, SUM (PSTI.Qty) AS Qty, 'Replace' AS DataType ");
            sQueryStringMaster.Append(" FROM t_ProductStockTran AS PST ");
            sQueryStringMaster.Append(" INNER JOIN t_ProductStockTranItem AS PSTI ");
            sQueryStringMaster.Append(" ON PST.TranID=PSTI.TranID ");
            sQueryStringMaster.Append(" INNER JOIN (SELECT * FROM  v_ProductDetails WHERE PGCode IN ('PG01', 'PG04', 'PG05')  ");
            sQueryStringMaster.Append(" AND MAGID NOT IN (20,33,41,334) AND BrandID IN (1,2,4,19)) AS PD ");
            sQueryStringMaster.Append(" ON PSTI.ProductID=PD.ProductID ");
            sQueryStringMaster.Append(" WHERE PST.TrantypeID =21 AND PST.TranDate BETWEEN ? AND ? AND PST.TranDate < ? ");
            sQueryStringMaster.Append(" GROUP BY PD.ProductCode, PD.ProductName,PD.ASGID, PD.ASGName, PD.MAGID, PD.MAGName, PD.BrandID,PD.BrandDesc, PD.IsActive ");

            sQueryStringMaster.Append(" UNION ALL ");
            //---------Cassandra Service Final(Only Warranty Except Replace & Cancel)------------

            sQueryStringMaster.Append(" Select P.Code AS ProductCode, PDS.ProductName AS ProductName, PDS.ASGID, PDS.ASGName, PDS.MAGID, PDS.MAGName, PDS.BrandID,PDS.BrandDesc, PDS.IsActive, COUNT(J.JobID) Qty, 'Service' AS DataType ");
            sQueryStringMaster.Append(" FROM TELServiceDB.dbo.Job AS J ");
            sQueryStringMaster.Append(" INNER JOIN TELServiceDB.dbo.Product AS P ");
            sQueryStringMaster.Append(" ON P.ProductID=J.ProductID ");
            sQueryStringMaster.Append(" INNER JOIN (SELECT * FROM  v_ProductDetails WHERE PGCode IN ('PG01', 'PG04', 'PG05')  ");
            sQueryStringMaster.Append(" AND MAGID NOT IN (20,33,41,334) AND BrandID IN (1,2,4,19))AS PDS ");
            sQueryStringMaster.Append(" ON PDS.ProductCode=P.Code ");
            sQueryStringMaster.Append(" WHERE J.JobType=1 AND J.ServiceType Not in (4)AND J.JobStatus NOT IN (15,20)AND J.JobCreationDate BETWEEN ? AND ? AND J.JobCreationDate < ? ");
            sQueryStringMaster.Append(" GROUP BY PDS.ProductName, P.Code,PDS.ASGID, PDS.ASGName, PDS.MAGID, PDS.MAGName, PDS.BrandID,PDS.BrandDesc, PDS.IsActive ");
            sQueryStringMaster.Append(" )A ");
            sQueryStringMaster.Append(" group by ProductCode,ProductName, ASGID, ASGName, MAGID, MAGName, BrandID,BrandDesc, IsActive ");
 
  
           OleDbCommand oCmd = DBController.Instance.GetCommand();
           //Command time out

           oCmd.CommandTimeout = 0;
           oCmd.CommandText = sQueryStringMaster.ToString();
           oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate);
           oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate.AddDays(1));
           oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate.AddDays(1));

           oCmd.Parameters.AddWithValue("InvoiceDate", dYFromDate);
           oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate.AddDays(1));
           oCmd.Parameters.AddWithValue("InvoiceDate", dYToDate.AddDays(1));


           oCmd.Parameters.AddWithValue("PST.TranDate", dYFromDate);
           oCmd.Parameters.AddWithValue("PST.TranDate", dYToDate.AddDays(1));
           oCmd.Parameters.AddWithValue("PST.TranDate", dYToDate.AddDays(1));

           oCmd.Parameters.AddWithValue("J.JobCreationDate", dYFromDate);
           oCmd.Parameters.AddWithValue("J.JobCreationDate", dYToDate.AddDays(1));
           oCmd.Parameters.AddWithValue("J.JobCreationDate", dYToDate.AddDays(1));

           GetDataProductPerformanceReport(oCmd); 
           
           }

           public void GetDataProductPerformanceReport(OleDbCommand cmd)
           {   
               try
               {
                   IDataReader reader = cmd.ExecuteReader();
                   while (reader.Read())
                   {
                       ProductPerformanceReport oItem = new ProductPerformanceReport();

                       if (reader["ProductCode"] != DBNull.Value)
                           oItem.ProductCode = reader["ProductCode"].ToString();
                       else oItem.ProductCode = "";

                       if (reader["ProductName"] != DBNull.Value)
                           oItem.ProductName = reader["ProductName"].ToString();
                       else oItem.ProductName = "";

                       if (reader["SaleQty"] != DBNull.Value)
                           oItem.SaleQty = Convert.ToInt32(reader["SaleQty"].ToString());
                       else oItem.SaleQty = -1;

                       if (reader["ServiceQty"] != DBNull.Value)
                           oItem.ServiceQty = Convert.ToInt32(reader["ServiceQty"].ToString());
                       else oItem.ServiceQty = -1;

                       if (reader["ReplaceQty"] != DBNull.Value)
                           oItem.ReplaceQty = Convert.ToInt32(reader["ReplaceQty"].ToString());
                       else oItem.ReplaceQty = -1;

                       if (reader["ASGID"] != DBNull.Value)
                           oItem.ASGID = Convert.ToInt32(reader["ASGID"]);
                       else oItem.ASGID = -1;

                       if (reader["ASGName"] != DBNull.Value)
                           oItem.ASGName = (string)reader["ASGName"];
                       else oItem.ASGName = "";

                       if (reader["MAGID"] != DBNull.Value)
                           oItem.MAGID = Convert.ToInt32(reader["MAGID"]);
                       else oItem.MAGID = -1;

                       if (reader["MAGName"] != DBNull.Value)
                           oItem.MAGName = (string)reader["MAGName"];
                       else oItem.MAGName = "";

                       if (reader["BrandID"] != DBNull.Value)
                           oItem.BrandID = Convert.ToInt32(reader["BrandID"]);
                       else oItem.BrandID = -1;

                       if (reader["BrandDesc"] != DBNull.Value)
                           oItem.BrandName = (string)reader["BrandDesc"];
                       else oItem.BrandName = "";  
                                                                    
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

           public void FromDataSetProductPerformanceReport(DataSet oDS)
           {
               InnerList.Clear();
               try
               {
                   foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                   {
                       ProductPerformanceReport oProductPerformanceReport = new ProductPerformanceReport();


                       oProductPerformanceReport.ProductCode = (string)oRow["ProductCode"];
                       oProductPerformanceReport.ProductName = (string)oRow["ProductName"];
                       oProductPerformanceReport.SaleQty = Convert.ToInt64(oRow["SaleQty"]);
                       oProductPerformanceReport.ServiceQty = Convert.ToInt64(oRow["ServiceQty"]);
                       oProductPerformanceReport.ReplaceQty = Convert.ToInt64(oRow["ReplaceQty"]);

                       oProductPerformanceReport.ASGID = Convert.ToInt32(oRow["ASGId"].ToString());
                       oProductPerformanceReport.ASGName = (string)oRow["ASGName"];

                       oProductPerformanceReport.MAGID = Convert.ToInt32(oRow["MAGID"].ToString());
                       oProductPerformanceReport.MAGName = (string)oRow["MAGName"];

                       oProductPerformanceReport.BrandID = Convert.ToInt32(oRow["BrandID"].ToString());
                       oProductPerformanceReport.BrandName = (string)oRow["BrandName"];

                       InnerList.Add(oProductPerformanceReport);
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


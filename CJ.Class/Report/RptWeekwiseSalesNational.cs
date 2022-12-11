// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak Kumar Chakraborty
// Date: Apr 16, 2013
// Time" :  11:28 AM
// Description: Week wise Daily National saels (Lighting-BLL)
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
    public class RptWeekwiseSalesNational
    {
        private int _nProductCode;
        private string _sProductName;
        private int _nASGID;
        private string _sASGName;
        private int _nBrandID;
        private string _sBrandDesc;
        private int _nMonthTGTQty;
        private int _nMTDSalesQty;
        private int _nWTDTGTQty;
        private int _nWTDSalesQty;
        private int _nCWTGTQty;
        private int _nCWSalesQty;
        private int _nPipeline;
        private int _nCurrentStock;
        private int _nTotalStock;


        public int ProductCode
        {
            get { return _nProductCode; }
            set { _nProductCode = value; }

        }

        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }

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

        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }

        }

        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value; }

        }

        public int MonthTgtQty
        {
            get { return _nMonthTGTQty; }
            set { _nMonthTGTQty = value; }

        }

        public int MTDSalesQty
        {
            get { return _nMTDSalesQty; }
            set { _nMTDSalesQty = value; }

        }
        public int WTDTGTQty
        {
            get { return _nWTDTGTQty; }
            set { _nWTDTGTQty = value; }

        }
        public int WTDSalesQty
        {
            get { return _nWTDSalesQty; }
            set { _nWTDSalesQty = value; }

        }
        public int CWTGTQty
        {
            get { return _nCWTGTQty; }
            set { _nCWTGTQty = value; }

        }
        public int CWSalesQty
        {
            get { return _nCWSalesQty; }
            set { _nCWSalesQty = value; }
        }
        public int Pipeline
        {
            get { return _nPipeline; }
            set { _nPipeline = value; }
        }
        public int CurrentStock
        {
            get { return _nCurrentStock; }
            set { _nCurrentStock = value; }
        }

        public int Totalstock
        {
            get { return _nTotalStock; }
            set { _nTotalStock = value; }

        }

    }

    public class RptWeekwiseSalesNationaldetails : CollectionBaseCustom
    {
        public void Add(RptWeekwiseSalesNational oRptWeekwiseSalesNational)
        {
            this.List.Add(oRptWeekwiseSalesNational);
        }
        public RptWeekwiseSalesNational this[Int32 Index]
        {
            get
            {
                return (RptWeekwiseSalesNational)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(RptWeekwiseSalesNational))))
                {
                    throw new Exception("Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void WeekwiseSalesNational(DateTime dYFromDate, DateTime dYTodate)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            sQueryStringMaster.Append("  select TGT.ProductCode, TGT.ProductName, TGT.ASGID,TGT.ASGName, TGT.BrandID, TGT.BrandDesc, TGT.MonthTGTQty, isnull(MTDSalesQty,0) as MTDSalesQty, TGT.WTDTGTQty , MTDSalesQty as WTDSalesQty,TGT.CWTGTQty,  ");
            sQueryStringMaster.Append("  isnull(CWSalesQty,0) as CWSalesQty,TGT.Pipeline,CurrentStock, (TGT.Pipeline+ CurrentStock) as TotalStock ");

            sQueryStringMaster.Append("  from ");
            sQueryStringMaster.Append("  ( ");
            sQueryStringMaster.Append("  select MTDTGT.ProductCode, ProductName, ASGID,ASGName,BrandID, BrandDesc, MonthTGTQty,isnull(WTDTGTQty,0) as WTDTGTQty ,isnull(CWTGTQty,0)as CWTGTQty, ");
            sQueryStringMaster.Append("  isnull(Pipeline,0) as Pipeline ");
            sQueryStringMaster.Append("  from ");
            sQueryStringMaster.Append("  ( ");
            sQueryStringMaster.Append("  select ProductCode, sum(SKUQty) as MonthTGTQty ");
            sQueryStringMaster.Append("  from teladddb.dbo.t_LightSKUNationalTgt ");
            sQueryStringMaster.Append("  where  TranTypeID=1 ");
            sQueryStringMaster.Append("  group by ProductCode ");
            sQueryStringMaster.Append("  ) as MTDTGT ");
            sQueryStringMaster.Append("  left outer join ");
            sQueryStringMaster.Append(" ( ");
            sQueryStringMaster.Append("  select ProductCode, sum(SKUQty) as WTDTGTQty ");
            sQueryStringMaster.Append("  from teladddb.dbo.t_LightSKUNationalTgt ");
            sQueryStringMaster.Append("  where  TranTypeID in (2,3) ");
            sQueryStringMaster.Append("  group by ProductCode ");
            sQueryStringMaster.Append("  ) as WTDTGT on MTDTGT.ProductCode=WTDTGT.ProductCode ");
            sQueryStringMaster.Append("  left outer join ");
            sQueryStringMaster.Append("  ( ");
            sQueryStringMaster.Append("  select ProductCode, sum(SKUQty) as CWTGTQty ");
            sQueryStringMaster.Append("  from teladddb.dbo.t_LightSKUNationalTgt ");
            sQueryStringMaster.Append("  where  TranTypeID in (3) ");
            sQueryStringMaster.Append("  group by ProductCode ");
            sQueryStringMaster.Append("  ) as CWTGT on MTDTGT.ProductCode=CWTGT.ProductCode ");
            sQueryStringMaster.Append("  left outer join ");
            sQueryStringMaster.Append("  ( ");
            sQueryStringMaster.Append("  select ProductCode, sum(SKUQty) as Pipeline ");
            sQueryStringMaster.Append("  from teladddb.dbo.t_LightSKUNationalTgt ");
            sQueryStringMaster.Append("  where  TranTypeID in (4) ");
            sQueryStringMaster.Append("  group by ProductCode ");
            sQueryStringMaster.Append("  ) as PIP on MTDTGT.ProductCode=PIP.ProductCode ");
            sQueryStringMaster.Append("  left outer join ");
            sQueryStringMaster.Append("  ( ");
            sQueryStringMaster.Append("  select ProductCode, ProductName, ASGID,ASGName, BrandID, BrandDesc ");
            sQueryStringMaster.Append("  from v_ProductDetails ");
            sQueryStringMaster.Append("  ) as Product on MTDTGT.ProductCode=Product.ProductCode ");
            sQueryStringMaster.Append("  ) as TGT ");
            sQueryStringMaster.Append("  left outer join ");
            sQueryStringMaster.Append("  ( ");
            sQueryStringMaster.Append("  select ProductCode, sum( CurrentStock) as CurrentStock ");
            sQueryStringMaster.Append("  from ");
            sQueryStringMaster.Append("  ( ");
            sQueryStringMaster.Append("  select Final.ProductCode,Final.ProductName, Final.ASGName, Final.BrandDesc,Final.ProductID,CurrentStock, Company  ");
            sQueryStringMaster.Append("  from ");
            sQueryStringMaster.Append("  ( ");
            sQueryStringMaster.Append("  Select b.ProductCode,b.ProductName, b.ASGName, b.BrandDesc,a.ProductID, sum(currentstock)as CurrentStock,'BLL' as Company  ");
            sQueryStringMaster.Append("  from BLLsysdb.dbo.t_productstock a, BLLsysdb.dbo.v_ProductDetails b  ");
            sQueryStringMaster.Append("  where channelid <> 1 and warehouseid <> 1  and a.productID=b.ProductID  and ASGID in (125,126,127,139,140) ");
            sQueryStringMaster.Append("  group by b.ProductCode,b.ProductName, b.ASGName, b.BrandDesc,a.ProductID ");
            sQueryStringMaster.Append("  )as Final ");
            sQueryStringMaster.Append("  )as TELBLL ");
            sQueryStringMaster.Append("  group by ProductCode ");
            sQueryStringMaster.Append("  ) as Stock on TGT.ProductCode=Stock.ProductCode ");
            sQueryStringMaster.Append("  left outer join ");
            sQueryStringMaster.Append("  ( ");
            sQueryStringMaster.Append("  select MTD.ProductCode, MTDSalesQty, isnull(CWSalesQty,0) as CWSalesQty ");
            sQueryStringMaster.Append("  from ");
            sQueryStringMaster.Append("  (  ");
            sQueryStringMaster.Append("  select ProductCode,  isnull (sum(QtySA)- sum(QtyRA),0) as MTDSalesQty ");
            sQueryStringMaster.Append("  from ");
            sQueryStringMaster.Append("  ( ");
            sQueryStringMaster.Append("  select  ProductCode,  sum (Quantity) as QtySA, 0 as  QtyRA   ");
            sQueryStringMaster.Append("  from bllsysdb.dbo.V_ProductDetails a, bllsysdb.dbo.t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c, bllsysdb.dbo.v_customerDetails d ");
            sQueryStringMaster.Append("  where a.productID=b.productID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and SBUID=1 and ChannelID in (2,12,8) and InvoicetypeID in (1,2,4,5) and invoiceStatus not in (3) ");
            sQueryStringMaster.Append("  and (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) ");
            sQueryStringMaster.Append(" group by ProductCode, ProductName ");
            sQueryStringMaster.Append("  union all  ");
            sQueryStringMaster.Append("  select  ProductCode,  0 as  QtySA,  sum(Quantity) as QtyRA  ");
            sQueryStringMaster.Append("  from bllsysdb.dbo.V_ProductDetails a, bllsysdb.dbo.t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c, bllsysdb.dbo.v_customerDetails d ");
            sQueryStringMaster.Append("  where a.productID=b.productID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and SBUID=1 and ChannelID in (2,12,8) and InvoicetypeID in (6,7,9,10,12) and invoiceStatus not in (3) ");
            sQueryStringMaster.Append("  and (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) ");
            sQueryStringMaster.Append("  group by  ProductCode, ProductName ");
            sQueryStringMaster.Append("  ) as b  ");
            sQueryStringMaster.Append("  group by   ProductCode ");
            sQueryStringMaster.Append("  ) MTD ");
            sQueryStringMaster.Append("  left outer join  ");
            sQueryStringMaster.Append("  ( ");
            sQueryStringMaster.Append("  select ProductCode,  isnull (sum(QtySA)- sum(QtyRA),0) as CWSalesQty ");
            sQueryStringMaster.Append("  from ");
            sQueryStringMaster.Append("  ( ");
            sQueryStringMaster.Append("  select  ProductCode,  sum (Quantity) as QtySA, 0 as  QtyRA   ");
            sQueryStringMaster.Append("  from bllsysdb.dbo.V_ProductDetails a, bllsysdb.dbo.t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c, bllsysdb.dbo.v_customerDetails d ");
            sQueryStringMaster.Append("  where a.productID=b.productID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and SBUID=1 and ChannelID in (2,12,8) and InvoicetypeID in (1,2,4,5) and invoiceStatus not in (3) ");
            sQueryStringMaster.Append("  and Invoicedate between ? and ? and Invoicedate< ? ");
            sQueryStringMaster.Append("  group by ProductCode, ProductName ");
            sQueryStringMaster.Append("  union all  ");
            sQueryStringMaster.Append(" select  ProductCode,  0 as  QtySA,  sum(Quantity) as QtyRA ");
            sQueryStringMaster.Append("  from bllsysdb.dbo.V_ProductDetails a, bllsysdb.dbo.t_salesinvoiceDetail b, bllsysdb.dbo.t_salesinvoice c, bllsysdb.dbo.v_customerDetails d ");
            sQueryStringMaster.Append("  where a.productID=b.productID and b.InvoiceID = c.InvoiceID and c.CustomerID=d.CustomerID and SBUID=1 and ChannelID in (2,12,8) and InvoicetypeID in (6,7,9,10,12) and invoiceStatus not in (3) ");
            sQueryStringMaster.Append("  and Invoicedate between ? and ? and Invoicedate< ? ");
            sQueryStringMaster.Append("  group by  ProductCode, ProductName  ");
            sQueryStringMaster.Append("  ) as b  ");
            sQueryStringMaster.Append("  group by   ProductCode ");
            sQueryStringMaster.Append("  ) as CW on MTD.ProductCode=CW.ProductCode ");
            sQueryStringMaster.Append("  ) as Sales on TGT.ProductCode=Sales.ProductCode ");
            sQueryStringMaster.Append("  Order by TGT.ProductCode, TGT.ProductName, TGT.ASGID,TGT.ASGName, TGT.BrandID, TGT.BrandDesc ");


            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYTodate.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYTodate.AddDays(1));

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYTodate.AddDays(1));
            oCmd.Parameters.AddWithValue("TranDate", dYTodate.AddDays(1));

            GetWeekwiseSales(oCmd);

        }

        public void GetWeekwiseSales(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptWeekwiseSalesNational oItem = new RptWeekwiseSalesNational();

                    if (reader["ProductCode"] != DBNull.Value)
                        oItem.ProductCode = Convert.ToInt32(reader["ProductCode"]);
                    else oItem.ProductCode = -1;

                    if (reader["ProductName"] != DBNull.Value)
                        oItem.ProductName = (string)reader["ProductName"];
                    else oItem.ProductName = "";

                    if (reader["ASGID"] != DBNull.Value)
                        oItem.ASGID = Convert.ToInt32(reader["ASGID"]);
                    else oItem.ASGID = -1;

                    if (reader["ASGName"] != DBNull.Value)
                        oItem.ASGName = (string)reader["ASGName"];
                    else oItem.ASGName = "";

                    if (reader["BrandID"] != DBNull.Value)
                        oItem.BrandID = Convert.ToInt32(reader["BrandID"]);
                    else oItem.BrandID = -1;

                    if (reader["BrandDesc"] != DBNull.Value)
                        oItem.BrandDesc = (string)reader["BrandDesc"];
                    else oItem.BrandDesc = "";

                    if (reader["MonthTgtQty"] != DBNull.Value)
                        oItem.MonthTgtQty =Convert.ToInt32(reader["MonthTgtQty"]);
                    else oItem.MonthTgtQty = 0;

                    if (reader["MTDSalesQty"] != DBNull.Value)
                        oItem.MTDSalesQty = Convert.ToInt32(reader["MTDSalesQty"]);
                    else oItem.MTDSalesQty = 0;

                    if (reader["WTDTGTQty"] != DBNull.Value)
                        oItem.WTDTGTQty = Convert.ToInt32(reader["WTDTGTQty"]);
                    else oItem.WTDTGTQty = 0;

                    if (reader["WTDSalesQty"] != DBNull.Value)
                        oItem.WTDSalesQty =Convert.ToInt32(reader["WTDSalesQty"]);
                    else oItem.WTDSalesQty = 0;

                    if (reader["CWTGTQty"] != DBNull.Value)
                        oItem.CWTGTQty = Convert.ToInt32(reader["CWTGTQty"]);
                    else oItem.CWTGTQty = 0;

                    if (reader["CWSalesQty"] != DBNull.Value)
                        oItem.CWSalesQty =Convert.ToInt32( reader["CWSalesQty"]);
                    else oItem.CWSalesQty = 0;

                    if (reader["Pipeline"] != DBNull.Value)
                        oItem.Pipeline =Convert.ToInt32( reader["Pipeline"]);
                    else oItem.Pipeline = 0;

                    if (reader["CurrentStock"] != DBNull.Value)
                        oItem.CurrentStock = Convert.ToInt32(reader["CurrentStock"]);
                    else oItem.CurrentStock = 0;

                    if (reader["Totalstock"] != DBNull.Value)
                        oItem.Totalstock = Convert.ToInt32(reader["Totalstock"]);
                    else oItem.Totalstock = 0;

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

        public void FromDataSetWeekwiseSales(DataSet oDS)
        {
            InnerList.Clear();
            try
            {
                foreach (DataRow oRow in oDS.Tables[this.GetType().Name].Rows)
                {
                    RptWeekwiseSalesNational oRptWeekwiseSalesNational = new RptWeekwiseSalesNational();


                    oRptWeekwiseSalesNational.ProductCode = Convert.ToInt32(oRow["ProductCode"]);
                    oRptWeekwiseSalesNational.ProductName = (string)oRow["ProductName"];
                    oRptWeekwiseSalesNational.ASGID = Convert.ToInt32(oRow["ASGID"]);
                    oRptWeekwiseSalesNational.ASGName = (string)oRow["ASGName"];
                    oRptWeekwiseSalesNational.BrandID = Convert.ToInt32(oRow["BrandID"]);
                    oRptWeekwiseSalesNational.BrandDesc = (string)oRow["BrandDesc"];
                    oRptWeekwiseSalesNational.MonthTgtQty = Convert.ToInt32(oRow["MonthTgtQty"]);
                    oRptWeekwiseSalesNational.MTDSalesQty = Convert.ToInt32(oRow["MTDSalesQty"]);
                    oRptWeekwiseSalesNational.WTDTGTQty = Convert.ToInt32(oRow["WTDTGTQty"]);
                    oRptWeekwiseSalesNational.WTDSalesQty = Convert.ToInt32(oRow["WTDSalesQty"]);
                    oRptWeekwiseSalesNational.CWTGTQty = Convert.ToInt32(oRow["CWTGTQty"]);                    
                    oRptWeekwiseSalesNational.CWSalesQty = Convert.ToInt32(oRow["CWSalesQty"]);
                    oRptWeekwiseSalesNational.Pipeline = Convert.ToInt32 (oRow["Pipeline"]);
                    oRptWeekwiseSalesNational.CurrentStock = Convert.ToInt32(oRow["CurrentStock"]);
                    oRptWeekwiseSalesNational.Totalstock = Convert.ToInt32(oRow["Totalstock"]);

                    InnerList.Add(oRptWeekwiseSalesNational);

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
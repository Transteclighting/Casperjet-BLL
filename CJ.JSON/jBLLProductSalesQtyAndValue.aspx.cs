
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.OleDb;
using Newtonsoft.Json;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.ANDROID;

public partial class jBLLProductSalesQtyAndValue : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();
            string sType = c.Request.Form["Type"].Trim();
            string sDataType = c.Request.Form["DataType"].Trim();

            //string sUser = "hakim";
            //string sType = "All";
            //string sCompany = "BLL";
            //string sDataType = "Sec";

            string sDatabase = "";
            string sValue = "";
            string sCustGroupID = "";
            string sValueType = "";
            if (c.Request.Form["Value"] != null)
            {
                sValue = c.Request.Form["Value"].Trim();
            }

            sDatabase = "BLLSysDB";

            if (sValue == "DC")
            {
                sCustGroupID = "216";
                sValueType = "DC";
            }
            else if (sValue == "DS")
            {
                sCustGroupID = "247";
                sValueType = "DS";
            }
            else if (sValue == "DN")
            {
                sCustGroupID = "246";
                sValueType = "DN";
            }
            else if (sValue == "NOR")
            {
                sCustGroupID = "10";
                sValueType = "NOR";
            }
            else if (sValue == "SOU")
            {
                sCustGroupID = "6";
                sValueType = "SOU";
            }
            else if (sValue == "CTG")
            {
                sCustGroupID = "4";
                sValueType = "CTG";
            }
            else if (sValue == "SYL")
            {
                sCustGroupID = "3";
                sValueType = "SYL";
            }
            else if (sValue == "W/S")
            {
                sCustGroupID = "288";
                sValueType = "W/S";
            }
  

            Datas oDatas = new Datas();
            Data _oData = new Data();
            Datas _oDatas = new Datas();
            Data _oDataTotal = new Data();
            Data _oDataPG = new Data();
            Data _oDataMAG = new Data();
            Data _oDataASG = new Data();   // Newly added
            Data _oDataBrand = new Data();

            int nCount = 0;

            DBController.Instance.OpenNewConnection();
            if (sDataType == "Pri")
            {
                oDatas.GetData(sCompany, sDatabase, sType, sValue, sCustGroupID, sValueType);
            }
            else
            {
               // oDatas.GetSecData(sCompany, sDatabase, sType, sValue, sCustGroupID, sValueType);
                oDatas.GetSecDataWH(sCompany, sDatabase, sType, sValue, sCustGroupID, sValueType);

            }
            DBController.Instance.CloseConnection();

            foreach (Data oData in oDatas)
            {
                if (nCount == 0)
                {
                    _oDataTotal = new Data();
                    _oDatas.Add(_oDataTotal);
                    _oDataTotal.BrandName = "Total";
                    _oDataTotal.Type = "Total";
                    _oDataTotal.Value = "Success";
                    nCount++;
                }
                if (_oDataPG.PGName != oData.PGName)
                {
                    _oDataPG = new Data();
                    _oDatas.Add(_oDataPG);
                    _oDataPG.PGName = oData.PGName;
                    _oDataPG.BrandName = oData.PGName;
                    _oDataPG.Type = "PG";
                    _oDataPG.Value = "Success";
                }

                if (_oDataMAG.MAGName != oData.MAGName)
                {
                    _oDataMAG = new Data();
                    _oDatas.Add(_oDataMAG);
                    _oDataMAG.MAGName = oData.MAGName;
                    _oDataMAG.BrandName = oData.MAGName;
                    _oDataMAG.Type = "MAG";
                    _oDataMAG.Value = "Success";
                }

                // New Added by Dipak

                if (_oDataASG.ASGName != oData.ASGName)
                {
                    _oDataASG = new Data();
                    _oDatas.Add(_oDataASG);
                    _oDataASG.ASGName = oData.ASGName;
                    _oDataASG.BrandName = oData.ASGName;
                    _oDataASG.Type = "ASG";
                    _oDataASG.Value = "Success";
                }


                _oDataBrand = new Data();
                _oDataBrand.Value = "Success";

                _oDataBrand.BrandName = oData.BrandName;

                _oDataBrand.DTDQty = oData.DTDQty;
                _oDataBrand.LDQty = oData.LDQty;
                _oDataBrand.MTDQty = oData.MTDQty;
                _oDataBrand.LMQty = oData.LMQty;
                _oDataBrand.YTDQty = oData.YTDQty;

                _oDataBrand.DTDValue = oData.DTDValue;
                _oDataBrand.LDValue = oData.LDValue;
                _oDataBrand.MTDValue = oData.MTDValue;
                _oDataBrand.LMValue = oData.LMValue;
                _oDataBrand.YTDValue = oData.YTDValue;
                _oDataBrand.Type = "Brand";
                _oDatas.Add(_oDataBrand);

                _oDataTotal.DTDQty = _oDataTotal.DTDQty + oData.DTDQty;
                _oDataTotal.LDQty = _oDataTotal.LDQty + oData.LDQty;
                _oDataTotal.MTDQty = _oDataTotal.MTDQty + oData.MTDQty;
                _oDataTotal.LMQty = _oDataTotal.LMQty + oData.LMQty;
                _oDataTotal.YTDQty = _oDataTotal.YTDQty + oData.YTDQty;

                _oDataTotal.DTDValue = _oDataTotal.DTDValue + oData.DTDValue;
                _oDataTotal.LDValue = _oDataTotal.LDValue + oData.LDValue;
                _oDataTotal.MTDValue = _oDataTotal.MTDValue + oData.MTDValue;
                _oDataTotal.LMValue = _oDataTotal.LMValue + oData.LMValue;
                _oDataTotal.YTDValue = _oDataTotal.YTDValue + oData.YTDValue;

                _oDataPG.DTDQty = _oDataPG.DTDQty + oData.DTDQty;
                _oDataPG.LDQty = _oDataPG.LDQty + oData.LDQty;
                _oDataPG.MTDQty = _oDataPG.MTDQty + oData.MTDQty;
                _oDataPG.LMQty = _oDataPG.LMQty + oData.LMQty;
                _oDataPG.YTDQty = _oDataPG.YTDQty + oData.YTDQty;

                _oDataPG.DTDValue = _oDataPG.DTDValue + oData.DTDValue;
                _oDataPG.LDValue = _oDataPG.LDValue + oData.LDValue;
                _oDataPG.MTDValue = _oDataPG.MTDValue + oData.MTDValue;
                _oDataPG.LMValue = _oDataPG.LMValue + oData.LMValue;
                _oDataPG.YTDValue = _oDataPG.YTDValue + oData.YTDValue;


                _oDataMAG.DTDQty = _oDataMAG.DTDQty + oData.DTDQty;
                _oDataMAG.LDQty = _oDataMAG.LDQty + oData.LDQty;
                _oDataMAG.MTDQty = _oDataMAG.MTDQty + oData.MTDQty;
                _oDataMAG.LMQty = _oDataMAG.LMQty + oData.LMQty;
                _oDataMAG.YTDQty = _oDataMAG.YTDQty + oData.YTDQty;

                _oDataMAG.DTDValue = _oDataMAG.DTDValue + oData.DTDValue;
                _oDataMAG.LDValue = _oDataMAG.LDValue + oData.LDValue;
                _oDataMAG.MTDValue = _oDataMAG.MTDValue + oData.MTDValue;
                _oDataMAG.LMValue = _oDataMAG.LMValue + oData.LMValue;
                _oDataMAG.YTDValue = _oDataMAG.YTDValue + oData.YTDValue;
                
                // Newly Added ASG ----------------

                _oDataASG.DTDQty = _oDataASG.DTDQty + oData.DTDQty;
                _oDataASG.LDQty = _oDataASG.LDQty + oData.LDQty;
                _oDataASG.MTDQty = _oDataASG.MTDQty + oData.MTDQty;
                _oDataASG.LMQty = _oDataASG.LMQty + oData.LMQty;
                _oDataASG.YTDQty = _oDataASG.YTDQty + oData.YTDQty;

                _oDataASG.DTDValue = _oDataASG.DTDValue + oData.DTDValue;
                _oDataASG.LDValue = _oDataASG.LDValue + oData.LDValue;
                _oDataASG.MTDValue = _oDataASG.MTDValue + oData.MTDValue;
                _oDataASG.LMValue = _oDataASG.LMValue + oData.LMValue;
                _oDataASG.YTDValue = _oDataASG.YTDValue + oData.YTDValue;


            }
            if (sCompany == "BLL")
            {
                if (sType == "All")
                {
                    if (sDataType == "Pri")
                    {
                        _oData.InsertReportLog(sUser);
                    }
                }
            }
            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput.ToString());
            
        }
    }
    public class Data
    {
        public string PGName;
        public string MAGName;
        public string ASGName;
        public string BrandName;
        public string Type;

        public double DTDValue;
        public double LDValue;
        public double MTDValue;
        public double LMValue;
        public double YTDValue;

        public string DTDValueText;
        public string LDValueText;
        public string LMValueText;
        public string MTDValueText;
        public string YTDValueText;

        public int DTDQty;
        public int LDQty;
        public int MTDQty; 
        public int LMQty;
        public int YTDQty;

        public string DTDQtyText;
        public string LDQtyText;
        public string LMQtyText;
        public string MTDQtyText;
        public string YTDQtyText;

        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10020";
            string sReportName = "BLL-Sales Qty & Value ";
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
        }
    }
    public class Datas : CollectionBase
    {
        public Data this[int i]
        {
            get { return (Data)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Data oData)
        {
            InnerList.Add(oData);
        }
        private string ExcludeDecimal(string sAmount)
        {
            string sResult = "";
            sResult = sAmount.Remove(sAmount.Length - 3);
            return sResult;
        }
        public void GetData(string sCompany, string sDatabase, string sType, string sValue, string sCustGroupID, string sValueType)
        {
            TELLib _oTELLib = new TELLib();

            DSOutletProductSales oDSDTDSales = new DSOutletProductSales();
            DSOutletProductSales oDSLDSales = new DSOutletProductSales();
            DSOutletProductSales oDSMTDSales = new DSOutletProductSales();
            DSOutletProductSales oDSLMSales = new DSOutletProductSales();
            DSOutletProductSales oDSYTDSales = new DSOutletProductSales();

            DateTime dFromDate = DateTime.Now.Date;
            DateTime dToDate = dFromDate.AddDays(1);
            DateTime dLastDate = dFromDate.AddDays(-1);
            DateTime _FirstDayofMonth = _oTELLib.FirstDayofMonth(dFromDate);
            DateTime _FirstDayofLastMonth = _oTELLib.FirstDayofLastMonth(dFromDate);

            string sSQL = "";
            #region DTD Sales Qty & Value
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (sType == "All")
            {
                sSQL = " select PGName, MAGName, ASGName,BrandName,(ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                      " Where a.ProductID=b.ProductID and InvoiceDate  " +
                      " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ASGID not in (677) Group by PGName, MAGName, ASGName,BrandName order by ASGName,BrandName  ";
            }
            else if (sType == "Outlet")
            {
                sSQL = " select PGName, MAGName,ASGName, BrandName, (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                      " " + sDatabase + ".dbo.t_Customer c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                                      " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' Group by PGName, MAGName,ASGName, BrandName order by ASGName,BrandName  ";

            }

            else if (sType == "ByOutlet")
            {
                sSQL = " select PGName, MAGName,ASGName, BrandName, (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                     " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                     " " + sDatabase + ".dbo.t_Customer c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                                     " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                                     " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and CustomerName='" + sValue + "' Group by PGName, MAGName,ASGName, BrandName  order by ASGName,BrandName ";

            }
            else if (sType == "ByGroup")
            {

                sSQL = " select PGName, MAGName,ASGName, BrandName, (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                      " " + sDatabase + ".dbo.t_Customer c, DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                      " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "' and d.CustomerID=c.CustomerID  and ";

                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                sSQL = sSQL + " Group by PGName, MAGName,ASGName, BrandName  order by ASGName,BrandName";
            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSDTDSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.MIX = reader["MIX"].ToString();
                    oProductSalesRow.Qty = reader["Qty"].ToString();
                    oProductSalesRow.Value = reader["Value"].ToString();


                    oDSDTDSales.ProductSales.AddProductSalesRow(oProductSalesRow);
                    oDSDTDSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
            #region LD Sales Qty & Value
            cmd = DBController.Instance.GetCommand();
            sSQL = "";
            if (sType == "All")
            {
                sSQL = " select PGName, MAGName,ASGName, BrandName, (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                  " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                                  " Where a.ProductID=b.ProductID and InvoiceDate  " +
                                  " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                  " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ASGID not in (677) Group by PGName, MAGName,ASGName,BrandName order by ASGName,BrandName  ";

            }
            else if (sType == "Outlet")
            {
                sSQL = " select PGName, MAGName,ASGName, BrandName, (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                     " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                     " " + sDatabase + ".dbo.t_Customer c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                                     " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                     " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' Group by PGName, MAGName,ASGName, BrandName  order by ASGName,BrandName ";

            }
            else if (sType == "ByOutlet")
            {
                sSQL = " select PGName, MAGName, ASGName,BrandName, (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                      " " + sDatabase + ".dbo.t_Customer c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and CustomerName='" + sValue + "' Group by PGName, MAGName,ASGName,BrandName  order by ASGName,BrandName ";
            }
            else if (sType == "ByGroup")
            {
                sSQL = " select PGName, MAGName, ASGName,BrandName, (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                      " " + sDatabase + ".dbo.t_Customer c, DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "' and d.CustomerID=c.CustomerID  and ";

                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                sSQL = sSQL + " Group by PGName, MAGName, ASGName,BrandName order by ASGName,BrandName ";
            }
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSLDSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.MIX = reader["MIX"].ToString();
                    oProductSalesRow.Qty = reader["Qty"].ToString();
                    oProductSalesRow.Value = reader["Value"].ToString();


                    oDSLDSales.ProductSales.AddProductSalesRow(oProductSalesRow);
                    oDSLDSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
            #region MTD Sales & Value
            cmd = DBController.Instance.GetCommand();
            sSQL = "";
            if (sType == "All")
            {
                //sSQL = " select PGName, MAGName,ASGName, BrandName, (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                //       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                //       " Where a.ProductID=b.ProductID and (InvoiceDate  " +
                //       " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                //       " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                //       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' Group by PGName, MAGName,ASGName,BrandName  ";


                //  New Query with Target 

                sSQL = " select PGName, MAGName,ASGName, BrandName,MIX, Sum(isnull(Qty,0))As Qty,Sum(isnull(Value,0))as Value, " +
                       "   sum(isnull(TGTQty,0)) as TGTQty, sum(isnull(TGTVal,0)) as TGTVal  " +
                       "   from " +
                       "   ( " +
                       "   select PGName, MAGName,ASGName, BrandName, (ASGName+BrandName)as MIX, Sum(SalesQty+FreeQty) as Qty,Sum(NetSale) as Value,0 as TGTQty, 0 as TGTVal  " +
                       "   from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b   " +
                       "   Where a.ProductID=b.ProductID and (InvoiceDate   " +
                       "   BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE()))  " +
                       "   AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))    " +
                       "   and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ASGID not in (677) Group by PGName, MAGName,ASGID,BrandID, ASGName, BrandName  " +
                       "   union all  " +
                       "  select PGName,MagName,ASGName,BrandName,(ASGName+BrandName)as Mix,0 as Qty, 0 as Value, sum(TGTQty)as TGTQty, sum(TGTTO)as TGTVal " +
                       "   from " +
                       "   ( " +
                       "   select ProductID,PGName,MagName,ASGID,ASGName,BrandID,BrandName,TGTQty,TGTTO " +
                       "   from " +
                       "   ( " +
                       "   select ProductGroupID, sum(Qty)as TGTQty, sum(round(Turnover,0))as TGTTO " +
                       "   from BLLsysdb.dbo.t_PlanBudgetTarget " +
                       "   where PeriodDate between '01-May-2015' and '30-May-2015' " +
                       "   group by ProductGroupID " +
                       "   )as TGT " +
                       "   inner join " +
                       "   ( " +
                       "   select ProductID,PGName,MagName,ASGID,ASGName,BrandID, BrandName from DWDB.dbo.t_ProductDetails where CompanyName='BLL' " +
                       "   )as Prod on TGT.ProductGroupID=Prod.ProductID " +
                       "   )as Final " +
                       "   group by PGName,MagName,ASGName, BrandName " +
                       "   )As MTD   " +
                       "   group by PGName, MAGName,ASGName, BrandName,MIX order by ASGName,BrandName ";



            }

            else if (sType == "ByOutlet")
            {
                //sSQL = " select PGName, MAGName, ASGName, BrandName, (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                //           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                //           " " + sDatabase + ".dbo.t_Customer c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                //           " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                //           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                //           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and CustomerName='" + sValue + "' Group by PGName, MAGName,ASGName, BrandName  ";



                sSQL = " select PGName, MAGName,ASGName, BrandName,MIX, Sum(isnull(Qty,0))As Qty,Sum(isnull(Value,0))as Value,  " +
                     " sum(isnull(TGTQty,0)) as TGTQty, sum(isnull(TGTVal,0)) as TGTVal " +
                     " from " +
                     " ( " +
                     " select PGName, MAGName, ASGName, BrandName, (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty,  Sum(NetSale) as Value, 0 as TGTQty, 0 as TGTVal  " +
                     " from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,   " +
                     " BLLsysDB.dbo.t_Customer c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate   " +
                     " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE()))  " +
                     " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                     " and a.CompanyName='BLL' and b.CompanyName='BLL' and CustomerName='" + sValue + "' Group by PGName, MAGName,ASGName, BrandName   " +
                     " union all  " +
                     " select PGName,MagName,ASGName,BrandName,(ASGName+BrandName)as Mix,0 as Qty, 0 as Value, sum(TGTQty)as TGTQty, sum(TGTTO)as TGTVal " +
                     " from " +
                     " ( " +
                     " select ProductID,PGName,MagName,ASGID,ASGName,BrandID,BrandName,TGTQty,TGTTO " +
                     " from " +
                     " ( " +
                     " select ProductGroupID, sum(Qty)as TGTQty, sum(round(Turnover,0))as TGTTO " +
                     " from BLLsysdb.dbo.t_PlanBudgetTarget a, BLLsysdb.dbo.t_Customer b " +
                     " where PeriodDate between '01-May-2015' and '30-May-2015' and a.MarketGroupID=b.CustomerID " +
                     " and b.CustomerName='" + sValue + "' " +
                     " group by ProductGroupID " +
                     " )as TGT " +
                     " inner join " +
                     " ( " +
                     " select ProductID,PGName,MagName,ASGID,ASGName,BrandID, BrandName from DWDB.dbo.t_ProductDetails where CompanyName='BLL' " +
                     " )as Prod on TGT.ProductGroupID=Prod.ProductID " +
                     " )as Final " +
                     " group by PGName,MagName,ASGName, BrandName " +
                     " )As MTD   " +
                     " group by PGName, MAGName,ASGName, BrandName,MIX order by ASGName,BrandName ";

            }

            else if (sType == "ByGroup")
            {

                //sSQL = " select PGName, MAGName,ASGName, BrandName, (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                //" Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                //" " + sDatabase + ".dbo.t_Customer c, DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                //" BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                //" AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                //" and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "' and d.CustomerID=c.CustomerID and ";

                //if (sValueType == "Area")
                //{
                //    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                //}
                //else
                //{
                //    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                //}
                //sSQL = sSQL + " Group by PGName, MAGName, ASGName, BrandName  ";


                // New Query with TGT 

                sSQL = " select PGName, MAGName,ASGName, BrandName, MIX, Sum(Qty)as Qty, Sum(Value) as Value, sum(TGTQty)as TGTQty, sum(TGTVal)As  TGTVal " +
                       " from " +
                       " ( " +
                       " select AreaID,TerritoryID,PGName, MAGName,ASGName, BrandName, (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty,Sum(NetSale) as Value,0 as TGTQty, 0 as TGTVal  " +
                       " from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,   " +
                       " BLLSysDB.dbo.t_Customer c, DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate   " +
                       " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE()))  " +
                       " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))    " +
                       " and a.CompanyName='BLL' and b.CompanyName='BLL' and d.CompanyName='BLL' and d.CustomerID=c.CustomerID  " +
                       " group by AreaID,TerritoryID,PGName, MAGName,ASGName, BrandName " +
                       " union all  " +
                       " select AreaID,TerritoryID,PGName,MagName,ASGName, BrandName,(ASGName+BrandName)as Mix, 0 as Qty, 0 as Value, sum(Qty)as TGTQty, sum(round(Turnover,0))as TGTTO " +
                       " from BLLsysdb.dbo.t_PlanBudgetTarget a, BLLsysdb.dbo.v_Customerdetails b, DWDB.dbo.t_ProductDetails c " +
                       " where PeriodDate between '01-May-2015' and '30-May-2015' and a.MarketGroupID=b.CustomerID and a.ProductGroupID=c.ProductID " +
                       " and c.CompanyName='BLL' " +
                       " group by AreaID,TerritoryID,PGName,MagName,ASGName, BrandName " +
                       " )as Final where ";

                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                sSQL = sSQL + "  group by PGName, MAGName,ASGName, BrandName,MIX order by ASGName,BrandName ";

            }
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSMTDSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.MIX = reader["MIX"].ToString();
                    oProductSalesRow.Qty = reader["Qty"].ToString();
                    oProductSalesRow.Value = reader["Value"].ToString();


                    oDSMTDSales.ProductSales.AddProductSalesRow(oProductSalesRow);
                    oDSMTDSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
            #region LM Sales & Value
            cmd = DBController.Instance.GetCommand();
            sSQL = "";
            if (sType == "All")
            {
                sSQL = " select PGName, MAGName,ASGName,BrandName, (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                          " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                          " Where a.ProductID=b.ProductID and InvoiceDate  " +
                          " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                          " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ASGID not in (677) Group by PGName, MAGName,ASGName,BrandName order by ASGName,BrandName  ";
            }
            else if (sType == "Outlet")
            {
                sSQL = " select PGName, MAGName, ASGName,BrandName, (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " " + sDatabase + ".dbo.t_Customer c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' Group by PGName, MAGName, ASGName,BrandName  order by ASGName,BrandName ";
            }
            else if (sType == "ByOutlet")
            {
                sSQL = " select PGName, MAGName, ASGName,BrandName, (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " " + sDatabase + ".dbo.t_Customer c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and CustomerName='" + sValue + "' Group by PGName, MAGName,ASGName, BrandName order by ASGName,BrandName  ";
            }
            else if (sType == "ByGroup")
            {
                sSQL = " select PGName, MAGName,ASGName, BrandName, (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " " + sDatabase + ".dbo.t_Customer c, DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "' and d.CustomerID=c.CustomerID and ";

                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                sSQL = sSQL + " Group by PGName, MAGName,ASGName, BrandName  order by ASGName,BrandName ";
            }
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSLMSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.MIX = reader["MIX"].ToString();
                    oProductSalesRow.Qty = reader["Qty"].ToString();
                    oProductSalesRow.Value = reader["Value"].ToString();

                    oDSLMSales.ProductSales.AddProductSalesRow(oProductSalesRow);
                    oDSLMSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
            #region YTD Sales & Value
            cmd = DBController.Instance.GetCommand();
            sSQL = "";
            if (sType == "All")
            {
                sSQL = " Select PGName, MAGName, ASGName,BrandName,MIX, Qty, Value from  " +
                       " ( " +
                       " select PGName, MAGName, ASGName, BrandName, PGSort, MAGSort, ASGSort,BrandSort, (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                       " Where a.ProductID=b.ProductID and (InvoiceDate  " +
                       " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                       " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ASGID not in (677) Group by PGName, MAGName,ASGName, BrandName, PGSort, MAGSort,ASGSort, BrandSort   " +
                       " )Final " +
                       " Order by ASGName,BrandName   ";
            }
            else if (sType == "Outlet")
            {
                sSQL = " Select PGName, MAGName,ASGName, BrandName,MIX, Qty, Value from  " +
                           " ( " +
                           " select PGName, MAGName, ASGName,BrandName, PGSort, MAGSort,ASGSort, BrandSort,  (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Customer c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' Group by PGName, MAGName,ASGName, BrandName,PGSort, MAGSort,ASGSort, BrandSort   " +
                           " )Final " +
                           " Order by  ASGName,BrandName  ";
            }
            else if (sType == "ByOutlet")
            {
                sSQL = " Select PGName, MAGName,ASGName, BrandName,MIX, Qty, Value from  " +
                           " ( " +
                           " select PGName, MAGName,ASGName,BrandName, PGSort, MAGSort,ASGSort, BrandSort,  (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Customer c Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and CustomerName='" + sValue + "' Group by PGName, MAGName,ASGName,BrandName,PGSort,MAGSort,ASGSort, BrandSort   " +
                           " )Final " +
                           " Order by ASGName,BrandName   ";
            }
            else if (sType == "ByGroup")
            {
                sSQL = " Select PGName, MAGName, ASGName,BrandName,MIX, Qty, Value from  " +
                           " ( " +
                           " select PGName, MAGName,ASGName, BrandName, PGSort, MAGSort, ASGSort,BrandSort,  (ASGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Customer c , DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "' and d.CustomerID=c.CustomerID and ";
                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }

                sSQL = sSQL + " Group by PGName, MAGName, ASGName,BrandName,PGSort, MAGSort,ASGSort, BrandSort   " +
                            " )Final " +
                            " order by ASGName,BrandName  ";
            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSYTDSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.PGName = reader["PGName"].ToString();
                    oProductSalesRow.MAGName = reader["MAGName"].ToString();
                    oProductSalesRow.ASGName = reader["ASGName"].ToString();
                    oProductSalesRow.BrandName = reader["BrandName"].ToString();

                    oProductSalesRow.MIX = reader["MIX"].ToString();
                    oProductSalesRow.Qty = reader["Qty"].ToString();
                    oProductSalesRow.Value = reader["Value"].ToString();


                    oDSYTDSales.ProductSales.AddProductSalesRow(oProductSalesRow);
                    oDSYTDSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion

            Data _oData;
            InnerList.Clear();

            foreach (DSOutletProductSales.ProductSalesRow oSalesValueRow in oDSYTDSales.ProductSales)
            {

                _oData = new Data();
                _oData.PGName = oSalesValueRow.PGName;
                _oData.MAGName = oSalesValueRow.MAGName;
                _oData.ASGName = oSalesValueRow.ASGName;
                _oData.BrandName = oSalesValueRow.BrandName;

                //DTD
                DSOutletProductSales oDSFilteredDTD = new DSOutletProductSales();
                DataRow[] oDRDTD = oDSDTDSales.ProductSales.Select(" MIX= '" + oSalesValueRow.MIX + "'");
                oDSFilteredDTD.Merge(oDRDTD);
                oDSFilteredDTD.AcceptChanges();

                foreach (DSOutletProductSales.ProductSalesRow oDTDSalesValueRow in oDSFilteredDTD.ProductSales)
                {
                    _oData.DTDQty = Convert.ToInt32(oDTDSalesValueRow.Qty);
                    _oData.DTDValue = Convert.ToDouble(oDTDSalesValueRow.Value);
                }

                //LD
                DSOutletProductSales oDSFilteredLD = new DSOutletProductSales();
                DataRow[] oDRLD = oDSLDSales.ProductSales.Select(" MIX= '" + oSalesValueRow.MIX + "'");
                oDSFilteredLD.Merge(oDRLD);
                oDSFilteredLD.AcceptChanges();

                foreach (DSOutletProductSales.ProductSalesRow oLDSalesValueRow in oDSFilteredLD.ProductSales)
                {
                    _oData.LDQty = Convert.ToInt32(oLDSalesValueRow.Qty);
                    _oData.LDValue = Convert.ToDouble(oLDSalesValueRow.Value);
                }

                //MTD
                DSOutletProductSales oDSFilteredMTD = new DSOutletProductSales();
                DataRow[] oDRMTD = oDSMTDSales.ProductSales.Select(" MIX= '" + oSalesValueRow.MIX + "'");
                oDSFilteredMTD.Merge(oDRMTD);
                oDSFilteredMTD.AcceptChanges();

                foreach (DSOutletProductSales.ProductSalesRow oMTDSalesValueRow in oDSFilteredMTD.ProductSales)
                {
                    _oData.MTDQty = Convert.ToInt32(oMTDSalesValueRow.Qty);
                    _oData.MTDValue = Convert.ToDouble(oMTDSalesValueRow.Value);
                }
                //LM
                DSOutletProductSales oDSFilteredLM = new DSOutletProductSales();
                DataRow[] oDRLM = oDSLMSales.ProductSales.Select(" MIX= '" + oSalesValueRow.MIX + "'");
                oDSFilteredLM.Merge(oDRLM);
                oDSFilteredLM.AcceptChanges();

                foreach (DSOutletProductSales.ProductSalesRow oLMSalesValueRow in oDSFilteredLM.ProductSales)
                {
                    _oData.LMQty = Convert.ToInt32(oLMSalesValueRow.Qty);
                    _oData.LMValue = Convert.ToDouble(oLMSalesValueRow.Value);
                }
                //YTD
                DSOutletProductSales oDSFilteredYTD = new DSOutletProductSales();
                DataRow[] oDRYTD = oDSYTDSales.ProductSales.Select(" MIX= '" + oSalesValueRow.MIX + "'");
                oDSFilteredYTD.Merge(oDRYTD);
                oDSFilteredYTD.AcceptChanges();

                foreach (DSOutletProductSales.ProductSalesRow oYTDSalesValueRow in oDSFilteredYTD.ProductSales)
                {
                    _oData.YTDQty = Convert.ToInt32(oYTDSalesValueRow.Qty);
                    _oData.YTDValue = Convert.ToDouble(oYTDSalesValueRow.Value);
                }
                InnerList.Add(_oData);
            }


        }
        public void GetSecData(string sCompany, string sDatabase, string sType, string sValue, string sCustGroupID, string sValueType)
        {
            TELLib _oTELLib = new TELLib();

            DSOutletProductSales oDSDTDSales = new DSOutletProductSales();
            DSOutletProductSales oDSLDSales = new DSOutletProductSales();
            DSOutletProductSales oDSMTDSales = new DSOutletProductSales();
            DSOutletProductSales oDSLMSales = new DSOutletProductSales();
            DSOutletProductSales oDSYTDSales = new DSOutletProductSales();

            DateTime dFromDate = DateTime.Now.Date;
            DateTime dToDate = dFromDate.AddDays(1);
            DateTime dLastDate = dFromDate.AddDays(-1);
            DateTime _FirstDayofMonth = _oTELLib.FirstDayofMonth(dFromDate);
            DateTime _FirstDayofLastMonth = _oTELLib.FirstDayofLastMonth(dFromDate);

            string sSQL = "";
            #region DTD Sales Qty & Value
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (sType == "All")
            {
                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                   " from( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                   " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c " +
                   " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + dFromDate + "' and '" + dToDate + "' and Trandate < '" + dToDate + "' " +
                   " and b.ProductID=c.ProductID )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";
                
            }            
            else if (sType == "ByOutlet")
            {

                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                       " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value "+
                       " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                       " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + dFromDate + "' and '" + dToDate + "' and Trandate < '" + dToDate + "' "+
                       " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and CustomerName='" + sValue + "'  " +
                       " )as Sls group by PGName, MAGName, ASGName,BrandDesc  order by ASGName,BrandName ";

            }
            else if (sType == "ByGroup")
            {

                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value " +
                       " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value "+
                       " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                       " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + dFromDate + "' and '" + dToDate + " and Trandate < '" + dToDate + " " +
                       " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and  ";
                                                            
                
                    if (sValueType == "Area")
                    {
                        sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                    }
                    else
                    {
                        sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                    }
                    sSQL = sSQL + " )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";


            }
            
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSDTDSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.MIX = reader["MIX"].ToString();
                    oProductSalesRow.Qty = reader["Qty"].ToString();
                    oProductSalesRow.Value = reader["Value"].ToString();


                    oDSDTDSales.ProductSales.AddProductSalesRow(oProductSalesRow);
                    oDSDTDSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
            #region LD Sales Qty & Value
            cmd = DBController.Instance.GetCommand();
            sSQL = "";


            if (sType == "All")
            {
                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                   " from( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                   " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c " +
                   " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + dLastDate + "' and '" + dFromDate + "' and Trandate < '" + dFromDate + "' " +
                   " and b.ProductID=c.ProductID )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";

            }
            else if (sType == "ByOutlet")
            {

                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                        " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                        " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                        " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + dLastDate + "' and '" + dFromDate + "' and Trandate < '" + dFromDate + "' " +
                        " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and CustomerName='" + sValue + "'  " +
                        " )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";

            }
            else if (sType == "ByGroup")
            {

                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value " +
                     " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                     " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                     " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + dLastDate + "' and '" + dFromDate + " and Trandate < '" + dFromDate + " " +
                     " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and   ";


                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                sSQL = sSQL + " )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";
                
            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSLDSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.MIX = reader["MIX"].ToString();
                    oProductSalesRow.Qty = reader["Qty"].ToString();
                    oProductSalesRow.Value = reader["Value"].ToString();


                    oDSLDSales.ProductSales.AddProductSalesRow(oProductSalesRow);
                    oDSLDSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
            #region MTD Sales & Value
            cmd = DBController.Instance.GetCommand();
            sSQL = "";

            if (sType == "All")
            {

                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                    "  from( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value   " +
                    "  from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c   " +
                    "  where TranTypeID=2  and a.TranID=b.TranID and (Trandate between CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                    "  and '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and (Trandate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) " +
                    "  and b.ProductID=c.ProductID )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";
            
            }
            else if (sType == "ByOutlet")
            {

                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                        " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                        " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                        " where TranTypeID in (2) and a.TranID=b.TranID and ( Trandate between CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE()))  " +
                        " and '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and ( Trandate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) " +
                        " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and CustomerName='" + sValue + "'  " +
                        " )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";

            }
            else if (sType == "ByGroup")
            {
                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value " +
                     " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                     " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                     " where TranTypeID in (2) and a.TranID=b.TranID and ( Trandate between CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                     " and '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and ( Trandate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) " +
                     " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and  ";
                
                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                sSQL = sSQL + " )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";

            }   

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSMTDSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.MIX = reader["MIX"].ToString();
                    oProductSalesRow.Qty = reader["Qty"].ToString();
                    oProductSalesRow.Value = reader["Value"].ToString();

                    oDSMTDSales.ProductSales.AddProductSalesRow(oProductSalesRow);
                    oDSMTDSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
            #region LM Sales & Value
            cmd = DBController.Instance.GetCommand();
            sSQL = "";

            if (sType == "All")
            {
                //sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                //   " from( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                //   " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c " +
                //   " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and Trandate < '" + _FirstDayofMonth + "' " +
                //   " and b.ProductID=c.ProductID )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";

                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, Qty,0 as Value " +
                   "   from " +
                   "   ( " +
                   "  select ASGID, BrandID, sum(Qty)as Qty " +
                   "   from dwdb.dbo.t_BLLSecondarySalesQty  " +
                   "   where Trandate between '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and Trandate < '" + _FirstDayofMonth + "' " +
                   "   group by ASGID,BrandID " +
                   "   )as LMSls " +
                   "   inner join  " +
                   "   ( select distinct ASGID, BrandID,PGName, MAGName, ASGName,BrandDesc from  BLLSysDB.dbo.v_ProductDetails  " +
                   "   )as Prod on LMSls.ASGID=Prod.ASGID and LMSls.BrandID=Prod.BrandID " +
                   "   order by ASGName,BrandName  ";


            }
            else if (sType == "ByOutlet")
            {
                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                        " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                        " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                        " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and Trandate < '" + _FirstDayofMonth + "' " +
                        " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and CustomerName='" + sValue + "'  " +
                        " )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";
            }
            else if (sType == "ByGroup")
            {
                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value " +
                     " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                     " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                     " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + " and Trandate < '" + _FirstDayofMonth + " " +
                     " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and  ";
                
                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                sSQL = sSQL + " )as Sls group by PGName, MAGName, ASGName,BrandDesc  order by ASGName,BrandName ";
                
            }
            
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSLMSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.MIX = reader["MIX"].ToString();
                    oProductSalesRow.Qty = reader["Qty"].ToString();
                    oProductSalesRow.Value = reader["Value"].ToString();

                    oDSLMSales.ProductSales.AddProductSalesRow(oProductSalesRow);
                    oDSLMSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
            #region YTD Sales & Value
            cmd = DBController.Instance.GetCommand();
            sSQL = "";

            if (sType == "All")
            {

                //sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                //   " from( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value  "+
                //   " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c  " +
                //   " where TranTypeID=2  and a.TranID=b.TranID and ( Trandate between '1/1/' + CONVERT(varchar, YEAR(GETDATE())) "+
                //   " and '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and (Trandate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))  " +
                //   " and b.ProductID=c.ProductID )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName "; 

                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, Qty,0 as Value " +
                  "   from " +
                  "   ( " +
                  "  select ASGID, BrandID, sum(Qty)as Qty " +
                  "   from dwdb.dbo.t_BLLSecondarySalesQty  " +
                  "   where Trandate between '1/1/' + CONVERT(varchar, YEAR(GETDATE())) and '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and Trandate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) " +
                  "   group by ASGID,BrandID " +
                  "   )as LMSls " +
                  "   inner join  " +
                  "   ( select distinct ASGID, BrandID,PGName, MAGName, ASGName,BrandDesc from  BLLSysDB.dbo.v_ProductDetails  " +
                  "   )as Prod on LMSls.ASGID=Prod.ASGID and LMSls.BrandID=Prod.BrandID " +
                  "   order by ASGName,BrandName  ";



            }
            else if (sType == "ByOutlet")
            {
                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                        " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                        " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                        " where TranTypeID in (2) and a.TranID=b.TranID and ( Trandate between '1/1/' + CONVERT(varchar, YEAR(GETDATE()))  " +
                        " and '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and ( Trandate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))  " +
                        " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and CustomerName='" + sValue + "'  " +
                        " )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";
            }
            else if (sType == "ByGroup")
            {
                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value " +
                     " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                     " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                     " where TranTypeID in (2) and a.TranID=b.TranID and (Trandate between '1/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                     " and '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))  and ( Trandate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) " +
                     " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and  ";

                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                sSQL = sSQL + " )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";
            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSYTDSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.PGName = reader["PGName"].ToString();
                    oProductSalesRow.MAGName = reader["MAGName"].ToString();
                    oProductSalesRow.ASGName = reader["ASGName"].ToString();
                    oProductSalesRow.BrandName = reader["BrandName"].ToString();

                    oProductSalesRow.MIX = reader["MIX"].ToString();
                    oProductSalesRow.Qty = reader["Qty"].ToString();
                    oProductSalesRow.Value = reader["Value"].ToString();


                    oDSYTDSales.ProductSales.AddProductSalesRow(oProductSalesRow);
                    oDSYTDSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion

            Data _oData;
            InnerList.Clear();

            foreach (DSOutletProductSales.ProductSalesRow oSalesValueRow in oDSYTDSales.ProductSales)
            {

                _oData = new Data();
                _oData.PGName = oSalesValueRow.PGName;
                _oData.MAGName = oSalesValueRow.MAGName;
                _oData.ASGName = oSalesValueRow.ASGName;
                _oData.BrandName = oSalesValueRow.BrandName;

                //DTD
                DSOutletProductSales oDSFilteredDTD = new DSOutletProductSales();
                DataRow[] oDRDTD = oDSDTDSales.ProductSales.Select(" MIX= '" + oSalesValueRow.MIX + "'");
                oDSFilteredDTD.Merge(oDRDTD);
                oDSFilteredDTD.AcceptChanges();

                foreach (DSOutletProductSales.ProductSalesRow oDTDSalesValueRow in oDSFilteredDTD.ProductSales)
                {
                    _oData.DTDQty = Convert.ToInt32(oDTDSalesValueRow.Qty);
                    _oData.DTDValue = Convert.ToDouble(oDTDSalesValueRow.Value);
                }

                //LD
                DSOutletProductSales oDSFilteredLD = new DSOutletProductSales();
                DataRow[] oDRLD = oDSLDSales.ProductSales.Select(" MIX= '" + oSalesValueRow.MIX + "'");
                oDSFilteredLD.Merge(oDRLD);
                oDSFilteredLD.AcceptChanges();

                foreach (DSOutletProductSales.ProductSalesRow oLDSalesValueRow in oDSFilteredLD.ProductSales)
                {
                    _oData.LDQty = Convert.ToInt32(oLDSalesValueRow.Qty);
                    _oData.LDValue = Convert.ToDouble(oLDSalesValueRow.Value);
                }

                //MTD
                DSOutletProductSales oDSFilteredMTD = new DSOutletProductSales();
                DataRow[] oDRMTD = oDSMTDSales.ProductSales.Select(" MIX= '" + oSalesValueRow.MIX + "'");
                oDSFilteredMTD.Merge(oDRMTD);
                oDSFilteredMTD.AcceptChanges();

                foreach (DSOutletProductSales.ProductSalesRow oMTDSalesValueRow in oDSFilteredMTD.ProductSales)
                {
                    _oData.MTDQty = Convert.ToInt32(oMTDSalesValueRow.Qty);
                    _oData.MTDValue = Convert.ToDouble(oMTDSalesValueRow.Value);
                }
                //LM
                DSOutletProductSales oDSFilteredLM = new DSOutletProductSales();
                DataRow[] oDRLM = oDSLMSales.ProductSales.Select(" MIX= '" + oSalesValueRow.MIX + "'");
                oDSFilteredLM.Merge(oDRLM);
                oDSFilteredLM.AcceptChanges();

                foreach (DSOutletProductSales.ProductSalesRow oLMSalesValueRow in oDSFilteredLM.ProductSales)
                {
                    _oData.LMQty = Convert.ToInt32(oLMSalesValueRow.Qty);
                    _oData.LMValue = Convert.ToDouble(oLMSalesValueRow.Value);
                }
                //YTD
                DSOutletProductSales oDSFilteredYTD = new DSOutletProductSales();
                DataRow[] oDRYTD = oDSYTDSales.ProductSales.Select(" MIX= '" + oSalesValueRow.MIX + "'");
                oDSFilteredYTD.Merge(oDRYTD);
                oDSFilteredYTD.AcceptChanges();

                foreach (DSOutletProductSales.ProductSalesRow oYTDSalesValueRow in oDSFilteredYTD.ProductSales)
                {
                    _oData.YTDQty = Convert.ToInt32(oYTDSalesValueRow.Qty);
                    _oData.YTDValue = Convert.ToDouble(oYTDSalesValueRow.Value);
                }
                InnerList.Add(_oData);
            }


        }
        public void GetSecDataWH(string sCompany, string sDatabase, string sType, string sValue, string sCustGroupID, string sValueType)
        {
            TELLib _oTELLib = new TELLib();

            DSOutletProductSales oDSDTDSales = new DSOutletProductSales();
            DSOutletProductSales oDSLDSales = new DSOutletProductSales();
            DSOutletProductSales oDSMTDSales = new DSOutletProductSales();
            DSOutletProductSales oDSLMSales = new DSOutletProductSales();
            DSOutletProductSales oDSYTDSales = new DSOutletProductSales();

            DateTime dFromDate = DateTime.Now.Date;
            DateTime dToDate = dFromDate.AddDays(1);
            DateTime dLastDate = dFromDate.AddDays(-1);
            DateTime _FirstDayofMonth = _oTELLib.FirstDayofMonth(dFromDate);
            DateTime _FirstDayofLastMonth = _oTELLib.FirstDayofLastMonth(dFromDate);

            string sSQL = "";
            #region DTD Sales Qty & Value
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (sType == "All")
            {
                //sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                //   " from( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                //   " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c " +
                //   " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + dFromDate + "' and '" + dToDate + "' and Trandate < '" + dToDate + "' " +
                //   " and b.ProductID=c.ProductID )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";

                sSQL = "  select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, Qty,0 as Value " +
                    "  from (select ASGID,BrandID, sum(Qty)as Qty " +
                    "  from DWDB.dbo.t_BLLSecondarySalesQty " +
                    "  where Trandate between '" + dFromDate + "' and '" + dToDate + "' and Trandate < '" + dToDate + "'  " +
                    "  group by ASGID,BrandID )As Qty inner join  " +
                    "  (select distinct ASGID,BrandID,ASGName,BrandDesc, PGName, MAGName from BLLSysDB.dbo.v_ProductDetails)as Prod on Qty.ASGID=Prod.ASGID " +
                    "  and Qty.BrandID=Prod.BrandID order by ASGName,BrandName ";



            }
            else if (sType == "ByOutlet")
            {

                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                       " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                       " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                       " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + dFromDate + "' and '" + dToDate + "' and Trandate < '" + dToDate + "' " +
                       " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and CustomerName='" + sValue + "'  " +
                       " )as Sls group by PGName, MAGName, ASGName,BrandDesc  order by ASGName,BrandName ";

            }
            else if (sType == "ByGroup")
            {

                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value " +
                       " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                       " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                       " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + dFromDate + "' and '" + dToDate + " and Trandate < '" + dToDate + " " +
                       " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and  ";


                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                sSQL = sSQL + " )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";


            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSDTDSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.MIX = reader["MIX"].ToString();
                    oProductSalesRow.Qty = reader["Qty"].ToString();
                    oProductSalesRow.Value = reader["Value"].ToString();


                    oDSDTDSales.ProductSales.AddProductSalesRow(oProductSalesRow);
                    oDSDTDSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
            #region LD Sales Qty & Value
            cmd = DBController.Instance.GetCommand();
            sSQL = "";


            if (sType == "All")
            {
                //sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                //   " from( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                //   " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c " +
                //   " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + dLastDate + "' and '" + dFromDate + "' and Trandate < '" + dFromDate + "' " +
                //   " and b.ProductID=c.ProductID )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";

                sSQL = "  select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, Qty,0 as Value " +
                    "  from (select ASGID,BrandID, sum(Qty)as Qty " +
                    "  from DWDB.dbo.t_BLLSecondarySalesQty " +
                    "  where Trandate between '" + dLastDate + "' and '" + dFromDate + "' and Trandate < '" + dFromDate + "'  " +
                    "  group by ASGID,BrandID )As Qty inner join  " +
                    "  (select distinct ASGID,BrandID,ASGName,BrandDesc, PGName, MAGName from BLLSysDB.dbo.v_ProductDetails)as Prod on Qty.ASGID=Prod.ASGID " +
                    "  and Qty.BrandID=Prod.BrandID order by ASGName,BrandName ";

            }
            else if (sType == "ByOutlet")
            {

                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                        " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                        " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                        " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + dLastDate + "' and '" + dFromDate + "' and Trandate < '" + dFromDate + "' " +
                        " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and CustomerName='" + sValue + "'  " +
                        " )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";

            }
            else if (sType == "ByGroup")
            {

                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value " +
                     " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                     " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                     " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + dLastDate + "' and '" + dFromDate + " and Trandate < '" + dFromDate + " " +
                     " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and   ";


                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                sSQL = sSQL + " )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";

            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSLDSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.MIX = reader["MIX"].ToString();
                    oProductSalesRow.Qty = reader["Qty"].ToString();
                    oProductSalesRow.Value = reader["Value"].ToString();


                    oDSLDSales.ProductSales.AddProductSalesRow(oProductSalesRow);
                    oDSLDSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
            #region MTD Sales & Value
            cmd = DBController.Instance.GetCommand();
            sSQL = "";

            if (sType == "All")
            {

                //sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                //    "  from( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value   " +
                //    "  from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c   " +
                //    "  where TranTypeID=2  and a.TranID=b.TranID and (Trandate between CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                //    "  and '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and (Trandate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) " +
                //    "  and b.ProductID=c.ProductID )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";


                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, Qty,0 as Value " +
                   "  from (select ASGID,BrandID, sum(Qty)as Qty " +
                   "  from DWDB.dbo.t_BLLSecondarySalesQty " +
                   "  where Trandate between DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0) and DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0) and Trandate < DATEADD(mm, DATEDIFF(mm, 0, GETDATE()) + 1, 0)  " +
                   "  group by ASGID,BrandID )As Qty inner join  " +
                   "  (select distinct ASGID,BrandID,ASGName,BrandDesc, PGName, MAGName from BLLSysDB.dbo.v_ProductDetails)as Prod on Qty.ASGID=Prod.ASGID " +
                   "  and Qty.BrandID=Prod.BrandID order by ASGName,BrandName ";
                

            }
            else if (sType == "ByOutlet")
            {

                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                        " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                        " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                        " where TranTypeID in (2) and a.TranID=b.TranID and ( Trandate between CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE()))  " +
                        " and '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and ( Trandate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) " +
                        " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and CustomerName='" + sValue + "'  " +
                        " )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";

            }
            else if (sType == "ByGroup")
            {
                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value " +
                     " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                     " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                     " where TranTypeID in (2) and a.TranID=b.TranID and ( Trandate between CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                     " and '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and ( Trandate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) " +
                     " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and  ";

                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                sSQL = sSQL + " )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";

            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSMTDSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.MIX = reader["MIX"].ToString();
                    oProductSalesRow.Qty = reader["Qty"].ToString();
                    oProductSalesRow.Value = reader["Value"].ToString();

                    oDSMTDSales.ProductSales.AddProductSalesRow(oProductSalesRow);
                    oDSMTDSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
            #region LM Sales & Value
            cmd = DBController.Instance.GetCommand();
            sSQL = "";

            if (sType == "All")
            {
                //sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                //   " from( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                //   " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c " +
                //   " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and Trandate < '" + _FirstDayofMonth + "' " +
                //   " and b.ProductID=c.ProductID )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";

                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, Qty,0 as Value " +
                   "   from " +
                   "   ( " +
                   "  select ASGID, BrandID, sum(Qty)as Qty " +
                   "   from dwdb.dbo.t_BLLSecondarySalesQty  " +
                   "   where Trandate between '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and Trandate < '" + _FirstDayofMonth + "' " +
                   "   group by ASGID,BrandID " +
                   "   )as LMSls " +
                   "   inner join  " +
                   "   ( select distinct ASGID, BrandID,PGName, MAGName, ASGName,BrandDesc from  BLLSysDB.dbo.v_ProductDetails  " +
                   "   )as Prod on LMSls.ASGID=Prod.ASGID and LMSls.BrandID=Prod.BrandID " +
                   "   order by ASGName,BrandName  ";


            }
            else if (sType == "ByOutlet")
            {
                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                        " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                        " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                        " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and Trandate < '" + _FirstDayofMonth + "' " +
                        " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and CustomerName='" + sValue + "'  " +
                        " )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";
            }
            else if (sType == "ByGroup")
            {
                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value " +
                     " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                     " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                     " where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + " and Trandate < '" + _FirstDayofMonth + " " +
                     " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and  ";

                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                sSQL = sSQL + " )as Sls group by PGName, MAGName, ASGName,BrandDesc  order by ASGName,BrandName ";

            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSLMSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.MIX = reader["MIX"].ToString();
                    oProductSalesRow.Qty = reader["Qty"].ToString();
                    oProductSalesRow.Value = reader["Value"].ToString();

                    oDSLMSales.ProductSales.AddProductSalesRow(oProductSalesRow);
                    oDSLMSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
            #region YTD Sales & Value
            cmd = DBController.Instance.GetCommand();
            sSQL = "";

            if (sType == "All")
            {

                //sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                //   " from( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value  "+
                //   " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c  " +
                //   " where TranTypeID=2  and a.TranID=b.TranID and ( Trandate between '1/1/' + CONVERT(varchar, YEAR(GETDATE())) "+
                //   " and '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and (Trandate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))  " +
                //   " and b.ProductID=c.ProductID )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName "; 

                sSQL = "  select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, Qty,0 as Value  "+
                    " from  "+
                    " (  "+
                    " select ASGID, BrandID, sum(Qty)as Qty   "+
                    " from dwdb.dbo.t_BLLSecondarySalesQty    "+
                    " where ( Trandate between '1/1/' + CONVERT(varchar, YEAR(GETDATE()))  and '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and (Trandate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) "+
                    " group by ASGID,BrandID   "+
                    " )as LMSls  "+
                    " inner join   "+
                    " ( select distinct ASGID, BrandID,PGName, MAGName, ASGName,BrandDesc from  BLLSysDB.dbo.v_ProductDetails   "+
                    " )as Prod on LMSls.ASGID=Prod.ASGID and LMSls.BrandID=Prod.BrandID  " +
                    " order by ASGName,BrandName ";
                

            }
            else if (sType == "ByOutlet")
            {
                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value  " +
                        " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                        " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                        " where TranTypeID in (2) and a.TranID=b.TranID and ( Trandate between '1/1/' + CONVERT(varchar, YEAR(GETDATE()))  " +
                        " and '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) and ( Trandate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))  " +
                        " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and CustomerName='" + sValue + "'  " +
                        " )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";
            }
            else if (sType == "ByGroup")
            {
                sSQL = " select PGName, MAGName, ASGName,BrandDesc as BrandName,(ASGName+BrandDesc)as MIX, sum(Qty)as Qty, sum(Value)as Value " +
                     " from ( select a.DistributorID,b.ProductID,PGName, MAGName, ASGName,BrandDesc,Qty, UnitPrice, round((Qty*UnitPrice),0)as Value " +
                     " from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, BLLSysDB.dbo.v_ProductDetails c, BLLSysDB.dbo.v_CustomerDetails d " +
                     " where TranTypeID in (2) and a.TranID=b.TranID and (Trandate between '1/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                     " and '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))  and ( Trandate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) " +
                     " and b.ProductID=c.ProductID  and a.DistributorID=d.CustomerID and  ";

                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                sSQL = sSQL + " )as Sls group by PGName, MAGName, ASGName,BrandDesc order by ASGName,BrandName ";
            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSYTDSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.PGName = reader["PGName"].ToString();
                    oProductSalesRow.MAGName = reader["MAGName"].ToString();
                    oProductSalesRow.ASGName = reader["ASGName"].ToString();
                    oProductSalesRow.BrandName = reader["BrandName"].ToString();

                    oProductSalesRow.MIX = reader["MIX"].ToString();
                    oProductSalesRow.Qty = reader["Qty"].ToString();
                    oProductSalesRow.Value = reader["Value"].ToString();


                    oDSYTDSales.ProductSales.AddProductSalesRow(oProductSalesRow);
                    oDSYTDSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion

            Data _oData;
            InnerList.Clear();

            foreach (DSOutletProductSales.ProductSalesRow oSalesValueRow in oDSYTDSales.ProductSales)
            {

                _oData = new Data();
                _oData.PGName = oSalesValueRow.PGName;
                _oData.MAGName = oSalesValueRow.MAGName;
                _oData.ASGName = oSalesValueRow.ASGName;
                _oData.BrandName = oSalesValueRow.BrandName;

                //DTD
                DSOutletProductSales oDSFilteredDTD = new DSOutletProductSales();
                DataRow[] oDRDTD = oDSDTDSales.ProductSales.Select(" MIX= '" + oSalesValueRow.MIX + "'");
                oDSFilteredDTD.Merge(oDRDTD);
                oDSFilteredDTD.AcceptChanges();

                foreach (DSOutletProductSales.ProductSalesRow oDTDSalesValueRow in oDSFilteredDTD.ProductSales)
                {
                    _oData.DTDQty = Convert.ToInt32(oDTDSalesValueRow.Qty);
                    _oData.DTDValue = Convert.ToDouble(oDTDSalesValueRow.Value);
                }

                //LD
                DSOutletProductSales oDSFilteredLD = new DSOutletProductSales();
                DataRow[] oDRLD = oDSLDSales.ProductSales.Select(" MIX= '" + oSalesValueRow.MIX + "'");
                oDSFilteredLD.Merge(oDRLD);
                oDSFilteredLD.AcceptChanges();

                foreach (DSOutletProductSales.ProductSalesRow oLDSalesValueRow in oDSFilteredLD.ProductSales)
                {
                    _oData.LDQty = Convert.ToInt32(oLDSalesValueRow.Qty);
                    _oData.LDValue = Convert.ToDouble(oLDSalesValueRow.Value);
                }

                //MTD
                DSOutletProductSales oDSFilteredMTD = new DSOutletProductSales();
                DataRow[] oDRMTD = oDSMTDSales.ProductSales.Select(" MIX= '" + oSalesValueRow.MIX + "'");
                oDSFilteredMTD.Merge(oDRMTD);
                oDSFilteredMTD.AcceptChanges();

                foreach (DSOutletProductSales.ProductSalesRow oMTDSalesValueRow in oDSFilteredMTD.ProductSales)
                {
                    _oData.MTDQty = Convert.ToInt32(oMTDSalesValueRow.Qty);
                    _oData.MTDValue = Convert.ToDouble(oMTDSalesValueRow.Value);
                }
                //LM
                DSOutletProductSales oDSFilteredLM = new DSOutletProductSales();
                DataRow[] oDRLM = oDSLMSales.ProductSales.Select(" MIX= '" + oSalesValueRow.MIX + "'");
                oDSFilteredLM.Merge(oDRLM);
                oDSFilteredLM.AcceptChanges();

                foreach (DSOutletProductSales.ProductSalesRow oLMSalesValueRow in oDSFilteredLM.ProductSales)
                {
                    _oData.LMQty = Convert.ToInt32(oLMSalesValueRow.Qty);
                    _oData.LMValue = Convert.ToDouble(oLMSalesValueRow.Value);
                }
                //YTD
                DSOutletProductSales oDSFilteredYTD = new DSOutletProductSales();
                DataRow[] oDRYTD = oDSYTDSales.ProductSales.Select(" MIX= '" + oSalesValueRow.MIX + "'");
                oDSFilteredYTD.Merge(oDRYTD);
                oDSFilteredYTD.AcceptChanges();

                foreach (DSOutletProductSales.ProductSalesRow oYTDSalesValueRow in oDSFilteredYTD.ProductSales)
                {
                    _oData.YTDQty = Convert.ToInt32(oYTDSalesValueRow.Qty);
                    _oData.YTDValue = Convert.ToDouble(oYTDSalesValueRow.Value);
                }
                InnerList.Add(_oData);
            }


        }
        public List<Data> getResult()
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            foreach (Data oData in this)
            {
                _oData = new Data();
                _oData.BrandName = oData.BrandName;
                _oData.Type = oData.Type;
                _oData.Value = oData.Value;
                _oData.DTDQtyText = oData.DTDQty.ToString();
                _oData.LDQtyText = oData.LDQty.ToString();
                _oData.MTDQtyText = oData.MTDQty.ToString();
                
                _oData.LMQtyText = oData.LMQty.ToString();
                _oData.YTDQtyText = oData.YTDQty.ToString();

                _oData.DTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.DTDValue));
                _oData.LDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LDValue));
                _oData.MTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.MTDValue));
                _oData.LMValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMValue));
                _oData.YTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.YTDValue));

                eList.Add(_oData);
            }
            return eList;

        }
      
    }
}



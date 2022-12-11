
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
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.ANDROID;

public partial class jBLLSecondaryRouteSalesAnalysisQty : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sType = c.Request.Form["Type"].Trim();
            string sAreaID = c.Request.Form["AreaID"].Trim();
            string sTerritoryID = c.Request.Form["TerritoryID"].Trim();
            string sCustomerID = c.Request.Form["CustomerID"].Trim();
            string sRouteTypeID = c.Request.Form["RouteTypeID"].Trim();
            string sRouteID = c.Request.Form["RouteID"].Trim();

            //string sUser = "hakim";
            //string sType = "National";
            //string sAreaID = "246";
            //string sTerritoryID = "76";
            //string sCustomerID = "1895";
            //string sRouteTypeID = "2";
            //string sRouteID = "1250";

            string sDate = "";
            DateTime dDate = DateTime.Now.Date;
            if (c.Request.Form["Date"] != null)
            {
                sDate = c.Request.Form["Date"].Trim();
            }
            try
            {
                dDate = Convert.ToDateTime(sDate);
            }
            catch (Exception ex)
            {
                dDate = DateTime.Now.Date;
            }
            Data _oData = new Data();
            Datas _oDatas = new Datas();
            _oDatas.GetData(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, dDate);

           _oData.InsertReportLog(sUser);

            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput.ToString());

        }
    }
    public class Data
    {
        // C = Current, M = Month, P=Primary, T=Target, L=Last, Y=Year, A=Actual

        public string ASGID;
        public string ASGName;
        

        public int CMSTQty;
        public int CMSAMTDQty;
        public int LMSAMTDQty;
        public int LMSAQty;
        public int LYCMSAQty; 
        public int LYCMSAMTDQty;
        public int DBStockQty;
        public int DBBufferStockQty;

        public string CMSTQtyText;
        public string CMSAMTDQtyText;
        public string LMSAMTDQtyText;
        public string LMSAQtyText;
        public string LYCMSAQtyText;
        public string LYCMSAMTDQtyText;
        public string DBStockQtyText;
        public string DBBufferStockQtyText;

        public string GSCMMTDPercText;
        public string GSLMMTDPercText;
        public string GSLMFullPercText;
        public string GSLYCMFullPercText;
        public string GSLYCMMTDPercText;
        public string StockPercText;


        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10039";
            string sReportName = "BLL-Route Sales Qty (ASG)";
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
        public void GetData(string sType, string sAreaID, string sTerritoryID, string sCustomerID, string sRouteTypeID, string sRouteID, DateTime dDate)
        {
            TELLib _oTELLib = new TELLib();

            //DateTime dFromDate = DateTime.Now.Date;
            DateTime dFromDate = dDate;
            DateTime dToDate = dFromDate.AddDays(1);
            DateTime dLastDate = dFromDate.AddDays(-1);
            DateTime _FirstDayofMonth = _oTELLib.FirstDayofMonth(dFromDate);
            DateTime _FirstDayofLastMonth = _oTELLib.FirstDayofLastMonth(dFromDate);
            DateTime _FirstDayofThisYear = _oTELLib.FirstDayofThisYear(dFromDate);
            DateTime _FirstDayofLastYear = _oTELLib.FirstDayofLastYear(dFromDate);
            DateTime _FirstDayofNextYear = _FirstDayofThisYear.AddYears(1);
            DateTime _FirstDayofNextMonth = _FirstDayofMonth.AddMonths(1);
            DateTime _ToDateOfLastMonth = dToDate.AddMonths(-1);

            DateTime _FristDayofLastYearThisMonth = _FirstDayofMonth.AddYears(-1);
            DateTime _FristDayofLastYearNextMonth = _FirstDayofNextMonth.AddYears(-1);
            DateTime _ToDateofLastYearThisMonth = dToDate.AddYears(-1);


            DSBLLPerformanceAnalysis oDSCustomer = new DSBLLPerformanceAnalysis();

            DSBLLPerformanceAnalysis oDSCMST = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSCMSAMTD = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLMSAMTD = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLMSA = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLYCMSA = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLYCMSAMTD = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSDBStock = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSDBBufferStock = new DSBLLPerformanceAnalysis();
            
            DBController.Instance.OpenNewConnection();

            oDSCustomer = GetASGList();
            oDSCMST = GetRawDataTarget(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, _FirstDayofMonth, _FirstDayofNextMonth);
            oDSCMSAMTD = GetRawData(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, _FirstDayofMonth, dToDate);
            oDSLMSAMTD = GetRawData(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, _FirstDayofLastMonth, _ToDateOfLastMonth);
            oDSLMSA = GetRawData(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, _FirstDayofLastMonth, _FirstDayofMonth);
            oDSLYCMSA = GetRawData(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, _FristDayofLastYearThisMonth, _FristDayofLastYearNextMonth);
            oDSLYCMSAMTD = GetRawData(sType, sAreaID, sTerritoryID, sCustomerID, sRouteTypeID, sRouteID, _FristDayofLastYearThisMonth, _ToDateofLastYearThisMonth);
            oDSDBStock = GetCustomerStock(sType, sAreaID, sTerritoryID, sCustomerID);
            oDSDBBufferStock = GetBufferStock(sType, sAreaID, sTerritoryID, sCustomerID);

            Data _oData;
            InnerList.Clear();

            foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow in oDSCustomer.BLLPerformanceAnalysis)
            {

                _oData = new Data();

                _oData.ASGName = oBLLPerformanceAnalysisRow.ASGName;
                
                //-----------
                // Current Month Secondary Target
                DSBLLPerformanceAnalysis oDSCMSTFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRCMST = oDSCMST.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "'");
                oDSCMSTFiltered.Merge(oDRCMST);
                oDSCMSTFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCMSTRow in oDSCMSTFiltered.BLLPerformanceAnalysis)
                {
                    _oData.CMSTQty = Convert.ToInt32(oDSCMSTRow.Qty);
                }

                // Current Month Secondary Achievement MTD
                DSBLLPerformanceAnalysis oDSCMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRCMSAMTD = oDSCMSAMTD.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "'");
                oDSCMSAMTDFiltered.Merge(oDRCMSAMTD);
                oDSCMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCMSAMTDRow in oDSCMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.CMSAMTDQty = Convert.ToInt32(oDSCMSAMTDRow.Qty);
                }

                // Last Month Secondary Achievement MTD
                DSBLLPerformanceAnalysis oDSLMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLMSAMTD = oDSLMSAMTD.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "'");
                oDSLMSAMTDFiltered.Merge(oDRLMSAMTD);
                oDSLMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMSAMTDRow in oDSLMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LMSAMTDQty = Convert.ToInt32(oDSLMSAMTDRow.Qty);
                }

                // Last Month Secondary Achievement
                DSBLLPerformanceAnalysis oDSLMSAFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLMSA = oDSLMSA.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "'");
                oDSLMSAFiltered.Merge(oDRLMSA);
                oDSLMSAFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMSARow in oDSLMSAFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LMSAQty = Convert.ToInt32(oDSLMSARow.Qty);
                }

                // Last Year This Month Secondary Achievement
                DSBLLPerformanceAnalysis oDSLYCMSAFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLYCMSA = oDSLYCMSA.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "'");
                oDSLYCMSAFiltered.Merge(oDRLYCMSA);
                oDSLYCMSAFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYCMSARow in oDSLYCMSAFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYCMSAQty = Convert.ToInt32(oDSLYCMSARow.Qty);
                }

                // Last Year This Month MTD Secondary Achievement
                DSBLLPerformanceAnalysis oDSLYCMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLYCMSAMTD = oDSLYCMSAMTD.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "'");
                oDSLYCMSAMTDFiltered.Merge(oDRLYCMSAMTD);
                oDSLYCMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYCMSAMTDRow in oDSLYCMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYCMSAMTDQty = Convert.ToInt32(oDSLYCMSAMTDRow.Qty);
                }

                // DB Stock
                DSBLLPerformanceAnalysis oDSDBStockFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRDBStock = oDSDBStock.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "'");
                oDSDBStockFiltered.Merge(oDRDBStock);
                oDSDBStockFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSDBStockRow in oDSDBStockFiltered.BLLPerformanceAnalysis)
                {
                    _oData.DBStockQty = Convert.ToInt32(oDSDBStockRow.Qty);
                }

                // DB Buffer Stock
                DSBLLPerformanceAnalysis oDSDBBufferStockFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRDBBufferStock = oDSDBBufferStock.BLLPerformanceAnalysis.Select(" ASGID= '" + oBLLPerformanceAnalysisRow.ASGID + "'");
                oDSDBBufferStockFiltered.Merge(oDRDBBufferStock);
                oDSDBBufferStockFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSDBBufferStockRow in oDSDBBufferStockFiltered.BLLPerformanceAnalysis)
                {
                    _oData.DBBufferStockQty = Convert.ToInt32(oDSDBBufferStockRow.Qty);
                }
                InnerList.Add(_oData);
            }


        }
        public DSBLLPerformanceAnalysis GetRawData(string sType, string sAreaID, string sTerritoryID, string sCustomerID, string sRouteTypeID, string sRouteID, DateTime dFromDate, DateTime dTodate)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();

            sSQL = " Select ASGID, Sum(RTQty)as Qty from " +
                  "  ( " +
                  "  select DistributorID,RouteID,RouteTypeID,ASGID, sum(Qty)as RTQty  " +
                  "  from " +
                  "  ( " +
                  "  select e.DistributorID,d.RouteID,RouteTypeID,ASGID,sum(Qty)as Qty  " +
                  "  from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSProductTranItem b, DWDB.dbo.t_ProductDetails c, BLLSysDB.dbo.t_DMSOutlet d, BLLSysDB.dbo.t_DMSRoute e  " +
                  "  where TranTypeID in (2) and a.TranID=b.TranID and Trandate between '" + dFromDate + "'  and '" + dTodate + "'   and Trandate < '" + dTodate + "'   " +
                  "  and b.ProductID=c.ProductID and a.OutletID=d.outletID and d.RouteID=e.RouteID and CompanyName='BLL' " +
                  "  group by e.DistributorID,d.RouteID,RouteTypeID,ASGID " +
                  "  union all " +
                  "  select DistributorID,RouteID, RouteTypeID, c.ASGID,sum(Qty)as RtQty  " +
                  "  from BLLSysDB.dbo.t_DMSRoute a, DWDB.dbo.t_SMSSecondarySales b, DWDB.dbo.t_SMSSecondarySalesItem c,  " +
                  "  (Select Distinct ASGID, ASGName,ASGSort from DWDB.dbo.t_ProductDetails Where companyName='BLL') d " +
                  "  Where RouteName='SMS Route' and a.DistributorID=b.CustomerID and b.TranID=c.TranID " +
                  "  and TranDate between '" + dFromDate + "'  and '" + dTodate + "'   and Trandate < '" + dTodate + "' and c.ASGID=d.ASGID " +
                  "  group by DistributorID, TranDate,RouteID, RouteTypeID,c.ASGID " +
                  "  )as Total group by DistributorID,RouteID,RouteTypeID,ASGID " +
                  "  )a, dwdb.dbo.t_CustomerDetails b Where a.DistributorID=b.customerID and companyname='BLL' ";
            if(sType != "National")
            {
                if (sType == "Area")
                {
                    sSQL = sSQL + "  and AreaID = '" + sAreaID + "' ";
                }
                else if (sType == "Territory")
                {
                    sSQL = sSQL + "  and TerritoryID = '" + sTerritoryID + "' ";
                }
                else if (sType == "Customer")
                {
                    sSQL = sSQL + "  and CustomerID = " + sCustomerID + " ";
                }
                else if (sType == "RouteType")
                {
                    sSQL = sSQL + " and RouteTypeID=" + sRouteTypeID + " and CustomerID = " + sCustomerID + " ";
                }
                else if (sType == "Route")
                {
                    sSQL = sSQL + "  and RouteID=" + sRouteID + " ";
                }
            }
           sSQL = sSQL + "  Group by ASGID ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.ASGID = Convert.ToInt32(reader["ASGID"]);
                    oBLLPerformanceAnalysisRow.Qty = Convert.ToInt32(reader["Qty"]);

                    oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.AddBLLPerformanceAnalysisRow(oBLLPerformanceAnalysisRow);
                    oDSBLLPerformanceAnalysis.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }


            return oDSBLLPerformanceAnalysis;
        }

        public DSBLLPerformanceAnalysis GetRawDataTarget(string sType, string sAreaID, string sTerritoryID, string sCustomerID, string sRouteTypeID, string sRouteID, DateTime dFromDate, DateTime dTodate)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();
            sSQL = " select a.ASGID, Sum(TSMTGTQty) as Qty from bllsysdb.dbo.t_DMSASGTarget a, DWDB.dbo.t_CustomerDetails b, " +
                   " BLLSysDB.dbo.t_DMSRoute c  " +
                   " Where a.DistributorID=b.CustomerID and CompanyName='BLL' and a.RouteID=c.RouteID " +
                   " and Targetdate between '" + dFromDate + "'  and '" + dTodate + "'   and Targetdate < '" + dTodate + "' ";
            if (sType != "National")
            {
                if (sType == "Area")
                {
                    sSQL = sSQL + "  and AreaID = '" + sAreaID + "' ";
                }
                else if (sType == "Territory")
                {
                    sSQL = sSQL + "  and TerritoryID = '" + sTerritoryID + "' ";
                }
                else if (sType == "Customer")
                {
                    sSQL = sSQL + "  and CustomerID = " + sCustomerID + " ";
                }
                else if (sType == "RouteType")
                {
                    sSQL = sSQL + " and RouteTypeID=" + sRouteTypeID + " and CustomerID = " + sCustomerID + " ";
                }
                else if (sType == "Route")
                {
                    sSQL = sSQL + "  and a.RouteID=" + sRouteID + " ";
                }
            }
            sSQL = sSQL + "  Group by a.ASGID ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.ASGID = Convert.ToInt32(reader["ASGID"]);
                    oBLLPerformanceAnalysisRow.Qty = Convert.ToInt32(reader["Qty"]);

                    oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.AddBLLPerformanceAnalysisRow(oBLLPerformanceAnalysisRow);
                    oDSBLLPerformanceAnalysis.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDSBLLPerformanceAnalysis;
        }
        
        public DSBLLPerformanceAnalysis GetCustomerStock(string sType, string sAreaID, string sTerritoryID, string sCustomerID)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();
            sSQL = " select ASGID, sum(CRStock) as CRStock, round(sum(StockVal),0)as StockVal " +
                   " from " +
                   " ( " +
                   " select a.ProductID,ASGID,a.DistributorID,NSP, sum(CurrentStock)as CRStock, sum(CurrentStock*NSP*.95)as StockVal " +
                   " from BLLSysDB.dbo.t_DMSProductStock a, BLLSysDB.dbo.t_DMSuser b, BLLSysDB.dbo.v_ProductDetails c, DWDB.dbo.t_CustomerDetails d " +
                   " where a.DistributorID=b.DistributorID and CurrentStock >=0 and a.DistributorID in  " +
                   " (select DistributorID from BLLSysDB.dbo.t_DMSUser where Isactive=1) and a.ProductID=c.ProductID and a.DistributorID=d.CustomerID  " +
                   " and d.CompanyName='BLL' ";

            if (sType != "National")
            {
                if (sType == "Area")
                {
                    sSQL = sSQL + "  and d.AreaID = '" + sAreaID + "' ";
                }
                else if (sType == "Territory")
                {
                    sSQL = sSQL + "  and d.TerritoryID = '" + sTerritoryID + "' ";
                }
                else if (sType == "Customer")
                {
                    sSQL = sSQL + "  and d.CustomerID = " + sCustomerID + " ";
                }

            }
            sSQL = sSQL + "  group by a.ProductID,ASGID,a.DistributorID, NSP)as Q1 Group by ASGID ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.ASGID = Convert.ToInt32(reader["ASGID"]);
                    oBLLPerformanceAnalysisRow.Qty = Convert.ToInt32(reader["CRStock"]);

                    oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.AddBLLPerformanceAnalysisRow(oBLLPerformanceAnalysisRow);
                    oDSBLLPerformanceAnalysis.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDSBLLPerformanceAnalysis;
        }
        
        public DSBLLPerformanceAnalysis GetBufferStock(string sType, string sAreaID, string sTerritoryID, string sCustomerID)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();
            sSQL = " select ASGID, Sum(BufferStock) as BufferStock from BLLsysDB.dbo.t_BufferStock a, " +
                   " BLLSysDB.dbo.v_ProductDetails b, DWDB.dbo.t_CustomerDetails c " +
                   " Where a.CustomerID=c.CustomerID and a.ProductID=b.ProductID and c.CompanyName='BLL' ";
            if (sType != "National")
            {
                if (sType == "Area")
                {
                    sSQL = sSQL + "  and AreaID = '" + sAreaID + "' ";
                }
                else if (sType == "Territory")
                {
                    sSQL = sSQL + "  and TerritoryID = '" + sTerritoryID + "' ";
                }
                else if (sType == "Customer")
                {
                    sSQL = sSQL + "  and c.CustomerID = " + sCustomerID + " ";
                }

            }
            sSQL = sSQL + "  Group by ASGID ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.ASGID = Convert.ToInt32(reader["ASGID"]);
                    oBLLPerformanceAnalysisRow.Qty = Convert.ToInt32(reader["BufferStock"]);

                    oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.AddBLLPerformanceAnalysisRow(oBLLPerformanceAnalysisRow);
                    oDSBLLPerformanceAnalysis.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDSBLLPerformanceAnalysis;
        }
        
        public DSBLLPerformanceAnalysis GetASGList()
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();

            //sSQL = " Select Distinct ASGID, ASGName, ASGSort from DWDB.dbo.t_ProductDetails where CompanyName='BLL' " +
            //       " and ASGID IN (126,125,127,139,140,708,712,713,714,715, 739,752,695) Order by ASGSort ";

            sSQL = " Select Distinct ASGID, ASGName, ASGSort from DWDB.dbo.t_ProductDetails where CompanyName = 'BLL' " +
                   " and ASGID not IN (129, 130, 131, 132, 135, 138, 142, 438, 656, 672, 677, 760, 762, 764, 767) " +
                   " Order by ASGSort  ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.ASGID = (int)reader["ASGID"];
                    oBLLPerformanceAnalysisRow.ASGName = reader["ASGName"].ToString();
                    

                    oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.AddBLLPerformanceAnalysisRow(oBLLPerformanceAnalysisRow);
                    oDSBLLPerformanceAnalysis.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return oDSBLLPerformanceAnalysis;
        }
        
        public List<Data> getResult()
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();

            foreach (Data oData in this)
            {

                _oData = new Data();
                _oData.ASGName = oData.ASGName;
                
                _oData.CMSTQtyText = oData.CMSTQty.ToString();
                _oData.CMSAMTDQtyText = oData.CMSAMTDQty.ToString();
                _oData.LMSAMTDQtyText = oData.LMSAMTDQty.ToString();
                _oData.LMSAQtyText = oData.LMSAQty.ToString();
                _oData.LYCMSAQtyText = oData.LYCMSAQty.ToString();
                _oData.LYCMSAMTDQtyText = oData.LYCMSAMTDQty.ToString();
                _oData.DBStockQtyText = oData.DBStockQty.ToString();
                _oData.DBBufferStockQtyText = oData.DBBufferStockQty.ToString();

                //Performance

                if (oData.CMSTQty > 0)
                {
                    _oData.GSCMMTDPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.CMSAMTDQty) / oData.CMSTQty) * 100));
                }
                else
                {
                    _oData.GSCMMTDPercText = "0";
                }

                if (oData.LMSAMTDQty > 0)
                {
                    _oData.GSLMMTDPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.CMSAMTDQty) - oData.LMSAMTDQty) / oData.LMSAMTDQty * 100));
                }
                else
                {
                    _oData.GSLMMTDPercText = "0";
                }

                if (oData.CMSTQty > 0)
                {
                    _oData.GSLMFullPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.LMSAQty) / oData.CMSTQty) * 100));
                }
                else
                {
                    _oData.GSLMFullPercText = "0";
                }
                if (oData.CMSTQty > 0)
                {
                    _oData.GSLYCMFullPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.LYCMSAQty) / oData.CMSTQty) * 100));
                }
                else
                {
                    _oData.GSLYCMFullPercText = "0";
                }
                if (oData.LYCMSAMTDQty > 0)
                {
                    _oData.GSLYCMMTDPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.CMSAMTDQty) - oData.LYCMSAMTDQty) / oData.LYCMSAMTDQty * 100));
                }
                else
                {
                    _oData.GSLYCMMTDPercText = "0";
                }
                if (oData.DBBufferStockQty > 0)
                {
                    _oData.StockPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.DBStockQty) / oData.DBBufferStockQty) * 100));
                }
                else
                {
                    _oData.StockPercText = "0";
                }
                eList.Add(_oData);

            }
            return eList;

        }
    }

}



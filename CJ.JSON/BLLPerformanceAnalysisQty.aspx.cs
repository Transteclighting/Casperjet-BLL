
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

public partial class BLLPerformanceAnalysisQty : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            string sUser = c.Request.Form["UserName"].Trim();  
            //string sUser = "hakim";
            

            Datas oDatas = new Datas();
            Data _oData = new Data();
            Datas _oDatas = new Datas();
            Data _oDataNational = new Data();
            Data _oDataArea = new Data();
            Data _oDataTerritory = new Data();
            Data _oDataCustomer = new Data();
            int nCount = 0;

            DBController.Instance.OpenNewConnection();
            oDatas.GetData();
            DBController.Instance.CloseConnection();

          
            _oData.InsertReportLog(sUser);

            TELLib _oTELLib = new TELLib();
            DateTime dFromDate = DateTime.Now.Date;
            int DayOfYear = dFromDate.DayOfYear;
            int TotalDayOfYear = _oTELLib.GetDaysInYear(dFromDate.Year);
            int DayOfMonth = dFromDate.Day;
            DateTime dLastDateOfMonth = _oTELLib.LastDayofMonth(dFromDate);
            int TotalDayOfMonth = dLastDateOfMonth.Day;

            //int xx = _oTELLib.LastDayofMonth(dFromDate.Day);
            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(DayOfMonth, TotalDayOfMonth, DayOfYear, TotalDayOfYear), Formatting.Indented);
            Response.Write(sOutput.ToString());

        }
    }
    public class Data
    {
        // C = Current, M = Month, P=Primary, T=Target, L=Last, Y=Year, A=Actual

        public int ASGID;
        public string ASGName;
        public int nQty;
        public string Type;
        public string Value;


        public int CMSTQty;
        public int CMSAMTDQty;
        public int LMSAMTDQty;
        public int LMSAQty;
        public int LYCMSAQty;

        public string CMSTQtyText;
        public string CMSAMTDQtyText;
        public string LMSAMTDQtyText;
        public string LMSAQtyText;
        public string LYCMSAQtyText;

        public string GSCMMTDPercText;
        public string GSLMMTDPercText;
        public string GSLMFullPercText;
        public string GSLYCMFullPercText;


        public void InsertReportLog(string sUser)
        {
            //ReportLog oReportLog = new ReportLog();
            //string sReportCode = "A10035";
            //string sReportName = "BLL-Route Sales (Value/ASG Qty)";
            //string connStr;
            //connStr = ConfigurationManager.AppSettings["jConnectionString"];
            //oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
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
        public void GetData()
        {
            TELLib _oTELLib = new TELLib();

            DateTime dFromDate = DateTime.Now.Date;
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

            oDSCustomer = GetCustomerList();
            oDSCMST = GetRawDataTarget(_FirstDayofMonth, _FirstDayofNextMonth);
            oDSCMSAMTD = GetRawData("SecondaryActual", _FirstDayofMonth, dToDate);
            oDSLMSAMTD = GetRawData("SecondaryActual", _FirstDayofLastMonth, _ToDateOfLastMonth);
            oDSLMSA = GetRawData("SecondaryActual", _FirstDayofLastMonth, _FirstDayofMonth);
            oDSLYCMSA = GetRawData("SecondaryActual", _FristDayofLastYearThisMonth, _FristDayofLastYearNextMonth);

            

            Data _oData;
            InnerList.Clear();

            foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow in oDSCustomer.BLLPerformanceAnalysis)
            {

                _oData = new Data();

                //_oData.AreaName = oBLLPerformanceAnalysisRow.AreaName;
                //_oData.TerritoryName = oBLLPerformanceAnalysisRow.TerritoryName;
                //_oData.FullName = oBLLPerformanceAnalysisRow.CustomerName;
                //_oData.ShortName = oBLLPerformanceAnalysisRow.CustomerShortName;
                //_oData.CustomerCode = oBLLPerformanceAnalysisRow.CustomerCode;
                //_oData.AreaID = oBLLPerformanceAnalysisRow.AreaID;
                //_oData.TerritoryID = oBLLPerformanceAnalysisRow.TerritoryID;
                //_oData.nReouteID = oBLLPerformanceAnalysisRow.RouteID;
                //_oData.sReouteID = oBLLPerformanceAnalysisRow.RouteID.ToString();
                //_oData.Route = oBLLPerformanceAnalysisRow.RouteName;
                //_oData.IsActive = oBLLPerformanceAnalysisRow.IsActive;

                //-----------
                // Current Month Secondary Target
                DSBLLPerformanceAnalysis oDSCMSTFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRCMST = oDSCMST.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSCMSTFiltered.Merge(oDRCMST);
                oDSCMSTFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCMSTRow in oDSCMSTFiltered.BLLPerformanceAnalysis)
                {
                    _oData.CMSTQty = Convert.ToInt32(oDSCMSTRow.Qty);
                }

                // Current Month Secondary Achievement MTD
                DSBLLPerformanceAnalysis oDSCMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRCMSAMTD = oDSCMSAMTD.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSCMSAMTDFiltered.Merge(oDRCMSAMTD);
                oDSCMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCMSAMTDRow in oDSCMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.CMSAMTDQty = Convert.ToInt32(oDSCMSAMTDRow.Qty);
                }

                // Last Month Secondary Achievement MTD
                DSBLLPerformanceAnalysis oDSLMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLMSAMTD = oDSLMSAMTD.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSLMSAMTDFiltered.Merge(oDRLMSAMTD);
                oDSLMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMSAMTDRow in oDSLMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LMSAMTDQty = Convert.ToInt32(oDSLMSAMTDRow.Qty);
                }

                // Last Month Secondary Achievement
                DSBLLPerformanceAnalysis oDSLMSAFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLMSA = oDSLMSA.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSLMSAFiltered.Merge(oDRLMSA);
                oDSLMSAFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMSARow in oDSLMSAFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LMSAQty = Convert.ToInt32(oDSLMSARow.Qty);
                }

                // Last Year This Month Secondary Achievement
                DSBLLPerformanceAnalysis oDSLYCMSAFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLYCMSA = oDSLYCMSA.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSLYCMSAFiltered.Merge(oDRLYCMSA);
                oDSLYCMSAFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYCMSARow in oDSLYCMSAFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYCMSAQty = Convert.ToInt32(oDSLYCMSARow.Qty);
                }
                
                InnerList.Add(_oData);
            }


        }
        public DSBLLPerformanceAnalysis GetRawData(string sType, DateTime dFromDate, DateTime dTodate)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (sType == "SecondaryActual")
            {
                cmd = DBController.Instance.GetCommand();
                //Old
                //sSQL = " Select b.RouteID as RouteID, Sum(NetAmount) as Value from BLLSysDB.dbo.t_DMSProductTran a, BLLSysDB.dbo.t_DMSOutlet b " +
                //       " where a.OutletID=b.OutletID and TranTypeID=2 and Trandate between '" + dFromDate + "' and '" + dTodate + "'   " +
                //       " and Trandate < '" + dTodate + "'  Group by b.RouteID ";

                //New
                sSQL = " Select RouteID, Sum(Value) as Value From " +
                "( " +
                "Select b.RouteID as RouteID, Sum(NetAmount) as Value from BLLSysDB.dbo.t_DMSProductTran a,  " +
                "BLLSysDB.dbo.t_DMSOutlet b, BLLSysDB.dbo.t_DMSUser c  " +
                "where a.OutletID=b.OutletID and a.DistributorID=c.DistributorID and Trandate >=ActivatedDate  "+
                "and TranTypeID=2 and Trandate between '" + dFromDate + "' and '" + dTodate + "' " +
                "and Trandate < '" + dTodate + "' Group by b.RouteID " +
                "UNION ALL " +
                "SElect b.RouteID, Value from " +
                "( " +
                "Select CustomerID, Sum(Amount) as Value from DWDB.dbo.t_SMSSecondarySales a, BLLSysDB.dbo.t_DMSUser b Where  " +
                "Trandate between '" + dFromDate + "' and '" + dTodate + "' " +
                "and Trandate < '" + dTodate + "' and ActivatedDate > Trandate and a.CustomerID=b.DistributorID Group by CustomerID " +
                "UNION ALL " +
                "Select CustomerID, Sum(Amount) as Value from DWDB.dbo.t_SMSSecondarySales Where  " +
                "Trandate between '" + dFromDate + "' and '" + dTodate + "' " +
                "and Trandate < '" + dTodate + "' and CustomerID Not IN (Select DistributorID From BLLSysDB.dbo.t_DMSUser Where IsActive=1)  " +
                "Group by CustomerID " +
                ") a, " +
                "(Select RouteID, DistributorID from BLLSysDB.dbo.t_DMSRoute Where RouteName='SMS Route')b " +
                "Where a.CustomerID=b.DistributorID " +
                ")x Group by RouteID ";


            }
            
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.RouteID = Convert.ToInt32(reader["RouteID"]);
                    oBLLPerformanceAnalysisRow.Amount = Convert.ToDouble(reader["Value"]);

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
        public DSBLLPerformanceAnalysis GetRawDataProductQty(string sType, string sMarketGroupType, string sValue, DateTime dFromDate, DateTime dTodate)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (sType == "SecondaryActual")
            {
                cmd = DBController.Instance.GetCommand();

                if (sMarketGroupType == "Route")
                {

                    //----------------------Qty By Route----------------------

                    //sSQL = "Select a.ASGID, ASGName, Qty from " +
                    //"( " +
                    sSQL = "Select ASGID, Sum(Qty) as Qty From " +
                    "( " +
                    "Select b.RouteID as RouteID,ASGID, BrandID, Sum(Qty) as Qty from BLLSysDB.dbo.t_DMSProductTran a,  " +
                    "BLLSysDB.dbo.t_DMSOutlet b, BLLSysDB.dbo.t_DMSUser c, (Select TranID, ASGID, BrandID, Sum(Qty) as Qty from  " +
                    "BLLSysDB.dbo.t_DMSProductTranItem a, DWDB.dbo.t_ProductDetails b Where a.ProductID=b.ProductID and CompanyName='BLL' " +
                    "Group by TranID, ASGID, BrandID) d  " +
                    "where a.OutletID=b.OutletID and a.DistributorID=c.DistributorID and a.TranID=d.TranID  " +
                    "and Trandate >=ActivatedDate  and TranTypeID=2 and Trandate between '" + dFromDate + "' and '" + dTodate + "' " +
                    "and Trandate < '" + dTodate + "' Group by b.RouteID, ASGID, BrandID " +
                    "UNION ALL " +
                    "SElect b.RouteID, ASGID, BrandID, Qty from " +
                    "( " +
                    "Select CustomerID, ASGID, BrandID, Sum(Qty) as Qty from DWDB.dbo.t_SMSSecondarySales a, BLLSysDB.dbo.t_DMSUser b, DWDB.dbo.t_SMSSecondarySalesItem c Where  " +
                    "Trandate between '" + dFromDate + "' and '" + dTodate + "' and Trandate < '" + dTodate + "' and ActivatedDate > Trandate and a.CustomerID=b.DistributorID  " +
                    "and a.TranID=c.TranID Group by CustomerID, ASGID, BrandID " +
                    "UNION ALL " +
                    "Select CustomerID, ASGID, BrandID, Sum(Qty) as Qty from DWDB.dbo.t_SMSSecondarySales a, DWDB.dbo.t_SMSSecondarySalesItem b Where  " +
                    "Trandate between '" + dFromDate + "' and '" + dTodate + "' and Trandate < '" + dTodate + "' and a.TranID=b.TranID  " +
                    "and CustomerID Not IN (Select DistributorID From BLLSysDB.dbo.t_DMSUser Where IsActive=1)  " +
                    "Group by CustomerID, ASGID, BrandID " +
                    ") a, " +
                    "(Select RouteID, DistributorID from BLLSysDB.dbo.t_DMSRoute Where RouteName='SMS Route')b " +
                    "Where a.CustomerID=b.DistributorID " +
                    ")x Where RouteID='" + sValue + "' Group by ASGID ";
                    //")a, (Select Distinct ASGID, ASGName,ASGSort from DWDB.dbo.t_ProductDetails Where CompanyName='BLL') b Where a.ASGID=b.ASGID " +
                    //"Order by ASGSort ";

                }
                else if (sMarketGroupType == "Customer")
                {
                    //----------- Qty Distributor---------

                    //sSQL = "Select a.ASGID, ASGName, Qty from " +
                    //"( " +
                    sSQL = "Select ASGID, Sum(Qty) as Qty From " +
                    "( " +
                    "Select b.DistributorID as CustomerID, ASGID, BrandID, Sum(Qty) as Qty from BLLSysDB.dbo.t_DMSProductTran a,  " +
                    "BLLSysDB.dbo.t_DMSOutlet b, BLLSysDB.dbo.t_DMSUser c, (Select TranID, ASGID, BrandID, Sum(Qty) as Qty from  " +
                    "BLLSysDB.dbo.t_DMSProductTranItem a, DWDB.dbo.t_ProductDetails b Where a.ProductID=b.ProductID and CompanyName='BLL' " +
                    "Group by TranID, ASGID, BrandID) d  " +
                    "where a.OutletID=b.OutletID and a.DistributorID=c.DistributorID and a.TranID=d.TranID  " +
                    "and Trandate >=ActivatedDate  and TranTypeID=2 and Trandate between '" + dFromDate + "' and '" + dTodate + "' " +
                    "and Trandate < '" + dTodate + "' Group by b.DistributorID, ASGID, BrandID " +
                    "UNION ALL " +
                    "SElect CustomerID, ASGID, BrandID, Qty from " +
                    "( " +
                    "Select CustomerID, ASGID, BrandID, Sum(Qty) as Qty from DWDB.dbo.t_SMSSecondarySales a, BLLSysDB.dbo.t_DMSUser b, DWDB.dbo.t_SMSSecondarySalesItem c Where  " +
                    "Trandate between '" + dFromDate + "' and '" + dTodate + "' and Trandate < '" + dTodate + "' and ActivatedDate > Trandate and a.CustomerID=b.DistributorID  " +
                    "and a.TranID=c.TranID Group by CustomerID, ASGID, BrandID " +
                    "UNION ALL " +
                    "Select CustomerID, ASGID, BrandID, Sum(Qty) as Qty from DWDB.dbo.t_SMSSecondarySales a, DWDB.dbo.t_SMSSecondarySalesItem b Where  " +
                    "Trandate between '" + dFromDate + "' and '" + dTodate + "' and Trandate < '" + dTodate + "' and a.TranID=b.TranID  " +
                    "and CustomerID Not IN (Select DistributorID From BLLSysDB.dbo.t_DMSUser Where IsActive=1)  " +
                    "Group by CustomerID, ASGID, BrandID " +
                    ") a " +
                    ")x Where CustomerID='" + sValue + "' Group by ASGID ";
                    //")a, (Select Distinct ASGID, ASGName,ASGSort from DWDB.dbo.t_ProductDetails Where CompanyName='BLL') b Where a.ASGID=b.ASGID " +
                    //"Order by ASGSort";
                }
                else
                {
                    //------Area/Territory/National--------

                    //sSQL = "Select a.ASGID, ASGName, Qty from " +
                    //"( " +
                    sSQL = "Select ASGID, Sum(Qty) as Qty From " +
                    "( " +
                    "Select ASGID, AreaID, TerritoryID, Sum(Qty) as Qty From " +
                    "( " +
                    "Select b.DistributorID as CustomerID, ASGID, BrandID, Sum(Qty) as Qty from BLLSysDB.dbo.t_DMSProductTran a,  " +
                    "BLLSysDB.dbo.t_DMSOutlet b, BLLSysDB.dbo.t_DMSUser c, (Select TranID, ASGID, BrandID, Sum(Qty) as Qty from  " +
                    "BLLSysDB.dbo.t_DMSProductTranItem a, DWDB.dbo.t_ProductDetails b Where a.ProductID=b.ProductID and CompanyName='BLL' Group by TranID, ASGID, BrandID) d  " +
                    "where a.OutletID=b.OutletID and a.DistributorID=c.DistributorID and a.TranID=d.TranID  " +
                    "and Trandate >=ActivatedDate  and TranTypeID=2 and Trandate between '" + dFromDate + "' and '" + dTodate + "' " +
                    "and Trandate < '" + dTodate + "'  Group by b.DistributorID, ASGID, BrandID " +
                    "UNION ALL " +
                    "SElect CustomerID, ASGID, BrandID, Qty from " +
                    "( " +
                    "Select CustomerID, ASGID, BrandID, Sum(Qty) as Qty from DWDB.dbo.t_SMSSecondarySales a, BLLSysDB.dbo.t_DMSUser b, DWDB.dbo.t_SMSSecondarySalesItem c Where  " +
                    "Trandate between '" + dFromDate + "' and '" + dTodate + "' and Trandate < '" + dTodate + "' and ActivatedDate > Trandate and a.CustomerID=b.DistributorID  " +
                    "and a.TranID=c.TranID Group by CustomerID, ASGID, BrandID " +
                    "UNION ALL " +
                    "Select CustomerID, ASGID, BrandID, Sum(Qty) as Qty from DWDB.dbo.t_SMSSecondarySales a, DWDB.dbo.t_SMSSecondarySalesItem b Where  " +
                    "Trandate between '" + dFromDate + "' and '" + dTodate + "' and Trandate < '" + dTodate + "' and a.TranID=b.TranID  " +
                    "and CustomerID Not IN (Select DistributorID From BLLSysDB.dbo.t_DMSUser Where IsActive=1)  " +
                    "Group by CustomerID, ASGID, BrandID " +
                    ") a " +
                    ")x ,  " +
                    "(Select CustomerID, AreaID, TerritoryID from DWDB.dbo.t_CustomerDetails Where ChannelID=2 and CompanyName='BLL')b Where x.CustomerID=b.CustomerID Group by ASGID,AreaID, TerritoryID " +
                    ")x Where 1=1 ";
                    if (sMarketGroupType == "Area")
                    {
                        sSQL = sSQL + " and AreaID = '" + sValue + "' ";
                    }
                    else if (sMarketGroupType == "Territory")
                    {
                        sSQL = sSQL + " and TerritoryID = '" + sValue + "' ";
                    }
                    sSQL = sSQL + " Group by ASGID ";
                    //")a, (Select Distinct ASGID, ASGName,ASGSort from DWDB.dbo.t_ProductDetails Where CompanyName='BLL') b Where a.ASGID=b.ASGID " +
                    //"Order by ASGSort";

                }
            }
            
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
        public DSBLLPerformanceAnalysis GetRawDataTarget(DateTime dFromDate, DateTime dTodate)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis(); 

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

                cmd = DBController.Instance.GetCommand();
                //, string sType, string sValue
                //if (sType == "All")
                {
                    sSQL = " select RouteID, SUM(TSMTGTTO)Amount from BLLSysDB.dbo.t_DMSTargetTO Where TGTDate Between '" + dFromDate + "' " +
                            " and '" + dTodate + "' and TGTDate < '" + dTodate + "' Group by RouteID";
                }
                //else if (sType == "All")
                //{ 
                
                
                //}


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.RouteID = Convert.ToInt32(reader["RouteID"]);
                    oBLLPerformanceAnalysisRow.Amount = Convert.ToDouble(reader["Amount"]);

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
        public DSBLLPerformanceAnalysis GetCustomerList()
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();

            sSQL = " Select CustomerID, CustomerCode, CustomerName, CustomerShortName, AreaID, AreaShortName, TerritoryID, TerritoryShortName, " +
                     "RouteID, RouteName, b.IsActive  from BLLSysDB.dbo.v_CustomerDetails a, BLLSysDB.dbo.t_DMSRoute b " +
                     "Where a.CustomerID=b.DistributorID and ChannelID=2 "+
                   " Order by AreaSort, TerritorySort, RouteName";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.CustomerID = reader["CustomerID"].ToString();
                    oBLLPerformanceAnalysisRow.CustomerCode = reader["CustomerCode"].ToString();
                    oBLLPerformanceAnalysisRow.CustomerName = reader["CustomerName"].ToString();
                    if (reader["CustomerShortName"] != DBNull.Value)
                        oBLLPerformanceAnalysisRow.CustomerShortName = reader["CustomerShortName"].ToString();
                    else oBLLPerformanceAnalysisRow.CustomerShortName = "Null";
                    oBLLPerformanceAnalysisRow.AreaName = reader["AreaShortName"].ToString();
                    oBLLPerformanceAnalysisRow.TerritoryName = reader["TerritoryShortName"].ToString();
                    oBLLPerformanceAnalysisRow.RouteID = Convert.ToInt32(reader["RouteID"]);
                    oBLLPerformanceAnalysisRow.RouteName = reader["RouteName"].ToString();

                    oBLLPerformanceAnalysisRow.AreaID = reader["AreaID"].ToString();
                    oBLLPerformanceAnalysisRow.TerritoryID = reader["TerritoryID"].ToString();
                    oBLLPerformanceAnalysisRow.IsActive = reader["IsActive"].ToString();


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
        public List<Data> getResult(int DayOfMonth, int TotalDayOfMonth, int DayOfYear, int TotalDayOfYear)
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            int nCount = 0;
            foreach (Data oData in this)
            {

                _oData = new Data();
                //_oData.ShortName = oData.ShortName;
                //_oData.FullName = oData.FullName;
                //_oData.CustomerCode = oData.CustomerCode;
                //_oData.AreaID = oData.AreaID;
                //_oData.TerritoryID = oData.TerritoryID;
                //_oData.sReouteID = oData.sReouteID;
                _oData.Type = oData.Type;
                _oData.Value = oData.Value;
                //if (oData.IsActive == "1")
                //    _oData.ActiveStatus = "Yes";
                //else _oData.ActiveStatus = "No";


                _oData.CMSTQtyText = oData.CMSTQty.ToString();
                _oData.CMSAMTDQtyText = oData.CMSAMTDQty.ToString();
                _oData.LMSAMTDQtyText = oData.LMSAMTDQty.ToString();
                _oData.LMSAQtyText = oData.LMSAQty.ToString();
                _oData.LYCMSAQtyText = oData.LYCMSAQty.ToString();

                //Performance

                if (oData.CMSTQty > 0)
                {
                    //_oData.GSCMMTDPercText = Convert.ToString(Math.Round((oData.CMSAMTDQty / oData.CMSTQty) * 100));
                }
                else
                {
                    _oData.GSCMMTDPercText = "0";
                }

                if (oData.CMSTQty > 0)
                {
                    //_oData.GSLMMTDPercText = Convert.ToString(Math.Round((oData.LMSAMTDQty / oData.CMSTQty) * 100));
                }
                else
                {
                    _oData.GSLMMTDPercText = "0";
                }

                if (oData.CMSTQty > 0)
                {
                    //_oData.GSLMFullPercText = Convert.ToString(Math.Round((oData.LMSAQty / oData.CMSTQty) * 100));
                }
                else
                {
                    _oData.GSLMFullPercText = "0";
                }
                if (oData.CMSTQty > 0)
                {
                    //_oData.GSLYCMFullPercText = Convert.ToString(Math.Round((oData.LYCMSAQty / oData.CMSTQty) * 100));
                }
                else
                {
                    _oData.GSLYCMFullPercText = "0";
                }
                eList.Add(_oData);

            }
            return eList;

        }
    }
}




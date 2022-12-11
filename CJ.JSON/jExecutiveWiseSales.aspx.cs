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

public partial class jExecutiveWiseSales : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

//            Select EmployeeID,JobLocationID,OutletEmployeeType 
//from t_Employee a,t_JobLocation b,t_OutletEmployee c
//where a.LocationID=b.JoblocationID and c.OutletEmployeeID=a.EmployeeID
//and IsActive=1 and EmployeeID=85283
//===================================
//select * from dbo.t_OutletSalesDataEmployee
 
//Select a.* From 
//DWDB.dbo.t_ExecutiveWiseWeekSales a,t_Employee b,t_JobLocation c,t_OutletEmployee d
//where a.SalesPersonID=b.EmployeeID and a.SalesPersonID=d.OutletEmployeeID 
//and b.EmployeeID=d.OutletEmployeeID and b.LocationID=c.JoblocationID and d.IsActive=1 
//and LocationID=55 and EmployeeID=85662





            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();
            string sOutlet = c.Request.Form["Outlet"].Trim();
            string sEmployeeID = c.Request.Form["EmployeeID"].Trim();

            //string sCompany = "TML";
            //string sUser = "hakim"; 

            string sChannel = "";

            string sDatabase = "x";
            if (c.Request.Form["Channel"] != null)
            {
                sChannel = c.Request.Form["Channel"].Trim();
            }
            if (sCompany == "TEL")
            {
                sDatabase = "TELSysDB";

            }
            else if (sCompany == "TML")
            {
                sDatabase = "TMLSysDB";
            }

            Datas oDatas = new Datas();
            Data _oData = new Data();
            Datas _oDatas = new Datas();
            Data _oDataTotal = new Data();
            Data _oDataArea = new Data();
            Data _oDataZone = new Data();
            Data _oDataOutlet = new Data();
            int nCount = 0;

            DBController.Instance.OpenNewConnection();
            //oDatas.GetData(sCompany, sDatabase, sChannel);
            oDatas.GetData(sCompany);
            DBController.Instance.CloseConnection();

            foreach (Data oData in oDatas)
            {
                if (nCount == 0)
                {
                    _oDataTotal = new Data();
                    _oDatas.Add(_oDataTotal);
                    _oDataTotal.Outlet = "Total";
                    _oDataTotal.Type = "Total";
                }
                if (_oDataArea.AreaName != oData.AreaName)
                {
                    _oDataTotal.Value = "Success";
                    nCount++;
                    _oDataArea = new Data();
                    _oDatas.Add(_oDataArea);
                    _oDataArea.AreaName = oData.AreaName;
                    _oDataArea.Outlet = oData.AreaName;
                    _oDataArea.Type = "Area";
                    _oDataArea.Value = "Success";
                }
                if (_oDataZone.ZoneName != oData.ZoneName)
                {
                    _oDataZone = new Data();
                    _oDatas.Add(_oDataZone);
                    _oDataZone.ZoneName = oData.ZoneName;
                    _oDataZone.Outlet = oData.ZoneName;
                    _oDataZone.Type = "Zone";
                    _oDataZone.Value = "Success";
                }

                _oDataOutlet = new Data();
                _oDataOutlet.Value = "Success";

                _oDataOutlet.Outlet = oData.Outlet;
                //_oDataOutlet.DTDValue = oData.DTDValue;
                //_oDataOutlet.LDValue = oData.LDValue;
                //_oDataOutlet.MTDValue = oData.MTDValue;
                //_oDataOutlet.LMValue = oData.LMValue;
                //_oDataOutlet.YTDValue = oData.YTDValue;
                //_oDataOutlet.LYValue = oData.LYValue;
                //_oDataOutlet.CMTValue = oData.CMTValue;
                //_oDataOutlet.MTDTValue = oData.MTDTValue;
                //_oDataOutlet.LMTValue = oData.LMTValue;
                //_oDataOutlet.LYYTDValue = oData.LYYTDValue;

                _oDataOutlet.Type = "Outlet";
                _oDatas.Add(_oDataOutlet);

                //_oDataTotal.DTDValue = _oDataTotal.DTDValue + oData.DTDValue;
                //_oDataTotal.LDValue = _oDataTotal.LDValue + oData.LDValue;
                //_oDataTotal.MTDValue = _oDataTotal.MTDValue + oData.MTDValue;
                //_oDataTotal.LMValue = _oDataTotal.LMValue + oData.LMValue;
                //_oDataTotal.YTDValue = _oDataTotal.YTDValue + oData.YTDValue;
                //_oDataTotal.LYValue = _oDataTotal.LYValue + oData.LYValue;
                //_oDataTotal.CMTValue = _oDataTotal.CMTValue + oData.CMTValue;
                //_oDataTotal.MTDTValue = _oDataTotal.MTDTValue + oData.MTDTValue;
                //_oDataTotal.LMTValue = _oDataTotal.LMTValue + oData.LMTValue;
                //_oDataTotal.LYYTDValue = _oDataTotal.LYYTDValue + oData.LYYTDValue;

                //_oDataArea.DTDValue = _oDataArea.DTDValue + oData.DTDValue;
                //_oDataArea.LDValue = _oDataArea.LDValue + oData.LDValue;
                //_oDataArea.MTDValue = _oDataArea.MTDValue + oData.MTDValue;
                //_oDataArea.LMValue = _oDataArea.LMValue + oData.LMValue;
                //_oDataArea.YTDValue = _oDataArea.YTDValue + oData.YTDValue;
                //_oDataArea.LYValue = _oDataArea.LYValue + oData.LYValue;
                //_oDataArea.CMTValue = _oDataArea.CMTValue + oData.CMTValue;
                //_oDataArea.MTDTValue = _oDataArea.MTDTValue + oData.MTDTValue;
                //_oDataArea.LMTValue = _oDataArea.LMTValue + oData.LMTValue;
                //_oDataArea.LYYTDValue = _oDataArea.LYYTDValue + oData.LYYTDValue;

                //_oDataZone.DTDValue = _oDataZone.DTDValue + oData.DTDValue;
                //_oDataZone.LDValue = _oDataZone.LDValue + oData.LDValue;
                //_oDataZone.MTDValue = _oDataZone.MTDValue + oData.MTDValue;
                //_oDataZone.LMValue = _oDataZone.LMValue + oData.LMValue;
                //_oDataZone.YTDValue = _oDataZone.YTDValue + oData.YTDValue;
                //_oDataZone.LYValue = _oDataZone.LYValue + oData.LYValue;
                //_oDataZone.CMTValue = _oDataZone.CMTValue + oData.CMTValue;
                //_oDataZone.MTDTValue = _oDataZone.MTDTValue + oData.MTDTValue;
                //_oDataZone.LMTValue = _oDataZone.LMTValue + oData.LMTValue;
                //_oDataZone.LYYTDValue = _oDataZone.LYYTDValue + oData.LYYTDValue;

            }
            if (sCompany == "TEL")
            {
                _oData.InsertReportLog(sUser);
            }
            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput.ToString());
  
        }
    }
    public class Data
    {
        public string AreaName;
        public string ZoneName;
        public string Outlet;
        public string Type;

        public string Company;
        public string SalesPerson;
        public string MAG;
        public string Brand;
        public int ToDaySalesQty;
        public int LastDaySalesQty;
        public double ToDaySalesVal;
        public double LastDaySalesVal;
        public int ThisWeekTGTQty;
        public int ThisWeekActualQty;
        public double ThisWeekTGTVal;
        public double ThisWeekActualVal;
        public int LastWeekTGTQty;
        public int LastWeekActualQty;
        public double LastWeekTGTVal;
        public double LastWeekActualVal;
        public int ThisYearTGTQty;
        public int ThisYearActualQty;
        public double ThisYearTGTVal;
        public double ThisYearActualVal;
        public int LastYearTGTQty;
        public int LastYearActualQty;
        public double LastYearTGTVal;
        public double LastYearActualVal;
        public int ToDayExpLeadQty;
        public int LastDayExpLeadQty;
        public double ToDayExpLeadVal;
        public double LastDayExpLeadVal;
        public string ToDaySalesQtyText;
        public string LastDaySalesQtyText;
        public string ToDaySalesValText;
        public string LastDaySalesValText;
        public string ThisWeekTGTQtyText;
        public string ThisWeekActualQtyText;
        public string ThisWeekTGTValText;
        public string ThisWeekActualValText;
        public string LastWeekTGTQtyText;
        public string LastWeekActualQtyText;
        public string LastWeekTGTValText;
        public string LastWeekActualValText;
        public string ThisYearTGTQtyText;
        public string ThisYearActualQtyText;
        public string ThisYearTGTValText;
        public string ThisYearActualValText;
        public string LastYearTGTQtyText;
        public string LastYearActualQtyText;
        public string LastYearTGTValText;
        public string LastYearActualValText;
        public string ToDayExpLeadQtyText;
        public string LastDayExpLeadQtyText;
        public string ToDayExpLeadValText;
        public string LastDayExpLeadValText;


        public string Value;

        public void InsertReportLog(string sUser)
        {
            //ReportLog oReportLog = new ReportLog();
            //string sReportCode = "A10005";
            //string sReportName = "Outlet Sales Value";
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
        public void GetDatax(string sCompany, string sDatabase, string sChannel)
        {
            TELLib _oTELLib = new TELLib();
            DSOutletSaleValue oDSDTDSales = new DSOutletSaleValue();
            DSOutletSaleValue oDSLDSales = new DSOutletSaleValue();
            DSOutletSaleValue oDSMTDSales = new DSOutletSaleValue();
            DSOutletSaleValue oDSLMSales = new DSOutletSaleValue();
            DSOutletSaleValue oDSYTDSales = new DSOutletSaleValue();
            DSOutletSaleValue oDSLYSales = new DSOutletSaleValue();

            DateTime dFromDate = DateTime.Now.Date;
            DateTime dToDate = dFromDate.AddDays(1);
            DateTime dLastDate = dFromDate.AddDays(-1);
            DateTime _FirstDayofMonth = _oTELLib.FirstDayofMonth(dFromDate);
            DateTime _FirstDayofLastMonth = _oTELLib.FirstDayofLastMonth(dFromDate);

            DateTime _FirstDayofThisYear = _oTELLib.FirstDayofThisYear(dFromDate);
            DateTime _FirstDayofLastYear = _FirstDayofThisYear.AddYears(-1);


            string sSQL = "";
            #region DTD Sales
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (sChannel == "Dealer")
            {
                sSQL = " Select ShowroomCode as Outlet, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " " + sDatabase + ".dbo.t_Showroom b  , DWDB.dbo.t_CustomerDetails c " +
              " Where  a.WarehouseID=b.WarehouseID and a.CustomerID=c.CustomerID and InvoiceDate BETWEEN '" + dFromDate + "' and '" + dToDate + "'  " +
              " and InvoiceDate < '" + dToDate + "'  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (3,15) ";
                }

                sSQL = sSQL + " Group by  ShowroomCode ";
            }
            else if (sChannel == "B2B")
            {
                sSQL = " Select ShowroomCode as Outlet, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " " + sDatabase + ".dbo.t_Showroom b  , DWDB.dbo.t_CustomerDetails c " +
              " Where  a.WarehouseID=b.WarehouseID and a.CustomerID=c.CustomerID and InvoiceDate BETWEEN '" + dFromDate + "' and '" + dToDate + "'  " +
              " and InvoiceDate < '" + dToDate + "'  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else
                {
                    sSQL = sSQL + " and c.ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }

                sSQL = sSQL + " Group by  ShowroomCode ";
            }
            else
            {
                sSQL = " Select ShowroomCode as Outlet, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
                              " " + sDatabase + ".dbo.t_Showroom b  " +
                              " Where  a.WarehouseID=b.WarehouseID and InvoiceDate BETWEEN '" + dFromDate + "' and '" + dToDate + "'  " +
                              " and InvoiceDate < '" + dToDate + "'  and CompanyName='" + sCompany + "' " +
                              " Group by  ShowroomCode ";

            }
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletSaleValue.SalesValueRow oSalesValueRow = oDSDTDSales.SalesValue.NewSalesValueRow();

                    oSalesValueRow.OutletCode = reader["Outlet"].ToString();
                    oSalesValueRow.Value = reader["NetSale"].ToString();

                    oDSDTDSales.SalesValue.AddSalesValueRow(oSalesValueRow);
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
            #region LD Sales
            cmd = DBController.Instance.GetCommand();
            sSQL = "";
            if (sChannel == "Dealer")
            {
                sSQL = " Select ShowroomCode as Outlet, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " " + sDatabase + ".dbo.t_Showroom b  , DWDB.dbo.t_CustomerDetails c " +
              " Where  a.WarehouseID=b.WarehouseID and a.CustomerID=c.CustomerID and InvoiceDate BETWEEN '" + dLastDate + "' and '" + dFromDate + "'  " +
              " and InvoiceDate < '" + dFromDate + "'  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (3,15) ";
                }

                sSQL = sSQL + " Group by  ShowroomCode ";
            }
            else if (sChannel == "B2B")
            {
                sSQL = " Select ShowroomCode as Outlet, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " " + sDatabase + ".dbo.t_Showroom b  , DWDB.dbo.t_CustomerDetails c " +
              " Where  a.WarehouseID=b.WarehouseID and a.CustomerID=c.CustomerID and InvoiceDate BETWEEN '" + dLastDate + "' and '" + dFromDate + "'  " +
              " and InvoiceDate < '" + dFromDate + "'  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else
                {
                    sSQL = sSQL + " and c.ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + " Group by  ShowroomCode ";
            }
            else
            {
                sSQL = " Select ShowroomCode as Outlet, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
                              " " + sDatabase + ".dbo.t_Showroom b  " +
                              " Where a.WarehouseID = b.WarehouseID and InvoiceDate BETWEEN '" + dLastDate + "' and '" + dFromDate + "'  " +
                              " and InvoiceDate < '" + dFromDate + "'  and CompanyName='" + sCompany + "' " +
                              " Group by  ShowroomCode ";

            }
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletSaleValue.SalesValueRow oSalesValueRow = oDSLDSales.SalesValue.NewSalesValueRow();

                    oSalesValueRow.OutletCode = reader["Outlet"].ToString();
                    oSalesValueRow.Value = reader["NetSale"].ToString();

                    oDSLDSales.SalesValue.AddSalesValueRow(oSalesValueRow);
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
            #region MTD Sales
            cmd = DBController.Instance.GetCommand();
            sSQL = "";
            if (sChannel == "Dealer")
            {
                sSQL = " Select ShowroomCode as Outlet, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " " + sDatabase + ".dbo.t_Showroom b  , DWDB.dbo.t_CustomerDetails c " +
              " Where  a.WarehouseID=b.WarehouseID and a.CustomerID=c.CustomerID and (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE()))    " +
                       " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (3,15) ";
                }

                sSQL = sSQL + " Group by  ShowroomCode ";
            }
            else if (sChannel == "B2B")
            {
                sSQL = " Select ShowroomCode as Outlet, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
                " " + sDatabase + ".dbo.t_Showroom b  , DWDB.dbo.t_CustomerDetails c " +
                " Where  a.WarehouseID=b.WarehouseID and a.CustomerID=c.CustomerID and (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE()))    " +
                " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else
                {
                    sSQL = sSQL + " and c.ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }

                sSQL = sSQL + " Group by  ShowroomCode ";
            }
            else
            {
                sSQL = " select ShowroomCode as Outlet, Sum(NetSale) as NetSale  " +
                       " from DWDB.dbo.t_SalesDataCustomerProduct a, " + sDatabase + ".dbo.t_Showroom b    " +
                       " Where a.WarehouseID = b.WarehouseID and (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE()))    " +
                       " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))    " +
                       " and CompanyName='" + sCompany + "'      " +
                       " Group by ShowroomCode ";

            }
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletSaleValue.SalesValueRow oSalesValueRow = oDSMTDSales.SalesValue.NewSalesValueRow();

                    oSalesValueRow.OutletCode = reader["Outlet"].ToString();
                    oSalesValueRow.Value = reader["NetSale"].ToString();

                    oDSMTDSales.SalesValue.AddSalesValueRow(oSalesValueRow);
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
            #region LM Sales
            cmd = DBController.Instance.GetCommand();
            sSQL = "";
            if (sChannel == "Dealer")
            {
                sSQL = " Select ShowroomCode as Outlet, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " " + sDatabase + ".dbo.t_Showroom b  , DWDB.dbo.t_CustomerDetails c " +
              " Where  a.WarehouseID=b.WarehouseID and a.CustomerID=c.CustomerID and InvoiceDate BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "'  " +
              " and InvoiceDate < '" + _FirstDayofMonth + "'  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (3,15) ";
                }

                sSQL = sSQL + " Group by  ShowroomCode ";
            }
            else if (sChannel == "B2B")
            {
                sSQL = " Select ShowroomCode as Outlet, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " " + sDatabase + ".dbo.t_Showroom b  , DWDB.dbo.t_CustomerDetails c " +
              " Where  a.WarehouseID=b.WarehouseID and a.CustomerID=c.CustomerID and InvoiceDate BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "'  " +
              " and InvoiceDate < '" + _FirstDayofMonth + "'  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else
                {
                    sSQL = sSQL + " and c.ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + " Group by  ShowroomCode ";
            }
            else
            {
                sSQL = " select ShowroomCode as Outlet, Sum(NetSale) as NetSale    " +
                       " from DWDB.dbo.t_SalesDataCustomerProduct a, " + sDatabase + ".dbo.t_Showroom b   " +
                       " Where a.WarehouseID = b.WarehouseID and InvoiceDate BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "'  " +
                       " and InvoiceDate < '" + _FirstDayofMonth + "'  and CompanyName='" + sCompany + "' Group by ShowroomCode ";
            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletSaleValue.SalesValueRow oSalesValueRow = oDSLMSales.SalesValue.NewSalesValueRow();

                    oSalesValueRow.OutletCode = reader["Outlet"].ToString();
                    oSalesValueRow.Value = reader["NetSale"].ToString();

                    oDSLMSales.SalesValue.AddSalesValueRow(oSalesValueRow);
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

            #region YTD Sales
            cmd = DBController.Instance.GetCommand();
            sSQL = "";
            if (sChannel == "Dealer")
            {
                sSQL = " Select ShowroomCode as Outlet, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " " + sDatabase + ".dbo.t_Showroom b  , DWDB.dbo.t_CustomerDetails c " +
              " Where  a.WarehouseID=b.WarehouseID and a.CustomerID=c.CustomerID and InvoiceDate BETWEEN '" + _FirstDayofThisYear + "' and '" + dToDate + "'  " +
              " and InvoiceDate < '" + dToDate + "'  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (3,15) ";
                }

                sSQL = sSQL + " Group by  ShowroomCode ";
            }
            else if (sChannel == "B2B")
            {
                sSQL = " Select ShowroomCode as Outlet, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " " + sDatabase + ".dbo.t_Showroom b  , DWDB.dbo.t_CustomerDetails c " +
              " Where  a.WarehouseID=b.WarehouseID and a.CustomerID=c.CustomerID and InvoiceDate BETWEEN '" + _FirstDayofThisYear + "' and '" + dToDate + "'  " +
              " and InvoiceDate < '" + dToDate + "'  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else
                {
                    sSQL = sSQL + " and c.ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + " Group by  ShowroomCode ";
            }
            else
            {
                sSQL = " select ShowroomCode as Outlet, Sum(NetSale) as NetSale    " +
                       " from DWDB.dbo.t_SalesDataCustomerProduct a, " + sDatabase + ".dbo.t_Showroom b   " +
                       " Where a.WarehouseID = b.WarehouseID and InvoiceDate BETWEEN '" + _FirstDayofThisYear + "' and '" + dToDate + "'  " +
                       " and InvoiceDate < '" + dToDate + "'  and CompanyName='" + sCompany + "' Group by ShowroomCode ";
            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletSaleValue.SalesValueRow oSalesValueRow = oDSYTDSales.SalesValue.NewSalesValueRow();

                    oSalesValueRow.OutletCode = reader["Outlet"].ToString();
                    oSalesValueRow.Value = reader["NetSale"].ToString();

                    oDSYTDSales.SalesValue.AddSalesValueRow(oSalesValueRow);
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
            #region LY Sales
            cmd = DBController.Instance.GetCommand();
            sSQL = "";
            if (sChannel == "Dealer")
            {
                sSQL = " Select ShowroomCode as Outlet, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " " + sDatabase + ".dbo.t_Showroom b  , DWDB.dbo.t_CustomerDetails c " +
              " Where  a.WarehouseID=b.WarehouseID and a.CustomerID=c.CustomerID and InvoiceDate BETWEEN '" + _FirstDayofLastYear + "' and '" + _FirstDayofThisYear + "'  " +
              " and InvoiceDate < '" + _FirstDayofThisYear + "'  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (3,15) ";
                }

                sSQL = sSQL + " Group by  ShowroomCode ";
            }
            else if (sChannel == "B2B")
            {
                sSQL = " Select ShowroomCode as Outlet, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " " + sDatabase + ".dbo.t_Showroom b  , DWDB.dbo.t_CustomerDetails c " +
              " Where  a.WarehouseID=b.WarehouseID and a.CustomerID=c.CustomerID and InvoiceDate BETWEEN '" + _FirstDayofLastYear + "' and '" + _FirstDayofThisYear + "'  " +
              " and InvoiceDate < '" + _FirstDayofThisYear + "'  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else
                {
                    sSQL = sSQL + " and c.ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + " Group by  ShowroomCode ";
            }
            else
            {
                sSQL = " select ShowroomCode as Outlet, Sum(NetSale) as NetSale    " +
                       " from DWDB.dbo.t_SalesDataCustomerProduct a, " + sDatabase + ".dbo.t_Showroom b   " +
                       " Where a.WarehouseID = b.WarehouseID and InvoiceDate BETWEEN '" + _FirstDayofLastYear + "' and '" + _FirstDayofThisYear + "'  " +
                       " and InvoiceDate < '" + _FirstDayofThisYear + "'  and CompanyName='" + sCompany + "' Group by ShowroomCode ";
            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletSaleValue.SalesValueRow oSalesValueRow = oDSLYSales.SalesValue.NewSalesValueRow();

                    oSalesValueRow.OutletCode = reader["Outlet"].ToString();
                    oSalesValueRow.Value = reader["NetSale"].ToString();

                    oDSLYSales.SalesValue.AddSalesValueRow(oSalesValueRow);
                    oDSLYSales.AcceptChanges();
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

            //foreach (DSOutletSaleValue.SalesValueRow oSalesValueRow in oDSYTDSales.SalesValue)

            cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " Select a.CustomerID, ShowroomCode as Outlet, IsNull(AreaName,'') as AreaName, IsNull(TerritoryName,'') as TerritoryName  from t_Showroom  a, " +
                    " (Select CustomerID, AreaShortName as AreaName, AreaSort, TerritoryShortName as TerritoryName,  " +
                    " TerritorySort from TELSysDB.dbo.v_CustomerDetails Where ChannelID=4 and AreaShortName Is Not Null) b " +
                    " Where a.CustomerID=b.CustomerID Order by AreaSort, TerritorySort, ShowroomCode";
            try
            {

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oData = new Data();
                    _oData.AreaName = reader["AreaName"].ToString();
                    _oData.ZoneName = reader["TerritoryName"].ToString();
                    _oData.Outlet = reader["Outlet"].ToString();

                    //DTD
                    DSOutletSaleValue oDSFilteredDTD = new DSOutletSaleValue();
                    DataRow[] oDRDTD = oDSDTDSales.SalesValue.Select(" OutletCode= '" + _oData.Outlet + "'");
                    oDSFilteredDTD.Merge(oDRDTD);
                    oDSFilteredDTD.AcceptChanges();

                    foreach (DSOutletSaleValue.SalesValueRow oDTDSalesValueRow in oDSFilteredDTD.SalesValue)
                    {
                        //_oData.DTDValue = Convert.ToDouble(oDTDSalesValueRow.Value);
                    }

                    //LD
                    DSOutletSaleValue oDSFilteredLD = new DSOutletSaleValue();
                    DataRow[] oDRLD = oDSLDSales.SalesValue.Select(" OutletCode= '" + _oData.Outlet + "'");
                    oDSFilteredLD.Merge(oDRLD);
                    oDSFilteredLD.AcceptChanges();

                    foreach (DSOutletSaleValue.SalesValueRow oLDSalesValueRow in oDSFilteredLD.SalesValue)
                    {
                        //_oData.LDValue = Convert.ToDouble(oLDSalesValueRow.Value);
                    }

                    //MTD
                    DSOutletSaleValue oDSFilteredMTD = new DSOutletSaleValue();
                    DataRow[] oDRMTD = oDSMTDSales.SalesValue.Select(" OutletCode= '" + _oData.Outlet + "'");
                    oDSFilteredMTD.Merge(oDRMTD);
                    oDSFilteredMTD.AcceptChanges();

                    foreach (DSOutletSaleValue.SalesValueRow oMTDSalesValueRow in oDSFilteredMTD.SalesValue)
                    {
                        //_oData.MTDValue = Convert.ToDouble(oMTDSalesValueRow.Value);
                    }
                    //LM
                    DSOutletSaleValue oDSFilteredLM = new DSOutletSaleValue();
                    DataRow[] oDRLM = oDSLMSales.SalesValue.Select(" OutletCode= '" + _oData.Outlet + "'");
                    oDSFilteredLM.Merge(oDRLM);
                    oDSFilteredLM.AcceptChanges();

                    foreach (DSOutletSaleValue.SalesValueRow oLMSalesValueRow in oDSFilteredLM.SalesValue)
                    {
                        //_oData.LMValue = Convert.ToDouble(oLMSalesValueRow.Value);
                    }
                    //YTD
                    DSOutletSaleValue oDSFilteredYTD = new DSOutletSaleValue();
                    DataRow[] oDRYTD = oDSYTDSales.SalesValue.Select(" OutletCode= '" + _oData.Outlet + "'");
                    oDSFilteredYTD.Merge(oDRYTD);
                    oDSFilteredYTD.AcceptChanges();

                    foreach (DSOutletSaleValue.SalesValueRow oYTDSalesValueRow in oDSFilteredYTD.SalesValue)
                    {
                        //_oData.YTDValue = Convert.ToDouble(oYTDSalesValueRow.Value);
                    }

                    //LY
                    DSOutletSaleValue oDSFilteredLY = new DSOutletSaleValue();
                    DataRow[] oDRLY = oDSLYSales.SalesValue.Select(" OutletCode= '" + _oData.Outlet + "'");
                    oDSFilteredLY.Merge(oDRLY);
                    oDSFilteredLY.AcceptChanges();

                    foreach (DSOutletSaleValue.SalesValueRow oLYSalesValueRow in oDSFilteredLY.SalesValue)
                    {
                        //_oData.LYValue = Convert.ToDouble(oLYSalesValueRow.Value);
                    }


                    InnerList.Add(_oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetData(string sCompany)
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " Select AreaName, TerritoryName, Outlet, Today, LastDay, CMTarget, MTDTarget, ThisMonth, LastMonthTarget, LastMonth, "+
                   " ThisYear, LastYear, LYYTD, LYMTD, LYCM from DWDB.dbo.t_OutletSales Where Company='" + sCompany + "' Order by AreaSort, TerritorySort, Outlet";
            try
            {
                Data _oData;
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    _oData = new Data();
                    _oData.AreaName = reader["AreaName"].ToString();
                    _oData.ZoneName = reader["TerritoryName"].ToString();
                    _oData.Outlet = reader["Outlet"].ToString();

                    //_oData.DTDValue = Convert.ToDouble(reader["Today"]);
                    //_oData.LDValue = Convert.ToDouble(reader["LastDay"]);
                    //_oData.MTDValue = Convert.ToDouble(reader["ThisMonth"]);
                    //_oData.LMValue = Convert.ToDouble(reader["LastMonth"]);
                    //_oData.YTDValue = Convert.ToDouble(reader["ThisYear"]);
                    //_oData.LYValue = Convert.ToDouble(reader["LastYear"]);

                    //_oData.LYYTDValue = Convert.ToDouble(reader["LYYTD"]);
                    //_oData.LYMTDValue = Convert.ToDouble(reader["LYMTD"]);
                    //_oData.LYCMValue = Convert.ToDouble(reader["LYCM"]);

                    //_oData.CMTValue = Convert.ToDouble(reader["CMTarget"]);
                    //_oData.MTDTValue = Convert.ToDouble(reader["MTDTarget"]);
                    //_oData.LMTValue = Convert.ToDouble(reader["LastMonthTarget"]);


                    InnerList.Add(_oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public List<Data> getResult()
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();

            DateTime dFromDate = DateTime.Now.Date;
            int nThisYear = dFromDate.Year;
            int nThisMonth = dFromDate.Month;

            DateTime LastDayOfMonth = _oTELLib.LastDayofMonth(dFromDate);
            int nLastDayCM = LastDayOfMonth.Day;
            int nDay = dFromDate.Day;

            foreach (Data oData in this)
            {
                _oData = new Data();
                _oData.Outlet = oData.Outlet;
                _oData.Type = oData.Type;
                _oData.Value = oData.Value;

                //_oData.DTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.DTDValue));
                //_oData.LDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LDValue));
                //_oData.MTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.MTDValue));
                //_oData.LMValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMValue));
                //_oData.YTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.YTDValue));
                //_oData.LYValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYValue));
                //_oData.CMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMTValue));
                //_oData.LMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMTValue));
                //_oData.LYYTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYYTDValue));

                //double _MTDTarget = 0;
                //if (oData.CMTValue > 0)
                //{
                //    //_MTDTarget = oData.CMTValue / nLastDayCM * nDay;
                //    _MTDTarget = oData.MTDTValue;
                    
                //    _oData.MTDTValueText = ExcludeDecimal(_oTELLib.TakaFormat(_MTDTarget));
                //}
                //else
                //{
                //    _oData.MTDTValueText = "0";
                //}


                //if (oData.CMTValue > 0)
                //{
                //    _oData.CMPercText = Convert.ToString(Math.Round((oData.MTDValue / oData.CMTValue) * 100));
                //}
                //else
                //{
                //    _oData.CMPercText = "0";
                //}
                //if (_MTDTarget > 0)
                //{
                //    _oData.MTDPercText = Convert.ToString(Math.Round((oData.MTDValue / _MTDTarget) * 100));
                //}
                //else
                //{
                //    _oData.MTDPercText = "0";
                //}
                //if (oData.LMTValue > 0)
                //{
                //    _oData.LMPercText = Convert.ToString(Math.Round((oData.LMValue / oData.LMTValue) * 100));
                //}
                //else
                //{
                //    _oData.LMPercText = "0";
                //}
                //if (oData.LYYTDValue > 0)
                //{
                //    _oData.YTDGthPercText = Convert.ToString(Math.Round(((oData.YTDValue / oData.LYYTDValue) * 100) - 100));
                //}
                //else
                //{
                //    _oData.YTDGthPercText = "0";
                //}
                eList.Add(_oData);
            }
            return eList;

        }
    }
}


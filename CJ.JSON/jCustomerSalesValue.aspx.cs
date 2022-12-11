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

public partial class jCustomerSalesValue : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            string sUser = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();

            //string sCompany = "TEL";
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
            oDatas.GetData(sCompany, sDatabase, sChannel);
            DBController.Instance.CloseConnection();

            foreach (Data oData in oDatas)
            {
                if (nCount == 0)
                {
                    _oDataTotal = new Data();
                    _oDatas.Add(_oDataTotal);
                    _oDataTotal.Outlet = "Total";
                    _oDataTotal.Type = "Total";
                    _oDataTotal.CustomerShortName = "Total";
                    _oDataTotal.CustomerName = "Total";
                    _oDataTotal.Value = "Success";
                    nCount++;
                }
                if (_oDataArea.AreaName != oData.AreaName)
                {
                    _oDataArea = new Data();
                    _oDatas.Add(_oDataArea);
                    _oDataArea.AreaName = oData.AreaName;
                    _oDataArea.Outlet = oData.AreaName;
                    _oDataArea.Type = "Area";
                    _oDataArea.CustomerShortName = oData.AreaName;
                    _oDataArea.CustomerName = oData.AreaName;
                    _oDataArea.Value = "Success";
                }
                if (_oDataZone.ZoneName != oData.ZoneName)
                {
                    _oDataZone = new Data();
                    _oDatas.Add(_oDataZone);
                    _oDataZone.ZoneName = oData.ZoneName;
                    _oDataZone.Outlet = oData.ZoneName;
                    _oDataZone.Type = "Zone";
                    _oDataZone.CustomerShortName = oData.ZoneName;
                    _oDataZone.CustomerName = oData.ZoneName;
                    _oDataZone.Value = "Success";
                }

                _oDataOutlet = new Data();
                _oDataOutlet.Value = "Success";

                _oDataOutlet.Outlet = oData.Outlet;
                _oDataOutlet.CustomerShortName = oData.CustomerShortName;
                _oDataOutlet.CustomerName = oData.CustomerName;
                _oDataOutlet.DTDValue = oData.DTDValue;
                _oDataOutlet.LDValue = oData.LDValue;
                _oDataOutlet.MTDValue = oData.MTDValue;
                _oDataOutlet.LMValue = oData.LMValue;
                _oDataOutlet.YTDValue = oData.YTDValue;
                _oDataOutlet.Type = "Outlet";
                _oDatas.Add(_oDataOutlet);

                _oDataTotal.DTDValue = _oDataTotal.DTDValue + oData.DTDValue;
                _oDataTotal.LDValue = _oDataTotal.LDValue + oData.LDValue;
                _oDataTotal.MTDValue = _oDataTotal.MTDValue + oData.MTDValue;
                _oDataTotal.LMValue = _oDataTotal.LMValue + oData.LMValue;
                _oDataTotal.YTDValue = _oDataTotal.YTDValue + oData.YTDValue;

                _oDataArea.DTDValue = _oDataArea.DTDValue + oData.DTDValue;
                _oDataArea.LDValue = _oDataArea.LDValue + oData.LDValue;
                _oDataArea.MTDValue = _oDataArea.MTDValue + oData.MTDValue;
                _oDataArea.LMValue = _oDataArea.LMValue + oData.LMValue;
                _oDataArea.YTDValue = _oDataArea.YTDValue + oData.YTDValue;

                _oDataZone.DTDValue = _oDataZone.DTDValue + oData.DTDValue;
                _oDataZone.LDValue = _oDataZone.LDValue + oData.LDValue;
                _oDataZone.MTDValue = _oDataZone.MTDValue + oData.MTDValue;
                _oDataZone.LMValue = _oDataZone.LMValue + oData.LMValue;
                _oDataZone.YTDValue = _oDataZone.YTDValue + oData.YTDValue;
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
        public string CustomerName;
        public string CustomerShortName;
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

        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10005";
            string sReportName = "Outlet Sales Value";
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
        public void GetData(string sCompany, string sDatabase, string sChannel)
        {
            TELLib _oTELLib = new TELLib();
            DSOutletSaleValue oDSDTDSales = new DSOutletSaleValue();
            DSOutletSaleValue oDSLDSales = new DSOutletSaleValue();
            DSOutletSaleValue oDSMTDSales = new DSOutletSaleValue();
            DSOutletSaleValue oDSLMSales = new DSOutletSaleValue();
            DSOutletSaleValue oDSYTDSales = new DSOutletSaleValue();

            DateTime dFromDate = DateTime.Now.Date;
            DateTime dToDate = dFromDate.AddDays(1);
            DateTime dLastDate = dFromDate.AddDays(-1);
            DateTime _FirstDayofMonth = _oTELLib.FirstDayofMonth(dFromDate);
            DateTime _FirstDayofLastMonth = _oTELLib.FirstDayofLastMonth(dFromDate);

            string sSQL = "";
            #region DTD Sales
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (sChannel == "Dealer")
            {
                sSQL = " Select CustomerCode, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
                        " DWDB.dbo.t_CustomerDetails c " +
                        " Where a.CustomerID=c.CustomerID and InvoiceDate BETWEEN '" + dFromDate + "' and '" + dToDate + "'  " +
                        " and InvoiceDate < '" + dToDate + "'  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                        if (sCompany == "TEL")
                        {
                            sSQL = sSQL + " and c.ChannelID IN (3,15) ";
                        }
                        sSQL = sSQL + " Group by  CustomerCode ";
            }
            else if (sChannel == "B2B")
            {
                sSQL = " Select CustomerCode, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " DWDB.dbo.t_CustomerDetails c " +
              " Where a.CustomerID=c.CustomerID and InvoiceDate BETWEEN '" + dFromDate + "' and '" + dToDate + "'  " +
              " and InvoiceDate < '" + dToDate + "'  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else
                {
                    sSQL = sSQL + " and c.ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }

                sSQL = sSQL + " Group by  CustomerCode ";
            }
            else if (sChannel == "CAC")
            {
                sSQL = " Select CustomerCode, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
                    " DWDB.dbo.t_CustomerDetails c " +
                    " Where a.CustomerID=c.CustomerID and InvoiceDate BETWEEN '" + dFromDate + "' and '" + dToDate + "'  " +
                    " and InvoiceDate < '" + dToDate + "'  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (5) ";
                }

                sSQL = sSQL + " Group by  CustomerCode ";
            }
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletSaleValue.SalesValueRow oSalesValueRow = oDSDTDSales.SalesValue.NewSalesValueRow();

                    oSalesValueRow.OutletCode = reader["CustomerCode"].ToString();
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
                sSQL = " Select CustomerCode, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " DWDB.dbo.t_CustomerDetails c " +
              " Where a.CustomerID=c.CustomerID and InvoiceDate BETWEEN '" + dLastDate + "' and '" + dFromDate + "'  " +
              " and InvoiceDate < '" + dFromDate + "'  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (3,15) ";
                }

                sSQL = sSQL + " Group by  CustomerCode ";
            }
            else if (sChannel == "B2B")
            {
                sSQL = " Select CustomerCode, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " DWDB.dbo.t_CustomerDetails c " +
              " Where a.CustomerID=c.CustomerID and InvoiceDate BETWEEN '" + dLastDate + "' and '" + dFromDate + "'  " +
              " and InvoiceDate < '" + dFromDate + "'  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else
                {
                    sSQL = sSQL + " and c.ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + " Group by  CustomerCode ";
            }
            else if (sChannel == "CAC")
            {
                sSQL = " Select CustomerCode, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " DWDB.dbo.t_CustomerDetails c " +
              " Where a.CustomerID=c.CustomerID and InvoiceDate BETWEEN '" + dLastDate + "' and '" + dFromDate + "'  " +
              " and InvoiceDate < '" + dFromDate + "'  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (5) ";
                }

                sSQL = sSQL + " Group by  CustomerCode ";

            }
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletSaleValue.SalesValueRow oSalesValueRow = oDSLDSales.SalesValue.NewSalesValueRow();

                    oSalesValueRow.OutletCode = reader["CustomerCode"].ToString();
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
                sSQL = " Select CustomerCode, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " DWDB.dbo.t_CustomerDetails c " +
              " Where a.CustomerID=c.CustomerID and (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE()))    " +
                       " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (3,15) ";
                }

                sSQL = sSQL + " Group by  CustomerCode ";
            }
            else if (sChannel == "B2B")
            {
                sSQL = " Select CustomerCode, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " DWDB.dbo.t_CustomerDetails c " +
              " Where a.CustomerID=c.CustomerID and (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE()))    " +
              " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
            if (sCompany == "TEL")
            {
                sSQL = sSQL + " and c.ChannelID IN (13) and a.CustomerTypeID = 249 ";
            }
            else
            {
                sSQL = sSQL + " and c.ChannelID IN (5) and a.CustomerTypeID = 202 ";
            }

            sSQL = sSQL + " Group by  CustomerCode ";
            }
            else if (sChannel == "CAC")
            {
                sSQL = " Select CustomerCode, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " DWDB.dbo.t_CustomerDetails c " +
              " Where a.CustomerID=c.CustomerID and (InvoiceDate BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE()))    " +
              " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (5) ";
                }

                sSQL = sSQL + " Group by  CustomerCode ";

            }
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletSaleValue.SalesValueRow oSalesValueRow = oDSMTDSales.SalesValue.NewSalesValueRow();

                    oSalesValueRow.OutletCode = reader["CustomerCode"].ToString();
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
                sSQL = " Select CustomerCode, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " DWDB.dbo.t_CustomerDetails c " +
              " Where a.CustomerID=c.CustomerID and InvoiceDate BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "'  " +
              " and InvoiceDate < '" + _FirstDayofMonth + "'  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (3,15) ";
                }

                sSQL = sSQL + " Group by CustomerCode ";
            }
            else if (sChannel == "B2B")
            {
                sSQL = " Select CustomerCode, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
              " DWDB.dbo.t_CustomerDetails c " +
              " Where  a.CustomerID=c.CustomerID and InvoiceDate BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "'  " +
              " and InvoiceDate < '" + _FirstDayofMonth + "'  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
            if (sCompany == "TEL")
            {
                sSQL = sSQL + " and c.ChannelID IN (13) and a.CustomerTypeID = 249 ";
            }
            else
            {
                sSQL = sSQL + " and c.ChannelID IN (5) and a.CustomerTypeID = 202 ";
            }
            sSQL = sSQL + " Group by  CustomerCode ";
            }
            else if (sChannel == "CAC")
            {
                sSQL = " Select CustomerCode, Sum(NetSale) as NetSale from DWDB.dbo.t_SalesDataCustomerProduct a, " +
                    " DWDB.dbo.t_CustomerDetails c " +
                    " Where a.CustomerID=c.CustomerID and InvoiceDate BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "'  " +
                    " and InvoiceDate < '" + _FirstDayofMonth + "'  and a.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and c.ChannelID IN (5) ";
                }

                sSQL = sSQL + " Group by CustomerCode ";
            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletSaleValue.SalesValueRow oSalesValueRow = oDSLMSales.SalesValue.NewSalesValueRow();

                    oSalesValueRow.OutletCode = reader["CustomerCode"].ToString();
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
                sSQL = " select AreaID, AreaSort, AreaShortName as AreaName, TerritoryID, TerritorySort, TerritoryShortName as TerritoryName, CustomerCode,  CustomerName, left(CustomerName, 6)+'..' as CustomerShort, Sum(NetSale) as NetSale " +
                " from DWDB.dbo.t_SalesDataCustomerProduct a,   "+
                " DWDB.dbo.t_CustomerDetails b  "+
                " Where a.CustomerID=b.CustomerID and (InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))     "+
                " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))    "+
                " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and b.ChannelID IN (3,15)  ";
                }
                sSQL = sSQL + " Group by CustomerCode, AreaID, AreaSort, AreaShortName, TerritoryID, TerritorySort, TerritoryShortName, CustomerName    " +
                " Order by AreaID, AreaSort, TerritoryID, TerritorySort, CustomerCode ";
                
            }
            else if (sChannel == "B2B")
            {
                sSQL = " select AreaID, AreaSort, AreaShortName as AreaName, TerritoryID, TerritorySort, TerritoryShortName as TerritoryName, CustomerCode,  CustomerName, left(CustomerName, 6)+'..' as CustomerShort, Sum(NetSale) as NetSale " +
                " from DWDB.dbo.t_SalesDataCustomerProduct a,   " +
                " DWDB.dbo.t_CustomerDetails b  " +
                " Where a.CustomerID=b.CustomerID and (InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))     " +
                " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))    " +
                " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and b.ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else
                {
                    sSQL = sSQL + " and b.ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + " Group by CustomerCode, AreaID, AreaSort, AreaShortName, TerritoryID, TerritorySort, TerritoryShortName, CustomerName  " +
                " Order by AreaID, AreaSort, TerritoryID, TerritorySort, CustomerCode ";
            }
            else if (sChannel == "CAC")
            {
                sSQL = " select AreaID, AreaSort, AreaShortName as AreaName, TerritoryID, TerritorySort, TerritoryShortName as TerritoryName, CustomerCode,  CustomerName, left(CustomerName, 6)+'..' as CustomerShort, Sum(NetSale) as NetSale   " +
                 " from DWDB.dbo.t_SalesDataCustomerProduct a,   " +
                 " DWDB.dbo.t_CustomerDetails b  " +
                 " Where a.CustomerID=b.CustomerID and (InvoiceDate BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))     " +
                 " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))    " +
                 " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and b.ChannelID IN (5)  ";
                }
                sSQL = sSQL + " Group by CustomerCode, AreaID, AreaSort, AreaShortName, TerritoryID, TerritorySort, TerritoryShortName, CustomerName " +
                " Order by AreaID, AreaSort, TerritoryID, TerritorySort, CustomerCode ";
            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletSaleValue.SalesValueRow oSalesValueRow = oDSYTDSales.SalesValue.NewSalesValueRow();

                    oSalesValueRow.AreaName = reader["AreaName"].ToString();
                    oSalesValueRow.ZoneName = reader["TerritoryName"].ToString();
                    oSalesValueRow.OutletCode = reader["CustomerCode"].ToString();
                    oSalesValueRow.CustomerName = reader["CustomerName"].ToString();
                    oSalesValueRow.CustomerShortName = reader["CustomerShort"].ToString();
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

            Data _oData;
            InnerList.Clear();

            foreach (DSOutletSaleValue.SalesValueRow oSalesValueRow in oDSYTDSales.SalesValue)
            {

                _oData = new Data();
                _oData.AreaName = oSalesValueRow.AreaName;
                _oData.ZoneName = oSalesValueRow.ZoneName;
                _oData.Outlet = oSalesValueRow.OutletCode;
                _oData.CustomerName = oSalesValueRow.CustomerName;
                _oData.CustomerShortName = oSalesValueRow.CustomerShortName;

                //DTD
                DSOutletSaleValue oDSFilteredDTD = new DSOutletSaleValue();
                DataRow[] oDRDTD = oDSDTDSales.SalesValue.Select(" OutletCode= '" + oSalesValueRow.OutletCode + "'");
                oDSFilteredDTD.Merge(oDRDTD);
                oDSFilteredDTD.AcceptChanges();

                foreach (DSOutletSaleValue.SalesValueRow oDTDSalesValueRow in oDSFilteredDTD.SalesValue)
                {
                    _oData.DTDValue = Convert.ToDouble(oDTDSalesValueRow.Value);
                }

                //LD
                DSOutletSaleValue oDSFilteredLD = new DSOutletSaleValue();
                DataRow[] oDRLD = oDSLDSales.SalesValue.Select(" OutletCode= '" + oSalesValueRow.OutletCode + "'");
                oDSFilteredLD.Merge(oDRLD);
                oDSFilteredLD.AcceptChanges();

                foreach (DSOutletSaleValue.SalesValueRow oLDSalesValueRow in oDSFilteredLD.SalesValue)
                {
                    _oData.LDValue = Convert.ToDouble(oLDSalesValueRow.Value);
                }

                //MTD
                DSOutletSaleValue oDSFilteredMTD = new DSOutletSaleValue();
                DataRow[] oDRMTD = oDSMTDSales.SalesValue.Select(" OutletCode= '" + oSalesValueRow.OutletCode + "'");
                oDSFilteredMTD.Merge(oDRMTD);
                oDSFilteredMTD.AcceptChanges();

                foreach (DSOutletSaleValue.SalesValueRow oMTDSalesValueRow in oDSFilteredMTD.SalesValue)
                {
                    _oData.MTDValue = Convert.ToDouble(oMTDSalesValueRow.Value);
                }
                //LM
                DSOutletSaleValue oDSFilteredLM = new DSOutletSaleValue();
                DataRow[] oDRLM = oDSLMSales.SalesValue.Select(" OutletCode= '" + oSalesValueRow.OutletCode + "'");
                oDSFilteredLM.Merge(oDRLM);
                oDSFilteredLM.AcceptChanges();

                foreach (DSOutletSaleValue.SalesValueRow oLMSalesValueRow in oDSFilteredLM.SalesValue)
                {
                    _oData.LMValue = Convert.ToDouble(oLMSalesValueRow.Value);
                }
                //YTD
                DSOutletSaleValue oDSFilteredYTD = new DSOutletSaleValue();
                DataRow[] oDRYTD = oDSYTDSales.SalesValue.Select(" OutletCode= '" + oSalesValueRow.OutletCode + "'");
                oDSFilteredYTD.Merge(oDRYTD);
                oDSFilteredYTD.AcceptChanges();

                foreach (DSOutletSaleValue.SalesValueRow oYTDSalesValueRow in oDSFilteredYTD.SalesValue)
                {
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
                _oData.Outlet = oData.Outlet;
                _oData.Type = oData.Type;
                _oData.Value = oData.Value;
                _oData.CustomerShortName = oData.CustomerShortName;
                _oData.CustomerName = oData.CustomerName;
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


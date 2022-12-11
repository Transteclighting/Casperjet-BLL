
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

public partial class jProductSalesQtyAndValue : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            string sUser = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();
            string sType = c.Request.Form["Type"].Trim();


            //string sType = "ByOutlet";
            //string sCompany = "TEL";
            //string sUser = "hakim";
            //string sSpecificData = "Transtec";




            string sDatabase = "x";
            string sValue = "";
            string sOutlet = "";
            string sSpecificData = "";
            string sCustGroupID = "";
            string sValueType = "";

            string sGroupType = "";
            string sGroupValue = "";
            string sIsBrand = "";

            //string sGroupType = "MAG";
            //string sGroupValue = "HTV";
            //string sIsBrand = "No";


            if (c.Request.Form["Value"] != null)
            {
                sValue = c.Request.Form["Value"].Trim();
            }
            if (c.Request.Form["SpecificData"] != null)
            {
                sSpecificData = c.Request.Form["SpecificData"].Trim();
            }
            if (c.Request.Form["GroupType"] != null)
            {
                sGroupType = c.Request.Form["GroupType"].Trim();
            }
            if (c.Request.Form["GroupValue"] != null)
            {
                sGroupValue = c.Request.Form["GroupValue"].Trim();
            }
            if (c.Request.Form["IsBrand"] != null)
            {
                sIsBrand = c.Request.Form["IsBrand"].Trim();
            }
            if (c.Request.Form["Outlet"] != null)
            {
                sOutlet = c.Request.Form["Outlet"].Trim();
            }
            #region
            if (c.Request.Form["Outlet"] != null)
            {
                if (sCompany == "TEL")
                {
                    if (sOutlet == "Area-1")
                    {
                        sCustGroupID = "18";
                        sValueType = "Area";
                    }
                    else if (sOutlet == "Area-2")
                    {
                        sCustGroupID = "19";
                        sValueType = "Area";
                    }
                    else if (sOutlet == "Area-3")
                    {
                        sCustGroupID = "311";
                        sValueType = "Area";
                    }
                    else if (sOutlet == "Zone-A")
                    {
                        sCustGroupID = "175";
                        sValueType = "Zone";
                    }
                    else if (sOutlet == "Zone-B")
                    {
                        sCustGroupID = "135";
                        sValueType = "Zone";
                    }
                    else if (sOutlet == "Zone-C")
                    {
                        sCustGroupID = "313";
                        sValueType = "Zone";
                    }
                    else if (sOutlet == "Zone-D")
                    {
                        sCustGroupID = "312";
                        sValueType = "Zone";
                    }
                    else if (sOutlet == "Zone-E")
                    {
                        sCustGroupID = "314";
                        sValueType = "Zone";
                    }
                }
                else
                {
                    if (sOutlet == "Area-1")
                    {
                        sCustGroupID = "1";
                        sValueType = "Area";
                    }
                    else if (sOutlet == "Area-2")
                    {
                        sCustGroupID = "2";
                        sValueType = "Area";
                    }
                    else if (sOutlet == "Area-3")
                    {
                        sCustGroupID = "5";
                        sValueType = "Area";
                    }
                    else if (sOutlet == "Zone-A")
                    {
                        sCustGroupID = "43";
                        sValueType = "Zone";
                    }
                    else if (sOutlet == "Zone-B")
                    {
                        sCustGroupID = "44";
                        sValueType = "Zone";
                    }
                    else if (sOutlet == "Zone-C")
                    {
                        sCustGroupID = "62";
                        sValueType = "Zone";
                    }
                    else if (sOutlet == "Zone-D")
                    {
                        sCustGroupID = "63";
                        sValueType = "Zone";
                    }
                    else if (sOutlet == "Zone-E")
                    {
                        sCustGroupID = "73";
                        sValueType = "Zone";
                    }
                }
            }
            else // Should be deleted after implement v5
            {
                if (sCompany == "TEL")
                {
                    if (sValue == "Area-1")
                    {
                        sCustGroupID = "18";
                        sValueType = "Area";
                    }
                    else if (sValue == "Area-2")
                    {
                        sCustGroupID = "19";
                        sValueType = "Area";
                    }
                    else if (sValue == "Area-3")
                    {
                        sCustGroupID = "311";
                        sValueType = "Area";
                    }
                    else if (sValue == "Zone-A")
                    {
                        sCustGroupID = "175";
                        sValueType = "Zone";
                    }
                    else if (sValue == "Zone-B")
                    {
                        sCustGroupID = "135";
                        sValueType = "Zone";
                    }
                    else if (sValue == "Zone-C")
                    {
                        sCustGroupID = "313";
                        sValueType = "Zone";
                    }
                    else if (sValue == "Zone-D")
                    {
                        sCustGroupID = "312";
                        sValueType = "Zone";
                    }
                    else if (sValue == "Zone-E")
                    {
                        sCustGroupID = "314";
                        sValueType = "Zone";
                    }
                }
                else
                {
                    if (sValue == "Area-1")
                    {
                        sCustGroupID = "1";
                        sValueType = "Area";
                    }
                    else if (sValue == "Area-2")
                    {
                        sCustGroupID = "2";
                        sValueType = "Area";
                    }
                    else if (sValue == "Area-3")
                    {
                        sCustGroupID = "5";
                        sValueType = "Area";
                    }
                    else if (sValue == "Zone-A")
                    {
                        sCustGroupID = "43";
                        sValueType = "Zone";
                    }
                    else if (sValue == "Zone-B")
                    {
                        sCustGroupID = "44";
                        sValueType = "Zone";
                    }
                    else if (sValue == "Zone-C")
                    {
                        sCustGroupID = "62";
                        sValueType = "Zone";
                    }
                    else if (sValue == "Zone-D")
                    {
                        sCustGroupID = "63";
                        sValueType = "Zone";
                    }
                    else if (sValue == "Zone-E")
                    {
                        sCustGroupID = "73";
                        sValueType = "Zone";
                    }
                }
            }
            #endregion
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
            Data _oDataPG = new Data();
            Data _oDataMAG = new Data();
            Data _oDataASG = new Data();
            Data _oDataAG = new Data();
            Data _oDataBrand = new Data();
            int nCount = 0;

            DBController.Instance.OpenNewConnection();
            if (sGroupType == "MAG")
            {
                if (sIsBrand == "Yes")
                {
                    oDatas.GetDataByMAG(sCompany, sDatabase, sType, sValue, sCustGroupID, sValueType, sSpecificData, sGroupValue, sOutlet);
                }
                else
                {
                    oDatas.GetDataByMAGWithoutBrand(sCompany, sDatabase, sType, sValue, sCustGroupID, sValueType, sSpecificData, sGroupValue, sOutlet);
                }
            }
            else
            {
                oDatas.GetData(sCompany, sDatabase, sType, sValue, sCustGroupID, sValueType, sSpecificData, sOutlet);
            }
            DBController.Instance.CloseConnection();
            #region NewLoop
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
                if (sGroupType != "MAG")
                {
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
                }
                else
                {
                    if (_oDataASG.ASGName != oData.ASGName)
                    {
                        _oDataASG = new Data();
                        _oDatas.Add(_oDataASG);
                        _oDataASG.ASGName = oData.ASGName;
                        _oDataASG.BrandName = oData.ASGName;
                        _oDataASG.Type = "ASG";
                        _oDataASG.Value = "Success";
                    }
                    if (_oDataAG.AGName != oData.AGName)
                    {
                        _oDataAG = new Data();
                        _oDatas.Add(_oDataAG);
                        _oDataAG.AGName = oData.AGName;
                        _oDataAG.BrandName = oData.AGName;
                        _oDataAG.Type = "AG";
                        _oDataAG.Value = "Success";
                    }
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

                if (sGroupType != "MAG")
                {
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
                }
                else
                {
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

                    _oDataAG.DTDQty = _oDataAG.DTDQty + oData.DTDQty;
                    _oDataAG.LDQty = _oDataAG.LDQty + oData.LDQty;
                    _oDataAG.MTDQty = _oDataAG.MTDQty + oData.MTDQty;
                    _oDataAG.LMQty = _oDataAG.LMQty + oData.LMQty;
                    _oDataAG.YTDQty = _oDataAG.YTDQty + oData.YTDQty;

                    _oDataAG.DTDValue = _oDataAG.DTDValue + oData.DTDValue;
                    _oDataAG.LDValue = _oDataAG.LDValue + oData.LDValue;
                    _oDataAG.MTDValue = _oDataAG.MTDValue + oData.MTDValue;
                    _oDataAG.LMValue = _oDataAG.LMValue + oData.LMValue;
                    _oDataAG.YTDValue = _oDataAG.YTDValue + oData.YTDValue;
                }
            }
            #endregion
            #region OldLoop
            /*
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
                if (_oDataASG.ASGName != oData.ASGName)
                {
                    _oDataASG = new Data();
                    _oDatas.Add(_oDataASG);
                    _oDataASG.ASGName = oData.ASGName;
                    _oDataASG.BrandName = oData.ASGName;
                    _oDataASG.Type = "ASG";
                    _oDataASG.Value = "Success";
                }
                if (_oDataAG.AGName != oData.AGName)
                {
                    _oDataAG = new Data();
                    _oDatas.Add(_oDataAG);
                    _oDataAG.AGName = oData.AGName;
                    _oDataAG.BrandName = oData.AGName;
                    _oDataAG.Type = "AG";
                    _oDataAG.Value = "Success";
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


                _oDataAG.DTDQty = _oDataAG.DTDQty + oData.DTDQty;
                _oDataAG.LDQty = _oDataAG.LDQty + oData.LDQty;
                _oDataAG.MTDQty = _oDataAG.MTDQty + oData.MTDQty;
                _oDataAG.LMQty = _oDataAG.LMQty + oData.LMQty;
                _oDataAG.YTDQty = _oDataAG.YTDQty + oData.YTDQty;

                _oDataAG.DTDValue = _oDataAG.DTDValue + oData.DTDValue;
                _oDataAG.LDValue = _oDataAG.LDValue + oData.LDValue;
                _oDataAG.MTDValue = _oDataAG.MTDValue + oData.MTDValue;
                _oDataAG.LMValue = _oDataAG.LMValue + oData.LMValue;
                _oDataAG.YTDValue = _oDataAG.YTDValue + oData.YTDValue;
            }
             */
            #endregion
            if (sCompany == "TEL")
            {
                if (sType == "All")
                {
                    _oData.InsertReportLog(sUser);
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
        public string AGName;
        public string BrandName;
        public string Type;

        public double DTDValue;
        public double LDValue;
        public double MTDValue;
        public double LMValue;
        public double YTDValue;
        public double LYValue;

        public string DTDValueText;
        public string LDValueText;
        public string LMValueText;
        public string MTDValueText;
        public string YTDValueText;
        public string LYValueText;

        public int DTDQty;
        public int LDQty;
        public int MTDQty;
        public int LMQty;
        public int YTDQty;
        public int LYQty;

        public string DTDQtyText;
        public string LDQtyText;
        public string LMQtyText;
        public string MTDQtyText;
        public string YTDQtyText;
        public string LYQtyText;

        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10002";
            string sReportName = "Sales Qty and Value";
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
        public void GetData(string sCompany, string sDatabase, string sType, string sValue, string sCustGroupID, string sValueType, string sSpecificData, string sOutlet)
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
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                      " Where a.ProductID=b.ProductID and InvoiceDate  " +
                      " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' ";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by PGName, MAGName, BrandName ";

            }
            else if (sType == "Outlet")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                       " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' ";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by PGName, MAGName, BrandName ";

            }
            else if (sType == "ByOutlet")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                       " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ShowroomCode='" + sOutlet + "' ";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by PGName, MAGName, BrandName ";

            }
            else if (sType == "ByGroup")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Showroom c, DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                           " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "' and d.CustomerID=c.CustomerID and ";
                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "Retail")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                       " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 ";
                }
                else if(sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (14,5) and a.CustomerTypeID <> 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "B2B")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                       " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "'";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "Dealer")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                       " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (3,15) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "CAC")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                       " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "'";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (5) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
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
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                  " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                                  " Where a.ProductID=b.ProductID and InvoiceDate  " +
                                  " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                  " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' ";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";

            }
            else if (sType == "Outlet")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                      " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' ";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "ByOutlet")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                      " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ShowroomCode='" + sOutlet + "'  ";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "ByGroup")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                      " " + sDatabase + ".dbo.t_Showroom c, DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
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
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "Retail")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                      " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (14,5) and a.CustomerTypeID <> 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "B2B")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                      " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }

                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "Dealer")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                      " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (3,15) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "CAC")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                      " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (5) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
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
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                       " Where a.ProductID=b.ProductID and (InvoiceDate  " +
                       " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                       " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  ";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "Outlet")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate  " +
                           " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' ";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "ByOutlet")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate  " +
                           " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ShowroomCode='" + sOutlet + "' ";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "ByGroup")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                " " + sDatabase + ".dbo.t_Showroom c, DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate  " +
                " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
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
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "Retail")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (14,5) and a.CustomerTypeID <> 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "B2B")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "Dealer")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (3,15) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "CAC")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (5) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
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
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                          " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                          " Where a.ProductID=b.ProductID and InvoiceDate  " +
                          " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                          " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  ";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "Outlet")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  ";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "ByOutlet")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ShowroomCode='" + sOutlet + "' ";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "ByGroup")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " " + sDatabase + ".dbo.t_Showroom c, DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
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
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "Retail")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (14,5) and a.CustomerTypeID <> 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "B2B")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "Dealer")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (3,15)  ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
            }
            else if (sType == "CAC")
            {
                sSQL = " select PGName, MAGName, BrandName, (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (5)  ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by PGName, MAGName, BrandName  ";
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
                sSQL = " Select PGName, MAGName, BrandName,MIX, Qty, Value from  " +
                       " ( " +
                       " select PGName, MAGName, BrandName, PGSort, MAGSort, BrandSort,  (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                       " Where a.ProductID=b.ProductID and (InvoiceDate  " +
                       " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                       " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' ";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by PGName, MAGName, BrandName,PGSort, MAGSort, BrandSort   " +
                       " )Final " +
                       " Order by PGSort, MAGSort, BrandSort   ";
            }
            else if (sType == "Outlet")
            {
                sSQL = " Select PGName, MAGName, BrandName,MIX, Qty, Value from  " +
                           " ( " +
                           " select PGName, MAGName, BrandName, PGSort, MAGSort, BrandSort,  (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' ";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }

                sSQL = sSQL + " Group by PGName, MAGName, BrandName,PGSort, MAGSort, BrandSort   " +
                           " )Final " +
                           " Order by PGSort, MAGSort, BrandSort   ";
            }
            else if (sType == "ByOutlet")
            {
                sSQL = " Select PGName, MAGName, BrandName,MIX, Qty, Value from  " +
                           " ( " +
                           " select PGName, MAGName, BrandName, PGSort, MAGSort, BrandSort,  (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Showroom c Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ShowroomCode='" + sOutlet + "' ";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }

                sSQL = sSQL + " Group by PGName, MAGName, BrandName,PGSort, MAGSort, BrandSort   " +
                           " )Final " +
                           " Order by PGSort, MAGSort, BrandSort   ";
            }
            else if (sType == "ByGroup")
            {
                sSQL = " Select PGName, MAGName, BrandName,MIX, Qty, Value from  " +
                           " ( " +
                           " select PGName, MAGName, BrandName, PGSort, MAGSort, BrandSort,  (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Showroom c , DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate  " +
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
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by PGName, MAGName, BrandName,PGSort, MAGSort, BrandSort   " +
                            " )Final " +
                            " Order by PGSort, MAGSort, BrandSort   ";
            }
            else if (sType == "Retail")
            {
                sSQL = " Select PGName, MAGName, BrandName,MIX, Qty, Value from  " +
                           " ( " +
                           " select PGName, MAGName, BrandName, PGSort, MAGSort, BrandSort,  (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (14,5) and a.CustomerTypeID <> 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by PGName, MAGName, BrandName,PGSort, MAGSort, BrandSort   " +
                           " )Final " +
                           " Order by PGSort, MAGSort, BrandSort   ";

            }
            else if (sType == "B2B")
            {
                sSQL = " Select PGName, MAGName, BrandName,MIX, Qty, Value from  " +
                           " ( " +
                           " select PGName, MAGName, BrandName, PGSort, MAGSort, BrandSort,  (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by PGName, MAGName, BrandName,PGSort, MAGSort, BrandSort   " +
                           " )Final " +
                           " Order by PGSort, MAGSort, BrandSort   ";

            }
            else if (sType == "Dealer")
            {
                sSQL = " Select PGName, MAGName, BrandName,MIX, Qty, Value from  " +
                           " ( " +
                           " select PGName, MAGName, BrandName, PGSort, MAGSort, BrandSort,  (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (3,15)";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by PGName, MAGName, BrandName,PGSort, MAGSort, BrandSort   " +
                           " )Final " +
                           " Order by PGSort, MAGSort, BrandSort   ";

            }
            else if (sType == "CAC")
            {
                sSQL = " Select PGName, MAGName, BrandName,MIX, Qty, Value from  " +
                           " ( " +
                           " select PGName, MAGName, BrandName, PGSort, MAGSort, BrandSort,  (PGName+MAGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' ";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (5)";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by PGName, MAGName, BrandName,PGSort, MAGSort, BrandSort   " +
                           " )Final " +
                           " Order by PGSort, MAGSort, BrandSort   ";

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
        public void GetDataByMAG(string sCompany, string sDatabase, string sType, string sValue, string sCustGroupID, string sValueType, string sSpecificData, string sGroupValue, string sOutlet)
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
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                      " Where a.ProductID=b.ProductID and InvoiceDate  " +
                      " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName ";

            }
            else if (sType == "Outlet")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                       " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName ";

            }
            else if (sType == "ByOutlet")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                       " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ShowroomCode='" + sOutlet + "' and MAGName='" + sGroupValue + "'";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName ";

            }
            else if (sType == "ByGroup")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Showroom c, DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                           " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "' and d.CustomerID=c.CustomerID and MAGName='" + sGroupValue + "' and ";
                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "Retail")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                       " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (14,5) and a.CustomerTypeID <> 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "B2B")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                       " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "Dealer")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                       " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (3,15) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "CAC")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                       " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (5) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by ASGName, AGName, BrandName  ";
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
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                  " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                                  " Where a.ProductID=b.ProductID and InvoiceDate  " +
                                  " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                  " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + "Group by ASGName, AGName, BrandName  ";

            }
            else if (sType == "Outlet")
            {


                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                       " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName ";

            }
            else if (sType == "ByOutlet")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                      " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ShowroomCode='" + sOutlet + "'  and MAGName='" + sGroupValue + "'";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "ByGroup")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                      " " + sDatabase + ".dbo.t_Showroom c, DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "' and d.CustomerID=c.CustomerID  and ";

                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "Retail")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                      " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (14,5) and a.CustomerTypeID <> 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "B2B")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                      " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }

                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "Dealer")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                      " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (3,15) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "CAC")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                      " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (5) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
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
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                       " Where a.ProductID=b.ProductID and (InvoiceDate  " +
                       " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                       " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "'";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "Outlet")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate  " +
                           " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "ByOutlet")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate  " +
                           " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ShowroomCode='" + sOutlet + "' and MAGName='" + sGroupValue + "'";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "ByGroup")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                " " + sDatabase + ".dbo.t_Showroom c, DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate  " +
                " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "' and d.CustomerID=c.CustomerID and ";

                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "Retail")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (14,5) and a.CustomerTypeID <> 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "B2B")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "Dealer")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (3,15) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "CAC")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (5) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
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
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                          " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                          " Where a.ProductID=b.ProductID and InvoiceDate  " +
                          " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                          " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "'";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "Outlet")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "'";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "ByOutlet")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ShowroomCode='" + sOutlet + "' and MAGName='" + sGroupValue + "'";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "ByGroup")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " " + sDatabase + ".dbo.t_Showroom c, DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "' and d.CustomerID=c.CustomerID and ";

                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "Retail")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (14,5) and a.CustomerTypeID <> 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "B2B")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "Dealer")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (3,15)  ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
            }
            else if (sType == "CAC")
            {
                sSQL = " select ASGName, AGName, BrandName, (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (5)  ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName  ";
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
                sSQL = " Select ASGName, AGName, BrandName,MIX, Qty, Value from  " +
                       " ( " +
                       " select ASGName, AGName, BrandName, ASGSort, AGSort, BrandSort,  (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                       " Where a.ProductID=b.ProductID and (InvoiceDate  " +
                       " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                       " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "'";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName,ASGSort, AGSort, BrandSort   " +
               " )Final " +
               " Order by ASGSort, AGSort, BrandSort   ";
            }
            else if (sType == "Outlet")
            {
                sSQL = " Select ASGName, AGName, BrandName,MIX, Qty, Value from  " +
                           " ( " +
                           " select ASGName, AGName, BrandName, ASGSort, AGSort, BrandSort,  (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "'";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }

                sSQL = sSQL + " Group by ASGName, AGName, BrandName,ASGSort, AGSort, BrandSort   " +
                   " )Final " +
                   " Order by ASGSort, AGSort, BrandSort   ";
            }
            else if (sType == "ByOutlet")
            {
                sSQL = " Select ASGName, AGName, BrandName,MIX, Qty, Value from  " +
                           " ( " +
                           " select ASGName, AGName, BrandName, ASGSort, AGSort, BrandSort,  (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Showroom c Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ShowroomCode='" + sOutlet + "'  and MAGName='" + sGroupValue + "'";
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }

                sSQL = sSQL + " Group by ASGName, AGName, BrandName,ASGSort, AGSort, BrandSort   " +
                           " )Final " +
                           " Order by ASGSort, AGSort, BrandSort   ";
            }
            else if (sType == "ByGroup")
            {
                sSQL = " Select ASGName, AGName, BrandName,MIX, Qty, Value from  " +
                           " ( " +
                           " select ASGName, AGName, BrandName, ASGSort, AGSort, BrandSort,  (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Showroom c , DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "' and d.CustomerID=c.CustomerID and ";
                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName,ASGSort, AGSort, BrandSort   " +
                            " )Final " +
                            " Order by ASGSort, AGSort, BrandSort   ";
            }
            else if (sType == "Retail")
            {
                sSQL = " Select ASGName, AGName, BrandName,MIX, Qty, Value from  " +
                           " ( " +
                           " select ASGName, AGName, BrandName, ASGSort, AGSort, BrandSort,  (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "'";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (14,5) and a.CustomerTypeID <> 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName,ASGSort, AGSort, BrandSort   " +
                           " )Final " +
                           " Order by ASGSort, AGSort, BrandSort   ";

            }
            else if (sType == "B2B")
            {
                sSQL = " Select ASGName, AGName, BrandName,MIX, Qty, Value from  " +
                           " ( " +
                           " select ASGName, AGName, BrandName, ASGSort, AGSort, BrandSort,  (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "'";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName,ASGSort, AGSort, BrandSort   " +
                           " )Final " +
                           " Order by ASGSort, AGSort, BrandSort   ";

            }
            else if (sType == "Dealer")
            {
                sSQL = " Select ASGName, AGName, BrandName,MIX, Qty, Value from  " +
                           " ( " +
                           " select ASGName, AGName, BrandName, ASGSort, AGSort, BrandSort,  (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "'";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (3,15)";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName,ASGSort, AGSort, BrandSort   " +
                           " )Final " +
                           " Order by ASGSort, AGSort, BrandSort   ";

            }
            else if (sType == "CAC")
            {
                sSQL = " Select ASGName, AGName, BrandName,MIX, Qty, Value from  " +
                           " ( " +
                           " select ASGName, AGName, BrandName, ASGSort, AGSort, BrandSort,  (ASGName+AGName+BrandName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "'";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (5)";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                if (sSpecificData != "")
                {
                    sSQL = sSQL + " and BrandName='" + sSpecificData + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, BrandName,ASGSort, AGSort, BrandSort   " +
                           " )Final " +
                           " Order by ASGSort, AGSort, BrandSort   ";

            }
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSYTDSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.ASGName = reader["ASGName"].ToString();
                    oProductSalesRow.AGName = reader["AGName"].ToString();
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
                _oData.ASGName = oSalesValueRow.ASGName;
                _oData.AGName = oSalesValueRow.AGName;
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
        public void GetDataByMAGWithoutBrand(string sCompany, string sDatabase, string sType, string sValue, string sCustGroupID, string sValueType, string sSpecificData, string sGroupValue, string sOutlet)
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
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                      " Where a.ProductID=b.ProductID and InvoiceDate  " +
                      " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "' Group by ASGName, AGName ";

            }
            else if (sType == "Outlet")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                       " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "' Group by ASGName, AGName ";

            }
            else if (sType == "ByOutlet")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                       " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ShowroomCode='" + sOutlet + "' and MAGName='" + sGroupValue + "' Group by ASGName, AGName ";

            }
            else if (sType == "ByGroup")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Showroom c, DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                           " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "' and d.CustomerID=c.CustomerID and MAGName='" + sGroupValue + "' and ";
                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName ";
            }
            else if (sType == "Retail")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                       " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (14,5) and a.CustomerTypeID <> 202 ";
                }
                sSQL = sSQL + "Group by ASGName, AGName  ";
            }
            else if (sType == "B2B")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                       " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + "Group by ASGName, AGName ";
            }
            else if (sType == "Dealer")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                       " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (3,15) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + "Group by ASGName, AGName ";
            }
            else if (sType == "CAC")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                       " BETWEEN '" + dFromDate + "' and '" + dToDate + "' and InvoiceDate < '" + dToDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (5) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + "Group by ASGName, AGName  ";
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
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                  " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                                  " Where a.ProductID=b.ProductID and InvoiceDate  " +
                                  " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                  " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";
                sSQL = sSQL + " Group by ASGName, AGName  ";

            }
            else if (sType == "Outlet")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                       " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "' Group by ASGName, AGName ";
            }
            else if (sType == "ByOutlet")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                      " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ShowroomCode='" + sOutlet + "'  and MAGName='" + sGroupValue + "'";
                sSQL = sSQL + " Group by ASGName, AGName  ";
            }
            else if (sType == "ByGroup")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                      " " + sDatabase + ".dbo.t_Showroom c, DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "' and d.CustomerID=c.CustomerID  and ";

                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName  ";
            }
            else if (sType == "Retail")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                      " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (14,5) and a.CustomerTypeID <> 202 ";
                }
                sSQL = sSQL + " Group by ASGName, AGName  ";
            }
            else if (sType == "B2B")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                      " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + " Group by ASGName, AGName  ";
            }
            else if (sType == "Dealer")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                      " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (3,15) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + " Group by ASGName, AGName  ";
            }
            else if (sType == "CAC")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                                      " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                                      " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                                      " BETWEEN '" + dLastDate + "' and '" + dFromDate + "' and InvoiceDate < '" + dFromDate + "'  " +
                                      " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (5) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + " Group by ASGName, AGName  ";
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
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                       " Where a.ProductID=b.ProductID and (InvoiceDate  " +
                       " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                       " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "'";
                sSQL = sSQL + " Group by ASGName, AGName  ";
            }
            else if (sType == "Outlet")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate  " +
                           " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";
                sSQL = sSQL + " Group by ASGName, AGName  ";
            }
            else if (sType == "ByOutlet")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate  " +
                           " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ShowroomCode='" + sOutlet + "' and MAGName='" + sGroupValue + "'";

                sSQL = sSQL + " Group by ASGName, AGName  ";
            }
            else if (sType == "ByGroup")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                " " + sDatabase + ".dbo.t_Showroom c, DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate  " +
                " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "' and d.CustomerID=c.CustomerID and ";

                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName  ";
            }
            else if (sType == "Retail")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (14,5) and a.CustomerTypeID <> 202 ";
                }
                sSQL = sSQL + " Group by ASGName, AGName ";
            }
            else if (sType == "B2B")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + " Group by ASGName, AGName  ";
            }
            else if (sType == "Dealer")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (3,15) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + " Group by ASGName, AGName  ";
            }
            else if (sType == "CAC")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE())) " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (5) ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + " Group by ASGName, AGName  ";
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
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                          " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                          " Where a.ProductID=b.ProductID and InvoiceDate  " +
                          " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                          " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "'";

                sSQL = sSQL + " Group by ASGName, AGName  ";
            }
            else if (sType == "Outlet")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "'";

                sSQL = sSQL + " Group by ASGName, AGName ";
            }
            else if (sType == "ByOutlet")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ShowroomCode='" + sOutlet + "' and MAGName='" + sGroupValue + "'";
                sSQL = sSQL + " Group by ASGName, AGName ";
            }
            else if (sType == "ByGroup")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " " + sDatabase + ".dbo.t_Showroom c, DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "' and d.CustomerID=c.CustomerID and ";

                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName  ";
            }
            else if (sType == "Retail")
            {
                sSQL = " select ASGName, AGName,(ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (14,5) and a.CustomerTypeID <> 202 ";
                }
                sSQL = sSQL + " Group by ASGName, AGName ";
            }
            else if (sType == "B2B")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + " Group by ASGName, AGName  ";
            }
            else if (sType == "Dealer")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (3,15)  ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + " Group by ASGName, AGName  ";
            }
            else if (sType == "CAC")
            {
                sSQL = " select ASGName, AGName, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                             " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                             " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and InvoiceDate  " +
                             " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                             " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "' and MAGName='" + sGroupValue + "'";

                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (5)  ";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + " Group by ASGName, AGName  ";
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
                sSQL = " Select ASGName, AGName, MIX, Qty, Value from  " +
                       " ( " +
                       " select ASGName, AGName, ASGSort, AGSort, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                       " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b  " +
                       " Where a.ProductID=b.ProductID and (InvoiceDate  " +
                       " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                       " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "'";

                sSQL = sSQL + " Group by ASGName, AGName, ASGSort, AGSort   " +
               " )Final " +
               " Order by ASGSort, AGSort ";
            }
            else if (sType == "Outlet")
            {
                sSQL = " Select ASGName, AGName, MIX, Qty, Value from  " +
                           " ( " +
                           " select ASGName, AGName,ASGSort, AGSort, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "'";

                sSQL = sSQL + " Group by ASGName, AGName, ASGSort, AGSort  " +
                   " )Final " +
                   " Order by ASGSort, AGSort  ";
            }
            else if (sType == "ByOutlet")
            {
                sSQL = " Select ASGName, AGName, MIX, Qty, Value from  " +
                           " ( " +
                           " select ASGName, AGName, ASGSort, AGSort,  (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Showroom c Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ShowroomCode='" + sOutlet + "'  and MAGName='" + sGroupValue + "'";
                sSQL = sSQL + " Group by ASGName, AGName, ASGSort, AGSort   " +
                           " )Final " +
                           " Order by ASGSort, AGSort  ";
            }
            else if (sType == "ByGroup")
            {
                sSQL = " Select ASGName, AGName, MIX, Qty, Value from  " +
                           " ( " +
                           " select ASGName, AGName, ASGSort, AGSort, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " " + sDatabase + ".dbo.t_Showroom c , DWDB.dbo.t_CustomerDetails d  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and d.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "' and d.CustomerID=c.CustomerID and ";
                if (sValueType == "Area")
                {
                    sSQL = sSQL + "AreaID='" + sCustGroupID + "' ";
                }
                else
                {
                    sSQL = sSQL + "TerritoryID='" + sCustGroupID + "' ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, ASGSort, AGSort  " +
                            " )Final " +
                            " Order by ASGSort, AGSort  ";
            }
            else if (sType == "Retail")
            {
                sSQL = " Select ASGName, AGName, MIX, Qty, Value from  " +
                           " ( " +
                           " select ASGName, AGName, ASGSort, AGSort, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "'";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (9,4,11,13) and a.CustomerTypeID <> 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (14,5) and a.CustomerTypeID <> 202 ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, ASGSort, AGSort  " +
                           " )Final " +
                           " Order by ASGSort, AGSort  ";

            }
            else if (sType == "B2B")
            {
                sSQL = " Select ASGName, AGName, MIX, Qty, Value from  " +
                           " ( " +
                           " select ASGName, AGName, ASGSort, AGSort, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "'";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (13) and a.CustomerTypeID = 249 ";
                }
                else if (sCompany == "TML")
                {
                    sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, ASGSort, AGSort   " +
                           " )Final " +
                           " Order by ASGSort, AGSort  ";

            }
            else if (sType == "Dealer")
            {
                sSQL = " Select ASGName, AGName, MIX, Qty, Value from  " +
                           " ( " +
                           " select ASGName, AGName, ASGSort, AGSort, (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "'";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (3,15)";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, ASGSort, AGSort   " +
                           " )Final " +
                           " Order by ASGSort, AGSort  ";

            }
            else if (sType == "CAC")
            {
                sSQL = " Select ASGName, AGName, MIX, Qty, Value from  " +
                           " ( " +
                           " select ASGName, AGName, ASGSort, AGSort,  (ASGName+AGName)MIX, Sum(SalesQty+FreeQty) as Qty, " +
                           " Sum(NetSale) as Value from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                           " DWDB.dbo.t_CustomerDetails c  Where a.ProductID=b.ProductID and a.CustomerID=c.CustomerID and (InvoiceDate  " +
                           " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                           " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))   " +
                           " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and c.CompanyName='" + sCompany + "'  and MAGName='" + sGroupValue + "'";
                if (sCompany == "TEL")
                {
                    sSQL = sSQL + " and ChannelID IN (5)";
                }
                else if (sCompany == "TML")
                {
                    //sSQL = sSQL + " and ChannelID IN (5) and a.CustomerTypeID = 202 ";
                }
                sSQL = sSQL + " Group by ASGName, AGName, ASGSort, AGSort   " +
                           " )Final " +
                           " Order by ASGSort, AGSort  ";

            }
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSYTDSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.ASGName = reader["ASGName"].ToString();
                    oProductSalesRow.AGName = reader["AGName"].ToString();

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
                _oData.ASGName = oSalesValueRow.ASGName;
                _oData.AGName = oSalesValueRow.AGName;

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


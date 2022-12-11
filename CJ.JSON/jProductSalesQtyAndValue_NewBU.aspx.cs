
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

public partial class jProductSalesQtyAndValue_NewBU : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            //string sUser = c.Request.Form["UserName"].Trim();
            //string sCompany = c.Request.Form["Company"].Trim();
            //string sChannel = c.Request.Form["Channel"].Trim();
            //string sValueType = c.Request.Form["ValueType"].Trim();
            //string sValue = c.Request.Form["Value"].Trim();

            string sCompany = "TEL";
            string sUser = "hakim";
            string sChannel = "TD";
            string sValueType = "ByArea";
            string sValue = "National-1";



            string sDatabase = "x";




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
            Datas oDatasBrands = new Datas();
            Data _oDataAllBrand = new Data();
            Data _oDataTotal = new Data();
            Data _oDataBrand = new Data();
            Data _oDataPGTotalTD = new Data();
            Data _oDataPGTotalRetail = new Data();
            Data _oDataPGTotalB2B = new Data();
            Data _oDataPGTotalDealer = new Data();

            Data _oDataPGTotalAll = new Data();
            Data _oDataPGTotalCAC = new Data();

            int nCount = 0;
            int nTotalCount = 0;

            int nMargetGroupID = 0;

            DBController.Instance.OpenNewConnection();
            if (sValueType == "ByArea" || sValueType == "ByZone")
            {
                nMargetGroupID = _oData.GetMarketGroupID(sCompany, sDatabase, sValue, sValueType);
            }
            oDatas.GetData(sCompany, sDatabase, sChannel, sValue, sValueType, nMargetGroupID);

            oDatasBrands.GetAllBrandData(sCompany, sDatabase, sChannel, sValue, sValueType, nMargetGroupID);
            
            DBController.Instance.CloseConnection();

            #region NewLoop
            foreach (Data oData in oDatas)
            {
                nTotalCount = 0;

                if (nCount == 0)
                {
                    _oDataPGTotalTD = new Data();
                    _oDatas.Add(_oDataPGTotalTD);
                    _oDataPGTotalTD.Name = "Total";
                    _oDataPGTotalTD.Type = "PGTotal";
                    _oDataPGTotalTD.Value = "Success";
                    _oDataPGTotalTD.ProductGroupName = "PGTotal";
                    _oDataPGTotalTD.ProductGroupType = "PGTotal";
                    _oDataPGTotalTD.ParentID = "0";
                    _oDataPGTotalTD.ProductGroupID = "0";
                    _oDataPGTotalTD.Channel = "TD";

                    _oDataPGTotalRetail = new Data();
                    _oDatas.Add(_oDataPGTotalRetail);
                    _oDataPGTotalRetail.Name = "Total";
                    _oDataPGTotalRetail.Type = "PGTotal";
                    _oDataPGTotalRetail.Value = "Success";
                    _oDataPGTotalRetail.ProductGroupName = "PGTotal";
                    _oDataPGTotalRetail.ProductGroupType = "PGTotal";
                    _oDataPGTotalRetail.ParentID = "0";
                    _oDataPGTotalRetail.ProductGroupID = "0";
                    _oDataPGTotalRetail.Channel = "Retail";

                    _oDataPGTotalB2B = new Data();
                    _oDatas.Add(_oDataPGTotalB2B);
                    _oDataPGTotalB2B.Name = "Total";
                    _oDataPGTotalB2B.Type = "PGTotal";
                    _oDataPGTotalB2B.Value = "Success";
                    _oDataPGTotalB2B.ProductGroupName = "PGTotal";
                    _oDataPGTotalB2B.ProductGroupType = "PGTotal";
                    _oDataPGTotalB2B.ParentID = "0";
                    _oDataPGTotalB2B.ProductGroupID = "0";
                    _oDataPGTotalB2B.Channel = "B2B";

                    _oDataPGTotalDealer = new Data();
                    _oDatas.Add(_oDataPGTotalDealer);
                    _oDataPGTotalDealer.Name = "Total";
                    _oDataPGTotalDealer.Type = "PGTotal";
                    _oDataPGTotalDealer.Value = "Success";
                    _oDataPGTotalDealer.ProductGroupName = "PGTotal";
                    _oDataPGTotalDealer.ProductGroupType = "PGTotal";
                    _oDataPGTotalDealer.ParentID = "0";
                    _oDataPGTotalDealer.ProductGroupID = "0";
                    _oDataPGTotalDealer.Channel = "Dealer";

                    _oDataPGTotalAll = new Data();
                    _oDatas.Add(_oDataPGTotalAll);
                    _oDataPGTotalAll.Name = "Total";
                    _oDataPGTotalAll.Type = "PGTotal";
                    _oDataPGTotalAll.Value = "Success";
                    _oDataPGTotalAll.ProductGroupName = "PGTotal";
                    _oDataPGTotalAll.ProductGroupType = "PGTotal";
                    _oDataPGTotalAll.ParentID = "0";
                    _oDataPGTotalAll.ProductGroupID = "0";
                    _oDataPGTotalAll.Channel = "All";

                    _oDataPGTotalCAC = new Data();
                    _oDatas.Add(_oDataPGTotalCAC);
                    _oDataPGTotalCAC.Name = "Total";
                    _oDataPGTotalCAC.Type = "PGTotal";
                    _oDataPGTotalCAC.Value = "Success";
                    _oDataPGTotalCAC.ProductGroupName = "PGTotal";
                    _oDataPGTotalCAC.ProductGroupType = "PGTotal";
                    _oDataPGTotalCAC.ParentID = "0";
                    _oDataPGTotalCAC.ProductGroupID = "0";
                    _oDataPGTotalCAC.Channel = "CAC";

                    //Brand Data
                   
                    foreach (Data oDataBrand in oDatasBrands)
                    {
                        _oDataAllBrand = new Data();
                        _oDataAllBrand.ProductGroupType = oDataBrand.ProductGroupType;
                        _oDataAllBrand.Channel = oDataBrand.Channel;
                        _oDataAllBrand.Name = oDataBrand.BrandName;
                        _oDataAllBrand.ProductGroupName = oDataBrand.ProductGroupName;
                        _oDataAllBrand.ParentID = oDataBrand.ParentID;
                        _oDataAllBrand.ProductGroupID = oDataBrand.ProductGroupID;
                        _oDataAllBrand.Type = "BrandAll";
                        _oDataAllBrand.Value = "Success";

                        _oDataAllBrand.DTDQty = oDataBrand.DTDQty;
                        _oDataAllBrand.LDQty = oDataBrand.LDQty;
                        _oDataAllBrand.MTDQty = oDataBrand.MTDQty;
                        _oDataAllBrand.LMQty = oDataBrand.LMQty;
                        _oDataAllBrand.YTDQty = oDataBrand.YTDQty;
                        _oDataAllBrand.LYQty = oDataBrand.LYQty;
                        _oDataAllBrand.LYYTDQty = oDataBrand.LYYTDQty;
                        _oDataAllBrand.LYMTDQty = oDataBrand.LYMTDQty;
                        _oDataAllBrand.CMTQty = oDataBrand.CMTQty;
                        _oDataAllBrand.LMTQty = oDataBrand.LMTQty;

                        _oDataAllBrand.DTDValue = oDataBrand.DTDValue;
                        _oDataAllBrand.LDValue = oDataBrand.LDValue;
                        _oDataAllBrand.MTDValue = oDataBrand.MTDValue;
                        _oDataAllBrand.LMValue = oDataBrand.LMValue;
                        _oDataAllBrand.YTDValue = oDataBrand.YTDValue;
                        _oDataAllBrand.LYValue = oDataBrand.LYValue;
                        _oDataAllBrand.LYYTDValue = oDataBrand.LYYTDValue;
                        _oDataAllBrand.LYMTDValue = oDataBrand.LYMTDValue;
                        _oDataAllBrand.CMTValue = oDataBrand.CMTValue;
                        _oDataAllBrand.LMTValue = oDataBrand.LMTValue;

                        _oDatas.Add(_oDataAllBrand);
                    }

                    nCount++;
                }
                if (_oDataTotal.ProductGroupType != oData.ProductGroupType)
                {
                    nTotalCount++;
                }
                else
                {
                    if (_oDataTotal.Channel != oData.Channel)
                    {
                        nTotalCount++;
                    }
                    else
                    {
                        if (_oDataTotal.ProductGroupName != oData.ProductGroupName)
                        {
                            nTotalCount++;
                        }

                    }
                }
                if (nTotalCount > 0)
                {
                    _oDataTotal = new Data();
                    _oDatas.Add(_oDataTotal);
                    _oDataTotal.ProductGroupType = oData.ProductGroupType;
                    _oDataTotal.Channel = oData.Channel;
                    _oDataTotal.ProductGroupName = oData.ProductGroupName;
                    _oDataTotal.BrandName = oData.BrandName;
                    _oDataTotal.Name = oData.ProductGroupName;
                    _oDataTotal.ParentID = oData.ParentID;
                    _oDataTotal.ProductGroupID = oData.ProductGroupID;
                    _oDataTotal.Type = "Total";
                    _oDataTotal.Value = "Success";
                }

                _oDataBrand = new Data();
                _oDataBrand.ProductGroupType = oData.ProductGroupType;
                _oDataBrand.Channel = oData.Channel;
                _oDataBrand.Name = oData.BrandName;
                _oDataBrand.ProductGroupName = oData.ProductGroupName;
                _oDataBrand.ParentID = oData.ParentID;
                _oDataBrand.ProductGroupID = oData.ProductGroupID;
                _oDataBrand.Type = "Brand";
                _oDataBrand.Value = "Success";

                _oDataBrand.DTDQty = oData.DTDQty;
                _oDataBrand.LDQty = oData.LDQty;
                _oDataBrand.MTDQty = oData.MTDQty;
                _oDataBrand.LMQty = oData.LMQty;
                _oDataBrand.YTDQty = oData.YTDQty;
                _oDataBrand.LYQty = oData.LYQty;
                _oDataBrand.LYYTDQty = oData.LYYTDQty;
                _oDataBrand.LYMTDQty = oData.LYMTDQty;
                _oDataBrand.CMTQty = oData.CMTQty;
                _oDataBrand.LMTQty = oData.LMTQty;

                _oDataBrand.DTDValue = oData.DTDValue;
                _oDataBrand.LDValue = oData.LDValue;
                _oDataBrand.MTDValue = oData.MTDValue;
                _oDataBrand.LMValue = oData.LMValue;
                _oDataBrand.YTDValue = oData.YTDValue;
                _oDataBrand.LYValue = oData.LYValue;
                _oDataBrand.LYYTDValue = oData.LYYTDValue;
                _oDataBrand.LYMTDValue = oData.LYMTDValue;
                _oDataBrand.CMTValue = oData.CMTValue;
                _oDataBrand.LMTValue = oData.LMTValue;

                _oDatas.Add(_oDataBrand);

                _oDataTotal.DTDQty = _oDataTotal.DTDQty + oData.DTDQty;
                _oDataTotal.LDQty = _oDataTotal.LDQty + oData.LDQty;
                _oDataTotal.MTDQty = _oDataTotal.MTDQty + oData.MTDQty;
                _oDataTotal.LMQty = _oDataTotal.LMQty + oData.LMQty;
                _oDataTotal.YTDQty = _oDataTotal.YTDQty + oData.YTDQty;
                _oDataTotal.LYQty = _oDataTotal.LYQty + oData.LYQty;
                _oDataTotal.LYYTDQty = _oDataTotal.LYYTDQty + oData.LYYTDQty;
                _oDataTotal.LYMTDQty = _oDataTotal.LYMTDQty + oData.LYMTDQty;
                _oDataTotal.CMTQty = _oDataTotal.CMTQty + oData.CMTQty;
                _oDataTotal.LMTQty = _oDataTotal.LMTQty + oData.LMTQty;

                _oDataTotal.DTDValue = _oDataTotal.DTDValue + oData.DTDValue;
                _oDataTotal.LDValue = _oDataTotal.LDValue + oData.LDValue;
                _oDataTotal.MTDValue = _oDataTotal.MTDValue + oData.MTDValue;
                _oDataTotal.LMValue = _oDataTotal.LMValue + oData.LMValue;
                _oDataTotal.YTDValue = _oDataTotal.YTDValue + oData.YTDValue;
                _oDataTotal.LYValue = _oDataTotal.LYValue + oData.LYValue;
                _oDataTotal.LYYTDValue = _oDataTotal.LYYTDValue + oData.LYYTDValue;
                _oDataTotal.LYMTDValue = _oDataTotal.LYMTDValue + oData.LYMTDValue;
                _oDataTotal.CMTValue = _oDataTotal.CMTValue + oData.CMTValue;
                _oDataTotal.LMTValue = _oDataTotal.LMTValue + oData.LMTValue;


                if (oData.ProductGroupType == "PG")
                {
                    if (oData.Channel == "TD")
                    {
                        _oDataPGTotalTD.DTDQty = _oDataPGTotalTD.DTDQty + oData.DTDQty;
                        _oDataPGTotalTD.LDQty = _oDataPGTotalTD.LDQty + oData.LDQty;
                        _oDataPGTotalTD.MTDQty = _oDataPGTotalTD.MTDQty + oData.MTDQty;
                        _oDataPGTotalTD.LMQty = _oDataPGTotalTD.LMQty + oData.LMQty;
                        _oDataPGTotalTD.YTDQty = _oDataPGTotalTD.YTDQty + oData.YTDQty;
                        _oDataPGTotalTD.LYQty = _oDataPGTotalTD.LYQty + oData.LYQty;
                        _oDataPGTotalTD.LYYTDQty = _oDataPGTotalTD.LYYTDQty + oData.LYYTDQty;
                        _oDataPGTotalTD.LYMTDQty = _oDataPGTotalTD.LYMTDQty + oData.LYMTDQty;
                        _oDataPGTotalTD.CMTQty = _oDataPGTotalTD.CMTQty + oData.CMTQty;
                        _oDataPGTotalTD.LMTQty = _oDataPGTotalTD.LMTQty + oData.LMTQty;

                        _oDataPGTotalTD.DTDValue = _oDataPGTotalTD.DTDValue + oData.DTDValue;
                        _oDataPGTotalTD.LDValue = _oDataPGTotalTD.LDValue + oData.LDValue;
                        _oDataPGTotalTD.MTDValue = _oDataPGTotalTD.MTDValue + oData.MTDValue;
                        _oDataPGTotalTD.LMValue = _oDataPGTotalTD.LMValue + oData.LMValue;
                        _oDataPGTotalTD.YTDValue = _oDataPGTotalTD.YTDValue + oData.YTDValue;
                        _oDataPGTotalTD.LYValue = _oDataPGTotalTD.LYValue + oData.LYValue;
                        _oDataPGTotalTD.LYYTDValue = _oDataPGTotalTD.LYYTDValue + oData.LYYTDValue;
                        _oDataPGTotalTD.LYMTDValue = _oDataPGTotalTD.LYMTDValue + oData.LYMTDValue;
                        _oDataPGTotalTD.CMTValue = _oDataPGTotalTD.CMTValue + oData.CMTValue;
                        _oDataPGTotalTD.LMTValue = _oDataPGTotalTD.LMTValue + oData.LMTValue;
                    }
                    else if (oData.Channel == "Retail")
                    {
                        _oDataPGTotalRetail.DTDQty = _oDataPGTotalRetail.DTDQty + oData.DTDQty;
                        _oDataPGTotalRetail.LDQty = _oDataPGTotalRetail.LDQty + oData.LDQty;
                        _oDataPGTotalRetail.MTDQty = _oDataPGTotalRetail.MTDQty + oData.MTDQty;
                        _oDataPGTotalRetail.LMQty = _oDataPGTotalRetail.LMQty + oData.LMQty;
                        _oDataPGTotalRetail.YTDQty = _oDataPGTotalRetail.YTDQty + oData.YTDQty;
                        _oDataPGTotalRetail.LYQty = _oDataPGTotalRetail.LYQty + oData.LYQty;
                        _oDataPGTotalRetail.LYYTDQty = _oDataPGTotalRetail.LYYTDQty + oData.LYYTDQty;
                        _oDataPGTotalRetail.LYMTDQty = _oDataPGTotalRetail.LYMTDQty + oData.LYMTDQty;
                        _oDataPGTotalRetail.CMTQty = _oDataPGTotalRetail.CMTQty + oData.CMTQty;
                        _oDataPGTotalRetail.LMTQty = _oDataPGTotalRetail.LMTQty + oData.LMTQty;

                        _oDataPGTotalRetail.DTDValue = _oDataPGTotalRetail.DTDValue + oData.DTDValue;
                        _oDataPGTotalRetail.LDValue = _oDataPGTotalRetail.LDValue + oData.LDValue;
                        _oDataPGTotalRetail.MTDValue = _oDataPGTotalRetail.MTDValue + oData.MTDValue;
                        _oDataPGTotalRetail.LMValue = _oDataPGTotalRetail.LMValue + oData.LMValue;
                        _oDataPGTotalRetail.YTDValue = _oDataPGTotalRetail.YTDValue + oData.YTDValue;
                        _oDataPGTotalRetail.LYValue = _oDataPGTotalRetail.LYValue + oData.LYValue;
                        _oDataPGTotalRetail.LYYTDValue = _oDataPGTotalRetail.LYYTDValue + oData.LYYTDValue;
                        _oDataPGTotalRetail.LYMTDValue = _oDataPGTotalRetail.LYMTDValue + oData.LYMTDValue;
                        _oDataPGTotalRetail.CMTValue = _oDataPGTotalRetail.CMTValue + oData.CMTValue;
                        _oDataPGTotalRetail.LMTValue = _oDataPGTotalRetail.LMTValue + oData.LMTValue;
                    }
                    else if (oData.Channel == "B2B")
                    {
                        _oDataPGTotalB2B.DTDQty = _oDataPGTotalB2B.DTDQty + oData.DTDQty;
                        _oDataPGTotalB2B.LDQty = _oDataPGTotalB2B.LDQty + oData.LDQty;
                        _oDataPGTotalB2B.MTDQty = _oDataPGTotalB2B.MTDQty + oData.MTDQty;
                        _oDataPGTotalB2B.LMQty = _oDataPGTotalB2B.LMQty + oData.LMQty;
                        _oDataPGTotalB2B.YTDQty = _oDataPGTotalB2B.YTDQty + oData.YTDQty;
                        _oDataPGTotalB2B.LYQty = _oDataPGTotalB2B.LYQty + oData.LYQty;
                        _oDataPGTotalB2B.LYYTDQty = _oDataPGTotalB2B.LYYTDQty + oData.LYYTDQty;
                        _oDataPGTotalB2B.LYMTDQty = _oDataPGTotalB2B.LYMTDQty + oData.LYMTDQty;
                        _oDataPGTotalB2B.CMTQty = _oDataPGTotalB2B.CMTQty + oData.CMTQty;
                        _oDataPGTotalB2B.LMTQty = _oDataPGTotalB2B.LMTQty + oData.LMTQty;

                        _oDataPGTotalB2B.DTDValue = _oDataPGTotalB2B.DTDValue + oData.DTDValue;
                        _oDataPGTotalB2B.LDValue = _oDataPGTotalB2B.LDValue + oData.LDValue;
                        _oDataPGTotalB2B.MTDValue = _oDataPGTotalB2B.MTDValue + oData.MTDValue;
                        _oDataPGTotalB2B.LMValue = _oDataPGTotalB2B.LMValue + oData.LMValue;
                        _oDataPGTotalB2B.YTDValue = _oDataPGTotalB2B.YTDValue + oData.YTDValue;
                        _oDataPGTotalB2B.LYValue = _oDataPGTotalB2B.LYValue + oData.LYValue;
                        _oDataPGTotalB2B.LYYTDValue = _oDataPGTotalB2B.LYYTDValue + oData.LYYTDValue;
                        _oDataPGTotalB2B.LYMTDValue = _oDataPGTotalB2B.LYMTDValue + oData.LYMTDValue;
                        _oDataPGTotalB2B.CMTValue = _oDataPGTotalB2B.CMTValue + oData.CMTValue;
                        _oDataPGTotalB2B.LMTValue = _oDataPGTotalB2B.LMTValue + oData.LMTValue;
                    }
                    else if (oData.Channel == "Dealer")
                    {
                        _oDataPGTotalDealer.DTDQty = _oDataPGTotalDealer.DTDQty + oData.DTDQty;
                        _oDataPGTotalDealer.LDQty = _oDataPGTotalDealer.LDQty + oData.LDQty;
                        _oDataPGTotalDealer.MTDQty = _oDataPGTotalDealer.MTDQty + oData.MTDQty;
                        _oDataPGTotalDealer.LMQty = _oDataPGTotalDealer.LMQty + oData.LMQty;
                        _oDataPGTotalDealer.YTDQty = _oDataPGTotalDealer.YTDQty + oData.YTDQty;
                        _oDataPGTotalDealer.LYQty = _oDataPGTotalDealer.LYQty + oData.LYQty;
                        _oDataPGTotalDealer.LYYTDQty = _oDataPGTotalDealer.LYYTDQty + oData.LYYTDQty;
                        _oDataPGTotalDealer.LYMTDQty = _oDataPGTotalDealer.LYMTDQty + oData.LYMTDQty;
                        _oDataPGTotalDealer.CMTQty = _oDataPGTotalDealer.CMTQty + oData.CMTQty;
                        _oDataPGTotalDealer.LMTQty = _oDataPGTotalDealer.LMTQty + oData.LMTQty;

                        _oDataPGTotalDealer.DTDValue = _oDataPGTotalDealer.DTDValue + oData.DTDValue;
                        _oDataPGTotalDealer.LDValue = _oDataPGTotalDealer.LDValue + oData.LDValue;
                        _oDataPGTotalDealer.MTDValue = _oDataPGTotalDealer.MTDValue + oData.MTDValue;
                        _oDataPGTotalDealer.LMValue = _oDataPGTotalDealer.LMValue + oData.LMValue;
                        _oDataPGTotalDealer.YTDValue = _oDataPGTotalDealer.YTDValue + oData.YTDValue;
                        _oDataPGTotalDealer.LYValue = _oDataPGTotalDealer.LYValue + oData.LYValue;
                        _oDataPGTotalDealer.LYYTDValue = _oDataPGTotalDealer.LYYTDValue + oData.LYYTDValue;
                        _oDataPGTotalDealer.LYMTDValue = _oDataPGTotalDealer.LYMTDValue + oData.LYMTDValue;
                        _oDataPGTotalDealer.CMTValue = _oDataPGTotalDealer.CMTValue + oData.CMTValue;
                        _oDataPGTotalDealer.LMTValue = _oDataPGTotalDealer.LMTValue + oData.LMTValue;
                    }
                    else if (oData.Channel == "All")
                    {
                        _oDataPGTotalAll.DTDQty = _oDataPGTotalAll.DTDQty + oData.DTDQty;
                        _oDataPGTotalAll.LDQty = _oDataPGTotalAll.LDQty + oData.LDQty;
                        _oDataPGTotalAll.MTDQty = _oDataPGTotalAll.MTDQty + oData.MTDQty;
                        _oDataPGTotalAll.LMQty = _oDataPGTotalAll.LMQty + oData.LMQty;
                        _oDataPGTotalAll.YTDQty = _oDataPGTotalAll.YTDQty + oData.YTDQty;
                        _oDataPGTotalAll.LYQty = _oDataPGTotalAll.LYQty + oData.LYQty;
                        _oDataPGTotalAll.LYYTDQty = _oDataPGTotalAll.LYYTDQty + oData.LYYTDQty;
                        _oDataPGTotalAll.LYMTDQty = _oDataPGTotalAll.LYMTDQty + oData.LYMTDQty;
                        _oDataPGTotalAll.CMTQty = _oDataPGTotalAll.CMTQty + oData.CMTQty;
                        _oDataPGTotalAll.LMTQty = _oDataPGTotalAll.LMTQty + oData.LMTQty;

                        _oDataPGTotalAll.DTDValue = _oDataPGTotalAll.DTDValue + oData.DTDValue;
                        _oDataPGTotalAll.LDValue = _oDataPGTotalAll.LDValue + oData.LDValue;
                        _oDataPGTotalAll.MTDValue = _oDataPGTotalAll.MTDValue + oData.MTDValue;
                        _oDataPGTotalAll.LMValue = _oDataPGTotalAll.LMValue + oData.LMValue;
                        _oDataPGTotalAll.YTDValue = _oDataPGTotalAll.YTDValue + oData.YTDValue;
                        _oDataPGTotalAll.LYValue = _oDataPGTotalAll.LYValue + oData.LYValue;
                        _oDataPGTotalAll.LYYTDValue = _oDataPGTotalAll.LYYTDValue + oData.LYYTDValue;
                        _oDataPGTotalAll.LYMTDValue = _oDataPGTotalAll.LYMTDValue + oData.LYMTDValue;
                        _oDataPGTotalAll.CMTValue = _oDataPGTotalAll.CMTValue + oData.CMTValue;
                        _oDataPGTotalAll.LMTValue = _oDataPGTotalAll.LMTValue + oData.LMTValue;
                    }
                    else if (oData.Channel == "CAC")
                    {
                        _oDataPGTotalCAC.DTDQty = _oDataPGTotalCAC.DTDQty + oData.DTDQty;
                        _oDataPGTotalCAC.LDQty = _oDataPGTotalCAC.LDQty + oData.LDQty;
                        _oDataPGTotalCAC.MTDQty = _oDataPGTotalCAC.MTDQty + oData.MTDQty;
                        _oDataPGTotalCAC.LMQty = _oDataPGTotalCAC.LMQty + oData.LMQty;
                        _oDataPGTotalCAC.YTDQty = _oDataPGTotalCAC.YTDQty + oData.YTDQty;
                        _oDataPGTotalCAC.LYQty = _oDataPGTotalCAC.LYQty + oData.LYQty;
                        _oDataPGTotalCAC.LYYTDQty = _oDataPGTotalCAC.LYYTDQty + oData.LYYTDQty;
                        _oDataPGTotalCAC.LYMTDQty = _oDataPGTotalCAC.LYMTDQty + oData.LYMTDQty;
                        _oDataPGTotalCAC.CMTQty = _oDataPGTotalCAC.CMTQty + oData.CMTQty;
                        _oDataPGTotalCAC.LMTQty = _oDataPGTotalCAC.LMTQty + oData.LMTQty;

                        _oDataPGTotalCAC.DTDValue = _oDataPGTotalCAC.DTDValue + oData.DTDValue;
                        _oDataPGTotalCAC.LDValue = _oDataPGTotalCAC.LDValue + oData.LDValue;
                        _oDataPGTotalCAC.MTDValue = _oDataPGTotalCAC.MTDValue + oData.MTDValue;
                        _oDataPGTotalCAC.LMValue = _oDataPGTotalCAC.LMValue + oData.LMValue;
                        _oDataPGTotalCAC.YTDValue = _oDataPGTotalCAC.YTDValue + oData.YTDValue;
                        _oDataPGTotalCAC.LYValue = _oDataPGTotalCAC.LYValue + oData.LYValue;
                        _oDataPGTotalCAC.LYYTDValue = _oDataPGTotalCAC.LYYTDValue + oData.LYYTDValue;
                        _oDataPGTotalCAC.LYMTDValue = _oDataPGTotalCAC.LYMTDValue + oData.LYMTDValue;
                        _oDataPGTotalCAC.CMTValue = _oDataPGTotalCAC.CMTValue + oData.CMTValue;
                        _oDataPGTotalCAC.LMTValue = _oDataPGTotalCAC.LMTValue + oData.LMTValue;
                    }
                }
            }

            #endregion

            if (sCompany == "TEL")
            {
                //if (sType == "All")
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
        public string ProductGroupType;
        public string Channel;
        public string ProductGroupName;
        public string BrandName;
        public string Name;
        public string Type;
        public string ParentID;
        public string ProductGroupID;

        public int DTDQty;
        public double DTDValue;
        public int LDQty;
        public double LDValue;
        public int MTDQty;
        public double MTDValue;
        public int LMQty;
        public double LMValue;
        public int YTDQty;
        public double YTDValue;
        public int LYQty;
        public double LYValue;
        public int LYYTDQty;
        public double LYYTDValue;
        public int LYMTDQty;
        public double LYMTDValue;
        public int CMTQty;
        public double CMTValue;
        public int LMTQty;
        public double LMTValue;

        public string DTDQtyText;
        public string DTDValueText;
        public string LDQtyText;
        public string LDValueText;
        public string LMQtyText;
        public string LMValueText;
        public string MTDQtyText;
        public string MTDValueText;
        public string YTDQtyText;
        public string YTDValueText;
        public string LYQtyText;
        public string LYValueText;

        public string LYYTDQtyText;
        public string LYYTDValueText;
        public string LYMTDQtyText;
        public string LYMTDValueText;
        public string CMTQtyText;
        public string CMTValueText;
        public string LMTQtyText;
        public string LMTValueText;

        public string MTDQtyPercText;
        public string LMQtyPercText;
        public string MTDQtyGthPercText;
        public string YTDQtyGthPercText;

        public string MTDValuePercText;
        public string LMValuePercText;
        public string MTDValueGthPercText;
        public string YTDValueGthPercText;

        public string Value;

        public int GetMarketGroupID(string sCompany, string sDatabase, string sValue, string sValueType)
        {
            TELLib _oTELLib = new TELLib();

            int nID = 0;

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (sValueType == "ByArea")
            {
                sSQL = " select AreaID as ID from TELSysDB.dbo.v_CustomerDetails a, " +
                       " TELSysDB.dbo.t_Showroom b Where a.CustomerID=b.CustomerID and AreaShortName='" + sValue + "' Group by AreaID ";

            }
            else if (sValueType == "ByZone")
            {
                sSQL = " select TerritoryID as ID from TELSysDB.dbo.v_CustomerDetails a, " +
                       " TELSysDB.dbo.t_Showroom b Where a.CustomerID=b.CustomerID and TerritoryShortName='" + sValue + "' Group by TerritoryID ";
            }
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nID = Convert.ToInt32(reader["ID"]);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nID;
        }

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
        
        public void GetData(string sCompany, string sDatabase, string sChannel, string sValue, string sValueType, int nMarketGroupID)
        {
            string sSQL = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (sChannel == "TD")
            {
                sSQL = " Select * from " +
                       " ( " +
                       " select ProductGroupType, CASE When ProductGroupType = 'PG' then 1 When ProductGroupType = 'MAG' then 2  " +
                       " When ProductGroupType = 'ASG' then 3 else 4 end as Type, " +
                       "  Channel, ProductGroupName, ProductGroupSort, BrandName, BrandSort, ProductGroupID, ParentID, " +
                       " Sum(DTDQty) as DTDQty, Sum(DTDValue) as DTDValue, Sum(LDQty) as LDQty, Sum(LDValue) as LDValue,  " +
                       " Sum(MTDQty) as MTDQty, Sum(MTDValue) as MTDValue, Sum(LMQty) as LMQty, Sum(LMValue) as LMValue,  " +
                       " Sum(YTDQty) as YTDQty, Sum(YTDValue) as YTDValue, Sum(LYQty) as LYQty, Sum(LYValue) as LYValue,  " +
                       " Sum(LYYTDQty) as LYYTDQty, Sum(LYYTDValue) as LYYTDValue, Sum(LYMTDQty) as LYMTDQty, Sum(LYMTDValue) as LYMTDValue,  " +
                       " Sum(CMTQty) as CMTQty, Sum(CMTValue) as CMTValue, Sum(LMTQty) as LMTQty, Sum(LMTValue) as LMTValue  " +
                       " from DWDB.dbo.t_SalesDataProductGroupQtyValueNew a, TELSysDB.dbo.t_Showroom b,  " +
                       " (Select CustomerID, AreaID, TerritoryID, AreaShortName, TerritoryShortName from TELSysDB.dbo.v_CustomerDetails) c " +
                       " Where a.WarehouseID=b.WarehouseID and b.CustomerID=c.CustomerID " +
                       " and Company='TEL' and BUID = 2 ";
                        
                        if (sValueType == "ByArea")
                        {
                            sSQL = sSQL + " and AreaID = " + nMarketGroupID + " ";
                        }
                        else if (sValueType == "ByZone")
                        {
                            sSQL = sSQL + " and TerritoryID = " + nMarketGroupID + " ";
                        }
                        else if (sValueType == "ByOutlet")
                        {
                            sSQL = sSQL + " and ShowroomCode = '" + sValue + "' ";
                        }

                       sSQL = sSQL + " Group by ProductGroupType, Channel, ProductGroupName, ProductGroupSort, BrandName, BrandSort, ProductGroupID, ParentID " +
                       " )a  " +
                       " Order by Type , Channel Desc, ProductGroupSort,ProductGroupName,BrandSort,BrandName ";

            }
            else if (sChannel == "Dealer")
            {
                sSQL = " Select * from " +
                          " ( " +
                          " select ProductGroupType, CASE When ProductGroupType = 'PG' then 1 When ProductGroupType = 'MAG' then 2  " +
                          " When ProductGroupType = 'ASG' then 3 else 4 end as Type, " +
                          "  Channel, ProductGroupName, ProductGroupSort, BrandName, BrandSort, ProductGroupID, ParentID, " +
                          " Sum(DTDQty) as DTDQty, Sum(DTDValue) as DTDValue, Sum(LDQty) as LDQty, Sum(LDValue) as LDValue,  " +
                          " Sum(MTDQty) as MTDQty, Sum(MTDValue) as MTDValue, Sum(LMQty) as LMQty, Sum(LMValue) as LMValue,  " +
                          " Sum(YTDQty) as YTDQty, Sum(YTDValue) as YTDValue, Sum(LYQty) as LYQty, Sum(LYValue) as LYValue,  " +
                          " Sum(LYYTDQty) as LYYTDQty, Sum(LYYTDValue) as LYYTDValue, Sum(LYMTDQty) as LYMTDQty, Sum(LYMTDValue) as LYMTDValue,  " +
                          " Sum(CMTQty) as CMTQty, Sum(CMTValue) as CMTValue, Sum(LMTQty) as LMTQty, Sum(LMTValue) as LMTValue  " +
                          " from DWDB.dbo.t_SalesDataProductGroupQtyValueNew Where Company='TEL' and BUID = 5 " +
                          " Group by ProductGroupType, Channel, ProductGroupName, ProductGroupSort, BrandName, BrandSort, ProductGroupID, ParentID " +
                          " )a  " +
                          " Order by Type , Channel Desc, ProductGroupSort,ProductGroupName,BrandSort,BrandName ";
            }
            else if (sChannel == "CAC")
            {
                sSQL = " Select * from " +
                          " ( " +
                          " select ProductGroupType, CASE When ProductGroupType = 'PG' then 1 When ProductGroupType = 'MAG' then 2  " +
                          " When ProductGroupType = 'ASG' then 3 else 4 end as Type, " +
                          "  Channel, ProductGroupName, ProductGroupSort, BrandName, BrandSort, ProductGroupID, ParentID, " +
                          " Sum(DTDQty) as DTDQty, Sum(DTDValue) as DTDValue, Sum(LDQty) as LDQty, Sum(LDValue) as LDValue,  " +
                          " Sum(MTDQty) as MTDQty, Sum(MTDValue) as MTDValue, Sum(LMQty) as LMQty, Sum(LMValue) as LMValue,  " +
                          " Sum(YTDQty) as YTDQty, Sum(YTDValue) as YTDValue, Sum(LYQty) as LYQty, Sum(LYValue) as LYValue,  " +
                          " Sum(LYYTDQty) as LYYTDQty, Sum(LYYTDValue) as LYYTDValue, Sum(LYMTDQty) as LYMTDQty, Sum(LYMTDValue) as LYMTDValue,  " +
                          " Sum(CMTQty) as CMTQty, Sum(CMTValue) as CMTValue, Sum(LMTQty) as LMTQty, Sum(LMTValue) as LMTValue  " +
                          " from DWDB.dbo.t_SalesDataProductGroupQtyValueNew Where Company='TEL' and BUID = 7 " +
                          " Group by ProductGroupType, Channel, ProductGroupName, ProductGroupSort, BrandName, BrandSort, ProductGroupID, ParentID " +
                          " )a  " +
                          " Order by Type , Channel Desc, ProductGroupSort,ProductGroupName,BrandSort,BrandName ";
            }
            else if (sChannel == "All")
            {
                sSQL = " Select * from " +
                          " ( " +
                          " select ProductGroupType, CASE When ProductGroupType = 'PG' then 1 When ProductGroupType = 'MAG' then 2  " +
                          " When ProductGroupType = 'ASG' then 3 else 4 end as Type, " +
                          "  Channel, ProductGroupName, ProductGroupSort, BrandName, BrandSort, ProductGroupID, ParentID, " +
                          " Sum(DTDQty) as DTDQty, Sum(DTDValue) as DTDValue, Sum(LDQty) as LDQty, Sum(LDValue) as LDValue,  " +
                          " Sum(MTDQty) as MTDQty, Sum(MTDValue) as MTDValue, Sum(LMQty) as LMQty, Sum(LMValue) as LMValue,  " +
                          " Sum(YTDQty) as YTDQty, Sum(YTDValue) as YTDValue, Sum(LYQty) as LYQty, Sum(LYValue) as LYValue,  " +
                          " Sum(LYYTDQty) as LYYTDQty, Sum(LYYTDValue) as LYYTDValue, Sum(LYMTDQty) as LYMTDQty, Sum(LYMTDValue) as LYMTDValue,  " +
                          " Sum(CMTQty) as CMTQty, Sum(CMTValue) as CMTValue, Sum(LMTQty) as LMTQty, Sum(LMTValue) as LMTValue  " +
                          " from DWDB.dbo.t_SalesDataProductGroupQtyValueNew Where Company='TEL' " +
                          " Group by ProductGroupType, Channel, ProductGroupName, ProductGroupSort, BrandName, BrandSort, ProductGroupID, ParentID " +
                          " )a  " +
                          " Order by Type , Channel Desc, ProductGroupSort,ProductGroupName,BrandSort,BrandName ";
            }
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.ProductGroupType = reader["ProductGroupType"].ToString();
                    oData.ProductGroupName = reader["ProductGroupName"].ToString();
                    oData.Channel = reader["Channel"].ToString();
                    oData.BrandName = reader["BrandName"].ToString();
                    oData.ParentID = reader["ParentID"].ToString();
                    oData.ProductGroupID = reader["ProductGroupID"].ToString();

                    oData.DTDQty = Convert.ToInt32(reader["DTDQty"]);
                    oData.DTDValue = Convert.ToDouble(reader["DTDValue"]);
                    oData.LDQty = Convert.ToInt32(reader["LDQty"]);
                    oData.LDValue = Convert.ToDouble(reader["LDValue"]);
                    oData.MTDQty = Convert.ToInt32(reader["MTDQty"]);
                    oData.MTDValue = Convert.ToDouble(reader["MTDValue"]);
                    oData.LMQty = Convert.ToInt32(reader["LMQty"]);
                    oData.LMValue = Convert.ToDouble(reader["LMValue"]);
                    oData.YTDQty = Convert.ToInt32(reader["YTDQty"]);
                    oData.YTDValue = Convert.ToDouble(reader["YTDValue"]);
                    oData.LYQty = Convert.ToInt32(reader["LYQty"]);
                    oData.LYValue = Convert.ToDouble(reader["LYValue"]);
                    oData.LYYTDQty = Convert.ToInt32(reader["LYYTDQty"]);
                    oData.LYYTDValue = Convert.ToDouble(reader["LYYTDValue"]);
                    oData.LYMTDQty = Convert.ToInt32(reader["LYMTDQty"]);
                    oData.LYMTDValue = Convert.ToDouble(reader["LYMTDValue"]);
                    oData.CMTQty = Convert.ToInt32(reader["CMTQty"]);
                    oData.CMTValue = Convert.ToDouble(reader["CMTValue"]);
                    oData.LMTQty = Convert.ToInt32(reader["LMTQty"]);
                    oData.LMTValue = Convert.ToDouble(reader["LMTValue"]);

                    InnerList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetAllBrandData(string sCompany, string sDatabase, string sChannel, string sValue, string sValueType, int nMargetGroupID)
        {
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (sChannel == "TD")
            {
                sSQL = " Select * from " +
                        " (  " +
                        " select 'All' as ProductGroupType, '0' as Type,  " +
                        "  Channel, 'All' as ProductGroupName, 0 as ProductGroupSort, BrandName, BrandSort, 0 as ProductGroupID, 0 as ParentID,  " +
                        " Sum(DTDQty) as DTDQty, Sum(DTDValue) as DTDValue, Sum(LDQty) as LDQty, Sum(LDValue) as LDValue,   " +
                        " Sum(MTDQty) as MTDQty, Sum(MTDValue) as MTDValue, Sum(LMQty) as LMQty, Sum(LMValue) as LMValue,   " +
                        " Sum(YTDQty) as YTDQty, Sum(YTDValue) as YTDValue, Sum(LYQty) as LYQty, Sum(LYValue) as LYValue,   " +
                        " Sum(LYYTDQty) as LYYTDQty, Sum(LYYTDValue) as LYYTDValue, Sum(LYMTDQty) as LYMTDQty, Sum(LYMTDValue) as LYMTDValue,   " +
                        " Sum(CMTQty) as CMTQty, Sum(CMTValue) as CMTValue, Sum(LMTQty) as LMTQty, Sum(LMTValue) as LMTValue   " +
                        " from DWDB.dbo.t_SalesDataProductGroupQtyValue a, TELSysDB.dbo.t_Showroom b,  " +
                        " (Select CustomerID, AreaID, TerritoryID, AreaShortName, TerritoryShortName from TELSysDB.dbo.v_CustomerDetails) c " +
                        " Where a.WarehouseID=b.WarehouseID and b.CustomerID=c.CustomerID  " +
                        " and Company='TEL' and Channel in ('TD','Retail','B2B','Dealer') and ProductGroupType = 'PG'  ";
                        if (sValueType == "ByArea")
                        {
                            sSQL = sSQL + " and AreaID = " + nMargetGroupID + " ";
                        }
                        else if (sValueType == "ByZone")
                        {
                            sSQL = sSQL + " and TerritoryID = " + nMargetGroupID + " ";
                        }
                        else if (sValueType == "ByOutlet")
                        {
                            sSQL = sSQL + " and ShowroomCode = '" + sValue + "' ";
                        }

                        sSQL = sSQL + " Group by Channel, BrandName, BrandSort  " +
                        " )a   " +
                        " Order by Type , Channel Desc, BrandSort, BrandName ";

            }
            else if (sChannel == "Retail")
            {
                sSQL = " Select * from " +
                        " (  " +
                        " select 'All' as ProductGroupType, '0' as Type,  " +
                        "  Channel, 'All' as ProductGroupName, 0 as ProductGroupSort, BrandName, BrandSort, 0 as ProductGroupID, 0 as ParentID,  " +
                        " Sum(DTDQty) as DTDQty, Sum(DTDValue) as DTDValue, Sum(LDQty) as LDQty, Sum(LDValue) as LDValue,   " +
                        " Sum(MTDQty) as MTDQty, Sum(MTDValue) as MTDValue, Sum(LMQty) as LMQty, Sum(LMValue) as LMValue,   " +
                        " Sum(YTDQty) as YTDQty, Sum(YTDValue) as YTDValue, Sum(LYQty) as LYQty, Sum(LYValue) as LYValue,   " +
                        " Sum(LYYTDQty) as LYYTDQty, Sum(LYYTDValue) as LYYTDValue, Sum(LYMTDQty) as LYMTDQty, Sum(LYMTDValue) as LYMTDValue,   " +
                        " Sum(CMTQty) as CMTQty, Sum(CMTValue) as CMTValue, Sum(LMTQty) as LMTQty, Sum(LMTValue) as LMTValue   " +
                        " from DWDB.dbo.t_SalesDataProductGroupQtyValue a, TELSysDB.dbo.t_Showroom b " +
                        " Where a.WarehouseID=b.WarehouseID  " +
                        " and Company='TEL' and Channel in ('Retail') and ProductGroupType = 'PG'  " +
                        " Group by Channel, BrandName, BrandSort  " +
                        " )a   " +
                        " Order by Type , Channel Desc, BrandSort, BrandName ";
            }
            else if (sChannel == "B2B")
            {
                sSQL = " Select * from " +
                        " (  " +
                        " select 'All' as ProductGroupType, '0' as Type,  " +
                        "  Channel, 'All' as ProductGroupName, 0 as ProductGroupSort, BrandName, BrandSort, 0 as ProductGroupID, 0 as ParentID,  " +
                        " Sum(DTDQty) as DTDQty, Sum(DTDValue) as DTDValue, Sum(LDQty) as LDQty, Sum(LDValue) as LDValue,   " +
                        " Sum(MTDQty) as MTDQty, Sum(MTDValue) as MTDValue, Sum(LMQty) as LMQty, Sum(LMValue) as LMValue,   " +
                        " Sum(YTDQty) as YTDQty, Sum(YTDValue) as YTDValue, Sum(LYQty) as LYQty, Sum(LYValue) as LYValue,   " +
                        " Sum(LYYTDQty) as LYYTDQty, Sum(LYYTDValue) as LYYTDValue, Sum(LYMTDQty) as LYMTDQty, Sum(LYMTDValue) as LYMTDValue,   " +
                        " Sum(CMTQty) as CMTQty, Sum(CMTValue) as CMTValue, Sum(LMTQty) as LMTQty, Sum(LMTValue) as LMTValue   " +
                        " from DWDB.dbo.t_SalesDataProductGroupQtyValue a, TELSysDB.dbo.t_Showroom b " +
                        " Where a.WarehouseID=b.WarehouseID  " +
                        " and Company='TEL' and Channel in ('B2B') and ProductGroupType = 'PG'  " +
                        " Group by Channel, BrandName, BrandSort  " +
                        " )a   " +
                        " Order by Type , Channel Desc, BrandSort, BrandName ";
            }
            else if (sChannel == "Dealer")
            {
                sSQL = " Select * from " +
                        " (  " +
                        " select 'All' as ProductGroupType, '0' as Type,  " +
                        "  Channel, 'All' as ProductGroupName, 0 as ProductGroupSort, BrandName, BrandSort, 0 as ProductGroupID, 0 as ParentID,  " +
                        " Sum(DTDQty) as DTDQty, Sum(DTDValue) as DTDValue, Sum(LDQty) as LDQty, Sum(LDValue) as LDValue,   " +
                        " Sum(MTDQty) as MTDQty, Sum(MTDValue) as MTDValue, Sum(LMQty) as LMQty, Sum(LMValue) as LMValue,   " +
                        " Sum(YTDQty) as YTDQty, Sum(YTDValue) as YTDValue, Sum(LYQty) as LYQty, Sum(LYValue) as LYValue,   " +
                        " Sum(LYYTDQty) as LYYTDQty, Sum(LYYTDValue) as LYYTDValue, Sum(LYMTDQty) as LYMTDQty, Sum(LYMTDValue) as LYMTDValue,   " +
                        " Sum(CMTQty) as CMTQty, Sum(CMTValue) as CMTValue, Sum(LMTQty) as LMTQty, Sum(LMTValue) as LMTValue   " +
                        " from DWDB.dbo.t_SalesDataProductGroupQtyValue Where Company='TEL' and Channel in ('Dealer') and ProductGroupType = 'PG'  " +
                        " Group by Channel, BrandName, BrandSort  " +
                        " )a   " +
                        " Order by Type , Channel Desc, BrandSort, BrandName ";
            }
            else if (sChannel == "CAC")
            {
                sSQL = " Select * from " +
                        " (  " +
                        " select 'All' as ProductGroupType, '0' as Type,  " +
                        "  Channel, 'All' as ProductGroupName, 0 as ProductGroupSort, BrandName, BrandSort, 0 as ProductGroupID, 0 as ParentID,  " +
                        " Sum(DTDQty) as DTDQty, Sum(DTDValue) as DTDValue, Sum(LDQty) as LDQty, Sum(LDValue) as LDValue,   " +
                        " Sum(MTDQty) as MTDQty, Sum(MTDValue) as MTDValue, Sum(LMQty) as LMQty, Sum(LMValue) as LMValue,   " +
                        " Sum(YTDQty) as YTDQty, Sum(YTDValue) as YTDValue, Sum(LYQty) as LYQty, Sum(LYValue) as LYValue,   " +
                        " Sum(LYYTDQty) as LYYTDQty, Sum(LYYTDValue) as LYYTDValue, Sum(LYMTDQty) as LYMTDQty, Sum(LYMTDValue) as LYMTDValue,   " +
                        " Sum(CMTQty) as CMTQty, Sum(CMTValue) as CMTValue, Sum(LMTQty) as LMTQty, Sum(LMTValue) as LMTValue   " +
                        " from DWDB.dbo.t_SalesDataProductGroupQtyValue Where Company='TEL' and Channel in ('CAC') and ProductGroupType = 'PG'  " +
                        " Group by Channel, BrandName, BrandSort  " +
                        " )a   " +
                        " Order by Type , Channel Desc, BrandSort, BrandName ";
            }
            else if (sChannel == "All")
            {
                sSQL = " Select * from " +
                        " (  " +
                        " select 'All' as ProductGroupType, '0' as Type,  " +
                        "  Channel, 'All' as ProductGroupName, 0 as ProductGroupSort, BrandName, BrandSort, 0 as ProductGroupID, 0 as ParentID,  " +
                        " Sum(DTDQty) as DTDQty, Sum(DTDValue) as DTDValue, Sum(LDQty) as LDQty, Sum(LDValue) as LDValue,   " +
                        " Sum(MTDQty) as MTDQty, Sum(MTDValue) as MTDValue, Sum(LMQty) as LMQty, Sum(LMValue) as LMValue,   " +
                        " Sum(YTDQty) as YTDQty, Sum(YTDValue) as YTDValue, Sum(LYQty) as LYQty, Sum(LYValue) as LYValue,   " +
                        " Sum(LYYTDQty) as LYYTDQty, Sum(LYYTDValue) as LYYTDValue, Sum(LYMTDQty) as LYMTDQty, Sum(LYMTDValue) as LYMTDValue,   " +
                        " Sum(CMTQty) as CMTQty, Sum(CMTValue) as CMTValue, Sum(LMTQty) as LMTQty, Sum(LMTValue) as LMTValue   " +
                        " from DWDB.dbo.t_SalesDataProductGroupQtyValue Where Company='TEL' and Channel in ('All') and ProductGroupType = 'PG'  " +
                        " Group by Channel, BrandName, BrandSort  " +
                        " )a   " +
                        " Order by Type , Channel Desc, BrandSort, BrandName ";
            }
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.ProductGroupType = reader["ProductGroupType"].ToString();
                    oData.ProductGroupName = reader["ProductGroupName"].ToString();
                    oData.Channel = reader["Channel"].ToString();
                    oData.BrandName = reader["BrandName"].ToString();
                    oData.ParentID = reader["ParentID"].ToString();
                    oData.ProductGroupID = reader["ProductGroupID"].ToString();

                    oData.DTDQty = Convert.ToInt32(reader["DTDQty"]);
                    oData.DTDValue = Convert.ToDouble(reader["DTDValue"]);
                    oData.LDQty = Convert.ToInt32(reader["LDQty"]);
                    oData.LDValue = Convert.ToDouble(reader["LDValue"]);
                    oData.MTDQty = Convert.ToInt32(reader["MTDQty"]);
                    oData.MTDValue = Convert.ToDouble(reader["MTDValue"]);
                    oData.LMQty = Convert.ToInt32(reader["LMQty"]);
                    oData.LMValue = Convert.ToDouble(reader["LMValue"]);
                    oData.YTDQty = Convert.ToInt32(reader["YTDQty"]);
                    oData.YTDValue = Convert.ToDouble(reader["YTDValue"]);
                    oData.LYQty = Convert.ToInt32(reader["LYQty"]);
                    oData.LYValue = Convert.ToDouble(reader["LYValue"]);
                    oData.LYYTDQty = Convert.ToInt32(reader["LYYTDQty"]);
                    oData.LYYTDValue = Convert.ToDouble(reader["LYYTDValue"]);
                    oData.LYMTDQty = Convert.ToInt32(reader["LYMTDQty"]);
                    oData.LYMTDValue = Convert.ToDouble(reader["LYMTDValue"]);
                    oData.CMTQty = Convert.ToInt32(reader["CMTQty"]);
                    oData.CMTValue = Convert.ToDouble(reader["CMTValue"]);
                    oData.LMTQty = Convert.ToInt32(reader["LMTQty"]);
                    oData.LMTValue = Convert.ToDouble(reader["LMTValue"]);

                    InnerList.Add(oData);
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
            foreach (Data oData in this)
            {
                _oData = new Data();
                _oData.Name = oData.Name;
                _oData.ProductGroupType = oData.ProductGroupType;
                _oData.Channel = oData.Channel;
                _oData.ProductGroupName = oData.ProductGroupName;
                _oData.ParentID = oData.ParentID;
                _oData.ProductGroupID = oData.ProductGroupID;
                _oData.Type = oData.Type;
                _oData.Value = oData.Value;

                _oData.DTDQtyText = oData.DTDQty.ToString();
                _oData.LDQtyText = oData.LDQty.ToString();
                _oData.MTDQtyText = oData.MTDQty.ToString();
                _oData.LMQtyText = oData.LMQty.ToString();
                _oData.YTDQtyText = oData.YTDQty.ToString();
                _oData.LYQtyText = oData.LYQty.ToString();
                _oData.LYYTDQtyText = oData.LYYTDQty.ToString();
                _oData.LYMTDQtyText = oData.LYMTDQty.ToString();
                _oData.CMTQtyText = oData.CMTQty.ToString();
                _oData.LMTQtyText = oData.LMTQty.ToString();

                _oData.DTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.DTDValue));
                _oData.LDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LDValue));
                _oData.MTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.MTDValue));
                _oData.LMValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMValue));
                _oData.YTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.YTDValue));
                _oData.LYValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYValue));
                _oData.LYYTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYYTDValue));
                _oData.LYMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYMTDValue));
                _oData.CMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMTValue));
                _oData.LMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMTValue));

                if (oData.CMTQty > 0)
                {
                    _oData.MTDQtyPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.MTDQty) / oData.CMTQty) * 100));
                }
                else
                {
                    _oData.MTDQtyPercText = "0";
                }
                if (oData.LMTQty > 0)
                {
                    _oData.LMQtyPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.LMQty) / oData.LMTQty) * 100));
                }
                else
                {
                    _oData.LMQtyPercText = "0";
                }
                if (oData.LYMTDQty > 0)
                {
                    _oData.MTDQtyGthPercText = Convert.ToString(Math.Round(((Convert.ToDouble(oData.MTDQty) / oData.LYMTDQty) * 100) - 100));
                }
                else
                {
                    _oData.MTDQtyGthPercText = "0";
                }
                if (oData.LYYTDQty > 0)
                {
                    _oData.YTDQtyGthPercText = Convert.ToString(Math.Round(((Convert.ToDouble(oData.YTDQty) / oData.LYYTDQty) * 100) - 100));
                }
                else
                {
                    _oData.YTDQtyGthPercText = "0";
                }

                ////
                if (oData.CMTValue > 0)
                {
                    _oData.MTDValuePercText = Convert.ToString(Math.Round((oData.MTDValue / oData.CMTValue) * 100));
                }
                else
                {
                    _oData.MTDValuePercText = "0";
                }
                if (oData.LMTValue > 0)
                {
                    _oData.LMValuePercText = Convert.ToString(Math.Round((oData.LMValue / oData.LMTValue) * 100));
                }
                else
                {
                    _oData.LMValuePercText = "0";
                }
                if (oData.LYMTDValue > 0)
                {
                    _oData.MTDValueGthPercText = Convert.ToString(Math.Round(((oData.MTDValue / oData.LYMTDValue) * 100) - 100));
                }
                else
                {
                    _oData.MTDValueGthPercText = "0";
                }
                if (oData.LYYTDValue > 0)
                {
                    _oData.YTDValueGthPercText = Convert.ToString(Math.Round(((oData.YTDValue / oData.LYYTDValue) * 100) - 100));
                }
                else
                {
                    _oData.YTDValueGthPercText = "0";
                }

                eList.Add(_oData);
            }
            return eList;

        }
      
    }
}



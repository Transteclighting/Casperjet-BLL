using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Data.OleDb;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using CJ.Class;
using CJ.Class.Library;


public partial class jBLLProductSalesQtyAndValueRevisedByMarketGroup : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sIsProductGroupChecked = c.Request.Form["sIsProductGroupChecked"].Trim();
            string sPGID = c.Request.Form["sPGID"].Trim();
            string sMAGID = c.Request.Form["sMAGID"].Trim();
            string sASGID = c.Request.Form["sASGID"].Trim();
            string sBrandID = c.Request.Form["sBrandID"].Trim();
            string sAndroidAppID = "";
            if (c.Request.Form["AndroidAppID"] != null)
            {
                sAndroidAppID = c.Request.Form["AndroidAppID"].Trim();
            }
            else
            {
                sAndroidAppID = Convert.ToString((int)Dictionary.AndroidAppID.CJ_Apps);
            }



            //string sUser = "hakim";
            //string sChannel = "All";
            //string sIsProductGroupChecked = "false";
            //string sPGID = "-1";
            //string sMAGID = "3";
            //string sASGID = "208";
            //string sBrandID = "3129";
            //string sDatabase = "x";
            //string sAndroidAppID = "3";



            Datas oDatas = new Datas();
            Data _oData = new Data();
            Datas _oDatas = new Datas();
            Data _oDataTotal = new Data();
           
            Data _oDataPGTotalAll = new Data();
            Data _oDataPGTotalGTM = new Data();
            Data _oDataPGTotalIL = new Data();

          

            int nCount = 0;
            int nTotalCount = 0;

       
            DBController.Instance.OpenNewConnection();
            
            oDatas.GetData(sIsProductGroupChecked, sPGID, sMAGID, sASGID, sBrandID, sUser, sAndroidAppID);

           
            DBController.Instance.CloseConnection();

            #region NewLoop
            foreach (Data oData in oDatas)
            {
                nTotalCount = 0;

                if (nCount == 0)
                {

                    _oDataPGTotalAll = new Data();
                    _oDatas.Add(_oDataPGTotalAll);
                    _oDataPGTotalAll.Name = "Total";
                    _oDataPGTotalAll.Type = "PGTotal";
                    _oDataPGTotalAll.Value = "Success";
                    _oDataPGTotalAll.MarketGroupName = "PGTotal";
                    _oDataPGTotalAll.MarketGroupType = "PGTotal";
                    _oDataPGTotalAll.ParentID = "0";
                    _oDataPGTotalAll.MarketGroupID = "0";
                    _oDataPGTotalAll.Channel = "All";


                    _oDataPGTotalGTM = new Data();
                    _oDatas.Add(_oDataPGTotalGTM);
                    _oDataPGTotalGTM.Name = "Total";
                    _oDataPGTotalGTM.Type = "PGTotal";
                    _oDataPGTotalGTM.Value = "Success";
                    _oDataPGTotalGTM.MarketGroupName = "PGTotal";
                    _oDataPGTotalGTM.MarketGroupType = "PGTotal";
                    _oDataPGTotalGTM.ParentID = "0";
                    _oDataPGTotalGTM.MarketGroupID = "0";
                    _oDataPGTotalGTM.Channel = "GTM";

                    _oDataPGTotalIL = new Data();
                    _oDatas.Add(_oDataPGTotalIL);
                    _oDataPGTotalIL.Name = "Total";
                    _oDataPGTotalIL.Type = "PGTotal";
                    _oDataPGTotalIL.Value = "Success";
                    _oDataPGTotalIL.MarketGroupName = "PGTotal";
                    _oDataPGTotalIL.MarketGroupType = "PGTotal";
                    _oDataPGTotalIL.ParentID = "0";
                    _oDataPGTotalIL.MarketGroupID = "0";
                    _oDataPGTotalIL.Channel = "IL";

                   /* foreach (Data oDataBrand in oDatasBrands)
                    {
                        _oDataAllBrand = new Data();
                        _oDataAllBrand.MarketGroupType = oDataBrand.MarketGroupType;
                        _oDataAllBrand.Channel = oDataBrand.Channel;
                        _oDataAllBrand.Name = oDataBrand.BrandName;
                        _oDataAllBrand.MarketGroupName = oDataBrand.MarketGroupName;
                        _oDataAllBrand.ParentID = oDataBrand.ParentID;
                        _oDataAllBrand.MarketGroupID = oDataBrand.MarketGroupID;
                        _oDataAllBrand.Type = "BrandAll";
                        _oDataAllBrand.Value = "Success";

                        _oDataAllBrand.PriDTDQty = oDataBrand.PriDTDQty;
                        _oDataAllBrand.PriLDQty = oDataBrand.PriLDQty;
                        _oDataAllBrand.PriMTDQty = oDataBrand.PriMTDQty;
                        _oDataAllBrand.PriLMQty = oDataBrand.PriLMQty;
                        _oDataAllBrand.PriYTDQty = oDataBrand.PriYTDQty;
                        _oDataAllBrand.PriLYQty = oDataBrand.PriLYQty;
                        _oDataAllBrand.PriLYYTDQty = oDataBrand.PriLYYTDQty;
                        _oDataAllBrand.PriLYMTDQty = oDataBrand.PriLYMTDQty;
                        _oDataAllBrand.PriCMTQty = oDataBrand.PriCMTQty;
                        _oDataAllBrand.PriLMTQty = oDataBrand.PriLMTQty;

                        _oDataAllBrand.PriDTDValue = oDataBrand.PriDTDValue;
                        _oDataAllBrand.PriLDValue = oDataBrand.PriLDValue;
                        _oDataAllBrand.PriMTDValue = oDataBrand.PriMTDValue;
                        _oDataAllBrand.PriLMValue = oDataBrand.PriLMValue;
                        _oDataAllBrand.PriYTDValue = oDataBrand.PriYTDValue;
                        _oDataAllBrand.PriLYValue = oDataBrand.PriLYValue;
                        _oDataAllBrand.PriLYYTDValue = oDataBrand.PriLYYTDValue;
                        _oDataAllBrand.PriLYMTDValue = oDataBrand.PriLYMTDValue;
                        _oDataAllBrand.PriCMTValue = oDataBrand.PriCMTValue;
                        _oDataAllBrand.PriLMTValue = oDataBrand.PriLMTValue;

                        _oDataAllBrand.SecDTDQty = oDataBrand.SecDTDQty;
                        _oDataAllBrand.SecLDQty = oDataBrand.SecLDQty;
                        _oDataAllBrand.SecMTDQty = oDataBrand.SecMTDQty;
                        _oDataAllBrand.SecLMQty = oDataBrand.SecLMQty;
                        _oDataAllBrand.SecYTDQty = oDataBrand.SecYTDQty;
                        _oDataAllBrand.SecLYQty = oDataBrand.SecLYQty;
                        _oDataAllBrand.SecLYYTDQty = oDataBrand.SecLYYTDQty;
                        _oDataAllBrand.SecLYMTDQty = oDataBrand.SecLYMTDQty;
                        _oDataAllBrand.SecCMTQty = oDataBrand.SecCMTQty;
                        _oDataAllBrand.SecLMTQty = oDataBrand.SecLMTQty;

                        _oDataAllBrand.SecDTDValue = oDataBrand.SecDTDValue;
                        _oDataAllBrand.SecLDValue = oDataBrand.SecLDValue;
                        _oDataAllBrand.SecMTDValue = oDataBrand.SecMTDValue;
                        _oDataAllBrand.SecLMValue = oDataBrand.SecLMValue;
                        _oDataAllBrand.SecYTDValue = oDataBrand.SecYTDValue;
                        _oDataAllBrand.SecLYValue = oDataBrand.SecLYValue;
                        _oDataAllBrand.SecLYYTDValue = oDataBrand.SecLYYTDValue;
                        _oDataAllBrand.SecLYMTDValue = oDataBrand.SecLYMTDValue;
                        _oDataAllBrand.SecCMTValue = oDataBrand.SecCMTValue;
                        _oDataAllBrand.SecLMTValue = oDataBrand.SecLMTValue;

                        _oDatas.Add(_oDataAllBrand);
                    }*/

                    nCount++;
                }
                if (_oDataTotal.MarketGroupType != oData.MarketGroupType)
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
                        if (_oDataTotal.MarketGroupName != oData.MarketGroupName)
                        {
                            nTotalCount++;
                        }

                    }
                }
                if (nTotalCount > 0)
                {
                    _oDataTotal = new Data();
                    _oDatas.Add(_oDataTotal);
                    _oDataTotal.MarketGroupType = oData.MarketGroupType;
                    _oDataTotal.Channel = oData.Channel;
                    _oDataTotal.MarketGroupName = oData.MarketGroupName;
                    _oDataTotal.BrandName = oData.BrandName;
                    _oDataTotal.Name = oData.MarketGroupName;
                    _oDataTotal.ParentID = oData.ParentID;
                    _oDataTotal.MarketGroupID = oData.MarketGroupID;
                    _oDataTotal.Type = "Total";
                    _oDataTotal.Value = "Success";
                }

               /* _oDataBrand = new Data();
                _oDataBrand.MarketGroupType = oData.MarketGroupType;
                _oDataBrand.Channel = oData.Channel;
                _oDataBrand.Name = oData.BrandName;
                _oDataBrand.MarketGroupName = oData.MarketGroupName;
                _oDataBrand.ParentID = oData.ParentID;
                _oDataBrand.MarketGroupID = oData.MarketGroupID;
                _oDataBrand.Type = "Brand";
                _oDataBrand.Value = "Success";

                _oDataBrand.PriDTDQty = oData.PriDTDQty;
                _oDataBrand.PriLDQty = oData.PriLDQty;
                _oDataBrand.PriMTDQty = oData.PriMTDQty;
                _oDataBrand.PriLMQty = oData.PriLMQty;
                _oDataBrand.PriYTDQty = oData.PriYTDQty;
                _oDataBrand.PriLYQty = oData.PriLYQty;
                _oDataBrand.PriLYYTDQty = oData.PriLYYTDQty;
                _oDataBrand.PriLYMTDQty = oData.PriLYMTDQty;
                _oDataBrand.PriCMTQty = oData.PriCMTQty;
                _oDataBrand.PriLMTQty = oData.PriLMTQty;

                _oDataBrand.PriDTDValue = oData.PriDTDValue;
                _oDataBrand.PriLDValue = oData.PriLDValue;
                _oDataBrand.PriMTDValue = oData.PriMTDValue;
                _oDataBrand.PriLMValue = oData.PriLMValue;
                _oDataBrand.PriYTDValue = oData.PriYTDValue;
                _oDataBrand.PriLYValue = oData.PriLYValue;
                _oDataBrand.PriLYYTDValue = oData.PriLYYTDValue;
                _oDataBrand.PriLYMTDValue = oData.PriLYMTDValue;
                _oDataBrand.PriCMTValue = oData.PriCMTValue;
                _oDataBrand.PriLMTValue = oData.PriLMTValue;
                //-----------------------------------------
                _oDataBrand.SecDTDQty = oData.SecDTDQty;
                _oDataBrand.SecLDQty = oData.SecLDQty;
                _oDataBrand.SecMTDQty = oData.SecMTDQty;
                _oDataBrand.SecLMQty = oData.SecLMQty;
                _oDataBrand.SecYTDQty = oData.SecYTDQty;
                _oDataBrand.SecLYQty = oData.SecLYQty;
                _oDataBrand.SecLYYTDQty = oData.SecLYYTDQty;
                _oDataBrand.SecLYMTDQty = oData.SecLYMTDQty;
                _oDataBrand.SecCMTQty = oData.SecCMTQty;
                _oDataBrand.SecLMTQty = oData.SecLMTQty;

                _oDataBrand.SecDTDValue = oData.SecDTDValue;
                _oDataBrand.SecLDValue = oData.SecLDValue;
                _oDataBrand.SecMTDValue = oData.SecMTDValue;
                _oDataBrand.SecLMValue = oData.SecLMValue;
                _oDataBrand.SecYTDValue = oData.SecYTDValue;
                _oDataBrand.SecLYValue = oData.SecLYValue;
                _oDataBrand.SecLYYTDValue = oData.SecLYYTDValue;
                _oDataBrand.SecLYMTDValue = oData.SecLYMTDValue;
                _oDataBrand.SecCMTValue = oData.SecCMTValue;
                _oDataBrand.SecLMTValue = oData.SecLMTValue;

                _oDatas.Add(_oDataBrand);*/

                _oDataTotal.PriDTDQty = _oDataTotal.PriDTDQty + oData.PriDTDQty;
                _oDataTotal.PriLDQty = _oDataTotal.PriLDQty + oData.PriLDQty;
                _oDataTotal.PriMTDQty = _oDataTotal.PriMTDQty + oData.PriMTDQty;
                _oDataTotal.PriLMQty = _oDataTotal.PriLMQty + oData.PriLMQty;
                _oDataTotal.PriYTDQty = _oDataTotal.PriYTDQty + oData.PriYTDQty;
                _oDataTotal.PriLYQty = _oDataTotal.PriLYQty + oData.PriLYQty;
                _oDataTotal.PriLYYTDQty = _oDataTotal.PriLYYTDQty + oData.PriLYYTDQty;
                _oDataTotal.PriLYMTDQty = _oDataTotal.PriLYMTDQty + oData.PriLYMTDQty;
                _oDataTotal.PriCMTQty = _oDataTotal.PriCMTQty + oData.PriCMTQty;
                _oDataTotal.PriLMTQty = _oDataTotal.PriLMTQty + oData.PriLMTQty;
                _oDataTotal.PriStockQty = _oDataTotal.PriStockQty + oData.PriStockQty;

                _oDataTotal.PriDTDValue = _oDataTotal.PriDTDValue + oData.PriDTDValue;
                _oDataTotal.PriLDValue = _oDataTotal.PriLDValue + oData.PriLDValue;
                _oDataTotal.PriMTDValue = _oDataTotal.PriMTDValue + oData.PriMTDValue;
                _oDataTotal.PriLMValue = _oDataTotal.PriLMValue + oData.PriLMValue;
                _oDataTotal.PriYTDValue = _oDataTotal.PriYTDValue + oData.PriYTDValue;
                _oDataTotal.PriLYValue = _oDataTotal.PriLYValue + oData.PriLYValue;
                _oDataTotal.PriLYYTDValue = _oDataTotal.PriLYYTDValue + oData.PriLYYTDValue;
                _oDataTotal.PriLYMTDValue = _oDataTotal.PriLYMTDValue + oData.PriLYMTDValue;
                _oDataTotal.PriCMTValue = _oDataTotal.PriCMTValue + oData.PriCMTValue;
                _oDataTotal.PriLMTValue = _oDataTotal.PriLMTValue + oData.PriLMTValue;
                _oDataTotal.PriStockVal = _oDataTotal.PriStockVal + oData.PriStockVal;

                //================================================================
                _oDataTotal.SecDTDQty = _oDataTotal.SecDTDQty + oData.SecDTDQty;
                _oDataTotal.SecLDQty = _oDataTotal.SecLDQty + oData.SecLDQty;
                _oDataTotal.SecMTDQty = _oDataTotal.SecMTDQty + oData.SecMTDQty;
                _oDataTotal.SecLMQty = _oDataTotal.SecLMQty + oData.SecLMQty;
                _oDataTotal.SecYTDQty = _oDataTotal.SecYTDQty + oData.SecYTDQty;
                _oDataTotal.SecLYQty = _oDataTotal.SecLYQty + oData.SecLYQty;
                _oDataTotal.SecLYYTDQty = _oDataTotal.SecLYYTDQty + oData.SecLYYTDQty;
                _oDataTotal.SecLYMTDQty = _oDataTotal.SecLYMTDQty + oData.SecLYMTDQty;
                _oDataTotal.SecCMTQty = _oDataTotal.SecCMTQty + oData.SecCMTQty;
                _oDataTotal.SecLMTQty = _oDataTotal.SecLMTQty + oData.SecLMTQty;
                _oDataTotal.SecStockQty = _oDataTotal.SecStockQty + oData.SecStockQty;

                _oDataTotal.SecDTDValue = _oDataTotal.SecDTDValue + oData.SecDTDValue;
                _oDataTotal.SecLDValue = _oDataTotal.SecLDValue + oData.SecLDValue;
                _oDataTotal.SecMTDValue = _oDataTotal.SecMTDValue + oData.SecMTDValue;
                _oDataTotal.SecLMValue = _oDataTotal.SecLMValue + oData.SecLMValue;
                _oDataTotal.SecYTDValue = _oDataTotal.SecYTDValue + oData.SecYTDValue;
                _oDataTotal.SecLYValue = _oDataTotal.SecLYValue + oData.SecLYValue;
                _oDataTotal.SecLYYTDValue = _oDataTotal.SecLYYTDValue + oData.SecLYYTDValue;
                _oDataTotal.SecLYMTDValue = _oDataTotal.SecLYMTDValue + oData.SecLYMTDValue;
                _oDataTotal.SecCMTValue = _oDataTotal.SecCMTValue + oData.SecCMTValue;
                _oDataTotal.SecLMTValue = _oDataTotal.SecLMTValue + oData.SecLMTValue;
                _oDataTotal.SecStockVal = _oDataTotal.SecStockVal + oData.SecStockVal;


                if (oData.MarketGroupType == "Region")
                {
                    if (oData.Channel == "All")
                    {
                        _oDataPGTotalAll.PriDTDQty = _oDataPGTotalAll.PriDTDQty + oData.PriDTDQty;
                        _oDataPGTotalAll.PriLDQty = _oDataPGTotalAll.PriLDQty + oData.PriLDQty;
                        _oDataPGTotalAll.PriMTDQty = _oDataPGTotalAll.PriMTDQty + oData.PriMTDQty;
                        _oDataPGTotalAll.PriLMQty = _oDataPGTotalAll.PriLMQty + oData.PriLMQty;
                        _oDataPGTotalAll.PriYTDQty = _oDataPGTotalAll.PriYTDQty + oData.PriYTDQty;
                        _oDataPGTotalAll.PriLYQty = _oDataPGTotalAll.PriLYQty + oData.PriLYQty;
                        _oDataPGTotalAll.PriLYYTDQty = _oDataPGTotalAll.PriLYYTDQty + oData.PriLYYTDQty;
                        _oDataPGTotalAll.PriLYMTDQty = _oDataPGTotalAll.PriLYMTDQty + oData.PriLYMTDQty;
                        _oDataPGTotalAll.PriCMTQty = _oDataPGTotalAll.PriCMTQty + oData.PriCMTQty;
                        _oDataPGTotalAll.PriLMTQty = _oDataPGTotalAll.PriLMTQty + oData.PriLMTQty;
                        _oDataPGTotalAll.PriStockQty = _oDataPGTotalAll.PriStockQty + oData.PriStockQty;

                        _oDataPGTotalAll.PriDTDValue = _oDataPGTotalAll.PriDTDValue + oData.PriDTDValue;
                        _oDataPGTotalAll.PriLDValue = _oDataPGTotalAll.PriLDValue + oData.PriLDValue;
                        _oDataPGTotalAll.PriMTDValue = _oDataPGTotalAll.PriMTDValue + oData.PriMTDValue;
                        _oDataPGTotalAll.PriLMValue = _oDataPGTotalAll.PriLMValue + oData.PriLMValue;
                        _oDataPGTotalAll.PriYTDValue = _oDataPGTotalAll.PriYTDValue + oData.PriYTDValue;
                        _oDataPGTotalAll.PriLYValue = _oDataPGTotalAll.PriLYValue + oData.PriLYValue;
                        _oDataPGTotalAll.PriLYYTDValue = _oDataPGTotalAll.PriLYYTDValue + oData.PriLYYTDValue;
                        _oDataPGTotalAll.PriLYMTDValue = _oDataPGTotalAll.PriLYMTDValue + oData.PriLYMTDValue;
                        _oDataPGTotalAll.PriCMTValue = _oDataPGTotalAll.PriCMTValue + oData.PriCMTValue;
                        _oDataPGTotalAll.PriLMTValue = _oDataPGTotalAll.PriLMTValue + oData.PriLMTValue;
                        _oDataPGTotalAll.PriStockVal = _oDataPGTotalAll.PriStockVal + oData.PriStockVal;
                        //=============================================================================
                        _oDataPGTotalAll.SecDTDQty = _oDataPGTotalAll.SecDTDQty + oData.SecDTDQty;
                        _oDataPGTotalAll.SecLDQty = _oDataPGTotalAll.SecLDQty + oData.SecLDQty;
                        _oDataPGTotalAll.SecMTDQty = _oDataPGTotalAll.SecMTDQty + oData.SecMTDQty;
                        _oDataPGTotalAll.SecLMQty = _oDataPGTotalAll.SecLMQty + oData.SecLMQty;
                        _oDataPGTotalAll.SecYTDQty = _oDataPGTotalAll.SecYTDQty + oData.SecYTDQty;
                        _oDataPGTotalAll.SecLYQty = _oDataPGTotalAll.SecLYQty + oData.SecLYQty;
                        _oDataPGTotalAll.SecLYYTDQty = _oDataPGTotalAll.SecLYYTDQty + oData.SecLYYTDQty;
                        _oDataPGTotalAll.SecLYMTDQty = _oDataPGTotalAll.SecLYMTDQty + oData.SecLYMTDQty;
                        _oDataPGTotalAll.SecCMTQty = _oDataPGTotalAll.SecCMTQty + oData.SecCMTQty;
                        _oDataPGTotalAll.SecLMTQty = _oDataPGTotalAll.SecLMTQty + oData.SecLMTQty;
                        _oDataPGTotalAll.SecStockQty = _oDataPGTotalAll.SecStockQty + oData.SecStockQty;

                        _oDataPGTotalAll.SecDTDValue = _oDataPGTotalAll.SecDTDValue + oData.SecDTDValue;
                        _oDataPGTotalAll.SecLDValue = _oDataPGTotalAll.SecLDValue + oData.SecLDValue;
                        _oDataPGTotalAll.SecMTDValue = _oDataPGTotalAll.SecMTDValue + oData.SecMTDValue;
                        _oDataPGTotalAll.SecLMValue = _oDataPGTotalAll.SecLMValue + oData.SecLMValue;
                        _oDataPGTotalAll.SecYTDValue = _oDataPGTotalAll.SecYTDValue + oData.SecYTDValue;
                        _oDataPGTotalAll.SecLYValue = _oDataPGTotalAll.SecLYValue + oData.SecLYValue;
                        _oDataPGTotalAll.SecLYYTDValue = _oDataPGTotalAll.SecLYYTDValue + oData.SecLYYTDValue;
                        _oDataPGTotalAll.SecLYMTDValue = _oDataPGTotalAll.SecLYMTDValue + oData.SecLYMTDValue;
                        _oDataPGTotalAll.SecCMTValue = _oDataPGTotalAll.SecCMTValue + oData.SecCMTValue;
                        _oDataPGTotalAll.SecLMTValue = _oDataPGTotalAll.SecLMTValue + oData.SecLMTValue;
                        _oDataPGTotalAll.SecStockVal = _oDataPGTotalAll.SecStockVal + oData.SecStockVal;
                    }
                    else if (oData.Channel == "GTM")
                    {
                        _oDataPGTotalGTM.PriDTDQty = _oDataPGTotalGTM.PriDTDQty + oData.PriDTDQty;
                        _oDataPGTotalGTM.PriLDQty = _oDataPGTotalGTM.PriLDQty + oData.PriLDQty;
                        _oDataPGTotalGTM.PriMTDQty = _oDataPGTotalGTM.PriMTDQty + oData.PriMTDQty;
                        _oDataPGTotalGTM.PriLMQty = _oDataPGTotalGTM.PriLMQty + oData.PriLMQty;
                        _oDataPGTotalGTM.PriYTDQty = _oDataPGTotalGTM.PriYTDQty + oData.PriYTDQty;
                        _oDataPGTotalGTM.PriLYQty = _oDataPGTotalGTM.PriLYQty + oData.PriLYQty;
                        _oDataPGTotalGTM.PriLYYTDQty = _oDataPGTotalGTM.PriLYYTDQty + oData.PriLYYTDQty;
                        _oDataPGTotalGTM.PriLYMTDQty = _oDataPGTotalGTM.PriLYMTDQty + oData.PriLYMTDQty;
                        _oDataPGTotalGTM.PriCMTQty = _oDataPGTotalGTM.PriCMTQty + oData.PriCMTQty;
                        _oDataPGTotalGTM.PriLMTQty = _oDataPGTotalGTM.PriLMTQty + oData.PriLMTQty;
                        _oDataPGTotalGTM.PriStockQty = _oDataPGTotalGTM.PriStockQty + oData.PriStockQty;

                        _oDataPGTotalGTM.PriDTDValue = _oDataPGTotalGTM.PriDTDValue + oData.PriDTDValue;
                        _oDataPGTotalGTM.PriLDValue = _oDataPGTotalGTM.PriLDValue + oData.PriLDValue;
                        _oDataPGTotalGTM.PriMTDValue = _oDataPGTotalGTM.PriMTDValue + oData.PriMTDValue;
                        _oDataPGTotalGTM.PriLMValue = _oDataPGTotalGTM.PriLMValue + oData.PriLMValue;
                        _oDataPGTotalGTM.PriYTDValue = _oDataPGTotalGTM.PriYTDValue + oData.PriYTDValue;
                        _oDataPGTotalGTM.PriLYValue = _oDataPGTotalGTM.PriLYValue + oData.PriLYValue;
                        _oDataPGTotalGTM.PriLYYTDValue = _oDataPGTotalGTM.PriLYYTDValue + oData.PriLYYTDValue;
                        _oDataPGTotalGTM.PriLYMTDValue = _oDataPGTotalGTM.PriLYMTDValue + oData.PriLYMTDValue;
                        _oDataPGTotalGTM.PriCMTValue = _oDataPGTotalGTM.PriCMTValue + oData.PriCMTValue;
                        _oDataPGTotalGTM.PriLMTValue = _oDataPGTotalGTM.PriLMTValue + oData.PriLMTValue;
                        _oDataPGTotalGTM.PriStockVal = _oDataPGTotalGTM.PriStockVal + oData.PriStockVal;

                        //============================================================================
                        _oDataPGTotalGTM.SecDTDQty = _oDataPGTotalGTM.SecDTDQty + oData.SecDTDQty;
                        _oDataPGTotalGTM.SecLDQty = _oDataPGTotalGTM.SecLDQty + oData.SecLDQty;
                        _oDataPGTotalGTM.SecMTDQty = _oDataPGTotalGTM.SecMTDQty + oData.SecMTDQty;
                        _oDataPGTotalGTM.SecLMQty = _oDataPGTotalGTM.SecLMQty + oData.SecLMQty;
                        _oDataPGTotalGTM.SecYTDQty = _oDataPGTotalGTM.SecYTDQty + oData.SecYTDQty;
                        _oDataPGTotalGTM.SecLYQty = _oDataPGTotalGTM.SecLYQty + oData.SecLYQty;
                        _oDataPGTotalGTM.SecLYYTDQty = _oDataPGTotalGTM.SecLYYTDQty + oData.SecLYYTDQty;
                        _oDataPGTotalGTM.SecLYMTDQty = _oDataPGTotalGTM.SecLYMTDQty + oData.SecLYMTDQty;
                        _oDataPGTotalGTM.SecCMTQty = _oDataPGTotalGTM.SecCMTQty + oData.SecCMTQty;
                        _oDataPGTotalGTM.SecLMTQty = _oDataPGTotalGTM.SecLMTQty + oData.SecLMTQty;
                        _oDataPGTotalGTM.SecStockQty = _oDataPGTotalGTM.SecStockQty + oData.SecStockQty;

                        _oDataPGTotalGTM.SecDTDValue = _oDataPGTotalGTM.SecDTDValue + oData.SecDTDValue;
                        _oDataPGTotalGTM.SecLDValue = _oDataPGTotalGTM.SecLDValue + oData.SecLDValue;
                        _oDataPGTotalGTM.SecMTDValue = _oDataPGTotalGTM.SecMTDValue + oData.SecMTDValue;
                        _oDataPGTotalGTM.SecLMValue = _oDataPGTotalGTM.SecLMValue + oData.SecLMValue;
                        _oDataPGTotalGTM.SecYTDValue = _oDataPGTotalGTM.SecYTDValue + oData.SecYTDValue;
                        _oDataPGTotalGTM.SecLYValue = _oDataPGTotalGTM.SecLYValue + oData.SecLYValue;
                        _oDataPGTotalGTM.SecLYYTDValue = _oDataPGTotalGTM.SecLYYTDValue + oData.SecLYYTDValue;
                        _oDataPGTotalGTM.SecLYMTDValue = _oDataPGTotalGTM.SecLYMTDValue + oData.SecLYMTDValue;
                        _oDataPGTotalGTM.SecCMTValue = _oDataPGTotalGTM.SecCMTValue + oData.SecCMTValue;
                        _oDataPGTotalGTM.SecLMTValue = _oDataPGTotalGTM.SecLMTValue + oData.SecLMTValue;
                        _oDataPGTotalGTM.SecStockVal = _oDataPGTotalGTM.SecStockVal + oData.SecStockVal;
                    }
                    else if (oData.Channel == "IL")
                    {
                        _oDataPGTotalIL.PriDTDQty = _oDataPGTotalIL.PriDTDQty + oData.PriDTDQty;
                        _oDataPGTotalIL.PriLDQty = _oDataPGTotalIL.PriLDQty + oData.PriLDQty;
                        _oDataPGTotalIL.PriMTDQty = _oDataPGTotalIL.PriMTDQty + oData.PriMTDQty;
                        _oDataPGTotalIL.PriLMQty = _oDataPGTotalIL.PriLMQty + oData.PriLMQty;
                        _oDataPGTotalIL.PriYTDQty = _oDataPGTotalIL.PriYTDQty + oData.PriYTDQty;
                        _oDataPGTotalIL.PriLYQty = _oDataPGTotalIL.PriLYQty + oData.PriLYQty;
                        _oDataPGTotalIL.PriLYYTDQty = _oDataPGTotalIL.PriLYYTDQty + oData.PriLYYTDQty;
                        _oDataPGTotalIL.PriLYMTDQty = _oDataPGTotalIL.PriLYMTDQty + oData.PriLYMTDQty;
                        _oDataPGTotalIL.PriCMTQty = _oDataPGTotalIL.PriCMTQty + oData.PriCMTQty;
                        _oDataPGTotalIL.PriLMTQty = _oDataPGTotalIL.PriLMTQty + oData.PriLMTQty;
                        _oDataPGTotalIL.PriStockQty = _oDataPGTotalIL.PriStockQty + oData.PriStockQty;

                        _oDataPGTotalIL.PriDTDValue = _oDataPGTotalIL.PriDTDValue + oData.PriDTDValue;
                        _oDataPGTotalIL.PriLDValue = _oDataPGTotalIL.PriLDValue + oData.PriLDValue;
                        _oDataPGTotalIL.PriMTDValue = _oDataPGTotalIL.PriMTDValue + oData.PriMTDValue;
                        _oDataPGTotalIL.PriLMValue = _oDataPGTotalIL.PriLMValue + oData.PriLMValue;
                        _oDataPGTotalIL.PriYTDValue = _oDataPGTotalIL.PriYTDValue + oData.PriYTDValue;
                        _oDataPGTotalIL.PriLYValue = _oDataPGTotalIL.PriLYValue + oData.PriLYValue;
                        _oDataPGTotalIL.PriLYYTDValue = _oDataPGTotalIL.PriLYYTDValue + oData.PriLYYTDValue;
                        _oDataPGTotalIL.PriLYMTDValue = _oDataPGTotalIL.PriLYMTDValue + oData.PriLYMTDValue;
                        _oDataPGTotalIL.PriCMTValue = _oDataPGTotalIL.PriCMTValue + oData.PriCMTValue;
                        _oDataPGTotalIL.PriLMTValue = _oDataPGTotalIL.PriLMTValue + oData.PriLMTValue;
                        _oDataPGTotalIL.PriStockVal = _oDataPGTotalIL.PriStockVal + oData.PriStockVal;

                        //==========================================================================
                        _oDataPGTotalIL.SecDTDQty = _oDataPGTotalIL.SecDTDQty + oData.SecDTDQty;
                        _oDataPGTotalIL.SecLDQty = _oDataPGTotalIL.SecLDQty + oData.SecLDQty;
                        _oDataPGTotalIL.SecMTDQty = _oDataPGTotalIL.SecMTDQty + oData.SecMTDQty;
                        _oDataPGTotalIL.SecLMQty = _oDataPGTotalIL.SecLMQty + oData.SecLMQty;
                        _oDataPGTotalIL.SecYTDQty = _oDataPGTotalIL.SecYTDQty + oData.SecYTDQty;
                        _oDataPGTotalIL.SecLYQty = _oDataPGTotalIL.SecLYQty + oData.SecLYQty;
                        _oDataPGTotalIL.SecLYYTDQty = _oDataPGTotalIL.SecLYYTDQty + oData.SecLYYTDQty;
                        _oDataPGTotalIL.SecLYMTDQty = _oDataPGTotalIL.SecLYMTDQty + oData.SecLYMTDQty;
                        _oDataPGTotalIL.SecCMTQty = _oDataPGTotalIL.SecCMTQty + oData.SecCMTQty;
                        _oDataPGTotalIL.SecLMTQty = _oDataPGTotalIL.SecLMTQty + oData.SecLMTQty;
                        _oDataPGTotalIL.SecStockQty = _oDataPGTotalIL.SecStockQty + oData.SecStockQty;

                        _oDataPGTotalIL.SecDTDValue = _oDataPGTotalIL.SecDTDValue + oData.SecDTDValue;
                        _oDataPGTotalIL.SecLDValue = _oDataPGTotalIL.SecLDValue + oData.SecLDValue;
                        _oDataPGTotalIL.SecMTDValue = _oDataPGTotalIL.SecMTDValue + oData.SecMTDValue;
                        _oDataPGTotalIL.SecLMValue = _oDataPGTotalIL.SecLMValue + oData.SecLMValue;
                        _oDataPGTotalIL.SecYTDValue = _oDataPGTotalIL.SecYTDValue + oData.SecYTDValue;
                        _oDataPGTotalIL.SecLYValue = _oDataPGTotalIL.SecLYValue + oData.SecLYValue;
                        _oDataPGTotalIL.SecLYYTDValue = _oDataPGTotalIL.SecLYYTDValue + oData.SecLYYTDValue;
                        _oDataPGTotalIL.SecLYMTDValue = _oDataPGTotalIL.SecLYMTDValue + oData.SecLYMTDValue;
                        _oDataPGTotalIL.SecCMTValue = _oDataPGTotalIL.SecCMTValue + oData.SecCMTValue;
                        _oDataPGTotalIL.SecLMTValue = _oDataPGTotalIL.SecLMTValue + oData.SecLMTValue;
                        _oDataPGTotalIL.SecStockVal = _oDataPGTotalIL.SecStockVal + oData.SecStockVal;
                    }
                }
            }

            #endregion

         
            _oData.InsertReportLog(sUser);
           
            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput);

        }

    }

    public class Data
    {
        public string MarketGroupID;
        public string MarketGroupType;
        public string MarketGroupName;
        public int MarketGroupSort;
        public string Channel;
        public string BrandName;
        public string Name;
        public string Type;
        public string ParentID;
        


        public string RegionShortName;
        public int AreaID;
        public string AreaShortName;
        public int TerritoryID;
        public string TerritoryShortName;
        public int DistributorID;
        public string DistributorName;
        public string Company;
        public int WarehouseID;
        
        public int BrandID;
        public int BrandSort;

        public int PriDTDQty;
        public double PriDTDValue;
        public int PriLDQty;
        public double PriLDValue;
        public int PriMTDQty;
        public double PriMTDValue;
        public int PriLMQty;
        public double PriLMValue;
        public int PriYTDQty;
        public double PriYTDValue;
        public int PriLYQty;
        public double PriLYValue;
        public int PriLYYTDQty;
        public double PriLYYTDValue;
        public int PriLYMTDQty;
        public double PriLYMTDValue;
        public int PriCMTQty;
        public double PriCMTValue;
        public int PriLMTQty;
        public double PriLMTValue;

        public int PriStockQty;
        public double PriStockVal;

        public int SecDTDQty;
        public double SecDTDValue;
        public int SecLDQty;
        public double SecLDValue;
        public int SecMTDQty;
        public double SecMTDValue;
        public int SecLMQty;
        public double SecLMValue;
        public int SecYTDQty;
        public double SecYTDValue;
        public int SecLYQty;
        public double SecLYValue;
        public int SecLYYTDQty;
        public double SecLYYTDValue;
        public int SecLYMTDQty;
        public double SecLYMTDValue;
        public int SecCMTQty;
        public double SecCMTValue;
        public int SecLMTQty;
        public double SecLMTValue;

        public int SecStockQty;
        public double SecStockVal;

        public string PriDTDQtyText;
        public string PriDTDValueText;
        public string PriLDQtyText;
        public string PriLDValueText;
        public string PriMTDQtyText;
        public string PriMTDValueText;
        public string PriLMQtyText;
        public string PriLMValueText;
        public string PriYTDQtyText;
        public string PriYTDValueText;
        public string PriLYQtyText;
        public string PriLYValueText;
        public string PriLYYTDQtyText;
        public string PriLYYTDValueText;
        public string PriLYMTDQtyText;
        public string PriLYMTDValueText;
        public string PriCMTQtyText;
        public string PriCMTValueText;
        public string PriLMTQtyText;
        public string PriLMTValueText;

        public string PriStockQtyText;
        public string PriStockValText;

        public string SecDTDQtyText;
        public string SecDTDValueText;
        public string SecLDQtyText;
        public string SecLDValueText;
        public string SecMTDQtyText;
        public string SecMTDValueText;
        public string SecLMQtyText;
        public string SecLMValueText;
        public string SecYTDQtyText;
        public string SecYTDValueText;
        public string SecLYQtyText;
        public string SecLYValueText;
        public string SecLYYTDQtyText;
        public string SecLYYTDValueText;
        public string SecLYMTDQtyText;
        public string SecLYMTDValueText;
        public string SecCMTQtyText;
        public string SecCMTValueText;
        public string SecLMTQtyText;
        public string SecLMTValueText;

        public string SecStockQtyText;
        public string SecStockValText;

        public string PriMTDQtyPercText;
        public string PriLMQtyPercText;
        public string PriMTDQtyGthPercText;
        public string PriYTDQtyGthPercText;
        public string PriMTDValuePercText;
        public string PriLMValuePercText;
        public string PriMTDValueGthPercText;
        public string PriYTDValueGthPercText;

        public string SecMTDQtyPercText;
        public string SecLMQtyPercText;
        public string SecMTDQtyGthPercText;
        public string SecYTDQtyGthPercText;
        public string SecMTDValuePercText;
        public string SecLMValuePercText;
        public string SecMTDValueGthPercText;
        public string SecYTDValueGthPercText;

        public string PriMTDTarQtyText;
        public string PriMTDTarValText;
        public string PriMTDTarQtyPer;
        public string PriMTDTarValPer;

        public string SecMTDTarQtyText;
        public string SecMTDTarValText;
        public string SecMTDTarQtyPer;
        public string SecMTDTarValPer;
        
        public string Value;

        public int GetMarketGroupID(string sCompany, string sDatabase, string sValue, string sValueType)
        {
            int nID = 0;

            /*string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (sValueType == "ByArea")
            {
                sSQL = " select AreaID as ID from BLLSysDB.dbo.v_CustomerDetails a, " +
                       " TELSysDB.dbo.t_Showroom b Where a.CustomerID=b.CustomerID and AreaShortName='" + sValue + "' Group by AreaID ";

            }
            else if (sValueType == "ByZone")
            {
                sSQL = " select TerritoryID as ID from BLLSysDB.dbo.v_CustomerDetails a, " +
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
            }*/
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

        public void GetData(string sIsProductGroupChecked, string sPGID, string sMAGID, string sASGID, string sBrandID, string sUser, string sAndroidAppID)
        {
            string sSQL = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();

            /*Stock Qty and Value Add*/

            sSQL = @" Select* from
            (                
            select MarketGroupType,DataType As Type,
            'All' As Channel, MarketGroupName,Sort As MarketGroupSort, BrandName, MarketGroupID, ParentID,
            Sum(PriDTDQty) as PriDTDQty, Sum(PriDTDValue) as PriDTDValue, Sum(PriLDQty) as PriLDQty, Sum(PriLDValue) as PriLDValue,
            Sum(SecDTDQty) as SecDTDQty, Sum(SecDTDValue) as SecDTDValue, Sum(SecLDQty) as SecLDQty, Sum(SecLDValue) as SecLDValue,
            Sum(PriMTDQty) as PriMTDQty, Sum(PriMTDValue) as PriMTDValue, Sum(PriLMQty) as PriLMQty, Sum(PriLMValue) as PriLMValue,
            Sum(SecMTDQty) as SecMTDQty, Sum(SecMTDValue) as SecMTDValue, Sum(SecLMQty) as SecLMQty, Sum(SecLMValue) as SecLMValue,
            Sum(PriYTDQty) as PriYTDQty, Sum(PriYTDValue) as PriYTDValue, Sum(PriLYQty) as PriLYQty, Sum(PriLYValue) as PriLYValue,
            Sum(SecYTDQty) as SecYTDQty, Sum(SecYTDValue) as SecYTDValue, Sum(SecLYQty) as SecLYQty, Sum(SecLYValue) as SecLYValue,
            Sum(PriLYYTDQty) as PriLYYTDQty, Sum(PriLYYTDValue) as PriLYYTDValue, Sum(PriLYMTDQty) as PriLYMTDQty, Sum(PriLYMTDValue) as PriLYMTDValue,
            Sum(SecLYYTDQty) as SecLYYTDQty, Sum(SecLYYTDValue) as SecLYYTDValue, Sum(SecLYMTDQty) as SecLYMTDQty, Sum(SecLYMTDValue) as SecLYMTDValue,
            Sum(PriCMTQty) as PriCMTQty, Sum(PriCMTValue) as PriCMTValue, Sum(PriLMTQty) as PriLMTQty, Sum(PriLMTValue) as PriLMTValue,
            Sum(SecCMTQty) as SecCMTQty, Sum(SecCMTValue) as SecCMTValue, Sum(SecLMTQty) as SecLMTQty, Sum(SecLMTValue) as SecLMTValue,
            sum(PriCRStock) as PriCRStock, sum(PriStockVal) as PriStockVal, sum(SecCRStock) as SecCRStock, sum(SecStockVal) as SecStockVal
            from DWDB.dbo.t_SalesDataProductGroupQtyValueByMktGrp a  Where 1=1 {0}
            Group by MarketGroupType, MarketGroupName, Sort, BrandName, MarketGroupID, ParentID,DataType
            ) as final 
            Union all
            Select* from
            (                
            select MarketGroupType,DataType As Type,
            Channel, MarketGroupName,Sort As MarketGroupSort, BrandName, MarketGroupID, ParentID,
            Sum(PriDTDQty) as PriDTDQty, Sum(PriDTDValue) as PriDTDValue, Sum(PriLDQty) as PriLDQty, Sum(PriLDValue) as PriLDValue,
            Sum(SecDTDQty) as SecDTDQty, Sum(SecDTDValue) as SecDTDValue, Sum(SecLDQty) as SecLDQty, Sum(SecLDValue) as SecLDValue,
            Sum(PriMTDQty) as PriMTDQty, Sum(PriMTDValue) as PriMTDValue, Sum(PriLMQty) as PriLMQty, Sum(PriLMValue) as PriLMValue,
            Sum(SecMTDQty) as SecMTDQty, Sum(SecMTDValue) as SecMTDValue, Sum(SecLMQty) as SecLMQty, Sum(SecLMValue) as SecLMValue,
            Sum(PriYTDQty) as PriYTDQty, Sum(PriYTDValue) as PriYTDValue, Sum(PriLYQty) as PriLYQty, Sum(PriLYValue) as PriLYValue,
            Sum(SecYTDQty) as SecYTDQty, Sum(SecYTDValue) as SecYTDValue, Sum(SecLYQty) as SecLYQty, Sum(SecLYValue) as SecLYValue,
            Sum(PriLYYTDQty) as PriLYYTDQty, Sum(PriLYYTDValue) as PriLYYTDValue, Sum(PriLYMTDQty) as PriLYMTDQty, Sum(PriLYMTDValue) as PriLYMTDValue,
            Sum(SecLYYTDQty) as SecLYYTDQty, Sum(SecLYYTDValue) as SecLYYTDValue, Sum(SecLYMTDQty) as SecLYMTDQty, Sum(SecLYMTDValue) as SecLYMTDValue,
            Sum(PriCMTQty) as PriCMTQty, Sum(PriCMTValue) as PriCMTValue, Sum(PriLMTQty) as PriLMTQty, Sum(PriLMTValue) as PriLMTValue,
            Sum(SecCMTQty) as SecCMTQty, Sum(SecCMTValue) as SecCMTValue, Sum(SecLMTQty) as SecLMTQty, Sum(SecLMTValue) as SecLMTValue, 
            sum(PriCRStock) as PriCRStock, sum(PriStockVal) as PriStockVal, sum(SecCRStock) as SecCRStock, sum(SecStockVal) as SecStockVal
            from DWDB.dbo.t_SalesDataProductGroupQtyValueByMktGrp a Where 1=1 {1}
            Group by MarketGroupType, Channel, MarketGroupName, Sort, BrandName, MarketGroupID, ParentID,DataType
            ) as final  ";

            //sSQL = @"Select* from
            //        (                
            //        select MarketGroupType,DataType As Type,
            //        'All' As Channel, MarketGroupName,Sort As MarketGroupSort, BrandName, MarketGroupID, ParentID,
            //        Sum(PriDTDQty) as PriDTDQty, Sum(PriDTDValue) as PriDTDValue, Sum(PriLDQty) as PriLDQty, Sum(PriLDValue) as PriLDValue,
            //        Sum(SecDTDQty) as SecDTDQty, Sum(SecDTDValue) as SecDTDValue, Sum(SecLDQty) as SecLDQty, Sum(SecLDValue) as SecLDValue,
            //        Sum(PriMTDQty) as PriMTDQty, Sum(PriMTDValue) as PriMTDValue, Sum(PriLMQty) as PriLMQty, Sum(PriLMValue) as PriLMValue,
            //        Sum(SecMTDQty) as SecMTDQty, Sum(SecMTDValue) as SecMTDValue, Sum(SecLMQty) as SecLMQty, Sum(SecLMValue) as SecLMValue,
            //        Sum(PriYTDQty) as PriYTDQty, Sum(PriYTDValue) as PriYTDValue, Sum(PriLYQty) as PriLYQty, Sum(PriLYValue) as PriLYValue,
            //        Sum(SecYTDQty) as SecYTDQty, Sum(SecYTDValue) as SecYTDValue, Sum(SecLYQty) as SecLYQty, Sum(SecLYValue) as SecLYValue,
            //        Sum(PriLYYTDQty) as PriLYYTDQty, Sum(PriLYYTDValue) as PriLYYTDValue, Sum(PriLYMTDQty) as PriLYMTDQty, Sum(PriLYMTDValue) as PriLYMTDValue,
            //        Sum(SecLYYTDQty) as SecLYYTDQty, Sum(SecLYYTDValue) as SecLYYTDValue, Sum(SecLYMTDQty) as SecLYMTDQty, Sum(SecLYMTDValue) as SecLYMTDValue,
            //        Sum(PriCMTQty) as PriCMTQty, Sum(PriCMTValue) as PriCMTValue, Sum(PriLMTQty) as PriLMTQty, Sum(PriLMTValue) as PriLMTValue,
            //        Sum(SecCMTQty) as SecCMTQty, Sum(SecCMTValue) as SecCMTValue, Sum(SecLMTQty) as SecLMTQty, Sum(SecLMTValue) as SecLMTValue
            //        from DWDB.dbo.t_SalesDataProductGroupQtyValueByMktGrp a  Where 1=1 {0}
            //        Group by MarketGroupType, MarketGroupName, Sort, BrandName, MarketGroupID, ParentID,DataType
            //        ) as final 
            //        Union all
            //        Select* from
            //        (                
            //        select MarketGroupType,DataType As Type,
            //        Channel, MarketGroupName,Sort As MarketGroupSort, BrandName, MarketGroupID, ParentID,
            //        Sum(PriDTDQty) as PriDTDQty, Sum(PriDTDValue) as PriDTDValue, Sum(PriLDQty) as PriLDQty, Sum(PriLDValue) as PriLDValue,
            //        Sum(SecDTDQty) as SecDTDQty, Sum(SecDTDValue) as SecDTDValue, Sum(SecLDQty) as SecLDQty, Sum(SecLDValue) as SecLDValue,
            //        Sum(PriMTDQty) as PriMTDQty, Sum(PriMTDValue) as PriMTDValue, Sum(PriLMQty) as PriLMQty, Sum(PriLMValue) as PriLMValue,
            //        Sum(SecMTDQty) as SecMTDQty, Sum(SecMTDValue) as SecMTDValue, Sum(SecLMQty) as SecLMQty, Sum(SecLMValue) as SecLMValue,
            //        Sum(PriYTDQty) as PriYTDQty, Sum(PriYTDValue) as PriYTDValue, Sum(PriLYQty) as PriLYQty, Sum(PriLYValue) as PriLYValue,
            //        Sum(SecYTDQty) as SecYTDQty, Sum(SecYTDValue) as SecYTDValue, Sum(SecLYQty) as SecLYQty, Sum(SecLYValue) as SecLYValue,
            //        Sum(PriLYYTDQty) as PriLYYTDQty, Sum(PriLYYTDValue) as PriLYYTDValue, Sum(PriLYMTDQty) as PriLYMTDQty, Sum(PriLYMTDValue) as PriLYMTDValue,
            //        Sum(SecLYYTDQty) as SecLYYTDQty, Sum(SecLYYTDValue) as SecLYYTDValue, Sum(SecLYMTDQty) as SecLYMTDQty, Sum(SecLYMTDValue) as SecLYMTDValue,
            //        Sum(PriCMTQty) as PriCMTQty, Sum(PriCMTValue) as PriCMTValue, Sum(PriLMTQty) as PriLMTQty, Sum(PriLMTValue) as PriLMTValue,
            //        Sum(SecCMTQty) as SecCMTQty, Sum(SecCMTValue) as SecCMTValue, Sum(SecLMTQty) as SecLMTQty, Sum(SecLMTValue) as SecLMTValue
            //        from DWDB.dbo.t_SalesDataProductGroupQtyValueByMktGrp a Where 1=1 {1}
            //        Group by MarketGroupType, Channel, MarketGroupName, Sort, BrandName, MarketGroupID, ParentID,DataType
            //        ) as final  ";

            string subCondition = "";
            if (sIsProductGroupChecked == "true")
            {
                
                if (sPGID != "-1")
                {
                    subCondition += " AND PGID = " + sPGID;
                }
                if (sMAGID != "-1")
                {
                    subCondition += " AND MAGID = " + sMAGID;
                }
                if (sASGID != "-1")
                {
                    subCondition += " AND ASGID = " + sASGID;
                }
                if (sBrandID != "-1")
                {
                    subCondition += " AND BrandID = " + sBrandID;
                }
            }
            //if (sAndroidAppID == Convert.ToString((int) Dictionary.AndroidAppID.CJ_Lighting))
            //{
            //    subCondition += " AND MarketGroupID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
            //    " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUser + "')) ";
            //}

            sSQL = string.Format(sSQL, subCondition, subCondition);

            sSQL += " Order by Type , Channel, MarketGroupSort, MarketGroupName ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();
                    oData.MarketGroupID = reader["MarketGroupID"].ToString();
                    oData.MarketGroupSort = (int)reader["MarketGroupSort"];
                    oData.MarketGroupType = reader["MarketGroupType"].ToString();
                    oData.MarketGroupName = reader["MarketGroupName"].ToString();
                    oData.Channel = reader["Channel"].ToString();
                    oData.BrandName = reader["BrandName"].ToString();
                    oData.ParentID = reader["ParentID"].ToString();
                   
                    //oData.BrandSort = (int)reader["BrandSort"];

                    oData.PriDTDQty = Convert.ToInt32(reader["PriDTDQty"]);
                    oData.PriDTDValue = Convert.ToDouble(reader["PriDTDValue"]);
                    oData.PriLDQty = Convert.ToInt32(reader["PriLDQty"]);
                    oData.PriLDValue = Convert.ToDouble(reader["PriLDValue"]);
                    oData.PriMTDQty = Convert.ToInt32(reader["PriMTDQty"]);
                    oData.PriMTDValue = Convert.ToDouble(reader["PriMTDValue"]);
                    oData.PriLMQty = Convert.ToInt32(reader["PriLMQty"]);
                    oData.PriLMValue = Convert.ToDouble(reader["PriLMValue"]);
                    oData.PriYTDQty = Convert.ToInt32(reader["PriYTDQty"]);
                    oData.PriYTDValue = Convert.ToDouble(reader["PriYTDValue"]);
                    oData.PriLYQty = Convert.ToInt32(reader["PriLYQty"]);
                    oData.PriLYValue = Convert.ToDouble(reader["PriLYValue"]);
                    oData.PriLYYTDQty = Convert.ToInt32(reader["PriLYYTDQty"]);
                    oData.PriLYYTDValue = Convert.ToDouble(reader["PriLYYTDValue"]);
                    oData.PriLYMTDQty = Convert.ToInt32(reader["PriLYMTDQty"]);
                    oData.PriLYMTDValue = Convert.ToDouble(reader["PriLYMTDValue"]);
                    oData.PriCMTQty = Convert.ToInt32(reader["PriCMTQty"]);
                    oData.PriCMTValue = Convert.ToDouble(reader["PriCMTValue"]);
                    oData.PriLMTQty = Convert.ToInt32(reader["PriLMTQty"]);
                    oData.PriLMTValue = Convert.ToDouble(reader["PriLMTValue"]);
                    oData.PriStockQty= Convert.ToInt32(reader["PriCRStock"]);
                    oData.PriStockVal = Convert.ToInt32(reader["PriStockVal"]);


                    oData.SecDTDQty = Convert.ToInt32(reader["SecDTDQty"]);
                    oData.SecDTDValue = Convert.ToDouble(reader["SecDTDValue"]);
                    oData.SecLDQty = Convert.ToInt32(reader["SecLDQty"]);
                    oData.SecLDValue = Convert.ToDouble(reader["SecLDValue"]);
                    oData.SecMTDQty = Convert.ToInt32(reader["SecMTDQty"]);
                    oData.SecMTDValue = Convert.ToDouble(reader["SecMTDValue"]);
                    oData.SecLMQty = Convert.ToInt32(reader["SecLMQty"]);
                    oData.SecLMValue = Convert.ToDouble(reader["SecLMValue"]);
                    oData.SecYTDQty = Convert.ToInt32(reader["SecYTDQty"]);
                    oData.SecYTDValue = Convert.ToDouble(reader["SecYTDValue"]);
                    oData.SecLYQty = Convert.ToInt32(reader["SecLYQty"]);
                    oData.SecLYValue = Convert.ToDouble(reader["SecLYValue"]);
                    oData.SecLYYTDQty = Convert.ToInt32(reader["SecLYYTDQty"]);
                    oData.SecLYYTDValue = Convert.ToDouble(reader["SecLYYTDValue"]);
                    oData.SecLYMTDQty = Convert.ToInt32(reader["SecLYMTDQty"]);
                    oData.SecLYMTDValue = Convert.ToDouble(reader["SecLYMTDValue"]);
                    oData.SecCMTQty = Convert.ToInt32(reader["SecCMTQty"]);
                    oData.SecCMTValue = Convert.ToDouble(reader["SecCMTValue"]);
                    oData.SecLMTQty = Convert.ToInt32(reader["SecLMTQty"]);
                    oData.SecLMTValue = Convert.ToDouble(reader["SecLMTValue"]);
                    oData.SecStockQty = Convert.ToInt32(reader["SecCRStock"]);
                    oData.SecStockVal = Convert.ToInt32(reader["SecStockVal"]);

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
            int nDays = DateTime.Now.Day;
            DateTime _lastDaysofMonth = _oTELLib.LastDayofMonth(DateTime.Now.Date);
            int nMonthDays = _lastDaysofMonth.Day;

            List<Data> eList = new List<Data>();
            foreach (Data oData in this)
            {
                _oData = new Data();
                _oData.Name = oData.Name;
                _oData.MarketGroupType = oData.MarketGroupType;
                _oData.Channel = oData.Channel;
                _oData.MarketGroupName = oData.MarketGroupName;
                _oData.ParentID = oData.ParentID;
                _oData.MarketGroupID = oData.MarketGroupID;
                _oData.Type = oData.Type;
                _oData.Value = oData.Value;

                _oData.PriDTDQtyText = oData.PriDTDQty.ToString();
                _oData.PriLDQtyText = oData.PriLDQty.ToString();
                _oData.PriMTDQtyText = oData.PriMTDQty.ToString();
                _oData.PriLMQtyText = oData.PriLMQty.ToString();
                _oData.PriYTDQtyText = oData.PriYTDQty.ToString();
                _oData.PriLYQtyText = oData.PriLYQty.ToString();
                _oData.PriLYYTDQtyText = oData.PriLYYTDQty.ToString();
                _oData.PriLYMTDQtyText = oData.PriLYMTDQty.ToString();
                _oData.PriCMTQtyText = oData.PriCMTQty.ToString();
                _oData.PriLMTQtyText = oData.PriLMTQty.ToString();
                _oData.PriStockQtyText = oData.PriStockQty.ToString();

                _oData.PriDTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriDTDValue));
                _oData.PriLDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriLDValue));
                _oData.PriMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriMTDValue));
                _oData.PriLMValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriLMValue));
                _oData.PriYTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriYTDValue));
                _oData.PriLYValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriLYValue));
                _oData.PriLYYTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriLYYTDValue));
                _oData.PriLYMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriLYMTDValue));
                _oData.PriCMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriCMTValue));
                _oData.PriLMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriLMTValue));
                _oData.PriStockValText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriStockVal));


                _oData.SecDTDQtyText = oData.SecDTDQty.ToString();
                _oData.SecLDQtyText = oData.SecLDQty.ToString();
                _oData.SecMTDQtyText = oData.SecMTDQty.ToString();
                _oData.SecLMQtyText = oData.SecLMQty.ToString();
                _oData.SecYTDQtyText = oData.SecYTDQty.ToString();
                _oData.SecLYQtyText = oData.SecLYQty.ToString();
                _oData.SecLYYTDQtyText = oData.SecLYYTDQty.ToString();
                _oData.SecLYMTDQtyText = oData.SecLYMTDQty.ToString();
                _oData.SecCMTQtyText = oData.SecCMTQty.ToString();
                _oData.SecLMTQtyText = oData.SecLMTQty.ToString();
                _oData.SecStockQtyText = oData.SecStockQty.ToString();

                _oData.SecDTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SecDTDValue));
                _oData.SecLDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SecLDValue));
                _oData.SecMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SecMTDValue));
                _oData.SecLMValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SecLMValue));
                _oData.SecYTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SecYTDValue));
                _oData.SecLYValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SecLYValue));
                _oData.SecLYYTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SecLYYTDValue));
                _oData.SecLYMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SecLYMTDValue));
                _oData.SecCMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SecCMTValue));
                _oData.SecLMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SecLMTValue));
                _oData.SecStockValText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SecStockVal));


                //Primary start
                if (oData.PriCMTQty > 0)
                {
                    _oData.PriMTDQtyPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.PriMTDQty) / oData.PriCMTQty) * 100));
                }
                else
                {
                    _oData.PriMTDQtyPercText = "0";
                }
                if (oData.PriLMTQty > 0)
                {
                    _oData.PriLMQtyPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.PriLMQty) / oData.PriLMTQty) * 100));
                }
                else
                {
                    _oData.PriLMQtyPercText = "0";
                }
                if (oData.PriLYMTDQty > 0)
                {
                    _oData.PriMTDQtyGthPercText = Convert.ToString(Math.Round(((Convert.ToDouble(oData.PriMTDQty) / oData.PriLYMTDQty) * 100) - 100));
                }
                else
                {
                    _oData.PriMTDQtyGthPercText = "0";
                }
                if (oData.PriLYYTDQty > 0)
                {
                    _oData.PriYTDQtyGthPercText = Convert.ToString(Math.Round(((Convert.ToDouble(oData.PriYTDQty) / oData.PriLYYTDQty) * 100) - 100));
                }
                else
                {
                    _oData.PriYTDQtyGthPercText = "0";
                }

                if (oData.PriCMTValue > 0)
                {
                    _oData.PriMTDValuePercText = Convert.ToString(Math.Round((oData.PriMTDValue / oData.PriCMTValue) * 100));
                }
                else
                {
                    _oData.PriMTDValuePercText = "0";
                }
                if (oData.PriLMTValue > 0)
                {
                    _oData.PriLMValuePercText = Convert.ToString(Math.Round((oData.PriLMValue / oData.PriLMTValue) * 100));
                }
                else
                {
                    _oData.PriLMValuePercText = "0";
                }
                if (oData.PriLYMTDValue > 0)
                {
                    _oData.PriMTDValueGthPercText = Convert.ToString(Math.Round(((oData.PriMTDValue / oData.PriLYMTDValue) * 100) - 100));
                }
                else
                {
                    _oData.PriMTDValueGthPercText = "0";
                }
                if (oData.PriLYYTDValue > 0)
                {
                    _oData.PriYTDValueGthPercText = Convert.ToString(Math.Round(((oData.PriYTDValue / oData.PriLYYTDValue) * 100) - 100));
                }
                else
                {
                    _oData.PriYTDValueGthPercText = "0";
                }
                //Primary End

                //Secondary Start
                if (oData.SecCMTQty > 0)
                {
                    _oData.SecMTDQtyPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.SecMTDQty) / oData.SecCMTQty) * 100));
                }
                else
                {
                    _oData.SecMTDQtyPercText = "0";
                }
                /*
                                        public string PriMTDTarQtyText;
                        public string PriMTDTarValText;
                        public string PriMTDTarQtyPer;
                        public string PriMTDTarValPer;

                        public string SecMTDTarQtyText;
                        public string SecMTDTarValText;
                        public string SecMTDTarQtyPer;
                        public string SecMTDTarValPer;*/

                if (oData.PriCMTQty > 0)
                {
                    _oData.PriMTDTarQtyText = Convert.ToString(Math.Round((Convert.ToDouble(oData.PriCMTQty) / nMonthDays * nDays)));
                }
                else
                {
                    _oData.PriMTDTarQtyText = "0";
                }
                if (oData.PriCMTQty > 0)
                {
                    _oData.PriMTDTarQtyPer = Convert.ToString(Math.Round(oData.PriMTDQty / (Convert.ToDouble(_oData.PriMTDTarQtyText)) * 100));


                }
                else
                {
                    _oData.PriMTDTarQtyPer = "0";
                }
                if (oData.PriCMTValue > 0)
                {
                    _oData.PriMTDTarValText = Convert.ToString(Math.Round((Convert.ToDouble(oData.PriCMTValue) / nMonthDays * nDays)));
                }
                else
                {
                    _oData.PriMTDTarValText = "0";
                }
                if (oData.PriCMTValue > 0)
                {
                    _oData.PriMTDTarValPer = Convert.ToString(Math.Round(oData.PriMTDValue / (Convert.ToDouble(_oData.PriMTDTarValText)) * 100));


                }
                else
                {
                    _oData.PriMTDTarValPer = "0";
                }
                //--------------------------------------------------------
                if (oData.SecCMTQty > 0)
                {
                    _oData.SecMTDTarQtyText = Convert.ToString(Math.Round((Convert.ToDouble(oData.SecCMTQty) / nMonthDays * nDays)));
                }
                else
                {
                    _oData.SecMTDTarQtyText = "0";
                }
                if (oData.SecCMTQty > 0)
                {
                    _oData.SecMTDTarQtyPer = Convert.ToString(Math.Round(oData.SecMTDQty / (Convert.ToDouble(_oData.SecMTDTarQtyText)) * 100));


                }
                else
                {
                    _oData.SecMTDTarQtyPer = "0";
                }
                if (oData.SecCMTValue > 0)
                {
                    _oData.SecMTDTarValText = Convert.ToString(Math.Round((Convert.ToDouble(oData.SecCMTValue) / nMonthDays * nDays)));
                }
                else
                {
                    _oData.SecMTDTarValText = "0";
                }
                if (oData.SecCMTValue > 0)
                {
                    _oData.SecMTDTarValPer = Convert.ToString(Math.Round(oData.SecMTDValue/(Convert.ToDouble(_oData.SecMTDTarValText)) * 100));

                }
                else
                {
                    _oData.SecMTDTarValPer = "0";
                }
                //-------------------------------------------------------


                if (oData.SecLMTQty > 0)
                {
                    _oData.SecLMQtyPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.SecLMQty) / oData.SecLMTQty) * 100));
                }
                else
                {
                    _oData.SecLMQtyPercText = "0";
                }
                if (oData.SecLYMTDQty > 0)
                {
                    _oData.SecMTDQtyGthPercText = Convert.ToString(Math.Round(((Convert.ToDouble(oData.SecMTDQty) / oData.SecLYMTDQty) * 100) - 100));
                }
                else
                {
                    _oData.SecMTDQtyGthPercText = "0";
                }
                if (oData.SecLYYTDQty > 0)
                {
                    _oData.SecYTDQtyGthPercText = Convert.ToString(Math.Round(((Convert.ToDouble(oData.SecYTDQty) / oData.SecLYYTDQty) * 100) - 100));
                }
                else
                {
                    _oData.SecYTDQtyGthPercText = "0";
                }

                if (oData.SecCMTValue > 0)
                {
                    _oData.SecMTDValuePercText = Convert.ToString(Math.Round((oData.SecMTDValue / oData.SecCMTValue) * 100));
                }
                else
                {
                    _oData.SecMTDValuePercText = "0";
                }
                if (oData.SecLMTValue > 0)
                {
                    _oData.SecLMValuePercText = Convert.ToString(Math.Round((oData.SecLMValue / oData.SecLMTValue) * 100));
                }
                else
                {
                    _oData.SecLMValuePercText = "0";
                }
                if (oData.SecLYMTDValue > 0)
                {
                    _oData.SecMTDValueGthPercText = Convert.ToString(Math.Round(((oData.SecMTDValue / oData.SecLYMTDValue) * 100) - 100));
                }
                else
                {
                    _oData.SecMTDValueGthPercText = "0";
                }
                if (oData.SecLYYTDValue > 0)
                {
                    _oData.SecYTDValueGthPercText = Convert.ToString(Math.Round(((oData.SecYTDValue / oData.SecLYYTDValue) * 100) - 100));
                }
                else
                {
                    _oData.SecYTDValueGthPercText = "0";
                }
                //Secondary End
                eList.Add(_oData);
            }
            return eList;

        }

    }
}
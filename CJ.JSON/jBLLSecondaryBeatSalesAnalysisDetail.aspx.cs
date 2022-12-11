
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

public partial class jBLLSecondaryBeatSalesAnalysisDetail : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sCustomerID = c.Request.Form["CustomerID"].Trim();

            //string sUser = "hakim";
            //string sCustomerID = "373";

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
            catch(Exception ex)
            {
                dDate = DateTime.Now.Date;
            }
            Datas oDatas = new Datas();
            Data _oData = new Data();
            Datas _oDatas = new Datas();
            
            Data _oDataNational = new Data();
            Data _oDataNationalNC = new Data();
            Data _oDataNationalECM = new Data();
            Data _oDataNationalIns = new Data();
            Data _oDataNationalTha = new Data();

            Data _oDataArea = new Data();
            Data _oDataAreaNC = new Data();
            Data _oDataAreaECM = new Data();
            Data _oDataAreaIns = new Data();
            Data _oDataAreaTha = new Data();


            Data _oDataBeat = new Data();

            int nCount = 0;

            Data oDatax = new Data();
            DBController.Instance.OpenNewConnection();
            oDatas.GetData(dDate, sCustomerID);
            oDatax.GetTSO(sCustomerID);
            DBController.Instance.CloseConnection();
            #region Loop
            foreach (Data oData in oDatas)
            {
                if (nCount == 0)
                {
                    #region National
                    //All
                    _oDataNational = new Data();
                    _oDatas.Add(_oDataNational);
                    _oDataNational.CustomerID = sCustomerID;
                    _oDataNational.ShortName = "Total";
                    _oDataNational.FullName = " TSO: " + oDatax.TSO;
                    _oDataNational.ResponsiblePerson = " TSO: " + oDatax.TSO;
                    _oDataNational.MobileNo = oDatax.TSOMob;
                    _oDataNational.RouteTypeID = "0";
                    _oDataNational.sRouteID = "0";
                    _oDataNational.Type = "National";
                    _oDataNational.Value = "Success";
                    _oDataNational.IsActive = "1";
                    _oDataNational.AreaID = oData.AreaID;
                    _oDataNational.TerritoryID = oData.TerritoryID;

                    //Non Cluster
                    _oDataNationalNC = new Data();
                    _oDatas.Add(_oDataNationalNC);
                    _oDataNationalNC.CustomerID = sCustomerID;
                    _oDataNationalNC.ShortName = "Total";
                    _oDataNationalNC.FullName = " TSO: " + oDatax.TSO;
                    _oDataNationalNC.ResponsiblePerson = " TSO: " + oDatax.TSO;
                    _oDataNationalNC.MobileNo = oDatax.TSOMob;
                    _oDataNationalNC.RouteTypeID = "1";
                    _oDataNationalNC.sRouteID = "0";
                    _oDataNationalNC.Type = "National";
                    _oDataNationalNC.Value = "Success";
                    _oDataNationalNC.IsActive = "1";
                    _oDataNationalNC.AreaID = oData.AreaID;
                    _oDataNationalNC.TerritoryID = oData.TerritoryID;

                    //ECM
                    _oDataNationalECM = new Data();
                    _oDatas.Add(_oDataNationalECM);
                    _oDataNationalECM.CustomerID = sCustomerID;
                    _oDataNationalECM.ShortName = "Total";
                    _oDataNationalECM.FullName = " TSO: " + oDatax.TSO;
                    _oDataNationalECM.ResponsiblePerson = " TSO: " + oDatax.TSO;
                    _oDataNationalECM.MobileNo = oDatax.TSOMob;
                    _oDataNationalECM.RouteTypeID = "2";
                    _oDataNationalECM.sRouteID = "0";
                    _oDataNationalECM.Type = "National";
                    _oDataNationalECM.Value = "Success";
                    _oDataNationalECM.IsActive = "1";
                    _oDataNationalECM.AreaID = oData.AreaID;
                    _oDataNationalECM.TerritoryID = oData.TerritoryID;

                    //Institution
                    _oDataNationalIns = new Data();
                    _oDatas.Add(_oDataNationalIns);
                    _oDataNationalIns.CustomerID = sCustomerID;
                    _oDataNationalIns.ShortName = "Total";
                    _oDataNationalIns.FullName = " TSO: " + oDatax.TSO;
                    _oDataNationalIns.ResponsiblePerson = " TSO: " + oDatax.TSO;
                    _oDataNationalIns.MobileNo = oDatax.TSOMob;
                    _oDataNationalIns.RouteTypeID = "3";
                    _oDataNationalIns.sRouteID = "0";
                    _oDataNationalIns.Type = "National";
                    _oDataNationalIns.Value = "Success";
                    _oDataNationalIns.IsActive = "1";
                    _oDataNationalIns.AreaID = oData.AreaID;
                    _oDataNationalIns.TerritoryID = oData.TerritoryID;

                    //Thana
                    _oDataNationalTha = new Data();
                    _oDatas.Add(_oDataNationalTha);
                    _oDataNationalTha.CustomerID = sCustomerID;
                    _oDataNationalTha.ShortName = "Total";
                    _oDataNationalTha.FullName = " TSO: " + oDatax.TSO;
                    _oDataNationalTha.ResponsiblePerson = " TSO: " + oDatax.TSO;
                    _oDataNationalTha.MobileNo = oDatax.TSOMob;
                    _oDataNationalTha.RouteTypeID = "4";
                    _oDataNationalTha.sRouteID = "0";
                    _oDataNationalTha.Type = "National";
                    _oDataNationalTha.Value = "Success";
                    _oDataNationalTha.IsActive = "1";
                    _oDataNationalTha.AreaID = oData.AreaID;
                    _oDataNationalTha.TerritoryID = oData.TerritoryID;

                    nCount++;
                    #endregion
                }
                if (_oDataArea.DSRID != oData.DSRID)
                {
                    #region Area
                    //All
                    _oDataArea = new Data();
                    _oDatas.Add(_oDataArea);
                    _oDataArea.CustomerID = sCustomerID;
                    _oDataArea.DSRID = oData.DSRID;
                    _oDataArea.ShortName = oData.DSRName;
                    _oDataArea.FullName = oData.DSRName;
                    _oDataArea.ResponsiblePerson = " DSR: " + oData.DSRName;
                    _oDataArea.MobileNo = oData.DSRMobileNo;
                    _oDataArea.RouteTypeID = "0";
                    _oDataArea.sRouteID = oData.sRouteID;
                    _oDataArea.Type = "Route";
                    _oDataArea.Value = "Success";
                    _oDataArea.IsActive = oData.IsActive;
                    _oDataArea.AreaID = oData.AreaID;
                    _oDataArea.TerritoryID = oData.TerritoryID;

                    //NC
                    _oDataAreaNC = new Data();
                    _oDatas.Add(_oDataAreaNC);
                    _oDataAreaNC.CustomerID = sCustomerID;
                    _oDataAreaNC.DSRID = oData.DSRID;
                    _oDataAreaNC.ShortName = oData.DSRName;
                    _oDataAreaNC.FullName = oData.DSRName;
                    _oDataAreaNC.ResponsiblePerson = " DSR: " + oData.DSRName;
                    _oDataAreaNC.MobileNo = oData.DSRMobileNo;
                    _oDataAreaNC.RouteTypeID = "1";
                    _oDataAreaNC.sRouteID = oData.sRouteID;
                    _oDataAreaNC.Type = "Route";
                    _oDataAreaNC.Value = "Success";
                    _oDataAreaNC.IsActive = oData.IsActive;
                    _oDataAreaNC.AreaID = oData.AreaID;
                    _oDataAreaNC.TerritoryID = oData.TerritoryID;

                    //ECM
                    _oDataAreaECM = new Data();
                    _oDatas.Add(_oDataAreaECM);
                    _oDataAreaECM.CustomerID = sCustomerID;
                    _oDataAreaECM.DSRID = oData.DSRID;
                    _oDataAreaECM.ShortName = oData.DSRName;
                    _oDataAreaECM.FullName = oData.DSRName;
                    _oDataAreaECM.ResponsiblePerson = " DSR: " + oData.DSRName;
                    _oDataAreaECM.MobileNo = oData.DSRMobileNo;
                    _oDataAreaECM.RouteTypeID = "2";
                    _oDataAreaECM.sRouteID = oData.sRouteID;
                    _oDataAreaECM.Type = "Route";
                    _oDataAreaECM.Value = "Success";
                    _oDataAreaECM.IsActive = oData.IsActive;
                    _oDataAreaECM.AreaID = oData.AreaID;
                    _oDataAreaECM.TerritoryID = oData.TerritoryID;

                    //Institute
                    _oDataAreaIns = new Data();
                    _oDatas.Add(_oDataAreaIns);
                    _oDataAreaIns.CustomerID = sCustomerID;
                    _oDataAreaIns.DSRID = oData.DSRID;
                    _oDataAreaIns.ShortName = oData.DSRName;
                    _oDataAreaIns.FullName = oData.DSRMobileNo;
                    _oDataAreaIns.ResponsiblePerson = " DSR: " + oData.DSRName;
                    _oDataAreaIns.MobileNo = oData.DSRMobileNo;
                    _oDataAreaIns.RouteTypeID = "3";
                    _oDataAreaIns.sRouteID = oData.sRouteID;
                    _oDataAreaIns.Type = "Route";
                    _oDataAreaIns.Value = "Success";
                    _oDataAreaIns.IsActive = oData.IsActive;
                    _oDataAreaIns.AreaID = oData.AreaID;
                    _oDataAreaIns.TerritoryID = oData.TerritoryID;

                    //Thana
                    _oDataAreaTha = new Data();
                    _oDatas.Add(_oDataAreaTha);
                    _oDataAreaTha.CustomerID = sCustomerID;
                    _oDataAreaTha.DSRID = oData.DSRID;
                    _oDataAreaTha.ShortName = oData.DSRName;
                    _oDataAreaTha.FullName = oData.DSRName;
                    _oDataAreaTha.ResponsiblePerson = " DSR: " + oData.DSRName;
                    _oDataAreaTha.MobileNo = oData.DSRMobileNo;
                    _oDataAreaTha.RouteTypeID = "4";
                    _oDataAreaTha.sRouteID = oData.sRouteID;
                    _oDataAreaTha.Type = "Route";
                    _oDataAreaTha.Value = "Success";
                    _oDataAreaTha.IsActive = oData.IsActive;
                    _oDataAreaTha.AreaID = oData.AreaID;
                    _oDataAreaTha.TerritoryID = oData.TerritoryID;

                    #endregion
                }

                _oDataBeat = new Data();
                _oDataBeat.Value = "Success";

                _oDataBeat.DSRID = oData.DSRID;
                _oDataBeat.CustomerID = sCustomerID;
                _oDataBeat.ShortName = oData.Route;
                _oDataBeat.FullName = " DSR: " + oData.DSRName + " | " + oData.DSRMobileNo;
                _oDataBeat.ResponsiblePerson = " DSR: " + oData.DSRName;
                _oDataBeat.MobileNo = oData.DSRMobileNo;
                _oDataBeat.CMSTValue = oData.CMSTValue;
                _oDataBeat.CMSAMTDValue = oData.CMSAMTDValue;
                _oDataBeat.LMSAMTDValue = oData.LMSAMTDValue;
                _oDataBeat.LMSAValue = oData.LMSAValue;
                _oDataBeat.LYCMSAValue = oData.LYCMSAValue;
                _oDataBeat.LYCMSAMTDValue = oData.LYCMSAMTDValue;

                _oDataBeat.LDValue = oData.LDValue;
                _oDataBeat.YTDValue = oData.YTDValue;
                _oDataBeat.LYYTDValue = oData.LYYTDValue;
                _oDataBeat.LYValue = oData.LYValue;

                _oDataBeat.RouteTypeID = oData.RouteTypeID;
                _oDataBeat.sRouteID = oData.sRouteID;
                _oDataBeat.IsActive = oData.IsActiveDB;
                _oDataBeat.AreaID = oData.AreaID;
                _oDataBeat.TerritoryID = oData.TerritoryID;

                _oDataBeat.LDOrderValue = oData.LDOrderValue;
                _oDataBeat.MTDOrderValue = oData.MTDOrderValue;
                _oDataBeat.SlabTarget = oData.SlabTarget;
                _oDataBeat.MTDSlabActual = oData.MTDSlabActual;

                _oDataBeat.Type = "Beat";
                _oDatas.Add(_oDataBeat);

                #region National

                _oDataNational.CMSTValue = _oDataNational.CMSTValue + oData.CMSTValue;
                _oDataNational.CMSAMTDValue = _oDataNational.CMSAMTDValue + oData.CMSAMTDValue;
                _oDataNational.LMSAMTDValue = _oDataNational.LMSAMTDValue + oData.LMSAMTDValue;
                _oDataNational.LMSAValue = _oDataNational.LMSAValue + oData.LMSAValue;
                _oDataNational.LYCMSAValue = _oDataNational.LYCMSAValue + oData.LYCMSAValue;
                _oDataNational.LYCMSAMTDValue = _oDataNational.LYCMSAMTDValue + oData.LYCMSAMTDValue;

                _oDataNational.LDValue = _oDataNational.LDValue + oData.LDValue;
                _oDataNational.YTDValue = _oDataNational.YTDValue + oData.YTDValue;
                _oDataNational.LYYTDValue = _oDataNational.LYYTDValue + oData.LYYTDValue;
                _oDataNational.LYValue = _oDataNational.LYValue + oData.LYValue;

                _oDataNational.LDOrderValue = _oDataNational.LDOrderValue + oData.LDOrderValue;
                _oDataNational.MTDOrderValue = _oDataNational.MTDOrderValue + oData.MTDOrderValue;
                _oDataNational.SlabTarget = _oDataNational.SlabTarget + oData.SlabTarget;
                _oDataNational.MTDSlabActual = _oDataNational.MTDSlabActual + oData.MTDSlabActual;
                _oDataNational.TodayTarget = _oDataNational.TodayTarget + oData.TodayTarget;

                if (oData.RouteTypeID == "1")
                {
                    _oDataNationalNC.CMSTValue = _oDataNationalNC.CMSTValue + oData.CMSTValue;
                    _oDataNationalNC.CMSAMTDValue = _oDataNationalNC.CMSAMTDValue + oData.CMSAMTDValue;
                    _oDataNationalNC.LMSAMTDValue = _oDataNationalNC.LMSAMTDValue + oData.LMSAMTDValue;
                    _oDataNationalNC.LMSAValue = _oDataNationalNC.LMSAValue + oData.LMSAValue;
                    _oDataNationalNC.LYCMSAValue = _oDataNationalNC.LYCMSAValue + oData.LYCMSAValue;
                    _oDataNationalNC.LYCMSAMTDValue = _oDataNationalNC.LYCMSAMTDValue + oData.LYCMSAMTDValue;

                    _oDataNationalNC.LDValue = _oDataNationalNC.LDValue + oData.LDValue;
                    _oDataNationalNC.YTDValue = _oDataNationalNC.YTDValue + oData.YTDValue;
                    _oDataNationalNC.LYYTDValue = _oDataNationalNC.LYYTDValue + oData.LYYTDValue;
                    _oDataNationalNC.LYValue = _oDataNationalNC.LYValue + oData.LYValue;

                    _oDataNationalNC.LDOrderValue = _oDataNationalNC.LDOrderValue + oData.LDOrderValue;
                    _oDataNationalNC.MTDOrderValue = _oDataNationalNC.MTDOrderValue + oData.MTDOrderValue;
                    _oDataNationalNC.SlabTarget = _oDataNationalNC.SlabTarget + oData.SlabTarget;
                    _oDataNationalNC.MTDSlabActual = _oDataNationalNC.MTDSlabActual + oData.MTDSlabActual;
                    _oDataNationalNC.TodayTarget = _oDataNationalNC.TodayTarget + oData.TodayTarget;
                }
                else if (oData.RouteTypeID == "2")
                {
                    _oDataNationalECM.CMSTValue = _oDataNationalECM.CMSTValue + oData.CMSTValue;
                    _oDataNationalECM.CMSAMTDValue = _oDataNationalECM.CMSAMTDValue + oData.CMSAMTDValue;
                    _oDataNationalECM.LMSAMTDValue = _oDataNationalECM.LMSAMTDValue + oData.LMSAMTDValue;
                    _oDataNationalECM.LMSAValue = _oDataNationalECM.LMSAValue + oData.LMSAValue;
                    _oDataNationalECM.LYCMSAValue = _oDataNationalECM.LYCMSAValue + oData.LYCMSAValue;
                    _oDataNationalECM.LYCMSAMTDValue = _oDataNationalECM.LYCMSAMTDValue + oData.LYCMSAMTDValue;

                    _oDataNationalECM.LDValue = _oDataNationalECM.LDValue + oData.LDValue;
                    _oDataNationalECM.YTDValue = _oDataNationalECM.YTDValue + oData.YTDValue;
                    _oDataNationalECM.LYYTDValue = _oDataNationalECM.LYYTDValue + oData.LYYTDValue;
                    _oDataNationalECM.LYValue = _oDataNationalECM.LYValue + oData.LYValue;

                    _oDataNationalECM.LDOrderValue = _oDataNationalECM.LDOrderValue + oData.LDOrderValue;
                    _oDataNationalECM.MTDOrderValue = _oDataNationalECM.MTDOrderValue + oData.MTDOrderValue;
                    _oDataNationalECM.SlabTarget = _oDataNationalECM.SlabTarget + oData.SlabTarget;
                    _oDataNationalECM.MTDSlabActual = _oDataNationalECM.MTDSlabActual + oData.MTDSlabActual;
                    _oDataNationalECM.TodayTarget = _oDataNationalECM.TodayTarget + oData.TodayTarget;
                }
                else if (oData.RouteTypeID == "3")
                {
                    _oDataNationalIns.CMSTValue = _oDataNationalIns.CMSTValue + oData.CMSTValue;
                    _oDataNationalIns.CMSAMTDValue = _oDataNationalIns.CMSAMTDValue + oData.CMSAMTDValue;
                    _oDataNationalIns.LMSAMTDValue = _oDataNationalIns.LMSAMTDValue + oData.LMSAMTDValue;
                    _oDataNationalIns.LMSAValue = _oDataNationalIns.LMSAValue + oData.LMSAValue;
                    _oDataNationalIns.LYCMSAValue = _oDataNationalIns.LYCMSAValue + oData.LYCMSAValue;
                    _oDataNationalIns.LYCMSAMTDValue = _oDataNationalIns.LYCMSAMTDValue + oData.LYCMSAMTDValue;

                    _oDataNationalIns.LDValue = _oDataNationalIns.LDValue + oData.LDValue;
                    _oDataNationalIns.YTDValue = _oDataNationalIns.YTDValue + oData.YTDValue;
                    _oDataNationalIns.LYYTDValue = _oDataNationalIns.LYYTDValue + oData.LYYTDValue;
                    _oDataNationalIns.LYValue = _oDataNationalIns.LYValue + oData.LYValue;

                    _oDataNationalIns.LDOrderValue = _oDataNationalIns.LDOrderValue + oData.LDOrderValue;
                    _oDataNationalIns.MTDOrderValue = _oDataNationalIns.MTDOrderValue + oData.MTDOrderValue;
                    _oDataNationalIns.SlabTarget = _oDataNationalIns.SlabTarget + oData.SlabTarget;
                    _oDataNationalIns.MTDSlabActual = _oDataNationalIns.MTDSlabActual + oData.MTDSlabActual;

                    _oDataNationalIns.TodayTarget = _oDataNationalIns.TodayTarget + oData.TodayTarget;
                }
                else if (oData.RouteTypeID == "4")
                {
                    _oDataNationalTha.CMSTValue = _oDataNationalTha.CMSTValue + oData.CMSTValue;
                    _oDataNationalTha.CMSAMTDValue = _oDataNationalTha.CMSAMTDValue + oData.CMSAMTDValue;
                    _oDataNationalTha.LMSAMTDValue = _oDataNationalTha.LMSAMTDValue + oData.LMSAMTDValue;
                    _oDataNationalTha.LMSAValue = _oDataNationalTha.LMSAValue + oData.LMSAValue;
                    _oDataNationalTha.LYCMSAValue = _oDataNationalTha.LYCMSAValue + oData.LYCMSAValue;
                    _oDataNationalTha.LYCMSAMTDValue = _oDataNationalTha.LYCMSAMTDValue + oData.LYCMSAMTDValue;

                    _oDataNationalTha.LDValue = _oDataNationalTha.LDValue + oData.LDValue;
                    _oDataNationalTha.YTDValue = _oDataNationalTha.YTDValue + oData.YTDValue;
                    _oDataNationalTha.LYYTDValue = _oDataNationalTha.LYYTDValue + oData.LYYTDValue;
                    _oDataNationalTha.LYValue = _oDataNationalTha.LYValue + oData.LYValue;

                    _oDataNationalTha.LDOrderValue = _oDataNationalTha.LDOrderValue + oData.LDOrderValue;
                    _oDataNationalTha.MTDOrderValue = _oDataNationalTha.MTDOrderValue + oData.MTDOrderValue;
                    _oDataNationalTha.SlabTarget = _oDataNationalTha.SlabTarget + oData.SlabTarget;
                    _oDataNationalTha.MTDSlabActual = _oDataNationalTha.MTDSlabActual + oData.MTDSlabActual;
                    _oDataNationalTha.TodayTarget = _oDataNationalTha.TodayTarget + oData.TodayTarget;
                }
                #endregion

                #region Route
                
                _oDataArea.CMSTValue = _oDataArea.CMSTValue + oData.CMSTValue;
                _oDataArea.CMSAMTDValue = _oDataArea.CMSAMTDValue + oData.CMSAMTDValue;
                _oDataArea.LMSAMTDValue = _oDataArea.LMSAMTDValue + oData.LMSAMTDValue;
                _oDataArea.LMSAValue = _oDataArea.LMSAValue + oData.LMSAValue;
                _oDataArea.LYCMSAValue = _oDataArea.LYCMSAValue + oData.LYCMSAValue;
                _oDataArea.LYCMSAMTDValue = _oDataArea.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                _oDataArea.LDValue = _oDataArea.LDValue + oData.LDValue;
                _oDataArea.YTDValue = _oDataArea.YTDValue + oData.YTDValue;
                _oDataArea.LYYTDValue = _oDataArea.LYYTDValue + oData.LYYTDValue;
                _oDataArea.LYValue = _oDataArea.LYValue + oData.LYValue;

                _oDataArea.LDOrderValue = _oDataArea.LDOrderValue + oData.LDOrderValue;
                _oDataArea.MTDOrderValue = _oDataArea.MTDOrderValue + oData.MTDOrderValue;
                _oDataArea.SlabTarget = _oDataArea.SlabTarget + oData.SlabTarget;
                _oDataArea.MTDSlabActual = _oDataArea.MTDSlabActual + oData.MTDSlabActual;

                _oDataArea.TodayTarget = _oDataArea.TodayTarget + oData.TodayTarget;

                if (oData.RouteTypeID == "1")
                {
                    _oDataAreaNC.CMSTValue = _oDataAreaNC.CMSTValue + oData.CMSTValue;
                    _oDataAreaNC.CMSAMTDValue = _oDataAreaNC.CMSAMTDValue + oData.CMSAMTDValue;
                    _oDataAreaNC.LMSAMTDValue = _oDataAreaNC.LMSAMTDValue + oData.LMSAMTDValue;
                    _oDataAreaNC.LMSAValue = _oDataAreaNC.LMSAValue + oData.LMSAValue;
                    _oDataAreaNC.LYCMSAValue = _oDataAreaNC.LYCMSAValue + oData.LYCMSAValue;
                    _oDataAreaNC.LYCMSAMTDValue = _oDataAreaNC.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                    _oDataAreaNC.LDValue = _oDataAreaNC.LDValue + oData.LDValue;
                    _oDataAreaNC.YTDValue = _oDataAreaNC.YTDValue + oData.YTDValue;
                    _oDataAreaNC.LYYTDValue = _oDataAreaNC.LYYTDValue + oData.LYYTDValue;
                    _oDataAreaNC.LYValue = _oDataAreaNC.LYValue + oData.LYValue;

                    _oDataAreaNC.LDOrderValue = _oDataAreaNC.LDOrderValue + oData.LDOrderValue;
                    _oDataAreaNC.MTDOrderValue = _oDataAreaNC.MTDOrderValue + oData.MTDOrderValue;
                    _oDataAreaNC.SlabTarget = _oDataAreaNC.SlabTarget + oData.SlabTarget;
                    _oDataAreaNC.MTDSlabActual = _oDataAreaNC.MTDSlabActual + oData.MTDSlabActual;

                    _oDataAreaNC.TodayTarget = _oDataAreaNC.TodayTarget + oData.TodayTarget;
                }
                else if (oData.RouteTypeID == "2")
                {
                    _oDataAreaECM.CMSTValue = _oDataAreaECM.CMSTValue + oData.CMSTValue;
                    _oDataAreaECM.CMSAMTDValue = _oDataAreaECM.CMSAMTDValue + oData.CMSAMTDValue;
                    _oDataAreaECM.LMSAMTDValue = _oDataAreaECM.LMSAMTDValue + oData.LMSAMTDValue;
                    _oDataAreaECM.LMSAValue = _oDataAreaECM.LMSAValue + oData.LMSAValue;
                    _oDataAreaECM.LYCMSAValue = _oDataAreaECM.LYCMSAValue + oData.LYCMSAValue;
                    _oDataAreaECM.LYCMSAMTDValue = _oDataAreaECM.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                    _oDataAreaECM.LDValue = _oDataAreaECM.LDValue + oData.LDValue;
                    _oDataAreaECM.YTDValue = _oDataAreaECM.YTDValue + oData.YTDValue;
                    _oDataAreaECM.LYYTDValue = _oDataAreaECM.LYYTDValue + oData.LYYTDValue;
                    _oDataAreaECM.LYValue = _oDataAreaECM.LYValue + oData.LYValue;

                    _oDataAreaECM.LDOrderValue = _oDataAreaECM.LDOrderValue + oData.LDOrderValue;
                    _oDataAreaECM.MTDOrderValue = _oDataAreaECM.MTDOrderValue + oData.MTDOrderValue;
                    _oDataAreaECM.SlabTarget = _oDataAreaECM.SlabTarget + oData.SlabTarget;
                    _oDataAreaECM.MTDSlabActual = _oDataAreaECM.MTDSlabActual + oData.MTDSlabActual;

                    _oDataAreaECM.TodayTarget = _oDataAreaECM.TodayTarget + oData.TodayTarget;
                }
                else if (oData.RouteTypeID == "3")
                {
                    _oDataAreaIns.CMSTValue = _oDataAreaIns.CMSTValue + oData.CMSTValue;
                    _oDataAreaIns.CMSAMTDValue = _oDataAreaIns.CMSAMTDValue + oData.CMSAMTDValue;
                    _oDataAreaIns.LMSAMTDValue = _oDataAreaIns.LMSAMTDValue + oData.LMSAMTDValue;
                    _oDataAreaIns.LMSAValue = _oDataAreaIns.LMSAValue + oData.LMSAValue;
                    _oDataAreaIns.LYCMSAValue = _oDataAreaIns.LYCMSAValue + oData.LYCMSAValue;
                    _oDataAreaIns.LYCMSAMTDValue = _oDataAreaIns.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                    _oDataAreaIns.LDValue = _oDataAreaIns.LDValue + oData.LDValue;
                    _oDataAreaIns.YTDValue = _oDataAreaIns.YTDValue + oData.YTDValue;
                    _oDataAreaIns.LYYTDValue = _oDataAreaIns.LYYTDValue + oData.LYYTDValue;
                    _oDataAreaIns.LYValue = _oDataAreaIns.LYValue + oData.LYValue;

                    _oDataAreaIns.LDOrderValue = _oDataAreaIns.LDOrderValue + oData.LDOrderValue;
                    _oDataAreaIns.MTDOrderValue = _oDataAreaIns.MTDOrderValue + oData.MTDOrderValue;
                    _oDataAreaIns.SlabTarget = _oDataAreaIns.SlabTarget + oData.SlabTarget;
                    _oDataAreaIns.MTDSlabActual = _oDataAreaIns.MTDSlabActual + oData.MTDSlabActual;

                    _oDataAreaIns.TodayTarget = _oDataAreaIns.TodayTarget + oData.TodayTarget;
                }
                else if (oData.RouteTypeID == "4")
                {
                    _oDataAreaTha.CMSTValue = _oDataAreaTha.CMSTValue + oData.CMSTValue;
                    _oDataAreaTha.CMSAMTDValue = _oDataAreaTha.CMSAMTDValue + oData.CMSAMTDValue;
                    _oDataAreaTha.LMSAMTDValue = _oDataAreaTha.LMSAMTDValue + oData.LMSAMTDValue;
                    _oDataAreaTha.LMSAValue = _oDataAreaTha.LMSAValue + oData.LMSAValue;
                    _oDataAreaTha.LYCMSAValue = _oDataAreaTha.LYCMSAValue + oData.LYCMSAValue;
                    _oDataAreaTha.LYCMSAMTDValue = _oDataAreaTha.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                    _oDataAreaTha.LDValue = _oDataAreaTha.LDValue + oData.LDValue;
                    _oDataAreaTha.YTDValue = _oDataAreaTha.YTDValue + oData.YTDValue;
                    _oDataAreaTha.LYYTDValue = _oDataAreaTha.LYYTDValue + oData.LYYTDValue;
                    _oDataAreaTha.LYValue = _oDataAreaTha.LYValue + oData.LYValue;

                    _oDataAreaTha.LDOrderValue = _oDataAreaTha.LDOrderValue + oData.LDOrderValue;
                    _oDataAreaTha.MTDOrderValue = _oDataAreaTha.MTDOrderValue + oData.MTDOrderValue;
                    _oDataAreaTha.SlabTarget = _oDataAreaTha.SlabTarget + oData.SlabTarget;
                    _oDataAreaTha.MTDSlabActual = _oDataAreaTha.MTDSlabActual + oData.MTDSlabActual;
                    _oDataAreaTha.TodayTarget = _oDataAreaTha.TodayTarget + oData.TodayTarget;
                }
                #endregion
  
            }
            #endregion
            _oData.InsertReportLog(sUser);

            TELLib _oTELLib = new TELLib();
            DateTime dFromDate = DateTime.Now.Date;
            int DayOfYear = dFromDate.DayOfYear;
            int TotalDayOfYear = _oTELLib.GetDaysInYear(dFromDate.Year);
            int DayOfMonth = dFromDate.Day;
            DateTime dLastDateOfMonth = _oTELLib.LastDayofMonth(dFromDate);
            int TotalDayOfMonth = dLastDateOfMonth.Day;

            //int xx = _oTELLib.LastDayofMonth(dFromDate.Day);
            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput.ToString());

        }
    } 
    public class Data
    {
        // C = Current, M = Month, P=Primary, T=Target, L=Last, Y=Year, A=Actual

       
        public string ShortName;
        public string FullName;
        public string CustomerID;
        public string AreaID;
        public string TerritoryID;
   
        public string Route;
        public int nRouteID;
        public string sRouteID;
        public string Type;
        public string Value;
        public string IsActive;
        public string IsActiveDB;
        public string ActiveStatus;
        public string RouteTypeID;
        public string DSRMobileNo;
        public string DSRName;
        public string ResponsiblePerson;
        public string DSRID;
        public string MobileNo;

        public double CMSTValue;
        public double CMSAMTDValue;
        public double LMSAMTDValue;
        public double LMSAValue;
        public double LYCMSAValue;
        public double LYCMSAMTDValue;

        public double LDValue;
        public double YTDValue;
        public double LYYTDValue;
        public double LYValue;
        public double LDOrderValue;
        public double MTDOrderValue;
        public double SlabTarget;
        public double MTDSlabActual;

        public string CMSTValueText;
        public string CMSAMTDValueText;
        public string LMSAMTDValueText;
        public string LMSAValueText;
        public string LYCMSAValueText;
        public string LYCMSAMTDValueText;

        public string LDValueText;
        public string YTDValueText;
        public string LYYTDValueText;
        public string LYValueText;
        public string LDOrderValueText;
        public string MTDOrderValueText;
        public string SlabTargetText;
        public string MTDSlabActualText;

        public string GSCMMTDPercText;
        public string GSLMMTDPercText;
        public string GSLMFullPercText;
        public string GSLYCMFullPercText;
        public string GSLYCMMTDPercText;
        public string LDOrderPercText;
        public string MTDDeliveryPercText;
        public string MTDSlabPercText;
        public string MTDSlabContributionPercText;
        public string TodayTarget;
        public string MTDRetailValueText;

        public string DayPassing;
        public string GSYTDPercText;

        public string TSO;
        public string TSOMob;

        public void GetTSO(string sCustomerID)
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

                cmd = DBController.Instance.GetCommand();

                sSQL = " Select IsNull(EmployeeName,'') as EmployeeName, IsNull(MobileNo,'') as MobileNo from t_Employee Where "+
                        " EmployeeID=(select EmployeeID from BLLSysDB.dbo.t_DMSUser Where DistributorID= '" + sCustomerID + "') ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    TSO = reader["EmployeeName"].ToString();
                    TSOMob = reader["MobileNo"].ToString();
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10035";
            string sReportName = "BLL-Route Sales (Value/ASG Qty)";
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
        public void GetData(DateTime dDate, string sCustomerID)
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

            DSBLLPerformanceAnalysis oDSLD = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSYTD = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLYYTD = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSLY = new DSBLLPerformanceAnalysis();

            DSBLLPerformanceAnalysis oDSLDOrder = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSMTDOrder = new DSBLLPerformanceAnalysis();
            DSBLLPerformanceAnalysis oDSSlabTargetAndActual = new DSBLLPerformanceAnalysis();

            oDSCustomer = GetCustomerList(sCustomerID);
            oDSCMST = GetRawDataTarget(_FirstDayofMonth, _FirstDayofNextMonth, sCustomerID);
            oDSCMSAMTD = GetRawData("SecondaryActual", _FirstDayofMonth, dToDate, sCustomerID);
            oDSLMSAMTD = GetRawData("SecondaryActual", _FirstDayofLastMonth, _ToDateOfLastMonth, sCustomerID);
            oDSLMSA = GetRawData("SecondaryActual", _FirstDayofLastMonth, _FirstDayofMonth, sCustomerID);
            oDSLYCMSA = GetRawData("SecondaryActual", _FristDayofLastYearThisMonth, _FristDayofLastYearNextMonth, sCustomerID);
            oDSLYCMSAMTD = GetRawData("SecondaryActual", _FristDayofLastYearThisMonth, _ToDateofLastYearThisMonth, sCustomerID);


            oDSLD = GetRawData("SecondaryActual", dLastDate, dFromDate, sCustomerID);
            oDSYTD = GetRawData("SecondaryActual", _FirstDayofThisYear, dToDate, sCustomerID);
            oDSLYYTD = GetRawData("SecondaryActual", _FirstDayofLastYear, _ToDateofLastYearThisMonth, sCustomerID);
            oDSLY = GetRawData("SecondaryActual", _FirstDayofLastYear, _FirstDayofThisYear, sCustomerID);

            oDSLDOrder = GetRawData("OrderActual", dLastDate, dFromDate, sCustomerID);
            oDSMTDOrder = GetRawData("OrderActual", _FirstDayofMonth, dToDate, sCustomerID);
            oDSSlabTargetAndActual = GetRawSlabTargetData("", _FirstDayofMonth, dToDate, sCustomerID);

            Data _oData;
            InnerList.Clear();

            foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow in oDSCustomer.BLLPerformanceAnalysis)
            {

                _oData = new Data();

                _oData.nRouteID = oBLLPerformanceAnalysisRow.RouteID;
                _oData.sRouteID = oBLLPerformanceAnalysisRow.RouteID.ToString();
                _oData.Route = oBLLPerformanceAnalysisRow.RouteName;
                _oData.RouteTypeID = oBLLPerformanceAnalysisRow.RouteTypeID;
                _oData.IsActive = oBLLPerformanceAnalysisRow.IsActive;
                _oData.IsActiveDB = oBLLPerformanceAnalysisRow.IsActiveDB;
                _oData.DSRMobileNo = oBLLPerformanceAnalysisRow.DSRMobileNo;
                _oData.DSRID = oBLLPerformanceAnalysisRow.DSRID;
                _oData.DSRName = oBLLPerformanceAnalysisRow.DSRName;
                _oData.CustomerID = oBLLPerformanceAnalysisRow.CustomerID;
                _oData.AreaID = oBLLPerformanceAnalysisRow.AreaID;
                _oData.TerritoryID = oBLLPerformanceAnalysisRow.TerritoryID;

                //-----------
                // Current Month Secondary Target
                DSBLLPerformanceAnalysis oDSCMSTFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRCMST = oDSCMST.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSCMSTFiltered.Merge(oDRCMST);
                oDSCMSTFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCMSTRow in oDSCMSTFiltered.BLLPerformanceAnalysis)
                {
                    _oData.CMSTValue = Convert.ToDouble(oDSCMSTRow.Amount);
                }

                // Current Month Secondary Achievement MTD
                DSBLLPerformanceAnalysis oDSCMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRCMSAMTD = oDSCMSAMTD.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSCMSAMTDFiltered.Merge(oDRCMSAMTD);
                oDSCMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCMSAMTDRow in oDSCMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.CMSAMTDValue = Convert.ToDouble(oDSCMSAMTDRow.Amount);
                }

                // Last Month Secondary Achievement MTD
                DSBLLPerformanceAnalysis oDSLMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLMSAMTD = oDSLMSAMTD.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSLMSAMTDFiltered.Merge(oDRLMSAMTD);
                oDSLMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMSAMTDRow in oDSLMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LMSAMTDValue = Convert.ToDouble(oDSLMSAMTDRow.Amount);
                }

                // Last Month Secondary Achievement
                DSBLLPerformanceAnalysis oDSLMSAFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLMSA = oDSLMSA.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSLMSAFiltered.Merge(oDRLMSA);
                oDSLMSAFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMSARow in oDSLMSAFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LMSAValue = Convert.ToDouble(oDSLMSARow.Amount);
                }

                // Last Year This Month Secondary Achievement
                DSBLLPerformanceAnalysis oDSLYCMSAFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLYCMSA = oDSLYCMSA.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSLYCMSAFiltered.Merge(oDRLYCMSA);
                oDSLYCMSAFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYCMSARow in oDSLYCMSAFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYCMSAValue = Convert.ToDouble(oDSLYCMSARow.Amount);
                }

                // Last Year This Month MTD Secondary Achievement
                DSBLLPerformanceAnalysis oDSLYCMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLYCMSAMTD = oDSLYCMSAMTD.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSLYCMSAMTDFiltered.Merge(oDRLYCMSAMTD);
                oDSLYCMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYCMSAMTDRow in oDSLYCMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYCMSAMTDValue = Convert.ToDouble(oDSLYCMSAMTDRow.Amount);
                }
                
                // Last Day Secondary Achievement
                DSBLLPerformanceAnalysis oDSLDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLD = oDSLD.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSLDFiltered.Merge(oDRLD);
                oDSLDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLDRow in oDSLDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LDValue = Convert.ToDouble(oDSLDRow.Amount);
                }
                // YTD Secondary Achievement
                DSBLLPerformanceAnalysis oDSYTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRYTD = oDSYTD.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSYTDFiltered.Merge(oDRYTD);
                oDSYTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSYTDRow in oDSYTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.YTDValue = Convert.ToDouble(oDSYTDRow.Amount);
                }
                // LYYTD Secondary Achievement
                DSBLLPerformanceAnalysis oDSLYYTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLYYTD = oDSLYYTD.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSLYYTDFiltered.Merge(oDRLYYTD);
                oDSLYYTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYYTDRow in oDSLYYTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYYTDValue = Convert.ToDouble(oDSLYYTDRow.Amount);
                }
                // LY Secondary Achievement
                DSBLLPerformanceAnalysis oDSLYFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLY = oDSLY.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "'");
                oDSLYFiltered.Merge(oDRLY);
                oDSLYFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYRow in oDSLYFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYValue = Convert.ToDouble(oDSLYRow.Amount);
                }
                // LD Order Value
                DSBLLPerformanceAnalysis oDSLDOrderFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLDOrder = oDSLDOrder.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "' ");
                oDSLDOrderFiltered.Merge(oDRLDOrder);
                oDSLDOrderFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLDORderRow in oDSLDOrderFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LDOrderValue = Convert.ToDouble(oDSLDORderRow.Amount);
                }

                // MTD Order Value
                DSBLLPerformanceAnalysis oDSMTDOrderFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRMTDOrder = oDSMTDOrder.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "' ");
                oDSMTDOrderFiltered.Merge(oDRMTDOrder);
                oDSMTDOrderFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSMTDORderRow in oDSMTDOrderFiltered.BLLPerformanceAnalysis)
                {
                    _oData.MTDOrderValue = Convert.ToDouble(oDSMTDORderRow.Amount);
                }

                //Slab Target and Actual
                DSBLLPerformanceAnalysis oDSMTDSlabFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRMTDSlab = oDSSlabTargetAndActual.BLLPerformanceAnalysis.Select(" RouteID= '" + oBLLPerformanceAnalysisRow.RouteID + "' ");
                oDSMTDSlabFiltered.Merge(oDRMTDSlab);
                oDSMTDSlabFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSMTDSlabRow in oDSMTDSlabFiltered.BLLPerformanceAnalysis)
                {
                    _oData.SlabTarget = Convert.ToDouble(oDSMTDSlabRow.SecondaryTarget);
                    _oData.MTDSlabActual = Convert.ToDouble(oDSMTDSlabRow.Amount);
                }
                InnerList.Add(_oData);
            }


        }
        public DSBLLPerformanceAnalysis GetRawData(string sType, DateTime dFromDate, DateTime dTodate, string sCustomerID)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (sType == "SecondaryActual")
            {
                cmd = DBController.Instance.GetCommand();

                sSQL = " Select RouteID, Sum(Value) as Value From " +
                "( " +
                "Select b.RouteID as RouteID, Sum(NetAmount) as Value from BLLSysDB.dbo.t_DMSProductTran a,  " +
                "BLLSysDB.dbo.t_DMSOutlet b, BLLSysDB.dbo.t_DMSUser c  " +
                "where a.OutletID=b.OutletID and a.DistributorID=c.DistributorID and Trandate >=ActivatedDate  "+
                "and TranTypeID=2 and Trandate between '" + dFromDate + "' and '" + dTodate + "' " +
                "and Trandate < '" + dTodate + "' and b.DistributorID='" + sCustomerID + "' Group by b.RouteID " +
                "UNION ALL " +
                "SElect b.RouteID, Value from " +
                "( " +
                "Select CustomerID, Sum(Amount) as Value from DWDB.dbo.t_SMSSecondarySales a, BLLSysDB.dbo.t_DMSUser b Where  " +
                "Trandate between '" + dFromDate + "' and '" + dTodate + "' " +
                "and Trandate < '" + dTodate + "' and b.DistributorID='" + sCustomerID + "' and ActivatedDate > Trandate and a.CustomerID=b.DistributorID Group by CustomerID " +
                "UNION ALL " +
                "Select CustomerID, Sum(Amount) as Value from DWDB.dbo.t_SMSSecondarySales Where  " +
                "Trandate between '" + dFromDate + "' and '" + dTodate + "' " +
                "and Trandate < '" + dTodate + "' and CustomerID='" + sCustomerID + "' and CustomerID Not IN (Select DistributorID From BLLSysDB.dbo.t_DMSUser Where IsActive=1)  " +
                "Group by CustomerID " +
                ") a, " +
                "(Select RouteID, DistributorID from BLLSysDB.dbo.t_DMSRoute Where RouteName='SMS Route' and DistributorID='" + sCustomerID + "')b " +
                "Where a.CustomerID=b.DistributorID " +
                ")x Group by RouteID ";


            }
            else if (sType == "OrderActual")
            {
                cmd = DBController.Instance.GetCommand();

                sSQL = " select RouteID, sum(OrderValue)as Value " +
                       " from BLLSysDB.dbo.t_SMSRouteOrder a, BLLSysDB.dbo.t_DMSRoute b  " +
                       " where orderDate between '" + dFromDate + "' and '" + dTodate + "' and orderDate < '" + dTodate + "' " +
                       " and a.RouteCode=b.RouteID and DistributorID='" + sCustomerID + "' " +
                       " group by RouteID ";
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
        public DSBLLPerformanceAnalysis GetRawSlabTargetData(string sType, DateTime dFromDate, DateTime dTodate, string sCustomerID)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();

            sSQL = " Select RouteID, Sum(SlabTGT) as Target, Sum(SLSalesTO) as Actual " +
                   " from  " +
                   " ( " +
                   " select OutletID, RetailName,Master.RouteId, RouteTypeID,DistributorID,SlabTGT,SLSalesTO " +
                   " from " +
                   " ( " +
                   " select OutletID,RetailName,RouteId, SlabTGT,SLSalesTO " +
                   " from " +
                   " ( " +
                   " select OutletID, sum(SlabTGT)As SlabTGT, sum(SLSalesTO)As SLSalesTO " +
                   " from " +
                   " ( " +

                   //" select OutletID,0 as SlabTGT, sum(Total)as SLSalesTO " +
                   //" from BLLSysDB.dbo.t_DMSASGWiseSales " +
                   //" where EntryDate between '" + dFromDate + "' and '" + dTodate + "' and EntryDate< '" + dTodate + "' " +
                   //" group by OutletID " +

                   //" select OutletID, 0 as SlabTGT, sum(NetAmount)as SLSalesTO  " +
                   //" from BLLSysDB.dbo.t_DMSKACSales  " +
                   //" where TranDate between '" + dFromDate + "' and '" + dTodate + "' and TranDate < '" + dTodate + "' " +
                   //" group by OutletID " +

                   " select OutletID, 0 as SlabTGT, sum(DeliveryAmount)as SLSalesTO  " +
                   " from BLLSysDB.dbo.t_DMSOrder a, t_DMSClusterOutlet b  " +
                  " where DeliveryDate between '" + dFromDate + "' and '" + dTodate + "' and DeliveryDate < '" + dTodate + "' and IsDelivered=1 and DeliveryAmount>0  " +
                  " and a.OutletID=b.RetailID and b.SlabOutlet=1 " +
                  " group by OutletID " +

                   " union all " +
                   " select OutletID, sum(slabValue)As SlabTGT, 0 as SLSalesTO " +
                   " from BLLSysDB.dbo.t_DMSSlabRegistration a, BLLSysDB.dbo.t_DMSSlabOffer b " +
                   " where Createdate between '" + dFromDate + "' and '" + dTodate + "' and Createdate < '" + dTodate + "' " +
                   " and a.SlabID=b.SlabID  " +
                   " group by OutletID " +
                   " )As SLTGT  group by OutletID   " +
                   " )As Total  " +
                   " left outer join BLLSysDB.dbo.t_DMSClusterOutlet as COut on Total.OutletID=Cout.RetailID " +
                   " where routeID >0 " +
                   " )As Master inner join BLLSysDB.dbo.t_DMSRoute as RT on Master.RouteId=RT.RouteID  where DistributorID=" + sCustomerID + " " +
                   " ) as x Group by RouteID ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.RouteID = Convert.ToInt32(reader["RouteID"]);
                    oBLLPerformanceAnalysisRow.SecondaryTarget = Convert.ToDouble(reader["Target"]);
                    oBLLPerformanceAnalysisRow.Amount = Convert.ToDouble(reader["Actual"]);

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
        public DSBLLPerformanceAnalysis GetRawDataTarget(DateTime dFromDate, DateTime dTodate, string sCustomerID)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis(); 

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

                cmd = DBController.Instance.GetCommand();
                {
                    sSQL = " select RouteID, SUM(TSMTGTTO)Amount from BLLSysDB.dbo.t_DMSTargetTO Where TGTDate Between '" + dFromDate + "' " +
                            " and '" + dTodate + "' and TGTDate < '" + dTodate + "' and DistributorID='" + sCustomerID + "' Group by RouteID";
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
        public DSBLLPerformanceAnalysis GetCustomerList(string sCustomerID)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();

            sSQL = " Select a.DSRID, DSRName, DSRMobileNo, b.IsActive as IsActiveDSR, RouteID, RouteName, RouteTypeID, " +
                   " a.IsActive as IsActiveRT, AreaID, TerritoryID from BLLSysDB.dbo.t_DMSRoute a, BLLSysDB.dbo.t_DMSDSR b, DWDB.dbo.t_CustomerDetails c " +
                   " Where a.DSRID=b.DSRID and a.DistributorID=c.CustomerID and c.CompanyName='BLL' and a.DistributorID='" + sCustomerID + "' " +
                   " Order by a.DSRID, RouteTypeID, RouteID ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    
                    oBLLPerformanceAnalysisRow.DSRID = reader["DSRID"].ToString();
                    oBLLPerformanceAnalysisRow.DSRName = reader["DSRName"].ToString();
                    oBLLPerformanceAnalysisRow.DSRMobileNo = reader["DSRMobileNo"].ToString();
                    oBLLPerformanceAnalysisRow.IsActive = reader["IsActiveDSR"].ToString();
                    oBLLPerformanceAnalysisRow.RouteID = Convert.ToInt32(reader["RouteID"]);
                    oBLLPerformanceAnalysisRow.RouteName = reader["RouteName"].ToString();
                    oBLLPerformanceAnalysisRow.RouteTypeID = reader["RouteTypeID"].ToString();
                    oBLLPerformanceAnalysisRow.IsActiveDB = reader["IsActiveRT"].ToString();
                    oBLLPerformanceAnalysisRow.AreaID = reader["AreaID"].ToString();
                    oBLLPerformanceAnalysisRow.TerritoryID = reader["TerritoryID"].ToString();
                    oBLLPerformanceAnalysisRow.CustomerID = sCustomerID;

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
            CalendarWeek oCalendarWeek = new CalendarWeek();
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();

            int nCount = 0;
            foreach (Data oData in this)
            {
                nCount = 1;
                double _Val = oData.CMSTValue + oData.CMSAMTDValue + oData.LMSAMTDValue + oData.LYCMSAMTDValue;
                if (oData.IsActive == "0")
                {
                    if (_Val == 0)
                    {
                        nCount = 0;
                    }
                }
                if (nCount != 0)
                {
                    _oData = new Data();
                    _oData.DSRID = oData.DSRID;
                    _oData.ShortName = oData.ShortName;
                    _oData.FullName = oData.FullName;
                    _oData.ResponsiblePerson = oData.ResponsiblePerson;
                    _oData.MobileNo = oData.MobileNo;
                    _oData.RouteTypeID = oData.RouteTypeID;
                    _oData.sRouteID = oData.sRouteID;
                    _oData.Type = oData.Type;
                    _oData.Value = oData.Value;
                    _oData.CustomerID = oData.CustomerID;
                    _oData.AreaID = oData.AreaID;
                    _oData.TerritoryID = oData.TerritoryID;
                    if (oData.IsActive == "1")
                        _oData.ActiveStatus = "Y";
                    else _oData.ActiveStatus = "N";

                    //_oData = new Data();
                    int nRemainingDay = oCalendarWeek.GetReamainingDateBLL();

                    _oData.CMSTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMSTValue));
                    _oData.CMSAMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMSAMTDValue));
                    _oData.LMSAMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMSAMTDValue));
                    _oData.LMSAValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMSAValue));
                    _oData.LYCMSAValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYCMSAValue));
                    _oData.LYCMSAMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYCMSAMTDValue));

                    _oData.LDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LDValue));
                    _oData.YTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.YTDValue));
                    _oData.LYYTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYYTDValue));
                    _oData.LYValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYValue));

                    _oData.LDOrderValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LDOrderValue));
                    _oData.MTDOrderValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.MTDOrderValue));
                    _oData.SlabTargetText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SlabTarget));
                    _oData.MTDSlabActualText = ExcludeDecimal(_oTELLib.TakaFormat(oData.MTDSlabActual));

                    double _balance = oData.CMSTValue - oData.CMSAMTDValue;
                    if (_balance > 0)
                    {
                        _oData.TodayTarget = ExcludeDecimal(_oTELLib.TakaFormat(Math.Round(_balance / nRemainingDay, 0)));
                    }
                    else
                    {
                        _oData.TodayTarget = "0";
                    }

                    _oData.MTDRetailValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMSAMTDValue - oData.MTDSlabActual));
                    //Performance

                    if (oData.CMSTValue > 0)
                    {
                        _oData.GSCMMTDPercText = Convert.ToString(Math.Round((oData.CMSAMTDValue / oData.CMSTValue) * 100));
                    }
                    else
                    {
                        _oData.GSCMMTDPercText = "0";
                    }

                    if (oData.LMSAMTDValue > 0)
                    {
                        _oData.GSLMMTDPercText = Convert.ToString(Math.Round((oData.CMSAMTDValue - oData.LMSAMTDValue) / oData.LMSAMTDValue * 100));
                    }
                    else
                    {
                        _oData.GSLMMTDPercText = "0";
                    }

                    if (oData.CMSTValue > 0)
                    {
                        _oData.GSLMFullPercText = Convert.ToString(Math.Round((oData.LMSAValue / oData.CMSTValue) * 100));
                    }
                    else
                    {
                        _oData.GSLMFullPercText = "0";
                    }
                    if (oData.CMSTValue > 0)
                    {
                        _oData.GSLYCMFullPercText = Convert.ToString(Math.Round((oData.LYCMSAValue / oData.CMSTValue) * 100));
                    }
                    else
                    {
                        _oData.GSLYCMFullPercText = "0";
                    }
                    if (oData.LYCMSAMTDValue > 0)
                    {
                        _oData.GSLYCMMTDPercText = Convert.ToString(Math.Round((oData.CMSAMTDValue - oData.LYCMSAMTDValue) / oData.LYCMSAMTDValue * 100));
                    }
                    else
                    {
                        _oData.GSLYCMMTDPercText = "0";
                    }
                    if (oData.LYYTDValue > 0)
                    {
                        _oData.GSYTDPercText = Convert.ToString(Math.Round((oData.YTDValue - oData.LYYTDValue) / oData.LYYTDValue * 100));
                    }
                    else
                    {
                        _oData.GSYTDPercText = "0";
                    }
                    if (oData.LDOrderValue > 0)
                    {
                        _oData.LDOrderPercText = Convert.ToString(Math.Round((oData.LDValue/oData.LDOrderValue) * 100));
                    }
                    else
                    {
                        _oData.LDOrderPercText = "0";
                    }
                    if (oData.MTDOrderValue > 0)
                    {
                        _oData.MTDDeliveryPercText = Convert.ToString(Math.Round((oData.CMSAMTDValue / oData.MTDOrderValue) * 100));
                    }
                    else
                    {
                        _oData.MTDDeliveryPercText = "0";
                    }
                    if (oData.SlabTarget > 0)
                    {
                        _oData.MTDSlabPercText = Convert.ToString(Math.Round((oData.MTDSlabActual / oData.SlabTarget) * 100));
                    }
                    else
                    {
                        _oData.MTDSlabPercText = "0";
                    }
                    if (oData.CMSAMTDValue > 0)
                    {
                        _oData.MTDSlabContributionPercText = Convert.ToString(Math.Round((oData.MTDSlabActual / oData.CMSAMTDValue) * 100));
                    }
                    else
                    {
                        _oData.MTDSlabContributionPercText = "0";
                    }
                    eList.Add(_oData);

                }

            }
            return eList;

        }
    }
}



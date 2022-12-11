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

public partial class jBLLSecondaryBeatSalesAnalysis : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            string sUser = c.Request.Form["UserName"].Trim();
            
            string sAndroidAppID = "";
            //string sUser = "hakim";
            string sDate = "";
            DateTime dDate = DateTime.Now.Date;
            if (c.Request.Form["Date"] != null)
            {
                sDate = c.Request.Form["Date"].Trim();
            }
            if (c.Request.Form["AndroidAppID"] != null)
            {
                sAndroidAppID = c.Request.Form["AndroidAppID"].Trim();
            }
            else
            {
                sAndroidAppID = Convert.ToString((int)Dictionary.AndroidAppID.CJ_Apps);
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

            Data _oDataTerritory = new Data();
            Data _oDataTerritoryNC = new Data();
            Data _oDataTerritoryECM = new Data();
            Data _oDataTerritoryIns = new Data();
            Data _oDataTerritoryTha = new Data();

            Data _oDataCustomer = new Data();
            Data _oDataCustomerNC = new Data();
            Data _oDataCustomerECM = new Data();
            Data _oDataCustomerIns = new Data();
            Data _oDataCustomerTha = new Data();


            int nCount = 0;

            DBController.Instance.OpenNewConnection();
            oDatas.GetData(dDate, sAndroidAppID, sUser);
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
                    _oDataNational.ShortName = "National";
                    _oDataNational.CustomerCode = "National";
                    _oDataNational.FullName = " HoB | ***";
                    _oDataNational.ResponsiblePerson = " HoB";
                    _oDataNational.MobileNo = "***";
                    _oDataNational.AreaID = "0";
                    _oDataNational.TerritoryID = "0";
                    _oDataNational.CustomerID = "0";
                    _oDataNational.RouteTypeID = "0";
                    _oDataNational.Type = "National";
                    _oDataNational.Value = "Success";
                    _oDataNational.IsActiveDB = "1";

                    //Non Cluster
                    _oDataNationalNC = new Data();
                    _oDatas.Add(_oDataNationalNC);
                    _oDataNationalNC.ShortName = "National";
                    _oDataNationalNC.CustomerCode = "National";
                    _oDataNationalNC.FullName = " HoB | ***";
                    _oDataNationalNC.ResponsiblePerson = " HoB";
                    _oDataNationalNC.MobileNo = "***";
                    _oDataNationalNC.AreaID = "0";
                    _oDataNationalNC.TerritoryID = "0";
                    _oDataNationalNC.CustomerID = "0";
                    _oDataNationalNC.RouteTypeID = "1";
                    _oDataNationalNC.Type = "National";
                    _oDataNationalNC.Value = "Success";
                    _oDataNationalNC.IsActiveDB = "1";

                    //ECM
                    _oDataNationalECM = new Data();
                    _oDatas.Add(_oDataNationalECM);
                    _oDataNationalECM.ShortName = "National";
                    _oDataNationalECM.CustomerCode = "National";
                    _oDataNationalECM.FullName = " HoB | ***";
                    _oDataNationalECM.ResponsiblePerson = " HoB";
                    _oDataNationalECM.MobileNo = "***";
                    _oDataNationalECM.AreaID = "0";
                    _oDataNationalECM.TerritoryID = "0";
                    _oDataNationalECM.CustomerID = "0";
                    _oDataNationalECM.RouteTypeID = "2";
                    _oDataNationalECM.Type = "National";
                    _oDataNationalECM.Value = "Success";
                    _oDataNationalECM.IsActiveDB = "1";

                    //Institution
                    _oDataNationalIns = new Data();
                    _oDatas.Add(_oDataNationalIns);
                    _oDataNationalIns.ShortName = "National";
                    _oDataNationalIns.CustomerCode = "National";
                    _oDataNationalIns.FullName = " HoB | ***";
                    _oDataNationalIns.ResponsiblePerson = " HoB";
                    _oDataNationalIns.MobileNo = "***";
                    _oDataNationalIns.AreaID = "0";
                    _oDataNationalIns.TerritoryID = "0";
                    _oDataNationalIns.CustomerID = "0";
                    _oDataNationalIns.RouteTypeID = "3";
                    _oDataNationalIns.Type = "National";
                    _oDataNationalIns.Value = "Success";
                    _oDataNationalIns.IsActiveDB = "1";

                    //Thana
                    _oDataNationalTha = new Data();
                    _oDatas.Add(_oDataNationalTha);
                    _oDataNationalTha.ShortName = "National";
                    _oDataNationalTha.CustomerCode = "National";
                    _oDataNationalTha.FullName = " HoB | ***";
                    _oDataNationalTha.ResponsiblePerson = " HoB";
                    _oDataNationalTha.MobileNo = "***";
                    _oDataNationalTha.AreaID = "0";
                    _oDataNationalTha.TerritoryID = "0";
                    _oDataNationalTha.CustomerID = "0";
                    _oDataNationalTha.RouteTypeID = "4";
                    _oDataNationalTha.Type = "National";
                    _oDataNationalTha.Value = "Success";
                    _oDataNationalTha.IsActiveDB = "1";

                    nCount++;
                    #endregion
                }
                if (_oDataArea.AreaName != oData.AreaName)
                {
                    #region Area
                    //All
                    _oDataArea = new Data();
                    _oDatas.Add(_oDataArea);
                    _oDataArea.AreaName = oData.AreaName;
                    _oDataArea.ShortName = oData.AreaName;
                    _oDataArea.CustomerCode = "Area";
                    _oDataArea.FullName = " ";
                    _oDataArea.ResponsiblePerson = " ";
                    _oDataArea.MobileNo = " ";
                    _oDataArea.AreaID = oData.AreaID;
                    _oDataArea.TerritoryID = oData.TerritoryID;
                    _oDataArea.CustomerID = oData.CustomerID;
                    _oDataArea.RouteTypeID = "0";
                    _oDataArea.Type = "Area";
                    _oDataArea.Value = "Success";
                    _oDataArea.IsActiveDB = "1";

                    //NC
                    _oDataAreaNC = new Data();
                    _oDatas.Add(_oDataAreaNC);
                    _oDataAreaNC.AreaName = oData.AreaName;
                    _oDataAreaNC.ShortName = oData.AreaName;
                    _oDataAreaNC.CustomerCode = "Area";
                    _oDataAreaNC.FullName = " ";
                    _oDataAreaNC.ResponsiblePerson = " ";
                    _oDataAreaNC.MobileNo = " ";
                    _oDataAreaNC.AreaID = oData.AreaID;
                    _oDataAreaNC.TerritoryID = oData.TerritoryID;
                    _oDataAreaNC.CustomerID = oData.CustomerID;
                    _oDataAreaNC.RouteTypeID = "1";
                    _oDataAreaNC.Type = "Area";
                    _oDataAreaNC.Value = "Success";
                    _oDataAreaNC.IsActiveDB = "1";

                    //ECM
                    _oDataAreaECM = new Data();
                    _oDatas.Add(_oDataAreaECM);
                    _oDataAreaECM.AreaName = oData.AreaName;
                    _oDataAreaECM.ShortName = oData.AreaName;
                    _oDataAreaECM.CustomerCode = "Area";
                    _oDataAreaECM.FullName = " ";
                    _oDataAreaECM.ResponsiblePerson = " ";
                    _oDataAreaECM.MobileNo = " ";
                    _oDataAreaECM.AreaID = oData.AreaID;
                    _oDataAreaECM.TerritoryID = oData.TerritoryID;
                    _oDataAreaECM.CustomerID = oData.CustomerID;
                    _oDataAreaECM.RouteTypeID = "2";
                    _oDataAreaECM.Type = "Area";
                    _oDataAreaECM.Value = "Success";
                    _oDataAreaECM.IsActiveDB = "1";

                    //Institute
                    _oDataAreaIns = new Data();
                    _oDatas.Add(_oDataAreaIns);
                    _oDataAreaIns.AreaName = oData.AreaName;
                    _oDataAreaIns.ShortName = oData.AreaName;
                    _oDataAreaIns.CustomerCode = "Area";
                    _oDataAreaIns.FullName = " ";
                    _oDataAreaIns.ResponsiblePerson = " ";
                    _oDataAreaIns.MobileNo = " ";
                    _oDataAreaIns.AreaID = oData.AreaID;
                    _oDataAreaIns.TerritoryID = oData.TerritoryID;
                    _oDataAreaIns.CustomerID = oData.CustomerID;
                    _oDataAreaIns.RouteTypeID = "3";
                    _oDataAreaIns.Type = "Area";
                    _oDataAreaIns.Value = "Success";
                    _oDataAreaIns.IsActiveDB = "1";

                    //Thana
                    _oDataAreaTha = new Data();
                    _oDatas.Add(_oDataAreaTha);
                    _oDataAreaTha.AreaName = oData.AreaName;
                    _oDataAreaTha.ShortName = oData.AreaName;
                    _oDataAreaTha.CustomerCode = "Area";
                    _oDataAreaTha.FullName = " ";
                    _oDataAreaTha.ResponsiblePerson = " ";
                    _oDataAreaTha.MobileNo = " ";
                    _oDataAreaTha.AreaID = oData.AreaID;
                    _oDataAreaTha.TerritoryID = oData.TerritoryID;
                    _oDataAreaTha.CustomerID = oData.CustomerID;
                    _oDataAreaTha.RouteTypeID = "4";
                    _oDataAreaTha.Type = "Area";
                    _oDataAreaTha.Value = "Success";
                    _oDataAreaTha.IsActiveDB = "1";

                    #endregion
                }
                if (_oDataTerritory.TerritoryName != oData.TerritoryName)
                {
                    #region Territory
                    //All
                    _oDataTerritory = new Data();
                    _oDatas.Add(_oDataTerritory);
                    _oDataTerritory.TerritoryName = oData.TerritoryName;
                    _oDataTerritory.ShortName = oData.TerritoryName;
                    _oDataTerritory.CustomerCode = "Territory";
                    _oDataTerritory.FullName = " TSM: " + oData.TSMName + " | " + oData.TSMMobileNo;
                    _oDataTerritory.ResponsiblePerson = " TSM: " + oData.TSMName;
                    _oDataTerritory.MobileNo = oData.TSMMobileNo;
                    _oDataTerritory.AreaID = oData.AreaID;
                    _oDataTerritory.TerritoryID = oData.TerritoryID;
                    _oDataTerritory.CustomerID = oData.CustomerID;
                    _oDataTerritory.RouteTypeID = "0";
                    _oDataTerritory.Type = "Territory";
                    _oDataTerritory.Value = "Success";
                    _oDataTerritory.IsActiveDB = "1";

                    //Non Cluster
                    _oDataTerritoryNC = new Data();
                    _oDatas.Add(_oDataTerritoryNC);
                    _oDataTerritoryNC.TerritoryName = oData.TerritoryName;
                    _oDataTerritoryNC.ShortName = oData.TerritoryName;
                    _oDataTerritoryNC.CustomerCode = "Territory";
                    _oDataTerritoryNC.FullName = " TSM: " + oData.TSMName + " | " + oData.TSMMobileNo;
                    _oDataTerritoryNC.ResponsiblePerson = " TSM: " + oData.TSMName;
                    _oDataTerritoryNC.MobileNo = oData.TSMMobileNo;
                    _oDataTerritoryNC.AreaID = oData.AreaID;
                    _oDataTerritoryNC.TerritoryID = oData.TerritoryID;
                    _oDataTerritoryNC.CustomerID = oData.CustomerID;
                    _oDataTerritoryNC.RouteTypeID = "1";
                    _oDataTerritoryNC.Type = "Territory";
                    _oDataTerritoryNC.Value = "Success";
                    _oDataTerritoryNC.IsActiveDB = "1";

                    //ECM
                    _oDataTerritoryECM = new Data();
                    _oDatas.Add(_oDataTerritoryECM);
                    _oDataTerritoryECM.TerritoryName = oData.TerritoryName;
                    _oDataTerritoryECM.ShortName = oData.TerritoryName;
                    _oDataTerritoryECM.CustomerCode = "Territory";
                    _oDataTerritoryECM.FullName = " TSM: " + oData.TSMName + " | " + oData.TSMMobileNo;
                    _oDataTerritoryECM.ResponsiblePerson = " TSM: " + oData.TSMName;
                    _oDataTerritoryECM.MobileNo = oData.TSMMobileNo;
                    _oDataTerritoryECM.AreaID = oData.AreaID;
                    _oDataTerritoryECM.TerritoryID = oData.TerritoryID;
                    _oDataTerritoryECM.CustomerID = oData.CustomerID;
                    _oDataTerritoryECM.RouteTypeID = "2";
                    _oDataTerritoryECM.Type = "Territory";
                    _oDataTerritoryECM.Value = "Success";
                    _oDataTerritoryECM.IsActiveDB = "1";

                    //Institution
                    _oDataTerritoryIns = new Data();
                    _oDatas.Add(_oDataTerritoryIns);
                    _oDataTerritoryIns.TerritoryName = oData.TerritoryName;
                    _oDataTerritoryIns.ShortName = oData.TerritoryName;
                    _oDataTerritoryIns.CustomerCode = "Territory";
                    _oDataTerritoryIns.FullName = " TSM: " + oData.TSMName + " | " + oData.TSMMobileNo;
                    _oDataTerritoryIns.ResponsiblePerson = " TSM: " + oData.TSMName;
                    _oDataTerritoryIns.MobileNo = oData.TSMMobileNo;
                    _oDataTerritoryIns.AreaID = oData.AreaID;
                    _oDataTerritoryIns.TerritoryID = oData.TerritoryID;
                    _oDataTerritoryIns.CustomerID = oData.CustomerID;
                    _oDataTerritoryIns.RouteTypeID = "3";
                    _oDataTerritoryIns.Type = "Territory";
                    _oDataTerritoryIns.Value = "Success";
                    _oDataTerritoryIns.IsActiveDB = "1";

                    //Thana
                    _oDataTerritoryTha = new Data();
                    _oDatas.Add(_oDataTerritoryTha);
                    _oDataTerritoryTha.TerritoryName = oData.TerritoryName;
                    _oDataTerritoryTha.ShortName = oData.TerritoryName;
                    _oDataTerritoryTha.CustomerCode = "Territory";
                    _oDataTerritoryTha.FullName = " TSM: " + oData.TSMName + " | " + oData.TSMMobileNo;
                    _oDataTerritoryTha.ResponsiblePerson = " TSM: " + oData.TSMName;
                    _oDataTerritoryTha.MobileNo = oData.TSMMobileNo;
                    _oDataTerritoryTha.AreaID = oData.AreaID;
                    _oDataTerritoryTha.TerritoryID = oData.TerritoryID;
                    _oDataTerritoryTha.CustomerID = oData.CustomerID;
                    _oDataTerritoryTha.RouteTypeID = "4";
                    _oDataTerritoryTha.Type = "Territory";
                    _oDataTerritoryTha.Value = "Success";
                    _oDataTerritoryTha.IsActiveDB = "1";

                    #endregion
                }

                if (_oDataCustomer.CustomerID != oData.CustomerID)
                {
                    #region Customer
                    //All
                    _oDataCustomer = new Data();
                    _oDatas.Add(_oDataCustomer);
                    _oDataCustomer.CustomerID = oData.CustomerID;
                    _oDataCustomer.ShortName = oData.ShortName;
                    _oDataCustomer.CustomerCode = oData.CustomerCode;
                    _oDataCustomer.FullName = " TSO: " + oData.TSOName + " | " + oData.TSOMobileNo;
                    _oDataCustomer.ResponsiblePerson = " TSO: " + oData.TSOName;
                    _oDataCustomer.MobileNo = oData.TSOMobileNo;
                    _oDataCustomer.AreaID = oData.AreaID;
                    _oDataCustomer.TerritoryID = oData.TerritoryID;
                    _oDataCustomer.CustomerID = oData.CustomerID;
                    _oDataCustomer.RouteTypeID = "0";
                    _oDataCustomer.Type = "Customer";
                    _oDataCustomer.Value = "Success";
                    _oDataCustomer.IsActiveDB = oData.IsActiveDB;

                    //Non Cluster
                    _oDataCustomerNC = new Data();
                    _oDatas.Add(_oDataCustomerNC);
                    _oDataCustomerNC.CustomerID = oData.CustomerID;
                    _oDataCustomerNC.ShortName = oData.ShortName;
                    _oDataCustomerNC.CustomerCode = oData.CustomerCode;
                    _oDataCustomerNC.FullName = " TSO: " + oData.TSOName + " | " + oData.TSOMobileNo;
                    _oDataCustomerNC.ResponsiblePerson = " TSO: " + oData.TSOName;
                    _oDataCustomerNC.MobileNo = oData.TSOMobileNo;
                    _oDataCustomerNC.AreaID = oData.AreaID;
                    _oDataCustomerNC.TerritoryID = oData.TerritoryID;
                    _oDataCustomerNC.CustomerID = oData.CustomerID;
                    _oDataCustomerNC.RouteTypeID = "1";
                    _oDataCustomerNC.Type = "Customer";
                    _oDataCustomerNC.Value = "Success";
                    _oDataCustomerNC.IsActiveDB = oData.IsActiveDB;

                    //ECM
                    _oDataCustomerECM = new Data();
                    _oDatas.Add(_oDataCustomerECM);
                    _oDataCustomerECM.CustomerID = oData.CustomerID;
                    _oDataCustomerECM.ShortName = oData.ShortName;
                    _oDataCustomerECM.CustomerCode = oData.CustomerCode;
                    _oDataCustomerECM.FullName = " TSO: " + oData.TSOName + " | " + oData.TSOMobileNo;
                    _oDataCustomerECM.ResponsiblePerson = " TSO: " + oData.TSOName;
                    _oDataCustomerECM.MobileNo = oData.TSOMobileNo;
                    _oDataCustomerECM.AreaID = oData.AreaID;
                    _oDataCustomerECM.TerritoryID = oData.TerritoryID;
                    _oDataCustomerECM.CustomerID = oData.CustomerID;
                    _oDataCustomerECM.RouteTypeID = "2";
                    _oDataCustomerECM.Type = "Customer";
                    _oDataCustomerECM.Value = "Success";
                    _oDataCustomerECM.IsActiveDB = oData.IsActiveDB;

                    //Institition
                    _oDataCustomerIns = new Data();
                    _oDatas.Add(_oDataCustomerIns);
                    _oDataCustomerIns.CustomerID = oData.CustomerID;
                    _oDataCustomerIns.ShortName = oData.ShortName;
                    _oDataCustomerIns.CustomerCode = oData.CustomerCode;
                    _oDataCustomerIns.FullName = " TSO: " + oData.TSOName + " | " + oData.TSOMobileNo;
                    _oDataCustomerIns.ResponsiblePerson = " TSO: " + oData.TSOName;
                    _oDataCustomerIns.MobileNo = oData.TSOMobileNo;
                    _oDataCustomerIns.AreaID = oData.AreaID;
                    _oDataCustomerIns.TerritoryID = oData.TerritoryID;
                    _oDataCustomerIns.CustomerID = oData.CustomerID;
                    _oDataCustomerIns.RouteTypeID = "3";
                    _oDataCustomerIns.Type = "Customer";
                    _oDataCustomerIns.Value = "Success";
                    _oDataCustomerIns.IsActiveDB = oData.IsActiveDB;

                    //Thana
                    _oDataCustomerTha = new Data();
                    _oDatas.Add(_oDataCustomerTha);
                    _oDataCustomerTha.CustomerID = oData.CustomerID;
                    _oDataCustomerTha.ShortName = oData.ShortName;
                    _oDataCustomerTha.CustomerCode = oData.CustomerCode;
                    _oDataCustomerTha.FullName = " TSO: " + oData.TSOName + " | " + oData.TSOMobileNo;
                    _oDataCustomerTha.ResponsiblePerson = " TSO: " + oData.TSOName;
                    _oDataCustomerTha.MobileNo = oData.TSOMobileNo;
                    _oDataCustomerTha.AreaID = oData.AreaID;
                    _oDataCustomerTha.TerritoryID = oData.TerritoryID;
                    _oDataCustomerTha.CustomerID = oData.CustomerID;
                    _oDataCustomerTha.RouteTypeID = "4";
                    _oDataCustomerTha.Type = "Customer";
                    _oDataCustomerTha.Value = "Success";
                    _oDataCustomerTha.IsActiveDB = oData.IsActiveDB;

                    #endregion
                }

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

                #region Area
                
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

                #region Territory

                _oDataTerritory.CMSTValue = _oDataTerritory.CMSTValue + oData.CMSTValue;
                _oDataTerritory.CMSAMTDValue = _oDataTerritory.CMSAMTDValue + oData.CMSAMTDValue;
                _oDataTerritory.LMSAMTDValue = _oDataTerritory.LMSAMTDValue + oData.LMSAMTDValue;
                _oDataTerritory.LMSAValue = _oDataTerritory.LMSAValue + oData.LMSAValue;
                _oDataTerritory.LYCMSAValue = _oDataTerritory.LYCMSAValue + oData.LYCMSAValue;
                _oDataTerritory.LYCMSAMTDValue = _oDataTerritory.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                _oDataTerritory.LDValue = _oDataTerritory.LDValue + oData.LDValue;
                _oDataTerritory.YTDValue = _oDataTerritory.YTDValue + oData.YTDValue;
                _oDataTerritory.LYYTDValue = _oDataTerritory.LYYTDValue + oData.LYYTDValue;
                _oDataTerritory.LYValue = _oDataTerritory.LYValue + oData.LYValue;
                _oDataTerritory.LDOrderValue = _oDataTerritory.LDOrderValue + oData.LDOrderValue;
                _oDataTerritory.MTDOrderValue = _oDataTerritory.MTDOrderValue + oData.MTDOrderValue;
                _oDataTerritory.SlabTarget = _oDataTerritory.SlabTarget + oData.SlabTarget;
                _oDataTerritory.MTDSlabActual = _oDataTerritory.MTDSlabActual + oData.MTDSlabActual;
                _oDataTerritory.TodayTarget = _oDataTerritory.TodayTarget + oData.TodayTarget;

                if (oData.RouteTypeID == "1")
                {
                    _oDataTerritoryNC.CMSTValue = _oDataTerritoryNC.CMSTValue + oData.CMSTValue;
                    _oDataTerritoryNC.CMSAMTDValue = _oDataTerritoryNC.CMSAMTDValue + oData.CMSAMTDValue;
                    _oDataTerritoryNC.LMSAMTDValue = _oDataTerritoryNC.LMSAMTDValue + oData.LMSAMTDValue;
                    _oDataTerritoryNC.LMSAValue = _oDataTerritoryNC.LMSAValue + oData.LMSAValue;
                    _oDataTerritoryNC.LYCMSAValue = _oDataTerritoryNC.LYCMSAValue + oData.LYCMSAValue;
                    _oDataTerritoryNC.LYCMSAMTDValue = _oDataTerritoryNC.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                    _oDataTerritoryNC.LDValue = _oDataTerritoryNC.LDValue + oData.LDValue;
                    _oDataTerritoryNC.YTDValue = _oDataTerritoryNC.YTDValue + oData.YTDValue;
                    _oDataTerritoryNC.LYYTDValue = _oDataTerritoryNC.LYYTDValue + oData.LYYTDValue;
                    _oDataTerritoryNC.LYValue = _oDataTerritoryNC.LYValue + oData.LYValue;
                    _oDataTerritoryNC.LDOrderValue = _oDataTerritoryNC.LDOrderValue + oData.LDOrderValue;
                    _oDataTerritoryNC.MTDOrderValue = _oDataTerritoryNC.MTDOrderValue + oData.MTDOrderValue;
                    _oDataTerritoryNC.SlabTarget = _oDataTerritoryNC.SlabTarget + oData.SlabTarget;
                    _oDataTerritoryNC.MTDSlabActual = _oDataTerritoryNC.MTDSlabActual + oData.MTDSlabActual;
                    _oDataTerritoryNC.TodayTarget = _oDataTerritoryNC.TodayTarget + oData.TodayTarget;
                }
                else if (oData.RouteTypeID == "2")
                {
                    _oDataTerritoryECM.CMSTValue = _oDataTerritoryECM.CMSTValue + oData.CMSTValue;
                    _oDataTerritoryECM.CMSAMTDValue = _oDataTerritoryECM.CMSAMTDValue + oData.CMSAMTDValue;
                    _oDataTerritoryECM.LMSAMTDValue = _oDataTerritoryECM.LMSAMTDValue + oData.LMSAMTDValue;
                    _oDataTerritoryECM.LMSAValue = _oDataTerritoryECM.LMSAValue + oData.LMSAValue;
                    _oDataTerritoryECM.LYCMSAValue = _oDataTerritoryECM.LYCMSAValue + oData.LYCMSAValue;
                    _oDataTerritoryECM.LYCMSAMTDValue = _oDataTerritoryECM.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                    _oDataTerritoryECM.LDValue = _oDataTerritoryECM.LDValue + oData.LDValue;
                    _oDataTerritoryECM.YTDValue = _oDataTerritoryECM.YTDValue + oData.YTDValue;
                    _oDataTerritoryECM.LYYTDValue = _oDataTerritoryECM.LYYTDValue + oData.LYYTDValue;
                    _oDataTerritoryECM.LYValue = _oDataTerritoryECM.LYValue + oData.LYValue;
                    _oDataTerritoryECM.LDOrderValue = _oDataTerritoryECM.LDOrderValue + oData.LDOrderValue;
                    _oDataTerritoryECM.MTDOrderValue = _oDataTerritoryECM.MTDOrderValue + oData.MTDOrderValue;
                    _oDataTerritoryECM.SlabTarget = _oDataTerritoryECM.SlabTarget + oData.SlabTarget;
                    _oDataTerritoryECM.MTDSlabActual = _oDataTerritoryECM.MTDSlabActual + oData.MTDSlabActual;
                    _oDataTerritoryECM.TodayTarget = _oDataTerritoryECM.TodayTarget + oData.TodayTarget;
                }
                else if (oData.RouteTypeID == "3")
                {
                    _oDataTerritoryIns.CMSTValue = _oDataTerritoryIns.CMSTValue + oData.CMSTValue;
                    _oDataTerritoryIns.CMSAMTDValue = _oDataTerritoryIns.CMSAMTDValue + oData.CMSAMTDValue;
                    _oDataTerritoryIns.LMSAMTDValue = _oDataTerritoryIns.LMSAMTDValue + oData.LMSAMTDValue;
                    _oDataTerritoryIns.LMSAValue = _oDataTerritoryIns.LMSAValue + oData.LMSAValue;
                    _oDataTerritoryIns.LYCMSAValue = _oDataTerritoryIns.LYCMSAValue + oData.LYCMSAValue;
                    _oDataTerritoryIns.LYCMSAMTDValue = _oDataTerritoryIns.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                    _oDataTerritoryIns.LDValue = _oDataTerritoryIns.LDValue + oData.LDValue;
                    _oDataTerritoryIns.YTDValue = _oDataTerritoryIns.YTDValue + oData.YTDValue;
                    _oDataTerritoryIns.LYYTDValue = _oDataTerritoryIns.LYYTDValue + oData.LYYTDValue;
                    _oDataTerritoryIns.LYValue = _oDataTerritoryIns.LYValue + oData.LYValue;
                    _oDataTerritoryIns.LDOrderValue = _oDataTerritoryIns.LDOrderValue + oData.LDOrderValue;
                    _oDataTerritoryIns.MTDOrderValue = _oDataTerritoryIns.MTDOrderValue + oData.MTDOrderValue;
                    _oDataTerritoryIns.SlabTarget = _oDataTerritoryIns.SlabTarget + oData.SlabTarget;
                    _oDataTerritoryIns.MTDSlabActual = _oDataTerritoryIns.MTDSlabActual + oData.MTDSlabActual;
                    _oDataTerritoryIns.TodayTarget = _oDataTerritoryIns.TodayTarget + oData.TodayTarget;
                }
                else if (oData.RouteTypeID == "4")
                {
                    _oDataTerritoryTha.CMSTValue = _oDataTerritoryTha.CMSTValue + oData.CMSTValue;
                    _oDataTerritoryTha.CMSAMTDValue = _oDataTerritoryTha.CMSAMTDValue + oData.CMSAMTDValue;
                    _oDataTerritoryTha.LMSAMTDValue = _oDataTerritoryTha.LMSAMTDValue + oData.LMSAMTDValue;
                    _oDataTerritoryTha.LMSAValue = _oDataTerritoryTha.LMSAValue + oData.LMSAValue;
                    _oDataTerritoryTha.LYCMSAValue = _oDataTerritoryTha.LYCMSAValue + oData.LYCMSAValue;
                    _oDataTerritoryTha.LYCMSAMTDValue = _oDataTerritoryTha.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                    _oDataTerritoryTha.LDValue = _oDataTerritoryTha.LDValue + oData.LDValue;
                    _oDataTerritoryTha.YTDValue = _oDataTerritoryTha.YTDValue + oData.YTDValue;
                    _oDataTerritoryTha.LYYTDValue = _oDataTerritoryTha.LYYTDValue + oData.LYYTDValue;
                    _oDataTerritoryTha.LYValue = _oDataTerritoryTha.LYValue + oData.LYValue;
                    _oDataTerritoryTha.LDOrderValue = _oDataTerritoryTha.LDOrderValue + oData.LDOrderValue;
                    _oDataTerritoryTha.MTDOrderValue = _oDataTerritoryTha.MTDOrderValue + oData.MTDOrderValue;
                    _oDataTerritoryTha.SlabTarget = _oDataTerritoryTha.SlabTarget + oData.SlabTarget;
                    _oDataTerritoryTha.MTDSlabActual = _oDataTerritoryTha.MTDSlabActual + oData.MTDSlabActual;
                    _oDataTerritoryTha.TodayTarget = _oDataTerritoryTha.TodayTarget + oData.TodayTarget;
                }

                #endregion 
                
                #region Customer

                _oDataCustomer.CMSTValue = _oDataCustomer.CMSTValue + oData.CMSTValue;
                _oDataCustomer.CMSAMTDValue = _oDataCustomer.CMSAMTDValue + oData.CMSAMTDValue;
                _oDataCustomer.LMSAMTDValue = _oDataCustomer.LMSAMTDValue + oData.LMSAMTDValue;
                _oDataCustomer.LMSAValue = _oDataCustomer.LMSAValue + oData.LMSAValue;
                _oDataCustomer.LYCMSAValue = _oDataCustomer.LYCMSAValue + oData.LYCMSAValue;
                _oDataCustomer.LYCMSAMTDValue = _oDataCustomer.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                _oDataCustomer.LDValue = _oDataCustomer.LDValue + oData.LDValue;
                _oDataCustomer.YTDValue = _oDataCustomer.YTDValue + oData.YTDValue;
                _oDataCustomer.LYYTDValue = _oDataCustomer.LYYTDValue + oData.LYYTDValue;
                _oDataCustomer.LYValue = _oDataCustomer.LYValue + oData.LYValue;
                _oDataCustomer.LDOrderValue = _oDataCustomer.LDOrderValue + oData.LDOrderValue;
                _oDataCustomer.MTDOrderValue = _oDataCustomer.MTDOrderValue + oData.MTDOrderValue;
                _oDataCustomer.SlabTarget = _oDataCustomer.SlabTarget + oData.SlabTarget;
                _oDataCustomer.MTDSlabActual = _oDataCustomer.MTDSlabActual + oData.MTDSlabActual;
                _oDataCustomer.TodayTarget = _oDataCustomer.TodayTarget + oData.TodayTarget;

                if (oData.RouteTypeID == "1")
                {
                    _oDataCustomerNC.CMSTValue = _oDataCustomerNC.CMSTValue + oData.CMSTValue;
                    _oDataCustomerNC.CMSAMTDValue = _oDataCustomerNC.CMSAMTDValue + oData.CMSAMTDValue;
                    _oDataCustomerNC.LMSAMTDValue = _oDataCustomerNC.LMSAMTDValue + oData.LMSAMTDValue;
                    _oDataCustomerNC.LMSAValue = _oDataCustomerNC.LMSAValue + oData.LMSAValue;
                    _oDataCustomerNC.LYCMSAValue = _oDataCustomerNC.LYCMSAValue + oData.LYCMSAValue;
                    _oDataCustomerNC.LYCMSAMTDValue = _oDataCustomerNC.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                    _oDataCustomerNC.LDValue = _oDataCustomerNC.LDValue + oData.LDValue;
                    _oDataCustomerNC.YTDValue = _oDataCustomerNC.YTDValue + oData.YTDValue;
                    _oDataCustomerNC.LYYTDValue = _oDataCustomerNC.LYYTDValue + oData.LYYTDValue;
                    _oDataCustomerNC.LYValue = _oDataCustomerNC.LYValue + oData.LYValue;
                    _oDataCustomerNC.LDOrderValue = _oDataCustomerNC.LDOrderValue + oData.LDOrderValue;
                    _oDataCustomerNC.MTDOrderValue = _oDataCustomerNC.MTDOrderValue + oData.MTDOrderValue;
                    _oDataCustomerNC.SlabTarget = _oDataCustomerNC.SlabTarget + oData.SlabTarget;
                    _oDataCustomerNC.MTDSlabActual = _oDataCustomerNC.MTDSlabActual + oData.MTDSlabActual;
                    _oDataCustomerNC.TodayTarget = _oDataCustomerNC.TodayTarget + oData.TodayTarget;
                }
                else if (oData.RouteTypeID == "2")
                {
                    _oDataCustomerECM.CMSTValue = _oDataCustomerECM.CMSTValue + oData.CMSTValue;
                    _oDataCustomerECM.CMSAMTDValue = _oDataCustomerECM.CMSAMTDValue + oData.CMSAMTDValue;
                    _oDataCustomerECM.LMSAMTDValue = _oDataCustomerECM.LMSAMTDValue + oData.LMSAMTDValue;
                    _oDataCustomerECM.LMSAValue = _oDataCustomerECM.LMSAValue + oData.LMSAValue;
                    _oDataCustomerECM.LYCMSAValue = _oDataCustomerECM.LYCMSAValue + oData.LYCMSAValue;
                    _oDataCustomerECM.LYCMSAMTDValue = _oDataCustomerECM.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                    _oDataCustomerECM.LDValue = _oDataCustomerECM.LDValue + oData.LDValue;
                    _oDataCustomerECM.YTDValue = _oDataCustomerECM.YTDValue + oData.YTDValue;
                    _oDataCustomerECM.LYYTDValue = _oDataCustomerECM.LYYTDValue + oData.LYYTDValue;
                    _oDataCustomerECM.LYValue = _oDataCustomerECM.LYValue + oData.LYValue;
                    _oDataCustomerECM.LDOrderValue = _oDataCustomerECM.LDOrderValue + oData.LDOrderValue;
                    _oDataCustomerECM.MTDOrderValue = _oDataCustomerECM.MTDOrderValue + oData.MTDOrderValue;
                    _oDataCustomerECM.SlabTarget = _oDataCustomerECM.SlabTarget + oData.SlabTarget;
                    _oDataCustomerECM.MTDSlabActual = _oDataCustomerECM.MTDSlabActual + oData.MTDSlabActual;
                    _oDataCustomerECM.TodayTarget = _oDataCustomerECM.TodayTarget + oData.TodayTarget;
                }
                else if (oData.RouteTypeID == "3")
                {
                    _oDataCustomerIns.CMSTValue = _oDataCustomerIns.CMSTValue + oData.CMSTValue;
                    _oDataCustomerIns.CMSAMTDValue = _oDataCustomerIns.CMSAMTDValue + oData.CMSAMTDValue;
                    _oDataCustomerIns.LMSAMTDValue = _oDataCustomerIns.LMSAMTDValue + oData.LMSAMTDValue;
                    _oDataCustomerIns.LMSAValue = _oDataCustomerIns.LMSAValue + oData.LMSAValue;
                    _oDataCustomerIns.LYCMSAValue = _oDataCustomerIns.LYCMSAValue + oData.LYCMSAValue;
                    _oDataCustomerIns.LYCMSAMTDValue = _oDataCustomerIns.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                    _oDataCustomerIns.LDValue = _oDataCustomerIns.LDValue + oData.LDValue;
                    _oDataCustomerIns.YTDValue = _oDataCustomerIns.YTDValue + oData.YTDValue;
                    _oDataCustomerIns.LYYTDValue = _oDataCustomerIns.LYYTDValue + oData.LYYTDValue;
                    _oDataCustomerIns.LYValue = _oDataCustomerIns.LYValue + oData.LYValue;
                    _oDataCustomerIns.LDOrderValue = _oDataCustomerIns.LDOrderValue + oData.LDOrderValue;
                    _oDataCustomerIns.MTDOrderValue = _oDataCustomerIns.MTDOrderValue + oData.MTDOrderValue;
                    _oDataCustomerIns.SlabTarget = _oDataCustomerIns.SlabTarget + oData.SlabTarget;
                    _oDataCustomerIns.MTDSlabActual = _oDataCustomerIns.MTDSlabActual + oData.MTDSlabActual;
                    _oDataCustomerIns.TodayTarget = _oDataCustomerIns.TodayTarget + oData.TodayTarget;
                }
                else if (oData.RouteTypeID == "4")
                {
                    _oDataCustomerTha.CMSTValue = _oDataCustomerTha.CMSTValue + oData.CMSTValue;
                    _oDataCustomerTha.CMSAMTDValue = _oDataCustomerTha.CMSAMTDValue + oData.CMSAMTDValue;
                    _oDataCustomerTha.LMSAMTDValue = _oDataCustomerTha.LMSAMTDValue + oData.LMSAMTDValue;
                    _oDataCustomerTha.LMSAValue = _oDataCustomerTha.LMSAValue + oData.LMSAValue;
                    _oDataCustomerTha.LYCMSAValue = _oDataCustomerTha.LYCMSAValue + oData.LYCMSAValue;
                    _oDataCustomerTha.LYCMSAMTDValue = _oDataCustomerTha.LYCMSAMTDValue + oData.LYCMSAMTDValue;
                    _oDataCustomerTha.LDValue = _oDataCustomerTha.LDValue + oData.LDValue;
                    _oDataCustomerTha.YTDValue = _oDataCustomerTha.YTDValue + oData.YTDValue;
                    _oDataCustomerTha.LYYTDValue = _oDataCustomerTha.LYYTDValue + oData.LYYTDValue;
                    _oDataCustomerTha.LYValue = _oDataCustomerTha.LYValue + oData.LYValue;
                    _oDataCustomerTha.LDOrderValue = _oDataCustomerTha.LDOrderValue + oData.LDOrderValue;
                    _oDataCustomerTha.MTDOrderValue = _oDataCustomerTha.MTDOrderValue + oData.MTDOrderValue;
                    _oDataCustomerTha.SlabTarget = _oDataCustomerTha.SlabTarget + oData.SlabTarget;
                    _oDataCustomerTha.MTDSlabActual = _oDataCustomerTha.MTDSlabActual + oData.MTDSlabActual;
                    _oDataCustomerTha.TodayTarget = _oDataCustomerTha.TodayTarget + oData.TodayTarget;
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
            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(DayOfMonth, TotalDayOfMonth, DayOfYear, TotalDayOfYear), Formatting.Indented);
            Response.Write(sOutput.ToString());

        }
    } 
    public class Data
    {
        // C = Current, M = Month, P=Primary, T=Target, L=Last, Y=Year, A=Actual

        public string AreaName;
        public string AreaID;
        public string TerritoryName;
        public string TerritoryID;
        public string ShortName;
        public string FullName;
        public string CustomerID;
        public string CustomerCode;
        public string RouteTypeID;
        public string Type;
        public string Value;
        public string IsActiveDB;
        public string ActiveStatus;
        public string TSMMobileNo;
        public string TSMName;
        public string TSOMobileNo;
        public string TSOName;
        public string ResponsiblePerson;
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
        public string GSYTDPercText;

        public string LDOrderPercText;
        public string MTDDeliveryPercText;
        public string MTDSlabPercText;
        public string MTDSlabContributionPercText;
        public string TodayTarget;
        public string MTDRetailValueText;

        public string DayPassing;


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
        
        public void GetData(DateTime dDate, string sAndroidAppID, string sUserName)
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


            oDSCustomer = GetCustomerList(sAndroidAppID, sUserName);
            oDSCMST = GetRawDataTarget("SecondaryTarget",_FirstDayofMonth, _FirstDayofNextMonth);
            oDSCMSAMTD = GetRawData("SecondaryActual", _FirstDayofMonth, dToDate);
            oDSLMSAMTD = GetRawData("SecondaryActual", _FirstDayofLastMonth, _ToDateOfLastMonth);
            oDSLMSA = GetRawData("SecondaryActual", _FirstDayofLastMonth, _FirstDayofMonth);
            oDSLYCMSA = GetRawData("SecondaryActual", _FristDayofLastYearThisMonth, _FristDayofLastYearNextMonth);
            oDSLYCMSAMTD = GetRawData("SecondaryActual", _FristDayofLastYearThisMonth, _ToDateofLastYearThisMonth);

            oDSLD = GetRawData("SecondaryActual", dLastDate, dFromDate);
            oDSYTD = GetRawData("SecondaryActual", _FirstDayofThisYear, dToDate);
            oDSLYYTD = GetRawData("SecondaryActual", _FirstDayofLastYear, _ToDateofLastYearThisMonth);
            oDSLY = GetRawData("SecondaryActual", _FirstDayofLastYear, _FirstDayofThisYear);

            oDSLDOrder = GetRawData("OrderActual", dLastDate, dFromDate);
            oDSMTDOrder = GetRawData("OrderActual", _FirstDayofMonth, dToDate);
            oDSSlabTargetAndActual = GetRawSlabTargetData("", _FirstDayofMonth, dToDate);

            Data _oData;
            InnerList.Clear();

            foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow in oDSCustomer.BLLPerformanceAnalysis)
            {

                _oData = new Data();

                _oData.AreaName = oBLLPerformanceAnalysisRow.AreaName;
                _oData.TerritoryName = oBLLPerformanceAnalysisRow.TerritoryName;
                _oData.FullName = oBLLPerformanceAnalysisRow.CustomerName;
                _oData.ShortName = oBLLPerformanceAnalysisRow.CustomerShortName;
                _oData.CustomerID = oBLLPerformanceAnalysisRow.CustomerID;
                _oData.CustomerCode = oBLLPerformanceAnalysisRow.CustomerCode;
                _oData.AreaID = oBLLPerformanceAnalysisRow.AreaID;
                _oData.TerritoryID = oBLLPerformanceAnalysisRow.TerritoryID;
                _oData.RouteTypeID = oBLLPerformanceAnalysisRow.RouteTypeID;
                _oData.IsActiveDB = oBLLPerformanceAnalysisRow.IsActiveDB;
                _oData.TSMMobileNo = oBLLPerformanceAnalysisRow.TSMMobileNo;
                _oData.TSMName = oBLLPerformanceAnalysisRow.TSMName;
                _oData.TSOMobileNo = oBLLPerformanceAnalysisRow.TSOMobileNo;
                _oData.TSOName = oBLLPerformanceAnalysisRow.TSOName;
                
                //-----------
                // Current Month Secondary Target
                DSBLLPerformanceAnalysis oDSCMSTFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRCMST = oDSCMST.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "' and RouteTypeID = '" + oBLLPerformanceAnalysisRow.RouteTypeID + "' ");
                oDSCMSTFiltered.Merge(oDRCMST);
                oDSCMSTFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCMSTRow in oDSCMSTFiltered.BLLPerformanceAnalysis)
                {
                    _oData.CMSTValue = Convert.ToDouble(oDSCMSTRow.Amount);
                }

                // Current Month Secondary Achievement MTD
                DSBLLPerformanceAnalysis oDSCMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRCMSAMTD = oDSCMSAMTD.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "' and RouteTypeID = '" + oBLLPerformanceAnalysisRow.RouteTypeID + "' ");
                oDSCMSAMTDFiltered.Merge(oDRCMSAMTD);
                oDSCMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSCMSAMTDRow in oDSCMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.CMSAMTDValue = Convert.ToDouble(oDSCMSAMTDRow.Amount);
                }

                // Last Month Secondary Achievement MTD
                DSBLLPerformanceAnalysis oDSLMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLMSAMTD = oDSLMSAMTD.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "' and RouteTypeID = '" + oBLLPerformanceAnalysisRow.RouteTypeID + "' ");
                oDSLMSAMTDFiltered.Merge(oDRLMSAMTD);
                oDSLMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMSAMTDRow in oDSLMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LMSAMTDValue = Convert.ToDouble(oDSLMSAMTDRow.Amount);
                }

                // Last Month Secondary Achievement
                DSBLLPerformanceAnalysis oDSLMSAFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLMSA = oDSLMSA.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "' and RouteTypeID = '" + oBLLPerformanceAnalysisRow.RouteTypeID + "' ");
                oDSLMSAFiltered.Merge(oDRLMSA);
                oDSLMSAFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLMSARow in oDSLMSAFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LMSAValue = Convert.ToDouble(oDSLMSARow.Amount);
                }

                // Last Year This Month Secondary Achievement
                DSBLLPerformanceAnalysis oDSLYCMSAFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLYCMSA = oDSLYCMSA.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "' and RouteTypeID = '" + oBLLPerformanceAnalysisRow.RouteTypeID + "' ");
                oDSLYCMSAFiltered.Merge(oDRLYCMSA);
                oDSLYCMSAFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYCMSARow in oDSLYCMSAFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYCMSAValue = Convert.ToDouble(oDSLYCMSARow.Amount);
                }

                // Last Year This Month MTD Secondary Achievement
                DSBLLPerformanceAnalysis oDSLYCMSAMTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLYCMSAMTD = oDSLYCMSAMTD.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "' and RouteTypeID = '" + oBLLPerformanceAnalysisRow.RouteTypeID + "' ");
                oDSLYCMSAMTDFiltered.Merge(oDRLYCMSAMTD);
                oDSLYCMSAMTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYCMSAMTDRow in oDSLYCMSAMTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYCMSAMTDValue = Convert.ToDouble(oDSLYCMSAMTDRow.Amount);
                }
                // Last Day Secondary Achievement
                DSBLLPerformanceAnalysis oDSLDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLD = oDSLD.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "' and RouteTypeID = '" + oBLLPerformanceAnalysisRow.RouteTypeID + "' ");
                oDSLDFiltered.Merge(oDRLD);
                oDSLDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLDRow in oDSLDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LDValue = Convert.ToDouble(oDSLDRow.Amount);
                }
                // YTD Secondary Achievement
                DSBLLPerformanceAnalysis oDSYTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRYTD = oDSYTD.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "' and RouteTypeID = '" + oBLLPerformanceAnalysisRow.RouteTypeID + "' ");
                oDSYTDFiltered.Merge(oDRYTD);
                oDSYTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSYTDRow in oDSYTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.YTDValue = Convert.ToDouble(oDSYTDRow.Amount);
                }
                // LYYTD Secondary Achievement
                DSBLLPerformanceAnalysis oDSLYYTDFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLYYTD = oDSLYYTD.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "' and RouteTypeID = '" + oBLLPerformanceAnalysisRow.RouteTypeID + "' ");
                oDSLYYTDFiltered.Merge(oDRLYYTD);
                oDSLYYTDFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYYTDRow in oDSLYYTDFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYYTDValue = Convert.ToDouble(oDSLYYTDRow.Amount);
                }
                // LY Secondary Achievement
                DSBLLPerformanceAnalysis oDSLYFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLY = oDSLY.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "' and RouteTypeID = '" + oBLLPerformanceAnalysisRow.RouteTypeID + "' ");
                oDSLYFiltered.Merge(oDRLY);
                oDSLYFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLYRow in oDSLYFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LYValue = Convert.ToDouble(oDSLYRow.Amount);
                }

                // LD Order Value
                DSBLLPerformanceAnalysis oDSLDOrderFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRLDOrder = oDSLDOrder.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "' and RouteTypeID = '" + oBLLPerformanceAnalysisRow.RouteTypeID + "' ");
                oDSLDOrderFiltered.Merge(oDRLDOrder);
                oDSLDOrderFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSLDORderRow in oDSLDOrderFiltered.BLLPerformanceAnalysis)
                {
                    _oData.LDOrderValue = Convert.ToDouble(oDSLDORderRow.Amount);
                }

                // MTD Order Value
                DSBLLPerformanceAnalysis oDSMTDOrderFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRMTDOrder = oDSMTDOrder.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "' and RouteTypeID = '" + oBLLPerformanceAnalysisRow.RouteTypeID + "' ");
                oDSMTDOrderFiltered.Merge(oDRMTDOrder);
                oDSMTDOrderFiltered.AcceptChanges();
                foreach (DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oDSMTDORderRow in oDSMTDOrderFiltered.BLLPerformanceAnalysis)
                {
                    _oData.MTDOrderValue = Convert.ToDouble(oDSMTDORderRow.Amount);
                }

                //Slab Target and Actual
                DSBLLPerformanceAnalysis oDSMTDSlabFiltered = new DSBLLPerformanceAnalysis();
                DataRow[] oDRMTDSlab = oDSSlabTargetAndActual.BLLPerformanceAnalysis.Select(" CustomerID= '" + oBLLPerformanceAnalysisRow.CustomerID + "' and RouteTypeID = '" + oBLLPerformanceAnalysisRow.RouteTypeID + "' ");
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
        
        public DSBLLPerformanceAnalysis GetRawData(string sType, DateTime dFromDate, DateTime dTodate)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (sType == "SecondaryActual")
            {
                cmd = DBController.Instance.GetCommand();

                sSQL = " Select CustomerID, RouteTypeID, Sum(Value) as Value From " +
                       " (  " +
                       " Select b.DistributorID as CustomerID, RouteTypeID, Sum(NetAmount) as Value from BLLSysDB.dbo.t_DMSProductTran a,   " +
                       " BLLSysDB.dbo.t_DMSOutlet b, BLLSysDB.dbo.t_DMSUser c, BLLSysDB.dbo.t_DMSRoute d   " +
                       " where a.OutletID=b.OutletID and a.DistributorID=c.DistributorID and b.RouteID=d.RouteID and Trandate >=ActivatedDate  " +
                       " and TranTypeID=2 and Trandate between '" + dFromDate + "' and '" + dTodate + "' and Trandate < '" + dTodate + "'  " +
                       " Group by b.DistributorID, RouteTypeID  " +
                       " UNION ALL  " +
                       " SElect CustomerID, RouteTypeID,Value from  " +
                       " (  " +
                       " Select CustomerID, 1 as RouteTypeID, Sum(Amount) as Value from DWDB.dbo.t_SMSSecondarySales a, BLLSysDB.dbo.t_DMSUser b Where   " +
                       " Trandate between '" + dFromDate + "' and '" + dTodate + "' and Trandate < '" + dTodate + "'  " +
                       " and ActivatedDate > Trandate and a.CustomerID=b.DistributorID Group by CustomerID " +
                       " UNION ALL  " +
                       " Select CustomerID, 1 as RouteTypeID, Sum(Amount) as Value from DWDB.dbo.t_SMSSecondarySales Where   " +
                       " Trandate between '" + dFromDate + "' and '" + dTodate + "' and Trandate < '" + dTodate + "'  " +
                       " and CustomerID Not IN (Select DistributorID From BLLSysDB.dbo.t_DMSUser Where IsActive=1)  " +
                       " Group by CustomerID  " +
                       " ) a,  " +
                       " (Select DistributorID from BLLSysDB.dbo.t_DMSRoute Where RouteName='SMS Route')b  " +
                       " Where a.CustomerID=b.DistributorID  " +
                       " )x Group by CustomerID, RouteTypeID ";


            }
            else if (sType == "OrderActual")
            {
                cmd = DBController.Instance.GetCommand();

                sSQL = " select DistributorID as CustomerID, RouteTypeID, sum(OrderValue)as Value " +
                       " from BLLSysDB.dbo.t_SMSRouteOrder a, BLLSysDB.dbo.t_DMSRoute b  " +
                       " where orderDate between '" + dFromDate + "' and '" + dTodate + "' and orderDate < '" + dTodate + "' " +
                       " and a.RouteCode=b.RouteID " +
                       " group by DistributorID, RouteTypeID ";
            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.CustomerID = reader["CustomerID"].ToString();
                    oBLLPerformanceAnalysisRow.RouteTypeID = reader["RouteTypeID"].ToString();
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
        
        public DSBLLPerformanceAnalysis GetRawSlabTargetData(string sType, DateTime dFromDate, DateTime dTodate)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();

            sSQL = " Select DistributorID, RouteTypeID, Sum(SlabTGT) as Target, Sum(SLSalesTO) as Actual " +
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
                  // " select OutletID, 0 as SlabTGT, sum(DeliveryAmount)as SLSalesTO  " +
                  // " from BLLSysDB.dbo.t_DMSOrder  " +
                  //" where DeliveryDate between '" + dFromDate + "' and '" + dTodate + "' and DeliveryDate < '" + dTodate + "' and IsDelivered=1 and DeliveryAmount>0  " +
                  // " group by OutletID " +

                    " select OutletID, 0 as SlabTGT, sum(DeliveryAmount) as SLSalesTO " +
                    " from BLLSysDB.dbo.t_DMSOrder a, t_DMSClusterOutlet b " +
                    " where DeliveryDate between '" + dFromDate + "' and '" + dTodate + "' and DeliveryDate < '" + dTodate + "'   " +
                    " and IsDelivered = 1 and DeliveryAmount> 0 " +
                    " and a.OutletID = b.RetailID and b.SlabOutlet = 1 " +
                    " group by OutletID " +

                   " union all " +



                   //" select OutletID, sum(slabValue)As SlabTGT, 0 as SLSalesTO " +
                   //" from BLLSysDB.dbo.t_DMSSlabRegistration a, BLLSysDB.dbo.t_DMSSlabOffer b " +
                   //" where Createdate between '" + dFromDate + "' and '" + dTodate + "' and Createdate < '" + dTodate + "' " +
                   //" and a.SlabID=b.SlabID  " +
                   //" group by OutletID " +
            " select OutletID,sum(TSMTGTTO)As SlabTGT,0 as SLSalesTO " +
                   " from BLLSysDB.dbo.t_DMSTargetTO  " +
                   " where TGTDate between '" + dFromDate + "' and '" + dTodate + "' and TGTDate < '" + dTodate + "' and OutletID > 0  " +
                   " group by OutletID " +

                   " )As SLTGT  group by OutletID   " +
                   " )As Total  " +
                   " left outer join BLLSysDB.dbo.t_DMSClusterOutlet as COut on Total.OutletID=Cout.RetailID " +
                   " where routeID >0 " +
                   " )As Master inner join BLLSysDB.dbo.t_DMSRoute as RT on Master.RouteId=RT.RouteID " +
                   " ) as x Group by DistributorID, RouteTypeID ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.CustomerID = reader["DistributorID"].ToString();
                    oBLLPerformanceAnalysisRow.RouteTypeID = reader["RouteTypeID"].ToString();
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
        
        public DSBLLPerformanceAnalysis GetRawDataTarget(string sType, DateTime dFromDate, DateTime dTodate)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis(); 

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

                cmd = DBController.Instance.GetCommand();
                if (sType == "SecondaryTarget")
                {
                    sSQL = " select a.DistributorID, IsNull(RouteTypeID,1) as RouteTypeID, SUM(TSMTGTTO)Amount from BLLSysDB.dbo.t_DMSTargetTO a " +
                    " Left Outer JOIN BLLSysDB.dbo.t_DMSRoute b  " +
                    " ON a.RouteID=b.RouteID Where TGTDate Between '" + dFromDate + "' and '" + dTodate + "' and TGTDate < '" + dTodate + "'  " +
                    " Group by a.DistributorID, RouteTypeID  ";
                }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSBLLPerformanceAnalysis.BLLPerformanceAnalysisRow oBLLPerformanceAnalysisRow = oDSBLLPerformanceAnalysis.BLLPerformanceAnalysis.NewBLLPerformanceAnalysisRow();

                    oBLLPerformanceAnalysisRow.CustomerID = reader["DistributorID"].ToString();
                    oBLLPerformanceAnalysisRow.RouteTypeID = reader["RouteTypeID"].ToString();
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
        
        public DSBLLPerformanceAnalysis GetCustomerList(string sAndroidAppID, string sUserName)
        {
            DSBLLPerformanceAnalysis oDSBLLPerformanceAnalysis = new DSBLLPerformanceAnalysis();
            int nAndroidAppID = Convert.ToInt32(sAndroidAppID);
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            cmd = DBController.Instance.GetCommand();

            sSQL = " Select CustomerID, CustomerCode, CustomerName, CustomerShortName, AreaID, AreaShortName, a.TerritoryID, " +
                   " TerritoryShortName, IsActiveDB, AreaSort, TerritorySort, RouteTypeID, " +
                   " IsNull(TSMName,'') as TSMName, IsNull(TSMContactNo,'') as TSMContactNo,  " +
                   " IsNull(TSOName,'') as TSOName, IsNull(TSOContactNo,'') as TSOContactNo from  " +
                   " (  " +
                   " Select CustomerID, CustomerCode, CustomerName, CustomerShortName, AreaID, AreaShortName, TerritoryID,   " +
                   " TerritoryShortName, a.IsActive as IsActiveDB, AreaSort, TerritorySort, RouteTypeID  " +
                   " from BLLSysDB.dbo.v_CustomerDetails a, BLLSysDB.dbo.t_DMSRoute b  " +
                   " Where a.CustomerID=b.DistributorID  ";
            if (nAndroidAppID == (int)Dictionary.AndroidAppID.CJ_Lighting)
            {
                sSQL = sSQL + " and a.CustomerID IN ( select DataID from BLLSysDB.dbo.t_UserPermissionData Where DataType='Customer' and UserID = " +
                " (Select UserID from BLLSysDB.dbo.t_User Where UserName='" + sUserName + "')) ";
            }
            sSQL = sSQL + " Group by CustomerID, CustomerCode, CustomerName, CustomerShortName, AreaID, AreaShortName, TerritoryID,   " +
            " TerritoryShortName, a.IsActive, AreaSort, TerritorySort, RouteTypeID " +
            " )a  " +
            " Left OUter JOIN  " +
            " (Select MarketGroupID as TerritoryID, EmployeeName as TSMName, MobileNo as TSMContactNo from BLLSysDB.dbo.t_MarketGroup a,   " +
            " dbo.t_Employee b Where a.EmployeeID=b.EmployeeID and MarketGroupType=2)c  " +
            " ON a.TerritoryID=c.TerritoryID  " +
            " Left Outer JOIN  " +
            " (select DistributorID, EmployeeName as TSOName, b.MobileNo as TSOContactNo from BLLSysDB.dbo.t_DMSUser a, " +
            " dbo.t_Employee b Where a.EmployeeID=b.EmployeeID)d  " +
            " ON a.CustomerID=d.DistributorID  " +
            " Order by AreaSort, TerritorySort, IsActiveDB DESC, CustomerID, RouteTypeID ";

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
                    oBLLPerformanceAnalysisRow.RouteTypeID = reader["RouteTypeID"].ToString();
                    oBLLPerformanceAnalysisRow.AreaID = reader["AreaID"].ToString();
                    oBLLPerformanceAnalysisRow.TerritoryID = reader["TerritoryID"].ToString();
                    oBLLPerformanceAnalysisRow.IsActiveDB = reader["IsActiveDB"].ToString();
                    oBLLPerformanceAnalysisRow.TSMMobileNo = reader["TSMContactNo"].ToString();
                    oBLLPerformanceAnalysisRow.TSMName = reader["TSMName"].ToString();
                    oBLLPerformanceAnalysisRow.TSOMobileNo = reader["TSOContactNo"].ToString();
                    oBLLPerformanceAnalysisRow.TSOName = reader["TSOName"].ToString();

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
            CalendarWeek oCalendarWeek = new CalendarWeek();
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();

            int nCount = 0;
            foreach (Data oData in this)
            {
                nCount = 1;
                double _Val = oData.CMSTValue + oData.CMSAMTDValue + oData.LMSAMTDValue + oData.LYCMSAMTDValue;
                if (oData.IsActiveDB == "0")
                {
                    if (_Val == 0)
                    {
                        nCount = 0;
                    }
                }
                if (nCount != 0)
                {

                    _oData = new Data();
                    int nRemainingDay = oCalendarWeek.GetReamainingDateBLL();

                    _oData.ShortName = oData.ShortName;
                    _oData.FullName = oData.FullName;
                    _oData.ResponsiblePerson = oData.ResponsiblePerson;
                    _oData.MobileNo = oData.MobileNo;
                    _oData.CustomerCode = oData.CustomerCode;
                    _oData.AreaID = oData.AreaID;
                    _oData.TerritoryID = oData.TerritoryID;
                    _oData.CustomerID = oData.CustomerID;
                    _oData.RouteTypeID = oData.RouteTypeID;
                    _oData.Type = oData.Type;
                    _oData.Value = oData.Value;
                    if (oData.IsActiveDB == "1")
                        _oData.ActiveStatus = "Y";
                    else _oData.ActiveStatus = "N";

                    double DayPassing = Math.Round(Convert.ToDouble(DayOfMonth) / TotalDayOfMonth * 100);
                    _oData.DayPassing = DayPassing.ToString();
                    _oData.CMSTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMSTValue));
                    _oData.CMSAMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMSAMTDValue));
                    double _balance = oData.CMSTValue - oData.CMSAMTDValue;
                    if (_balance > 0)
                    {
                        _oData.TodayTarget = ExcludeDecimal(_oTELLib.TakaFormat(Math.Round(_balance / nRemainingDay, 0)));
                    }
                    else
                    {
                        _oData.TodayTarget = "0";
                    }
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



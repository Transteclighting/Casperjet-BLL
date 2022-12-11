
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

public partial class jSalesLeadManagement : System.Web.UI.Page
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

            string sAndroidAppID = "";
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
            catch (Exception ex)
            {
                dDate = DateTime.Now.Date;
            }

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

            Data _oDataTotal = new Data();
            Data _oDataTotalRtl = new Data();
            Data _oDataTotalB2B = new Data();
            Data _oDataTotalDeal = new Data();
            Data _oDataTotalEcom = new Data();
            Data _oDataTotalOth = new Data();

            Data _oDataArea = new Data();
            Data _oDataAreaRtl = new Data();
            Data _oDataAreaB2B = new Data();
            Data _oDataAreaDeal = new Data();
            Data _oDataAreaEcom = new Data();
            Data _oDataAreaOth = new Data();

            Data _oDataZone = new Data();
            Data _oDataZoneRtl = new Data();
            Data _oDataZoneB2B = new Data();
            Data _oDataZoneDeal = new Data();
            Data _oDataZoneEcom = new Data();
            Data _oDataZoneOth = new Data();

            Data _oDataOutlet = new Data();
            Data _oDataOutletRtl = new Data();
            Data _oDataOutletB2B = new Data();
            Data _oDataOutletDeal = new Data();
            Data _oDataOutletEcom = new Data();
            Data _oDataOutletOth = new Data();

            int nCount = 0;

            DBController.Instance.OpenNewConnection();
            oDatas.GetData(sCompany, dDate);
            DBController.Instance.CloseConnection();

            foreach (Data oData in oDatas)
            {
                if (nCount == 0)
                {
                    _oDataTotal = new Data();
                    _oDatas.Add(_oDataTotal);
                    _oDataTotal.Outlet = "Total";
                    _oDataTotal.Type = "National";
                    _oDataTotal.Value = "Success";
                    _oDataTotal.Channel = "All";

                    _oDataTotalRtl = new Data();
                    _oDatas.Add(_oDataTotalRtl);
                    _oDataTotalRtl.Outlet = "Total";
                    _oDataTotalRtl.Type = "National";
                    _oDataTotalRtl.Value = "Success";
                    _oDataTotalRtl.Channel = "Retail";

                    _oDataTotalB2B = new Data();
                    _oDatas.Add(_oDataTotalB2B);
                    _oDataTotalB2B.Outlet = "Total";
                    _oDataTotalB2B.Type = "National";
                    _oDataTotalB2B.Value = "Success";
                    _oDataTotalB2B.Channel = "B2B";

                    _oDataTotalDeal = new Data();
                    _oDatas.Add(_oDataTotalDeal);
                    _oDataTotalDeal.Outlet = "Total";
                    _oDataTotalDeal.Type = "National";
                    _oDataTotalDeal.Value = "Success";
                    _oDataTotalDeal.Channel = "Dealer";

                    _oDataTotalEcom = new Data();
                    _oDatas.Add(_oDataTotalEcom);
                    _oDataTotalEcom.Outlet = "Total";
                    _oDataTotalEcom.Type = "National";
                    _oDataTotalEcom.Value = "Success";
                    _oDataTotalEcom.Channel = "e-Store";

                    _oDataTotalOth = new Data();
                    _oDatas.Add(_oDataTotalOth);
                    _oDataTotalOth.Outlet = "Total";
                    _oDataTotalOth.Type = "National";
                    _oDataTotalOth.Value = "Success";
                    _oDataTotalOth.Channel = "Other";

                    nCount++;
                }
                if (_oDataArea.AreaName != oData.AreaName)
                {
                    _oDataArea = new Data();
                    _oDatas.Add(_oDataArea);
                    _oDataArea.AreaName = oData.AreaName;
                    _oDataArea.Outlet = oData.AreaName;
                    _oDataArea.Type = "Area";
                    _oDataArea.Value = "Success";
                    _oDataArea.Channel = "All";

                    _oDataAreaRtl = new Data();
                    _oDatas.Add(_oDataAreaRtl);
                    _oDataAreaRtl.AreaName = oData.AreaName;
                    _oDataAreaRtl.Outlet = oData.AreaName;
                    _oDataAreaRtl.Type = "Area";
                    _oDataAreaRtl.Value = "Success";
                    _oDataAreaRtl.Channel = "Retail";

                    _oDataAreaB2B = new Data();
                    _oDatas.Add(_oDataAreaB2B);
                    _oDataAreaB2B.AreaName = oData.AreaName;
                    _oDataAreaB2B.Outlet = oData.AreaName;
                    _oDataAreaB2B.Type = "Area";
                    _oDataAreaB2B.Value = "Success";
                    _oDataAreaB2B.Channel = "B2B";

                    _oDataAreaDeal = new Data();
                    _oDatas.Add(_oDataAreaDeal);
                    _oDataAreaDeal.AreaName = oData.AreaName;
                    _oDataAreaDeal.Outlet = oData.AreaName;
                    _oDataAreaDeal.Type = "Area";
                    _oDataAreaDeal.Value = "Success";
                    _oDataAreaDeal.Channel = "Dealer";

                    _oDataAreaEcom = new Data();
                    _oDatas.Add(_oDataAreaEcom);
                    _oDataAreaEcom.AreaName = oData.AreaName;
                    _oDataAreaEcom.Outlet = oData.AreaName;
                    _oDataAreaEcom.Type = "Area";
                    _oDataAreaEcom.Value = "Success";
                    _oDataAreaEcom.Channel = "e-Store";

                    _oDataAreaOth = new Data();
                    _oDatas.Add(_oDataAreaOth);
                    _oDataAreaOth.AreaName = oData.AreaName;
                    _oDataAreaOth.Outlet = oData.AreaName;
                    _oDataAreaOth.Type = "Area";
                    _oDataAreaOth.Value = "Success";
                    _oDataAreaOth.Channel = "Other";
                }
                if (_oDataZone.ZoneName != oData.ZoneName)
                {
                    _oDataZone = new Data();
                    _oDatas.Add(_oDataZone);
                    _oDataZone.ZoneName = oData.ZoneName;
                    _oDataZone.Outlet = oData.ZoneName;
                    _oDataZone.Type = "Zone";
                    _oDataZone.Value = "Success";
                    _oDataZone.Channel = "All";

                    _oDataZoneRtl = new Data();
                    _oDatas.Add(_oDataZoneRtl);
                    _oDataZoneRtl.ZoneName = oData.ZoneName;
                    _oDataZoneRtl.Outlet = oData.ZoneName;
                    _oDataZoneRtl.Type = "Zone";
                    _oDataZoneRtl.Value = "Success";
                    _oDataZoneRtl.Channel = "Retail";

                    _oDataZoneB2B = new Data();
                    _oDatas.Add(_oDataZoneB2B);
                    _oDataZoneB2B.ZoneName = oData.ZoneName;
                    _oDataZoneB2B.Outlet = oData.ZoneName;
                    _oDataZoneB2B.Type = "Zone";
                    _oDataZoneB2B.Value = "Success";
                    _oDataZoneB2B.Channel = "B2B";

                    _oDataZoneDeal = new Data();
                    _oDatas.Add(_oDataZoneDeal);
                    _oDataZoneDeal.ZoneName = oData.ZoneName;
                    _oDataZoneDeal.Outlet = oData.ZoneName;
                    _oDataZoneDeal.Type = "Zone";
                    _oDataZoneDeal.Value = "Success";
                    _oDataZoneDeal.Channel = "Dealer";

                    _oDataZoneEcom = new Data();
                    _oDatas.Add(_oDataZoneEcom);
                    _oDataZoneEcom.ZoneName = oData.ZoneName;
                    _oDataZoneEcom.Outlet = oData.ZoneName;
                    _oDataZoneEcom.Type = "Zone";
                    _oDataZoneEcom.Value = "Success";
                    _oDataZoneEcom.Channel = "e-Store";

                    _oDataZoneOth = new Data();
                    _oDatas.Add(_oDataZoneOth);
                    _oDataZoneOth.ZoneName = oData.ZoneName;
                    _oDataZoneOth.Outlet = oData.ZoneName;
                    _oDataZoneOth.Type = "Zone";
                    _oDataZoneOth.Value = "Success";
                    _oDataZoneOth.Channel = "Other";
                }
                if (_oDataOutlet.Outlet != oData.Outlet)
                {
                    _oDataOutlet = new Data();
                    _oDatas.Add(_oDataOutlet);
                    _oDataOutlet.Outlet = oData.Outlet;
                    _oDataOutlet.Type = "Outlet";
                    _oDataOutlet.Value = "Success";
                    _oDataOutlet.Channel = "All";

                    _oDataOutletRtl = new Data();
                    _oDatas.Add(_oDataOutletRtl);
                    _oDataOutletRtl.Outlet = oData.Outlet;
                    _oDataOutletRtl.Type = "Outlet";
                    _oDataOutletRtl.Value = "Success";
                    _oDataOutletRtl.Channel = "Retail";

                    _oDataOutletB2B = new Data();
                    _oDatas.Add(_oDataOutletB2B);
                    _oDataOutletB2B.Outlet = oData.Outlet;
                    _oDataOutletB2B.Type = "Outlet";
                    _oDataOutletB2B.Value = "Success";
                    _oDataOutletB2B.Channel = "B2B";

                    _oDataOutletDeal = new Data();
                    _oDatas.Add(_oDataOutletDeal);
                    _oDataOutletDeal.Outlet = oData.Outlet;
                    _oDataOutletDeal.Type = "Outlet";
                    _oDataOutletDeal.Value = "Success";
                    _oDataOutletDeal.Channel = "Dealer";

                    _oDataOutletEcom = new Data();
                    _oDatas.Add(_oDataOutletEcom);
                    _oDataOutletEcom.Outlet = oData.Outlet;
                    _oDataOutletEcom.Type = "Outlet";
                    _oDataOutletEcom.Value = "Success";
                    _oDataOutletEcom.Channel = "e-Store";

                    _oDataOutletOth = new Data();
                    _oDatas.Add(_oDataOutletOth);
                    _oDataOutletOth.Outlet = oData.Outlet;
                    _oDataOutletOth.Type = "Outlet";
                    _oDataOutletOth.Value = "Success";
                    _oDataOutletOth.Channel = "Other";

                }


                _oDataTotal.TargetQty = _oDataTotal.TargetQty + oData.TargetQty;
                _oDataTotal.TargetValue = _oDataTotal.TargetValue + oData.TargetValue;
                _oDataTotal.InitialLeadQty = _oDataTotal.InitialLeadQty + oData.InitialLeadQty;
                _oDataTotal.InitialLeadValue = _oDataTotal.InitialLeadValue + oData.InitialLeadValue;
                _oDataTotal.InitialLeadValue = _oDataTotal.InitialLeadValue + oData.InitialLeadValue;
                _oDataTotal.NewLeadQty = _oDataTotal.NewLeadQty + oData.NewLeadQty;
                _oDataTotal.NewLeadValue = _oDataTotal.NewLeadValue + oData.NewLeadValue;
                _oDataTotal.ShiftedLeadQty = _oDataTotal.ShiftedLeadQty + oData.ShiftedLeadQty;
                _oDataTotal.ShiftedLeadValue = _oDataTotal.ShiftedLeadValue + oData.ShiftedLeadValue;
                _oDataTotal.CancelLeadQty = _oDataTotal.CancelLeadQty + oData.CancelLeadQty;
                _oDataTotal.CancelLeadValue = _oDataTotal.CancelLeadValue + oData.CancelLeadValue;
                _oDataTotal.ConversionLeadQty = _oDataTotal.ConversionLeadQty + oData.ConversionLeadQty;
                _oDataTotal.ConversionLeadValue = _oDataTotal.ConversionLeadValue + oData.ConversionLeadValue;

                _oDataArea.TargetQty = _oDataArea.TargetQty + oData.TargetQty;
                _oDataArea.TargetValue = _oDataArea.TargetValue + oData.TargetValue;
                _oDataArea.InitialLeadQty = _oDataArea.InitialLeadQty + oData.InitialLeadQty;
                _oDataArea.InitialLeadValue = _oDataArea.InitialLeadValue + oData.InitialLeadValue;
                _oDataArea.InitialLeadValue = _oDataArea.InitialLeadValue + oData.InitialLeadValue;
                _oDataArea.NewLeadQty = _oDataArea.NewLeadQty + oData.NewLeadQty;
                _oDataArea.NewLeadValue = _oDataArea.NewLeadValue + oData.NewLeadValue;
                _oDataArea.ShiftedLeadQty = _oDataArea.ShiftedLeadQty + oData.ShiftedLeadQty;
                _oDataArea.ShiftedLeadValue = _oDataArea.ShiftedLeadValue + oData.ShiftedLeadValue;
                _oDataArea.CancelLeadQty = _oDataArea.CancelLeadQty + oData.CancelLeadQty;
                _oDataArea.CancelLeadValue = _oDataArea.CancelLeadValue + oData.CancelLeadValue;
                _oDataArea.ConversionLeadQty = _oDataArea.ConversionLeadQty + oData.ConversionLeadQty;
                _oDataArea.ConversionLeadValue = _oDataArea.ConversionLeadValue + oData.ConversionLeadValue;

                _oDataZone.TargetQty = _oDataZone.TargetQty + oData.TargetQty;
                _oDataZone.TargetValue = _oDataZone.TargetValue + oData.TargetValue;
                _oDataZone.InitialLeadQty = _oDataZone.InitialLeadQty + oData.InitialLeadQty;
                _oDataZone.InitialLeadValue = _oDataZone.InitialLeadValue + oData.InitialLeadValue;
                _oDataZone.InitialLeadValue = _oDataZone.InitialLeadValue + oData.InitialLeadValue;
                _oDataZone.NewLeadQty = _oDataZone.NewLeadQty + oData.NewLeadQty;
                _oDataZone.NewLeadValue = _oDataZone.NewLeadValue + oData.NewLeadValue;
                _oDataZone.ShiftedLeadQty = _oDataZone.ShiftedLeadQty + oData.ShiftedLeadQty;
                _oDataZone.ShiftedLeadValue = _oDataZone.ShiftedLeadValue + oData.ShiftedLeadValue;
                _oDataZone.CancelLeadQty = _oDataZone.CancelLeadQty + oData.CancelLeadQty;
                _oDataZone.CancelLeadValue = _oDataZone.CancelLeadValue + oData.CancelLeadValue;
                _oDataZone.ConversionLeadQty = _oDataZone.ConversionLeadQty + oData.ConversionLeadQty;
                _oDataZone.ConversionLeadValue = _oDataZone.ConversionLeadValue + oData.ConversionLeadValue;

                _oDataOutlet.TargetQty = _oDataOutlet.TargetQty + oData.TargetQty;
                _oDataOutlet.TargetValue = _oDataOutlet.TargetValue + oData.TargetValue;
                _oDataOutlet.InitialLeadQty = _oDataOutlet.InitialLeadQty + oData.InitialLeadQty;
                _oDataOutlet.InitialLeadValue = _oDataOutlet.InitialLeadValue + oData.InitialLeadValue;
                _oDataOutlet.InitialLeadValue = _oDataOutlet.InitialLeadValue + oData.InitialLeadValue;
                _oDataOutlet.NewLeadQty = _oDataOutlet.NewLeadQty + oData.NewLeadQty;
                _oDataOutlet.NewLeadValue = _oDataOutlet.NewLeadValue + oData.NewLeadValue;
                _oDataOutlet.ShiftedLeadQty = _oDataOutlet.ShiftedLeadQty + oData.ShiftedLeadQty;
                _oDataOutlet.ShiftedLeadValue = _oDataOutlet.ShiftedLeadValue + oData.ShiftedLeadValue;
                _oDataOutlet.CancelLeadQty = _oDataOutlet.CancelLeadQty + oData.CancelLeadQty;
                _oDataOutlet.CancelLeadValue = _oDataOutlet.CancelLeadValue + oData.CancelLeadValue;
                _oDataOutlet.ConversionLeadQty = _oDataOutlet.ConversionLeadQty + oData.ConversionLeadQty;
                _oDataOutlet.ConversionLeadValue = _oDataOutlet.ConversionLeadValue + oData.ConversionLeadValue;

                if (oData.Channel == "Retail")
                {
                    _oDataTotalRtl.TargetQty = _oDataTotalRtl.TargetQty + oData.TargetQty;
                    _oDataTotalRtl.TargetValue = _oDataTotalRtl.TargetValue + oData.TargetValue;
                    _oDataTotalRtl.InitialLeadQty = _oDataTotalRtl.InitialLeadQty + oData.InitialLeadQty;
                    _oDataTotalRtl.InitialLeadValue = _oDataTotalRtl.InitialLeadValue + oData.InitialLeadValue;
                    _oDataTotalRtl.InitialLeadValue = _oDataTotalRtl.InitialLeadValue + oData.InitialLeadValue;
                    _oDataTotalRtl.NewLeadQty = _oDataTotalRtl.NewLeadQty + oData.NewLeadQty;
                    _oDataTotalRtl.NewLeadValue = _oDataTotalRtl.NewLeadValue + oData.NewLeadValue;
                    _oDataTotalRtl.ShiftedLeadQty = _oDataTotalRtl.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataTotalRtl.ShiftedLeadValue = _oDataTotalRtl.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataTotalRtl.CancelLeadQty = _oDataTotalRtl.CancelLeadQty + oData.CancelLeadQty;
                    _oDataTotalRtl.CancelLeadValue = _oDataTotalRtl.CancelLeadValue + oData.CancelLeadValue;
                    _oDataTotalRtl.ConversionLeadQty = _oDataTotalRtl.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataTotalRtl.ConversionLeadValue = _oDataTotalRtl.ConversionLeadValue + oData.ConversionLeadValue;

                    _oDataAreaRtl.TargetQty = _oDataAreaRtl.TargetQty + oData.TargetQty;
                    _oDataAreaRtl.TargetValue = _oDataAreaRtl.TargetValue + oData.TargetValue;
                    _oDataAreaRtl.InitialLeadQty = _oDataAreaRtl.InitialLeadQty + oData.InitialLeadQty;
                    _oDataAreaRtl.InitialLeadValue = _oDataAreaRtl.InitialLeadValue + oData.InitialLeadValue;
                    _oDataAreaRtl.InitialLeadValue = _oDataAreaRtl.InitialLeadValue + oData.InitialLeadValue;
                    _oDataAreaRtl.NewLeadQty = _oDataAreaRtl.NewLeadQty + oData.NewLeadQty;
                    _oDataAreaRtl.NewLeadValue = _oDataAreaRtl.NewLeadValue + oData.NewLeadValue;
                    _oDataAreaRtl.ShiftedLeadQty = _oDataAreaRtl.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataAreaRtl.ShiftedLeadValue = _oDataAreaRtl.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataAreaRtl.CancelLeadQty = _oDataAreaRtl.CancelLeadQty + oData.CancelLeadQty;
                    _oDataAreaRtl.CancelLeadValue = _oDataAreaRtl.CancelLeadValue + oData.CancelLeadValue;
                    _oDataAreaRtl.ConversionLeadQty = _oDataAreaRtl.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataAreaRtl.ConversionLeadValue = _oDataAreaRtl.ConversionLeadValue + oData.ConversionLeadValue;

                    _oDataZoneRtl.TargetQty = _oDataZoneRtl.TargetQty + oData.TargetQty;
                    _oDataZoneRtl.TargetValue = _oDataZoneRtl.TargetValue + oData.TargetValue;
                    _oDataZoneRtl.InitialLeadQty = _oDataZoneRtl.InitialLeadQty + oData.InitialLeadQty;
                    _oDataZoneRtl.InitialLeadValue = _oDataZoneRtl.InitialLeadValue + oData.InitialLeadValue;
                    _oDataZoneRtl.InitialLeadValue = _oDataZoneRtl.InitialLeadValue + oData.InitialLeadValue;
                    _oDataZoneRtl.NewLeadQty = _oDataZoneRtl.NewLeadQty + oData.NewLeadQty;
                    _oDataZoneRtl.NewLeadValue = _oDataZoneRtl.NewLeadValue + oData.NewLeadValue;
                    _oDataZoneRtl.ShiftedLeadQty = _oDataZoneRtl.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataZoneRtl.ShiftedLeadValue = _oDataZoneRtl.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataZoneRtl.CancelLeadQty = _oDataZoneRtl.CancelLeadQty + oData.CancelLeadQty;
                    _oDataZoneRtl.CancelLeadValue = _oDataZoneRtl.CancelLeadValue + oData.CancelLeadValue;
                    _oDataZoneRtl.ConversionLeadQty = _oDataZoneRtl.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataZoneRtl.ConversionLeadValue = _oDataZoneRtl.ConversionLeadValue + oData.ConversionLeadValue;

                    _oDataOutletRtl.TargetQty = _oDataOutletRtl.TargetQty + oData.TargetQty;
                    _oDataOutletRtl.TargetValue = _oDataOutletRtl.TargetValue + oData.TargetValue;
                    _oDataOutletRtl.InitialLeadQty = _oDataOutletRtl.InitialLeadQty + oData.InitialLeadQty;
                    _oDataOutletRtl.InitialLeadValue = _oDataOutletRtl.InitialLeadValue + oData.InitialLeadValue;
                    _oDataOutletRtl.InitialLeadValue = _oDataOutletRtl.InitialLeadValue + oData.InitialLeadValue;
                    _oDataOutletRtl.NewLeadQty = _oDataOutletRtl.NewLeadQty + oData.NewLeadQty;
                    _oDataOutletRtl.NewLeadValue = _oDataOutletRtl.NewLeadValue + oData.NewLeadValue;
                    _oDataOutletRtl.ShiftedLeadQty = _oDataOutletRtl.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataOutletRtl.ShiftedLeadValue = _oDataOutletRtl.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataOutletRtl.CancelLeadQty = _oDataOutletRtl.CancelLeadQty + oData.CancelLeadQty;
                    _oDataOutletRtl.CancelLeadValue = _oDataOutletRtl.CancelLeadValue + oData.CancelLeadValue;
                    _oDataOutletRtl.ConversionLeadQty = _oDataOutletRtl.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataOutletRtl.ConversionLeadValue = _oDataOutletRtl.ConversionLeadValue + oData.ConversionLeadValue;
                }
                else if (oData.Channel == "B2B")
                {
                    _oDataTotalB2B.TargetQty = _oDataTotalB2B.TargetQty + oData.TargetQty;
                    _oDataTotalB2B.TargetValue = _oDataTotalB2B.TargetValue + oData.TargetValue;
                    _oDataTotalB2B.InitialLeadQty = _oDataTotalB2B.InitialLeadQty + oData.InitialLeadQty;
                    _oDataTotalB2B.InitialLeadValue = _oDataTotalB2B.InitialLeadValue + oData.InitialLeadValue;
                    _oDataTotalB2B.InitialLeadValue = _oDataTotalB2B.InitialLeadValue + oData.InitialLeadValue;
                    _oDataTotalB2B.NewLeadQty = _oDataTotalB2B.NewLeadQty + oData.NewLeadQty;
                    _oDataTotalB2B.NewLeadValue = _oDataTotalB2B.NewLeadValue + oData.NewLeadValue;
                    _oDataTotalB2B.ShiftedLeadQty = _oDataTotalB2B.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataTotalB2B.ShiftedLeadValue = _oDataTotalB2B.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataTotalB2B.CancelLeadQty = _oDataTotalB2B.CancelLeadQty + oData.CancelLeadQty;
                    _oDataTotalB2B.CancelLeadValue = _oDataTotalB2B.CancelLeadValue + oData.CancelLeadValue;
                    _oDataTotalB2B.ConversionLeadQty = _oDataTotalB2B.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataTotalB2B.ConversionLeadValue = _oDataTotalB2B.ConversionLeadValue + oData.ConversionLeadValue;

                    _oDataAreaB2B.TargetQty = _oDataAreaB2B.TargetQty + oData.TargetQty;
                    _oDataAreaB2B.TargetValue = _oDataAreaB2B.TargetValue + oData.TargetValue;
                    _oDataAreaB2B.InitialLeadQty = _oDataAreaB2B.InitialLeadQty + oData.InitialLeadQty;
                    _oDataAreaB2B.InitialLeadValue = _oDataAreaB2B.InitialLeadValue + oData.InitialLeadValue;
                    _oDataAreaB2B.InitialLeadValue = _oDataAreaB2B.InitialLeadValue + oData.InitialLeadValue;
                    _oDataAreaB2B.NewLeadQty = _oDataAreaB2B.NewLeadQty + oData.NewLeadQty;
                    _oDataAreaB2B.NewLeadValue = _oDataAreaB2B.NewLeadValue + oData.NewLeadValue;
                    _oDataAreaB2B.ShiftedLeadQty = _oDataAreaB2B.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataAreaB2B.ShiftedLeadValue = _oDataAreaB2B.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataAreaB2B.CancelLeadQty = _oDataAreaB2B.CancelLeadQty + oData.CancelLeadQty;
                    _oDataAreaB2B.CancelLeadValue = _oDataAreaB2B.CancelLeadValue + oData.CancelLeadValue;
                    _oDataAreaB2B.ConversionLeadQty = _oDataAreaB2B.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataAreaB2B.ConversionLeadValue = _oDataAreaB2B.ConversionLeadValue + oData.ConversionLeadValue;

                    _oDataZoneB2B.TargetQty = _oDataZoneB2B.TargetQty + oData.TargetQty;
                    _oDataZoneB2B.TargetValue = _oDataZoneB2B.TargetValue + oData.TargetValue;
                    _oDataZoneB2B.InitialLeadQty = _oDataZoneB2B.InitialLeadQty + oData.InitialLeadQty;
                    _oDataZoneB2B.InitialLeadValue = _oDataZoneB2B.InitialLeadValue + oData.InitialLeadValue;
                    _oDataZoneB2B.InitialLeadValue = _oDataZoneB2B.InitialLeadValue + oData.InitialLeadValue;
                    _oDataZoneB2B.NewLeadQty = _oDataZoneB2B.NewLeadQty + oData.NewLeadQty;
                    _oDataZoneB2B.NewLeadValue = _oDataZoneB2B.NewLeadValue + oData.NewLeadValue;
                    _oDataZoneB2B.ShiftedLeadQty = _oDataZoneB2B.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataZoneB2B.ShiftedLeadValue = _oDataZoneB2B.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataZoneB2B.CancelLeadQty = _oDataZoneB2B.CancelLeadQty + oData.CancelLeadQty;
                    _oDataZoneB2B.CancelLeadValue = _oDataZoneB2B.CancelLeadValue + oData.CancelLeadValue;
                    _oDataZoneB2B.ConversionLeadQty = _oDataZoneB2B.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataZoneB2B.ConversionLeadValue = _oDataZoneB2B.ConversionLeadValue + oData.ConversionLeadValue;

                    _oDataOutletB2B.TargetQty = _oDataOutletB2B.TargetQty + oData.TargetQty;
                    _oDataOutletB2B.TargetValue = _oDataOutletB2B.TargetValue + oData.TargetValue;
                    _oDataOutletB2B.InitialLeadQty = _oDataOutletB2B.InitialLeadQty + oData.InitialLeadQty;
                    _oDataOutletB2B.InitialLeadValue = _oDataOutletB2B.InitialLeadValue + oData.InitialLeadValue;
                    _oDataOutletB2B.InitialLeadValue = _oDataOutletB2B.InitialLeadValue + oData.InitialLeadValue;
                    _oDataOutletB2B.NewLeadQty = _oDataOutletB2B.NewLeadQty + oData.NewLeadQty;
                    _oDataOutletB2B.NewLeadValue = _oDataOutletB2B.NewLeadValue + oData.NewLeadValue;
                    _oDataOutletB2B.ShiftedLeadQty = _oDataOutletB2B.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataOutletB2B.ShiftedLeadValue = _oDataOutletB2B.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataOutletB2B.CancelLeadQty = _oDataOutletB2B.CancelLeadQty + oData.CancelLeadQty;
                    _oDataOutletB2B.CancelLeadValue = _oDataOutletB2B.CancelLeadValue + oData.CancelLeadValue;
                    _oDataOutletB2B.ConversionLeadQty = _oDataOutletB2B.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataOutletB2B.ConversionLeadValue = _oDataOutletB2B.ConversionLeadValue + oData.ConversionLeadValue;
                }
                else if (oData.Channel == "Dealer")
                {
                    _oDataTotalDeal.TargetQty = _oDataTotalDeal.TargetQty + oData.TargetQty;
                    _oDataTotalDeal.TargetValue = _oDataTotalDeal.TargetValue + oData.TargetValue;
                    _oDataTotalDeal.InitialLeadQty = _oDataTotalDeal.InitialLeadQty + oData.InitialLeadQty;
                    _oDataTotalDeal.InitialLeadValue = _oDataTotalDeal.InitialLeadValue + oData.InitialLeadValue;
                    _oDataTotalDeal.InitialLeadValue = _oDataTotalDeal.InitialLeadValue + oData.InitialLeadValue;
                    _oDataTotalDeal.NewLeadQty = _oDataTotalDeal.NewLeadQty + oData.NewLeadQty;
                    _oDataTotalDeal.NewLeadValue = _oDataTotalDeal.NewLeadValue + oData.NewLeadValue;
                    _oDataTotalDeal.ShiftedLeadQty = _oDataTotalDeal.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataTotalDeal.ShiftedLeadValue = _oDataTotalDeal.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataTotalDeal.CancelLeadQty = _oDataTotalDeal.CancelLeadQty + oData.CancelLeadQty;
                    _oDataTotalDeal.CancelLeadValue = _oDataTotalDeal.CancelLeadValue + oData.CancelLeadValue;
                    _oDataTotalDeal.ConversionLeadQty = _oDataTotalDeal.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataTotalDeal.ConversionLeadValue = _oDataTotalDeal.ConversionLeadValue + oData.ConversionLeadValue;

                    _oDataAreaDeal.TargetQty = _oDataAreaDeal.TargetQty + oData.TargetQty;
                    _oDataAreaDeal.TargetValue = _oDataAreaDeal.TargetValue + oData.TargetValue;
                    _oDataAreaDeal.InitialLeadQty = _oDataAreaDeal.InitialLeadQty + oData.InitialLeadQty;
                    _oDataAreaDeal.InitialLeadValue = _oDataAreaDeal.InitialLeadValue + oData.InitialLeadValue;
                    _oDataAreaDeal.InitialLeadValue = _oDataAreaDeal.InitialLeadValue + oData.InitialLeadValue;
                    _oDataAreaDeal.NewLeadQty = _oDataAreaDeal.NewLeadQty + oData.NewLeadQty;
                    _oDataAreaDeal.NewLeadValue = _oDataAreaDeal.NewLeadValue + oData.NewLeadValue;
                    _oDataAreaDeal.ShiftedLeadQty = _oDataAreaDeal.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataAreaDeal.ShiftedLeadValue = _oDataAreaDeal.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataAreaDeal.CancelLeadQty = _oDataAreaDeal.CancelLeadQty + oData.CancelLeadQty;
                    _oDataAreaDeal.CancelLeadValue = _oDataAreaDeal.CancelLeadValue + oData.CancelLeadValue;
                    _oDataAreaDeal.ConversionLeadQty = _oDataAreaDeal.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataAreaDeal.ConversionLeadValue = _oDataAreaDeal.ConversionLeadValue + oData.ConversionLeadValue;

                    _oDataZoneDeal.TargetQty = _oDataZoneDeal.TargetQty + oData.TargetQty;
                    _oDataZoneDeal.TargetValue = _oDataZoneDeal.TargetValue + oData.TargetValue;
                    _oDataZoneDeal.InitialLeadQty = _oDataZoneDeal.InitialLeadQty + oData.InitialLeadQty;
                    _oDataZoneDeal.InitialLeadValue = _oDataZoneDeal.InitialLeadValue + oData.InitialLeadValue;
                    _oDataZoneDeal.InitialLeadValue = _oDataZoneDeal.InitialLeadValue + oData.InitialLeadValue;
                    _oDataZoneDeal.NewLeadQty = _oDataZoneDeal.NewLeadQty + oData.NewLeadQty;
                    _oDataZoneDeal.NewLeadValue = _oDataZoneDeal.NewLeadValue + oData.NewLeadValue;
                    _oDataZoneDeal.ShiftedLeadQty = _oDataZoneDeal.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataZoneDeal.ShiftedLeadValue = _oDataZoneDeal.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataZoneDeal.CancelLeadQty = _oDataZoneDeal.CancelLeadQty + oData.CancelLeadQty;
                    _oDataZoneDeal.CancelLeadValue = _oDataZoneDeal.CancelLeadValue + oData.CancelLeadValue;
                    _oDataZoneDeal.ConversionLeadQty = _oDataZoneDeal.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataZoneDeal.ConversionLeadValue = _oDataZoneDeal.ConversionLeadValue + oData.ConversionLeadValue;

                    _oDataOutletDeal.TargetQty = _oDataOutletDeal.TargetQty + oData.TargetQty;
                    _oDataOutletDeal.TargetValue = _oDataOutletDeal.TargetValue + oData.TargetValue;
                    _oDataOutletDeal.InitialLeadQty = _oDataOutletDeal.InitialLeadQty + oData.InitialLeadQty;
                    _oDataOutletDeal.InitialLeadValue = _oDataOutletDeal.InitialLeadValue + oData.InitialLeadValue;
                    _oDataOutletDeal.InitialLeadValue = _oDataOutletDeal.InitialLeadValue + oData.InitialLeadValue;
                    _oDataOutletDeal.NewLeadQty = _oDataOutletDeal.NewLeadQty + oData.NewLeadQty;
                    _oDataOutletDeal.NewLeadValue = _oDataOutletDeal.NewLeadValue + oData.NewLeadValue;
                    _oDataOutletDeal.ShiftedLeadQty = _oDataOutletDeal.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataOutletDeal.ShiftedLeadValue = _oDataOutletDeal.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataOutletDeal.CancelLeadQty = _oDataOutletDeal.CancelLeadQty + oData.CancelLeadQty;
                    _oDataOutletDeal.CancelLeadValue = _oDataOutletDeal.CancelLeadValue + oData.CancelLeadValue;
                    _oDataOutletDeal.ConversionLeadQty = _oDataOutletDeal.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataOutletDeal.ConversionLeadValue = _oDataOutletDeal.ConversionLeadValue + oData.ConversionLeadValue;
                }
                else if (oData.Channel == "e-Store")
                {
                    _oDataTotalEcom.TargetQty = _oDataTotalEcom.TargetQty + oData.TargetQty;
                    _oDataTotalEcom.TargetValue = _oDataTotalEcom.TargetValue + oData.TargetValue;
                    _oDataTotalEcom.InitialLeadQty = _oDataTotalEcom.InitialLeadQty + oData.InitialLeadQty;
                    _oDataTotalEcom.InitialLeadValue = _oDataTotalEcom.InitialLeadValue + oData.InitialLeadValue;
                    _oDataTotalEcom.InitialLeadValue = _oDataTotalEcom.InitialLeadValue + oData.InitialLeadValue;
                    _oDataTotalEcom.NewLeadQty = _oDataTotalEcom.NewLeadQty + oData.NewLeadQty;
                    _oDataTotalEcom.NewLeadValue = _oDataTotalEcom.NewLeadValue + oData.NewLeadValue;
                    _oDataTotalEcom.ShiftedLeadQty = _oDataTotalEcom.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataTotalEcom.ShiftedLeadValue = _oDataTotalEcom.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataTotalEcom.CancelLeadQty = _oDataTotalEcom.CancelLeadQty + oData.CancelLeadQty;
                    _oDataTotalEcom.CancelLeadValue = _oDataTotalEcom.CancelLeadValue + oData.CancelLeadValue;
                    _oDataTotalEcom.ConversionLeadQty = _oDataTotalEcom.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataTotalEcom.ConversionLeadValue = _oDataTotalEcom.ConversionLeadValue + oData.ConversionLeadValue;

                    _oDataAreaEcom.TargetQty = _oDataAreaEcom.TargetQty + oData.TargetQty;
                    _oDataAreaEcom.TargetValue = _oDataAreaEcom.TargetValue + oData.TargetValue;
                    _oDataAreaEcom.InitialLeadQty = _oDataAreaEcom.InitialLeadQty + oData.InitialLeadQty;
                    _oDataAreaEcom.InitialLeadValue = _oDataAreaEcom.InitialLeadValue + oData.InitialLeadValue;
                    _oDataAreaEcom.InitialLeadValue = _oDataAreaEcom.InitialLeadValue + oData.InitialLeadValue;
                    _oDataAreaEcom.NewLeadQty = _oDataAreaEcom.NewLeadQty + oData.NewLeadQty;
                    _oDataAreaEcom.NewLeadValue = _oDataAreaEcom.NewLeadValue + oData.NewLeadValue;
                    _oDataAreaEcom.ShiftedLeadQty = _oDataAreaEcom.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataAreaEcom.ShiftedLeadValue = _oDataAreaEcom.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataAreaEcom.CancelLeadQty = _oDataAreaEcom.CancelLeadQty + oData.CancelLeadQty;
                    _oDataAreaEcom.CancelLeadValue = _oDataAreaEcom.CancelLeadValue + oData.CancelLeadValue;
                    _oDataAreaEcom.ConversionLeadQty = _oDataAreaEcom.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataAreaEcom.ConversionLeadValue = _oDataAreaEcom.ConversionLeadValue + oData.ConversionLeadValue;

                    _oDataZoneEcom.TargetQty = _oDataZoneEcom.TargetQty + oData.TargetQty;
                    _oDataZoneEcom.TargetValue = _oDataZoneEcom.TargetValue + oData.TargetValue;
                    _oDataZoneEcom.InitialLeadQty = _oDataZoneEcom.InitialLeadQty + oData.InitialLeadQty;
                    _oDataZoneEcom.InitialLeadValue = _oDataZoneEcom.InitialLeadValue + oData.InitialLeadValue;
                    _oDataZoneEcom.InitialLeadValue = _oDataZoneEcom.InitialLeadValue + oData.InitialLeadValue;
                    _oDataZoneEcom.NewLeadQty = _oDataZoneEcom.NewLeadQty + oData.NewLeadQty;
                    _oDataZoneEcom.NewLeadValue = _oDataZoneEcom.NewLeadValue + oData.NewLeadValue;
                    _oDataZoneEcom.ShiftedLeadQty = _oDataZoneEcom.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataZoneEcom.ShiftedLeadValue = _oDataZoneEcom.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataZoneEcom.CancelLeadQty = _oDataZoneEcom.CancelLeadQty + oData.CancelLeadQty;
                    _oDataZoneEcom.CancelLeadValue = _oDataZoneEcom.CancelLeadValue + oData.CancelLeadValue;
                    _oDataZoneEcom.ConversionLeadQty = _oDataZoneEcom.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataZoneEcom.ConversionLeadValue = _oDataZoneEcom.ConversionLeadValue + oData.ConversionLeadValue;

                    _oDataOutletEcom.TargetQty = _oDataOutletEcom.TargetQty + oData.TargetQty;
                    _oDataOutletEcom.TargetValue = _oDataOutletEcom.TargetValue + oData.TargetValue;
                    _oDataOutletEcom.InitialLeadQty = _oDataOutletEcom.InitialLeadQty + oData.InitialLeadQty;
                    _oDataOutletEcom.InitialLeadValue = _oDataOutletEcom.InitialLeadValue + oData.InitialLeadValue;
                    _oDataOutletEcom.InitialLeadValue = _oDataOutletEcom.InitialLeadValue + oData.InitialLeadValue;
                    _oDataOutletEcom.NewLeadQty = _oDataOutletEcom.NewLeadQty + oData.NewLeadQty;
                    _oDataOutletEcom.NewLeadValue = _oDataOutletEcom.NewLeadValue + oData.NewLeadValue;
                    _oDataOutletEcom.ShiftedLeadQty = _oDataOutletEcom.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataOutletEcom.ShiftedLeadValue = _oDataOutletEcom.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataOutletEcom.CancelLeadQty = _oDataOutletEcom.CancelLeadQty + oData.CancelLeadQty;
                    _oDataOutletEcom.CancelLeadValue = _oDataOutletEcom.CancelLeadValue + oData.CancelLeadValue;
                    _oDataOutletEcom.ConversionLeadQty = _oDataOutletEcom.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataOutletEcom.ConversionLeadValue = _oDataOutletEcom.ConversionLeadValue + oData.ConversionLeadValue;
                }
                else if (oData.Channel == "Other")
                {
                    _oDataTotalOth.TargetQty = _oDataTotalOth.TargetQty + oData.TargetQty;
                    _oDataTotalOth.TargetValue = _oDataTotalOth.TargetValue + oData.TargetValue;
                    _oDataTotalOth.InitialLeadQty = _oDataTotalOth.InitialLeadQty + oData.InitialLeadQty;
                    _oDataTotalOth.InitialLeadValue = _oDataTotalOth.InitialLeadValue + oData.InitialLeadValue;
                    _oDataTotalOth.InitialLeadValue = _oDataTotalOth.InitialLeadValue + oData.InitialLeadValue;
                    _oDataTotalOth.NewLeadQty = _oDataTotalOth.NewLeadQty + oData.NewLeadQty;
                    _oDataTotalOth.NewLeadValue = _oDataTotalOth.NewLeadValue + oData.NewLeadValue;
                    _oDataTotalOth.ShiftedLeadQty = _oDataTotalOth.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataTotalOth.ShiftedLeadValue = _oDataTotalOth.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataTotalOth.CancelLeadQty = _oDataTotalOth.CancelLeadQty + oData.CancelLeadQty;
                    _oDataTotalOth.CancelLeadValue = _oDataTotalOth.CancelLeadValue + oData.CancelLeadValue;
                    _oDataTotalOth.ConversionLeadQty = _oDataTotalOth.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataTotalOth.ConversionLeadValue = _oDataTotalOth.ConversionLeadValue + oData.ConversionLeadValue;

                    _oDataAreaOth.TargetQty = _oDataAreaOth.TargetQty + oData.TargetQty;
                    _oDataAreaOth.TargetValue = _oDataAreaOth.TargetValue + oData.TargetValue;
                    _oDataAreaOth.InitialLeadQty = _oDataAreaOth.InitialLeadQty + oData.InitialLeadQty;
                    _oDataAreaOth.InitialLeadValue = _oDataAreaOth.InitialLeadValue + oData.InitialLeadValue;
                    _oDataAreaOth.InitialLeadValue = _oDataAreaOth.InitialLeadValue + oData.InitialLeadValue;
                    _oDataAreaOth.NewLeadQty = _oDataAreaOth.NewLeadQty + oData.NewLeadQty;
                    _oDataAreaOth.NewLeadValue = _oDataAreaOth.NewLeadValue + oData.NewLeadValue;
                    _oDataAreaOth.ShiftedLeadQty = _oDataAreaOth.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataAreaOth.ShiftedLeadValue = _oDataAreaOth.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataAreaOth.CancelLeadQty = _oDataAreaOth.CancelLeadQty + oData.CancelLeadQty;
                    _oDataAreaOth.CancelLeadValue = _oDataAreaOth.CancelLeadValue + oData.CancelLeadValue;
                    _oDataAreaOth.ConversionLeadQty = _oDataAreaOth.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataAreaOth.ConversionLeadValue = _oDataAreaOth.ConversionLeadValue + oData.ConversionLeadValue;

                    _oDataZoneOth.TargetQty = _oDataZoneOth.TargetQty + oData.TargetQty;
                    _oDataZoneOth.TargetValue = _oDataZoneOth.TargetValue + oData.TargetValue;
                    _oDataZoneOth.InitialLeadQty = _oDataZoneOth.InitialLeadQty + oData.InitialLeadQty;
                    _oDataZoneOth.InitialLeadValue = _oDataZoneOth.InitialLeadValue + oData.InitialLeadValue;
                    _oDataZoneOth.InitialLeadValue = _oDataZoneOth.InitialLeadValue + oData.InitialLeadValue;
                    _oDataZoneOth.NewLeadQty = _oDataZoneOth.NewLeadQty + oData.NewLeadQty;
                    _oDataZoneOth.NewLeadValue = _oDataZoneOth.NewLeadValue + oData.NewLeadValue;
                    _oDataZoneOth.ShiftedLeadQty = _oDataZoneOth.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataZoneOth.ShiftedLeadValue = _oDataZoneOth.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataZoneOth.CancelLeadQty = _oDataZoneOth.CancelLeadQty + oData.CancelLeadQty;
                    _oDataZoneOth.CancelLeadValue = _oDataZoneOth.CancelLeadValue + oData.CancelLeadValue;
                    _oDataZoneOth.ConversionLeadQty = _oDataZoneOth.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataZoneOth.ConversionLeadValue = _oDataZoneOth.ConversionLeadValue + oData.ConversionLeadValue;

                    _oDataOutletOth.TargetQty = _oDataOutletOth.TargetQty + oData.TargetQty;
                    _oDataOutletOth.TargetValue = _oDataOutletOth.TargetValue + oData.TargetValue;
                    _oDataOutletOth.InitialLeadQty = _oDataOutletOth.InitialLeadQty + oData.InitialLeadQty;
                    _oDataOutletOth.InitialLeadValue = _oDataOutletOth.InitialLeadValue + oData.InitialLeadValue;
                    _oDataOutletOth.InitialLeadValue = _oDataOutletOth.InitialLeadValue + oData.InitialLeadValue;
                    _oDataOutletOth.NewLeadQty = _oDataOutletOth.NewLeadQty + oData.NewLeadQty;
                    _oDataOutletOth.NewLeadValue = _oDataOutletOth.NewLeadValue + oData.NewLeadValue;
                    _oDataOutletOth.ShiftedLeadQty = _oDataOutletOth.ShiftedLeadQty + oData.ShiftedLeadQty;
                    _oDataOutletOth.ShiftedLeadValue = _oDataOutletOth.ShiftedLeadValue + oData.ShiftedLeadValue;
                    _oDataOutletOth.CancelLeadQty = _oDataOutletOth.CancelLeadQty + oData.CancelLeadQty;
                    _oDataOutletOth.CancelLeadValue = _oDataOutletOth.CancelLeadValue + oData.CancelLeadValue;
                    _oDataOutletOth.ConversionLeadQty = _oDataOutletOth.ConversionLeadQty + oData.ConversionLeadQty;
                    _oDataOutletOth.ConversionLeadValue = _oDataOutletOth.ConversionLeadValue + oData.ConversionLeadValue;
                }
                


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
        public string Channel;
        public string Type;

        public int TargetQty;
        public double TargetValue;
        public string TargetQtyText;
        public string TargetValueText;

        public int InitialLeadQty;
        public double InitialLeadValue;
        public string InitialLeadQtyText;
        public string InitialLeadValueText;

        public int NewLeadQty;
        public double NewLeadValue;
        public string NewLeadQtyText;
        public string NewLeadValueText;

        public int ShiftedLeadQty;
        public double ShiftedLeadValue;
        public string ShiftedLeadQtyText;
        public string ShiftedLeadValueText;

        public int CancelLeadQty;
        public double CancelLeadValue;
        public string CancelLeadQtyText;
        public string CancelLeadValueText;

        public int ConversionLeadQty;
        public double ConversionLeadValue;
        public string ConversionLeadQtyText;
        public string ConversionLeadValueText;

        public string TotalLeadQtyText;
        public string TotalLeadValueText;
        public string ShortfallLeadValueText;
        public string ConversionRationValueText;

        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10018";
            string sReportName = "Sales Lead Management";
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
        public void GetDataOld(string sCompany, DateTime dDate)
        {
            TELLib _oTELLib = new TELLib();
            DSLeadManagement oDSTarget = new DSLeadManagement();
            DSLeadManagement oDSInitialLead = new DSLeadManagement();
            DSLeadManagement oDSNewLead = new DSLeadManagement();
            DSLeadManagement oDSShiftedLead = new DSLeadManagement();
            DSLeadManagement oDSCancelLead = new DSLeadManagement();
            DSLeadManagement oDSConversion = new DSLeadManagement();

            DateTime dFromDate = DateTime.Now.Date;
            DateTime dToDate = dFromDate.AddDays(1);
            DateTime dLastDate = dFromDate.AddDays(-1);


            int nMonth = dFromDate.Month;
            int nYear = dFromDate.Year;
            DateTime _FirstDayofMonth = _oTELLib.FirstDayofMonth(dFromDate);
            DateTime _LastDateOfMonth = _oTELLib.LastDayofMonth(dFromDate);



            DateTime _FirstDayofLastMonth = _oTELLib.FirstDayofLastMonth(dFromDate);

            DateTime _FirstDayofThisYear = _oTELLib.FirstDayofThisYear(dFromDate);
            DateTime _FirstDayofLastYear = _FirstDayofThisYear.AddYears(-1);


            string sSQL = "";

            #region Target
            OleDbCommand cmd = DBController.Instance.GetCommand();

            sSQL = " Select ShowroomCode as Outlet, Case when Channel=3 then 'Dealer' " +
                   " when Channel=4 then 'Retail' when Channel= 13 then 'B2B' " +
                   " when Channel= 16 then 'e-Store' else 'Other' end as Channel , Sum(TargetQty) as Qty, sum(TargetAmount) as Amount " +
                   " From t_PLanExecutiveLeadTarget a, t_Showroom b where a.customerid=b.customerid and TMonth=" + nMonth + " and TYear= " + nYear + " and TargetType = " + (int)Dictionary.PlanVersionType.ExecutiveLeadTarget + " " +
                   " group by ShowroomCode, Channel ";
               
            
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSLeadManagement.LeadManagementRow oTargetRow = oDSTarget.LeadManagement.NewLeadManagementRow();

                    oTargetRow.Outlet = reader["Outlet"].ToString();
                    oTargetRow.Channel = reader["Channel"].ToString();
                    oTargetRow.Qty = Convert.ToInt32(reader["Qty"]);
                    oTargetRow.Value = Convert.ToDouble(reader["Amount"]);

                    oDSTarget.LeadManagement.AddLeadManagementRow(oTargetRow);
                    oDSTarget.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
            
            #region Initial Lead
            cmd = DBController.Instance.GetCommand();

            //sSQL = " Select ShowroomCode as Outlet,  " +
            //       " Channel=Case when CustomerType=1 then 'Retail'  " +
            //       " when CustomerType=3 then 'B2B'  " +
            //       " when CustomerType=5 then 'Dealer'  " +
            //       " when CustomerType=6 then 'e-Store'  " +
            //       " else 'Other' end,0 as LeadTarget,count(LeadID) as Qty,  " +
            //       " sum(LeadAmount) as Amount  " +
            //       " From t_SalesLeadManagement a, t_showroom b " +
            //       " where a.warehouseid=b.warehouseid and month(ExpExecuteDate)= " + nMonth + " and Year(ExpExecuteDate)= " + nYear + " and LeadDate<'" + _FirstDayofMonth + "' and LeadID not in  " +
            //       " (Select LeadID From (Select WarehouseID,LeadID,LeadNo From  " +
            //       " (Select WarehouseID,LeadID,LeadNo,CancelDate=Case when CancelDate is not null then CancelDate  " +
            //       " when CancelDate<>'' then CancelDate else UpdateDate end  " +
            //       " From t_SalesLeadManagement where LeadDate < '" + _FirstDayofMonth + "'  " +
            //       " and Status=4 ) a where CancelDate<'" + _FirstDayofMonth + "'  " +
            //       " Union All  " +
            //       " Select WarehouseID,LeadID,LeadNo  " +
            //       " From t_SalesLeadManagement where LeadDate<'" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
            //       " and Status=3 ) a)  " +
            //       " group by ShowroomCode,CustomerType  ";

            sSQL = String.Format(@"Select Outlet,Channel,0 as LeadTarget,count(LeadNo) as Qty,
                    sum(LeadAmount) as Amount From
                    (
                    Select ShowroomCode as Outlet,
                    Channel = Case when CustomerType = 1 then 'Retail'
                    when CustomerType = 3 then 'B2B'
                    when CustomerType = 5 then 'Dealer'
                    when CustomerType = 6 then 'e-Store'  
                    else 'Other' end, LeadNo,
                    LeadAmount,
                    case when LeadDate < '{0}' and InvoiceDate < '{0}'
                    and Status = 3 then 1
                    when(Case when CancelDate is not null then CancelDate
                    when CancelDate <> '' then CancelDate else UpdateDate end) < '{0}'
                    and Status = 4 then 1 else 0 end as IsExcludeLead
                    From t_SalesLeadManagement a, t_showroom b
                    where a.warehouseid = b.warehouseid and month(ExpExecuteDate) = {1}
                    and Year(ExpExecuteDate) = {2} and LeadDate < '{0}'
                    ) Main where IsExcludeLead = 0
                    group by Outlet,Channel", _FirstDayofMonth, nMonth, nYear);
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSLeadManagement.LeadManagementRow oInitialRow = oDSInitialLead.LeadManagement.NewLeadManagementRow();

                    oInitialRow.Outlet = reader["Outlet"].ToString();
                    oInitialRow.Channel = reader["Channel"].ToString();
                    oInitialRow.Qty = Convert.ToInt32(reader["Qty"]);
                    oInitialRow.Value = Convert.ToDouble(reader["Amount"]);

                    oDSInitialLead.LeadManagement.AddLeadManagementRow(oInitialRow);
                    oDSInitialLead.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion

            #region New Lead
            cmd = DBController.Instance.GetCommand();

            sSQL = " Select ShowroomCode as Outlet,  " +
                   " Channel=Case when CustomerType=1 then 'Retail'  " +
                   " when CustomerType=3 then 'B2B'  " +
                   " when CustomerType=5 then 'Dealer'  " +
                   " when CustomerType=6 then 'e-Store'  " +
                   " else 'Other' end,count(LeadID) as Qty,  " +
                   " sum(LeadAmount) as Amount "+
                   " From t_SalesLeadManagement a, t_showroom b " +
                   " where a.warehouseid=b.warehouseid and month(ExpExecuteDate)= " + nMonth + " and Year(ExpExecuteDate) = " + nYear + " " +
                   " and Month(LeadDate)= " + nMonth + " and Year(LeadDate)= " + nYear + " group by ShowroomCode,CustomerType  ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSLeadManagement.LeadManagementRow oNewLeadRow = oDSNewLead.LeadManagement.NewLeadManagementRow();

                    oNewLeadRow.Outlet = reader["Outlet"].ToString();
                    oNewLeadRow.Channel = reader["Channel"].ToString();
                    oNewLeadRow.Qty = Convert.ToInt32(reader["Qty"]);
                    oNewLeadRow.Value = Convert.ToDouble(reader["Amount"]);

                    oDSNewLead.LeadManagement.AddLeadManagementRow(oNewLeadRow);
                    oDSNewLead.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion

            #region Shifted Lead
            cmd = DBController.Instance.GetCommand();

            sSQL = " Select ShowroomCode as Outlet,  " +
                   " Channel=Case when CustomerType=1 then 'Retail'  " +
                   " when CustomerType=3 then 'B2B'  " +
                   " when CustomerType=5 then 'Dealer'  " +
                   " when CustomerType=6 then 'e-Store'  " +
                   " else 'Other' end,  " +
                   " count(LeadID) as Qty,sum(LeadAmount) as Amount " +
                   " From t_SalesLeadManagement a, t_showroom b where a.warehouseid=b.warehouseid and LeadNo in  " +
                   " (Select LeadNo From  " +
                   " (Select LeadNo,max(ExpExecuteDate) ExpExecuteDate From t_SalesLeadManagementHistory where LeadNo in (  " +
                   " Select LeadNo From t_SalesLeadManagement  " +
                   " where month(ExpExecuteDate)= " + nMonth + " and Year(ExpExecuteDate)= " + nYear + " and  " +
                   " LeadID not in (Select LeadID From (Select WarehouseID,LeadID,LeadNo From  " +
                   " (Select WarehouseID,LeadID,LeadNo,CancelDate=Case when CancelDate is not null then CancelDate  " +
                   " when CancelDate <> '' then CancelDate else UpdateDate end  " +
                   " From t_SalesLeadManagement where LeadDate < '" + _FirstDayofMonth + "'  " +
                   " and Status=4 ) a where CancelDate < '" + _FirstDayofMonth + "'  " +
                   " Union All  " +
                   " Select WarehouseID,LeadID,LeadNo  " +
                   " From t_SalesLeadManagement where LeadDate < '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                   " and Status=3 ) a))  " +
                   " group by LeadNo) Main where ExpExecuteDate > '" + _LastDateOfMonth + "' " +// --last day of selected month  
                   " ) " +
                   " group by ShowroomCode,CustomerType  ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSLeadManagement.LeadManagementRow oShiftedLeadRow = oDSShiftedLead.LeadManagement.NewLeadManagementRow();

                    oShiftedLeadRow.Outlet = reader["Outlet"].ToString();
                    oShiftedLeadRow.Channel = reader["Channel"].ToString();
                    oShiftedLeadRow.Qty = Convert.ToInt32(reader["Qty"]);
                    oShiftedLeadRow.Value = Convert.ToDouble(reader["Amount"]);

                    oDSShiftedLead.LeadManagement.AddLeadManagementRow(oShiftedLeadRow);
                    oDSShiftedLead.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion

            #region Cancel Lead
            cmd = DBController.Instance.GetCommand();

            sSQL = " Select ShowroomCode as Outlet,  " +
                   " Channel=Case when CustomerType=1 then 'Retail'  " +
                   " when CustomerType=3 then 'B2B'  " +
                   " when CustomerType=5 then 'Dealer'  " +
                   " when CustomerType=6 then 'e-Store'  " +
                   " else 'Other' end,Count(LeadID) as Qty,  " +
                   " sum(LeadAmount) as Amount " +
                   " From t_SalesLeadManagement a, t_showroom b " +
                   " where a.warehouseid=b.warehouseid and month(ExpExecuteDate)= " + nMonth + " and Year(ExpExecuteDate)= " + nYear + " and Status=4  " +
                   " group by ShowroomCode,CustomerType  ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSLeadManagement.LeadManagementRow oCancelLeadRow = oDSCancelLead.LeadManagement.NewLeadManagementRow();

                    oCancelLeadRow.Outlet = reader["Outlet"].ToString();
                    oCancelLeadRow.Channel = reader["Channel"].ToString();
                    oCancelLeadRow.Qty = Convert.ToInt32(reader["Qty"]);
                    oCancelLeadRow.Value = Convert.ToDouble(reader["Amount"]);

                    oDSCancelLead.LeadManagement.AddLeadManagementRow(oCancelLeadRow);
                    oDSCancelLead.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion

            #region Conversion Lead
            cmd = DBController.Instance.GetCommand();

            sSQL = " Select ShowroomCode as Outlet, " +
                   " Channel=Case when CustomerType=1 then 'Retail'  " +
                   " when CustomerType=3 then 'B2B'  " +
                   " when CustomerType=5 then 'Dealer'  " +
                   " when CustomerType=6 then 'e-Store'  " +
                   " else 'Other' end, count(InvoiceID) as Qty,sum(InvoiceAmount) as Amount  " +
                   " From t_SalesLeadManagement a,t_SalesInvoice b ,t_showroom c " +
                   " where a.InvoiceNo=b.InvoiceNo and a.WarehouseID=b.WarehouseID and a.WarehouseID=c.warehouseid and  " +
                   " month(ExpExecuteDate)= " + nMonth + " and Year(ExpExecuteDate)= " + nYear + " and Status=3  " +
                   " group by ShowroomCode,CustomerType  ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSLeadManagement.LeadManagementRow oConversionLeadRow = oDSConversion.LeadManagement.NewLeadManagementRow();

                    oConversionLeadRow.Outlet = reader["Outlet"].ToString();
                    oConversionLeadRow.Channel = reader["Channel"].ToString();
                    oConversionLeadRow.Qty = Convert.ToInt32(reader["Qty"]);
                    oConversionLeadRow.Value = Convert.ToDouble(reader["Amount"]);

                    oDSConversion.LeadManagement.AddLeadManagementRow(oConversionLeadRow);
                    oDSConversion.AcceptChanges();
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
            sSQL = " Select ShowroomCode as Outlet, Channel,IsNull(AreaName,'') as AreaName, " +
                   " IsNull(TerritoryName,'') as TerritoryName  from t_Showroom  a,  " +
                   " (Select CustomerID, AreaShortName as AreaName, AreaSort, TerritoryShortName as TerritoryName,   " +
                   " TerritorySort from DWDB.dbo.t_CustomerDetails Where CompanyName = 'TEL' and AreaShortName Is Not Null) b, " +
                   " (Select 'Retail' as Channel UNION ALL Select 'B2B' as Channel UNION ALL " +
                   " Select 'Dealer' as Channel UNION ALL Select 'e-Store' as Channel UNION ALL " +
                   " Select 'Other' as Channel) C Where a.CustomerID=b.CustomerID Order by AreaSort, TerritorySort, ShowroomCode ";
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
                    _oData.Channel = reader["Channel"].ToString();

                    //Target
                    DSLeadManagement oDSFilteredTarget = new DSLeadManagement();
                    DataRow[] oDRTarget = oDSTarget.LeadManagement.Select(" Outlet= '" + _oData.Outlet + "' and Channel = '"+ _oData.Channel + "'");
                    oDSFilteredTarget.Merge(oDRTarget);
                    oDSFilteredTarget.AcceptChanges();

                    foreach (DSLeadManagement.LeadManagementRow oTargetRow in oDSFilteredTarget.LeadManagement)
                    {
                        _oData.TargetQty = Convert.ToInt32(oTargetRow.Qty);
                        _oData.TargetValue = Convert.ToDouble(oTargetRow.Value);
                    }

                    //Initial
                    DSLeadManagement oDSFilteredInitialLead = new DSLeadManagement();
                    DataRow[] oDRInitialLead = oDSInitialLead.LeadManagement.Select(" Outlet= '" + _oData.Outlet + "' and Channel = '" + _oData.Channel + "'");
                    oDSFilteredInitialLead.Merge(oDRInitialLead);
                    oDSFilteredInitialLead.AcceptChanges();

                    foreach (DSLeadManagement.LeadManagementRow oInitialRow in oDSFilteredInitialLead.LeadManagement)
                    {
                        _oData.InitialLeadQty = Convert.ToInt32(oInitialRow.Qty);
                        _oData.InitialLeadValue = Convert.ToDouble(oInitialRow.Value);
                    }

                    //New Lead
                    DSLeadManagement oDSFilteredNewLead = new DSLeadManagement();
                    DataRow[] oDRNewLead = oDSNewLead.LeadManagement.Select(" Outlet= '" + _oData.Outlet + "' and Channel = '" + _oData.Channel + "'");
                    oDSFilteredNewLead.Merge(oDRNewLead);
                    oDSFilteredNewLead.AcceptChanges();

                    foreach (DSLeadManagement.LeadManagementRow oNewLeadRow in oDSFilteredNewLead.LeadManagement)
                    {
                        _oData.NewLeadQty = Convert.ToInt32(oNewLeadRow.Qty);
                        _oData.NewLeadValue = Convert.ToDouble(oNewLeadRow.Value);
                    }
                    //Shifted Lead
                    DSLeadManagement oDSFilteredShiftedLead = new DSLeadManagement();
                    DataRow[] oDRShiftedLead = oDSShiftedLead.LeadManagement.Select(" Outlet= '" + _oData.Outlet + "' and Channel = '" + _oData.Channel + "'");
                    oDSFilteredShiftedLead.Merge(oDRShiftedLead);
                    oDSFilteredShiftedLead.AcceptChanges();

                    foreach (DSLeadManagement.LeadManagementRow oShiftedLeadRow in oDSFilteredShiftedLead.LeadManagement)
                    {
                        _oData.ShiftedLeadQty = Convert.ToInt32(oShiftedLeadRow.Qty);
                        _oData.ShiftedLeadValue = Convert.ToDouble(oShiftedLeadRow.Value);
                    }
                    //Cancel
                    DSLeadManagement oDSFilteredCancelLead = new DSLeadManagement();
                    DataRow[] oDRCancelLead = oDSCancelLead.LeadManagement.Select(" Outlet= '" + _oData.Outlet + "' and Channel = '" + _oData.Channel + "'");
                    oDSFilteredCancelLead.Merge(oDRCancelLead);
                    oDSFilteredCancelLead.AcceptChanges();

                    foreach (DSLeadManagement.LeadManagementRow oCancelLeadRow in oDSFilteredCancelLead.LeadManagement)
                    {
                        _oData.CancelLeadQty = Convert.ToInt32(oCancelLeadRow.Qty);
                        _oData.CancelLeadValue = Convert.ToDouble(oCancelLeadRow.Value);
                    }

                    //Converted Lead
                    DSLeadManagement oDSFilteredConvertedLead = new DSLeadManagement();
                    DataRow[] oDRConvertedLead = oDSConversion.LeadManagement.Select(" Outlet= '" + _oData.Outlet + "' and Channel = '" + _oData.Channel + "'");
                    oDSFilteredConvertedLead.Merge(oDRConvertedLead);
                    oDSFilteredConvertedLead.AcceptChanges();

                    foreach (DSLeadManagement.LeadManagementRow oConvertedLeadRow in oDSFilteredConvertedLead.LeadManagement)
                    {
                        _oData.ConversionLeadQty = Convert.ToInt32(oConvertedLeadRow.Qty);
                        _oData.ConversionLeadValue = Convert.ToDouble(oConvertedLeadRow.Value);
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
        public void GetDatax(string sCompany, DateTime dDate)
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = " Select Main.*,((InitialLeadQty+NewLeadQty)- (ShiftedLeadQty+CancelledLeadQty)) as TotalLeadQty, " +
                   " ((InitialLead+NewLead)- (ShiftedLead+CancelledLeadAmt)) as TotalLeadAmt,  " +
                   " LeadTarget-((InitialLead+NewLead)- (ShiftedLead+CancelledLeadAmt)) as ShortFall,  " +
                   " isnull(nullif(ConverttoSalesAmt,0)/(nullif(InitialLead,0)+nullif(NewLead,0))*100,0) as Achievment, " +
                   " IsNull(EmployeeCode,'') as EmployeeCode,IsNull(EmployeeName,'Not Assign') as EmployeeName  " +
                   " From  " +
                   " (  " +
                   " Select ShowroomCode,SalesPersonID,Channel,  " +
                   " sum(isnull(LeadTarget,0)) as LeadTarget,  " +
                   " sum(isnull(InitialLeadQty,0)) as InitialLeadQty,sum(isnull(InitialLead,0)) as InitialLead,  " +
                   " sum(isnull(NewLeadQty,0)) as NewLeadQty,sum(isnull(NewLead,0)) as NewLead,  " +
                   " sum(isnull(ShiftedLeadQty,0)) as ShiftedLeadQty,sum(isnull(ShiftedLead,0)) as ShiftedLead,  " +
                   " sum(isnull(CancelledLeadQty,0)) as CancelledLeadQty,sum(isnull(CancelledLeadAmt,0)) as CancelledLeadAmt,  " +
                   " sum(isnull(ConverttoSalesQty,0)) as ConverttoSalesQty,sum(isnull(ConverttoSalesAmt,0)) as ConverttoSalesAmt  " +
                   " From  " +
                   " (  " +//--Target---
                   " Select ShowroomCode,SalesPersonID,Channel,sum(TargetAmount) as LeadTarget,0 as InitialLeadQty,0 as InitialLead, 0 as NewLeadQty,0 as NewLead,  " +
                   " 0 as ShiftedLeadQty,0 as ShiftedLead,0 as CancelledLeadQty,0 as CancelledLeadAmt,0 as ConverttoSalesQty,0 as ConverttoSalesAmt  " +
                   " From t_PLanExecutiveLeadTarget a, t_Showroom b where a.customerid=b.customerid and  " +
                   " TMonth=2 and TYear= 2017 " +
                   " group by ShowroomCode,SalesPersonID,Channel  " +
                   " Union All  " +
                // ---End Target---
                // ----InitialLead---
                   " Select ShowroomCode,SalesPersonID,  " +
                   " Channel=Case when CustomerType=1 then 'Retail'  " +
                   " when CustomerType=3 then 'B2B'  " +
                   " when CustomerType=5 then 'Dealer'  " +
                   " when CustomerType=6 then 'e-Store'  " +
                   " else 'Other' end,0 as LeadTarget,count(LeadID) as InitialLeadQty,  " +
                   " sum(LeadAmount) as InitialLead,0 as NewLeadQty,0 as NewLead,  " +
                   " 0 as ShiftedLeadQty,0 as ShiftedLead,0 as CancelledLeadQty,  " +
                   " 0 as CancelledLeadAmt,0 as ConverttoSalesQty,0 as ConverttoSalesAmt  " +
                   " From t_SalesLeadManagement a, t_showroom b " +
                   " where a.warehouseid=b.warehouseid and month(ExpExecuteDate)= 2 and Year(ExpExecuteDate)= 2017 and LeadDate<'01-FEB-2017' and LeadID not in  " +
                   " (Select LeadID From (Select WarehouseID,LeadID,LeadNo From  " +
                   " (Select WarehouseID,LeadID,LeadNo,CancelDate=Case when CancelDate is not null then CancelDate  " +
                   " when CancelDate<>'' then CancelDate else UpdateDate end  " +
                   " From t_SalesLeadManagement where LeadDate<'01-FEB-2017'  " +
                   " and Status=4 ) a where CancelDate<'01-FEB-2017'  " +
                   " Union All  " +
                   " Select WarehouseID,LeadID,LeadNo  " +
                   " From t_SalesLeadManagement where LeadDate<'01-FEB-2017' and InvoiceDate<'01-FEB-2017'  " +
                   " and Status=3 ) a)  " +
                   " group by ShowroomCode,SalesPersonID,CustomerType  " +
                   " Union All  " +
                // ---End InitialLead-----
                // ---New Lead-----
                   " Select ShowroomCode,SalesPersonID,  " +
                   " Channel=Case when CustomerType=1 then 'Retail'  " +
                   " when CustomerType=3 then 'B2B'  " +
                   " when CustomerType=5 then 'Dealer'  " +
                   " when CustomerType=6 then 'e-Store'  " +
                   " else 'Other' end,0 as LeadTarget,0 as InitialLeadQty,0 as InitialLead,count(LeadID) as NewLeadQty,  " +
                   " sum(LeadAmount) as NewLead, 0 as ShiftedLeadQty,0 as ShiftedLead,0 as CancelledLeadQty,  " +
                   " 0 as CancelledLeadAmt,0 as ConverttoSalesQty,0 as ConverttoSalesAmt  " +
                   " From t_SalesLeadManagement a, t_showroom b " +
                   " where a.warehouseid=b.warehouseid and month(ExpExecuteDate)= 2 and Year(ExpExecuteDate)=2017 " +
                   " and Month(LeadDate)= 2 and Year(LeadDate)= 2017 group by ShowroomCode,SalesPersonID,CustomerType  " +
                   " Union All  " +
                // ---End New Lead----- "+
                // ----ShiftedLead---
                   " Select ShowroomCode,SalesPersonID,  " +
                   " Channel=Case when CustomerType=1 then 'Retail'  " +
                   " when CustomerType=3 then 'B2B'  " +
                   " when CustomerType=5 then 'Dealer'  " +
                   " when CustomerType=6 then 'e-Store'  " +
                   " else 'Other' end,0 as LeadTarget,0 as InitialLeadQty, 0 as InitialLead,0 as NewLeadQty, 0 as NewLead,  " +
                   " count(LeadID) as ShiftedLeadQty,sum(LeadAmount) as ShiftedLead,0 as CancelledLeadQty,0 as CancelledLeadAmt,  " +
                   " 0 as ConverttoSalesQty,0 as ConverttoSalesAmt  " +
                   " From t_SalesLeadManagement a, t_showroom b where a.warehouseid=b.warehouseid and LeadNo in  " +
                   " (Select LeadNo From  " +
                   " (Select LeadNo,max(ExpExecuteDate) ExpExecuteDate From t_SalesLeadManagementHistory where LeadNo in (  " +
                   " Select LeadNo From t_SalesLeadManagement  " +
                   " where month(ExpExecuteDate)= 2 and Year(ExpExecuteDate)= 2017 and  " +
                   " LeadID not in (Select LeadID From (Select WarehouseID,LeadID,LeadNo From  " +
                   " (Select WarehouseID,LeadID,LeadNo,CancelDate=Case when CancelDate is not null then CancelDate  " +
                   " when CancelDate<>'' then CancelDate else UpdateDate end  " +
                   " From t_SalesLeadManagement where LeadDate<'01-FEB-2017'  " +
                   " and Status=4 ) a where CancelDate<'01-FEB-2017'  " +
                   " Union All  " +
                   " Select WarehouseID,LeadID,LeadNo  " +
                   " From t_SalesLeadManagement where LeadDate<'01-FEB-2017' and InvoiceDate<'01-FEB-2017'  " +
                   " and Status=3 ) a))  " +
                   " group by LeadNo) Main where ExpExecuteDate > '28-FEB-2017' " +// --last day of selected month  
                   " ) " +
                   " group by ShowroomCode,SalesPersonID,CustomerType  " +
                   " Union All  " +
                // ----END ShiftedLead---
                // ----Cancel----
                   " Select ShowroomCode,SalesPersonID,  " +
                   " Channel=Case when CustomerType=1 then 'Retail'  " +
                   " when CustomerType=3 then 'B2B'  " +
                   " when CustomerType=5 then 'Dealer'  " +
                   " when CustomerType=6 then 'e-Store'  " +
                   " else 'Other' end,0 as LeadTarget,0 as InitialLeadQty,0 as InitialLead, 0 as NewLeadQty,0 as NewLead,  " +
                   " 0 as ShiftedLeadQty,0 as ShiftedLead,Count(LeadID) as CancelledLeadQty,  " +
                   " sum(LeadAmount) as CancelledLeadAmt,0 as ConverttoSalesQty,0 as ConverttoSalesAmt  " +
                   " From t_SalesLeadManagement a, t_showroom b " +
                   " where a.warehouseid=b.warehouseid and month(ExpExecuteDate)= 2 and Year(ExpExecuteDate)= 2017 and Status=4  " +
                   " group by ShowroomCode,SalesPersonID,CustomerType  " +
                   " Union All  " +
                // ----END Cancel----
                // ---ConverttoSalesAmt---
                   " Select ShowroomCode,a.SalesPersonID,  " +
                   " Channel=Case when CustomerType=1 then 'Retail'  " +
                   " when CustomerType=3 then 'B2B'  " +
                   " when CustomerType=5 then 'Dealer'  " +
                   " when CustomerType=6 then 'e-Store'  " +
                   " else 'Other' end,0 as LeadTarget,0 as InitialLeadQty,0 as InitialLead, 0 as NewLeadQty,0 as NewLead,  " +
                   " 0 as ShiftedLeadQty,0 as ShiftedLead,0 as CancelledLeadQty,  " +
                   " 0 as CancelledLeadAmt,count(InvoiceID) as ConverttoSalesQty,sum(InvoiceAmount) as ConverttoSalesAmt  " +
                   " From t_SalesLeadManagement a,t_SalesInvoice b ,t_showroom c " +
                   " where a.InvoiceNo=b.InvoiceNo and a.WarehouseID=b.WarehouseID and a.WarehouseID=c.warehouseid and  " +
                   " month(ExpExecuteDate)= 2 and Year(ExpExecuteDate)= 2017 and Status=3  " +
                   " group by ShowroomCode,a.SalesPersonID,CustomerType  " +
                // ---END ConverttoSalesAmt----
                   " ) a group by ShowroomCode,SalesPersonID,Channel  " +
                   " ) Main left outer join TELSysdB.dbo.v_Employeedetails b on (Main.SalesPersonID=b.EmployeeID) ";
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

        public void GetData(string sCompany, DateTime dDate)
        {
            TELLib _oTELLib = new TELLib();
            DSLeadManagement oDSTarget = new DSLeadManagement();
            DSLeadManagement oDSInitialLead = new DSLeadManagement();
            DSLeadManagement oDSNewLead = new DSLeadManagement();
            DSLeadManagement oDSShiftedLead = new DSLeadManagement();
            DSLeadManagement oDSCancelLead = new DSLeadManagement();
            DSLeadManagement oDSConversion = new DSLeadManagement();

            DateTime dFromDate = DateTime.Now.Date;
            DateTime dToDate = dFromDate.AddDays(1);
            DateTime dLastDate = dFromDate.AddDays(-1);


            int nMonth = dFromDate.Month;
            int nYear = dFromDate.Year;
            DateTime _FirstDayofMonth = _oTELLib.FirstDayofMonth(dFromDate);
            DateTime _LastDateOfMonth = _oTELLib.LastDayofMonth(dFromDate);



            DateTime _FirstDayofLastMonth = _oTELLib.FirstDayofLastMonth(dFromDate);

            DateTime _FirstDayofThisYear = _oTELLib.FirstDayofThisYear(dFromDate);
            DateTime _FirstDayofLastYear = _FirstDayofThisYear.AddYears(-1);


            string sSQL = "";

            #region Target
            OleDbCommand cmd = DBController.Instance.GetCommand();

            sSQL = " Select ShowroomCode as Outlet, Case when Channel=3 then 'Dealer' " +
                   " when Channel=4 then 'Retail' when Channel= 13 then 'B2B' " +
                   " when Channel= 16 then 'e-Store' else 'Other' end as Channel , Sum(TargetQty) as Qty, sum(TargetAmount) as Amount " +
                   " From t_PLanExecutiveLeadTarget a, t_Showroom b where a.customerid=b.customerid and TMonth=" + nMonth + " and TYear= " + nYear + " and TargetType = " + (int)Dictionary.PlanVersionType.ExecutiveLeadTarget + " " +
                   " group by ShowroomCode, Channel ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSLeadManagement.LeadManagementRow oTargetRow = oDSTarget.LeadManagement.NewLeadManagementRow();

                    oTargetRow.Outlet = reader["Outlet"].ToString();
                    oTargetRow.Channel = reader["Channel"].ToString();
                    oTargetRow.Qty = Convert.ToInt32(reader["Qty"]);
                    oTargetRow.Value = Convert.ToDouble(reader["Amount"]);

                    oDSTarget.LeadManagement.AddLeadManagementRow(oTargetRow);
                    oDSTarget.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion

            #region Lead Query
            cmd = DBController.Instance.GetCommand();

            sSQL = String.Format(@"Select Channel,Outlet,LeadType,
                    sum(LeadAmount) Amount,sum(Qty) Qty From 
                    (
                    Select Channel=Case when CustomerType=3 then 'B2B'  
                    when CustomerType=5 then 'Dealer'  
                    when CustomerType=6 then 'e-Store'  
                    else 'Retail' end,ShowroomCode as Outlet,
                    LeadType,sum(LeadAmount) LeadAmount,count(LeadNo) as Qty 
                    From 
                    (
                    --Opening Lead--
                    Select distinct WarehouseID,a.CustomerType, LeadNo,
                    LeadAmount,case when LeadDate < '{0}' and InvoiceDate < '{0}'
                    and Status = 3 then 1
                    when(Case when CancelDate is not null then CancelDate
                    when CancelDate <> '' then CancelDate else UpdateDate end) < '{0}'
                    and Status = 4 then 1 else 0 end as IsExcludeLead,
                    'Opening Lead' as LeadType
                    From t_SalesLeadManagement a
                    where month(ExpExecuteDate) = {2} and Year(ExpExecuteDate) = {3} and LeadDate < '{0}'
                    --END Opening Lead--
                    Union All
                    --New Lead--
                    Select distinct WarehouseID, 
                    CustomerType,LeadNo,
                    LeadAmount,0 as IsExcludeLead,'New Lead' as LeadType
                    From t_SalesLeadManagement a 
                    where month(ExpExecuteDate)=  {2}  and Year(ExpExecuteDate) =  {3}  
                    and Month(LeadDate)=  {2}  and Year(LeadDate)=  {3}  
                    --End New Lead--
                    Union All
                    --Shifted Lead--
                    Select distinct a.WarehouseID, 
                    a.CustomerType,a.LeadNo,
                    LeadAmount,0 as IsExcludeLead,'Shifted Lead' as LeadType 
                    From t_SalesLeadManagement a,
                    (
                    Select * From t_SalesLeadManagementHistory 
                    where Month(ExpExecuteDate)={2} and year(ExpExecuteDate)={3}
                    ) b  
                    where a.ExpExecuteDate>'{1}' 
                    and a.LeadNo=b.LeadNo and a.WarehouseID=b.WarehouseID
                    and a.Status not in (3,4)
                    --END Shifted Lead--
                    Union All
                    --Cancel Lead---
                    Select distinct a.WarehouseID, 
                    a.CustomerType,a.LeadNo,
                    LeadAmount,0 as IsExcludeLead,'Cancel Lead' as LeadType 
                    From t_SalesLeadManagement a  
                    where month(ExpExecuteDate)=  {2} and Year(ExpExecuteDate)=  {3}
                    and Status=4 
                    --End Cancel Lead---
                    Union All
                    --Conversion Lead---
                    Select distinct a.WarehouseID, 
                    a.CustomerType,a.LeadNo,
                    NetSales,0 as IsExcludeLead,'Conversion Lead' as LeadType 
                    From t_SalesLeadManagement a,
                    (
                    Select InvoiceNo,InvoiceDate,sum(NetSales) NetSales 
                    From DWDB.DBO.t_InvoiceWiseSalesDetail 
                    group by InvoiceNo,InvoiceDate) b 
                    where a.InvoiceNo=b.InvoiceNo and 
                    month(b.InvoiceDate)=  {2} and Year(b.InvoiceDate)=  {3}
                    and Status=3 
                    --End Conversion Lead---
                    ) a,t_Showroom b 
                    where a.WarehouseID=b.WarehouseID
                    group by ShowroomCode,LeadType,CustomerType
                    ) main group by Channel,Outlet,LeadType", _FirstDayofMonth, _LastDateOfMonth, nMonth, nYear);


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["LeadType"].ToString() == "Opening Lead")
                    {
                        DSLeadManagement.LeadManagementRow oInitialRow = oDSInitialLead.LeadManagement.NewLeadManagementRow();
                        oInitialRow.Outlet = reader["Outlet"].ToString();
                        oInitialRow.Channel = reader["Channel"].ToString();
                        oInitialRow.Qty = Convert.ToInt32(reader["Qty"]);
                        oInitialRow.Value = Convert.ToDouble(reader["Amount"]);
                        oDSInitialLead.LeadManagement.AddLeadManagementRow(oInitialRow);
                        oDSInitialLead.AcceptChanges();
                    }

                    if (reader["LeadType"].ToString() == "New Lead")
                    {
                        DSLeadManagement.LeadManagementRow oNewLeadRow = oDSNewLead.LeadManagement.NewLeadManagementRow();
                        oNewLeadRow.Outlet = reader["Outlet"].ToString();
                        oNewLeadRow.Channel = reader["Channel"].ToString();
                        oNewLeadRow.Qty = Convert.ToInt32(reader["Qty"]);
                        oNewLeadRow.Value = Convert.ToDouble(reader["Amount"]);
                        oDSNewLead.LeadManagement.AddLeadManagementRow(oNewLeadRow);
                        oDSNewLead.AcceptChanges();
                    }

                    if (reader["LeadType"].ToString() == "Shifted Lead")
                    {
                        DSLeadManagement.LeadManagementRow oShiftedLeadRow = oDSShiftedLead.LeadManagement.NewLeadManagementRow();
                        oShiftedLeadRow.Outlet = reader["Outlet"].ToString();
                        oShiftedLeadRow.Channel = reader["Channel"].ToString();
                        oShiftedLeadRow.Qty = Convert.ToInt32(reader["Qty"]);
                        oShiftedLeadRow.Value = Convert.ToDouble(reader["Amount"]);
                        oDSShiftedLead.LeadManagement.AddLeadManagementRow(oShiftedLeadRow);
                        oDSShiftedLead.AcceptChanges();
                    }

                    if (reader["LeadType"].ToString() == "Cancel Lead")
                    {
                        DSLeadManagement.LeadManagementRow oCancelLeadRow = oDSCancelLead.LeadManagement.NewLeadManagementRow();
                        oCancelLeadRow.Outlet = reader["Outlet"].ToString();
                        oCancelLeadRow.Channel = reader["Channel"].ToString();
                        oCancelLeadRow.Qty = Convert.ToInt32(reader["Qty"]);
                        oCancelLeadRow.Value = Convert.ToDouble(reader["Amount"]);
                        oDSCancelLead.LeadManagement.AddLeadManagementRow(oCancelLeadRow);
                        oDSCancelLead.AcceptChanges();
                    }

                    if (reader["LeadType"].ToString() == "Conversion Lead")
                    {
                        DSLeadManagement.LeadManagementRow oConversionLeadRow = oDSConversion.LeadManagement.NewLeadManagementRow();
                        oConversionLeadRow.Outlet = reader["Outlet"].ToString();
                        oConversionLeadRow.Channel = reader["Channel"].ToString();
                        oConversionLeadRow.Qty = Convert.ToInt32(reader["Qty"]);
                        oConversionLeadRow.Value = Convert.ToDouble(reader["Amount"]);
                        oDSConversion.LeadManagement.AddLeadManagementRow(oConversionLeadRow);
                        oDSConversion.AcceptChanges();
                    }
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
            
            cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = @"Select ShowroomCode as Outlet, Channel,IsNull(AreaName,'') as AreaName, 
                    IsNull(TerritoryName,'') as TerritoryName  from t_Showroom  a,  
                    (Select Areaid,a.CustomerID, AreaShortName as AreaName, AreaSort, TerritoryShortName as TerritoryName,   
                    TerritorySort from TELSysDB.dbo.v_CustomerDetails a,TELSysDB.dbo.t_Showroom b 
                    Where a.CustomerID=b.CustomerID and AreaShortName Is Not Null) b, 
                    (
                    Select 'Retail' as Channel 
                    UNION ALL Select 'B2B' as Channel 
                    UNION ALL Select 'Dealer' as Channel 
                    UNION ALL Select 'e-Store' as Channel 
                    UNION ALL Select 'Other' as Channel
                    ) C Where a.CustomerID=b.CustomerID 
                    and Areaid in (18,19,318)
                    Order by AreaSort, TerritorySort, ShowroomCode";
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
                    _oData.Channel = reader["Channel"].ToString();

                    //Target
                    DSLeadManagement oDSFilteredTarget = new DSLeadManagement();
                    DataRow[] oDRTarget = oDSTarget.LeadManagement.Select(" Outlet= '" + _oData.Outlet + "' and Channel = '" + _oData.Channel + "'");
                    oDSFilteredTarget.Merge(oDRTarget);
                    oDSFilteredTarget.AcceptChanges();

                    foreach (DSLeadManagement.LeadManagementRow oTargetRow in oDSFilteredTarget.LeadManagement)
                    {
                        _oData.TargetQty = Convert.ToInt32(oTargetRow.Qty);
                        _oData.TargetValue = Convert.ToDouble(oTargetRow.Value);
                    }

                    //Initial
                    DSLeadManagement oDSFilteredInitialLead = new DSLeadManagement();
                    DataRow[] oDRInitialLead = oDSInitialLead.LeadManagement.Select(" Outlet= '" + _oData.Outlet + "' and Channel = '" + _oData.Channel + "'");
                    oDSFilteredInitialLead.Merge(oDRInitialLead);
                    oDSFilteredInitialLead.AcceptChanges();

                    foreach (DSLeadManagement.LeadManagementRow oInitialRow in oDSFilteredInitialLead.LeadManagement)
                    {
                        _oData.InitialLeadQty = Convert.ToInt32(oInitialRow.Qty);
                        _oData.InitialLeadValue = Convert.ToDouble(oInitialRow.Value);
                    }

                    //New Lead
                    DSLeadManagement oDSFilteredNewLead = new DSLeadManagement();
                    DataRow[] oDRNewLead = oDSNewLead.LeadManagement.Select(" Outlet= '" + _oData.Outlet + "' and Channel = '" + _oData.Channel + "'");
                    oDSFilteredNewLead.Merge(oDRNewLead);
                    oDSFilteredNewLead.AcceptChanges();

                    foreach (DSLeadManagement.LeadManagementRow oNewLeadRow in oDSFilteredNewLead.LeadManagement)
                    {
                        _oData.NewLeadQty = Convert.ToInt32(oNewLeadRow.Qty);
                        _oData.NewLeadValue = Convert.ToDouble(oNewLeadRow.Value);
                    }
                    //Shifted Lead
                    DSLeadManagement oDSFilteredShiftedLead = new DSLeadManagement();
                    DataRow[] oDRShiftedLead = oDSShiftedLead.LeadManagement.Select(" Outlet= '" + _oData.Outlet + "' and Channel = '" + _oData.Channel + "'");
                    oDSFilteredShiftedLead.Merge(oDRShiftedLead);
                    oDSFilteredShiftedLead.AcceptChanges();

                    foreach (DSLeadManagement.LeadManagementRow oShiftedLeadRow in oDSFilteredShiftedLead.LeadManagement)
                    {
                        _oData.ShiftedLeadQty = Convert.ToInt32(oShiftedLeadRow.Qty);
                        _oData.ShiftedLeadValue = Convert.ToDouble(oShiftedLeadRow.Value);
                    }
                    //Cancel
                    DSLeadManagement oDSFilteredCancelLead = new DSLeadManagement();
                    DataRow[] oDRCancelLead = oDSCancelLead.LeadManagement.Select(" Outlet= '" + _oData.Outlet + "' and Channel = '" + _oData.Channel + "'");
                    oDSFilteredCancelLead.Merge(oDRCancelLead);
                    oDSFilteredCancelLead.AcceptChanges();

                    foreach (DSLeadManagement.LeadManagementRow oCancelLeadRow in oDSFilteredCancelLead.LeadManagement)
                    {
                        _oData.CancelLeadQty = Convert.ToInt32(oCancelLeadRow.Qty);
                        _oData.CancelLeadValue = Convert.ToDouble(oCancelLeadRow.Value);
                    }

                    //Converted Lead
                    DSLeadManagement oDSFilteredConvertedLead = new DSLeadManagement();
                    DataRow[] oDRConvertedLead = oDSConversion.LeadManagement.Select(" Outlet= '" + _oData.Outlet + "' and Channel = '" + _oData.Channel + "'");
                    oDSFilteredConvertedLead.Merge(oDRConvertedLead);
                    oDSFilteredConvertedLead.AcceptChanges();

                    foreach (DSLeadManagement.LeadManagementRow oConvertedLeadRow in oDSFilteredConvertedLead.LeadManagement)
                    {
                        _oData.ConversionLeadQty = Convert.ToInt32(oConvertedLeadRow.Qty);
                        _oData.ConversionLeadValue = Convert.ToDouble(oConvertedLeadRow.Value);
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
                _oData.Channel = oData.Channel;

                _oData.TargetValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.TargetValue));

                _oData.InitialLeadQtyText = oData.InitialLeadQty.ToString();
                _oData.InitialLeadValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.InitialLeadValue));

                _oData.NewLeadQtyText = oData.NewLeadQty.ToString();
                _oData.NewLeadValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.NewLeadValue));

                double _LeadVal = oData.InitialLeadValue + oData.NewLeadValue;

                _oData.ShiftedLeadQtyText = oData.ShiftedLeadQty.ToString();
                _oData.ShiftedLeadValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.ShiftedLeadValue));

                _oData.CancelLeadQtyText = oData.CancelLeadQty.ToString();
                _oData.CancelLeadValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CancelLeadValue));

                _oData.ConversionLeadQtyText = oData.ConversionLeadQty.ToString();
                _oData.ConversionLeadValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.ConversionLeadValue));

                int nTotalLeadQty = ((oData.InitialLeadQty + oData.NewLeadQty) - (oData.ShiftedLeadQty + oData.CancelLeadQty));
                _oData.TotalLeadQtyText = nTotalLeadQty.ToString();

                double _TotalLeadValue = ((oData.InitialLeadValue + oData.NewLeadValue) - (oData.ShiftedLeadValue + oData.CancelLeadValue));
                _oData.TotalLeadValueText = ExcludeDecimal(_oTELLib.TakaFormat(_TotalLeadValue));

                _oData.ShortfallLeadValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.TargetValue - _TotalLeadValue));

                //_oData.TotalLeadValueText = "";
                if (_LeadVal > 0)
                {
                    _oData.ConversionRationValueText = Convert.ToString(Math.Round((oData.ConversionLeadValue / _LeadVal) * 100));
                }
                else
                {
                    _oData.ConversionRationValueText = "0";
                }
                
                eList.Add(_oData);
            }
            return eList;

        }
    }
}

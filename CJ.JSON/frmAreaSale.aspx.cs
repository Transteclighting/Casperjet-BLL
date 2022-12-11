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

using Newtonsoft.Json;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.ANDROID;
using CJ.Class.Library;

public partial class frmAreaSale : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            //string sType = c.Request.Form["Type"].Trim();

            TELs oTELs = new TELs();
            DBController.Instance.OpenNewConnection();
            //oTELs.RefreshOutlet();
            DBController.Instance.CloseConnection();
            List<Data> eList = new List<Data>();

            TELLib oTELLib = new TELLib();
            foreach (TEL oTEL in oTELs)
            {
                Data _oData = new Data();
                _oData.Value = "Success";
                _oData.AreaID = oTEL.AreaID.ToString();
                _oData.AreaName = oTEL.AreaName;
                _oData.Outlet = oTEL.Outlet;
                _oData.DTD = ExcludeDecimal(oTELLib.TakaFormat(oTEL.DTD));
                _oData.LD = ExcludeDecimal(oTELLib.TakaFormat(oTEL.LD));
                _oData.MTD = ExcludeDecimal(oTELLib.TakaFormat(oTEL.MTD));
                eList.Add(_oData);
            }
            string sOutput = JsonConvert.SerializeObject(eList, Formatting.Indented);
            Response.Write(sOutput.ToString());
        }
    }
    private string ExcludeDecimal(string sAmount)
    {
        string sResult = "";
        sResult = sAmount.Remove(sAmount.Length - 3);
        return sResult;
    }
    public class Data
    {
        public string AreaID;
        public string AreaName;
        public string Outlet;
        public string DTD;
        public string LD;
        public string MTD;
        public string Value;
    }
}

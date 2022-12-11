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

public partial class jSalesQty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            string sUser = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();
            TELs oTELs = new TELs();
            DBController.Instance.OpenNewConnection();
            oTELs.GetSalesQty(sCompany);
            DBController.Instance.CloseConnection();

            Data _oData = new Data();
            Datas _oDatas = new Datas();
            Data _oDataTotal = new Data();
            Data _oDataPG = new Data();
            Data _oDataMAG = new Data();
            Data _oDataBrand = new Data();
            //int nCount = 0;
            foreach (TEL oTEL in oTELs)
            {
                //if (nCount == 0)
                //{
                //    _oDataTotal = new Data();
                //    _oDatas.Add(_oDataTotal);
                //    _oDataTotal.Outlet = "Total";
                //    _oDataTotal.Type = "Total";
                //    _oDataTotal.Value = "Success";
                //    nCount++;
                //}
                if (_oDataPG.PGName != oTEL.PGName)
                {
                    _oDataPG = new Data();
                    _oDatas.Add(_oDataPG);
                    _oDataPG.PGName = oTEL.PGName;
                    _oDataPG.BrandName = oTEL.PGName;
                    _oDataPG.Type = "PG";
                    _oDataPG.Value = "Success";
                }
                if (_oDataMAG.MAGName != oTEL.MAGName)
                {
                    _oDataMAG = new Data();
                    _oDatas.Add(_oDataMAG);
                    _oDataMAG.MAGName = oTEL.MAGName;
                    _oDataMAG.BrandName = oTEL.MAGName;
                    _oDataMAG.Type = "MAG";
                    _oDataMAG.Value = "Success";
                }

                _oDataBrand = new Data();
                _oDataBrand.Value = "Success";

                _oDataBrand.BrandName = oTEL.BrandName;
                _oDataBrand.DTDQty = oTEL.DTDQty;
                _oDataBrand.LDQty = oTEL.LDQty;
                _oDataBrand.MTDQty = oTEL.MTDQty;
                _oDataBrand.LMQty = oTEL.LMQty;
                _oDataBrand.YTDQty = oTEL.YTDQty;
                _oDataBrand.Type = "Brand";
                _oDatas.Add(_oDataBrand);

                //_oDataTotal.DTD = _oDataTotal.DTD + oTEL.DTD;
                //_oDataTotal.LD = _oDataTotal.LD + oTEL.LD;
                //_oDataTotal.MTD = _oDataTotal.MTD + oTEL.MTD;
                //_oDataTotal.LM = _oDataTotal.LM + oTEL.LM;
                //_oDataTotal.YTD = _oDataTotal.YTD + oTEL.YTD;

                _oDataPG.DTDQty = _oDataPG.DTDQty + oTEL.DTDQty;
                _oDataPG.LDQty = _oDataPG.LDQty + oTEL.LDQty;
                _oDataPG.MTDQty = _oDataPG.MTDQty + oTEL.MTDQty;
                _oDataPG.LMQty = _oDataPG.LMQty + oTEL.LMQty;
                _oDataPG.YTDQty = _oDataPG.YTDQty + oTEL.YTDQty;

                _oDataMAG.DTDQty = _oDataMAG.DTDQty + oTEL.DTDQty;
                _oDataMAG.LDQty = _oDataMAG.LDQty + oTEL.LDQty;
                _oDataMAG.MTDQty = _oDataMAG.MTDQty + oTEL.MTDQty;
                _oDataMAG.LMQty = _oDataMAG.LMQty + oTEL.LMQty;
                _oDataMAG.YTDQty = _oDataMAG.YTDQty + oTEL.YTDQty;

            }

            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput.ToString());
        }
         
    }
    public class Data
    {
        public string PGName;
        public string MAGName;
        public string BrandName;
        public string Type;

        public int DTDQty;
        public int LDQty;
        public int MTDQty;
        public int LMQty;
        public int YTDQty;

        public string DTDQtyText;
        public string LDQtyText;
        public string LMQtyText;
        public string MTDQtyText;
        public string YTDQtyText;

        public string Value;
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
        public List<Data> getResult()
        {
            Data _oData;
            List<Data> eList = new List<Data>();
            foreach (Data oData in this)
            {
                _oData = new Data();
                _oData.PGName = oData.PGName;
                _oData.MAGName = oData.MAGName;
                _oData.BrandName = oData.BrandName;
                _oData.Type = oData.Type;
                _oData.Value = oData.Value;

                _oData.DTDQtyText = oData.DTDQty.ToString();
                _oData.LDQtyText = oData.LDQty.ToString();
                _oData.MTDQtyText = oData.MTDQty.ToString();
                _oData.LMQtyText = oData.LMQty.ToString();
                _oData.YTDQtyText = oData.YTDQty.ToString();

                eList.Add(_oData);
            }
            return eList;

        }
    }
}

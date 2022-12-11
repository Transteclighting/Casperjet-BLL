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

public partial class jRetailComsumerTran : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();
            string sMonth = c.Request.Form["Month"].Trim();
            string sYear = c.Request.Form["Year"].Trim();
            string sReportType = c.Request.Form["ReportType"].Trim();
            string sValue = c.Request.Form["Value"].Trim();

            //string sUser = "hakim";
            //string sCompany = "TEL";
            //string sMonth = "Dec";
            //string sYear = "2015";
            //string sReportType = "Outlet";
            //string sValue = "DGN";

            int nYear = Convert.ToInt32(sYear);

            Datas oDatas = new Datas();
            Data _oData = new Data();
            Datas _oDatas = new Datas(); 
            Data _oDataTotal = new Data();
            Data _oDataArea = new Data();
            Data _oDataZone = new Data();
            Data _oDataOutlet = new Data();
            int nCount = 0;

            string sType = "";
            string sDataID = "";
            #region
            if (sValue != "")
            {
                if (sValue == "Area-1")
                {
                    sDataID = "18";
                    sType = "Area";
                }
                else if (sValue == "Area-2")
                {
                    sDataID = "19";
                    sType = "Area";
                }
                else if (sValue == "Area-3")
                {
                    sDataID = "311";
                    sType = "Area";
                }
                else if (sValue == "Zone-A")
                {
                    sDataID = "175";
                    sType = "Zone";
                }
                else if (sValue == "Zone-B")
                {
                    sDataID = "135";
                    sType = "Zone";
                }
                else if (sValue == "Zone-C")
                {
                    sDataID = "313";
                    sType = "Zone";
                }
                else if (sValue == "Zone-D")
                {
                    sDataID = "312";
                    sType = "Zone";
                }
                else if (sValue == "Zone-E")
                {
                    sDataID = "314";
                    sType = "Zone";
                }
                else if (sValue == "Total")
                {
                    sDataID = "Total";
                    sType = "Total";
                }
                else
                {
                    sDataID = sValue;
                    sType = "Outlet";
                }
            }
            #endregion

            DBController.Instance.OpenNewConnection();
            if (sReportType == "Outlet")
            {
                oDatas = new Datas();
                oDatas.GetData(sCompany, nYear, sMonth);
            }
            else if (sReportType == "MAG")
            {
                oDatas = new Datas();
                oDatas.GetDataMAG(sCompany, nYear, sMonth, sType, sDataID);
            }
            DBController.Instance.CloseConnection();
            foreach (Data oData in oDatas)
            {
                if (nCount == 0)
                {
                    _oDataTotal = new Data();
                    _oDatas.Add(_oDataTotal);
                    _oDataTotal.Outlet = "Total";
                    _oDataTotal.Type = "Total";
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
                    _oDataArea.Value = "Success";

                }
                if (_oDataZone.TerritoryName != oData.TerritoryName)
                {
                    _oDataZone = new Data();
                    _oDatas.Add(_oDataZone);
                    _oDataZone.TerritoryName = oData.TerritoryName;
                    _oDataZone.Outlet = oData.TerritoryName;
                    _oDataZone.Type = "Zone";
                    _oDataZone.Value = "Success";

                }

                _oDataOutlet = new Data();
                _oDataOutlet.Value = "Success";

                _oDataOutlet.Outlet = oData.Outlet;
                
                _oDataOutlet.Type = "Outlet";

                _oDataOutlet.TotalNOC = oData.TotalNOC;
                _oDataOutlet.OldNOC = oData.OldNOC;
                _oDataOutlet.NewNOC = oData.NewNOC;
                _oDataOutlet.TotalVal = oData.TotalVal;
                _oDataOutlet.OldVal = oData.OldVal;
                _oDataOutlet.NewVal = oData.NewVal;
                _oDatas.Add(_oDataOutlet);
 
                _oDataTotal.TotalNOC = _oDataTotal.TotalNOC + oData.TotalNOC;
                _oDataTotal.OldNOC = _oDataTotal.OldNOC + oData.OldNOC;
                _oDataTotal.NewNOC = _oDataTotal.NewNOC + oData.NewNOC;
                _oDataTotal.TotalVal = _oDataTotal.TotalVal + oData.TotalVal;
                _oDataTotal.OldVal = _oDataTotal.OldVal + oData.OldVal;
                _oDataTotal.NewVal = _oDataTotal.NewVal + oData.NewVal;

                _oDataArea.TotalNOC = _oDataArea.TotalNOC + oData.TotalNOC;
                _oDataArea.OldNOC = _oDataArea.OldNOC + oData.OldNOC;
                _oDataArea.NewNOC = _oDataArea.NewNOC + oData.NewNOC;
                _oDataArea.TotalVal = _oDataArea.TotalVal + oData.TotalVal;
                _oDataArea.OldVal = _oDataArea.OldVal + oData.OldVal;
                _oDataArea.NewVal = _oDataArea.NewVal + oData.NewVal;

                _oDataZone.TotalNOC = _oDataZone.TotalNOC + oData.TotalNOC;
                _oDataZone.OldNOC = _oDataZone.OldNOC + oData.OldNOC;
                _oDataZone.NewNOC = _oDataZone.NewNOC + oData.NewNOC;
                _oDataZone.TotalVal = _oDataZone.TotalVal + oData.TotalVal;
                _oDataZone.OldVal = _oDataZone.OldVal + oData.OldVal;
                _oDataZone.NewVal = _oDataZone.NewVal + oData.NewVal;

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
        public string TerritoryName;
        public string Type;
        public string Outlet;
        public string Brand;
        public string MAGName;

        public int TotalNOC;
        public int OldNOC;
        public int NewNOC;

        public string TotalNOCText;
        public string OldNOCText;
        public string OldNOCPerc;
        public string NewNOCText;
        public string NewNOCPerc;

        public double TotalVal;
        public double OldVal;
        public double NewVal;
        public string TotalValText;
        public string OldValText;
        public string OldValPerc;
        public string NewValText;
        public string NewValPerc;

        public string Value;
        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10013";
            string sReportName = "TEL-Customer Tran Analysis";
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
        public void GetData(string sCompany, int nYear, string sMonth)
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            sSQL = " Select TranMonth, MonthName, WarehouseCode,Zone, Area, TotalNOC, " +
                   " OldCustNOC, NewCustNOC,TotalVal, OldCustVal, NewCustVal " +
                   " from  " +
                   " ( " +
                   " Select TranMonth, MonthName, WarehouseCode,  " +
                   " SUM(TotalNOC) as TotalNOC, SUM(OldCustNOC) as OldCustNOC, SUM(NewCustNOC) as NewCustNOC, " +
                   " SUM(TotalVal) as TotalVal, SUM(OldCustVal) as OldCustVal, SUM(NewCustVal) as NewCustVal " +
                   " from  " +
                   " ( " +
                   " Select TranMonth, CASE When TranMonth = 1 then 'Jan' When TranMonth = 2 then 'Feb' " +
                   " When TranMonth = 3 then 'Mar' When TranMonth = 4 then 'Apr' " +
                   " When TranMonth = 5 then 'May' When TranMonth = 6 then 'Jun' " +
                   " When TranMonth = 7 then 'Jul' When TranMonth = 8 then 'Aug' " +
                   " When TranMonth = 9 then 'Sep' When TranMonth = 10 then 'Oct' " +
                   " When TranMonth = 11 then 'Nov' When TranMonth = 12 then 'Dec' end as MonthName, " +
                   " WarehouseCode, (OldCustNOC + NewCustNOC) as TotalNOC, OldCustNOC, NewCustNOC,  " +
                   " (OldCustVal + NewCustVal) as TotalVal, OldCustVal, NewCustVal  " +
                   " from DWDB.dbo.t_RetailCustomerSumm WHERE TranYear=" + nYear + " and Company='" + sCompany + "'  " +
                   " ) x Group by TranMonth, MonthName, WarehouseCode " +
                   " )a, " +
                   " (Select ShowroomCode, Zone, Area from TELSysDB.dbo.t_Showroom a,   " +
                   " (select CustomerID, TerritoryShortName as Zone,  " +
                   " AreaShortName as Area from DWDB.dbo.t_CustomerDetails Where CompanyName='TEL' and CustomerTypeID=5)b " +//Shouldn't Change Company Name TEL because both TEL, TML share Market group from TEL. - Hakim
                   " Where a.CustomerID=b.CustomerID and IsPOSActive=1)b  " +
                   " Where a.WarehouseCode=b.ShowroomCode and MonthName='" + sMonth + "' " +
                   " Order by Area, Zone, WarehouseCode ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Data _oData = new Data();

                    _oData.Outlet = (string)reader["WarehouseCode"];
                    _oData.TerritoryName = (string)reader["Zone"];
                    _oData.AreaName = (string)reader["Area"];

                    _oData.TotalNOC = Convert.ToInt32(reader["TotalNOC"]);
                    _oData.OldNOC = Convert.ToInt32(reader["OldCustNOC"]);
                    _oData.NewNOC = Convert.ToInt32(reader["NewCustNOC"]);

                    _oData.TotalVal = Convert.ToDouble(reader["TotalVal"]);
                    _oData.OldVal = Convert.ToDouble(reader["OldCustVal"]);
                    _oData.NewVal = Convert.ToDouble(reader["NewCustVal"]);

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

        public void GetDataMAG(string sCompany, int nYear, string sMonth, string sType, string sValue)
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            sSQL = " Select Brand, MAGName, " +
                   " SUM(TotalNOC) as TotalNOC, SUM(OldCustNOC) as OldCustNOC, SUM(NewCustNOC) as NewCustNOC,  " +
                   " SUM(TotalVal) as TotalVal, SUM(OldCustVal) as OldCustVal, SUM(NewCustVal) as NewCustVal  " +
                   " from  " +
                   " ( " +
                   " Select TranMonth, MonthName,Brand, MAGName,Zone, Area, TotalNOC,  " +
                   " OldCustNOC, NewCustNOC,TotalVal, OldCustVal, NewCustVal  " +
                   " from   " +
                   " (  " +
                   " Select TranMonth, MonthName, WarehouseCode, Brand, MAGName,  " +
                   " SUM(TotalNOC) as TotalNOC, SUM(OldCustNOC) as OldCustNOC, SUM(NewCustNOC) as NewCustNOC,  " +
                   " SUM(TotalVal) as TotalVal, SUM(OldCustVal) as OldCustVal, SUM(NewCustVal) as NewCustVal  " +
                   " from   " +
                   " (  " +
                   " Select Brand, MAGName,TranMonth, CASE When TranMonth = 1 then 'Jan' When TranMonth = 2 then 'Feb'  " +
                   " When TranMonth = 3 then 'Mar' When TranMonth = 4 then 'Apr'  " +
                   " When TranMonth = 5 then 'May' When TranMonth = 6 then 'Jun'  " +
                   " When TranMonth = 7 then 'Jul' When TranMonth = 8 then 'Aug'  " +
                   " When TranMonth = 9 then 'Sep' When TranMonth = 10 then 'Oct'  " +
                   " When TranMonth = 11 then 'Nov' When TranMonth = 12 then 'Dec' end as MonthName,  " +
                   " WarehouseCode, (OldCustNOC + NewCustNOC) as TotalNOC, OldCustNOC, NewCustNOC,   " +
                   " (OldCustVal + NewCustVal) as TotalVal, OldCustVal, NewCustVal   " +
                   " from DWDB.dbo.t_RetailCustomerMAGSumm WHERE TranYear= " + nYear + " and Company='" + sCompany + "'   " +
                   " ) x Group by TranMonth, MonthName, WarehouseCode,Brand, MAGName  " +
                   " )a,  " +
                   " (Select ShowroomCode, Zone, Area from TELSysDB.dbo.t_Showroom a,    " +
                   " (select CustomerID, TerritoryShortName as Zone,   " +
                   " AreaShortName as Area, AreaID, TerritoryID from DWDB.dbo.t_CustomerDetails Where CompanyName='TEL'  " + //Shouldn't Change Company Name TEL because both TEL, TML share Market group from TEL. - Hakim
                   " and CustomerTypeID=5)b  " +
                   " Where a.CustomerID=b.CustomerID and IsPOSActive=1  ";
            if (sValue != "Total")
            {
                if (sType == "Area")
                {
                    sSQL = sSQL + " and AreaID = '" + sValue + "' ";
                }
                else if (sType == "Zone")
                {
                    sSQL = sSQL + " and TerritoryID = '" + sValue + "' ";
                }
                else
                {
                    sSQL = sSQL + " and ShowroomCode = '" + sValue + "' ";
                }
            }
            sSQL = sSQL + " )b   " +
                   " Where a.WarehouseCode=b.ShowroomCode and MonthName='" + sMonth + "' " +
                   " )Final Group by Brand, MAGName";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Data _oData = new Data();

                    _oData.Outlet = (string)reader["Brand"];
                    _oData.AreaName = (string)reader["MAGName"];

                    //_oData.TerritoryName = (string)reader["Zone"];
                    //_oData.Brand = (string)reader["Brand"];
                    //_oData.MAGName = (string)reader["MAGName"];

                    _oData.TotalNOC = Convert.ToInt32(reader["TotalNOC"]);
                    _oData.OldNOC = Convert.ToInt32(reader["OldCustNOC"]);
                    _oData.NewNOC = Convert.ToInt32(reader["NewCustNOC"]);

                    _oData.TotalVal = Convert.ToDouble(reader["TotalVal"]);
                    _oData.OldVal = Convert.ToDouble(reader["OldCustVal"]);
                    _oData.NewVal = Convert.ToDouble(reader["NewCustVal"]);

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
            foreach (Data oData in this)
            {
                _oData = new Data();
                _oData.Outlet = oData.Outlet;
                _oData.Type = oData.Type;
                _oData.Value = oData.Value;

                _oData.TotalNOCText = oData.TotalNOC.ToString();
                _oData.OldNOCText = oData.OldNOC.ToString();
                _oData.NewNOCText = oData.NewNOC.ToString();
               
                //_oData.TotalValText = ExcludeDecimal(_oTELLib.TakaFormat(oData.TotalVal));
                //_oData.OldValText = ExcludeDecimal(_oTELLib.TakaFormat(oData.OldVal));
                //_oData.NewValText = ExcludeDecimal(_oTELLib.TakaFormat(oData.NewVal));

                _oData.TotalValText = ExcludeDecimal(_oTELLib.TakaFormat(oData.TotalVal / 1000));
                _oData.OldValText = ExcludeDecimal(_oTELLib.TakaFormat(oData.OldVal / 1000));
                _oData.NewValText = ExcludeDecimal(_oTELLib.TakaFormat(oData.NewVal / 1000));

                if (oData.OldNOC > 0)
                {
                    _oData.OldNOCPerc = (Math.Round(((oData.OldNOC * 1.0) / oData.TotalNOC) * 100)).ToString();
                }
                else
                {
                    _oData.OldNOCPerc = "0";
                }
                if (oData.NewNOC > 0)
                {
                    _oData.NewNOCPerc = (Math.Round(((oData.NewNOC * 1.0) / oData.TotalNOC) * 100)).ToString();
                }
                else
                {
                    _oData.NewNOCPerc = "0";
                }
                if (oData.OldVal > 0)
                {
                    _oData.OldValPerc = (Math.Round(((oData.OldVal * 1.0) / oData.TotalVal) * 100)).ToString();
                }
                else
                {
                    _oData.OldValPerc = "0";
                }
                if (oData.NewVal > 0)
                {
                    _oData.NewValPerc = (Math.Round(((oData.NewVal * 1.0) / oData.TotalVal) * 100)).ToString();
                }
                else
                {
                    _oData.NewValPerc = "0";
                }

                eList.Add(_oData);
            }
            return eList;

        }
    }
}


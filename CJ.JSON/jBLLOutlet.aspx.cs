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

public partial class jBLLOutlet : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sBeatID = c.Request.Form["BeatID"].Trim();
            string sDate = c.Request.Form["Date"].Trim();


            //string sUser = "hakim";
            //string sBeatID = "1321";
            //string sDate = "";

            DateTime dDate = DateTime.Now.Date;
            try
            {
                dDate = Convert.ToDateTime(sDate);
            }
            catch (Exception ex)
            {
                dDate = DateTime.Now.Date;
            }
            Data _oData = new Data();
            Datas oDatas = new Datas();
            Datas _oDatas = new Datas();
            Data _oNational = new Data();
            Data _oOutlet = new Data();
            int nCount = 0;
            oDatas.GetRawData(sBeatID, dDate);
            #region Loop
            foreach (Data oData in oDatas)
            {

                if (nCount == 0)
                {
                    #region Total
                    //All
                    _oNational = new Data();
                    _oDatas.Add(_oNational);
                    _oNational.RetailID = "--";
                    _oNational.BeatID = "--";
                    _oNational.RetailName = "Total";
                    _oNational.RetailAddress = "--";
                    _oNational.ProprietorName = "--";
                    _oNational.ContactNo = "--";
                    _oNational.MarketName = "--";
                    _oNational.RetailType = "--";
                    _oNational.SlabDescription = "--";
                    _oNational.Value = "Success";
                    _oNational.Type = "Total";
                    nCount++;
                    #endregion
                }

                _oOutlet = new Data();
                _oOutlet.Value = "Success";
                _oOutlet.Type = "Outlet";

                _oOutlet.RetailID = oData.RetailID;
                _oOutlet.BeatID = oData.BeatID;
                _oOutlet.RetailName = oData.RetailName;
                _oOutlet.RetailAddress = oData.RetailAddress;
                _oOutlet.ProprietorName = oData.ProprietorName;
                _oOutlet.ContactNo = oData.ContactNo;
                _oOutlet.MarketName = oData.MarketName;
                _oOutlet.RetailType = oData.RetailType;
                _oOutlet.SlabDescription = oData.SlabDescription;
                _oOutlet.TargetValue = oData.TargetValue;
                _oOutlet.SalesValue = oData.SalesValue;

                _oDatas.Add(_oOutlet);

                _oNational.TargetValue = _oNational.TargetValue + oData.TargetValue;
                _oNational.SalesValue = _oNational.SalesValue + oData.SalesValue;
               
            }
            #endregion
            _oData.InsertReportLog(sUser);

            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput.ToString());

        }
    }
    public class Data
    {
        // C = Current, M = Month, P=Primary, T=Target, L=Last, Y=Year, A=Actual

        public string RetailID;
        public string BeatID;
        public string RetailName;
        public string RetailAddress;
        public string ProprietorName;
        public string ContactNo;
        public string MarketName;
        public string RetailType;
        public string SlabDescription;

        public double TargetValue;
        public double SalesValue;

        public string TargetValueText;
        public string SalesValueText;
        public string PercentText;
        public string Value;
        public string Type;


        public void InsertReportLog(string sUser)
        {
            //ReportLog oReportLog = new ReportLog();
            //string sReportCode = "A10042";
            //string sReportName = "BLL-Outlet List";
            //string connStr;
            //connStr = ConfigurationManager.AppSettings["jConnectionString"];
            //oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
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
    
        public void GetRawData(string sBeatID, DateTime dFromDate)
        {
            DateTime _dTodate;
            DateTime _dFromDate;
            TELLib oTELLib = new TELLib();
            _dFromDate = oTELLib.FirstDayofMonth(dFromDate);
            _dTodate = _dFromDate.AddMonths(1);
            string sSQL = "";
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            
            cmd = DBController.Instance.GetCommand();

            sSQL = " Select RetailID, RouteID, RetailName, RetailAddress, ProprietorName,ContactNo, " +
                   " MarketName, RetailType, SlabOutlet,MapSerialno, 'CFL: 100 pcs' as SlabDes, 1000 as TargetValue, IsNull(SalesValue,0) as SalesValue from  " +
                   " (Select RetailID, RouteID, RetailName, RetailAddress, ProprietorName,Mobile01 as ContactNo,  " +
                   " MarketName, RetailType, SlabOutlet,MapSerialno  from BLLSysDB.dbo.t_DMSClusterOutlet  " +
                   " Where IsActive=1 and RouteID=" + sBeatID + ") a " +
                   " Left OUter JOIN  " +
                   " (Select OutletID, Sum(Total) as SalesValue from BLLSysDB.dbo.t_DMSASGWiseSales Where EntryDate between '" + _dFromDate + "'  " +
                   " and '" + _dTodate + "' and EntryDate < '" + _dTodate + "' Group by OutletID)b " +
                   " ON a.RetailID=b.OutletID " +
                   " Order by MapSerialno ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Data oData = new Data();

                    if (reader["RetailID"] != DBNull.Value)
                        oData.RetailID = reader["RetailID"].ToString();
                    else oData.RetailID = "";

                    if (reader["RouteID"] != DBNull.Value)
                        oData.BeatID = reader["RouteID"].ToString();
                    else oData.BeatID = "";

                    if (reader["RetailName"] != DBNull.Value)
                        oData.RetailName = reader["RetailName"].ToString();
                    else oData.RetailName = "";

                    if (reader["RetailAddress"] != DBNull.Value)
                        oData.RetailAddress = reader["RetailAddress"].ToString();
                    else oData.RetailAddress = "";

                    if (reader["ProprietorName"] != DBNull.Value)
                        oData.ProprietorName = reader["ProprietorName"].ToString();
                    else oData.ProprietorName = "";

                    if (reader["ContactNo"] != DBNull.Value)
                        oData.ContactNo = reader["ContactNo"].ToString();
                    else oData.ContactNo = "";

                    if (reader["MarketName"] != DBNull.Value)
                        oData.MarketName = reader["MarketName"].ToString();
                    else oData.MarketName = "";

                    if (reader["RetailType"] != DBNull.Value)
                        oData.RetailType = reader["RetailType"].ToString();
                    else oData.RetailType = "";

                    if (reader["SlabDes"] != DBNull.Value)
                        oData.SlabDescription = reader["SlabDes"].ToString();
                    else oData.SlabDescription = "";

                    oData.TargetValue = Convert.ToDouble(reader["TargetValue"]);
                    oData.SalesValue = Convert.ToDouble(reader["SalesValue"]);

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
                    _oData.RetailID = oData.RetailID;
                    _oData.BeatID = oData.BeatID;
                    _oData.RetailName = oData.RetailName;
                    _oData.RetailAddress = oData.RetailAddress;
                    _oData.ProprietorName = oData.ProprietorName;
                    _oData.ContactNo = oData.ContactNo;
                    _oData.MarketName = oData.MarketName;
                    _oData.RetailType = oData.RetailType;
                    _oData.SlabDescription = oData.SlabDescription;
                    _oData.TargetValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.TargetValue));
                    _oData.SalesValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SalesValue));
                    _oData.Type = oData.Type;
                    _oData.Value = oData.Value;
                    if (oData.TargetValue > 0)
                    {
                        _oData.PercentText = Convert.ToString(Math.Round((Convert.ToDouble(oData.SalesValue) / oData.TargetValue) * 100));
                    }
                    else
                    {
                        _oData.PercentText = "0";
                    }
                    eList.Add(_oData);
                
            }
            return eList;

        }
    }

}





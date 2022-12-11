using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CJ.Class;
using CJ.Class.Library;
using Newtonsoft.Json;

public partial class jBLLWeeklySalesAndCollection : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sRegionId = c.Request.Form["sRegionId"].Trim();
            string sAreaId = c.Request.Form["sAreaId"].Trim();
            string sTerritoryId = c.Request.Form["sTerritoryId"].Trim();
            string sCustomerId = c.Request.Form["sCustomerId"].Trim();


            //string sUser = "hakim";
            //string sRegionId = "-1";
            //string sAreaId = "-1";
            //string sTerritoryId = "-1";
            //string sCustomerId = "-1";


            Data _oData = new Data();

            Datas oDatas = new Datas();
            Datas _oDatas = new Datas();
            Data _oDataTotal = new Data();

            int nCount = 0;
            int nTotalCount = 0;
            int nMargetGroupID = 0;

            DBController.Instance.OpenNewConnection();
            oDatas.GetData(sRegionId, sAreaId, sTerritoryId, sCustomerId);
            DBController.Instance.CloseConnection();

            _oDataTotal = new Data();
            
            _oDataTotal.Name = "Total";
            _oDataTotal.Type = "Total";
            _oDataTotal.Value = "Success";
            _oDatas.Add(_oDataTotal);


            foreach (Data oData in oDatas)
            {
                nTotalCount = 0;

                _oData = new Data();

                _oData.Name = oData.WeekNo + " (" + oData.FromDate.ToString("dd-MMM-yyyy") + "-" + oData.ToDate.ToString("dd-MMM-yyyy") + ")";
                _oData.Type = "Week";
                _oData.WeekNo = oData.WeekNo;
                _oData.FromDate = oData.FromDate;
                _oData.ToDate = oData.ToDate;                
                _oData.PriSales = oData.PriSales;
                _oData.SecSales = oData.SecSales;
                _oData.SalesGap = oData.SalesGap;
                _oData.Collectionplan = oData.Collectionplan;
                _oData.MTDCollection = oData.MTDCollection;
                _oData.CollectionGap = oData.CollectionGap;
                _oData.CreditLimitm = oData.CreditLimitm;
                _oData.Receievables = oData.Receievables;

                _oData.PriSalesText = oData.PriSalesText;
                _oData.SecSalesText = oData.SecSalesText;
                _oData.SalesGapText = oData.SalesGapText;
                _oData.CollectionplanText = oData.CollectionplanText;
                _oData.MTDCollectionText = oData.MTDCollectionText;
                _oData.CollectionGapText = oData.CollectionGapText;
                _oData.CreditLimitmText = oData.CreditLimitmText;
                _oData.ReceievablesText = oData.ReceievablesText;

                _oDatas.Add(_oData);

                _oDataTotal.PriSales = _oDataTotal.PriSales + oData.PriSales;
                _oDataTotal.SecSales = _oDataTotal.SecSales + oData.SecSales;
                _oDataTotal.SalesGap = _oDataTotal.SalesGap + oData.SalesGap;
                _oDataTotal.Collectionplan = _oDataTotal.Collectionplan + oData.Collectionplan;
                _oDataTotal.MTDCollection = _oDataTotal.MTDCollection + oData.MTDCollection;
                _oDataTotal.CollectionGap = _oDataTotal.CollectionGap + oData.CollectionGap;
                _oDataTotal.CreditLimitm = _oDataTotal.CreditLimitm + oData.CreditLimitm;
                _oDataTotal.Receievables = _oDataTotal.Receievables + oData.Receievables;
            }



            _oData.InsertReportLog(sUser);

            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput);
        }
    }

    public class Data
    {
        public string Name;
        public string Type;
        public string Value;

        public string WeekNo;
        public DateTime FromDate;
        public DateTime ToDate;
        public double PriSales;
        public double SecSales;
        public double SalesGap;
        public double Collectionplan;
        public double MTDCollection;
        public double CollectionGap;
        public double CreditLimitm;
        public double Receievables;


        public string PriSalesText;
        public string SecSalesText;
        public string SalesGapText;
        public string CollectionplanText;
        public string MTDCollectionText;
        public string CollectionGapText;
        public string CreditLimitmText;
        public string ReceievablesText;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10048";
            string sReportName = "Weekly Sales & Collection [213]";
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
        public void GetData(string sRegionId, string sAreaId, string sTerritoryId, string sCustomerId)
        {
            string sSQL = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();

            sSQL = @"select WeekNo, fromDate,ToDate,
                    sum(PriSales)As PriSales,sum(SecSales)as SecSales,sum(SecSales-PriSales)as SalesGap,
                    sum(Regular_ColPlan+OverLimit_ColPlan)as Collectionplan, sum(CM_Coll)as MTDCollection,
                    sum(CollGap)as CollectionGap, 
                    sum(CRLimit)As CreditLimitm,sum( RecBalance)  Receievables
                    from [dwdb].[dbo].t_WeekwiseCollectionPlan 
                    where weekno > 0   {0} ";

            //and RegionID = 1 and AreaID = 216 and TerritoryID = 222 and CustomerID = 2595


            string subCondition = "";

            if (sAreaId != "-1")
            {
                subCondition += " AND AreaID = " + sAreaId;
            }
            if (sRegionId != "-1")
            {
                subCondition += " AND RegionID = " + sRegionId;
            }
            if (sTerritoryId != "-1")
            {
                subCondition += " AND TerritoryID = " + sTerritoryId;
            }
            if (sCustomerId != "-1")
            {
                subCondition += " AND CustomerID = " + sCustomerId;
            }

            sSQL = string.Format(sSQL, subCondition);

            sSQL += " group by WeekNo,fromDate,ToDate  ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text; ;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Data oData = new Data();
                    oData.WeekNo = reader["WeekNo"].ToString();
                    oData.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                    oData.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                    oData.PriSales = Convert.ToDouble(reader["PriSales"].ToString());
                    oData.SecSales = Convert.ToDouble(reader["SecSales"].ToString());
                    oData.SalesGap = Convert.ToDouble(reader["SalesGap"].ToString());
                    oData.Collectionplan = Convert.ToDouble(reader["Collectionplan"]);
                    oData.MTDCollection = Convert.ToDouble(reader["MTDCollection"]);
                    oData.CollectionGap = Convert.ToDouble(reader["CollectionGap"]);
                    oData.CreditLimitm = Convert.ToDouble(reader["CreditLimitm"]);
                    oData.Receievables = Convert.ToDouble(reader["Receievables"]);

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
            TELLib _oTELLib = new TELLib();
            Data _oData;

            List<Data> eList = new List<Data>();
            foreach (Data oData in this)
            {
                _oData = new Data();

                //_oData.Name = oData.WeekNo + " (" + oData.FromDate.ToString("dd-MMM-yyyy") + "-" + oData.ToDate.ToString("dd-MMM-yyyy") + ")";
                _oData.Name = oData.Name;
                _oData.Type = oData.Type;
                _oData.WeekNo = oData.WeekNo;
                _oData.FromDate = oData.FromDate;
                _oData.ToDate = oData.ToDate;

                _oData.PriSalesText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriSales));
                _oData.SecSalesText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SecSales));
                _oData.SalesGapText = ExcludeDecimal(_oTELLib.TakaFormat(oData.SalesGap));
                _oData.CollectionplanText = ExcludeDecimal(_oTELLib.TakaFormat(oData.Collectionplan));
                _oData.MTDCollectionText = ExcludeDecimal(_oTELLib.TakaFormat(oData.MTDCollection));
                _oData.CollectionGapText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CollectionGap));
                _oData.CreditLimitmText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CreditLimitm));
                _oData.ReceievablesText = ExcludeDecimal(_oTELLib.TakaFormat(oData.Receievables));

                eList.Add(_oData);
            }
            return eList;

        }

    }
}

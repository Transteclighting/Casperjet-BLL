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
using System.Data.OleDb;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.ANDROID;
using CJ.Class.Library;

public partial class jCompanySales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            string sUser = c.Request.Form["UserName"].Trim();

            //string sUser = "hakim";


            Data _oResponse = new Data();
            List<Data> eList = new List<Data>();
            Companys _oCompanys = new Companys();

            _oResponse.Values = "Success";
            DBController.Instance.OpenNewConnection();
            _oResponse.CompanyDataList = _oCompanys.getResult();

            //_oData.InsertReportLog(sUser);
            eList.Add(_oResponse);

            
            string sOutput = JsonConvert.SerializeObject(eList, Formatting.Indented);
            Response.Write(sOutput.ToString());
            DBController.Instance.CloseConnection();
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
        public string Values;
        public List<Company> CompanyDataList;
    }
    public class Company
    {
        public string sCompany;
        public string TodaySales;
        public string LastDaySales;
        public string ThisMonthTarget;
        public string ThisMonthSales;
        public string ThisMonthAch;
        public string LastMonthTarget;
        public string LastMonthSales;
        public string LastMonthAch;
        public string YTDSales;
        public string LastYearYTDSales;
        public string YTDGrowth;
        public string LastYearSales;
  
        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10001";
            string sReportName = "Sales Summary";
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

    }

    public class Companys : CollectionBase
    {
        public Company this[int i]
        {
            get { return (Company)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Company oCompany)
        {
            InnerList.Add(oCompany);
        }
        private string ExcludeDecimal(string sAmount)
        {
            string sResult = "";
            sResult = sAmount.Remove(sAmount.Length - 3);
            return sResult;
        }

        private string CommaSeparator(double _Amount)
        {
            string sResult = "";
            sResult = String.Format("{0:#,###,###.##}", _Amount);
            return sResult;
        }

        public List<Company> getResult()
        {
            Company _oCompany;
            List<Company> eList = new List<Company>();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = " Select Company, TodaySales, LastDaySales, ThisMonthTarget, ThisMonthSales, ThisMonthAch, LastMonthTarget, " +
                   " LastMonthSales, LastMonthAch, YTDSales, LastYearYTDSales, YTDGrowth, LastYearSales from DWDB.dbo.t_CompanySummary " +
                   " Where IsActive=1 Order by Sort";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oCompany = new Company();

                    _oCompany.sCompany = (string)reader["Company"];
                    _oCompany.TodaySales = CommaSeparator(Convert.ToDouble(reader["TodaySales"]));
                    _oCompany.LastDaySales = CommaSeparator(Convert.ToDouble(reader["LastDaySales"]));
                    _oCompany.ThisMonthTarget = CommaSeparator(Convert.ToDouble(reader["ThisMonthTarget"]));
                    _oCompany.ThisMonthSales = CommaSeparator(Convert.ToDouble(reader["ThisMonthSales"]));
                    _oCompany.ThisMonthAch = CommaSeparator(Convert.ToDouble(reader["ThisMonthAch"]));
                    _oCompany.LastMonthTarget = CommaSeparator(Convert.ToDouble(reader["LastMonthTarget"]));
                    _oCompany.LastMonthSales = CommaSeparator(Convert.ToDouble(reader["LastMonthSales"]));
                    _oCompany.LastMonthAch = CommaSeparator(Convert.ToDouble(reader["LastMonthAch"]));
                    _oCompany.YTDSales = CommaSeparator(Convert.ToDouble(reader["YTDSales"]));
                    _oCompany.LastYearYTDSales = CommaSeparator(Convert.ToDouble(reader["LastYearYTDSales"]));
                    _oCompany.YTDGrowth = CommaSeparator(Convert.ToDouble(reader["YTDGrowth"]));
                    _oCompany.LastYearSales = CommaSeparator(Convert.ToDouble(reader["LastYearSales"]));

                    _oCompany.Value = "Success";
                    eList.Add(_oCompany);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            return eList;

        }

    }
}


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

public partial class jCustomerReceivable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            HttpContext c = HttpContext.Current;
            string sUser = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();
            string sType = c.Request.Form["Type"].Trim();
            //string sType = "Customer";
            //string sCompany = "TML";
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

            DBController.Instance.OpenNewConnection();
            if (sType == "Channel")
            {
                oDatas.GetChannel(sDatabase);
            }
            else if (sType == "Customer")
            {
                oDatas.GetCustomer(sDatabase);
            }
            DBController.Instance.CloseConnection();

            if (sCompany == "TEL")
            {
                if (sType == "Channel")
                {
                    Data oData = new Data();
                    oData.InsertReportLog(sUser);
                }
            }

            if (sType == "Channel")
            {
                string sOutput = JsonConvert.SerializeObject(oDatas.getResult(), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "Customer")
            {
                string sOutput = JsonConvert.SerializeObject(oDatas.getCustomerResult(), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            
        }
    }
    public class Data
    {
        public string ChannelID;
        public string ChannelName;
        public string CustomerName;
        public string IsActive;

        public double ActiveBalanceValue;
        public double InActiveBalanceValue;
        public double CurrentBalanceValue;


        public string ActiveBalanceValueText;
        public string InActiveBalanceValueText;
        public string CurrentBalanceValueText;

        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10003";
            string sReportName = "Customer Receivable";
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
        public void GetChannels(string sDatabase)
        {

            InnerList.Clear();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            sSQL = " select a.ChannelID, a.ChannelDescription as ChannelName, ActiveBalance, InActiveBalance, SortOrder from  " +
                   " ( " +
                   " Select ChannelID, ChannelDescription, Sum(ActiveCB) as ActiveBalance, Sum(InActiveCB) as InActiveBalance " +
                   " From " +
                   " ( " +
                   " Select ChannelID, ChannelDescription, Sum(CurrentBalance*-1)ActiveCB, 0 as  InActiveCB " +
                   " from " + sDatabase + ".dbo.v_CustomerDetails Where IsActive=1 group by ChannelID, ChannelDescription " +
                   " UNION ALL " +
                   " Select ChannelID, ChannelDescription, 0 as ActiveCB, Sum(CurrentBalance*-1) as  InActiveCB " +
                   " from " + sDatabase + ".dbo.v_CustomerDetails Where IsActive=0 group by ChannelID, ChannelDescription " +
                   " ) a Group by ChannelID, ChannelDescription " +
                   " )a, " + sDatabase + ".dbo.t_Channel b  Where a.ChannelID=b.ChannelID and (ActiveBalance + InActiveBalance) > 0 " +
                   " Order by SortOrder ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();
                    oData.ChannelID = reader["ChannelID"].ToString();
                    oData.ChannelName = reader["ChannelName"].ToString();
                    oData.ActiveBalanceValue = Convert.ToDouble(reader["ActiveBalance"]);
                    oData.InActiveBalanceValue = Convert.ToDouble(reader["InActiveBalance"]);

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


        public void GetChannel(string sDatabase)
        {

            InnerList.Clear();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            sSQL = " select a.ChannelID, a.ChannelDescription as ChannelName, ActiveBalance, InActiveBalance, SortOrder from  " +
                   " ( " +
                   " Select ChannelID, ChannelDescription, Sum(ActiveCB) as ActiveBalance, Sum(InActiveCB) as InActiveBalance " +
                   " From " +
                   " ( " +
                   " Select ChannelID, ChannelDescription, Sum(CurrentBalance*-1)ActiveCB, 0 as  InActiveCB " +
                   " from " + sDatabase + ".dbo.v_CustomerDetails Where IsActive=1 group by ChannelID, ChannelDescription " +
                   " UNION ALL " +
                   " Select ChannelID, ChannelDescription, 0 as ActiveCB, Sum(CurrentBalance*-1) as  InActiveCB " +
                   " from " + sDatabase + ".dbo.v_CustomerDetails Where IsActive=0 group by ChannelID, ChannelDescription " +
                   " ) a Group by ChannelID, ChannelDescription " +
                   " )a, " + sDatabase + ".dbo.t_Channel b  Where a.ChannelID=b.ChannelID  " +
                   " Order by SortOrder ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();
                    oData.ChannelID = reader["ChannelID"].ToString();
                    oData.ChannelName = reader["ChannelName"].ToString();
                    oData.ActiveBalanceValue = Convert.ToDouble(reader["ActiveBalance"]);
                    oData.InActiveBalanceValue = Convert.ToDouble(reader["InActiveBalance"]);

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
        public void GetCustomer(string sDatabase)
        {

            InnerList.Clear();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            sSQL = " select ChannelID, CustomerName +'['+ CustomerCode + ']' as CustomerName, (CurrentBalance * -1) as CurrentBalance, Case When IsActive = 1 then 'Active' else 'In-Active' end as IsActive " +
                   " from " + sDatabase + ".dbo.v_CustomerDetails where (CurrentBalance * -1) <>0 " +
                   " order by IsActive,CustomerName, CurrentBalance desc  ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();
                    oData.ChannelID = reader["ChannelID"].ToString();
                    oData.CustomerName = reader["CustomerName"].ToString();
                    oData.CurrentBalanceValue = Convert.ToDouble(reader["CurrentBalance"]);
                    oData.IsActive = reader["IsActive"].ToString();

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
                _oData.ChannelID = oData.ChannelID;
                _oData.Value = "Success";

                _oData.ChannelName = oData.ChannelName;

                _oData.ActiveBalanceValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.ActiveBalanceValue));
                _oData.InActiveBalanceValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.InActiveBalanceValue));

                eList.Add(_oData);
            }
            return eList;

        }

        public List<Data> getCustomerResult()
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            foreach (Data oData in this)
            {
                _oData = new Data();
                _oData.ChannelID = oData.ChannelID;
                _oData.Value = "Success";

                _oData.CustomerName = oData.CustomerName;

                _oData.CurrentBalanceValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CurrentBalanceValue));
                _oData.IsActive = oData.IsActive;

                eList.Add(_oData);
            }
            return eList;

        }
        
    }
}

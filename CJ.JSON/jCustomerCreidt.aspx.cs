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

public partial class jCustomerCreidt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();
            string sType = c.Request.Form["Type"].Trim();

            //string sType = "Summary";
            //string sCompany = "TEL";

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
            if (sType == "Summary")
            {
                oDatas.GetSummary(sDatabase, sCompany);
            }
            else if (sType == "OutletWise")
            {
                //oDatas.GetCustomer(sDatabase);
            }
            else if (sType == "InvoiceWise")
            { 
            
            }
            DBController.Instance.CloseConnection();

            Data _oData = new Data();
            Datas _oDatas = new Datas();
            Data _oDataTotal = new Data();
            Data _oDataArea = new Data();
            Data _oDataZone = new Data();
            Data _oDataOutlet = new Data();
            int nCount = 0;
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
                if (_oDataZone.ZoneName != oData.ZoneName)
                {
                    _oDataZone = new Data();
                    _oDatas.Add(_oDataZone);
                    _oDataZone.ZoneName = oData.ZoneName;
                    _oDataZone.Outlet = oData.ZoneName;
                    _oDataZone.Type = "Zone";
                    _oDataZone.Value = "Success";
                }

                _oDataOutlet = new Data();
                _oDataOutlet.Value = "Success";

                _oDataOutlet.Outlet = oData.Outlet;
                _oDataOutlet.NoOfRunningCredit = oData.NoOfRunningCredit;
                _oDataOutlet.CreditAmount = oData.CreditAmount;
                _oDataOutlet.InvoiceAmount = oData.InvoiceAmount;
                _oDataOutlet.BalanceAmount = oData.BalanceAmount;
                _oDataOutlet.CollectionAmount = oData.CollectionAmount;
                _oDataOutlet.DueAmount = oData.DueAmount;
                _oDataOutlet.OverDueAmount = oData.OverDueAmount;
                _oDataOutlet.TotalDueAmount = oData.TotalDueAmount;
                _oDataOutlet.Type = "Outlet";
                _oDatas.Add(_oDataOutlet);

                _oDataTotal.NoOfRunningCredit = _oDataTotal.NoOfRunningCredit + oData.NoOfRunningCredit;
                _oDataTotal.CreditAmount = _oDataTotal.CreditAmount + oData.CreditAmount;
                _oDataTotal.InvoiceAmount = _oDataTotal.InvoiceAmount + oData.InvoiceAmount;
                _oDataTotal.BalanceAmount = _oDataTotal.BalanceAmount + oData.BalanceAmount;
                _oDataTotal.CollectionAmount = _oDataTotal.CollectionAmount + oData.CollectionAmount;
                _oDataTotal.DueAmount = _oDataTotal.DueAmount + oData.DueAmount;
                _oDataTotal.OverDueAmount = _oDataTotal.OverDueAmount + oData.OverDueAmount;
                _oDataTotal.TotalDueAmount = _oDataTotal.TotalDueAmount + oData.TotalDueAmount;

                _oDataArea.NoOfRunningCredit = _oDataArea.NoOfRunningCredit + oData.NoOfRunningCredit;
                _oDataArea.CreditAmount = _oDataArea.CreditAmount + oData.CreditAmount;
                _oDataArea.InvoiceAmount = _oDataArea.InvoiceAmount + oData.InvoiceAmount;
                _oDataArea.BalanceAmount = _oDataArea.BalanceAmount + oData.BalanceAmount;
                _oDataArea.CollectionAmount = _oDataArea.CollectionAmount + oData.CollectionAmount;
                _oDataArea.DueAmount = _oDataArea.DueAmount + oData.DueAmount;
                _oDataArea.OverDueAmount = _oDataArea.OverDueAmount + oData.OverDueAmount;
                _oDataArea.TotalDueAmount = _oDataArea.TotalDueAmount + oData.TotalDueAmount; 

                _oDataZone.NoOfRunningCredit = _oDataZone.NoOfRunningCredit + oData.NoOfRunningCredit;
                _oDataZone.CreditAmount = _oDataZone.CreditAmount + oData.CreditAmount;
                _oDataZone.InvoiceAmount = _oDataZone.InvoiceAmount + oData.InvoiceAmount;
                _oDataZone.BalanceAmount = _oDataZone.BalanceAmount + oData.BalanceAmount;
                _oDataZone.CollectionAmount = _oDataZone.CollectionAmount + oData.CollectionAmount;
                _oDataZone.DueAmount = _oDataZone.DueAmount + oData.DueAmount;
                _oDataZone.OverDueAmount = _oDataZone.OverDueAmount + oData.OverDueAmount;
                _oDataZone.TotalDueAmount = _oDataZone.TotalDueAmount + oData.TotalDueAmount;
            }
            if (sCompany == "TEL")
            {
                if (sType == "Summary")
                {
                    Data oData = new Data();
                    //oData.InsertReportLog(sUser);
                }
            }

            if (sType == "Summary")
            {
                string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            //else if (sType == "Customer")
            //{
            //    string sOutput = JsonConvert.SerializeObject(oDatas.getCustomerResult(), Formatting.Indented);
            //    Response.Write(sOutput.ToString());
            //}

        }
    }
    public class Data
    {
        public string AreaName;
        public string ZoneName;
        public string Outlet;
        public string Type;

        public int NoOfRunningCredit;
        public double CreditAmount;
        public double InvoiceAmount;
        public double BalanceAmount;
        public double CollectionAmount;
        public double DueAmount;
        public double OverDueAmount;
        public double TotalDueAmount;
        public int CreditPeriod;

        public string ApproveNumber;
        public string Customer;
        public string InvoiceNumber;
        public string ExpireDate;

        public string NoOfRunningCreditText;
        public string CreditAmountText;
        public string InvoiceAmountText;
        public string BalanceAmountText;
        public string CollectionAmountText;
        public string DueAmountText;
        public string OverDueAmountText;
        public string TotalDueAmountText;
        public string CreditPeriodText;

        public string Value;

        public void InsertReportLog(string sUser)
        {
            //ReportLog oReportLog = new ReportLog();
            //string sReportCode = "A10003";
            //string sReportName = "Customer Credit";
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
        public void GetSummary(string sDatabase, string sCompany)
        {

            InnerList.Clear();

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            sSQL = "  Select AreaShortName, TerritoryShortName,ShowroomCode, NoOfRunningCredit, CreditAmount, InvoicedAmount, " +
                   "  BalanceAmount, CollectedAmount, TotalDue, " +
                   "  ISNULL(Due,0) as Due, ISNULL(OverDue,0) as OverDue from " +
                   "  (select AreaShortName, TerritoryShortName,ShowroomCode,a.WarehouseID, count(a.WarehouseID) as NoOfRunningCredit,  " +
                   "  Sum(CreditAmount) as CreditAmount, Sum(InvoicedAmount) as InvoicedAmount, Sum(CreditAmount - InvoicedAmount) as BalanceAmount, " +
                   "  Sum(CollectedAmount) as CollectedAmount, Sum(InvoicedAmount-CollectedAmount) as TotalDue " +
                   "  from " + sDatabase + ".dbo.t_CustomerCreditApproval a, " + sDatabase + ".dbo.t_Showroom b,  DWDB.dbo.t_CustomerDetails c  " +
                   "  Where Status=" + (int)Dictionary.CreditApprovalStatus.Approve + " and a.WarehouseID=b.WarehouseID and b.CustomerID=c.CustomerID and c.CompanyName='" + sCompany + "' " +
                   "  and CollectedAmount <> CreditAmount " +
                   "  Group by AreaShortName, TerritoryShortName,ShowroomCode, a.WarehouseID " +
                   "  )a " +
                   "  Left Outer JOIN " +
                   "  ( " +
                   "  Select WarehouseID, Sum(Case When DueType = 1 then Amount else 0 end ) as Due, " +
                   "  Sum(Case When DueType = 2 then Amount else 0 end ) as OverDue " +
                   "  from ( " +
                   "  Select c.WarehouseID, InstrumentNo, Amount, CreditPeriod, InvoiceDate,  " +
                   "  Case When (InvoiceDate+CreditPeriod) > convert(varchar, getdate(), 106) then 1 else 2 end as DueType   " +
                   "  from " + sDatabase + ".dbo.t_SalesInvoicePaymentMode a,  " + sDatabase + ".dbo.t_SalesInvoice b,  " + sDatabase + ".dbo.t_CustomerCreditApproval c Where a.InvoiceID=b.InvoiceID  " +
                   "  and PaymentModeID=" + (int)Dictionary.PaymentMode.Approve_Credit + " and InstrumentNo is not null and a.InstrumentNo=c.ApprovalNo " +
                   "  ) a Group by WarehouseID " +
                   "  )b ON a.WarehouseID=b.WarehouseID order by AreaShortName, TerritoryShortName, ShowroomCode  ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.AreaName = reader["AreaShortName"].ToString();
                    oData.ZoneName = reader["TerritoryShortName"].ToString();
                    oData.Outlet = reader["ShowroomCode"].ToString();
                    oData.NoOfRunningCredit = Convert.ToInt32(reader["NoOfRunningCredit"]);
                    oData.CreditAmount = Convert.ToDouble(reader["CreditAmount"]);
                    oData.InvoiceAmount = Convert.ToDouble(reader["InvoicedAmount"]);
                    oData.BalanceAmount = Convert.ToDouble(reader["BalanceAmount"]);
                    oData.CollectionAmount = Convert.ToDouble(reader["CollectedAmount"]);
                    oData.TotalDueAmount = Convert.ToDouble(reader["TotalDue"]);

                    double dDueAmount = Convert.ToDouble(reader["Due"]);
                    double dOverDueAmount = Convert.ToDouble(reader["OverDue"]);
                    if (oData.CollectionAmount <= dOverDueAmount)
                    {
                        oData.OverDueAmount = dOverDueAmount - oData.CollectionAmount;
                    }
                    else
                    {
                        oData.OverDueAmount = 0;
                        double temp = dDueAmount - oData.CollectionAmount;
                        if (temp > 0)
                        {
                            oData.DueAmount = temp;
                        }
                    }

                    
                    //oData.DueAmount = Convert.ToDouble(reader["Due"]);
                    //oData.OverDueAmount = Convert.ToDouble(reader["OverDue"]);

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

                _oData.Outlet = oData.Outlet;
                _oData.Type = oData.Type;
                _oData.Value = oData.Value;
                _oData.NoOfRunningCreditText = oData.NoOfRunningCredit.ToString();
                _oData.CreditAmountText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CreditAmount));
                _oData.InvoiceAmountText = ExcludeDecimal(_oTELLib.TakaFormat(oData.InvoiceAmount));
                _oData.BalanceAmountText = ExcludeDecimal(_oTELLib.TakaFormat(oData.BalanceAmount));
                _oData.CollectionAmountText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CollectionAmount));
                _oData.TotalDueAmountText = ExcludeDecimal(_oTELLib.TakaFormat(oData.TotalDueAmount));
                _oData.DueAmountText = ExcludeDecimal(_oTELLib.TakaFormat(oData.DueAmount));
                _oData.OverDueAmountText = ExcludeDecimal(_oTELLib.TakaFormat(oData.OverDueAmount));

                eList.Add(_oData);
            }
            return eList;

        }

        public List<Data> getCustomerResult()
        {
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            //foreach (Data oData in this)
            //{
            //    _oData = new Data();
            //    _oData.ChannelID = oData.ChannelID;
            //    _oData.Value = "Success";

            //    _oData.CustomerName = oData.CustomerName;

            //    _oData.CurrentBalanceValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CurrentBalanceValue));
            //    _oData.IsActive = oData.IsActive;

            //    eList.Add(_oData);
            //}
            return eList;

        }

    }
}

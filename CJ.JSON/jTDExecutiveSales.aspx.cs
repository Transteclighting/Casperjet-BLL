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

public partial class jTDExecutiveSales : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();
            string sArea = c.Request.Form["Area"].Trim();
            string sZone = c.Request.Form["Zone"].Trim();
            string sOutlet = c.Request.Form["Outlet"].Trim();

            //string sUser = "hakim";
            //string sCompany = "TEL";
            //string sArea = "National-2";
            //string sZone = "Central-East";
            //string sOutlet = "DMK";


            Data _oData = new Data();
            _oData.InsertReportLog(sUser);

            Datas oDatas = new Datas();
            Datas _oDatas = new Datas();
            Data _oDataTotal = new Data();
            Data _oBUData = new Data();
            int nCount = 0;
            if(!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            
            //oDatas.GetData();
            //foreach (Data oData in oDatas)
            //{
            //    //if (nCount == 0)
            //    //{
            //    //    _oDataTotal = new Data();
            //    //    _oDatas.Add(_oDataTotal);
            //    //    _oDataTotal.Name = "Total";
            //    //    _oDataTotal.Type = "Type1";
            //    //    _oDataTotal.Value = "Success";
            //    //    nCount++;

            //    //}

            //    //_oBUData = new Data();
            //    //_oBUData.Value = "Success";

            //    //_oBUData.Name = oData.Name;
            //    //_oBUData.DTDValue = oData.DTDValue;
            //    //_oBUData.LDValue = oData.LDValue;
            //    //_oBUData.MTDValue = oData.MTDValue;
            //    //_oBUData.LMValue = oData.LMValue;
            //    //_oBUData.YTDValue = oData.YTDValue;
            //    //_oBUData.LYValue = oData.LYValue;
            //    //_oBUData.CMTValue = oData.CMTValue;
            //    //_oBUData.MTDTValue = oData.MTDTValue;
            //    //_oBUData.LMTValue = oData.LMTValue;
            //    //_oBUData.LYYTDValue = oData.LYYTDValue;
            //    //_oBUData.YBLYValue = oData.YBLYValue;

            //    //_oBUData.Type = "Type2";
            //    //_oDatas.Add(_oBUData);

            //    //_oDataTotal.DTDValue = _oDataTotal.DTDValue + oData.DTDValue;
            //    //_oDataTotal.LDValue = _oDataTotal.LDValue + oData.LDValue;
            //    //_oDataTotal.MTDValue = _oDataTotal.MTDValue + oData.MTDValue;
            //    //_oDataTotal.LMValue = _oDataTotal.LMValue + oData.LMValue;
            //    //_oDataTotal.YTDValue = _oDataTotal.YTDValue + oData.YTDValue;
            //    //_oDataTotal.LYValue = _oDataTotal.LYValue + oData.LYValue;
            //    //_oDataTotal.CMTValue = _oDataTotal.CMTValue + oData.CMTValue;
            //    //_oDataTotal.MTDTValue = _oDataTotal.MTDTValue + oData.MTDTValue;
            //    //_oDataTotal.LMTValue = _oDataTotal.LMTValue + oData.LMTValue;
            //    //_oDataTotal.LYYTDValue = _oDataTotal.LYYTDValue + oData.LYYTDValue;
            //    //_oDataTotal.YBLYValue = _oDataTotal.YBLYValue + oData.YBLYValue;

            //}

            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(sArea, sZone, sOutlet), Formatting.Indented);
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
        public string Type;
        public string Name;
        public string BusinessType;
        public string Channel;
        public string BrandType;
        public string SalesPersonID;
        public string EmployeeCode;
        public string EmployeeName;

        public string Today;
        public string LastDay;
        public string CMTarget;
        public string MTDTarget;
        public string ThisMonth;
        public string LMTarget;
        public string LastMonth;
        public string ThisYear;
        public string LYYTD;
        public string LastYear;
        public string YBLY;
        public string CMLeadTgtQty;
        public string CMLeadTgtVal;
        public string NewLeadQty;
        public string NewLeadAmt;
        public string OldLeadQty;
        public string OldLeadAmt;
        public string TotalLeadQty;
        public string TotalLeadAmt;
        public string Lead_Exces_Short_Qty;
        public string Lead_Exces_Short_Amt;
        public string Lead_Exces_Short_QtyPer;
        public string Lead_Exces_Short_AmtPer;
        public string CMLeadSalesQty;
        public string CMLeadSalesVal;
        public string LMLeadSalesQty;
        public string LMLeadSalesVal;
        public string Parent;
        public string Sort;
        public string IsActive;
        public string OwnTP;
        public string EmployeeType;

        public string LeadConvCMQtyPer;
        public string LeadConvCMValPer;
        public string LeadConvLMQtyPer;
        public string LeadConvLMValPer;

        //public string LMTarText;
        public string LMPercText;
        //public string CMTarText;
        public string CMPercText;
        //public string MTDTarText;
        public string MTDPercText;
        public string YTDGthPercText;
        public string YBLYGthPercText;

        //public double CMTarget;
        //public double MTDTarget;
        //public double LMTarget;

        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10052";
            string sReportName = "Executive Performance [122]";
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

        double LMTarget = 0;
        double CMTarget = 0;
        double MTDTarget = 0;
        double LMSales = 0;
        double MTDSales = 0;
        double _YTD = 0;
        double _LYYTD = 0;
        double _YBLY = 0;
        double _LY = 0;
        int _Lead_Exces_Short_Qty;
        double _Lead_Exces_Short_Amt;
        int _CMLeadTargetQty;
        double _CMLeadTargetValue;

        DSTDExecutiveSales _oDSTDExecutiveSales;
        DSTDExecutiveSales _oDSTDExecutiveSalesFilter;

        public void GetData()
        {
            _oDSTDExecutiveSales = new DSTDExecutiveSales();
            _oDSTDExecutiveSalesFilter = new DSTDExecutiveSales();
            Data _oData;
            TELLib _oTELLib = new TELLib();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            //sSQL = @"Select Type,Name,BusinessType,Channel,BrandType,SalesPersonID,EmployeeCode,EmployeeName,Today,
            //        LastDay,CMTarget,MTDTarget,ThisMonth,LMTarget,LastMonth,ThisYear,LYYTD,LastYear,YBLY,CMLeadTgtQty,
            //        CMLeadTgtVal,NewLeadQty,NewLeadAmt,OldLeadQty,OldLeadAmt,CMLeadSalesQty,CMLeadSalesVal,
            //        LMLeadSalesQty,LMLeadSalesVal,Parent,Sort
            //        from DWDB.[dbo].[t_OutletChannelSalesEmployeeSummary] where Type = 'Executive' order by Type, Parent, Name,Sort";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSTDExecutiveSales.TDExecutiveSalesRow oTDExecutiveSalesRow = _oDSTDExecutiveSales.TDExecutiveSales.NewTDExecutiveSalesRow();

                    _oData = new Data();

                    oTDExecutiveSalesRow.Type = (string)reader["Type"];
                    oTDExecutiveSalesRow.Name = (string)reader["Name"];
                    oTDExecutiveSalesRow.BusinessType = (string)reader["BusinessType"];
                    oTDExecutiveSalesRow.Channel = (string)reader["Channel"];
                    oTDExecutiveSalesRow.BrandType = (string)reader["BrandType"];
                    oTDExecutiveSalesRow.SalesPersonID = (string)reader["SalesPersonID"];
                    oTDExecutiveSalesRow.EmployeeCode = (string)reader["EmployeeCode"];
                    oTDExecutiveSalesRow.EmployeeName = (string)reader["EmployeeName"];

                    oTDExecutiveSalesRow.Today = (double)reader["Today"];
                    oTDExecutiveSalesRow.LastDay = (double)reader["LastDay"];
                    oTDExecutiveSalesRow.CMTarget = (double)reader["CMTarget"];
                    oTDExecutiveSalesRow.MTDTarget = (double)reader["MTDTarget"];

                    oTDExecutiveSalesRow.ThisMonth = (double)reader["ThisMonth"];
                    oTDExecutiveSalesRow.LMTarget = (double)reader["LMTarget"];
                    oTDExecutiveSalesRow.LastMonth = (double)reader["LastMonth"];
                    oTDExecutiveSalesRow.ThisYear = (double)reader["ThisYear"];

                    oTDExecutiveSalesRow.LYYTD = (double)reader["LYYTD"];
                    oTDExecutiveSalesRow.LastYear = (double)reader["LastYear"];
                    oTDExecutiveSalesRow.YBLY = (double)reader["YBLY"];
                    oTDExecutiveSalesRow.CMLeadTgtQty = (int)reader["CMLeadTgtQty"];
                    oTDExecutiveSalesRow.CMLeadTgtVal = (double)reader["CMLeadTgtVal"];
                    oTDExecutiveSalesRow.NewLeadQty = (int)reader["NewLeadQty"];
                    oTDExecutiveSalesRow.NewLeadAmt = (double)reader["NewLeadAmt"];
                    oTDExecutiveSalesRow.OldLeadQty = (int)reader["OldLeadQty"];
                    oTDExecutiveSalesRow.OldLeadAmt = (double)reader["OldLeadAmt"];
                    oTDExecutiveSalesRow.CMLeadSalesQty = (int)reader["CMLeadSalesQty"];
                    oTDExecutiveSalesRow.CMLeadSalesVal = (double)reader["CMLeadSalesVal"];

                    oTDExecutiveSalesRow.LMLeadSalesQty = (int)reader["LMLeadSalesQty"];
                    oTDExecutiveSalesRow.LMLeadSalesVal = (double)reader["LMLeadSalesVal"];


                    oTDExecutiveSalesRow.Parent = (string)reader["Parent"];
                    oTDExecutiveSalesRow.Sort = (int)reader["Sort"];

                    _oDSTDExecutiveSales.TDExecutiveSales.AddTDExecutiveSalesRow(oTDExecutiveSalesRow);
                    _oDSTDExecutiveSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

                _oDSTDExecutiveSalesFilter.Merge(_oDSTDExecutiveSales);
                _oDSTDExecutiveSalesFilter.AcceptChanges();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        public List<Data> getResult(string sArea, string sZone, string sOutlet)
        {
            Data _oData;
            List<Data> eList = new List<Data>();
            TELLib _oTELLib = new TELLib();



            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = "Select Type,Name,BusinessType,Channel,BrandType,SalesPersonID,EmployeeCode,EmployeeName,Today, " +
                   " LastDay,CMTarget,MTDTarget,ThisMonth,LMTarget,LastMonth,ThisYear,LYYTD,LastYear,YBLY,CMLeadTgtQty, " +
                   " CMLeadTgtVal,NewLeadQty,NewLeadAmt,OldLeadQty,OldLeadAmt,CMLeadSalesQty,CMLeadSalesVal, " +
                   " LMLeadSalesQty,LMLeadSalesVal,Parent,Sort, Case when IsOwnEmployee='Own' then 'Own' else 'TP' end as OwnTP, " +
                   " Case when IsActive = 1 then 'A' else 'I' end as IsActive, Case when EmployeeType = 'Manager' then 'Mgr' else 'Exe' end as EmployeeType " +
                   " from DWDB.[dbo].[t_OutletChannelSalesEmployeeSummary] where Type = 'Executive'  ";

            if (sOutlet != "All")
            {
                sSQL += " and Parent = '" + sOutlet + "' ";
            }
            else if (sZone != "All")
            {
                sSQL += " and Parent IN (select distinct Name from DWDB.[dbo].[t_OutletChannelSalesEmployeeSummary] "+
                        " where Type = 'Outlet'  and Parent = '"+ sZone + "') ";
            }
            else if (sArea != "All")
            {
                sSQL += " and Parent IN (select distinct Name from DWDB.[dbo].[t_OutletChannelSalesEmployeeSummary] " +
                        " where Type = 'Outlet'  and Parent IN " +
                        " (select distinct Name from DWDB.[dbo].[t_OutletChannelSalesEmployeeSummary] " +
                        " where Type = 'Zone'  and Parent = '" + sArea + "')) ";
            }
            
            sSQL += " order by Type, Parent, IsActive, IsOwnEmployee, ThisMonth desc, LastMonth desc,  Name, Sort  ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oData = new Data();
                    _oData.Name = (string)reader["Name"];
                    _oData.Type = (string)reader["Type"];
                    _oData.BusinessType = (string)reader["BusinessType"];
                    _oData.Channel = (string)reader["Channel"];
                    _oData.BrandType = (string)reader["BrandType"];
                    _oData.SalesPersonID = (string)reader["SalesPersonID"];
                    _oData.EmployeeCode = (string)reader["EmployeeCode"];
                    _oData.EmployeeName = (string)reader["EmployeeName"];
                    _oData.IsActive = (string)reader["IsActive"];
                    _oData.OwnTP = (string)reader["OwnTP"];
                    _oData.EmployeeType = (string)reader["EmployeeType"];
                    
                    _oData.Today = ExcludeDecimal(_oTELLib.TakaFormat((double)reader["Today"]));

                    _oData.LastDay = ExcludeDecimal(_oTELLib.TakaFormat((double)reader["LastDay"]));

                    _oData.CMTarget = ExcludeDecimal(_oTELLib.TakaFormat((double)reader["CMTarget"]));
                    CMTarget = (double)reader["CMTarget"];

                    _oData.MTDTarget = ExcludeDecimal(_oTELLib.TakaFormat((double)reader["MTDTarget"]));
                    MTDTarget = (double)reader["MTDTarget"];

                    _oData.ThisMonth = ExcludeDecimal(_oTELLib.TakaFormat((double)reader["ThisMonth"]));
                    MTDSales = (double)reader["ThisMonth"];

                    _oData.LMTarget = ExcludeDecimal(_oTELLib.TakaFormat((double)reader["LMTarget"]));
                    LMTarget = (double)reader["LMTarget"];

                    _oData.LastMonth = ExcludeDecimal(_oTELLib.TakaFormat((double)reader["LastMonth"]));
                    LMSales = (double)reader["LastMonth"];

                    _oData.ThisYear = ExcludeDecimal(_oTELLib.TakaFormat((double)reader["ThisYear"]));
                    _YTD = (double)reader["ThisYear"];

                    _oData.LYYTD = ExcludeDecimal(_oTELLib.TakaFormat((double)reader["LYYTD"]));
                    _LYYTD = (double)reader["LYYTD"];

                    _oData.LastYear = ExcludeDecimal(_oTELLib.TakaFormat((double)reader["LastYear"]));
                    _LY = (double)reader["LastYear"];

                    _oData.YBLY = ExcludeDecimal(_oTELLib.TakaFormat((double)reader["YBLY"]));
                    _YBLY = (double)reader["YBLY"];

                    _CMLeadTargetQty = (int)reader["CMLeadTgtQty"];
                    _CMLeadTargetValue = (double)reader["CMLeadTgtVal"];

                    _oData.CMLeadTgtQty = Convert.ToString(_CMLeadTargetQty);
                    _oData.CMLeadTgtVal = ExcludeDecimal(_oTELLib.TakaFormat(_CMLeadTargetValue));

                    _oData.NewLeadQty = Convert.ToString((int)reader["NewLeadQty"]);
                    _oData.NewLeadAmt = ExcludeDecimal(_oTELLib.TakaFormat((double)reader["NewLeadAmt"]));

                    _oData.OldLeadQty = Convert.ToString((int)reader["OldLeadQty"]);
                    _oData.OldLeadAmt = ExcludeDecimal(_oTELLib.TakaFormat((double)reader["OldLeadAmt"]));

                    _oData.TotalLeadQty = Convert.ToString((int)reader["NewLeadQty"] + (int)reader["OldLeadQty"]);
                    _oData.TotalLeadAmt = ExcludeDecimal(_oTELLib.TakaFormat((double)reader["NewLeadAmt"] + (double)reader["OldLeadAmt"]));

                    _Lead_Exces_Short_Qty = ((int)reader["NewLeadQty"] + (int)reader["OldLeadQty"]) - (int)reader["CMLeadTgtQty"];
                    _Lead_Exces_Short_Amt = ((double)reader["NewLeadAmt"] + (double)reader["OldLeadAmt"]) - (double)reader["CMLeadTgtVal"];

                    _oData.Lead_Exces_Short_Qty = Convert.ToString(_Lead_Exces_Short_Qty);
                    _oData.Lead_Exces_Short_Amt = ExcludeDecimal(_oTELLib.TakaFormat(_Lead_Exces_Short_Amt));


                    if (_CMLeadTargetQty > 0)
                    {
                        _oData.Lead_Exces_Short_QtyPer = Convert.ToString(Math.Round((Convert.ToDouble(_Lead_Exces_Short_Qty) / _CMLeadTargetQty) * 100));
                    }
                    else
                    {
                        _oData.Lead_Exces_Short_QtyPer = "0";
                    }
                    if (_CMLeadTargetValue > 0)
                    {
                        _oData.Lead_Exces_Short_AmtPer = Convert.ToString(Math.Round((Convert.ToDouble(_Lead_Exces_Short_Amt) / _CMLeadTargetValue) * 100));
                    }
                    else
                    {
                        _oData.Lead_Exces_Short_AmtPer = "0";
                    }
                   
                    _oData.CMLeadSalesQty = Convert.ToString((int)reader["CMLeadSalesQty"]);
                    _oData.CMLeadSalesVal = ExcludeDecimal(_oTELLib.TakaFormat((double)reader["CMLeadSalesVal"]));

                    _oData.LMLeadSalesQty = Convert.ToString((int)reader["LMLeadSalesQty"]);
                    _oData.LMLeadSalesVal = ExcludeDecimal(_oTELLib.TakaFormat((double)reader["LMLeadSalesVal"]));

                    _oData.Parent = Convert.ToString((string)reader["Parent"]);
                    _oData.Sort = Convert.ToString((int)reader["Sort"]);


                    if (CMTarget > 0)
                        _oData.CMPercText = Convert.ToString(Math.Round((MTDSales / CMTarget) * 100));
                    else
                        _oData.CMPercText = "0";

                    if (MTDTarget > 0)
                        _oData.MTDPercText = Convert.ToString(Math.Round((MTDSales / MTDTarget) * 100));
                    else
                        _oData.MTDPercText = "0";

                    if (LMTarget > 0)
                        _oData.LMPercText = Convert.ToString(Math.Round((LMSales / LMTarget) * 100));
                    else
                        _oData.LMPercText = "0";



                    //_oData.LMTarText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMTValue)); 
                    //_oData.LMText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMValue)); 


                    //_oData.YTDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.YTDValue)); 
                    //_oData.LYYTDText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYYTDValue)); 
                    //_oData.LYText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYValue));

                    if (_LYYTD > 0)
                        _oData.YTDGthPercText = Convert.ToString(Math.Round(((_YTD / _LYYTD) * 100) - 100));
                    else
                        _oData.YTDGthPercText = "0";

                    if (_YBLY > 0)
                        _oData.YBLYGthPercText = Convert.ToString(Math.Round(((_LY / _YBLY) * 100) - 100));
                    else
                        _oData.YBLYGthPercText = "0";

                    _oData.LeadConvCMQtyPer = "0";
                    _oData.LeadConvCMValPer = "0";
                    _oData.LeadConvLMQtyPer = "0";
                    _oData.LeadConvLMValPer = "0";


                    _oData.Value = "Success";

                    eList.Add(_oData);

                }
            }
            catch
            {
            }

            return eList;



            //List<Data> lst = _oDSTDExecutiveSalesFilter.Tables[0];

            //DataTable dtt = _oDSTDExecutiveSalesFilter.Tables[0];
            // List<Data> lstCallAssignement = dtt.DataTableToList<Data>();
            //eList = _oDSTDExecutiveSalesFilter.Select();
            //foreach (Data oData in this)
            // foreach (DSTDExecutiveSales.TDExecutiveSalesRow oData in _oDSTDExecutiveSalesFilter.TDExecutiveSales)




        }

    }
}

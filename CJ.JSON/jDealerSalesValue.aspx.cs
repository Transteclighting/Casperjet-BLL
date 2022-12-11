using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Data.OleDb;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using CJ.Class;
using CJ.Class.Library;



public partial class jDealerSalesValue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //This report is replaced by jDealerSalesValueNew.aspx
            HttpContext c = HttpContext.Current;

            //string sUser = c.Request.Form["UserName"].Trim();

            //string sUser = "hakim";

            //Data _oData = new Data();
            //Datas oDatas = new Datas();
            //if (!DBController.Instance.CheckConnection())
            //{
            //    DBController.Instance.OpenNewConnection();
            //}

            //oDatas.GetData();

            //DBController.Instance.CloseConnection();
            //_oData.InsertReportLog(sUser);
            //string sOutput = JsonConvert.SerializeObject(oDatas.getResult(), Formatting.Indented);
            //Response.Write(sOutput.ToString());

        }
    }
    public class Data
    {
        public string SalesFrom;
        public string Incharge;
        public string AreaName;
        public string ZoneName;
        public string ContactNo;
        public string Type;
        public string Name;
        public string Condition;
        public string BrandType;
        public string Parent;

        public double DTDValue;
        public double LDValue;
        public double MTDValue;
        public double LMValue;
        public double YTDValue;
        public double LYValue;

        public double CMTValue;
        public double MTDTValue;
        public double LMTValue;

        public double LYYTDValue;
        public double YBLYValue;

        public string DTDValueText;
        public string LDValueText;
        public string LMValueText;
        public string MTDValueText;
        public string YTDValueText;
        public string LYValueText;

        public string CMTValueText;
        public string MTDTValueText;
        public string LMTValueText;

        public string LYYTDValueText;
        public string YBLYValueText;

        public string CMPercText;
        public string MTDPercText;
        public string LMPercText;
        public string YTDGthPercText;
        public string LYGthPercText;

        public string Value;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10055";
            string sReportName = "Dealer Sales Value [123]";
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
        DSDealerSalesValue _oDSSalesVal = new DSDealerSalesValue();
        DSDealerSalesValue oDSFilteredData = new DSDealerSalesValue();
        private bool Fill_DS(string sCondition)
        {
            DataRow[] oDR = _oDSSalesVal.DealerSalesValue.Select(sCondition);
            oDSFilteredData.Merge(oDR);
            oDSFilteredData.AcceptChanges();

            if (oDR.Length > 0)
                return true;
            else return false;

        }
        public void GetData()
        {

            Datas oDatas = new Datas();

            _oDSSalesVal = oDatas.FillData(_oDSSalesVal);

            //Datas _oAreas = new Datas();
            //_oAreas.GetAllArea();

            Datas _oAreas = new Datas();
            _oAreas.GetAllArea();

            string sCondition = "";

            sCondition = " Type = 'National' and ParentName= 'National'";
            if (Fill_DS(sCondition))
            {
                foreach (Data oArea in _oAreas)
                {
                    sCondition = " Type = 'Area' and Name= '" + oArea.AreaName + "'  and ParentName='National' ";
                    if (Fill_DS(sCondition))
                    {

                        Datas _oZones = new Datas();
                        _oZones.GetAllZone(oArea.AreaName);

                        foreach (Data oZone in _oZones)
                        {
                            //Get Zone
                            sCondition = " Type= 'Zone' and Name= '" + oZone.ZoneName + "' and ParentName='" + oArea.AreaName + "'";
                            if (Fill_DS(sCondition))
                            {
                                //Get Outlet by Zone
                                sCondition = " Type= 'Customer' and ParentName='" + oZone.ZoneName + "'";
                                Fill_DS(sCondition);
                            }

                        }
                    }

                }

            }

        }

        public DSDealerSalesValue FillData(DSDealerSalesValue oDSDealerSalesValue)
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = @"Select Type, Name, BrandType, SalesFrom, Today, LastDay, CMTarget, MTDTarget, ThisMonth, LMTarget, LastMonth, 
                    ThisYear, LYYTD, LastYear, YBLY, Parent, Sort, Incharge, ContactNo From DWDB.DBO.t_DealerSalesSummary ";

            sSQL = string.Format(sSQL);
            try
            {

                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSDealerSalesValue.DealerSalesValueRow oDealerSalesValueRow = oDSDealerSalesValue.DealerSalesValue.NewDealerSalesValueRow();

                    oDealerSalesValueRow.Type = reader["Type"].ToString();
                    oDealerSalesValueRow.Name = reader["Name"].ToString();
                    oDealerSalesValueRow.ParentName = reader["Parent"].ToString();
                    oDealerSalesValueRow.Incharge = reader["Incharge"].ToString();
                    oDealerSalesValueRow.BrandType = reader["BrandType"].ToString();
                    oDealerSalesValueRow.SalesFrom = reader["SalesFrom"].ToString();
                    oDealerSalesValueRow.Contact = reader["ContactNo"].ToString();

                    oDealerSalesValueRow.DTDValue = Convert.ToDouble(reader["Today"]);
                    oDealerSalesValueRow.LDValue = Convert.ToDouble(reader["LastDay"]);
                    oDealerSalesValueRow.MTDValue = Convert.ToDouble(reader["ThisMonth"]);
                    oDealerSalesValueRow.LMValue = Convert.ToDouble(reader["LastMonth"]);
                    oDealerSalesValueRow.YTDValue = Convert.ToDouble(reader["ThisYear"]);
                    oDealerSalesValueRow.LYValue = Convert.ToDouble(reader["LastYear"]);

                    oDealerSalesValueRow.LYYTDValue = Convert.ToDouble(reader["LYYTD"]);

                    oDealerSalesValueRow.CMTValue = Convert.ToDouble(reader["CMTarget"]);
                    oDealerSalesValueRow.MTDTValue = Convert.ToDouble(reader["MTDTarget"]);
                    oDealerSalesValueRow.LMTValue = Convert.ToDouble(reader["LMTarget"]);
                    oDealerSalesValueRow.YBLYValue = Convert.ToDouble(reader["YBLY"]);

                    oDealerSalesValueRow.ParentName = reader["Parent"].ToString();
                   

                    oDSDealerSalesValue.DealerSalesValue.AddDealerSalesValueRow(oDealerSalesValueRow);
                    oDSDealerSalesValue.AcceptChanges();


                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return oDSDealerSalesValue;
        }

        public void GetAllArea()
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = " Select Distinct Name as AreaName, Parent as ParentName, Sort From DWDB.DBO.t_DealerSalesSummary Where Type = 'Area' order by Sort ";
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
                    _oData.Name = reader["ParentName"].ToString();

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

        public void GetAllZone(string sAreaName)
        {

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";
            sSQL = "Select Distinct Name as ZoneName, Parent as ParentName, Sort From DWDB.DBO.t_DealerSalesSummary Where Type = 'Zone' order by Sort ";
            try
            {
                Data _oData;
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oData = new Data();

                    _oData.ZoneName = reader["ZoneName"].ToString();
                    _oData.Name = reader["ParentName"].ToString();

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
            foreach (DSDealerSalesValue.DealerSalesValueRow oData in oDSFilteredData.DealerSalesValue)
            {
                _oData = new Data();              
                _oData.Type = oData.Type;
                _oData.Name = oData.Name;
                _oData.BrandType = oData.BrandType;
                _oData.SalesFrom = oData.SalesFrom;
                _oData.Incharge = oData.Incharge;
                _oData.ContactNo = oData.Contact;
                _oData.Parent = oData.ParentName;
                _oData.Value = "Success";

                _oData.DTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.DTDValue));
                _oData.LDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LDValue));
                _oData.MTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.MTDValue));
                _oData.LMValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMValue));
                _oData.YTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.YTDValue));
                _oData.LYValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYValue));
                _oData.CMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.CMTValue));
                _oData.LMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LMTValue));
                _oData.LYYTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.LYYTDValue));
                _oData.YBLYValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.YBLYValue));

                double _MTDTarget = 0;
                if (oData.CMTValue > 0)
                {
                    //_MTDTarget = oData.CMTValue / nLastDayCM * nDay;
                    _MTDTarget = oData.MTDTValue;

                    _oData.MTDTValueText = ExcludeDecimal(_oTELLib.TakaFormat(_MTDTarget));
                }
                else
                {
                    _oData.MTDTValueText = "0";
                }


                if (oData.CMTValue > 0)
                {
                    _oData.CMPercText = Convert.ToString(Math.Round((oData.MTDValue / oData.CMTValue) * 100));
                }
                else
                {
                    _oData.CMPercText = "0";
                }
                if (_MTDTarget > 0)
                {
                    _oData.MTDPercText = Convert.ToString(Math.Round((oData.MTDValue / _MTDTarget) * 100));
                }
                else
                {
                    _oData.MTDPercText = "0";
                }
                if (oData.LMTValue > 0)
                {
                    _oData.LMPercText = Convert.ToString(Math.Round((oData.LMValue / oData.LMTValue) * 100));
                }
                else
                {
                    _oData.LMPercText = "0";
                }
                if (oData.LYYTDValue > 0)
                {
                    _oData.YTDGthPercText = Convert.ToString(Math.Round(((oData.YTDValue / oData.LYYTDValue) * 100) - 100));
                }
                else
                {
                    _oData.YTDGthPercText = "0";
                }
                if (oData.YBLYValue > 0)
                {
                    _oData.LYGthPercText = Convert.ToString(Math.Round(((oData.LYValue / oData.YBLYValue) * 100) - 100));
                }
                else
                {
                    _oData.LYGthPercText = "0";
                }



                eList.Add(_oData);
            }
            return eList;

        }
    }
}
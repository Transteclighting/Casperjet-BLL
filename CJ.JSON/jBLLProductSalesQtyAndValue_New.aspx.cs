using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Data.OleDb;
using Newtonsoft.Json;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.Library;

public partial class jBLLProductSalesQtyAndValue_New : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();
            //string sChannel = c.Request.Form["Channel"].Trim();
            string sValueType = c.Request.Form["ValueType"].Trim();
            string sValue = c.Request.Form["Value"].Trim();

            //string sCompany = "BLL";
            //string sUser = "sajib";
            //string sChannel = "All";
            //string sValueType = "ByArea";
            //string sValue = "Area-1";

            string sDatabase = "x";

            if (sCompany == "BLL")
            {
                sDatabase = "BLLSysDb";
            }
            else if (sCompany == "TML")
            {
                sDatabase = "TMLSysDB";
            }

            Datas oDatas = new Datas();
            Data _oData = new Data();
            Datas _oDatas = new Datas();
            Datas oDatasBrands = new Datas();
            Data _oDataAllBrand = new Data();
            Data _oDataTotal = new Data();
            Data _oDataBrand = new Data();
            Data _oDataPGTotalTD = new Data();
           // Data _oDataPGTotalRetail = new Data();
            //Data _oDataPGTotalB2B = new Data();
            //Data _oDataPGTotalDealer = new Data();

            Data _oDataPGTotalAll = new Data();
            //Data _oDataPGTotalCAC = new Data();

            int nCount = 0;
            int nTotalCount;

            int nMargetGroupID = 0;

            DBController.Instance.OpenNewConnection();
            //if (sValueType == "ByArea" || sValueType == "ByZone")
            //{
            //    nMargetGroupID = _oData.GetMarketGroupID(sCompany, sDatabase, sValue, sValueType);
            //}
            oDatas.GetData(sCompany, sDatabase, sValue, sValueType, 1);
            //oDatasBrands.GetAllBrandData(sCompany, sDatabase, sChannel, sValue, sValueType, nMargetGroupID);

            DBController.Instance.CloseConnection();

            #region NewLoop
            foreach (Data oData in oDatas)
            {
                nTotalCount = 0;

                if (nCount == 0)
                {
                    _oDataPGTotalAll = new Data();
                    _oDatas.Add(_oDataPGTotalAll);
                    _oDataPGTotalAll.Name = "Total";
                    _oDataPGTotalAll.Type = "PGTotal";
                    _oDataPGTotalAll.Value = "Success";
                    _oDataPGTotalAll.ProductGroupName = "PGTotal";
                    _oDataPGTotalAll.ProductGroupType = "PGTotal";
                    _oDataPGTotalAll.ParentID = "0";
                    _oDataPGTotalAll.ProductGroupID = "0";
                    _oDataPGTotalAll.Channel = "All";

                    //Brand Data

                    foreach (Data oDataBrand in oDatasBrands)
                    {
                        _oDataAllBrand = new Data();
                        _oDataAllBrand.ProductGroupType = oDataBrand.ProductGroupType;
                        _oDataAllBrand.Channel = oDataBrand.Channel;
                        _oDataAllBrand.Name = oDataBrand.BrandName;
                        _oDataAllBrand.ProductGroupName = oDataBrand.ProductGroupName;
                        _oDataAllBrand.ParentID = oDataBrand.ParentID;
                        _oDataAllBrand.ProductGroupID = oDataBrand.ProductGroupID;
                        _oDataAllBrand.Type = "BrandAll";
                        _oDataAllBrand.Value = "Success";

                        _oDataAllBrand.PriDTDQty = oDataBrand.PriDTDQty;
                        _oDataAllBrand.PriLDQty = oDataBrand.PriLDQty;
                        _oDataAllBrand.PriMTDQty = oDataBrand.PriMTDQty;
                        _oDataAllBrand.PriLMQty = oDataBrand.PriLMQty;
                        _oDataAllBrand.PriYTDQty = oDataBrand.PriYTDQty;
                        _oDataAllBrand.PriLYQty = oDataBrand.PriLYQty;
                        _oDataAllBrand.PriLYYTDQty = oDataBrand.PriLYYTDQty;
                        _oDataAllBrand.PriLYMTDQty = oDataBrand.PriLYMTDQty;
                        _oDataAllBrand.PriCMTQty = oDataBrand.PriCMTQty;
                        _oDataAllBrand.PriLMTQty = oDataBrand.PriLMTQty;

                        _oDataAllBrand.PriDTDValue = oDataBrand.PriDTDValue;
                        _oDataAllBrand.PriLDValue = oDataBrand.PriLDValue;
                        _oDataAllBrand.PriMTDValue = oDataBrand.PriMTDValue;
                        _oDataAllBrand.PriLMValue = oDataBrand.PriLMValue;
                        _oDataAllBrand.PriYTDValue = oDataBrand.PriYTDValue;
                        _oDataAllBrand.PriLYValue = oDataBrand.PriLYValue;
                        _oDataAllBrand.PriLYYTDValue = oDataBrand.PriLYYTDValue;
                        _oDataAllBrand.PriLYMTDValue = oDataBrand.PriLYMTDValue;
                        _oDataAllBrand.PriCMTValue = oDataBrand.PriCMTValue;
                        _oDataAllBrand.PriLMTValue = oDataBrand.PriLMTValue;

                        _oDatas.Add(_oDataAllBrand);
                    }

                    nCount++;
                }
                if (_oDataTotal.ProductGroupType != oData.ProductGroupType)
                {
                    nTotalCount++;
                }
                else
                {
                    if (_oDataTotal.Channel != oData.Channel)
                    {
                        nTotalCount++;
                    }
                    else
                    {
                        if (_oDataTotal.ProductGroupName != oData.ProductGroupName)
                        {
                            nTotalCount++;
                        }

                    }
                }
                if (nTotalCount > 0)
                {
                    _oDataTotal = new Data();
                    _oDatas.Add(_oDataTotal);
                    _oDataTotal.ProductGroupType = oData.ProductGroupType;
                    _oDataTotal.Channel = oData.Channel;
                    _oDataTotal.ProductGroupName = oData.ProductGroupName;
                    _oDataTotal.BrandName = oData.BrandName;
                    _oDataTotal.Name = oData.ProductGroupName;
                    _oDataTotal.ParentID = oData.ParentID;
                    _oDataTotal.ProductGroupID = oData.ProductGroupID;
                    _oDataTotal.Type = "Total";
                    _oDataTotal.Value = "Success";
                }

                _oDataBrand = new Data();
                _oDataBrand.ProductGroupType = oData.ProductGroupType;
                _oDataBrand.Channel = oData.Channel;
                _oDataBrand.Name = oData.BrandName;
                _oDataBrand.ProductGroupName = oData.ProductGroupName;
                _oDataBrand.ParentID = oData.ParentID;
                _oDataBrand.ProductGroupID = oData.ProductGroupID;
                _oDataBrand.Type = "Brand";
                _oDataBrand.Value = "Success";

                _oDataBrand.PriDTDQty = oData.PriDTDQty;
                _oDataBrand.PriLDQty = oData.PriLDQty;
                _oDataBrand.PriMTDQty = oData.PriMTDQty;
                _oDataBrand.PriLMQty = oData.PriLMQty;
                _oDataBrand.PriYTDQty = oData.PriYTDQty;
                _oDataBrand.PriLYQty = oData.PriLYQty;
                _oDataBrand.PriLYYTDQty = oData.PriLYYTDQty;
                _oDataBrand.PriLYMTDQty = oData.PriLYMTDQty;
                _oDataBrand.PriCMTQty = oData.PriCMTQty;
                _oDataBrand.PriLMTQty = oData.PriLMTQty;
                _oDataBrand.PriDTDValue = oData.PriDTDValue;
                _oDataBrand.PriLDValue = oData.PriLDValue;
                _oDataBrand.PriMTDValue = oData.PriMTDValue;
                _oDataBrand.PriLMValue = oData.PriLMValue;
                _oDataBrand.PriYTDValue = oData.PriYTDValue;
                _oDataBrand.PriLYValue = oData.PriLYValue;
                _oDataBrand.PriLYYTDValue = oData.PriLYYTDValue;
                _oDataBrand.PriLYMTDValue = oData.PriLYMTDValue;
                _oDataBrand.PriCMTValue = oData.PriCMTValue;
                _oDataBrand.PriLMTValue = oData.PriLMTValue;

                _oDatas.Add(_oDataBrand);

                _oDataTotal.PriDTDQty = _oDataTotal.PriDTDQty + oData.PriDTDQty;
                _oDataTotal.PriLDQty = _oDataTotal.PriLDQty + oData.PriLDQty;
                _oDataTotal.PriMTDQty = _oDataTotal.PriMTDQty + oData.PriMTDQty;
                _oDataTotal.PriLMQty = _oDataTotal.PriLMQty + oData.PriLMQty;
                _oDataTotal.PriYTDQty = _oDataTotal.PriYTDQty + oData.PriYTDQty;
                _oDataTotal.PriLYQty = _oDataTotal.PriLYQty + oData.PriLYQty;
                _oDataTotal.PriLYYTDQty = _oDataTotal.PriLYYTDQty + oData.PriLYYTDQty;
                _oDataTotal.PriLYMTDQty = _oDataTotal.PriLYMTDQty + oData.PriLYMTDQty;
                _oDataTotal.PriCMTQty = _oDataTotal.PriCMTQty + oData.PriCMTQty;
                _oDataTotal.PriLMTQty = _oDataTotal.PriLMTQty + oData.PriLMTQty;
                _oDataTotal.PriDTDValue = _oDataTotal.PriDTDValue + oData.PriDTDValue;
                _oDataTotal.PriLDValue = _oDataTotal.PriLDValue + oData.PriLDValue;
                _oDataTotal.PriMTDValue = _oDataTotal.PriMTDValue + oData.PriMTDValue;
                _oDataTotal.PriLMValue = _oDataTotal.PriLMValue + oData.PriLMValue;
                _oDataTotal.PriYTDValue = _oDataTotal.PriYTDValue + oData.PriYTDValue;
                _oDataTotal.PriLYValue = _oDataTotal.PriLYValue + oData.PriLYValue;
                _oDataTotal.PriLYYTDValue = _oDataTotal.PriLYYTDValue + oData.PriLYYTDValue;
                _oDataTotal.PriLYMTDValue = _oDataTotal.PriLYMTDValue + oData.PriLYMTDValue;
                _oDataTotal.PriCMTValue = _oDataTotal.PriCMTValue + oData.PriCMTValue;
                _oDataTotal.PriLMTValue = _oDataTotal.PriLMTValue + oData.PriLMTValue;


                if (oData.ProductGroupType == "PG")
                {

                    _oDataPGTotalTD.PriDTDQty = _oDataPGTotalTD.PriDTDQty + oData.PriDTDQty;
                    _oDataPGTotalTD.PriLDQty = _oDataPGTotalTD.PriLDQty + oData.PriLDQty;
                    _oDataPGTotalTD.PriMTDQty = _oDataPGTotalTD.PriMTDQty + oData.PriMTDQty;
                    _oDataPGTotalTD.PriLMQty = _oDataPGTotalTD.PriLMQty + oData.PriLMQty;
                    _oDataPGTotalTD.PriYTDQty = _oDataPGTotalTD.PriYTDQty + oData.PriYTDQty;
                    _oDataPGTotalTD.PriLYQty = _oDataPGTotalTD.PriLYQty + oData.PriLYQty;
                    _oDataPGTotalTD.PriLYYTDQty = _oDataPGTotalTD.PriLYYTDQty + oData.PriLYYTDQty;
                    _oDataPGTotalTD.PriLYMTDQty = _oDataPGTotalTD.PriLYMTDQty + oData.PriLYMTDQty;
                    _oDataPGTotalTD.PriCMTQty = _oDataPGTotalTD.PriCMTQty + oData.PriCMTQty;
                    _oDataPGTotalTD.PriLMTQty = _oDataPGTotalTD.PriLMTQty + oData.PriLMTQty;

                    _oDataPGTotalTD.PriDTDValue = _oDataPGTotalTD.PriDTDValue + oData.PriDTDValue;
                    _oDataPGTotalTD.PriLDValue = _oDataPGTotalTD.PriLDValue + oData.PriLDValue;
                    _oDataPGTotalTD.PriMTDValue = _oDataPGTotalTD.PriMTDValue + oData.PriMTDValue;
                    _oDataPGTotalTD.PriLMValue = _oDataPGTotalTD.PriLMValue + oData.PriLMValue;
                    _oDataPGTotalTD.PriYTDValue = _oDataPGTotalTD.PriYTDValue + oData.PriYTDValue;
                    _oDataPGTotalTD.PriLYValue = _oDataPGTotalTD.PriLYValue + oData.PriLYValue;
                    _oDataPGTotalTD.PriLYYTDValue = _oDataPGTotalTD.PriLYYTDValue + oData.PriLYYTDValue;
                    _oDataPGTotalTD.PriLYMTDValue = _oDataPGTotalTD.PriLYMTDValue + oData.PriLYMTDValue;
                    _oDataPGTotalTD.PriCMTValue = _oDataPGTotalTD.PriCMTValue + oData.PriCMTValue;
                    _oDataPGTotalTD.PriLMTValue = _oDataPGTotalTD.PriLMTValue + oData.PriLMTValue;

                }
            }

            #endregion

            if (sCompany == "TEL")
            {
                //if (sType == "All")
                {
                    _oData.InsertReportLog(sUser);
                }
            }
            string sOutput = JsonConvert.SerializeObject(_oDatas.getResult(), Formatting.Indented);
            Response.Write(sOutput);

        }

    }

    public class Data
    {
        public string ProductGroupType;
        public string Channel;
        public string ProductGroupName;
        public string BrandName;
        public string Name;
        public string Type;
        public string ParentID;
        public string ProductGroupID;


        public string RegionShortName;
        public int AreaID;
        public string AreaShortName;
        public int TerritoryID;
        public string TerritoryShortName;
        public int DistributorID;
        public string DistributorName;
        public string Company;
        public int WarehouseID;
        public int ProductGroupSort;
        public int BrandID;
        public int BrandSort;

        public int PriDTDQty;
        public double PriDTDValue;
        public int PriLDQty;
        public double PriLDValue;
        public int PriMTDQty;
        public double PriMTDValue;
        public int PriLMQty;
        public double PriLMValue;
        public int PriYTDQty;
        public double PriYTDValue;
        public int PriLYQty;
        public double PriLYValue;
        public int PriLYYTDQty;
        public double PriLYYTDValue;
        public int PriLYMTDQty;
        public double PriLYMTDValue;
        public int PriCMTQty;
        public double PriCMTValue;
        public int PriLMTQty;
        public double PriLMTValue;


        public int SecDTDQty;
        public double SecDTDValue;
        public int SecLDQty;
        public double SecLDValue;
        public int SecMTDQty;
        public double SecMTDValue;
        public int SecLMQty;
        public double SecLMValue;
        public int SecYTDQty;
        public double SecYTDValue;
        public int SecLYQty;
        public double SecLYValue;
        public int SecLYYTDQty;
        public double SecLYYTDValue;
        public int SecLYMTDQty;
        public double SecLYMTDValue;
        public int SecCMTQty;
        public double SecCMTValue;
        public int SecLMTQty;
        public double SecLMTValue;


        public string PriDTDQtyText;
        public string PriDTDValueText;
        public string PriLDQtyText;
        public string PriLDValueText;
        public string PriMTDQtyText;
        public string PriMTDValueText;
        public string PriLMQtyText;
        public string PriLMValueText;
        public string PriYTDQtyText;
        public string PriYTDValueText;
        public string PriLYQtyText;
        public string PriLYValueText;
        public string PriLYYTDQtyText;
        public string PriLYYTDValueText;
        public string PriLYMTDQtyText;
        public string PriLYMTDValueText;
        public string PriCMTQtyText;
        public string PriCMTValueText;
        public string PriLMTQtyText;
        public string PriLMTValueText;

        public string SecDTDQtyText;
        public string SecDTDValueText;
        public string SecLDQtyText;
        public string SecLDValueText;
        public string SecMTDQtyText;
        public string SecMTDValueText;
        public string SecLMQtyText;
        public string SecLMValueText;
        public string SecYTDQtyText;
        public string SecYTDValueText;
        public string SecLYQtyText;
        public string SecLYValueText;
        public string SecLYYTDQtyText;
        public string SecLYYTDValueText;
        public string SecLYMTDQtyText;
        public string SecLYMTDValueText;
        public string SecCMTQtyText;
        public string SecCMTValueText;
        public string SecLMTQtyText;
        public string SecLMTValueText;

        public string MTDQtyPercText;
        public string LMQtyPercText;
        public string MTDQtyGthPercText;
        public string YTDQtyGthPercText;
        public string MTDValuePercText;
        public string LMValuePercText;
        public string MTDValueGthPercText;
        public string YTDValueGthPercText;

        /*public string DTDQtyText;
        public string DTDValueText;
        public string LDQtyText;
        public string LDValueText;
        public string LMQtyText;
        public string LMValueText;
        public string MTDQtyText;
        public string MTDValueText;
        public string YTDQtyText;
        public string YTDValueText;
        public string LYQtyText;
        public string LYValueText;

        public string LYYTDQtyText;
        public string LYYTDValueText;
        public string LYMTDQtyText;
        public string LYMTDValueText;
        public string CMTQtyText;
        public string CMTValueText;
        public string LMTQtyText;
        public string LMTValueText;*/



        public string Value;

        public int GetMarketGroupID(string sCompany, string sDatabase, string sValue, string sValueType)
        {
            TELLib _oTELLib = new TELLib();

            int nID = 0;

            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            if (sValueType == "ByArea")
            {
                sSQL = " select AreaID as ID from TELSysDB.dbo.v_CustomerDetails a, " +
                       " TELSysDB.dbo.t_Showroom b Where a.CustomerID=b.CustomerID and AreaShortName='" + sValue + "' Group by AreaID ";

            }
            else if (sValueType == "ByZone")
            {
                sSQL = " select TerritoryID as ID from TELSysDB.dbo.v_CustomerDetails a, " +
                       " TELSysDB.dbo.t_Showroom b Where a.CustomerID=b.CustomerID and TerritoryShortName='" + sValue + "' Group by TerritoryID ";
            }
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nID = Convert.ToInt32(reader["ID"]);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nID;
        }

        public void InsertReportLog(string sUser)
        {
            //ReportLog oReportLog = new ReportLog();
            //string sReportCode = "A10002";
            //string sReportName = "Sales Qty and Value";
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

        public void GetData(string sCompany, string sDatabase, string sValue, string sValueType, int nMargetGroupID)
        {
            //TELLib _oTELLib = new TELLib();

            string sSQL = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();


            sSQL = " select ProductGroupType, CASE When ProductGroupType = 'PG' then 1 When ProductGroupType = 'MAG' then 2  " +
                   " When ProductGroupType = 'ASG' then 3 else 4 end as Type, " +
                   " Channel, ProductGroupName, ProductGroupSort, BrandName, BrandSort, ProductGroupID, ParentID, " +
                   " Sum(PriDTDQty) as PriDTDQty, Sum(PriDTDValue) as PriDTDValue, Sum(PriLDQty) as PriLDQty, Sum(PriLDValue) as PriLDValue,  " +
                   " Sum(SecDTDQty) as SecDTDQty, Sum(SecDTDValue) as SecDTDValue, Sum(SecLDQty) as SecLDQty, Sum(SecLDValue) as SecLDValue,  " +
                   " Sum(PriMTDQty) as PriMTDQty, Sum(PriMTDValue) as PriMTDValue, Sum(PriLMQty) as PriLMQty, Sum(PriLMValue) as PriLMValue,  " +
                   " Sum(SecMTDQty) as SecMTDQty, Sum(SecMTDValue) as SecMTDValue, Sum(SecLMQty) as SecLMQty, Sum(SecLMValue) as SecLMValue,  " +
                   " Sum(PriYTDQty) as PriYTDQty, Sum(PriYTDValue) as PriYTDValue, Sum(PriLYQty) as PriLYQty, Sum(PriLYValue) as PriLYValue,  " +
                   " Sum(SecYTDQty) as SecYTDQty, Sum(SecYTDValue) as SecYTDValue, Sum(SecLYQty) as SecLYQty, Sum(SecLYValue) as SecLYValue,  " +
                   " Sum(PriLYYTDQty) as PriLYYTDQty, Sum(PriLYYTDValue) as PriLYYTDValue, Sum(PriLYMTDQty) as PriLYMTDQty, Sum(PriLYMTDValue) as PriLYMTDValue,  " +
                   " Sum(SecLYYTDQty) as SecLYYTDQty, Sum(SecLYYTDValue) as SecLYYTDValue, Sum(SecLYMTDQty) as SecLYMTDQty, Sum(SecLYMTDValue) as SecLYMTDValue,  " +
                   " Sum(PriCMTQty) as PriCMTQty, Sum(PriCMTValue) as PriCMTValue, Sum(PriLMTQty) as PriLMTQty, Sum(PriLMTValue) as PriLMTValue,  " +
                   " Sum(SecCMTQty) as SecCMTQty, Sum(SecCMTValue) as SecCMTValue, Sum(SecLMTQty) as SecLMTQty, Sum(SecLMTValue) as SecLMTValue  " +
                   " from DWDB.dbo.t_SalesDataProductGroupQtyValue a where Company = 'BLL' AND Channel = 'GTM' ";

             /*  if (sValueType == "ByArea")
              {
                  sSQL = sSQL + " and AreaID = " + nMargetGroupID + " ";
              }
              else if (sValueType == "ByZone")
              {
                  sSQL = sSQL + " and TerritoryID = " + nMargetGroupID + " ";
              }
              else if (sValueType == "ByOutlet")
              {
                  sSQL = sSQL + " and ShowroomCode = '" + sValue + "' ";
              }*/

            sSQL += " Group by ProductGroupType, Channel, ProductGroupName, ProductGroupSort, BrandName, BrandSort, ProductGroupID, ParentID " +
                    //" RegionShortName,AreaID,AreaShortName,TerritoryID,TerritoryShortName,DistributorID,DistributorName,Company,WarehouseID,ProductGroupSort,BrandID,BrandSort " +
                    " Order by Type , Channel Desc, ProductGroupSort, ProductGroupName, BrandSort, BrandName ";



            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.ProductGroupType = reader["ProductGroupType"].ToString();
                    oData.ProductGroupName = reader["ProductGroupName"].ToString();
                    oData.Channel = reader["Channel"].ToString();
                    oData.BrandName = reader["BrandName"].ToString();
                    oData.ParentID = reader["ParentID"].ToString();
                    oData.ProductGroupID = reader["ProductGroupID"].ToString();


                    //oData.RegionShortName = reader["RegionShortName"].ToString();
                    //oData.AreaID = (int)reader["AreaID"];
                    //oData.AreaShortName = reader["AreaShortName"].ToString();
                    //oData.TerritoryID = (int)reader["TerritoryID"];
                    //oData.TerritoryShortName = reader["TerritoryShortName"].ToString();
                    //oData.DistributorID = (int)reader["DistributorID"];
                    //oData.DistributorName = reader["DistributorName"].ToString();
                    //oData.Company = reader["DistributorName"].ToString();
                    //oData.WarehouseID = (int)reader["WarehouseID"];
                    //oData.BrandID = (int)reader["BrandID"];

                    oData.ProductGroupSort = (int)reader["ProductGroupSort"];
                    oData.BrandSort = (int)reader["BrandSort"];

                    oData.PriDTDQty = Convert.ToInt32(reader["PriDTDQty"]);
                    oData.PriDTDValue = Convert.ToDouble(reader["PriDTDValue"]);
                    oData.PriLDQty = Convert.ToInt32(reader["PriLDQty"]);
                    oData.PriLDValue = Convert.ToDouble(reader["PriLDValue"]);
                    oData.PriMTDQty = Convert.ToInt32(reader["PriMTDQty"]);
                    oData.PriMTDValue = Convert.ToDouble(reader["PriMTDValue"]);
                    oData.PriLMQty = Convert.ToInt32(reader["PriLMQty"]);
                    oData.PriLMValue = Convert.ToDouble(reader["PriLMValue"]);
                    oData.PriYTDQty = Convert.ToInt32(reader["PriYTDQty"]);
                    oData.PriYTDValue = Convert.ToDouble(reader["PriYTDValue"]);
                    oData.PriLYQty = Convert.ToInt32(reader["PriLYQty"]);
                    oData.PriLYValue = Convert.ToDouble(reader["PriLYValue"]);
                    oData.PriLYYTDQty = Convert.ToInt32(reader["PriLYYTDQty"]);
                    oData.PriLYYTDValue = Convert.ToDouble(reader["PriLYYTDValue"]);
                    oData.PriLYMTDQty = Convert.ToInt32(reader["PriLYMTDQty"]);
                    oData.PriLYMTDValue = Convert.ToDouble(reader["PriLYMTDValue"]);
                    oData.PriCMTQty = Convert.ToInt32(reader["PriCMTQty"]);
                    oData.PriCMTValue = Convert.ToDouble(reader["PriCMTValue"]);
                    oData.PriLMTQty = Convert.ToInt32(reader["PriLMTQty"]);
                    oData.PriLMTValue = Convert.ToDouble(reader["PriLMTValue"]);

                    oData.SecDTDQty = Convert.ToInt32(reader["SecDTDQty"]);
                    oData.SecDTDValue = Convert.ToDouble(reader["SecDTDValue"]);
                    oData.SecLDQty = Convert.ToInt32(reader["SecLDQty"]);
                    oData.SecLDValue = Convert.ToDouble(reader["SecLDValue"]);
                    oData.SecMTDQty = Convert.ToInt32(reader["SecMTDQty"]);
                    oData.SecMTDValue = Convert.ToDouble(reader["SecMTDValue"]);
                    oData.SecLMQty = Convert.ToInt32(reader["SecLMQty"]);
                    oData.SecLMValue = Convert.ToDouble(reader["SecLMValue"]);
                    oData.SecYTDQty = Convert.ToInt32(reader["SecYTDQty"]);
                    oData.SecYTDValue = Convert.ToDouble(reader["SecYTDValue"]);
                    oData.SecLYQty = Convert.ToInt32(reader["SecLYQty"]);
                    oData.SecLYValue = Convert.ToDouble(reader["SecLYValue"]);
                    oData.SecLYYTDQty = Convert.ToInt32(reader["SecLYYTDQty"]);
                    oData.SecLYYTDValue = Convert.ToDouble(reader["SecLYYTDValue"]);
                    oData.SecLYMTDQty = Convert.ToInt32(reader["SecLYMTDQty"]);
                    oData.SecLYMTDValue = Convert.ToDouble(reader["SecLYMTDValue"]);
                    oData.SecCMTQty = Convert.ToInt32(reader["SecCMTQty"]);
                    oData.SecCMTValue = Convert.ToDouble(reader["SecCMTValue"]);
                    oData.SecLMTQty = Convert.ToInt32(reader["SecLMTQty"]);
                    oData.SecLMTValue = Convert.ToDouble(reader["SecLMTValue"]);

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
        public void GetAllBrandData(string sCompany, string sDatabase, string sChannel, string sValue, string sValueType, int nMargetGroupID)
        {
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();

            sSQL = " Select * from " +
                    " (  " +
                    " select 'All' as ProductGroupType, '0' as Type,  " +
                    "  Channel, 'All' as ProductGroupName, 0 as ProductGroupSort, BrandName, BrandSort, 0 as ProductGroupID, 0 as ParentID,  " +
                    " Sum(PriDTDQty) as PriDTDQty, Sum(PriDTDValue) as PriDTDValue, Sum(PriLDQty) as PriLDQty, Sum(PriLDValue) as PriLDValue,   " +
                    " Sum(PriMTDQty) as PriMTDQty, Sum(PriMTDValue) as PriMTDValue, Sum(PriLMQty) as PriLMQty, Sum(PriLMValue) as PriLMValue,   " +
                    " Sum(PriYTDQty) as PriYTDQty, Sum(PriYTDValue) as PriYTDValue, Sum(PriLYQty) as PriLYQty, Sum(PriLYValue) as PriLYValue,   " +
                    " Sum(PriLYYTDQty) as PriLYYTDQty, Sum(PriLYYTDValue) as PriLYYTDValue, Sum(PriLYMTDQty) as PriLYMTDQty, Sum(PriLYMTDValue) as PriLYMTDValue,   " +
                    " Sum(PriCMTQty) as PriCMTQty, Sum(PriCMTValue) as PriCMTValue, Sum(PriLMTQty) as PriLMTQty, Sum(PriLMTValue) as PriLMTValue   " +
                    " from DWDB.dbo.t_SalesDataProductGroupQtyValue a, TELSysDB.dbo.t_Showroom b,  " +
                    " (Select CustomerID, AreaID, TerritoryID, AreaShortName, TerritoryShortName from TELSysDB.dbo.v_CustomerDetails) c " +
                    " Where a.WarehouseID=b.WarehouseID and b.CustomerID=c.CustomerID  " +
                    " and Company='TEL' and Channel in ('TD','Retail','B2B','Dealer') and ProductGroupType = 'PG'  ";
            if (sValueType == "ByArea")
            {
                sSQL = sSQL + " and AreaID = " + nMargetGroupID + " ";
            }
            else if (sValueType == "ByZone")
            {
                sSQL = sSQL + " and TerritoryID = " + nMargetGroupID + " ";
            }
            else if (sValueType == "ByOutlet")
            {
                sSQL = sSQL + " and ShowroomCode = '" + sValue + "' ";
            }

            sSQL = sSQL + " Group by Channel, BrandName, BrandSort  " +
            " )a   " +
            " Order by Type , Channel Desc, BrandSort, BrandName ";


            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.ProductGroupType = reader["ProductGroupType"].ToString();
                    oData.ProductGroupName = reader["ProductGroupName"].ToString();
                    oData.Channel = reader["Channel"].ToString();
                    oData.BrandName = reader["BrandName"].ToString();
                    oData.ParentID = reader["ParentID"].ToString();
                    oData.ProductGroupID = reader["ProductGroupID"].ToString();

                    oData.PriDTDQty = Convert.ToInt32(reader["PriDTDQty"]);
                    oData.PriDTDValue = Convert.ToDouble(reader["PriDTDValue"]);
                    oData.PriLDQty = Convert.ToInt32(reader["PriLDQty"]);
                    oData.PriLDValue = Convert.ToDouble(reader["PriLDValue"]);
                    oData.PriMTDQty = Convert.ToInt32(reader["PriMTDQty"]);
                    oData.PriMTDValue = Convert.ToDouble(reader["PriMTDValue"]);
                    oData.PriLMQty = Convert.ToInt32(reader["PriLMQty"]);
                    oData.PriLMValue = Convert.ToDouble(reader["PriLMValue"]);
                    oData.PriYTDQty = Convert.ToInt32(reader["PriYTDQty"]);
                    oData.PriYTDValue = Convert.ToDouble(reader["PriYTDValue"]);
                    oData.PriLYQty = Convert.ToInt32(reader["PriLYQty"]);
                    oData.PriLYValue = Convert.ToDouble(reader["PriLYValue"]);
                    oData.PriLYYTDQty = Convert.ToInt32(reader["PriLYYTDQty"]);
                    oData.PriLYYTDValue = Convert.ToDouble(reader["PriLYYTDValue"]);
                    oData.PriLYMTDQty = Convert.ToInt32(reader["PriLYMTDQty"]);
                    oData.PriLYMTDValue = Convert.ToDouble(reader["PriLYMTDValue"]);
                    oData.PriCMTQty = Convert.ToInt32(reader["PriCMTQty"]);
                    oData.PriCMTValue = Convert.ToDouble(reader["PriCMTValue"]);
                    oData.PriLMTQty = Convert.ToInt32(reader["PriLMTQty"]);
                    oData.PriLMTValue = Convert.ToDouble(reader["PriLMTValue"]);

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
                _oData.Name = oData.Name;
                _oData.ProductGroupType = oData.ProductGroupType;
                _oData.Channel = oData.Channel;
                _oData.ProductGroupName = oData.ProductGroupName;
                _oData.ParentID = oData.ParentID;
                _oData.ProductGroupID = oData.ProductGroupID;
                _oData.Type = oData.Type;
                _oData.Value = oData.Value;

                _oData.PriDTDQtyText = oData.PriDTDQty.ToString();
                _oData.PriLDQtyText = oData.PriLDQty.ToString();
                _oData.PriMTDQtyText = oData.PriMTDQty.ToString();
                _oData.PriLMQtyText = oData.PriLMQty.ToString();
                _oData.PriYTDQtyText = oData.PriYTDQty.ToString();
                _oData.PriLYQtyText = oData.PriLYQty.ToString();
                _oData.PriLYYTDQtyText = oData.PriLYYTDQty.ToString();
                _oData.PriLYMTDQtyText = oData.PriLYMTDQty.ToString();
                _oData.PriCMTQtyText = oData.PriCMTQty.ToString();
                _oData.PriLMTQtyText = oData.PriLMTQty.ToString();

                _oData.PriDTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriDTDValue));
                _oData.PriLDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriLDValue));
                _oData.PriMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriMTDValue));
                _oData.PriLMValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriLMValue));
                _oData.PriYTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriYTDValue));
                _oData.PriLYValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriLYValue));
                _oData.PriLYYTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriLYYTDValue));
                _oData.PriLYMTDValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriLYMTDValue));
                _oData.PriCMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriCMTValue));
                _oData.PriLMTValueText = ExcludeDecimal(_oTELLib.TakaFormat(oData.PriLMTValue));

                if (oData.PriCMTQty > 0)
                {
                    _oData.MTDQtyPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.PriMTDQty) / oData.PriCMTQty) * 100));
                }
                else
                {
                    _oData.MTDQtyPercText = "0";
                }
                if (oData.PriLMTQty > 0)
                {
                    _oData.LMQtyPercText = Convert.ToString(Math.Round((Convert.ToDouble(oData.PriLMQty) / oData.PriLMTQty) * 100));
                }
                else
                {
                    _oData.LMQtyPercText = "0";
                }
                if (oData.PriLYMTDQty > 0)
                {
                    _oData.MTDQtyGthPercText = Convert.ToString(Math.Round(((Convert.ToDouble(oData.PriMTDQty) / oData.PriLYMTDQty) * 100) - 100));
                }
                else
                {
                    _oData.MTDQtyGthPercText = "0";
                }
                if (oData.PriLYYTDQty > 0)
                {
                    _oData.YTDQtyGthPercText = Convert.ToString(Math.Round(((Convert.ToDouble(oData.PriYTDQty) / oData.PriLYYTDQty) * 100) - 100));
                }
                else
                {
                    _oData.YTDQtyGthPercText = "0";
                }

                ////
                if (oData.PriCMTValue > 0)
                {
                    _oData.MTDValuePercText = Convert.ToString(Math.Round((oData.PriMTDValue / oData.PriCMTValue) * 100));
                }
                else
                {
                    _oData.MTDValuePercText = "0";
                }
                if (oData.PriLMTValue > 0)
                {
                    _oData.LMValuePercText = Convert.ToString(Math.Round((oData.PriLMValue / oData.PriLMTValue) * 100));
                }
                else
                {
                    _oData.LMValuePercText = "0";
                }
                if (oData.PriLYMTDValue > 0)
                {
                    _oData.MTDValueGthPercText = Convert.ToString(Math.Round(((oData.PriMTDValue / oData.PriLYMTDValue) * 100) - 100));
                }
                else
                {
                    _oData.MTDValueGthPercText = "0";
                }
                if (oData.PriLYYTDValue > 0)
                {
                    _oData.YTDValueGthPercText = Convert.ToString(Math.Round(((oData.PriYTDValue / oData.PriLYYTDValue) * 100) - 100));
                }
                else
                {
                    _oData.YTDValueGthPercText = "0";
                }

                eList.Add(_oData);
            }
            return eList;

        }

    }
}
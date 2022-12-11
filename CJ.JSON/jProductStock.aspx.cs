using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Newtonsoft.Json;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.ANDROID;

public partial class jProductStock : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();
            string sType = c.Request.Form["Type"].Trim();
            string sProductCode = c.Request.Form["ProductCode"].Trim();

            //string sUser = "hakim";
            //string sCompany = "TEL";
            //string sType = "ProductAndPlan";
            //string sProductCode = "911118";

            string sDatabase = "x";
            string sWarehouseID = "";
            if (sCompany == "TEL")
            {
                sDatabase = "TELSysDB";
                sWarehouseID = "(65,69,70,108,116,171,173,174,175,178)";
            }
            else if (sCompany == "TML")
            {
                sDatabase = "TMLSysDB";
                sWarehouseID = "(155)";
            }
            Datas _oDatas = new Datas();
            string sOutput = "";
            DBController.Instance.OpenNewConnection();
            //if (sCompany == "TEL")
            {
                if (sType == "ByProduct")
                {
                    Data _oData = new Data();
                    _oData.InsertReportLog(sUser);
                }
                else if (sType == "ProductAndPlan")
                {
                    Data _oData = new Data();
                    _oData.InsertReportLog(sUser);
                }
            }
            if (sType == "ByProduct")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetData(sUser, sDatabase, sWarehouseID), Formatting.Indented);
            }
            else if (sType == "ProductAndPlan")
            {
                if (sCompany == "TEL")
                {
                    sOutput = JsonConvert.SerializeObject(_oDatas.GetDataTEL(sUser), Formatting.Indented);
                }
                else if (sCompany == "TML")
                {
                    sOutput = JsonConvert.SerializeObject(_oDatas.GetDataTML(sUser), Formatting.Indented);
                }
            }
            else if (sType == "ByWarehouse")
            {
                _oDatas.GetSalesData(sCompany, sDatabase, sProductCode, sWarehouseID);

                Datas oDatas = new Datas();
                Data _oDataTotal = new Data();
                Data _oDataWarehouse = new Data();
               
                int nCount = 0;

                foreach (Data oData in _oDatas)
                {
                    if (nCount == 0)
                    {
                        _oDataTotal = new Data();
                        oDatas.Add(_oDataTotal);
                        _oDataTotal.WarehouseCode = "Total";
                        _oDataTotal.Value = "Success";
                        nCount++;
                    }

                    _oDataWarehouse = new Data();
                    _oDataWarehouse.Value = "Success";

                    _oDataWarehouse.WarehouseCode = oData.WarehouseCode;
                    _oDataWarehouse.nCurrentStock = Convert.ToInt32(oData.CurrentStock);
                    _oDataWarehouse.nMTDSale = Convert.ToInt32(oData.MTDSale);
                    _oDataWarehouse.nLMSale = Convert.ToInt32(oData.LMSale);
                    _oDataWarehouse.nYTDSale = Convert.ToInt32(oData.YTDSale);
                    oDatas.Add(_oDataWarehouse);

                    _oDataTotal.nCurrentStock = _oDataTotal.nCurrentStock + Convert.ToInt32(oData.CurrentStock);
                    _oDataTotal.nMTDSale = _oDataTotal.nMTDSale + Convert.ToInt32(oData.MTDSale);
                    _oDataTotal.nLMSale = _oDataTotal.nLMSale + Convert.ToInt32(oData.LMSale);
                    _oDataTotal.nYTDSale = _oDataTotal.nYTDSale + Convert.ToInt32(oData.YTDSale);

                }

                sOutput = JsonConvert.SerializeObject(oDatas.GetWarehouseWiseStock(), Formatting.Indented);
            }
            Response.Write(sOutput.ToString());

            DBController.Instance.CloseConnection();
        }
    }
    public class Data
    {
        public string ProductCode;
        public string ProductName;
        public string InventoryCategory;
        public string PGID;
        public string MAGID;
        public string MAGName;
        public string ASGID;
        public string ASGName;
        public string AGID;
        public string AGName;
        public string BrandID;
        public string BrandName;
        public string VAT;
        public string CP;
        public string NSP;
        public string RSP;
        public string CRWStk;
        public string TDStk;
        public string TotalStk;
        public string Value;
        public string CPPermission;
        public string NSPPermission;

        public string WarehouseCode;
        public string CurrentStock;
        public string MTDSale;
        public string LMSale;
        public string YTDSale;
        public string LYSale;

        public int nCurrentStock;
        public int nMTDSale;
        public int nLMSale;
        public int nYTDSale;
        public int nLYSale;

        public string CMGRDQty;
        public string CMSalesQty;
        public string M0Sales;
        public string M0Arrival;
        public string M1Sales;
        public string M1Arrival;
        public string M2Sales;
        public string M2Arrival;
        public string M3Sales;
        public string M3Arrival;
        public string M4Sales;
        public string M4Arrival;

        public string RestM0Sales;
        public string RestM0Arrival;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10017";
            string sReportName = "TEL-Product Price & Stock";
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
        }

        public string CheckCPPermission(String sUser)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select * from t_User a, t_UserPermission b Where a.UserID=b.UserID "+
                          " and UserName='" + sUser + "' and PermissionKey='M41.1.13.1'";

            int nCount = 0;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }
        public string CheckNSPPermission(String sUser)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select * from t_User a, t_UserPermission b Where a.UserID=b.UserID " +
                          " and UserName='" + sUser + "' and PermissionKey='M41.1.13.2'";

            int nCount = 0;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCount++;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (nCount != 0)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }
    }
    public class Datas : CollectionBase
    {
        TELLib oTELLib = new TELLib();
        public Data this[int i]
        {
            get { return (Data)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Data oData)
        {
            InnerList.Add(oData);
        }
        public void GetSalesDataxxxxxxxxxxxxxx(string sCompany, string sDatabase, string sProductCode, string sWarehouseID)
        {
            TELLib _oTELLib = new TELLib();

            DSOutletProductSales oDSOutletStock = new DSOutletProductSales();
            DSOutletProductSales oDSMTDSales = new DSOutletProductSales();
            DSOutletProductSales oDSLMSales = new DSOutletProductSales();
            DSOutletProductSales oDSYTDSales = new DSOutletProductSales();

            DateTime dFromDate = DateTime.Now.Date;
            DateTime dToDate = dFromDate.AddDays(1);
            DateTime dLastDate = dFromDate.AddDays(-1);
            DateTime _FirstDayofMonth = _oTELLib.FirstDayofMonth(dFromDate);
            DateTime _FirstDayofLastMonth = _oTELLib.FirstDayofLastMonth(dFromDate);

            string sSQL = "";
            #region Stock
           OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";

            {
            sSQL = " Select WarehouseCode, CurrentStock from  " +
               " (  " +
               " Select ShortCode as WarehouseCode,(CurrentStock-BookingStock) as CurrentStock, 1 as SortOrder   " +
               " from " + sDatabase + ".dbo.t_ProductStock a, (select WarehouseID, ShortCode from " + sDatabase + ".dbo.t_Warehouse) b,  " +
               " " + sDatabase + ".dbo.t_Product c Where a.WarehouseID=b.WarehouseID and a.WarehouseID IN " + sWarehouseID + " and CurrentStock>0  " +
               " and a.ProductID=c.ProductID  and ProductCode='" + sProductCode + "' " +
               " UNION ALL   " +
               " Select ShortCode, IsNull(CurrentStock,0) as CurrentStock, 2 as SortOrder from  "+
               " (select WarehouseID, ShowroomCode as ShortCode from " + sDatabase + ".dbo.t_Showroom Where IsPOSActive=1)b " +
               " left Outer JOIN "+
               " (Select a.WarehouseID, CurrentStock from " + sDatabase + ".dbo.t_ProductStock a,  " + sDatabase + ".dbo.t_Product b  " +
               " Where a.ProductID=b.ProductID and CurrentStock>0 and ProductCode='" + sProductCode + "')a " +
               " ON a.WarehouseID=b.WarehouseID " +
               " ) a "+
               " Order by SortOrder,WarehouseCode ";
            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSOutletStock.ProductSales.NewProductSalesRow();

                    oProductSalesRow.Outlet = reader["WarehouseCode"].ToString();
                    oProductSalesRow.Qty = reader["CurrentStock"].ToString();

                    oDSOutletStock.ProductSales.AddProductSalesRow(oProductSalesRow);
                    oDSOutletStock.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            #endregion
            #region MTD Sales & Value
            cmd = DBController.Instance.GetCommand();
            sSQL = "";

            {
                sSQL = " select  ShowroomCode as Outlet, Sum(SalesQty+FreeQty) as Qty from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                       " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate    " +
                       " BETWEEN CONVERT(varchar, MONTH(GETDATE())) + '/1/' + CONVERT(varchar, YEAR(GETDATE()))   " +
                       "  AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))     " +
                       " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ProductCode='" + sProductCode + "' Group By ShowroomCode  ";
            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSMTDSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.Outlet = reader["Outlet"].ToString();
                    oProductSalesRow.Qty = reader["Qty"].ToString();

                    oDSMTDSales.ProductSales.AddProductSalesRow(oProductSalesRow);
                    oDSMTDSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
            #region LM Sales & Value
            cmd = DBController.Instance.GetCommand();
            sSQL = "";


            sSQL = " select ShowroomCode as Outlet, Sum(SalesQty+FreeQty) as Qty from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                   " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and InvoiceDate  " +
                   " BETWEEN '" + _FirstDayofLastMonth + "' and '" + _FirstDayofMonth + "' and InvoiceDate < '" + _FirstDayofMonth + "'  " +
                   " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ProductCode='" + sProductCode + "' group by ShowroomCode";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSLMSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.Outlet = reader["Outlet"].ToString();
                    oProductSalesRow.Qty = reader["Qty"].ToString();

                    oDSLMSales.ProductSales.AddProductSalesRow(oProductSalesRow);
                    oDSLMSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion
            #region YTD Sales & Value
            cmd = DBController.Instance.GetCommand();
            sSQL = "";

            sSQL = " select  ShowroomCode as Outlet, Sum(SalesQty+FreeQty) as Qty from DWDB.dbo.t_SalesDataCustomerProduct a, DWDB.dbo.t_ProductDetails b,  " +
                   " " + sDatabase + ".dbo.t_Showroom c  Where a.ProductID=b.ProductID and a.WarehouseID=c.WarehouseID and (InvoiceDate    " +
                   " BETWEEN '1/1/' + CONVERT(varchar, YEAR(GETDATE()))    " +
                   " AND '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1)) AND (InvoiceDate < '1/1/' + CONVERT(varchar, YEAR(GETDATE()) + 1))     " +
                   " and a.CompanyName='" + sCompany + "' and b.CompanyName='" + sCompany + "' and ProductCode='" + sProductCode + "' group by ShowroomCode ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DSOutletProductSales.ProductSalesRow oProductSalesRow = oDSYTDSales.ProductSales.NewProductSalesRow();

                    oProductSalesRow.Outlet = reader["Outlet"].ToString();
                    oProductSalesRow.Qty = reader["Qty"].ToString();

                    oDSYTDSales.ProductSales.AddProductSalesRow(oProductSalesRow);
                    oDSYTDSales.AcceptChanges();
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            #endregion

            Data _oData;
            InnerList.Clear();

            foreach (DSOutletProductSales.ProductSalesRow oSalesValueRow in oDSOutletStock.ProductSales)
            {

                _oData = new Data();
                _oData.WarehouseCode = oSalesValueRow.Outlet;
                _oData.CurrentStock = oSalesValueRow.Qty;

                //MTD
                DSOutletProductSales oDSFilteredMTD = new DSOutletProductSales();
                DataRow[] oDRMTD = oDSMTDSales.ProductSales.Select(" Outlet= '" + oSalesValueRow.Outlet + "'");
                oDSFilteredMTD.Merge(oDRMTD);
                oDSFilteredMTD.AcceptChanges();

                if (oDSFilteredMTD.ProductSales.Count > 0)
                {
                    foreach (DSOutletProductSales.ProductSalesRow oMTDSalesValueRow in oDSFilteredMTD.ProductSales)
                    {
                        _oData.MTDSale = oMTDSalesValueRow.Qty;
                    }
                }
                else
                {
                    _oData.MTDSale = "0";
                }
                //LM
                DSOutletProductSales oDSFilteredLM = new DSOutletProductSales();
                DataRow[] oDRLM = oDSLMSales.ProductSales.Select(" Outlet= '" + oSalesValueRow.Outlet + "'");
                oDSFilteredLM.Merge(oDRLM);
                oDSFilteredLM.AcceptChanges();

                if (oDSFilteredLM.ProductSales.Count > 0)
                {
                    foreach (DSOutletProductSales.ProductSalesRow oLMSalesValueRow in oDSFilteredLM.ProductSales)
                    {
                        _oData.LMSale = oLMSalesValueRow.Qty;
                    }
                }
                else
                {
                    _oData.LMSale = "0";
                }
                //YTD
                DSOutletProductSales oDSFilteredYTD = new DSOutletProductSales();
                DataRow[] oDRYTD = oDSYTDSales.ProductSales.Select(" Outlet= '" + oSalesValueRow.Outlet + "'");
                oDSFilteredYTD.Merge(oDRYTD);
                oDSFilteredYTD.AcceptChanges();
                if (oDSFilteredYTD.ProductSales.Count > 0)
                {
                    foreach (DSOutletProductSales.ProductSalesRow oYTDSalesValueRow in oDSFilteredYTD.ProductSales)
                    {
                        _oData.YTDSale = oYTDSalesValueRow.Qty;
                    }
                }
                else
                {
                    _oData.YTDSale = "0";
                }
                InnerList.Add(_oData);
            }


        }
        public void GetSalesData(string sCompany, string sDatabase, string sProductCode, string sWarehouseID)
        {
            TELLib _oTELLib = new TELLib();

            

            string sSQL = "";

            OleDbCommand cmd = DBController.Instance.GetCommand();
            sSQL = "";

            if (sCompany == "TEL")
            {
                sSQL = " Select WarehouseCode, CurrentStock, IsNull(MTDSaleQty,0) as MTDSaleQty, IsNull(LMSaleQty,0) as LMSaleQty, " +
                 " IsNull(YTDSaleQty,0) as YTDSaleQty, IsNull(LYSaleQty,0) as LYSaleQty from   " +
                 " (   " +
                 " Select a.WarehouseID, ShortCode as WarehouseCode,(CurrentStock-BookingStock) as CurrentStock, 1 as SortOrder    " +
                 " from  TELSysDB.dbo.t_ProductStock a, (select WarehouseID, ShortCode from  TELSysDB.dbo.t_Warehouse) b,   " +
                 " TELSysDB.dbo.t_Product c Where a.WarehouseID=b.WarehouseID and a.WarehouseID IN  " + sWarehouseID + " and CurrentStock>0   " +
                 " and a.ProductID=c.ProductID  and ProductCode='" + sProductCode + "'  " +
                 " UNION ALL    " +
                 " Select b.WarehouseID, ShortCode, IsNull(CurrentStock,0) as CurrentStock, 2 as SortOrder from   " +
                 " (select WarehouseID, ShowroomCode as ShortCode from  TELSysDB.dbo.t_Showroom Where IsPOSActive=1)b  " +
                 " left Outer JOIN  " +
                 " (Select a.WarehouseID, CurrentStock, b.ProductID from  TELSysDB.dbo.t_ProductStock a, TELSysDB.dbo.t_Product b   " +
                 " Where a.ProductID=b.ProductID and CurrentStock>0 and ProductCode='" + sProductCode + "')a  " +
                 " ON a.WarehouseID=b.WarehouseID  " +
                 " ) a  " +
                 " Left Outer JOIN " +
                 " (Select a.* from DWDB.dbo.t_SalesQtyProductWarehouse a, TELSysDB.dbo.t_Product b  " +
                 " Where a.ProductID=b.ProductID and ProductCode='" + sProductCode + "' and Company = '" + sCompany + "')b " +
                 " ON a.WarehouseID=b.WarehouseID " +
                 " Where CurrentStock + IsNull(MTDSaleQty,0) + IsNull(LMSaleQty,0) + IsNull(YTDSaleQty,0)+ IsNull(LYSaleQty,0)>0 " +
                 " Order by SortOrder,WarehouseCode  ";
            }

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data _oData = new Data();

                    _oData.WarehouseCode = reader["WarehouseCode"].ToString();
                    _oData.CurrentStock = reader["CurrentStock"].ToString();

                    _oData.MTDSale = reader["MTDSaleQty"].ToString();
                    _oData.LMSale = reader["LMSaleQty"].ToString();
                    _oData.YTDSale = reader["YTDSaleQty"].ToString();
                    _oData.LYSale = reader["LYSaleQty"].ToString();

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


        public List<Data> GetWarehouseWiseStock()
        {

            List<Data> eList = new List<Data>();
            Data _oData; 
            foreach (Data oData in this)
            {
                _oData = new Data();

                //int nQty = oData.nCurrentStock + oData.nYTDSale;
                //if (nQty > 0)
                //{
                    _oData.Value = "Success";
                    _oData.WarehouseCode = oData.WarehouseCode;
                    _oData.CurrentStock = oData.nCurrentStock.ToString();
                    _oData.MTDSale = oData.nMTDSale.ToString();
                    _oData.LMSale = oData.nLMSale.ToString();
                    _oData.YTDSale = oData.nYTDSale.ToString();

                    eList.Add(_oData);
               // }
            }

            return eList;
        }
        private string ExcludeDecimal(string sAmount)
        {
            string sResult = "";
            sResult = sAmount.Remove(sAmount.Length - 3);
            return sResult;
        }

        public List<Data> GetData(String sUser, string sDatabase, string sWarehouseID)
        {
            string IsCPPermission = "";
            Data oCPPermission = new Data();
            IsCPPermission = oCPPermission.CheckCPPermission(sUser);

            string IsNSPPremission = "";
            Data oNSPPermission = new Data();
            IsNSPPremission = oNSPPermission.CheckNSPPermission(sUser);

            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = " Select ProductCode, ProductName, InventoryCategory, PGID, PGName, MAGID, MAGName, ASGID, ASGName, AGID, AGName, BrandID, BrandDesc as BrandName, (VAT*100) as VAT,  " +
                          "  CostPrice as CP, NSP, RSP,CRWStk, TDStk, (CRWStk + TDStk) as TotalStk from   " +
                          "  (Select ProductID, Sum(CRWStk) as CRWStk, Sum(TDStk) as TDStk  " +
                          "  from   " +
                          "  (  " +
                          "  Select ProductID, (CurrentStock-BookingStock) as CRWStk, 0 as TDStk from " + sDatabase + ".dbo.t_ProductStock Where WarehouseID IN " + sWarehouseID + " and CurrentStock>0  " +
                          "  UNION ALL  " +
                          "  Select ProductID, 0 as CRWStk, Sum(CurrentStock) TDStk from " + sDatabase + ".dbo.t_ProductStock a, " + sDatabase + ".dbo.t_Showroom b " +
                          "  Where a.WarehouseID=b.WarehouseID and CurrentStock>0  " +
                          "  Group by ProductID  " +
                          "  ) a Group by ProductID)Stk,  " +
                          "  (Select * from " + sDatabase + ".dbo.v_ProductDetails Where ProductType=1)Prod Where Stk.ProductID=Prod.ProductID  " +
                          "  Order by ProductName ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.CPPermission = IsCPPermission;
                    oData.NSPPermission = IsNSPPremission;
                    oData.Value = "Success";
                    oData.ProductCode = reader["ProductCode"].ToString();
                    oData.ProductName = reader["ProductName"].ToString();
                    oData.InventoryCategory = reader["InventoryCategory"].ToString();
                    oData.PGID = reader["PGID"].ToString();
                    oData.MAGID = reader["MAGID"].ToString();
                    oData.ASGID = reader["ASGID"].ToString();
                    oData.AGID = reader["AGID"].ToString();
                    oData.MAGName = reader["MAGName"].ToString();
                    oData.BrandID = reader["BrandID"].ToString();
                    oData.BrandName = reader["BrandName"].ToString();
                    oData.VAT = reader["VAT"].ToString();
                    if (reader["CP"] != DBNull.Value)
                    {
                        oData.CP = ExcludeDecimal(oTELLib.TakaFormat(Convert.ToDouble(reader["CP"])));
                    }
                    else
                    {
                        oData.CP = "0";
                    }
                    if (reader["NSP"] != DBNull.Value)
                    {
                        oData.NSP = ExcludeDecimal(oTELLib.TakaFormat(Convert.ToDouble(reader["NSP"])));
                    }
                    else
                    {
                        oData.NSP = "0";
                    }
                    if (reader["RSP"] != DBNull.Value)
                    {
                        oData.RSP = ExcludeDecimal(oTELLib.TakaFormat(Convert.ToDouble(reader["RSP"])));
                    }
                    else
                    {
                        oData.RSP = "0";
                    }
                    oData.CRWStk = reader["CRWStk"].ToString();
                    oData.TDStk = reader["TDStk"].ToString();
                    oData.TotalStk = reader["TotalStk"].ToString();

                    eList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return eList;
        }

        public List<Data> GetDataTEL(String sUser)
        {
            string IsCPPermission = "";
            Data oCPPermission = new Data();
            IsCPPermission = oCPPermission.CheckCPPermission(sUser);

            string IsNSPPremission = "";
            Data oNSPPermission = new Data();
            IsNSPPremission = oNSPPermission.CheckNSPPermission(sUser);

            int _nGRDQty = 0;
            int _nSalesQty = 0;
            int _nM0Sales = 0;
            int _nM0Arrival = 0;

            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = " Select ProductCode, ProductName, InventoryCategory, PGID, PGName, MAGID, MAGName, ASGID, ASGName, AGID, AGName, BrandID, BrandDesc as BrandName, (VAT*100) as VAT,  " +
                          " CostPrice as CP, NSP, RSP,CentralStk as CRWStk, TDStk, (CentralStk + TDStk) as TotalStk, CMGRDQty, CMSalesQty, M0Sales, M0Arrival, M1Sales, M1Arrival, M2Sales,  " +
                          " M2Arrival, M3Sales, M3Arrival, M4Sales, M4Arrival from DWDB.dbo.t_StockVsArrivalPlan a,  " +
                          " TELSysDB.dbo.v_ProductDetails b " +
                          " Where a.ProductID = b.ProductID and Company='TEL' and  " +
                          " (CentralStk + TDStk + CMGRDQty + CMSalesQty + M0Sales + M0Arrival + M1Sales + M1Arrival + M2Sales + M2Arrival + M3Sales + M3Arrival + M4Sales + M4Arrival) >0 " +
                          " Order by ProductName ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.CPPermission = IsCPPermission;
                    oData.NSPPermission = IsNSPPremission;
                    oData.Value = "Success";
                    oData.ProductCode = reader["ProductCode"].ToString();
                    oData.ProductName = reader["ProductName"].ToString();
                    oData.InventoryCategory = reader["InventoryCategory"].ToString();
                    oData.PGID = reader["PGID"].ToString();
                    oData.MAGID = reader["MAGID"].ToString();
                    oData.ASGID = reader["ASGID"].ToString();
                    oData.AGID = reader["AGID"].ToString();
                    oData.MAGName = reader["MAGName"].ToString();
                    oData.BrandID = reader["BrandID"].ToString();
                    oData.BrandName = reader["BrandName"].ToString();
                    oData.VAT = reader["VAT"].ToString();
                    if (reader["CP"] != DBNull.Value)
                    {
                        oData.CP = ExcludeDecimal(oTELLib.TakaFormat(Convert.ToDouble(reader["CP"])));
                    }
                    else
                    {
                        oData.CP = "0";
                    }
                    if (reader["NSP"] != DBNull.Value)
                    {
                        oData.NSP = ExcludeDecimal(oTELLib.TakaFormat(Convert.ToDouble(reader["NSP"])));
                    }
                    else
                    {
                        oData.NSP = "0";
                    }
                    if (reader["RSP"] != DBNull.Value)
                    {
                        oData.RSP = ExcludeDecimal(oTELLib.TakaFormat(Convert.ToDouble(reader["RSP"])));
                    }
                    else
                    {
                        oData.RSP = "0";
                    }
                    oData.CRWStk = reader["CRWStk"].ToString();
                    oData.TDStk = reader["TDStk"].ToString();
                    oData.TotalStk = reader["TotalStk"].ToString();

                    oData.CMGRDQty = reader["CMGRDQty"].ToString();
                    oData.CMSalesQty = reader["CMSalesQty"].ToString();
                    oData.M0Sales = reader["M0Sales"].ToString();
                    oData.M0Arrival = reader["M0Arrival"].ToString();

                    _nGRDQty = Convert.ToInt32(reader["CMGRDQty"]);
                    _nSalesQty = Convert.ToInt32(reader["CMSalesQty"]);
                    _nM0Sales = Convert.ToInt32(reader["M0Sales"]);
                    _nM0Arrival = Convert.ToInt32(reader["M0Arrival"]);

                    oData.RestM0Sales = Convert.ToString(_nM0Sales - _nSalesQty);
                    oData.RestM0Arrival = Convert.ToString(_nM0Arrival - _nGRDQty);

                    oData.M1Sales = reader["M1Sales"].ToString();
                    oData.M1Arrival = reader["M1Arrival"].ToString();
                    oData.M2Sales = reader["M2Sales"].ToString();
                    oData.M2Arrival = reader["M2Arrival"].ToString();
                    oData.M3Sales = reader["M3Sales"].ToString();
                    oData.M3Arrival = reader["M3Arrival"].ToString();
                    oData.M4Sales = reader["M4Sales"].ToString();
                    oData.M4Arrival = reader["M4Arrival"].ToString();

                    eList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return eList;
        }

        public List<Data> GetDataTML(String sUser)
        {
            string IsCPPermission = "";
            Data oCPPermission = new Data();
            IsCPPermission = oCPPermission.CheckCPPermission(sUser);

            int _nGRDQty = 0;
            int _nSalesQty = 0;
            int _nM0Sales = 0;
            int _nM0Arrival = 0;

            string IsNSPPremission = "";
            Data oNSPPermission = new Data();
            IsNSPPremission = oNSPPermission.CheckNSPPermission(sUser);

            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = " Select ProductCode, ProductName, InventoryCategory, PGID, PGName, MAGID, MAGName, ASGID, ASGName, AGID, AGName, BrandID, BrandDesc as BrandName, (VAT*100) as VAT,  " +
                          " CostPrice as CP, NSP, RSP,CentralStk as CRWStk, TDStk, (CentralStk + TDStk) as TotalStk, CMGRDQty, CMSalesQty, M0Sales, M0Arrival, M1Sales, M1Arrival, M2Sales,  " +
                          " M2Arrival, M3Sales, M3Arrival, M4Sales, M4Arrival from DWDB.dbo.t_StockVsArrivalPlan a,  " +
                          " TMLSysDB.dbo.v_ProductDetails b " +
                          " Where a.ProductID = b.ProductID and Company='TML' and  " +
                          " (CentralStk + TDStk + CMGRDQty + CMSalesQty + M0Sales + M0Arrival + M1Sales + M1Arrival + M2Sales + M2Arrival + M3Sales + M3Arrival + M4Sales + M4Arrival) >0 " +
                          " Order by ProductName ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.CPPermission = IsCPPermission;
                    oData.NSPPermission = IsNSPPremission;
                    oData.Value = "Success";
                    oData.ProductCode = reader["ProductCode"].ToString();
                    oData.ProductName = reader["ProductName"].ToString();
                    oData.InventoryCategory = reader["InventoryCategory"].ToString();
                    oData.PGID = reader["PGID"].ToString();
                    oData.MAGID = reader["MAGID"].ToString();
                    oData.ASGID = reader["ASGID"].ToString();
                    oData.AGID = reader["AGID"].ToString();
                    oData.MAGName = reader["MAGName"].ToString();
                    oData.BrandID = reader["BrandID"].ToString();
                    oData.BrandName = reader["BrandName"].ToString();
                    oData.VAT = reader["VAT"].ToString();
                    if (reader["CP"] != DBNull.Value)
                    {
                        oData.CP = ExcludeDecimal(oTELLib.TakaFormat(Convert.ToDouble(reader["CP"])));
                    }
                    else
                    {
                        oData.CP = "0";
                    }
                    if (reader["NSP"] != DBNull.Value)
                    {
                        oData.NSP = ExcludeDecimal(oTELLib.TakaFormat(Convert.ToDouble(reader["NSP"])));
                    }
                    else
                    {
                        oData.NSP = "0";
                    }
                    if (reader["RSP"] != DBNull.Value)
                    {
                        oData.RSP = ExcludeDecimal(oTELLib.TakaFormat(Convert.ToDouble(reader["RSP"])));
                    }
                    else
                    {
                        oData.RSP = "0";
                    }
                    oData.CRWStk = reader["CRWStk"].ToString();
                    oData.TDStk = reader["TDStk"].ToString();
                    oData.TotalStk = reader["TotalStk"].ToString();

                    oData.CMGRDQty = reader["CMGRDQty"].ToString();
                    oData.CMSalesQty = reader["CMSalesQty"].ToString();
                    oData.M0Sales = reader["M0Sales"].ToString();
                    oData.M0Arrival = reader["M0Arrival"].ToString();

                    _nGRDQty = Convert.ToInt32(reader["CMGRDQty"]);
                    _nSalesQty = Convert.ToInt32(reader["CMSalesQty"]);
                    _nM0Sales = Convert.ToInt32(reader["M0Sales"]);
                    _nM0Arrival = Convert.ToInt32(reader["M0Arrival"]);

                    oData.RestM0Sales = Convert.ToString(_nM0Sales - _nSalesQty);
                    oData.RestM0Arrival = Convert.ToString(_nM0Arrival - _nGRDQty);

                    oData.M1Sales = reader["M1Sales"].ToString();
                    oData.M1Arrival = reader["M1Arrival"].ToString();
                    oData.M2Sales = reader["M2Sales"].ToString();
                    oData.M2Arrival = reader["M2Arrival"].ToString();
                    oData.M3Sales = reader["M3Sales"].ToString();
                    oData.M3Arrival = reader["M3Arrival"].ToString();
                    oData.M4Sales = reader["M4Sales"].ToString();
                    oData.M4Arrival = reader["M4Arrival"].ToString();

                    eList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return eList;
        } 
    }
}

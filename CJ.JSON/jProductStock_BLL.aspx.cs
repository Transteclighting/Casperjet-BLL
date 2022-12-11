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

public partial class jProductStock_BLL : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();

            //string sUser = "hakim";

            Datas _oDatas = new Datas();
            string sOutput = "";
            DBController.Instance.OpenNewConnection();

            Data _oData = new Data();
            _oData.InsertReportLog(sUser);

            sOutput = JsonConvert.SerializeObject(_oDatas.GetData(sUser), Formatting.Indented);
          
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
        public string StockValue;

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

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10043";
            string sReportName = "BLL-Product Price & Stock";
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
        }

        public string CheckCPPermission(String sUser)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " select * from t_User a, t_UserPermission b Where a.UserID=b.UserID "+
                          " and UserName='" + sUser + "' and PermissionKey='M41.2.12.1'";

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
                          " and UserName='" + sUser + "' and PermissionKey='M41.2.12.2'";

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

        private string ExcludeDecimal(string sAmount)
        {
            string sResult = "";
            sResult = sAmount.Remove(sAmount.Length - 3);
            return sResult;
        }
        public List<Data> GetData(String sUser)
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

            string sSQL = " SELECT ProductCode, ProductName, PGID, PGName, MAGID, MAGName, " +
                          " ASGID, ASGName, AGID, AGName, BrandID, BrandDesc as BrandName, CostPrice as CP, b.NSP, RSP, " +
                          " Sum(CurrentStock-BookingStock) AS 'HQStockQty', sum((CurrentStock-BookingStock) * CostPrice) as StockVal " +
                          " FROM BLLSysDB.dbo.t_productStock a, BLLSysDB.dbo.v_ProductDetails b " +
                          " WHERE (a.WarehouseID Not In (1)) AND (a.ProductID=b.ProductID) and NSP>0 " +
                          " GROUP BY ProductCode, ProductName, PGID, PGName, MAGID, MAGName,  " +
                          " ASGID, ASGName, AGID, AGName, BrandID, BrandDesc, CostPrice, b.NSP, RSP ";

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
                    //oData.InventoryCategory = reader["InventoryCategory"].ToString();
                    oData.PGID = reader["PGID"].ToString();
                    oData.MAGID = reader["MAGID"].ToString();
                    oData.ASGID = reader["ASGID"].ToString();
                    oData.AGID = reader["AGID"].ToString();
                    oData.MAGName = reader["MAGName"].ToString();
                    oData.BrandID = reader["BrandID"].ToString();
                    oData.BrandName = reader["BrandName"].ToString();
                    //oData.VAT = reader["VAT"].ToString();
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
                    oData.CRWStk = reader["HQStockQty"].ToString();
                    //oData.TDStk = reader["TDStk"].ToString();
                    oData.StockValue = ExcludeDecimal(oTELLib.TakaFormat(Convert.ToDouble(reader["StockVal"])));

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


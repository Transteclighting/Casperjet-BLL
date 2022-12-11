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

public partial class jSalesPromotion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            string sUser = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();
            string sType = c.Request.Form["Type"].Trim();


            //string sUser = "hakim";
            //string sCompany = "TEL";
            //string sType = "Header";

            string sPromotionID = "";
            if (c.Request.Form["PromotionID"] != null)
            {
                sPromotionID = c.Request.Form["PromotionID"].Trim();
            }
            else
            {
                sPromotionID = "0";
            }
            string sProductCode = "";
            if (c.Request.Form["ProductCode"] != null)
            {
                sProductCode = c.Request.Form["ProductCode"].Trim();
            }
            else
            {
                sProductCode = "0";
            }

            //Should be comment out
            //sProductCode = "810057";
            //sPromotionID = "681";

            string sDatabase = "x";
            if (sCompany == "TEL")
            {
                sDatabase = "TELSysDB";
            }
            else if (sCompany == "TML")
            {
                sDatabase = "TMLSysDB";
            }

            Data oData = new Data();
            DBController.Instance.OpenNewConnection();

            Datas oDatas = new Datas();
            if (sType == "Header")
            {
                string sOutput = JsonConvert.SerializeObject(oDatas.GetPromotionHeader(oData.GetProductID(sProductCode, sDatabase), sDatabase, sCompany), Formatting.Indented);
                Response.Write(sOutput.ToString());
                oData.InsertReportLog(sUser);
            }
            else if(sType == "ForProduct")
            {
                string sOutput = JsonConvert.SerializeObject(oDatas.GetPromotionForProduct(oData.GetProductID(sProductCode, sDatabase), sDatabase, sCompany, Convert.ToInt32(sPromotionID)), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if(sType == "ForChannel")
            {
                string sOutput = JsonConvert.SerializeObject(oDatas.GetPromotionForChannel(sDatabase, Convert.ToInt32(sPromotionID)), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if(sType == "DiscountAmount")
            {
                string sOutput = JsonConvert.SerializeObject(oDatas.GetPromotionDisAmt(sDatabase, Convert.ToInt32(sPromotionID)), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "FreeProduct")
            {
                string sOutput = JsonConvert.SerializeObject(oDatas.GetPromotionFreeProduct(sDatabase, sCompany, Convert.ToInt32(sPromotionID)), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            
            DBController.Instance.CloseConnection();
        }

    }
    public class Data
    {
        public string PromotionID;
        public string PromotionNo;
        public string PromotionName;
        public string FromDate;
        public string ToDate;

        public string ProductID;
        public string ProductCode;
        public string ProductName;
        public string Qty;
        public string DiscountAmount;

        public string Channel;
        
        public string Value;

        public int GetProductID(string sProductCode, string sDB)
        {
            int nProductID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = " select * from " + sDB + ".dbo.t_Product Where ProductCode='" + sProductCode + "'";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nProductID = Convert.ToInt32(reader["ProductID"]);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nProductID;

        }

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10010";
            string sReportName = "Sales Promotion";
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
       
        public List<Data> GetPromotionHeader(int nProductID, string sDB, string sCompany)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            //sSQL = " Select * from (select a.SalesPromotionID, SalesPromotionNo, SalesPromotionName, FromDate, ToDate from " + sDB + ".dbo.t_SalesPromo a, " +
            //       " " + sDB + ".dbo.t_SalesPromoProduct b " +
            //       " Where a.SalesPromotionID=b.SalesPromotionID  and IsActive=1 and DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) between FromDate and ToDate  and ProductID=" + nProductID + " " +
            //       " UNION ALL " +
            //       " select a.SalesPromotionID, SalesPromotionNo, SalesPromotionName, FromDate, ToDate from " + sDB + ".dbo.t_SalesPromo a,  " +
            //       " " + sDB + ".dbo.t_SalesPromoDiscount b " +
            //       " Where a.SalesPromotionID=b.SalesPromotionID  and IsActive=1 and DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) between FromDate and ToDate  and ProductGroupType = 5 " +
            //       " and ProductGroupID=" + nProductID + " " +
            //       " UNION ALL " +
            //       " select a.SalesPromotionID, SalesPromotionNo, SalesPromotionName, FromDate, ToDate from " + sDB + ".dbo.t_SalesPromo a,  " +
            //       " " + sDB + ".dbo.t_SalesPromoDiscount b, DWDB.dbo.t_ProductDetails c " +
            //       " Where a.SalesPromotionID=b.SalesPromotionID  and IsActive=1 and DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) between FromDate and ToDate  and ProductGroupType = 4 " +
            //       " and c.AGID=b.ProductGroupID and CompanyName='" + sCompany + "' and ProductID=" + nProductID + " " +
            //       " UNION ALL " +
            //       " select a.SalesPromotionID, SalesPromotionNo, SalesPromotionName, FromDate, ToDate from " + sDB + ".dbo.t_SalesPromo a,  " +
            //       " " + sDB + ".dbo.t_SalesPromoDiscount b, DWDB.dbo.t_ProductDetails c " +
            //       " Where a.SalesPromotionID=b.SalesPromotionID  and IsActive=1 and DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) between FromDate and ToDate  and ProductGroupType = 3 " +
            //       " and c.ASGID=b.ProductGroupID and CompanyName='" + sCompany + "' and ProductID=" + nProductID + " " +
            //       " UNION ALL " +
            //       " select a.SalesPromotionID, SalesPromotionNo, SalesPromotionName, FromDate, ToDate from " + sDB + ".dbo.t_SalesPromo a,  " +
            //       " " + sDB + ".dbo.t_SalesPromoDiscount b, DWDB.dbo.t_ProductDetails c " +
            //       " Where a.SalesPromotionID=b.SalesPromotionID  and IsActive=1 and DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) between FromDate and ToDate  and ProductGroupType = 2 " +
            //       " and c.MAGID=b.ProductGroupID and CompanyName='" + sCompany + "' and ProductID=" + nProductID + " " +
            //       " UNION ALL " +
            //       " select a.SalesPromotionID, SalesPromotionNo, SalesPromotionName, FromDate, ToDate from " + sDB + ".dbo.t_SalesPromo a,  " +
            //       " " + sDB + ".dbo.t_SalesPromoDiscount b, DWDB.dbo.t_ProductDetails c " +
            //       " Where a.SalesPromotionID=b.SalesPromotionID  and IsActive=1 and DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) between FromDate and ToDate  and ProductGroupType = 1 " +
            //       " and c.PGID=b.ProductGroupID and CompanyName='" + sCompany + "' and ProductID=" + nProductID + ") a Order by SalesPromotionID Desc";


            sSQL = " Select a.ConsumerPromoID as SalesPromotionID,ConsumerPromoNo as SalesPromotionNo, "+
                    " ConsumerPromoName as SalesPromotionName,FromDate,ToDate " +
                    " From t_PromoCP a,t_PromoCPProductFor b, t_Product c " +
                    " where a.ConsumerPromoID = b.ConsumerPromoID and b.ProductID = c.ProductID " +
                    " and Cast(GETDATE() as Date) between FromDate and ToDate " +
                    " and a.IsActive = 1 and Status = 1 and a.ConsumerPromoID in  " +
                    " ( " +
                    " Select ConsumerPromoID From t_PromoCPProductFor group by ConsumerPromoID " +
                    " having count(ProductID) = 1 " +
                    " ) and c.ProductID = '" + nProductID + "' order by a.ConsumerPromoID DESC ";


            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oData = new Data();
                    _oData.Value = "Success";
                    _oData.PromotionID = reader["SalesPromotionID"].ToString();
                    _oData.PromotionNo = reader["SalesPromotionNo"].ToString();
                    _oData.PromotionName = reader["SalesPromotionName"].ToString();
                    _oData.FromDate = Convert.ToDateTime(reader["FromDate"]).ToString("dd-MMM-yyyy");
                    _oData.ToDate = Convert.ToDateTime(reader["ToDate"]).ToString("dd-MMM-yyyy");

                    eList.Add(_oData);
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
        public List<Data> GetPromotionForProduct(int nProductID, string sDB, string sCompany, int nPromotionID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            //sSQL = " Select a.ProductID,ProductCode,ProductName,Qty From " + sDB + ".dbo.t_SalesPromoSlabRatio a, " +
            //       " DWDB.dbo.t_ProductDetails b where CompanyName='" + sCompany + "' and CPSID in  " +
            //       " (Select CPSID From " + sDB + ".dbo.t_SalesPromoSlab where SalesPromotionID in  " +
            //       " (Select SalesPromotionID from " + sDB + ".dbo.t_SalesPromoProduct where SalesPromotionID in  " +
            //       " (select b.SalesPromotionID from " + sDB + ".dbo.t_SalesPromoProduct a, " + sDB + ".dbo.t_SalesPromo b where IsActive=1  " +
            //       " and a.SalesPRomotionID=b.SalesPRomotionID and DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) between FromDate and ToDate  and ProductID=" + nProductID + " ) and SalesPromotionID = " + nPromotionID + ") " +
            //       " ) " +
            //       " and a.ProductID=b.ProductID " +
            //       " UNION ALL " +
            //       " select c.ProductID,ProductCode,ProductName,1 as Qty from " + sDB + ".dbo.t_SalesPromo a,  " +
            //       " " + sDB + ".dbo.t_SalesPromoDiscount b, DWDB.dbo.t_ProductDetails c " +
            //       " Where a.SalesPromotionID=b.SalesPromotionID  and IsActive=1 and DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) between FromDate and ToDate  and ProductGroupType = 5 " +
            //       " and b.ProductGroupID=c.ProductID and CompanyName='" + sCompany + "' and ProductGroupID=" + nProductID + " and a.SalesPromotionID = " + nPromotionID + " " +
            //       " UNION ALL " +
            //       " select c.ProductID,ProductCode,ProductName,1 as Qty from " + sDB + ".dbo.t_SalesPromo a,  " +
            //       " " + sDB + ".dbo.t_SalesPromoDiscount b, DWDB.dbo.t_ProductDetails c " +
            //       " Where a.SalesPromotionID=b.SalesPromotionID  and IsActive=1 and DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) between FromDate and ToDate  and ProductGroupType = 4 " +
            //       " and b.ProductGroupID=c.AGID and CompanyName='" + sCompany + "' and ProductGroupID=" + nProductID + " and a.SalesPromotionID = " + nPromotionID + " " +
            //       " UNION ALL " +
            //       " select c.ProductID,ProductCode,ProductName,1 as Qty from " + sDB + ".dbo.t_SalesPromo a,  " +
            //       " " + sDB + ".dbo.t_SalesPromoDiscount b, DWDB.dbo.t_ProductDetails c " +
            //       " Where a.SalesPromotionID=b.SalesPromotionID  and IsActive=1 and DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) between FromDate and ToDate  and ProductGroupType = 3 " +
            //       " and b.ProductGroupID=c.ASGID and CompanyName='" + sCompany + "' and ProductGroupID=" + nProductID + " and a.SalesPromotionID = " + nPromotionID + " " +
            //       " UNION ALL " +
            //       " select c.ProductID,ProductCode,ProductName,1 as Qty from " + sDB + ".dbo.t_SalesPromo a,  " +
            //       " " + sDB + ".dbo.t_SalesPromoDiscount b, DWDB.dbo.t_ProductDetails c " +
            //       " Where a.SalesPromotionID=b.SalesPromotionID  and IsActive=1 and DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) between FromDate and ToDate  and ProductGroupType = 2 " +
            //       " and b.ProductGroupID=c.MAGID and CompanyName='" + sCompany + "' and ProductGroupID=" + nProductID + " and a.SalesPromotionID = " + nPromotionID + " " +
            //       " UNION ALL " +
            //       " select c.ProductID,ProductCode,ProductName,1 as Qty from " + sDB + ".dbo.t_SalesPromo a,  " +
            //       " " + sDB + ".dbo.t_SalesPromoDiscount b, DWDB.dbo.t_ProductDetails c " +
            //       " Where a.SalesPromotionID=b.SalesPromotionID  and IsActive=1 and DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) between FromDate and ToDate  and ProductGroupType = 1 " +
            //       " and b.ProductGroupID=c.PGID and CompanyName='" + sCompany + "' and ProductGroupID=" + nProductID + " and a.SalesPromotionID = " + nPromotionID + "";

            sSQL = " Select a.ProductID, ProductCode, ProductName, 0 as Qty From t_PromoCPProductFor a,t_Product b " +
                   " where a.ProductID = b.ProductID and ConsumerPromoID = " + nPromotionID + " ";

            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oData = new Data();

                    _oData.Value = "Success";
                    _oData.ProductID = reader["ProductID"].ToString();
                    _oData.ProductCode = reader["ProductCode"].ToString();
                    _oData.ProductName = reader["ProductName"].ToString();
                    _oData.Qty = reader["Qty"].ToString();

                    eList.Add(_oData);
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
        public List<Data> GetPromotionForChannel(string sDB, int nPromotionID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            //sSQL = " Select (ChannelDescription +' ['+ ChannelCode + ']') as Channel from " + sDB + ".dbo.t_SalesPromoChannel a, " + sDB + ".dbo.t_Channel b  " +
            //       " where a.ChannelID=b.ChannelID and SalesPromotionID=" + nPromotionID + " ";

            sSQL = " Select CASE When SalesType = 1 then 'Retail' When SalesType = 2 then 'B2C' When SalesType = 3 then 'B2B' " +
                   " When SalesType = 4 then 'HPA' When SalesType = 5 then 'Dealer' When SalesType = 6 then 'eStore' else 'Others' end as Channel " +
                   " from t_PromoCPSalesType where ConsumerPromoID = " + nPromotionID + " ";

            Data _oData;  
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            string sChannelName = "";
            string _sChannelName = "";
            int nCount = 0;
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (sChannelName == "")
                    {
                        sChannelName = reader["Channel"].ToString();
                        _sChannelName = reader["Channel"].ToString();
                    }
                    else
                    {
                        _sChannelName = _sChannelName + ", " + reader["Channel"].ToString();
                    }
                    nCount++;
                }
                if (nCount > 0)
                {
                    _oData = new Data();
                    _oData.Value = "Success";
                    _oData.Channel = _sChannelName;
                    eList.Add(_oData);
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
        public List<Data> GetPromotionDisAmt(string sDB, int nPromotionID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            //sSQL = " Select CASE When DiscountType = 2 Then 'FlatAmount' " +
            //        " When DiscountType = 1 Then 'Percentage' else 'None' end as DisType, DiscountPercentage as Discount  " +
            //        " from  " +
            //        " (select Distinct DiscountType, DiscountPercentage from " + sDB + ".dbo.t_SalesPromoDiscount   " +
            //        " Where SalesPromotionID=" + nPromotionID + " and DiscountType IN (1,2)) a  " +
            //        " UNION ALL  " +
            //        " select CASE When DiscountType = 1 Then 'FlatAmount' " +
            //        " When DiscountType = 2 Then 'Percentage' else 'None' end as DisType,   " +
            //        " Discount from " + sDB + ".dbo.t_SalesPromoSlab Where SalesPromotionID=" + nPromotionID + " and DiscountType IN (1,2) ";

            sSQL = "  Select '[' + SlabName + '-Qty:' + cast(Qty as varchar) + ']-' + " +
            " '[' + OfferName + '-' + d.Description + ']' as OfferDetail " +
            " From t_PromoCPSlab a,t_PromoCPSlabRatio b, t_Product c,t_PromoCPOffer d " +
            " where a.ConsumerPromoID = b.ConsumerPromoID and a.SlabID = b.SlabID and " +
            " a.SlabID = d.SlabID and a.ConsumerPromoID = d.ConsumerPromoID and " +
            " b.ProductID = c.ProductID and a.ConsumerPromoID = " + nPromotionID + " and a.IsActive = 1 ";


            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oData = new Data();

                    _oData.Value = "Success";

                    //string sDisType = "";
                    //sDisType = reader["DisType"].ToString();
                    //if (sDisType == "Percentage")
                    //{
                    //    _oData.DiscountAmount = reader["Discount"].ToString() + "%";
                    //}
                    //else
                    //{
                    //    _oData.DiscountAmount = ExcludeDecimal(_oTELLib.TakaFormat(Convert.ToDouble(reader["Discount"]))) + " Taka";
                    //}
                    _oData.DiscountAmount = reader["OfferDetail"].ToString() + "\n";
                    
                    eList.Add(_oData);
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
        public List<Data> GetPromotionFreeProduct(string sDB, string sCompany, int nPromotionID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            //sSQL = " Select ProductCode, ProductName, Qty From " + sDB + ".dbo.t_SalesPromofreeProduct a, " + sDB + ".dbo.t_SalesPromoSlab b, DWDB.dbo.t_ProductDetails c  " +
            //       " Where a.ProductID=c.ProductID and CompanyName='" + sCompany + "' and a.CPSID=b.CPSID and SalesPromotionID = " + nPromotionID + "";


            //No need this query for new promotions
            sSQL = " Select ProductCode, ProductName, Qty From " + sDB + ".dbo.t_SalesPromofreeProduct a, " + sDB + ".dbo.t_SalesPromoSlab b, DWDB.dbo.t_ProductDetails c  " +
       " Where a.ProductID=c.ProductID and CompanyName='x' and a.CPSID=b.CPSID and SalesPromotionID = " + nPromotionID + "";
            Data _oData;
            TELLib _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _oData = new Data();

                    _oData.Value = "Success";

                    _oData.ProductCode = reader["ProductCode"].ToString();
                    _oData.ProductName = reader["ProductName"].ToString();
                    _oData.Qty = reader["Qty"].ToString();

                    eList.Add(_oData);
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

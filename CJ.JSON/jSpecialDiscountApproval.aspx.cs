using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Newtonsoft.Json;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;
using CJ.Class.ANDROID;

public partial class jSpecialDiscountApproval : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            string sUser = c.Request.Form["UserName"].Trim();
            string sCompany = c.Request.Form["Company"].Trim();
            string sType = c.Request.Form["Type"].Trim();


            //string sUser = "wahid";
            //string sCompany = "TEL";
            //string sType = "ApproveOrReject";

            //string sAction = "";
            //string sRemarks = "TEST";
            //int nSpecialDiscountID = 1;
            //int nWarehouseID = 45;
            //string sRemarks = "Approved";

            int nSpecialDiscountID = 0;
            if (c.Request.Form["SpecialDiscountID"] != null)
            {
                nSpecialDiscountID = Convert.ToInt32(c.Request.Form["SpecialDiscountID"]);
            }
            int nWarehouseID = 0;
            if (c.Request.Form["WarehouseID"] != null)
            {
                nWarehouseID = Convert.ToInt32(c.Request.Form["WarehouseID"]);
            }
            string sRemarks = "";
            if (c.Request.Form["Remarks"] != null)
            {
                sRemarks = c.Request.Form["Remarks"].Trim();
            }
            double _RequestAmount = 0;
            if (c.Request.Form["RequestAmount"] != null)
            {
                _RequestAmount = Convert.ToDouble(c.Request.Form["RequestAmount"].Trim());
            }
            int nAuthorityID = 0;
            if (c.Request.Form["AuthorityID"] != null)
            {
                nAuthorityID = Convert.ToInt32(c.Request.Form["AuthorityID"]);
            }
            double _PromoDiscountAmount = 0;
            if (c.Request.Form["PromoDiscountAmount"] != null)
            {
                _PromoDiscountAmount = Convert.ToDouble(c.Request.Form["PromoDiscountAmount"]);
            }
            double _RSP = 0;
            if (c.Request.Form["RSP"] != null)
            {
                _RSP = Convert.ToDouble(c.Request.Form["RSP"]);
            }

            string sDatabase = "x";
            if (sCompany == "TEL")
            {
                sDatabase = "TELSysDB";
            }
            else if (sCompany == "TML")
            {
                sDatabase = "TMLSysDB";
            }
            Datas _oDatas = new Datas();
            string sOutput = "";
            Data oData;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            Data _oData = new Data();
            if (sCompany == "TEL")
            {
                if (sType == "Summary")
                {

                }
            }
            if (sType == "Pending")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetData(sDatabase, sUser, "Pending"), Formatting.Indented);
                Response.Write(sOutput.ToString());
                _oData.InsertReportLog(sUser);
            }
            else if (sType == "ApproveOrReject")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetDataApproveOrReject(sDatabase, sUser), Formatting.Indented);
                Response.Write(sOutput.ToString());
                _oData.InsertReportLog(sUser);
            }
            else if (sType == "SummaryApprove") 
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetData(sDatabase, sUser, "SummaryApprove"), Formatting.Indented);
                Response.Write(sOutput.ToString());
                _oData.InsertReportLog(sUser);
            }
            else if (sType == "SummaryEmployee")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetSummaryData(sDatabase, sUser), Formatting.Indented);
                Response.Write(sOutput.ToString());
                _oData.InsertReportLog(sUser);
            }

            else if (sType == "Reject")
            {
                oData = new Data();
                sOutput = JsonConvert.SerializeObject(oData.ExecuiteReject(sDatabase, sUser, nSpecialDiscountID, nWarehouseID, sRemarks, _PromoDiscountAmount, _RSP), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "Approve")
            {
                oData = new Data();
                sOutput = JsonConvert.SerializeObject(oData.ExecuiteApprove(sDatabase, sUser, nSpecialDiscountID, nWarehouseID, sRemarks, _RequestAmount, nAuthorityID, _PromoDiscountAmount, _RSP), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            DBController.Instance.CloseConnection();
        }
    }
    public class Result 
    {
        public string ResultValue;
    }
    public class Data 
    {

        public string Value;

        public string SpecialDiscountID;
        public string ApprovalNumber;
        public string SalesType;
        public string CustomerCode;
        public string CustomerName;
        public string Amount;
        public string WarehouseID;
        public string OutletCode;
        public string OutletName;
        public string AuthorityEmployeeID;
        public string AuthorityName;
        public string ApprovedEmployee;
        public string ApproveDate;
        public string ApproveRemarks;
        public string Status;
        public string StatusName;
        public string InvoiceAmount;
        public string PromoDiscount;
        public string ProductCode;
        public string ProductName;
        public string RSP;
        public string CreateDate;
        public string Reason;
        public string EMITenure;
        public string DiscountType;

        public string AuthorityID;
        public string JanLimit;
        public string JanDiscount;
        public string FebLimit;
        public string FebDiscount;
        public string MarLimit;
        public string MarDiscount;
        public string AprLimit;
        public string AprDiscount;
        public string MayLimit;
        public string MayDiscount;
        public string JunLimit;
        public string JunDiscount;
        public string JulLimit;
        public string JulDiscount;
        public string AugLimit;
        public string AugDiscount;
        public string SepLimit;
        public string SepDiscount;
        public string OctLimit;
        public string OctDiscount;
        public string NovLimit;
        public string NovDiscount;
        public string DecLimit;
        public string DecDiscount;
        public string EmployeeID;
        public string EmployeeName;
        public string CurrentLimit;
        public string CurrentDiscount;



        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10048";
            string sReportName = "TEL-Special Discount Approval [118]";
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
        }
        #region Reject
        //public List<Data> ExecuiteReject(string sDB, int nISGMID, string sUserName, string sRemarks)
        //{
        //    List<Data> sResult = new List<Data>();
        //    int nCount = 0;
        //    Data _oData = new Data();
        //    DBController.Instance.OpenNewConnection();
        //    GetISGM(sDB, nISGMID);
        //    int nUserID = GetUserID(sDB, sUserName);
        //    DBController.Instance.CloseConnection();
        //    string connStr;
        //    connStr = ConfigurationManager.AppSettings["jConnectionString"];

        //    DataTran oDataTran = new DataTran();


        //    string sTableName = "t_StockRequisition";

        //    //---------
        //    using (SqlConnection connection = new SqlConnection(connStr))
        //    {
        //        connection.Open();

        //        SqlCommand command = connection.CreateCommand();
        //        SqlTransaction transaction;

        //        transaction = connection.BeginTransaction("SampleTransaction");

        //        command.Connection = connection;
        //        command.Transaction = transaction;

        //        try
        //        {
        //            int nStatus = (int)Dictionary.StockRequisitionStatus.Reject_By_HO;
        //            int nProductStatus = (int)Dictionary.ProductSerialStatus.Received_at_Outlet;
        //            command.CommandText = "Update " + sDB + ".dbo.t_StockRequisition Set Status = " + nStatus + " Where StockRequisitionID=" + nISGMID + " ";
        //            nCount = command.ExecuteNonQuery();
        //            if (nCount > 0)
        //            {
        //                command.CommandText = "Update " + sDB + ".dbo.t_StockRequisition Set AuthorizedBy = " + nUserID + ", AuthorizeDate = '" + DateTime.Now + "', AuthorizeRemarks='" + sRemarks + "' Where StockRequisitionID=" + nISGMID + " ";
        //                command.ExecuteNonQuery();
        //                command.CommandText = "INSERT INTO " + sDB + ".dbo.t_DataTransfer VALUES ('" + sTableName + "', " + nISGMID + ", " + nFromWHID + ",2,1,0,'" + DateTime.Now + "', null) ";
        //                command.ExecuteNonQuery();


        //                Datas oDatas = new Datas();
        //                DBController.Instance.OpenNewConnection();
        //                oDatas.GetProductSerial(nStockTranID, sDB);
        //                foreach (Data oData in oDatas)
        //                {
        //                    int nProductSerialID = GetProductSerialID(sDB, oData.ProductSerialNo);
        //                    int nProductSerialHistoryID = GetProductSerialHitoryID(sDB, nProductSerialID);

        //                    command.CommandText = "Update " + sDB + ".dbo.t_ProductStockSerial SET Status=" + nProductStatus + " Where ProductSerialNo='" + oData.ProductSerialNo + "'";
        //                    command.ExecuteNonQuery();

        //                    command.CommandText = "DELETE FROM " + sDB + ".dbo.t_ProductStockSerialHistory WHERE ProductStockSerialHistoryID=" + nProductSerialHistoryID + "";
        //                    command.ExecuteNonQuery();
        //                }
        //                DBController.Instance.CloseConnection();

        //                command.CommandText = "Delete from " + sDB + ".dbo.t_ProductTransferProductSerial Where TranID IN ( " +
        //                              "Select TranID from " + sDB + ".dbo.t_ProductStockTran Where TranID=" + nStockTranID + ") ";
        //                command.ExecuteNonQuery();

        //                command.CommandText = "Delete from " + sDB + ".dbo.t_ProductStockTranItem Where TranID IN ( " +
        //                                    "Select TranID from " + sDB + ".dbo.t_ProductStockTran Where TranID=" + nStockTranID + ") ";
        //                command.ExecuteNonQuery();

        //                command.CommandText = "Delete from " + sDB + ".dbo.t_ProductStockTran Where TranID=" + nStockTranID + "";
        //                command.ExecuteNonQuery();

        //                command.CommandText = "Update " + sDB + ".dbo.t_StockRequisition Set StockTranID = null Where StockRequisitionID=" + nISGMID + " ";
        //                command.ExecuteNonQuery();
        //                // Attempt to commit the transaction.
        //                transaction.Commit();
        //                _oData.Value = "Success";
        //                sResult.Add(_oData);

        //            }
        //            else
        //            {
        //                _oData.Value = "Invalid";
        //                sResult.Add(_oData);
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            transaction.Rollback();
        //            _oData.Value = "Error" + ex.Message;
        //            sResult.Add(_oData);
        //        }
        //    }

        //    return sResult;
        //}
        #endregion
        public List<Data> ExecuiteApprove(string sDB, string sUserName, int nSpecialDiscountID, int nWarehouseID, string sRemarks, double _RequestAmount, int nAuthorityID, double _PromoDiscountAmount, double _RSP)
        {
            List<Data> sResult = new List<Data>();
            int nCount = 0;
            Data _oData = new Data();

            int nYear = DateTime.Now.Year;
            int nMonth = DateTime.Now.Month;
            //Check Limit

            if (!CheckLimit(sDB, nAuthorityID, _RequestAmount))
            {
                _oData.Value = "Insufficient Limit";
                sResult.Add(_oData);
                return sResult;
            }

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            int nUserID = GetUserID(sDB, sUserName);
            //DBController.Instance.CloseConnection();
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];

            DataTran oDataTran = new DataTran();

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                transaction = connection.BeginTransaction("SampleTransaction");

                command.Connection = connection;
                command.Transaction = transaction;

                try
                {

                    Data oData = new Data();
                    //DBController.Instance.OpenNewConnection();
                    DateTime _Date = DateTime.Now;


                    command.CommandText = "INSERT INTO " + sDB + ".dbo.t_DataTransfer (TableName,DataID, WarehouseID,TransferType,IsDownload,BatchNo,CreateDate) VALUES('t_PromoDiscountSpecial'," + nSpecialDiscountID + "," + nWarehouseID + ",2,1,0,'" + _Date + "')";
                    command.ExecuteNonQuery(); 

                    command.CommandText = "UPDATE " + sDB + ".dbo.t_PromoDiscountSpecial SET IsApplicableB2BDiscount = "+(int)Dictionary.YesOrNoStatus.NO+", Status = "+ (int)Dictionary.SpacialDiscountStatus.Approved + ", ApproveUserID = "+ nUserID + ", ApproveDate = '" + _Date + "' , ApproveRemarks = '"+ sRemarks + "', PromoDiscountAmount = '" + _PromoDiscountAmount + "', RSP = '" + _RSP + "' WHERE SpecialDiscountID = " + nSpecialDiscountID + " and WarehouseID= "+nWarehouseID+"";
                    command.ExecuteNonQuery();

                    command.CommandText = "Update " + sDB + ".dbo.t_PromoDiscountSpecialAuthorityLimit SET Discount = Discount + " + _RequestAmount + " Where TMonth = " + nMonth + " and TYear = " + nYear + " and AuthorityID = " + nAuthorityID + "";
                    command.ExecuteNonQuery();
                    

                    // Attempt to commit the transaction.
                    transaction.Commit();
                    _oData.Value = "Success";
                    sResult.Add(_oData);



                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _oData.Value = "Error" + ex.Message;
                    sResult.Add(_oData);
                }
            }

            return sResult;
        }

        public List<Data> ExecuiteReject(string sDB, string sUserName, int nSpecialDiscountID, int nWarehouseID, string sRemarks, double _PromoDiscountAmount, double _RSP)
        {
            List<Data> sResult = new List<Data>();
            int nCount = 0;
            Data _oData = new Data();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            int nUserID = GetUserID(sDB, sUserName);
            //DBController.Instance.CloseConnection();
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];

            DataTran oDataTran = new DataTran();

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                transaction = connection.BeginTransaction("SampleTransaction");

                command.Connection = connection;
                command.Transaction = transaction;

                try
                {

                    Data oData = new Data();
                    //DBController.Instance.OpenNewConnection();
                    DateTime _Date = DateTime.Now;

                    command.CommandText = "INSERT INTO " + sDB + ".dbo.t_DataTransfer (TableName,DataID, WarehouseID,TransferType,IsDownload,BatchNo,CreateDate) VALUES('t_PromoDiscountSpecial'," + nSpecialDiscountID + "," + nWarehouseID + ",2,1,0,'" + _Date + "')";
                    command.ExecuteNonQuery();

                    command.CommandText = "UPDATE " + sDB + ".dbo.t_PromoDiscountSpecial SET IsApplicableB2BDiscount = " + (int)Dictionary.YesOrNoStatus.NO + ", Status = " + (int)Dictionary.SpacialDiscountStatus.Rejected + ", ApproveUserID = " + nUserID + ", ApproveDate = '" + _Date + "' , ApproveRemarks = '" + sRemarks + "', PromoDiscountAmount = '" + _PromoDiscountAmount + "', RSP = '" + _RSP + "' WHERE SpecialDiscountID = " + nSpecialDiscountID + " and WarehouseID= " + nWarehouseID + "";
                    command.ExecuteNonQuery();



                    //DBController.Instance.CloseConnection();

                    // Attempt to commit the transaction.
                    transaction.Commit();
                    _oData.Value = "Success";
                    sResult.Add(_oData);



                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _oData.Value = "Error" + ex.Message;
                    sResult.Add(_oData);
                }
            }

            return sResult;
        }

        public int GetUserID(string sDB, string sUserName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nResult = 0;
            string sSQL = "";
            sSQL = "select UserID from " + sDB + ".dbo.t_User Where UserName='" + sUserName + "'";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nResult = Convert.ToInt32(reader["UserID"]);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nResult;
        }

        public bool CheckLimit(string sDB, int nAuthorityID, double _RequestAmount)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            double _Result = 0;
            string sSQL = "";

            int nYear = DateTime.Now.Year;
            int nMonth = DateTime.Now.Month;

            sSQL = "Select (Limit - Discount) as AvailableLimit from " + sDB + ".dbo.t_PromoDiscountSpecialAuthorityLimit Where TMonth = "+ nMonth + " and TYear = "+ nYear + " and AuthorityID = "+ nAuthorityID + " ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _Result = Convert.ToDouble(reader["AvailableLimit"]);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            if (_RequestAmount <= _Result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double GetPromoAmount(string sProductCode, string sDatabase)
        {
            double _Amount = 0;

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "Select max(DisAmount) DisAmount " +
                        " From " +
                        " ( " +
                        " Select A.ConsumerPromoID, A.SlabID, ProductCode, c.ProductID, " +
                        " case when OfferType = 2 then RSP * Discount / 100 else Discount end DisAmount " +
                        " From  " + sDatabase + ".dbo.t_PromoCPOfferDetail a, " +
                        " ( " +
                        " Select a.ConsumerPromoID, SlabID, a.ProductID " +
                        " From  " + sDatabase + ".dbo.t_PromoCPProductFor a,  " + sDatabase + ".dbo.t_PromoCPSlabRatio b " +
                        " where a.ConsumerPromoID = b.ConsumerPromoID and a.ProductID = b.ProductID and Qty = 1 " +
                        " and a.ConsumerPromoID in  " +
                        //--Single Product--
                        " ( " +
                        " Select ConsumerPromoID " +
                        " From  " + sDatabase + ".dbo.t_PromoCPProductFor group by ConsumerPromoID " +
                        " having count(ProductID) = 1) " +
                        //--Single Slab--
                        " and a.ConsumerPromoID in (Select ConsumerPromoID From  " + sDatabase + ".dbo.t_PromoCPSlab " +
                        " group by ConsumerPromoID having count(SlabID) = 1) " +
                        " ) B, " + sDatabase + ".dbo.v_ProductDetails c,  " + sDatabase + ".dbo.t_PromoCP d where OfferType in (1, 2)  " +
                        " AND a.ConsumerPromoID = b.ConsumerPromoID and a.SlabID = b.SlabID " +
                        " and b.ProductID = c.ProductID and a.ConsumerPromoID = d.ConsumerPromoID " +
                        " and DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) between FromDate and ToDate " +
                        " and d.IsActive = 1 " +
                        " ) xx " +
                        " where ProductCode = '"+sProductCode+"' ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["DisAmount"] != DBNull.Value)
                    {
                        _Amount = Convert.ToDouble(reader["DisAmount"]);
                    }
                    else
                    {
                        _Amount = 0;
                    }
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return _Amount;
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
        
        public void GetProductSerial(int nStockTranID, string sDB)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = " select * from " + sDB + ".dbo.t_ProductTransferProductSerial where TranID=" + nStockTranID + " ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Data oData = new Data();
                    //oData.ProductSerialNo = reader["ProductSerialNo"].ToString();

                    InnerList.Add(oData);
                }

                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetISGMItem(int nISGMID, string sDB)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = " select * from " + sDB + ".dbo.t_StockRequisitionItem where StockRequisitionID=" + nISGMID + " ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Data oData = new Data();
                    //oData.ISGMQty = Convert.ToInt32(reader["RequisitionQty"]);
                    //oData.ProductID = reader["ProductID"].ToString();

                    InnerList.Add(oData);
                }

                reader.Close();
                InnerList.TrimToSize();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Data> GetData(string sDatabase, string sUserName, string sListType)
        {

            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select AuthorityID, CreateDate, SpecialDiscountID, ApprovalNumber, SalesType, CASE When Type = 1 then CustomerCode else ConsumerCode end as CustomerCode, " +
                          " CASE When Type = 1 then CustomerName else ConsumerName end as CustomerName,  Amount,  " +
                          " WarehouseID, OutletCode, OutletName,AuthorityEmployeeID, AuthorityName, ApprovedEmployee, ApproveDate, ApproveRemarks, Status, isnull(ProductCode,'') as ProductCode, Isnull(ProductName,'') as ProductName, IsNull(SalesPrice,0) as SalesPrice, Reason, EMITenure, DiscountType From " +
                          " ( " +
                          " Select A.*, B.ConsumerCode, B.ConsumerName, isnull(e.EmployeeName, '') as ApprovedEmployee, p.ProductCode, p.ProductName, SalesPrice, Isnull(Tenure,'') as EMITenure from " +
                          " ( " +
                          " Select a.*, CustomerCode, CustomerName, " +
                          " ShowroomCode as OutletCode, ShowroomName as OutletName, EmployeeID as AuthorityEmployeeID, EmployeeName as AuthorityName " +
                          " from " + sDatabase + ".dbo.t_PromoDiscountSpecial a, " + sDatabase + ".dbo.t_Customer b, " + sDatabase + ".dbo.t_Showroom c, " + sDatabase + ".dbo.t_PromoDiscountSpecialAuthority d " +
                          " where a.CustomerID = b.CustomerID and a.WarehouseID = c.WarehouseID and a.AuthorityID = d.AuthorityID and d.EmployeeID = (Select EmployeeID from " + sDatabase + ".dbo.t_user where username = '" + sUserName + "') ";
            if (sListType == "Pending")
            {
                sSql += " and Status = " + (int)Dictionary.SpacialDiscountStatus.Create + " ";
            }
            else if(sListType == "SummaryApprove")
            {
                sSql += " and Status != " + (int)Dictionary.SpacialDiscountStatus.Create + " ";
            }
            
            sSql+=" ) as A " +
                          " Left Outer Join " +
                          " ( " +
                          " Select * from " + sDatabase + ".dbo.t_RetailConsumer " +
                          " ) as B " +
                          " on A.ConsumerID = B.ConsumerID and a.WarehouseID = b.WarehouseID " +
                          " left outer join " +
                          " " + sDatabase + ".dbo.t_employee e on a.ApproveUserID = e.EmployeeID " +
                          " left outer join "+
                          " (Select ProductID, ProductCode, ProductName, RSP as SalesPrice from " + sDatabase + ".dbo.v_ProductDetails ) p on p.ProductID = a.ProductID  " +
                          " left outer join " + sDatabase + ".dbo.t_EMITenure emi on emi.EMITenureID =  a.EMITenureID " +
                          " ) Main Order by CreateDate DESC, WarehouseID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Data oData = new Data();

                    oData.Value = "Success";

                    oData.AuthorityID = Convert.ToUInt32(reader["AuthorityID"]).ToString();
                    oData.CreateDate = Convert.ToDateTime(reader["CreateDate"]).ToString("dd-MMM-yyyy");
                    oData.SpecialDiscountID = Convert.ToUInt32(reader["SpecialDiscountID"]).ToString();
                    oData.ApprovalNumber = (string)reader["ApprovalNumber"];
                    oData.SalesType = Enum.GetName(typeof(Dictionary.SalesType), (int)reader["SalesType"]);
                    if (reader["CustomerCode"] != DBNull.Value)
                    {
                        oData.CustomerCode = (string)reader["CustomerCode"];
                    }
                    else
                    {
                        oData.CustomerCode = "";
                    }
                    if (reader["CustomerName"] != DBNull.Value)
                    {
                        oData.CustomerName = (string)reader["CustomerName"];
                    }
                    else
                    {
                        oData.CustomerName = "";
                    }
                    oData.Amount = Convert.ToDouble(reader["Amount"]).ToString();
                    oData.WarehouseID = Convert.ToUInt32(reader["WarehouseID"]).ToString();
                    oData.OutletCode = (string)reader["OutletCode"];
                    oData.OutletName = (string)reader["OutletName"];
                    oData.AuthorityEmployeeID = Convert.ToUInt32(reader["AuthorityEmployeeID"]).ToString();
                    oData.AuthorityName = (string)reader["AuthorityName"];
                    oData.ApprovedEmployee = (string)reader["ApprovedEmployee"];
                    if (reader["ApproveDate"] != DBNull.Value)
                    {
                        oData.ApproveDate = Convert.ToDateTime(reader["ApproveDate"]).ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        oData.ApproveDate = "";
                    }
                    if (reader["DiscountType"] != DBNull.Value)
                    {
                        oData.DiscountType = (string)reader["DiscountType"];
                    }
                    else
                    {
                        oData.DiscountType = "";
                    }
                    if (reader["EMITenure"] != DBNull.Value)
                    {
                        oData.EMITenure = Convert.ToInt32(reader["EMITenure"]).ToString();
                    }
                    else
                    {
                        oData.EMITenure = "";
                    }

                    oData.ApproveRemarks = (string)reader["ApproveRemarks"];
                    oData.Status = Convert.ToUInt32(reader["Status"]).ToString();
                    oData.StatusName = Enum.GetName(typeof(Dictionary.SpacialDiscountStatus), Convert.ToUInt32(reader["Status"]));
                    //oData.InvoiceAmount = Convert.ToDouble(reader["InvoiceAmount"]).ToString();
                    if (reader["Reason"] != DBNull.Value)
                    {
                        oData.Reason = (string)reader["Reason"];
                    }
                    else
                    {
                        oData.Reason = "";
                    }
                    oData.ProductCode = (string)reader["ProductCode"];
                    oData.ProductName = (string)reader["ProductName"];
                    oData.RSP = reader["SalesPrice"].ToString();
                    oData.PromoDiscount = Convert.ToString(oData.GetPromoAmount(oData.ProductCode, sDatabase));

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

        public List<Data> GetDataApproveOrReject(string sDatabase, string sUserName)
        {
            DateTime _date = DateTime.Now;
            _date = _date.AddDays(-7);
            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select AuthorityID, CreateDate, SpecialDiscountID, ApprovalNumber, SalesType, CASE When Type = 1 then CustomerCode else ConsumerCode end as CustomerCode, " +
                          " CASE When Type = 1 then CustomerName else ConsumerName end as CustomerName,  Amount,  " +
                          " WarehouseID, OutletCode, OutletName,AuthorityEmployeeID, AuthorityName, ApprovedEmployee, ApproveDate, ApproveRemarks, Status, IsNull(PromoDiscountAmount,0) as PromoDiscountAmount, isnull(ProductCode,'') as ProductCode, Isnull(ProductName,'') as ProductName, Isnull(RSP,'') as RSP, Reason, EMITenure, DiscountType  From " +
                          " ( " +
                          " Select A.*, B.ConsumerCode, B.ConsumerName, isnull(e.EmployeeName, '') as ApprovedEmployee, p.ProductCode, p.ProductName, Isnull(Tenure,'') as EMITenure from " +
                          " ( " +
                          " Select a.*, CustomerCode, CustomerName, " +
                          " ShowroomCode as OutletCode, ShowroomName as OutletName, EmployeeID as AuthorityEmployeeID, EmployeeName as AuthorityName " +
                          " from " + sDatabase + ".dbo.t_PromoDiscountSpecial a, " + sDatabase + ".dbo.t_Customer b, " + sDatabase + ".dbo.t_Showroom c, " + sDatabase + ".dbo.t_PromoDiscountSpecialAuthority d " +
                          " where a.CreateDate > '"+ _date + "' and a.CustomerID = b.CustomerID and a.WarehouseID = c.WarehouseID and a.AuthorityID = d.AuthorityID and d.EmployeeID = (Select EmployeeID from " + sDatabase + ".dbo.t_user where username = '" + sUserName + "') "+
                          " and Status != " + (int)Dictionary.SpacialDiscountStatus.Create + " ) as A " +
                          " Left Outer Join " +
                          " ( " +
                          " Select * from " + sDatabase + ".dbo.t_RetailConsumer " +
                          " ) as B " +
                          " on A.ConsumerID = B.ConsumerID and a.WarehouseID = b.WarehouseID " +
                          " left outer join " +
                          " " + sDatabase + ".dbo.t_employee e on a.ApproveUserID = e.EmployeeID " +
                          " left outer join " +
                          " " + sDatabase + ".dbo.v_Product p on p.ProductID = a.ProductID  " +
                          " left outer join " + sDatabase + ".dbo.t_EMITenure emi on emi.EMITenureID =  a.EMITenureID " +
                          " ) Main Order by CreateDate DESC, WarehouseID ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Data oData = new Data();

                    oData.Value = "Success";

                    oData.AuthorityID = Convert.ToUInt32(reader["AuthorityID"]).ToString();
                    oData.CreateDate = Convert.ToDateTime(reader["CreateDate"]).ToString("dd-MMM-yyyy");
                    oData.SpecialDiscountID = Convert.ToUInt32(reader["SpecialDiscountID"]).ToString();
                    oData.ApprovalNumber = (string)reader["ApprovalNumber"];
                    oData.SalesType = Enum.GetName(typeof(Dictionary.SalesType), (int)reader["SalesType"]);
                    if (reader["CustomerCode"] != DBNull.Value)
                    {
                        oData.CustomerCode = (string)reader["CustomerCode"];
                    }
                    else
                    {
                        oData.CustomerCode = "";
                    }
                    if (reader["CustomerName"] != DBNull.Value)
                    {
                        oData.CustomerName = (string)reader["CustomerName"];
                    }
                    else
                    {
                        oData.CustomerName = "";
                    }
                    oData.Amount = Convert.ToDouble(reader["Amount"]).ToString();
                    oData.WarehouseID = Convert.ToUInt32(reader["WarehouseID"]).ToString();
                    oData.OutletCode = (string)reader["OutletCode"];
                    oData.OutletName = (string)reader["OutletName"];
                    oData.AuthorityEmployeeID = Convert.ToUInt32(reader["AuthorityEmployeeID"]).ToString();
                    oData.AuthorityName = (string)reader["AuthorityName"];
                    oData.ApprovedEmployee = (string)reader["ApprovedEmployee"];
                    if (reader["Reason"] != DBNull.Value)
                    {
                        oData.Reason = (string)reader["Reason"];
                    }
                    else
                    {
                        oData.Reason = "";
                    }
                    if (reader["ApproveDate"] != DBNull.Value)
                    {
                        oData.ApproveDate = Convert.ToDateTime(reader["ApproveDate"]).ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        oData.ApproveDate = "";
                    }
                    if (reader["DiscountType"] != DBNull.Value)
                    {
                        oData.DiscountType = (string)reader["DiscountType"];
                    }
                    else
                    {
                        oData.DiscountType = "";
                    }
                    if (reader["EMITenure"] != DBNull.Value)
                    {
                        oData.EMITenure = Convert.ToInt32(reader["EMITenure"]).ToString();
                    }
                    else
                    {
                        oData.EMITenure = "";
                    }
                    oData.ApproveRemarks = (string)reader["ApproveRemarks"];
                    oData.Status = Convert.ToUInt32(reader["Status"]).ToString();
                    oData.StatusName = Enum.GetName(typeof(Dictionary.SpacialDiscountStatus), Convert.ToUInt32(reader["Status"]));
                    oData.RSP = Convert.ToDouble(reader["RSP"]).ToString();

                    oData.ProductCode = (string)reader["ProductCode"];
                    oData.ProductName = (string)reader["ProductName"];
                    oData.RSP = reader["RSP"].ToString();
                    oData.PromoDiscount = reader["PromoDiscountAmount"].ToString();

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



        public List<Data> GetSummaryData(string sDatabase, string sUserName)
        {
            int nYear = DateTime.Now.Year;
            int nMonth = DateTime.Now.Month;
            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = " Select a.*, EmployeeID, EmployeeName, IsNULL(c.CurrentLimit,0) as CurrentLimit, IsNull(c.CurrentDiscount,0) as CurrentDiscount from " +
                           " (Select AuthorityID, " +
                           " SUM(CASE When TMonth = 1 then Limit else 0 end) as JanLimit, SUM(CASE When TMonth = 1 then Discount else 0 end) as JanDiscount, " +
                           " SUM(CASE When TMonth = 2 then Limit else 0 end) as FebLimit, SUM(CASE When TMonth = 2 then Discount else 0 end) as FebDiscount, " +
                           " SUM(CASE When TMonth = 3 then Limit else 0 end) as MarLimit, SUM(CASE When TMonth = 3 then Discount else 0 end) as MarDiscount, " +
                           " SUM(CASE When TMonth = 4 then Limit else 0 end) as AprLimit, SUM(CASE When TMonth = 4 then Discount else 0 end) as AprDiscount, " +
                           " SUM(CASE When TMonth = 5 then Limit else 0 end) as MayLimit, SUM(CASE When TMonth = 5 then Discount else 0 end) as MayDiscount, " +
                           " SUM(CASE When TMonth = 6 then Limit else 0 end) as JunLimit, SUM(CASE When TMonth = 6 then Discount else 0 end) as JunDiscount, " +
                           " SUM(CASE When TMonth = 7 then Limit else 0 end) as JulLimit, SUM(CASE When TMonth = 7 then Discount else 0 end) as JulDiscount, " +
                           " SUM(CASE When TMonth = 8 then Limit else 0 end) as AugLimit, SUM(CASE When TMonth = 8 then Discount else 0 end) as AugDiscount, " +
                           " SUM(CASE When TMonth = 9 then Limit else 0 end) as SepLimit, SUM(CASE When TMonth = 9 then Discount else 0 end) as SepDiscount, " +
                           " SUM(CASE When TMonth = 10 then Limit else 0 end) as OctLimit, SUM(CASE When TMonth = 10 then Discount else 0 end) as OctDiscount, " +
                           " SUM(CASE When TMonth = 11 then Limit else 0 end) as NovLimit, SUM(CASE When TMonth = 11 then Discount else 0 end) as NovDiscount, " +
                           " SUM(CASE When TMonth = 12 then Limit else 0 end) as DecLimit, SUM(CASE When TMonth = 12 then Discount else 0 end) as DecDiscount " +
                           " from " +
                           " ( " +
                           " Select AuthorityID, Limit, Discount, TMonth from "+ sDatabase + ".[dbo].[t_PromoDiscountSpecialAuthorityLimit] Where TMonth = 1 and TYear = " + nYear + " " +
                           " UNION ALL " +
                           " Select AuthorityID, Limit, Discount, TMonth from " + sDatabase + ".[dbo].[t_PromoDiscountSpecialAuthorityLimit] Where TMonth = 2 and TYear = " + nYear + " " +
                           " UNION ALL " +
                           " Select AuthorityID, Limit, Discount, TMonth from " + sDatabase + ".[dbo].[t_PromoDiscountSpecialAuthorityLimit] Where TMonth = 3 and TYear = " + nYear + " " +
                           " UNION ALL " +
                           " Select AuthorityID, Limit, Discount, TMonth from " + sDatabase + ".[dbo].[t_PromoDiscountSpecialAuthorityLimit] Where TMonth = 4 and TYear = " + nYear + " " +
                           " UNION ALL " +
                           " Select AuthorityID, Limit, Discount, TMonth from " + sDatabase + ".[dbo].[t_PromoDiscountSpecialAuthorityLimit] Where TMonth = 5 and TYear = " + nYear + " " +
                           " UNION ALL " +
                           " Select AuthorityID, Limit, Discount, TMonth from " + sDatabase + ".[dbo].[t_PromoDiscountSpecialAuthorityLimit] Where TMonth = 6 and TYear = " + nYear + " " +
                           " UNION ALL " +
                           " Select AuthorityID, Limit, Discount, TMonth from " + sDatabase + ".[dbo].[t_PromoDiscountSpecialAuthorityLimit] Where TMonth = 7 and TYear = " + nYear + " " +
                           " UNION ALL " +
                           " Select AuthorityID, Limit, Discount, TMonth from " + sDatabase + ".[dbo].[t_PromoDiscountSpecialAuthorityLimit] Where TMonth = 8 and TYear = " + nYear + " " +
                           " UNION ALL " +
                           " Select AuthorityID, Limit, Discount, TMonth from " + sDatabase + ".[dbo].[t_PromoDiscountSpecialAuthorityLimit] Where TMonth = 9 and TYear = " + nYear + " " +
                           " UNION ALL " +
                           " Select AuthorityID, Limit, Discount, TMonth from " + sDatabase + ".[dbo].[t_PromoDiscountSpecialAuthorityLimit] Where TMonth = 10 and TYear = " + nYear + " " +
                           " UNION ALL " +
                           " Select AuthorityID, Limit, Discount, TMonth from " + sDatabase + ".[dbo].[t_PromoDiscountSpecialAuthorityLimit] Where TMonth = 11 and TYear = " + nYear + " " +
                           " UNION ALL " +
                           " Select AuthorityID, Limit, Discount, TMonth from " + sDatabase + ".[dbo].[t_PromoDiscountSpecialAuthorityLimit] Where TMonth = 12 and TYear = " + nYear + " " +
                           " )x group by AuthorityID)a INNER JOIN " + sDatabase + ".[dbo].[t_PromoDiscountSpecialAuthority] b ON a.AuthorityID = b.AuthorityID " +
                           " Left Outer JOIN " +
                           " (Select AuthorityID, Limit as CurrentLimit, Discount as CurrentDiscount from " + sDatabase + ".[dbo].[t_PromoDiscountSpecialAuthorityLimit] Where TMonth = "+ nMonth + " and TYear = "+ nYear + ")c " +
                           " ON a.AuthorityID = c.AuthorityID order by Sort ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Data oData = new Data();

                    oData.Value = "Success";
                    oData.AuthorityID = Convert.ToInt32(reader["AuthorityID"]).ToString();
                    oData.JanLimit = Convert.ToDouble(reader["JanLimit"]).ToString();
                    oData.JanDiscount = Convert.ToDouble(reader["JanDiscount"]).ToString();
                    oData.FebLimit = Convert.ToDouble(reader["FebLimit"]).ToString();
                    oData.FebDiscount = Convert.ToDouble(reader["FebDiscount"]).ToString();
                    oData.MarLimit = Convert.ToDouble(reader["MarLimit"]).ToString();
                    oData.MarDiscount = Convert.ToDouble(reader["MarDiscount"]).ToString();
                    oData.AprLimit = Convert.ToDouble(reader["AprLimit"]).ToString();
                    oData.AprDiscount = Convert.ToDouble(reader["AprDiscount"]).ToString();
                    oData.MayLimit = Convert.ToDouble(reader["MayLimit"]).ToString();
                    oData.MayDiscount = Convert.ToDouble(reader["MayDiscount"]).ToString();
                    oData.JunLimit = Convert.ToDouble(reader["JunLimit"]).ToString();
                    oData.JunDiscount = Convert.ToDouble(reader["JunDiscount"]).ToString();
                    oData.JulLimit = Convert.ToDouble(reader["JulLimit"]).ToString();
                    oData.JulDiscount = Convert.ToDouble(reader["JulDiscount"]).ToString();
                    oData.AugLimit = Convert.ToDouble(reader["AugLimit"]).ToString();
                    oData.AugDiscount = Convert.ToDouble(reader["AugDiscount"]).ToString();
                    oData.SepLimit = Convert.ToDouble(reader["SepLimit"]).ToString();
                    oData.SepDiscount = Convert.ToDouble(reader["SepDiscount"]).ToString();
                    oData.OctLimit = Convert.ToDouble(reader["OctLimit"]).ToString();
                    oData.OctDiscount = Convert.ToDouble(reader["OctDiscount"]).ToString();
                    oData.NovLimit = Convert.ToDouble(reader["NovLimit"]).ToString();
                    oData.NovDiscount = Convert.ToDouble(reader["NovDiscount"]).ToString();
                    oData.DecLimit = Convert.ToDouble(reader["DecLimit"]).ToString();
                    oData.DecDiscount = Convert.ToDouble(reader["DecDiscount"]).ToString();

                    oData.EmployeeID = Convert.ToInt32(reader["EmployeeID"]).ToString();
                    oData.EmployeeName = (string)reader["EmployeeName"];
                    oData.CurrentLimit = Convert.ToDouble(reader["CurrentLimit"]).ToString();
                    oData.CurrentDiscount = Convert.ToDouble(reader["CurrentDiscount"]).ToString();

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



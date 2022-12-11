
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

public partial class jISGMAuthorization : System.Web.UI.Page
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
            //string sType = "Summary";
           // string sRemarks = "TEST";


            int nISGMID = 0;
            if (c.Request.Form["RequisitionID"] != null)
            {
                nISGMID = Convert.ToInt32(c.Request.Form["RequisitionID"]);
            }
            string sRemarks = "";
            if (c.Request.Form["Remarks"] != null)
            {
                sRemarks = c.Request.Form["Remarks"].Trim();
            }
            string sAction = "";
            if (c.Request.Form["Action"] != null)
            {
                sAction = c.Request.Form["Action"].Trim();
            }
            //nISGMID = 5923000;
            

            string sDatabase = "x";
            int nChannelID = 0;
            if (sCompany == "TEL")
            {
                sDatabase = "TELSysDB";
                nChannelID = 4;
            }
            else if (sCompany == "TML")
            {
                sDatabase = "TMLSysDB";
                nChannelID = 14;
            }
            Datas _oDatas = new Datas();
            string sOutput = "";
            DBController.Instance.OpenNewConnection();
            if (sCompany == "TEL")
            {
                if (sType == "Summary")
                {
                    Data _oData = new Data();
                    _oData.InsertReportLog(sUser);
                }
            }
            if (sType == "Summary")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetData(sDatabase), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "Detail")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetDataDetail(sDatabase), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "Update")
            {
               Data oData = new Data();
               if (sAction == "Reject")
               {
                   sOutput = JsonConvert.SerializeObject(oData.ExecuiteReject(sDatabase, nISGMID, sUser, sRemarks), Formatting.Indented);
                   Response.Write(sOutput.ToString());
               }
               else if (sAction == "Approve")
               {
                   sOutput = JsonConvert.SerializeObject(oData.ExecuiteApprove(sDatabase, nISGMID, sUser, sRemarks, nChannelID), Formatting.Indented);
                   Response.Write(sOutput.ToString());
               }
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
        public string RequisitionID;
        public string RequisitionNo;
        public string Date;
        public string FromWHID;
        public string FromWHName;
        public string ToWHID;
        public string ToWHName;
        public string Remarks;

        public string ProductID;
        public string ProductCode;
        public string ProductName;
        public string RequisitionQty;

        public string Value;

        public int nFromWHID;
        public int nToWHID;
        public int nStatus;
        public int nStockTranID;
        public string ProductSerialNo;
        public int ISGMQty;


        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10016";
            string sReportName = "TEL-ISGM Authorization";
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
        }
        public List<Data> ExecuiteReject(string sDB, int nISGMID, string sUserName, string sRemarks)
        {
            List<Data> sResult = new List<Data>();
            int nCount = 0;
            Data _oData = new Data();
            DBController.Instance.OpenNewConnection();
            GetISGM(sDB, nISGMID);
            int nUserID = GetUserID(sDB, sUserName);
            DBController.Instance.CloseConnection();
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];

            DataTran oDataTran = new DataTran();


            string sTableName = "t_StockRequisition";

            //---------
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
                    int nStatus = (int)Dictionary.StockRequisitionStatus.Reject_By_HO;
                    int nProductStatus = (int)Dictionary.ProductSerialStatus.Received_at_Outlet;
                    command.CommandText = "Update " + sDB + ".dbo.t_StockRequisition Set Status = " + nStatus + " Where StockRequisitionID=" + nISGMID + " ";
                    nCount = command.ExecuteNonQuery();
                    if (nCount > 0)
                    {
                        command.CommandText = "Update " + sDB + ".dbo.t_StockRequisition Set AuthorizedBy = " + nUserID + ", AuthorizeDate = '" + DateTime.Now + "', AuthorizeRemarks='" + sRemarks + "' Where StockRequisitionID=" + nISGMID + " ";
                        command.ExecuteNonQuery();
                        command.CommandText = "INSERT INTO " + sDB + ".dbo.t_DataTransfer (TableName,DataID, WarehouseID,TransferType,IsDownload,BatchNo,CreateDate) VALUES ('" + sTableName + "', " + nISGMID + ", " + nFromWHID + ",2,1,0,'" + DateTime.Now + "') ";
                        command.ExecuteNonQuery();


                        Datas oDatas = new Datas();
                        DBController.Instance.OpenNewConnection();
                        oDatas.GetProductSerial(nStockTranID, sDB);
                        foreach (Data oData in oDatas)
                        {
                            int nProductSerialID = GetProductSerialID(sDB, oData.ProductSerialNo);
                            int nProductSerialHistoryID = GetProductSerialHitoryID(sDB, nProductSerialID);

                            command.CommandText = "Update " + sDB + ".dbo.t_ProductStockSerial SET Status=" + nProductStatus + " Where ProductSerialNo='" + oData.ProductSerialNo + "'";
                            command.ExecuteNonQuery();

                            command.CommandText = "DELETE FROM " + sDB + ".dbo.t_ProductStockSerialHistory WHERE ProductStockSerialHistoryID=" + nProductSerialHistoryID + "";
                            command.ExecuteNonQuery();
                        }
                        DBController.Instance.CloseConnection();
                        ///Update Vat Paid Data
                        command.CommandText = "Update " + sDB + ".dbo.t_ProductStockSerialVatPaid set Status="+ (int)Dictionary.ProductSerialStatus.Received_at_Outlet + " Where ProductSerialNo IN ( " +
                                               "Select ProductSerialNo from " + sDB + ".dbo.t_ProductTransferProductSerial Where TranID=" + nStockTranID + ") ";
                        command.ExecuteNonQuery();

                        command.CommandText = "Delete from " + sDB + ".dbo.t_ProductTransferProductSerial Where TranID IN ( " +
                                      "Select TranID from " + sDB + ".dbo.t_ProductStockTran Where TranID=" + nStockTranID + ") ";
                        command.ExecuteNonQuery();

                        command.CommandText = "Delete from " + sDB + ".dbo.t_ProductStockTranItem Where TranID IN ( " +
                                            "Select TranID from " + sDB + ".dbo.t_ProductStockTran Where TranID=" + nStockTranID + ") ";
                        command.ExecuteNonQuery();

                        command.CommandText = "Delete from " + sDB + ".dbo.t_ProductStockTran Where TranID=" + nStockTranID + "";
                        command.ExecuteNonQuery();

                        command.CommandText = "Update " + sDB + ".dbo.t_StockRequisition Set StockTranID = null Where StockRequisitionID=" + nISGMID + " ";
                        command.ExecuteNonQuery();
                        // Attempt to commit the transaction.
                        transaction.Commit();
                        _oData.Value = "Success";
                        sResult.Add(_oData);

                    }
                    else
                    {
                        _oData.Value = "Invalid";
                        sResult.Add(_oData);
                    }

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

        private void UpdateVatPaidData(int nStockTranID,string sRequisitionNo)
        {
            ////Update Vat Paid Data
            ProductBarcode _oMAXID = new ProductBarcode();
            int nID = _oMAXID.GetMaxID();


                ProductTransferProductSerials oVatPaidSerial = new ProductTransferProductSerials();
                oVatPaidSerial.GetProductTransferProductSerial(nStockTranID);
                foreach (ProductTransferProductSerial oVatPaid in oVatPaidSerial)
                {
                    if (oVatPaid.IsVATPaidProduct == 1)
                    {
                        ProductBarcode _oProductBarcode = new ProductBarcode();
                        _oProductBarcode.VatPaidID = nID;
                        _oProductBarcode.ProductId = oVatPaid.ProductID;
                        _oProductBarcode.WarehouseID = nToWHID;
                        _oProductBarcode.ProductSerialNo = oVatPaid.ProductSerialNo;
                        _oProductBarcode.TranNo = sRequisitionNo;
                        _oProductBarcode.TranDate = Convert.ToDateTime(DateTime.Now.Date);
                        _oProductBarcode.Status = (int)Dictionary.ProductSerialStatus.Received_at_Outlet;
                        _oProductBarcode.InsertVatPaidProductSerial();

                    }

                }

            

        }
        public List<Data> ExecuiteApprove(string sDB, int nISGMID, string sUserName, string sRemarks, int nChannelID)
        {
            List<Data> sResult = new List<Data>();
            int nCount = 0;
            Data _oData = new Data();
            DBController.Instance.OpenNewConnection();
            GetISGM(sDB, nISGMID);
            int nUserID = GetUserID(sDB, sUserName);
            DBController.Instance.CloseConnection();
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];

            DataTran oDataTran = new DataTran();


            string sTableName = "t_StockRequisition";

            //---------
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
                    int nStatus = (int)Dictionary.StockRequisitionStatus.Approve_By_HO;
                    //int nProductStatus = (int)Dictionary.ProductSerialStatus.Received_at_Outlet;
                    command.CommandText = "Update " + sDB + ".dbo.t_StockRequisition Set Status = " + nStatus + " Where StockRequisitionID=" + nISGMID + " ";
                    nCount = command.ExecuteNonQuery();
                    if (nCount > 0)
                    {
                        command.CommandText = "Update " + sDB + ".dbo.t_StockRequisition Set AuthorizedBy = " + nUserID + ", AuthorizeDate = '" + DateTime.Now + "', AuthorizeRemarks='" + sRemarks + "' Where StockRequisitionID=" + nISGMID + " ";
                        command.ExecuteNonQuery();
                        command.CommandText = "INSERT INTO " + sDB + ".dbo.t_DataTransfer (TableName,DataID, WarehouseID,TransferType,IsDownload,BatchNo,CreateDate) VALUES ('" + sTableName + "', " + nISGMID + ", " + nFromWHID + ",2,1,0,'" + DateTime.Now + "') ";
                        command.ExecuteNonQuery();

                        command.CommandText = "INSERT INTO " + sDB + ".dbo.t_DataTransfer (TableName,DataID, WarehouseID,TransferType,IsDownload,BatchNo,CreateDate) VALUES ('" + sTableName + "', " + nISGMID + ", " + nToWHID + ",1,1,0,'" + DateTime.Now + "') ";
                        command.ExecuteNonQuery();

                        int nStockTranStatus = (int)Dictionary.StockTransactionStatus.COMPLETE;

                        command.CommandText = "Update " + sDB + ".dbo.t_productstocktran SET Status=" + nStockTranStatus + " Where TranID=" + nStockTranID + " ";
                        command.ExecuteNonQuery();

                        Datas oDatas = new Datas();
                        DBController.Instance.OpenNewConnection();
                        oDatas.GetISGMItem(nISGMID, sDB);
                        foreach (Data oData in oDatas)
                        {
                            command.CommandText = "Update " + sDB + ".dbo.t_StockRequisitionItem SET AuthorizeQty=" + oData.ISGMQty + " Where ProductID = " + oData.ProductID + " and StockRequisitionID=" + nISGMID + "";
                            command.ExecuteNonQuery();

                           bool bFlag = CheckProduct(sDB,Convert.ToInt32(oData.ProductID), nChannelID, nToWHID);

                           if (bFlag == true)
                           {
                               command.CommandText = "update " + sDB + ".dbo.t_ProductStock set CurrentStock=CurrentStock - " + oData.ISGMQty + " where  ChannelID = " + nChannelID + " AND WarehouseID = " + nFromWHID + " AND ProductID = " + oData.ProductID + "";
                               command.ExecuteNonQuery();
                               command.CommandText = "update " + sDB + ".dbo.t_ProductStock set CurrentStock=CurrentStock + " + oData.ISGMQty + " where  ChannelID = " + nChannelID + " AND WarehouseID = " + nToWHID + " AND ProductID = " + oData.ProductID + "";
                               command.ExecuteNonQuery();
                           }
                           else
                           {
                               command.CommandText = "update " + sDB + ".dbo.t_ProductStock set CurrentStock=CurrentStock - " + oData.ISGMQty + " where  ChannelID = " + nChannelID + " AND WarehouseID = " + nFromWHID + " AND ProductID = " + oData.ProductID + "";
                               command.ExecuteNonQuery();

                               command.CommandText = "INSERT INTO " + sDB + ".dbo.t_ProductStock VALUES (" + oData.ProductID + "," + nToWHID + "," + (int)Dictionary.WareHouseStockType.SOUND + ",0,0,0,0," + nChannelID + ",1)";
                               command.ExecuteNonQuery();

                               command.CommandText = "update " + sDB + ".dbo.t_ProductStock set CurrentStock=CurrentStock + " + oData.ISGMQty + " where  ChannelID = " + nChannelID + " AND WarehouseID = " + nToWHID + " AND ProductID = " + oData.ProductID + "";
                               command.ExecuteNonQuery();
                           }

                        }

                        UpdateVatPaidData(nStockTranID, RequisitionNo);
                        DBController.Instance.CloseConnection();

                        // Attempt to commit the transaction.
                        transaction.Commit();
                        _oData.Value = "Success";
                        sResult.Add(_oData);

                    }
                    else
                    {
                        _oData.Value = "Invalid";
                        sResult.Add(_oData);
                    }

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
        public void GetISGM(string sDB, int nISGMID)
        {
           OleDbCommand cmd = DBController.Instance.GetCommand();
           string sSQL = "";
           sSQL = " Select RequisitionNo, FromWHID, ToWHID,Status,StockTranID  from " + sDB + ".dbo.t_StockRequisition where StockRequisitionID=" + nISGMID + " ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nFromWHID = Convert.ToInt32(reader["FromWHID"]);
                    nToWHID = Convert.ToInt32(reader["ToWHID"]);
                    nStatus = Convert.ToInt32(reader["Status"]);
                    RequisitionNo = reader["RequisitionNo"].ToString();
                    if (reader["StockTranID"] != DBNull.Value)
                    {
                        nStockTranID = Convert.ToInt32(reader["StockTranID"]);
                    }
                    else
                    {
                        nStockTranID = -1;
                    }
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
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
        public int GetProductSerialID(string sDB, string sProductSerialNo)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nResult = 0;
            string sSQL = "";
            sSQL = "select ProductSerialID from " + sDB + ".dbo.t_ProductStockSerial WITH(NOLOCK) Where ProductSerialNo='" + sProductSerialNo + "' ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nResult = Convert.ToInt32(reader["ProductSerialID"]);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nResult;
        }
        public int GetProductSerialHitoryID(string sDB, int nProductStockSerialID)
        {
            int nResult = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "select MAX (ProductStockSerialHistoryID) as ProductStockSerialHistoryID from " + sDB + ".dbo.t_ProductStockSerialHistory WITH(NOLOCK) Where ProductStockSerialID=" + nProductStockSerialID + "";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nResult = int.Parse(reader["ProductStockSerialHistoryID"].ToString());
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            return nResult;
        }
        public bool CheckProduct(string sDB, int nProductID,int nChannelID,int nToWHID)
        {
            int nCount = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = " select * from " + sDB + ".dbo.t_ProductStock WITH(NOLOCK) where  ChannelID = " + nChannelID + " AND WarehouseID = " + nToWHID + " AND ProductID = " + nProductID + " ";
            try
            {
                cmd.CommandText = sSQL;
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
                return true;
            }
            else
            {
                return false;
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
                    oData.ProductSerialNo = reader["ProductSerialNo"].ToString();

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
                    oData.ISGMQty = Convert.ToInt32(reader["RequisitionQty"]);
                    oData.ProductID = reader["ProductID"].ToString();

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
        public List<Data> GetData(string sDatabase)
        {

            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = " select StockRequisitionID, RequisitionNo, RequisitionDate, b.WarehouseID as FromWHID, " +
                          " b.ShortCode as FromWHName, c.WarehouseID as ToWHID,c.ShortCode as ToWHName, a.Remarks " +
                          " from " + sDatabase + ".dbo.t_StockRequisition a, " + sDatabase + ".dbo.t_Warehouse b, " + sDatabase + ".dbo.t_Warehouse c where b.WarehouseID=a.FromWHID  " +
                          " and a.ToWHID=c.WarehouseID and RequisitionType=" + (int)Dictionary.StockRequisitionType.ISGM + " " +
                          " and Status=" + (int)Dictionary.StockRequisitionStatus.Create + " " +
                          " Order by RequisitionDate";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.Value = "Success";
                    oData.RequisitionID = reader["StockRequisitionID"].ToString();
                    oData.RequisitionNo = reader["RequisitionNo"].ToString();
                    oData.Date = Convert.ToDateTime(reader["RequisitionDate"]).ToString("dd-MMM-yyyy");
                    oData.FromWHID = reader["FromWHID"].ToString();
                    oData.FromWHName = reader["FromWHName"].ToString();
                    oData.ToWHID = reader["ToWHID"].ToString();
                    oData.ToWHName = reader["ToWHName"].ToString();
                    oData.Remarks = reader["Remarks"].ToString();

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
        public List<Data> GetDataDetail(string sDatabase)
        {

            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = " select a.StockRequisitionID, a.ProductID, ProductCode, ProductName, RequisitionQty " +
                          " from " + sDatabase + ".dbo.t_StockRequisitionItem a, " + sDatabase + ".dbo.t_Product b," + sDatabase + ".dbo.t_StockRequisition c " +
                          " where a.StockRequisitionID=c.StockRequisitionID  " +
                          " and a.ProductID=b.ProductID and RequisitionType=" + (int)Dictionary.StockRequisitionType.ISGM + " " +
                          " and Status=" + (int)Dictionary.StockRequisitionStatus.Create + " Order by a.StockRequisitionID, ProductName ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.Value = "Success";
                    oData.RequisitionID = reader["StockRequisitionID"].ToString();
                    oData.ProductID = reader["ProductID"].ToString();
                    oData.ProductCode = reader["ProductCode"].ToString();
                    oData.ProductName = reader["ProductName"].ToString();
                    oData.RequisitionQty = reader["RequisitionQty"].ToString();

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


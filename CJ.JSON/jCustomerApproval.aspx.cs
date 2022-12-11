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

public partial class jCustomerApproval : System.Web.UI.Page
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
            //string sType = "Approve";

            //string sAction = "";
            //string sRemarks = "TEST";


            int nTempCustomerID = 0;
            if (c.Request.Form["CustomerID"] != null)
            {
                nTempCustomerID = Convert.ToInt32(c.Request.Form["CustomerID"]);
            }
            int nWarehouseID = 0;
            if (c.Request.Form["WarehouseID"] != null)
            {
                nWarehouseID = Convert.ToInt32(c.Request.Form["WarehouseID"]);
            }
            //string sRemarks = "";
            //if (c.Request.Form["Remarks"] != null)
            //{
            //    sRemarks = c.Request.Form["Remarks"].Trim();
            //}

            //nISGMID = 5923000;
            

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
            DBController.Instance.OpenNewConnection();
            if (sCompany == "TEL")
            {
                if (sType == "Summary")
                {
                    Data _oData = new Data();
                    //_oData.InsertReportLog(sUser);
                }
            }
            if (sType == "Summary")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetData(sDatabase), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "Reject")
            {
                oData = new Data();
                sOutput = JsonConvert.SerializeObject(oData.ExecuiteReject(sDatabase, sUser, nTempCustomerID, nWarehouseID), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "Approve")
            {
                oData = new Data();
                sOutput = JsonConvert.SerializeObject(oData.ExecuiteApprove(sDatabase, sUser, nTempCustomerID, nWarehouseID), Formatting.Indented);
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

        public int WarehouseID;
        public string ShowroomCode;
        public int CustomerID;
        public string CustomerName;
        public string CustomerCode;
        public string CreateDate;
        public int CreateUserID;
        public int ParentCustomerID;
        public string ParentCustomerCode;
        public string ParentCustomerName;
        public string CustomerAddress;
        public string CustomerTelephone;
        public string CustomerFax;
        public string CellPhoneNo;
        public string CustomerShortName;
        public string CellPhoneNumber;
        public string ContactPerson;
        public int CustTypeID;
        public int MarketGroupID;
        public int GeoLocationID;
        public string EmailAddress;
        public string EnrollmentDate;
        public int Terminal;
        public int Status;
        public string ContractPerson;
        public string ContactDesignation;
        public int IsActive;
        public int SBUID;
        public string SBUCode;
        public string SBUName;
        public int ChannelID;
        public string ChannelCode;
        public string ChannelDescription;
        public int CustomerTypeID;
        public string CustomerTypeCode;
        public string CustomerTypeName;
        public int Areaid;
        public string AreaCode;
        public string AreaName;
        public int TerritoryID;
        public string TerritoryCode;
        public string TerritoryName;
        public int DistrictID;
        public string DistrictCode;
        public string DistrictName;
        public int ThanaID;
        public string ThanaCode;
        public string ThanaName;
        public string ThanaCategory;

        public void GetCustomerByID(int nTempCustomerID, int nWarehouseID, string sDatabase)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";
                 sSql = "Select * From  " +
                    "(SELECT WarehouseID,qq6.ShowroomCode,qq1.CustomerID, qq1.CustomerName,isnull(qq7.NewCustomerCode,'') as CustomerCode,qq1.CreateDate,qq1.CreateUserID, qq1.ParentCustomerID, qq5.CustomerCode AS ParentCustomerCode,   " +
                    "qq5.CustomerName AS ParentCustomerName, qq1.CustomerAddress, qq1.CustomerTelephone, qq1.CustomerFax, qq1.CellPhoneNumber AS CellPhoneNo,  " +
                    "qq1.CustomerShortName,qq1.CellPhoneNumber,qq1.ContactPerson,qq1.CustTypeID,qq1.MarketGroupID,qq1.GeoLocationID,  " +
                    "qq1.EmailAddress,qq1.EnrollmentDate,qq1.Terminal,qq1.Status,   " +
                    "qq1.ContactPerson AS ContractPerson, qq1.ContactDesignation, qq1.IsActive, qq1.SBUID, qq1.SBUCode, qq1.SBUName, qq1.ChannelID, qq1.ChannelCode,   " +
                    "qq1.ChannelDescription, qq1.CustTypeID AS CustomerTypeID, qq1.CustTypeCode AS CustomerTypeCode, qq1.CustTypeDescription AS CustomerTypeName,   " +
                    "qq2.Areaid, qq2.AreaCode, qq2.AreaName, qq2.TerritoryID, qq2.TerritoryCode, qq2.TerritoryName, qq3.DistrictID, qq3.DistrictCode, qq3.DistrictName, qq3.ThanaID,   " +
                    "qq3.ThanaCode, qq3.ThanaName, qq3.ThanaCategory  " +
                    "FROM      " +
                    "(SELECT c.CustomerID, c.ParentCustomerID,c.CustomerShortName, c.CustomerName,  " +
                    "c.CreateDate,c.CreateUserID, c.CustomerAddress, isnull(c.CustomerTelephone,'') CustomerTelephone,   " +
                    "isnull(c.CustomerFax,'') CustomerFax, c.CellPhoneNumber,   " +
                    "c.ContactPerson, c.ContactDesignation, c.IsActive, c.GeoLocationID,   " +
                    "isnull(c.EmailAddress,'') EmailAddress,c.EnrollmentDate,c.Terminal,  " +
                    "c.Status,c.MarketGroupID, t.CustTypeID, t.CustTypeCode, t.CustTypeDescription, ch.ChannelID,   " +
                    "ch.ChannelCode, ch.ChannelDescription, sb.SBUID, sb.SBUCode, sb.SBUName  " +
                    "FROM  " + sDatabase + ".dbo.t_CustomertEMP AS c INNER JOIN  " +
                    "" + sDatabase + ".dbo.t_CustomerType AS t ON c.CustTypeID = t.CustTypeID INNER JOIN  " +
                    "" + sDatabase + ".dbo.t_Channel AS ch ON t.ChannelID = ch.ChannelID INNER JOIN  " +
                    "" + sDatabase + ".dbo.t_SBU AS sb ON ch.SBUID = sb.SBUID) AS qq1   " +
                    "INNER JOIN  " +
                    "(SELECT q1.MarketGroupID AS Areaid, q1.MarketGroupCode AS AreaCode,   " +
                    "q1.MarketGroupDesc AS AreaName, q2.MarketGroupID AS TerritoryID,   " +
                    " q2.MarketGroupCode AS TerritoryCode, q2.MarketGroupDesc AS TerritoryName  " +
                    "FROM      " +
                    "(SELECT MarketGroupID, MarketGroupCode, MarketGroupDesc, ParentID  " +
                    " FROM " + sDatabase + ".dbo.t_MarketGroup) AS q1 INNER JOIN  " +
                    "(SELECT MarketGroupID, MarketGroupCode, MarketGroupDesc, ParentID  " +
                    " FROM " + sDatabase + ".dbo.t_MarketGroup AS t_MarketGroup_1) AS q2 ON q1.MarketGroupID = q2.ParentID) AS qq2 ON   " +
                    "qq1.MarketGroupID = qq2.TerritoryID   " +
                    "LEFT OUTER JOIN  " +
                    "(SELECT q3.GeoLocationID AS DistrictID, q3.GeoLocationCode AS DistrictCode, q3.GeoLocationName AS DistrictName, q4.GeoLocationID AS ThanaID,   " +
                    "q4.GeoLocationCode AS ThanaCode, q4.GeoLocationName AS ThanaName, q4.GeoLocationCategory AS ThanaCategory  " +
                    "FROM (SELECT GeoLocationID, GeoLocationCode, GeoLocationName, ParentID  " +
                    "FROM  " + sDatabase + ".dbo.t_GeoLocation) AS q3 INNER JOIN  " +
                    "(SELECT GeoLocationID, GeoLocationCode, GeoLocationName, GeoLocationCategory, ParentID  " +
                    "FROM " + sDatabase + ".dbo.t_GeoLocation AS t_GeoLocation_1) AS q4 ON q3.GeoLocationID = q4.ParentID) AS qq3 ON   " +
                    "qq1.GeoLocationID = qq3.ThanaID  " +
                    "LEFT OUTER JOIN  " +
                    " (SELECT CustomerID, CustomerCode, CustomerName  " +
                    "FROM  " + sDatabase + ".dbo.t_Customer ) AS qq5 ON qq1.ParentCustomerID = qq5.CustomerID  " +
                    "LEFT OUTER JOIN  " +
                    " (SELECT CustomerID, WarehouseID,ShowroomCode  " +
                    "FROM  " + sDatabase + ".dbo.t_Showroom ) AS qq6 ON qq1.ParentCustomerID = qq6.CustomerID  " +
                    " left outer join  " +
                    " (Select * From (Select a.CustomerID,NewCustomerCode,a.ParentCustomerID From " + sDatabase + ".dbo.t_CustomerTemp a, " + sDatabase + ".dbo.t_Customer b   " +
                    " where a.NewCustomerCode=b.CustomerCode) x) AS qq7 ON qq1.CustomerID = qq7.CustomerID  and qq1.ParentCustomerID=qq7.ParentCustomerID   " +
                    ") Main where 1=1 and Status = 1 and CustomerID = " + nTempCustomerID + " and WarehouseID = " + nWarehouseID + " ";


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    CustomerID = int.Parse(reader["CustomerID"].ToString());
                    WarehouseID = int.Parse(reader["WarehouseID"].ToString());
                    ShowroomCode = reader["ShowroomCode"].ToString();
                    CustomerCode = reader["CustomerCode"].ToString();
                    ParentCustomerID = Convert.ToInt32(reader["ParentCustomerID"]);
                    ParentCustomerCode = reader["ParentCustomerCode"].ToString();
                    if (reader["CustomerShortName"] != DBNull.Value)
                        CustomerShortName = (string)reader["CustomerShortName"];
                    else CustomerShortName = "";
                    CustomerName = reader["CustomerName"].ToString();
                    CustomerAddress = reader["CustomerAddress"].ToString();
                    CustomerTelephone = reader["CustomerTelephone"].ToString();
                    CustomerFax = reader["CustomerFax"].ToString();
                    CellPhoneNo = reader["CellPhoneNo"].ToString();
                    ContactPerson = reader["ContractPerson"].ToString();
                    ContactDesignation = reader["ContactDesignation"].ToString();
                    ChannelDescription = reader["ChannelDescription"].ToString();
                    ChannelID = int.Parse(reader["ChannelID"].ToString());
                    Areaid = int.Parse(reader["AreaID"].ToString());
                    AreaName = reader["AreaName"].ToString();
                    EmailAddress = reader["EmailAddress"].ToString();
                    TerritoryName = reader["territoryName"].ToString();
                    CustTypeID = int.Parse(reader["CustomerTypeID"].ToString());
                    MarketGroupID = int.Parse(reader["TerritoryID"].ToString());
                    DistrictID = int.Parse(reader["DistrictID"].ToString());
                    GeoLocationID = int.Parse(reader["ThanaID"].ToString());
                    Status = int.Parse(reader["Status"].ToString());
                    CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    CreateDate = Convert.ToDateTime(reader["CreateDate"]).ToString("dd-MMM-yyyy");
                    Terminal = int.Parse(reader["Terminal"].ToString());

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }



        public void InsertReportLog(string sUser)
        {
            //ReportLog oReportLog = new ReportLog();
            //string sReportCode = "A10016";
            //string sReportName = "TEL-ISGM Authorization";
            //string connStr;
            //connStr = ConfigurationManager.AppSettings["jConnectionString"];
            //oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
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
        public List<Data> ExecuiteApprove(string sDB, string sUserName, int nTempCustomerID, int nWarehouseID)
        {
            List<Data> sResult = new List<Data>();
            int nCount = 0;
            Data _oData = new Data();
            DBController.Instance.OpenNewConnection();
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

                    Data oData = new Data();
                    DBController.Instance.OpenNewConnection();
                    GetCustomerByID(nTempCustomerID, nWarehouseID, sDB);
                    DateTime _Date = DateTime.Now;
                    int MaxCustID = GetMaxCustID(sDB);
                    string sCustCode = GetMaxCustomerCode(sDB);

                    command.CommandText = "Insert Into " + sDB + ".dbo.t_Customer (CustomerID, ParentCustomerID, CustomerCode, CustomerName, CustomerAddress, " +
                        " CustomerTelephone, CustomerFax, CellPhoneNumber, ContactPerson, ContactDesignation, IsActive, " +
                        " CustTypeID, MarketGroupID, GeoLocationID, EmailAddress, EnrollmentDate, UploadStatus, UploadDate, " +
                        " DownloadDate, RowStatus, Terminal, EntryDate, EntryUserID, UpdateDate, UpdateUserID, CustomerShortName ) " +
                        " VALUES (" + MaxCustID + ", " + ParentCustomerID + ",'" + sCustCode + "', '" + CustomerName + "','" + CustomerAddress + "', " +
                        "'" + CustomerTelephone + "','" + CustomerFax + "','" + CellPhoneNumber + "','" + ContactPerson + "','" + ContactDesignation + "',"+(int)Dictionary.IsActive.Active+", " +
                        " " + CustTypeID + "," + MarketGroupID + "," + GeoLocationID + ",'" + EmailAddress + "', '" + EnrollmentDate + "', Null, Null, " +
                        " Null, Null, " + Terminal + ", '" + _Date + "'," + CreateUserID + ", Null, Null,'" + CustomerShortName + "') ";
                    command.ExecuteNonQuery();

                    //t_CustomerTemp
                    command.CommandText = "INSERT INTO " + sDB + ".dbo.t_DataTransfer (TableName,DataID, WarehouseID,TransferType,IsDownload,BatchNo,CreateDate) VALUES('t_CustomerTemp'," + CustomerID + "," + WarehouseID + ",1,1,0,'" + _Date + "')";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO " + sDB + ".dbo.t_DataTransfer (TableName,DataID, WarehouseID,TransferType,IsDownload,BatchNo,CreateDate) VALUES('t_Customer'," + MaxCustID + "," + WarehouseID + ",1,1,0,'" + _Date + "')";
                    command.ExecuteNonQuery();

                    command.CommandText = "UPDATE " + sDB + ".dbo.t_CustomerTemp SET NewCustomerCode = '" + sCustCode + "', Status = " + (int)Dictionary.B2BCustomerStatus.Approve_By_HO + ", ApprovedUserID = " + nUserID + ", ApprovedDate = '" + _Date + "' WHERE CustomerID = " + CustomerID + " and WarehouseID = " + WarehouseID + "";
                    command.ExecuteNonQuery();

                    command.CommandText = "Insert Into " + sDB + ".dbo.t_CustomerAccount (CustomerID, CurrentBalance) VALUES ( " + MaxCustID + ", 0) ";
                    command.ExecuteNonQuery();



                    DBController.Instance.CloseConnection();

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

        public List<Data> ExecuiteReject(string sDB, string sUserName, int nTempCustomerID, int nWarehouseID)
        {
            List<Data> sResult = new List<Data>();
            int nCount = 0;
            Data _oData = new Data();
            DBController.Instance.OpenNewConnection();
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

                    Data oData = new Data();
                    DBController.Instance.OpenNewConnection();
                    DateTime _Date = DateTime.Now;

                    command.CommandText = "UPDATE " + sDB + ".dbo.t_CustomerTemp SET Status = " + (int)Dictionary.B2BCustomerStatus.Reject + ", ApprovedUserID = " + nUserID + ", ApprovedDate = '" + _Date + "' WHERE CustomerID = " + nTempCustomerID + " and WarehouseID = " + nWarehouseID + "";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO " + sDB + ".dbo.t_DataTransfer (TableName,DataID, WarehouseID,TransferType,IsDownload,BatchNo,CreateDate) VALUES('t_CustomerTemp'," + nTempCustomerID + "," + nWarehouseID + ",1,1,0,'" + _Date + "')";
                    command.ExecuteNonQuery();



                    DBController.Instance.CloseConnection();

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

        public int GetMaxCustID(string sDB)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nResult = 0;
            string sSQL = "";
            sSQL = "select Max(CustomerID) as CustomerID from " + sDB + ".dbo.t_Customer ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nResult = Convert.ToInt32(reader["CustomerID"]) + 1;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nResult;
        }

        public string GetMaxCustomerCode(string sDB)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            string sCode = "";
            try
            {
                if (sDB == "TELSysDB")
                {
                    cmd.CommandText = "Select '4500'+CONVERT(varchar(10), CustomerCode) as CustomerCode From  " +
                                      "(Select max(CustomerID)+1 as CustomerCode From t_Customer ) x";
                }
                else 
                {
                    cmd.CommandText = " Select CONVERT(varchar(10), CustomerCode) as CustomerCode  " +
                                      " From (Select max(CustomerCode)+1 as CustomerCode     " +
                                      " From " + sDB + ".dbo.t_Customer where CusttypeID=202 and   " +
                                      " Customercode like '4500%') x";
                }

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sCode = (string)reader["CustomerCode"];

                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return sCode;
        }

        #region
        //public void GetISGM(string sDB, int nISGMID)
        //{
        //   OleDbCommand cmd = DBController.Instance.GetCommand();
        //   string sSQL = "";
        //   sSQL = " Select RequisitionNo, FromWHID, ToWHID,Status,StockTranID  from " + sDB + ".dbo.t_StockRequisition where StockRequisitionID=" + nISGMID + " ";
        //    try
        //    {
        //        cmd.CommandText = sSQL;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            nFromWHID = Convert.ToInt32(reader["FromWHID"]);
        //            nToWHID = Convert.ToInt32(reader["ToWHID"]);
        //            nStatus = Convert.ToInt32(reader["Status"]);
        //            RequisitionNo = reader["RequisitionNo"].ToString();
        //            if (reader["StockTranID"] != DBNull.Value)
        //            {
        //                nStockTranID = Convert.ToInt32(reader["StockTranID"]);
        //            }
        //            else
        //            {
        //                nStockTranID = -1;
        //            }
        //        }
        //        reader.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
        
        //public int GetProductSerialID(string sDB, string sProductSerialNo)
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    int nResult = 0;
        //    string sSQL = "";
        //    sSQL = "select ProductSerialID from " + sDB + ".dbo.t_ProductStockSerial WITH(NOLOCK) Where ProductSerialNo='" + sProductSerialNo + "' ";
        //    try
        //    {
        //        cmd.CommandText = sSQL;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            nResult = Convert.ToInt32(reader["ProductSerialID"]);
        //        }
        //        reader.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    return nResult;
        //}
        //public int GetProductSerialHitoryID(string sDB, int nProductStockSerialID)
        //{
        //    int nResult = 0;
        //    OleDbCommand cmd = DBController.Instance.GetCommand();

        //    string sSql = "select MAX (ProductStockSerialHistoryID) as ProductStockSerialHistoryID from " + sDB + ".dbo.t_ProductStockSerialHistory WITH(NOLOCK) Where ProductStockSerialID=" + nProductStockSerialID + "";

        //    try
        //    {
        //        cmd.CommandText = sSql;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            nResult = int.Parse(reader["ProductStockSerialHistoryID"].ToString());
        //        }
        //        reader.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);

        //    }
        //    return nResult;
        //}
        //public bool CheckProduct(string sDB, int nProductID,int nChannelID,int nToWHID)
        //{
        //    int nCount = 0;
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    string sSQL = "";
        //    sSQL = " select * from " + sDB + ".dbo.t_ProductStock WITH(NOLOCK) where  ChannelID = " + nChannelID + " AND WarehouseID = " + nToWHID + " AND ProductID = " + nProductID + " ";
        //    try
        //    {
        //        cmd.CommandText = sSQL;
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            nCount++;
        //        }
        //        reader.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    if (nCount != 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
#endregion
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
        
        public List<Data> GetData(string sDatabase)
        {

            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select a.CustomerID, a.WarehouseID, ShowroomCode, CustomerName, Convert(datetime,replace(convert(varchar, CreateDate,6),'','-'),1)CreateDate "+
                           " from " + sDatabase + ".dbo.t_CustomerTemp a, " + sDatabase + ".dbo.t_Showroom b Where a.WarehouseID=b.WarehouseID and Status = 1 " +
                           " Order by ShowroomCode ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.Value = "Success";

                    oData.CustomerID = (int)reader["CustomerID"];
                    oData.WarehouseID = (int)reader["WarehouseID"];
                    oData.ShowroomCode = (string)reader["ShowroomCode"];
                    oData.CustomerName = (string)reader["CustomerName"];
                    oData.CreateDate = Convert.ToDateTime(reader["CreateDate"]).ToString("dd-MMM-yyyy");


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



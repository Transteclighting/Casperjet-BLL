using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Data.OleDb;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;

public partial class jDMSSalesOrderApprove : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            string sUser = c.Request.Form["UserName"].Trim();
            string sType = c.Request.Form["Type"].Trim();
            string sSalesType = c.Request.Form["SalesType"].Trim();

            //string sUser = "hakim";
            //string sType = "Summary";
            //string sSalesType = "5"; // 3=B2B & 5=Dealer
            //string sRemarks = "TEST";


            int nOrderId = 0;
            if (c.Request.Form["OrderID"] != null)
            {
                nOrderId = Convert.ToInt32(c.Request.Form["OrderID"]);
            }

            int nWarehouseId = 0;
            if (c.Request.Form["WarehouseId"] != null)
            {
                nWarehouseId = Convert.ToInt32(c.Request.Form["WarehouseId"]);
            }

            string sOrderNo = "";
            if (c.Request.Form["OrderNo"] != null)
            {
                sOrderNo = c.Request.Form["OrderNo"].Trim();
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

            //nOrderId = 1;
            //nWarehouseId = 156;

            //string sUser = "hakim";
            //string sType = "Update";
            //string sSalesType = "5"; // 3=B2B & 5=Dealer
            //sRemarks = "TEST Approve";
            sAction = "Approve";
            sOrderNo = "Order-GOV-190001";
            int nChannelID = 0;
            nChannelID = 4;

            Datas _oDatas = new Datas();
            string sOutput = "";
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            if (sType == "Summary")
            {
                Data _oData = new Data();
                _oData.InsertReportLog(sUser, sSalesType);
            }

            if (sType == "Summary")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetData(sSalesType), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "Detail")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetDataDetail(nOrderId, nWarehouseId), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "Update")
            {
                Data oData = new Data();
                if (sAction == "Reject")
                {
                    sOutput = JsonConvert.SerializeObject(oData.ExecuiteReject(nOrderId, nWarehouseId, sUser, sRemarks), Formatting.Indented);
                    Response.Write(sOutput.ToString());
                }
                else if (sAction == "Approve")
                {
                    sOutput = JsonConvert.SerializeObject(oData.ExecuiteApprove(nOrderId, nWarehouseId, sUser, sRemarks, nChannelID), Formatting.Indented);
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
        public string OrderID;
        public string OrderNo;
        public string Date;
        public string CustomerID;
        public string CustomerName;
        public string ParentCustomerID;
        public string ParentCustomerName;

        public string ProductID;
        public string ProductCode;
        public string ProductName;
        public string OrderQty;
        public string ContactNo;
        public string sWarehouseID;

        public string Value;

        public int nCustomerID;
        public int nParentCustomerID;
        public int nStatus;
        public int nWarehouseID;
        public string ProductSerialNo;
        public int ISGMQty;
        //public int nStockTranID;

        private int GetMappedWarehouseID(int nWHID)
        {
            int nMappedWarehouseID = 0;


            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = "Select MappedWarehouseID from t_Showroom where WarehouseID=" + nWHID + "";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nMappedWarehouseID = Convert.ToInt32(reader["MappedWarehouseID"]);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nMappedWarehouseID;
        }
        public POSRequisition GetUIData(POSRequisition _oPOSRequisition)
        {

            _oPOSRequisition.FromWHID = _oPOSRequisition.FromWHID;
            _oPOSRequisition.ToWHID = GetMappedWarehouseID(_oPOSRequisition.FromWHID);
            _oPOSRequisition.Remarks = "Auto generated requisition for DMS order.";
            _oPOSRequisition.Terminal = (int)Dictionary.Terminal.Head_Office;


            //// Product Details
            //foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            //{
            //    if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
            //    {

            //        POSRequisitionItem _oPOSRequisitionItem = new POSRequisitionItem();

            //        _oPOSRequisitionItem.ProductID = int.Parse(oItemRow.Cells[10].Value.ToString());
            //        _oPOSRequisitionItem.RequisitionQty = int.Parse(oItemRow.Cells[8].Value.ToString());
            //        _oPOSRequisitionItem.AuthorizeQty = 0;

            //        _oPOSRequisition.Add(_oPOSRequisitionItem);

            //    }
            //}

            return _oPOSRequisition;
        }
        private void InsertAutoRequisition(int nWarehouseID,int nOrderID)
        {

            DBController.Instance.BeginNewTransaction();
            POSRequisition _oPOSRequisition = new POSRequisition();
            _oPOSRequisition.FromWHID = nWarehouseID;

            _oPOSRequisition = GetUIData(_oPOSRequisition);

            _oPOSRequisition.InsertStockRequisition((int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Create);

            DBController.Instance.CommitTran();
        }
        public void InsertReportLog(string sUser, string sSalesType)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "";
            string sReportName = "";

            if (sSalesType == "5")
            {
                sReportCode = "A10050";
                sReportName = "M41.1.22','Dealer Order Approval [120]";
            }
            else if (sSalesType == "3")
            {
                sReportCode = "A10051";
                sReportName = "B2B Order Approval [121]";
            }
            
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
        }
        public List<Data> ExecuiteReject( int nOrderID,int _nWarehouseId, string sUserName, string sRemarks)
        {
            List<Data> sResult = new List<Data>();
            int nCount = 0;
            Data _oData = new Data();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            //GetDMSOrder(sDB, nOrderID, _nWarehouseId);
            int nUserID = GetUserID( sUserName);
            DBController.Instance.CloseConnection();
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];

            DataTran oDataTran = new DataTran();


            string sTableName = "t_DMSSecondarySalesOrder";

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
                    int nStatus = (int)Dictionary.DMSSecondarySalesOrderStatus.Reject_By_HO;
                    command.CommandText = "Update t_DMSSecondarySalesOrder Set Status = " + nStatus + " Where OrderID=" + nOrderID + " and WarehouseID=" + _nWarehouseId + " ";
                    nCount = command.ExecuteNonQuery();
                    if (nCount > 0)
                    {
                        command.CommandText = "Update t_DMSSecondarySalesOrder Set AuthorizedBy = " + nUserID + ", AuthorizeDate = '" + DateTime.Now + "', AuthorizeRemarks='" + sRemarks + "' Where OrderID=" + nOrderID + " and WarehouseID=" + _nWarehouseId + "";
                        command.ExecuteNonQuery();
                        command.CommandText = "Update t_DMSSecondarySalesOrderDetail Set ConfirmedQty=0 Where OrderID=" + nOrderID + " and WarehouseID=" + _nWarehouseId + "";
                        command.ExecuteNonQuery();
                        command.CommandText = "INSERT INTO t_DataTransfer (TableName,DataID, WarehouseID,TransferType,IsDownload,BatchNo,CreateDate) VALUES ('" + sTableName + "', " + nOrderID + ", " + _nWarehouseId + ",2,1,0,'" + DateTime.Now + "') ";
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

        public List<Data> ExecuiteApprove( int nOrderID, int _nWarehouseId,string sUserName, string sRemarks, int nChannelID)
        {
            List<Data> sResult = new List<Data>();
            int nCount = 0;
            Data _oData = new Data();
            DBController.Instance.OpenNewConnection();
            //GetDMSOrder(sDB, nOrderID, _nWarehouseId);
            int nUserID = GetUserID(sUserName);
            DBController.Instance.CloseConnection();
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];

            DataTran oDataTran = new DataTran();


            string sTableName = "t_DMSSecondarySalesOrder";

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
                    int nStatus = (int)Dictionary.DMSSecondarySalesOrderStatus.Approved_By_HO;

                    command.CommandText = "Update t_DMSSecondarySalesOrder Set Status = " + nStatus + " Where OrderID=" + nOrderID + " and  WarehouseID=" + _nWarehouseId + " ";
                    nCount = command.ExecuteNonQuery();
                    if (nCount > 0)
                    {
                        command.CommandText = "Update t_DMSSecondarySalesOrder Set AuthorizedBy = " + nUserID + ", AuthorizeDate = '" + DateTime.Now + "', AuthorizeRemarks='" + sRemarks + "' Where OrderID=" + nOrderID + " and WarehouseID=" + _nWarehouseId + "";
                        command.ExecuteNonQuery();
                        command.CommandText = "INSERT INTO t_DataTransfer (TableName,DataID, WarehouseID,TransferType,IsDownload,BatchNo,CreateDate) VALUES ('" + sTableName + "', " + nOrderID + ", " + _nWarehouseId + ",2,1,0,'" + DateTime.Now + "') ";
                        command.ExecuteNonQuery();

                        command.CommandText = "Update t_DMSSecondarySalesOrderDetail Set ConfirmedQty=OrderQty Where OrderID=" + nOrderID + " and WarehouseID=" + _nWarehouseId + "";
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
        public void GetDMSOrder(string sDB, int nOrderID, int nWarehouseID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = " Select OrderNo, CustomerID, ParentCustomerID,Status,WarehouseID  from t_DMSSecondarySalesOrder where OrderID=" + nOrderID + " and WarehouseID=" + nWarehouseID + "";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nCustomerID = Convert.ToInt32(reader["CustomerID"]);
                    nParentCustomerID = Convert.ToInt32(reader["ParentCustomerID"]);
                    nStatus = Convert.ToInt32(reader["Status"]);
                    OrderNo = reader["OrderNo"].ToString();
                    nWarehouseID = Convert.ToInt32(reader["WarehouseID"]);

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public int GetUserID(string sUserName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nResult = 0;
            string sSQL = "";
            sSQL = "select UserID from t_User Where UserName='" + sUserName + "'";
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
        public void GetProductSerial(int nStockTranID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = " select * from t_ProductTransferProductSerial where TranID=" + nStockTranID + " ";
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
        public void GetOrderItem(int nOrderID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = " select * from t_DMSSecondarySalesOrderDetail where OrderID=" + nOrderID + " ";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Data oData = new Data();
                    oData.ISGMQty = Convert.ToInt32(reader["OrderQty"]);
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
        public List<Data> GetData(string sSalesType)
        {

            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "Select OrderID,OrderNo,CreateDate as OrderDate,a.WarehouseID,a.CustomerID,b.CustomerName,a.ParentCustomerID,c.CustomerID as ParentCustomerName , b.CellPhoneNumber as ContactNo " +
                        "From t_DMSSecondarySalesOrder a,t_Customer b,t_Customer c " +
                        "where a.CustomerID=b.CustomerID and a.ParentCustomerID=c.CustomerID and a.Status=" + (int)Dictionary.DMSSecondarySalesOrderStatus.Submit + " and SalesType = "+ sSalesType + " " +
                        "order by a.OrderID,a.WarehouseID";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.Value = "Success";
                    oData.OrderID = reader["OrderID"].ToString();
                    oData.OrderNo = reader["OrderNo"].ToString();
                    oData.Date = Convert.ToDateTime(reader["OrderDate"]).ToString("dd-MMM-yyyy");
                    oData.CustomerID = reader["CustomerID"].ToString();
                    oData.CustomerName = reader["CustomerName"].ToString();
                    oData.ParentCustomerID = reader["ParentCustomerID"].ToString();
                    oData.ParentCustomerName = reader["ParentCustomerName"].ToString();
                    oData.ContactNo = reader["ContactNo"].ToString();
                    oData.sWarehouseID = reader["WarehouseID"].ToString();

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
        public List<Data> GetDataDetail(int sOrderId, int sWarehouseId)
        {

            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = "Select a.OrderID,b.ProductID,ProductCode,ProductName,OrderQty  " +
                        "From t_DMSSecondarySalesOrder a, t_DMSSecondarySalesOrderDetail b,t_Product c  " +
                        "where a.OrderID = b.OrderID and a.WarehouseID = b.WarehouseID and Status = " + (int)Dictionary.DMSSecondarySalesOrderStatus.Submit + " and  b.OrderId = "+ sOrderId + " and b.WarehouseId = "+ sWarehouseId + " and " +
                        "b.ProductID = c.ProductID order by a.OrderID,ProductCode";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.Value = "Success";
                    oData.OrderID = reader["OrderID"].ToString();
                    oData.ProductID = reader["ProductID"].ToString();
                    oData.ProductCode = reader["ProductCode"].ToString();
                    oData.ProductName = reader["ProductName"].ToString();
                    oData.OrderQty = reader["OrderQty"].ToString();

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
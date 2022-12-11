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

public partial class jCustomerAccountSend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sCustomerCode = c.Request.Form["CustomerCode"].Trim();
            string sType = c.Request.Form["Type"].Trim();


            //string sUser = "hakim";
            //string sCustomerCode = "10708009";
            //string sType = "AcctSend";

            string sOutput = "";

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            Data _oData = new Data();

            if (sType == "CustName")
            {
                sOutput = JsonConvert.SerializeObject(_oData.CheckCustomer(sCustomerCode), Formatting.Indented);
                Response.Write(sOutput.ToString());
            }
            else if (sType == "AcctSend")
            {
                sOutput = JsonConvert.SerializeObject(_oData.SendAccount(sCustomerCode), Formatting.Indented);
                Response.Write(sOutput.ToString());
                _oData.InsertReportLog(sUser);
            }

            DBController.Instance.CloseConnection();
        }
    }
    public class Data
    {

        public string Value;
        public string CustomerCode;
        public string CustomerName;
        public string MappedOutlet;

        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10057";
            string sReportName = "Customer Account Send";
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
        }
        public List<Data> SendAccount(string sCustomerCode)
        {
            List<Data> sResult = new List<Data>();
            int nCount = 0;
            Data _oData = new Data();

            int nWarehouseID = GetWHId(sCustomerCode);
            int nCustomerId = GetCustomerId(sCustomerCode);

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

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
                    if (nWarehouseID > 0)
                    {
                        command.CommandText = "INSERT INTO TELSysDB.dbo.t_DataTransfer (TableName,DataID, WarehouseID,TransferType,IsDownload,BatchNo,CreateDate) VALUES('t_CustomerAccount'," + nCustomerId + "," + nWarehouseID + ",1,1,0,'" + _Date + "')";
                        nCount = command.ExecuteNonQuery();
                    }


                    // Attempt to commit the transaction.
                    transaction.Commit();
                    if (nCount > 0)
                    {
                        _oData.Value = "Success";
                    }
                    else
                    {
                        _oData.Value = "Account NOT sent!!";
                    }
                    
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
        public List<Data> CheckCustomer(string sCustCode)
        {
            List<Data> sResult = new List<Data>();
            Data _oData = new Data();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = " Select a.CustomerCode, a.CustomerName, b.ShowroomCode from t_Customer a, t_Showroom b "+
                    " Where a.ParentCustomerID = b.CustomerID and a.CustomerCode = '"+ sCustCode + "'";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _oData.CustomerCode = reader["CustomerCode"].ToString();
                    _oData.CustomerName = reader["CustomerName"].ToString();
                    _oData.MappedOutlet = reader["ShowroomCode"].ToString();
                    _oData.Value = "Success";
                    sResult.Add(_oData);
                }
                else
                {
                    _oData.CustomerCode = "";
                    _oData.CustomerName = "";
                    _oData.MappedOutlet = "";
                    _oData.Value = "Customer Not Found!!";
                    sResult.Add(_oData);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return sResult;
        }
        private int GetWHId(string sCustCode)
        {
            int nResult = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = "Select top 1 WarehouseID from t_Showroom Where CustomerID = "+
                    "(Select ParentCustomerID from t_customer Where customerCode = '"+ sCustCode + "')";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nResult = Convert.ToInt32(reader["WarehouseID"]);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nResult;
        }
        private int GetCustomerId(string sCustCode)
        {
            int nResult = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSQL = "";
            sSQL = "Select CustomerID from t_customer Where customerCode = '" + sCustCode + "'";
            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nResult = Convert.ToInt32(reader["CustomerID"]);
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
}




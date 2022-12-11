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

public partial class jUpdateBasicData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sIMEI = c.Request.Form["IMEI"].Trim();

            //string sUser = "hakim";
            //string sIMEI = "358918058749541";
            string sBLLMarketGroup = "";
            string sVersion = "";

            if (c.Request.Form["BLLMarketGroup"] != null)
            {
                sBLLMarketGroup = c.Request.Form["BLLMarketGroup"].Trim();
            }
            if (c.Request.Form["VersionNo"] != null)
            {
                sVersion = c.Request.Form["VersionNo"].Trim();
            }
            string connStr = ConfigurationManager.AppSettings["jConnectionString"];
            DBController.Instance.OpenNewConnection();
            Data _oData = new Data();
            if (sBLLMarketGroup == "Yes")
            {
                _oData.BLLMarketGroupUpdate(connStr, sUser, sIMEI);
            }
            _oData.VersionUpdate(connStr, sVersion, sUser, sIMEI);
            DBController.Instance.CloseConnection();
        }
    }
    public class Result 
    {
        public string ResultValue;
    }
    public class Data 
    {
       
        public void BLLMarketGroupUpdate(string connStr, string sUser, string sIMEI)
        {

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;            // <== lacking
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Update TELSysDB.dbo.t_A_UserRegistration SET BLLMarketGroup=0 Where UserName='" + sUser + "' and IMEINo = '" + sIMEI + "' ";
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {

                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        public void VersionUpdate(string connStr, string sVersion, string sUser, string sIMEI)
        {

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;            // <== lacking
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Update TELSysDB.dbo.t_A_UserRegistration SET VersionNo='" + sVersion + "' Where UserName='" + sUser + "' and IMEINo = '" + sIMEI + "' ";
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {

                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
      
    }
   
}



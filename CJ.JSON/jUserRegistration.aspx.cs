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
using CJ.Class.ANDROID;

public partial class jUserRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUserName = c.Request.Form["UserName"].Trim();
            string sName = c.Request.Form["Name"].Trim();
            string sIMEI = c.Request.Form["IMEI"].Trim();
            string sSIMSerial = c.Request.Form["SIMSerial"].Trim();
            string sMobileNo = c.Request.Form["MobileNo"].Trim();

            //string sUserName = "hakim";
            //string sName = "Abdul Hakim";
            //string sIMEI = "89512548521";
            //string sSIMSerial = "11111111111111111111";
            //string sMobileNo = "01714089042";

            Datas _oDatas = new Datas();
            string sOutput = "";
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            sOutput = JsonConvert.SerializeObject(_oDatas.Insert(connStr, sUserName, sName, sIMEI, sSIMSerial, sMobileNo), Formatting.Indented);
            Response.Write(sOutput.ToString());
        }
    }
    public class Data
    {
        public string Value;

       
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
        public List<Data> Insert(string connStr, string sUserName, string sName, string sIMEI, string sSIMSerial, string sMobileNo)
        {
            List<Data> eList = new List<Data>();
            Data oData = new Data();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;           
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO t_A_UserRegistration (MobileNo, UserFullName, UserName, IMEINo, SIMSerialNo, RequestDate, Status) VALUES ('" + sMobileNo + "', '" + sName + "', '" + sUserName + "', '" + sIMEI + "', '" + sSIMSerial + "', '" + DateTime.Now + "','InActive') ";
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        oData.Value = "Success";
                        eList.Add(oData);
                    }
                    catch (SqlException)
                    {
                        oData.Value = "Unsuccess";
                        eList.Add(oData);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return eList;
        }
    }
}

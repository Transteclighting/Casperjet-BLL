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

using Newtonsoft.Json;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.ANDROID;

public partial class frmUserPermission : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;
            string sUserName = c.Request.Form["UserName"].Trim();
            //string sUserName = "hakim";
            string sIsNonPermissionMenu = "";
            if (c.Request.Form["IsNonPermissionMenu"] != null)
            {
                sIsNonPermissionMenu = c.Request.Form["IsNonPermissionMenu"].Trim();
            }
            UserPermissions oUserPermissions = new UserPermissions();
            DBController.Instance.OpenNewConnection();
            if (sIsNonPermissionMenu == "Yes")
            {
                oUserPermissions = oUserPermissions.RefreshAndroidNonPermission(oUserPermissions);
            }
            else
            {
                oUserPermissions = oUserPermissions.RefreshAndroidPermission(oUserPermissions, sUserName);
            }
            DBController.Instance.CloseConnection();


            List<Data> eList = new List<Data>();
            foreach (UserPermission oUserPermission in oUserPermissions)
            {
                Data _oData = new Data();
                _oData.Value = "Success";
                _oData.PermissionKey = oUserPermission.UserPermissions.ToString();
                _oData.Description = oUserPermission.Description.ToString();
                _oData.MenuType = oUserPermission.MenuType.ToString();
                _oData.Company = oUserPermission.Company.ToString();
                eList.Add(_oData);
            }
            string sOutput = JsonConvert.SerializeObject(eList, Formatting.Indented);
            Response.Write(sOutput.ToString());
        }
    }
    public class Data
    {
        public string PermissionKey;
        public string Description;
        public string Company;
        public string MenuType;
        public string Value;
    }
}

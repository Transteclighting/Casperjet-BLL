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

using CJ.Class;

public partial class frmBanner : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Arif Khan: 6-Apr-2014>Add this for auto login.
        User oUser;
        string sUserName = "";
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            sUserName = HttpContext.Current.User.Identity.Name;
            oUser = new User();
            DBController.Instance.OpenNewConnection();
            oUser.authenticate(sUserName);
            DBController.Instance.CloseConnection();

            Session.Add("User", oUser);
            Session.Add("UserID", oUser.UserId);

            Utility.UserId = oUser.UserId;
            Utility.Username = oUser.Username;
            Utility.EmployeeID = oUser.EmployeeID;
            Utility.UserFullname = oUser.UserFullName;
        }
        else
        {
            oUser = (User)Session["User"];
        }
        //Arif Khan.

        //User oUser=(User)Session["User"];
        ////lblUserName.Text = "Current User : " + this.Context.User.Identity.Name;
        lblUserName.Text = "Current User : " + oUser.Username;
        lblVersion.Text = "Web Version: " + ConfigurationManager.AppSettings["Version"].ToString();
        ////lblUserName.Text = (string)(Session["PassWord"]);
    }
    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {

    }
    #endregion
    
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmPasswordChange.aspx");
    }
    protected void LnkLogout_Click(object sender, EventArgs e)
    {
        User oUser = (User)Session["User"];
        Session.RemoveAll();
        //Arif Khan: 6-Apr-2014>Add this to stop persisting cookie used for auto login.
        FormsAuthentication.SetAuthCookie(oUser.Username, false);
        //
        AppLogger.LogInfo("Web: Success fully Logout User name =" + oUser.Username);
        Response.Redirect("frmLogout.aspx");
    }
}

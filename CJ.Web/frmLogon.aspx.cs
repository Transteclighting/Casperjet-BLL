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
using System.Net;
using System.ComponentModel;

using CJ.Class;
using CJ.Class.Library;

public partial class frmLogon : System.Web.UI.Page
{
    public DataSet oDSRespose = new DataSet();
    public DataSet oDSRequest = new DataSet();
    public User oUser;
    TELReg oReg;
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        
        if (txtUserId.Text != "")
        {
            if (txtPwd.Text != "")
            {
                try
                {
                    string sPrevliage = this.Login(txtUserId.Text, txtPwd.Text);

                    if (sPrevliage != null)  // means authetication
                    {

                        // Create the authentication ticket
                        FormsAuthenticationTicket authTicket = new
                        FormsAuthenticationTicket(1,  // version
                        txtUserId.Text,               // user name
                        DateTime.Now,                 // creation
                        DateTime.Now.AddMinutes(60),  // Expiration
                        false,                        // Persistent
                        sPrevliage);                     // User data

                        // Now encrypt the ticket.
                        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                        // Create a cookie and add the encrypted ticket to the 
                        // cookie as data.
                        HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        // Add the cookie to the outgoing cookies collection. 
                        Response.Cookies.Add(authCookie);
                        Session["UserName"] = txtUserId.Text;
                        Session["PassWord"] = txtPwd.Text;
                        //Session["UserSBUs"] = 

                        //Arif Khan: 6-Apr-2014>Add this auto login.
                        if (chkRememberMe.Checked)
                        {
                            FormsAuthentication.SetAuthCookie(txtUserId.Text, true);
                        }
                        //Arif Khan.

                        // Redirect the user to the originally requested page
                        Response.Redirect(FormsAuthentication.GetRedirectUrl(txtUserId.Text, false));
                    }
                    else
                    {
                        lblPwdError.Visible = false;
                        lblDbFailed.Visible = false;
                        lblUserIdError.Visible = false;
                        lblAuthencationFailed.Visible = true;
                    }
                }
                catch
                {
                    lblUserIdError.Visible = false;
                    lblDbFailed.Visible = true;
                    lblPwdError.Visible = false;
                    lblAuthencationFailed.Visible = false;
                }
            }
            else
            {
                lblUserIdError.Visible = false;
                lblDbFailed.Visible = false;
                lblPwdError.Visible = true;
                lblAuthencationFailed.Visible = false;
            }
        }
        else
        {
            lblPwdError.Visible = false;
            lblDbFailed.Visible = false;
            lblUserIdError.Visible = true;
            lblAuthencationFailed.Visible = false;
        }
        
    }

    public string Login(string sUsername, string sPassword)
    {
        oUser = new User();
        int nUserID = 0;
        DBController.Instance.OpenNewConnection();
        bool bAuthenticated=oUser.authenticate(sUsername);
        DBController.Instance.CloseConnection();

        if (bAuthenticated != false)
        {
            PDSAHash mph = new PDSAHash(PDSAHash.PDSAHashType.MD5);

            string sHashValue = mph.CreateHash(sPassword, oUser.Salt);
            if (oUser.UserPassword.CompareTo(sHashValue) != 0)
            {
                AppLogger.LogError ("Web: Invalid Password" );
                return null;
            }
            else
            {
                nUserID = oUser.UserId;
                Session.Add("User", oUser);
                Session.Add("UserID", nUserID);  

                Utility.UserId = oUser.UserId;
                Utility.Username = oUser.Username;
                Utility.EmployeeID = oUser.EmployeeID;
                Utility.UserFullname = oUser.UserFullName;

              
            

                AppLogger.LogInfo("Web: Success fully Login User name =" + oUser.Username);
                return "Yes";
            }
        }
        AppLogger.LogError("Web: Invalid Username");
        return null;

    }

}

/// <summary>
/// Compamy: Transcom Electronics Limited
/// Author: Shyam Sundar Biswas
/// Date: April 21, 2011
/// Time : 2:09 PM
/// Description: frmPasswordChange
/// Modify Person And Date:
/// </summary>

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


public partial class frmPasswordChange : System.Web.UI.Page
{
   

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    private int equals(string x, string y)
    {
        int i;
        i = string.Compare(x, y);
        return i;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        User oUser;
        if (txtCurrentPassword.Text == "")
        {
            lblErrCurrentPassword.Text = "Please Enter Current Password";
            lblErrNewPassword.Text = "";
            lblErrConfirmPassword.Text = "";
            return;
        }
        if (txtNewPassword.Text == "")
        {
            lblErrNewPassword.Text = "Please Enter New Password";
            lblErrCurrentPassword.Text = "";
            lblErrConfirmPassword.Text = "";
            return;
        }
        if (txtConfirmPassword.Text == "")
        {
            lblErrConfirmPassword.Text = "Please Check new pasword and confirmpassword";
            lblErrNewPassword.Text = "";
            lblErrCurrentPassword.Text = "";
            return;
        }

        int i = this.equals(this.txtNewPassword.Text.Trim(), this.txtConfirmPassword.Text.Trim());
        if (i != 0)
        {
            lblErrCurrentPassword.Text = "Please Check new pasword and confirmpassword";
            lblErrNewPassword.Text = "";
            lblErrConfirmPassword.Text = "";
            return;
        }
        //Resetting password     

        oUser= new User();
           
            DBController.Instance.OpenNewConnection();

            if (oUser.authenticate(Utility.Username) != false)
            {
                PDSAHash mph = new PDSAHash(PDSAHash.PDSAHashType.MD5);

                string sHashValue = mph.CreateHash(txtCurrentPassword.Text, oUser.Salt);
                if (oUser.UserPassword.CompareTo(sHashValue) != 0)
                {
                    AppLogger.LogWarning("Invalid old password" + Utility.Username);
                    lblErrConfirmPassword.Text = "Invalid old password";
                    lblErrNewPassword.Text = "";
                    lblErrCurrentPassword.Text = "";
                    return;
                }
                else
                {
                    mph = new PDSAHash(PDSAHash.PDSAHashType.MD5);
                    string sSaltValue = mph.CreateSalt();
                    oUser.UserId = Utility.UserId; ;
                    oUser.UserPassword = mph.CreateHash(txtConfirmPassword.Text.Trim(), sSaltValue);
                    oUser.Salt = sSaltValue;


                    try
                    {
                        DBController.Instance.CloseConnection();
                        DBController.Instance.BeginNewTransaction();
                        oUser.changepassword();
                        DBController.Instance.CommitTransaction();
                        AppLogger.LogInfo("Web: Success fully Password Change =" + Utility.Username);
                        string[] sSuccedCode =  { this.Context.User.Identity.Name.ToString() };
                        Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                        UIUtility.GetConfirmationMsg("Update", "Password", sSuccedCode, null, "frmPasswordChange.aspx", -1);

                        Response.Redirect("frmMessage.aspx");
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        AppLogger.LogError("Web: Unsuccessfull Password Change =" + Utility.Username);
                        string[] sSuccedCode =  { this.Context.User.Identity.Name.ToString() };
                        Session[Dictionary.SessionKey.KEY_MSG.ToString()] =
                        UIUtility.GetConfirmationMsg("Update", "Password", sSuccedCode, null, "frmPasswordChange.aspx", -1);
                        Response.Redirect("frmMessage.aspx");
                    }
                }
            }
      
    }
 
}
